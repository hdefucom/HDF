using System;

namespace ZYCommon
{
	public class Format_Max : StringDataFormatItem
	{
		public override string Name => "max";

		public override string DisplayName => "最大不得超过" + strSetting;

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
					if (value == null)
					{
						strSetting = "0";
					}
					else
					{
						Convert.ToDouble(value);
						strSetting = value;
					}
				}
				catch
				{
				}
			}
		}

		public override bool CanEditSetting()
		{
			return true;
		}

		public override bool Test(string strValue)
		{
			return Convert.ToDouble(strValue) <= Convert.ToDouble(strSetting);
		}
	}
}
