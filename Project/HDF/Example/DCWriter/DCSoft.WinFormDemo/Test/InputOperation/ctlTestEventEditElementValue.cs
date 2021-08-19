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
    public partial class ctlTestEventEditElementValue : UserControl
    {
        public ctlTestEventEditElementValue()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.EventEditElementValue += new WriterEditElementValueEventHandler(myWriterControl_EventEditElementValue);
        }

        void myWriterControl_EventEditElementValue(object eventSender, WriterEditElementValueEventArgs args)
        {
            if (args.FieldElement != null && args.FieldElement.EditorControlTypeName == "filename")
            {
                args.Handled = true;
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.CheckFileExists = true;
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        args.FieldElement.EditorTextExt = dlg.FileName;
                        args.Result = ElementValueEditResult.UserAccept;
                    }
                    else
                    {
                        args.Result = ElementValueEditResult.UserCancel;
                    }
                }
            }
        }

        private void btnInsertList_Click(object sender, EventArgs e)
        {
            DCSoft.Writer.Dom.XTextInputFieldElement field
                = new DCSoft.Writer.Dom.XTextInputFieldElement();
            field.BackgroundText = "文件名";
            field.ID = "fieldFileName";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
            field.EditorControlTypeName = "filename";
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnSetField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = myWriterControl.CurrentInputField;
            if (field != null)
            {
                field.EditorControlTypeName = "filename";
            }
        }
    }
}