using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	public sealed class GClass272
	{
		private struct Struct71
		{
			public uint uint_0;

			public uint uint_1;

			public uint uint_2;

			public uint uint_3;

			public uint uint_4;

			public uint uint_5;

			public uint uint_6;

			public uint uint_7;
		}

		private static Struct71 struct71_0;

		static GClass272()
		{
			struct71_0 = default(Struct71);
			smethod_7();
		}

		public static uint smethod_0()
		{
			return struct71_0.uint_1;
		}

		public static uint smethod_1()
		{
			return struct71_0.uint_2;
		}

		public static uint smethod_2()
		{
			return struct71_0.uint_3;
		}

		public static uint smethod_3()
		{
			return struct71_0.uint_4;
		}

		public static uint smethod_4()
		{
			return struct71_0.uint_5;
		}

		public static uint smethod_5()
		{
			return struct71_0.uint_6;
		}

		public static uint smethod_6()
		{
			return struct71_0.uint_7;
		}

		public static void smethod_7()
		{
			struct71_0.uint_0 = 24u;
			GlobalMemoryStatus(ref struct71_0);
		}

		[DllImport("kernel32")]
		private static extern void GlobalMemoryStatus(ref Struct71 struct71_1);

		private GClass272()
		{
		}
	}
}
