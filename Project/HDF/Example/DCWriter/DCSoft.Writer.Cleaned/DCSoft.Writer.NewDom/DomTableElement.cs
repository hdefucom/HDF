using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.NewDom
{
	/// <summary>
	///       表格元素
	///       </summary>
	[ComVisible(false)]
	public class DomTableElement : DomElement
	{
		private float _LeftIndent = 0f;

		private bool _AllowUserDeleteRow = true;

		private bool _AllowUserInsertRow = true;

		private bool _AllowUserToResizeEvenInFormViewMode = false;

		private bool _AllowUserToResizeColumns = true;

		private bool _AllowUserToResizeRows = true;

		private bool _CompressOwnerLineSpacing = false;

		private bool _HoldWholeLine = true;

		private bool _PrintBothBorderWhenJumpPrint = false;

		private List<DomTableRowElement> _Rows = null;

		private List<DomTableColumnElement> _Columns = null;

		/// <summary>
		///       表格行数
		///       </summary>
		[XmlAttribute]
		public int NumOfRows
		{
			get
			{
				return (_Rows != null) ? _Rows.Count : 0;
			}
			set
			{
			}
		}

		/// <summary>
		///       表格的列数
		///       </summary>
		[XmlAttribute]
		public int NumOfColumns
		{
			get
			{
				return (_Columns != null) ? Columns.Count : 0;
			}
			set
			{
			}
		}

		/// <summary>
		///       左边缩进量
		///       </summary>
		[XmlAttribute]
		[DefaultValue(0f)]
		public float LeftIndent
		{
			get
			{
				return _LeftIndent;
			}
			set
			{
				_LeftIndent = value;
			}
		}

		/// <summary>
		///       允许用户删除表格行
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool AllowUserDeleteRow
		{
			get
			{
				return _AllowUserDeleteRow;
			}
			set
			{
				_AllowUserDeleteRow = value;
			}
		}

		/// <summary>
		///       允许用户新增表格行
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		public bool AllowUserInsertRow
		{
			get
			{
				return _AllowUserInsertRow;
			}
			set
			{
				_AllowUserInsertRow = value;
			}
		}

		/// <summary>
		///       即使在表单模式下用户仍然可以拖拽修改表格大小
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool AllowUserToResizeEvenInFormViewMode
		{
			get
			{
				return _AllowUserToResizeEvenInFormViewMode;
			}
			set
			{
				_AllowUserToResizeEvenInFormViewMode = value;
			}
		}

		/// <summary>
		///       是否允许用户鼠标拖拽操作改变表格列宽度
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		public bool AllowUserToResizeColumns
		{
			get
			{
				return _AllowUserToResizeColumns;
			}
			set
			{
				_AllowUserToResizeColumns = value;
			}
		}

		/// <summary>
		///       是否允许用户鼠标拖拽操作改变表格行高度
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		public bool AllowUserToResizeRows
		{
			get
			{
				return _AllowUserToResizeRows;
			}
			set
			{
				_AllowUserToResizeRows = value;
			}
		}

		/// <summary>
		///       压缩所在文档行的行间距
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool CompressOwnerLineSpacing
		{
			get
			{
				return _CompressOwnerLineSpacing;
			}
			set
			{
				_CompressOwnerLineSpacing = value;
			}
		}

		/// <summary>
		///       在排版时占据整个一行
		///       </summary>
		[DefaultValue(true)]
		[XmlAttribute]
		public bool HoldWholeLine
		{
			get
			{
				return _HoldWholeLine;
			}
			set
			{
				_HoldWholeLine = value;
			}
		}

		/// <summary>
		///       在续打的时候打印所有单元格边框
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool PrintBothBorderWhenJumpPrint
		{
			get
			{
				return _PrintBothBorderWhenJumpPrint;
			}
			set
			{
				_PrintBothBorderWhenJumpPrint = value;
			}
		}

		/// <summary>
		///       表格行集合
		///       </summary>
		[XmlArrayItem("Row", typeof(DomTableRowElement))]
		[DefaultValue(null)]
		public List<DomTableRowElement> Rows
		{
			get
			{
				return _Rows;
			}
			set
			{
				_Rows = value;
			}
		}

		/// <summary>
		///       表格列集合
		///       </summary>
		[DefaultValue(null)]
		[XmlArrayItem("Column", typeof(DomTableColumnElement))]
		public List<DomTableColumnElement> Columns
		{
			get
			{
				return _Columns;
			}
			set
			{
				_Columns = value;
			}
		}
	}
}
