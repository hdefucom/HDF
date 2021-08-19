using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       空格文本元素
	///       </summary>
	[ComVisible(false)]
	public class DomWhiteSpacesElement : DomElement
	{
		private int _Length = 0;

		/// <summary>
		///       长度
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0)]
		public int Length
		{
			get
			{
				return _Length;
			}
			set
			{
				_Length = value;
			}
		}
	}
}
