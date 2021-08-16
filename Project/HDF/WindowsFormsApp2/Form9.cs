using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }


        public enum InputBoundaryType
        {
            Start,
            End
        }




        private void Form9_Load(object sender, EventArgs e)
        {



        }
        private void Form9_Paint(object sender, PaintEventArgs e)
        {




            //ControlPaint.DrawGrid(
            //    e.Graphics,
            //    new Rectangle(100, 100, 200, 200),
            //    new Size(10, 10),
            //    Color.White
            //    );


        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (PrintDialog dialog = new PrintDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {


                    PrintDocument doc = new PrintDocument();
                    doc.PrinterSettings = dialog.PrinterSettings;
                    doc.Print();

                }




            }

        }
    }
}
