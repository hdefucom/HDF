using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YidanSoft.Library.EmrEditor.Src.Print
{
    public partial class PrintExPanel : UserControl
    {
        public PrintExPanel()
        {
            InitializeComponent();
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("范围中所有页面");
            this.comboBox1.Items.Add("奇数页");
            this.comboBox1.Items.Add("偶数页");
            this.comboBox1.Items.Add("偶数页(双面打印)");

            //this.comboBox1.SelectedIndex = 0;
            this.comboBox1.Text = "范围中所有页面";
            this.label1.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
