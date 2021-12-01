using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DCSoft.Writer.Dom;
using DCSoft.Printing;
using DCSoft.Writer.Extension;
using DCSoft.Writer.Data;
using DCSoft.Writer;

namespace DCSoft.Writer.WinFormDemo.Test.CourseRecord
{
    [ToolboxItem(false)]
    public partial class ctlTestSubDocument : UserControl
    {
        public ctlTestSubDocument()
        {
            InitializeComponent();
        }

        private DCSoft.Writer.Controls.TrackListBoxControler _TrackListControler = null;

        private void ctlTestMulCourse3_Load(object sender, EventArgs e)
        {

            myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.False;


            // 留痕显示模式
            myViewControl.ExecuteCommand(StandardCommandNames.ComplexViewMode, false, true);
            // 启用授权控制
            myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
            // 允许逻辑删除
            myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
            myViewControl.CommandControler = this.writerCommandControler1;
            myViewControl.CommandControler.Start();
        }

        /// <summary>
        /// 在最后面添加一个新的病程记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = CreateNewSubDocument();
            this.myViewControl.AppendSubDocument(subdoc);
            RefreshRecordsList();
            this.myViewControl.Focus();
        }


        /// <summary>
        /// 在当前病程记录上面插入新的病程记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertRecord_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subDoc = CreateNewSubDocument();
            this.myViewControl.InsertSubDocuentAtCurrentPosition(subDoc, false);
            RefreshRecordsList();
            this.myViewControl.Focus();
        }

        private XTextSubDocumentElement CreateNewSubDocument()
        {
            XTextSubDocumentElement doc = new XTextSubDocumentElement();
            doc.EnableCollapse = btnEnableCollapse.Checked;
            doc.OwnerDocument = this.myViewControl.Document;
            doc.DocumentInfo.Author = System.Environment.UserName;
            doc.DocumentInfo.Title = DateTime.Now.ToString("病程记录yyyy年MM月dd日 HH时mm分ss秒");
            doc.ID = doc.Title;
            doc.SetInnerTextFast("这是一段新的病程记录");
            // 新文档不启用权限
            doc.EnablePermission = DCBooleanValue.False;
            // 新文档是不只读的
            doc.ContentReadonly = ContentReadonlyState.False;
            // 打印时背景透明
            doc.Style.PrintBackColor = Color.Transparent;
            // 设置新的文件名
            string path = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容");
            string fileName = doc.DocumentInfo.Title + ".xml";
            fileName = Path.Combine(path, fileName);
            doc.FileName = fileName;
            return doc;
        }

        private void btnLoadSpecifyFile_Click(object sender, EventArgs e)
        {
            this.myViewControl.Document.Body.Elements.Clear();
            this.myViewControl.PageSettings.Landscape = false;
            int tick = System.Environment.TickCount;
            string[] fileNames = null;

            // 加载框架模版
            string tempPath = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容\\模板-病程记录.xml");
            this.myViewControl.LoadDocumentFromFile(tempPath, null);
            fileNames = Directory.GetFiles(Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容"), "病程记录*.xml");
            for (int i = 0; i < Convert.ToInt32(toolStripTextBox1.Text); i++)
            {
                // 清空正文内容
                //myViewControl.Document.Body.Elements.Clear();
                for (int iCount = 0; iCount < fileNames.Length; iCount++)
                {
                    string fileName = fileNames[iCount];
                    XTextSubDocumentElement subDoc = new XTextSubDocumentElement();
                    subDoc.EnableCollapse = btnEnableCollapse.Checked;
                    subDoc.IsCollapsed = true;
                    subDoc.OwnerDocument = myViewControl.Document;
                    subDoc.LoadDocumentFromFileName(fileName, "xml");
                    subDoc.Title = System.IO.Path.GetFileNameWithoutExtension(fileName);
                    subDoc.Style.BorderLeft = true;
                    subDoc.Style.BorderTop = true;
                    subDoc.Style.BorderRight = true;
                    subDoc.Style.BorderBottom = true;
                    subDoc.Style.BorderWidth = 1;
                    subDoc.Style.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    subDoc.Style.BorderColor = Color.Gray;
                    subDoc.Style.PrintBackColor = Color.Transparent;
                    if ((iCount % 4) == 0)
                    {
                        // 内容可修改
                        subDoc.Style.BackgroundColor = Color.Transparent;
                        subDoc.ContentReadonly = ContentReadonlyState.False;
                    }
                    else
                    {
                        // 内容只读
                        subDoc.Style.BackgroundColor = Color.LightGray;
                        subDoc.ContentReadonly = ContentReadonlyState.True;
                    }
                    if ((iCount % 3) == 0)
                    {
                        // 启用授权控制
                        subDoc.EnablePermission = DCBooleanValue.True;
                    }
                    if (iCount == 6)
                    {
                        // 强制分页
                        subDoc.NewPage = true;
                    }
                    // 添加子文档元素对象
                    myViewControl.Document.Body.AppendChildElement(subDoc);

                }//for
            }

            // 刷新文档
            myViewControl.RefreshDocument();
            int tick2 = System.Environment.TickCount - tick;
            // 刷新子文档列表
            RefreshRecordsList();
          //  MessageBox.Show("耗时：" + tick2.ToString() + "毫秒");
        }

        private void myViewControl_SelectionChanged(object sender, WriterEventArgs args)
        {
            btnSave.Enabled = this.myViewControl.Modified;
            XTextSubDocumentElement subdoc = this.myViewControl.CurrentSubDocument;
            if (subdoc != null)
            {
                foreach (ListViewItem item in lvwRecords.Items)
                {
                    if (item.Tag == subdoc)
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
            }
        }

        private void btnBeginEdit_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.CurrentSubDocument;
            if (subdoc != null)
            {
                subdoc.Focus();
                subdoc.EditorSetState(false, Color.Transparent, Color.Gray);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 获得需要保存的文档对象
            List<XTextDocument> documents = new List<XTextDocument>();
            this.myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
            foreach (XTextSubDocumentElement subDoc in this.myViewControl.SubDocuments)
            {
                if (subDoc.Modified)
                {
                    // 只有文件修改了才保存
                    subDoc.SaveDocumentToFileName(subDoc.FileName, subDoc.FileFormat);
                    subDoc.Modified = false;
                    subDoc.EditorSetState(true, Color.LightGray, Color.FromArgb(200, 200, 200));
                }
            }

            // 清空撤销操作信息列表
            this.myViewControl.ExecuteCommand(StandardCommandNames.ClearUndo, false, null);
        }

        private void RefreshRecordsList()
        {
            lvwRecords.Items.Clear();
            foreach (XTextSubDocumentElement subdoc in this.myViewControl.SubDocuments)
            {
                string title = subdoc.Title;
                if (string.IsNullOrEmpty(title))
                {
                    title = System.IO.Path.GetFileNameWithoutExtension(subdoc.FileName);
                }
                ListViewItem item = new ListViewItem(title);
                item.Tag = subdoc;
                lvwRecords.Items.Add(item);
            }
        }

        private void lvwRecords_Click(object sender, EventArgs e)
        {
            if (lvwRecords.SelectedItems.Count > 0)
            {
                XTextSubDocumentElement record = (XTextSubDocumentElement)lvwRecords.SelectedItems[0].Tag;
                if (record != null)
                {
                    record.Focus();
                    record.SelectFirstLine();
                    this.myViewControl.Focus();
                    this.myViewControl.ScrollToCaretExt(WinForms.ScrollToViewStyle.Top);
                }
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.CurrentSubDocument;
            if (subdoc != null && subdoc.Locked == false)
            {
                if (MessageBox.Show(
                    this,
                    ResourceStrings.PromptDeleteRecord + subdoc.Title + " ?",
                    ResourceStrings.SystemAlert,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string fileName = subdoc.FileName;
                    // 删除文件
                    System.IO.File.Delete(fileName);
                    subdoc.EditorDelete(false);
                    RefreshRecordsList();
                }
            }
        }


        private void btnRefreshTrackList_Click(object sender, EventArgs e)
        {
            // 刷新用户痕迹列表内容
            this._TrackListControler.Refresh();
        }

        private void myViewControl_DocumentContentChanged(object eventSender, WriterEventArgs args)
        {
            // 当文档导航内容发生改变时刷新用户痕迹列表内容
        }

        private void btnUseTrack_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.CurrentSubDocument;
            if (subdoc != null && subdoc.Locked == false)
            {
                subdoc.EnablePermission = DCBooleanValue.True;//启用痕迹

                DCSoft.Writer.Security.UserLoginInfo usr = new DCSoft.Writer.Security.UserLoginInfo();
                usr.ID = "DR.ZHANG";
                usr.Name = "张医生";
                //设置权限等级：大于等于0的整数，整数越大权限越大。
                usr.PermissionLevel = 3;

                myViewControl.UserLogin(usr, true);
                myViewControl.ExecuteCommand(StandardCommandNames.ComplexViewMode, false, null);
                myViewControl.Document.Options.SecurityOptions.EnablePermission = true;
                myViewControl.Document.Options.SecurityOptions.EnableLogicDelete = true;
                myViewControl.Document.Options.SecurityOptions.ShowLogicDeletedContent = true;
                myViewControl.Document.Options.SecurityOptions.ShowPermissionMark = true;
                myViewControl.Document.Options.SecurityOptions.ShowPermissionTip = true;
            }
            myViewControl.RefreshDocument();
            //if (btnUseTrack.Checked)
            //{
            //    CurrentUserInfo usr = new CurrentUserInfo();
            //    usr.ID = "zhangsan";
            //    usr.Name = "张三";
            //    usr.PermissionLevel = 1;
            //    myViewControl.ExecuteCommand(StandardCommandNames.SetAutoLogin, false, usr);
            //    myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
            //    myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
            //    myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = true;
            //    myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = true;
            //    myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = true;
            //}
            //else
            //{
            //    myViewControl.DocumentOptions.SecurityOptions.EnablePermission = false;
            //    myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = false ;
            //    myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = false ;
            //    myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = false ;
            //    myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = false ;
            //}
            //myViewControl.RefreshDocument();
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            using (DCSoft.Writer.WinFormDemo.dlgLogin dlg = new dlgLogin())
            {
                dlg.WriterControl = this.myViewControl;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    myViewControl.UserLoginByParameter(
                        dlg.InputUserInfo.ID,
                        dlg.InputUserInfo.Name,
                        dlg.InputUserInfo.PermissionLevel);
                    myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
                    myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
                    myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = true;
                    myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = true;
                    myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = true;
                }
            }
            myViewControl.RefreshDocument();
        }

        private void btnDisablePermission_Click(object sender, EventArgs e)
        {
            //myViewControl.DocumentOptions.SecurityOptions.EnablePermission = false;
            XTextSubDocumentElement subdoc = this.myViewControl.CurrentSubDocument;
            if (subdoc != null && subdoc.Locked == false)
            {
                subdoc.EnablePermission = DCBooleanValue.False;//启用痕迹
            }
            myViewControl.DocumentOptions.SecurityOptions.EnablePermission = false;
            myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = false;
            myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = false;
            myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = false;
            myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = false;
            myViewControl.RefreshDocument();
        }

        private void btnEnableCollapse_Click(object sender, EventArgs e)
        {
            myViewControl.DocumentOptions.BehaviorOptions.EnableCollapseSection = btnEnableCollapse.Checked;
            foreach (XTextSectionElement sec in myViewControl.Document.Sections)
            {
                sec.EnableCollapse = btnEnableCollapse.Checked;
            }
            myViewControl.RefreshDocument();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容\\病程记录2013年02月13日 12时01分03秒.xml");
            int tick = System.Environment.TickCount;
            for (int i = 0; i < Convert.ToInt32(toolStripTextBox1.Text); i++)
            {
                XTextSubDocumentElement subdoc = CreateNewSubDocument();
                //subdoc.OwnerDocument = myViewControl.Document;
                subdoc.LoadDocumentFromFileName(fileName, null);
                this.myViewControl.AppendSubDocument(subdoc);
            }
            RefreshRecordsList();
            this.myViewControl.Focus();
            int tick2 = System.Environment.TickCount - tick;
            MessageBox.Show(tick2.ToString());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string[] fileNames = Directory.GetFiles(Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容"), "表格*.xml");
            this.myViewControl.LoadDocumentFromFile(fileNames[0], "xml");
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            this.myViewControl.PageSettings.Landscape = true;
            string[] fileNames = Directory.GetFiles(Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容"), "表格*.xml");
            this.myViewControl.Document.LoadUseAppendModeFromFileName(fileNames[0], "xml");
            this.myViewControl.RefreshDocument();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            int tick = System.Environment.TickCount;
            XTextSubDocumentElement subDoc = new XTextSubDocumentElement();
            subDoc.OwnerDocument = this.myViewControl.Document;

            string tempPath = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容\\TestTime.xml");

            subDoc.LoadDocumentFromFileName(tempPath, null);


            this.myViewControl.LoadDocumentFromFile(tempPath, "xml");
            this.myViewControl.Document.Body.AppendChildElement(subDoc);
            int tick2 = System.Environment.TickCount - tick;
            //  myViewControl.RefreshDocument();
            MessageBox.Show("耗时：" + tick2.ToString() + "毫秒");
        }

        private void toolStripButton19_Click_1(object sender, EventArgs e)
        {
            string tempPath = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容\\TestTime.xml");
            int tick = System.Environment.TickCount;
            this.myViewControl.LoadDocumentFromFile(tempPath, "xml");

            int tick2 = System.Environment.TickCount - tick;
            //  myViewControl.RefreshDocument();
            MessageBox.Show("耗时：" + tick2.ToString() + "毫秒");
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            if (toolStripButton24.Checked)
                this.myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.True;
            else
                this.myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.False;
        }

    }
}