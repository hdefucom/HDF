using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	public class SystemDebugKeyValueItem
	{
		private string strKey = null;

		private string strValue = null;

		[XmlAttribute("Key")]
		public string Key
		{
			get
			{
				return strKey;
			}
			set
			{
				strKey = value;
			}
		}

		[XmlText]
		public string Value
		{
			get
			{
				return strValue;
			}
			set
			{
				strValue = value;
			}
		}
	}
}
