using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DebuggerNonUserCode]
	internal class Class141
	{
		private Encoding encoding_0;

		private bool bool_0;

		private Stream stream_0;

		public Class141(Stream stream_1)
		{
			int num = 16;
			encoding_0 = Encoding.UTF8;
			bool_0 = false;
			stream_0 = null;
			
			if (stream_1 == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream_0 = stream_1;
		}

		public Encoding method_0()
		{
			return encoding_0;
		}

		public void method_1(Encoding encoding_1)
		{
			encoding_0 = encoding_1;
		}

		public bool method_2()
		{
			return bool_0;
		}

		public Stream method_3()
		{
			return stream_0;
		}

		public int method_4()
		{
			int num = stream_0.ReadByte();
			if (num == -1)
			{
				bool_0 = true;
			}
			return num;
		}

		public bool method_5()
		{
			int num = stream_0.ReadByte();
			if (num == -1)
			{
				bool_0 = true;
				return false;
			}
			return num != 0;
		}

		public short method_6()
		{
			byte[] array = new byte[2];
			int num = stream_0.Read(array, 0, array.Length);
			if (num == array.Length)
			{
				return BitConverter.ToInt16(array, 0);
			}
			bool_0 = true;
			return 0;
		}

		public int method_7()
		{
			byte[] array = new byte[4];
			int num = stream_0.Read(array, 0, array.Length);
			if (num == array.Length)
			{
				return BitConverter.ToInt32(array, 0);
			}
			bool_0 = true;
			return 0;
		}

		public long method_8()
		{
			byte[] array = new byte[8];
			int num = stream_0.Read(array, 0, array.Length);
			if (num == array.Length)
			{
				return BitConverter.ToInt64(array, 0);
			}
			bool_0 = true;
			return 0L;
		}

		public float method_9()
		{
			byte[] array = new byte[4];
			int num = stream_0.Read(array, 0, array.Length);
			if (num == array.Length)
			{
				return BitConverter.ToSingle(array, 0);
			}
			bool_0 = true;
			return 0f;
		}

		public double method_10()
		{
			byte[] array = new byte[8];
			int num = stream_0.Read(array, 0, array.Length);
			if (num == array.Length)
			{
				return BitConverter.ToDouble(array, 0);
			}
			bool_0 = true;
			return 0.0;
		}

		public string method_11()
		{
			byte[] array = new byte[4];
			int num = stream_0.Read(array, 0, array.Length);
			if (num == array.Length)
			{
				num = BitConverter.ToInt32(array, 0);
				array = new byte[num];
				num = stream_0.Read(array, 0, num);
				if (num == array.Length)
				{
					return encoding_0.GetString(array);
				}
				bool_0 = true;
			}
			else
			{
				bool_0 = true;
			}
			return null;
		}

		public byte[] method_12()
		{
			byte[] array = new byte[4];
			int num = stream_0.Read(array, 0, array.Length);
			if (num == array.Length)
			{
				num = BitConverter.ToInt32(array, 0);
				array = new byte[num];
				num = stream_0.Read(array, 0, array.Length);
				if (num == array.Length)
				{
					return array;
				}
				bool_0 = true;
			}
			else
			{
				bool_0 = true;
			}
			return null;
		}

		private byte[] method_13(int int_0)
		{
			int num = 1;
			if (int_0 <= 0)
			{
				throw new ArgumentException("size <= 0");
			}
			byte[] array = new byte[int_0];
			int num2 = stream_0.Read(array, 0, array.Length);
			if (num2 == int_0)
			{
				return array;
			}
			bool_0 = true;
			return null;
		}
	}
}
