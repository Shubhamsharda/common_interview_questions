using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    class SearchingAndSorting
    {
        //        Sorted Merge: You are given two sorted arrays, A and B, where A has a large enough buffer at the
        //end to hold B.Write a method to merge B into A in sorted order.
        public static void SortedMerge(int[] a, int[] b, int lastIndexA)
        {
            int i = a.Length - 1;
            int j = b.Length - 1;
            while (i >= 0)
            {
                Console.WriteLine(lastIndexA + " " + j + " " + i);
                if (a[lastIndexA] > b[j])
                {
                    a[i] = a[lastIndexA];
                    i--;
                    lastIndexA--;
                }
                else
                {
                    a[i] = b[j];
                    if (i > 0)
                        i--;
                    if (j > 0)
                        j--;
                }
            }
            foreach (var ele in a)
            {
                Console.WriteLine(ele);
            }
        }

        //        Search in Rotated Array: Given a sorted array of n integers that has been rotated an unknown
        //number of times, write code to find an element in the array.You may assume that the array was
        //originally sorted in increasing order.
        //EXAMPLE
        //lnput:find5in{ 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14}
        //        Output: 8 (the index of 5 in the array)




        //Group Anagrams: Write a method to sort an array of strings so that all the anagrnms are next to
        //each other.

        public static string[] groupAnagram(string[] arr)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            foreach (var str in arr)
            {
                string sortedStr;
                sortedStr = String.Concat(str.OrderBy(x => x));
                if (map.ContainsKey(sortedStr))
                {
                    map[sortedStr].Add(str);
                }
                else
                {
                    map[sortedStr] = new List<string>() { str };
                }

            }

            var res = new string[arr.Length];
            int i = 0;
            foreach (var (k, v) in map)
            {
                foreach (string str in v)
                {
                    res[i] = str;
                    i++;
                }
            }

            return res;
        }

        //Sorted Search, No Size: You are given an array-like data structure Listy which lacks a size
        //method.It does, however, have an elementAt(i) method that returns the element at index i in
        //0( 1) time.If i is beyond the bounds of the data structure, it returns -1. (For this reason, the data
        //structure only supports positive integers.) Given a Listy which contains sorted, positive integers,
        //find the index at which an element x occurs. If x occurs multiple times, you may return any index.

        public static void search(int[] list, int value)
        {
            int ind = 1;
            try
            {
                while (list[ind] != -1 && list[ind] < value)
                {
                    ind *= 2;
                }
                int res = binarySearch(list, value, ind / 2, ind);
                Console.WriteLine(res);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int binarySearch(int[] lst, int val, int low, int high)
        {
            int mid;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (lst[mid] == -1 || lst[mid] > val)
                {
                    high = mid - 1;
                }
                else if (lst[mid] < val)
                {
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }

        //        Sparse Search: Given a sorted array of strings that is interspersed with empty strings, write a
        //method to find the location of a given string.
        //EXAMPLE
        //Input: ball, {"at","" "" ""
        //, , , "ball", ,,,,
        //,
        //,,,,
        //, "car", ""
        //,
        //""
        //, "dad", ""
        //""}
        //Output: 4
        public static void sparseSearch()
        {
            string[] arr = new string[] { "aab", "", "", "", "aba", "abb", "", "", "", "bc", "", "", "", "cd", "ce" };
            int res = sparseSearch(arr, "aab", 0, arr.Length - 1);
            Console.WriteLine(res);
        }
        public static int sparseSearch(string[] arr, string val, int low, int upper)
        {
            int mid = (low + upper) / 2;
            if (arr[mid] == "")
            {
                int left = mid;
                int right = mid;
                while (true)
                {
                    if (left >= low && arr[left] != "")
                    {
                        mid = left;
                        break;
                    }
                    else if (right <= upper && arr[upper] != "")
                    {
                        mid = upper;
                        break;
                    }
                    else if (left < low && right > upper)
                    {
                        return -1;
                    }
                    left--;
                    right++;
                }
            }
            if (arr[mid] == val)
            {
                return mid;
            }
            else if (arr[mid].CompareTo(val) > 0)
            {
                return sparseSearch(arr, val, low, mid - 1);
            }
            else
            {
                return sparseSearch(arr, val, low, mid - 1);
            }
        }

        //Peaks and Valleys: In an array of integers, a "peak" is an element which is greater than or equal
        //to the adjacent integers and a "valley" is an element which is less than or equal to the adjacent
        //integers.For example, in the array { 5, 8, 6, 2, 3, 4, 6}, {8, 6} are peaks and {5, 2}
        //    are valleys.Given an
        //array of integers, sort the array into an alternating sequence of peaks and valleys.
        //EXAMPLE
        //Input: { 5, 3, 1, 2, 3}
        //Output: {5, 1, 3, 2, 3}

        public static void PeakAndValley()
        {
            int[] arr = new int[] { 5, 3, 1, 2, 3 };
            for (int i = 1; i < arr.Length; i += 2)
            {
                int biggestIndex = findBiggestIndex(i - 1, i, i + 1, arr);
                if (i != biggestIndex)
                {
                    swap(i, biggestIndex, arr);
                }
            }

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        public static int findBiggestIndex(int a, int b, int c, int[] arr)
        {
            int valuea = a >= 0 && a < arr.Length ? arr[a] : Int32.MinValue;
            int valueb = b >= 0 && b < arr.Length ? arr[b] : Int32.MinValue;
            int valuec = c >= 0 && c < arr.Length ? arr[c] : Int32.MinValue;

            int maxx = Math.Max(valuea, Math.Max(valueb, valuec));
            if (maxx == valuea) return a;
            if (maxx == valueb) return b;
            else return c;
        }

        public static void swap(int a, int b, int[] arr)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        //        Smallest Difference: Given two arrays of integers, compute the pair of values(one value in each
        //array) with the smallest(non-negative) difference.Return the difference.
        //EXAMPLE
        //Input: {l, 3, 15, 11, 2}, {23, 127, 235, 19, 8}
        //Output: 3. That is, the pair(11, 8).

        public static void findSmallestDiff()
        {
            int[] arr1 = { 1, 2, 11, 15 };
            int[] arr2 = { 4, 12, 19, 23, 127, 235 };
            Array.Sort(arr1);
            Array.Sort(arr2);
            int a = 0;
            int b = 0;
            int diff = Int32.MaxValue;
            while (a < arr1.Length && b < arr2.Length)
            {
                if (Math.Abs(arr1[a] - arr2[b]) < diff)
                {
                    diff = Math.Abs(arr1[a] - arr2[b]);
                }
                if (arr1[a] > arr2[b])
                {
                    b++;
                }
                else
                {
                    a++;
                }
            }
            Console.WriteLine(diff);
        }

        //English Int: Given any integer, print an English phrase that describes the integer(e.g., "One
        //Thousand, Two Hundred Thirty Four").
        public static void numberInWords()
        {
            String[] smalls = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven",
 "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
 "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
            String[] tens ={"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy",
 "Eighty", "Ninety"};
            String[] bigs = { "", "Thousand", "Million", "Billion" };
            String hundred = "Hundred";
            String negative = "Negative";

            Console.WriteLine(convert(1200000));

            String convert(int num)
            {
                if (num == 0)
                {
                    return smalls[0];
                }
                else if (num < 0)
                {
                    return negative + " " + convert(-1 * num);
                }
                LinkedList<String> parts = new LinkedList<string>();
                int chunkCount = 0;


                while (num > 0)
                {
                    if (num % 1000 != 0)
                    {
                        String chunk = convertChunk(num % 1000) + " " + bigs[chunkCount];
                        parts.AddFirst(chunk);
                    }
                    num /= 1000; // shift chunk
                    chunkCount++;
                }

                return listToString(parts);
            }

            String convertChunk(int number)
            {
                LinkedList<String> parts = new LinkedList<String>();

                /* Convert hundreds place */
                if (number >= 100)
                {
                    parts.AddLast(smalls[number / 100]);

                }
                parts.AddLast(hundred);
                number %= 100;

                /* Convert tens place */
                if (number >= 10 && number <= 19)
                {
                    parts.AddLast(smalls[number]);
                }
                else if (number >= 20)
                {
                    parts.AddLast(tens[number / 10]);
                    number %= 10;
                }

                /* Convert ones place */
                if (number >= 1 && number <= 9)
                {
                    parts.AddLast(smalls[number]);
                }

                return listToString(parts);
            }
            /* Convert a linked list of strings to a string, dividing it up with spaces. */
            string listToString(LinkedList<String> parts)
            {
                StringBuilder sb = new StringBuilder();
                while (parts.Count > 1)
                {
                    sb.Append(parts.First());
                    parts.RemoveFirst();
                    sb.Append(" ");
                }
                sb.Append(parts.First());

                return sb.ToString();
            }


        }
        //        A peak element is an element that is strictly greater than its neighbors.
        //Given an integer array nums, find a peak element, and return its index.If the array contains multiple peaks, return the index to any of the peaks.

        //You may imagine that nums[-1] = nums[n] = -∞.
        //You must write an algorithm that runs in O(log n) time.

        //        We can view any given sequence in numsnums array as alternating ascending and descending sequences.By making use of this,
        //and the fact that we can return any peak as the result, we can make use of Binary Search to find the required peak element.

        //In case of simple Binary Search, we work on a sorted sequence of numbers and try to find out the required number by reducing the search 
        //space at every step.In this case, we use a modification of this simple Binary Search to our advantage. We start off by finding the middle element, midmid from the given numsnums array. If this element happens to be lying in a descending sequence of numbers.or a local falling slope(found by comparing nums[i] nums[i] to its right neighbour), it means that the peak will always lie towards the left of this element.Thus, we reduce the search space to the left of midmid(including itself) and perform the same process on left subarray.

        //If the middle element, midmid lies in an ascending sequence of numbers, or a rising slope(found by comparing nums[i] nums[i] to its right 
        //neighbour), it obviously implies that the peak lies towards the right of this element.Thus, we reduce the search space to the right of midmid and perform the same process on the right subarray.

        //In this way, we keep on reducing the search space till we eventually reach a state where only one element is remaining in the search space.
        //This single element is the peak element.

        //To see how it works, let's consider the three cases discussed above again.


        //Case 1. In this case, we firstly find 33 as the middle element.Since it lies on a falling slope, we reduce the search space to [1, 2, 3].
        //For this subarray, 22 happens to be the middle element, which again lies on a falling slope, reducing the search space to[1, 2]. Now, 11 acts as the middle element and it lies on a falling slope, reducing the search space to[1] only. Thus, 11 is returned as the peak correctly.
        //[1,2,3,1]
        //[0,1,2,3]
        public static int FindPeakElement(int[] nums)
        {
            int start = 0, end = nums.Length - 1, mid;
            while (start < end)
            {
                mid = (start + end) / 2;
                if (nums[mid] > nums[mid + 1])
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return start;
        }

        

        public int[] TopKFrequent(int[] nums, int k)
        {

            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict[nums[i]] = 1;
                }
            }

            return dict.Select(kv => new int[] { kv.Key, kv.Value }).OrderByDescending(x => x[1]).Take(k).Select(x => x[0]).ToArray();

        }
        // Sort Colors       Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
        //We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
        //You must solve this problem without using the library's sort function.

        public static void SortColors(int[] nums)
        {
            int start = 0, end = nums.Length - 1, index = 0;

            while(index<=end && start < end)
            {
                if(nums[index] == 0)
                {
                    nums[index] = nums[start];
                    nums[start] = 0;
                    index++;
                    start++;
                }
                else if (nums[index] == 2)
                {
                    nums[index] = nums[end];
                    nums[end] = 2;
                    end--;
                }
                else if (nums[index] == 1)
                {
                    index++;
                }

                
            }
            foreach (var ele in nums)
            {
                Console.WriteLine(ele);
            }
        }
        static int MAX_CHARS = 256;

        // Function to find smallest window containing
        // all distinct characters
        static string findSubString(string str)
        {
            int n = str.Length;

            // if string is empty or having one char
            if (n <= 1)
                return str;

            // Count all distinct characters.
            int dist_count = 0;
            bool[] visited = new bool[MAX_CHARS];
            for (int i = 0; i < n; i++)
            {
                if (visited[str[i]] == false)
                {
                    visited[str[i]] = true;
                    dist_count++;
                }
            }

            // Now follow the algorithm discussed in below
            // post. We basically maintain a window of
            // characters that contains all characters of given
            // string.
            int start = 0, start_index = -1,
                min_len = int.MaxValue;

            int count = 0;
            int[] curr_count = new int[MAX_CHARS];
            for (int j = 0; j < n; j++)
            {
                // Count occurrence of characters of string
                curr_count[str[j]]++;

                // If any distinct character matched,
                // then increment count
                if (curr_count[str[j]] == 1)
                    count++;

                // if all the characters are matched
                if (count == dist_count)
                {
                    // Try to minimize the window i.e., check if
                    // any character is occurring more no. of
                    // times than its occurrence in pattern, if
                    // yes then remove it from starting and also
                    // remove the useless characters.
                    while (curr_count[str[start]] > 1)
                    {
                        if (curr_count[str[start]] > 1)
                            curr_count[str[start]]--;
                        start++;
                    }

                    // Update window size
                    int len_window = j - start + 1;
                    if (min_len > len_window)
                    {
                        min_len = len_window;
                        start_index = start;
                    }
                }
            }

            // Return substring starting from start_index
            // and length min_len

            return str.Substring(start_index, min_len);
        }

    }
}
