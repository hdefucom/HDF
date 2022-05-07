using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HDF.BenchmarkDotNet;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}


public class TestFor
{

    List<int> list = Enumerable.Range(0, 10000).ToList();




    [Benchmark]
    public void Foreach()
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    [Benchmark]
    public void For()
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
    }


    [Benchmark]
    public void List()
    {
        list.ForEach(item => Console.WriteLine(item));
    }


    public void Linq()
    {



    }


}

