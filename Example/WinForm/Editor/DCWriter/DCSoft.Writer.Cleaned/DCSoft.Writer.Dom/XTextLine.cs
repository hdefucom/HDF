using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Dom
{
    /// <summary>
    ///       文本行对象
    ///       </summary>
    
    [DebuggerDisplay("Count={ Count }")]
    [DebuggerTypeProxy(typeof(ListDebugView))]
    [Guid("00012345-6789-ABCD-EF01-23456789000F")]
    [ComDefaultInterface(typeof(IXTextLine))]
    [ComVisible(true)]
    [ComClass("00012345-6789-ABCD-EF01-23456789000F", "88F6BACA-29E0-465E-AC26-710AC3AF1050")]
    [ClassInterface(ClassInterfaceType.None)]
    [DocumentComment]
    public class XTextLine : XTextElementList, IXTextLine
    {
        internal const string string_2 = "00012345-6789-ABCD-EF01-23456789000F";

        internal const string string_3 = "88F6BACA-29E0-465E-AC26-710AC3AF1050";

        private bool bool_1 = true;

        private bool bool_2 = true;

        internal XTextDocument xtextDocument_0 = null;

        private bool bool_3 = false;

        private XTextParagraphFlagElement xtextParagraphFlagElement_0 = null;

        internal XTextContentElement xtextContentElement_0 = null;

        private PrintPage printPage_0 = null;

        private PrintPage printPage_1 = null;

        private bool bool_4 = false;

        private int int_0 = 0;

        private int int_1 = 0;

        private int int_2 = 0;

        private int int_3 = 0;

        private VerticalAlignStyle verticalAlignStyle_0 = VerticalAlignStyle.Bottom;

        private VerticalAlignStyle verticalAlignStyle_1 = VerticalAlignStyle.Bottom;

        private DocumentContentAlignment documentContentAlignment_0 = DocumentContentAlignment.Left;



        private float float_1 = 0f;

        private float float_2 = 0f;

        private float float_3 = 0f;

        private float float_4 = 0f;

        [NonSerialized]
        private float float_5 = -1f;

        private float float_6 = 0f;

        private bool bool_5 = false;

        private float float_7 = 0f;

        private float float_8 = 0f;

        private float 字符间距 = 0f;

        private float f段前间距 = 0f;

        private float f段后间距 = 0f;

        private float f行间距 = 0f;

        public static float float_13 = 0f;

        private float f内容高度 = -1f;

        private static float float_15 = 3.125f;

        private float float_16 = 0f;

        private float float_17 = -1f;

        private XTextPageBreakElement xtextPageBreakElement_0 = null;

        private XTextTableElement xtextTableElement_0 = null;

        private XTextSectionElement xtextSectionElement_0 = null;

        private bool bool_6 = true;

        private ContentLayoutDirectionStyle contentLayoutDirectionStyle_0 = ContentLayoutDirectionStyle.Invalidate;

        private int int_4 = 0;

        internal static GStruct20 gstruct20_0 = new GStruct20(bool_1: true);

        private float float_18 = 0f;

        private string string_4 = null;

        private ArrayList arrayList_0 = null;

        private RectangleF[] rectangleF_0 = null;

        /// <summary>
        ///       文档行是否可见
        ///       </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        
        public bool Visible
        {
            get
            {
                return bool_1;
            }
            set
            {
                bool_1 = value;
            }
        }

        /// <summary>
        ///       在输出HTML中是否可见
        ///       </summary>
        internal bool HtmlVisible
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
        ///       对象所属的文档对象
        ///       </summary>
        [Browsable(false)]
        public virtual XTextDocument OwnerDocument => xtextDocument_0;

        /// <summary>
        ///       受到了自由布局元素影响
        ///       </summary>
        [DefaultValue(false)]
        public bool EffectByFreeLayoutElement
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
        ///       文档行所在的段落的段落标记文档元素对象
        ///       </summary>
        [Browsable(false)]
        [ReadOnly(true)]
        public XTextParagraphFlagElement ParagraphFlagElement
        {
            get
            {
                return xtextParagraphFlagElement_0;
            }
            set
            {
                xtextParagraphFlagElement_0 = value;
                contentLayoutDirectionStyle_0 = ContentLayoutDirectionStyle.Invalidate;
            }
        }

        /// <summary>
        ///       对象所属的文档区域对象
        ///       </summary>
        [Browsable(false)]
        public XTextContentElement OwnerContentElement => xtextContentElement_0;

        /// <summary>
        ///       对象所在的文档页对象
        ///       </summary>
        [ReadOnly(true)]
        [Browsable(true)]
        public PrintPage OwnerPage
        {
            get
            {
                return printPage_0;
            }
            set
            {
                printPage_0 = value;
            }
        }

        /// <summary>
        ///       对象所在的最后一个文档页对象
        ///       </summary>
        [ReadOnly(true)]
        [Browsable(true)]
        public PrintPage LastOwnerPage
        {
            get
            {
                return printPage_1;
            }
            set
            {
                printPage_1 = value;
            }
        }

        internal bool InvalidateState
        {
            get
            {
                return bool_4;
            }
            set
            {
                bool_4 = value;
                if (bool_4)
                {
                    float_17 = -1f;
                    bool_6 = true;
                }
            }
        }

        /// <summary>
        ///       在整个文档中的从1开始的行号
        ///       </summary>
        [DefaultValue(0)]
        
        public int GlobalIndex
        {
            get
            {
                return int_0;
            }
            set
            {
                int_0 = value;
            }
        }

        /// <summary>
        ///       在所在文档页中的从1开始的行号
        ///       </summary>
        [DefaultValue(0)]
        
        public int IndexInPage
        {
            get
            {
                return int_1;
            }
            set
            {
                int_1 = value;
            }
        }

        /// <summary>
        ///       在段落中的行号
        ///       </summary>
        [DefaultValue(0)]
        public int IndexInParagraph
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
        ///       所在文档页中的从1开始的私有行号
        ///       </summary>
        [DefaultValue(0)]
        public int PrivateIndexInPage
        {
            get
            {
                return int_3;
            }
            set
            {
                if (value != 0)
                {
                }
                if (int_3 != value)
                {
                    int_3 = value;
                }
            }
        }

        /// <summary>
        ///       垂直对齐方式
        ///       </summary>
        [DefaultValue(VerticalAlignStyle.Bottom)]
        public VerticalAlignStyle VerticalAlign
        {
            get
            {
                return verticalAlignStyle_0;
            }
            set
            {
                verticalAlignStyle_0 = value;
            }
        }

        /// <summary>
        ///       运行时使用的垂直对齐方式
        ///       </summary>
        public VerticalAlignStyle RuntimeVerticalAlign => verticalAlignStyle_1;

        /// <summary>
        ///       内容的水平对齐方式
        ///       </summary>
        [DefaultValue(DocumentContentAlignment.Left)]
        public DocumentContentAlignment Align
        {
            get
            {
                return documentContentAlignment_0;
            }
            set
            {
                documentContentAlignment_0 = value;
            }
        }

        /// <summary>
        ///       左内边距
        ///       </summary>
        [DefaultValue(0f)]
        public float PaddingLeft { get; set; }

        /// <summary>
        ///       右内边距
        ///       </summary>
        [DefaultValue(0f)]
        public float PaddingRight
        {
            get
            {
                return float_1;
            }
            set
            {
                float_1 = value;
            }
        }

        /// <summary>
        ///       对象左端位置
        ///       </summary>
        [DefaultValue(0f)]
        
        public float Left
        {
            get
            {
                return float_2;
            }
            set
            {
                float_2 = value;
            }
        }

        /// <summary>
        ///       文本行的绝对左端位置
        ///       </summary>
        [DefaultValue(0)]
        public float AbsLeft
        {
            get
            {
                if (xtextContentElement_0 == null)
                {
                    return float_2 + xtextDocument_0.Left;
                }
                return float_2 + xtextContentElement_0.AbsLeft;
            }
        }

        /// <summary>
        ///       对象顶端位置
        ///       </summary>
        
        [DefaultValue(0f)]
        public float Top
        {
            get
            {
                return float_3;
            }
            set
            {
                if (float_3 != value)
                {
                    float_3 = value;
                    float_5 = -1f;
                }
            }
        }

        /// <summary>
        ///       原始的文档行顶端位置，一般的经过排版后，文档行的Top值等于该值，
        ///       但由于进行二次分页线位置修正后，文档行的Top可能大于NativeTop值。
        ///       </summary>
        [DefaultValue(0f)]
        internal float NativeTop
        {
            get
            {
                return float_4;
            }
            set
            {
                float_4 = value;
            }
        }

        /// <summary>
        ///       缓存的文档行的绝对顶端坐标值
        ///       </summary>
        internal float AbsTopBuffered
        {
            get
            {
                return float_5;
            }
            set
            {
                float_5 = value;
            }
        }

        /// <summary>
        ///       文档行在文档视图中的绝对顶端位置
        ///       </summary>
        [DefaultValue(0f)]
        public float AbsTop
        {
            get
            {
                if (float_5 >= 0f)
                {
                    return float_5;
                }
                if (xtextContentElement_0 == null)
                {
                    return float_3 + xtextDocument_0.Top;
                }
                return float_3 + xtextContentElement_0.AbsTop;
            }
        }

        /// <summary>
        ///       文档行的设计宽度
        ///       </summary>
        [DefaultValue(0f)]
        public float DesignWidth
        {
            get
            {
                return float_6;
            }
            set
            {
                float_6 = value;
                float_7 = value;
            }
        }

        /// <summary>
        ///       内容排版状态无效标记
        ///       </summary>
        [DefaultValue(false)]
        public bool LayoutInvalidate
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
        ///       对象宽度
        ///       </summary>
        
        [DefaultValue(0f)]
        public float Width
        {
            get
            {
                return float_7;
            }
            set
            {
                float_7 = value;
            }
        }

        /// <summary>
        ///       判断是否存在着重号字符
        ///       </summary>
        internal bool HasEmphasisMarkChar
        {
            get
            {
                using (Enumerator enumerator = GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        XTextElement current = enumerator.Current;
                        if (current is XTextCharElement && current.RuntimeStyle.EmphasisMark)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        ///       对象高度
        ///       </summary>
        
        [DefaultValue(0f)]
        public float Height
        {
            get
            {
                return float_8;
            }
            set
            {
                if (float_8 != value)
                {
                    float_8 = value;
                    bool_5 = true;
                    int_4 = -1;
                }
            }
        }

        /// <summary>
        ///       文档行的显示高度
        ///       </summary>
        public float ViewHeight => Height;

        /// <summary>
        ///       字符间距
        ///       </summary>
        [DefaultValue(0f)]
        public float Spacing
        {
            get
            {
                return 字符间距;
            }
            set
            {
                if (字符间距 != value)
                {
                    字符间距 = value;
                    bool_5 = true;
                    int_4 = -1;
                }
            }
        }

        /// <summary>
        ///       视图宽度
        ///       </summary>
        public float ViewWidth
        {
            get
            {
                float num = Width;
                if (base.LastElement is XTextParagraphFlagElement)
                {
                    num += OwnerDocument.PixelToDocumentUnit(7f);
                }
                return num;
            }
        }

        /// <summary>
        ///       由于段落前间距而导致的文档行额外的上间距
        ///       </summary>
        public float SpacingBeforeForParagraph
        {
            get
            {
                return f段前间距;
            }
            set
            {
                if (f段前间距 != value)
                {
                    f段前间距 = value;
                    bool_5 = true;
                    int_4 = -1;
                }
            }
        }

        /// <summary>
        ///       由于段落后间距而导致的文档行额外的下间距
        ///       </summary>
        public float SpacingAfterForParagraph
        {
            get
            {
                return f段后间距;
            }
            set
            {
                if (f段后间距 != value)
                {
                    f段后间距 = value;
                    bool_5 = true;
                    int_4 = -1;
                }
            }
        }

        /// <summary>
        ///       指定的行间距，这是由段落的行间距设置计算所得,为0表示自动行高
        ///       </summary>
        [DefaultValue(0f)]
        public float SpecifyLineSpacing
        {
            get
            {
                return f行间距;
            }
            set
            {
                if (f行间距 != value)
                {
                    f行间距 = value;
                    bool_5 = true;
                    int_4 = -1;
                }
            }
        }

        /// <summary>
        ///       对象底端位置
        ///       </summary>
        [DefaultValue(0f)]
        public float Bottom => float_3 + float_8;

        /// <summary>
        ///       底端绝对坐标
        ///       </summary>
        [DefaultValue(0f)]
        public float AbsBottom => AbsTop + float_8;

        /// <summary>
        ///       对象边框
        ///       </summary>
        [Browsable(false)]
        public RectangleF Bounds => new RectangleF(float_2, float_3, float_7, float_8);

        /// <summary>
        ///       采用绝对坐标下的对象边框
        ///       </summary>
        [Browsable(false)]
        public RectangleF AbsBounds => new RectangleF(AbsLeft, AbsTop, float_7, float_8);

        /// <summary>
        ///       文档行中所有元素的宽度和
        ///       </summary>
        public float ElementsWidth
        {
            get
            {
                float num = 0f;
                using (Enumerator enumerator = GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        XTextElement current = enumerator.Current;
                        num += current.Width;
                    }
                }
                return num;
            }
        }

        /// <summary>
        ///       文档行中所有元素的内容宽度和
        ///       </summary>
        public float ContentWidth
        {
            get
            {
                if (base.Count == 0)
                {
                    return 0f;
                }
                float num = 0f;
                using (Enumerator enumerator = GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        XTextElement current = enumerator.Current;
                        num = num + current.Width + 字符间距;
                    }
                }
                return num - 字符间距;
            }
        }

        /// <summary>
        ///       内容顶端位置修正
        ///       </summary>
        public float ContentTopFix => float_16;

        /// <summary>
        ///       内容高度
        ///       </summary>
        public float ContentHeight
        {
            get
            {
                if (f内容高度 < 0f)
                {
                    method_16(method_18());
                }
                return f内容高度;
            }
        }

        private bool InGridLineContentElement
        {
            get
            {
                if (xtextContentElement_0 != null && xtextContentElement_0.RuntimeStyle.GridLineType == ContentGridLineType.ExtentToBottom)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///       获得本行中最大字体高度
        ///       </summary>
        [Browsable(false)]
        public float MaxFontHeight
        {
            get
            {
                if (float_17 < 0f)
                {
                    bool inGridLineContentElement = InGridLineContentElement;
                    using (Enumerator enumerator = GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            XTextElement current = enumerator.Current;
                            _ = current.RuntimeStyle;
                            if (inGridLineContentElement && current is XTextParagraphFlagElement)
                            {
                            }
                        }
                    }
                    float_17 = Math.Max(float_17, 50f);
                }
                return float_17;
            }
        }

        /// <summary>
        ///       判断本行是分页行（只包含一个分页符）
        ///       </summary>
        internal bool IsPageBreakLine => xtextPageBreakElement_0 != null;

        /// <summary>
        ///       获得分页元素
        ///       </summary>
        internal XTextPageBreakElement PageBreakElement => xtextPageBreakElement_0;

        /// <summary>
        ///       判断本行是否为表格行（只包含一个表格元素）
        ///       </summary>
        internal bool IsTableLine => xtextTableElement_0 != null;

        /// <summary>
        ///       文档行中所包含的表格对象
        ///       </summary>
        internal XTextTableElement TableElement => xtextTableElement_0;

        /// <summary>
        ///       是否为只包含一个段落符号的空白行
        ///       </summary>
        [Browsable(false)]
        public bool IsEmptyLine => base.Count == 1 && base[0] is XTextParagraphFlagElement;

        /// <summary>
        ///       判断本行是否为一个空白行。
        ///       </summary>
        internal bool IsBlankElementLine => base.Count == 1 && base[0] is XTextBlankLineElement;

        /// <summary>
        ///       判断本行是否为文档节行（只包含一个文档节元素）
        ///       </summary>
        internal bool IsSectionLine => xtextSectionElement_0 != null;

        /// <summary>
        ///       判断本行是否包含了一个内容展开的文档节行。
        ///       </summary>
        internal bool IsExpendedSectionLine
        {
            get
            {
                if (!(SectionElement?.RuntimeIsCollapsed ?? true))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///       文档行中所包含的文档节对象
        ///       </summary>
        internal XTextSectionElement SectionElement => xtextSectionElement_0;

        /// <summary>
        ///       获得布局方式,内部使用.
        ///       </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComVisible(false)]
        [Browsable(false)]
        public ContentLayoutDirectionStyle RuntimeLayoutDirection
        {
            get
            {
                if (contentLayoutDirectionStyle_0 == ContentLayoutDirectionStyle.Invalidate)
                {
                    contentLayoutDirectionStyle_0 = ParagraphFlagElement.RuntimeLayoutDirection;
                    if (contentLayoutDirectionStyle_0 == ContentLayoutDirectionStyle.Default)
                    {
                        contentLayoutDirectionStyle_0 = OwnerDocument.Options.ViewOptions.LayoutDirection;
                    }
                    if (contentLayoutDirectionStyle_0 == ContentLayoutDirectionStyle.Default)
                    {
                        contentLayoutDirectionStyle_0 = ContentLayoutDirectionStyle.LeftToRight;
                    }
                }
                return contentLayoutDirectionStyle_0;
            }
        }

        private float ClientWidth => float_7 - PaddingLeft - float_1;

        /// <summary>
        ///       获得文本行开头的空白字符串
        ///       </summary>
        internal string HeadWhitespaceString
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                using (Enumerator enumerator = GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        XTextElement current = enumerator.Current;
                        if (!(current is XTextCharElement))
                        {
                            break;
                        }
                        XTextCharElement xTextCharElement = (XTextCharElement)current;
                        if (xTextCharElement.CharValue != ' ' && xTextCharElement.CharValue != '\t')
                        {
                            break;
                        }
                        stringBuilder.Append(xTextCharElement.CharValue);
                    }
                }
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        ///       初始化对象
        ///       </summary>
        
        internal XTextLine()
        {
        }

        /// <summary>
        ///       获得文档行中指定类型的元素
        ///       </summary>
        /// <param name="elementType">
        /// </param>
        /// <returns>
        /// </returns>
        public XTextElement GetFirstElement(Type elementType)
        {
            int num = 13;
            if (elementType == null)
            {
                throw new ArgumentNullException("elementType");
            }
            using (Enumerator enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    XTextElement current = enumerator.Current;
                    if (elementType.IsInstanceOfType(current))
                    {
                        return current;
                    }
                }
            }
            return null;
        }

        public virtual void vmethod_1()
        {
            OwnerDocument.method_70(Bounds);
        }

        private void method_16(float float_19)
        {
            if (f内容高度 != float_19)
            {
                f内容高度 = float_19;
            }
        }

        
        public static float smethod_0(Graphics graphics_0, XFontValue xfontValue_0)
        {
            float height = xfontValue_0.Value.GetHeight(graphics_0);
            return height + float_15;
        }

        
        public void method_17()
        {
            method_16(-1f);
        }

        private float method_18()
        {
            float num = 0f;
            using (Enumerator enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    XTextElement current = enumerator.Current;
                    if (!(current is XTextShadowElement) && current.RuntimeStyle.LayoutAlign == ContentLayoutAlign.EmbedInText)
                    {
                        num = Math.Max(current.Height, num);
                    }
                }
            }
            num = Math.Max(num, OwnerDocument.DefaultStyle.DefaultLineHeight);
            if (!IsTableLine && !IsSectionLine && ParagraphFlagElement != null)
            {
                RuntimeDocumentContentStyle runtimeStyle = ParagraphFlagElement.RuntimeStyle;
                if (runtimeStyle.LineSpacingStyle == LineSpacingStyle.SpaceSpecify)
                {
                    num = Math.Min(num, runtimeStyle.LineSpacing);
                }
            }
            return num + float_15;
        }

        private bool method_19(int int_5, int int_6, float float_19, float float_20, ContentLayoutDirectionStyle contentLayoutDirectionStyle_1, bool bool_7)
        {
            if (int_6 == 0)
            {
                return false;
            }
            bool flag = OwnerDocument.EditorControl != null && !OwnerDocument.EditorControl.IsUpdating && !OwnerDocument.IsLoadingDocument;
            float val = 1E+08f;
            if (!IsTableLine && !IsSectionLine && ParagraphFlagElement != null)
            {
                RuntimeDocumentContentStyle runtimeStyle = ParagraphFlagElement.RuntimeStyle;
                if (runtimeStyle.LineSpacingStyle == LineSpacingStyle.SpaceSpecify)
                {
                    val = runtimeStyle.GetLineSpacing(0f, 0f, OwnerDocument.DocumentGraphicsUnit);
                }
            }
            XTextDocument ownerDocument = OwnerDocument;
            XTextElementList xTextElementList = null;
            if (int_5 == 0 && int_6 == base.Count)
            {
                xTextElementList = this;
            }
            else
            {
                xTextElementList = new XTextElementList();
                for (int i = 0; i < int_6; i++)
                {
                    xTextElementList.Add(base[i + int_5]);
                }
            }
            int num = 0;
            if (ownerDocument.Options.ViewOptions.EnableRightToLeft)
            {
                if (WriterUtils.smethod_24(xTextElementList))
                {
                    WriterUtils.smethod_20(OwnerDocument, this, bool_2: true);
                }
                if (bool_6 && Class126.smethod_5() && (contentLayoutDirectionStyle_1 == ContentLayoutDirectionStyle.LeftToRight || contentLayoutDirectionStyle_1 == ContentLayoutDirectionStyle.RightToLeft))
                {
                    int num2 = -1;
                    for (int i = 0; i < int_6; i++)
                    {
                        ContentLayoutDirectionStyle contentLayoutDirectionStyle = contentLayoutDirectionStyle_1;
                        XTextElement xTextElement = xTextElementList[i];
                        if (xTextElement is XTextCharElement)
                        {
                            XTextCharElement xTextCharElement = (XTextCharElement)xTextElement;
                            char charValue = xTextCharElement.CharValue;
                            contentLayoutDirectionStyle = WriterUtils.smethod_21(charValue, contentLayoutDirectionStyle_1);
                            if (!xTextCharElement.ConnectFlag)
                            {
                            }
                        }
                        else
                        {
                            contentLayoutDirectionStyle = contentLayoutDirectionStyle_1;
                        }
                        xTextElement.IsRightToLeft = (contentLayoutDirectionStyle == ContentLayoutDirectionStyle.RightToLeft);
                        int num3 = 0;
                        if (i == int_6 - 1)
                        {
                            if (contentLayoutDirectionStyle != contentLayoutDirectionStyle_1)
                            {
                                num3 = 1;
                            }
                            contentLayoutDirectionStyle = contentLayoutDirectionStyle_1;
                        }
                        if (contentLayoutDirectionStyle == contentLayoutDirectionStyle_1)
                        {
                            if (num2 < 0)
                            {
                                continue;
                            }
                            if (i + num3 > num2 + 1)
                            {
                                if (xTextElementList == this)
                                {
                                    XTextElementList collection = xTextElementList;
                                    xTextElementList = new XTextElementList();
                                    xTextElementList.AddRange(collection);
                                }
                                xTextElementList.Reverse(num2, i + num3 - num2);
                                Reverse(num2 + int_5, i + num3 - num2);
                            }
                            num2 = -1;
                        }
                        else if (num2 == -1)
                        {
                            num2 = i;
                        }
                    }
                }
                if (Class126.smethod_5())
                {
                    foreach (XTextElement item in xTextElementList)
                    {
                        if (item is XTextCharElement && ((XTextCharElement)item).ConnectFlag)
                        {
                            num++;
                        }
                    }
                }
            }
            DocumentControler documentControler = ownerDocument.DocumentControler;
            (base.LastElement as XTextLineBreakElement)?.method_13(SafeGet(base.Count - 2));
            float num4 = -1f;
            float num5 = 10f;
            if (InGridLineContentElement)
            {
                num5 = OwnerDocument.DefaultStyle.FontHeight;
            }
            List<XTextElement> list = new List<XTextElement>();
            new List<XTextElement>();
            int num6 = int_6;
            if (bool_7)
            {
                int i = int_6 - 1;
                while (i >= 0 && xTextElementList[i] is XTextCharElement)
                {
                    XTextCharElement xTextCharElement2 = (XTextCharElement)xTextElementList[i];
                    if (xTextCharElement2.CharValue != ' ')
                    {
                        break;
                    }
                    num6--;
                    xTextCharElement2.WidthFix = 0f;
                    i--;
                }
                if ((double)num6 < (double)int_6 * 0.8)
                {
                    num6 = int_6;
                }
            }
            DocumentContentAlignment align = ParagraphFlagElement.RuntimeStyle.Align;
            float num7 = 0f;
            float num8 = 1f;
            if (OwnerContentElement is XTextTableCellElement)
            {
                num8 = ((XTextTableCellElement)OwnerContentElement).RateForAutoFixFontSizeMode;
            }
            for (int i = 0; i < num6; i++)
            {
                XTextElement xTextElement = xTextElementList[i];
                if (xTextElement is XTextFieldBorderElement)
                {
                    XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xTextElement;
                    if (string.IsNullOrEmpty(xTextFieldBorderElement.Text) && string.IsNullOrEmpty(xTextFieldBorderElement.BorderText))
                    {
                        XTextElement xTextElement2 = null;
                        xTextElement2 = ((xTextFieldBorderElement.Position != 0) ? xTextElementList.GetPreElement(xTextFieldBorderElement) : xTextElementList.GetNextElement(xTextFieldBorderElement));
                        if (xTextElement2 == null || xTextElement2 is XTextFieldBorderElement)
                        {
                            xTextFieldBorderElement.Height = num8 * xTextFieldBorderElement.StandardHeight;
                        }
                        else
                        {
                            xTextFieldBorderElement.Height = num8 * Math.Max(xTextElement2.Height, xTextFieldBorderElement.StandardHeight);
                        }
                    }
                    if (xTextFieldBorderElement.Parent is XTextInputFieldElementBase)
                    {
                        XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextFieldBorderElement.Parent;
                        if (xTextFieldBorderElement != xTextInputFieldElementBase.EndElement || !(xTextInputFieldElementBase.RuntimeSpecifyWidth > 0f))
                        {
                        }
                    }
                }
                else if (xTextElement is XTextPageBreakElement)
                {
                    xTextElement.Width = DesignWidth - 20f;
                    if (xTextElement.Height == 0f)
                    {
                        xTextElement.Height = num8 * MaxFontHeight;
                    }
                }
                RuntimeDocumentContentStyle runtimeStyle2 = xTextElement.RuntimeStyle;
                num7 = num7 + Spacing + xTextElement.LayoutWidth + runtimeStyle2.LetterSpacing;
                xTextElement.WidthFix = 0f;
                if (runtimeStyle2.LayoutAlign == ContentLayoutAlign.EmbedInText)
                {
                    float layoutHeight = xTextElement.LayoutHeight;
                    if (layoutHeight > num5)
                    {
                        num5 = layoutHeight;
                    }
                }
                else
                {
                    list.Add(xTextElement);
                }
            }
            num7 -= Spacing;
            num5 = Math.Min(num5, val);
            num4 = (float)Math.Ceiling(num5 + float_15);
            if (num4 > f内容高度)
            {
                method_16(num4);
            }
            float num9 = float_16;
            num9 = (f行间距 <= 0f) ? (float_15 + f段前间距) : (float_15 + f段前间距 + (f行间距 - num4) / 2f);
            if (IsSectionLine)
            {
                if (SectionElement.CompressOwnerLineSpacing)
                {
                    num9 = float_15;
                }
            }
            else if (IsTableLine)
            {
                if (TableElement.CompressOwnerLineSpacing)
                {
                    num9 = float_15;
                }
            }
            else if (IsPageBreakLine)
            {
                num9 = float_15;
            }
            float_16 = num9;
            bool flag2 = true;
            if (int_6 == 1)
            {
                flag2 = false;
            }
            else if (align == DocumentContentAlignment.Distribute)
            {
                flag2 = true;
            }
            else if (xTextElementList.HasLineEndElement)
            {
                flag2 = false;
            }
            else if (OwnerContentElement.PrivateLines.LastLine == this)
            {
                flag2 = false;
            }
            else if (IsTableLine || IsSectionLine)
            {
                flag2 = false;
            }
            else
            {
                XTextElementList privateContent = OwnerContentElement.PrivateContent;
                if (privateContent.SafeGet(privateContent.method_9(xTextElementList.LastElement) + 1) is XTextPageBreakElement)
                {
                    flag2 = false;
                }
            }
            DocumentContentAlignment documentContentAlignment = Align;
            foreach (XTextElement item2 in xTextElementList)
            {
                if (item2 is XTextCharElement)
                {
                    XTextCharElement xTextCharElement2 = (XTextCharElement)item2;
                    xTextCharElement2.LinkCharNum = 0;
                }
                item2.WidthFix = item2.RuntimeStyle.LetterSpacing;
            }
            float num10 = Math.Abs(float_19 - float_20) - num7;
            if (!(num10 < 0f))
            {
            }
            if (flag2 && num10 > 0f)
            {
                if (num > 0)
                {
                    using (DCGraphics dCGraphics = OwnerDocument.CreateDCGraphics())
                    {
                        GClass95 render = OwnerDocument.Render;
                        while (num10 > 0f)
                        {
                            foreach (XTextElement item3 in xTextElementList)
                            {
                                if (!(item3 is XTextCharElement))
                                {
                                    continue;
                                }
                                XTextCharElement xTextCharElement2 = (XTextCharElement)item3;
                                if (!xTextCharElement2.ConnectFlag)
                                {
                                    continue;
                                }
                                float width = render.method_9().method_10(xTextCharElement2.RuntimeStyle.Font, '\u0640', dCGraphics.NativeGraphics, dCGraphics.NativeGraphics.PageUnit).Width;
                                if (!(width > num10))
                                {
                                    xTextCharElement2.LinkCharNum++;
                                    xTextCharElement2.WidthFix += width;
                                    num10 -= width;
                                    if (num10 < 0f)
                                    {
                                        break;
                                    }
                                    continue;
                                }
                                goto IL_08ea;
                            }
                        }
                    }
                    goto IL_08ea;
                }
                goto IL_08f2;
            }
            goto IL_0aeb;
            IL_08f2:
            if (num10 > 0f)
            {
                List<XTextElement> list2 = new List<XTextElement>();
                int num11 = 0;
                for (int i = 0; i < num6; i++)
                {
                    XTextElement xTextElement = xTextElementList[i];
                    if (!(xTextElement is XTextCharElement))
                    {
                        break;
                    }
                    char charValue = ((XTextCharElement)xTextElement).CharValue;
                    if (charValue != ' ' && charValue != '\t')
                    {
                        break;
                    }
                    num11 = i + 1;
                }
                if (num11 == num - 1)
                {
                    int_5 = 0;
                }
                for (int i = num11; i < num6 - 1; i++)
                {
                    XTextElement xTextElement = xTextElementList[i];
                    if (xTextElement.RuntimeStyle.FixedSpacing)
                    {
                        continue;
                    }
                    if (xTextElement is XTextCharElement)
                    {
                        if (xTextElement.Parent is XTextFieldElementBase)
                        {
                            XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement.Parent;
                            if (xTextFieldElementBase.FastIsBackgroundTextElement(xTextElement))
                            {
                                continue;
                            }
                        }
                        XTextCharElement xTextCharElement3 = (XTextCharElement)xTextElement;
                        if (xTextCharElement3.CharValue != '\t' && !documentControler.vmethod_11(xTextCharElement3.CharValue))
                        {
                            if (i == int_6 - 1 && list2.Count > 0)
                            {
                                break;
                            }
                            list2.Add(xTextElement);
                        }
                        continue;
                    }
                    if (xTextElement is XTextFieldBorderElement)
                    {
                        XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)xTextElement;
                        if (xTextFieldBorderElement2.Position == BorderElementPosition.Start)
                        {
                            continue;
                        }
                    }
                    if (!(xTextElement is XTextParagraphFlagElement))
                    {
                        list2.Add(xTextElement);
                    }
                }
                if (list2.Count > 0)
                {
                    float num12 = num10 / (float)list2.Count;
                    foreach (XTextElement item4 in list2)
                    {
                        item4.WidthFix = item4.RuntimeStyle.LetterSpacing + num12;
                    }
                }
                num10 = 0f;
            }
            documentContentAlignment = DocumentContentAlignment.Justify;
            goto IL_0aeb;
            IL_0aeb:
            VerticalAlignStyle verticalAlignStyle = verticalAlignStyle_1 = VerticalAlign;
            if (verticalAlignStyle != 0)
            {
                foreach (XTextElement item5 in xTextElementList)
                {
                    if (item5 is XTextObjectElement)
                    {
                        XTextObjectElement xTextObjectElement = (XTextObjectElement)item5;
                        verticalAlignStyle = xTextObjectElement.RuntimeVAlign;
                        break;
                    }
                    if (item5 is XTextShapeInputFieldElement)
                    {
                        XTextShapeInputFieldElement xTextShapeInputFieldElement = (XTextShapeInputFieldElement)item5;
                        verticalAlignStyle = xTextShapeInputFieldElement.RuntimeVAlign;
                    }
                }
            }
            verticalAlignStyle_1 = verticalAlignStyle;
            float num13 = 0f;
            foreach (XTextElement item6 in xTextElementList)
            {
                if (item6 is XTextCharElement || item6 is XTextLabelElement)
                {
                    float layoutHeight2 = item6.LayoutHeight;
                    if (num13 < layoutHeight2)
                    {
                        num13 = layoutHeight2;
                    }
                }
                else if (item6 is XTextFieldBorderElement)
                {
                    XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)item6;
                    if (num13 < xTextFieldBorderElement2.float_6)
                    {
                        num13 = xTextFieldBorderElement2.float_6;
                    }
                }
            }
            float num14 = num9;
            switch (verticalAlignStyle)
            {
                default:
                    num14 = num9 + num5 - num13;
                    break;
                case VerticalAlignStyle.Top:
                    num14 = num9;
                    break;
                case VerticalAlignStyle.Middle:
                    num14 = num9 + (num5 - num13) / 2f;
                    break;
                case VerticalAlignStyle.Bottom:
                    num14 = num9 + num5 - num13;
                    break;
            }
            switch (contentLayoutDirectionStyle_1)
            {
                case ContentLayoutDirectionStyle.RightToLeft:
                    {
                        float num15 = Math.Abs(float_19 - float_20);
                        float_19 = Math.Max(float_19, float_20);
                        float num20 = float_19;
                        switch (documentContentAlignment)
                        {
                            case DocumentContentAlignment.Right:
                                num20 = float_19;
                                break;
                            case DocumentContentAlignment.Center:
                                num20 = float_19 - (num15 - num7) / 2f;
                                if (num20 > float_19)
                                {
                                    num20 = float_19;
                                }
                                break;
                            case DocumentContentAlignment.Left:
                                num20 = float_19 - (num15 - num7);
                                if (num20 > float_19)
                                {
                                    num20 = float_19;
                                }
                                break;
                            default:
                                num20 = float_19;
                                break;
                        }
                        for (int i = 0; i < int_6; i++)
                        {
                            XTextElement xTextElement = xTextElementList[i];
                            float num17 = num20 - xTextElement.LayoutWidth;
                            float num18 = num9;
                            float num19 = 0f;
                            if (!list.Contains(xTextElement))
                            {
                                if (xTextElement is XTextCharElement || xTextElement is XTextLabelElement)
                                {
                                    num19 = num14 + num13 - xTextElement.LayoutHeight;
                                }
                                else
                                {
                                    switch (verticalAlignStyle)
                                    {
                                        default:
                                            num19 = num18 + num5 - xTextElement.LayoutHeight;
                                            break;
                                        case VerticalAlignStyle.Top:
                                            num19 = num9;
                                            break;
                                        case VerticalAlignStyle.Middle:
                                            num19 = num9 + (num5 - xTextElement.LayoutHeight) / 2f;
                                            break;
                                        case VerticalAlignStyle.Bottom:
                                            num19 = num18 + num5 - xTextElement.LayoutHeight;
                                            break;
                                    }
                                }
                                if (xTextElement is XTextFieldBorderElement)
                                {
                                    XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)xTextElement;
                                    if (xTextFieldBorderElement2.float_6 > 0f)
                                    {
                                        xTextFieldBorderElement2.float_7 = num14 + num13 - xTextFieldBorderElement2.float_6 - num19;
                                    }
                                }
                            }
                            else
                            {
                                num19 = num9;
                            }
                            if (xTextElement.Left != num17 || xTextElement.Top != num19)
                            {
                                xTextElement.Left = num17;
                                xTextElement.Top = num19;
                                ownerDocument.method_67(xTextElement);
                            }
                            float num21 = xTextElement.LayoutWidth + xTextElement.WidthFix;
                            xTextElement.Left = num20 - xTextElement.LayoutWidth - xTextElement.WidthFix;
                            num20 -= num21;
                            if (list.Contains(xTextElement))
                            {
                                xTextElement.Bounds.Offset(Left, Top);
                                OwnerContentElement.dictionary_0[xTextElement] = this;
                            }
                        }
                        break;
                    }
                case ContentLayoutDirectionStyle.LeftToRight:
                    {
                        float num15 = Math.Abs(float_19 - float_20);
                        float_19 = Math.Min(float_19, float_20);
                        float num16 = float_19;
                        switch (documentContentAlignment)
                        {
                            case DocumentContentAlignment.Left:
                                num16 = float_19;
                                break;
                            case DocumentContentAlignment.Center:
                                num16 = float_19 + (num15 - num7) / 2f;
                                if (num16 < float_19)
                                {
                                    num16 = float_19;
                                }
                                break;
                            case DocumentContentAlignment.Right:
                                num16 = float_19 + (num15 - num7);
                                if (num16 < float_19)
                                {
                                    num16 = float_19;
                                }
                                break;
                            default:
                                num16 = float_19;
                                break;
                        }
                        for (int i = 0; i < int_6; i++)
                        {
                            XTextElement xTextElement = xTextElementList[i];
                            float num17 = num16;
                            float num18 = num9;
                            float num19 = 0f;
                            if (!list.Contains(xTextElement))
                            {
                                if (xTextElement is XTextCharElement || xTextElement is XTextLabelElement)
                                {
                                    num19 = num14 + num13 - xTextElement.LayoutHeight;
                                }
                                else
                                {
                                    switch (verticalAlignStyle)
                                    {
                                        default:
                                            num19 = num18 + num5 - xTextElement.LayoutHeight;
                                            break;
                                        case VerticalAlignStyle.Top:
                                            num19 = num9;
                                            break;
                                        case VerticalAlignStyle.Middle:
                                            num19 = num9 + (num5 - xTextElement.LayoutHeight) / 2f;
                                            break;
                                        case VerticalAlignStyle.Bottom:
                                            num19 = num18 + num5 - xTextElement.LayoutHeight;
                                            break;
                                    }
                                }
                                if (xTextElement is XTextFieldBorderElement)
                                {
                                    XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)xTextElement;
                                    if (xTextFieldBorderElement2.float_6 > 0f)
                                    {
                                        xTextFieldBorderElement2.float_7 = num14 + num13 - xTextFieldBorderElement2.float_6 - num19;
                                    }
                                }
                            }
                            else
                            {
                                num19 = num9;
                            }
                            if (xTextElement.Left != num17 || xTextElement.Top != num19)
                            {
                                xTextElement.Left = num17;
                                xTextElement.Top = num19;
                                if (flag && !(xTextElement is XTextCharElement))
                                {
                                    ownerDocument.method_67(xTextElement);
                                }
                            }
                            num16 = num16 + xTextElement.LayoutWidth + xTextElement.WidthFix;
                            if (list.Contains(xTextElement))
                            {
                                xTextElement.Bounds.Offset(Left, Top);
                                OwnerContentElement.dictionary_0[xTextElement] = this;
                            }
                        }
                        break;
                    }
            }
            return true;
            IL_08ea:
            WriterUtils.smethod_23(xTextElementList);
            goto IL_08f2;
        }

        internal void method_20()
        {
            using (Enumerator enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    XTextElement current = enumerator.Current;
                    current.OwnerLine = this;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [ComVisible(false)]
        
        public ContentLayoutDirectionStyle method_21(XTextElement xtextElement_0)
        {
            ContentLayoutDirectionStyle runtimeLayoutDirection = RuntimeLayoutDirection;
            if (xtextElement_0 is XTextCharElement)
            {
                char charValue = ((XTextCharElement)xtextElement_0).CharValue;
                xtextElement_0.IsRightToLeft = false;
                if (Class126.smethod_8(charValue))
                {
                    xtextElement_0.IsRightToLeft = true;
                    return ContentLayoutDirectionStyle.RightToLeft;
                }
                if (!char.IsWhiteSpace(charValue))
                {
                    return ContentLayoutDirectionStyle.LeftToRight;
                }
            }
            return runtimeLayoutDirection;
        }

        
        public bool method_22()
        {
            if (LayoutInvalidate)
            {
            }
            LayoutInvalidate = false;
            if (base.Count == 0)
            {
                return false;
            }
            if (DesignWidth > 0f)
            {
                Width = DesignWidth;
            }
            int num = 0;
            method_16(-1f);
            ContentLayoutDirectionStyle runtimeLayoutDirection = RuntimeLayoutDirection;
            bool result = false;
            switch (runtimeLayoutDirection)
            {
                case ContentLayoutDirectionStyle.LeftToRight:
                    {
                        float float_2 = PaddingLeft;
                        for (int i = 0; i < base.Count; i++)
                        {
                            XTextElement xTextElement = base[i];
                            if (xTextElement is XTextShadowElement)
                            {
                                float num2 = ((XTextShadowElement)xTextElement).EntryElement.BoundsInContentElement.Left;
                                if (method_19(num, i - num, float_2, num2, runtimeLayoutDirection, bool_7: false))
                                {
                                    result = true;
                                }
                                num = i + 1;
                                float_2 = num2 + xTextElement.Width + xTextElement.WidthFix;
                            }
                            else if (i == base.Count - 1 && i - num >= 0 && method_19(num, i - num + 1, float_2, Width - PaddingRight, runtimeLayoutDirection, bool_7: true))
                            {
                                result = true;
                            }
                        }
                        Width = base.LastElement.Left + base.LastElement.Width;
                        break;
                    }
                case ContentLayoutDirectionStyle.RightToLeft:
                    {
                        float float_ = Width - PaddingRight;
                        for (int i = 0; i < base.Count; i++)
                        {
                            XTextElement xTextElement = base[i];
                            if (xTextElement is XTextShadowElement)
                            {
                                RectangleF boundsInContentElement = ((XTextShadowElement)xTextElement).EntryElement.BoundsInContentElement;
                                float num2 = boundsInContentElement.Left + boundsInContentElement.Width;
                                if (method_19(num, i - num, float_, num2, runtimeLayoutDirection, bool_7: false))
                                {
                                    result = true;
                                }
                                num = i + 1;
                                float_ = num2 + xTextElement.Width + xTextElement.WidthFix;
                            }
                            else if (i == base.Count - 1 && i - num >= 0 && method_19(num, i - num + 1, float_, PaddingLeft, runtimeLayoutDirection, bool_7: true))
                            {
                                result = true;
                            }
                        }
                        break;
                    }
            }
            f行间距 = xtextContentElement_0.method_38(this);
            float num3 = f段后间距 + f段前间距 + float_13;
            if (f行间距 > 0f)
            {
                num3 += f行间距;
            }
            else
            {
                num3 += ContentHeight + float_15;
                num3 = (float)Math.Ceiling(num3);
            }
            if (xtextContentElement_0 != null && xtextContentElement_0.RuntimeSpecifyFixedLineHeight > 0f)
            {
                num3 = xtextContentElement_0.RuntimeSpecifyFixedLineHeight;
            }
            if (HasEmphasisMarkChar)
            {
                num3 += xtextDocument_0.Options.ViewOptions.EmphasisMarkSize * 2f;
            }
            Height = num3;
            if (IsSectionLine)
            {
                if (SectionElement.CompressOwnerLineSpacing)
                {
                    SectionElement.Top = 0f;
                    Height = SectionElement.Height;
                }
            }
            else if (IsTableLine)
            {
                if (TableElement.CompressOwnerLineSpacing)
                {
                    TableElement.Top = 0f;
                    Height = TableElement.Height;
                }
            }
            else if (IsPageBreakLine)
            {
                PageBreakElement.Top = 0f;
                Height = PageBreakElement.Height;
            }
            method_23();
            bool_6 = false;
            bool_5 = false;
            return result;
        }

        internal void method_23()
        {
            if (xtextContentElement_0 == null || xtextContentElement_0.RuntimeGridLine == null)
            {
                return;
            }
            if (IsTableLine)
            {
                XTextTableElement tableElement = TableElement;
                if (tableElement.CompressOwnerLineSpacing)
                {
                    return;
                }
            }
            if (IsSectionLine)
            {
                XTextSectionElement sectionElement = SectionElement;
                if (sectionElement.CompressOwnerLineSpacing)
                {
                    return;
                }
            }
            float num = xtextContentElement_0.RuntimeGridLine.method_1(Height);
            if (Height != num)
            {
                float num2 = (num - Height) / 2f;
                float_16 += num2;
                Height = num;
                if (num2 > 0f)
                {
                    using (Enumerator enumerator = GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            enumerator.Current.Top += num2;
                        }
                    }
                }
            }
        }

        internal bool method_24(XTextElement xtextElement_0)
        {
            float contentWidth = ContentWidth;
            if (contentWidth + xtextElement_0.Width + 字符间距 > Width - PaddingLeft)
            {
                return false;
            }
            return true;
        }

        internal bool method_25(XTextElement xtextElement_0)
        {
            if ((IsTableLine || IsPageBreakLine) && !XTextContentElement.smethod_0(xtextElement_0))
            {
                return false;
            }
            float layoutWidth = xtextElement_0.LayoutWidth;
            RuntimeDocumentContentStyle runtimeStyle = xtextElement_0.RuntimeStyle;
            float_17 = -1f;
            bool_6 = true;
            method_16(-1f);
            bool flag;
            if (flag = (base.Count == 0))
            {
                float_18 = 0f;
            }
            List<XTextElement> freeLayoutElements = xtextContentElement_0.FreeLayoutElements;
            if (!(xtextElement_0 is XTextTableElement) && !(xtextElement_0 is XTextSectionElement))
            {
                method_27(xtextElement_0);
            }
            if (xtextElement_0 is XTextFieldBorderElement)
            {
                XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xtextElement_0;
                if (xTextFieldBorderElement.Parent is XTextInputFieldElementBase)
                {
                    XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextFieldBorderElement.Parent;
                    xTextInputFieldElementBase.vmethod_37(xTextFieldBorderElement);
                    layoutWidth = xtextElement_0.LayoutWidth;
                }
            }
            if (flag)
            {
                XTextParagraphFlagElement paragraphFlagElement = ParagraphFlagElement;
                bool flag2 = false;
                AddRaw(xtextElement_0);
                method_26(xtextElement_0);
                float_18 += layoutWidth;
                if (!(xtextElement_0 is XTextTableElement) && !(xtextElement_0 is XTextSectionElement))
                {
                    if (paragraphFlagElement != null)
                    {
                        RuntimeDocumentContentStyle runtimeStyle2 = paragraphFlagElement.RuntimeStyle;
                        if (xtextElement_0 == paragraphFlagElement.ParagraphFirstContentElement)
                        {
                            flag2 = true;
                            PaddingLeft = runtimeStyle2.LeftIndent + runtimeStyle2.FirstLineIndent;
                        }
                        else
                        {
                            PaddingLeft = runtimeStyle2.LeftIndent;
                        }
                    }
                    else
                    {
                        PaddingLeft = 0f;
                    }
                }
                xtextElement_0.Left = PaddingLeft;
                if (flag2 && paragraphFlagElement.ListStyle != 0)
                {
                    XTextParagraphListItemElement xTextParagraphListItemElement = new XTextParagraphListItemElement();
                    RuntimeDocumentContentStyle runtimeStyle2 = xtextElement_0.RuntimeStyle;
                    float num2 = xTextParagraphListItemElement.Height = (xTextParagraphListItemElement.Width = runtimeStyle2.Font.GetHeight(xtextElement_0.OwnerDocument.DocumentGraphicsUnit));
                    xTextParagraphListItemElement.ParagraphFlagElement = paragraphFlagElement;
                    using (DCGraphics dcgraphics_ = xtextElement_0.OwnerDocument.CreateDCGraphics())
                    {
                        xTextParagraphListItemElement.method_13(dcgraphics_);
                    }
                    xTextParagraphListItemElement.OwnerDocument = xtextElement_0.OwnerDocument;
                    xTextParagraphListItemElement.StyleIndex = xtextElement_0.StyleIndex;
                    method_13(0, xTextParagraphListItemElement);
                    method_26(xTextParagraphListItemElement);
                    float_18 += xTextParagraphListItemElement.Width + 字符间距;
                }
                if (runtimeStyle.LayoutAlign == ContentLayoutAlign.Surroundings)
                {
                    if (!freeLayoutElements.Contains(xtextElement_0))
                    {
                        freeLayoutElements.Add(xtextElement_0);
                    }
                    OwnerContentElement.dictionary_0[xtextElement_0] = this;
                }
                return true;
            }
            float letterSpacing = runtimeStyle.LetterSpacing;
            if (!(xtextElement_0 is XTextParagraphFlagElement) && (double)(float_18 + layoutWidth + letterSpacing + 字符间距) > (double)ClientWidth + 0.1)
            {
                bool flag3 = true;
                if (base.Count == 1 && base[0] is XTextFieldBorderElement)
                {
                    XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)base[0];
                    if (xTextFieldBorderElement2.Width < 5f)
                    {
                        flag3 = false;
                    }
                }
                if (flag3 && xtextElement_0 is XTextFieldBorderElement)
                {
                    XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)xtextElement_0;
                    if (xTextFieldBorderElement2.Position == BorderElementPosition.End)
                    {
                        flag3 = false;
                    }
                }
                if (flag3)
                {
                    return false;
                }
            }
            XTextElement xTextElement = base[base.Count - 1];
            xtextElement_0.Left = xTextElement.Left + xTextElement.LayoutWidth + 字符间距;
            AddRaw(xtextElement_0);
            method_26(xtextElement_0);
            if (xtextElement_0 is XTextCharElement)
            {
                XTextCharElement xTextCharElement = (XTextCharElement)xtextElement_0;
                if (xTextCharElement.CharValue == '\t')
                {
                    xTextCharElement.method_13();
                    layoutWidth = xTextCharElement.LayoutWidth;
                }
            }
            float_18 += layoutWidth + letterSpacing + 字符间距;
            if (!(xtextElement_0 is XTextShadowElement) && runtimeStyle.LayoutAlign == ContentLayoutAlign.Surroundings)
            {
                if (!freeLayoutElements.Contains(xtextElement_0))
                {
                    freeLayoutElements.Add(xtextElement_0);
                }
                OwnerContentElement.dictionary_0[xtextElement_0] = this;
            }
            return true;
        }

        private void method_26(XTextElement xtextElement_0)
        {
            if (xtextElement_0 is XTextTableElement)
            {
                xtextTableElement_0 = (XTextTableElement)xtextElement_0;
            }
            else if (xtextElement_0 is XTextPageBreakElement)
            {
                xtextPageBreakElement_0 = (XTextPageBreakElement)xtextElement_0;
            }
            else if (xtextElement_0 is XTextSectionElement)
            {
                xtextSectionElement_0 = (XTextSectionElement)xtextElement_0;
            }
        }

        private void method_27(XTextElement xtextElement_0)
        {
            bool_6 = true;
            method_16(-1f);
            if (OwnerContentElement.HasFreeLayoutElements)
            {
                List<XTextElement> freeLayoutElements = OwnerContentElement.FreeLayoutElements;
                _ = base.LastElement;
                RectangleF rect = new RectangleF(Left + ContentWidth, Top, xtextElement_0.Width, method_18());
                if (xtextElement_0 is XTextParagraphFlagElement)
                {
                    rect.Width = xtextElement_0.Width / 4f;
                }
                foreach (XTextElement item in freeLayoutElements)
                {
                    if (!Contains(item))
                    {
                        XTextLine xTextLine = item.OwnerLine;
                        if (xTextLine == null && xtextContentElement_0.dictionary_0.ContainsKey(item))
                        {
                            xTextLine = xtextContentElement_0.dictionary_0[item];
                        }
                        if (xTextLine != null)
                        {
                            if (OwnerContentElement.dictionary_0.ContainsKey(item))
                            {
                                xTextLine = OwnerContentElement.dictionary_0[item];
                            }
                            RectangleF bounds = item.Bounds;
                            bounds.Offset(xTextLine.Left, xTextLine.Top);
                            if (bounds.IntersectsWith(rect))
                            {
                                if (OwnerContentElement.ShadowElements.Count > 0)
                                {
                                    foreach (XTextShadowElement shadowElement in OwnerContentElement.ShadowElements)
                                    {
                                        XTextLine ownerLine = shadowElement.OwnerLine;
                                        if (ownerLine != null && OwnerContentElement.PrivateLines.Contains(ownerLine))
                                        {
                                            ownerLine.InvalidateState = true;
                                        }
                                    }
                                }
                                XTextShadowElement xTextShadowElement = new XTextShadowElement(item);
                                OwnerContentElement.ShadowElements.Add(xTextShadowElement);
                                xTextShadowElement.OwnerLine = this;
                                Add(xTextShadowElement);
                                float_18 += xTextShadowElement.Width + 字符间距;
                            }
                        }
                    }
                }
            }
        }

        internal XTextElement method_28()
        {
            if (base.Count > 1)
            {
                XTextElement result = base[base.Count - 1];
                RemoveAt(base.Count - 1);
                return result;
            }
            return null;
        }

        internal void method_29()
        {
            _ = Left + "*" + Top + "*" + Width + "*" + Height + "*" + Spacing + "*" + SpacingBeforeForParagraph + "*" + SpacingAfterForParagraph + "*" + PaddingLeft + "*" + base.Count;
            arrayList_0 = new ArrayList();
            arrayList_0.AddRange(this);
            rectangleF_0 = new RectangleF[base.Count];
            for (int i = 0; i < base.Count; i++)
            {
                rectangleF_0[i] = base[i].Bounds;
            }
        }

        internal bool method_30()
        {
            string a = Left + "*" + Top + "*" + Width + "*" + Height + "*" + Spacing + "*" + SpacingBeforeForParagraph + "*" + SpacingAfterForParagraph + "*" + PaddingLeft + "*" + base.Count;
            if (a != string_4)
            {
                return true;
            }
            if (arrayList_0 == null || arrayList_0.Count != base.Count)
            {
                return true;
            }
            int num = 0;
            while (true)
            {
                if (num < base.Count)
                {
                    if (arrayList_0[num] == base[num])
                    {
                        if (rectangleF_0[num].Equals(base[num].Bounds))
                        {
                            break;
                        }
                        num++;
                        continue;
                    }
                    return true;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        ///       返回表示对象数据的字符串
        ///       </summary>
        /// <returns>字符串</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (Enumerator enumerator = GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    XTextElement current = enumerator.Current;
                    stringBuilder.Append(current.ToString());
                }
            }
            return stringBuilder.ToString();
        }

        internal void method_31()
        {
            printPage_1 = null;
            xtextContentElement_0 = null;
            xtextDocument_0 = null;
            printPage_0 = null;
            xtextPageBreakElement_0 = null;
            xtextParagraphFlagElement_0 = null;
            xtextSectionElement_0 = null;
            xtextTableElement_0 = null;
            if (arrayList_0 != null)
            {
                arrayList_0.Clear();
                arrayList_0 = null;
            }
            string_4 = null;
        }
    }
}
