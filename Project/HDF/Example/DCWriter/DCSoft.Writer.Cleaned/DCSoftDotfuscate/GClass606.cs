using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass606 : GClass605
	{
		private sbyte[] sbyte_0;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private Rectangle rectangle_0;

		private int int_2;

		private int int_3;

		public override int vmethod_2()
		{
			if (!bool_0)
			{
				return int_2;
			}
			return int_3;
		}

		public override int vmethod_1()
		{
			if (!bool_0)
			{
				return int_3;
			}
			return int_2;
		}

		public GClass606(byte[] byte_0, int int_4, int int_5)
			: base(int_4, int_5)
		{
			int_3 = int_4;
			int_2 = int_5;
			sbyte_0 = new sbyte[int_4 * int_5];
			for (int i = 0; i < int_5; i++)
			{
				int num = i * int_4;
				for (int j = 0; j < int_4; j++)
				{
					int num2 = byte_0[num * 3 + j * 3];
					int num3 = byte_0[num * 3 + j * 3 + 1];
					int num4 = byte_0[num * 3 + j * 3 + 2];
					if (num2 == num3 && num3 == num4)
					{
						sbyte_0[num + j] = (sbyte)num2;
					}
					else
					{
						sbyte_0[num + j] = (sbyte)(num2 + num3 + num3 + num4 >> 2);
					}
				}
			}
		}

		public GClass606(byte[] byte_0, int int_4, int int_5, bool bool_2)
			: base(int_4, int_5)
		{
			int_3 = int_4;
			int_2 = int_5;
			sbyte_0 = new sbyte[int_4 * int_5];
			Buffer.BlockCopy(byte_0, 0, sbyte_0, 0, int_4 * int_5);
		}

		public GClass606(byte[] byte_0, int int_4, int int_5, bool bool_2, Rectangle rectangle_1)
			: base(int_4, int_5)
		{
			int_3 = rectangle_1.Width;
			int_2 = rectangle_1.Height;
			rectangle_0 = rectangle_1;
			bool_1 = true;
		}

		public GClass606(Bitmap bitmap_0, int int_4, int int_5)
			: base(int_4, int_5)
		{
			int num = int_3 = int_4;
			int num2 = int_2 = int_5;
			sbyte_0 = new sbyte[num * num2];
			for (int i = 0; i < num2; i++)
			{
				int num3 = i * num;
				for (int j = 0; j < num; j++)
				{
					Color pixel = bitmap_0.GetPixel(j, i);
					sbyte_0[num3 + j] = (sbyte)((pixel.R << 16) | (pixel.G << 8) | pixel.B);
				}
			}
		}

		public override sbyte[] vmethod_5(int int_4, sbyte[] sbyte_1)
		{
			int num;
			if (!bool_0)
			{
				num = vmethod_1();
				if (sbyte_1 == null || sbyte_1.Length < num)
				{
					sbyte_1 = new sbyte[num];
				}
				for (int i = 0; i < num; i++)
				{
					sbyte_1[i] = sbyte_0[int_4 * num + i];
				}
				return sbyte_1;
			}
			num = int_3;
			int num2 = int_2;
			if (sbyte_1 == null || sbyte_1.Length < num2)
			{
				sbyte_1 = new sbyte[num2];
			}
			for (int i = 0; i < num2; i++)
			{
				sbyte_1[i] = sbyte_0[i * num + int_4];
			}
			return sbyte_1;
		}

		public override sbyte[] vmethod_0()
		{
			return sbyte_0;
		}

		public override GClass605 vmethod_6(int int_4, int int_5, int int_6, int int_7)
		{
			return base.vmethod_6(int_4, int_5, int_6, int_7);
		}

		public override GClass605 vmethod_7()
		{
			bool_0 = true;
			return this;
		}

		public override bool vmethod_4()
		{
			return true;
		}
	}
}
