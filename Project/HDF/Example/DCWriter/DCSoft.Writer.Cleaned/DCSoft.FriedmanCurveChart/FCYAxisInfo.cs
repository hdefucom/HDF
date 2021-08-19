using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       Y坐标轴信息
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[DCDescriptionResourceSource("DCSoft.FriedmanCurveChart.DCFriedmanCurveDescriptionResource")]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("6BC33CCB-B16E-40F5-AEE3-91733A4635D6")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IYAxisInfo))]
	[DocumentComment]
	[DCPublishAPI]
	public class FCYAxisInfo : IYAxisInfo
	{
		private float float_0 = 0f;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private bool bool_2 = true;

		private string string_0 = null;

		private float float_1 = -10000f;

		private float float_2 = -10000f;

		[NonSerialized]
		private float float_3 = 0f;

		[NonSerialized]
		private float float_4 = 0f;

		private bool bool_3 = true;

		private FCDateTimePrecisionMode fcdateTimePrecisionMode_0 = FCDateTimePrecisionMode.Minute;

		private int int_0 = 2;

		private bool bool_4 = true;

		private XFontValue xfontValue_0 = null;

		private XFontValue xfontValue_1 = null;

		private int int_1 = 1;

		private Color color_0 = Color.Blue;

		private Color color_1 = Color.Red;

		private float float_5 = 20f;

		private float float_6 = 0f;

		private FCValuePointDataSourceInfo fcvaluePointDataSourceInfo_0 = null;

		private bool bool_5 = false;

		private bool bool_6 = true;

		private bool bool_7 = true;

		private bool bool_8 = true;

		private bool bool_9 = true;

		private bool bool_10 = false;

		private string string_1 = null;

		private FCYAxisInfoStyle fcyaxisInfoStyle_0 = FCYAxisInfoStyle.Value;

		private string string_2 = null;

		private string string_3 = null;

		private FCYAxisInfo fcyaxisInfo_0 = null;

		private bool bool_11 = true;

		private bool bool_12 = false;

		private string string_4 = null;

		private bool bool_13 = true;

		internal bool bool_14 = true;

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

		private bool bool_15 = true;

		private Color color_2 = Color.Transparent;

		private Color color_3 = Color.White;

		private Color color_4 = Color.Transparent;

		private float float_13 = -10000f;

		private float float_14 = -10000f;

		private float float_15 = -10000f;

		private bool bool_16 = true;

		private float float_16 = 100f;

		private float float_17 = 0f;

		private bool bool_17 = true;

		private FCValuePointSymbolStyle fcvaluePointSymbolStyle_0 = FCValuePointSymbolStyle.SolidCicle;

		private string string_7 = null;

		private Color color_5 = Color.Transparent;

		private Color color_6 = Color.LightGray;

		private Color color_7 = Color.Black;

		private Color color_8 = Color.Red;

		private bool bool_18 = false;

		[NonSerialized]
		internal float float_18 = 0f;

		internal float float_19 = 0f;

		private string string_8 = null;

		private string string_9 = null;

		private string string_10 = null;

		private string string_11 = null;

		[NonSerialized]
		internal PointF pointF_0 = new PointF(float.NaN, float.NaN);

		[NonSerialized]
		internal FCValuePoint fcvaluePoint_0 = null;

		private FCYAxisScaleInfoList fcyaxisScaleInfoList_0 = null;

		/// <summary>
		///       底端间隔区域
		///       </summary>
		[DefaultValue(0)]
		[DCDisplayName(typeof(FCHeaderLabelInfo), "BottomSpacing")]
		[Browsable(true)]
		[XmlAttribute]
		public float BottomSpacing
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
		[XmlAttribute]
		[DefaultValue(false)]
		[DCDisplayName(typeof(FCYAxisInfo), "MergeIntoLeft")]
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
		///       是否绘制数据轴内的内容
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "IsDrawContent")]
		[DefaultValue(false)]
		public bool IsDrawContent
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
		///       名称
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "Name")]
		[Editor(typeof(FCEditNameUITypeEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
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
		[DCDisplayName(typeof(FCYAxisInfo), "TopPadding")]
		[DefaultValue(-10000f)]
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
		[DefaultValue(-10000f)]
		[DCDisplayName(typeof(FCYAxisInfo), "BottomPadding")]
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
		[DCDisplayName(typeof(FCYAxisInfo), "HighlightOutofNormalRange")]
		[XmlAttribute]
		[DefaultValue(true)]
		public bool HighlightOutofNormalRange
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
		///       输入时间的精度
		///       </summary>
		[DefaultValue(FCDateTimePrecisionMode.Minute)]
		[DCDisplayName(typeof(FCYAxisInfo), "InputTimePrecision")]
		[XmlAttribute]
		public FCDateTimePrecisionMode InputTimePrecision
		{
			get
			{
				return fcdateTimePrecisionMode_0;
			}
			set
			{
				fcdateTimePrecisionMode_0 = value;
			}
		}

		/// <summary>
		///       数值精度,也就是保持小数点后面几位。
		///       </summary>
		[DefaultValue(2)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "ValuePrecision")]
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
		[DefaultValue(true)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "AllowInterrupt")]
		public bool AllowInterrupt
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
		///       字体
		///       </summary>
		[XmlElement]
		[DCDisplayName(typeof(FCYAxisInfo), "Font")]
		[DefaultValue(null)]
		[Browsable(true)]
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
		[XmlElement]
		[DCDisplayName(typeof(FCYAxisInfo), "ValueFont")]
		[Browsable(true)]
		[DefaultValue(null)]
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
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "LineWidth")]
		[DefaultValue(1)]
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
		[DefaultValue(typeof(Color), "Blue")]
		[Browsable(false)]
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
		[Browsable(false)]
		[XmlAttribute]
		[DefaultValue(null)]
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
		[DefaultValue(typeof(Color), "Red")]
		[XmlIgnore]
		[Browsable(false)]
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
		[Browsable(false)]
		[DefaultValue(null)]
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
		[DCDisplayName(typeof(FCYAxisInfo), "SymbolSize")]
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
		internal int RunFriedmanCurveWidth
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
		[DefaultValue(0f)]
		[DCDisplayName(typeof(FCYAxisInfo), "SpecifyTitleWidth")]
		[XmlAttribute]
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
		[DefaultValue(null)]
		[XmlElement]
		[DCDisplayName(typeof(FCYAxisInfo), "DataSource")]
		[Browsable(true)]
		public FCValuePointDataSourceInfo DataSource
		{
			get
			{
				if (fcvaluePointDataSourceInfo_0 == null)
				{
					fcvaluePointDataSourceInfo_0 = new FCValuePointDataSourceInfo();
				}
				return fcvaluePointDataSourceInfo_0;
			}
			set
			{
				fcvaluePointDataSourceInfo_0 = value;
			}
		}

		/// <summary>
		///       允许数值超出范围
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "AllowOutofRange")]
		[DefaultValue(false)]
		public bool AllowOutofRange
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
		///       文本分隔线是否显示
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "SeparatorLineVisible")]
		[DefaultValue(true)]
		public bool SeparatorLineVisible
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
		///       鼠标点击来隐藏数据
		///       </summary>
		[DCDisplayName(typeof(FCYAxisInfo), "ClickToHide")]
		[DefaultValue(true)]
		[XmlAttribute]
		public bool ClickToHide
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
		///       对象是否可见
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		[DCDisplayName(typeof(FCYAxisInfo), "Visible")]
		public bool Visible
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
		///       数值是否可见
		///       </summary>
		[DCDisplayName(typeof(FCYAxisInfo), "ValueVisible")]
		[DefaultValue(true)]
		[XmlAttribute]
		public bool ValueVisible
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
		///       允许使用灯笼数据
		///       </summary>
		[Browsable(false)]
		[DCDisplayName(typeof(FCYAxisInfo), "EnableLanternValue")]
		[XmlIgnore]
		[DefaultValue(false)]
		public bool EnableLanternValue
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
		///       灯笼数据名称
		///       </summary>
		[Browsable(false)]
		[DCDisplayName(typeof(FCYAxisInfo), "LanternValueTitle")]
		[XmlIgnore]
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
		[DCDisplayName(typeof(FCYAxisInfo), "Style")]
		[XmlAttribute]
		[DefaultValue(FCYAxisInfoStyle.Value)]
		public FCYAxisInfoStyle Style
		{
			get
			{
				return fcyaxisInfoStyle_0;
			}
			set
			{
				fcyaxisInfoStyle_0 = value;
			}
		}

		/// <summary>
		///       空心覆盖目标名称
		///       </summary>
		[XmlIgnore]
		[DCDisplayName(typeof(FCYAxisInfo), "HollowCovertTargetName")]
		[Browsable(false)]
		[DefaultValue(null)]
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
		[DCDisplayName(typeof(FCYAxisInfo), "ShadowName")]
		[XmlIgnore]
		[Browsable(false)]
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
				fcyaxisInfo_0 = null;
			}
		}

		/// <summary>
		///       引用数据线对象
		///       </summary>
		internal FCYAxisInfo ShadowInfo
		{
			get
			{
				return fcyaxisInfo_0;
			}
			set
			{
				fcyaxisInfo_0 = value;
			}
		}

		/// <summary>
		///       心率脉搏阴影区域是否显示
		///       </summary>
		[Browsable(false)]
		[DefaultValue(false)]
		public bool ShadowPointVisible
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
		///       控制脉搏和心率之间的数值连线是否显示
		///       </summary>
		[DefaultValue(false)]
		[Browsable(false)]
		public bool VerticalLine
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
		///       标题数值格式字符串
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(FCYAxisInfo), "TitleValueDispalyFormat")]
		[XmlAttribute]
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
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "TitleVisible")]
		[DefaultValue(true)]
		public bool TitleVisible
		{
			get
			{
				return bool_13;
			}
			set
			{
				bool_13 = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "Title")]
		[Editor(typeof(FCEditTitleUITypeEditor), typeof(UITypeEditor))]
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
		[XmlIgnore]
		[Browsable(false)]
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
		[Browsable(false)]
		[XmlIgnore]
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
		[Browsable(false)]
		[XmlIgnore]
		public float TitleBottom => float_8 + float_10;

		/// <summary>
		///       标题区域宽度
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
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
		[XmlAttribute]
		[DefaultValue(8)]
		[DCDisplayName(typeof(FCYAxisInfo), "YSplitNum")]
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
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "ValueFormatString")]
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
		[Browsable(false)]
		[XmlIgnore]
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
		[DefaultValue(1f)]
		[Browsable(false)]
		[XmlIgnore]
		[DCDisplayName(typeof(FCYAxisInfo), "RedLineWidth")]
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
		[Browsable(false)]
		[DefaultValue(false)]
		[XmlIgnore]
		public bool RedLinePrintVisible
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
		///       正常数值区域背景色
		///       </summary>
		[DefaultValue(typeof(Color), "Transparent")]
		[DCDisplayName(typeof(FCYAxisInfo), "NormalRangeBackColor")]
		[XmlIgnore]
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
		[XmlAttribute]
		[DefaultValue(null)]
		[Browsable(false)]
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
		[DCDisplayName(typeof(FCYAxisInfo), "ValueTextBackColor")]
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
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlAttribute]
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
		[DefaultValue(typeof(Color), "Transparent")]
		[DCDisplayName(typeof(FCYAxisInfo), "OutofNormalRangeBackColor")]
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
		[XmlAttribute]
		[DefaultValue(null)]
		[Browsable(false)]
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
		[DCDisplayName(typeof(FCYAxisInfo), "NormalMaxValue")]
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
		[DCDisplayName(typeof(FCYAxisInfo), "NormalMinValue")]
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
		///       右侧刻度值相对左边刻度偏移
		///       </summary>
		[DCDisplayName(typeof(FCYAxisInfo), "RightOffset")]
		[XmlAttribute]
		[DefaultValue(-10000f)]
		public float RightOffset
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
		///       打印时是否显示红线
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCDisplayName(typeof(FCYAxisInfo), "IsShowRightScale")]
		[DefaultValue(false)]
		public bool IsShowRightScale
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
		///       最大值
		///       </summary>
		[DCDisplayName(typeof(FCYAxisInfo), "MaxValue")]
		[DefaultValue(100f)]
		[XmlAttribute]
		public float MaxValue
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
		///       最小值
		///       </summary>
		[DefaultValue(0f)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "MinValue")]
		public float MinValue
		{
			get
			{
				return float_17;
			}
			set
			{
				float_17 = value;
			}
		}

		/// <summary>
		///       在标尺中显示图例
		///       </summary>
		[DCDisplayName(typeof(FCYAxisInfo), "ShowLegendInRule")]
		[XmlAttribute]
		[DefaultValue(true)]
		public bool ShowLegendInRule
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
		///       数据点符号类型
		///       </summary>
		[DefaultValue(FCValuePointSymbolStyle.SolidCicle)]
		[DCDisplayName(typeof(FCYAxisInfo), "SymbolStyle")]
		[XmlAttribute]
		public FCValuePointSymbolStyle SymbolStyle
		{
			get
			{
				return fcvaluePointSymbolStyle_0;
			}
			set
			{
				fcvaluePointSymbolStyle_0 = value;
			}
		}

		/// <summary>
		///       底端标题
		///       </summary>
		[DCDisplayName(typeof(FCYAxisInfo), "BottomTitle")]
		[XmlAttribute]
		[DefaultValue(null)]
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
		[DCDisplayName(typeof(FCYAxisInfo), "TitleBackColor")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
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
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlAttribute]
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
		[DefaultValue(typeof(Color), "LightGray")]
		[DCDisplayName(typeof(FCYAxisInfo), "HiddenValueTitleBackColor")]
		[XmlIgnore]
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
		[Browsable(false)]
		[XmlAttribute]
		[DefaultValue(null)]
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
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
		[DCDisplayName(typeof(FCYAxisInfo), "TitleColor")]
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
		[XmlIgnore]
		[DCDisplayName(typeof(FCYAxisInfo), "SymbolColor")]
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
		[Browsable(false)]
		[DefaultValue(false)]
		[XmlIgnore]
		public bool Selected
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
		///       文本形式的颜色值
		///       </summary>
		[Browsable(false)]
		[DefaultValue("Red")]
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
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCYAxisInfo), "DataSourceName")]
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
		[DCDisplayName(typeof(FCYAxisInfo), "ValueFieldName")]
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
		[DefaultValue(null)]
		[DCDisplayName(typeof(FCYAxisInfo), "LanternValueFieldName")]
		[Browsable(false)]
		[XmlIgnore]
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
		///       表示数据时间的字段名
		///       </summary>
		[DCDisplayName(typeof(FCYAxisInfo), "TimeFieldName")]
		[DefaultValue(null)]
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
		[DefaultValue(null)]
		[Browsable(true)]
		[DCDisplayName(typeof(FCYAxisInfo), "Scales")]
		[XmlArrayItem("Scale", typeof(FCYAxisScaleInfo))]
		public FCYAxisScaleInfoList Scales
		{
			get
			{
				if (fcyaxisScaleInfoList_0 == null)
				{
					fcyaxisScaleInfoList_0 = new FCYAxisScaleInfoList();
				}
				return fcyaxisScaleInfoList_0;
			}
			set
			{
				fcyaxisScaleInfoList_0 = value;
			}
		}

		/// <summary>
		///       存在有效的自定义的刻度信息
		///       </summary>
		internal bool HasScales => fcyaxisScaleInfoList_0 != null && fcyaxisScaleInfoList_0.Count > 2;

		internal void method_0(FriedmanCurveDocument friedmanCurveDocument_0)
		{
			float_3 = 0f;
			if (TopPadding >= 0f)
			{
				float_3 = TopPadding;
			}
			else if (friedmanCurveDocument_0.Config.DataGridTopPadding >= 0f)
			{
				float_3 = friedmanCurveDocument_0.Config.DataGridTopPadding;
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
			else if (friedmanCurveDocument_0.Config.DataGridBottomPadding >= 0f)
			{
				float_4 = friedmanCurveDocument_0.Config.DataGridBottomPadding;
			}
			if (float_4 >= 1f)
			{
				float_4 = 0f;
			}
		}

		internal float method_1(float float_20)
		{
			if (ValuePrecision < 0)
			{
				return float_20;
			}
			if (FriedmanCurveDocument.smethod_3(float_20))
			{
				return float_20;
			}
			return (float)Math.Round(float_20, ValuePrecision);
		}

		internal bool method_2(float float_20)
		{
			if (FriedmanCurveDocument.smethod_3(float_20))
			{
				return true;
			}
			if (float_20 > MaxValue || float_20 < MinValue)
			{
				if (AllowOutofRange)
				{
					return true;
				}
				return false;
			}
			return true;
		}

		internal float method_3(FriedmanCurveDocument friedmanCurveDocument_0, RectangleF rectangleF_0, float float_20)
		{
			float num = method_5(float_20);
			if (FriedmanCurveDocument.smethod_3(num))
			{
				return float.NaN;
			}
			return rectangleF_0.Top + rectangleF_0.Height * RuntimeTopPadding + rectangleF_0.Height * (1f - RuntimeTopPadding - RuntimeBottomPadding) * (1f - num);
		}

		internal float method_4(FriedmanCurveDocument friedmanCurveDocument_0, RectangleF rectangleF_0, float float_20)
		{
			float num = rectangleF_0.Top + rectangleF_0.Height * (1f - RuntimeBottomPadding);
			float num2 = rectangleF_0.Top + rectangleF_0.Height * RuntimeTopPadding;
			float num3 = 1f - (float_20 - num2) / (num - num2);
			if (FriedmanCurveDocument.smethod_3(num3))
			{
				return float.NaN;
			}
			if (HasScales)
			{
				int num4 = 1;
				FCYAxisScaleInfo fCYAxisScaleInfo;
				while (true)
				{
					if (num4 < Scales.Count)
					{
						fCYAxisScaleInfo = Scales[num4];
						if (num3 >= fCYAxisScaleInfo.ScaleRate)
						{
							break;
						}
						num4++;
						continue;
					}
					return 0f;
				}
				FCYAxisScaleInfo fCYAxisScaleInfo2 = Scales[num4 - 1];
				float num5 = 0f;
				num5 = ((!(num3 > fCYAxisScaleInfo2.ScaleRate) && fCYAxisScaleInfo2.ScaleRate != fCYAxisScaleInfo.ScaleRate) ? (fCYAxisScaleInfo.Value + (fCYAxisScaleInfo2.Value - fCYAxisScaleInfo.Value) * ((num3 - fCYAxisScaleInfo.ScaleRate) / (fCYAxisScaleInfo2.ScaleRate - fCYAxisScaleInfo.ScaleRate))) : fCYAxisScaleInfo2.Value);
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

		private float method_5(float float_20)
		{
			int_3 = 0;
			if (FriedmanCurveDocument.smethod_3(float_20))
			{
				return float.NaN;
			}
			if (HasScales)
			{
				int num = 1;
				FCYAxisScaleInfo fCYAxisScaleInfo;
				while (true)
				{
					if (num < Scales.Count)
					{
						fCYAxisScaleInfo = Scales[num];
						if (float_20 >= fCYAxisScaleInfo.Value)
						{
							break;
						}
						num++;
						continue;
					}
					return 0f;
				}
				FCYAxisScaleInfo fCYAxisScaleInfo2 = Scales[num - 1];
				float num2 = 0f;
				return (!(float_20 > fCYAxisScaleInfo2.Value)) ? (fCYAxisScaleInfo.ScaleRate + (fCYAxisScaleInfo2.ScaleRate - fCYAxisScaleInfo.ScaleRate) * ((float_20 - fCYAxisScaleInfo.Value) / (fCYAxisScaleInfo2.Value - fCYAxisScaleInfo.Value))) : fCYAxisScaleInfo2.ScaleRate;
			}
			if (float_20 > MaxValue)
			{
				int_3 = 1;
				if (AllowOutofRange)
				{
					return 1f;
				}
				return float.NaN;
			}
			if (float_20 < MinValue)
			{
				int_3 = -1;
				if (AllowOutofRange)
				{
					return 0f;
				}
				return float.NaN;
			}
			return (float_20 - MinValue) / (MaxValue - MinValue);
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
		public FCYAxisInfo Clone()
		{
			FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)MemberwiseClone();
			if (fcyaxisScaleInfoList_0 != null)
			{
				fCYAxisInfo.fcyaxisScaleInfoList_0 = new FCYAxisScaleInfoList();
				foreach (FCYAxisScaleInfo item in fcyaxisScaleInfoList_0)
				{
					fCYAxisInfo.fcyaxisScaleInfoList_0.Add(item);
				}
			}
			return fCYAxisInfo;
		}
	}
}
