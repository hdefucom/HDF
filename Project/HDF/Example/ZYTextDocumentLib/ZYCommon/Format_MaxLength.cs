using System;

namespace ZYCommon
{
	public class Format_MaxLength : StringDataFormatItem
	{
		public override string Name => "maxlength";

		public override string DisplayName => "不得超过 " + strSetting + " 个字符";

		public override string SettingValue
		{
			get
			{
				return strSetting;
			}
			set
			{
				try
				{
					Convert.ToInt32(value);
					strSetting = value;
				}
				catch
				{
				}
			}
		}

		public override bool Test(string strValue)
		{
			if (strValue != null)
			{
				return strValue.Length <= Convert.ToInt32(strSetting);
			}
			return true;
		}

		public override bool CanEditSetting()
		{
			return true;
		}
	}
}
