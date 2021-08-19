using System.Collections;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class ZYUserList
	{
		public const string c_ItemXMLName = "user";

		public const string c_RootXMLName = "users";

		public const string c_Name = "name";

		private ArrayList myList = new ArrayList();

		private int intCurrentIndex = 0;

		public string CurrentName
		{
			get
			{
				return GetName(intCurrentIndex);
			}
			set
			{
				intCurrentIndex = IndexOf(value);
				if (intCurrentIndex < 0)
				{
					Add(value);
				}
				intCurrentIndex = IndexOf(value);
			}
		}

		public int CurrentIndex
		{
			get
			{
				return intCurrentIndex;
			}
			set
			{
				intCurrentIndex = value;
				if (intCurrentIndex < 0)
				{
					intCurrentIndex = 0;
				}
				if (intCurrentIndex > myList.Count - 1)
				{
					intCurrentIndex = myList.Count - 1;
				}
			}
		}

		public int Count => myList.Count;

		public string[] GetUserNames()
		{
			string[] array = new string[myList.Count];
			for (int i = 0; i < myList.Count; i++)
			{
				array[i] = (string)myList[i];
			}
			return array;
		}

		public void Clear()
		{
			myList.Clear();
		}

		public bool Add(string strName)
		{
			if (strName == null || strName.Trim().Length == 0)
			{
				return false;
			}
			strName = strName.Trim();
			foreach (string my in myList)
			{
				if (my == strName)
				{
					return false;
				}
			}
			myList.Add(strName);
			return true;
		}

		public bool Contains(string strName)
		{
			if (strName == null || strName.Trim().Length == 0)
			{
				return false;
			}
			strName = strName.Trim();
			foreach (string my in myList)
			{
				if (my == strName)
				{
					return true;
				}
			}
			return false;
		}

		public string GetName(int index)
		{
			if (index >= 0 && index < myList.Count)
			{
				return (string)myList[index];
			}
			return null;
		}

		public int IndexOf(string strName)
		{
			foreach (string my in myList)
			{
				if (my == strName)
				{
					return myList.IndexOf(my);
				}
			}
			return -1;
		}

		public int FromXML(XmlElement RootElement)
		{
			int num = 0;
			if (RootElement != null)
			{
				foreach (XmlNode childNode in RootElement.ChildNodes)
				{
					if (childNode.Name == "user" && Add((childNode as XmlElement).GetAttribute("name")))
					{
						num++;
					}
				}
				intCurrentIndex = 0;
			}
			return num;
		}

		public void ToXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				foreach (string my in myList)
				{
					XmlElement xmlElement = RootElement.OwnerDocument.CreateElement("user");
					RootElement.AppendChild(xmlElement);
					xmlElement.SetAttribute("name", my);
				}
			}
		}
	}
}
