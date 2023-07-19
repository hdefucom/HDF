using System;
using System.Collections.Generic;
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

        var y = 10;

        var font = new Font("Segoe UI Emoji", 9f);




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

    List<long[]> list = new List<long[]>();

    private void button1_Click(object sender, EventArgs e)
    {

        var array = new long[int.MaxValue];

        list.Add(array);

        this.Invalidate();

    }


    int rate = 100;

    private void trackBar1_ValueChanged(object sender, EventArgs e)
    {

        panel1.Scale(trackBar1.Value / (float)rate);




        rate = trackBar1.Value;
    }
}