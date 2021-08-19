using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass501
	{
		public static uint smethod_0(GClass498 gclass498_0, int int_0, int int_1)
		{
			int num = int_1 % 4;
			if (num > 0)
			{
				int_1 += 4 - num;
			}
			int_1 /= 4;
			int int_2 = gclass498_0.vmethod_3();
			try
			{
				gclass498_0.method_27(int_0);
				uint num2 = 0u;
				for (int i = 0; i < int_1; i++)
				{
					num2 += gclass498_0.method_4();
				}
				return num2;
			}
			finally
			{
				gclass498_0.method_27(int_2);
			}
		}
	}
}
