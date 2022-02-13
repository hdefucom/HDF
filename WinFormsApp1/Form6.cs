using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }







        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);





            //var str3 = "💩😓😓😓🚃⛪🚋🚄🐒🐖🐿🌎【💩】\u263A";

            //var str = "\u3053\u3093\u306B\u3061\u306F \u2728";

            //string s1 = "\U0001f8ff";

            //// 3dd8 a9dc
            //var s = e.Graphics.MeasureString("💩", this.Font, 10000, new StringFormat(StringFormat.GenericTypographic)
            //{
            //    FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces,
            //});

            //e.Graphics.FillRectangle(Brushes.Red, 10, 10, s.Width, s.Height);

            //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            //e.Graphics.DrawString(str3, this.Font, Brushes.Black, 10, 10);


            //TextRenderer.DrawText(e.Graphics, str3, this.Font, new Point(10, 30), Color.Black);



            //var f = new Font("宋体", 30);

            //e.Graphics.DrawString(str, f, Brushes.Black, 10, 50);




            var str = textBox1.Text;


            var str_utf8_2 = string.Join(" ", Encoding.UTF8.GetBytes(str).Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray());
            var str_utf8_16 = string.Join(" ", Encoding.UTF8.GetBytes(str).Select(b => Convert.ToString(b, 16).PadLeft(2, '0')).ToArray());


            e.Graphics.DrawString("UTF-8", this.Font, Brushes.Black, 10, 10);
            e.Graphics.DrawString("二进制：" + str_utf8_2, this.Font, Brushes.Black, 10, 30);
            e.Graphics.DrawString("十六进制：" + str_utf8_16, this.Font, Brushes.Black, 10, 50);


            //IPAddress.NetworkToHostOrder()

            var str_unicode_2 = string.Join(" ", Encoding.Unicode.GetBytes(str)/*.Reverse()*/.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).ToArray());
            var str_unicode_16 = string.Join(" ", Encoding.Unicode.GetBytes(str)/*.Reverse()*/.Select(b => Convert.ToString(b, 16).PadLeft(2, '0')).ToArray());

            //StringReader sr = new StringReader(str);

            //var i = sr.Read();

            //while (i != -1)
            //{
            //    i = sr.Read();


            //}

            e.Graphics.DrawString("Unicode", this.Font, Brushes.Black, 10, 70);
            e.Graphics.DrawString("二进制：" + str_unicode_2, this.Font, Brushes.Black, 10, 90);
            e.Graphics.DrawString("十六进制：" + str_unicode_16, this.Font, Brushes.Black, 10, 110);




        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }








}
