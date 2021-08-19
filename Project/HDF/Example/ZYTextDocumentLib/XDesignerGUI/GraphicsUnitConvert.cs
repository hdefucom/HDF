using System;
using System.Drawing;

namespace XDesignerGUI
{
	public sealed class GraphicsUnitConvert
	{
		private static float fDpi = 96f;

		public static float Dpi
		{
			get
			{
				return fDpi;
			}
			set
			{
				fDpi = value;
			}
		}

		public static double Convert(double vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return vValue;
			}
			return vValue * GetRate(NewUnit, OldUnit);
		}

		public static float Convert(float vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return vValue;
			}
			return (float)((double)vValue * GetRate(NewUnit, OldUnit));
		}

		public static int Convert(int vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return vValue;
			}
			return (int)((double)vValue * GetRate(NewUnit, OldUnit));
		}

		public static Point Convert(Point p, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return p;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new Point((int)((double)p.X * rate), (int)((double)p.Y * rate));
		}

		public static Point Convert(int x, int y, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return new Point(x, y);
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new Point((int)((double)x * rate), (int)((double)y * rate));
		}

		public static Size Convert(Size size, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return size;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new Size((int)((double)size.Width * rate), (int)((double)size.Height * rate));
		}

		public static SizeF Convert(SizeF size, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return size;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new SizeF((float)((double)size.Width * rate), (float)((double)size.Height * rate));
		}

		public static Rectangle Convert(Rectangle rect, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return rect;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new Rectangle((int)((double)rect.X * rate), (int)((double)rect.Y * rate), (int)((double)rect.Width * rate), (int)((double)rect.Height * rate));
		}

		public static RectangleF Convert(RectangleF rect, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return rect;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new RectangleF((float)((double)rect.X * rate), (float)((double)rect.Y * rate), (float)((double)rect.Width * rate), (float)((double)rect.Height * rate));
		}

		public static double GetRate(GraphicsUnit NewUnit, GraphicsUnit OldUnit)
		{
			return GetUnit(OldUnit) / GetUnit(NewUnit);
		}

		public static double GetDpi(GraphicsUnit unit)
		{
			switch (unit)
			{
			case GraphicsUnit.Display:
				return fDpi;
			case GraphicsUnit.Document:
				return 300.0;
			case GraphicsUnit.Inch:
				return 1.0;
			case GraphicsUnit.Millimeter:
				return 25.4;
			case GraphicsUnit.Pixel:
				return fDpi;
			case GraphicsUnit.Point:
				return 72.0;
			default:
				return fDpi;
			}
		}

		private static double GetUnit(GraphicsUnit unit)
		{
			switch (unit)
			{
			case GraphicsUnit.Display:
				return 1f / fDpi;
			case GraphicsUnit.Document:
				return 0.0033333333333333335;
			case GraphicsUnit.Inch:
				return 1.0;
			case GraphicsUnit.Millimeter:
				return 0.03937007874015748;
			case GraphicsUnit.Pixel:
				return 1f / fDpi;
			case GraphicsUnit.Point:
				return 0.013888888888888888;
			default:
				throw new NotSupportedException("Not support " + unit);
			}
		}

		private GraphicsUnitConvert()
		{
		}
	}
}
