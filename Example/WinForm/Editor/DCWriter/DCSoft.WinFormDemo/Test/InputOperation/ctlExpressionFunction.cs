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
    public partial class ctlExpressionFunction : UserControl
    {
        public ctlExpressionFunction()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.EventExpressionFunction += new WriterExpressionFunctionEventHandler(
                myWriterControl_EventExpressionFunction);
        }

        void myWriterControl_EventExpressionFunction(
            object eventSender, 
            WriterExpressionFunctionEventArgs args)
        {
            if (args.FunctionName == "AGE2")
            {
                DateTime dtm = Convert.ToDateTime(args.ParameterString1);
                TimeSpan span = DateTime.Now - dtm;
                args.Result = ( int )(  span.TotalDays / 365 );
                args.Handled = true;
            }
        }
         

        private void btnInsertField_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = new XTextInputFieldElement();
            field.ID = "field1";
            field.LabelText = "出生日期：";
            field.FieldSettings = new InputFieldSettings();
            field.FieldSettings.EditStyle = InputFieldEditStyle.Date;
            field.BackgroundText = "XXXXX";
            myWriterControl.ExecuteCommand("InsertInputField", false, field);

            field = new XTextInputFieldElement();
            field.LabelText = "年龄:";
            field.ValueExpression = "AGE2([field1])";
            field.BackgroundText = "xxxx";
            myWriterControl.ExecuteCommand("InsertInputField", false, field);
        }

        private void btnLoadVBNETDemo_Click(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine(Application.StartupPath, "Test\\表达式调用VB脚本函数.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.LoadDocumentFromFile(fileName, null);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("未找到文件 " + fileName );
            }
        }
         
    }
}