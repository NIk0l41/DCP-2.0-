using System;

namespace DCP_074
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 13;
            int X = 26;
            Table tab = new Table(N);
            tab.PrintTable();
            string msg = X + " appears in the table " + tab.ReturnCount(X) + " times.";
            Console.WriteLine(msg);
            Console.ReadLine();
        }

    }

}
