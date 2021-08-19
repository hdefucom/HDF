namespace DCSoftDotfuscate
{
	internal class Class131
	{
		internal enum Enum12
		{
			const_0,
			const_1,
			const_2
		}

		private static Enum12[] enum12_0 = null;

		private static readonly int[] int_0 = new int[30]
		{
			3904,
			3905,
			3906,
			3908,
			3909,
			3910,
			3911,
			3913,
			3919,
			3920,
			3921,
			3923,
			3924,
			3925,
			3926,
			3928,
			3929,
			3930,
			3931,
			3933,
			3934,
			3935,
			3936,
			3937,
			3938,
			3939,
			3940,
			3942,
			3943,
			3944
		};

		private static readonly int[] int_1 = new int[4]
		{
			3956,
			3962,
			3964,
			3954
		};

		public static bool smethod_0(char char_0)
		{
			if (char_0 == '་' || char_0 == '།')
			{
				return true;
			}
			return false;
		}

		public static bool smethod_1(char char_0)
		{
			if ('ༀ' <= char_0 && char_0 <= '\u0fff')
			{
				return true;
			}
			return false;
		}

		public static Enum12 smethod_2(char char_0)
		{
			if (enum12_0 == null)
			{
				enum12_0 = new Enum12[100];
				for (int i = 0; i < 100; i++)
				{
					enum12_0[i] = Enum12.const_0;
				}
				int[] array = int_0;
				foreach (int num in array)
				{
					enum12_0[num - 3900] = Enum12.const_2;
				}
				array = int_1;
				foreach (int num in array)
				{
					enum12_0[num - 3900] = Enum12.const_1;
				}
			}
			int num2 = char_0 - 3900;
			if (num2 >= 0 && num2 < 64)
			{
				return enum12_0[num2];
			}
			return Enum12.const_0;
		}

		public static bool smethod_3(char char_0)
		{
			return char_0 == '\u0f74' || char_0 == '\u0f7a' || char_0 == '\u0f7c' || char_0 == '\u0f72';
		}

		public static bool smethod_4(char char_0)
		{
			if (char_0 >= '\u0f71' && char_0 <= '\u0f84')
			{
				return true;
			}
			if (char_0 >= '\u0f90' && char_0 <= '\u0fbc')
			{
				return true;
			}
			return char_0 == '\u0f19' || char_0 == '\u0f35' || char_0 == '\u0f37' || char_0 == '\u0f39' || char_0 == '\u0f86' || char_0 == '\u0f87';
		}
	}
}
