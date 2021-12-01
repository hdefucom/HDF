using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;
using YidanSoft.Library.EmrEditor.Src.Gui;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public partial class DropDownControl : UserControl
    {
        public DropDownControl(IWindowsFormsEditorService e, object v)
        {
            InitializeComponent();
            this.edSvc = e;
            //初始化列表
            foreach (object o in ZYEditorControl.helpEventList)
            {
                this.listBox1.Items.Add(o.ToString());
            }
            if (v != null)
            {
                this.listBox1.Text = v.ToString();
            }
        }

        public IWindowsFormsEditorService edSvc;
        public string Value
        {
            get
            {
                return (string)this.listBox1.Text;
            }
            set
            {
                this.listBox1.Text = value;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edSvc != null)
                edSvc.CloseDropDown();

            Debug.WriteLine(this.listBox1.SelectedValue);
        }
    }
}
