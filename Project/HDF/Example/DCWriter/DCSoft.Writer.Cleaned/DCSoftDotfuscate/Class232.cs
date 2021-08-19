using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class232 : Class231
	{
		public static GClass628 smethod_16(GClass645 gclass645_0)
		{
			int num = 11;
			sbyte[] array = gclass645_0.method_1();
			if (array == null)
			{
				return null;
			}
			Class267 @class = Class267.smethod_0(array, 0);
			if (@class == null || !@class.method_0() || !@class.method_1())
			{
				return null;
			}
			if (!@class.method_2().Equals("T"))
			{
				return null;
			}
			string[] array2 = smethod_17(@class.method_3());
			return new GClass628(array2[0], array2[1]);
		}

		internal static string[] smethod_17(sbyte[] sbyte_0)
		{
			int num = 15;
			sbyte b = sbyte_0[0];
			bool flag = (b & 0x80) != 0;
			int num2 = b & 0x1F;
			string text = Class231.smethod_15(sbyte_0, 1, num2, "US-ASCII");
			string string_ = flag ? "UTF-16" : "UTF-8";
			string text2 = Class231.smethod_15(sbyte_0, 1 + num2, sbyte_0.Length - num2 - 1, string_);
			return new string[2]
			{
				text,
				text2
			};
		}
	}
}
