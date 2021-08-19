using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestCreateContentDocument : UserControl
    {
        public ctlTestCreateContentDocument()
        {
            InitializeComponent();
        }
        private void ctlTestCreateContentDocument_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\获取区域内容.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            }
        }

        private void myWriterControl_SelectionChanged(object sender, WriterEventArgs args)
        {
            XTextElement element = myWriterControl.CurrentElement;
            cboRange.Items.Clear();
            cboRange.ComboBox.DisplayMember = "TypeName";
            while (element != null)
            {
                cboRange.Items.Add(element);
                element = element.Parent;
            }
            if (cboRange.Items.Count > 0)
            {
                cboRange.SelectedIndex = 0;
            }
        }

        private void btnViewRangeXML_Click(object sender, EventArgs e)
        {
            XTextElement element = ( XTextElement ) cboRange.SelectedItem;
            if (element != null)
            {
                XTextDocument document = element.CreateContentDocument(true);
                myWriterControl.ExecuteCommand("ViewXMLSource", true, document);
            }
        }

        private void btnContentXML_Click(object sender, EventArgs e)
        {
            XTextElement element = (XTextElement)cboRange.SelectedItem;
            if (element != null)
            {
                XTextDocument document = element.CreateContentDocument(false);
                if (document != null)
                {
                    myWriterControl.ExecuteCommand("ViewXMLSource", true, document);
                }
            }
        }
        private void btnOwnerPageIndex_Click(object sender, EventArgs e)
        {
            XTextElement element = (XTextElement)cboRange.SelectedItem;
            if (element != null)
            {
                MessageBox.Show(element.OwnerPageIndex.ToString());
            }
        }

        private void btnGetClientBounds_Click(object sender, EventArgs e)
        {
            XTextElement element = (XTextElement)cboRange.SelectedItem;
            if (element != null)
            {
                Rectangle rect = this.myWriterControl.GetElementClientBounds(element);
                MessageBox.Show("Left:" + rect.Left + " Top:" + rect.Top + " Width:" + rect.Width + " Height:" + rect.Height);
            }
        }
    }
}