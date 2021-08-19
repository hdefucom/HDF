using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       表格列元素
	///       </summary>
	[ComVisible(false)]
	public class DomTableColumnElement : DomElement
	{
		private bool _Visible = true;

		private float _Width = 0f;

		private List<DomAttribute> _Attributes = null;

		/// <summary>
		///        元素是否可见
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		[Browsable(true)]
		public bool Visible
		{
			get
			{
				return _Visible;
			}
			set
			{
				_Visible = value;
			}
		}

		/// <summary>
		///       宽度
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0f)]
		public virtual float Width
		{
			get
			{
				return _Width;
			}
			set
			{
				_Width = value;
			}
		}

		/// <summary>
		///       附加属性列表
		///       </summary>
		[DefaultValue(null)]
		[XmlArrayItem("Attribute", typeof(DomAttribute))]
		public List<DomAttribute> Attributes
		{
			get
			{
				return _Attributes;
			}
			set
			{
				_Attributes = value;
			}
		}
	}
}
