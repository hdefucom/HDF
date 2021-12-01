using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public partial class DateTimeFormatControl : UserControl
    {
        public DateTimeFormatControl(IWindowsFormsEditorService e, object v)
        {
            InitializeComponent();
            this.edSvc = e;

            if (v != null && v is string)
            {
                listBox1.SelectedItem = v;
            }
            else
            {
                listBox1.SelectedItem = false;
            }
        }
        public IWindowsFormsEditorService edSvc;
        public string Value
        {
            get
            {
                return (string)this.listBox1.Text;
            }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edSvc != null)
                edSvc.CloseDropDown();
        }
    }
}
