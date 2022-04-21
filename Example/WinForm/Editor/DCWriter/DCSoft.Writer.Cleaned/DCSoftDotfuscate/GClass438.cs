using DCSoft.Common;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	
	public static class GClass438
	{
		private static Dictionary<Color, SolidBrush> dictionary_0 = new Dictionary<Color, SolidBrush>();

		private static Dictionary<Color, Pen> dictionary_1 = new Dictionary<Color, Pen>();

		public static SolidBrush smethod_0(Color color_0)
		{
			if (dictionary_0.ContainsKey(color_0))
			{
				return dictionary_0[color_0];
			}
			SolidBrush solidBrush = new SolidBrush(color_0);
			dictionary_0[color_0] = solidBrush;
			return solidBrush;
		}

		public static Pen smethod_1(Color color_0)
		{
			if (dictionary_1.ContainsKey(color_0))
			{
				return dictionary_1[color_0];
			}
			Pen pen = new Pen(color_0);
			dictionary_1[color_0] = pen;
			return pen;
		}

		public static void smethod_2()
		{
			foreach (SolidBrush value in dictionary_0.Values)
			{
				value.Dispose();
			}
			dictionary_0.Clear();
			foreach (Pen value2 in dictionary_1.Values)
			{
				value2.Dispose();
			}
			dictionary_1.Clear();
		}
	}
}
