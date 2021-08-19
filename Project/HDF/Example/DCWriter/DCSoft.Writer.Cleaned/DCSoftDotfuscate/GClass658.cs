using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass658
	{
		private sbyte[][] sbyte_0;

		private int int_0;

		private int int_1;

		public int method_0()
		{
			return int_1;
		}

		public int method_1()
		{
			return int_0;
		}

		public sbyte[][] method_2()
		{
			return sbyte_0;
		}

		public GClass658(int int_2, int int_3)
		{
			sbyte_0 = new sbyte[int_3][];
			for (int i = 0; i < int_3; i++)
			{
				sbyte_0[i] = new sbyte[int_2];
			}
			int_0 = int_2;
			int_1 = int_3;
		}

		public sbyte method_3(int int_2, int int_3)
		{
			return sbyte_0[int_3][int_2];
		}

		public void method_4(int int_2, int int_3, sbyte sbyte_1)
		{
			sbyte_0[int_3][int_2] = sbyte_1;
		}

		public void method_5(int int_2, int int_3, int int_4)
		{
			sbyte_0[int_3][int_2] = (sbyte)int_4;
		}

		public void method_6(sbyte sbyte_1)
		{
			for (int i = 0; i < int_1; i++)
			{
				for (int j = 0; j < int_0; j++)
				{
					sbyte_0[i][j] = sbyte_1;
				}
			}
		}

		public override string ToString()
		{
			int num = 4;
			StringBuilder stringBuilder = new StringBuilder(2 * int_0 * int_1 + 2);
			for (int i = 0; i < int_1; i++)
			{
				for (int j = 0; j < int_0; j++)
				{
					switch (sbyte_0[i][j])
					{
					default:
						stringBuilder.Append("  ");
						break;
					case 0:
						stringBuilder.Append(" 0");
						break;
					case 1:
						stringBuilder.Append(" 1");
						break;
					}
				}
				stringBuilder.Append('\n');
			}
			return stringBuilder.ToString();
		}

		public Bitmap method_7()
		{
			sbyte[][] array = method_2();
			int num = method_1();
			int num2 = method_0();
			Bitmap bitmap = new Bitmap(num, num2, PixelFormat.Format8bppIndexed);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
			byte[] array2 = new byte[bitmapData.Stride * num2];
			int num3 = 0;
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					array2[num3++] = (byte)((array[i][j] != 0) ? byte.MaxValue : 0);
				}
				num3 += bitmapData.Stride - num;
			}
			Marshal.Copy(array2, 0, bitmapData.Scan0, array2.Length);
			bitmap.UnlockBits(bitmapData);
			return bitmap;
		}
	}
}
