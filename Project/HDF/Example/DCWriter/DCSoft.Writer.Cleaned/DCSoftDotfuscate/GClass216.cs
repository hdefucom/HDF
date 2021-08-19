using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass216 : GClass163
	{
		private string string_0;

		public override string InnerText => string_0;

		public override string TagName => "#text";

		public override string vmethod_7()
		{
			return string_0;
		}

		public override void vmethod_8(string string_1)
		{
			string_0 = string_1;
		}

		public override bool Write(XmlWriter myWriter)
		{
			int num = 19;
			if (Class171.smethod_3(string_0))
			{
				string text = (!htmldocument_0.WriteOptions.bool_7) ? string_0.Trim() : string_0;
				if (htmldocument_0.WriteOptions.bool_5)
				{
					text = Class171.smethod_2(text);
				}
				bool flag = htmldocument_0.WriteOptions.bool_6 && (gclass164_0 == null || gclass164_0.vmethod_2().Count != 1);
				if (htmldocument_0.WriteOptions.bool_8)
				{
					string[] array = Class171.smethod_1(text, htmldocument_0.WriteOptions.string_0, htmldocument_0.WriteOptions.string_1);
					if (flag)
					{
						myWriter.WriteStartElement("SPAN");
					}
					for (int i = 0; i < array.Length; i++)
					{
						string text2 = array[i];
						if (text2 == null)
						{
							continue;
						}
						if (i % 2 == 1 && text2 != "")
						{
							if (text2.IndexOf("\r\n") >= 0)
							{
								text2 = text2.Replace("\r\n", "");
							}
							if (text2.StartsWith("num:"))
							{
								text2 = text2.Substring(4);
								myWriter.WriteStartElement("xsl:if");
								myWriter.WriteAttributeString("test", text2 + "!='0.0000'");
								myWriter.WriteStartElement("xsl:value-of");
								myWriter.WriteAttributeString("select", htmldocument_0.WriteOptions.method_4(text2));
								myWriter.WriteEndElement();
								myWriter.WriteEndElement();
							}
							else if (text2.StartsWith("%:"))
							{
								text2 = text2.Substring(2);
								myWriter.WriteStartElement("xsl:value-of");
								myWriter.WriteAttributeString("select", "format-number(" + htmldocument_0.WriteOptions.method_4(text2) + " , '0.00')");
								myWriter.WriteEndElement();
							}
							else if (text2.StartsWith("call:"))
							{
								text2 = text2.Substring(5);
								myWriter.WriteStartElement("xsl:call-template");
								myWriter.WriteAttributeString("name", text2);
								myWriter.WriteEndElement();
							}
							else
							{
								myWriter.WriteStartElement("xsl:value-of");
								myWriter.WriteAttributeString("select", htmldocument_0.WriteOptions.method_4(text2));
								myWriter.WriteEndElement();
							}
							continue;
						}
						int num2 = 0;
						int num3 = text2.IndexOf("&nbsp;");
						if (num3 >= 0)
						{
							while (num3 >= 0)
							{
								if (num3 > num2)
								{
									myWriter.WriteString(text2.Substring(num2, num3 - num2));
								}
								myWriter.WriteStartElement("xsl:text");
								myWriter.WriteAttributeString("disable-output-escaping", "yes");
								myWriter.WriteString("&nbsp;");
								myWriter.WriteEndElement();
								num2 = num3 + 6;
								num3 = text2.IndexOf("&nbsp;", num2);
							}
							if (num2 < text2.Length)
							{
								myWriter.WriteString(text2.Substring(num2));
							}
						}
						else
						{
							myWriter.WriteString(text2);
						}
					}
					if (flag)
					{
						myWriter.WriteEndElement();
					}
				}
				else if (flag)
				{
					myWriter.WriteElementString("SPAN", text);
				}
				else
				{
					myWriter.WriteString(text);
				}
			}
			return true;
		}

		internal override bool Read(Class171 myReader)
		{
			string_0 = myReader.method_34();
			return true;
		}
	}
}
