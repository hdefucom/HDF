using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Printing
{
	/// <summary>
	///       文档打印控制对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	
	
	public class DocumentPrinter
	{
		private DCPrintDocumentOptions dcprintDocumentOptions_0 = new DCPrintDocumentOptions();

		private float float_0 = 0f;

		private XTextDocumentList xtextDocumentList_0 = new XTextDocumentList();

		private bool bool_0 = false;

		private PrintPage printPage_0 = null;

		private WriterControl writerControl_0 = null;

		/// <summary>
		///       打印文档选项
		///       </summary>
		
		public DCPrintDocumentOptions Options
		{
			get
			{
				return dcprintDocumentOptions_0;
			}
			set
			{
				dcprintDocumentOptions_0 = value;
			}
		}

		/// <summary>
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		[ComVisible(false)]
		[Obsolete("★★★★★★请使用Options下的属性")]
		
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AsyncPrint
		{
			get
			{
				return Options.AsyncPrint;
			}
			set
			{
				Options.AsyncPrint = value;
			}
		}

		/// <summary>
		///       正文Y方向偏移量
		///       </summary>
		
		public float BodyOffsetY
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
		///       要打印的文档
		///       </summary>
		
		public XTextDocument Document
		{
			get
			{
				if (xtextDocumentList_0 == null)
				{
					return null;
				}
				return xtextDocumentList_0.FirstDocument;
			}
			set
			{
				xtextDocumentList_0 = new XTextDocumentList(value);
			}
		}

		/// <summary>
		///       要打印的文档集合
		///       </summary>
		
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
		///       整洁打印模式
		///       </summary>
		
		public bool CleanMode
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
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		[Obsolete("★★★★★★请使用Options下的属性")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[ComVisible(false)]
		
		public JumpPrintInfo JumpPrint
		{
			get
			{
				return Options.JumpPrint;
			}
			set
			{
				Options.JumpPrint = value;
			}
		}

		/// <summary>
		///       当前页对象
		///       </summary>
		
		public PrintPage CurrentPage
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
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		[Browsable(false)]
		[Obsolete("★★★★★★请使用Options下的属性")]
		[ComVisible(false)]
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		public PrintRange PrintRange
		{
			get
			{
				return Options.PrintRange;
			}
			set
			{
				Options.PrintRange = value;
			}
		}

		/// <summary>
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		[Obsolete("★★★★★★请使用Options下的属性")]
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		[Browsable(false)]
		public int FromPage
		{
			get
			{
				return Options.FromPage;
			}
			set
			{
				Options.FromPage = value;
			}
		}

		/// <summary>
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		
		[ComVisible(false)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("★★★★★★请使用Options下的属性")]
		public int ToPage
		{
			get
			{
				return Options.ToPage;
			}
			set
			{
				Options.ToPage = value;
			}
		}

		/// <summary>
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		
		[Obsolete("★★★★★★请使用Options下的属性")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		public string PrinterName
		{
			get
			{
				return Options.PrinterName;
			}
			set
			{
				Options.PrinterName = value;
			}
		}

		/// <summary>
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		[Browsable(false)]
		[Obsolete("★★★★★★请使用Options下的属性")]
		public string PaperSourceName
		{
			get
			{
				return Options.PaperSourceName;
			}
			set
			{
				Options.PaperSourceName = value;
			}
		}

		/// <summary>
		///       编辑器控件对象
		///       </summary>
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
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		[Obsolete("★★★★★★请使用Options下的属性")]
		
		[Browsable(false)]
		public List<int> SpecifyPageIndexs
		{
			get
			{
				return Options.SpecifyPageIndexs;
			}
			set
			{
				Options.SpecifyPageIndexs = value;
			}
		}

		/// <summary>
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		
		[ComVisible(false)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("★★★★★★请使用Options下的属性")]
		public int SpecifyCopies
		{
			get
			{
				return Options.SpecifyCopies;
			}
			set
			{
				Options.SpecifyCopies = value;
			}
		}

		/// <summary>
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		[Browsable(false)]
		[Obsolete("★★★★★★请使用Options下的属性")]
		public bool DrawFirstHeaderFooterWhenJumpPrintMode
		{
			get
			{
				return Options.DrawFirstHeaderFooterWhenJumpPrintMode;
			}
			set
			{
				Options.DrawFirstHeaderFooterWhenJumpPrintMode = value;
			}
		}

		/// <summary>
		///       本属性已经废除掉了,请使用Options下的属性
		///       </summary>
		[ComVisible(false)]
		[Obsolete("★★★★★★请使用Options下的属性")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public bool ManualDuplex
		{
			get
			{
				return Options.ManualDuplex;
			}
			set
			{
				Options.ManualDuplex = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public DocumentPrinter()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="doc">要打印的文档对象</param>
		
		public DocumentPrinter(XTextDocument xtextDocument_0)
		{
			xtextDocumentList_0 = new XTextDocumentList(xtextDocument_0);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		
		public DocumentPrinter(WriterControl writerControl_1)
		{
			xtextDocumentList_0 = new XTextDocumentList(writerControl_1.Document);
			Options = new DCPrintDocumentOptions();
			if (writerControl_1.JumpPrint != null)
			{
				Options.JumpPrint = writerControl_1.JumpPrint.Clone();
			}
			if (writerControl_1.BoundsSelection != null)
			{
				Options.BoundsSelection = writerControl_1.BoundsSelection.Clone();
			}
			CurrentPage = writerControl_1.CurrentPage;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="documents">要打印的文档集合</param>
		
		public DocumentPrinter(XTextDocumentList xtextDocumentList_1)
		{
			xtextDocumentList_0 = xtextDocumentList_1;
		}

		private void method_0()
		{
			if (Options.FromPage < 0)
			{
				Options.FromPage = -Options.FromPage;
			}
			if (Options.ToPage < 0)
			{
				Options.ToPage = -Options.ToPage;
			}
			if (Options.FromPage > Options.ToPage)
			{
				int fromPage = Options.FromPage;
				Options.FromPage = Options.ToPage;
				Options.ToPage = fromPage;
			}
		}

		/// <summary>
		///       为打印做一些准备工作
		///       </summary>
		
		public void PreparePrintDocument()
		{
			if (Documents != null)
			{
				foreach (XTextDocument document in Documents)
				{
					using (DCGraphics dcgraphics_ = document.CreateDCGraphics())
					{
						document.RefreshSize(dcgraphics_);
					}
					document.ExecuteLayout();
					document.RefreshPages();
				}
			}
		}

		/// <summary>
		///       打印报表文档
		///       </summary>
		/// <param name="Prompt">是否显示打印机选择对话框</param>
		/// <returns>是否进行了打印</returns>
		
		public PrintResult PrintDocument(bool Prompt)
		{
			return PrintDocument(Prompt, -1);
		}

		private void method_1(object sender, QueryPageSettingsEventArgs e)
		{
			XPrintDocument xPrintDocument = (XPrintDocument)sender;
			_ = (XTextDocument)xPrintDocument.CurrentPrintingPage.Document;
		}

		private void method_2(object sender, EventArgs e)
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
		///       打印报表文档
		///       </summary>
		/// <param name="Prompt">是否显示打印机选择对话框</param>
		/// <param name="SpecialPageIndex">从0开始计算的要打印的指定序号的报表页,若该参数超出范围则打印文档的所有页</param>
		/// <returns>是否进行了打印</returns>
		
		public PrintResult PrintDocument(bool Prompt, int SpecialPageIndex)
		{
			PrintResult printResult = new PrintResult();
			if (Document == null)
			{
				printResult.UserCancel = true;
				return printResult;
			}
			method_0();
			using (WriterPrintDocument writerPrintDocument = new WriterPrintDocument())
			{
				writerPrintDocument.Options = Options;
				writerPrintDocument.CleanMode = CleanMode;
				writerPrintDocument.Documents = Documents;
				writerPrintDocument.WriterControl = WriterControl;
				writerPrintDocument.CurrentDocumentPage = CurrentPage;
				writerPrintDocument.PrinterSettings.Copies = (short)Document.PageSettings.Copies;
				writerPrintDocument.ForPOSPrinter = Document.PageSettings.RuntimeForPOSPrinter;
				if (!string.IsNullOrEmpty(Options.PrinterName))
				{
					writerPrintDocument.PrinterSettings.PrinterName = Options.PrinterName;
				}
				writerPrintDocument.PrinterSettings.PrintRange = Options.PrintRange;
				if (Prompt && !writerPrintDocument.Prompt(SpecialPageIndex, null))
				{
					printResult.UserCancel = true;
					return printResult;
				}
				if (writerPrintDocument.PrintDocument(SpecialPageIndex))
				{
					printResult = writerPrintDocument.CurrentPrintResult;
					printResult.EndTime = Document.GetNowDateTime();
					return printResult;
				}
				printResult.UserCancel = true;
				return printResult;
			}
		}
	}
}
