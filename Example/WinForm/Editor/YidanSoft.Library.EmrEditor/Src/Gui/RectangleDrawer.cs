using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 矩形图形绘制对象
    /// </summary>
    public class RectangleDrawer : System.IDisposable
    {
        public static bool DrawRectangle(
            System.Drawing.Graphics g,
            System.Drawing.Pen BorderPen,
            System.Drawing.Brush FillBrush,
            System.Drawing.Rectangle Bounds,
            System.Drawing.Rectangle ClipRectangle,
            bool ForceDrawBorder)
        {
            System.Drawing.Rectangle rect = System.Drawing.Rectangle.Empty;
            if (ClipRectangle.IsEmpty)
                rect = Bounds;
            else
                rect = System.Drawing.Rectangle.Intersect(Bounds, ClipRectangle);
            if (rect.IsEmpty)
                return false;
            if (FillBrush != null)
            {
                g.FillRectangle(FillBrush, rect);
            }
            if (BorderPen != null)
            {
                rect = new System.Drawing.Rectangle(
                    Bounds.Left,
                    Bounds.Top,
                    Bounds.Width - (int)Math.Ceiling(BorderPen.Width / 2.0),
                    Bounds.Height - (int)Math.Ceiling(BorderPen.Width / 2.0));
                if (ForceDrawBorder || ClipRectangle.IsEmpty)
                    g.DrawRectangle(BorderPen, rect);
                else
                {
                    if (rect.IntersectsWith(ClipRectangle))
                        g.DrawRectangle(BorderPen, rect);
                }
            }
            return true;
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        public RectangleDrawer()
        {
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="bounds">对象边框</param>
        /// <param name="BorderColor">边框颜色</param>
        /// <param name="FillColor">背景色</param>
        public RectangleDrawer(
            System.Drawing.Rectangle bounds,
            System.Drawing.Color BorderColor,
            System.Drawing.Color FillColor)
        {
            myBounds = bounds;
            if (BorderColor.A != 0)
                this.myBorderPen = new System.Drawing.Pen(BorderColor, 1);
            if (FillColor.A != 0)
                this.myFillBrush = new System.Drawing.SolidBrush(FillColor);
        }

        private System.Drawing.Rectangle myBounds = System.Drawing.Rectangle.Empty;
        /// <summary>
        /// 对象边框
        /// </summary>
        public System.Drawing.Rectangle Bounds
        {
            get { return myBounds; }
            set { myBounds = value; }
        }

        private System.Drawing.Pen myBorderPen = null;
        /// <summary>
        /// 绘制边框使用的画笔对象
        /// </summary>
        public System.Drawing.Pen BorderPen
        {
            get { return myBorderPen; }
            set { myBorderPen = value; }
        }

        private bool bolIsDrawBorder = true;
        /// <summary>
        /// 是否绘制边框
        /// </summary>
        public bool IsDrawBorder
        {
            get { return bolIsDrawBorder; }
            set { bolIsDrawBorder = value; }
        }

        private System.Drawing.Brush myFillBrush = null;
        /// <summary>
        /// 填充边框使用的画刷对象
        /// </summary>
        public System.Drawing.Brush FillBrush
        {
            get { return myFillBrush; }
            set { myFillBrush = value; }
        }

        private bool bolIsFill = true;
        /// <summary>
        /// 是否填充边框
        /// </summary>
        public bool IsFill
        {
            get { return bolIsFill; }
            set { bolIsFill = value; }
        }

        public bool CanDraw
        {
            get
            {
                if (this.myBounds.IsEmpty)
                    return false;
                if (this.IsDrawBorder && this.myBorderPen != null)
                    return true;
                if (this.IsFill && this.myFillBrush != null)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="g">图形绘制对象</param>
        /// <param name="ClipRectangle">剪切矩形</param>
        /// <returns>是否进行了绘制</returns>
        public bool Draw(System.Drawing.Graphics g, System.Drawing.Rectangle ClipRectangle)
        {
            if (g == null)
                throw new System.ArgumentNullException("g");
            System.Drawing.Pen p = null;
            if (this.bolIsDrawBorder)
                p = this.myBorderPen;
            System.Drawing.Brush b = null;
            if (this.bolIsFill)
                b = this.myFillBrush;

            return DrawRectangle(g, p, b, this.myBounds, ClipRectangle, true);
        }

        public void Dispose()
        {
            if (this.myBorderPen != null)
            {
                this.myBorderPen.Dispose();
                this.myBorderPen = null;
            }
            if (this.myFillBrush != null)
            {
                this.myFillBrush.Dispose();
                this.myFillBrush = null;
            }
        }

    }
}
