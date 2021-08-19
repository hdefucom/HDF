using Open_Newtonsoft_Json.Serialization;
using Open_Newtonsoft_Json.Utilities.LinqBridge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class StringUtils
	{
		public const string CarriageReturnLineFeed = "\r\n";

		public const string Empty = "";

		public const char CarriageReturn = '\r';

		public const char LineFeed = '\n';

		public const char Tab = '\t';

		public static string FormatWith(string format, IFormatProvider provider, object arg0)
		{
			return FormatWith(format, provider, new object[1]
			{
				arg0
			});
		}

		public static string FormatWith(string format, IFormatProvider provider, object arg0, object arg1)
		{
			return FormatWith(format, provider, new object[2]
			{
				arg0,
				arg1
			});
		}

		public static string FormatWith(string format, IFormatProvider provider, object arg0, object arg1, object arg2)
		{
			return FormatWith(format, provider, new object[3]
			{
				arg0,
				arg1,
				arg2
			});
		}

		public static string FormatWith(string format, IFormatProvider provider, object arg0, object arg1, object arg2, object arg3)
		{
			return FormatWith(format, provider, new object[4]
			{
				arg0,
				arg1,
				arg2,
				arg3
			});
		}

		private static string FormatWith(string format, IFormatProvider provider, params object[] args)
		{
			ValidationUtils.ArgumentNotNull(format, "format");
			return string.Format(provider, format, args);
		}

		/// <summary>
		///       Determines whether the string is all white space. Empty string will return false.
		///       </summary>
		/// <param name="s">The string to test whether it is all white space.</param>
		/// <returns>
		///   <c>true</c> if the string is all white space; otherwise, <c>false</c>.
		///       </returns>
		public static bool IsWhiteSpace(string string_0)
		{
			int num = 7;
			if (string_0 == null)
			{
				throw new ArgumentNullException("s");
			}
			if (string_0.Length == 0)
			{
				return false;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < string_0.Length)
				{
					if (!char.IsWhiteSpace(string_0[num2]))
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		/// <summary>
		///       Nulls an empty string.
		///       </summary>
		/// <param name="s">The string.</param>
		/// <returns>Null if the string was null, otherwise the string unchanged.</returns>
		public static string NullEmptyString(string string_0)
		{
			return string.IsNullOrEmpty(string_0) ? null : string_0;
		}

		public static StringWriter CreateStringWriter(int capacity)
		{
			StringBuilder sb = new StringBuilder(capacity);
			return new StringWriter(sb, CultureInfo.InvariantCulture);
		}

		public static int? GetLength(string value)
		{
			return value?.Length;
		}

		public static void ToCharAsUnicode(char char_0, char[] buffer)
		{
			buffer[0] = '\\';
			buffer[1] = 'u';
			buffer[2] = MathUtils.IntToHex(((int)char_0 >> 12) & 0xF);
			buffer[3] = MathUtils.IntToHex(((int)char_0 >> 8) & 0xF);
			buffer[4] = MathUtils.IntToHex(((int)char_0 >> 4) & 0xF);
			buffer[5] = MathUtils.IntToHex(char_0 & 0xF);
		}

		public static TSource ForgivingCaseSensitiveFind<TSource>(IEnumerable<TSource> source, Func<TSource, string> valueSelector, string testValue)
		{
			int num = 11;
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (valueSelector == null)
			{
				throw new ArgumentNullException("valueSelector");
			}
			IEnumerable<TSource> source2 = Enumerable.Where(source, (TSource gparam_0) => string.Equals(valueSelector(gparam_0), testValue, StringComparison.OrdinalIgnoreCase));
			if (Enumerable.Count(source2) <= 1)
			{
				return Enumerable.SingleOrDefault(source2);
			}
			IEnumerable<TSource> source3 = Enumerable.Where(source, (TSource gparam_0) => string.Equals(valueSelector(gparam_0), testValue, StringComparison.Ordinal));
			return Enumerable.SingleOrDefault(source3);
		}

		public static string ToCamelCase(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return string_0;
			}
			if (!char.IsUpper(string_0[0]))
			{
				return string_0;
			}
			char[] array = string_0.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = i + 1 < array.Length;
				if (i > 0 && flag && !char.IsUpper(array[i + 1]))
				{
					break;
				}
				array[i] = char.ToLower(array[i], CultureInfo.InvariantCulture);
			}
			return new string(array);
		}

		public static bool IsHighSurrogate(char char_0)
		{
			return char.IsHighSurrogate(char_0);
		}

		public static bool IsLowSurrogate(char char_0)
		{
			return char.IsLowSurrogate(char_0);
		}

		public static bool StartsWith(string source, char value)
		{
			return source.Length > 0 && source[0] == value;
		}

		public static bool EndsWith(string source, char value)
		{
			return source.Length > 0 && source[source.Length - 1] == value;
		}
	}
}
