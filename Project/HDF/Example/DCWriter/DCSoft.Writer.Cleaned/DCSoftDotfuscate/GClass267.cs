using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass267 : GClass265
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[ComVisible(false)]
		private class Class182
		{
			public int int_0 = 0;

			public int int_1 = 0;

			public int int_2 = 0;

			public int int_3 = 0;

			public int int_4 = 0;

			public byte byte_0 = 0;

			public byte byte_1 = 0;

			public byte byte_2 = 0;

			public GEnum71 genum71_0 = GEnum71.const_0;

			public byte byte_3 = 0;

			public byte byte_4 = 0;

			public byte byte_5 = 0;

			public byte byte_6 = 0;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string string_0 = null;
		}

		[ComVisible(false)]
		public enum GEnum71 : byte
		{
			const_0 = 0,
			const_1 = 1,
			const_2 = 2,
			const_3 = 0x80,
			const_4 = 129,
			const_5 = 129,
			const_6 = 134,
			const_7 = 136,
			const_8 = byte.MaxValue,
			const_9 = 130,
			const_10 = 177,
			const_11 = 178,
			const_12 = 161,
			const_13 = 162,
			const_14 = 163,
			const_15 = 222,
			const_16 = 238,
			const_17 = 204,
			const_18 = 77,
			const_19 = 186
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[ComVisible(false)]
		private struct Struct75
		{
			public int int_0;

			public int int_1;
		}

		[ComVisible(false)]
		private struct Struct76
		{
			public IntPtr intptr_0;

			public IntPtr intptr_1;

			public IntPtr intptr_2;

			public IntPtr intptr_3;

			public IntPtr intptr_4;

			public IntPtr intptr_5;

			public int int_0;

			public int int_1;

			public int int_2;
		}

		private class Class183
		{
			public const int int_0 = 524288;

			public const int int_1 = 1;

			public const int int_2 = 256;

			public const int int_3 = 4194304;

			public const int int_4 = 32768;

			public const int int_5 = 16;

			public const int int_6 = 65536;

			public const int int_7 = 2097152;

			public const int int_8 = 1024;

			public const int int_9 = 32;

			public const int int_10 = 1048576;

			public const int int_11 = 33554432;

			public const int int_12 = 16777216;

			public const int int_13 = 67108864;

			public const int int_14 = 134217728;

			public const int int_15 = 2;

			public const int int_16 = 8388608;

			public const int int_17 = 8;
		}

		private Class182 class182_0 = new Class182();

		public string Name => class182_0.string_0;

		public GClass267(string string_0, int int_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
		{
			class182_0 = new Class182();
			class182_0.int_0 = int_0;
			class182_0.string_0 = string_0;
			class182_0 = new Class182();
			class182_0.int_0 = int_0;
			class182_0.string_0 = string_0;
			class182_0.int_4 = (bool_1 ? 700 : 400);
			class182_0.byte_0 = (byte)(bool_2 ? 1 : 0);
			class182_0.byte_1 = (byte)(bool_3 ? 1 : 0);
			class182_0.byte_2 = (byte)(bool_4 ? 1 : 0);
			intptr_0 = CreateFont(class182_0.int_0, class182_0.int_1, class182_0.int_2, class182_0.int_3, class182_0.int_4, class182_0.byte_0, class182_0.byte_1, class182_0.byte_2, 1, class182_0.byte_3, class182_0.byte_4, class182_0.byte_5, class182_0.byte_6, class182_0.string_0);
		}

		public GClass267(Font font_0)
		{
			float size = font_0.Size;
			class182_0 = new Class182();
			font_0.ToLogFont(class182_0);
			class182_0.int_0 = (int)(0.0 - Math.Round(size / 1f));
			intptr_0 = CreateFont(class182_0.int_0, class182_0.int_1, class182_0.int_2, class182_0.int_3, class182_0.int_4, class182_0.byte_0, class182_0.byte_1, class182_0.byte_2, 1, class182_0.byte_3, class182_0.byte_4, class182_0.byte_5, class182_0.byte_6, class182_0.string_0);
		}

		public int method_6()
		{
			return class182_0.int_0;
		}

		public int method_7()
		{
			return class182_0.int_1;
		}

		public int method_8()
		{
			return class182_0.int_2;
		}

		public int method_9()
		{
			return class182_0.int_4;
		}

		public bool method_10()
		{
			return class182_0.byte_0 != 0;
		}

		public bool method_11()
		{
			return class182_0.byte_1 != 0;
		}

		public bool method_12()
		{
			return class182_0.byte_2 != 0;
		}

		public GEnum71 method_13()
		{
			return class182_0.genum71_0;
		}

		public byte method_14()
		{
			return class182_0.byte_3;
		}

		public byte method_15()
		{
			return class182_0.byte_4;
		}

		public byte method_16()
		{
			return class182_0.byte_5;
		}

		public byte method_17()
		{
			return class182_0.byte_6;
		}

		public Rectangle[] method_18(Graphics graphics_0, string string_0, StringFormat stringFormat_0)
		{
			return method_19(graphics_0, string_0, RectangleF.Empty, graphics_0.PageUnit);
		}

		public Rectangle[] method_19(Graphics graphics_0, string string_0, RectangleF rectangleF_0, GraphicsUnit graphicsUnit_0)
		{
			Rectangle empty = Rectangle.Empty;
			empty = ((!rectangleF_0.IsEmpty) ? Rectangle.Round(rectangleF_0) : new Rectangle(0, 0, 1000, 1000));
			IntPtr hdc = graphics_0.GetHdc();
			try
			{
				IntPtr intptr_ = SelectObject(hdc, method_0());
				Struct76 struct76_ = default(Struct76);
				struct76_.int_0 = Marshal.SizeOf(typeof(Struct76));
				struct76_.intptr_5 = IntPtr.Zero;
				struct76_.intptr_4 = IntPtr.Zero;
				struct76_.intptr_2 = IntPtr.Zero;
				struct76_.intptr_0 = Marshal.AllocCoTaskMem(4 * string_0.Length);
				struct76_.intptr_1 = IntPtr.Zero;
				struct76_.intptr_3 = IntPtr.Zero;
				struct76_.int_1 = string_0.Length;
				GetCharacterPlacement(hdc, string_0, string_0.Length, 0, ref struct76_, 40);
				int length = string_0.Length;
				Rectangle[] array = new Rectangle[length];
				int num = Marshal.ReadInt32(struct76_.intptr_0, 0);
				for (int i = 0; i < length - 1; i++)
				{
					int num2 = Marshal.ReadInt32(struct76_.intptr_0, (i + 1) * 4);
					array[i] = new Rectangle(empty.X + num, empty.Y, num2 - num, empty.Height);
					num = num2;
				}
				if (length > 0)
				{
					array[length - 1] = new Rectangle(empty.X + num, empty.Y, empty.Width - num, empty.Height);
				}
				Marshal.FreeCoTaskMem(struct76_.intptr_0);
				SelectObject(hdc, intptr_);
				return array;
			}
			finally
			{
				graphics_0.ReleaseHdc(hdc);
			}
		}

		public Size[] method_20(Graphics graphics_0, string string_0)
		{
			double num = 1.0;
			IntPtr hdc = graphics_0.GetHdc();
			try
			{
				SelectObject(hdc, method_0());
				Struct75 struct75_ = default(Struct75);
				Size[] array = new Size[string_0.Length];
				for (int i = 0; i < string_0.Length; i++)
				{
					char c = string_0[i];
					int byteCount = Encoding.Default.GetByteCount(c.ToString());
					if (GetTextExtentPoint32(hdc, c.ToString(), byteCount, ref struct75_))
					{
						array[i].Width = (int)((double)struct75_.int_0 * num);
						array[i].Height = (int)((double)struct75_.int_1 * num);
					}
				}
				return array;
			}
			finally
			{
				graphics_0.ReleaseHdc(hdc);
			}
		}

		[DllImport("gdi32.dll")]
		private static extern bool GetTextExtentPoint32(IntPtr intptr_1, string string_0, int int_0, ref Struct75 struct75_0);

		[DllImport("gdi32.dll")]
		private static extern IntPtr CreateFont(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, int int_12, string string_0);

		[DllImport("gdi32.dll")]
		private static extern int GetCharacterPlacement(IntPtr intptr_1, string string_0, int int_0, int int_1, ref Struct76 struct76_0, int int_2);

		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr intptr_1, IntPtr intptr_2);
	}
}
