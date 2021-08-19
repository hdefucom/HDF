using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       内容注释对象
	///       </summary>
	[ComVisible(false)]
	public class DomComment
	{
		private int _Index = 0;

		private bool _BindingUserTrack = false;

		private List<DomAttribute> _Attributes = null;

		private string _AuthorID = null;

		private string _Author = null;

		private string _CreationTime = null;

		private string _Text = null;

		private int _CreatorIndex = -1;

		private string _BackColor = null;

		private string _ForeColor = null;

		private string _BorderColor = null;

		/// <summary>
		///       编号
		///       </summary>
		[XmlAttribute]
		public int Index
		{
			get
			{
				return _Index;
			}
			set
			{
				_Index = value;
			}
		}

		/// <summary>
		///       绑定了用户痕迹
		///       </summary>
		[DefaultValue(false)]
		[XmlAttribute]
		public bool BindingUserTrack
		{
			get
			{
				return _BindingUserTrack;
			}
			set
			{
				_BindingUserTrack = value;
			}
		}

		/// <summary>
		///       附加属性列表
		///       </summary>
		[XmlArrayItem("Attribute", typeof(DomAttribute))]
		[DefaultValue(null)]
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

		/// <summary>
		///       创建者编号
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string AuthorID
		{
			get
			{
				return _AuthorID;
			}
			set
			{
				_AuthorID = value;
			}
		}

		/// <summary>
		///       创建者
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string Author
		{
			get
			{
				return _Author;
			}
			set
			{
				_Author = value;
			}
		}

		/// <summary>
		///       对象的创建时间
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string CreationTime
		{
			get
			{
				return _CreationTime;
			}
			set
			{
				_CreationTime = value;
			}
		}

		/// <summary>
		///       批注文本
		///       </summary>
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

		/// <summary>
		///       创建者编号
		///       </summary>
		[DefaultValue(-1)]
		[XmlAttribute]
		public int CreatorIndex
		{
			get
			{
				return _CreatorIndex;
			}
			set
			{
				_CreatorIndex = value;
			}
		}

		/// <summary>
		///       背景色
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string BackColor
		{
			get
			{
				return _BackColor;
			}
			set
			{
				_BackColor = value;
			}
		}

		/// <summary>
		///       文本颜色
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string ForeColor
		{
			get
			{
				return _ForeColor;
			}
			set
			{
				_ForeColor = value;
			}
		}

		/// <summary>
		///       边框色
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string BorderColor
		{
			get
			{
				return _BorderColor;
			}
			set
			{
				_BorderColor = value;
			}
		}
	}
}
