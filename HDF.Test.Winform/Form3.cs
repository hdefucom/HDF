using System;
using System.Drawing;
using System.Windows.Forms;

namespace HDF.Test.Winform
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            new Form4().Show();

            return;


            using var g = this.CreateGraphics();
            g.Clear(Color.Black);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Invalidate(new Rectangle(100, 100, 10, 10));
            this.Invalidate(new Rectangle(200, 100, 10, 10));
        }










        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;//1鼠标位置为客户区
        private const int HTCAPTION = 0x2;//2鼠标位置为标题栏


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);


            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }








    }
}
