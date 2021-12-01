using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    public partial class ctlTestFileNew : UserControl
    {
        public ctlTestFileNew()
        {
            InitializeComponent();
        }

        private void tspMenuItemNew_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FileNew", false, null);
        }
    }
}
