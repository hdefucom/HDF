using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       文本元素
	///       </summary>
	[ComVisible(false)]
	public class DomTextElement : DomElement
	{
		private int _StyleIndex = -1;

		private string _Text = null;

		[DefaultValue(-1)]
		[XmlAttribute]
		public int StyleIndex
		{
			get
			{
				return _StyleIndex;
			}
			set
			{
				_StyleIndex = value;
			}
		}

		[XmlElement]
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
	}
}
