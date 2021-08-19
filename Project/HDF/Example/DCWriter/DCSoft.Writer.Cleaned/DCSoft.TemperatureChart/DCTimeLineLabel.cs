using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Drawing.Design;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       文本标签对象
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	[DCDescriptionResourceSource("DCSoft.TemperatureChart.DCTimeLineDescriptionResource")]
	public class DCTimeLineLabel
	{
		private string _Text = null;

		private XImageValue _Image = null;

		private bool _ShowBorder = false;

		private string _ParameterName = null;

		private bool _MultiLine = false;

		private XFontValue _Font = null;

		private Color _Color = Color.Black;

		private Color _BackColor = Color.Transparent;

		private StringAlignment _Alignment = StringAlignment.Center;

		private StringAlignment _LineAlignment = StringAlignment.Center;

		private float _Left = 0f;

		private float _Top = 0f;

		private float _Width = 100f;

		private float _Height = 100f;

		/// <summary>
		///       文本
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		[DCDisplayName(typeof(DCTimeLineLabel), "Text")]
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
		///       图片内容
		///       </summary>
		[DCDisplayName(typeof(DCTimeLineLabel), "Image")]
		[Editor(typeof(SimpleImageValueEditor), typeof(UITypeEditor))]
		[Browsable(true)]
		[DefaultValue(null)]
		[XmlElement]
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
		///       是否显示边框
		///       </summary>
		[DefaultValue(false)]
		public bool ShowBorder
		{
			get
			{
				return _ShowBorder;
			}
			set
			{
				_ShowBorder = value;
			}
		}

		/// <summary>
		///       引用的参数名
		///       </summary>
		[DefaultValue(null)]
		[DCDisplayName(typeof(DCTimeLineLabel), "ParameterName")]
		[XmlAttribute]
		public string ParameterName
		{
			get
			{
				return _ParameterName;
			}
			set
			{
				_ParameterName = value;
			}
		}

		/// <summary>
		///       显示多行
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(DCTimeLineLabel), "MultiLine")]
		[DefaultValue(false)]
		public bool MultiLine
		{
			get
			{
				return _MultiLine;
			}
			set
			{
				_MultiLine = value;
			}
		}

		/// <summary>
		///       绘制文本使用的字体
		///       </summary>
		[DCDisplayName(typeof(DCTimeLineLabel), "Font")]
		[DefaultValue(null)]
		[Browsable(true)]
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
		///       文本颜色
		///       </summary>
		[DCDisplayName(typeof(DCTimeLineLabel), "Color")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
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
		///       文本颜色值
		///       </summary>
		[Browsable(false)]
		[XmlAttribute]
		[DefaultValue(null)]
		public string ColorValue
		{
			get
			{
				return XMLSerializeHelper.ColorToString(Color, Color.Black);
			}
			set
			{
				Color = XMLSerializeHelper.StringToColor(value, Color.Black);
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		[DCDisplayName(typeof(DCTimeLineLabel), "BackColor")]
		[DefaultValue(typeof(Color), "Transparent")]
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
		///       文本颜色值
		///       </summary>
		[Browsable(false)]
		[XmlAttribute]
		[DefaultValue(null)]
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
		///       水平对齐方式
		///       </summary>
		[DCDisplayName(typeof(DCTimeLineLabel), "Alignment")]
		[XmlAttribute]
		[DefaultValue(StringAlignment.Center)]
		public StringAlignment Alignment
		{
			get
			{
				return _Alignment;
			}
			set
			{
				_Alignment = value;
			}
		}

		/// <summary>
		///       垂直对齐方式
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(DCTimeLineLabel), "LineAlignment")]
		[DefaultValue(StringAlignment.Center)]
		public StringAlignment LineAlignment
		{
			get
			{
				return _LineAlignment;
			}
			set
			{
				_LineAlignment = value;
			}
		}

		/// <summary>
		///       左端位置
		///       </summary>
		[DCDisplayName(typeof(DCTimeLineLabel), "Left")]
		[XmlAttribute]
		[DefaultValue(0f)]
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
		///       顶端位置
		///       </summary>
		[DefaultValue(0f)]
		[DCDisplayName(typeof(DCTimeLineLabel), "Top")]
		[XmlAttribute]
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
		///       宽度
		///       </summary>
		[XmlAttribute]
		[DCDisplayName(typeof(DCTimeLineLabel), "Width")]
		[DefaultValue(100f)]
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
		///       高度
		///       </summary>
		[DCDisplayName(typeof(DCTimeLineLabel), "Height")]
		[DefaultValue(100f)]
		[XmlAttribute]
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

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DCTimeLineLabel Clone()
		{
			return (DCTimeLineLabel)MemberwiseClone();
		}
	}
}
