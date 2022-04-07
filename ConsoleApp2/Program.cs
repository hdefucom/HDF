using ConsoleApp2.Db;
using System;
using System.Linq;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        var context = new GYYTContext();


        var list = context.SYS_USERs.ToList();


        Console.WriteLine("Hello World!");
    }



}

