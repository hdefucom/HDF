using DCSoft.Common;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时刻信息对象
	///       </summary>
	[DocumentComment]
	public class TickInfo
	{
		private float _Value = 0f;

		private string _Text = null;

		private Color _Color = Color.Black;

		/// <summary>
		///       数值
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0f)]
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
		///       文本
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
		///       文本颜色
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
		///       文本颜色值
		///       </summary>
		[XmlAttribute]
		[Browsable(false)]
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
		///       初始化对象
		///       </summary>
		public TickInfo()
		{
		}

		internal TickInfo(int int_0, string string_0, Color color_0)
		{
			_Value = int_0;
			_Text = string_0;
			_Color = color_0;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public TickInfo Clone()
		{
			return (TickInfo)MemberwiseClone();
		}

		/// <summary>
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return _Value + " " + _Text + " " + ColorTranslator.ToHtml(Color);
		}
	}
}
