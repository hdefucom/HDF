using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
    /// <summary>
    ///       文档内容元素类型
    ///       </summary>
    /// <remarks>编制 袁永福</remarks>
    [Serializable]
    [Guid("00012345-6789-ABCD-EF01-234567890052")]
    [DocumentComment]
    
    public class XTextContentElement : XTextContainerElement
    {
        internal class Class11
        {
            private bool bool_0 = false;

            private int int_0 = -1;

            private bool bool_1 = false;

            private bool bool_2 = true;

            private bool bool_3 = false;

            private bool bool_4 = true;

            public bool method_0()
            {
                return bool_0;
            }

            public void method_1(bool bool_5)
            {
                bool_0 = bool_5;
            }

            public int method_2()
            {
                return int_0;
            }

            public void method_3(int int_1)
            {
                int_0 = int_1;
            }

            public bool method_4()
            {
                return bool_1;
            }

            public void method_5(bool bool_5)
            {
                bool_1 = bool_5;
            }

            public bool method_6()
            {
                return bool_2;
            }

            public void method_7(bool bool_5)
            {
                bool_2 = bool_5;
            }

            public bool method_8()
            {
                return bool_3;
            }

            public void method_9(bool bool_5)
            {
                bool_3 = bool_5;
            }

            public bool method_10()
            {
                return bool_4;
            }

            public void method_11(bool bool_5)
            {
                bool_4 = bool_5;
            }
        }

        internal const int int_10 = -10000;

        private DCGridLineInfo dcgridLineInfo_0 = null;

        private float float_5 = 0f;

        [NonSerialized]
        private List<XTextElement> list_0 = null;

        [NonSerialized]
        internal Dictionary<XTextElement, XTextLine> dictionary_0 = null;

        [NonSerialized]
        private List<XTextShadowElement> list_1 = null;

        private bool bool_17 = true;

        private bool bool_18 = false;

        [NonSerialized]
        private XTextLineList xtextLineList_0 = new XTextLineList();

        [NonSerialized]
        protected XTextElementList xtextElementList_2 = null;

        [NonSerialized]
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool bool_19 = false;

        [NonSerialized]
        internal bool bool_20 = false;

        [NonSerialized]
        private bool bool_21 = false;

        [NonSerialized]
        private float float_6 = 1f;

        internal int int_11 = 0;

        [NonSerialized]
        private GStruct20 gstruct20_0 = new GStruct20(bool_1: true);

        [NonSerialized]
        private GStruct20 gstruct20_1 = new GStruct20(bool_1: true);

        private int int_12 = 0;

        private float float_7 = float.NaN;

        [ThreadStatic]
        private static DrawStringFormatExt drawStringFormatExt_0 = null;

        [NonSerialized]
        private RectangleF rectangleF_0 = RectangleF.Empty;

        private float float_8 = 0f;

        [NonSerialized]
        private Class124 class124_0 = null;

        private static Random random_0 = new Random();

        [NonSerialized]
        private XTextElementList xtextElementList_3 = null;

        /// <summary>
        ///       网格线设置
        ///       </summary>
        [ComVisible(true)]
        [MemberExpressionable(MemberEffectLevel.ElementLayout)]
        [XmlElement]
        [Browsable(true)]
        [DefaultValue(null)]
        [Editor(typeof(DCGridLineInfoUIEditor), typeof(UITypeEditor))]
        
        public virtual DCGridLineInfo GridLine
        {
            get
            {
                return dcgridLineInfo_0;
            }
            set
            {
                dcgridLineInfo_0 = value;
            }
        }

        internal virtual DCGridLineInfo RuntimeGridLine => dcgridLineInfo_0;

        /// <summary>
        ///       指定的固定行高
        ///       </summary>
        /// <remarks>
        ///       若该属性大于0，则本容器中所有文档行的高度为指定值，不受段落设置影响。
        ///       </remarks>
        
        [DefaultValue(0f)]
        [HtmlAttribute]
        public float SpecifyFixedLineHeight
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
        ///       运行时使用的固定行高
        ///       </summary>
        internal float RuntimeSpecifyFixedLineHeight
        {
            get
            {
                if (SpecifyFixedLineHeight > 0f)
                {
                    return SpecifyFixedLineHeight;
                }
                RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                if (runtimeStyle.SpecifyGridLineStep > 0f)
                {
                    return runtimeStyle.SpecifyGridLineStep;
                }
                return 0f;
            }
        }

        /// <summary>
        ///       元素类型
        ///       </summary>
        [Browsable(false)]
        
        public override ElementType _ElementType => ElementType.Object;

        /// <summary>
        ///       是否包含自由排版的文档元素
        ///       </summary>
        /// <returns>
        /// </returns>
        
        public bool HasFreeLayoutElements => dictionary_0 != null && dictionary_0.Count > 0;

        /// <summary>
        ///       采用相对布局模式的文档元素对象列表
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public List<XTextElement> FreeLayoutElements
        {
            get
            {
                if (list_0 == null)
                {
                    list_0 = new List<XTextElement>();
                }
                return list_0;
            }
            set
            {
                if (list_0 != value)
                {
                    list_0 = value;
                }
            }
        }

        /// <summary>
        ///       内容中的影子元素列表
        ///       </summary>
        [XmlIgnore]
        [Browsable(false)]
        internal List<XTextShadowElement> ShadowElements
        {
            get
            {
                if (list_1 == null)
                {
                    list_1 = new List<XTextShadowElement>();
                }
                return list_1;
            }
        }

        /// <summary>
        ///       表格内容排版无效标志
        ///       </summary>
        internal bool LayoutInvalidate
        {
            get
            {
                return bool_17;
            }
            set
            {
                bool_17 = value;
            }
        }

        /// <summary>
        ///       内容为空
        ///       </summary>
        
        [XmlIgnore]
        [DefaultValue(false)]
        public bool IsEmpty
        {
            get
            {
                return bool_18;
            }
            set
            {
                bool_18 = value;
            }
        }

        /// <summary>
        ///       元素私有的文本行列表
        ///       </summary>
        [Browsable(true)]
        
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public XTextLineList PrivateLines
        {
            get
            {
                if (xtextLineList_0 == null)
                {
                    xtextLineList_0 = new XTextLineList();
                }
                return xtextLineList_0;
            }
        }

        /// <summary>
        ///       内容在容器中的顶端位置
        ///       </summary>
        internal float ContentTop
        {
            get
            {
                XTextLineList privateLines = PrivateLines;
                if (privateLines != null && privateLines.Count > 0)
                {
                    return privateLines[0].Top;
                }
                return 0f;
            }
        }

        /// <summary>
        ///       文档内容在容器中的低端位置
        ///       </summary>
        internal float ContentBottom
        {
            get
            {
                XTextLineList privateLines = PrivateLines;
                if (privateLines != null && privateLines.Count > 0)
                {
                    XTextLine lastLine = PrivateLines.LastLine;
                    return lastLine.Top + lastLine.Height;
                }
                return 0f;
            }
        }

        /// <summary>
        ///       内容高度
        ///       </summary>
        [Browsable(false)]
        [XmlIgnore]
        public float ContentHeight
        {
            get
            {
                float num = 0f;
                XTextLineList privateLines = PrivateLines;
                if (privateLines.Count > 0)
                {
                    num = privateLines.LastLine.Bottom - privateLines[0].Top;
                }
                if (HasFreeLayoutElements)
                {
                    foreach (XTextElement freeLayoutElement in FreeLayoutElements)
                    {
                        RectangleF boundsInContentElement = freeLayoutElement.BoundsInContentElement;
                        if (num < boundsInContentElement.Bottom + 1f)
                        {
                            num = boundsInContentElement.Bottom + 1f;
                        }
                    }
                }
                RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                return num + runtimeStyle.PaddingTop + runtimeStyle.PaddingBottom;
            }
        }

        /// <summary>
        ///       除去最后一行额外高度的内容高度
        ///       </summary>
        [XmlIgnore]
        [Browsable(false)]
        protected internal float ContentHeightExcludeLastLineAdditionHeight
        {
            get
            {
                float num = 0f;
                XTextLineList privateLines = PrivateLines;
                if (privateLines.Count > 0)
                {
                    num = privateLines.LastLine.Bottom - privateLines[0].Top;
                }
                if (HasFreeLayoutElements)
                {
                    foreach (XTextElement freeLayoutElement in FreeLayoutElements)
                    {
                        RectangleF boundsInContentElement = freeLayoutElement.BoundsInContentElement;
                        if (num < boundsInContentElement.Bottom + 1f)
                        {
                            num = boundsInContentElement.Bottom + 1f;
                        }
                    }
                }
                RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                return num + runtimeStyle.PaddingTop + runtimeStyle.PaddingBottom;
            }
        }

        /// <summary>
        ///       文档内容管理对象
        ///       </summary>
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [Browsable(false)]
        public XTextElementList PrivateContent
        {
            get
            {
                if (xtextElementList_2 == null)
                {
                    xtextElementList_3 = null;
                    xtextElementList_2 = new XTextElementList();
                    if (IsCollapsedSection)
                    {
                        return xtextElementList_2;
                    }
                    vmethod_32(xtextElementList_2, bool_17: true);
                    foreach (XTextElement item in xtextElementList_2)
                    {
                        if (item is XTextParagraphFlagElement)
                        {
                            ((XTextParagraphFlagElement)item).RuntimeLayoutDirection = ContentLayoutDirectionStyle.Default;
                        }
                    }
                    XTextElementList elements = Elements;
                    if (elements.Count > 0 && xtextElementList_2.method_1(elements.LastElement) < 0)
                    {
                        xtextElementList_2.Add(elements.LastElement);
                    }
                    int index = 0;
                    int count = xtextElementList_2.Count;
                    for (int i = 0; i < count; i++)
                    {
                        xtextElementList_2[i].int_3 = i;
                        XTextParagraphFlagElement xTextParagraphFlagElement = xtextElementList_2[i] as XTextParagraphFlagElement;
                        if (xTextParagraphFlagElement != null)
                        {
                            xTextParagraphFlagElement.ParagraphFirstContentElement = xtextElementList_2[index];
                            index = i + 1;
                        }
                    }
                }
                return xtextElementList_2;
            }
        }

        /// <summary>
        ///       内容垂直对齐方式
        ///       </summary>
        
        [Browsable(false)]
        
        public virtual VerticalAlignStyle ContentVertialAlign => VerticalAlignStyle.Top;

        /// <summary>
        ///       当前对象是否为收缩状态的文档节对象
        ///       </summary>
        private bool IsCollapsedSection
        {
            get
            {
                if (this is XTextSectionElement)
                {
                    return ((XTextSectionElement)this).RuntimeIsCollapsed;
                }
                return false;
            }
        }

        /// <summary>
        ///       声明文档内容高度发生改变，需要更新容器元素高度
        ///       </summary>
        internal bool InvalidateContentHeight => bool_21;

        /// <summary>
        ///       判断是否需要进行为分页线而调整文档行的位置
        ///       </summary>
        [Browsable(false)]
        internal virtual bool NeedFixLinePositionForPageLine
        {
            get
            {
                XTextDocument ownerDocument = OwnerDocument;
                if (ownerDocument != null && ownerDocument.FixContentForPageLineElements != null && ownerDocument.FixContentForPageLineElements.Contains(this))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///       DCWriter内部使用。自动缩放字体大小时计算出来的缩放比率,专门用于单元格的自动缩放字体的功能。
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(true)]
        [ReadOnly(true)]
        public float RateForAutoFixFontSizeMode
        {
            get
            {
                return float_6;
            }
            set
            {
                float_6 = value;
            }
        }

        /// <summary>
        ///       内容部分样式
        ///       </summary>
        [Browsable(false)]
        public virtual PageContentPartyStyle ContentPartyStyle
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return PageContentPartyStyle.Body;
                }
                XTextDocument ownerDocument = OwnerDocument;
                XTextElement xTextElement = this;
                while (true)
                {
                    if (xTextElement != null)
                    {
                        if (xTextElement is XTextDocumentContentElement)
                        {
                            if (xTextElement == ownerDocument.Body)
                            {
                                return PageContentPartyStyle.Body;
                            }
                            if (xTextElement == ownerDocument.Header)
                            {
                                return PageContentPartyStyle.Header;
                            }
                            if (xTextElement == ownerDocument.Footer)
                            {
                                return PageContentPartyStyle.Footer;
                            }
                            if (xTextElement == ownerDocument.HeaderForFirstPage)
                            {
                                return PageContentPartyStyle.HeaderForFirstPage;
                            }
                            if (xTextElement == ownerDocument.FooterForFirstPage)
                            {
                                break;
                            }
                        }
                        xTextElement = xTextElement.Parent;
                        continue;
                    }
                    return PageContentPartyStyle.Body;
                }
                return PageContentPartyStyle.FooterForFirstPage;
            }
        }

        /// <summary>
        ///       内容是否为空
        ///       </summary>
        
        [Browsable(false)]
        public override bool HasContentElement
        {
            get
            {
                if (Elements.Count == 0)
                {
                    return false;
                }
                if (Elements.Count == 1 && Elements[0] is XTextParagraphFlagElement)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///       用于显示行号的区域
        ///       </summary>
        protected RectangleF LineNumberDisplayArea
        {
            get
            {
                return rectangleF_0;
            }
            set
            {
                rectangleF_0 = value;
            }
        }

        /// <summary>
        ///       是否具有可见的内容网格线。
        ///       </summary>
        protected internal bool HasVisibleDCGridLine => RuntimeGridLine != null && RuntimeGridLine.Visible && RuntimeGridLine.RuntimeGridSpan > 0f;

        /// <summary>
        ///       文档元素边框信息列表
        ///       </summary>
        internal virtual Class124 RenderBorderInfos
        {
            get
            {
                if (class124_0 == null)
                {
                    class124_0 = new Class124();
                    foreach (XTextLine privateLine in PrivateLines)
                    {
                        if (!privateLine.IsTableLine && !privateLine.IsSectionLine && privateLine.ParagraphFlagElement != null)
                        {
                            RuntimeDocumentContentStyle runtimeDocumentContentStyle = privateLine.ParagraphFlagElement.RuntimeStyle;
                            if (!runtimeDocumentContentStyle.HasFullBorder)
                            {
                                runtimeDocumentContentStyle = null;
                            }
                            Class123 @class = null;
                            foreach (XTextElement item in privateLine)
                            {
                                XTextElement xTextElement = item.Parent;
                                if (item is XTextCharElement)
                                {
                                    xTextElement = item;
                                }
                                RuntimeDocumentContentStyle runtimeDocumentContentStyle2 = null;
                                while (xTextElement != null && !(xTextElement is XTextContentElement))
                                {
                                    RuntimeDocumentContentStyle runtimeStyle = xTextElement.RuntimeStyle;
                                    if (runtimeStyle.HasVisibleBorder)
                                    {
                                        runtimeDocumentContentStyle2 = runtimeStyle;
                                        break;
                                    }
                                    xTextElement = xTextElement.Parent;
                                }
                                if (runtimeDocumentContentStyle2 == null)
                                {
                                    runtimeDocumentContentStyle2 = runtimeDocumentContentStyle;
                                }
                                if (runtimeDocumentContentStyle2 == null)
                                {
                                    @class = null;
                                }
                                else if (!(@class?.method_6().EqualsBorderStyle(runtimeDocumentContentStyle2) ?? false))
                                {
                                    @class = new Class123();
                                    @class.method_0().Add(item);
                                    @class.method_9(privateLine);
                                    @class.method_7(runtimeDocumentContentStyle2);
                                    class124_0.Add(@class);
                                }
                                else
                                {
                                    @class.method_0().Add(item);
                                }
                            }
                        }
                    }
                    if (class124_0.Count > 0)
                    {
                        foreach (Class123 item2 in class124_0)
                        {
                            _ = item2.method_0().FirstElement;
                            _ = item2.method_0().LastElement;
                            RectangleF rectangleF = RectangleF.Empty;
                            RectangleF absBounds = AbsBounds;
                            foreach (XTextElement item3 in item2.method_0())
                            {
                                rectangleF = ((!rectangleF.IsEmpty) ? RectangleF.Union(rectangleF, item3.AbsBounds) : item3.AbsBounds);
                            }
                            rectangleF.Offset(0f - absBounds.Left, 0f - absBounds.Top);
                            item2.method_5(rectangleF);
                        }
                    }
                }
                return class124_0;
            }
        }

        /// <summary>
        ///       获得区间包含的段落对象列表
        ///       </summary>
        [Obsolete("请使用 ParagraphsFlags属性")]
        [XmlIgnore]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        
        public XTextElementList ParagraphsEOFs
        {
            get
            {
                XTextElementList xTextElementList = new XTextElementList();
                if (PrivateContent.Count > 0)
                {
                    foreach (XTextElement item in PrivateContent)
                    {
                        if (item is XTextParagraphFlagElement)
                        {
                            xTextElementList.Add(item);
                        }
                    }
                }
                return xTextElementList;
            }
        }

        /// <summary>
        ///       段落个数
        ///       </summary>
        [Browsable(false)]
        
        public int ParagraphCount
        {
            get
            {
                int num = 0;
                foreach (XTextElement item in PrivateContent)
                {
                    if (item is XTextParagraphFlagElement)
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        /// <summary>
        ///       获得区间包含的段落对象列表
        ///       </summary>
        [XmlIgnore]
        
        [Browsable(false)]
        public XTextElementList ParagraphsFlags
        {
            get
            {
                if (xtextElementList_3 == null)
                {
                    xtextElementList_3 = new XTextElementList();
                    if (xtextElementList_2 != null && xtextElementList_2.Count > 0)
                    {
                        foreach (XTextElement item in xtextElementList_2)
                        {
                            if (item is XTextParagraphFlagElement)
                            {
                                xtextElementList_3.Add(item);
                            }
                        }
                    }
                }
                return xtextElementList_3;
            }
        }

        /// <summary>
        ///       对象所属文档对象
        ///       </summary>
        [Browsable(false)]
        
        [XmlIgnore]
        public override XTextDocument OwnerDocument
        {
            get
            {
                return base.ElementOwnerDocument;
            }
            set
            {
                base.OwnerDocument = value;
                if (xtextLineList_0 != null)
                {
                    foreach (XTextLine item in xtextLineList_0)
                    {
                        item.xtextDocument_0 = value;
                    }
                }
            }
        }

        /// <summary>
        ///       返回表示对象的文本
        ///       </summary>
        
        [ReadOnly(true)]
        [XmlIgnore]
        [Browsable(true)]
        public override string Text
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                XTextElementList elements = Elements;
                if (elements != null && elements.Count > 0)
                {
                    XTextElement xTextElement = elements.LastElement;
                    if (!(xTextElement is XTextParagraphFlagElement))
                    {
                        xTextElement = null;
                    }
                    foreach (XTextElement item in elements)
                    {
                        if (item != xTextElement && item.RuntimeVisible && item.RuntimeStyle.DeleterIndex < 0)
                        {
                            stringBuilder.Append(item.OuterText);
                        }
                    }
                }
                return stringBuilder.ToString();
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        ///       初始化对象
        ///       </summary>
        protected XTextContentElement()
        {
        }

        /// <summary>
        ///       选中所有内容
        ///       </summary>
        /// <returns>操作是否成功</returns>
        
        public override bool Select()
        {
            OwnerDocument.method_124(this);
            XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
            int num = documentContentElement.Content.IndexOf(FirstContentElement);
            int num2 = documentContentElement.Content.IndexOf(LastContentElement) - 1;
            if (num2 >= num)
            {
                return documentContentElement.SetSelection(num, num2 - num + 1);
            }
            return false;
        }

        /// <summary>
        ///       选择第一行内容
        ///       </summary>
        /// <returns>操作是否成功</returns>
        [ComVisible(true)]
        
        public bool SelectFirstLine()
        {
            if (xtextLineList_0 != null && xtextLineList_0.Count > 0)
            {
                XTextLine xTextLine = xtextLineList_0[0];
                if (xTextLine.IsTableLine)
                {
                    xTextLine.TableElement.Select();
                    return true;
                }
                XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
                int num = documentContentElement.Content.IndexOf(xTextLine.FirstContentElement);
                int num2 = documentContentElement.Content.IndexOf(xTextLine.LastContentElement);
                if (num >= 0 && num2 >= 0)
                {
                    documentContentElement.Content.SelectionStartElementAsCurrentElement = true;
                    bool result;
                    if (result = documentContentElement.SetSelection(num, num2 - num + 1))
                    {
                        WriterControl.ScrollToCaretExt(ScrollToViewStyle.Top);
                    }
                    return result;
                }
            }
            return false;
        }

        private bool method_26(XTextElement xtextElement_0)
        {
            return xtextElement_0 is XTextObjectElement && xtextElement_0.RuntimeStyle.LayoutAlign == ContentLayoutAlign.Surroundings;
        }

        /// <summary>
        ///       判断文档行是否存在自由布局的元素
        ///       </summary>
        /// <param name="line">文档行对象</param>
        /// <returns>是否存在自由布局的元素</returns>
        private bool HasFreeLayoutElement(XTextLine line)
        {
            if (list_0 != null && list_0.Count > 0)
            {
                foreach (XTextElement item in list_0)
                {
                    if (item.OwnerLine == line)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///       添加子元素
        ///       </summary>
        /// <param name="element">元素对象</param>
        /// <returns>操作是否成功</returns>
        
        public override bool AppendChildElement(XTextElement element)
        {
            if (base.AppendChildElement(element))
            {
                bool_18 = false;
                return true;
            }
            return false;
        }

        internal XTextLine method_27(float float_9, float float_10, bool bool_22)
        {
            if (PrivateLines.Count == 0)
            {
                return null;
            }
            float x = float_9 - AbsLeft;
            float num = float_10 - AbsTop;
            XTextLine xTextLine = null;
            if (bool_22)
            {
                foreach (XTextLine privateLine in PrivateLines)
                {
                    if (privateLine.Visible && new RectangleF(privateLine.Left, privateLine.Top, privateLine.Width, privateLine.ViewHeight).Contains(x, num))
                    {
                        xTextLine = privateLine;
                        break;
                    }
                }
            }
            else
            {
                foreach (XTextLine privateLine2 in PrivateLines)
                {
                    if (privateLine2.Visible && privateLine2.Top + privateLine2.ViewHeight > num)
                    {
                        int num2 = PrivateLines.IndexOf(privateLine2);
                        if (num2 > 0)
                        {
                            XTextLine xTextLine2 = PrivateLines[num2 - 1];
                            float num3 = (xTextLine2.Top + xTextLine2.ViewHeight + privateLine2.Top) / 2f;
                            xTextLine = ((!(num > num3)) ? xTextLine2 : privateLine2);
                        }
                        else
                        {
                            xTextLine = privateLine2;
                        }
                        break;
                    }
                }
            }
            if (xTextLine == null && HasFreeLayoutElements)
            {
                foreach (XTextElement freeLayoutElement in FreeLayoutElements)
                {
                    XTextLine current = freeLayoutElement.OwnerLine;
                    if (new RectangleF(current.Left + freeLayoutElement.Left, current.Top + freeLayoutElement.Top, freeLayoutElement.Width, freeLayoutElement.Height).Contains(x, num))
                    {
                        xTextLine = current;
                        break;
                    }
                }
            }
            if (!bool_22 && xTextLine == null)
            {
                xTextLine = PrivateLines.LastLine;
            }
            return xTextLine;
        }

        
        protected internal int method_28(int int_13)
        {
            if (PrivateLines.Count == 0)
            {
                return 0;
            }
            foreach (XTextLine privateLine in PrivateLines)
            {
                privateLine.GlobalIndex = int_13;
                if (privateLine.IsTableLine)
                {
                    privateLine.GlobalIndex = int_13;
                    XTextTableElement tableElement = privateLine.TableElement;
                    foreach (XTextTableRowElement row in tableElement.Rows)
                    {
                        if (row.RuntimeVisible)
                        {
                            int num = int_13;
                            foreach (XTextTableCellElement cell in row.Cells)
                            {
                                if (cell.RuntimeVisible)
                                {
                                    int val = cell.method_28(int_13);
                                    num = Math.Max(num, val);
                                }
                            }
                            int_13 = num;
                        }
                    }
                }
                else if (privateLine.IsSectionLine)
                {
                    privateLine.GlobalIndex = int_13;
                    XTextSectionElement sectionElement = privateLine.SectionElement;
                    int_13 = sectionElement.method_28(int_13);
                }
                else
                {
                    privateLine.GlobalIndex = int_13;
                    int_13++;
                }
            }
            return int_13;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        
        public void method_29(XTextLine xtextLine_1, XTextLine xtextLine_2)
        {
            if (xtextLine_1 == xtextLine_2 && xtextLine_1 != null)
            {
                xtextLine_1.InvalidateState = true;
                return;
            }
            int num = PrivateLines.IndexOf(xtextLine_1);
            if (num < 0)
            {
                num = 0;
            }
            int num2 = PrivateLines.IndexOf(xtextLine_2);
            if (num2 < 0)
            {
                num2 = PrivateLines.Count - 1;
            }
            for (int i = num; i <= num2; i++)
            {
                PrivateLines[i].InvalidateState = true;
            }
        }

        /// <summary>
        ///       加载文档后的处理
        ///       </summary>
        public override void AfterLoad(ElementLoadEventArgs args)
        {
            xtextLineList_0 = null;
            xtextElementList_2 = null;
            list_1 = null;
            list_0 = null;
            dictionary_0 = null;
            base.AfterLoad(args);
            FixElements();
        }

        /// <summary>
        ///       清空文档内容
        ///       </summary>
        public virtual void Clear()
        {
            xtextElementList_2 = null;
            xtextLineList_0 = null;
            Elements.Clear();
            Elements.Add(OwnerDocument.CreateElementByType(typeof(XTextParagraphFlagElement)));
            vmethod_36(bool_22: true);
            ExecuteLayout();
        }

        /// <summary>
        ///       删除子元素
        ///       </summary>
        /// <param name="element">元素对象</param>
        /// <returns>操作是否成功</returns>
        
        public override bool RemoveChild(XTextElement element)
        {
            if (element == Elements.LastElement)
            {
                return false;
            }
            return base.RemoveChild(element);
        }

        internal override void vmethod_29(XTextElementList xtextElementList_4)
        {
            xtextElementList_2 = null;
            xtextLineList_0 = null;
            dictionary_0 = null;
            list_0 = null;
        }

        
        public override void FixDomState()
        {
            base.FixDomState();
            FixElements();
        }

        /// <summary>
        ///       修正元素内容
        ///       </summary>
        
        public virtual void FixElements()
        {
            XTextElementList elements = Elements;
            if (elements.Count == 0 || !(elements.LastElement is XTextParagraphFlagElement))
            {
                XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
                xTextParagraphFlagElement.AutoCreate = true;
                xTextParagraphFlagElement.SetParentRaw(this);
                xTextParagraphFlagElement.method_5(OwnerDocument);
                bool_18 = false;
                elements.AddRaw(xTextParagraphFlagElement);
            }
        }

        /// <summary>
        ///       添加内容元素
        ///       </summary>
        /// <param name="element">文档元素</param>
        
        
        public virtual void AppendContentElement(XTextElement element)
        {
            int num = 8;
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            AppendContentElements(new XTextElementList(element));
        }

        /// <summary>
        ///       添加内容元素
        ///       </summary>
        /// <param name="elements">文档元素列表</param>
        
        
        public virtual void AppendContentElements(XTextElementList elements)
        {
            int num = 10;
            if (elements == null)
            {
                throw new ArgumentNullException("elements");
            }
            if (elements.Count != 0)
            {
                foreach (XTextElement element in elements)
                {
                    element.Parent = this;
                    element.OwnerDocument = OwnerDocument;
                }
                if (Elements.LastContentElement is XTextParagraphFlagElement)
                {
                    Elements.method_12(Elements.Count - 1, elements);
                }
                else
                {
                    Elements.AddRange(elements);
                }
            }
        }

        
        public virtual void vmethod_36(bool bool_22)
        {
            Class11 @class = new Class11();
            @class.method_11(bool_22);
            @class.method_5(bool_5: false);
            @class.method_7(bool_5: true);
            vmethod_37(@class);
        }

        internal virtual void vmethod_37(Class11 class11_0)
        {
            if (!class11_0.method_0() && WriterControl != null && WriterControl.InnerViewControl != null && WriterControl.InnerViewControl.ViewHandleManager != null)
            {
                WriterControl.InnerViewControl.ViewHandleManager.method_0();
            }
            if (class11_0.method_6())
            {
                vmethod_31(!class11_0.method_8());
            }
            if (OwnerDocument != null)
            {
                OwnerDocument.UpdateContentVersion();
            }
            list_0 = null;
            class124_0 = null;
            xtextElementList_2 = null;
            if (!class11_0.method_4())
            {
                FixElements();
            }
            if (!class11_0.method_10())
            {
                return;
            }
            for (XTextElement parent = Parent; parent != null; parent = parent.Parent)
            {
                if (parent is XTextContentElement)
                {
                    XTextContentElement xTextContentElement = (XTextContentElement)parent;
                    if (class11_0.method_8())
                    {
                        class11_0.method_7(bool_5: false);
                    }
                    xTextContentElement.vmethod_37(class11_0);
                }
            }
        }

        
        public XTextElementList method_30(XTextElementList xtextElementList_4)
        {
            int num = 13;
            if (xtextElementList_4 == null)
            {
                throw new ArgumentNullException("elements");
            }
            XTextElementList xTextElementList = new XTextElementList();
            XTextParagraphElement xTextParagraphElement = new XTextParagraphElement();
            xTextParagraphElement.OwnerDocument = OwnerDocument;
            xTextParagraphElement.Parent = this;
            xTextElementList.Add(xTextParagraphElement);
            foreach (XTextElement item in xtextElementList_4)
            {
                if (item is XTextParagraphFlagElement)
                {
                    XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)item;
                    xTextParagraphElement.StyleIndex = xTextParagraphFlagElement.StyleIndex;
                    xTextParagraphElement.Elements.Add(item);
                    xTextParagraphElement = new XTextParagraphElement();
                    xTextParagraphElement.OwnerDocument = OwnerDocument;
                    xTextParagraphElement.Parent = this;
                    xTextElementList.Add(xTextParagraphElement);
                }
                else
                {
                    xTextParagraphElement.Elements.Add(item);
                }
            }
            foreach (XTextParagraphElement item2 in xTextElementList)
            {
                XTextElementList collection = WriterUtils.smethod_60(item2.Elements, bool_2: false);
                item2.Elements.Clear();
                item2.Elements.AddRange(collection);
            }
            return xTextElementList;
        }

        
        public bool method_31(int int_13)
        {
            return vmethod_38(int_13, -1, bool_22: false);
        }

        
        public virtual bool vmethod_38(int int_13, int int_14, bool bool_22)
        {
            return vmethod_39(int_13, int_14, bool_22, bool_23: true);
        }

        
        public virtual bool vmethod_39(int int_13, int int_14, bool bool_22, bool bool_23)
        {
            if (UIIsUpdating)
            {
                return false;
            }
            if (IsCollapsedSection)
            {
                return false;
            }
            bool bool_24 = int_13 != -10000;
            bool_19 = false;
            int_13 = PrivateContent.FixElementIndex(int_13);
            XTextDocument ownerDocument = OwnerDocument;
            bool flag = true;
            XTextElement xTextElement = PrivateContent[int_13];
            if (xTextElement.OwnerLine != null && xTextElement.OwnerLine.IndexOf(xTextElement) == 0)
            {
                int num = PrivateLines.IndexOf(xTextElement.OwnerLine);
                if (num > 0)
                {
                    XTextLine xTextLine = PrivateLines[num - 1];
                    if (xTextLine.HasLineEndElement)
                    {
                        XTextElement lastElement = xTextLine.LastElement;
                        if (PrivateContent.Contains(lastElement))
                        {
                            flag = false;
                        }
                    }
                }
            }
            if (flag && int_13 > 0)
            {
                int_13--;
            }
            int_13 = PrivateContent.FixElementIndex(int_13);
            if (bool_20)
            {
                bool_20 = false;
                PrivateLines.Clear();
                int_13 = 0;
            }
            XTextElement xtextElement_ = PrivateContent.SafeGet(int_14);
            float height = Height;
            Class121 @class = new Class121(PrivateContent[int_13], xtextElement_, ContentVertialAlign);
            @class.method_1(bool_24);
            if (vmethod_42(@class))
            {
                base.DocumentContentElement.method_28(0);
                bool flag2 = !ownerDocument.PageRefreshed;
                if (this is XTextTableCellElement)
                {
                    XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)this;
                    if (xTextTableCellElement.RowSpan != 1 || !(xTextTableCellElement.OwnerRow.RuntimeSpecifyHeight < 0f))
                    {
                        for (XTextElement xTextElement2 = this; xTextElement2 != null; xTextElement2 = xTextElement2.Parent)
                        {
                            if (xTextElement2 is XTextTableCellElement)
                            {
                                XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextElement2;
                                XTextTableElement ownerTable = xTextTableCellElement2.OwnerTable;
                                if (ownerTable.OwnerLine == null)
                                {
                                    return false;
                                }
                                if (xTextTableCellElement2 != this)
                                {
                                    height = xTextTableCellElement2.Height;
                                }
                                if (xTextTableCellElement2 != this)
                                {
                                    xTextTableCellElement2.Height = 0f;
                                    xTextTableCellElement2.Width = 0f;
                                }
                                ownerTable.method_33(bool_26: true);
                                if (xTextTableCellElement2.Height != height)
                                {
                                    ownerTable.OwnerLine.method_22();
                                    ownerTable.OwnerLine.InvalidateState = true;
                                    ownerTable.ContentElement.method_33();
                                    flag2 = true;
                                }
                            }
                            else if (xTextElement2 is XTextSectionElement)
                            {
                                XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextElement2;
                                if (xTextSectionElement.OwnerLine == null)
                                {
                                    return false;
                                }
                                if (xTextSectionElement != this)
                                {
                                    height = xTextSectionElement.Height;
                                }
                                if (xTextSectionElement != this)
                                {
                                    xTextSectionElement.ExecuteLayout();
                                    if (height != xTextSectionElement.Height)
                                    {
                                        xTextSectionElement.OwnerLine.method_22();
                                        xTextSectionElement.OwnerLine.InvalidateState = true;
                                        flag2 = true;
                                    }
                                }
                            }
                        }
                        if (flag2)
                        {
                            flag2 = true;
                            base.DocumentContentElement.vmethod_41(base.DocumentContentElement.ContentVertialAlign, bool_22: true, bool_23: true);
                        }
                    }
                }
                else if (this is XTextSectionElement)
                {
                    if (base.OwnerLine == null)
                    {
                        return false;
                    }
                    XTextSectionElement xTextSectionElement2 = (XTextSectionElement)this;
                    if (!(xTextSectionElement2.SpecifyHeight < 0f))
                    {
                        XTextDocumentBodyElement xTextDocumentBodyElement = (XTextDocumentBodyElement)Parent;
                        base.OwnerLine.method_22();
                        base.OwnerLine.InvalidateState = true;
                        if (xTextDocumentBodyElement != this)
                        {
                            height = xTextDocumentBodyElement.Height;
                        }
                        xTextDocumentBodyElement.vmethod_41(VerticalAlignStyle.Top, bool_22: true, bool_23: false);
                        xTextDocumentBodyElement.vmethod_40();
                        if (xTextDocumentBodyElement.Height != height)
                        {
                            flag2 = true;
                        }
                        if (flag2)
                        {
                            flag2 = true;
                            base.DocumentContentElement.vmethod_41(base.DocumentContentElement.ContentVertialAlign, bool_22: true, bool_23: true);
                        }
                    }
                }
                else
                {
                    flag2 = true;
                    if (!ownerDocument.PageRefreshed)
                    {
                        flag2 = true;
                    }
                }
                bool_19 = flag2;
                if (flag2)
                {
                    ownerDocument.PageRefreshed = false;
                    if (!bool_22)
                    {
                        ownerDocument?.RefreshPages();
                        if (ownerDocument.EditorControl != null && !ownerDocument.EditorControl.IsUpdating)
                        {
                            ownerDocument.EditorControl.UpdatePages();
                            if (bool_23)
                            {
                                ownerDocument.EditorControl.UpdateTextCaret();
                            }
                            ownerDocument.EditorControl.InnerViewControl.Invalidate();
                        }
                    }
                }
            }
            else if (!bool_22 && ownerDocument != null)
            {
                if (!ownerDocument.PageRefreshed)
                {
                    ownerDocument.RefreshPages();
                }
                if (ownerDocument != null && ownerDocument.EditorControl != null && !ownerDocument.EditorControl.IsUpdating && bool_23)
                {
                    ownerDocument.EditorControl.UpdateTextCaret();
                }
            }
            return true;
        }

        
        public void method_32(XTextElementList xtextElementList_4, bool bool_22, bool bool_23)
        {
            int num = 18;
            if (xtextElementList_4 != null && xtextElementList_4.Count != 0)
            {
                int num2 = int.MaxValue;
                int num3 = -1;
                using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
                {
                    DocumentPaintEventArgs args = OwnerDocument.method_55(dcgraphics_);
                    foreach (XTextElement item in xtextElementList_4)
                    {
                        int num4 = PrivateContent.IndexOf(item);
                        if (num4 < 0)
                        {
                            throw new Exception("Element no in content");
                        }
                        if (num2 > num4)
                        {
                            num2 = num4;
                        }
                        if (item.SizeInvalid || item.ViewInvalid)
                        {
                            item.InvalidateView();
                        }
                        if (item.SizeInvalid)
                        {
                            item.RefreshSize(args);
                            item.InvalidateView();
                        }
                        item.ViewInvalid = false;
                        if (num4 > 0 && num4 > num3)
                        {
                            num3 = num4;
                        }
                    }
                    OwnerDocument.ContentStyles.method_8(dcgraphics_);
                }
                vmethod_38(num2, num3, bool_23);
                if (!bool_22)
                {
                    base.DocumentContentElement.Content.AutoClearSelection = true;
                    base.DocumentContentElement.Content.MoveToPosition(num2);
                }
            }
        }

        /// <summary>
        ///       对整个内容执行重新排版操作
        ///       </summary>
        
        public override void ExecuteLayout()
        {
            Width = OwnerDocument.PageSettings.ViewClientWidth;
            if (OwnerDocument.PageViewMode == PageViewMode.AutoLine)
            {
                Width = OwnerDocument.Width;
            }
            PrivateLines.Clear();
            foreach (XTextElement item in PrivateContent)
            {
                item.OwnerLine = null;
            }
            Class121 class121_ = new Class121(null, null, ContentVertialAlign);
            vmethod_42(class121_);
        }

        
        public virtual void vmethod_40()
        {
            bool_21 = false;
            Height = ContentHeight;
        }

        internal void method_33()
        {
            for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.Parent)
            {
                if (xTextElement is XTextContentElement)
                {
                    ((XTextContentElement)xTextElement).bool_21 = true;
                }
            }
        }

        internal bool method_34()
        {
            if (PrivateLines == null || PrivateLines.Count == 0)
            {
                return false;
            }
            XTextDocument ownerDocument = OwnerDocument;
            RectangleF absBounds = AbsBounds;
            int num = 0;
            bool flag = false;
            bool flag2 = false;
            foreach (PrintPage page in ownerDocument.Pages)
            {
                float bottom = page.Bottom;
                if (bottom >= absBounds.Bottom - 3f)
                {
                    break;
                }
                if (!(bottom <= absBounds.Top + 3f))
                {
                    if (!flag2)
                    {
                        flag2 = true;
                        foreach (XTextLine privateLine in PrivateLines)
                        {
                            privateLine.Top = privateLine.NativeTop;
                        }
                    }
                    float num2 = 0f;
                    if (PrivateLines.Count > 0)
                    {
                        num2 = ClientHeight - PrivateLines.LastLine.Bottom;
                    }
                    for (int i = num; i < PrivateLines.Count; i++)
                    {
                        XTextLine current2 = PrivateLines[i];
                        RectangleF absBounds2 = current2.AbsBounds;
                        if (bottom >= absBounds2.Top + 5f && bottom <= absBounds2.Bottom - 3f)
                        {
                            float num3 = bottom - absBounds2.Top;
                            if (num3 > num2)
                            {
                                num3 = num2;
                            }
                            num2 -= num3;
                            for (int j = i; j < PrivateLines.Count; j++)
                            {
                                PrivateLines[j].Top += num3;
                                flag = true;
                            }
                            num = i;
                            break;
                        }
                    }
                }
            }
            if (flag)
            {
                method_40();
            }
            return flag;
        }

        internal virtual bool vmethod_41(VerticalAlignStyle verticalAlignStyle_0, bool bool_22, bool bool_23)
        {
            if (PrivateLines.Count == 0)
            {
                return false;
            }
            if (Height == 0f)
            {
                return false;
            }
            class124_0 = null;
            if (!(this is XTextDocumentContentElement))
            {
            }
            float[] array = new float[PrivateLines.Count * 2];
            for (int i = 0; i < PrivateLines.Count; i++)
            {
                XTextLine xTextLine = PrivateLines[i];
                array[i * 2] = xTextLine.NativeTop;
                array[i * 2 + 1] = xTextLine.Height;
            }
            float num = 0f;
            foreach (XTextLine privateLine in PrivateLines)
            {
                num += privateLine.Height;
            }
            float num2 = 0f;
            RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
            switch (verticalAlignStyle_0)
            {
                case VerticalAlignStyle.Top:
                    num2 = runtimeStyle.PaddingTop;
                    break;
                case VerticalAlignStyle.Middle:
                    num2 = (Height - runtimeStyle.PaddingTop - runtimeStyle.PaddingBottom - num) / 2f;
                    num2 = runtimeStyle.PaddingTop + Math.Max(0f, num2);
                    break;
                case VerticalAlignStyle.Bottom:
                    num2 = Height - runtimeStyle.PaddingTop - runtimeStyle.PaddingBottom - num;
                    num2 = runtimeStyle.PaddingTop + Math.Max(0f, num2);
                    break;
            }
            foreach (XTextLine privateLine2 in PrivateLines)
            {
                if ((privateLine2.IsTableLine || privateLine2.IsSectionLine || privateLine2.IsPageBreakLine) && HasFreeLayoutElements)
                {
                    foreach (XTextElement freeLayoutElement in FreeLayoutElements)
                    {
                        XTextLine ownerLine = freeLayoutElement.OwnerLine;
                        if (PrivateLines.IndexOf(ownerLine) < PrivateLines.IndexOf(privateLine2))
                        {
                            float num3 = ownerLine.Top + freeLayoutElement.Top + freeLayoutElement.Height;
                            if (num2 < num3)
                            {
                                num2 = num3;
                            }
                        }
                    }
                }
                privateLine2.NativeTop = num2;
                privateLine2.Top = privateLine2.NativeTop;
                num2 = privateLine2.Top + privateLine2.Height;
            }
            bool flag = false;
            if (bool_23)
            {
                foreach (XTextLine privateLine3 in PrivateLines)
                {
                    if (privateLine3.IsTableLine)
                    {
                        XTextTableElement tableElement = privateLine3.TableElement;
                        foreach (XTextTableCellElement cell in tableElement.Cells)
                        {
                            if (cell.RuntimeVisible && cell.vmethod_41(cell.RuntimeStyle.VerticalAlign, bool_22, bool_23))
                            {
                                flag = true;
                            }
                        }
                    }
                    else if (privateLine3.IsSectionLine)
                    {
                        XTextSectionElement sectionElement = privateLine3.SectionElement;
                        if (sectionElement.vmethod_41(VerticalAlignStyle.Top, bool_22, bool_23))
                        {
                            flag = true;
                        }
                    }
                }
            }
            if (!flag)
            {
                XTextDocument ownerDocument = OwnerDocument;
                for (int i = 0; i < PrivateLines.Count; i++)
                {
                    XTextLine xTextLine = PrivateLines[i];
                    if (xTextLine.NativeTop != array[i * 2] || xTextLine.Height != array[i * 2 + 1])
                    {
                        foreach (XTextElement item in xTextLine)
                        {
                            ownerDocument.method_67(item);
                        }
                        flag = true;
                    }
                }
            }
            if (NeedFixLinePositionForPageLine && method_34())
            {
                flag = true;
            }
            if (flag || InvalidateContentHeight)
            {
                vmethod_40();
            }
            return flag;
        }

        private void method_35()
        {
            if (PrivateLines != null)
            {
                foreach (XTextLine privateLine in PrivateLines)
                {
                    privateLine.NativeTop = privateLine.Top;
                }
            }
        }

        
        internal static bool smethod_0(XTextElement xtextElement_0)
        {
            DocumentBehaviorOptions behaviorOptions = xtextElement_0.OwnerDocument.Options.BehaviorOptions;
            if (xtextElement_0 is XTextFieldBorderElement)
            {
                XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xtextElement_0;
                if (string.IsNullOrEmpty(xTextFieldBorderElement.BorderText))
                {
                    XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xtextElement_0.Parent;
                    if (xTextFieldBorderElement == xTextFieldElementBase.EndElement && behaviorOptions.CompressLayoutForFieldBorder)
                    {
                        return true;
                    }
                }
            }
            else if (xtextElement_0 is XTextParagraphFlagElement && behaviorOptions.ParagraphFlagFollowTableOrSection)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// RefreshLine
        /// 重新分行
        /// </summary>
        /// <param name="class121_0"></param>
        /// <returns></returns>
        internal virtual bool vmethod_42(Class121 class121_0)
        {
            int num = 1;
            int_11++;
            if (UIIsUpdating)
            {
                return false;
            }
            if (IsCollapsedSection)
            {
                return false;
            }
            float_7 = ClientWidth;
            if (RuntimeGridLine != null)
            {
                RuntimeGridLine.method_0(OwnerDocument.method_95(OwnerDocument.PageSettings), OwnerDocument.DocumentGraphicsUnit, RateForAutoFixFontSizeMode);
            }
            XTextElement xTextElement = class121_0.method_2();
            XTextElement xTextElement2 = class121_0.method_4();
            VerticalAlignStyle verticalAlignStyle = class121_0.method_6();
            int_12 = 0;
            class124_0 = null;
            XTextDocument ownerDocument = OwnerDocument;
            ownerDocument.ContentStyles.method_4();
            LayoutInvalidate = false;
            bool flag = true;
            if (Width == 0f)
            {
                if (this is XTextDocumentContentElement)
                {
                    Width = ownerDocument.PageSettings.ViewClientWidth;
                }
            }
            else if (Width < 0f)
            {
                Width = ownerDocument.PageSettings.ViewClientWidth;
            }
            XTextElementList privateContent = PrivateContent;
            XTextLineList privateLines = PrivateLines;
            if (privateContent.Count == 0)
            {
                privateLines.Clear();
                return flag;
            }
            bool flag2 = xTextElement == null || privateLines.Count == 0;
            DocumentControler documentControler = ownerDocument.DocumentControler;
            int[] array = new int[privateLines.Count * 2];
            float[] array2 = new float[privateLines.Count * 2];
            for (int i = 0; i < privateLines.Count; i++)
            {
                XTextLine xTextLine = privateLines[i];
                array2[i * 2] = xTextLine.Top;
                array2[i * 2 + 1] = xTextLine.Height;
                array[i * 2] = xTextLine.GlobalIndex;
                array[i * 2 + 1] = xTextLine.IndexInPage;
            }
            int num2 = -1;
            if (xTextElement2 != null)
            {
                num2 = privateContent.IndexOf(xTextElement2);
            }
            if (xTextElement == null)
            {
                xTextElement = privateContent[0];
            }
            int num3 = privateContent.IndexOf(xTextElement);
            if (num3 < 0)
            {
                throw new Exception("未找到起始元素");
            }
            int num4 = 0;
            for (int i = num3; i >= 0; i--)
            {
                XTextElement xTextElement3 = privateContent[i];
                if (xTextElement3.OwnerLine != null)
                {
                    XTextLine ownerLine = xTextElement3.OwnerLine;
                    num4 = privateLines.IndexOf(ownerLine);
                    if (num4 >= 0)
                    {
                        num4--;
                        if (num4 < 0)
                        {
                            num4 = 0;
                        }
                        break;
                    }
                }
            }
            if (num4 < 0)
            {
                num4 = 0;
            }
            if (num3 > 0)
            {
                _ = privateContent[num3 - 1].OwnerLine;
            }
            int num5 = privateLines.Count - 1;
            if (num2 >= 0)
            {
                for (int i = num2; i < privateContent.Count; i++)
                {
                    if (privateContent[i].OwnerLine == null)
                    {
                        continue;
                    }
                    num5 = privateLines.IndexOf(privateContent[i].OwnerLine);
                    if (num5 < 0)
                    {
                        continue;
                    }
                    for (int j = num5; j < privateLines.Count; j++)
                    {
                        if (privateLines[j].LastElement is IXTextParagraphFlagElement)
                        {
                            num5 = j;
                            break;
                        }
                    }
                    num5 = Math.Min(num5 + 2, privateLines.Count - 1);
                    break;
                }
            }
            if (xTextElement.OwnerLine != null)
            {
                XTextLine ownerLine2 = xTextElement.OwnerLine;
                if (num3 == 0)
                {
                    if (privateLines.Count > 0)
                    {
                        XTextLine xTextLine = privateLines[0];
                        bool flag3 = true;
                        foreach (XTextElement item2 in xTextLine)
                        {
                            if (privateContent.Contains(item2))
                            {
                                flag3 = false;
                                break;
                            }
                        }
                        if (flag3)
                        {
                            xTextElement.OwnerLine = null;
                            privateLines.Clear();
                            list_1 = null;
                        }
                    }
                }
                else
                {
                    foreach (XTextElement item3 in ownerLine2)
                    {
                        int num6 = privateContent.IndexOf(item3);
                        if (num6 >= 0 && num3 > num6)
                        {
                            num3 = num6;
                            xTextElement = item3;
                        }
                    }
                }
            }
            _ = RuntimeStyle;
            List<XTextElement> list = new List<XTextElement>();
            XTextLine xTextLine2 = null;
            List<XTextElement> freeLayoutElements = FreeLayoutElements;
            freeLayoutElements.Clear();
            for (int i = 0; i < num3; i++)
            {
                XTextElement current = privateContent[i];
                if (method_26(current))
                {
                    freeLayoutElements.Add(current);
                }
            }
            dictionary_0 = new Dictionary<XTextElement, XTextLine>();
            XTextLineList xTextLineList = new XTextLineList();
            XTextLine xTextLine3 = method_39(privateLines.method_1(privateContent[num3].OwnerLine));
            xTextLineList.Add(xTextLine3);
            Class113 @class = new Class113(privateContent, num3, privateContent.Count - num3);
            bool flag4 = true;
            while (@class.method_3() > 0)
            {
                bool flag5 = false;
                XTextElement current = @class.method_2();
                if (current is XTextObjectElement && current.RuntimeZOrderStyle != 0)
                {
                    base.DocumentContentElement.method_55();
                }
                if (current is XTextHorizontalLineElement)
                {
                    current.Width = ClientWidth - 10f;
                }
                int i;
                if (xTextLine3.Count == 0)
                {
                    if (current is XTextCharElement)
                    {
                        XTextCharElement xTextCharElement = (XTextCharElement)current;
                        if (xTextCharElement.CharValue == '\t')
                        {
                            xTextCharElement.method_13();
                        }
                    }
                    xTextLine3.method_25(current);
                    if (documentControler.vmethod_10(current))
                    {
                        flag5 = true;
                        if (@class.method_3() > 0 && smethod_0(@class.method_4()))
                        {
                            flag5 = false;
                        }
                    }
                    else if (documentControler.vmethod_9(current))
                    {
                        flag5 = true;
                    }
                }
                else
                {
                    bool flag6 = documentControler.vmethod_10(current);
                    if (current is XTextTableElement && xTextLine3.Count == 1 && xTextLine3[0] is XTextFieldBorderElement)
                    {
                        XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xTextLine3[0];
                        flag6 = ((!string.IsNullOrEmpty(xTextFieldBorderElement.Text) || !string.IsNullOrEmpty(xTextFieldBorderElement.BorderText)) ? true : false);
                    }
                    if (flag6)
                    {
                        @class.method_0(current);
                        flag5 = true;
                    }
                    else if (!xTextLine3.method_25(current))
                    {
                        @class.method_0(current);
                        flag5 = true;
                        if (xTextLine3.Count > 1 && !documentControler.vmethod_13(xTextLine3.LastElement))
                        {
                            XTextElement xTextElement4 = xTextLine3.method_28();
                            if (xTextElement4 != null)
                            {
                                @class.method_0(xTextElement4);
                                list.Add(xTextElement4);
                            }
                        }
                        else
                        {
                            if (!documentControler.vmethod_12(current) || !documentControler.vmethod_13(xTextLine3.LastElement))
                            {
                                XTextElement xTextElement5 = xTextLine3.method_28();
                                if (xTextElement5 != null)
                                {
                                    @class.method_0(xTextElement5);
                                    list.Add(xTextElement5);
                                    if (!documentControler.vmethod_12(xTextElement5) && xTextLine3.Count > 2)
                                    {
                                        xTextElement5 = xTextLine3.method_28();
                                        if (xTextElement5 != null)
                                        {
                                            @class.method_0(xTextElement5);
                                            list.Add(xTextElement5);
                                        }
                                    }
                                }
                            }
                            XTextCharElement xTextCharElement2 = @class.method_4() as XTextCharElement;
                            bool flag7 = false;
                            if (xTextCharElement2 != null)
                            {
                                if (documentControler.vmethod_11(xTextCharElement2.CharValue))
                                {
                                    flag7 = true;
                                }
                                if (Class131.smethod_1(xTextCharElement2.CharValue))
                                {
                                    flag7 = true;
                                }
                            }
                            if (flag7)
                            {
                                float num7 = 0f;
                                float contentWidth = xTextLine3.ContentWidth;
                                int num8 = 0;
                                int num9 = -1;
                                if (Class131.smethod_1(xTextCharElement2.CharValue))
                                {
                                    i = xTextLine3.Count - 1;
                                    while (i >= 0 && xTextLine3[i] is XTextCharElement)
                                    {
                                        char charValue = ((XTextCharElement)xTextLine3[i]).CharValue;
                                        bool flag8 = false;
                                        if (Class131.smethod_0(charValue))
                                        {
                                            break;
                                        }
                                        if (Class131.smethod_1(charValue))
                                        {
                                            flag8 = true;
                                        }
                                        if (!flag8)
                                        {
                                            break;
                                        }
                                        num7 += xTextLine3[i].Width;
                                        num8++;
                                        num9 = i;
                                        if (num8 > 7)
                                        {
                                            break;
                                        }
                                        i--;
                                    }
                                }
                                else
                                {
                                    i = xTextLine3.Count - 1;
                                    while (i >= 0)
                                    {
                                        if (xTextLine3[i] is XTextCharElement)
                                        {
                                            char charValue = ((XTextCharElement)xTextLine3[i]).CharValue;
                                            bool flag8 = false;
                                            if (documentControler.vmethod_11(charValue))
                                            {
                                                flag8 = true;
                                            }
                                            if (!flag8)
                                            {
                                                break;
                                            }
                                            num7 += xTextLine3[i].Width;
                                            num8++;
                                            num9 = i;
                                            i--;
                                            continue;
                                        }
                                        if (xTextLine3[i] is XTextParagraphListItemElement)
                                        {
                                            num9 = 0;
                                        }
                                        break;
                                    }
                                }
                                if (num9 > xTextLine3.Count / 3 && num7 < contentWidth / 3f)
                                {
                                    for (i = xTextLine3.Count - 1; i >= num9; i--)
                                    {
                                        XTextElement xTextElement6 = xTextLine3[i];
                                        xTextLine3.RemoveAt(i);
                                        @class.method_0(xTextElement6);
                                        list.Add(xTextElement6);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (method_26(current) && !freeLayoutElements.Contains(current))
                        {
                            freeLayoutElements.Add(current);
                        }
                        if (documentControler.vmethod_9(current))
                        {
                            flag5 = true;
                        }
                    }
                }
                if ((xTextLine3.IsTableLine || xTextLine3.IsSectionLine || xTextLine3.IsPageBreakLine) && freeLayoutElements.Count > 0)
                {
                    foreach (XTextElement item4 in freeLayoutElements)
                    {
                        XTextLine xTextLine = item4.OwnerLine;
                        if (xTextLine == null && dictionary_0.ContainsKey(item4))
                        {
                            xTextLine = dictionary_0[item4];
                        }
                        if (xTextLine != null)
                        {
                            float num10 = xTextLine.Top + item4.Top + item4.Height;
                            if (xTextLine3.Top < num10)
                            {
                                xTextLine3.Top = num10;
                            }
                        }
                    }
                }
                XTextCharElement xTextCharElement3 = current as XTextCharElement;
                if (xTextCharElement3 != null && xTextCharElement3.CharValue == '\t')
                {
                    xTextCharElement3.method_13();
                }
                if (!flag5)
                {
                    continue;
                }
                XTextLine lastLine;
                if (flag4)
                {
                    flag4 = false;
                }
                else if (xtextLineList_0.Count > 0 && (num2 <= 0 || xtextElementList_2.IndexOf(current) > num2))
                {
                    lastLine = xTextLineList.LastLine;
                    _ = lastLine.FirstElement;
                    i = num5;
                    while (i >= num4)
                    {
                        XTextLine xTextLine4 = privateLines[i];
                        if (xTextLine4.InvalidateState)
                        {
                            break;
                        }
                        if (!class121_0.method_0() || !method_41(lastLine, xtextLineList_0[i]))
                        {
                            i--;
                            continue;
                        }
                        goto IL_0c12;
                    }
                    i = privateLines.Count - 1;
                    while (i >= num5)
                    {
                        XTextLine xTextLine4 = privateLines[i];
                        if (xTextLine4.InvalidateState)
                        {
                            break;
                        }
                        if (!method_41(lastLine, xtextLineList_0[i]))
                        {
                            i--;
                            continue;
                        }
                        goto IL_0bf9;
                    }
                }
                if (@class.method_3() > 0)
                {
                    if (xTextLine3 != null && xTextLine3.Count > 0)
                    {
                        method_36(xTextLine3);
                    }
                    xTextLine3 = method_39(xTextLineList.LastLine);
                    xTextLineList.Add(xTextLine3);
                    continue;
                }
                if (xTextLine3 != null && xTextLine3.Count > 0)
                {
                    method_36(xTextLine3);
                }
                break;
                IL_0bf9:
                xTextLine2 = xtextLineList_0[i];
                method_36(lastLine);
                break;
                IL_0c12:
                xTextLine2 = xtextLineList_0[i];
                method_36(lastLine);
                break;
            }
            if (this is XTextDocumentBodyElement)
            {
                gstruct20_1.method_10();
                gstruct20_1.method_0();
                gstruct20_0.method_0();
                XTextLine.gstruct20_0.method_0();
            }
            while (@class.method_3() > 0)
            {
                XTextElement current = @class.method_2();
                if (method_26(current))
                {
                    freeLayoutElements.Add(current);
                }
            }
            List<XTextLine> list2 = new List<XTextLine>();
            if (xTextLineList.Count > 0)
            {
                XTextLine lastLine = xTextLineList.LastLine;
                if (lastLine.Count == 0)
                {
                    xTextLineList.Remove(lastLine);
                }
                if (xTextLineList.Count > 0)
                {
                    method_37(xTextLineList.LastLine);
                }
            }
            int num11 = 0;
            if (xTextElement.OwnerLine != null)
            {
                _ = xTextElement.OwnerLine.Top;
                num11 = privateLines.IndexOf(xTextElement.OwnerLine);
            }
            if (num11 < 0)
            {
                num11 = 0;
            }
            if (xTextLine2 == null && xTextLineList.Count > 1 && privateLines.Count > 0)
            {
                XTextLine lastLine = xTextLineList.LastLine;
                _ = lastLine.FirstElement;
                int i = privateLines.Count - 1;
                while (i >= 0)
                {
                    if (!method_41(lastLine, privateLines[i]))
                    {
                        i--;
                        continue;
                    }
                    xTextLine2 = privateLines[i];
                    break;
                }
            }
            if (xTextLine2 == null && xTextLineList.Count == 1 && xtextLineList_0.Count > 0 && xtextLineList_0.LastLine.FirstElement == xTextLineList[0].FirstElement)
            {
                xTextLine2 = xtextLineList_0.LastLine;
            }
            List<XTextLine> list3 = new List<XTextLine>();
            bool flag9 = false;
            bool flag10 = false;
            if (xTextLine2 == null)
            {
                flag10 = true;
                flag9 = true;
                if (privateLines.Count > 0)
                {
                    if (num11 == 0)
                    {
                        list3.AddRange(privateLines);
                        xtextLineList_0.Clear();
                    }
                    else
                    {
                        for (int i = privateLines.Count - 1; i >= num11; i--)
                        {
                            list3.Add(privateLines[i]);
                            privateLines.RemoveAt(i);
                        }
                    }
                }
                privateLines.AddRange(xTextLineList);
                foreach (XTextLine item5 in xTextLineList)
                {
                    item5.method_20();
                }
            }
            else
            {
                XTextLine ownerLine3 = xTextElement.OwnerLine;
                if (ownerLine3 == null)
                {
                    ownerLine3 = privateLines[0];
                }
                int num12 = privateLines.IndexOf(xTextLine2);
                if (num12 - num11 + 1 != xTextLineList.Count)
                {
                    flag10 = true;
                    flag9 = true;
                }
                else
                {
                    for (int i = 0; i < xTextLineList.Count; i++)
                    {
                        XTextLine xTextLine5 = xTextLineList[i];
                        XTextLine ownerLine2 = privateLines[i + num11];
                        if (xTextLine5.Height != ownerLine2.Height)
                        {
                            flag10 = true;
                            break;
                        }
                    }
                }
                if (xTextLineList.LastLine.Top != xTextLine2.Top)
                {
                    flag9 = true;
                }
                if (!flag10 && xTextLineList.Count > 1)
                {
                    num12--;
                    xTextLineList.RemoveAt(xTextLineList.Count - 1);
                }
                if (!flag10)
                {
                    for (int i = 0; i < xTextLineList.Count; i++)
                    {
                        XTextLine xTextLine = xTextLineList[i];
                        list3.Add(xTextLine);
                        xTextLine.OwnerPage = privateLines[i + num11].OwnerPage;
                        xTextLine.method_20();
                        XTextLine xTextLine4 = privateLines[i + num11];
                        list3.Add(xTextLine4);
                        privateLines.method_0(i + num11, xTextLine);
                    }
                }
                else
                {
                    for (int i = num12; i >= num11; i--)
                    {
                        if (i >= 0)
                        {
                            if (ownerDocument.EditorControl != null)
                            {
                                XTextLine item = privateLines[i];
                                list3.Add(item);
                            }
                            privateLines.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < xTextLineList.Count; i++)
                    {
                        if (ownerDocument.EditorControl != null)
                        {
                            XTextLine xTextLine = xTextLineList[i];
                            list3.Add(xTextLine);
                        }
                        xTextLineList[i].method_20();
                        privateLines.Insert(i + num11, xTextLineList[i]);
                    }
                }
            }
            if (verticalAlignStyle != 0 || flag9)
            {
                if (Height > 0f)
                {
                    vmethod_41(verticalAlignStyle, bool_22: false, bool_23: false);
                }
            }
            else if (NeedFixLinePositionForPageLine)
            {
                method_34();
            }
            for (int i = ShadowElements.Count - 1; i >= 0; i--)
            {
                XTextShadowElement xTextShadowElement = ShadowElements[i];
                if (!privateLines.Contains(xTextShadowElement.OwnerLine))
                {
                    ShadowElements.RemoveAt(i);
                }
            }
            if (!class121_0.method_8() && ownerDocument.EditorControl != null && !flag2)
            {
                foreach (XTextLine item6 in list3)
                {
                    ownerDocument.EditorControl.ViewInvalidate(item6, ContentPartyStyle);
                }
                foreach (XTextLine item7 in xTextLineList)
                {
                    ownerDocument.EditorControl.ViewInvalidate(item7, ContentPartyStyle);
                }
            }
            if (list.Count > 0)
            {
                List<XTextLine> list4 = new List<XTextLine>();
                foreach (XTextElement item8 in list)
                {
                    XTextLine xTextLine = item8.OwnerLine;
                    if (xTextLine != null && privateLines.Contains(xTextLine) && !list4.Contains(xTextLine))
                    {
                        list4.Add(item8.OwnerLine);
                    }
                }
                if (list4.Count > 0)
                {
                    foreach (XTextLine item9 in list4)
                    {
                        if (!list2.Contains(item9))
                        {
                            item9.SpecifyLineSpacing = 0f;
                            method_36(item9);
                        }
                    }
                }
            }
            flag10 = false;
            if (array2.Length != xtextLineList_0.Count * 2)
            {
                flag10 = true;
            }
            else
            {
                for (int i = 0; i < privateLines.Count; i++)
                {
                    XTextLine xTextLine = privateLines[i];
                    if (xTextLine.Top == array2[i * 2])
                    {
                        if (xTextLine.Height == array2[i * 2 + 1])
                        {
                            xTextLine.GlobalIndex = array[i * 2];
                            xTextLine.IndexInPage = array[i * 2 + 1];
                            continue;
                        }
                        flag10 = true;
                        break;
                    }
                    flag10 = true;
                    break;
                }
            }
            int num13 = 0;
            foreach (XTextLine item10 in privateLines)
            {
                item10.InvalidateState = false;
                item10.IndexInParagraph = num13;
                num13 = ((!(item10.LastElement is XTextParagraphFlagElement)) ? (num13 + 1) : 0);
            }
            if (WriterControl != null && WriterControl.InnerViewControl != null && WriterControl.InnerViewControl.ViewHandleManager != null)
            {
                WriterControl.InnerViewControl.ViewHandleManager.method_1();
            }
            if (privateLines.Count != 0)
            {
            }
            dictionary_0 = null;
            if (list_0 != null && list_0.Count == 0)
            {
                list_0 = null;
            }
            if (!flag10 && !class121_0.method_8() && ownerDocument.EditorControl != null && ownerDocument.EditorControl.ControlHostManger != null)
            {
                ownerDocument.EditorControl.ControlHostManger.UpdateHostWindowsControlPosition();
            }
            if (flag10)
            {
                if (!class121_0.method_8() && ownerDocument.EditorControl != null && !flag2)
                {
                    ownerDocument.EditorControl.ViewInvalidate(AbsBounds, ContentPartyStyle);
                }
                if (flag)
                {
                    method_40();
                }
                return flag;
            }
            if (flag)
            {
                method_40();
            }
            return false;
        }

        private void method_36(XTextLine xtextLine_1)
        {
            gstruct20_0.method_2(OwnerDocument.Options.BehaviorOptions.DebugMode);
            gstruct20_0.method_3();
            xtextLine_1.InvalidateState = false;
            xtextLine_1.method_17();
            if (xtextLine_1.IsTableLine)
            {
                xtextLine_1.method_22();
                XTextTableElement tableElement = xtextLine_1.TableElement;
                if (tableElement.LayoutInvalidate)
                {
                    tableElement.ExecuteLayout();
                    xtextLine_1.method_22();
                }
            }
            else if (xtextLine_1.IsSectionLine)
            {
                xtextLine_1.method_22();
                XTextSectionElement sectionElement = xtextLine_1.SectionElement;
                if (sectionElement.LayoutInvalidate)
                {
                    sectionElement.ExecuteLayout();
                    xtextLine_1.method_22();
                }
            }
            else
            {
                xtextLine_1.method_22();
            }
            gstruct20_0.method_4();
        }

        private void method_37(XTextLine xtextLine_1)
        {
            float num2 = xtextLine_1.SpecifyLineSpacing = method_38(xtextLine_1);
            if (xtextLine_1.LayoutInvalidate && !xtextLine_1.IsTableLine)
            {
                xtextLine_1.method_22();
            }
        }

        internal float method_38(XTextLine xtextLine_1)
        {
            RuntimeDocumentContentStyle runtimeStyle = xtextLine_1.ParagraphFlagElement.RuntimeStyle;
            float result = 0f;
            if (runtimeStyle.LineSpacingStyle != LineSpacingStyle.SpaceExactly)
            {
                _ = RuntimeStyle;
                result = ((!(RuntimeSpecifyFixedLineHeight > 0f)) ? runtimeStyle.GetLineSpacing(xtextLine_1.ContentHeight, xtextLine_1.MaxFontHeight * float_6, OwnerDocument.DocumentGraphicsUnit) : RuntimeSpecifyFixedLineHeight);
                if (xtextLine_1.IsTableLine)
                {
                    result = 0f;
                }
                else if (xtextLine_1.IsSectionLine)
                {
                    result = 0f;
                }
                else if (xtextLine_1.IsPageBreakLine)
                {
                    result = 0f;
                }
            }
            return result;
        }

        private XTextLine method_39(XTextLine xtextLine_1)
        {
            if (PrivateContent.Count == 0)
            {
                return null;
            }
            XTextDocument ownerDocument = OwnerDocument;
            gstruct20_1.method_3();
            gstruct20_1.method_2(ownerDocument.Options.BehaviorOptions.DebugMode);
            RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
            XTextLine xTextLine = new XTextLine();
            xTextLine.xtextContentElement_0 = this;
            xTextLine.InvalidateState = true;
            XTextElement xTextElement = PrivateContent.FirstElement;
            int num = 0;
            if (xtextLine_1 != null)
            {
                xTextElement = xtextLine_1.LastElement;
                if (xTextElement != null)
                {
                    num = xtextElementList_2.IndexOf(xTextElement, int_12);
                    if (num >= 0)
                    {
                        int_12 = num - 1;
                        if (int_12 < 0)
                        {
                            int_12 = 0;
                        }
                        num++;
                        xTextElement = xtextElementList_2.SafeGet(num);
                    }
                }
            }
            if (xTextElement == null)
            {
                xTextElement = PrivateContent.FirstElement;
                num = 0;
                int_12 = 0;
            }
            if (num < 0)
            {
                num = 0;
                int_12 = 0;
            }
            xTextLine.ParagraphFlagElement = PrivateContent.method_11(num);
            if (xTextLine != null && xTextLine.ParagraphFlagElement != null)
            {
            }
            float runtimeSpecifyFixedLineHeight = RuntimeSpecifyFixedLineHeight;
            RuntimeDocumentContentStyle runtimeStyle2 = xTextLine.ParagraphFlagElement.RuntimeStyle;
            if (runtimeSpecifyFixedLineHeight <= 0f)
            {
                if (xtextLine_1 == null || xtextLine_1.ParagraphFlagElement != xTextLine.ParagraphFlagElement)
                {
                    xTextLine.SpacingBeforeForParagraph = runtimeStyle2.SpacingBeforeParagraph * float_6;
                }
                else
                {
                    xTextLine.SpacingBeforeForParagraph = 0f;
                }
                xTextLine.Spacing = runtimeStyle2.Spacing;
            }
            xTextLine.Align = runtimeStyle2.Align;
            xTextLine.Left = runtimeStyle.PaddingLeft;
            if (xtextLine_1 == null)
            {
                xTextLine.Top = runtimeStyle.PaddingTop;
            }
            else
            {
                float num2 = 0f;
                if (runtimeSpecifyFixedLineHeight > 0f)
                {
                    num2 = (xtextLine_1.SpecifyLineSpacing = runtimeSpecifyFixedLineHeight);
                }
                else
                {
                    float num4 = xtextLine_1.MaxFontHeight * float_6;
                    num2 = xtextLine_1.ParagraphFlagElement.RuntimeStyle.GetLineSpacing(xtextLine_1.ContentHeight, num4, ownerDocument.DocumentGraphicsUnit);
                    if (xtextLine_1.IsTableLine)
                    {
                        num2 = (float)((double)xtextLine_1.TableElement.Height + (double)num4 * 0.1);
                    }
                    else if (xtextLine_1.IsSectionLine)
                    {
                        num2 = (float)((double)xtextLine_1.SectionElement.Height + (double)num4 * 0.1);
                    }
                    else if (runtimeStyle2.LineSpacingStyle == LineSpacingStyle.SpaceExactly)
                    {
                        xtextLine_1.SpecifyLineSpacing = 0f;
                    }
                    else
                    {
                        xtextLine_1.SpecifyLineSpacing = num2;
                    }
                }
                if (xtextLine_1.ParagraphFlagElement != xTextLine.ParagraphFlagElement)
                {
                    xtextLine_1.SpacingAfterForParagraph = xtextLine_1.ParagraphFlagElement.RuntimeStyle.SpacingAfterParagraph * float_6;
                }
                if (xtextLine_1.IsPageBreakLine)
                {
                    xtextLine_1.SpecifyLineSpacing = 0f;
                    xtextLine_1.SpacingBeforeForParagraph = 0f;
                    xtextLine_1.SpacingAfterForParagraph = 0f;
                    xtextLine_1.LayoutInvalidate = false;
                }
                if (xtextLine_1.IsSectionLine && xtextLine_1.SectionElement.CompressOwnerLineSpacing)
                {
                    xtextLine_1.SpecifyLineSpacing = 0f;
                    xtextLine_1.SpacingBeforeForParagraph = 0f;
                    xtextLine_1.SpacingAfterForParagraph = 0f;
                    xtextLine_1.LayoutInvalidate = false;
                }
                if (xtextLine_1.IsTableLine && xtextLine_1.TableElement.CompressOwnerLineSpacing)
                {
                    xtextLine_1.SpecifyLineSpacing = 0f;
                    xtextLine_1.SpacingBeforeForParagraph = 0f;
                    xtextLine_1.SpacingAfterForParagraph = 0f;
                    xtextLine_1.LayoutInvalidate = false;
                }
                if (xtextLine_1.LayoutInvalidate)
                {
                    xtextLine_1.method_22();
                }
                xtextLine_1.method_23();
                xTextLine.Top = xtextLine_1.Top + xtextLine_1.Height;
            }
            xTextLine.NativeTop = xTextLine.Top;
            xTextLine.DesignWidth = float_7;
            xTextLine.Height = Math.Max(ownerDocument.DefaultStyle.DefaultLineHeight, xTextElement.Height);
            if (runtimeSpecifyFixedLineHeight > 0f)
            {
                xTextLine.Height = runtimeSpecifyFixedLineHeight;
            }
            xTextLine.xtextContentElement_0 = this;
            xTextLine.xtextDocument_0 = ownerDocument;
            gstruct20_1.method_4();
            return xTextLine;
        }

        internal void method_40()
        {
            XTextLineList privateLines = PrivateLines;
            if (privateLines == null || privateLines.Count == 0)
            {
                return;
            }
            PrintPageCollection pages = base.ElementOwnerDocument.Pages;
            if (pages == null || pages.Count == 0)
            {
                return;
            }
            foreach (XTextLine item in privateLines)
            {
                item.OwnerPage = null;
                item.LastOwnerPage = null;
            }
            float absTop = AbsTop;
            float num = absTop + Height;
            int num2 = 0;
            float num3 = absTop + privateLines[0].Top;
            int num4 = 0;
            int count = privateLines.Count;
            int count2 = pages.Count;
            int num5 = pages.IndexOfByPosition(absTop, 0);
            if (num5 != 2)
            {
            }
            for (int i = num5; i < count2; i++)
            {
                PrintPage printPage = pages[i];
                float height = printPage.Height;
                float num6 = printPage.Top - 0.5f;
                float num7 = num6 + height;
                if (!(num3 >= num6) || !(num3 < num7))
                {
                    continue;
                }
                for (int j = num4; j < count; j++)
                {
                    XTextLine current = privateLines[j];
                    if (current.OwnerPage != null)
                    {
                        continue;
                    }
                    float num8 = current.Top + absTop;
                    if (num8 >= num6 && num8 < num7)
                    {
                        current.OwnerPage = printPage;
                        if (num8 + current.Height < num7 + 3f)
                        {
                            current.LastOwnerPage = printPage;
                        }
                        else
                        {
                            for (int k = i; k < pages.Count; k++)
                            {
                                PrintPage printPage2 = pages[k];
                                if (num8 + current.Height < printPage2.Top + 3f)
                                {
                                    current.LastOwnerPage = printPage2;
                                    break;
                                }
                            }
                            if (current.LastOwnerPage == null)
                            {
                                current.LastOwnerPage = pages[pages.Count - 1];
                            }
                        }
                        num4 = j;
                        num2++;
                    }
                    else if (num8 >= num7 - 1f)
                    {
                        num3 = num8;
                        break;
                    }
                }
                if (num < num6 || num2 == count)
                {
                    break;
                }
            }
        }

        private bool method_41(XTextLine xtextLine_1, XTextLine xtextLine_2)
        {
            if (xtextLine_1.Count != xtextLine_2.Count)
            {
                return false;
            }
            if (xtextLine_2.InvalidateState)
            {
                return false;
            }
            if (xtextLine_1.PaddingLeft != xtextLine_2.PaddingLeft)
            {
                return false;
            }
            int num = 0;
            while (true)
            {
                if (num < xtextLine_1.Count)
                {
                    XTextElement xTextElement = xtextLine_1[num];
                    if (xTextElement == xtextLine_2[num])
                    {
                        if (xTextElement.SizeInvalid)
                        {
                            break;
                        }
                        num++;
                        continue;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        ///       元素是否可见
        ///       </summary>
        /// <param name="element">元素对象</param>
        /// <returns>是否可见</returns>
        
        public virtual bool IsVisible(XTextElement element)
        {
            return OwnerDocument.IsVisible(element);
        }

        
        public void method_42(GClass128 gclass128_0)
        {
            if (PrivateLines.Count == 0)
            {
                return;
            }
            XTextLine lastLine = PrivateLines.LastLine;
            if (!(this is XTextDocumentBodyElement) && lastLine.AbsTop + lastLine.Height <= gclass128_0.method_23())
            {
                bool flag = true;
                if (gclass128_0.method_0() != null && gclass128_0.method_0().Count > 0)
                {
                    foreach (XTextPageBreakElement item in gclass128_0.method_0())
                    {
                        if (!item.Handled && item.IsParentOrSupParent(this))
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    gclass128_0.method_30(bool_5: true);
                    return;
                }
            }
            XTextLine xTextLine = null;
            float absTop = AbsTop;
            XTextLineList privateLines = PrivateLines;
            int num = 0;
            if (!gclass128_0.method_16())
            {
                int num2 = privateLines.Count - 1;
                while (num2 >= 0)
                {
                    if (!(privateLines[num2].Top + absTop < gclass128_0.method_20()))
                    {
                        num2--;
                        continue;
                    }
                    num = num2;
                    break;
                }
            }
            int count = privateLines.Count;
            for (int num2 = num; num2 < count; num2++)
            {
                XTextLine xTextLine2 = privateLines[num2];
                if (!gclass128_0.method_16())
                {
                    if (xTextLine2.FirstElement is XTextSubDocumentElement)
                    {
                        XTextSubDocumentElement xTextSubDocumentElement = (XTextSubDocumentElement)xTextLine2.FirstElement;
                        if (xTextSubDocumentElement.NewPage && !xTextSubDocumentElement.RuntimeIsCollapsed && !xTextSubDocumentElement.HandledNewPage)
                        {
                            xTextSubDocumentElement.HandledNewPage = true;
                            gclass128_0.method_24(xTextSubDocumentElement.AbsTop);
                            gclass128_0.method_5(xTextSubDocumentElement);
                            gclass128_0.method_3(bool_5: true);
                            return;
                        }
                    }
                    if (xTextLine2.IsExpendedSectionLine && xTextLine2.SectionElement.ContainsUnHandledPageBreak)
                    {
                        xTextLine2.SectionElement.method_42(gclass128_0);
                        break;
                    }
                    if (xTextLine2.IsTableLine && xTextLine2.TableElement.ContainsUnHandledPageBreak)
                    {
                        xTextLine2.TableElement.method_26(gclass128_0);
                        break;
                    }
                }
                if (!(Math.Abs(gclass128_0.method_23() - absTop - xTextLine2.Top) < 2f))
                {
                    if (!(gclass128_0.method_23() > absTop + xTextLine2.Top))
                    {
                        break;
                    }
                    xTextLine = xTextLine2;
                    if (xTextLine[0] is XTextPageBreakElement)
                    {
                        XTextPageBreakElement current = (XTextPageBreakElement)xTextLine[0];
                        if (!current.Handled)
                        {
                            current.Handled = true;
                            if (OwnerDocument.Options.BehaviorOptions.PageLineUnderPageBreak)
                            {
                                int num3 = (int)(xTextLine.AbsTop + xTextLine.Height);
                                gclass128_0.method_5(current);
                                if (privateLines.LastLine == xTextLine2)
                                {
                                    float bottom = AbsBounds.Bottom;
                                    if (bottom - gclass128_0.method_23() < 50f)
                                    {
                                        num3 = (int)bottom;
                                        gclass128_0.method_5(this);
                                    }
                                }
                                gclass128_0.method_24(num3);
                            }
                            else
                            {
                                gclass128_0.method_24((int)xTextLine.AbsTop);
                            }
                            gclass128_0.method_5(current);
                            gclass128_0.method_3(bool_5: true);
                            return;
                        }
                    }
                    if (privateLines.LastLine != xTextLine2 || !(gclass128_0.method_23() > xTextLine2.AbsBottom))
                    {
                        if (gclass128_0.method_23() < absTop + xTextLine.Top + xTextLine.Height)
                        {
                            break;
                        }
                        continue;
                    }
                    xTextLine = null;
                    gclass128_0.method_30(bool_5: true);
                    break;
                }
                xTextLine = xTextLine2;
                break;
            }
            if (xTextLine == null)
            {
                if (!gclass128_0.method_29())
                {
                    gclass128_0.bool_3 = true;
                }
                return;
            }
            if (gclass128_0.method_23() > xTextLine.AbsBottom)
            {
                if (xTextLine == privateLines.LastLine)
                {
                    RectangleF absBounds = AbsBounds;
                    if (gclass128_0.method_23() >= absBounds.Bottom)
                    {
                        gclass128_0.method_24(absBounds.Bottom);
                        gclass128_0.method_5(this);
                    }
                    else if (absBounds.Bottom - gclass128_0.method_23() < OwnerDocument.PixelToDocumentUnit(15f))
                    {
                        goto IL_0441;
                    }
                }
                gclass128_0.method_30(bool_5: true);
                return;
            }
            goto IL_0441;
            IL_0441:
            if (xTextLine.TableElement != null)
            {
                XTextTableElement tableElement = xTextLine.TableElement;
                tableElement.method_26(gclass128_0);
            }
            else if (xTextLine.IsExpendedSectionLine)
            {
                XTextSectionElement sectionElement = xTextLine.SectionElement;
                sectionElement.method_42(gclass128_0);
            }
            else
            {
                int num4 = privateLines.IndexOf(xTextLine);
                float num5 = 0f;
                if (num4 > 0)
                {
                    XTextLine xTextLine3 = privateLines[num4 - 1];
                    num5 = xTextLine3.AbsTop + xTextLine3.Height;
                }
                else
                {
                    num5 = xTextLine.AbsTop;
                }
                XTextElement xTextElement = xTextLine[0];
                if (xTextElement is XTextParagraphListItemElement && xTextLine.Count > 1)
                {
                    xTextElement = xTextLine[1];
                }
                if (xTextElement != null)
                {
                    gclass128_0.method_5(xTextElement);
                }
                if (num5 - gclass128_0.method_20() > gclass128_0.method_12())
                {
                    gclass128_0.method_24(num5);
                    RectangleF absBounds = AbsBounds;
                    if (gclass128_0.method_23() - absBounds.Top < OwnerDocument.PixelToDocumentUnit(15f))
                    {
                        gclass128_0.method_24(absBounds.Top);
                        gclass128_0.method_5(this);
                    }
                }
            }
            if ((!gclass128_0.method_16() || OwnerDocument.Options.BehaviorOptions.SpecifyDebugMode) && list_0 != null)
            {
                foreach (XTextElement item2 in list_0)
                {
                    _ = item2.AbsBounds;
                    float absTop2 = item2.OwnerLine.AbsTop;
                    if (gclass128_0.method_23() > absTop2 && gclass128_0.method_23() < absTop2 + item2.Top + item2.Height)
                    {
                        gclass128_0.method_24(absTop2);
                        gclass128_0.method_5(item2);
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///       绘制文档内容
        ///       </summary>
        /// <param name="args">参数</param>
        public override void DrawContent(DocumentPaintEventArgs args)
        {
            method_43(args);
        }

        internal void method_43(DocumentPaintEventArgs documentPaintEventArgs_0)
        {
            int num = 5;
            _ = OwnerDocument;
            RectangleF clipRectangle = documentPaintEventArgs_0.ClipRectangle;
            RectangleF absBounds = AbsBounds;
            absBounds.Width = ViewWidth;
            clipRectangle = RectangleF.Intersect(clipRectangle, absBounds);
            if (!(base.ID == "aaa"))
            {
            }
            if (clipRectangle.IsEmpty)
            {
                if (this is XTextDocumentBodyElement && documentPaintEventArgs_0.ViewMode == PageViewMode.Page)
                {
                    method_46(documentPaintEventArgs_0);
                }
                return;
            }
            if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && clipRectangle.Height > 2f)
            {
                base.InnerPrintedFlag = true;
            }
            if (drawStringFormatExt_0 == null)
            {
                drawStringFormatExt_0 = new DrawStringFormatExt();
                drawStringFormatExt_0.Alignment = StringAlignment.Center;
                drawStringFormatExt_0.LineAlignment = StringAlignment.Center;
            }
            bool enableEncryptView = OwnerDocument.Options.ViewOptions.EnableEncryptView;
            XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
            bool flag;
            if ((flag = OwnerDocument.Options.SecurityOptions.ShowPermissionMark) && !XTextDocument.smethod_13(GEnum6.const_118))
            {
                flag = false;
            }
            new List<XTextElement>();
            DocumentViewOptions viewOptions = OwnerDocument.Options.ViewOptions;
            OwnerDocument.method_85(this);
            XPenStyle xPenStyle = null;
            Color newInputContentUnderlineColor = OwnerDocument.Options.ViewOptions.NewInputContentUnderlineColor;
            if (newInputContentUnderlineColor.A > 0)
            {
                xPenStyle = new XPenStyle(newInputContentUnderlineColor);
            }
            foreach (XTextLine privateLine in PrivateLines)
            {
                if (privateLine.Count != 0 && privateLine.Visible)
                {
                    bool flag2 = true;
                    RectangleF absBounds2 = privateLine.AbsBounds;
                    if (privateLine.LastElement is XTextParagraphFlagElement)
                    {
                        absBounds2.Width += privateLine.LastElement.ViewWidth;
                    }
                    if (!clipRectangle.IsEmpty)
                    {
                        RectangleF rectangleF = RectangleF.Intersect(clipRectangle, absBounds2);
                        if (rectangleF.IsEmpty)
                        {
                            flag2 = false;
                        }
                        else
                        {
                            if (documentPaintEventArgs_0.RenderMode != 0 && rectangleF.Height <= 5f)
                            {
                                flag2 = false;
                            }
                            if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.PDF && rectangleF.Height < 10f)
                            {
                                flag2 = false;
                            }
                        }
                    }
                    if (flag2)
                    {
                        if (!documentPaintEventArgs_0.PageClipRectangle.IsEmpty)
                        {
                            RectangleF rectangleF2 = RectangleF.Intersect(documentPaintEventArgs_0.PageClipRectangle, absBounds2);
                            if (rectangleF2.Height < 10f && (double)rectangleF2.Height < (double)absBounds2.Height * 0.2)
                            {
                                continue;
                            }
                        }
                        GClass437 gClass = new GClass437();
                        XTextElementList xTextElementList = privateLine;
                        if (privateLine.RuntimeLayoutDirection == ContentLayoutDirectionStyle.RightToLeft)
                        {
                            xTextElementList = new XTextElementList();
                            xTextElementList.AddRange(privateLine);
                            xTextElementList.Reverse();
                        }
                        RectangleF absBounds3 = privateLine.AbsBounds;
                        float num2 = absBounds3.Right + 20f;
                        absBounds3.X = absBounds.Left;
                        absBounds3.Width = num2 - absBounds3.Left;
                        absBounds3 = RectangleF.Intersect(absBounds3, documentPaintEventArgs_0.ClipRectangle);
                        absBounds3 = RectangleF.Intersect(absBounds3, absBounds);
                        if (!documentPaintEventArgs_0.PageClipRectangle.IsEmpty)
                        {
                            absBounds3 = RectangleF.Intersect(absBounds3, documentPaintEventArgs_0.PageClipRectangle);
                        }
                        absBounds3.Width += 2f;
                        absBounds3.X -= 2f;
                        foreach (XTextElement item in xTextElementList)
                        {
                            if (!(item is XTextShadowElement) && item.RuntimeZOrderStyle == ElementZOrderStyle.Normal)
                            {
                                if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && documentPaintEventArgs_0.PrintSelectionMode)
                                {
                                    XTextSelection selection = base.DocumentContentElement.Selection;
                                    if (item is XTextParagraphListItemElement)
                                    {
                                        XTextElement nextElement = privateLine.GetNextElement(item);
                                        if (!selection.method_1(nextElement))
                                        {
                                            continue;
                                        }
                                    }
                                    else if (!selection.method_1(item))
                                    {
                                        continue;
                                    }
                                }
                                if (documentPaintEventArgs_0.IsVisible(item.RuntimeStyle.Visibility))
                                {
                                    if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && item is XTextObjectElement)
                                    {
                                        XTextObjectElement xTextObjectElement = (XTextObjectElement)item;
                                        if (xTextObjectElement.PrintVisibility != 0)
                                        {
                                            continue;
                                        }
                                    }
                                    if (!(item.Width <= 0f))
                                    {
                                        RectangleF rectangleF_ = item.Bounds;
                                        rectangleF_.Offset(absBounds2.Left, absBounds2.Top);
                                        RectangleF rectangleF3 = new RectangleF(item.Left + absBounds2.Left, absBounds2.Top + privateLine.ContentTopFix, item.ViewWidth + item.WidthFix, privateLine.Height - privateLine.ContentTopFix);
                                        if (!clipRectangle.IsEmpty)
                                        {
                                            rectangleF_ = RectangleF.Intersect(clipRectangle, rectangleF3);
                                        }
                                        if (!rectangleF_.IsEmpty)
                                        {
                                            if (!(item is XTextTableElement))
                                            {
                                                OwnerDocument.method_88(rectangleF_);
                                            }
                                            if (item.OwnerLine != null)
                                            {
                                            }
                                            bool flag3 = false;
                                            if (enableEncryptView && item.Parent is XTextInputFieldElementBase)
                                            {
                                                XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item.Parent;
                                                if (xTextInputFieldElementBase.IsEncrypt(item))
                                                {
                                                    flag3 = true;
                                                }
                                            }
                                            documentPaintEventArgs_0.Element = item;
                                            RuntimeDocumentContentStyle runtimeDocumentContentStyle = documentPaintEventArgs_0.Style = item.RuntimeStyle;
                                            RectangleF rectangleF4 = new RectangleF(absBounds2.Left + item.Left, absBounds2.Top + item.Top, item.Width, item.Height);
                                            rectangleF4.Width = item.ViewWidth;
                                            documentPaintEventArgs_0.ViewBounds = rectangleF4;
                                            rectangleF4.X += runtimeDocumentContentStyle.PaddingLeft;
                                            rectangleF4.Y += runtimeDocumentContentStyle.PaddingRight;
                                            rectangleF4.Width = item.ClientWidth;
                                            rectangleF4.Height = item.ClientHeight;
                                            documentPaintEventArgs_0.ClientViewBounds = rectangleF4;
                                            if (flag)
                                            {
                                                documentPaintEventArgs_0.Render.vmethod_0(item, documentPaintEventArgs_0, bool_2: true);
                                            }
                                            bool flag4 = true;
                                            if (item is XTextParagraphFlagElement && !OwnerDocument.Options.ViewOptions.ShowParagraphFlag)
                                            {
                                                flag4 = false;
                                                if (item.RuntimeStyle.DeleterIndex >= 0)
                                                {
                                                    flag4 = true;
                                                }
                                            }
                                            if (flag4)
                                            {
                                                if (flag3)
                                                {
                                                    documentPaintEventArgs_0.Render.vmethod_3(item, documentPaintEventArgs_0);
                                                    drawStringFormatExt_0.Font = runtimeDocumentContentStyle.Font;
                                                    drawStringFormatExt_0.Color = runtimeDocumentContentStyle.Color;
                                                    drawStringFormatExt_0.SetBounds(rectangleF4);
                                                    documentPaintEventArgs_0.Graphics.method_2("*", drawStringFormatExt_0);
                                                }
                                                else
                                                {
                                                    if (!(item is XTextCharElement) && !(item is XTextParagraphFlagElement))
                                                    {
                                                        WriterUtils.smethod_29(this, item, documentPaintEventArgs_0);
                                                    }
                                                    if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && xPenStyle != null && item.IsNewInputContent)
                                                    {
                                                        documentPaintEventArgs_0.Graphics.ResetClip();
                                                        documentPaintEventArgs_0.Graphics.DrawLine(xPenStyle, item.Left + absBounds2.Left, absBounds2.Bottom - 1f, item.Right + item.WidthFix + absBounds2.Left, absBounds2.Bottom - 1f);
                                                    }
                                                    if (!(item is XTextSectionElement))
                                                    {
                                                        documentPaintEventArgs_0.SetClip(absBounds3, CombineMode.Replace);
                                                    }
                                                    item.Draw(documentPaintEventArgs_0);
                                                    if (!(item is XTextCharElement) && !(item is XTextParagraphFlagElement))
                                                    {
                                                        WriterUtils.smethod_28(this, item, documentPaintEventArgs_0);
                                                    }
                                                }
                                            }
                                            if (flag)
                                            {
                                                documentPaintEventArgs_0.ViewBounds = rectangleF4;
                                                documentPaintEventArgs_0.Render.vmethod_0(item, documentPaintEventArgs_0, bool_2: false);
                                            }
                                            if (documentPaintEventArgs_0.Cancel)
                                            {
                                                break;
                                            }
                                            if (documentPaintEventArgs_0.ActiveMode && documentContentElement.IsSelected(item) && !(item is XTextButtonElement))
                                            {
                                                if (item.RuntimeStyle.LayoutAlign == ContentLayoutAlign.Surroundings)
                                                {
                                                    rectangleF3.Height = Math.Max(rectangleF3.Height, item.Height);
                                                }
                                                if (documentContentElement.Selection.LastElement == item)
                                                {
                                                    RectangleF rectangleF5 = rectangleF3;
                                                    rectangleF5.Width = item.Width;
                                                    gClass.method_2(rectangleF5.Left, absBounds2.Top, rectangleF5.Width, absBounds2.Height);
                                                }
                                                else
                                                {
                                                    gClass.method_2(rectangleF3.Left, absBounds2.Top, rectangleF3.Width, absBounds2.Height);
                                                }
                                            }
                                            if (viewOptions.HighlightProtectedContent && (runtimeDocumentContentStyle.ProtectType == ContentProtectType.Content || runtimeDocumentContentStyle.ProtectType == ContentProtectType.Range))
                                            {
                                                gClass.method_1(rectangleF3);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        documentPaintEventArgs_0.Graphics.ResetClip();
                        if (!gClass.method_3() && OwnerDocument.EditorControl != null)
                        {
                            RectangleF rectangleF_ = RectangleF.Empty;
                            rectangleF_ = ((!(this is XTextTableCellElement)) ? gClass.method_4() : RectangleF.Intersect(AbsBounds, gClass.method_4()));
                            OwnerDocument.EditorControl.AddSelectionAreaRectangle(Rectangle.Ceiling(rectangleF_));
                        }
                    }
                }
            }
            method_44(documentPaintEventArgs_0);
            if (HasFreeLayoutElements)
            {
                foreach (XTextElement freeLayoutElement in FreeLayoutElements)
                {
                    RectangleF absBounds4 = freeLayoutElement.AbsBounds;
                    RectangleF rectangleF_ = absBounds4;
                    if (!clipRectangle.IsEmpty)
                    {
                        rectangleF_ = RectangleF.Intersect(clipRectangle, absBounds4);
                    }
                    if (!rectangleF_.IsEmpty)
                    {
                        OwnerDocument.method_88(absBounds4);
                        documentPaintEventArgs_0.Element = freeLayoutElement;
                        documentPaintEventArgs_0.Style = freeLayoutElement.RuntimeStyle;
                        documentPaintEventArgs_0.ViewBounds = absBounds4;
                        documentPaintEventArgs_0.ClientViewBounds = documentPaintEventArgs_0.Style.GetClientRectangleF(absBounds4);
                        if (flag)
                        {
                            documentPaintEventArgs_0.Render.vmethod_0(freeLayoutElement, documentPaintEventArgs_0, bool_2: true);
                        }
                        WriterUtils.smethod_29(this, freeLayoutElement, documentPaintEventArgs_0);
                        freeLayoutElement.Draw(documentPaintEventArgs_0);
                        WriterUtils.smethod_28(this, freeLayoutElement, documentPaintEventArgs_0);
                        if (flag)
                        {
                            documentPaintEventArgs_0.Render.vmethod_0(freeLayoutElement, documentPaintEventArgs_0, bool_2: true);
                        }
                        if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && documentPaintEventArgs_0.ActiveMode && documentContentElement.IsSelected(freeLayoutElement))
                        {
                            OwnerDocument.EditorControl.AddSelectionAreaRectangle(Rectangle.Ceiling(absBounds4));
                        }
                    }
                }
            }
            if (this is XTextDocumentBodyElement && documentPaintEventArgs_0.ViewMode == PageViewMode.Page)
            {
                method_46(documentPaintEventArgs_0);
            }
            else if (HasVisibleDCGridLine)
            {
                RectangleF rectangleF_ = documentPaintEventArgs_0.ClipRectangle;
                RectangleF rectangleF4 = AbsClientBounds;
                rectangleF_ = RectangleF.Intersect(documentPaintEventArgs_0.ClipRectangle, AbsClientBounds);
                rectangleF_.X = rectangleF4.X;
                rectangleF_.Width = rectangleF4.Width;
                if (rectangleF_.Bottom > rectangleF4.Bottom)
                {
                    rectangleF_.Y = rectangleF4.Bottom - rectangleF_.Height;
                    rectangleF_.Height = rectangleF4.Bottom - rectangleF_.Top;
                }
                DocumentPaintEventArgs documentPaintEventArgs = documentPaintEventArgs_0.Clone();
                documentPaintEventArgs.ClipRectangle = rectangleF_;
                vmethod_43(documentPaintEventArgs);
            }
        }

        private void method_44(DocumentPaintEventArgs documentPaintEventArgs_0)
        {
            Class124 renderBorderInfos = RenderBorderInfos;
            if (renderBorderInfos == null || renderBorderInfos.Count == 0)
            {
                return;
            }
            if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && documentPaintEventArgs_0.PrintSelectionMode)
            {
                for (int num = renderBorderInfos.Count - 1; num >= 0; num--)
                {
                    Class123 @class = renderBorderInfos[num];
                    bool flag = false;
                    foreach (XTextElement item in @class.method_0())
                    {
                        if (base.DocumentContentElement.Selection.method_1(item))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        renderBorderInfos.RemoveAt(num);
                    }
                }
            }
            if (renderBorderInfos == null || renderBorderInfos.Count > 0)
            {
                RectangleF absBounds = AbsBounds;
                foreach (Class123 item2 in renderBorderInfos)
                {
                    RectangleF rectangleF = item2.method_4();
                    rectangleF.Offset(absBounds.Left, absBounds.Top);
                    if (rectangleF.IntersectsWith(documentPaintEventArgs_0.ClipRectangle) && (documentPaintEventArgs_0.PageClipRectangle.IsEmpty || !(RectangleF.Intersect(documentPaintEventArgs_0.PageClipRectangle, rectangleF).Height < 2f)))
                    {
                        using (item2.method_6().CreateBorderPen())
                        {
                            item2.method_6().DrawBorder(documentPaintEventArgs_0.Graphics, rectangleF);
                        }
                    }
                }
            }
        }

        
        [Browsable(false)]
        public float method_45(PrintPage printPage_0)
        {
            DocumentPaintEventArgs documentPaintEventArgs = new DocumentPaintEventArgs(null, RectangleF.Empty);
            documentPaintEventArgs.Page = printPage_0;
            documentPaintEventArgs.ClientViewBounds = RuntimeStyle.GetClientRectangleF(AbsBounds);
            float_8 = 0f;
            method_48(documentPaintEventArgs, Color.Empty, bool_22: false, bool_23: true, bool_24: true, 0f, RuntimeSpecifyFixedLineHeight, RuntimeStyle.GridLineOffsetY, RuntimeStyle.GridLineStyle, bool_25: true);
            return float_8;
        }

        
        private void method_46(DocumentPaintEventArgs documentPaintEventArgs_0)
        {
            GraphicsState graphicsState_ = documentPaintEventArgs_0.Graphics.Save();
            documentPaintEventArgs_0.Graphics.ResetClip();
            DocumentPaintEventArgs documentPaintEventArgs = documentPaintEventArgs_0.Clone();
            float num = documentPaintEventArgs.ClipRectangle.Bottom;
            if (documentPaintEventArgs.ClipRectangle.IsEmpty)
            {
                num = AbsTop + base.Bottom;
            }
            if (documentPaintEventArgs.Page != null)
            {
                num = documentPaintEventArgs.Page.Top + documentPaintEventArgs.Page.StandartPapeBodyHeight;
            }
            RectangleF clipRectangle = documentPaintEventArgs.ClipRectangle;
            clipRectangle.Height = num - clipRectangle.Top;
            clipRectangle.Y = num - clipRectangle.Height;
            documentPaintEventArgs.ClipRectangle = clipRectangle;
            documentPaintEventArgs.PageClipRectangle = clipRectangle;
            vmethod_43(documentPaintEventArgs);
            documentPaintEventArgs_0.Graphics.Restore(graphicsState_);
        }

        
        protected internal virtual void vmethod_43(DocumentPaintEventArgs documentPaintEventArgs_0)
        {
            if (!documentPaintEventArgs_0.EnabledDrawGridLine)
            {
                return;
            }
            DCGridLineInfo runtimeGridLine = RuntimeGridLine;
            if (runtimeGridLine == null || !runtimeGridLine.Visible || runtimeGridLine.RuntimeGridSpan <= 0f || (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && !runtimeGridLine.Printable) || PrivateLines.Count == 0)
            {
                return;
            }
            RectangleF clipRectangle = documentPaintEventArgs_0.ClipRectangle;
            RectangleF absClientBounds = AbsClientBounds;
            absClientBounds.X -= RuntimeStyle.PaddingLeft;
            absClientBounds.Width += RuntimeStyle.PaddingLeft + RuntimeStyle.PaddingRight;
            if (clipRectangle.Top < absClientBounds.Top)
            {
                clipRectangle.Height = clipRectangle.Bottom - absClientBounds.Top;
                clipRectangle.Y = absClientBounds.Top;
            }
            clipRectangle.X = absClientBounds.X;
            clipRectangle.Width = absClientBounds.Width;
            float absTop = AbsTop;
            float num = Math.Max(absClientBounds.Bottom, clipRectangle.Bottom);
            float num2 = Math.Max(absClientBounds.Top, clipRectangle.Top + 2f);
            if (!documentPaintEventArgs_0.PageClipRectangle.IsEmpty)
            {
                num = Math.Min(num, documentPaintEventArgs_0.PageClipRectangle.Bottom);
                num2 = Math.Max(num2, documentPaintEventArgs_0.PageClipRectangle.Top);
            }
            float num3 = float.MaxValue;
            if (documentPaintEventArgs_0.Page != null)
            {
                num3 = documentPaintEventArgs_0.Page.Bottom;
                if (this is XTextDocumentBodyElement)
                {
                    num3 = Math.Max(num3, num);
                }
            }
            XPenStyle xpenStyle_ = runtimeGridLine.method_4();
            float runtimeGridSpan = runtimeGridLine.RuntimeGridSpan;
            float num4 = absTop + PrivateLines.FirstLine.Top;
            while (num4 >= num2 && num4 > absClientBounds.Top + 10f)
            {
                if (num4 >= num2 && num4 <= clipRectangle.Bottom + 5f)
                {
                    method_47(documentPaintEventArgs_0.Graphics, xpenStyle_, clipRectangle, num4);
                }
                num4 -= runtimeGridSpan;
            }
            float num5 = absTop + PrivateLines.LastLine.Bottom;
            foreach (XTextLine privateLine in PrivateLines)
            {
                if (privateLine.OwnerPage != null && privateLine.OwnerPage.PageIndex > documentPaintEventArgs_0.PageIndex)
                {
                    break;
                }
                _ = absTop + privateLine.Top;
                num4 = absTop + privateLine.Bottom;
                if (num4 >= num2 && num4 <= clipRectangle.Bottom + 5f)
                {
                    if (absTop + privateLine.Top + privateLine.ContentTopFix >= num3)
                    {
                        break;
                    }
                    if (documentPaintEventArgs_0.Page != null && num4 > documentPaintEventArgs_0.Page.Bottom)
                    {
                        num4 = documentPaintEventArgs_0.Page.Bottom;
                        num4 = runtimeGridLine.method_2(num4 - documentPaintEventArgs_0.Page.Top) + documentPaintEventArgs_0.Page.Top;
                    }
                    num5 = num4;
                    if (documentPaintEventArgs_0.Page != null)
                    {
                        float num6 = num - num4;
                        if ((double)num6 < (double)runtimeGridSpan * 0.2)
                        {
                            break;
                        }
                    }
                    method_47(documentPaintEventArgs_0.Graphics, xpenStyle_, clipRectangle, num4);
                }
                if (num4 >= clipRectangle.Bottom + 5f)
                {
                    if (clipRectangle.Bottom > absTop + privateLine.Top)
                    {
                        if (this is XTextDocumentBodyElement && documentPaintEventArgs_0.ViewMode == PageViewMode.Page)
                        {
                            if (documentPaintEventArgs_0.Page != null && num4 > documentPaintEventArgs_0.Page.Bottom)
                            {
                                num4 = documentPaintEventArgs_0.Page.Top + runtimeGridLine.method_2(documentPaintEventArgs_0.Page.Height);
                            }
                        }
                        else
                        {
                            num5 = num4;
                        }
                        num5 = num4;
                    }
                    else if (num4 < num)
                    {
                        num5 = num4;
                    }
                    break;
                }
                num5 = num4;
            }
            for (num4 = num5; num4 < clipRectangle.Bottom; num4 += runtimeGridSpan)
            {
                float num6 = num - num4;
                if (!((double)num6 < (double)runtimeGridSpan * 0.8) || (this is XTextDocumentBodyElement && documentPaintEventArgs_0.ViewMode == PageViewMode.Page))
                {
                    method_47(documentPaintEventArgs_0.Graphics, xpenStyle_, clipRectangle, num4);
                }
            }
        }

        private void method_47(DCGraphics dcgraphics_0, XPenStyle xpenStyle_0, RectangleF rectangleF_1, float float_9)
        {
            if (float_9 >= rectangleF_1.Top && float_9 <= rectangleF_1.Bottom)
            {
                dcgraphics_0.DrawLine(xpenStyle_0, rectangleF_1.Left, float_9, rectangleF_1.Right, float_9);
                if (OwnerDocument.Options.BehaviorOptions.SpecifyDebugMode)
                {
                    dcgraphics_0.DrawString(float_9.ToString(), new XFontValue(), Color.Blue, rectangleF_1.Left - 200f, float_9);
                }
            }
        }

        internal void method_48(DocumentPaintEventArgs documentPaintEventArgs_0, Color color_0, bool bool_22, bool bool_23, bool bool_24, float float_9, float float_10, float float_11, DashStyle dashStyle_0, bool bool_25)
        {
            if (HasVisibleDCGridLine)
            {
                return;
            }
            float runtimeSpecifyFixedLineHeight = RuntimeSpecifyFixedLineHeight;
            RectangleF clientViewBounds = documentPaintEventArgs_0.ClientViewBounds;
            if (!documentPaintEventArgs_0.PageClipRectangle.IsEmpty)
            {
                if (this is XTextDocumentBodyElement)
                {
                    float num = Math.Max(clientViewBounds.Bottom, documentPaintEventArgs_0.PageClipRectangle.Bottom);
                    clientViewBounds.Y = Math.Max(clientViewBounds.Y, documentPaintEventArgs_0.PageClipRectangle.Top);
                    clientViewBounds.Height = num - clientViewBounds.Top;
                    clientViewBounds.Height += 3f;
                }
                else
                {
                    float num = Math.Min(clientViewBounds.Bottom, documentPaintEventArgs_0.PageClipRectangle.Bottom);
                    clientViewBounds.Y = Math.Max(clientViewBounds.Y, documentPaintEventArgs_0.PageClipRectangle.Top);
                    clientViewBounds.Height = num - clientViewBounds.Top;
                    clientViewBounds.Height += 3f;
                }
            }
            RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
            clientViewBounds.X -= runtimeStyle.PaddingLeft;
            clientViewBounds.Width = clientViewBounds.Width + runtimeStyle.PaddingLeft + runtimeStyle.PaddingRight;
            RectangleF.Intersect(clientViewBounds, documentPaintEventArgs_0.ClipRectangle);
            List<float> list = new List<float>();
            List<int> list2 = new List<int>();
            if (float_10 > 0f)
            {
                _ = AbsTop;
                float num2 = clientViewBounds.Top + float_10;
                float val = clientViewBounds.Bottom;
                if (!bool_22 && PrivateLines.Count > 0)
                {
                    XTextLine xTextLine = PrivateLines[0];
                    num2 = AbsTop + xTextLine.Top + xTextLine.Height;
                }
                if (!bool_23 && PrivateLines.Count > 0)
                {
                    XTextLine lastLine = PrivateLines.LastLine;
                    val = AbsTop + lastLine.Top + lastLine.Height;
                }
                if (!documentPaintEventArgs_0.PageClipRectangle.IsEmpty)
                {
                    num2 = Math.Max(num2, documentPaintEventArgs_0.PageClipRectangle.Top);
                    val = Math.Min(val, documentPaintEventArgs_0.PageClipRectangle.Bottom);
                }
                val = Math.Min(val, clientViewBounds.Bottom);
                if ((double)(clientViewBounds.Bottom - val) < 0.2 * (double)float_10)
                {
                    val -= float_10 * 0.5f;
                }
                for (float num3 = num2; num3 <= val; num3 += float_10)
                {
                    list.Add(num3);
                }
            }
            else
            {
                float num4 = -1f;
                float num5 = -1f;
                if (bool_22 && PrivateLines.Count > 0)
                {
                    XTextLine xTextLine = PrivateLines[0];
                    float num6 = float_9;
                    if (num6 <= 0f)
                    {
                        num6 = xTextLine.Height;
                    }
                    if (runtimeSpecifyFixedLineHeight > 0f)
                    {
                        num6 = runtimeSpecifyFixedLineHeight;
                    }
                    for (float num3 = xTextLine.AbsTop; num3 >= documentPaintEventArgs_0.ClientViewBounds.Top + num6 * 0.5f; num3 -= num6)
                    {
                        list.Add(num3);
                    }
                }
                foreach (XTextLine privateLine in PrivateLines)
                {
                    if (privateLine.Count == 1 && (privateLine.FirstElement is XTextPageBreakElement || privateLine.FirstElement is XTextHorizontalLineElement))
                    {
                        num4 = -1f;
                        num5 = -1f;
                    }
                    else
                    {
                        float num7 = Math.Min(documentPaintEventArgs_0.ViewBounds.Bottom - 30f, documentPaintEventArgs_0.ClipRectangle.Bottom);
                        if (bool_24)
                        {
                            num7 = documentPaintEventArgs_0.ClientViewBounds.Bottom + 5f;
                        }
                        if (documentPaintEventArgs_0.Page != null)
                        {
                            num7 = documentPaintEventArgs_0.Page.Top + documentPaintEventArgs_0.Page.Height + 1f;
                        }
                        float num8 = privateLine.AbsTop + privateLine.Height;
                        if (runtimeSpecifyFixedLineHeight > 0f)
                        {
                            num8 = privateLine.AbsTop + privateLine.Height;
                        }
                        if (num8 > num7)
                        {
                            break;
                        }
                        num4 = num8;
                        if (num8 >= documentPaintEventArgs_0.ClipRectangle.Top && num8 <= num7)
                        {
                            if (list.Count > 0)
                            {
                                num5 = num8 - list[list.Count - 1];
                            }
                            if (privateLine.IsTableLine || privateLine.IsSectionLine)
                            {
                                list2.Add(list.Count);
                            }
                            list.Add(num8);
                        }
                    }
                }
                if (bool_23)
                {
                    float_8 = 0f;
                    XTextLine lastLine = PrivateLines.LastLine;
                    int num9 = PrivateLines.Count - 1;
                    while (num9 >= 0)
                    {
                        XTextLine current = PrivateLines[num9];
                        if (OwnerDocument.Pages.IndexOf(current.OwnerPage) > OwnerDocument.Pages.IndexOf(documentPaintEventArgs_0.Page))
                        {
                            num9--;
                            continue;
                        }
                        lastLine = current;
                        break;
                    }
                    float num8 = num4;
                    float num10 = OwnerDocument.GlobalLastGridLineHeight;
                    if (num10 == 0f)
                    {
                        num10 = ((DocumentContentStyle)OwnerDocument.ContentStyles.Default).DefaultLineHeight;
                    }
                    if (num5 > 0f)
                    {
                        num10 = num5;
                    }
                    else if (lastLine != null && !lastLine.IsTableLine && !lastLine.IsSectionLine)
                    {
                        num8 = lastLine.AbsTop + lastLine.Height;
                        if (num5 <= 0f)
                        {
                            num10 = lastLine.Height;
                        }
                    }
                    if (float_9 > 0f)
                    {
                        num10 = float_9;
                    }
                    if (runtimeSpecifyFixedLineHeight > 0f)
                    {
                        num10 = runtimeSpecifyFixedLineHeight;
                    }
                    if (num10 < 10f)
                    {
                        num10 = documentPaintEventArgs_0.Graphics.GetFontHeight(OwnerDocument.ContentStyles.Default.Font);
                    }
                    float_8 = num10;
                    OwnerDocument.GlobalLastGridLineHeight = float_8;
                    float num11 = (float)((double)clientViewBounds.Bottom - (double)num10 * 0.8);
                    if (this is XTextDocumentBodyElement)
                    {
                        num11 = clientViewBounds.Bottom;
                    }
                    num8 += num10;
                    if (list.Count > 0)
                    {
                        num8 = list[list.Count - 1];
                    }
                    for (; num8 < num11; num8 += num10)
                    {
                        list.Add(num8);
                    }
                }
            }
            if (bool_25 || list.Count <= 0)
            {
                return;
            }
            if (float_11 != 0f)
            {
                for (int num9 = 0; num9 < list.Count; num9++)
                {
                    list[num9] += float_11;
                }
            }
            if (list.Count >= 1 && !(this is XTextDocumentBodyElement))
            {
                float num6 = RuntimeStyle.DefaultLineHeight;
                if (list.Count > 1)
                {
                    num6 = list[list.Count - 1] - list[list.Count - 2];
                }
                if (num6 < 20f)
                {
                    num6 = 20f;
                }
                float num12 = clientViewBounds.Bottom - list[list.Count - 1];
                if ((double)num12 < (double)num6 * 0.8)
                {
                    RuntimeDocumentContentStyle runtimeStyle2 = RuntimeStyle;
                    if (runtimeStyle2.HasVisibleBorder && runtimeStyle2.BorderBottom)
                    {
                        list.RemoveAt(list.Count - 1);
                    }
                }
            }
            if (list.Count == 0)
            {
                return;
            }
            XPenStyle xPenStyle = new XPenStyle(color_0, 1f);
            if (!(this is XTextDocumentBodyElement))
            {
            }
            xPenStyle.DashStyle = dashStyle_0;
            for (int num9 = 0; num9 < list.Count; num9++)
            {
                float num3 = list[num9];
                if (!list2.Contains(num9))
                {
                    documentPaintEventArgs_0.Graphics.DrawLine(xPenStyle, clientViewBounds.Left, num3, clientViewBounds.Right, num3);
                }
            }
        }

        internal ListDictionary<XTextParagraphFlagElement, List<XTextLine>> method_49()
        {
            int num = 0;
            ListDictionary<XTextParagraphFlagElement, List<XTextLine>> listDictionary = new ListDictionary<XTextParagraphFlagElement, List<XTextLine>>();
            for (int i = 0; i < PrivateLines.Count; i++)
            {
                XTextLine xTextLine = PrivateLines[i];
                if (xTextLine.LastElement is XTextParagraphFlagElement)
                {
                    List<XTextLine> list = new List<XTextLine>();
                    for (int j = num; j <= i; j++)
                    {
                        list.Add(PrivateLines[j]);
                    }
                    num = i + 1;
                    listDictionary[(XTextParagraphFlagElement)xTextLine.LastElement] = list;
                }
            }
            return listDictionary;
        }

        
        public virtual void vmethod_44(bool bool_22)
        {
            if (bool_22 && class124_0 != null && class124_0.Count > 0 && OwnerDocument.EditorControl != null)
            {
                RectangleF rectangleF = RectangleF.Empty;
                foreach (Class123 item in class124_0)
                {
                    rectangleF = ((!rectangleF.IsEmpty) ? RectangleF.Union(item.method_4(), rectangleF) : item.method_4());
                }
                OwnerDocument.EditorControl.ViewInvalidate(rectangleF, base.DocumentContentElement.PagePartyStyle);
            }
            class124_0 = null;
        }

        private ListDictionary<XTextParagraphFlagElement, List<XTextElementList>> method_50(bool bool_22, bool bool_23, Rectangle rectangle_0, bool bool_24)
        {
            int num = 0;
            ListDictionary<XTextParagraphFlagElement, List<XTextElementList>> listDictionary = new ListDictionary<XTextParagraphFlagElement, List<XTextElementList>>();
            if (bool_24)
            {
                FixElements();
                XTextElementList xTextElementList = new XTextElementList();
                foreach (XTextElement element in Elements)
                {
                    xTextElementList.AddRaw(element);
                    if (element is XTextParagraphFlagElement)
                    {
                        List<XTextElementList> list = new List<XTextElementList>();
                        list.Add(xTextElementList);
                        listDictionary[(XTextParagraphFlagElement)element] = list;
                        xTextElementList = new XTextElementList();
                    }
                }
                return listDictionary;
            }
            for (int i = 0; i < PrivateLines.Count; i++)
            {
                XTextLine xTextLine = PrivateLines[i];
                if (!(xTextLine.LastElement is XTextParagraphFlagElement))
                {
                    continue;
                }
                List<XTextElementList> list2 = new List<XTextElementList>();
                for (int j = num; j <= i; j++)
                {
                    XTextLine xTextLine2 = PrivateLines[j];
                    if (!rectangle_0.IsEmpty && !rectangle_0.IntersectsWith(Rectangle.Ceiling(xTextLine2.AbsBounds)))
                    {
                        continue;
                    }
                    if (bool_22 || bool_23)
                    {
                        bool flag = false;
                        if (bool_22)
                        {
                            foreach (XTextElement item in xTextLine2)
                            {
                                if (item.HasSelection)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        if (bool_23)
                        {
                            foreach (XTextElement item2 in xTextLine2)
                            {
                                if (!item2.IsLogicDeleted)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        if (!flag)
                        {
                            continue;
                        }
                    }
                    list2.Add(xTextLine2);
                }
                if (list2.Count > 0)
                {
                    listDictionary[(XTextParagraphFlagElement)xTextLine.LastElement] = list2;
                }
                num = i + 1;
            }
            return listDictionary;
        }

        public override void vmethod_19(GClass103 gclass103_0)
        {
            int num = 16;
            ListDictionary<XTextParagraphFlagElement, List<XTextElementList>> listDictionary = method_50(gclass103_0.vmethod_0(), gclass103_0.method_12(), Rectangle.Empty, bool_24: false);
            XTextTableCellElement xTextTableCellElement = OwnerCell;
            if (this is XTextTableCellElement)
            {
                xTextTableCellElement = (XTextTableCellElement)this;
            }
            foreach (XTextParagraphFlagElement key in listDictionary.Keys)
            {
                List<XTextElementList> list = listDictionary[key];
                gclass103_0.method_35(key.RuntimeStyle, key);
                if ((this is XTextDocumentHeaderElement || this is XTextDocumentHeaderForFirstPageElement) && HasContentElement && OwnerDocument.RuntimeShowHeaderBottomLine && key == Elements.LastElement)
                {
                    gclass103_0.method_28("s15");
                    gclass103_0.method_28("brdrb");
                    gclass103_0.method_28("brdrs");
                    gclass103_0.method_28("brdrw15");
                    gclass103_0.method_28("brsp20");
                    gclass103_0.method_28("brdrcf" + gclass103_0.method_10().method_8().method_7(Color.Black));
                }
                if (xTextTableCellElement != null)
                {
                    gclass103_0.method_28("intbl");
                    int neastLevel = xTextTableCellElement.OwnerTable.NeastLevel;
                    if (neastLevel > 1)
                    {
                        gclass103_0.method_28("itap" + neastLevel);
                    }
                }
                foreach (XTextElementList item in list)
                {
                    XTextElementList xTextElementList = WriterUtils.smethod_60(item, gclass103_0.vmethod_0());
                    foreach (XTextElement item2 in xTextElementList)
                    {
                        item2.vmethod_19(gclass103_0);
                    }
                }
            }
        }

        
        private void method_51(GInterface5 ginterface5_0)
        {
            int num = 5;
            float num2 = AbsBounds.Bottom - RuntimeStyle.PaddingBottom;
            if (!ginterface5_0.imethod_50().IsEmpty)
            {
                num2 = Math.Min(ginterface5_0.imethod_50().Bottom, num2);
            }
            DCGridLineInfo dCGridLineInfo = RuntimeGridLine;
            if (dCGridLineInfo == null || !dCGridLineInfo.Visible || !dCGridLineInfo.Printable)
            {
                if (this is XTextDocumentBodyElement)
                {
                    if (OwnerDocument.Options.ViewOptions.PrintGridLine && OwnerDocument.Options.ViewOptions.ShowGridLine)
                    {
                        dCGridLineInfo = new DCGridLineInfo();
                        dCGridLineInfo.Visible = true;
                        dCGridLineInfo.Printable = true;
                        dCGridLineInfo.Color = OwnerDocument.Options.ViewOptions.GridLineColor;
                        dCGridLineInfo.LineStyle = OwnerDocument.Options.ViewOptions.GridLineStyle;
                    }
                }
                else if (dCGridLineInfo == null)
                {
                    RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                    if (runtimeStyle.GridLineType == ContentGridLineType.Display || runtimeStyle.GridLineType == ContentGridLineType.ExtentToBottom)
                    {
                        dCGridLineInfo = new DCGridLineInfo();
                        dCGridLineInfo.Visible = true;
                        dCGridLineInfo.Printable = true;
                        dCGridLineInfo.Color = runtimeStyle.GridLineColor;
                        dCGridLineInfo.LineStyle = runtimeStyle.GridLineStyle;
                    }
                }
            }
            if (dCGridLineInfo != null && dCGridLineInfo.RuntimeGridSpan <= 0f)
            {
                dCGridLineInfo = null;
            }
            if (dCGridLineInfo != null)
            {
                if (this is XTextTableCellElement)
                {
                    if (!XTextDocument.smethod_13(GEnum6.const_109))
                    {
                        dCGridLineInfo = null;
                    }
                }
                else if (!XTextDocument.smethod_13(GEnum6.const_33))
                {
                    dCGridLineInfo = null;
                }
            }
            List<XTextLine> list = new List<XTextLine>();
            for (int i = 0; i < PrivateLines.Count; i++)
            {
                XTextLine xTextLine = PrivateLines[i];
                float height = xTextLine.Height;
                if (!ginterface5_0.imethod_50().IsEmpty)
                {
                    Rectangle rectangle = Rectangle.Intersect(ginterface5_0.imethod_50(), Rectangle.Ceiling(xTextLine.AbsBounds));
                    if (rectangle.Height < 5)
                    {
                        continue;
                    }
                    height = rectangle.Height;
                }
                list.Add(xTextLine);
            }
            int num3 = ginterface5_0.imethod_27();
            ginterface5_0.imethod_28(0);
            float num4 = 0f;
            bool flag = true;
            foreach (XTextLine item in list)
            {
                float height = item.Height;
                if (!ginterface5_0.imethod_50().IsEmpty)
                {
                    RectangleF rectangleF = RectangleF.Intersect(ginterface5_0.imethod_50(), item.AbsBounds);
                    if (rectangleF.Height < 5f)
                    {
                        continue;
                    }
                    height = rectangleF.Height;
                }
                if (flag)
                {
                    flag = false;
                    float num5 = ginterface5_0.imethod_45(item.AbsTop - Math.Max(AbsTop + RuntimeStyle.PaddingTop, ginterface5_0.imethod_50().Top));
                    if (num5 > 2f)
                    {
                        ginterface5_0.imethod_0("div");
                        ginterface5_0.imethod_24();
                        ginterface5_0.imethod_25("height", num5 + "px");
                        ginterface5_0.imethod_25("overflow", "hidden");
                        ginterface5_0.imethod_26();
                        ginterface5_0.imethod_2();
                    }
                }
                num4 += ginterface5_0.imethod_45(height);
                RuntimeDocumentContentStyle runtimeStyle2 = item.ParagraphFlagElement.RuntimeStyle;
                bool flag2 = true;
                if ((item.IsTableLine || item.IsSectionLine || item.IsPageBreakLine) && runtimeStyle2.Align == DocumentContentAlignment.Left)
                {
                    flag2 = false;
                }
                if (dCGridLineInfo != null && dCGridLineInfo.Visible && dCGridLineInfo.AlignToGridLine)
                {
                    flag2 = true;
                }
                if (!flag2)
                {
                    XTextElementList xTextElementList = WriterUtils.smethod_61(item, bool_2: false, ginterface5_0, bool_3: false);
                    foreach (XTextElement item2 in xTextElementList)
                    {
                        if (!(item2 is XTextParagraphFlagElement))
                        {
                            item2.vmethod_18(ginterface5_0);
                        }
                    }
                }
                else
                {
                    ginterface5_0.imethod_27();
                    ginterface5_0.imethod_28(0);
                    ginterface5_0.imethod_0("div");
                    ginterface5_0.imethod_24();
                    bool flag3 = false;
                    if (dCGridLineInfo != null && dCGridLineInfo.Visible && dCGridLineInfo.Printable)
                    {
                        float num6 = num2 - item.AbsBottom;
                        if (this is XTextDocumentBodyElement || (double)num6 > (double)item.Height * 0.5)
                        {
                            bool flag4 = true;
                            if (item.IsTableLine)
                            {
                                XTextTableElement tableElement = item.TableElement;
                                if (tableElement.CompressOwnerLineSpacing)
                                {
                                    flag4 = false;
                                }
                            }
                            if (flag4)
                            {
                                ginterface5_0.imethod_25("border-bottom-color", ginterface5_0.imethod_21(dCGridLineInfo.Color));
                                ginterface5_0.imethod_25("border-bottom-style", ginterface5_0.imethod_22(dCGridLineInfo.LineStyle));
                                ginterface5_0.imethod_25("border-bottom-width", ginterface5_0.imethod_44(dCGridLineInfo.LineWidth) + "px");
                            }
                            num3++;
                            flag3 = true;
                        }
                    }
                    if (RuntimeStyle.PaddingLeft > 0f)
                    {
                        ginterface5_0.imethod_25("padding-left", ginterface5_0.imethod_44(RuntimeStyle.PaddingLeft) + "px");
                    }
                    if (RuntimeStyle.PaddingRight > 0f)
                    {
                        ginterface5_0.imethod_25("padding-right", ginterface5_0.imethod_44(RuntimeStyle.PaddingRight) + "px");
                    }
                    int num7 = ginterface5_0.imethod_44(item.ContentTopFix);
                    if (num7 > 0)
                    {
                        ginterface5_0.imethod_25("padding-top", num7 + "px");
                    }
                    int num8 = ginterface5_0.imethod_44(height);
                    if (flag3)
                    {
                        num8--;
                    }
                    num3 += num8;
                    if (ginterface5_0.imethod_19() != XWebBrowsersStyle.InternetExplorer7)
                    {
                        num8 -= num7;
                    }
                    if (num4 < (float)num3)
                    {
                        num8--;
                        num3--;
                    }
                    else if (num4 > (float)num3)
                    {
                        num8++;
                        num3++;
                    }
                    ginterface5_0.imethod_25("height", num8 + "px");
                    string text = null;
                    if (item.LastElement is XTextParagraphFlagElement)
                    {
                        switch (runtimeStyle2.Align)
                        {
                            case DocumentContentAlignment.Left:
                                ginterface5_0.imethod_25("text-align", "left");
                                break;
                            case DocumentContentAlignment.Center:
                                ginterface5_0.imethod_25("text-align", "center");
                                break;
                            case DocumentContentAlignment.Right:
                                ginterface5_0.imethod_25("text-align", "right");
                                break;
                            case DocumentContentAlignment.Justify:
                                ginterface5_0.imethod_25("text-align", "justify");
                                break;
                            case DocumentContentAlignment.Distribute:
                                ginterface5_0.imethod_25("text-align", "justify");
                                ginterface5_0.imethod_25("layout-grid", "char loose 10pt none");
                                break;
                        }
                    }
                    else
                    {
                        switch (runtimeStyle2.Align)
                        {
                            case DocumentContentAlignment.Left:
                                text = "leftline";
                                break;
                            case DocumentContentAlignment.Center:
                                text = "centerline";
                                break;
                            case DocumentContentAlignment.Right:
                                text = "rightline";
                                break;
                            case DocumentContentAlignment.Justify:
                                text = "justifyline";
                                break;
                            case DocumentContentAlignment.Distribute:
                                text = "distributeline";
                                break;
                        }
                    }
                    if (item.PaddingLeft != 0f)
                    {
                        ginterface5_0.imethod_25("padding-left", ginterface5_0.imethod_45(item.PaddingLeft) + "px");
                    }
                    ginterface5_0.imethod_26();
                    if (text != null)
                    {
                        ginterface5_0.imethod_18("class", text);
                    }
                    XTextElementList xTextElementList = WriterUtils.smethod_61(item, bool_2: false, ginterface5_0, bool_3: false);
                    new Stack<XTextElement>();
                    XTextInputFieldElement xTextInputFieldElement = null;
                    foreach (XTextElement item3 in xTextElementList)
                    {
                        if (!(item3 is XTextParagraphFlagElement))
                        {
                            if (!item.IsTableLine && !item.IsSectionLine)
                            {
                                XTextInputFieldElement xTextInputFieldElement2 = item3.Parent as XTextInputFieldElement;
                                if (xTextInputFieldElement2 != null && !xTextInputFieldElement2.RuntimeStyle.HasVisibleBorder && xTextInputFieldElement2.RuntimeStyle.BackgroundColor.A == 0)
                                {
                                    xTextInputFieldElement2 = null;
                                }
                                if (xTextInputFieldElement != xTextInputFieldElement2)
                                {
                                    if (xTextInputFieldElement != null)
                                    {
                                        ginterface5_0.imethod_2();
                                    }
                                    xTextInputFieldElement = xTextInputFieldElement2;
                                    if (xTextInputFieldElement2 != null)
                                    {
                                        RuntimeDocumentContentStyle runtimeStyle3 = xTextInputFieldElement2.RuntimeStyle;
                                        ginterface5_0.imethod_0("span");
                                        ginterface5_0.imethod_24();
                                        if (runtimeStyle3.HasVisibleBorder)
                                        {
                                            ginterface5_0.imethod_17(runtimeStyle3.BorderLeft, runtimeStyle3.BorderTop, runtimeStyle3.BorderRight, runtimeStyle3.BorderBottom, runtimeStyle3.BorderColor, (int)runtimeStyle3.BorderWidth, runtimeStyle3.BorderStyle);
                                        }
                                        if (runtimeStyle3.BackgroundColor.A != 0)
                                        {
                                            ginterface5_0.imethod_25("background-color", ginterface5_0.imethod_21(runtimeStyle3.BackgroundColor));
                                        }
                                        ginterface5_0.imethod_25("font-family", runtimeStyle3.FontName);
                                        ginterface5_0.imethod_25("font-size", runtimeStyle3.FontSize + "pt");
                                        ginterface5_0.imethod_26();
                                    }
                                }
                            }
                            item3.vmethod_18(ginterface5_0);
                        }
                    }
                    if (xTextInputFieldElement != null)
                    {
                        ginterface5_0.imethod_2();
                    }
                    ginterface5_0.imethod_2();
                }
            }
            if (dCGridLineInfo == null || !dCGridLineInfo.Visible || !dCGridLineInfo.AlignToGridLine || !(dCGridLineInfo.RuntimeGridSpan > 0f))
            {
                return;
            }
            XTextLine xTextLine2 = (list.Count > 0) ? list[list.Count - 1] : null;
            if (this is XTextDocumentBodyElement)
            {
                if (!ginterface5_0.imethod_52().IsEmpty)
                {
                    num2 = Math.Max(num2, ginterface5_0.imethod_52().Bottom);
                }
            }
            else if (RuntimeStyle.BorderBottom && RuntimeStyle.HasVisibleBorder)
            {
                num2 -= 4f;
            }
            float runtimeGridSpan = dCGridLineInfo.RuntimeGridSpan;
            float num9 = ginterface5_0.imethod_45(runtimeGridSpan);
            float num10 = ginterface5_0.imethod_50().Top;
            if (xTextLine2 != null)
            {
                num10 = xTextLine2.AbsBottom + runtimeGridSpan;
            }
            for (; num10 <= num2; num10 += runtimeGridSpan)
            {
                float num6 = num2 - num10;
                if (this is XTextDocumentBodyElement || (double)num6 > (double)runtimeGridSpan * 0.5)
                {
                    ginterface5_0.imethod_0("div");
                    ginterface5_0.imethod_24();
                    int num8 = (int)(num9 - 1f);
                    num4 += num9;
                    num3 += num8 + 1;
                    if (num4 < (float)num3)
                    {
                        num8--;
                        num3--;
                    }
                    else if (num4 > (float)num3)
                    {
                        num8++;
                        num3++;
                    }
                    ginterface5_0.imethod_25("height", num8 + "px");
                    ginterface5_0.imethod_25("border-bottom-color", ginterface5_0.imethod_21(dCGridLineInfo.Color));
                    ginterface5_0.imethod_25("border-bottom-style", ginterface5_0.imethod_22(dCGridLineInfo.LineStyle));
                    ginterface5_0.imethod_25("border-bottom-width", dCGridLineInfo.LineWidth + "px");
                    ginterface5_0.imethod_26();
                    ginterface5_0.imethod_2();
                }
            }
        }

        
        public void method_52(GInterface5 ginterface5_0)
        {
            int num = 9;
            if (!ginterface5_0.imethod_36())
            {
            }
            if (ginterface5_0.imethod_34())
            {
                method_51(ginterface5_0);
                return;
            }
            for (int i = 0; i < PrivateLines.Count; i++)
            {
                XTextLine xTextLine = PrivateLines[i];
                xTextLine.HtmlVisible = true;
                if (!ginterface5_0.imethod_50().IsEmpty && Rectangle.Intersect(ginterface5_0.imethod_50(), Rectangle.Ceiling(xTextLine.AbsBounds)).Height < 5)
                {
                    xTextLine.HtmlVisible = false;
                }
            }
            ListDictionary<XTextParagraphFlagElement, List<XTextElementList>> listDictionary = method_50(ginterface5_0.imethod_48(), ginterface5_0.imethod_38(), ginterface5_0.imethod_50(), ginterface5_0.imethod_36() || ginterface5_0.imethod_34());
            DocumentContentStyle documentContentStyle = OwnerDocument.DefaultStyle;
            XTextElement xTextElement = null;
            foreach (XTextParagraphFlagElement key in listDictionary.Keys)
            {
                List<XTextElementList> list = listDictionary[key];
                if (!ginterface5_0.imethod_50().IsEmpty)
                {
                    bool flag;
                    if (!(flag = key.vmethod_3(ginterface5_0)))
                    {
                        foreach (XTextElementList item in list)
                        {
                            if (item is XTextLine)
                            {
                                if (((XTextLine)item).HtmlVisible)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            else
                            {
                                foreach (XTextElement item2 in item)
                                {
                                    if (item2.vmethod_3(ginterface5_0))
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (!flag)
                    {
                        continue;
                    }
                }
                RuntimeDocumentContentStyle runtimeStyle = key.RuntimeStyle;
                bool flag2 = false;
                bool flag3 = false;
                if (list.Count == 1 && list[0].Count > 0)
                {
                    XTextElement current3 = list[0][0];
                    if (current3 is XTextTableElement || current3 is XTextSectionElement)
                    {
                        flag3 = true;
                    }
                }
                if (flag3)
                {
                    ginterface5_0.imethod_0("p");
                    flag2 = true;
                    documentContentStyle = runtimeStyle.CloneParent();
                    documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
                }
                else
                {
                    if (documentContentStyle.ParagraphListStyle != runtimeStyle.ParagraphListStyle)
                    {
                        if (documentContentStyle.ParagraphListStyle != 0)
                        {
                            ginterface5_0.imethod_1();
                        }
                        documentContentStyle = runtimeStyle.Parent;
                        if (documentContentStyle.IsBulletedList)
                        {
                            ginterface5_0.imethod_0("ul");
                            if (documentContentStyle.LeftIndent > 0f)
                            {
                                ginterface5_0.imethod_18("style", "padding-left:" + ginterface5_0.imethod_44(documentContentStyle.LeftIndent) + "px");
                            }
                            flag2 = true;
                        }
                        else if (documentContentStyle.IsListNumberStyle)
                        {
                            ginterface5_0.imethod_0("ol");
                            if (documentContentStyle.LeftIndent > 0f)
                            {
                                ginterface5_0.imethod_18("style", "padding-left:" + ginterface5_0.imethod_44(documentContentStyle.LeftIndent) + "px");
                            }
                            flag2 = true;
                        }
                    }
                    if (documentContentStyle.ParagraphListStyle != 0)
                    {
                        ginterface5_0.imethod_0("li");
                        flag2 = true;
                    }
                    else
                    {
                        ginterface5_0.imethod_0("p");
                        flag2 = true;
                    }
                }
                RuntimeDocumentContentStyle runtimeStyle2 = key.RuntimeStyle;
                switch (runtimeStyle2.Align)
                {
                    case DocumentContentAlignment.Left:
                        ginterface5_0.imethod_18("align", "left");
                        break;
                    case DocumentContentAlignment.Center:
                        ginterface5_0.imethod_18("align", "center");
                        break;
                    case DocumentContentAlignment.Right:
                        ginterface5_0.imethod_18("align", "right");
                        break;
                    case DocumentContentAlignment.Justify:
                        ginterface5_0.imethod_18("align", "justify");
                        break;
                    case DocumentContentAlignment.Distribute:
                        ginterface5_0.imethod_18("align", "justify");
                        break;
                }
                ginterface5_0.imethod_24();
                ginterface5_0.imethod_54(runtimeStyle2, key);
                ginterface5_0.imethod_25("word-wrap", "break-word");
                ginterface5_0.imethod_25("word-break", "break-all");
                if (ginterface5_0.imethod_19() == XWebBrowsersStyle.InternetExplorer || ginterface5_0.imethod_19() == XWebBrowsersStyle.InternetExplorer7 || ginterface5_0.imethod_19() == XWebBrowsersStyle.InternetExplorer8)
                {
                }
                if (ginterface5_0.imethod_46().method_14() && !(this is XTextTableCellElement) && (runtimeStyle2.Align == DocumentContentAlignment.Right || runtimeStyle2.Align == DocumentContentAlignment.Center))
                {
                    ginterface5_0.imethod_25("width", GraphicsUnitConvert.ToCSSLength(ClientWidth + 4f, OwnerDocument.DocumentGraphicsUnit, GEnum87.const_5));
                }
                ginterface5_0.imethod_26();
                if (key.TopicID >= 0)
                {
                    ginterface5_0.imethod_0("a");
                    ginterface5_0.imethod_33();
                    ginterface5_0.imethod_18("name", "DCTopic_" + key.TopicID);
                    ginterface5_0.imethod_1();
                }
                int num2 = 0;
                foreach (XTextElementList item3 in list)
                {
                    if (item3.Count == 1 && item3.LastElement is XTextParagraphFlagElement)
                    {
                        ginterface5_0.imethod_16(" ");
                        ginterface5_0.imethod_15("&nbsp;");
                    }
                    XTextElementList xTextElementList = WriterUtils.smethod_61(item3, ginterface5_0.imethod_48(), ginterface5_0, ginterface5_0.imethod_38());
                    int num3 = -1;
                    if (xTextElement != null)
                    {
                        num3 = xTextElementList.IndexOf(xTextElement);
                        if (num3 < 0)
                        {
                            continue;
                        }
                        xTextElement = null;
                    }
                    bool flag4 = false;
                    if (num2 > 0 && this is XTextDocumentContentElement && ginterface5_0.imethod_46().method_14())
                    {
                        flag4 = true;
                    }
                    if (flag4)
                    {
                        ginterface5_0.imethod_0("br");
                        ginterface5_0.imethod_1();
                    }
                    num2++;
                    for (int i = num3 + 1; i < xTextElementList.Count; i++)
                    {
                        XTextElement current3 = xTextElementList[i];
                        if (ginterface5_0.imethod_46().method_16() && current3 is XTextFieldBorderElement)
                        {
                            XTextInputFieldElement xTextInputFieldElement = current3.Parent as XTextInputFieldElement;
                            if (xTextInputFieldElement != null && xTextInputFieldElement.StartElement == current3)
                            {
                                xTextInputFieldElement.vmethod_18(ginterface5_0);
                                xTextElement = xTextInputFieldElement.EndElement;
                                int num4 = xTextElementList.IndexOf(xTextElement);
                                if (num4 <= 0)
                                {
                                    break;
                                }
                                i = num4;
                                xTextElement = null;
                                continue;
                            }
                        }
                        if (random_0.NextDouble() < 0.006)
                        {
                            GClass472 gClass = XTextDocument.smethod_6(bool_32: false);
                            if (!(gClass?.method_6() ?? true))
                            {
                                string text = gClass.method_8();
                                ginterface5_0.imethod_0("span");
                                ginterface5_0.imethod_18("style", "color:red;font-weight:bold");
                                ginterface5_0.imethod_33();
                                ginterface5_0.imethod_16(" ");
                                string string_ = XMLHelper.ToXMLEntryRandom(text, 0.4);
                                ginterface5_0.imethod_15(string_);
                                ginterface5_0.imethod_2();
                            }
                        }
                        current3.vmethod_18(ginterface5_0);
                    }
                }
                if (flag2)
                {
                    ginterface5_0.imethod_2();
                }
            }
            if (documentContentStyle.ParagraphListStyle != 0)
            {
                ginterface5_0.imethod_1();
            }
        }

        
        public XTextDocument method_53(int int_13)
        {
            int num = 0;
            if (int_13 < 0)
            {
                throw new ArgumentOutOfRangeException("paragraphIndex=" + int_13);
            }
            XTextElementList xTextElementList = new XTextElementList();
            int num2 = 0;
            foreach (XTextElement item in PrivateContent)
            {
                if (item is XTextParagraphFlagElement)
                {
                    num2++;
                    if (num2 > int_13)
                    {
                        break;
                    }
                }
                if (num2 == int_13)
                {
                    xTextElementList.AddRaw(item);
                }
            }
            return WriterUtils.smethod_32(OwnerDocument, xTextElementList, bool_2: true);
        }

        public string method_54(int int_13)
        {
            int num = 12;
            if (int_13 < 0)
            {
                throw new ArgumentOutOfRangeException("paragraphIndex=" + int_13);
            }
            StringBuilder stringBuilder = new StringBuilder();
            int num2 = 0;
            foreach (XTextElement item in PrivateContent)
            {
                if (item is XTextParagraphFlagElement)
                {
                    num2++;
                    if (num2 > int_13)
                    {
                        break;
                    }
                }
                if (num2 == int_13)
                {
                    stringBuilder.Append(item.Text);
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        ///       删除区域结尾的空白内容
        ///       </summary>
        /// <param name="whiteSpace">空白字符</param>
        /// <param name="tabSpace">制表符</param>
        /// <param name="paragraphFlag">空白段落符号</param>
        /// <param name="chineseWhitespace">中文空格（全角空格）</param>
        /// <param name="pageBreak">分页符</param>
        /// <param name="lineBreak">换行符</param>
        /// <returns>操作删除的文档元素个数</returns>
        
        public int DeleteRedundant(bool whiteSpace, bool tabSpace, bool paragraphFlag, bool chineseWhitespace, bool pageBreak, bool lineBreak)
        {
            return DeleteRedundant(whiteSpace, tabSpace, paragraphFlag, chineseWhitespace, pageBreak, lineBreak, fastMode: false);
        }

        /// <summary>
        ///       删除区域结尾的空白内容
        ///       </summary>
        /// <param name="whiteSpace">空白字符</param>
        /// <param name="tabSpace">制表符</param>
        /// <param name="paragraphFlag">空白段落符号</param>
        /// <param name="chineseWhitespace">中文空格（全角空格）</param>
        /// <param name="pageBreak">分页符</param>
        /// <param name="lineBreak">换行符</param>
        /// <param name="fastMode">快速操作模式</param>
        /// <returns>操作删除的文档元素个数</returns>
        
        public int DeleteRedundant(bool whiteSpace, bool tabSpace, bool paragraphFlag, bool chineseWhitespace, bool pageBreak, bool lineBreak, bool fastMode)
        {
            int num = 0;
            _ = OwnerDocument.DocumentControler;
            for (int num2 = Elements.Count - 1; num2 >= 0; num2--)
            {
                XTextElement xTextElement = Elements[num2];
                if (xTextElement is XTextParagraphFlagElement)
                {
                    if (!paragraphFlag)
                    {
                        break;
                    }
                    num++;
                }
                else if (xTextElement is XTextLineBreakElement)
                {
                    if (!lineBreak)
                    {
                        break;
                    }
                    num++;
                }
                else if (xTextElement is XTextPageBreakElement)
                {
                    if (!pageBreak)
                    {
                        break;
                    }
                    num++;
                }
                else
                {
                    if (!(xTextElement is XTextCharElement))
                    {
                        break;
                    }
                    char charValue = ((XTextCharElement)xTextElement).CharValue;
                    if (chineseWhitespace && charValue == '\u3000')
                    {
                        num++;
                    }
                    else if (whiteSpace && charValue == ' ')
                    {
                        num++;
                    }
                    else
                    {
                        if (!tabSpace || charValue != '\t')
                        {
                            break;
                        }
                        num++;
                    }
                }
            }
            if (num > 0)
            {
                if (num >= Elements.Count)
                {
                    num--;
                }
                if (num > 0 && !(Elements[Elements.Count - num - 1] is XTextParagraphFlagElement) && Elements[Elements.Count - num] is XTextParagraphFlagElement)
                {
                    num--;
                }
            }
            if (num > 0)
            {
                if (!fastMode)
                {
                    XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
                    XTextElement currentElement = documentContentElement.CurrentElement;
                    XTextElement preElement = documentContentElement.Content.GetPreElement(Elements.SafeGet(Elements.Count - num - 1));
                    documentContentElement.Content.IndexOf(currentElement);
                    Elements.RemoveRange(Elements.Count - num, num);
                    EditorRefreshView();
                    if (!documentContentElement.Content.Contains(currentElement) && documentContentElement.Content.Contains(preElement))
                    {
                        documentContentElement.Content.MoveToElement(preElement);
                    }
                }
                return num;
            }
            return 0;
        }

        /// <summary>
        ///       复制对象
        ///       </summary>
        /// <param name="Deeply">是否深入复制子对象</param>
        /// <returns>复制品</returns>
        public override XTextElement Clone(bool Deeply)
        {
            XTextContentElement xTextContentElement = (XTextContentElement)base.Clone(Deeply);
            xTextContentElement.xtextElementList_2 = null;
            xTextContentElement.xtextLineList_0 = null;
            xTextContentElement.list_1 = null;
            xTextContentElement.bool_18 = false;
            xTextContentElement.dictionary_0 = null;
            xTextContentElement.FreeLayoutElements = null;
            xTextContentElement.class124_0 = null;
            xTextContentElement.bool_17 = true;
            if (dcgridLineInfo_0 != null)
            {
                xTextContentElement.dcgridLineInfo_0 = dcgridLineInfo_0.method_5();
            }
            if (!Deeply || !RuntimeVisible)
            {
            }
            return xTextContentElement;
        }

        public override void Dispose()
        {
            base.Dispose();
            if (dictionary_0 != null)
            {
                dictionary_0.Clear();
                dictionary_0 = null;
            }
            if (list_0 != null)
            {
                list_0.Clear();
                list_0 = null;
            }
            dcgridLineInfo_0 = null;
            if (xtextElementList_3 != null)
            {
                xtextElementList_3.Clear();
                xtextElementList_3 = null;
            }
            if (xtextElementList_2 != null)
            {
                xtextElementList_2.Clear();
                xtextElementList_2 = null;
            }
            if (xtextLineList_0 != null)
            {
                xtextLineList_0.method_2();
                xtextLineList_0 = null;
            }
            if (class124_0 != null)
            {
                class124_0.Clear();
                class124_0 = null;
            }
            if (list_1 != null)
            {
                list_1.Clear();
                list_1 = null;
            }
        }
    }
}
