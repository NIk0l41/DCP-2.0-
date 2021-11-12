using System;
using System.Collections.Generic;
using System.Text;

namespace DCP_078
{
    //Using https://www.geeksforgeeks.org/linked-list-set-1-introduction/
    
    public class LinkedList
    {
        public Node head;

        /// <summary>
        /// Counts how many singly linked nodes are in this
        /// Linked List Object.
        /// </summary>
        /// <returns>An Integer Value of Length lmao.</returns>
        public int Length() {
            Node tmp = (head == null) ? null : head;
            int output = 0;
            while (tmp != null) {
                output++;
                tmp = tmp.next;
            }
            return output;
        }

        /// <summary>
        /// Adds a new node with 'data' to the Linked List.
        /// </summary>
        /// <param name="data">Data to be added to the new node.</param>
        public void AddNode(int data) {
            int len = Length();
            Node tmp = head;
            //This takes us to the last item.
            for (int nodeNumber = 1; nodeNumber < len; nodeNumber++){
                tmp = tmp.next;
            }
            tmp.next = new Node(data);
        }

        public void MergeLinkedList(LinkedList list) {
            int len = Length();
            Node tmp = head;
            //This takes us to the last item.
            for (int nodeNumber = 1; nodeNumber < len; nodeNumber++){
                tmp = tmp.next;
            }
            tmp.next = list.head;
        }

        public void PrintList() {
            int len = Length();
            Node tmp = head;
            for (int nodeNo = 0; nodeNo < len; nodeNo++) {
                Console.Write(tmp.data);
                if (nodeNo != len - 1) {
                    Console.Write(", ");
                }
                tmp = tmp.next;
            }
            Console.ReadLine();
        }

        /// <summary>
        /// (WIP) Sorts a single linked list.
        /// </summary>
        /// <param name="chkPoint">Where to start the Sort from.</param>
        public LinkedList SortASC(LinkedList list) {
            int len = Length();
            bool hasSortOccurred = false;
            Node chkPoint = list.head;
            /// 1) Find a single case where B is less than A
            //This issue here is how we're iterating through
            //The LList Object.
            for (int nodeNumber = 0; nodeNumber < len; nodeNumber++){
                if (chkPoint.next.data < chkPoint.data) {
                    /// 2) Change the data from A to B and B to A.
                    ///  Break.
                    int tmpData = chkPoint.next.data;
                    chkPoint.next.data = chkPoint.data;
                    chkPoint.data = tmpData;
                    hasSortOccurred = true;

                    break;
                }
                chkPoint = chkPoint.next;
            }
            /// 3) If a sort has occurred, the function needs to run again.
            /// If not, then it can return a new Linked List.
            if (hasSortOccurred){
            }
            else {
                
            }
            return list;
        }
    }

    public class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
}
