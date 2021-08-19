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
    public partial class ctlTestMulCourse4 : UserControl
    {
        public ctlTestMulCourse4()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 病程记录文档控制器
        /// </summary>
        private SectionCourseRecordDocumentController _CRController = null;
        private DCSoft.Writer.Controls.TrackListBoxControler _TrackListControler = null;

        private void ctlTestMulCourse3_Load(object sender, EventArgs e)
        {
            myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.False;
            this._TrackListControler = new Writer.Controls.TrackListBoxControler(lstUserTrack, this.myViewControl);
            this._TrackListControler.Start();

            //this.myViewControl.HeaderFooterReadonly = true;
            myViewControl.CommandControler = writerCommandControler1;
            myViewControl.CommandControler.Start();
            this._CRController = new SectionCourseRecordDocumentController();
            this._CRController.ViewControl = myViewControl;
            this._CRController.SetAttributeNameLabelIDMap("病区", "lblArea");
            this._CRController.Start();
            this._CRController.CurrentRecordChanged += new WriterEventHandler(
                _CRController_CurrentRecordChanged);
            this._CRController.BeforeRecordDeleted += new WriterCancelEventHandler(_CRController_BeforeRecordDeleted);
            // 留痕显示模式
            myViewControl.ExecuteCommand(StandardCommandNames.ComplexViewMode, false, true);
            // 启用授权控制
            myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
            // 允许逻辑删除
            myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = true;
            btnRefresh_Click(null, null);
        }

        void _CRController_BeforeRecordDeleted(object eventSender, WriterCancelEventArgs args)
        {
            SectionCourseRecord record = this._CRController.GetRecordByElement(args.Element);
            if (MessageBox.Show(
                this,
                ResourceStrings.PromptDeleteRecord + record.Title + " ?",
                ResourceStrings.SystemAlert,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string fileName = record.FileName;
                // 删除文件
                System.IO.File.Delete(fileName);
            }
            else
            {
                args.Cancel = true;
            }
        }

        void _CRController_CurrentRecordChanged(object sender, WriterEventArgs args)
        {
            SectionCourseRecord record = this._CRController.CurrentRecord;
            if (record == null)
            {
                cboArea.Text = "";
                cboCurrentUser.Text = "";
            }
            else
            {
                cboArea.Text = record.GetDocumentAttributeValue("病区");
                cboCurrentUser.Text = record.Author ;
                foreach (ListViewItem item in lvwRecords.Items)
                {
                    if (item.Tag == record)
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private string _DocumentInfoFileName = null;

        private void RefreshView(string[] fileNames)
        {
            string tempPath = Path.Combine(Application.StartupPath, "DemoFile\\模板-病程记录.xml");
            // 加载框架性的模板
            this._CRController.LoadFrameTemplateByFileName( tempPath );
            // 清空上次显示文档时生成的病区标题信息
            if (fileNames != null && fileNames.Length > 0)
            {
                _DocumentInfoFileName = Path.Combine(Path.GetDirectoryName(fileNames[0]), "info");
                if (this._CRController.GenerateTitleAndMark)
                {
                    _DocumentInfoFileName = _DocumentInfoFileName + ".gen.xml";
                }
                else
                {
                    _DocumentInfoFileName = _DocumentInfoFileName + ".xml";
                }

                if (System.IO.File.Exists(_DocumentInfoFileName))
                {
                    // 加载上一次保存的文档信息
                    using (StreamReader reader = new StreamReader(_DocumentInfoFileName, Encoding.UTF8, true))
                    {
                        string xml = reader.ReadToEnd();
                        this._CRController.LoadDocumentInfoFromXMLString(xml);
                    }
                }
                this._CRController.SetStartFileIndex(0);
                //List<XTextDocument> documents = new List<XTextDocument>();
                //int index = 0;
                for (int iCount = 0; iCount < fileNames.Length; iCount++)
                {
                    string fileName = fileNames[iCount];
                    if (this._CRController.NeedLoadDocumentContent(fileName) == false)
                    {
                        continue;
                    }
                    // 创建临时文档对象
                    XTextDocument document = new XTextDocument();
                    string format = "xml";
                    if (fileName.EndsWith(".rtf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        format = "rtf";
                    }
                    //this.myViewControl.CommentVisibility = Writer.Controls.FunctionControlVisibility.Hide;
                    // 加载病程记录文档到临时文档对象中
                    document.Options = myViewControl.Document.Options;
                    document.Load(fileName, format);
                    // 设置标题
                    document.Info.Title = System.IO.Path.GetFileNameWithoutExtension(fileName);
                        
                    if (document != null && document.Body.HasContentElement)
                    {
                        SectionCourseRecordSource recordSource = new SectionCourseRecordSource();
                        recordSource.Document = document;
                        // 设置第6个文档强制分页
                        recordSource.NewPage = iCount == 6;
                        // 设置某些文档启用授权
                        recordSource.EnablePermission = (iCount % 3)== 0 ;
                        recordSource.FileName = fileName;
                        if (iCount == 2)
                        {
                            // 第二个文档默认就处于编辑状态
                            recordSource.Readonly = false;
                            recordSource.Modified = true;
                        }
                        if (iCount == 4)
                        {
                            recordSource.SpecifyBackgroundCololr = Color.Yellow ;
                        }
                        if (iCount == 5)
                        {
                            recordSource.RecordBorderColor = Color.Red;
                        }
                        else
                        {
                            //recordSource.RecordBorderColor = Color.Transparent;
                        }
                        recordSource.RecordSpacing = 100;
                        // 添加记录
                        this._CRController.AddDocumentFromSourceRecord(recordSource);
                        //documents.Add(document);
                    }
                }//foreach
                // 启用痕迹保留
                this.myViewControl.DocumentOptions.SecurityOptions.EnablePermission = btnUseTrack.Checked;
                this.myViewControl.DocumentOptions.SecurityOptions.EnableLogicDelete = btnUseTrack.Checked;
                this.myViewControl.DocumentOptions.SecurityOptions.ShowLogicDeletedContent = btnUseTrack.Checked;
                this.myViewControl.DocumentOptions.SecurityOptions.ShowPermissionMark = btnUseTrack.Checked;
                this.myViewControl.DocumentOptions.SecurityOptions.ShowPermissionTip = btnUseTrack.Checked;
                this._CRController.RefreshViewWithDocuments();
                
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
            SectionCourseRecordSource recordSource = CreateNewRecordSource();
            this._CRController.AppendNewRecordByRecordSource( recordSource );
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
            SectionCourseRecordSource recordSource = CreateNewRecordSource();
            this._CRController.InsertNewRecordAtCurrentPositionByRecordSource( recordSource , false);
            RefreshRecordsList();
            this.myViewControl.Focus();
        }

        private SectionCourseRecordSource CreateNewRecordSource()
        {
            XTextDocument doc = new XTextDocument();
            doc.Info.Author = cboCurrentUser.Text;
            doc.Info.Title = doc.GetNowDateTime().ToString("病程记录yyyy年MM月dd日 HH时mm分ss秒");
            SectionCourseRecordSource record = new SectionCourseRecordSource();
            record.Document = doc;
            string path = Path.Combine(Application.StartupPath, "DemoFile");
            string fileName = doc.Info.Title + ".xml";
            fileName = Path.Combine(path, fileName);
            doc.FileName = fileName;
            return record;
        }

        private void cboArea_TextChanged(object sender, EventArgs e)
        {
            SectionCourseRecord record = this._CRController.CurrentRecord;
            if (record != null && record.Readonly == false)
            {
                record.SetDocumentAttribute("病区", cboArea.Text);
                this._CRController.RefreshHeaderText();
                record.Modified = true;
            }
        }


        private void cboCurrentUser_TextChanged(object sender, EventArgs e)
        {
            SectionCourseRecord record = this._CRController.CurrentRecord;
            if (record != null && record.Readonly == false)
            {
                record.Author = cboCurrentUser.Text;
                record.Modified = true;
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

        private void myViewControl_SelectionChanged(object sender, WriterEventArgs args)
        {
            btnSave.Enabled = this._CRController.HasModifiedRecord;
            SectionCourseRecord record = this._CRController.CurrentRecord;
            if (record == null)
            {
                btnBeginEdit.Enabled = false;
                cboCurrentUser.Enabled = false;
                cboArea.Enabled = false;
            }
            else
            {
                btnBeginEdit.Enabled = record.Readonly;
                cboCurrentUser.Enabled = record.Readonly == false;
                cboArea.Enabled = record.Readonly == false;
            }

            // 当文档当前位置发生改变时设置当前列表项目
            //this._TrackListControler.HandleWriterControlSelectionChanged();

        }

        private void btnBeginEdit_Click(object sender, EventArgs e)
        {
            this._CRController.EditCurrentRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 获得需要保存的文档对象
            List<XTextDocument> documents = new List<XTextDocument>();
            this.myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
            foreach (SectionCourseRecord record in this._CRController.Records)
            {
                if (record.Modified)
                {
                    XTextDocument doc = record.CreateRecordDocument();
                    doc.SaveToFile(doc.FileName, doc.FileFormat);
                    record.Modified = false;
                    record.Readonly = true;
                }
            }
            // 保存文档信息对象
            string xml = this._CRController.SaveDocumentInfoToXMLString();
            using (System.IO.StreamWriter writer = new StreamWriter(_DocumentInfoFileName, false, Encoding.UTF8))
            {
                writer.Write(xml);
            }
            // 清空撤销操作信息列表
            this.myViewControl.ExecuteCommand(StandardCommandNames.ClearUndo, false, null);
        }

        private void RefreshRecordsList()
        {
            lvwRecords.Items.Clear();
            for (int iCount = 0; iCount < this._CRController.RecordCount; iCount++)
            {
                SectionCourseRecord record = this._CRController.GetRecord(iCount);
                ListViewItem item = new ListViewItem(record.Title);
                item.Tag = record;
                lvwRecords.Items.Add(item);
            }
        }

        private void lvwRecords_Click(object sender, EventArgs e)
        {
            if (lvwRecords.SelectedItems.Count > 0)
            {
                SectionCourseRecord record = (SectionCourseRecord)lvwRecords.SelectedItems[0].Tag;
                if (record != null)
                {
                    record.IsCurrent = true;
                    this.myViewControl.Focus();
                }
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (this._CRController.DeleteCurrentRecord())
            {
                RefreshRecordsList();
            }
        }

        private void mRefreshGenerateTitle_Click(object sender, EventArgs e)
        {
            this._CRController.GenerateTitleAndMark = true;

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

        private void mRefreshNoGenerateTitle_Click(object sender, EventArgs e)
        {
            this._CRController.GenerateTitleAndMark = false;

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