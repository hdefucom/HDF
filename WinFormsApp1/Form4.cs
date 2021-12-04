using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }




        [Category("自定义属性")]
        [Description("标签文本")]
        public string LabelText
        {
            get => label1.Text;
            set => label1.Text = value;
        }


    }
}
