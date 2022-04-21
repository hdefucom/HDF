using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///        网格线样式
	///        </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[Guid("C934F62D-4CFE-46C7-82AB-DD1E385219C5")]
	[ComVisible(true)]
	
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IGridLineInfo))]
	public class GridLineInfo : ICloneable, IGridLineInfo
	{
		private bool _Visible = false;

		private Color _Color = Color.Black;

		private static TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof(Color));

		private float _Step = 0f;

		private int _LineWidth = 1;

		private DashStyle _DashStyle = DashStyle.Solid;

		/// <summary>
		///       是否显示网格线
		///       </summary>
		[DefaultValue(false)]
		public bool Visible
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
		///       网格线颜色
		///       </summary>
		[DefaultValue(typeof(Color), "Black")]
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
		///       颜色值
		///       </summary>
		[DefaultValue("Black")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[XmlElement]
		public string ColorValue
		{
			get
			{
				return typeConverter_0.ConvertToString(Color);
			}
			set
			{
				_Color = (Color)typeConverter_0.ConvertFromString(value);
			}
		}

		/// <summary>
		///       网格线步长
		///       </summary>
		[DefaultValue(0f)]
		public float Step
		{
			get
			{
				return _Step;
			}
			set
			{
				_Step = value;
			}
		}

		/// <summary>
		///       线条宽度
		///       </summary>
		[DefaultValue(1)]
		public int LineWidth
		{
			get
			{
				return _LineWidth;
			}
			set
			{
				_LineWidth = value;
			}
		}

		/// <summary>
		///       线条样式
		///       </summary>
		[DefaultValue(DashStyle.Solid)]
		public DashStyle DashStyle
		{
			get
			{
				return _DashStyle;
			}
			set
			{
				_DashStyle = value;
			}
		}

		/// <summary>
		///       运行时是否显示图形
		///       </summary>
		[Browsable(false)]
		
		public bool RuntimeVisible
		{
			get
			{
				if (!Visible)
				{
					return false;
				}
				if (Color.A == 0)
				{
					return false;
				}
				if (LineWidth <= 0)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///       根据对象设置创建画笔对象
		///       </summary>
		/// <returns>创建的画笔对象</returns>
		
		public Pen CreatePen()
		{
			Pen pen = new Pen(Color, LineWidth);
			pen.DashStyle = DashStyle;
			return pen;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public GridLineInfo Clone()
		{
			return (GridLineInfo)MemberwiseClone();
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
