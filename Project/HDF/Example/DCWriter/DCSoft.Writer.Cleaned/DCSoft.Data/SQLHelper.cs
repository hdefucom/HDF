using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       SQLHelper 的摘要说明。
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public sealed class SQLHelper
	{
		                                                                    /// <summary>
		                                                                    ///       根据字段列表输出查询SQL语句
		                                                                    ///       </summary>
		                                                                    /// <param name="FieldNames">字段列表</param>
		                                                                    /// <returns>输出的SQL语句</returns>
		public static string BuildSelectSQL(ICollection FieldNames)
		{
			int num = 15;
			StringCollection stringCollection = new StringCollection();
			StringCollection stringCollection2 = new StringCollection();
			foreach (string FieldName in FieldNames)
			{
				if (!stringCollection.Contains(FieldName.Trim()))
				{
					stringCollection.Add(FieldName.Trim());
				}
				int num2 = FieldName.IndexOf('.');
				if (num2 > 0)
				{
					string value = FieldName.Substring(0, num2).Trim();
					if (!stringCollection2.Contains(value))
					{
						stringCollection2.Add(value);
					}
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" Select " + Environment.NewLine);
			for (int i = 0; i < stringCollection.Count; i++)
			{
				string text2 = stringCollection[i];
				if (text2.Length > 0)
				{
					stringBuilder.Append("     " + text2);
				}
				if (i < stringCollection.Count - 1)
				{
					stringBuilder.Append(" ," + Environment.NewLine);
				}
			}
			stringBuilder.Append(Environment.NewLine + " From" + Environment.NewLine);
			for (int i = 0; i < stringCollection2.Count; i++)
			{
				string text2 = stringCollection2[i];
				if (text2.Length > 0)
				{
					stringBuilder.Append("     " + text2);
				}
				if (i < stringCollection2.Count - 1)
				{
					stringBuilder.Append(" ," + Environment.NewLine);
				}
			}
			return stringBuilder.ToString();
		}

		public static bool MatchFieldName(string name1, string name2)
		{
			if (name1 == null || name2 == null)
			{
				return false;
			}
			if (string.Compare(name1, name2, ignoreCase: true) == 0)
			{
				return true;
			}
			int num = name1.IndexOf('.');
			if (num > 0)
			{
				name1 = name1.Substring(num + 1).Trim();
				if (name1.Length == 0)
				{
					return false;
				}
			}
			num = name2.IndexOf('.');
			if (num > 0)
			{
				name2 = name2.Substring(num + 1).Trim();
				if (name2.Length == 0)
				{
					return false;
				}
			}
			if (string.Compare(name1, name2, ignoreCase: true) == 0)
			{
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       获得字段名在字段名称列表中的从0开始的序号
		                                                                    ///       </summary>
		                                                                    /// <param name="FieldNames">字段名称列表</param>
		                                                                    /// <param name="FieldName">指定的字段名称</param>
		                                                                    /// <returns>从0开始的序号,若未找到则返回-1</returns>
		public static int FieldIndexOf(ICollection FieldNames, string FieldName)
		{
			int num = 15;
			if (FieldName == null || FieldNames == null)
			{
				return -1;
			}
			FieldName = FieldName.Trim();
			if (FieldName.Length == 0)
			{
				return -1;
			}
			int num2 = 0;
			bool flag = true;
			string text = FieldName;
			foreach (char value in text)
			{
				if ("0123456789".IndexOf(value) < 0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				num2 = Convert.ToInt32(FieldName);
				if (num2 >= 0 && num2 < FieldNames.Count)
				{
					return num2;
				}
				return -1;
			}
			foreach (string FieldName2 in FieldNames)
			{
				if (string.Compare(FieldName2, FieldName, ignoreCase: true) == 0)
				{
					return num2;
				}
				num2++;
			}
			num2 = FieldName.IndexOf('.');
			if (num2 > 0)
			{
				FieldName = FieldName.Substring(num2 + 1).Trim();
			}
			if (FieldName.Length == 0)
			{
				return -1;
			}
			num2 = 0;
			foreach (string FieldName3 in FieldNames)
			{
				if (string.Compare(FieldName3, FieldName, ignoreCase: true) == 0)
				{
					return num2;
				}
				int num3 = FieldName3.IndexOf('.');
				if (num3 >= 0)
				{
					string strA2 = FieldName3.Substring(num3 + 1).Trim();
					if (string.Compare(strA2, FieldName, ignoreCase: true) == 0)
					{
						return num2;
					}
				}
				num2++;
			}
			return -1;
		}

		private SQLHelper()
		{
		}
	}
}
