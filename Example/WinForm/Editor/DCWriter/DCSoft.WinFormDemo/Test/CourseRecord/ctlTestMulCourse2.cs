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

namespace DCSoft.Writer.WinFormDemo.Test.CourseRecord
{
    [ToolboxItem(false)]
    public partial class ctlTestMulCourse2 : UserControl
    {
        public ctlTestMulCourse2()
        {
            InitializeComponent();
        }

        private void frmTestMulSection_Load(object sender, EventArgs e)
        {
            myViewControl.CommandControler = writerCommandControler1;
            myViewControl.CommandControler.Start();
            mySplitContainer.Panel2Collapsed = true;

            // 使用文档元素级事件来实现病程记录动态病区列表功能
            // 需要在病程记录框架模板的页眉中已经放置好了一个XTextLabelElement
            // 元素并设置它的EventTemplateName属性值为“设置病区标题”。
            ElementEventTemplate eet = new ElementEventTemplate();
            eet.Name = "设置病区标题";
            eet.BeforePaint += new ElementPaintEventHandler(eet_BeforePaint);
            myViewControl.EventTemplates.Add(eet);

            btnRefresh_Click(null, null);
        }


        private Dictionary<int, string> _AreasInPage = null;

        void eet_BeforePaint(object sender, ElementPaintEventArgs args)
        {
            if (_AreasInPage == null)
            {
                // 获得每页显示的病区文本字典
                _AreasInPage = new Dictionary<int, string>();
                // 遍历所有的文档页对象
                for (int iCount = 0; iCount < myViewControl.Document.Pages.Count; iCount++)
                {
                    PrintPage page = myViewControl.Document.Pages[iCount];
                    StringBuilder areaList = new StringBuilder();
                    string lastArea = null;
                    // 遍历文档中所有的文档节对象
                    foreach (XTextSectionElement section in myViewControl.Document.Body.Sections)
                    {
                        if ( section.Attributes != null && section.OwnerLine.OwnerPage == page)
                        {
                            // 获得文档节中附加的病区名称
                            string area = section.Attributes.GetValue("病区");
                            if (string.IsNullOrEmpty(area) == false)
                            {
                                if (lastArea == null || lastArea != area)
                                {
                                    // 进行病区名称拼接
                                    lastArea = area;
                                    if (areaList.Length > 0)
                                    {
                                        areaList.Append("->");
                                    }
                                    areaList.Append(area);
                                }//if
                            }//if
                        }
                    }
                    // 将拼接的病区名称字符串存放在全局的字典中
                    _AreasInPage[iCount + 1] = areaList.ToString();
                }
            }//if
            XTextLabelElement lbl = args.Element as XTextLabelElement;
            if (_AreasInPage.ContainsKey(lbl.OwnerDocument.PageIndex))
            {
                // 获得当前页码号对应的病区信息
                lbl.Text = _AreasInPage[lbl.OwnerDocument.PageIndex];
            }
            else
            {
                // 没找到，则设置不显示文本
                lbl.Text = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnEditRecord.Enabled = true ;
            btnNewRecord.Enabled = true ;
            // 清空上次显示文档时生成的病区标题信息
            _AreasInPage = null;
            string path = Path.Combine(Application.StartupPath, "DemoFile");
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
                //foreach (string fileName in fileNames)
                //{
                //    // 创建临时文档对象
                //    XTextDocument document = new XTextDocument();
                //    // 加载病程记录文档到临时文档对象中
                //    myViewControl.Document.Load(fileName, "xml", document);
                //    if (document != null && document.Body.HasContentElement)
                //    {
                //        // 创建文档节对象
                //        XTextSectionElement section = (XTextSectionElement)myViewControl.Document.CreateElement(
                //            typeof(XTextSectionElement));
                //        section.Attributes = new XAttributeList();
                //        // 设置文件名
                //        section.Attributes.SetValue("FileName", fileName);
                //        if (document.Attributes != null)
                //        {
                //            section.Attributes.SetValue("病区", document.Attributes.GetValue("病区"));
                //        }
                //        // 从临时文档对象中导入文档内容
                //        XTextElementList elements = document.Body.Elements.Clone();
                //        myViewControl.Document.ImportElements(elements);
                //        section.ContentBuilder.AppendRawMode = true;
                //        // 以粗体格式输出标题
                //        section.ContentBuilder.AppendTextWithStyleString(
                //            Path.GetFileNameWithoutExtension(fileName), 
                //            "Bold:True");
                //        // 输出一个段落
                //        section.ContentBuilder.AppendParagraphFlag("Align:left");
                //        // 输出病程记录内容
                //        section.ContentBuilder.AppendRange(elements);
                //        // 输出一个段落
                //        section.ContentBuilder.AppendParagraphFlag("Align:left");
                //        // 输出落款
                //        section.ContentBuilder.AppendTextWithStyleString("医生:", "Bold:True");
                //        if (document.Attributes != null)
                //        {
                //            section.ContentBuilder.AppendTextWithStyleString(document.Attributes.GetValue("作者"), "Bold:True");
                //        }
                //        // 输出一个右对齐的段落
                //        section.ContentBuilder.AppendParagraphFlag("Align:Right");
                //        // 将文档节添加到文档内容中
                //        myViewControl.Document.Body.AppendContentElement(section);
                //        // 添加一个段落符号
                //        myViewControl.Document.Body.AppendContentElement(new XTextParagraphFlagElement());
                //    }//if
                //}//foreach
                //// 刷新文档内容
                //myViewControl.RefreshDocument();
                //myViewControl.Document.Content.MoveSelectStart(selectStart);
            }
        }

