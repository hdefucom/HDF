using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HDF.Framework.Text
{
    internal class Regex_正则
    {

        public static void Method1()
        {

            //检验数值类型，允许一位整数和四位小数

            Regex.IsMatch("1.45", @"^\d{1}(\.\d{1,4})?$");
            new Regex("^-?\\d+$|^(-?\\d+)(\\.\\d+)?$").IsMatch("1.4434");



            //正则参数用法，  匹配字符用 () 包裹，替换字符内使用 $n 获取前面匹配的参数，n从1开始。

            //  123{name}456{age} --> 123{0:name}456{0:age}  用于对象属性格式化字符串
            var res1 = Regex.Replace("", @"\{(\w+)\}", "{0:$1}");



        }
    }
}
