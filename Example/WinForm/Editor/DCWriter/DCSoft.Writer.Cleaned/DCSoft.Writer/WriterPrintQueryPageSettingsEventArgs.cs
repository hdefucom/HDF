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
	///       打印时查询页面设置事件参数
	///       </summary>
	
	
	[ComDefaultInterface(typeof(IWriterPrintQueryPageSettingsEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("6568A299-FEAB-4D02-AA97-2DD0EED28DAC")]
	[ComVisible(true)]
	[ComClass("6568A299-FEAB-4D02-AA97-2DD0EED28DAC", "9DF128AB-A6B7-4989-8C19-6E73AA50AF16")]
	public class WriterPrintQueryPageSettingsEventArgs : EventArgs, IWriterPrintQueryPageSettingsEventArgs
	{
		internal const string CLASSID = "6568A299-FEAB-4D02-AA97-2DD0EED28DAC";

		internal const string CLASSID_Interface = "9DF128AB-A6B7-4989-8C19-6E73AA50AF16";

		private int _PageIndex;

		private QueryPageSettingsEventArgs _SrcArgs;

		private WriterControl _WriterControl;

		private XTextDocument _Document;

		private WriterPrintDocument _PrintDocument;

		/// <summary>
		///       从0开始计算的页码号
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

		
		public PageSettings PageSettings => _SrcArgs.PageSettings;

		
		public PrintAction PrintAction => _SrcArgs.PrintAction;

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

		
		public WriterPrintQueryPageSettingsEventArgs(XTextDocument xtextDocument_0, WriterPrintDocument pDoc, QueryPageSettingsEventArgs srcArgs, int pageIndex)
		{
			int num = 5;
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
