using System;
using System.Threading.Tasks;

namespace HDF.CLI
{

    class test
    {
        ~test()
        {
            Console.WriteLine("sssssssss");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {










            var t = new test();


            t = null;

            GC.Collect();

            if (args.Length == 0)
            {
                Console.WriteLine("没有传递参数");

                var str = @" _    _ _____  ______ 
| |  | |  __ \|  ____|
| |__| | |  | | |__   
|  __  | |  | |  __|  
| |  | | |__| | |     
|_|  |_|_____/|_|                      
                                ";
                Console.WriteLine(str);

                return;
            }



            Console.WriteLine(string.Join(" ", args)); ;


        }






    }
}
