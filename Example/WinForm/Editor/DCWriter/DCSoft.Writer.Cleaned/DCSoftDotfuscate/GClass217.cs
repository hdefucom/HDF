using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass217 : GClass163, Interface0
	{
		private GClass165 gclass165_0 = null;

		private string string_0 = null;

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

		public override string InnerText => string_0;

		public override string TagName => "TEXTAREA";

		public GClass165 imethod_0()
		{
			return gclass165_0;
		}

		public void imethod_1(GClass165 gclass165_1)
		{
			gclass165_0 = gclass165_1;
		}

		public string method_46()
		{
			return method_9("rows");
		}

		public void method_47(string string_1)
		{
			method_11("rows", string_1);
		}

		public string method_48()
		{
			return method_9("cols");
		}

		public void method_49(string string_1)
		{
			method_11("cols", string_1);
		}

		public bool method_50()
		{
			return method_13("readonly");
		}

		public void method_51(bool bool_0)
		{
			int num = 10;
			if (bool_0)
			{
				method_11("readonly", "1");
			}
			else
			{
				method_12("readonly");
			}
		}

		public bool method_52()
		{
			return method_13("disabled");
		}

		public void method_53(bool bool_0)
		{
			int num = 6;
			if (bool_0)
			{
				method_11("disabled", "1");
			}
			else
			{
				method_12("disabled");
			}
		}

		public override string vmethod_4()
		{
			return string_0;
		}

		public override void vmethod_5(string string_1)
		{
			string_0 = string_1;
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
			string_0 = class171_0.method_32(TagName);
			return true;
		}

		protected override bool vmethod_12(XmlWriter xmlWriter_0)
		{
			int num = 12;
			if (htmldocument_0.WriteOptions.bool_11)
			{
				xmlWriter_0.WriteStartElement("xsl:value-of");
				xmlWriter_0.WriteAttributeString("xsl:value-of", Name);
				xmlWriter_0.WriteEndElement();
			}
			else
			{
				xmlWriter_0.WriteString(Class171.smethod_4(string_0) ? " " : string_0);
			}
			return true;
		}
	}
}
