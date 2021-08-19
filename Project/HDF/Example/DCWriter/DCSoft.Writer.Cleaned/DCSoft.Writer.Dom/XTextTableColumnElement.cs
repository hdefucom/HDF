using DCSoft.Common;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom.Undo;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表格列元素
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextTableColumnElement))]
	[DocumentComment]
	[DCPublishAPI]
	[ComClass("00012345-6789-ABCD-EF01-234567890012", "03C90FA7-7002-4333-883F-D1E95C100A32")]
	[XmlType("XTextTableColumn")]
	[DebuggerDisplay("Column {Index}:{Width}")]
	[ComVisible(true)]
	[Guid("00012345-6789-ABCD-EF01-234567890012")]
	public sealed class XTextTableColumnElement : XTextElement, IXTextTableColumnElement
	{
		internal const string string_3 = "00012345-6789-ABCD-EF01-234567890012";

		internal const string string_4 = "03C90FA7-7002-4333-883F-D1E95C100A32";

		private bool bool_5 = true;

		private XDataBinding xdataBinding_0 = null;

		[NonSerialized]
		private bool bool_6 = false;

		private XAttributeList xattributeList_0 = null;

		[NonSerialized]
		internal XTextElementList xtextElementList_0 = null;

		public override string DomDisplayName => "Col:" + Index;

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "col";

		/// <summary>
		///       属性无效
		///       </summary>
		private new string FormulaValue
		{
			get
			{
				return base.FormulaValue;
			}
			set
			{
				base.FormulaValue = value;
			}
		}

		/// <summary>
		///        元素是否可见
		///       </summary>
		[MemberExpressionable(MemberEffectLevel.ContentElementLayout)]
		[DCPublishAPI]
		[XmlElement]
		[DefaultValue(true)]
		[Browsable(true)]
		public override bool Visible
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       内容绑定对象
		///       </summary>
		[DefaultValue(null)]
		[HtmlAttribute]
		public XDataBinding ValueBinding
		{
			get
			{
				if (xdataBinding_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					xdataBinding_0 = new XDataBinding();
				}
				return xdataBinding_0;
			}
			set
			{
				xdataBinding_0 = value;
			}
		}

		/// <summary>
		///       元素内容是否改变
		///       </summary>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		[ComVisible(true)]
		public override bool Modified
		{
			get
			{
				return bool_6;
			}
			set
			{
				bool_6 = value;
			}
		}

		/// <summary>
		///       用户自定义属性列表
		///       </summary>
		[Browsable(true)]
		[DCPublishAPI]
		[HtmlAttribute]
		[DefaultValue(null)]
		[XmlArrayItem("Attribute", typeof(XAttribute))]
		public override XAttributeList Attributes
		{
			get
			{
				if (xattributeList_0 == null && DocumentBehaviorOptions.StaticAutoCreateInstanceInProperty)
				{
					xattributeList_0 = new XAttributeList();
				}
				return xattributeList_0;
			}
			set
			{
				xattributeList_0 = value;
			}
		}

		/// <summary>
		///       属性可见可序列化
		///       </summary>
		[Browsable(true)]
		[XmlElement]
		[DCPublishAPI]
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		public override float Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
			}
		}

		/// <summary>
		///       宽度是否为零
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public bool ZeroWidth => (double)Math.Abs(Width) < 0.01;

		/// <summary>
		///       作废
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("表格行的高度属性无效")]
		[Browsable(false)]
		[XmlIgnore]
		public override float Height
		{
			get
			{
				if (OwnerTable == null)
				{
					return 0f;
				}
				return OwnerTable.Height;
			}
			set
			{
			}
		}

		/// <summary>
		///       列号
		///       </summary>
		[Browsable(false)]
		public int Index => ((XTextTableElement)Parent)?.Columns.IndexOf(this) ?? (-1);

		/// <summary>
		///       本表格列所属的表格对象
		///       </summary>
		[Browsable(false)]
		public new XTextTableElement OwnerTable => (XTextTableElement)Parent;

		/// <summary>
		///       表格列所属的单元格对象列表
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		[DCPublishAPI]
		public XTextElementList Cells
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				XTextTableElement ownerTable = OwnerTable;
				if (ownerTable != null)
				{
					int num = ownerTable.Columns.IndexOf(this);
					if (num >= 0)
					{
						foreach (XTextTableRowElement row in ownerTable.Rows)
						{
							xTextElementList.AddRaw(row.Cells[num]);
						}
					}
				}
				return xTextElementList;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextTableColumnElement()
		{
		}

		public override XTextElement Clone(bool Deeply)
		{
			XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)base.Clone(Deeply);
			if (xattributeList_0 != null)
			{
				xTextTableColumnElement.xattributeList_0 = xattributeList_0.Clone();
			}
			if (xdataBinding_0 != null)
			{
				xTextTableColumnElement.xdataBinding_0 = xdataBinding_0.Clone();
			}
			xTextTableColumnElement.xtextElementList_0 = null;
			return xTextTableColumnElement;
		}

		/// <summary>
		///       获得指定名称的属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>获得的属性值</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public override string GetAttribute(string name)
		{
			if (xattributeList_0 != null)
			{
				return xattributeList_0.GetValue(name);
			}
			return null;
		}

		/// <summary>
		///       设置属性值
		///       </summary>
		/// <param name="name">属性名</param>
		/// <param name="Value">属性值</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		[ComVisible(true)]
		public override bool SetAttribute(string name, string Value)
		{
			if (xattributeList_0 == null)
			{
				xattributeList_0 = new XAttributeList();
			}
			xattributeList_0.SetValue(name, Value);
			return true;
		}

		/// <summary>
		///       判断是否存在指定名称的属性
		///       </summary>
		/// <param name="name">属性名</param>
		/// <returns>是否存在</returns>
		[ComVisible(true)]
		[DCPublishAPI]
		public override bool HasAttribute(string name)
		{
			if (xattributeList_0 != null)
			{
				return xattributeList_0.ContainsByName(name);
			}
			return false;
		}

		/// <summary>
		///       判断元素是否挂在指定文档的DOM结构中
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="checkLogicDelete">检查逻辑删除标记</param>
		/// <returns>是否挂在DOM结构中</returns>
		public override bool BelongToDocumentDom(XTextDocument document, bool checkLogicDelete)
		{
			if (Parent == null)
			{
				return false;
			}
			return Parent.BelongToDocumentDom(document, checkLogicDelete);
		}

		/// <summary>
		///       选择整个表格列
		///       </summary>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public override bool Select()
		{
			XTextTableElement ownerTable = OwnerTable;
			if (ownerTable == null || ownerTable.Rows.Count == 0)
			{
				return false;
			}
			int num = ownerTable.Columns.IndexOf(this);
			if (num >= 0)
			{
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (documentContentElement == null)
				{
					return false;
				}
				if (OwnerDocument.CurrentContentElement != documentContentElement)
				{
					documentContentElement.Focus();
				}
				XTextElementList cells = Cells;
				documentContentElement.method_66((XTextTableCellElement)cells.FirstElement, (XTextTableCellElement)cells.LastElement);
				return true;
			}
			return false;
		}

		/// <summary>
		///       获得输入焦点
		///       </summary>
		[DCPublishAPI]
		public override void Focus()
		{
			XTextTableElement ownerTable = OwnerTable;
			if (ownerTable == null || ownerTable.Rows.Count == 0)
			{
				return;
			}
			int num = ownerTable.Columns.IndexOf(this);
			if (num < 0)
			{
				return;
			}
			XTextTableCellElement xTextTableCellElement = ownerTable.GetCell(0, num, throwException: false);
			if (xTextTableCellElement != null)
			{
				if (xTextTableCellElement.OverrideCell != null)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				xTextTableCellElement.Focus();
			}
		}

		/// <summary>
		///       删除表格列
		///       </summary>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		[DCPublishAPI]
		public bool EditorDelete(bool logUndo)
		{
			XTextTableElement ownerTable = OwnerTable;
			return ownerTable?.method_48(ownerTable.Columns.IndexOf(this), 1, logUndo, null, OwnerDocument.Options.EditOptions.KeepTableWidthWhenInsertDeleteColumn, null) ?? false;
		}

		/// <summary>
		///       创建新的文档对象，使其包含本文档元素的复制品
		///       </summary>
		/// <param name="includeThis">是否包含本文档原始对象,对表格列该参数无作用</param>
		/// <returns>创建的文档对象</returns>
		[DCPublishAPI]
		public override XTextDocument CreateContentDocument(bool includeThis)
		{
			XTextTableElement ownerTable = OwnerTable;
			if (ownerTable == null)
			{
				return null;
			}
			int index = ownerTable.Columns.IndexOf(this);
			XTextElementList xTextElementList = new XTextElementList();
			foreach (XTextTableRowElement row in ownerTable.Rows)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)row.Cells[index];
				if (!xTextTableCellElement.IsOverrided)
				{
					xTextElementList.Add(xTextTableCellElement);
				}
			}
			if (xTextElementList.Count > 0)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)ownerTable.Clone(Deeply: false);
				xTextTableElement.Rows = new XTextElementList();
				xTextTableElement.Columns = new XTextElementList();
				xTextTableElement.Columns.Add(Clone(Deeply: true));
				foreach (XTextTableCellElement item in xTextElementList)
				{
					XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)item.OwnerRow.Clone(Deeply: false);
					xTextTableRowElement2.Cells = new XTextElementList();
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)item.Clone(Deeply: true);
					xTextTableCellElement2.method_60(1);
					xTextTableCellElement2.method_61(1);
					xTextTableRowElement2.Cells.Add(xTextTableCellElement2);
					xTextTableElement.Rows.Add(xTextTableRowElement2);
				}
				XTextDocument result = xTextTableElement.CreateContentDocument(includeThis: true);
				xTextTableElement.Dispose();
				return result;
			}
			return null;
		}

		internal void method_13(float float_5, bool bool_7, bool bool_8)
		{
			float minTableColumnWidth = OwnerDocument.Options.ViewOptions.MinTableColumnWidth;
			if (float_5 < minTableColumnWidth)
			{
				float_5 = minTableColumnWidth;
			}
			XTextTableElement ownerTable = OwnerTable;
			XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)ownerTable.Columns.GetNextElement(this);
			float num = Width;
			if (bool_8 && xTextTableColumnElement != null)
			{
				num = Width + xTextTableColumnElement.Width;
				if (num - float_5 < minTableColumnWidth)
				{
					float_5 = num - minTableColumnWidth;
				}
			}
			if (Width != float_5)
			{
				float height = ownerTable.Height;
				ownerTable.InvalidateView();
				float width = Width;
				Width = float_5;
				Modified = true;
				if (bool_8 && xTextTableColumnElement != null)
				{
					xTextTableColumnElement.Width = num - float_5;
				}
				if (bool_7 && OwnerDocument.BeginLogUndo())
				{
					XTextUndoTableColumnWidth ginterface1_ = new XTextUndoTableColumnWidth(this, width, Width, bool_8);
					OwnerDocument.UndoList.method_14(ginterface1_);
					OwnerDocument.EndLogUndo();
				}
				OwnerDocument.Modified = true;
				ownerTable.ExecuteLayout();
				ownerTable.InvalidateView();
				if (ownerTable.Height != height)
				{
					ownerTable.method_41(bool_26: true);
				}
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.UpdateTextCaretWithoutScroll();
				}
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			if (xattributeList_0 != null)
			{
				xattributeList_0.Clear();
				xattributeList_0 = null;
			}
			xdataBinding_0 = null;
		}
	}
}
