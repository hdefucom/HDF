using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Drawing
{
	/// <summary>
	///       颜色值的封装
	///       </summary>
	/// <remarks>
	///       Color值不能参与XML序列化，本类型就是Color类型的一个封装，使得颜色值能进行XML序列化
	///       编写 袁永福</remarks>
	[Editor(typeof(GClass524), typeof(UITypeEditor))]
	[ComVisible(false)]
	[TypeConverter(typeof(GClass523))]
	public class XColorValue : ICloneable
	{
		private Color _Value = Color.Empty;

		private static TypeConverter converter = TypeDescriptor.GetConverter(typeof(Color));

		/// <summary>
		///       颜色值
		///       </summary>
		[XmlIgnore]
		public Color Value
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
		///       颜色值的字符串表达形式
		///       </summary>
		[Browsable(false)]
		[XmlText]
		public string StringValue
		{
			get
			{
				return converter.ConvertToString(_Value);
			}
			set
			{
				if (value == null || value.Length == 0)
				{
					_Value = Color.Empty;
				}
				else
				{
					_Value = (Color)converter.ConvertFromString(value);
				}
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public XColorValue()
		{
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="c">颜色值</param>
		public XColorValue(Color color_0)
		{
			_Value = color_0;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="v">表示颜色的字符串</param>
		public XColorValue(string string_0)
		{
			StringValue = string_0;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public XColorValue Clone()
		{
			return (XColorValue)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			XColorValue xColorValue = new XColorValue();
			xColorValue._Value = _Value;
			return xColorValue;
		}
	}
}
