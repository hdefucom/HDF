using System.Collections;
using System.Xml;

namespace ZYCommon
{
	public class StringDataFormat
	{
		private ArrayList myItems = new ArrayList();

		private string strLastTestResult = null;

		public string LastTestResult => strLastTestResult;

		public ArrayList Items => myItems;

		public StringDataFormatItem this[int index] => (StringDataFormatItem)myItems[index];

		public bool HasItem()
		{
			return myItems != null && myItems.Count > 0;
		}

		public void Clear()
		{
			myItems.Clear();
		}

		public StringDataFormatItem NewItem(string strName)
		{
			StringDataFormatItem stringDataFormatItem = StringDataFormatItem.Create(strName);
			if (stringDataFormatItem != null)
			{
				myItems.Add(stringDataFormatItem);
			}
			return stringDataFormatItem;
		}

		public bool Test(string strValue)
		{
			strLastTestResult = null;
			if (!HasItem())
			{
				return true;
			}
			try
			{
				foreach (StringDataFormatItem myItem in myItems)
				{
					if (!myItem.Test(strValue))
					{
						strLastTestResult = myItem.DisplayName;
						return false;
					}
				}
				return true;
			}
			catch
			{
			}
			return false;
		}

		public bool FromXML(XmlElement myElement)
		{
			myItems.Clear();
			if (myElement != null)
			{
				foreach (XmlNode childNode in myElement.ChildNodes)
				{
					if (childNode is XmlElement)
					{
						StringDataFormatItem stringDataFormatItem = StringDataFormatItem.Create(childNode.Name);
						if (stringDataFormatItem != null)
						{
							myItems.Add(stringDataFormatItem);
							stringDataFormatItem.FromXML(childNode as XmlElement);
						}
					}
				}
				return true;
			}
			return false;
		}

		public bool ToXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				foreach (StringDataFormatItem myItem in myItems)
				{
					if (myItem.Name != null)
					{
						XmlElement xmlElement = myElement.OwnerDocument.CreateElement(myItem.Name);
						myElement.AppendChild(xmlElement);
						myItem.ToXML(xmlElement);
					}
				}
				return true;
			}
			return false;
		}
	}
}
