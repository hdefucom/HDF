using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass647
	{
		private GClass681 gclass681_0;

		public GClass647()
		{
			gclass681_0 = new GClass681(GClass618.gclass618_1);
		}

		public GClass678 method_0(bool[][] bool_0)
		{
			int num = bool_0.Length;
			GClass679 gClass = new GClass679(num);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (bool_0[i][j])
					{
						gClass.method_4(j, i);
					}
				}
			}
			return method_1(gClass);
		}

		public GClass678 method_1(GClass679 gclass679_0)
		{
			Class251 @class = new Class251(gclass679_0);
			GClass676 gclass676_ = @class.method_0(gclass679_0);
			sbyte[] sbyte_ = @class.method_1();
			Class250[] array = Class250.smethod_0(sbyte_, gclass676_);
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				num += array[i].method_0();
			}
			sbyte[] array2 = new sbyte[num];
			int num2 = 0;
			foreach (Class250 class2 in array)
			{
				sbyte[] array3 = class2.method_1();
				int num3 = class2.method_0();
				method_2(array3, num3);
				for (int i = 0; i < num3; i++)
				{
					array2[num2++] = array3[i];
				}
			}
			return Class271.smethod_0(array2);
		}

		private void method_2(sbyte[] sbyte_0, int int_0)
		{
			int num = sbyte_0.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (sbyte_0[i] & 0xFF);
			}
			int int_ = sbyte_0.Length - int_0;
			try
			{
				gclass681_0.method_0(array, int_);
			}
			catch (GException27)
			{
				throw GException25.smethod_0();
			}
			for (int i = 0; i < int_0; i++)
			{
				sbyte_0[i] = (sbyte)array[i];
			}
		}
	}
}
