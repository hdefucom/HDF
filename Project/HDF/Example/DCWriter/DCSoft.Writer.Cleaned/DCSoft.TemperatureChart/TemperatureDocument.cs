using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///        体温信息文档对象
	///        </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[DocumentComment]
	[ComDefaultInterface(typeof(ITemperatureDocument))]
	[Guid("E4A142CF-3E9C-4C5F-A84D-9EC3C0C61F3C")]
	public class TemperatureDocument : ITemperatureDocument
	{
		private class Class47
		{
		}

		internal enum Enum4
		{
			const_0,
			const_1,
			const_2
		}

		internal const int int_0 = 16;

		public const string string_0 = "2014-5-20";

		/// <summary>
		///       表示空日期的字符串
		///       </summary>
		public const string NullDateString = "1900-1-1";

		/// <summary>
		///       表示空的数据
		///       </summary>
		public const float NullValue = -10000f;

		private static string _RegisterCode = null;

		[DCInternal]
		public static GDelegate24 gdelegate24_0 = null;

		private static int int_1 = 0;

		private int int_2 = int_1++;

		private Enum16 enum16_0 = Enum16.const_0;

		private bool bool_0 = false;

		private TemperatureDocumentConfig temperatureDocumentConfig_0 = null;

		private float float_0 = 0f;

		private float float_1 = 0f;

		private float float_2 = 750f;

		private float float_3 = 1020f;

		private Color color_0 = Color.Transparent;

		private DocumentViewMode documentViewMode_0 = DocumentViewMode.Page;

		private int int_3 = 0;

		internal int int_4 = 0;

		private float float_4 = 0f;

		[NonSerialized]
		private object object_0 = null;

		/// <summary>
		///       表示空的日期
		///       </summary>
		public static DateTime NullDate = new DateTime(1900, 1, 1);

		private static Random random_0 = new Random();

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private DateTime dateTime_0 = DateTime.MinValue;

		private DateTime dateTime_1 = DateTime.MinValue;

		private float float_5 = 0f;

		private YAxisInfoList yaxisInfoList_0 = new YAxisInfoList();

		private YAxisInfoList yaxisInfoList_1 = new YAxisInfoList();

		private bool bool_1 = true;

		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public EventHandler eventHandler_0 = null;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		private static DrawStringFormatExt drawStringFormatExt_1 = null;

		private DateTime dateTime_2 = NullDate;

		private DCTimeLineParameterList dctimeLineParameterList_0 = new DCTimeLineParameterList();

		private DocumentDataList documentDataList_0 = new DocumentDataList();

		[NonSerialized]
		private TitleLineInfoList titleLineInfoList_0 = null;

		[NonSerialized]
		private TitleLineInfoList titleLineInfoList_1 = null;

		[NonSerialized]
		private Hashtable hashtable_0 = new Hashtable();

		private int int_5 = 0;

		[NonSerialized]
		private Class159 class159_0 = null;

		private DateTime dateTime_3 = NullDate;

		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private bool bool_2 = false;

		[NonSerialized]
		private ValuePoint valuePoint_0 = null;

		[NonSerialized]
		internal Dictionary<ValuePoint, RectangleF> dictionary_1 = null;

		private float float_6 = 0f;

		private static DrawStringFormatExt drawStringFormatExt_2 = null;

		private float float_7 = 0f;

		internal RectangleF rectangleF_1 = RectangleF.Empty;

		private static Bitmap bitmap_0 = null;

		private static Bitmap bitmap_1 = null;

		internal static string LicenseTitle
		{
			get
			{
				GClass472 gClass = smethod_0(null);
				if (gClass != null)
				{
					if (string.IsNullOrEmpty(gClass.method_2()))
					{
						return gClass.method_8();
					}
					return gClass.method_2();
				}
				return null;
			}
		}

		/// <summary>
		///       静态的注册码属性
		///       </summary>
		public static string StaticRegisterCode
		{
			get
			{
				return null;
			}
			set
			{
				_RegisterCode = value;
				smethod_1();
			}
		}

		/// <summary>
		///       注册码
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DefaultValue(null)]
		public string RegisterCode
		{
			get
			{
				return _RegisterCode;
			}
			set
			{
				_RegisterCode = value;
				smethod_1();
			}
		}

		/// <summary>
		///       判断控件是否已经注册了
		///       </summary>
		internal static bool IsRegistered => smethod_0(null)?.method_6() ?? false;

		/// <summary>
		///       程序集是否混淆加密
		///       </summary>
		[Browsable(false)]
		public static bool IsAssemblyObfuscation => typeof(Class47).Name != "TempClass";

		/// <summary>
		///       对象实例编号
		///       </summary>
		public int InstanceIndex => int_2;

		/// <summary>
		///       文档行为模式
		///       </summary>
		internal Enum16 InnerBehaviorMode
		{
			get
			{
				return enum16_0;
			}
			set
			{
				enum16_0 = value;
			}
		}

		/// <summary>
		///       文档数据是否发生改变标记
		///       </summary>
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Modified
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       文档配置
		///       </summary>
		[DefaultValue(null)]
		public TemperatureDocumentConfig Config
		{
			get
			{
				if (temperatureDocumentConfig_0 == null)
				{
					temperatureDocumentConfig_0 = new TemperatureDocumentConfig();
					temperatureDocumentConfig_0.CheckDefaultTicks();
				}
				return temperatureDocumentConfig_0;
			}
			set
			{
				temperatureDocumentConfig_0 = value;
				object_0 = null;
				LayoutInvalidate = true;
			}
		}

		/// <summary>
		///       检测阴影数据点的时钟秒数
		///       </summary>
		[XmlIgnore]
		[DefaultValue(2000)]
		public int ShadowPointDetectSeconds
		{
			get
			{
				return Config.ShadowPointDetectSeconds;
			}
			set
			{
				Config.ShadowPointDetectSeconds = value;
			}
		}

		/// <summary>
		///       图标像素宽度
		///       </summary>
		[DefaultValue(16)]
		[XmlIgnore]
		public int ImagePixelWidth
		{
			get
			{
				return Config.ImagePixelWidth;
			}
			set
			{
				Config.ImagePixelWidth = value;
			}
		}

		/// <summary>
		///       图标像素高度
		///       </summary>
		[XmlIgnore]
		[DefaultValue(16)]
		public int ImagePixelHeight
		{
			get
			{
				return Config.ImagePixelHeight;
			}
			set
			{
				Config.ImagePixelHeight = value;
			}
		}

		/// <summary>
		///       左端位置
		///       </summary>
		[XmlIgnore]
		[DefaultValue(0f)]
		public float Left
		{
			get
			{
				return float_0;
			}
			set
			{
				if (float_0 != value)
				{
					LayoutInvalidate = true;
					float_0 = value;
				}
			}
		}

		/// <summary>
		///       右端坐标
		///       </summary>
		[Browsable(false)]
		public float Right => float_0 + float_2;

		/// <summary>
		///       顶端位置
		///       </summary>
		[DefaultValue(0)]
		[XmlIgnore]
		public float Top
		{
			get
			{
				return float_1;
			}
			set
			{
				if (float_1 != value)
				{
					LayoutInvalidate = true;
					float_1 = value;
				}
			}
		}

		/// <summary>
		///       下端坐标
		///       </summary>
		[Browsable(false)]
		public float Bottom => float_1 + float_3;

		/// <summary>
		///       宽度
		///       </summary>
		[XmlIgnore]
		[DefaultValue(750)]
		public float Width
		{
			get
			{
				return float_2;
			}
			set
			{
				if (float_2 != value)
				{
					LayoutInvalidate = true;
					float_2 = value;
				}
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		[DefaultValue(1020)]
		[XmlIgnore]
		public float Height
		{
			get
			{
				return float_3;
			}
			set
			{
				if (float_3 != value)
				{
					LayoutInvalidate = true;
					float_3 = value;
				}
			}
		}

		/// <summary>
		///       边界
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
				Left = value.Left;
				Top = value.Top;
				Width = value.Width;
				Height = value.Height;
			}
		}

		/// <summary>
		///       Y轴分割份数
		///       </summary>
		[DefaultValue(8)]
		[XmlIgnore]
		public int GridYSplitNum
		{
			get
			{
				return Config.GridYSplitNum;
			}
			set
			{
				Config.GridYSplitNum = value;
			}
		}

		/// <summary>
		///       网格线颜色
		///       </summary>
		[XmlIgnore]
		public Color GridLineColor
		{
			get
			{
				return Config.GridLineColor;
			}
			set
			{
				Config.GridLineColor = value;
			}
		}

		internal int HoutTicksLength
		{
			get
			{
				if (Config.Ticks.Count == 0)
				{
					return 1;
				}
				return Config.Ticks.Count;
			}
		}

		/// <summary>
		///       数据点符号大小
		///       </summary>
		[DefaultValue(20f)]
		[XmlIgnore]
		public float SymbolSize
		{
			get
			{
				return Config.SymbolSize;
			}
			set
			{
				Config.SymbolSize = value;
			}
		}

		/// <summary>
		///       字体名称
		///       </summary>
		[DefaultValue("宋体")]
		[XmlIgnore]
		public string FontName
		{
			get
			{
				return Config.FontName;
			}
			set
			{
				Config.FontName = value;
			}
		}

		/// <summary>
		///       字体的大小
		///       </summary>
		[XmlIgnore]
		[DefaultValue(9f)]
		public float FontSize
		{
			get
			{
				return Config.FontSize;
			}
			set
			{
				Config.FontSize = value;
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color BackColor
		{
			get
			{
				return color_0;
			}
			set
			{
				color_0 = value;
			}
		}

		/// <summary>
		///       输出日期数据使用的格式化字符串
		///       </summary>
		[DefaultValue("yyyy-MM-dd")]
		[XmlIgnore]
		public string DateFormatString
		{
			get
			{
				return Config.DateFormatString;
			}
			set
			{
				Config.DateFormatString = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[XmlIgnore]
		[DefaultValue(null)]
		public string Title
		{
			get
			{
				return Config.Title;
			}
			set
			{
				Config.Title = value;
			}
		}

		/// <summary>
		///       页面标题
		///       </summary>
		[XmlArrayItem("Label", typeof(HeaderLabelInfo))]
		[XmlIgnore]
		public HeaderLabelInfoList HeaderLabels
		{
			get
			{
				return Config.HeaderLabels;
			}
			set
			{
				Config.HeaderLabels = value;
			}
		}

		/// <summary>
		///       文档视图模式
		///       </summary>
		[Category("Layout")]
		[DefaultValue(DocumentViewMode.Page)]
		[XmlIgnore]
		public DocumentViewMode ViewMode
		{
			get
			{
				return documentViewMode_0;
			}
			set
			{
				if (documentViewMode_0 != value)
				{
					documentViewMode_0 = value;
					LayoutInvalidate = true;
				}
			}
		}

		/// <summary>
		///       从0开始计算的当前页号
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public int PageIndex
		{
			get
			{
				return int_3;
			}
			set
			{
				if (int_3 != value)
				{
					int_3 = value;
					if (ViewMode == DocumentViewMode.Normal || ViewMode == DocumentViewMode.Page)
					{
						LayoutInvalidate = true;
						foreach (YAxisInfo yAxisInfo in YAxisInfos)
						{
							foreach (ValuePoint item in method_19(yAxisInfo.Name))
							{
								item.Left = float.NaN;
								item.Top = float.NaN;
								item.Width = 0f;
								item.Height = 0f;
							}
						}
						foreach (TitleLineInfo footerLine in FooterLines)
						{
							foreach (ValuePoint item2 in method_19(footerLine.Name))
							{
								item2.Left = float.NaN;
								item2.Top = float.NaN;
								item2.Width = 0f;
								item2.Height = 0f;
							}
						}
					}
				}
			}
		}

		/// <summary>
		///       运行时的当前页码
		///       </summary>
		private int RuntimePageIndex
		{
			get
			{
				if (ViewMode == DocumentViewMode.Timeline)
				{
					return 0;
				}
				if (int_3 < 0)
				{
					return 0;
				}
				if (int_3 >= NumOfPages)
				{
					return NumOfPages - 1;
				}
				return int_3;
			}
		}

		/// <summary>
		///       总页数
		///       </summary>
		[Browsable(false)]
		public int NumOfPages => int_4;

		/// <summary>
		///       文档配置字符串
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public string ConfigXml
		{
			get
			{
				return XMLHelper.SaveObjectToIndentXMLString(Config);
			}
			set
			{
				TemperatureDocumentConfig temperatureDocumentConfig = (TemperatureDocumentConfig)XMLHelper.LoadObjectFromXMLString(typeof(TemperatureDocumentConfig), value);
				if (temperatureDocumentConfig != null)
				{
					Config = temperatureDocumentConfig;
					int_3 = 0;
				}
			}
		}

		/// <summary>
		///       设置、获得包含文档数据的XML字符串
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		public string XMLText
		{
			get
			{
				return XMLHelper.SaveObjectToXMLString(this);
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					((TemperatureDocument)XMLHelper.LoadObjectFromXMLString(typeof(TemperatureDocument), value))?.method_55(this);
				}
			}
		}

		/// <summary>
		///       设置、获得包含文档数据的带缩进的XML字符串
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string XMLTextIndented
		{
			get
			{
				return XMLHelper.SaveObjectToIndentXMLString(this);
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					((TemperatureDocument)XMLHelper.LoadObjectFromXMLString(typeof(TemperatureDocument), value))?.method_55(this);
				}
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		internal object SelectedObject
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

		internal GraphicsUnit GraphicsUnit => GraphicsUnit.Document;

		/// <summary>
		///       数据网格区域
		///       </summary>
		internal RectangleF DataGridBounds => rectangleF_0;

		/// <summary>
		///       可见的Y刻度尺信息对象列表
		///       </summary>
		internal YAxisInfoList VisibleYAxisInfos
		{
			get
			{
				return yaxisInfoList_0;
			}
			set
			{
				yaxisInfoList_0 = value;
			}
		}

		/// <summary>
		///       文档内容布局无效，需要重新计算布局
		///       </summary>
		internal bool LayoutInvalidate
		{
			get
			{
				return bool_1;
			}
			set
			{
				if (bool_1 != value)
				{
					bool_1 = value;
					if (bool_1)
					{
						titleLineInfoList_1 = null;
						titleLineInfoList_0 = null;
					}
				}
			}
		}

		/// <summary>
		///       居中的字符串格式化对象
		///       </summary>
		private DrawStringFormatExt StringFormatForCenter
		{
			get
			{
				if (drawStringFormatExt_0 == null)
				{
					drawStringFormatExt_0 = new DrawStringFormatExt();
					drawStringFormatExt_0.Alignment = StringAlignment.Center;
					drawStringFormatExt_0.LineAlignment = StringAlignment.Center;
					drawStringFormatExt_0.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
				}
				return drawStringFormatExt_0;
			}
		}

		/// <summary>
		///       绘制坐标网格中文本标签使用的格式化对象
		///       </summary>
		private DrawStringFormatExt StringFormatForYAxisLabelValue
		{
			get
			{
				if (drawStringFormatExt_1 == null)
				{
					drawStringFormatExt_1 = DrawStringFormatExt.GenericDefault.Clone();
					drawStringFormatExt_1.FormatFlags = (StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap);
					drawStringFormatExt_1.Alignment = StringAlignment.Near;
					drawStringFormatExt_1.LineAlignment = StringAlignment.Center;
					drawStringFormatExt_1.Trimming = StringTrimming.None;
				}
				return drawStringFormatExt_1;
			}
		}

		/// <summary>
		///       光标所在的时间值
		///       </summary>
		[DefaultValue(typeof(DateTime), "1900-1-1")]
		public DateTime CaretDateTime
		{
			get
			{
				return dateTime_2;
			}
			set
			{
				dateTime_2 = value;
			}
		}

		/// <summary>
		///       文档参数值
		///       </summary>
		[XmlArrayItem("Parameter", typeof(DCTimeLineParameter))]
		public DCTimeLineParameterList Parameters
		{
			get
			{
				if (dctimeLineParameterList_0 == null)
				{
					dctimeLineParameterList_0 = new DCTimeLineParameterList();
				}
				return dctimeLineParameterList_0;
			}
			set
			{
				dctimeLineParameterList_0 = value;
			}
		}

		/// <summary>
		///       数值
		///       </summary>
		[XmlArrayItem("Data", typeof(DocumentData))]
		[DefaultValue(null)]
		public DocumentDataList Datas
		{
			get
			{
				if (documentDataList_0 == null)
				{
					documentDataList_0 = new DocumentDataList();
				}
				return documentDataList_0;
			}
			set
			{
				documentDataList_0 = value;
			}
		}

		/// <summary>
		///       每页显示的天数
		///       </summary>
		[XmlIgnore]
		[DefaultValue(7)]
		public int NumOfDaysInOnePage
		{
			get
			{
				return Config.NumOfDaysInOnePage;
			}
			set
			{
				Config.NumOfDaysInOnePage = value;
			}
		}

		private int RuntimeNumOfDaysInOnePage
		{
			get
			{
				if (ViewMode == DocumentViewMode.Timeline)
				{
					if (Days <= 0)
					{
						return NumOfDaysInOnePage;
					}
					return Days;
				}
				return NumOfDaysInOnePage;
			}
		}

		/// <summary>
		///       标题行信息
		///       </summary>
		[XmlIgnore]
		public TitleLineInfoList HeaderLines
		{
			get
			{
				return Config.HeaderLines;
			}
			set
			{
				Config.HeaderLines = value;
			}
		}

		/// <summary>
		///       实际参与绘图的标题行列表
		///       </summary>
		internal TitleLineInfoList RuntimeHeaderLines
		{
			get
			{
				if (InnerBehaviorMode == Enum16.const_1)
				{
					return Config.HeaderLines;
				}
				if (titleLineInfoList_0 == null)
				{
					titleLineInfoList_0 = Config.HeaderLines.GetRuntimeInfos();
				}
				return titleLineInfoList_0;
			}
		}

		/// <summary>
		///       页脚行信息
		///       </summary>
		[XmlIgnore]
		public TitleLineInfoList FooterLines
		{
			get
			{
				return Config.FooterLines;
			}
			set
			{
				Config.FooterLines = value;
			}
		}

		/// <summary>
		///       实际参与绘图的标题行列表
		///       </summary>
		internal TitleLineInfoList RuntimeFooterLines
		{
			get
			{
				if (InnerBehaviorMode == Enum16.const_1)
				{
					return Config.FooterLines;
				}
				if (titleLineInfoList_1 == null)
				{
					titleLineInfoList_1 = Config.FooterLines.GetRuntimeInfos();
				}
				return titleLineInfoList_1;
			}
		}

		/// <summary>
		///       Y坐标轴信息列表
		///       </summary>
		[XmlIgnore]
		public YAxisInfoList YAxisInfos
		{
			get
			{
				return Config.YAxisInfos;
			}
			set
			{
				Config.YAxisInfos = value;
			}
		}

		/// <summary>
		///       对象绑定的数据源对象列表
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		public Hashtable DataSources
		{
			get
			{
				if (hashtable_0 == null)
				{
					hashtable_0 = new Hashtable();
				}
				return hashtable_0;
			}
		}

		/// <summary>
		///       时间跨度天数
		///       </summary>
		public int Days => int_5;

		/// <summary>
		///       运行时使用的时间刻度列表
		///       </summary>
		internal Class159 RuntimeTicks => class159_0;

		/// <summary>
		///       SQL查询使用的参数列表
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public Dictionary<string, object> SQLParameters
		{
			get
			{
				if (dictionary_0 == null)
				{
					dictionary_0 = new Dictionary<string, object>();
				}
				return dictionary_0;
			}
			set
			{
				dictionary_0 = value;
			}
		}

		/// <summary>
		///       正在打印模式
		///       </summary>
		internal bool PrintingMode
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
		///       鼠标悬停的数据点
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		internal ValuePoint MouseHoverValuePoint
		{
			get
			{
				return valuePoint_0;
			}
			set
			{
				valuePoint_0 = value;
			}
		}

		/// <summary>
		///       文档左侧标题栏宽度
		///       </summary>
		[Browsable(false)]
		private float LeftHeaderWidth => float_6;

		/// <summary>
		///       文档左侧标题栏像素宽度
		///       </summary>
		[Browsable(false)]
		public float LeftHeaderPixelWidth => GraphicsUnitConvert.Convert(LeftHeaderWidth, GraphicsUnit, GraphicsUnit.Pixel);

		/// <summary>
		///       绘制行标题使用的字符格式化对象
		///       </summary>
		internal DrawStringFormatExt LineTitleStringFormat
		{
			get
			{
				if (drawStringFormatExt_2 == null)
				{
					drawStringFormatExt_2 = new DrawStringFormatExt();
					drawStringFormatExt_2.Alignment = StringAlignment.Near;
					drawStringFormatExt_2.LineAlignment = StringAlignment.Center;
					drawStringFormatExt_2.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
				}
				return drawStringFormatExt_2;
			}
		}

		/// <summary>
		///       一个最小时间刻度的宽度
		///       </summary>
		public float TickViewWidth => float_7;

		/// <summary>
		///       获得前景色的画笔对象
		///       </summary>
		/// <returns>
		/// </returns>
		private Pen ForePen => GClass438.smethod_1(method_24(Config.ForeColor));

		private Color RuntimeForeColor => method_24(Config.ForeColor);

		/// <summary>
		///       获得前景色的画刷对象
		///       </summary>
		/// <returns>
		/// </returns>
		private SolidBrush ForeBrush => GClass438.smethod_0(method_24(Config.ForeColor));

		internal static GClass472 smethod_0(TemperatureDocument temperatureDocument_0)
		{
			if (gdelegate24_0 != null)
			{
				object obj = gdelegate24_0(temperatureDocument_0, typeof(TemperatureDocument), 16);
				if (obj is GClass472)
				{
					return (GClass472)obj;
				}
			}
			GClass472 gClass = new GClass472();
			string string_ = "【未注册，请联系南京都昌信息科技有限公司进行注册】";
			gClass.method_7(bool_7: false);
			gClass.method_9(string_);
			gClass.method_13(20f);
			gClass.method_17(Color.Red);
			return gClass;
		}

		internal static void smethod_1()
		{
		}

		internal static string smethod_2(DateTime dateTime_4)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(dateTime_4.Year + "年" + dateTime_4.Month + "月" + dateTime_4.Day + "日");
			if (dateTime_4.Hour <= 0 || dateTime_4.Millisecond <= 0 || dateTime_4.Second <= 0)
			{
			}
			return stringBuilder.ToString();
		}

		private XFontValue method_0(TitleLineInfo titleLineInfo_0, bool bool_3)
		{
			XFontValue xFontValue = null;
			if (titleLineInfo_0 != null)
			{
				if (bool_3)
				{
					xFontValue = titleLineInfo_0.ValueFont;
					if (xFontValue == null)
					{
						xFontValue = titleLineInfo_0.Font;
					}
				}
				else
				{
					xFontValue = titleLineInfo_0.Font;
				}
			}
			if (xFontValue == null)
			{
				xFontValue = new XFontValue();
				xFontValue.Name = FontName;
				xFontValue.Size = FontSize;
			}
			return xFontValue;
		}

		private XFontValue method_1(YAxisInfo yaxisInfo_0, bool bool_3)
		{
			XFontValue xFontValue = null;
			if (yaxisInfo_0 != null)
			{
				if (bool_3)
				{
					xFontValue = yaxisInfo_0.ValueFont;
					if (xFontValue == null)
					{
						xFontValue = yaxisInfo_0.Font;
					}
				}
				else
				{
					xFontValue = yaxisInfo_0.Font;
				}
			}
			if (xFontValue == null)
			{
				xFontValue = new XFontValue();
				xFontValue.Name = FontName;
				xFontValue.Size = FontSize;
			}
			return xFontValue;
		}

		private XFontValue method_2()
		{
			return Config.RuntimeFont;
		}

		private XFontValue method_3()
		{
			string text = FontName;
			if (string.IsNullOrEmpty(text))
			{
				text = Control.DefaultFont.Name;
			}
			return new XFontValue(text, Config.BigTitleFontSize);
		}

		public string method_4()
		{
			int num = 5;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<table border='1'>");
			stringBuilder.AppendLine("\t<tr bgcolor='#dddddd'><td>时间</td>");
			List<string> list = new List<string>();
			foreach (DocumentData data in Datas)
			{
				string str = data.Name;
				TitleLineInfo titleLineInfo = method_20(data.Name);
				if (titleLineInfo != null)
				{
					if (!string.IsNullOrEmpty(titleLineInfo.Title))
					{
						str = titleLineInfo.Title;
					}
				}
				else
				{
					YAxisInfo itemByName = YAxisInfos.GetItemByName(data.Name);
					if (itemByName != null && !string.IsNullOrEmpty(itemByName.Title))
					{
						str = itemByName.Title;
						if (itemByName.Style == YAxisInfoStyle.Value)
						{
							list.Add(data.Name);
						}
					}
				}
				stringBuilder.AppendLine("\t<td>" + str + "</td>");
			}
			stringBuilder.AppendLine("\t</tr>");
			List<DateTime> list2 = new List<DateTime>();
			foreach (DocumentData data2 in Datas)
			{
				foreach (ValuePoint value in data2.Values)
				{
					if (!list2.Contains(value.Time))
					{
						list2.Add(value.Time);
					}
				}
			}
			list2.Sort();
			foreach (DateTime item in list2)
			{
				stringBuilder.AppendLine("\t<tr>");
				stringBuilder.AppendLine("\t<td>" + item.ToString("yyyy-MM-dd HH:mm:ss") + "</td>");
				foreach (DocumentData data3 in Datas)
				{
					bool flag = false;
					foreach (ValuePoint value2 in data3.Values)
					{
						if (value2.Time == item)
						{
							if (list.Contains(data3.Name))
							{
								if (smethod_3(value2.Value))
								{
									stringBuilder.AppendLine("\t<td>&nbsp;</td>");
								}
								else
								{
									stringBuilder.AppendLine("\t<td>" + value2.Value + "</td>");
								}
							}
							else
							{
								stringBuilder.AppendLine("\t<td>" + value2.RuntimeText + "</td>");
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						stringBuilder.AppendLine("\t<td>&nbsp;</td>");
					}
				}
				stringBuilder.AppendLine("\t</tr>");
			}
			stringBuilder.AppendLine("</table>");
			return stringBuilder.ToString();
		}

		private void method_5()
		{
			float num = float_4;
			if ((ViewMode == DocumentViewMode.Page || ViewMode == DocumentViewMode.Normal) && LeftHeaderWidth > 0f)
			{
				float num2 = 0f;
				int num3 = 0;
				foreach (Class158 item in class159_0)
				{
					if (item.timeLineZoneInfo_0 != null && item.timeLineZoneInfo_0.SpecifyTickWidth > 0f)
					{
						num2 += item.timeLineZoneInfo_0.SpecifyTickWidth;
					}
					else
					{
						num2 += float_4;
						num3++;
					}
				}
				if (num2 != Width - LeftHeaderWidth && num3 > 0)
				{
					num = (Width - LeftHeaderWidth) / (float)num3;
					if (num <= 0f)
					{
						num = float_4;
					}
				}
			}
			float num4 = 0f;
			foreach (Class158 item2 in class159_0)
			{
				item2.float_0 = num4;
				if (item2.timeLineZoneInfo_0 != null && item2.timeLineZoneInfo_0.SpecifyTickWidth > 0f)
				{
					item2.float_1 = item2.timeLineZoneInfo_0.SpecifyTickWidth;
				}
				else
				{
					item2.float_1 = num;
				}
				num4 += item2.float_1;
			}
			class159_0.method_20(num4);
		}

		internal SizeF method_6(Graphics graphics_0)
		{
			int num = 14;
			graphics_0.PageUnit = GraphicsUnit;
			Config.CheckDefaultTicks();
			DateTime maxDate = NullDate;
			DateTime minDate = NullDate;
			UpdateNumOfPage(out maxDate, out minDate);
			_ = (int)maxDate.Subtract(minDate).TotalDays;
			method_22(minDate, maxDate, 0);
			_ = class159_0.Count;
			method_15(new DCGraphics(graphics_0));
			float num2 = float_6;
			float num3 = 0f;
			XFontValue xFontValue = method_2();
			_ = graphics_0.MeasureString("HHHH", xFontValue.Value).Width;
			float num4 = Config.SpecifyTickWidth;
			if (num4 <= 0f)
			{
				num4 = graphics_0.MeasureString("HH", xFontValue.Value, 10000, StringFormat.GenericTypographic).Width * 1.1f;
			}
			float_4 = num4;
			method_5();
			num2 += class159_0.method_19();
			float num5 = xFontValue.GetHeight(graphics_0) * 1.1f;
			num3 = num5 * (float)(RuntimeHeaderLines.Count + RuntimeFooterLines.Count);
			num3 += 1000f;
			return new SizeF(num2, num3);
		}

		internal void method_7()
		{
		}

		/// <summary>
		///       创建一个完整的图片，包含所有的内容
		///       </summary>
		/// <returns>
		/// </returns>
		public Bitmap CreateFullContentBmp()
		{
			Bitmap bitmap = new Bitmap((int)Width, (int)Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.White);
				PageIndex = 0;
				method_29(new DCGraphics(graphics), new RectangleF(0f, 0f, Right, Bottom), GEnum22.const_2);
			}
			return bitmap;
		}

		/// <summary>
		///       创建包含指定页码内容的图片对象
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码</param>
		/// <returns>创建的图片对象</returns>
		public Bitmap CreatePageBmp(int pageIndex)
		{
			Bitmap bitmap;
			if (ViewMode == DocumentViewMode.Timeline || ViewMode == DocumentViewMode.Normal)
			{
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(Width, Height), GraphicsUnit, GraphicsUnit.Pixel);
				bitmap = new Bitmap((int)sizeF.Width, (int)sizeF.Height);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.PageUnit = GraphicsUnit;
					if (Config.PageBackColor.A == 0)
					{
						graphics.Clear(Color.White);
					}
					else
					{
						graphics.Clear(Config.PageBackColor);
					}
					PageIndex = PageIndex;
					method_29(new DCGraphics(graphics), new RectangleF(0f, 0f, Right, Bottom), GEnum22.const_2);
				}
				return bitmap;
			}
			PageSettings pageSettings = new PageSettings();
			bitmap = new Bitmap((int)((double)pageSettings.Bounds.Width * 96.0 / 100.0), (int)((double)pageSettings.Bounds.Height * 96.0 / 100.0));
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				if (Config.PageBackColor.A == 0)
				{
					graphics.Clear(Color.White);
				}
				else
				{
					graphics.Clear(Config.PageBackColor);
				}
				method_8(pageSettings);
				DocumentViewMode viewMode = ViewMode;
				ViewMode = DocumentViewMode.Page;
				PageIndex = pageIndex;
				method_29(new DCGraphics(graphics), new RectangleF(0f, 0f, Right, Bottom), GEnum22.const_2);
				ViewMode = viewMode;
			}
			return bitmap;
		}

		internal RectangleF method_8(PageSettings pageSettings_0)
		{
			Rectangle rectangle = XPaperSizeCollection.smethod_0(pageSettings_0);
			RectangleF result = new Rectangle(0, 0, rectangle.Width * 3, rectangle.Height * 3);
			RectangleF empty = RectangleF.Empty;
			empty.X = result.X + (float)(pageSettings_0.Margins.Left * 3);
			empty.Y = result.Y + (float)(pageSettings_0.Margins.Top * 3);
			empty.Width = result.Right - (float)(pageSettings_0.Margins.Right * 3) - empty.Left;
			empty.Height = result.Bottom - (float)(pageSettings_0.Margins.Bottom * 3) - empty.Top;
			Left = empty.Left;
			Top = empty.Top;
			Width = empty.Width;
			Height = empty.Height;
			return result;
		}

		private RectangleF method_9(object object_1)
		{
			if (object_1 is HeaderLabelInfo)
			{
				HeaderLabelInfo headerLabelInfo = (HeaderLabelInfo)object_1;
				return new RectangleF(headerLabelInfo.Left, headerLabelInfo.Top, headerLabelInfo.Width, headerLabelInfo.Height);
			}
			if (object_1 is TitleLineInfo)
			{
				TitleLineInfo titleLineInfo = (TitleLineInfo)object_1;
				return titleLineInfo.TitleBounds;
			}
			if (object_1 is YAxisInfo)
			{
				YAxisInfo yAxisInfo = (YAxisInfo)object_1;
				return yAxisInfo.TitleBounds;
			}
			if (object_1 is TemperatureDocument || object_1 is TemperatureDocumentConfig)
			{
				if (ViewMode == DocumentViewMode.Page || ViewMode == DocumentViewMode.Normal)
				{
					return new RectangleF(Left, Top, Width, Height);
				}
				return new RectangleF(Left, Top, LeftHeaderWidth, Height);
			}
			if (object_1 is DCTimeLineImage)
			{
				DCTimeLineImage dCTimeLineImage = (DCTimeLineImage)object_1;
				return new RectangleF(Left + dCTimeLineImage.Left, Top + dCTimeLineImage.Top, dCTimeLineImage.ImagePixelWidth, dCTimeLineImage.ImagePixelHeight);
			}
			if (object_1 is DCTimeLineLabel)
			{
				DCTimeLineLabel dCTimeLineLabel = (DCTimeLineLabel)object_1;
				return new RectangleF(Left + dCTimeLineLabel.Left, Top + dCTimeLineLabel.Top, dCTimeLineLabel.Width, dCTimeLineLabel.Height);
			}
			if (object_1 is TimeLineZoneInfo)
			{
				TimeLineZoneInfo timeLineZoneInfo = (TimeLineZoneInfo)object_1;
				return new RectangleF(timeLineZoneInfo.Left, timeLineZoneInfo.Top, timeLineZoneInfo.Width, timeLineZoneInfo.Height);
			}
			return RectangleF.Empty;
		}

		internal object method_10(float float_8, float float_9)
		{
			if (ViewMode == DocumentViewMode.Page && Config.Labels != null)
			{
				foreach (DCTimeLineLabel label in Config.Labels)
				{
					RectangleF rectangleF = method_9(label);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return label;
					}
				}
			}
			if (Config.Images != null)
			{
				foreach (DCTimeLineImage image in Config.Images)
				{
					RectangleF rectangleF = method_9(image);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return image;
					}
				}
			}
			if (Config.HeaderLabels != null)
			{
				foreach (HeaderLabelInfo headerLabel in Config.HeaderLabels)
				{
					RectangleF rectangleF = method_9(headerLabel);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return headerLabel;
					}
				}
			}
			if (Config.HeaderLines != null)
			{
				foreach (TitleLineInfo headerLine in Config.HeaderLines)
				{
					RectangleF rectangleF = method_9(headerLine);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return headerLine;
					}
				}
			}
			if (Config.YAxisInfos != null)
			{
				foreach (YAxisInfo yAxisInfo in Config.YAxisInfos)
				{
					RectangleF rectangleF = method_9(yAxisInfo);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return yAxisInfo;
					}
				}
			}
			if (Config.FooterLines != null)
			{
				foreach (TitleLineInfo footerLine in Config.FooterLines)
				{
					RectangleF rectangleF = method_9(footerLine);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return footerLine;
					}
				}
			}
			if (Config.Zones != null)
			{
				TimeLineZoneInfoList zones = Config.Zones;
				int num = zones.Count - 1;
				while (num >= 0)
				{
					TimeLineZoneInfo timeLineZoneInfo = zones[num];
					RectangleF rectangleF = new RectangleF(timeLineZoneInfo.Left, timeLineZoneInfo.Top, timeLineZoneInfo.Width, timeLineZoneInfo.Height);
					if (rectangleF.IsEmpty || !rectangleF.Contains(float_8, float_9))
					{
						num--;
						continue;
					}
					return timeLineZoneInfo;
				}
			}
			return null;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public TemperatureDocument Clone()
		{
			TemperatureDocument temperatureDocument = (TemperatureDocument)MemberwiseClone();
			if (temperatureDocumentConfig_0 != null)
			{
				temperatureDocument.temperatureDocumentConfig_0 = temperatureDocumentConfig_0.Clone();
			}
			if (documentDataList_0 != null)
			{
				temperatureDocument.documentDataList_0 = documentDataList_0.Clone();
			}
			if (dctimeLineParameterList_0 != null)
			{
				temperatureDocument.dctimeLineParameterList_0 = dctimeLineParameterList_0.Clone();
			}
			return temperatureDocument;
		}

		internal static bool smethod_3(float float_8)
		{
			return float.IsNaN(float_8) || float_8 == -10000f;
		}

		internal static bool smethod_4(DateTime dateTime_4)
		{
			return dateTime_4 == DateTime.MinValue || dateTime_4 == NullDate;
		}

		/// <summary>
		///       创建测试用的数值
		///       </summary>
		/// <param name="name">数据名称</param>
		/// <param name="minValue">最小值</param>
		/// <param name="maxValue">最大值</param>
		/// <returns>创建的数值</returns>
		public static float GenerateTestValue(string name, float minValue, float maxValue)
		{
			if (random_0.NextDouble() < 0.09)
			{
				return float.NaN;
			}
			return (float)TestValueGenerator.Generate(name, minValue, maxValue);
		}

		/// <summary>
		///       创建测试用的数值
		///       </summary>
		/// <param name="name">数据名称</param>
		/// <param name="minValue">最小值</param>
		/// <param name="maxValue">最大值</param>
		/// <param name="allowNoneData">允许创建空数据</param>
		/// <returns>创建的数值</returns>
		public static float GenerateTestValue(string name, float minValue, float maxValue, bool allowNoneData)
		{
			if (allowNoneData && random_0.NextDouble() < 0.09)
			{
				return float.NaN;
			}
			return (float)TestValueGenerator.Generate(name, minValue, maxValue);
		}

		internal float method_11(float float_8)
		{
			return GraphicsUnitConvert.Convert(float_8, GraphicsUnit.Pixel, GraphicsUnit);
		}

		internal float method_12(float float_8)
		{
			return GraphicsUnitConvert.Convert(float_8, GraphicsUnit, GraphicsUnit.Pixel);
		}

		private void method_13(DCGraphics dcgraphics_0)
		{
			if (LayoutInvalidate)
			{
				LayoutInvalidate = false;
				method_15(dcgraphics_0);
			}
		}

		internal void method_14()
		{
			if (InnerBehaviorMode == Enum16.const_1)
			{
				yaxisInfoList_0 = YAxisInfos;
				return;
			}
			yaxisInfoList_0 = new YAxisInfoList();
			foreach (YAxisInfo yAxisInfo in YAxisInfos)
			{
				if (yAxisInfo.Visible)
				{
					bool flag = false;
					foreach (YAxisInfo yAxisInfo2 in YAxisInfos)
					{
						if (yAxisInfo2.ShadowName == yAxisInfo.Name && !yAxisInfo2.Visible)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						yaxisInfoList_0.Add(yAxisInfo);
					}
				}
			}
		}

		internal float method_15(DCGraphics dcgraphics_0)
		{
			int num = 8;
			if (dcgraphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			lock (this)
			{
				dcgraphics_0.PageUnit = GraphicsUnit;
				titleLineInfoList_0 = null;
				titleLineInfoList_1 = null;
				bool_1 = false;
				float_6 = 0f;
				float tickCountFloat = CountDown.GetTickCountFloat();
				float tickCountFloat2 = CountDown.GetTickCountFloat();
				float num2 = tickCountFloat2;
				Config.CheckDefaultTicks();
				dateTime_1 = NullDate;
				DateTime minDate = NullDate;
				UpdateNumOfPage(out dateTime_1, out minDate);
				tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
				float tickCountFloat3 = CountDown.GetTickCountFloat();
				foreach (DocumentData data in Datas)
				{
					foreach (ValuePoint value in data.Values)
					{
						value.OwnerList = data.Values;
						value.Visible = false;
						value.Left = float.NaN;
						value.Top = float.NaN;
						value.ViewBounds = Rectangle.Empty;
						value.HollowCovertFlag = false;
					}
				}
				method_14();
				foreach (TitleLineInfo runtimeHeaderLine in RuntimeHeaderLines)
				{
					runtimeHeaderLine.Top = 0f;
					runtimeHeaderLine.Height = 0f;
					if (runtimeHeaderLine.ValueType == TitleLineValueType.InDayIndex)
					{
						runtimeHeaderLine.ValueType = TitleLineValueType.GlobalDayIndex;
					}
					List<DateTime> list = new List<DateTime>();
					if (runtimeHeaderLine.ValueType == TitleLineValueType.DayIndex)
					{
						if (!smethod_4(runtimeHeaderLine.StartDate))
						{
							list.Add(runtimeHeaderLine.StartDate);
						}
						else if (!string.IsNullOrEmpty(runtimeHeaderLine.StartDateKeyword))
						{
							foreach (YAxisInfo item in yaxisInfoList_0)
							{
								if (item.Style == YAxisInfoStyle.Text)
								{
									string[] array = new string[1]
									{
										runtimeHeaderLine.StartDateKeyword
									};
									foreach (ValuePoint item2 in method_19(item.Name))
									{
										if (runtimeHeaderLine.StartDateKeyword.IndexOf(",") > 0)
										{
											array = runtimeHeaderLine.StartDateKeyword.Split(',');
										}
										for (int i = 0; i < array.Length; i++)
										{
											if (item2.Text != null && item2.Text.IndexOf(array[i]) >= 0)
											{
												DateTime dateTime = item2.Time.Date.AddDays(1.0);
												if (list.Count == 0 || list[list.Count - 1] != dateTime)
												{
													list.Add(dateTime);
												}
											}
										}
									}
									break;
								}
							}
						}
					}
					else if (runtimeHeaderLine.ValueType == TitleLineValueType.GlobalDayIndex)
					{
						list.Add(minDate);
					}
					if (list.Count > 0)
					{
						runtimeHeaderLine._RuntimeStartDates = list.ToArray();
					}
					else
					{
						runtimeHeaderLine._RuntimeStartDates = null;
					}
				}
				foreach (YAxisInfo item3 in yaxisInfoList_0)
				{
					item3.ShadowInfo = null;
					foreach (ValuePoint item4 in method_19(item3.Name))
					{
						item4.ShadowPoint = null;
						item4.Parent = item3;
					}
				}
				foreach (TitleLineInfo runtimeHeaderLine2 in RuntimeHeaderLines)
				{
					runtimeHeaderLine2.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					foreach (ValuePoint item5 in method_19(runtimeHeaderLine2.Name))
					{
						item5.Parent = runtimeHeaderLine2;
					}
				}
				foreach (TitleLineInfo runtimeFooterLine in RuntimeFooterLines)
				{
					runtimeFooterLine.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					foreach (ValuePoint item6 in method_19(runtimeFooterLine.Name))
					{
						item6.Parent = runtimeFooterLine;
					}
				}
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				tickCountFloat3 = CountDown.GetTickCountFloat();
				yaxisInfoList_1 = new YAxisInfoList();
				foreach (YAxisInfo item7 in yaxisInfoList_0)
				{
					item7.method_0(this);
					if (!string.IsNullOrEmpty(item7.Name))
					{
						bool flag = false;
						foreach (YAxisInfo item8 in yaxisInfoList_0)
						{
							if (item7.Name == item8.ShadowName && item7 != item8)
							{
								float tickCountFloat4 = CountDown.GetTickCountFloat();
								item8.ShadowInfo = item7;
								ValuePointList valuePointList = method_19(item8.Name);
								ValuePointList valuePointList2 = method_19(item7.Name);
								int num3 = 0;
								foreach (ValuePoint item9 in valuePointList)
								{
									for (int j = num3; j < valuePointList2.Count; j++)
									{
										ValuePoint valuePoint = valuePointList2[j];
										if (Math.Abs(item9.Time.Subtract(valuePoint.Time).TotalSeconds) < (double)ShadowPointDetectSeconds)
										{
											item9.ShadowPoint = valuePoint;
											num3 = j;
											break;
										}
									}
								}
								tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							continue;
						}
					}
					if (item7.Style == YAxisInfoStyle.Value && item7.TitleVisible)
					{
						yaxisInfoList_1.Add(item7);
					}
				}
				if (InnerBehaviorMode == Enum16.const_1)
				{
					yaxisInfoList_1 = YAxisInfos;
				}
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				XFontValue xFontValue = method_2();
				foreach (YAxisInfo yAxisInfo in YAxisInfos)
				{
					yAxisInfo.TitleWidth = 0f;
					yAxisInfo.TitleWidth = 0f;
				}
				float num4 = 0f;
				if (yaxisInfoList_1.Count > 0)
				{
					yaxisInfoList_1[0].MergeIntoLeft = false;
				}
				YAxisInfoList yAxisInfoList = new YAxisInfoList();
				foreach (YAxisInfo item10 in yaxisInfoList_1)
				{
					item10.FixTopHeightForPadding = false;
					if (item10.SpecifyTitleWidth == 0f)
					{
						string text = item10.Title;
						if (string.IsNullOrEmpty(text))
						{
							text = "HHHH";
						}
						SizeF sizeF = dcgraphics_0.MeasureString(text, xFontValue);
						if (!string.IsNullOrEmpty(item10.BottomTitle))
						{
							sizeF.Width = Math.Max(val2: dcgraphics_0.MeasureString(item10.BottomTitle, xFontValue).Width, val1: sizeF.Width);
						}
						item10.TitleWidth = sizeF.Width * 1.1f;
					}
					else
					{
						item10.TitleWidth = item10.SpecifyTitleWidth;
					}
					if (item10.MergeIntoLeft)
					{
						YAxisInfo lastInfo = yAxisInfoList.LastInfo;
						lastInfo.FixTopHeightForPadding = true;
						item10.FixTopHeightForPadding = true;
						item10.TitleLeft = lastInfo.TitleLeft;
						float num7 = item10.TitleWidth = (lastInfo.TitleWidth = Math.Max(item10.TitleWidth, lastInfo.TitleWidth));
					}
					else
					{
						item10.TitleLeft = yAxisInfoList.TotalTitleWidth + Left;
					}
					yAxisInfoList.Add(item10);
				}
				num4 = yAxisInfoList.TotalTitleWidth;
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				List<TitleLineInfo> list2 = new List<TitleLineInfo>();
				foreach (TitleLineInfo runtimeHeaderLine3 in RuntimeHeaderLines)
				{
					list2.Add(runtimeHeaderLine3);
				}
				foreach (TitleLineInfo runtimeFooterLine2 in RuntimeFooterLines)
				{
					list2.Add(runtimeFooterLine2);
				}
				float num8 = num4;
				foreach (TitleLineInfo item11 in list2)
				{
					if (item11.SpecifyTitleWidth <= 0f)
					{
						if (!string.IsNullOrEmpty(item11.Title))
						{
							num8 = Math.Max(num8, dcgraphics_0.MeasureString(item11.Title, xFontValue).Width);
						}
					}
					else
					{
						num8 = Math.Max(num8, item11.SpecifyTitleWidth);
					}
				}
				if (num8 > num4)
				{
					float num9 = Left;
					foreach (YAxisInfo item12 in yaxisInfoList_1)
					{
						item12.TitleLeft = num9;
						item12.TitleWidth += (num8 - num4) / (float)yaxisInfoList_1.Count;
						if (!item12.MergeIntoLeft)
						{
							num9 += item12.TitleWidth;
						}
					}
				}
				float_6 = num8;
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				rectangleF_0 = RectangleF.Empty;
				rectangleF_0.X = Left + num8;
				rectangleF_0.Width = Width - num8;
				float num10 = rectangleF_0.Width / (float)RuntimeNumOfDaysInOnePage;
				if (Config.Ticks.Count > 0)
				{
					float_7 = num10 / (float)Config.Ticks.Count;
				}
				else
				{
					float_7 = num10;
				}
				dateTime_0 = minDate.AddDays(RuntimePageIndex * RuntimeNumOfDaysInOnePage);
				dateTime_1 = dateTime_0.AddDays(RuntimeNumOfDaysInOnePage);
				method_22(dateTime_0, dateTime_1, (ViewMode != DocumentViewMode.Timeline) ? (RuntimeNumOfDaysInOnePage * Config.Ticks.Count) : 0);
				float_5 = dcgraphics_0.GetFontHeight(xFontValue) * 1.5f;
				float num11 = 0f;
				foreach (TitleLineInfo runtimeHeaderLine4 in RuntimeHeaderLines)
				{
					method_35(dcgraphics_0, runtimeHeaderLine4, float_5, dateTime_0);
					runtimeHeaderLine4.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					num11 += runtimeHeaderLine4.RuntimeHeight;
				}
				float tickCountFloat5 = CountDown.GetTickCountFloat();
				float num12 = 0f;
				if (ViewMode == DocumentViewMode.Page)
				{
					if (Config.SpecifyTitleHeight > 0f)
					{
						num12 = GraphicsUnitConvert.Convert(Config.SpecifyTitleHeight, GraphicsUnit.Document, dcgraphics_0.PageUnit);
					}
					else
					{
						XFontValue font = method_3();
						num12 = dcgraphics_0.GetFontHeight(font) * 1.1f;
						RectangleF rectangleF = new RectangleF(Left, Top, Width, num12);
					}
				}
				method_16(num12, float_5, dcgraphics_0, xFontValue);
				num12 += float_5;
				tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
				float num13 = 0f;
				foreach (TitleLineInfo runtimeFooterLine3 in RuntimeFooterLines)
				{
					method_35(dcgraphics_0, runtimeFooterLine3, float_5, dateTime_0);
					num13 += runtimeFooterLine3.RuntimeHeight;
				}
				tickCountFloat5 = CountDown.GetTickCountFloat();
				method_5();
				rectangleF_0.Y = Top + num12 + RuntimeHeaderLines.TotalRuntimeHeight;
				rectangleF_0.Height = Height - num11 - num13 - num12;
				float num14 = 0f;
				string text2 = null;
				if (ViewMode == DocumentViewMode.Page)
				{
					if (!string.IsNullOrEmpty(Config.FooterDescription))
					{
						if (Config.FooterDescription.Contains("\\r\\n"))
						{
							int num15 = Config.FooterDescription.Split(new string[1]
							{
								"\\r\\n"
							}, StringSplitOptions.None).Length;
							num14 = float_5 * (float)num15;
						}
						else
						{
							num14 = float_5;
						}
					}
					text2 = Config.PageIndexText;
					if (!string.IsNullOrEmpty(text2))
					{
						num14 += float_5;
						text2 = text2.Replace("[%pageindex%]", Convert.ToString(RuntimePageIndex + 1));
						text2 = text2.Replace("[%pagecount%]", NumOfPages.ToString());
					}
					rectangleF_0.Height -= num14;
				}
				float num16 = Top + num12;
				for (int k = 0; k < RuntimeHeaderLines.Count; k++)
				{
					TitleLineInfo current3 = RuntimeHeaderLines[k];
					current3.Top = num16;
					current3.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					num16 += current3.RuntimeHeight;
				}
				tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
				tickCountFloat5 = CountDown.GetTickCountFloat();
				foreach (YAxisInfo yAxisInfo2 in Config.YAxisInfos)
				{
					yAxisInfo2.bool_13 = false;
				}
				for (int j = 0; j < yaxisInfoList_1.Count; j++)
				{
					YAxisInfo current7 = yaxisInfoList_1[j];
					current7.TitleTop = rectangleF_0.Top;
					current7.TitleHeight = rectangleF_0.Height;
					current7.bool_13 = true;
				}
				tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
				foreach (YAxisInfo item13 in yaxisInfoList_0)
				{
					item13.pointF_0 = new PointF(float.NaN, float.NaN);
				}
				float tickCountFloat6 = CountDown.GetTickCountFloat();
				_ = dcgraphics_0.MeasureString("##", xFontValue, 10000, DrawStringFormatExt.GenericTypographic).Width;
				foreach (YAxisInfo yAxisInfo3 in YAxisInfos)
				{
					if (yAxisInfo3.Style != YAxisInfoStyle.Background)
					{
						method_17(dcgraphics_0, rectangleF_0, yAxisInfo3, yaxisInfoList_0, dateTime_0);
					}
				}
				tickCountFloat6 = CountDown.GetTickCountFloat() - tickCountFloat6;
				float tickCountFloat7 = CountDown.GetTickCountFloat();
				if (RuntimeFooterLines.Count > 0)
				{
					num16 = rectangleF_0.Bottom;
					foreach (TitleLineInfo runtimeFooterLine4 in RuntimeFooterLines)
					{
						runtimeFooterLine4.Top = num16;
						num16 += runtimeFooterLine4.RuntimeHeight;
					}
				}
				tickCountFloat7 = CountDown.GetTickCountFloat() - tickCountFloat7;
				float tickCountFloat8 = CountDown.GetTickCountFloat();
				xFontValue.Dispose();
				tickCountFloat8 = CountDown.GetTickCountFloat() - tickCountFloat8;
				num2 = CountDown.GetTickCountFloat() - num2;
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, null);
				}
				return 0f;
			}
		}

		private void method_16(float float_8, float float_9, DCGraphics dcgraphics_0, XFontValue xfontValue_0)
		{
			rectangleF_1 = RectangleF.Empty;
			if (HeaderLabels == null || HeaderLabels.Count == 0)
			{
				return;
			}
			foreach (HeaderLabelInfo headerLabel in HeaderLabels)
			{
				headerLabel.OwnerDocument = this;
				headerLabel.method_0(dcgraphics_0, xfontValue_0);
				headerLabel.Height = float_9;
			}
			float num;
			if (ViewMode == DocumentViewMode.Timeline || ViewMode == DocumentViewMode.Normal)
			{
				num = Left;
				foreach (HeaderLabelInfo headerLabel2 in HeaderLabels)
				{
					headerLabel2.Left = num;
					headerLabel2.Top = Top + float_8;
					num += headerLabel2.Width + float_9;
				}
				return;
			}
			float num2 = Width;
			foreach (HeaderLabelInfo headerLabel3 in HeaderLabels)
			{
				num2 -= headerLabel3.Width;
			}
			if (HeaderLabels.Count > 1)
			{
				num2 /= (float)(HeaderLabels.Count - 1);
			}
			num = Left;
			foreach (HeaderLabelInfo headerLabel4 in HeaderLabels)
			{
				headerLabel4.Left = num;
				headerLabel4.Top = Top + float_8;
				num += headerLabel4.Width + num2;
			}
		}

		private void method_17(DCGraphics dcgraphics_0, RectangleF rectangleF_2, YAxisInfo yaxisInfo_0, YAxisInfoList yaxisInfoList_2, DateTime dateTime_4)
		{
			int num = 18;
			float tickCountFloat = CountDown.GetTickCountFloat();
			if (yaxisInfo_0.Style == YAxisInfoStyle.Value && !string.IsNullOrEmpty(yaxisInfo_0.HollowCovertTargetName))
			{
				ValuePointList valuePointList = method_19(yaxisInfo_0.Name);
				float tickCountFloat2 = CountDown.GetTickCountFloat();
				YAxisInfo itemByName = yaxisInfoList_2.GetItemByName(yaxisInfo_0.HollowCovertTargetName);
				ValuePointList valuePointList2 = method_19(yaxisInfo_0.HollowCovertTargetName);
				if (itemByName != null && valuePointList2 != null && valuePointList2.Count > 0)
				{
					float num2 = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, GraphicsUnit);
					foreach (ValuePoint item in valuePointList)
					{
						item.HollowCovertFlag = false;
						float num3 = yaxisInfo_0.method_3(this, rectangleF_2, item.Value);
						if (!float.IsNaN(num3))
						{
							ValuePoint nearestPoint = valuePointList2.GetNearestPoint(item.Time, 1000f);
							if (nearestPoint != null)
							{
								float num4 = itemByName.method_3(this, rectangleF_2, nearestPoint.Value);
								if (!float.IsNaN(num4) && Math.Abs(num4 - num3) < num2)
								{
									item.HollowCovertFlag = true;
								}
							}
						}
					}
				}
				tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
			}
			XFontValue font = method_1(yaxisInfo_0, bool_3: true);
			float width = dcgraphics_0.MeasureString("##", font, 10000, DrawStringFormatExt.GenericTypographic).Width;
			ValuePointList valuePointList3 = method_19(yaxisInfo_0.Name);
			CountDown.GetTickCountFloat();
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			float tickCountFloat3 = CountDown.GetTickCountFloat();
			float num8 = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			if (ViewMode == DocumentViewMode.Timeline)
			{
				num5 = 0;
				num6 = valuePointList3.Count - 1;
			}
			else
			{
				int count = valuePointList3.Count;
				int num9 = 0;
				for (int i = 0; i < count; i++)
				{
					num9++;
					ValuePoint current = valuePointList3[i];
					if (current.Time < dateTime_4)
					{
						current.Visible = false;
						num5 = i + 1;
						continue;
					}
					current.Visible = true;
					if (!(current.Time > class159_0.method_4()))
					{
						if (num7 < 0)
						{
							num7 = i;
						}
						if (num5 < 0)
						{
							num5 = Math.Max(i - 1, 0);
						}
						continue;
					}
					current.Visible = false;
					if (num5 >= 0)
					{
						if (num6 < 0)
						{
							num6 = ((!(current.Time > class159_0.method_2())) ? i : Math.Max(0, i - 1));
						}
						if (num5 < 0)
						{
							num5 = Math.Max(0, num6 - 1);
						}
					}
					break;
				}
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				tickCountFloat3 = CountDown.GetTickCountFloat();
				if (num5 >= 0 || num6 >= 0)
				{
					if (num5 < 0)
					{
						num5 = 0;
					}
					if (num6 < 0)
					{
						num6 = valuePointList3.Count - 1;
					}
					if (yaxisInfo_0.Style != YAxisInfoStyle.Text)
					{
						num5 = Math.Max(num5 - 10, 0);
						num6 = Math.Min(num6 + 10, valuePointList3.Count - 1);
					}
				}
			}
			Dictionary<float, float> dictionary = new Dictionary<float, float>();
			float num10 = 0f;
			for (int i = num5; i >= 0 && i <= num6; i++)
			{
				ValuePoint current = valuePointList3[i];
				_ = (current.Time.Date - dateTime_4).Days;
				Class158 class158_ = null;
				float num12 = current.Left = rectangleF_2.Left + class159_0.method_11(current.Time, ref class158_);
				if (yaxisInfo_0.Style == YAxisInfoStyle.Text)
				{
					Class158 class158_2 = null;
					num12 = class159_0.method_17(rectangleF_2, current.Time, ref class158_2);
					num12 = Math.Max(num12, rectangleF_0.Left + method_11(2f));
					if (current.Left > rectangleF_2.Right - 2f)
					{
						break;
					}
					current.Visible = true;
					float num13 = (float)GraphicsUnitConvert.Convert(1.0, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
					current.Left = num12;
					if (smethod_3(current.Value))
					{
						current.Top = rectangleF_2.Top + rectangleF_2.Height * Config.DataGridTopPadding + 3f * num13;
					}
					else
					{
						current.Top = yaxisInfo_0.method_3(this, rectangleF_2, current.Value);
					}
					foreach (float key in dictionary.Keys)
					{
						float num14 = key;
						float num15 = Math.Abs(num14 - current.Left);
						if (num15 < width / 2f)
						{
							current.Top = Math.Max(dictionary[num14] + 3f, current.Top);
							current.Left = num14;
							break;
						}
					}
					current.Height = 0f;
					current.Width = width;
					float num16 = current.Top;
					if (current.ImageValue != null && Config.ShowIcon)
					{
						current.Height = (float)ImagePixelHeight * num13;
						num16 += current.Height + num13 * 3f;
					}
					if (!string.IsNullOrEmpty(current.Text))
					{
						XFontValue font2 = method_1(yaxisInfo_0, bool_3: true);
						SizeF sizeF = dcgraphics_0.MeasureString(current.Text, font2, (int)width, StringFormatForYAxisLabelValue);
						if (yaxisInfo_0.MaxTextDisplayLength > 0f && sizeF.Height > yaxisInfo_0.MaxTextDisplayLength)
						{
							sizeF.Height = yaxisInfo_0.MaxTextDisplayLength;
						}
						current.Height += sizeF.Height;
						RectangleF rectangleF = new RectangleF(current.Left, num16, current.Width, sizeF.Height);
						if (!dictionary.ContainsKey(current.Left))
						{
							rectangleF.X = Math.Max(rectangleF.Left, num10 + 4f);
							current.Left = rectangleF.X;
							num10 = Math.Max(num10, rectangleF.Right);
						}
						dictionary[current.Left] = rectangleF.Bottom;
						float bottom = rectangleF_2.Bottom;
						if (rectangleF.Bottom > bottom - 2f)
						{
							rectangleF.Height = bottom - rectangleF.Top - 2f;
						}
						current.ViewBounds = new RectangleF(current.Left, current.Top, current.Width, current.Height);
						if (!(rectangleF.Height <= 0f))
						{
						}
					}
					continue;
				}
				if (class158_ != null && class158_.timeLineZoneInfo_0 != null && !class158_.timeLineZoneInfo_0.IsExpanded && !float.IsNaN(yaxisInfo_0.pointF_0.X))
				{
					float num15 = num12 - yaxisInfo_0.pointF_0.X;
					if (num15 < num8)
					{
						current.Visible = false;
						continue;
					}
				}
				current.Visible = true;
				float num3 = current.Top = yaxisInfo_0.method_3(this, rectangleF_2, current.Value);
				if (float.IsNaN(num3))
				{
					yaxisInfo_0.pointF_0 = new PointF(float.NaN, float.NaN);
					current.Left = float.NaN;
					current.Top = float.NaN;
				}
				else
				{
					current.OutofRangeFlag = yaxisInfo_0.OutofRangeFlag;
					yaxisInfo_0.pointF_0 = new PointF(num12, num3);
					yaxisInfo_0.valuePoint_0 = current;
				}
			}
			tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		/// <summary>
		///       清除数据
		///       </summary>
		public void ClearData()
		{
			Datas.Clear();
		}

		public void method_18()
		{
			foreach (DocumentData data in Datas)
			{
				data.Values.SortInvalidate = true;
			}
		}

		internal ValuePointList method_19(string string_1)
		{
			return Datas.GetValuesByName(string_1);
		}

		public TitleLineInfo method_20(string string_1)
		{
			TitleLineInfo itemByName = HeaderLines.GetItemByName(string_1);
			if (itemByName == null)
			{
				itemByName = FooterLines.GetItemByName(string_1);
			}
			return itemByName;
		}

		/// <summary>
		///       根据序号设置页眉标题文本
		///       </summary>
		/// <param name="index">从0开始计算的序号</param>
		/// <param name="text">文本</param>
		[ComVisible(true)]
		public void SetHeaderLableValueByIndex(int index, string text)
		{
			if (index >= 0 && index < HeaderLabels.Count)
			{
				HeaderLabels[index].Value = text;
			}
		}

		/// <summary>
		///       设置页眉标题文本
		///       </summary>
		/// <param name="title">标题</param>
		/// <param name="text">文本</param>
		[Obsolete("请使用SetParameterValue(name,value)")]
		public void SetHeaderLableValue(string title, string text)
		{
			foreach (HeaderLabelInfo headerLabel in HeaderLabels)
			{
				if (headerLabel.Title == title)
				{
					headerLabel.Value = text;
					break;
				}
			}
		}

		/// <summary>
		///       设置文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <param name="Value">参数值</param>
		[ComVisible(true)]
		public void SetParameterValue(string name, string Value)
		{
			Parameters.SetValue(name, Value);
		}

		/// <summary>
		///       获得文档参数值
		///       </summary>
		/// <param name="name">参数名</param>
		/// <returns>参数值</returns>
		[ComVisible(true)]
		public string GetParameterValue(string name)
		{
			return Parameters.GetValue(name);
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="Value">数值</param>
		public void AddPointByTimeValue(string name, DateTime dateTime_4, float Value)
		{
			ValuePointList valuePointList = method_19(name);
			if (valuePointList != null)
			{
				lock (this)
				{
					valuePointList.AddByTimeValue(dateTime_4, Value);
				}
			}
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列的名称</param>
		/// <param name="point">数据点对象</param>
		public void AddPoint(string name, ValuePoint point)
		{
			int num = 6;
			if (point == null)
			{
				throw new ArgumentNullException("point");
			}
			ValuePointList valuePointList = method_19(name);
			if (valuePointList != null)
			{
				lock (this)
				{
					valuePointList.Add(point);
					valuePointList.SortInvalidate = true;
				}
			}
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">数值</param>
		public void AddPointByTimeText(string name, DateTime dateTime_4, string text)
		{
			ValuePointList valuePointList = method_19(name);
			if (valuePointList != null)
			{
				lock (this)
				{
					valuePointList.AddByTimeText(dateTime_4, text);
				}
			}
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">文本</param>
		/// <param name="Value">数值</param>
		public void AddPointByTimeTextValue(string name, DateTime dateTime_4, string text, float Value)
		{
			ValuePointList valuePointList = method_19(name);
			if (valuePointList != null)
			{
				lock (this)
				{
					valuePointList.AddByTimeTextValue(dateTime_4, text, Value);
				}
			}
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="text">文本</param>
		/// <param name="htmlColorValue">HTML格式的颜色值</param>
		public void AddPointByTimeTextColor(string name, DateTime dateTime_4, string text, string htmlColorValue)
		{
			ValuePointList valuePointList = method_19(name);
			if (valuePointList != null)
			{
				ValuePoint valuePoint = new ValuePoint();
				valuePoint.Time = dateTime_4;
				valuePoint.Text = text;
				valuePoint.ColorValue = htmlColorValue;
				lock (this)
				{
					valuePointList.Add(valuePoint);
				}
			}
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列名称</param>
		/// <param name="dtm">数据时间</param>
		/// <param name="Value">数值</param>
		/// <param name="landernValue">灯笼数值</param>
		public void AddPointByTimeValueLandernValue(string name, DateTime dateTime_4, float Value, float landernValue)
		{
			ValuePointList valuePointList = method_19(name);
			if (valuePointList != null)
			{
				lock (this)
				{
					valuePointList.AddByTimeValueLandernValue(dateTime_4, Value, landernValue);
				}
			}
		}

		/// <summary>
		///       设置计算天数使用的开始日期
		///       </summary>
		/// <param name="name">数据行的名称</param>
		/// <param name="startDate">开始日期</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		public bool SetStartDateForDayIndex(string name, DateTime startDate)
		{
			TitleLineInfo titleLineInfo = method_20(name);
			if (titleLineInfo != null)
			{
				titleLineInfo.StartDate = startDate;
				return true;
			}
			return false;
		}

		/// <summary>
		///       修改指定时间区域的范围
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="startTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>操作是否修改了数据</returns>
		public bool SetTimeLineZoneRange(string zoneName, DateTime startTime, DateTime endTime)
		{
			TimeLineZoneInfo byName = Config.Zones.GetByName(zoneName);
			if (byName != null)
			{
				byName.StartTime = startTime;
				byName.EndTime = endTime;
				return true;
			}
			return false;
		}

		/// <summary>
		///       设置指定时间区域中的数据点颜色
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="valueName">数据序列名称</param>
		/// <param name="colorValue">颜色值，比如"#ff00ff"</param>
		/// <returns>操作修改的数据点个数</returns>
		public int SetSymbolStyleByTimeZone(string zoneName, string valueName, string colorValue)
		{
			int num = 0;
			TimeLineZoneInfo byName = Config.Zones.GetByName(zoneName);
			if (byName != null)
			{
				ValuePointList valuePointList = method_19(valueName);
				if (valuePointList != null && valuePointList.Count > 0)
				{
					foreach (ValuePoint item in valuePointList)
					{
						if (byName.Contains(item.Time))
						{
							item.ColorValue = colorValue;
							num++;
						}
					}
				}
			}
			return num;
		}

		/// <summary>
		///       设置指定时间区域中的数据点样式
		///       </summary>
		/// <param name="zoneName">时间区域名称</param>
		/// <param name="valueName">数据序列名称</param>
		/// <param name="style">新的数据点图标样式</param>
		/// <returns>操作修改的数据点个数</returns>
		public int SetSymbolStyleByTimeZone(string zoneName, string valueName, ValuePointSymbolStyle style)
		{
			int num = 0;
			TimeLineZoneInfo byName = Config.Zones.GetByName(zoneName);
			if (byName != null)
			{
				ValuePointList valuePointList = method_19(valueName);
				if (valuePointList != null && valuePointList.Count > 0)
				{
					foreach (ValuePoint item in valuePointList)
					{
						if (byName.Contains(item.Time))
						{
							item.SpecifySymbolStyle = style;
							num++;
						}
					}
				}
			}
			return num;
		}

		internal ValuePointList method_21()
		{
			lock (this)
			{
				ValuePointList valuePointList = new ValuePointList();
				foreach (YAxisInfo yAxisInfo in YAxisInfos)
				{
					if (yAxisInfo.Visible)
					{
						valuePointList.AddRange(method_19(yAxisInfo.Name));
					}
				}
				foreach (TitleLineInfo headerLine in HeaderLines)
				{
					if (headerLine.ValueType == TitleLineValueType.Data)
					{
						valuePointList.AddRange(method_19(headerLine.Name));
					}
				}
				foreach (TitleLineInfo footerLine in FooterLines)
				{
					if (footerLine.ValueType == TitleLineValueType.Data)
					{
						valuePointList.AddRange(method_19(footerLine.Name));
					}
				}
				return valuePointList;
			}
		}

		/// <summary>
		///       更新文档总页数
		///       </summary>
		public void UpdateNumOfPage()
		{
			DateTime maxDate = DateTime.MinValue;
			DateTime minDate = DateTime.MinValue;
			UpdateNumOfPage(out maxDate, out minDate);
		}

		private void method_22(DateTime dateTime_4, DateTime dateTime_5, int int_6)
		{
			float tickCountFloat = CountDown.GetTickCountFloat();
			if (Config.Zones != null)
			{
				Config.Zones.RefreshState();
			}
			class159_0 = new Class159();
			class159_0.method_1(dateTime_4);
			class159_0.method_3(dateTime_5);
			class159_0.dctimeUnit_0 = Config.TickUnit;
			Config.CheckDefaultTicks();
			class159_0.method_14(0, dateTime_4, dateTime_5, Config.Ticks, null);
			if (Config.Zones != null && Config.Zones.Count > 0)
			{
				foreach (TimeLineZoneInfo zone in Config.Zones)
				{
					bool flag = false;
					for (TimeLineZoneInfo parentZone = zone.ParentZone; parentZone != null; parentZone = parentZone.ParentZone)
					{
						if (!parentZone.IsExpanded)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						DateTime t = dateTime_4;
						if (!smethod_4(zone.StartTime))
						{
							t = zone.StartTime;
						}
						int num = -1;
						for (int i = 0; i < class159_0.Count; i++)
						{
							if (class159_0[i].dateTime_1 >= t)
							{
								num = i;
								break;
							}
						}
						DateTime t2 = dateTime_5;
						if (!smethod_4(zone.EndTime))
						{
							t2 = zone.EndTime;
						}
						int num2 = -1;
						for (int i = num; i < class159_0.Count; i++)
						{
							try
							{
								Class158 @class = class159_0[i];
								if (@class.dateTime_1 > t2)
								{
									num2 = i;
									break;
								}
							}
							catch
							{
							}
						}
						if (num >= 0 || num2 >= 0)
						{
							if (num == -1)
							{
								num = 0;
							}
							if (num2 == -1)
							{
								num2 = class159_0.Count;
							}
							if (num2 - num > 1)
							{
								class159_0.RemoveRange(num + 1, num2 - num - 1);
							}
							class159_0.method_14(num + 1, t, t2, zone.Ticks, zone);
						}
					}
				}
			}
			if (int_6 > 0 && int_6 < class159_0.Count)
			{
				class159_0.RemoveRange(int_6, class159_0.Count - int_6);
			}
			for (int i = 0; i < class159_0.Count; i++)
			{
				class159_0[i].int_0 = i;
			}
			DateTime t3 = class159_0[0].dateTime_0.Date.AddDays(-1.0);
			foreach (Class158 item in class159_0)
			{
				if (item.dateTime_0.Date > t3)
				{
					item.bool_0 = true;
					t3 = item.dateTime_0.Date;
				}
				else
				{
					item.bool_0 = false;
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		/// <summary>
		///       更新文档的总页数
		///       </summary>
		/// <param name="maxDate">输出的数据最大日期</param>
		/// <param name="minDate">输出的数据最小日期</param>
		public void UpdateNumOfPage(out DateTime maxDate, out DateTime minDate)
		{
			maxDate = NullDate;
			minDate = NullDate;
			dateTime_3 = NullDate;
			lock (this)
			{
				foreach (DocumentData data in Datas)
				{
					ValuePointList values = data.Values;
					if (values.Count > 0)
					{
						values.CheckSortInvalidate();
						if (maxDate == NullDate || maxDate < values.MaxDate.Date)
						{
							maxDate = values.MaxDate.Date;
						}
						if (minDate == NullDate || minDate > values.MinDate.Date)
						{
							minDate = values.MinDate.Date;
						}
						if (dateTime_3 == NullDate || dateTime_3 < values.MaxDate)
						{
							dateTime_3 = values.MaxDate;
						}
					}
				}
				if (ViewMode == DocumentViewMode.Timeline)
				{
					maxDate = maxDate.AddDays(Config.ExtendDaysForTimeLine);
				}
			}
			if (!string.IsNullOrEmpty(Config.SpecifyStartDate))
			{
				DateTime result = DateTime.MinValue;
				if (DateTime.TryParse(Config.SpecifyStartDate, out result))
				{
					minDate = result;
				}
			}
			if (!string.IsNullOrEmpty(Config.SpecifyEndDate))
			{
				DateTime result = DateTime.MinValue;
				if (DateTime.TryParse(Config.SpecifyEndDate, out result))
				{
					maxDate = result;
				}
			}
			if (Config.Zones != null)
			{
				foreach (TimeLineZoneInfo zone in Config.Zones)
				{
					if (!smethod_4(zone.StartTime) && minDate > zone.StartTime)
					{
						minDate = zone.StartTime;
					}
					if (!smethod_4(zone.EndTime) && maxDate < zone.EndTime)
					{
						maxDate = zone.EndTime;
					}
				}
			}
			if (maxDate != NullDate)
			{
				maxDate = maxDate.AddDays(1.0);
			}
			if (maxDate != NullDate)
			{
				TimeSpan timeSpan = maxDate - minDate;
				int_5 = timeSpan.Days;
				int_4 = (int)Math.Ceiling((double)timeSpan.Days / (double)RuntimeNumOfDaysInOnePage);
				if (int_4 == 0)
				{
					int_4 = 1;
				}
				if (PageIndex >= NumOfPages)
				{
					PageIndex = NumOfPages - 1;
				}
				if (PageIndex < 0)
				{
					PageIndex = 0;
				}
			}
			else
			{
				maxDate = DateTime.Today;
				minDate = maxDate.AddDays(-NumOfDaysInOnePage);
				int_4 = 1;
				PageIndex = 0;
			}
		}

		public void method_23(IDbConnection idbConnection_0)
		{
			int num = 4;
			if (idbConnection_0 == null)
			{
				throw new ArgumentNullException("conn");
			}
			if (idbConnection_0.State != ConnectionState.Open)
			{
				idbConnection_0.Open();
			}
			int num2 = 0;
			using (IDbCommand dbCommand = idbConnection_0.CreateCommand())
			{
				dbCommand.Parameters.Clear();
				if (SQLParameters.Count > 0)
				{
					foreach (string key in SQLParameters.Keys)
					{
						IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
						dbDataParameter.ParameterName = key;
						dbDataParameter.Value = SQLParameters[key];
						dbCommand.Parameters.Add(dbDataParameter);
					}
				}
				if (!string.IsNullOrEmpty(Config.SQLTextForHeaderLabel))
				{
					foreach (HeaderLabelInfo headerLabel in Config.HeaderLabels)
					{
						if (!string.IsNullOrEmpty(headerLabel.ValueFieldName))
						{
							headerLabel.Value = null;
						}
					}
					dbCommand.CommandText = Config.SQLTextForHeaderLabel;
					IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleRow);
					if (dataReader.Read())
					{
						foreach (HeaderLabelInfo headerLabel2 in Config.HeaderLabels)
						{
							if (!string.IsNullOrEmpty(headerLabel2.ValueFieldName))
							{
								int ordinal = dataReader.GetOrdinal(headerLabel2.ValueFieldName);
								if (ordinal >= 0 && !dataReader.IsDBNull(ordinal))
								{
									headerLabel2.Value = Convert.ToString(dataReader.GetValue(ordinal));
									num2++;
								}
							}
						}
					}
					dataReader.Close();
				}
				Dictionary<ValuePointDataSourceInfo, ValuePointList> dictionary = new Dictionary<ValuePointDataSourceInfo, ValuePointList>();
				foreach (TitleLineInfo headerLine in Config.HeaderLines)
				{
					if (headerLine.DataSource != null)
					{
						dictionary[headerLine.DataSource] = Datas.GetValuesByName(headerLine.Name);
					}
				}
				foreach (TitleLineInfo footerLine in Config.FooterLines)
				{
					if (footerLine.DataSource != null)
					{
						dictionary[footerLine.DataSource] = Datas.GetValuesByName(footerLine.Name);
					}
				}
				foreach (YAxisInfo yAxisInfo in Config.YAxisInfos)
				{
					if (yAxisInfo.DataSource != null)
					{
						dictionary[yAxisInfo.DataSource] = Datas.GetValuesByName(yAxisInfo.Name);
					}
				}
				foreach (ValuePointDataSourceInfo key2 in dictionary.Keys)
				{
					if (!string.IsNullOrEmpty(key2.SQLText))
					{
						ValuePointList valuePointList = dictionary[key2];
						valuePointList.Clear();
						dbCommand.CommandText = key2.SQLText;
						IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
						int num3 = key2.Fill(dataReader, valuePointList);
						dataReader.Close();
						num2 += num3;
					}
				}
			}
		}

		/// <summary>
		///       刷新数据源绑定
		///       </summary>
		public void RefreshDataSource()
		{
			lock (this)
			{
				foreach (HeaderLabelInfo headerLabel in HeaderLabels)
				{
					if (!string.IsNullOrEmpty(headerLabel.DataSourceName))
					{
						object obj = DataSources[headerLabel.DataSourceName];
						if (obj != null)
						{
							if (string.IsNullOrEmpty(headerLabel.ValueFieldName))
							{
								headerLabel.Value = Convert.ToString(obj);
							}
							else
							{
								GClass318 gClass = new GClass318(obj);
								headerLabel.Value = Convert.ToString(gClass.method_2(headerLabel.ValueFieldName));
							}
						}
					}
				}
				foreach (YAxisInfo yAxisInfo in YAxisInfos)
				{
					if (!string.IsNullOrEmpty(yAxisInfo.DataSourceName))
					{
						object obj = DataSources[yAxisInfo.DataSourceName];
						if (obj != null)
						{
							ValuePointList valuesByName = Datas.GetValuesByName(yAxisInfo.Name);
							valuesByName.BindingDataSource(obj, yAxisInfo.TimeFieldName, yAxisInfo.ValueFieldName, yAxisInfo.LanternValueFieldName, yAxisInfo.Style == YAxisInfoStyle.Text);
							valuesByName.SortByTime();
						}
					}
				}
				foreach (TitleLineInfo footerLine in FooterLines)
				{
					if (!string.IsNullOrEmpty(footerLine.DataSourceName))
					{
						object obj = DataSources[footerLine.DataSourceName];
						if (obj != null)
						{
							ValuePointList valuesByName = Datas.GetValuesByName(footerLine.Name);
							valuesByName.BindingDataSource(obj, footerLine.TimeFieldName, footerLine.ValueFieldName, null, textMode: true);
							valuesByName.SortByTime();
						}
					}
				}
				foreach (TitleLineInfo headerLine in HeaderLines)
				{
					if (!string.IsNullOrEmpty(headerLine.DataSourceName))
					{
						object obj = DataSources[headerLine.DataSourceName];
						if (obj != null)
						{
							ValuePointList valuesByName = Datas.GetValuesByName(headerLine.Name);
							valuesByName.BindingDataSource(obj, headerLine.TimeFieldName, headerLine.ValueFieldName, null, textMode: true);
							valuesByName.SortByTime();
						}
					}
				}
			}
		}

		private Color method_24(Color color_1)
		{
			if (PrintingMode && Config.BothBlackWhenPrint)
			{
				return Color.Black;
			}
			return color_1;
		}

		private float method_25(float float_8)
		{
			if (PrintingMode)
			{
				return float_8 * Config.LineWidthZoomRateWhenPrint;
			}
			return float_8;
		}

		private bool method_26(ValuePoint valuePoint_1)
		{
			if (Config.LinkVisualStyle == DocumentLinkVisualStyle.None)
			{
				return false;
			}
			if (string.IsNullOrEmpty(valuePoint_1.Link))
			{
				return false;
			}
			if (Config.LinkVisualStyle == DocumentLinkVisualStyle.Hover)
			{
				return MouseHoverValuePoint == valuePoint_1;
			}
			if (Config.LinkVisualStyle == DocumentLinkVisualStyle.Always)
			{
				return true;
			}
			return false;
		}

		private float method_27(RectangleF rectangleF_2, float float_8, YAxisInfo yaxisInfo_0)
		{
			if (yaxisInfo_0 == null)
			{
				return rectangleF_2.Top + rectangleF_2.Height * Config.DataGridTopPadding + rectangleF_2.Height * (1f - Config.DataGridTopPadding - Config.DataGridBottomPadding) * float_8;
			}
			return rectangleF_2.Top + rectangleF_2.Height * yaxisInfo_0.RuntimeTopPadding + rectangleF_2.Height * (1f - yaxisInfo_0.RuntimeTopPadding - yaxisInfo_0.RuntimeBottomPadding) * float_8;
		}

		private void method_28(float float_8)
		{
		}

		public float method_29(DCGraphics dcgraphics_0, RectangleF rectangleF_2, GEnum22 genum22_0)
		{
			int num = 19;
			if (dcgraphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			method_13(dcgraphics_0);
			lock (this)
			{
				dcgraphics_0.PageUnit = GraphicsUnit;
				dcgraphics_0.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				dictionary_1 = new Dictionary<ValuePoint, RectangleF>();
				float tickCountFloat = CountDown.GetTickCountFloat();
				float tickCountFloat2 = CountDown.GetTickCountFloat();
				rectangleF_2.Inflate(2f, 2f);
				DateTime dateTime_ = dateTime_1;
				tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
				float tickCountFloat3 = CountDown.GetTickCountFloat();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				XFontValue xFontValue = method_2();
				DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				DateTime dateTime_2 = dateTime_0;
				float num2 = dcgraphics_0.GetFontHeight(xFontValue) * 1.5f;
				float num3 = 0f;
				foreach (TitleLineInfo runtimeHeaderLine in RuntimeHeaderLines)
				{
					method_35(dcgraphics_0, runtimeHeaderLine, num2, dateTime_2);
					runtimeHeaderLine.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					num3 += runtimeHeaderLine.RuntimeHeight;
				}
				float tickCountFloat4 = CountDown.GetTickCountFloat();
				float num4 = 0f;
				if (ViewMode == DocumentViewMode.Page)
				{
					XFontValue font = method_3();
					num4 = dcgraphics_0.GetFontHeight(font) * 1.1f;
					if (Config.SpecifyTitleHeight > 0f)
					{
						num4 = GraphicsUnitConvert.Convert(Config.SpecifyTitleHeight, GraphicsUnit.Document, dcgraphics_0.PageUnit);
					}
					RectangleF rect = new RectangleF(Left, Top, Width, num4);
					if (!string.IsNullOrEmpty(Title) && (rectangleF_2.IsEmpty || rectangleF_2.IntersectsWith(rect)))
					{
						using (DrawStringFormatExt drawStringFormatExt2 = DrawStringFormatExt.GenericTypographic.Clone())
						{
							drawStringFormatExt2.Alignment = StringAlignment.Center;
							drawStringFormatExt2.LineAlignment = StringAlignment.Near;
							drawStringFormatExt2.FormatFlags = StringFormatFlags.NoWrap;
							dcgraphics_0.DrawString(Title, font, RuntimeForeColor, rect, drawStringFormatExt2);
						}
					}
				}
				method_46(num4, num2, dcgraphics_0, rectangleF_2, xFontValue);
				num4 += num2;
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				tickCountFloat4 = CountDown.GetTickCountFloat();
				float num5 = 0f;
				string text = null;
				if (ViewMode == DocumentViewMode.Page)
				{
					if (!string.IsNullOrEmpty(Config.FooterDescription))
					{
						if (Config.FooterDescription.Contains("\\r\\n"))
						{
							int num6 = Config.FooterDescription.Split(new string[1]
							{
								"\\r\\n"
							}, StringSplitOptions.None).Length;
							num5 = float_5 * (float)num6;
						}
						else
						{
							num5 = float_5;
						}
					}
					text = Config.PageIndexText;
					if (!string.IsNullOrEmpty(text))
					{
						num5 += num2;
						text = text.Replace("[%pageindex%]", Convert.ToString(RuntimePageIndex + 1));
						text = text.Replace("[%pagecount%]", NumOfPages.ToString());
					}
				}
				float num7 = Top + num4;
				for (int i = 0; i < RuntimeHeaderLines.Count; i++)
				{
					TitleLineInfo current = RuntimeHeaderLines[i];
					method_36(current, rectangleF_0, dcgraphics_0, rectangleF_2, float_6, genum22_0, dateTime_2, dateTime_);
					num7 += current.RuntimeHeight;
				}
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				tickCountFloat4 = CountDown.GetTickCountFloat();
				foreach (YAxisInfo yAxisInfo3 in Config.YAxisInfos)
				{
					yAxisInfo3.bool_13 = false;
				}
				YAxisInfo yAxisInfo = null;
				YAxisInfo yAxisInfo2 = null;
				for (int j = 0; j < yaxisInfoList_1.Count; j++)
				{
					YAxisInfo current2 = yaxisInfoList_1[j];
					if (j < yaxisInfoList_1.Count - 1)
					{
						yAxisInfo2 = yaxisInfoList_1[j + 1];
					}
					XFontValue xFontValue2 = xFontValue.Clone();
					if (current2.Selected)
					{
						xFontValue2.Bold = true;
					}
					if (current2.FixTopHeightForPadding)
					{
						float float_ = current2.TopPadding;
						if (smethod_3(float_))
						{
							float_ = 0f;
						}
						if (smethod_3(float_))
						{
							float_ = 0f;
						}
						float num8 = current2.BottomPadding;
						if (smethod_3(num8))
						{
							num8 = 0f;
						}
						if (smethod_3(num8))
						{
							num8 = 0f;
						}
						float titleTop = rectangleF_0.Top;
						float bottom = rectangleF_0.Bottom;
						if (!current2.MergeIntoLeft)
						{
							titleTop = rectangleF_0.Top;
						}
						if (yAxisInfo == null)
						{
							bottom = rectangleF_0.Bottom - rectangleF_0.Height * num8;
						}
						else
						{
							if (current2.MergeIntoLeft)
							{
								titleTop = yAxisInfo.TitleBottom;
							}
							bottom = rectangleF_0.Bottom - rectangleF_0.Height * num8;
						}
						if (!(yAxisInfo2?.MergeIntoLeft ?? false))
						{
							bottom = rectangleF_0.Bottom;
						}
						current2.TitleTop = titleTop;
						current2.TitleHeight = bottom - current2.TitleTop;
					}
					else
					{
						current2.TitleTop = rectangleF_0.Top;
						current2.TitleHeight = rectangleF_0.Height;
					}
					yAxisInfo = current2;
					current2.bool_13 = true;
					RectangleF rect2 = new RectangleF(current2.TitleLeft, current2.TitleTop + (float)GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), current2.TitleWidth, num2);
					Color color = current2.TitleBackColor;
					if (!current2.ValueVisible)
					{
						color = current2.HiddenValueTitleBackColor;
					}
					if (color.A != 0)
					{
						dcgraphics_0.FillRectangle(color, current2.TitleLeft + 3f, current2.TitleTop + 3f, current2.TitleWidth - 6f, current2.TitleHeight - 6f);
					}
					if (!string.IsNullOrEmpty(current2.Title))
					{
						using (DrawStringFormatExt drawStringFormatExt3 = new DrawStringFormatExt(drawStringFormatExt))
						{
							if (current2.SpecifyTitleWidth > 0f)
							{
								drawStringFormatExt3.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
							}
							drawStringFormatExt3.Alignment = StringAlignment.Center;
							drawStringFormatExt3.LineAlignment = StringAlignment.Near;
							rect2.Height = dcgraphics_0.MeasureString(current2.Title, xFontValue2, (int)rect2.Width, drawStringFormatExt3).Height * 1.05f;
							dcgraphics_0.DrawString(current2.Title, xFontValue2, method_24(current2.TitleColor), rect2, drawStringFormatExt3);
						}
					}
					rect2.Offset(0f, rect2.Height);
					if (current2.ShowLegendInRule)
					{
						method_54(dcgraphics_0, rectangleF_2, rect2.Left + rect2.Width / 2f, rect2.Top + GraphicsUnitConvert.Convert(SymbolSize, GraphicsUnit.Document, dcgraphics_0.PageUnit) / 2f, current2.SymbolStyle, current2.CharacterForCharSymbolStyle, current2.SymbolColor, null, float.NaN, bool_3: false);
					}
					if (!string.IsNullOrEmpty(current2.BottomTitle))
					{
						using (DrawStringFormatExt drawStringFormatExt3 = new DrawStringFormatExt(drawStringFormatExt))
						{
							if (current2.SpecifyTitleWidth > 0f)
							{
								drawStringFormatExt3.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
							}
							drawStringFormatExt3.Alignment = StringAlignment.Center;
							drawStringFormatExt3.LineAlignment = StringAlignment.Far;
							dcgraphics_0.DrawString(rect: new RectangleF(current2.TitleLeft, current2.TitleBottom - num2, current2.TitleWidth, num2), string_0: current2.BottomTitle, font: xFontValue2, color_0: method_24(current2.TitleColor), format: drawStringFormatExt3);
						}
					}
					int num9 = current2.YSplitNum;
					if (current2.HasScales)
					{
						num9 = current2.Scales.Count - 1;
						current2.Scales.SortByValue();
						current2.Scales.Reverse();
					}
					for (int k = 0; k <= num9; k++)
					{
						RectangleF rect4 = new RectangleF(current2.TitleLeft, method_27(rectangleF_0, (float)k / (float)num9, current2), current2.TitleWidth, num2);
						float num10 = current2.MaxValue - (current2.MaxValue - current2.MinValue) * (float)k / (float)num9;
						string value = num10.ToString();
						if (!string.IsNullOrEmpty(current2.TitleValueDispalyFormat))
						{
							value = num10.ToString(current2.TitleValueDispalyFormat);
						}
						if (current2.HasScales)
						{
							YAxisScaleInfo yAxisScaleInfo = current2.Scales[k];
							num10 = yAxisScaleInfo.Value;
							rect4.Y = method_27(rectangleF_0, 1f - yAxisScaleInfo.ScaleRate, current2);
							value = (string.IsNullOrEmpty(yAxisScaleInfo.Text) ? num10.ToString() : yAxisScaleInfo.Text);
						}
						if (current2.Style != 0)
						{
							value = null;
						}
						if (k == 0)
						{
							if (current2.RuntimeTopPadding <= 0f)
							{
								continue;
							}
							rect4.Offset(0f, (0f - num2) / 2f);
						}
						else if (k == num9)
						{
							if ((!string.IsNullOrEmpty(current2.BottomTitle) && current2.RuntimeBottomPadding <= 0f) || (yAxisInfo2 != null && yAxisInfo2.MergeIntoLeft))
							{
								continue;
							}
							if (current2.RuntimeBottomPadding <= 0f)
							{
								if (num10 <= current2.MinValue + (current2.MaxValue - current2.MinValue) * 0.08f)
								{
									rect4.Offset(0f, 0f - num2);
								}
								else
								{
									rect4.Offset(0f, (0f - num2) / 2f);
								}
							}
							else
							{
								rect4.Offset(0f, (0f - num2) / 2f);
							}
						}
						else
						{
							rect4.Offset(0f, (0f - num2) / 2f);
						}
						if (!string.IsNullOrEmpty(value))
						{
							dcgraphics_0.DrawString(value, xFontValue2, method_24(current2.TitleColor), rect4, drawStringFormatExt);
						}
					}
					dcgraphics_0.DrawLine(ForePen, current2.TitleLeft + current2.TitleWidth, current2.TitleTop, current2.TitleLeft + current2.TitleWidth, rectangleF_0.Bottom);
					dcgraphics_0.DrawLine(RuntimeForeColor, method_25(2f), current2.TitleLeft, current2.TitleTop, current2.TitleLeft + current2.TitleWidth, current2.TitleTop);
					dcgraphics_0.DrawLine(RuntimeForeColor, method_25(2f), current2.TitleLeft, rectangleF_0.Bottom, current2.TitleLeft + current2.TitleWidth, rectangleF_0.Bottom);
				}
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				tickCountFloat4 = CountDown.GetTickCountFloat();
				dcgraphics_0.DrawLine(RuntimeForeColor, method_25(2f), Left, rectangleF_0.Bottom, rectangleF_0.Left, rectangleF_0.Bottom);
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				tickCountFloat4 = CountDown.GetTickCountFloat();
				method_32(dcgraphics_0, rectangleF_2, rectangleF_0, yaxisInfoList_0, dateTime_2);
				method_50(dcgraphics_0, rectangleF_0, rectangleF_2);
				dcgraphics_0.DrawLine(Color.Black, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Left, rectangleF_0.Bottom);
				method_31(dcgraphics_0, rectangleF_2, rectangleF_0, yaxisInfoList_0, dateTime_2);
				dcgraphics_0.DrawLine(RuntimeForeColor, method_25(2f), rectangleF_0.Left, rectangleF_0.Top, Math.Min(rectangleF_2.Right, rectangleF_0.Right), rectangleF_0.Top);
				dcgraphics_0.DrawLine(RuntimeForeColor, method_25(2f), rectangleF_0.Left, rectangleF_0.Bottom, Math.Min(rectangleF_2.Right, rectangleF_0.Right), rectangleF_0.Bottom);
				foreach (YAxisInfo item in yaxisInfoList_0)
				{
					if (item.Style == YAxisInfoStyle.Background && item.Scales != null && item.Scales.Count > 0 && !string.IsNullOrEmpty(item.Title) && item.ValueVisible)
					{
						dcgraphics_0.DrawString(layoutRectangle: new RectangleF(rectangleF_0.Left + 3f, item.float_17, 1000f, item.float_18), string_0: item.Title, font: xFontValue, color: RuntimeForeColor, alignment: StringAlignment.Near, lineAlignment: StringAlignment.Center, noWrap: true);
					}
				}
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				foreach (YAxisInfo item2 in yaxisInfoList_0)
				{
					item2.pointF_0 = new PointF(float.NaN, float.NaN);
				}
				float tickCountFloat5 = CountDown.GetTickCountFloat();
				_ = dcgraphics_0.MeasureString("##", xFontValue, 10000, DrawStringFormatExt.GenericTypographic).Width;
				foreach (YAxisInfo item3 in yaxisInfoList_0)
				{
					if (genum22_0 == GEnum22.const_0)
					{
						break;
					}
					if (item3.ValueVisible && item3.Style != YAxisInfoStyle.Background)
					{
						if (item3.Style == YAxisInfoStyle.Text)
						{
							method_30(dcgraphics_0, rectangleF_0, rectangleF_2, item3, yaxisInfoList_0, dateTime_2);
						}
						else
						{
							method_30(dcgraphics_0, rectangleF_0, rectangleF_2, item3, yaxisInfoList_0, dateTime_2);
						}
					}
				}
				dcgraphics_0.DrawLine(Color.Black, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Left, rectangleF_0.Bottom);
				tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
				float tickCountFloat6 = CountDown.GetTickCountFloat();
				if (RuntimeFooterLines.Count > 0)
				{
					foreach (TitleLineInfo runtimeFooterLine in RuntimeFooterLines)
					{
						method_36(runtimeFooterLine, rectangleF_0, dcgraphics_0, rectangleF_2, float_6, genum22_0, dateTime_2, dateTime_);
					}
				}
				tickCountFloat6 = CountDown.GetTickCountFloat() - tickCountFloat6;
				float tickCountFloat7 = CountDown.GetTickCountFloat();
				dcgraphics_0.DrawRectangle(method_24(Config.ForeColor), method_25(2f), Left, Top + num4, Width, Height - num4 - num5);
				if (num5 > 0f)
				{
					using (DrawStringFormatExt drawStringFormatExt2 = new DrawStringFormatExt())
					{
						float num11 = Top + Height - num5;
						if (!string.IsNullOrEmpty(Config.FooterDescription))
						{
							drawStringFormatExt2.Alignment = StringAlignment.Near;
							drawStringFormatExt2.LineAlignment = StringAlignment.Center;
							drawStringFormatExt2.FormatFlags = StringFormatFlags.NoWrap;
							drawStringFormatExt2.Font = xFontValue;
							drawStringFormatExt2.Color = RuntimeForeColor;
							if (Config.FooterDescription.Contains("\\r\\n"))
							{
								string[] array = Config.FooterDescription.Split(new string[1]
								{
									"\\r\\n"
								}, StringSplitOptions.None);
								string[] array2 = array;
								foreach (string text2 in array2)
								{
									drawStringFormatExt2.Left = Left;
									drawStringFormatExt2.Top = num11;
									drawStringFormatExt2.Width = Width;
									drawStringFormatExt2.Height = num2;
									dcgraphics_0.method_2(text2, drawStringFormatExt2);
									num11 += num2;
								}
							}
							else
							{
								drawStringFormatExt2.Left = Left;
								drawStringFormatExt2.Top = num11;
								drawStringFormatExt2.Width = Width;
								drawStringFormatExt2.Height = num2;
								dcgraphics_0.method_2(Config.FooterDescription, drawStringFormatExt2);
								num11 += num2;
							}
						}
						if (!string.IsNullOrEmpty(text))
						{
							drawStringFormatExt2.Alignment = StringAlignment.Center;
							drawStringFormatExt2.LineAlignment = StringAlignment.Center;
							drawStringFormatExt2.Font = Config.RuntimePageIndexFont;
							drawStringFormatExt2.Left = Left;
							drawStringFormatExt2.Top = num11;
							drawStringFormatExt2.Width = Width;
							drawStringFormatExt2.Height = num2;
							dcgraphics_0.method_2(text, drawStringFormatExt2);
						}
					}
				}
				method_33(dcgraphics_0, rectangleF_2);
				method_34(dcgraphics_0, rectangleF_2);
				if (InnerBehaviorMode == Enum16.const_1 && SelectedObject != null)
				{
					RectangleF rect5 = method_9(SelectedObject);
					if (!rect5.IsEmpty && rectangleF_2.IntersectsWith(rect5))
					{
						dcgraphics_0.DrawRectangle(method_24(Config.ForeColor), method_11(2f), rect5.Left, rect5.Top, rect5.Width, rect5.Height);
						float num12 = method_11(6f);
						Pen selectionPen = DrawerUtil.GetSelectionPen(num12, IsCurrent: true);
						rect5.Inflate((0f - num12) / 2f, (0f - num12) / 2f);
						dcgraphics_0.DrawRectangle(selectionPen, rect5.Left, rect5.Top, rect5.Width, rect5.Height);
					}
				}
				if (ViewMode != 0)
				{
					GClass472 gClass = smethod_0(this);
					if (!(gClass?.method_6() ?? true))
					{
						gClass.method_21(GEnum88.flag_0);
						SizeF sizeF = gClass.method_27(dcgraphics_0);
						if (!sizeF.IsEmpty)
						{
							RectangleF rectangleF = new RectangleF(Left + rectangleF_1.Right, Top + rectangleF_1.Top, sizeF.Width, sizeF.Height);
							gClass.method_29(dcgraphics_0, rectangleF, bool_7: false);
						}
						else
						{
							gClass.method_29(dcgraphics_0, Bounds, bool_7: true);
						}
					}
				}
				xFontValue.Dispose();
				drawStringFormatExt.Dispose();
				tickCountFloat7 = CountDown.GetTickCountFloat() - tickCountFloat7;
				return 0f;
			}
		}

		private void method_30(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3, YAxisInfo yaxisInfo_0, YAxisInfoList yaxisInfoList_2, DateTime dateTime_4)
		{
			int num = 18;
			bool flag = false;
			foreach (YAxisInfo item in yaxisInfoList_2)
			{
				if (item.ShadowInfo == yaxisInfo_0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return;
			}
			XFontValue font = method_1(yaxisInfo_0, bool_3: true);
			float width = dcgraphics_0.MeasureString("##", font, 10000, DrawStringFormatExt.GenericTypographic).Width;
			if (!smethod_3(yaxisInfo_0.RedLineValue))
			{
				float num2 = yaxisInfo_0.method_3(this, rectangleF_2, yaxisInfo_0.RedLineValue);
				RectangleF rectangleF = RectangleF.Intersect(rectangleF_2, rectangleF_3);
				if (!rectangleF.IsEmpty && (!PrintingMode || yaxisInfo_0.RedLinePrintVisible))
				{
					dcgraphics_0.DrawLine(method_24(Color.Red), method_25(yaxisInfo_0.RedLineWidth), rectangleF.Left, num2, rectangleF.Right, num2);
				}
			}
			ValuePointList valuePointList = method_19(yaxisInfo_0.Name);
			float tickCountFloat = CountDown.GetTickCountFloat();
			int num3 = -1;
			int num4 = -1;
			RectangleF rectangleF2 = RectangleF.Intersect(rectangleF_3, rectangleF_2);
			int num5 = -1;
			float tickCountFloat2 = CountDown.GetTickCountFloat();
			_ = (float)GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			int index = class159_0.method_6(rectangleF_2, rectangleF_3);
			DateTime dateTime = class159_0[index].dateTime_0;
			int floorIndexByTime = valuePointList.GetFloorIndexByTime(dateTime);
			floorIndexByTime = Math.Max(0, floorIndexByTime - 5);
			float runtimeSymbolSize = yaxisInfo_0.RuntimeSymbolSize;
			for (int i = floorIndexByTime; i < valuePointList.Count; i++)
			{
				ValuePoint valuePoint = valuePointList[i];
				if (valuePoint.Time < dateTime_4)
				{
					continue;
				}
				if (!(valuePoint.Time > class159_0.method_4()))
				{
					if (num5 < 0)
					{
						num5 = i;
					}
					float left = valuePoint.Left;
					float top = valuePoint.Top;
					bool flag2 = left >= rectangleF2.Left - runtimeSymbolSize;
					if (yaxisInfo_0.Style == YAxisInfoStyle.Text)
					{
						flag2 = (left + width >= rectangleF2.Left);
					}
					if (flag2)
					{
						if (num3 < 0)
						{
							num3 = Math.Max(i - 1, 0);
							if (yaxisInfo_0.ShadowInfo != null)
							{
								bool flag3 = false;
								int num6 = 0;
								for (int num7 = num3; num7 >= 0; num7--)
								{
									if (valuePointList[num7].ShowShadowPoint)
									{
										num3 = num7;
										flag3 = true;
										if (num6++ > 4)
										{
											break;
										}
									}
									else
									{
										if (valuePointList[num7].IsNullValue)
										{
											break;
										}
										if (num7 != num3)
										{
											num3 = num7;
											break;
										}
										if (!flag3)
										{
											break;
										}
										flag3 = false;
									}
								}
							}
						}
						if (!yaxisInfo_0.AllowInterrupt)
						{
							int num7 = i - 1;
							while (num7 >= 0)
							{
								ValuePoint valuePoint2 = valuePointList[num7];
								if (smethod_3(valuePoint2.Value))
								{
									num7--;
									continue;
								}
								num3 = Math.Min(num3, num7);
								break;
							}
						}
					}
					if (!(left > rectangleF2.Right))
					{
						continue;
					}
					num4 = i;
					if (yaxisInfo_0.ShadowInfo != null)
					{
						for (int num7 = num4; num7 < valuePointList.Count; num7++)
						{
							if (valuePointList[num7].ShadowPoint != null)
							{
								if (num7 - num4 > 4)
								{
									num4 = num7;
									break;
								}
								continue;
							}
							num4 = num7;
							break;
						}
					}
					if (num4 < valuePointList.Count - 1)
					{
						num4++;
					}
					break;
				}
				if (num4 < 0)
				{
					num4 = ((!(valuePoint.Time > class159_0.method_2())) ? i : Math.Max(0, i - 1));
				}
				if (num3 < 0)
				{
					num3 = Math.Max(0, num4 - 1);
				}
				break;
			}
			tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
			if (num3 < 0)
			{
				return;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num3 < num5)
			{
				num3 = num5;
			}
			if (num4 < 0)
			{
				num4 = valuePointList.Count - 1;
			}
			float tickCountFloat3 = CountDown.GetTickCountFloat();
			Dictionary<float, float> dictionary = new Dictionary<float, float>();
			yaxisInfo_0.pointF_0 = new PointF(float.NaN, float.NaN);
			yaxisInfo_0.valuePoint_0 = null;
			bool flag4 = false;
			for (int i = num3; i <= num4; i++)
			{
				float tickCountFloat4 = CountDown.GetTickCountFloat();
				ValuePoint valuePoint = valuePointList[i];
				if (valuePoint.Time < dateTime_4 || valuePoint.Time > class159_0.method_2() || ((smethod_3(valuePoint.Left) || smethod_3(valuePoint.Top)) && (yaxisInfo_0.Style != 0 || !yaxisInfo_0.AllowInterrupt)))
				{
					continue;
				}
				_ = (valuePoint.Time.Date - dateTime_4).Days;
				float left = valuePoint.Left;
				if (yaxisInfo_0.Style == YAxisInfoStyle.Text)
				{
					if (left > rectangleF_2.Right - 2f)
					{
						break;
					}
					float num8 = (float)GraphicsUnitConvert.Convert(1.0, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
					float num9 = valuePoint.Top;
					if (valuePoint.ImageValue != null && Config.ShowIcon)
					{
						num9 += valuePoint.Height + num8 * 3f;
						method_45(dcgraphics_0, valuePoint.ImageValue, valuePoint.Left, valuePoint.Top);
					}
					if (!string.IsNullOrEmpty(valuePoint.Text))
					{
						using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericDefault.Clone())
						{
							if (valuePoint.Text.Length == 1)
							{
								drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
							}
							else
							{
								drawStringFormatExt.FormatFlags = (StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap);
							}
							drawStringFormatExt.Alignment = StringAlignment.Near;
							drawStringFormatExt.LineAlignment = StringAlignment.Center;
							XFontValue font2 = method_1(yaxisInfo_0, bool_3: true);
							RectangleF rectangleF3 = new RectangleF(0f, 0f, 0f, 0f);
							rectangleF3 = new RectangleF(valuePoint.Left + 3f, num9 + valuePoint.ValueTextTopPadding, valuePoint.Width, valuePoint.Top + valuePoint.Height - num9);
							bool flag5 = false;
							if (dictionary.ContainsKey(valuePoint.Left))
							{
								flag5 = true;
							}
							dictionary[valuePoint.Left] = rectangleF3.Bottom;
							float bottom = rectangleF_2.Bottom;
							if (rectangleF3.Bottom > bottom - 2f)
							{
								rectangleF3.Height = bottom - rectangleF3.Top - 2f;
							}
							if (!(rectangleF3.Height <= 0f))
							{
								if (yaxisInfo_0.ValueTextBackColor.A != 0)
								{
									dcgraphics_0.FillRectangle(yaxisInfo_0.ValueTextBackColor, rectangleF3);
								}
								if (flag5 && yaxisInfo_0.SeparatorLineVisible)
								{
									dcgraphics_0.DrawLine(method_24(Config.ForeColor), rectangleF3.Left, rectangleF3.Top, rectangleF3.Right, rectangleF3.Top);
								}
								Color color_ = yaxisInfo_0.SymbolColor;
								if (method_26(valuePoint))
								{
									color_ = Color.Blue;
									dcgraphics_0.DrawLine(Color.Blue, rectangleF3.Left, rectangleF3.Top, rectangleF3.Left, rectangleF3.Bottom);
									dcgraphics_0.DrawLine(Color.Blue, rectangleF3.Right - 1f, rectangleF3.Top, rectangleF3.Right - 1f, rectangleF3.Bottom);
								}
								try
								{
									dcgraphics_0.DrawString(valuePoint.Text, font2, method_24(color_), rectangleF3, drawStringFormatExt);
								}
								catch
								{
								}
								goto IL_07f1;
							}
						}
						continue;
					}
					goto IL_07f1;
				}
				if (!valuePoint.Visible)
				{
					continue;
				}
				float top = valuePoint.Top;
				if (float.IsNaN(top))
				{
					if (yaxisInfo_0.AllowInterrupt)
					{
						yaxisInfo_0.pointF_0 = new PointF(float.NaN, float.NaN);
						flag4 = false;
					}
				}
				else
				{
					bool flag6 = yaxisInfo_0.HighlightOutofNormalRange && Class157.smethod_3(valuePoint.Value, yaxisInfo_0.NormalMaxValue, yaxisInfo_0.NormalMinValue);
					float tickCountFloat5 = CountDown.GetTickCountFloat();
					if (!float.IsNaN(yaxisInfo_0.pointF_0.X))
					{
						Color color_2 = yaxisInfo_0.SymbolColor;
						if (valuePoint.Color.A != 0)
						{
							color_2 = valuePoint.Color;
						}
						else if (yaxisInfo_0.valuePoint_0 != null && yaxisInfo_0.valuePoint_0.Color.A != 0)
						{
							color_2 = yaxisInfo_0.valuePoint_0.Color;
						}
						SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
						dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
						float num10 = method_25(yaxisInfo_0.RuntimeLineWidth);
						if (flag6 || flag4)
						{
							num10 = (float)Math.Ceiling(num10 * 1.5f);
						}
						dcgraphics_0.DrawLine(method_24(color_2), method_25(num10), yaxisInfo_0.pointF_0, new PointF(left, top));
						dcgraphics_0.SmoothingMode = smoothingMode;
					}
					float num11 = yaxisInfo_0.RuntimeSymbolSize;
					if (flag6)
					{
						num11 *= 1.5f;
					}
					if (valuePoint.HollowCovertFlag)
					{
						method_54(dcgraphics_0, rectangleF_3, left, top, ValuePointSymbolStyle.HollowCicle, yaxisInfo_0.CharacterForCharSymbolStyle, yaxisInfo_0.SymbolColor, valuePoint, num11 * 1.5f, bool_3: false);
					}
					else
					{
						method_54(dcgraphics_0, rectangleF_3, left, top, yaxisInfo_0.SymbolStyle, yaxisInfo_0.CharacterForCharSymbolStyle, yaxisInfo_0.SymbolColor, valuePoint, num11, bool_3: false);
					}
					if (valuePoint.OutofRangeFlag == 1)
					{
						method_52(dcgraphics_0, left, top, bool_3: true, valuePoint, yaxisInfo_0.ValueTextBackColor);
					}
					else if (valuePoint.OutofRangeFlag == -1)
					{
						method_52(dcgraphics_0, left, top, bool_3: false, valuePoint, yaxisInfo_0.ValueTextBackColor);
					}
					tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
					yaxisInfo_0.pointF_0 = new PointF(left, top);
					yaxisInfo_0.valuePoint_0 = valuePoint;
					flag4 = flag6;
					if (yaxisInfo_0.EnableLanternValue && !smethod_3(valuePoint.LanternValue))
					{
						float num12 = yaxisInfo_0.method_3(this, rectangleF_2, valuePoint.LanternValue);
						Color red = Color.Red;
						red = ((!(num12 < top)) ? method_24(yaxisInfo_0.LanternValueColorForDown) : method_24(yaxisInfo_0.LanternValueColorForUp));
						method_54(dcgraphics_0, rectangleF_3, left, num12, yaxisInfo_0.SpecifyLanternSymbolStyle, yaxisInfo_0.CharacterForLanternSymbolStyle, red, valuePoint, num11, bool_3: true);
						if (valuePoint.Verified)
						{
							method_54(dcgraphics_0, rectangleF_3, valuePoint.Left, valuePoint.Top - 25f, ValuePointSymbolStyle.V, yaxisInfo_0.CharacterForCharSymbolStyle, red, null, num11, bool_3: false);
						}
						using (Pen pen = new Pen(red, method_25(2f)))
						{
							pen.DashStyle = DashStyle.Dash;
							dcgraphics_0.DrawLine(pen, left, top, left, num12);
						}
					}
				}
				if (yaxisInfo_0.ShadowInfo != null && valuePoint.ShadowPoint != null)
				{
					if (valuePoint.ShowShadowPoint)
					{
						top = valuePoint.ShadowPoint.Top;
						if (float.IsNaN(top))
						{
							valuePoint.ShadowPoint = null;
							yaxisInfo_0.ShadowInfo.pointF_0 = new PointF(float.NaN, float.NaN);
						}
						else
						{
							valuePoint.ShadowPoint.Left = left;
							valuePoint.ShadowPoint.Top = top;
							method_54(dcgraphics_0, rectangleF_3, left, top, ValuePointSymbolStyle.HollowCicle, yaxisInfo_0.CharacterForCharSymbolStyle, yaxisInfo_0.SymbolColor, valuePoint.ShadowPoint, yaxisInfo_0.RuntimeSymbolSize, bool_3: false);
							yaxisInfo_0.ShadowInfo.pointF_0 = new PointF(left, top);
						}
						if (valuePoint.ShowShadowPoint && yaxisInfo_0.VerticalLine)
						{
							using (Pen pen_ = new Pen(method_24(Color.Red), method_25(2f)))
							{
								dcgraphics_0.DrawLine(pen_, new PointF(valuePoint.Left, valuePoint.Top), new PointF(valuePoint.ShadowPoint.Left, valuePoint.ShadowPoint.Top));
							}
						}
					}
					else
					{
						yaxisInfo_0.ShadowInfo.pointF_0 = new PointF(float.NaN, float.NaN);
					}
				}
				goto IL_0cc2;
				IL_0cc2:
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				continue;
				IL_07f1:
				if (dictionary_1 != null && valuePoint.Height > 0f)
				{
					dictionary_1[valuePoint] = valuePoint.ViewBounds;
				}
				goto IL_0cc2;
			}
			tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
			if (yaxisInfo_0.ShadowInfo != null && valuePointList.Count > 0)
			{
				for (int i = num3; i <= num4; i++)
				{
					ValuePoint valuePoint = valuePointList[i];
					if (valuePoint.Time < dateTime_4 || valuePoint.Time > class159_0.method_2() || !valuePoint.ShowShadowPoint)
					{
						continue;
					}
					int num13 = i;
					if (num13 > num3)
					{
						ValuePoint valuePoint3 = valuePointList[num13 - 1];
						if (!valuePoint3.IsNullValue && valuePoint3.ShadowPoint != null && !float.IsNaN(valuePoint3.ShadowPoint.CenterY))
						{
							num13--;
						}
					}
					int j;
					for (j = i; j <= num4; j++)
					{
						ValuePoint valuePoint4 = valuePointList[j];
						if (valuePoint4.ShowShadowPoint)
						{
							if (j == num4)
							{
								if (valuePoint4.IsNullValue)
								{
									j--;
								}
								break;
							}
							continue;
						}
						if (valuePoint4.ShadowPoint == null || float.IsNaN(valuePoint4.ShadowPoint.CenterY))
						{
							j--;
						}
						break;
					}
					i = j;
					if (j <= num13)
					{
						continue;
					}
					List<PointF> list = new List<PointF>();
					for (int k = num13; k <= j; k++)
					{
						list.Add(new PointF(valuePointList[k].CenterX, valuePointList[k].CenterY));
					}
					for (int k = j; k >= num13; k--)
					{
						ValuePoint valuePoint4 = valuePointList[k];
						if (valuePoint4.ShowShadowPoint)
						{
							list.Add(new PointF(valuePoint4.ShadowPoint.CenterX, valuePoint4.ShadowPoint.CenterY));
						}
						else
						{
							list.Add(new PointF(valuePoint4.CenterX, valuePoint4.CenterY));
						}
					}
					if (list.Count > 2 && list[0] != list[list.Count - 1])
					{
						list.Add(list[0]);
					}
					SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
					dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
					dcgraphics_0.DrawLines(method_24(yaxisInfo_0.SymbolColor), method_25(2f), list.ToArray());
					dcgraphics_0.SmoothingMode = smoothingMode;
					using (HatchBrush brush = new HatchBrush(HatchStyle.LightUpwardDiagonal, method_24(yaxisInfo_0.SymbolColor), Color.Transparent))
					{
						if (yaxisInfo_0.ShadowPointVisible)
						{
							dcgraphics_0.FillPolygon(brush, list.ToArray());
						}
					}
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private void method_31(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3, YAxisInfoList yaxisInfoList_2, DateTime dateTime_4)
		{
			foreach (YAxisInfo item in yaxisInfoList_2)
			{
				bool flag = false;
				if (item.ValueVisible && (!smethod_3(item.NormalMaxValue) || !smethod_3(item.NormalMinValue)))
				{
					flag = true;
					foreach (YAxisInfo item2 in yaxisInfoList_2)
					{
						if (item2 != item && item2.ValueVisible && item2.Style == YAxisInfoStyle.Value)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					RectangleF a = rectangleF_3;
					if (!smethod_3(item.NormalMaxValue) && item.NormalMaxValue > item.MinValue && item.NormalMaxValue < item.MaxValue)
					{
						float num = item.method_3(this, rectangleF_3, item.NormalMaxValue);
						a.Height = a.Bottom - num;
						a.Y = num;
						if (item.OutofNormalRangeBackColor.A != 0)
						{
							RectangleF a2 = new RectangleF(rectangleF_3.Left, rectangleF_3.Top, rectangleF_3.Width, num - rectangleF_3.Top);
							RectangleF rect = RectangleF.Intersect(a2, rectangleF_2);
							if (!rect.IsEmpty)
							{
								dcgraphics_0.FillRectangle(item.OutofNormalRangeBackColor, rect);
							}
						}
					}
					if (!smethod_3(item.NormalMinValue) && item.NormalMinValue > item.MinValue && item.NormalMinValue < item.MaxValue)
					{
						float num2 = item.method_3(this, rectangleF_3, item.NormalMinValue);
						a.Height = num2 - a.Top;
						if (item.OutofNormalRangeBackColor.A != 0)
						{
							RectangleF a2 = new RectangleF(rectangleF_3.Left, num2, rectangleF_3.Width, rectangleF_3.Bottom - num2);
							RectangleF rect = RectangleF.Intersect(a2, rectangleF_2);
							if (!rect.IsEmpty)
							{
								dcgraphics_0.FillRectangle(item.OutofNormalRangeBackColor, rect);
							}
						}
					}
					if (a.Height > 0f && item.NormalRangeBackColor.A != 0)
					{
						RectangleF rect = RectangleF.Intersect(a, rectangleF_2);
						if (!rect.IsEmpty)
						{
							dcgraphics_0.FillRectangle(item.NormalRangeBackColor, rect);
						}
					}
				}
			}
		}

		private void method_32(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3, YAxisInfoList yaxisInfoList_2, DateTime dateTime_4)
		{
			int num = -1;
			foreach (YAxisInfo item in yaxisInfoList_2)
			{
				if (item.Style == YAxisInfoStyle.PartialBackground)
				{
					num++;
					item.float_17 = rectangleF_3.Bottom - rectangleF_3.Height * (float)(num + 1) / (float)Config.GridYSplitInfo.GridYSplitNum;
					item.float_18 = rectangleF_3.Height / (float)Config.GridYSplitInfo.GridYSplitNum;
					method_47(null, item.Scales, Datas.GetValuesByName(item.Name), rectangleF_3, item.float_17, item.float_18, dcgraphics_0, rectangleF_2, dateTime_4, bool_3: true);
				}
				else if (item.Style == YAxisInfoStyle.Background)
				{
					num++;
					item.float_17 = rectangleF_3.Top;
					item.float_18 = rectangleF_3.Height;
					method_47(null, item.Scales, Datas.GetValuesByName(item.Name), rectangleF_3, item.float_17, item.float_18, dcgraphics_0, rectangleF_2, dateTime_4, bool_3: true);
				}
			}
		}

		private void method_33(DCGraphics dcgraphics_0, RectangleF rectangleF_2)
		{
			if (ViewMode == DocumentViewMode.Page && Config.Labels != null && Config.Labels.Count != 0)
			{
				float num = (float)GraphicsUnitConvert.GetRate(dcgraphics_0.PageUnit, GraphicsUnit.Document);
				foreach (DCTimeLineLabel label in Config.Labels)
				{
					RectangleF rect = new RectangleF(Left + label.Left * num, Top + label.Top * num, label.Width * num, label.Height * num);
					if (rectangleF_2.IntersectsWith(rect))
					{
						if (label.BackColor.A != 0)
						{
							dcgraphics_0.FillRectangle(label.BackColor, rect);
						}
						if (label.Image != null)
						{
							dcgraphics_0.DrawImage(label.Image.Value, rect);
						}
						if (label.ShowBorder)
						{
							dcgraphics_0.DrawRectangle(Color.Black, Left + label.Left * num, Top + label.Top * num, label.Width * num, label.Height * num);
						}
						string value = Parameters.Convert(label.ParameterName, label.Text);
						if (!string.IsNullOrEmpty(value))
						{
							using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericTypographic.Clone())
							{
								drawStringFormatExt.Alignment = label.Alignment;
								drawStringFormatExt.LineAlignment = label.LineAlignment;
								if (!label.MultiLine)
								{
									drawStringFormatExt.FormatFlags |= StringFormatFlags.NoWrap;
								}
								XFontValue xFontValue = label.Font;
								if (xFontValue == null)
								{
									xFontValue = new XFontValue();
								}
								dcgraphics_0.DrawString(value, xFontValue, method_24(label.Color), rect, drawStringFormatExt);
							}
						}
					}
				}
			}
		}

		private void method_34(DCGraphics dcgraphics_0, RectangleF rectangleF_2)
		{
			if (ViewMode == DocumentViewMode.Page && Config.Images != null && Config.Images.Count != 0)
			{
				foreach (DCTimeLineImage image in Config.Images)
				{
					if (image.Image != null && image.Image.HasContent)
					{
						RectangleF empty = RectangleF.Empty;
						empty.X = Left + GraphicsUnitConvert.Convert(image.Left, GraphicsUnit.Document, dcgraphics_0.PageUnit);
						empty.Y = Top + GraphicsUnitConvert.Convert(image.Top, GraphicsUnit.Document, dcgraphics_0.PageUnit);
						empty.Width = GraphicsUnitConvert.Convert(image.ImagePixelWidth, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
						empty.Height = GraphicsUnitConvert.Convert(image.ImagePixelHeight, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
						if (rectangleF_2.IntersectsWith(empty))
						{
							dcgraphics_0.DrawImage(image.Image.Value, empty);
						}
					}
				}
			}
		}

		private void method_35(DCGraphics dcgraphics_0, TitleLineInfo titleLineInfo_0, float float_8, DateTime dateTime_4)
		{
			titleLineInfo_0.Height = float_8;
			DateTime t = dateTime_4.AddDays(RuntimeNumOfDaysInOnePage);
			if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Cascade)
			{
				ValuePointList valuePointList = method_19(titleLineInfo_0.Name);
				if (valuePointList != null && valuePointList.Count > 0)
				{
					DateTime date = dateTime_4.Date;
					int num = 1;
					int num2 = 0;
					foreach (ValuePoint item in valuePointList)
					{
						if (item.Time > t)
						{
							break;
						}
						if (item.Time.Date == date)
						{
							num2++;
						}
						else
						{
							num = Math.Max(num, num2);
							num2 = 1;
							if (item.Time.Date > date)
							{
								date = item.Time.Date;
							}
						}
					}
					titleLineInfo_0.Height = (float)num * float_8;
					titleLineInfo_0.ContentLineCount = num;
				}
				else
				{
					titleLineInfo_0.ContentLineCount = 1;
					titleLineInfo_0.Height = float_8;
				}
			}
			if (dcgraphics_0 != null)
			{
				titleLineInfo_0.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
			}
		}

		private void method_36(TitleLineInfo titleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, float float_8, GEnum22 genum22_0, DateTime dateTime_4, DateTime dateTime_5)
		{
			if (titleLineInfo_0.ValueType == TitleLineValueType.InDayIndex)
			{
				titleLineInfo_0.ValueType = TitleLineValueType.GlobalDayIndex;
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			RectangleF rect = new RectangleF(Left, titleLineInfo_0.Top, Width, titleLineInfo_0.RuntimeHeight);
			if (!rectangleF_3.IsEmpty && !rectangleF_3.IntersectsWith(rect))
			{
				return;
			}
			dcgraphics_0.DrawLine(ForePen, Left, rect.Bottom, rect.Right, rect.Bottom);
			RectangleF rectangleF = new RectangleF(Left, titleLineInfo_0.Top, float_8, titleLineInfo_0.RuntimeHeight);
			XFontValue font = method_0(titleLineInfo_0, bool_3: false);
			titleLineInfo_0.TitleBounds = rectangleF;
			float num = 0f;
			if (titleLineInfo_0.ShowExpandedHandle && !PrintingMode)
			{
				Image collapse = DCTimeLineImageResources.Collapse;
				Image expand = DCTimeLineImageResources.Expand;
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(collapse.Width, collapse.Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				_ = (float)GraphicsUnitConvert.Convert(3, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				GraphicsUnitConvert.Convert(16, GraphicsUnit.Pixel, GraphicsUnit);
				float num2 = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, GraphicsUnit);
				RectangleF rect2 = titleLineInfo_0.ExpandedHandleBounds = new RectangleF(rectangleF.Left + num2, rectangleF.Top + (rectangleF.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
				Image image_ = titleLineInfo_0.IsExpanded ? expand : collapse;
				if (rectangleF_3.IntersectsWith(rect2))
				{
					DrawerUtil.DrawImageUnscaledNearestNeighbor(dcgraphics_0, image_, (int)rect2.Left, (int)rect2.Top);
				}
				num = num2 + rect2.Width + 2f;
			}
			if (!string.IsNullOrEmpty(titleLineInfo_0.Title) && (rectangleF_3.IsEmpty || rectangleF_3.IntersectsWith(rectangleF)))
			{
				LineTitleStringFormat.Alignment = titleLineInfo_0.TitleAlign;
				RectangleF rect3 = rectangleF;
				if (LineTitleStringFormat.Alignment == StringAlignment.Near)
				{
					rect3 = new RectangleF(rectangleF.Left + num, rectangleF.Top, rectangleF.Width - num, rectangleF.Height);
				}
				dcgraphics_0.DrawString(titleLineInfo_0.Title, font, method_24(titleLineInfo_0.TitleColor), rect3, LineTitleStringFormat);
			}
			dcgraphics_0.DrawRectangle(RuntimeForeColor, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
			dcgraphics_0.DrawLine(RuntimeForeColor, method_25(2f), rectangleF.Left + rectangleF.Width, rectangleF.Top, rectangleF.Left + rectangleF.Width, rectangleF.Height + rectangleF.Top);
			if (genum22_0 != 0)
			{
				if (titleLineInfo_0.ExtendGridLineType == DCExtendGridLineType.Below)
				{
					method_37(dcgraphics_0, new RectangleF(rectangleF_2.Left, rectangleF.Top, rectangleF_2.Width, rectangleF.Height), rectangleF_3);
				}
				DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
				float num3 = rectangleF_2.Width / (float)RuntimeNumOfDaysInOnePage;
				if (Config.Ticks.Count > 0)
				{
					float_7 = num3 / (float)Config.Ticks.Count;
				}
				else
				{
					float_7 = num3;
				}
				if (titleLineInfo_0.ValueType == TitleLineValueType.SerialDate)
				{
					method_39(titleLineInfo_0, rectangleF_2, dcgraphics_0, rectangleF_3, dateTime_4, drawStringFormatExt);
				}
				else if (titleLineInfo_0.ValueType == TitleLineValueType.NewSerialDate)
				{
					method_38(titleLineInfo_0, rectangleF_2, dcgraphics_0, rectangleF_3, dateTime_4, drawStringFormatExt);
				}
				else if (titleLineInfo_0.ValueType == TitleLineValueType.DayIndex || titleLineInfo_0.ValueType == TitleLineValueType.GlobalDayIndex)
				{
					method_40(titleLineInfo_0, rectangleF_2, dcgraphics_0, rectangleF_3, dateTime_4, dateTime_5, drawStringFormatExt);
				}
				else if (titleLineInfo_0.ValueType == TitleLineValueType.HourTick)
				{
					method_43(titleLineInfo_0, rectangleF_2, dcgraphics_0, rectangleF_3);
				}
				else if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Free || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.FreeText || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant3)
				{
					method_47(titleLineInfo_0, titleLineInfo_0.Scales, method_19(titleLineInfo_0.Name), rectangleF_2, titleLineInfo_0.Top + 1f, titleLineInfo_0.RuntimeHeight - 2f, dcgraphics_0, rectangleF_3, dateTime_4, titleLineInfo_0.ShowBackColor);
				}
				else if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Cascade || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.HorizCascade || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Normal || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant2)
				{
					method_42(titleLineInfo_0, rectangleF_2, dcgraphics_0, rectangleF_3, dateTime_4);
				}
				if (titleLineInfo_0.ExtendGridLineType == DCExtendGridLineType.Above)
				{
					method_37(dcgraphics_0, new RectangleF(rectangleF_2.Left, rectangleF.Top, rectangleF_2.Width, rectangleF.Height), rectangleF_3);
				}
				dcgraphics_0.DrawRectangle(RuntimeForeColor, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
				dcgraphics_0.DrawLine(RuntimeForeColor, Math.Max(Left, rectangleF_3.Left - 1f), titleLineInfo_0.Top, Math.Min(Left + Width, rectangleF_3.Right + 1f), titleLineInfo_0.Top);
				dcgraphics_0.DrawLine(RuntimeForeColor, Math.Max(Left, rectangleF_3.Left - 1f), titleLineInfo_0.Top + titleLineInfo_0.RuntimeHeight, Math.Min(Left + Width, rectangleF_3.Right + 1f), titleLineInfo_0.Top + titleLineInfo_0.RuntimeHeight);
				drawStringFormatExt.Dispose();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			}
		}

		private void method_37(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3)
		{
			_ = RuntimeNumOfDaysInOnePage;
			float num = Math.Max(rectangleF_2.Top, rectangleF_3.Top);
			float num2 = Math.Min(rectangleF_2.Bottom, rectangleF_3.Bottom);
			if (num <= num2)
			{
				using (Pen pen_ = new Pen(method_24(Config.BigVerticalGridLineColor), method_25(2f)))
				{
					for (int i = 1; i < class159_0.Count; i++)
					{
						Class158 @class = class159_0[i];
						if (@class.bool_0)
						{
							float num3 = rectangleF_2.Left + @class.float_0;
							if (num3 >= rectangleF_3.Left && num3 <= rectangleF_3.Right)
							{
								dcgraphics_0.DrawLine(pen_, num3, num, num3, num2);
							}
						}
					}
				}
			}
		}

		private void method_38(TitleLineInfo titleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4, DrawStringFormatExt drawStringFormatExt_3)
		{
			int num = 16;
			int runtimeNumOfDaysInOnePage = RuntimeNumOfDaysInOnePage;
			XFontValue font = method_0(titleLineInfo_0, bool_3: true);
			RectangleF rectangleF = RectangleF.Empty;
			string text = Config.DateFormatString;
			if (string.IsNullOrEmpty(text))
			{
				text = "yyyy-MM-dd";
			}
			float width = dcgraphics_0.MeasureString(text, font, 10000, drawStringFormatExt_3).Width;
			bool flag = false;
			for (int i = 0; i < runtimeNumOfDaysInOnePage; i++)
			{
				DateTime dateTime = dateTime_4.AddDays(i);
				RectangleF rectangleF2 = class159_0.method_18(rectangleF_2, dateTime);
				if (rectangleF2.IsEmpty || rectangleF2.Right <= rectangleF.Right)
				{
					continue;
				}
				rectangleF = rectangleF2;
				rectangleF2.Y = titleLineInfo_0.Top;
				rectangleF2.Height = titleLineInfo_0.RuntimeHeight;
				if (rectangleF2.Left > rectangleF_3.Right || rectangleF2.Left >= rectangleF_2.Right - 2f)
				{
					break;
				}
				rectangleF2 = method_41(rectangleF_2, rectangleF2);
				string text2 = null;
				if (i == 0 || dateTime.Day == 1)
				{
					if (PageIndex == 0 || dateTime.DayOfYear == 1)
					{
						if (rectangleF2.Width > width * 0.9f)
						{
							text2 = dateTime.ToString(text);
							flag = false;
						}
						else
						{
							flag = true;
						}
					}
					else if (rectangleF2.Width > width * 0.9f)
					{
						text2 = dateTime.ToString("MM-dd");
						flag = false;
					}
					else
					{
						flag = true;
					}
				}
				if (flag && rectangleF2.Width > width * 0.9f)
				{
					text2 = dateTime.ToString(text);
					flag = false;
				}
				if (text2 == null)
				{
					text2 = dateTime.Day.ToString();
				}
				if (rectangleF_3.IntersectsWith(rectangleF2))
				{
					Color color_ = titleLineInfo_0?.TextColor ?? Config.ForeColor;
					dcgraphics_0.DrawString(text2, font, method_24(color_), rectangleF2, drawStringFormatExt_3);
				}
			}
		}

		private void method_39(TitleLineInfo titleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4, DrawStringFormatExt drawStringFormatExt_3)
		{
			int num = 9;
			int runtimeNumOfDaysInOnePage = RuntimeNumOfDaysInOnePage;
			XFontValue font = method_0(titleLineInfo_0, bool_3: true);
			RectangleF rectangleF = RectangleF.Empty;
			string text = Config.DateFormatString;
			if (string.IsNullOrEmpty(text))
			{
				text = "yyyy-MM-dd";
			}
			float width = dcgraphics_0.MeasureString(text, font, 10000, drawStringFormatExt_3).Width;
			bool flag = false;
			for (int i = 0; i < runtimeNumOfDaysInOnePage; i++)
			{
				DateTime dateTime = dateTime_4.AddDays(i);
				RectangleF rectangleF2 = class159_0.method_18(rectangleF_2, dateTime);
				if (rectangleF2.IsEmpty || rectangleF2.Right <= rectangleF.Right)
				{
					continue;
				}
				rectangleF = rectangleF2;
				rectangleF2.Y = titleLineInfo_0.Top;
				rectangleF2.Height = titleLineInfo_0.RuntimeHeight;
				if (rectangleF2.Left > rectangleF_3.Right || rectangleF2.Left >= rectangleF_2.Right - 2f)
				{
					break;
				}
				rectangleF2 = method_41(rectangleF_2, rectangleF2);
				string text2 = null;
				if (i == 0 || dateTime.Day == 1 || (dateTime.DayOfWeek == DayOfWeek.Monday && ViewMode == DocumentViewMode.Timeline))
				{
					if (rectangleF2.Width > width * 0.9f)
					{
						text2 = dateTime.ToString(text);
						flag = false;
					}
					else
					{
						flag = true;
					}
				}
				if (flag && rectangleF2.Width > width * 0.9f)
				{
					text2 = dateTime.ToString(text);
					flag = false;
				}
				if (text2 == null)
				{
					text2 = dateTime.Day.ToString();
				}
				if (rectangleF_3.IntersectsWith(rectangleF2))
				{
					Color color_ = titleLineInfo_0?.TextColor ?? Config.ForeColor;
					dcgraphics_0.DrawString(text2, font, method_24(color_), rectangleF2, drawStringFormatExt_3);
				}
			}
		}

		private void method_40(TitleLineInfo titleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4, DateTime dateTime_5, DrawStringFormatExt drawStringFormatExt_3)
		{
			int num = 13;
			float tickCountFloat = CountDown.GetTickCountFloat();
			int runtimeNumOfDaysInOnePage = RuntimeNumOfDaysInOnePage;
			if (titleLineInfo_0._RuntimeStartDates != null)
			{
				XFontValue font = method_0(titleLineInfo_0, bool_3: true);
				RectangleF rectangleF = RectangleF.Empty;
				int index = class159_0.method_6(rectangleF_2, rectangleF_3);
				DateTime dateTime = class159_0[index].dateTime_0;
				index = (int)dateTime.Subtract(dateTime_4).TotalDays - 2;
				index = Math.Max(index, 0);
				for (int i = index; i < runtimeNumOfDaysInOnePage; i++)
				{
					DateTime dateTime2 = dateTime_4.AddDays(i);
					if (dateTime2 >= dateTime_5 || (titleLineInfo_0.EnableEndTime && !smethod_4(dateTime_3) && dateTime2 > dateTime_3))
					{
						break;
					}
					RectangleF rectangleF2 = class159_0.method_18(rectangleF_2, dateTime2);
					if (rectangleF2.Right <= rectangleF.Right)
					{
						continue;
					}
					rectangleF = rectangleF2;
					rectangleF2.Y = titleLineInfo_0.Top;
					rectangleF2.Height = titleLineInfo_0.RuntimeHeight;
					if (rectangleF2.Left > rectangleF_3.Right || rectangleF2.Left > rectangleF_2.Right - 2f)
					{
						break;
					}
					rectangleF2 = method_41(rectangleF_2, rectangleF2);
					if (rectangleF2.IsEmpty || !rectangleF_3.IntersectsWith(rectangleF2))
					{
						continue;
					}
					int num2 = (titleLineInfo_0.ValueType == TitleLineValueType.GlobalDayIndex || titleLineInfo_0.MaxValueForDayIndex <= 0) ? int.MaxValue : titleLineInfo_0.MaxValueForDayIndex;
					StringBuilder stringBuilder = new StringBuilder();
					for (int num3 = titleLineInfo_0._RuntimeStartDates.Length - 1; num3 >= 0; num3--)
					{
						DateTime d = titleLineInfo_0._RuntimeStartDates[num3];
						DateTime d2 = d.AddDays(-1.0);
						TimeSpan timeSpan = dateTime2 - d;
						TimeSpan timeSpan2 = dateTime2 - d2;
						if (timeSpan.Days <= num2)
						{
							if (titleLineInfo_0.AfterOperaDaysFromZero && timeSpan2.Days == 0)
							{
								string value = Convert.ToString(timeSpan2.Days);
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append("/");
								}
								stringBuilder.Append(value);
							}
							if (timeSpan.Days >= 0)
							{
								string value = Convert.ToString(timeSpan.Days + 1);
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append("/");
								}
								stringBuilder.Append(value);
							}
						}
					}
					if (stringBuilder.Length > 0)
					{
						Color color_ = titleLineInfo_0?.TextColor ?? Config.ForeColor;
						dcgraphics_0.DrawString(stringBuilder.ToString(), font, method_24(color_), rectangleF2, drawStringFormatExt_3);
					}
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private RectangleF method_41(RectangleF rectangleF_2, RectangleF rectangleF_3)
		{
			rectangleF_3.X = Math.Max(rectangleF_3.X, rectangleF_2.Left);
			float num = Math.Min(rectangleF_3.Right, rectangleF_2.Right);
			rectangleF_3.Width = num - rectangleF_3.Left;
			if (rectangleF_3.Width <= 0f)
			{
				return RectangleF.Empty;
			}
			return rectangleF_3;
		}

		private void method_42(TitleLineInfo titleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4)
		{
			_ = RuntimeNumOfDaysInOnePage;
			ValuePointList valuePointList = method_19(titleLineInfo_0.Name);
			int num = 0;
			if (titleLineInfo_0.UpAndDownTextType == UpAndDownTextType.ShowByText)
			{
				for (int i = 0; i < valuePointList.Count; i++)
				{
					if (string.IsNullOrEmpty(valuePointList[i].RuntimeText))
					{
						num++;
					}
					ValuePoint valuePoint = valuePointList[i];
					if ((i - num) % 2 == 0)
					{
						valuePoint.UpAndDown = ValuePointUpAndDown.Up;
					}
					else
					{
						valuePoint.UpAndDown = ValuePointUpAndDown.Down;
					}
				}
			}
			float tickCountFloat = CountDown.GetTickCountFloat();
			int count = class159_0.Count;
			_ = rectangleF_2.Width / (float)class159_0.Count;
			string[] array = null;
			if (!string.IsNullOrEmpty(titleLineInfo_0.LoopTextList))
			{
				array = titleLineInfo_0.LoopTextList.Split(',');
			}
			int num2 = 1;
			int num3 = -1;
			int num4 = class159_0.method_6(rectangleF_2, rectangleF_3);
			if (titleLineInfo_0.TickStep > 1)
			{
				int num5 = 1;
				if (array != null && array.Length > 0)
				{
					num5 = array.Length;
				}
				if (titleLineInfo_0.ValueType == TitleLineValueType.TickText)
				{
					num4 -= num4 % (titleLineInfo_0.TickStep * num5);
				}
				else
				{
					float num6 = titleLineInfo_0.TickStep;
					DCTimeUnit dCTimeUnit = Config.TickUnit;
					if (Config.TickUnit == DCTimeUnit.Hour)
					{
						num6 = (float)titleLineInfo_0.TickStep * 24f / (float)Config.Ticks.Count;
						if (num6 == 24f)
						{
							num6 = 1f;
							dCTimeUnit = DCTimeUnit.Day;
						}
					}
					if (dCTimeUnit == DCTimeUnit.Day)
					{
						DateTime date = class159_0[num4].dateTime_0.Date;
						for (int num7 = num4 - 1; num7 >= 0; num7--)
						{
							if (class159_0[num7].dateTime_0.Day < date.Day)
							{
								num4 = num7 + 1;
							}
						}
					}
				}
			}
			for (int j = num4; j < count; j += num2)
			{
				if (j != count - 1)
				{
				}
				DateTime dateTime = class159_0[j].dateTime_0;
				int num8 = j + 1;
				if (titleLineInfo_0.ValueType == TitleLineValueType.TickText && titleLineInfo_0.TickStep == 1)
				{
					num8 = j + 1;
				}
				else
				{
					float num6 = titleLineInfo_0.TickStep;
					DCTimeUnit dCTimeUnit = Config.TickUnit;
					if (Config.TickUnit == DCTimeUnit.Hour)
					{
						num6 = (float)titleLineInfo_0.TickStep * 24f / (float)Config.Ticks.Count;
						if (num6 == 24f)
						{
							num6 = 1f;
							dCTimeUnit = DCTimeUnit.Day;
						}
					}
					dateTime = Class160.smethod_0(dateTime, num6, dCTimeUnit, bool_0: true);
					num8 = class159_0.method_13(dateTime, bool_0: false, bool_1: true);
				}
				num2 = num8 - j;
				if (num2 <= 0)
				{
					num2 = 1;
				}
				num3++;
				RectangleF rectangleF_4 = new RectangleF(rectangleF_2.Left + class159_0.method_21(j), titleLineInfo_0.Top, 0f, titleLineInfo_0.RuntimeHeight);
				rectangleF_4.Width = class159_0.method_21(j + num2) - class159_0.method_21(j);
				if (!(rectangleF_4.Left > rectangleF_3.Right - 2f))
				{
					rectangleF_4 = method_41(rectangleF_2, rectangleF_4);
					if (!rectangleF_3.IntersectsWith(rectangleF_4))
					{
						continue;
					}
					_ = CountDown.GetTickCountFloat() - tickCountFloat;
					dcgraphics_0.DrawLine(ForePen, rectangleF_4.Right, rectangleF_4.Top, rectangleF_4.Right, rectangleF_4.Bottom);
					RectangleF rectangleF = new RectangleF(rectangleF_4.Left, rectangleF_4.Top, rectangleF_4.Width, rectangleF_4.Height);
					ValuePointList valuePointList2 = null;
					if (array != null && array.Length > 0)
					{
						if (titleLineInfo_0.RuntimeLayoutType != TitleLineLayoutType.Cascade && titleLineInfo_0.RuntimeLayoutType != TitleLineLayoutType.HorizCascade)
						{
							ValuePoint valuePoint = new ValuePoint();
							valuePoint.Text = array[num3 % array.Length];
							method_44(titleLineInfo_0, valuePoint, dcgraphics_0, rectangleF_4, j);
							continue;
						}
						valuePointList2 = new ValuePointList();
						string[] array2 = array;
						foreach (string text in array2)
						{
							ValuePoint valuePoint = new ValuePoint();
							valuePoint.Text = text;
							valuePointList2.Add(valuePoint);
						}
					}
					else
					{
						valuePointList2 = new ValuePointList();
						_ = (float)(int)Math.Floor((float)j / (float)Config.Ticks.Count);
						_ = j % Config.Ticks.Count;
						DateTime t = class159_0.method_9(j);
						DateTime t2 = class159_0.method_10(j + num2 - 1);
						if (t2.Day != t.Day)
						{
							t2 = t.Date.AddDays(1.0);
						}
						if (valuePointList.Count > 0)
						{
							int num9 = valuePointList.GetFloorIndexByTime(t);
							if (num9 < 0)
							{
								num9 = 0;
							}
							if (num9 >= 0)
							{
								for (int l = num9; l < valuePointList.Count; l++)
								{
									ValuePoint valuePoint = valuePointList[l];
									if (!(valuePoint.Time >= t))
									{
										continue;
									}
									if (valuePoint.Time >= t2)
									{
										break;
									}
									if (!string.IsNullOrEmpty(valuePoint.RuntimeText))
									{
										valuePointList2.Add(valuePoint);
										if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Normal)
										{
											break;
										}
									}
								}
							}
						}
					}
					if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Normal)
					{
						if (valuePointList2.Count > 0)
						{
							method_44(titleLineInfo_0, valuePointList2[0], dcgraphics_0, rectangleF_4, j);
						}
					}
					else if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant2)
					{
						SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
						dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
						if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant)
						{
							dcgraphics_0.DrawLine(Pens.Black, rectangleF_4.Left, rectangleF_4.Top, rectangleF_4.Right, rectangleF_4.Bottom);
						}
						else
						{
							dcgraphics_0.DrawLine(Pens.Black, rectangleF_4.Right, rectangleF_4.Top, rectangleF_4.Left, rectangleF_4.Bottom);
						}
						dcgraphics_0.SmoothingMode = smoothingMode;
						if (valuePointList2.Count > 0)
						{
							method_44(titleLineInfo_0, valuePointList2[0], dcgraphics_0, new RectangleF(rectangleF_4.Left, rectangleF_4.Top, rectangleF_4.Width / 2f, rectangleF_4.Height), 0);
						}
						if (valuePointList2.Count > 1)
						{
							method_44(titleLineInfo_0, valuePointList2[1], dcgraphics_0, new RectangleF(rectangleF_4.Left + rectangleF_4.Width / 2f, rectangleF_4.Top, rectangleF_4.Width / 2f, rectangleF_4.Height), 1);
						}
					}
					else if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Cascade)
					{
						if (valuePointList2.Count > 0)
						{
							for (int num7 = 0; num7 < valuePointList2.Count; num7++)
							{
								method_44(titleLineInfo_0, valuePointList2[num7], dcgraphics_0, new RectangleF(rectangleF_4.Left, rectangleF_4.Top + (float)num7 * rectangleF_4.Height / (float)valuePointList2.Count, rectangleF_4.Width, rectangleF_4.Height / (float)valuePointList2.Count), j);
							}
						}
					}
					else if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.HorizCascade && valuePointList2.Count > 0)
					{
						for (int num7 = 0; num7 < valuePointList2.Count; num7++)
						{
							method_44(titleLineInfo_0, valuePointList2[num7], dcgraphics_0, new RectangleF(rectangleF_4.Left + (float)num7 * rectangleF_4.Width / (float)valuePointList2.Count, rectangleF_4.Top, rectangleF_4.Width / (float)valuePointList2.Count, rectangleF_4.Height), j);
						}
					}
					continue;
				}
				_ = CountDown.GetTickCountFloat() - tickCountFloat;
				break;
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private void method_43(TitleLineInfo titleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3)
		{
			XFontValue font = method_0(titleLineInfo_0, bool_3: true);
			_ = rectangleF_2.Width / (float)RuntimeNumOfDaysInOnePage;
			_ = (titleLineInfo_0.RuntimeHeight - dcgraphics_0.GetFontHeight(font)) / 2f;
			using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericTypographic.Clone())
			{
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
				int num = class159_0.method_6(rectangleF_2, rectangleF_3);
				for (int i = num; i < class159_0.Count; i++)
				{
					Class158 @class = class159_0[i];
					float num2 = rectangleF_2.Left + @class.float_0;
					if (!(num2 + @class.float_1 < rectangleF_3.Left))
					{
						if (num2 > rectangleF_3.Right || num2 >= rectangleF_2.Right - 2f)
						{
							break;
						}
						RectangleF rect = new RectangleF(num2, titleLineInfo_0.Top, @class.float_1, titleLineInfo_0.RuntimeHeight);
						Class158 class2 = class159_0[i];
						if (rectangleF_3.IntersectsWith(rect))
						{
							if (!string.IsNullOrEmpty(class2.string_0))
							{
								dcgraphics_0.DrawString(class2.string_0, font, method_24(class2.color_0), rect, drawStringFormatExt);
							}
							dcgraphics_0.DrawLine(RuntimeForeColor, rect.Left, rect.Top, rect.Left, rect.Bottom);
							if (class2.int_1 == 0)
							{
								dcgraphics_0.DrawLine(Config.BigVerticalGridLineColor, rect.Left, rect.Top, rect.Left, rect.Bottom);
							}
						}
					}
				}
			}
		}

		private void method_44(TitleLineInfo titleLineInfo_0, ValuePoint valuePoint_1, DCGraphics dcgraphics_0, RectangleF rectangleF_2, int int_6)
		{
			if (!(titleLineInfo_0.Name == "huxi"))
			{
			}
			if (dictionary_1 != null)
			{
				dictionary_1[valuePoint_1] = rectangleF_2;
			}
			valuePoint_1.ViewBounds = rectangleF_2;
			if (valuePoint_1.Color.A != 0)
			{
				dcgraphics_0.FillRectangle(valuePoint_1.Color, rectangleF_2);
				dcgraphics_0.DrawRectangle(RuntimeForeColor, rectangleF_2.Left, rectangleF_2.Top, rectangleF_2.Width, rectangleF_2.Height);
			}
			if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Cascade)
			{
				dcgraphics_0.DrawLine(RuntimeForeColor, rectangleF_2.Left, rectangleF_2.Bottom, rectangleF_2.Right, rectangleF_2.Bottom);
			}
			else if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.HorizCascade)
			{
				dcgraphics_0.DrawLine(RuntimeForeColor, rectangleF_2.Right, rectangleF_2.Top, rectangleF_2.Right, rectangleF_2.Bottom);
			}
			Class158 @class = class159_0.method_8(int_6);
			if (@class != null && @class.int_1 == 0)
			{
				dcgraphics_0.DrawLine(Config.BigVerticalGridLineColor, rectangleF_2.Left, rectangleF_2.Top, rectangleF_2.Left, rectangleF_2.Bottom);
			}
			string runtimeText = valuePoint_1.RuntimeText;
			if (!string.IsNullOrEmpty(runtimeText))
			{
				XFontValue xFontValue = method_0(titleLineInfo_0, bool_3: true);
				using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericTypographic.Clone())
				{
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
					if (titleLineInfo_0.ValueTextMultiLine)
					{
						drawStringFormatExt.FormatFlags &= ~StringFormatFlags.NoWrap;
					}
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.Alignment = titleLineInfo_0.ValueAlign;
					if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant)
					{
						if (int_6 == 0)
						{
							drawStringFormatExt.LineAlignment = StringAlignment.Far;
						}
						else
						{
							drawStringFormatExt.LineAlignment = StringAlignment.Near;
						}
					}
					else if (titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant2)
					{
						if (int_6 == 0)
						{
							drawStringFormatExt.LineAlignment = StringAlignment.Near;
						}
						else
						{
							drawStringFormatExt.LineAlignment = StringAlignment.Far;
						}
					}
					else if (titleLineInfo_0.UpAndDownTextType != 0 || titleLineInfo_0.UpAndDownText)
					{
						if (valuePoint_1.UpAndDown == ValuePointUpAndDown.None && (titleLineInfo_0.UpAndDownTextType == UpAndDownTextType.ShowByTick || titleLineInfo_0.UpAndDownText))
						{
							if (int_6 / titleLineInfo_0.TickStep % 2 == 0)
							{
								drawStringFormatExt.LineAlignment = StringAlignment.Near;
							}
							else
							{
								drawStringFormatExt.LineAlignment = StringAlignment.Far;
							}
						}
						if (valuePoint_1.UpAndDown == ValuePointUpAndDown.Up)
						{
							drawStringFormatExt.LineAlignment = StringAlignment.Near;
						}
						else if (valuePoint_1.UpAndDown == ValuePointUpAndDown.Down)
						{
							drawStringFormatExt.LineAlignment = StringAlignment.Far;
						}
					}
					Color black = Color.Black;
					black = ((titleLineInfo_0 == null) ? Config.ForeColor : ((!Class157.smethod_3(valuePoint_1.Value, titleLineInfo_0.NormalMaxValue, titleLineInfo_0.NormalMinValue)) ? titleLineInfo_0.TextColor : titleLineInfo_0.OutofNormalRangeTextColor));
					if (method_26(valuePoint_1))
					{
						black = Color.Blue;
						xFontValue.Underline = true;
					}
					dcgraphics_0.DrawString(runtimeText, xFontValue, method_24(black), new RectangleF(rectangleF_2.Left + 1f, rectangleF_2.Top + 1f, rectangleF_2.Width - 1f, rectangleF_2.Height - 2f), drawStringFormatExt);
					if (titleLineInfo_0.CircleText == runtimeText)
					{
						float num = Math.Min(dcgraphics_0.GetFontHeight(xFontValue), rectangleF_2.Width - 2f);
						RectangleF rect = new RectangleF(rectangleF_2.Left + (rectangleF_2.Width - num) / 2f, rectangleF_2.Top + 1f, num, num);
						if (drawStringFormatExt.LineAlignment == StringAlignment.Near)
						{
							rect.Y = rectangleF_2.Top + 1f;
						}
						else
						{
							rect.Y = rectangleF_2.Bottom - rect.Height - 1f;
						}
						SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
						dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
						dcgraphics_0.DrawEllipse(titleLineInfo_0?.TextColor ?? RuntimeForeColor, rect);
						dcgraphics_0.SmoothingMode = smoothingMode;
					}
				}
			}
		}

		private void method_45(DCGraphics dcgraphics_0, Image image_0, float float_8, float float_9)
		{
			_ = (float)GraphicsUnitConvert.Convert(1.0, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			dcgraphics_0.DrawImageUnscaled(image_0, (int)float_8, (int)float_9);
		}

		private void method_46(float float_8, float float_9, DCGraphics dcgraphics_0, RectangleF rectangleF_2, XFontValue xfontValue_0)
		{
			rectangleF_1 = RectangleF.Empty;
			if (HeaderLabels == null || HeaderLabels.Count == 0)
			{
				return;
			}
			foreach (HeaderLabelInfo headerLabel in HeaderLabels)
			{
				headerLabel.method_0(dcgraphics_0, xfontValue_0);
				headerLabel.Height = float_9;
			}
			if (ViewMode == DocumentViewMode.Timeline || ViewMode == DocumentViewMode.Normal)
			{
				float num = Left;
				foreach (HeaderLabelInfo headerLabel2 in HeaderLabels)
				{
					headerLabel2.Left = num;
					headerLabel2.Top = Top + float_8;
					num += headerLabel2.Width + float_9;
				}
			}
			else
			{
				float num2 = Width;
				foreach (HeaderLabelInfo headerLabel3 in HeaderLabels)
				{
					num2 -= headerLabel3.Width;
				}
				if (HeaderLabels.Count > 1)
				{
					num2 /= (float)(HeaderLabels.Count - 1);
				}
				float num = Left;
			}
			foreach (HeaderLabelInfo headerLabel4 in HeaderLabels)
			{
				if (new RectangleF(headerLabel4.Left, headerLabel4.Top, headerLabel4.Width, headerLabel4.Height).IntersectsWith(rectangleF_2))
				{
					headerLabel4.OwnerDocument = this;
					headerLabel4.method_1(dcgraphics_0, xfontValue_0, Config.ForeColor, ViewMode.ToString());
				}
			}
		}

		private void method_47(TitleLineInfo titleLineInfo_0, YAxisScaleInfoList yaxisScaleInfoList_0, ValuePointList valuePointList_0, RectangleF rectangleF_2, float float_8, float float_9, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4, bool bool_3)
		{
			int num = 12;
			if (valuePointList_0 == null || valuePointList_0.Count == 0 || dcgraphics_0 == null)
			{
				return;
			}
			XFontValue xFontValue = method_0(titleLineInfo_0, bool_3: true);
			float tickCountFloat = CountDown.GetTickCountFloat();
			rectangleF_2.Y = -1000f;
			rectangleF_2.Height = 100000f;
			ValuePoint valuePoint = null;
			Color transparent = Color.Transparent;
			_ = rectangleF_2.Width / (float)RuntimeNumOfDaysInOnePage;
			for (int num2 = valuePointList_0.Count - 1; num2 >= 0; num2--)
			{
				ValuePoint valuePoint2 = valuePointList_0[num2];
				transparent = valuePoint2.Color;
				string text = valuePoint2.Text;
				YAxisScaleInfo scaleInfoByValue = yaxisScaleInfoList_0.GetScaleInfoByValue(valuePoint2.Value);
				if (scaleInfoByValue != null)
				{
					transparent = scaleInfoByValue.Color;
					if (string.IsNullOrEmpty(text))
					{
						text = scaleInfoByValue.Text;
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					text = valuePoint2.Value.ToString();
				}
				if (class159_0.Count <= 0 || (!(valuePoint2.Time >= class159_0.method_5().dateTime_1) && !(valuePoint2.Time < class159_0.method_0())))
				{
					valuePoint2.Left = class159_0.method_16(rectangleF_2, valuePoint2.Time);
					float num3 = 0f;
					bool flag = true;
					if (titleLineInfo_0 != null)
					{
						flag = titleLineInfo_0.EnableEndTime;
					}
					if (titleLineInfo_0 == null || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Free || titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant3)
					{
						num3 = ((flag && !smethod_4(valuePoint2.EndTime)) ? (class159_0.method_16(rectangleF_2, valuePoint2.EndTime) - valuePoint2.Left) : ((valuePoint != null) ? (valuePoint.Left - valuePoint2.Left) : (rectangleF_2.Right - valuePoint2.Left)));
					}
					else if (titleLineInfo_0 != null && titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.FreeText)
					{
						num3 = ((valuePoint != null) ? (valuePoint.Left - valuePoint2.Left) : (rectangleF_2.Right - valuePoint2.Left));
					}
					if (!(num3 <= 0f))
					{
						RectangleF rectangleF = new RectangleF(valuePoint2.Left, float_8, num3, float_9);
						RectangleF rectangleF2 = rectangleF;
						rectangleF = (valuePoint2.ViewBounds = RectangleF.Intersect(rectangleF, rectangleF_2));
						RectangleF rect = rectangleF;
						RectangleF a = rectangleF;
						if (titleLineInfo_0 != null && titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.FreeText)
						{
							float num4 = GraphicsUnitConvert.Convert(titleLineInfo_0.BlockWidth, GraphicsUnit.Document, dcgraphics_0.PageUnit);
							rect.Width -= num4 + 2f;
							rect.Offset(num4 + 2f, 0f);
							a = new RectangleF(rectangleF.Left, rectangleF.Top, num4, rectangleF.Height);
						}
						if (!rectangleF.IsEmpty)
						{
							RectangleF value = RectangleF.Intersect(rectangleF, rectangleF_3);
							if (!value.IsEmpty)
							{
								if (dictionary_1 != null)
								{
									dictionary_1[valuePoint2] = value;
								}
								a = RectangleF.Intersect(a, rectangleF_3);
								if (bool_3 && !a.IsEmpty && transparent.A != 0 && transparent.ToArgb() != Color.White.ToArgb())
								{
									dcgraphics_0.FillRectangle(transparent, a);
								}
								if (titleLineInfo_0 == null || titleLineInfo_0.VerticalLineForFreeeLayout)
								{
									Color color = ControlPaint.Dark(transparent);
									using (Pen pen_ = new Pen(color))
									{
										if (titleLineInfo_0 != null && titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant3 && text.IndexOf("/") > 0)
										{
											dcgraphics_0.DrawLine(pen_, rectangleF.Right, rectangleF.Top, rectangleF.Left, rectangleF.Bottom);
										}
										if (rectangleF2.Left >= rectangleF_2.Left && rectangleF2.Left <= rectangleF_2.Right)
										{
											dcgraphics_0.DrawLine(pen_, rectangleF.Left, rectangleF.Top, rectangleF.Left, rectangleF.Bottom);
										}
										if (rectangleF2.Right >= rectangleF_2.Left && rectangleF2.Right <= rectangleF_2.Right)
										{
											dcgraphics_0.DrawLine(pen_, a.Right, a.Top, a.Right, a.Bottom);
										}
									}
								}
								if (!string.IsNullOrEmpty(text))
								{
									using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
									{
										drawStringFormatExt.Alignment = StringAlignment.Near;
										drawStringFormatExt.LineAlignment = StringAlignment.Center;
										drawStringFormatExt.FormatFlags = (drawStringFormatExt.FormatFlags | StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox);
										drawStringFormatExt.Trimming = StringTrimming.None;
										if (titleLineInfo_0 != null && titleLineInfo_0.ValueTextMultiLine)
										{
											drawStringFormatExt.FormatFlags &= ~StringFormatFlags.NoWrap;
										}
										if (titleLineInfo_0 == null || titleLineInfo_0.RuntimeLayoutType != TitleLineLayoutType.FreeText || transparent.A == 0)
										{
											transparent = (titleLineInfo_0?.TextColor ?? Config.ForeColor);
										}
										XFontValue xFontValue2 = xFontValue;
										if (method_26(valuePoint2))
										{
											transparent = Color.Blue;
											xFontValue2 = xFontValue2.Clone();
											xFontValue2.Underline = true;
										}
										if (titleLineInfo_0 != null && titleLineInfo_0.RuntimeLayoutType == TitleLineLayoutType.Slant3 && text.IndexOf("/") > 0)
										{
											string text2 = text.Substring(0, text.IndexOf("/"));
											string text3 = text.Substring(text.IndexOf("/") + 1, text.Length - text.IndexOf("/") - 1);
											RectangleF rectangleF4 = new RectangleF(0f, 0f, 0f, 0f);
											RectangleF rectangleF5 = new RectangleF(0f, 0f, 0f, 0f);
											if (ViewMode == DocumentViewMode.Normal)
											{
												if (titleLineInfo_0.TickStep != 6)
												{
													rectangleF4 = new RectangleF(valuePoint2.Left + 16f, float_8 - 4f, num3, float_9);
													rectangleF5 = new RectangleF(valuePoint2.Left + 180f, float_8 + 26f, num3 - 61f, float_9 - 22f);
												}
												else
												{
													rectangleF4 = new RectangleF(valuePoint2.Left + 2f, float_8 - 7f, num3, float_9);
													rectangleF5 = new RectangleF(valuePoint2.Left + 127f, float_8 + 24f, num3 - 61f, float_9 - 22f);
												}
											}
											else if (ViewMode == DocumentViewMode.Page)
											{
												if (titleLineInfo_0.TickStep != 6)
												{
													rectangleF4 = new RectangleF(valuePoint2.Left - 3f, float_8 - 10f, num3, float_9);
													rectangleF5 = new RectangleF(valuePoint2.Left + 70f, float_8 + 26f, num3 - 61f, float_9 - 22f);
												}
												else
												{
													rectangleF4 = new RectangleF(valuePoint2.Left - 1f, float_8 - 11f, num3, float_9);
													rectangleF5 = new RectangleF(valuePoint2.Left + 112f, float_8 + 24f, num3 - 61f, float_9 - 22f);
												}
											}
											else if (titleLineInfo_0.TickStep != 6)
											{
												rectangleF4 = new RectangleF(valuePoint2.Left - 3f, float_8 - 10f, num3, float_9);
												rectangleF5 = new RectangleF(valuePoint2.Left + 70f, float_8 + 26f, num3 - 61f, float_9 - 22f);
											}
											else
											{
												rectangleF4 = new RectangleF(valuePoint2.Left + 10f, float_8 - 8f, num3, float_9);
												rectangleF5 = new RectangleF(valuePoint2.Left + 154f, float_8 + 24f, num3 - 61f, float_9 - 22f);
											}
											dcgraphics_0.DrawString(text3, xFontValue2, method_24(transparent), rectangleF5, drawStringFormatExt);
											dcgraphics_0.DrawString(text2, xFontValue2, method_24(transparent), rectangleF4, drawStringFormatExt);
										}
										else
										{
											dcgraphics_0.DrawString(text, xFontValue2, method_24(transparent), rect, drawStringFormatExt);
										}
									}
								}
							}
						}
						valuePoint = valuePoint2;
					}
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private float method_48(int int_6)
		{
			TickInfoList ticks = Config.Ticks;
			if (ticks == null || ticks.Count == 0 || int_6 >= ticks.Count)
			{
				return 24f;
			}
			if (int_6 < 0)
			{
				return 0f;
			}
			return (ticks[int_6].Value + ticks[int_6 + 1].Value) / 2f;
		}

		private float method_49(int int_6)
		{
			TickInfoList ticks = Config.Ticks;
			if (ticks == null || ticks.Count == 0 || int_6 <= 0)
			{
				return 0f;
			}
			if (int_6 >= ticks.Count)
			{
				return 24f;
			}
			return (ticks[int_6].Value + ticks[int_6 - 1].Value) / 2f;
		}

		private void method_50(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3)
		{
			_ = RuntimeNumOfDaysInOnePage * Config.Ticks.Count;
			int num = Config.GridYSplitInfo.GridYSplitNum * Config.GridYSplitInfo.GridYSpaceNum;
			CountDown.GetTickCountFloat();
			if (rectangleF_3.IsEmpty)
			{
				rectangleF_3 = rectangleF_2;
			}
			if (Config.Zones != null)
			{
				foreach (TimeLineZoneInfo zone in Config.Zones)
				{
					zone.FirstTickItem = null;
					zone.LastTickItem = null;
					zone.Left = 0f;
					zone.Top = rectangleF_2.Top;
					zone.Width = 0f;
					zone.Height = rectangleF_2.Height;
					zone.ExpandedHandleBounds = RectangleF.Empty;
				}
			}
			Class158 @class = class159_0[0];
			TimeLineZoneInfo timeLineZoneInfo_ = @class.timeLineZoneInfo_0;
			List<float> list = new List<float>();
			for (int i = 0; i < class159_0.Count; i++)
			{
				Class158 class2 = class159_0[i];
				if (class2.timeLineZoneInfo_0 != null)
				{
					if (class2.timeLineZoneInfo_0.FirstTickItem == null)
					{
						class2.timeLineZoneInfo_0.FirstTickItem = class2;
						class2.timeLineZoneInfo_0.Left = rectangleF_2.Left + class2.float_0;
					}
					class2.timeLineZoneInfo_0.LastTickItem = class2;
					class2.timeLineZoneInfo_0.Width = rectangleF_2.Left + class2.float_0 - class2.timeLineZoneInfo_0.Left + class2.float_1;
				}
				if (class2.timeLineZoneInfo_0 == timeLineZoneInfo_ && i != class159_0.Count - 1)
				{
					continue;
				}
				Color color = Config.GridBackColor;
				Color color2 = method_24(Config.GridLineColor);
				DashStyle dashStyle = DashStyle.Solid;
				if (timeLineZoneInfo_ != null)
				{
					color = timeLineZoneInfo_.BackColor;
					color2 = timeLineZoneInfo_.GridLineColor;
					dashStyle = timeLineZoneInfo_.GridLineStyle;
				}
				RectangleF a = new RectangleF(rectangleF_2.Left + @class.float_0, rectangleF_2.Top, class2.float_0 - @class.float_0, rectangleF_2.Height);
				int num2 = i - 1;
				Class158 class3 = class159_0.method_8(i + 1);
				if (class3 != null && timeLineZoneInfo_ != null && class3.timeLineZoneInfo_0 != null)
				{
					num2 = i;
				}
				if (class2.timeLineZoneInfo_0 == timeLineZoneInfo_)
				{
					num2 = i;
					a.Width = class2.float_0 - @class.float_0 + class2.float_1;
				}
				RectangleF rect = RectangleF.Intersect(a, rectangleF_3);
				if (rect.IsEmpty)
				{
					timeLineZoneInfo_ = class2.timeLineZoneInfo_0;
					@class = class2;
					continue;
				}
				if (color.A != 0)
				{
					dcgraphics_0.FillRectangle(color, rect);
				}
				XPenStyle xPenStyle = new XPenStyle(color2, method_25(1f));
				xPenStyle.DashStyle = dashStyle;
				int num3 = class159_0.IndexOf(@class);
				bool flag = true;
				if (num3 > 0)
				{
					Class158 class4 = class159_0[num3 - 1];
					int num4 = (class4.timeLineZoneInfo_0 == null) ? (-1) : class4.timeLineZoneInfo_0.ZoneIndex;
					Class158 class5 = class159_0[num3];
					int num5 = (class5.timeLineZoneInfo_0 == null) ? (-1) : class5.timeLineZoneInfo_0.ZoneIndex;
					flag = ((num5 >= num4) ? true : false);
				}
				for (int j = num3; j <= num2; j++)
				{
					Class158 class6 = class159_0[j];
					if (xPenStyle.DashStyle != dashStyle)
					{
						xPenStyle.DashStyle = dashStyle;
					}
					if (j > 0)
					{
						Class158 class4 = class159_0[j - 1];
						if (class4.timeLineZoneInfo_0 != class6.timeLineZoneInfo_0)
						{
							xPenStyle.DashStyle = DashStyle.Solid;
						}
					}
					Class158 class7 = class159_0.method_8(j + 1);
					if (class7 != null && class7.timeLineZoneInfo_0 != class6.timeLineZoneInfo_0)
					{
						xPenStyle.DashStyle = DashStyle.Solid;
						dcgraphics_0.DrawLine(xPenStyle, rectangleF_2.Left + class6.float_0 + class6.float_1, rect.Top, rectangleF_2.Left + class6.float_0 + class6.float_1, rect.Bottom);
						xPenStyle.DashStyle = dashStyle;
					}
					float num6 = rectangleF_2.Left + class6.float_0;
					if (num6 > rect.Right + 1f)
					{
						break;
					}
					if (!(num6 + class6.float_1 < rect.Left))
					{
						if (j != num3 || flag)
						{
							dcgraphics_0.DrawLine(xPenStyle, num6, rect.Top, num6, rect.Bottom);
						}
						if (j == num2)
						{
							dcgraphics_0.DrawLine(xPenStyle, num6 + class6.float_1, rect.Top, num6 + class6.float_1, rect.Bottom);
						}
						if (class6.timeLineZoneInfo_0 == null && class6.int_1 == 0 && j != num3)
						{
							list.Add(num6);
						}
					}
				}
				xPenStyle.DashStyle = dashStyle;
				List<float> list2 = new List<float>();
				foreach (YAxisInfo yAxisInfo in YAxisInfos)
				{
					if (yAxisInfo.Visible && yAxisInfo.ValueVisible && !smethod_3(yAxisInfo.RedLineValue))
					{
						float num6 = yAxisInfo.method_3(this, rectangleF_2, yAxisInfo.RedLineValue);
						list2.Add(num6);
					}
				}
				num = (int)((float)(Config.GridYSplitInfo.GridYSplitNum * Config.GridYSplitInfo.GridYSpaceNum) / (1f - Config.DataGridBottomPadding - Config.DataGridTopPadding));
				float num7 = rectangleF_2.Top + rectangleF_2.Height * Config.DataGridTopPadding - 0.5f;
				for (int k = 0; k <= num; k++)
				{
					float num6 = rectangleF_2.Top + rectangleF_2.Height * (float)k / (float)num;
					if (num6 > rect.Bottom)
					{
						break;
					}
					if (num6 < rect.Top)
					{
						continue;
					}
					bool flag2 = false;
					foreach (float item in list2)
					{
						float num8 = item;
						if ((double)Math.Abs(num8 - num6) < 0.05)
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						continue;
					}
					if (num6 >= num7 && k >= 0 && k < num && k % Config.GridYSplitInfo.GridYSpaceNum == 0)
					{
						DashStyle dashStyle2 = xPenStyle.DashStyle;
						if (dashStyle2 != 0)
						{
							xPenStyle.Width = Config.GridYSplitInfo.ThinLineWidth;
							xPenStyle.DashStyle = DashStyle.Solid;
							dcgraphics_0.DrawLine(xPenStyle, rect.Left, num6, rect.Right, num6);
							xPenStyle.DashStyle = dashStyle2;
						}
						else
						{
							xPenStyle.Width = GraphicsUnitConvert.Convert(Config.GridYSplitInfo.ThickLineWidth, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
							dcgraphics_0.DrawLine(xPenStyle, rect.Left, num6, rect.Right, num6);
						}
					}
					else
					{
						xPenStyle.Width = Config.GridYSplitInfo.ThinLineWidth;
						dcgraphics_0.DrawLine(xPenStyle, rect.Left, num6, rect.Right, num6);
					}
				}
				timeLineZoneInfo_ = class2.timeLineZoneInfo_0;
				@class = class2;
			}
			if (Config.AllowUserCollapseZone && Config.Zones != null)
			{
				Image collapse = DCTimeLineImageResources.Collapse;
				Image expand = DCTimeLineImageResources.Expand;
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(collapse.Width, collapse.Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				float num9 = GraphicsUnitConvert.Convert(3, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				foreach (TimeLineZoneInfo zone2 in Config.Zones)
				{
					if (zone2.FirstTickItem != null)
					{
						RectangleF rect2 = zone2.ExpandedHandleBounds = new RectangleF(rectangleF_2.Left + zone2.FirstTickItem.float_0 + num9, rectangleF_2.Top + num9, sizeF.Width, sizeF.Height);
						Image image_ = zone2.IsExpanded ? expand : collapse;
						if (rectangleF_3.IntersectsWith(rect2))
						{
							DrawerUtil.DrawImageUnscaledNearestNeighbor(dcgraphics_0, image_, (int)rect2.Left, (int)rect2.Top);
						}
					}
				}
			}
			if (list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					float num6 = list[i];
					dcgraphics_0.DrawLine(Config.BigVerticalGridLineColor, method_25(2f), num6, rectangleF_2.Top, num6, rectangleF_2.Bottom);
				}
			}
		}

		private void method_51(YAxisInfo yaxisInfo_0, DCGraphics dcgraphics_0, RectangleF rectangleF_2, float float_8, DrawStringFormatExt drawStringFormatExt_3, XFontValue xfontValue_0)
		{
			yaxisInfo_0.bool_13 = true;
			RectangleF rect = new RectangleF(yaxisInfo_0.TitleLeft, rectangleF_0.Top + (float)GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), yaxisInfo_0.TitleWidth, float_8);
			Color color = yaxisInfo_0.TitleBackColor;
			if (!yaxisInfo_0.ValueVisible)
			{
				color = yaxisInfo_0.HiddenValueTitleBackColor;
			}
			if (color.A != 0)
			{
				dcgraphics_0.FillRectangle(color, yaxisInfo_0.TitleLeft + 1f, yaxisInfo_0.TitleTop + 1f, yaxisInfo_0.TitleWidth - 2f, yaxisInfo_0.TitleHeight - 2f);
			}
			if (!string.IsNullOrEmpty(yaxisInfo_0.Title))
			{
				using (DrawStringFormatExt drawStringFormatExt = drawStringFormatExt_3.Clone())
				{
					if (yaxisInfo_0.SpecifyTitleWidth > 0f)
					{
						drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
					}
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Near;
					rect.Height = dcgraphics_0.MeasureString(yaxisInfo_0.Title, xfontValue_0, (int)rect.Width, drawStringFormatExt).Height * 1.05f;
					dcgraphics_0.DrawString(yaxisInfo_0.Title, xfontValue_0, yaxisInfo_0.TitleColor, rect, drawStringFormatExt);
				}
			}
			rect.Offset(0f, rect.Height);
			if (yaxisInfo_0.ShowLegendInRule)
			{
				method_54(dcgraphics_0, rectangleF_2, rect.Left + rect.Width / 2f, rect.Top + GraphicsUnitConvert.Convert(SymbolSize, GraphicsUnit.Document, dcgraphics_0.PageUnit) / 2f, yaxisInfo_0.SymbolStyle, yaxisInfo_0.CharacterForCharSymbolStyle, yaxisInfo_0.SymbolColor, null, float.NaN, bool_3: false);
			}
			if (!string.IsNullOrEmpty(yaxisInfo_0.BottomTitle))
			{
				using (DrawStringFormatExt drawStringFormatExt = drawStringFormatExt_3.Clone())
				{
					if (yaxisInfo_0.SpecifyTitleWidth > 0f)
					{
						drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
					}
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Far;
					dcgraphics_0.DrawString(rect: new RectangleF(yaxisInfo_0.TitleLeft, yaxisInfo_0.TitleBottom - float_8, yaxisInfo_0.TitleWidth, float_8), string_0: yaxisInfo_0.BottomTitle, font: xfontValue_0, color_0: yaxisInfo_0.TitleColor, format: drawStringFormatExt);
				}
			}
			int num = yaxisInfo_0.YSplitNum;
			if (yaxisInfo_0.HasScales)
			{
				num = yaxisInfo_0.Scales.Count - 1;
				yaxisInfo_0.Scales.SortByValue();
				yaxisInfo_0.Scales.Reverse();
			}
			for (int i = 0; i <= num; i++)
			{
				RectangleF rect3 = new RectangleF(yaxisInfo_0.TitleLeft, method_27(rectangleF_0, (float)i / (float)num, yaxisInfo_0), yaxisInfo_0.TitleWidth, float_8);
				float num2 = yaxisInfo_0.MaxValue - (yaxisInfo_0.MaxValue - yaxisInfo_0.MinValue) * (float)i / (float)num;
				string value = num2.ToString();
				if (yaxisInfo_0.HasScales)
				{
					YAxisScaleInfo yAxisScaleInfo = yaxisInfo_0.Scales[i];
					num2 = yAxisScaleInfo.Value;
					rect3.Y = method_27(rectangleF_0, 1f - yAxisScaleInfo.ScaleRate, yaxisInfo_0);
					value = (string.IsNullOrEmpty(yAxisScaleInfo.Text) ? num2.ToString() : yAxisScaleInfo.Text);
				}
				if (yaxisInfo_0.Style != 0)
				{
					value = null;
				}
				if (i == 0)
				{
					if (Config.DataGridTopPadding <= 0f)
					{
						continue;
					}
					rect3.Offset(0f, (0f - float_8) / 2f);
				}
				else if (i == num)
				{
					if (!string.IsNullOrEmpty(yaxisInfo_0.BottomTitle) && Config.DataGridBottomPadding <= 0f)
					{
						continue;
					}
					if (Config.DataGridBottomPadding <= 0f)
					{
						if (num2 <= yaxisInfo_0.MinValue + (yaxisInfo_0.MaxValue - yaxisInfo_0.MinValue) * 0.08f)
						{
							rect3.Offset(0f, 0f - float_8);
						}
						else
						{
							rect3.Offset(0f, (0f - float_8) / 2f);
						}
					}
					else
					{
						rect3.Offset(0f, (0f - float_8) / 2f);
					}
				}
				else
				{
					rect3.Offset(0f, (0f - float_8) / 2f);
				}
				if (!string.IsNullOrEmpty(value))
				{
					dcgraphics_0.DrawString(value, xfontValue_0, yaxisInfo_0.TitleColor, rect3, drawStringFormatExt_3);
				}
			}
			dcgraphics_0.DrawLine(RuntimeForeColor, yaxisInfo_0.TitleLeft + yaxisInfo_0.TitleWidth, yaxisInfo_0.TitleTop, yaxisInfo_0.TitleLeft + yaxisInfo_0.TitleWidth, rectangleF_0.Bottom);
		}

		private void method_52(DCGraphics dcgraphics_0, float float_8, float float_9, bool bool_3, ValuePoint valuePoint_1, Color color_1)
		{
			if (bitmap_1 == null)
			{
				bitmap_1 = DCTimeLineImageResources.ArrowDown;
				bitmap_1.MakeTransparent(Color.Red);
				bitmap_0 = DCTimeLineImageResources.ArrowUp;
				bitmap_0.MakeTransparent(Color.Red);
			}
			SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(bitmap_0.Width, bitmap_0.Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			float num = GraphicsUnitConvert.Convert(SymbolSize, GraphicsUnit.Document, dcgraphics_0.PageUnit);
			string text = valuePoint_1.Text;
			if (string.IsNullOrEmpty(text))
			{
				text = valuePoint_1.ValueString;
			}
			XFontValue font = method_2();
			using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
			{
				drawStringFormatExt.FormatFlags = (StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
				drawStringFormatExt.Trimming = StringTrimming.None;
				SizeF sizeF2 = dcgraphics_0.MeasureString(text, font, 1000, drawStringFormatExt);
				if (bool_3)
				{
					DrawerUtil.DrawImageUnscaledNearestNeighbor(dcgraphics_0, bitmap_0, (int)(float_8 - sizeF.Width / 2f), (int)(float_9 + num * 1f));
					RectangleF rect = new RectangleF(float_8 - sizeF2.Width / 2f, (int)((double)(float_9 + num * 1f) + (double)sizeF.Height * 1.1), sizeF2.Width + 1f, sizeF2.Height);
					if (color_1.A != 0)
					{
						dcgraphics_0.FillRectangle(color_1, rect);
					}
					dcgraphics_0.DrawString(text, font, Config.ForeColor, rect, drawStringFormatExt);
				}
				else
				{
					DrawerUtil.DrawImageUnscaledNearestNeighbor(dcgraphics_0, bitmap_1, (int)(float_8 - sizeF.Width / 2f), (int)(float_9 - num * 1f - sizeF.Height));
					RectangleF rect = new RectangleF(float_8 - sizeF2.Width / 2f, (int)((double)float_9 - (double)num * 1.0 - (double)sizeF.Height * 1.1 - (double)sizeF2.Height), sizeF2.Width + 1f, sizeF2.Height);
					dcgraphics_0.FillRectangle(Color.White, rect);
					dcgraphics_0.DrawString(text, font, RuntimeForeColor, rect, drawStringFormatExt);
				}
			}
		}

		internal Bitmap method_53(YAxisInfo yaxisInfo_0)
		{
			Bitmap bitmap = new Bitmap(16, 16);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.White);
				float num = GraphicsUnitConvert.Convert(16, GraphicsUnit.Pixel, GraphicsUnit.Document);
				graphics.PageUnit = GraphicsUnit.Document;
				method_54(new DCGraphics(graphics), new RectangleF(0f, 0f, num, num), num / 2f, num / 2f, yaxisInfo_0.SymbolStyle, yaxisInfo_0.CharacterForCharSymbolStyle, yaxisInfo_0.SymbolColor, null, num / 2f, bool_3: false);
			}
			return bitmap;
		}

		private void method_54(DCGraphics dcgraphics_0, RectangleF rectangleF_2, float float_8, float float_9, ValuePointSymbolStyle valuePointSymbolStyle_0, char char_0, Color color_1, ValuePoint valuePoint_1, float float_10, bool bool_3)
		{
			color_1 = method_24(color_1);
			float num = GraphicsUnitConvert.Convert(float.IsNaN(float_10) ? SymbolSize : float_10, GraphicsUnit.Document, dcgraphics_0.PageUnit);
			RectangleF rectangleF = new RectangleF(float_8 - num / 2f, float_9 - num / 2f, num, num);
			float num2 = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			string text = char_0.ToString();
			RectangleF rect = new RectangleF(rectangleF.Left + 1f, rectangleF.Top - 2f, rectangleF.Width - 1f, rectangleF.Height - 2f);
			if (valuePoint_1 != null)
			{
				valuePoint_1.ViewBounds = rectangleF;
			}
			if (rectangleF_2.IsEmpty || !rectangleF_2.IntersectsWith(rectangleF))
			{
				return;
			}
			if (dictionary_1 != null && valuePoint_1 != null)
			{
				dictionary_1[valuePoint_1] = rectangleF;
			}
			if (valuePoint_1 != null && valuePoint_1.SpecifySymbolStyle != ValuePointSymbolStyle.Default)
			{
				if (bool_3)
				{
					text = valuePoint_1.CharacterForLanternSymbolStyle.ToString();
					valuePointSymbolStyle_0 = valuePoint_1.SpecifyLanternSymbolStyle;
				}
				else
				{
					text = valuePoint_1.CharacterForCharSymbolStyle.ToString();
					valuePointSymbolStyle_0 = valuePoint_1.SpecifySymbolStyle;
				}
			}
			if (valuePoint_1 != null && valuePoint_1.CustomImage != null)
			{
				dcgraphics_0.DrawImage(valuePoint_1.CustomImage.Value, new Rectangle((int)rectangleF.Left, (int)rectangleF.Top, valuePoint_1.CustomImage.Width * 3, valuePoint_1.CustomImage.Height * 3));
			}
			else if (valuePointSymbolStyle_0 != 0)
			{
				SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
				dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				switch (valuePointSymbolStyle_0)
				{
				case ValuePointSymbolStyle.SolidCicle:
					dcgraphics_0.FillEllipse(color_1, rectangleF);
					break;
				case ValuePointSymbolStyle.HollowCicle:
					dcgraphics_0.DrawEllipse(color_1, num2, rectangleF);
					break;
				case ValuePointSymbolStyle.Cross:
					dcgraphics_0.DrawLine(color_1, num2, rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
					dcgraphics_0.DrawLine(color_1, num2, rectangleF.Left, rectangleF.Bottom, rectangleF.Right, rectangleF.Top);
					break;
				case ValuePointSymbolStyle.Square:
					dcgraphics_0.FillRectangle(color_1, rectangleF);
					break;
				case ValuePointSymbolStyle.HollowSquare:
					dcgraphics_0.DrawRectangle(color_1, num2, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
					break;
				case ValuePointSymbolStyle.Diamond:
				{
					PointF[] points = new PointF[5]
					{
						new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top),
						new PointF(rectangleF.Right, rectangleF.Top + rectangleF.Height / 2f),
						new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Bottom),
						new PointF(rectangleF.Left, rectangleF.Top + rectangleF.Height / 2f),
						new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top)
					};
					dcgraphics_0.FillPolygon(color_1, points);
					break;
				}
				case ValuePointSymbolStyle.HollowDiamond:
				{
					PointF[] points = new PointF[5]
					{
						new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top),
						new PointF(rectangleF.Right, rectangleF.Top + rectangleF.Height / 2f),
						new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Bottom),
						new PointF(rectangleF.Left, rectangleF.Top + rectangleF.Height / 2f),
						new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top)
					};
					dcgraphics_0.DrawPolygon(color_1, num2, points);
					break;
				}
				case ValuePointSymbolStyle.V:
				{
					PointF[] points = new PointF[3]
					{
						new PointF(rectangleF.Left, rectangleF.Top),
						new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height / 2f),
						new PointF(rectangleF.Right, rectangleF.Top)
					};
					dcgraphics_0.DrawLines(color_1, num2, points);
					break;
				}
				case ValuePointSymbolStyle.VReversed:
				{
					PointF[] points = new PointF[3]
					{
						new PointF(rectangleF.Left, rectangleF.Bottom),
						new PointF(rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height / 2f),
						new PointF(rectangleF.Right, rectangleF.Bottom)
					};
					dcgraphics_0.DrawLines(color_1, num2, points);
					break;
				}
				case ValuePointSymbolStyle.Character:
					dcgraphics_0.DrawString(text, new XFontValue(), method_24(color_1), rect, DrawStringFormatExt.GenericTypographic);
					break;
				case ValuePointSymbolStyle.CharacterCircle:
				{
					dcgraphics_0.DrawString(text, new XFontValue(), method_24(color_1), rect, DrawStringFormatExt.GenericTypographic);
					float num3 = Math.Min(dcgraphics_0.GetFontHeight(new XFontValue()), rect.Width - 2f);
					RectangleF rect2 = new RectangleF(rect.Left - rect.Width / 2f, rectangleF.Top - (rectangleF.Height - num3) / 2f, num3 * 2f, num3 * 2f);
					SmoothingMode smoothingMode2 = dcgraphics_0.SmoothingMode;
					dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
					dcgraphics_0.DrawEllipse(color_1, rect2);
					dcgraphics_0.SmoothingMode = smoothingMode2;
					break;
				}
				}
				dcgraphics_0.SmoothingMode = smoothingMode;
			}
		}

		/// <summary>
		///       保存文档到文件流中
		///       </summary>
		/// <param name="stream">文件流</param>
		[ComVisible(false)]
		public void Save(Stream stream)
		{
			int num = 18;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(stream, this);
		}

		/// <summary>
		///       保存文档到文本书写器中
		///       </summary>
		/// <param name="writer">文本书写器</param>
		[ComVisible(false)]
		public void Save(TextWriter writer)
		{
			int num = 10;
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(writer, this);
		}

		/// <summary>
		///       保存文件
		///       </summary>
		/// <param name="fileName">文件名</param>
		[ComVisible(true)]
		public void SaveToFile(string fileName)
		{
			int num = 10;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				xmlSerializer.Serialize(stream, this);
			}
		}

		/// <summary>
		///       保存文档到字符串中
		///       </summary>
		/// <returns>生成的字符串</returns>
		[ComVisible(true)]
		public string SaveToString()
		{
			StringWriter stringWriter = new StringWriter();
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(stringWriter, this);
			return stringWriter.ToString();
		}

		/// <summary>
		///       从文件中加载文档对象
		///       </summary>
		/// <param name="fileName">文件名</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		public bool LoadFromFile(string fileName)
		{
			int num = 5;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				return Load(stream);
			}
		}

		/// <summary>
		///       从文件流中加载文档数据
		///       </summary>
		/// <param name="stream">文件流</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(false)]
		public bool Load(Stream stream)
		{
			int num = 3;
			try
			{
				if (stream == null)
				{
					throw new ArgumentNullException("stream");
				}
				XmlSerializer xmlSerializer = new XmlSerializer(GetType());
				TemperatureDocument temperatureDocument = (TemperatureDocument)xmlSerializer.Deserialize(stream);
				if (temperatureDocument != null)
				{
					temperatureDocument.method_55(this);
					return true;
				}
			}
			catch
			{
				MessageBox.Show("XML文档有错误，请检查！");
				return false;
			}
			return false;
		}

		/// <summary>
		///       从文件读取器中加载文档数据
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(false)]
		public bool Load(TextReader reader)
		{
			int num = 19;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			TemperatureDocument temperatureDocument = (TemperatureDocument)xmlSerializer.Deserialize(reader);
			if (temperatureDocument != null)
			{
				temperatureDocument.method_55(this);
				return true;
			}
			return false;
		}

		/// <summary>
		///       从字符串中加载数据
		///       </summary>
		/// <param name="xml">XML字符串</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		public bool LoadFromString(string string_1)
		{
			int num = 1;
			if (string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("xml");
			}
			using (StringReader reader = new StringReader(string_1))
			{
				return Load(reader);
			}
		}

		private void method_55(TemperatureDocument temperatureDocument_0)
		{
			temperatureDocument_0.temperatureDocumentConfig_0 = temperatureDocumentConfig_0;
			temperatureDocument_0.documentDataList_0 = documentDataList_0;
			temperatureDocument_0.int_4 = int_4;
			temperatureDocument_0.float_0 = float_0;
			temperatureDocument_0.float_1 = float_1;
			temperatureDocument_0.float_2 = float_2;
			temperatureDocument_0.float_3 = float_3;
			temperatureDocument_0.color_0 = color_0;
			temperatureDocument_0.int_3 = int_3;
			temperatureDocument_0.documentViewMode_0 = documentViewMode_0;
			temperatureDocument_0.dctimeLineParameterList_0 = dctimeLineParameterList_0;
			temperatureDocument_0.LayoutInvalidate = true;
		}

		/// <summary>
		///       保存数据HTML
		///       </summary>
		/// <param name="stream">文件流</param>
		public void SaveDataHtml(Stream stream)
		{
			int num = 15;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			StreamWriter streamWriter = new StreamWriter(stream, Encoding.Default);
			streamWriter.WriteLine("<html><body>");
			streamWriter.WriteLine(method_4());
			streamWriter.WriteLine("</body><//html>");
		}
	}
}
