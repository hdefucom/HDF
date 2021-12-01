using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass193 : GClass164
	{
		public override string TagName => "PRE";

		public bool method_50()
		{
			return method_13("disabled");
		}

		public void method_51(bool bool_0)
		{
			int num = 4;
			if (bool_0)
			{
				method_11("disabled", "1");
			}
			else
			{
				method_12("disabled");
			}
		}

		public string method_52()
		{
			return method_9("width");
		}

		public void method_53(string string_0)
		{
			method_11("width", string_0);
		}

		public string method_54()
		{
			return method_9("wrap");
		}

		public void method_55(string string_0)
		{
			method_11("wrap", string_0);
		}
	}
}
