using System;

namespace ZYCommon
{
	public class Format_Integer : StringDataFormatItem
	{
		public override string Name => "integer";

		public override string DisplayName => "必须为整数";

		public override bool Test(string strValue)
		{
			try
			{
				Convert.ToInt32(strValue);
				return true;
			}
			catch
			{
			}
			return false;
		}
	}
}
