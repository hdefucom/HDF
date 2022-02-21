using DCSoft.Common;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer
{
	/// <summary>
	///       元素鼠标事件参数类型
	///       </summary>
	[Guid("BB04154D-8AFE-413A-A5F3-608DC2C5E345")]
	[ComVisible(true)]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IElementMouseEventArgs))]
	
	[ComClass("BB04154D-8AFE-413A-A5F3-608DC2C5E345", "73B53D58-5AB7-4C9E-BBE3-B5C03CEDF98A")]
	public class ElementMouseEventArgs : ElementEventArgs, IElementMouseEventArgs
	{
		internal new const string CLASSID = "BB04154D-8AFE-413A-A5F3-608DC2C5E345";

		internal new const string CLASSID_Interface = "73B53D58-5AB7-4C9E-BBE3-B5C03CEDF98A";

		private MouseButtons _Button = MouseButtons.None;

		private int _Clicks = 0;

		private int _Delta = 0;

		private float _DocumentX = 0f;

		private float _DocumentY = 0f;

		private float _ElementClientX = 0f;

		private float _ElementClientY = 0f;

		/// <summary>
		///       鼠标按键值
		///       </summary>
		[Browsable(false)]
		
		public MouseButtons Button
		{
			get
			{
				return _Button;
			}
			set
			{
				_Button = value;
			}
		}

		/// <summary>
		///       用户是否按下左按钮
		///       </summary>
		
		public bool HasLeftButton => (_Button & MouseButtons.Left) == MouseButtons.Left;

		/// <summary>
		///       用户是否按下右按钮
		///       </summary>
		
		public bool HasRightButton => (_Button & MouseButtons.Right) == MouseButtons.Right;

		/// <summary>
		///       鼠标按键值
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(true)]
		
		[Obsolete("本属性仅仅作为COM接口使用")]
		public int ButtonValue => (int)Button;

		/// <summary>
		///       按键点击次数
		///       </summary>
		
		public int Clicks
		{
			get
			{
				return _Clicks;
			}
			set
			{
				_Clicks = value;
			}
		}

		/// <summary>
		///       鼠标滚轮计数
		///       </summary>
		
		public int Delta
		{
			get
			{
				return _Delta;
			}
			set
			{
				_Delta = value;
			}
		}

		/// <summary>
		///       鼠标光标在文档中的X坐标
		///       </summary>
		
		public float DocumentX
		{
			get
			{
				return _DocumentX;
			}
			set
			{
				_DocumentX = value;
			}
		}

		/// <summary>
		///       鼠标光标在文档中的Y坐标
		///       </summary>
		
		public float DocumentY
		{
			get
			{
				return _DocumentY;
			}
			set
			{
				_DocumentY = value;
			}
		}

		/// <summary>
		///       鼠标光标在元素客户区中的X坐标
		///       </summary>
		
		public float ElementClientX
		{
			get
			{
				return _ElementClientX;
			}
			set
			{
				_ElementClientX = value;
			}
		}

		/// <summary>
		///       鼠标光标在元素客户区中的Y坐标
		///       </summary>
		
		public float ElementClientY
		{
			get
			{
				return _ElementClientY;
			}
			set
			{
				_ElementClientY = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <param name="element">
		/// </param>
		public ElementMouseEventArgs(DocumentEventArgs args, XTextElement element)
			: base(element)
		{
			_Button = args.Button;
			_Clicks = args.MouseClicks;
			_Delta = args.WheelDelta;
			_DocumentX = args.X;
			_DocumentY = args.Y;
			if (element != null)
			{
				RuntimeDocumentContentStyle runtimeStyle = element.RuntimeStyle;
				RectangleF absBounds = element.AbsBounds;
				_ElementClientX = _DocumentX - absBounds.X - runtimeStyle.PaddingLeft;
				_ElementClientY = _DocumentY - absBounds.Y - runtimeStyle.PaddingTop;
			}
		}
	}
}
