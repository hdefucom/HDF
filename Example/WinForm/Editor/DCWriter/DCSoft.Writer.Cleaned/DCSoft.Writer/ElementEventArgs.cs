using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素事件参数
	///       </summary>
	[ComClass("D1DB1F7B-F1DC-461E-9E0B-7DC46CF5D513", "E480A97E-8DB9-45AF-8207-31C19D079B93")]
	[DocumentComment]
	[Guid("D1DB1F7B-F1DC-461E-9E0B-7DC46CF5D513")]
	[ComDefaultInterface(typeof(IElementEventArgs))]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DCPublishAPI]
	public class ElementEventArgs : EventArgs, IElementEventArgs
	{
		internal const string CLASSID = "D1DB1F7B-F1DC-461E-9E0B-7DC46CF5D513";

		internal const string CLASSID_Interface = "E480A97E-8DB9-45AF-8207-31C19D079B93";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XTextElement _Element = null;

		private bool _Handled = false;

		private bool _CancelBubble = false;

		/// <summary>
		///       编辑器控件对象
		///       </summary>
		[DCPublishAPI]
		public WriterControl WriterControl
		{
			get
			{
				return _WriterControl;
			}
			set
			{
				_WriterControl = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument Document
		{
			get
			{
				return _Document;
			}
			set
			{
				_Document = value;
			}
		}

		/// <summary>
		///       文档元素对象
		///       </summary>
		[DCPublishAPI]
		public XTextElement Element
		{
			get
			{
				return _Element;
			}
			set
			{
				_Element = value;
			}
		}

		/// <summary>
		///       事件已经被处理了，后续无需继续处理
		///       </summary>
		[DCPublishAPI]
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
		///       取消事件冒泡
		///       </summary>
		[DCPublishAPI]
		public bool CancelBubble
		{
			get
			{
				return _CancelBubble;
			}
			set
			{
				_CancelBubble = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		public ElementEventArgs()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">文档元素对象</param>
		[DCInternal]
		public ElementEventArgs(XTextElement element)
		{
			_Document = element.OwnerDocument;
			_Element = element;
			if (_Document != null)
			{
				_WriterControl = _Document.EditorControl;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		[DCInternal]
		public ElementEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element)
		{
			_WriterControl = writerControl_0;
			_Document = document;
			_Element = element;
		}
	}
}
