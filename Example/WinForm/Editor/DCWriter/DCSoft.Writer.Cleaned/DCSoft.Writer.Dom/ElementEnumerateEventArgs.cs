using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       遍历元素事件参数
	///       </summary>
	[ComVisible(false)]
	
	public class ElementEnumerateEventArgs : EventArgs
	{
		private bool _ReverseMode = false;

		private object _Parameter = null;

		internal bool _Cancel = false;

		internal bool _CancelChild = false;

		internal XTextContainerElement _Parent = null;

		internal XTextElement _Element = null;

		internal bool _ExcludeCharElement = false;

		internal bool _ExcludeParagraphFlag = false;

		private int _HandlerCount = 0;

		/// <summary>
		///       逆向遍历模式
		///       </summary>
		public bool ReverseMode
		{
			get
			{
				return _ReverseMode;
			}
			set
			{
				_ReverseMode = value;
			}
		}

		/// <summary>
		///       参数
		///       </summary>
		public object Parameter
		{
			get
			{
				return _Parameter;
			}
			set
			{
				_Parameter = value;
			}
		}

		/// <summary>
		///       取消操作
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
		///       取消遍历子孙元素
		///       </summary>
		public bool CancelChild
		{
			get
			{
				return _CancelChild;
			}
			set
			{
				_CancelChild = value;
			}
		}

		/// <summary>
		///       父节点
		///       </summary>
		public XTextContainerElement Parent => _Parent;

		/// <summary>
		///       当前处理的元素
		///       </summary>
		public XTextElement Element => _Element;

		/// <summary>
		///       忽略字符元素
		///       </summary>
		public bool ExcludeCharElement
		{
			get
			{
				return _ExcludeCharElement;
			}
			set
			{
				_ExcludeCharElement = value;
			}
		}

		/// <summary>
		///       忽略段落符号元素
		///       </summary>
		public bool ExcludeParagraphFlag
		{
			get
			{
				return _ExcludeParagraphFlag;
			}
			set
			{
				_ExcludeParagraphFlag = value;
			}
		}

		/// <summary>
		///       累计执行的次数
		///       </summary>
		public int HandlerCount => _HandlerCount;

		/// <summary>
		///       累加执行次数
		///       </summary>
		internal void IncreaseHandlerCount()
		{
			_HandlerCount++;
		}
	}
}
