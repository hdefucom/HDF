using DCSoft.Writer.Dom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       表格行元素
	///       </summary>
	[ComVisible(false)]
	public class DomTableRowElement : DomElement
	{
		private TableRowCloneType _CloneType = TableRowCloneType.Default;

		private bool _HeaderStyle = false;

		private float _SpecifyHeight = 0f;

		private bool _ExpendForDataBinding = true;

		private bool _CanSplitByPageLine = true;

		private bool _AllowUserPressTabKeyToInsertRowDown = false;

		private DCBooleanValue _AllowUserToResizeRowHeight = DCBooleanValue.Inherit;

		private bool _PrintCellBorder = true;

		private bool _PrintCellBackground = true;

		private bool _NewPage = false;

		private List<DomTableCellElement> _Cells = null;

		/// <summary>
		///       复制方式
		///       </summary>
		[XmlAttribute]
		[DefaultValue(TableRowCloneType.Default)]
		public TableRowCloneType CloneType
		{
			get
			{
				return _CloneType;
			}
			set
			{
				_CloneType = (TableRowCloneType)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       标题行样式
		///       </summary>
		/// <remarks>
		///       在分页时，若导致分页的表格行的DataRow属性为false则不自动插入临时标题行
		///       </remarks>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool HeaderStyle
		{
			get
			{
				return _HeaderStyle;
			}
			set
			{
				_HeaderStyle = value;
			}
		}

		/// <summary>
		///       用户指定的高度
		///       </summary>
		/// <remarks>
		///       若等于0则表格行自动设置高度，
		///       若大于0则表格行高度自动设置高度而且高度不小于用户指定的高度，
		///       若小于0则固定设置表格行的高度为用户指定的高度。
		///       </remarks>
		[XmlAttribute]
		[DefaultValue(0f)]
		public float SpecifyHeight
		{
			get
			{
				return _SpecifyHeight;
			}
			set
			{
				_SpecifyHeight = value;
			}
		}

		/// <summary>
		///       由于数据源绑定而扩展的表格行
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool ExpendForDataBinding
		{
			get
			{
				return _ExpendForDataBinding;
			}
			set
			{
				_ExpendForDataBinding = value;
			}
		}

		/// <summary>
		///       能否被分页线分割，也就是是否允许被分配到两页上
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool CanSplitByPageLine
		{
			get
			{
				return _CanSplitByPageLine;
			}
			set
			{
				_CanSplitByPageLine = value;
			}
		}

		/// <summary>
		///       允许用户按下Tab键来向下插入表格行,即使表格行不是表格的最后一行。本属性值默认为false。
		///       如果表格的AllowUserInsertRow属性值为false，则不能插入表格行。
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool AllowUserPressTabKeyToInsertRowDown
		{
			get
			{
				return _AllowUserPressTabKeyToInsertRowDown;
			}
			set
			{
				_AllowUserPressTabKeyToInsertRowDown = value;
			}
		}

		/// <summary>
		///       是否允许用户鼠标拖拽操作改变表格行高度
		///       </summary>
		[DefaultValue(DCBooleanValue.Inherit)]
		[XmlAttribute]
		public DCBooleanValue AllowUserToResizeHeight
		{
			get
			{
				return _AllowUserToResizeRowHeight;
			}
			set
			{
				_AllowUserToResizeRowHeight = value;
			}
		}

		/// <summary>
		///       打印单元格边框线
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		public bool PrintCellBorder
		{
			get
			{
				return _PrintCellBorder;
			}
			set
			{
				_PrintCellBorder = value;
			}
		}

		/// <summary>
		///       打印单元格背景
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		public bool PrintCellBackground
		{
			get
			{
				return _PrintCellBackground;
			}
			set
			{
				_PrintCellBackground = value;
			}
		}

		/// <summary>
		///       强制分页
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool NewPage
		{
			get
			{
				return _NewPage;
			}
			set
			{
				_NewPage = value;
			}
		}

		/// <summary>
		///       单元格集合
		///       </summary>
		[XmlArrayItem("Cell", typeof(DomTableCellElement))]
		[DefaultValue(null)]
		public List<DomTableCellElement> Cells
		{
			get
			{
				return _Cells;
			}
			set
			{
				_Cells = value;
			}
		}
	}
}
