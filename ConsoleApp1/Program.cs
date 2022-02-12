using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {



        Stopwatch stopwatch = Stopwatch.StartNew();

        int j = 0;
        for (int i = 0; i < 1_0000_0000; i++)
        {
            j += i;
        }

        stopwatch.Stop();

        Console.WriteLine($"Output took {stopwatch.ElapsedMilliseconds} ms.");










        Console.WriteLine("Hello World!");
    }
}




public class Test
{

    public static string GetString(string key) => $"data:{key}";


}