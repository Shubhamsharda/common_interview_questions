﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Trees
    {
        /*Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).*/
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();
            IList<IList<int>> lst2 = new List<IList<int>>();

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            bool reverse = false;
            while (q.Count > 0)
            {
                var lst = new List<int>();
                var lst3 = new List<TreeNode>();
                while (q.Count > 0)
                {
                    var node = q.Dequeue();
                    lst3.Add(node);

                }

                if (reverse)
                {
                    for (int i = lst3.Count - 1; i >= 0; i--)
                    {
                        lst.Add(lst3[i].val);
                    }
                }
                else
                {
                    foreach (var node in lst3)
                    {
                        lst.Add(node.val);
                    }
                }
                lst2.Add(lst);

                foreach (var node in lst3)
                {
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }


                reverse = !reverse;
            }

            return lst2;

        }

        //int preOrderInd = 0;
        //MAke tree from inorder and preorder
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            int[] preOrderInd = new int[] { 0 };
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                dict[inorder[i]] = i;
            }

            return arrayToTree(inorder, 0, inorder.Length - 1, preOrderInd, preorder, dict);
        }
        public TreeNode arrayToTree(int[] inorder, int start, int end, int[] preOrderInd, int[] preorder, Dictionary<int, int> dict)
        {
            if (preOrderInd[0] > inorder.Length - 1)
            {
                return null;
            }
            if (start > end)
            {
                return null;
            }

            TreeNode root = new TreeNode(preorder[preOrderInd[0]]);
            int index = dict[preorder[preOrderInd[0]]];
            ++preOrderInd[0];
            root.left = arrayToTree(inorder, start, index - 1, preOrderInd, preorder, dict);
            root.right = arrayToTree(inorder, index + 1, end, preOrderInd, preorder, dict);

            return root;

        }

        //Kth Smallest Element in a BST
        public int kthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (--k == 0) return root.val;
                root = root.right;
            }
        }

        public int NumIslands(char[][] grid)
        {
            int ct = 0;
            bool[,] visited = new bool[grid.Length,grid[0].Length];
            for (int row = 0; row <= grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == 1 && !visited[row,col])
                    {
                        DFS(grid, row, col, visited);
                    }
                }
            }
            return ct;
        }


        public void DFS(char[][] grid, int row, int col, bool[,] visited)
        {

            visited[row,col] = true;
            if (isValid(grid, row - 1, col, visited)) DFS(grid, row - 1, col, visited);
            if (isValid(grid, row + 1, col, visited)) DFS(grid, row + 1, col, visited);
            if (isValid(grid, row, col - 1, visited)) DFS(grid, row, col - 1, visited);
            if (isValid(grid, row, col + 1, visited)) DFS(grid, row, col + 1, visited);
        }



        public bool isValid(char[][] grid, int row, int col, bool[,]visited)
        {
            int maxrow = grid.Length;
            int maxCol = grid[0].Length;
            if (row > maxrow - 1 || col > maxCol - 1 || row < 0 || col < 0 || grid[row][col] != 1 || visited[row,col]) return false;
            return true;
        }

    }
}