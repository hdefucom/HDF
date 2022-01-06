using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HDF.Framework.Text;

public class CSharp_JS闭包
{
    public void Test()
    {

        {
            var func = Test1();

            var sb1 = func.Invoke();
            sb1.Append("aaaaaa");

            var sb2 = func.Invoke();//aaaaaa
            var b = sb1 == sb2;//true
        }

        {
            var func = Test2();

            var i1 = func.Invoke();

            i1++;

            var i2 = func.Invoke();//99
            var b = i1 == i2;//false
        }

        {
            var func = Test3();

            var str1 = func.Invoke();

            str1 += "aaaa";

            var str2 = func.Invoke();//str
            var b = str1 == str2;//false
        }

        //C#引用类型可以使用闭包，但是值类型不可以，享元模式的string也不可以
        //因为func返回的是一致的上下文
        //js由于只有全局作用域和将函数作用域，没有类的概念，所以产生了闭包
        //但是C#有类/对象所以闭包对于C#无意义

    }



    private Func<StringBuilder> Test1()
    {
        var sb = new StringBuilder();

        return () => sb;
    }

    private Func<int> Test2()
    {
        var i = 99;

        return () => i;
    }
    private Func<string> Test3()
    {
        var str = "str";

        return () => str;
    }

}