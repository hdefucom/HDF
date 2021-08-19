using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass168 : GClass164
	{
		public override string TagName => "B";

		public bool method_50()
		{
			return method_13("disabled");
		}

		public void method_51(bool bool_0)
		{
			int num = 14;
			if (bool_0)
			{
				method_11("disabled", "1");
			}
			else
			{
				method_12("disabled");
			}
		}
	}
}
