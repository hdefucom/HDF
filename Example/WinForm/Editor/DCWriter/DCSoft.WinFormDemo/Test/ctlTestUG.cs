using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test
{
    [ToolboxItem(false)]
    public partial class ctlTestUG : UserControl
    {
        public ctlTestUG()
        {
            InitializeComponent();
        }

        private void ctlTestUG_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }
         
    }
}