using HDF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HDF.Framework.Text;

internal static class StringFormat_拓展
{


    public static void Test()
    {




        var res1 = "第{PageIndex}页/共{PageCount}页".FormatPageNumber(new { PageIndex = 1, PageCount = 10 });

    }








    public static string FormatPageNumber(this string format, object arg, PageNumberFormat type = PageNumberFormat.Number)
    {
        format = Regex.Replace(format, @"\{(\w+)\}", "{0:$1}");
        return string.Format(new PageNumberFormatProvider(type), format, arg);
    }



    /// <summary>
    /// 数字转中文
    /// </summary>
    /// <param name="number">eg: 22</param>
    /// <returns></returns>
    public static string ToSimpleChinese(this int number)
    {
        string str = number.ToString();
        string schar = str.Substring(0, 1);

        var res = schar switch
        {
            "1" => "一",
            "2" => "二",
            "3" => "三",
            "4" => "四",
            "5" => "五",
            "6" => "六",
            "7" => "七",
            "8" => "八",
            "9" => "九",
            _ => "零",
        };

        if (str.Length <= 1)
            return res;

        res += str.Length switch
        {
            2 or 6 => "十",
            3 or 3 => "百",
            4 => "千",
            5 => "万",
            _ => ""
        };

        res += ToSimpleChinese(str.Remove(0, 1).To<int>());

        return res;
    }

    /// <summary>
    /// 数字转中文
    /// </summary>
    /// <param name="number">eg: 22</param>
    /// <returns></returns>
    public static string ToTraditionChinese(this int number)
    {
        string str = number.ToString();
        string schar = str.Substring(0, 1);

        var res = schar switch
        {
            "1" => "壹",
            "2" => "贰",
            "3" => "叁",
            "4" => "肆",
            "5" => "伍",
            "6" => "陆",
            "7" => "柒",
            "8" => "捌",
            "9" => "玖",
            _ => "零",
        };

        if (str.Length <= 1)
            return res;

        res += str.Length switch
        {
            2 or 6 => "拾",
            3 or 3 => "佰",
            4 => "仟",
            5 => "萬",
            _ => ""
        };

        res += ToTraditionChinese(str.Remove(0, 1).To<int>());

        return res;
    }


    //   48-57  0-9
    //   65-90  A-Z
    //   97-122 a-z

    /// <summary>
    /// 数字转小写英文
    /// </summary>
    /// <param name="number">eg: 22</param>
    /// <returns></returns>
    public static string ToLowerEnglish(this int number)
    {
        if (number == 0)
            return "null";

        var c = (number - 1) % 26 + 97;
        var n = (number - 1) / 26 + 1;

        return new string(n.For(i => (char)c).ToArray());
    }

    /// <summary>
    /// 数字转大写英文
    /// </summary>
    /// <param name="number">eg: 22</param>
    /// <returns></returns>
    public static string ToUpperEnglish(this int number)
    {
        if (number == 0)
            return "null";

        var c = (number - 1) % 26 + 65;
        var n = (number - 1) / 26 + 1;

        return new string(n.For(i => (char)c).ToArray());
    }



}


public enum PageNumberFormat
{
    /// <summary>
    /// 数字：1,2,3,4,5...
    /// </summary>
    Number,
    /// <summary>
    /// 简体中文：一,二,三,四,五...
    /// </summary>
    SimpleChinese,
    /// <summary>
    /// 繁体中文：壹,贰,叁,肆,伍...
    /// </summary>
    TraditionChinese,
    /// <summary>
    /// 小写英文字母：a,b,c,d,e...
    /// </summary>
    LowerEnglish,
    /// <summary>
    /// 大写英文字母：a,b,c,d,e...
    /// </summary>
    UpperEnglish,
}

internal class PageNumberFormatProvider : ObjectFormatProvider
{
    private PageNumberFormat _type;

    public PageNumberFormatProvider(PageNumberFormat type)
    {
        _type = type;
    }
    public override string Format(string format, object arg, IFormatProvider formatProvider)
    {
        var str = arg?.GetType()?.GetProperty(format)?.GetValue(arg, null)?.ToString() ?? "";
        if (!str.IsNullOrEmpty() && int.TryParse(str, out int i))
            str = _type switch
            {
                PageNumberFormat.Number => i.ToString(),
                PageNumberFormat.SimpleChinese => i.ToSimpleChinese(),
                PageNumberFormat.TraditionChinese => i.ToTraditionChinese(),
                PageNumberFormat.LowerEnglish => i.ToLowerEnglish(),
                PageNumberFormat.UpperEnglish => i.ToUpperEnglish(),
                _ => i.ToString(),
            };
        return str;
    }


}



