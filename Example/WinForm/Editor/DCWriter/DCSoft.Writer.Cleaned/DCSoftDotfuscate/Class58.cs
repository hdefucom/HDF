using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.Drawing;

namespace DCSoftDotfuscate
{
	internal class Class58
	{
		public static bool smethod_0(DateTime dateTime_0)
		{
			return dateTime_0 == DateTime.MaxValue || dateTime_0 == DateTime.MinValue || dateTime_0 == DocumentComment.dateTime_0;
		}

		public static string smethod_1(DateTime dateTime_0)
		{
			return dateTime_0.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public static string smethod_2(Color color_0)
		{
			return XMLSerializeHelper.ColorToString(color_0);
		}
	}
}
