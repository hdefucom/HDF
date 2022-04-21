using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       支持文本编辑的分页视图控件
	///       </summary>
	[Guid("00012345-6789-ABCD-EF01-234567890004")]
	[ToolboxItem(false)]
	
	
	[ComVisible(true)]
	public class TextPageViewControl : PageViewControl
	{
		protected bool bool_16 = true;

		private static Keys[] keys_0 = new Keys[10]
		{
			Keys.Left,
			Keys.Up,
			Keys.Right,
			Keys.Down,
			Keys.Tab,
			Keys.Return,
			Keys.ShiftKey,
			Keys.Back,
			Keys.BrowserBack,
			Keys.Control
		};

		private bool bool_17 = false;

		protected bool bool_18 = true;

		private bool bool_19 = true;

		private bool bolCaretCreated = false;

		public static int int_6 = 2;

		public static int int_7 = 6;

		private Rectangle rectangle_2 = Rectangle.Empty;

		/// <summary>
		///       获取或设置一个值，该值指示在控件中按 TAB 键时，是否在控件中键入一个 TAB 字符，而不是按选项卡的顺序将焦点移动到下一个控件。
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool AcceptsTab
		{
			get
			{
				return bool_16;
			}
			set
			{
				bool_16 = value;
			}
		}

		/// <summary>
		///       是否强制显示光标而不管控件是否获得输入焦点
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool ForceShowCaret
		{
			get
			{
				return bool_17;
			}
			set
			{
				bool_17 = value;
			}
		}

		/// <summary>
		///       移动光标时是否自动滚动到光标区域
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool MoveCaretWithScroll
		{
			get
			{
				return bool_18;
			}
			set
			{
				bool_18 = value;
			}
		}

		/// <summary>
		///       当前是否处于插入模式,若处于插入模式,则光标比较细,否则处于改写模式,光标比较粗
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public virtual bool InsertMode
		{
			get
			{
				return bool_19;
			}
			set
			{
				bool_19 = value;
			}
		}

		/// <summary>
		///       光标已经创建标志
		///       </summary>
		[Browsable(false)]
		public bool CaretCreated => bolCaretCreated;

		/// <summary>
		///       光标控制对象
		///       </summary>
		
		[Browsable(false)]
		public virtual ICaretProvider Caret => null;

		/// <summary>
		///       重写键盘字符处理函数,保证控件能处理一些功能键
		///       </summary>
		/// <param name="keyData">按键数据</param>
		/// <returns>控件是否能处理按键数据</returns>
		protected override bool IsInputKey(Keys keyData)
		{
			if (keyData != (Keys)131137)
			{
			}
			if (keyData == Keys.Tab && !AcceptsTab)
			{
				return base.IsInputKey(keyData);
			}
			int num = 0;
			while (true)
			{
				if (num < keys_0.Length)
				{
					Keys keys = keys_0[num];
					if ((keys & keyData) == keys)
					{
						break;
					}
					num++;
					continue;
				}
				return base.IsInputKey(keyData);
			}
			return true;
		}

		[Browsable(false)]
		
		public virtual IImmProvider vmethod_33()
		{
			return null;
		}

		/// <summary>
		///       显示插入点光标
		///       </summary>
		public void ShowCaret()
		{
			if (CaretCreated && !rectangle_2.IsEmpty && Caret != null)
			{
				Caret.Create(1, rectangle_2.Width, rectangle_2.Height);
				Caret.SetPos(rectangle_2.X, rectangle_2.Y);
				Caret.Show();
			}
		}

		/// <summary>
		///       已重载:失去焦点,隐藏光标
		///       </summary>
		/// <param name="e">
		/// </param>
		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			if (CaretCreated && Caret != null)
			{
				Caret.Hide();
			}
			base.OnLostFocus(eventArgs_0);
		}

		public bool MoveCaretTo(int vLeft, int vTop, int vWidth, int vHeight, int 横向偏移量)
		{
			if (base.IsUpdating || !base.IsHandleCreated)
			{
				return false;
			}
			if (!ForceShowCaret && !Focused)
			{
				if (CaretCreated && Caret != null)
				{
					Caret.Hide();
				}
				return false;
			}
			int num = (int)((float)GraphicsUnitConvert.Convert(vHeight, GraphicsUnit, GraphicsUnit.Pixel) * base.YZoomRate);
			if (vWidth > 0 && vHeight > 0)
			{
				if (Caret == null)
				{
					bolCaretCreated = false;
				}
				else
				{
					bolCaretCreated = Caret.Create(0, vWidth, num);
				}
				if (CaretCreated)
				{
					if (MoveCaretWithScroll)
					{
						method_28(vLeft, vTop, Math.Max(vWidth, 横向偏移量), vHeight);
					}
					Point empty = Point.Empty;
					empty = ViewPointToClient(vLeft, vTop);
					if (Caret != null)
					{
						Caret.SetPos(empty.X, empty.Y);
						Caret.Show();
					}
					IImmProvider immProvider = vmethod_33();
					if (immProvider != null && immProvider.IsImmOpen())
					{
						immProvider.SetImmPos(empty.X, empty.Y);
					}
					rectangle_2 = new Rectangle(empty.X, empty.Y, vWidth, num);
					if (MoveCaretWithScroll)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool MoveTextCaretTo(int left, int bottom, int height, int 横向偏移量)
		{
			return MoveCaretTo(left, bottom - height, bool_19 ? int_6 : int_7, height, 横向偏移量);
		}

		public void method_58()
		{
			if (base.IsHandleCreated)
			{
				Caret.Hide();
			}
		}
	}
}
