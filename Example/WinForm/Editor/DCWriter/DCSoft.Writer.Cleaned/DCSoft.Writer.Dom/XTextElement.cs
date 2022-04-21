using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom.Undo;
using DCSoft.Writer.Script;
using DCSoft.Writer.Security;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
    /// <summary>
    ///       文档元素基础类型
    ///       </summary>
    /// <remarks>
    ///       本类型是文本文档对象模型的最基础的类型,任何其他的文本文档对象类型都是从该类型
    ///       派生的,本类型定义了所有文本文档对象所需要的通用程序,并定义了一些常用例程.
    ///       编制 袁永福 2012-1-12
    ///       </remarks>
    [Serializable]
    [ComClass("00012345-6789-ABCD-EF01-234567890009", "26ABDEDB-D16C-3C3C-A699-34268D8C7D95")]
    
    [XmlType("Element")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("00012345-6789-ABCD-EF01-234567890009")]
    [ComDefaultInterface(typeof(IXTextElement))]
    
    public abstract class XTextElement : IDisposable, IXTextElement, IGetSetAttribute//, GInterface0
    {
        internal const string string_0 = "00012345-6789-ABCD-EF01-234567890009";

        internal const string string_1 = "26ABDEDB-D16C-3C3C-A699-34268D8C7D95";

        internal static int int_0 = 0;

        private bool bool_0 = false;

        [NonSerialized]
        private bool bool_1 = false;

        private int int_1 = int_0++;

        private string string_2 = null;

        private XTextDocument xtextDocument_0 = null;

        [NonSerialized]
        internal int int_2 = -1;

        [NonSerialized]
        internal int int_3 = -1;

        [NonSerialized]
        private bool bool_2 = true;

        private XTextContainerElement xtextContainerElement_0 = null;

        private int int_4 = -1;

        [NonSerialized]
        private XTextLine xtextLine_0 = null;

        [NonSerialized]
        private RuntimeDocumentContentStyle runtimeDocumentContentStyle_0 = null;

        [NonSerialized]
        private DocumentContentStyle documentContentStyle_0 = null;

        private int int_5 = -1;

        private bool bool_3 = true;

        private bool bool_4 = true;

        private float float_0 = 0f;

        private float float_1 = 0f;

        private float float_2 = 0f;

        private float float_3 = 0f;

        private float float_4 = 0f;

        /// <summary>
        ///       内容版本号
        ///       </summary>
        [NonSerialized]
        protected int _ContentVersion = 0;

        /// <summary>
        ///       新输入的内容
        ///       </summary>
        /// <remarks>
        ///       用户在用户界面上新输入的内容，这个状态不保存。
        ///       </remarks>
        [XmlIgnore]
        
        public bool IsNewInputContent => bool_0;

        /// <summary>
        ///       对象运行时的位置排版模式
        ///       </summary>
        
        public virtual ElementPositionStyle RuntimePositionStyle => ElementPositionStyle.Static;

        /// <summary>
        ///       运行时的Z方向位置类型
        ///       </summary>
        
        public virtual ElementZOrderStyle RuntimeZOrderStyle => ElementZOrderStyle.Normal;

        /// <summary>
        ///       DCWriter内部使用。元素是否在一个收缩的文档节中
        ///       </summary>
        [Browsable(false)]
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ComVisible(false)]
        public bool IsInCollapsedSection
        {
            get
            {
                XTextElement parent = Parent;
                while (true)
                {
                    if (parent != null)
                    {
                        if (parent is XTextSectionElement && ((XTextSectionElement)parent).RuntimeIsCollapsed)
                        {
                            break;
                        }
                        parent = parent.Parent;
                        continue;
                    }
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///       DCWriter内部使用。是否是从右到左排版的元素
        ///       </summary>
        
        [XmlIgnore]
        [DefaultValue(false)]
        public bool IsRightToLeft
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
        ///       是否支持文档视图小把柄对象
        ///       </summary>
        
        [Browsable(false)]
        public virtual bool SupportElementViewHandle => false;

        /// <summary>
        ///       元素实例编号
        ///       </summary>
        [Browsable(true)]
        
        [XmlIgnore]
        public int ElementInstanceIndex => int_1;

        /// <summary>
        ///       扩展标记文本
        ///       </summary>
        
        [XmlIgnore]
        public virtual string RuntimeAdornText => null;

        /// <summary>
        ///       返回运行时使用的脚本信息对象列表
        ///       </summary>
        [XmlIgnore]
        
        [ComVisible(false)]
        public virtual VBScriptItemList RuntimeScriptItems => null;

        /// <summary>
        ///       能否被选中
        ///       </summary>
        
        public virtual bool RuntimeSelectable => true;

        /// <summary>
        ///       自定义属性列表
        ///       </summary>
        
        [XmlArrayItem("Attribute", typeof(XAttribute))]
        [ComVisible(true)]
        [DefaultValue(null)]
        public virtual XAttributeList Attributes
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        ///       类型名称
        ///       </summary>
        [Browsable(false)]
        
        public string TypeName => GetType().Name;

        /// <summary>
        ///       获得供显示的类型名称
        ///       </summary>
        [Browsable(false)]
        
        public string DispalyTypeName => WriterUtils.smethod_17(GetType());

        /// <summary>
        ///       元素在DOM树中的显示名称
        ///       </summary>
        
        [Browsable(false)]
        public virtual string DomDisplayName => GetType().Name + ":" + ID;

        /// <summary>
        ///       元素类型
        ///       </summary>
        [Browsable(false)]
        public virtual ElementType _ElementType => WriterUtils.smethod_64(GetType());

        /// <summary>
        ///       内容是否修改标记
        ///       </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [Browsable(false)]
        public virtual bool Modified
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        ///       对象编号
        ///       </summary>
        [ComVisible(true)]
        
        [HtmlAttribute(DetectDefaultValue = true, AttributeName = "id")]
        [DefaultValue(null)]
        public string ID
        {
            get
            {
                return string_2;
            }
            set
            {
                string_2 = value;
            }
        }

        /// <summary>
        ///       元素在客户端的编号
        ///       </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        [ComVisible(false)]
        
        public string ClientID
        {
            get
            {
                string text = null;
                text = ((OwnerDocument != null) ? OwnerDocument.method_42(this) : ID);
                if (text == null)
                {
                    text = string.Empty;
                }
                return text;
            }
        }

        /// <summary>
        ///       文档元素编号前缀
        ///       </summary>
        
        public virtual string ElementIDPrefix => "element";

        /// <summary>
        ///       影子文档元素。
        ///       </summary>
        /// <remarks>某些元素具有影子元素，当修改和删除本元素等价于修改和删除影子元素</remarks>
        [Browsable(false)]
        
        [XmlIgnore]
        public virtual XTextElement ShadowElement => null;

        /// <summary>
        ///       对象所属的文档对象
        ///       </summary>
        [DefaultValue(null)]
        
        [Browsable(false)]
        [XmlIgnore]
        [ComVisible(true)]
        public virtual XTextDocument OwnerDocument
        {
            get
            {
                return xtextDocument_0;
            }
            set
            {
                xtextDocument_0 = value;
                runtimeDocumentContentStyle_0 = null;
            }
        }

        [ComVisible(false)]
        
        [Browsable(false)]
        public virtual bool UIIsUpdating
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return true;
                }
                return OwnerDocument.UIIsUpdating;
            }
        }

        /// <summary>
        ///       快速的获得对象所属文档对象
        ///       </summary>
        
        protected internal XTextDocument ElementOwnerDocument => xtextDocument_0;

        /// <summary>
        ///       文档元素所在的编辑器控件对象
        ///       </summary>
        [ComVisible(false)]
        
        [Browsable(false)]
        [XmlIgnore]
        public virtual WriterControl WriterControl
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return null;
                }
                return OwnerDocument.EditorControl;
            }
        }

        /// <summary>
        ///       元素内容的文本内容
        ///       </summary>
        [ComVisible(true)]
        [XmlIgnore]
        
        [Browsable(false)]
        public virtual string InnerText
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }

        /// <summary>
        ///       元素内容和元素本身的文本内容
        ///       </summary>
        [Browsable(false)]
        [ComVisible(true)]
        [XmlIgnore]
        
        public virtual string OuterText
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }

        /// <summary>
        ///       返回元素内置内容的文档XML字符串
        ///       </summary>
        [ComVisible(true)]
        
        [Browsable(false)]
        public virtual string InnerXML
        {
            get
            {
                using (XTextDocument xTextDocument = CreateContentDocument(includeThis: false))
                {
                    return xTextDocument?.XMLText;
                }
            }
        }

        /// <summary>
        ///       返回元素内置内容的文档XML字符串,而且不包含任何用户痕迹信息。
        ///       </summary>
        
        [Browsable(false)]
        [ComVisible(true)]
        public virtual string InnerXMLWithoutTrack
        {
            get
            {
                using (XTextDocument xTextDocument = CreateContentDocument(includeThis: false))
                {
                    if (xTextDocument == null)
                    {
                        return null;
                    }
                    xTextDocument.CommitUserTrace();
                    return xTextDocument.XMLText;
                }
            }
        }

        /// <summary>
        ///       返回元素内置内容的文档XML字符串
        ///       </summary>
        
        [Browsable(false)]
        [ComVisible(true)]
        public virtual string OuterXML
        {
            get
            {
                using (XTextDocument xTextDocument = CreateContentDocument(includeThis: true))
                {
                    return xTextDocument?.XMLText;
                }
            }
        }

        /// <summary>
        ///       返回元素内置内容的文档XML字符串,而且不包含任何用户痕迹信息。
        ///       </summary>
        [Browsable(false)]
        
        [ComVisible(true)]
        public virtual string OuterXMLWithoutTrack
        {
            get
            {
                using (XTextDocument xTextDocument = CreateContentDocument(includeThis: true))
                {
                    if (xTextDocument == null)
                    {
                        return null;
                    }
                    xTextDocument.CommitUserTrace();
                    return xTextDocument.XMLText;
                }
            }
        }

        /// <summary>
        ///       元素所属的文档级内容元素对象
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public XTextDocumentContentElement DocumentContentElement
        {
            get
            {
                XTextElement xTextElement = this;
                while (true)
                {
                    if (xTextElement != null)
                    {
                        if (xTextElement is XTextDocumentContentElement)
                        {
                            break;
                        }
                        xTextElement = xTextElement.Parent;
                        continue;
                    }
                    return null;
                }
                return (XTextDocumentContentElement)xTextElement;
            }
        }

        /// <summary>
        ///       元素所属的页面区域类型
        ///       </summary>
        
        [ComVisible(true)]
        public PageContentPartyStyle OwnerPagePartyStyle => DocumentContentElement?.PagePartyStyle ?? PageContentPartyStyle.Body;

        /// <summary>
        ///       元素所属的内容元素对象
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public virtual XTextContentElement ContentElement
        {
            get
            {
                XTextElement xTextElement = this;
                while (true)
                {
                    if (xTextElement != null)
                    {
                        if (xTextElement is XTextContentElement)
                        {
                            break;
                        }
                        xTextElement = xTextElement.Parent;
                        continue;
                    }
                    return null;
                }
                return (XTextContentElement)xTextElement;
            }
        }

        /// <summary>
        ///       获得该元素所在的表格单元格对象
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public virtual XTextTableCellElement OwnerCell
        {
            get
            {
                XTextElement xTextElement = this;
                while (true)
                {
                    if (xTextElement != null)
                    {
                        if (xTextElement is XTextTableCellElement)
                        {
                            break;
                        }
                        xTextElement = xTextElement.Parent;
                        continue;
                    }
                    return null;
                }
                return (XTextTableCellElement)xTextElement;
            }
        }

        /// <summary>
        ///       获得该元素所在的表格对象
        ///       </summary>
        
        [Browsable(false)]
        [XmlIgnore]
        public virtual XTextTableElement OwnerTable
        {
            get
            {
                XTextElement xTextElement = this;
                while (true)
                {
                    if (xTextElement != null)
                    {
                        if (xTextElement is XTextTableElement)
                        {
                            break;
                        }
                        xTextElement = xTextElement.Parent;
                        continue;
                    }
                    return null;
                }
                return (XTextTableElement)xTextElement;
            }
        }

        /// <summary>
        ///       获得该元素所在的文档节对象
        ///       </summary>
        
        [Browsable(false)]
        [XmlIgnore]
        public virtual XTextSectionElement OwnerSection
        {
            get
            {
                XTextElement xTextElement = this;
                while (true)
                {
                    if (xTextElement != null)
                    {
                        if (xTextElement is XTextSectionElement)
                        {
                            break;
                        }
                        xTextElement = xTextElement.Parent;
                        continue;
                    }
                    return null;
                }
                return (XTextSectionElement)xTextElement;
            }
        }

        /// <summary>
        ///       本属性已过期，请采用ContentIndex属性。
        ///       </summary>
        
        [Browsable(true)]
        [ComVisible(true)]
        public int ViewIndex => int_2;

        /// <summary>
        ///       元素在Header/Body/Footer.Content列表中的序号。
        ///       </summary>
        /// <remarks>
        ///       当文档包含大量的元素时,XTextContent中包含了大量的元素,此时它的 IndexOf 函数执行
        ///       缓慢,此处用该属性来预先设置到元素在 XTextContent中的序号,以此来代替或加速 IndexOf 函数
        ///       </remarks>
        
        
        [Browsable(true)]
        [ComVisible(true)]
        public int ContentIndex => int_2;

        /// <summary>
        ///       元素在所属的XTextContentElement.PrivateContent列表中的序号。
        ///       </summary>
        /// <remarks>
        ///       当文档包含大量的元素时,XTextContent中包含了大量的元素,此时它的 IndexOf 函数执行
        ///       缓慢,此处用该属性来预先设置到元素在 PrivateContent中的序号,以此来代替或加速 IndexOf 函数
        ///       </remarks>
        
        [Browsable(true)]
        [ComVisible(true)]
        public int PrivateContentIndex => int_3;

        /// <summary>
        ///       元素占据排版位置，能参与文档内容排版。
        ///       </summary>
        
        [Browsable(false)]
        public virtual bool RuntimeLayoutable => RuntimeVisible;

        /// <summary>
        ///       运行时元素是否显示
        ///       </summary>
        [Browsable(true)]
        [XmlIgnore]
        [ReadOnly(true)]
        public virtual bool RuntimeVisible
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
        ///        设计时元素是否可见
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public virtual bool Visible
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        /// <summary>
        ///       创建者权限许可等级
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public int CreatorPermessionLevel
        {
            get
            {
                int creatorIndex = RuntimeStyle.CreatorIndex;
                return OwnerDocument.UserHistories.GetPermissionLevel(creatorIndex);
            }
        }

        /// <summary>
        ///       逻辑删除者权限许可等级
        ///       </summary>
        [Browsable(false)]
        
        [XmlIgnore]
        public int DeleterPermissionLevel
        {
            get
            {
                int deleterIndex = RuntimeStyle.DeleterIndex;
                return OwnerDocument.UserHistories.GetPermissionLevel(deleterIndex);
            }
        }

        /// <summary>
        ///       元素是否是逻辑删除的
        ///       </summary>
        [Browsable(false)]
        [XmlIgnore]
        public bool IsLogicDeleted
        {
            get
            {
                XTextElement xTextElement = this;
                while (true)
                {
                    if (xTextElement != null)
                    {
                        if (xTextElement.RuntimeStyle.DeleterIndex >= 0)
                        {
                            break;
                        }
                        xTextElement = xTextElement.Parent;
                        continue;
                    }
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///       父对象
        ///       </summary>
        [Browsable(false)]
        [XmlIgnore]
        
        [ComVisible(true)]
        [DefaultValue(null)]
        public virtual XTextContainerElement Parent
        {
            get
            {
                return xtextContainerElement_0;
            }
            set
            {
                if (xtextContainerElement_0 != value)
                {
                    xtextContainerElement_0 = value;
                    if (xtextContainerElement_0 != null)
                    {
                        OwnerDocument = xtextContainerElement_0.OwnerDocument;
                    }
                }
            }
        }

        /// <summary>
        ///       元素在父节点的子节点列表中的序号
        ///       </summary>
        [XmlIgnore]
        [Browsable(true)]
        public virtual int ElementIndex
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
        ///       对象所在的文本行对象
        ///       </summary>
        [XmlIgnore]
        
        [DefaultValue(null)]
        [Browsable(false)]
        public XTextLine OwnerLine
        {
            get
            {
                return xtextLine_0;
            }
            set
            {
                xtextLine_0 = value;
            }
        }

        /// <summary>
        ///       对象在文本行中的从1开始的列号
        ///       </summary>
        
        [Browsable(false)]
        public int ColumnIndex
        {
            get
            {
                if (xtextLine_0 != null)
                {
                    return xtextLine_0.IndexOf(this) + 1;
                }
                return -1;
            }
        }

        /// <summary>
        ///       获得一个从0开始计算的当前元素所在的页码
        ///       </summary>
        
        public virtual int OwnerPageIndex
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return -1;
                }
                XTextElement firstContentElement = FirstContentElement;
                if (firstContentElement != null)
                {
                    XTextLine ownerLine = firstContentElement.OwnerLine;
                    if (ownerLine != null && ownerLine.OwnerPage != null)
                    {
                        if (OwnerDocument == null)
                        {
                            return ownerLine.OwnerPage.PageIndex;
                        }
                        return OwnerDocument.Pages.IndexOf(ownerLine.OwnerPage);
                    }
                }
                return -1;
            }
        }

        /// <summary>
        ///       获得一个从0开始计算的元素下边缘所能到达的页码
        ///       </summary>
        public virtual int OwnerLastPageIndex
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return -1;
                }
                float num = AbsTop + Height;
                return OwnerDocument.Pages.IndexOfByPosition(num - 0.5f, -1);
            }
        }

        /// <summary>
        ///       判断是否本元素或者子孙元素处于选择状态
        ///       </summary>
        [Browsable(false)]
        [XmlIgnore]
        public virtual bool HasSelection
        {
            get
            {
                if (DocumentContentElement == null)
                {
                    return false;
                }
                return DocumentContentElement.IsSelected(this);
            }
        }

        /// <summary>
        ///       绘制文档内容使用的样式
        ///       </summary>
        [XmlIgnore]
        [Browsable(false)]
        public virtual RuntimeDocumentContentStyle RuntimeStyle
        {
            get
            {
                method_8(bool_5: false);
                if (runtimeDocumentContentStyle_0 == null)
                {
                    XTextDocument ownerDocument = OwnerDocument;
                    if (ownerDocument != null)
                    {
                        runtimeDocumentContentStyle_0 = ownerDocument.ContentStyles.method_3(StyleIndex);
                    }
                }
                return runtimeDocumentContentStyle_0;
            }
        }

        /// <summary>
        ///       文档显示样式
        ///       </summary>
        
        [Browsable(true)]
        [XmlIgnore]
        [ReadOnly(true)]
        public virtual DocumentContentStyle Style
        {
            get
            {
                if (documentContentStyle_0 == null)
                {
                    RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                    if (runtimeStyle != null)
                    {
                        documentContentStyle_0 = (DocumentContentStyle)runtimeStyle.Parent.Clone();
                        documentContentStyle_0.bool_2 = false;
                    }
                    else
                    {
                        documentContentStyle_0 = new DocumentContentStyle();
                        documentContentStyle_0.bool_2 = false;
                    }
                }
                return documentContentStyle_0;
            }
            set
            {
                documentContentStyle_0 = value;
                if (documentContentStyle_0 != null)
                {
                    documentContentStyle_0.bool_2 = true;
                }
            }
        }

        /// <summary>
        ///       使用的样式编号
        ///       </summary>
        
        [DefaultValue(-1)]
        [XmlAttribute]
        public virtual int StyleIndex
        {
            get
            {
                return int_5;
            }
            set
            {
                if (int_5 != value)
                {
                    int_5 = value;
                    bool_3 = true;
                    runtimeDocumentContentStyle_0 = null;
                    documentContentStyle_0 = null;
                }
            }
        }

        /// <summary>
        ///       子对象列表
        ///       </summary>
        
        [Browsable(false)]
        [XmlIgnore]
        public virtual XTextElementList Elements
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        ///       元素中第一个显示在文档正文内容中的元素 
        ///       </summary>
        [XmlIgnore]
        
        [Browsable(false)]
        public virtual XTextElement FirstContentElementInPublicContent => FirstContentElement;

        /// <summary>
        ///       元素中最后一个显示在文档正文内容中的元素 
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public virtual XTextElement LastContentElementInPublicContent => LastContentElement;

        /// <summary>
        ///       元素中第一个显示在文档内容中的元素 
        ///       </summary>
        [XmlIgnore]
        
        [Browsable(false)]
        public virtual XTextElement FirstContentElement => this;

        /// <summary>
        ///       元素中最后一个显示在文档内容中的元素 
        ///       </summary>
        [Browsable(false)]
        
        [XmlIgnore]
        public virtual XTextElement LastContentElement => this;

        /// <summary>
        ///       元素大小无效标记
        ///       </summary>
        /// <remarks>若设置该属性,则元素的大小发生改变,系统需要从该元素
        ///       开始重新进行文档排版和分页</remarks>
        [XmlIgnore]
        
        [Browsable(false)]
        public virtual bool SizeInvalid
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
        ///       元素视图无效标记
        ///       </summary>
        /// <remarks>若设置该属性,则元素的显示样式无效,系统需要重新
        ///       绘制该元素</remarks>
        [Browsable(false)]
        [XmlIgnore]
        
        public bool ViewInvalid
        {
            get
            {
                return bool_4;
            }
            set
            {
                bool_4 = value;
            }
        }

        /// <summary>
        ///       对象左端位置
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(true)]
        public virtual float Left
        {
            get
            {
                return float_0;
            }
            set
            {
                float_0 = value;
            }
        }

        /// <summary>
        ///       对象顶端位置
        ///       </summary>
        
        [Browsable(true)]
        [XmlIgnore]
        public virtual float Top
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
        ///       对象宽度
        ///       </summary>
        [XmlIgnore]
        
        [Browsable(true)]
        public virtual float Width
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
        ///       文档内容布局时使用的宽度
        ///       </summary>
        
        [Browsable(false)]
        public virtual float LayoutWidth => float_2;

        /// <summary>
        ///       文档内容布局时使用的高度
        ///       </summary>
        
        [Browsable(false)]
        public virtual float LayoutHeight => float_3;

        /// <summary>
        ///       像素单位的对象宽度
        ///       </summary>
        [Browsable(true)]
        [XmlIgnore]
        [ComVisible(true)]
        public float PixelWidth
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return GraphicsUnitConvert.Convert(Width, GraphicsUnit.Document, GraphicsUnit.Pixel);
                }
                return OwnerDocument.ToPixelFloat(Width);
            }
            set
            {
                if (OwnerDocument == null)
                {
                    Width = GraphicsUnitConvert.Convert(value, GraphicsUnit.Pixel, GraphicsUnit.Document);
                }
                else
                {
                    Width = GraphicsUnitConvert.Convert(value, GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
                }
            }
        }

        /// <summary>
        ///       像素单位的对象宽度
        ///       </summary>
        [ComVisible(true)]
        [XmlIgnore]
        [Browsable(true)]
        public float PixelHeight
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return GraphicsUnitConvert.Convert(Height, GraphicsUnit.Document, GraphicsUnit.Pixel);
                }
                return OwnerDocument.ToPixelFloat(Height);
            }
            set
            {
                if (OwnerDocument == null)
                {
                    Height = GraphicsUnitConvert.Convert(value, GraphicsUnit.Pixel, GraphicsUnit.Document);
                }
                else
                {
                    Height = GraphicsUnitConvert.Convert(value, GraphicsUnit.Pixel, OwnerDocument.DocumentGraphicsUnit);
                }
            }
        }

        /// <summary>
        ///       在视图中的显示宽度
        ///       </summary>
        [Browsable(false)]
        public virtual float ViewWidth => Width;

        /// <summary>
        ///       对象客户区的宽度
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(true)]
        [ReadOnly(true)]
        public virtual float ClientWidth
        {
            get
            {
                RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                if (runtimeStyle == null)
                {
                    return Width;
                }
                return Width - runtimeStyle.PaddingLeft - runtimeStyle.PaddingRight;
            }
            set
            {
                RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                if (runtimeStyle == null)
                {
                    Width = value;
                }
                else
                {
                    Width = value + runtimeStyle.PaddingLeft + runtimeStyle.PaddingRight;
                }
            }
        }

        /// <summary>
        ///       像素单位的客户端高度
        ///       </summary>
        [Browsable(true)]
        public float PixelClientHeigth
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return GraphicsUnitConvert.Convert(ClientHeight, GraphicsUnit.Document, GraphicsUnit.Pixel);
                }
                return OwnerDocument.ToPixelFloat(ClientHeight);
            }
        }

        /// <summary>
        ///       像素单位的客户端宽度
        ///       </summary>
        [Browsable(true)]
        public float PixelClientWidth
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return GraphicsUnitConvert.Convert(ClientWidth, GraphicsUnit.Document, GraphicsUnit.Pixel);
                }
                return OwnerDocument.ToPixelFloat(ClientWidth);
            }
        }

        /// <summary>
        ///       对象客户区的高度
        ///       </summary>
        [Browsable(true)]
        [XmlIgnore]
        [ReadOnly(true)]
        
        public virtual float ClientHeight
        {
            get
            {
                RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                if (runtimeStyle == null)
                {
                    return Height;
                }
                return Height - runtimeStyle.PaddingTop - runtimeStyle.PaddingBottom;
            }
            set
            {
                RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                if (runtimeStyle == null)
                {
                    Height = value;
                }
                else
                {
                    Height = value + runtimeStyle.PaddingTop + runtimeStyle.PaddingBottom;
                }
            }
        }

        /// <summary>
        ///       对象高度
        ///       </summary>
        [Browsable(true)]
        [XmlIgnore]
        public virtual float Height
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
                }
            }
        }

        internal RectangleF BoundsInContentElement
        {
            get
            {
                XTextLine ownerLine = OwnerLine;
                if (ownerLine != null)
                {
                    return new RectangleF(ownerLine.Left + Left, ownerLine.Top, Width + WidthFix, Math.Max(Height, ownerLine.Height));
                }
                RectangleF bounds = Bounds;
                for (XTextElement parent = Parent; parent != null; parent = parent.Parent)
                {
                    RuntimeDocumentContentStyle runtimeStyle = parent.RuntimeStyle;
                    bounds.Offset(parent.Left + runtimeStyle.PaddingLeft, parent.Top + runtimeStyle.PaddingTop);
                    if (parent is XTextContentElement)
                    {
                        break;
                    }
                }
                return bounds;
            }
        }

        /// <summary>
        ///       对象大小
        ///       </summary>
        [Browsable(false)]
        [XmlIgnore]
        public SizeF Size => new SizeF(Width, Height);

        /// <summary>
        ///       专为编辑器提供的对象大小属性
        ///       </summary>
        [XmlIgnore]
        [Browsable(false)]
        public virtual SizeF EditorSize
        {
            get
            {
                return new SizeF(Width, Height);
            }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        /// <summary>
        ///       对象右边缘位置
        ///       </summary>
        [Browsable(false)]
        [XmlIgnore]
        
        public float Right => float_0 + float_2;

        /// <summary>
        ///       对象底端位置
        ///       </summary>
        [XmlIgnore]
        
        public float Bottom => float_1 + float_3;

        /// <summary>
        ///       对象宽度修正值
        ///       </summary>
        
        [Browsable(true)]
        [XmlIgnore]
        public float WidthFix
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
        ///       对象边界
        ///       </summary>
        [XmlIgnore]
        [Browsable(false)]
        public RectangleF Bounds
        {
            get
            {
                return new RectangleF(float_0, float_1, float_2, float_3);
            }
            set
            {
                if (value.Width != 0f)
                {
                }
                float_0 = value.Left;
                float_1 = value.Top;
                float_2 = value.Width;
                float_3 = value.Height;
            }
        }

        /// <summary>
        ///       对象在文档中的绝对坐标位置
        ///       </summary>
        [XmlIgnore]
        
        [Browsable(false)]
        public virtual float AbsLeft
        {
            get
            {
                if (xtextLine_0 == null)
                {
                    if (Parent == null)
                    {
                        return float_0;
                    }
                    return float_0 + Parent.Left;
                }
                return float_0 + xtextLine_0.AbsLeft;
            }
        }

        /// <summary>
        ///       对象在文档中的绝对坐标位置
        ///       </summary>
        [Browsable(true)]
        
        [XmlIgnore]
        public virtual float AbsTop
        {
            get
            {
                if (xtextLine_0 == null)
                {
                    if (Parent == null)
                    {
                        return float_1;
                    }
                    return float_1 + Parent.AbsTop;
                }
                return float_1 + xtextLine_0.AbsTop;
            }
        }

        /// <summary>
        ///       绝对边界
        ///       </summary>
        
        [Browsable(false)]
        [XmlIgnore]
        public virtual RectangleF AbsBounds => new RectangleF(AbsLeft, AbsTop, Width, Height);

        /// <summary>
        ///       客户区的绝对边界
        ///       </summary>
        [Browsable(false)]
        
        [XmlIgnore]
        public virtual RectangleF AbsClientBounds
        {
            get
            {
                RectangleF absBounds = AbsBounds;
                RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
                return runtimeStyle.GetClientRectangleF(absBounds);
            }
        }

        /// <summary>
        ///       文档元素在视图中占据的边界
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public RectangleF ViewBounds
        {
            get
            {
                if (OwnerLine == null)
                {
                    return new RectangleF(AbsLeft, AbsTop, ViewWidth + float_4, Height);
                }
                return new RectangleF(AbsLeft, AbsTop, ViewWidth + float_4, OwnerLine.Height);
            }
        }

        /// <summary>
        ///       对象所示段落符号元素
        ///       </summary>
        [Browsable(false)]
        
        public XTextParagraphFlagElement OwnerParagraphEOF
        {
            get
            {
                if (OwnerDocument == null)
                {
                    return null;
                }
                return OwnerDocument.method_77(this);
            }
        }

        /// <summary>
        ///       获得同一层次中的上一个元素
        ///       </summary>
        [Browsable(false)]
        [ComVisible(true)]
        [XmlIgnore]
        public virtual XTextElement PreviousElement
        {
            get
            {
                XTextContainerElement parent = Parent;
                if (parent != null)
                {
                    int num = parent.Elements.IndexOf(this);
                    if (num > 0)
                    {
                        return parent.Elements[num - 1];
                    }
                }
                return null;
            }
        }

        /// <summary>
        ///       获得元素的同一层次的下一个元素
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        [ComVisible(true)]
        public virtual XTextElement NextElement
        {
            get
            {
                XTextContainerElement parent = Parent;
                if (parent != null)
                {
                    int num = parent.Elements.IndexOf(this);
                    if (num < parent.Elements.Count - 1)
                    {
                        return parent.Elements[num + 1];
                    }
                }
                return null;
            }
        }

        /// <summary>
        ///       元素内容版本号，当元素内容发生任何改变时，该属性值都会改变
        ///       </summary>
        
        [XmlIgnore]
        [Browsable(false)]
        public int ContentVersion => _ContentVersion;

        /// <summary>
        ///       判断元素是否获得输入焦点
        ///       </summary>
        [Browsable(false)]
        
        public virtual bool Focused
        {
            get
            {
                XTextDocumentContentElement documentContentElement = DocumentContentElement;
                return documentContentElement.CurrentElement == this;
            }
        }

        [XmlIgnore]
        [Browsable(false)]
        GInterface22 PropertyLogger
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        ///       表示对象内容的纯文本数据
        ///       </summary>
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [XmlIgnore]
        public virtual string Text
        {
            get
            {
                return ToString();
            }
            set
            {
            }
        }

        /// <summary>
        ///       表达式数值内容
        ///       </summary>
        [MemberExpressionable(MemberEffectLevel.ElementLayout)]
        
        [XmlIgnore]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ComVisible(true)]
        public virtual string FormulaValue
        {
            get
            {
                return Text;
            }
            set
            {
                Text = method_12(value);
            }
        }

        /// <summary>
        ///       元素事件列表
        ///       </summary>
        [XmlIgnore]
        
        [Browsable(false)]
        public virtual ElementEventTemplateList Events
        {
            get
            {
                if (OwnerDocument != null && OwnerDocument.EditorControl != null)
                {
                    return OwnerDocument.EditorControl.GetElementEventTemplates(this);
                }
                return null;
            }
        }

        /// <summary>
        ///       初始化对象
        ///       </summary>
        public XTextElement()
        {
        }

        internal void method_0(XTextContainerElement xtextContainerElement_1, XTextDocument xtextDocument_1, int int_6)
        {
            xtextContainerElement_0 = xtextContainerElement_1;
            xtextDocument_0 = xtextDocument_1;
            int_5 = int_6;
        }

        public virtual void vmethod_0(bool bool_5)
        {
            bool_0 = bool_5;
        }

        
        protected DataSourceTreeNode method_1(string string_3)
        {
            XTextDocument ownerDocument = OwnerDocument;
            if (!(ownerDocument?.Options.BehaviorOptions.EnableDataBinding ?? false))
            {
                return null;
            }
            DataSourceTreeNode result = null;
            if (string.IsNullOrEmpty(string_3))
            {
                XTextContainerElement parent = Parent;
                while (parent != null)
                {
                    if (parent.DataBoundNode == null)
                    {
                        if (parent != ownerDocument)
                        {
                            parent = parent.Parent;
                            continue;
                        }
                        result = ownerDocument.RuntimeDataSourceTree;
                        break;
                    }
                    result = parent.DataBoundNode;
                    break;
                }
            }
            else
            {
                result = ownerDocument.RuntimeDataSourceTree.GetSubNode(string_3, autoCreate: false);
            }
            return result;
        }

        
        public DataSourceTreeNode method_2(XDataBinding xdataBinding_0, UpdateDataBindingArgs updateDataBindingArgs_0, string string_3 = null)
        {
            if (xdataBinding_0 == null)
            {
                return null;
            }
            if (!OwnerDocument.method_104(xdataBinding_0))
            {
                return null;
            }
            if (string.IsNullOrEmpty(string_3))
            {
                return method_3(xdataBinding_0.DataSource, xdataBinding_0.BindingPath, updateDataBindingArgs_0);
            }
            return method_3(xdataBinding_0.DataSource, string_3, updateDataBindingArgs_0);
        }

        
        public DataSourceTreeNode method_3(string string_3, string string_4, UpdateDataBindingArgs updateDataBindingArgs_0)
        {
            if (!(OwnerDocument?.Options.BehaviorOptions.EnableDataBinding ?? false))
            {
                return null;
            }
            if (!(updateDataBindingArgs_0?.CheckForSpecifyParameterName(string_3) ?? true))
            {
                return null;
            }
            DataSourceTreeNode dataSourceTreeNode = method_1(string_3);
            if (!(dataSourceTreeNode?.IsEmpty ?? true))
            {
                string path = dataSourceTreeNode.OwnerDocument.TranslateRuntimePath(string_4);
                DataSourceTreeNode dataSourceTreeNode2 = dataSourceTreeNode.SelectSingleNode(path, autoCreateNode: true);
                if (dataSourceTreeNode2 == null)
                {
                    dataSourceTreeNode2 = DataSourceTreeNode.EmptyNode;
                }
                return dataSourceTreeNode2;
            }
            return DataSourceTreeNode.EmptyNode;
        }

        
        [Browsable(false)]
        public Color method_4(Color color_0)
        {
            XTextDocument ownerDocument = OwnerDocument;
            if (ownerDocument != null && ownerDocument.Options.ViewOptions.BothBlackWhenPrint)
            {
                return Color.Black;
            }
            return color_0;
        }

        
        [Browsable(false)]
        public virtual bool vmethod_1(bool bool_5)
        {
            VBScriptItemList runtimeScriptItems = RuntimeScriptItems;
            if (runtimeScriptItems != null && runtimeScriptItems.Count > 0)
            {
                return true;
            }
            if (bool_5)
            {
                XTextElementList elements = Elements;
                if (elements != null && elements.Count > 0)
                {
                    foreach (XTextElement item in elements)
                    {
                        if (item.vmethod_1(bool_5: true))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///       获得运行时用的成员表达式列表对象
        ///       </summary>
        /// <returns>
        /// </returns>
        
        public virtual PropertyExpressionInfoList GetRuntimePropertyExpressions()
        {
            return null;
        }

        
        public virtual GClass3 vmethod_2()
        {
            return null;
        }

        /// <summary>
        ///       获得提示文本信息对象
        ///       </summary>
        /// <returns>
        /// </returns>
        
        public virtual GClass96 GetToolTipInfo()
        {
            XTextDocument ownerDocument = OwnerDocument;
            if (ownerDocument != null && ownerDocument.Options.SecurityOptions.ShowPermissionTip)
            {
                StringBuilder stringBuilder = new StringBuilder();
                UserHistoryInfo info = ownerDocument.UserHistories.GetInfo(RuntimeStyle.CreatorIndex);
                if (info != null)
                {
                    QueryUserHistoryDisplayTextEventArgs queryUserHistoryDisplayTextEventArgs = new QueryUserHistoryDisplayTextEventArgs(WriterControl, ownerDocument, this, info, forLogicDelete: false);
                    string creatorTipFormatString = ownerDocument.Options.SecurityOptions.CreatorTipFormatString;
                    if (string.IsNullOrEmpty(creatorTipFormatString))
                    {
                        creatorTipFormatString = WriterStringsCore.CreatorTipFormatString;
                    }
                    info.DisplaySavedTime = (info.IsEmptySaveTime ? ownerDocument.GetNowDateTime() : info.SavedTime);
                    queryUserHistoryDisplayTextEventArgs.Result = StringFormatHelper.FormatExt(creatorTipFormatString, info);
                    if (WriterControl != null)
                    {
                        WriterControl.vmethod_45(queryUserHistoryDisplayTextEventArgs);
                    }
                    if (!string.IsNullOrEmpty(queryUserHistoryDisplayTextEventArgs.Result))
                    {
                        stringBuilder.Append(queryUserHistoryDisplayTextEventArgs.Result);
                    }
                }
                info = ownerDocument.UserHistories.GetInfo(RuntimeStyle.DeleterIndex);
                if (info != null)
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(Environment.NewLine);
                    }
                    QueryUserHistoryDisplayTextEventArgs queryUserHistoryDisplayTextEventArgs = new QueryUserHistoryDisplayTextEventArgs(WriterControl, ownerDocument, this, info, forLogicDelete: true);
                    string creatorTipFormatString = ownerDocument.Options.SecurityOptions.DeleterTipFormatString;
                    if (string.IsNullOrEmpty(creatorTipFormatString))
                    {
                        creatorTipFormatString = WriterStringsCore.DeleterTipFormatString;
                    }
                    info.DisplaySavedTime = (info.IsEmptySaveTime ? ownerDocument.GetNowDateTime() : info.SavedTime);
                    queryUserHistoryDisplayTextEventArgs.Result = StringFormatHelper.FormatExt(creatorTipFormatString, info);
                    if (WriterControl != null)
                    {
                        WriterControl.vmethod_45(queryUserHistoryDisplayTextEventArgs);
                    }
                    stringBuilder.Append(queryUserHistoryDisplayTextEventArgs.Result);
                }
                if (stringBuilder.Length > 0)
                {
                    GClass96 gClass = new GClass96();
                    if (string.IsNullOrEmpty(ownerDocument.Options.BehaviorOptions.TitleForToolTip))
                    {
                        gClass.method_4(WriterStringsCore.TipTitle);
                    }
                    else
                    {
                        gClass.method_4(ownerDocument.Options.BehaviorOptions.TitleForToolTip);
                    }
                    gClass.method_2(this);
                    gClass.method_6(stringBuilder.ToString());
                    gClass.method_8(GEnum4.const_0);
                    gClass.method_10(GEnum5.const_0);
                    gClass.method_12(ToolTipContentType.UserTrack);
                    gClass.method_14(bool_1: true);
                    return gClass;
                }
            }
            return null;
        }

        /// <summary>
        ///       获得指定名称的属性值 
        ///       </summary>
        /// <param name="name">属性名</param>
        /// <returns>属性值</returns>
        [ComVisible(true)]
        
        public virtual string GetAttribute(string name)
        {
            return null;
        }

        /// <summary>
        ///       设置属性值
        ///       </summary>
        /// <param name="name">属性名</param>
        /// <param name="Value">属性值</param>
        /// <returns>操作是否成功</returns>
        
        [ComVisible(true)]
        public virtual bool SetAttribute(string name, string Value)
        {
            return false;
        }

        /// <summary>
        ///       判断是否存在指定名称的属性
        ///       </summary>
        /// <param name="name">属性名</param>
        /// <returns>是否存在</returns>
        [ComVisible(true)]
        
        public virtual bool HasAttribute(string name)
        {
            return false;
        }

        /// <summary>
        ///       获得文档元素数值编辑器
        ///       </summary>
        /// <returns>获得的数值编辑器</returns>
        
        public virtual ElementValueEditor GetValueEditor()
        {
            return null;
        }

        internal void method_5(XTextDocument xtextDocument_1)
        {
            if (xtextDocument_0 != xtextDocument_1)
            {
                xtextDocument_0 = xtextDocument_1;
                runtimeDocumentContentStyle_0 = null;
            }
        }

        internal void method_6(XTextContainerElement xtextContainerElement_1)
        {
            XTextDocument ownerDocument = OwnerDocument;
            if (Parent != null)
            {
                Parent.RemoveChild(this);
            }
            if (ownerDocument != null && ownerDocument != xtextContainerElement_1.OwnerDocument && xtextContainerElement_1.OwnerDocument != null)
            {
                xtextContainerElement_1.OwnerDocument.ImportElement(this);
            }
            Parent = xtextContainerElement_1;
            OwnerDocument = xtextContainerElement_1.OwnerDocument;
        }

        /// <summary>
        ///       返回包含数据的XML片段,本函数返回的XML字符串可以作为编辑器控件或文档对象的函数CreateElementByXMLFragment()的参数。
        ///       </summary>
        /// <returns>生成的XML片段字符串</returns>
        [Browsable(false)]
        [ComVisible(true)]
        public virtual string GetXMLFragment()
        {
            return XMLHelper.SaveObjectToIndentXMLString(this);
        }

        /// <summary>
        ///       创建新的文档对象，使其包含本文档元素的复制品
        ///       </summary>
        /// <param name="includeThis">是否包含本文档原始对象</param>
        /// <returns>创建的文档对象</returns>
        
        public virtual XTextDocument CreateContentDocument(bool includeThis)
        {
            if (includeThis)
            {
                XTextElementList xTextElementList = new XTextElementList();
                xTextElementList.Add(Clone(Deeply: true));
                return WriterUtils.smethod_32(OwnerDocument, xTextElementList, bool_2: true);
            }
            return null;
        }

        /// <summary>
        ///       判断元素是否挂在指定文档的DOM结构中
        ///       </summary>
        /// <param name="document">文档对象</param>
        /// <param name="checkLogicDelete">检查逻辑删除标记</param>
        /// <returns>是否挂在DOM结构中</returns>
        
        public virtual bool BelongToDocumentDom(XTextDocument document, bool checkLogicDelete)
        {
            if (document == null)
            {
                return false;
            }
            if (Parent is XTextInputFieldElementBase)
            {
                XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)Parent;
                if (xTextInputFieldElementBase.IsBackgroundTextElement(this))
                {
                    return xTextInputFieldElementBase.BelongToDocumentDom(document, checkLogicDelete);
                }
            }
            XTextElement xTextElement = this;
            while (true)
            {
                if (xTextElement != null)
                {
                    if (checkLogicDelete)
                    {
                        RuntimeDocumentContentStyle runtimeStyle = xTextElement.RuntimeStyle;
                        if (runtimeStyle.DeleterIndex >= 0)
                        {
                            return false;
                        }
                    }
                    if (xTextElement != document)
                    {
                        if (xTextElement.Parent == null || !xTextElement.Parent.Elements.Contains(xTextElement))
                        {
                            break;
                        }
                        xTextElement = xTextElement.Parent;
                        continue;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        
        protected void method_7()
        {
            XTextDocumentContentElement documentContentElement = DocumentContentElement;
            if (documentContentElement != null && documentContentElement != OwnerDocument.CurrentContentElement)
            {
                documentContentElement.Focus();
            }
        }

        /// <summary>
        ///       修正DOM结构信息
        ///       </summary>
        
        public virtual void FixDomState()
        {
        }

        /// <summary>
        ///       设置元素为选中状态
        ///       </summary>
        
        public virtual bool Select()
        {
            method_7();
            XTextDocumentContentElement documentContentElement = DocumentContentElement;
            if (documentContentElement == null)
            {
                return false;
            }
            OwnerDocument.method_124(this);
            if (OwnerDocument.CurrentContentElement != documentContentElement)
            {
                documentContentElement.Focus();
            }
            int num = documentContentElement.Content.IndexOf(this);
            if (num >= 0)
            {
                documentContentElement.Content.method_47(num, 1);
                return true;
            }
            return false;
        }

        public virtual bool vmethod_3(GInterface5 ginterface5_0)
        {
            if (OwnerLine == null)
            {
                return false;
            }
            return OwnerLine.HtmlVisible;
        }

        /// <summary>
        ///       设置容器元素的可见性
        ///       </summary>
        /// <param name="visible">新的可见性</param>
        /// <returns>操作是否成功</returns>
        
        public bool EditorSetVisible(bool visible)
        {
            return EditorSetVisibleExt(visible, logUndo: true, fastMode: false);
        }

        /// <summary>
        ///       设置容器元素的可见性
        ///       </summary>
        /// <param name="visible">新的可见性</param>
        /// <param name="logUndo">是否记录撤销操作信息</param>
        /// <param name="fastMode">是否启用快速模式，当使用快速模式时，
        ///       只更新DOM结构，不更新用户界面视图</param>
        /// <returns>操作是否成功</returns>
        
        public virtual bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode)
        {
            bool result = false;
            bool visible2;
            if ((visible2 = Visible) != visible)
            {
                Visible = visible;
                RuntimeVisible = (Visible && OwnerDocument.IsVisible(this));
                if (OwnerDocument == null || OwnerDocument.ReadyState != DomReadyStates.Complete)
                {
                    return false;
                }
                if (UIIsUpdating && this is XTextContainerElement)
                {
                    XTextContainerElement xTextContainerElement = (XTextContainerElement)this;
                    xTextContainerElement.vmethod_31(bool_17: true);
                    return true;
                }
                if (Visible == visible)
                {
                    if (logUndo && OwnerDocument.BeginLogUndo())
                    {
                        OwnerDocument.UndoList.AddVisible(this, visible2, Visible);
                        OwnerDocument.EndLogUndo();
                    }
                    InvalidateView();
                    if (OwnerDocument.HighlightManager != null)
                    {
                        if (visible)
                        {
                            OwnerDocument.HighlightManager.imethod_9(this);
                        }
                        else
                        {
                            OwnerDocument.HighlightManager.imethod_8(this);
                        }
                    }
                    result = true;
                    XTextElement firstContentElement = FirstContentElement;
                    _ = LastContentElement;
                    XTextContentElement contentElement = ContentElement;
                    int int_ = 0;
                    XTextElement preElement = contentElement.PrivateContent.GetPreElement(firstContentElement);
                    if (visible2)
                    {
                        int_ = contentElement.PrivateContent.IndexOf(firstContentElement);
                    }
                    UpdateContentVersion();
                    XTextDocumentContentElement documentContentElement = DocumentContentElement;
                    XTextElement currentElement = documentContentElement.CurrentElement;
                    contentElement.vmethod_36(bool_22: true);
                    if (!visible2)
                    {
                        int_ = contentElement.PrivateContent.IndexOf(firstContentElement);
                    }
                    else if (preElement != null && contentElement.PrivateContent.Contains(preElement))
                    {
                        int_ = contentElement.PrivateContent.IndexOf(preElement);
                    }
                    contentElement.vmethod_38(int_, -1, fastMode);
                    if (!fastMode && currentElement != null)
                    {
                        int num = documentContentElement.Content.IndexOf(currentElement);
                        if (num >= 0)
                        {
                        }
                    }
                    OwnerDocument.Modified = true;
                    OwnerDocument.OnSelectionChanged();
                    if (OwnerDocument.EditorControl != null)
                    {
                        OwnerDocument.EditorControl.UpdateTextCaret();
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///       内部的直接设置元素父节点对象
        ///       </summary>
        /// <param name="c">
        /// </param>
        
        public void SetParentRaw(XTextContainerElement xtextContainerElement_1)
        {
            xtextContainerElement_0 = xtextContainerElement_1;
        }

        /// <summary>
        ///       判断指定元素是否是本元素的父节点或者更高层次的父节点。
        ///       </summary>
        /// <param name="parentElement">要判断的元素</param>
        /// <returns>是否是父节点或者更高级的父节点</returns>
        
        public virtual bool IsParentOrSupParent(XTextElement parentElement)
        {
            XTextElement parent = Parent;
            while (true)
            {
                if (parent != null)
                {
                    if (parent == parentElement)
                    {
                        break;
                    }
                    parent = parent.Parent;
                    continue;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        ///       设置文档元素样式
        ///       </summary>
        /// <param name="style">文档样式</param>
        /// <returns>操作是否成功</returns>
        [Obsolete("请直接设置element.Style下面的属性值")]
        [ComVisible(true)]
        
        public virtual bool EditorSetStyle(DocumentContentStyle style)
        {
            int num = 12;
            if (xtextDocument_0 == null)
            {
                throw new NullReferenceException(WriterStringsCore.NeedSetOwnerDocument);
            }
            if (style == null)
            {
                throw new ArgumentNullException("style");
            }
            StyleIndex = OwnerDocument.ContentStyles.GetStyleIndex(style);
            return true;
        }

        /// <summary>
        ///       开始设置文档元素样式
        ///       </summary>
        /// <returns>操作是否成功</returns>
        
        [Obsolete("请直接设置element.Style下面的属性值")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool BeginSetStyle()
        {
            return true;
        }

        /// <summary>
        ///       结束设置文档元素样式
        ///       </summary>
        /// <returns>操作是否成功</returns>
        [Obsolete("请直接设置element.Style下面的属性值")]
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool EndSetStyle()
        {
            if (OwnerDocument == null)
            {
                throw new NullReferenceException(WriterStringsCore.NeedSetOwnerDocument);
            }
            return method_8(bool_5: false);
        }

        /// <summary>
        ///       结束设置文档元素样式
        ///       </summary>
        /// <returns>操作是否成功</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        
        [Obsolete("请直接设置element.Style下面的属性值")]
        public virtual bool EndSetStyleWithLogUndo()
        {
            if (OwnerDocument == null)
            {
                throw new NullReferenceException(WriterStringsCore.NeedSetOwnerDocument);
            }
            return method_8(bool_5: true);
        }

        protected internal bool method_8(bool bool_5)
        {
            if (documentContentStyle_0 != null && documentContentStyle_0.bool_2)
            {
                XTextDocument xTextDocument = xtextDocument_0;
                if (xTextDocument != null)
                {
                    int oldStyleIndex = int_5;
                    int_5 = xTextDocument.ContentStyles.GetStyleIndex(documentContentStyle_0);
                    documentContentStyle_0.vmethod_3();
                    runtimeDocumentContentStyle_0 = null;
                    documentContentStyle_0 = null;
                    if (bool_5 && xTextDocument.CanLogUndo)
                    {
                        xTextDocument.UndoList.AddStyleIndex(this, oldStyleIndex, int_5);
                    }
                    return true;
                }
            }
            return false;
        }

        
        public virtual void vmethod_4()
        {
        }

        /// <summary>
        ///       声明元素的视图无效,需要重新绘制
        ///       </summary>
        
        public virtual void InvalidateView()
        {
            if (xtextDocument_0 != null)
            {
                xtextDocument_0.method_69(this);
            }
        }

        /// <summary>
        ///       声明元素的高亮度显示信息无效
        ///       </summary>
        
        public virtual void InvalidateHighlightInfo()
        {
            if (OwnerDocument != null && !OwnerDocument.IsLoadingDocument)
            {
                OwnerDocument.HighlightManager?.imethod_9(this);
            }
        }

        /// <summary>
        ///       沿着DOM树逐级向上查找指定类型的父容器
        ///       </summary>
        /// <param name="ParentType">父容器类型</param>
        /// <param name="includeThis">查找时是否包含元素本身</param>
        /// <returns>找到的父容器对象</returns>
        public virtual XTextElement GetOwnerParent(Type ParentType, bool includeThis)
        {
            XTextElement xTextElement = includeThis ? this : Parent;
            while (true)
            {
                if (xTextElement != null)
                {
                    Type type = xTextElement.GetType();
                    if (type.Equals(ParentType) || type.IsSubclassOf(ParentType))
                    {
                        break;
                    }
                    xTextElement = xTextElement.Parent;
                    continue;
                }
                return null;
            }
            return xTextElement;
        }

        /// <summary>
        ///       获得所有的上层元素列表
        ///       </summary>
        /// <returns>
        /// </returns>
        public virtual XTextElementList GetParentList()
        {
            XTextElementList xTextElementList = new XTextElementList();
            for (XTextElement parent = Parent; parent != null; parent = parent.Parent)
            {
                xTextElementList.Add(parent);
            }
            return xTextElementList;
        }

        /// <summary>
        ///       修改元素内容版本号，这会导致所有父级元素的ContentVersion的值的改变。
        ///       </summary>
        
        public virtual void UpdateContentVersion()
        {
            for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.Parent)
            {
                xTextElement._ContentVersion++;
            }
        }

        /// <summary>
        ///       单独的更新元素状态
        ///       </summary>
        /// <returns>
        /// </returns>
        
        public virtual void EditorRefreshView()
        {
            EditorRefreshViewExt(fastMode: false);
        }

        /// <summary>
        ///       单独的更新元素状态
        ///       </summary>
        /// <param name="fastMode">快速模式</param>
        /// <returns>
        /// </returns>
        
        public virtual void EditorRefreshViewExt(bool fastMode)
        {
            SizeInvalid = true;
            FixDomState();
            if (this is XTextContainerElement)
            {
                ((XTextContainerElement)this).vmethod_31(bool_17: true);
            }
            else
            {
                bool_2 = (Visible && OwnerDocument.IsVisible(this));
            }
            if (OwnerDocument == null)
            {
                throw new Exception(WriterStringsCore.OwnerDocumentNUll);
            }
            if (OwnerDocument.ReadyState == DomReadyStates.Complete && (WriterControl == null || !WriterControl.IsUpdating) && ContentElement != null)
            {
                if (!fastMode)
                {
                    ElementLoadEventArgs elementLoadEventArgs = new ElementLoadEventArgs(this, null);
                    elementLoadEventArgs.UpdateValueBinding = false;
                    AfterLoad(elementLoadEventArgs);
                }
                lock (OwnerDocument)
                {
                    object obj = (DocumentContentElement == null) ? null : DocumentContentElement.Selection.method_12();
                    method_8(bool_5: false);
                    OwnerDocument.ContentStyles.method_4();
                    ContentElement.vmethod_36(bool_22: true);
                    InvalidateView();
                    if (OwnerDocument.HighlightManager != null)
                    {
                        OwnerDocument.HighlightManager.imethod_9(this);
                    }
                    using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
                    {
                        DocumentPaintEventArgs documentPaintEventArgs = OwnerDocument.method_55(dcgraphics_);
                        documentPaintEventArgs.RenderMode = DocumentRenderMode.Paint;
                        documentPaintEventArgs.ActiveMode = false;
                        documentPaintEventArgs.Element = this;
                        if (fastMode)
                        {
                            documentPaintEventArgs.CheckSizeInvalidateWhenRefreshSize = true;
                        }
                        RefreshSize(documentPaintEventArgs);
                    }
                    XTextContentElement contentElement = ContentElement;
                    if (this is XTextContentElement && !(this is XTextDocumentContentElement))
                    {
                        contentElement = contentElement.Parent.ContentElement;
                    }
                    contentElement.vmethod_36(bool_22: true);
                    XTextElementList xTextElementList = new XTextElementList(this);
                    if (this is XTextTableCellElement)
                    {
                        xTextElementList.Add(((XTextTableCellElement)this).OwnerTable);
                    }
                    else if (this is XTextSectionElement)
                    {
                        xTextElementList.Add(Parent);
                    }
                    foreach (XTextElement item in new DomTreeNodeEnumerable(xTextElementList))
                    {
                        method_9(item, !fastMode);
                    }
                    DocumentContentElement.vmethod_44(bool_22: false);
                    if (obj == null)
                    {
                        contentElement.DocumentContentElement.Selection.method_4();
                    }
                    else
                    {
                        contentElement.DocumentContentElement.Selection.method_13(obj);
                    }
                    method_10(bool_5: false);
                }
            }
        }

        protected internal void method_9(XTextElement xtextElement_0, bool bool_5)
        {
            if (bool_5)
            {
                xtextElement_0.SizeInvalid = true;
            }
            if (xtextElement_0 is XTextTableElement)
            {
                XTextTableElement xTextTableElement = (XTextTableElement)xtextElement_0;
                foreach (XTextTableCellElement cell in xTextTableElement.Cells)
                {
                    cell.FixElements();
                    cell.Width = 0f;
                    cell.Height = 0f;
                    cell.vmethod_36(bool_22: false);
                    if (bool_5)
                    {
                    }
                }
                xTextTableElement.ExecuteLayout();
            }
            else if (xtextElement_0 is XTextSectionElement)
            {
                XTextSectionElement xTextSectionElement = (XTextSectionElement)xtextElement_0;
                xTextSectionElement.method_8(bool_5: false);
                xTextSectionElement.vmethod_36(bool_22: false);
                if (bool_5)
                {
                    xTextSectionElement.SizeInvalid = true;
                }
                xTextSectionElement.ExecuteLayout();
            }
        }

        /// <summary>
        ///       设置元素大小
        ///       </summary>
        /// <param name="width">新的元素宽度</param>
        /// <param name="height">新的元素高度</param>
        /// <param name="updateView">操作是否更新视图</param>
        /// <param name="logUndo">是否记录撤销操作信息</param>
        /// <returns>操作是否成功</returns>
        
        public virtual bool EditorSetSize(float width, float height, bool updateView, bool logUndo)
        {
            int num = 7;
            if (width <= 0f)
            {
                throw new ArgumentOutOfRangeException("width:" + width);
            }
            if (height <= 0f)
            {
                throw new ArgumentOutOfRangeException("height:" + height);
            }
            if (Width == width && Height == height)
            {
                return false;
            }
            SizeF sizeF = new SizeF(Width, Height);
            if (updateView)
            {
                InvalidateView();
            }
            Width = width;
            Height = height;
            SizeInvalid = false;
            if (logUndo && OwnerDocument.BeginLogUndo())
            {
                XTextUndoProperty xTextUndoProperty = new XTextUndoProperty();
                xTextUndoProperty.Style = GEnum18.const_1;
                xTextUndoProperty.Element = this;
                xTextUndoProperty.OldValue = sizeF;
                xTextUndoProperty.NewValue = new SizeF(Width, Height);
                OwnerDocument.UndoList.method_14(xTextUndoProperty);
                OwnerDocument.EndLogUndo();
            }
            if (updateView)
            {
                method_10(bool_5: true);
            }
            return true;
        }

        
        protected void method_10(bool bool_5)
        {
            if (OwnerLine != null)
            {
                OwnerLine.InvalidateState = true;
            }
            if (this is XTextSectionElement || this is XTextTableCellElement)
            {
                XTextContentElement contentElement = Parent.ContentElement;
                InvalidateView();
                int int_ = contentElement.PrivateContent.IndexOf(Elements.FirstContentElement);
                contentElement.method_31(int_);
            }
            else
            {
                XTextContentElement contentElement = ContentElement;
                InvalidateView();
                int int_ = contentElement.PrivateContent.IndexOf(this);
                if (int_ < 0)
                {
                    int_ = contentElement.PrivateContent.IndexOf(FirstContentElement);
                }
                if (int_ < 0)
                {
                    int_ = -10000;
                }
                contentElement.method_31(int_);
            }
            OwnerDocument.States.Layouted = true;
            InvalidateView();
            if (bool_5)
            {
                OwnerDocument.Modified = true;
                ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
                contentChangedEventArgs.EventSource = ContentChangedEventSource.UndoRedo;
                contentChangedEventArgs.Document = OwnerDocument;
                XTextContainerElement xTextContainerElement = this as XTextContainerElement;
                if (xTextContainerElement == null)
                {
                    xTextContainerElement = Parent;
                }
                contentChangedEventArgs.Element = xTextContainerElement;
                xTextContainerElement.method_23(contentChangedEventArgs);
                OwnerDocument.OnDocumentContentChanged();
            }
        }

        /// <summary>
        ///       处理文档用户界面事件
        ///       </summary>
        /// <param name="args">
        /// </param>
        
        public virtual void HandleDocumentEvent(DocumentEventArgs args)
        {
            switch (args.Style)
            {
                case DocumentEventStyles.ControlLostFoucs:
                case DocumentEventStyles.LostFocusExt:
                case DocumentEventStyles.ControlGotFoucs:
                    break;
                case DocumentEventStyles.MouseDown:
                    {
                        ElementMouseEventArgs elementMouseEventArgs = new ElementMouseEventArgs(args, this);
                        OnViewMouseDown(elementMouseEventArgs);
                        if (elementMouseEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementMouseEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.MouseMove:
                    {
                        ElementMouseEventArgs elementMouseEventArgs = new ElementMouseEventArgs(args, this);
                        OnViewMouseMove(elementMouseEventArgs);
                        if (elementMouseEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementMouseEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.MouseUp:
                    {
                        ElementMouseEventArgs elementMouseEventArgs = new ElementMouseEventArgs(args, this);
                        OnViewMouseUp(elementMouseEventArgs);
                        if (elementMouseEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementMouseEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.MouseClick:
                    {
                        ElementMouseEventArgs elementMouseEventArgs = new ElementMouseEventArgs(args, this);
                        OnViewMouseClick(elementMouseEventArgs);
                        if (elementMouseEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementMouseEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.MouseDblClick:
                    {
                        ElementMouseEventArgs elementMouseEventArgs = new ElementMouseEventArgs(args, this);
                        OnViewMouseDblClick(elementMouseEventArgs);
                        if (elementMouseEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementMouseEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.KeyDown:
                    {
                        ElementKeyEventArgs elementKeyEventArgs = new ElementKeyEventArgs(args, this);
                        OnViewKeyDown(elementKeyEventArgs);
                        if (elementKeyEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementKeyEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.KeyPress:
                    {
                        ElementKeyEventArgs elementKeyEventArgs = new ElementKeyEventArgs(args, this);
                        vmethod_15(elementKeyEventArgs);
                        if (elementKeyEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementKeyEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.KeyUp:
                    {
                        ElementKeyEventArgs elementKeyEventArgs = new ElementKeyEventArgs(args, this);
                        vmethod_16(elementKeyEventArgs);
                        if (elementKeyEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementKeyEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.LostFocus:
                    {
                        ElementEventArgs elementEventArgs = new ElementEventArgs(this);
                        OnViewLostFocus(elementEventArgs);
                        if (elementEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.GotFocus:
                    {
                        ElementEventArgs elementEventArgs = new ElementEventArgs(this);
                        OnViewGotFocus(elementEventArgs);
                        if (elementEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.MouseEnter:
                    {
                        ElementEventArgs elementEventArgs = new ElementEventArgs(this);
                        vmethod_7(elementEventArgs);
                        if (elementEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
                case DocumentEventStyles.MouseLeave:
                    {
                        ElementEventArgs elementEventArgs = new ElementEventArgs(this);
                        vmethod_8(elementEventArgs);
                        if (elementEventArgs.Handled)
                        {
                            args.Handled = true;
                        }
                        if (elementEventArgs.CancelBubble)
                        {
                            args.CancelBubble = true;
                        }
                        break;
                    }
            }
        }

        
        public virtual void OnViewGotFocus(ElementEventArgs elementEventArgs_0)
        {
            int num = 19;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.GlobalElementEventMan.method_23(this, elementEventArgs_0);
                    if (elementEventArgs_0.Handled)
                    {
                        return;
                    }
                    WriterControl.vmethod_26(elementEventArgs_0);
                    if (elementEventArgs_0.Handled)
                    {
                        return;
                    }
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasGotFocus)
                {
                    events.OnGotFocus(this, elementEventArgs_0);
                    if (elementEventArgs_0.Handled)
                    {
                        return;
                    }
                }
            }
            OwnerDocument.method_47(this, "GotFocus", new object[2]
            {
                this,
                elementEventArgs_0
            });
        }

        
        public virtual void OnViewLostFocus(ElementEventArgs elementEventArgs_0)
        {
            int num = 4;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.GlobalElementEventMan.method_25(this, elementEventArgs_0);
                    if (elementEventArgs_0.Handled)
                    {
                        return;
                    }
                    WriterControl.vmethod_27(elementEventArgs_0);
                    if (elementEventArgs_0.Handled)
                    {
                        return;
                    }
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasLostFocus)
                {
                    events.OnLostFocus(this, elementEventArgs_0);
                    if (elementEventArgs_0.Handled)
                    {
                        return;
                    }
                }
            }
            OwnerDocument.method_47(this, "LostFocus", new object[2]
            {
                this,
                elementEventArgs_0
            });
        }

        /// <summary>
        ///       获得输入焦点
        ///       </summary>
        
        public virtual void Focus()
        {
            if (!BelongToDocumentDom(OwnerDocument, checkLogicDelete: false))
            {
                return;
            }
            method_7();
            OwnerDocument.method_124(this);
            XTextElement firstContentElement = FirstContentElement;
            if (firstContentElement == null)
            {
                return;
            }
            XTextDocumentContentElement documentContentElement = DocumentContentElement;
            if (documentContentElement == null)
            {
                return;
            }
            if (OwnerDocument.CurrentContentElement != documentContentElement)
            {
                documentContentElement.Focus();
            }
            int num = -1;
            XTextElement xTextElement;
            for (xTextElement = firstContentElement; xTextElement != null; xTextElement = xTextElement.Parent)
            {
                num = documentContentElement.Content.IndexOf(xTextElement);
                if (num >= 0)
                {
                    break;
                }
            }
            if (num >= 0)
            {
                documentContentElement.SetSelection(num, 0);
                if (documentContentElement.Content.IndexOf(xTextElement) != num)
                {
                    documentContentElement.SetSelection(documentContentElement.Content.IndexOf(xTextElement), 0);
                }
                if (OwnerDocument.EditorControl != null)
                {
                    OwnerDocument.EditorControl.ScrollToCaret();
                }
            }
        }

        internal bool method_11(bool bool_5, bool bool_6)
        {
            if (WriterControl != null && WriterControl.IsUpdating)
            {
                return false;
            }
            XTextDocumentContentElement documentContentElement = DocumentContentElement;
            XTextContentElement contentElement = ContentElement;
            if (documentContentElement == null || contentElement == null)
            {
                return false;
            }
            int num = documentContentElement.Content.method_8(this);
            int num2 = contentElement.PrivateContent.method_9(this);
            if (num >= 0 && num2 < 0)
            {
                for (XTextElement parent = Parent; parent != null; parent = parent.Parent)
                {
                    if (parent is XTextInputFieldElementBase)
                    {
                        XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)parent;
                        if (xTextInputFieldElementBase.RuntimeSpecifyWidth < 0f && xTextInputFieldElementBase.method_33(this, bool_5, bool_6))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        
        public virtual void vmethod_7(ElementEventArgs elementEventArgs_0)
        {
            int num = 12;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.GlobalElementEventMan.method_33(this, elementEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasMouseEnter)
                {
                    events.OnMouseEnter(this, elementEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "MouseEnter", new object[2]
            {
                this,
                elementEventArgs_0
            });
        }

        
        public virtual void vmethod_8(ElementEventArgs elementEventArgs_0)
        {
            int num = 14;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.GlobalElementEventMan.method_35(this, elementEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasMouseLeave)
                {
                    events.OnMouseLeave(this, elementEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "MouseLeave", new object[2]
            {
                this,
                elementEventArgs_0
            });
        }

        
        public virtual void OnViewMouseDown(ElementMouseEventArgs elementMouseEventArgs_0)
        {
            int num = 8;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.vmethod_29(elementMouseEventArgs_0);
                    WriterControl.GlobalElementEventMan.method_7(this, elementMouseEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasMouseDown)
                {
                    events.OnMouseDown(this, elementMouseEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "MouseDown", new object[2]
            {
                this,
                elementMouseEventArgs_0
            });
        }

        
        public virtual void OnViewMouseMove(ElementMouseEventArgs elementMouseEventArgs_0)
        {
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.vmethod_30(elementMouseEventArgs_0);
                    WriterControl.GlobalElementEventMan.method_9(this, elementMouseEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasMouseMove)
                {
                    events.OnMouseMove(this, elementMouseEventArgs_0);
                }
            }
        }

        
        public virtual void OnViewMouseUp(ElementMouseEventArgs elementMouseEventArgs_0)
        {
            int num = 3;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.vmethod_31(elementMouseEventArgs_0);
                    WriterControl.GlobalElementEventMan.method_11(this, elementMouseEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasMouseUp)
                {
                    events.OnMouseUp(this, elementMouseEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "MouseUp", new object[2]
            {
                this,
                elementMouseEventArgs_0
            });
        }

        
        public virtual void OnViewMouseClick(ElementMouseEventArgs elementMouseEventArgs_0)
        {
            int num = 9;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.vmethod_25(elementMouseEventArgs_0);
                    WriterControl.GlobalElementEventMan.method_3(this, elementMouseEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasMouseClick)
                {
                    events.OnMouseClick(this, elementMouseEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "MouseClick", new object[2]
            {
                this,
                elementMouseEventArgs_0
            });
        }

        
        public virtual void OnViewMouseDblClick(ElementMouseEventArgs elementMouseEventArgs_0)
        {
            int num = 1;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.vmethod_28(elementMouseEventArgs_0);
                    WriterControl.GlobalElementEventMan.method_5(this, elementMouseEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasMouseDblClick)
                {
                    events.OnMouseDblClick(this, elementMouseEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "MouseDblClick", new object[2]
            {
                this,
                elementMouseEventArgs_0
            });
        }

        
        public virtual void OnViewKeyDown(ElementKeyEventArgs elementKeyEventArgs_0)
        {
            int num = 2;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.GlobalElementEventMan.method_13(this, elementKeyEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasKeyDown)
                {
                    events.OnKeyDown(this, elementKeyEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "KeyDown", new object[2]
            {
                this,
                elementKeyEventArgs_0
            });
        }

        
        public virtual void vmethod_15(ElementKeyEventArgs elementKeyEventArgs_0)
        {
            int num = 17;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.GlobalElementEventMan.method_15(this, elementKeyEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasKeyPress)
                {
                    events.OnKeyPress(this, elementKeyEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "KeyPress", new object[2]
            {
                this,
                elementKeyEventArgs_0
            });
        }

        
        public virtual void vmethod_16(ElementKeyEventArgs elementKeyEventArgs_0)
        {
            int num = 8;
            if (OwnerDocument.Options.BehaviorOptions.EnableElementEvents)
            {
                if (WriterControl != null)
                {
                    WriterControl.GlobalElementEventMan.method_17(this, elementKeyEventArgs_0);
                }
                ElementEventTemplateList events = Events;
                if (events != null && events.HasKeyUp)
                {
                    events.OnKeyUp(this, elementKeyEventArgs_0);
                }
            }
            OwnerDocument.method_47(this, "KeyUp", new object[2]
            {
                this,
                elementKeyEventArgs_0
            });
        }

        /// <summary>
        ///       复制对象
        ///       </summary>
        /// <param name="Deeply">是否深入复制子元素</param>
        /// <returns>复制品</returns>
        public virtual XTextElement Clone(bool Deeply)
        {
            XTextElement xTextElement = (XTextElement)MemberwiseClone();
            xTextElement.int_1 = int_0++;
            xTextElement._ContentVersion = 0;
            xTextElement.documentContentStyle_0 = null;
            xTextElement.xtextLine_0 = null;
            xTextElement.xtextContainerElement_0 = null;
            xTextElement.bool_3 = true;
            xTextElement.int_2 = -1;
            xTextElement.bool_4 = true;
            return xTextElement;
        }

        /// <summary>
        ///       输出元素包含的文本数据
        ///       </summary>
        /// <returns>
        /// </returns>
        public override string ToString()
        {
            return "";
        }

        /// <summary>
        ///       输出纯文本数据
        ///       </summary>
        /// <returns>纯文本数据</returns>
        
        public virtual string ToPlaintString()
        {
            return ToString();
        }

        /// <summary>
        ///       输出调试用的文本数据
        ///       </summary>
        /// <returns>文本数据</returns>
        
        public virtual string ToDebugString()
        {
            return GetType().Name + "(" + ID + ")";
        }

        
        public virtual void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
        {
            ID = readHTMLEventArgs_0.HtmlElement.method_37();
            readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
        }

        
        public virtual void vmethod_18(GInterface5 ginterface5_0)
        {
            ginterface5_0.imethod_23(this);
        }

        
        public virtual void vmethod_19(GClass103 gclass103_0)
        {
        }

        /// <summary>
        ///       绘制文档元素对象
        ///       </summary>
        /// <param name="args">事件参数</param>
        
        public virtual void Draw(DocumentPaintEventArgs args)
        {
            args.Render.vmethod_3(this, args);
            DrawContent(args);
        }

        /// <summary>
        ///       绘制文档元素内容
        ///       </summary>
        /// <param name="args">事件参数</param>
        
        public virtual void DrawContent(DocumentPaintEventArgs args)
        {
        }

        /// <summary>
        ///       计算元素大小
        ///       </summary>
        /// <param name="args">参数</param>
        
        public virtual void RefreshSize(DocumentPaintEventArgs args)
        {
        }

        
        public virtual HighlightInfoList vmethod_20()
        {
            return null;
        }

        /// <summary>
        ///       创建包含元素内容的图片对象
        ///       </summary>
        /// <returns>图片对象</returns>
        
        public virtual Image CreateContentImage()
        {
            if (Width <= 0f || Height <= 0f)
            {
                return null;
            }
            SizeF size = new SizeF(Width, Height);
            size = GraphicsUnitConvert.Convert(size, OwnerDocument.DocumentGraphicsUnit, GraphicsUnit.Pixel);
            Bitmap bitmap = new Bitmap((int)Math.Ceiling(size.Width), (int)Math.Ceiling(size.Height));
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.PageUnit = OwnerDocument.DocumentGraphicsUnit;
                RectangleF absBounds = AbsBounds;
                graphics.TranslateTransform(0f - absBounds.Left, 0f - absBounds.Top);
                DocumentPaintEventArgs documentPaintEventArgs = OwnerDocument.method_55(new DCGraphics(graphics));
                documentPaintEventArgs.PageClipRectangle = Rectangle.Ceiling(absBounds);
                documentPaintEventArgs.RenderMode = DocumentRenderMode.Bitmap;
                documentPaintEventArgs.Style = RuntimeStyle;
                documentPaintEventArgs.Type = DocumentContentElement.ContentPartyStyle;
                documentPaintEventArgs.ViewBounds = absBounds;
                documentPaintEventArgs.ClientViewBounds = RuntimeStyle.GetClientRectangleF(absBounds);
                documentPaintEventArgs.ActiveMode = true;
                documentPaintEventArgs.Bounds = absBounds;
                documentPaintEventArgs.Element = this;
                documentPaintEventArgs.ForCreateImage = true;
                documentPaintEventArgs.ClipRectangle = documentPaintEventArgs.ViewBounds;
                Draw(documentPaintEventArgs);
            }
            return bitmap;
        }

        
        public virtual void vmethod_21(string string_3)
        {
        }

        
        public virtual void vmethod_22()
        {
        }

        /// <summary>
        ///       文档加载后的处理
        ///       </summary>
        /// <param name="args">事件参数</param>
        
        public virtual void AfterLoad(ElementLoadEventArgs args)
        {
        }

        /// <summary>
        ///       销毁对象
        ///       </summary>
        public virtual void Dispose()
        {
            string_2 = null;
            xtextDocument_0 = null;
            xtextLine_0 = null;
            xtextContainerElement_0 = null;
            runtimeDocumentContentStyle_0 = null;
            documentContentStyle_0 = null;
        }

        
        protected string method_12(string string_3)
        {
            int num = 19;
            if (string_3 != null)
            {
                string_3 = string_3.Replace("\\r\\n", Environment.NewLine);
            }
            return string_3;
        }

        [ComVisible(true)]
        public string PBGetAttribute(ref string name)
        {
            string name2 = (name == null) ? null : string.Copy(name);
            string attribute = GetAttribute(name2);
            GC.KeepAlive(name);
            GC.KeepAlive(attribute);
            return attribute;
        }

        [ComVisible(true)]
        public bool PBSetAttribute(ref string name, ref string string_3)
        {
            string name2 = (name == null) ? null : string.Copy(name);
            string value = (string_3 == null) ? null : string.Copy(string_3);
            bool flag = SetAttribute(name2, value);
            GC.KeepAlive(name);
            GC.KeepAlive(string_3);
            GC.KeepAlive(flag);
            return flag;
        }
    }
}
