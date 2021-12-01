using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass498
	{
		protected const string string_0 = "error when working with .ttf file";

		public const int int_0 = 1;

		public const int int_1 = 1;

		public const int int_2 = 2;

		public const int int_3 = 2;

		public const int int_4 = 4;

		public const int int_5 = 4;

		public const int int_6 = 4;

		public const int int_7 = 2;

		public const int int_8 = 2;

		public const int int_9 = 2;

		public const int int_10 = 8;

		public const int int_11 = 10;

		protected abstract byte vmethod_0();

		protected abstract void vmethod_1(byte byte_0);

		protected abstract void vmethod_2(int int_12);

		public byte method_0()
		{
			int num = 19;
			if (vmethod_3() < 0 || vmethod_3() >= vmethod_4())
			{
				throw new GException16("error when working with .ttf file");
			}
			return vmethod_0();
		}

		public sbyte method_1()
		{
			return Convert.ToSByte(method_0());
		}

		public ushort method_2()
		{
			int num = 6;
			if (vmethod_3() < 0 || vmethod_3() >= vmethod_4() - 1)
			{
				throw new GException16("error when working with .ttf file");
			}
			if (BitConverter.IsLittleEndian)
			{
				return (ushort)((vmethod_0() << 8) + vmethod_0());
			}
			return (ushort)(vmethod_0() + (vmethod_0() << 8));
		}

		public short method_3()
		{
			int num = 0;
			if (vmethod_3() < 0 || vmethod_3() >= vmethod_4() - 1)
			{
				throw new GException16("error when working with .ttf file");
			}
			if (BitConverter.IsLittleEndian)
			{
				return (short)((vmethod_0() << 8) + vmethod_0());
			}
			return (short)(vmethod_0() + (vmethod_0() << 8));
		}

		public uint method_4()
		{
			int num = 19;
			if (vmethod_3() < 0 || vmethod_3() >= vmethod_4() - 3)
			{
				throw new GException16("error when working with .ttf file");
			}
			if (BitConverter.IsLittleEndian)
			{
				return (uint)((vmethod_0() << 24) + (vmethod_0() << 16) + (vmethod_0() << 8) + vmethod_0());
			}
			return (uint)(vmethod_0() + (vmethod_0() << 8) + (vmethod_0() << 16) + (vmethod_0() << 24));
		}

		public int method_5()
		{
			byte[] value = method_11(4);
			return BitConverter.ToInt32(value, 0);
		}

		public int method_6()
		{
			int num = 9;
			if (vmethod_3() < 0 || vmethod_3() >= vmethod_4() - 3)
			{
				throw new GException16("error when working with .ttf file");
			}
			if (BitConverter.IsLittleEndian)
			{
				return (vmethod_0() << 24) + (vmethod_0() << 16) + (vmethod_0() << 8) + vmethod_0();
			}
			return vmethod_0() + (vmethod_0() << 8) + (vmethod_0() << 16) + (vmethod_0() << 24);
		}

		public ushort method_7()
		{
			return method_2();
		}

		public short method_8()
		{
			return method_3();
		}

		public GStruct23 method_9()
		{
			int num = 3;
			if (vmethod_3() < 0 || vmethod_3() >= vmethod_4() - 9)
			{
				throw new GException16("error when working with .ttf file");
			}
			GStruct23 result = default(GStruct23);
			result.byte_0 = vmethod_0();
			result.byte_1 = vmethod_0();
			result.byte_2 = vmethod_0();
			result.byte_3 = vmethod_0();
			result.byte_4 = vmethod_0();
			result.byte_5 = vmethod_0();
			result.byte_6 = vmethod_0();
			result.byte_7 = vmethod_0();
			result.byte_8 = vmethod_0();
			result.byte_9 = vmethod_0();
			return result;
		}

		public byte[] method_10()
		{
			int num = 13;
			if (vmethod_3() < 0 || vmethod_3() >= vmethod_4() - 1)
			{
				throw new GException16("error when working with .ttf file");
			}
			return new byte[2]
			{
				vmethod_0(),
				vmethod_0()
			};
		}

		public byte[] method_11(int int_12)
		{
			int num = 6;
			if (vmethod_3() < 0 || vmethod_3() >= vmethod_4() - int_12 + 1)
			{
				throw new GException16("error when working with .ttf file");
			}
			byte[] array = new byte[int_12];
			for (int i = 0; i < int_12; i++)
			{
				array[i] = vmethod_0();
			}
			return array;
		}

		public string method_12(int int_12)
		{
			string text = "";
			for (int i = 0; i < int_12; i += 2)
			{
				text += (char)method_2();
			}
			return text;
		}

		public void method_13(byte[] byte_0)
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				vmethod_1(byte_0[i]);
			}
		}

		public void method_14(byte[] byte_0, bool bool_0)
		{
			if (bool_0)
			{
				for (int num = byte_0.Length - 1; num >= 0; num--)
				{
					vmethod_1(byte_0[num]);
				}
			}
			else
			{
				method_13(byte_0);
			}
		}

		public void method_15(byte byte_0)
		{
			vmethod_1(byte_0);
		}

		public void method_16(sbyte sbyte_0)
		{
			vmethod_1((byte)sbyte_0);
		}

		public void method_17(ushort ushort_0)
		{
			byte[] bytes = BitConverter.GetBytes(ushort_0);
			method_14(bytes, BitConverter.IsLittleEndian);
		}

		public void method_18(short short_0)
		{
			byte[] bytes = BitConverter.GetBytes(short_0);
			method_14(bytes, BitConverter.IsLittleEndian);
		}

		public void method_19(uint uint_0)
		{
			byte[] bytes = BitConverter.GetBytes(uint_0);
			method_14(bytes, BitConverter.IsLittleEndian);
		}

		public void method_20(int int_12)
		{
			byte[] bytes = BitConverter.GetBytes(int_12);
			method_14(bytes, BitConverter.IsLittleEndian);
		}

		public void method_21(ushort ushort_0)
		{
			method_17(ushort_0);
		}

		public void method_22(short short_0)
		{
			method_18(short_0);
		}

		public void method_23(GStruct23 gstruct23_0)
		{
			vmethod_1(gstruct23_0.byte_0);
			vmethod_1(gstruct23_0.byte_1);
			vmethod_1(gstruct23_0.byte_2);
			vmethod_1(gstruct23_0.byte_3);
			vmethod_1(gstruct23_0.byte_4);
			vmethod_1(gstruct23_0.byte_5);
			vmethod_1(gstruct23_0.byte_6);
			vmethod_1(gstruct23_0.byte_7);
			vmethod_1(gstruct23_0.byte_8);
			vmethod_1(gstruct23_0.byte_9);
		}

		public void method_24(string string_1)
		{
			for (int i = 0; i < string_1.Length; i++)
			{
				method_17(string_1[i]);
			}
		}

		public void method_25()
		{
			int num = vmethod_3() % 4;
			for (int num2 = 4; num2 > num; num2--)
			{
				vmethod_1(0);
			}
		}

		public void method_26(int int_12)
		{
			method_27(vmethod_3() + int_12);
		}

		public void method_27(int int_12)
		{
			int num = 18;
			if (int_12 < 0 || int_12 > vmethod_4())
			{
				throw new GException16("error when working with .ttf file");
			}
			vmethod_2(int_12);
		}

		public static float smethod_0(byte[] byte_0)
		{
			if (byte_0.Length != 4)
			{
				return 0f;
			}
			byte[] array = new byte[4];
			if (BitConverter.IsLittleEndian)
			{
				for (int i = 0; i < 4; i++)
				{
					array[i] = byte_0[4 - i - 1];
				}
			}
			else
			{
				for (int i = 0; i < 4; i++)
				{
					array[i] = byte_0[i];
				}
			}
			short num = BitConverter.ToInt16(array, 2);
			ushort num2 = BitConverter.ToUInt16(array, 0);
			if (num2 != 0)
			{
				double num3 = Math.Pow(10.0, Math.Ceiling(Math.Log10((int)num2)));
				return Convert.ToSingle((double)num + (double)(int)num2 / num3 * (double)Math.Sign(num));
			}
			return Convert.ToSingle(num);
		}

		public abstract int vmethod_3();

		public abstract int vmethod_4();
	}
}
