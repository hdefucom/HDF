using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Drawing.Design;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       文本标签对象
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	[DCDescriptionResourceSource("DCSoft.FriedmanCurveChart.DCFriedmanCurveDescriptionResource")]
	public class DCFriedmanCurveLabel
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
		[XmlAttribute]
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Text")]
		[DefaultValue(null)]
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
		[Editor(typeof(SimpleImageValueEditor), typeof(UITypeEditor))]
		[DefaultValue(null)]
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Image")]
		[XmlElement]
		[Browsable(true)]
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
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "ParameterName")]
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
		[DefaultValue(false)]
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "MultiLine")]
		[XmlAttribute]
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
		[Browsable(true)]
		[DefaultValue(null)]
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Font")]
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
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Color")]
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
		[DefaultValue(null)]
		[XmlAttribute]
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
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "BackColor")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Transparent")]
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
		[XmlAttribute]
		[Browsable(false)]
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
		[DefaultValue(StringAlignment.Center)]
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Alignment")]
		[XmlAttribute]
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
		[DefaultValue(StringAlignment.Center)]
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "LineAlignment")]
		[XmlAttribute]
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
		[XmlAttribute]
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Left")]
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
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Top")]
		[DefaultValue(0f)]
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
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Width")]
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
		[DCDisplayName(typeof(DCFriedmanCurveLabel), "Height")]
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
		public DCFriedmanCurveLabel Clone()
		{
			return (DCFriedmanCurveLabel)MemberwiseClone();
		}
	}
}
