using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器事件参数类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComClass("2868B0A2-C98D-4127-9273-B0F9635C3C8E", "D1F9A947-10B8-492A-98D4-382A2B52CA4F")]
	
	[ComVisible(true)]
	[DocumentComment]
	[Guid("2868B0A2-C98D-4127-9273-B0F9635C3C8E")]
	[ComDefaultInterface(typeof(IWriterCancelEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	public class WriterCancelEventArgs : EventArgs, IWriterCancelEventArgs
	{
		internal const string CLASSID = "2868B0A2-C98D-4127-9273-B0F9635C3C8E";

		internal const string CLASSID_Interface = "D1F9A947-10B8-492A-98D4-382A2B52CA4F";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XTextElement _Element = null;

		private bool _Cancel = false;

		/// <summary>
		///       编辑器控件
		///       </summary>
		
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Document => _Document;

		/// <summary>
		///       文档元素对象
		///       </summary>
		
		public XTextElement Element => _Element;

		/// <summary>
		///       用户取消操作标记
		///       </summary>
		
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		
		public WriterCancelEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element)
		{
			_WriterControl = writerControl_0;
			_Document = document;
			_Element = element;
		}
	}
}
