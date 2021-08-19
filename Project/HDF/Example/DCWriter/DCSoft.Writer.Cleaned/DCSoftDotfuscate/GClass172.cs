using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass172 : GClass164
	{
		public override string TagName => "TD";

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
			return method_9("background");
		}

		public void method_55(string string_0)
		{
			method_11("background", string_0);
		}

		public string method_56()
		{
			return method_9("bgcolor");
		}

		public void method_57(string string_0)
		{
			method_11("bgcolor", string_0);
		}

		public string method_58()
		{
			return method_9("bordercolor");
		}

		public void method_59(string string_0)
		{
			method_11("bordercolor", string_0);
		}

		public string method_60()
		{
			return method_9("colspan");
		}

		public void method_61(string string_0)
		{
			method_11("colspan", string_0);
		}

		public string method_62()
		{
			return method_9("nowrap");
		}

		public void method_63(string string_0)
		{
			method_11("nowrap", string_0);
		}

		public string method_64()
		{
			return method_9("rowspan");
		}

		public void method_65(string string_0)
		{
			method_11("rowspan", string_0);
		}

		public string method_66()
		{
			return method_9("height");
		}

		public void method_67(string string_0)
		{
			method_11("height", string_0);
		}

		public string method_68()
		{
			return method_9("valign");
		}

		public void method_69(string string_0)
		{
			method_11("valign", string_0);
		}

		public string method_70()
		{
			return method_9("width");
		}

		public void method_71(string string_0)
		{
			method_11("width", string_0);
		}

		public override bool Write(XmlWriter myWriter)
		{
			int num = 13;
			if (htmldocument_0.WriteOptions.bool_3)
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

		internal override bool vmethod_21(Class171 class171_0, string string_0)
		{
			int num = 13;
			if (string_0 == "TR" || string_0 == "TABLE" || string_0 == "TBODY")
			{
				class171_0.method_20('<');
				return true;
			}
			return base.vmethod_21(class171_0, string_0);
		}
	}
}
