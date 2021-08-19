using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass142
	{
		private Stream stream_0;

		private static Dictionary<Type, int> dictionary_0 = new Dictionary<Type, int>();

		public GClass142(Stream stream_1)
		{
			int num = 7;
			stream_0 = null;
			
			if (stream_1 == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream_0 = stream_1;
		}

		public bool method_0()
		{
			int num = 18;
			int num2 = stream_0.ReadByte();
			if (num2 == -1)
			{
				throw new InvalidOperationException("EOF");
			}
			return num2 != 0;
		}

		public string method_1()
		{
			int num = 8;
			int num2 = stream_0.ReadByte();
			if (num2 == 0)
			{
				return null;
			}
			byte[] array = new byte[num2];
			if (stream_0.Read(array, 0, array.Length) < num2)
			{
				throw new InvalidOperationException("EOF");
			}
			return Encoding.UTF8.GetString(array);
		}

		public string method_2()
		{
			int num = 10;
			byte[] array = new byte[2];
			if (stream_0.Read(array, 0, array.Length) < 2)
			{
				throw new InvalidOperationException("EOF");
			}
			int num2 = BitConverter.ToInt16(array, 0);
			array = new byte[num2];
			if (stream_0.Read(array, 0, array.Length) < num2)
			{
				throw new InvalidOperationException("EOF");
			}
			return Encoding.UTF8.GetString(array);
		}

		public byte method_3()
		{
			int num = 16;
			int num2 = stream_0.ReadByte();
			if (num2 == -1)
			{
				throw new InvalidOperationException("EOF");
			}
			return (byte)num2;
		}

		public short method_4()
		{
			int num = 11;
			byte[] array = new byte[2];
			if (stream_0.Read(array, 0, array.Length) != 2)
			{
				throw new InvalidOperationException("EOF");
			}
			return BitConverter.ToInt16(array, 0);
		}

		public int method_5()
		{
			int num = 9;
			byte[] array = new byte[4];
			if (stream_0.Read(array, 0, array.Length) != 4)
			{
				throw new InvalidOperationException("EOF");
			}
			return BitConverter.ToInt32(array, 0);
		}

		public long method_6()
		{
			int num = 17;
			byte[] array = new byte[8];
			if (stream_0.Read(array, 0, array.Length) != 8)
			{
				throw new InvalidOperationException("EOF");
			}
			return BitConverter.ToInt64(array, 0);
		}

		public float method_7()
		{
			int num = 11;
			byte[] array = new byte[4];
			if (stream_0.Read(array, 0, array.Length) != 4)
			{
				throw new InvalidOperationException("EOF");
			}
			return BitConverter.ToSingle(array, 0);
		}

		public double method_8()
		{
			int num = 0;
			byte[] array = new byte[8];
			if (stream_0.Read(array, 0, array.Length) != 8)
			{
				throw new InvalidOperationException("EOF");
			}
			return BitConverter.ToDouble(array, 0);
		}

		public DateTime method_9()
		{
			int num = 14;
			byte[] array = new byte[8];
			if (stream_0.Read(array, 0, array.Length) != 8)
			{
				throw new InvalidOperationException("EOF");
			}
			long ticks = BitConverter.ToInt64(array, 0);
			return new DateTime(ticks);
		}

		public void method_10(byte[] byte_0, int int_0, int int_1)
		{
			int num = 6;
			if (stream_0.Read(byte_0, int_0, int_1) < int_1)
			{
				throw new InvalidOperationException("EOF");
			}
		}

		public object method_11(Type type_0)
		{
			int num = 5;
			int num2 = smethod_0(type_0);
			byte[] array = new byte[num2];
			if (stream_0.Read(array, 0, array.Length) < num2)
			{
				throw new InvalidOperationException("EOF");
			}
			long value = smethod_1(array);
			return Enum.ToObject(type_0, value);
		}

		public static int smethod_0(Type type_0)
		{
			int num = 5;
			if (type_0 == null)
			{
				throw new ArgumentNullException("enumType");
			}
			if (!type_0.IsEnum)
			{
				throw new ArgumentException(type_0.FullName);
			}
			if (dictionary_0.ContainsKey(type_0))
			{
				return dictionary_0[type_0];
			}
			Array values = Enum.GetValues(type_0);
			long num2 = long.MinValue;
			long num3 = long.MaxValue;
			if (Attribute.GetCustomAttribute(type_0, typeof(FlagsAttribute), inherit: true) == null)
			{
				foreach (object item in values)
				{
					long val = Convert.ToInt64(item);
					num2 = Math.Max(num2, val);
					num3 = Math.Min(num3, val);
				}
			}
			else
			{
				num2 = 0L;
				num3 = 0L;
				foreach (object item2 in values)
				{
					long val = Convert.ToInt64(item2);
					if (val > 0L)
					{
						num2 += val;
					}
					else
					{
						num3 += val;
					}
				}
			}
			int num4 = 1;
			num4 = ((num2 < 126L && num3 > -127L) ? 1 : ((num2 < 32766L && num3 > 32768L) ? 2 : ((num2 >= 2147483646L || num3 <= -2147483647L) ? 8 : 4)));
			dictionary_0[type_0] = num4;
			return num4;
		}

		public static long smethod_1(byte[] byte_0)
		{
			long num = 0L;
			for (int i = 0; i < byte_0.Length; i++)
			{
				num = (num << 8) + byte_0[i];
			}
			return num;
		}

		public byte[] method_12(int int_0)
		{
			int num = 1;
			if (int_0 <= 0)
			{
				throw new ArgumentOutOfRangeException(int_0.ToString());
			}
			byte[] array = new byte[int_0];
			if (stream_0.Read(array, 0, array.Length) < int_0)
			{
				throw new InvalidOperationException("EOF");
			}
			return array;
		}

		public byte[] method_13(int int_0)
		{
			int num = 10;
			int num2;
			byte[] array;
			if (int_0 <= 254)
			{
				num2 = stream_0.ReadByte();
				if (num2 == -1)
				{
					throw new InvalidOperationException("EOF");
				}
				array = new byte[num2];
				if (stream_0.Read(array, 0, array.Length) < num2)
				{
					throw new InvalidOperationException("EOF");
				}
				return array;
			}
			if (int_0 <= 32766)
			{
				num2 = method_4();
				array = new byte[num2];
				if (stream_0.Read(array, 0, array.Length) < num2)
				{
					throw new InvalidOperationException("EOF");
				}
				return array;
			}
			num2 = method_5();
			array = new byte[num2];
			if (stream_0.Read(array, 0, array.Length) < num2)
			{
				throw new InvalidOperationException("EOF");
			}
			return array;
		}
	}
}
