using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestListItems : UserControl
    {
        public ctlTestListItems()
        {
            InitializeComponent();
        }


        private void frmTestListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnInsertField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "请选择值";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.Items = new ListItemCollection();
            field.FieldSettings.ListSource.Items.AddByTextValue("列表项目1", "数值1");
            field.FieldSettings.ListSource.Items.AddByTextValue("列表项目2", "数值2");
            field.FieldSettings.ListSource.Items.AddByTextValue("列表项目3", "数值3");
            field.FieldSettings.ListSource.Items.AddByTextValue("列表项目4", "数值4");
            field.FieldSettings.ListSource.Items.AddByTextValue("列表项目5", "数值5");
            myWriterControl.ExecuteCommand("InsertInputField", false, field);

        }

        private void btnInsertField2_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "请选择值";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.RuntimeItems = new ListItemCollection();
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目1", "数值1");
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目2", "数值2");
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目3", "数值3");
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目4", "数值4");
            field.FieldSettings.ListSource.RuntimeItems.AddByTextValue("列表项目5", "数值5");
            myWriterControl.ExecuteCommand("InsertInputField", false, field);

        }

        private void btnAddBufferedListItems_Click(object sender, EventArgs e)
        {
            ListItemCollection items = new ListItemCollection();
            items.AddByTextValue("男", "1");
            items.AddByTextValue("女", "0");
            myWriterControl.AddBufferedListItems("性别", items, true);

            items = new ListItemCollection();
            items.AddByTextValue("张三", "zhang");
            items.AddByTextValue("李四", "li");
            items.AddByTextValue("王五", "wang");
            items.AddByTextValue("赵六", "zhao");
            myWriterControl.AddBufferedListItems("医生列表", items, true);

        }
    }
}
