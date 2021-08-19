using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class238 : Class235
	{
		private static readonly char[] char_0 = new char[21]
		{
			'@',
			'.',
			'!',
			'#',
			'$',
			'%',
			'&',
			'\'',
			'*',
			'+',
			'-',
			'/',
			'=',
			'?',
			'^',
			'_',
			'`',
			'{',
			'|',
			'}',
			'~'
		};

		public static GClass622 smethod_17(GClass645 gclass645_0)
		{
			int num = 0;
			string text = gclass645_0.method_0();
			if (!(text?.StartsWith("MATMSG:") ?? false))
			{
				return null;
			}
			string[] array = Class235.smethod_15("TO:", text, bool_0: true);
			if (array == null)
			{
				return null;
			}
			string text2 = array[0];
			if (!smethod_18(text2))
			{
				return null;
			}
			string string_ = Class235.smethod_16("SUB:", text, bool_0: false);
			string string_2 = Class235.smethod_16("BODY:", text, bool_0: false);
			return new GClass622(text2, string_, string_2, "mailto:" + text2);
		}

		internal static bool smethod_18(string string_0)
		{
			if (string_0 == null)
			{
				return false;
			}
			bool flag = false;
			int num = 0;
			while (true)
			{
				if (num < string_0.Length)
				{
					char c = string_0[num];
					if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || smethod_19(c))
					{
						if (c == '@')
						{
							if (flag)
							{
								break;
							}
							flag = true;
						}
						num++;
						continue;
					}
					return false;
				}
				return flag;
			}
			return false;
		}

		private static bool smethod_19(char char_1)
		{
			int num = 0;
			while (true)
			{
				if (num < char_0.Length)
				{
					if (char_1 == char_0[num])
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}
}
