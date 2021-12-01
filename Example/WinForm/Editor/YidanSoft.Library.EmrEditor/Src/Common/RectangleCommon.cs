using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
    /// <summary>
    /// 定义矩形相关的例称模块，本对象不能实例化
    /// </summary>
    public sealed class RectangleCommon
    {
        /// <summary>
        /// 获得两个矩形间的一个过渡矩形
        /// </summary>
        /// <param name="rect1">原始矩形</param>
        /// <param name="rect2">目标矩形</param>
        /// <param name="rate">过渡系数，若为0则返回原始矩形，若为1则返回目标矩形</param>
        /// <returns>过渡矩形</returns>
        public static System.Drawing.Rectangle GetMiddleRectangle(
            System.Drawing.Rectangle rect1,
            System.Drawing.Rectangle rect2,
            double rate)
        {
            int left = rect1.Left + (int)((rect2.Left - rect1.Left) * rate);
            int top = rect1.Top + (int)((rect2.Top - rect1.Top) * rate);
            int w = rect1.Width + (int)((rect2.Width - rect1.Width) * rate);
            int h = rect1.Height + (int)((rect2.Height - rect1.Height) * rate);
            return new System.Drawing.Rectangle(left, top, w, h);
        }
        /// <summary>
        /// 修改矩形的宽度和高度
        /// </summary>
        /// <param name="rect">矩形区域</param>
        /// <param name="dsize">大小改变量</param>
        /// <returns>获得的新矩形</returns>
        public static System.Drawing.Rectangle ReSize(System.Drawing.Rectangle rect, int dsize)
        {
            return new System.Drawing.Rectangle(rect.Left, rect.Top, rect.Width + dsize, rect.Height + dsize);
        }
        /// <summary>
        /// 计算内置旋转矩形的大小
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static System.Drawing.Size InnerRoteteRectangleSize(int Width, int Height, double angle)
        {
            if (Width <= 0 || Height <= 0)
                return System.Drawing.Size.Empty;
            double a = System.Math.Atan2(Height, Width);
            double r = Math.Sqrt(Width * Width + Height * Height) / 2;
            double w = r * Math.Cos(a - angle);
            double h = r * Math.Sin(a + angle);
            double rate = w * 2 / Width;
            if (rate < h * 2 / Height)
                rate = h * 2 / Height;
            return new System.Drawing.Size((int)(Width / rate), (int)(Height / rate));
        }

        /// <summary>
        /// 逆时针旋转矩形
        /// </summary>
        /// <param name="o">原点</param>
        /// <param name="rect">旋转的矩形</param>
        /// <param name="angle">弧度</param>
        /// <returns>旋转后的矩形</returns>
        public static System.Drawing.Rectangle RotateRectangle(
            System.Drawing.Point o,
            System.Drawing.Rectangle rect,
            double angle)
        {
            System.Drawing.Point[] ps = To4Points(rect);
            for (int iCount = 0; iCount < ps.Length; iCount++)
            {
                ps[iCount] = MathCommon.RotatePoint(o, ps[iCount], angle);
            }
            return PointBuffer.GetBounds(ps);
        }

        /// <summary>
        /// 进行矩形对齐操作
        /// </summary>
        /// <param name="MainRect">主矩形</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="Align">水平对齐方式 1:左对齐 2:居中对齐 3:右对齐 其他:不进行对齐操作</param>
        /// <param name="VAlign">垂直对齐方式 1:左对齐 2:居中对齐 3:右对齐 其他:不进行对齐操作</param>
        /// <returns>对齐操作产生的矩形</returns>
        public static System.Drawing.Rectangle AlignRect(
            System.Drawing.Rectangle MainRect,
            int width,
            int height,
            int Align,
            int VAlign)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
            if (Align == 1)
                rect.X = MainRect.Left;
            else if (Align == 2)
                rect.X = MainRect.Left + (MainRect.Width - width) / 2;
            else if (Align == 3)
                rect.X = MainRect.Right - width;

            if (VAlign == 1)
                rect.Y = MainRect.Top;
            else if (VAlign == 2)
                rect.Y = MainRect.Top + (MainRect.Height - height) / 2;
            else if (VAlign == 3)
                rect.Y = MainRect.Bottom - height;
            return rect;
        }//public static System.Drawing.Rectangle AlignRect( System.Drawing.Rectangle MainRect , int width , int height , int Align , int VAlign)


        /// <summary>
        /// 将整数矩形转换为浮点数矩形
        /// </summary>
        /// <param name="rect">整数矩形对象</param>
        /// <returns>转换所得的浮点数矩形</returns>
        public static System.Drawing.RectangleF ToRectangleF(System.Drawing.Rectangle rect)
        {
            return new System.Drawing.RectangleF(rect.Left, rect.Top, rect.Width, rect.Height);
        }

        /// <summary>
        /// 将浮点数矩形转换为整数矩形
        /// </summary>
        /// <param name="rect">浮点数矩形</param>
        /// <returns>转换所得的整数矩形</returns>
        public static System.Drawing.Rectangle ToRectangle(System.Drawing.RectangleF rect)
        {
            return new System.Drawing.Rectangle((int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Height);
        }
        /// <summary>
        /// 在绘图操作中判断指定的大小是否表示有效的大小
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns>是否表示有效大小,若为有效大小则需要进行绘制操作,否则不需要进行绘制操作</returns>
        public static bool PaintInvalidSize(int width, int height)
        {
            if (width > 0 && height >= 0)
                return true;
            if (height > 0 && width >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// 获得内置矩形
        /// </summary>
        /// <param name="rect">外围的矩形</param>
        /// <param name="Align">水平对齐方式</param>
        /// <param name="LineAlign">垂直对齐方式</param>
        /// <param name="InnerRectSize">内置矩形的大小</param>
        /// <returns>内置矩形</returns>
        public static System.Drawing.Rectangle GetInnerRectangle(
            System.Drawing.Rectangle rect,
            System.Drawing.StringAlignment Align,
            System.Drawing.StringAlignment LineAlign,
            System.Drawing.Size InnerRectSize)
        {
            int left = 0;
            int top = 0;
            if (Align == System.Drawing.StringAlignment.Near)
                left = rect.Left;
            else if (Align == System.Drawing.StringAlignment.Center)
                left = rect.Left + (rect.Width - InnerRectSize.Width) / 2;
            else
                left = rect.Right - InnerRectSize.Width;
            if (LineAlign == System.Drawing.StringAlignment.Near)
                top = rect.Top;
            else if (LineAlign == System.Drawing.StringAlignment.Center)
                top = rect.Top + (rect.Height - InnerRectSize.Height) / 2;
            else
                top = rect.Bottom - InnerRectSize.Height;
            return new System.Drawing.Rectangle(left, top, InnerRectSize.Width, InnerRectSize.Height);
        }

        /// <summary>
        /// 返回表示矩形左上点，右上点和右下点坐标的点结构体数组
        /// </summary>
        /// <param name="rect">矩形区域</param>
        /// <returns>包含3个元素的点结构体数组</returns>
        public static System.Drawing.Point[] To3Points(System.Drawing.Rectangle rect)
        {
            System.Drawing.Point[] p = new System.Drawing.Point[3];
            p[0] = new System.Drawing.Point(rect.X, rect.Y);
            p[1] = new System.Drawing.Point(rect.Right, rect.Y);
            p[2] = new System.Drawing.Point(rect.Right, rect.Bottom);
            return p;
        }
        /// <summary>
        /// 返回表示矩形四个顶点坐标的点结构体数组
        /// </summary>
        /// <param name="rect">矩形区域</param>
        /// <returns>包含4个元素的点结构体数组</returns>
        public static System.Drawing.Point[] To4Points(System.Drawing.Rectangle rect)
        {
            System.Drawing.Point[] p = new System.Drawing.Point[4];
            p[0] = new System.Drawing.Point(rect.X, rect.Y);
            p[1] = new System.Drawing.Point(rect.Right, rect.Y);
            p[2] = new System.Drawing.Point(rect.Right, rect.Bottom);
            p[3] = new System.Drawing.Point(rect.Left, rect.Bottom);
            return p;
        }

        /// <summary>
        /// 返回表示矩形四个顶点坐标的点结构体数组,并进行闭合
        /// </summary>
        /// <param name="rect">矩形区域</param>
        /// <returns>包含5个元素的点结构体数组</returns>
        public static System.Drawing.Point[] To5Points(System.Drawing.Rectangle rect)
        {
            System.Drawing.Point[] p = new System.Drawing.Point[5];
            p[0] = new System.Drawing.Point(rect.X, rect.Y);
            p[1] = new System.Drawing.Point(rect.Right, rect.Y);
            p[2] = new System.Drawing.Point(rect.Right, rect.Bottom);
            p[3] = new System.Drawing.Point(rect.Left, rect.Bottom);
            p[4] = p[0];
            return p;
        }

        public static System.Drawing.Rectangle GetSquare(System.Drawing.Rectangle rect)
        {
            if (rect.Width == rect.Height)
                return rect;
            if (rect.Width > rect.Height)
                return new System.Drawing.Rectangle(
                    rect.Left + (rect.Width - rect.Height) / 2,
                    rect.Top,
                    rect.Height,
                    rect.Height);
            else
                return new System.Drawing.Rectangle(
                    rect.Left,
                    rect.Top + (rect.Height - rect.Width) / 2,
                    rect.Width,
                    rect.Width);
        }
        /// <summary>
        /// 返回整数矩形的中心坐标
        /// </summary>
        /// <param name="rect">整数矩形对象</param>
        /// <returns>矩形中心坐标</returns>
        public static System.Drawing.Point Center(System.Drawing.Rectangle rect)
        {
            return new System.Drawing.Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
        }

        /// <summary>
        /// 获得以指定矩形的中心为中心的指定大小的矩形对象
        /// </summary>
        /// <param name="rect">原始矩形区域</param>
        /// <param name="size">指定的矩形大小</param>
        /// <returns>获得的矩形对象</returns>
        public static System.Drawing.Rectangle Center(
            System.Drawing.Rectangle rect,
            System.Drawing.Size size)
        {
            return new System.Drawing.Rectangle(
                rect.Left + (rect.Width - size.Width) / 2,
                rect.Top + (rect.Height - size.Height) / 2,
                size.Width,
                size.Height);
        }

        /// <summary>
        /// 获得以指定矩形的中心为中心的指定大小的矩形对象
        /// </summary>
        /// <param name="rect">原始矩形区域</param>
        /// <param name="size">指定的矩形大小</param>
        /// <returns>获得的矩形对象</returns>
        public static System.Drawing.RectangleF Center(
            System.Drawing.RectangleF rect,
            System.Drawing.SizeF size)
        {
            return new System.Drawing.RectangleF(
                rect.Left + (rect.Width - size.Width) / 2,
                rect.Top + (rect.Height - size.Height) / 2,
                size.Width,
                size.Height);
        }

        /// <summary>
        /// 移动指定的矩形,使其中心为指定点
        /// </summary>
        /// <param name="rect">原始矩形区域</param>
        /// <param name="x">中心点X坐标</param>
        /// <param name="y">中心点Y坐标</param>
        /// <returns>移动后的矩形区域</returns>
        public static System.Drawing.Rectangle SetCenter(System.Drawing.Rectangle rect, int x, int y)
        {
            return new System.Drawing.Rectangle(
                x - rect.Width / 2,
                y - rect.Height / 2,
                rect.Width,
                rect.Height);
        }

        /// <summary>
        /// 移动指定的矩形,使其中心为指定点
        /// </summary>
        /// <param name="rect">原始矩形区域</param>
        /// <param name="x">中心点X坐标</param>
        /// <param name="y">中心点Y坐标</param>
        /// <returns>移动后的矩形区域</returns>
        public System.Drawing.RectangleF SetCenter(System.Drawing.RectangleF rect, float x, float y)
        {
            return new System.Drawing.RectangleF(
                (float)(x - rect.Width / 2.0),
                (float)(y - rect.Height / 2.0),
                rect.Width,
                rect.Height);
        }
        //		
        //		public static System.Drawing.Rectangle ConvertToRectangle( System.Drawing.RectangleF rf)
        //		{
        //			return new System.Drawing.Rectangle( (int)rf.Left , (int)rf.Top , (int)rf.Width , (int)rf.Height );
        //		}

        /// <summary>
        /// 判断指定点是指定的矩形的那个顶点,返回-1:不是顶点 0:为左上点 1:右上点 2:右下点 3:左下点
        /// </summary>
        /// <param name="vRect">矩形对象</param>
        /// <param name="p">点对象</param>
        /// <returns>返回值</returns>
        public static int GetAcmeIndex(System.Drawing.Rectangle vRect, System.Drawing.Point p)
        {
            if (vRect.IsEmpty == false)
            {
                if (p.Y == vRect.Y)
                {
                    if (p.X == vRect.X)
                        return 0;
                    if (p.X == vRect.Right)
                        return 1;
                }
                else if (p.Y == vRect.Bottom)
                {
                    if (p.X == vRect.Right)
                        return 2;
                    if (p.X == vRect.X)
                        return 3;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获得指定矩形指定顶端的坐标,矩形顶点编号为 0:为左上点 1:右上点 2:右下点 3:左下点
        /// </summary>
        /// <param name="vRect"></param>
        /// <param name="AcmeIndex"></param>
        /// <returns></returns>
        public static System.Drawing.Point GetAcmePos(System.Drawing.Rectangle vRect, int AcmeIndex)
        {
            switch (AcmeIndex)
            {
                case 0:
                    return vRect.Location;
                case 1:
                    return new System.Drawing.Point(vRect.Right, vRect.Y);
                case 2:
                    return new System.Drawing.Point(vRect.Right, vRect.Bottom);
                case 3:
                    return new System.Drawing.Point(vRect.X, vRect.Bottom);
            }
            return System.Drawing.Point.Empty;
        }

        /// <summary>
        /// 根据两点坐标获得方框对象
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static System.Drawing.Rectangle GetRectangle(int x1, int y1, int x2, int y2)
        {
            System.Drawing.Rectangle myRect = System.Drawing.Rectangle.Empty;
            if (x1 < x2)
            {
                myRect.X = x1;
                myRect.Width = x2 - x1;
            }
            else
            {
                myRect.X = x2;
                myRect.Width = x1 - x2;
            }
            if (y1 < y2)
            {
                myRect.Y = y1;
                myRect.Height = y2 - y1;
            }
            else
            {
                myRect.Y = y2;
                myRect.Height = y1 - y2;
            }
            if (myRect.Width < 1) myRect.Width = 1;
            if (myRect.Height < 1) myRect.Height = 1;
            return myRect;
        }


        /// <summary>
        /// 根据两点坐标获得方框对象
        /// </summary>
        /// <param name="p1">第一个点的坐标</param>
        /// <param name="p2">第二个点的坐标</param>
        /// <returns></returns>
        public static System.Drawing.Rectangle GetRectangle(System.Drawing.Point p1, System.Drawing.Point p2)
        {
            return GetRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static int MoveXInto(int x, System.Drawing.Rectangle Bounds)
        {
            if (Bounds.IsEmpty)
                return x;
            if (x < Bounds.Left)
                x = Bounds.Left;
            else if (x > Bounds.Right)
                x = Bounds.Right;
            return x;
        }

        public static int MoveYInto(int y, System.Drawing.Rectangle Bounds)
        {
            if (Bounds.IsEmpty)
                return y;
            if (y < Bounds.Top)
                y = Bounds.Top;
            else if (y > Bounds.Bottom)
                y = Bounds.Bottom;
            return y;
        }

        /// <summary>
        /// 移动一个矩形,致使在指定的矩形中
        /// </summary>
        /// <param name="rect">要修正的矩形</param>
        /// <param name="Bounds">容器矩形</param>
        /// <returns>修正后的矩形</returns>
        public static System.Drawing.Rectangle MoveInto(
            System.Drawing.Rectangle rect,
            System.Drawing.Rectangle Bounds)
        {
            if (Bounds.IsEmpty)
                return rect;
            if (rect.Right > Bounds.Right)
                rect.X = Bounds.Right - rect.Width;
            if (rect.Bottom > Bounds.Bottom)
                rect.Y = Bounds.Bottom - rect.Height;
            if (rect.X < Bounds.Left)
                rect.X = Bounds.Left;
            if (rect.Y < Bounds.Top)
                rect.Y = Bounds.Top;
            return rect;
        }

        public static System.Drawing.Point MoveInto(
            System.Drawing.Point p,
            System.Drawing.Rectangle Bounds)
        {
            if (!Bounds.IsEmpty)
            {
                if (p.X < Bounds.Left)
                    p.X = Bounds.Left;
                if (p.X >= Bounds.Right)
                    p.X = Bounds.Right;
                if (p.Y < Bounds.Top)
                    p.Y = Bounds.Top;
                if (p.Y >= Bounds.Bottom)
                    p.Y = Bounds.Bottom;
            }
            return p;
        }

        public static System.Drawing.Point GetBorderPoint
            (int intLeft,
            int intTop,
            int intWidth,
            int intHeight,
            int iPos,
            int iSplit)
        {
            System.Drawing.Point myPoint = System.Drawing.Point.Empty;
            if (iSplit <= 0)
                return myPoint;
            // 修正参数,保证参数在 0 到 4倍的Split之间
            iPos %= (iSplit * 4);
            if (iPos < 0)
                iPos += (iSplit * 4);
            // 计算坐标
            if (iPos >= 0 && iPos < iSplit)
            {
                myPoint.X = intLeft + (intWidth * iPos) / iSplit;
                myPoint.Y = intTop;
            }
            else if (iPos >= iSplit && iPos < iSplit * 2)
            {
                myPoint.X = intLeft + intWidth;
                myPoint.Y = intTop + (intHeight * (iPos - iSplit)) / iSplit;
            }
            else if (iPos >= iSplit * 2 && iPos < iSplit * 3)
            {
                myPoint.X = intLeft + (intWidth * (iSplit * 3 - iPos)) / iSplit;
                myPoint.Y = intTop + intHeight;
            }
            else
            {
                myPoint.X = intLeft;
                myPoint.Y = intTop + (intHeight * (iSplit * 4 - iPos)) / iSplit;
            }
            // 返回结果
            return myPoint;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 修改矩形的宽度和高度
        /// </summary>
        /// <param name="rect">矩形区域</param>
        /// <param name="dsize">大小改变量</param>
        /// <returns>获得的新矩形</returns>
        public static System.Drawing.RectangleF ReSize(System.Drawing.RectangleF rect, float dsize)
        {
            return new System.Drawing.RectangleF(rect.Left, rect.Top, rect.Width + dsize, rect.Height + dsize);
        }
        /// <summary>
        /// 计算内置旋转矩形的大小
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static System.Drawing.SizeF InnerRoteteRectangleSize(float Width, float Height, double angle)
        {
            if (Width <= 0 || Height <= 0)
                return System.Drawing.SizeF.Empty;
            double a = System.Math.Atan2(Height, Width);
            double r = Math.Sqrt(Width * Width + Height * Height) / 2;
            double w = r * Math.Cos(a - angle);
            double h = r * Math.Sin(a + angle);
            double rate = w * 2 / Width;
            if (rate < h * 2 / Height)
                rate = h * 2 / Height;
            return new System.Drawing.SizeF((float)(Width / rate), (float)(Height / rate));
        }

        /// <summary>
        /// 逆时针旋转矩形
        /// </summary>
        /// <param name="o">原点</param>
        /// <param name="rect">旋转的矩形</param>
        /// <param name="angle">弧度</param>
        /// <returns>旋转后的矩形</returns>
        public static System.Drawing.RectangleF RotateRectangle(System.Drawing.PointF o, System.Drawing.RectangleF rect, double angle)
        {
            System.Drawing.PointF[] ps = To4Points(rect);
            for (int iCount = 0; iCount < ps.Length; iCount++)
            {
                ps[iCount] = MathCommon.RotatePoint(o, ps[iCount], angle);
            }
            return PointBuffer.GetBounds(ps);
        }

        /// <summary>
        /// 进行矩形对齐操作
        /// </summary>
        /// <param name="MainRect">主矩形</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="Align">水平对齐方式 1:左对齐 2:居中对齐 3:右对齐 其他:不进行对齐操作</param>
        /// <param name="VAlign">垂直对齐方式 1:左对齐 2:居中对齐 3:右对齐 其他:不进行对齐操作</param>
        /// <returns>对齐操作产生的矩形</returns>
        public static System.Drawing.RectangleF AlignRect(System.Drawing.RectangleF MainRect, float width, float height, int Align, int VAlign)
        {
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, width, height);
            if (Align == 1)
                rect.X = MainRect.Left;
            else if (Align == 2)
                rect.X = MainRect.Left + (MainRect.Width - width) / 2;
            else if (Align == 3)
                rect.X = MainRect.Right - width;

            if (VAlign == 1)
                rect.Y = MainRect.Top;
            else if (VAlign == 2)
                rect.Y = MainRect.Top + (MainRect.Height - height) / 2;
            else if (VAlign == 3)
                rect.Y = MainRect.Bottom - height;
            return rect;
        }//public static System.Drawing.Rectanglef AlignRect( System.Drawing.RectangleF MainRect , float width , float height , int Align , int VAlign)

        //
        //		/// <summary>
        //		/// 将整数矩形转换为浮点数矩形
        //		/// </summary>
        //		/// <param name="rect">整数矩形对象</param>
        //		/// <returns>转换所得的浮点数矩形</returns>
        //		public static System.Drawing.RectangleF ToRectangleF( System.Drawing.Rectangle rect)
        //		{
        //			return new System.Drawing.RectangleF( rect.Left , rect.Top , rect.Width , rect.Height );
        //		}
        //
        //		/// <summary>
        //		/// 将浮点数矩形转换为整数矩形
        //		/// </summary>
        //		/// <param name="rect">浮点数矩形</param>
        //		/// <returns>转换所得的整数矩形</returns>
        //		public static System.Drawing.Rectangle ToRectangle( System.Drawing.RectangleF rect )
        //		{
        //			return new System.Drawing.Rectangle( (int) rect.Left , ( int) rect.Top , (int) rect.Width , ( int) rect.Height );
        //		}
        /// <summary>
        /// 在绘图操作中判断指定的大小是否表示有效的大小
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns>是否表示有效大小,若为有效大小则需要进行绘制操作,否则不需要进行绘制操作</returns>
        public static bool PaintInvalidSize(float width, float height)
        {
            if (width > 0 && height >= 0)
                return true;
            if (height > 0 && width >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// 获得内置矩形
        /// </summary>
        /// <param name="rect">外围的矩形</param>
        /// <param name="Align">水平对齐方式</param>
        /// <param name="LineAlign">垂直对齐方式</param>
        /// <param name="InnerRectSize">内置矩形的大小</param>
        /// <returns>内置矩形</returns>
        public static System.Drawing.RectangleF GetInnerRectangle(
            System.Drawing.RectangleF rect,
            System.Drawing.StringAlignment Align,
            System.Drawing.StringAlignment LineAlign,
            System.Drawing.SizeF InnerRectSize)
        {
            float left = 0;
            float top = 0;
            if (Align == System.Drawing.StringAlignment.Near)
                left = rect.Left;
            else if (Align == System.Drawing.StringAlignment.Center)
                left = rect.Left + (rect.Width - InnerRectSize.Width) / 2;
            else
                left = rect.Right - InnerRectSize.Width;
            if (LineAlign == System.Drawing.StringAlignment.Near)
                top = rect.Top;
            else if (LineAlign == System.Drawing.StringAlignment.Center)
                top = rect.Top + (rect.Height - InnerRectSize.Height) / 2;
            else
                top = rect.Bottom - InnerRectSize.Height;
            return new System.Drawing.RectangleF(left, top, InnerRectSize.Width, InnerRectSize.Height);
        }

        /// <summary>
        /// 返回表示矩形左上点，右上点和右下点坐标的点结构体数组
        /// </summary>
        /// <param name="rect">矩形区域</param>
        /// <returns>包含3个元素的点结构体数组</returns>
        public static System.Drawing.PointF[] To3Points(System.Drawing.RectangleF rect)
        {
            System.Drawing.PointF[] p = new System.Drawing.PointF[3];
            p[0] = new System.Drawing.PointF(rect.X, rect.Y);
            p[1] = new System.Drawing.PointF(rect.Right, rect.Y);
            p[2] = new System.Drawing.PointF(rect.Right, rect.Bottom);
            return p;
        }
        /// <summary>
        /// 返回表示矩形四个顶点坐标的点结构体数组
        /// </summary>
        /// <param name="rect">矩形区域</param>
        /// <returns>包含4个元素的点结构体数组</returns>
        public static System.Drawing.PointF[] To4Points(System.Drawing.RectangleF rect)
        {
            System.Drawing.PointF[] p = new System.Drawing.PointF[4];
            p[0] = new System.Drawing.PointF(rect.X, rect.Y);
            p[1] = new System.Drawing.PointF(rect.Right, rect.Y);
            p[2] = new System.Drawing.PointF(rect.Right, rect.Bottom);
            p[3] = new System.Drawing.PointF(rect.Left, rect.Bottom);
            return p;
        }

        /// <summary>
        /// 返回表示矩形四个顶点坐标的点结构体数组,并进行闭合
        /// </summary>
        /// <param name="rect">矩形区域</param>
        /// <returns>包含5个元素的点结构体数组</returns>
        public static System.Drawing.PointF[] To5Points(System.Drawing.RectangleF rect)
        {
            System.Drawing.PointF[] p = new System.Drawing.PointF[5];
            p[0] = new System.Drawing.PointF(rect.X, rect.Y);
            p[1] = new System.Drawing.PointF(rect.Right, rect.Y);
            p[2] = new System.Drawing.PointF(rect.Right, rect.Bottom);
            p[3] = new System.Drawing.PointF(rect.Left, rect.Bottom);
            p[4] = p[0];
            return p;
        }

        public static System.Drawing.RectangleF GetSquare(System.Drawing.RectangleF rect)
        {
            if (rect.Width == rect.Height)
                return rect;
            if (rect.Width > rect.Height)
                return new System.Drawing.RectangleF(
                    rect.Left + (rect.Width - rect.Height) / 2,
                    rect.Top,
                    rect.Height,
                    rect.Height);
            else
                return new System.Drawing.RectangleF(
                    rect.Left,
                    rect.Top + (rect.Height - rect.Width) / 2,
                    rect.Width,
                    rect.Width);
        }

        /// <summary>
        /// 返回浮点数矩形中心坐标
        /// </summary>
        /// <param name="rect">浮点数矩形对象</param>
        /// <returns>矩形中心坐标</returns>
        public static System.Drawing.PointF Center(System.Drawing.RectangleF rect)
        {
            return new System.Drawing.PointF(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
        }

        /// <summary>
        /// 判断指定点是指定的矩形的那个顶点,返回-1:不是顶点 0:为左上点 1:右上点 2:右下点 3:左下点
        /// </summary>
        /// <param name="vRect">矩形对象</param>
        /// <param name="p">点对象</param>
        /// <returns>返回值</returns>
        public static int GetAcmeIndexF(System.Drawing.RectangleF vRect, System.Drawing.PointF p)
        {
            if (vRect.IsEmpty == false)
            {
                if (p.Y == vRect.Y)
                {
                    if (p.X == vRect.X)
                        return 0;
                    if (p.X == vRect.Right)
                        return 1;
                }
                else if (p.Y == vRect.Bottom)
                {
                    if (p.X == vRect.Right)
                        return 2;
                    if (p.X == vRect.X)
                        return 3;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获得指定矩形指定顶端的坐标,矩形顶点编号为 0:为左上点 1:右上点 2:右下点 3:左下点
        /// </summary>
        /// <param name="vRect"></param>
        /// <param name="AcmeIndex"></param>
        /// <returns></returns>
        public static System.Drawing.PointF GetAcmePos(System.Drawing.RectangleF vRect, int AcmeIndex)
        {
            switch (AcmeIndex)
            {
                case 0:
                    return vRect.Location;
                case 1:
                    return new System.Drawing.PointF(vRect.Right, vRect.Y);
                case 2:
                    return new System.Drawing.PointF(vRect.Right, vRect.Bottom);
                case 3:
                    return new System.Drawing.PointF(vRect.X, vRect.Bottom);
            }
            return System.Drawing.PointF.Empty;
        }

        /// <summary>
        /// 根据两点坐标获得方框对象
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static System.Drawing.RectangleF GetRectangle(float x1, float y1, float x2, float y2)
        {
            System.Drawing.RectangleF myRect = System.Drawing.RectangleF.Empty;
            if (x1 < x2)
            {
                myRect.X = x1;
                myRect.Width = x2 - x1;
            }
            else
            {
                myRect.X = x2;
                myRect.Width = x1 - x2;
            }
            if (y1 < y2)
            {
                myRect.Y = y1;
                myRect.Height = y2 - y1;
            }
            else
            {
                myRect.Y = y2;
                myRect.Height = y1 - y2;
            }
            if (myRect.Width < 1) myRect.Width = 1;
            if (myRect.Height < 1) myRect.Height = 1;
            return myRect;
        }


        /// <summary>
        /// 根据两点坐标获得方框对象
        /// </summary>
        /// <param name="p1">第一个点的坐标</param>
        /// <param name="p2">第二个点的坐标</param>
        /// <returns></returns>
        public static System.Drawing.RectangleF GetRectangle(System.Drawing.PointF p1, System.Drawing.PointF p2)
        {
            return GetRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static float MoveXInto(float x, System.Drawing.RectangleF Bounds)
        {
            if (Bounds.IsEmpty)
                return x;
            if (x < Bounds.Left)
                x = Bounds.Left;
            else if (x > Bounds.Right)
                x = Bounds.Right;
            return x;
        }

        public static float MoveYInto(float y, System.Drawing.RectangleF Bounds)
        {
            if (Bounds.IsEmpty)
                return y;
            if (y < Bounds.Top)
                y = Bounds.Top;
            else if (y > Bounds.Bottom)
                y = Bounds.Bottom;
            return y;
        }

        /// <summary>
        /// 移动一个矩形,致使在指定的矩形中
        /// </summary>
        /// <param name="rect">要修正的矩形</param>
        /// <param name="Bounds">容器矩形</param>
        /// <returns>修正后的矩形</returns>
        public static System.Drawing.RectangleF MoveInto(System.Drawing.RectangleF rect, System.Drawing.RectangleF Bounds)
        {
            if (Bounds.IsEmpty)
                return rect;
            if (rect.Right > Bounds.Right)
                rect.X = Bounds.Right - rect.Width;
            if (rect.Bottom > Bounds.Bottom)
                rect.Y = Bounds.Bottom - rect.Height;
            if (rect.X < Bounds.Left)
                rect.X = Bounds.Left;
            if (rect.Y < Bounds.Top)
                rect.Y = Bounds.Top;
            return rect;
        }

        public static System.Drawing.PointF MoveInto(System.Drawing.PointF p, System.Drawing.RectangleF Bounds)
        {
            if (!Bounds.IsEmpty)
            {
                if (p.X < Bounds.Left)
                    p.X = Bounds.Left;
                if (p.X >= Bounds.Right)
                    p.X = Bounds.Right;
                if (p.Y < Bounds.Top)
                    p.Y = Bounds.Top;
                if (p.Y >= Bounds.Bottom)
                    p.Y = Bounds.Bottom;
            }
            return p;
        }

        public static System.Drawing.PointF GetBorderPoint
            (float intLeft,
            float intTop,
            float intWidth,
            float intHeight,
            int iPos,
            int iSplit)
        {
            System.Drawing.PointF myPoint = System.Drawing.PointF.Empty;
            if (iSplit <= 0)
                return myPoint;
            // 修正参数,保证参数在 0 到 4倍的Split之间
            iPos %= (iSplit * 4);
            if (iPos < 0)
                iPos += (iSplit * 4);
            // 计算坐标
            if (iPos >= 0 && iPos < iSplit)
            {
                myPoint.X = intLeft + (intWidth * iPos) / iSplit;
                myPoint.Y = intTop;
            }
            else if (iPos >= iSplit && iPos < iSplit * 2)
            {
                myPoint.X = intLeft + intWidth;
                myPoint.Y = intTop + (intHeight * (iPos - iSplit)) / iSplit;
            }
            else if (iPos >= iSplit * 2 && iPos < iSplit * 3)
            {
                myPoint.X = intLeft + (intWidth * (iSplit * 3 - iPos)) / iSplit;
                myPoint.Y = intTop + intHeight;
            }
            else
            {
                myPoint.X = intLeft;
                myPoint.Y = intTop + (intHeight * (iSplit * 4 - iPos)) / iSplit;
            }
            // 返回结果
            return myPoint;
        }

        private RectangleCommon() { }
    }//public sealed class RectangleCommon
}
