using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass592
	{
		internal GClass592()
		{
		}

		public static string smethod_0(string string_0)
		{
			string text = string_0;
			if (string_0 != null && string_0.Length > 0)
			{
				if (string_0[0] == '\\' || string_0[0] == '/')
				{
					if (string_0.Length > 1 && (string_0[1] == '\\' || string_0[1] == '/'))
					{
						int i = 2;
						int num = 2;
						for (; i <= string_0.Length; i++)
						{
							if ((string_0[i] == '\\' || string_0[i] == '/') && --num <= 0)
							{
								break;
							}
						}
						i++;
						text = ((i >= string_0.Length) ? "" : string_0.Substring(i));
					}
				}
				else if (string_0.Length > 1 && string_0[1] == ':')
				{
					int count = 2;
					if (string_0.Length > 2 && (string_0[2] == '\\' || string_0[2] == '/'))
					{
						count = 3;
					}
					text = text.Remove(0, count);
				}
			}
			return text;
		}
	}
}
