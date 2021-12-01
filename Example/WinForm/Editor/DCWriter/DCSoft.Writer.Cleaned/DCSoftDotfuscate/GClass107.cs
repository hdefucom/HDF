using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[Serializable]
	[DCInternal]
	[ComVisible(false)]
	public class GClass107
	{
		private string string_0 = null;

		private string string_1 = null;

		private int int_0 = 0;

		private DateTime dateTime_0 = DateTime.Now;

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_2)
		{
			string_0 = string_2;
		}

		public string method_2()
		{
			return string_1;
		}

		public void method_3(string string_2)
		{
			string_1 = string_2;
		}

		public int method_4()
		{
			return int_0;
		}

		public void method_5(int int_1)
		{
			int_0 = int_1;
		}

		public DateTime method_6()
		{
			return dateTime_0;
		}

		public void method_7(DateTime dateTime_1)
		{
			dateTime_0 = dateTime_1;
		}
	}
}
