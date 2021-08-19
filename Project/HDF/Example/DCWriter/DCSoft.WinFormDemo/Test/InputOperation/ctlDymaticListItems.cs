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
    public partial class ctlDymaticListItems : UserControl
    {
        public ctlDymaticListItems()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnInsertList_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "药品列表";
            field.ID = "药品列表";
            field.FieldSettings = new InputFieldSettings();
            //field.FieldSettings.MultiSelect = true;
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            // 标记这是动态查询下拉列表内容
            field.FieldSettings.DynamicListItems = true;
            field.EnableLastSelectedListItems = true;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        /// <summary>
        /// 响应编辑器控件的QueryListItems事件，动态加载下拉列表内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_QueryListItems(
            object sender, 
            QueryListItemsEventArgs args)
        {
            if (args.Element.ID == "药品列表")
            {
                using (IDbConnection conn = Utils.CreateConnection())
                {
                    conn.Open();
                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        string spellCode = args.SpellCode;
                        if (spellCode != null)
                        {
                            spellCode = spellCode.Trim().ToLower();
                        }
                        if (string.IsNullOrEmpty(spellCode))
                        {
                            cmd.CommandText = "Select top 100 name ,py From  EMR_DOCEX   order by name";
                        }
                        else
                        {
                            cmd.CommandText = "Select top 100 name ,py From  EMR_DOCEX   where py like '" + spellCode + "%'  order by name ";
                        }
                        IDataReader reader = cmd.ExecuteReader();
                        ListItemCollection list = new ListItemCollection();
                        while (reader.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = Convert.ToString(reader.GetValue(0));
                            item.Value = item.Text;
                            list.Add(item);
                        }
                        reader.Close();
                        args.Result = list;
                    }
                }
            }
        }

        private void btnInsertListCC_Click(object sender, EventArgs e)
        {
            DCSoft.Writer.Dom.XTextInputFieldElement field
                   = new DCSoft.Writer.Dom.XTextInputFieldElement();
            field.BackgroundText = "汉字检索";
            field.ID = "fieldFileName";
            field.EditorControlTypeName = "DCSoft.Writer.WinFormDemo.Test.InputOperation.ctlChinesecharacter";
            myWriterControl.ExecuteCommand("InsertInputField", false, field);

        }
         
    }
}