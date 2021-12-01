using DCSoftDotfuscate;
using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       绘图单位转换
	///       </summary>
	[ComVisible(false)]
	public sealed class GraphicsUnitConvert
	{
		private static float fDpi;

		/// <summary>
		///       屏幕使用的DPI值
		///       </summary>
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

		static GraphicsUnitConvert()
		{
			fDpi = 96f;
			using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
			{
				fDpi = graphics.DpiX;
			}
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="vValue">长度值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static double Convert(double vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return vValue;
			}
			return vValue * GetRate(NewUnit, OldUnit);
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="vValue">长度值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static float Convert(float vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return vValue;
			}
			return (float)((double)vValue * GetRate(NewUnit, OldUnit));
		}

		/// <summary>
		///       将长度转换为厘米
		///       </summary>
		/// <param name="vValue">长度值</param>
		/// <param name="oldUnit">长度单位</param>
		/// <returns>转换的厘米值</returns>
		public static float ConvertToCM(float vValue, GraphicsUnit oldUnit)
		{
			return (float)((double)Convert(vValue, oldUnit, GraphicsUnit.Millimeter) / 10.0);
		}

		/// <summary>
		///       将厘米长度值转换为指定单位的长度
		///       </summary>
		/// <param name="cmValue">厘米长度值</param>
		/// <param name="unit">新的长度单位</param>
		/// <returns>转换结果</returns>
		public static float ConvertFromCM(float cmValue, GraphicsUnit unit)
		{
			return Convert(cmValue * 10f, GraphicsUnit.Millimeter, unit);
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="vValue">长度值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static int Convert(int vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return vValue;
			}
			return (int)((double)vValue * GetRate(NewUnit, OldUnit));
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="p">长度值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static Point Convert(Point point_0, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return point_0;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new Point((int)((double)point_0.X * rate), (int)((double)point_0.Y * rate));
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="p">长度值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static PointF Convert(PointF pointF_0, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return pointF_0;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new PointF((float)((double)pointF_0.X * rate), (float)((double)pointF_0.Y * rate));
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="x">X坐标值</param>
		/// <param name="y">Y坐标值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static Point Convert(int int_0, int int_1, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return new Point(int_0, int_1);
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new Point((int)((double)int_0 * rate), (int)((double)int_1 * rate));
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="size">旧值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static Size Convert(Size size, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return size;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new Size((int)((double)size.Width * rate), (int)((double)size.Height * rate));
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="size">旧值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static SizeF Convert(SizeF size, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return size;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new SizeF((float)((double)size.Width * rate), (float)((double)size.Height * rate));
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="rect">旧值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static Rectangle Convert(Rectangle rect, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return rect;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new Rectangle((int)((double)rect.X * rate), (int)((double)rect.Y * rate), (int)((double)rect.Width * rate), (int)((double)rect.Height * rate));
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="rect">旧值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static RectangleF Convert(RectangleF rect, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return rect;
			}
			double rate = GetRate(NewUnit, OldUnit);
			return new RectangleF((float)((double)rect.X * rate), (float)((double)rect.Y * rate), (float)((double)rect.Width * rate), (float)((double)rect.Height * rate));
		}

		/// <summary>
		///       将一个长度从旧单位换算成新单位使用的比率
		///       </summary>
		/// <param name="NewUnit">新单位</param>
		/// <param name="OldUnit">旧单位</param>
		/// <returns>比率数</returns>
		public static double GetRate(GraphicsUnit NewUnit, GraphicsUnit OldUnit)
		{
			return GetUnit(OldUnit) / GetUnit(NewUnit);
		}

		/// <summary>
		///       将像素单位转换为打印单位
		///       </summary>
		/// <param name="v">像素单位</param>
		/// <returns>转换后的打印单位</returns>
		public static double PixelToPrintUnit(double double_0)
		{
			return Convert(double_0, GraphicsUnit.Pixel, GraphicsUnit.Inch) * 100.0;
		}

		/// <summary>
		///       将指定的单位转换为打印单位
		///       </summary>
		/// <param name="v">像素单位</param>
		/// <param name="unit">旧单位</param>
		/// <returns>转换后的打印单位</returns>
		public static double UnitToPintUnit(double double_0, GraphicsUnit unit)
		{
			return Convert(double_0, unit, GraphicsUnit.Inch) * 100.0;
		}

		/// <summary>
		///       将像素单位转换为单位
		///       </summary>
		/// <param name="v">像素单位</param>
		/// <param name="unit">新的单位</param>
		/// <returns>转换后的单位</returns>
		public static double PixelToUnit(double double_0, GraphicsUnit unit)
		{
			return Convert(double_0, GraphicsUnit.Pixel, unit);
		}

		/// <summary>
		///       获得指定度量单位下的DPI值
		///       </summary>
		/// <param name="unit">指定的度量单位</param>
		/// <returns>DPI值</returns>
		public static double GetDpi(GraphicsUnit unit)
		{
			switch (unit)
			{
			default:
				return fDpi;
			case GraphicsUnit.Display:
				return fDpi;
			case GraphicsUnit.Pixel:
				return fDpi;
			case GraphicsUnit.Point:
				return 72.0;
			case GraphicsUnit.Inch:
				return 1.0;
			case GraphicsUnit.Document:
				return 300.0;
			case GraphicsUnit.Millimeter:
				return 25.4;
			}
		}

		/// <summary>
		///       获得一个单位占据的英寸数
		///       </summary>
		/// <param name="unit">单位类型</param>
		/// <returns>英寸数</returns>
		public static double GetUnit(GraphicsUnit unit)
		{
			int num = 11;
			switch (unit)
			{
			default:
				throw new NotSupportedException("Not support " + unit);
			case GraphicsUnit.Display:
				return 1f / fDpi;
			case GraphicsUnit.Pixel:
				return 1f / fDpi;
			case GraphicsUnit.Point:
				return 0.013888888888888888;
			case GraphicsUnit.Inch:
				return 1.0;
			case GraphicsUnit.Document:
				return 0.0033333333333333335;
			case GraphicsUnit.Millimeter:
				return 0.03937007874015748;
			}
		}

		/// <summary>
		///       进行单位换算
		///       </summary>
		/// <param name="Value">旧值</param>
		/// <param name="OldUnit">旧单位</param>
		/// <param name="NewUnit">新单位</param>
		/// <returns>换算结果</returns>
		public static double Convert(double Value, LengthUnit OldUnit, LengthUnit NewUnit)
		{
			if (OldUnit == NewUnit)
			{
				return Value;
			}
			return Value * GetUnit(OldUnit) / GetUnit(NewUnit);
		}

		/// <summary>
		///       获得一个单位占据的英寸数
		///       </summary>
		/// <param name="unit">单位类型</param>
		/// <returns>英寸数</returns>
		public static double GetUnit(LengthUnit unit)
		{
			int num = 2;
			switch (unit)
			{
			default:
				throw new NotSupportedException("Not support " + unit);
			case LengthUnit.Document:
				return 0.0033333333333333335;
			case LengthUnit.Inch:
				return 1.0;
			case LengthUnit.Millimeter:
				return 0.03937007874015748;
			case LengthUnit.Pixel:
				return 1f / fDpi;
			case LengthUnit.Point:
				return 0.013888888888888888;
			case LengthUnit.Centimerter:
				return 0.39370078740157477;
			case LengthUnit.Twips:
				return 0.00069444444444444447;
			}
		}

		/// <summary>
		///       将指定单位的指定长度转化为 Twips 单位
		///       </summary>
		/// <param name="Value">长度</param>
		/// <param name="unit">度量单位</param>
		/// <returns>转化的 Twips 数</returns>
		public static int ToTwips(int Value, GraphicsUnit unit)
		{
			double unit2 = GetUnit(unit);
			return (int)((double)Value * unit2 * 1440.0);
		}

		/// <summary>
		///       将指定单位的指定长度转化为 Twips 单位
		///       </summary>
		/// <param name="Value">长度</param>
		/// <param name="unit">度量单位</param>
		/// <returns>转化的 Twips 数</returns>
		public static int ToTwips(float Value, GraphicsUnit unit)
		{
			double unit2 = GetUnit(unit);
			return (int)((double)Value * unit2 * 1440.0);
		}

		/// <summary>
		///       将指定的Twips值转化为指定单位的数值
		///       </summary>
		/// <param name="Twips">Twips值</param>
		/// <param name="unit">要转化的目标单位</param>
		/// <returns>转化的长度值</returns>
		public static int FromTwips(int Twips, GraphicsUnit unit)
		{
			double unit2 = GetUnit(unit);
			return (int)((double)Twips / (unit2 * 1440.0));
		}

		/// <summary>
		///       将指定的Twips值转化为指定单位的数值
		///       </summary>
		/// <param name="twips">Twips值</param>
		/// <param name="unit">要转化的目标单位</param>
		/// <returns>转化的长度值</returns>
		public static double FromTwips(double twips, GraphicsUnit unit)
		{
			double unit2 = GetUnit(unit);
			return twips / (unit2 * 1440.0);
		}

		public static double ToPixel(double Value, GraphicsUnit unit, float float_0)
		{
			int num = 10;
			if (float_0 <= 0f)
			{
				throw new ArgumentOutOfRangeException("dpi=" + float_0);
			}
			double unit2 = GetUnit(unit);
			return Value * unit2 * (double)float_0;
		}

		public static double FromPixel(double pixelValue, GraphicsUnit unit, float float_0)
		{
			int num = 5;
			if (float_0 <= 0f)
			{
				throw new ArgumentOutOfRangeException("dpi=" + float_0);
			}
			double unit2 = GetUnit(unit);
			return pixelValue / ((double)float_0 * unit2);
		}

		/// <summary>
		///       将CSS样式的长度字符串转换为数值
		///       </summary>
		/// <param name="CSSLength">CSS样式的长度字符串</param>
		/// <param name="unit">要转换为单位</param>
		/// <param name="DefaultValue">默认值</param>
		/// <returns>转换后的数值</returns>
		public static double ParseCSSLength(string CSSLength, GraphicsUnit unit, double DefaultValue)
		{
			int num = 3;
			CSSLength = CSSLength.Trim();
			int length = CSSLength.Length;
			double result = 0.0;
			int num2 = 0;
			while (true)
			{
				if (num2 < length)
				{
					char value = CSSLength[num2];
					if ("-.0123456789".IndexOf(value) < 0 && num2 > 0 && double.TryParse(CSSLength.Substring(0, num2), NumberStyles.Any, null, out result))
					{
						break;
					}
					num2++;
					continue;
				}
				if (double.TryParse(CSSLength, NumberStyles.Any, null, out result))
				{
					return Convert(result, GraphicsUnit.Pixel, unit);
				}
				return DefaultValue;
			}
			switch (CSSLength.Substring(num2).Trim().ToLower())
			{
			case "cm":
				return Convert(result, GraphicsUnit.Millimeter, unit) * 10.0;
			case "mm":
				return Convert(result, GraphicsUnit.Millimeter, unit);
			case "in":
				return Convert(result, GraphicsUnit.Inch, unit);
			case "pt":
				return Convert(result, GraphicsUnit.Point, unit);
			case "pc":
				return Convert(result, GraphicsUnit.Point, unit) * 12.0;
			case "px":
				return Convert(result, GraphicsUnit.Pixel, unit);
			default:
				return Convert(result, GraphicsUnit.Pixel, unit);
			}
		}

		public static string ToCSSLength(double Value, GraphicsUnit unit, GEnum87 cssUnit)
		{
			int num = 14;
			double num2 = 0.0;
			string str = "";
			switch (cssUnit)
			{
			case GEnum87.const_0:
				num2 = Convert(Value, unit, GraphicsUnit.Millimeter) / 10.0;
				str = "cm";
				break;
			case GEnum87.const_1:
				num2 = Convert(Value, unit, GraphicsUnit.Millimeter);
				str = "mm";
				break;
			case GEnum87.const_2:
				num2 = Convert(Value, unit, GraphicsUnit.Inch);
				str = "in";
				break;
			case GEnum87.const_3:
				num2 = Convert(Value, unit, GraphicsUnit.Point);
				str = "pt";
				break;
			case GEnum87.const_4:
				num2 = Convert(Value, unit, GraphicsUnit.Point) / 12.0;
				str = "pc";
				break;
			case GEnum87.const_5:
				num2 = Convert(Value, unit, GraphicsUnit.Pixel);
				str = "px";
				break;
			}
			return num2.ToString("0.0000") + str;
		}

		/// <summary>
		///       对象不可实例化
		///       </summary>
		private GraphicsUnitConvert()
		{
		}
	}
}
