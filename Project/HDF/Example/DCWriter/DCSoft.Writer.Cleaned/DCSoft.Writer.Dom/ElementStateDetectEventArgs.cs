using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档元素状态检测事件参数
	///       </summary>
	[ComVisible(false)]
	public class ElementStateDetectEventArgs
	{
		private bool _ForContent = false;

		private DomAccessFlags _Flags = DomAccessFlags.Normal;

		private XTextElement _Element = null;

		private bool _SetMessage = true;

		private string _Message = null;

		private bool _Result = true;

		/// <summary>
		///       为修改内容而执行判断
		///       </summary>
		public bool ForContent
		{
			get
			{
				return _ForContent;
			}
			set
			{
				_ForContent = value;
			}
		}

		/// <summary>
		///       标记
		///       </summary>
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
		///       文档元素对象
		///       </summary>
		public XTextElement Element => _Element;

		/// <summary>
		///       设置消息
		///       </summary>
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
		///       检测结果
		///       </summary>
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
		///       输出对象
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="flags">标记</param>
		public ElementStateDetectEventArgs(XTextElement element, DomAccessFlags flags)
		{
			_Element = element;
			_Flags = flags;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">文档元素对象</param>
		public ElementStateDetectEventArgs(XTextElement element)
		{
			_Element = element;
		}
	}
}
