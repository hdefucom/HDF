using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal static class DateTimeUtils
	{
		private const int DaysPer100Years = 36524;

		private const int DaysPer400Years = 146097;

		private const int DaysPer4Years = 1461;

		private const int DaysPerYear = 365;

		private const long TicksPerDay = 864000000000L;

		internal static readonly long InitialJavaScriptDateTicks;

		private static readonly int[] DaysToMonth365;

		private static readonly int[] DaysToMonth366;

		static DateTimeUtils()
		{
			InitialJavaScriptDateTicks = 621355968000000000L;
			DaysToMonth365 = new int[13]
			{
				0,
				31,
				59,
				90,
				120,
				151,
				181,
				212,
				243,
				273,
				304,
				334,
				365
			};
			DaysToMonth366 = new int[13]
			{
				0,
				31,
				60,
				91,
				121,
				152,
				182,
				213,
				244,
				274,
				305,
				335,
				366
			};
		}

		public static TimeSpan GetUtcOffset(DateTime dateTime_0)
		{
			return TimeZone.CurrentTimeZone.GetUtcOffset(dateTime_0);
		}

		public static XmlDateTimeSerializationMode ToSerializationMode(DateTimeKind kind)
		{
			int num = 17;
			switch (kind)
			{
			default:
				throw MiscellaneousUtils.CreateArgumentOutOfRangeException("kind", kind, "Unexpected DateTimeKind value.");
			case DateTimeKind.Unspecified:
				return XmlDateTimeSerializationMode.Unspecified;
			case DateTimeKind.Utc:
				return XmlDateTimeSerializationMode.Utc;
			case DateTimeKind.Local:
				return XmlDateTimeSerializationMode.Local;
			}
		}

		internal static DateTime EnsureDateTime(DateTime value, DateTimeZoneHandling timeZone)
		{
			int num = 3;
			switch (timeZone)
			{
			default:
				throw new ArgumentException("Invalid date time handling value.");
			case DateTimeZoneHandling.Local:
				value = SwitchToLocalTime(value);
				break;
			case DateTimeZoneHandling.Utc:
				value = SwitchToUtcTime(value);
				break;
			case DateTimeZoneHandling.Unspecified:
				value = new DateTime(value.Ticks, DateTimeKind.Unspecified);
				break;
			case DateTimeZoneHandling.RoundtripKind:
				break;
			}
			return value;
		}

		private static DateTime SwitchToLocalTime(DateTime value)
		{
			switch (value.Kind)
			{
			default:
				return value;
			case DateTimeKind.Unspecified:
				return new DateTime(value.Ticks, DateTimeKind.Local);
			case DateTimeKind.Utc:
				return value.ToLocalTime();
			case DateTimeKind.Local:
				return value;
			}
		}

		private static DateTime SwitchToUtcTime(DateTime value)
		{
			switch (value.Kind)
			{
			default:
				return value;
			case DateTimeKind.Unspecified:
				return new DateTime(value.Ticks, DateTimeKind.Utc);
			case DateTimeKind.Utc:
				return value;
			case DateTimeKind.Local:
				return value.ToUniversalTime();
			}
		}

		private static long ToUniversalTicks(DateTime dateTime)
		{
			if (dateTime.Kind == DateTimeKind.Utc)
			{
				return dateTime.Ticks;
			}
			return ToUniversalTicks(dateTime, GetUtcOffset(dateTime));
		}

		private static long ToUniversalTicks(DateTime dateTime, TimeSpan offset)
		{
			if (dateTime.Kind == DateTimeKind.Utc || dateTime == DateTime.MaxValue || dateTime == DateTime.MinValue)
			{
				return dateTime.Ticks;
			}
			long num = dateTime.Ticks - offset.Ticks;
			if (num > 3155378975999999999L)
			{
				return 3155378975999999999L;
			}
			if (num < 0L)
			{
				return 0L;
			}
			return num;
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, TimeSpan offset)
		{
			long universialTicks = ToUniversalTicks(dateTime, offset);
			return UniversialTicksToJavaScriptTicks(universialTicks);
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime)
		{
			return ConvertDateTimeToJavaScriptTicks(dateTime, convertToUtc: true);
		}

		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, bool convertToUtc)
		{
			long universialTicks = convertToUtc ? ToUniversalTicks(dateTime) : dateTime.Ticks;
			return UniversialTicksToJavaScriptTicks(universialTicks);
		}

		private static long UniversialTicksToJavaScriptTicks(long universialTicks)
		{
			return (universialTicks - InitialJavaScriptDateTicks) / 10000L;
		}

		internal static DateTime ConvertJavaScriptTicksToDateTime(long javaScriptTicks)
		{
			return new DateTime(javaScriptTicks * 10000L + InitialJavaScriptDateTicks, DateTimeKind.Utc);
		}

		internal static bool TryParseDateIso(string text, DateParseHandling dateParseHandling, DateTimeZoneHandling dateTimeZoneHandling, out object object_0)
		{
			DateTimeParser dateTimeParser = default(DateTimeParser);
			if (!dateTimeParser.Parse(text))
			{
				object_0 = null;
				return false;
			}
			DateTime dateTime = new DateTime(dateTimeParser.Year, dateTimeParser.Month, dateTimeParser.Day, dateTimeParser.Hour, dateTimeParser.Minute, dateTimeParser.Second).AddTicks(dateTimeParser.Fraction);
			switch (dateTimeParser.Zone)
			{
			case ParserTimeZone.Utc:
				dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Utc);
				break;
			case ParserTimeZone.LocalWestOfUtc:
			{
				TimeSpan timeSpan = new TimeSpan(dateTimeParser.ZoneHour, dateTimeParser.ZoneMinute, 0);
				long num = dateTime.Ticks + timeSpan.Ticks;
				if (num <= DateTime.MaxValue.Ticks)
				{
					dateTime = new DateTime(num, DateTimeKind.Utc).ToLocalTime();
					break;
				}
				num += GetUtcOffset(dateTime).Ticks;
				if (num > DateTime.MaxValue.Ticks)
				{
					num = DateTime.MaxValue.Ticks;
				}
				dateTime = new DateTime(num, DateTimeKind.Local);
				break;
			}
			case ParserTimeZone.LocalEastOfUtc:
			{
				TimeSpan timeSpan = new TimeSpan(dateTimeParser.ZoneHour, dateTimeParser.ZoneMinute, 0);
				long num = dateTime.Ticks - timeSpan.Ticks;
				if (num >= DateTime.MinValue.Ticks)
				{
					dateTime = new DateTime(num, DateTimeKind.Utc).ToLocalTime();
					break;
				}
				num += GetUtcOffset(dateTime).Ticks;
				if (num < DateTime.MinValue.Ticks)
				{
					num = DateTime.MinValue.Ticks;
				}
				dateTime = new DateTime(num, DateTimeKind.Local);
				break;
			}
			}
			object_0 = EnsureDateTime(dateTime, dateTimeZoneHandling);
			return true;
		}

		internal static bool TryParseDateTime(string string_0, DateParseHandling dateParseHandling, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out object object_0)
		{
			int num = 11;
			if (string_0.Length > 0)
			{
				if (string_0[0] == '/')
				{
					if (string_0.StartsWith("/Date(", StringComparison.Ordinal) && string_0.EndsWith(")/", StringComparison.Ordinal) && TryParseDateMicrosoft(string_0, dateParseHandling, dateTimeZoneHandling, out object_0))
					{
						return true;
					}
				}
				else if (string_0.Length >= 19 && string_0.Length <= 40 && char.IsDigit(string_0[0]) && string_0[10] == 'T' && TryParseDateIso(string_0, dateParseHandling, dateTimeZoneHandling, out object_0))
				{
					return true;
				}
				if (!string.IsNullOrEmpty(dateFormatString) && TryParseDateExact(string_0, dateParseHandling, dateTimeZoneHandling, dateFormatString, culture, out object_0))
				{
					return true;
				}
			}
			object_0 = null;
			return false;
		}

		private static bool TryParseDateMicrosoft(string text, DateParseHandling dateParseHandling, DateTimeZoneHandling dateTimeZoneHandling, out object object_0)
		{
			string text2 = text.Substring(6, text.Length - 8);
			DateTimeKind dateTimeKind = DateTimeKind.Utc;
			int num = text2.IndexOf('+', 1);
			if (num == -1)
			{
				num = text2.IndexOf('-', 1);
			}
			if (num != -1)
			{
				dateTimeKind = DateTimeKind.Local;
				text2 = text2.Substring(0, num);
			}
			if (!long.TryParse(text2, NumberStyles.Integer, CultureInfo.InvariantCulture, out long result))
			{
				object_0 = null;
				return false;
			}
			DateTime dateTime = ConvertJavaScriptTicksToDateTime(result);
			DateTime value;
			switch (dateTimeKind)
			{
			case DateTimeKind.Unspecified:
				value = DateTime.SpecifyKind(dateTime.ToLocalTime(), DateTimeKind.Unspecified);
				break;
			default:
				value = dateTime;
				break;
			case DateTimeKind.Local:
				value = dateTime.ToLocalTime();
				break;
			}
			object_0 = EnsureDateTime(value, dateTimeZoneHandling);
			return true;
		}

		private static bool TryParseDateExact(string text, DateParseHandling dateParseHandling, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out object object_0)
		{
			if (DateTime.TryParseExact(text, dateFormatString, culture, DateTimeStyles.RoundtripKind, out DateTime result))
			{
				result = EnsureDateTime(result, dateTimeZoneHandling);
				object_0 = result;
				return true;
			}
			object_0 = null;
			return false;
		}

		internal static void WriteDateTimeString(TextWriter writer, DateTime value, DateFormatHandling format, string formatString, CultureInfo culture)
		{
			if (string.IsNullOrEmpty(formatString))
			{
				char[] array = new char[64];
				int count = WriteDateTimeString(array, 0, value, null, value.Kind, format);
				writer.Write(array, 0, count);
			}
			else
			{
				writer.Write(value.ToString(formatString, culture));
			}
		}

		internal static int WriteDateTimeString(char[] chars, int start, DateTime value, TimeSpan? offset, DateTimeKind kind, DateFormatHandling format)
		{
			int num = 16;
			int num2 = start;
			if (format == DateFormatHandling.MicrosoftDateFormat)
			{
				TimeSpan offset2 = offset ?? GetUtcOffset(value);
				long num3 = ConvertDateTimeToJavaScriptTicks(value, offset2);
				"\\/Date(".CopyTo(0, chars, num2, 7);
				num2 += 7;
				string text = num3.ToString(CultureInfo.InvariantCulture);
				text.CopyTo(0, chars, num2, text.Length);
				num2 += text.Length;
				switch (kind)
				{
				case DateTimeKind.Unspecified:
					if (value != DateTime.MaxValue && value != DateTime.MinValue)
					{
						num2 = WriteDateTimeOffset(chars, num2, offset2, format);
					}
					break;
				case DateTimeKind.Local:
					num2 = WriteDateTimeOffset(chars, num2, offset2, format);
					break;
				}
				")\\/".CopyTo(0, chars, num2, 3);
				num2 += 3;
			}
			else
			{
				num2 = WriteDefaultIsoDate(chars, num2, value);
				switch (kind)
				{
				case DateTimeKind.Utc:
					chars[num2++] = 'Z';
					break;
				case DateTimeKind.Local:
					num2 = WriteDateTimeOffset(chars, num2, offset ?? GetUtcOffset(value), format);
					break;
				}
			}
			return num2;
		}

		internal static int WriteDefaultIsoDate(char[] chars, int start, DateTime dateTime_0)
		{
			int num = 19;
			GetDateValues(dateTime_0, out int year, out int month, out int int_);
			CopyIntToCharArray(chars, start, year, 4);
			chars[start + 4] = '-';
			CopyIntToCharArray(chars, start + 5, month, 2);
			chars[start + 7] = '-';
			CopyIntToCharArray(chars, start + 8, int_, 2);
			chars[start + 10] = 'T';
			CopyIntToCharArray(chars, start + 11, dateTime_0.Hour, 2);
			chars[start + 13] = ':';
			CopyIntToCharArray(chars, start + 14, dateTime_0.Minute, 2);
			chars[start + 16] = ':';
			CopyIntToCharArray(chars, start + 17, dateTime_0.Second, 2);
			int num2 = (int)(dateTime_0.Ticks % 10000000L);
			if (num2 != 0)
			{
				int num3 = 7;
				while (num2 % 10 == 0)
				{
					num3--;
					num2 /= 10;
				}
				chars[start + 19] = '.';
				CopyIntToCharArray(chars, start + 20, num2, num3);
				num += num3 + 1;
			}
			return start + num;
		}

		private static void CopyIntToCharArray(char[] chars, int start, int value, int digits)
		{
			while (digits-- != 0)
			{
				chars[start + digits] = (char)(value % 10 + 48);
				value /= 10;
			}
		}

		internal static int WriteDateTimeOffset(char[] chars, int start, TimeSpan offset, DateFormatHandling format)
		{
			chars[start++] = ((offset.Ticks >= 0L) ? '+' : '-');
			int value = Math.Abs(offset.Hours);
			CopyIntToCharArray(chars, start, value, 2);
			start += 2;
			if (format == DateFormatHandling.IsoDateFormat)
			{
				chars[start++] = ':';
			}
			int value2 = Math.Abs(offset.Minutes);
			CopyIntToCharArray(chars, start, value2, 2);
			start += 2;
			return start;
		}

		private static void GetDateValues(DateTime dateTime_0, out int year, out int month, out int int_0)
		{
			long ticks = dateTime_0.Ticks;
			int num = (int)(ticks / 864000000000L);
			int num2 = num / 146097;
			num -= num2 * 146097;
			int num3 = num / 36524;
			if (num3 == 4)
			{
				num3 = 3;
			}
			num -= num3 * 36524;
			int num4 = num / 1461;
			num -= num4 * 1461;
			int num5 = num / 365;
			if (num5 == 4)
			{
				num5 = 3;
			}
			year = num2 * 400 + num3 * 100 + num4 * 4 + num5 + 1;
			num -= num5 * 365;
			int[] array = (num5 == 3 && (num4 != 24 || num3 == 3)) ? DaysToMonth366 : DaysToMonth365;
			int i;
			for (i = num >> 6; num >= array[i]; i++)
			{
			}
			month = i;
			int_0 = num - array[i - 1] + 1;
		}
	}
}
