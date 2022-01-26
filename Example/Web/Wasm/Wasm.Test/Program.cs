// See https://aka.ms/new-console-template for more information



using Microsoft.JSInterop;

namespace Wasm.Test;

public class Program
{

    static void Main()
    {

        Console.WriteLine("Hello");






    }

}



public class Test
{


    public static int Sum(int i, int j)
    {
        return i + j;
    }




    private void TestMethod()
    {

        var obj = DotNetObjectReference.Create(new { Name = "HDF" });
    }

}