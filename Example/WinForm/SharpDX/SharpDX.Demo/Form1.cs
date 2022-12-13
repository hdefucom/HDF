using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SharpDX.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }




        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            Stopwatch s = new Stopwatch();

            s.Start();


            e.Graphics.Clear(Color.FromArgb(255, 0, 0, 0));


            //for (int i = 0; i < 10000; i++)
            e.Graphics.DrawString("😂😂😂", new Font("Segoe UI Emoji", 24f), Brushes.White, 0, 0);
            e.Graphics.DrawString("==> => == ===", new Font("Fira Code", 24f), Brushes.White, 0, 50);

            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);
        }











    }
}
