using System;
using System.Drawing;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
    /// <summary>
    /// 椭圆对象
    /// </summary>
    public class EllipseObject
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public EllipseObject()
        {
        }

        /// <summary>
        /// 指定外切矩形初始化对象
        /// </summary>
        /// <param name="bounds">椭圆的外切矩形</param>
        public EllipseObject(System.Drawing.RectangleF bounds)
        {
            myBounds = bounds;
            UpdateSate();
        }
        /// <summary>
        /// 指定外切矩形初始化对象
        /// </summary>
        /// <param name="bounds">椭圆的外切矩形</param>
        public EllipseObject(System.Drawing.Rectangle bounds)
        {
            myBounds = new System.Drawing.RectangleF(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
            UpdateSate();
        }
        private System.Drawing.RectangleF myBounds = System.Drawing.RectangleF.Empty;
        /// <summary>
        /// 椭圆外切矩形
        /// </summary>
        public System.Drawing.RectangleF Bounds
        {
            get { return myBounds; }
            set { myBounds = value; UpdateSate(); }
        }
        public void Offset(float dx, float dy)
        {
            myBounds.Offset(dx, dy);
            this.UpdateSate();
        }
        private System.Drawing.PointF myCenter = System.Drawing.PointF.Empty;
        private void UpdateSate()
        {
            myCenter = new System.Drawing.PointF(
                myBounds.Left + myBounds.Width / 2,
                myBounds.Top + myBounds.Height / 2);
        }
        /// <summary>
        /// 椭圆中心点坐标
        /// </summary>
        public System.Drawing.PointF Center
        {
            get
            {
                return myCenter;
            }
        }
        /// <summary>
        /// 椭圆半长轴
        /// </summary>
        public float Semimajor
        {
            get { return (float)(myBounds.Width / 2.0); }
        }
        /// <summary>
        /// 椭圆半短轴
        /// </summary>
        public float SemiMinor
        {
            get { return (float)(myBounds.Height / 2.0); }
        }
        /// <summary>
        /// 获得指定角度在椭圆边界上的点坐标
        /// </summary>
        /// <param name="angle">角度值</param>
        /// <returns>点坐标值</returns>
        public System.Drawing.PointF PeripheraPoint(double angle)
        {
            double rad = angle * Math.PI / 180;
            double x = myCenter.X + myBounds.Width * Math.Cos(rad) / 2;
            double y = myCenter.Y + myBounds.Height * Math.Sin(rad) / 2;
            return new System.Drawing.PointF((float)x, (float)y);
        }

        public System.Drawing.PointF PeripheraPoint2(double angle)
        {
            double rad = angle * Math.PI / 180;
            double r = GetEllipseRadius(angle);
            double x = myCenter.X + r * Math.Cos(rad);
            double y = myCenter.Y + r * Math.Sin(rad);
            return new System.Drawing.PointF((float)x, (float)y);
        }

        /// <summary>
        /// 将圆压成椭圆后,圆上的指定的角度在椭圆中的新角度值
        /// </summary>
        /// <param name="angle">圆上的角度</param>
        /// <returns>椭圆上的角度</returns>
        public float CompressAngle(float angle)
        {
            if (myBounds.Width == myBounds.Height)
                return angle;
            double x = myBounds.Width * Math.Cos(angle * Math.PI / 180);
            double y = myBounds.Height * Math.Sin(angle * Math.PI / 180);
            float result = (float)(Math.Atan2(y, x) * 180 / Math.PI);
            if (result < 0)
                result += 360;
            return result;
        }

        /// <summary>
        /// 将椭圆拉成圆,椭圆上指定的角度在圆中的新的角度值
        /// </summary>
        /// <param name="angle">椭圆角度</param>
        /// <returns>圆角度</returns>
        public float UnCompressAngle(float angle)
        {
            if (myBounds.Width == myBounds.Height)
                return angle;
            double x = myBounds.Height * Math.Cos(angle * Math.PI / 180);
            double y = myBounds.Height * Math.Sin(angle * Math.PI / 180);
            float result = (float)(Math.Atan2(y, x) * 180 / Math.PI);
            if (result < 0)
                result += 360;
            return result;
        }

        /// <summary>
        /// 判断指定点是否在椭圆区域内
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Contains(double x, double y)
        {
            double dx = x - myBounds.Left - myBounds.Width / 2;
            double dy = y - myBounds.Top - myBounds.Height / 2;
            double angle = Math.Atan2(y, x);
            if (angle < 0)
                angle = angle + 2.0 * Math.PI;
            double r = Math.Sqrt(dy * dy + dx * dx);
            return GetEllipseRadius(angle) > r;
        }

        /// <summary>
        /// 判断指定点是否在指定椭圆扇形区域内
        /// </summary>
        /// <param name="x">点X坐标</param>
        /// <param name="y">点Y坐标</param>
        /// <param name="StartAngle">扇形区域开始角度</param>
        /// <param name="SweepAngle">扇形区域扫过的角度</param>
        /// <returns>指定点是否在椭圆扇形区域内</returns>
        public bool Contains(double x, double y, float StartAngle, float SweepAngle)
        {
            double dx = x - myBounds.Left - myBounds.Width / 2;
            double dy = y - myBounds.Top - myBounds.Height / 2;
            double angle = Math.Atan2(dy, dx);
            if (angle < 0)
                angle = angle + 2.0 * Math.PI;
            double angleDegrees = angle * 180 / Math.PI;
            float EndAngle = StartAngle + SweepAngle;

            if ((angleDegrees >= StartAngle && angleDegrees <= EndAngle)
                || (EndAngle > 360) && ((angleDegrees + 360) <= EndAngle))
            {
                double r = Math.Sqrt(dy * dy + dx * dx);
                return GetEllipseRadius(angleDegrees) > r;
            }
            return false;
        }

        /// <summary>
        /// 获得椭圆的半径
        /// </summary>
        /// <param name="angle">指定的角度</param>
        /// <returns>椭圆半径</returns>
        public double GetEllipseRadius(double angle)
        {
            angle = angle * Math.PI / 180;
            double a = myBounds.Width / 2;
            double b = myBounds.Height / 2;
            double a2 = a * a;
            double b2 = b * b;
            double cosFi = Math.Cos(angle);
            double sinFi = Math.Sin(angle);
            // distance of the ellipse perimeter point
            return (a * b) / Math.Sqrt(b2 * cosFi * cosFi + a2 * sinFi * sinFi);
        }

        public void Draw(
            System.Drawing.Graphics g,
            System.Drawing.Pen pen,
            System.Drawing.Brush brush)
        {
            if (g == null)
                return;
            if (pen == null && brush == null)
                return;
            if (brush != null)
                g.FillEllipse(brush, myBounds);

            if (pen != null)
                g.DrawEllipse(pen, myBounds);
        }

        public void Draw(
            System.Drawing.Graphics g,
            System.Drawing.Pen pen,
            System.Drawing.Brush brush,
            float StartAngle,
            float SweepAngle)
        {
            if (g == null)
                return;
            if (pen == null && brush == null)
                return;
            if (brush != null)
                g.FillPie(
                    brush,
                    myBounds.Left,
                    myBounds.Top,
                    myBounds.Width,
                    myBounds.Height,
                    StartAngle,
                    SweepAngle);

            if (pen != null)
                g.DrawPie(
                    pen,
                    myBounds.Left,
                    myBounds.Top,
                    myBounds.Width,
                    myBounds.Height,
                    StartAngle,
                    SweepAngle);
        }
    }//public class EllipseObject
}
