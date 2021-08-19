using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass250 : GClass248
	{
		private struct Struct73
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;
		}

		private static GClass250 gclass250_0 = null;

		public static GClass250 smethod_0(IntPtr intptr_2)
		{
			GClass250 gClass = new GClass250();
			gClass.method_1(intptr_2);
			return gClass;
		}

		public static GClass250 smethod_1(IntPtr intptr_2)
		{
			GClass250 gClass = new GClass250();
			gClass.method_4(intptr_2);
			return gClass;
		}

		public static GClass250 smethod_2()
		{
			return new GClass250("DISPLAY");
		}

		public static GClass250 smethod_3()
		{
			int num = 2;
			if (gclass250_0 == null)
			{
				gclass250_0 = new GClass250("DISPLAY");
			}
			return gclass250_0;
		}

		private GClass250()
		{
		}

		public GClass250(Graphics graphics_1)
		{
			if (graphics_1 != null)
			{
				method_2(graphics_1);
			}
		}

		public GClass250(IntPtr intptr_2)
		{
			method_0(intptr_2);
		}

		public GClass250(string string_0)
		{
			method_3(string_0);
		}

		public GEnum54 method_7()
		{
			return (GEnum54)GetROP2(intptr_0);
		}

		public void method_8(GEnum54 genum54_0)
		{
			SetROP2(intptr_0, (int)genum54_0);
		}

		public Color method_9()
		{
			return Color.FromArgb(GetBkColor(intptr_0));
		}

		public void method_10(Color color_0)
		{
			SetBkColor(intptr_0, color_0.ToArgb());
		}

		public Graphics method_11()
		{
			return Graphics.FromHdc(intptr_0);
		}

		public Color method_12(Point point_0)
		{
			return method_13(point_0.X, point_0.Y);
		}

		public Color method_13(int int_1, int int_2)
		{
			int pixel = GetPixel(intptr_0, int_1, int_2);
			return Color.FromArgb(255, pixel & 0xFF, (pixel & 0xFF00) >> 8, pixel >> 16);
		}

		public void method_14(Point point_0, Color color_0)
		{
			method_15(point_0.X, point_0.Y, color_0);
		}

		public void method_15(int int_1, int int_2, Color color_0)
		{
			int int_3 = color_0.R + color_0.G * 256 + color_0.B * 65536;
			SetPixel(intptr_0, int_1, int_2, int_3);
		}

		public void method_16(int int_1, int int_2, int int_3, int int_4)
		{
			if (intptr_0.ToInt32() != 0)
			{
				Struct73 struct73_ = default(Struct73);
				struct73_.int_0 = int_1;
				struct73_.int_1 = int_2;
				struct73_.int_2 = int_1 + int_3;
				struct73_.int_3 = int_2 + int_4;
				DrawFocusRect(intptr_0, ref struct73_);
			}
		}

		public void method_17(Rectangle rectangle_0)
		{
			if (intptr_0.ToInt32() != 0)
			{
				Struct73 struct73_ = default(Struct73);
				struct73_.int_0 = rectangle_0.Left;
				struct73_.int_1 = rectangle_0.Top;
				struct73_.int_2 = rectangle_0.Right;
				struct73_.int_3 = rectangle_0.Bottom;
				DrawFocusRect(intptr_0, ref struct73_);
			}
		}

		public void method_18(Rectangle rectangle_0)
		{
			Rectangle(intptr_0, rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Bottom);
		}

		public void method_19(int int_1, int int_2, int int_3, int int_4)
		{
			Rectangle(intptr_0, int_1, int_2, int_1 + int_3, int_2 + int_4);
		}

		public void method_20(int int_1, int int_2, int int_3, int int_4)
		{
			if (intptr_0.ToInt32() != 0)
			{
				Struct73 struct73_ = default(Struct73);
				struct73_.int_0 = int_1;
				struct73_.int_1 = int_2;
				struct73_.int_2 = int_1 + int_3;
				struct73_.int_3 = int_2 + int_4;
				InvertRect(intptr_0, ref struct73_);
			}
		}

		public void method_21(Rectangle rectangle_0)
		{
			if (intptr_0.ToInt32() != 0)
			{
				Struct73 struct73_ = default(Struct73);
				struct73_.int_0 = rectangle_0.Left;
				struct73_.int_1 = rectangle_0.Top;
				struct73_.int_2 = rectangle_0.Right;
				struct73_.int_3 = rectangle_0.Bottom;
				InvertRect(intptr_0, ref struct73_);
			}
		}

		public Bitmap method_22()
		{
			GClass294 gClass = new GClass294(intptr_0);
			return method_24(0, 0, gClass.method_8(), gClass.method_9());
		}

		public Bitmap method_23(Rectangle rectangle_0)
		{
			return method_24(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height);
		}

		public Bitmap method_24(int int_1, int int_2, int int_3, int int_4)
		{
			GClass294 gClass = new GClass294(intptr_0);
			if (int_1 < 0)
			{
				int_1 = 0;
			}
			if (int_2 < 0)
			{
				int_2 = 0;
			}
			if (int_1 + int_3 > gClass.method_8())
			{
				int_3 = gClass.method_8() - int_1;
			}
			if (int_2 + int_4 > gClass.method_9())
			{
				int_4 = gClass.method_9() - int_2;
			}
			if (int_3 <= 0 || int_4 <= 0)
			{
				return null;
			}
			IntPtr intptr_ = CreateCompatibleDC_1(intptr_0);
			if (intptr_.ToInt32() == 0)
			{
				return null;
			}
			IntPtr intptr_2 = CreateCompatibleBitmap(intptr_0, int_3, int_4);
			if (intptr_2.ToInt32() == 0)
			{
				return null;
			}
			IntPtr intptr_3 = SelectObject(intptr_, intptr_2);
			BitBlt(intptr_, 0, 0, int_3, int_4, intptr_0, int_1, int_2, 13369376);
			intptr_2 = SelectObject(intptr_, intptr_3);
			DeleteDC(intptr_);
			return Image.FromHbitmap(intptr_2);
		}

		[DllImport("gdi32")]
		private static extern int BitBlt(IntPtr intptr_2, int int_1, int int_2, int int_3, int int_4, IntPtr intptr_3, int int_5, int int_6, int int_7);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool DeleteDC(IntPtr intptr_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SelectObject(IntPtr intptr_2, IntPtr intptr_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto, EntryPoint = "CreateCompatibleDC")]
		private static extern IntPtr CreateCompatibleDC_1(IntPtr intptr_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_2, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int GetPixel(IntPtr intptr_2, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int SetPixel(IntPtr intptr_2, int int_1, int int_2, int int_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int SetROP2(IntPtr intptr_2, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int GetROP2(IntPtr intptr_2);

		[DllImport("gdi32")]
		private static extern int SetBkColor(IntPtr intptr_2, int int_1);

		[DllImport("gdi32")]
		private static extern int GetBkColor(IntPtr intptr_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool DrawFocusRect(IntPtr intptr_2, ref Struct73 struct73_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool Rectangle(IntPtr intptr_2, int int_1, int int_2, int int_3, int int_4);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int InvertRect(IntPtr intptr_2, ref Struct73 struct73_0);
	}
}
