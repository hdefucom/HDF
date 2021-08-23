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
using YidanSoft.Library.EmrEditor.Src.Common;

namespace YidanSoft.Library.EmrEditor.Src.Document.PorpertyElement
{
    public partial class FontControl : UserControl
    {
        public FontControl(IWindowsFormsEditorService e, object v)
        {
            InitializeComponent();
            this.edSvc = e;

            this.listBox1.Items.AddRange(FontCommon.FontList.ToArray());
            this.listBox1.Text = (string)v;
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
