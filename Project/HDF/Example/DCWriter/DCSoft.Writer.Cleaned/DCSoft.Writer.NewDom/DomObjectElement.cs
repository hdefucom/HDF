using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	[ComVisible(false)]
	public class DomObjectElement : DomElement
	{
		private string _Name = null;

		private string _ToolTip = null;

		private int _StyleIndex = -1;

		private bool _Deleteable = true;

		private bool _Enabled = true;

		private bool _Visible = true;

		private float _Height = 0f;

		private float _Width = 0f;

		private List<DomAttribute> _Attributes = null;

		private string _JavaScriptForClick = null;

		private string _JavaScriptForDoubleClick = null;

		private int _UserFlags = 0;

		private PropertyExpressionInfoList _PropertyExpressions = null;

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
		///       提示文本
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string ToolTip
		{
			get
			{
				return _ToolTip;
			}
			set
			{
				_ToolTip = value;
			}
		}

		/// <summary>
		///       样式编号
		///       </summary>
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

		[XmlAttribute]
		[DefaultValue(true)]
		public bool Deleteable
		{
			get
			{
				return _Deleteable;
			}
			set
			{
				_Deleteable = value;
			}
		}

		/// <summary>
		///       对象是否可用
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		/// <summary>
		///       对象是否可见
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
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
		///       高度
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0f)]
		public virtual float Height
		{
			get
			{
				return _Height;
			}
			set
			{
				_Height = value;
			}
		}

		/// <summary>
		///       宽度
		///       </summary>
		[DefaultValue(0f)]
		[XmlAttribute]
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

		[DefaultValue(null)]
		[XmlElement]
		public string JavaScriptForClick
		{
			get
			{
				return _JavaScriptForClick;
			}
			set
			{
				_JavaScriptForClick = value;
			}
		}

		[XmlElement]
		[DefaultValue(null)]
		public string JavaScriptForDoubleClick
		{
			get
			{
				return _JavaScriptForDoubleClick;
			}
			set
			{
				_JavaScriptForDoubleClick = value;
			}
		}

		[DefaultValue(0)]
		[XmlAttribute]
		public int UserFlags
		{
			get
			{
				return _UserFlags;
			}
			set
			{
				_UserFlags = value;
			}
		}

		[XmlArrayItem("Item", typeof(PropertyExpressionInfo))]
		[DefaultValue(null)]
		public PropertyExpressionInfoList PropertyExpressions
		{
			get
			{
				return _PropertyExpressions;
			}
			set
			{
				_PropertyExpressions = value;
			}
		}

		public virtual void BuildDom(XTextElement parentElement)
		{
		}
	}
}
