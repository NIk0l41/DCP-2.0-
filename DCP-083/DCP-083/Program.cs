using System;

namespace DCP_083
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree nodeF = new BinaryTree('f');
            BinaryTree nodeD = new BinaryTree('d');
            BinaryTree nodeE = new BinaryTree('e');
            BinaryTree nodeB = new BinaryTree('b', nodeD, nodeE);
            BinaryTree nodeC = new BinaryTree('c', nodeF);
            BinaryTree tree = new BinaryTree('a', nodeB, nodeC);

            tree = ReturnFlippedTree(tree);

            Console.ReadLine();

        }

        static BinaryTree ReturnFlippedTree(BinaryTree head) {
            //Check for null branches.
            if (head == null || (head.left == null && head.right == null)) {
                return head;
            }
            BinaryTree tmp = new BinaryTree('z');
            //Swap  branches.
            tmp = head.right;
            head.right = head.left;
            head.left = tmp;
            //Flip their branches.
            head.right = ReturnFlippedTree(head.right);
            head.left = ReturnFlippedTree(head.left);
            return head;
        }
    }
}
