using System;

namespace ZYCommon
{
	public class Format_Min : StringDataFormatItem
	{
		public override string Name => "min";

		public override string DisplayName => "最小不得小于" + strSetting;

		public override string SettingValue
		{
			get
			{
				return strSetting;
			}
			set
			{
				if (value == null)
				{
					strSetting = "0";
				}
				else
				{
					try
					{
						Convert.ToDouble(value);
						strSetting = value;
					}
					catch
					{
					}
				}
			}
		}

		public override bool CanEditSetting()
		{
			return true;
		}

		public override bool Test(string strValue)
		{
			return Convert.ToDouble(strValue) >= Convert.ToDouble(strSetting);
		}
	}
}
