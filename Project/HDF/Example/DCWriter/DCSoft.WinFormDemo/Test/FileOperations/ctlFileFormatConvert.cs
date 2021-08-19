using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlFileFormatConvert : UserControl
    {
        public ctlFileFormatConvert()
        {
            InitializeComponent();
        }


        private void ctlFileFormatConvert_Load(object sender, EventArgs e)
        {
     
        }

        private void btnSourceFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.CheckFileExists = true;
                dlg.Filter = "*.xml,*.html,*.rtf,*.txt|*.xml;*.html;*.htm;*.rtf;*.txt";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string fn = dlg.FileName;
                    txtSourceFile.Text = fn;
                    if (fn.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboSourceFormat.Text = "xml";
                    }
                    else if (fn.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase)
                        || fn.EndsWith(".htm", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboSourceFormat.Text = "html";
                    }
                    else if (fn.EndsWith(".rtf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboSourceFormat.Text = "rtf";
                    }
                    else if (fn.EndsWith(".txt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboSourceFormat.Text = "txt";
                    }

                }
            }
        }

        private void btnBrowseDestFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.CheckPathExists = true;
                dlg.OverwritePrompt = true;
                dlg.Filter = "*.xml,*.html,*.rtf,*.txt,*.pdf,*.mht|*.xml;*.html;*.htm;*.rtf;*.txt;*.pdf;*.mht";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string fn = dlg.FileName;
                    txtDestFile.Text = fn;
                    if (fn.EndsWith(".xml", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboDestFormat.Text = "xml";
                    }
                    else if (fn.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase)
                        || fn.EndsWith(".htm", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboDestFormat.Text = "html";
                    }
                    else if (fn.EndsWith(".rtf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboDestFormat.Text = "rtf";
                    }
                    else if (fn.EndsWith(".txt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboDestFormat.Text = "txt";
                    }
                    else if (fn.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboDestFormat.Text = "pdf";
                    }
                    else if (fn.EndsWith(".mht", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cboDestFormat.Text = "mht";
                    }
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            bool result = ConvertFile(txtSourceFile.Text, cboSourceFormat.Text, txtDestFile.Text, cboDestFormat.Text);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 进行文件格式转换
        /// </summary>
        /// <param name="sourceFileName">原始文件名</param>
        /// <param name="sourceFormat">原始文件格式</param>
        /// <param name="descFileName">目标文件名</param>
        /// <param name="descFormat">目标文件格式</param>
        /// <returns>操作是否成功</returns>
        public bool ConvertFile(
            string sourceFileName ,
            string sourceFormat, 
            string descFileName, 
            string descFormat)
        {
            if (string.IsNullOrEmpty(sourceFileName))
            {
                throw new ArgumentNullException("sourceFileName");
            }
            if (System.IO.File.Exists(sourceFileName) == false)
            {
                throw new System.IO.FileNotFoundException(sourceFileName);
            }
            if (string.IsNullOrEmpty(descFileName))
            {
                throw new ArgumentNullException("descFileName");
            }
             
            XTextDocument document = new XTextDocument();
            document.Load(sourceFileName, sourceFormat);
            using (DCSoft.Drawing.DCGraphics g = document.CreateDCGraphics())
            {
                // 计算文档元素大小
                document.RefreshSize(g);
                // 进行内容排版
                document.ExecuteLayout();
                // 进行分页
                document.RefreshPages();
            }
            document.Save(descFileName, descFormat);

            return true;
        }

    }
}