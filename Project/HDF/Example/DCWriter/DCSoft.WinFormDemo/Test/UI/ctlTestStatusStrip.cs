using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace DCSoft.Writer.WinFormDemo.Test.UI
{
    public partial class ctlTestStatusStrip : UserControl
    {
        public ctlTestStatusStrip()
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
    }
}
