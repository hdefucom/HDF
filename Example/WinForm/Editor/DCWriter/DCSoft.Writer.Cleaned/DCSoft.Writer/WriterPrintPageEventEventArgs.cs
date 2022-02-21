using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Printing;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       打印每页内容事件参数
	///       </summary>
	[Guid("9CA7B12E-75CD-420E-B340-4DDC61DBAB14")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IWriterPrintPageEventEventArgs))]
	[DocumentComment]
	
	[ComVisible(true)]
	[ComClass("9CA7B12E-75CD-420E-B340-4DDC61DBAB14", "9E285C5F-A5A2-4351-8E00-691CAB35CB1E")]
	public class WriterPrintPageEventEventArgs : EventArgs, IWriterPrintPageEventEventArgs
	{
		internal const string CLASSID = "9CA7B12E-75CD-420E-B340-4DDC61DBAB14";

		internal const string CLASSID_Interface = "9E285C5F-A5A2-4351-8E00-691CAB35CB1E";

		private int _PageIndex;

		private PrintPageEventArgs _SrcArgs;

		private WriterControl _WriterControl;

		private XTextDocument _Document;

		private WriterPrintDocument _PrintDocument;

		/// <summary>
		///       当前的从0开始计算的页码数
		///       </summary>
		
		public int PageIndex => _PageIndex;

		/// <summary>
		///       用户是否取消操作
		///       </summary>
		
		public bool Cancel
		{
			get
			{
				return _SrcArgs.Cancel;
			}
			set
			{
				_SrcArgs.Cancel = value;
			}
		}

		
		public Graphics Graphics => _SrcArgs.Graphics;

		
		public PageSettings PageSettings => _SrcArgs.PageSettings;

		
		public Rectangle PageBounds => _SrcArgs.PageBounds;

		
		public Rectangle MarginBounds => _SrcArgs.MarginBounds;

		
		public bool HasMorePages
		{
			get
			{
				return _SrcArgs.HasMorePages;
			}
			set
			{
				_SrcArgs.HasMorePages = value;
			}
		}

		/// <summary>
		///       编辑器控件
		///       </summary>
		
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Document => _Document;

		/// <summary>
		///       默认页面设置
		///       </summary>
		
		public PageSettings DefaultPageSettings => _PrintDocument.DefaultPageSettings;

		/// <summary>
		///       默认打印机设置
		///       </summary>
		
		public PrinterSettings PrinterSettings => _PrintDocument.PrinterSettings;

		/// <summary>
		///       打印文档对象
		///       </summary>
		
		public WriterPrintDocument PrintDocument => _PrintDocument;

		
		public WriterPrintPageEventEventArgs(XTextDocument xtextDocument_0, WriterPrintDocument pDoc, PrintPageEventArgs srcArgs, int pageIndex)
		{
			int num = 13;
			_PageIndex = 0;
			_SrcArgs = null;
			_WriterControl = null;
			_Document = null;
			_PrintDocument = null;
			
			if (xtextDocument_0 == null)
			{
				throw new ArgumentNullException("doc");
			}
			if (pDoc == null)
			{
				throw new ArgumentNullException("pDoc");
			}
			if (srcArgs == null)
			{
				throw new ArgumentNullException("srcArgs");
			}
			_WriterControl = xtextDocument_0.EditorControl;
			_Document = xtextDocument_0;
			_SrcArgs = srcArgs;
			_PrintDocument = pDoc;
			_PageIndex = pageIndex;
		}
	}
}
