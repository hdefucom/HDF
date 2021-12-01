using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass210 : GClass163
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

		public override string TagName => "LINK";

		public string method_46()
		{
			return method_9("href");
		}

		public void method_47(string string_0)
		{
			method_11("href", string_0);
		}

		public string method_48()
		{
			return method_9("rel");
		}

		public void method_49(string string_0)
		{
			method_11("rel", string_0);
		}

		public string method_50()
		{
			return method_9("rev");
		}

		public void method_51(string string_0)
		{
			method_11("rev", string_0);
		}

		public string method_52()
		{
			return method_9("target");
		}

		public void method_53(string string_0)
		{
			method_11("target", string_0);
		}

		public string method_54()
		{
			return method_9("type");
		}

		public void method_55(string string_0)
		{
			method_11("type", string_0);
		}
	}
}
