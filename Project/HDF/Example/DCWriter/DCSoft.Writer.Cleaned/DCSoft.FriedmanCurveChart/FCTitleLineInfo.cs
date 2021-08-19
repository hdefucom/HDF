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
	///       网格线标题行信息
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComDefaultInterface(typeof(ITitleLineInfo))]
	[Guid("7280403D-0D5F-4009-80B9-09E427C079C2")]
	[DCPublishAPI]
	[DCDescriptionResourceSource("DCSoft.FriedmanCurveChart.DCFriedmanCurveDescriptionResource")]
	[XmlType]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	public class FCTitleLineInfo : ITitleLineInfo
	{
		private float _BottomSpacing = 0f;

		private FCDateTimePrecisionMode _InputTimePrecision = FCDateTimePrecisionMode.Minute;

		private string _Name = null;

		private string _GroupName = null;

		private bool _AfterOperaDaysFromZero = false;

		private RectangleF _ExpandedHandleBounds = RectangleF.Empty;

		private bool _IsExpanded = true;

		private bool _ShowExpandedHandle = false;

		private bool _ValueTextMultiLine = false;

		private Color _OutofNormalRangeTextColor = Color.Red;

		private float _NormalMaxValue = -10000f;

		private float _NormalMinValue = -10000f;

		private FCDCExtendGridLineType _ExtendGridLineType = FCDCExtendGridLineType.Below;

		private FCTitleLineBorderStyle _TitleLineBorderStyle = FCTitleLineBorderStyle.Full;

		private bool _VerticalLineForFreeeLayout = true;

		private bool _EnableEndTime = true;

		private float _BlockWidth = 15f;

		private string _ValueDisplayFormat = null;

		private string _LoopTextList = null;

		private float _SpecifyTitleWidth = 0f;

		private string _Title = null;

		private XFontValue _Font = null;

		private XFontValue _ValueFont = null;

		private Color _TitleColor = Color.Black;

		private Color _TextColor = Color.Black;

		private StringAlignment _TitleAlign = StringAlignment.Center;

		private StringAlignment _ValueAlign = StringAlignment.Center;

		private int _MaxValueForDayIndex = 13;

		private FCValuePointDataSourceInfo _DataSource = null;

		private string _CircleText = null;

		private float _SpecifyHeight = 0f;

		private float _Top = 0f;

		/// <summary>
		///       对象高度
		///       </summary>
		private float _Height = 0f;

		/// <summary>
		///       运行时使用的高度
		///       </summary>
		internal float RuntimeHeight = 0f;

		/// <summary>
		///       内容行数
		///       </summary>
		internal int ContentLineCount = 1;

		/// <summary>
		///       标题边界
		///       </summary>
		internal RectangleF TitleBounds = RectangleF.Empty;

		private DateTime _StartDate = FriedmanCurveDocument.NullDate;

		private string _StartDateKeyword = null;

		private bool _ShowBackColor = false;

		private FCTitleLineLayoutType _LayoutType = FCTitleLineLayoutType.Normal;

		private int _TickStep = 1;

		private bool _UpAndDownText = false;

		/// <summary>
		///       运行时使用的开始计算的日期
		///       </summary>
		[NonSerialized]
		internal DateTime[] _RuntimeStartDates = null;

		private FCTitleLineValueType _ValueType = FCTitleLineValueType.TickText;

		private string _DataSourceName = null;

		private string _ValueFieldName = null;

		private string _TimeFieldName = null;

		private FCYAxisScaleInfoList _Scales = null;

		/// <summary>
		///       底端间隔区域
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCHeaderLabelInfo), "BottomSpacing")]
		[DefaultValue(0)]
		[Browsable(true)]
		public float BottomSpacing
		{
			get
			{
				return _BottomSpacing;
			}
			set
			{
				_BottomSpacing = value;
			}
		}

		/// <summary>
		///       输入时间的精度
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "InputTimePrecision")]
		[DefaultValue(FCDateTimePrecisionMode.Minute)]
		[XmlAttribute]
		public FCDateTimePrecisionMode InputTimePrecision
		{
			get
			{
				return _InputTimePrecision;
			}
			set
			{
				_InputTimePrecision = value;
			}
		}

		/// <summary>
		///       名称
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "Name")]
		[DefaultValue(null)]
		[Editor(typeof(FCEditNameUITypeEditor), typeof(UITypeEditor))]
		[XmlAttribute]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       分组名称
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "GroupName")]
		[DefaultValue(null)]
		public string GroupName
		{
			get
			{
				return _GroupName;
			}
			set
			{
				_GroupName = value;
			}
		}

		/// <summary>
		///       术后天数是否从0显示
		///       add by ld
		///       </summary>
		[DCDisplayName(typeof(FCYAxisInfo), "AfterOperaDaysFromZero")]
		[DefaultValue(true)]
		[XmlAttribute]
		public bool AfterOperaDaysFromZero
		{
			get
			{
				return _AfterOperaDaysFromZero;
			}
			set
			{
				_AfterOperaDaysFromZero = value;
			}
		}

		/// <summary>
		///       展开收缩句柄显示区域
		///       </summary>
		internal RectangleF ExpandedHandleBounds
		{
			get
			{
				return _ExpandedHandleBounds;
			}
			set
			{
				_ExpandedHandleBounds = value;
			}
		}

		/// <summary>
		///       对象是否是展开的
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public bool IsExpanded
		{
			get
			{
				return _IsExpanded;
			}
			set
			{
				_IsExpanded = value;
			}
		}

		/// <summary>
		///       是否显示展开收缩句柄
		///       </summary>
		internal bool ShowExpandedHandle
		{
			get
			{
				return _ShowExpandedHandle;
			}
			set
			{
				_ShowExpandedHandle = value;
			}
		}

		/// <summary>
		///       数值文本多行显示
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "ValueTextMultiLine")]
		[DefaultValue(false)]
		public bool ValueTextMultiLine
		{
			get
			{
				return _ValueTextMultiLine;
			}
			set
			{
				_ValueTextMultiLine = value;
			}
		}

		/// <summary>
		///       超出正常区域背景色
		///       </summary>
		[XmlIgnore]
		[DCDisplayName(typeof(FCTitleLineInfo), "OutofNormalRangeTextColor")]
		[DefaultValue(typeof(Color), "Red")]
		public Color OutofNormalRangeTextColor
		{
			get
			{
				return _OutofNormalRangeTextColor;
			}
			set
			{
				_OutofNormalRangeTextColor = value;
			}
		}

		/// <summary>
		///       文本形式的OutofNormalRangeTextColor属性值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlAttribute]
		public string OutofNormalRangeTextColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(OutofNormalRangeTextColor, Color.Red);
			}
			set
			{
				OutofNormalRangeTextColor = XMLSerializeHelper.StringToColor(value, Color.Red);
			}
		}

		/// <summary>
		///       数值正常范围的最大值
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "NormalMaxValue")]
		[XmlAttribute]
		[DefaultValue(-10000f)]
		public float NormalMaxValue
		{
			get
			{
				return _NormalMaxValue;
			}
			set
			{
				_NormalMaxValue = value;
			}
		}

		/// <summary>
		///       数值正常范围的最小值
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "NormalMinValue")]
		[DefaultValue(-10000f)]
		public float NormalMinValue
		{
			get
			{
				return _NormalMinValue;
			}
			set
			{
				_NormalMinValue = value;
			}
		}

		/// <summary>
		///       延伸的网格线样式
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "ExtendGridLineType")]
		[DefaultValue(FCDCExtendGridLineType.Below)]
		public FCDCExtendGridLineType ExtendGridLineType
		{
			get
			{
				return _ExtendGridLineType;
			}
			set
			{
				_ExtendGridLineType = value;
			}
		}

		/// <summary>
		///       边框样式
		///       </summary>
		[Browsable(true)]
		[DCDisplayName(typeof(FCTitleLineInfo), "TitleLineBorderStyle")]
		[DefaultValue(FCTitleLineBorderStyle.Full)]
		[XmlAttribute]
		public FCTitleLineBorderStyle TitleLineBorderStyle
		{
			get
			{
				return _TitleLineBorderStyle;
			}
			set
			{
				_TitleLineBorderStyle = value;
			}
		}

		/// <summary>
		///       针对自由排版的色块两边显示竖线
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "VerticalLineForFreeeLayout")]
		[DefaultValue(true)]
		public bool VerticalLineForFreeeLayout
		{
			get
			{
				return _VerticalLineForFreeeLayout;
			}
			set
			{
				_VerticalLineForFreeeLayout = value;
			}
		}

		/// <summary>
		///       启动数据块结束时间
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "EnableEndTime")]
		[XmlAttribute]
		[DefaultValue(true)]
		public bool EnableEndTime
		{
			get
			{
				return _EnableEndTime;
			}
			set
			{
				_EnableEndTime = value;
			}
		}

		/// <summary>
		///       色块宽度
		///       </summary>
		[DefaultValue(15f)]
		[DCDisplayName(typeof(FCTitleLineInfo), "BlockWidth")]
		[XmlAttribute]
		public float BlockWidth
		{
			get
			{
				return _BlockWidth;
			}
			set
			{
				_BlockWidth = value;
			}
		}

		/// <summary>
		///       显示数值使用的格式化字符串
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "ValueDisplayFormat")]
		[DefaultValue(null)]
		[XmlAttribute]
		public string ValueDisplayFormat
		{
			get
			{
				return _ValueDisplayFormat;
			}
			set
			{
				_ValueDisplayFormat = value;
			}
		}

		/// <summary>
		///       循环显示的文本，各个项目之间用半角逗号分开
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "LoopTextList")]
		[DefaultValue(null)]
		[XmlAttribute]
		public string LoopTextList
		{
			get
			{
				return _LoopTextList;
			}
			set
			{
				_LoopTextList = value;
			}
		}

		/// <summary>
		///       指定的标题宽度,小于等于0为无效设置，将自动计算标题宽度。
		///       </summary>
		[DefaultValue(0f)]
		[DCDisplayName(typeof(FCTitleLineInfo), "SpecifyTitleWidth")]
		[XmlAttribute]
		public float SpecifyTitleWidth
		{
			get
			{
				return _SpecifyTitleWidth;
			}
			set
			{
				_SpecifyTitleWidth = value;
			}
		}

		/// <summary>
		///       标题文本
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "Title")]
		[DefaultValue(null)]
		[Editor(typeof(FCEditTitleUITypeEditor), typeof(UITypeEditor))]
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
		///       字体
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		[Browsable(true)]
		[DCDisplayName(typeof(FCTitleLineInfo), "Font")]
		public XFontValue Font
		{
			get
			{
				return _Font;
			}
			set
			{
				_Font = value;
			}
		}

		/// <summary>
		///       字体
		///       </summary>
		[DefaultValue(null)]
		[Browsable(true)]
		[DCDisplayName(typeof(FCTitleLineInfo), "ValueFont")]
		[XmlElement]
		public XFontValue ValueFont
		{
			get
			{
				return _ValueFont;
			}
			set
			{
				_ValueFont = value;
			}
		}

		/// <summary>
		///       标题文本颜色
		///       </summary>
		[XmlIgnore]
		[DCDisplayName(typeof(FCTitleLineInfo), "TitleColor")]
		[DefaultValue(typeof(Color), "Black")]
		public Color TitleColor
		{
			get
			{
				return _TitleColor;
			}
			set
			{
				_TitleColor = value;
			}
		}

		/// <summary>
		///       文本形式的标题文本颜色值
		///       </summary>
		[DefaultValue(null)]
		[Browsable(false)]
		[XmlAttribute]
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
		///       文本颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
		[XmlIgnore]
		[DCDisplayName(typeof(FCTitleLineInfo), "TextColor")]
		public Color TextColor
		{
			get
			{
				return _TextColor;
			}
			set
			{
				_TextColor = value;
			}
		}

		/// <summary>
		///       文本颜色值
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlAttribute]
		public string TextColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(TextColor, Color.Black);
			}
			set
			{
				TextColor = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       标题对齐方式
		///       </summary>
		[DefaultValue(StringAlignment.Center)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "TitleAlign")]
		public StringAlignment TitleAlign
		{
			get
			{
				return _TitleAlign;
			}
			set
			{
				_TitleAlign = value;
			}
		}

		/// <summary>
		///       数值对齐方式
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "ValueAlign")]
		[DefaultValue(StringAlignment.Center)]
		public StringAlignment ValueAlign
		{
			get
			{
				return _ValueAlign;
			}
			set
			{
				_ValueAlign = value;
			}
		}

		/// <summary>
		///       显示的ForDayIndex的最大值，为0表示不限制。默认为13.
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "MaxValueForDayIndex")]
		[XmlAttribute]
		[DefaultValue(13)]
		public int MaxValueForDayIndex
		{
			get
			{
				return _MaxValueForDayIndex;
			}
			set
			{
				_MaxValueForDayIndex = value;
			}
		}

		/// <summary>
		///       数据源
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		[DCDisplayName(typeof(FCTitleLineInfo), "DataSource")]
		[DefaultValue(null)]
		public FCValuePointDataSourceInfo DataSource
		{
			get
			{
				if (_DataSource == null)
				{
					_DataSource = new FCValuePointDataSourceInfo();
				}
				return _DataSource;
			}
			set
			{
				_DataSource = value;
			}
		}

		/// <summary>
		///       画圈的文本值
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "CircleText")]
		public string CircleText
		{
			get
			{
				return _CircleText;
			}
			set
			{
				_CircleText = value;
			}
		}

		/// <summary>
		///       指定的高度，以Document(1/300英寸)为单位
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "SpecifyHeight")]
		[XmlAttribute]
		[DefaultValue(0f)]
		public float SpecifyHeight
		{
			get
			{
				return _SpecifyHeight;
			}
			set
			{
				_SpecifyHeight = value;
			}
		}

		/// <summary>
		///       顶端位置
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float Top
		{
			get
			{
				return _Top;
			}
			set
			{
				_Top = value;
			}
		}

		/// <summary>
		///       对象高度
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float Height
		{
			get
			{
				return _Height;
			}
			set
			{
				_Height = value;
				if (SpecifyHeight == 0f)
				{
					RuntimeHeight = _Height;
				}
			}
		}

		/// <summary>
		///       开始计算的日期
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "StartDate")]
		[DefaultValue(typeof(DateTime), "1900-1-1")]
		public DateTime StartDate
		{
			get
			{
				return _StartDate;
			}
			set
			{
				_StartDate = value;
			}
		}

		/// <summary>
		///       判断开始计算日期的关键字
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(FCTitleLineInfo), "StartDateKeyword")]
		[XmlAttribute]
		public string StartDateKeyword
		{
			get
			{
				return _StartDateKeyword;
			}
			set
			{
				_StartDateKeyword = value;
			}
		}

		/// <summary>
		///       是否显示背景色
		///       </summary>
		[DefaultValue(false)]
		[DCDisplayName(typeof(FCTitleLineInfo), "ShowBackColor")]
		[XmlAttribute]
		public bool ShowBackColor
		{
			get
			{
				return _ShowBackColor;
			}
			set
			{
				_ShowBackColor = value;
			}
		}

		/// <summary>
		///       内容布局模式
		///       </summary>
		[DefaultValue(FCTitleLineLayoutType.Normal)]
		[DCDisplayName(typeof(FCTitleLineInfo), "LayoutType")]
		[XmlAttribute]
		public FCTitleLineLayoutType LayoutType
		{
			get
			{
				return _LayoutType;
			}
			set
			{
				_LayoutType = value;
			}
		}

		/// <summary>
		///       运行时使用的布局方式
		///       </summary>
		internal FCTitleLineLayoutType RuntimeLayoutType
		{
			get
			{
				if (_LayoutType == FCTitleLineLayoutType.AutoCascade)
				{
					if (IsExpanded)
					{
						return FCTitleLineLayoutType.Cascade;
					}
					return FCTitleLineLayoutType.HorizCascade;
				}
				return _LayoutType;
			}
		}

		/// <summary>
		///       跨越时间刻度个数
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "TickStep")]
		[DefaultValue(1)]
		public int TickStep
		{
			get
			{
				return _TickStep;
			}
			set
			{
				_TickStep = value;
			}
		}

		/// <summary>
		///       是否上下交替绘制文本
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "UpAndDownText")]
		[XmlAttribute]
		[DefaultValue(false)]
		public bool UpAndDownText
		{
			get
			{
				return _UpAndDownText;
			}
			set
			{
				_UpAndDownText = value;
			}
		}

		/// <summary>
		///       样式
		///       </summary>
		[XmlAttribute]
		[DefaultValue(FCTitleLineValueType.TickText)]
		[DCDisplayName(typeof(FCTitleLineInfo), "ValueType")]
		public FCTitleLineValueType ValueType
		{
			get
			{
				return _ValueType;
			}
			set
			{
				_ValueType = value;
			}
		}

		/// <summary>
		///       数据源的名称
		///       </summary>
		[DCDisplayName(typeof(FCTitleLineInfo), "DataSourceName")]
		[XmlAttribute]
		[DefaultValue(null)]
		public string DataSourceName
		{
			get
			{
				return _DataSourceName;
			}
			set
			{
				_DataSourceName = value;
			}
		}

		/// <summary>
		///       数据字段的名称
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(FCTitleLineInfo), "ValueFieldName")]
		public string ValueFieldName
		{
			get
			{
				return _ValueFieldName;
			}
			set
			{
				_ValueFieldName = value;
			}
		}

		/// <summary>
		///       表示数据时间的字段名
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		[DCDisplayName(typeof(FCTitleLineInfo), "TimeFieldName")]
		public string TimeFieldName
		{
			get
			{
				return _TimeFieldName;
			}
			set
			{
				_TimeFieldName = value;
			}
		}

		/// <summary>
		///       自定义的刻度信息列表
		///       </summary>
		[XmlArrayItem("Scale", typeof(FCYAxisScaleInfo))]
		[DefaultValue(null)]
		public FCYAxisScaleInfoList Scales
		{
			get
			{
				if (_Scales == null)
				{
					_Scales = new FCYAxisScaleInfoList();
				}
				return _Scales;
			}
			set
			{
				_Scales = value;
			}
		}

		/// <summary>
		///       计算运行时使用的高度
		///       </summary>
		/// <param name="unit">当前高度使用的度量单位</param>
		internal void RefreshRuntimeHeight(GraphicsUnit unit)
		{
			if (SpecifyHeight > 0f)
			{
				RuntimeHeight = GraphicsUnitConvert.Convert(SpecifyHeight, GraphicsUnit.Document, unit);
			}
			else
			{
				RuntimeHeight = Height;
			}
		}

		/// <summary>
		///       返回表示对象的字符串
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
		public FCTitleLineInfo Clone()
		{
			return (FCTitleLineInfo)MemberwiseClone();
		}
	}
}
