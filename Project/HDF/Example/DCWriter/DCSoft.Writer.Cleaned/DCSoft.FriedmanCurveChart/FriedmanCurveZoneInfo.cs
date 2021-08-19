using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       产程图区域信息对象
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	[DCDescriptionResourceSource("DCSoft.FriedmanCurveChart.DCFriedmanCurveDescriptionResource")]
	public class FriedmanCurveZoneInfo
	{
		private FriedmanCurveZoneInfo _ParentZone = null;

		private RectangleF _ExpandedHandleBounds = RectangleF.Empty;

		private bool _IsExpanded = true;

		private int _ZoneIndex = 0;

		private Class164 _FirstTickItem = null;

		private Class164 _LastTickItem = null;

		private float _Left = 0f;

		private float _Top = 0f;

		private float _Width = 0f;

		private float _Height = 0f;

		private string _Name = null;

		private DateTime _StartTime = FriedmanCurveDocument.NullDate;

		private DateTime _EndTime = FriedmanCurveDocument.NullDate;

		private bool _AlignToGrid = true;

		private DashStyle _GridLineStyle = DashStyle.Solid;

		private Color _GridLineColor = Color.Transparent;

		private Color _BackColor = Color.Transparent;

		private float _SpecifyTickWidth = 0f;

		private FCTickInfoList _Ticks = null;

		private int _AutoTickStepSeconds = 0;

		private string _AutoTickFormatString = null;

		/// <summary>
		///       父区域
		///       </summary>
		internal FriedmanCurveZoneInfo ParentZone
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
		internal Class164 FirstTickItem
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
		internal Class164 LastTickItem
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
		[DefaultValue(null)]
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "Name")]
		[XmlAttribute]
		[Browsable(true)]
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
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "StartTime")]
		[XmlAttribute]
		[DefaultValue(typeof(DateTime), "1900-1-1")]
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
		[XmlAttribute]
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "EndTime")]
		[DefaultValue(typeof(DateTime), "1900-1-1")]
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
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "AlignToGrid")]
		[DefaultValue(true)]
		[Browsable(true)]
		[XmlAttribute]
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
		[DefaultValue(DashStyle.Solid)]
		[Browsable(true)]
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "GridLineStyle")]
		[XmlAttribute]
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
		[DefaultValue(typeof(Color), "Transparent")]
		[XmlIgnore]
		[Browsable(true)]
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "GridLineColor")]
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
		[XmlAttribute]
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
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "BackColor")]
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
		///       文本形式的颜色值
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
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
		///       指定的最小刻度长度，小于等于0则自动计算，默认为0.
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "SpecifyTickWidth")]
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
		[Browsable(true)]
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "Ticks")]
		[XmlArrayItem("Tick", typeof(FCTickInfo))]
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
		///       自动生成刻度使用的时间步长秒数，大于0有效
		///       </summary>
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "AutoTickStepSeconds")]
		[XmlAttribute]
		[DefaultValue(0)]
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
		[XmlAttribute]
		[DefaultValue(null)]
		[DCDisplayName(typeof(FriedmanCurveZoneInfo), "AutoTickFormatString")]
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
			if (!FriedmanCurveDocument.smethod_4(StartTime) && dateTime_0 < StartTime)
			{
				return false;
			}
			if (!FriedmanCurveDocument.smethod_4(EndTime) && dateTime_0 > EndTime)
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
			int num = 0;
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
		public FriedmanCurveZoneInfo Clone()
		{
			FriedmanCurveZoneInfo friedmanCurveZoneInfo = (FriedmanCurveZoneInfo)MemberwiseClone();
			if (_Ticks != null)
			{
				friedmanCurveZoneInfo._Ticks = _Ticks.Clone();
			}
			return friedmanCurveZoneInfo;
		}
	}
}
