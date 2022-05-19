using System.Drawing;
using System.Windows.Forms;

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

        var format = new StringFormat { Trimming = StringTrimming.EllipsisWord };

        format.FormatFlags = StringFormatFlags.NoClip;
        var y = 10;

        {
            var size1 = g.MeasureString(str1, font, 1000, format);
            var size2 = g.MeasureString(str2, font, 1000, format);

            format.Trimming = StringTrimming.EllipsisCharacter;
            g.DrawString(str1, font, Brushes.Black, 10, y, format);
            y += 20;
            format.Trimming = StringTrimming.None;
            g.DrawString(str1, font, Brushes.Black, 10, y, format);
            g.DrawString(str2, font, Brushes.Black, 10, y + 20, format);

            g.DrawRectangle(Pens.Black, 10, y, size1.Width, size1.Height);
            g.DrawRectangle(Pens.Black, 10, y + 20, size2.Width, size2.Height);

            g.DrawString(size1.ToString(), font, Brushes.Black, 80, y, format);
            g.DrawString(size2.ToString(), font, Brushes.Black, 80, y + 20, format);
        }

        {
            y += 50;

            format.Trimming = StringTrimming.Character;

            var size1 = g.MeasureString(str1, font, 1000, format);
            var size2 = g.MeasureString(str2, font, 1000, format);

            g.DrawString(str1, font, Brushes.Black, 10, y, format);
            g.DrawString(str2, font, Brushes.Black, 10, y + 20, format);

            g.DrawRectangle(Pens.Black, 10, y, size1.Width, size1.Height);
            g.DrawRectangle(Pens.Black, 10, y + 20, size2.Width, size2.Height);

            g.DrawString(size1.ToString(), font, Brushes.Black, 80, y, format);
            g.DrawString(size2.ToString(), font, Brushes.Black, 80, y + 20, format);
        }




    }
}