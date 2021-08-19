using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom ;
using DCSoft.Writer.Controls ;
using DCSoft.Writer;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestEvent : UserControl
    {
        public ctlTestEvent()
        {
            InitializeComponent();
        }

        private void frmTestEvent_Load(object sender, EventArgs e)
        {
            myWriterControl.IsAdministrator = true;
            myWriterControl.CommandControler = this.writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\控件级事件和文档元素级事件.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            }

//// 为图片元素添加全局事件模板
//myWriterControl.GlobalEventTemplates[typeof(XTextImageElement)] = eetField;
//// 为条码元素添加全局事件模板
//myWriterControl.GlobalEventTemplates[typeof(XTextBarcodeFieldElement)] = eetField;
        }


        private void btnClearListener_Click(object sender, EventArgs e)
        {
            myWriterControl.EventTemplates.Clear();
        }

        private void btnAddEvent1_Click(object sender, EventArgs e)
        {
            myWriterControl.EventTemplates.Clear();

            ElementEventTemplate eet = new ElementEventTemplate();
            eet.Name = "测试";
            eet.MouseClick += new ElementMouseEventHandler(EET_MouseClick);
            eet.MouseDblClick += new ElementMouseEventHandler(eet_MouseDblClick);
            eet.KeyDown += new ElementKeyEventHandler(EET_KeyDown);
            eet.LostFocus += new ElementEventHandler(EET_LostFocus);
            eet.GotFocus += new ElementEventHandler(EET_GotFocus);
            eet.ContentChanging += new ContentChangingEventHandler(eet_ContentChanging);
            myWriterControl.EventTemplates.Add(eet);

            eet = new ElementEventTemplate();
            eet.Name = "自定义数据校验";
            eet.Validating += new ElementValidatingEventHandler(EET_Validating);
            myWriterControl.EventTemplates.Add(eet);

            eet = new ElementEventTemplate();
            eet.Name = "自定义执行表达式";
            eet.Expression += new ElementExpressionEventHandler(EET_Expression);
            myWriterControl.EventTemplates.Add(eet);

            MyEventTemplate listerner2 = new MyEventTemplate();
            listerner2._OutputTextBox = txtLog;
            listerner2.Name = "测试2";
            myWriterControl.EventTemplates.Add(listerner2);
        }

        void eet_ContentChanging(object eventSender, ContentChangingEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + "即将使用的新文本为：" + args.GetContainerNewText());
        }

        void eet_MouseDblClick(object eventSender, ElementMouseEventArgs args)
        {
            Rectangle rect = myWriterControl.GetElementClientBounds(args.Element);
            MessageBox.Show( rect.Left + " * " + rect.Top + "--" + rect.Width  + " * " + rect.Height );
        }


        private void btnBindDirect_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("SmartSetEventTemplateName", false, "测试");
        }

        /// <summary>
        /// 执行自定义的表达式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void EET_Expression(object sender, ElementExpressionEventArgs args)
        {
            if (args.Expression == "是否成年")
            {
                DateTime dtm = DateTime.Now;
                if (DateTime.TryParse(args.Element.Text, out dtm))
                {
                    if (dtm.Subtract(DateTime.Now).TotalDays > 18 * 365)
                    {
                        args.Result = true;
                        return;
                    }
                }
            }
            args.Result = false;
        }

        /// <summary>
        /// 自定义数据校验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void EET_Validating(object sender, ElementValidatingEventArgs args)
        {
            string text = args.Element.Text;
            txtLog.AppendText(Environment.NewLine + "校验数据:" + text);
            if (text != null)
            {
                if (text.Length > 3 && text.Length < 10)
                {
                    // 校验成功
                    args.ResultState = ElementValidatingState.Success;
                    return;
                }
            }
            args.ResultState = ElementValidatingState.Fail;
            args.Message = "校验失败，长度必须大于3小于10";
        }

        void EET_GotFocus(object sender, ElementEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + args.Element.ID + ":GotFocus");
        }

        void EET_LostFocus(object sender, ElementEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + args.Element.ID + ":LostFocus");
        }

        void EET_KeyDown(object sender, ElementKeyEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + args.Element.ID + ":KeyDown Code:" + args.KeyCode);
        }

        void EET_MouseClick(object sender, ElementMouseEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + args.Element.ID + ":MouseClick");
        }

        private class MyEventTemplate : DCSoft.Writer.ElementEventTemplate
        {
            public TextBox _OutputTextBox = null;

            public override void OnMouseClick(object sender, ElementMouseEventArgs args)
            {
                _OutputTextBox.AppendText(Environment.NewLine + "MouseClick2");
            }
            public override void OnMouseDblClick(object sender, ElementMouseEventArgs args)
            {
                _OutputTextBox.AppendText(Environment.NewLine + "MouseDblClick2");
                args.Handled = true;
            }
            public override void OnMouseDown(object sender, ElementMouseEventArgs args)
            {
                _OutputTextBox.AppendText(Environment.NewLine + "MouseDown2");
            }
            public override void OnGotFocus(object sender, ElementEventArgs args)
            {
                _OutputTextBox.AppendText(Environment.NewLine + "GotFocus2");
            }
            public override void OnLostFocus(object sender, ElementEventArgs args)
            {
                _OutputTextBox.AppendText(Environment.NewLine + "LostFocus2");
            }
            public override void OnMouseEnter(object sender, ElementEventArgs args)
            {
                _OutputTextBox.AppendText(Environment.NewLine + "MouseEnter");
            }
            public override void OnMouseLeave(object sender, ElementEventArgs args)
            {
                _OutputTextBox.AppendText(Environment.NewLine + "MouseLeave");
            }
        }

        private void eetField_ContentChanged(object sender, ContentChangedEventArgs args)
        {
            txtLog.AppendText(Environment.NewLine + "输入域内容发生改变");
        }

        private void btnRaiseEvent_Click(object sender, EventArgs e)
        {
            XTextInputFieldElement field = myWriterControl.CurrentInputField;
            if (field != null)
            {
                myWriterControl.RaiseElementContentChangedEvent(field);
            }
        }
    }
}