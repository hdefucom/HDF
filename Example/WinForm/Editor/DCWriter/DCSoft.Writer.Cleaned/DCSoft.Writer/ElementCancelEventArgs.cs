using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       带取消功能的文档元素事件参数类型
	///       </summary>
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IElementCancelEventArgs))]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("B4DF21C4-9740-48F4-A366-AF6DB3B7548F", "84568825-E006-4F84-83A5-4A60E996B332")]
	[Guid("B4DF21C4-9740-48F4-A366-AF6DB3B7548F")]
	[DCPublishAPI]
	public class ElementCancelEventArgs : ElementEventArgs, IElementCancelEventArgs
	{
		internal new const string CLASSID = "B4DF21C4-9740-48F4-A366-AF6DB3B7548F";

		internal new const string CLASSID_Interface = "84568825-E006-4F84-83A5-4A60E996B332";

		private bool _Cancel = false;

		/// <summary>
		///       取消事件
		///       </summary>
		[DCPublishAPI]
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
		/// <param name="element">文档元素对象</param>
		[DCInternal]
		public ElementCancelEventArgs(XTextElement element)
			: base(element)
		{
		}
	}
}
