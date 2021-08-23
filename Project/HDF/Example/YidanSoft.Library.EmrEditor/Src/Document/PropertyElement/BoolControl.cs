using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Windows.Forms.Design;
using System.Diagnostics;

namespace YidanSoft.Library.EmrEditor.Src.Document
{
    public partial class BoolControl : UserControl
    {
        public BoolControl(IWindowsFormsEditorService e, object v)
        {
            InitializeComponent();
            this.edSvc = e;
            listBox1.DataSource = ToListForBind();
            listBox1.ValueMember = "Value";
            listBox1.DisplayMember = "Key";
            if (v != null && v is bool)
            {
                this.Value = (bool)v;
                listBox1.SelectedValue = v;
            }
            else
            {
                listBox1.SelectedValue = false;
            }
        }
        //生成显示数据用的列表数据。    
        public static List<KeyValuePair<string, bool>> ToListForBind()
        {
            List<KeyValuePair<string, bool>> list = new List<KeyValuePair<string, bool>>();
            list.Clear();
            list.Add(new KeyValuePair<string, bool>("是", true));
            list.Add(new KeyValuePair<string, bool>("否", false));
            return list;
        }
        public IWindowsFormsEditorService edSvc;
        public bool Value
        {
            get
            {
                return (bool)this.listBox1.SelectedValue;
            }
            set
            {
                this.listBox1.SelectedValue = value;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(edSvc!=null)
            edSvc.CloseDropDown();
        }
    }
}
