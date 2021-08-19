using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class255
	{
		private GClass618 gclass618_0;

		private int[] int_0;

		internal int[] method_0()
		{
			return int_0;
		}

		internal int method_1()
		{
			return int_0.Length - 1;
		}

		internal bool method_2()
		{
			return int_0[0] == 0;
		}

		internal Class255(GClass618 gclass618_1, int[] int_1)
		{
			if (int_1 == null || int_1.Length == 0)
			{
				throw new ArgumentException();
			}
			gclass618_0 = gclass618_1;
			int num = int_1.Length;
			if (num > 1 && int_1[0] == 0)
			{
				int i;
				for (i = 1; i < num && int_1[i] == 0; i++)
				{
				}
				if (i == num)
				{
					int_0 = gclass618_1.method_0().int_0;
					return;
				}
				int_0 = new int[num - i];
				Array.Copy(int_1, i, int_0, 0, int_0.Length);
			}
			else
			{
				int_0 = int_1;
			}
		}

		internal int method_3(int int_1)
		{
			return int_0[int_0.Length - 1 - int_1];
		}

		internal int method_4(int int_1)
		{
			if (int_1 == 0)
			{
				return method_3(0);
			}
			int num = int_0.Length;
			if (int_1 == 1)
			{
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					num2 = GClass618.smethod_0(num2, int_0[i]);
				}
				return num2;
			}
			int num3 = int_0[0];
			for (int i = 1; i < num; i++)
			{
				num3 = GClass618.smethod_0(gclass618_0.method_6(int_1, num3), int_0[i]);
			}
			return num3;
		}

		internal Class255 method_5(Class255 class255_0)
		{
			int num = 10;
			if (!gclass618_0.Equals(class255_0.gclass618_0))
			{
				throw new ArgumentException("GF256Polys do not have same GF256 field");
			}
			if (method_2())
			{
				return class255_0;
			}
			if (class255_0.method_2())
			{
				return this;
			}
			int[] array = int_0;
			int[] array2 = class255_0.int_0;
			if (array.Length > array2.Length)
			{
				int[] array3 = array;
				array = array2;
				array2 = array3;
			}
			int[] array4 = new int[array2.Length];
			int num2 = array2.Length - array.Length;
			Array.Copy(array2, 0, array4, 0, num2);
			for (int i = num2; i < array2.Length; i++)
			{
				array4[i] = GClass618.smethod_0(array[i - num2], array2[i]);
			}
			return new Class255(gclass618_0, array4);
		}

		internal Class255 method_6(Class255 class255_0)
		{
			int num = 3;
			if (!gclass618_0.Equals(class255_0.gclass618_0))
			{
				throw new ArgumentException("GF256Polys do not have same GF256 field");
			}
			if (method_2() || class255_0.method_2())
			{
				return gclass618_0.method_0();
			}
			int[] array = int_0;
			int num2 = array.Length;
			int[] array2 = class255_0.int_0;
			int num3 = array2.Length;
			int[] array3 = new int[num2 + num3 - 1];
			for (int i = 0; i < num2; i++)
			{
				int int_ = array[i];
				for (int j = 0; j < num3; j++)
				{
					array3[i + j] = GClass618.smethod_0(array3[i + j], gclass618_0.method_6(int_, array2[j]));
				}
			}
			return new Class255(gclass618_0, array3);
		}

		internal Class255 method_7(int int_1)
		{
			switch (int_1)
			{
			case 0:
				return gclass618_0.method_0();
			case 1:
				return this;
			default:
			{
				int num = int_0.Length;
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = gclass618_0.method_6(int_0[i], int_1);
				}
				return new Class255(gclass618_0, array);
			}
			}
		}

		internal Class255 method_8(int int_1, int int_2)
		{
			if (int_1 < 0)
			{
				throw new ArgumentException();
			}
			if (int_2 == 0)
			{
				return gclass618_0.method_0();
			}
			int num = int_0.Length;
			int[] array = new int[num + int_1];
			for (int i = 0; i < num; i++)
			{
				array[i] = gclass618_0.method_6(int_0[i], int_2);
			}
			return new Class255(gclass618_0, array);
		}

		internal Class255[] method_9(Class255 class255_0)
		{
			int num = 8;
			if (!gclass618_0.Equals(class255_0.gclass618_0))
			{
				throw new ArgumentException("GF256Polys do not have same GF256 field");
			}
			if (class255_0.method_2())
			{
				throw new ArgumentException("Divide by 0");
			}
			Class255 @class = gclass618_0.method_0();
			Class255 class2 = this;
			int int_ = class255_0.method_3(class255_0.method_1());
			int int_2 = gclass618_0.method_5(int_);
			while (class2.method_1() >= class255_0.method_1() && !class2.method_2())
			{
				int num2 = class2.method_1() - class255_0.method_1();
				int num3 = gclass618_0.method_6(class2.method_3(class2.method_1()), int_2);
				Class255 class255_ = class255_0.method_8(num2, num3);
				Class255 class255_2 = gclass618_0.method_2(num2, num3);
				@class = @class.method_5(class255_2);
				class2 = class2.method_5(class255_);
			}
			return new Class255[2]
			{
				@class,
				class2
			};
		}

		public override string ToString()
		{
			int num = 6;
			StringBuilder stringBuilder = new StringBuilder(8 * method_1());
			for (int num2 = method_1(); num2 >= 0; num2--)
			{
				int num3 = method_3(num2);
				if (num3 != 0)
				{
					if (num3 < 0)
					{
						stringBuilder.Append(" - ");
						num3 = -num3;
					}
					else if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" + ");
					}
					if (num2 == 0 || num3 != 1)
					{
						int num4 = gclass618_0.method_4(num3);
						switch (num4)
						{
						case 0:
							stringBuilder.Append('1');
							break;
						case 1:
							stringBuilder.Append('a');
							break;
						default:
							stringBuilder.Append("a^");
							stringBuilder.Append(num4);
							break;
						}
					}
					switch (num2)
					{
					case 1:
						stringBuilder.Append('x');
						break;
					default:
						stringBuilder.Append("x^");
						stringBuilder.Append(num2);
						break;
					case 0:
						break;
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
}
