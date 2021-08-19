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
    [System.ComponentModel.ToolboxItem(false)]
    public partial class ctlPageSettings : UserControl
    {
        public ctlPageSettings()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine( Application.StartupPath , "DemoFile2\\入院记录--广州医科大学附属第一医院入院记录.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.LoadDocumentFromFile(fileName, null);
            }
        }

        private void btnHeng_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.Landscape = true ;
            myWriterControl.RefreshDocument();
        }

        private void btnZong_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.Landscape = false;
            myWriterControl.RefreshDocument();
        }
         

        private void menuNoBlankText_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.TerminalText = null;
            myWriterControl.RedrawDocument();
        }

        private void menuBlankText_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.TerminalText = new DCSoft.Drawing.DocumentTerminalTextInfo();
            myWriterControl.PageSettings.TerminalText.Font = new DCSoft.Drawing.XFontValue("宋体", 30);
            myWriterControl.PageSettings.TerminalText.Text = "以下空白";
            myWriterControl.PageSettings.TerminalText.TextInMiddlePage = "此处空白";
            myWriterControl.RedrawDocument();
        }

        private void menuBlankLine1_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.TerminalText = new DCSoft.Drawing.DocumentTerminalTextInfo();
            myWriterControl.PageSettings.TerminalText.Font = new DCSoft.Drawing.XFontValue("宋体", 30);
            myWriterControl.PageSettings.TerminalText.Text = "line:/";
            myWriterControl.PageSettings.TerminalText.TextInMiddlePage = "line:/";
            myWriterControl.RedrawDocument();
        }

        private void menuBlankLine2_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.TerminalText = new DCSoft.Drawing.DocumentTerminalTextInfo();
            myWriterControl.PageSettings.TerminalText.Font = new DCSoft.Drawing.XFontValue("宋体", 30);
            myWriterControl.PageSettings.TerminalText.Text = "line:\\";
            myWriterControl.PageSettings.TerminalText.TextInMiddlePage = "line:\\";
            myWriterControl.RedrawDocument();
        }

        private void menuBlankLineS_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.TerminalText = new DCSoft.Drawing.DocumentTerminalTextInfo();
            myWriterControl.PageSettings.TerminalText.Font = new DCSoft.Drawing.XFontValue("宋体", 30);
            myWriterControl.PageSettings.TerminalText.Text = "line:s";
            myWriterControl.PageSettings.TerminalText.TextInMiddlePage = "line:s";
            myWriterControl.RedrawDocument();
        }

        private void menuNoWM_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.Watermark = null;
            myWriterControl.RedrawDocument();
        }

        private void menuTextWM_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.Watermark = new DCSoft.Drawing.WatermarkInfo();
            myWriterControl.PageSettings.Watermark.Type = DCSoft.Drawing.WatermarkType.Text;
            myWriterControl.PageSettings.Watermark.Text = "南京都昌信息科技有限公司";
            myWriterControl.PageSettings.Watermark.Font = new DCSoft.Drawing.XFontValue("宋体", 30);
            myWriterControl.PageSettings.Watermark.Angle = -45;
            myWriterControl.PageSettings.Watermark.Color = Color.Blue;
            myWriterControl.RedrawDocument();
        }

        private void menuImageWM_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "图片文件(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(dlg.FileName);
                    myWriterControl.PageSettings.Watermark = new DCSoft.Drawing.WatermarkInfo();
                    myWriterControl.PageSettings.Watermark.Type = DCSoft.Drawing.WatermarkType.Image;
                    myWriterControl.PageSettings.Watermark.Image = new DCSoft.Drawing.XImageValue( img );
                    myWriterControl.PageSettings.Watermark.Repeat = true;
                    myWriterControl.RedrawDocument();
                }
            }
        }

        private void btnPageSettings_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings = new DCSoft.Printing.XPageSettings();
            myWriterControl.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            myWriterControl.PageSettings.Landscape = false;
            myWriterControl.PageSettings.LeftMargin = 125;
            myWriterControl.PageSettings.TopMargin = 100;
            myWriterControl.PageSettings.RightMargin = 125;
            myWriterControl.PageSettings.BottomMargin = 100;
            myWriterControl.PageSettings.HeaderDistance = 50;
            myWriterControl.PageSettings.FooterDistance = 50;
            myWriterControl.RefreshDocument();
        }

        private void menuNoBorder_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.PageBorderBackground = null;
            myWriterControl.RedrawDocument();
        }

        private void menuPageBorder_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.PageBorderBackground = new DCSoft.Drawing.PageBorderBackgroundStyle();
            myWriterControl.PageSettings.PageBorderBackground.BorderRange = DCSoft.Drawing.PageBorderRangeTypes.Page;
            myWriterControl.PageSettings.PageBorderBackground.BorderColor = System.Drawing.Color.Blue;
            myWriterControl.PageSettings.PageBorderBackground.BorderWidth = 1;
            myWriterControl.PageSettings.PageBorderBackground.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            myWriterControl.PageSettings.PageBorderBackground.BorderLeft = true;
            myWriterControl.PageSettings.PageBorderBackground.BorderTop = true;
            myWriterControl.PageSettings.PageBorderBackground.BorderRight = true;
            myWriterControl.PageSettings.PageBorderBackground.BorderBottom = true;
            myWriterControl.RedrawDocument();
        }

        private void menuBorderBody_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.PageBorderBackground = new DCSoft.Drawing.PageBorderBackgroundStyle();
            myWriterControl.PageSettings.PageBorderBackground.BorderRange = DCSoft.Drawing.PageBorderRangeTypes.Body;
            myWriterControl.PageSettings.PageBorderBackground.BorderColor = System.Drawing.Color.Red;
            myWriterControl.PageSettings.PageBorderBackground.BorderWidth = 6.25f;
            myWriterControl.PageSettings.PageBorderBackground.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            myWriterControl.PageSettings.PageBorderBackground.BorderLeft = true;
            myWriterControl.PageSettings.PageBorderBackground.BorderTop = true;
            myWriterControl.PageSettings.PageBorderBackground.BorderRight = true;
            myWriterControl.PageSettings.PageBorderBackground.BorderBottom = true;
            myWriterControl.RedrawDocument();
        }

        private void btnSwapMergin_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.SwapLeftRightMargin = btnSwapMergin.Checked;
            myWriterControl.PageSettings.LeftMargin = 100;
            myWriterControl.PageSettings.RightMargin = 50;
            myWriterControl.RefreshDocument();
        }

        private void btnEditBackImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "图片文件(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(dlg.FileName);
                    myWriterControl.PageSettings.EditTimeBackgroundImage = new DCSoft.Drawing.XImageValue(img);
                    myWriterControl.RedrawDocument();
                }
            }
        }

        private void btnHeaderFooterDifferentFirstPage_Click(object sender, EventArgs e)
        {
            myWriterControl.PageSettings.HeaderFooterDifferentFirstPage = btnHeaderFooterDifferentFirstPage.Checked;
            myWriterControl.RefreshDocumentLayout();
        }
          
    }
}