using DCSoft.Drawing;
using DCSoft.Printing;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
    [ComVisible(false)]
    public class MultiPageTransform : MultiRectangleTransform
    {
        protected PrintPageCollection printPageCollection_0 = null;

        private int int_2 = -1;

        protected bool bool_0 = false;

        /// <summary>
        /// Ò³Ãæ¼¯ºÏ
        /// </summary>
        public PrintPageCollection Pages { get; set; }


        public virtual void AddPage(PrintPage page, float PageTop, float ZoomRate)
        {
            Rectangle empty = Rectangle.Empty;
            int leftMargin = (int)(page.ViewLeftMargin * ZoomRate);
            int topMargin = (int)(page.ViewTopMargin * ZoomRate);
            _ = (int)(page.ViewRightMargin * ZoomRate);

            int bottomMargin = (int)(page.ViewBottomMargin * ZoomRate);
            _ = (int)(page.ViewPaperWidth * ZoomRate);

            int num4 = (int)(page.ViewPaperHeight * ZoomRate);
            int top = (int)PageTop + topMargin; 
            SimpleRectangleTransform item = null;
            if (page.HeaderContentHeight > 0f)
            {
                item = new SimpleRectangleTransform();
                item.method_13(page.GlobalIndex);
                item.method_1(page.FirstPageFlag ? PageContentPartyStyle.HeaderForFirstPage : PageContentPartyStyle.Header);
                item.method_9(page);
                item.method_11(page.Document);
                item.set_DescRectF(new RectangleF(0f, 0f, page.Width, page.HeaderContentHeight - 1f));
                top = SetSourceRect(item, ZoomRate, leftMargin + page.ClientLeftFix, top);
                method_17(item);
            }
            item = new SimpleRectangleTransform();
            item.method_13(page.GlobalIndex);
            item.method_1(PageContentPartyStyle.Body);
            item.method_9(page);
            item.method_11(page.Document);
            item.set_DescRectF(new RectangleF(0f, page.Top, page.Width, page.Height));
            top = SetSourceRect(item, ZoomRate, leftMargin + page.ClientLeftFix, top);
            method_17(item);
            if (page.FooterContentHeight > 0f)
            {
                item = new SimpleRectangleTransform();
                item.method_13(page.GlobalIndex);
                item.method_1((!page.FirstPageFlag) ? PageContentPartyStyle.Footer : PageContentPartyStyle.FooterForFirstPage);
                item.method_9(page);
                item.method_11(page.Document);
                item.set_DescRectF(new RectangleF(0f, page.DocumentHeight - page.FooterContentHeight + 1f, page.Width, page.FooterContentHeight - 1f));
                SetSourceRect(item, ZoomRate, leftMargin, top);
                empty = item.method_21();
                top = (int)(PageTop + (float)num4 - (float)bottomMargin - (float)empty.Height);
                item.setSourceRectF(new RectangleF(leftMargin + page.ClientLeftFix, top, empty.Width, empty.Height));
                method_17(item);
            }
        }

        private int SetSourceRect(SimpleRectangleTransform gclass435_1, float float_0, int int_3, int int_4)
        {
            RectangleF rectangleF_ = Rectangle.Empty;
            rectangleF_.X = int_3;
            rectangleF_.Y = int_4;
            rectangleF_.Width = (int)(gclass435_1.method_25().Width * float_0);
            rectangleF_.Height = (int)(gclass435_1.method_25().Height * float_0);
            gclass435_1.setSourceRectF(rectangleF_);
            return (int)rectangleF_.Bottom;
        }

        public void Refresh(float zoom, int pagespacing, int int_4, int topspacing)
        {
            mySourceOffsetBack = Point.Empty; 
            method_25();
            float num2 = pagespacing + topspacing;
            foreach (PrintPage item2 in Pages)
            {
                AddPage(item2, num2, zoom);
                Rectangle clientBounds = item2.ClientBounds;
                clientBounds.Y = (int)num2;
                item2.ClientBounds = clientBounds;
                num2 = num2 + item2.PageSettings.ViewPaperHeight * zoom + (float)int_4;
            }
        }

        public int method_30()
        {
            return int_2;
        }

        public void method_31(int int_3)
        {
            int_2 = int_3;
        }

        public bool method_32()
        {
            return bool_0;
        }

        public void method_33(bool bool_1)
        {
            bool_0 = bool_1;
        }

        public override Point UnTransformPoint(int int_3, int int_4)
        {
            if (bool_0)
            {
                PointF pointF = AbsUnTransformPoint(int_3, int_4);
                return new Point((int)pointF.X, (int)pointF.Y);
            }
            Point empty = Point.Empty;
            int num = base.Count - 1;
            SimpleRectangleTransform gClass;
            while (true)
            {
                if (num >= 0)
                {
                    gClass = method_7(num);
                    if (gClass.getEnable() && gClass.method_27().Contains(int_3, int_4))
                    {
                        break;
                    }
                    num--;
                    continue;
                }
                return empty;
            }
            return gClass.UnTransformPoint(int_3, int_4);
        }

        public override PointF UnTransformPointF(float float_0, float float_1)
        {
            if (bool_0)
            {
                return AbsUnTransformPoint(float_0, float_1);
            }
            return base.UnTransformPointF(float_0, float_1);
        }

        public override Point TransformPoint(int int_3, int int_4)
        {
            if (bool_0)
            {
                PointF pointF = AbsTransformPoint(int_3, int_4);
                return new Point((int)pointF.X, (int)pointF.Y);
            }
            return base.TransformPoint(int_3, int_4);
        }

        public override PointF TransformPointF(float float_0, float float_1)
        {
            if (bool_0)
            {
                return AbsTransformPoint(float_0, float_1);
            }
            return base.TransformPointF(float_0, float_1);
        }

        public override bool ContainsSourcePoint(int int_3, int int_4)
        {
            if (bool_0)
            {
                return true;
            }
            return base.ContainsSourcePoint(int_3, int_4);
        }

        public override Point TransformPoint(Point point_1)
        {
            return base.TransformPoint(point_1);
        }

        public PointF AbsUnTransformPoint(float float_0, float float_1)
        {
            SimpleRectangleTransform gClass = null;
            SimpleRectangleTransform gClass2 = null;
            SimpleRectangleTransform gClass3 = null;
            IEnumerator enumerator = GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    SimpleRectangleTransform gClass4 = (SimpleRectangleTransform)enumerator.Current;
                    if (gClass4.getEnable() && (int_2 < 0 || gClass4.method_12() == int_2))
                    {
                        if (gClass4.method_25().Contains(float_0, float_1))
                        {
                            return gClass4.UnTransformPointF(float_0, float_1);
                        }
                        if (float_1 >= gClass4.method_25().Top && float_1 < gClass4.method_25().Bottom)
                        {
                            gClass3 = gClass4;
                            break;
                        }
                        if (float_1 < gClass4.method_25().Top && (gClass2 == null || gClass4.method_25().Top < gClass2.method_25().Top))
                        {
                            gClass2 = gClass4;
                        }
                        if (float_1 > gClass4.method_25().Bottom && (gClass == null || gClass4.method_25().Bottom > gClass.method_25().Bottom))
                        {
                            gClass = gClass4;
                        }
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            if (gClass3 == null)
            {
                gClass3 = ((gClass == null) ? gClass2 : gClass);
            }
            if (gClass3 == null)
            {
                return PointF.Empty;
            }
            PointF pointF_ = new PointF(float_0, float_1);
            pointF_ = RectangleCommon.MoveInto(pointF_, gClass3.method_25());
            return gClass3.vmethod_15(pointF_);
        }

        public PointF AbsTransformPoint(float float_0, float float_1)
        {
            SimpleRectangleTransform pre = null;
            SimpleRectangleTransform next = null;
            SimpleRectangleTransform cur = null;
            IEnumerator enumerator = GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    SimpleRectangleTransform item = (SimpleRectangleTransform)enumerator.Current;
                    if (item.getEnable())
                    {
                        if (item.getSourceRectF().Contains(float_0, float_1))
                        {
                            return item.TransformPointF(float_0, float_1);
                        }
                        if (float_1 >= item.getSourceRectF().Top && float_1 <= item.getSourceRectF().Bottom)
                        {
                            cur = item;
                            break;
                        }
                        if (float_1 < item.getSourceRectF().Top && (next == null || item.getSourceRectF().Top < next.getSourceRectF().Top))
                        {
                            next = item;
                        }
                        if (float_1 > item.getSourceRectF().Bottom && (pre == null || item.getSourceRectF().Bottom > pre.getSourceRectF().Bottom))
                        {
                            pre = item;
                        }
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            if (cur == null)
            {
                cur = ((pre == null) ? next : pre);
            }
            if (cur == null)
            {
                return PointF.Empty;
            }
            PointF pointF_ = new PointF(float_0, float_1);
            pointF_ = RectangleCommon.MoveInto(pointF_, cur.getSourceRectF());
            return cur.vmethod_3(pointF_);
        }
    }
}
