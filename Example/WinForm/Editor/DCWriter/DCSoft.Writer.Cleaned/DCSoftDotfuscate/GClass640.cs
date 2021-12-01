using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass640 : GClass639
	{
		private float float_2;

		private int int_0;

		public float method_0()
		{
			return float_2;
		}

		internal int method_1()
		{
			return int_0;
		}

		internal GClass640(float float_3, float float_4, float float_5)
			: base(float_3, float_4)
		{
			float_2 = float_5;
			int_0 = 1;
		}

		internal void method_2()
		{
			int_0++;
		}

		internal bool method_3(float float_3, float float_4, float float_5)
		{
			if (Math.Abs(float_4 - vmethod_1()) <= float_3 && Math.Abs(float_5 - vmethod_0()) <= float_3)
			{
				float num = Math.Abs(float_3 - float_2);
				return num <= 1f || num / float_2 <= 1f;
			}
			return false;
		}
	}
}
