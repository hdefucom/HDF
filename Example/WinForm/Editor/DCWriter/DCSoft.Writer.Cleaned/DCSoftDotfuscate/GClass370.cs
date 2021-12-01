using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass370
	{
		private static GClass370 gclass370_0 = null;

		private string string_0 = null;

		private string string_1 = null;

		private WebClient webClient_0 = new WebClient();

		private static readonly string string_2 = "袁永福到此一游";

		public static GClass370 smethod_0()
		{
			if (gclass370_0 == null)
			{
				gclass370_0 = new GClass370();
			}
			return gclass370_0;
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_3)
		{
			if (string_0 != string_3)
			{
				string_0 = string_3;
				string_1 = null;
			}
		}

		public string method_2()
		{
			int num = 8;
			if (string_1 == string_2)
			{
				return null;
			}
			if (string_1 == null)
			{
				try
				{
					string text = method_3().DownloadString(method_0());
					if (text != null && text.Length > 0)
					{
						XmlDocument xmlDocument = new XmlDocument();
						xmlDocument.LoadXml(text);
						XmlElement xmlElement = (XmlElement)xmlDocument.DocumentElement.SelectSingleNode("ReportUrl");
						if (xmlElement != null)
						{
							string_1 = xmlElement.InnerText;
						}
					}
				}
				catch (Exception)
				{
					string_1 = string_2;
				}
			}
			return string_1;
		}

		public WebClient method_3()
		{
			if (webClient_0 == null)
			{
				webClient_0 = new WebClient();
				webClient_0.Encoding = Encoding.UTF8;
			}
			return webClient_0;
		}

		public bool method_4(Dictionary<string, string> dictionary_0)
		{
			int num = 5;
			string text = method_2();
			if (text == null || text.Length > 0)
			{
				return false;
			}
			if (dictionary_0 == null || dictionary_0.Count == 0)
			{
				return false;
			}
			string data = method_5(dictionary_0, bool_0: false);
			method_3().UploadStringAsync(new Uri(text), "POST", data);
			return true;
		}

		public string method_5(Dictionary<string, string> dictionary_0, bool bool_0)
		{
			int num = 13;
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			if (bool_0)
			{
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.Indentation = 3;
				xmlTextWriter.IndentChar = ' ';
			}
			else
			{
				xmlTextWriter.Formatting = Formatting.None;
			}
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("DCClient");
			foreach (string key in dictionary_0.Keys)
			{
				xmlTextWriter.WriteStartElement("Value");
				xmlTextWriter.WriteAttributeString("Name", key);
				xmlTextWriter.WriteString(dictionary_0[key]);
				xmlTextWriter.WriteFullEndElement();
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Close();
			stringWriter.Close();
			return stringWriter.ToString();
		}
	}
}
