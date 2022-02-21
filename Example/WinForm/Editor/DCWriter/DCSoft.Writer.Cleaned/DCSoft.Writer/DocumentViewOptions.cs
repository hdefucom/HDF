using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms.Design;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档视图相关选项
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[Guid("00012345-6789-ABCD-EF01-23456789006B")]
	[ComClass("00012345-6789-ABCD-EF01-23456789006B", "D9CF1866-B246-40C7-BA6F-CAB856CEDEA8")]
	[DocumentComment]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IDocumentViewOptions))]
	
	public class DocumentViewOptions : ICloneable, IDocumentViewOptions
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-23456789006B";

		internal const string CLASSID_Interface = "D9CF1866-B246-40C7-BA6F-CAB856CEDEA8";

		private Color _NewInputContentUnderlineColor = Color.Transparent;

		private bool _SupportUG = false;

		private bool _HiddenTableBorderJumpPrintPage = false;

		private InterpolationMode _ImageInterpolationMode = InterpolationMode.High;

		private float _EmphasisMarkSize = 10f;

		private Color _MaskColorForJumpPrint = Color.FromArgb(100, 0, 0, 255);

		private bool _BothBlackWhenPrint = false;

		private Color _ProtectedContentBackColor = Color.Empty;

		private Color _DefaultLineColorForImageEditor = Color.Empty;

		private bool _ShowInputFieldStateTag = false;

		private RenderVisibility _SectionBorderVisibility = RenderVisibility.All;

		private RenderVisibility _TableCellBorderVisibility = RenderVisibility.All;

		private bool _ShowPageBreak = false;

		private InputFieldAdornTextType _DefaultAdornTextType = InputFieldAdornTextType.DataSource;

		private DCAdornTextVisibility _AdornTextVisibility = DCAdornTextVisibility.Hidden;

		private Color _AdornTextBackColor = Color.FromArgb(100, Color.Gray);

		private bool _ShowGrayMaskOverDisableContentParty = true;

		private bool _ShowFormButton = false;

		private int _PageMarginLineLength = 30;

		private EnableState _DefaultInputFieldHighlight = EnableState.Enabled;

		private bool _HighlightProtectedContent = false;

		private bool _ShowLineNumber = false;

		private bool _UseLanguage2 = false;

		private float _specifyExtenGridLineStep = 0f;

		private DashStyle _GridLineStyle = DashStyle.Solid;

		private bool _EnableRightToLeft = true;

		private bool _AutoZoomDropdownListFontSize = true;

		private float _DropdownListFontSize = 0f;

		private string _DropdownListFontName = null;

		private bool _ShowBackgroundCellID = false;

		private bool _ShowExpressionFlag = true;

		private string _CommentFontName = null;

		private float _CommentFontSize = 10f;

		private string _CommentDateFormatString = "yyyy-MM-dd HH:mm";

		private bool _OldWhitespaceWidth = false;

		private bool _ShowGridLine = false;

		private bool _EnableEncryptView = true;

		private Color _GridLineColor = Color.Gray;

		private bool _PreserveBackgroundTextWhenPrint = false;

		private bool _PrintBackgroundText = false;

		private bool _IgnoreFieldBorderWhenPrint = true;

		private bool _PrintGridLine = false;

		private bool _PrintImageAltText = false;

		private bool _ShowHeaderBottomLine = true;

		private float _HeaderBottomLineWidth = 1f;

		private bool _ShowCellNoneBorder = true;

		private Color _NoneBorderColor = Color.LightGray;

		private SmoothingMode _GraphicsSmoothingMode = SmoothingMode.None;

		/// <summary>
		///       文本展现样式
		///       </summary>
		private TextRenderingHint intTextRenderStyle = TextRenderingHint.ClearTypeGridFit;

		private bool _ShowParagraphFlag = true;

		private bool _HiddenFieldBorderWhenLostFocus = true;

		private bool _ShowFieldBorderElement = true;

		private Color _FieldBorderColor = Color.Empty;

		private bool _ShowPageLine = true;

		private bool _RichTextBoxCompatibility = false;

		private float _MinTableColumnWidth = 50f;

		private Color _DefaultInputFieldTextColor = Color.Transparent;

		private bool _EnableFieldTextColor = false;

		private Color _FieldTextColor = Color.Black;

		private Color _FieldTextPrintColor = Color.Transparent;

		private Color _FieldBackColor = Color.AliceBlue;

		private Color _FieldHoverBackColor = Color.LightBlue;

		private Color _FieldFocusedBackColor = Color.LightBlue;

		private Color _FieldInvalidateValueForeColor = Color.LightCoral;

		private Color _FieldInvalidateValueBackColor = Color.Transparent;

		private Color _ReadonlyFieldBorderColor = Color.Gray;

		private Color _TagColorForReadonylField = Color.Gray;

		private Color _TagColorForModifiedField = Color.Blue;

		private Color _TagColorForNormalField = Color.Red;

		private Color _TagColorForValueInvalidateField = Color.Red;

		private Color _UnEditableFieldBorderColor = Color.Red;

		private Color _NormalFieldBorderColor = Color.Blue;

		private Color _BackgroundTextColor = Color.Gray;

		private SelectionHighlightStyle _SelectionHighlight = SelectionHighlightStyle.MaskColor;

		private Color _SelectionHightlightMaskColor = Color.FromArgb(50, Color.Blue);

		private ContentLayoutDirectionStyle _LayoutDirection = ContentLayoutDirectionStyle.LeftToRight;

		/// <summary>
		///       表示新输入的内容的下划线颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Transparent")]
		public Color NewInputContentUnderlineColor
		{
			get
			{
				return _NewInputContentUnderlineColor;
			}
			set
			{
				_NewInputContentUnderlineColor = value;
			}
		}

		/// <summary>
		///       NewInputContentUnderlineColor属性的颜色值
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		public string NewInputContentUnderlineColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(NewInputContentUnderlineColor, Color.Transparent);
			}
			set
			{
				NewInputContentUnderlineColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       是否启用维文功能。启用维文功能会降低编辑器运行性能，而大多数情况下是无需启用维文功能。在此添加这个选项。
		///       </summary>
		[DefaultValue(false)]
		public bool SupportUG
		{
			get
			{
				return _SupportUG;
			}
			set
			{
				_SupportUG = value;
				Class126.smethod_1(value);
			}
		}

		/// <summary>
		///       在打印发生续打时的页面时隐藏表格边框线，但对于其他页面则正常打印。默认false。
		///       </summary>
		[DefaultValue(false)]
		public bool HiddenTableBorderJumpPrintPage
		{
			get
			{
				return _HiddenTableBorderJumpPrintPage;
			}
			set
			{
				_HiddenTableBorderJumpPrintPage = value;
			}
		}

		/// <summary>
		///       绘制图片时的呈现质量，默认High。
		///       </summary>
		/// <remarks>
		///       对于COM接口，可以直接设置该属性值为整数，其值可以为
		///       <br />Default = 0,
		///       <br />Low = 1,
		///       <br />High = 2,
		///       <br />Bilinear = 3,
		///       <br />Bicubic = 4,
		///       <br />NearestNeighbor = 5,
		///       <br />HighQualityBilinear = 6,
		///       <br />HighQualityBicubic = 7,
		///       </remarks>
		[DefaultValue(InterpolationMode.High)]
		public InterpolationMode ImageInterpolationMode
		{
			get
			{
				return _ImageInterpolationMode;
			}
			set
			{
				_ImageInterpolationMode = value;
			}
		}

		/// <summary>
		///       着重号的直径
		///       </summary>
		[DefaultValue(10f)]
		public float EmphasisMarkSize
		{
			get
			{
				return _EmphasisMarkSize;
			}
			set
			{
				_EmphasisMarkSize = value;
			}
		}

		/// <summary>
		///       续打时使用的遮盖色，可以是半透明颜色。
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "100,0,0,255")]
		public Color MaskColorForJumpPrint
		{
			get
			{
				return _MaskColorForJumpPrint;
			}
			set
			{
				_MaskColorForJumpPrint = value;
			}
		}

		/// <summary>
		///       续打时使用的遮盖色，可以是半透明颜色。
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[Browsable(false)]
		public string MaskColorForJumpPrintValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(MaskColorForJumpPrint, Color.FromArgb(100, 0, 0, 255));
			}
			set
			{
				MaskColorForJumpPrint = XMLSerializeHelper.StringToColor(value, Color.FromArgb(100, 0, 0, 255));
			}
		}

		/// <summary>
		///       打印的时候前景色全部强制为黑色
		///       </summary>
		[DefaultValue(false)]
		public bool BothBlackWhenPrint
		{
			get
			{
				return _BothBlackWhenPrint;
			}
			set
			{
				_BothBlackWhenPrint = value;
			}
		}

		/// <summary>
		///       受保护内容背景色
		///       </summary>
		[DefaultValue(typeof(Color), "Empty")]
		[XmlIgnore]
		[ComVisible(true)]
		public Color ProtectedContentBackColor
		{
			get
			{
				return _ProtectedContentBackColor;
			}
			set
			{
				_ProtectedContentBackColor = value;
			}
		}

		/// <summary>
		///       受保护内容背景色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		[ComVisible(true)]
		public string ProtectedContentBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(ProtectedContentBackColor, Color.Empty);
			}
			set
			{
				ProtectedContentBackColor = XMLSerializeHelper.StringToColor(value, Color.Empty);
			}
		}

		/// <summary>
		///       图片编辑器使用的默认线条颜色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Empty")]
		[ComVisible(true)]
		public Color DefaultLineColorForImageEditor
		{
			get
			{
				return _DefaultLineColorForImageEditor;
			}
			set
			{
				_DefaultLineColorForImageEditor = value;
			}
		}

		/// <summary>
		///       图片编辑器使用的默认线条颜色值
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		[Browsable(false)]
		[ComVisible(true)]
		public string DefaultLineColorForImageEditorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(DefaultLineColorForImageEditor, Color.Empty);
			}
			set
			{
				DefaultLineColorForImageEditor = XMLSerializeHelper.StringToColor(value, Color.Empty);
			}
		}

		/// <summary>
		///       是否显示输入域状态标签.本属性支持Web版控件。
		///       </summary>
		[DefaultValue(false)]
		public bool ShowInputFieldStateTag
		{
			get
			{
				return _ShowInputFieldStateTag;
			}
			set
			{
				_ShowInputFieldStateTag = value;
			}
		}

		/// <summary>
		///       文档节边框线可见性
		///       </summary>
		[DefaultValue(RenderVisibility.All)]
		[ComVisible(true)]
		public RenderVisibility SectionBorderVisibility
		{
			get
			{
				return _SectionBorderVisibility;
			}
			set
			{
				_SectionBorderVisibility = value;
			}
		}

		/// <summary>
		///       表格单元格边框线可见性
		///       </summary>
		[DefaultValue(RenderVisibility.All)]
		[ComVisible(true)]
		public RenderVisibility TableCellBorderVisibility
		{
			get
			{
				return _TableCellBorderVisibility;
			}
			set
			{
				_TableCellBorderVisibility = value;
			}
		}

		/// <summary>
		///       显示分页符
		///       </summary>
		[DefaultValue(false)]
		public bool ShowPageBreak
		{
			get
			{
				return _ShowPageBreak;
			}
			set
			{
				_ShowPageBreak = value;
			}
		}

		/// <summary>
		///       默认的输入域的扩展标记文字类型
		///       </summary>
		[DefaultValue(InputFieldAdornTextType.DataSource)]
		public InputFieldAdornTextType DefaultAdornTextType
		{
			get
			{
				return _DefaultAdornTextType;
			}
			set
			{
				_DefaultAdornTextType = value;
			}
		}

		/// <summary>
		///       文档元素扩展文本显示方式
		///       </summary>
		[DefaultValue(DCAdornTextVisibility.Hidden)]
		public DCAdornTextVisibility AdornTextVisibility
		{
			get
			{
				return _AdornTextVisibility;
			}
			set
			{
				_AdornTextVisibility = value;
			}
		}

		/// <summary>
		///       扩展文字背景色
		///       </summary>
		[XmlIgnore]
		public Color AdornTextBackColor
		{
			get
			{
				return _AdornTextBackColor;
			}
			set
			{
				_AdornTextBackColor = value;
			}
		}

		/// <summary>
		///       扩展文字背景色
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public string AdornTextBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(AdornTextBackColor, Color.Gray);
			}
			set
			{
				AdornTextBackColor = XMLSerializeHelper.StringToColor(value, Color.Gray);
			}
		}

		/// <summary>
		///       在禁用的文档部分上面显示灰色遮盖
		///       </summary>
		[DefaultValue(true)]
		public bool ShowGrayMaskOverDisableContentParty
		{
			get
			{
				return _ShowGrayMaskOverDisableContentParty;
			}
			set
			{
				_ShowGrayMaskOverDisableContentParty = value;
			}
		}

		/// <summary>
		///       是否显示表单按钮
		///       </summary>
		[DefaultValue(false)]
		public bool ShowFormButton
		{
			get
			{
				return _ShowFormButton;
			}
			set
			{
				_ShowFormButton = value;
			}
		}

		/// <summary>
		///       表示页面边界的线条长度,
		///       </summary>
		[DefaultValue(30)]
		public int PageMarginLineLength
		{
			get
			{
				return _PageMarginLineLength;
			}
			set
			{
				_PageMarginLineLength = value;
			}
		}

		/// <summary>
		///       默认的输入域高亮度显示模式
		///       </summary>
		[DefaultValue(EnableState.Enabled)]
		public virtual EnableState DefaultInputFieldHighlight
		{
			get
			{
				return _DefaultInputFieldHighlight;
			}
			set
			{
				_DefaultInputFieldHighlight = (EnableState)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       高亮度显示受保护的内容
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "HighlightProtectedContent")]
		public bool HighlightProtectedContent
		{
			get
			{
				return _HighlightProtectedContent;
			}
			set
			{
				_HighlightProtectedContent = value;
			}
		}

		/// <summary>
		///       是否显示行号
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "ShowLineNumber")]
		[DefaultValue(false)]
		public bool ShowLineNumber
		{
			get
			{
				return _ShowLineNumber;
			}
			set
			{
				_ShowLineNumber = value;
			}
		}

		/// <summary>
		///       是否启用第二语言
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "UseLanguage2")]
		public bool UseLanguage2
		{
			get
			{
				return _UseLanguage2;
			}
			set
			{
				_UseLanguage2 = value;
			}
		}

		/// <summary>
		///       指定的扩展文档网格线步长,单位为1/300英寸，小于等于0表示无效值，默认为0。
		///       </summary>
		[DefaultValue(0f)]
		[DCDescription(typeof(DocumentViewOptions), "SpecifyExtenGridLineStep")]
		public float SpecifyExtenGridLineStep
		{
			get
			{
				return _specifyExtenGridLineStep;
			}
			set
			{
				_specifyExtenGridLineStep = value;
			}
		}

		/// <summary>
		///       文档网格线线型
		///       </summary>
		[Obsolete("本属性已经淘汰了，请使用document.PageSettings.DocumentGridLine属性。")]
		[DefaultValue(DashStyle.Solid)]
		[DCDescription(typeof(DocumentViewOptions), "GridLineStyle")]
		[Editor(typeof(DashStyleEditor), typeof(UITypeEditor))]
		public DashStyle GridLineStyle
		{
			get
			{
				return _GridLineStyle;
			}
			set
			{
				_GridLineStyle = value;
			}
		}

		/// <summary>
		///       允许执行从右到左排版,当允许从右到左排版时会影响一些性能。当确定不再使用从右到左的功能时，可以设置该选项为false来提高一些性能。默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentViewOptions), "EnableRightToLeft")]
		public bool EnableRightToLeft
		{
			get
			{
				return _EnableRightToLeft;
			}
			set
			{
				_EnableRightToLeft = value;
			}
		}

		/// <summary>
		///       自动缩放下拉列表字体大小
		///       </summary>
		/// <remarks>
		///       当设置了DropdownListFontSize&gt;0时，本属性不起作用。
		///       </remarks>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentViewOptions), "AutoZoomDropdownListFontSize")]
		public bool AutoZoomDropdownListFontSize
		{
			get
			{
				return _AutoZoomDropdownListFontSize;
			}
			set
			{
				_AutoZoomDropdownListFontSize = value;
			}
		}

		/// <summary>
		///       下拉列表字体大小，小于等于0则不设置，默认为0.
		///       </summary>
		[DefaultValue(0f)]
		[DCDescription(typeof(DocumentViewOptions), "DropdownListFontSize")]
		public float DropdownListFontSize
		{
			get
			{
				return _DropdownListFontSize;
			}
			set
			{
				_DropdownListFontSize = value;
			}
		}

		/// <summary>
		///       下拉列表字体名称，默认为空。
		///       </summary>
		[DefaultValue(null)]
		[DCDescription(typeof(DocumentViewOptions), "DropdownListFontName")]
		public string DropdownListFontName
		{
			get
			{
				return _DropdownListFontName;
			}
			set
			{
				_DropdownListFontName = value;
			}
		}

		/// <summary>
		///       作为背景显示单元格编号，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "ShowBackgroundCellID")]
		public bool ShowBackgroundCellID
		{
			get
			{
				return _ShowBackgroundCellID;
			}
			set
			{
				_ShowBackgroundCellID = value;
			}
		}

		/// <summary>
		///       当单元格设置了表达式，则在右下角显示表达式标记，默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentViewOptions), "ShowExpressionFlag")]
		public bool ShowExpressionFlag
		{
			get
			{
				return _ShowExpressionFlag;
			}
			set
			{
				_ShowExpressionFlag = value;
			}
		}

		/// <summary>
		///       文档批注字体名称
		///       </summary>
		[DefaultValue(null)]
		[DCDescription(typeof(DocumentViewOptions), "CommentFontName")]
		public string CommentFontName
		{
			get
			{
				return _CommentFontName;
			}
			set
			{
				_CommentFontName = value;
			}
		}

		/// <summary>
		///       文档批注字体大小，默认为10.
		///       </summary>
		[DefaultValue(10f)]
		[DCDescription(typeof(DocumentViewOptions), "CommentFontSize")]
		public float CommentFontSize
		{
			get
			{
				return _CommentFontSize;
			}
			set
			{
				_CommentFontSize = value;
			}
		}

		/// <summary>
		///       文档批注时间格式化字符串。WinForm控件和Web控件中有效。
		///       </summary>
		[DefaultValue("yyyy-MM-dd HH:mm")]
		[DCDescription(typeof(DocumentViewOptions), "CommentDateFormatString")]
		public string CommentDateFormatString
		{
			get
			{
				return _CommentDateFormatString;
			}
			set
			{
				_CommentDateFormatString = value;
			}
		}

		/// <summary>
		///       是否启用旧的计算空格的算法，默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "OldWhitespaceWidth")]
		[DefaultValue(false)]
		public bool OldWhitespaceWidth
		{
			get
			{
				return _OldWhitespaceWidth;
			}
			set
			{
				_OldWhitespaceWidth = value;
			}
		}

		/// <summary>
		///       是否显示文档网格线，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "ShowGridLine")]
		[Obsolete("本属性已经淘汰了，请使用document.PageSettings.DocumentGridLine属性。")]
		public bool ShowGridLine
		{
			get
			{
				return _ShowGridLine;
			}
			set
			{
				_ShowGridLine = value;
			}
		}

		/// <summary>
		///       是否允许视图加密显示，默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentViewOptions), "EnableEncryptView")]
		public bool EnableEncryptView
		{
			get
			{
				return _EnableEncryptView;
			}
			set
			{
				_EnableEncryptView = value;
			}
		}

		/// <summary>
		///       文档网格线颜色，默认为灰色。
		///       </summary>
		[DefaultValue(typeof(Color), "Gray")]
		[Obsolete("本属性已经淘汰了，请使用document.PageSettings.DocumentGridLine属性。")]
		[XmlIgnore]
		[DCDescription(typeof(DocumentViewOptions), "GridLineColor")]
		public Color GridLineColor
		{
			get
			{
				return _GridLineColor;
			}
			set
			{
				_GridLineColor = value;
			}
		}

		/// <summary>
		///       文档网格线颜色，默认为灰色。
		///       </summary>
		[XmlElement]
		[Browsable(false)]
		[Obsolete("本属性已经淘汰了，请使用document.PageSettings.DocumentGridLine属性。")]
		[DefaultValue(null)]
		public string GridLineColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(GridLineColor, Color.Gray);
			}
			set
			{
				GridLineColor = XMLSerializeHelper.StringToColor(value, Color.Gray);
			}
		}

		/// <summary>
		///       在打印的时候保留背景文字的位置，但不打印背景文字。
		///       </summary>
		[DefaultValue(false)]
		public bool PreserveBackgroundTextWhenPrint
		{
			get
			{
				return _PreserveBackgroundTextWhenPrint;
			}
			set
			{
				_PreserveBackgroundTextWhenPrint = value;
			}
		}

		/// <summary>
		///       打印时是否显示输入域的背景文字，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "PrintBackgroundText")]
		public bool PrintBackgroundText
		{
			get
			{
				return _PrintBackgroundText;
			}
			set
			{
				_PrintBackgroundText = value;
			}
		}

		/// <summary>
		///       打印的时候忽略掉输入域边界元素,是其不占据位置，默认为true。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "IgnoreFieldBorderWhenPrint")]
		[DefaultValue(true)]
		public bool IgnoreFieldBorderWhenPrint
		{
			get
			{
				return _IgnoreFieldBorderWhenPrint;
			}
			set
			{
				_IgnoreFieldBorderWhenPrint = value;
			}
		}

		/// <summary>
		///       打印时是否打印网格线，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "PrintGridLine")]
		[Obsolete("本属性已经淘汰了，请使用document.PageSettings.DocumentGridLine属性。")]
		public bool PrintGridLine
		{
			get
			{
				return _PrintGridLine;
			}
			set
			{
				_PrintGridLine = value;
			}
		}

		/// <summary>
		///       打印时，若图片没有数据，是否打印图片元素的Alt提示文本，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "PrintImageAltText")]
		public bool PrintImageAltText
		{
			get
			{
				return _PrintImageAltText;
			}
			set
			{
				_PrintImageAltText = value;
			}
		}

		/// <summary>
		///       当页眉有内容时显示页眉下边框线。若为false，则页眉和正文之间就没有分隔横线。默认值为true。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "ShowHeaderBottomLine")]
		[DefaultValue(true)]
		public bool ShowHeaderBottomLine
		{
			get
			{
				return _ShowHeaderBottomLine;
			}
			set
			{
				_ShowHeaderBottomLine = value;
			}
		}

		/// <summary>
		///       页眉下边框线的宽度.
		///       </summary>
		[DefaultValue(1f)]
		public float HeaderBottomLineWidth
		{
			get
			{
				return _HeaderBottomLineWidth;
			}
			set
			{
				_HeaderBottomLineWidth = value;
			}
		}

		/// <summary>
		///       是否显示表格单元格的隐藏的边框线。当为true时，若表格没有边框线，
		///       则在编辑器中也会使用NoneBorderColor选项指定的颜色显示出边框线。
		///       该设置不影响打印结果。该选项默认值为true。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "ShowCellNoneBorder")]
		[DefaultValue(true)]
		public bool ShowCellNoneBorder
		{
			get
			{
				return _ShowCellNoneBorder;
			}
			set
			{
				_ShowCellNoneBorder = value;
			}
		}

		/// <summary>
		///       绘制隐藏的边框线使用的颜色。默认淡灰色。
		///       </summary>
		[DefaultValue(typeof(Color), "LightGray")]
		[XmlIgnore]
		[DCDescription(typeof(DocumentViewOptions), "NoneBorderColor")]
		public Color NoneBorderColor
		{
			get
			{
				return _NoneBorderColor;
			}
			set
			{
				_NoneBorderColor = value;
			}
		}

		/// <summary>
		///       虚边框颜色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public string NoneBorderColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(NoneBorderColor, Color.LightGray);
			}
			set
			{
				NoneBorderColor = XMLSerializeHelper.StringToColor(value, Color.LightGray);
			}
		}

		/// <summary>
		///       图形平滑模式
		///       </summary>
		[DefaultValue(SmoothingMode.None)]
		public SmoothingMode GraphicsSmoothingMode
		{
			get
			{
				return _GraphicsSmoothingMode;
			}
			set
			{
				_GraphicsSmoothingMode = value;
			}
		}

		/// <summary>
		///       在绘制文字时的质量设置。默认为ClearTypeGridFit。
		///       </summary>
		[DefaultValue(TextRenderingHint.ClearTypeGridFit)]
		[DCDescription(typeof(DocumentViewOptions), "TextRenderStyle")]
		public TextRenderingHint TextRenderStyle
		{
			get
			{
				return intTextRenderStyle;
			}
			set
			{
				intTextRenderStyle = value;
			}
		}

		/// <summary>
		///       显示段落标记。不影响打印，默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentViewOptions), "ShowParagraphFlag")]
		public bool ShowParagraphFlag
		{
			get
			{
				return _ShowParagraphFlag;
			}
			set
			{
				_ShowParagraphFlag = value;
			}
		}

		/// <summary>
		///       输入域失去焦点时隐藏边框元素
		///       </summary>
		[DefaultValue(true)]
		public bool HiddenFieldBorderWhenLostFocus
		{
			get
			{
				return _HiddenFieldBorderWhenLostFocus;
			}
			set
			{
				_HiddenFieldBorderWhenLostFocus = value;
			}
		}

		/// <summary>
		///       是否显示输入域边框元素,默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentViewOptions), "ShowFieldBorderElement")]
		public bool ShowFieldBorderElement
		{
			get
			{
				return _ShowFieldBorderElement;
			}
			set
			{
				_ShowFieldBorderElement = value;
			}
		}

		/// <summary>
		///       输入域边框元素颜色，默认为空颜色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Empty")]
		[DCDescription(typeof(DocumentViewOptions), "FieldBorderColor")]
		public Color FieldBorderColor
		{
			get
			{
				return _FieldBorderColor;
			}
			set
			{
				_FieldBorderColor = value;
			}
		}

		/// <summary>
		///       输入域边框元素颜色，默认为空
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string FieldBorderColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(FieldBorderColor, Color.Empty);
			}
			set
			{
				FieldBorderColor = XMLSerializeHelper.StringToColor(value, Color.Empty);
			}
		}

		/// <summary>
		///       当编辑器处于普通视图模式（不分页），是否显示分页线。默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentViewOptions), "ShowPageLine")]
		public bool ShowPageLine
		{
			get
			{
				return _ShowPageLine;
			}
			set
			{
				_ShowPageLine = value;
			}
		}

		/// <summary>
		///       兼容RTF文本控件模式,若为true，则使得同一个RTF文档，在本编辑器中和标准RichTextBox控件中
		///       显示的结果误差比较小。默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "RichTextBoxCompatibility")]
		public bool RichTextBoxCompatibility
		{
			get
			{
				return _RichTextBoxCompatibility;
			}
			set
			{
				_RichTextBoxCompatibility = value;
			}
		}

		/// <summary>
		///       表格列的最小宽度，单位为1/300英寸，默认为50。
		///       </summary>
		[DefaultValue(50f)]
		[DCDescription(typeof(DocumentViewOptions), "MinTableColumnWidth")]
		public float MinTableColumnWidth
		{
			get
			{
				return _MinTableColumnWidth;
			}
			set
			{
				_MinTableColumnWidth = value;
			}
		}

		/// <summary>
		///       文本输入域默认的文本颜色，默认为透明色，也就是该设置无效
		///       </summary>
		[DefaultValue(typeof(Color), "Transparent")]
		[XmlIgnore]
		[DCDescription(typeof(DocumentViewOptions), "DefaultInputFieldTextColor")]
		public Color DefaultInputFieldTextColor
		{
			get
			{
				return _DefaultInputFieldTextColor;
			}
			set
			{
				_DefaultInputFieldTextColor = value;
			}
		}

		/// <summary>
		///       文本输入域默认的文本颜色，默认为透明色，也就是该设置无效
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		[Browsable(false)]
		public string DefaultInputFieldTextColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(DefaultInputFieldTextColor, Color.Transparent);
			}
			set
			{
				DefaultInputFieldTextColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       是否启用输入域文字颜色，默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "EnableFieldTextColor")]
		[DefaultValue(false)]
		public bool EnableFieldTextColor
		{
			get
			{
				return _EnableFieldTextColor;
			}
			set
			{
				_EnableFieldTextColor = value;
			}
		}

		/// <summary>
		///       输入域文字颜色，和EnableFieldTextColor搭配使用，默认为黑色。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "FieldTextColor")]
		[DefaultValue(typeof(Color), "Black")]
		[XmlIgnore]
		public Color FieldTextColor
		{
			get
			{
				return _FieldTextColor;
			}
			set
			{
				_FieldTextColor = value;
			}
		}

		/// <summary>
		///       文档域文字颜色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public string FieldTextColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(FieldTextColor, Color.Black);
			}
			set
			{
				FieldTextColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       输入域打印时文字颜色，和EnableFieldTextColor搭配使用，默认为黑色。
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
		[DCDescription(typeof(DocumentViewOptions), "FieldTextPrintColor")]
		public Color FieldTextPrintColor
		{
			get
			{
				return _FieldTextPrintColor;
			}
			set
			{
				_FieldTextPrintColor = value;
			}
		}

		/// <summary>
		///       文档域打印时文字颜色值
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		public string FieldTextPrintColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(FieldTextPrintColor, Color.Transparent);
			}
			set
			{
				FieldTextPrintColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       文本输入域的默认背景颜色，默认为浅蓝色。本属性支持Web版控件。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "FieldBackColor")]
		[DefaultValue(typeof(Color), "AliceBlue")]
		[XmlIgnore]
		public Color FieldBackColor
		{
			get
			{
				return _FieldBackColor;
			}
			set
			{
				_FieldBackColor = value;
			}
		}

		/// <summary>
		///       文档域背景色值
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string FieldBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(FieldBackColor, Color.LightGray);
			}
			set
			{
				FieldBackColor = XMLSerializeHelper.StringToColor(value, Color.LightGray);
			}
		}

		/// <summary>
		///       鼠标悬浮在文本输入域时文本输入域的高亮度背景颜色，默认为淡蓝色。本属性支持Web版控件。
		///       </summary>
		[XmlIgnore]
		[DCDescription(typeof(DocumentViewOptions), "FieldHoverBackColor")]
		[DefaultValue(typeof(Color), "LightBlue")]
		public Color FieldHoverBackColor
		{
			get
			{
				return _FieldHoverBackColor;
			}
			set
			{
				_FieldHoverBackColor = value;
			}
		}

		/// <summary>
		///       文档域悬浮背景色值
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[Browsable(false)]
		public string FieldHoverBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(FieldHoverBackColor, Color.LightBlue);
			}
			set
			{
				FieldHoverBackColor = XMLSerializeHelper.StringToColor(value, Color.LightBlue);
			}
		}

		/// <summary>
		///       文本输入域获得输入焦点时的高亮度背景颜色,默认为淡蓝色。本属性支持Web版控件。
		///       </summary>
		[XmlIgnore]
		[DCDescription(typeof(DocumentViewOptions), "FieldFocusedBackColor")]
		[DefaultValue(typeof(Color), "LightBlue")]
		public Color FieldFocusedBackColor
		{
			get
			{
				return _FieldFocusedBackColor;
			}
			set
			{
				_FieldFocusedBackColor = value;
			}
		}

		/// <summary>
		///       文本输入域获得输入焦点时的高亮度背景颜色,默认为淡蓝色。
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string FieldFocusedBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(FieldFocusedBackColor, Color.LightBlue);
			}
			set
			{
				FieldFocusedBackColor = XMLSerializeHelper.StringToColor(value, Color.LightBlue);
			}
		}

		/// <summary>
		///       文本输入域数据异常时的高亮度文本色，默认为淡红色。
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "LightCoral")]
		[DCDescription(typeof(DocumentViewOptions), "FieldInvalidateValueForeColor")]
		public Color FieldInvalidateValueForeColor
		{
			get
			{
				return _FieldInvalidateValueForeColor;
			}
			set
			{
				_FieldInvalidateValueForeColor = value;
			}
		}

		/// <summary>
		///       文本输入域数据异常时的高亮度前景色，默认为淡红色。
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		public string FieldInvalidateValueForeColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(FieldInvalidateValueForeColor, Color.LightCoral);
			}
			set
			{
				FieldInvalidateValueForeColor = XMLSerializeHelper.StringToColor(value, Color.LightCoral);
			}
		}

		/// <summary>
		///       文本输入域数据异常时的高亮度背景色，默认为全透明。本属性支持Web版控件。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "FieldInvalidateValueBackColor")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color FieldInvalidateValueBackColor
		{
			get
			{
				return _FieldInvalidateValueBackColor;
			}
			set
			{
				_FieldInvalidateValueBackColor = value;
			}
		}

		/// <summary>
		///       文本输入域数据异常时的高亮度背景色，默认为淡红色。
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public string FieldInvalidateValueBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(FieldInvalidateValueBackColor, Color.Transparent);
			}
			set
			{
				FieldInvalidateValueBackColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       只读输入域的边界元素颜色，默认为灰色
		///       </summary>
		[DefaultValue(typeof(Color), "Gray")]
		[XmlIgnore]
		[DCDescription(typeof(DocumentViewOptions), "ReadonlyFieldBorderColor")]
		public Color ReadonlyFieldBorderColor
		{
			get
			{
				return _ReadonlyFieldBorderColor;
			}
			set
			{
				_ReadonlyFieldBorderColor = value;
			}
		}

		/// <summary>
		///       只读的输入域的标记点颜色，默认为透明色。本属性支持Web版控件。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "TagColorForReadonlyField")]
		[DefaultValue(typeof(Color), "Gray")]
		[XmlIgnore]
		public Color TagColorForReadonlyField
		{
			get
			{
				return _TagColorForReadonylField;
			}
			set
			{
				_TagColorForReadonylField = value;
			}
		}

		/// <summary>
		///       只读输入域标记颜色值
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		public string TagColorForReadonlyFieldValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(TagColorForReadonlyField, Color.Gray);
			}
			set
			{
				TagColorForReadonlyField = XMLSerializeHelper.StringToColor(value, Color.Gray);
			}
		}

		/// <summary>
		///       内容修改的输入域的标记点颜色，默认为蓝色。本属性支持Web版控件。
		///       </summary>
		[DefaultValue(typeof(Color), "blue")]
		[XmlIgnore]
		[DCDescription(typeof(DocumentViewOptions), "TagColorForModifiedField")]
		public Color TagColorForModifiedField
		{
			get
			{
				return _TagColorForModifiedField;
			}
			set
			{
				_TagColorForModifiedField = value;
			}
		}

		/// <summary>
		///       内容修改的输入域的标记点颜色值本属性支持Web版控件。
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		public string TagColorForModifiedFieldValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(TagColorForModifiedField, Color.Blue);
			}
			set
			{
				TagColorForModifiedField = XMLSerializeHelper.StringToColor(value, Color.Blue);
			}
		}

		/// <summary>
		///       普通输入域的标记点颜色，默认为红色。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "TagColorForNormalField")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Red")]
		public Color TagColorForNormalField
		{
			get
			{
				return _TagColorForNormalField;
			}
			set
			{
				_TagColorForNormalField = value;
			}
		}

		/// <summary>
		///       普通输入域的标记点颜色值
		///       </summary>
		[Browsable(false)]
		[XmlElement]
		[DefaultValue(null)]
		public string TagColorForNormalFieldValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(TagColorForNormalField, Color.SkyBlue);
			}
			set
			{
				TagColorForNormalField = XMLSerializeHelper.StringToColor(value, Color.SkyBlue);
			}
		}

		/// <summary>
		///       数据不正确的输入域的标记点颜色，默认为蓝色。本属性支持Web版控件。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "TagColorForValueInvalidateField")]
		[DefaultValue(typeof(Color), "Red")]
		[XmlIgnore]
		public Color TagColorForValueInvalidateField
		{
			get
			{
				return _TagColorForValueInvalidateField;
			}
			set
			{
				_TagColorForValueInvalidateField = value;
			}
		}

		/// <summary>
		///       数据不正确的输入域的标记点颜色值
		///       </summary>
		[XmlElement]
		[Browsable(false)]
		[DefaultValue(null)]
		public string TagColorForValueInvalidateFieldValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(TagColorForValueInvalidateField, Color.Red);
			}
			set
			{
				TagColorForValueInvalidateField = XMLSerializeHelper.StringToColor(value, Color.Red);
			}
		}

		/// <summary>
		///       只读输入域的边界元素颜色，默认为灰色
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string ReadonlyFieldBorderColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(ReadonlyFieldBorderColor, Color.Gray);
			}
			set
			{
				ReadonlyFieldBorderColor = XMLSerializeHelper.StringToColor(value, Color.Gray);
			}
		}

		/// <summary>
		///       内容不能被用户直接录入修改的输入域的边界元素颜色，默认为红色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Red")]
		[DCDescription(typeof(DocumentViewOptions), "UnEditableFieldBorderColor")]
		public Color UnEditableFieldBorderColor
		{
			get
			{
				return _UnEditableFieldBorderColor;
			}
			set
			{
				_UnEditableFieldBorderColor = value;
			}
		}

		/// <summary>
		///       内容不能直接修改的输入域的边界元素颜色，默认为红色
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string UnEditableFieldBorderColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(UnEditableFieldBorderColor, Color.Red);
			}
			set
			{
				UnEditableFieldBorderColor = XMLSerializeHelper.StringToColor(value, Color.Red);
			}
		}

		/// <summary>
		///       常规的输入域的边界元素颜色，用户可以在常规的输入域中直接输入内容。该属性值默认为蓝色
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "NormalFieldBorderColor")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Blue")]
		public Color NormalFieldBorderColor
		{
			get
			{
				return _NormalFieldBorderColor;
			}
			set
			{
				_NormalFieldBorderColor = value;
			}
		}

		/// <summary>
		///       常规的输入域的边界元素颜色，默认为蓝色
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlElement]
		public string NormalFieldBorderColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(NormalFieldBorderColor, Color.Blue);
			}
			set
			{
				NormalFieldBorderColor = XMLSerializeHelper.StringToColor(value, Color.Blue);
			}
		}

		/// <summary>
		///       字段域的背景文本颜色，默认为灰色。
		///       </summary>
		[DCDescription(typeof(DocumentViewOptions), "BackgroundTextColor")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Gray")]
		public Color BackgroundTextColor
		{
			get
			{
				return _BackgroundTextColor;
			}
			set
			{
				_BackgroundTextColor = value;
			}
		}

		/// <summary>
		///       字段域的背景文本颜色，默认为灰色。
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string BackgroundTextColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BackgroundTextColor, Color.Gray);
			}
			set
			{
				BackgroundTextColor = XMLSerializeHelper.StringToColor(value, Color.Gray);
			}
		}

		/// <summary>
		///       选择区域高亮度显示方式，默认为MaskColor方式。
		///       </summary>
		[DefaultValue(SelectionHighlightStyle.MaskColor)]
		[DCDescription(typeof(DocumentViewOptions), "SelectionHighlight")]
		public SelectionHighlightStyle SelectionHighlight
		{
			get
			{
				return _SelectionHighlight;
			}
			set
			{
				_SelectionHighlight = value;
			}
		}

		/// <summary>
		///       选择区域高亮度遮盖色，本选项和SelectionHighlight搭配使用。默认为半透明淡蓝色。
		///       </summary>
		[XmlIgnore]
		[DCDescription(typeof(DocumentViewOptions), "SelectionHightlightMaskColor")]
		public Color SelectionHightlightMaskColor
		{
			get
			{
				return _SelectionHightlightMaskColor;
			}
			set
			{
				_SelectionHightlightMaskColor = value;
			}
		}

		/// <summary>
		///       选择区域高亮度遮盖色，默认为半透明淡蓝色。
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlElement]
		public string SelectionHightlightMaskColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(SelectionHightlightMaskColor, Color.FromArgb(50, Color.Blue));
			}
			set
			{
				SelectionHightlightMaskColor = XMLSerializeHelper.StringToColor(value, Color.FromArgb(50, Color.Blue));
			}
		}

		/// <summary>
		///       内容排版方向，默认为LeftToRight。
		///       </summary>
		[DefaultValue(ContentLayoutDirectionStyle.LeftToRight)]
		[DCDescription(typeof(DocumentViewOptions), "LayoutDirection")]
		public ContentLayoutDirectionStyle LayoutDirection
		{
			get
			{
				return _LayoutDirection;
			}
			set
			{
				_LayoutDirection = value;
			}
		}

		/// <summary>
		///       是否显示本地化名称
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentViewOptions), "ShowLocalizationDisplayName")]
		public static bool ShowLocalizationDisplayName
		{
			get
			{
				return GClass360.smethod_0();
			}
			set
			{
				GClass360.smethod_1(value);
			}
		}

		object ICloneable.Clone()
		{
			return (DocumentViewOptions)MemberwiseClone();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DocumentViewOptions Clone()
		{
			return (DocumentViewOptions)((ICloneable)this).Clone();
		}
	}
}
