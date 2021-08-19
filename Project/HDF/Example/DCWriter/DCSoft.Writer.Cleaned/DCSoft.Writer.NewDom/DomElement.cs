using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	[ComVisible(false)]
	public abstract class DomElement
	{
		private string _ID = null;

		private string _Tag = null;

		/// <summary>
		///       元素编号
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		/// <summary>
		///       用户扩展数据
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		public string Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}

		public DomElement()
		{
		}
	}
}
