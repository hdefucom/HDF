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
    public partial class ctlTestSetVisible : UserControl
    {
        public ctlTestSetVisible()
        {
            InitializeComponent();
        }

        private void frmTestSetSize_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = this.writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\元素可见性.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            }
        }

         
         
        private void btnSetHidden_Click(object sender, EventArgs e)
        {
            if (cboElements.SelectedIndex >= 0)
            {
                XTextElement element = _elements[cboElements.SelectedIndex];
                if (element != null)
                {
                    bool result = element.EditorSetVisible(false);
                    MessageBox.Show("操作结果:" + result);
                }
            }
        }

        private List<XTextElement> _elements = new List<XTextElement>();

        private void myWriterControl_SelectionChanged(object sender, EventArgs e)
        {
            cboElements.Items.Clear();
            _elements.Clear();
            XTextElement element = myWriterControl.CurrentElement;
            while (element != null)
            {
                if (element is XTextDocumentContentElement)
                {
                    break;
                }
                else
                {
                    cboElements.Items.Add(element.GetType().Name + "|" + element.ToString());
                    _elements.Add(element);
                }
                element = element.Parent;
            }
        }

        private void btnSwapVisible_Click(object sender, EventArgs e)
        {
            XTextElement element = myWriterControl.Document.GetElementById(txtElementID.Text);
            if (element == null)
            {
                MessageBox.Show("未找到指定编号的文档元素");
            }
            else
            {
                bool result = element.EditorSetVisible(!element.Visible);
                MessageBox.Show(result.ToString());
            }
        }

    }
}
