using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       CanInsert函数参数类型
	///       </summary>
	[DocumentComment]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("C26BF7C1-77E3-49B2-94E7-1FD7843FE6CE")]
	[ComDefaultInterface(typeof(ICanInsertElementEventArgs))]
	[DCPublishAPI]
	[ComClass("C26BF7C1-77E3-49B2-94E7-1FD7843FE6CE", "516F05E8-587A-41B4-8DB4-E219BDE0228C")]
	public class CanInsertElementEventArgs : ICanInsertElementEventArgs
	{
		internal const string CLASSID = "C26BF7C1-77E3-49B2-94E7-1FD7843FE6CE";

		internal const string CLASSID_Interface = "516F05E8-587A-41B4-8DB4-E219BDE0228C";

		private XTextContainerElement _Container = null;

		private int _Index = 0;

		private Type _ElementType = null;

		private XTextElement _Element = null;

		private DomAccessFlags _Flags = DomAccessFlags.Normal;

		private bool _SetMessage = false;

		private string _Message = null;

		private bool _Result = true;

		/// <summary>
		///       容器元素
		///       </summary>
		[DCPublishAPI]
		public XTextContainerElement Container => _Container;

		/// <summary>
		///       序号
		///       </summary>
		[DCPublishAPI]
		public int Index => _Index;

		/// <summary>
		///       文档元素类型
		///       </summary>
		[DCPublishAPI]
		public Type ElementType => _ElementType;

		/// <summary>
		///       文档元素对象
		///       </summary>
		[DCPublishAPI]
		public XTextElement Element => _Element;

		/// <summary>
		///       标记
		///       </summary>
		[DCPublishAPI]
		public DomAccessFlags Flags
		{
			get
			{
				return _Flags;
			}
			set
			{
				_Flags = value;
			}
		}

		/// <summary>
		///       设置的消息
		///       </summary>
		[DCPublishAPI]
		public bool SetMessage
		{
			get
			{
				return _SetMessage;
			}
			set
			{
				_SetMessage = value;
			}
		}

		/// <summary>
		///       消息
		///       </summary>
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
		///       结果
		///       </summary>
		[DCPublishAPI]
		public bool Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="container">容器对象</param>
		/// <param name="index">序号</param>
		/// <param name="elementType">文档元素类型</param>
		/// <param name="flags">标记</param>
		[DCInternal]
		public CanInsertElementEventArgs(XTextContainerElement container, int index, Type elementType, DomAccessFlags flags)
		{
			_Container = container;
			_Index = index;
			_ElementType = elementType;
			_Flags = flags;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="container">容器对象</param>
		/// <param name="index">序号</param>
		/// <param name="element">文档元素</param>
		/// <param name="flags">标记</param>
		[DCInternal]
		public CanInsertElementEventArgs(XTextContainerElement container, int index, XTextElement element, DomAccessFlags flags)
		{
			_Container = container;
			_Index = index;
			_Element = element;
			_Flags = flags;
		}
	}
}
