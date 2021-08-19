using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal abstract class Class256
	{
		private class Class257 : Class256
		{
			internal override bool vmethod_0(int int_0, int int_1)
			{
				return ((int_0 + int_1) & 1) == 0;
			}
		}

		private class Class258 : Class256
		{
			internal override bool vmethod_0(int int_0, int int_1)
			{
				return (int_0 & 1) == 0;
			}
		}

		private class Class259 : Class256
		{
			internal override bool vmethod_0(int int_0, int int_1)
			{
				return int_1 % 3 == 0;
			}
		}

		private class Class260 : Class256
		{
			internal override bool vmethod_0(int int_0, int int_1)
			{
				return (int_0 + int_1) % 3 == 0;
			}
		}

		private class Class261 : Class256
		{
			internal override bool vmethod_0(int int_0, int int_1)
			{
				return ((GClass634.smethod_3(int_0, 1) + int_1 / 3) & 1) == 0;
			}
		}

		private class Class262 : Class256
		{
			internal override bool vmethod_0(int int_0, int int_1)
			{
				int num = int_0 * int_1;
				return (num & 1) + num % 3 == 0;
			}
		}

		private class Class263 : Class256
		{
			internal override bool vmethod_0(int int_0, int int_1)
			{
				int num = int_0 * int_1;
				return (((num & 1) + num % 3) & 1) == 0;
			}
		}

		private class Class264 : Class256
		{
			internal override bool vmethod_0(int int_0, int int_1)
			{
				return ((((int_0 + int_1) & 1) + int_0 * int_1 % 3) & 1) == 0;
			}
		}

		private static readonly Class256[] class256_0 = new Class256[8]
		{
			new Class257(),
			new Class258(),
			new Class259(),
			new Class260(),
			new Class261(),
			new Class262(),
			new Class263(),
			new Class264()
		};

		private Class256()
		{
		}

		internal void method_0(GClass679 gclass679_0, int int_0)
		{
			for (int i = 0; i < int_0; i++)
			{
				for (int j = 0; j < int_0; j++)
				{
					if (vmethod_0(i, j))
					{
						gclass679_0.method_5(j, i);
					}
				}
			}
		}

		internal abstract bool vmethod_0(int int_0, int int_1);

		internal static Class256 smethod_0(int int_0)
		{
			if (int_0 < 0 || int_0 > 7)
			{
				throw new ArgumentException();
			}
			return class256_0[int_0];
		}
	}
}
