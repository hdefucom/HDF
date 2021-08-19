using System;

namespace ZYCommon
{
	public class Format_Double : StringDataFormatItem
	{
		public override string Name => "double";

		public override string DisplayName => "必须为实数";

		public override bool Test(string strValue)
		{
			try
			{
				Convert.ToDouble(strValue);
				return true;
			}
			catch
			{
			}
			return false;
		}
	}
}
