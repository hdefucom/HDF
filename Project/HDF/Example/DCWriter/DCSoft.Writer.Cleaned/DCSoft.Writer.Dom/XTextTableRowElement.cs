using DCSoft.Common;
using DCSoft.Writer.Dom.Undo;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表格行元素
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[DCPublishAPI]
	[XmlType("XTextTableRow")]
	[ComDefaultInterface(typeof(IXTextTableRowElement))]
	[ComClass("00012345-6789-ABCD-EF01-234567890014", "CBD69042-B2BA-38CB-9480-49D68053C72D")]
	[ComVisible(true)]
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("00012345-6789-ABCD-EF01-234567890014")]
	public sealed class XTextTableRowElement : XTextContainerElement, IXTextTableRowElement
	{
		internal const string string_14 = "00012345-6789-ABCD-EF01-234567890014";

		internal const string string_15 = "CBD69042-B2BA-38CB-9480-49D68053C72D";

		internal int int_10 = -1;

		private int int_11 = 1;

		private int int_12 = 1;

		private bool bool_17 = false;

		private bool bool_18 = false;

		private bool bool_19 = false;

		private bool bool_20 = true;

		private bool bool_21 = true;

		private DCInsertRowDownUseHotKeys dcinsertRowDownUseHotKeys_0 = DCInsertRowDownUseHotKeys.EnableOnlyForLastRow;

		private DCBooleanValue dcbooleanValue_1 = DCBooleanValue.Inherit;

		[NonSerialized]
		private float float_5 = -1f;

		private bool bool_22 = true;

		private bool bool_23 = true;

		private float float_6 = 0f;

		private bool bool_24 = false;

		private TableRowCloneType tableRowCloneType_0 = TableRowCloneType.Default;

		/// <summary>
		///       行号
		///       </summary>
		[DCPublishAPI]
		[ComVisible(true)]
		public int RowIndex => int_10;

		/// <summary>
		///       数据源绑定跨行数
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(1)]
		[DCPublishAPI]
		[HtmlAttribute]
		[MemberExpressionable]
		public int DataSourceRowSpan
		{
			get
			{
				return int_11;
			}
			set
			{
				int_11 = value;
			}
		}

		/// <summary>
		///       执行数据源绑定时的复制操作的倍数基数。，不足补充空白行。
		///       </summary>
		/// <remarks>
		///       比如设置为3，则生成的复制的次数必须为3的倍数，不足则补充空白行。
		///       本属性只有在ExpendForDataBinding=true时有效。
		///       </remarks>
		[ComVisible(true)]
		[DCPublishAPI]
		[DefaultValue(1)]
		[HtmlAttribute]
		[MemberExpressionable]
		public int CloneMultipleBaseForBindingDataSource
		{
			get
			{
				return int_12;
			}
			set
			{
				int_12 = value;
			}
		}

		/// <summary>
		///       DCWriter内部使用。本表格行是多行数据源绑定操作而产生的
		///       </summary>
		[DefaultValue(false)]
		[DCInternal]
		[XmlElement]
		[MemberExpressionable]
		[HtmlAttribute]
		[ComVisible(true)]
		public bool GenerateByValueBingding
		{
			get
			{
				return bool_17;
			}
			set
			{
				bool_17 = value;
			}
		}

		public override string DomDisplayName
		{
			get
			{
				int num = 19;
				string text = "Row:" + Convert.ToString(Index + 1);
				if (!string.IsNullOrEmpty(base.ID))
				{
					text = text + "-" + base.ID;
				}
				return text;
			}
		}

		/// <summary>
		///       从1开始计算的元素序号
		///       </summary>
		[DCPublishAPI]
		public int IndexBase1 => Index + 1;

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

		[DCPublishAPI]
		[Browsable(true)]
		[ReadOnly(true)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override string Text
		{
			get
			{
				int num = 2;
				StringBuilder stringBuilder = new StringBuilder();
				foreach (XTextTableCellElement cell in Cells)
				{
					if (!cell.IsOverrided)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(" ");
						}
						stringBuilder.Append(cell.Text);
					}
				}
				return stringBuilder.ToString();
			}
			set
			{
			}
		}

		internal override bool ContainsUnHandledPageBreak
		{
			get
			{
				if (RuntimeNewPage && !bool_19)
				{
					return true;
				}
				return base.ContainsUnHandledPageBreak;
			}
			set
			{
				base.ContainsUnHandledPageBreak = value;
			}
		}

		/// <summary>
		///       强制分页
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(false)]
		[DCPublishAPI]
		[HtmlAttribute]
		public bool NewPage
		{
			get
			{
				return bool_18;
			}
			set
			{
				bool_18 = value;
			}
		}

		internal bool RuntimeNewPage
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_100))
				{
					return bool_18;
				}
				return false;
			}
		}

		/// <summary>
		///       已经处理的强制分页标记.DCWriter内部使用。
		///       </summary>
		internal bool HandledNewPage
		{
			get
			{
				return bool_19;
			}
			set
			{
				bool_19 = value;
			}
		}

		/// <summary>
		///       打印单元格边框线
		///       </summary>
		[DCPublishAPI]
		[DefaultValue(true)]
		[ComVisible(true)]
		[HtmlAttribute]
		public bool PrintCellBorder
		{
			get
			{
				return bool_20;
			}
			set
			{
				bool_20 = value;
			}
		}

		/// <summary>
		///       打印单元格背景
		///       </summary>
		[DCPublishAPI]
		[HtmlAttribute]
		[ComVisible(true)]
		[DefaultValue(true)]
		public bool PrintCellBackground
		{
			get
			{
				return bool_21;
			}
			set
			{
				bool_21 = value;
			}
		}

		/// <summary>
		///       使用快捷键向下插入表格行时的行为。
		///       </summary>
		[DCPublishAPI]
		[MemberExpressionable]
		[ComVisible(true)]
		[DefaultValue(DCInsertRowDownUseHotKeys.EnableOnlyForLastRow)]
		[HtmlAttribute]
		public DCInsertRowDownUseHotKeys AllowInsertRowDownUseHotKey
		{
			get
			{
				return dcinsertRowDownUseHotKeys_0;
			}
			set
			{
				dcinsertRowDownUseHotKeys_0 = value;
			}
		}

		/// <summary>
		///       本属性已经过时，请使用InsertRowDownUseHotKey属性替代。
		///       </summary>
		/// <remarks>
		///       允许用户按下Tab键来向下插入表格行,即使表格行不是表格的最后一行。本属性值默认为false。
		///       如果表格的AllowUserInsertRow属性值为false，则不能插入表格行。
		///       </remarks>
		[ComVisible(true)]
		[DisplayName("(已过时)AllowUserPressTabKeyToInsertRowDown")]
		[DCPublishAPI]
		[DefaultValue(false)]
		public bool AllowUserPressTabKeyToInsertRowDown
		{
			get
			{
				if (AllowInsertRowDownUseHotKey == DCInsertRowDownUseHotKeys.EnableInAllCases)
				{
					return true;
				}
				return false;
			}
			set
			{
				if (AllowUserPressTabKeyToInsertRowDown != value)
				{
					if (value)
					{
						AllowInsertRowDownUseHotKey = DCInsertRowDownUseHotKeys.EnableInAllCases;
					}
					else
					{
						AllowInsertRowDownUseHotKey = DCInsertRowDownUseHotKeys.EnableOnlyForLastRow;
					}
				}
			}
		}

		/// <summary>
		///       是否允许用户鼠标拖拽操作改变表格行高度
		///       </summary>
		[MemberExpressionable]
		[HtmlAttribute]
		[ComVisible(true)]
		[DCPublishAPI]
		[DefaultValue(DCBooleanValue.Inherit)]
		public DCBooleanValue AllowUserToResizeHeight
		{
			get
			{
				return dcbooleanValue_1;
			}
			set
			{
				dcbooleanValue_1 = value;
			}
		}

		/// <summary>
		///       运行时的用户能否改变表格行高度
		///       </summary>
		internal bool RuntimeAllowUserToResizeHeight
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_92))
				{
					return true;
				}
				if (AllowUserToResizeHeight == DCBooleanValue.True)
				{
					return true;
				}
				if (AllowUserToResizeHeight == DCBooleanValue.False)
				{
					return false;
				}
				if (OwnerTable == null)
				{
					return true;
				}
				return OwnerTable.AllowUserToResizeRows;
			}
		}

		internal override bool RuntimeSupportValueBinding => XTextDocument.smethod_13(GEnum6.const_96);

		/// <summary>
		///       表格行中最高的单元格的高度
		///       </summary>
		internal float MaxCellHeight
		{
			get
			{
				if (float_5 < 0f)
				{
					float_5 = 0f;
					foreach (XTextTableCellElement cell in Cells)
					{
						if (!cell.IsOverrided)
						{
							float_5 = Math.Max(float_5, cell.Height);
						}
					}
				}
				return float_5;
			}
			set
			{
				float_5 = value;
			}
		}

		/// <summary>
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "row";

		/// <summary>
		///       能否被分页线分割，也就是是否允许被分配到两页上
		///       </summary>
		[Category("Layout")]
		[DefaultValue(true)]
		[MemberExpressionable(MemberEffectLevel.DocumentLayout)]
		[DCPublishAPI]
		[HtmlAttribute]
		public bool CanSplitByPageLine
		{
			get
			{
				return bool_22;
			}
			set
			{
				bool_22 = value;
			}
		}

		internal bool RuntimeCanSplitByPageLine
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_99))
				{
					return bool_22;
				}
				return true;
			}
		}

		/// <summary>
		///       从0开始计算的表格行所在的页码数
		///       </summary>
		[Browsable(true)]
		[DCPublishAPI]
		public override int OwnerPageIndex
		{
			get
			{
				if (OwnerDocument == null)
				{
					return -1;
				}
				float position = AbsTop + 0.01f;
				return OwnerDocument.Pages.IndexOfByPosition(position, 0);
			}
		}

		/// <summary>
		///       由于数据源绑定而扩展的表格行
		///       </summary>
		[DefaultValue(true)]
		[XmlElement]
		[HtmlAttribute]
		[DCPublishAPI]
		[Browsable(false)]
		public bool ExpendForDataBinding
		{
			get
			{
				return bool_23;
			}
			set
			{
				bool_23 = value;
			}
		}

		/// <summary>
		///       对象所属的表格对象
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[XmlIgnore]
		public new XTextTableElement OwnerTable => (XTextTableElement)Parent;

		/// <summary>
		///       行号
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		public int Index
		{
			get
			{
				if (OwnerTable == null)
				{
					return 0;
				}
				return OwnerTable.RuntimeRows.IndexOf(this);
			}
		}

		/// <summary>
		///       左端绝对坐标
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		public override float AbsLeft => OwnerTable.AbsLeft + Left;

		/// <summary>
		///       顶端绝对坐标值
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DCPublishAPI]
		public override float AbsTop => OwnerTable.AbsTop + Top;

		/// <summary>
		///       本表格行包含的单元格对象
		///       </summary>
		[DCPublishAPI]
		[Browsable(false)]
		[XmlIgnore]
		public XTextElementList Cells
		{
			get
			{
				return Elements;
			}
			set
			{
				Elements = value;
			}
		}

		/// <summary>
		///       表格行中最后一个可见的单元格（未被其他单元格合并覆盖的单元格）
		///       </summary>
		[ComVisible(true)]
		[Browsable(false)]
		[XmlIgnore]
		public XTextTableCellElement LastVisibleCell
		{
			get
			{
				int num = Cells.Count - 1;
				XTextTableCellElement xTextTableCellElement;
				while (true)
				{
					if (num >= 0)
					{
						xTextTableCellElement = (XTextTableCellElement)Cells[num];
						if (!xTextTableCellElement.IsOverrided)
						{
							break;
						}
						num--;
						continue;
					}
					return null;
				}
				return xTextTableCellElement;
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
		[DefaultValue(0f)]
		[DCPublishAPI]
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ContentElementLayout)]
		public float SpecifyHeight
		{
			get
			{
				return float_6;
			}
			set
			{
				float_6 = value;
			}
		}

		[DCInternal]
		[Browsable(false)]
		public float RuntimeSpecifyHeight
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_97))
				{
					return float_6;
				}
				return 0f;
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		[XmlIgnore]
		[Browsable(true)]
		[DCPublishAPI]
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
		///       对象高度
		///       </summary>
		[DCPublishAPI]
		[Browsable(true)]
		[XmlIgnore]
		public override float Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				base.Height = value;
			}
		}

		/// <summary>
		///       标题行样式
		///       </summary>
		/// <remarks>
		///       在分页时，若导致分页的表格行的DataRow属性为false则不自动插入临时标题行
		///       </remarks>
		[HtmlAttribute]
		[DefaultValue(false)]
		[MemberExpressionable(MemberEffectLevel.DocumentLayout)]
		[Category("Appearance")]
		[DCPublishAPI]
		public bool HeaderStyle
		{
			get
			{
				return bool_24;
			}
			set
			{
				bool_24 = value;
			}
		}

		/// <summary>
		///       运行时的是否是标题行模式
		///       </summary>
		internal bool RuntimeHeaderStyle
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_98))
				{
					return bool_24;
				}
				return false;
			}
		}

		/// <summary>
		///       获得同一层次中的上一个元素
		///       </summary>
		[XmlIgnore]
		[DCPublishAPI]
		[Browsable(false)]
		public override XTextElement PreviousElement => ((XTextTableElement)Parent)?.RuntimeRows.GetPreElement(this);

		/// <summary>
		///       获得元素的同一层次的下一个元素
		///       </summary>
		[Browsable(false)]
		[DCPublishAPI]
		[XmlIgnore]
		public override XTextElement NextElement => ((XTextTableElement)Parent)?.RuntimeRows.GetNextElement(this);

		/// <summary>
		///       元素编号
		///       </summary>
		[Browsable(false)]
		public override int ElementIndex
		{
			get
			{
				if (Parent != null)
				{
					XTextTableElement xTextTableElement = (XTextTableElement)Parent;
					return xTextTableElement.RuntimeRows.IndexOf(this);
				}
				return -1;
			}
		}

		/// <summary>
		///       是否包含被选中的单元格
		///       </summary>
		[Browsable(false)]
		public override bool HasSelection
		{
			get
			{
				if (OwnerDocument.Selection.CellsWithoutOverried != null)
				{
					foreach (XTextTableCellElement item in OwnerDocument.Selection.CellsWithoutOverried)
					{
						if (Cells.Contains(item))
						{
							return true;
						}
					}
				}
				return base.HasSelection;
			}
		}

		/// <summary>
		///       复制方式
		///       </summary>
		[DCPublishAPI]
		[MemberExpressionable]
		[HtmlAttribute]
		[DefaultValue(TableRowCloneType.Default)]
		public TableRowCloneType CloneType
		{
			get
			{
				return tableRowCloneType_0;
			}
			set
			{
				tableRowCloneType_0 = (TableRowCloneType)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCPublishAPI]
		public XTextTableRowElement()
		{
		}

		internal int method_26(UpdateDataBindingArgs updateDataBindingArgs_0)
		{
			int num = 0;
			foreach (XTextElement element in Elements)
			{
				if (element is IUpdateDataBindingExt)
				{
					int num2 = ((IUpdateDataBindingExt)element).UpdateDataBindingExt(updateDataBindingArgs_0);
					num += num2;
				}
			}
			return num;
		}

		public override string ToString()
		{
			return DomDisplayName;
		}

		protected override bool vmethod_26(string string_16, bool bool_25)
		{
			return false;
		}

		/// <summary>
		///       设置表格行固定文档内容行高
		///       </summary>
		/// <param name="lineHeight">指定的行高</param>
		/// <param name="showGridLine">是否显示网格线</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否修改了文档内容</returns>
		public bool EditorSetSpecifyFixedLineHeight(float lineHeight, bool showGridLine, bool logUndo)
		{
			int num = 5;
			bool flag = false;
			XTextDocument ownerDocument = OwnerDocument;
			bool flag2 = logUndo && ownerDocument.CanLogUndo;
			if (float.IsNaN(lineHeight))
			{
				float num2 = 0f;
				foreach (XTextTableCellElement cell in Cells)
				{
					foreach (XTextLine privateLine in cell.PrivateLines)
					{
						num2 = Math.Max(num2, privateLine.Height);
					}
				}
				lineHeight = num2;
			}
			foreach (XTextTableCellElement cell2 in Cells)
			{
				if (cell2.SpecifyFixedLineHeight != lineHeight)
				{
					if (flag2)
					{
						ownerDocument.UndoList.AddProperty("SpecifyFixedLineHeight", cell2.SpecifyFixedLineHeight, lineHeight, cell2);
					}
					cell2.SpecifyFixedLineHeight = lineHeight;
					flag = true;
				}
				DocumentContentStyle documentContentStyle = cell2.RuntimeStyle.CloneParent();
				if (showGridLine)
				{
					documentContentStyle.GridLineStyle = DashStyle.Solid;
					documentContentStyle.GridLineType = ContentGridLineType.ExtentToBottom;
				}
				else
				{
					documentContentStyle.GridLineStyle = DashStyle.Solid;
					documentContentStyle.GridLineType = ContentGridLineType.None;
				}
				int styleIndex = ownerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
				if (cell2.StyleIndex != styleIndex)
				{
					ownerDocument.UndoList.AddStyleIndex(cell2, cell2.StyleIndex, styleIndex);
					cell2.StyleIndex = styleIndex;
				}
			}
			if (flag)
			{
				if (flag2)
				{
					ownerDocument.UndoList.AddMethod(UndoMethodTypes.RefreshLayout);
				}
				EditorRefreshView();
			}
			return flag;
		}

		/// <summary>
		///       表格行的刷新内容和排版
		///       </summary>
		[DCPublishAPI]
		public override void EditorRefreshView()
		{
			XTextTableElement ownerTable = OwnerTable;
			ownerTable.EditorRefreshView();
		}

		/// <summary>
		///       不支持设置表格行的可见性
		///       </summary>
		/// <param name="visible">
		/// </param>
		/// <param name="logUndo">
		/// </param>
		/// <param name="fastMode">
		/// </param>
		/// <returns>
		/// </returns>
		public override bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode)
		{
			return false;
		}

		/// <summary>
		///       创建新的文档对象，使其包含本文档元素的复制品
		///       </summary>
		/// <param name="includeThis">是否包含本文档原始对象,对表格行该参数无作用</param>
		/// <returns>创建的文档对象</returns>
		public override XTextDocument CreateContentDocument(bool includeThis)
		{
			if (OwnerTable == null)
			{
				return null;
			}
			XTextElementList xTextElementList = new XTextElementList();
			foreach (XTextTableCellElement cell in Cells)
			{
				if (!cell.IsOverrided)
				{
					xTextElementList.Add(cell);
				}
			}
			if (xTextElementList.Count == 0)
			{
				return null;
			}
			XTextTableElement xTextTableElement = (XTextTableElement)OwnerTable.Clone(Deeply: false);
			xTextTableElement.Columns = new XTextElementList();
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Clone(Deeply: false);
			xTextTableElement.Rows = new XTextElementList();
			xTextTableElement.Rows.Add(xTextTableRowElement);
			foreach (XTextTableCellElement item in xTextElementList)
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)item.OwnerColumn.Clone(Deeply: false);
				xTextTableColumnElement.Width = item.Width;
				xTextTableElement.Columns.Add(xTextTableColumnElement);
				XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)item.Clone(Deeply: true);
				xTextTableCellElement2.method_61(1);
				xTextTableCellElement2.method_60(1);
				xTextTableRowElement.Cells.Add(xTextTableCellElement2);
			}
			xTextTableElement.OwnerDocument = OwnerDocument;
			XTextDocument result = xTextTableElement.CreateContentDocument(includeThis: true);
			xTextTableElement.Dispose();
			return result;
		}

		/// <summary>
		///       选中整个表格行
		///       </summary>
		/// <returns>
		/// </returns>
		[DCPublishAPI]
		public override bool Select()
		{
			XTextTableElement ownerTable = OwnerTable;
			if (ownerTable == null)
			{
				return false;
			}
			XTextElementList selectionCells = ownerTable.GetSelectionCells(ownerTable.RuntimeRows.IndexOf(this), 0, ownerTable.RuntimeRows.IndexOf(this), Cells.Count - 1);
			int num = int.MaxValue;
			int num2 = 0;
			foreach (XTextTableCellElement item in selectionCells)
			{
				if (!item.IsOverrided)
				{
					num = Math.Min(num, item.Elements.FirstContentElement.ViewIndex);
					num2 = Math.Max(num2, item.Elements.LastElement.ViewIndex);
					OwnerDocument.method_124(item);
				}
			}
			if (num < int.MaxValue && num >= 0 && num2 >= 0)
			{
				return base.DocumentContentElement.SetSelectionRange(num, num2);
			}
			return false;
		}

		/// <summary>
		///       在编辑器中设置表格行的用户指定高度,DCWriter内部使用。
		///       </summary>
		/// <param name="newHeight">新高度</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		[DCPublishAPI]
		public void EditorSetRowSpecifyHeight(float newHeight, bool logUndo)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_97))
			{
				return;
			}
			XTextTableElement ownerTable = OwnerTable;
			ownerTable.InvalidateView();
			float height = ownerTable.Height;
			float specifyHeight = SpecifyHeight;
			if (SpecifyHeight < 0f)
			{
				newHeight = 0f - newHeight;
			}
			if (SpecifyHeight == newHeight)
			{
				return;
			}
			XTextDocument ownerDocument = OwnerDocument;
			if (ownerDocument.EditorControl != null)
			{
				WriterTableRowHeightChangingEventArgs writerTableRowHeightChangingEventArgs = new WriterTableRowHeightChangingEventArgs(ownerDocument.EditorControl, ownerDocument, this, newHeight);
				ownerDocument.EditorControl.vmethod_16(writerTableRowHeightChangingEventArgs);
				if (writerTableRowHeightChangingEventArgs.Cancel)
				{
					return;
				}
				newHeight = writerTableRowHeightChangingEventArgs.NewHeight;
			}
			float height2 = Height;
			SpecifyHeight = newHeight;
			if (logUndo && ownerDocument.BeginLogUndo())
			{
				ownerDocument.UndoList.AddRowSpecifyHeight(this, specifyHeight);
				ownerDocument.EndLogUndo();
			}
			ownerDocument.Modified = true;
			Modified = true;
			Height = 0f;
			foreach (XTextTableCellElement cell in Cells)
			{
				cell.LayoutInvalidate = true;
				cell.Width = 0f;
				cell.Height = 0f;
			}
			ownerTable.method_33(bool_26: false);
			ownerTable.InvalidateView();
			if (ownerTable.Height != height)
			{
				ownerTable.method_41(bool_26: false);
			}
			if (ownerDocument.EditorControl != null)
			{
				WriterTableRowHeightChangedEventArgs writerTableRowHeightChangedEventArgs_ = new WriterTableRowHeightChangedEventArgs(ownerDocument.EditorControl, ownerDocument, this, height2, Height);
				ownerDocument.EditorControl.vmethod_15(writerTableRowHeightChangedEventArgs_);
			}
		}

		/// <summary>
		///       删除表格行
		///       </summary>
		[DCPublishAPI]
		public override bool EditorDelete(bool logUndo)
		{
			XTextTableElement ownerTable = OwnerTable;
			return ownerTable?.method_46(ownerTable.Rows.IndexOf(this), 1, logUndo, null) ?? false;
		}

		/// <summary>
		///       计算表格行的高度，DCWriter内部使用
		///       </summary>
		[DCInternal]
		public void CalcuteRowHeight()
		{
			if (RuntimeSpecifyHeight < 0f)
			{
				Height = Math.Abs(RuntimeSpecifyHeight);
				return;
			}
			bool flag = false;
			RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
			float paddingTop = runtimeStyle.PaddingTop;
			float paddingBottom = runtimeStyle.PaddingBottom;
			float num = RuntimeSpecifyHeight;
			foreach (XTextTableCellElement cell in Cells)
			{
				if (!cell.IsOverrided && cell.RowSpan == 1 && cell.AutoFixFontSizeMode != ContentAutoFixFontSizeMode.SingleLine && cell.AutoFixFontSizeMode != ContentAutoFixFontSizeMode.MultiLine)
				{
					float num2 = cell.ContentHeight + paddingTop + paddingBottom;
					if (num < num2)
					{
						num = num2;
					}
					flag = true;
				}
			}
			if (!flag)
			{
				float val = OwnerDocument.DefaultStyle.DefaultLineHeight + paddingTop + paddingBottom;
				num = Math.Max(RuntimeSpecifyHeight, val);
			}
			Height = num;
		}

		/// <summary>
		///       为编辑器复制表格行对象
		///       </summary>
		/// <returns>复制品</returns>
		[DCPublishAPI]
		public XTextTableRowElement EditorClone()
		{
			return EditorCloneSpecifyCloneType(CloneType);
		}

		/// <summary>
		///       指定复制模式的为编辑器复制表格行对象
		///       </summary>
		/// <param name="cloneType">复制模式</param>
		/// <returns>复制品</returns>
		[DCPublishAPI]
		public XTextTableRowElement EditorCloneSpecifyCloneType(TableRowCloneType cloneType)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Clone(Deeply: false);
			xTextTableRowElement.HeaderStyle = false;
			xTextTableRowElement.Elements = new XTextElementList();
			foreach (XTextTableCellElement cell in Cells)
			{
				TableRowCloneType tableRowCloneType = cell.CloneType;
				if (tableRowCloneType == TableRowCloneType.Default)
				{
					tableRowCloneType = cloneType;
				}
				XTextTableCellElement xTextTableCellElement2 = cell.EditorCloneSpecifyCloneType(tableRowCloneType);
				xTextTableCellElement2.Parent = xTextTableRowElement;
				xTextTableRowElement.Cells.Add(xTextTableCellElement2);
			}
			return xTextTableRowElement;
		}

		/// <summary>
		///       表格行填充数据源
		///       </summary>
		/// <param name="dataSource">数据源对象</param>
		/// <returns>生成的表格行个数</returns>
		[ComVisible(false)]
		public int EditorFillDataSource(object dataSource)
		{
			return 0;
		}
	}
}
