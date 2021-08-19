using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       带边框的用户控件对象
	///       </summary>
	/// <remarks>本控件在UserControl的基础上实现了标准下陷的控件边框,并支持滚动事件
	///       新增属性 BorderStyle 可让控件不显示边框,显示简单的细边框或3D下陷式的粗边框 
	///       新增事件 Scroll ,当用户滚动控件时会触发该事件</remarks>
	[Guid("00012345-6789-ABCD-EF01-234567890007")]
	[DCInternal]
	[DocumentComment]
	[Browsable(false)]
	[ComVisible(true)]
	[ToolboxItem(false)]
	public class BorderUserControl : UserControl
	{
		private const int int_0 = 8;

		private const int int_1 = 17;

		public static bool bool_0 = true;

		private Bitmap bitmap_0 = null;

		private EventHandler eventHandler_0 = null;

		private bool bool_1 = false;

		/// <summary>
		///       启动双缓冲样式
		///       </summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		public bool DoubleBuffering
		{
			get
			{
				return GetStyle(ControlStyles.DoubleBuffer);
			}
			set
			{
				if (GetStyle(ControlStyles.DoubleBuffer) != value)
				{
					if (value)
					{
						SetStyle(ControlStyles.UserPaint, value: true);
						SetStyle(ControlStyles.DoubleBuffer, value: true);
						SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
					}
					else
					{
						SetStyle(ControlStyles.DoubleBuffer, value: false);
					}
					UpdateStyles();
					Invalidate();
				}
			}
		}

		/// <summary>
		///       正在冻结用户界面
		///       </summary>
		[Browsable(false)]
		public bool IsFreezeUI => bitmap_0 != null;

		/// <summary>
		///       发生滚动时的处理
		///       </summary>
	 	public event EventHandler XScroll
		{
			add
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public BorderUserControl()
		{
			AutoScroll = true;
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			SetStyle(ControlStyles.Selectable, value: true);
			if (bool_0)
			{
				SetStyle(ControlStyles.UserPaint, value: true);
				SetStyle(ControlStyles.DoubleBuffer, value: true);
				SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			}
		}

		/// <summary>
		///       冻结用户界面
		///       </summary>
		public void FreezeUI()
		{
			if (bitmap_0 == null)
			{
				Bitmap image = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
				using (Graphics graphics = Graphics.FromImage(image))
				{
					graphics.Clear(BackColor);
					PaintEventArgs e = new PaintEventArgs(graphics, new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height));
					OnPaint(e);
				}
				bitmap_0 = image;
			}
		}

		/// <summary>
		///       解冻用户界面
		///       </summary>
		public void ReleaseFreezeUI()
		{
			if (bitmap_0 != null)
			{
				bitmap_0.Dispose();
				bitmap_0 = null;
				Invalidate();
			}
		}

		protected void method_0(PaintEventArgs paintEventArgs_0)
		{
			if (bitmap_0 != null)
			{
				paintEventArgs_0.Graphics.DrawImage(bitmap_0, paintEventArgs_0.ClipRectangle.Left, paintEventArgs_0.ClipRectangle.Top, new RectangleF(paintEventArgs_0.ClipRectangle.Left, paintEventArgs_0.ClipRectangle.Top, paintEventArgs_0.ClipRectangle.Width, paintEventArgs_0.ClipRectangle.Height), GraphicsUnit.Pixel);
			}
		}

		/// <summary>
		///       绘制控件内容
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnPaint(PaintEventArgs pevent)
		{
			if (IsFreezeUI)
			{
				method_0(pevent);
			}
			else
			{
				base.OnPaint(pevent);
			}
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		/// <param name="disposing">
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (bitmap_0 != null)
			{
				bitmap_0.Dispose();
				bitmap_0 = null;
			}
			base.Dispose(disposing);
		}

		[DllImport("imm32.dll")]
		public static extern IntPtr ImmGetContext(IntPtr intptr_0);

		[DllImport("imm32.dll")]
		public static extern bool ImmGetOpenStatus(IntPtr intptr_0);

		[DllImport("imm32.dll")]
		public static extern bool ImmSetOpenStatus(IntPtr intptr_0, bool bool_2);

		[DllImport("imm32.dll")]
		public static extern bool ImmGetConversionStatus(IntPtr intptr_0, ref int int_2, ref int int_3);

		[DllImport("imm32.dll")]
		public static extern int ImmSimulateHotKey(IntPtr intptr_0, int int_2);

		protected virtual void OnXScroll()
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, null);
			}
		}

		public void method_1()
		{
			OnXScroll();
		}

		public void method_2(bool bool_2)
		{
			base.HScroll = bool_2;
		}

		public void method_3(bool bool_2)
		{
			base.VScroll = bool_2;
		}

		/// <summary>
		///       已重载:处理Windows底层消息,此处用于判断是否触发 Scroll 滚动事件
		///       </summary>
		/// <param name="m">Windows消息结构体</param>
		protected override void WndProc(ref Message message_0)
		{
			if (!base.IsHandleCreated)
			{
				base.WndProc(ref message_0);
				return;
			}
			if (message_0.Msg == 522)
			{
				OnXScroll();
			}
			else if (message_0.HWnd == base.Handle)
			{
				if (message_0.Msg == 276 || message_0.Msg == 277)
				{
					int num = message_0.WParam.ToInt32();
					if ((num & 0xF) == 5)
					{
						base.WndProc(ref message_0);
						if (!bool_1)
						{
							num--;
							message_0.WParam = new IntPtr(num);
							base.WndProc(ref message_0);
						}
						OnXScroll();
					}
					else
					{
						base.WndProc(ref message_0);
						OnXScroll();
					}
					return;
				}
				if (message_0.Msg == 15)
				{
				}
			}
			base.WndProc(ref message_0);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			bool_1 = GClass281.smethod_0();
			base.OnHandleCreated(eventArgs_0);
		}
	}
}
