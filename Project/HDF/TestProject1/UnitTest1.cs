using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {






            Assert.True(true);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test2(int i)
        {
            Assert.True(i > 0);
        }


        public static IEnumerable<object[]> Parameter => new List<Object[]>()
        {
            new object[]{ 1,2,3,4},
            new object[]{ 5,6,7,8},
        };

        //[ClassData(typeof(ParameterClass), Skip = "{\"MyProperty\":1}")]
        [Theory]
        [MemberData(nameof(Parameter))]
        public void Test3(int i1, int i2, int i3, int i4)
        {
            Console.WriteLine(i1);
            Console.WriteLine(i2);
            Console.WriteLine(i3);
            Console.WriteLine(i4);
            Debug.WriteLine(i1);
            Debug.WriteLine(i2);
            Debug.WriteLine(i3);
            Debug.WriteLine(i4);
        }

        [Theory]
        [ClassData(typeof(ParameterClass))]
        public void Test4(int i1, int i2, int i3)
        {
            Console.WriteLine(i1);
            Console.WriteLine(i2);
            Console.WriteLine(i3);
            Debug.WriteLine(i1);
            Debug.WriteLine(i2);
            Debug.WriteLine(i3);

        }


        public class ParameterClass : IEnumerable<object[]>
        {
            public int MyProperty { get; set; }

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 1, 2, 3 };
                yield return new object[] { -4, -6, -10 };
                yield return new object[] { -2, 2, 0 };
                yield return new object[] { int.MinValue, -1, int.MaxValue };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }



}

