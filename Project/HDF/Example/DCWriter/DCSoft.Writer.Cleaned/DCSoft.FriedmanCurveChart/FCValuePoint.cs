using DCSoft.Common;
using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       数据点对象
	///       </summary>
	[DCPublishAPI]
	[Guid("745D920E-3A66-494B-8877-44FC8139873F")]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IValuePoint))]
	public class FCValuePoint : IValuePoint
	{
		[NonSerialized]
		private FCValuePointList _OwnerList = null;

		internal bool HollowCovertFlag = false;

		private static int _InstanceCount = 0;

		private int _InstanceIndex = _InstanceCount++;

		private bool _Verified = false;

		private float _ValueTextTopPadding = 0f;

		private string _TagValue = null;

		private string _ID = null;

		private FCValuePointSymbolStyle _SpecifySymbolStyle = FCValuePointSymbolStyle.Default;

		private string _Link = null;

		private XImageValue _Image = null;

		private XImageValue _CustomImage = null;

		private string _LinkTarget = null;

		private string _Title = null;

		private DateTime _Time = DateTime.MinValue;

		[NonSerialized]
		private DateTime _EndTime = DateTime.MinValue;

		[NonSerialized]
		private bool _Visible = true;

		[NonSerialized]
		private int _OutofRangeFlag = 0;

		private float _Value = -10000f;

		[NonSerialized]
		private object _Parent = null;

		[NonSerialized]
		private float _Left = 0f;

		[NonSerialized]
		private float _Top = 0f;

		[NonSerialized]
		private float _Width = 0f;

		[NonSerialized]
		private float _Height = 0f;

		private RectangleF _ViewBounds = RectangleF.Empty;

		/// <summary>
		///       对应的阴影数据点对象
		///       </summary>
		internal FCValuePoint ShadowPoint = null;

		private float _LanternValue = -10000f;

		private string _Text = null;

		private FCValuePointUpAndDown _UpAndDown = FCValuePointUpAndDown.None;

		private Color _Color = Color.Transparent;

		/// <summary>
		///       判断是否具有阴影图形
		///       </summary>
		internal bool HasShadowShape = false;

		[NonSerialized]
		private object _DataBoundItem = null;

		/// <summary>
		///       对象所示的列表
		///       </summary>
		[XmlIgnore]
		internal FCValuePointList OwnerList
		{
			get
			{
				return _OwnerList;
			}
			set
			{
				_OwnerList = value;
			}
		}

		/// <summary>
		///       对象实例编号
		///       </summary>
		public int InstanceIndex => _InstanceIndex;

		/// <summary>
		///       是否核实，体温若突然上升或下降与病情不符时应予复测，核实无误后在原体温上方用蓝笔写一小写英文字母"V"
		///       </summary>
		[DefaultValue(false)]
		public bool Verified
		{
			get
			{
				return _Verified;
			}
			set
			{
				_Verified = value;
			}
		}

		/// <summary>
		///       数值提示文本顶端内距
		///       </summary>
		[DefaultValue(0f)]
		public float ValueTextTopPadding
		{
			get
			{
				return _ValueTextTopPadding;
			}
			set
			{
				_ValueTextTopPadding = value;
			}
		}

		/// <summary>
		///       额外标记值
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string TagValue
		{
			get
			{
				return _TagValue;
			}
			set
			{
				_TagValue = value;
			}
		}

		/// <summary>
		///       节点编号
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		/// <summary>
		///       指定的数据点图例样式
		///       </summary>
		[XmlAttribute]
		[DefaultValue(FCValuePointSymbolStyle.Default)]
		public FCValuePointSymbolStyle SpecifySymbolStyle
		{
			get
			{
				return _SpecifySymbolStyle;
			}
			set
			{
				_SpecifySymbolStyle = value;
			}
		}

		/// <summary>
		///       超链接地址
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string Link
		{
			get
			{
				return _Link;
			}
			set
			{
				_Link = value;
			}
		}

		/// <summary>
		///       图标
		///       </summary>
		[DefaultValue(null)]
		public XImageValue Image
		{
			get
			{
				return _Image;
			}
			set
			{
				_Image = value;
			}
		}

		/// <summary>
		///       自定义图标
		///       </summary>
		[DefaultValue(null)]
		[Browsable(true)]
		public XImageValue CustomImage
		{
			get
			{
				return _CustomImage;
			}
			set
			{
				_CustomImage = value;
			}
		}

		/// <summary>
		///       图标数值
		///       </summary>
		[Browsable(false)]
		[DefaultValue(null)]
		[XmlIgnore]
		public Image ImageValue
		{
			get
			{
				if (_Image == null)
				{
					return null;
				}
				return _Image.Value;
			}
			set
			{
				if (value == null)
				{
					_Image = null;
				}
				else
				{
					_Image = new XImageValue(value);
				}
			}
		}

		/// <summary>
		///       超链接目标
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string LinkTarget
		{
			get
			{
				return _LinkTarget;
			}
			set
			{
				_LinkTarget = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
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
		///       运行时标题
		///       </summary>
		[Browsable(false)]
		public string RuntimeTitle
		{
			get
			{
				int num = 0;
				if (string.IsNullOrEmpty(Title))
				{
					string text = Time.ToString("yyyy-MM-dd HH:mm:ss");
					if (Parent is FCYAxisInfo)
					{
						FCYAxisInfo fCYAxisInfo = (FCYAxisInfo)Parent;
						if (fCYAxisInfo.Style == FCYAxisInfoStyle.Value)
						{
							text = text + " " + ((FCYAxisInfo)Parent).Title;
						}
					}
					else if (Parent is FCTitleLineInfo)
					{
						text = text + " " + ((FCTitleLineInfo)Parent).Title;
					}
					if (!string.IsNullOrEmpty(Text))
					{
						text = text + " " + Text;
					}
					else if (!FriedmanCurveDocument.smethod_3(Value))
					{
						text = text + " " + Value;
					}
					return text;
				}
				return Title;
			}
		}

		/// <summary>
		///       数据时间
		///       </summary>
		[XmlAttribute]
		public DateTime Time
		{
			get
			{
				return _Time;
			}
			set
			{
				_Time = value;
			}
		}

		/// <summary>
		///       数据结束时间
		///       </summary>
		[XmlIgnore]
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
		///       数据点是否可见
		///       </summary>
		internal bool Visible
		{
			get
			{
				return _Visible;
			}
			set
			{
				_Visible = value;
			}
		}

		/// <summary>
		///       超出取值范围标记
		///       </summary>
		internal int OutofRangeFlag
		{
			get
			{
				return _OutofRangeFlag;
			}
			set
			{
				_OutofRangeFlag = value;
			}
		}

		/// <summary>
		///       数值
		///       </summary>
		[XmlAttribute]
		[DefaultValue(-10000f)]
		public float Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		/// <summary>
		///       数值文本
		///       </summary>
		[Browsable(false)]
		public string ValueString
		{
			get
			{
				if (Parent is FCYAxisInfo)
				{
					string valueFormatString = ((FCYAxisInfo)Parent).ValueFormatString;
					if (!string.IsNullOrEmpty(valueFormatString))
					{
						return Value.ToString(valueFormatString);
					}
				}
				return Value.ToString();
			}
		}

		/// <summary>
		///       判断是否为空数值
		///       </summary>
		[Browsable(false)]
		public bool IsNullValue => FriedmanCurveDocument.smethod_3(Value);

		/// <summary>
		///       父对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public object Parent
		{
			get
			{
				return _Parent;
			}
			set
			{
				_Parent = value;
			}
		}

		/// <summary>
		///       数据点在视图中的X坐标
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float Left
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
		///       数据点在视图中的Y坐标
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
				if (_Top != value)
				{
					_Top = value;
				}
			}
		}

		/// <summary>
		///       视图宽度
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public float Width
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
		///       数据点在视图中的高度
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public float Height
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

		internal float CenterX => Left + Width / 2f;

		internal float CenterY
		{
			get
			{
				float num = Top + Height / 2f;
				if (!float.IsNaN(num))
				{
				}
				return num;
			}
		}

		/// <summary>
		///       显示边界
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public RectangleF ViewBounds
		{
			get
			{
				return _ViewBounds;
			}
			set
			{
				_ViewBounds = value;
			}
		}

		/// <summary>
		///       绘制阴影数据点
		///       </summary>
		[XmlIgnore]
		internal bool ShowShadowPoint
		{
			get
			{
				if (ShadowPoint != null && !ShadowPoint.IsNullValue && !IsNullValue && (double)Math.Abs(ShadowPoint.Value - Value) > 0.01)
				{
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///       挂灯笼的数值
		///       </summary>
		[DefaultValue(-10000f)]
		[XmlAttribute]
		public float LanternValue
		{
			get
			{
				return _LanternValue;
			}
			set
			{
				_LanternValue = value;
			}
		}

		/// <summary>
		///       文本值
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				_Text = value;
			}
		}

		/// <summary>
		///       数据点垂直对齐方式
		///       </summary>
		[XmlIgnore]
		public FCValuePointUpAndDown UpAndDown
		{
			get
			{
				return _UpAndDown;
			}
			set
			{
				_UpAndDown = value;
			}
		}

		/// <summary>
		///       运行时使用的文本
		///       </summary>
		public string RuntimeText
		{
			get
			{
				string text = Text;
				if (string.IsNullOrEmpty(text) && !FriedmanCurveDocument.smethod_3(Value))
				{
					text = Value.ToString();
					if (Parent is FCTitleLineInfo)
					{
						FCTitleLineInfo fCTitleLineInfo = (FCTitleLineInfo)Parent;
						if (!string.IsNullOrEmpty(fCTitleLineInfo.ValueDisplayFormat))
						{
							text = Value.ToString(fCTitleLineInfo.ValueDisplayFormat);
						}
					}
				}
				return text;
			}
		}

		/// <summary>
		///       颜色值
		///       </summary>
		[XmlIgnore]
		public Color Color
		{
			get
			{
				return _Color;
			}
			set
			{
				_Color = value;
			}
		}

		/// <summary>
		///       文本形式的颜色值
		///       </summary>
		[XmlAttribute]
		[Browsable(false)]
		[DefaultValue(null)]
		public string ColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(Color, Color.Transparent);
			}
			set
			{
				Color = XMLSerializeHelper.StringToColor(value, Color.Transparent);
			}
		}

		/// <summary>
		///       绑定的数据源对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public object DataBoundItem
		{
			get
			{
				return _DataBoundItem;
			}
			set
			{
				_DataBoundItem = value;
			}
		}

		/// <summary>
		///       使用BASE64字符串来加载图标
		///       </summary>
		/// <param name="txt">
		/// </param>
		[ComVisible(true)]
		public void LoadImageByBase64String(string string_0)
		{
			Image image_ = GClass343.smethod_9(string_0);
			_Image = new XImageValue(image_);
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return Time.ToString("yyyy-MM-dd HH:mm:ss") + "#" + RuntimeText;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public FCValuePoint Clone()
		{
			return (FCValuePoint)MemberwiseClone();
		}
	}
}
