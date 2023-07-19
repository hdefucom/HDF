using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form_ScrollBar2 : Form
    {
        public Form_ScrollBar2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _ = this.AutoScroll;//是否自动启用滚动条

            _ = this.AutoScrollMargin;//设置滚动区域多余边距

            _ = this.AutoScrollMinSize;//设置滚动区域大小

            _ = this.AutoScrollOffset;

            _ = this.AutoScrollPosition;//设置滚动视图的位置


            this.vScrollBar1.Minimum = 0;

            this.vScrollBar1.LargeChange = panel1.ClientSize.Height;

            //this.vScrollBar1.Maximum = panel1.DisplayRectangle.Height;//+ panel1.ClientSize.Height;
            this.vScrollBar1.Maximum = button1.Bottom - 1;

        }

        private void Form1_Click(object sender, EventArgs e)
        {

            _ = this.VerticalScroll;


            _ = this.Size;

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.panel1.VerticalScroll.Value = vScrollBar1.Value;

            //this.panel1.AutoScrollPosition = new Point(this.panel1.AutoScrollPosition.X, e.NewValue);
        }


    }



    public class MyPanel : Panel
    {



        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            ShowScrollBar(this.Handle, 3, false);//0:horizontal,1:vertical,3:both
            base.WndProc(ref m);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);


    }



}
