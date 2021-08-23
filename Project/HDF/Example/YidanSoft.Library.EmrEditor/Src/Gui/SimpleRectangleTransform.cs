﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 简单矩形坐标转换对象
    /// </summary>
    public class SimpleRectangleTransform : TransformBase
    {
        /// <summary>
        /// 无作为的初始化对象
        /// </summary>
        public SimpleRectangleTransform()
        {
        }
        /// <summary>
        /// 初始化对象并设置原始区域和目标区域矩形
        /// </summary>
        /// <param name="vSourceRect">原始区域矩形</param>
        /// <param name="vDescRect">目标区域矩形</param>
        public SimpleRectangleTransform(
            System.Drawing.RectangleF vSourceRect,
            System.Drawing.RectangleF vDescRect)
        {
            mySourceRect = vSourceRect;
            myDescRect = vDescRect;
        }

        private bool bolEnable = true;
        /// <summary>
        /// 对象是否可用
        /// </summary>
        public bool Enable
        {
            get { return bolEnable; }
            set { bolEnable = value; }
        }
        private bool bolVisible = true;
        /// <summary>
        /// 对象是否可见
        /// </summary>
        public bool Visible
        {
            get { return bolVisible; }
            set { bolVisible = value; }
        }
        private object objTag = null;
        /// <summary>
        /// 对象额外数据
        /// </summary>
        public object Tag
        {
            get { return objTag; }
            set { objTag = value; }
        }

        private int intPageIndex = 0;
        public int PageIndex
        {
            get { return intPageIndex; }
            set { intPageIndex = value; }
        }

        private int intFlag2 = 0;
        public int Flag2
        {
            get { return intFlag2; }
            set { intFlag2 = value; }
        }

        private int intFlag3 = 0;
        public int Flag3
        {
            get { return intFlag3; }
            set { intFlag3 = value; }
        }

        protected System.Drawing.RectangleF mySourceRect = System.Drawing.RectangleF.Empty;
        /// <summary>
        /// 原始区域矩形边框
        /// </summary>
        public System.Drawing.RectangleF SourceRectF
        {
            get { return mySourceRect; }
            set { mySourceRect = value; }
        }
        /// <summary>
        /// 原始区域矩形边框
        /// </summary>
        public System.Drawing.Rectangle SourceRect
        {
            get
            {
                return new System.Drawing.Rectangle(
                    (int)mySourceRect.Left,
                    (int)mySourceRect.Top,
                    (int)mySourceRect.Width,
                    (int)mySourceRect.Height);
            }
            set
            {
                mySourceRect = new System.Drawing.RectangleF(
                    value.Left,
                    value.Top,
                    value.Width,
                    value.Height);
            }
        }
        protected System.Drawing.RectangleF myDescRect = System.Drawing.RectangleF.Empty;
        /// <summary>
        /// 目标区域矩形边框
        /// </summary>
        public System.Drawing.RectangleF DescRectF
        {
            get { return myDescRect; }
            set { myDescRect = value; }
        }
        /// <summary>
        /// 目标区域矩形边框
        /// </summary>
        public System.Drawing.Rectangle DescRect
        {
            get
            {
                return new System.Drawing.Rectangle(
                     (int)myDescRect.Left,
                     (int)myDescRect.Top,
                     (int)myDescRect.Width,
                     (int)myDescRect.Height);
            }
            set
            {
                myDescRect = new System.Drawing.RectangleF(
                    value.Left,
                    value.Top,
                    value.Width,
                    value.Height);
            }
        }

        public System.Drawing.Point OffsetPosition
        {
            get
            {
                return new System.Drawing.Point(
                    (int)(myDescRect.Left - mySourceRect.Left),
                    (int)(myDescRect.Top - mySourceRect.Top));
            }
        }
        public System.Drawing.PointF OffsetPositionF
        {
            get
            {
                return new System.Drawing.PointF(
                    myDescRect.Left - mySourceRect.Left,
                    myDescRect.Top - mySourceRect.Top);
            }
        }
        public float XZoomRate
        {
            get
            {
                float rate = myDescRect.Width;
                return rate / mySourceRect.Width;
            }
        }
        public float YZoomRate
        {
            get
            {
                float rate = myDescRect.Height;
                return rate / mySourceRect.Height;
            }
        }
        public override bool ContainsSourcePoint(int x, int y)
        {
            return this.mySourceRect.Contains(x, y);
        }

        /// <summary>
        /// 将原始区域的点转换为目标区域中的点
        /// </summary>
        /// <param name="x">原始区域中的点的X坐标</param>
        /// <param name="y">原始区域的点的Y坐标</param>
        /// <returns>目标区域中的点坐标</returns>
        public override System.Drawing.Point TransformPoint(int x, int y)
        {
            System.Drawing.PointF p = TransformPointF((float)x, (float)y);
            return new System.Drawing.Point((int)p.X, (int)p.Y);
        }
        /// <summary>
        /// 将原始区域的点转换为目标区域中的点
        /// </summary>
        /// <param name="x">原始区域中的点的X坐标</param>
        /// <param name="y">原始区域的点的Y坐标</param>
        /// <returns>目标区域中的点坐标</returns>
        public override System.Drawing.PointF TransformPointF(float x, float y)
        {
            x = x - mySourceRect.Left;
            y = y - mySourceRect.Top;
            if (mySourceRect.Width != myDescRect.Width && mySourceRect.Width != 0)
                x = x * myDescRect.Width / mySourceRect.Width;
            if (mySourceRect.Height != myDescRect.Height && mySourceRect.Height != 0)
                y = y * myDescRect.Height / mySourceRect.Height;
            return new System.Drawing.PointF(x + DescRect.Left, y + DescRect.Top);
        }
        /// <summary>
        /// 将原始区域重的大小转换未目标区域中的大小
        /// </summary>
        /// <param name="vSize">原始区域中的大小</param>
        /// <returns>目标区域中的大小</returns>
        public override System.Drawing.Size TransformSize(int w, int h)
        {
            if (mySourceRect.Width != myDescRect.Width && mySourceRect.Width != 0)
                w = (int)(w * myDescRect.Width / mySourceRect.Width);
            if (mySourceRect.Height != myDescRect.Height && mySourceRect.Height != 0)
                h = (int)(h * myDescRect.Height / mySourceRect.Height);
            return new System.Drawing.Size(w, h);
        }
        /// <summary>
        /// 将原始区域重的大小转换未目标区域中的大小
        /// </summary>
        /// <param name="vSize">原始区域中的大小</param>
        /// <returns>目标区域中的大小</returns>
        public override System.Drawing.SizeF TransformSizeF(float w, float h)
        {
            if (mySourceRect.Width != myDescRect.Width && mySourceRect.Width != 0)
                w = w * myDescRect.Width / mySourceRect.Width;
            if (mySourceRect.Height != myDescRect.Height && mySourceRect.Height != 0)
                h = h * myDescRect.Height / mySourceRect.Height;
            return new System.Drawing.SizeF(w, h);
        }

        /// <summary>
        /// 将目标区域中的坐标转换为原始区域的坐标
        /// </summary>
        /// <param name="p">目标区域中的坐标</param>
        /// <returns>原始区域的坐标</returns>
        public override System.Drawing.Point UnTransformPoint(System.Drawing.Point p)
        {
            System.Drawing.PointF p1 = UnTransformPointF((float)p.X, (float)p.Y);
            return new System.Drawing.Point((int)p1.X, (int)p1.Y);
        }
        /// <summary>
        /// 将目标区域中的坐标转换为原始区域中的坐标
        /// </summary>
        /// <param name="x">目标区域中的X坐标</param>
        /// <param name="y">目标区域中的Y坐标</param>
        /// <returns>原始区域中的坐标</returns>
        public override System.Drawing.Point UnTransformPoint(int x, int y)
        {
            System.Drawing.PointF p1 = UnTransformPointF((float)x, (float)y);
            return new System.Drawing.Point((int)p1.X, (int)p1.Y);
        }
        /// <summary>
        /// 将目标区域中的坐标转换为原始区域中的坐标
        /// </summary>
        /// <param name="x">目标区域中的X坐标</param>
        /// <param name="y">目标区域中的Y坐标</param>
        /// <returns>原始区域中的坐标</returns>
        public override System.Drawing.PointF UnTransformPointF(float x, float y)
        {
            x = x - DescRect.Left;
            y = y - DescRect.Top;
            if (mySourceRect.Width != myDescRect.Width && myDescRect.Width != 0)
                x = x * mySourceRect.Width / myDescRect.Width;
            if (mySourceRect.Height != myDescRect.Height && myDescRect.Height != 0)
                y = y * mySourceRect.Height / myDescRect.Height;
            return new System.Drawing.PointF(x + SourceRect.Left, y + SourceRect.Top);
        }
        /// <summary>
        /// 将目标区域中的大小转换为原始区域中的大小
        /// </summary>
        /// <param name="vSize">目标区域中的大小</param>
        /// <returns>原始区域中的大小</returns>
        public override System.Drawing.Size UnTransformSize(int w, int h)
        {
            if (mySourceRect.Width != myDescRect.Width && myDescRect.Width != 0)
                w = (int)(w * mySourceRect.Width / myDescRect.Width);
            if (mySourceRect.Height != myDescRect.Height && myDescRect.Height != 0)
                h = (int)(h * mySourceRect.Height / myDescRect.Height);
            return new System.Drawing.Size(w, h);
        }
        /// <summary>
        /// 将目标区域中的大小转换为原始区域中的大小
        /// </summary>
        /// <param name="vSize">目标区域中的大小</param>
        /// <returns>原始区域中的大小</returns>
        public override System.Drawing.SizeF UnTransformSizeF(float w, float h)
        {
            if (mySourceRect.Width != myDescRect.Width && myDescRect.Width != 0)
                w = w * mySourceRect.Width / myDescRect.Width;
            if (mySourceRect.Height != myDescRect.Height && myDescRect.Height != 0)
                h = h * mySourceRect.Height / myDescRect.Height;
            return new System.Drawing.SizeF(w, h);
        }
    }//public class SimpleRectangleTransform
}
