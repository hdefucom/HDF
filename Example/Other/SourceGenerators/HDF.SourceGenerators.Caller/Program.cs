
namespace HDF.SourceGenerators.Caller;


public class Program
{

    public static void Main()
    {
        string filename = System.Environment.CurrentDirectory;



        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        new SomeClassInMyCode().SomeMethodIHave();

        Console.WriteLine(typeof(HelloWorld).FullName);


        Console.ReadLine();

    }


}






public class SomeClassInMyCode
{
    public void SomeMethodIHave()
    {
        HelloWorld.SayHello();



    }
}

