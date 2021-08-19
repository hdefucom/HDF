using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs17 : EventArgs
	{
		private string string_0;

		private long long_0;

		private long long_1;

		private bool bool_0 = true;

		public string Name => string_0;

		public GEventArgs17(string string_1, long long_2, long long_3)
		{
			string_0 = string_1;
			long_0 = long_2;
			long_1 = long_3;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public float method_2()
		{
			if (long_1 <= 0L)
			{
				return 0f;
			}
			return (float)long_0 / (float)long_1 * 100f;
		}

		public long method_3()
		{
			return long_0;
		}

		public long method_4()
		{
			return long_1;
		}
	}
}
