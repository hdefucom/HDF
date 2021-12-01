using System.Xml;

namespace ZYCommon
{
	public class DBXMLConfig
	{
		private XmlDocument myXMLDoc;

		private string strCurrentSection;

		public string CurrentSection
		{
			get
			{
				return strCurrentSection;
			}
			set
			{
				strCurrentSection = value;
			}
		}

		public DBXMLConfig()
		{
			myXMLDoc = new XmlDocument();
			strCurrentSection = "System";
		}

		public XmlDocument GetInnerXMLDoc()
		{
			return myXMLDoc;
		}

		public void Load(string strURL)
		{
			myXMLDoc.Load(strURL);
		}

		public void LoadXML(string strXML)
		{
			myXMLDoc.LoadXml(strXML);
		}

		public string GetXML()
		{
			if (myXMLDoc.DocumentElement == null)
			{
				return null;
			}
			return myXMLDoc.DocumentElement.OuterXml;
		}

		public void Save(string strURL)
		{
			myXMLDoc.Save(strURL);
		}

		public string GetSystemSetting(string strKey)
		{
			return GetSettingEx("system", strKey);
		}

		public void SaveSystemSetting(string strKey, string strValue)
		{
			SaveSettingEx("system", strKey, strValue);
		}

		public string GetSetting(string strKey)
		{
			return GetSettingEx(strCurrentSection, strKey);
		}

		public void SaveSetting(string strKey, string strValue)
		{
			SaveSettingEx(strCurrentSection, strKey, strValue);
		}

		public string GetSettingEx(string strSection, string strKey)
		{
			XmlElement xmlElement = (XmlElement)myXMLDoc.SelectSingleNode("//setting[@sectionname='" + strSection + "' and @keyname='" + strKey + "']");
			if (xmlElement != null)
			{
				return xmlElement.InnerText;
			}
			return "";
		}

		public void SaveSettingEx(string strSection, string strKey, string strValue)
		{
			XmlElement xmlElement = (XmlElement)myXMLDoc.SelectSingleNode("//setting[@sectionname='" + strSection + "' and @keyname='" + strKey + "']");
			if (xmlElement == null)
			{
				if (myXMLDoc.DocumentElement == null)
				{
					myXMLDoc.LoadXml("<dbxmlsetting />");
				}
				xmlElement = myXMLDoc.CreateElement("setting");
				xmlElement.SetAttribute("sectionname", strSection);
				xmlElement.SetAttribute("keyname", strKey);
				myXMLDoc.DocumentElement.AppendChild(xmlElement);
			}
			xmlElement.InnerText = strValue;
		}
	}
}
