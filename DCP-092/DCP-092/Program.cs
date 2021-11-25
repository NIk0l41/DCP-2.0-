using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DCP_092
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> keyValuePairs = new Dictionary<string, string[]>();
            keyValuePairs.Add("CSC300", new string[] { "CSC100", "CSC200"});
            keyValuePairs.Add("CSC200", new string[] { "CSC100"});
            keyValuePairs.Add("CSC100", new string[] { });
            
            
            string[] courseOrder = CourseOrder(keyValuePairs);
            PrintOrder(courseOrder);

        }

        static void PrintOrder(string[] order) {
            if (order == null) {
                Console.WriteLine("Invalid Courses. Please try again with a different table.");
                return;
            }
            for (int i = 0; i < order.Length; i++) {
                Console.Write(order[i]);
                if (i != order.Length - 1) {
                    Console.Write(", ");
                }
            }
            Console.ReadLine();
        }

        static string[] CourseOrder(Dictionary<string, string[]> hashTable) {
            List<string> courseOrder = new List<string>();
            (List<string> order, Dictionary<string, string[]> table) courses = CourseOrdering(courseOrder, hashTable);
            if (courses.table == null && courses.order == null) {
                return null;
            }
            return courses.order.ToArray();
        }

        static (List<string>, Dictionary<string, string[]>) CourseOrdering(List<string> currentOrder, Dictionary<string, string[]> hashTable) {
            bool orderingOccurred = false;
            foreach (KeyValuePair<string, string[]> entry in hashTable) {
                // Foreach remaining course
                /// Are there prereq courses?
                if (entry.Value.Length == 0) {
                    /// --> If not, add to currentOrder and remove from hashTable. orderingOccurred
                    currentOrder.Add(entry.Key);
                    hashTable.Remove(entry.Key);
                    orderingOccurred = true;
                }
                else {
                    /// --> If so, check to see whether the listed courses are in the currentOrder
                    int prereqsMet = 0;
                    for (int i = 0; i < entry.Value.Length; i++) {
                        if (CourseExists(currentOrder, entry.Value[i])) {
                            prereqsMet++;
                        }
                    }
                    // If all prereq courses are in the current order.
                    ///     --> If not, continue
                    ///     --> If so, add to currentOrder and remove from hashTable. orderOccurred.
                    if (prereqsMet == entry.Value.Length) {
                        currentOrder.Add(entry.Key);
                        hashTable.Remove(entry.Key);
                        orderingOccurred = true;
                    }
                }
            }
            (List<string> order, Dictionary<string, string[]> table) output = (currentOrder, hashTable);
            /// Ordering Occurred?
            if (orderingOccurred) {
                /// --> If so, iterate on itself.
                output = CourseOrdering(output.order, output.table);
                return output;
            }
            else {
                /// --> If not, check if hashtable it empty.
                if (output.table.Count == 0) {
                    ///     --> If so, the ordering is complete!
                    return output;
                }
                else {
                    ///     --> If not, the ordering cannot be done. Return null.}
                    return (null, null);
                }

            }
        }

        static bool CourseExists(List<string> courseCollection, string courseToFind) {
            bool exists = courseCollection.Any(a => a.SequenceEqual(courseToFind));
            return exists;
        }
    }
}
