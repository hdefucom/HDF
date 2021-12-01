using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 长度单位转换类
    /// </summary>
    public sealed class GraphicsUnitConvert
    {
        private static float fDpi = 96;
        public static float Dpi
        {
            get { return fDpi; }
            set { fDpi = value; }
        }

        #region 构造函数 Convert **************************
        public static double Convert(  double vValue, System.Drawing.GraphicsUnit OldUnit, System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return vValue;
            else
                return vValue * GetRate(NewUnit, OldUnit);
        }
        public static float Convert(  float vValue,  System.Drawing.GraphicsUnit OldUnit, System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return vValue;
            else
                return (float)(vValue * GetRate(NewUnit, OldUnit));
        }
        public static int Convert(  int vValue,   System.Drawing.GraphicsUnit OldUnit, System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return vValue;
            else
                return (int)(vValue * GetRate(NewUnit, OldUnit));
        }
        public static System.Drawing.Point Convert(System.Drawing.Point p, System.Drawing.GraphicsUnit OldUnit, System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return p;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new System.Drawing.Point( (int)(p.X * rate),(int)(p.Y * rate));
            }
        }
        public static System.Drawing.Point Convert( int x,int y,System.Drawing.GraphicsUnit OldUnit,System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return new System.Drawing.Point(x, y);
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new System.Drawing.Point(
                    (int)(x * rate),
                    (int)(y * rate));
            }
        }
        public static System.Drawing.Size Convert(System.Drawing.Size size,System.Drawing.GraphicsUnit OldUnit,System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return size;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new System.Drawing.Size(
                    (int)(size.Width * rate),
                    (int)(size.Height * rate));
            }
        }
        public static System.Drawing.SizeF Convert(System.Drawing.SizeF size,System.Drawing.GraphicsUnit OldUnit,System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
                return size;
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new System.Drawing.SizeF(
                    (float)(size.Width * rate),
                    (float)(size.Height * rate));
            }
        }

        public static System.Drawing.Rectangle Convert(System.Drawing.Rectangle rect,System.Drawing.GraphicsUnit OldUnit,System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
            {
                return rect;
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new System.Drawing.Rectangle(
                    (int)(rect.X * rate),
                    (int)(rect.Y * rate),
                    (int)(rect.Width * rate),
                    (int)(rect.Height * rate));
            }
        }
        public static System.Drawing.RectangleF Convert(System.Drawing.RectangleF rect,System.Drawing.GraphicsUnit OldUnit,System.Drawing.GraphicsUnit NewUnit)
        {
            if (OldUnit == NewUnit)
            {
                return rect;
            }
            else
            {
                double rate = GetRate(NewUnit, OldUnit);
                return new System.Drawing.RectangleF(
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
        public static double GetRate(System.Drawing.GraphicsUnit NewUnit, System.Drawing.GraphicsUnit OldUnit)
        {
            return GetUnit(OldUnit) / GetUnit(NewUnit);
        }

        public static double GetDpi(System.Drawing.GraphicsUnit unit)
        {
            switch (unit)
            {
                case System.Drawing.GraphicsUnit.Display:
                    return fDpi;
                case System.Drawing.GraphicsUnit.Document:
                    return 300;
                case System.Drawing.GraphicsUnit.Inch:
                    return 1;
                case System.Drawing.GraphicsUnit.Millimeter:
                    return 25.4;
                case System.Drawing.GraphicsUnit.Pixel:
                    return fDpi;
                case System.Drawing.GraphicsUnit.Point:
                    return 72;
            }
            return fDpi;
        }

        /// <summary>
        /// 获得一个单位占据的英寸数
        /// </summary>
        /// <param name="unit">单位类型</param>
        /// <returns>英寸数</returns>
        private static double GetUnit(System.Drawing.GraphicsUnit unit)
        {
            switch (unit)
            {
                case System.Drawing.GraphicsUnit.Display:
                    return 1 / fDpi;
                case System.Drawing.GraphicsUnit.Document:
                    return 1 / 300.0;
                case System.Drawing.GraphicsUnit.Inch:
                    return 1;
                case System.Drawing.GraphicsUnit.Millimeter:
                    return 1 / 25.4;
                case System.Drawing.GraphicsUnit.Pixel:
                    return 1 / fDpi;
                case System.Drawing.GraphicsUnit.Point:
                    return 1 / 72.0;
                default:
                    throw new System.NotSupportedException("Not support " + unit.ToString());
            }
        }


        private GraphicsUnitConvert()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }
}
