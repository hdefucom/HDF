using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.WinForms.Native
{
	/// <summary>
	///       绘制矩形动画的模块,本模块为Win32API函数 DrawAnimatedRects 的托管包装,并提供了新的动画功能.
	///       </summary>
	/// <remarks>
	///       编写 袁永福( http://www.xdesigner.cn ) 2006-12-12
	///       </remarks>
	/// <example>
	///       测试 AnimatedRectDrawer 的功能的一段代码
	///
	///       public class AnimatedRectDrawerTestForm : System.Windows.Forms.Form
	///       {
	///          public AnimatedRectDrawerTestForm()
	///          {
	///              this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	///              btn = new System.Windows.Forms.Button();
	///              this.Controls.Add(btn);
	///              btn.Text = "打开窗体";
	///              btn.Location = new System.Drawing.Point(30, 30);
	///              btn.Click += new EventHandler(btn_Click);
	///          }
	///
	///          private AnimatedRectDrawer drawer = new AnimatedRectDrawer();
	///          System.Windows.Forms.Button btn = null;
	///
	///          void btn_Click(object sender, EventArgs e)
	///          {
	///              System.Windows.Forms.Form frm = new System.Windows.Forms.Form();
	///              drawer.Add(btn, frm);
	///              frm.Owner = this;
	///              frm.Show();
	///          }
	///
	///          [STAThread]
	///          static void Main()
	///          {
	///              System.Windows.Forms.Application.Run(new AnimatedRectDrawerTestForm());
	///          }
	///       }//public class AnimatedRectDrawerTestForm : System.Windows.Forms.Form
	///       </example>
	[ComVisible(false)]
	public class AnimatedRectDrawer : IDisposable
	{
		[ComVisible(false)]
		public class GClass686
		{
			public Control control_0 = null;

			public Rectangle rectangle_0 = Rectangle.Empty;

			public Control control_1 = null;

			public Rectangle rectangle_1 = Rectangle.Empty;

			public object object_0 = null;
		}

		private struct Struct111
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;
		}

		private const int int_0 = 3;

		private const int int_1 = 2;

		private const int int_2 = 1;

		private static int int_3 = 0;

		public static AnimatedDrawStyle animatedDrawStyle_0 = AnimatedDrawStyle.System;

		private AnimatedDrawStyle animatedDrawStyle_1 = animatedDrawStyle_0;

		private ArrayList arrayList_0 = new ArrayList();

		private EventHandler eventHandler_0 = null;

		private EventHandler eventHandler_1 = null;

		/// <summary>
		///       绘制次数累计
		///       </summary>
		public static int DrawCount
		{
			get
			{
				return int_3;
			}
			set
			{
				int_3 = value;
			}
		}

		/// <summary>
		///       动画样式
		///       </summary>
		public AnimatedDrawStyle Style
		{
			get
			{
				return animatedDrawStyle_1;
			}
			set
			{
				animatedDrawStyle_1 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public AnimatedRectDrawer()
		{
			eventHandler_0 = method_2;
			eventHandler_1 = method_1;
		}

		/// <summary>
		///       添加项目
		///       </summary>
		/// <param name="ctl">原始控件</param>
		/// <param name="rect">原始矩形</param>
		/// <param name="frm">目标窗体</param>
		/// <returns>新增的项目对象</returns>
		public GClass686 Add(Control control_0, Rectangle rect, Form form_0)
		{
			GClass686 gClass = method_0(form_0);
			if (gClass == null)
			{
				gClass = new GClass686();
				arrayList_0.Add(gClass);
				form_0.Load += eventHandler_1;
				form_0.Closed += eventHandler_0;
			}
			gClass.control_0 = control_0;
			gClass.rectangle_0 = rect;
			gClass.control_1 = form_0;
			return gClass;
		}

		/// <summary>
		///       添加项目
		///       </summary>
		/// <param name="ctl">原始控件</param>
		/// <param name="frm">目标窗体</param>
		/// <returns>新增的项目对象</returns>
		public GClass686 Add(Control control_0, Form form_0)
		{
			return Add(control_0, Rectangle.Empty, form_0);
		}

		/// <summary>
		///       删除所有项目
		///       </summary>
		public void Clear()
		{
			arrayList_0.Clear();
		}

		public GClass686 method_0(Form form_0)
		{
			foreach (GClass686 item in arrayList_0)
			{
				if (item.control_1 == form_0)
				{
					return item;
				}
			}
			return null;
		}

		public static void smethod_0(Control control_0, Rectangle rectangle_0, Control control_1, AnimatedDrawStyle animatedDrawStyle_2)
		{
			GClass686 gClass = new GClass686();
			gClass.control_0 = control_0;
			gClass.rectangle_0 = rectangle_0;
			gClass.control_1 = control_1;
			smethod_3(gClass, bool_0: true, animatedDrawStyle_2);
		}

		public static void smethod_1(Control control_0, Rectangle rectangle_0, Control control_1, AnimatedDrawStyle animatedDrawStyle_2)
		{
			GClass686 gClass = new GClass686();
			gClass.control_0 = control_0;
			gClass.rectangle_0 = rectangle_0;
			gClass.control_1 = control_1;
			smethod_3(gClass, bool_0: false, animatedDrawStyle_2);
		}

		public static void smethod_2(Control control_0, Rectangle rectangle_0, Control control_1, Rectangle rectangle_1, AnimatedDrawStyle animatedDrawStyle_2)
		{
			GClass686 gClass = new GClass686();
			gClass.control_0 = control_0;
			gClass.rectangle_0 = rectangle_0;
			gClass.control_1 = control_1;
			gClass.rectangle_1 = rectangle_1;
			smethod_3(gClass, bool_0: true, animatedDrawStyle_2);
		}

		private void method_1(object sender, EventArgs e)
		{
			GClass686 gClass = method_0((Form)sender);
			if (gClass != null)
			{
				int_3++;
				smethod_3(gClass, bool_0: true, animatedDrawStyle_1);
			}
		}

		private void method_2(object sender, EventArgs e)
		{
			GClass686 gClass = method_0((Form)sender);
			if (gClass != null)
			{
				arrayList_0.Remove(gClass);
				smethod_3(gClass, bool_0: false, animatedDrawStyle_1);
			}
		}

		private static bool smethod_3(GClass686 gclass686_0, bool bool_0, AnimatedDrawStyle animatedDrawStyle_2)
		{
			if (animatedDrawStyle_2 == AnimatedDrawStyle.None)
			{
				return false;
			}
			if (gclass686_0 == null)
			{
				return false;
			}
			if (gclass686_0.control_1 == null)
			{
				return false;
			}
			Rectangle rectangle = smethod_7(gclass686_0.rectangle_0, gclass686_0.control_0);
			if (rectangle.IsEmpty)
			{
				return false;
			}
			Rectangle rectangle2 = smethod_7(gclass686_0.rectangle_1, gclass686_0.control_1);
			if (rectangle2.IsEmpty)
			{
				return false;
			}
			switch (animatedDrawStyle_2)
			{
			case AnimatedDrawStyle.Rectangle:
				if (bool_0)
				{
					smethod_4(rectangle, rectangle2);
				}
				else
				{
					smethod_4(rectangle2, rectangle);
				}
				return true;
			case AnimatedDrawStyle.RotateRectangle:
				if (bool_0)
				{
					smethod_5(rectangle, rectangle2);
				}
				else
				{
					smethod_5(rectangle2, rectangle);
				}
				return true;
			case AnimatedDrawStyle.System:
			{
				Point point = new Point(0, 0);
				Struct111 struct111_ = default(Struct111);
				struct111_.int_0 = rectangle.Left - point.X;
				struct111_.int_1 = rectangle.Top - point.Y;
				struct111_.int_2 = rectangle.Right - point.X;
				struct111_.int_3 = rectangle.Bottom - point.Y;
				Struct111 struct111_2 = default(Struct111);
				struct111_2.int_0 = rectangle2.Left - point.X;
				struct111_2.int_1 = rectangle2.Top - point.Y;
				struct111_2.int_2 = rectangle2.Right - point.X;
				struct111_2.int_3 = rectangle2.Bottom - point.Y;
				bool flag = false;
				IntPtr zero = IntPtr.Zero;
				zero = gclass686_0.control_1.Handle;
				flag = ((!bool_0) ? DrawAnimatedRects(zero, 3, ref struct111_2, ref struct111_) : DrawAnimatedRects(zero, 3, ref struct111_, ref struct111_2));
				if (!flag)
				{
					new Win32Exception();
				}
				return flag;
			}
			default:
				return false;
			}
		}

		private static void smethod_4(Rectangle rectangle_0, Rectangle rectangle_1)
		{
			Rectangle rectangle = Rectangle.Empty;
			int num = Environment.TickCount;
			int num2 = 10;
			for (int i = 0; i <= num2; i++)
			{
				Rectangle rectangle2 = smethod_9(rectangle_0, rectangle_1, (double)i / (double)num2);
				if (!rectangle.IsEmpty)
				{
					ControlPaint.DrawReversibleFrame(rectangle, Color.SkyBlue, FrameStyle.Thick);
				}
				num += 30;
				while (Environment.TickCount < num)
				{
					Thread.Sleep(5);
				}
				rectangle = rectangle2;
				float tickCountFloat = CountDown.GetTickCountFloat();
				ControlPaint.DrawReversibleFrame(rectangle2, Color.SkyBlue, FrameStyle.Thick);
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				if (i == 0 && tickCountFloat > 0f)
				{
					num2 = (int)(100f / tickCountFloat);
					if (num2 < 2)
					{
						num2 = 2;
					}
					else if (num2 > 10)
					{
						num2 = 10;
					}
				}
			}
			if (!rectangle.IsEmpty)
			{
				ControlPaint.DrawReversibleFrame(rectangle, Color.SkyBlue, FrameStyle.Thick);
			}
		}

		private static void smethod_5(Rectangle rectangle_0, Rectangle rectangle_1)
		{
			Rectangle rectangle_2 = Rectangle.Empty;
			int num = 10;
			for (int i = 0; i <= num; i++)
			{
				Rectangle rectangle = smethod_9(rectangle_0, rectangle_1, (double)i / (double)num);
				if (!rectangle_2.IsEmpty)
				{
					smethod_6(rectangle_2, Math.PI * (double)(i - 1) / 10.0);
				}
				rectangle_2 = rectangle;
				float tickCountFloat = CountDown.GetTickCountFloat();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				if (i == 0 && tickCountFloat > 0f)
				{
					num = (int)(100f / tickCountFloat);
					num = Math.Max(num, 2);
				}
				smethod_6(rectangle, Math.PI * (double)i / 10.0);
				Thread.Sleep(30);
			}
			if (!rectangle_2.IsEmpty)
			{
				smethod_6(rectangle_2, Math.PI);
			}
		}

		private static void smethod_6(Rectangle rectangle_0, double double_0)
		{
			Point[] array = smethod_10(new Point(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2), rectangle_0, double_0);
			Point[] array2 = new Point[5];
			Array.Copy(array, array2, 4);
			array2[4] = array[0];
			using (GClass249 gClass = GClass249.smethod_2())
			{
				gClass.method_8(2);
				gClass.method_12(array2);
			}
		}

		private static Rectangle smethod_7(Rectangle rectangle_0, Control control_0)
		{
			Rectangle empty = Rectangle.Empty;
			if (control_0 == null)
			{
				empty = rectangle_0;
			}
			else if (rectangle_0.IsEmpty)
			{
				empty = smethod_8(control_0);
			}
			else
			{
				empty = rectangle_0;
				empty.Location = control_0.PointToScreen(empty.Location);
			}
			return empty;
		}

		protected static Rectangle smethod_8(Control control_0)
		{
			if (control_0 == null)
			{
				return Rectangle.Empty;
			}
			if (control_0.IsHandleCreated)
			{
				Struct111 struct111_ = default(Struct111);
				if (GetWindowRect(control_0.Handle, ref struct111_))
				{
					return new Rectangle(struct111_.int_0, struct111_.int_1, struct111_.int_2 - struct111_.int_0, struct111_.int_3 - struct111_.int_1);
				}
			}
			return control_0.Bounds;
		}

		[DllImport("user32.dll")]
		private static extern bool DrawAnimatedRects(IntPtr intptr_0, int int_4, ref Struct111 struct111_0, ref Struct111 struct111_1);

		[DllImport("user32.dll")]
		private static extern bool GetWindowRect(IntPtr intptr_0, ref Struct111 struct111_0);

		public void Dispose()
		{
			Clear();
		}

		public static Rectangle smethod_9(Rectangle rectangle_0, Rectangle rectangle_1, double double_0)
		{
			int x = rectangle_0.Left + (int)((double)(rectangle_1.Left - rectangle_0.Left) * double_0);
			int y = rectangle_0.Top + (int)((double)(rectangle_1.Top - rectangle_0.Top) * double_0);
			int width = rectangle_0.Width + (int)((double)(rectangle_1.Width - rectangle_0.Width) * double_0);
			int height = rectangle_0.Height + (int)((double)(rectangle_1.Height - rectangle_0.Height) * double_0);
			return new Rectangle(x, y, width, height);
		}

		public static Point[] smethod_10(Point point_0, Rectangle rectangle_0, double double_0)
		{
			Point[] array = smethod_11(rectangle_0);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = smethod_12(point_0, array[i], double_0);
			}
			return array;
		}

		public static Point[] smethod_11(Rectangle rectangle_0)
		{
			return new Point[4]
			{
				new Point(rectangle_0.X, rectangle_0.Y),
				new Point(rectangle_0.Right, rectangle_0.Y),
				new Point(rectangle_0.Right, rectangle_0.Bottom),
				new Point(rectangle_0.Left, rectangle_0.Bottom)
			};
		}

		public static Point smethod_12(Point point_0, Point point_1, double double_0)
		{
			if (point_0.X == point_1.X && point_0.Y == point_1.Y)
			{
				return point_1;
			}
			double d = (point_1.X - point_0.X) * (point_1.X - point_0.X) + (point_1.Y - point_0.Y) * (point_1.Y - point_0.Y);
			d = Math.Sqrt(d);
			double num = Math.Atan2(point_1.Y - point_0.Y, point_1.X - point_0.X);
			num -= double_0;
			Point empty = Point.Empty;
			empty.X = (int)((double)point_0.X + d * Math.Cos(num));
			empty.Y = (int)((double)point_0.Y + d * Math.Sin(num));
			return empty;
		}
	}
}
