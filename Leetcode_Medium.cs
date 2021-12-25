using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        /*Word Search
         Given an m x n grid of characters board and a string word, return true if word exists in the grid.

         The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are
         horizontally or vertically neighboring. The same letter cell may not be used more than once.

            Input: board = [["A","B","C","E"]
                            ,["S","F","C","S"],
                            ["A","D","E","E"]], word = "ABCCED"
            Output: true
             */
        public static bool Exist(char[][] board, string word)
        {
            var chars = word.ToCharArray();
            var startIndexes = new List<Point>();
            for(int i = 0; i < board.Length; i++)
            {
                for(int j =0;j<board[0].Length; j++)
                {
                    if (board[i][j] == word[0])
                        startIndexes.Add(new Point(i, j));
                }
            }

            bool[,] visited = new bool[board.Length,board[0].Length];

            bool textFound = false;
            foreach (var point in startIndexes)
            {
                textFound = Func(board, word, point.i,point.j,0);
                if (textFound)
                {
                    break;
                }
            }
            return textFound;
        }

        public static bool Func(char[][] board, string word, int row, int column,int wordInd)
        {
            if (row>board.Length-1 || column>board[0].Length-1 || row<0||column<0|| wordInd > word.Length - 1|| board[row][column]=='*')
            {
                return false;
            }
            
            if (board[row][column] == word[wordInd])
            {
                if(wordInd == word.Length - 1)
                {
                    return true;
                }
                else
                {
                    board[row][column] = '*';
                    var res = Func(board, word, row + 1, column, wordInd + 1) || Func(board, word, row, column + 1, wordInd + 1) || Func(board, word, row - 1, column, wordInd + 1) || Func(board, word, row, column - 1, wordInd + 1);
                    board[row][column] = word[wordInd];
                    return res;
                }
            }
            else
            {
                return false;
            }
        }

        /*Maximum Product Subarray
         * Given an integer array nums, find a contiguous non-empty subarray within the array that has the largest product,
         * and return the product.

It is guaranteed that the answer will fit in a 32-bit integer.

A subarray is a contiguous subsequence of the array.

 

Example 1:

Input: nums = [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.
         */
        public static void MaxProduct()
        {
            int[] nums = new int[] { 2, 3, -2, 4 };
            var result = nums.Max();
            int currMax = 1;
            int currMin = 1;
            foreach(var num in nums)
            {
                var temp = currMax;
                currMax = Math.Max(num, Math.Max(currMax * num, currMin * num));
                currMin = Math.Min(num, Math.Min(temp * num, currMin * num));
                result = Math.Max(result, currMax);
            }
            Console.WriteLine(result);
        }
        /*Multiply Strings
         Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
        Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.
        Example 1:
        
        Input: num1 = "2", num2 = "3"
        Output: "6"
        Example 2:
        
        Input: num1 = "123", num2 = "456"
        Output: "56088"
         */
        public static string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";
            var res = new int[num1.Length + num2.Length];
            num1 = new String(num1.Reverse().ToArray());
            num2 = new String(num2.Reverse().ToArray());
            for(int i = 0; i < num1.Length; i++)
            {
                for(int j = 0; j < num2.Length; j++)
                {
                    int a = Convert.ToInt32(num1[i].ToString());                                           
                    int b = Convert.ToInt32(num2[j].ToString());
                    int digit = a * b;
                    res[i + j] += digit;
                    res[i + j + 1] += res[i + j] / 10;
                    res[i + j] = res[i + j] % 10;
                }
            }
            var res2 = res.Reverse();
            var ret = res2.Aggregate("", (acc, x) => acc + x.ToString());
            int startPoint = 0;
            for(int i = 0; i < ret.Length; i++)
            {
                if (ret[i] != '0')
                {
                    startPoint = i;
                    break;
                }
            }
            return ret.Substring(startPoint);
        }
        /*Combination Sum
         Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

 

Example 1:

Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.
Example 2:

Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]
         
         
         */
        public static IList<IList<int>>  CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSumBacktrack(list, new List<int>(), candidates, target, 0);
            return list;
        }

        private static void CombinationSumBacktrack(IList<IList<int>> list, List<int> tempList, int[] nums, int remain, int start)
        {
            if (remain < 0) return;
            else if (remain == 0) list.Add(new List<int>(tempList));
            else
            {
                for(int i = start; i < nums.Length; i++)
                {
                    tempList.Add(nums[i]);
                    CombinationSumBacktrack(list,tempList,nums,remain - nums[i],i);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> list = new List<IList<int>>();
            CombinationSum2Backtracking(list, new List<int>(),candidates, target, 0);
            return list;
        }

        private static void CombinationSum2Backtracking(IList<IList<int>> list, List<int> tempList,int[] candidates,int remainig,int start)
        {
            if (remainig < 0) return;
            else if(remainig == 0) list.Add(new List<int>(tempList));
            else
            {
                for(int i = start; i < candidates.Length; i++)
                {
                    if(i>start && candidates[i] == candidates[i - 1])
                    {
                        continue;
                    }
                    tempList.Add(candidates[i]);
                    CombinationSum2Backtracking(list, tempList, candidates, remainig - candidates[i], i + 1);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }

        /*
         Permutations
         Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Example 2:

Input: nums = [0,1]
Output: [[0,1],[1,0]]
         */
        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            PermuteBacktracking(list, new List<int>(), nums);
            return list;
        }

        private static void PermuteBacktracking(IList<IList<int>> list, List<int> tempList,int[] nums)
        {
            if(tempList.Count == nums.Length)
            {
                list.Add(new List<int>(tempList));
            }
            else
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    if (tempList.Contains(nums[i])) continue;
                    tempList.Add(nums[i]);
                    PermuteBacktracking(list, tempList, nums);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }

        /*
         Permutations II
        Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

 

Example 1:

Input: nums = [1,1,2]
Output:
[[1,1,2],
 [1,2,1],
 [2,1,1]]
Example 2:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
         */
        public static IList<IList<int>> PermuteUnique2(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            var used = new bool[nums.Length];
            PermuteUniqueBacktrack(list,nums,used,new List<int>());
            return list;
        }

        private static void PermuteUniqueBacktrack(IList<IList<int>> list, int[] nums,bool[] used,List<int> tempList)
        {
            if (tempList.Count == nums.Length) list.Add(new List<int>(tempList));
            else
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    if (used[i] || i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
                    tempList.Add(nums[i]);
                    used[i] = true;
                    PermuteUniqueBacktrack(list, nums, used, tempList);
                    used[i] = false;
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
        public IList<string> LetterCombinations(string digits)
        {
            var dict = new Dictionary<char, List<string>>()
            {
            { '0', new List<string>() { " "} },
            { '1', new List<string>() },
            { '2', new List<string>() { "a", "b", "c" } },
            { '3', new List<string>() { "d", "e", "f" } },
            { '4', new List<string>() { "g", "h", "i" } },
            { '5', new List<string>() { "j", "k", "l" } },
            { '6', new List<string>() { "m", "n", "o" } },
            { '7', new List<string>() { "p", "q", "r","s" } },
            { '8', new List<string>() { "t", "u", "v" } },
            { '9', new List<string>() { "w", "x", "y","z" } }
            };
            if (digits == "")
            {
                return new List<string>();
            }
            var result = new List<string>();
            backtrack99(new List<char>(), digits, result, dict, 0);
            return result;
        }

        public void backtrack99(List<char> tempStr, string digits, List<string> result, Dictionary<char, List<string>> dict, int digitIndex)
        {
            if (tempStr.Count == digits.Length)
            {
                result.Add(new string(tempStr.ToArray()));
            }
            else
            {
                List<string> chars = dict[digits[digitIndex]];
                for (int i = 0; i < chars.Count; i++)
                {
                    tempStr.AddRange(chars[i].ToCharArray());
                    backtrack99(tempStr, digits, result, dict, digitIndex + 1);
                    tempStr.RemoveAt(tempStr.Count - 1);
                }
            }
        }

        /*Rotate Image
         Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[7,4,1],[8,5,2],[9,6,3]]
         */
        public void Rotate(int[][] matrix)
        {
            swapcolumns(matrix);
            swapSymmetry(matrix);
        }

        private void swapSymmetry(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i + 1; j < matrix[0].Length; j++)
                {
                    swap(i, j, j, i, matrix);
                }
            }
        }

        private void swap(int a, int b, int i, int j, int[][] matrix)
        {
            var temp = matrix[a][b];
            matrix[a][b] = matrix[i][j];
            matrix[i][j] = temp;
        }

        private void swapcolumns(int[][] matrix)
        {
            int lastRow = matrix.Length - 1;
            int lastCol = matrix[0].Length - 1;

            for (int j = 0; j <= lastCol; j++)
            {
                int start = 0;
                int end = lastRow;
                while (start < end)
                {
                    swap(start, j, end, j, matrix);
                    start++;
                    end--;
                }
            }
        }

        /* Minimum Path Sum
         Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.
        Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
         */
        public int MinPathSum(int[][] grid)
        {
            Dictionary<(int, int), int> dict = new Dictionary<(int, int), int>();
            return MinPathSum(grid, 0, 0, dict);
        }
        public int MinPathSum(int[][] grid, int i, int j, Dictionary<(int, int), int> dict)
        {
            int maxrow = grid.Length - 1;
            int maxcol = grid[0].Length - 1;
            if (i == grid.Length - 1 && j == grid[0].Length - 1)
            {
                return dict[(i, j)] = grid[i][j];
            }
            else if (i > maxrow || j > maxcol)
            {
                return Int32.MaxValue;
            }
            else if (dict.ContainsKey((i, j)))
            {
                return dict[(i, j)];
            }
            else
            {
                return dict[(i, j)] = grid[i][j] + Math.Min(MinPathSum(grid, i + 1, j, dict), MinPathSum(grid, i, j + 1, dict));
            }
        }

        /*
        Next Permutation
       Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

If such an arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).

The replacement must be in place and use only constant extra memory.
       Example 1:

Input: nums = [1,2,3]
Output: [1,3,2]
Example 2:

Input: nums = [3,2,1]
Output: [1,2,3]
        */



        public static void NextPermutation(int[] nums)
        {
            int i = nums.Length-2;
            while (i >= 0 && nums[i] >= nums[i+1]) i--;
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i]) j--;
                swap(i, j, nums);
            }
            reverse(i + 1, nums.Length - 1, nums);
        }

        private static void reverse(int start, int end, int[] nums)
        {
            while (start < end)
            {
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        private static void swap(int i, int j, int[] nums)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        /*Subsets
         Given an integer array nums of unique elements, return all possible subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.
Example 1:
Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
         */
        public IList<IList<int>> Subsets(int[] nums)
        {
            Array.Sort(nums);
            var list = new List<int>();
            var result = new List<IList<int>>();
            backtrack55(nums, 0, list, result);
            return result;
        }
        private void backtrack55(int[] nums,int start,List<int> list, List<IList<int>> result)
        {
            result.Add(new List<int>(list));
            for(int i = start; i < nums.Length; i++)
            {
                list.Add(nums[i]);
                backtrack55(nums, i + 1, list, result);
                list.RemoveAt(list.Count - 1);
            }
        }

        /*
         Longest Consecutive Sequence
        Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.
You must write an algorithm that runs in O(n) time.

Example 1:

Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
Example 2:

Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9
         */
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var set = new HashSet<int>(nums);
            int maxLength = 1;
            foreach(var ele in nums)
            {
                if (set.Contains(ele - 1))
                {
                    continue;
                }
                var curr = ele+1;
                int count = 1;
                while (set.Contains(curr))
                {
                    count++;
                    curr++;
                }
                if (count > maxLength) maxLength = count;
            }
            return maxLength;

        }

        /*# Boyer's Moore Algorithm --> O(1) Space
        
        # We first assume that our first num is the majority element
        # So the count here is 1 as we have seen it 1 times, if the 
        # count in the end is greater than 0 we are sure that this is majority element
        # as if you take count of majority element and subtract sum of all counts of non
        # Majority element, if that count is still positive that it proves that is
        # majority element. We do not need to check count in end over here as we are 
        # sure that there exists a majority element.*/

        public int MajorityElement(int[] nums)
        {
            var count = 1;
            //Our Initial guess that this is the majority element
            var result = nums[0];
            for(int i=1;i<nums.Length;i++)
            {
                /*# If the next number is not same as prev
            # and count becomes 0 make this number as majority element and initialize 
            # count to 1 again else just decrease the count*/
                if (nums[i] != result)
                {
                    //# decrease count by 1
                    count--;
                    //Make this element as majority element
                    if (count == 0)
                    {
                        result = nums[i];
                        count = 1;
                    }
                }
                else
                {
                    //This is same element as previous one.
                    count++;
                }
            }
            return result;
        }

        public static void MoveZeroes(int[] nums)
        {
            int snowBallSize = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    snowBallSize++;
                }
                else if (snowBallSize > 0)
                {
                    int t = nums[i];
                    nums[i] = 0;
                    nums[i - snowBallSize] = t;
                }
            }
        }
        private static void Swap(int i, int j, int[] nums)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int ret = -1;
            for (int i = 0; i < gas.Length - 1; i++)
            {
                int currgas = gas[i];
                bool solutionFound = false;
                bool[] visited = new bool[gas.Length];
                Console.WriteLine($" i = {i}");
                for (int j = i ; ; j = (j + 1) % gas.Length)
                {
                    Console.WriteLine($" j = {j}");
                    Console.WriteLine($" currGas  = {currgas}");


                    if (visited[j])
                    {
                        if (currgas >= 0)
                        {
                            solutionFound = true;
                            ret = i;
                        }
                        break;
                    }
                    visited[j] = true;
                    currgas = currgas - cost[j];
                    if (currgas < 0) break;
                    currgas = currgas + gas[(j + 1) % gas.Length];
                }
                if (solutionFound) break;
                
            }
            return ret;
        }
    }

    public struct Point
    {
        public int i;
        public int j;
        public Point(int x, int y)
        {
            i = x;
            j = y;
        }
    }

    public class LRUCache
    {
        LLNode head = new LLNode();
        LLNode tail = new LLNode();
        Dictionary<int, LLNode> dict;
        int capacity;

        public LRUCache(int capacity)
        {
            dict = new Dictionary<int, LLNode>();
            head.next = tail;
            tail.prev = head;
            this.capacity = capacity;
        }
        
        public int Get(int key)
        {
            int result = -1;
            LLNode node = dict.GetValueOrDefault(key);
            if (node != null)
            {
                delete(node);
                add(node);
                result = node.val;
            }
            return result;
        }

        public void Put(int key, int value)
        {
            LLNode node = dict.GetValueOrDefault(key);
            if (node != null)
            {
                delete(node);
                node.val = value;
                add(node);
            }
            else
            {
                if(dict.Count == capacity)
                {
                    dict.Remove(tail.prev.key);
                    delete(tail.prev);
                }

                LLNode new_node = new LLNode();
                new_node.key = key;
                new_node.val = value;

                dict[key] = new_node;
                add(new_node);
            }
        }

        public void add(LLNode node)
        {
            var nextNode = head.next;
            head.next = node;
            node.prev = head;
            node.next = nextNode;
            nextNode.prev = node;
        }
        public void delete(LLNode node)
        {
            var nextNode = node.next;
            var prevNode = node.prev;
            nextNode.prev = prevNode;
            prevNode.next = nextNode;
        }

    }

    public class LLNode
    {
        public int key { get; set; }
        public int val { get; set; }

        public LLNode next { get; set; }
        public LLNode prev { get; set; }
    }

    class MinStack
    {
        private Node22 head;

        public void push(int x)
        {
            if (head == null)
                head = new Node22(x, x, null);
            else
                head = new Node22(x, Math.Min(x, head.min), head);
        }

        public void pop()
        {
            head = head.next;
        }

        public int top()
        {
            return head.val;
        }

        public int getMin()
        {
            return head.min;
        }

        
    }
    public class Node22
    {
        public int val;
        public int min;
        public Node22 next;

        public Node22(int val, int min, Node22 next)
        {
            this.val = val;
            this.min = min;
            this.next = next;
        }
    }




}
