using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 页面边框绘制对象
    /// </summary>
    public class PageFrameDrawer
    {
        /// <summary>
        /// 绘制页面边框
        /// </summary>
        /// <param name="bounds">页面边框</param>
        /// <param name="m">页边距对象</param>
        /// <param name="g">图形绘制对象</param>
        /// <param name="ClipRectangle">剪切矩形</param>
        /// <param name="HightlightingBorder">是否高亮度显示边框</param>
        /// <param name="FillBackground">是否填充背景</param>
        public /*static*/ void DrawPageFrame(
            System.Drawing.Rectangle bounds,
            System.Drawing.Printing.Margins m,
            System.Drawing.Graphics g,
            System.Drawing.Rectangle ClipRectangle,
            bool HightlightingBorder,
            bool FillBackground)
        {
            //PageFrameDrawer drawer = new PageFrameDrawer();
            //drawer.Bounds = bounds;
            //drawer.Margins = m;
            ////TODO 页面边框
            //if (HightlightingBorder)
            //    drawer.BorderColor = this.BorderColor;//System.Drawing.Color.SkyBlue;
            //else
            //    drawer.BorderColor = System.Drawing.Color.Gray;
            //drawer.BorderWidth = 1;
            //if (FillBackground)
            //    drawer.BackColor = this.BackColor;//System.Drawing.SystemColors.Window;
            //else
            //    drawer.BackColor = System.Drawing.Color.Transparent;
            //drawer.DrawPageFrame(g, ClipRectangle);

            this.Bounds = bounds;
            this.Margins = m;
            //TODO 页面边框
            if (HightlightingBorder)
                ;//this.BorderColor = this.BorderColor;//System.Drawing.Color.SkyBlue;
            else
                this.BorderColor = System.Drawing.Color.Gray;
            this.BorderWidth = 1;
            if (FillBackground)
                ;//drawer.BackColor = this.BackColor;//System.Drawing.SystemColors.Window;
            else
                this.BackColor = System.Drawing.Color.Transparent;
            this.DrawPageFrame(g, ClipRectangle);
        }
        /// <summary>
        /// 初始化对象
        /// </summary>
        public PageFrameDrawer()
        {

        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="bounds">页面边框</param>
        /// <param name="m">页边距对象</param>
        public PageFrameDrawer(
            System.Drawing.Rectangle bounds,
            System.Drawing.Printing.Margins m)
        {
            this.myBounds = bounds;
            this.Margins = m;
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

        private int intLeftMargin = 20;
        private int intTopMargin = 30;
        private int intRightMargin = 20;
        private int intBottomMargin = 40;
        /// <summary>
        /// 左页边距
        /// </summary>
        public int LeftMargin
        {
            get { return intLeftMargin; }
            set { intLeftMargin = value; }
        }
        /// <summary>
        /// 顶页边距
        /// </summary>
        public int TopMargin
        {
            get { return intTopMargin; }
            set { intTopMargin = value; }
        }
        /// <summary>
        /// 右页边距
        /// </summary>
        public int RightMargin
        {
            get { return intRightMargin; }
            set { intRightMargin = value; }
        }
        /// <summary>
        /// 底页边距
        /// </summary>
        public int BottomMargin
        {
            get { return intBottomMargin; }
            set { intBottomMargin = value; }
        }

        /// <summary>
        /// 页边距对象
        /// </summary>
        public System.Drawing.Printing.Margins Margins
        {
            get
            {
                return new System.Drawing.Printing.Margins(
                    this.intLeftMargin,
                    this.intRightMargin,
                    this.intTopMargin,
                    this.intBottomMargin);
            }
            set
            {
                this.intLeftMargin = value.Left;
                this.intTopMargin = value.Top;
                this.intRightMargin = value.Right;
                this.intBottomMargin = value.Bottom;
            }
        }

        private int intMarginLineLength = 20;
        /// <summary>
        /// 边距线长度
        /// </summary>
        public int MarginLineLength
        {
            get { return intMarginLineLength; }
            set { intMarginLineLength = value; }
        }
        private bool bolDrawMargin = true;
        /// <summary>
        /// 是否绘制边距线
        /// </summary>
        public bool DrawMargin
        {
            get { return bolDrawMargin; }
            set { bolDrawMargin = value; }
        }

        private System.Drawing.Color intMarginLineColor = System.Drawing.SystemColors.Control;
        /// <summary>
        /// 边距线颜色
        /// </summary>
        public System.Drawing.Color MarginLineColor
        {
            get { return this.intMarginLineColor; }
            set { this.intMarginLineColor = value; }
        }

        private System.Drawing.Color intBackColor = System.Drawing.Color.White;
        /// <summary>
        /// 背景色
        /// </summary>
        public System.Drawing.Color BackColor
        {
            get { return intBackColor; }
            set { intBackColor = value; }
        }

        private System.Drawing.Color intBorderColor = System.Drawing.Color.Black;
        /// <summary>
        /// 边框线颜色
        /// </summary>
        public System.Drawing.Color BorderColor
        {
            get { return intBorderColor; }
            set { intBorderColor = value; }
        }

        private int intBorderWidth = 1;
        /// <summary>
        /// 边框线宽度
        /// </summary>
        public int BorderWidth
        {
            get { return intBorderWidth; }
            set { intBorderWidth = value; }
        }

        bool drawtopmargin = false;
        public bool DrawTopMargin
        {
            get { return drawtopmargin; }
            set { drawtopmargin = value; }
        }
        bool drawbottommargin = false;
        public bool DrawBottomMargin
        {
            get { return drawbottommargin; }
            set { drawbottommargin = value; }
        }

        /// <summary>
        /// 使用指定图形绘制对象从指定位置开始绘制页面框架
        /// </summary>
        /// <param name="g">图形绘制对象</param>
        /// <param name="ClipRectangle">剪切矩形</param>
        public void DrawPageFrame(
            System.Drawing.Graphics g,
            System.Drawing.Rectangle ClipRectangle)
        {
            //Debug.WriteLine("DrawPageFrame");
            using (RectangleDrawer drawer = new RectangleDrawer())
            {
                drawer.Bounds = this.myBounds;
                if (this.intBorderColor.A != 0 && this.intBorderWidth > 0)
                    drawer.BorderPen = new System.Drawing.Pen(this.intBorderColor, this.intBorderWidth);
                if (this.intBackColor.A != 0)
                    drawer.FillBrush = new System.Drawing.SolidBrush(this.intBackColor);
                if (drawer.Draw(g, ClipRectangle))
                {
                    if (this.bolDrawMargin
                        && this.intMarginLineColor.A != 0
                        && this.intMarginLineLength > 0)
                    {
                        System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                            myBounds.Left + this.intLeftMargin,
                            myBounds.Top + this.intTopMargin,
                            myBounds.Width - this.intLeftMargin - this.intRightMargin,
                            myBounds.Height - this.intTopMargin - this.intBottomMargin);

                        System.Drawing.Point[] ps = new System.Drawing.Point[16];
                        ps[0] = rect.Location;
                        ps[1].X = rect.Left - intMarginLineLength;
                        ps[1].Y = rect.Top;

                        ps[2] = ps[0];
                        ps[3].X = rect.Left;
                        ps[3].Y = rect.Top - intMarginLineLength;

                        ps[4].X = rect.Right;
                        ps[4].Y = rect.Top;
                        ps[5].X = rect.Right + intMarginLineLength;
                        ps[5].Y = rect.Top;

                        ps[6] = ps[4];
                        ps[7].X = rect.Right;
                        ps[7].Y = rect.Top - intMarginLineLength;

                        ps[8].X = rect.Right;
                        ps[8].Y = rect.Bottom;
                        ps[9].X = rect.Right + intMarginLineLength;
                        ps[9].Y = rect.Bottom;

                        ps[10] = ps[8];
                        ps[11].X = rect.Right;
                        ps[11].Y = rect.Bottom + intMarginLineLength;

                        ps[12].X = rect.Left;
                        ps[12].Y = rect.Bottom;
                        ps[13].X = rect.Left;
                        ps[13].Y = rect.Bottom + intMarginLineLength;

                        ps[14] = ps[12];
                        ps[15].X = rect.Left - intMarginLineLength;
                        ps[15].Y = rect.Bottom;

                        Common.MathCommon.RectangleClipLines(myBounds, ps);
                        using (System.Drawing.Pen p = new System.Drawing.Pen(this.intMarginLineColor, 1))
                        {
                            //是否画上边距线，如果不画，则应用背景色画它，否则会有上次遗留
                            //if (this.DrawTopMargin)
                            //p.Color = this.intMarginLineColor;
                            //else
                            //p.Color = this.BackColor;

                            for (int iCount = 0; iCount < 8; iCount += 2)
                            {
                                //g.DrawLine(p, ps[iCount], ps[iCount + 1]);
                                g.DrawLine(new Pen(Color.Black), ps[iCount], ps[iCount + 1]);
                            }

                            //是否画下边距线，如果不画，则应用背景色画它，否则会有上次遗留
                            //if (this.DrawBottomMargin)
                            //p.Color = this.intMarginLineColor;
                            //else
                            //p.Color = this.BackColor;

                            for (int iCount = 8; iCount < 16; iCount += 2)
                            {
                                //g.DrawLine(p, ps[iCount], ps[iCount + 1]);
                                g.DrawLine(new Pen(Color.Black), ps[iCount], ps[iCount + 1]);
                            }

                            //画装订线
                            //p.Color = Color.Red;
                            //g.DrawLine(p, myBounds.Left + this.LeftMargin, myBounds.Height / 2 - 20, myBounds.Left + this.LeftMargin, myBounds.Height / 2 + 20);
                        }//using( System.Drawing.Pen p = new System.Drawing.Pen( this.intMarginLineColor , 1 ))
                    }//if( this.bolDrawMargin && this.intMarginLineColor.A != 0 )
                }//if( drawer.Draw( g , ClipRectangle ))
            }//using( RectangleDrawer drawer = new RectangleDrawer() )
        }//public void DrawPageFrame()
    }//public class PageFrameDrawer
}
