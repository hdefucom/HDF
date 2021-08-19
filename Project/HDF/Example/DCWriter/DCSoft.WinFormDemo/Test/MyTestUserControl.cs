using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.Test
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class MyTestUserControl : UserControl
    {
        public MyTestUserControl()
        {
            InitializeComponent();
        }

        private void MyTestUserControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

            }
        }
    }
}
