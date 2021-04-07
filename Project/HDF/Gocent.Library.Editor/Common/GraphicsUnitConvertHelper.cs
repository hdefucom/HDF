using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gocent.Library.Editor.Common
{
    /// <summary>
    /// 长度单位转换类
    /// </summary>
    public static class GraphicsUnitConvertHelper
    {
        public static float Dpi { get; set; }

        static GraphicsUnitConvertHelper()
        {
            Dpi = 96f;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                Dpi = graphics.DpiX;
            }
        }


        #region Convert Method
        public static double Convert(this double vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            return OldUnit == NewUnit ? vValue : vValue * GetRate(NewUnit, OldUnit);
        }
        public static float Convert(this float vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            return OldUnit == NewUnit ? vValue : (float)(vValue * GetRate(NewUnit, OldUnit));
        }
        public static int Convert(this int vValue, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            return OldUnit == NewUnit ? vValue : (int)(vValue * GetRate(NewUnit, OldUnit));
        }
        public static Point Convert(this Point p, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return p;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new Point((int)(p.X * rate), (int)(p.Y * rate));
            }
        }
        public static PointF Convert(this PointF p, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return p;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new PointF((float)(p.X * rate), (float)(p.Y * rate));
            }
        }
        public static Point Convert(int x, int y, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return new Point(x, y);
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new Point((int)(x * rate), (int)(y * rate));
            }
        }
        public static PointF Convert(float x, float y, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return new PointF(x, y);
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new PointF((float)(x * rate), (float)(y * rate));
            }
        }
        public static Size Convert(this Size size, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return size;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new Size((int)(size.Width * rate), (int)(size.Height * rate));
            }
        }
        public static SizeF Convert(this SizeF size, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return size;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new SizeF((float)(size.Width * rate), (float)(size.Height * rate));
            }
        }
        public static Rectangle Convert(this Rectangle rect, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return rect;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new Rectangle(
                    (int)(rect.X * rate),
                    (int)(rect.Y * rate),
                    (int)(rect.Width * rate),
                    (int)(rect.Height * rate));
            }
        }
        public static RectangleF Convert(this RectangleF rect, GraphicsUnit OldUnit, GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return rect;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new RectangleF(
                    (float)(rect.X * rate),
                    (float)(rect.Y * rate),
                    (float)(rect.Width * rate),
                    (float)(rect.Height * rate));
            }
        }
        #endregion

        /// <summary>
        /// 将一个长度从旧单位换算成新单位使用的比率
        /// </summary>
        /// <param name="NewUnit">新单位</param>
        /// <param name="OldUnit">旧单位</param>
        /// <returns>比率数</returns>
        public static double GetRate(this GraphicsUnit NewUnit, GraphicsUnit OldUnit)
        {
            return GetUnit(OldUnit) / GetUnit(NewUnit);
        }

        public static double GetDpi(GraphicsUnit unit)
        {
            switch (unit)
            {
                case GraphicsUnit.Display:
                    return Dpi;
                case GraphicsUnit.Pixel:
                    return Dpi;
                case GraphicsUnit.Point:
                    return 72;
                case GraphicsUnit.Inch:
                    return 1;
                case GraphicsUnit.Document:
                    return 300;
                case GraphicsUnit.Millimeter:
                    return 25.4;
                default:
                    return Dpi;
            }
        }

        /// <summary>
        /// 获得一个单位占据的英寸数
        /// </summary>
        /// <param name="unit">单位类型</param>
        /// <returns>英寸数</returns>
        private static double GetUnit(GraphicsUnit unit)
        {
            switch (unit)
            {
                case GraphicsUnit.Display:
                    return 1 / Dpi;
                case GraphicsUnit.Pixel:
                    return 1 / Dpi;
                case GraphicsUnit.Point:
                    return 1 / 72.0;
                case GraphicsUnit.Inch:
                    return 1;
                case GraphicsUnit.Document:
                    return 1 / 300d;
                case GraphicsUnit.Millimeter:
                    return 1 / 25.4;
                default:
                    throw new NotSupportedException("Not support " + unit.ToString());
            }
        }


    }















}
