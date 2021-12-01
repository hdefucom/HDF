using System;
using System.Collections;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextSaveLogCollection : CollectionBase
	{
		private ZYTextDocument myOwnerDocument = null;

		private ZYTextSaveLog myCurrentSaveLog = new ZYTextSaveLog();

		public int CurrentIndex => base.Count - 1;

		public ZYTextSaveLog CurrentSaveLog
		{
			get
			{
				return myCurrentSaveLog;
			}
			set
			{
				myCurrentSaveLog = value;
			}
		}

		public string CurrentUserName
		{
			get
			{
				return myCurrentSaveLog.UserName;
			}
			set
			{
				myCurrentSaveLog.UserName = value;
				if (myOwnerDocument != null && myOwnerDocument.DocumentElement != null)
				{
					myOwnerDocument.UpdateUserName();
				}
			}
		}

		public ZYTextDocument OwnerDocument
		{
			get
			{
				return myOwnerDocument;
			}
			set
			{
				myOwnerDocument = value;
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ZYTextSaveLog zYTextSaveLog = (ZYTextSaveLog)enumerator.Current;
						zYTextSaveLog.OwnerDocument = myOwnerDocument;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				myCurrentSaveLog.OwnerDocument = myOwnerDocument;
			}
		}

		public ZYTextSaveLog this[int index] => (ZYTextSaveLog)base.List[index];

		public ZYTextSaveLogCollection()
		{
			base.List.Add(myCurrentSaveLog);
		}

		public bool IndexAvailable(int Index)
		{
			return Index >= 0 && Index < base.Count;
		}

		public int GetMaxLockLevel()
		{
			int num = -1;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYTextSaveLog zYTextSaveLog = (ZYTextSaveLog)enumerator.Current;
					if (zYTextSaveLog.Lock && num < zYTextSaveLog.Level)
					{
						num = zYTextSaveLog.Level;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return num;
		}

		public void Mark()
		{
			myCurrentSaveLog.Lock = true;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYTextSaveLog zYTextSaveLog = (ZYTextSaveLog)enumerator.Current;
					if (zYTextSaveLog != myCurrentSaveLog && zYTextSaveLog.UserName == myCurrentSaveLog.UserName)
					{
						zYTextSaveLog.Lock = true;
						zYTextSaveLog.Level = myCurrentSaveLog.Level;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public ZYTextSaveLog SafeGet(int index)
		{
			if (index >= 0 && index < base.Count)
			{
				return (ZYTextSaveLog)base.List[index];
			}
			return null;
		}

		public string GetXMLName()
		{
			return "savelogs";
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
						ZYTextSaveLog zYTextSaveLog = new ZYTextSaveLog();
						zYTextSaveLog.FromXML(childNode as XmlElement);
						zYTextSaveLog.OwnerDocument = myOwnerDocument;
						base.List.Add(zYTextSaveLog);
					}
				}
				base.List.Add(myCurrentSaveLog);
				return true;
			}
			base.List.Add(myCurrentSaveLog);
			return false;
		}

		public bool ToXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				myCurrentSaveLog.SaveDateTime = ZYTime.GetServerTime();
				{
					IEnumerator enumerator = GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							ZYTextSaveLog zYTextSaveLog = (ZYTextSaveLog)enumerator.Current;
							XmlElement xmlElement = RootElement.OwnerDocument.CreateElement(zYTextSaveLog.GetXMLName());
							RootElement.AppendChild(xmlElement);
							zYTextSaveLog.ToXML(xmlElement);
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				return true;
			}
			return false;
		}

		public string[] ToStringArray()
		{
			string[] array = new string[base.Count];
			int num = 0;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ZYTextSaveLog zYTextSaveLog = (ZYTextSaveLog)enumerator.Current;
					array[num] = zYTextSaveLog.DisplayText();
					num++;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return array;
		}
	}
}
