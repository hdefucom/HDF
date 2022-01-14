using DCSoftDotfuscate;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.WinForms.Native
{
	/// <summary>
	///       捕获鼠标的模块
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComVisible(false)]
	public class MouseCapturer
	{
		private struct Struct0
		{
			public IntPtr intptr_0;

			public int int_0;

			public IntPtr intptr_1;

			public IntPtr intptr_2;

			public uint uint_0;

			public int int_1;

			public int int_2;
		}

		private struct Struct1
		{
			public int int_0;

			public int int_1;
		}

		private enum Enum0
		{
			const_0,
			const_1,
			const_2
		}

		protected Control control_0 = null;

		private Point point_0 = Point.Empty;

		private Point point_1 = Point.Empty;

		private Point point_2 = Point.Empty;

		private Point point_3 = Point.Empty;

		private Point point_4 = Point.Empty;

		private Size size_0 = Size.Empty;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private GDelegate13 gdelegate13_0 = null;

		private GDelegate13 gdelegate13_1 = null;

		private GEnum68 genum68_0 = GEnum68.const_4;

		private object object_0 = null;

		private bool bool_0 = false;

		/// <summary>
		///       对象绑定的控件,若该控件有效则鼠标光标是用控件客户区坐标,否则采用屏幕坐标
		///       </summary>
		public Control BindControl
		{
			get
			{
				return control_0;
			}
			set
			{
				control_0 = value;
			}
		}

		/// <summary>
		///       初始化时的鼠标开始位置
		///       </summary>
		public Point InitStartPosition
		{
			get
			{
				return point_0;
			}
			set
			{
				point_0 = value;
			}
		}

		/// <summary>
		///       开始捕获时的鼠标光标的位置
		///       </summary>
		public Point StartPosition
		{
			get
			{
				return point_1;
			}
			set
			{
				point_1 = value;
			}
		}

		/// <summary>
		///       结束捕获时鼠标光标位置
		///       </summary>
		public Point EndPosition => point_2;

		/// <summary>
		///       上一次处理时鼠标光标位置
		///       </summary>
		public Point LastPosition => point_3;

		/// <summary>
		///       当前鼠标光标的位置
		///       </summary>
		public Point CurrentPosition => point_4;

		/// <summary>
		///       整个操作中鼠标移动的距离,属性的Width值表示光标横向移动的距离,Height值表示纵向移动距离
		///       </summary>
		public Size MoveSize
		{
			get
			{
				return size_0;
			}
			set
			{
				size_0 = value;
			}
		}

		/// <summary>
		///       整个操作中鼠标横向移动距离
		///       </summary>
		public int DX => point_2.X - point_1.X;

		/// <summary>
		///       整个操作中鼠标纵向移动距离
		///       </summary>
		public int DY => point_2.Y - point_1.Y;

		/// <summary>
		///       鼠标移动起点和终点组成的矩形区域
		///       </summary>
		public Rectangle CaptureRectagle => smethod_3(point_1, point_2);

		/// <summary>
		///       鼠标光标的活动范围
		///       </summary>
		public Rectangle ClipRectangle
		{
			get
			{
				return rectangle_0;
			}
			set
			{
				rectangle_0 = value;
			}
		}

		/// <summary>
		///       可逆图形样式
		///       </summary>
		public GEnum68 ReversibleShape
		{
			get
			{
				return genum68_0;
			}
			set
			{
				genum68_0 = value;
			}
		}

		/// <summary>
		///       对象额外数据
		///       </summary>
		public object Tag
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		public bool CancelFlag
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public Size CurrentMoveSize => new Size(point_4.X - point_1.X, point_4.Y - point_1.Y);

		private Point CurMousePosition => method_3(Control.MousePosition);

		private Point CurMousePosition2
		{
			get
			{
				Point point = Control.MousePosition;
				if (BindControl != null)
				{
					point = BindControl.PointToClient(point);
				}
				return point;
			}
		}

		/// <summary>
		///       鼠标捕获期间移动时的回调处理事件
		///       </summary>
		public event GDelegate13 MouseMove
		{
			add
			{
				GDelegate13 gDelegate = gdelegate13_0;
				GDelegate13 gDelegate2;
				do
				{
					gDelegate2 = gDelegate;
					GDelegate13 value2 = (GDelegate13)Delegate.Combine(gDelegate2, value);
					gDelegate = Interlocked.CompareExchange(ref gdelegate13_0, value2, gDelegate2);
				}
				while ((object)gDelegate != gDelegate2);
			}
			remove
			{
				GDelegate13 gDelegate = gdelegate13_0;
				GDelegate13 gDelegate2;
				do
				{
					gDelegate2 = gDelegate;
					GDelegate13 value2 = (GDelegate13)Delegate.Remove(gDelegate2, value);
					gDelegate = Interlocked.CompareExchange(ref gdelegate13_0, value2, gDelegate2);
				}
				while ((object)gDelegate != gDelegate2);
			}
		}

		/// <summary>
		///       鼠标捕获期间绘制可逆图形的回调处理事件
		///       </summary>
		public event GDelegate13 Draw
		{
			add
			{
				GDelegate13 gDelegate = gdelegate13_1;
				GDelegate13 gDelegate2;
				do
				{
					gDelegate2 = gDelegate;
					GDelegate13 value2 = (GDelegate13)Delegate.Combine(gDelegate2, value);
					gDelegate = Interlocked.CompareExchange(ref gdelegate13_1, value2, gDelegate2);
				}
				while ((object)gDelegate != gDelegate2);
			}
			remove
			{
				GDelegate13 gDelegate = gdelegate13_1;
				GDelegate13 gDelegate2;
				do
				{
					gDelegate2 = gDelegate;
					GDelegate13 value2 = (GDelegate13)Delegate.Remove(gDelegate2, value);
					gDelegate = Interlocked.CompareExchange(ref gdelegate13_1, value2, gDelegate2);
				}
				while ((object)gDelegate != gDelegate2);
			}
		}

		public static Rectangle smethod_0(Control control_1, int int_0, int int_1)
		{
			int num = 18;
			if (control_1 == null || control_1.IsDisposed)
			{
				throw new ArgumentNullException("ctl");
			}
			if (control_1.IsDisposed)
			{
				throw new ArgumentException("ctl Disposed");
			}
			if (WinFormUtils.DragDetect(control_1.Handle))
			{
				MouseCapturer mouseCapturer = new MouseCapturer(control_1);
				mouseCapturer.ReversibleShape = GEnum68.const_1;
				mouseCapturer.StartPosition = new Point(int_0, int_1);
				if (mouseCapturer.method_1())
				{
					return mouseCapturer.CaptureRectagle;
				}
			}
			return Rectangle.Empty;
		}

		/// <summary>
		///       无作为的初始化对象
		///       </summary>
		public MouseCapturer()
		{
		}

		/// <summary>
		///       初始化对象并设置绑定的控件
		///       </summary>
		/// <param name="ctl">绑定的控件</param>
		public MouseCapturer(Control control_1)
		{
			control_0 = control_1;
		}

		protected virtual CaptureMouseMoveEventArgs vmethod_0()
		{
			return new CaptureMouseMoveEventArgs(this, point_1, point_4);
		}

		protected virtual void vmethod_1()
		{
			if (gdelegate13_0 != null)
			{
				gdelegate13_0(this, vmethod_0());
			}
		}

		protected virtual void vmethod_2(bool bool_1)
		{
			if (ReversibleShape == GEnum68.const_4)
			{
				if (gdelegate13_1 != null)
				{
					CaptureMouseMoveEventArgs gEventArgs = vmethod_0();
					gEventArgs.method_10(bool_1);
					gdelegate13_1(this, gEventArgs);
				}
				return;
			}
			GClass249 gClass = null;
			gClass = ((control_0 != null) ? GClass249.smethod_0(control_0.Handle) : GClass249.smethod_2());
			gClass.method_21(GEnum64.const_0);
			gClass.method_23(Color.White);
			gClass.method_8(1);
			Rectangle rectangle = smethod_3(StartPosition, CurrentPosition);
			switch (ReversibleShape)
			{
			case GEnum68.const_0:
				gClass.method_13(StartPosition, CurrentPosition);
				break;
			case GEnum68.const_1:
				gClass.DrawRectangle(rectangle);
				break;
			case GEnum68.const_2:
				gClass.method_16(rectangle);
				break;
			case GEnum68.const_3:
				gClass.method_19(rectangle);
				break;
			}
			gClass.Dispose();
		}

		protected virtual void vmethod_3()
		{
			Rectangle rectangle = smethod_3(point_1, point_4);
			switch (genum68_0)
			{
			case GEnum68.const_2:
				break;
			case GEnum68.const_0:
				ControlPaint.DrawReversibleLine(point_1, point_4, Color.Black);
				break;
			case GEnum68.const_1:
				ControlPaint.DrawReversibleFrame(rectangle, Color.SkyBlue, FrameStyle.Dashed);
				break;
			case GEnum68.const_3:
				ControlPaint.FillReversibleRectangle(rectangle, Color.Black);
				break;
			case GEnum68.const_4:
				if (gdelegate13_1 != null)
				{
					gdelegate13_1(this, null);
				}
				break;
			}
		}

		public void method_0()
		{
			if (point_0.IsEmpty)
			{
				point_1 = CurMousePosition;
			}
			else
			{
				point_1 = point_0;
			}
			point_3 = point_1;
			point_4 = point_1;
			point_2 = point_1;
			size_0 = Size.Empty;
		}

		public bool method_1()
		{
			return CaptureMouseMove(bool_1: true);
		}

		public bool CaptureMouseMove(bool bool_1)
		{
			method_0();
			Struct0 struct0_ = default(Struct0);
			int width = SystemInformation.DragSize.Width;
			bool flag = false;
			if (Control.MouseButtons == MouseButtons.None)  
			{
				return false;
			}
			Point point = CurMousePosition;
			bool_0 = false;
			bool flag2 = false;
			Cursor cursor = null;
			if (BindControl != null)
			{
				cursor = BindControl.Cursor;
				if (bool_1 && !DragDetect(BindControl.Handle))
				{
					return false;
				}
				BindControl.Cursor = cursor;
				BindControl.Capture = true;
				flag = true;
			}
			else
			{
				Application.DoEvents();
				flag = true;
			}
			int num = 0;
			while (true)
			{
				MsgWaitForMultipleObjects(1, 0, bool_1: true, 20, 255);
				if (!PeekMessage(ref struct0_, 0, 0u, 0u, 0u))
				{
					continue;
				}
				num++;
				if (Control.MouseButtons == MouseButtons.None || bool_0)
				{
					break;
				}
				if (!GClass293.smethod_1(struct0_.int_0))
				{
					MouseButtons mouseButtons = MouseButtons.Left;
					if (GClass293.smethod_3(struct0_.int_0))
					{
						mouseButtons = GClass293.smethod_4(struct0_.intptr_1.ToInt32());
					}
					if (GClass293.smethod_0(struct0_.int_0))
					{
						point = CurMousePosition2;
						Point point2 = point;
						if (point2.X != point_4.X || point2.Y != point_4.Y)
						{
							if (flag2)
							{
								vmethod_2(bool_1: true);
							}
							point_4 = point2;
							if (!flag && (Math.Abs(point_4.X - point_1.X) >= width || Math.Abs(point_4.Y - point_1.Y) >= width))
							{
								flag = true;
							}
							if (flag)
							{
								point_4 = point2;
								vmethod_2(bool_1: false);
								flag2 = true;
								vmethod_1();
								point_3 = point_4;
							}
						}
						GetMessage(ref struct0_, 0, 0u, 0u);
					}
					else
					{
						GetMessage(ref struct0_, 0, 0u, 0u);
						if (struct0_.int_0 == 514 || struct0_.int_0 == 517)
						{
							break;
						}
						if (struct0_.int_0 != 15)
						{
							TranslateMessage(ref struct0_);
							DispatchMessage(ref struct0_);
						}
					}
					if (mouseButtons == MouseButtons.None)
					{
						break;
					}
					continue;
				}
				GetMessage(ref struct0_, 0, 0u, 0u);
				break;
			}
			point_4 = point;
			if (flag2)
			{
				vmethod_2(bool_1: true);
			}
			point_2 = point_4;
			size_0 = new Size(point_2.X - point_1.X, point_2.Y - point_1.Y);
			if (BindControl != null && cursor != null)
			{
				BindControl.Cursor = cursor;
				BindControl.Capture = false;
			}
			if (bool_0)
			{
				return false;
			}
			if (size_0.Width == 0 && size_0.Height == 0)
			{
				return false;
			}
			return flag;
		}

		private Point method_3(Point point_5)
		{
			if (control_0 != null)
			{
				point_5 = control_0.PointToClient(point_5);
			}
			return smethod_4(point_5, rectangle_0);
		}

		private Point method_4(Point point_5)
		{
			if (control_0 != null)
			{
				point_5 = control_0.PointToClient(point_5);
			}
			return point_5;
		}

		/// <summary>
		///       检测鼠标是否开始执行了拖拽操作
		///       </summary>
		/// <param name="hwnd">
		/// </param>
		/// <returns>是否开始进行了鼠标拖拽操作</returns>
		public static bool DragDetect(IntPtr hwnd)
		{
			Struct1 struct1_ = default(Struct1);
			struct1_.int_0 = Control.MousePosition.X;
			struct1_.int_1 = Control.MousePosition.Y;
			return DragDetect(hwnd, struct1_);
		}

		private static bool smethod_1(int int_0)
		{
			if (int_0 == 512 || int_0 == 160)
			{
				return true;
			}
			return false;
		}

		private static bool smethod_2(int int_0)
		{
			if (int_0 == 514 || int_0 == 520 || int_0 == 517 || int_0 == 524)
			{
				return true;
			}
			if (int_0 == 162 || int_0 == 168 || int_0 == 165 || int_0 == 172)
			{
				return true;
			}
			return false;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool DragDetect(IntPtr intptr_0, Struct1 struct1_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int MsgWaitForMultipleObjects(int int_0, int int_1, bool bool_1, int int_2, int int_3);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool GetMessage(ref Struct0 struct0_0, int int_0, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool PeekMessage(ref Struct0 struct0_0, int int_0, uint uint_0, uint uint_1, uint uint_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool WaitMessage();

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool TranslateMessage(ref Struct0 struct0_0);

		[DllImport("user32.dll")]
		private static extern IntPtr DispatchMessage(ref Struct0 struct0_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool IsWindowUnicode(HandleRef handleRef_0);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
		private static extern IntPtr DispatchMessageA([In] ref Struct0 struct0_0);

		internal static Rectangle smethod_3(Point point_5, Point point_6)
		{
			Rectangle empty = Rectangle.Empty;
			empty.X = Math.Min(point_5.X, point_6.X);
			empty.Y = Math.Min(point_5.Y, point_6.Y);
			empty.Width = Math.Max(point_5.X, point_6.X) - empty.Left;
			empty.Height = Math.Max(point_5.Y, point_6.Y) - empty.Top;
			return empty;
		}

		public static Point smethod_4(Point point_5, Rectangle rectangle_1)
		{
			if (!rectangle_1.IsEmpty)
			{
				if (point_5.X < rectangle_1.Left)
				{
					point_5.X = rectangle_1.Left;
				}
				if (point_5.X >= rectangle_1.Right)
				{
					point_5.X = rectangle_1.Right;
				}
				if (point_5.Y < rectangle_1.Top)
				{
					point_5.Y = rectangle_1.Top;
				}
				if (point_5.Y >= rectangle_1.Bottom)
				{
					point_5.Y = rectangle_1.Bottom;
				}
			}
			return point_5;
		}
	}
}
