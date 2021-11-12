using System;

namespace DCP_080
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binTree = new BinaryTree(
                'a',
                new BinaryTree(
                    'b',
                    new BinaryTree('d'),
                    new BinaryTree('e',
                        new BinaryTree('f')
                        )
                    ),
                new BinaryTree('c')
            );

            Console.WriteLine(ReturnDeepestNode(binTree).data);
        }

        /// <summary>
        /// If a tree has no branches, then it is the furthest node, and it returns that.
        /// If it has branches, then the function iterates on the branch with more nodes.
        /// </summary>
        /// <param name="tree">Input Binary Tree.</param>
        /// <returns>The node furthest from the initial node.</returns>
        static BinaryTree ReturnDeepestNode(BinaryTree tree) {
            /// 1) If tree has no branches, return tree.
            int lLen = tree.BranchLength()[0];
            int rLen = tree.BranchLength()[1];
            int len = rLen + lLen;
            if (len == 0)
                return tree;
            /// 2) If tree has branches, select the one with more branches
            /// and iterate ReturnDeepestNode(tree)
            tree = (lLen > rLen) ? tree.left : tree.right;
            tree = ReturnDeepestNode(tree);
            return tree;
        }
    }
}
