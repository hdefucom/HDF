#define CaptureMouseMove
#define ReversibleDraw

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using YidanSoft.Library.EmrEditor.Src.Common;
using YidanSoft.Library.EmrEditor.Src.Document;

#if CaptureMouseMove || ReversibleDraw

using YidanSoft.Library.EmrEditor.Src.Win32API;
using System.Diagnostics;
using System.Runtime.InteropServices;
///////////////////////序列化需要的引用
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Windows32;
#endif

namespace YidanSoft.Library.EmrEditor.Src.Gui
{
    /// <summary>
    /// 文档视图控件、主要实现坐标转换、
    /// 鼠标位置信息没有在委托中获得，而是自己实现了一遍,重写的鼠标事件中也转换了坐标
    /// </summary>
    /// 
    [Serializable]
    public class DocumentViewControl : ScrollableControl
    {
        #region bwy : 为了预防出错而加，测试用
        //public bool AutoScroll = true;
        //public bool HScroll = true;
        //public bool VScroll = true;
        //public Size AutoScrollMinSize = new Size();
        //public Point AutoScrollPosition = new Point();
        #endregion bwy :
        /// <summary>
        /// 初始化对象
        /// </summary>
        public DocumentViewControl()
        {
            //this.myScaleViewer.BindViewControl = this ;
            #region bwy from borderusercontrol
            
            this.AutoScroll = true;
            this.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
            if (DoubleBuffer)
            {
                this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
                this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
                this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            }
            #endregion from borderusercontrol
        }

        #region bwy : from borderusercontrol
        /// <summary>
        /// 是否启用双缓冲设置
        /// </summary>
        public static bool DoubleBuffer = false;

        /// <summary>
        /// 发生滚动时的处理
        /// </summary>
        public event System.EventHandler Scroll = null;
        /// <summary>
        /// 触发滚动事件
        /// </summary>

        /// <summary>
        /// 内部的调用 OnScroll 的接口
        /// </summary>
        internal void InnerOnScroll()
        {
            OnScroll();
        }
        /// <summary>
        /// 边框样式
        /// </summary>
        protected System.Windows.Forms.BorderStyle intBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        /// <summary>
        /// 边框样式
        /// </summary>
        public System.Windows.Forms.BorderStyle BorderStyle
        {
            get { return intBorderStyle; }
            set
            {
                intBorderStyle = value;
                this.RecreateHandle();
            }
        }

