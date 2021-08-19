using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass176 : GClass164
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

		public override string TagName => "A";

		public bool method_50()
		{
			return method_13("disabled");
		}

		public void method_51(bool bool_0)
		{
			int num = 3;
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
			return method_9("href");
		}

		public void method_53(string string_0)
		{
			method_11("href", string_0);
		}

		public string method_54()
		{
			return method_9("methods");
		}

		public void method_55(string string_0)
		{
			method_11("methods", string_0);
		}

		public string method_56()
		{
			return method_9("target");
		}

		public void method_57(string string_0)
		{
			method_11("target", string_0);
		}

		public string method_58()
		{
			return method_9("title");
		}

		public void method_59(string string_0)
		{
			method_11("title", string_0);
		}

		public string method_60()
		{
			return method_9("urn");
		}

		public void method_61(string string_0)
		{
			method_11("urn", string_0);
		}

		public string method_62()
		{
			return method_9("type");
		}

		public void method_63(string string_0)
		{
			method_11("type", string_0);
		}

		public string method_64()
		{
			return method_9("shape");
		}

		public void method_65(string string_0)
		{
			method_11("shape", string_0);
		}
	}
}
