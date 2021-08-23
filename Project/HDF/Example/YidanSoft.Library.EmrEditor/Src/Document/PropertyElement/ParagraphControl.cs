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
    public partial class ParagraphControl : UserControl
    {
        public ParagraphControl(IWindowsFormsEditorService e, object v)
        {
            InitializeComponent();
            this.edSvc = e;
            listBox1.DataSource = ToListForBind();
            listBox1.ValueMember = "Value";
            listBox1.DisplayMember = "Key";
            if (v != null && v is ParagraphAlignConst)
            {
                this.Value = (ParagraphAlignConst)v;
                listBox1.SelectedValue = v;
            }
            else
            {
                listBox1.SelectedValue = false;
            }
        }
        //生成显示数据用的列表数据。    
        public static List<KeyValuePair<string, ParagraphAlignConst>> ToListForBind()
        {
            List<KeyValuePair<string, ParagraphAlignConst>> list = new List<KeyValuePair<string, ParagraphAlignConst>>();
            list.Clear();
            list.Add(new KeyValuePair<string, ParagraphAlignConst>("居中对齐", ParagraphAlignConst.Center));
            list.Add(new KeyValuePair<string, ParagraphAlignConst>("分散对齐", ParagraphAlignConst.Disperse));
            list.Add(new KeyValuePair<string, ParagraphAlignConst>("两端对齐", ParagraphAlignConst.Justify));
                        list.Add(new KeyValuePair<string, ParagraphAlignConst>("左对齐", ParagraphAlignConst.Left));
                        list.Add(new KeyValuePair<string, ParagraphAlignConst>("右对齐", ParagraphAlignConst.Right));

            return list;
        }
        public IWindowsFormsEditorService edSvc;
        public ParagraphAlignConst Value
        {
            get
            {
                return (ParagraphAlignConst)this.listBox1.SelectedValue;
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
        }
    }
}

