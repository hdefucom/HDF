using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass200 : GClass163
	{
		public string Name
		{
			get
			{
				return method_9("name");
			}
			set
			{
				method_11("name", value);
			}
		}

		public override string TagName => "PARAM";

		public override string vmethod_4()
		{
			return method_9("value");
		}

		public override void vmethod_5(string string_0)
		{
			method_11("value", string_0);
		}
	}
}
