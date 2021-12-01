using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       报告错误事件参数
	///       </summary>
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IWriterReportErrorEventArgs))]
	[ComClass("63DDC6FD-585E-4B14-B076-4AEB652A3C58", "3E829F65-FB88-4B9F-933E-BDF855B4097A")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("63DDC6FD-585E-4B14-B076-4AEB652A3C58")]
	[DocumentComment]
	public class WriterReportErrorEventArgs : WriterEventArgs, IWriterReportErrorEventArgs
	{
		internal new const string CLASSID = "63DDC6FD-585E-4B14-B076-4AEB652A3C58";

		internal new const string CLASSID_Interface = "3E829F65-FB88-4B9F-933E-BDF855B4097A";

		private string _Message = null;

		private string _Details = null;

		private bool _Handled = false;

		/// <summary>
		///       错误信息
		///       </summary>
		[DCPublishAPI]
		[XmlElement]
		[DefaultValue(null)]
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}

		/// <summary>
		///       错误的详细信息
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[DCPublishAPI]
		public string Details
		{
			get
			{
				return _Details;
			}
			set
			{
				_Details = value;
			}
		}

		/// <summary>
		///       事件是否被处理了
		///       </summary>
		[DefaultValue(null)]
		[DCPublishAPI]
		[XmlElement]
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		/// <param name="msg">错误消息</param>
		/// <param name="details">详细信息</param>
		[DCInternal]
		public WriterReportErrorEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, string string_0, string details)
			: base(writerControl_0, document, element)
		{
			_Message = string_0;
			_Details = details;
		}
	}
}
