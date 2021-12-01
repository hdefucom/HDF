using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Script;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestEventVBScript : UserControl
    {
        public ctlTestEventVBScript()
        {
            InitializeComponent();
        }

        private void frmTestEventVBScript_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnSetEventVBScript2_Click(object sender, EventArgs e)
        {
            VBScriptItemList items = new VBScriptItemList();
            VBScriptItem item = new VBScriptItem();
            item.Name = "Validating";
            item.ScriptText = "if Len( CurrentElement.Text ) < 10 then \r\n EventArgs.ResultState = ElementValidatingState.Fail \r\n EventArgs.Message = \"校验失败，长度必须大于10\" \r\n End if";
            items.Add(item);
            myWriterControl.ExecuteCommand("EditElementEventVBScript", false, items);
        }

        private void btnInsertFieldWithScript_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.BackgroundText = "输入手机号";
            field.ScriptItems = new VBScriptItemList();
            field.ScriptItems.SetScript(
                "Validating",
                "if Len( CurrentElement.Text ) <> 11 then \r\n EventArgs.ResultState = ElementValidatingState.Fail \r\n EventArgs.Message = \"校验失败，长度必须为11\" \r\n End if");
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnScriptError_Click(object sender, EventArgs e)
        {
            if (myWriterControl.Document.ScriptEngine != null)
            {
                myWriterControl.Document.ScriptEngine.ShowErrorDialog(this);
            }
        }
    }
}
