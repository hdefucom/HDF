using System;

namespace ZYCommon
{
	public class Format_Date : StringDataFormatItem
	{
		public override string Name => "date";

		public override string DisplayName => "必须为表示时间";

		public override bool Test(string strValue)
		{
			try
			{
				Convert.ToDateTime(strValue);
				return true;
			}
			catch
			{
			}
			return false;
		}
	}
}
