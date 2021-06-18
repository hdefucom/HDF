using Microsoft.CodeAnalysis;
using System;

namespace DataStructureAndAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {



            DynamicArray<int> array = new DynamicArray<int>();

            Console.WriteLine(array);













            Console.ReadLine();
        }



    }


    public class DynamicArray<T>
    {
        private T[] data;//数据
        private int n;//数据实际数量


        public DynamicArray() : this(10)
        {

        }
        public DynamicArray(int length)
        {
            data = new T[length];
        }


        public void Add(T val)
        {
            Check();
            data[n] = val;
            n++;
        }

        public void Insert(int index, T val)
        {
            Check();
            for (int i = n; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = val;
            n++;
        }


        public void Remove(int index)
        {


        }







        private void Check()
        {
            if (n == data.Length)
            {
                T[] d2 = new T[(int)Math.Ceiling(data.Length * 1.5)];
                data.CopyTo(d2, 0);
                data = d2;
            }
        }









        public override string ToString() => $"{nameof(DynamicArray<T>)}:[{string.Join(",", data)}]";

    }






}
