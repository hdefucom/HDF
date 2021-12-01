using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms.Native;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
    /// <summary>
    ///       文档视图控件
    ///       </summary>
    [ToolboxItem(false)]
    [ComVisible(true)]
    [Guid("00012345-6789-ABCD-EF01-234567890006")]
    [DocumentComment]
    public class DocumentViewControl : BorderUserControl
    {
        protected class MyCapturer : MouseCapturer
        {
            public BorderUserControl borderUserControl_0 = null;

            public int int_0 = 0;

            public Rectangle[] rectangle_1 = null;

            public Rectangle rectangle_2 = Rectangle.Empty;

            protected override CaptureMouseMoveEventArgs vmethod_0()
            {
                DocumentViewControl documentViewControl = (DocumentViewControl)base.BindControl;
                CaptureMouseMoveEventArgs gEventArgs = base.vmethod_0();
                gEventArgs.method_4(documentViewControl.MouseCaptureTransform.TransformPoint(gEventArgs.method_3()));
                gEventArgs.method_6(documentViewControl.MouseCaptureTransform.TransformPoint(gEventArgs.method_5()));
                return gEventArgs;
            }
        }

        private bool bool_2 = false;

        private Image image_0 = null;

        protected bool bool_3 = true;

        protected Cursor cursor_0 = Cursors.Default;

        protected float _XZoomRate = 1f;

        protected float _YZoomRate = 1f;

        private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Pixel;

        protected TransformBase myTransform = new SimpleRectangleTransform();

        private PointF pointF_0 = PointF.Empty;

        protected Rectangle rectangle_0 = Rectangle.Empty;

        private Size size_0 = new Size(20, 20);

        private bool bool_4 = false;

        private System.Windows.Forms.Timer timer_0 = null;

        private bool bool_5 = false;

        protected bool bool_6 = false;

        protected Point point_0 = Point.Empty;

        private MouseEventHandler mouseEventHandler_0 = null;

        protected bool bool_7 = false;

        private MouseEventHandler mouseEventHandler_1 = null;

        private MouseEventHandler mouseEventHandler_2 = null;

        private MouseEventHandler mouseEventHandler_3 = null;

        private MouseEventHandler mouseEventHandler_4 = null;

        private PaintEventHandler paintEventHandler_0 = null;

        private UpdateLock updateLock = new UpdateLock();

        protected Rectangle rectangle_1 = Rectangle.Empty;

        protected Bitmap bitmap_1 = null;

        private GEnum64 genum64_0 = GEnum64.const_0;

        private bool bool_8 = false;

        private bool bool_9 = false;

        private bool bool_10 = false;

        private bool bool_11 = false;

        protected bool bool_12 = false;

        /// <summary>
        ///       固定背景
        ///       </summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool FixedBackground
        {
            get
            {
                return bool_2;
            }
            set
            {
                bool_2 = value;
            }
        }

        /// <summary>
        ///       标志图片
        ///       </summary>
        [DefaultValue(null)]
        [Category("Appearance")]
        public Image LogonImage
        {
            get
            {
                return image_0;
            }
            set
            {
                image_0 = value;
            }
        }

        /// <summary>
        ///       鼠标拖拽滚动时使用手形鼠标光标
        ///       </summary>
        [Browsable(false)]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool DragUseHandCursor
        {
            get
            {
                return bool_3;
            }
            set
            {
                bool_3 = value;
            }
        }

        /// <summary>
        ///       控件默认鼠标光标
        ///       </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Cursor XDefaultCursor
        {
            get
            {
                if (bool_6)
                {
                    if (bool_3)
                    {
                        return GClass291.smethod_4();
                    }
                    return cursor_0;
                }
                return cursor_0;
            }
            set
            {
                cursor_0 = value;
            }
        }

        /// <summary>
        ///       X方向缩放率
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float XZoomRate
        {
            get
            {
                return _XZoomRate;
            }
            set
            {
                if (_XZoomRate != value)
                {
                    _XZoomRate = value;
                    UpdateViewBounds();
                    Invalidate();
                }
            }
        }

        /// <summary>
        ///       Y方向缩放率
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float YZoomRate
        {
            get
            {
                return _YZoomRate;
            }
            set
            {
                if (_YZoomRate != value)
                {
                    _YZoomRate = value;
                    UpdateViewBounds();
                    Invalidate();
                }
            }
        }

        /// <summary>
        ///       绘图单位
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual GraphicsUnit GraphicsUnit
        {
            get
            {
                return graphicsUnit_0;
            }
            set
            {
                if (graphicsUnit_0 != value)
                {
                    graphicsUnit_0 = value;
                    UpdateViewBounds();
                    Invalidate();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Size ViewAutoScrollMinSize
        {
            get
            {
                Size autoScrollMinSize = base.AutoScrollMinSize;
                autoScrollMinSize = GraphicsUnitConvert.Convert(autoScrollMinSize, GraphicsUnit.Pixel, GraphicsUnit);
                autoScrollMinSize.Width = (int)((float)autoScrollMinSize.Width * _XZoomRate);
                autoScrollMinSize.Height = (int)((float)autoScrollMinSize.Height * _YZoomRate);
                return autoScrollMinSize;
            }
            set
            {
                Size size_ = GraphicsUnitConvert.Convert(value, GraphicsUnit, GraphicsUnit.Pixel);
                size_.Width = (int)((float)size_.Width / _XZoomRate);
                size_.Height = (int)((float)size_.Height / _YZoomRate);
                method_7(size_);
            }
        }

        /// <summary>
        ///       横向的客户区图形度量单位和文档视图度量单位的比率
        ///       </summary>
        [Browsable(false)]
        public double ClientToViewXRate
        {
            get
            {
                double rate = GraphicsUnitConvert.GetRate(GraphicsUnit, GraphicsUnit.Pixel);
                return rate / (double)_XZoomRate;
            }
        }

        [Browsable(false)]
        public double ClientToViewYRate
        {
            get
            {
                double rate = GraphicsUnitConvert.GetRate(GraphicsUnit, GraphicsUnit.Pixel);
                return rate / (double)_YZoomRate;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Point ViewAutoScrollPosition
        {
            get
            {
                Point autoScrollPosition = base.AutoScrollPosition;
                autoScrollPosition = GraphicsUnitConvert.Convert(autoScrollPosition, GraphicsUnit.Pixel, GraphicsUnit);
                autoScrollPosition.X = (int)((float)autoScrollPosition.X * _XZoomRate);
                autoScrollPosition.Y = (int)((float)autoScrollPosition.Y * _YZoomRate);
                return autoScrollPosition;
            }
            set
            {
                Point point_ = GraphicsUnitConvert.Convert(value, GraphicsUnit, GraphicsUnit.Pixel);
                point_.X = (int)((float)point_.X / _XZoomRate);
                point_.Y = (int)((float)point_.Y / _YZoomRate);
                SetAutoScrollPosition(point_);
            }
        }

        [Browsable(false)]
        public virtual Size ViewClientSize
        {
            get
            {
                Size result = GraphicsUnitConvert.Convert(base.ClientSize, GraphicsUnit.Pixel, GraphicsUnit);
                result.Width = (int)((float)result.Width / _XZoomRate);
                result.Height = (int)((float)result.Height / _YZoomRate);
                return result;
            }
        }

        [Browsable(false)]
        public virtual Rectangle ViewClientRectangle
        {
            get
            {
                Rectangle result = GraphicsUnitConvert.Convert(base.ClientRectangle, GraphicsUnit.Pixel, GraphicsUnit);
                result.X = (int)((float)result.X / _XZoomRate);
                result.Y = (int)((float)result.Y / _YZoomRate);
                result.Width = (int)((float)result.Width / _XZoomRate);
                result.Height = (int)((float)result.Height / _YZoomRate);
                return result;
            }
        }

        /// <summary>
        ///       用于鼠标拖拽时使用的坐标转换对象
        ///       </summary>
        [Browsable(false)]
        protected virtual TransformBase MouseCaptureTransform => myTransform;

        /// <summary>
        ///       视图区域偏移量
        ///       </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public PointF ViewOffset
        {
            get
            {
                return pointF_0;
            }
            set
            {
                pointF_0 = value;
            }
        }

        /// <summary>
        ///       内部的从控件客户区到视图区的转换对象
        ///       </summary>
        [Browsable(false)]
        public TransformBase Transform => myTransform;

        /// <summary>
        ///       鼠标在控件上的位置
        ///       </summary>
        [Browsable(false)]
        public virtual Point ClientMousePosition
        {
            get
            {
                Point mousePosition = Control.MousePosition;
                mousePosition = PointToClient(mousePosition);
                if (base.ClientRectangle.Contains(mousePosition))
                {
                    return mousePosition;
                }
                return Point.Empty;
            }
        }

        /// <summary>
        ///       鼠标在视图区中的坐标
        ///       </summary>
        [Browsable(false)]
        public virtual Point ViewMousePosition
        {
            get
            {
                Point clientMousePosition = ClientMousePosition;
                if (!clientMousePosition.IsEmpty)
                {
                    return ClientPointToView(clientMousePosition);
                }
                return Point.Empty;
            }
        }

        /// <summary>
        ///       整个视图区域的矩形区域
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ViewBounds
        {
            get
            {
                return rectangle_0;
            }
            set
            {
                if (!rectangle_0.Equals(value))
                {
                    rectangle_0 = value;
                    UpdateViewBounds();
                }
            }
        }

        /// <summary>
        ///       视图内边距大小
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size ViewBoundsMarginSize
        {
            get
            {
                return size_0;
            }
            set
            {
                size_0 = value;
            }
        }

        /// <summary>
        ///       禁止Resize事件
        ///       </summary>
        [Browsable(false)]
        public bool DisableResizeEvent => bool_4;

        /// <summary>
        ///       延时设置控件的视图区域大小,DCWriter内部使用。
        ///       </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool DelaySetAutoScrollMinSize
        {
            get
            {
                return bool_5;
            }
            set
            {
                bool_5 = value;
            }
        }

        /// <summary>
        ///       使用鼠标拖拽滚动模式标记
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MouseDragScroll
        {
            get
            {
                return bool_6;
            }
            set
            {
                bool_6 = value;
            }
        }

        /// <summary>
        ///       是否正在更新内容，锁定用户界面
        ///       </summary>
        [Browsable(false)]
        public bool IsUpdating => updateLock.IsUpdating();

        /// <summary>
        ///       可逆线条样式
        ///       </summary>
        [Browsable(false)]
        [DefaultValue(GEnum64.const_0)]
        public virtual GEnum64 ReversibleLineStyle
        {
            get
            {
                return genum64_0;
            }
            set
            {
                genum64_0 = value;
            }
        }

        /// <summary>
        ///       进行滚动的标志
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ScrollFlag
        {
            get
            {
                return bool_9;
            }
            set
            {
                bool_9 = value;
            }
        }

        /// <summary>
        ///       只一次性的锁定滚动位置
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LockScrollPositionOnce
        {
            get
            {
                return bool_10;
            }
            set
            {
                bool_10 = value;
            }
        }

        /// <summary>
        ///       锁定滚动位置
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LockScrollPosition
        {
            get
            {
                return bool_11;
            }
            set
            {
                bool_11 = value;
            }
        }

        /// <summary>
        ///       是否启用平滑滚动效果
        ///       </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [DefaultValue(true)]
        protected virtual bool SmoothScrollView => true;

        public event MouseEventHandler ViewMouseDown
        {
            add
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_0;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_0, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
            remove
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_0;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_0, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
        }

        public event MouseEventHandler ViewMouseMove
        {
            add
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_1;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_1, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
            remove
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_1;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_1, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
        }

        /// <summary>
        ///       视图区域中的鼠标按键松开事件
        ///       </summary>
        public event MouseEventHandler ViewMouseUp
        {
            add
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_2;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_2, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
            remove
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_2;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_2, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
        }

        /// <summary>
        ///       鼠标在视图中的单击事件
        ///       </summary>
        public event MouseEventHandler ViewClick
        {
            add
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_3;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_3, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
            remove
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_3;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_3, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
        }

        public event MouseEventHandler ViewMouseDoubleClick
        {
            add
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_4;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_4, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
            remove
            {
                MouseEventHandler mouseEventHandler = mouseEventHandler_4;
                MouseEventHandler mouseEventHandler2;
                do
                {
                    mouseEventHandler2 = mouseEventHandler;
                    MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
                    mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_4, value2, mouseEventHandler2);
                }
                while ((object)mouseEventHandler != mouseEventHandler2);
            }
        }

        /// <summary>
        ///       绘制视图的事件
        ///       </summary>
        public event PaintEventHandler ViewPaint
        {
            add
            {
                PaintEventHandler paintEventHandler = paintEventHandler_0;
                PaintEventHandler paintEventHandler2;
                do
                {
                    paintEventHandler2 = paintEventHandler;
                    PaintEventHandler value2 = (PaintEventHandler)Delegate.Combine(paintEventHandler2, value);
                    paintEventHandler = Interlocked.CompareExchange(ref paintEventHandler_0, value2, paintEventHandler2);
                }
                while ((object)paintEventHandler != paintEventHandler2);
            }
            remove
            {
                PaintEventHandler paintEventHandler = paintEventHandler_0;
                PaintEventHandler paintEventHandler2;
                do
                {
                    paintEventHandler2 = paintEventHandler;
                    PaintEventHandler value2 = (PaintEventHandler)Delegate.Remove(paintEventHandler2, value);
                    paintEventHandler = Interlocked.CompareExchange(ref paintEventHandler_0, value2, paintEventHandler2);
                }
                while ((object)paintEventHandler != paintEventHandler2);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (base.DesignMode)
            {
                base.OnPaintBackground(pevent);
            }
            base.OnPaintBackground(pevent);
            if (image_0 != null)
            {
                int x = base.ClientSize.Width - image_0.Width;
                int y = base.ClientSize.Height - image_0.Height;
                if (pevent.ClipRectangle.IntersectsWith(new Rectangle(x, y, image_0.Width, image_0.Height)))
                {
                    pevent.Graphics.DrawImage(image_0, x, y, image_0.Width, image_0.Height);
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
        {
            if (FixedBackground)
            {
                LockWindowUpdate(base.Handle);
                base.OnMouseWheel(mouseEventArgs_0);
                LockWindowUpdate(IntPtr.Zero);
                Invalidate();
            }
            else
            {
                base.OnMouseWheel(mouseEventArgs_0);
            }
        }

        protected override void OnScroll(ScrollEventArgs scrollEventArgs_0)
        {
            if (bool_2)
            {
                if (scrollEventArgs_0.Type == ScrollEventType.First)
                {
                    LockWindowUpdate(base.Handle);
                }
                else if (scrollEventArgs_0.Type == ScrollEventType.ThumbTrack)
                {
                    LockWindowUpdate(IntPtr.Zero);
                    Refresh();
                    LockWindowUpdate(base.Handle);
                }
                else if (scrollEventArgs_0.Type == ScrollEventType.ThumbPosition)
                {
                    LockWindowUpdate(IntPtr.Zero);
                }
                else
                {
                    LockWindowUpdate(IntPtr.Zero);
                    Invalidate();
                }
            }
            base.OnScroll(scrollEventArgs_0);
        }

        [DllImport("user32.dll")]
        private static extern bool LockWindowUpdate(IntPtr intptr_0);

        public virtual void Zoom(float float_2)
        {
            if (float_2 <= 0f)
            {
                float_2 = 1f;
            }
            _XZoomRate = float_2;
            _YZoomRate = float_2;
            UpdateViewBounds();
            Invalidate();
        }

        protected void CheckZoomRate()
        {
            int num = 2;
            if (_XZoomRate <= 0f || _YZoomRate <= 0f)
            {
                throw new InvalidOperationException("Bad zoom rate value");
            }
        }

        protected virtual void RefreshScaleTransform()
        {
            SimpleRectangleTransform gClass = myTransform as SimpleRectangleTransform;
            if (gClass != null)
            {
                Rectangle clientRectangle = base.ClientRectangle;
                gClass.set_SourceRect(clientRectangle);
                Point autoScrollPosition = base.AutoScrollPosition;
                float num = (float)ClientToViewXRate;
                float num2 = (float)ClientToViewYRate;
                RectangleF rectangleF_ = new RectangleF((float)(-autoScrollPosition.X) * num, (float)(-autoScrollPosition.Y) * num2, (float)clientRectangle.Width * num, (float)clientRectangle.Height * num2);
                rectangleF_.Offset(ViewOffset);
                gClass.set_DescRectF(rectangleF_);
            }
        }

        public virtual Point ClientPointToView(int int_2, int int_3)
        {
            RefreshScaleTransform();
            return Transform.TransformPoint(int_2, int_3);
        }

        public virtual Point ClientPointToView(Point point_1)
        {
            RefreshScaleTransform();
            return Transform.TransformPoint(point_1);
        }

        public virtual Point ViewPointToClient(int int_2, int int_3)
        {
            RefreshScaleTransform();
            return myTransform.UnTransformPoint(int_2, int_3);
        }

        public Point ViewPointToClient(Point point_1)
        {
            return ViewPointToClient(point_1.X, point_1.X);
        }

        public virtual void UpdateViewBounds()
        {
            if (!ViewBounds.IsEmpty)
            {
                Size size = new Size(ViewBounds.Right - (int)ViewOffset.X, ViewBounds.Bottom - (int)ViewOffset.Y);
                RefreshScaleTransform();
                size = myTransform.UnTransformSize(size);
                method_6(new Size(size.Width + ViewBoundsMarginSize.Width, size.Height + ViewBoundsMarginSize.Height));
                Invalidate();
            }
        }

        public void method_6(Size size_1)
        {
            if (timer_0 == null)
            {
                timer_0 = new System.Windows.Forms.Timer();
                timer_0.Tick += timer_0_Tick;
                timer_0.Interval = 50;
            }
            timer_0.Tag = size_1;
            if (timer_0.Enabled)
            {
            }
            timer_0.Start();
        }

        private void timer_0_Tick(object sender, EventArgs e)
        {
            if (timer_0 != null)
            {
                Size size = (Size)timer_0.Tag;
                timer_0.Dispose();
                timer_0 = null;
                if (base.IsHandleCreated && !base.IsDisposed && !base.AutoScrollMinSize.Equals(size))
                {
                    bool_4 = true;
                    try
                    {
                        base.AutoScrollMinSize = size;
                    }
                    finally
                    {
                        bool_4 = false;
                    }
                }
            }
        }

        public void method_7(Size size_1)
        {
            if (base.IsDisposed)
            {
                return;
            }
            if (DelaySetAutoScrollMinSize && base.IsHandleCreated)
            {
                method_6(size_1);
                return;
            }
            if (timer_0 != null)
            {
                timer_0.Stop();
                timer_0.Dispose();
                timer_0 = null;
            }
            if (!base.AutoScrollMinSize.Equals(size_1))
            {
                base.AutoScrollMinSize = size_1;
            }
        }

        public virtual MouseEventArgs vmethod_7()
        {
            Point viewMousePosition = ViewMousePosition;
            return new MouseEventArgs(Control.MouseButtons, 0, viewMousePosition.X, viewMousePosition.Y, 0);
        }

        protected override void OnXScroll()
        {
            base.OnXScroll();
            RefreshScaleTransform();
        }

        /// <summary>
        ///       已重载：鼠标按键按下事件处理
        ///       </summary>
        /// <param name="e">事件参数</param>
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (bool_6)
            {
                point_0 = new Point(mevent.X, mevent.Y);
            }
            if (myTransform.ContainsSourcePoint(mevent.X, mevent.Y))
            {
                Point point = ClientPointToView(mevent.X, mevent.Y);
                OnViewMouseDown(new MouseEventArgs(mevent.Button, mevent.Clicks, point.X, point.Y, mevent.Delta));
            }
            if (MouseDragScroll && bool_3)
            {
                Cursor = GClass291.smethod_5();
            }
        }

        protected void method_8(MouseEventArgs mouseEventArgs_0)
        {
            base.OnMouseDown(mouseEventArgs_0);
        }

        protected virtual void OnViewMouseDown(MouseEventArgs mouseEventArgs_0)
        {
            if (mouseEventHandler_0 != null)
            {
                mouseEventHandler_0(this, mouseEventArgs_0);
            }
        }

        /// <summary>
        ///       已重载:鼠标移动事件处理
        ///       </summary>
        /// <param name="e">事件参数</param>
        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            bool_7 = false;
            base.OnMouseMove(mevent);
            if (bool_12)
            {
                Console.WriteLine(bool_12);
                return;
            }
            if (MouseDragScroll)
            {
                if (Control.MouseButtons == MouseButtons.Left)
                {
                    if (bool_3)
                    {
                        Cursor = GClass291.smethod_5();
                    }
                    if (!point_0.IsEmpty)
                    {
                        int num = mevent.X - point_0.X;
                        int num2 = mevent.Y - point_0.Y;
                        point_0 = new Point(mevent.X, mevent.Y);
                        SetAutoScrollPosition(new Point(-num - base.AutoScrollPosition.X, -num2 - base.AutoScrollPosition.Y));
                        OnXScroll();
                        return;
                    }
                }
                else
                {
                    if (bool_3)
                    {
                        Cursor = GClass291.smethod_4();
                    }
                    point_0 = Point.Empty;
                }
            }
            if (myTransform.ContainsSourcePoint(mevent.X, mevent.Y))
            {
                Point point = ClientPointToView(mevent.X, mevent.Y);
                bool_7 = true;
                OnViewMouseMove(new MouseEventArgs(mevent.Button, mevent.Clicks, point.X, point.Y, mevent.Delta));
            }
            else
            {
                Cursor = XDefaultCursor;
            }
        }

        protected virtual void OnViewMouseMove(MouseEventArgs mouseEventArgs_0)
        {
            if (mouseEventHandler_1 != null)
            {
                mouseEventHandler_1(this, mouseEventArgs_0);
            }
        }

        /// <summary>
        ///       已重载:鼠标按键松开事件处理
        ///       </summary>
        /// <param name="e">事件参数</param>
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            point_0 = Point.Empty;
            if (myTransform.ContainsSourcePoint(mevent.X, mevent.Y))
            {
                Point point = ClientPointToView(mevent.X, mevent.Y);
                OnViewMouseUp(new MouseEventArgs(mevent.Button, mevent.Clicks, point.X, point.Y, mevent.Delta));
            }
        }

        protected virtual void OnViewMouseUp(MouseEventArgs mouseEventArgs_0)
        {
            if (mouseEventHandler_2 != null)
            {
                mouseEventHandler_2(this, mouseEventArgs_0);
            }
        }

        /// <summary>
        ///       已重载:处理鼠标单击事件
        ///       </summary>
        /// <param name="e">
        /// </param>
        protected override void OnClick(EventArgs eventArgs_0)
        {
            base.OnClick(eventArgs_0);
            Point viewMousePosition = ViewMousePosition;
            OnViewClick(new MouseEventArgs(Control.MouseButtons, 1, viewMousePosition.X, viewMousePosition.Y, 0));
        }

        protected virtual void OnViewClick(MouseEventArgs mouseEventArgs_0)
        {
            if (mouseEventHandler_3 != null)
            {
                mouseEventHandler_3(this, mouseEventArgs_0);
            }
        }

        /// <summary>
        ///       已重载:处理鼠标双击事件
        ///       </summary>
        /// <param name="e">事件参数</param>
        protected override void OnMouseDoubleClick(MouseEventArgs mouseEventArgs_0)
        {
            base.OnMouseDoubleClick(mouseEventArgs_0);
            Point point = ClientPointToView(mouseEventArgs_0.X, mouseEventArgs_0.Y);
            vmethod_12(new MouseEventArgs(mouseEventArgs_0.Button, mouseEventArgs_0.Clicks, point.X, point.Y, mouseEventArgs_0.Delta));
        }

        protected virtual void vmethod_12(MouseEventArgs mouseEventArgs_0)
        {
            if (mouseEventHandler_4 != null)
            {
                mouseEventHandler_4(this, mouseEventArgs_0);
            }
        }

        /// <summary>
        ///       已重载:重新绘制视图的事件处理
        ///       </summary>
        /// <param name="e">事件参数</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (!base.DesignMode)
            {
                CheckZoomRate();
                RefreshScaleTransform();
                PaintEventArgs paintEventArgs = TransformPaint(pevent, Transform as SimpleRectangleTransform, bool_13: true);
                if (paintEventArgs != null)
                {
                    OnViewPaint(paintEventArgs, Transform as SimpleRectangleTransform);
                }
            }
        }

        protected virtual PaintEventArgs TransformPaint(PaintEventArgs paintEventArgs_0, SimpleRectangleTransform gclass435_0, bool bool_13)
        {
            if (gclass435_0 == null)
            {
                return null;
            }
            Rectangle rectangle = paintEventArgs_0.ClipRectangle;
            rectangle.Offset(-1, -1);
            rectangle.Width += 2;
            rectangle.Height += 2;
            if (bool_13)
            {
                rectangle = Rectangle.Intersect(gclass435_0.method_21(), rectangle);
            }
            RectangleF rectangleF = gclass435_0.vmethod_12(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);


            rectangle.X = (int)Math.Floor(rectangleF.Left);
            rectangle.Y = (int)Math.Floor(rectangleF.Top);
            rectangle.Width = (int)Math.Ceiling(rectangleF.Right) - rectangle.Left;
            rectangle.Height = (int)Math.Ceiling(rectangleF.Bottom) - rectangle.Top;


            paintEventArgs_0.Graphics.PageUnit = GraphicsUnit;
            paintEventArgs_0.Graphics.ResetTransform();
            paintEventArgs_0.Graphics.ScaleTransform(XZoomRate, YZoomRate);
            double clientToViewXRate = ClientToViewXRate;
            paintEventArgs_0.Graphics.TranslateTransform(
                (float)((double)gclass435_0.getSourceRectF().Left * clientToViewXRate - (double)gclass435_0.method_25().X),
                (float)((double)gclass435_0.getSourceRectF().Top * clientToViewXRate - (double)gclass435_0.method_25().Y)
            );
            if (gclass435_0.method_31() < 1f)
            {
                rectangle.Width += (int)Math.Ceiling(1f / gclass435_0.method_31());
            }
            if (gclass435_0.method_32() < 1f)
            {
                rectangle.Height += (int)Math.Ceiling(1f / gclass435_0.method_32());
            }
            rectangle.Height += 6;
            PaintEventArgs paintEventArgs = new PaintEventArgs(paintEventArgs_0.Graphics, rectangle);
            paintEventArgs.Graphics.ResetClip();
            int num = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, paintEventArgs.Graphics.PageUnit);
            paintEventArgs.Graphics.SetClip(new Rectangle(rectangle.Left - num, rectangle.Top - num, rectangle.Width + num * 2, rectangle.Height + num));
            return paintEventArgs;
        }

        protected virtual void OnViewPaint(PaintEventArgs paintEventArgs_0, SimpleRectangleTransform gclass435_0)
        {
            if (paintEventHandler_0 != null)
            {
                paintEventHandler_0(this, paintEventArgs_0);
            }
        }

        public Bitmap method_9()
        {
            Bitmap bitmap = new Bitmap(base.ClientSize.Width, base.ClientSize.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(BackColor);
                graphics.PageUnit = GraphicsUnit;
                OnPaint(new PaintEventArgs(graphics, base.ClientRectangle));
            }
            return bitmap;
        }

        public virtual Graphics vmethod_15()
        {
            Graphics graphics = CreateGraphics();
            graphics.PageUnit = GraphicsUnit;
            return graphics;
        }

        protected Bitmap method_10(float float_2, Color color_0)
        {
            SimpleRectangleTransform gClass = myTransform as SimpleRectangleTransform;
            if (gClass == null)
            {
                return null;
            }
            Size autoScrollMinSize = base.AutoScrollMinSize;
            autoScrollMinSize.Width = (int)((float)autoScrollMinSize.Width * float_2);
            autoScrollMinSize.Height = (int)((float)autoScrollMinSize.Height * float_2);
            if (autoScrollMinSize.Width <= 0 || autoScrollMinSize.Height <= 0)
            {
                return null;
            }
            Bitmap bitmap = new Bitmap(autoScrollMinSize.Width, autoScrollMinSize.Height);
            float num = _XZoomRate;
            try
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(color_0);
                    graphics.PageUnit = GraphicsUnit;
                    graphics.ScaleTransform(float_2, float_2);
                    graphics.TranslateTransform(0f - gClass.method_25().X, 0f - gClass.method_25().Y);
                    PaintEventArgs paintEventArgs_ = new PaintEventArgs(graphics, gClass.method_27());
                    _XZoomRate = float_2;
                    OnViewPaint(paintEventArgs_, gClass);
                    _XZoomRate = num;
                }
                return bitmap;
            }
            catch (Exception ex)
            {
                _XZoomRate = num;
                throw ex;
            }
        }

        public virtual void BeginUpdate()
        {
            updateLock.BeginUpdate();
        }

        public virtual void EndUpdate()
        {
            updateLock.EndUpdate();
        }

        protected void method_11()
        {
            updateLock.method_6();
        }

        protected virtual Rectangle vmethod_18(Rectangle rectangle_2)
        {
            if (rectangle_1.IsEmpty)
            {
                rectangle_1 = rectangle_2;
            }
            else if (!rectangle_2.IsEmpty)
            {
                rectangle_1 = Rectangle.Union(rectangle_1, rectangle_2);
            }
            if (IsUpdating)
            {
                return Rectangle.Empty;
            }
            Rectangle result = rectangle_1;
            rectangle_1 = Rectangle.Empty;
            return result;
        }

        public virtual void vmethod_19(Rectangle rectangle_2)
        {
            if (!IsUpdating)
            {
                rectangle_2 = vmethod_18(rectangle_2);
                if (!rectangle_2.IsEmpty)
                {
                    RefreshScaleTransform();
                    Rectangle rc = myTransform.vmethod_21(rectangle_2);
                    Invalidate(rc);
                }
            }
        }

        public virtual Point[] vmethod_20(GDelegate13 gdelegate13_0, Rectangle rectangle_2, object object_0)
        {
            if (bool_6)
            {
                return null;
            }
            RefreshScaleTransform();
            MyCapturer myCapturer = new MyCapturer();
            myCapturer.Tag = object_0;
            myCapturer.BindControl = this;
            if (!rectangle_2.IsEmpty)
            {
                rectangle_2 = myTransform.vmethod_21(rectangle_2);
                myCapturer.ClipRectangle = rectangle_2;
            }
            myCapturer.ReversibleShape = GEnum68.const_4;
            if (gdelegate13_0 != null)
            {
                myCapturer.Draw += gdelegate13_0;
            }
            if (myCapturer.method_1())
            {
                Point startPosition = myCapturer.StartPosition;
                startPosition = MouseCaptureTransform.TransformPoint(startPosition);
                Point endPosition = myCapturer.EndPosition;
                endPosition = MouseCaptureTransform.TransformPoint(endPosition);
                return new Point[2]
                {
                    startPosition,
                    endPosition
                };
            }
            return null;
        }

        public Point[] method_12(Rectangle rectangle_2)
        {
            return vmethod_20(method_15, rectangle_2, null);
        }

        public Point[] method_13(Rectangle rectangle_2)
        {
            return vmethod_20(mcp_Draw, rectangle_2, null);
        }

        public Point[] method_14(Rectangle rectangle_2)
        {
            return vmethod_20(method_17, rectangle_2, null);
        }

        private void method_15(object sender, CaptureMouseMoveEventArgs e)
        {
            Rectangle rectangle = RectangleCommon.GetRectangle(e.method_3(), e.method_5());
            if (!rectangle.IsEmpty)
            {
                method_26(rectangle, e.method_9());
            }
        }

        private void mcp_Draw(object sender, CaptureMouseMoveEventArgs e)
        {
            Rectangle rectangle = RectangleCommon.GetRectangle(e.method_3(), e.method_5());
            if (!rectangle.IsEmpty)
            {
                ReversibleViewDrawRect(rectangle, e.method_9());
            }
        }

        private void method_17(object sender, CaptureMouseMoveEventArgs e)
        {
            vmethod_21(e.method_3(), e.method_5());
        }

        public void method_18(Point[] point_1, Graphics graphics_0)
        {
            if (point_1 != null && point_1.Length > 1)
            {
                GClass249 gClass = null;
                gClass = ((graphics_0 != null) ? new GClass249(graphics_0) : GClass249.smethod_0(base.Handle));
                gClass.method_21(genum64_0);
                gClass.method_23(Color.Red);
                RefreshScaleTransform();
                Point[] array = new Point[point_1.Length];
                for (int i = 0; i < point_1.Length; i++)
                {
                    array[i] = MouseCaptureTransform.UnTransformPoint(point_1[i]);
                }
                gClass.method_12(array);
                gClass.Dispose();
            }
        }

        public void method_19(Point[] point_1)
        {
            if (point_1 != null && point_1.Length > 1)
            {
                using (GClass249 gClass = GClass249.smethod_0(base.Handle))
                {
                    gClass.method_21(genum64_0);
                    gClass.method_23(Color.Red);
                    RefreshScaleTransform();
                    Point[] array = new Point[point_1.Length];
                    for (int i = 0; i < point_1.Length; i++)
                    {
                        array[i] = MouseCaptureTransform.UnTransformPoint(point_1[i]);
                    }
                    gClass.method_12(array);
                }
            }
        }

        public void method_20(int int_2, int int_3, int int_4, int int_5)
        {
            using (GClass249 gClass = GClass249.smethod_0(base.Handle))
            {
                gClass.method_21(genum64_0);
                gClass.method_23(Color.Red);
                RefreshScaleTransform();
                Point point = MouseCaptureTransform.UnTransformPoint(int_2, int_3);
                Point point_ = MouseCaptureTransform.UnTransformPoint(int_4, int_5);
                gClass.method_13(point, point_);
            }
        }

        public virtual void vmethod_21(Point point_1, Point point_2)
        {
            method_20(point_1.X, point_1.Y, point_2.X, point_2.Y);
        }

        public void ReversibleViewDrawRect(Rectangle rectangle_2, bool bool_13)
        {
            ReversibleViewDrawRect(rectangle_2.Left, rectangle_2.Top, rectangle_2.Width, rectangle_2.Height, bool_13);
        }

        public virtual void ReversibleViewDrawRect(int int_2, int int_3, int int_4, int int_5, bool bool_13)
        {
            RefreshScaleTransform();
            Rectangle rectangle = MouseCaptureTransform.vmethod_22(int_2, int_3, int_4, int_5);
            using (GClass249 gClass = GClass249.smethod_0(base.Handle))
            {
                gClass.method_21(genum64_0);
                gClass.method_23(Color.White);
                gClass.method_8(1);
                gClass.DrawRectangle(rectangle);
            }
        }

        public void method_22(Rectangle rectangle_2)
        {
            method_23(rectangle_2.Left, rectangle_2.Top, rectangle_2.Width, rectangle_2.Height);
        }

        public void method_23(int int_2, int int_3, int int_4, int int_5)
        {
            using (GClass249 gClass = GClass249.smethod_0(base.Handle))
            {
                RefreshScaleTransform();
                RectangleF value = MouseCaptureTransform.vmethod_24(int_2, int_3, int_4, int_5);
                gClass.method_19(Rectangle.Ceiling(value));
            }
        }

        public void method_24(Rectangle rectangle_2, Graphics graphics_0)
        {
            method_25(rectangle_2.Left, rectangle_2.Top, rectangle_2.Width, rectangle_2.Height, graphics_0);
        }

        public void method_25(int int_2, int int_3, int int_4, int int_5, Graphics graphics_0)
        {
            IntPtr hdc = graphics_0.GetHdc();
            using (GClass249 gClass = GClass249.smethod_1(hdc))
            {
                RefreshScaleTransform();
                Rectangle rectangle = MouseCaptureTransform.vmethod_22(int_2, int_3, int_4, int_5);
                rectangle.Location = ViewPointToClient(int_2, int_3);
                gClass.method_19(rectangle);
            }
            graphics_0.ReleaseHdc(hdc);
        }

        public void method_26(Rectangle rectangle_2, bool bool_13)
        {
            vmethod_23(rectangle_2.Left, rectangle_2.Top, rectangle_2.Width, rectangle_2.Height, bool_13);
        }

        public virtual void vmethod_23(int int_2, int int_3, int int_4, int int_5, bool bool_13)
        {
            using (GClass249 gClass = GClass249.smethod_0(base.Handle))
            {
                gClass.method_21(genum64_0);
                gClass.method_23(Color.White);
                gClass.method_8(1);
                RefreshScaleTransform();
                Rectangle rectangle = MouseCaptureTransform.vmethod_22(int_2, int_3, int_4, int_5);
                gClass.method_16(rectangle);
            }
        }

        public void method_27(Point point_1)
        {
            vmethod_24(point_1.X, point_1.Y);
        }

        public virtual void vmethod_24(int int_2, int int_3)
        {
            if (int_2 != 0 || int_3 != 0)
            {
                Point autoScrollPosition = base.AutoScrollPosition;
                SetAutoScrollPosition(new Point(int_2 - autoScrollPosition.X, int_3 - autoScrollPosition.Y));
            }
        }

        public virtual bool vmethod_25(Rectangle rectangle_2)
        {
            return method_31(rectangle_2.Left, rectangle_2.Top, rectangle_2.Width, rectangle_2.Height, ScrollToViewStyle.Normal);
        }

        public bool method_28(int int_2, int int_3, int int_4, int int_5)
        {
            return method_31(int_2, int_3, int_4, int_5, ScrollToViewStyle.Normal);
        }

        public bool method_29(Rectangle rectangle_2, ScrollToViewStyle scrollToViewStyle_0)
        {
            return method_31(rectangle_2.Left, rectangle_2.Top, rectangle_2.Width, rectangle_2.Height, scrollToViewStyle_0);
        }

        public void method_30()
        {
            bool_8 = true;
        }

        public bool method_31(int int_2, int int_3, int int_4, int int_5, ScrollToViewStyle scrollToViewStyle_0)
        {
            if (bool_8)
            {
                bool_8 = false;
                return false;
            }
            switch (scrollToViewStyle_0)
            {
                case ScrollToViewStyle.Normal:
                    {
                        Rectangle rectangle = Transform.vmethod_22(int_2, int_3, int_4, int_5);
                        rectangle.Location = ViewPointToClient(int_2, int_3);
                        if (!rectangle.IsEmpty)
                        {
                            return InnerScrollToView(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
                        }
                        return false;
                    }
                case ScrollToViewStyle.Top:
                    {
                        Point point_ = ViewPointToClient(int_2, int_3);
                        if (!point_.IsEmpty)
                        {
                            point_ = new Point(point_.X - base.ClientSize.Width / 2 - base.AutoScrollPosition.X, point_.Y - base.AutoScrollPosition.Y);
                            SetAutoScrollPosition(point_);
                            return true;
                        }
                        return false;
                    }
                case ScrollToViewStyle.Middle:
                    {
                        int int_6 = int_2 + int_4 / 2;
                        int int_7 = int_3 + int_5 / 2;
                        Point point_ = ViewPointToClient(int_6, int_7);
                        if (!point_.IsEmpty)
                        {
                            point_ = new Point(point_.X - base.ClientSize.Width / 2 - base.AutoScrollPosition.X, point_.Y - base.ClientSize.Height / 2 - base.AutoScrollPosition.Y);
                            SetAutoScrollPosition(point_);
                            return true;
                        }
                        return false;
                    }
                case ScrollToViewStyle.Bottom:
                    {
                        Point point_ = ViewPointToClient(int_2, int_3 + int_5);
                        if (!point_.IsEmpty)
                        {
                            point_ = new Point(point_.X - base.ClientSize.Width / 2 - base.AutoScrollPosition.X, point_.Y - base.ClientSize.Height - base.AutoScrollPosition.Y);
                            SetAutoScrollPosition(point_);
                            return true;
                        }
                        return false;
                    }
                default:
                    return false;
            }
        }

        public bool method_32(int int_2, int int_3, int int_4, int int_5, ScrollToViewStyle scrollToViewStyle_0)
        {
            Point point_;
            switch (scrollToViewStyle_0)
            {
                case ScrollToViewStyle.Normal:
                    return InnerScrollToView(int_2, int_3, int_4, int_5);
                case ScrollToViewStyle.Top:
                    {
                        int x = int_2;
                        int y = int_3;
                        point_ = new Point(x, y);
                        point_ = new Point(point_.X - base.AutoScrollPosition.X, point_.Y - base.AutoScrollPosition.Y);
                        SetAutoScrollPosition(point_);
                        return true;
                    }
                case ScrollToViewStyle.Middle:
                    {
                        int x = int_2 + int_4 / 2;
                        int y = int_3 + int_5 / 2;
                        point_ = new Point(x, y);
                        point_ = new Point(point_.X - base.ClientSize.Width / 2 - base.AutoScrollPosition.X, point_.Y - base.ClientSize.Height / 2 - base.AutoScrollPosition.Y);
                        SetAutoScrollPosition(point_);
                        return true;
                    }
                case ScrollToViewStyle.Bottom:
                    point_ = new Point(int_2, int_3 + int_5);
                    point_ = new Point(point_.X - base.AutoScrollPosition.X, point_.Y - base.ClientSize.Height - base.AutoScrollPosition.Y);
                    SetAutoScrollPosition(point_);
                    return true;
                default:
                    return false;
            }
        }

        protected bool InnerScrollToView(int x, int y, int w, int h)
        {
            if (!base.IsHandleCreated)
            {
                return false;
            }
            bool result = false;
            if (w < 0 || h < 0)
                return false;

            int dx = 0;
            int dy = 0;
            Point point = new Point(x, y);
            Rectangle clientRectangle = base.ClientRectangle;
            if (clientRectangle.Width <= 0 || clientRectangle.Height <= 0)
            {
                return false;
            }
            clientRectangle.Location = PointToScreen(clientRectangle.Location);
            clientRectangle = Rectangle.Intersect(clientRectangle, Screen.GetWorkingArea(this));
            if (!clientRectangle.IsEmpty)
            {
                clientRectangle.Location = PointToClient(clientRectangle.Location);
            }
            _ = base.AutoScrollPosition;
            if (point.X > clientRectangle.Right - w + 3 && clientRectangle.Right - w + 3 > 0)
            {
                dx = point.X - clientRectangle.Right + w + 3;
            }
            if (w > clientRectangle.Width)
            {
                if (point.X > 3)
                {
                    dx = point.X - 3;
                }
                if (point.X + w < clientRectangle.Width)
                {
                    dx = point.X - clientRectangle.Width + w + 3;
                }
            }
            else if (point.X < clientRectangle.Left)
            {
                dx = point.X - 3 - clientRectangle.Left;
            }
            if (point.Y > clientRectangle.Bottom - h + 3)
            {
                if (clientRectangle.Bottom - h + 3 > 0)
                {
                    dy = point.Y - clientRectangle.Bottom + h + 3;
                }
                else if (point.Y + h < clientRectangle.Top)
                {
                    dy = point.Y - clientRectangle.Bottom + h + 3;
                }
                else if (point.Y > clientRectangle.Bottom)
                {
                    dy = point.Y - 3;
                }
            }
            if (h > clientRectangle.Bottom)
            {
                if (point.Y > 3)
                {
                    dy = point.Y - 3;
                }
                if (point.Y + h < clientRectangle.Bottom)
                {
                    dy = point.Y - clientRectangle.Bottom + h + 3;
                }
            }
            else if (point.Y < clientRectangle.Top)
            {
                dy = point.Y - 3 - clientRectangle.Top;
            }
            if (dx != 0 || dy != 0)
            {
                bool_9 = true;
                Point point_ = new Point(dx - base.AutoScrollPosition.X, dy - base.AutoScrollPosition.Y);
                SetAutoScrollPosition(point_);
                result = true;
            }

            return result;
        }

        public void SetAutoScrollPosition(Point point_1)
        {
            if (IsUpdating)
            {
                return;
            }
            if (LockScrollPositionOnce)
            {
                LockScrollPositionOnce = false;
            }
            else
            {
                if (LockScrollPosition)
                {
                    return;
                }
                Point point = new Point(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y);
                if (point.Equals(point_1) || GClass354.smethod_3())
                {
                    return;
                }
                bool_12 = true;
                if (FixedBackground)
                {
                    LockWindowUpdate(base.Handle);
                    if (SmoothScrollView)
                    {
                        method_35(point_1);
                    }
                    else
                    {
                        base.AutoScrollPosition = point_1;
                    }
                    LockWindowUpdate(IntPtr.Zero);
                }
                else if (SmoothScrollView)
                {
                    if (base.AutoScrollPosition.Y != -point_1.Y)
                    {
                        method_35(point_1);
                    }
                    else
                    {
                        base.AutoScrollPosition = point_1;
                        base.OnScroll(null);
                    }
                }
                else
                {
                    base.AutoScrollPosition = point_1;
                    base.OnScroll(null);
                }
                bool_12 = false;
                OnXScroll();
            }
        }

        private void method_35(Point point_1)
        {
            int num = 0;
            int tickCount = Environment.TickCount;
            while (num++ <= 20 && Environment.TickCount - tickCount <= 200)
            {
                Point autoScrollPosition = base.AutoScrollPosition;
                autoScrollPosition.X = -autoScrollPosition.X;
                autoScrollPosition.Y = -autoScrollPosition.Y;
                if (!(autoScrollPosition == point_1))
                {
                    float num2 = (float)Math.Floor((float)(point_1.X - autoScrollPosition.X) / 3f);
                    if (Math.Abs(point_1.X - autoScrollPosition.X) < 30)
                    {
                        num2 = point_1.X - autoScrollPosition.X;
                    }
                    float num3 = (float)Math.Floor((float)(point_1.Y - autoScrollPosition.Y) / 3f);
                    if (Math.Abs(point_1.Y - autoScrollPosition.Y) < 30)
                    {
                        num3 = point_1.Y - autoScrollPosition.Y;
                    }
                    Point point2 = base.AutoScrollPosition = new Point((int)((float)autoScrollPosition.X + num2), (int)((float)autoScrollPosition.Y + num3));
                    base.OnScroll(null);
                    Update();
                    continue;
                }
                return;
            }
            Point autoScrollPosition2 = base.AutoScrollPosition;
            autoScrollPosition2.X = -autoScrollPosition2.X;
            autoScrollPosition2.Y = -autoScrollPosition2.Y;
            if (autoScrollPosition2 != point_1)
            {
                base.AutoScrollPosition = point_1;
                base.OnScroll(null);
            }
        }
    }
}
