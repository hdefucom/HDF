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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var btn = new Button()
            {
                Name = "button" + centerLayoutPanel1.Controls.Count,
                Text = "button" + centerLayoutPanel1.Controls.Count,
            };
            btn.Click += button1_Click;
            centerLayoutPanel1.Controls.Add(btn);

            var p = btn.PointToScreen(new Point(0, 0));
            p = centerLayoutPanel1.PointToClient(p);

            var y = 0;
            if (p.Y > centerLayoutPanel1.Height)
                y = p.Y - centerLayoutPanel1.Height;

            y = y - centerLayoutPanel1.AutoScrollPosition.Y;

            centerLayoutPanel1.AutoScrollPosition = new Point(0, y);

        }
    }
}
