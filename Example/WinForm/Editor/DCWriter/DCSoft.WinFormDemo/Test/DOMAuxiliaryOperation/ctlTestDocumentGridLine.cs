using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestDocumentGridLine : UserControl
    {
        public ctlTestDocumentGridLine()
        {
            InitializeComponent();
        }


        private void btnDocumentGridLine_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("DocumentGridLineNew", true, null);
        }

        private void txtCode_Click(object sender, EventArgs e)
        {
            writerControl1.Document.PageSettings.DocumentGridLine = new DCSoft.Printing.DCGridLineInfo();
            // 显示网格线
            writerControl1.Document.PageSettings.DocumentGridLine.Visible = true;
            // 每页显示的行数
            writerControl1.Document.PageSettings.DocumentGridLine.GridNumInOnePage = 40;
            // 红色网格线
            writerControl1.Document.PageSettings.DocumentGridLine.Color = Color.Red;
            // 线条样式
            writerControl1.Document.PageSettings.DocumentGridLine.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            // 打印网格线
            writerControl1.Document.PageSettings.DocumentGridLine.Printable = true;
            // 对齐文档行到网格线
            writerControl1.Document.PageSettings.DocumentGridLine.AlignToGridLine = true;
            // 刷新文档
            writerControl1.RefreshDocumentExt(false, true);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("FileOpen", true, null);
        }
         

        private void btnGridLineExt_Click(object sender, EventArgs e)
        {
            DCSoft.Writer.GridLineSettings gls = new GridLineSettings();
            gls.ShowGridLine = true;
            gls.GridLineColor = Color.Red;
            gls.PrintGridLine = true;
            writerControl1.ExecuteCommand("DocumentGridLine", true, gls);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("FilePrint", true, null);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            writerControl1.ExecuteCommand("FileSaveAs", true, null);
        }

        private void writerControl1_Load(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\文档网格线.xml");
            if (System.IO.File.Exists(fileName))
            {
                writerControl1.ExecuteCommand("FileOpen", false, fileName);
            }
        }

    }
}