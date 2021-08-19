using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素内容验证中事件参数
	///       </summary>
	[ComVisible(true)]
	[DocumentComment]
	[ComClass("DA9464B8-8122-4491-9A9D-BF4C848AFEC1", "449CBD6E-6383-4D0B-8F5D-6FD44067E790")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IElementValidatingEventArgs))]
	[Guid("DA9464B8-8122-4491-9A9D-BF4C848AFEC1")]
	public class ElementValidatingEventArgs : ElementEventArgs, IElementValidatingEventArgs
	{
		internal new const string CLASSID = "DA9464B8-8122-4491-9A9D-BF4C848AFEC1";

		internal new const string CLASSID_Interface = "449CBD6E-6383-4D0B-8F5D-6FD44067E790";

		private ElementValidatingState _ResultState = ElementValidatingState.Success;

		private ValueValidateLevel _ResultLevel = ValueValidateLevel.Error;

		private string _Message = null;

		private bool _Cancel = false;

		/// <summary>
		///       校验状态
		///       </summary>
		public ElementValidatingState ResultState
		{
			get
			{
				return _ResultState;
			}
			set
			{
				_ResultState = value;
			}
		}

		/// <summary>
		///       校验结果等级
		///       </summary>
		public ValueValidateLevel ResultLevel
		{
			get
			{
				return _ResultLevel;
			}
			set
			{
				_ResultLevel = value;
			}
		}

		/// <summary>
		///       验证结果信息 
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
		///       取消后续事件
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
		///       初始化对象
		///       </summary>
		/// <param name="element">文档元素对象</param>
		[DCInternal]
		public ElementValidatingEventArgs(XTextElement element)
			: base(element)
		{
		}
	}
}
