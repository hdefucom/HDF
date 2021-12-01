using System.Xml;

namespace ZYCommon
{
	public class XMLCommon
	{
		public static string GetElementValue(XmlElement RootElement, string strName)
		{
			foreach (XmlNode childNode in RootElement.ChildNodes)
			{
				if (childNode.Name == strName)
				{
					return childNode.InnerText;
				}
			}
			return null;
		}

		public static bool SetElementValue(XmlElement RootElement, string strName, string strValue)
		{
			XmlElement xmlElement = null;
			foreach (XmlNode childNode in RootElement.ChildNodes)
			{
				if (childNode.Name == strName)
				{
					xmlElement = (XmlElement)childNode;
					break;
				}
			}
			if (xmlElement == null)
			{
				xmlElement = RootElement.OwnerDocument.CreateElement(strName);
				RootElement.AppendChild(xmlElement);
			}
			xmlElement.InnerText = strValue;
			return true;
		}

		public static void ClearChildNode(XmlNode myNode)
		{
			if (myNode != null)
			{
				while (myNode.FirstChild != null)
				{
					myNode.RemoveChild(myNode.FirstChild);
				}
			}
		}

		public static XmlNode GetXMLNodeByPath(XmlNode rootNode, string strPath)
		{
			if (strPath == null || rootNode == null)
			{
				return null;
			}
			int num = strPath.IndexOf(".");
			string text = null;
			if (num > 0)
			{
				text = strPath.Substring(0, num);
				strPath = strPath.Substring(num + 1);
			}
			else
			{
				text = strPath;
				strPath = null;
			}
			foreach (XmlNode childNode in rootNode.ChildNodes)
			{
				if (childNode.Name == text)
				{
					if (strPath == null)
					{
						return childNode;
					}
					return GetXMLNodeByPath(childNode, strPath);
				}
			}
			return null;
		}

		public static XmlElement GetElementByName(XmlElement rootNode, string strName, bool Deep)
		{
			if (rootNode == null || strName == null || strName.Trim().Length == 0)
			{
				return null;
			}
			strName = strName.Trim();
			foreach (XmlNode childNode in rootNode.ChildNodes)
			{
				if (childNode.Name == strName)
				{
					return (XmlElement)childNode;
				}
				if (Deep && childNode is XmlElement && childNode.ChildNodes.Count > 0)
				{
					XmlElement elementByName = GetElementByName((XmlElement)childNode, strName, Deep: true);
					if (elementByName != null)
					{
						return elementByName;
					}
				}
			}
			return null;
		}

		public static XmlElement CreateChildElement(XmlElement RootElement, string strName, bool bolCreate)
		{
			if (RootElement == null || strName == null || strName.Trim().Length == 0)
			{
				return null;
			}
			try
			{
				strName = strName.Trim();
				foreach (XmlNode childNode in RootElement.ChildNodes)
				{
					if (childNode.Name == strName)
					{
						return (XmlElement)childNode;
					}
				}
				if (bolCreate)
				{
					XmlElement xmlElement = RootElement.OwnerDocument.CreateElement(strName);
					RootElement.AppendChild(xmlElement);
					return xmlElement;
				}
			}
			catch
			{
			}
			return null;
		}

		public static XmlElement GetElementByAttribute(XmlElement rootElement, string strName, string strAttrName, string strAttrValue, bool bolCreate)
		{
			XmlElement xmlElement = null;
			if (rootElement == null || strName == null || strAttrName == null || strAttrValue == null)
			{
				return null;
			}
			foreach (XmlNode childNode in rootElement.ChildNodes)
			{
				xmlElement = (childNode as XmlElement);
				if (xmlElement != null && xmlElement.Name == strName && xmlElement.HasAttribute(strAttrName) && xmlElement.GetAttribute(strAttrName) == strAttrValue)
				{
					return xmlElement;
				}
			}
			if (bolCreate)
			{
				xmlElement = rootElement.OwnerDocument.CreateElement(strName);
				xmlElement.SetAttribute(strAttrName, strAttrValue);
				rootElement.AppendChild(xmlElement);
				return xmlElement;
			}
			return null;
		}
	}
}
