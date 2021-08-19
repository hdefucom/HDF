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

namespace DCSoft.Writer.WinFormDemo.Test.CourseRecord
{
    [ToolboxItem(false)]
    public partial class ctlTestMulCourse3 : UserControl
    {
        public ctlTestMulCourse3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 病程记录文档控制器
        /// </summary>
        private CourseRecordDocumentController _CRController = null;

        private void ctlTestMulCourse3_Load(object sender, EventArgs e)
        {
            myViewControl.CommandControler = writerCommandControler1;
            myViewControl.CommandControler.Start();
            this._CRController = new CourseRecordDocumentController();
            this._CRController.ViewControl = myViewControl;
            this._CRController.SetAttributeNameLabelIDMap("病区", "lblArea");
            this._CRController.Start();
            this._CRController.CurrentRecordChanged += new WriterEventHandler(
                _CRController_CurrentSectionChanged);
            this._CRController.BeforeRecordDeleted += new WriterCancelEventHandler(_CRController_BeforeRecordDeleted);
            btnRefresh_Click(null, null);
        }

        void _CRController_BeforeRecordDeleted(object eventSender, WriterCancelEventArgs args)
        {
            XTextContainerElement c = (XTextContainerElement)args.Element;
            string title = c.Attributes.GetValue(_CRController.TitleAttributeName);
            if (MessageBox.Show(this, "是否删除记录 " + title + " ?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string fileName = c.Attributes.GetValue(_CRController.FileNameAttributeName);
                // 删除文件
                System.IO.File.Delete(fileName);
            }
            else
            {
                args.Cancel = true;
            }
        }

        void _CRController_CurrentSectionChanged(object sender, WriterEventArgs args)
        {
            XTextContainerElement field = this._CRController.CurrentContentContainerElement;
            if (field == null)
            {
                cboArea.Text = "";
                cboCurrentUser.Text = "";
            }
            else
            {
                cboArea.Text = field.Attributes.GetValue("病区");
                cboCurrentUser.Text = field.Attributes.GetValue(this._CRController.AuthorNameAttributeName);
                foreach (ListViewItem item in lvwRecords.Items)
                {
                    if (item.Tag == field)
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
            btnBeginEdit.Enabled = true;
            btnAddNewRecord.Enabled = true;

            string path = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容");
            //myViewControl.ExecuteCommand("FileOpen", false, path + "\\模板-病程记录.xml");
            string[] fns = Directory.GetFiles(path, "病程记录*.xml");
            if (fns.Length > 0)
            {
                //int selectStart = myViewControl.Document.Selection.AbsStartIndex;
                //myWriterControl.Document.Clear();
                List<string> fileNames = new List<string>();
                fileNames.AddRange(fns);
                fileNames.Sort();
                RefreshView(fileNames.ToArray());
            }
        }

        private void RefreshView(string[] fileNames)
        {
            string path = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容");
            myViewControl.ExecuteCommand("FileOpen", false, path + "\\模板-病程记录.xml");
            // 清空上次显示文档时生成的病区标题信息
            if (fileNames != null && fileNames.Length > 0)
            {
                List<XTextDocument> documents = new List<XTextDocument>();
                foreach (string fileName in fileNames)
                {
                    // 创建临时文档对象
                    XTextDocument document = new XTextDocument();
                    string format = "xml";
                    if (fileName.EndsWith(".rtf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        format = "rtf";
                    }
                    // 加载病程记录文档到临时文档对象中
                    myViewControl.Document.LoadDocumentInstance(fileName, format, document);
                    if (document != null && document.Body.HasContentElement)
                    {
                        document.Info.Title = System.IO.Path.GetFileNameWithoutExtension(fileName);
                        documents.Add(document);
                    }
                }//foreach
                if (documents.Count > 0)
                {
                    this._CRController.RefreshView(documents.ToArray());
                    RefreshRecordsList();
                }
            }
        }

        /// <summary>
        /// 在最后面添加一个新的病程记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            XTextDocument doc = NewDocument();
            this._CRController.AppendNewRecord(doc);
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
            XTextDocument doc = NewDocument();
            this._CRController.InsertNewRecordAtCurrentPosition(doc, false);
            RefreshRecordsList();
            this.myViewControl.Focus();
        }

        private XTextDocument NewDocument()
        {
            XTextDocument doc = new XTextDocument();
            string title = doc.GetNowDateTime().ToString("病程记录yyyy年MM月dd日 HH时mm分ss秒");
            string path = Path.Combine(Application.StartupPath, "DemoFile");
            string fileName = title + ".xml";
            fileName = Path.Combine(path, fileName);
            doc.Info.Title = title;
            doc.FileName = fileName;
            return doc;
        }

        private void cboArea_TextChanged(object sender, EventArgs e)
        {
            if (this._CRController.CanEditCurrentRecord)
            {
                this._CRController.CurrentContentContainerElement.Attributes.SetValue("病区", cboArea.Text);
                this._CRController.RefreshHeaderText();
                this._CRController.CurrentContentContainerElement.UpdateContentVersion();
            }
        }


        private void cboCurrentUser_TextChanged(object sender, EventArgs e)
        {
            if (this._CRController.CanEditCurrentRecord)
            {
                this._CRController.CurrentContentContainerElement.Attributes.SetValue(
                    this._CRController.AuthorNameAttributeName,
                    cboCurrentUser.Text);
                this._CRController.CurrentContentContainerElement.UpdateContentVersion();
            }
        }

        private void btnLoadSpecifyFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Multiselect = true;
                dlg.Filter = "XML文件,RTF文件|*.xml;*.rtf";
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
            //btnBeginEdit.Enabled = !this._CRController.CanEditCurrentRecord;
            btnSave.Enabled = !btnBeginEdit.Enabled;
            cboCurrentUser.Enabled = btnSave.Enabled;
            cboArea.Enabled = btnSave.Enabled;

        }

        private void btnBeginEdit_Click(object sender, EventArgs e)
        {
            this._CRController.EditCurrentRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 获得需要保存的文档对象
            XTextDocument[] documents = this._CRController.GetModifiedDocuments();
            if (documents != null && documents.Length > 0)
            {
                foreach (XTextDocument document in documents)
                {
                    // 挨个保存文件
                    document.Save(document.FileName, document.FileFormat);
                }
                // 所有的文件保存成功，清除文档修改标记
                this._CRController.ClearModifiedFlags();
            }
        }

        private void RefreshRecordsList()
        {
            lvwRecords.Items.Clear();
            XTextContainerElement[] containers = this._CRController.GetAllContentField(false);
            foreach (XTextContainerElement c in containers)
            {
                ListViewItem item = new ListViewItem(c.Attributes.GetValue(this._CRController.TitleAttributeName));
                item.Tag = c;
                lvwRecords.Items.Add(item);
            }
        }

        private void lvwRecords_Click(object sender, EventArgs e)
        {
            if (lvwRecords.SelectedItems.Count > 0)
            {
                XTextContainerElement c = (XTextContainerElement)lvwRecords.SelectedItems[0].Tag;
                if (c != null)
                {
                    c.Focus();
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
    }
}