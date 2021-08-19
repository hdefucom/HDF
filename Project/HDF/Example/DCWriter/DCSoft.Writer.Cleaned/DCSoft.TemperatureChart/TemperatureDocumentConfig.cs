using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       体温单文档配置信息对象
	///       </summary>
	/// <remarks>
	///       袁永福到此一游
	///       </remarks>
	[Serializable]
	[DCPublishAPI]
	[DCDescriptionResourceSource("DCSoft.TemperatureChart.DCTimeLineDescriptionResource")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComVisible(false)]
	public class TemperatureDocumentConfig
	{
		private bool _BothBlackWhenPrint = false;

		private float _LineWidthZoomRateWhenPrint = 1f;

		private DocumentLinkVisualStyle _LinkVisualStyle = DocumentLinkVisualStyle.Hover;

		private bool _DebugMode = false;

		private EditValuePointEventHandleMode _EditValuePointMode = EditValuePointEventHandleMode.None;

		private bool _Readonly = false;

		private float _ExtendDaysForTimeLine = 0f;

		private string _TitleForToolTip = null;

		private DCTimeLineSelectionMode _SelectionMode = DCTimeLineSelectionMode.None;

		private bool _ShowTooltip = true;

		private bool _AllowUserCollapseZone = true;

		private string _Version = null;

		private DCTimeUnit _TickUnit = DCTimeUnit.Hour;

		private float _DataGridTopPadding = 0f;

		private float _DataGridBottomPadding = 0f;

		private string _SQLTextForHeaderLabel = null;

		private float _SpecifyTickWidth = 0f;

		private DCTimeLineImageList _Images = new DCTimeLineImageList();

		private DCTimeLineLabelList _Labels = new DCTimeLineLabelList();

		private string _PageIndexText = "第[%pageindex%]页";

		private string _SpecifyStartDate = null;

		private string _SpecifyEndDate = null;

		private DocumentPageSettings _PageSettings = null;

		private string _FooterDescription = null;

		private PageTitlePosition _PageTitlePosition = PageTitlePosition.TopLeft;

		private bool _ShowIcon = false;

		private int _ImagePixelWidth = 16;

		private int _ImagePixelHeight = 16;

		private int _ShadowPointDetectSeconds = 2000;

		private int _GridYSplitNum = 8;

		private GridYSplitInfo _GridYSplitInfo = null;

		private TimeLineZoneInfoList _Zones = null;

		private TickInfoList _Ticks = null;

		private float _SymbolSize = 20f;

		private string _FontName = "宋体";

		private float _FontSize = 9f;

		private float _BigTitleFontSize = 27f;

		private XFontValue _PageIndexFont = null;

		private Color _ForeColor = Color.Black;

		private Color _BigVerticalGridLineColor = Color.Red;

		private Color _BackColor = Color.Transparent;

		private bool _ValueTextTransparentBackColor = false;

		private Color _PageBackColor = Color.White;

		private Color _GridLineColor = Color.Black;

		private Color _GridBackColor = Color.Transparent;

		private string _DateFormatString = "yyyy-MM-dd";

		private string _Title = null;

		private float _SpecifyTitleHeight = 0f;

		private HeaderLabelInfoList _HeaderLabels = new HeaderLabelInfoList();

		private int _NumOfDaysInOnePage = 7;

		private TitleLineInfoList _HeaderLines = new TitleLineInfoList();

		private TitleLineInfoList _FooterLines = new TitleLineInfoList();

		private YAxisInfoList _YAxisInfos = new YAxisInfoList();

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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "LinkVisualStyle")]
		[DefaultValue(DocumentLinkVisualStyle.Hover)]
		public DocumentLinkVisualStyle LinkVisualStyle
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "DebugMode")]
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
		[DefaultValue(EditValuePointEventHandleMode.None)]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "EditValuePointMode")]
		public EditValuePointEventHandleMode EditValuePointMode
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "Readonly")]
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
		///       为时间轴模式而延长的天数
		///       </summary>
		[DefaultValue(0f)]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "ExtendDaysForTimeLine")]
		public float ExtendDaysForTimeLine
		{
			get
			{
				return _ExtendDaysForTimeLine;
			}
			set
			{
				_ExtendDaysForTimeLine = value;
			}
		}

		/// <summary>
		///       提示信息的标题文本
		///       </summary>
		[DCDisplayName(typeof(TemperatureDocumentConfig), "TitleForToolTip")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "SelectionMode")]
		[DefaultValue(DCTimeLineSelectionMode.None)]
		public DCTimeLineSelectionMode SelectionMode
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
		[DefaultValue(true)]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "ShowTooltip")]
		[Category("Behavior")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "AllowUserCollapseZone")]
		[DefaultValue(true)]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "Version")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "TickUnit")]
		[DefaultValue(DCTimeUnit.Hour)]
		public DCTimeUnit TickUnit
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "DataGridTopPadding")]
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
		[DefaultValue(0f)]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "DataGridBottomPadding")]
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
		[XmlElement]
		[DefaultValue(null)]
		[Editor(typeof(dlgSQLText.GClass18), typeof(UITypeEditor))]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "SQLTextForHeaderLabel")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "SpecifyTickWidth")]
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
		[XmlArrayItem("Image", typeof(DCTimeLineImage))]
		[Browsable(false)]
		public DCTimeLineImageList Images
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
		[XmlArrayItem("Label", typeof(DCTimeLineLabel))]
		public DCTimeLineLabelList Labels
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "PageIndexText")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "SpecifyStartDate")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "SpecifyEndDate")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "PageSettings")]
		[Browsable(true)]
		[DefaultValue(null)]
		public DocumentPageSettings PageSettings
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "FooterDescription")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "PageTitlePosition")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "ShowIcon")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "ImagePixelWidth")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "ImagePixelHeight")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "ShadowPointDetectSeconds")]
		[DefaultValue(2000)]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "GridYSplitNum")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "GridYSplitInfo")]
		[DefaultValue(null)]
		public GridYSplitInfo GridYSplitInfo
		{
			get
			{
				if (_GridYSplitInfo == null)
				{
					_GridYSplitInfo = new GridYSplitInfo();
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
		[XmlArrayItem("Zone", typeof(TimeLineZoneInfo))]
		[Browsable(false)]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "Zones")]
		public TimeLineZoneInfoList Zones
		{
			get
			{
				if (_Zones == null)
				{
					_Zones = new TimeLineZoneInfoList();
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
		public bool HasTimeLineZones
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "Ticks")]
		[XmlArrayItem("Tick", typeof(TickInfo))]
		[Browsable(true)]
		public TickInfoList Ticks
		{
			get
			{
				if (_Ticks == null)
				{
					_Ticks = new TickInfoList();
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
		[DefaultValue(20f)]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "SymbolSize")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "FontName")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "FontSize")]
		[DefaultValue(9f)]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "BigTitleFontSize")]
		[DefaultValue(27f)]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "ForeColor")]
		[Browsable(true)]
		[XmlIgnore]
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
				return Class157.smethod_4(ForeColor, Color.Black);
			}
			set
			{
				ForeColor = Class157.smethod_5(value, Color.Black);
			}
		}

		/// <summary>
		///       大的垂直网格线颜色
		///       </summary>
		[DCDisplayName(typeof(TemperatureDocumentConfig), "BigVerticalGridLineColor")]
		[Browsable(true)]
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
		[DefaultValue(null)]
		[Browsable(false)]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "BackColor")]
		[DefaultValue(typeof(Color), "Transparent")]
		[XmlIgnore]
		[Browsable(true)]
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
		///       数值文本是否是透明背景色
		///       </summary>
		[DCDisplayName(typeof(TemperatureDocumentConfig), "ValueTextTransparentBackColor")]
		[Browsable(true)]
		[DefaultValue(false)]
		[XmlIgnore]
		public bool ValueTextTransparentBackColor
		{
			get
			{
				return _ValueTextTransparentBackColor;
			}
			set
			{
				_ValueTextTransparentBackColor = value;
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
		[DefaultValue(typeof(Color), "White")]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "PageBackColor")]
		[XmlIgnore]
		[Browsable(true)]
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
		[Browsable(false)]
		[DefaultValue(null)]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "GridLineColor")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Black")]
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
		[DefaultValue(typeof(Color), "Transparent")]
		[Browsable(true)]
		[XmlIgnore]
		[DCDisplayName(typeof(TemperatureDocumentConfig), "GridBackColor")]
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
		[Browsable(false)]
		[DefaultValue(null)]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "DateFormatString")]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "Title")]
		[DefaultValue(null)]
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "SpecifyTitleHeight")]
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
		[XmlArrayItem("Label", typeof(HeaderLabelInfo))]
		public HeaderLabelInfoList HeaderLabels
		{
			get
			{
				if (_HeaderLabels == null)
				{
					_HeaderLabels = new HeaderLabelInfoList();
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
		[DCDisplayName(typeof(TemperatureDocumentConfig), "NumOfDaysInOnePage")]
		[DefaultValue(7)]
		public int NumOfDaysInOnePage
		{
			get
			{
				return _NumOfDaysInOnePage;
			}
			set
			{
				_NumOfDaysInOnePage = value;
			}
		}

		/// <summary>
		///       标题行信息
		///       </summary>
		[Browsable(false)]
		[XmlArrayItem("Line", typeof(TitleLineInfo))]
		public TitleLineInfoList HeaderLines
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
		[XmlArrayItem("Line", typeof(TitleLineInfo))]
		[Browsable(false)]
		public TitleLineInfoList FooterLines
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
		[Browsable(false)]
		[XmlArrayItem("YAxis", typeof(YAxisInfo))]
		public YAxisInfoList YAxisInfos
		{
			get
			{
				if (_YAxisInfos == null)
				{
					_YAxisInfos = new YAxisInfoList();
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
		public TemperatureDocumentConfig()
		{
			_Version = "1.0";
			_PageSettings = new DocumentPageSettings();
		}

		internal void CheckDefaultTicks()
		{
			int num = 1;
			if (_Ticks == null || _Ticks.Count == 0)
			{
				_Ticks = new TickInfoList();
				_Ticks.AddItem(2, "2", Color.Red);
				_Ticks.AddItem(6, "6", Color.Red);
				_Ticks.AddItem(10, "10", Color.Black);
				_Ticks.AddItem(14, "14", Color.Black);
				_Ticks.AddItem(18, "18", Color.Black);
				_Ticks.AddItem(22, "22", Color.Red);
			}
		}

		/// <summary>
		///       获得文档中所有的文本行列表
		///       </summary>
		/// <returns>
		/// </returns>
		internal TitleLineInfoList GetAllTitleLines()
		{
			TitleLineInfoList titleLineInfoList = new TitleLineInfoList();
			titleLineInfoList.AddRange(HeaderLines);
			titleLineInfoList.AddRange(FooterLines);
			return titleLineInfoList;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public TemperatureDocumentConfig Clone()
		{
			TemperatureDocumentConfig temperatureDocumentConfig = (TemperatureDocumentConfig)MemberwiseClone();
			if (_Images != null)
			{
				temperatureDocumentConfig._Images = new DCTimeLineImageList();
				foreach (DCTimeLineImage image in _Images)
				{
					temperatureDocumentConfig._Images.Add(image.Clone());
				}
			}
			if (_FooterLines != null)
			{
				temperatureDocumentConfig._FooterLines = new TitleLineInfoList();
				foreach (TitleLineInfo footerLine in _FooterLines)
				{
					temperatureDocumentConfig._FooterLines.Add(footerLine.Clone());
				}
			}
			if (_HeaderLines != null)
			{
				temperatureDocumentConfig._HeaderLines = new TitleLineInfoList();
				foreach (TitleLineInfo headerLine in _HeaderLines)
				{
					temperatureDocumentConfig._HeaderLines.Add(headerLine.Clone());
				}
			}
			if (_YAxisInfos != null)
			{
				temperatureDocumentConfig._YAxisInfos = new YAxisInfoList();
				foreach (YAxisInfo yAxisInfo in _YAxisInfos)
				{
					temperatureDocumentConfig._YAxisInfos.Add(yAxisInfo);
				}
			}
			if (_Ticks != null)
			{
				temperatureDocumentConfig._Ticks = _Ticks.Clone();
			}
			if (_Zones != null)
			{
				temperatureDocumentConfig._Zones = new TimeLineZoneInfoList();
				foreach (TimeLineZoneInfo zone in _Zones)
				{
					temperatureDocumentConfig._Zones.Add(zone.Clone());
				}
			}
			if (HeaderLabels != null)
			{
				temperatureDocumentConfig._HeaderLabels = _HeaderLabels.Clone();
			}
			if (_Labels != null)
			{
				temperatureDocumentConfig._Labels = _Labels.Clone();
			}
			return temperatureDocumentConfig;
		}
	}
}
