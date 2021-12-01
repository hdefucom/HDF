using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class240 : GClass608
	{
		private Class240()
		{
		}

		public static GClass629 smethod_15(GClass645 gclass645_0)
		{
			int num = 18;
			string text = gclass645_0.method_0();
			if (text == null)
			{
				return null;
			}
			int num2;
			if (text.StartsWith("sms:") || text.StartsWith("SMS:") || text.StartsWith("mms:") || text.StartsWith("MMS:"))
			{
				num2 = 4;
			}
			else
			{
				if (!text.StartsWith("smsto:") && !text.StartsWith("SMSTO:") && !text.StartsWith("mmsto:") && !text.StartsWith("MMSTO:"))
				{
					return null;
				}
				num2 = 6;
			}
			Hashtable hashtable = GClass608.smethod_10(text);
			string string_ = null;
			string text2 = null;
			bool flag = false;
			if (hashtable != null && hashtable.Count != 0)
			{
				string_ = (string)hashtable["subject"];
				text2 = (string)hashtable["body"];
				flag = true;
			}
			int num3 = text.IndexOf('?', num2);
			string text3 = (num3 >= 0 && flag) ? text.Substring(num2, num3 - num2) : text.Substring(num2);
			int num4 = text3.IndexOf(';');
			string text4;
			string string_2;
			if (num4 < 0)
			{
				text4 = text3;
				string_2 = null;
			}
			else
			{
				text4 = text3.Substring(0, num4);
				string text5 = text3.Substring(num4 + 1);
				string_2 = ((!text5.StartsWith("via=")) ? null : text5.Substring(4));
			}
			if (text2 == null)
			{
				int num5 = text4.IndexOf(':');
				if (num5 >= 0)
				{
					text2 = text4.Substring(num5 + 1);
					text4 = text4.Substring(0, num5);
				}
			}
			return new GClass629("sms:" + text4, text4, string_2, string_, text2, null);
		}
	}
}
