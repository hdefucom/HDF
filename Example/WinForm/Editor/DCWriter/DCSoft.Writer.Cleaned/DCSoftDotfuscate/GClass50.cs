using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass50
	{
		[ComVisible(false)]
		public delegate int GDelegate0(GClass50 gclass50_0, int int_0, GInterface14 ginterface14_0);

		public const bool bool_0 = false;

		protected short[] short_0;

		protected int int_0;

		protected short[] short_1;

		protected short[] short_2;

		protected int[] int_1;

		protected int[] int_2;

		protected GClass45 gclass45_0;

		protected short[] short_3;

		public GDelegate0 gdelegate0_0;

		protected short[][] short_4;

		public virtual void vmethod_0(GException5 gexception5_0)
		{
		}

		protected void method_0(int int_3, GInterface14 ginterface14_0)
		{
			if (gclass45_0.int_5 <= 0)
			{
				GException5 gException = new GException5(vmethod_2(), int_0, int_3, ginterface14_0);
				vmethod_0(gException);
				throw gException;
			}
			gclass45_0.bool_1 = true;
		}

		public int method_1(GInterface14 ginterface14_0)
		{
			int num = ginterface14_0.imethod_3();
			int num2 = 0;
			try
			{
				char c;
				while (true)
				{
					int num3 = short_3[num2];
					if (num3 < 0)
					{
						if (short_0[num2] >= 1)
						{
							return short_0[num2];
						}
						c = (char)ginterface14_0.imethod_2(1);
						if (c > 'ÿ' && c != '\uffff')
						{
							ginterface14_0.imethod_0();
							return 25;
						}
						if (c >= int_2[num2] && c <= int_1[num2])
						{
							int num4 = short_4[num2][c - int_2[num2]];
							if (num4 < 0)
							{
								if (short_2[num2] < 0)
								{
									method_0(num2, ginterface14_0);
									return 0;
								}
								num2 = short_2[num2];
								ginterface14_0.imethod_0();
							}
							else
							{
								num2 = num4;
								ginterface14_0.imethod_0();
							}
						}
						else
						{
							if (short_2[num2] < 0)
							{
								break;
							}
							num2 = short_2[num2];
							ginterface14_0.imethod_0();
						}
					}
					else
					{
						num2 = gdelegate0_0(this, num3, ginterface14_0);
						ginterface14_0.imethod_0();
					}
				}
				if (c == (ushort)GClass84.int_6 && short_1[num2] >= 0)
				{
					return short_0[short_1[num2]];
				}
				method_0(num2, ginterface14_0);
				return 0;
			}
			finally
			{
				ginterface14_0.imethod_6(num);
			}
		}

		public virtual int vmethod_1(int int_3, GInterface14 ginterface14_0)
		{
			return -1;
		}

		public int method_2(int int_3, int int_4)
		{
			return 0;
		}

		public virtual string vmethod_2()
		{
			return "n/a";
		}
	}
}
