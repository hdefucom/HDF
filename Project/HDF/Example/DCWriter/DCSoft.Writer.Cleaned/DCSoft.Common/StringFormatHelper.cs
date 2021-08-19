using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       DCWriter内部使用。字符串格式处理类
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public sealed class StringFormatHelper
	{
		                                                                    /// <summary>
		                                                                    ///       增强型的格式化输出，支持按照名称输出属性值
		                                                                    ///       </summary>
		                                                                    /// <param name="format">格式化字符串</param>
		                                                                    /// <param name="instances">对象数值</param>
		                                                                    /// <returns>输出的文本</returns>
		public static string FormatExt(string format, params object[] instances)
		{
			int num = 2;
			if (string.IsNullOrEmpty(format) || instances == null || instances.Length == 0)
			{
				return format;
			}
			string[] array = VariableString.AnalyseVariableString(format, "{", "}");
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (i % 2 == 0)
				{
					stringBuilder.Append(text);
					continue;
				}
				int num2 = text.IndexOf(":");
				string text2 = null;
				if (num2 > 0)
				{
					text2 = text.Substring(num2 + 1);
					text = text.Substring(0, num2).Trim();
				}
				int result = 0;
				object obj;
				if (int.TryParse(text, out result))
				{
					if (result < 0 || result >= instances.Length)
					{
						continue;
					}
					obj = instances[result];
					if (obj != null)
					{
						if (!string.IsNullOrEmpty(text2) || obj is IFormattable)
						{
							stringBuilder.Append(((IFormattable)obj).ToString(text2, null));
						}
						else
						{
							stringBuilder.Append(Convert.ToString(obj));
						}
					}
					continue;
				}
				obj = instances[0];
				PropertyInfo property = obj.GetType().GetProperty(text, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
				if (property == null)
				{
					continue;
				}
				object value = property.GetValue(obj, null);
				if (value != null)
				{
					if (!string.IsNullOrEmpty(text2) || value is IFormattable)
					{
						stringBuilder.Append(((IFormattable)value).ToString(text2, null));
					}
					else
					{
						stringBuilder.Append(Convert.ToString(value));
					}
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       修正多行文本，添加缺少的\r字符
		                                                                    ///       </summary>
		                                                                    /// <param name="text">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static string FixMultiLineTextForCr(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length);
			int length = text.Length;
			for (int i = 0; i < length; i++)
			{
				char c = text[i];
				if (c == '\n' && i > 0 && text[i] != '\r')
				{
					stringBuilder.Append('\r');
				}
				stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       进行格式化输出
		                                                                    ///       </summary>
		                                                                    /// <param name="format">格式化字符串</param>
		                                                                    /// <param name="record">记录对象</param>
		                                                                    /// <returns>输出的内容</returns>
		public static string FormatString(string format, IDataRecord record)
		{
			if (string.IsNullOrEmpty(format))
			{
				return format;
			}
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = null;
			foreach (char c in format)
			{
				switch (c)
				{
				case '{':
					stringBuilder2 = new StringBuilder();
					break;
				case '}':
				{
					string text = null;
					string text2 = stringBuilder2.ToString();
					stringBuilder2 = null;
					int num = text2.IndexOf(':');
					if (num > 0)
					{
						text = text2.Substring(num + 1);
						text2 = text2.Substring(0, num);
					}
					int result = record.GetOrdinal(text2);
					if (result < 0 && !int.TryParse(text2, out result))
					{
						result = -1;
					}
					if (result >= 0 && !record.IsDBNull(result))
					{
						object value = record.GetValue(result);
						if (string.IsNullOrEmpty(text))
						{
							stringBuilder.Append(Convert.ToString(value));
						}
						else if (value is IFormattable)
						{
							stringBuilder.Append(((IFormattable)value).ToString(text, null));
						}
						else
						{
							stringBuilder.Append(Convert.ToString(value));
						}
					}
					break;
				}
				default:
					if (stringBuilder2 == null)
					{
						stringBuilder.Append(c);
					}
					else
					{
						stringBuilder2.Append(c);
					}
					break;
				}
			}
			if (stringBuilder2 != null)
			{
				stringBuilder.Append(stringBuilder2.ToString());
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       在每行文本前添加行号
		                                                                    ///       </summary>
		                                                                    /// <param name="MultilineText">多行的文本</param>
		                                                                    /// <param name="StartLineIndex">开始的行号</param>
		                                                                    /// <returns>处理后的文本</returns>
		public static string AddLineCount(string MultilineText, int StartLineIndex)
		{
			int num = 13;
			if (MultilineText == null)
			{
				return null;
			}
			StringReader stringReader = new StringReader(MultilineText);
			ArrayList arrayList = new ArrayList();
			for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
			{
				arrayList.Add(text);
			}
			stringReader.Close();
			StringBuilder stringBuilder = new StringBuilder();
			string format = new string('0', (int)Math.Ceiling(Math.Log10(arrayList.Count + StartLineIndex)));
			string newLine = Environment.NewLine;
			for (int i = 0; i < arrayList.Count; i++)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(newLine);
				}
				stringBuilder.Append((i + StartLineIndex).ToString(format));
				stringBuilder.Append(":");
				stringBuilder.Append((string)arrayList[i]);
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       将一个多行字符转化为单行字符组成的字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">多行文本</param>
		                                                                    /// <returns>字符串数组</returns>
		public static string[] GetLines(string strText)
		{
			if (strText == null || strText.Length == 0)
			{
				return null;
			}
			StringReader stringReader = new StringReader(strText);
			ArrayList arrayList = new ArrayList();
			for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
			{
				arrayList.Add(text);
			}
			stringReader.Close();
			return (string[])arrayList.ToArray(typeof(string));
		}

		                                                                    /// <summary>
		                                                                    ///       将一个多行字符串转换为单行字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">原始字符串</param>
		                                                                    /// <returns>处理后的字符串</returns>
		public static string ToSingleLine(string strText)
		{
			if (strText == null || strText.Length == 0)
			{
				return strText;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in strText)
			{
				if (c != '\r' && c != '\n')
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       删除一个字符串中指定的字符
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">字符串</param>
		                                                                    /// <param name="vChar">指定的字符</param>
		                                                                    /// <returns>处理后的字符串</returns>
		public static string RemoveChar(string strText, char vChar)
		{
			if (strText == null || strText.Length == 0)
			{
				return strText;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in strText)
			{
				if (c != vChar)
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       若存在指定的前缀字符串则删除前缀字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">要处理的字符串</param>
		                                                                    /// <param name="strPrefix">要删除的前缀字符串</param>
		                                                                    /// <returns>处理后的字符串</returns>
		public static string RemovePrefix(string strText, string strPrefix)
		{
			if (strText == null)
			{
				return strText;
			}
			if (strText.StartsWith(strPrefix))
			{
				return strText.Substring(strPrefix.Length);
			}
			return strText;
		}

		                                                                    /// <summary>
		                                                                    ///       若存在指定的后缀字符串则删除后缀字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">要处理的字符串</param>
		                                                                    /// <param name="strEndfix">要删除的后缀字符串</param>
		                                                                    /// <returns>处理后的字符串</returns>
		public static string RemoveEndfix(string strText, string strEndfix)
		{
			if (!(strText?.EndsWith(strEndfix) ?? false))
			{
				return strText;
			}
			return strText.Substring(0, strText.Length - strEndfix.Length);
		}

		                                                                    /// <summary>
		                                                                    ///       对一个多行文本的每行添加指定的前缀和后缀
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">多行文本</param>
		                                                                    /// <param name="strPrefix">前缀</param>
		                                                                    /// <param name="strEndfix">后缀</param>
		                                                                    /// <returns>处理后的字符串</returns>
		public static string LinesAddfix(string strText, string strPrefix, string strEndfix)
		{
			if (strText == null || strText.Length == 0)
			{
				return strText;
			}
			StringReader stringReader = new StringReader(strText);
			StringBuilder stringBuilder = new StringBuilder();
			string text = stringReader.ReadLine();
			while (text != null)
			{
				if (text.Length > 0 && strPrefix != null)
				{
					stringBuilder.Append(strPrefix);
				}
				stringBuilder.Append(text);
				if (text.Length > 0 && strEndfix != null)
				{
					stringBuilder.Append(strEndfix);
				}
				text = stringReader.ReadLine();
				if (text == null)
				{
					break;
				}
				stringBuilder.Append(Environment.NewLine);
			}
			stringReader.Close();
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       计算所有的字符串的最大的字节长度，并可设置所有的字符串为相同的字节长度
		                                                                    ///       </summary>
		                                                                    /// <param name="myList">保存字符串的数组</param>
		                                                                    /// <param name="FixStyle">修正模式 0:不修正, 1:在原始字符产前面添加填充字符 2:在字符串后面添加填充字符</param>
		                                                                    /// <param name="FillChar">修正时填充的字符,其Asc码从0到255</param>
		                                                                    /// <returns>字符串最大的字节长度</returns>
		public static int FixStringByteLength(ArrayList myList, int FixStyle, char FillChar)
		{
			Encoding encoding = Encoding.GetEncoding(936);
			int num = 0;
			foreach (string my in myList)
			{
				if (my != null)
				{
					int byteCount = encoding.GetByteCount(my);
					if (num < byteCount)
					{
						num = byteCount;
					}
				}
			}
			if (FixStyle == 1 || FixStyle == 2)
			{
				for (int i = 0; i < myList.Count; i++)
				{
					string text = (string)myList[i];
					if (text == null)
					{
						text = "";
					}
					int byteCount = encoding.GetByteCount(text);
					if (byteCount != num)
					{
						text = (string)(myList[i] = ((FixStyle != 1) ? (text + new string(FillChar, num - byteCount)) : (new string(FillChar, num - byteCount) + text)));
					}
				}
			}
			return num;
		}

		                                                                    /// <summary>
		                                                                    ///       清除一个字符串中的空白字符
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">原始字符串</param>
		                                                                    /// <param name="intMaxLength">输出结果的最长长度,为0表示无限制</param>
		                                                                    /// <param name="bolHtml">是否模仿HTML对空白字符的处理</param>
		                                                                    /// <returns>没有空白字符的字符串</returns>
		public static string ClearWhiteSpace(string strText, int intMaxLength, bool bolHtml)
		{
			int num = 18;
			if (strText == null)
			{
				return null;
			}
			bool flag = false;
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = 0;
			foreach (char c in strText)
			{
				if (char.IsWhiteSpace(c))
				{
					flag = true;
					continue;
				}
				if (bolHtml && flag)
				{
					stringBuilder.Append(" ");
				}
				stringBuilder.Append(c);
				if (intMaxLength > 0)
				{
					num2++;
					if (num2 > intMaxLength)
					{
						break;
					}
				}
				flag = false;
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       清除一段文本中所有的空白行
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">文本</param>
		                                                                    /// <returns>处理后的文本</returns>
		public static string ClearBlankLine(string strData)
		{
			int num = 10;
			if (strData == null)
			{
				return null;
			}
			StringReader stringReader = new StringReader(strData);
			StringBuilder stringBuilder = new StringBuilder();
			string text = stringReader.ReadLine();
			bool flag = true;
			while (text != null)
			{
				string text2 = text;
				foreach (char c in text2)
				{
					if (!char.IsWhiteSpace(c))
					{
						if (!flag)
						{
							stringBuilder.Append("\r\n");
						}
						stringBuilder.Append(text);
						flag = false;
						break;
					}
				}
				text = stringReader.ReadLine();
			}
			stringReader.Close();
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       删除文本中的空白字符
		                                                                    ///       </summary>
		                                                                    /// <param name="strText">文本</param>
		                                                                    /// <returns>处理后的文本</returns>
		public static string RemoveBlank(string strText)
		{
			if (strText == null)
			{
				return strText;
			}
			if (strText.Length == 0)
			{
				return strText;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in strText)
			{
				if (!char.IsWhiteSpace(c))
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       压缩所有的空白字符(将连续的空白字符压缩为一个空格)
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static string NormalizeSpace(string strData)
		{
			if (strData == null)
			{
				return null;
			}
			char[] array = new char[strData.Length];
			int num = 0;
			bool flag = false;
			for (int i = 0; i < strData.Length; i++)
			{
				if (char.IsWhiteSpace(strData[i]))
				{
					if (!flag)
					{
						flag = true;
						array[num] = ' ';
						num++;
					}
				}
				else
				{
					flag = false;
					array[num] = strData[i];
					num++;
				}
			}
			if (num == 0)
			{
				return "";
			}
			return new string(array, 0, num);
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个字符串对象是否是空字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">字符串</param>
		                                                                    /// <returns>若字符串为空或者全部有空白字符组成则返回True,否则返回false</returns>
		public static bool IsBlankString(string strData)
		{
			if (strData == null)
			{
				return true;
			}
			int num = 0;
			while (true)
			{
				if (num < strData.Length)
				{
					if (!char.IsWhiteSpace(strData[num]))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个字符串是否存在空白字符
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">字符串</param>
		                                                                    /// <returns>是否存在空白字符</returns>
		public static bool HasBlank(string strData)
		{
			if (strData == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < strData.Length)
				{
					if (char.IsWhiteSpace(strData[num]))
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
		                                                                    ///       判断一个字符串是否有内容,本函数和isBlankString相反
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">字符串对象</param>
		                                                                    /// <returns>若字符串不为空且存在非空白字符则返回True 否则返回False</returns>
		public static bool HasContent(string strData)
		{
			if (strData != null && strData.Length > 0)
			{
				foreach (char c in strData)
				{
					if (!char.IsWhiteSpace(c))
					{
						return true;
					}
				}
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个字符串是否为空引用或者长度为零
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">字符串对象</param>
		                                                                    /// <returns>是否为空引用或长度为0</returns>
		public static bool IsEmpty(string strData)
		{
			return strData == null || strData.Length == 0;
		}

		                                                                    /// <summary>
		                                                                    ///       判断是否是英文字母
		                                                                    ///       </summary>
		                                                                    /// <param name="c">字符</param>
		                                                                    /// <returns>是否为英文字母</returns>
		public static bool IsEnglishLetter(char char_0)
		{
			return (char_0 >= 'a' && char_0 <= 'z') || (char_0 >= 'A' && char_0 <= 'Z');
		}

		                                                                    /// <summary>
		                                                                    ///       测试一个字符串中所有的字符都是字母或者数字
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">供测试的字符串</param>
		                                                                    /// <returns>若字符串所有字符都是字母或数字则返回true ,否则返回 false</returns>
		public static bool IsLetterOrDigit(string strData)
		{
			if (strData != null)
			{
				int num = 0;
				while (true)
				{
					if (num < strData.Length)
					{
						if (!char.IsLetterOrDigit(strData, num))
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       格式化字符串，进行分组处理
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">连续的字符串</param>
		                                                                    /// <param name="GroupSize">一组编码的字符个数</param>
		                                                                    /// <param name="LineGroupCount">每行文本的编码组个数</param>
		                                                                    /// <returns>格式化后的字符串</returns>
		public static string GroupFormatString(string strData, int GroupSize, int LineGroupCount)
		{
			int num = 6;
			if (strData == null || strData.Length == 0 || (GroupSize <= 0 && LineGroupCount <= 0))
			{
				return strData;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int length = strData.Length;
			int num2 = 0;
			LineGroupCount *= GroupSize;
			while (true)
			{
				stringBuilder.Append(" ");
				if (num2 + GroupSize >= length)
				{
					break;
				}
				stringBuilder.Append(strData.Substring(num2, GroupSize));
				num2 += GroupSize;
				if (num2 % LineGroupCount == 0)
				{
					stringBuilder.Append("\r\n");
				}
			}
			stringBuilder.Append(strData.Substring(num2));
			return stringBuilder.ToString();
		}

		private StringFormatHelper()
		{
		}
	}
}
