using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HDF.Async
{


    class Program
    {


        public enum Color { Red, Yellow, Black, Blue, }

        public class HDF
        {
            public int Age { get; set; }
            public void Deconstruct(out int age) => age = Age;
        }

        static async Task Main(string[] args)
        {


            string[] array = new string[] { "1111", "2222", "3333", "4444", "5555" };


            #region C# 8.0 Index Range

            Console.WriteLine("******************************************************");
            foreach (var item in array[0..])
                Console.WriteLine(item);

            Console.WriteLine("******************************************************");
            foreach (var item in array[1..])
                Console.WriteLine(item);

            Console.WriteLine("******************************************************");
            foreach (var item in array[2..])
                Console.WriteLine(item);

            Console.WriteLine("******************************************************");
            foreach (var item in array[0..1])
                Console.WriteLine(item);

            Console.WriteLine("******************************************************");
            foreach (var item in array[0..^1])
                Console.WriteLine(item);

            Console.WriteLine("******************************************************");
            foreach (var item in array[0..^0])
                Console.WriteLine(item);

            Console.WriteLine("******************************************************");
            foreach (var item in array[1..^1])
                Console.WriteLine(item);

            Console.WriteLine("******************************************************");
            foreach (var item in array[1..4])
                Console.WriteLine(item);

            #endregion

            #region C# 8.0 Async

            //old
            foreach (var temp in Foo2())
                Console.WriteLine(temp);

            IEnumerable<string> Foo2()
            {
                foreach (var temp in new[] { "1 lindexi", "2 doubi", "3 csdn" })
                {
                    yield return temp;
                }
            }

            //new
            await foreach (var temp in Foo())
                Console.WriteLine(temp);

            async IAsyncEnumerable<string> Foo()
            {
                foreach (var temp in new[] { "1 lindexi", "2 doubi", "3 csdn" })
                {
                    await Task.Delay(100);
                    yield return temp;
                }
            }




            #endregion

            #region C# 8.0 switch

            //1
            Color c = Color.Red;
            var a = c switch
            {
                Color.Red => "红",
                Color.Yellow => throw new NotImplementedException(),
                Color.Black => throw new NotImplementedException(),
                Color.Blue => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
            //2 3
            HDF h = new HDF();
            var b = h switch
            {
                { Age: 1 } => "",
                { Age: 2 } => "",
                var (age) when age > 0 => "",
                var (_) => "",
                _ => throw new NotImplementedException()
            };




            #endregion



        }


    }
    public static class EmumrableExtend
    {
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> source) => source == default || source.Count() <= 0;




    }






}
