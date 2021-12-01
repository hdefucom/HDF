using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System.IO;
using System.Data.OleDb;
using DCSoft.Drawing;

namespace DCSoft.Writer.WinFormDemo.Test.CourseRecord
{
    public partial class ctlTestMulCourse6 : UserControl
    {
        public ctlTestMulCourse6()
        {
            InitializeComponent();
        }
        public ListItemCollection list = null;
        public DateTime SubDocumentTime = DateTime.Now;
        public string SubDocumentType = "";
        public string SubDocumentSign = "";

        DateTimePicker dtp1 = new DateTimePicker();
        DateTimePicker dtp2 = new DateTimePicker();
        DateTime d = new DateTime();
        CheckBox cbox = new CheckBox();
        float _JumpPrintPosition = 0;
        private void ctlTestMulCourse6_Load(object sender, EventArgs e)
        {
            this.myViewControl.CommandControler = this.writerCommandControler1;
            this.myViewControl.CommandControler.Start();
            myViewControl.Document.Body.Elements.Clear();//清除开头换行回车的style
            ToolStripControlHost tsc = new ToolStripControlHost(dtp1);
            dtp1.Value = DateTime.Now.AddYears(-1);
            dtp1.Width = 130;
            this.toolStrip1.Items.Insert(1, tsc);
            dtp2.Value = DateTime.Now.AddDays(1);
            tsc = new ToolStripControlHost(dtp2);
            dtp2.Width = 130;
            this.toolStrip1.Items.Insert(3, tsc);
            tsc = new ToolStripControlHost(cbox);
            cbox.Text = "保留续打位置";
            tsc.Width = 130;
            // this.toolStrip1.Items.Insert(5, new ToolStripSeparator());
            this.toolStrip1.Items.Insert(6, tsc);
            toolStripButton29.Checked = true;
            this.myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.True;
        }

        private void StartQuery_Click(object sender, EventArgs e)
        {
            using (IDbConnection conn = Utils.CreateConnection())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    //加载页眉页脚模板
                    cmd.CommandText = "Select TemplateContent From  CourseRecordTemplate ";
                    IDataReader reader = cmd.ExecuteReader();
                    list = new ListItemCollection();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = Convert.ToString(reader.GetValue(0));
                        item.Value = item.Text;
                        list.Add(item);
                    }
                    reader.Close();
                    this.myViewControl.LoadDocumentFromString(list[0].Text, null);
                    // 清空正文内容
                    myViewControl.Document.Body.Elements.Clear();
                    //加载病程记录
                    cmd.CommandText = "Select RecordContent,RecordDate,RecordID,RecordMark From  CourseRecord ";
                    reader = cmd.ExecuteReader();
                    list = new ListItemCollection();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = Convert.ToString(reader.GetValue(0));
                        item.Text2 = Convert.ToString(reader.GetValue(1));
                        item.Tag = Convert.ToString(reader.GetValue(2));
                        item.SpellCode = Convert.ToString(reader.GetValue(3)); ;
                        item.Value = item.Text;
                        list.Add(item);
                    }
                    reader.Close();

