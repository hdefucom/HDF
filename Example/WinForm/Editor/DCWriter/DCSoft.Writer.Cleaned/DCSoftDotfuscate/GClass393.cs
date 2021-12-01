using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[Serializable]
	[ComVisible(false)]
	public class GClass393 : GClass383
	{
		private GClass425 gclass425_0 = new GClass425();

		private string string_0 = null;

		public GClass393()
		{
			method_13(bool_1: true);
		}

		public GClass425 method_17()
		{
			return gclass425_0;
		}

		public void method_18(GClass425 gclass425_1)
		{
			gclass425_0 = gclass425_1;
		}

		public string method_19()
		{
			return string_0;
		}

		public void method_20(string string_1)
		{
			string_0 = string_1;
		}

		public override string vmethod_0()
		{
			return string_0;
		}

		public override string ToString()
		{
			int num = 6;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Text");
			if (method_17() != null && method_17().method_59())
			{
				stringBuilder.Append("(Hidden)");
			}
			stringBuilder.Append(":" + string_0);
			return stringBuilder.ToString();
		}
	}
}
