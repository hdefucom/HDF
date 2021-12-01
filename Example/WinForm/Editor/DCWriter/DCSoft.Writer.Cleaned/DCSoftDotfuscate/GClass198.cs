using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass198 : GClass163, Interface0
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

		public override string InnerText
		{
			get
			{
				string a = vmethod_13();
				if (a == "text")
				{
					return vmethod_4();
				}
				return null;
			}
		}

		public override string TagName => "INPUT";

		public GClass165 imethod_0()
		{
			return gclass165_0;
		}

		public void imethod_1(GClass165 gclass165_1)
		{
			gclass165_0 = gclass165_1;
		}

		public virtual string vmethod_13()
		{
			return method_9("type");
		}

		public virtual void vmethod_14(string string_0)
		{
			method_11("type", string_0);
		}

		public override string vmethod_4()
		{
			return method_9("value");
		}

		public override void vmethod_5(string string_0)
		{
			method_11("value", string_0);
		}

		public bool method_46()
		{
			return method_14("disabled");
		}

		public void method_47(bool bool_0)
		{
			method_15("disabled", bool_0);
		}

		public string method_48()
		{
			return method_9("size");
		}

		public void method_49(string string_0)
		{
			method_11("size", string_0);
		}

		public string method_50()
		{
			return method_9("src");
		}

		public void method_51(string string_0)
		{
			method_11("src", string_0);
		}

		public bool method_52()
		{
			return method_14("checked");
		}

		public void method_53(bool bool_0)
		{
			method_15("checked", bool_0);
		}

		public override bool Write(XmlWriter myWriter)
		{
			int num = 7;
			string a = vmethod_13();
			if (a != "checkbox" && a != "radio")
			{
				method_12("checked");
			}
			if (a != "image")
			{
				method_12("src");
			}
			if (htmldocument_0.WriteOptions.bool_1)
			{
				if (a == "text" || a == "hidden")
				{
					method_12("value");
				}
				else if (a == "radio" || a == "checkbox")
				{
					method_12("checked");
				}
			}
			return base.Write(myWriter);
		}

		protected override bool vmethod_12(XmlWriter xmlWriter_0)
		{
			int num = 13;
			if (htmldocument_0.WriteOptions.bool_1)
			{
				string a = vmethod_13();
				if (a == "text" || a == "hidden")
				{
					xmlWriter_0.WriteStartElement("xsl:attribute");
					xmlWriter_0.WriteAttributeString("name", "value");
					xmlWriter_0.WriteStartElement("xsl:value-of");
					xmlWriter_0.WriteAttributeString("select", Name);
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteEndElement();
				}
				else if (a == "radio" || a == "checkbox")
				{
					xmlWriter_0.WriteStartElement("xsl:if");
					xmlWriter_0.WriteAttributeString("test", Name + "='" + vmethod_4() + "'");
					xmlWriter_0.WriteStartElement("xsl:attribute");
					xmlWriter_0.WriteAttributeString("name", "checked");
					xmlWriter_0.WriteString("1");
					xmlWriter_0.WriteEndElement();
					xmlWriter_0.WriteEndElement();
				}
			}
			return true;
		}
	}
}