        /// <summary>
        /// 初始化创建控件的参数对象
        /// </summary>
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams p = base.CreateParams;
                switch (intBorderStyle)
                {
                    case System.Windows.Forms.BorderStyle.None:
                        break;
                    case System.Windows.Forms.BorderStyle.Fixed3D:
                        p.ExStyle = p.ExStyle | 0x00000200;
                        //(int)Windows32.WindowExStyles.WS_EX_CLIENTEDGE;
                        break;
                    case System.Windows.Forms.BorderStyle.FixedSingle:
                        p.ExStyle = p.ExStyle | 0x00020000;//(int)Windows32.WindowExStyles.WS_EX_STATICEDGE ;
                        break;
                }
                return p;
            }
        }

        /// <summary>
        /// 设置是否可见水平滚动条
        /// </summary>
        /// <param name="flag">设置值</param>
        public void SetHScroll(bool flag)
        {
            HScroll = flag;
        }
        /// <summary>
        /// 设置是否可见垂直滚动条
        /// </summary>
        /// <param name="flag">设置值</param>
        public void SetVScroll(bool flag)
        {
            VScroll = flag;
        }


        #endregion bwy : from borderusercontrol

        protected System.Windows.Forms.Cursor myDefaultCursor = System.Windows.Forms.Cursors.Default;
        /// <summary>
        /// 控件默认鼠标光标
        /// </summary>
        public System.Windows.Forms.Cursor DefaultCursor
        {
            get { return myDefaultCursor; }
            set { myDefaultCursor = value; }
        }

        #region *****************缩放*************************
        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="rate">缩放倍数</param>
        public void Zoom(float rate)
        {
            fXZoomRate *= rate;
            fYZoomRate *= rate;
            if (fXZoomRate <= 0)
                fXZoomRate = 1f;
            if (fYZoomRate <= 0)
                fYZoomRate = 1f;

#region bwy 

#endregion bwy
            this.UpdateViewBounds();
            this.Invalidate();
        }
        protected float fXZoomRate = 1.0f;
        /// <summary>
        /// X方向缩放率
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public float XZoomRate
        {
            get { return fXZoomRate; }
            set
            {
                if (fXZoomRate != value)
                {
                    fXZoomRate = value;
                    this.UpdateViewBounds();
                    this.Invalidate();
                }
            }
        }

        protected float fYZoomRate = 1.0f;
        /// <summary>
        /// Y方向缩放率
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public float YZoomRate
        {
            get { return fYZoomRate; }
            set
            {
                if (fYZoomRate != value)
                {
                    fYZoomRate = value;
                    this.UpdateViewBounds();
                    this.Invalidate();
                }
            }
        }

        protected void CheckZoomRate()
        {
            if (this.fXZoomRate <= 0 || this.fYZoomRate <= 0)
                throw new System.InvalidOperationException("Bad zoom rate value");
        }
        #endregion

        /// <summary>
        /// 绘图单位
        /// </summary>
        protected System.Drawing.GraphicsUnit intGraphicsUnit = System.Drawing.GraphicsUnit.Pixel;
        /// <summary>
        /// 绘图单位
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public System.Drawing.GraphicsUnit GraphicsUnit
        {
            get { return intGraphicsUnit; }
            set
            {
                intGraphicsUnit = value;
                this.UpdateViewBounds();
                this.Invalidate();
            }
        }

        [System.ComponentModel.Browsable(false)]
        public virtual System.Drawing.Size ViewAutoScrollMinSize
        {
            get
            {
                System.Drawing.Size size = this.AutoScrollMinSize;
                size = GraphicsUnitConvert.Convert(
                    size,
                    System.Drawing.GraphicsUnit.Pixel,
                    this.intGraphicsUnit);
                size.Width = (int)(size.Width * this.fXZoomRate);
                size.Height = (int)(size.Height * this.fYZoomRate);
                return size;
            }
            set
            {
                System.Drawing.Size size = GraphicsUnitConvert.Convert(
                    value,
                    this.intGraphicsUnit,
                    System.Drawing.GraphicsUnit.Pixel);
                size.Width = (int)(size.Width / this.fXZoomRate);
                size.Height = (int)(size.Height / this.fYZoomRate);
                this.AutoScrollMinSize = size;
            }
        }

        [System.ComponentModel.Browsable(false)]
        public double ClientToViewXRate
        {
            get
            {
                double rate = GraphicsUnitConvert.GetRate(
                    this.intGraphicsUnit,
                    System.Drawing.GraphicsUnit.Pixel);
                rate /= this.fXZoomRate;
                return rate;
            }
        }
        [System.ComponentModel.Browsable(false)]
        public double ClientToViewYRate
        {
            get
            {
                double rate = GraphicsUnitConvert.GetRate(
                    this.intGraphicsUnit,
                    System.Drawing.GraphicsUnit.Pixel);
                rate /= this.fYZoomRate;
                return rate;
            }
        }
        [System.ComponentModel.Browsable(false)]
        public virtual System.Drawing.Point ViewAutoScrollPosition
        {
            get
            {
                System.Drawing.Point p = this.AutoScrollPosition;
                p = GraphicsUnitConvert.Convert(
                    p,
                    System.Drawing.GraphicsUnit.Pixel,
                    this.intGraphicsUnit);
                p.X = (int)(p.X * this.fXZoomRate);
                p.Y = (int)(p.Y * this.fYZoomRate);
                return p;
            }
            set
            {
                System.Drawing.Point p = GraphicsUnitConvert.Convert(
                    value,
                    this.intGraphicsUnit,
                    System.Drawing.GraphicsUnit.Pixel);
                p.X = (int)(p.X / this.fXZoomRate);
                p.Y = (int)(p.Y / this.fYZoomRate);
                this.SetAutoScrollPosition(p);
            }
        }

        [System.ComponentModel.Browsable(false)]
        public virtual System.Drawing.Size ViewClientSize
        {
            get
            {
                System.Drawing.Size size = GraphicsUnitConvert.Convert(
                    this.ClientSize,
                    System.Drawing.GraphicsUnit.Pixel,
                    this.intGraphicsUnit);
                size.Width = (int)(size.Width * this.fXZoomRate);
                size.Height = (int)(size.Height * this.fYZoomRate);
                return size;
            }
        }
        [System.ComponentModel.Browsable(false)]
        public virtual System.Drawing.Rectangle ViewClientRectangle
        {
            get
            {
                System.Drawing.Rectangle rect = GraphicsUnitConvert.Convert(this.ClientRectangle,
                    System.Drawing.GraphicsUnit.Pixel,
                    this.intGraphicsUnit);
                rect.X = (int)(rect.X * this.fXZoomRate);
                rect.Y = (int)(rect.Y * this.fYZoomRate);
                rect.Width = (int)(rect.Width * this.fXZoomRate);
                rect.Height = (int)(rect.Height * this.fYZoomRate);
                return rect;
            }
        }

        /// <summary>
        /// 从控件客户区到视图区的转换对象
        /// </summary>
        protected TransformBase myTransform = new SimpleRectangleTransform();

        /// <summary>
        /// 内部的从控件客户区到视图区的转换对象
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public TransformBase Transform
        {
            get { return this.myTransform; }
        }
        /// <summary>
        /// 刷新坐标转换对象
        /// </summary>
        protected virtual void RefreshScaleTransform()
        {
            Debug.WriteLine(" documentview call RefreshScaleTransform()");
            SimpleRectangleTransform transform = this.myTransform as SimpleRectangleTransform;
            if (transform == null)
                return;

            System.Drawing.Rectangle rect = this.ClientRectangle;
            transform.SourceRect = rect;
            System.Drawing.Point p = this.AutoScrollPosition;
            //rect.Offset( this.AutoScrollPosition.X ,   this.AutoScrollPosition.Y );
            //transform.SourceRect = rect ;

            float xrate = (float)this.ClientToViewXRate;
            float yrate = (float)this.ClientToViewYRate;

            transform.DescRectF = new System.Drawing.RectangleF(
                -p.X * xrate,
                -p.Y * yrate,
                rect.Width * xrate,
                rect.Height * yrate);
        }

        /// <summary>
        /// 将客户区坐标转换为视图区坐标
        /// </summary>
        /// <param name="x">客户区点X坐标</param>
        /// <param name="y">客户区点Y坐标</param>
        /// <returns>转换后的视图点坐标</returns>
        public virtual System.Drawing.Point ClientPointToView(int x, int y)
        {
            this.RefreshScaleTransform();
            return myTransform.TransformPoint(x, y);
        }
        /// <summary>
        /// 将客户区坐标转换为视图区坐标
        /// </summary>
        /// <param name="p">客户区点坐标</param>
        /// <returns>视图区点坐标</returns>
        public virtual System.Drawing.Point ClientPointToView(System.Drawing.Point p)
        {
            this.RefreshScaleTransform();
            return myTransform.TransformPoint(p);
        }
        //		
        //		public virtual System.Drawing.Rectangle ClipRectangleToView( System.Drawing.Rectangle rect )
        //		{
        //			this.RefreshScaleTransform();
        //			return myTransform.TransformRectangle( rect );
        //		}

        /// <summary>
        /// 将视图区坐标转换为客户区坐标
        /// </summary>
        /// <param name="x">视图区X坐标</param>
        /// <param name="y">视图区Y坐标</param>
        /// <returns>客户区坐标</returns>
        public virtual System.Drawing.Point ViewPointToClient(int x, int y)
        {
            this.RefreshScaleTransform();
            return myTransform.UnTransformPoint(x, y);
        }
        /// <summary>
        /// 将视图区坐标转换为客户区坐标
        /// </summary>
        /// <param name="p">视图区坐标</param>
        /// <returns>客户区坐标</returns>
        public virtual System.Drawing.Point ViewPointToClient(System.Drawing.Point p)
        {
            this.RefreshScaleTransform();
            return myTransform.UnTransformPoint(p);
        }
        /// <summary>
        /// 鼠标在控件上的位置
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public virtual System.Drawing.Point ClientMousePosition
        {
            get
            {
                System.Drawing.Point p = System.Windows.Forms.Control.MousePosition;
                p = this.PointToClient(p);
                if (this.ClientRectangle.Contains(p))
                    return p;
                else
                    return System.Drawing.Point.Empty;
            }
        }

        /// <summary>
        /// 鼠标在视图区中的坐标
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public virtual System.Drawing.Point ViewMousePosition
        {
            get
            {
                System.Drawing.Point p = this.ClientMousePosition;
                if (p.IsEmpty == false)
                    return this.ClientPointToView(p);
                else
                    return System.Drawing.Point.Empty;
            }
        }

        protected System.Drawing.Rectangle myViewBounds = System.Drawing.Rectangle.Empty;
        /// <summary>
        /// 整个视图区域的矩形区域
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public System.Drawing.Rectangle ViewBounds
        {
            get { return myViewBounds; }
            set
            {
                if (myViewBounds.Equals(value) == false)
                {
                    myViewBounds = value;
                    this.UpdateViewBounds();
                }
            }
        }

        public virtual void UpdateViewBounds()
        {
            System.Drawing.Size size = new Size(myViewBounds.Right, myViewBounds.Bottom);
            this.RefreshScaleTransform();
            size = myTransform.UnTransformSize(size);
            this.AutoScrollMinSize = size;
        }

        //public virtual System.Windows.Forms.MouseEventArgs CreateViewMouseEventArgs()
        //{
        //    System.Drawing.Point p = this.ViewMousePosition;
        //    return new System.Windows.Forms.MouseEventArgs(System.Windows.Forms.Control.MouseButtons, 0, p.X, p.Y, 0);
        //}

        protected bool bolMouseDragScroll = false;
        /// <summary>
        /// 使用鼠标拖拽滚动模式标记
        /// </summary>
        public bool MouseDragScroll
        {
            get { return this.bolMouseDragScroll; }
            set { this.bolMouseDragScroll = value; }
        }
        protected System.Drawing.Point myMouseDragPoint = System.Drawing.Point.Empty;

        /// <summary>
        /// 重写基类的OnScroll
        /// </summary>
        //protected override void OnScroll()
        public virtual void OnScroll()
        {
            //base.OnScroll();
            if (Scroll != null)
                Scroll(this, null);
            this.RefreshScaleTransform();
        }


        //protected void Control_OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //}

        public event System.Windows.Forms.MouseEventHandler ViewMouseDown = null;
        /// <summary>
        /// 鼠标按键在视图区中按下事件处理
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnViewMouseDown(MouseEventArgs e)
        {
            Debug.WriteLine("DocumentViewControl：OnViewMouseDown");
            if (ViewMouseDown != null)
                ViewMouseDown(this, e);
        }



        public event System.Windows.Forms.MouseEventHandler ViewMouseMove = null;
        /// <summary>
        /// 鼠标在视图区中的移动事件处理
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnViewMouseMove(MouseEventArgs e)
        {
            //Debug.WriteLine("documentviewcontrol OnViewMouseMove");
            if (ViewMouseMove != null)
                ViewMouseMove(this, e);
        }


        /// <summary>
        /// 视图区域中的鼠标按键松开事件
        /// </summary>
        public event System.Windows.Forms.MouseEventHandler ViewMouseUp = null;
        /// <summary>
        /// 鼠标在视图区中的按键松开事件处理
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnViewMouseUp(MouseEventArgs e)
        {
            if (ViewMouseUp != null)
                ViewMouseUp(this, e);
        }

        /// <summary>
        /// 鼠标在视图中的单击事件
        /// </summary>
        public event System.Windows.Forms.MouseEventHandler ViewClick = null;
        /// <summary>
        /// 处理鼠标在视图区域中的单击事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnViewClick(System.Windows.Forms.MouseEventArgs e)
        {
            if (ViewClick != null)
                ViewClick(this, e);
        }



        /// <summary>
        /// 鼠标在视图区中双击事件
        /// </summary>
        public event System.Windows.Forms.MouseEventHandler ViewDoubleClick = null;
        /// <summary>
        /// 处理鼠标在视图区域中的双击事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnViewDoubleClick(System.Windows.Forms.MouseEventArgs e)
        {
            if (ViewDoubleClick != null)
                ViewDoubleClick(this, e);
        }

        /// <summary>
        /// 已重载:重新绘制视图的事件处理
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.CheckZoomRate();
            this.RefreshScaleTransform();
            TransformPaint(e, this.myTransform as SimpleRectangleTransform);
        }

        protected virtual void TransformPaint(PaintEventArgs e, SimpleRectangleTransform trans)
        {
            if (trans == null)
                return;

            System.Drawing.Rectangle rect = e.ClipRectangle;
            rect.Offset(-1, -1);
            rect.Width += 2;
            rect.Height += 2;
            rect = System.Drawing.Rectangle.Intersect(trans.SourceRect, rect);
            if (rect.IsEmpty)
                return;

            System.Drawing.RectangleF rectf = trans.TransformRectangleF(
                rect.Left,
                rect.Top,
                rect.Width,
                rect.Height);// this.ClipRectangleToView( e.ClipRectangle );
            rect.X = (int)Math.Floor(rectf.Left);
            rect.Y = (int)Math.Floor(rectf.Top);
            rect.Width = (int)System.Math.Ceiling(rectf.Width);
            rect.Height = (int)System.Math.Ceiling(rectf.Height);

            e.Graphics.PageUnit = this.intGraphicsUnit;
            e.Graphics.ResetTransform();

            //e.Graphics.TranslateTransform( trans.SourceRect.Left , trans.SourceRect.Top );
            e.Graphics.ScaleTransform(this.fXZoomRate, this.fYZoomRate);
            double rate = this.ClientToViewXRate * this.fXZoomRate;

            e.Graphics.TranslateTransform(
                (float)(trans.SourceRect.Left * rate - trans.DescRectF.X),
                (float)(trans.SourceRect.Top * rate - trans.DescRectF.Y));

            if (trans.XZoomRate < 1)
                rect.Width = rect.Width + (int)System.Math.Ceiling(1 / trans.XZoomRate);

            if (trans.YZoomRate < 1)
                rect.Height = rect.Height + (int)System.Math.Ceiling(1 / trans.YZoomRate);

            System.Windows.Forms.PaintEventArgs e2 =
                new System.Windows.Forms.PaintEventArgs(
                e.Graphics,
                rect);

            e2.Graphics.ResetClip();


            OnViewPaint(e2, trans);
        }

        /// <summary>
        /// 绘制视图的事件
        /// </summary>
        public event System.Windows.Forms.PaintEventHandler ViewPaint = null;
        /// <summary>
        /// 重新绘制视图的事件处理
        /// </summary>
        /// <param name="e">事件参数</param>
        protected virtual void OnViewPaint(PaintEventArgs e, SimpleRectangleTransform trans)
        {
            if (ViewPaint != null)
                ViewPaint(this, e);
        }

        public System.Drawing.Graphics CreateViewGraphics()
        {
            System.Drawing.Graphics g = this.CreateGraphics();
            g.PageUnit = this.intGraphicsUnit;
            return g;
        }
        protected System.Drawing.Bitmap CreateContentBitmap(float rate, System.Drawing.Color BmpBackColor)
        {
            SimpleRectangleTransform trans = this.myTransform as SimpleRectangleTransform;
            if (trans == null)
                return null;

            System.Drawing.Size size = this.AutoScrollMinSize;
            size.Width = (int)(size.Width * rate);
            size.Height = (int)(size.Height * rate);
            if (size.Width <= 0 || size.Height <= 0)
                return null;
            System.Drawing.Bitmap bmp = new Bitmap(size.Width, size.Height);
            float rate2 = rate;

            float rateback = this.fXZoomRate;
            try
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
                {
                    g.Clear(BmpBackColor);
                    g.PageUnit = this.intGraphicsUnit;
                    g.ScaleTransform(rate2, rate2);
                    g.TranslateTransform(-trans.DescRectF.X, -trans.DescRectF.Y);
                    System.Windows.Forms.PaintEventArgs e = new PaintEventArgs(g, trans.DescRect);
                    this.fXZoomRate = rate;
                    this.OnViewPaint(e, trans);
                    this.fXZoomRate = rateback;
                }
                return bmp;
            }
            catch (Exception ext)
            {
                this.fXZoomRate = rateback;
                throw ext;
            }
        }
        //
        //		public void ViewInvertRect( System.Drawing.Rectangle rect )
        //		{
        //			rect = this.myTransform.UnTransformRectangle( rect );
        //			
        //		}
        /// <summary>
        /// 使用视图坐标来指定区域无效
        /// </summary>
        /// <param name="ViewBounds">无效区域</param>
        public virtual void ViewInvalidate(System.Drawing.Rectangle ViewBounds)
        {
            this.RefreshScaleTransform();
            System.Drawing.Rectangle rect = myTransform.UnTransformRectangle(ViewBounds);
            //System.Console.WriteLine( rect.Width + " " + rect.Height );
            this.Invalidate(rect);
        }
