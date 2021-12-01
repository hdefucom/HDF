using DCSoft.Drawing;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
    [ComVisible(false)]
    public class SimpleRectangleTransform : TransformBase
    {
        private PageContentPartyStyle pageContentPartyStyle_0 = PageContentPartyStyle.Body;

        private bool bool_0 = true;

        private bool bool_1 = true;

        private bool bool_2 = true;

        private object object_0 = null;

        private object object_1 = null;

        private int int_0 = 0;

        private int int_1 = 0;

        private RectangleF SourceRect = RectangleF.Empty;

        private PointF pointF_0 = new PointF(0f, 0f);

        internal Rectangle rectangle_0 = Rectangle.Empty;

        private RectangleF DescRectF = RectangleF.Empty;

        public SimpleRectangleTransform()
        {
        }

        public SimpleRectangleTransform(RectangleF rectangleF_2, RectangleF rectangleF_3)
        {
            SourceRect = rectangleF_2;
            DescRectF = rectangleF_3;
        }

        public PageContentPartyStyle method_0()
        {
            return pageContentPartyStyle_0;
        }

        public void method_1(PageContentPartyStyle pageContentPartyStyle_1)
        {
            pageContentPartyStyle_0 = pageContentPartyStyle_1;
        }

        public bool getEnable()
        {
            return bool_0;
        }

        public void setEnable(bool bool_3)
        {
            bool_0 = bool_3;
        }

        public bool method_4()
        {
            return bool_1;
        }

        public void method_5(bool bool_3)
        {
            bool_1 = bool_3;
        }

        public bool getVisible()
        {
            return bool_2;
        }

        public void method_7(bool bool_3)
        {
            bool_2 = bool_3;
        }

        public object method_8()
        {
            return object_0;
        }

        public void method_9(object object_2)
        {
            object_0 = object_2;
        }

        public object method_10()
        {
            return object_1;
        }

        public void method_11(object object_2)
        {
            object_1 = object_2;
        }

        public int method_12()
        {
            return int_0;
        }

        public void method_13(int int_2)
        {
            int_0 = int_2;
        }

        public int method_14()
        {
            return int_1;
        }

        public void method_15(int int_2)
        {
            int_1 = int_2;
        }

        public RectangleF getSourceRectF()
        {
            return SourceRect;
        }

        public void setSourceRectF(RectangleF rectangleF_2)
        {
            SourceRect = rectangleF_2;
        }

        public PointF method_18()
        {
            return pointF_0;
        }

        public void method_19(PointF pointF_1)
        {
            pointF_0 = pointF_1;
        }

        public void method_20(float float_0, float float_1)
        {
            SourceRect.Offset(float_0, float_1);
        }

        public Rectangle method_21()
        {
            return new Rectangle((int)SourceRect.Left, (int)SourceRect.Top, (int)SourceRect.Width, (int)SourceRect.Height);
        }

        public void set_SourceRect(Rectangle rectangle_1)
        {
            SourceRect = new RectangleF(rectangle_1.Left, rectangle_1.Top, rectangle_1.Width, rectangle_1.Height);
        }

        public Rectangle method_23()
        {
            if (rectangle_0.IsEmpty)
            {
                return method_21();
            }
            return rectangle_0;
        }

        public void method_24(Rectangle rectangle_1)
        {
            rectangle_0 = rectangle_1;
        }

        public RectangleF method_25()
        {
            return DescRectF;
        }

        public void set_DescRectF(RectangleF rectangleF_2)
        {
            DescRectF = rectangleF_2;
        }

        public Rectangle method_27()
        {
            return new Rectangle((int)DescRectF.Left, (int)DescRectF.Top, (int)DescRectF.Width, (int)DescRectF.Height);
        }

        public void method_28(Rectangle rectangle_1)
        {
            DescRectF = new RectangleF(rectangle_1.Left, rectangle_1.Top, rectangle_1.Width, rectangle_1.Height);
        }

        public Point method_29()
        {
            return new Point((int)(DescRectF.Left - SourceRect.Left - pointF_0.X), (int)(DescRectF.Top - SourceRect.Top - pointF_0.Y));
        }

        public PointF method_30()
        {
            return new PointF(DescRectF.Left - SourceRect.Left - pointF_0.X, DescRectF.Top - SourceRect.Top - pointF_0.Y);
        }

        public float method_31()
        {
            float width = DescRectF.Width;
            return width / SourceRect.Width;
        }

        public float method_32()
        {
            float height = DescRectF.Height;
            return height / SourceRect.Height;
        }

        public override bool ContainsSourcePoint(int int_2, int int_3)
        {
            return SourceRect.Contains((float)int_2 - pointF_0.X, (float)int_3 - pointF_0.Y);
        }

        public override Point TransformPoint(int int_2, int int_3)
        {
            PointF pointF = TransformPointF(int_2, int_3);
            return new Point((int)pointF.X, (int)pointF.Y);
        }

        public override PointF TransformPointF(float float_0, float float_1)
        {
            float_0 = float_0 - SourceRect.Left - pointF_0.X;
            float_1 = float_1 - SourceRect.Top - pointF_0.Y;
            if (SourceRect.Width != DescRectF.Width && SourceRect.Width != 0f)
            {
                float_0 = float_0 * DescRectF.Width / SourceRect.Width;
            }
            if (SourceRect.Height != DescRectF.Height && SourceRect.Height != 0f)
            {
                float_1 = float_1 * DescRectF.Height / SourceRect.Height;
            }
            return new PointF(float_0 + (float)method_27().Left, float_1 + (float)method_27().Top);
        }

        public override Size vmethod_6(int int_2, int int_3)
        {
            if (SourceRect.Width != DescRectF.Width && SourceRect.Width != 0f)
            {
                int_2 = (int)((float)int_2 * DescRectF.Width / SourceRect.Width);
            }
            if (SourceRect.Height != DescRectF.Height && SourceRect.Height != 0f)
            {
                int_3 = (int)((float)int_3 * DescRectF.Height / SourceRect.Height);
            }
            return new Size(int_2, int_3);
        }

        public override SizeF vmethod_8(float float_0, float float_1)
        {
            if (SourceRect.Width != DescRectF.Width && SourceRect.Width != 0f)
            {
                float_0 = float_0 * DescRectF.Width / SourceRect.Width;
            }
            if (SourceRect.Height != DescRectF.Height && SourceRect.Height != 0f)
            {
                float_1 = float_1 * DescRectF.Height / SourceRect.Height;
            }
            return new SizeF(float_0, float_1);
        }

        public override Point UnTransformPoint(Point point_0)
        {
            PointF pointF = UnTransformPointF(point_0.X, point_0.Y);
            return new Point((int)pointF.X, (int)pointF.Y);
        }

        public override Point UnTransformPoint(int int_2, int int_3)
        {
            PointF pointF = UnTransformPointF(int_2, int_3);
            return new Point((int)pointF.X, (int)pointF.Y);
        }

        public override PointF UnTransformPointF(float float_0, float float_1)
        {
            float_0 -= DescRectF.Left;
            float_1 -= DescRectF.Top;
            if (SourceRect.Width != DescRectF.Width && DescRectF.Width != 0f)
            {
                float_0 = float_0 * SourceRect.Width / DescRectF.Width;
            }
            if (SourceRect.Height != DescRectF.Height && DescRectF.Height != 0f)
            {
                float_1 = float_1 * SourceRect.Height / DescRectF.Height;
            }
            return new PointF(float_0 + SourceRect.Left + pointF_0.X, float_1 + SourceRect.Top + pointF_0.Y);
        }

        public override Size UnTransformSize(int int_2, int int_3)
        {
            if (SourceRect.Width != DescRectF.Width && DescRectF.Width != 0f)
            {
                int_2 = (int)((float)int_2 * SourceRect.Width / DescRectF.Width);
            }
            if (SourceRect.Height != DescRectF.Height && DescRectF.Height != 0f)
            {
                int_3 = (int)((float)int_3 * SourceRect.Height / DescRectF.Height);
            }
            return new Size(int_2, int_3);
        }

        public override SizeF vmethod_20(float float_0, float float_1)
        {
            if (SourceRect.Width != DescRectF.Width && DescRectF.Width != 0f)
            {
                float_0 = float_0 * SourceRect.Width / DescRectF.Width;
            }
            if (SourceRect.Height != DescRectF.Height && DescRectF.Height != 0f)
            {
                float_1 = float_1 * SourceRect.Height / DescRectF.Height;
            }
            return new SizeF(float_0, float_1);
        }

        public override string ToString()
        {
            return string.Concat(method_12(), " ", method_0(), " {", SourceRect.X, ",", SourceRect.Y, ",", SourceRect.Width, ",", SourceRect.Height, "}->{", DescRectF.X, ",", DescRectF.Y, ",", DescRectF.Width, ",", DescRectF.Height, "}");
        }
    }
}
