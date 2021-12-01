using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GStream7 : GStream5
	{
		[ComVisible(false)]
		private enum Enum32
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		protected GClass548 gclass548_0 = new GClass548();

		private Enum32 enum32_0 = Enum32.const_0;

		public GStream7(Stream stream_1)
			: this(stream_1, 4096)
		{
		}

		public GStream7(Stream stream_1, int int_0)
			: base(stream_1, new GClass586(-1, bool_1: true), int_0)
		{
		}

		public void method_10(int int_0)
		{
			int num = 1;
			if (int_0 < 1)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			gclass586_0.method_10(int_0);
		}

		public int method_11()
		{
			return gclass586_0.method_11();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			int num = 15;
			if (enum32_0 == Enum32.const_0)
			{
				method_12();
			}
			if (enum32_0 != Enum32.const_1)
			{
				throw new InvalidOperationException("Write not permitted in current state");
			}
			gclass548_0.imethod_4(buffer, offset, count);
			base.Write(buffer, offset, count);
		}

		public override void Close()
		{
			try
			{
				vmethod_0();
			}
			finally
			{
				if (enum32_0 != Enum32.const_3)
				{
					enum32_0 = Enum32.const_3;
					if (method_0())
					{
						stream_0.Close();
					}
				}
			}
		}

		public override void vmethod_0()
		{
			if (enum32_0 == Enum32.const_0)
			{
				method_12();
			}
			if (enum32_0 == Enum32.const_1)
			{
				enum32_0 = Enum32.const_2;
				base.vmethod_0();
				uint num = (uint)(gclass586_0.method_2() & 0xFFFFFFFF);
				uint num2 = (uint)(gclass548_0.imethod_0() & 0xFFFFFFFF);
				byte[] array = new byte[8]
				{
					(byte)num2,
					(byte)(num2 >> 8),
					(byte)(num2 >> 16),
					(byte)(num2 >> 24),
					(byte)num,
					(byte)(num >> 8),
					(byte)(num >> 16),
					(byte)(num >> 24)
				};
				stream_0.Write(array, 0, array.Length);
			}
		}

		private void method_12()
		{
			if (enum32_0 == Enum32.const_0)
			{
				enum32_0 = Enum32.const_1;
				int num = (int)((DateTime.Now.Ticks - new DateTime(1970, 1, 1).Ticks) / 10000000L);
				byte[] array = new byte[10]
				{
					31,
					139,
					8,
					0,
					0,
					0,
					0,
					0,
					0,
					255
				};
				array[4] = (byte)num;
				array[5] = (byte)(num >> 8);
				array[6] = (byte)(num >> 16);
				array[7] = (byte)(num >> 24);
				byte[] array2 = array;
				stream_0.Write(array2, 0, array2.Length);
			}
		}
	}
}
