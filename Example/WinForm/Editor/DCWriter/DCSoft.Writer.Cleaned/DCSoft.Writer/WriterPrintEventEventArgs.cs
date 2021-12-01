using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Printing;
using Microsoft.VisualBasic;
using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       打印事件参数
	///       </summary>
	[DCPublishAPI]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("432F8499-A989-4CE0-A23F-27DF60A92496", "6A6AA3C0-2F4D-4D61-B319-3949DF34037E")]
	[Guid("432F8499-A989-4CE0-A23F-27DF60A92496")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IWriterPrintEventEventArgs))]
	public class WriterPrintEventEventArgs : EventArgs, IWriterPrintEventEventArgs
	{
		internal const string CLASSID = "432F8499-A989-4CE0-A23F-27DF60A92496";

		internal const string CLASSID_Interface = "6A6AA3C0-2F4D-4D61-B319-3949DF34037E";

		private PrintEventArgs _SrcArgs;

		private WriterControl _WriterControl;

		private XTextDocument _Document;

		private WriterPrintDocument _PrintDocument;

		/// <summary>
		///       用户是否取消操作
		///       </summary>
		[DCPublishAPI]
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

		/// <summary>
		///       编辑器控件
		///       </summary>
		[DCPublishAPI]
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument Document => _Document;

		/// <summary>
		///       打印动作
		///       </summary>
		[DCPublishAPI]
		public PrintAction PrintAction => _SrcArgs.PrintAction;

		/// <summary>
		///       默认页面设置
		///       </summary>
		[DCPublishAPI]
		public PageSettings DefaultPageSettings => _PrintDocument.DefaultPageSettings;

		/// <summary>
		///       默认打印机设置
		///       </summary>
		[DCPublishAPI]
		public PrinterSettings PrinterSettings => _PrintDocument.PrinterSettings;

		/// <summary>
		///       打印文档对象
		///       </summary>
		[DCPublishAPI]
		public WriterPrintDocument PrintDocument => _PrintDocument;

		[DCInternal]
		public WriterPrintEventEventArgs(XTextDocument xtextDocument_0, WriterPrintDocument pDoc, PrintEventArgs srcArgs)
		{
			int num = 10;
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
		}
	}
}
