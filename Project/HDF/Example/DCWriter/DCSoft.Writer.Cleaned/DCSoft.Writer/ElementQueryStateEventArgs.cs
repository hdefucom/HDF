using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询文档元素状态信息事件参数
	///       </summary>
	[DocumentComment]
	[ComClass("3F3FE584-4C2E-42D7-A880-F7F06CBC59A1", "BE39D42D-7CC5-4108-BE75-ECD43B32B170")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IElementQueryStateEventArgs))]
	[Guid("3F3FE584-4C2E-42D7-A880-F7F06CBC59A1")]
	[ClassInterface(ClassInterfaceType.None)]
	public class ElementQueryStateEventArgs : ElementEventArgs, IElementQueryStateEventArgs
	{
		internal new const string CLASSID = "3F3FE584-4C2E-42D7-A880-F7F06CBC59A1";

		internal new const string CLASSID_Interface = "BE39D42D-7CC5-4108-BE75-ECD43B32B170";

		private DomAccessFlags _AccessFlags = DomAccessFlags.Normal;

		private bool _ContentReadonly = false;

		private bool _PropertyReadonly = false;

		private bool _Deleteable = true;

		private string _Message = null;

		/// <summary>
		///       访问标记
		///       </summary>
		public DomAccessFlags AccessFlags
		{
			get
			{
				return _AccessFlags;
			}
			set
			{
				_AccessFlags = value;
			}
		}

		/// <summary>
		///       内容是否只读
		///       </summary>
		public bool ContentReadonly
		{
			get
			{
				return _ContentReadonly;
			}
			set
			{
				_ContentReadonly = value;
			}
		}

		/// <summary>
		///       本身的属性是否是只读的
		///       </summary>
		public bool PropertyReadonly
		{
			get
			{
				return _PropertyReadonly;
			}
			set
			{
				_PropertyReadonly = value;
			}
		}

		/// <summary>
		///       元素能否被删除
		///       </summary>
		public bool Deleteable
		{
			get
			{
				return _Deleteable;
			}
			set
			{
				_Deleteable = value;
			}
		}

		/// <summary>
		///       相关的提示信息
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
		///       初始化对象
		///       </summary>
		/// <param name="element">
		/// </param>
		[DCInternal]
		public ElementQueryStateEventArgs(XTextElement element)
			: base(element)
		{
		}
	}
}
