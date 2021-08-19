using System;

namespace ZYCommon
{
	public class Format_MinLength : Format_MaxLength
	{
		public override string Name => "minlength";

		public override string DisplayName => "不得小于 " + strSetting + " 个字符";

		public override bool Test(string strValue)
		{
			if (strValue == null)
			{
				return true;
			}
			return strValue.Length >= Convert.ToInt32(strSetting);
		}
	}
}
