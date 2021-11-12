using System;

namespace DCP_078
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 3;
            int[] randItemBounds = { 1, 10};
            int[] randItemDataBounds = { 1, 100 };
            LinkedList[] rawLists = ReturnKLinkedListArray(k, randItemBounds, randItemDataBounds);
            LinkedList mergedList = rawLists[0];
            for (int mergeNo = 1; mergeNo < k; mergeNo++) {
                mergedList = ReturnMergedSingleSortedLLists(mergedList, rawLists[mergeNo]);
            }
            mergedList.PrintList();
            //LinkedList mergedList = ReturnMergedSingleSortedLLists(llist, llist2);
            //mergedList.PrintList();
        }

        /// <summary>
        /// A very scuffed way of Merging and Sorting lists.
        /// (But hey, it works!)
        /// </summary>
        /// <param name="llist1">First Linked List Input.</param>
        /// <param name="llist2">Second Linked List Input.</param>
        /// <returns>A Merged and Sorted Linked List.</returns>
        static LinkedList ReturnMergedSingleSortedLLists(LinkedList llist1, LinkedList llist2) {
            /// 1) Add List2 to List1
            int len = llist1.Length();
            Node tmp = llist1.head;
            //This takes us to the last item.
            for (int nodeNumber = 1; nodeNumber < len; nodeNumber++){
                tmp = tmp.next;
            }
            tmp.next = llist2.head;
            //Need to redeclare Len, otherwise it's an incomplete List.
            len = llist1.Length();

            /// 2) Convert tmp to array
            int[] arrTmp = new int[len];
            //Creating an array from the linked list -->
            tmp = llist1.head;
            for (int nodeItem = 0; nodeItem < len; nodeItem++) {
                arrTmp[nodeItem] = tmp.data;
                tmp = tmp.next;
            }

            /// 3) Sort Array Elements
            //Array.Sort(arrTmp);
            //PrintArray(arrTmp);
            /// 4) Convert Array to Linked List
            tmp = llist1.head;
            for (int nodeItem = 0; nodeItem < len; nodeItem++){
                tmp.data = arrTmp[nodeItem];
                tmp = tmp.next;
            }
            return llist1;
        }

        /// <summary>
        /// Prints the contents of an array.
        /// </summary>
        /// <param name="array">Array Input.</param>
        static void PrintArray(int[] array) {
            int len = array.Length;
            Console.WriteLine("ArrayPrinting");
            for (int arrItem = 0; arrItem < len; arrItem++) {
                Console.Write(array[arrItem]);
                if (arrItem != len - 1) {
                    Console.Write(", ");
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Creates an array with k number of lists. Random list number, random list data.
        /// </summary>
        /// <param name="k">Number of lists.</param>
        /// <param name="randItemBounds">A 2 item array with positive bounds to generate how many items a list can have.</param>
        /// <param name="randItemDataBounds">A 2 item array with positive bounds to generate possible data entries for nodes.</param>
        /// <returns></returns>
        static LinkedList[] ReturnKLinkedListArray(int k, int[] randItemBounds, int[] randItemDataBounds) {
            /// 1) Create an array with k length
            LinkedList[] outputList = new LinkedList[k];
            /// 2) Iterate List Creation
            for (int listNo = 0; listNo < k; listNo++) {
                /// 3) -List Creation-, random number of items, with random non-zero data.
                LinkedList list = new LinkedList();
                Random rnd = new Random();
                //Random number of items per list, but within bounds.
                int numItems = rnd.Next(randItemBounds[0], randItemBounds[1]);
                list.head = new Node(rnd.Next(randItemDataBounds[0], randItemDataBounds[1]));
                for (int itemNo = 0; itemNo < numItems; itemNo++) {
                    //Random data for each node.
                    int itemData = rnd.Next(randItemDataBounds[0], randItemDataBounds[1]);
                    //New Node Creation
                    list.AddNode(itemData);
                }
                //Print List...Debugging
                //list.PrintList();
                //Add list to Array.
                outputList[listNo] = list;
            }
            /// 4) Return outputList
            return outputList;
        }
    }
}
