using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档内容发生改变事件参数
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Guid("00012345-6789-ABCD-EF01-23456789005D")]
	
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IContentChangedEventArgs))]
	[ComClass("00012345-6789-ABCD-EF01-23456789005D", "8CF6FF56-F492-4F52-AD84-6F49CF569AB7")]
	public class ContentChangedEventArgs : EventArgs, IContentChangedEventArgs
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789005D";

		internal const string CLASSID_Interface = "8CF6FF56-F492-4F52-AD84-6F49CF569AB7";

		private ContentChangedEventSource _EventSource = ContentChangedEventSource.Default;

		private bool _OnlyStyleChanged = false;

		private XTextDocument _Document = null;

		private bool _LoadingDocument = false;

		private object _Tag = null;

		private XTextElement _Element = null;

		private int _ElementIndex = 0;

		private XTextElementList _DeletedElements = null;

		private XTextElementList _InsertedElements = null;

		private bool _CancelBubble = false;

		private bool _Handled = false;

		/// <summary>
		///       事件来源
		///       </summary>
		
		public ContentChangedEventSource EventSource
		{
			get
			{
				return _EventSource;
			}
			set
			{
				_EventSource = value;
			}
		}

		/// <summary>
		///       只是样式发生了改变
		///       </summary>
		
		public bool OnlyStyleChanged
		{
			get
			{
				return _OnlyStyleChanged;
			}
			set
			{
				_OnlyStyleChanged = value;
			}
		}

		/// <summary>
		///       由于进行重做/撤销操作而引发了该事件
		///       </summary>
		
		public bool UndoRedoCause => EventSource == ContentChangedEventSource.UndoRedo;

		/// <summary>
		///       文档对象
		///       </summary>
		
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
		///       正在加载文档标志
		///       </summary>
		
		public bool LoadingDocument
		{
			get
			{
				return _LoadingDocument;
			}
			set
			{
				_LoadingDocument = value;
			}
		}

		/// <summary>
		///       额外的数据
		///       </summary>
		
		public object Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}

		/// <summary>
		///       容器元素对象
		///       </summary>
		
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
		///       发生操作时的元素位置序号
		///       </summary>
		
		public int ElementIndex
		{
			get
			{
				return _ElementIndex;
			}
			set
			{
				_ElementIndex = value;
			}
		}

		/// <summary>
		///       正要删除的元素列表
		///       </summary>
		
		public XTextElementList DeletedElements
		{
			get
			{
				return _DeletedElements;
			}
			set
			{
				_DeletedElements = value;
			}
		}

		/// <summary>
		///       准备新增的元素列表
		///       </summary>
		
		public XTextElementList InsertedElements
		{
			get
			{
				return _InsertedElements;
			}
			set
			{
				_InsertedElements = value;
			}
		}

		/// <summary>
		///       取消事件向上层元素冒泡传递
		///       </summary>
		
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
		///       事件已经被处理了，无需后续处理
		///       </summary>
		
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
		
		public ContentChangedEventArgs()
		{
		}
	}
}
