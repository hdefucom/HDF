using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class247 : GClass608
	{
		private Class247()
		{
		}

		public static GClass626 smethod_15(GClass645 gclass645_0)
		{
			int num = 8;
			string text = gclass645_0.method_0();
			if (text == null || (!text.StartsWith("geo:") && !text.StartsWith("GEO:")))
			{
				return null;
			}
			int num2 = text.IndexOf('?', 4);
			string text2 = (num2 < 0) ? text.Substring(4) : text.Substring(4, num2 - 4);
			int num3 = text2.IndexOf(',');
			if (num3 < 0)
			{
				return null;
			}
			int num4 = text2.IndexOf(',', num3 + 1);
			double double_;
			double double_2;
			double double_3;
			try
			{
				double_ = double.Parse(text2.Substring(0, num3));
				if (num4 < 0)
				{
					double_2 = double.Parse(text2.Substring(num3 + 1));
					double_3 = 0.0;
				}
				else
				{
					double_2 = double.Parse(text2.Substring(num3 + 1, num4 - (num3 + 1)));
					double_3 = double.Parse(text2.Substring(num4 + 1));
				}
			}
			catch (FormatException)
			{
				return null;
			}
			return new GClass626(text.StartsWith("GEO:") ? ("geo:" + text.Substring(4)) : text, double_, double_2, double_3);
		}
	}
}
