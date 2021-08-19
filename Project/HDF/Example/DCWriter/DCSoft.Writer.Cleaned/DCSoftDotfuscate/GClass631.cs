using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass631 : GClass620
	{
		private string[] string_0;

		private string string_1;

		private string[] string_2;

		private string[] string_3;

		private string string_4;

		private string[] string_5;

		private string string_6;

		private string string_7;

		private string string_8;

		private string string_9;

		public string[] method_0()
		{
			return string_0;
		}

		public string method_1()
		{
			return string_1;
		}

		public string[] method_2()
		{
			return string_2;
		}

		public string[] method_3()
		{
			return string_3;
		}

		public string method_4()
		{
			return string_4;
		}

		public string[] method_5()
		{
			return string_5;
		}

		public string method_6()
		{
			return string_8;
		}

		public string method_7()
		{
			return string_6;
		}

		public string method_8()
		{
			return string_9;
		}

		public string method_9()
		{
			return string_7;
		}

		public override string vmethod_1()
		{
			StringBuilder stringBuilder = new StringBuilder(100);
			GClass620.smethod_1(string_0, stringBuilder);
			GClass620.smethod_0(string_1, stringBuilder);
			GClass620.smethod_0(string_8, stringBuilder);
			GClass620.smethod_0(string_6, stringBuilder);
			GClass620.smethod_1(string_5, stringBuilder);
			GClass620.smethod_1(string_2, stringBuilder);
			GClass620.smethod_1(string_3, stringBuilder);
			GClass620.smethod_0(string_9, stringBuilder);
			GClass620.smethod_0(string_7, stringBuilder);
			GClass620.smethod_0(string_4, stringBuilder);
			return stringBuilder.ToString();
		}

		public GClass631(string[] string_10, string string_11, string[] string_12, string[] string_13, string string_14, string[] string_15, string string_16, string string_17, string string_18, string string_19)
			: base(GClass660.gclass660_0)
		{
			string_0 = string_10;
			string_1 = string_11;
			string_2 = string_12;
			string_3 = string_13;
			string_4 = string_14;
			string_5 = string_15;
			string_6 = string_16;
			string_7 = string_17;
			string_8 = string_18;
			string_9 = string_19;
		}
	}
}
