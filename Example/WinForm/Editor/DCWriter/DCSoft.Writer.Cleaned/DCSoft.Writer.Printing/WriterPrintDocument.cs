using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Printing
{
	/// <summary>
	///       打印文档对象
	///       </summary>
	
	
	[ComVisible(false)]
	public sealed class WriterPrintDocument : XPrintDocument
	{
		private class Class41
		{
			private DocumentOptions documentOptions_0 = null;

			private PageViewMode pageViewMode_0 = PageViewMode.Page;

			private PrintPageCollection printPageCollection_0 = null;

			private PrintPageCollection printPageCollection_1 = null;

			public void method_0(XTextDocument xtextDocument_0)
			{
				documentOptions_0 = xtextDocument_0.Options;
				xtextDocument_0.Options = documentOptions_0.Clone();
				pageViewMode_0 = xtextDocument_0.PageViewMode;
				printPageCollection_0 = xtextDocument_0.Pages;
				printPageCollection_1 = xtextDocument_0.GlobalPages;
			}

			public void method_1(XTextDocument xtextDocument_0)
			{
				xtextDocument_0.Options = documentOptions_0;
				xtextDocument_0.PageViewMode = pageViewMode_0;
				xtextDocument_0.Pages = printPageCollection_0;
				xtextDocument_0.GlobalPages = printPageCollection_1;
			}
		}

		private float float_0 = 0f;

		private string string_1 = null;

		private bool bool_7 = false;

		private Dictionary<XTextDocument, Class41> dictionary_2 = new Dictionary<XTextDocument, Class41>();

		private List<XTextDocument> list_0 = new List<XTextDocument>();

		/// <summary>
		///       全局的文档打印前处理委托对象
		///       </summary>
		public static CancelEventHandler GlobalBeforePrintHandler = null;

		/// <summary>
		///       全局的文档打印后处理委托对象
		///       </summary>
		public static EventHandler GlobalAfterPrintHandler = null;

		private bool bool_8 = true;

		private WriterControl writerControl_0 = null;

		private XTextDocumentList xtextDocumentList_0 = new XTextDocumentList();

		/// <summary>
		///       正文位置偏移量
		///       </summary>
		
		public float BodyPositionOffset
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
			}
		}

		/// <summary>
		///       指定的文档名称
		///       </summary>
		
		[DefaultValue(null)]
		public string SpecifyDocumentName
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       整洁打印模式
		///       </summary>
		
		public bool CleanMode
		{
			get
			{
				return bool_7;
			}
			set
			{
				bool_7 = value;
			}
		}

		private bool RuntimeCleanMode
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_40))
				{
					return true;
				}
				if (CleanMode && !XTextDocument.smethod_13(GEnum6.const_41))
				{
					return false;
				}
				return CleanMode;
			}
		}

		/// <summary>
		///       异步打印
		///       </summary>
		/// <remarks>
		///       本属性默认为true，执行异步打印，程序向系统提交打印任务后立即返回；
		///       若该属性为false，则执行同步打印，程序向系统提交打印任务后等待打印任务完全完成后才返回。
		///       </remarks>
		[DefaultValue(true)]
		
		public bool AsyncPrint
		{
			get
			{
				return bool_8;
			}
			set
			{
				bool_8 = value;
			}
		}

		/// <summary>
		///       编辑器控件
		///       </summary>
		[Browsable(false)]
		public WriterControl WriterControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		
		[Browsable(false)]
		public XTextDocumentList Documents
		{
			get
			{
				return xtextDocumentList_0;
			}
			set
			{
				xtextDocumentList_0 = value;
			}
		}

		/// <summary>
		///       主文档对象
		///       </summary>
		[Browsable(false)]
		public XTextDocument RuntimeMainDocument
		{
			get
			{
				if (xtextDocumentList_0 == null || xtextDocumentList_0.Count == 0)
				{
					return null;
				}
				return xtextDocumentList_0[0];
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public WriterPrintDocument()
		{
			base.Options.PrinterName = WriterControl.GlobalDefaultPrinterName;
			base.PageDrawer = new Class104();
			base.PaintPage += method_9;
			base.PrinterSettings = new PrinterSettings();
			base.PrintController = new StandardPrintController();
		}

		/// <summary>
		///       显示打印机设置对话哭
		///       </summary>
		/// <param name="parent">所属父窗体</param>
		/// <returns>操作是否成功</returns>
		public override bool ShowPrintDialog(IWin32Window parent)
		{
			return Prompt(-1, parent);
		}

		/// <summary>
		///       显示打印机选中对话框
		///       </summary>
		/// <param name="specialPageIndex">指定的页码</param>
		/// <param name="parnet">对话框使用的父窗体</param>
		/// <returns>用户是否成功的设置</returns>
		
		public bool Prompt(int specialPageIndex, IWin32Window parnet)
		{
			using (PrintDialog printDialog = new PrintDialog())
			{
				string printerName = base.PrinterSettings.PrinterName;
				if (!string.IsNullOrEmpty(base.Options.PrinterName))
				{
					printerName = base.Options.PrinterName;
				}
				if (printerName == null || printerName.Trim().Length == 0)
				{
					printerName = RuntimeMainDocument.PageSettings.PrinterName;
				}
				if (printerName != null && printerName.Trim().Length > 0)
				{
					base.PrinterSettings.PrinterName = printerName;
				}
				printDialog.PrinterSettings = base.PrinterSettings;
				if (specialPageIndex < 0)
				{
					printDialog.AllowCurrentPage = true;
					printDialog.AllowSelection = true;
					printDialog.AllowSomePages = true;
				}
				JumpPrintInfo jumpPrint = base.Options.JumpPrint;
				if (jumpPrint != null && jumpPrint.Enabled && (jumpPrint.Position >= 0f || jumpPrint.EndPosition > 0f))
				{
					printDialog.AllowCurrentPage = false;
					printDialog.AllowSelection = false;
					printDialog.AllowSomePages = false;
				}
				if (base.Options.BoundsSelection != null && base.Options.BoundsSelection.Count > 0)
				{
					printDialog.AllowCurrentPage = false;
					printDialog.AllowSelection = false;
					printDialog.AllowSomePages = false;
				}
				if (printDialog.AllowSomePages || base.PrinterSettings.PrintRange == PrintRange.CurrentPage)
				{
					printDialog.PrinterSettings.MinimumPage = 1 + base.Options.GlobalPageIndexFix;
					int num = 0;
					foreach (XTextDocument document in Documents)
					{
						document.CheckPageRefreshed();
						num += document.Pages.Count;
					}
					printDialog.PrinterSettings.MaximumPage = num + base.Options.GlobalPageIndexFix;
					if (WriterControl != null && (WriterControl.StartPageIndex >= 0 || WriterControl.EndPageIndex >= 0))
					{
						if (WriterControl.StartPageIndex >= 0)
						{
							printDialog.PrinterSettings.FromPage = WriterControl.StartPageIndex + 1 + base.Options.GlobalPageIndexFix;
						}
						if (WriterControl.EndPageIndex >= 0)
						{
							printDialog.PrinterSettings.ToPage = WriterControl.EndPageIndex + 1 + base.Options.GlobalPageIndexFix;
						}
						else
						{
							printDialog.PrinterSettings.ToPage = num + base.Options.GlobalPageIndexFix;
						}
						printDialog.PrinterSettings.PrintRange = PrintRange.SomePages;
					}
					if (printDialog.PrinterSettings.FromPage == 0)
					{
						printDialog.PrinterSettings.FromPage = 1;
					}
					if (printDialog.PrinterSettings.ToPage == 0)
					{
						printDialog.PrinterSettings.ToPage = num;
					}
					printDialog.PrinterSettings.FromPage = Math.Min(num, printDialog.PrinterSettings.FromPage + base.Options.GlobalPageIndexFix);
					printDialog.PrinterSettings.ToPage = Math.Min(num, printDialog.PrinterSettings.ToPage + base.Options.GlobalPageIndexFix);
					if (WriterControl != null && base.PrinterSettings.PrintRange == PrintRange.CurrentPage)
					{
						printDialog.PrinterSettings.PrintRange = PrintRange.SomePages;
						printDialog.PrinterSettings.FromPage = WriterControl.CurrentPageIndex + base.Options.GlobalPageIndexFix + 1;
						printDialog.PrinterSettings.ToPage = WriterControl.CurrentPageIndex + base.Options.GlobalPageIndexFix + 1;
					}
				}
				printDialog.PrinterSettings.Collate = true;
				XTextDocument runtimeMainDocument = RuntimeMainDocument;
				bool flag = false;
				if (runtimeMainDocument != null && runtimeMainDocument.Options.BehaviorOptions.ExtendingPrintDialog)
				{
					flag = true;
					if (base.Options != null)
					{
						if (base.Options.BoundsSelection != null && base.Options.BoundsSelection.Enable)
						{
							flag = false;
						}
						if (base.Options.JumpPrint != null && base.Options.JumpPrint.Enabled)
						{
							flag = false;
						}
					}
					if (flag)
					{
						WinFormUtils.RunOnceDelay(method_4, 400);
					}
				}
				if (parnet == null)
				{
					parnet = WriterControl;
				}
				printDialog.UseEXDialog = true;
				GClass293.ReleaseCapture();
				if (base.CurrentDocumentPage == null)
				{
					printDialog.AllowCurrentPage = false;
				}
				if (printDialog.ShowDialog(parnet) == DialogResult.OK)
				{
					printDialog.PrinterSettings.FromPage -= base.Options.GlobalPageIndexFix;
					printDialog.PrinterSettings.ToPage -= base.Options.GlobalPageIndexFix;
					base.Options.PrintRange = printDialog.PrinterSettings.PrintRange;
					base.Options.FromPage = printDialog.PrinterSettings.FromPage;
					base.Options.ToPage = printDialog.PrinterSettings.ToPage;
					base.Options.PrinterName = null;
					base.Options.PaperSourceName = null;
					base.PrinterSettings = printDialog.PrinterSettings;
					if (flag)
					{
						base.Options.PrintMode = ExtPrintSettingsControl.LastSelectedPrintMode;
						if (base.Options.PrintMode == DCPrintMode.CurrentPage)
						{
							base.PrinterSettings.PrintRange = PrintRange.CurrentPage;
						}
					}
					XPageSettings xPageSettings = new XPageSettings();
					xPageSettings.StdPageSettings = printDialog.PrinterSettings.DefaultPageSettings;
					return true;
				}
				return false;
			}
		}

		private void method_4(object sender, EventArgs e)
		{
			GClass244 gClass = GClass244.smethod_1();
			if (gClass == null || !(gClass.Handle != DCSoft.Writer.Controls.dlgError.CurrentInstanceHandle))
			{
				return;
			}
			ExtPrintSettingsControl extPrintSettingsControl = new ExtPrintSettingsControl();
			extPrintSettingsControl.BorderStyle = BorderStyle.None;
			extPrintSettingsControl.CreateControl();
			extPrintSettingsControl.Dock = DockStyle.None;
			extPrintSettingsControl.Left = 10;
			extPrintSettingsControl.Top = gClass.method_5().Bottom - 40;
			GClass244[] array = gClass.method_38();
			int num = 0;
			if (array != null && array.Length > 0)
			{
				GClass244[] array2 = array;
				foreach (GClass244 gClass2 in array2)
				{
					num = Math.Max(num, gClass2.method_8().Top);
				}
			}
			if (num > 0)
			{
				extPrintSettingsControl.Top = gClass.method_7(0, num).Y - 3;
				if (base.CurrentDocumentPage != null)
				{
					extPrintSettingsControl.method_0(base.CurrentDocumentPage.PageIndex);
				}
			}
			extPrintSettingsControl.SelectedPrintMode = base.Options.PrintMode;
			GClass244 gClass3 = new GClass244(extPrintSettingsControl);
			gClass3.method_20(gClass.Handle);
			gClass3.method_34();
		}

		/// <summary>
		///       打印文档
		///       </summary>
		/// <param name="SpecialPageIndex">指定的要打印的页码序号</param>
		/// <returns>操作是否成功</returns>
		
		public bool PrintDocument(int SpecialPageIndex)
		{
			return method_8(SpecialPageIndex, bool_9: false);
		}

		/// <summary>
		///       为打印文档而更新文档状态
		///       </summary>
		/// <returns>操作是否成功</returns>
		
		public bool UpdateDocumentsState()
		{
			return method_8(-1, bool_9: true);
		}

		protected override void OnQueryPageSettings(QueryPageSettingsEventArgs queryPageSettingsEventArgs_0)
		{
			if (Documents != null)
			{
				foreach (XTextDocument document in Documents)
				{
					WriterPrintQueryPageSettingsEventArgs writerPrintQueryPageSettingsEventArgs = new WriterPrintQueryPageSettingsEventArgs(document, this, queryPageSettingsEventArgs_0, base.CurrentPrintingPage.GlobalIndex);
					document.method_34(writerPrintQueryPageSettingsEventArgs);
					if (writerPrintQueryPageSettingsEventArgs.Cancel)
					{
						return;
					}
				}
			}
			base.OnQueryPageSettings(queryPageSettingsEventArgs_0);
		}

		/// <summary>
		///       处理打印一页事件
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnPrintPage(PrintPageEventArgs printPageEventArgs_0)
		{
			PrintPage currentPrintingPage = base.CurrentPrintingPage;
			XTextDocument xTextDocument = null;
			XTextDocument xTextDocument2 = null;
			GraphicsState gstate = printPageEventArgs_0.Graphics.Save();
			if (currentPrintingPage != null)
			{
				if (Class103.smethod_4().method_6())
				{
					using (StringFormat stringFormat = new StringFormat())
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append('南');
						stringBuilder.Append('京');
						stringBuilder.Append('都');
						stringBuilder.Append('昌');
						stringBuilder.Append('信');
						stringBuilder.Append('息');
						stringBuilder.Append('科');
						stringBuilder.Append('技');
						stringBuilder.Append('有');
						stringBuilder.Append('限');
						stringBuilder.Append('公');
						stringBuilder.Append('司');
						stringBuilder.Append('版');
						stringBuilder.Append('权');
						stringBuilder.Append('所');
						stringBuilder.Append('有');
						string s = stringBuilder.ToString();
						stringFormat.Alignment = StringAlignment.Near;
						stringFormat.LineAlignment = StringAlignment.Near;
						printPageEventArgs_0.Graphics.DrawString(s, XFontValue.font_0, Brushes.Black, printPageEventArgs_0.PageBounds.Left + 20, printPageEventArgs_0.PageBounds.Top + 20);
					}
				}
				xTextDocument2 = (XTextDocument)currentPrintingPage.Document;
				base.PageDrawer.method_27(xTextDocument2.PageSettings.RuntimePageBorderBackground);
				xTextDocument2.States.JumpPrintModeForCurrentPage = JumpPrintMode.Disable;
				base.DrawWatermark = true;
				if (base.Options.BoundsSelection != null && base.Options.BoundsSelection.Count > 0 && base.Options.BoundsSelection.Enable)
				{
					base.DrawWatermark = false;
				}
				if (base.Options.JumpPrint != null && base.Options.JumpPrint.Enabled && base.Options.JumpPrint.PageIndex >= 0)
				{
					if (base.Options.JumpPrint.Mode == JumpPrintMode.Normal)
					{
						if (currentPrintingPage.GlobalIndex == base.Options.JumpPrint.PageIndex)
						{
							xTextDocument2.States.JumpPrintModeForCurrentPage = JumpPrintMode.Normal;
							xTextDocument = xTextDocument2;
							base.DrawWatermark = false;
						}
					}
					else if (base.Options.JumpPrint.Mode == JumpPrintMode.Append)
					{
						if (currentPrintingPage.GlobalIndex == 0)
						{
							xTextDocument2.States.JumpPrintModeForCurrentPage = JumpPrintMode.Append;
							base.DrawWatermark = false;
						}
					}
					else if (base.Options.JumpPrint.Mode == JumpPrintMode.Offset && currentPrintingPage.GlobalIndex == 0)
					{
						base.DrawWatermark = false;
					}
				}
				if (xTextDocument2.Options.BehaviorOptions.SpecifyDebugMode)
				{
					_ = printPageEventArgs_0.PageSettings.PrintableArea;
					printPageEventArgs_0.Graphics.PageUnit = GraphicsUnit.Display;
					RectangleF rectangleF = new RectangleF(0f, 0f, printPageEventArgs_0.PageSettings.Margins.Left, printPageEventArgs_0.PageSettings.Margins.Top);
					printPageEventArgs_0.Graphics.DrawLine(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
					printPageEventArgs_0.Graphics.DrawLine(Pens.Black, rectangleF.Left, rectangleF.Bottom, rectangleF.Right, rectangleF.Top);
					printPageEventArgs_0.Graphics.DrawRectangle(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
					rectangleF = printPageEventArgs_0.PageSettings.Bounds;
					rectangleF = new RectangleF(rectangleF.Width - (float)printPageEventArgs_0.PageSettings.Margins.Right, rectangleF.Height - (float)printPageEventArgs_0.PageSettings.Margins.Bottom, printPageEventArgs_0.PageSettings.Margins.Right, printPageEventArgs_0.PageSettings.Margins.Bottom);
					printPageEventArgs_0.Graphics.DrawLine(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
					printPageEventArgs_0.Graphics.DrawLine(Pens.Black, rectangleF.Left, rectangleF.Bottom, rectangleF.Right, rectangleF.Top);
					printPageEventArgs_0.Graphics.DrawRectangle(Pens.Black, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
				}
			}
			try
			{
				if (xTextDocument2 != null)
				{
					WriterPrintPageEventEventArgs writerPrintPageEventEventArgs = new WriterPrintPageEventEventArgs(xTextDocument2, this, printPageEventArgs_0, base.CurrentPrintingPage.GlobalIndex);
					xTextDocument2.method_35(writerPrintPageEventEventArgs);
					if (writerPrintPageEventEventArgs.Cancel)
					{
						return;
					}
				}
				base.OnPrintPage(printPageEventArgs_0);
			}
			finally
			{
				if (xTextDocument != null)
				{
					xTextDocument.States.JumpPrintModeForCurrentPage = JumpPrintMode.Disable;
				}
			}
			if (Class103.smethod_4().method_38())
			{
				string text = "[试用版，请联系南京都昌信息科技有限公司进行注册]";
				WatermarkInfo watermarkInfo = new WatermarkInfo();
				watermarkInfo.Text = text;
				watermarkInfo.Font = new XFontValue(XFontValue.DefaultFontName, 30f);
				watermarkInfo.Color = Color.Red;
				watermarkInfo.Type = WatermarkType.Text;
				watermarkInfo.Alpha = 100;
				watermarkInfo.Angle = -45f;
				printPageEventArgs_0.Graphics.Restore(gstate);
				watermarkInfo.method_4(printPageEventArgs_0.PageBounds, new DCGraphics(printPageEventArgs_0.Graphics), printPageEventArgs_0.PageBounds);
			}
		}

		/// <summary>
		///       开始打印任务
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnBeginPrint(PrintEventArgs printEventArgs_0)
		{
			if (base.Options != null)
			{
				if (!XTextDocument.smethod_13(GEnum6.const_46))
				{
					base.Options.SpecifyPageIndexs = null;
				}
				if (!XTextDocument.smethod_13(GEnum6.const_42) && base.Options.JumpPrint != null && base.Options.JumpPrint.Mode == JumpPrintMode.Normal)
				{
					base.Options.JumpPrint = null;
				}
				if (!XTextDocument.smethod_13(GEnum6.const_43) && base.Options.JumpPrint != null && base.Options.JumpPrint.Mode == JumpPrintMode.Offset)
				{
					base.Options.JumpPrint = null;
				}
				if (!XTextDocument.smethod_13(GEnum6.const_45))
				{
					base.Options.BoundsSelection = null;
				}
			}
			if (Documents != null)
			{
				foreach (XTextDocument document in Documents)
				{
					document.method_43();
					document.PageSettings.method_2(base.DefaultPageSettings.PrinterSettings);
					WriterPrintEventEventArgs writerPrintEventEventArgs = new WriterPrintEventEventArgs(document, this, printEventArgs_0);
					document.method_33(writerPrintEventEventArgs);
					if (writerPrintEventEventArgs.Cancel)
					{
						return;
					}
				}
				List<int> list = new List<int>();
				if (base.Options.BoundsSelection != null && base.Options.BoundsSelection.Enable)
				{
					foreach (BoundsSelectionPrintInfoItem item in base.Options.BoundsSelection)
					{
						if (item.PageIndex >= 0 && !list.Contains(item.PageIndex))
						{
							list.Add(item.PageIndex);
						}
					}
				}
				else if (base.PrinterSettings.PrintRange == PrintRange.Selection)
				{
					foreach (XTextDocument document2 in Documents)
					{
						XTextSelection selection = document2.Body.Selection;
						float num = float.MaxValue;
						float num2 = float.MinValue;
						foreach (XTextElement contentElement in selection.ContentElements)
						{
							float absTop = contentElement.AbsTop;
							if (absTop > 0f)
							{
								num = Math.Min(num, absTop);
								num2 = Math.Max(num2, absTop + contentElement.Height);
							}
						}
						if (selection.Cells != null)
						{
							foreach (XTextTableCellElement cell in selection.Cells)
							{
								float absTop = cell.AbsTop;
								if (absTop > 0f)
								{
									num = Math.Min(num, absTop);
									num2 = Math.Max(num2, absTop + cell.Height);
								}
							}
						}
						if (num != float.MaxValue)
						{
							for (int i = 0; i < document2.Pages.Count; i++)
							{
								PrintPage printPage = document2.Pages[i];
								if (printPage.Top < num2 - 2f && printPage.Bottom > num + 2f)
								{
									list.Add(printPage.PageIndex);
								}
							}
						}
					}
				}
				else
				{
					foreach (XTextDocument document3 in Documents)
					{
						document3.States.Printing = true;
						document3.States.PrintPreviewing = (printEventArgs_0.PrintAction == PrintAction.PrintToPreview);
						document3.States.RenderMode = DocumentRenderMode.Print;
						base.Options.ShowDebugMessage = document3.Options.BehaviorOptions.ShowDebugMessage;
						base.ForPOSPrinter = document3.PageSettings.RuntimeForPOSPrinter;
						if (document3.BoundsSelection != null && document3.BoundsSelection.Enable)
						{
							foreach (BoundsSelectionPrintInfoItem item2 in document3.BoundsSelection)
							{
								if (item2.PageIndex >= 0)
								{
									list.Add(item2.PageIndex);
								}
							}
						}
					}
				}
				if (list.Count > 0)
				{
					base.Options.SpecifyPageIndexs = list;
				}
			}
			base.OnBeginPrint(printEventArgs_0);
		}

		/// <summary>
		///       结束打印任务
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnEndPrint(PrintEventArgs printEventArgs_0)
		{
			if (!printEventArgs_0.Cancel && Documents != null)
			{
				foreach (XTextDocument document in Documents)
				{
					document.States.Printing = false;
					document.States.PrintPreviewing = false;
					document.States.RenderMode = DocumentRenderMode.Print;
					WriterPrintEventEventArgs writerPrintEventEventArgs = new WriterPrintEventEventArgs(document, this, printEventArgs_0);
					document.method_36(writerPrintEventEventArgs);
					if (writerPrintEventEventArgs.Cancel)
					{
						return;
					}
				}
			}
			base.OnEndPrint(printEventArgs_0);
			if (!printEventArgs_0.Cancel && base.PrintPageFlag)
			{
				if (Documents != null)
				{
					foreach (XTextDocument document2 in Documents)
					{
						if (!base.GeneratingPreviewContent)
						{
							if (document2.EditorControl != null)
							{
								document2.EditorControl.LastPrintResult = base.CurrentPrintResult;
							}
							document2.LastPrintResult = base.CurrentPrintResult;
						}
					}
				}
				if (base.CurrentPrintResult != null && Documents != null)
				{
					foreach (XTextDocument document3 in Documents)
					{
						foreach (XTextElement element in document3.Body.Elements)
						{
							if (element is XTextSubDocumentElement)
							{
								XTextSubDocumentElement xTextSubDocumentElement = (XTextSubDocumentElement)element;
								xTextSubDocumentElement.Printed = false;
							}
						}
					}
				}
			}
		}

		
		public void method_5(CancelEventArgs cancelEventArgs_0)
		{
			if (!(base.PrintController is PreviewPrintController) && GlobalBeforePrintHandler != null)
			{
				GlobalBeforePrintHandler(this, cancelEventArgs_0);
			}
		}

		
		public void method_6(EventArgs eventArgs_0)
		{
			if (!(base.PrintController is PreviewPrintController))
			{
				foreach (PrintPageResult pageInfo in base.CurrentPrintResult.PageInfos)
				{
					PrintPage page = pageInfo.Page;
					XTextDocument xTextDocument = page.Document as XTextDocument;
					if (xTextDocument != null)
					{
						foreach (XTextElement element in xTextDocument.Body.Elements)
						{
							if (element is XTextSubDocumentElement)
							{
								XTextSubDocumentElement xTextSubDocumentElement = (XTextSubDocumentElement)element;
								if (xTextSubDocumentElement.InnerPrintedFlag)
								{
									float absTop = xTextSubDocumentElement.AbsTop;
									xTextSubDocumentElement.Printed = true;
									xTextSubDocumentElement.PrintedPageIndex = page.PageIndex + xTextDocument.PageIndexfix;
									xTextSubDocumentElement.PrintPositionInPage = absTop - page.Top;
									xTextSubDocumentElement.Modified = true;
									xTextSubDocumentElement.UpdateContentVersion();
									xTextDocument.Modified = true;
								}
							}
						}
					}
				}
				if (GlobalAfterPrintHandler != null)
				{
					GlobalAfterPrintHandler(this, EventArgs.Empty);
				}
			}
		}

		private void method_7(PrinterSettings printerSettings_0)
		{
			if (WriterControl != null && WriterControl.DocumentOptions.BehaviorOptions.ForceCollateWhenPrint)
			{
				printerSettings_0.Collate = true;
			}
			if (Documents != null && Documents.Count > 0 && Documents[0].Options.BehaviorOptions.ForceCollateWhenPrint)
			{
				printerSettings_0.Collate = true;
			}
		}

		private bool method_8(int int_5, bool bool_9)
		{
			int num = 8;
			XTextDocument xTextDocument = null;
			if (Documents.Count > 0)
			{
				xTextDocument = Documents[0];
				dictionary_2 = new Dictionary<XTextDocument, Class41>();
				list_0 = new List<XTextDocument>();
				XTextDocumentList xTextDocumentList = Documents.Clone();
				if (!XTextDocument.smethod_13(GEnum6.const_37) && !XTextDocument.smethod_13(GEnum6.const_38))
				{
					xTextDocumentList = new XTextDocumentList();
					xTextDocumentList.Add(xTextDocument);
				}
				bool flag = false;
				if (!XTextDocument.smethod_13(GEnum6.const_44))
				{
					flag = false;
				}
				if (flag)
				{
					xTextDocumentList = new XTextDocumentList();
					foreach (XTextDocument document in Documents)
					{
						if (document.Selection.Length != 0)
						{
							XTextDocument xTextDocument2 = document.Selection.CreateDocument();
							xTextDocumentList.Add(xTextDocument2);
							if (RuntimeCleanMode)
							{
								xTextDocument2.Options.SecurityOptions.ShowLogicDeletedContent = false;
								xTextDocument2.Options.SecurityOptions.ShowPermissionMark = false;
							}
							xTextDocument2.PageRefreshed = false;
							xTextDocument2.CheckPageRefreshed();
						}
					}
					if (xTextDocumentList.Count == 0)
					{
						return false;
					}
				}
				try
				{
					if (WriterControl != null)
					{
						WriterControl.InnerViewControl.FreezeUI();
					}
					foreach (XTextDocument item in xTextDocumentList)
					{
						item.States.Printing = true;
						bool flag2 = false;
						if (item.EditorControl == null || !item.PageRefreshed || item.SizeInvalid)
						{
							flag2 = true;
						}
						else if (item.EditorControl != null && item.EditorControl.ViewMode == PageViewMode.AutoLine)
						{
							flag2 = true;
						}
						else if (!base.Options.DisableRefreshDocumentLayout || flag)
						{
							foreach (XTextElement item2 in new DomTreeNodeEnumerable(item.Elements))
							{
								if (item2 is XTextTableElement)
								{
									XTextTableElement xTextTableElement = (XTextTableElement)item2;
									if ((item.PageViewMode == PageViewMode.Normal || item.PageViewMode == PageViewMode.NormalCenter || item.PageViewMode == PageViewMode.AutoLine) && xTextTableElement.HasHeaderRow)
									{
										flag2 = true;
										break;
									}
								}
								if (item2 is XTextInputFieldElementBase)
								{
									XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item2;
									if (item.Options.ViewOptions.IgnoreFieldBorderWhenPrint && item.Options.ViewOptions.ShowFieldBorderElement)
									{
										flag2 = true;
										break;
									}
									if ((xTextInputFieldElementBase.Elements == null || xTextInputFieldElementBase.Elements.Count == 0) && !string.IsNullOrEmpty(xTextInputFieldElementBase.RuntimeBackgroundText))
									{
										flag2 = true;
										break;
									}
								}
								if (item2 is XTextFieldElementBase && item.Options.ViewOptions.IgnoreFieldBorderWhenPrint && item.Options.ViewOptions.ShowFieldBorderElement)
								{
									flag2 = true;
									break;
								}
								if (item2 is XTextObjectElement)
								{
									XTextObjectElement xTextObjectElement = (XTextObjectElement)item2;
									if (xTextObjectElement.PrintVisibility == ElementVisibility.None)
									{
										flag2 = true;
										break;
									}
								}
								if (item2 is XTextCheckBoxElementBase)
								{
									XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item2;
									if (!xTextCheckBoxElementBase.Checked && xTextCheckBoxElementBase.RuntimePrintVisibilityWhenUnchecked == PrintVisibilityModeWhenUnchecked.HiddenAll)
									{
										flag2 = true;
										break;
									}
								}
								if (item2 is XTextContainerElement)
								{
									XTextContainerElement xTextContainerElement = (XTextContainerElement)item2;
									if (xTextContainerElement.PrintVisibility == ElementVisibility.None)
									{
										flag2 = true;
										break;
									}
								}
								if (RuntimeCleanMode && item.Options.SecurityOptions.ShowLogicDeletedContent && item2.RuntimeStyle.DeleterIndex >= 0)
								{
									flag2 = true;
									break;
								}
							}
						}
						if (!base.Options.DisableRefreshDocumentLayout && RuntimeCleanMode)
						{
							Class41 @class = new Class41();
							@class.method_0(item);
							dictionary_2[item] = @class;
							if (item.Options.SecurityOptions.ShowLogicDeletedContent || item.Options.SecurityOptions.ShowPermissionMark)
							{
								item.Options.SecurityOptions.ShowLogicDeletedContent = false;
								item.Options.SecurityOptions.ShowPermissionMark = false;
								item.States.Printing = true;
								flag2 = true;
							}
						}
						if (flag2)
						{
							list_0.Add(item);
							if (!dictionary_2.ContainsKey(item))
							{
								Class41 @class = new Class41();
								@class.method_0(item);
								dictionary_2[item] = @class;
							}
							item.PageViewMode = PageViewMode.Page;
							int num2 = item.Pages.IndexOf(base.CurrentDocumentPage);
							item.method_97(bool_32: true, bool_33: false);
							item.RefreshSizeWithoutParamter();
							item.ExecuteLayout();
							item.RefreshPages();
							if (num2 >= 0 && num2 < item.Pages.Count)
							{
								base.CurrentDocumentPage = item.Pages[num2];
							}
							else
							{
								base.CurrentDocumentPage = null;
							}
							if (!flag)
							{
							}
						}
					}
					base.Pages = new PrintPageCollection();
					foreach (XTextDocument item3 in xTextDocumentList)
					{
						if (item3.Options.BehaviorOptions.AutoIgnoreLastEmptyPage)
						{
							int num3 = item3.Pages.Count - 1;
							if (item3.LastPageIsEmpty)
							{
								num3--;
							}
							for (int i = 0; i <= num3; i++)
							{
								base.Pages.Add(item3.Pages[i]);
							}
						}
						else
						{
							base.Pages.AddRange(item3.Pages);
						}
					}
					foreach (XTextDocument item4 in xTextDocumentList)
					{
						item4.GlobalPages = base.Pages;
					}
					if (!string.IsNullOrEmpty(SpecifyDocumentName))
					{
						base.DocumentName = SpecifyDocumentName;
					}
					else if (xTextDocumentList.Count > 0)
					{
						if (xTextDocument.Info.Title != null)
						{
							base.DocumentName = xTextDocument.Info.Title;
						}
						else
						{
							base.DocumentName = "DCSoft.Writer document";
						}
					}
					if (!bool_9)
					{
						method_7(base.PrinterSettings);
						foreach (XTextDocument item5 in xTextDocumentList)
						{
							item5.States.Printing = false;
						}
						try
						{
							if (int_5 >= 0 && int_5 < base.Pages.Count)
							{
								PrintSpecialPage(int_5);
							}
							else
							{
								CancelEventArgs cancelEventArgs = new CancelEventArgs();
								cancelEventArgs.Cancel = false;
								method_5(cancelEventArgs);
								if (!cancelEventArgs.Cancel)
								{
									DCPrint(WriterControl);
									method_6(EventArgs.Empty);
								}
							}
							if (WriterControl != null)
							{
								WriterControl.SetStatusText(WriterStringsCore.PrintComplete);
							}
						}
						finally
						{
							foreach (XTextDocument item6 in xTextDocumentList)
							{
								if (item6.EditorControl != null)
								{
									item6.EditorControl.LastPrintResult = base.CurrentPrintResult;
								}
							}
							if (!flag)
							{
								foreach (XTextDocument item7 in xTextDocumentList)
								{
									item7.GlobalPages = null;
									if (item7.States.Printing)
									{
										item7.States.Printing = false;
										item7.States.PrintPreviewing = false;
										item7.Info.LastPrintTime = item7.GetNowDateTime();
									}
								}
								RestoreDocumentsState();
							}
						}
						bool flag3 = false;
						if (!AsyncPrint)
						{
							flag3 = WaitForExit(Environment.UserInteractive);
						}
						flag3 = ((base.PrintedPageCount > 0) ? true : false);
						if (flag)
						{
							foreach (XTextDocument item8 in xTextDocumentList)
							{
								item8.Dispose();
							}
							xTextDocumentList = null;
						}
						return flag3;
					}
					return true;
				}
				finally
				{
					if (xTextDocumentList != null)
					{
						foreach (XTextDocument item9 in xTextDocumentList)
						{
							item9.States.Printing = false;
							item9.States.PrintPreviewing = false;
						}
						xTextDocumentList = null;
					}
					if (WriterControl != null)
					{
						WriterControl.InnerViewControl.ReleaseFreezeUI();
					}
				}
			}
			return false;
		}

		/// <summary>
		///       恢复文档状态
		///       </summary>
		
		public void RestoreDocumentsState()
		{
			if (xtextDocumentList_0 != null)
			{
				foreach (XTextDocument item in xtextDocumentList_0)
				{
					item.States.Printing = false;
				}
			}
			if (dictionary_2 != null && dictionary_2.Count > 0)
			{
				foreach (XTextDocument key in dictionary_2.Keys)
				{
					dictionary_2[key].method_1(key);
				}
			}
			dictionary_2 = null;
			if (list_0 != null && list_0.Count > 0)
			{
				foreach (XTextDocument item2 in list_0)
				{
					item2.States.Printing = false;
					item2.method_97(bool_32: true, bool_33: false);
					item2.RefreshSizeWithoutParamter();
					item2.ExecuteLayout();
					item2.RefreshPages();
				}
			}
			list_0 = null;
		}

		private void method_9(object sender, EventArgs e)
		{
			XPrintDocument xPrintDocument = (XPrintDocument)sender;
			XTextDocument xTextDocument = (XTextDocument)xPrintDocument.CurrentPrintingPage.Document;
			xTextDocument.CurrentPage = xPrintDocument.CurrentPrintingPage;
			xTextDocument.States.Printing = true;
			if (WriterControl != null)
			{
				WriterControl.SetStatusText(string.Format(WriterStringsCore.PrintPage_PageIndex, xTextDocument.PageIndex + 1));
			}
		}

		/// <summary>
		///       根据编辑控件添加文档内容
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		
		public void AddDocumentByWriterControl(WriterControl writerControl_1)
		{
			Documents.Add(writerControl_1.Document);
			if (writerControl_1.JumpPrint != null)
			{
				base.Options.JumpPrint = writerControl_1.JumpPrint.Clone();
			}
			if (writerControl_1.BoundsSelection != null)
			{
				base.Options.BoundsSelection = writerControl_1.BoundsSelection.Clone();
			}
			base.Options.GlobalPageIndexFix = writerControl_1.Document.PageIndexfix;
		}
	}
}
