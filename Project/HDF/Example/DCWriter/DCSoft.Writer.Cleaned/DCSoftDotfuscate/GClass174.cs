using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass174 : GClass164
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

		public override string TagName => "MAP";

		public string method_50()
		{
			return method_9("title");
		}

		public void method_51(string string_0)
		{
			method_11("title", string_0);
		}
	}
}
