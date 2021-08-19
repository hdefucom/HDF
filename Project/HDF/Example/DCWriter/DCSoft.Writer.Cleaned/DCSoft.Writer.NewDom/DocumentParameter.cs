using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       文档参数
	///       </summary>
	[ComVisible(false)]
	public class DocumentParameter
	{
		private string _Name = null;

		private string _Value = null;

		/// <summary>
		///       参数名称
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
		[XmlText]
		[DefaultValue(null)]
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
