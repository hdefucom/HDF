using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSoft.Writer.Data;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo
{
    public partial class dlgLogin : Form
    {
        public dlgLogin()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private WriterControl _WriterControl = null;
        /// <summary>
        /// 编辑器控件
        /// </summary>
        public WriterControl WriterControl
        {
            get { return _WriterControl; }
            set { _WriterControl = value; }
        }
        

        private void dlgLogin_Load(object sender, EventArgs e)
        {
            RefreshView();
        }

        private UserLoginInfo _InputUserInfo = null;

        public UserLoginInfo InputUserInfo
        {
            get { return _InputUserInfo; }
            set { _InputUserInfo = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _InputUserInfo = new UserLoginInfo();
            if (rdoZhang.Checked)
            {
                // 设置用户编号 
                _InputUserInfo.ID = "zhang";
                // 设置用户名，可以修改
                _InputUserInfo.Name = "张主任";
                // 设置权限等级：0，小医生：1：中医生；2：大医生。
                _InputUserInfo.PermissionLevel = 2;
                
            }
            else if (rdoLi.Checked)
            {
                _InputUserInfo.ID = "li";
                _InputUserInfo.Name = "李医师";
                _InputUserInfo.PermissionLevel = 1;
                
            }
            else if (rdoWang.Checked)
            {
                _InputUserInfo.ID = "wang";
                _InputUserInfo.Name = "王医师";
                _InputUserInfo.PermissionLevel = 0;
            }
            else if (rdoOther.Checked)
            {
                _InputUserInfo.ID = txtUserID.Text;
                _InputUserInfo.Name = txtName.Text;
                _InputUserInfo.PermissionLevel = Convert.ToInt32(nudLevel.Value);
            }
            else
            {
                MessageBox.Show("请选择一个登录身份");
                return;
            }
            // 设置客户端名称
            _InputUserInfo.ClientName = System.Environment.MachineName;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            //主页面显示
            //FrmMain frm = new FrmMain();
            //frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void RefreshView()
        //{
        //    tabControl1.SelectedIndex = 0;
        //    //string path = System.IO.Path.Combine("../WinFormDemo", "Test");
        //    string soucePath = System.IO.Path.Combine("../WinFormDemo", "dlgLogin" + ".cs");
        //    string sourceCode = null;
        //    if (System.IO.File.Exists(soucePath))
        //    {
        //        using (System.IO.StreamReader reader = new System.IO.StreamReader(soucePath, Encoding.Default, true))
        //        {
        //            sourceCode = reader.ReadToEnd();
        //            if (sourceCode != null)
        //            {
        //                sourceCode = sourceCode.Replace("\t", "    ");
        //            }
        //        }

        //        XtractPro.Text.CSharpSyntaxHighlighter hi =
        //        new XtractPro.Text.CSharpSyntaxHighlighter();
        //        hi.ShowCollapsibleBlocks = false;
        //        hi.ShowComments = true;
        //        hi.ShowHyperlinks = true;
        //        hi.ShowLineNumbers = true;
        //        hi.ShowRtf = true;
        //        hi.AddCssSourceCode = true;
        //        sourceCode = hi.Process(sourceCode);

        //    }
        //    else
        //    {
        //        sourceCode = " can not find file" + soucePath;
        //    }
        //    this.Cursor = Cursors.WaitCursor;
        //    myWebBrowser.DocumentText = "<html><body leftmargin=0 topmargin=0>" + sourceCode + "</body></html>";
        //    this.Cursor = Cursors.Default;
        //}
        private void RefreshView()
        {
            MytabControl.SelectedIndex = 0;
            //string soucePath = System.IO.Path.Combine("../WinFormDemo", "dlgLogin" + ".cs");
            string soucePath = System.IO.Path.Combine(Application.StartupPath, "dlgLogin" + ".cs");
            string sourceCode = null;
            if (System.IO.File.Exists(soucePath))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(soucePath, Encoding.Default, true))
                {
                    sourceCode = reader.ReadToEnd();
                    if (sourceCode != null)
                    {
                        sourceCode = sourceCode.Replace("\t", "    ");
                    }
                }

                XtractPro.Text.CSharpSyntaxHighlighter hi =
                new XtractPro.Text.CSharpSyntaxHighlighter();
                hi.ShowCollapsibleBlocks = false;
                hi.ShowComments = true;
                hi.ShowHyperlinks = true;
                hi.ShowLineNumbers = true;
                hi.ShowRtf = true;
                hi.AddCssSourceCode = true;
                sourceCode = hi.Process(sourceCode);

            }
            else
            {
                sourceCode = " can not find file" + soucePath;
            }
            this.Cursor = Cursors.WaitCursor;
            myWebBrowser.DocumentText = "<html><body leftmargin=0 topmargin=0>" + sourceCode + "</body></html>";
            this.Cursor = Cursors.Default;
        }

        private void picMarkwang_Click(object sender, EventArgs e)
        {

        }

        private void picMarkli_Click(object sender, EventArgs e)
        {

        }

        private void picMarkzhang_Click(object sender, EventArgs e)
        {

        }

        private void rdoOther_CheckedChanged(object sender, EventArgs e)
        {
            txtUserID.Enabled = rdoOther.Checked;
            txtName.Enabled = rdoOther.Checked;
            nudLevel.Enabled = rdoOther.Checked;
        }
    }
}