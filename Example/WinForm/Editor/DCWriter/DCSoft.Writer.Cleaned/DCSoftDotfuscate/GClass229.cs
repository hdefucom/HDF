using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass229
	{
		public string string_0;

		public string string_1;

		public GClass229 method_0()
		{
			return (GClass229)MemberwiseClone();
		}

		public string method_1()
		{
			int num = 8;
			if (string_1 != null && string_1.IndexOf("\r\n") >= 0)
			{
				return string_1.Replace("\r\n", "");
			}
			return string_1;
		}

		public bool method_2()
		{
			int num = 4;
			return string_1 != null && string_1.StartsWith("xsl:");
		}

		public string method_3()
		{
			int num = 7;
			if (string_1 != null && string_1.StartsWith("xsl:"))
			{
				string text = string_1.Substring(4);
				if (text.IndexOf("\r\n") >= 0)
				{
					return text.Replace("\r\n", "");
				}
				return text;
			}
			return null;
		}

		public override string ToString()
		{
			return string_0 + "=" + string_1;
		}
	}
}
