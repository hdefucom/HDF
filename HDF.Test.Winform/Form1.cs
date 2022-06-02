using HDF.Test.Winform.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;

namespace HDF.Test.Winform;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    private void Form1_Paint(object sender, PaintEventArgs e)
    {

        /*
         StringFormat.Trimming  应该不影响测量字符大小
         
         
         
         
         
         */


        var g = e.Graphics;

        var str1 = "黄德富";
        var str2 = "123";

        var font = new Font("宋体", 9f);


        var y = 10;



        str1 = "😂😂😂";
        font = new Font("Segoe UI Emoji", 9f);


        if (false)
        {


            var families = Fonts.GetFontFamilies(@"C:\WINDOWS\Fonts\simsun.ttc");
            foreach (System.Windows.Media.FontFamily family in families)
            {
                var typefaces = family.GetTypefaces();
                foreach (Typeface typeface in typefaces)
                {
                    GlyphTypeface glyph;
                    typeface.TryGetGlyphTypeface(out glyph);
                    IDictionary<int, ushort> characterMap = glyph.CharacterToGlyphMap;

                    foreach (KeyValuePair<int, ushort> kvp in characterMap)
                    {
                        Console.WriteLine(String.Format("{0}:{1}", kvp.Key, kvp.Value));
                    }

                }
            }





        }









        {

            var aaa = MeasureDisplayStringWidth(g, str1, font);

            var bbb = TextRenderer.MeasureText(str1, font, new Size(100, 100), TextFormatFlags.ExternalLeading | TextFormatFlags.NoPadding);
            var ccc = TextRenderer.MeasureText(str1, font);

        }

        {
            var format = new StringFormat(StringFormat.GenericTypographic);


            var size1 = g.MeasureString(str1, font, 1000, format);
            var size2 = g.MeasureString(str2, font, 1000, format);

            g.DrawString(str1, font, System.Drawing.Brushes.Black, 10, y, format);
            g.DrawString(str2, font, System.Drawing.Brushes.Black, 10, y + 20, format);

            g.DrawRectangle(Pens.Black, 10, y, size1.Width, size1.Height);
            g.DrawRectangle(Pens.Black, 10, y + 20, size2.Width, size2.Height);

            g.DrawString(size1.ToString(), font, System.Drawing.Brushes.Black, 80, y, format);
            g.DrawString(size2.ToString(), font, System.Drawing.Brushes.Black, 80, y + 20, format);
        }

        {
            y += 50;

            var format = new StringFormat();
            format.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.FitBlackBox | StringFormatFlags.LineLimit;// | StringFormatFlags.MeasureTrailingSpaces;
            format.Trimming = StringTrimming.None;

            var size1 = g.MeasureString(str1, font, 1000, format);
            var size2 = g.MeasureString(str2, font, 1000, format);

            g.DrawString(str1, font, System.Drawing.Brushes.Black, 10, y, format);
            g.DrawString(str2, font, System.Drawing.Brushes.Black, 10, y + 20, format);

            g.DrawRectangle(Pens.Black, 10, y, size1.Width, size1.Height);
            g.DrawRectangle(Pens.Black, 10, y + 20, size2.Width, size2.Height);

            g.DrawString(size1.ToString(), font, System.Drawing.Brushes.Black, 80, y, format);
            g.DrawString(size2.ToString(), font, System.Drawing.Brushes.Black, 80, y + 20, format);
        }




    }



    static public float MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
    {
        System.Drawing.StringFormat format = new System.Drawing.StringFormat();
        System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, 1000, 1000);
        var ranges = new System.Drawing.CharacterRange(0, text.Length);
        System.Drawing.Region[] regions = new System.Drawing.Region[1];

        format.SetMeasurableCharacterRanges(new CharacterRange[] { ranges });

        regions = graphics.MeasureCharacterRanges(text, font, rect, format);
        rect = regions[0].GetBounds(graphics);

        //return (int)(rect.Right + 1.0f);
        return rect.Width;
    }

    private void button1_Click(object sender, EventArgs e)
    {



        var config = ServiceProviderHelper.ServiceProvider.GetService<IConfiguration>();

        var s = config.GetValue(typeof(string), "Serilog:MinimumLevel");

        var c = ServiceProviderHelper.ServiceProvider.GetService<IOptionsSnapshot<MyConfig>>();

        Console.WriteLine(c?.Value?.Name);


    }
}