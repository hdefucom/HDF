using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       体温单文档配置信息对象
	///       </summary>
	/// <remarks>
	///       袁永福到此一游
	///       </remarks>
	[Serializable]
	[DCDescriptionResourceSource("DCSoft.FriedmanCurveChart.DCFriedmanCurveDescriptionResource")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComVisible(false)]
	public class FriedmanCurveDocumentConfig
	{
		private float _HeaderLabelBottomSpacing = 0f;

		private float _LineZoneBottomSpacing = 0f;

		private bool _BothBlackWhenPrint = false;

		private float _LineWidthZoomRateWhenPrint = 1f;

		private FCDocumentLinkVisualStyle _LinkVisualStyle = FCDocumentLinkVisualStyle.Hover;

		private bool _DebugMode = false;

		private FCEditValuePointEventHandleMode _EditValuePointMode = FCEditValuePointEventHandleMode.None;

		private bool _Readonly = false;

		private float _ExtendDaysForFriedmanCurve = 0f;

		private string _TitleForToolTip = null;

		private DCFriedmanCurveSelectionMode _SelectionMode = DCFriedmanCurveSelectionMode.None;

		private bool _ShowTooltip = true;

		private bool _AllowUserCollapseZone = true;

		private string _Version = null;

		private DCFriedmanCurveUnit _TickUnit = DCFriedmanCurveUnit.Hour;

		private float _DataGridTopPadding = 0f;

		private float _DataGridBottomPadding = 0f;

		private string _SQLTextForHeaderLabel = null;

		private float _SpecifyTickWidth = 0f;

		private DCFriedmanCurveImageList _Images = new DCFriedmanCurveImageList();

		private DCFriedmanCurveLabelList _Labels = new DCFriedmanCurveLabelList();

		private string _PageIndexText = "";

		private string _SpecifyStartDate = null;

		private string _SpecifyEndDate = null;

		private FCDocumentPageSettings _PageSettings = null;

		private string _FooterDescription = null;

		private PageTitlePosition _PageTitlePosition = PageTitlePosition.TopLeft;

		private bool _ShowIcon = false;

		private int _ImagePixelWidth = 16;

		private int _ImagePixelHeight = 16;

		private int _ShadowPointDetectSeconds = 2000;

		private int _GridYSplitNum = 8;

		private FCGridYSplitInfo _GridYSplitInfo = null;

		private FriedmanCurveZoneInfoList _Zones = null;

		private FCTickInfoList _Ticks = null;

		private float _SymbolSize = 20f;

		private string _FontName = "宋体";

		private float _FontSize = 9f;

		private float _BigTitleFontSize = 27f;

		private XFontValue _PageIndexFont = null;

		private Color _ForeColor = Color.Black;

		private Color _BigVerticalGridLineColor = Color.Red;

		private Color _BackColor = Color.Transparent;

		private Color _PageBackColor = Color.White;

		private Color _GridLineColor = Color.Black;

		private Color _GridBackColor = Color.Transparent;

		private string _DateFormatString = "yyyy-MM-dd";

		private string _Title = null;

		private float _SpecifyTitleHeight = 0f;

		private FCHeaderLabelInfoList _HeaderLabels = new FCHeaderLabelInfoList();

		private int _NumOfHoursInOnePage = 7;

		private FCTitleLineInfoList _HeaderLines = new FCTitleLineInfoList();

		private FCTitleLineInfoList _FooterLines = new FCTitleLineInfoList();

		private FCYAxisInfoList _YAxisInfos = new FCYAxisInfoList();

		/// <summary>
		///       页眉标签底端间隔区域：伍贻超添加属性
		///       </summary>
		[DefaultValue(0)]
		[Browsable(true)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "HeaderLabelBottomSpacing")]
		[XmlAttribute]
		public float HeaderLabelBottomSpacing
		{
			get
			{
				return _HeaderLabelBottomSpacing;
			}
			set
			{
				_HeaderLabelBottomSpacing = value;
			}
		}

		/// <summary>
		///       折线区域底端间隔区域：伍贻超添加属性
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "LineZoneBottomSpacing")]
		[DefaultValue(0)]
		[Browsable(true)]
		[XmlAttribute]
		public float LineZoneBottomSpacing
		{
			get
			{
				return _LineZoneBottomSpacing;
			}
			set
			{
				_LineZoneBottomSpacing = value;
			}
		}

		/// <summary>
		///       打印时全部采用黑色
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
		///       打印时的线条粗细缩放比率
		///       </summary>
		[DefaultValue(1f)]
		public float LineWidthZoomRateWhenPrint
		{
			get
			{
				return _LineWidthZoomRateWhenPrint;
			}
			set
			{
				_LineWidthZoomRateWhenPrint = value;
			}
		}

		/// <summary>
		///       超链接可视化样式
		///       </summary>
		[DefaultValue(FCDocumentLinkVisualStyle.Hover)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "LinkVisualStyle")]
		public FCDocumentLinkVisualStyle LinkVisualStyle
		{
			get
			{
				return _LinkVisualStyle;
			}
			set
			{
				_LinkVisualStyle = value;
			}
		}

		/// <summary>
		///       调试模式
		///       </summary>
		[DefaultValue(false)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "DebugMode")]
		public bool DebugMode
		{
			get
			{
				return _DebugMode;
			}
			set
			{
				_DebugMode = value;
			}
		}

		/// <summary>
		///       数据点编辑模式
		///       </summary>
		[DefaultValue(FCEditValuePointEventHandleMode.None)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "EditValuePointMode")]
		public FCEditValuePointEventHandleMode EditValuePointMode
		{
			get
			{
				return _EditValuePointMode;
			}
			set
			{
				_EditValuePointMode = value;
			}
		}

		/// <summary>
		///       文档是只读的
		///       </summary>
		[DefaultValue(false)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "Readonly")]
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
			}
		}

		/// <summary>
		///       为产程图模式而延长的天数
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "ExtendDaysForFriedmanCurve")]
		[DefaultValue(0f)]
		[Browsable(false)]
		public float ExtendDaysForFriedmanCurve
		{
			get
			{
				return _ExtendDaysForFriedmanCurve;
			}
			set
			{
				_ExtendDaysForFriedmanCurve = value;
			}
		}

		/// <summary>
		///       提示信息的标题文本
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "TitleForToolTip")]
		[DefaultValue(null)]
		public string TitleForToolTip
		{
			get
			{
				return _TitleForToolTip;
			}
			set
			{
				_TitleForToolTip = value;
			}
		}

		/// <summary>
		///       选择模式
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "SelectionMode")]
		[DefaultValue(DCFriedmanCurveSelectionMode.None)]
		[Browsable(false)]
		public DCFriedmanCurveSelectionMode SelectionMode
		{
			get
			{
				return _SelectionMode;
			}
			set
			{
				_SelectionMode = value;
			}
		}

		/// <summary>
		///       是否显示提示文本 
		///       </summary>
		[Category("Behavior")]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "ShowTooltip")]
		[DefaultValue(true)]
		public bool ShowTooltip
		{
			get
			{
				return _ShowTooltip;
			}
			set
			{
				_ShowTooltip = value;
			}
		}

		/// <summary>
		///       允许用户收缩时间区域
		///       </summary>
		[DefaultValue(true)]
		[Browsable(false)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "AllowUserCollapseZone")]
		public bool AllowUserCollapseZone
		{
			get
			{
				return _AllowUserCollapseZone;
			}
			set
			{
				_AllowUserCollapseZone = value;
			}
		}

		/// <summary>
		///       版本号
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "Version")]
		[XmlAttribute]
		public string Version
		{
			get
			{
				return _Version;
			}
			set
			{
				_Version = value;
			}
		}

		/// <summary>
		///       标准时刻单位
		///       </summary>
		[DefaultValue(DCFriedmanCurveUnit.Hour)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "TickUnit")]
		public DCFriedmanCurveUnit TickUnit
		{
			get
			{
				return _TickUnit;
			}
			set
			{
				_TickUnit = value;
			}
		}

		/// <summary>
		///       数据网格线顶端空白边距比率，取值范围从0.0到1.0之间
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "DataGridTopPadding")]
		[DefaultValue(0f)]
		public float DataGridTopPadding
		{
			get
			{
				return _DataGridTopPadding;
			}
			set
			{
				_DataGridTopPadding = value;
			}
		}

		/// <summary>
		///       数据网格线底端空白边距比率，取值范围从0.0到1.0之间
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "DataGridBottomPadding")]
		[DefaultValue(0f)]
		public float DataGridBottomPadding
		{
			get
			{
				return _DataGridBottomPadding;
			}
			set
			{
				_DataGridBottomPadding = value;
			}
		}

		/// <summary>
		///       查询标题头数据使用的SQL语句
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "SQLTextForHeaderLabel")]
		[Editor(typeof(FCdlgSQLText.GClass19), typeof(UITypeEditor))]
		[DefaultValue(null)]
		[XmlElement]
		public string SQLTextForHeaderLabel
		{
			get
			{
				return _SQLTextForHeaderLabel;
			}
			set
			{
				_SQLTextForHeaderLabel = value;
			}
		}

		/// <summary>
		///       指定的最小刻度长度，小于等于0则自动计算，默认为0.
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "SpecifyTickWidth")]
		[DefaultValue(0f)]
		public float SpecifyTickWidth
		{
			get
			{
				return _SpecifyTickWidth;
			}
			set
			{
				_SpecifyTickWidth = value;
			}
		}

		/// <summary>
		///       贴图列表
		///       </summary>
		[Browsable(false)]
		[XmlArrayItem("Image", typeof(DCFriedmanCurveImage))]
		public DCFriedmanCurveImageList Images
		{
			get
			{
				return _Images;
			}
			set
			{
				_Images = value;
			}
		}

		/// <summary>
		///       额外的文本标签列表
		///       </summary>
		[Browsable(false)]
		[XmlArrayItem("Label", typeof(DCFriedmanCurveLabel))]
		public DCFriedmanCurveLabelList Labels
		{
			get
			{
				return _Labels;
			}
			set
			{
				_Labels = value;
			}
		}

		/// <summary>
		///       页码文本
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "PageIndexText")]
		[Browsable(false)]
		[DefaultValue(null)]
		public string PageIndexText
		{
			get
			{
				return _PageIndexText;
			}
			set
			{
				_PageIndexText = value;
			}
		}

		/// <summary>
		///       指定的开始日期
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "SpecifyStartDate")]
		[DefaultValue(null)]
		public string SpecifyStartDate
		{
			get
			{
				return _SpecifyStartDate;
			}
			set
			{
				_SpecifyStartDate = value;
			}
		}

		/// <summary>
		///       指定的结束日期
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "SpecifyEndDate")]
		[DefaultValue(null)]
		public string SpecifyEndDate
		{
			get
			{
				return _SpecifyEndDate;
			}
			set
			{
				_SpecifyEndDate = value;
			}
		}

		/// <summary>
		///       页面设置
		///       </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "PageSettings")]
		public FCDocumentPageSettings PageSettings
		{
			get
			{
				return _PageSettings;
			}
			set
			{
				_PageSettings = value;
			}
		}

		/// <summary>
		///       在文档下面显示的标注
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "FooterDescription")]
		public string FooterDescription
		{
			get
			{
				return _FooterDescription;
			}
			set
			{
				_FooterDescription = value;
			}
		}

		/// <summary>
		///       页面标题文本位置
		///       </summary>
		[DefaultValue(PageTitlePosition.TopLeft)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "PageTitlePosition")]
		public PageTitlePosition PageTitlePosition
		{
			get
			{
				return _PageTitlePosition;
			}
			set
			{
				_PageTitlePosition = value;
			}
		}

		/// <summary>
		///       是否显示文字上面的图标
		///       </summary>
		[DefaultValue(false)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "ShowIcon")]
		public bool ShowIcon
		{
			get
			{
				return _ShowIcon;
			}
			set
			{
				_ShowIcon = value;
			}
		}

		/// <summary>
		///       图片像素宽度
		///       </summary>
		[DefaultValue(16)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "ImagePixelWidth")]
		public int ImagePixelWidth
		{
			get
			{
				return _ImagePixelWidth;
			}
			set
			{
				_ImagePixelWidth = value;
			}
		}

		/// <summary>
		///       图片像素高度
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "ImagePixelHeight")]
		[DefaultValue(16)]
		public int ImagePixelHeight
		{
			get
			{
				return _ImagePixelHeight;
			}
			set
			{
				_ImagePixelHeight = value;
			}
		}

		/// <summary>
		///       检测阴影数据点的时钟秒数
		///       </summary>
		[DefaultValue(2000)]
		[Browsable(false)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "ShadowPointDetectSeconds")]
		public int ShadowPointDetectSeconds
		{
			get
			{
				return _ShadowPointDetectSeconds;
			}
			set
			{
				_ShadowPointDetectSeconds = value;
			}
		}

		/// <summary>
		///       Y轴分割份数
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "GridYSplitNum")]
		[DefaultValue(8)]
		public int GridYSplitNum
		{
			get
			{
				return GridYSplitInfo.GridYSplitNum;
			}
			set
			{
				GridYSplitInfo.GridYSplitNum = value;
			}
		}

		/// <summary>
		///       Y轴网格线配置信息
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "GridYSplitInfo")]
		public FCGridYSplitInfo GridYSplitInfo
		{
			get
			{
				if (_GridYSplitInfo == null)
				{
					_GridYSplitInfo = new FCGridYSplitInfo();
				}
				return _GridYSplitInfo;
			}
			set
			{
				_GridYSplitInfo = value;
			}
		}

		/// <summary>
		///       时间区域信息列表
		///       </summary>
		[XmlArrayItem("Zone", typeof(FriedmanCurveZoneInfo))]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "Zones")]
		[Browsable(false)]
		public FriedmanCurveZoneInfoList Zones
		{
			get
			{
				if (_Zones == null)
				{
					_Zones = new FriedmanCurveZoneInfoList();
				}
				return _Zones;
			}
			set
			{
				_Zones = value;
			}
		}

		/// <summary>
		///       判断是否存在有效的时间区域
		///       </summary>
		[Browsable(false)]
		public bool HasFriedmanCurveZones
		{
			get
			{
				if (Zones.Count > 0)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       刻度信息列表
		///       </summary>
		[XmlArrayItem("Tick", typeof(FCTickInfo))]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "Ticks")]
		[Browsable(false)]
		public FCTickInfoList Ticks
		{
			get
			{
				if (_Ticks == null)
				{
					_Ticks = new FCTickInfoList();
				}
				return _Ticks;
			}
			set
			{
				_Ticks = value;
			}
		}

		/// <summary>
		///       数据点符号大小，以Document(1/300英寸)为单位
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "SymbolSize")]
		[DefaultValue(20f)]
		public float SymbolSize
		{
			get
			{
				return _SymbolSize;
			}
			set
			{
				_SymbolSize = value;
			}
		}

		/// <summary>
		///       字体名称
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "FontName")]
		[DefaultValue("宋体")]
		public string FontName
		{
			get
			{
				return _FontName;
			}
			set
			{
				_FontName = value;
			}
		}

		/// <summary>
		///       字体的大小
		///       </summary>
		[DefaultValue(9f)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "FontSize")]
		public float FontSize
		{
			get
			{
				return _FontSize;
			}
			set
			{
				_FontSize = value;
			}
		}

		/// <summary>
		///       运行时使用的字体
		///       </summary>
		internal XFontValue RuntimeFont
		{
			get
			{
				XFontValue xFontValue = new XFontValue();
				xFontValue.Name = FontName;
				xFontValue.Size = FontSize;
				return xFontValue;
			}
		}

		/// <summary>
		///       大标题使用的字体大小
		///       </summary>
		[DefaultValue(27f)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "BigTitleFontSize")]
		public float BigTitleFontSize
		{
			get
			{
				return _BigTitleFontSize;
			}
			set
			{
				_BigTitleFontSize = value;
			}
		}

		/// <summary>
		///       页码字体
		///       </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		public XFontValue PageIndexFont
		{
			get
			{
				return _PageIndexFont;
			}
			set
			{
				_PageIndexFont = value;
			}
		}

		/// <summary>
		///       运行时真正使用的页码字体
		///       </summary>
		internal XFontValue RuntimePageIndexFont
		{
			get
			{
				XFontValue xFontValue = PageIndexFont;
				if (xFontValue == null)
				{
					xFontValue = RuntimeFont;
				}
				return xFontValue;
			}
		}

		/// <summary>
		///       图形前景色，为默认的线条和文字颜色
		///       </summary>
		[XmlIgnore]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "ForeColor")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Black")]
		public Color ForeColor
		{
			get
			{
				return _ForeColor;
			}
			set
			{
				_ForeColor = value;
			}
		}

		/// <summary>
		///       文本形式的线条颜色
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		public string ForeColorValue
		{
			get
			{
				return Class163.smethod_4(ForeColor, Color.Black);
			}
			set
			{
				ForeColor = Class163.smethod_5(value, Color.Black);
			}
		}

		/// <summary>
		///       大的垂直网格线颜色
		///       </summary>
		[Browsable(true)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "BigVerticalGridLineColor")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Red")]
		public Color BigVerticalGridLineColor
		{
			get
			{
				return _BigVerticalGridLineColor;
			}
			set
			{
				_BigVerticalGridLineColor = value;
			}
		}

		/// <summary>
		///       大的垂直网格线颜色
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		public string BigVerticalGridLineColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BigVerticalGridLineColor, Color.Red);
			}
			set
			{
				BigVerticalGridLineColor = XMLSerializeHelper.StringToColor(value, Color.Red);
			}
		}

		/// <summary>
		///       页面背景色
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "BackColor")]
		[XmlIgnore]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color BackColor
		{
			get
			{
				return _BackColor;
			}
			set
			{
				_BackColor = value;
			}
		}

		/// <summary>
		///       文本形式的颜色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		public string BackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(BackColor, Color.Transparent);
			}
			set
			{
				BackColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       页面背景色
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "PageBackColor")]
		[XmlIgnore]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		public Color PageBackColor
		{
			get
			{
				return _PageBackColor;
			}
			set
			{
				_PageBackColor = value;
			}
		}

		/// <summary>
		///       文本形式的颜色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		public string PageBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(PageBackColor, Color.White);
			}
			set
			{
				PageBackColor = XMLSerializeHelper.StringToColor(value, Color.White);
			}
		}

		/// <summary>
		///       数据点符号颜色
		///       </summary>
		[XmlIgnore]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "GridLineColor")]
		[DefaultValue(typeof(Color), "Black")]
		[Browsable(true)]
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
		///       文本形式的颜色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		public string GridLineColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(GridLineColor, Color.Black);
			}
			set
			{
				GridLineColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       数据点符号颜色
		///       </summary>
		[XmlIgnore]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Transparent")]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "GridBackColor")]
		public Color GridBackColor
		{
			get
			{
				return _GridBackColor;
			}
			set
			{
				_GridBackColor = value;
			}
		}

		/// <summary>
		///       文本形式的颜色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		public string GridBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(GridBackColor, Color.Transparent);
			}
			set
			{
				GridBackColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       输出日期数据使用的格式化字符串
		///       </summary>
		[DefaultValue("yyyy-MM-dd")]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "DateFormatString")]
		public string DateFormatString
		{
			get
			{
				return _DateFormatString;
			}
			set
			{
				_DateFormatString = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "Title")]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}

		/// <summary>
		///       指定的标题高度
		///       </summary>
		[DefaultValue(0f)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "SpecifyTitleHeight")]
		public float SpecifyTitleHeight
		{
			get
			{
				return _SpecifyTitleHeight;
			}
			set
			{
				_SpecifyTitleHeight = value;
			}
		}

		/// <summary>
		///       页面标题
		///       </summary>
		[Browsable(false)]
		[XmlArrayItem("Label", typeof(FCHeaderLabelInfo))]
		public FCHeaderLabelInfoList HeaderLabels
		{
			get
			{
				if (_HeaderLabels == null)
				{
					_HeaderLabels = new FCHeaderLabelInfoList();
				}
				return _HeaderLabels;
			}
			set
			{
				_HeaderLabels = value;
			}
		}

		/// <summary>
		///       每页显示的天数
		///       </summary>
		[DefaultValue(7)]
		[DCDisplayName(typeof(FriedmanCurveDocumentConfig), "NumOfHoursInOnePage")]
		public int NumOfHoursInOnePage
		{
			get
			{
				return _NumOfHoursInOnePage;
			}
			set
			{
				_NumOfHoursInOnePage = value;
			}
		}

		/// <summary>
		///       标题行信息
		///       </summary>
		[Browsable(false)]
		[XmlArrayItem("Line", typeof(FCTitleLineInfo))]
		public FCTitleLineInfoList HeaderLines
		{
			get
			{
				return _HeaderLines;
			}
			set
			{
				_HeaderLines = value;
			}
		}

		/// <summary>
		///       页脚行信息
		///       </summary>
		[Browsable(false)]
		[XmlArrayItem("Line", typeof(FCTitleLineInfo))]
		public FCTitleLineInfoList FooterLines
		{
			get
			{
				return _FooterLines;
			}
			set
			{
				_FooterLines = value;
			}
		}

		/// <summary>
		///       Y坐标轴信息列表
		///       </summary>
		[XmlArrayItem("YAxis", typeof(FCYAxisInfo))]
		[Browsable(false)]
		public FCYAxisInfoList YAxisInfos
		{
			get
			{
				if (_YAxisInfos == null)
				{
					_YAxisInfos = new FCYAxisInfoList();
				}
				return _YAxisInfos;
			}
			set
			{
				_YAxisInfos = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public FriedmanCurveDocumentConfig()
		{
			_Version = "1.0";
		}

		internal void CheckDefaultTicks()
		{
			_Ticks = new FCTickInfoList();
			_Ticks.AddItem(1, "1", Color.Black);
		}

		/// <summary>
		///       获得文档中所有的文本行列表
		///       </summary>
		/// <returns>
		/// </returns>
		internal FCTitleLineInfoList GetAllTitleLines()
		{
			FCTitleLineInfoList fCTitleLineInfoList = new FCTitleLineInfoList();
			fCTitleLineInfoList.AddRange(HeaderLines);
			fCTitleLineInfoList.AddRange(FooterLines);
			return fCTitleLineInfoList;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public FriedmanCurveDocumentConfig Clone()
		{
			FriedmanCurveDocumentConfig friedmanCurveDocumentConfig = (FriedmanCurveDocumentConfig)MemberwiseClone();
			if (_Images != null)
			{
				friedmanCurveDocumentConfig._Images = new DCFriedmanCurveImageList();
				foreach (DCFriedmanCurveImage image in _Images)
				{
					friedmanCurveDocumentConfig._Images.Add(image.Clone());
				}
			}
			if (_FooterLines != null)
			{
				friedmanCurveDocumentConfig._FooterLines = new FCTitleLineInfoList();
				foreach (FCTitleLineInfo footerLine in _FooterLines)
				{
					friedmanCurveDocumentConfig._FooterLines.Add(footerLine.Clone());
				}
			}
			if (_HeaderLines != null)
			{
				friedmanCurveDocumentConfig._HeaderLines = new FCTitleLineInfoList();
				foreach (FCTitleLineInfo headerLine in _HeaderLines)
				{
					friedmanCurveDocumentConfig._HeaderLines.Add(headerLine.Clone());
				}
			}
			if (_YAxisInfos != null)
			{
				friedmanCurveDocumentConfig._YAxisInfos = new FCYAxisInfoList();
				foreach (FCYAxisInfo yAxisInfo in _YAxisInfos)
				{
					friedmanCurveDocumentConfig._YAxisInfos.Add(yAxisInfo);
				}
			}
			if (_Ticks != null)
			{
				friedmanCurveDocumentConfig._Ticks = _Ticks.Clone();
			}
			if (_Zones != null)
			{
				friedmanCurveDocumentConfig._Zones = new FriedmanCurveZoneInfoList();
				foreach (FriedmanCurveZoneInfo zone in _Zones)
				{
					friedmanCurveDocumentConfig._Zones.Add(zone.Clone());
				}
			}
			if (HeaderLabels != null)
			{
				friedmanCurveDocumentConfig._HeaderLabels = _HeaderLabels.Clone();
			}
			if (_Labels != null)
			{
				friedmanCurveDocumentConfig._Labels = _Labels.Clone();
			}
			return friedmanCurveDocumentConfig;
		}
	}
}
