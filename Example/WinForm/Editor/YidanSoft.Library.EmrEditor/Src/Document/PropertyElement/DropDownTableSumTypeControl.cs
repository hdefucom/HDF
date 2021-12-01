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
using YidanSoft.Library.EmrEditor.Src.Document.Table;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public partial class DropDownTableSumTypeControl<T> : UserControl
    {
        public DropDownTableSumTypeControl(IWindowsFormsEditorService e, object v, IEnumerable<KeyValuePair<string, T>> data)
        {
            InitializeComponent();
            this.edSvc = e;

            //初始化列表
            listBox1.DataSource = data.ToList();
            listBox1.ValueMember = "Value";
            listBox1.DisplayMember = "Key";
            if (v != null)
            {
                this.Value = (T)v;
                listBox1.SelectedValue = v;
            }
        }



        public IWindowsFormsEditorService edSvc;
        public T Value
        {
            get
            {
                return (T)this.listBox1.SelectedValue;
            }
            set
            {
                this.listBox1.SelectedValue = value;
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
