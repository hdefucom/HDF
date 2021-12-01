using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass620
	{
		private GClass660 gclass660_0;

		public virtual GClass660 vmethod_0()
		{
			return gclass660_0;
		}

		public abstract string vmethod_1();

		protected internal GClass620(GClass660 gclass660_1)
		{
			gclass660_0 = gclass660_1;
		}

		public override string ToString()
		{
			return vmethod_1();
		}

		public static void smethod_0(string string_0, StringBuilder stringBuilder_0)
		{
			if (string_0 != null && string_0.Length > 0)
			{
				if (stringBuilder_0.Length > 0)
				{
					stringBuilder_0.Append('\n');
				}
				stringBuilder_0.Append(string_0);
			}
		}

		public static void smethod_1(string[] string_0, StringBuilder stringBuilder_0)
		{
			if (string_0 == null)
			{
				return;
			}
			for (int i = 0; i < string_0.Length; i++)
			{
				if (string_0[i] != null && string_0[i].Length > 0)
				{
					if (stringBuilder_0.Length > 0)
					{
						stringBuilder_0.Append('\n');
					}
					stringBuilder_0.Append(string_0[i]);
				}
			}
		}
	}
}
