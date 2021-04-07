using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            InitScrollInfo();
            InitScrollEvent();
        }


        private void InitScrollInfo()
        {
            var height = this.panel_Body.Controls.Cast<System.Windows.Forms.Control>().Max(c => c.Location.Y + c.Height - 1);

            if (height <= this.panel_Body.Height)
            {
                this.vScrollBar1.Visible = false;
                return;
            }

            this.vScrollBar1.Minimum = 0;
            this.vScrollBar1.Maximum = height;
            this.vScrollBar1.LargeChange = this.panel_Body.Height;

            this.panel_Body.VerticalScroll.Minimum = 0;
            this.panel_Body.VerticalScroll.Maximum = height;
            this.panel_Body.VerticalScroll.LargeChange = this.panel_Body.Height;
            this.panel_Body.VerticalScroll.Visible = false;

        }
        private void InitScrollEvent()
        {
            this.panel_Body.MouseWheel += (obj, e) =>
            {
                if (!vScrollBar1.Visible)
                    return;
                if (vScrollBar1.Value - e.Delta + vScrollBar1.LargeChange > vScrollBar1.Maximum)
                    vScrollBar1.Value = vScrollBar1.Maximum - vScrollBar1.LargeChange + 1;
                else if (vScrollBar1.Value - e.Delta < vScrollBar1.Minimum)
                    vScrollBar1.Value = vScrollBar1.Minimum;
                else
                    vScrollBar1.Value -= e.Delta;

                //if (this.panel_Body.VerticalScroll.Value != vScrollBar1.Value)
                this.panel_Body.VerticalScroll.Value = vScrollBar1.Value;
            };

            this.vScrollBar1.Scroll += (obj, e) =>
            {
                if (!vScrollBar1.Visible)
                    return;
                //if (this.panel_Body.VerticalScroll.Value != vScrollBar1.Value)
                this.panel_Body.VerticalScroll.Value = vScrollBar1.Value;
            };
        }






        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var p1 = this.button1.Location;
            p1.Offset(0, -10);
            this.button1.Location = p1;

            var p2 = this.button2.Location;
            p2.Offset(0, -10);
            this.button2.Location = p2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var p1 = this.button1.Location;
            p1.Offset(0, 10);
            this.button1.Location = p1;

            var p2 = this.button2.Location;
            p2.Offset(0, 10);
            this.button2.Location = p2;
        }

        private void panel_Body_Layout(object sender, LayoutEventArgs e)
        {
            InitScrollInfo();
        }
    }
}
