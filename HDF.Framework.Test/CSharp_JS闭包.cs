using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HDF.Framework.Text;

public class CSharp_JS闭包
{
    public void Test()
    {
        var func = Test1();


        var sb1 = func.Invoke();
        sb1.Append("aaaaaa");

        var sb2 = func.Invoke();//aaaaaa

        var b = sb1 == sb2;//true
    }



    private Func<StringBuilder> Test1()
    {
        var sb = new StringBuilder();

        return () => sb;
    }

}
