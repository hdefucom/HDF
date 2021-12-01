using System;
using System.Globalization;

namespace DCSoftDotfuscate
{
	internal class Class207
	{
		public static string smethod_0(float float_0)
		{
			if (Math.Abs(float_0) < 0.0001f)
			{
				float_0 = 0f;
			}
			return float_0.ToString(NumberFormatInfo.InvariantInfo);
		}

		public static string smethod_1(double double_0)
		{
			if (Math.Abs(double_0) < 0.0001)
			{
				double_0 = 0.0;
			}
			return double_0.ToString(NumberFormatInfo.InvariantInfo);
		}
	}
}
