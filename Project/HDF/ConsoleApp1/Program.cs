using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {




        static void Main(string[] args)
        {
            {
                int v = 5;

                var x = v switch
                {
                    1 => 5,
                    2 => 6,
                    3 => 7,
                    4 => 8,
                    _ => 9
                };
            }

            {

                int Add(int a, int b) => a + b;

                var res = Add(1, 2);

            }

            {

                HDF h = new HDF(1, 2);

                var (x, y) = h;



            }


            Console.WriteLine("Hello World!");
        }
    }



    class HDF
    {
        private int x;
        private int y;

        public HDF(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Deconstruct(out int x, out int y)
        {
            x = this.x;
            y = this.y;
        }
    }














}
