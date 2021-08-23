using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Document;
using YiDanCommon.Ctrs.FORM;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using YiDanCommon.Util;
using YidanSoft.Library.EmrEditor.Src.Gui.WebApiDTO.GTCMCDS;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;
using System.Runtime.InteropServices;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    public partial class SubjectForm : DevBaseForm
    {

        ZYTextDocument myDocument;

        string elementText;

        ZYTextContainer myElement;

        public SubjectForm()
        {
            InitializeComponent();
        }

        public SubjectForm(ZYSubject element)
        {
            InitializeComponent();

            myDocument = element.OwnerDocument;
            myElement = element;
            elementText = element.Text;

        }

        public SubjectForm(ZYTextParagraph element)
        {
            InitializeComponent();

            myDocument = element.OwnerDocument;
            myElement = element;
            elementText = myElement.ToEMRString();

        }

        private void SetLocation()
        {
            Rectangle AbsolutEditorWinRect = myDocument.OwnerControl.ClientRectangle;
            AbsolutEditorWinRect.Location = myDocument.OwnerControl.PointToScreen(AbsolutEditorWinRect.Location);

            //弹出窗口绝对位置
            Rectangle AbsolutHelpWinRect = this.Bounds;
            var myLine = myDocument.Content.CurrentLine;

            Point clientPoint = myDocument.ViewPointToClient(myLine.RealLeft, myLine.RealTop);


            AbsolutHelpWinRect.Location = new Point(
            AbsolutEditorWinRect.Location.X + clientPoint.X,
            AbsolutEditorWinRect.Location.Y + clientPoint.Y);

            //AbsolutHelpWinRect.Location = zySubject.OwnerDocument.OwnerControl.m_MouseDownPosition;

            Size lineSize = new Size();
            if (myLine.Elements.Count > 0)
            {
                string str = "";
                Font font = null;
                
                foreach (var item in myLine.Elements)
                {
                    if (item is ZYTextChar)
                    {
                        str += (item as ZYTextChar).Char;
                        font = (item as ZYTextChar).Font;
                    }
                }
                lineSize = TextRenderer.MeasureText(str.TrimEnd(), font);
                AbsolutHelpWinRect.Offset(lineSize.Width, lineSize.Height);
            }
            
            
            //计算合理位置
            //弹出窗口没有超出编辑窗口范围
            if (AbsolutEditorWinRect.Contains(AbsolutHelpWinRect))
            {
            }
            else
            {
                int x = 0;
                int y = 0;
                //调整水平位置
                if (AbsolutHelpWinRect.Right > AbsolutEditorWinRect.Right)
                {
                    x = AbsolutEditorWinRect.Right - AbsolutHelpWinRect.Right;
                    
                }
                //调整垂直位置
                if (AbsolutHelpWinRect.Bottom > AbsolutEditorWinRect.Bottom)
                {
                    y = -AbsolutHelpWinRect.Height;
                    if (lineSize!=null)
                    {
                        y -= lineSize.Height;
                    }
                }

                AbsolutHelpWinRect.Offset(x, y);
            }

            this.Location = AbsolutHelpWinRect.Location;
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {

            SetLocation();

            //无边框窗体设置四周阴影
            FormPrintShadow.ApplyShadows(this);
        }

        public void SetFocus()
        {

            if (this.InvokeRequired)
                this.Invoke(new Action(() => textBox1.Focus()));
            else
                textBox1.Focus();

        }

        private void StartLoadZZ()
        {
            new Task(() =>
            {
                LoadZZ();
            }).Start();
        }

        public bool LoadZZ()
        {
            try
            {
                elementText = myElement.ToEMRString();

                if (this.InvokeRequired)
                    this.Invoke(new Action(() => flowLayoutPanelZZ.Controls.Clear()));
                else
                    flowLayoutPanelZZ.Controls.Clear();

                string subjectStr = "";

                if (!string.IsNullOrEmpty(elementText) && !string.IsNullOrEmpty(elementText.Trim()))
                {
                    if (this.elementText.LastIndexOf(",") != -1
                        || this.elementText.LastIndexOf("、") != -1
                        || this.elementText.LastIndexOf("，") != -1)
                    {
                        subjectStr = elementText.Remove(elementText.Length - 1).Trim();
                    }
                    else
                    {
                        subjectStr = elementText.Trim();
                    }
                    subjectStr = subjectStr.Replace('、', ',').Replace('，', ',');
                }
                var jsonRes = HttpUtil.HttpGet(string.Format(
                    "http://210.73.61.110:8099/tcmcds/sys/consilia/InteInquList?keyWord={0}", subjectStr),5000);

                InteInquListResponse res = JsonUtil.JsonToT<InteInquListResponse>(jsonRes);
                if (res == null || string.IsNullOrEmpty(res.strText))
                {
                    //this.Close();
                    return false;
                }

                var controls = res.Results.Select(r =>
                {
                    var button = new SimpleButton();
                    button.Cursor = Cursors.Hand;
                    button.Font = new Font("微软雅黑", 10F);
                    button.ForeColor = Color.FromArgb(157, 147, 165);
                    button.Appearance.BackColor = Color.White;
                    button.Cursor = Cursors.Hand;
                    button.Location = new Point(150, 10);
                    button.Margin = new Padding(5);
                    button.Size = new Size(TextRenderer.MeasureText(r,button.Font).Width + 15, 30);
                    button.Text = r;

                    button.BorderStyle = BorderStyles.HotFlat;
                    button.Appearance.BorderColor = Color.FromArgb(1,221, 221, 221);
                    button.Appearance.Options.UseBackColor = true;
                    button.Appearance.Options.UseBorderColor = true;
                    button.Appearance.Options.UseForeColor = true;
                    button.Appearance.Options.UseFont = true;
                    button.Appearance.Options.UseTextOptions = true;

                    button.Click += new EventHandler(btnConfirm_Click);
                    
                    button.MouseEnter += (sender, args) =>
                    {
                        ((SimpleButton)sender).Appearance.BackColor = Color.FromArgb(1,135, 206, 235);
                        ((SimpleButton)sender).Appearance.BorderColor = Color.FromArgb(1,135, 206, 235);
                        ((SimpleButton)sender).ForeColor = Color.White;
                    };

                    button.MouseLeave += (sender, args) =>
                    {
                        ((SimpleButton)sender).Appearance.BorderColor = Color.FromArgb(1, 221, 221, 221);
                        ((SimpleButton)sender).Appearance.BackColor = Color.White;
                        ((SimpleButton)sender).ForeColor = Color.FromArgb(1,157,147,165);
                    };


                    return button;
                }).ToArray();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { flowLayoutPanelZZ.Controls.AddRange(controls);
                    }));
                }
                else
                {
                    flowLayoutPanelZZ.Controls.AddRange(controls);
                }

                SetFormSize();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void SubjectForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string subStr = "";
            subStr += ((SimpleButton)sender).Text;// +",";
            
            if (subStr.LastIndexOf(",") != -1)
            {
                subStr = subStr.Remove(subStr.Length - 1);
            }
            else
            {
                subStr += ",";
            }
            myDocument.Content.InsertString(subStr);
            SetLocation();
            SetFocus();
            //StartLoadZZ();
            if (!this.LoadZZ())
            {
                myDocument.Content.SetSubjectFormNull();
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                if (keyData == Keys.Escape || keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
                {
                    this.Close();//esc关闭窗体
                }
                else if (keyData == Keys.Back)
                {
                    myDocument._BackSpace(true);
                    SetLocation();
                    SetFocus();
                }
               
            }
            return false;
        }

        private void SubjectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void SubjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string elStr = myElement.ToEMRString();

            if (!string.IsNullOrEmpty(elStr) )
            {
                elStr = elStr.TrimEnd('\r', '\n');
                if (elStr.EndsWith("，") || elStr.EndsWith(",") || elStr.EndsWith("、"))
	            {
                    myDocument._BackSpace(true);
                    myDocument.Content.InsertString("。");
	            }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                myDocument.Content.InsertString(textBox1.Text);
                SetLocation();
                if (textBox1.Text.LastIndexOf(',') != -1)
                {
                    StartLoadZZ();
                }
                textBox1.Text = "";
            }
        }

        private void SetFormSize()
        {
            this.Size = new Size(438, 135);
            this.Size = new Size(438, this.panel2.Height + flowLayoutPanelZZ.Height+10);
        }

        

    }
}
