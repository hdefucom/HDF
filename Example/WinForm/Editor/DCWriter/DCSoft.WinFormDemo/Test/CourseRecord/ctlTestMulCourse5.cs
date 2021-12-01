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
    public partial class ctlTestMulCourse5 : UserControl
    {
        public ctlTestMulCourse5()
        {
            InitializeComponent();
        }
 
        private DCSoft.Writer.Controls.TrackListBoxControler _TrackListControler = null;

        private void ctlTestMulCourse3_Load(object sender, EventArgs e)
        {
            myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.False;
            this._TrackListControler = new Writer.Controls.TrackListBoxControler(lstUserTrack, this.myViewControl);
            this._TrackListControler.Start();
           
            
            // 留痕显示模式
            myViewControl.ExecuteCommand(StandardCommandNames.ComplexViewMode, false, true);
            // 启用授权控制
            myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
            // 允许逻辑删除
            myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
            btnRefresh_Click(null, null);
            myViewControl.CommandControler = this.writerCommandControler1;
            myViewControl.CommandControler.Start();
        }
         
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private string _DocumentInfoFileName = null;

        private void RefreshView(string[] fileNames)
        {
            // 加载框架模版
            string tempPath = Path.Combine(Application.StartupPath, "DemoFile\\模板-病程记录.xml");
            this.myViewControl.LoadDocumentFromFile(tempPath, null);
            XTextLabelElement lbl = (XTextLabelElement)this.myViewControl.GetElementById("lblArea");
            if (lbl != null)
            {
                lbl.AttributeNameForContactAction = "病区";
            }
            // 清空上次显示文档时生成的病区标题信息
            if (fileNames != null && fileNames.Length > 0)
            {

                //List<XTextDocument> documents = new List<XTextDocument>();
                //int index = 0;
                for (int iCount = 0; iCount < fileNames.Length; iCount++)
                {
                    string fileName = fileNames[iCount];
                    // 创建临时文档对象
                    XTextDocument document = new XTextDocument();
                    string format = "xml";
                    if (fileName.EndsWith(".rtf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        format = "rtf";
                    }
                    XTextSubDocumentElement subDoc = new XTextSubDocumentElement();
                    subDoc.OwnerDocument = this.myViewControl.Document;
                 
                    subDoc.LoadDocumentFromFileName(fileName, format);
                    subDoc.DocumentInfo.Title = System.IO.Path.GetFileNameWithoutExtension(fileName);
                    subDoc.ID = subDoc.DocumentInfo.Title;
                    if (subDoc.HasContentElement)
                    {
                        // 设置第6个文档强制分页
                        subDoc.NewPage = iCount == 6;
                        // 设置某些文档启用授权
                        subDoc.EnablePermission = (iCount % 3) == 0 ? DCBooleanValue.True : DCBooleanValue.False ;
                        Color borderColor = Color.FromArgb(200, 200, 200);
                        if (iCount == 2)
                        {
                            // 第二个文档默认就处于编辑状态
                            subDoc.EditorSetState(false, Color.Transparent, Color.Red);
                            subDoc.Modified = true;
                        }
                        if (iCount == 4)
                        {
                            subDoc.EditorSetState(true, Color.Yellow, borderColor);
                        }
                        if (iCount == 5)
                        {
                            subDoc.EditorSetState(true, Color.Transparent, Color.Red);
                        }
                        else
                        {
                            subDoc.EditorSetState(true, Color.Transparent, borderColor);
                            //recordSource.RecordBorderColor = Color.Transparent;
                        }
                        //subDoc.RecordSpacing = 100;
                    }
                    myViewControl.Document.Body.AppendContentElement(subDoc);

                }//foreach
                // 启用痕迹保留
                this.myViewControl.DocumentOptions.SecurityOptions.EnablePermission = btnUseTrack.Checked;
                this.myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = btnUseTrack.Checked;
                this.myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = btnUseTrack.Checked;
                this.myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = btnUseTrack.Checked;
                this.myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = btnUseTrack.Checked;
                this.myViewControl.RefreshDocument();

                RefreshRecordsList();

                //if( documents.Count > 0 )
                //{
                //    this._CRController.RefreshView( documents.ToArray());
                //    RefreshRecordsList();
                //}
            }
        }

        /// <summary>
        /// 在最后面添加一个新的病程记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = CreateNewSubDocument();
            this.myViewControl.Document.AppendSubDocument(subdoc);
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
            this.myViewControl.Document.InsertSubDocuentAtCurrentPosition(subDoc, false);
            RefreshRecordsList();
            this.myViewControl.Focus();
        }

        private XTextSubDocumentElement CreateNewSubDocument()
        {
            XTextSubDocumentElement doc = new XTextSubDocumentElement();
            doc.DocumentInfo.Author = cboCurrentUser.Text;
            doc.DocumentInfo.Title = DateTime.Now.ToString("病程记录yyyy年MM月dd日 HH时mm分ss秒");
            doc.ID = doc.Title;
            doc.SetInnerTextFast("这是一段新的病程记录");
            string path = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容");
            string fileName = doc.DocumentInfo.Title + ".xml";
            fileName = Path.Combine(path, fileName);
            doc.FileName = fileName;
            return doc;
        }

        private void cboArea_TextChanged(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.Document.CurrentSubDocument;
            if (subdoc != null)
            {
                subdoc.SetAttribute("病区", cboArea.Text);
                this.myViewControl.Document.RefreshLabelContactString();
                subdoc.Modified = true;
                this.myViewControl.Document.Modified = true;
            }
        }


        private void cboCurrentUser_TextChanged(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.Document.CurrentSubDocument;
            if (subdoc != null)
            {
                subdoc.DocumentInfo.Author = cboCurrentUser.Text;
                subdoc.Modified = true;
                this.myViewControl.Document.Modified = true;
            }
        }

        private void btnLoadSpecifyFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Multiselect = true;
                dlg.Filter = "*.xml;*.rtf|*.xml;*.rtf";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshView(dlg.FileNames);
                    btnBeginEdit.Enabled = false;
                    btnAddNewRecord.Enabled = false;
                }
            }
        }

        private XTextSubDocumentElement lastRecord = null;
        private void myViewControl_SelectionChanged(object sender, WriterEventArgs args)
        {
            btnSave.Enabled = this.myViewControl.Document.Modified;
            XTextSubDocumentElement subdoc = this.myViewControl.Document.CurrentSubDocument;
            if (subdoc == null)
            {
                btnBeginEdit.Enabled = false;
                cboCurrentUser.Enabled = false;
                cboArea.Enabled = false;
            }
            else
            {
                btnBeginEdit.Enabled = subdoc.ContentReadonly == ContentReadonlyState.True;
                cboCurrentUser.Enabled = subdoc.ContentReadonly != ContentReadonlyState.True;
                cboArea.Enabled = subdoc.ContentReadonly != ContentReadonlyState.True;
            }
            if (subdoc != lastRecord)
            {
                lastRecord = subdoc;

                if (subdoc == null)
                {
                    cboArea.Text = "";
                    cboCurrentUser.Text = "";
                }
                else
                {
                    cboArea.Text = subdoc.GetAttribute("病区");
                    cboCurrentUser.Text = subdoc.DocumentInfo.Author;
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
            // 当文档当前位置发生改变时设置当前列表项目
            //this._TrackListControler.HandleWriterControlSelectionChanged();

        }

        private void btnBeginEdit_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.Document.CurrentSubDocument;
            if (subdoc != null)
            {
                subdoc.Focus();
                subdoc.EditorSetState(false, Color.Transparent, Color.Transparent);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 获得需要保存的文档对象
            List<XTextDocument> documents = new List<XTextDocument>();
            this.myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
            foreach (XTextSubDocumentElement record in this.myViewControl.Document.SubDocuments)
            {
                if (record.Modified)
                {
                    record.SaveDocumentToFileName(record.FileName, record.FileFormat);
                    record.Modified = false;
                    record.EditorSetState(true, Color.LightGray, Color.FromArgb( 200,200,200));
                }
            }
              
            // 清空撤销操作信息列表
            this.myViewControl.ExecuteCommand(StandardCommandNames.ClearUndo, false, null);
        }

        private void RefreshRecordsList()
        {
            lvwRecords.Items.Clear();
            foreach( XTextSubDocumentElement subdoc in this.myViewControl.Document.SubDocuments )
            {
                ListViewItem item = new ListViewItem( subdoc.Title );
                item.Tag = subdoc ;
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
            XTextSubDocumentElement subdoc = this.myViewControl.Document.CurrentSubDocument;
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

        private void mRefreshGenerateTitle_Click(object sender, EventArgs e)
        {
            //this._CRController.GenerateTitleAndMark = true;

            //btnBeginEdit.Enabled = true;
            //btnAddNewRecord.Enabled = true;

            //string path = Path.Combine(Application.StartupPath, "DemoFile");
            //string[] fns = Directory.GetFiles(path, "病程记录内容\\病程记录*.xml");
            //if (fns.Length > 0)
            //{
            //    List<string> fileNames = new List<string>();
            //    fileNames.AddRange(fns);
            //    fileNames.Sort();
            //    RefreshView(fileNames.ToArray());
            //}
        }

        private void mRefreshNoGenerateTitle_Click(object sender, EventArgs e)
        {
           // this._CRController.GenerateTitleAndMark = false;

            btnBeginEdit.Enabled = true;
            btnAddNewRecord.Enabled = true;
            string path = Path.Combine(Application.StartupPath, "DemoFile");
            string[] fns = Directory.GetFiles(path, "病程记录内容\\病程记录*.xml");
            if (fns.Length > 0)
            {
                List<string> fileNames = new List<string>();
                fileNames.AddRange(fns);
                fileNames.Sort();
                RefreshView(fileNames.ToArray());
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
            this._TrackListControler.Refresh();
        }

        private void btnUseTrack_Click(object sender, EventArgs e)
        {
            if (btnUseTrack.Checked)
            {
                CurrentUserInfo usr = new CurrentUserInfo();
                usr.ID = "zhangsan";
                usr.Name = "张三";
                usr.PermissionLevel = 1;
                myViewControl.ExecuteCommand(StandardCommandNames.SetAutoLogin, false, usr);
                myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
                myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
                myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = true;
                myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = true;
                myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = true;
            }
            else
            {
                myViewControl.DocumentOptions.SecurityOptions.EnablePermission = false;
                myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = false ;
                myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = false ;
                myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = false ;
                myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = false ;
            }
            myViewControl.RefreshDocument();
        }

        private void btnUserLogin_Click(object sender, EventArgs e)
        {
            using (DCSoft.Writer.WinFormDemo.dlgLogin dlg = new dlgLogin())
            {
                dlg.WriterControl = this.myViewControl;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    myViewControl.UserLogin();
                    myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
                    myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
                    myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = true;
                    myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = true;
                    myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = true;
                }
            }
        }

        private void btnDisablePermission_Click(object sender, EventArgs e)
        {
            myViewControl.DocumentOptions.SecurityOptions.EnablePermission = false;
        }
    }
}