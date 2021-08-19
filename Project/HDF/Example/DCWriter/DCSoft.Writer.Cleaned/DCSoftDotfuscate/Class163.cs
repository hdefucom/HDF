using DCSoft.Common;
using DCSoft.FriedmanCurveChart;
using System;
using System.Drawing;

namespace DCSoftDotfuscate
{
	internal class Class163
	{
		public static string smethod_0(FCDateTimePrecisionMode fcdateTimePrecisionMode_0)
		{
			int num = 15;
			switch (fcdateTimePrecisionMode_0)
			{
			default:
				return "yyyy-MM-dd HH:mm:ss";
			case FCDateTimePrecisionMode.NoLimited:
				return "yyyy-MM-dd HH:mm:ss.ff";
			case FCDateTimePrecisionMode.Second:
				return "yyyy-MM-dd HH:mm:ss";
			case FCDateTimePrecisionMode.Minute:
				return "yyyy-MM-dd HH:mm";
			case FCDateTimePrecisionMode.Hour:
				return "yyyy-MM-dd HH";
			case FCDateTimePrecisionMode.Day:
				return "yyyy-MM-dd";
			case FCDateTimePrecisionMode.Month:
				return "yyyy-MM";
			case FCDateTimePrecisionMode.Year:
				return "yyyy";
			}
		}

		public static DateTime smethod_1(DateTime dateTime_0, FCDateTimePrecisionMode fcdateTimePrecisionMode_0)
		{
			switch (fcdateTimePrecisionMode_0)
			{
			default:
				return dateTime_0;
			case FCDateTimePrecisionMode.NoLimited:
				return dateTime_0;
			case FCDateTimePrecisionMode.Second:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, dateTime_0.Second);
			case FCDateTimePrecisionMode.Minute:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, dateTime_0.Minute, 0);
			case FCDateTimePrecisionMode.Hour:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day, dateTime_0.Hour, 0, 0);
			case FCDateTimePrecisionMode.Day:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, dateTime_0.Day);
			case FCDateTimePrecisionMode.Month:
				return new DateTime(dateTime_0.Year, dateTime_0.Month, 1);
			case FCDateTimePrecisionMode.Year:
				return new DateTime(dateTime_0.Year, 1, 1);
			}
		}

		public static float smethod_2(string string_0, float float_0, float float_1, ref string string_1, bool bool_0, bool bool_1)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				if (!bool_0)
				{
					string_1 = DCFriedmanCurveStrings.RequiredValue;
				}
				return float.NaN;
			}
			float result = 0f;
			if (float.TryParse(string_0, out result))
			{
				if (smethod_3(result, float_0, float_1) && !bool_1)
				{
					string_1 = string.Format(DCFriedmanCurveStrings.OutofRange_Max_Min, float_0, float_1);
				}
				return result;
			}
			return float.NaN;
		}

		public static bool smethod_3(float float_0, float float_1, float float_2)
		{
			if (FriedmanCurveDocument.smethod_3(float_0))
			{
				return false;
			}
			if (!FriedmanCurveDocument.smethod_3(float_2) && float_0 < float_2)
			{
				return true;
			}
			if (!FriedmanCurveDocument.smethod_3(float_1) && float_0 > float_1)
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
