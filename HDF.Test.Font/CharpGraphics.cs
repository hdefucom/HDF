using Microsoft.JSInterop;
using System.Drawing;

namespace HDF.Test.Font;

public class CharpGraphics
{


    //static Graphics _Graphics = Graphics.FromHwnd(IntPtr.Zero);




    [JSInvokable]
    public static SizeF MeasureString(string text, System.Drawing.Font font, int width, StringFormat format)
    {

        //return _Graphics.MeasureString(text, font, width, format);



        //SixLabors.Fonts.TextMeasurer.MeasureSize("");


        return new SizeF(10, 10);

    }



    [JSInvokable]

    public static int Get()
    {

        return 10;
    }







    public static void Main()
    {
        Console.WriteLine($"CharpGraphics 初始化!");

        //Console.WriteLine(MeasureString("a", new System.Drawing.Font("宋体", 12f), 10000, StringFormat.GenericDefault));
    }

    [JSInvokable]
    public async static Task<string[]> Demo()
    {

        await Task.Delay(500);
        return new string[] { "111111", "22222222222" };
    }


}