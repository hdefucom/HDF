using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestMove : UserControl
    {
        public ctlTestMove()
        {
            InitializeComponent();
        }


        private void ctlTestMove_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            foreach (object v in Enum.GetValues(typeof(DCSoft.Writer.MoveTarget)))
            {
                cboMoveTarget.Items.Add(v);
            }
            //add by lidong open a file
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\插入点模板.xml");
            myWriterControl.ExecuteCommand("FileOpen", false, fileName);
        }

        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("MoveToPosition", false, 100);
        }

        private void btnMoveTo2_Click(object sender, EventArgs e)
        {
            if (cboMoveTarget.SelectedIndex >= 0)
            {
                MoveTarget target = (MoveTarget)cboMoveTarget.SelectedItem;
                myWriterControl.ExecuteCommand("MoveTo", false, target);
                myWriterControl.Focus();
            }
        }

        private void btnMoveFirstField_Click(object sender, EventArgs e)
        {
            XTextElementList list = myWriterControl.Document.GetElementsByType(typeof(XTextInputFieldElement));
            if (list != null)
            {
                XTextInputFieldElement field = (XTextInputFieldElement)list[0];
                field.Focus();
            }
        }
    }
}