using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       单选框、复选框基础元素类型
	///       </summary>
	[ComVisible(false)]
	public abstract class DomCheckBoxElementBase : DomObjectElement
	{
		private CheckBoxVisualStyle _VisualStyle = CheckBoxVisualStyle.Default;

		private bool _Checked = false;

		private string _Caption = null;

		private bool _CheckAlignLeft = true;

		private bool _Multiline = false;

		private bool _PrintBoxOnlyChecked = false;

		private bool _Readonly = false;

		/// <summary>
		///       复选框视图样式
		///       </summary>
		[DefaultValue(CheckBoxVisualStyle.Default)]
		[XmlAttribute]
		public CheckBoxVisualStyle VisualStyle
		{
			get
			{
				return _VisualStyle;
			}
			set
			{
				_VisualStyle = value;
			}
		}

		[DefaultValue(false)]
		[XmlAttribute]
		public bool Checked
		{
			get
			{
				return _Checked;
			}
			set
			{
				_Checked = value;
			}
		}

		/// <summary>
		///       复选框后面跟着的文本
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string Caption
		{
			get
			{
				return _Caption;
			}
			set
			{
				_Caption = value;
			}
		}

		/// <summary>
		///       勾选框靠左侧对齐
		///       </summary>
		[XmlElement]
		[DefaultValue(true)]
		public bool CheckAlignLeft
		{
			get
			{
				return _CheckAlignLeft;
			}
			set
			{
				_CheckAlignLeft = value;
			}
		}

		/// <summary>
		///       多行文本
		///       </summary>
		[XmlElement]
		[DefaultValue(false)]
		public bool Multiline
		{
			get
			{
				return _Multiline;
			}
			set
			{
				_Multiline = value;
			}
		}

		/// <summary>
		///       只在勾选的时候打印勾选框。如果不勾选则不打印勾选框。默认false。
		///       </summary>
		[XmlElement]
		[DefaultValue(false)]
		public bool PrintBoxOnlyChecked
		{
			get
			{
				return _PrintBoxOnlyChecked;
			}
			set
			{
				_PrintBoxOnlyChecked = value;
			}
		}

		/// <summary>
		///       只读的
		///       </summary>
		[DefaultValue(false)]
		[XmlAttribute]
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
			}
		}

		public DomCheckBoxElementBase()
		{
		}
	}
}
