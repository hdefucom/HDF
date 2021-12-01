using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass190 : GClass164
	{
		public override string TagName => "TR";

		internal override bool CheckChildTagName(string strName)
		{
			return strName == "TD";
		}

		public string method_50()
		{
			return method_9("xslsource");
		}

		public void method_51(string string_0)
		{
			method_11("xslsource", string_0);
		}

		public string method_52()
		{
			return method_9("align");
		}

		public void method_53(string string_0)
		{
			method_11("align", string_0);
		}

		public string method_54()
		{
			return method_9("bgcolor");
		}

		public void method_55(string string_0)
		{
			method_11("bgcolor", string_0);
		}

		public string method_56()
		{
			return method_9("bordercolor");
		}

		public void method_57(string string_0)
		{
			method_11("bordercolor", string_0);
		}

		public string method_58()
		{
			return method_9("valign");
		}

		public void method_59(string string_0)
		{
			method_11("valign", string_0);
		}

		internal override bool vmethod_21(Class171 class171_0, string string_0)
		{
			int num = 7;
			if (string_0 == "TABLE" || string_0 == "TBODY")
			{
				class171_0.method_20('<');
				return true;
			}
			return base.vmethod_21(class171_0, string_0);
		}

		public override bool Write(XmlWriter myWriter)
		{
			int num = 18;
			if (htmldocument_0.WriteOptions.bool_4)
			{
				string text = method_50();
				if (text != null && text.Length > 0)
				{
					myWriter.WriteStartElement("xsl:for-each");
					myWriter.WriteAttributeString("select", htmldocument_0.WriteOptions.method_4(text));
					bool result = base.Write(myWriter);
					myWriter.WriteEndElement();
					return result;
				}
				return base.Write(myWriter);
			}
			return base.Write(myWriter);
		}
	}
}
