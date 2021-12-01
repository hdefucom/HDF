using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass266 : GClass265
	{
		private struct Struct72
		{
			public int int_0;

			public int int_1;
		}

		public static readonly GClass266 gclass266_0 = new GClass266(GEnum64.const_5, 1, Color.Black);

		private GEnum64 genum64_0 = GEnum64.const_0;

		private int int_0 = 1;

		private Color color_0 = Color.Black;

		public GClass266()
		{
			genum64_0 = GEnum64.const_0;
			int_0 = 1;
			color_0 = Color.Black;
		}

		public GClass266(Color color_1)
			: this(GEnum64.const_0, 1, color_1)
		{
		}

		public GClass266(int int_1, Color color_1)
			: this(GEnum64.const_0, int_1, color_1)
		{
		}

		public GClass266(GEnum64 genum64_1, int int_1, Color color_1)
		{
			genum64_0 = genum64_1;
			int_0 = int_1;
			color_0 = color_1;
		}

		public GEnum64 method_6()
		{
			return genum64_0;
		}

		public void method_7(GEnum64 genum64_1)
		{
			if (genum64_0 != genum64_1)
			{
				genum64_0 = genum64_1;
				Dispose();
			}
		}

		public int method_8()
		{
			return int_0;
		}

		public void method_9(int int_1)
		{
			if (int_0 != int_1)
			{
				int_0 = int_1;
				Dispose();
			}
		}

		public Color method_10()
		{
			return color_0;
		}

		public void method_11(Color color_1)
		{
			if (color_0 != color_1)
			{
				color_0 = color_1;
				Dispose();
			}
		}

		protected override void vmethod_0()
		{
			if (intptr_0 == IntPtr.Zero)
			{
				intptr_0 = CreatePen((int)genum64_0, int_0, ColorTranslator.ToWin32(color_0));
			}
		}

		public void method_12(IntPtr intptr_1, int int_1, int int_2, int int_3, int int_4)
		{
			vmethod_0();
			IntPtr intptr_2 = method_2(intptr_1);
			MoveToEx(intptr_1, int_1, int_2, 0);
			LineTo(intptr_1, int_3, int_4);
			if (intptr_2.ToInt32() != 0)
			{
				method_4(intptr_1, intptr_2);
			}
		}

		public void method_13(IntPtr intptr_1, Point[] point_0)
		{
			vmethod_0();
			IntPtr intptr_2 = method_2(intptr_1);
			Struct72[] array = new Struct72[point_0.Length];
			for (int i = 0; i < point_0.Length; i++)
			{
				array[i].int_0 = point_0[i].X;
				array[i].int_1 = point_0[i].Y;
			}
			Polyline(intptr_1, array, array.Length);
			if (intptr_2.ToInt32() != 0)
			{
				method_4(intptr_1, intptr_2);
			}
		}

		public void method_14(IntPtr intptr_1, Point point_0, Point point_1)
		{
			vmethod_0();
			method_12(intptr_1, point_0.X, point_0.Y, point_1.X, point_1.Y);
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreatePen(int int_1, int int_2, int int_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool LineTo(IntPtr intptr_1, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool Polyline(IntPtr intptr_1, Struct72[] struct72_0, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool MoveToEx(IntPtr intptr_1, int int_1, int int_2, int int_3);
	}
}
