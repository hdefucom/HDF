using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       通用的字符串处理静态对象
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class StringCommon
	{
		                                                                    /// <summary> 
		                                                                    ///       使用 POST 方法向 某web服务器发送和接受数据的事件处理
		                                                                    ///        参数strURL web服务器页面地址 ContentLength 上传或者下载的数据的长度
		                                                                    ///        CompletedLength 已经上传或下载的数据的长度
		                                                                    ///        Tick     操作开始的毫秒数
		                                                                    ///        Status 状态 0:正在打开连接 1:正在上传数据 2:上传完毕，正在等待响应 
		                                                                    ///                    3:收到响应，准备下载 4:正在下载 5:下载完毕
		                                                                    ///        返回值：True 继续执行操作 False 立即终止操作
		                                                                    ///       </summary>
		[ComVisible(false)]
		public delegate bool PostEventHandler(string strURL, long ContentLength, long CompletedLength, int Tick, int Status);

		public const string c_HexCharList = "0123456789ABCDEF";

		public const string c_Base64CharList = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

		public const string StartPunctuaction = "!),.:;?]}\u00a8·\u02c7\u02c9―‖’”…∶、。〃\u3005〉》」』】〕〗！＂＇），．：；？］\uff40｜｝～￠";

		public const string EndPunctuaction = "([{·‘“〈《「『【〔〖（．［｛￡￥";

		private static int intAllocCount = 0;

		private static NameValueCollection myStringTable = null;

		                                                                    /// <summary>
		                                                                    ///       压缩空白字符。将连续的空白字符压缩成一个空格。
		                                                                    ///       </summary>
		                                                                    /// <param name="txt">要处理的字符串</param>
		                                                                    /// <returns>处理后的字符串</returns>
		public static string CompressWhiteSpace(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return string_0;
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in string_0)
			{
				if (char.IsWhiteSpace(c) || c == '\u3000')
				{
					if (!flag)
					{
						flag = true;
						stringBuilder.Append(' ');
					}
				}
				else
				{
					flag = false;
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		public static string RemoveBlankLine(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return string_0;
			}
			StringBuilder stringBuilder = new StringBuilder();
			StringReader stringReader = new StringReader(string_0);
			for (string text = stringReader.ReadLine(); text != null; text = stringReader.ReadLine())
			{
				string text2 = text.Trim();
				if (text2.Length > 0)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine();
					}
					stringBuilder.Append(text2);
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetAssemblyVersion(string AssemblyFullName)
		{
			int num = 15;
			if (AssemblyFullName == null)
			{
				return "";
			}
			int num2 = AssemblyFullName.IndexOf("Version=");
			if (num2 > 0)
			{
				string text = AssemblyFullName.Substring(num2 + 8);
				num2 = text.IndexOf(",");
				if (num2 > 0)
				{
					text = text.Substring(0, num2);
				}
				return text;
			}
			return "";
		}

		public static string GetIncludeChars(string Data, string IncludeChars)
		{
			if (Data == null || Data.Length == 0)
			{
				return Data;
			}
			if (IncludeChars == null || IncludeChars.Length == 0)
			{
				return Data;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char value in Data)
			{
				if (IncludeChars.IndexOf(value) >= 0)
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       清除指定的字符
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">原始字符串</param>
		                                                                    /// <param name="FilterChars">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static string ClearChars(string Data, string ClearChars)
		{
			if (Data == null || Data.Length == 0)
			{
				return Data;
			}
			if (ClearChars == null || ClearChars.Length == 0)
			{
				return Data;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char value in Data)
			{
				if (ClearChars.IndexOf(value) < 0)
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       清除符号":"
		                                                                    ///       </summary>
		                                                                    /// <param name="Data">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static string ClearColon(string Data)
		{
			int num = 5;
			if (IsNullOrEmpty(Data))
			{
				return "";
			}
			return Data.Replace("：", "").Replace(":", "").Trim();
		}

		                                                                    /// <summary>
		                                                                    /// </summary>
		                                                                    /// <param name="value">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static bool IsNullOrEmpty(string value)
		{
			if (value != null)
			{
				return value.Length == 0;
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    /// </summary>
		                                                                    /// <param name="input">
		                                                                    /// </param>
		                                                                    /// <param name="result">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static bool TryParseInt(string input, out int result)
		{
			result = 0;
			try
			{
				result = int.Parse(input);
			}
			catch
			{
				return false;
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    /// </summary>
		                                                                    /// <param name="input">
		                                                                    /// </param>
		                                                                    /// <param name="result">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static bool TryParseFloat(string input, out float result)
		{
			result = 0f;
			try
			{
				result = float.Parse(input);
			}
			catch
			{
				return false;
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    /// </summary>
		                                                                    /// <param name="input">
		                                                                    /// </param>
		                                                                    /// <param name="result">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static bool TryParseDouble(string input, out double result)
		{
			result = 0.0;
			try
			{
				result = double.Parse(input);
			}
			catch
			{
				return false;
			}
			return true;
		}

		                                                                    /// <summary>
		                                                                    ///       安全的获得子字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="txt">字符串</param>
		                                                                    /// <param name="StartIndex">子字符串的开始位置</param>
		                                                                    /// <param name="Length">要获得的子字符串长度</param>
		                                                                    /// <returns>获得的子字符串</returns>
		public static string SafeSubstring(string string_0, int StartIndex, int Length)
		{
			if (string_0 != null)
			{
				if (Length + StartIndex >= string_0.Length)
				{
					return string_0.Substring(StartIndex);
				}
				return string_0.Substring(StartIndex, Length);
			}
			return null;
		}

		public static int GetSymbolSplitLevel(char vSymbol)
		{
			if (vSymbol == '.' || vSymbol == '。')
			{
				return 5;
			}
			if (vSymbol == ';' || vSymbol == '；')
			{
				return 4;
			}
			if (vSymbol == ',' || vSymbol == '，')
			{
				return 3;
			}
			if (vSymbol == '、')
			{
				return 2;
			}
			if (char.IsWhiteSpace(vSymbol))
			{
				return 1;
			}
			return 0;
		}

		                                                                    /// <summary>
		                                                                    ///       获得可用于作为控件快捷键字符列表
		                                                                    ///       </summary>
		                                                                    /// <param name="strExcept">排除的字母组成的字符串</param>
		                                                                    /// <returns>可供作为快捷字符组成的字符串</returns>
		public static string GetShortCutChars(string strExcept)
		{
			string text = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			if (strExcept != null)
			{
				strExcept = strExcept.Trim().ToUpper();
			}
			StringBuilder stringBuilder = new StringBuilder();
			string text2 = text;
			foreach (char value in text2)
			{
				if (strExcept == null || strExcept.IndexOf(value) < 0)
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		                                                                    /// <summary>
		                                                                    ///       分配一个对象名称
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static string AllocObjectName()
		{
			intAllocCount++;
			return "C" + Environment.TickCount.ToString("X") + intAllocCount;
		}

		                                                                    /// <summary>
		                                                                    ///       根据一个BASE64的字符串加载一个图片对象
		                                                                    ///       </summary>
		                                                                    /// <param name="strBase64">Base54字符串</param>
		                                                                    /// <returns>创建的图片对象,若发生错误则返回空引用</returns>
		public static Image ImageFromBase64String(string strBase64)
		{
			try
			{
				byte[] buffer = Convert.FromBase64String(strBase64);
				MemoryStream memoryStream = new MemoryStream(buffer);
				Image result = Image.FromStream(memoryStream);
				memoryStream.Close();
				return result;
			}
			catch
			{
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       将一个图片对象按照指定的图片格式保存到一个Base64字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="myImage">图片对象</param>
		                                                                    /// <param name="format">图片格式,默认为PNG格式</param>
		                                                                    /// <returns>Base64字符串</returns>
		public static string ImageToBase64String(Image myImage, ImageFormat format)
		{
			if (myImage == null)
			{
				return null;
			}
			if (format == null)
			{
				format = ImageFormat.Png;
			}
			MemoryStream memoryStream = new MemoryStream();
			myImage.Save(memoryStream, format);
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			return Convert.ToBase64String(inArray);
		}

		                                                                    /// <summary>
		                                                                    ///       向指定URL使用POST方法发送一个字符串数据并返回保存响应结果的字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strSend">POST发送的字符串</param>
		                                                                    /// <param name="strURL">URL地址</param>
		                                                                    /// <param name="vEvent">发送事件对象</param>
		                                                                    /// <returns>保存相应结果的字符串,若取消操作则返回空引用</returns>
		public static string PostStringData(string strSend, string strURL, PostEventHandler vEvent)
		{
			int num = 7;
			byte[] bytes = Encoding.UTF8.GetBytes(strSend);
			int tickCount = Environment.TickCount;
			if (!(vEvent?.Invoke(strURL, bytes.Length, 0L, 0, 0) ?? true))
			{
				return null;
			}
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = bytes.Length;
			httpWebRequest.Method = "POST";
			Stream requestStream = httpWebRequest.GetRequestStream();
			int num2 = 0;
			do
			{
				if (num2 + 1024 <= bytes.Length)
				{
					requestStream.Write(bytes, num2, 1024);
					num2 += 1024;
					continue;
				}
				requestStream.Write(bytes, num2, bytes.Length - num2);
				if (!(vEvent?.Invoke(strURL, bytes.Length, bytes.Length, Environment.TickCount - tickCount, 1) ?? true))
				{
					requestStream.Close();
					httpWebRequest.Abort();
					return null;
				}
				requestStream.Close();
				if (!(vEvent?.Invoke(strURL, bytes.Length, num2, Environment.TickCount - tickCount, 2) ?? true))
				{
					httpWebRequest.Abort();
					return null;
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				requestStream = httpWebResponse.GetResponseStream();
				if (!(vEvent?.Invoke(strURL, httpWebResponse.ContentLength, 0L, Environment.TickCount - tickCount, 3) ?? true))
				{
					httpWebResponse.Close();
					httpWebRequest.Abort();
					return null;
				}
				MemoryStream memoryStream = new MemoryStream(1024);
				byte[] buffer = new byte[1024];
				do
				{
					int num3 = requestStream.Read(buffer, 0, 1024);
					if (num3 != 0)
					{
						memoryStream.Write(buffer, 0, num3);
						continue;
					}
					requestStream.Close();
					httpWebResponse.Close();
					httpWebRequest.Abort();
					if (!(vEvent?.Invoke(strURL, httpWebResponse.ContentLength, memoryStream.Length, Environment.TickCount - tickCount, 5) ?? true))
					{
						return null;
					}
					byte[] array = memoryStream.ToArray();
					memoryStream.Close();
					char[] array2 = new char[Encoding.UTF8.GetCharCount(array, 0, array.Length)];
					Encoding.UTF8.GetChars(array, 0, array.Length, array2, 0);
					return new string(array2);
				}
				while (vEvent?.Invoke(strURL, httpWebResponse.ContentLength, memoryStream.Length, Environment.TickCount - tickCount, 4) ?? true);
				httpWebResponse.Close();
				httpWebRequest.Abort();
				memoryStream.Close();
				return null;
			}
			while (vEvent?.Invoke(strURL, bytes.Length, num2, Environment.TickCount - tickCount, 1) ?? true);
			requestStream.Close();
			httpWebRequest.Abort();
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       将字符串按照指定格式转换为时间数据，若没指定格式则尝试自动判别格式,若转换失败则使用默认时间
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">表示时间数据的字符串</param>
		                                                                    /// <param name="strFromFormat">指定的转换格式，可以为空</param>
		                                                                    /// <param name="DefaultValue">若转换失败则使用的默认时间</param>
		                                                                    /// <returns>转换后的时间数据</returns>
		public static DateTime ConvertToDateTime(string strValue, string strFromFormat, DateTime DefaultValue)
		{
			try
			{
				return ConvertToDateTime(strValue, strFromFormat);
			}
			catch
			{
				return DefaultValue;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       将字符串按照指定格式转换为时间数据，若没指定格式则尝试自动判别格式
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">表示时间数据的字符串</param>
		                                                                    /// <param name="strFromFormat">指定的转换格式，可以为空</param>
		                                                                    /// <returns>转换后的时间数据</returns>
		public static DateTime ConvertToDateTime(string strValue, string strFromFormat)
		{
			int num = 17;
			if (StringFormatHelper.IsBlankString(strFromFormat))
			{
				strValue = strValue.Trim();
				switch (strValue.Length)
				{
				case 8:
					strFromFormat = "yyyyMMdd";
					break;
				case 10:
					strFromFormat = ((strValue.IndexOf("-") < 0) ? "yyyyMMddHH" : "yyyy-MM-dd");
					break;
				case 12:
					strFromFormat = "yyyyMMddHHmm";
					break;
				case 13:
					strFromFormat = "yyyy-MM-dd HH";
					break;
				case 14:
					strFromFormat = "yyyyMMddHHmmss";
					break;
				case 16:
					strFromFormat = "yyyy-MM-dd HH:mm";
					break;
				case 19:
					strFromFormat = "yyyy-MM-dd HH:mm:ss";
					break;
				}
			}
			if (StringFormatHelper.IsBlankString(strFromFormat))
			{
				return DateTime.Parse(strValue);
			}
			new DateTimeFormatInfo();
			IFormatProvider provider = new CultureInfo("zh-CN", useUserOverride: false);
			return DateTime.ParseExact(strValue, strFromFormat, provider);
		}

		                                                                    /// <summary>
		                                                                    ///       格式化时间字符串
		                                                                    ///       </summary>
		                                                                    /// <param name="strValue">包含数据数据的字符串</param>
		                                                                    /// <param name="strFromFormat">转换前的时间字符串格式</param>
		                                                                    /// <param name="strToFormat">转换后的时间格式化字符串</param>
		                                                                    /// <returns>转换后的时间字符串，若发生错误则返回零长度的字符串</returns>
		public static string FormatDateTime(string strValue, string strFromFormat, string strToFormat)
		{
			try
			{
				return ConvertToDateTime(strValue, strFromFormat).ToString(strToFormat);
			}
			catch
			{
				return "";
			}
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个字符串是否表示一个 http 的 URL 
		                                                                    ///       </summary>
		                                                                    /// <param name="strData">字符串</param>
		                                                                    /// <returns>是否是HTTP的URL</returns>
		public static bool isHttpURL(string strData)
		{
			int num = 7;
			if (strData != null)
			{
				strData = strData.Trim().ToLower();
				return strData.StartsWith("http:                                                                    //");
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       加载字符串列表
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">定义字符串列表的XML文档URL</param>
		public static void LoadStringTable(string strURL)
		{
			int num = 8;
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = null;
			xmlDocument.Load(strURL);
			myStringTable = new NameValueCollection();
			foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
			{
				xmlElement = (childNode as XmlElement);
				if (xmlElement != null)
				{
					myStringTable.Set(xmlElement.GetAttribute("name"), xmlElement.InnerText);
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定名称的字符串项目
		                                                                    ///       </summary>
		                                                                    /// <param name="strName">字符串项目的名称</param>
		                                                                    /// <returns>字符串项目的值</returns>
		public static string GetStringValue(string strName)
		{
			if (myStringTable != null)
			{
				return myStringTable[strName];
			}
			return null;
		}

		public static string ToBase64String(string strData)
		{
			if (strData == null)
			{
				return null;
			}
			return Convert.ToBase64String(Encoding.GetEncoding(936).GetBytes(strData));
		}

		public static string FromBase64String(string strData)
		{
			if (strData == null)
			{
				return null;
			}
			byte[] bytes = Convert.FromBase64String(strData);
			char[] chars = Encoding.GetEncoding(936).GetChars(bytes);
			return new string(chars);
		}

		                                                                    /// <summary>
		                                                                    ///       判断一个字符的编码是否是属于Base64字符
		                                                                    ///       </summary>
		                                                                    /// <param name="intChar">字符的Ansi或Unicode编码</param>
		                                                                    /// <returns>判断结果</returns>
		public static bool isBase64Ascii(int intChar)
		{
			return (intChar >= 65 && intChar <= 90) || (intChar >= 97 && intChar <= 122) || (intChar >= 48 && intChar <= 57) || intChar == 43 || intChar == 47 || intChar == 61;
		}
	}
}
