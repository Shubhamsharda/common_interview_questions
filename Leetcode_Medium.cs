﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Transactions;

namespace ConsoleApp4
{
    class Leetcode_Medium
    {
        //https://leetcode.com/problems/longest-substring-without-repeating-characters/solution/
        //        Algorithm

        //The naive approach is very straightforward.But it is too slow. So how can we optimize it?

        //In the naive approaches, we repeatedly check a substring to see if it has duplicate character. But it is unnecessary.If a substring s_{ ij}
        //        s
        //ij
        //​
        //  from index ii to j - 1j−1 is already checked to have no duplicate characters.We only need to check if s[j] s[j] is already 
        //in the substring s_{ij
        //    }
        //    s
        //ij
        //​
        // .

        //To check if a character is already in the substring, we can scan the substring, which leads to an O(n^2)O(n
        //2
        // ) algorithm.But we can do better.

        //By using HashSet as a sliding window, checking if a character in the current can be done in O(1)O(1).

        //A sliding window is an abstract concept commonly used in array/string problems.A window is a range of elements 
        //in the array/string which usually defined by the start and end indices, i.e. [i, j)[i, j) (left-closed, right-open).
        //    A sliding window is a window "slides" its two boundaries to the certain direction.For example, if we slide [i, j)[i, j)
        //        to the right by 11 element, then it becomes [i+1, j+1)[i+1, j+1) (left-closed, right-open).


        //Back to our problem.We use HashSet to store the characters in current window [i, j)[i, j) (j = ij=i initially).
        //Then we slide the index jj to the right.If it is not in the HashSet, we slide jj further.Doing so until s[j] is already
        //in the HashSet.At this point, we found the maximum size of substrings without duplicate characters start with index ii.
        //If we do this for all ii, we get our answer.

    /*Algorith:
     window approach:
     loop till right window is not contained in dict
     if contained then move the left window and remove the left window from dict
     else if right window is unique(i.e., not contained in dict) then keep on adding to dict the right window and move the right indow.
     Worst case complexity is O(2N)*/
        public static int LengthOfLongestSubstring(string s)
        {
            var dict = new Dictionary<int,int>();
            int largetUnique = 0;
            int i = 0;
            int j = 0;
            while (j < s.Length)
            {
                if (dict.ContainsKey(s[j]))
                {
                    dict.Remove(s[i]);
                    i += 1;
                }
                else
                {
                    dict[s[j]] = 1;
                    largetUnique = Math.Max(largetUnique, j - i + 1);
                    j++;

                }
            }

            return largetUnique;
        }
        //        The above solution requires at most 2n steps.In fact, it could be optimized to require only n steps.Instead of using a set to tell if 
        //a character exists or not, we could define a mapping of the characters to its index.Then we can skip the characters immediately when we found 
        //    a repeated character.

        //The reason is that if s[j] s[j] have a duplicate in the range[i, j)[i, j) with index j'j 
        //′
        // , we don't need to increase ii little by little. We can skip all the elements in the range [i, j']
        //    [i, j 
        //′
        // ]
        //    and let ii to be j' + 1j 
        //′
        // +1 directly.
        /*Algorithm:
         create a dictionary which will have character to its index mapping.
         as you loop over the elements, keep updating the dict.
         if you find element in dict then move the left pointer to that index+1 by looking at the dictionary*/
        public static int LengthOfLongestSubstring2(string s)
        {
            var dict = new Dictionary<int, int>();
            int largetUnique = 0;
            int i = 0;
            int j = 0;
            while (j < s.Length)
            {
                if (dict.ContainsKey(s[j]))
                {
                    if (dict[s[j]] >= i)
                    {
                        i = dict[s[j]] + 1;
                    }
                }
                
                largetUnique = Math.Max(largetUnique, j - i + 1);
                dict[s[j]]=j;
                j = j + 1;
            }

            return largetUnique;
        }

        /*Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
Notice that the solution set must not contain duplicate triplets.*/

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            //[-1,0,1,2,-1,-4]
            var res = new List<IList<int>>();
            Array.Sort(nums);
            for(int i = 0; i < nums.Length - 2; i++)
            {
                int k = i + 1;
                int j = nums.Length - 1;
                if (i > 0 && nums[i] == nums[i - 1]) continue;  //skip duplicates
                while (k < j && j<=nums.Length-1 && k <= nums.Length - 1)
                {
                    
                    
                    if(nums[i]+nums[j]+nums[k] == 0)
                    {
                        res.Add(new List<int> { nums[i], nums[j], nums[k] });
                        j--;
                        k++;
                        while (j>k && nums[j] == nums[j +1]) j--;
                        while (k<j && nums[k] == nums[k - 1]) k++;
                    }
                    else
                    {
                        if((nums[i] + nums[j] + nums[k]) > 0)
                        {
                            j--;
                        }
                        if(nums[i] + nums[j] + nums[k] < 0)
                        {
                            k++;
                        }
                    }
                }
            }

