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
    public partial class ctlCustomEditorControl : UserControl
    {
        public ctlCustomEditorControl()
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
            DCSoft.Writer.Dom.XTextInputFieldElement field
                = new DCSoft.Writer.Dom.XTextInputFieldElement();
            field.BackgroundText = "文件名";
            field.ID = "fieldFileName";
            field.EditorControlTypeName = typeof(ctlCustomEditorControlEditorControl).FullName;
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnSetField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = myWriterControl.CurrentInputField;
            if (field != null)
            {
                field.EditorControlTypeName = typeof(ctlCustomEditorControlEditorControl).FullName;
            }
        }

        private void btnBeginEdit_Click(object sender, EventArgs e)
        {
            if (myWriterControl.CurrentInputField == null)
            {
                MessageBox.Show("请将光标放在一个输入域中");
            }
            else
            {
                myWriterControl.BeginEditElementValue(myWriterControl.CurrentInputField);
            }
        }

        private void btnClearEditor_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = myWriterControl.CurrentInputField;
            if (field != null)
            {
                field.EditorControlTypeName = null;
            }
        }
    }
}