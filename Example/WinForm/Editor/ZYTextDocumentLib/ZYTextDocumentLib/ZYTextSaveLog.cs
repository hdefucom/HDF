using System;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextSaveLog
	{
		public bool Lock = false;

		public int Level = 0;

		private ZYTextDocument myOwnerDocument = null;

		private string strUserName = null;

		private DateTime dtSaveDateTime = ZYTime.GetServerTime();

		public ZYTextDocument OwnerDocument
		{
			get
			{
				return myOwnerDocument;
			}
			set
			{
				myOwnerDocument = value;
			}
		}

		public string UserName
		{
			get
			{
				return strUserName;
			}
			set
			{
				strUserName = value;
			}
		}

		public DateTime SaveDateTime
		{
			get
			{
				return dtSaveDateTime;
			}
			set
			{
				dtSaveDateTime = value;
			}
		}

		public string DisplayDateTime => dtSaveDateTime.ToString("yyyy年MM月dd日 HH:mm");

		public string DisplayText()
		{
			if (strUserName != null && strUserName.Length > 0)
			{
				return strUserName + " 保存于" + dtSaveDateTime.ToString("yyyy年MM月dd日 HH:mm");
			}
			return "";
		}

		public string GetXMLName()
		{
			return "savelog";
		}

		public bool ToXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				myElement.SetAttribute("name", strUserName);
				myElement.SetAttribute("time", dtSaveDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
				myElement.SetAttribute("level", Level.ToString());
				if (Lock)
				{
					myElement.SetAttribute("lock", "1");
				}
				return true;
			}
			return false;
		}

		public bool FromXML(XmlElement myElement)
		{
			if (myElement != null)
			{
				strUserName = myElement.GetAttribute("name");
				dtSaveDateTime = StringCommon.ConvertToDateTime(myElement.GetAttribute("time"), null, ZYTime.GetServerTime());
				Lock = myElement.HasAttribute("lock");
				Level = StringCommon.ToInt32Value(myElement.GetAttribute("level"), 0);
				return true;
			}
			return false;
		}
	}
}
