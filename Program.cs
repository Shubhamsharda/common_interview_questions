
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {


        static void Main(string[] args)
        {
            //Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
            //Console.WriteLine(StrStr("mississippi", "issip"));
            //var rotatedArr = RotateArray3(new int[2] { 1, 2}, 3);
            //foreach (var i in rotatedArr)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(isUnique("abcdef"));
            //char[] arr = new char[50];
            //arr[0]='a';
            //arr[1]=' ';
            //arr[2]='b';
            //arr[3]=' ';
            //arr[4]=' ';
            //arr[5] = 'c';
            //replaceSpaces(arr, 6);
            //string[] arr = { "aab", "bac", "a", "dddddddddd", "abcgddgcba" };
            //foreach(var str in arr)
            //{
            //    Console.WriteLine(PalindromePermutation(str));
            //}
            //Console.WriteLine( oneEditAway("abc","a") );
            //Console.WriteLine(isRotation("tlewaterbot", "waterbottle"));
            //Console.WriteLine(findWays(3));
            //bool[,] matrix =
            //{
            //    {false,false,false },
            //    {true,false,false },
            //    {false,false,false },
            //};
            //List<Point> points = new List<Point>();
            //List<Point> failedPoints = new List<Point>();
            //FindPath(matrix, 2, 2, points, failedPoints);
            //foreach(var point in points)
            //{
            //    Console.WriteLine(point.R+","+point.C);
            //}
            //int[] arr = { -20, -10, 2, 10, 11 };
            //Console.WriteLine(magicindex(arr));
            //Console.WriteLine(minProduct(4,5));
            //jobSequencing();
            //meetings();
            //Console.WriteLine(makeChange(5) ); 
            //var lst = printParams(3);
            //var lst = generateParens(3);
            //foreach(var item in lst)
            //{
            //    Console.WriteLine(item);
            //}
            //int[] a = new int[6];
            //int[] b = new int[3];
            //a[0] = 1;
            //a[1] = 3;
            //a[2] = 5;
            //b[0] = 2;
            //b[1] = 4;
            //b[2] = 5;

            //SearchingAndSorting.SortedMerge(a,b,2);
            //string[] arr = { "abc", "xyz", "bac", "zyx", "bca" };
            //var arr2=SearchingAndSorting.groupAnagram(arr);
            //foreach(var a  in arr2)
            //{
            //    Console.WriteLine(a);
            //}

            //SearchingAndSorting.search(new int[] { 1, 2, 3, 4, 5, 6, -1, -2, -1 -1, -1, -1, -1 },1);
            //SearchingAndSorting.sparseSearch();
            //SearchingAndSorting.PeakAndValley();
            //SearchingAndSorting.findSmallestDiff();
            //SearchingAndSorting.numberInWords();
            //SearchingAndSorting.SortColors(new int[] { 2, 0, 2, 1, 1, 0 });
            //SearchingAndSorting.SortColors(new int[] { 2,0,1 });
            //Console.WriteLine(SearchingAndSorting.FindPeakElement(new int[] { 1, 2, 1, 3, 5, 6, 4 }));

            //maxProfit();
            //Leetcode_Medium.LengthOfLongestSubstring("abcabcbb");
            //Leetcode_Medium.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            //Leetcode_Medium.ThreeSum(new int[] { 0,0,0,0});
            //int res = Leetcode_Medium.RotatedBinarySearch(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
            //Console.WriteLine(res);
            //Console.WriteLine(Leetcode_Medium.LongestPalindrome("aacabdkacaa"));
            //Console.WriteLine(Leetcode_Medium.FindDuplicate(new int[] { 1, 3, 4, 2, 2 }));
            //int[] res = Leetcode_Medium.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 },8);

            //foreach(var i in res)
            //{
            //    Console.WriteLine(i);
            //}
            //var res = Leetcode_Medium.MergeIntervals(new int[][] { new int[] { 1, 4 }, new int[] { 0, 4 } });
            //foreach (var arr in res)
            //{
            //    Console.WriteLine("=============");
            //    foreach (var i in arr)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
            //Console.WriteLine(Leetcode_Medium.FindMaxLength(new int[] { 0, 1, 0 }));
            //Console.WriteLine(Leetcode_Medium.RepeatedSubstringPattern("abab"));
            //Console.WriteLine(Leetcode_Medium.subarraySum(new int[] { 1,1,1},2));
            //var res = Leetcode_Medium.SortedSquares(new int[] { -5, -3, -2, -1 });
            //foreach(var i in res)
            //{
            //    Console.WriteLine(i);
            //}
            //var res = Leetcode_Medium.ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            //foreach(var i in res)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine(stockMaxProfit(new int[] { 3, 2, 5, 8, 1, 9 }));
            //Console.WriteLine(stockMaxProfit2(new int[] { 3, 2, 5, 8, 1, 9 }));

            //var nums = new int[] { 2, 4, 5, 1 };
            //var res = Leetcode_Medium.canJump(nums);
            //var res = Leetcode_Medium.permute(new int[] { 1, 2, 3 });
            //var res = Leetcode_Medium.PermuteUnique(new int[] { 1, 1, 2 });
            //var res = Leetcode_Medium.Partition("aab");
            //foreach (var lst in res)
            //{
            //    Console.WriteLine("-----------");
            //    foreach(var ele in lst)
            //    {
            //        Console.WriteLine(ele);
            //    }
            //    Console.WriteLine("-----------");

            //}
            //Console.WriteLine(res);

            #region Dynamic Programming
            //Console.WriteLine(Dynamic_Programming.CoinChange(new int[] { 1, 2, 5 }, 11));

            #endregion

            #region LinkedLists
            //LinkedLists lnkdlst = new LinkedLists();
            //lnkdlst.Client();
            #endregion

            #region Trees
            Trees tree = new Trees();
            //tree.BuildTree(new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });

            //------------------------
            var root = new TreeNode(1);
            root.left = new TreeNode(3);
            root.left.left = new TreeNode(5);
            //root.left.right = new TreeNode(4);
            root.right = new TreeNode(2);
            //root.right.right = new TreeNode(7);
           //--------------------merge binary tree-------------- 
            
            var root2 = new TreeNode(2);
            root2.left = new TreeNode(1);
            root2.right = new TreeNode(3);
            root2.left.right = new TreeNode(4);
            root2.right.right = new TreeNode(7);

            //var rett = tree.MergeTrees(root,root2);
            //tree.InOrderPrint(rett);


            //--------------------merge binary tree--------------
            //---------------invert binary tree----------------
            var invertedTree = tree.InvertBTree(root);
            tree.InOrderPrint(invertedTree);
           //---------------invert binary tree-----------------





            //Console.WriteLine(tree.kthSmallest(root,5));


            #endregion
            Console.WriteLine("Run again?press any key");
            var response = Console.ReadLine();
            if (response != null)
            {
                Main(null);
            }
        }

         
        public static bool IsPalindrome(string s)
        {
            var arr = s.Where(c => (char.IsLetterOrDigit(c))).ToArray();
            Array.Reverse(arr);
            string s2 = new string(arr);
            if (s.ToUpper() == s2.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int StrStr(string haystack, string needle) // implements str.IndexOf() function of string
        {
            string h = haystack;
            string n = needle;
            if (n == "")
            {
                return 0;
            }
            if (n.Length > h.Length)
            {
                return -1;
            }
            int index = -1;

            int i = 0;
            int j = 0;
            int ct = 0;
            int k = 0;
            while (i < h.Length && j < n.Length && k < h.Length)
            {
                if (h[k] == n[j])
                {
                    if (ct == 0)
                        index = i;
                    k++;
                    j++;
                    ct++;
                }
                else
                {
                    i++;
                    k = i;
                    j = 0;
                    index = -1;
                    ct = 0;
                }
                if (ct == n.Length)
                {
                    return index;
                }
            }
            if (ct == n.Length)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public static int[] RotateArray(int[] arr, int k) //k=rotations Brute Force approcah
        {
            k = k % arr.Length;
            for (int i = 0; i < k; i++)
            {
                int prev = arr[arr.Length - 1];
                int temp;
                for (int j = 0; j < arr.Length; j++)
                {
                    temp = arr[j];
                    arr[j] = prev;
                    prev = temp;
                }
            }
            return arr;
        }

        public static int[] RotateArray2(int[] arr, int k)//Using Extra Array https://leetcode.com/problems/rotate-array/solution/
        {
            var tempArray = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                int ind = (i + k) % arr.Length;
                tempArray[ind] = arr[i];
            }
            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = tempArray[j];
            }
            return arr;
        }
        public static int[] RotateArray3(int[] arr, int k)//Using reverse https://leetcode.com/problems/rotate-array/solution/
        {
            k = k % arr.Length;
            arr = Reverse(arr, 0, arr.Length - 1);
            arr = Reverse(arr, 0, k - 1);
            arr = Reverse(arr, k, arr.Length - 1);
            return arr;
        }
        public static int[] Reverse(int[] arr, int start, int end)
        {
            for (int i = start, j = end; i < j; i++, j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            return arr;
        }
        //Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
        //cannot use additional data structures?
        public static bool isUnique(string str) //using extra space for bool array
        {
            bool[] arr = new bool[256];
            foreach (var ch in str)
            {
                if (arr[ch])
                    return false;
                else
                    arr[ch] = true;
            }
            return true;
        }

        public static bool isUnique2(string s)
        {
            var hset = new HashSet<char>();
            foreach (var ch in s)
            {
                if (hset.Contains(ch))
                    return false;
                hset.Add(ch);
            }
            return true;
        }

        //URIFy --> Cracking the coding interview
        public static void replaceSpaces(char[] str, int trueLength)
        {
            int spaceCount = 0, index, i = 0;
            for (i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            index = trueLength + spaceCount * 2;
            if (trueLength < str.Length) str[trueLength] = '\0';
            for (i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    str[index - 1] = str[i];
                    index--;
                }
            }

            Console.WriteLine(str.ToString());
        }

        //Palindrome Permutation: Given a string, write a function to check if it is a permutation of
        //a palindrome.A palindrome is a word or phrase that is the same forwards and backwards.A
        //permutation is a rearrangement of letters. The palindrome does not need to be limited to just
        //dictionary words. 

        //to be a permutation ot a palindrome, a string
        //can have no more than one character that is odd.This will cover both the odd and the even cases
        public static bool PalindromePermutation(string str)
        {
            bool[] arr = new bool[128]; //if only ascii characters
            foreach (var ch in str)
            {
                arr[ch] = !arr[ch];
            }
            return arr.Count(x => x == true) <= 1;
        }

        //One Away: There are three types of edits that can be performed on strings: insert a character,
        //remove a character, or replace a character.Given two strings, write a function to check if they are
        //one edit (or zero edits) away.
        //EXAMPLE
        //pale, ple -> true
        //pales, pale -> true
        //pale, bale -> true
        //pale, bae -> false
        public static bool oneEditAway(string first, string second)
        {
            if (first.Length == second.Length)
            {
                return isReplace(first, second);
            }
            else if (first.Length + 1 == second.Length)
            {
                return isInsert(first, second);
            }
            else if (first.Length == second.Length + 1)
            {
                return isInsert(second, first);
            }
            return false;
        }
        public static bool isReplace(string f, string s)
        {
            int ct = 0;
            for (int i = 0; i < f.Length; i++)
            {
                if (f[i] != s[i])
                    ct++;
            }
            return ct == 1;
        }
        public static bool isInsert(string f, string s)
        {
            int ct = 0;
            int index1 = 0, index2 = 0;
            //for (int i = 0, j = 0; i < f.Length && j < s.Length; i++, j++)
            while (index1 < f.Length && index2 < s.Length)
            {
                if (f[index1] != s[index2])
                {
                    if (ct != 0)
                    {
                        return false;
                    }
                    ct += 1;
                    index1++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }

        //String Rotation: Assume you have a method i 5Su b 5 tr ing which checks if one word is a substring
        //of another.Given two strings, 51 and 52, write code to check if 52 is a rotation of 51 using only one
        //call to i5Sub5tring(e.g., "waterbottle" is a rotation of"erbottlewat").

        public static bool isRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            if ((s1 + s1).Contains(s2)) return true;
            return false;
        }

        //Triple Step: A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
        //steps at a time.Implement a method to count how many possible ways the child can run up the
        //stairs.

        public static int findWays(int n)
        {
            int[] memo = new int[n];
            Array.Fill(memo, -1);

            return CountWays(n - 1, memo) + CountWays(n - 2, memo) + CountWays(n - 3, memo);
        }
        public static int CountWays(int n, int[] memo)
        {
            if (n < 0)
            {
                return 0;
            }
            if (n == 0)
            {
                return 1;
            }
            if (memo[n] != -1)
                return memo[n];
            return memo[n] = CountWays(n - 1, memo) + CountWays(n - 2, memo) + CountWays(n - 3, memo);
        }

        //Robot in a Grid: Imagine a robot sitting on the upper left corner of grid with r rows and c columns.   
        //The robot can only move in two directions, right and down, but certain cells are "off limits" such that
        //the robot cannot step on them.Design an algorithm to find a path for the robot from the top left to
        //the bottom right. 
        public struct Point
        {
            public int R { get; set; }
            public int C { get; set; }
            public Point(int r, int c)
            {
                R = r;
                C = c;
            }
        }
        public static bool FindPath(bool[,] matrix, int row, int col, List<Point> path, List<Point> failedPoints)
        {

            if (row < 0 || col < 0 || matrix[row, col]) return false;
            if (failedPoints.Contains(new Point(row, col))) return false;
            if ((row == 0 && col == 0) || FindPath(matrix, row - 1, col, path, failedPoints) || FindPath(matrix, row, col - 1, path, failedPoints))
            {
                path.Add(new Point(row, col));
                return true;
            }
            failedPoints.Add(new Point(row, col));
            return false;
        }

        //Magic Index: A magic index in an array A[1.•. n - 1] is defined to be an index such that A[i]        
        //i.Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in
        //array A.
        //FOLLOW UP
        //What if the values are not distinct?

        //solve using binary search
        public static int magicindex(int[] arr)
        {
            return magicindex(arr, 0, arr.Length - 1);
        }
        public static int magicindex(int[] arr, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }
            int mid = (start + end) / 2;
            if (mid == arr[mid])
            {
                return mid;
            }
            else if (arr[mid] > mid)
            {
                return magicindex(arr, mid + 1, end);
            }
            else
            {
                return magicindex(arr, start, mid - 1);
            }
        }
        //Recursive Multiply: Write a recursive function to multiply two positive integers without using     
        //the * operator (or / operator). You can use addition, subtraction, and bit shifting, but you should
        //minimize the number of those operations.
        public static int minProduct(int a, int b)  //O(log smint)
        {
            int bigger = a < b ? b : a;

            int smaller = a < b ? a : b;
            return minProductHelper(smaller, bigger);
        }

        public static int minProductHelper(int smint, int bgint)
        {
            if (smint == 0)
            { // 0 x bigger = 0
                return 0;
            }
            else if (smint == 1)
            { // 1 x bigger =bigger
                return bgint;
            }

            /* Compute half. If uneven, compute other half. If even, double it. */
            int smallerHalf = smint >> 1; // Divide by 2
            int halfArea = minProductHelper(smallerHalf, bgint);
            if (smint % 2 == 0)
            {
                return halfArea * 2;
            }
            else
            {
                return halfArea * 2 + bgint;
            }
        }
        //Given an array of jobs where every job has a deadline and associated profit if the job is finished before the deadline.        
        //It is also given that every job takes a single unit of time, so the minimum possible deadline for any job is 1. 
        //How to maximize total profit if only one job can be scheduled at a time.
        //1) Sort all jobs in decreasing order of profit.
        //2) Iterate on jobs in decreasing order of profit.For each job, do the following :
        //For each job find an empty time slot from deadline to 0. If found empty slot put the job in the slot and mark this slot filled.
        public struct Job
        {
            public int deadline { get; set; }
            public int profit { get; set; }
            public string name { get; set; }
            public Job(string n, int s, int p)
            {
                deadline = s;
                profit = p;
                name = n;
            }
        }
        public class Camp : IComparer<Job>
        {
            public int Compare(Job a, Job b)
            {
                if (a.profit == b.profit) return 0;
                if (a.profit > b.profit) return -1;
                else
                    return 1;
            }
        }
        public static void jobSequencing()
        {
            var jobList = new List<Job>() {
                new Job("a",2,100),
                new Job("b", 1, 19),
                new Job("c", 2, 27),
                new Job("d", 1, 25),
                new Job("e", 3, 15)
            };
            int n = 3;
            Camp cmp = new Camp();

            //jobList.Sort(cmp);
            jobList = jobList.OrderByDescending(x => x.profit).ToList();
            bool[] slotFilled = new bool[n + 1];
            slotFilled[0] = true;
            string[] result = new string[n + 1];

            foreach (var job in jobList)
            {
                for (int i = Math.Min(job.deadline, n); i >= 0; i--)
                {
                    if (!slotFilled[i])
                    {
                        slotFilled[i] = true;
                        result[i] = job.name;
                        break;
                    }
                }
            }

            //print the result
            for (int j = 1; j < n + 1; j++)
            {
                Console.WriteLine(result[j]);
            }
        }

        //There is one meeting room in a firm.There are N meetings in the form of (S[i], F[i]) where S[i] is the start time of meeting i and F[i]
        //is finish time of meeting i.The task is to find the maximum number of meetings that can be accommodated
        //in the meeting room.Print all meeting numbers

        public struct Meeting
        {
            public int start { get; set; }
            public int end { get; set; }
            public string name { get; set; }
            public Meeting(string name, int start, int end)
            {
                this.start = start;
                this.name = name;
                this.end = end;
            }
        }

        public static void meetings()
        {
            var meetingLst = new List<Meeting>()
            {
                new Meeting("a",1,2),
                new Meeting("b",3,4),
                new Meeting("c",0,6),
                new Meeting("d",5,7),
                new Meeting("e",8,9),
                new Meeting("f",5,9),
            };

            meetingLst = meetingLst.OrderBy(x => x.end).ToList();
            int last = Int32.MinValue;
            var result = new List<Meeting>();
            foreach (var m in meetingLst)
            {
                if (m.start > last)
                {
                    result.Add(m);
                    last = m.end;
                }
            }

            foreach (var res in result)
            {
                Console.Write(res.name);
            }
        }

        //Given an infinite number of quarters(25 cents), dimes(1 O cents), nickels(5 cents), and
        //pennies(1 cent), write code to calculate the number of ways of representing n cents.
        public static int makeChange(int amount, int[] denom, int index,int[,] memo)
        {
            if (index >= denom.Length-1) return 1;
            if (memo[amount, index] != 0) return memo[amount, index];
            int ways = 0;
            for (int i = 0; i * denom[index] <= amount; i++)
            {
                int remainingAmount = amount - i * denom[index];
                ways += makeChange(remainingAmount, denom, index + 1,memo);
            }

            return memo[amount, index] = ways;
        }
        public static int makeChange(int amount)
        {
            int[,] memo = new int[amount + 1, 4];
            return makeChange(amount, new int[] { 25, 10, 5, 1 }, 0,memo);
        }

        //Parens: Implement an algorithm to print all valid(i.e., properly opened and closed) combinations
        //of n pairs of parentheses.
        //EXAMPLE
        //Input: 3
        //Output: ((() ) ) , (() () ) , (() ) () , () (() ) , () () ()

        public static HashSet<string> printParams(int n)
        {
            //string res = "()";
            //for(int i = 1; i <= n; i++)
            //{
            //    Console.WriteLine();
            //}
            if (n == 1) return new HashSet<string>() { "()" };
            
            HashSet<string> res = printParams(n - 1);
            var newLst = new HashSet<string>();
            foreach (var str in res)
            {
                newLst.Add("()" + str);
                newLst.Add(str + "()");
                newLst.Add($"({str})");
            }

            return newLst;
        }

        public static void addParen(List<string> list, int leftRem, int rightRem, char[] str,int index)
        {
            if (leftRem < 0 || rightRem < leftRem) return;// invalid state

             if (leftRem == 0 && rightRem == 0)
            {/*Out of left and right parentheses */
                list.Add(str.ToString()); ;
            }
            else
            {
                str[index] = '('; // Add left and recurse
                addParen(list, leftRem - 1, rightRem, str, index + 1);

                str[index] = ')'; // Add right and recurse
                addParen(list, leftRem, rightRem - 1, str, index + 1);
            }
        }
        public static List<string> generateParens(int count)
        {
            char[] str = new char[count * 2];
            List<string> list = new List<string>();
            addParen(list, count, count, str, 0);
            return list;
        }

        //The cost of a stock on each day is given in an array, find the max profit that you can make by buying and selling in
        //those days.For example, if the given array is { 100, 180, 260, 310, 40, 535, 695}, the maximum profit can earned by buying on day 0, selling on day 3. Again buy on day 4 and sell on day 6. If the given array of prices is sorted in decreasing order, then profit cannot be earned at all.
        //Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
        //Naive approach: A simple approach is to try buying the stocks and selling them on every single day when profitable 
        //and keep updating the maximum profit so far.
        // Function to return the maximum profit
        // that can be made after buying and
        // selling the given stocks
        public static int maxProfit(int[] price, int start, int end)
        {

            // If the stocks can't be bought
            if (end <= start)
                return 0;

            // Initialise the profit
            int profit = 0;

            // The day at which the stock
            // must be bought
            for (int i = start; i < end; i++)
            {

                // The day at which the
                // stock must be sold
                for (int j = i + 1; j <= end; j++)
                {

                    // If buying the stock at ith day and
                    // selling it at jth day is profitable
                    if (price[j] > price[i])
                    {

                        // Update the current profit
                        int curr_profit = price[j] - price[i]
                                        + maxProfit(price, start, i - 1)
                                        + maxProfit(price, j + 1, end);

                        // Update the maximum profit so far
                        profit = Math.Max(profit, curr_profit);
                    }
                }
            }
            return profit;
        }
        public static void maxProfit()
        {
            int[] price = { 100, 180, 260, 310,
                    40, 535, 695 };
            int n = price.Length;
            Console.WriteLine(maxProfit(price,0,n-1));
        }

        public static int stockMaxProfit(int[] prices)
        {
            int i = 0, buy = 0, sell = 0;
            int profit = 0;
            int N = prices.Length - 1;
            while ( i< N )
            {
                while( i<N && prices[i + 1] <= prices[i])
                {
                    i++;
                }
                buy = prices[i];
                while(i<N && prices[i] < prices[i + 1]) { i++; }
                sell = prices[i];
                profit += sell - buy;
            }
            return profit;
        }
        public static int stockMaxProfit2(int[] prices)
        {
            int maxprofit = 0;
            for(int i = 0; i < prices.Length-1; i++)
            {
                if(prices[i+1]> prices[i])
                {
                    maxprofit += prices[i + 1] - prices[i];
                }
            }
            return maxprofit;
        }
    }



}
