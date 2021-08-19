using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass209 : GClass163
	{
		private string string_0;

		public override string TagName => "OPTION";

		protected override bool vmethod_6()
		{
			return true;
		}

		public override string vmethod_7()
		{
			return (string_0 == null) ? "" : string_0;
		}

		public override void vmethod_8(string string_1)
		{
			string_0 = string_1;
		}

		public override string vmethod_4()
		{
			return method_9("value");
		}

		public override void vmethod_5(string string_1)
		{
			method_11("value", string_1);
		}

		public bool method_46()
		{
			return method_13("selected");
		}

		public void method_47(bool bool_0)
		{
			method_15("selected", bool_0);
		}

		public override bool Write(XmlWriter myWriter)
		{
			int num = 12;
			if (htmldocument_0.WriteOptions.bool_10)
			{
				GClass170 gClass = (GClass170)gclass164_0;
				method_12("selected");
				myWriter.WriteStartElement(TagName);
				method_44(myWriter);
				myWriter.WriteStartElement("xsl:if");
				myWriter.WriteAttributeString("test", gClass.Name + "='" + vmethod_4() + "'");
				myWriter.WriteStartElement("xsl:attribute");
				myWriter.WriteAttributeString("name", "selected");
				myWriter.WriteString("1");
				myWriter.WriteEndElement();
				myWriter.WriteEndElement();
				myWriter.WriteElementString("xsl:text", string_0);
				myWriter.WriteEndElement();
				return true;
			}
			return base.Write(myWriter);
		}
	}
}
