using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass205 : GClass163
	{
		private string string_0;

		public override string TagName => "SCRIPT";

		public string method_46()
		{
			return method_9("defer");
		}

		public void method_47(string string_1)
		{
			method_11("defer", string_1);
		}

		public string method_48()
		{
			return method_9("event");
		}

		public void method_49(string string_1)
		{
			method_11("event", string_1);
		}

		public string method_50()
		{
			return method_9("for");
		}

		public void method_51(string string_1)
		{
			method_11("for", string_1);
		}

		public string method_52()
		{
			return method_9("language");
		}

		public void method_53(string string_1)
		{
			method_11("language", string_1);
		}

		public string method_54()
		{
			return method_9("src");
		}

		public void method_55(string string_1)
		{
			method_11("src", string_1);
		}

		public string method_56()
		{
			return method_9("type");
		}

		public void method_57(string string_1)
		{
			method_11("type", string_1);
		}

		public override string vmethod_7()
		{
			return string_0;
		}

		public override void vmethod_8(string string_1)
		{
			string_0 = string_1;
		}

		protected override bool vmethod_6()
		{
			return true;
		}

		internal override bool vmethod_11(Class171 class171_0)
		{
			int num = 9;
			string_0 = class171_0.method_32(TagName);
			if (string_0 != null)
			{
				int num2 = string_0.IndexOf("<!--");
				if (num2 >= 0)
				{
					string_0 = string_0.Substring(num2 + 4);
				}
				num2 = string_0.LastIndexOf("-->");
				if (num2 >= 0)
				{
					string_0 = string_0.Substring(0, num2);
				}
			}
			return true;
		}

		protected override bool vmethod_12(XmlWriter xmlWriter_0)
		{
			int num = 9;
			if (Class171.smethod_4(string_0))
			{
				xmlWriter_0.WriteString(" ");
			}
			else if (htmldocument_0.WriteOptions.bool_14)
			{
				string text = string_0.Replace("<![CDATA[", "");
				text = text.Replace("]]", "");
				xmlWriter_0.WriteString("//");
				xmlWriter_0.WriteCData(text + "//");
			}
			else
			{
				string text = string_0 + " ";
				if (text.IndexOf("--") >= 0)
				{
					text = "因保存需要,将所有的\"--\"转换为 \"@@\"符号\r\n" + text.Replace("--", "@@");
				}
				xmlWriter_0.WriteComment(text);
			}
			return true;
		}
	}
}
