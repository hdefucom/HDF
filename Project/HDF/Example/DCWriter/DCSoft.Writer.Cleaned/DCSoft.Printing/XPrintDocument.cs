using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印报表的打印文档对象
	///       </summary>
	/// <remarks>本打印文档对象专门用于实现报表文档的打印输出</remarks>
	[Browsable(false)]
	[ComVisible(false)]
	[DCInternal]
	[DocumentComment]
	[ToolboxItem(false)]
	public class XPrintDocument : PrintDocument
	{
		private bool bool_0 = false;

		private PrintResult printResult_0 = new PrintResult();

		private bool bool_1 = false;

		private int int_0 = 0;

		private PrintJob printJob_0 = null;

		private PrintPageCollection printPageCollection_0 = new PrintPageCollection();

		private IEnumerator ienumerator_0 = null;

		private PrintPage printPage_0 = null;

		private DCPrintDocumentOptions dcprintDocumentOptions_0 = null;

		private int int_1 = 0;

		private PrintPageCollection printPageCollection_1 = null;

		protected bool bool_2 = true;

		private int int_2 = 0;

		private string string_0 = null;

		private int int_3 = 0;

		private int int_4 = 0;

		private DocumentPageDrawer gclass100_0 = new DocumentPageDrawer();

		private bool bool_3 = false;

		private bool bool_4 = true;

		private bool bool_5 = false;

		private static Dictionary<string, PointF> dictionary_0 = new Dictionary<string, PointF>();

		private Dictionary<PrintPage, SimpleRectangleTransform> dictionary_1 = new Dictionary<PrintPage, SimpleRectangleTransform>();

		private EventHandler eventHandler_0 = null;

		private static bool bool_6 = false;

		/// <summary>
		///       使用POS打印机进行打印
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool ForPOSPrinter
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       当前打印结果信息对象
		///       </summary>
		public PrintResult CurrentPrintResult
		{
			get
			{
				if (printResult_0 == null)
				{
					printResult_0 = new PrintResult();
				}
				return printResult_0;
			}
			set
			{
				printResult_0 = value;
			}
		}

		/// <summary>
		///       正在生成预览用的内容
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public bool GeneratingPreviewContent
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       总页数
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public int TotalPages
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       打印任务
		///       </summary>
		[DCInternal]
		public PrintJob PrintJob => printJob_0;

		/// <summary>
		///       需要打印的文档页集合
		///       </summary>
		[Browsable(false)]
		public PrintPageCollection Pages
		{
			get
			{
				return printPageCollection_0;
			}
			set
			{
				printPageCollection_0 = value;
			}
		}

		/// <summary>
		///       当前文档页对象
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public PrintPage CurrentDocumentPage
		{
			get
			{
				return printPage_0;
			}
			set
			{
				printPage_0 = value;
			}
		}

		/// <summary>
		///       当前打印的页
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public PrintPage CurrentPrintingPage
		{
			get
			{
				if (ienumerator_0 == null)
				{
					return null;
				}
				return (PrintPage)ienumerator_0.Current;
			}
		}

		/// <summary>
		///       打印文档选项
		///       </summary>
		[DCPublishAPI]
		public DCPrintDocumentOptions Options
		{
			get
			{
				if (dcprintDocumentOptions_0 == null)
				{
					dcprintDocumentOptions_0 = new DCPrintDocumentOptions();
				}
				return dcprintDocumentOptions_0;
			}
			set
			{
				dcprintDocumentOptions_0 = value;
			}
		}

		/// <summary>
		///       实际参与打印的文档页列表
		///       </summary>
		[DCPublishAPI]
		public PrintPageCollection PrintedPages => printPageCollection_1;

		/// <summary>
		///       实际累计打印的总页数
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		public int PrintedPageCount
		{
			get
			{
				return int_4;
			}
			set
			{
				int_4 = value;
			}
		}

		/// <summary>
		///       页面内容绘制器
		///       </summary>
		[DCInternal]
		[Browsable(false)]
		public DocumentPageDrawer PageDrawer
		{
			get
			{
				return gclass100_0;
			}
			set
			{
				gclass100_0 = value;
			}
		}

		/// <summary>
		///       PrintPage方法执行标记
		///       </summary>
		public bool PrintPageFlag => bool_3;

		/// <summary>
		///       是否打印水印
		///       </summary>
		[DCPublishAPI]
		public bool DrawWatermark
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		/// <summary>
		///       正在执行打印预览
		///       </summary>
		[DCInternal]
		[DCPublishAPI]
		public bool ForPrintPreview
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       各个页面的正文视图内容到打印内容的坐标转换信息字典
		///       </summary>
		[DCInternal]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Dictionary<PrintPage, SimpleRectangleTransform> PageBodyContentTransform => dictionary_1;

		/// <summary>
		///       绘制一页文档前触发的事件
		///       </summary>
		public event EventHandler PaintPage
		{
			add
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		public XPrintDocument()
		{
			base.PrintController = new StandardPrintController();
		}

		/// <summary>
		///       显示打印机选择对话框
		///       </summary>
		/// <param name="parent">对话框所示父窗体</param>
		/// <returns>操作是否成功</returns>
		public virtual bool ShowPrintDialog(IWin32Window parent)
		{
			using (PrintDialog printDialog = new PrintDialog())
			{
				printDialog.Document = this;
				if (CurrentDocumentPage == null)
				{
					printDialog.AllowCurrentPage = false;
				}
				if (printDialog.ShowDialog(parent) == DialogResult.OK)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       执行打印任务
		///       </summary>
		/// <param name="parent">弹出的对话框使用的父窗体</param>
		[DCPublishAPI]
		public void DCPrint(IWin32Window parent)
		{
			smethod_0();
			List<int> list = null;
			if (Options.SpecifyPageIndexs != null)
			{
				list = new List<int>();
				foreach (int specifyPageIndex in Options.SpecifyPageIndexs)
				{
					list.Add(specifyPageIndex);
				}
			}
			if (Options.PrintMode == DCPrintMode.ManualDuplex)
			{
				PrintWithManualDuplex(parent);
			}
			else if (Options.PrintMode == DCPrintMode.CurrentPage)
			{
				PrintSpecialPage(Pages.IndexOf(CurrentDocumentPage));
			}
			else
			{
				Print();
			}
			Options.SpecifyPageIndexs = list;
		}

		/// <summary>
		///       结束打印任务
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnEndPrint(PrintEventArgs printEventArgs_0)
		{
			if (CurrentPrintResult.PageInfos.Count > 0)
			{
				CurrentPrintResult.PageInfos[CurrentPrintResult.PageInfos.Count - 1].TickSpan = Environment.TickCount - int_3;
			}
			base.OnEndPrint(printEventArgs_0);
			if (!printEventArgs_0.Cancel)
			{
				if (Options.PreparePrintJob)
				{
					printJob_0 = null;
					GClass158 gClass = new GClass158(base.PrinterSettings.PrinterName);
					foreach (PrintJob item in gClass.method_5())
					{
						if (item.Document == base.DocumentName)
						{
							printJob_0 = item;
							break;
						}
					}
				}
				if (CurrentPrintResult.State == PrintResultStates.PartialPrinted)
				{
					CurrentPrintResult.State = PrintResultStates.CompletePrinted;
				}
				CurrentPrintResult.EndTime = DateTime.Now;
				CurrentPrintResult.TotalTickSpan = Environment.TickCount - int_2;
			}
			else
			{
				CurrentPrintResult.UserCancel = true;
			}
		}

		/// <summary>
		///       等待打印任务完成
		///       </summary>
		/// <param name="showUI">是否显示等待对话框</param>
		/// <returns>打印操作是否成功</returns>
		[DCPublishAPI]
		public bool WaitForExit(bool showUI)
		{
			if (printJob_0 == null)
			{
				return true;
			}
			if (showUI && Environment.UserInteractive)
			{
				using (dlgWaitPrintJob dlgWaitPrintJob = new dlgWaitPrintJob())
				{
					dlgWaitPrintJob.PrintJob = printJob_0;
					if (dlgWaitPrintJob.ShowDialog() == DialogResult.OK)
					{
						return true;
					}
					return false;
				}
			}
			return printJob_0.WaitForExit(null);
		}

		/// <summary>
		///       执行手动双面打印
		///       </summary>
		[DCPublishAPI]
		public void PrintWithManualDuplex(IWin32Window promptParent)
		{
			try
			{
				Options.PrintMode = DCPrintMode.ManualDuplex;
				int_1 = 1;
				Print();
				if (!CurrentPrintResult.UserCancel && int_1 == 2)
				{
					string text = base.DocumentName;
					if (string.IsNullOrEmpty(text))
					{
						text = Application.ProductName;
					}
					if (MessageBox.Show(promptParent, PrintingResources.PromptManualDuplex, text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
					{
						Print();
					}
				}
			}
			finally
			{
				int_1 = 0;
			}
		}

		private bool method_0(int int_5)
		{
			if (Options.SpecifyPageIndexs != null && Options.SpecifyPageIndexs.Count > 0)
			{
				int num = 0;
				while (true)
				{
					if (num < Options.SpecifyPageIndexs.Count)
					{
						if (Options.SpecifyPageIndexs[num] == int_5)
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				return true;
			}
			return true;
		}

		/// <summary>
		///       打印指定页
		///       </summary>
		/// <param name="vPageIndex">指定页号</param>
		[DCPublishAPI]
		public void PrintSpecialPage(int vPageIndex)
		{
			base.PrinterSettings.PrintRange = PrintRange.CurrentPage;
			printPage_0 = printPageCollection_0[vPageIndex];
			Print();
		}

		protected virtual void vmethod_0(GClass157 gclass157_0)
		{
		}

		/// <summary>
		///       已重载:开始打印文档
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnBeginPrint(PrintEventArgs printEventArgs_0)
		{
			int num = 4;
			int_2 = Environment.TickCount;
			int_3 = int_2;
			CurrentPrintResult.InitalizeTickSpan = 0;
			string_0 = null;
			if (printEventArgs_0.PrintAction == PrintAction.PrintToPreview)
			{
				bool_5 = true;
			}
			bool_3 = false;
			dictionary_1.Clear();
			CurrentPrintResult = new PrintResult();
			TotalPages = 0;
			if (!method_3())
			{
				printEventArgs_0.Cancel = true;
			}
			string printerName = Options.PrinterName;
			if ((printerName == null || printerName.Trim().Length == 0) && CurrentDocumentPage != null)
			{
				printerName = CurrentDocumentPage.PageSettings.PrinterName;
			}
			if (printerName != null && printerName.Trim().Length > 0)
			{
				printerName = printerName.Trim();
				foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
				{
					if (string.Compare(printerName, installedPrinter, ignoreCase: true) == 0)
					{
						base.DefaultPageSettings.PrinterSettings.PrinterName = installedPrinter;
						base.PrinterSettings.PrinterName = installedPrinter;
						break;
					}
				}
			}
			string paperSourceName = Options.PaperSourceName;
			if (paperSourceName != null && paperSourceName.Trim().Length > 0)
			{
				foreach (PaperSource paperSource in base.PrinterSettings.PaperSources)
				{
					if (paperSource.SourceName != null && string.Compare(paperSource.SourceName.Trim(), paperSourceName.Trim(), ignoreCase: true) == 0)
					{
						base.DefaultPageSettings.PaperSource = paperSource;
						break;
					}
				}
			}
			for (int i = 0; i < Pages.Count; i++)
			{
				if (Options.JumpPrint.Mode == JumpPrintMode.Append)
				{
					Pages[i].GlobalIndex = i + Options.JumpPrint.PageIndex;
				}
				else
				{
					Pages[i].GlobalIndex = i;
				}
			}
			int int_ = 0;
			if ((Options.JumpPrint.Mode == JumpPrintMode.Normal || Options.JumpPrint.Mode == JumpPrintMode.Offset) && Options.JumpPrint.PageIndex >= 0)
			{
				int_ = Options.JumpPrint.PageIndex;
			}
			GClass157 gClass = new GClass157();
			gClass.method_1(Options.PrintRange);
			gClass.method_3(Options.PrintMode);
			if (gClass.method_2() == DCPrintMode.CurrentPage)
			{
				gClass.method_1(PrintRange.CurrentPage);
			}
			gClass.method_9(Options.SpecifyPageIndexs);
			gClass.method_5(int_1);
			gClass.method_15(int_);
			gClass.method_17(base.PrinterSettings.FromPage);
			gClass.method_19(base.PrinterSettings.ToPage);
			gClass.method_11(base.PrinterSettings.Copies);
			if (Options.SpecifyCopies > 0)
			{
				gClass.method_11(Options.SpecifyCopies);
			}
			base.PrinterSettings.Copies = 1;
			gClass.method_13(base.PrinterSettings.Collate);
			gClass.method_21(CurrentDocumentPage);
			vmethod_0(gClass);
			PrintPageCollection printPageCollection = gClass.method_23(Pages);
			int_1 = gClass.method_4();
			if (Options.ShowDebugMessage)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("手动双面打印：" + int_1);
				stringBuilder.AppendLine("指定打印份数:" + Options.SpecifyCopies);
				stringBuilder.AppendLine("指定页码数:" + GClass369.smethod_6(Options.SpecifyPageIndexs));
				stringBuilder.AppendLine("实际要打印的页码数:" + GClass369.smethod_5(printPageCollection, "GlobalIndex"));
				stringBuilder.AppendLine("打印机:" + base.PrinterSettings.PrinterName);
				stringBuilder.AppendLine("标题:" + base.DocumentName);
				stringBuilder.AppendLine("纸张类型:" + base.DefaultPageSettings.PaperSize.Kind);
				MessageBox.Show(stringBuilder.ToString());
			}
			if (printPageCollection.Count == 0)
			{
				printEventArgs_0.Cancel = true;
				return;
			}
			foreach (PrintPage item in printPageCollection)
			{
				if (item.PageSettings != null && item.PageSettings.RuntimeForPOSPrinter)
				{
					ForPOSPrinter = true;
					break;
				}
			}
			if (ForPOSPrinter)
			{
				SizeF sizeF = new SizeF(0f, 0f);
				GraphicsUnit oldUnit = GraphicsUnit.Document;
				PrintPage printPage = null;
				PrintPageCollection printPageCollection2 = new PrintPageCollection();
				float num2 = 0f;
				foreach (PrintPage item2 in printPageCollection)
				{
					if (printPage == null || item2.ForNewPage)
					{
						printPage = item2.Clone();
						printPage.PageSettings = printPage.PageSettings.Clone();
						printPage.Width = 0f;
						printPageCollection2.Add(printPage);
						printPage.OwnerPages = printPageCollection2;
						num2 = 0f;
					}
					if (item2.Document != null)
					{
						oldUnit = item2.Document.DocumentGraphicsUnit;
					}
					printPage.Width = Math.Max(printPage.Width, item2.Width);
					num2 = (printPage.Height = num2 + item2.Height);
				}
				foreach (PrintPage item3 in printPageCollection2)
				{
					PaperSize paperSize = new PaperSize("Custom", (int)(GraphicsUnitConvert.Convert(item3.Width, oldUnit, GraphicsUnit.Inch) * 100f), (int)(GraphicsUnitConvert.Convert(item3.Height, oldUnit, GraphicsUnit.Inch) * 100f));
					item3.PageSettings.PaperSize = paperSize;
				}
				printPageCollection = printPageCollection2;
			}
			ienumerator_0 = printPageCollection.GetEnumerator();
			ienumerator_0.MoveNext();
			if (Options.PreparePrintJob)
			{
				printJob_0 = null;
				base.DocumentName = base.DocumentName + "$" + Environment.TickCount;
			}
			printPageCollection_1 = new PrintPageCollection();
			base.OnBeginPrint(printEventArgs_0);
			CurrentPrintResult.Title = base.DocumentName;
			CurrentPrintResult.StartTime = DateTime.Now;
			CurrentPrintResult.Copies = gClass.method_10();
			CurrentPrintResult.UserCancel = false;
		}

		/// <summary>
		///       已重载:查询页面设置
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnQueryPageSettings(QueryPageSettingsEventArgs queryPageSettingsEventArgs_0)
		{
			if (CurrentPrintResult.PageInfos.Count > 0)
			{
				CurrentPrintResult.PageInfos[CurrentPrintResult.PageInfos.Count - 1].TickSpan = Environment.TickCount - int_3;
			}
			int_3 = Environment.TickCount;
			base.OnQueryPageSettings(queryPageSettingsEventArgs_0);
			if (!method_3())
			{
				return;
			}
			XPageSettings xPageSettings = CurrentPrintingPage.PageSettings.Clone();
			if (string.IsNullOrEmpty(string_0))
			{
				string_0 = queryPageSettingsEventArgs_0.PageSettings.PrinterSettings.PrinterName;
			}
			xPageSettings.PrinterName = string_0;
			string printerName = xPageSettings.PrinterName;
			if (!ForPrintPreview && printerName != null && printerName.Trim().Length > 0)
			{
				printerName = printerName.Trim();
				foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
				{
					if (string.Compare(printerName, installedPrinter, ignoreCase: true) == 0)
					{
						queryPageSettingsEventArgs_0.PageSettings.PrinterSettings.PrinterName = installedPrinter;
						base.PrinterSettings.PrinterName = installedPrinter;
						string_0 = installedPrinter;
						break;
					}
				}
			}
			string paperSource = xPageSettings.PaperSource;
			if (!ForPrintPreview && paperSource != null && paperSource.Trim().Length > 0)
			{
				foreach (PaperSource paperSource2 in queryPageSettingsEventArgs_0.PageSettings.PrinterSettings.PaperSources)
				{
					if (string.Compare(paperSource2.SourceName, paperSource, ignoreCase: true) == 0)
					{
						queryPageSettingsEventArgs_0.PageSettings.PaperSource = paperSource2;
						break;
					}
				}
			}
			bool flag = false;
			if (!xPageSettings.RuntimeAutoFitPageSize && !ForPrintPreview)
			{
				if (xPageSettings.PaperKind == PaperKind.Custom || !xPageSettings.RuntimeAutoChoosePageSize)
				{
					PaperSize paperSize = XPageSettings.smethod_0(queryPageSettingsEventArgs_0.PageSettings, xPageSettings.PaperWidth, xPageSettings.PaperHeight, ForPrintPreview);
					queryPageSettingsEventArgs_0.PageSettings.PaperSize = paperSize;
					flag = true;
				}
				else
				{
					foreach (PaperSize item in XPageSettings.smethod_1(queryPageSettingsEventArgs_0.PageSettings.PrinterSettings))
					{
						if (xPageSettings.PaperKind == item.Kind)
						{
							queryPageSettingsEventArgs_0.PageSettings.PaperSize = item;
							flag = true;
							break;
						}
					}
				}
				queryPageSettingsEventArgs_0.PageSettings.Margins = xPageSettings.Margins;
			}
			if (!flag && (ForPrintPreview || base.PrintController is PreviewPrintController))
			{
				PaperSize paperSize = XPageSettings.smethod_0(queryPageSettingsEventArgs_0.PageSettings, xPageSettings.PaperWidth, xPageSettings.PaperHeight, ForPrintPreview);
				queryPageSettingsEventArgs_0.PageSettings.PaperSize = paperSize;
				flag = true;
			}
			queryPageSettingsEventArgs_0.PageSettings.Landscape = xPageSettings.Landscape;
			if (!ForPrintPreview)
			{
				CurrentPrintResult.PrinterName = base.PrinterSettings.PrinterName;
				CurrentPrintResult.PaperSourceName = queryPageSettingsEventArgs_0.PageSettings.PaperSource.SourceName;
				CurrentPrintResult.ClientName = SystemInformation.ComputerName;
			}
		}

		/// <summary>
		///       已重载:打印一页内容
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnPrintPage(PrintPageEventArgs printPageEventArgs_0)
		{
			base.OnPrintPage(printPageEventArgs_0);
			if (printPageEventArgs_0.Cancel)
			{
				return;
			}
			if (CurrentPrintResult.InitalizeTickSpan == 0)
			{
				CurrentPrintResult.InitalizeTickSpan = Environment.TickCount - int_2;
			}
			Options.PrintRange = printPageEventArgs_0.PageSettings.PrinterSettings.PrintRange;
			if (ienumerator_0 == null)
			{
				return;
			}
			PrintPage printPage = (PrintPage)ienumerator_0.Current;
			Rectangle rectangle_ = new Rectangle((int)Math.Floor(printPage.Left), (int)Math.Floor(printPage.Top), (int)Math.Ceiling(printPage.Width), (int)Math.Ceiling(printPage.Height));
			bool flag = false;
			bool flag2 = false;
			bool flag3 = true;
			PrintPageResult printPageResult = new PrintPageResult();
			printPageResult.Page = printPage;
			if (ForPOSPrinter)
			{
				XPageSettings pageSettings = printPage.PageSettings;
				printPageEventArgs_0.PageSettings.PaperSize = pageSettings.PaperSize;
				base.DefaultPageSettings.PaperSize = pageSettings.PaperSize;
				method_1(printPageEventArgs_0, printPage, printPageEventArgs_0.Graphics, rectangle_, bool_7: false, bool_8: false, printPageEventArgs_0, 0f);
			}
			else
			{
				if (Options.JumpPrint.Mode == JumpPrintMode.Normal || Options.JumpPrint.Mode == JumpPrintMode.Offset)
				{
					if (Pages.SafeGet(Options.JumpPrint.PageIndex) == printPage)
					{
						float position = Options.JumpPrint.Position;
						rectangle_.Offset(0, (int)position);
						rectangle_.Height -= (int)position;
						flag = true;
						if (position > 1f)
						{
							flag3 = Options.DrawFirstHeaderFooterWhenJumpPrintMode;
						}
					}
					if (Options.JumpPrint.EndPageIndex >= 0 && Options.JumpPrint.EndPosition < 1f && Pages.SafeGet(Options.JumpPrint.EndPageIndex - 1) == printPage)
					{
						flag2 = true;
					}
					if (!flag2 && Pages.SafeGet(Options.JumpPrint.EndPageIndex) == printPage && (Options.JumpPrint.EndPageIndex > Options.JumpPrint.PageIndex || Options.JumpPrint.EndPosition > Options.JumpPrint.Position))
					{
						flag = true;
						float position = Options.JumpPrint.EndPosition + printPage.Top;
						rectangle_.Height = (int)Math.Ceiling(position - (float)rectangle_.Top);
						flag2 = true;
					}
				}
				else if (Options.JumpPrint.Mode == JumpPrintMode.Append)
				{
					float position = Options.JumpPrint.Position;
					rectangle_.Offset(0, (int)position);
					rectangle_.Height -= (int)position;
					flag = true;
					if (position > 1f)
					{
						flag3 = Options.DrawFirstHeaderFooterWhenJumpPrintMode;
					}
				}
				method_1(printPageEventArgs_0, printPage, printPageEventArgs_0.Graphics, rectangle_, flag3, flag3, printPageEventArgs_0, 0f);
			}
			if (flag2)
			{
				printPageEventArgs_0.HasMorePages = false;
			}
			else
			{
				printPageEventArgs_0.HasMorePages = ienumerator_0.MoveNext();
			}
			int_4++;
			int_0++;
			Pages.IndexOf(printPage);
			CurrentPrintResult._SuccessedPageIndexs.Add(printPage.PageIndex);
			CurrentPrintResult.Position = rectangle_.Bottom;
			if (flag)
			{
				CurrentPrintResult.JumpPrintMode = true;
			}
			if (!printPageEventArgs_0.HasMorePages)
			{
				CurrentPrintResult.State = PrintResultStates.PartialPrinted;
			}
			printPageCollection_1.Add(printPage);
		}

		protected void method_1(PrintPageEventArgs printPageEventArgs_0, PrintPage printPage_1, Graphics graphics_0, Rectangle rectangle_0, bool bool_7, bool bool_8, PrintPageEventArgs printPageEventArgs_1, float float_0)
		{
			bool_3 = true;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
			XPageSettings pageSettings = printPage_1.PageSettings;
			if (pageSettings == null)
			{
				return;
			}
			if (DrawWatermark && pageSettings != null)
			{
				WatermarkInfo runtimeWatermark = pageSettings.RuntimeWatermark;
				if (runtimeWatermark != null && runtimeWatermark.PrintWatermark)
				{
					graphics_0.PageUnit = pageSettings.ViewUnit;
					RectangleF rectangleF_ = new RectangleF(pageSettings.ViewLeftMargin, pageSettings.ViewTopMargin, pageSettings.ViewPaperWidth - pageSettings.ViewLeftMargin - pageSettings.ViewRightMargin, pageSettings.ViewPaperHeight - pageSettings.ViewTopMargin - pageSettings.ViewBottomMargin);
					runtimeWatermark.method_4(rectangleF_, new DCGraphics(graphics_0), new RectangleF(0f, 0f, 100000f, 100000f));
				}
			}
			PageDrawer.method_9(printPage_1.Document);
			PageDrawer.method_17(Pages);
			PageDrawer.method_21(bool_8);
			PageDrawer.method_19(bool_7);
			PageDrawer.method_3(string_0);
			PageDrawer.method_5(printPageEventArgs_1.PageSettings);
			if (pageSettings.RuntimeAutoFitPageSize && !ForPOSPrinter)
			{
				float num = printPageEventArgs_1.PageSettings.Bounds.Width;
				float num2 = printPageEventArgs_1.PageSettings.Bounds.Height;
				float num3 = pageSettings.PaperWidth;
				float num4 = pageSettings.PaperHeight;
				if (pageSettings.Landscape)
				{
					float num5 = num3;
					num3 = num4;
					num4 = num5;
				}
				if (((double)Math.Abs((num - num3) / num3) > 0.04 || (double)Math.Abs((num2 - num4) / num4) > 0.04) && num3 > 0f && num4 > 0f)
				{
					float float_ = Math.Min(num / num3, num2 / num4);
					PageDrawer.method_11(float_);
					PageDrawer.method_13(float_);
				}
			}
			PointF pointF_ = method_2(printPageEventArgs_1.PageSettings);
			if (pageSettings.RuntimeOffsetX != 0f || pageSettings.RuntimeOffsetY != 0f)
			{
				pointF_.X -= pageSettings.RuntimeOffsetX;
				pointF_.Y -= pageSettings.RuntimeOffsetY;
			}
			PageDrawer.method_29(pointF_);
			if (ForPOSPrinter)
			{
				if (printPage_1.Document != null)
				{
					PageDrawer.method_29(new PointF(pointF_.X, (0f - GraphicsUnitConvert.Convert(float_0, printPage_1.Document.DocumentGraphicsUnit, GraphicsUnit.Inch)) * 100f + (float)printPageEventArgs_1.PageSettings.Margins.Top));
				}
				else
				{
					PageDrawer.method_29(new PointF(pointF_.X, (0f - GraphicsUnitConvert.Convert(float_0, graphics_0.PageUnit, GraphicsUnit.Inch)) * 100f + (float)printPageEventArgs_1.PageSettings.Margins.Top));
				}
			}
			PageDrawer.method_38(Options);
			graphics_0.ResetClip();
			graphics_0.ResetTransform();
			PrintPageResult item = PageDrawer.vmethod_1(printPage_1, graphics_0, rectangle_0, bool_2: true);
			printResult_0.PageInfos.Add(item);
			dictionary_1[printPage_1] = PageDrawer.method_39();
		}

		private PointF method_2(PageSettings pageSettings_0)
		{
			if (ForPrintPreview)
			{
				return new PointF(0f, 0f);
			}
			return GClass154.smethod_1(pageSettings_0).Location;
		}

		private bool method_3()
		{
			return printPageCollection_0 != null && printPageCollection_0.Count > 0;
		}

		protected static void smethod_0()
		{
			if (!bool_6)
			{
				if (PrinterSettings.InstalledPrinters.Count == 0)
				{
					throw new InvalidOperationException(PrintingResources.NoPrinter);
				}
				bool_6 = true;
			}
		}
	}
}
