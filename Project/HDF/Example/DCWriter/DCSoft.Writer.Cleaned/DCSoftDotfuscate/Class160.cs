using DCSoft.TemperatureChart;
using System;

namespace DCSoftDotfuscate
{
	internal class Class160
	{
		public static DateTime smethod_0(DateTime dateTime_0, double double_0, DCTimeUnit dctimeUnit_0, bool bool_0)
		{
			DateTime result = dateTime_0;
			switch (dctimeUnit_0)
			{
			case DCTimeUnit.Second:
				result = result.AddSeconds(double_0);
				break;
			case DCTimeUnit.Minute:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, result.Day, result.Hour, result.Minute, 0);
				}
				result = result.AddMinutes(double_0);
				break;
			case DCTimeUnit.Hour:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, result.Day, result.Hour, 0, 0);
				}
				result = result.AddHours(double_0);
				break;
			case DCTimeUnit.Day:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, result.Day, 0, 0, 0);
				}
				result = result.AddDays(double_0);
				break;
			case DCTimeUnit.Week:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, result.Day, 0, 0, 0);
				}
				result = result.AddDays(double_0);
				break;
			case DCTimeUnit.Month:
				if (bool_0)
				{
					result = new DateTime(result.Year, result.Month, 1, 0, 0, 0);
				}
				result = result.AddMonths((int)double_0);
				break;
			case DCTimeUnit.Year:
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
