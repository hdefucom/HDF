using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class JavaScriptUtils
	{
		private const string EscapedUnicodeText = "!";

		internal static readonly bool[] SingleQuoteCharEscapeFlags;

		internal static readonly bool[] DoubleQuoteCharEscapeFlags;

		internal static readonly bool[] HtmlCharEscapeFlags;

		static JavaScriptUtils()
		{
			SingleQuoteCharEscapeFlags = new bool[128];
			DoubleQuoteCharEscapeFlags = new bool[128];
			HtmlCharEscapeFlags = new bool[128];
			IList<char> list = new List<char>
			{
				'\n',
				'\r',
				'\t',
				'\\',
				'\f',
				'\b'
			};
			for (int i = 0; i < 32; i++)
			{
				list.Add((char)i);
			}
			foreach (char item in Enumerable.Union(list, new char[1]
			{
				'\''
			}))
			{
				SingleQuoteCharEscapeFlags[item] = true;
			}
			foreach (char item2 in Enumerable.Union(list, new char[1]
			{
				'"'
			}))
			{
				DoubleQuoteCharEscapeFlags[item2] = true;
			}
			foreach (char item3 in Enumerable.Union(list, new char[5]
			{
				'"',
				'\'',
				'<',
				'>',
				'&'
			}))
			{
				HtmlCharEscapeFlags[item3] = true;
			}
		}

		public static bool[] GetCharEscapeFlags(StringEscapeHandling stringEscapeHandling, char quoteChar)
		{
			if (stringEscapeHandling == StringEscapeHandling.EscapeHtml)
			{
				return HtmlCharEscapeFlags;
			}
			if (quoteChar == '"')
			{
				return DoubleQuoteCharEscapeFlags;
			}
			return SingleQuoteCharEscapeFlags;
		}

		public static bool ShouldEscapeJavaScriptString(string string_0, bool[] charEscapeFlags)
		{
			if (string_0 == null)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < string_0.Length)
				{
					char c = string_0[num];
					if (c >= charEscapeFlags.Length || charEscapeFlags[c])
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

		public static void WriteEscapedJavaScriptString(TextWriter writer, string string_0, char delimiter, bool appendDelimiters, bool[] charEscapeFlags, StringEscapeHandling stringEscapeHandling, ref char[] writeBuffer)
		{
			int num = 15;
			if (appendDelimiters)
			{
				writer.Write(delimiter);
			}
			if (string_0 != null)
			{
				int num2 = 0;
				for (int i = 0; i < string_0.Length; i++)
				{
					char c = string_0[i];
					if (c < charEscapeFlags.Length && !charEscapeFlags[c])
					{
						continue;
					}
					string text;
					switch (c)
					{
					case '\\':
						text = "\\\\";
						break;
					case '\b':
						text = "\\b";
						break;
					case '\t':
						text = "\\t";
						break;
					case '\n':
						text = "\\n";
						break;
					case '\f':
						text = "\\f";
						break;
					case '\r':
						text = "\\r";
						break;
					default:
						if (c < charEscapeFlags.Length || stringEscapeHandling == StringEscapeHandling.EscapeNonAscii)
						{
							if (c == '\'' && stringEscapeHandling != StringEscapeHandling.EscapeHtml)
							{
								text = "\\'";
								break;
							}
							if (c == '"' && stringEscapeHandling != StringEscapeHandling.EscapeHtml)
							{
								text = "\\\"";
								break;
							}
							if (writeBuffer == null)
							{
								writeBuffer = new char[6];
							}
							StringUtils.ToCharAsUnicode(c, writeBuffer);
							text = "!";
						}
						else
						{
							text = null;
						}
						break;
					case '\u2028':
						text = "\\u2028";
						break;
					case '\u2029':
						text = "\\u2029";
						break;
					case '\u0085':
						text = "\\u0085";
						break;
					}
					if (text == null)
					{
						continue;
					}
					bool flag = string.Equals(text, "!");
					if (i > num2)
					{
						int num3 = i - num2 + (flag ? 6 : 0);
						int num4 = flag ? 6 : 0;
						if (writeBuffer == null || writeBuffer.Length < num3)
						{
							char[] array = new char[num3];
							if (flag)
							{
								Array.Copy(writeBuffer, array, 6);
							}
							writeBuffer = array;
						}
						string_0.CopyTo(num2, writeBuffer, num4, num3 - num4);
						writer.Write(writeBuffer, num4, num3 - num4);
					}
					num2 = i + 1;
					if (!flag)
					{
						writer.Write(text);
					}
					else
					{
						writer.Write(writeBuffer, 0, 6);
					}
				}
				if (num2 == 0)
				{
					writer.Write(string_0);
				}
				else
				{
					int num3 = string_0.Length - num2;
					if (writeBuffer == null || writeBuffer.Length < num3)
					{
						writeBuffer = new char[num3];
					}
					string_0.CopyTo(num2, writeBuffer, 0, num3);
					writer.Write(writeBuffer, 0, num3);
				}
			}
			if (appendDelimiters)
			{
				writer.Write(delimiter);
			}
		}

		public static string ToEscapedJavaScriptString(string value, char delimiter, bool appendDelimiters)
		{
			return ToEscapedJavaScriptString(value, delimiter, appendDelimiters, StringEscapeHandling.Default);
		}

		public static string ToEscapedJavaScriptString(string value, char delimiter, bool appendDelimiters, StringEscapeHandling stringEscapeHandling)
		{
			bool[] charEscapeFlags = GetCharEscapeFlags(stringEscapeHandling, delimiter);
			using (StringWriter stringWriter = StringUtils.CreateStringWriter(StringUtils.GetLength(value) ?? 16))
			{
				char[] writeBuffer = null;
				WriteEscapedJavaScriptString(stringWriter, value, delimiter, appendDelimiters, charEscapeFlags, stringEscapeHandling, ref writeBuffer);
				return stringWriter.ToString();
			}
		}
	}
}