#if CaptureMouseMove
        //protected class MyCapturer : MouseCapturer
        //{
        //    public DocumentViewControl Control = null;
        //    protected override CaptureMouseMoveEventArgs CreateArgs()
        //    {
        //        DocumentViewControl ctl = (DocumentViewControl)base.BindControl;
        //        CaptureMouseMoveEventArgs e = base.CreateArgs();
        //        e.StartPosition = ctl.myTransform.TransformPoint(e.StartPosition);
        //        e.CurrentPosition = ctl.myTransform.TransformPoint(e.CurrentPosition);
        //        return e;
        //    }
        //    public int DragStyle = 0;
        //    public System.Drawing.Rectangle[] Rects = null;
        //    public System.Drawing.Rectangle ViewClipRectangle = System.Drawing.Rectangle.Empty;
        //}

        ///// <summary>
        ///// 进行鼠标拖拽操作
        ///// </summary>
        ///// <param name="DrawFunction">鼠标拖拽期间的回调函数委托</param>
        ///// <param name="ClipRectangle">使用视图坐标的剪切矩形</param>
        ///// <returns>点坐标数组,包含开始拖拽和结束拖拽时鼠标的视图坐标位置</returns>
        //public virtual System.Drawing.Point[] CaptureMouseMove(
        //    CaptureMouseMoveEventHandler DrawFunction,
        //    System.Drawing.Rectangle ClipRectangle,
        //    object Tag)
        //{
        //    if (this.bolMouseDragScroll)
        //        return null;

        //    this.RefreshScaleTransform();

        //    MyCapturer mc = new MyCapturer();
        //    mc.Tag = Tag;
        //    mc.BindControl = this;
        //    if (ClipRectangle.IsEmpty == false)
        //    {
        //        ClipRectangle = myTransform.UnTransformRectangle(ClipRectangle);
        //        mc.ClipRectangle = ClipRectangle;
        //    }
        //    mc.ReversibleShape = ReversibleShapeStyle.Custom;
        //    if (DrawFunction != null)
        //        mc.Draw += DrawFunction;
        //    if (mc.CaptureMouseMove())
        //    {

        //        System.Drawing.Point p1 = mc.StartPosition;
        //        p1 = myTransform.TransformPoint(p1);

        //        System.Drawing.Point p2 = mc.EndPosition;
        //        p2 = myTransform.TransformPoint(p2);

        //        return new System.Drawing.Point[] { p1, p2 };
        //    }//if
        //    return null;
        //}

        ///// <summary>
        ///// 使用鼠标拖拽获得一个矩形
        ///// </summary>
        ///// <param name="ClipRectangle">剪切矩形</param>
        ///// <returns>获得的矩形区域</returns>
        //public System.Drawing.Point[] GetCaptureMouseRectangle(System.Drawing.Rectangle ClipRectangle)
        //{
        //    return CaptureMouseMove(
        //        new CaptureMouseMoveEventHandler(this.myCaptureRectangle),
        //        ClipRectangle,
        //        null);
        //}
        ///// <summary>
        ///// 使用鼠标拖拽获得一个线段
        ///// </summary>
        ///// <param name="ClipRectangle">剪切矩形</param>
        ///// <returns>线段的两个端点坐标组成的数组</returns>
        //public System.Drawing.Point[] GetCaptureMouseLine(System.Drawing.Rectangle ClipRectangle)
        //{
        //    return CaptureMouseMove(
        //        new CaptureMouseMoveEventHandler(this.myCaptureLine),
        //        ClipRectangle,
        //        null);
        //}
        //private void myCaptureRectangle(object sender, CaptureMouseMoveEventArgs e)
        //{
        //    System.Drawing.Rectangle rect = RectangleCommon.GetRectangle(
        //        e.StartPosition,
        //        e.CurrentPosition);
        //    if (rect.IsEmpty == false)
        //        ReversibleViewDrawRect(rect);
        //}
        //private void myCaptureLine(object sender, CaptureMouseMoveEventArgs e)
        //{
        //    ReversibleViewDrawLine(e.StartPosition, e.CurrentPosition);
        //}

