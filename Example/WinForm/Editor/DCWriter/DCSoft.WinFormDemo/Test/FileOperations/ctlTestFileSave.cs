using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    public partial class ctlTestFileSave : UserControl
    {
        public ctlTestFileSave()
        {
            InitializeComponent();
        }

        private void tspMenuItemSave_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FileSave", true, null);
        }
    }
}
