using Gocent.Library.Editor.Common;
using Gocent.Library.Editor.Designer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace Gocent.Library.Editor.Controls
{

    [ToolboxItem(true)]
    [Designer(typeof(GocentControlInfoDesigner))]
    [Description("国讯电子病历编辑器组件")]
    public class DocumentViewControl : ScrollableControl
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text { get => base.Text; set => base.Text = value; }



        /// <summary>
        /// 启动双缓冲样式
        /// </summary>
        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("启动双缓冲样式")]
        public bool DoubleBuffering
        {
            get
            {
                return GetStyle(ControlStyles.DoubleBuffer);
            }
            set
            {
                if (GetStyle(ControlStyles.DoubleBuffer) == value)
                    return;

                if (value)
                {
                    SetStyle(ControlStyles.UserPaint, value: true);
                    SetStyle(ControlStyles.DoubleBuffer, value: true);
                    SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
                }
                else
                {
                    SetStyle(ControlStyles.DoubleBuffer, value: false);
                }
                UpdateStyles();
                Invalidate();

            }
        }


        #region 功能：设置边框样式

        private BorderStyle _BorderStyle = BorderStyle.None;

        /// <summary>
        /// 边框样式
        /// </summary>
        [DefaultValue(BorderStyle.None)]
        [Category("Appearance")]
        [Description("获取或设置控件的边框样式。")]
        public BorderStyle BorderStyle
        {
            get { return _BorderStyle; }
            set
            {
                _BorderStyle = value;

                UpdateStyles();
            }
        }



        /// <summary>
        /// 初始化创建控件的参数对象
        /// </summary>
        protected override CreateParams CreateParams
        {
            /*
             * 不在使用
             * Fixed3D WS_EX_CLIENTEDGE  0x00000200
             * FixedSingle WS_EX_STATICEDGE  0x00020000
             * 
             * 采用UserControl、Panel实现方法
             */
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 65536;//WS_EX_CONTROLPARENT  0x00010000L  窗口本身包含应参与对话框导航的子窗口。如果指定了此样式，则在执行导航操作（例如处理TAB键，箭头键或键盘助记符）时，对话框管理器将循环到此窗口的子级中。
                //通过位运算移除两种边框样式在进行添加
                createParams.ExStyle &= -513;
                createParams.Style &= -8388609;
                switch (_BorderStyle)
                {
                    case BorderStyle.Fixed3D:
                        createParams.ExStyle |= 512;//WS_EX_CLIENTEDGE  0x00000200L
                        break;
                    case BorderStyle.FixedSingle:
                        createParams.Style |= 8388608;//WS_BORDER  0x00800000L
                        break;
                }
                return createParams;
            }
        }

        #endregion 功能：设置边框样式

        #region 功能：缩放

        /// <summary>
        /// 缩放
        /// </summary>
        /// <param name="rate">缩放倍数</param>
        public void Zoom(float rate)
        {
            if (rate <= 0)
                throw new ArgumentException("缩放倍数必须大于0。", nameof(rate));
            //倍率应该是直接赋值，而不是用倍率乘倍率
            //_XZoomRate *= rate;
            //_YZoomRate *= rate;
            //if (_XZoomRate <= 0)
            //    _XZoomRate = 1f;
            //if (_YZoomRate <= 0)
            //    _YZoomRate = 1f;
            _XZoomRate = rate;
            _YZoomRate = rate;

            this.UpdateViewBounds();
            this.Invalidate();
        }

        private float _XZoomRate = 1.0f;
        /// <summary>
        /// X方向缩放率
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float XZoomRate
        {
            get { return _XZoomRate; }
            set
            {
                if (_XZoomRate == value) return;

                _XZoomRate = value;
                this.UpdateViewBounds();
                this.Invalidate();
            }
        }

        private float _YZoomRate = 1.0f;
        /// <summary>
        /// Y方向缩放率
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float YZoomRate
        {
            get { return _YZoomRate; }
            set
            {
                if (_YZoomRate == value) return;

                _YZoomRate = value;
                this.UpdateViewBounds();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 检查缩放倍率
        /// </summary>
        protected void CheckZoomRate()
        {
            if (this._XZoomRate <= 0 || this._YZoomRate <= 0)
                throw new InvalidOperationException("Bad zoom rate value");
        }

        #endregion



        private GraphicsUnit _GraphicsUnit = GraphicsUnit.Pixel;

        /// <summary>
        /// 绘图单位
        /// </summary>
        [DefaultValue(GraphicsUnit.Pixel)]
        [Category("Appearance")]
        [Description("获取或设置控件的绘图单位。")]
        public GraphicsUnit GraphicsUnit
        {
            get { return _GraphicsUnit; }
            set
            {
                if (_GraphicsUnit == value)
                    return;
                _GraphicsUnit = value;
                this.UpdateViewBounds();
                this.Invalidate();

            }
        }



        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Size ViewAutoScrollMinSize
        {
            get
            {
                Size size = this.AutoScrollMinSize.Convert(GraphicsUnit.Pixel, GraphicsUnit);
                size.Width = (int)(size.Width * this._XZoomRate);
                size.Height = (int)(size.Height * this._YZoomRate);
                return size;
            }
            set
            {
                Size size = value.Convert(this.GraphicsUnit, GraphicsUnit.Pixel);
                size.Width = (int)(size.Width / this._XZoomRate);
                size.Height = (int)(size.Height / this._YZoomRate);
                this.AutoScrollMinSize = size;
            }
        }


        [Browsable(false)]
        public double ClientToViewXRate
        {
            get => this.GraphicsUnit.GetRate(GraphicsUnit.Pixel) / _XZoomRate;

        }
        [Browsable(false)]
        public double ClientToViewYRate
        {
            get => this.GraphicsUnit.GetRate(GraphicsUnit.Pixel) / _YZoomRate;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Point ViewAutoScrollPosition
        {
            get
            {
                Point p = this.AutoScrollPosition.Convert(GraphicsUnit.Pixel, this.GraphicsUnit);
                p.X = (int)(p.X * this._XZoomRate);
                p.Y = (int)(p.Y * this._YZoomRate);
                return p;
            }
            set
            {
                Point p = value.Convert(this.GraphicsUnit, GraphicsUnit.Pixel);
                p.X = (int)(p.X / this._XZoomRate);
                p.Y = (int)(p.Y / this._YZoomRate);
                this.SetAutoScrollPosition(p);
            }
        }

        [Browsable(false)]
        public virtual Size ViewClientSize
        {
            get
            {
                Size size = this.ClientSize.Convert(GraphicsUnit.Pixel, this.GraphicsUnit);
                size.Width = (int)(size.Width * this._XZoomRate);
                size.Height = (int)(size.Height * this._YZoomRate);
                return size;
            }
        }
        [Browsable(false)]
        public virtual Rectangle ViewClientRectangle
        {
            get
            {
                Rectangle rect = this.ClientRectangle.Convert(GraphicsUnit.Pixel, this.GraphicsUnit);
                rect.X = (int)(rect.X * this._XZoomRate);
                rect.Y = (int)(rect.Y * this._YZoomRate);
                rect.Width = (int)(rect.Width * this._XZoomRate);
                rect.Height = (int)(rect.Height * this._YZoomRate);
                return rect;
            }
        }



        /// <summary>
        /// 视图正在滚动中
        /// </summary>
        protected bool bolScrolling = false;

        /// <summary>
        /// P 是客户端坐标
        /// </summary>
        /// <param name="p"></param>
        public void SetAutoScrollPosition(Point p)
        {
            if (StackTraceHelper.CheckRecursion())
                return;

            bolScrolling = true;
            this.AutoScrollPosition = p;
            bolScrolling = false;

            this.OnScroll(null);
            Debug.WriteLine("End Scroll");
        }





        /// <summary>
        /// 将客户区坐标转换为视图区坐标
        /// </summary>
        /// <param name="p">客户区点坐标</param>
        /// <returns>视图区点坐标</returns>
        public Point ClientPointToView(Point p) => ClientPointToView(p.X, p.Y);

        /// <summary>
        /// 将客户区坐标转换为视图区坐标
        /// </summary>
        /// <param name="x">客户区点X坐标</param>
        /// <param name="y">客户区点Y坐标</param>
        /// <returns>转换后的视图点坐标</returns>
        public virtual Point ClientPointToView(int x, int y) => this.TransformPoint(x, y);






        /// <summary>
        /// 鼠标在控件上的位置
        /// </summary>
        [Browsable(false)]
        public virtual Point ClientMousePosition
        {
            get
            {
                Point p = this.PointToClient(MousePosition);
                return this.ClientRectangle.Contains(p) ? p : Point.Empty;
            }
        }

        /// <summary>
        /// 鼠标在视图区中的坐标
        /// </summary>
        [Browsable(false)]
        public virtual Point ViewMousePosition
            => this.ClientMousePosition.IsEmpty ? Point.Empty : ClientPointToView(this.ClientMousePosition);

        protected Rectangle myViewBounds = Rectangle.Empty;

        /// <summary>
        /// 整个视图区域的矩形区域
        /// </summary>
        [Browsable(false)]
        public Rectangle ViewBounds
        {
            get { return myViewBounds; }
            set
            {
                if (myViewBounds.Equals(value))
                    return;

                myViewBounds = value;
                this.UpdateViewBounds();
            }
        }

        public virtual void UpdateViewBounds()
        {
            Size size = new Size(myViewBounds.Right, myViewBounds.Bottom);

            size = this.UnTransformSize(size.Width, size.Height);
            this.AutoScrollMinSize = size;
        }


        protected bool bolMouseDragScroll = false;
        /// <summary>
        /// 使用鼠标拖拽滚动模式标记
        /// </summary>
        public bool MouseDragScroll
        {
            get { return this.bolMouseDragScroll; }
            set { this.bolMouseDragScroll = value; }
        }



        public event MouseEventHandler ViewMouseDown;
        public event MouseEventHandler ViewMouseMove;
        public event MouseEventHandler ViewMouseUp;
        public event MouseEventHandler ViewClick;
        public event MouseEventHandler ViewDoubleClick;
        public event PaintEventHandler ViewPaint;

        protected virtual void OnViewMouseDown(MouseEventArgs e) => ViewMouseDown?.Invoke(this, e);
        protected virtual void OnViewMouseMove(MouseEventArgs e) => ViewMouseMove?.Invoke(this, e);
        protected virtual void OnViewMouseUp(MouseEventArgs e) => ViewMouseUp?.Invoke(this, e);
        protected virtual void OnViewClick(MouseEventArgs e) => ViewClick?.Invoke(this, e);
        protected virtual void OnViewDoubleClick(MouseEventArgs e) => ViewDoubleClick?.Invoke(this, e);
        protected virtual void OnViewPaint(PaintEventArgs e) => ViewPaint?.Invoke(this, e);


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (base.DesignMode) return;

            this.CheckZoomRate();
            TransformPaint(e);
        }



        protected virtual void TransformPaint(PaintEventArgs e)
        {


            Rectangle rect = e.ClipRectangle;
            rect.Offset(-1, -1);
            rect.Width += 2;
            rect.Height += 2;
            rect = Rectangle.Intersect(ClientRectangle, rect);
            if (rect.IsEmpty)
                return;

            RectangleF rectf = this.TransformRectangleF(
                rect.Left,
                rect.Top,
                rect.Width,
                rect.Height);// this.ClipRectangleToView( e.ClipRectangle );
            rect.X = (int)Math.Floor(rectf.Left);
            rect.Y = (int)Math.Floor(rectf.Top);
            rect.Width = (int)System.Math.Ceiling(rectf.Width);
            rect.Height = (int)System.Math.Ceiling(rectf.Height);

            e.Graphics.PageUnit = this.GraphicsUnit;
            e.Graphics.ResetTransform();

            //e.Graphics.TranslateTransform( trans.SourceRect.Left , trans.SourceRect.Top );
            e.Graphics.ScaleTransform(this._XZoomRate, this._YZoomRate);


            //e.Graphics.TranslateTransform(
            //    (float)(ClientRectangle.Left * rate - trans.DescRectF.X),
            //    (float)(ClientRectangle.Top * rate - trans.DescRectF.Y));

            if (ClientToViewXRate < 1)
                rect.Width = rect.Width + (int)System.Math.Ceiling(1 / ClientToViewXRate);

            if (ClientToViewYRate < 1)
                rect.Height = rect.Height + (int)System.Math.Ceiling(1 / ClientToViewYRate);

            PaintEventArgs e2 = new PaintEventArgs(e.Graphics, rect);

            e2.Graphics.ResetClip();

            OnViewPaint(e2);
        }













        public DocumentViewControl()
        {
            this.AutoScroll = true;
            this.Size = new Size(200, 200);

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            if (DoubleBuffering)
            {

                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            }


        }






















    }
}
