namespace ZYCommon
{
	public class Format_NoNull : StringDataFormatItem
	{
		public override string Name => "notnull";

		public override string DisplayName => "必须输入";

		public override bool CanEditSetting()
		{
			return false;
		}

		public override bool Test(string strValue)
		{
			return !StringCommon.isBlankString(strValue);
		}
	}
}
