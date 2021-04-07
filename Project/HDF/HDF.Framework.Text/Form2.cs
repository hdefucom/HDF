using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDF.Framework.Text
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (DesignMode)
                File.AppendAllText("E://1.txt", "ffffffffffffff");
        }

        private void Form2_Load(object sender, EventArgs e)
        {



            Rectangle[] rects = {
            new Rectangle(0,0,10,10),
            new Rectangle(10,0,10,10),
            new Rectangle(20,0,10,10),
            };



            Rectangle rect = Rectangle.Empty;
            foreach (var item in rects)
            {
                //if (rect.IsEmpty)
                //    rect = item;
                //else
                rect = Rectangle.Union(rect, item);
            }

            var r = rect;







        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {








        }
    }
}
