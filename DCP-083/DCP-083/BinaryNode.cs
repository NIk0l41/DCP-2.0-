using System;

namespace DCP_083 {

    class BinaryTree {

        public BinaryTree left;
        public BinaryTree right;

        public char data;

        public BinaryTree(char data, BinaryTree left = null, BinaryTree right = null) {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Counts how many total connections are in a given binary tree.
        /// </summary>
        /// <returns>[0] length of left branch, [1] length of right branch.</returns>
        public int[] BranchLength() {
            int leftLength = ReturnBranchLength(left);
            int rightLength = ReturnBranchLength(right);
            int[] output = { leftLength, rightLength };
            return output;
        }

        int ReturnBranchLength(BinaryTree branch) {
            int length = 0;
            if (branch != null) {
                length++;
                int[] branches = branch.BranchLength();
                length += branches[0] + branches[1];
            }
            return length;
        }

        public void PrintTree() {
            
        }
    }

}