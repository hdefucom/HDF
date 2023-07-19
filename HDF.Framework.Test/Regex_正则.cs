using System.Text.RegularExpressions;

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
            Regex.Replace("", @"\{(\w+)\}", "{0:$1}");



            //Regex.IsMatch("", @"\p{Cs}");//正则判断是否存在emoji




            //是否是西文字符（英文数字半角符号）
            char c = '1';
            var iswestchar = c >= 0x21 && c <= 0x7E;//由于限制没有使用字符类型，所以不判断数字字符符号，只要是西文统一返回true




            //正则替换
            var str = "http://dev.gocent.com.cn:7001/his";
            str = "http://192.168.0.40:9090/his";
            var reg = new Regex(@"http://(\S+)/his");
            if (reg.IsMatch(str))
            {
                var str2 = reg.Replace(str, "ws://$1/his/websocket");
            }






            //Regex ControlCharRegex = new Regex(@"[\p{C}]", RegexOptions.Compiled);

            {
                Regex reg1 = new Regex(@"\p{C}", RegexOptions.Compiled);
                var str1 = "ertet😂";
                var res1 = reg1.IsMatch(str1);
            }

            {
                Regex reg1 = new Regex(@"\p{C}", RegexOptions.Compiled);
                var str1 = "sdfasfd";
                var res1 = reg1.IsMatch(str1);
            }

            {
                Regex reg1 = new Regex(@"\p{M}", RegexOptions.Compiled);
                var str1 = "བོད་ཡིག";
                var res1 = reg1.IsMatch(str1);
            }

            {
                Regex reg1 = new Regex(@"\p{S}", RegexOptions.Compiled);
                var str1 = "བོད་ཡིག";
                var res1 = reg1.IsMatch(str1);
            }

            {
                Regex reg1 = new Regex(@"\p{L}", RegexOptions.Compiled);
                var str1 = "བོད་ཡིག";
                var res1 = reg1.IsMatch(str1);
            }

            {
                Regex reg1 = new Regex(@"\p{C}", RegexOptions.Compiled);
                var str1 = "བོད་ཡིག";
                var res1 = reg1.IsMatch(str1);
            }

            {
                Regex reg1 = new Regex(@"\p{L}", RegexOptions.Compiled);
                var str1 = "ŝ";
                var res1 = reg1.IsMatch(str1);
            }

            {
                Regex reg1 = new Regex(@"\p{L}", RegexOptions.Compiled);
                var str1 = "ʨʧ";
                var res1 = reg1.IsMatch(str1);
            }


        }
    }
}
