using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestInputField : UserControl
    {
        public ctlTestInputField()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnInsertInputField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.ID = "field1";
            field.BackgroundText = "请选择内容";
            field.FieldSettings = new InputFieldSettings();
            // 下拉列表方式
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.MultiSelect = true;// 多选
            // 用户不能直接修改内容，只能选择列表项目
            field.UserEditable = false;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.Items = new ListItemCollection();
            for (int iCount = 0; iCount < 20; iCount++)
            {
                // 添加列表内容
                field.FieldSettings.ListSource.Items.AddByTextValue("文本" + iCount, "数值" + iCount);
            }
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnSetSelectedItems_Click(object sender, EventArgs e)
        {
            myWriterControl.SetInputFieldSelectedIndexs("field1", "0,3,7,9");
            //XTextInputFieldElement field = myWriterControl.CurrentInputField;
            //if (field != null)
            //{
            //    field.EditorSetSelectedIndexs("0,3,7,9");
            //}
        }

        private void btnMultiColumnList_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "多栏列表";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.FieldSettings.MultiColumn = true;
            //field.FieldSettings.MultiSelect = true;
            field.FieldSettings.ListSource = new ListSourceInfo();
            field.FieldSettings.ListSource.Items = new ListItemCollection();
            for (int iCount = 0; iCount < 20; iCount++)
            {
                field.FieldSettings.ListSource.Items.AddByTextValueTextInList(
                    "项目" + iCount,
                    "value" + iCount,
                    "项目" + iCount + ",价格" + iCount + ",规格" + iCount + ",编号" + iCount);
            }//for

            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnDefaultCurrentDate_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.DefaultValueType = DCDefaultValueType.CurrentDate;
            field.BackgroundText = "默认当前日期";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.Date;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnDefaultCurrentTime_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.DefaultValueType = DCDefaultValueType.CurrentTime;
            field.BackgroundText = "默认当前时间";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.Time;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnDefaultCurrentDateTime_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.DefaultValueType = DCDefaultValueType.CurrentDateTime;
            field.BackgroundText = "默认当前日期时间";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DateTime;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnResetFormValue_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("ResetFormValue", false, null);
        }

        private void btnViewXMLFragment_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = myWriterControl.CurrentInputField;
            if (field != null)
            {
                string xml = field.GetXMLFragment();
                myWriterControl.ExecuteCommand("ViewXMLSource", true, xml);
            }
        }

        private void btnInsertXMLFragment_Click(object sender, EventArgs e)
        {
            string xml = @"
<XInputField >
   <Attributes />
   <ID>field1</ID>
   <EnableValueValidate>true</EnableValueValidate>
   <BorderElementColor />
   <RuntimeBackgroundTextColor />
   <UserEditable>false</UserEditable>
   <BackgroundText>请选择内容</BackgroundText>
   <FieldSettings>
      <EditStyle>DropdownList</EditStyle>
      <MultiSelect>true</MultiSelect>
      <ListSource>
         <Items>
            <Item>
               <Text>文本0</Text>
               <Value>数值0</Value>
            </Item>
            <Item>
               <Text>文本1</Text>
               <Value>数值1</Value>
            </Item>
            <Item>
               <Text>文本2</Text>
               <Value>数值2</Value>
            </Item>
            <Item>
               <Text>文本3</Text>
               <Value>数值3</Value>
            </Item>
         </Items>
      </ListSource>
   </FieldSettings>
</XInputField>";
            myWriterControl.ExecuteCommand("InsertInputField", false, xml);
        }
    }
}