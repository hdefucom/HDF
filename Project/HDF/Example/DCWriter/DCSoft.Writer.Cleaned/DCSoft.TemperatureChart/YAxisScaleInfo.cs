using DCSoft.Common;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       数据标尺刻度信息
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[Guid("A4322AC8-1AEF-40F4-B9BB-1101FA18FFEF")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IYAxisScaleInfo))]
	[DCPublishAPI]
	public class YAxisScaleInfo : IYAxisScaleInfo
	{
		private string _Text = null;

		private float _Value = 0f;

		private float _ScaleRate = 0f;

		private Color _Color = Color.Transparent;

		/// <summary>
		///       刻度文本
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
		///       刻度数值
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0)]
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
		///       展示的刻度比例,从0.0到1.0之间
		///       </summary>
		[DefaultValue(0f)]
		[XmlAttribute]
		public float ScaleRate
		{
			get
			{
				return _ScaleRate;
			}
			set
			{
				_ScaleRate = value;
			}
		}

		/// <summary>
		///       数据点符号颜色
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
		[Browsable(false)]
		[XmlAttribute]
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
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public YAxisScaleInfo Clone()
		{
			return (YAxisScaleInfo)MemberwiseClone();
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return Value + "#" + ScaleRate;
		}
	}
}
