using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       内部可嵌入变量域的字符串处理对象
	                                                                    ///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class VariableString
	{
		private bool bolNamedParameter = false;

		private string strParameterNamePrefix = "@";

		private string strVariablePrefix = "[%";

		private string strVariableEndfix = "%]";

		private IVariableProvider myVariables = new HashTableVariableProvider();

		private string strText = null;

		                                                                    /// <summary>
		                                                                    ///       命名方式的使用参数
		                                                                    ///       </summary>
		public bool NamedParameter
		{
			get
			{
				return bolNamedParameter;
			}
			set
			{
				bolNamedParameter = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       参数名称前缀
		                                                                    ///       </summary>
		public string ParameterNamePrefix
		{
			get
			{
				return strParameterNamePrefix;
			}
			set
			{
				strParameterNamePrefix = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       变量域前缀
		                                                                    ///       </summary>
		public string VariablePrefix
		{
			get
			{
				return strVariablePrefix;
			}
			set
			{
				strVariablePrefix = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       变量域后缀
		                                                                    ///       </summary>
		public string VariableEndfix
		{
			get
			{
				return strVariableEndfix;
			}
			set
			{
				strVariableEndfix = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       变量提供者,默认为一个 HashTableVariableProvider 类型的对象
		                                                                    ///       </summary>
		public IVariableProvider Variables
		{
			get
			{
				return myVariables;
			}
			set
			{
				myVariables = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       字符串数据
		                                                                    ///       </summary>
		public string Text
		{
			get
			{
				return strText;
			}
			set
			{
				strText = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public VariableString()
		{
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="txt">字符串数据</param>
		public VariableString(string string_0)
		{
			strText = string_0;
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="txt">字符串数据</param>
		                                                                    /// <param name="Prefix">字符前缀</param>
		                                                                    /// <param name="EndFix">字符后缀</param>
		public VariableString(string string_0, string Prefix, string EndFix)
		{
			strText = string_0;
			strVariablePrefix = Prefix;
			strVariableEndfix = EndFix;
		}

		                                                                    /// <summary>
		                                                                    ///       设置变量
		                                                                    ///       </summary>
		                                                                    /// <param name="strName">变量名称</param>
		                                                                    /// <param name="strValue">变量值</param>
		public void SetVariable(string strName, string strValue)
		{
			if (myVariables != null)
			{
				myVariables.Set(strName, strValue);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得字符串中包含的变量名称
		                                                                    ///       </summary>
		                                                                    /// <returns>变量名称组成的字符串数组</returns>
		public string[] GetVariableNames()
		{
			string[] array = AnalyseVariableString(strText, strVariablePrefix, strVariableEndfix);
			if (array != null)
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 1; i < array.Length; i += 2)
				{
					arrayList.Add(array[i]);
				}
				return (string[])arrayList.ToArray(typeof(string));
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       执行变量
		                                                                    ///       </summary>
		                                                                    /// <returns>处理后的字符串</returns>
		public string Execute()
		{
			return Execute(strText, null);
		}

		                                                                    /// <summary>
		                                                                    ///       进行变量替换
		                                                                    ///       </summary>
		                                                                    /// <param name="ParameterValues">变量值</param>
		                                                                    /// <returns>替换后的结果</returns>
		public string Execute(ArrayList ParameterValues)
		{
			return Execute(strText, ParameterValues);
		}

		                                                                    /// <summary>
		                                                                    ///       执行变量
		                                                                    ///       </summary>
		                                                                    /// <param name="txt">原始字符串</param>
		                                                                    /// <param name="ParameterValues">保存参数的列表</param>
		                                                                    /// <returns>处理后的字符串</returns>
		public string Execute(string string_0, ArrayList ParameterValues)
		{
			int num = 6;
			if (myVariables == null)
			{
				throw new InvalidOperationException("未设置 Variables 属性");
			}
			if (string_0 == null || string_0.Length == 0)
			{
				return string_0;
			}
			string[] array = AnalyseVariableString(string_0, strVariablePrefix, strVariableEndfix);
			if (array == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				string text = array[i];
				bool flag;
				if (flag = text.StartsWith("@"))
				{
					text = text.Substring(1);
				}
				string text2 = null;
				text2 = ((!myVariables.Exists(text)) ? "" : myVariables.Get(text));
				if (ParameterValues != null && flag)
				{
					if (bolNamedParameter)
					{
						string text3 = text.Trim();
						if (ContainsString(arrayList, text3))
						{
							for (int j = arrayList.Count; j < 100; j++)
							{
								text3 = "Parameter" + j;
								if (!ContainsString(arrayList, text3))
								{
									break;
								}
							}
						}
						arrayList.Add(text3);
						ParameterValues.Add(text3);
						ParameterValues.Add(text2);
						stringBuilder.Append(" " + strParameterNamePrefix + text3 + " ");
					}
					else
					{
						ParameterValues.Add(text2);
						stringBuilder.Append(" ? ");
					}
				}
				else
				{
					stringBuilder.Append(text2);
				}
			}
			return stringBuilder.ToString();
		}

		private bool ContainsString(ArrayList list, string strValue)
		{
			strValue = strValue.Trim();
			int num = 0;
			while (true)
			{
				if (num < list.Count)
				{
					string text = (string)list[num];
					text = text.Trim();
					if (string.Compare(strValue, text, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       分析一个字符串,根据开始字符串和结束字符串进行分割,并返回分割生成的字符串数组
		                                                                    ///       这些字符串数组的偶数号元素为开始字符串和结束字符串间的部分
		                                                                    ///       例如分析字符串"aaa[bbb]ccc"产生字符串数组"aaa","bbb","ccc"
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">供分析的字符串</param>
		                                                                    /// <param name="strHead">开始字符串</param>
		                                                                    /// <param name="strEnd">结束字符串</param>
		                                                                    /// <returns>生成的字符串数组</returns>
		public static string[] AnalyseVariableString(string strText, string strHead, string strEnd)
		{
			return AnalyseVariableString(strText, strHead, strEnd, EnableEmptyItem: false);
		}

		                                                                    /// <summary>
		                                                                    ///       分析一个字符串,根据开始字符串和结束字符串进行分割,并返回分割生成的字符串数组
		                                                                    ///       这些字符串数组的偶数号元素为开始字符串和结束字符串间的部分
		                                                                    ///       例如分析字符串"aaa[bbb]ccc"产生字符串数组"aaa","bbb","ccc"
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">供分析的字符串</param>
		                                                                    /// <param name="strHead">开始字符串</param>
		                                                                    /// <param name="strEnd">结束字符串</param>
		                                                                    /// <param name="EnableEmptyItem">允许出现空白项目</param>
		                                                                    /// <returns>生成的字符串数组</returns>
		public static string[] AnalyseVariableString(string strText, string strHead, string strEnd, bool EnableEmptyItem)
		{
			if (strText == null || strHead == null || strEnd == null || strHead.Length == 0 || strEnd.Length == 0 || strText.Length == 0)
			{
				return new string[1]
				{
					strText
				};
			}
			int num = strText.IndexOf(strHead);
			if (num < 0)
			{
				return new string[1]
				{
					strText
				};
			}
			ArrayList arrayList = new ArrayList();
			int num2 = 0;
			do
			{
				int num3 = strText.IndexOf(strEnd, num + 1);
				if (num3 <= num)
				{
					break;
				}
				num = LastIndexOfRange(strText, strHead, num2, num3);
				if (num == -1)
				{
					break;
				}
				int num4 = num3 - num - strHead.Length;
				if (num4 < 0 || (num4 == 0 && !EnableEmptyItem))
				{
					break;
				}
				string value = strText.Substring(num + strHead.Length, num4);
				if (num2 < num)
				{
					string value2 = strText.Substring(num2, num - num2);
					arrayList.Add(value2);
				}
				else
				{
					arrayList.Add("");
				}
				arrayList.Add(value);
				num = num3 + strEnd.Length;
				num2 = num;
			}
			while (num >= 0 && num < strText.Length);
			if (num2 < strText.Length)
			{
				arrayList.Add(strText.Substring(num2));
			}
			return (string[])arrayList.ToArray(typeof(string));
		}

		private static int LastIndexOfRange(string strText, string strSearch, int StartIndex, int EndIndex)
		{
			int num = 17;
			if (strText == null)
			{
				throw new ArgumentNullException("strText");
			}
			if (strSearch == null)
			{
				throw new ArgumentNullException("strSearch");
			}
			int num2 = strText.IndexOf(strSearch, StartIndex);
			if (num2 == -1)
			{
				return -1;
			}
			StartIndex += strSearch.Length;
			while (true)
			{
				int num3 = strText.IndexOf(strSearch, StartIndex);
				if (num3 == -1 || num3 >= EndIndex)
				{
					break;
				}
				num2 = num3;
				StartIndex += strSearch.Length;
			}
			return num2;
		}
	}
}
