using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass641 : GClass639
	{
		private float float_2;

		internal GClass641(float float_3, float float_4, float float_5)
			: base(float_3, float_4)
		{
			float_2 = float_5;
		}

		internal bool method_0(float float_3, float float_4, float float_5)
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
