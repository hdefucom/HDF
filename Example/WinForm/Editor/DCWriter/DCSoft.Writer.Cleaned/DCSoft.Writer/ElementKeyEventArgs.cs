using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素键盘事件参数
	///       </summary>
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("48B6B2E5-4FFB-4A40-9BD5-29C48C1CE854", "20769745-CCC7-4AC4-B98A-25FDFB237B29")]
	[ComDefaultInterface(typeof(IElementKeyEventArgs))]
	[ComVisible(true)]
	[Guid("48B6B2E5-4FFB-4A40-9BD5-29C48C1CE854")]
	
	public class ElementKeyEventArgs : ElementEventArgs, IElementKeyEventArgs
	{
		internal new const string CLASSID = "48B6B2E5-4FFB-4A40-9BD5-29C48C1CE854";

		internal new const string CLASSID_Interface = "20769745-CCC7-4AC4-B98A-25FDFB237B29";

		private bool _Alt = false;

		private bool _Control = false;

		private bool _Shift = false;

		private Keys _KeyCode = Keys.None;

		private char _KeyChar = '\0';

		/// <summary>
		///       Alt键状态
		///       </summary>
		
		public bool Alt
		{
			get
			{
				return _Alt;
			}
			set
			{
				_Alt = value;
			}
		}

		/// <summary>
		///       Control键状态
		///       </summary>
		
		public bool Control
		{
			get
			{
				return _Control;
			}
			set
			{
				_Control = value;
			}
		}

		/// <summary>
		///       Shift键状态
		///       </summary>
		
		public bool Shift
		{
			get
			{
				return _Shift;
			}
			set
			{
				_Shift = value;
			}
		}

		/// <summary>
		///       按键值
		///       </summary>
		[ComVisible(false)]
		
		public Keys KeyCode
		{
			get
			{
				return _KeyCode;
			}
			set
			{
				_KeyCode = value;
			}
		}

		/// <summary>
		///       按键字符值
		///       </summary>
		[ComVisible(false)]
		
		public char KeyChar => _KeyChar;

		/// <summary>
		///       按键字符值
		///       </summary>
		
		[ComVisible(true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("本属性仅仅作为COM接口使用")]
		[Browsable(false)]
		public int KeyCharValue => _KeyChar;

		/// <summary>
		///       按键值，仅作为COM接口使用。
		///       </summary>
		[Browsable(true)]
		
		[Obsolete("本属性仅仅作为COM接口使用")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int KeyCodeValue => (int)_KeyCode;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <param name="element">
		/// </param>
		
		public ElementKeyEventArgs(DocumentEventArgs args, XTextElement element)
			: base(element)
		{
			_Alt = args.AltKey;
			_Shift = args.ShiftKey;
			_Control = args.CtlKey;
			_KeyCode = args.KeyCode;
			_KeyChar = args.KeyChar;
		}
	}
}
