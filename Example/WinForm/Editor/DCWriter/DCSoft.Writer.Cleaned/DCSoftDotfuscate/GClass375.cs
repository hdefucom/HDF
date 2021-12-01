using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass375
	{
		protected bool bool_0 = false;

		protected Stream stream_0 = null;

		protected Encoding encoding_0 = Encoding.UTF8;

		public GClass375()
		{
		}

		public GClass375(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		public GClass375(Stream stream_1, Encoding encoding_1)
		{
			stream_0 = stream_1;
			encoding_0 = encoding_1;
		}

		public GClass375(byte[] byte_0)
		{
			stream_0 = new MemoryStream(byte_0);
		}

		public bool method_0()
		{
			return bool_0;
		}

		public Stream method_1()
		{
			return stream_0;
		}

		public void method_2(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		public Encoding method_3()
		{
			return encoding_0;
		}

		public void method_4(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		protected virtual byte vmethod_0(byte byte_0)
		{
			return byte_0;
		}

		protected virtual byte[] vmethod_1(byte[] byte_0)
		{
			return byte_0;
		}

		public bool method_5(byte[] byte_0)
		{
			byte[] array = method_6(byte_0.Length);
			if (array == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < byte_0.Length)
				{
					if (byte_0[num] != array[num])
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		public byte[] method_6(int int_0)
		{
			int num = 1;
			if (int_0 == 0)
			{
				return null;
			}
			if (int_0 < 0)
			{
				throw new ArgumentException("参数 Size 必须大于 0 ");
			}
			if (bool_0)
			{
				return null;
			}
			bool_0 = true;
			byte[] array = new byte[int_0];
			int num2 = stream_0.Read(array, 0, array.Length);
			if (num2 == array.Length)
			{
				bool_0 = false;
				return vmethod_1(array);
			}
			return null;
		}

		public byte[] method_7(int int_0)
		{
			int num = 4;
			if (int_0 == 0)
			{
				return null;
			}
			if (int_0 < 0)
			{
				throw new ArgumentException("参数 MaxLen 必须大于 0 ");
			}
			if (bool_0)
			{
				return null;
			}
			bool_0 = true;
			byte[] array = new byte[int_0];
			int num2 = stream_0.Read(array, 0, array.Length);
			if (num2 == int_0)
			{
				bool_0 = false;
				return vmethod_1(array);
			}
			if (num2 <= 0)
			{
				return null;
			}
			byte[] array2 = new byte[num2];
			Array.Copy(array, 0, array2, 0, num2);
			bool_0 = false;
			return vmethod_1(array2);
		}

		public byte[] method_8()
		{
			if (bool_0)
			{
				return null;
			}
			int num = stream_0.ReadByte();
			switch (num)
			{
			case -1:
				bool_0 = true;
				return null;
			case 0:
				return null;
			default:
				num = vmethod_0((byte)num);
				return method_7(num);
			}
		}

		public byte[] method_9()
		{
			byte[] array = method_6(4);
			if (array == null)
			{
				return null;
			}
			int num = BitConverter.ToInt32(array, 0);
			if (num == int.MinValue)
			{
				return null;
			}
			return method_7(num);
		}

		public string method_10()
		{
			byte[] array = method_8();
			if (array == null || array.Length == 0)
			{
				return null;
			}
			return encoding_0.GetString(array);
		}

		public string method_11()
		{
			byte[] array = method_9();
			if (array == null)
			{
				return null;
			}
			return encoding_0.GetString(array);
		}

		public byte method_12()
		{
			int num = stream_0.ReadByte();
			if (num == -1)
			{
				bool_0 = true;
				return 0;
			}
			num = vmethod_0((byte)num);
			bool_0 = false;
			return (byte)num;
		}

		public short method_13()
		{
			byte[] array = method_6(2);
			if (array == null)
			{
				return short.MinValue;
			}
			return BitConverter.ToInt16(array, 0);
		}

		public int method_14()
		{
			byte[] array = method_6(4);
			if (array == null)
			{
				return int.MinValue;
			}
			return BitConverter.ToInt32(array, 0);
		}

		public int[] method_15(int int_0)
		{
			byte[] array = method_6(int_0 * 4);
			if (array == null)
			{
				return null;
			}
			int[] array2 = new int[int_0];
			for (int i = 0; i < int_0; i++)
			{
				array2[i] = BitConverter.ToInt32(array, i * 4);
			}
			return array2;
		}

		public long method_16()
		{
			byte[] array = method_6(8);
			if (array == null)
			{
				return long.MinValue;
			}
			return BitConverter.ToInt64(array, 0);
		}

		public ushort method_17()
		{
			byte[] array = method_6(2);
			if (array == null)
			{
				return 0;
			}
			return BitConverter.ToUInt16(array, 0);
		}

		public uint method_18()
		{
			byte[] array = method_6(4);
			if (array == null)
			{
				return 0u;
			}
			return BitConverter.ToUInt32(array, 0);
		}

		public ulong method_19()
		{
			byte[] array = method_6(8);
			if (array == null)
			{
				return 0uL;
			}
			return BitConverter.ToUInt64(array, 0);
		}

		public float method_20()
		{
			byte[] array = method_6(4);
			if (array == null)
			{
				return float.NaN;
			}
			return BitConverter.ToSingle(array, 0);
		}

		public double method_21()
		{
			byte[] array = method_6(8);
			if (array == null)
			{
				return double.NaN;
			}
			return BitConverter.ToDouble(array, 0);
		}

		public bool method_22()
		{
			byte[] array = method_6(1);
			if (array == null)
			{
				return false;
			}
			return BitConverter.ToBoolean(array, 0);
		}

		public char method_23()
		{
			byte[] array = method_6(2);
			if (array == null)
			{
				return '\0';
			}
			return BitConverter.ToChar(array, 0);
		}

		public decimal method_24()
		{
			int[] array = method_15(4);
			if (array == null)
			{
				return decimal.MinValue;
			}
			return new decimal(array);
		}

		public DateTime method_25()
		{
			byte[] array = method_6(8);
			if (array == null)
			{
				return DateTime.MinValue;
			}
			return new DateTime(BitConverter.ToInt64(array, 0));
		}

		public Guid method_26()
		{
			byte[] array = method_6(16);
			if (array == null)
			{
				return Guid.Empty;
			}
			return new Guid(array);
		}
	}
}