            return res;
        }
        /*Search in Rotated Sorted Array
         */

        public static int RotatedBinarySearch(int[] nums, int target)
        {
            //nums = [4,5,6,7,8,1,2], target = 8
            //[4,5,6,7,8,1,2]
            //[0,1,2,3,4,5,6]

            //left 0    4	4  5
            //right 6   6	5	5	
            //mid  3     5	4	

            //first let us find the first element which is pivot point i.e., 1 in above example. It will be saved in 'left' variable
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = (left + right)/2;
                if (nums[mid] > nums[right])
                {
                    left = mid +1;
                }
                else
                {
                    right = mid;
                }
            }

            //Decide which of two arrays we need to search

            int start;
            int end;

            if (target > nums[nums.Length - 1])
            {
                start = 0;
                end = left - 1;
            }
            else
            {
                start = left;
                end = nums.Length - 1;
            }

            // Do binary search in one of two segments

            while (start <= end)
            {
                int mid = (start + end)/2;
                if (nums[mid] == target) return mid;
                if (nums[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }

        //Longest Palindromic Substring
        //Given a string s, return the longest palindromic substring in s.
        public static string LongestPalindrome(string s)
        {
            if (s == "" || s==null) return s;
            int start=0;
            int end=0;
            for(int i = 0; i < s.Length  -1; i++)
            {
                int len1 = expandFromTheMiddle(s, i, i);
                int len2 = expandFromTheMiddle(s, i, i+1);

                int len = Math.Max(len1, len2);
                if (len > (end - start+1))
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1);
        }

        public static int expandFromTheMiddle(string s,int start,int end)
        {
            int ret = 0;
            while(start>=0 && end <= s.Length-1 )
            {
                if (s[start] == s[end])
                {
                    ret = end - start + 1;
                    start--;
                    end++;
                }
                else
                    break;
                
            }
            return ret;
        }

        //Given an array of integers nums containing n + 1 integers where each integer is in the range[1, n] inclusive.
        //There is only one repeated number in nums, return this repeated number.
        //You must solve the problem without modifying the array nums and uses only constant extra space.
        //Find the Duplicate Number
        //        Example 1:

        //Input: nums = [1,3,4,2,2]
        //        Output: 2
        //Example 2:

        //Input: nums = [3,1,3,4,2]
        //        Output: 3
        //Example 3:

        //Input: nums = [1,1]
        //        Output: 1
        //Example 4:

        //Input: nums = [1,1,2]
        //        Output: 1

        public static int FindDuplicate(int[] nums)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i])] < 0) return Math.Abs(nums[i]);
                nums[Math.Abs(nums[i])] = nums[Math.Abs(nums[i])] * -1;
            }
            return -1;
        }
        //Find First and Last Position of Element in Sorted Array
        //Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.
        //If target is not found in the array, return [-1, -1].
        //You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [5, 7, 7, 8, 8, 10], target = 8
        //Output: [3,4]
        public static int[] SearchRange(int[] nums, int target)
        {
            int result1 = findleftindex(nums, target);
            int result2 = findrightindex(nums, target);
            return new int[] { result1, result2 };
        }
        public static int findleftindex(int[] nums, int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] >= target) end=mid-1;
                else
                    start = mid + 1;
                if (nums[mid] == target)
                {
                    index = mid;
                }

            }
            return index;
        }

        public static int findrightindex(int[] nums, int target)
        {
            int index = -1;
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] <= target) start = mid + 1;
                else
                    end = mid - 1;
                if (nums[mid] == target)
                {
                    index = mid;
                }

            }
            return index;
        }


        //Merge Intervals
        //Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping
