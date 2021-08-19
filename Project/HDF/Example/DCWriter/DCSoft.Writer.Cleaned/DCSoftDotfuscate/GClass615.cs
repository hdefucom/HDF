using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass615
	{
		private const int int_0 = 3;

		private const int int_1 = 512;

		public GClass678 method_0(bool[][] bool_0)
		{
			int num = bool_0.Length;
			GClass679 gClass = new GClass679(num);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (bool_0[j][i])
					{
						gClass.method_4(j, i);
					}
				}
			}
			return method_1(gClass);
		}

		public GClass678 method_1(GClass679 gclass679_0)
		{
			Class265 @class = new Class265(gclass679_0);
			int[] array = @class.method_2();
			if (array == null || array.Length == 0)
			{
				throw GException25.smethod_0();
			}
			int num = @class.method_1();
			int num2 = 1 << num + 1;
			int[] int_ = @class.method_0();
			smethod_1(array, int_, num2);
			smethod_0(array, num2);
			return Class249.smethod_0(array);
		}

		private static void smethod_0(int[] int_2, int int_3)
		{
			if (int_2.Length < 4)
			{
				throw GException25.smethod_0();
			}
			int num = int_2[0];
			if (num > int_2.Length)
			{
				throw GException25.smethod_0();
			}
			if (num == 0)
			{
				if (int_3 >= int_2.Length)
				{
					throw GException25.smethod_0();
				}
				int_2[0] = int_2.Length - int_3;
			}
		}

		private static int smethod_1(int[] int_2, int[] int_3, int int_4)
		{
			if ((int_3 != null && int_3.Length > int_4 / 2 + 3) || int_4 < 0 || int_4 > 512)
			{
				throw GException25.smethod_0();
			}
			int num = 0;
			if (int_3 != null)
			{
				int num2 = int_3.Length;
				if (num > 0)
				{
					num2 -= num;
				}
				if (num2 > 3)
				{
					throw GException25.smethod_0();
				}
			}
			return num;
		}
	}
}
