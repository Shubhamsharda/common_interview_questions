using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Leetcode_Easy
    {
        //https://leetcode.com/problems/palindrome-number/solution/
        //find if a number is a palindrome
        public bool IsPalindrome(int x)
        {
            // Special cases:
            // As discussed above, when x < 0, x is not a palindrome.
            // Also if the last digit of the number is 0, in order to be a palindrome,
            // the first digit of the number also needs to be 0.
            // Only 0 satisfy this property.
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            // When the length is an odd number, we can get rid of the middle digit by revertedNumber/10
            // For example when the input is 12321, at the end of the while loop we get x = 12, revertedNumber = 123,
            // since the middle digit doesn't matter in palidrome(it will always equal to itself), we can simply get rid of it.
            return x == revertedNumber || x == revertedNumber / 10;
        }

        /* Valid Parentheses 
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
 

Example 1:

Input: s = "()"
Output: true*/
        public bool IsValid(string s)
        {
            List<string> openingBrackets = new List<string>() { "(", "{", "[" };
            List<string> closingBrackets = new List<string>() { ")", "}", "]" };
            Stack<string> stack = new Stack<string>();
            Dictionary<string, string> pairs = new Dictionary<string, string>() { { "{", "}" }, { "(", ")" }, { "[", "]" } };
            string lastCharAdded = "";
            stack.Push(s[0].ToString());
            int i = 1;
            while(i<s.Length)
            {
                bool popped = false;
                while(i<s.Length && stack.Count>0 && s[i].ToString() == pairs.GetValueOrDefault(stack.Peek()))
                {
                    stack.Pop();
                    popped = true;
                    i++;

                }
                if(i<s.Length) stack.Push(s[i].ToString());
                i++;
                
            }
            if(stack.Count > 0)
            {
                return false;
            }
            return true;
        }
    }




}
