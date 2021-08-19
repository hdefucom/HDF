using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       内容保护信息对象
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public class ContentProtectedInfo
	{
		private XTextElement _Element = null;

		private string _Message = null;

		private ContentProtectedReason _Reason = ContentProtectedReason.None;

		/// <summary>
		///       文档元素对象
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
		///       内容被保护的理由
		///       </summary>
		public ContentProtectedReason Reason
		{
			get
			{
				return _Reason;
			}
			set
			{
				_Reason = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="element">文档元素对象</param>
		/// <param name="msg">消息</param>
		public ContentProtectedInfo(XTextElement element, string string_0, ContentProtectedReason reason)
		{
			_Element = element;
			_Message = string_0;
			_Reason = reason;
		}
	}
}
