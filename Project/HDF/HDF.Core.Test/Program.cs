using System;
using HDF.Core.IOC;

namespace HDF.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class Test1
    {
        [Injection]
        public Test1(string s) { }
        public Test1(int i) { }
        public Test1() { }

        public void TestMethod1() { 
        
        }

    }
}
