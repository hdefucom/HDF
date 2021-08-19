using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DCSoft.Printing
{
    /// <summary>
    ///       带分页功能的视图控件
    ///       </summary>
    [ToolboxItem(false)]
    [ComVisible(true)]
    [DocumentComment]
    [Guid("00012345-6789-ABCD-EF01-234567890005")]
    public class PageViewControl : DocumentViewControl
    {
        private int int_2 = -1;

        private int int_3 = -1;

        private PageViewMode pageViewMode_0 = PageViewMode.Page;

        private PrintPage printPage_0 = null;

        private EventHandler eventHandler_1 = null;

        private PrintPageCollection printPageCollection_0 = new PrintPageCollection();

        private SimpleRectangleTransform gclass435_0 = null;

        private bool bool_13 = false;

        private bool bool_14 = false;

        private GClass543 gclass543_0 = null;

        protected int int_4 = 20;

        protected Color color_0 = SystemColors.Window;

        private Color color_1 = Color.Black;

        private PageBorderBackgroundStyle pageBorderBackgroundStyle_0 = null;

        private Color color_2 = Color.Black;

        private int int_5 = 60;

        private HeaderFooterFlagVisible headerFooterFlagVisible_0 = HeaderFooterFlagVisible.None;

        private bool bool_15 = false;

        private static Font font_0 = null;

        /// <summary>
        ///       从0开始的计算的开始显示的页码号,只有处于分页视图模式下该属性才有效。小于0则不启用该设置。
        ///       </summary>
        [Category("Appearance")]
        [DefaultValue(-1)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int StartPageIndex
        {
            get
            {
                return int_2;
            }
            set
            {
                int_2 = value;
            }
        }

        /// <summary>
        ///       从0开始计算的最后显示的页码号,为0表示没有设置。只有处于分页视图模式下该属性才有效。小于0则不启用该设置。
        ///       </summary>
        [DefaultValue(-1)]
        [Category("Appearance")]
        public int EndPageIndex
        {
            get
            {
                return int_3;
            }
            set
            {
                int_3 = value;
            }
        }

        /// <summary>
        ///       页面显示模式
        ///       </summary>
        [DefaultValue(PageViewMode.Page)]
        [Browsable(false)]
        public PageViewMode ViewMode
        {
            get
            {
                return pageViewMode_0;
            }
            set
            {
                pageViewMode_0 = value;
            }
        }

        /// <summary>
        ///       运行时使用的视图模式
        ///       </summary>
        [Browsable(false)]
        public virtual PageViewMode RuntimeViewMode
        {
            get
            {
                if (AutoZoom && ViewMode == PageViewMode.AutoLine)
                {
                    return PageViewMode.Normal;
                }
                return ViewMode;
            }
        }

        /// <summary>
        ///       当前页对象
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual PrintPage CurrentPage
        {
            get
            {
                return printPage_0;
            }
            set
            {
                printPage_0 = value;
                if (printPage_0 != null && RuntimeViewMode == PageViewMode.Page)
                {
                    int top = printPage_0.ClientBounds.Top;
                    SetAutoScrollPosition(new Point(base.AutoScrollPosition.X, top));
                }
            }
        }

        /// <summary>
        ///       从1开始计算的当前页号
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPageIndex
        {
            get
            {
                if (CurrentPage == null)
                {
                    return 0;
                }
                return CurrentPage.PageIndex;
            }
            set
            {
                value--;
                if (Pages != null && value >= 0 && value < Pages.Count)
                {
                    CurrentPage = Pages[value];
                }
            }
        }

        /// <summary>
        ///       页面集合
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrintPageCollection Pages
        {
            get
            {
                return printPageCollection_0;
            }
            set
            {
                printPageCollection_0 = value;
            }
        }

        /// <summary>
        ///       文档中可见的页面对象
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PrintPageCollection VisiblePages
        {
            get
            {
                if (printPageCollection_0 == null)
                {
                    return null;
                }
                return printPageCollection_0.GetVisiblePages(StartPageIndex, EndPageIndex);
            }
        }

        /// <summary>
        ///       当前转换信息对象
        ///       </summary>
        protected SimpleRectangleTransform CurrentTransformItem
        {
            get
            {
                return gclass435_0;
            }
            set
            {
                gclass435_0 = value;
            }
        }

        /// <summary>
        ///       分页坐标转换对象
        ///       </summary>
        [Browsable(false)]
        public MultiPageTransform PagesTransform => (MultiPageTransform)base.Transform;

        /// <summary>
        ///       文档内容高度
        ///       </summary>
        [Browsable(false)]
        public virtual float ContentViewHeight => 0f;

        /// <summary>
        ///       文档内容宽度
        ///       </summary>
        [Browsable(false)]
        public virtual float ContentViewWidth
        {
            get
            {
                if (RuntimeViewMode == PageViewMode.Normal || RuntimeViewMode == PageViewMode.NormalCenter)
                {
                    return Pages.GetPageMaxWidth();
                }
                if (RuntimeViewMode == PageViewMode.AutoLine)
                {
                    return (float)((double)base.ClientSize.Width * base.ClientToViewXRate);
                }
                if (RuntimeViewMode == PageViewMode.Page)
                {
                    GClass543 commentSettings = CommentSettings;
                    float num = 0f;
                    foreach (PrintPage page in Pages)
                    {
                        float num2 = page.PageSettings.ViewPaperWidth;
                        if (commentSettings != null && commentSettings.method_0() && commentSettings.method_2() >= page.ViewRightMargin)
                        {
                            float num3 = commentSettings.method_2() - page.ViewRightMargin;
                            num2 += num3;
                        }
                        if (num < num2)
                        {
                            num = num2;
                        }
                    }
                    return num;
                }
                return 0f;
            }
        }

        /// <summary>
        ///       设置自动缩放
        ///       </summary>
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool AutoZoom
        {
            get
            {
                return bool_13;
            }
            set
            {
                bool_13 = value;
            }
        }

        /// <summary>
        ///       是否具有文档批注的区域
        ///       </summary>
        [Browsable(false)]
        public bool HasCommentArea => bool_14;

        /// <summary>
        ///       文档批注区域设置
        ///       </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual GClass543 CommentSettings
        {
            get
            {
                return gclass543_0;
            }
            set
            {
                gclass543_0 = value;
            }
        }

        /// <summary>
        ///       分页模式下的控件顶端预留空白高度
        ///       </summary>
        protected virtual int PreserveSpacingInPageView => 0;

        /// <summary>
        ///       处于页面视图模式时各个页面间的距离，像素为单位
        ///       </summary>
        [DefaultValue(20)]
        [Category("Appearance")]
        public int PageSpacing
        {
            get
            {
                return int_4;
            }
            set
            {
                int_4 = value;
            }
        }

        /// <summary>
        ///       总页数
        ///       </summary>
        [Browsable(false)]
        public int PageCount
        {
            get
            {
                if (printPageCollection_0 != null)
                {
                    return printPageCollection_0.Count;
                }
                return 0;
            }
        }

        /// <summary>
        ///       是否采用绝对的坐标转换
        ///       </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool UseAbsTransformPoint
        {
            get
            {
                return PagesTransform.method_32();
            }
            set
            {
                PagesTransform.method_33(value);
            }
        }

        /// <summary>
        ///       设置或返回从1开始的当前页号
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageIndex
        {
            get
            {
                if (printPage_0 == null)
                {
                    return 0;
                }
                return printPage_0.GlobalIndex;
            }
            set
            {
                MoveToPage(value);
            }
        }

        /// <summary>
        ///       页背景色
        ///       </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Window")]
        public Color PageBackColor
        {
            get
            {
                return color_0;
            }
            set
            {
                if (color_0 != value)
                {
                    color_0 = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        ///       页面边框线颜色
        ///       </summary>
        [DefaultValue(typeof(Color), "Black")]
        [Category("Appearance")]
        public Color PageBorderColor
        {
            get
            {
                return color_1;
            }
            set
            {
                color_1 = value;
            }
        }

        /// <summary>
        ///       页面内容边框设置
        ///       </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public PageBorderBackgroundStyle PageContentBorderStyle
        {
            get
            {
                return pageBorderBackgroundStyle_0;
            }
            set
            {
                pageBorderBackgroundStyle_0 = value;
            }
        }

        /// <summary>
        ///       页面边框线颜色
        ///       </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public Color CurrentPageBorderColor
        {
            get
            {
                return color_2;
            }
            set
            {
                color_2 = value;
            }
        }

        /// <summary>
        ///       表示页面边距的线条长度
        ///       </summary>
        [DefaultValue(60)]
        [Category("Appearance")]
        public int PageMarginLineLength
        {
            get
            {
                return int_5;
            }
            set
            {
                int_5 = value;
            }
        }

        protected virtual bool RuntimeDesignMode => false;

        /// <summary>
        ///       是否显示页眉页脚标记
        ///       </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual HeaderFooterFlagVisible HeaderFooterFlagVisible
        {
            get
            {
                return headerFooterFlagVisible_0;
            }
            set
            {
                headerFooterFlagVisible_0 = value;
            }
        }

        /// <summary>
        ///       阅读版式视图模式
        ///       </summary>
        [DefaultValue(false)]
        public bool ReadViewMode
        {
            get
            {
                return bool_15;
            }
            set
            {
                bool_15 = value;
            }
        }

        /// <summary>
        ///       当前页改变事件
        ///       </summary>
        public event EventHandler CurrentPageChanged
        {
            add
            {
                EventHandler eventHandler = eventHandler_1;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
            remove
            {
                EventHandler eventHandler = eventHandler_1;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
        }

        /// <summary>
        ///       无作为的初始化对象
        ///       </summary>
        public PageViewControl()
        {
            myTransform = new MultiPageTransform();
        }

        public bool method_36(PrintPage printPage_1)
        {
            if (printPage_0 != printPage_1)
            {
                printPage_0 = printPage_1;
                return true;
            }
            return false;
        }

        public virtual bool UpdateCurrentPage()
        {
            if (printPageCollection_0 != null)
            {
                PrintPage printPage = null;
                Rectangle b = new Rectangle(-base.AutoScrollPosition.X, -base.AutoScrollPosition.Y, base.ClientSize.Width, base.ClientSize.Height);
                int num = 0;
                foreach (PrintPage item in printPageCollection_0)
                {
                    Rectangle rectangle = Rectangle.Intersect(item.ClientBounds, b);
                    if (!rectangle.IsEmpty && num < rectangle.Height)
                    {
                        printPage = item;
                        num = rectangle.Height;
                    }
                }
                if (printPage != printPage_0)
                {
                    printPage_0 = printPage;
                    return true;
                }
            }
            return false;
        }

        public virtual void OnCurrentPageChanged()
        {
            if (eventHandler_1 != null)
            {
                eventHandler_1(this, null);
            }
        }

        public PointF method_37(float float_2, float float_3, GEnum24 genum24_0)
        {
            return method_38(float_2, float_3, genum24_0)?.UnTransformPointF(float_2, float_3) ?? new PointF(float.NaN, float.NaN);
        }

        public SimpleRectangleTransform method_38(float float_2, float float_3, GEnum24 genum24_0)
        {
            RefreshScaleTransform();
            SimpleRectangleTransform result = null;
            switch (genum24_0)
            {
                case GEnum24.const_0:
                    result = PagesTransform.method_11(float_2, float_3);
                    break;
                case GEnum24.const_1:
                    result = PagesTransform.method_12(float_2, float_3);
                    break;
                case GEnum24.const_2:
                    result = CurrentTransformItem;
                    break;
            }
            return result;
        }

        public PointF method_39(float float_2, float float_3, GEnum24 genum24_0)
        {
            RefreshScaleTransform();
            SimpleRectangleTransform gClass = null;
            switch (genum24_0)
            {
                case GEnum24.const_0:
                    gClass = PagesTransform.method_13(float_2, float_3);
                    break;
                case GEnum24.const_1:
                    gClass = PagesTransform.method_14(float_2, float_3);
                    break;
                case GEnum24.const_2:
                    gClass = CurrentTransformItem;
                    break;
            }
            return gClass?.TransformPointF(float_2, float_3) ?? new PointF(float.NaN, float.NaN);
        }

        protected override void RefreshScaleTransform()
        {
            MultiPageTransform gClass = (MultiPageTransform)myTransform;
            GraphicsUnit = printPageCollection_0.GraphicsUnit;
            gClass.method_2(GraphicsUnitConvert.GetRate(GraphicsUnit, GraphicsUnit.Pixel));
            Point autoScrollPosition = base.AutoScrollPosition;
            gClass.ClearSourceOffset();
            gClass.OffsetSource(autoScrollPosition.X, autoScrollPosition.Y, bool_0: true);
        }

        public virtual void UpdatePages()
        {
            if (GClass354.smethod_3() || Pages == null || Pages.Count == 0)
            {
                return;
            }
            bool_14 = false;
            float rate = (float)(1.0 / base.ClientToViewXRate);
            Size size_;
            if (RuntimeViewMode == PageViewMode.AutoLine)
            {
                if (base.ClientSize.Width >= 30)
                {
                    PagesTransform.method_25();
                    PagesTransform.ClearSourceOffset();
                    SimpleRectangleTransform gClass = new SimpleRectangleTransform();
                    gClass.method_13(0);
                    float contentViewHeight = ContentViewHeight;
                    gClass.setSourceRectF(new RectangleF(0f, 0f, base.ClientSize.Width, contentViewHeight * rate));
                    gClass.set_DescRectF(new RectangleF(0f, 0f, gClass.getSourceRectF().Width / rate, contentViewHeight));
                    gClass.method_9(Pages[0]);
                    gClass.method_1(PageContentPartyStyle.Body);
                    gClass.setEnable(bool_3: true);
                    gClass.method_11(Pages[0].Document);
                    PagesTransform.method_17(gClass);
                    PagesTransform.ClearSourceOffset();
                    RefreshScaleTransform();
                    size_ = new Size((int)Math.Ceiling(gClass.getSourceRectF().Width), (int)Math.Ceiling(gClass.getSourceRectF().Height));
                    size_.Width = 0;
                    method_7(size_);
                    CurrentPage = Pages[0];
                    float num2 = 0f;
                    foreach (PrintPage page in Pages)
                    {
                        page.ClientBounds = new Rectangle(0, (int)(num2 * rate), (int)(page.Bounds.Width * rate), (int)(page.Bounds.Height * rate));
                        num2 += page.Bounds.Height;
                    }
                }
            }
            else if (RuntimeViewMode == PageViewMode.Normal)
            {
                PagesTransform.method_25();
                PagesTransform.ClearSourceOffset();
                SimpleRectangleTransform gClass = new SimpleRectangleTransform();
                gClass.method_13(0);
                gClass.set_DescRectF(new RectangleF(0f, 0f, ContentViewWidth, Pages.Height));
                gClass.setSourceRectF(new RectangleF(0f, 0f, gClass.method_25().Width * rate, gClass.method_25().Height * rate));
                gClass.method_9(Pages[0]);
                gClass.method_1(PageContentPartyStyle.Body);
                gClass.setEnable(bool_3: true);
                gClass.method_11(Pages[0].Document);
                PagesTransform.method_17(gClass);
                PagesTransform.ClearSourceOffset();
                RefreshScaleTransform();
                size_ = new Size((int)Math.Ceiling(gClass.getSourceRectF().Width), (int)Math.Ceiling(gClass.getSourceRectF().Height));
                if (AutoZoom)
                {
                    size_.Width = 5;
                }
                method_7(size_);
                CurrentPage = Pages[0];
                float num2 = 0f;
                foreach (PrintPage page2 in Pages)
                {
                    page2.ClientBounds = new Rectangle(0, (int)(num2 * rate), (int)(page2.Bounds.Width * rate), (int)(page2.Bounds.Height * rate));
                    num2 += page2.Bounds.Height;
                }
            }
            else if (RuntimeViewMode == PageViewMode.NormalCenter)
            {
                PagesTransform.method_25();
                PagesTransform.ClearSourceOffset();
                SimpleRectangleTransform gClass = new SimpleRectangleTransform();
                gClass.method_13(0);
                gClass.set_DescRectF(new RectangleF(0f, 0f, ContentViewWidth, Pages.Height));
                RectangleF rectangleF_ = new RectangleF(0f, 0f, gClass.method_25().Width * rate, gClass.method_25().Height * rate);
                if (rectangleF_.Width < (float)base.ClientSize.Width)
                {
                    rectangleF_.X = ((float)base.ClientSize.Width - rectangleF_.Width) / 2f;
                }
                gClass.setSourceRectF(rectangleF_);
                gClass.method_9(Pages[0]);
                gClass.method_1(PageContentPartyStyle.Body);
                gClass.setEnable(bool_3: true);
                gClass.method_11(Pages[0].Document);
                PagesTransform.method_17(gClass);
                PagesTransform.ClearSourceOffset();
                RefreshScaleTransform();
                size_ = new Size((int)Math.Ceiling(gClass.getSourceRectF().Width), (int)Math.Ceiling(gClass.getSourceRectF().Height));
                method_7(size_);
                CurrentPage = Pages[0];
                float num2 = 0f;
                foreach (PrintPage page3 in Pages)
                {
                    page3.ClientBounds = new Rectangle((int)gClass.getSourceRectF().X, (int)(num2 * rate), (int)(page3.Bounds.Width * rate), (int)(page3.Bounds.Height * rate));
                    num2 += page3.Bounds.Height;
                }
            }
            else if (RuntimeViewMode == PageViewMode.Page)
            {
                GClass543 commentSettings = CommentSettings;
                PrintPageCollection visiblePages = VisiblePages;
                foreach (PrintPage item in visiblePages)
                {
                    Rectangle empty = Rectangle.Empty;
                    empty.Width = (int)(item.PageSettings.ViewPaperWidth * rate);
                    empty.Height = (int)(item.PageSettings.ViewPaperHeight * rate);
                    item.ClientBounds = empty;
                    item.ClientMargins = new Margins((int)(item.ViewLeftMargin * rate), (int)(item.ViewRightMargin * rate), (int)(item.ViewTopMargin * rate), (int)(item.ViewBottomMargin * rate));
                    if (commentSettings != null && commentSettings.method_0() && commentSettings.method_2() >= item.ViewRightMargin)
                    {
                        bool_14 = true;
                        int num3 = (int)Math.Ceiling(commentSettings.method_2() * rate - item.ViewRightMargin * rate);
                        item.ClientBounds = new Rectangle(item.ClientBounds.Left, item.ClientBounds.Top, item.ClientBounds.Width + num3, item.ClientBounds.Height);
                        item.ClientMargins.Right = item.ClientMargins.Right + num3;
                    }
                }
                SizeF sizeF = new SizeF(0f, 0f);
                foreach (PrintPage item2 in visiblePages)
                {
                    sizeF.Height = sizeF.Height + (float)PageSpacing + (float)item2.ClientBounds.Height;
                    if (sizeF.Width < (float)item2.ClientBounds.Width)
                    {
                        sizeF.Width = item2.ClientBounds.Width;
                    }
                }
                if (!AutoZoom)
                {
                    sizeF.Width += PageSpacing * 2;
                    sizeF.Height += PageSpacing;
                }
                foreach (PrintPage item3 in visiblePages)
                {
                    item3.ClientLeftFix = (int)(sizeF.Width - (float)item3.ClientBounds.Width) / 2;
                }
                MultiPageTransform gClass2 = (MultiPageTransform)base.Transform;
                base.GraphicsUnit = Pages.GraphicsUnit;
                gClass2.Pages = visiblePages;
                gClass2.Refresh(rate, (!AutoZoom) ? PageSpacing : 0, PageSpacing, PreserveSpacingInPageView);
                sizeF = new SizeF(0f, 0f);
                foreach (PrintPage item4 in visiblePages)
                {
                    sizeF.Height = sizeF.Height + (float)PageSpacing + (float)item4.ClientBounds.Height;
                    if (sizeF.Width < (float)item4.ClientBounds.Width)
                    {
                        sizeF.Width = item4.ClientBounds.Width;
                    }
                }
                sizeF.Width += PageSpacing * 2;
                sizeF.Height += PageSpacing;
                int width = base.ClientSize.Width;
                int num4 = 0;
                num4 = ((!((float)width <= sizeF.Width)) ? ((int)(((float)width - sizeF.Width) / 2f)) : 0);
                gClass2.OffsetSource(num4, 0, bool_0: false);
                RefreshScaleTransform();
                int num5 = 0;
                num5 = ((!AutoZoom) ? (PageSpacing + PreserveSpacingInPageView) : PreserveSpacingInPageView);
                foreach (PrintPage item5 in visiblePages)
                {
                    if (item5.ClientBounds.Top > 0 && num5 != item5.ClientBounds.Top)
                    {
                        num5 = item5.ClientBounds.Top;
                    }
                    item5.ClientBounds = new Rectangle(num4 + item5.ClientLeftFix, num5, item5.ClientBounds.Width, item5.ClientBounds.Height);
                    num5 = num5 + item5.ClientBounds.Height + PageSpacing;
                }
                if (AutoZoom)
                {
                    sizeF.Width = 0f;
                    num5 -= PageSpacing;
                }
                method_7(new Size((int)sizeF.Width, num5));
                if (UpdateCurrentPage())
                {
                    OnCurrentPageChanged();
                }
            }
        }

        public override void vmethod_19(Rectangle rectangle_2)
        {
            rectangle_2 = vmethod_18(rectangle_2);
            if (!rectangle_2.IsEmpty)
            {
                MultiPageTransform gClass = myTransform as MultiPageTransform;
                if (gClass == null)
                {
                    base.vmethod_19(rectangle_2);
                }
                else
                {
                    foreach (SimpleRectangleTransform item in gClass)
                    {
                        Rectangle rectangle_3 = Rectangle.Intersect(item.method_27(), rectangle_2);
                        if (!rectangle_3.IsEmpty)
                        {
                            rectangle_3 = item.vmethod_21(rectangle_3);
                            Invalidate(rectangle_3);
                        }
                    }
                }
            }
        }

        public void method_40()
        {
            MoveToPage(0);
        }

        public void method_41()
        {
            if (printPage_0 == null)
            {
                MoveToPage(StartPageIndex);
            }
            else
            {
                MoveToPage(Pages.IndexOf(printPage_0) + 1);
            }
        }

        public void method_42()
        {
            if (printPage_0 == null)
            {
                MoveToPage(StartPageIndex);
            }
            else
            {
                MoveToPage(Pages.IndexOf(printPage_0) - 1);
            }
        }

        public void method_43()
        {
            if (printPageCollection_0 != null)
            {
                MoveToPage(Pages.Count - 1);
            }
        }

        public bool MoveToPage(int int_6)
        {
            if (StartPageIndex >= 0 && int_6 < StartPageIndex)
            {
                int_6 = StartPageIndex;
            }
            if (EndPageIndex >= 0 && int_6 > EndPageIndex)
            {
                int_6 = EndPageIndex;
            }
            if (Pages != null && int_6 >= 0 && int_6 < Pages.Count)
            {
                PrintPage printPage = Pages[int_6];
                SetAutoScrollPosition(new Point(0, printPage.ClientBounds.Top));
                printPage_0 = printPage;
                Invalidate();
                return true;
            }
            return false;
        }

        protected override void OnXScroll()
        {
            if (Pages != null && RuntimeViewMode == PageViewMode.Page)
            {
                RefreshScaleTransform();
                PrintPage printPage_ = printPage_0;
                if (UpdateCurrentPage())
                {
                    using (Graphics graphics_ = CreateGraphics())
                    {
                        DrawPageFrame(printPage_, graphics_, Rectangle.Empty, bool_16: false);
                        DrawPageFrame(CurrentPage, graphics_, Rectangle.Empty, bool_16: false);
                    }
                    OnCurrentPageChanged();

                }
            }
            base.OnXScroll();
        }



        protected virtual void DrawPageFrame(PrintPage printPage_1, Graphics graphics_0, Rectangle rectangle_2, bool bool_16)
        {
            if (printPage_1 == null || !printPageCollection_0.Contains(printPage_1))
            {
                return;
            }
            Rectangle clientBounds = printPage_1.ClientBounds;
            clientBounds.Offset(base.AutoScrollPosition);
            PageFrameDrawer gClass = new PageFrameDrawer();
            gClass.method_35(1);
            gClass.method_9(clientBounds);
            Rectangle rectangle = Rectangle.Empty;
            foreach (SimpleRectangleTransform item in PagesTransform)
            {
                if (item.method_8() == printPage_1 && (item.method_0() == PageContentPartyStyle.HeaderRows || item.method_0() == PageContentPartyStyle.Body))
                {
                    rectangle = ((!rectangle.IsEmpty) ? Rectangle.Union(item.method_23(), rectangle) : item.method_23());
                }
            }
            gClass.method_11(rectangle);
            gClass.method_21(printPage_1.ClientMargins);
            if (printPage_1 == CurrentPage)
            {
                if (base.Enabled)
                {
                    gClass.method_33(CurrentPageBorderColor);
                    gClass.method_35(1);
                }
                else
                {
                    gClass.method_33(Color.LightGray);
                    gClass.method_35(1);
                }
            }
            else
            {
                gClass.method_35(1);
                gClass.method_33(PageBorderColor);
            }
            gClass.method_29(bool_16);
            gClass.method_31(PageBackColor);
            if (printPage_1.PageSettings.RuntimeEditTimeBackgroundImage != null && printPage_1.PageSettings.RuntimeEditTimeBackgroundImage.Value != null && bool_16)
            {
                gClass.method_39(printPage_1.PageSettings.RuntimeEditTimeBackgroundImage.Value);
            }
            if (bool_16)
            {
                gClass.method_7(printPage_1.PageSettings.RuntimeWatermark);
            }
            gClass.method_41(CommentSettings);
            gClass.method_37(PageContentBorderStyle);
            if (graphics_0.PageUnit != GraphicsUnit && gClass.method_36() != null)
            {
                gClass.method_37((PageBorderBackgroundStyle)gClass.method_36().Clone());
                gClass.method_36().BorderWidth = GraphicsUnitConvert.Convert(gClass.method_36().BorderWidth, GraphicsUnit, graphics_0.PageUnit);
            }
            gClass.method_23(PageMarginLineLength);
            gClass.method_1(RuntimeDesignMode);
            gClass.method_3(base.XZoomRate);
            gClass.DrawPageFrame(graphics_0, rectangle_2);
        }

        protected Rectangle GetViewClipRectangle(Rectangle rectangle_2)
        {
            double clientToViewXRate = base.ClientToViewXRate;
            double clientToViewYRate = base.ClientToViewYRate;
            rectangle_2.X = (int)((double)rectangle_2.X * clientToViewXRate);
            rectangle_2.Y = (int)((double)rectangle_2.Y * clientToViewYRate);
            rectangle_2.Width = (int)((double)rectangle_2.Width * clientToViewXRate);
            rectangle_2.Height = (int)((double)rectangle_2.Height * clientToViewYRate);
            return rectangle_2;
        }

        protected int GetJumpPrintPosition(int int_6, int int_7)
        {
            MultiPageTransform gClass = (MultiPageTransform)myTransform;
            if (gClass.ContainsSourcePoint(int_6, int_7))
            {
                int y = myTransform.TransformPoint(int_6, int_7).Y;
                if (y >= 0)
                {
                    return y;
                }
            }
            return 0;
        }

        public SimpleRectangleTransform method_48(float float_2, float float_3)
        {
            MultiPageTransform gClass = (MultiPageTransform)myTransform;
            foreach (SimpleRectangleTransform item in gClass)
            {
                if (item.method_25().Contains(float_2, float_3))
                {
                    return item;
                }
            }
            return null;
        }

        public SimpleRectangleTransform method_49(float float_2)
        {
            MultiPageTransform gClass = (MultiPageTransform)myTransform;
            foreach (SimpleRectangleTransform item in gClass)
            {
                if (item.method_25().Top >= float_2 && item.method_25().Bottom >= float_2)
                {
                    return item;
                }
            }
            return null;
        }

        protected void method_50(Graphics graphics_0, Rectangle rectangle_2, JumpPrintInfo jumpPrintInfo_0, Color color_3)
        {
            int num = 14;
            if (!(jumpPrintInfo_0?.Enabled ?? false) || (jumpPrintInfo_0.PageIndex < 0 && jumpPrintInfo_0.EndPageIndex < 0))
            {
                return;
            }
            MultiPageTransform gClass = (MultiPageTransform)myTransform;
            PrintPage printPage = null;
            float num2 = -2.14748365E+09f;
            float num3 = -2.14748365E+09f;
            foreach (SimpleRectangleTransform item in gClass)
            {
                if (item.method_0() == PageContentPartyStyle.Body)
                {
                    if ((jumpPrintInfo_0.PageIndex != 0 || jumpPrintInfo_0.Position != 0f) && jumpPrintInfo_0.PageIndex >= 0 && item.method_8() == Pages.SafeGet(jumpPrintInfo_0.PageIndex))
                    {
                        num2 = item.UnTransformPointF(0f, jumpPrintInfo_0.Position + (float)(int)item.method_25().Top).Y;
                        printPage = Pages.SafeGet(jumpPrintInfo_0.PageIndex);
                        if (Math.Abs(jumpPrintInfo_0.Position) < 1f && jumpPrintInfo_0.PageIndex > 0)
                        {
                            PrintPage printPage2 = Pages[jumpPrintInfo_0.PageIndex - 1];
                            num2 = (printPage2.ClientBounds.Bottom + Pages[jumpPrintInfo_0.PageIndex].ClientBounds.Top) / 2 + base.AutoScrollPosition.Y;
                        }
                    }
                    if ((jumpPrintInfo_0.EndPageIndex != 0 || jumpPrintInfo_0.EndPosition != 0f) && jumpPrintInfo_0.EndPageIndex >= 0 && item.method_8() == Pages.SafeGet(jumpPrintInfo_0.EndPageIndex))
                    {
                        num3 = item.UnTransformPointF(0f, jumpPrintInfo_0.EndPosition + (float)(int)item.method_25().Top).Y;
                        Pages.SafeGet(jumpPrintInfo_0.EndPageIndex);
                        if (jumpPrintInfo_0.EndPosition < 1f && jumpPrintInfo_0.EndPageIndex > 0)
                        {
                            PrintPage printPage2 = Pages[jumpPrintInfo_0.EndPageIndex - 1];
                            num3 = (printPage2.ClientBounds.Bottom + Pages[jumpPrintInfo_0.EndPageIndex].ClientBounds.Top) / 2 + base.AutoScrollPosition.Y;
                        }
                    }
                    if (num2 != -2.14748365E+09f && num3 != -2.14748365E+09f)
                    {
                        break;
                    }
                }
            }
            RectangleF rectangleF;
            if (num2 >= 0f)
            {
                rectangleF = new RectangleF(0f, 0f, base.ClientSize.Width, num2);
                RectangleF b = rectangle_2;
                b = ((!rectangle_2.IsEmpty) ? RectangleF.Intersect(rectangleF, b) : rectangleF);
                if (!b.IsEmpty)
                {
                    graphics_0.ResetClip();
                    graphics_0.PageUnit = GraphicsUnit.Pixel;
                    graphics_0.ResetTransform();
                    using (SolidBrush brush = new SolidBrush(color_3))
                    {
                        graphics_0.FillRectangle(brush, b);
                    }
                    using (Pen pen = new Pen(Color.Blue, 2f))
                    {
                        graphics_0.DrawLine(pen, 0f, rectangleF.Bottom - 1f, base.ClientSize.Width, rectangleF.Bottom - 1f);
                    }
                    if (jumpPrintInfo_0.Mode == JumpPrintMode.Offset)
                    {
                        Rectangle clientBounds = printPage.ClientBounds;
                        clientBounds.Offset(base.AutoScrollPosition.X, base.AutoScrollPosition.Y);
                        float num4 = (float)GraphicsUnitConvert.Convert(10.0, GraphicsUnit.Millimeter, GraphicsUnit.Pixel);
                        int num5 = clientBounds.Left + (int)Math.Min(num4, (double)clientBounds.Width * 0.3);
                        graphics_0.DrawLine(Pens.Red, num5, clientBounds.Top, num5, num2 - 1f);
                        Font defaultFont = Control.DefaultFont;
                        float height = defaultFont.GetHeight(graphics_0);
                        for (int i = 0; i < 1000; i++)
                        {
                            float num6 = (float)clientBounds.Top + (float)i * num4;
                            if (num6 > num2)
                            {
                                break;
                            }
                            graphics_0.DrawLine(Pens.Red, num5, num6, (float)num5 + num4, num6);
                            float num7 = (0f - height) / 2f;
                            if (i == 0)
                            {
                                num7 = 0f;
                            }
                            graphics_0.DrawString(i + "CM", defaultFont, Brushes.Red, (float)num5 + num4, num6 + num7);
                        }
                    }
                }
            }
            if (num3 != -2.14748365E+09f && num3 < (float)base.ClientSize.Height)
            {
                rectangleF = new RectangleF(0f, num3, base.ClientSize.Width, (float)base.ClientSize.Height - num3);
                RectangleF b = rectangle_2;
                b = ((!rectangle_2.IsEmpty) ? RectangleF.Intersect(rectangleF, b) : rectangleF);
                if (!b.IsEmpty)
                {
                    graphics_0.ResetClip();
                    graphics_0.PageUnit = GraphicsUnit.Pixel;
                    graphics_0.ResetTransform();
                    using (SolidBrush brush = new SolidBrush(color_3))
                    {
                        graphics_0.FillRectangle(brush, b);
                    }
                    using (Pen pen = new Pen(Color.Blue, 2f))
                    {
                        graphics_0.DrawLine(pen, 0f, rectangleF.Top, base.ClientSize.Width, rectangleF.Top);
                    }
                }
            }
        }

        protected void method_51(PaintEventArgs paintEventArgs_0)
        {
            if (Pages != null && Pages.Count > 0 && (RuntimeViewMode == PageViewMode.Normal || RuntimeViewMode == PageViewMode.NormalCenter))
            {
                using (Pen pen = new Pen(Color.Black))
                {
                    pen.DashStyle = DashStyle.Dot;
                    foreach (PrintPage page in Pages)
                    {
                        int num = page.ClientBounds.Bottom + base.AutoScrollPosition.Y;
                        if (num >= paintEventArgs_0.ClipRectangle.Top && num <= paintEventArgs_0.ClipRectangle.Bottom)
                        {
                            paintEventArgs_0.Graphics.DrawLine(pen, 0, num, base.ClientSize.Width, num);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///       已重载:绘制文档内容
        ///       </summary>
        /// <param name="e">绘制事件参数</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (!base.DesignMode && !base.IsUpdating)
            {
                method_52(pevent, bool_16: false);
            }
        }

        protected void method_52(PaintEventArgs paintEventArgs_0, bool bool_16)
        {
            Rectangle clipRectangle = paintEventArgs_0.ClipRectangle;
            clipRectangle.Height++;
            Point autoScrollPosition = base.AutoScrollPosition;
            RefreshScaleTransform();
            if (PagesTransform == null || PagesTransform.Count == 0)
            {
                return;
            }
            if (RuntimeViewMode == PageViewMode.Normal || RuntimeViewMode == PageViewMode.NormalCenter || RuntimeViewMode == PageViewMode.AutoLine)
            {
                SimpleRectangleTransform gClass = PagesTransform.method_7(0);
                PrintPage printPage = (PrintPage)gClass.method_8();
                XPageSettings pageSettings = printPage.PageSettings;
                if (pageSettings.RuntimeEditTimeBackgroundImage != null && pageSettings.RuntimeEditTimeBackgroundImage.Value != null)
                {
                    using (TextureBrush textureBrush = new TextureBrush(pageSettings.RuntimeEditTimeBackgroundImage.Value))
                    {
                        textureBrush.WrapMode = WrapMode.Tile;
                        _ = (float)GraphicsUnitConvert.GetRate(paintEventArgs_0.Graphics.PageUnit, GraphicsUnit.Pixel);
                        textureBrush.TranslateTransform(base.AutoScrollPosition.X, base.AutoScrollPosition.Y);
                        paintEventArgs_0.Graphics.FillRectangle(textureBrush, paintEventArgs_0.ClipRectangle);
                    }
                }
                else if (PageBackColor.A != 0)
                {
                    using (SolidBrush brush = new SolidBrush(PageBackColor))
                    {
                        paintEventArgs_0.Graphics.FillRectangle(brush, paintEventArgs_0.ClipRectangle);
                    }
                }
                Rectangle b = gClass.method_21();
                b.Width += 30;
                if (Rectangle.Intersect(clipRectangle, b).IsEmpty)
                {
                    return;
                }
                GraphicsState gstate = paintEventArgs_0.Graphics.Save();
                PaintEventArgs paintEventArgs = TransformPaint(paintEventArgs_0, gClass, bool_13: true);
                if (paintEventArgs != null)
                {
                    PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(paintEventArgs.Graphics, paintEventArgs.ClipRectangle, printPage.Document, null, gClass.method_0(), gClass);
                    pageDocumentPaintEventArgs.ContentBounds = gClass.method_27();
                    if (ReadViewMode)
                    {
                        pageDocumentPaintEventArgs.RenderMode = ContentRenderMode.ReadPaint;
                    }
                    else
                    {
                        pageDocumentPaintEventArgs.RenderMode = ContentRenderMode.UIPaint;
                    }
                    pageDocumentPaintEventArgs.NumberOfPages = Pages.Count;
                    pageDocumentPaintEventArgs.ViewMode = RuntimeViewMode;
                    vmethod_31(printPage.Document, pageDocumentPaintEventArgs, paintEventArgs_0);
                }
                paintEventArgs_0.Graphics.Restore(gstate);
            }
            else
            {
                MultiPageTransform gClass2 = (MultiPageTransform)base.Transform;
                _ = paintEventArgs_0.Graphics;
                foreach (PrintPage page in Pages)
                {
                    Rectangle clientBounds = page.ClientBounds;
                    clientBounds.Offset(autoScrollPosition);
                    clientBounds.Offset(-20, 0);
                    clientBounds.Width += 40;
                    if (clipRectangle.IntersectsWith(new Rectangle(clientBounds.Left, clientBounds.Top, clientBounds.Width + 5, clientBounds.Height + 5)))
                    {
                        DrawPageFrame(page, paintEventArgs_0.Graphics, clipRectangle, bool_16: true);
                        for (int num = gClass2.Count - 1; num >= 0; num--)
                        {
                            SimpleRectangleTransform gClass = gClass2.method_7(num);
                            if (gClass.getVisible() && gClass.method_8() == page)
                            {
                                //绘制页眉页脚编辑区域虚线框
                                if (gClass.method_0() != PageContentPartyStyle.Body)
                                {
                                }
                                if (gClass.method_0() == PageContentPartyStyle.Header && (HeaderFooterFlagVisible == HeaderFooterFlagVisible.Header || HeaderFooterFlagVisible == HeaderFooterFlagVisible.HeaderFooter))
                                {
                                    method_53(PrintingResources.Header, gClass.method_23(), paintEventArgs_0.Graphics, bool_16: false);
                                }
                                if (gClass.method_0() == PageContentPartyStyle.HeaderForFirstPage)
                                {
                                    if (HeaderFooterFlagVisible == HeaderFooterFlagVisible.Header || HeaderFooterFlagVisible == HeaderFooterFlagVisible.HeaderFooter)
                                    {
                                        method_53(PrintingResources.HeaderForFirstPage, gClass.method_23(), paintEventArgs_0.Graphics, bool_16: false);
                                    }
                                }
                                else if (gClass.method_0() == PageContentPartyStyle.Footer)
                                {
                                    if (HeaderFooterFlagVisible == HeaderFooterFlagVisible.Footer || HeaderFooterFlagVisible == HeaderFooterFlagVisible.HeaderFooter)
                                    {
                                        method_53(PrintingResources.Footer, gClass.method_23(), paintEventArgs_0.Graphics, bool_16: true);
                                    }
                                }
                                else if (gClass.method_0() == PageContentPartyStyle.FooterForFirstPage && (HeaderFooterFlagVisible == HeaderFooterFlagVisible.Footer || HeaderFooterFlagVisible == HeaderFooterFlagVisible.HeaderFooter))
                                {
                                    method_53(PrintingResources.FooterForFirstPage, gClass.method_23(), paintEventArgs_0.Graphics, bool_16: true);
                                }
                                Rectangle b = new Rectangle((int)gClass.getSourceRectF().Left, (int)Math.Floor(gClass.getSourceRectF().Top), (int)gClass.getSourceRectF().Width, 0);
                                b.Height = (int)Math.Ceiling(gClass.getSourceRectF().Bottom - (float)b.Top);
                                Rectangle.Ceiling(gClass.getSourceRectF());
                                if (bool_16 && gClass.method_0() == PageContentPartyStyle.Body && !gClass.method_23().IsEmpty)
                                {
                                    b = gClass.method_23();
                                }
                                b = Rectangle.Intersect(clipRectangle, b);
                                if (!b.IsEmpty)
                                {
                                }
                                if (!b.IsEmpty)
                                {
                                    GraphicsState gstate = paintEventArgs_0.Graphics.Save();
                                    PaintEventArgs paintEventArgs = TransformPaint(paintEventArgs_0, gClass, bool_13: true);
                                    if (paintEventArgs != null)
                                    {
                                        PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(paintEventArgs.Graphics, paintEventArgs.ClipRectangle, page.Document, page, gClass.method_0(), gClass);
                                        pageDocumentPaintEventArgs.ContentBounds = gClass.method_27();
                                        pageDocumentPaintEventArgs.PageClipRectangle = gClass.method_25();
                                        if (ReadViewMode)
                                        {
                                            pageDocumentPaintEventArgs.RenderMode = ContentRenderMode.ReadPaint;
                                        }
                                        else
                                        {
                                            pageDocumentPaintEventArgs.RenderMode = ContentRenderMode.UIPaint;
                                        }
                                        pageDocumentPaintEventArgs.PageIndex = page.PageIndex;
                                        pageDocumentPaintEventArgs.NumberOfPages = Pages.Count;
                                        pageDocumentPaintEventArgs.ViewMode = RuntimeViewMode;
                                        if (page.Document != null)
                                        {
                                            vmethod_31(page.Document, pageDocumentPaintEventArgs, paintEventArgs_0);
                                        }
                                    }
                                    paintEventArgs_0.Graphics.Restore(gstate);
                                    vmethod_30(paintEventArgs_0, gClass);
                                }
                            }
                        }
                    }
                }
                method_45();
            }
        }

        protected virtual void vmethod_30(PaintEventArgs paintEventArgs_0, SimpleRectangleTransform gclass435_1)
        {
            if (!gclass435_1.getEnable() && gclass435_1.method_4())
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(140, PageBackColor)))
                {
                    Rectangle rectangle = gclass435_1.method_21();
                    paintEventArgs_0.Graphics.FillRectangle(brush, rectangle.Left, rectangle.Top, rectangle.Width + 2, rectangle.Height + 2);
                }
            }
        }

        protected virtual void vmethod_31(IPageDocument ipageDocument_0, PageDocumentPaintEventArgs pageDocumentPaintEventArgs_0, PaintEventArgs paintEventArgs_0)
        {
            ipageDocument_0?.DrawContent(pageDocumentPaintEventArgs_0);
        }

        private void method_53(string string_0, Rectangle rectangle_2, Graphics graphics_0, bool bool_16)
        {
            if (font_0 == null)
            {
                font_0 = new Font(Control.DefaultFont.Name, 10f);
            }
            SizeF sizeF = graphics_0.MeasureString(string_0, font_0);
            Size size = new Size((int)sizeF.Width + 10, (int)sizeF.Height + 10);
            using (Pen pen = new Pen(Color.FromArgb(155, 187, 227)))
            {
                pen.DashStyle = DashStyle.Dash;
                graphics_0.DrawRectangle(pen, rectangle_2);
            }
            Rectangle empty = Rectangle.Empty;
            method_54(rectangle_2: bool_16 ? new Rectangle(rectangle_2.Left + 10, rectangle_2.Top - size.Height, size.Width, size.Height) : new Rectangle(rectangle_2.Left + 10, rectangle_2.Bottom, size.Width, size.Height), graphics_0: graphics_0, font_1: font_0, string_0: string_0, color_3: Color.FromArgb(21, 66, 139), color_4: Color.FromArgb(216, 232, 245), color_5: Color.FromArgb(155, 187, 227));
        }

        private void method_54(Graphics graphics_0, Font font_1, string string_0, Color color_3, Color color_4, Color color_5, Rectangle rectangle_2)
        {
            using (SolidBrush brush = new SolidBrush(color_4))
            {
                graphics_0.FillRectangle(brush, rectangle_2);
            }
            if (string_0 != null && string_0.Length > 0)
            {
                using (StringFormat stringFormat = new StringFormat())
                {
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                    using (SolidBrush brush = new SolidBrush(color_3))
                    {
                        graphics_0.DrawString(string_0, font_1, brush, new RectangleF(rectangle_2.Left, rectangle_2.Top, rectangle_2.Width, rectangle_2.Height), stringFormat);
                    }
                }
            }
            using (Pen pen = new Pen(color_5))
            {
                graphics_0.DrawRectangle(pen, rectangle_2);
            }
        }

        /// <summary>
        ///       控件大小发生改变时的处理
        ///       </summary>
        /// <param name="e">事件参数</param>
        protected override void OnResize(EventArgs eventArgs_0)
        {
            if (!base.DesignMode && base.IsHandleCreated)
            {
                UpdatePages();
            }
            base.OnResize(eventArgs_0);
        }

        protected void method_55(EventArgs eventArgs_0)
        {
            base.OnResize(eventArgs_0);
        }

        protected virtual void vmethod_32(int int_6)
        {
        }

        protected override void Dispose(bool disposing)
        {
            eventHandler_1 = null;
            base.Dispose(disposing);
        }
    }
}
