using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass214 : GClass163
	{
		protected XmlDocument xmlDocument_0 = new XmlDocument();

		protected string string_0 = null;

		protected string string_1 = null;

		public override string TagName => "XML";

		public string method_46()
		{
			return method_9("src");
		}

		public void method_47(string string_2)
		{
			method_11("src", string_2);
		}

		public XmlDocument method_48()
		{
			return xmlDocument_0;
		}

		public void method_49(XmlDocument xmlDocument_1)
		{
			xmlDocument_0 = xmlDocument_1;
		}

		public string method_50()
		{
			return string_0;
		}

		public void method_51(string string_2)
		{
			string_0 = string_2;
		}

		internal override bool vmethod_11(Class171 class171_0)
		{
			int num = 11;
			string_1 = null;
			string_0 = class171_0.method_32(TagName);
			try
			{
				xmlDocument_0.RemoveAll();
				XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument_0.NameTable);
				foreach (GClass229 item in htmldocument_0.method_8())
				{
					string text = item.string_0;
					if (text.ToLower().StartsWith("xmlns"))
					{
						int num2 = text.IndexOf(":");
						if (num2 > 0)
						{
							string prefix = text.Substring(num2 + 1);
							xmlNamespaceManager.AddNamespace(prefix, item.string_1);
						}
					}
				}
				XmlParserContext context = new XmlParserContext(xmlDocument_0.NameTable, xmlNamespaceManager, null, XmlSpace.None);
				XmlTextReader xmlTextReader = new XmlTextReader(string_0, XmlNodeType.Element, context);
				xmlDocument_0.Load(xmlTextReader);
				xmlTextReader.Close();
			}
			catch (Exception ex)
			{
				xmlDocument_0.RemoveAll();
				string_1 = "加载XML数据岛信息错误 - " + ex.Message;
			}
			return true;
		}

		protected override bool vmethod_12(XmlWriter xmlWriter_0)
		{
			if (xmlDocument_0.DocumentElement == null)
			{
				xmlWriter_0.WriteString(string_1);
			}
			else
			{
				xmlDocument_0.WriteContentTo(xmlWriter_0);
			}
			return true;
		}
	}
}
