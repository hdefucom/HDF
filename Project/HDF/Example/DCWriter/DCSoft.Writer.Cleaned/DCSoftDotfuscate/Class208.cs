using System;
using System.Drawing;

namespace DCSoftDotfuscate
{
	internal class Class208
	{
		public static readonly float float_0;

		public static readonly float float_1;

		public static readonly float float_2;

		public static readonly float float_3;

		public static readonly float float_4;

		public static readonly float float_5;

		public static readonly float float_6;

		public static readonly float float_7;

		static Class208()
		{
			float_0 = 75f;
			float_1 = 1f;
			float_2 = 300f;
			float_3 = 25.4f;
			float_4 = 96f;
			float_5 = 72f;
			float_6 = 100f;
			float_7 = 254f;
			Graphics graphics = Graphics.FromHwnd(new IntPtr(0));
			float_4 = graphics.DpiX;
			graphics.Dispose();
		}

		public static float smethod_0(GraphicsUnit graphicsUnit_0)
		{
			switch (graphicsUnit_0)
			{
			default:
				return 1f;
			case GraphicsUnit.Display:
				return float_0;
			case GraphicsUnit.Pixel:
				return float_4;
			case GraphicsUnit.Point:
				return float_5;
			case GraphicsUnit.Inch:
				return float_1;
			case GraphicsUnit.Document:
				return float_2;
			case GraphicsUnit.Millimeter:
				return float_3;
			}
		}
	}
}
