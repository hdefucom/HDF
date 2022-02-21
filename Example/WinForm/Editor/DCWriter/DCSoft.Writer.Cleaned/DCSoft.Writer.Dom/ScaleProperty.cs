using DCSoft.Common;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       数据标尺刻度信息
	///       </summary>
	/// <remarks>编制 宋建明</remarks>
	[XmlType("ScaleProperty")]
	[DocumentComment]
	
	public class ScaleProperty
	{
		private float _Value = 0f;

		private float _ScaleRate = 0f;

		/// <summary>
		///       刻度数值
		///       </summary>
		[DefaultValue(0)]
		[XmlAttribute]
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
		///       返回表示对象数据的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return Value + "#" + ScaleRate;
		}
	}
}
