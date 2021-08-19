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

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///        产程图信息文档对象
	///        </summary>
	/// <remarks>
	/// </remarks>
	[Serializable]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("FD6B6978-B2DE-48F4-98BD-6BE03A4C8D58")]
	[DCPublishAPI]
	[DocumentComment]
	[ComDefaultInterface(typeof(IFriedmanCurveDocument))]
	public class FriedmanCurveDocument : IFriedmanCurveDocument
	{
		internal enum Enum5
		{
			const_0,
			const_1,
			const_2
		}

		private class Class48
		{
		}

		internal const int int_0 = 32;

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

		private RectangleF rectangleF_0 = RectangleF.Empty;

		private DateTime dateTime_0 = DateTime.MinValue;

		private DateTime dateTime_1 = DateTime.MinValue;

		private float float_0 = 0f;

		private FCYAxisInfoList fcyaxisInfoList_0 = new FCYAxisInfoList();

		private FCYAxisInfoList fcyaxisInfoList_1 = new FCYAxisInfoList();

		private bool bool_0 = true;

		[XmlIgnore]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public EventHandler eventHandler_0 = null;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		private bool bool_1 = false;

		[NonSerialized]
		private FCValuePoint fcvaluePoint_0 = null;

		[NonSerialized]
		internal Dictionary<FCValuePoint, RectangleF> dictionary_0 = null;

		private float float_1 = 0f;

		private static DrawStringFormatExt drawStringFormatExt_1 = null;

		private float float_2 = 0f;

		internal RectangleF rectangleF_1 = RectangleF.Empty;

		private static Bitmap bitmap_0 = null;

		private static Bitmap bitmap_1 = null;

		private DateTime dateTime_2 = NullDate;

		private DCFriedmanCurveParameterList dcfriedmanCurveParameterList_0 = new DCFriedmanCurveParameterList();

		private FCDocumentDataList fcdocumentDataList_0 = new FCDocumentDataList();

		[NonSerialized]
		private FCTitleLineInfoList fctitleLineInfoList_0 = null;

		[NonSerialized]
		private FCTitleLineInfoList fctitleLineInfoList_1 = null;

		[NonSerialized]
		private Hashtable hashtable_0 = new Hashtable();

		private int int_1 = 0;

		[NonSerialized]
		private Class165 class165_0 = null;

		private DateTime dateTime_3 = NullDate;

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private static int int_2 = 0;

		private int int_3 = int_2++;

		private Enum19 enum19_0 = Enum19.const_0;

		private bool bool_2 = false;

		private FriedmanCurveDocumentConfig friedmanCurveDocumentConfig_0 = null;

		private float float_3 = 0f;

		private float float_4 = 0f;

		private float float_5 = 750f;

		private float float_6 = 1020f;

		private Color color_0 = Color.Transparent;

		private FCDocumentViewMode fcdocumentViewMode_0 = FCDocumentViewMode.Page;

		private int int_4 = 0;

		internal int int_5 = 0;

		private float float_7 = 0f;

		[NonSerialized]
		private object object_0 = null;

		/// <summary>
		///       表示空的日期
		///       </summary>
		public static DateTime NullDate = new DateTime(1900, 1, 1);

		private static Random random_0 = new Random();

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
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlIgnore]
		public string RegisterCode
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
		///       判断控件是否已经注册了
		///       </summary>
		internal static bool IsRegistered => smethod_0(null)?.method_6() ?? false;

		internal GraphicsUnit GraphicsUnit => GraphicsUnit.Document;

		/// <summary>
		///       数据网格区域
		///       </summary>
		internal RectangleF DataGridBounds => rectangleF_0;

		/// <summary>
		///       可见的Y刻度尺信息对象列表
		///       </summary>
		internal FCYAxisInfoList VisibleYAxisInfos
		{
			get
			{
				return fcyaxisInfoList_0;
			}
			set
			{
				fcyaxisInfoList_0 = value;
			}
		}

		/// <summary>
		///       文档内容布局无效，需要重新计算布局
		///       </summary>
		internal bool LayoutInvalidate
		{
			get
			{
				return bool_0;
			}
			set
			{
				if (bool_0 != value)
				{
					bool_0 = value;
					if (bool_0)
					{
						fctitleLineInfoList_1 = null;
						fctitleLineInfoList_0 = null;
					}
				}
			}
		}

		/// <summary>
		///       绘制坐标网格中文本标签使用的格式化对象
		///       </summary>
		private DrawStringFormatExt StringFormatForYAxisLabelValue
		{
			get
			{
				if (drawStringFormatExt_0 == null)
				{
					drawStringFormatExt_0 = DrawStringFormatExt.GenericDefault.Clone();
					drawStringFormatExt_0.FormatFlags = (StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap);
					drawStringFormatExt_0.Alignment = StringAlignment.Near;
					drawStringFormatExt_0.LineAlignment = StringAlignment.Center;
					drawStringFormatExt_0.Trimming = StringTrimming.None;
				}
				return drawStringFormatExt_0;
			}
		}

		/// <summary>
		///       正在打印模式
		///       </summary>
		internal bool PrintingMode
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
		///       鼠标悬停的数据点
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		internal FCValuePoint MouseHoverValuePoint
		{
			get
			{
				return fcvaluePoint_0;
			}
			set
			{
				fcvaluePoint_0 = value;
			}
		}

		/// <summary>
		///       文档左侧标题栏宽度
		///       </summary>
		[Browsable(false)]
		private float LeftHeaderWidth => float_1;

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
				if (drawStringFormatExt_1 == null)
				{
					drawStringFormatExt_1 = new DrawStringFormatExt();
					drawStringFormatExt_1.Alignment = StringAlignment.Near;
					drawStringFormatExt_1.LineAlignment = StringAlignment.Center;
					drawStringFormatExt_1.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
				}
				return drawStringFormatExt_1;
			}
		}

		/// <summary>
		///       一个最小时间刻度的宽度
		///       </summary>
		public float TickViewWidth => float_2;

		/// <summary>
		///       获得前景色的画笔对象
		///       </summary>
		/// <returns>
		/// </returns>
		private Pen ForePen => GClass438.smethod_1(method_8(Config.ForeColor));

		private Color RuntimeForeColor => method_8(Config.ForeColor);

		/// <summary>
		///       获得前景色的画刷对象
		///       </summary>
		/// <returns>
		/// </returns>
		private SolidBrush ForeBrush => GClass438.smethod_0(method_8(Config.ForeColor));

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
		[XmlArrayItem("Parameter", typeof(DCFriedmanCurveParameter))]
		public DCFriedmanCurveParameterList Parameters
		{
			get
			{
				if (dcfriedmanCurveParameterList_0 == null)
				{
					dcfriedmanCurveParameterList_0 = new DCFriedmanCurveParameterList();
				}
				return dcfriedmanCurveParameterList_0;
			}
			set
			{
				dcfriedmanCurveParameterList_0 = value;
			}
		}

		/// <summary>
		///       数值
		///       </summary>
		[DefaultValue(null)]
		[XmlArrayItem("Data", typeof(FCDocumentData))]
		public FCDocumentDataList Datas
		{
			get
			{
				if (fcdocumentDataList_0 == null)
				{
					fcdocumentDataList_0 = new FCDocumentDataList();
				}
				return fcdocumentDataList_0;
			}
			set
			{
				fcdocumentDataList_0 = value;
			}
		}

		/// <summary>
		///       每页显示的小时数
		///       </summary>
		[DefaultValue(7)]
		[XmlIgnore]
		public int NumOfHoursInOnePage
		{
			get
			{
				return Config.NumOfHoursInOnePage;
			}
			set
			{
				Config.NumOfHoursInOnePage = value;
			}
		}

		private int RuntimeNumOfHoursInOnePage
		{
			get
			{
				if (ViewMode == FCDocumentViewMode.FriedmanCurve)
				{
					if (Days <= 0)
					{
						return NumOfHoursInOnePage;
					}
					return Days;
				}
				return NumOfHoursInOnePage;
			}
		}

		/// <summary>
		///       标题行信息
		///       </summary>
		[XmlIgnore]
		public FCTitleLineInfoList HeaderLines
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
		internal FCTitleLineInfoList RuntimeHeaderLines
		{
			get
			{
				if (InnerBehaviorMode == Enum19.const_1)
				{
					return Config.HeaderLines;
				}
				if (fctitleLineInfoList_0 == null)
				{
					fctitleLineInfoList_0 = Config.HeaderLines.GetRuntimeInfos();
				}
				return fctitleLineInfoList_0;
			}
		}

		/// <summary>
		///       页脚行信息
		///       </summary>
		[XmlIgnore]
		public FCTitleLineInfoList FooterLines
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
		internal FCTitleLineInfoList RuntimeFooterLines
		{
			get
			{
				if (InnerBehaviorMode == Enum19.const_1)
				{
					return Config.FooterLines;
				}
				if (fctitleLineInfoList_1 == null)
				{
					fctitleLineInfoList_1 = Config.FooterLines.GetRuntimeInfos();
				}
				return fctitleLineInfoList_1;
			}
		}

		/// <summary>
		///       Y坐标轴信息列表
		///       </summary>
		[XmlIgnore]
		public FCYAxisInfoList YAxisInfos
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
		public int Days => int_1;

		/// <summary>
		///       运行时使用的时间刻度列表
		///       </summary>
		internal Class165 RuntimeTicks => class165_0;

		/// <summary>
		///       SQL查询使用的参数列表
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public Dictionary<string, object> SQLParameters
		{
			get
			{
				if (dictionary_1 == null)
				{
					dictionary_1 = new Dictionary<string, object>();
				}
				return dictionary_1;
			}
			set
			{
				dictionary_1 = value;
			}
		}

		/// <summary>
		///       程序集是否混淆加密
		///       </summary>
		[Browsable(false)]
		public static bool IsAssemblyObfuscation => typeof(Class48).Name != "TempClass";

		/// <summary>
		///       对象实例编号
		///       </summary>
		public int InstanceIndex => int_3;

		/// <summary>
		///       文档行为模式
		///       </summary>
		internal Enum19 InnerBehaviorMode
		{
			get
			{
				return enum19_0;
			}
			set
			{
				enum19_0 = value;
			}
		}

		/// <summary>
		///       文档数据是否发生改变标记
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[Browsable(false)]
		public bool Modified
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
		///       文档配置
		///       </summary>
		[DefaultValue(null)]
		public FriedmanCurveDocumentConfig Config
		{
			get
			{
				if (friedmanCurveDocumentConfig_0 == null)
				{
					friedmanCurveDocumentConfig_0 = new FriedmanCurveDocumentConfig();
					friedmanCurveDocumentConfig_0.CheckDefaultTicks();
				}
				return friedmanCurveDocumentConfig_0;
			}
			set
			{
				friedmanCurveDocumentConfig_0 = value;
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
		///       右端坐标
		///       </summary>
		[Browsable(false)]
		public float Right => float_3 + float_5;

		/// <summary>
		///       顶端位置
		///       </summary>
		[XmlIgnore]
		[DefaultValue(0)]
		public float Top
		{
			get
			{
				return float_4;
			}
			set
			{
				if (float_4 != value)
				{
					LayoutInvalidate = true;
					float_4 = value;
				}
			}
		}

		/// <summary>
		///       下端坐标
		///       </summary>
		[Browsable(false)]
		public float Bottom => float_4 + float_6;

		/// <summary>
		///       宽度
		///       </summary>
		[XmlIgnore]
		[DefaultValue(750)]
		public float Width
		{
			get
			{
				return float_5;
			}
			set
			{
				if (float_5 != value)
				{
					LayoutInvalidate = true;
					float_5 = value;
				}
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		[XmlIgnore]
		[DefaultValue(1020)]
		public float Height
		{
			get
			{
				return float_6;
			}
			set
			{
				if (float_6 != value)
				{
					LayoutInvalidate = true;
					float_6 = value;
				}
			}
		}

		/// <summary>
		///       边界
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public RectangleF Bounds
		{
			get
			{
				return new RectangleF(float_3, float_4, float_5, float_6);
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
		[XmlIgnore]
		[DefaultValue(8)]
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
		[XmlIgnore]
		[DefaultValue(20f)]
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
		[XmlIgnore]
		[DefaultValue("宋体")]
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
		[DefaultValue(9f)]
		[XmlIgnore]
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
		[XmlIgnore]
		[DefaultValue("yyyy-MM-dd")]
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
		[DefaultValue(null)]
		[XmlIgnore]
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
		[XmlIgnore]
		[XmlArrayItem("Label", typeof(FCHeaderLabelInfo))]
		public FCHeaderLabelInfoList HeaderLabels
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
		[DefaultValue(FCDocumentViewMode.Page)]
		[XmlIgnore]
		public FCDocumentViewMode ViewMode
		{
			get
			{
				return fcdocumentViewMode_0;
			}
			set
			{
				if (fcdocumentViewMode_0 != value)
				{
					fcdocumentViewMode_0 = value;
					LayoutInvalidate = true;
				}
			}
		}

		/// <summary>
		///       从0开始计算的当前页号
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public int PageIndex
		{
			get
			{
				return int_4;
			}
			set
			{
				if (int_4 != value)
				{
					int_4 = value;
					if (ViewMode == FCDocumentViewMode.Normal || ViewMode == FCDocumentViewMode.Page)
					{
						LayoutInvalidate = true;
						foreach (FCYAxisInfo yAxisInfo in YAxisInfos)
						{
							foreach (FCValuePoint item in method_40(yAxisInfo.Name))
							{
								item.Left = float.NaN;
								item.Top = float.NaN;
								item.Width = 0f;
								item.Height = 0f;
							}
						}
						foreach (FCTitleLineInfo footerLine in FooterLines)
						{
							foreach (FCValuePoint item2 in method_40(footerLine.Name))
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
				if (ViewMode == FCDocumentViewMode.FriedmanCurve)
				{
					return 0;
				}
				if (int_4 < 0)
				{
					return 0;
				}
				if (int_4 >= NumOfPages)
				{
					return NumOfPages - 1;
				}
				return int_4;
			}
		}

		/// <summary>
		///       总页数
		///       </summary>
		[Browsable(false)]
		public int NumOfPages => int_5;

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
				FriedmanCurveDocumentConfig friedmanCurveDocumentConfig = (FriedmanCurveDocumentConfig)XMLHelper.LoadObjectFromXMLString(typeof(FriedmanCurveDocumentConfig), value);
				if (friedmanCurveDocumentConfig != null)
				{
					Config = friedmanCurveDocumentConfig;
					int_4 = 0;
				}
			}
		}

		/// <summary>
		///       设置、获得包含文档数据的XML字符串
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
					((FriedmanCurveDocument)XMLHelper.LoadObjectFromXMLString(typeof(FriedmanCurveDocument), value))?.method_7(this);
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
					((FriedmanCurveDocument)XMLHelper.LoadObjectFromXMLString(typeof(FriedmanCurveDocument), value))?.method_7(this);
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

		internal static GClass472 smethod_0(FriedmanCurveDocument friedmanCurveDocument_0)
		{
			if (gdelegate24_0 != null)
			{
				object obj = gdelegate24_0(friedmanCurveDocument_0, typeof(FriedmanCurveDocument), 32);
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

		internal float method_0(float float_8)
		{
			return GraphicsUnitConvert.Convert(float_8, GraphicsUnit.Pixel, GraphicsUnit);
		}

		internal float method_1(float float_8)
		{
			return GraphicsUnitConvert.Convert(float_8, GraphicsUnit, GraphicsUnit.Pixel);
		}

		private void method_2(DCGraphics dcgraphics_0)
		{
			if (LayoutInvalidate)
			{
				LayoutInvalidate = false;
				method_4(dcgraphics_0);
			}
		}

		internal void method_3()
		{
			if (InnerBehaviorMode == Enum19.const_1)
			{
				fcyaxisInfoList_0 = YAxisInfos;
				return;
			}
			fcyaxisInfoList_0 = new FCYAxisInfoList();
			foreach (FCYAxisInfo yAxisInfo in YAxisInfos)
			{
				if (yAxisInfo.Visible)
				{
					bool flag = false;
					foreach (FCYAxisInfo yAxisInfo2 in YAxisInfos)
					{
						if (yAxisInfo2.ShadowName == yAxisInfo.Name && !yAxisInfo2.Visible)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						fcyaxisInfoList_0.Add(yAxisInfo);
					}
				}
			}
		}

		internal float method_4(DCGraphics dcgraphics_0)
		{
			int num = 18;
			if (dcgraphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			lock (this)
			{
				dcgraphics_0.PageUnit = GraphicsUnit;
				fctitleLineInfoList_0 = null;
				fctitleLineInfoList_1 = null;
				bool_0 = false;
				float_1 = 0f;
				float tickCountFloat = CountDown.GetTickCountFloat();
				float tickCountFloat2 = CountDown.GetTickCountFloat();
				float num2 = tickCountFloat2;
				Config.CheckDefaultTicks();
				dateTime_1 = NullDate;
				DateTime minDate = NullDate;
				UpdateNumOfPage(out dateTime_1, out minDate);
				tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
				float tickCountFloat3 = CountDown.GetTickCountFloat();
				foreach (FCDocumentData data in Datas)
				{
					foreach (FCValuePoint value in data.Values)
					{
						value.OwnerList = data.Values;
						value.Visible = false;
						value.Left = float.NaN;
						value.Top = float.NaN;
						value.ViewBounds = Rectangle.Empty;
						value.HollowCovertFlag = false;
					}
				}
				method_3();
				foreach (FCTitleLineInfo runtimeHeaderLine in RuntimeHeaderLines)
				{
					runtimeHeaderLine.Top = 0f;
					runtimeHeaderLine.Height = 0f;
					List<DateTime> list = new List<DateTime>();
					if (list.Count > 0)
					{
						runtimeHeaderLine._RuntimeStartDates = list.ToArray();
					}
					else
					{
						runtimeHeaderLine._RuntimeStartDates = null;
					}
				}
				foreach (FCYAxisInfo item in fcyaxisInfoList_0)
				{
					item.ShadowInfo = null;
					foreach (FCValuePoint item2 in method_40(item.Name))
					{
						item2.ShadowPoint = null;
						item2.Parent = item;
					}
				}
				foreach (FCTitleLineInfo runtimeHeaderLine2 in RuntimeHeaderLines)
				{
					runtimeHeaderLine2.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					foreach (FCValuePoint item3 in method_40(runtimeHeaderLine2.Name))
					{
						item3.Parent = runtimeHeaderLine2;
					}
				}
				foreach (FCTitleLineInfo runtimeFooterLine in RuntimeFooterLines)
				{
					runtimeFooterLine.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					foreach (FCValuePoint item4 in method_40(runtimeFooterLine.Name))
					{
						item4.Parent = runtimeFooterLine;
					}
				}
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				tickCountFloat3 = CountDown.GetTickCountFloat();
				fcyaxisInfoList_1 = new FCYAxisInfoList();
				foreach (FCYAxisInfo item5 in fcyaxisInfoList_0)
				{
					item5.method_0(this);
					if (!string.IsNullOrEmpty(item5.Name))
					{
						bool flag = false;
						foreach (FCYAxisInfo item6 in fcyaxisInfoList_0)
						{
							if (item5.Name == item6.ShadowName && item5 != item6)
							{
								float tickCountFloat4 = CountDown.GetTickCountFloat();
								item6.ShadowInfo = item5;
								FCValuePointList fCValuePointList = method_40(item6.Name);
								FCValuePointList fCValuePointList2 = method_40(item5.Name);
								int num3 = 0;
								foreach (FCValuePoint item7 in fCValuePointList)
								{
									for (int i = num3; i < fCValuePointList2.Count; i++)
									{
										FCValuePoint fCValuePoint = fCValuePointList2[i];
										if (Math.Abs(item7.Time.Subtract(fCValuePoint.Time).TotalSeconds) < (double)ShadowPointDetectSeconds)
										{
											item7.ShadowPoint = fCValuePoint;
											num3 = i;
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
					if (item5.Style == FCYAxisInfoStyle.Value)
					{
						fcyaxisInfoList_1.Add(item5);
					}
				}
				if (InnerBehaviorMode == Enum19.const_1)
				{
					fcyaxisInfoList_1 = YAxisInfos;
				}
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				XFontValue xFontValue = method_47();
				foreach (FCYAxisInfo yAxisInfo in YAxisInfos)
				{
					yAxisInfo.TitleWidth = 0f;
					yAxisInfo.TitleWidth = 0f;
				}
				float num4 = 0f;
				if (fcyaxisInfoList_1.Count > 0)
				{
					fcyaxisInfoList_1[0].MergeIntoLeft = false;
				}
				FCYAxisInfoList fCYAxisInfoList = new FCYAxisInfoList();
				foreach (FCYAxisInfo item8 in fcyaxisInfoList_1)
				{
					item8.FixTopHeightForPadding = false;
					if (item8.SpecifyTitleWidth == 0f)
					{
						string text = item8.Title;
						if (string.IsNullOrEmpty(text))
						{
							text = "HHHH";
						}
						SizeF sizeF = dcgraphics_0.MeasureString(text, xFontValue);
						if (!string.IsNullOrEmpty(item8.BottomTitle))
						{
							sizeF.Width = Math.Max(val2: dcgraphics_0.MeasureString(item8.BottomTitle, xFontValue).Width, val1: sizeF.Width);
						}
						item8.TitleWidth = sizeF.Width * 1.1f;
					}
					else
					{
						item8.TitleWidth = item8.SpecifyTitleWidth;
					}
					if (item8.MergeIntoLeft)
					{
						FCYAxisInfo lastInfo = fCYAxisInfoList.LastInfo;
						lastInfo.FixTopHeightForPadding = true;
						item8.FixTopHeightForPadding = true;
						item8.TitleLeft = lastInfo.TitleLeft;
						float num7 = item8.TitleWidth = (lastInfo.TitleWidth = Math.Max(item8.TitleWidth, lastInfo.TitleWidth));
					}
					else
					{
						item8.TitleLeft = fCYAxisInfoList.TotalTitleWidth + Left;
					}
					fCYAxisInfoList.Add(item8);
				}
				num4 = fCYAxisInfoList.TotalTitleWidth;
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				List<FCTitleLineInfo> list2 = new List<FCTitleLineInfo>();
				foreach (FCTitleLineInfo runtimeHeaderLine3 in RuntimeHeaderLines)
				{
					list2.Add(runtimeHeaderLine3);
				}
				foreach (FCTitleLineInfo runtimeFooterLine2 in RuntimeFooterLines)
				{
					list2.Add(runtimeFooterLine2);
				}
				float num8 = num4;
				foreach (FCTitleLineInfo item9 in list2)
				{
					if (item9.SpecifyTitleWidth <= 0f)
					{
						if (!string.IsNullOrEmpty(item9.Title))
						{
							num8 = Math.Max(num8, dcgraphics_0.MeasureString(item9.Title, xFontValue).Width);
						}
					}
					else
					{
						num8 = Math.Max(num8, item9.SpecifyTitleWidth);
					}
				}
				if (num8 > num4)
				{
					float num9 = Left;
					foreach (FCYAxisInfo item10 in fcyaxisInfoList_1)
					{
						item10.TitleLeft = num9;
						item10.TitleWidth += (num8 - num4) / (float)fcyaxisInfoList_1.Count;
						if (!item10.MergeIntoLeft)
						{
							num9 += item10.TitleWidth;
						}
					}
				}
				float_1 = num8;
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				rectangleF_0 = RectangleF.Empty;
				rectangleF_0.X = Left + num8;
				rectangleF_0.Width = Width - num8;
				float num10 = rectangleF_0.Width / (float)RuntimeNumOfHoursInOnePage;
				if (Config.Ticks.Count > 0)
				{
					float_2 = num10 / (float)Config.Ticks.Count;
				}
				else
				{
					float_2 = num10;
				}
				dateTime_0 = minDate.AddDays(RuntimePageIndex * RuntimeNumOfHoursInOnePage);
				dateTime_1 = dateTime_0.AddDays(RuntimeNumOfHoursInOnePage);
				method_43(dateTime_0, dateTime_1, minDate, (ViewMode != FCDocumentViewMode.FriedmanCurve) ? (RuntimeNumOfHoursInOnePage * Config.Ticks.Count) : 0);
				float_0 = dcgraphics_0.GetFontHeight(xFontValue) * 1.5f;
				float num11 = 0f;
				foreach (FCTitleLineInfo runtimeHeaderLine4 in RuntimeHeaderLines)
				{
					method_19(dcgraphics_0, runtimeHeaderLine4, float_0, dateTime_0);
					runtimeHeaderLine4.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					num11 = num11 + runtimeHeaderLine4.RuntimeHeight + runtimeHeaderLine4.BottomSpacing;
				}
				float tickCountFloat5 = CountDown.GetTickCountFloat();
				float num12 = 0f;
				if (ViewMode == FCDocumentViewMode.Page)
				{
					if (Config.SpecifyTitleHeight > 0f)
					{
						num12 = GraphicsUnitConvert.Convert(Config.SpecifyTitleHeight, GraphicsUnit.Document, dcgraphics_0.PageUnit);
					}
					else
					{
						XFontValue font = method_48();
						num12 = dcgraphics_0.GetFontHeight(font) * 1.1f;
						RectangleF rectangleF = new RectangleF(Left, Top, Width, num12);
					}
				}
				method_5(num12, float_0, dcgraphics_0, xFontValue);
				num12 = num12 + float_0 + Config.HeaderLabelBottomSpacing;
				tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
				float num13 = 0f;
				foreach (FCTitleLineInfo runtimeFooterLine3 in RuntimeFooterLines)
				{
					method_19(dcgraphics_0, runtimeFooterLine3, float_0, dateTime_0);
					num13 = num13 + runtimeFooterLine3.RuntimeHeight + runtimeFooterLine3.BottomSpacing;
				}
				tickCountFloat5 = CountDown.GetTickCountFloat();
				method_50();
				rectangleF_0.Y = Top + num12 + RuntimeHeaderLines.TotalRuntimeHeight;
				rectangleF_0.Height = Height - num11 - num13 - num12 - Config.LineZoneBottomSpacing;
				float num14 = 0f;
				string text2 = null;
				if (ViewMode == FCDocumentViewMode.Page)
				{
					if (!string.IsNullOrEmpty(Config.FooterDescription))
					{
						if (Config.FooterDescription.Contains("\\r\\n"))
						{
							int num15 = Config.FooterDescription.Split(new string[1]
							{
								"\\r\\n"
							}, StringSplitOptions.None).Length;
							num14 = float_0 * (float)num15;
						}
						else
						{
							num14 = float_0;
						}
					}
					text2 = Config.PageIndexText;
					if (!string.IsNullOrEmpty(text2))
					{
						num14 += float_0;
						text2 = text2.Replace("[%pageindex%]", Convert.ToString(RuntimePageIndex + 1));
						text2 = text2.Replace("[%pagecount%]", NumOfPages.ToString());
					}
					rectangleF_0.Height -= num14;
				}
				float num16 = Top + num12;
				for (int j = 0; j < RuntimeHeaderLines.Count; j++)
				{
					FCTitleLineInfo current3 = RuntimeHeaderLines[j];
					current3.Top = num16;
					current3.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					num16 = num16 + current3.RuntimeHeight + current3.BottomSpacing;
				}
				tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
				tickCountFloat5 = CountDown.GetTickCountFloat();
				foreach (FCYAxisInfo yAxisInfo2 in Config.YAxisInfos)
				{
					yAxisInfo2.bool_14 = false;
				}
				for (int i = 0; i < fcyaxisInfoList_1.Count; i++)
				{
					FCYAxisInfo current6 = fcyaxisInfoList_1[i];
					current6.TitleTop = rectangleF_0.Top;
					current6.TitleHeight = rectangleF_0.Height;
					current6.bool_14 = true;
				}
				tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
				foreach (FCYAxisInfo item11 in fcyaxisInfoList_0)
				{
					item11.pointF_0 = new PointF(float.NaN, float.NaN);
				}
				float tickCountFloat6 = CountDown.GetTickCountFloat();
				_ = dcgraphics_0.MeasureString("##", xFontValue, 10000, DrawStringFormatExt.GenericTypographic).Width;
				foreach (FCYAxisInfo yAxisInfo3 in YAxisInfos)
				{
					if (yAxisInfo3.Style != FCYAxisInfoStyle.Background)
					{
						method_6(dcgraphics_0, rectangleF_0, yAxisInfo3, fcyaxisInfoList_0, dateTime_0);
					}
				}
				tickCountFloat6 = CountDown.GetTickCountFloat() - tickCountFloat6;
				float tickCountFloat7 = CountDown.GetTickCountFloat();
				if (RuntimeFooterLines.Count > 0)
				{
					num16 = rectangleF_0.Bottom + Config.LineZoneBottomSpacing;
					foreach (FCTitleLineInfo runtimeFooterLine4 in RuntimeFooterLines)
					{
						runtimeFooterLine4.Top = num16;
						num16 = num16 + runtimeFooterLine4.RuntimeHeight + runtimeFooterLine4.BottomSpacing;
						List<DateTime> list = new List<DateTime>();
						if (list.Count > 0)
						{
							runtimeFooterLine4._RuntimeStartDates = list.ToArray();
						}
						else
						{
							runtimeFooterLine4._RuntimeStartDates = null;
						}
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

		private void method_5(float float_8, float float_9, DCGraphics dcgraphics_0, XFontValue xfontValue_0)
		{
			rectangleF_1 = RectangleF.Empty;
			if (HeaderLabels == null || HeaderLabels.Count == 0)
			{
				return;
			}
			foreach (FCHeaderLabelInfo headerLabel in HeaderLabels)
			{
				headerLabel.OwnerDocument = this;
				headerLabel.method_0(dcgraphics_0, xfontValue_0);
				headerLabel.Height = float_9;
			}
			float num;
			if (ViewMode == FCDocumentViewMode.FriedmanCurve || ViewMode == FCDocumentViewMode.Normal)
			{
				num = Left;
				foreach (FCHeaderLabelInfo headerLabel2 in HeaderLabels)
				{
					headerLabel2.Left = num;
					headerLabel2.Top = Top + float_8;
					num += headerLabel2.Width + float_9;
				}
				return;
			}
			float num2 = Width;
			foreach (FCHeaderLabelInfo headerLabel3 in HeaderLabels)
			{
				num2 -= headerLabel3.Width;
			}
			if (HeaderLabels.Count > 1)
			{
				num2 /= (float)(HeaderLabels.Count - 1);
			}
			num = Left;
			foreach (FCHeaderLabelInfo headerLabel4 in HeaderLabels)
			{
				headerLabel4.Left = num;
				headerLabel4.Top = Top + float_8;
				num += headerLabel4.Width + num2;
			}
		}

		private void method_6(DCGraphics dcgraphics_0, RectangleF rectangleF_2, FCYAxisInfo fcyaxisInfo_0, FCYAxisInfoList fcyaxisInfoList_2, DateTime dateTime_4)
		{
			int num = 8;
			float tickCountFloat = CountDown.GetTickCountFloat();
			if (fcyaxisInfo_0.Style == FCYAxisInfoStyle.Value && !string.IsNullOrEmpty(fcyaxisInfo_0.HollowCovertTargetName))
			{
				FCValuePointList fCValuePointList = method_40(fcyaxisInfo_0.Name);
				float tickCountFloat2 = CountDown.GetTickCountFloat();
				FCYAxisInfo itemByName = fcyaxisInfoList_2.GetItemByName(fcyaxisInfo_0.HollowCovertTargetName);
				FCValuePointList fCValuePointList2 = method_40(fcyaxisInfo_0.HollowCovertTargetName);
				if (itemByName != null && fCValuePointList2 != null && fCValuePointList2.Count > 0)
				{
					float num2 = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, GraphicsUnit);
					foreach (FCValuePoint item in fCValuePointList)
					{
						item.HollowCovertFlag = false;
						float num3 = fcyaxisInfo_0.method_3(this, rectangleF_2, item.Value);
						if (!float.IsNaN(num3))
						{
							FCValuePoint nearestPoint = fCValuePointList2.GetNearestPoint(item.Time, 1000f);
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
			XFontValue font = method_46(fcyaxisInfo_0, bool_3: true);
			float width = dcgraphics_0.MeasureString("##", font, 10000, DrawStringFormatExt.GenericTypographic).Width;
			FCValuePointList fCValuePointList3 = method_40(fcyaxisInfo_0.Name);
			CountDown.GetTickCountFloat();
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			float tickCountFloat3 = CountDown.GetTickCountFloat();
			float num8 = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			if (ViewMode == FCDocumentViewMode.FriedmanCurve)
			{
				num5 = 0;
				num6 = fCValuePointList3.Count - 1;
			}
			else
			{
				int count = fCValuePointList3.Count;
				int num9 = 0;
				for (int i = 0; i < count; i++)
				{
					num9++;
					FCValuePoint current = fCValuePointList3[i];
					if (current.Time < dateTime_4)
					{
						current.Visible = false;
						num5 = i + 1;
						continue;
					}
					current.Visible = true;
					if (!(current.Time > class165_0.method_4()))
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
							num6 = ((!(current.Time > class165_0.method_2())) ? i : Math.Max(0, i - 1));
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
						num6 = fCValuePointList3.Count - 1;
					}
					if (fcyaxisInfo_0.Style != FCYAxisInfoStyle.Text)
					{
						num5 = Math.Max(num5 - 10, 0);
						num6 = Math.Min(num6 + 10, fCValuePointList3.Count - 1);
					}
				}
			}
			Dictionary<float, float> dictionary = new Dictionary<float, float>();
			float num10 = 0f;
			for (int i = num5; i >= 0 && i <= num6; i++)
			{
				FCValuePoint current = fCValuePointList3[i];
				_ = (current.Time.Date - dateTime_4).Days;
				Class164 class164_ = null;
				float num12 = current.Left = rectangleF_2.Left + class165_0.method_11(current.Time, ref class164_);
				if (fcyaxisInfo_0.Style == FCYAxisInfoStyle.Text)
				{
					Class164 class164_2 = null;
					num12 = class165_0.method_17(rectangleF_2, current.Time, ref class164_2);
					num12 = Math.Max(num12, rectangleF_0.Left + method_0(2f));
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
						current.Top = fcyaxisInfo_0.method_3(this, rectangleF_2, current.Value);
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
						XFontValue font2 = method_46(fcyaxisInfo_0, bool_3: true);
						SizeF sizeF = dcgraphics_0.MeasureString(current.Text, font2, (int)width, StringFormatForYAxisLabelValue);
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
				if (class164_ != null && class164_.friedmanCurveZoneInfo_0 != null && !class164_.friedmanCurveZoneInfo_0.IsExpanded && !float.IsNaN(fcyaxisInfo_0.pointF_0.X))
				{
					float num15 = num12 - fcyaxisInfo_0.pointF_0.X;
					if (num15 < num8)
					{
						current.Visible = false;
						continue;
					}
				}
				current.Visible = true;
				float num3 = current.Top = fcyaxisInfo_0.method_3(this, rectangleF_2, current.Value);
				if (float.IsNaN(num3))
				{
					fcyaxisInfo_0.pointF_0 = new PointF(float.NaN, float.NaN);
					current.Left = float.NaN;
					current.Top = float.NaN;
				}
				else
				{
					current.OutofRangeFlag = fcyaxisInfo_0.OutofRangeFlag;
					fcyaxisInfo_0.pointF_0 = new PointF(num12, num3);
					fcyaxisInfo_0.fcvaluePoint_0 = current;
				}
			}
			tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		/// <summary>
		///       保存文档到文件流中
		///       </summary>
		/// <param name="stream">文件流</param>
		[ComVisible(false)]
		public void Save(Stream stream)
		{
			int num = 3;
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
			int num = 8;
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
			int num = 2;
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
			int num = 19;
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
			int num = 6;
			try
			{
				if (stream == null)
				{
					throw new ArgumentNullException("stream");
				}
				XmlSerializer xmlSerializer = new XmlSerializer(GetType());
				FriedmanCurveDocument friedmanCurveDocument = (FriedmanCurveDocument)xmlSerializer.Deserialize(stream);
				if (friedmanCurveDocument != null)
				{
					friedmanCurveDocument.method_7(this);
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
			int num = 8;
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			FriedmanCurveDocument friedmanCurveDocument = (FriedmanCurveDocument)xmlSerializer.Deserialize(reader);
			if (friedmanCurveDocument != null)
			{
				friedmanCurveDocument.method_7(this);
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
			int num = 5;
			if (string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("xml");
			}
			using (StringReader reader = new StringReader(string_1))
			{
				return Load(reader);
			}
		}

		private void method_7(FriedmanCurveDocument friedmanCurveDocument_0)
		{
			friedmanCurveDocument_0.friedmanCurveDocumentConfig_0 = friedmanCurveDocumentConfig_0;
			friedmanCurveDocument_0.fcdocumentDataList_0 = fcdocumentDataList_0;
			friedmanCurveDocument_0.int_5 = int_5;
			friedmanCurveDocument_0.float_3 = float_3;
			friedmanCurveDocument_0.float_4 = float_4;
			friedmanCurveDocument_0.float_5 = float_5;
			friedmanCurveDocument_0.float_6 = float_6;
			friedmanCurveDocument_0.color_0 = color_0;
			friedmanCurveDocument_0.int_4 = int_4;
			friedmanCurveDocument_0.fcdocumentViewMode_0 = fcdocumentViewMode_0;
			friedmanCurveDocument_0.dcfriedmanCurveParameterList_0 = dcfriedmanCurveParameterList_0;
			friedmanCurveDocument_0.LayoutInvalidate = true;
		}

		/// <summary>
		///       保存数据HTML
		///       </summary>
		/// <param name="stream">文件流</param>
		public void SaveDataHtml(Stream stream)
		{
			int num = 11;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			StreamWriter streamWriter = new StreamWriter(stream, Encoding.Default);
			streamWriter.WriteLine("<html><body>");
			streamWriter.WriteLine(method_49());
			streamWriter.WriteLine("</body><//html>");
		}

		private Color method_8(Color color_1)
		{
			if (PrintingMode && Config.BothBlackWhenPrint)
			{
				return Color.Black;
			}
			return color_1;
		}

		private float method_9(float float_8)
		{
			if (PrintingMode)
			{
				return float_8 * Config.LineWidthZoomRateWhenPrint;
			}
			return float_8;
		}

		private bool method_10(FCValuePoint fcvaluePoint_1)
		{
			if (Config.LinkVisualStyle == FCDocumentLinkVisualStyle.None)
			{
				return false;
			}
			if (string.IsNullOrEmpty(fcvaluePoint_1.Link))
			{
				return false;
			}
			if (Config.LinkVisualStyle == FCDocumentLinkVisualStyle.Hover)
			{
				return MouseHoverValuePoint == fcvaluePoint_1;
			}
			if (Config.LinkVisualStyle == FCDocumentLinkVisualStyle.Always)
			{
				return true;
			}
			return false;
		}

		private float method_11(RectangleF rectangleF_2, float float_8, FCYAxisInfo fcyaxisInfo_0)
		{
			if (fcyaxisInfo_0 == null)
			{
				return rectangleF_2.Top + rectangleF_2.Height * Config.DataGridTopPadding + rectangleF_2.Height * (1f - Config.DataGridTopPadding - Config.DataGridBottomPadding) * float_8;
			}
			return rectangleF_2.Top + rectangleF_2.Height * fcyaxisInfo_0.RuntimeTopPadding + rectangleF_2.Height * (1f - fcyaxisInfo_0.RuntimeTopPadding - fcyaxisInfo_0.RuntimeBottomPadding) * float_8;
		}

		private void method_12(float float_8)
		{
		}

		public float method_13(DCGraphics dcgraphics_0, RectangleF rectangleF_2, GEnum23 genum23_0)
		{
			int num = 5;
			if (dcgraphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			method_2(dcgraphics_0);
			lock (this)
			{
				dcgraphics_0.PageUnit = GraphicsUnit;
				dcgraphics_0.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				dictionary_0 = new Dictionary<FCValuePoint, RectangleF>();
				float tickCountFloat = CountDown.GetTickCountFloat();
				float tickCountFloat2 = CountDown.GetTickCountFloat();
				rectangleF_2.Inflate(2f, 2f);
				DateTime dateTime_ = dateTime_1;
				tickCountFloat2 = CountDown.GetTickCountFloat() - tickCountFloat2;
				float tickCountFloat3 = CountDown.GetTickCountFloat();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
				XFontValue xFontValue = method_47();
				DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
				tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
				DateTime dateTime_2 = dateTime_0;
				float num2 = dcgraphics_0.GetFontHeight(xFontValue) * 1.5f;
				float num3 = 0f;
				foreach (FCTitleLineInfo runtimeHeaderLine in RuntimeHeaderLines)
				{
					method_19(dcgraphics_0, runtimeHeaderLine, num2, dateTime_2);
					runtimeHeaderLine.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
					num3 += runtimeHeaderLine.RuntimeHeight;
				}
				float tickCountFloat4 = CountDown.GetTickCountFloat();
				float num4 = 0f;
				if (ViewMode == FCDocumentViewMode.Page)
				{
					XFontValue font = method_48();
					num4 = dcgraphics_0.GetFontHeight(font) * 1.1f;
					if (Config.SpecifyTitleHeight > 0f)
					{
						num4 = GraphicsUnitConvert.Convert(Config.SpecifyTitleHeight, GraphicsUnit.Document, dcgraphics_0.PageUnit);
					}
					RectangleF rectangleF = new RectangleF(Left, Top, Width, num4);
					if (!string.IsNullOrEmpty(Title) && (rectangleF_2.IsEmpty || rectangleF_2.IntersectsWith(rectangleF)))
					{
						dcgraphics_0.DrawString(Title, font, RuntimeForeColor, rectangleF, StringAlignment.Center, StringAlignment.Near, noWrap: true);
					}
				}
				method_30(num4, num2, dcgraphics_0, rectangleF_2, xFontValue);
				num4 += num2;
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				tickCountFloat4 = CountDown.GetTickCountFloat();
				float num5 = 0f;
				string text = null;
				if (ViewMode == FCDocumentViewMode.Page)
				{
					if (!string.IsNullOrEmpty(Config.FooterDescription))
					{
						if (Config.FooterDescription.Contains("\\r\\n"))
						{
							int num6 = Config.FooterDescription.Split(new string[1]
							{
								"\\r\\n"
							}, StringSplitOptions.None).Length;
							num5 = float_0 * (float)num6;
						}
						else
						{
							num5 = float_0;
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
					FCTitleLineInfo current = RuntimeHeaderLines[i];
					method_20(current, rectangleF_0, dcgraphics_0, rectangleF_2, float_1, genum23_0, dateTime_2, dateTime_);
					num7 = num7 + current.RuntimeHeight + current.BottomSpacing;
				}
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				tickCountFloat4 = CountDown.GetTickCountFloat();
				foreach (FCYAxisInfo yAxisInfo in Config.YAxisInfos)
				{
					yAxisInfo.bool_14 = false;
				}
				FCYAxisInfo fCYAxisInfo = null;
				FCYAxisInfo fCYAxisInfo2 = null;
				for (int j = 0; j < fcyaxisInfoList_1.Count; j++)
				{
					FCYAxisInfo current2 = fcyaxisInfoList_1[j];
					if (j < fcyaxisInfoList_1.Count - 1)
					{
						fCYAxisInfo2 = fcyaxisInfoList_1[j + 1];
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
						if (fCYAxisInfo == null)
						{
							bottom = rectangleF_0.Bottom - rectangleF_0.Height * num8;
						}
						else
						{
							if (current2.MergeIntoLeft)
							{
								titleTop = fCYAxisInfo.TitleBottom;
							}
							bottom = rectangleF_0.Bottom - rectangleF_0.Height * num8;
						}
						if (!(fCYAxisInfo2?.MergeIntoLeft ?? false))
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
					fCYAxisInfo = current2;
					current2.bool_14 = true;
					RectangleF rect = new RectangleF(current2.TitleLeft, current2.TitleTop + (float)GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), current2.TitleWidth, num2);
					Color color = current2.TitleBackColor;
					if (!current2.ValueVisible)
					{
						color = current2.HiddenValueTitleBackColor;
					}
					if (color.A != 0)
					{
						dcgraphics_0.FillRectangle(color, current2.TitleLeft + 3f, current2.TitleTop + 3f, current2.TitleWidth - 6f, current2.TitleHeight - 6f);
					}
					if (!string.IsNullOrEmpty(current2.Title) && current2.IsDrawContent)
					{
						using (DrawStringFormatExt drawStringFormatExt2 = new DrawStringFormatExt(drawStringFormatExt))
						{
							if (current2.SpecifyTitleWidth > 0f)
							{
								drawStringFormatExt2.FormatFlags = StringFormatFlags.DirectionVertical;
							}
							drawStringFormatExt2.Alignment = StringAlignment.Center;
							drawStringFormatExt2.LineAlignment = StringAlignment.Near;
							rect.Height = dcgraphics_0.MeasureString(current2.Title, xFontValue2, (int)rect.Width, drawStringFormatExt2).Height * 1.25f;
							dcgraphics_0.DrawString(current2.Title, xFontValue2, method_8(current2.TitleColor), rect, drawStringFormatExt2);
						}
					}
					rect.Offset(0f, rect.Height);
					if (current2.ShowLegendInRule && current2.IsDrawContent)
					{
						method_38(dcgraphics_0, rectangleF_2, rect.Left + rect.Width / 2f, current2.TitleTop + (float)GraphicsUnitConvert.Convert(10, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), current2.SymbolStyle, current2.SymbolColor, null, float.NaN);
					}
					if (!string.IsNullOrEmpty(current2.BottomTitle))
					{
						using (DrawStringFormatExt drawStringFormatExt2 = new DrawStringFormatExt(drawStringFormatExt))
						{
							if (current2.SpecifyTitleWidth > 0f)
							{
								drawStringFormatExt2.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
							}
							drawStringFormatExt2.Alignment = StringAlignment.Center;
							drawStringFormatExt2.LineAlignment = StringAlignment.Far;
							dcgraphics_0.DrawString(rect: new RectangleF(current2.TitleLeft, current2.TitleBottom - num2, current2.TitleWidth, num2), string_0: current2.BottomTitle, font: xFontValue2, color_0: method_8(current2.TitleColor), format: drawStringFormatExt2);
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
						RectangleF rect3 = new RectangleF(current2.TitleLeft, method_11(rectangleF_0, (float)k / (float)num9, current2), current2.TitleWidth, num2);
						RectangleF rectangleF2 = default(RectangleF);
						if (InnerBehaviorMode == Enum19.const_0)
						{
							rectangleF2 = new RectangleF(DataGridBounds.Right + 15f, method_11(rectangleF_0, (float)k / (float)num9, current2), current2.TitleWidth, num2);
						}
						else if (InnerBehaviorMode == Enum19.const_1)
						{
							rectangleF2 = new RectangleF(DataGridBounds.Right + 15f, method_11(rectangleF_0, (float)k / (float)num9, current2), current2.TitleWidth, num2);
						}
						float num10 = current2.MaxValue - (current2.MaxValue - current2.MinValue) * (float)k / (float)num9;
						string value = num10.ToString();
						if (!string.IsNullOrEmpty(current2.TitleValueDispalyFormat))
						{
							value = num10.ToString(current2.TitleValueDispalyFormat);
						}
						if (current2.HasScales)
						{
							FCYAxisScaleInfo fCYAxisScaleInfo = current2.Scales[k];
							num10 = fCYAxisScaleInfo.Value;
							rect3.Y = method_11(rectangleF_0, 1f - fCYAxisScaleInfo.ScaleRate, current2);
							value = (string.IsNullOrEmpty(fCYAxisScaleInfo.Text) ? num10.ToString() : fCYAxisScaleInfo.Text);
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
							rect3.Offset(0f, (0f - num2) / 2f);
						}
						else if (k == num9)
						{
							if ((!string.IsNullOrEmpty(current2.BottomTitle) && current2.RuntimeBottomPadding <= 0f) || fCYAxisInfo2 != null)
							{
								continue;
							}
							if (current2.RuntimeBottomPadding <= 0f)
							{
								if (num10 <= current2.MinValue + (current2.MaxValue - current2.MinValue) * 0.08f)
								{
									rect3.Offset(0f, 0f - num2);
								}
								else
								{
									rect3.Offset(0f, (0f - num2) / 2f);
								}
							}
							else
							{
								rect3.Offset(0f, (0f - num2) / 2f);
							}
						}
						else
						{
							rect3.Offset(0f, (0f - num2) / 2f);
						}
						if (!string.IsNullOrEmpty(value) && current2.IsDrawContent)
						{
							dcgraphics_0.DrawString(value, xFontValue2, method_8(current2.TitleColor), rect3, drawStringFormatExt);
							if (current2.IsShowRightScale)
							{
							}
						}
					}
					dcgraphics_0.DrawLine(ForePen, current2.TitleLeft + current2.TitleWidth, current2.TitleTop, current2.TitleLeft + current2.TitleWidth, rectangleF_0.Bottom);
					using (Pen pen_ = new Pen(ForePen.Color, method_9(2f)))
					{
						dcgraphics_0.DrawLine(pen_, current2.TitleLeft, current2.TitleTop, current2.TitleLeft + current2.TitleWidth, current2.TitleTop);
					}
					using (Pen pen_ = new Pen(ForePen.Color, method_9(2f)))
					{
						dcgraphics_0.DrawLine(pen_, current2.TitleLeft, rectangleF_0.Bottom, current2.TitleLeft + current2.TitleWidth, rectangleF_0.Bottom);
					}
				}
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				tickCountFloat4 = CountDown.GetTickCountFloat();
				using (new Pen(ForePen.Color, method_9(2f)))
				{
					dcgraphics_0.DrawLine(ForePen, Left, rectangleF_0.Bottom, rectangleF_0.Left, rectangleF_0.Bottom);
				}
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				tickCountFloat4 = CountDown.GetTickCountFloat();
				method_16(dcgraphics_0, rectangleF_2, rectangleF_0, fcyaxisInfoList_0, dateTime_2);
				method_34(dcgraphics_0, rectangleF_0, rectangleF_2);
				dcgraphics_0.DrawLine(Pens.Black, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Left, rectangleF_0.Bottom);
				method_15(dcgraphics_0, rectangleF_2, rectangleF_0, fcyaxisInfoList_0, dateTime_2);
				using (Pen pen_ = new Pen(ForePen.Color, method_9(2f)))
				{
					dcgraphics_0.DrawLine(pen_, rectangleF_0.Left, rectangleF_0.Top, Math.Min(rectangleF_2.Right, rectangleF_0.Right), rectangleF_0.Top);
				}
				using (Pen pen_ = new Pen(ForePen.Color, method_9(2f)))
				{
					dcgraphics_0.DrawLine(pen_, rectangleF_0.Left, rectangleF_0.Bottom, Math.Min(rectangleF_2.Right, rectangleF_0.Right), rectangleF_0.Bottom);
				}
				foreach (FCYAxisInfo item in fcyaxisInfoList_0)
				{
					if (item.Style == FCYAxisInfoStyle.Background && item.Scales != null && item.Scales.Count > 0 && !string.IsNullOrEmpty(item.Title) && item.ValueVisible)
					{
						dcgraphics_0.DrawString(layoutRectangle: new RectangleF(rectangleF_0.Left + 3f, item.float_18, 1000f, item.float_19), string_0: item.Title, font: xFontValue, color: RuntimeForeColor, alignment: StringAlignment.Near, lineAlignment: StringAlignment.Center, noWrap: true);
					}
				}
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				foreach (FCYAxisInfo item2 in fcyaxisInfoList_0)
				{
					item2.pointF_0 = new PointF(float.NaN, float.NaN);
				}
				float tickCountFloat5 = CountDown.GetTickCountFloat();
				_ = dcgraphics_0.MeasureString("##", xFontValue, 10000, DrawStringFormatExt.GenericTypographic).Width;
				foreach (FCYAxisInfo item3 in fcyaxisInfoList_0)
				{
					if (genum23_0 == GEnum23.const_0)
					{
						break;
					}
					if (item3.ValueVisible && item3.Style != FCYAxisInfoStyle.Background)
					{
						if (item3.Style == FCYAxisInfoStyle.Text)
						{
							if (item3.IsDrawContent)
							{
								method_14(dcgraphics_0, rectangleF_0, rectangleF_2, item3, fcyaxisInfoList_0, dateTime_2);
							}
						}
						else if (item3.IsDrawContent)
						{
							method_14(dcgraphics_0, rectangleF_0, rectangleF_2, item3, fcyaxisInfoList_0, dateTime_2);
						}
					}
				}
				dcgraphics_0.DrawLine(Pens.Black, rectangleF_0.Left, rectangleF_0.Top, rectangleF_0.Left, rectangleF_0.Bottom);
				tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
				float tickCountFloat6 = CountDown.GetTickCountFloat();
				if (RuntimeFooterLines.Count > 0)
				{
					foreach (FCTitleLineInfo runtimeFooterLine in RuntimeFooterLines)
					{
						method_20(runtimeFooterLine, rectangleF_0, dcgraphics_0, rectangleF_2, float_1, genum23_0, dateTime_2, dateTime_);
					}
				}
				tickCountFloat6 = CountDown.GetTickCountFloat() - tickCountFloat6;
				float tickCountFloat7 = CountDown.GetTickCountFloat();
				using (Pen pen_ = new Pen(method_8(Config.ForeColor), method_9(2f)))
				{
					dcgraphics_0.DrawRectangle(pen_, Left, Top + num4, Width, Height - num4 - num5);
				}
				if (num5 > 0f)
				{
					using (DrawStringFormatExt drawStringFormatExt3 = new DrawStringFormatExt())
					{
						float num11 = Top + Height - num5;
						if (!string.IsNullOrEmpty(Config.FooterDescription))
						{
							drawStringFormatExt3.Alignment = StringAlignment.Near;
							drawStringFormatExt3.LineAlignment = StringAlignment.Center;
							drawStringFormatExt3.FormatFlags = StringFormatFlags.NoWrap;
							if (Config.FooterDescription.Contains("\\r\\n"))
							{
								string[] array = Config.FooterDescription.Split(new string[1]
								{
									"\\r\\n"
								}, StringSplitOptions.None);
								string[] array2 = array;
								foreach (string text2 in array2)
								{
									dcgraphics_0.DrawString(text2, xFontValue, RuntimeForeColor, new RectangleF(Left, num11, Width, num2), drawStringFormatExt3);
									num11 += num2;
								}
							}
							else
							{
								dcgraphics_0.DrawString(Config.FooterDescription, xFontValue, RuntimeForeColor, new RectangleF(Left, num11, Width, num2), drawStringFormatExt3);
								num11 += num2;
							}
						}
						if (!string.IsNullOrEmpty(text))
						{
							drawStringFormatExt3.Alignment = StringAlignment.Center;
							drawStringFormatExt3.LineAlignment = StringAlignment.Center;
							dcgraphics_0.DrawString(text, Config.RuntimePageIndexFont, RuntimeForeColor, new RectangleF(Left, num11, Width, num2), drawStringFormatExt3);
						}
					}
				}
				method_17(dcgraphics_0, rectangleF_2);
				method_18(dcgraphics_0, rectangleF_2);
				if (InnerBehaviorMode == Enum19.const_1 && SelectedObject != null)
				{
					RectangleF rect4 = method_54(SelectedObject);
					if (!rect4.IsEmpty && rectangleF_2.IntersectsWith(rect4))
					{
						dcgraphics_0.DrawRectangle(method_8(Config.ForeColor), method_0(2f), rect4.Left, rect4.Top, rect4.Width, rect4.Height);
						float num12 = method_0(6f);
						Pen selectionPen = DrawerUtil.GetSelectionPen(num12, IsCurrent: true);
						rect4.Inflate((0f - num12) / 2f, (0f - num12) / 2f);
						dcgraphics_0.DrawRectangle(selectionPen, rect4.Left, rect4.Top, rect4.Width, rect4.Height);
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
							RectangleF rectangleF3 = new RectangleF(Left + rectangleF_1.Right, Top + rectangleF_1.Top, sizeF.Width, sizeF.Height);
							gClass.method_29(dcgraphics_0, rectangleF3, bool_7: false);
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

		private void method_14(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3, FCYAxisInfo fcyaxisInfo_0, FCYAxisInfoList fcyaxisInfoList_2, DateTime dateTime_4)
		{
			int num = 2;
			bool flag = false;
			foreach (FCYAxisInfo item in fcyaxisInfoList_2)
			{
				if (item.ShadowInfo == fcyaxisInfo_0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return;
			}
			XFontValue font = method_46(fcyaxisInfo_0, bool_3: true);
			float width = dcgraphics_0.MeasureString("##", font, 10000, DrawStringFormatExt.GenericTypographic).Width;
			if (!smethod_3(fcyaxisInfo_0.RedLineValue))
			{
				float num2 = fcyaxisInfo_0.method_3(this, rectangleF_2, fcyaxisInfo_0.RedLineValue);
				RectangleF rectangleF = RectangleF.Intersect(rectangleF_2, rectangleF_3);
				if (!rectangleF.IsEmpty && (!PrintingMode || fcyaxisInfo_0.RedLinePrintVisible))
				{
					dcgraphics_0.DrawLine(method_8(Color.Red), method_9(fcyaxisInfo_0.RedLineWidth), rectangleF.Left, num2, rectangleF.Right, num2);
				}
			}
			FCValuePointList fCValuePointList = method_40(fcyaxisInfo_0.Name);
			float tickCountFloat = CountDown.GetTickCountFloat();
			int num3 = -1;
			int num4 = -1;
			RectangleF rectangleF2 = RectangleF.Intersect(rectangleF_3, rectangleF_2);
			int num5 = -1;
			float tickCountFloat2 = CountDown.GetTickCountFloat();
			_ = (float)GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			int index = class165_0.method_6(rectangleF_2, rectangleF_3);
			DateTime dateTime = class165_0[index].dateTime_0;
			int floorIndexByTime = fCValuePointList.GetFloorIndexByTime(dateTime);
			floorIndexByTime = Math.Max(0, floorIndexByTime - 5);
			float runtimeSymbolSize = fcyaxisInfo_0.RuntimeSymbolSize;
			for (int i = floorIndexByTime; i < fCValuePointList.Count; i++)
			{
				FCValuePoint fCValuePoint = fCValuePointList[i];
				if (fCValuePoint.Time < dateTime_4)
				{
					continue;
				}
				if (!(fCValuePoint.Time > class165_0.method_4()))
				{
					if (num5 < 0)
					{
						num5 = i;
					}
					float left = fCValuePoint.Left;
					float top = fCValuePoint.Top;
					bool flag2 = left >= rectangleF2.Left - runtimeSymbolSize;
					if (fcyaxisInfo_0.Style == FCYAxisInfoStyle.Text)
					{
						flag2 = (left + width >= rectangleF2.Left);
					}
					if (flag2)
					{
						if (num3 < 0)
						{
							num3 = Math.Max(i - 1, 0);
							if (fcyaxisInfo_0.ShadowInfo != null)
							{
								bool flag3 = false;
								int num6 = 0;
								for (int num7 = num3; num7 >= 0; num7--)
								{
									if (fCValuePointList[num7].ShowShadowPoint)
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
										if (fCValuePointList[num7].IsNullValue)
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
						if (!fcyaxisInfo_0.AllowInterrupt)
						{
							int num7 = i - 1;
							while (num7 >= 0)
							{
								FCValuePoint fCValuePoint2 = fCValuePointList[num7];
								if (smethod_3(fCValuePoint2.Value))
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
					if (fcyaxisInfo_0.ShadowInfo != null)
					{
						for (int num7 = num4; num7 < fCValuePointList.Count; num7++)
						{
							if (fCValuePointList[num7].ShadowPoint != null)
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
					if (num4 < fCValuePointList.Count - 1)
					{
						num4++;
					}
					break;
				}
				if (num4 < 0)
				{
					num4 = ((!(fCValuePoint.Time > class165_0.method_2())) ? i : Math.Max(0, i - 1));
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
				num4 = fCValuePointList.Count - 1;
			}
			float tickCountFloat3 = CountDown.GetTickCountFloat();
			Dictionary<float, float> dictionary = new Dictionary<float, float>();
			fcyaxisInfo_0.pointF_0 = new PointF(float.NaN, float.NaN);
			fcyaxisInfo_0.fcvaluePoint_0 = null;
			bool flag4 = false;
			for (int i = num3; i <= num4; i++)
			{
				float tickCountFloat4 = CountDown.GetTickCountFloat();
				FCValuePoint fCValuePoint = fCValuePointList[i];
				if ((smethod_3(fCValuePoint.Left) || smethod_3(fCValuePoint.Top)) && (fcyaxisInfo_0.Style != 0 || !fcyaxisInfo_0.AllowInterrupt))
				{
					continue;
				}
				_ = (fCValuePoint.Time.Date - dateTime_4).Days;
				float left = fCValuePoint.Left;
				if (fcyaxisInfo_0.Style == FCYAxisInfoStyle.Text)
				{
					if (left > rectangleF_2.Right - 2f)
					{
						break;
					}
					float num8 = (float)GraphicsUnitConvert.Convert(1.0, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
					float num9 = fCValuePoint.Top;
					if (fCValuePoint.ImageValue != null && Config.ShowIcon)
					{
						num9 += fCValuePoint.Height + num8 * 3f;
						method_29(dcgraphics_0, fCValuePoint.ImageValue, fCValuePoint.Left, fCValuePoint.Top);
					}
					if (!string.IsNullOrEmpty(fCValuePoint.Text))
					{
						using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericDefault.Clone())
						{
							drawStringFormatExt.FormatFlags = (StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap);
							drawStringFormatExt.Alignment = StringAlignment.Near;
							drawStringFormatExt.LineAlignment = StringAlignment.Center;
							XFontValue font2 = method_46(fcyaxisInfo_0, bool_3: true);
							RectangleF rectangleF3 = new RectangleF(0f, 0f, 0f, 0f);
							rectangleF3 = new RectangleF(fCValuePoint.Left + 3f, num9 + fCValuePoint.ValueTextTopPadding, fCValuePoint.Width, fCValuePoint.Top + fCValuePoint.Height - num9);
							bool flag5 = false;
							if (dictionary.ContainsKey(fCValuePoint.Left))
							{
								flag5 = true;
							}
							dictionary[fCValuePoint.Left] = rectangleF3.Bottom;
							float bottom = rectangleF_2.Bottom;
							if (rectangleF3.Bottom > bottom - 2f)
							{
								rectangleF3.Height = bottom - rectangleF3.Top - 2f;
							}
							if (!(rectangleF3.Height <= 0f))
							{
								if (fcyaxisInfo_0.ValueTextBackColor.A == 0)
								{
								}
								if (flag5 && fcyaxisInfo_0.SeparatorLineVisible)
								{
									dcgraphics_0.DrawLine(method_8(Config.ForeColor), rectangleF3.Left, rectangleF3.Top, rectangleF3.Right, rectangleF3.Top);
								}
								Color color_ = fcyaxisInfo_0.SymbolColor;
								if (method_10(fCValuePoint))
								{
									color_ = Color.Blue;
									dcgraphics_0.DrawLine(Color.Blue, rectangleF3.Left, rectangleF3.Top, rectangleF3.Left, rectangleF3.Bottom);
									dcgraphics_0.DrawLine(Color.Blue, rectangleF3.Right - 1f, rectangleF3.Top, rectangleF3.Right - 1f, rectangleF3.Bottom);
								}
								try
								{
									dcgraphics_0.DrawString(fCValuePoint.Text, font2, method_8(color_), rectangleF3, drawStringFormatExt);
								}
								catch
								{
								}
								goto IL_078c;
							}
						}
						continue;
					}
					goto IL_078c;
				}
				if (!fCValuePoint.Visible)
				{
					continue;
				}
				float top = fCValuePoint.Top;
				if (float.IsNaN(top))
				{
					if (fcyaxisInfo_0.AllowInterrupt)
					{
						fcyaxisInfo_0.pointF_0 = new PointF(float.NaN, float.NaN);
						flag4 = false;
					}
				}
				else
				{
					bool flag6 = fcyaxisInfo_0.HighlightOutofNormalRange && Class163.smethod_3(fCValuePoint.Value, fcyaxisInfo_0.NormalMaxValue, fcyaxisInfo_0.NormalMinValue);
					float tickCountFloat5 = CountDown.GetTickCountFloat();
					if (!float.IsNaN(fcyaxisInfo_0.pointF_0.X))
					{
						Color color_2 = fcyaxisInfo_0.SymbolColor;
						if (fCValuePoint.Color.A != 0)
						{
							color_2 = fCValuePoint.Color;
						}
						else if (fcyaxisInfo_0.fcvaluePoint_0 != null && fcyaxisInfo_0.fcvaluePoint_0.Color.A != 0)
						{
							color_2 = fcyaxisInfo_0.fcvaluePoint_0.Color;
						}
						SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
						dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
						float num10 = method_9(fcyaxisInfo_0.RunFriedmanCurveWidth);
						if (flag6 || flag4)
						{
							num10 = (float)Math.Ceiling(num10 * 1.5f);
						}
						dcgraphics_0.DrawLine(method_8(color_2), method_9(num10), fcyaxisInfo_0.pointF_0, new PointF(left, top));
						dcgraphics_0.SmoothingMode = smoothingMode;
					}
					float num11 = fcyaxisInfo_0.RuntimeSymbolSize;
					if (flag6)
					{
						num11 *= 1.5f;
					}
					if (fCValuePoint.HollowCovertFlag)
					{
						method_38(dcgraphics_0, rectangleF_3, left, top, FCValuePointSymbolStyle.HollowCicle, fcyaxisInfo_0.SymbolColor, fCValuePoint, num11 * 1.5f);
					}
					else
					{
						method_38(dcgraphics_0, rectangleF_3, left, top, fcyaxisInfo_0.SymbolStyle, fcyaxisInfo_0.SymbolColor, fCValuePoint, num11);
					}
					if (fCValuePoint.OutofRangeFlag == 1)
					{
						method_36(dcgraphics_0, left, top, bool_3: true, fCValuePoint, fcyaxisInfo_0.ValueTextBackColor);
					}
					else if (fCValuePoint.OutofRangeFlag == -1)
					{
						method_36(dcgraphics_0, left, top, bool_3: false, fCValuePoint, fcyaxisInfo_0.ValueTextBackColor);
					}
					tickCountFloat5 = CountDown.GetTickCountFloat() - tickCountFloat5;
					fcyaxisInfo_0.pointF_0 = new PointF(left, top);
					fcyaxisInfo_0.fcvaluePoint_0 = fCValuePoint;
					flag4 = flag6;
					if (fcyaxisInfo_0.EnableLanternValue && !smethod_3(fCValuePoint.LanternValue))
					{
						float num12 = fcyaxisInfo_0.method_3(this, rectangleF_2, fCValuePoint.LanternValue);
						Color red = Color.Red;
						if (!(num12 < top))
						{
						}
						method_38(dcgraphics_0, rectangleF_3, left, num12, FCValuePointSymbolStyle.HollowCicle, red, null, num11);
						if (fCValuePoint.Verified)
						{
							method_38(dcgraphics_0, rectangleF_3, fCValuePoint.Left, fCValuePoint.Top - 25f, FCValuePointSymbolStyle.V, red, null, num11);
						}
						dcgraphics_0.DrawLine(red, method_9(2f), DashStyle.Dash, left, top, left, num12);
					}
				}
				if (fcyaxisInfo_0.ShadowInfo != null && fCValuePoint.ShadowPoint != null)
				{
					if (fCValuePoint.ShowShadowPoint)
					{
						top = fCValuePoint.ShadowPoint.Top;
						if (float.IsNaN(top))
						{
							fCValuePoint.ShadowPoint = null;
							fcyaxisInfo_0.ShadowInfo.pointF_0 = new PointF(float.NaN, float.NaN);
						}
						else
						{
							fCValuePoint.ShadowPoint.Left = left;
							fCValuePoint.ShadowPoint.Top = top;
							method_38(dcgraphics_0, rectangleF_3, left, top, FCValuePointSymbolStyle.HollowCicle, fcyaxisInfo_0.SymbolColor, fCValuePoint.ShadowPoint, fcyaxisInfo_0.RuntimeSymbolSize);
							fcyaxisInfo_0.ShadowInfo.pointF_0 = new PointF(left, top);
						}
						if (fCValuePoint.ShowShadowPoint && fcyaxisInfo_0.VerticalLine)
						{
							dcgraphics_0.DrawLine(method_8(Color.Red), method_9(2f), new PointF(fCValuePoint.Left, fCValuePoint.Top), new PointF(fCValuePoint.ShadowPoint.Left, fCValuePoint.ShadowPoint.Top));
						}
					}
					else
					{
						fcyaxisInfo_0.ShadowInfo.pointF_0 = new PointF(float.NaN, float.NaN);
					}
				}
				goto IL_0bd2;
				IL_0bd2:
				tickCountFloat4 = CountDown.GetTickCountFloat() - tickCountFloat4;
				continue;
				IL_078c:
				if (dictionary_0 != null && fCValuePoint.Height > 0f)
				{
					dictionary_0[fCValuePoint] = fCValuePoint.ViewBounds;
				}
				goto IL_0bd2;
			}
			tickCountFloat3 = CountDown.GetTickCountFloat() - tickCountFloat3;
			if (fcyaxisInfo_0.ShadowInfo != null && fCValuePointList.Count > 0)
			{
				for (int i = num3; i <= num4; i++)
				{
					FCValuePoint fCValuePoint = fCValuePointList[i];
					if (!fCValuePoint.ShowShadowPoint)
					{
						continue;
					}
					int num13 = i;
					if (num13 > num3)
					{
						FCValuePoint fCValuePoint3 = fCValuePointList[num13 - 1];
						if (!fCValuePoint3.IsNullValue && fCValuePoint3.ShadowPoint != null && !float.IsNaN(fCValuePoint3.ShadowPoint.CenterY))
						{
							num13--;
						}
					}
					int j;
					for (j = i; j <= num4; j++)
					{
						FCValuePoint fCValuePoint4 = fCValuePointList[j];
						if (fCValuePoint4.ShowShadowPoint)
						{
							if (j == num4)
							{
								if (fCValuePoint4.IsNullValue)
								{
									j--;
								}
								break;
							}
							continue;
						}
						if (fCValuePoint4.ShadowPoint == null || float.IsNaN(fCValuePoint4.ShadowPoint.CenterY))
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
						list.Add(new PointF(fCValuePointList[k].CenterX, fCValuePointList[k].CenterY));
					}
					for (int k = j; k >= num13; k--)
					{
						FCValuePoint fCValuePoint4 = fCValuePointList[k];
						if (fCValuePoint4.ShowShadowPoint)
						{
							list.Add(new PointF(fCValuePoint4.ShadowPoint.CenterX, fCValuePoint4.ShadowPoint.CenterY));
						}
						else
						{
							list.Add(new PointF(fCValuePoint4.CenterX, fCValuePoint4.CenterY));
						}
					}
					if (list.Count > 2 && list[0] != list[list.Count - 1])
					{
						list.Add(list[0]);
					}
					SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
					dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
					dcgraphics_0.DrawLines(method_8(fcyaxisInfo_0.SymbolColor), method_9(2f), list.ToArray());
					dcgraphics_0.SmoothingMode = smoothingMode;
					using (HatchBrush brush = new HatchBrush(HatchStyle.LightUpwardDiagonal, method_8(fcyaxisInfo_0.SymbolColor), Color.Transparent))
					{
						if (fcyaxisInfo_0.ShadowPointVisible)
						{
							dcgraphics_0.FillPolygon(brush, list.ToArray());
						}
					}
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private void method_15(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3, FCYAxisInfoList fcyaxisInfoList_2, DateTime dateTime_4)
		{
			foreach (FCYAxisInfo item in fcyaxisInfoList_2)
			{
				bool flag = false;
				if (item.ValueVisible && (!smethod_3(item.NormalMaxValue) || !smethod_3(item.NormalMinValue)))
				{
					flag = true;
					foreach (FCYAxisInfo item2 in fcyaxisInfoList_2)
					{
						if (item2 != item && item2.ValueVisible && item2.Style == FCYAxisInfoStyle.Value)
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

		private void method_16(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3, FCYAxisInfoList fcyaxisInfoList_2, DateTime dateTime_4)
		{
			int num = -1;
			foreach (FCYAxisInfo item in fcyaxisInfoList_2)
			{
				if (item.Style == FCYAxisInfoStyle.PartialBackground)
				{
					num++;
					item.float_18 = rectangleF_3.Bottom - rectangleF_3.Height * (float)(num + 1) / (float)Config.GridYSplitInfo.GridYSplitNum;
					item.float_19 = rectangleF_3.Height / (float)Config.GridYSplitInfo.GridYSplitNum;
					method_31(null, item.Scales, Datas.GetValuesByName(item.Name), rectangleF_3, item.float_18, item.float_19, dcgraphics_0, rectangleF_2, dateTime_4, bool_3: true);
				}
				else if (item.Style == FCYAxisInfoStyle.Background)
				{
					num++;
					item.float_18 = rectangleF_3.Top;
					item.float_19 = rectangleF_3.Height;
					method_31(null, item.Scales, Datas.GetValuesByName(item.Name), rectangleF_3, item.float_18, item.float_19, dcgraphics_0, rectangleF_2, dateTime_4, bool_3: true);
				}
			}
		}

		private void method_17(DCGraphics dcgraphics_0, RectangleF rectangleF_2)
		{
			if (ViewMode == FCDocumentViewMode.Page && Config.Labels != null && Config.Labels.Count != 0)
			{
				float num = (float)GraphicsUnitConvert.GetRate(dcgraphics_0.PageUnit, GraphicsUnit.Document);
				foreach (DCFriedmanCurveLabel label in Config.Labels)
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
								dcgraphics_0.DrawString(value, xFontValue, method_8(label.Color), rect, drawStringFormatExt);
							}
						}
					}
				}
			}
		}

		private void method_18(DCGraphics dcgraphics_0, RectangleF rectangleF_2)
		{
			if (ViewMode == FCDocumentViewMode.Page && Config.Images != null && Config.Images.Count != 0)
			{
				foreach (DCFriedmanCurveImage image in Config.Images)
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

		private void method_19(DCGraphics dcgraphics_0, FCTitleLineInfo fctitleLineInfo_0, float float_8, DateTime dateTime_4)
		{
			fctitleLineInfo_0.Height = float_8;
			DateTime t = dateTime_4.AddDays(RuntimeNumOfHoursInOnePage);
			if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Cascade)
			{
				FCValuePointList fCValuePointList = method_40(fctitleLineInfo_0.Name);
				if (fCValuePointList != null && fCValuePointList.Count > 0)
				{
					DateTime date = dateTime_4.Date;
					int num = 1;
					int num2 = 0;
					foreach (FCValuePoint item in fCValuePointList)
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
					fctitleLineInfo_0.Height = (float)num * float_8;
					fctitleLineInfo_0.ContentLineCount = num;
				}
				else
				{
					fctitleLineInfo_0.ContentLineCount = 1;
					fctitleLineInfo_0.Height = float_8;
				}
			}
			if (dcgraphics_0 != null)
			{
				fctitleLineInfo_0.RefreshRuntimeHeight(dcgraphics_0.PageUnit);
			}
		}

		private void method_20(FCTitleLineInfo fctitleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, float float_8, GEnum23 genum23_0, DateTime dateTime_4, DateTime dateTime_5)
		{
			float tickCountFloat = CountDown.GetTickCountFloat();
			RectangleF rect = new RectangleF(Left, fctitleLineInfo_0.Top, Width, fctitleLineInfo_0.RuntimeHeight);
			if (!rectangleF_3.IsEmpty && !rectangleF_3.IntersectsWith(rect))
			{
				return;
			}
			dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : ForePen, Left + float_8, rect.Bottom, rect.Right, rect.Bottom);
			RectangleF rectangleF = new RectangleF(Left, fctitleLineInfo_0.Top, float_8, fctitleLineInfo_0.RuntimeHeight);
			XFontValue font = method_45(fctitleLineInfo_0, bool_3: false);
			fctitleLineInfo_0.TitleBounds = rectangleF;
			float num = 0f;
			if (fctitleLineInfo_0.ShowExpandedHandle && !PrintingMode)
			{
				Image collapse = DCFriedmanCurveImageResources.Collapse;
				Image expand = DCFriedmanCurveImageResources.Expand;
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(collapse.Width, collapse.Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				_ = (float)GraphicsUnitConvert.Convert(3, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				GraphicsUnitConvert.Convert(16, GraphicsUnit.Pixel, GraphicsUnit);
				float num2 = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, GraphicsUnit);
				RectangleF rect2 = fctitleLineInfo_0.ExpandedHandleBounds = new RectangleF(rectangleF.Left + num2, rectangleF.Top + (rectangleF.Height - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
				Image image_ = fctitleLineInfo_0.IsExpanded ? expand : collapse;
				if (rectangleF_3.IntersectsWith(rect2))
				{
					DrawerUtil.DrawImageUnscaledNearestNeighbor(dcgraphics_0, image_, (int)rect2.Left, (int)rect2.Top);
				}
				num = num2 + rect2.Width + 2f;
			}
			if (!string.IsNullOrEmpty(fctitleLineInfo_0.Title) && (rectangleF_3.IsEmpty || rectangleF_3.IntersectsWith(rectangleF)))
			{
				LineTitleStringFormat.Alignment = fctitleLineInfo_0.TitleAlign;
				RectangleF rect3 = rectangleF;
				if (LineTitleStringFormat.Alignment == StringAlignment.Near)
				{
					rect3 = new RectangleF(rectangleF.Left + num, rectangleF.Top, rectangleF.Width - num, rectangleF.Height);
				}
				dcgraphics_0.DrawString(fctitleLineInfo_0.Title, font, method_8(fctitleLineInfo_0.TitleColor), rect3, LineTitleStringFormat);
			}
			if (fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.Full)
			{
				dcgraphics_0.DrawRectangle(RuntimeForeColor, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
			}
			if (fctitleLineInfo_0.TitleLineBorderStyle != 0)
			{
				dcgraphics_0.DrawLine(RuntimeForeColor, rectangleF.Left + rectangleF.Width, rectangleF.Top, rectangleF.Left + rectangleF.Width, rectangleF.Height + rectangleF.Top);
			}
			if (genum23_0 != 0)
			{
				if (fctitleLineInfo_0.ExtendGridLineType == FCDCExtendGridLineType.Below)
				{
					method_21(dcgraphics_0, new RectangleF(rectangleF_2.Left, rectangleF.Top, rectangleF_2.Width, rectangleF.Height), rectangleF_3, fctitleLineInfo_0);
				}
				StringFormat stringFormat = new StringFormat();
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				stringFormat.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
				float num3 = rectangleF_2.Width / (float)RuntimeNumOfHoursInOnePage;
				if (Config.Ticks.Count > 0)
				{
					float_2 = num3 / (float)Config.Ticks.Count;
				}
				else
				{
					float_2 = num3;
				}
				if (fctitleLineInfo_0.ValueType == FCTitleLineValueType.HourTick)
				{
					method_26(fctitleLineInfo_0, rectangleF_2, dcgraphics_0, rectangleF_3);
				}
				else if (fctitleLineInfo_0.ValueType == FCTitleLineValueType.DurationTick)
				{
					method_27(fctitleLineInfo_0, rectangleF_2, dcgraphics_0, rectangleF_3);
				}
				else if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Free || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.FreeText || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant3)
				{
					method_31(fctitleLineInfo_0, fctitleLineInfo_0.Scales, method_40(fctitleLineInfo_0.Name), rectangleF_2, fctitleLineInfo_0.Top + 1f, fctitleLineInfo_0.RuntimeHeight - 2f, dcgraphics_0, rectangleF_3, dateTime_4, fctitleLineInfo_0.ShowBackColor);
				}
				else if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Cascade || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.HorizCascade || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Normal || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant2)
				{
					method_25(fctitleLineInfo_0, rectangleF_2, dcgraphics_0, rectangleF_3, dateTime_4);
				}
				if (fctitleLineInfo_0.ExtendGridLineType == FCDCExtendGridLineType.Above)
				{
					method_21(dcgraphics_0, new RectangleF(rectangleF_2.Left, rectangleF.Top, rectangleF_2.Width, rectangleF.Height), rectangleF_3, fctitleLineInfo_0);
				}
				dcgraphics_0.DrawRectangle((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.Full) ? ForePen : new Pen(Color.Transparent), rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
				dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : ForePen, Math.Max(Left + float_8, rectangleF_3.Left + float_8 - 1f), fctitleLineInfo_0.Top, Math.Min(Left + Width, rectangleF_3.Right + 1f), fctitleLineInfo_0.Top);
				dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : ForePen, Math.Max(Left + float_8, rectangleF_3.Left + float_8 - 1f), fctitleLineInfo_0.Top + fctitleLineInfo_0.RuntimeHeight, Math.Min(Left + Width, rectangleF_3.Right + 1f), fctitleLineInfo_0.Top + fctitleLineInfo_0.RuntimeHeight);
				dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : ForePen, Math.Min(Left + Width, rectangleF_3.Right + 1f), fctitleLineInfo_0.Top, Math.Min(Left + Width, rectangleF_3.Right + 1f), fctitleLineInfo_0.Top + fctitleLineInfo_0.RuntimeHeight);
				stringFormat.Dispose();
				tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
			}
		}

		private void method_21(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3, FCTitleLineInfo fctitleLineInfo_0)
		{
			_ = RuntimeNumOfHoursInOnePage;
			float num = Math.Max(rectangleF_2.Top, rectangleF_3.Top);
			float num2 = Math.Min(rectangleF_2.Bottom, rectangleF_3.Bottom);
			if (!(num <= num2) || fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None)
			{
				return;
			}
			XPenStyle xpenStyle_ = new XPenStyle(method_8(Config.BigVerticalGridLineColor), method_9(2f));
			for (int i = 1; i < class165_0.Count; i++)
			{
				Class164 @class = class165_0[i];
				if (@class.bool_0)
				{
					float num3 = rectangleF_2.Left + @class.float_0;
					if (num3 >= rectangleF_3.Left && num3 <= rectangleF_3.Right)
					{
						dcgraphics_0.DrawLine(xpenStyle_, num3, num, num3, num2);
					}
				}
			}
		}

		private void method_22(FCTitleLineInfo fctitleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4, DrawStringFormatExt drawStringFormatExt_2)
		{
			int num = 6;
			int runtimeNumOfHoursInOnePage = RuntimeNumOfHoursInOnePage;
			XFontValue font = method_45(fctitleLineInfo_0, bool_3: true);
			RectangleF rectangleF = RectangleF.Empty;
			string text = Config.DateFormatString;
			if (string.IsNullOrEmpty(text))
			{
				text = "yyyy-MM-dd";
			}
			float width = dcgraphics_0.MeasureString(text, font, 10000, drawStringFormatExt_2).Width;
			bool flag = false;
			for (int i = 0; i < runtimeNumOfHoursInOnePage; i++)
			{
				DateTime dateTime = dateTime_4.AddDays(i);
				RectangleF rectangleF2 = class165_0.method_18(rectangleF_2, dateTime);
				if (rectangleF2.IsEmpty || rectangleF2.Right <= rectangleF.Right)
				{
					continue;
				}
				rectangleF = rectangleF2;
				rectangleF2.Y = fctitleLineInfo_0.Top;
				rectangleF2.Height = fctitleLineInfo_0.RuntimeHeight;
				if (rectangleF2.Left > rectangleF_3.Right || rectangleF2.Left >= rectangleF_2.Right - 2f)
				{
					break;
				}
				rectangleF2 = method_24(rectangleF_2, rectangleF2);
				string text2 = null;
				if (i == 0 || dateTime.Day == 1 || (dateTime.DayOfWeek == DayOfWeek.Monday && ViewMode == FCDocumentViewMode.FriedmanCurve))
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
					Color color_ = fctitleLineInfo_0?.TextColor ?? Config.ForeColor;
					dcgraphics_0.DrawString(text2, font, method_8(color_), rectangleF2, drawStringFormatExt_2);
				}
			}
		}

		private void method_23(FCTitleLineInfo fctitleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4, DateTime dateTime_5, DrawStringFormatExt drawStringFormatExt_2)
		{
			int num = 8;
			float tickCountFloat = CountDown.GetTickCountFloat();
			int runtimeNumOfHoursInOnePage = RuntimeNumOfHoursInOnePage;
			if (fctitleLineInfo_0._RuntimeStartDates != null)
			{
				XFontValue font = method_45(fctitleLineInfo_0, bool_3: true);
				RectangleF rectangleF = RectangleF.Empty;
				int index = class165_0.method_6(rectangleF_2, rectangleF_3);
				DateTime dateTime = class165_0[index].dateTime_0;
				index = (int)dateTime.Subtract(dateTime_4).TotalDays - 2;
				index = Math.Max(index, 0);
				for (int i = index; i < runtimeNumOfHoursInOnePage; i++)
				{
					DateTime dateTime2 = dateTime_4.AddDays(i);
					if (dateTime2 >= dateTime_5 || (fctitleLineInfo_0.EnableEndTime && !smethod_4(dateTime_3) && dateTime2 > dateTime_3))
					{
						break;
					}
					RectangleF rectangleF2 = class165_0.method_18(rectangleF_2, dateTime2);
					if (rectangleF2.Right <= rectangleF.Right)
					{
						continue;
					}
					rectangleF = rectangleF2;
					rectangleF2.Y = fctitleLineInfo_0.Top;
					rectangleF2.Height = fctitleLineInfo_0.RuntimeHeight;
					if (rectangleF2.Left > rectangleF_3.Right || rectangleF2.Left > rectangleF_2.Right - 2f)
					{
						break;
					}
					rectangleF2 = method_24(rectangleF_2, rectangleF2);
					if (rectangleF2.IsEmpty || !rectangleF_3.IntersectsWith(rectangleF2))
					{
						continue;
					}
					int num2 = (fctitleLineInfo_0.MaxValueForDayIndex > 0) ? fctitleLineInfo_0.MaxValueForDayIndex : int.MaxValue;
					StringBuilder stringBuilder = new StringBuilder();
					for (int num3 = fctitleLineInfo_0._RuntimeStartDates.Length - 1; num3 >= 0; num3--)
					{
						DateTime d = fctitleLineInfo_0._RuntimeStartDates[num3];
						DateTime d2 = d.AddDays(-1.0);
						TimeSpan timeSpan = dateTime2 - d;
						TimeSpan timeSpan2 = dateTime2 - d2;
						if (timeSpan.Days <= num2)
						{
							if (fctitleLineInfo_0.Title == "术后天数" && fctitleLineInfo_0.AfterOperaDaysFromZero && timeSpan2.Days == 0)
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
						Color color_ = fctitleLineInfo_0?.TextColor ?? Config.ForeColor;
						dcgraphics_0.DrawString(stringBuilder.ToString(), font, method_8(color_), rectangleF2, drawStringFormatExt_2);
					}
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private RectangleF method_24(RectangleF rectangleF_2, RectangleF rectangleF_3)
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

		private void method_25(FCTitleLineInfo fctitleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4)
		{
			_ = RuntimeNumOfHoursInOnePage;
			FCValuePointList fCValuePointList = method_40(fctitleLineInfo_0.Name);
			float tickCountFloat = CountDown.GetTickCountFloat();
			int count = class165_0.Count;
			_ = rectangleF_2.Width / (float)class165_0.Count;
			string[] array = null;
			if (!string.IsNullOrEmpty(fctitleLineInfo_0.LoopTextList))
			{
				array = fctitleLineInfo_0.LoopTextList.Split(',');
			}
			int num = 1;
			int num2 = -1;
			int num3 = class165_0.method_6(rectangleF_2, rectangleF_3);
			if (fctitleLineInfo_0.TickStep > 1)
			{
				int num4 = 1;
				if (array != null && array.Length > 0)
				{
					num4 = array.Length;
				}
				if (fctitleLineInfo_0.ValueType == FCTitleLineValueType.TickText)
				{
					num3 -= num3 % (fctitleLineInfo_0.TickStep * num4);
				}
				else
				{
					float num5 = fctitleLineInfo_0.TickStep;
					DCFriedmanCurveUnit dCFriedmanCurveUnit = Config.TickUnit;
					if (Config.TickUnit == DCFriedmanCurveUnit.Hour)
					{
						num5 = (float)fctitleLineInfo_0.TickStep * 24f / (float)Config.Ticks.Count;
						if (num5 == 24f)
						{
							num5 = 1f;
							dCFriedmanCurveUnit = DCFriedmanCurveUnit.Day;
						}
					}
					if (dCFriedmanCurveUnit == DCFriedmanCurveUnit.Day)
					{
						DateTime date = class165_0[num3].dateTime_0.Date;
						for (int num6 = num3 - 1; num6 >= 0; num6--)
						{
							if (class165_0[num6].dateTime_0.Day < date.Day)
							{
								num3 = num6 + 1;
							}
						}
					}
				}
			}
			for (int i = num3; i < count; i += num)
			{
				if (i != count - 1)
				{
				}
				DateTime dateTime = class165_0[i].dateTime_0;
				int num7 = i + 1;
				if (fctitleLineInfo_0.ValueType == FCTitleLineValueType.TickText && fctitleLineInfo_0.TickStep == 1)
				{
					num7 = i + 1;
				}
				else
				{
					float num5 = fctitleLineInfo_0.TickStep;
					DCFriedmanCurveUnit dCFriedmanCurveUnit = Config.TickUnit;
					if (Config.TickUnit == DCFriedmanCurveUnit.Hour)
					{
						num5 = (float)fctitleLineInfo_0.TickStep * 24f / (float)Config.Ticks.Count;
						if (num5 == 24f)
						{
							num5 = 1f;
							dCFriedmanCurveUnit = DCFriedmanCurveUnit.Day;
						}
					}
					dateTime = Class167.smethod_0(dateTime, num5, dCFriedmanCurveUnit, bool_0: true);
					num7 = class165_0.method_13(dateTime, bool_0: false, bool_1: true);
				}
				num = num7 - i;
				if (num <= 0)
				{
					num = 1;
				}
				num2++;
				RectangleF rectangleF_4 = new RectangleF(rectangleF_2.Left + class165_0.method_21(i), fctitleLineInfo_0.Top, 0f, fctitleLineInfo_0.RuntimeHeight);
				rectangleF_4.Width = class165_0.method_21(i + num) - class165_0.method_21(i);
				if (!(rectangleF_4.Left > rectangleF_3.Right - 2f))
				{
					rectangleF_4 = method_24(rectangleF_2, rectangleF_4);
					if (!rectangleF_3.IntersectsWith(rectangleF_4))
					{
						continue;
					}
					_ = CountDown.GetTickCountFloat() - tickCountFloat;
					dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : ForePen, rectangleF_4.Right, rectangleF_4.Top, rectangleF_4.Right, rectangleF_4.Bottom);
					RectangleF rectangleF = new RectangleF(rectangleF_4.Left, rectangleF_4.Top, rectangleF_4.Width, rectangleF_4.Height);
					FCValuePointList fCValuePointList2 = null;
					if (array != null && array.Length > 0)
					{
						if (fctitleLineInfo_0.RuntimeLayoutType != FCTitleLineLayoutType.Cascade && fctitleLineInfo_0.RuntimeLayoutType != FCTitleLineLayoutType.HorizCascade)
						{
							FCValuePoint fCValuePoint = new FCValuePoint();
							fCValuePoint.Text = array[num2 % array.Length];
							method_28(fctitleLineInfo_0, fCValuePoint, dcgraphics_0, rectangleF_4, i);
							continue;
						}
						fCValuePointList2 = new FCValuePointList();
						string[] array2 = array;
						foreach (string text in array2)
						{
							FCValuePoint fCValuePoint = new FCValuePoint();
							fCValuePoint.Text = text;
							fCValuePointList2.Add(fCValuePoint);
						}
					}
					else
					{
						fCValuePointList2 = new FCValuePointList();
						_ = (float)(int)Math.Floor((float)i / (float)Config.Ticks.Count);
						_ = i % Config.Ticks.Count;
						DateTime t = class165_0.method_9(i);
						DateTime t2 = class165_0.method_10(i + num - 1);
						if (t2.Day != t.Day)
						{
							t2 = t.Date.AddDays(1.0);
						}
						if (fCValuePointList.Count > 0)
						{
							int num8 = fCValuePointList.GetFloorIndexByTime(t);
							if (num8 < 0)
							{
								num8 = 0;
							}
							if (num8 >= 0)
							{
								for (int k = num8; k < fCValuePointList.Count; k++)
								{
									FCValuePoint fCValuePoint = fCValuePointList[k];
									if (!(fCValuePoint.Time >= t))
									{
										continue;
									}
									if (fCValuePoint.Time >= t2)
									{
										break;
									}
									if (!string.IsNullOrEmpty(fCValuePoint.RuntimeText))
									{
										fCValuePointList2.Add(fCValuePoint);
										if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Normal)
										{
											break;
										}
									}
								}
							}
						}
					}
					if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Normal)
					{
						if (fCValuePointList2.Count > 0)
						{
							method_28(fctitleLineInfo_0, fCValuePointList2[0], dcgraphics_0, rectangleF_4, i);
						}
					}
					else if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant2)
					{
						SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
						dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
						if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant)
						{
							dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : Pens.Black, rectangleF_4.Left, rectangleF_4.Top, rectangleF_4.Right, rectangleF_4.Bottom);
						}
						else
						{
							dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : Pens.Black, rectangleF_4.Right, rectangleF_4.Top, rectangleF_4.Left, rectangleF_4.Bottom);
						}
						dcgraphics_0.SmoothingMode = smoothingMode;
						if (fCValuePointList2.Count > 0)
						{
							method_28(fctitleLineInfo_0, fCValuePointList2[0], dcgraphics_0, new RectangleF(rectangleF_4.Left, rectangleF_4.Top, rectangleF_4.Width / 2f, rectangleF_4.Height), 0);
						}
						if (fCValuePointList2.Count > 1)
						{
							method_28(fctitleLineInfo_0, fCValuePointList2[1], dcgraphics_0, new RectangleF(rectangleF_4.Left + rectangleF_4.Width / 2f, rectangleF_4.Top, rectangleF_4.Width / 2f, rectangleF_4.Height), 1);
						}
					}
					else if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Cascade)
					{
						if (fCValuePointList2.Count > 0)
						{
							for (int num6 = 0; num6 < fCValuePointList2.Count; num6++)
							{
								method_28(fctitleLineInfo_0, fCValuePointList2[num6], dcgraphics_0, new RectangleF(rectangleF_4.Left, rectangleF_4.Top + (float)num6 * rectangleF_4.Height / (float)fCValuePointList2.Count, rectangleF_4.Width, rectangleF_4.Height / (float)fCValuePointList2.Count), i);
							}
						}
					}
					else if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.HorizCascade && fCValuePointList2.Count > 0)
					{
						for (int num6 = 0; num6 < fCValuePointList2.Count; num6++)
						{
							method_28(fctitleLineInfo_0, fCValuePointList2[num6], dcgraphics_0, new RectangleF(rectangleF_4.Left + (float)num6 * rectangleF_4.Width / (float)fCValuePointList2.Count, rectangleF_4.Top, rectangleF_4.Width / (float)fCValuePointList2.Count, rectangleF_4.Height), i);
						}
					}
					continue;
				}
				_ = CountDown.GetTickCountFloat() - tickCountFloat;
				break;
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private void method_26(FCTitleLineInfo fctitleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3)
		{
			XFontValue font = method_45(fctitleLineInfo_0, bool_3: true);
			_ = rectangleF_2.Width / (float)RuntimeNumOfHoursInOnePage;
			_ = (fctitleLineInfo_0.RuntimeHeight - dcgraphics_0.GetFontHeight(font)) / 2f;
			using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericTypographic.Clone())
			{
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
				int num = class165_0.method_6(rectangleF_2, rectangleF_3);
				for (int i = num; i < class165_0.Count; i++)
				{
					Class164 @class = class165_0[i];
					float num2 = rectangleF_2.Left + @class.float_0;
					if (!(num2 + @class.float_1 < rectangleF_3.Left))
					{
						if (num2 > rectangleF_3.Right || num2 >= rectangleF_2.Right - 2f)
						{
							break;
						}
						RectangleF rect = new RectangleF(num2, fctitleLineInfo_0.Top, @class.float_1, fctitleLineInfo_0.RuntimeHeight);
						Class164 class2 = class165_0[i];
						if (rectangleF_3.IntersectsWith(rect))
						{
							if (!string.IsNullOrEmpty(class2.string_0))
							{
								dcgraphics_0.DrawString(class2.string_0, font, method_8(class2.color_0), rect, drawStringFormatExt);
							}
							dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : ForePen, rect.Left, rect.Top, rect.Left, rect.Bottom);
							if (class2.int_1 == 0)
							{
								dcgraphics_0.DrawLine((fctitleLineInfo_0.TitleLineBorderStyle == FCTitleLineBorderStyle.None) ? new Pen(Color.Transparent) : GClass438.smethod_1(Config.BigVerticalGridLineColor), rect.Left, rect.Top, rect.Left, rect.Bottom);
							}
						}
					}
				}
			}
		}

		private void method_27(FCTitleLineInfo fctitleLineInfo_0, RectangleF rectangleF_2, DCGraphics dcgraphics_0, RectangleF rectangleF_3)
		{
			XFontValue font = method_45(fctitleLineInfo_0, bool_3: true);
			_ = rectangleF_2.Width / (float)RuntimeNumOfHoursInOnePage;
			_ = (fctitleLineInfo_0.RuntimeHeight - dcgraphics_0.GetFontHeight(font)) / 2f;
			using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericTypographic.Clone())
			{
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
				int num = class165_0.method_6(rectangleF_2, rectangleF_3);
				for (int i = num; i < class165_0.Count; i++)
				{
					Class164 @class = class165_0[i];
					float num2 = rectangleF_2.Left + @class.float_0;
					if (!(num2 + @class.float_1 < rectangleF_3.Left))
					{
						if (num2 > rectangleF_3.Right || num2 >= rectangleF_2.Right - 2f)
						{
							break;
						}
						RectangleF rect = new RectangleF(num2, fctitleLineInfo_0.Top, @class.float_1, fctitleLineInfo_0.RuntimeHeight);
						Class164 class2 = class165_0[i];
						if (rectangleF_3.IntersectsWith(rect))
						{
							if (!string.IsNullOrEmpty(class2.string_0))
							{
								dcgraphics_0.DrawString(class2.string_1, font, method_8(class2.color_0), rect, drawStringFormatExt);
							}
							if (fctitleLineInfo_0.TitleLineBorderStyle != 0)
							{
								dcgraphics_0.DrawLine(RuntimeForeColor, rect.Left, rect.Top, rect.Left, rect.Bottom);
							}
							if (class2.int_1 == 0 && fctitleLineInfo_0.TitleLineBorderStyle != 0)
							{
								dcgraphics_0.DrawLine(Config.BigVerticalGridLineColor, rect.Left, rect.Top, rect.Left, rect.Bottom);
							}
						}
					}
				}
			}
		}

		private void method_28(FCTitleLineInfo fctitleLineInfo_0, FCValuePoint fcvaluePoint_1, DCGraphics dcgraphics_0, RectangleF rectangleF_2, int int_6)
		{
			if (fcvaluePoint_1.InstanceIndex != 1074)
			{
			}
			if (dictionary_0 != null)
			{
				dictionary_0[fcvaluePoint_1] = rectangleF_2;
			}
			fcvaluePoint_1.ViewBounds = rectangleF_2;
			if (fcvaluePoint_1.Color.A != 0)
			{
				dcgraphics_0.FillRectangle(fcvaluePoint_1.Color, rectangleF_2);
				if (fctitleLineInfo_0.TitleLineBorderStyle != 0)
				{
					dcgraphics_0.DrawRectangle(RuntimeForeColor, rectangleF_2.Left, rectangleF_2.Top, rectangleF_2.Width, rectangleF_2.Height);
				}
			}
			if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Cascade)
			{
				if (fctitleLineInfo_0.TitleLineBorderStyle != 0)
				{
					dcgraphics_0.DrawLine(RuntimeForeColor, rectangleF_2.Left, rectangleF_2.Bottom, rectangleF_2.Right, rectangleF_2.Bottom);
				}
			}
			else if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.HorizCascade && fctitleLineInfo_0.TitleLineBorderStyle != 0)
			{
				dcgraphics_0.DrawLine(RuntimeForeColor, rectangleF_2.Right, rectangleF_2.Top, rectangleF_2.Right, rectangleF_2.Bottom);
			}
			Class164 @class = class165_0.method_8(int_6);
			if (@class != null && @class.int_1 == 0 && fctitleLineInfo_0.TitleLineBorderStyle != 0)
			{
				dcgraphics_0.DrawLine(Config.BigVerticalGridLineColor, rectangleF_2.Left, rectangleF_2.Top, rectangleF_2.Left, rectangleF_2.Bottom);
			}
			string runtimeText = fcvaluePoint_1.RuntimeText;
			if (!string.IsNullOrEmpty(runtimeText))
			{
				XFontValue xFontValue = method_45(fctitleLineInfo_0, bool_3: true);
				using (DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericTypographic.Clone())
				{
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
					if (fctitleLineInfo_0.ValueTextMultiLine)
					{
						drawStringFormatExt.FormatFlags &= ~StringFormatFlags.NoWrap;
					}
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
					drawStringFormatExt.Alignment = fctitleLineInfo_0.ValueAlign;
					if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant)
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
					else if (fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant2)
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
					else if (fctitleLineInfo_0.UpAndDownText)
					{
						if (fcvaluePoint_1.UpAndDown == FCValuePointUpAndDown.None)
						{
							if (int_6 / fctitleLineInfo_0.TickStep % 2 == 0)
							{
								drawStringFormatExt.LineAlignment = StringAlignment.Near;
							}
							else
							{
								drawStringFormatExt.LineAlignment = StringAlignment.Far;
							}
						}
						if (fcvaluePoint_1.UpAndDown == FCValuePointUpAndDown.Up)
						{
							drawStringFormatExt.LineAlignment = StringAlignment.Near;
						}
						else if (fcvaluePoint_1.UpAndDown == FCValuePointUpAndDown.Down)
						{
							drawStringFormatExt.LineAlignment = StringAlignment.Far;
						}
					}
					Color black = Color.Black;
					black = ((fctitleLineInfo_0 == null) ? Config.ForeColor : ((!Class163.smethod_3(fcvaluePoint_1.Value, fctitleLineInfo_0.NormalMaxValue, fctitleLineInfo_0.NormalMinValue)) ? fctitleLineInfo_0.TextColor : fctitleLineInfo_0.OutofNormalRangeTextColor));
					if (method_10(fcvaluePoint_1))
					{
						black = Color.Blue;
						xFontValue.Underline = true;
					}
					dcgraphics_0.DrawString(runtimeText, xFontValue, method_8(black), new RectangleF(rectangleF_2.Left + 1f, rectangleF_2.Top + 1f, rectangleF_2.Width - 1f, rectangleF_2.Height - 2f), drawStringFormatExt);
					if (fctitleLineInfo_0.CircleText == runtimeText)
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
						dcgraphics_0.DrawEllipse(fctitleLineInfo_0?.TextColor ?? RuntimeForeColor, rect);
						dcgraphics_0.SmoothingMode = smoothingMode;
					}
				}
			}
		}

		private void method_29(DCGraphics dcgraphics_0, Image image_0, float float_8, float float_9)
		{
			_ = (float)GraphicsUnitConvert.Convert(1.0, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			dcgraphics_0.DrawImageUnscaled(image_0, (int)float_8, (int)float_9);
		}

		private void method_30(float float_8, float float_9, DCGraphics dcgraphics_0, RectangleF rectangleF_2, XFontValue xfontValue_0)
		{
			rectangleF_1 = RectangleF.Empty;
			if (HeaderLabels == null || HeaderLabels.Count == 0)
			{
				return;
			}
			foreach (FCHeaderLabelInfo headerLabel in HeaderLabels)
			{
				headerLabel.method_0(dcgraphics_0, xfontValue_0);
				headerLabel.Height = float_9;
			}
			if (ViewMode == FCDocumentViewMode.FriedmanCurve || ViewMode == FCDocumentViewMode.Normal)
			{
				float num = Left;
				foreach (FCHeaderLabelInfo headerLabel2 in HeaderLabels)
				{
					headerLabel2.Left = num;
					headerLabel2.Top = Top + float_8;
					num += headerLabel2.Width + float_9;
				}
			}
			else
			{
				float num2 = Width;
				foreach (FCHeaderLabelInfo headerLabel3 in HeaderLabels)
				{
					num2 -= headerLabel3.Width;
				}
				if (HeaderLabels.Count > 1)
				{
					num2 /= (float)(HeaderLabels.Count - 1);
				}
				float num = Left;
			}
			foreach (FCHeaderLabelInfo headerLabel4 in HeaderLabels)
			{
				if (new RectangleF(headerLabel4.Left, headerLabel4.Top, headerLabel4.Width, headerLabel4.Height).IntersectsWith(rectangleF_2))
				{
					headerLabel4.OwnerDocument = this;
					headerLabel4.method_1(dcgraphics_0, xfontValue_0, Config.ForeColor, ViewMode.ToString());
				}
			}
		}

		private void method_31(FCTitleLineInfo fctitleLineInfo_0, FCYAxisScaleInfoList fcyaxisScaleInfoList_0, FCValuePointList fcvaluePointList_0, RectangleF rectangleF_2, float float_8, float float_9, DCGraphics dcgraphics_0, RectangleF rectangleF_3, DateTime dateTime_4, bool bool_3)
		{
			int num = 8;
			if (fcvaluePointList_0 == null || fcvaluePointList_0.Count == 0 || dcgraphics_0 == null)
			{
				return;
			}
			XFontValue xFontValue = method_45(fctitleLineInfo_0, bool_3: true);
			float tickCountFloat = CountDown.GetTickCountFloat();
			rectangleF_2.Y = -1000f;
			rectangleF_2.Height = 100000f;
			FCValuePoint fCValuePoint = null;
			Color transparent = Color.Transparent;
			_ = rectangleF_2.Width / (float)RuntimeNumOfHoursInOnePage;
			for (int num2 = fcvaluePointList_0.Count - 1; num2 >= 0; num2--)
			{
				FCValuePoint fCValuePoint2 = fcvaluePointList_0[num2];
				transparent = fCValuePoint2.Color;
				string text = fCValuePoint2.Text;
				FCYAxisScaleInfo scaleInfoByValue = fcyaxisScaleInfoList_0.GetScaleInfoByValue(fCValuePoint2.Value);
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
					text = fCValuePoint2.Value.ToString();
				}
				if (class165_0.Count <= 0 || (!(fCValuePoint2.Time >= class165_0.method_5().dateTime_1) && !(fCValuePoint2.Time < class165_0.method_0())))
				{
					fCValuePoint2.Left = class165_0.method_16(rectangleF_2, fCValuePoint2.Time);
					float num3 = 0f;
					bool flag = true;
					if (fctitleLineInfo_0 != null)
					{
						flag = fctitleLineInfo_0.EnableEndTime;
					}
					if (fctitleLineInfo_0 == null || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Free || fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant3)
					{
						num3 = ((flag && !smethod_4(fCValuePoint2.EndTime)) ? (class165_0.method_16(rectangleF_2, fCValuePoint2.EndTime) - fCValuePoint2.Left) : ((fCValuePoint != null) ? (fCValuePoint.Left - fCValuePoint2.Left) : (rectangleF_2.Right - fCValuePoint2.Left)));
					}
					else if (fctitleLineInfo_0 != null && fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.FreeText)
					{
						num3 = ((fCValuePoint != null) ? (fCValuePoint.Left - fCValuePoint2.Left) : (rectangleF_2.Right - fCValuePoint2.Left));
					}
					if (!(num3 <= 0f))
					{
						RectangleF rectangleF = new RectangleF(fCValuePoint2.Left, float_8, num3, float_9);
						RectangleF rectangleF2 = rectangleF;
						rectangleF = (fCValuePoint2.ViewBounds = RectangleF.Intersect(rectangleF, rectangleF_2));
						RectangleF rect = rectangleF;
						RectangleF a = rectangleF;
						if (fctitleLineInfo_0 != null && fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.FreeText)
						{
							float num4 = GraphicsUnitConvert.Convert(fctitleLineInfo_0.BlockWidth, GraphicsUnit.Document, dcgraphics_0.PageUnit);
							rect.Width -= num4 + 2f;
							rect.Offset(num4 + 2f, 0f);
							a = new RectangleF(rectangleF.Left, rectangleF.Top, num4, rectangleF.Height);
						}
						if (!rectangleF.IsEmpty)
						{
							RectangleF value = RectangleF.Intersect(rectangleF, rectangleF_3);
							if (!value.IsEmpty)
							{
								if (dictionary_0 != null)
								{
									dictionary_0[fCValuePoint2] = value;
								}
								a = RectangleF.Intersect(a, rectangleF_3);
								if (bool_3 && !a.IsEmpty && transparent.A != 0 && transparent.ToArgb() != Color.White.ToArgb())
								{
									dcgraphics_0.FillRectangle(transparent, a);
								}
								if (fctitleLineInfo_0 == null || fctitleLineInfo_0.VerticalLineForFreeeLayout)
								{
									Color color = ControlPaint.Dark(transparent);
									if (fctitleLineInfo_0 != null && fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant3 && text.IndexOf("/") > 0)
									{
										dcgraphics_0.DrawLine(color, rectangleF.Right, rectangleF.Top, rectangleF.Left, rectangleF.Bottom);
									}
									if (rectangleF2.Left >= rectangleF_2.Left && rectangleF2.Left <= rectangleF_2.Right)
									{
										dcgraphics_0.DrawLine(color, rectangleF.Left, rectangleF.Top, rectangleF.Left, rectangleF.Bottom);
									}
									if (rectangleF2.Right >= rectangleF_2.Left && rectangleF2.Right <= rectangleF_2.Right)
									{
										dcgraphics_0.DrawLine(color, a.Right, a.Top, a.Right, a.Bottom);
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
										if (fctitleLineInfo_0 != null && fctitleLineInfo_0.ValueTextMultiLine)
										{
											drawStringFormatExt.FormatFlags &= ~StringFormatFlags.NoWrap;
										}
										if (fctitleLineInfo_0 == null || fctitleLineInfo_0.RuntimeLayoutType != FCTitleLineLayoutType.FreeText || transparent.A == 0)
										{
											transparent = (fctitleLineInfo_0?.TextColor ?? Config.ForeColor);
										}
										XFontValue xFontValue2 = xFontValue;
										if (method_10(fCValuePoint2))
										{
											transparent = Color.Blue;
											xFontValue2 = xFontValue2.Clone();
											xFontValue2.Underline = true;
										}
										if (fctitleLineInfo_0 != null && fctitleLineInfo_0.RuntimeLayoutType == FCTitleLineLayoutType.Slant3 && text.IndexOf("/") > 0)
										{
											string text2 = text.Substring(0, text.IndexOf("/"));
											string text3 = text.Substring(text.IndexOf("/") + 1, text.Length - text.IndexOf("/") - 1);
											RectangleF rectangleF4 = new RectangleF(0f, 0f, 0f, 0f);
											RectangleF rectangleF5 = new RectangleF(0f, 0f, 0f, 0f);
											if (ViewMode == FCDocumentViewMode.Normal)
											{
												if (fctitleLineInfo_0.TickStep != 6)
												{
													rectangleF4 = new RectangleF(fCValuePoint2.Left + 16f, float_8 - 4f, num3, float_9);
													rectangleF5 = new RectangleF(fCValuePoint2.Left + 180f, float_8 + 26f, num3 - 61f, float_9 - 22f);
												}
												else
												{
													rectangleF4 = new RectangleF(fCValuePoint2.Left + 2f, float_8 - 7f, num3, float_9);
													rectangleF5 = new RectangleF(fCValuePoint2.Left + 127f, float_8 + 24f, num3 - 61f, float_9 - 22f);
												}
											}
											else if (ViewMode == FCDocumentViewMode.Page)
											{
												if (fctitleLineInfo_0.TickStep != 6)
												{
													rectangleF4 = new RectangleF(fCValuePoint2.Left - 3f, float_8 - 10f, num3, float_9);
													rectangleF5 = new RectangleF(fCValuePoint2.Left + 70f, float_8 + 26f, num3 - 61f, float_9 - 22f);
												}
												else
												{
													rectangleF4 = new RectangleF(fCValuePoint2.Left - 1f, float_8 - 11f, num3, float_9);
													rectangleF5 = new RectangleF(fCValuePoint2.Left + 112f, float_8 + 24f, num3 - 61f, float_9 - 22f);
												}
											}
											else if (fctitleLineInfo_0.TickStep != 6)
											{
												rectangleF4 = new RectangleF(fCValuePoint2.Left - 3f, float_8 - 10f, num3, float_9);
												rectangleF5 = new RectangleF(fCValuePoint2.Left + 70f, float_8 + 26f, num3 - 61f, float_9 - 22f);
											}
											else
											{
												rectangleF4 = new RectangleF(fCValuePoint2.Left + 10f, float_8 - 8f, num3, float_9);
												rectangleF5 = new RectangleF(fCValuePoint2.Left + 154f, float_8 + 24f, num3 - 61f, float_9 - 22f);
											}
											dcgraphics_0.DrawString(text3, xFontValue2, method_8(transparent), rectangleF5, drawStringFormatExt);
											dcgraphics_0.DrawString(text2, xFontValue2, method_8(transparent), rectangleF4, drawStringFormatExt);
										}
										else
										{
											dcgraphics_0.DrawString(text, xFontValue2, method_8(transparent), rect, drawStringFormatExt);
										}
									}
								}
							}
						}
						fCValuePoint = fCValuePoint2;
					}
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		private float method_32(int int_6)
		{
			FCTickInfoList ticks = Config.Ticks;
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

		private float method_33(int int_6)
		{
			FCTickInfoList ticks = Config.Ticks;
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

		private void method_34(DCGraphics dcgraphics_0, RectangleF rectangleF_2, RectangleF rectangleF_3)
		{
			_ = RuntimeNumOfHoursInOnePage * Config.Ticks.Count;
			int num = Config.GridYSplitInfo.GridYSplitNum * Config.GridYSplitInfo.GridYSpaceNum;
			CountDown.GetTickCountFloat();
			if (rectangleF_3.IsEmpty)
			{
				rectangleF_3 = rectangleF_2;
			}
			if (Config.Zones != null)
			{
				foreach (FriedmanCurveZoneInfo zone in Config.Zones)
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
			Class164 @class = class165_0[0];
			FriedmanCurveZoneInfo friedmanCurveZoneInfo_ = @class.friedmanCurveZoneInfo_0;
			List<float> list = new List<float>();
			for (int i = 0; i < class165_0.Count; i++)
			{
				Class164 class2 = class165_0[i];
				if (class2.friedmanCurveZoneInfo_0 != null)
				{
					if (class2.friedmanCurveZoneInfo_0.FirstTickItem == null)
					{
						class2.friedmanCurveZoneInfo_0.FirstTickItem = class2;
						class2.friedmanCurveZoneInfo_0.Left = rectangleF_2.Left + class2.float_0;
					}
					class2.friedmanCurveZoneInfo_0.LastTickItem = class2;
					class2.friedmanCurveZoneInfo_0.Width = rectangleF_2.Left + class2.float_0 - class2.friedmanCurveZoneInfo_0.Left + class2.float_1;
				}
				if (class2.friedmanCurveZoneInfo_0 == friedmanCurveZoneInfo_ && i != class165_0.Count - 1)
				{
					continue;
				}
				Color color = Config.GridBackColor;
				Color color2 = method_8(Config.GridLineColor);
				DashStyle dashStyle = DashStyle.Solid;
				if (friedmanCurveZoneInfo_ != null)
				{
					color = friedmanCurveZoneInfo_.BackColor;
					color2 = friedmanCurveZoneInfo_.GridLineColor;
					dashStyle = friedmanCurveZoneInfo_.GridLineStyle;
				}
				RectangleF a = new RectangleF(rectangleF_2.Left + @class.float_0, rectangleF_2.Top, class2.float_0 - @class.float_0, rectangleF_2.Height);
				int num2 = i - 1;
				Class164 class3 = class165_0.method_8(i + 1);
				if (class3 != null && friedmanCurveZoneInfo_ != null && class3.friedmanCurveZoneInfo_0 != null)
				{
					num2 = i;
				}
				if (class2.friedmanCurveZoneInfo_0 == friedmanCurveZoneInfo_)
				{
					num2 = i;
					a.Width = class2.float_0 - @class.float_0 + class2.float_1;
				}
				RectangleF rect = RectangleF.Intersect(a, rectangleF_3);
				if (rect.IsEmpty)
				{
					friedmanCurveZoneInfo_ = class2.friedmanCurveZoneInfo_0;
					@class = class2;
					continue;
				}
				if (color.A != 0)
				{
					dcgraphics_0.FillRectangle(color, rect);
				}
				using (XPenStyle xPenStyle = new XPenStyle(color2, method_9(1f)))
				{
					xPenStyle.DashStyle = dashStyle;
					int num3 = class165_0.IndexOf(@class);
					bool flag = true;
					if (num3 > 0)
					{
						Class164 class4 = class165_0[num3 - 1];
						int num4 = (class4.friedmanCurveZoneInfo_0 == null) ? (-1) : class4.friedmanCurveZoneInfo_0.ZoneIndex;
						Class164 class5 = class165_0[num3];
						int num5 = (class5.friedmanCurveZoneInfo_0 == null) ? (-1) : class5.friedmanCurveZoneInfo_0.ZoneIndex;
						flag = ((num5 >= num4) ? true : false);
					}
					for (int j = num3; j <= num2; j++)
					{
						Class164 class6 = class165_0[j];
						if (xPenStyle.DashStyle != dashStyle)
						{
							xPenStyle.DashStyle = dashStyle;
						}
						if (j > 0)
						{
							Class164 class4 = class165_0[j - 1];
							if (class4.friedmanCurveZoneInfo_0 != class6.friedmanCurveZoneInfo_0)
							{
								xPenStyle.DashStyle = DashStyle.Solid;
							}
						}
						Class164 class7 = class165_0.method_8(j + 1);
						if (class7 != null && class7.friedmanCurveZoneInfo_0 != class6.friedmanCurveZoneInfo_0)
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
							if (class6.friedmanCurveZoneInfo_0 == null && class6.int_1 == 0 && j != num3)
							{
								list.Add(num6);
							}
						}
					}
					xPenStyle.DashStyle = dashStyle;
					List<float> list2 = new List<float>();
					foreach (FCYAxisInfo yAxisInfo in YAxisInfos)
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
						if (!(num6 < rect.Top))
						{
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
							if (!flag2)
							{
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
						}
					}
				}
				friedmanCurveZoneInfo_ = class2.friedmanCurveZoneInfo_0;
				@class = class2;
			}
			if (Config.AllowUserCollapseZone && Config.Zones != null)
			{
				Image collapse = DCFriedmanCurveImageResources.Collapse;
				Image expand = DCFriedmanCurveImageResources.Expand;
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(collapse.Width, collapse.Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				float num9 = GraphicsUnitConvert.Convert(3, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				foreach (FriedmanCurveZoneInfo zone2 in Config.Zones)
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
					using (Pen pen_ = new Pen(Config.BigVerticalGridLineColor, method_9(2f)))
					{
						dcgraphics_0.DrawLine(pen_, num6, rectangleF_2.Top, num6, rectangleF_2.Bottom);
					}
				}
			}
		}

		private void method_35(FCYAxisInfo fcyaxisInfo_0, DCGraphics dcgraphics_0, RectangleF rectangleF_2, float float_8, DrawStringFormatExt drawStringFormatExt_2, XFontValue xfontValue_0)
		{
			fcyaxisInfo_0.bool_14 = true;
			RectangleF rect = new RectangleF(fcyaxisInfo_0.TitleLeft, rectangleF_0.Top + (float)GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), fcyaxisInfo_0.TitleWidth, float_8);
			Color color = fcyaxisInfo_0.TitleBackColor;
			if (!fcyaxisInfo_0.ValueVisible)
			{
				color = fcyaxisInfo_0.HiddenValueTitleBackColor;
			}
			if (color.A != 0)
			{
				dcgraphics_0.FillRectangle(color, fcyaxisInfo_0.TitleLeft + 1f, fcyaxisInfo_0.TitleTop + 1f, fcyaxisInfo_0.TitleWidth - 2f, fcyaxisInfo_0.TitleHeight - 2f);
			}
			if (!string.IsNullOrEmpty(fcyaxisInfo_0.Title))
			{
				using (DrawStringFormatExt drawStringFormatExt = drawStringFormatExt_2.Clone())
				{
					if (fcyaxisInfo_0.SpecifyTitleWidth > 0f)
					{
						drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
					}
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Near;
					rect.Height = dcgraphics_0.MeasureString(fcyaxisInfo_0.Title, xfontValue_0, (int)rect.Width, drawStringFormatExt).Height * 1.05f;
					dcgraphics_0.DrawString(fcyaxisInfo_0.Title, xfontValue_0, fcyaxisInfo_0.TitleColor, rect, drawStringFormatExt);
				}
			}
			rect.Offset(0f, rect.Height);
			if (fcyaxisInfo_0.ShowLegendInRule)
			{
				method_38(dcgraphics_0, rectangleF_2, rect.Left + rect.Width / 2f, fcyaxisInfo_0.TitleTop + (float)GraphicsUnitConvert.Convert(10, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), fcyaxisInfo_0.SymbolStyle, fcyaxisInfo_0.SymbolColor, null, float.NaN);
			}
			if (!string.IsNullOrEmpty(fcyaxisInfo_0.BottomTitle))
			{
				using (DrawStringFormatExt drawStringFormatExt = drawStringFormatExt_2.Clone())
				{
					if (fcyaxisInfo_0.SpecifyTitleWidth > 0f)
					{
						drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.NoClip);
					}
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Far;
					dcgraphics_0.DrawString(rect: new RectangleF(fcyaxisInfo_0.TitleLeft, fcyaxisInfo_0.TitleBottom - float_8, fcyaxisInfo_0.TitleWidth, float_8), string_0: fcyaxisInfo_0.BottomTitle, font: xfontValue_0, color_0: fcyaxisInfo_0.TitleColor, format: drawStringFormatExt);
				}
			}
			int num = fcyaxisInfo_0.YSplitNum;
			if (fcyaxisInfo_0.HasScales)
			{
				num = fcyaxisInfo_0.Scales.Count - 1;
				fcyaxisInfo_0.Scales.SortByValue();
				fcyaxisInfo_0.Scales.Reverse();
			}
			for (int i = 0; i <= num; i++)
			{
				RectangleF rect3 = new RectangleF(fcyaxisInfo_0.TitleLeft, method_11(rectangleF_0, (float)i / (float)num, fcyaxisInfo_0), fcyaxisInfo_0.TitleWidth, float_8);
				float num2 = fcyaxisInfo_0.MaxValue - (fcyaxisInfo_0.MaxValue - fcyaxisInfo_0.MinValue) * (float)i / (float)num;
				string value = num2.ToString();
				if (fcyaxisInfo_0.HasScales)
				{
					FCYAxisScaleInfo fCYAxisScaleInfo = fcyaxisInfo_0.Scales[i];
					num2 = fCYAxisScaleInfo.Value;
					rect3.Y = method_11(rectangleF_0, 1f - fCYAxisScaleInfo.ScaleRate, fcyaxisInfo_0);
					value = (string.IsNullOrEmpty(fCYAxisScaleInfo.Text) ? num2.ToString() : fCYAxisScaleInfo.Text);
				}
				if (fcyaxisInfo_0.Style != 0)
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
					if (!string.IsNullOrEmpty(fcyaxisInfo_0.BottomTitle) && Config.DataGridBottomPadding <= 0f)
					{
						continue;
					}
					if (Config.DataGridBottomPadding <= 0f)
					{
						if (num2 <= fcyaxisInfo_0.MinValue + (fcyaxisInfo_0.MaxValue - fcyaxisInfo_0.MinValue) * 0.08f)
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
					dcgraphics_0.DrawString(value, xfontValue_0, fcyaxisInfo_0.TitleColor, rect3, drawStringFormatExt_2);
				}
			}
			dcgraphics_0.DrawLine(ForePen, fcyaxisInfo_0.TitleLeft + fcyaxisInfo_0.TitleWidth, fcyaxisInfo_0.TitleTop, fcyaxisInfo_0.TitleLeft + fcyaxisInfo_0.TitleWidth, rectangleF_0.Bottom);
		}

		private void method_36(DCGraphics dcgraphics_0, float float_8, float float_9, bool bool_3, FCValuePoint fcvaluePoint_1, Color color_1)
		{
			if (bitmap_1 == null)
			{
				bitmap_1 = DCFriedmanCurveImageResources.ArrowDown;
				bitmap_1.MakeTransparent(Color.Red);
				bitmap_0 = DCFriedmanCurveImageResources.ArrowUp;
				bitmap_0.MakeTransparent(Color.Red);
			}
			SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(bitmap_0.Width, bitmap_0.Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			float num = GraphicsUnitConvert.Convert(SymbolSize, GraphicsUnit.Document, dcgraphics_0.PageUnit);
			string text = fcvaluePoint_1.Text;
			if (string.IsNullOrEmpty(text))
			{
				text = fcvaluePoint_1.ValueString;
			}
			XFontValue font = method_47();
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

		internal Bitmap method_37(FCYAxisInfo fcyaxisInfo_0)
		{
			Bitmap bitmap = new Bitmap(16, 16);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.White);
				float num = GraphicsUnitConvert.Convert(16, GraphicsUnit.Pixel, GraphicsUnit.Document);
				graphics.PageUnit = GraphicsUnit.Document;
				method_38(new DCGraphics(graphics), new RectangleF(0f, 0f, num, num), num / 2f, num / 2f, fcyaxisInfo_0.SymbolStyle, fcyaxisInfo_0.SymbolColor, null, num / 2f);
			}
			return bitmap;
		}

		private void method_38(DCGraphics dcgraphics_0, RectangleF rectangleF_2, float float_8, float float_9, FCValuePointSymbolStyle fcvaluePointSymbolStyle_0, Color color_1, FCValuePoint fcvaluePoint_1, float float_10)
		{
			color_1 = method_8(color_1);
			float num = GraphicsUnitConvert.Convert(float.IsNaN(float_10) ? SymbolSize : float_10, GraphicsUnit.Document, dcgraphics_0.PageUnit);
			RectangleF rectangleF = new RectangleF(float_8 - num / 2f, float_9 - num / 2f, num, num);
			float num2 = GraphicsUnitConvert.Convert(2, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			if (fcvaluePoint_1 != null)
			{
				fcvaluePoint_1.ViewBounds = rectangleF;
			}
			if (rectangleF_2.IsEmpty || !rectangleF_2.IntersectsWith(rectangleF))
			{
				return;
			}
			if (dictionary_0 != null && fcvaluePoint_1 != null)
			{
				dictionary_0[fcvaluePoint_1] = rectangleF;
			}
			if (fcvaluePoint_1 != null && fcvaluePoint_1.SpecifySymbolStyle != FCValuePointSymbolStyle.Default)
			{
				fcvaluePointSymbolStyle_0 = fcvaluePoint_1.SpecifySymbolStyle;
			}
			if (fcvaluePoint_1 != null && fcvaluePoint_1.CustomImage != null)
			{
				dcgraphics_0.DrawImage(fcvaluePoint_1.CustomImage.Value, new Rectangle((int)rectangleF.Left, (int)rectangleF.Top, fcvaluePoint_1.CustomImage.Width * 3, fcvaluePoint_1.CustomImage.Height * 3));
			}
			else if (fcvaluePointSymbolStyle_0 != 0)
			{
				SmoothingMode smoothingMode = dcgraphics_0.SmoothingMode;
				dcgraphics_0.SmoothingMode = SmoothingMode.AntiAlias;
				switch (fcvaluePointSymbolStyle_0)
				{
				case FCValuePointSymbolStyle.SolidCicle:
					dcgraphics_0.FillEllipse(color_1, rectangleF);
					break;
				case FCValuePointSymbolStyle.HollowCicle:
					dcgraphics_0.DrawEllipse(color_1, num2, rectangleF);
					break;
				case FCValuePointSymbolStyle.Cross:
					dcgraphics_0.DrawLine(color_1, num2, rectangleF.Left, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
					dcgraphics_0.DrawLine(color_1, num2, rectangleF.Left, rectangleF.Bottom, rectangleF.Right, rectangleF.Top);
					break;
				case FCValuePointSymbolStyle.Square:
					dcgraphics_0.FillRectangle(color_1, rectangleF);
					break;
				case FCValuePointSymbolStyle.HollowSquare:
					dcgraphics_0.DrawRectangle(color_1, num2, rectangleF.Left, rectangleF.Top, rectangleF.Width, rectangleF.Height);
					break;
				case FCValuePointSymbolStyle.Diamond:
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
				case FCValuePointSymbolStyle.HollowDiamond:
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
				case FCValuePointSymbolStyle.V:
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
				case FCValuePointSymbolStyle.VReversed:
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
				}
				dcgraphics_0.SmoothingMode = smoothingMode;
			}
		}

		/// <summary>
		///       清除数据
		///       </summary>
		public void ClearData()
		{
			Datas.Clear();
		}

		public void method_39()
		{
			foreach (FCDocumentData data in Datas)
			{
				data.Values.SortInvalidate = true;
			}
		}

		internal FCValuePointList method_40(string string_1)
		{
			return Datas.GetValuesByName(string_1);
		}

		public FCTitleLineInfo method_41(string string_1)
		{
			FCTitleLineInfo itemByName = HeaderLines.GetItemByName(string_1);
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
			foreach (FCHeaderLabelInfo headerLabel in HeaderLabels)
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
			FCValuePointList fCValuePointList = method_40(name);
			if (fCValuePointList != null)
			{
				lock (this)
				{
					fCValuePointList.AddByTimeValue(dateTime_4, Value);
				}
			}
		}

		/// <summary>
		///       添加数据点
		///       </summary>
		/// <param name="name">数据序列的名称</param>
		/// <param name="point">数据点对象</param>
		public void AddPoint(string name, FCValuePoint point)
		{
			int num = 17;
			if (point == null)
			{
				throw new ArgumentNullException("point");
			}
			FCValuePointList fCValuePointList = method_40(name);
			if (fCValuePointList != null)
			{
				lock (this)
				{
					fCValuePointList.Add(point);
					fCValuePointList.SortInvalidate = true;
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
			FCValuePointList fCValuePointList = method_40(name);
			if (fCValuePointList != null)
			{
				lock (this)
				{
					fCValuePointList.AddByTimeText(dateTime_4, text);
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
			FCValuePointList fCValuePointList = method_40(name);
			if (fCValuePointList != null)
			{
				lock (this)
				{
					fCValuePointList.AddByTimeTextValue(dateTime_4, text, Value);
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
			FCValuePointList fCValuePointList = method_40(name);
			if (fCValuePointList != null)
			{
				FCValuePoint fCValuePoint = new FCValuePoint();
				fCValuePoint.Time = dateTime_4;
				fCValuePoint.Text = text;
				fCValuePoint.ColorValue = htmlColorValue;
				lock (this)
				{
					fCValuePointList.Add(fCValuePoint);
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
			FCValuePointList fCValuePointList = method_40(name);
			if (fCValuePointList != null)
			{
				lock (this)
				{
					fCValuePointList.AddByTimeValueLandernValue(dateTime_4, Value, landernValue);
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
			FCTitleLineInfo fCTitleLineInfo = method_41(name);
			if (fCTitleLineInfo != null)
			{
				fCTitleLineInfo.StartDate = startDate;
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
		public bool SetFriedmanCurveZoneRange(string zoneName, DateTime startTime, DateTime endTime)
		{
			FriedmanCurveZoneInfo byName = Config.Zones.GetByName(zoneName);
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
			FriedmanCurveZoneInfo byName = Config.Zones.GetByName(zoneName);
			if (byName != null)
			{
				FCValuePointList fCValuePointList = method_40(valueName);
				if (fCValuePointList != null && fCValuePointList.Count > 0)
				{
					foreach (FCValuePoint item in fCValuePointList)
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
		public int SetSymbolStyleByTimeZone(string zoneName, string valueName, FCValuePointSymbolStyle style)
		{
			int num = 0;
			FriedmanCurveZoneInfo byName = Config.Zones.GetByName(zoneName);
			if (byName != null)
			{
				FCValuePointList fCValuePointList = method_40(valueName);
				if (fCValuePointList != null && fCValuePointList.Count > 0)
				{
					foreach (FCValuePoint item in fCValuePointList)
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

		internal FCValuePointList method_42()
		{
			lock (this)
			{
				FCValuePointList fCValuePointList = new FCValuePointList();
				foreach (FCYAxisInfo yAxisInfo in YAxisInfos)
				{
					if (yAxisInfo.Visible)
					{
						fCValuePointList.AddRange(method_40(yAxisInfo.Name));
					}
				}
				foreach (FCTitleLineInfo headerLine in HeaderLines)
				{
					if (headerLine.ValueType == FCTitleLineValueType.Data)
					{
						fCValuePointList.AddRange(method_40(headerLine.Name));
					}
				}
				foreach (FCTitleLineInfo footerLine in FooterLines)
				{
					if (footerLine.ValueType == FCTitleLineValueType.Data)
					{
						fCValuePointList.AddRange(method_40(footerLine.Name));
					}
				}
				return fCValuePointList;
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

		private void method_43(DateTime dateTime_4, DateTime dateTime_5, DateTime dateTime_6, int int_6)
		{
			float tickCountFloat = CountDown.GetTickCountFloat();
			if (Config.Zones != null)
			{
				Config.Zones.RefreshState();
			}
			class165_0 = new Class165();
			class165_0.method_1(dateTime_4);
			class165_0.method_3(dateTime_5);
			class165_0.dcfriedmanCurveUnit_0 = Config.TickUnit;
			Config.CheckDefaultTicks();
			class165_0.method_14(0, dateTime_4, dateTime_5, dateTime_6, Config.Ticks, null);
			if (Config.Zones != null && Config.Zones.Count > 0)
			{
				foreach (FriedmanCurveZoneInfo zone in Config.Zones)
				{
					bool flag = false;
					for (FriedmanCurveZoneInfo parentZone = zone.ParentZone; parentZone != null; parentZone = parentZone.ParentZone)
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
						for (int i = 0; i < class165_0.Count; i++)
						{
							if (class165_0[i].dateTime_1 >= t)
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
						for (int i = num; i < class165_0.Count; i++)
						{
							try
							{
								Class164 @class = class165_0[i];
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
								num2 = class165_0.Count;
							}
							if (num2 - num > 1)
							{
								class165_0.RemoveRange(num + 1, num2 - num - 1);
							}
							class165_0.method_14(num + 1, t, t2, dateTime_6, zone.Ticks, zone);
						}
					}
				}
			}
			if (int_6 > 0 && int_6 < class165_0.Count)
			{
				class165_0.RemoveRange(int_6, class165_0.Count - int_6);
			}
			for (int i = 0; i < class165_0.Count; i++)
			{
				class165_0[i].int_0 = i;
			}
			DateTime t3 = class165_0[0].dateTime_0.Date.AddDays(-1.0);
			foreach (Class164 item in class165_0)
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
				foreach (FCDocumentData data in Datas)
				{
					FCValuePointList values = data.Values;
					if (values.Count > 0)
					{
						values.CheckSortInvalidate();
						if (maxDate == NullDate || maxDate < values.MaxDate)
						{
							maxDate = values.MaxDate;
						}
						if (minDate == NullDate || minDate > values.MinDate)
						{
							minDate = values.MinDate;
						}
						if (dateTime_3 == NullDate || dateTime_3 < values.MaxDate)
						{
							dateTime_3 = values.MaxDate;
						}
					}
				}
				if (ViewMode == FCDocumentViewMode.FriedmanCurve)
				{
					maxDate = maxDate.AddDays(Config.ExtendDaysForFriedmanCurve);
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
				foreach (FriedmanCurveZoneInfo zone in Config.Zones)
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
				int_1 = timeSpan.Days;
				int_5 = (int)Math.Ceiling((double)timeSpan.Days / (double)RuntimeNumOfHoursInOnePage);
				if (int_5 == 0)
				{
					int_5 = 1;
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
				minDate = maxDate.AddDays(-NumOfHoursInOnePage);
				int_5 = 1;
				PageIndex = 0;
			}
		}

		public void method_44(IDbConnection idbConnection_0)
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
					foreach (FCHeaderLabelInfo headerLabel in Config.HeaderLabels)
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
						foreach (FCHeaderLabelInfo headerLabel2 in Config.HeaderLabels)
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
				Dictionary<FCValuePointDataSourceInfo, FCValuePointList> dictionary = new Dictionary<FCValuePointDataSourceInfo, FCValuePointList>();
				foreach (FCTitleLineInfo headerLine in Config.HeaderLines)
				{
					if (headerLine.DataSource != null)
					{
						dictionary[headerLine.DataSource] = Datas.GetValuesByName(headerLine.Name);
					}
				}
				foreach (FCTitleLineInfo footerLine in Config.FooterLines)
				{
					if (footerLine.DataSource != null)
					{
						dictionary[footerLine.DataSource] = Datas.GetValuesByName(footerLine.Name);
					}
				}
				foreach (FCYAxisInfo yAxisInfo in Config.YAxisInfos)
				{
					if (yAxisInfo.DataSource != null)
					{
						dictionary[yAxisInfo.DataSource] = Datas.GetValuesByName(yAxisInfo.Name);
					}
				}
				foreach (FCValuePointDataSourceInfo key2 in dictionary.Keys)
				{
					if (!string.IsNullOrEmpty(key2.SQLText))
					{
						FCValuePointList fCValuePointList = dictionary[key2];
						fCValuePointList.Clear();
						dbCommand.CommandText = key2.SQLText;
						IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
						int num3 = key2.Fill(dataReader, fCValuePointList);
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
				foreach (FCHeaderLabelInfo headerLabel in HeaderLabels)
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
				foreach (FCYAxisInfo yAxisInfo in YAxisInfos)
				{
					if (!string.IsNullOrEmpty(yAxisInfo.DataSourceName))
					{
						object obj = DataSources[yAxisInfo.DataSourceName];
						if (obj != null)
						{
							FCValuePointList valuesByName = Datas.GetValuesByName(yAxisInfo.Name);
							valuesByName.BindingDataSource(obj, yAxisInfo.TimeFieldName, yAxisInfo.ValueFieldName, yAxisInfo.LanternValueFieldName, yAxisInfo.Style == FCYAxisInfoStyle.Text);
							valuesByName.SortByTime();
						}
					}
				}
				foreach (FCTitleLineInfo footerLine in FooterLines)
				{
					if (!string.IsNullOrEmpty(footerLine.DataSourceName))
					{
						object obj = DataSources[footerLine.DataSourceName];
						if (obj != null)
						{
							FCValuePointList valuesByName = Datas.GetValuesByName(footerLine.Name);
							valuesByName.BindingDataSource(obj, footerLine.TimeFieldName, footerLine.ValueFieldName, null, textMode: true);
							valuesByName.SortByTime();
						}
					}
				}
				foreach (FCTitleLineInfo headerLine in HeaderLines)
				{
					if (!string.IsNullOrEmpty(headerLine.DataSourceName))
					{
						object obj = DataSources[headerLine.DataSourceName];
						if (obj != null)
						{
							FCValuePointList valuesByName = Datas.GetValuesByName(headerLine.Name);
							valuesByName.BindingDataSource(obj, headerLine.TimeFieldName, headerLine.ValueFieldName, null, textMode: true);
							valuesByName.SortByTime();
						}
					}
				}
			}
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

		private XFontValue method_45(FCTitleLineInfo fctitleLineInfo_0, bool bool_3)
		{
			XFontValue xFontValue = null;
			if (fctitleLineInfo_0 != null)
			{
				if (bool_3)
				{
					xFontValue = fctitleLineInfo_0.ValueFont;
					if (xFontValue == null)
					{
						xFontValue = fctitleLineInfo_0.Font;
					}
				}
				else
				{
					xFontValue = fctitleLineInfo_0.Font;
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

		private XFontValue method_46(FCYAxisInfo fcyaxisInfo_0, bool bool_3)
		{
			XFontValue xFontValue = null;
			if (fcyaxisInfo_0 != null)
			{
				if (bool_3)
				{
					xFontValue = fcyaxisInfo_0.ValueFont;
					if (xFontValue == null)
					{
						xFontValue = fcyaxisInfo_0.Font;
					}
				}
				else
				{
					xFontValue = fcyaxisInfo_0.Font;
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

		private XFontValue method_47()
		{
			return Config.RuntimeFont;
		}

		private XFontValue method_48()
		{
			string text = FontName;
			if (string.IsNullOrEmpty(text))
			{
				text = Control.DefaultFont.Name;
			}
			return new XFontValue(text, Config.BigTitleFontSize);
		}

		public string method_49()
		{
			int num = 5;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<table border='1'>");
			stringBuilder.AppendLine("\t<tr bgcolor='#dddddd'><td>时间</td>");
			List<string> list = new List<string>();
			foreach (FCDocumentData data in Datas)
			{
				string str = data.Name;
				FCTitleLineInfo fCTitleLineInfo = method_41(data.Name);
				if (fCTitleLineInfo != null)
				{
					if (!string.IsNullOrEmpty(fCTitleLineInfo.Title))
					{
						str = fCTitleLineInfo.Title;
					}
				}
				else
				{
					FCYAxisInfo itemByName = YAxisInfos.GetItemByName(data.Name);
					if (itemByName != null && !string.IsNullOrEmpty(itemByName.Title))
					{
						str = itemByName.Title;
						if (itemByName.Style == FCYAxisInfoStyle.Value)
						{
							list.Add(data.Name);
						}
					}
				}
				stringBuilder.AppendLine("\t<td>" + str + "</td>");
			}
			stringBuilder.AppendLine("\t</tr>");
			List<DateTime> list2 = new List<DateTime>();
			foreach (FCDocumentData data2 in Datas)
			{
				foreach (FCValuePoint value in data2.Values)
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
				foreach (FCDocumentData data3 in Datas)
				{
					bool flag = false;
					foreach (FCValuePoint value2 in data3.Values)
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

		private void method_50()
		{
			float num = float_7;
			if ((ViewMode == FCDocumentViewMode.Page || ViewMode == FCDocumentViewMode.Normal) && LeftHeaderWidth > 0f)
			{
				float num2 = 0f;
				int num3 = 0;
				foreach (Class164 item in class165_0)
				{
					if (item.friedmanCurveZoneInfo_0 != null && item.friedmanCurveZoneInfo_0.SpecifyTickWidth > 0f)
					{
						num2 += item.friedmanCurveZoneInfo_0.SpecifyTickWidth;
					}
					else
					{
						num2 += float_7;
						num3++;
					}
				}
				if (num2 != Width - LeftHeaderWidth && num3 > 0)
				{
					num = (Width - LeftHeaderWidth) / (float)num3;
					if (num <= 0f)
					{
						num = float_7;
					}
				}
			}
			float num4 = 0f;
			foreach (Class164 item2 in class165_0)
			{
				item2.float_0 = num4;
				if (item2.friedmanCurveZoneInfo_0 != null && item2.friedmanCurveZoneInfo_0.SpecifyTickWidth > 0f)
				{
					item2.float_1 = item2.friedmanCurveZoneInfo_0.SpecifyTickWidth;
				}
				else
				{
					item2.float_1 = num;
				}
				num4 += item2.float_1;
			}
			class165_0.method_20(num4);
		}

		internal SizeF method_51(Graphics graphics_0)
		{
			int num = 19;
			graphics_0.PageUnit = GraphicsUnit;
			Config.CheckDefaultTicks();
			DateTime maxDate = NullDate;
			DateTime minDate = NullDate;
			UpdateNumOfPage(out maxDate, out minDate);
			_ = (int)maxDate.Subtract(minDate).TotalDays;
			method_43(minDate, maxDate, minDate, 0);
			_ = class165_0.Count;
			method_4(new DCGraphics(graphics_0));
			float num2 = float_1;
			float num3 = 0f;
			XFontValue xFontValue = method_47();
			_ = graphics_0.MeasureString("HHHH", xFontValue.Value).Width;
			float num4 = Config.SpecifyTickWidth;
			if (num4 <= 0f)
			{
				num4 = graphics_0.MeasureString("HH", xFontValue.Value, 10000, StringFormat.GenericTypographic).Width * 1.1f;
			}
			float_7 = num4;
			method_50();
			num2 += class165_0.method_19();
			float num5 = xFontValue.GetHeight(graphics_0) * 1.1f;
			num3 = num5 * (float)(RuntimeHeaderLines.Count + RuntimeFooterLines.Count);
			num3 += 1000f;
			return new SizeF(num2, num3);
		}

		internal void method_52()
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
				method_13(new DCGraphics(graphics), new RectangleF(0f, 0f, Right, Bottom), GEnum23.const_2);
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
			if (ViewMode == FCDocumentViewMode.FriedmanCurve || ViewMode == FCDocumentViewMode.Normal)
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
					method_13(new DCGraphics(graphics), new RectangleF(0f, 0f, Right, Bottom), GEnum23.const_2);
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
				method_53(pageSettings);
				FCDocumentViewMode viewMode = ViewMode;
				ViewMode = FCDocumentViewMode.Page;
				PageIndex = pageIndex;
				method_13(new DCGraphics(graphics), new RectangleF(0f, 0f, Right, Bottom), GEnum23.const_2);
				ViewMode = viewMode;
			}
			return bitmap;
		}

		internal RectangleF method_53(PageSettings pageSettings_0)
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

		private RectangleF method_54(object object_1)
		{
			if (object_1 is FCHeaderLabelInfo)
			{
				FCHeaderLabelInfo fCHeaderLabelInfo = (FCHeaderLabelInfo)object_1;
				return new RectangleF(fCHeaderLabelInfo.Left, fCHeaderLabelInfo.Top, fCHeaderLabelInfo.Width, fCHeaderLabelInfo.Height);
			}
			if (object_1 is FCTitleLineInfo)
			{
				FCTitleLineInfo fCTitleLineInfo = (FCTitleLineInfo)object_1;
				return fCTitleLineInfo.TitleBounds;
			}
			if (object_1 is FCYAxisInfo)
			{
				FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)object_1;
				return fCYAxisInfo.TitleBounds;
			}
			if (object_1 is FriedmanCurveDocument || object_1 is FriedmanCurveDocumentConfig)
			{
				if (ViewMode == FCDocumentViewMode.Page || ViewMode == FCDocumentViewMode.Normal)
				{
					return new RectangleF(Left, Top, Width, Height);
				}
				return new RectangleF(Left, Top, LeftHeaderWidth, Height);
			}
			if (object_1 is DCFriedmanCurveImage)
			{
				DCFriedmanCurveImage dCFriedmanCurveImage = (DCFriedmanCurveImage)object_1;
				return new RectangleF(Left + dCFriedmanCurveImage.Left, Top + dCFriedmanCurveImage.Top, dCFriedmanCurveImage.ImagePixelWidth, dCFriedmanCurveImage.ImagePixelHeight);
			}
			if (object_1 is DCFriedmanCurveLabel)
			{
				DCFriedmanCurveLabel dCFriedmanCurveLabel = (DCFriedmanCurveLabel)object_1;
				return new RectangleF(Left + dCFriedmanCurveLabel.Left, Top + dCFriedmanCurveLabel.Top, dCFriedmanCurveLabel.Width, dCFriedmanCurveLabel.Height);
			}
			if (object_1 is FriedmanCurveZoneInfo)
			{
				FriedmanCurveZoneInfo friedmanCurveZoneInfo = (FriedmanCurveZoneInfo)object_1;
				return new RectangleF(friedmanCurveZoneInfo.Left, friedmanCurveZoneInfo.Top, friedmanCurveZoneInfo.Width, friedmanCurveZoneInfo.Height);
			}
			return RectangleF.Empty;
		}

		internal object method_55(float float_8, float float_9)
		{
			if (ViewMode == FCDocumentViewMode.Page && Config.Labels != null)
			{
				foreach (DCFriedmanCurveLabel label in Config.Labels)
				{
					RectangleF rectangleF = method_54(label);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return label;
					}
				}
			}
			if (Config.Images != null)
			{
				foreach (DCFriedmanCurveImage image in Config.Images)
				{
					RectangleF rectangleF = method_54(image);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return image;
					}
				}
			}
			if (Config.HeaderLabels != null)
			{
				foreach (FCHeaderLabelInfo headerLabel in Config.HeaderLabels)
				{
					RectangleF rectangleF = method_54(headerLabel);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return headerLabel;
					}
				}
			}
			if (Config.HeaderLines != null)
			{
				foreach (FCTitleLineInfo headerLine in Config.HeaderLines)
				{
					RectangleF rectangleF = method_54(headerLine);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return headerLine;
					}
				}
			}
			if (Config.YAxisInfos != null)
			{
				foreach (FCYAxisInfo yAxisInfo in Config.YAxisInfos)
				{
					RectangleF rectangleF = method_54(yAxisInfo);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return yAxisInfo;
					}
				}
			}
			if (Config.FooterLines != null)
			{
				foreach (FCTitleLineInfo footerLine in Config.FooterLines)
				{
					RectangleF rectangleF = method_54(footerLine);
					if (!rectangleF.IsEmpty && rectangleF.Contains(float_8, float_9))
					{
						return footerLine;
					}
				}
			}
			if (Config.Zones != null)
			{
				FriedmanCurveZoneInfoList zones = Config.Zones;
				int num = zones.Count - 1;
				while (num >= 0)
				{
					FriedmanCurveZoneInfo friedmanCurveZoneInfo = zones[num];
					RectangleF rectangleF = new RectangleF(friedmanCurveZoneInfo.Left, friedmanCurveZoneInfo.Top, friedmanCurveZoneInfo.Width, friedmanCurveZoneInfo.Height);
					if (rectangleF.IsEmpty || !rectangleF.Contains(float_8, float_9))
					{
						num--;
						continue;
					}
					return friedmanCurveZoneInfo;
				}
			}
			return null;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public FriedmanCurveDocument Clone()
		{
			FriedmanCurveDocument friedmanCurveDocument = (FriedmanCurveDocument)MemberwiseClone();
			if (friedmanCurveDocumentConfig_0 != null)
			{
				friedmanCurveDocument.friedmanCurveDocumentConfig_0 = friedmanCurveDocumentConfig_0.Clone();
			}
			if (fcdocumentDataList_0 != null)
			{
				friedmanCurveDocument.fcdocumentDataList_0 = fcdocumentDataList_0.Clone();
			}
			if (dcfriedmanCurveParameterList_0 != null)
			{
				friedmanCurveDocument.dcfriedmanCurveParameterList_0 = dcfriedmanCurveParameterList_0.Clone();
			}
			return friedmanCurveDocument;
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
	}
}
