using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Printing
{
	/// <summary>
	///       网格线信息对象
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ClassInterface(ClassInterfaceType.None)]
	[XmlType]
	
	[Guid("76B93F60-DB26-4EF0-81EB-E236A32A1EC9")]
	[ComDefaultInterface(typeof(IDCGridLineInfo))]
	[Editor(typeof(DCGridLineInfoUIEditor), typeof(UITypeEditor))]
	public class DCGridLineInfo : IDCStringSerializable, IDCGridLineInfo
	{
		private bool bool_0 = false;

		private bool bool_1 = true;

		private Color color_0 = Color.Black;

		private float float_0 = 1f;

		private int int_0 = 0;

		private float float_1 = 0f;

		private DashStyle dashStyle_0 = DashStyle.Solid;

		private bool bool_2 = true;

		private float float_2 = 0f;

		/// <summary>
		///       对象可见
		///       </summary>
		[DefaultValue(false)]
		public bool Visible
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
		///       对齐到网格线
		///       </summary>
		[DefaultValue(true)]
		public bool AlignToGridLine
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
		///       网格线颜色
		///       </summary>
		[XmlIgnore]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Black")]
		public Color Color
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
		///       颜色值
		///       </summary>
		[XmlElement]
		[EditorBrowsable(EditorBrowsableState.Never)]
		
		[DefaultValue(null)]
		[Browsable(false)]
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
		///       网格线宽度
		///       </summary>
		[DefaultValue(1f)]
		[XmlElement]
		public float LineWidth
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
		///       每页网格线行数。该属性仅对文档正文对象有效
		///       </summary>
		[XmlElement]
		[DefaultValue(0)]
		public int GridNumInOnePage
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
		///       厘米为单位的网格线跨度
		///       </summary>
		[DefaultValue(0f)]
		[XmlElement]
		public float GridSpanInCM
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
		///       线条样式
		///       </summary>
		[DefaultValue(DashStyle.Solid)]
		[XmlElement]
		public DashStyle LineStyle
		{
			get
			{
				return dashStyle_0;
			}
			set
			{
				dashStyle_0 = value;
			}
		}

		/// <summary>
		///       打印
		///       </summary>
		[DefaultValue(true)]
		public bool Printable
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
		///       运行时使用的网格线间距。DCWriter内部使用。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		
		[XmlIgnore]
		public float RuntimeGridSpan => float_2;

		
		public void method_0(float float_3, GraphicsUnit graphicsUnit_0, float float_4)
		{
			if (Visible)
			{
				if (GridNumInOnePage > 0 && float_3 > 0f)
				{
					float_2 = float_4 * (float_3 - 2f) / (float)GridNumInOnePage;
				}
				else
				{
					float_2 = float_4 * GraphicsUnitConvert.ConvertFromCM(GridSpanInCM, graphicsUnit_0);
				}
			}
		}

		
		public float method_1(float float_3)
		{
			if (Visible && AlignToGridLine && RuntimeGridSpan > 0f)
			{
				float num = (float)Math.Ceiling(float_3 / RuntimeGridSpan);
				return num * RuntimeGridSpan;
			}
			return float_3;
		}

		public float method_2(float float_3)
		{
			if (Visible && AlignToGridLine && RuntimeGridSpan > 0f)
			{
				float num = (float)Math.Ceiling(float_3 / RuntimeGridSpan);
				return num * RuntimeGridSpan;
			}
			return float_3;
		}

		
		public Pen method_3()
		{
			Pen pen = new Pen(Color, LineWidth);
			pen.DashStyle = LineStyle;
			return pen;
		}

		
		public XPenStyle method_4()
		{
			return new XPenStyle(Color, LineWidth, LineStyle);
		}

		
		public DCGridLineInfo method_5()
		{
			return (DCGridLineInfo)MemberwiseClone();
		}

		
		public override string ToString()
		{
			return DCWriteString();
		}

		
		public string DCWriteString()
		{
			return ValueTypeHelper.GetPropertiesAttributeString(this, detectDefaultValue: true);
		}

		
		public void DCReadString(string text)
		{
			ValueTypeHelper.SetPropertiesAttributeString(this, text);
		}
	}
}
