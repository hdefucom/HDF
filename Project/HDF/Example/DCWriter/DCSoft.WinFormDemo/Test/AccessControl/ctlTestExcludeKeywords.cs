using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    [ToolboxItem(false)]
    public partial class ctlTestExcludeKeywords : UserControl
    {
        public ctlTestExcludeKeywords()
        {
            InitializeComponent();
        }

        private void frmTestExcludeKeywords_Load(object sender, EventArgs e)
        {
            btnSetValue_Click(null, null);
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\违禁关键字.xml");
            if (System.IO.File.Exists(fileName))
            {
                writerControl1.ExecuteCommand("FileOpen", false, fileName);
            }
        }

        private void btnDocumentValidate_Click(object sender, EventArgs e)
        {
            ValueValidateResultList list = writerControl1.DocumentValueValidate();
            // 或者 ValueValidateResultList list = (ValueValidateResultList)writerControl1.ExecuteCommand("DocumentValueValidate", false, null);
            lvwItem.Items.Clear();
            if (list != null && list.Count > 0)
            {
                foreach (ValueValidateResult result in list)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text =  result.Message + "(" + result.Level + ")";
                    item.Tag = result;
                    lvwItem.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show(ResourceStrings.DocumentValidate);
            }
        }


        private void btnDocumentValueValidateWithCreateDocumentComments_Click(object sender, EventArgs e)
        {
            ValueValidateResultList list = writerControl1.DocumentValueValidateWithCreateDocumentComments();//.DocumentValueValidate();
            // 或者 ValueValidateResultList list = (ValueValidateResultList)writerControl1.ExecuteCommand("DocumentValueValidate", false, null);
            lvwItem.Items.Clear();
            if (list != null && list.Count > 0)
            {
                foreach (ValueValidateResult result in list)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = result.Message + "(" + result.Level + ")";
                    item.Tag = result;
                    lvwItem.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show(ResourceStrings.DocumentValidate);
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("FileOpen", true, null);
        }

        private void btnSetValue_Click(object sender, EventArgs e)
        {
            writerControl1.ExcludeKeywords = txtExcludeKeywords.Text;
            // 也可以使用以下代码
            // writerControl1.DocumentOptions.BehaviorOptions.ExcludeKeywords = txtExcludeKeywords.Text;
        }

        private void lvwItem_Click(object sender, EventArgs e)
        {
            if (lvwItem.SelectedItems.Count > 0)
            {
                ValueValidateResult result = (ValueValidateResult)lvwItem.SelectedItems[0].Tag;
                result.Selet();
                this.writerControl1.Focus();
                this.writerControl1.Select();
            }
        }


    }
}
