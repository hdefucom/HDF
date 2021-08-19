using DCSoft.Common;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass517 : GClass504
	{
		private DateTime dateTime_0 = DateTime.MinValue;

		public GClass517(DateTime dateTime_1)
		{
			dateTime_0 = dateTime_1;
		}

		public DateTime method_8()
		{
			return dateTime_0;
		}

		public void method_9(DateTime dateTime_1)
		{
			dateTime_0 = dateTime_1;
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			string str = "(D:";
			str += method_10();
			str += method_11();
			str += method_12();
			str += method_13();
			str += method_14();
			str += method_15();
			str += method_16();
			str += ")";
			streamWriter_0.Write(str);
		}

		private string method_10()
		{
			return dateTime_0.Year.ToString("D4");
		}

		private string method_11()
		{
			return dateTime_0.Month.ToString("D2");
		}

		private string method_12()
		{
			return dateTime_0.Day.ToString("D2");
		}

		private string method_13()
		{
			return dateTime_0.Hour.ToString("D2");
		}

		private string method_14()
		{
			return dateTime_0.Minute.ToString("D2");
		}

		private string method_15()
		{
			return dateTime_0.Second.ToString("D2");
		}

		private string method_16()
		{
			int num = 9;
			TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(dateTime_0);
			string str = "";
			if (utcOffset.Ticks < 0L)
			{
				str += "-";
			}
			else
			{
				if (utcOffset.Ticks <= 0L)
				{
					return "Z";
				}
				str += "+";
			}
			str += utcOffset.Hours.ToString("D2");
			str += "'";
			str += utcOffset.Minutes.ToString("D2");
			return str + "'";
		}

		public override string ToString()
		{
			return "DateTime:" + FormatUtils.ToYYYY_MM_DD_HH_MM_SS(method_8());
		}
	}
}
