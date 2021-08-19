using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestSetSize : UserControl
    {
        public ctlTestSetSize()
        {
            InitializeComponent();
        }

        private void frmTestSetSize_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = this.writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }


        private void myWriterControl_DocumentContentChanged(object sender, EventArgs e)
        {
            myWriterControl_SelectionChanged(null, null);
        }

        private void myWriterControl_SelectionChanged(object sender, EventArgs e)
        {
            if (myWriterControl.Selection.Length == 1
                || myWriterControl.Selection.Length == -1)
            {
                XTextElement element = myWriterControl.Selection.ContentElements[0];
                txtWidth.Text = element.Width.ToString();
                txtHeight.Text = element.Height.ToString();
            }
            else
            {
                txtWidth.Text = "";
                txtHeight.Text = "";
            }
        }

        private void btnSetSize_Click(object sender, EventArgs e)
        {
            if (myWriterControl.Selection.Length == 1
                || myWriterControl.Selection.Length == -1)
            {
                XTextElement element = myWriterControl.Selection.ContentElements[0];
                float newWidth = element.Width;
                if (float.TryParse(txtWidth.Text, out newWidth) == false)
                {
                    return;
                }

                float newHeight = element.Height;
                if (float.TryParse(txtHeight.Text, out newHeight) == false)
                {
                    return;
                }
                bool result = element.EditorSetSize(newWidth, newHeight, true, true);
                MessageBox.Show("操作结果:" + result);
            }
        }

    }
}
