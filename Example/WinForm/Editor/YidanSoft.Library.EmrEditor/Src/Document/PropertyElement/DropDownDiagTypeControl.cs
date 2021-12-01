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
    public partial class DropDownDiagTypeControl : UserControl
    {
        public DropDownDiagTypeControl(IWindowsFormsEditorService e, object v)
        {
            InitializeComponent();
            this.edSvc = e;

            //初始化列表
            listBox1.DataSource = ToListForBind();
            listBox1.ValueMember = "Value";
            listBox1.DisplayMember = "Key";
            if (v != null && v is DiagType)
            {
                this.Value = (DiagType)v;
                listBox1.SelectedValue = v;
            }
        }

        //生成显示数据用的列表数据。    
        public static List<KeyValuePair<string, DiagType>> ToListForBind()
        {
            List<KeyValuePair<string, DiagType>> list = new List<KeyValuePair<string, DiagType>>();
            list.Clear();
            list.Add(new KeyValuePair<string, DiagType>("西医诊断", DiagType.XiYiZhenDuan));
            list.Add(new KeyValuePair<string, DiagType>("中医病", DiagType.ZhongYiBing));
            list.Add(new KeyValuePair<string, DiagType>("中医证", DiagType.ZhongYiZheng));
            return list;
        }

        public IWindowsFormsEditorService edSvc;
        public DiagType Value
        {
            get
            {
                return (DiagType)this.listBox1.SelectedValue;
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
