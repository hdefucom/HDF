using System.Xml;

namespace ZYCommon
{
	public abstract class StringDataFormatItem
	{
		protected string strSetting = null;

		public virtual string Name => null;

		public virtual string DisplayName => null;

		public virtual string SettingValue
		{
			get
			{
				return strSetting;
			}
			set
			{
				strSetting = value;
			}
		}

		public static StringDataFormatItem Create(string vName)
		{
			switch (vName)
			{
			case "min":
				return new Format_Min();
			case "max":
				return new Format_Max();
			case "integer":
				return new Format_Integer();
			case "double":
				return new Format_Double();
			case "notnull":
				return new Format_NoNull();
			case "inlist":
				return new Format_InList();
			case "notinlist":
				return new Format_NoInList();
			case "date":
				return new Format_Date();
			case "minlength":
				return new Format_MinLength();
			case "maxlength":
				return new Format_MaxLength();
			default:
				return null;
			}
		}

		public virtual bool Test(string strValue)
		{
			return false;
		}

		public virtual bool FromXML(XmlElement myElement)
		{
			strSetting = myElement.GetAttribute("setting");
			return true;
		}

		public virtual bool ToXML(XmlElement myElement)
		{
			if (myElement != null && strSetting != null)
			{
				myElement.SetAttribute("setting", strSetting);
			}
			return true;
		}

		public virtual bool CanEditSetting()
		{
			return false;
		}
	}
}
