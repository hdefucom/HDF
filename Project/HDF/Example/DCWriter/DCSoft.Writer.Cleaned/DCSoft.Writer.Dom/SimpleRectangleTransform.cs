using System.Drawing;

namespace New.Editor.Controls.Transform
{
    /// <summary>
    /// 简单矩形坐标转换对象
    /// </summary>
    public class SimpleRectangleTransform : TransformBase
    {
        public SimpleRectangleTransform()
        {
        }

        /// <summary>
        /// 初始化对象并设置原始区域和目标区域矩形
        /// </summary>
        /// <param name="source">原始区域矩形</param>
        /// <param name="desc">目标区域矩形</param>
        public SimpleRectangleTransform(RectangleF source, RectangleF desc)
        {
            SourceRectF = source;
            DescRectF = desc;
        }



        #region property

        /// <summary>
        /// 页面内容类型
        /// </summary>
        public PageContentPartyType ContentPartyType { get; set; } = PageContentPartyType.Body;


        /// <summary>
        /// 对象是否可用
        /// </summary>
        public bool Enable { get; set; } = true;

        /// <summary>
        /// 对象是否可见
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// 对象额外数据
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// 从0开始的页号
        /// </summary>
        public int PageIndex { get; set; }


        /// <summary>
        /// 原始区域矩形边框
        /// </summary>
        public RectangleF SourceRectF { get; set; } = RectangleF.Empty;

        /// <summary>
        /// 原始区域矩形边框
        /// </summary>
        public Rectangle SourceRect
        {
            get => Rectangle.Truncate(SourceRectF);
            set => SourceRectF = value;
        }

        /// <summary>
        /// 目标区域矩形边框
        /// </summary>
        public RectangleF DescRectF { get; set; } = RectangleF.Empty;
        /// <summary>
        /// 目标区域矩形边框
        /// </summary>
        public Rectangle DescRect
        {
            get => Rectangle.Truncate(DescRectF);
            set => DescRectF = value;
        }

        public Point OffsetPosition => Point.Truncate(OffsetPositionF);

        public PointF OffsetPositionF => new PointF(DescRectF.Left - SourceRectF.Left, DescRectF.Top - SourceRectF.Top);

        public float XZoomRate => DescRectF.Width / SourceRectF.Width;

        public float YZoomRate => DescRectF.Height / SourceRectF.Height;

        #endregion property


        #region override virtual

        public override bool ContainsSourcePoint(int x, int y) => this.SourceRectF.Contains(x, y);

        public override Point TransformPoint(int x, int y) => Point.Truncate(TransformPointF(x, y));

        public override PointF TransformPointF(float x, float y)
        {
            x -= SourceRectF.Left;
            y -= SourceRectF.Top;
            if (SourceRectF.Width != DescRectF.Width && SourceRectF.Width != 0)
                x = x * DescRectF.Width / SourceRectF.Width;
            if (SourceRectF.Height != DescRectF.Height && SourceRectF.Height != 0)
                y = y * DescRectF.Height / SourceRectF.Height;
            return new PointF(x + DescRect.Left, y + DescRect.Top);
        }

        public override Size TransformSize(int w, int h) => Size.Truncate(TransformSizeF(w, h));

        public override SizeF TransformSizeF(float w, float h)
        {
            if (SourceRectF.Width != DescRectF.Width && SourceRectF.Width != 0)
                w = w * DescRectF.Width / SourceRectF.Width;
            if (SourceRectF.Height != DescRectF.Height && SourceRectF.Height != 0)
                h = h * DescRectF.Height / SourceRectF.Height;
            return new SizeF(w, h);
        }

        public override Point UnTransformPoint(int x, int y) => Point.Truncate(UnTransformPointF(x, y));

        public override PointF UnTransformPointF(float x, float y)
        {
            x -= SourceRectF.Left;
            y -= SourceRectF.Top;
            if (SourceRectF.Width != DescRectF.Width && DescRectF.Width != 0)
                x = x * SourceRectF.Width / DescRectF.Width;
            if (SourceRectF.Height != DescRectF.Height && DescRectF.Height != 0)
                y = y * SourceRectF.Height / DescRectF.Height;
            return new PointF(x + SourceRect.Left, y + SourceRect.Top);
        }

        public override Size UnTransformSize(int w, int h) => Size.Truncate(UnTransformSizeF(w, h));

        public override SizeF UnTransformSizeF(float w, float h)
        {
            if (SourceRectF.Width != DescRectF.Width && DescRectF.Width != 0)
                w = w * SourceRectF.Width / DescRectF.Width;
            if (SourceRectF.Height != DescRectF.Height && DescRectF.Height != 0)
                h = h * SourceRectF.Height / DescRectF.Height;
            return new SizeF(w, h);
        }

        #endregion override virtual


    }







}