        private void RefreshView(string[] fileNames)
        {
            string path = Path.Combine(Application.StartupPath, "DemoFile");
            myViewControl.ExecuteCommand("FileOpen", false, path + "\\模板-病程记录.xml");
            // 清空上次显示文档时生成的病区标题信息
            _AreasInPage = null;
            if ( fileNames != null && fileNames.Length > 0 )
            {
                int selectStart = myViewControl.Document.Selection.AbsStartIndex;
                //myWriterControl.Document.Clear();
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
                    myViewControl.Document.LoadDocumentInstance(fileName, format , document);
                    if (document != null && document.Body.HasContentElement)
                    {
                        // 创建文档节对象
                        XTextSectionElement section = (XTextSectionElement)myViewControl.Document.CreateElementByType(
                            typeof(XTextSectionElement));
                        section.Attributes = new XAttributeList();
                        // 设置文件名
                        section.Attributes.SetValue("FileName", fileName);
                        if (document.Attributes != null)
                        {
                            section.Attributes.SetValue("病区", document.Attributes.GetValue("病区"));
                        }
                        // 从临时文档对象中导入文档内容
                        XTextElementList elements = document.Body.Elements.Clone();
                        myViewControl.Document.ImportElements(elements);
                        section.ContentBuilder.AppendRawMode = true;
                        // 以粗体格式输出标题
                        section.ContentBuilder.AppendTextWithStyleString(
                            Path.GetFileNameWithoutExtension(fileName),
                            "Bold:True");
                        // 输出一个段落
                        section.ContentBuilder.AppendParagraphFlagWithStyleString("Align:left");
                        // 输出病程记录内容
                        section.ContentBuilder.AppendRange(elements);
                        // 输出一个段落
                        section.ContentBuilder.AppendParagraphFlagWithStyleString("Align:left");
                        // 输出落款
                        section.ContentBuilder.AppendTextWithStyleString("医生:", "Bold:True");
                        if (document.Attributes != null)
                        {
                            section.ContentBuilder.AppendTextWithStyleString(document.Attributes.GetValue("作者"), "Bold:True");
                        }
                        // 输出一个右对齐的段落
                        section.ContentBuilder.AppendParagraphFlagWithStyleString("Align:Right");
                        // 将文档节添加到文档内容中
                        myViewControl.Document.Body.AppendContentElement(section);
                        // 添加一个段落符号
                        myViewControl.Document.Body.AppendContentElement(new XTextParagraphFlagElement());
                    }//if
                }//foreach
                // 刷新文档内容
                myViewControl.RefreshDocument();
                myViewControl.Document.Content.MoveToPosition(selectStart);
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            // 获得插入点所在的当前文档节对象
            XTextSectionElement section = this.myViewControl.Document.CurrentSection;
            if (section != null)
            {
                if (section.Attributes != null && section.Attributes.ContainsByName("FileName"))
                {
                    // 根据附加的属性值获得病程记录文件名
                    string fileName = section.Attributes.GetValue("FileName");
                    mySplitContainer.Panel2Collapsed = false;
                    // 加载病程记录文档内容
                    myWriterControlExt.ExecuteCommand("FileOpen", false, fileName);
                    if (myWriterControlExt.Document.Attributes != null)
                    {
                        cboArea.Text = myWriterControlExt.Document.Attributes.GetValue("病区");
                        cboCurrentUser.Text = myWriterControlExt.Document.Attributes.GetValue("UserName");
                    }
                    myWriterControlExt.InnerWriterControl.Focus();

                }
            }

        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            mySplitContainer.Panel2Collapsed = false;
            string path = Path.Combine(Application.StartupPath, "DemoFile");
            myWriterControlExt.ExecuteCommand("FileOpen", false, path + "\\模板-病程记录.xml");
            myWriterControlExt.Document.FileName = null;
            myWriterControlExt.InnerWriterControl.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 获得文件名
            string fileName = myWriterControlExt.Document.FileName;
            if (myWriterControlExt.Document.Attributes != null)
            {
                myWriterControlExt.Document.Attributes = new XAttributeList();
            }
            // 保存当前用户名
            myWriterControlExt.Document.Attributes.SetValue("UserName", cboCurrentUser.Text);
            // 保存当前病区
            myWriterControlExt.Document.Attributes.SetValue("病区", cboArea.Text);
            if (string.IsNullOrEmpty(fileName))
            {
                // 若文件名为空则是新增病程记录内容
                // 生成新的病程记录文件名
                fileName = System.IO.Path.Combine(
                    Application.StartupPath,
                    "DemoFile\\病程记录"
                    + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒")
                    + ".xml");
            }
            // 保存文件
            myWriterControlExt.ExecuteCommand("FileSave", false, fileName);
            // 刷新显示
            btnRefresh_Click(null, null);
            mySplitContainer.Panel2Collapsed = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mySplitContainer.Panel2Collapsed = true;
            myWriterControlExt.ExecuteCommand("FileNew", false, null);
        }

        private void cboArea_TextChanged(object sender, EventArgs e)
        {
            XTextLabelElement lbl = myWriterControlExt.Document.GetElementById("lblArea") as XTextLabelElement ;
            if (lbl != null)
            {
                lbl.Text = cboArea.Text;
                myWriterControlExt.Refresh();
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
                    btnEditRecord.Enabled = false;
                    btnNewRecord.Enabled = false;
                }
            }
        }

    }
}