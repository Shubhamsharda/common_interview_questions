using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{

    //* Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    //l1 = [2,4,3], l2 = [5,6,4]
    //Output: [7,0,8]

    class LinkedLists
    {
        public void Client()
        {
            ListNode head1 = new ListNode(1);
            head1.next = new ListNode(2);
            //head1.next.next = new ListNode(3);
            //head1.next.next.next = new ListNode(4);
            //head1.next.next.next.next = new ListNode(5);
            //head1.next.next.next.next.next = new ListNode(6);

            ListNode head2 = new ListNode(9);
            head2.next = new ListNode(9);
            head2.next.next = new ListNode(9);

            //var result = AddTwoNumbers(head1, head2);
            //Traverse(result);
            var res = RemoveNthFromEnd(head1,2);
            Traverse(res);

        }

        public void Traverse(ListNode head)
        {
            var curr = head;
            while (curr != null)
            {
                Console.WriteLine(curr.val);
                curr = curr.next;
            }
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //ListNode head = new ListNode();
            ListNode curr = null;
            ListNode head = curr;
            int next = 0;
            while (l1 != null || l2 != null)
            {
                int sum = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + next;
                l1 = (l1 != null ? l1.next : null);
                l2 = (l2 != null ? l2.next : null);

                next = sum / 10;
                int second = sum % 10;
                if (curr == null)
                {
                    curr = new ListNode(second);
                    head = curr;
                }
                else
                {
                    curr.val = second;
                }
                if (l1 != null || l2 != null)
                {
                    curr.next = new ListNode();
                    curr = curr.next;
                }


            }
            if (next != 0)
            {
                curr.next = new ListNode(next);
            }
            return head;
        }

        /*Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, 
         * and return the reordered list.
Note that the relative order inside both the even and odd groups should remain as it was in the input.
You must solve the problem in O(1) extra space complexity and O(n) time complexity.
         * 
         * [1,2,3,4,5]
         [1-->3-->5-->2-->4]
         */

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            var odd = head;
            var even = head.next;
            var evenhead = head.next;
            var curr = head;
            while (odd.next != null || even.next != null)
            {
                if (odd.next != null && odd.next.next != null)
                {
                    odd.next = odd.next.next;
                    odd = odd.next;
                }
                else
                {
                    odd.next = null;
                }

                if (even.next != null && even.next.next != null)
                {
                    even.next = even.next.next;
                    even = even.next;
                }
                else
                {
                    even.next = null;
                }
            }
            odd.next = evenhead;
            return head;
        }
        public ListNode oddEvenList2(ListNode head)
        {
            if (head == null) return null;
            ListNode odd = head, even = head.next, evenHead = even;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
        //Intersection of Two Linked Lists

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var a = headA;
            var b = headB;

            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }
            return a;
        }

        /*Remove Nth Node From End of List
         Given the head of a linked list, remove the nth node from the end of the list and return its head.
         Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]
Example 2:

Input: head = [1], n = 1
Output: []
Example 3:

Input: head = [1,2], n = 1
Output: [1]*/
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            if (head.next == null && n == 1)
            {
                head = head.next;
                return head;
            }
            var start = new ListNode(0);
            var fast = start;
            var slow = start;
            start.next = head;

            for (int i = 1; i <= n; i++) //move fast to nth node first
            {
                fast = fast.next;
            }

            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;

            }

            slow.next = slow.next.next;

            return slow.next;


        }
        /*
         Swap Nodes in Pairs
         Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)

         Example 1:
         Input: head = [1,2,3,4]
         Output: [2,1,4,3]
         */
        public ListNode SwapPairsRecursive(ListNode head)
        { 
            if (head == null || head.next==null)
            {
                return head;
            }
            else
            {
                ListNode first = head;
                ListNode second = head.next;

                if (second != null)
                {
                    ListNode temp = second.next;
                    second.next = first;
                    first.next = SwapPairsRecursive(temp);
                }
                return second;
            }
        }

        public ListNode SwapPairsIterative(ListNode head)
        {
            // If linked list is empty or there
            // is only one node in list
            if (head == null || head.next == null)
            {
                return head;
            }
                   
            // Initialize previous and current pointers
            ListNode prev = head;
            ListNode curr = head.next;

            // Change head before proceeeding
            head = curr;

            // Traverse the list
            while (true)
            {
                ListNode next = curr.next;

                // Change next of current as previous node
                curr.next = prev;

                // If next NULL or next is the last node
                if (next == null || next.next == null)
                {
                    prev.next = next;
                    break;
                }

                // Change next of previous to next of next
                prev.next = next.next;

                // Update previous and curr
                prev = next;
                curr = prev.next;
            }
            return head;
        }
    }
}