                    for (int iCount = 0; iCount < list.Count; iCount++)
                    {
                        if (DateTime.TryParse(list[iCount].Text2, out d) == true && Convert.ToDateTime(list[iCount].Text2) >= dtp1.Value && Convert.ToDateTime(list[iCount].Text2) <= dtp2.Value)
                        {
                            string fileName = list[iCount].Text;
                            XTextSubDocumentElement subDoc = new XTextSubDocumentElement();
                            subDoc.EnableCollapse = false;
                            subDoc.IsCollapsed = true;
                            subDoc.Style.BackgroundColor = Color.LightGray;
                            subDoc.ContentReadonly = ContentReadonlyState.True; ;
                            subDoc.OwnerDocument = myViewControl.Document;
                            subDoc.LoadDocumentFromString(fileName, null);
                            subDoc.Title = list[iCount].SpellCode;
                            subDoc.Style.BorderLeft = true;
                            subDoc.Style.BorderTop = true;
                            subDoc.Style.BorderRight = true;
                            subDoc.Style.BorderBottom = true;
                            subDoc.Style.BorderWidth = 1;
                            subDoc.Style.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                            subDoc.Style.BorderColor = Color.Gray;
                            subDoc.Style.PrintBackColor = Color.Transparent;
                            subDoc.TagValue = list[iCount].Tag;
                            // 添加子文档元素对象
                            this.myViewControl.DocumentOptions.BehaviorOptions.ParagraphFlagFollowTableOrSection = true;
                            myViewControl.Document.Body.AppendChildElement(subDoc);
                        }
                    }//for
                    myViewControl.RefreshDocument();
                    // 刷新子文档列表
                    RefreshRecordsList();
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.myViewControl.ExecuteCommand("JumpPrintMode", false, null);
            if (cbox.Checked)
            {
                this.myViewControl.JumpPrintPosition = this._JumpPrintPosition;
            }
        }

        private XTextSubDocumentElement CreateNewSubDocument()
        {
            XTextSubDocumentElement doc = new XTextSubDocumentElement();
            doc.DocumentInfo.Author = "123";
            doc.DocumentInfo.Title = DateTime.Now.ToString("病程记录yyyy年MM月dd日 HH时mm分ss秒");
            doc.ID = doc.Title;
            doc.SetInnerTextFast("这是一段新的病程记录");
            //string path = Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容");
            //string fileName = doc.DocumentInfo.Title + ".xml";
            //fileName = Path.Combine(path, fileName);
            //doc.FileName = fileName;
            return doc;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.myViewControl.ExecuteCommand("FilePrint", true, null);
            this._JumpPrintPosition = this.myViewControl.JumpPrintPosition;
        }

        private void IsShowTreeview_Click(object sender, EventArgs e)
        {
            if (this.IsShowTreeview.Text == "显示")
            {
                this.tabControl1.Visible = true;
                this.IsShowTreeview.Text = "隐藏";
            }
            else if (this.IsShowTreeview.Text == "隐藏")
            {
                this.tabControl1.Visible = false;
                this.IsShowTreeview.Text = "显示";
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
        private void RefreshRecordsList()
        {
            lvwRecords.Items.Clear();
            foreach (XTextSubDocumentElement subdoc in this.myViewControl.Document.SubDocuments)
            {
                ListViewItem item = new ListViewItem(subdoc.Title);
                item.Tag = subdoc;
                lvwRecords.Items.Add(item);
            }
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            myViewControl.DocumentOptions.BehaviorOptions.EnableCollapseSection = toolStripButton28.Checked;
            foreach (XTextSectionElement sec in myViewControl.Document.Sections)
            {
                sec.EnableCollapse = toolStripButton28.Checked;
            }
            myViewControl.RefreshDocument();
        }

        private void btnInsertRecord_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subDoc = CreateNewSubDocument();
            this.myViewControl.InsertSubDocuentAtCurrentPosition(subDoc, false);
            RefreshRecordsList();
            this.myViewControl.Focus();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using (IDbConnection conn = Utils.CreateConnection())
            {
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    //加载页眉页脚模板
                    cmd.CommandText = "Select TemplateContent From  CourseRecordTemplate ";
                    IDataReader reader = cmd.ExecuteReader();
                    list = new ListItemCollection();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = Convert.ToString(reader.GetValue(0));
                        item.Value = item.Text;
                        list.Add(item);
                    }
                    reader.Close();
                    this.myViewControl.LoadDocumentFromString(list[0].Text, null);
                    // 清空正文内容
                    myViewControl.Document.Body.Elements.Clear();
                    //加载病程记录
                    cmd.CommandText = "Select RecordContent,RecordID,RecordMark From CourseRecord ";
                    reader = cmd.ExecuteReader();
                    list = new ListItemCollection();
                    while (reader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Text = Convert.ToString(reader.GetValue(0));
                        item.Value = item.Text;
                        item.Tag = Convert.ToString(reader.GetValue(1));
                        item.Text2 = reader.GetValue(2).ToString();
                        list.Add(item);
                    }
                    reader.Close();
                    for (int iCount = 0; iCount < list.Count; iCount++)
                    {
                        string fileName = list[iCount].Text;
                        XTextSubDocumentElement subDoc = new XTextSubDocumentElement();
                        subDoc.EnableCollapse = false;
                        subDoc.IsCollapsed = true;
                        subDoc.OwnerDocument = myViewControl.Document;
                        subDoc.LoadDocumentFromString(fileName, null);
                        subDoc.Title = list[iCount].Text2;
                        subDoc.Style.BorderLeft = true;
                        subDoc.Style.BorderTop = true;
                        subDoc.Style.BorderRight = true;
                        subDoc.Style.BorderBottom = true;
                        subDoc.Style.BorderWidth = 1;
                        subDoc.Style.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        subDoc.Style.BorderColor = Color.Gray;
                        subDoc.Style.PrintBackColor = Color.Transparent;
                        subDoc.TagValue = list[iCount].Tag;//RecordID  时间戳
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
                        this.myViewControl.DocumentOptions.BehaviorOptions.ParagraphFlagFollowTableOrSection = true;
                        myViewControl.Document.Body.AppendChildElement(subDoc);
                    }//for
                    myViewControl.RefreshDocument();
                    // 刷新子文档列表
                    RefreshRecordsList();
                }
            }
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            frmInsertSubDocumentTemplate frmInsert = new frmInsertSubDocumentTemplate(this);
            frmInsert.ShowDialog();
            if (frmInsert.DialogResult == DialogResult.OK)
            {
                XTextSubDocumentElement subDoc = new XTextSubDocumentElement();
                subDoc.EnableCollapse = false;
                subDoc.IsCollapsed = true;
                subDoc.OwnerDocument = myViewControl.Document;
                subDoc.Title = this.SubDocumentType;
                subDoc.ContentReadonly = ContentReadonlyState.False;
                subDoc.EnablePermission = DCBooleanValue.False;
                //subDoc.TagValue = "New" + new Random().Next(100, 100000) + "$" + SubDocumentTime;//保存至数据库时使用
                subDoc.TagValue = SubDocumentTime;//RecordID  时间戳
                //时间和标题
                subDoc.ContentBuilder.AppendTextWithStyleString(this.SubDocumentTime.ToString() + "           " + this.SubDocumentType.ToString(), "Bold:True");
                subDoc.ContentBuilder.AppendParagraphFlagWithStyleString("Align:Left");
                //内容
                subDoc.ContentBuilder.AppendTextWithStyleString("    XXXXXXXXXXXXXXXX", "");
                //签名
                XTextInputFieldElement input = new XTextInputFieldElement();
                input.BackgroundText = "签名";
                input.Text = this.SubDocumentSign;
                subDoc.AppendChildElement(input);
                subDoc.ContentBuilder.AppendParagraphFlagWithStyleString("Align:Right");
                //边框
                subDoc.Style.BorderLeft = true;
                subDoc.Style.BorderTop = true;
                subDoc.Style.BorderRight = true;
                subDoc.Style.BorderBottom = true;
                subDoc.Style.BorderWidth = 1;
                subDoc.Style.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                subDoc.Style.BorderColor = Color.Gray;
                subDoc.Style.PrintBackColor = Color.Transparent;
                // 添加子文档元素对象
                this.myViewControl.DocumentOptions.BehaviorOptions.ParagraphFlagFollowTableOrSection = true;
                myViewControl.Document.Body.AppendChildElement(subDoc);
                this.myViewControl.RefreshDocument();

                RefreshRecordsList();
                this.myViewControl.Focus();
                subDoc.Focus();
                this.myViewControl.RefreshDocument();
            }
        }

        private void btnBeginEdit_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.Document.CurrentSubDocument;
            if (subdoc != null)
            {
                subdoc.Focus();
                subdoc.EditorSetState(false, Color.Transparent, Color.Gray);
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
                    this.myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.False;
                    string fileName = subdoc.FileName;
                    // 删除数据库中文件
                    //System.IO.File.Delete(fileName);
                    subdoc.EditorDelete(false);
                    this.myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.True;
                    RefreshRecordsList();
                }
            }
        }

        private void myViewControl_SelectionChanged(object eventSender, WriterEventArgs args)
        {
            // btnSave.Enabled = this.myViewControl.Modified;
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

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            if (toolStripButton29.Checked)
                this.myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.True;
            else
                this.myViewControl.Document.Body.ContentReadonly = ContentReadonlyState.False;
        }

        private void btnUseTrack_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.CurrentSubDocument;
            if (subdoc != null && subdoc.Locked == false && btnUseTrack.Checked)
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
            else if (subdoc != null && subdoc.Locked == false && !btnUseTrack.Checked)
            {
                subdoc.EnablePermission = DCBooleanValue.False;//关闭痕迹
                //DCSoft.Writer.Security.UserLoginInfo usr = new DCSoft.Writer.Security.UserLoginInfo();
                //usr.ID = "DR.ZHANG";
                //usr.Name = "张医生";
                ////设置权限等级：大于等于0的整数，整数越大权限越大。
                //usr.PermissionLevel = 3;
                //myViewControl.UserLogin(usr, true);
                myViewControl.ExecuteCommand(StandardCommandNames.ComplexViewMode, false, null);
                myViewControl.Document.Options.SecurityOptions.EnablePermission = false;
                myViewControl.Document.Options.SecurityOptions.EnableLogicDelete = false;
                myViewControl.Document.Options.SecurityOptions.ShowLogicDeletedContent = false;
                myViewControl.Document.Options.SecurityOptions.ShowPermissionMark = false;
                myViewControl.Document.Options.SecurityOptions.ShowPermissionTip = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
              this,
             "文档的增删改操作都将保存到数据库，确定保存?",
              ResourceStrings.SystemAlert,
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //查询数据库RecordID
                using (IDbConnection conn = Utils.CreateConnection())
                {
                    conn.Open();
                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = "Select RecordID From  CourseRecord ";
                            IDataReader reader = cmd.ExecuteReader();
                            list = new ListItemCollection();
                            while (reader.Read())
                            {
                                ListItem item = new ListItem();
                                item.Text = Convert.ToString(reader.GetValue(0));
                                list.Add(item);
                            }
                            reader.Close();
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                        }
                    }
                }

                // 获得需要保存的文档对象
                List<XTextDocument> documents = new List<XTextDocument>();
                this.myViewControl.DocumentOptions.SecurityOptions.EnablePermission = true;
                //将文档中病程更新到数据库
                foreach (XTextSubDocumentElement record in this.myViewControl.Document.SubDocuments)
                {
                    bool isExist = false;
                    //比较数据库中的RecordID和文档中病程记录的Tagvalue（RecordID）
                    foreach (ListItem item in list)
                    {
                        //数据库中存在病程
                        if (record.TagValue.ToString() == item.Text)
                        {
                            isExist = true;
                            break;
                        }
                    }

                    if (isExist)
                    {
                        if (record.Modified)
                        {
                            //更新病程记录到数据库
                            using (IDbConnection conn = Utils.CreateConnection())
                            {
                                conn.Open();
                                using (IDbCommand cmd = conn.CreateCommand())
                                {
                                    try
                                    {
                                        cmd.CommandText = string.Format("update CourseRecord set RecordContent='{0}' where RecordID ='{1}'", record.InnerXML, record.TagValue.ToString());
                                        cmd.ExecuteNonQuery();
                                    }
                                    finally
                                    {
                                        if (conn.State == ConnectionState.Open)
                                            conn.Close();
                                    }
                                }
                            }
                            record.Modified = false;
                            record.EditorSetState(true, Color.LightGray, Color.FromArgb(200, 200, 200));
                        }
                    }
                    else
                    {
                        //新加病程，插入数据库
                        using (IDbConnection conn = Utils.CreateConnection())
                        {
                            conn.Open();
                            using (IDbCommand cmd = conn.CreateCommand())
                            {
                                try
                                {
                                    cmd.CommandText = string.Format("insert into CourseRecord(RecordID,RecordContent,PatientID,RecordDate,RecordMark) values('{0}','{1}','{2}','{3}','{4}') ", record.TagValue, record.InnerXML, "", record.TagValue, record.Title);
                                    cmd.ExecuteNonQuery();
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    if (conn.State == ConnectionState.Open)
                                        conn.Close();
                                }
                            }
                        }
                        record.Modified = false;
                        record.EditorSetState(true, Color.LightGray, Color.FromArgb(200, 200, 200));
                    }
                }
                //从数据库删除病程
                foreach (ListItem item in list)
                {
                    bool isExist = false;
                    foreach (XTextSubDocumentElement record in this.myViewControl.Document.SubDocuments)
                    {
                        if (item.Text == record.TagValue.ToString())
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        using (IDbConnection conn = Utils.CreateConnection())
                        {
                            conn.Open();
                            using (IDbCommand cmd = conn.CreateCommand())
                            {
                                try
                                {
                                    cmd.CommandText = string.Format("Delete from CourseRecord where RecordID='{0}' ", item.Text);
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    if (conn.State == ConnectionState.Open)
                                        conn.Close();
                                }
                            }
                        }
                    }
                }
                // 清空撤销操作信息列表
                this.myViewControl.ExecuteCommand(StandardCommandNames.ClearUndo, false, null);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
               this,
              "确定清空?",
               ResourceStrings.SystemAlert,
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.myViewControl.Document.Body.Elements.Clear();
                this.myViewControl.RefreshDocument();
                this.myViewControl.Document.Body.Elements.Clear();
                RefreshRecordsList();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            XTextSubDocumentElement subdoc = this.myViewControl.Document.CurrentSubDocument;
            if (subdoc != null)
            {
                subdoc.Focus();
                subdoc.EditorSetState(true, Color.LightGray, Color.Gray);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.myViewControl.CurrentSubDocument.Visible = false;
            this.myViewControl.RefreshDocument();
        }
    }
}
