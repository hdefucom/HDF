using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	/// <summary>
	///       测试基础打印功能的对话框
	///       </summary>
	[ComVisible(false)]
	public class frmTestPrintDocument : Form
	{
		private IContainer icontainer_0 = null;

		private ToolStrip toolStrip1;

		private ToolStripButton btnFont;

		private ToolStripButton btnPageSettings;

		private ToolStripButton btnPreview;

		private ToolStripButton btnPrint;

		private TextBox txtText;

		private PrintDocument printDocument_0 = null;

		private XPageSettings xpageSettings_0 = new XPageSettings();

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Printing.frmTestPrintDocument));
			toolStrip1 = new System.Windows.Forms.ToolStrip();
			txtText = new System.Windows.Forms.TextBox();
			btnPageSettings = new System.Windows.Forms.ToolStripButton();
			btnPrint = new System.Windows.Forms.ToolStripButton();
			btnPreview = new System.Windows.Forms.ToolStripButton();
			btnFont = new System.Windows.Forms.ToolStripButton();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4]
			{
				btnFont,
				btnPageSettings,
				btnPreview,
				btnPrint
			});
			toolStrip1.Location = new System.Drawing.Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.ShowItemToolTips = false;
			toolStrip1.Size = new System.Drawing.Size(520, 25);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "toolStrip1";
			txtText.Dock = System.Windows.Forms.DockStyle.Fill;
			txtText.Location = new System.Drawing.Point(0, 25);
			txtText.Multiline = true;
			txtText.Name = "txtText";
			txtText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtText.Size = new System.Drawing.Size(520, 257);
			txtText.TabIndex = 1;
			txtText.Text = "请输入文本...";
			btnPageSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnPageSettings.Image = (System.Drawing.Image)resources.GetObject("btnPageSettings.Image");
			btnPageSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnPageSettings.Name = "btnPageSettings";
			btnPageSettings.Size = new System.Drawing.Size(60, 22);
			btnPageSettings.Text = "页面设置";
			btnPageSettings.Click += new System.EventHandler(btnPageSettings_Click);
			btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnPrint.Image = (System.Drawing.Image)resources.GetObject("btnPrint.Image");
			btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnPrint.Name = "btnPrint";
			btnPrint.Size = new System.Drawing.Size(36, 22);
			btnPrint.Text = "打印";
			btnPrint.Click += new System.EventHandler(btnPrint_Click);
			btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnPreview.Image = (System.Drawing.Image)resources.GetObject("btnPreview.Image");
			btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnPreview.Name = "btnPreview";
			btnPreview.Size = new System.Drawing.Size(60, 22);
			btnPreview.Text = "打印预览";
			btnPreview.Click += new System.EventHandler(btnPreview_Click);
			btnFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			btnFont.Image = (System.Drawing.Image)resources.GetObject("btnFont.Image");
			btnFont.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnFont.Name = "btnFont";
			btnFont.Size = new System.Drawing.Size(36, 22);
			btnFont.Text = "字体";
			btnFont.Click += new System.EventHandler(btnFont_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(520, 282);
			base.Controls.Add(txtText);
			base.Controls.Add(toolStrip1);
			base.MinimizeBox = false;
			base.Name = "frmTestPrintDocument";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "测试打印功能";
			base.Load += new System.EventHandler(frmTestPrintDocument_Load);
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public frmTestPrintDocument()
		{
			InitializeComponent();
		}

		private void frmTestPrintDocument_Load(object sender, EventArgs e)
		{
			printDocument_0 = new PrintDocument();
			printDocument_0.QueryPageSettings += printDocument_0_QueryPageSettings;
			printDocument_0.PrintPage += printDocument_0_PrintPage;
		}

		private void printDocument_0_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
		{
			xpageSettings_0.method_4(e.PageSettings);
		}

		private void printDocument_0_PrintPage(object sender, PrintPageEventArgs e)
		{
			int num = 19;
			e.Graphics.PageUnit = GraphicsUnit.Document;
			RectangleF printableArea = e.PageSettings.PrintableArea;
			printableArea.X *= 3f;
			printableArea.Y *= 3f;
			printableArea.Width *= 3f;
			printableArea.Height *= 3f;
			if (e.PageSettings.Landscape)
			{
				float width = printableArea.Width;
				printableArea.Width = printableArea.Height;
				printableArea.Height = width;
			}
			using (Pen pen = new Pen(Color.Red, 10f))
			{
				e.Graphics.DrawRectangle(pen, printableArea.Left, printableArea.Top, printableArea.Width, printableArea.Height);
			}
			RectangleF rectangleF = new RectangleF(0f, 0f, printableArea.Width / 5f, printableArea.Height / 5f);
			e.Graphics.DrawLine(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
			e.Graphics.DrawLine(Pens.Black, rectangleF.Left, rectangleF.Bottom, rectangleF.Right, rectangleF.Top);
			e.Graphics.DrawRectangle(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
			rectangleF = e.PageSettings.Bounds;
			rectangleF = new RectangleF(3f * rectangleF.Width - printableArea.Width / 5f, 3f * rectangleF.Height - printableArea.Height / 5f, printableArea.Width / 5f, printableArea.Height / 5f);
			e.Graphics.DrawLine(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
			e.Graphics.DrawLine(Pens.Black, rectangleF.Left, rectangleF.Bottom, rectangleF.Right, rectangleF.Top);
			e.Graphics.DrawRectangle(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
			float num2 = GraphicsUnitConvert.ConvertFromCM(1f, e.Graphics.PageUnit);
			float num3 = GraphicsUnitConvert.ConvertToCM(printableArea.Width, e.Graphics.PageUnit);
			float num4 = GraphicsUnitConvert.ConvertToCM(printableArea.Height, e.Graphics.PageUnit);
			Font defaultFont = Control.DefaultFont;
			float num5 = printableArea.Left + printableArea.Width / 2f;
			e.Graphics.DrawLine(Pens.Black, num5, printableArea.Top, num5, printableArea.Bottom);
			for (int i = 0; (float)i <= num4; i++)
			{
				float num6 = GraphicsUnitConvert.ConvertFromCM(i, e.Graphics.PageUnit);
				e.Graphics.DrawLine(Pens.Black, num5, num6, num5 + num2, num6);
				e.Graphics.DrawString(i + "CM", defaultFont, Brushes.Black, num5 + num2, num6);
			}
			float num7 = printableArea.Top + printableArea.Height / 2f;
			e.Graphics.DrawLine(Pens.Black, printableArea.Left, num7, printableArea.Right, num7);
			for (int i = 0; (float)i <= num3; i++)
			{
				float num6 = GraphicsUnitConvert.ConvertFromCM(i, e.Graphics.PageUnit);
				e.Graphics.DrawLine(Pens.Black, num6, num7, num6, num7 + num2);
				e.Graphics.DrawString(i + "CM", defaultFont, Brushes.Black, num6, num7 + num2);
			}
			float left = e.PageSettings.PrintableArea.Left;
			float top = e.PageSettings.PrintableArea.Top;
			e.Graphics.DrawRectangle(Pens.Red, printableArea.Left, printableArea.Top, printableArea.Width, printableArea.Height);
			RectangleF layoutRectangle = new RectangleF((float)(e.PageSettings.Margins.Left * 3) - left * 3f, (float)(e.PageSettings.Margins.Top * 3) - top * 3f, printableArea.Width - (float)(e.PageSettings.Margins.Left * 3) - (float)(e.PageSettings.Margins.Right * 3) - left * 6f, printableArea.Height - (float)(e.PageSettings.Margins.Top * 3) - (float)(e.PageSettings.Margins.Bottom * 3) - top * 6f);
			PointF pos = GClass154.smethod_5(null, e.PageSettings, GraphicsUnit.Document);
			layoutRectangle.Offset(pos);
			e.Graphics.DrawRectangle(Pens.Blue, layoutRectangle.Left, layoutRectangle.Top, layoutRectangle.Width, layoutRectangle.Height);
			using (StringFormat stringFormat = new StringFormat())
			{
				stringFormat.Alignment = StringAlignment.Near;
				stringFormat.LineAlignment = StringAlignment.Near;
				using (SolidBrush brush = new SolidBrush(txtText.ForeColor))
				{
					string s = string.Concat(txtText.Text, Environment.NewLine, xpageSettings_0.ToString(), Environment.NewLine, "宽度:", num3.ToString("0.00"), "CM", Environment.NewLine, "高度:", num4.ToString("0.00"), "CM", Environment.NewLine, "打印机:", e.PageSettings.PrinterSettings.PrinterName, Environment.NewLine, "打印纸张来源:", e.PageSettings.PaperSource.ToString(), Environment.NewLine, "实际使用的纸张名称:", e.PageSettings.PaperSize.PaperName, Environment.NewLine, "纸张类型:", e.PageSettings.PaperSize.Kind, Environment.NewLine, "纸张宽度:", GraphicsUnitConvert.ConvertToCM(e.PageSettings.PaperSize.Width * 3, GraphicsUnit.Document).ToString("0.00"), "CM", Environment.NewLine, "纸张高度:", GraphicsUnitConvert.ConvertToCM(e.PageSettings.PaperSize.Height * 3, GraphicsUnit.Document).ToString("0.00"), "CM", Environment.NewLine, "横向可打印区域：", GraphicsUnitConvert.ConvertToCM(e.PageSettings.PrintableArea.X * 3f, GraphicsUnit.Document).ToString("0.00"), "CM", Environment.NewLine, "纵向可打印区域：", GraphicsUnitConvert.ConvertToCM(e.PageSettings.PrintableArea.Y * 3f, GraphicsUnit.Document).ToString("0.00"), "CM");
					e.Graphics.DrawString(s, txtText.Font, brush, layoutRectangle, stringFormat);
				}
			}
		}

		private void btnFont_Click(object sender, EventArgs e)
		{
			using (FontDialog fontDialog = new FontDialog())
			{
				fontDialog.ShowColor = true;
				fontDialog.Color = txtText.ForeColor;
				fontDialog.Font = txtText.Font;
				if (fontDialog.ShowDialog(this) == DialogResult.OK)
				{
					txtText.ForeColor = fontDialog.Color;
					txtText.Font = fontDialog.Font;
				}
			}
		}

		private void btnPageSettings_Click(object sender, EventArgs e)
		{
			using (dlgPageSetup dlgPageSetup = new dlgPageSetup())
			{
				dlgPageSetup.PageSettings = xpageSettings_0;
				if (dlgPageSetup.ShowDialog(this) == DialogResult.OK)
				{
					xpageSettings_0 = dlgPageSetup.PageSettings;
				}
			}
		}

		private void btnPreview_Click(object sender, EventArgs e)
		{
			using (PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog())
			{
				printPreviewDialog.Document = printDocument_0;
				printPreviewDialog.ShowDialog(this);
			}
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			using (PrintDialog printDialog = new PrintDialog())
			{
				printDialog.Document = printDocument_0;
				if (printDialog.ShowDialog(this) == DialogResult.OK)
				{
					printDocument_0.Print();
				}
			}
		}
	}
}
