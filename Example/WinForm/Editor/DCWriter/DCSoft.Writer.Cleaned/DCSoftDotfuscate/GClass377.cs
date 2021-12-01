using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass377
	{
		private static DateTime dateTime_0 = DateTime.Now;

		private static long long_0 = 0L;

		private static long long_1 = 0L;

		private static long long_2 = 0L;

		private static bool bool_0 = false;

		private static volatile object object_0 = new object();

		public static bool smethod_0()
		{
			return bool_0;
		}

		public static void smethod_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public static void smethod_2(DateTime dateTime_1)
		{
			lock (object_0)
			{
				dateTime_0 = dateTime_1;
				long_0 = DateTime.Now.Ticks - dateTime_0.Ticks;
				long_2 = Environment.TickCount;
				bool_0 = true;
			}
		}

		public static DateTime smethod_3()
		{
			lock (object_0)
			{
				if (bool_0)
				{
					DateTime dateTime = dateTime_0;
					long num = Environment.TickCount - long_2;
					dateTime = dateTime.AddSeconds((double)num / 1000.0);
					DateTime dateTime2 = DateTime.Now.AddTicks(-long_0);
					if (Math.Abs((dateTime - dateTime2).Seconds) > 2)
					{
						bool_0 = false;
						return DateTime.Now;
					}
					return dateTime2;
				}
				return DateTime.Now;
			}
		}
	}
}
