using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       编辑器事件参数类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[Guid("5CA02A4C-914F-4CB2-83D2-D6B350004F2D")]
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IWriterEventArgs))]
	[ComVisible(true)]
	[DocumentComment]
	[ComClass("5CA02A4C-914F-4CB2-83D2-D6B350004F2D", "DC50DF91-E87E-47ED-9AA4-6CF16530B4AB")]
	public class WriterEventArgs : EventArgs, IWriterEventArgs
	{
		internal const string CLASSID = "5CA02A4C-914F-4CB2-83D2-D6B350004F2D";

		internal const string CLASSID_Interface = "DC50DF91-E87E-47ED-9AA4-6CF16530B4AB";

		[NonSerialized]
		private WriterControl _WriterControl = null;

		[NonSerialized]
		private XTextDocument _Document = null;

		[NonSerialized]
		private XTextElement _Element = null;

		/// <summary>
		///       编辑器控件
		///       </summary>
		
		[XmlIgnore]
		[ComVisible(false)]
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		[XmlIgnore]
		
		[ComVisible(true)]
		public XTextDocument Document => _Document;

		/// <summary>
		///       文档元素对象
		///       </summary>
		
		[XmlIgnore]
		[ComVisible(true)]
		public XTextElement Element => _Element;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="document">
		/// </param>
		/// <param name="element">
		/// </param>
		
		public WriterEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element)
		{
			_WriterControl = writerControl_0;
			_Document = document;
			_Element = element;
		}

		internal virtual void InnerDispose()
		{
			_WriterControl = null;
			_Document = null;
			_Element = null;
		}
	}
}
