using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       属性值元素
	///       </summary>
	[ComVisible(false)]
	public class DomAttribute
	{
		private string _Name = null;

		private string _Value = null;

		/// <summary>
		///       名称
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       数值
		///       </summary>
		[DefaultValue(null)]
		[XmlText]
		public string Value
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
	}
}
