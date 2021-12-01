using System.Text;

namespace ZYCommon
{
	public class Format_InList : StringDataFormatItem
	{
		public override string Name => "inlist";

		public override string DisplayName => "必须在[" + strSetting + "]中选一个";

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
					strSetting = "";
					return;
				}
				string[] items = GetItems(value);
				StringBuilder stringBuilder = new StringBuilder();
				string[] array = items;
				foreach (string text in array)
				{
					if (text.Trim().Length > 0)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(text.Trim());
					}
				}
				strSetting = stringBuilder.ToString();
			}
		}

		public override bool CanEditSetting()
		{
			return true;
		}

		protected string[] GetItems(string strValue)
		{
			return strValue.Split(",;，；、".ToCharArray());
		}

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
