using System.Text;

namespace ZYCommon
{
	public class NameValueList
	{
		private string[] strNames = new string[16];

		private string[] strValues = new string[16];

		private int iItemCount = 0;

		public string this[int index] => strValues[index];

		public string this[string strName] => GetValue(strName);

		public int Count => iItemCount;

		public void Clear()
		{
			iItemCount = 0;
		}

		public bool Contains(string strName)
		{
			for (int i = 0; i < iItemCount && strNames[i] != null; i++)
			{
				if (strNames[i].Equals(strName))
				{
					return true;
				}
			}
			return false;
		}

		public int IndexOf(string strName)
		{
			if (strName != null)
			{
				for (int i = 0; i < iItemCount && strNames[i] != null; i++)
				{
					if (strName.Equals(strNames[i]))
					{
						return i;
					}
				}
			}
			return -1;
		}

		public string GetName(int index)
		{
			if (index >= 0 && index < iItemCount)
			{
				return strNames[index];
			}
			return null;
		}

		public string GetValue(int index)
		{
			if (index >= 0 && index < iItemCount)
			{
				return strValues[index];
			}
			return null;
		}

		public string GetValue(string strName)
		{
			return GetValue(IndexOf(strName));
		}

		public void SetValue(string strName, string strValue)
		{
			if (strName == null)
			{
				return;
			}
			int num = IndexOf(strName);
			if (num >= 0)
			{
				strValues[num] = strValue;
				return;
			}
			if (iItemCount >= strNames.Length - 1)
			{
				string[] array = new string[(int)((double)strNames.Length * 1.5)];
				string[] array2 = new string[array.Length];
				for (int i = 0; i < iItemCount; i++)
				{
					array[i] = strNames[i];
					array2[i] = strValues[i];
				}
				strNames = array;
				strValues = array2;
			}
			strNames[iItemCount] = strName;
			strValues[iItemCount] = strValue;
			iItemCount++;
		}

		public void Remove(string strName)
		{
			int num = IndexOf(strName);
			if (num >= 0)
			{
				for (int i = num; i < iItemCount; i++)
				{
					strNames[i] = strNames[i + 1];
					strValues[i] = strValues[i + 1];
				}
				strNames[iItemCount - 1] = null;
				strValues[iItemCount - 1] = null;
				iItemCount--;
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("NameValueList(" + iItemCount + "):");
			for (int i = 0; i < iItemCount; i++)
			{
				stringBuilder.Append(strNames[i] + "=" + strValues[i] + " ");
			}
			return stringBuilder.ToString();
		}

		public string[] ToStringArray()
		{
			string[] array = new string[iItemCount * 2];
			for (int i = 0; i < iItemCount; i++)
			{
				array[i * 2] = strNames[i];
				array[i * 2 + 1] = strValues[i];
			}
			return array;
		}

		public int FromStringArray(string[] strData)
		{
			if (strData != null && strData.Length > 0 && strData.Length % 2 == 0)
			{
				iItemCount = strData.Length / 2;
				strNames = new string[iItemCount];
				strValues = new string[iItemCount];
				for (int i = 0; i < iItemCount; i++)
				{
					strNames[i] = ((strData[i * 2] == null) ? "" : strData[i * 2].Trim());
					strValues[i] = strData[i * 2 + 1];
				}
				return iItemCount;
			}
			return -1;
		}

		public string ToListString(string strItemSpliter, string strValueSpliter)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < iItemCount; i++)
			{
				if (i == 0)
				{
					stringBuilder.Append(strNames[i] + strValueSpliter + strValues[i]);
				}
				else
				{
					stringBuilder.Append(strItemSpliter + strNames[i] + strValueSpliter + strValues[i]);
				}
			}
			return stringBuilder.ToString();
		}

		public string FixVariableString(string strText)
		{
			return FixVariableString(strText, "[", "]");
		}

		public string FixVariableString(string strText, string strHead, string strEnd)
		{
			if (strText == null || strHead == null || strEnd == null || strHead.Length == 0 || strEnd.Length == 0 || strText.Length == 0)
			{
				return strText;
			}
			int num = strText.IndexOf(strHead);
			if (num < 0)
			{
				return strText;
			}
			int num2 = 0;
			StringBuilder stringBuilder = new StringBuilder();
			do
			{
				int num3 = strText.IndexOf(strEnd, num + 1);
				if (num3 <= num)
				{
					break;
				}
				int num4 = num;
				do
				{
					num = num4;
					num4 = strText.IndexOf(strHead, num4 + 1);
				}
				while (num4 > num && num4 < num3);
				string strName = strText.Substring(num + strHead.Length, num3 - num - strHead.Length);
				int num5 = IndexOf(strName);
				if (num5 >= 0)
				{
					if (num2 < num)
					{
						stringBuilder.Append(strText.Substring(num2, num - num2));
					}
					stringBuilder.Append(strValues[num5]);
					num = num3 + strEnd.Length;
					num2 = num;
				}
				else
				{
					num = num3 + strEnd.Length;
				}
			}
			while (num >= 0 && num < strText.Length);
			if (num2 < strText.Length)
			{
				stringBuilder.Append(strText.Substring(num2));
			}
			return stringBuilder.ToString();
		}
	}
}
