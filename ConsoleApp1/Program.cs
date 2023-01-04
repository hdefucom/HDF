using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            test();

            //GC.Collect();

            var input = Console.ReadLine();
        }



        static void test()
        {

            var list = new List<int>(100_0000);

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

        }
    }
}