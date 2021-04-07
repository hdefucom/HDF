using Gocent.Library.Editor.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Gocent.Library.Editor.Common
{
    public static class TransformHelper
    {


        /// <summary>
        /// 将原始区域的点转换为目标区域中的点
        /// </summary>
        /// <param name="x">原始区域中的点的X坐标</param>
        /// <param name="y">原始区域的点的Y坐标</param>
        /// <returns>目标区域中的点坐标</returns>
        public static PointF TransformPointF(this DocumentViewControl control, float x, float y)
        {
            Rectangle source = control.ClientRectangle;
            Point p = control.AutoScrollPosition;
            float xrate = (float)control.ClientToViewXRate;
            float yrate = (float)control.ClientToViewYRate;
            RectangleF desc = new RectangleF(-p.X * xrate, -p.Y * yrate, source.Width * xrate, source.Height * yrate);

            x = x - source.Left;
            y = y - source.Top;
            if (source.Width != desc.Width && source.Width != 0)
                x = x * desc.Width / source.Width;
            if (source.Height != desc.Height && source.Height != 0)
                y = y * desc.Height / source.Height;
            return new PointF(x + desc.Left, y + desc.Top);
        }


        /// <summary>
        /// 将原始区域的点转换为目标区域中的点
        /// </summary>
        /// <param name="x">原始区域中的点的X坐标</param>
        /// <param name="y">原始区域的点的Y坐标</param>
        /// <returns>目标区域中的点坐标</returns>
        public static Point TransformPoint(this DocumentViewControl control, int x, int y)
        {
            return Point.Truncate(control.TransformPointF(x, y));
        }

        /// <summary>
        /// 将原始区域重的大小转换未目标区域中的大小
        /// </summary>
        /// <param name="vSize">原始区域中的大小</param>
        /// <returns>目标区域中的大小</returns>
        public static SizeF TransformSizeF(this DocumentViewControl control, float w, float h)
        {
            Rectangle source = control.ClientRectangle;
            Point p = control.AutoScrollPosition;
            float xrate = (float)control.ClientToViewXRate;
            float yrate = (float)control.ClientToViewYRate;
            RectangleF desc = new RectangleF(-p.X * xrate, -p.Y * yrate, source.Width * xrate, source.Height * yrate);

            if (source.Width != desc.Width && source.Width != 0)
                w = w * desc.Width / source.Width;
            if (source.Height != desc.Height && source.Height != 0)
                h = h * desc.Height / source.Height;
            return new SizeF(w, h);
        }




        /// <summary>
        /// 将目标区域中的大小转换为原始区域中的大小
        /// </summary>
        /// <param name="vSize">目标区域中的大小</param>
        /// <returns>原始区域中的大小</returns>
        public static SizeF UnTransformSizeF(this DocumentViewControl control, float w, float h)
        {
            Rectangle source = control.ClientRectangle;
            Point p = control.AutoScrollPosition;
            float xrate = (float)control.ClientToViewXRate;
            float yrate = (float)control.ClientToViewYRate;
            RectangleF desc = new RectangleF(-p.X * xrate, -p.Y * yrate, source.Width * xrate, source.Height * yrate);

            if (source.Width != desc.Width && desc.Width != 0)
                w = w * source.Width / desc.Width;
            if (source.Height != desc.Height && desc.Height != 0)
                h = h * source.Height / desc.Height;
            return new SizeF(w, h);
        }



        public static Size UnTransformSize(this DocumentViewControl control, int w, int h)
        {
            return Size.Truncate(control.UnTransformSize(w, h));
        }





        public static RectangleF TransformRectangleF(this DocumentViewControl control, RectangleF rect) => new RectangleF(control.TransformPointF(rect.Left, rect.Top), control.TransformSizeF(rect.Width, rect.Height));



        public static RectangleF TransformRectangleF(this DocumentViewControl control, float left, float top, float width, float height) => new RectangleF(control.TransformPointF(left, top), control.TransformSizeF(width, height));















    }
}
