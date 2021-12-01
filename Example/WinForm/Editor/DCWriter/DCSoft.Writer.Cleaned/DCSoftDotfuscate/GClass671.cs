using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass671
	{
		private const int int_0 = 32;

		private sbyte[] sbyte_0;

		private int int_1;

		public bool method_0()
		{
			return int_1 == 0;
		}

		public GClass671()
		{
			sbyte_0 = null;
			int_1 = 0;
		}

		public GClass671(int int_2)
		{
			sbyte_0 = new sbyte[int_2];
			int_1 = int_2;
		}

		public GClass671(sbyte[] sbyte_1)
		{
			sbyte_0 = sbyte_1;
			int_1 = sbyte_0.Length;
		}

		public int method_1(int int_2)
		{
			return sbyte_0[int_2] & 0xFF;
		}

		public void method_2(int int_2, int int_3)
		{
			sbyte_0[int_2] = (sbyte)int_3;
		}

		public int method_3()
		{
			return int_1;
		}

		public void method_4(int int_2)
		{
			if (int_1 == 0 || int_1 >= sbyte_0.Length)
			{
				int int_3 = Math.Max(32, int_1 << 1);
				method_5(int_3);
			}
			sbyte_0[int_1] = (sbyte)int_2;
			int_1++;
		}

		public void method_5(int int_2)
		{
			if (sbyte_0 == null || sbyte_0.Length < int_2)
			{
				sbyte[] destinationArray = new sbyte[int_2];
				if (sbyte_0 != null)
				{
					Array.Copy(sbyte_0, 0, destinationArray, 0, sbyte_0.Length);
				}
				sbyte_0 = destinationArray;
			}
		}

		public void method_6(sbyte[] sbyte_1, int int_2, int int_3)
		{
			sbyte_0 = new sbyte[int_3];
			int_1 = int_3;
			for (int i = 0; i < int_3; i++)
			{
				sbyte_0[i] = sbyte_1[int_2 + i];
			}
		}
	}
}
