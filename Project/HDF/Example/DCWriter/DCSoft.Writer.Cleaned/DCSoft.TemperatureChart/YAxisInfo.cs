using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       Y坐标轴信息
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DCDescriptionResourceSource("DCSoft.TemperatureChart.DCTimeLineDescriptionResource")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IYAxisInfo))]
	[DCPublishAPI]
	[DocumentComment]
	[Guid("31F1D605-6845-4EC1-948F-54BA07C8FFF2")]
	[ClassInterface(ClassInterfaceType.None)]
	public class YAxisInfo : IYAxisInfo
	{
		private float float_0 = 0f;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private string string_0 = null;

		private float float_1 = -10000f;

		private float float_2 = -10000f;

		[NonSerialized]
		private float float_3 = 0f;

		[NonSerialized]
		private float float_4 = 0f;

		private bool bool_2 = true;

		private DateTimePrecisionMode dateTimePrecisionMode_0 = DateTimePrecisionMode.Minute;

		private int int_0 = 2;

		private bool bool_3 = true;

		private XFontValue xfontValue_0 = null;

		private XFontValue xfontValue_1 = null;

		private int int_1 = 1;

		private Color color_0 = Color.Blue;

		private Color color_1 = Color.Red;

		private float float_5 = 20f;

		private float float_6 = 0f;

		private ValuePointDataSourceInfo valuePointDataSourceInfo_0 = null;

		private bool bool_4 = false;

		private bool bool_5 = true;

		private bool bool_6 = true;

		private bool bool_7 = true;

		private bool bool_8 = true;

		private bool bool_9 = false;

		private string string_1 = null;

		private YAxisInfoStyle yaxisInfoStyle_0 = YAxisInfoStyle.Value;

		private string string_2 = null;

		private string string_3 = null;

		private YAxisInfo yaxisInfo_0 = null;

		private bool bool_10 = true;

		private bool bool_11 = false;

		private string string_4 = null;

		private bool bool_12 = true;

		internal bool bool_13 = true;

		private string string_5 = null;

		private float float_7 = 0f;

		private float float_8 = 0f;

		private float float_9 = 0f;

		private float float_10 = 0f;

		private int int_2 = 8;

		private string string_6 = null;

		private int int_3 = 0;

		private float float_11 = -10000f;

		private float float_12 = 1f;

		private bool bool_14 = true;

		private Color color_2 = Color.Transparent;

		private Color color_3 = Color.White;

		private Color color_4 = Color.Transparent;

		private float float_13 = -10000f;

		private float float_14 = -10000f;

		private float float_15 = 100f;

		private float float_16 = 0f;

		private bool bool_15 = true;

		private ValuePointSymbolStyle valuePointSymbolStyle_0 = ValuePointSymbolStyle.SolidCicle;

		private char char_0 = 'R';

		private string string_7 = null;

		private Color color_5 = Color.Transparent;

		private Color color_6 = Color.LightGray;

		private Color color_7 = Color.Black;

		private Color color_8 = Color.Red;

		private bool bool_16 = false;

		[NonSerialized]
		internal float float_17 = 0f;

		internal float float_18 = 0f;

		private string string_8 = null;

		private string string_9 = null;

		private string string_10 = null;

		private ValuePointSymbolStyle valuePointSymbolStyle_1 = ValuePointSymbolStyle.HollowCicle;

		private char char_1 = 'R';

		private string string_11 = null;

		[NonSerialized]
		internal PointF pointF_0 = new PointF(float.NaN, float.NaN);

		[NonSerialized]
		internal ValuePoint valuePoint_0 = null;

		private YAxisScaleInfoList yaxisScaleInfoList_0 = null;

		/// <summary>
		///       最大文本显示长度
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(0f)]
		public float MaxTextDisplayLength
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
		///       为内边距修正标题顶端位置和高度
		///       </summary>
		internal bool FixTopHeightForPadding
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
		///       并入到左边的标尺
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "MergeIntoLeft")]
		[DefaultValue(false)]
		[XmlAttribute]
		public bool MergeIntoLeft
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
		///       名称
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "Name")]
		[XmlAttribute]
		[DefaultValue(null)]
		[Editor(typeof(EditNameUITypeEditor), typeof(UITypeEditor))]
		public string Name
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       数据网格线顶端空白边距比率，取值范围从0.0到1.0之间，若属性值为空则采用DocumentConfig.DataGridTopPadding属性值。
		///       </summary>
		[DefaultValue(-10000f)]
		[DCDisplayName(typeof(YAxisInfo), "TopPadding")]
		public float TopPadding
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
		///       数据网格线底端空白边距比率，取值范围从0.0到1.0之间，若属性值为空则采用DocumentConfig.DataGridBottomPadding属性值。
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "BottomPadding")]
		[DefaultValue(-10000f)]
		public float BottomPadding
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

		internal float RuntimeTopPadding => float_3;

		internal float RuntimeBottomPadding => float_4;

		/// <summary>
		///       数据点超出正常范围时高亮度显示
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		[DCDisplayName(typeof(YAxisInfo), "HighlightOutofNormalRange")]
		public bool HighlightOutofNormalRange
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
		///       输入时间的精度
		///       </summary>
		[DefaultValue(DateTimePrecisionMode.Minute)]
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "InputTimePrecision")]
		public DateTimePrecisionMode InputTimePrecision
		{
			get
			{
				return dateTimePrecisionMode_0;
			}
			set
			{
				dateTimePrecisionMode_0 = value;
			}
		}

		/// <summary>
		///       数值精度,也就是保持小数点后面几位。
		///       </summary>
		[XmlAttribute]
		[DefaultValue(2)]
		[DCDisplayName(typeof(YAxisInfo), "ValuePrecision")]
		public int ValuePrecision
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
		///       允许数据线中断
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "AllowInterrupt")]
		[XmlAttribute]
		[DefaultValue(true)]
		public bool AllowInterrupt
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
		///       字体
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[Browsable(true)]
		[DCDisplayName(typeof(YAxisInfo), "Font")]
		public XFontValue Font
		{
			get
			{
				return xfontValue_0;
			}
			set
			{
				xfontValue_0 = value;
			}
		}

		/// <summary>
		///       字体
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(YAxisInfo), "ValueFont")]
		[XmlElement]
		[Browsable(true)]
		public XFontValue ValueFont
		{
			get
			{
				return xfontValue_1;
			}
			set
			{
				xfontValue_1 = value;
			}
		}

		/// <summary>
		///       线条宽度
		///       </summary>
		[DefaultValue(1)]
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "LineWidth")]
		public int LineWidth
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
		///       物理升温颜色
		///       </summary>
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Blue")]
		[XmlIgnore]
		public Color LanternValueColorForUp
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
		///       文本形式的物理升温颜色
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		[Browsable(false)]
		public string LanternValueColorForUpValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(LanternValueColorForUp, Color.Blue);
			}
			set
			{
				LanternValueColorForUp = XMLSerializeHelper.StringToColor(value, Color.Blue);
			}
		}

		/// <summary>
		///       物理降温颜色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Red")]
		[Browsable(true)]
		public Color LanternValueColorForDown
		{
			get
			{
				return color_1;
			}
			set
			{
				color_1 = value;
			}
		}

		/// <summary>
		///       文本形式的物理降温颜色
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlAttribute]
		public string LanternValueColorForDownValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(LanternValueColorForDown, Color.Red);
			}
			set
			{
				LanternValueColorForDown = XMLSerializeHelper.StringToColor(value, Color.Red);
			}
		}

		/// <summary>
		///       图例大小
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "SymbolSize")]
		[XmlAttribute]
		[DefaultValue(20f)]
		public float SymbolSize
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
		///       运行时使用的线条宽度
		///       </summary>
		internal int RuntimeLineWidth
		{
			get
			{
				if (Selected)
				{
					return (int)Math.Ceiling((double)LineWidth * 1.5);
				}
				return LineWidth;
			}
		}

		/// <summary>
		///       运行时使用的图例大小
		///       </summary>
		internal float RuntimeSymbolSize
		{
			get
			{
				if (Selected)
				{
					return (int)Math.Ceiling((double)SymbolSize * 1.5);
				}
				return SymbolSize;
			}
		}

		/// <summary>
		///       指定的标题宽度,小于等于0为无效设置，将自动计算标题宽度。采用GraphicUnit.Document为单位。
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "SpecifyTitleWidth")]
		[XmlAttribute]
		[DefaultValue(0f)]
		public float SpecifyTitleWidth
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
		///       数据源
		///       </summary>
		[Browsable(true)]
		[DefaultValue(null)]
		[XmlElement]
		[DCDisplayName(typeof(YAxisInfo), "DataSource")]
		public ValuePointDataSourceInfo DataSource
		{
			get
			{
				if (valuePointDataSourceInfo_0 == null)
				{
					valuePointDataSourceInfo_0 = new ValuePointDataSourceInfo();
				}
				return valuePointDataSourceInfo_0;
			}
			set
			{
				valuePointDataSourceInfo_0 = value;
			}
		}

		/// <summary>
		///       允许数值超出范围
		///       </summary>
		[DefaultValue(false)]
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "AllowOutofRange")]
		public bool AllowOutofRange
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
		///       文本分隔线是否显示
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "SeparatorLineVisible")]
		[XmlAttribute]
		[DefaultValue(true)]
		public bool SeparatorLineVisible
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
		///       鼠标点击来隐藏数据
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "ClickToHide")]
		[XmlAttribute]
		[DefaultValue(true)]
		public bool ClickToHide
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		/// <summary>
		///       对象是否可见
		///       </summary>
		[DefaultValue(true)]
		[DCDisplayName(typeof(YAxisInfo), "Visible")]
		[XmlAttribute]
		public bool Visible
		{
			get
			{
				return bool_7;
			}
			set
			{
				bool_7 = value;
			}
		}

		/// <summary>
		///       数值是否可见
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "ValueVisible")]
		[XmlAttribute]
		[DefaultValue(true)]
		public bool ValueVisible
		{
			get
			{
				return bool_8;
			}
			set
			{
				bool_8 = value;
			}
		}

		/// <summary>
		///       允许使用灯笼数据
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "EnableLanternValue")]
		[DefaultValue(false)]
		public bool EnableLanternValue
		{
			get
			{
				return bool_9;
			}
			set
			{
				bool_9 = value;
			}
		}

		/// <summary>
		///       灯笼数据名称
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "LanternValueTitle")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string LanternValueTitle
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       坐标轴样式
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "Style")]
		[XmlAttribute]
		[DefaultValue(YAxisInfoStyle.Value)]
		public YAxisInfoStyle Style
		{
			get
			{
				return yaxisInfoStyle_0;
			}
			set
			{
				yaxisInfoStyle_0 = value;
			}
		}

		/// <summary>
		///       空心覆盖目标名称
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "HollowCovertTargetName")]
		[DefaultValue(null)]
		[XmlAttribute]
		public string HollowCovertTargetName
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
		///       阴影数据线名称
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "ShadowName")]
		[DefaultValue(null)]
		public string ShadowName
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
				yaxisInfo_0 = null;
			}
		}

		/// <summary>
		///       引用数据线对象
		///       </summary>
		internal YAxisInfo ShadowInfo
		{
			get
			{
				return yaxisInfo_0;
			}
			set
			{
				yaxisInfo_0 = value;
			}
		}

		/// <summary>
		///       心率脉搏阴影区域是否显示
		///       </summary>
		[Browsable(true)]
		[DefaultValue(true)]
		public bool ShadowPointVisible
		{
			get
			{
				return bool_10;
			}
			set
			{
				bool_10 = value;
			}
		}

		/// <summary>
		///       控制脉搏和心率之间的数值连线是否显示
		///       </summary>
		[Browsable(true)]
		[DefaultValue(false)]
		public bool VerticalLine
		{
			get
			{
				return bool_11;
			}
			set
			{
				bool_11 = value;
			}
		}

		/// <summary>
		///       标题数值格式字符串
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		[DCDisplayName(typeof(YAxisInfo), "TitleValueDispalyFormat")]
		public string TitleValueDispalyFormat
		{
			get
			{
				return string_4;
			}
			set
			{
				string_4 = value;
			}
		}

		/// <summary>
		///       是否显示Y坐标刻度和标题
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "TitleVisible")]
		public bool TitleVisible
		{
			get
			{
				return bool_12;
			}
			set
			{
				bool_12 = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[Editor(typeof(EditTitleUITypeEditor), typeof(UITypeEditor))]
		[DCDisplayName(typeof(YAxisInfo), "Title")]
		public string Title
		{
			get
			{
				return string_5;
			}
			set
			{
				string_5 = value;
			}
		}

		/// <summary>
		///       刻度尺区域
		///       </summary>
		internal RectangleF TitleBounds => new RectangleF(TitleLeft, TitleTop, TitleWidth, TitleHeight);

		/// <summary>
		///       标题区域左端位置
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public float TitleLeft
		{
			get
			{
				return float_7;
			}
			set
			{
				if (float_7 != value)
				{
					float_7 = value;
				}
			}
		}

		/// <summary>
		///       标题区域顶端位置
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float TitleTop
		{
			get
			{
				return float_8;
			}
			set
			{
				float_8 = value;
			}
		}

		/// <summary>
		///       标题区域的低端位置
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float TitleBottom => float_8 + float_10;

		/// <summary>
		///       标题区域宽度
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public float TitleWidth
		{
			get
			{
				return float_9;
			}
			set
			{
				if (value != float_9)
				{
					float_9 = value;
				}
			}
		}

		/// <summary>
		///       标题区域宽度
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float TitleHeight
		{
			get
			{
				return float_10;
			}
			set
			{
				float_10 = value;
			}
		}

		/// <summary>
		///       Y轴分割区域数量
		///       </summary>
		[DefaultValue(8)]
		[DCDisplayName(typeof(YAxisInfo), "YSplitNum")]
		[XmlAttribute]
		public int YSplitNum
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
		///       数值格式化字符串
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "ValueFormatString")]
		[DefaultValue(null)]
		[XmlAttribute]
		public string ValueFormatString
		{
			get
			{
				return string_6;
			}
			set
			{
				string_6 = value;
			}
		}

		/// <summary>
		///       超出取值范围标记
		///       </summary>
		[Browsable(false)]
		internal int OutofRangeFlag => int_3;

		/// <summary>
		///       水平红线对应的数值
		///       </summary>
		[DefaultValue(-10000f)]
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "RedLineValue")]
		public float RedLineValue
		{
			get
			{
				return float_11;
			}
			set
			{
				float_11 = value;
			}
		}

		/// <summary>
		///       水平紅线宽度
		///       </summary>
		[XmlAttribute]
		[DefaultValue(1f)]
		[DCDisplayName(typeof(YAxisInfo), "RedLineWidth")]
		public float RedLineWidth
		{
			get
			{
				return float_12;
			}
			set
			{
				float_12 = value;
			}
		}

		/// <summary>
		///       打印时是否显示红线
		///       </summary>
		[DefaultValue(true)]
		public bool RedLinePrintVisible
		{
			get
			{
				return bool_14;
			}
			set
			{
				bool_14 = value;
			}
		}

		/// <summary>
		///       正常数值区域背景色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
		[DCDisplayName(typeof(YAxisInfo), "NormalRangeBackColor")]
		public Color NormalRangeBackColor
		{
			get
			{
				return color_2;
			}
			set
			{
				color_2 = value;
			}
		}

		/// <summary>
		///       文本形式的NormalRangeBackColor属性值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlAttribute]
		public string NormalRangeBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(NormalRangeBackColor, Color.Transparent);
			}
			set
			{
				NormalRangeBackColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       数值文本背景色
		///       </summary>
		[DefaultValue(typeof(Color), "White")]
		[DCDisplayName(typeof(YAxisInfo), "ValueTextBackColor")]
		[XmlIgnore]
		public Color ValueTextBackColor
		{
			get
			{
				return color_3;
			}
			set
			{
				color_3 = value;
			}
		}

		/// <summary>
		///       文本形式的ValueTextBackColor属性值
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		[Browsable(false)]
		public string ValueTextBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(ValueTextBackColor, Color.White);
			}
			set
			{
				ValueTextBackColor = XMLSerializeHelper.StringToColor(value, Color.White);
			}
		}

		/// <summary>
		///       超出正常区域背景色
		///       </summary>
		[XmlIgnore]
		[DCDisplayName(typeof(YAxisInfo), "OutofNormalRangeBackColor")]
		[DefaultValue(typeof(Color), "Transparent")]
		public Color OutofNormalRangeBackColor
		{
			get
			{
				return color_4;
			}
			set
			{
				color_4 = value;
			}
		}

		/// <summary>
		///       文本形式的OutofNormalRangeBackColor属性值
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlAttribute]
		public string OutofNormalRangeBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(OutofNormalRangeBackColor, Color.Transparent);
			}
			set
			{
				OutofNormalRangeBackColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       数值正常范围的最大值
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "NormalMaxValue")]
		[XmlAttribute]
		[DefaultValue(-10000f)]
		public float NormalMaxValue
		{
			get
			{
				return float_13;
			}
			set
			{
				float_13 = value;
			}
		}

		/// <summary>
		///       数值正常范围的最小值
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "NormalMinValue")]
		[DefaultValue(-10000f)]
		[XmlAttribute]
		public float NormalMinValue
		{
			get
			{
				return float_14;
			}
			set
			{
				float_14 = value;
			}
		}

		/// <summary>
		///       最大值
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "MaxValue")]
		[XmlAttribute]
		[DefaultValue(100f)]
		public float MaxValue
		{
			get
			{
				return float_15;
			}
			set
			{
				float_15 = value;
			}
		}

		/// <summary>
		///       最小值
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "MinValue")]
		[XmlAttribute]
		[DefaultValue(0f)]
		public float MinValue
		{
			get
			{
				return float_16;
			}
			set
			{
				float_16 = value;
			}
		}

		/// <summary>
		///       在标尺中显示图例
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "ShowLegendInRule")]
		[DefaultValue(true)]
		public bool ShowLegendInRule
		{
			get
			{
				return bool_15;
			}
			set
			{
				bool_15 = value;
			}
		}

		/// <summary>
		///       数据点符号类型
		///       </summary>
		[XmlAttribute]
		[DefaultValue(ValuePointSymbolStyle.SolidCicle)]
		[DCDisplayName(typeof(YAxisInfo), "SymbolStyle")]
		public ValuePointSymbolStyle SymbolStyle
		{
			get
			{
				return valuePointSymbolStyle_0;
			}
			set
			{
				valuePointSymbolStyle_0 = value;
			}
		}

		/// <summary>
		///       获取或设置当SpecifySymbolStyle枚举被设置成字符或套圈字符时，此处将要使用的字符变量
		///       </summary>
		[DefaultValue('P')]
		[DCDisplayName(typeof(YAxisInfo), "CharacterForCharSymbolStyle")]
		[XmlAttribute]
		public char CharacterForCharSymbolStyle
		{
			get
			{
				return char_0;
			}
			set
			{
				char_0 = value;
			}
		}

		/// <summary>
		///       底端标题
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		[DCDisplayName(typeof(YAxisInfo), "BottomTitle")]
		public string BottomTitle
		{
			get
			{
				return string_7;
			}
			set
			{
				string_7 = value;
			}
		}

		/// <summary>
		///       标题背景颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Transparent")]
		[XmlIgnore]
		[DCDisplayName(typeof(YAxisInfo), "TitleBackColor")]
		public Color TitleBackColor
		{
			get
			{
				return color_5;
			}
			set
			{
				color_5 = value;
			}
		}

		/// <summary>
		///       文本形式的标题背景颜色值
		///       </summary>
		[XmlAttribute]
		[Browsable(false)]
		[DefaultValue(null)]
		public string TitleBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(TitleBackColor, Color.Transparent);
			}
			set
			{
				TitleBackColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       数据隐藏时的标题背景色
		///       </summary>
		[XmlIgnore]
		[DefaultValue(typeof(Color), "LightGray")]
		[DCDisplayName(typeof(YAxisInfo), "HiddenValueTitleBackColor")]
		public Color HiddenValueTitleBackColor
		{
			get
			{
				return color_6;
			}
			set
			{
				color_6 = value;
			}
		}

		/// <summary>
		///       文本形式的标题文本颜色值
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		[Browsable(false)]
		public string HiddenValueTitleBackColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(HiddenValueTitleBackColor, Color.LightGray);
			}
			set
			{
				HiddenValueTitleBackColor = XMLSerializeHelper.StringToColor(value, Color.LightGray);
			}
		}

		/// <summary>
		///       标题文本颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		[DCDisplayName(typeof(YAxisInfo), "TitleColor")]
		[XmlIgnore]
		public Color TitleColor
		{
			get
			{
				return color_7;
			}
			set
			{
				color_7 = value;
			}
		}

		/// <summary>
		///       文本形式的标题文本颜色值
		///       </summary>
		[Browsable(false)]
		[XmlAttribute]
		[DefaultValue(null)]
		public string TitleColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(TitleColor, Color.Black);
			}
			set
			{
				TitleColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       数据点符号颜色
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "SymbolColor")]
		[XmlIgnore]
		public Color SymbolColor
		{
			get
			{
				return color_8;
			}
			set
			{
				color_8 = value;
			}
		}

		/// <summary>
		///       被选择状态
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DefaultValue(false)]
		public bool Selected
		{
			get
			{
				return bool_16;
			}
			set
			{
				bool_16 = value;
			}
		}

		/// <summary>
		///       文本形式的颜色值
		///       </summary>
		[DefaultValue("Red")]
		[Browsable(false)]
		[XmlAttribute]
		public string SymbolColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(SymbolColor, Color.Red);
			}
			set
			{
				SymbolColor = XMLSerializeHelper.StringToColor(value, Color.Red);
			}
		}

		/// <summary>
		///       数据源的名称
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "DataSourceName")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string DataSourceName
		{
			get
			{
				return string_8;
			}
			set
			{
				string_8 = value;
			}
		}

		/// <summary>
		///       数据字段的名称
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "ValueFieldName")]
		[DefaultValue(null)]
		public string ValueFieldName
		{
			get
			{
				return string_9;
			}
			set
			{
				string_9 = value;
			}
		}

		/// <summary>
		///       灯笼数据字段名称
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		[DCDisplayName(typeof(YAxisInfo), "LanternValueFieldName")]
		public string LanternValueFieldName
		{
			get
			{
				return string_10;
			}
			set
			{
				string_10 = value;
			}
		}

		/// <summary>
		///       指定的数据点的灯笼数据的图例样式
		///       </summary>
		[DCDisplayName(typeof(YAxisInfo), "LanternSymbolStyle")]
		[XmlAttribute]
		[DefaultValue(ValuePointSymbolStyle.HollowCicle)]
		public ValuePointSymbolStyle SpecifyLanternSymbolStyle
		{
			get
			{
				return valuePointSymbolStyle_1;
			}
			set
			{
				valuePointSymbolStyle_1 = value;
			}
		}

		/// <summary>
		///       获取或设置当灯笼数据图例枚举被设置成字符或套圈字符时，此处将要使用的字符变量
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(YAxisInfo), "LanternSymbolChar")]
		[DefaultValue('R')]
		public char CharacterForLanternSymbolStyle
		{
			get
			{
				return char_1;
			}
			set
			{
				char_1 = value;
			}
		}

		/// <summary>
		///       表示数据时间的字段名
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(YAxisInfo), "TimeFieldName")]
		[XmlAttribute]
		public string TimeFieldName
		{
			get
			{
				return string_11;
			}
			set
			{
				string_11 = value;
			}
		}

		/// <summary>
		///       自定义的刻度信息列表
		///       </summary>
		[XmlArrayItem("Scale", typeof(YAxisScaleInfo))]
		[DCDisplayName(typeof(YAxisInfo), "Scales")]
		[Browsable(true)]
		[DefaultValue(null)]
		public YAxisScaleInfoList Scales
		{
			get
			{
				if (yaxisScaleInfoList_0 == null)
				{
					yaxisScaleInfoList_0 = new YAxisScaleInfoList();
				}
				return yaxisScaleInfoList_0;
			}
			set
			{
				yaxisScaleInfoList_0 = value;
			}
		}

		/// <summary>
		///       存在有效的自定义的刻度信息
		///       </summary>
		internal bool HasScales => yaxisScaleInfoList_0 != null && yaxisScaleInfoList_0.Count > 2;

		internal void method_0(TemperatureDocument temperatureDocument_0)
		{
			float_3 = 0f;
			if (TopPadding >= 0f)
			{
				float_3 = TopPadding;
			}
			else if (temperatureDocument_0.Config.DataGridTopPadding >= 0f)
			{
				float_3 = temperatureDocument_0.Config.DataGridTopPadding;
			}
			if (float_3 >= 1f)
			{
				float_3 = 0f;
			}
			float_4 = 0f;
			if (BottomPadding >= 0f)
			{
				float_4 = BottomPadding;
			}
			else if (temperatureDocument_0.Config.DataGridBottomPadding >= 0f)
			{
				float_4 = temperatureDocument_0.Config.DataGridBottomPadding;
			}
			if (float_4 >= 1f)
			{
				float_4 = 0f;
			}
		}

		internal float method_1(float float_19)
		{
			if (ValuePrecision < 0)
			{
				return float_19;
			}
			if (TemperatureDocument.smethod_3(float_19))
			{
				return float_19;
			}
			return (float)Math.Round(float_19, ValuePrecision);
		}

		internal bool method_2(float float_19)
		{
			if (TemperatureDocument.smethod_3(float_19))
			{
				return true;
			}
			if (float_19 > MaxValue || float_19 < MinValue)
			{
				if (AllowOutofRange)
				{
					return true;
				}
				return false;
			}
			return true;
		}

		internal float method_3(TemperatureDocument temperatureDocument_0, RectangleF rectangleF_0, float float_19)
		{
			float num = method_5(float_19);
			if (TemperatureDocument.smethod_3(num))
			{
				return float.NaN;
			}
			return rectangleF_0.Top + rectangleF_0.Height * RuntimeTopPadding + rectangleF_0.Height * (1f - RuntimeTopPadding - RuntimeBottomPadding) * (1f - num);
		}

		internal float method_4(TemperatureDocument temperatureDocument_0, RectangleF rectangleF_0, float float_19)
		{
			float num = rectangleF_0.Top + rectangleF_0.Height * (1f - RuntimeBottomPadding);
			float num2 = rectangleF_0.Top + rectangleF_0.Height * RuntimeTopPadding;
			float num3 = 1f - (float_19 - num2) / (num - num2);
			if (TemperatureDocument.smethod_3(num3))
			{
				return float.NaN;
			}
			if (HasScales)
			{
				int num4 = 1;
				YAxisScaleInfo yAxisScaleInfo;
				while (true)
				{
					if (num4 < Scales.Count)
					{
						yAxisScaleInfo = Scales[num4];
						if (num3 >= yAxisScaleInfo.ScaleRate)
						{
							break;
						}
						num4++;
						continue;
					}
					return 0f;
				}
				YAxisScaleInfo yAxisScaleInfo2 = Scales[num4 - 1];
				float num5 = 0f;
				num5 = ((!(num3 > yAxisScaleInfo2.ScaleRate) && yAxisScaleInfo2.ScaleRate != yAxisScaleInfo.ScaleRate) ? (yAxisScaleInfo.Value + (yAxisScaleInfo2.Value - yAxisScaleInfo.Value) * ((num3 - yAxisScaleInfo.ScaleRate) / (yAxisScaleInfo2.ScaleRate - yAxisScaleInfo.ScaleRate))) : yAxisScaleInfo2.Value);
				return method_1(num5);
			}
			if (num3 >= 1f)
			{
				return MaxValue;
			}
			if (num3 <= 0f)
			{
				return MinValue;
			}
			return method_1(MinValue + (MaxValue - MinValue) * num3);
		}

		private float method_5(float float_19)
		{
			int_3 = 0;
			if (TemperatureDocument.smethod_3(float_19))
			{
				return float.NaN;
			}
			if (HasScales)
			{
				int num = 1;
				YAxisScaleInfo yAxisScaleInfo;
				while (true)
				{
					if (num < Scales.Count)
					{
						yAxisScaleInfo = Scales[num];
						if (float_19 >= yAxisScaleInfo.Value)
						{
							break;
						}
						num++;
						continue;
					}
					return 0f;
				}
				YAxisScaleInfo yAxisScaleInfo2 = Scales[num - 1];
				float num2 = 0f;
				return (!(float_19 > yAxisScaleInfo2.Value)) ? (yAxisScaleInfo.ScaleRate + (yAxisScaleInfo2.ScaleRate - yAxisScaleInfo.ScaleRate) * ((float_19 - yAxisScaleInfo.Value) / (yAxisScaleInfo2.Value - yAxisScaleInfo.Value))) : yAxisScaleInfo2.ScaleRate;
			}
			if (float_19 > MaxValue)
			{
				int_3 = 1;
				if (AllowOutofRange)
				{
					return 1f;
				}
				return float.NaN;
			}
			if (float_19 < MinValue)
			{
				int_3 = -1;
				if (AllowOutofRange)
				{
					return 0f;
				}
				return float.NaN;
			}
			return (float_19 - MinValue) / (MaxValue - MinValue);
		}

		/// <summary>
		///       返回表示对象数值的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			return Name + " " + Title + " " + GetType().Name;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public YAxisInfo Clone()
		{
			YAxisInfo yAxisInfo = (YAxisInfo)MemberwiseClone();
			if (yaxisScaleInfoList_0 != null)
			{
				yAxisInfo.yaxisScaleInfoList_0 = new YAxisScaleInfoList();
				foreach (YAxisScaleInfo item in yaxisScaleInfoList_0)
				{
					yAxisInfo.yaxisScaleInfoList_0.Add(item);
				}
			}
			return yAxisInfo;
		}
	}
}
