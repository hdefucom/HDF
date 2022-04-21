using DCSoft.Printing;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
    /// <summary>
    ///       文档批注
    ///       </summary>
    /// <remarks>编制 袁永福</remarks>
    [Serializable]
    [ComDefaultInterface(typeof(IDocumentComment))]
    [XmlType("Comment")]
    [ComVisible(true)]
    [ComClass("00012345-6789-ABCD-EF01-234567890099", "2C48283C-903F-450B-9752-99E9220441C4")]
    [ClassInterface(ClassInterfaceType.None)]

    [DebuggerDisplay("Comment:{Text}")]
    [Guid("00012345-6789-ABCD-EF01-234567890099")]
    public class DocumentComment : IDocumentComment
    {
        internal const string string_0 = "00012345-6789-ABCD-EF01-234567890099";

        internal const string string_1 = "2C48283C-903F-450B-9752-99E9220441C4";

        internal bool bool_0 = false;

        private string string_2 = null;

        private bool bool_1 = false;

        [NonSerialized]
        private XTextDocument xtextDocument_0 = null;

        [NonSerialized]
        private XTextElementList xtextElementList_0 = null;

        private bool bool_2 = true;

        [NonSerialized]
        private XTextElement xtextElement_0 = null;

        [NonSerialized]
        private object object_0 = null;

        [NonSerialized]
        private float float_0 = 0f;

        [NonSerialized]
        internal bool bool_3 = false;

        private int int_0 = 0;

        private bool bool_4 = false;

        private XAttributeList xattributeList_0 = new XAttributeList();

        private string string_3 = null;

        private string string_4 = null;

        public static readonly DateTime dateTime_0 = new DateTime(1980, 1, 1);

        private DateTime dateTime_1 = dateTime_0;

        private string string_5 = null;

        private int int_1 = -1;

        private Color color_0 = Color.FromArgb(255, 213, 213);

        private Color color_1 = Color.Black;

        private Color color_2 = Color.Red;

        [NonSerialized]
        private float float_1 = 0f;

        [NonSerialized]
        private float float_2 = 0f;

        [NonSerialized]
        private float float_3 = 0f;

        [NonSerialized]
        private float float_4 = 0f;

        private float float_5 = 0f;

        [NonSerialized]
        private float float_6 = -1f;

        /// <summary>
        ///       为内部生成的文档批注对象
        ///       </summary>

        [Browsable(false)]
        public bool IsInternal => bool_0;

        /// <summary>
        ///       标题
        ///       </summary>
        [DefaultValue(null)]
        [XmlElement]
        public string Title
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
        ///       视图状态无效标记
        ///       </summary>
        [Browsable(false)]
        [XmlIgnore]

        public bool Invalidate
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
        ///       对象所属文档对象
        ///       </summary>

        [Browsable(false)]
        [XmlIgnore]
        public XTextDocument Document
        {
            get
            {
                return xtextDocument_0;
            }
            set
            {
                xtextDocument_0 = value;
            }
        }

        /// <summary>
        ///       引用本批注的文档元素列表
        ///       </summary>
        [XmlIgnore]

        [Browsable(false)]
        public XTextElementList ReferenceElements
        {
            get
            {
                if (IsInternal)
                {
                    return xtextElementList_0;
                }
                if (xtextElementList_0 == null)
                {
                    xtextElementList_0 = new XTextElementList();
                    List<int> list = new List<int>();
                    foreach (DocumentContentStyle style in Document.ContentStyles.Styles)
                    {
                        if (style.CommentIndex == Index)
                        {
                            list.Add(Document.ContentStyles.Styles.IndexOf(style));
                        }
                    }
                    foreach (XTextElement item in Document.Body.Content)
                    {
                        if (item.StyleIndex >= 0 && list.Contains(item.StyleIndex))
                        {
                            xtextElementList_0.Add(item);
                        }
                    }
                }
                return xtextElementList_0;
            }
            set
            {
                xtextElementList_0 = value;
            }
        }

        /// <summary>
        ///       DCWriter内部使用。运行时是否可见
        ///       </summary>
        [XmlIgnore]

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RuntimeVisible
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
        ///       锚元素
        ///       </summary>
        [Browsable(false)]

        [XmlIgnore]

        public XTextElement AnchorElement
        {
            get
            {
                return xtextElement_0;
            }
            set
            {
                xtextElement_0 = value;
            }
        }

        /// <summary>
        ///       注释所属的文档页面对象
        ///       </summary>

        [XmlIgnore]
        [Browsable(false)]

        public PrintPage OwnerPage
        {
            get
            {
                XTextElement anchorElement = AnchorElement;
                if (!RuntimeVisible || anchorElement == null || anchorElement.OwnerLine == null)
                {
                    return null;
                }
                return anchorElement.OwnerLine.OwnerPage;
            }
        }

        /// <summary>
        ///       绑定的对象
        ///       </summary>

        [XmlIgnore]
        [Browsable(false)]
        public object DataBoundItem
        {
            get
            {
                return object_0;
            }
            set
            {
                object_0 = value;
            }
        }

        /// <summary>
        ///       定位位置
        ///       </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]

        [XmlIgnore]

        [Browsable(false)]
        public float AnchorPosition
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
        ///       编号
        ///       </summary>
        [XmlAttribute]

        [HtmlAttribute]
        public int Index
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
        ///       绑定了用户痕迹
        ///       </summary>
        [HtmlAttribute]
        [DefaultValue(false)]

        public bool BindingUserTrack
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
        ///       自定义属性
        ///       </summary>
        [XmlArrayItem("Attribute", typeof(XAttribute))]

        [HtmlAttribute]
        public XAttributeList Attributes
        {
            get
            {
                if (xattributeList_0 == null)
                {
                    xattributeList_0 = new XAttributeList();
                }
                return xattributeList_0;
            }
            set
            {
                xattributeList_0 = value;
            }
        }

        /// <summary>
        ///       创建者编号
        ///       </summary>
        [HtmlAttribute]

        [DefaultValue(null)]
        public string AuthorID
        {
            get
            {
                return string_3;
            }
            set
            {
                if (string_3 != value)
                {
                    string_3 = value;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       创建者
        ///       </summary>
        [DefaultValue(null)]

        [HtmlAttribute]
        public string Author
        {
            get
            {
                return string_4;
            }
            set
            {
                if (string_4 != value)
                {
                    string_4 = value;
                    float_6 = -1f;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       对象的创建时间
        ///       </summary>
        [DefaultValue(typeof(DateTime), "1980-1-1")]
        [HtmlAttribute]

        public DateTime CreationTime
        {
            get
            {
                return dateTime_1;
            }
            set
            {
                if (dateTime_1 != value)
                {
                    dateTime_1 = value;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       批注文本
        ///       </summary>
        [DefaultValue(null)]

        [HtmlAttribute]
        public string Text
        {
            get
            {
                return string_5;
            }
            set
            {
                if (string_5 != value)
                {
                    string_5 = value;
                    float_6 = -1f;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       创建者编号
        ///       </summary>
        [DefaultValue(-1)]
        [HtmlAttribute]

        public int CreatorIndex
        {
            get
            {
                return int_1;
            }
            set
            {
                if (int_1 != value)
                {
                    int_1 = value;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       背景色
        ///       </summary>

        [XmlIgnore]
        public Color BackColor
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
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       文本颜色
        ///       </summary>
        [DefaultValue(typeof(Color), "Black")]
        [XmlIgnore]

        public Color ForeColor
        {
            get
            {
                return color_1;
            }
            set
            {
                if (color_1 != value)
                {
                    color_1 = value;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       边框色
        ///       </summary>
        [DefaultValue(typeof(Color), "Red")]
        [XmlIgnore]

        public Color BorderColor
        {
            get
            {
                return color_2;
            }
            set
            {
                if (color_2 != value)
                {
                    color_2 = value;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       左边位置
        ///       </summary>

        [Browsable(false)]
        [XmlIgnore]
        public float Left
        {
            get
            {
                return float_1;
            }
            set
            {
                if (float_1 != value)
                {
                    float_1 = value;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       顶端位置
        ///       </summary>
        [Browsable(false)]

        [XmlIgnore]
        public float Top
        {
            get
            {
                return float_2;
            }
            set
            {
                if (float_2 != value)
                {
                    float_2 = value;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       宽度
        ///       </summary>
        [XmlIgnore]

        [Browsable(false)]
        public float Width
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
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       高度
        ///       </summary>
        [XmlIgnore]

        [Browsable(false)]
        public float Height
        {
            get
            {
                return float_4;
            }
            set
            {
                if (float_4 != value)
                {
                    float_4 = value;
                    Invalidate = true;
                }
            }
        }

        /// <summary>
        ///       内部的新的高度
        ///       </summary>

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlIgnore]
        public float NewHeight
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
        ///       内容高度
        ///       </summary>

        [Browsable(false)]
        [XmlIgnore]
        public float ContentHeight
        {
            get
            {
                return float_6;
            }
            set
            {
                if (float_6 != value)
                {
                    float_6 = value;
                    bool_1 = true;
                }
            }
        }

        /// <summary>
        ///       初始化对象
        ///       </summary>

        public DocumentComment()
        {
        }


        public DocumentComment method_0()
        {
            return (DocumentComment)MemberwiseClone();
        }


        public void method_1(XTextDocument xtextDocument_1)
        {
            if (xtextDocument_1 != null && xtextDocument_1.Options.BehaviorOptions.InsertCommentBindingUserTrack && CreatorIndex >= 0 && CreatorIndex < xtextDocument_1.UserHistories.Count)
            {
                int permissionLevel = xtextDocument_1.UserHistories[CreatorIndex].PermissionLevel;
                Color baseColor = Color.Transparent;
                TrackVisibleConfig trackVisibleConfig = xtextDocument_1.Options.SecurityOptions.GetTrackVisibleConfig(permissionLevel);
                if (trackVisibleConfig != null)
                {
                    baseColor = trackVisibleConfig.BackgroundColor;
                }
                if (baseColor.A != 0)
                {
                    BackColor = ControlPaint.Dark(baseColor);
                }
            }
        }

        /// <summary>
        ///       返回表示对象的字符串
        ///       </summary>
        /// <returns>
        /// </returns>

        public override string ToString()
        {
            return Index + " " + Author + ":" + Text;
        }
    }
}
