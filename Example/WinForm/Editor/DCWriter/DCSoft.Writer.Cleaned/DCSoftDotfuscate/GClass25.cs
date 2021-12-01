using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass25
	{
		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		private string string_3 = null;

		private bool bool_0 = false;

		private string string_4 = null;

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_5)
		{
			string_0 = string_5;
		}

		public string method_2()
		{
			return string_1;
		}

		public void method_3(string string_5)
		{
			string_1 = string_5;
		}

		public string method_4()
		{
			return string_2;
		}

		public void method_5(string string_5)
		{
			string_2 = string_5;
		}

		public string method_6()
		{
			return string_3;
		}

		public void method_7(string string_5)
		{
			string_3 = string_5;
		}

		public bool method_8()
		{
			return bool_0;
		}

		public void method_9(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public string method_10()
		{
			return string_4;
		}

		public void method_11(string string_5)
		{
			string_4 = string_5;
		}

		public override string ToString()
		{
			return method_0() + ">" + method_4();
		}
	}
}
