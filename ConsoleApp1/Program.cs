using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {





        //Task.Run(() =>
        //{
        //    while (true)
        //    {
        //        var time = DateTime.Now;

        //        if (time.Hour == 7)
        //            while (queue.TryDequeue(out _)) { }
        //        else
        //        {
        //            var span = time.Hour > 7
        //                ? time.AddDays(1).Date.AddHours(7) - time
        //                : time.Date.AddHours(7) - time;
        //            Thread.Sleep(span.Milliseconds);

        //        }
        //    }
        //});




        Console.WriteLine("Hello World!");
    }
}




public class Test
{

    public static string GetString(string key) => $"data:{key}";


}