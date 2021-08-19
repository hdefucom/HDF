using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       画笔样式信息对象,本对象可以参与XML序列化和反序列化
	///       </summary>
	[Serializable]
	[Editor(typeof(GClass531), typeof(UITypeEditor))]
	[ClassInterface(ClassInterfaceType.None)]
	[TypeConverter(typeof(GClass532))]
	[ToolboxItem(false)]
	[Guid("00012345-6789-ABCD-EF01-23456789009A")]
	[ComDefaultInterface(typeof(IXPenStyle))]
	[ComVisible(true)]
	public class XPenStyle : ICloneable, IComponent, IXPenStyle
	{
		private Color intColor = Color.Black;

		private float fWidth = 1f;

		private DashStyle intDashStyle = DashStyle.Solid;

		private DashCap intDashCap = DashCap.Flat;

		private LineJoin intLineJoin = LineJoin.Bevel;

		private LineCap intStartCap = LineCap.Flat;

		private LineCap intEndCap = LineCap.Flat;

		private float _MiterLimit = 10f;

		private PenAlignment _Alignment = PenAlignment.Center;

		private static Dictionary<string, Pen> _Buffer = new Dictionary<string, Pen>();

		[NonSerialized]
		private Pen _Value = null;

		[NonSerialized]
		private ISite mySite = null;

		/// <summary>
		///       画笔颜色
		///       </summary>
		[Category("Appearance")]
		[XmlIgnore]
		[DefaultValue(typeof(Color), "Black")]
		public Color Color
		{
			get
			{
				return intColor;
			}
			set
			{
				intColor = value;
				_Value = null;
			}
		}

		/// <summary>
		///       画笔颜色文本值
		///       </summary>
		[XmlElement("Color")]
		[Browsable(false)]
		[DefaultValue("Black")]
		public string ColorString
		{
			get
			{
				return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(intColor);
			}
			set
			{
				intColor = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(value);
				_Value = null;
			}
		}

		/// <summary>
		///       线条宽度
		///       </summary>
		[DefaultValue(1f)]
		[Category("Appearance")]
		public float Width
		{
			get
			{
				return fWidth;
			}
			set
			{
				fWidth = value;
				_Value = null;
			}
		}

		/// <summary>
		///       线条虚线样式
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(DashStyle.Solid)]
		[Editor("DCSoft.Editor.DashStyleEditor", typeof(UITypeEditor))]
		public DashStyle DashStyle
		{
			get
			{
				return intDashStyle;
			}
			set
			{
				if (value != DashStyle.Custom)
				{
					intDashStyle = value;
					_Value = null;
				}
			}
		}

		/// <summary>
		///       虚线帽样式
		///       </summary>
		[Category("Appearance")]
		[Editor("DCSoft.Editor.DashCapEditor", typeof(UITypeEditor))]
		[DefaultValue(DashCap.Flat)]
		public DashCap DashCap
		{
			get
			{
				return intDashCap;
			}
			set
			{
				intDashCap = value;
				_Value = null;
			}
		}

		/// <summary>
		///       线段连接处样式
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(LineJoin.Bevel)]
		public LineJoin LineJoin
		{
			get
			{
				return intLineJoin;
			}
			set
			{
				intLineJoin = value;
				_Value = null;
			}
		}

		/// <summary>
		///       线段起点箭头样式
		///       </summary>
		[DefaultValue(LineCap.Flat)]
		[Category("Appearance")]
		[Editor("DCSoft.Editor.LineCapEditor", typeof(UITypeEditor))]
		public LineCap StartCap
		{
			get
			{
				return intStartCap;
			}
			set
			{
				if (value != LineCap.Custom)
				{
					intStartCap = value;
					_Value = null;
				}
			}
		}

		/// <summary>
		///       线段终点箭头样式
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(LineCap.Flat)]
		[Editor("DCSoft.Editor.LineCapEditor", typeof(UITypeEditor))]
		public LineCap EndCap
		{
			get
			{
				return intEndCap;
			}
			set
			{
				if (value != LineCap.Custom)
				{
					intEndCap = value;
					_Value = null;
				}
			}
		}

		/// <summary>
		///       参数
		///       </summary>
		[DefaultValue(10f)]
		public float MiterLimit
		{
			get
			{
				return _MiterLimit;
			}
			set
			{
				if (_MiterLimit != value)
				{
					_MiterLimit = value;
					_Value = null;
				}
			}
		}

		/// <summary>
		///       对齐方式
		///       </summary>
		[DefaultValue(PenAlignment.Center)]
		public PenAlignment Alignment
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
		///       画笔对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public Pen Value
		{
			get
			{
				int num = 19;
				if (_Value == null)
				{
					string key = string.Concat(Color.ToArgb().ToString(), " ", Width, " ", DashCap, " ", DashStyle, " ", StartCap, " ", EndCap, " ", MiterLimit, " ", Alignment);
					if (_Buffer.ContainsKey(key))
					{
						_Value = _Buffer[key];
					}
					else
					{
						if (_Buffer.Count > 100)
						{
							foreach (Pen value2 in _Buffer.Values)
							{
								value2.Dispose();
							}
							_Buffer.Clear();
						}
						Pen value = CreatePen();
						_Buffer[key] = value;
						_Value = value;
					}
				}
				return _Value;
			}
		}

		/// <summary>
		///       对象站点
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ISite Site
		{
			get
			{
				return mySite;
			}
			set
			{
				mySite = value;
			}
		}

		/// <summary>
		///       对象销毁事件
		///       </summary>
		[field: NonSerialized]
		public event EventHandler Disposed = null;

		/// <summary>
		///       初始化对象
		///       </summary>
		public XPenStyle()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="color">颜色</param>
		public XPenStyle(Color color)
		{
			intColor = color;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="color">颜色</param>
		/// <param name="width">线条宽度</param>
		public XPenStyle(Color color, float width)
		{
			intColor = color;
			fWidth = width;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="color">颜色</param>
		/// <param name="width">线条宽度</param>
		/// <param name="dashStyle">虚线样式</param>
		public XPenStyle(Color color, float width, DashStyle dashStyle)
		{
			intColor = color;
			fWidth = width;
			intDashStyle = dashStyle;
		}

		/// <summary>
		///       根据设置创建画笔对象
		///       </summary>
		/// <returns>创建的画笔对象</returns>
		public Pen CreatePen()
		{
			Pen pen = new Pen(Color, Width);
			pen.DashStyle = DashStyle;
			pen.DashCap = DashCap;
			pen.LineJoin = LineJoin;
			pen.StartCap = StartCap;
			pen.EndCap = EndCap;
			pen.MiterLimit = MiterLimit;
			pen.Alignment = Alignment;
			return pen;
		}

		object ICloneable.Clone()
		{
			return (XPenStyle)MemberwiseClone();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public XPenStyle Clone()
		{
			return (XPenStyle)((ICloneable)this).Clone();
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			int num = 19;
			new ColorConverter();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(intDashStyle.ToString());
			stringBuilder.Append(" " + ColorTranslator.ToHtml(intColor));
			stringBuilder.Append(" " + fWidth);
			if (MiterLimit != 10f)
			{
				stringBuilder.Append(" MiterLimit:" + MiterLimit);
			}
			if (Alignment != 0)
			{
				stringBuilder.Append(" " + Alignment);
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			if (this.Disposed != null)
			{
				this.Disposed(this, new EventArgs());
			}
		}
	}
}
