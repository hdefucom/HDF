using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       字符串解析通用模块
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public sealed class StringAnalyseHelper
	{
		public static bool Hasfix(string strText, string strPrefix, string strEndfix)
		{
			if (strText == null)
			{
				return false;
			}
			return strText.StartsWith(strPrefix) && strText.EndsWith(strEndfix);
		}

		                                                                    /// <summary>
		                                                                    ///       将一个多行文本转换为字符串数组，每行文本为一个数组元素
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">多行文本</param>
		                                                                    /// <param name="RemoveBlankLine">是否删除空白行</param>
		                                                                    /// <returns>获得的字符串数组</returns>
		public static string[] GetLines(string strText, bool RemoveBlankLine)
		{
			if (strText == null)
			{
				return null;
			}
			StringReader stringReader = new StringReader(strText);
			ArrayList arrayList = new ArrayList();
			for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
			{
				if (!RemoveBlankLine || text.Length != 0)
				{
					arrayList.Add(text);
				}
			}
			stringReader.Close();
			return (string[])arrayList.ToArray(typeof(string));
		}

		public static string[] GetWords(string strText)
		{
			int num = 2;
			if (strText == null || strText.Length == 0)
			{
				return null;
			}
			return strText.Split(" \t\r\n".ToCharArray(), int.MaxValue);
		}

		public static string GetInnerString(string strText, string strHead, string strEnd)
		{
			int num = strText.IndexOf(strHead);
			num = ((num != -1) ? (num + strHead.Length) : 0);
			int num2 = strText.LastIndexOf(strEnd);
			if (num2 == -1)
			{
				num2 = strText.Length;
			}
			if (num < num2)
			{
				return strText.Substring(num, num2 - num);
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       判断字符串1是否以字符串2开头
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">字符串1</param>
		                                                                    /// <param name="strHead">字符串2</param>
		                                                                    /// <param name="IgnoreCase">是否区分大小写</param>
		                                                                    /// <returns>字符串1是否以字符串2为开头</returns>
		public static bool StartsWith(string strText, string strHead, bool IgnoreCase)
		{
			if (strText == null || strHead == null || strText.Length <= strHead.Length || strHead.Length == 0)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < strHead.Length)
				{
					if (strText[num] != strHead[num])
					{
						if (!IgnoreCase)
						{
							break;
						}
						if (char.ToLower(strText[num]) != char.ToLower(strHead[num]))
						{
							return false;
						}
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       找到指定字符串中一组字符出现的第一个序号
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">字符串</param>
		                                                                    /// <param name="strFind">所有需要查找的字符组成的字符串</param>
		                                                                    /// <returns>第一次出现字符的序号,若未找到则返回-1</returns>
		public static int IndexofEx(string strData, string strFind)
		{
			int num = -1;
			int num2 = 0;
			if (strData != null && strFind != null)
			{
				for (int i = 0; i < strFind.Length; i++)
				{
					num2 = strData.IndexOf(strFind[i]);
					if (num2 < num || num == -1)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		                                                                    /// <summary>
		                                                                    ///       找到第一次出现空白字符的位置
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">字符串</param>
		                                                                    /// <returns>第一次出现空白字符的位置,若未找到则返回字符的长度</returns>
		public static int IndexofWiteSpace(string strData)
		{
			int num = 0;
			while (true)
			{
				if (num < strData.Length)
				{
					if (char.IsWhiteSpace(strData, num))
					{
						break;
					}
					num++;
					continue;
				}
				return strData.Length;
			}
			return num;
		}

		                                                                    /// <summary>
		                                                                    ///       找到第一次出现空白字符的位置
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">字符串</param>
		                                                                    /// <param name="StartIndex">开始查找的起始位置</param>
		                                                                    /// <returns>第一次出现空白字符的位置,若未找到则返回字符的长度</returns>
		public static int IndexofWiteSpace(string strData, int StartIndex)
		{
			if (StartIndex < 0 || StartIndex >= strData.Length)
			{
				StartIndex = 0;
			}
			int num = StartIndex;
			while (true)
			{
				if (num < strData.Length)
				{
					if (char.IsWhiteSpace(strData, num))
					{
						break;
					}
					num++;
					continue;
				}
				return strData.Length;
			}
			return num;
		}

		                                                                    /// <summary>
		                                                                    ///       将一个字符串根据其中包含的数字字符区域分成三分,函数返回3个元素的字符串数组
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">字符串数据</param>
		                                                                    /// <returns>三个元素的字符串数组</returns>
		public static string[] SplitWithNumber(string strText)
		{
			bool flag = false;
			int num = 0;
			int num2 = strText.Length;
			for (int i = 0; i < strText.Length; i++)
			{
				char c = strText[i];
				if (c >= '0' && c <= '9')
				{
					if (!flag)
					{
						num = i;
						flag = true;
					}
				}
				else if (flag)
				{
					num2 = i;
					break;
				}
			}
			string[] array = new string[3];
			if (num > 0)
			{
				array[0] = strText.Substring(0, num);
			}
			if (num2 > 0)
			{
				array[1] = strText.Substring(num, num2 - num);
			}
			if (num2 < strText.Length)
			{
				array[2] = strText.Substring(num2);
			}
			return array;
		}

		                                                                    /// <summary>
		                                                                    ///       安全的分隔字符串,分隔结果不会包含空字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">字符串</param>
		                                                                    /// <param name="chrSpliter">分隔字符串</param>
		                                                                    /// <returns>分隔后的字符串数组,若无法分隔则返回空引用</returns>
		public static string[] SaftSplit(string strText, char chrSpliter)
		{
			if (strText == null)
			{
				return null;
			}
			string[] array = strText.Split(chrSpliter);
			ArrayList arrayList = new ArrayList();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.Length > 0)
				{
					arrayList.Add(text);
				}
			}
			if (arrayList.Count == 0)
			{
				return null;
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		                                                                    /// <summary>
		                                                                    ///       获得字符串中指定分隔符前面的子字符串,若分隔字符串不存在则返回原始字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">字符串</param>
		                                                                    /// <param name="strSpliter">分隔字符串</param>
		                                                                    /// <returns>分隔字符串前面的子字符串</returns>
		public static string GetPreString(string strText, string strSpliter)
		{
			if (strText == null)
			{
				return null;
			}
			int num = strText.IndexOf(strSpliter);
			if (num >= 0)
			{
				return strText.Substring(0, num);
			}
			return strText;
		}

		                                                                    /// <summary>
		                                                                    ///       获得字符串中指定分隔符后面的子字符串,若分隔字符串不存在则返回空引用
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">字符串</param>
		                                                                    /// <param name="strSpliter">分隔字符串</param>
		                                                                    /// <returns>分隔字符串后面的子字符串</returns>
		public static string GetAfterString(string strText, string strSpliter)
		{
			if (strText == null)
			{
				return null;
			}
			int num = strText.IndexOf(strSpliter);
			if (num >= 0)
			{
				return strText.Substring(num + strSpliter.Length);
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       分析单行字符串,该字符串为名称值=值对
		                                                                    ///       </summary>
		                                                                    /// <param name="strList">
		                                                                    /// </param>
		                                                                    /// <param name="strLastParamName">
		                                                                    /// </param>
		                                                                    /// <param name="AllowSameName">是否允许重名</param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static string[] AnalyseSingleLineParams(string strList, string strLastParamName, bool AllowSameName)
		{
			if (strList == null || strList.Length == 0)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			string text = null;
			string text2 = null;
			string text3 = null;
			int num = 0;
			while (num < strList.Length)
			{
				int num2 = IndexofWiteSpace(strList, num);
				if (num2 < 0)
				{
					num2 = strList.Length;
				}
				if (num2 > num + 1)
				{
					text = strList.Substring(num, num2 - num);
					int num3 = text.IndexOf('=');
					if (num3 > 0)
					{
						text2 = text.Substring(0, num3);
						text3 = text.Substring(num3 + 1);
					}
					else
					{
						text2 = text;
						text3 = "";
					}
					if (strLastParamName != null && strLastParamName.Equals(text2))
					{
						num = strList.IndexOf('=', num);
						text3 = ((num <= 0) ? "" : strList.Substring(num + 1));
					}
					bool flag = true;
					if (!AllowSameName && IsNameExist(arrayList, text2))
					{
						flag = false;
					}
					if (flag)
					{
						arrayList.Add(text2);
						arrayList.Add(text3);
					}
				}
				num = num2 + 1;
			}
			if (arrayList.Count > 0)
			{
				return null;
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		                                                                    /// <summary>
		                                                                    ///       本函数参数为一个多行字符串，每一行字符串由一个名称和一个值组成，名称和值间用等号分开，本函数
		                                                                    ///       就是分析这个字符串，将名称和值拆开来组成一个字符串对象数组，该数组元素个数为偶数个
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">供分析的字符串</param>
		                                                                    /// <returns>生成的字符串数组，数组元素个数为偶数个且大于0，若参数中没有数据则返回空对象</returns>
		public static string[] AnalyseLineParams(string strText)
		{
			if (strText == null || strText.Length == 0)
			{
				return null;
			}
			StringReader stringReader = new StringReader(strText);
			ArrayList arrayList = new ArrayList();
			for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
			{
				if (text.Length > 0)
				{
					int num = text.IndexOf('=');
					if (num >= 0)
					{
						arrayList.Add(text.Substring(0, num));
						arrayList.Add(text.Substring(num + 1));
					}
					else
					{
						arrayList.Add(text);
						arrayList.Add("");
					}
				}
			}
			if (arrayList.Count > 0)
			{
				return (string[])arrayList.ToArray(typeof(string));
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       分析一个保存列表数据的字符串并将分析结果保存在一个名称-值集合中
		                                                                    ///       该字符串格式为 项目名 值分隔字符 项目值 项目分隔字符 项目名 值分隔字符 项目值 ...
		                                                                    ///       例如 若值分隔字符为 ； 项目分隔字符为 = 则该输入字符串格式为 a=1;b=2;c=33
		                                                                    ///       则本函数将生成一个名称-值集合对象,其中的内容为 {(a,1),(b,2),(c,33)}
		                                                                    ///       </summary>
		                                                                    /// <param name="strList">保存列表数据的字符串</param>
		                                                                    /// <param name="ItemSplit">项目分隔字符串</param>
		                                                                    /// <param name="ValueSplit">值分隔字符串</param>
		                                                                    /// <param name="AllowSameName">分析的项目是否允许重名</param>
		                                                                    /// <returns>返回的依次保存项目名称和项目值的集合对象,参数不正确则返回空引用</returns>
		public static NameValueCollection AnalyseNameValueList(string strList, char ItemSplit, char ValueSplit, bool AllowSameName)
		{
			string[] array = AnalyseStringList(strList, ItemSplit, ValueSplit, AllowSameName);
			if (array != null && array.Length > 0)
			{
				NameValueCollection nameValueCollection = new NameValueCollection();
				for (int i = 0; i < array.Length; i += 2)
				{
					nameValueCollection.Set(array[i], array[i + 1]);
				}
				return nameValueCollection;
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       分析一个保存列表数据的字符串并将分析结果保存在一个字符串字典中
		                                                                    ///       该字符串格式为 项目名 值分隔字符 项目值 项目分隔字符 项目名 值分隔字符 项目值 ...
		                                                                    ///       例如 若值分隔字符为 ； 项目分隔字符为 = 则该输入字符串格式为 a=1;b=2;c=33
		                                                                    ///       则本函数将生成一个名称-值集合对象,其中的内容为 {(a,1),(b,2),(c,33)}
		                                                                    ///       </summary>
		                                                                    /// <param name="dic">字符串字典对象</param>
		                                                                    /// <param name="strList">保存列表数据的字符串</param>
		                                                                    /// <param name="ItemSplit">项目分隔字符串</param>
		                                                                    /// <param name="ValueSplit">值分隔字符串</param>
		                                                                    /// <param name="AllowSameName">分析的项目是否允许重名</param>
		                                                                    /// <returns>返回的依次保存项目名称和项目值的集合对象,参数不正确则返回空引用</returns>
		public static void AnalyseNameValueDictionary(StringDictionary stringDictionary_0, string strList, char ItemSplit, char ValueSplit, bool AllowSameName)
		{
			string[] array = AnalyseStringList(strList, ItemSplit, ValueSplit, AllowSameName);
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i += 2)
				{
					stringDictionary_0[array[i]] = array[i + 1];
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       分析一个保存列表数据的字符串并将分析结果保存在一个字符串数组中
		                                                                    ///       该字符串格式为 项目名 值分隔字符 项目值 项目分隔字符 项目名 值分隔字符 项目值 ...
		                                                                    ///       例如 若值分隔字符为 ； 项目分隔字符为 = 则该输入字符串格式为 a=1;b=2;c=33
		                                                                    ///       则本函数将生成一个字符串数组 {a,1,b,2,c,33}，数组元素为偶数个
		                                                                    ///       </summary>
		                                                                    /// <param name="strList">保存列表数据的字符串</param>
		                                                                    /// <param name="ItemSplit">项目分隔字符串</param>
		                                                                    /// <param name="ValueSplit">值分隔字符串</param>
		                                                                    /// <param name="AllowSameName">分析的项目是否允许重名</param>
		                                                                    /// <returns>返回的依次保存项目名称和项目值的字符串，元素个数必为偶数个,参数不正确则返回空引用</returns>
		public static string[] AnalyseStringList(string strList, char ItemSplit, char ValueSplit, bool AllowSameName)
		{
			if (strList == null || strList.Length == 0)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			string text = null;
			string text2 = null;
			string text3 = null;
			int num = 0;
			while (num < strList.Length)
			{
				int num2 = strList.IndexOf(ItemSplit, num);
				if (num2 < 0)
				{
					num2 = strList.Length;
				}
				if (num2 > num + 1)
				{
					text = strList.Substring(num, num2 - num);
					int num3 = text.IndexOf(ValueSplit);
					if (num3 > 0)
					{
						text2 = text.Substring(0, num3);
						text3 = text.Substring(num3 + 1);
					}
					else
					{
						text2 = text;
						text3 = "";
					}
					bool flag = true;
					if (!AllowSameName && IsNameExist(arrayList, text2))
					{
						flag = false;
					}
					if (flag)
					{
						arrayList.Add(text2);
						arrayList.Add(text3);
					}
				}
				num = num2 + 1;
			}
			if (arrayList.Count > 0)
			{
				return (string[])arrayList.ToArray(typeof(string));
			}
			return null;
		}

		private static bool IsNameExist(ArrayList myList, string strName)
		{
			int num = 0;
			while (true)
			{
				if (num < myList.Count)
				{
					if (strName.Equals((string)myList[num]))
					{
						break;
					}
					num += 2;
					continue;
				}
				return false;
			}
			return true;
		}

		private StringAnalyseHelper()
		{
		}
	}
}
