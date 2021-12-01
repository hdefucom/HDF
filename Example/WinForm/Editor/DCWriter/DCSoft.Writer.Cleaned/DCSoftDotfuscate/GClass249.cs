using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass249 : GClass248
	{
		private enum Enum20
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 3,
			const_3 = 4,
			const_4 = 5,
			const_5 = 6,
			const_6 = 7,
			const_7 = 8,
			const_8 = 9,
			const_9 = 10,
			const_10 = 11,
			const_11 = 12,
			const_12 = 13,
			const_13 = 14,
			const_14 = 0xF,
			const_15 = 0x10,
			const_16 = 0x10
		}

		private struct Struct68
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;
		}

		private int int_1 = 1;

		private int int_2 = 0;

		private GClass266 gclass266_0 = new GClass266(Color.Black);

		public static GClass249 smethod_0(IntPtr intptr_2)
		{
			GClass249 gClass = new GClass249();
			gClass.method_1(intptr_2);
			return gClass;
		}

		public static GClass249 smethod_1(IntPtr intptr_2)
		{
			GClass249 gClass = new GClass249();
			gClass.method_0(intptr_2);
			return gClass;
		}

		public static GClass249 smethod_2()
		{
			GClass249 gClass = new GClass249();
			gClass.method_1(new IntPtr(0));
			return gClass;
		}

		private GClass249()
		{
		}

		public GClass249(Graphics graphics_1)
		{
			method_2(graphics_1);
		}

		public int method_7()
		{
			return int_1;
		}

		public void method_8(int int_3)
		{
			if (int_1 != int_3 && int_3 > 0)
			{
				int_1 = int_3;
				gclass266_0.Dispose();
				gclass266_0 = new GClass266(int_1, Color.Black);
			}
		}

		public void method_9()
		{
			int_2 = SetROP2(intptr_0, 6);
		}

		public void method_10()
		{
			SetROP2(intptr_0, int_2);
		}

		public void method_11(int int_3, int int_4, int int_5, int int_6)
		{
			int int_7 = SetROP2(intptr_0, 6);
			gclass266_0.method_12(intptr_0, int_3, int_4, int_5, int_6);
			SetROP2(intptr_0, int_7);
		}

		public void method_12(Point[] point_0)
		{
			int int_ = SetROP2(intptr_0, 6);
			gclass266_0.method_13(intptr_0, point_0);
			SetROP2(intptr_0, int_);
		}

		public void method_13(Point point_0, Point point_1)
		{
			method_11(point_0.X, point_0.Y, point_1.X, point_1.Y);
		}

		/// <summary>
		/// 绘制可逆矩形
		/// </summary>
		public void DrawRectangle(int int_3, int int_4, int int_5, int int_6)
		{
			int int_7 = SetROP2(intptr_0, 7);
			IntPtr intptr_ = method_6(GetStockObject(5));
			IntPtr intptr_2 = method_6(gclass266_0.method_0());
			Rectangle(intptr_0, int_3, int_4, int_3 + int_5, int_4 + int_6);
			method_6(intptr_);
			method_6(intptr_2);
			SetROP2(intptr_0, int_7);
		}

		/// <summary>
		/// 绘制可逆矩形
		/// </summary>
		public void DrawRectangle(Rectangle rectangle_0)
		{
			DrawRectangle(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height);
		}

		public void method_16(Rectangle rectangle_0)
		{
			method_17(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height);
		}

		public void method_17(int int_3, int int_4, int int_5, int int_6)
		{
			int int_7 = SetROP2(intptr_0, 7);
			IntPtr intptr_ = method_6(GetStockObject(5));
			IntPtr intptr_2 = method_6(gclass266_0.method_0());
			Ellipse(intptr_0, int_3, int_4, int_3 + int_5, int_4 + int_6);
			method_6(intptr_);
			method_6(intptr_2);
			SetROP2(intptr_0, int_7);
		}

		public void method_18(int int_3, int int_4, int int_5, int int_6)
		{
			Struct68 struct68_ = default(Struct68);
			struct68_.int_0 = int_3;
			struct68_.int_1 = int_4;
			struct68_.int_2 = int_3 + int_5;
			struct68_.int_3 = int_4 + int_6;
			InvertRect(intptr_0, ref struct68_);
		}

		public void method_19(Rectangle rectangle_0)
		{
			method_18(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height);
		}

		public override void Dispose()
		{
			base.Dispose();
			if (gclass266_0 != null)
			{
				gclass266_0.Dispose();
				gclass266_0 = null;
			}
		}

		public GEnum64 method_20()
		{
			return gclass266_0.method_6();
		}

		public void method_21(GEnum64 genum64_0)
		{
			gclass266_0.method_7(genum64_0);
		}

		public Color method_22()
		{
			return gclass266_0.method_10();
		}

		public void method_23(Color color_0)
		{
			gclass266_0.method_11(color_0);
		}

		[DllImport("gdi32")]
		private static extern IntPtr GetStockObject(int int_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int SetROP2(IntPtr intptr_2, int int_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool LineTo(IntPtr intptr_2, int int_3, int int_4);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool MoveToEx(IntPtr intptr_2, int int_3, int int_4, int int_5);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool Rectangle(IntPtr intptr_2, int int_3, int int_4, int int_5, int int_6);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int InvertRect(IntPtr intptr_2, ref Struct68 struct68_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int InvertRgn(IntPtr intptr_2, IntPtr intptr_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool Ellipse(IntPtr intptr_2, int int_3, int int_4, int int_5, int int_6);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool Arc(IntPtr intptr_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8, int int_9, int int_10);
	}
}
