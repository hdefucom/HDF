using DCSoft.FriedmanCurveChart;
using System;

namespace DCSoftDotfuscate
{
	internal class Class167
	{
		public static DateTime smethod_0(DateTime dateTime_0, double double_0, DCFriedmanCurveUnit dcfriedmanCurveUnit_0, bool bool_0)
		{
			DateTime result = dateTime_0;
			switch (dcfriedmanCurveUnit_0)
			{
			case DCFriedmanCurveUnit.Second:
				result = result.AddSeconds(double_0);
				break;
			case DCFriedmanCurveUnit.Minute:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, result.Day, result.Hour, result.Minute, 0);
				}
				result = result.AddMinutes(double_0);
				break;
			case DCFriedmanCurveUnit.Hour:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, result.Day, result.Hour, 0, 0);
				}
				result = result.AddHours(double_0);
				break;
			case DCFriedmanCurveUnit.Day:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, result.Day, 0, 0, 0);
				}
				result = result.AddDays(double_0);
				break;
			case DCFriedmanCurveUnit.Week:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, result.Day, 0, 0, 0);
				}
				result = result.AddDays(double_0);
				break;
			case DCFriedmanCurveUnit.Month:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, 1, 0, 0, 0);
				}
				result = result.AddMonths((int)double_0);
				break;
			case DCFriedmanCurveUnit.Year:
				if (bool_0)
				{
					result = new DateTime(result.Year, 1, 1, 0, 0, 0);
				}
				result = result.AddYears((int)double_0);
				break;
			}
			return result;
		}
	}
}
