using DCSoft.Common;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass351
	{
		private StringWriter stringWriter_0 = null;

		private XmlTextWriter xmlTextWriter_0 = null;

		public GClass351(bool bool_0)
		{
			stringWriter_0 = new StringWriter();
			xmlTextWriter_0 = new XmlTextWriter(stringWriter_0);
			if (bool_0)
			{
				xmlTextWriter_0.Formatting = Formatting.Indented;
				xmlTextWriter_0.IndentChar = ' ';
				xmlTextWriter_0.Indentation = 1;
			}
		}

		public string method_0()
		{
			string xmlText = stringWriter_0.ToString();
			return XMLHelper.CleanupXMLHeader(xmlText);
		}

		public void method_1()
		{
			xmlTextWriter_0.WriteStartDocument();
		}

		public void method_2()
		{
			xmlTextWriter_0.WriteEndDocument();
		}

		public void method_3(string string_0)
		{
			xmlTextWriter_0.WriteStartElement(string_0);
		}

		public void method_4()
		{
			xmlTextWriter_0.WriteEndElement();
		}

		public void method_5(string string_0, string string_1)
		{
			xmlTextWriter_0.WriteElementString(string_0, string_1);
		}

		public void method_6(string string_0)
		{
			xmlTextWriter_0.WriteString(string_0);
		}

		public void method_7(string string_0, string string_1)
		{
			xmlTextWriter_0.WriteAttributeString(string_0, string_1);
		}
	}
}
