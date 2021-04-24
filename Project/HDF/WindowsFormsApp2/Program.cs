using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp2
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*

            float val = 1E+08f;

            var font = Control.DefaultFont;

            font = new Font(font.FontFamily, 42, FontStyle.Regular);


            //font单位point就是word中的磅值
            //



            var str = Environment.NewLine;


            var lh = font.GetHeight();


            Bitmap bmp = new Bitmap(100, 100);

            Graphics g = Graphics.FromImage(bmp);
            var h = g.MeasureString(str, font);
            h = g.MeasureString("黄", font);

            var m = new StringFormat(StringFormat.GenericTypographic);
            m.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces;
            //m.FormatFlags |= StringFormatFlags.DirectionVertical;


            h = g.MeasureString("DGJFSDA ", font, 10000, m);

            g.DrawString("sdafkjhas fa ", font, Brushes.Black, 0, 0, m);

            bmp.Save(@"C:\Users\12131\Desktop\aaaa.png", ImageFormat.Png);




            double d = 0.01 / (1 / 300d);

            var font = Control.DefaultFont;









            */

















            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }








    }






}
