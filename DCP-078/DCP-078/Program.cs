using System;

namespace DCP_078
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList llist = new LinkedList();

            llist.head = new Node(1);

            llist.AddNode(2);
            llist.AddNode(3);
            llist.AddNode(4);
            //Cool, we have a linked list.
            Console.WriteLine(llist.Length());
            //Now, given k sorted singly linked lists,
            //Merge them into one sorted singly linked list.
        }

        static LinkedList ReturnMergedSingleSortedLLists(LinkedList llist1, LinkedList llist2) {
            return new LinkedList();
        }

    }
}
