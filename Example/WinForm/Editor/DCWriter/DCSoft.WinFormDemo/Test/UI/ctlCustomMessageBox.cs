using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace DCSoft.Writer.WinFormDemo.Test.UI
{
    public partial class ctlCustomMessageBox : UserControl
    {
        public ctlCustomMessageBox()
        {
            InitializeComponent();
        }

        private bool boolRuleVisible = true;
        private void tsbSetRuleVisible_Click(object sender, EventArgs e)
        {
            if (boolRuleVisible == true)
            {
                //设置控件标尺显示
                myWriterControl.RuleVisible = true;
                boolRuleVisible = false;
            }
            else
            {
                //设置控件标尺是否显示
                myWriterControl.RuleVisible = false;
                boolRuleVisible = true;
            }
            myWriterControl.ScrollToCaret();
        }

        private void myWriterControl_SelectionChanged(object eventSender, WriterEventArgs args)
        {
            DCSoft.Writer.Dom.XTextLine line = myWriterControl.Document.CurrentContentElement.CurrentLine;
            if (line != null)
            {
                string txt =
                    string.Format(ResourceStrings._LINE,
                    Convert.ToString(myWriterControl.FocusedPageIndexBase0 + 1),
                    Convert.ToString(myWriterControl.CurrentLineIndexInPage),
                    Convert.ToString(myWriterControl.CurrentColumnIndex));
                if (myWriterControl.Selection.Length != 0)
                {
                    txt = txt + string.Format(ResourceStrings._SELECTELEMENTS, Math.Abs(myWriterControl.Selection.Length));
                }
                Point p = myWriterControl.SelectionStartPosition;
                this.tspStatusLabelPosition.Text = txt + " X:" + p.X + " Y:" + p.Y;
            }
        }

        //private bool boolBackColor = true;
        private void tsbSetBackgroundColor_Click(object sender, EventArgs e)
        {
            myWriterControl.BackColor = Color.LightGreen;
            //myWriterControl.BackColorString = "#90EE90";
        }

        private void tsbPageBorderColor_Click(object sender, EventArgs e)
        {
            //myWriterControl.PageBorderColor = Color.Red;
            myWriterControl.CurrentPageBorderColor = Color.Red;
            myWriterControl.Refresh();
        }
        /// <summary>
        /// 使用标准的消息框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetStdMessageBox_Click(object sender, EventArgs e)
        {
            myWriterControl.AppHost.UITools = new DCSoft.WinForms.DCUITools();
        }
        /// <summary>
        /// 使用自定义的消息框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetCustomMessageBox_Click(object sender, EventArgs e)
        {
            myWriterControl.AppHost.UITools = new MyUITools();
        }

        /// <summary>
        /// 自定义的用户界面功能集
        /// </summary>
        private class MyUITools : DCSoft.WinForms.DCUITools
        {
            /// <summary>
            /// 显示普通的系统消息
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="msg"></param>
            public override void ShowMessageBox(IWin32Window parent, string msg)
            {
                using (dlgCustomMessageBox dlg = new dlgCustomMessageBox())
                {
                    dlg.MessageTitle = "系统提示";
                    dlg.MessageContent = msg;
                    dlg.btnClose.Visible = true;
                    dlg.ShowDialog(parent);
                }
            }
            /// <summary>
            /// 显示系统警告消息
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="msg"></param>
            public override void ShowWarringMessageBox(IWin32Window parent, string msg)
            {
                using (dlgCustomMessageBox dlg = new dlgCustomMessageBox())
                {
                    dlg.MessageTitle = "系统警告";
                    dlg.MessageContent = msg;
                    dlg.btnClose.Visible = true;
                    dlg.ShowDialog(parent);
                }
            }
            /// <summary>
            /// 显示系统错误消息
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="msg"></param>
            public override void ShowErrorMessageBox(IWin32Window parent, string msg)
            {
                using (dlgCustomMessageBox dlg = new dlgCustomMessageBox())
                {
                    dlg.MessageTitle = "系统错误";
                    dlg.MessageContent = msg;
                    dlg.btnClose.Visible = true;
                    dlg.ShowDialog(parent);
                }
            }
            /// <summary>
            /// 显示一个消息框，让用户点击是或者否。
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="msg"></param>
            /// <returns></returns>
            public override bool Confirm(IWin32Window parent, string msg)
            {
                using (dlgCustomMessageBox dlg = new dlgCustomMessageBox())
                {
                    dlg.MessageTitle = "系统提示";
                    dlg.MessageContent = msg;
                    dlg.btnYes.Visible = true;
                    dlg.btnNO.Visible = true;
                    if (dlg.ShowDialog(parent) == DialogResult.Yes)
                    {
                        return true;
                    }
                }
                return false;
            }
            /// <summary>
            /// 显示一个消息框，让用户点击是或者否。默认是否。
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="msg"></param>
            /// <returns></returns>
            public override bool ConfirmDefaultNo(IWin32Window parent, string msg)
            {
                using (dlgCustomMessageBox dlg = new dlgCustomMessageBox())
                {
                    dlg.MessageTitle = "系统提示";
                    dlg.MessageContent = msg;
                    dlg.btnYes.Visible = true;
                    dlg.btnNO.Visible = true;
                    dlg.btnNO.Focus();
                    dlg.AcceptButton = dlg.btnNO;
                    if (dlg.ShowDialog(parent) == DialogResult.Yes)
                    {
                        return true;
                    }
                }
                return false;
            }
            /// <summary>
            /// 显示一个消息框，让用户点击是，否或者取消按钮。
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="msg"></param>
            /// <returns></returns>
            public override DialogResult ShowYesNoCancelMessageBox(IWin32Window parent, string msg)
            {
                using (dlgCustomMessageBox dlg = new dlgCustomMessageBox())
                {
                    dlg.MessageTitle = "系统提示";
                    dlg.MessageContent = msg;
                    dlg.btnYes.Visible = true;
                    dlg.btnNO.Visible = true;
                    dlg.btnCancel.Visible = true;
                    return dlg.ShowDialog(parent);
                }
            }
            /// <summary>
            /// 显示一个输入框，让用户输入单行文本。
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="msg"></param>
            /// <param name="defaultValue"></param>
            /// <returns></returns>
            public override string InputBox(IWin32Window parent, string msg, string defaultValue)
            {
                return base.InputBox(parent, msg, defaultValue);
            }
            /// <summary>
            /// 显示一个URL地址输入对话框。
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="title"></param>
            /// <param name="defaultUrl"></param>
            /// <returns></returns>
            public override string InputURL(IWin32Window parent, string title, string defaultUrl)
            {
                return base.InputURL(parent, title, defaultUrl);
            }
            /// <summary>
            /// 显示一个多行的消息框。
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="txt"></param>
            /// <param name="title"></param>
            public override void ShowTextDialog(IWin32Window parent, string txt, string title)
            {
                base.ShowTextDialog(parent, txt, title);
            }

            /// <summary>
            /// 显示一个颜色选择对话框
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="colorValue"></param>
            /// <returns></returns>
            public override bool PickColor(IWin32Window parent, ref Color colorValue)
            {
                using (ColorDialog dlg = new ColorDialog())
                {
                    dlg.Color = colorValue;
                    if (dlg.ShowDialog(parent) == DialogResult.OK)
                    {
                        colorValue = dlg.Color;
                        return true;
                    }
                }
                return false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.myWriterControl.Modified = true;
            this.myWriterControl.ExecuteCommand("FileOpen", true, null);
        }
    }
}
