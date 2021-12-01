using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }






        private void button1_Click(object sender, EventArgs e)
        {
            myControl1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }












    public class MyControl : UserControl
    {
        public MyControl()
        {

            this.DoubleBuffered = true;
        }



        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            e.Graphics.Clear(Color.Black);

            Debug.WriteLine("OnPaintBackground");


        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Debug.WriteLine("OnPaint");
        }

    }




}
