using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlBuildDom : UserControl
    {
        public ctlBuildDom()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            //myWriterControl.ViewMode = DCSoft.Printing.PageViewMode.Normal;
        }

        /// <summary>
        /// 处理数据过滤事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_FilterValue(object sender, FilterValueEventArgs args)
        {
            if (args.Type == InputValueType.Dom)
            {
                XTextElementList list = (XTextElementList)args.Value;
                if (list != null && list.Count > 0)
                {
                    // 清空原始数据中所有文本输入域的内容
                    ClearFieldContent(list);
                }
            }
        }

        private void ClearFieldContent(XTextElementList list)
        {
            // 清空所有输入域的内容
            foreach (XTextElement element in list)
            {
                if (element is XTextInputFieldElement)
                {
                    XTextInputFieldElement field = (XTextInputFieldElement)element;
                    if (field.Attributes == null)
                    {
                        field.Attributes = new XAttributeList();
                    }
                    field.Attributes.SetValue("插入时间", DateTime.Now.ToString());
                    field.Elements.Clear();
                    field.InnerValue = null;
                }
                else if (element is XTextContainerElement)
                {
                    XTextContainerElement c = (XTextContainerElement)element;
                    if (c.Elements != null && c.Elements.Count > 0)
                    {
                        ClearFieldContent(c.Elements);
                    }
                }
            }
        }

        private void btnFillHeader_Click(object sender, EventArgs e)
        {
            FillDocument(0);
        }


        private void btnFillBody_Click(object sender, EventArgs e)
        {
            FillDocument(1);
        }

        private void btnFillFooter_Click(object sender, EventArgs e)
        {
            FillDocument(2);
        }

        private void FillDocument(int style)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "XML文件|*.xml";
                dlg.CheckPathExists = true;
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = dlg.FileName;
                    XTextDocument document = new XTextDocument();
                    document.Load(fileName, "xml");
                    //this.myWriterControl.Document.Load(fileName, "xml", document);
                    if (document != null && document.Body.HasContentElement)
                    {
                        XTextElementList elements = document.Body.Elements.Clone();
                        myWriterControl.Document.ImportElements(elements);
                        if (style == 0)
                        {
                            myWriterControl.Document.Header.AppendContentElements(elements);
                        }
                        else if (style == 1)
                        {
                            myWriterControl.Document.Body.AppendContentElements(elements);
                        }
                        else
                        {
                            myWriterControl.Document.Footer.AppendContentElements(elements);
                        }
                        myWriterControl.RefreshDocument();
                    }
                }
            }
        }

        private void btnBuildContent_Click(object sender, EventArgs e)
        {
            XTextDocument document = myWriterControl.Document;
            DocumentContentStyle dcs = new DocumentContentStyle();
            dcs.FontSize = 12;
            dcs.Color = System.Drawing.Color.Red;
            document.Header.ContentBuilder.AppendTextWithStyle("这是一段页眉    第 ", dcs);
            XTextPageInfoElement pi = new XTextPageInfoElement();
            pi.ValueType = PageInfoValueType.PageIndex;
            document.Header.ContentBuilder.AppendWithStyle(pi , dcs );
            document.Header.ContentBuilder.AppendTextWithStyle("共 页", dcs);
            XTextPageInfoElement pc = new XTextPageInfoElement();
            pc.ValueType = PageInfoValueType.NumOfPages;
            pc.StyleIndex = document.ContentStyles.GetStyleIndex(dcs);
            document.Header.ContentBuilder.Append(pc);
            document.Header.ContentBuilder.AppendTextWithStyle("页", dcs);
            dcs = new DocumentContentStyle();
            dcs.Align = Drawing.DocumentContentAlignment.Center;
            //dcs.BorderBottom = true;
            //dcs.BorderSpacing = 10;
            //dcs.BorderWidth = 1;
            document.Header.ContentBuilder.SetParagraphStyle(dcs);

            dcs = new DocumentContentStyle();
            dcs.Color = System.Drawing.Color.Yellow;
            document.Body.ContentBuilder.AppendTextWithStyle("这是文档正文内容", dcs);
            document.Body.ContentBuilder.AppendParagraphFlag();
            dcs = new DocumentContentStyle();
            dcs.FontSize = 12;
            document.Body.ContentBuilder.AppendTextWithStyle("页面第二行", dcs);

            dcs = new DocumentContentStyle();
            dcs.FontSize = 12;
            dcs.Color = System.Drawing.Color.Blue;
            document.Footer.ContentBuilder.AppendTextWithStyle("这是页脚内容", dcs);

            myWriterControl.Document.ContentStyles.Default.FontSize = 12;
            myWriterControl.Document.ContentStyles.Default.Color = System.Drawing.Color.Tomato;
            myWriterControl.Document.ContentStyles.Default.LineSpacingStyle = DCSoft.Drawing.LineSpacingStyle.SpaceSpecify;
            myWriterControl.Document.ContentStyles.Default.LineSpacing = 60;
            myWriterControl.RefreshDocument();
        }

        private void btnBuildValueBindingField_Click(object sender, EventArgs e)
        {
            //第一行页眉  医院民称
            XTextDocument document = this.myWriterControl.Document;
            DocumentContentStyle dcs = new DocumentContentStyle();
            dcs.FontSize = 12;
            dcs.Color = System.Drawing.Color.Gray;
            dcs.Align = DCSoft.Drawing.DocumentContentAlignment.Center;
            document.Header.ContentBuilder.AppendTextWithStyle("XXXX人民医院\r\n", dcs);

            //姓名文本输入域
            XTextInputFieldElement name = new XTextInputFieldElement();
            name.FieldSettings = new InputFieldSettings();
            name.FieldSettings.EditStyle = InputFieldEditStyle.Text;
            name.DisplayFormat = new DCSoft.Data.ValueFormater ();
            name.ValidateStyle = new DCSoft.Common.ValueValidateStyle();
            //自动绑定数据  
            name.ValueBinding = new DCSoft.Writer.Data.XDataBinding();
            name.ValueBinding.DataSource = "name";//数据源的名称
            name.ValueBinding.AutoUpdate = true;//是否自动更新数据

            //住院号文本输入域
            XTextInputFieldElement inpno = new XTextInputFieldElement();
            inpno.FieldSettings = new InputFieldSettings();
            inpno.FieldSettings.EditStyle = InputFieldEditStyle.Text;
            inpno.DisplayFormat = new DCSoft.Data.ValueFormater();
            inpno.ValidateStyle = new DCSoft.Common.ValueValidateStyle();
            //自动绑定数据  
            inpno.ValueBinding = new DCSoft.Writer.Data.XDataBinding();
            inpno.ValueBinding.DataSource = "inpno";//数据源的名称
            inpno.ValueBinding.AutoUpdate = true;//是否自动更新数据

            //科室文本输入域
            XTextInputFieldElement dept = new XTextInputFieldElement();
            dept.FieldSettings = new InputFieldSettings();
            dept.FieldSettings.EditStyle = InputFieldEditStyle.Text;
            dept.DisplayFormat = new DCSoft.Data.ValueFormater();
            dept.ValidateStyle = new DCSoft.Common.ValueValidateStyle();
            //自动绑定数据  
            dept.ValueBinding = new DCSoft.Writer.Data.XDataBinding();
            dept.ValueBinding.DataSource = "dept";//数据源的名称
            dept.ValueBinding.AutoUpdate = true;//是否自动更新数据

            //床号文本输入域
            XTextInputFieldElement bedno = new XTextInputFieldElement();
            bedno.FieldSettings = new InputFieldSettings();
            bedno.FieldSettings.EditStyle = InputFieldEditStyle.Text;
            bedno.DisplayFormat = new DCSoft.Data.ValueFormater();
            bedno.ValidateStyle = new DCSoft.Common.ValueValidateStyle();
            //自动绑定数据  
            bedno.ValueBinding = new DCSoft.Writer.Data.XDataBinding();
            bedno.ValueBinding.DataSource = "bedno";//数据源的名称
            bedno.ValueBinding.AutoUpdate = true;//是否自动更新数据


            //第二行页眉  病人信息
            DocumentContentStyle dcs2 = new DocumentContentStyle();
            dcs2.FontSize = 12;
            dcs2.Color = System.Drawing.Color.Gray;
            dcs2.Align = DCSoft.Drawing.DocumentContentAlignment.Center;
            document.Header.ContentBuilder.AppendText("姓名:");
            document.Header.ContentBuilder.Append(name);
            document.Header.ContentBuilder.AppendText("\t");
            document.Header.ContentBuilder.AppendText("住院号:");
            document.Header.ContentBuilder.Append(inpno);
            document.Header.ContentBuilder.AppendText("\t");
            document.Header.ContentBuilder.AppendText("科室:");
            document.Header.ContentBuilder.Append(dept);
            document.Header.ContentBuilder.AppendText("\t");
            document.Header.ContentBuilder.AppendText("床号:");
            document.Header.ContentBuilder.Append(bedno);

            document.Header.ContentBuilder.SetParagraphStyle(dcs2);
            myWriterControl.Document.Parameters.SetValue("name", "张三");
            myWriterControl.Document.Parameters.SetValue("inpno", "0001");
            myWriterControl.Document.Parameters.SetValue("dept", "222");
            myWriterControl.Document.Parameters.SetValue("bedno", "333");
            myWriterControl.RefreshDocument();
            myWriterControl.WriteDataFromDataSourceToDocument();// .UpdateViewForDataSource();// .ExecuteCommand("UpdateViewForDataSource", false, null);
        }

        private void btnFillHeader2_Click(object sender, EventArgs e)
        {
            //第一行页眉  医院民称
            XTextDocument document = this.myWriterControl.Document;
            //ContentBuilder bulder = new ContentBuilder(document.Header);
            DocumentContentStyle dcs = new DocumentContentStyle();
            dcs.FontSize = 12;
            dcs.Color = System.Drawing.Color.Gray;
            dcs.Align = DCSoft.Drawing.DocumentContentAlignment.Center;
            document.Header.ContentBuilder.AppendTextWithStyle( "XX省人民医院\r\n", dcs);

            //第二行页眉  病人信息
            DocumentContentStyle dcs2 = new DocumentContentStyle();
            dcs2.FontSize = 12;
            dcs2.Color = System.Drawing.Color.Gray;
            dcs2.Align = DCSoft.Drawing.DocumentContentAlignment.Center;
            //if (MRClass == "1" || MRClass == "7")
            {
                document.Header.ContentBuilder.AppendTextWithStyle("姓名:张三"  + " \t" + "住院号:0000111" +  "\t" + "科室:呼吸科" + "\t" + "床号:002" , dcs2);
            }
            //else
            //{
            //    document.Header.ContentBuilder.AppendTextWithStyle("姓名:张三" +  "\t" + "就诊号:00000111" +  "", dcs2);
            //}
            this.myWriterControl.RefreshDocument();
        }

    }
}