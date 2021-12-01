using System.Collections;
using System.Text;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class UnderWriteMarkCollection : IXMLSerializable, IEnumerable
	{
		private class myEnumerator : IEnumerator
		{
			private ArrayList myList;

			private int index;

			public object Current => (UnderWriteMark)myList[index];

			public myEnumerator(ArrayList lst)
			{
				myList = lst;
				index = -1;
			}

			public void Reset()
			{
				index = -1;
			}

			public bool MoveNext()
			{
				index++;
				return index < myList.Count;
			}
		}

		public ZYTextDocument OwnerDocument;

		public ZYTextElement OwnerElement;

		public bool Enable = true;

		private ArrayList myItems = new ArrayList();

		public UnderWriteMark NewMark = null;

		public int Count => myItems.Count;

		public UnderWriteMark this[int index] => (UnderWriteMark)myItems[index];

		public UnderWriteMark LastMark => (UnderWriteMark)myItems[myItems.Count - 1];

		public string LastSenior
		{
			get
			{
				if (myItems.Count > 0)
				{
					return ((UnderWriteMark)myItems[myItems.Count - 1]).Senior;
				}
				return null;
			}
		}

		public bool IndexAvailable(int Index)
		{
			return Index >= 0 && Index < myItems.Count;
		}

		public bool CanMark(string strUserName)
		{
			if (myItems.Count > 0)
			{
				string lastSenior = LastSenior;
				if (lastSenior == null || lastSenior.Length == 0)
				{
					return true;
				}
				return lastSenior == strUserName;
			}
			return true;
		}

		public UnderWriteMark AddMark(string strUserName, string strSenior)
		{
			if (myItems.Count > 0)
			{
				string lastSenior = LastSenior;
				if (lastSenior != null && lastSenior.Length > 0 && lastSenior != strUserName)
				{
					return null;
				}
			}
			NewMark = new UnderWriteMark();
			NewMark.UserName = strUserName;
			NewMark.Senior = strSenior;
			NewMark.MarkTime = ZYTime.GetServerTime();
			myItems.Add(NewMark);
			if (OwnerDocument != null)
			{
				NewMark.SaveLogIndex = OwnerDocument.SaveLogs.CurrentIndex;
				OwnerDocument.UpdateUserName();
			}
			return NewMark;
		}

		public void Clear()
		{
			myItems.Clear();
		}

		public string[] ToStringArray()
		{
			string[] array = new string[myItems.Count];
			for (int i = 0; i < myItems.Count; i++)
			{
				UnderWriteMark underWriteMark = (UnderWriteMark)myItems[i];
				array[i] = underWriteMark.DisplayText();
			}
			return array;
		}

		public string[] GetUserNameStringArray()
		{
			string[] array = new string[myItems.Count];
			for (int i = 0; i < myItems.Count; i++)
			{
				UnderWriteMark underWriteMark = (UnderWriteMark)myItems[i];
				array[i] = underWriteMark.UserName;
			}
			return array;
		}

		public string GetDisplayText()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (UnderWriteMark myItem in myItems)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append("\r\n");
				}
				stringBuilder.Append(myItem.UserName);
				stringBuilder.Append(" 签名于 ");
				stringBuilder.Append(myItem.MarkTime.ToString("yyyy年MM月dd日 HH:mm:ss"));
			}
			if (myItems.Count > 0 && !StringCommon.isBlankString(LastMark.Senior))
			{
				stringBuilder.Append("\r\n 本区域指定由[ " + LastMark.Senior + " ]签名");
			}
			return stringBuilder.ToString();
		}

		public string GetXMLName()
		{
			return "underwritemarks";
		}

		public bool FromXML(XmlElement RootElement)
		{
			Clear();
			if (RootElement != null)
			{
				foreach (XmlNode childNode in RootElement.ChildNodes)
				{
					if (childNode is XmlElement)
					{
						UnderWriteMark underWriteMark = new UnderWriteMark();
						underWriteMark.FromXML(childNode as XmlElement);
						myItems.Add(underWriteMark);
					}
				}
				return true;
			}
			return false;
		}

		public bool ToXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				foreach (UnderWriteMark myItem in myItems)
				{
					XmlElement xmlElement = RootElement.OwnerDocument.CreateElement(myItem.GetXMLName());
					RootElement.AppendChild(xmlElement);
					myItem.ToXML(xmlElement);
				}
				return true;
			}
			return false;
		}

		public IEnumerator GetEnumerator()
		{
			return new myEnumerator(myItems);
		}
	}
}
