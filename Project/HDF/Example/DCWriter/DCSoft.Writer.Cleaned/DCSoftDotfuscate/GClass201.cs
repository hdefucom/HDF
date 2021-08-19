using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass201 : GClass163
	{
		public override string TagName => "META";

		public string method_46()
		{
			return method_9("content");
		}

		public void method_47(string string_0)
		{
			method_11("content", string_0);
		}

		public string method_48()
		{
			return method_9("http-equiv");
		}

		public void method_49(string string_0)
		{
			method_11("http-equiv", string_0);
		}

		public string method_50()
		{
			return method_9("scheme");
		}

		public void method_51(string string_0)
		{
			method_11("scheme", string_0);
		}

		internal override bool Read(Class171 myReader)
		{
			int num = 17;
			if (base.Read(myReader))
			{
				if (method_13("charset"))
				{
					string text = method_9("charset");
					if (!string.IsNullOrEmpty(method_6().CharSet) && string.Compare(text, method_6().CharSet, ignoreCase: true) != 0)
					{
						method_6().CharSet = text;
						if (myReader.method_0())
						{
							throw new GException14(text);
						}
					}
				}
				if (method_13("content"))
				{
					NameValueCollection nameValueCollection = Class171.smethod_0(method_9("content"));
					foreach (string key in nameValueCollection.Keys)
					{
						if (string.Compare(key, "charset", ignoreCase: true) == 0)
						{
							string text3 = nameValueCollection[key];
							if (text3 != null)
							{
								text3 = text3.Trim();
								if (htmldocument_0.CharSet != null && string.Compare(text3, htmldocument_0.CharSet, ignoreCase: true) != 0)
								{
									htmldocument_0.CharSet = text3;
									if (myReader.method_0())
									{
										throw new GException14(text3);
									}
								}
							}
						}
					}
				}
				return true;
			}
			return false;
		}
	}
}
