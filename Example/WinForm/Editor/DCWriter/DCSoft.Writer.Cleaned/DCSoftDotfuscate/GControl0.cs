using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms.Native;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Undo;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
    [ComVisible(false)]
    [DCInternal]
    [ToolboxItem(false)]
    public class DCRulerControl : Control
    {
        public const int int_0 = 24;

        public const int int_1 = 12;

        public const string string_0 = "155, 187, 227";

        private static Bitmap bitmap_0 = null;

        private static Bitmap bitmap_1 = null;

        private XTextParagraphFlagElement xtextParagraphFlagElement_0 = null;

        private ToolTip toolTip_0 = null;

        private WriterControl writerControl_0 = null;

        private ScrollEventHandler scrollEventHandler_0 = null;

        private EventHandler eventHandler_0 = null;

        private XPageSettings xpageSettings_0 = null;

        private GEnum8 genum8_0 = GEnum8.H;

        public static readonly Color color_0 = Color.FromArgb(155, 187, 227);

        public static readonly Color color_1 = Color.FromArgb(177, 202, 235);

        public static readonly Color color_2 = Color.FromArgb(213, 226, 243);

        public static readonly Color color_3 = Color.FromArgb(90, 97, 108);

        public static readonly Color color_4 = Color.FromArgb(128, 128, 128);

        private Rectangle rectangle_0 = Rectangle.Empty;

        private RectangleF rectangleF_0 = Rectangle.Empty;

        private RectangleF rectangleF_1 = RectangleF.Empty;

        private Rectangle rectangle_1 = Rectangle.Empty;

        private PrintPage printPage_0 = null;

        private bool bool_0 = false;

        private Rectangle rectangle_2 = Rectangle.Empty;

        private Rectangle rectangle_3 = Rectangle.Empty;

        private Rectangle rectangle_4 = Rectangle.Empty;

        private Rectangle rectangle_5 = Rectangle.Empty;

        private Rectangle rectangle_6 = Rectangle.Empty;

        protected override bool DoubleBuffered
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public DCRulerControl()
        {
            SetStyle(ControlStyles.Selectable, value: false);
            BackColor = Color.FromArgb(155, 187, 227);
            scrollEventHandler_0 = method_7;
            eventHandler_0 = method_6;
            SetStyle(ControlStyles.Selectable, value: false);
            if (bitmap_1 == null)
            {
                bitmap_1 = WriterResourcesCore.RuleDownButton;
                bitmap_1.MakeTransparent(Color.Red);
                bitmap_0 = WriterResourcesCore.RuleUpButton;
                bitmap_0.MakeTransparent(Color.Red);
            }
        }

        internal XTextParagraphFlagElement method_0()
        {
            return xtextParagraphFlagElement_0;
        }

        internal void method_1(XTextParagraphFlagElement xtextParagraphFlagElement_1)
        {
            if (xtextParagraphFlagElement_0 != xtextParagraphFlagElement_1)
            {
                xtextParagraphFlagElement_0 = xtextParagraphFlagElement_1;
                if (base.IsHandleCreated && base.Visible)
                {
                    Invalidate();
                }
            }
        }

        private void method_2(string string_1)
        {
            if (toolTip_0 == null)
            {
                toolTip_0 = new ToolTip();
            }
            if (toolTip_0.GetToolTip(this) != string_1)
            {
                toolTip_0.SetToolTip(this, string_1);
            }
        }

        internal void method_3(WriterControl writerControl_1)
        {
            int num = 15;
            if (writerControl_1 == null)
            {
                throw new ArgumentNullException("ctl");
            }
            writerControl_0 = writerControl_1;
            writerControl_0.InnerViewControl.Scroll += scrollEventHandler_0;
            writerControl_0.InnerViewControl.CurrentPageChanged += eventHandler_0;
        }

        protected override void Dispose(bool disposing)
        {
            if (writerControl_0 != null)
            {
                if (writerControl_0.InnerViewControl != null)
                {
                    writerControl_0.InnerViewControl.Scroll -= scrollEventHandler_0;
                    writerControl_0.InnerViewControl.CurrentPageChanged -= eventHandler_0;
                }
                writerControl_0 = null;
            }
            if (toolTip_0 != null)
            {
                toolTip_0.Dispose();
                toolTip_0 = null;
            }
            base.Dispose(disposing);
        }

        private bool method_4()
        {
            if (writerControl_0 == null)
            {
                return true;
            }
            if (writerControl_0.FormView == FormViewMode.Normal || writerControl_0.FormView == FormViewMode.Strict)
            {
                return true;
            }
            return writerControl_0.Readonly;
        }

        private bool method_5()
        {
            if (method_0() == null)
            {
                return true;
            }
            return !writerControl_0.Document.DocumentControler.CanModifyParagraphs;
        }

        private void method_6(object sender, EventArgs e)
        {
            method_16(bool_1: false);
        }

        private void method_7(object sender, ScrollEventArgs e)
        {
            method_16(bool_1: true);
        }

        public WriterControl method_8()
        {
            return writerControl_0;
        }

        private float method_9()
        {
            if (writerControl_0 != null && writerControl_0.InnerViewControl != null)
            {
                return writerControl_0.InnerViewControl.XZoomRate;
            }
            return 1f;
        }

        private float method_10()
        {
            if (writerControl_0 != null && writerControl_0.InnerViewControl != null)
            {
                return writerControl_0.InnerViewControl.YZoomRate;
            }
            return 1f;
        }

        private XPageSettings method_11()
        {
            return xpageSettings_0;
        }

        private void method_12(XPageSettings xpageSettings_1)
        {
            xpageSettings_0 = xpageSettings_1;
        }

        public GEnum8 method_13()
        {
            return genum8_0;
        }

        public void method_14(GEnum8 genum8_1)
        {
            genum8_0 = genum8_1;
        }

        public void method_15()
        {
            printPage_0 = null;
            xtextParagraphFlagElement_0 = null;
            xpageSettings_0 = null;
        }

        internal void method_16(bool bool_1)
        {
            if (method_8() == null || method_8().InnerViewControl == null || base.IsDisposed || !base.IsHandleCreated)
            {
                return;
            }
            method_12(null);
            _ = (float)(GraphicsUnitConvert.GetRate(GraphicsUnit.Pixel, GraphicsUnit.Inch) * 100.0);
            printPage_0 = method_8().CurrentPage;
            if (printPage_0 == null)
            {
                printPage_0 = method_8().Pages.FirstPage;
            }
            if (printPage_0 == null)
            {
                return;
            }
            method_12(printPage_0.PageSettings);
            if (method_13() == GEnum8.H)
            {
                Rectangle clientBounds = printPage_0.ClientBounds;
                clientBounds.Width = (int)(GraphicsUnitConvert.Convert(method_11().ViewPaperWidth, method_11().ViewUnit, GraphicsUnit.Pixel) * method_9());
                clientBounds.X += writerControl_0.InnerViewControl.AutoScrollPosition.X;
                Point point = method_17(new Point(0, 0));
                clientBounds.X += point.X;
                Rectangle rectangle = rectangle_0 = new Rectangle(clientBounds.Left, (base.Height - 24) / 2, clientBounds.Width, 24);
                rectangle_1 = new Rectangle(0, 0, base.Width, base.Height);
                point = method_17(new Point(0, 0));
                if (rectangle_1.X < point.X)
                {
                    rectangle_1.Width = rectangle_1.Right - point.X;
                    rectangle_1.X = point.X;
                }
                point = method_17(new Point(writerControl_0.InnerViewControl.Width, 0));
                if (rectangle_1.Right > point.X)
                {
                    rectangle_1.Width = point.X - rectangle_1.X;
                }
                Invalidate();
            }
            else if (method_13() == GEnum8.V)
            {
                Rectangle clientBounds = printPage_0.ClientBounds;
                clientBounds.Y += writerControl_0.InnerViewControl.AutoScrollPosition.Y;
                Point point = method_17(new Point(0, 0));
                clientBounds.Y += point.Y;
                Rectangle rectangle = rectangle_0 = new Rectangle((base.Width - 24) / 2, clientBounds.Top, 24, clientBounds.Height);
                rectangle_1 = new Rectangle(0, 0, base.Width, base.Height);
                point = method_17(new Point(0, 0));
                if (rectangle_1.Y < point.Y)
                {
                    rectangle_1.Height = rectangle_1.Bottom - point.Y;
                    rectangle_1.Y = point.Y;
                }
                point = method_17(new Point(0, writerControl_0.InnerViewControl.Height));
                if (rectangle_1.Bottom > point.Y)
                {
                    rectangle_1.Height = point.X - rectangle_1.Top;
                }
                if (base.ClientRectangle.IntersectsWith(rectangle_0) || bool_0)
                {
                    Invalidate();
                }
            }
        }

        private Point method_17(Point point_0)
        {
            point_0 = writerControl_0.InnerViewControl.PointToScreen(point_0);
            point_0 = PointToClient(point_0);
            return point_0;
        }

        protected override void OnVisibleChanged(EventArgs eventArgs_0)
        {
            base.OnVisibleChanged(eventArgs_0);
            method_16(bool_1: false);
        }

        protected override void OnResize(EventArgs eventArgs_0)
        {
            base.OnResize(eventArgs_0);
            method_16(bool_1: false);
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            method_18(mevent, GEnum66.const_1);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            method_18(mevent, GEnum66.const_0);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs mouseEventArgs_0)
        {
            int num = 1;
            base.OnMouseDoubleClick(mouseEventArgs_0);
            if (!method_4())
            {
                writerControl_0.ExecuteCommand("FilePageSettings", showUI: true, null);
            }
        }

        private void method_18(MouseEventArgs mouseEventArgs_0, GEnum66 genum66_0)
        {
            int num = 15;
            if (method_8() == null || method_8().InnerViewControl == null)
            {
                return;
            }
            Cursor cursor = Cursors.Arrow;
            string string_ = null;
            if (!rectangle_1.Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y))
            {
                method_2(null);
            }
            else
            {
                if (method_11() == null)
                {
                    return;
                }
                XTextDocument document = writerControl_0.Document;
                if (method_13() == GEnum8.H)
                {
                    int num2 = (int)GraphicsUnitConvert.Convert(200.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
                    if (!rectangle_3.IsEmpty && rectangle_3.Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y))
                    {
                        if (method_5())
                        {
                            method_2(null);
                            return;
                        }
                        string_ = WriterStringsCore.ParagraphFirstLineIndent;
                        if (genum66_0 == GEnum66.const_0 && mouseEventArgs_0.Button == MouseButtons.Left)
                        {
                            rectangle_6 = new Rectangle(rectangle_2.Left, 1, rectangle_2.Width - num2, 1);
                            Point[] array = method_19();
                            if (array != null)
                            {
                                DocumentContentStyle documentContentStyle = method_0().RuntimeStyle.CloneParent();
                                int num3 = (int)(GraphicsUnitConvert.Convert((float)(array[1].X - rectangle_2.Left) / method_9(), GraphicsUnit.Pixel, document.DocumentGraphicsUnit) - documentContentStyle.LeftIndent);
                                documentContentStyle.DisableDefaultValue = true;
                                if (documentContentStyle.FirstLineIndent != (float)num3)
                                {
                                    XTextContentElement contentElement = method_0().ContentElement;
                                    RectangleF absClientBounds = contentElement.AbsClientBounds;
                                    if ((float)num3 >= 0f - documentContentStyle.LeftIndent && (double)num3 < (double)absClientBounds.Width * 0.8)
                                    {
                                        documentContentStyle.FirstLineIndent = num3;
                                        document.BeginLogUndo();
                                        XTextElementList xTextElementList = document.Selection.SetParagraphStyle(documentContentStyle);
                                        if (xTextElementList != null && xTextElementList.Count > 0)
                                        {
                                            document.EndLogUndo();
                                            document.Modified = true;
                                            document.OnSelectionChanged();
                                            document.OnDocumentContentChanged();
                                            Invalidate();
                                            document.EditorControl.CommandControler.UpdateBindingControlStatus();
                                        }
                                        else
                                        {
                                            document.EndLogUndo();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (!rectangle_4.IsEmpty && rectangle_4.Contains(mouseEventArgs_0.X, mouseEventArgs_0.Y))
                    {
                        if (method_5())
                        {
                            method_2(null);
                            return;
                        }
                        string_ = WriterStringsCore.ParagraphLeftIndent;
                        if (genum66_0 == GEnum66.const_0 && mouseEventArgs_0.Button == MouseButtons.Left)
                        {
                            rectangle_6 = new Rectangle(rectangle_2.Left, 1, rectangle_2.Width - num2, 1);
                            Point[] array = method_19();
                            if (array != null)
                            {
                                int num4 = (int)GraphicsUnitConvert.Convert((float)(array[1].X - rectangle_2.Left) / method_9(), GraphicsUnit.Pixel, document.DocumentGraphicsUnit);
                                if (num4 < 0)
                                {
                                    num4 = 0;
                                }
                                DocumentContentStyle documentContentStyle = method_0().RuntimeStyle.CloneParent();
                                documentContentStyle.DisableDefaultValue = true;
                                if (documentContentStyle.LeftIndent != (float)num4)
                                {
                                    XTextContentElement contentElement = method_0().ContentElement;
                                    RectangleF absClientBounds = contentElement.AbsClientBounds;
                                    if (num4 >= 0 && (double)num4 < (double)absClientBounds.Width * 0.8)
                                    {
                                        documentContentStyle.LeftIndent = num4;
                                        documentContentStyle.FirstLineIndent = Math.Max(documentContentStyle.FirstLineIndent, 0f - documentContentStyle.LeftIndent);
                                        document.BeginLogUndo();
                                        XTextElementList xTextElementList = document.Selection.SetParagraphStyle(documentContentStyle);
                                        if (xTextElementList != null && xTextElementList.Count > 0)
                                        {
                                            document.EndLogUndo();
                                            document.Modified = true;
                                            document.OnSelectionChanged();
                                            document.OnDocumentContentChanged();
                                            Invalidate();
                                            document.EditorControl.CommandControler.UpdateBindingControlStatus();
                                        }
                                        else
                                        {
                                            document.EndLogUndo();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if ((float)mouseEventArgs_0.Y >= rectangleF_0.Top && (float)mouseEventArgs_0.Y <= rectangleF_0.Bottom)
                    {
                        if (method_4())
                        {
                            method_2(null);
                            return;
                        }
                        int num5 = method_11().Landscape ? method_11().PaperHeight : method_11().PaperWidth;
                        if (Math.Abs((float)mouseEventArgs_0.X - rectangleF_0.Left) < 2f)
                        {
                            cursor = Cursors.VSplit;
                            if (genum66_0 == GEnum66.const_1)
                            {
                                string_ = WriterStringsCore.PageLeftMargin;
                            }
                            else if (genum66_0 == GEnum66.const_0 && mouseEventArgs_0.Button == MouseButtons.Left)
                            {
                                int num6 = (int)GraphicsUnitConvert.Convert((double)method_11().RightMargin * 3.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
                                rectangle_6 = new Rectangle(rectangle_0.Left, 1, rectangle_0.Width - num6, 1);
                                Point[] array = method_19();
                                if (array != null)
                                {
                                    int num7 = (int)GraphicsUnitConvert.PixelToPrintUnit(((float)array[1].X - rectangleF_1.X) / method_9());
                                    bool flag = false;
                                    if (num7 > 0 && method_11().LeftMargin != num7 && (double)(num7 + method_11().RightMargin) < (double)num5 * 0.8)
                                    {
                                        flag = true;
                                    }
                                    if (flag)
                                    {
                                        if (document.BeginLogUndo())
                                        {
                                            document.UndoList.AddProperty("LeftMargin", method_11().LeftMargin, num7, method_11());
                                            document.UndoList.AddMethod(UndoMethodTypes.RefreshLayout);
                                            document.EndLogUndo();
                                        }
                                        method_11().LeftMargin = num7;
                                        writerControl_0.InnerViewControl.method_30();
                                        writerControl_0.RefreshDocumentExt(refreshSize: false, executeLayout: true);
                                        document.Modified = true;
                                        document.OnDocumentContentChanged();
                                        Invalidate();
                                    }
                                }
                            }
                        }
                        else if (Math.Abs((float)mouseEventArgs_0.X - rectangleF_0.Right) < 2f)
                        {
                            cursor = Cursors.VSplit;
                            if (genum66_0 == GEnum66.const_1)
                            {
                                string_ = WriterStringsCore.PageRightMargin;
                            }
                            else if (genum66_0 == GEnum66.const_0 && mouseEventArgs_0.Button == MouseButtons.Left)
                            {
                                int num6 = (int)GraphicsUnitConvert.Convert((double)method_11().LeftMargin * 3.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
                                rectangle_6 = new Rectangle(rectangle_0.Left + num6, 1, rectangle_0.Width - num6, 1);
                                Point[] array = method_19();
                                if (array != null)
                                {
                                    int num8 = (int)GraphicsUnitConvert.PixelToPrintUnit((rectangleF_1.Right - (float)array[1].X) / method_9());
                                    bool flag = false;
                                    if (num8 > 0 && method_11().RightMargin != num8 && (double)(num8 + method_11().LeftMargin) < (double)num5 * 0.8)
                                    {
                                        flag = true;
                                    }
                                    if (flag)
                                    {
                                        if (document.BeginLogUndo())
                                        {
                                            document.UndoList.AddProperty("RightMargin", method_11().RightMargin, num8, method_11());
                                            document.UndoList.AddMethod(UndoMethodTypes.RefreshLayout);
                                            document.EndLogUndo();
                                        }
                                        method_11().RightMargin = num8;
                                        writerControl_0.InnerViewControl.method_30();
                                        writerControl_0.RefreshDocumentExt(refreshSize: false, executeLayout: true);
                                        document.Modified = true;
                                        document.OnDocumentContentChanged();
                                        Invalidate();
                                    }
                                }
                            }
                        }
                    }
                }
                else if (method_13() == GEnum8.V)
                {
                    if (method_4())
                    {
                        method_2(null);
                        return;
                    }
                    float num9 = method_11().Landscape ? method_11().PaperWidth : method_11().PaperHeight;
                    if ((float)mouseEventArgs_0.X >= rectangleF_0.Left && (float)mouseEventArgs_0.X <= rectangleF_0.Right)
                    {
                        if (Math.Abs((float)mouseEventArgs_0.Y - rectangleF_0.Top) < 2f)
                        {
                            cursor = Cursors.HSplit;
                            if (genum66_0 == GEnum66.const_1)
                            {
                                string_ = WriterStringsCore.PageTopMargin;
                            }
                            else if (genum66_0 == GEnum66.const_0 && mouseEventArgs_0.Button == MouseButtons.Left)
                            {
                                int num6 = (int)GraphicsUnitConvert.Convert((double)method_11().BottomMargin * 3.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
                                rectangle_6 = new Rectangle(1, rectangle_0.Top, 1, rectangle_0.Height - num6);
                                Point[] array = method_19();
                                if (array != null)
                                {
                                    int num10 = (int)GraphicsUnitConvert.PixelToPrintUnit(((float)array[1].Y - rectangleF_1.Y) / method_10());
                                    bool flag = false;
                                    if (num10 > 0 && method_11().TopMargin != num10 && (double)(num10 + method_11().BottomMargin) < (double)num9 * 0.8)
                                    {
                                        flag = true;
                                    }
                                    if (flag)
                                    {
                                        if (document.BeginLogUndo())
                                        {
                                            document.UndoList.AddProperty("TopMargin", method_11().TopMargin, num10, method_11());
                                            document.UndoList.AddMethod(UndoMethodTypes.RefreshLayout);
                                            document.EndLogUndo();
                                        }
                                        method_11().TopMargin = num10;
                                        writerControl_0.InnerViewControl.method_30();
                                        writerControl_0.RefreshDocumentExt(refreshSize: false, executeLayout: true);
                                        document.Modified = true;
                                        document.OnDocumentContentChanged();
                                        Invalidate();
                                    }
                                }
                            }
                        }
                        else if (Math.Abs((float)mouseEventArgs_0.Y - rectangleF_0.Bottom) < 2f)
                        {
                            cursor = Cursors.HSplit;
                            if (genum66_0 == GEnum66.const_1)
                            {
                                string_ = WriterStringsCore.PageBottomMargin;
                            }
                            else if (genum66_0 == GEnum66.const_0 && mouseEventArgs_0.Button == MouseButtons.Left)
                            {
                                int num6 = (int)GraphicsUnitConvert.Convert((double)method_11().TopMargin * 3.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
                                rectangle_6 = new Rectangle(1, rectangle_0.Top + num6, 1, rectangle_0.Height - num6);
                                Point[] array = method_19();
                                if (array != null)
                                {
                                    int num11 = (int)GraphicsUnitConvert.PixelToPrintUnit((rectangleF_1.Bottom - (float)array[1].Y) / method_10());
                                    bool flag = false;
                                    if (num11 > 0 && method_11().BottomMargin != num11 && (double)(num11 + method_11().TopMargin) < (double)num9 * 0.8)
                                    {
                                        flag = true;
                                    }
                                    if (flag)
                                    {
                                        if (document.BeginLogUndo())
                                        {
                                            document.UndoList.AddProperty("BottomMargin", method_11().BottomMargin, num11, method_11());
                                            document.UndoList.AddMethod(UndoMethodTypes.RefreshLayout);
                                            document.EndLogUndo();
                                        }
                                        method_11().BottomMargin = num11;
                                        writerControl_0.InnerViewControl.method_30();
                                        writerControl_0.RefreshDocumentExt(refreshSize: false, executeLayout: true);
                                        document.Modified = true;
                                        document.OnDocumentContentChanged();
                                        Invalidate();
                                    }
                                }
                            }
                        }
                    }
                }
                if (Cursor != cursor)
                {
                    Cursor = cursor;
                }
                if (genum66_0 == GEnum66.const_1)
                {
                    method_2(string_);
                }
            }
        }

        private Point[] method_19()
        {
            Point[] array = null;
            MouseCapturer mouseCapturer = new MouseCapturer();
            mouseCapturer.BindControl = this;
            mouseCapturer.ReversibleShape = GEnum68.const_4;
            mouseCapturer.Draw += method_20;
            Cursor cursor = Cursor;
            if (!rectangle_6.IsEmpty)
            {
                Rectangle clip = rectangle_6;
                rectangle_6 = Rectangle.Empty;
                if (method_13() == GEnum8.H)
                {
                    clip.Location = PointToScreen(clip.Location);
                    clip.Y = 0;
                    clip.Height = Screen.GetWorkingArea(this).Height;
                    clip.X -= 3;
                    clip.Width += 6;
                }
                else if (method_13() == GEnum8.V)
                {
                    clip.Location = PointToScreen(clip.Location);
                    clip.X = 0;
                    clip.Width = Screen.GetWorkingArea(this).Width;
                    clip.Y -= 3;
                    clip.Height += 6;
                }
                Cursor.Clip = clip;
            }
            if (mouseCapturer.method_1())
            {
                Cursor = cursor;
                array = new Point[2]
                {
                    mouseCapturer.StartPosition,
                    mouseCapturer.EndPosition
                };
            }
            Cursor.Clip = Rectangle.Empty;
            if (array != null && array[0] != array[1] && writerControl_0.UIStartEditContent())
            {
                return array;
            }
            return null;
        }

        private void method_20(object sender, CaptureMouseMoveEventArgs e)
        {
            using (GClass249 gClass = GClass249.smethod_0(writerControl_0.InnerViewControl.Handle))
            {
                gClass.method_21(GEnum64.const_1);
                gClass.method_23(Color.Red);
                Point point_;
                Point p;
                if (method_13() == GEnum8.H)
                {
                    p = new Point(e.method_5().X, 0);
                    p = PointToScreen(p);
                    p = writerControl_0.InnerViewControl.PointToClient(p);
                    point_ = new Point(p.X, method_8().InnerViewControl.ClientSize.Height);
                    p.Y = 0;
                    point_.Y = writerControl_0.InnerViewControl.ClientSize.Height;
                    gClass.method_13(p, point_);
                }
                else if (method_13() == GEnum8.V)
                {
                    p = new Point(0, e.method_5().Y);
                    p = PointToScreen(p);
                    p = writerControl_0.InnerViewControl.PointToClient(p);
                    point_ = new Point(method_8().InnerViewControl.ClientSize.Width, p.Y);
                    p.X = 0;
                    point_.X = writerControl_0.InnerViewControl.ClientSize.Width;
                    gClass.method_13(p, point_);
                }
            }
        }

        #region  »­±ê³ßÇøÓò

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            bool_0 = false;
            if (method_13() == GEnum8.H)
            {
                method_21(pevent.Graphics, pevent.ClipRectangle);
            }
            else if (method_13() == GEnum8.V)
            {
                method_22(pevent.Graphics, pevent.ClipRectangle);
            }
        }




        private void method_21(Graphics graphics_0, Rectangle rectangle_7)
        {
            if (method_11() == null)
            {
                return;
            }
            bool_0 = true;
            float num = method_9();
            float num2 = (float)(GraphicsUnitConvert.GetRate(GraphicsUnit.Pixel, GraphicsUnit.Inch) / 100.0) * num;
            float num3 = GraphicsUnitConvert.Convert(10, GraphicsUnit.Millimeter, GraphicsUnit.Pixel);
            num3 *= num;
            rectangleF_1 = new RectangleF(rectangle_0.Left, rectangle_0.Top + 6, rectangle_0.Width, rectangle_0.Height - 12);
            float num4 = method_11().Landscape ? method_11().PaperHeight : method_11().PaperWidth;
            graphics_0.SetClip(rectangle_1);
            rectangleF_0.X = rectangleF_1.Left + (float)method_11().LeftMargin * num2;
            rectangleF_0.Y = rectangleF_1.Top + 1f;
            rectangleF_0.Width = (num4 - (float)method_11().LeftMargin - (float)method_11().RightMargin) * num2;
            rectangleF_0.Height = rectangleF_1.Height - 2f;
            Rectangle rect = new Rectangle((int)rectangleF_1.Left, (int)rectangleF_1.Top, (int)rectangleF_1.Width, (int)rectangleF_1.Height);
            graphics_0.FillRectangle(GClass438.smethod_0(color_1), rect);
            graphics_0.FillRectangle(Brushes.White, rectangleF_0);
            graphics_0.DrawRectangle(GClass438.smethod_1(color_2), rect);
            using (StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic))
            {
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                for (int i = 0; i < 10000; i++)
                {
                    float num5 = (float)rectangle_0.Left + num3 * (float)i;
                    if (num5 >= rectangleF_1.Right)
                    {
                        break;
                    }
                    SizeF sizeF = graphics_0.MeasureString(i.ToString(), Font, 1000, stringFormat);
                    RectangleF rectangleF = new RectangleF(num5 - sizeF.Width / 2f, rectangleF_0.Top, sizeF.Width, rectangleF_0.Height);
                    float x = num5 - sizeF.Width / 2f;
                    if (i == 0)
                    {
                        x = num5 + 1f;
                    }
                    graphics_0.DrawString(i.ToString(), Font, GClass438.smethod_0(color_3), x, rectangleF_0.Top + sizeF.Height / 2f - 1f, stringFormat);
                    graphics_0.DrawLine(GClass438.smethod_1(color_4), num5, rectangleF_0.Bottom + 2f, num5, base.Height - 2);
                }
            }
            if (method_0() != null)
            {
                GraphicsUnit documentGraphicsUnit = method_0().OwnerDocument.DocumentGraphicsUnit;
                int width = bitmap_1.Width;
                int height = bitmap_1.Height;
                XTextContentElement contentElement = method_0().ContentElement;
                RuntimeDocumentContentStyle runtimeStyle = method_0().RuntimeStyle;
                RectangleF absClientBounds = contentElement.AbsClientBounds;
                rectangle_2.X = (int)(rectangleF_0.Left + GraphicsUnitConvert.Convert(absClientBounds.Left, documentGraphicsUnit, GraphicsUnit.Pixel) * num);
                rectangle_2.Width = (int)(GraphicsUnitConvert.Convert(absClientBounds.Width, documentGraphicsUnit, GraphicsUnit.Pixel) * num);
                float num5 = rectangleF_0.Left + GraphicsUnitConvert.Convert(absClientBounds.Left + runtimeStyle.FirstLineIndent + runtimeStyle.LeftIndent, documentGraphicsUnit, GraphicsUnit.Pixel) * num;
                rectangle_3 = new Rectangle((int)(num5 - (float)(width / 2)), (int)(rectangleF_0.Top - (float)(height / 2) - 1f), width, height);
                if (rectangle_7.IntersectsWith(rectangle_3))
                {
                    graphics_0.DrawImageUnscaled(bitmap_1, rectangle_3);
                }
                num5 = rectangleF_0.Left + GraphicsUnitConvert.Convert(absClientBounds.Left + runtimeStyle.LeftIndent, documentGraphicsUnit, GraphicsUnit.Pixel) * num;
                rectangle_4 = new Rectangle((int)(num5 - (float)(width / 2)), (int)(rectangleF_0.Bottom - (float)(height / 2) + 1f), width, height);
                if (rectangle_7.IntersectsWith(rectangle_4))
                {
                    graphics_0.DrawImageUnscaled(bitmap_0, rectangle_4);
                }
            }
        }

        private void method_22(Graphics graphics_0, Rectangle rectangle_7)
        {
            if (method_11() != null && base.ClientRectangle.IntersectsWith(rectangle_0))
            {
                bool_0 = true;
                float num = method_10();
                float num2 = (float)(GraphicsUnitConvert.GetRate(GraphicsUnit.Pixel, GraphicsUnit.Inch) / 100.0) * num;
                float num3 = (float)GraphicsUnitConvert.Convert(10.0, GraphicsUnit.Millimeter, GraphicsUnit.Pixel);
                num3 *= num;
                rectangleF_1 = new RectangleF(rectangle_0.Left + 6, rectangle_0.Top, rectangle_0.Width - 12, rectangle_0.Height);
                float num4 = method_11().Landscape ? method_11().PaperWidth : method_11().PaperHeight;
                graphics_0.SetClip(rectangle_1);
                rectangleF_0.X = rectangleF_1.Left + 1f;
                rectangleF_0.Y = rectangleF_1.Top + (float)method_11().TopMargin * num2;
                rectangleF_0.Width = rectangleF_1.Width - 2f;
                rectangleF_0.Height = (num4 - (float)method_11().TopMargin - (float)method_11().BottomMargin) * num2;
                graphics_0.FillRectangle(GClass438.smethod_0(color_1), rectangleF_1);
                graphics_0.FillRectangle(Brushes.White, rectangleF_0);
                graphics_0.DrawRectangle(GClass438.smethod_1(color_2), rectangleF_1.Left, rectangleF_1.Top, rectangleF_1.Width, rectangleF_1.Height);
                using (StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic))
                {
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.FormatFlags = (StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap);
                    RightToLeft rightToLeft = RightToLeft;
                    for (int i = 0; i < 10000; i++)
                    {
                        float num5 = (float)rectangle_0.Top + num3 * (float)i;
                        if (num5 >= rectangleF_1.Bottom)
                        {
                            break;
                        }
                        SizeF sizeF = graphics_0.MeasureString(i.ToString(), Font, 1000, stringFormat);
                        RectangleF rectangleF = new RectangleF(rectangleF_0.Left, num5 - sizeF.Height / 2f, rectangleF_0.Width, sizeF.Height);
                        float y = num5 - sizeF.Height / 2f;
                        if (i == 0)
                        {
                            y = num5 + 1f;
                        }
                        graphics_0.DrawString(i.ToString(), Font, GClass438.smethod_0(color_3), rectangleF_0.Left + sizeF.Width / 2f - 2f, y, stringFormat);
                        if (rightToLeft == RightToLeft.Yes)
                        {
                            graphics_0.DrawLine(GClass438.smethod_1(color_4), rectangleF_0.Left - 2f, num5, 2f, num5);
                        }
                        else
                        {
                            graphics_0.DrawLine(GClass438.smethod_1(color_4), rectangleF_0.Right + 2f, num5, base.Width - 2, num5);
                        }
                    }
                }
            }
        }


        #endregion
    }
}
