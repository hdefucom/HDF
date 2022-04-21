using DCSoft.Common;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档打印事件参数
	///       </summary>
	[Guid("595277B8-083B-40DE-8FF4-A85DA2DD48C5")]
	
	
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IWriterDocumentPrintedEventArgs))]
	[ComClass("595277B8-083B-40DE-8FF4-A85DA2DD48C5", "A491F121-1D53-41AC-9AE4-76687867EEB6")]
	[ClassInterface(ClassInterfaceType.None)]
	public class WriterDocumentPrintedEventArgs : WriterEventArgs, IWriterDocumentPrintedEventArgs
	{
		internal new const string CLASSID = "595277B8-083B-40DE-8FF4-A85DA2DD48C5";

		internal new const string CLASSID_Interface = "A491F121-1D53-41AC-9AE4-76687867EEB6";

		private PrintResult _PrintResult = null;

		/// <summary>
		///       打印结果
		///       </summary>
		
		public PrintResult PrintResult => _PrintResult;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="document">文档对象</param>
		
		public WriterDocumentPrintedEventArgs(WriterControl writerControl_0, XTextDocument document)
			: base(writerControl_0, document, document)
		{
			_PrintResult = document.LastPrintResult;
			if (_PrintResult == null)
			{
				_PrintResult = new PrintResult();
			}
		}
	}
}
