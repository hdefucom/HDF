using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.MouseDown += (_, e) => Console.WriteLine($"【{DateTime.Now}】MouseDown{e.Location}");
            this.MouseMove += (_, e) => Console.WriteLine($"【{DateTime.Now}】MouseMove{e.Location}"); 
            this.MouseUp += (_, e) => Console.WriteLine($"【{DateTime.Now}】MouseUp{e.Location}"); 
            this.MouseClick += (_, e) => Console.WriteLine($"【{DateTime.Now}】MouseClick{e.Location}");
            this.MouseEnter += (_, e) => Console.WriteLine($"【{DateTime.Now}】MouseEnter{MousePosition}");
            this.MouseLeave += (_, e) => Console.WriteLine($"【{DateTime.Now}】MouseLeave{MousePosition}");
            this.MouseHover += (_, e) => Console.WriteLine($"【{DateTime.Now}】MouseHover{MousePosition}");
            this.Click += (_, e) => Console.WriteLine($"【{DateTime.Now}】Click{MousePosition}");

        }






        private void Form2_Paint(object sender, PaintEventArgs e)
        {

            var source1 = new Point(0, 0);
            var source2 = new Point(50, 0);

            //e.Graphics.TranslateTransform(100, 100);

            //e.Graphics.DrawRectangle(Pens.Red, new Rectangle(0, 0, 100, 100));

            e.Graphics.DrawLine(Pens.Black, source1, source2);


            //e.Graphics.DrawRectangle(Pens.Black, source1, source2,)；


            var container = e.Graphics.BeginContainer();



            e.Graphics.ScaleTransform(2, 2);
            e.Graphics.TranslateTransform(100, 100);




            e.Graphics.DrawLine(Pens.Red, source1, source2);


            e.Graphics.EndContainer(container);

            e.Graphics.DrawLine(Pens.Red, source1, source2);



            //var m1 = new Matrix();

            //m1.Translate(100, 100);

            //m1.Scale(2, 2);


            var ps = new[] { source1, source2 };

            e.Graphics.Transform.TransformPoints(ps);

            //m1.TransformPoints(ps);
            ////m1.TransformVectors(ps);
            ////m1.VectorTransformPoints(ps);

            //e.Graphics.DrawLine(Pens.Black, ps[0], ps[1]);





            label1.Text = $"Source:{source1}{source2}{Environment.NewLine}Target:{ps[0]}{ps[1]}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
