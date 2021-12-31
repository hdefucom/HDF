using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml;

namespace WinFormsApp1
{
    public partial class Form_DrawReversibleLine : Form
    {
        public Form_DrawReversibleLine()
        {
            InitializeComponent();

            this.DoubleBuffered = true;



        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
        }




        int x;
        bool isDown;

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;


            Cursor.Clip = new Rectangle(this.Location, this.Size);

            var p = button1.PointToScreen(e.Location);//获取屏幕上的x坐标

            if (p.X == x)
                return;

            var p2 = panel1.PointToScreen(Point.Empty);//获取屏幕上的y坐标


            if (isDown)
                ControlPaint.DrawReversibleLine(new Point(x, p2.Y), new Point(x, p2.Y + panel1.Height), Color.Black);

            ControlPaint.DrawReversibleLine(new Point(p.X, p2.Y), new Point(p.X, p2.Y + panel1.Height), Color.Black);

            x = p.X;
            isDown = true;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDown)
                return;
            var p2 = panel1.PointToScreen(Point.Empty);//获取屏幕上的y坐标
            ControlPaint.DrawReversibleLine(new Point(x, p2.Y), new Point(x, p2.Y + panel1.Height), Color.Black);
            isDown = false;
        }



    }

















}
