using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass170 : GClass164, Interface0
	{
		protected GClass165 gclass165_0 = null;

		public string Name
		{
			get
			{
				return method_9("name");
			}
			set
			{
				method_11("name", value);
			}
		}

		public override string TagName => "SELECT";

		public GClass165 imethod_0()
		{
			return gclass165_0;
		}

		public void imethod_1(GClass165 gclass165_1)
		{
			gclass165_0 = gclass165_1;
		}

		public GClass228 method_50()
		{
			return gclass228_0;
		}

		public string method_51()
		{
			return method_9("xslsource");
		}

		public void method_52(string string_0)
		{
			method_11("xslsource", string_0);
		}

		public string method_53()
		{
			return method_9("valuexslsource");
		}

		public void method_54(string string_0)
		{
			method_11("valuexslsource", string_0);
		}

		public string method_55()
		{
			return method_9("textxslsource");
		}

		public void method_56(string string_0)
		{
			method_11("textxslsource", string_0);
		}

		public bool method_57()
		{
			return method_13("disabled");
		}

		public void method_58(bool bool_0)
		{
			int num = 9;
			if (bool_0)
			{
				method_11("disabled", "1");
			}
			else
			{
				method_12("disabled");
			}
		}

		public bool method_59()
		{
			return method_13("multiple");
		}

		public void method_60(bool bool_0)
		{
			int num = 4;
			if (bool_0)
			{
				method_11("multiple", "1");
			}
			else
			{
				method_12("multiple");
			}
		}

		public string method_61()
		{
			return method_9("size");
		}

		public void method_62(string string_0)
		{
			method_11("size", string_0);
		}

		public int method_63()
		{
			foreach (GClass209 item in gclass228_0)
			{
				if (item.method_46())
				{
					return gclass228_0.method_9(item);
				}
			}
			return -1;
		}

		public void method_64(int int_0)
		{
			foreach (GClass209 item in gclass228_0)
			{
				item.method_47(bool_0: false);
			}
			((GClass209)gclass228_0.method_4(int_0)).method_47(bool_0: true);
		}

		public override string vmethod_4()
		{
			foreach (GClass209 item in gclass228_0)
			{
				if (item.method_46())
				{
					return item.vmethod_4();
				}
			}
			return null;
		}

		public override void vmethod_5(string string_0)
		{
			foreach (GClass209 item in gclass228_0)
			{
				item.method_47(item.vmethod_4() == string_0);
			}
		}

		public override bool Write(XmlWriter myWriter)
		{
			int num = 11;
			if (htmldocument_0.WriteOptions.bool_2)
			{
				string text = htmldocument_0.WriteOptions.method_4(method_51());
				if (text != null && text.Length > 0)
				{
					string text2 = htmldocument_0.WriteOptions.method_4(method_53());
					string text3 = htmldocument_0.WriteOptions.method_4(method_55());
					if (text2 == null || text2.Length == 0)
					{
						text2 = "value";
					}
					if (text3 == null || text3.Length == 0)
					{
						text3 = "text";
					}
					myWriter.WriteStartElement(TagName);
					method_44(myWriter);
					myWriter.WriteStartElement("xsl:variable");
					myWriter.WriteAttributeString("name", "selectvalue");
					myWriter.WriteStartElement("xsl:value-of");
					myWriter.WriteAttributeString("select", Name);
					myWriter.WriteEndElement();
					myWriter.WriteEndElement();
					myWriter.WriteStartElement("xsl:for-each");
					myWriter.WriteAttributeString("select", text);
					myWriter.WriteStartElement("OPTION");
					myWriter.WriteStartElement("xsl:attribute");
					myWriter.WriteAttributeString("name", "value");
					myWriter.WriteStartElement("xsl:value-of");
					myWriter.WriteAttributeString("select", text2);
					myWriter.WriteEndElement();
					myWriter.WriteEndElement();
					myWriter.WriteStartElement("xsl:if");
					myWriter.WriteAttributeString("test", "$selectvalue=" + text2);
					myWriter.WriteStartElement("xsl:attribute");
					myWriter.WriteAttributeString("name", "selected");
					myWriter.WriteString("1");
					myWriter.WriteEndElement();
					myWriter.WriteEndElement();
					myWriter.WriteStartElement("xsl:value-of");
					myWriter.WriteAttributeString("select", text3);
					myWriter.WriteEndElement();
					myWriter.WriteEndElement();
					myWriter.WriteEndElement();
					myWriter.WriteEndElement();
					return true;
				}
				return base.Write(myWriter);
			}
			return base.Write(myWriter);
		}

		internal override bool CheckChildTagName(string strName)
		{
			return strName == "OPTION";
		}
	}
}
