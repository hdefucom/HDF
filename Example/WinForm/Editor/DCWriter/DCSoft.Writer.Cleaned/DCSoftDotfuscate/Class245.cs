using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class245 : GClass608
	{
		private Class245()
		{
		}

		public static GClass624 smethod_15(GClass645 gclass645_0)
		{
			int num = 8;
			string text = gclass645_0.method_0();
			if (text != null && text.StartsWith("URL:"))
			{
				text = text.Substring(4);
			}
			if (!smethod_16(text))
			{
				return null;
			}
			return new GClass624(text, null);
		}

		internal static bool smethod_16(string string_0)
		{
			if (string_0 == null || string_0.IndexOf(' ') >= 0 || string_0.IndexOf('\n') >= 0)
			{
				return false;
			}
			int num = string_0.IndexOf('.');
			if (num >= string_0.Length - 2)
			{
				return false;
			}
			int num2 = string_0.IndexOf(':');
			if (num < 0 && num2 < 0)
			{
				return false;
			}
			if (num2 >= 0)
			{
				if (num < 0 || num > num2)
				{
					for (int i = 0; i < num2; i++)
					{
						char c = string_0[i];
						if ((c < 'a' || c > 'z') && (c < 'A' || c > 'Z'))
						{
							return false;
						}
					}
				}
				else
				{
					if (num2 >= string_0.Length - 2)
					{
						return false;
					}
					for (int i = num2 + 1; i < num2 + 3; i++)
					{
						char c = string_0[i];
						if (c < '0' || c > '9')
						{
							return false;
						}
					}
				}
			}
			return true;
		}
	}
}