#endif

#if ReversibleDraw

        /// <summary>
        /// 使用视图坐标绘制一个可逆线段
        /// </summary>
        /// <param name="x1">线段起点X坐标</param>
        /// <param name="y1">线段起点Y坐标</param>
        /// <param name="x2">线段终点X坐标</param>
        /// <param name="y2">线段终点Y坐标</param>
        public void ReversibleViewDrawLine(
            int x1,
            int y1,
            int x2,
            int y2)
        {
            throw new NotImplementedException("documentviewcontrol:ReversibleViewDrawLine");
            //using (ReversibleDrawer drawer = ReversibleDrawer.FromHwnd(this.Handle))
            //{
            //    drawer.PenStyle = PenStyle.PS_DOT;
            //    drawer.PenColor = System.Drawing.Color.Red;
            //    this.RefreshScaleTransform();
            //    System.Drawing.Point p1 = myTransform.UnTransformPoint(x1, y1);
            //    System.Drawing.Point p2 = myTransform.UnTransformPoint(x2, y2);

            //    drawer.DrawLine(p1, p2);
            //}
        }

        /// <summary>
        /// 使用视图坐标绘制一个可逆线段边框
        /// </summary>
        /// <param name="p1">线段起点坐标</param>
        /// <param name="p2">线段终点坐标</param>
        public void ReversibleViewDrawLine(
            System.Drawing.Point p1,
            System.Drawing.Point p2)
        {
            ReversibleViewDrawLine(p1.X, p1.Y, p2.X, p2.Y);
        }
        /// <summary>
        /// 使用视图坐标绘制一个可逆矩形
        /// </summary>
        /// <param name="rect">矩形坐标</param>
        public void ReversibleViewDrawRect(System.Drawing.Rectangle rect)
        {
            ReversibleViewDrawRect(rect.Left, rect.Top, rect.Width, rect.Height);
        }
        /// <summary>
        /// 使用视图坐标绘制一个可逆矩形边框
        /// </summary>
        /// <param name="left">矩形的左端位置</param>
        /// <param name="top">矩形的顶端位置</param>
        /// <param name="width">矩形的宽度</param>
        /// <param name="height">矩形的高度</param>
        public void ReversibleViewDrawRect(
            int left,
            int top,
            int width,
            int height)
        {
            //throw new NotImplementedException("documentviewcontrol:ReversibleViewDrawRect");
            using (ReversibleDrawer drawer
                       = ReversibleDrawer.FromHwnd(this.Handle))
            {
                drawer.PenStyle = PenStyle.PS_DOT;
                drawer.PenColor = System.Drawing.Color.Red;
                this.RefreshScaleTransform();
                System.Drawing.Rectangle rect
                    = this.myTransform.UnTransformRectangle(left, top, width, height);

                drawer.DrawRectangle(rect);
            }
        }
        /// <summary>
        /// 使用绘图坐标填充一个可逆矩形区域
        /// </summary>
        /// <param name="rect">矩形区域</param>
        public void ReversibleViewFillRect(System.Drawing.Rectangle rect)
        {
            ReversibleViewFillRect(rect.Left, rect.Top, rect.Width, rect.Height);
        }
        /// <summary>
        /// 使用绘图坐标填充一个可逆矩形区域
        /// </summary>
        /// <param name="left">矩形的左端位置</param>
        /// <param name="top">矩形的顶端位置</param>
        /// <param name="width">矩形的宽度</param>
        /// <param name="height">矩形的高度</param>
        public void ReversibleViewFillRect(int left, int top, int width, int height)
        {
            throw new NotImplementedException("documentviewcontrol:ReversibleViewDrawRect");
            //using (ReversibleDrawer drawer
            //           = ReversibleDrawer.FromHwnd(this.Handle))
            //{
            //    this.RefreshScaleTransform();
            //    System.Drawing.RectangleF rect = this.myTransform.UnTransformRectangleF(left, top, width, height);

            //    drawer.FillRectangle(System.Drawing.Rectangle.Ceiling(rect));
            //}
        }

        /// <summary>
        /// 使用绘图坐标填充一个可逆矩形区域
        /// </summary>
        /// <param name="rect">矩形区域</param>
        public void ReversibleViewFillRect(System.Drawing.Rectangle rect, System.Drawing.Graphics g)
        {
            ReversibleViewFillRect(rect.Left, rect.Top, rect.Width, rect.Height, g);
        }
        /// <summary>
        /// 使用绘图坐标填充一个可逆矩形区域
        /// </summary>
        /// <param name="left">矩形的左端位置</param>
        /// <param name="top">矩形的顶端位置</param>
        /// <param name="width">矩形的宽度</param>
        /// <param name="height">矩形的高度</param>
        /// 
        #region bwy :
        public void ReversibleViewFillRect(int left, int top, int width, int height, System.Drawing.Graphics g)
        {
            //throw new NotImplementedException("documentviewcontrol:ReversibleViewDrawRect");
            IntPtr hdc = g.GetHdc();
            //using (ReversibleDrawer drawer = ReversibleDrawer.FromHDC(hdc))
            //{

            this.RefreshScaleTransform();
            //System.Drawing.Rectangle rect = this.myTransform.UnTransformRectangle(left, top, width, height); //add by myc 2014-07-24 页眉、正文和页脚统一管理方式需要
             
            #region add by myc 2014-07-03 添加原因：新版页眉二期改版之页眉区域反色高亮绘制——>已被注释2014-07-24 页眉、正文和页脚统一管理方式下无须走以下流程
            //if (ZYTextDocument.CurrentEditingArea == 0)
            //{
            //    for (int i = 0; i < ZYTextDocument.HeaderTransforms.Count; i++)
            //    {
            //        SimpleRectangleTransform headerTransform = ZYTextDocument.HeaderTransforms[i] as SimpleRectangleTransform;
            //        //if (headerTransform.DescRect.Top <= vTop && headerTransform.DescRect.Top + headerTransform.DescRect.Height >= vTop + vHeight)
            //        if (headerTransform.DescRect.Contains(left, top))
            //        {
            //            rect = headerTransform.UnTransformRectangle(left, top, width, height);
            //            break;
            //        }
            //    }
            //}
            //else if (ZYTextDocument.CurrentEditingArea == 2) //add by myc 2014-07-07 添加原因：新版页脚之页脚区域反色高亮绘制
            //{
            //    for (int i = 0; i < ZYTextDocument.FooterTransforms.Count; i++)
            //    {
            //        SimpleRectangleTransform footerTransform = ZYTextDocument.FooterTransforms[i] as SimpleRectangleTransform;
            //        //if (footerTransform.DescRect.Top <= vTop && footerTransform.DescRect.Top + headerTransform.DescRect.Height >= vTop + vHeight)
            //        if (footerTransform.DescRect.Contains(left, top))
            //        {
            //            rect = footerTransform.UnTransformRectangle(left, top, width, height);
            //            break;
            //        }
            //    }
            //}
            #endregion



            //    drawer.FillRectangle(rect);
            //}
            RECT rc = new RECT();
            #region add by myc 2014-07-24 注释原因：页眉、正文和页脚统一管理需要
            //rc.left = rect.Left;
            //rc.top = rect.Top;
            //rc.right = rect.Left + rect.Width;
            //rc.bottom = rect.Top + rect.Height; 
            #endregion

            #region add by myc 2014-07-24 添加原因：页眉、正文和页脚统一管理需要——>这里的坐标由ZYTextDocument中调用的反色绘制接口已经转换成客户区坐标了
            rc.left = left;
            rc.top = top;
            rc.right = left + width;
            rc.bottom = top + height;
            #endregion
            
            InvertRect(hdc, ref rc);
            g.ReleaseHdc(hdc);
        }

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int InvertRect(IntPtr hdc, ref RECT vRect);

        #endregion bwy :


       





