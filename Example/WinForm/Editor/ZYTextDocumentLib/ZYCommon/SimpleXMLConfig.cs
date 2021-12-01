using System.IO;
using System.Xml;

namespace ZYCommon
{
	public class SimpleXMLConfig : XmlDocument
	{
		private string strFileName = null;

		public string FileName
		{
			get
			{
				return strFileName;
			}
			set
			{
				strFileName = value;
			}
		}

		public new bool Load(string filename)
		{
			try
			{
				strFileName = filename;
				base.Load(filename);
				return true;
			}
			catch
			{
			}
			return false;
		}

		public void Save()
		{
			if (strFileName != null)
			{
				if (File.Exists(strFileName))
				{
					File.SetAttributes(strFileName, FileAttributes.Normal);
				}
				base.Save(strFileName);
			}
		}

		public string GetSetting(string strName)
		{
			return (SelectSingleNode("*/setting[@name='" + strName + "']") as XmlElement)?.InnerText;
		}

		public void SetSetting(string strName, string strValue)
		{
			XmlElement xmlElement = SelectSingleNode("*/setting[@name='" + strName + "']") as XmlElement;
			if (xmlElement == null)
			{
				if (base.DocumentElement == null)
				{
					base.AppendChild(CreateElement("xmlconfig"));
				}
				bool flag = false;
				foreach (XmlNode childNode in base.DocumentElement.ChildNodes)
				{
					if (childNode.Name == "setting")
					{
						xmlElement = (childNode as XmlElement);
						if (xmlElement.GetAttribute("name") == strName)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					xmlElement = CreateElement("setting");
					xmlElement.SetAttribute("name", strName);
					base.DocumentElement.AppendChild(xmlElement);
				}
			}
			xmlElement.InnerText = strValue;
		}
	}
}
