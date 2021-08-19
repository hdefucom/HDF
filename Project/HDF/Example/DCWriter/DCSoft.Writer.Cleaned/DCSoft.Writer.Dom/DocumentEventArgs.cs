using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档事件参数
	///       </summary>
	[ComClass("04F413CE-CC37-4489-9353-A608D7E8BB04", "693A4F9F-5DE9-4AB8-A630-FA40E11379DC")]
	[DocumentComment]
	[Guid("04F413CE-CC37-4489-9353-A608D7E8BB04")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IDocumentEventArgs))]
	[ComVisible(true)]
	public class DocumentEventArgs : IDocumentEventArgs
	{
		internal const string CLASSID = "04F413CE-CC37-4489-9353-A608D7E8BB04";

		internal const string CLASSID_Interface = "693A4F9F-5DE9-4AB8-A630-FA40E11379DC";

		/// <summary>
		///       默认鼠标光标对象
		///       </summary>
		public static Cursor DefaultCursor = Cursors.IBeam;

		internal DocumentEventStyles intStyle = DocumentEventStyles.None;

		private XTextDocument myDocument = null;

		private XTextElement _Element = null;

		internal string strName = null;

		private bool bolAltKey = false;

		private bool bolCtlKey = false;

		private bool bolShiftKey = false;

		private Keys _KeyCode = Keys.None;

		internal char intKeyChar = '\0';

		private bool _CancelBubble = false;

		private bool _Handled = false;

		private bool _AlreadSetSelection = false;

		/// <summary>
		///       鼠标光标坐标转换时出现了严格命中
		///       </summary>
		internal bool _StrictMatch = true;

		private int _MouseClicks = 0;

		internal int intClientX = 0;

		internal int intClientY = 0;

		internal float _ViewX = 0f;

		internal float _ViewY = 0f;

		internal int intX = 0;

		internal int intY = 0;

		private MouseButtons _Button = MouseButtons.None;

		internal int intWheelDelta = 0;

		private object objReturnValue = null;

		internal static Cursor myCursor = Cursors.IBeam;

		/// <summary>
		///       提示文本
		///       </summary>
		internal static string strTooltip = null;

		/// <summary>
		///       文档事件类型
		///       </summary>
		public DocumentEventStyles Style => intStyle;

		/// <summary>
		///       对象所在文档对象
		///       </summary>
		public XTextDocument Document => myDocument;

		/// <summary>
		///       事件相关的文档元素对象
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
		///       事件名称
		///       </summary>
		public string Name => strName;

		/// <summary>
		///       用户是否按下了 Alt 键
		///       </summary>
		public bool AltKey => bolAltKey;

		/// <summary>
		///       用户是否按下的 Ctl 键
		///       </summary>
		public bool CtlKey => bolCtlKey;

		/// <summary>
		///       用户是否按下了 Shift 键
		///       </summary>
		public bool ShiftKey => bolShiftKey;

		/// <summary>
		///       按键值
		///       </summary>
		[ComVisible(false)]
		public Keys KeyCode => _KeyCode;

		/// <summary>
		///       按键值，仅作为COM接口使用。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(true)]
		[Obsolete("本属性仅仅作为COM接口使用")]
		public int KeyCodeValue => (int)_KeyCode;

		/// <summary>
		///       键盘字符值
		///       </summary>
		[ComVisible(false)]
		public char KeyChar => intKeyChar;

		/// <summary>
		///       键盘字符值
		///       </summary>
		[ComVisible(true)]
		public int KeyCharValue => intKeyChar;

		/// <summary>
		///       取消事件冒泡
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
		///       事件已经处理了
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
		///       已经设置了文档内容选择区域，无需自动设置选择区域
		///       </summary>
		public bool AlreadSetSelection
		{
			get
			{
				return _AlreadSetSelection;
			}
			set
			{
				_AlreadSetSelection = value;
			}
		}

		/// <summary>
		///       鼠标光标坐标转换时出现了严格命中
		///       </summary>
		public bool StrictMatch => _StrictMatch;

		/// <summary>
		///       鼠标点击次数
		///       </summary>
		public int MouseClicks
		{
			get
			{
				return _MouseClicks;
			}
			set
			{
				_MouseClicks = value;
			}
		}

		/// <summary>
		///       鼠标在文档控件客户区的X坐标
		///       </summary>
		public int ClientX => intClientX;

		/// <summary>
		///       鼠标在文档控件客户区的Y坐标
		///       </summary>
		public int ClientY => intClientY;

		public float ViewX => _ViewX;

		public float ViewY => _ViewY;

		/// <summary>
		///       鼠标光标在视图中的X坐标
		///       </summary>
		public int X => intX;

		/// <summary>
		///       鼠标光标在视图中的Y坐标
		///       </summary>
		public int Y => intY;

		/// <summary>
		///       鼠标按键值
		///       </summary>
		[Browsable(false)]
		public MouseButtons Button => _Button;

		/// <summary>
		///       鼠标按键值
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(true)]
		[Obsolete("本属性仅仅作为COM接口使用")]
		public int ButtonValue => (int)Button;

		/// <summary>
		///       鼠标滚轮值
		///       </summary>
		public int WheelDelta => intWheelDelta;

		/// <summary>
		///       事件返回值
		///       </summary>
		public object ReturnValue
		{
			get
			{
				return objReturnValue;
			}
			set
			{
				objReturnValue = value;
			}
		}

		/// <summary>
		///       视图区鼠标光标对象
		///       </summary>
		[ComVisible(false)]
		public Cursor Cursor
		{
			get
			{
				return myCursor;
			}
			set
			{
				myCursor = value;
			}
		}

		/// <summary>
		///       提示文本
		///       </summary>
		public string Tooltip
		{
			get
			{
				return strTooltip;
			}
			set
			{
				strTooltip = value;
			}
		}

		/// <summary>
		///       创建鼠标按键按下事件参数
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <param name="e">原始事件参数</param>
		/// <returns>创建的参数</returns>
		[DCInternal]
		public static DocumentEventArgs CreateMouseDown(XTextDocument xtextDocument_0, MouseEventArgs mouseEventArgs_0)
		{
			return CreateMouseEvent(xtextDocument_0, mouseEventArgs_0, DocumentEventStyles.MouseDown);
		}

		/// <summary>
		///       创建鼠标移动按下事件参数
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <param name="e">原始事件参数</param>
		/// <returns>创建的参数</returns>
		[DCInternal]
		public static DocumentEventArgs CreateMouseMove(XTextDocument xtextDocument_0, MouseEventArgs mouseEventArgs_0)
		{
			return CreateMouseEvent(xtextDocument_0, mouseEventArgs_0, DocumentEventStyles.MouseMove);
		}

		/// <summary>
		///       创建鼠标按键松开事件参数
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <param name="e">原始事件参数</param>
		/// <returns>创建的参数</returns>
		[DCInternal]
		public static DocumentEventArgs CreateMouseUp(XTextDocument xtextDocument_0, MouseEventArgs mouseEventArgs_0)
		{
			return CreateMouseEvent(xtextDocument_0, mouseEventArgs_0, DocumentEventStyles.MouseUp);
		}

		/// <summary>
		///       创建键盘按键按下事件参数对象
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <param name="e">原始事件参数</param>
		/// <returns>创建的事件参数对象</returns>
		[DCInternal]
		public static DocumentEventArgs CreateKeyDown(XTextDocument xtextDocument_0, KeyEventArgs keyEventArgs_0)
		{
			DocumentEventArgs documentEventArgs = new DocumentEventArgs();
			documentEventArgs.myDocument = xtextDocument_0;
			documentEventArgs.bolAltKey = keyEventArgs_0.Alt;
			documentEventArgs.bolCtlKey = keyEventArgs_0.Control;
			documentEventArgs.bolShiftKey = keyEventArgs_0.Shift;
			documentEventArgs._KeyCode = keyEventArgs_0.KeyCode;
			documentEventArgs.intKeyChar = (char)keyEventArgs_0.KeyCode;
			documentEventArgs.intStyle = DocumentEventStyles.KeyDown;
			return documentEventArgs;
		}

		/// <summary>
		///       创建键盘按键按下事件参数对象
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <param name="e">原始事件参数</param>
		/// <returns>创建的事件参数对象</returns>
		[DCInternal]
		public static DocumentEventArgs CreateKeyPress(XTextDocument xtextDocument_0, KeyPressEventArgs keyPressEventArgs_0)
		{
			DocumentEventArgs documentEventArgs = new DocumentEventArgs();
			documentEventArgs.myDocument = xtextDocument_0;
			documentEventArgs.UpdateKeyState();
			documentEventArgs.intKeyChar = keyPressEventArgs_0.KeyChar;
			documentEventArgs.intStyle = DocumentEventStyles.KeyPress;
			return documentEventArgs;
		}

		/// <summary>
		///       创建键盘按键按下事件参数对象
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <param name="chr">字符值</param>
		/// <returns>创建的事件参数对象</returns>
		[DCInternal]
		public static DocumentEventArgs CreateKeyPress(XTextDocument xtextDocument_0, char char_0)
		{
			DocumentEventArgs documentEventArgs = new DocumentEventArgs();
			documentEventArgs.myDocument = xtextDocument_0;
			documentEventArgs.UpdateKeyState();
			documentEventArgs.intKeyChar = char_0;
			documentEventArgs.intStyle = DocumentEventStyles.KeyPress;
			return documentEventArgs;
		}

		/// <summary>
		///       创建键盘按键松开事件参数对象
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <param name="e">原始事件参数</param>
		/// <returns>创建的事件参数对象</returns>
		[DCInternal]
		public static DocumentEventArgs CreateKeyUp(XTextDocument xtextDocument_0, KeyEventArgs keyEventArgs_0)
		{
			DocumentEventArgs documentEventArgs = new DocumentEventArgs();
			documentEventArgs.myDocument = xtextDocument_0;
			documentEventArgs.bolAltKey = keyEventArgs_0.Alt;
			documentEventArgs.bolCtlKey = keyEventArgs_0.Control;
			documentEventArgs.bolShiftKey = keyEventArgs_0.Shift;
			documentEventArgs._KeyCode = keyEventArgs_0.KeyCode;
			documentEventArgs.intKeyChar = (char)keyEventArgs_0.KeyCode;
			documentEventArgs.intStyle = DocumentEventStyles.KeyUp;
			return documentEventArgs;
		}

		[DCInternal]
		private static DocumentEventArgs CreateMouseEvent(XTextDocument xtextDocument_0, MouseEventArgs mouseEventArgs_0, DocumentEventStyles style)
		{
			DocumentEventArgs documentEventArgs = new DocumentEventArgs();
			documentEventArgs._MouseClicks = mouseEventArgs_0.Clicks;
			documentEventArgs.myDocument = xtextDocument_0;
			documentEventArgs.intX = mouseEventArgs_0.X;
			documentEventArgs.intY = mouseEventArgs_0.Y;
			documentEventArgs._ViewX = mouseEventArgs_0.X;
			documentEventArgs._ViewY = mouseEventArgs_0.Y;
			documentEventArgs._Button = mouseEventArgs_0.Button;
			documentEventArgs.intWheelDelta = mouseEventArgs_0.Delta;
			documentEventArgs.UpdateKeyState();
			documentEventArgs.intStyle = style;
			return documentEventArgs;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="element">文档元素对象</param>
		/// <param name="style">事件类型</param>
		[DCInternal]
		public DocumentEventArgs(XTextDocument document, XTextElement element, DocumentEventStyles style)
		{
			myDocument = document;
			_Element = element;
			intStyle = style;
			UpdateKeyState();
		}

		/// <summary>
		///       内部使用的构造函数
		///       </summary>
		internal DocumentEventArgs()
		{
			myCursor = DefaultCursor;
			strTooltip = null;
		}

		private void UpdateKeyState()
		{
			Keys modifierKeys = Control.ModifierKeys;
			bolAltKey = ((modifierKeys & Keys.Shift) != 0);
			bolCtlKey = ((modifierKeys & Keys.Control) != 0);
			bolShiftKey = ((modifierKeys & Keys.Shift) != 0);
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>对象复制品</returns>
		[DCInternal]
		public DocumentEventArgs Clone()
		{
			return (DocumentEventArgs)MemberwiseClone();
		}
	}
}