//        intervals that cover all the intervals in the input.
//        Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
//        Output: [[1,6],[8,10],[15,18]]
//        Explanation: Since intervals[1, 3] and[2, 6] overlaps, merge them into[1, 6].
        public static int[][] MergeIntervals(int[][] intervals)
        {
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            int[][] res = new int[intervals.Length][];
            res[0] = intervals[0];
            int index = 0;
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= res[index][1])
                {
                    res[index][1] = Math.Max(res[index][1], intervals[i][1]);
                }
                else
                {
                    index++;
                    res[index] = intervals[i];
                }
            }
            var res2 = res.TakeWhile(x => x != null).ToArray() ;
            return res2;
        }
        //Given a binary array nums, return the maximum length of a contiguous subarray with an equal number of 0 and 1.
        //        Input: nums = [0,1,0]
        //        Output: 2
        //Explanation: [0, 1] (or[1, 0]) is a longest contiguous subarray with equal number of 0 and 1.

        public static int FindMaxLength(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            dict[0] = -1;
            int count = 0;
            int max = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    count--;
                }
                else
                {
                    count++;
                }

                if (dict.ContainsKey(count))
                {
                    max = Math.Max(max, i - dict[count]);
                }
                else
                {
                    dict[count] = i;
                }
            }
            return max;
        }
        //Given an integer array nums, return true if there exists a triple of indices (i, j, k) such that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices exists, return false.
        //        Input: nums = [2,1,5,0,4,6]
        //        Output: true
        //Explanation: The triplet(3, 4, 5) is valid because nums[3] == 0 < nums[4] == 4 < nums[5] == 6.

        public static bool IncreasingTriplet(int[] nums)
        {
            int min1 = Int32.MaxValue;
            int min2 = Int32.MaxValue;

            foreach(var num in nums)
            {
                if (num < min1)
                {
                    min1 = num;
                }
                if (num > min1)
                {
                    min2 = Math.Min(min2, num);
                }
                if (num > min2)
                {
                    return true;
                }
            }
            return false;
        }

        //Given a string s, check if it can be constructed by taking a substring of it and appending multiple copies of the substring together.

        //Example 1:
        //Input: s = "abab"
        //Output: true
        //Explanation: It is the substring "ab" twice.
        //        The maximum length of a "repeated" substring that you could get from a string would be half it's length
        //For example, s = "abcdabcd", "abcd" of len = 4, is the repeated substring.
        //You cannot have a substring >(len(s)/2), that can be repeated.
        //So, when ss = s + s, we will have atleast 4 parts of "repeated substring" in ss.
        //(s+s)[1:-1], With this we are removing 1st char and last char => Out of 4 parts of repeated substring, 2 part will be gone (they will no longer have the same substring).
        //ss.find(s) != -1, But still we have 2 parts out of which we can make s.And that's how ss should have s, if s has repeated substring.
        public static bool RepeatedSubstringPattern(string s)
        {
            if(s=="" || s == null)
            {
                return false;
            }

            string ss = s + s;
            if (ss.Substring(1, ss.Length - 2).Contains(s)) return true;

            return false;


        }

        //Subarray Sum Equals K
        //        Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
        //Example 1:
        //Input: nums = [1,1,1], k = 2
        //Output: 2

        // Sliding window -- No, contains negative number
        // hashmap + preSum
        /*
            1. Hashmap<sum[0,i - 1], frequency>
            2. sum[i, j] = sum[0, j] - sum[0, i - 1]    --> sum[0, i - 1] = sum[0, j] - sum[i, j]
                   k           sum      hashmap-key     -->  hashmap-key  =  sum - k
            3. now, we have k and sum.  
                  As long as we can find a sum[0, i - 1], we then get a valid subarray
                 which is as long as we have the hashmap-key,  we then get a valid subarray
            4. Why don't map.put(sum[0, i - 1], 1) every time ?
                  if all numbers are positive, this is fine
                  if there exists negative number, there could be preSum frequency > 1
        */
        /*The hashmap is to record presum and frequency of the presum. The reason why result += map.get(sum-k) is when at each sum if there is
         * a presum exists then there is a subarray between this sum and presum. But to use its frequency instead of just add 1 to result is 
         * because there can be multiple presum exists at this point of sum. Since each presum is added up from beginning there can be no two duplicate
         * presum and therefore no two duplicate subarrays exist.*/
        public static int subarraySum(int[] nums, int k)
        {
            
            int sum = 0;
            int result = 0;
            var presum = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == k) result++;
                if (presum.ContainsKey(sum - k))
                {
                    result += presum[sum - k];
                    presum[sum]++;
                }
                else
                {
                    presum[sum] = 1;
                }
                
            }

            return result;
        }
        //Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
        //Input: nums = [-7,-3,2,3,11]
        //Output: [4,9,9,49,121]
        public static int[] SortedSquares(int[] nums)
        {
            if (nums.Length == 1) return new int[] { nums[0] * nums[0] };
            if (nums.Length == 0) return new int[] { };
            int first_positive_index = 0;
            while (nums[first_positive_index] < 0 && first_positive_index<nums.Length) first_positive_index++;
            int last_negative_index = first_positive_index - 1;

            int[] res = new int[nums.Length];
            int index = 0;
            while(last_negative_index>=0 && first_positive_index < nums.Length)
            {
                if(Math.Pow(nums[first_positive_index],2) > Math.Pow(nums[last_negative_index], 2))
                {
                    res[index] = (int) Math.Pow(nums[last_negative_index], 2);
                    last_negative_index--;
                }
                else
                {
                    res[index] = (int)Math.Pow(nums[first_positive_index], 2);
                    first_positive_index++;
                }
                index++;
            }

            while (last_negative_index >= 0)
            {
                res[index++] = (int)Math.Pow(nums[last_negative_index--], 2);
            }
            while(first_positive_index < nums.Length)
            {
                res[index++] = (int)Math.Pow(nums[first_positive_index++], 2);
            }

            return res;
            
        }
        //Product of Array Except Self
        //        Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
        //The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
        //You must write an algorithm that runs in O(n) time and without using the division operation.

        //Example 1:

        //Input: nums = [1, 2, 3, 4]
        //Output: [24,12,8,6]
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] left = new int[nums.Length];
            int[] right = new int[nums.Length];

            int leftProd = 1;
            int rightProd= 1;
            for(int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    left[i] = 1;
                }
                else
                {
                    left[i] = leftProd;
                    
                }
                leftProd = nums[i] * leftProd;
            }
            for (int i = nums.Length-1; i >=0; i--)
            {
                if (i == nums.Length - 1)
                {
                    right[i] = 1;
                }
                else
                {
                    right[i] = rightProd;
                }
                rightProd = nums[i] * rightProd;
            }

            var res = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                res[i] = left[i] * right[i];
            }

            return res;
        }
        /*Given an array of non-negative integers nums, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Your goal is to reach the last index in the minimum number of jumps.

You can assume that you can always reach the last index.

 

Example 1:

Input: nums = [2,3,1,1,4]
Output: 2
Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.*/

        public static int Jump(int[] nums)
        {
            int position = nums.Length - 1;
            int steps = 0;

            while (position != 0)
            {
                for (int i = 0; i < position; i++)
                {
                    if (nums[i] >= position - i)
                    {
                        position = i;
                        steps++;
                        break;
                    }
                }
            }
            return steps;
        }

        /*You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.

Return true if you can reach the last index, or false otherwise.

 

Example 1:

Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
Example 2:

Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.*/
        public static bool canJump(int[] nums)
        {
            int lastGoodIndexPosition = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= lastGoodIndexPosition)
                {
                    lastGoodIndexPosition = i;
                }
            }

            return lastGoodIndexPosition == 0;
        }
        /*46. Permutations

Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]02*/

        public static List<List<int>> permute(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            // Arrays.sort(nums); // not necessary
            backtrack(list, new List<int>(), nums);
            //backtrack2(list, new List<int>(), new List<int>(nums));
            return list;
        }


        public static void backtrack(List<List<int>> list, List<int> tempList, int[] nums)
        {
            if (tempList.Count == nums.Length)
            {
                list.Add(new List<int>(tempList));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (tempList.Contains(nums[i])) continue; // element already exists, skip
                    tempList.Add(nums[i]);
                    backtrack(list, tempList, nums);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }


        /*47. Permutations II
        Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.
        Example 1:

        Input: nums = [1,1,2]
        Output:
        [[1,1,2],
         [1,2,1],
         [2,1,1]]*/
        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            //Array.Sort(nums);
            var dict = new Dictionary<int, int>();
            foreach (var ele in nums)
            {
                if (dict.ContainsKey(ele))
                {
                    dict[ele] += 1;
                }
                else
                {
                    dict[ele] = 1;
                }
            }
            //IList<int> lst = new List<int>();
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> lst3 = new List<int>();
            return backtrack2(nums, dict, lst3, res);
        }

        public static IList<IList<int>> backtrack2(int[] nums, Dictionary<int, int> dict, IList<int> lst, IList<IList<int>> res)
        {
            if (lst.Count == nums.Length)
            {
                res.Add(new List<int>(lst));
            }
            else
            {
                foreach (var ele in dict.Keys.ToList())
                {
                    if (dict[ele] > 0)
                    {
                        lst.Add(ele);
                        dict[ele] -= 1;
                        backtrack2(nums, dict, lst, res);
                        dict[ele] += 1;
                        lst.RemoveAt(lst.Count - 1);
                    }
                }
            }
            return res;
        }

        public static IList<IList<string>> Partition(string s)
        {
            return backtrack3(s, 0, new List<string>(), new List<IList<string>>());
        }

        public static IList<IList<string>>  backtrack3(string str,int start,IList<string> partition, IList<IList<string>> res)
        {
            if(start > str.Length - 1)
            {
                res.Add(new List<string>(partition));
            }
            else
            {
                for(int end = start; end <= str.Length - 1; end++)
                {
                    if (isPalindrome(start, end, str))
                    {
                        partition.Add(str.Substring(start, end - start + 1));
                        backtrack3(str, end + 1, partition, res);
                        partition.RemoveAt(partition.Count - 1);
                    }
                }
            }

            return res;
        }
        public static bool isPalindrome(int start,int end,string str)
        {
            while (start < end)
            {
                if (str[start] != str[end]) return false;
                start++;end--;
            }
            return true;
        }
    }




}