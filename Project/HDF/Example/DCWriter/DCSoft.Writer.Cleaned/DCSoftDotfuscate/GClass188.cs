using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass188 : GClass164
	{
		protected int int_0 = 1;

		public override string TagName => "H" + int_0;

		public int method_50()
		{
			return int_0;
		}

		public void method_51(int int_1)
		{
			if (int_1 >= 1 && int_1 <= 6)
			{
				int_0 = int_1;
			}
		}

		public bool method_52()
		{
			return method_14("disabled");
		}

		public void method_53(bool bool_0)
		{
			method_15("disabled", bool_0);
		}

		public string method_54()
		{
			return method_9("align");
		}

		public void method_55(string string_0)
		{
			method_11("align", string_0);
		}
	}
}
