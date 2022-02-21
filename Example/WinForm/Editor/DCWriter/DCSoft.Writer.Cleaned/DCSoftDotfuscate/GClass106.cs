using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	
	public class GClass106
	{
		private static GClass106 gclass106_0 = null;

		private int int_0 = 0;

		private long long_0 = 0L;

		private string string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DCLocalBuffer");

		private List<GClass107> list_0 = null;

		public static GClass106 smethod_0()
		{
			if (gclass106_0 == null)
			{
				gclass106_0 = new GClass106();
			}
			return gclass106_0;
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_1)
		{
			int_0 = int_1;
		}

		public long method_2()
		{
			return long_0;
		}

		public void method_3(long long_1)
		{
			long_0 = long_1;
		}

		public string method_4()
		{
			return string_0;
		}

		public void method_5(string string_1)
		{
			string_0 = string_1;
			list_0 = null;
		}

		public List<GClass107> method_6()
		{
			if (list_0 != null)
			{
			}
			return list_0;
		}
	}
}
