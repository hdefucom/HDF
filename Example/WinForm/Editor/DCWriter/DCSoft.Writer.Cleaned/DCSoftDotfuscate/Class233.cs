using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class233 : Class231
	{
		public static GClass623 smethod_16(GClass645 gclass645_0)
		{
			int num = 12;
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
			if (!@class.method_2().Equals("Sp"))
			{
				return null;
			}
			int num2 = 0;
			int num3 = 0;
			Class267 class2 = null;
			sbyte[] array2 = @class.method_3();
			int int_ = -1;
			string string_ = null;
			string string_2 = null;
			while (true)
			{
				if (num2 < array2.Length && (class2 = Class267.smethod_0(array2, num2)) != null)
				{
					if (num3 == 0 && !class2.method_0())
					{
						break;
					}
					string value = class2.method_2();
					if ("T".Equals(value))
					{
						string[] array3 = Class232.smethod_17(class2.method_3());
						string_ = array3[1];
					}
					else if ("U".Equals(value))
					{
						string_2 = Class234.smethod_17(class2.method_3());
					}
					else if ("act".Equals(value))
					{
						int_ = class2.method_3()[0];
					}
					num3++;
					num2 += class2.method_4();
					continue;
				}
				if (num3 == 0 || !(class2?.method_1() ?? true))
				{
					return null;
				}
				return new GClass623(int_, string_2, string_);
			}
			return null;
		}
	}
}
