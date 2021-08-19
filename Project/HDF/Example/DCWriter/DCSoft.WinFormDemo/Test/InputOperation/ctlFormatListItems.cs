using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlFormatListItems : UserControl
    {
        public ctlFormatListItems()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        /// <summary>
        ///解释列表项目输出文本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_EventParseSelectedItems(
            object sender,
            ParseSelectedItemsEventArgs args)
        {
            if (args.FormatString == "有无列表")
            {
                if (args.Text != null)
                {
                    string Value = args.Text.Trim();
                    if (Value.StartsWith("有"))
                    {
                        Value = Value.Substring(1, Value.Length - 1);
                        int index = Value.IndexOf(",无");
                        if (index > 0)
                        {
                            Value = Value.Substring(0, index);
                        }
                        args.Result = Value.Split(args.SeparatorChar);
                    }
                }
            }
        }

        /// <summary>
        /// 处理格式化输出列表项目文本的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_EventFormatListItems(
            object sender,
            FormatListItemsEventArgs args)
        {
            if (args.FormatString == "有无列表")
            {
                string text1 = Contact(args.SelectedItems, args.SeparatorChar);
                string text2 = Contact(args.UnselectedItems, args.SeparatorChar);
                StringBuilder str = new StringBuilder();
                if (string.IsNullOrEmpty(text1) == false)
                {
                    str.Append("有" + text1);
                }
                if (string.IsNullOrEmpty(text2) == false)
                {
                    if (str.Length > 0)
                    {
                        str.Append(",");
                    }
                    str.Append("无" + text2);
                }
                args.Result = str.ToString();
            }
        }

        private string Contact(string[] items, char spliter)
        {
            StringBuilder str = new StringBuilder();
            foreach (string item in items)
            {
                if (str.Length > 0)
                {
                    str.Append(spliter);
                }
                str.Append(item);
            }
            return str.ToString();
        }

        private void btnInsertField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "有无列表型列表";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.ListValueFormatString = "有无列表";
            field.FieldSettings.ListValueSeparatorChar = "、";
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.MultiSelect = true;
            field.FieldSettings.ListSource.Items = new ListItemCollection();
            field.FieldSettings.ListSource.Items.AddByTextValue("舒张早期奔马律", "舒张早期奔马律");
            field.FieldSettings.ListSource.Items.AddByTextValue("舒张晚期奔马律", "舒张晚期奔马律");
            field.FieldSettings.ListSource.Items.AddByTextValue("重叠型奔马律", "重叠型奔马律");
            field.FieldSettings.ListSource.Items.AddByTextValue("开瓣音", "开瓣音");
            field.FieldSettings.ListSource.Items.AddByTextValue("关瓣音", "关瓣音");
            field.FieldSettings.ListSource.Items.AddByTextValue("喀喇音", "喀喇音");
            field.FieldSettings.ListSource.Items.AddByTextValue("心包叩击音", "心包叩击音");
            field.FieldSettings.ListSource.Items.AddByTextValue("肿瘤扑落音", "肿瘤扑落音");
            field.FieldSettings.ListSource.Items.AddByTextValue("收缩早期喷射音", "收缩早期喷射音");
            field.FieldSettings.ListSource.Items.AddByTextValue("收缩中晚期喀喇音", "收缩中晚期喀喇音");

            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }
    }


}