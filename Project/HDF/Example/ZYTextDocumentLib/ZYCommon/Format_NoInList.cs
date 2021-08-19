namespace ZYCommon
{
	public class Format_NoInList : Format_InList
	{
		public override string Name => "notinlist";

		public override string DisplayName => "不得出现[" + strSetting + "]中的任一个";

		public override bool Test(string strValue)
		{
			if (strSetting == null || strValue == null)
			{
				return true;
			}
			strValue = strValue.Trim();
			string[] items = GetItems(strSetting);
			if (items.Length > 0)
			{
				string[] array = items;
				foreach (string text in array)
				{
					if (strValue.Equals(text.Trim()))
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}
	}
}
