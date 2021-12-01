using DCSoft.Common;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       标尺刻度对象
	///       </summary>
	[DocumentComment]
	public class RuleScaleItem
	{
		private string _Text = null;

		private float _Value = 0f;

		private float _ScaleRate = -1f;

		private Color _Color = Color.Black;

		/// <summary>
		///       文本
		///       </summary>
		[XmlAttribute]
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
		///       标尺比率，从0到1之间的浮点数。
		///       </summary>
		[XmlAttribute]
		[DefaultValue(-1f)]
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
		///       文本颜色
		///       </summary>
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
	}
}
