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

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlContextMenu : UserControl
    {
        public ctlContextMenu()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }


        private void btnTableContextMenu_Click(object sender, EventArgs e)
        {
            myWriterControl.AddContextMenuItemByTypeName("XTextTableCellElement", "insertrowup", "Table_InsertRowUp", "在上面插入表格行");
            myWriterControl.AddContextMenuItemByTypeName("XTextTableCellElement", "insertrowdown", "Table_InsertRowDown", "在下面插入表格行");
            myWriterControl.AddContextMenuSeparatorByTypeName("XTextTableCellElement");
            myWriterControl.AddContextMenuItemByTypeName("XTextTableCellElement", "mergecell", "Table_MergeCell", "合并单元格");
            myWriterControl.AddContextCustomMenuItem(
                typeof(XTextTableCellElement),
                "我的功能",
                new EventHandler( this.MyFunction ));
        }

        private void MyFunction(object sender, EventArgs args)
        {
            MessageBox.Show("执行我的代码");
        }
    }
}