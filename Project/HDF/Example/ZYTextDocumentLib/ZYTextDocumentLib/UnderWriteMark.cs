using System;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class UnderWriteMark : IXMLSerializable
	{
		public string UserName;

		public DateTime MarkTime;

		public int SaveLogIndex;

		public string Senior;

		public string DisplayText()
		{
			return UserName + " 签名于" + MarkTime.ToString("yyyy年MM月dd日 HH:mm");
		}

		public string GetXMLName()
		{
			return "underwritemark";
		}

		public bool FromXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				UserName = RootElement.GetAttribute("username");
				MarkTime = StringCommon.ConvertToDateTime(RootElement.GetAttribute("marktime"), null, ZYTime.GetServerTime());
				Senior = RootElement.GetAttribute("senior");
				SaveLogIndex = StringCommon.ToInt32Value(RootElement.GetAttribute("savelog"), 0);
				return true;
			}
			return false;
		}

		public bool ToXML(XmlElement RootElement)
		{
			if (RootElement != null)
			{
				RootElement.SetAttribute("username", UserName);
				RootElement.SetAttribute("marktime", MarkTime.ToString("yyyy-MM-dd HH:mm:ss"));
				RootElement.SetAttribute("senior", Senior);
				RootElement.SetAttribute("savelog", SaveLogIndex.ToString());
				return true;
			}
			return false;
		}
	}
}
