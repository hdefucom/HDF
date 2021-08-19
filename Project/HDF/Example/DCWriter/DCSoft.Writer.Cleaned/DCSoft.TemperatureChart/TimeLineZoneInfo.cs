using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间轴区域信息对象
	///       </summary>
	[DCDescriptionResourceSource("DCSoft.TemperatureChart.DCTimeLineDescriptionResource")]
	[ComVisible(false)]
	[DocumentComment]
	public class TimeLineZoneInfo
	{
		private TimeLineZoneInfo _ParentZone = null;

		private RectangleF _ExpandedHandleBounds = RectangleF.Empty;

		private bool _IsExpanded = true;

		private int _ZoneIndex = 0;

		private Class158 _FirstTickItem = null;

		private Class158 _LastTickItem = null;

		private float _Left = 0f;

		private float _Top = 0f;

		private float _Width = 0f;

		private float _Height = 0f;

		private string _Name = null;

		private DateTime _StartTime = TemperatureDocument.NullDate;

		private DateTime _EndTime = TemperatureDocument.NullDate;

		private bool _AlignToGrid = true;

		private DashStyle _GridLineStyle = DashStyle.Solid;

		private Color _GridLineColor = Color.Transparent;

		private Color _BackColor = Color.Transparent;

		private float _SpecifyTickWidth = 0f;

		private TickInfoList _Ticks = null;

		private int _AutoTickStepSeconds = 0;

		private string _AutoTickFormatString = null;

		/// <summary>
		///       父区域
		///       </summary>
		internal TimeLineZoneInfo ParentZone
		{
			get
			{
				return _ParentZone;
			}
			set
			{
				_ParentZone = value;
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
		[XmlIgnore]
		[Browsable(false)]
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
		///       区域序号
		///       </summary>
		internal int ZoneIndex
		{
			get
			{
				return _ZoneIndex;
			}
			set
			{
				_ZoneIndex = value;
			}
		}

		/// <summary>
		///       第一个时刻信息对象
		///       </summary>
		internal Class158 FirstTickItem
		{
			get
			{
				return _FirstTickItem;
			}
			set
			{
				_FirstTickItem = value;
			}
		}

		/// <summary>
		///       最后一个时刻信息对象
		///       </summary>
		internal Class158 LastTickItem
		{
			get
			{
				return _LastTickItem;
			}
			set
			{
				_LastTickItem = value;
			}
		}

		/// <summary>
		///       左端位置
		///       </summary>
		internal float Left
		{
			get
			{
				return _Left;
			}
			set
			{
				_Left = value;
			}
		}

		/// <summary>
		///       顶端位置
		///       </summary>
		internal float Top
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
		///       宽度
		///       </summary>
		internal float Width
		{
			get
			{
				return _Width;
			}
			set
			{
				_Width = value;
			}
		}

		/// <summary>
		///       高度
		///       </summary>
		internal float Height
		{
			get
			{
				return _Height;
			}
			set
			{
				_Height = value;
			}
		}

		/// <summary>
		///       区域名称
		///       </summary>
		[DCDisplayName(typeof(TimeLineZoneInfo), "Name")]
		[XmlAttribute]
		[Browsable(true)]
		[DefaultValue(null)]
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
		///       区域开始时间
		///       </summary>
		[DefaultValue(typeof(DateTime), "1900-1-1")]
		[DCDisplayName(typeof(TimeLineZoneInfo), "StartTime")]
		[XmlAttribute]
		[Browsable(true)]
		public DateTime StartTime
		{
			get
			{
				return _StartTime;
			}
			set
			{
				_StartTime = value;
			}
		}

		/// <summary>
		///       区域结束时间
		///       </summary>
		[DefaultValue(typeof(DateTime), "1900-1-1")]
		[XmlAttribute]
		[DCDisplayName(typeof(TimeLineZoneInfo), "EndTime")]
		[Browsable(true)]
		public DateTime EndTime
		{
			get
			{
				return _EndTime;
			}
			set
			{
				_EndTime = value;
			}
		}

		/// <summary>
		///       是否对齐到网格线
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		[DCDisplayName(typeof(TimeLineZoneInfo), "AlignToGrid")]
		[Browsable(true)]
		public bool AlignToGrid
		{
			get
			{
				return _AlignToGrid;
			}
			set
			{
				_AlignToGrid = value;
			}
		}

		/// <summary>
		///       网格线样式
		///       </summary>
		[DCDisplayName(typeof(TimeLineZoneInfo), "GridLineStyle")]
		[XmlAttribute]
		[Browsable(true)]
		[DefaultValue(DashStyle.Solid)]
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
		///       网格线颜色值
		///       </summary>
		[DCDisplayName(typeof(TimeLineZoneInfo), "GridLineColor")]
		[Browsable(true)]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
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
		[Browsable(false)]
		[XmlAttribute]
		[DefaultValue(null)]
		public string GridLineColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(GridLineColor, Color.Transparent);
			}
			set
			{
				GridLineColor = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       颜色值
		///       </summary>
		[DefaultValue(typeof(Color), "Transparent")]
		[DCDisplayName(typeof(TimeLineZoneInfo), "BackColor")]
		[Browsable(true)]
		[XmlIgnore]
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
		[XmlAttribute]
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
		///       指定的最小刻度长度，小于等于0则自动计算，默认为0.
		///       </summary>
		[DCDisplayName(typeof(TimeLineZoneInfo), "SpecifyTickWidth")]
		[DefaultValue(0f)]
		[XmlAttribute]
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
		///       时间刻度
		///       </summary>
		[DCDisplayName(typeof(TimeLineZoneInfo), "Ticks")]
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
		///       自动生成刻度使用的时间步长秒数，大于0有效
		///       </summary>
		[DCDisplayName(typeof(TimeLineZoneInfo), "AutoTickStepSeconds")]
		[DefaultValue(0)]
		[XmlAttribute]
		public int AutoTickStepSeconds
		{
			get
			{
				return _AutoTickStepSeconds;
			}
			set
			{
				_AutoTickStepSeconds = value;
			}
		}

		/// <summary>
		///       自动生成刻度时使用的格式化字符串
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(TimeLineZoneInfo), "AutoTickFormatString")]
		public string AutoTickFormatString
		{
			get
			{
				return _AutoTickFormatString;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_AutoTickFormatString = null;
				}
				else
				{
					_AutoTickFormatString = value;
				}
			}
		}

		/// <summary>
		///       判断是否在时间区域中
		///       </summary>
		/// <param name="dtm">时间值</param>
		/// <returns>是否在区域中</returns>
		internal bool Contains(DateTime dateTime_0)
		{
			if (!TemperatureDocument.smethod_4(StartTime) && dateTime_0 < StartTime)
			{
				return false;
			}
			if (!TemperatureDocument.smethod_4(EndTime) && dateTime_0 > EndTime)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>
		/// </returns>
		public override string ToString()
		{
			int num = 12;
			string text = Name + "|" + StartTime.ToString("yyyy-MM-dd") + "->" + EndTime.ToString("yyyy-MM-dd");
			if (_Ticks != null)
			{
				text = text + ":" + _Ticks.ToString();
			}
			return text;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public TimeLineZoneInfo Clone()
		{
			TimeLineZoneInfo timeLineZoneInfo = (TimeLineZoneInfo)MemberwiseClone();
			if (_Ticks != null)
			{
				timeLineZoneInfo._Ticks = _Ticks.Clone();
			}
			return timeLineZoneInfo;
		}
	}
}
