using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[ComVisible(false)]
	public class GClass413
	{
		protected int int_0 = 0;

		protected byte[] byte_0 = new byte[16];

		public virtual void vmethod_0()
		{
			byte_0 = new byte[16];
			int_0 = 0;
		}

		public void method_0()
		{
			int_0 = 0;
		}

		public byte method_1(int int_1)
		{
			int num = 16;
			if (int_1 < 0 || int_1 >= int_0)
			{
				throw new IndexOutOfRangeException("index");
			}
			return byte_0[int_1];
		}

		public void method_2(int int_1, byte byte_1)
		{
			int num = 7;
			if (int_1 < 0 || int_1 >= int_0)
			{
				throw new IndexOutOfRangeException("index");
			}
			byte_0[int_1] = byte_1;
		}

		public virtual int vmethod_1()
		{
			return int_0;
		}

		public void method_3(byte byte_1)
		{
			method_8(int_0 + 1);
			byte_0[int_0] = byte_1;
			int_0++;
		}

		public void method_4(byte[] byte_1)
		{
			if (byte_1 != null)
			{
				method_5(byte_1, 0, byte_1.Length);
			}
		}

		public void method_5(byte[] byte_1, int int_1, int int_2)
		{
			if (byte_1 != null && int_1 >= 0 && int_1 + int_2 <= byte_1.Length && int_2 > 0)
			{
				method_8(int_0 + int_2);
				Array.Copy(byte_1, int_1, byte_0, int_0, int_2);
				int_0 += int_2;
			}
		}

		public byte[] method_6()
		{
			if (int_0 > 0)
			{
				byte[] array = new byte[int_0];
				Array.Copy(byte_0, 0, array, 0, int_0);
				return array;
			}
			return null;
		}

		public string method_7(Encoding encoding_0)
		{
			int num = 15;
			if (encoding_0 == null)
			{
				throw new ArgumentNullException("encoding");
			}
			if (int_0 > 0)
			{
				return encoding_0.GetString(byte_0, 0, int_0);
			}
			return "";
		}

		protected void method_8(int int_1)
		{
			if (int_1 > byte_0.Length)
			{
				if (int_1 < (int)((double)byte_0.Length * 1.5))
				{
					int_1 = (int)((double)byte_0.Length * 1.5);
				}
				byte[] dst = new byte[int_1];
				Buffer.BlockCopy(byte_0, 0, dst, 0, byte_0.Length);
				byte_0 = dst;
			}
		}
	}
}