#endif

        #region 处理自动滚动的成员 ********************************************

        /// <summary>
        /// 移动滚动定位位置
        /// </summary>
        /// <param name="p">滚动改变量</param>
        public void MoveScrollPos(System.Drawing.Point p)
        {
            MoveScrollPos(p.X, p.Y);
        }
        /// <summary>
        /// 移动滚动定位位置
        /// </summary>
        /// <param name="dx">横向滚动量</param>
        /// <param name="dy">纵向滚动量</param>
        public virtual void MoveScrollPos(int dx, int dy)
        {
            if (dx != 0 || dy != 0)
            {
                System.Drawing.Point p = this.AutoScrollPosition;
                this.SetAutoScrollPosition(new System.Drawing.Point(dx - p.X, dy - p.Y));
            }
        }

        /// <summary>
        /// 滚动控件,保证指定区域在控件显示区域,参数采用视图坐标
        /// </summary>
        /// <param name="rect">指定的区域</param>
        /// <returns>操作是否导致滚动</returns>
        public virtual bool ScrollToView(System.Drawing.Rectangle rect)
        {
            return ScrollToView(rect.Left, rect.Top, rect.Width, rect.Height);
        }
        /// <summary>
        /// 滚动控件,保证指定区域在控件显示区域中,参数采用视图坐标
        /// </summary>
        /// <param name="x">指定区域的左端位置</param>
        /// <param name="y">指定区域的顶端位置</param>
        /// <param name="width">指定区域的宽度</param>
        /// <param name="height">指定区域的高度</param>
        /// <returns>操作是否导致滚动</returns>
        public bool ScrollToView(int x, int y, int width, int height)
        {
            System.Drawing.Rectangle rect = myTransform.UnTransformRectangle(x, y, width, height);
            if (rect.IsEmpty == false)
            {
                //rect.Offset(  - this.AutoScrollPosition.X , - this.AutoScrollPosition.Y );
                return InnerScrollToView(rect.Left, rect.Top, rect.Width, rect.Height);
            }
            else
                return false;
        }
        private bool bolScrollFlag = false;
        /// <summary>
        /// 进行滚动的标志
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public bool ScrollFlag
        {
            get { return bolScrollFlag; }
            set { bolScrollFlag = value; }
        }
        /// <summary>
        /// 滚动控件,保证指定区域在控件显示区域中
        /// </summary>
        /// <param name="x">指定区域的左端位置</param>
        /// <param name="y">指定区域的顶端位置</param>
        /// <param name="width">指定区域的宽度</param>
        /// <param name="height">指定区域的高度</param>
        /// <returns>操作是否导致滚动</returns>
        public bool InnerScrollToView(int x, int y, int width, int height)
        {
            bool bolResult = false;
            if (width >= 0 && height >= 0)
            {
                //if( x < 0 ) x = 0 ;
                //if( y < 0 ) y = 0 ;
                int dx = 0;
                int dy = 0;
                System.Drawing.Point myPoint = new System.Drawing.Point(x, y);
                System.Drawing.Size clientSize = this.ClientSize;
                System.Drawing.Point ScrollPos = this.AutoScrollPosition;

                if (myPoint.X > clientSize.Width - width + 3)
                {
                    if (clientSize.Width - width + 3 > 0)
                        dx = myPoint.X - clientSize.Width + width + 3;
                }
                if (width > clientSize.Width)
                {
                    if (myPoint.X > 3)
                        dx = myPoint.X - 3;
                    if (myPoint.X + width < clientSize.Width)
                        dx = myPoint.X - clientSize.Width + width + 3;
                }
                else
                {
                    if (myPoint.X < 0)
                        dx = myPoint.X - 3;
                }

                if (myPoint.Y > clientSize.Height - height + 3)
                {
                    if (clientSize.Height - height + 3 > 0)
                        dy = myPoint.Y - clientSize.Height + height + 3;
                    else
                    {
                        if (myPoint.Y + height < 0)
                            dy = myPoint.Y - clientSize.Height + height + 3;
                        else if (myPoint.Y > clientSize.Height)
                            dy = myPoint.Y - 3;
                    }
                }
                if (height > clientSize.Height)
                {
                    if (myPoint.Y > 3)
                        dy = myPoint.Y - 3;
                    if (myPoint.Y + height < clientSize.Height)
                        dy = myPoint.Y - clientSize.Height + height + 3;
                }
                else
                {
                    if (myPoint.Y < 0)
                        dy = myPoint.Y - 3;
                }

                if (dx != 0 || dy != 0)
                {
                    bolScrollFlag = true;
                    Debug.WriteLine( "DX:" + dx + " DY:" + dy );
                    System.Drawing.Point p = new System.Drawing.Point(
                        dx - this.AutoScrollPosition.X,
                        dy - this.AutoScrollPosition.Y);
                    SetAutoScrollPosition(p);
                    bolResult = true;
                }
            }
            return bolResult;
        }

        /// <summary>
        /// P 是客户端坐标
        /// </summary>
        /// <param name="p"></param>
        public void SetAutoScrollPosition(System.Drawing.Point p)
        {
            if (StackTraceHelper.CheckRecursion())
                return;
            //XDesignerCommon.StackTraceHelper.OutputStackTrace();

            bolScrolling = true;
            this.AutoScrollPosition = p;
            bolScrolling = false;
            this.OnScroll();
            Debug.WriteLine("End Scroll");
        }
        /// <summary>
        /// 视图正在滚动中
        /// </summary>
        protected bool bolScrolling = false;

        #endregion

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }
}
