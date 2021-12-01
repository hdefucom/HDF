using DCSoft.Common;
using DCSoft.TemperatureChart;
using System;
using System.Drawing;

namespace DCSoftDotfuscate
{
	internal class Class157
	{
		public static string smethod_0(DateTimePrecisionMode dateTimePrecisionMode_0)
		{
			int num = 0;
			switch (dateTimePrecisionMode_0)
			{
			default:
				return "yyyy-MM-dd HH:mm:ss";
			case DateTimePrecisionMode.NoLimited:
				return "yyyy-MM-dd HH:mm:ss.ff";
			case DateTimePrecisionMode.Second:
				return "yyyy-MM-dd HH:mm:ss";
			case DateTimePrecisionMode.Minute:
				return "yyyy-MM-dd HH:mm";
			case DateTimePrecisionMode.Hour:
				return "yyyy-MM-dd HH";
			case DateTimePrecisionMode.Day:
				return "yyyy-MM-dd";
			case DateTimePrecisionMode.Month:
				return "yyyy-MM";
			case DateTimePrecisionMode.Year:
				return "yyyy";
			}
		}

		public static DateTime smethod_1(DateTime dateTime_0, DateTimePrecisionMode dateTimePrecisionMode_0)
		{
			switch (dateTimePrecisionMode_0)
			{
			default:
				return dateTime_0;
			case DateTimePrecisionMode.NoLimited:
				return dateTime_0;
			case DateTimePrecisionMode.Second:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, dateTime_0.Second);
			case DateTimePrecisionMode.Minute:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, 0);
			case DateTimePrecisionMode.Hour:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, 0, 0);
			case DateTimePrecisionMode.Day:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day);
			case DateTimePrecisionMode.Month:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, 1);
			case DateTimePrecisionMode.Year:
				return new DateTime(dateTime_0.Year, 1, 1);
			}
		}

		public static float smethod_2(string string_0, float float_0, float float_1, ref string string_1, bool bool_0, bool bool_1)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				if (!bool_0)
				{
					string_1 = DCTimeLineStrings.RequiredValue;
				}
				return float.NaN;
			}
			float result = 0f;
			if (float.TryParse(string_0, out result))
			{
				if (smethod_3(result, float_0, float_1) && !bool_1)
				{
					string_1 = string.Format(DCTimeLineStrings.OutofRange_Max_Min, float_0, float_1);
				}
				return result;
			}
			return float.NaN;
		}

		public static bool smethod_3(float float_0, float float_1, float float_2)
		{
			if (TemperatureDocument.smethod_3(float_0))
			{
				return false;
			}
			if (!TemperatureDocument.smethod_3(float_2) && float_0 < float_2)
			{
				return true;
			}
			if (!TemperatureDocument.smethod_3(float_1) && float_0 > float_1)
			{
				return true;
			}
			return false;
		}

		public static string smethod_4(Color color_0, Color color_1)
		{
			return XMLSerializeHelper.ColorToString(color_0, color_1);
		}

		public static Color smethod_5(string string_0, Color color_0)
		{
			return XMLSerializeHelper.StringToColor(string_0, color_0);
		}
	}
}
