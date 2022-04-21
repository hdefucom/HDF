using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom.Undo;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       单元格元素
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComClass("00012345-6789-ABCD-EF01-234567890011", "27BA9E41-2E8E-408F-B95A-0709630742AB")]
	[ComVisible(true)]
	
	[DebuggerDisplay("Cell {CellID}:{ PreviewString }")]
	
	[ComDefaultInterface(typeof(IXTextTableCellElement))]
	[Guid("00012345-6789-ABCD-EF01-234567890011")]
	[XmlType("XTextTableCell")]
	public sealed class XTextTableCellElement : XTextContentElement, IXTextTableCellElement
	{
		private class Class12 : IComparable<Class12>
		{
			public int int_0 = 0;

			public float float_0 = 0f;

			public float float_1 = 0f;

			public XTextTableColumnElement xtextTableColumnElement_0 = null;

			public XTextTableColumnElement xtextTableColumnElement_1 = null;

			public bool bool_0 = false;

			public int CompareTo(Class12 other)
			{
				return (int)(float_0 - other.float_0);
			}

			public override string ToString()
			{
				int num = 10;
				string text = float_0.ToString("0.0") + " " + float_1.ToString("0.0");
				if (bool_0)
				{
					text += " NewFlag";
				}
				if (xtextTableColumnElement_0 != null)
				{
					text += " HasOldCol";
				}
				return text;
			}
		}

		internal const string string_14 = "00012345-6789-ABCD-EF01-234567890011";

		internal const string string_15 = "27BA9E41-2E8E-408F-B95A-0709630742AB";

		private bool bool_22 = true;

		private bool bool_23 = false;

		private bool bool_24 = false;

		private ContentAutoFixFontSizeMode contentAutoFixFontSizeMode_0 = ContentAutoFixFontSizeMode.None;

		private MoveFocusHotKeys moveFocusHotKeys_0 = MoveFocusHotKeys.Tab;

		private RectangleSlantSplitStyle rectangleSlantSplitStyle_0 = RectangleSlantSplitStyle.None;

		[NonSerialized]
		private XTextTableColumnElement xtextTableColumnElement_0 = null;

		private XTextTableCellElement xtextTableCellElement_0 = null;

		private int int_13 = 1;

		private int int_14 = 1;

		internal int int_15 = -1;

		internal int int_16 = -1;

		private int int_17 = 0;

		private int int_18 = 0;

		private static Bitmap bitmap_0 = null;

		private bool bool_25 = false;

		private TableRowCloneType tableRowCloneType_0 = TableRowCloneType.Default;

		public override string DomDisplayName
		{
			get
			{
				int num = 13;
				if (string.IsNullOrEmpty(base.ID))
				{
					return CellID;
				}
				return CellID + "-" + base.ID;
			}
		}

		/// <summary>
		///       获取或设置一个值，该值指示用户能否使用 Tab 键将焦点放到该元素中上。 
		///       </summary>
		[MemberExpressionable]
		[DefaultValue(true)]
		
		[HtmlAttribute]
		public bool TabStop
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

		/// <summary>
		///       获取或设置一个运行时的值，该值指示用户能否使用 Tab 键将焦点放到该元素中上。 
		///       </summary>
		public override bool RuntimeTabStop => TabStop;

		internal override bool RuntimeSupportValueBinding => XTextDocument.smethod_13(GEnum6.const_104);

		internal override bool RuntimeSupportValidateStyle => XTextDocument.smethod_13(GEnum6.const_105);

		[Browsable(false)]
		
		[XmlIgnore]
		public override bool Visible
		{
			get
			{
				return true;
			}
			set
			{
				base.Visible = value;
			}
		}

		/// <summary>
		///       单元格可否可见
		///       </summary>
		[XmlIgnore]
		[Browsable(true)]
		public override bool RuntimeVisible
		{
			get
			{
				return base.RuntimeVisible && xtextTableCellElement_0 == null;
			}
			set
			{
				base.RuntimeVisible = value;
			}
		}

		/// <summary>
		///       在续打的时候已经打印了边框，和XTextTableElement.PrintBothBorderWhenJumpPrint属性搭配使用。
		///       </summary>
		[DefaultValue(false)]
		[MemberExpressionable(MemberEffectLevel.DOM)]
		
		public bool BorderPrintedWhenJumpPrint
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
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "cell";

		/// <summary>
		///       元素在父节点的子节点列表中的序号
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override int ElementIndex
		{
			get
			{
				if (Parent == null)
				{
					return -1;
				}
				return Parent.Elements.IndexOf(this);
			}
			set
			{
				base.ElementIndex = value;
			}
		}

		/// <summary>
		///       对象所属页码
		///       </summary>
		[Browsable(false)]
		
		public override int OwnerPageIndex
		{
			get
			{
				if (OwnerRow == null)
				{
					return -1;
				}
				return OwnerRow.OwnerPageIndex;
			}
		}

		/// <summary>
		///       边框是重点突出的
		///       </summary>
		
		[Category("Appearance")]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		[HtmlAttribute]
		[DefaultValue(false)]
		public bool StressBorder
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
		///       自动修改字体大小以适应内容
		///       </summary>
		
		[MemberExpressionable(MemberEffectLevel.ElementLayout)]
		[HtmlAttribute]
		[DefaultValue(ContentAutoFixFontSizeMode.None)]
		public ContentAutoFixFontSizeMode AutoFixFontSizeMode
		{
			get
			{
				return contentAutoFixFontSizeMode_0;
			}
			set
			{
				contentAutoFixFontSizeMode_0 = value;
			}
		}

		/// <summary>
		///       运行时使用的自动修字体大小设置
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		
		private ContentAutoFixFontSizeMode RuntimeAutoFixFontSizeMode
		{
			get
			{
				if (contentAutoFixFontSizeMode_0 == ContentAutoFixFontSizeMode.MultiLine)
				{
					if (!XTextDocument.smethod_13(GEnum6.const_107))
					{
						return ContentAutoFixFontSizeMode.None;
					}
				}
				else if (contentAutoFixFontSizeMode_0 == ContentAutoFixFontSizeMode.SingleLine && !XTextDocument.smethod_13(GEnum6.const_106))
				{
					return ContentAutoFixFontSizeMode.None;
				}
				return AutoFixFontSizeMode;
			}
		}

		/// <summary>
		///       本属性已经被AutoFixFontSizeMode属性替换掉了。
		///       </summary>
		
		[XmlElement]
		[DefaultValue(false)]
		[ComVisible(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AutoFixFontSize
		{
			get
			{
				return AutoFixFontSizeMode != ContentAutoFixFontSizeMode.None;
			}
			set
			{
				if (value != (AutoFixFontSizeMode != ContentAutoFixFontSizeMode.None))
				{
					if (value)
					{
						AutoFixFontSizeMode = ContentAutoFixFontSizeMode.SingleLine;
					}
					else
					{
						AutoFixFontSizeMode = ContentAutoFixFontSizeMode.None;
					}
				}
			}
		}

		/// <summary>
		///       移动焦点使用的快捷键
		///       </summary>
		[DefaultValue(MoveFocusHotKeys.Tab)]
		
		[MemberExpressionable]
		[HtmlAttribute]
		public MoveFocusHotKeys MoveFocusHotKey
		{
			get
			{
				return moveFocusHotKeys_0;
			}
			set
			{
				moveFocusHotKeys_0 = (MoveFocusHotKeys)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       实际使用的移动焦点所使用的快捷键样式.DCWriter内部使用。
		///       </summary>
		[HtmlAttribute]
		[XmlIgnore]
		[Browsable(false)]
		public override MoveFocusHotKeys RuntimeMoveFocusHotKey
		{
			get
			{
				MoveFocusHotKeys moveFocusHotKeys = MoveFocusHotKey;
				if (moveFocusHotKeys == MoveFocusHotKeys.Default && OwnerDocument != null && OwnerDocument.EditorControl != null)
				{
					moveFocusHotKeys = OwnerDocument.EditorControl.MoveFocusHotKey;
				}
				if (moveFocusHotKeys == MoveFocusHotKeys.Default)
				{
					moveFocusHotKeys = MoveFocusHotKeys.None;
				}
				return moveFocusHotKeys;
			}
			set
			{
			}
		}

		/// <summary>
		///       对象宽度
		///       </summary>
		
		[XmlIgnore]
		[Browsable(true)]
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
		
		[XmlIgnore]
		[Browsable(true)]
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

		
		[MemberExpressionable(MemberEffectLevel.DOM)]
		[XmlIgnore]
		[Browsable(false)]
		public override string FormulaValue
		{
			get
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)Elements.method_5(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement == null)
				{
					return Text;
				}
				return xTextInputFieldElement.FormulaValue;
			}
			set
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)Elements.method_5(typeof(XTextInputFieldElement));
				SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
				setContainerTextArgs.NewText = method_12(value);
				setContainerTextArgs.LogUndo = false;
				setContainerTextArgs.AccessFlags = DomAccessFlags.None;
				setContainerTextArgs.DisablePermission = true;
				setContainerTextArgs.EventSource = ContentChangedEventSource.Default;
				setContainerTextArgs.FocusContainer = false;
				setContainerTextArgs.IgnoreDisplayFormat = false;
				setContainerTextArgs.ShowUI = false;
				setContainerTextArgs.UpdateContent = true;
				if (xTextInputFieldElement == null)
				{
					SetEditorText(setContainerTextArgs);
				}
				else
				{
					xTextInputFieldElement.SetEditorText(setContainerTextArgs);
				}
			}
		}

		/// <summary>
		///       不推荐使用，被ToolTip属性代替了。
		///       </summary>
		[Browsable(false)]
		[Obsolete("不推荐使用，被ToolTip属性代替了。")]
		[XmlIgnore]
		[DefaultValue(null)]
		public string Title
		{
			get
			{
				return base.ToolTip;
			}
			set
			{
				base.ToolTip = value;
			}
		}

		/// <summary>
		///       斜分割线样式
		///       </summary>
		[Category("Appearance")]
		[MemberExpressionable(MemberEffectLevel.ElementView)]
		
		[DefaultValue(RectangleSlantSplitStyle.None)]
		[HtmlAttribute]
		public RectangleSlantSplitStyle SlantSplitLineStyle
		{
			get
			{
				return rectangleSlantSplitStyle_0;
			}
			set
			{
				rectangleSlantSplitStyle_0 = (RectangleSlantSplitStyle)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       对象所属表格对象
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		public new XTextTableElement OwnerTable
		{
			get
			{
				if (Parent == null)
				{
					return null;
				}
				return (XTextTableElement)Parent.Parent;
			}
		}

		/// <summary>
		///       对象所属表格行对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		
		public XTextTableRowElement OwnerRow => (XTextTableRowElement)Parent;

		/// <summary>
		///       左端绝对坐标值
		///       </summary>
		[Browsable(false)]
		
		public override float AbsLeft => OwnerRow.AbsLeft + Left;

		/// <summary>
		///       顶端绝对坐标值
		///       </summary>
		
		[Browsable(false)]
		public override float AbsTop
		{
			get
			{
				XTextTableRowElement xTextTableRowElement = Parent as XTextTableRowElement;
				if (xTextTableRowElement != null)
				{
					XTextTableElement xTextTableElement = xTextTableRowElement.Parent as XTextTableElement;
					if (xTextTableElement != null)
					{
						return xTextTableElement.AbsTop + xTextTableRowElement.Top;
					}
				}
				return 0f;
			}
		}

		/// <summary>
		///       对象所属的最下面的表格行对象
		///       </summary>
		/// <remarks>当对象没有合并单元格时，该属性就返回单元格所在表格行对象，
		///       当纵向合并了单元格时( RowSpan 属性大于1)则该属性返回该单元格所跨过的
		///       表格行中最下面的一个表格行对象</remarks>
		[Browsable(false)]
		
		[XmlIgnore]
		public XTextTableRowElement LastOwnerRow
		{
			get
			{
				XTextTableElement ownerTable = OwnerTable;
				return (XTextTableRowElement)ownerTable.RuntimeRows.SafeGet(Parent.ElementIndex + RowSpan - 1);
			}
		}

		/// <summary>
		///       单元格所属表格列对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		
		public XTextTableColumnElement OwnerColumn
		{
			get
			{
				if (xtextTableColumnElement_0 == null)
				{
					XTextTableElement ownerTable = OwnerTable;
					if (ownerTable != null)
					{
						xtextTableColumnElement_0 = (XTextTableColumnElement)ownerTable.Columns.SafeGet(ElementIndex);
					}
				}
				return xtextTableColumnElement_0;
			}
			set
			{
				xtextTableColumnElement_0 = value;
			}
		}

		/// <summary>
		///       对象所属的最右边的表格列对象
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		public XTextTableColumnElement LastOwnerColumn => (XTextTableColumnElement)OwnerTable.Columns.SafeGet(ElementIndex + int_14 - 1);

		/// <summary>
		///       若单元格被其他单元格合并了则返回合并本单元格的单元格对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		
		public XTextTableCellElement OverrideCell => xtextTableCellElement_0;

		/// <summary>
		///       单元格是否处于选择状态
		///       </summary>
		[Browsable(false)]
		
		public bool IsSelected
		{
			get
			{
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (documentContentElement.Selection.Cells != null)
				{
					return documentContentElement.Selection.Cells.Contains(this);
				}
				return false;
			}
		}

		/// <summary>
		///       单元格在表格中的编号,这个编号是只读的，比如“A1”、“B2”、“C3”等。
		///       </summary>
		[Category("Design")]
		
		public string CellID
		{
			get
			{
				if (Parent != null && OwnerTable != null)
				{
					return GClass344.smethod_1(RowIndex + 1, ColIndex + 1);
				}
				return "";
			}
		}

		/// <summary>
		///       内容垂直对齐方式
		///       </summary>
		public override VerticalAlignStyle ContentVertialAlign
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_110))
				{
					return VerticalAlignStyle.Top;
				}
				return RuntimeStyle.VerticalAlign;
			}
		}

		/// <summary>
		///       判断本单元格是否被其他单元格合并了
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public bool IsOverrided => xtextTableCellElement_0 != null;

		/// <summary>
		///       跨行数
		///       </summary>
		/// <remarks>
		///       单元格所占据的表格行数，本属性为1则占据一行，单元格纵向没有合并单元格，若该属性值大于1则纵向合并
		///       单元格。本属性类似于 HTML 的 TD 元素的 ROWSPAN 属性。
		///       </remarks>
		[MemberExpressionable(MemberEffectLevel.ContentElementLayout)]
		[Category("Layout")]
		[DefaultValue(1)]
		
		public int RowSpan
		{
			get
			{
				return int_13;
			}
			set
			{
				if (UIIsUpdating)
				{
					int_13 = value;
					return;
				}
				if (OwnerTable == null || OwnerDocument == null || OwnerDocument.ReadyState != DomReadyStates.Complete)
				{
					int_13 = value;
					return;
				}
				int num = method_58(value);
				if (int_13 != num)
				{
					int_13 = num;
					OwnerTable.ExecuteLayout();
				}
			}
		}

		/// <summary>
		///       运行时的跨行数
		///       </summary>
		[Browsable(false)]
		
		public int RuntimeRowSpan => int_13;

		/// <summary>
		///       本单元格跨越的表格行列表
		///       </summary>
		
		[XmlIgnore]
		[Browsable(false)]
		public XTextElementList SpanRows
		{
			get
			{
				if (OwnerTable != null)
				{
					return OwnerTable.Elements.GetElements(RowIndex, int_13);
				}
				return new XTextElementList();
			}
		}

		/// <summary>
		///       获得单元格中覆盖的单元格列表
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public XTextElementList SpanCells
		{
			get
			{
				XTextElementList result = new XTextElementList();
				_ = OwnerTable;
				return result;
			}
		}

		/// <summary>
		///       跨列数
		///       </summary>
		/// <remarks>
		///       单元格所占据的表格列数，本属性值为1则单元格占据一列，单元格横向没有合并单元格，若该属性值大于1则横向合并
		///       单元格。本属性类似 HTML 的 TD 元素的 COLSPAN 属性。
		///       </remarks>
		[Category("Layout")]
		[MemberExpressionable(MemberEffectLevel.ContentElementLayout)]
		
		[DefaultValue(1)]
		public int ColSpan
		{
			get
			{
				return int_14;
			}
			set
			{
				if (UIIsUpdating)
				{
					int_14 = value;
					return;
				}
				if (OwnerDocument == null || OwnerDocument.ReadyState != DomReadyStates.Complete)
				{
					int_14 = value;
					return;
				}
				int num = method_59(value);
				if (int_14 != num)
				{
					int_14 = num;
					OwnerTable.ExecuteLayout();
				}
			}
		}

		/// <summary>
		///       从0开始的行号
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		
		public int RowIndex => int_15;

		/// <summary>
		///       从0开始的列号
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public int ColIndex => int_16;

		/// <summary>
		///       设计时行号
		///       </summary>
		
		[XmlElement]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[DefaultValue(0)]
		public int DesignRowIndex
		{
			get
			{
				return int_17;
			}
			set
			{
				int_17 = value;
			}
		}

		/// <summary>
		///       设计时列号
		///       </summary>
		
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(0)]
		[XmlElement]
		[Browsable(false)]
		public int DesignColIndex
		{
			get
			{
				return int_18;
			}
			set
			{
				int_18 = value;
			}
		}

		/// <summary>
		///       获得右边的可见单元格
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public XTextTableCellElement RightVisibleCell
		{
			get
			{
				XTextTableCellElement xTextTableCellElement = this;
				if (xTextTableCellElement.OverrideCell != null)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				XTextTableRowElement ownerRow = xTextTableCellElement.OwnerRow;
				if (ownerRow != null && ColIndex + ColSpan <= ownerRow.Cells.Count)
				{
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)ownerRow.Cells.SafeGet(xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan);
					if (xTextTableCellElement2 != null && xTextTableCellElement2.OverrideCell != null)
					{
						xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
					}
					return xTextTableCellElement2;
				}
				return null;
			}
		}

		/// <summary>
		///       获得左边的可见单元格
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		
		public XTextTableCellElement LeftVisibleCell
		{
			get
			{
				XTextTableCellElement xTextTableCellElement = this;
				if (xTextTableCellElement.OverrideCell != null)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				XTextTableRowElement ownerRow = xTextTableCellElement.OwnerRow;
				if (ownerRow != null && xTextTableCellElement.ColIndex > 0)
				{
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)ownerRow.Cells.SafeGet(xTextTableCellElement.ColIndex - 1);
					if (xTextTableCellElement2 != null && xTextTableCellElement2.OverrideCell != null)
					{
						xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
					}
					return xTextTableCellElement2;
				}
				return null;
			}
		}

		/// <summary>
		///       获得上面的可见单元格
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		
		
		public XTextTableCellElement TopVisibleCell
		{
			get
			{
				XTextTableCellElement xTextTableCellElement = this;
				if (xTextTableCellElement.OverrideCell != null)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				if (OwnerTable != null)
				{
					XTextTableCellElement xTextTableCellElement2 = OwnerTable.GetCell(xTextTableCellElement.RowIndex - 1, xTextTableCellElement.ColIndex, throwException: false);
					if (xTextTableCellElement2 != null && xTextTableCellElement2.OverrideCell != null)
					{
						xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
					}
					return xTextTableCellElement2;
				}
				return null;
			}
		}

		/// <summary>
		///       获得下面的可见的单元格
		///       </summary>
		
		[XmlIgnore]
		[Browsable(false)]
		public XTextTableCellElement BottomVisibleCell
		{
			get
			{
				XTextTableCellElement xTextTableCellElement = this;
				if (xTextTableCellElement.OverrideCell != null)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				if (OwnerTable != null)
				{
					XTextTableCellElement xTextTableCellElement2 = OwnerTable.GetCell(xTextTableCellElement.RowIndex + 1, xTextTableCellElement.ColIndex, throwException: false);
					if (xTextTableCellElement2 != null && xTextTableCellElement2.OverrideCell != null)
					{
						xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
					}
					return xTextTableCellElement2;
				}
				return null;
			}
		}

		/// <summary>
		///       本属性已经废止了，请使用ValueExpression属性
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string Expression
		{
			get
			{
				return base.ValueExpression;
			}
			set
			{
				base.ValueExpression = value;
			}
		}

		private static Bitmap Flag_Expression
		{
			get
			{
				if (bitmap_0 == null)
				{
					bitmap_0 = WriterResourcesCore.Flag_Expression;
					bitmap_0.MakeTransparent(Color.Red);
				}
				return bitmap_0;
			}
		}

		/// <summary>
		///       跨页视图镜像
		///       </summary>
		[HtmlAttribute]
		[ComVisible(true)]
		
		[DefaultValue(false)]
		public bool MirrorViewForCrossPage
		{
			get
			{
				return bool_25;
			}
			set
			{
				bool_25 = value;
			}
		}

		internal override DCGridLineInfo RuntimeGridLine
		{
			get
			{
				if (!XTextDocument.smethod_13(GEnum6.const_109))
				{
					return null;
				}
				return GridLine;
			}
		}

		/// <summary>
		///       复制方式
		///       </summary>
		
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
		
		public XTextTableCellElement()
		{
		}

		public override bool vmethod_30()
		{
			if (IsOverrided)
			{
				return false;
			}
			if (!(OwnerColumn?.Visible ?? true))
			{
				return false;
			}
			return base.vmethod_30();
		}

		/// <summary>
		///       不支持该方法
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

		
		public void method_55()
		{
			if (xtextElementList_2 != null && xtextElementList_2.Count != 0)
			{
				ContentAutoFixFontSizeMode runtimeAutoFixFontSizeMode = RuntimeAutoFixFontSizeMode;
				if (runtimeAutoFixFontSizeMode == ContentAutoFixFontSizeMode.None)
				{
					base.RateForAutoFixFontSizeMode = 1f;
				}
				else if (Height != 0f)
				{
					using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
					{
						DocumentPaintEventArgs documentPaintEventArgs = OwnerDocument.method_55(dcgraphics_);
						foreach (XTextElement item in base.PrivateContent)
						{
							if (item is XTextCharElement)
							{
								XTextCharElement xTextCharElement = (XTextCharElement)item;
								if (xTextCharElement.FontSizeZoomRate != 1f)
								{
									xTextCharElement.FontSizeZoomRate = 1f;
									documentPaintEventArgs.Element = xTextCharElement;
									xTextCharElement.RefreshSize(documentPaintEventArgs);
								}
							}
							else if (item is XTextParagraphFlagElement)
							{
								XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)item;
								xTextParagraphFlagElement.FontSizeZoomRate = 1f;
								documentPaintEventArgs.Element = xTextParagraphFlagElement;
								xTextParagraphFlagElement.RefreshSize(documentPaintEventArgs);
							}
						}
						switch (runtimeAutoFixFontSizeMode)
						{
						case ContentAutoFixFontSizeMode.MultiLine:
						{
							base.RateForAutoFixFontSizeMode = 1f;
							float num5 = Height;
							float num6 = ClientHeight;
							if (num6 < 0f)
							{
								XTextTableRowElement xTextTableRowElement = Parent as XTextTableRowElement;
								if (xTextTableRowElement != null && xTextTableRowElement.RuntimeSpecifyHeight != 0f)
								{
									num5 = Math.Abs(xTextTableRowElement.RuntimeSpecifyHeight);
									num6 = num5 - RuntimeStyle.PaddingTop - RuntimeStyle.PaddingBottom;
								}
							}
							if (!(num6 <= 10f))
							{
								if (base.PrivateLines.Count == 1)
								{
									float val = ClientHeight / base.PrivateLines[0].Height;
									float val2 = ClientWidth / base.PrivateLines[0].ContentWidth;
									method_56(Math.Min(val, val2), documentPaintEventArgs, bool_26: true);
								}
								if (base.PrivateLines.Count > 1)
								{
									_ = RuntimeStyle;
									Class121 @class = new Class121(null, null, ContentVertialAlign);
									@class.method_9(bool_2: true);
									double num7 = 1.0;
									foreach (XTextLine privateLine in base.PrivateLines)
									{
										privateLine.InvalidateState = true;
									}
									base.vmethod_42(@class);
									for (int i = 0; i < 4; i++)
									{
										float contentHeightExcludeLastLineAdditionHeight = base.ContentHeightExcludeLastLineAdditionHeight;
										if (!((double)contentHeightExcludeLastLineAdditionHeight > (double)num6 * 1.001))
										{
											break;
										}
										double num8 = 1.0 / Math.Sqrt(contentHeightExcludeLastLineAdditionHeight / num6);
										num8 *= 1.0 - (double)i / 8.0;
										num7 *= num8;
										if (num8 > 0.9)
										{
											num7 *= 0.95;
										}
										method_56((float)num7, documentPaintEventArgs, bool_26: true);
									}
								}
								Height = num5;
								InvalidateView();
							}
							break;
						}
						case ContentAutoFixFontSizeMode.SingleLine:
						{
							base.RateForAutoFixFontSizeMode = 1f;
							float num = 1f;
							float num2 = 0f;
							float num3 = 0f;
							foreach (XTextElement item2 in base.PrivateContent)
							{
								num2 += item2.Width;
								if (item2 is XTextCharElement)
								{
									num3 += item2.Width;
								}
							}
							float num4 = num2 - ClientWidth;
							if (num4 > 0f && num3 > 0f)
							{
								num = (num3 - num4) / num3;
								if (num < 0.3f)
								{
									num = 0.3f;
								}
							}
							if ((double)num < 1.0)
							{
								method_56(num, documentPaintEventArgs, bool_26: true);
							}
							base.RateForAutoFixFontSizeMode = num;
							break;
						}
						}
					}
				}
			}
		}

		private void method_56(float float_9, DocumentPaintEventArgs documentPaintEventArgs_0, bool bool_26)
		{
			if (float_9 >= 1f)
			{
				float_9 = 1f;
			}
			documentPaintEventArgs_0.Render = OwnerDocument.Render;
			documentPaintEventArgs_0.Document = OwnerDocument;
			bool flag = false;
			foreach (XTextElement item in base.PrivateContent)
			{
				if (item is XTextCharElement)
				{
					XTextCharElement xTextCharElement = (XTextCharElement)item;
					if (xTextCharElement.FontSizeZoomRate != float_9)
					{
						xTextCharElement.FontSizeZoomRate = float_9;
						documentPaintEventArgs_0.Element = xTextCharElement;
						xTextCharElement.RefreshSize(documentPaintEventArgs_0);
						flag = true;
					}
				}
				else if (item is XTextParagraphFlagElement)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)item;
					if (xTextParagraphFlagElement.FontSizeZoomRate != float_9)
					{
						xTextParagraphFlagElement.FontSizeZoomRate = float_9;
						documentPaintEventArgs_0.Element = xTextParagraphFlagElement;
						xTextParagraphFlagElement.RefreshSize(documentPaintEventArgs_0);
						flag = true;
					}
				}
			}
			base.RateForAutoFixFontSizeMode = float_9;
			if (bool_26 && flag)
			{
				Class121 @class = new Class121(null, null, ContentVertialAlign);
				@class.method_9(bool_2: true);
				foreach (XTextLine privateLine in base.PrivateLines)
				{
					privateLine.InvalidateState = true;
				}
				base.vmethod_42(@class);
			}
		}

		internal override bool vmethod_42(Class121 class121_0)
		{
			if (UIIsUpdating)
			{
				return false;
			}
			if (RuntimeAutoFixFontSizeMode == ContentAutoFixFontSizeMode.MultiLine || RuntimeAutoFixFontSizeMode == ContentAutoFixFontSizeMode.SingleLine)
			{
				method_55();
			}
			else
			{
				base.RateForAutoFixFontSizeMode = 1f;
			}
			List<XTextContentElement> fixContentForPageLineElements = OwnerDocument.FixContentForPageLineElements;
			if (fixContentForPageLineElements != null && fixContentForPageLineElements.Contains(this))
			{
				fixContentForPageLineElements.Remove(this);
			}
			bool result = base.vmethod_42(class121_0);
			if (MirrorViewForCrossPage)
			{
				InvalidateView();
			}
			return result;
		}

		internal void method_57(XTextTableCellElement xtextTableCellElement_1)
		{
			if (xtextTableCellElement_0 != xtextTableCellElement_1)
			{
				xtextTableCellElement_0 = xtextTableCellElement_1;
			}
		}

		
		public int method_58(int int_19)
		{
			if (int_19 < 1)
			{
				int_19 = 1;
			}
			if (RowIndex + int_19 - 1 >= OwnerTable.Rows.Count)
			{
				int_19 = OwnerTable.Rows.Count - RowIndex;
			}
			return int_19;
		}

		
		public int method_59(int int_19)
		{
			if (ColIndex + int_19 - 1 >= OwnerTable.Columns.Count)
			{
				int_19 = OwnerTable.Columns.Count - ColIndex;
			}
			if (int_19 < 1)
			{
				int_19 = 1;
			}
			return int_19;
		}

		
		public void method_60(int int_19)
		{
			int_14 = Math.Max(int_19, 1);
		}

		
		public void method_61(int int_19)
		{
			int_13 = Math.Max(int_19, 1);
		}

		
		public override void vmethod_40()
		{
		}

		/// <summary>
		///       创建新的文档对象，使其包含本文档元素的复制品
		///       </summary>
		/// <param name="includeThis">是否包含本文档原始对象</param>
		/// <returns>创建的文档对象</returns>
		
		public override XTextDocument CreateContentDocument(bool includeThis)
		{
			if (OwnerTable == null)
			{
				return null;
			}
			if (includeThis)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)OwnerTable.Clone(Deeply: false);
				xTextTableElement.OwnerDocument = OwnerDocument;
				xTextTableElement.Columns = new XTextElementList();
				XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
				xTextTableColumnElement.Width = Width;
				xTextTableElement.Columns.Add(xTextTableColumnElement);
				xTextTableElement.Elements = new XTextElementList();
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)OwnerRow.Clone(Deeply: false);
				xTextTableElement.Rows.Add(xTextTableRowElement);
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)Clone(Deeply: true);
				xTextTableCellElement.int_13 = 1;
				xTextTableCellElement.int_14 = 1;
				xTextTableRowElement.Cells.Add(xTextTableCellElement);
				xTextTableElement.FixDomState();
				XTextDocument result = WriterUtils.smethod_32(OwnerDocument, new XTextElementList(xTextTableElement), bool_2: false);
				xTextTableElement.Dispose();
				return result;
			}
			return base.CreateContentDocument(includeThis: false);
		}

		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[ComVisible(false)]
		public bool method_62(PrintPage printPage_0)
		{
			if (printPage_0 == null)
			{
				return false;
			}
			if (MirrorViewForCrossPage)
			{
				if (!XTextDocument.smethod_13(GEnum6.const_108))
				{
					return false;
				}
				if (base.PrivateLines == null || base.PrivateLines.Count == 0)
				{
					return false;
				}
				if (base.OwnerPagePartyStyle == PageContentPartyStyle.Body)
				{
					if (ContentVertialAlign == VerticalAlignStyle.Top)
					{
						XTextLine lastLine = base.PrivateLines.LastLine;
						float num = 0f;
						foreach (XTextElement item in lastLine)
						{
							num = Math.Max(num, item.Top + item.Height);
						}
						if (lastLine.AbsTop + num < printPage_0.Top + 4f)
						{
							return true;
						}
					}
					else if (ContentVertialAlign == VerticalAlignStyle.Bottom)
					{
						XTextLine firstLine = base.PrivateLines.FirstLine;
						if ((double)firstLine.AbsTop > (double)printPage_0.Bottom - 0.1)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		protected internal override void vmethod_43(DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			if (documentPaintEventArgs_0.RenderMode != DocumentRenderMode.Print || OwnerRow.PrintCellBorder)
			{
				base.vmethod_43(documentPaintEventArgs_0);
			}
		}

		/// <summary>
		///       绘制单元格内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void DrawContent(DocumentPaintEventArgs args)
		{
			int num = 18;
			OwnerDocument.method_85(this);
			_ = args.ViewBounds;
			RectangleSlantSplitStyle rectangleSlantSplitStyle = SlantSplitLineStyle;
			if (!XTextDocument.smethod_13(GEnum6.const_111))
			{
				rectangleSlantSplitStyle = RectangleSlantSplitStyle.None;
			}
			if (rectangleSlantSplitStyle != 0 && RuntimeStyle.HasVisibleBorder)
			{
				XPenStyle xpenStyle_ = RuntimeStyle.CreateBorderPen2();
				GClass503.smethod_1(args.Graphics, AbsBounds, xpenStyle_, rectangleSlantSplitStyle);
			}
			RectangleF absBounds;
			if (args.RenderMode == DocumentRenderMode.Paint && OwnerDocument.Options.ViewOptions.ShowExpressionFlag && !string.IsNullOrEmpty(base.ValueExpression))
			{
				absBounds = AbsBounds;
				float num2 = OwnerDocument.PixelToDocumentUnit(Flag_Expression.Width);
				args.Graphics.DrawImage(Flag_Expression, absBounds.Right - num2, absBounds.Bottom - num2);
			}
			base.DrawContent(args);
			if (method_62(args.Page))
			{
				PrintPage page = args.Page;
				float num3 = 0f;
				if (ContentVertialAlign == VerticalAlignStyle.Top)
				{
					num3 = page.Top - AbsTop;
				}
				else if (ContentVertialAlign == VerticalAlignStyle.Bottom)
				{
					num3 = page.Bottom - AbsBounds.Bottom;
				}
				XTextLineList xTextLineList = new XTextLineList();
				foreach (XTextLine privateLine in base.PrivateLines)
				{
					privateLine.Top += num3;
					xTextLineList.Add(privateLine);
				}
				bool enabledDrawGridLine = args.EnabledDrawGridLine;
				args.EnabledDrawGridLine = false;
				try
				{
					base.DrawContent(args);
				}
				finally
				{
					args.EnabledDrawGridLine = enabledDrawGridLine;
					foreach (XTextLine item in xTextLineList)
					{
						item.Top -= num3;
					}
				}
			}
			if (args.RenderMode != 0 || !OwnerDocument.Options.ViewOptions.ShowBackgroundCellID)
			{
				return;
			}
			absBounds = AbsBounds;
			if (!args.PageClipRectangle.IsEmpty)
			{
				absBounds = RectangleF.Intersect(absBounds, args.PageClipRectangle);
			}
			float fontHeight = args.Graphics.GetFontHeight(new XFontValue());
			DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
			VerticalAlignStyle verticalAlign = RuntimeStyle.VerticalAlign;
			drawStringFormatExt.Alignment = StringAlignment.Center;
			drawStringFormatExt.LineAlignment = StringAlignment.Center;
			if (Elements.Count > 1)
			{
				XTextLine firstLine = base.PrivateLines.FirstLine;
				if (firstLine != null)
				{
					if (firstLine.Top > fontHeight)
					{
						absBounds.Height = firstLine.Top;
					}
					else
					{
						switch (verticalAlign)
						{
						case VerticalAlignStyle.Top:
							drawStringFormatExt.LineAlignment = StringAlignment.Center;
							break;
						case VerticalAlignStyle.Middle:
							drawStringFormatExt.LineAlignment = StringAlignment.Near;
							break;
						case VerticalAlignStyle.Bottom:
							drawStringFormatExt.LineAlignment = StringAlignment.Near;
							break;
						}
					}
				}
			}
			drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
			string text = CellID;
			if (!string.IsNullOrEmpty(base.ValueExpression))
			{
				text = text + "=" + base.ValueExpression;
			}
			drawStringFormatExt.SetBounds(absBounds);
			drawStringFormatExt.Font = new XFontValue();
			drawStringFormatExt.Color = Color.Gray;
			args.Graphics.method_2(text, drawStringFormatExt);
		}

		/// <summary>
		///       执行排版
		///       </summary>
		public override void ExecuteLayout()
		{
			method_63(bool_26: false);
		}

		internal void method_63(bool bool_26)
		{
			base.PrivateLines.Clear();
			foreach (XTextElement item in base.PrivateContent)
			{
				item.OwnerLine = null;
			}
			if (!UIIsUpdating)
			{
				Class121 @class = new Class121(null, null, RuntimeStyle.VerticalAlign);
				@class.method_9(bool_26);
				if (vmethod_42(@class) && Height > 0f)
				{
					vmethod_41(ContentVertialAlign, bool_22: true, bool_23: true);
				}
				SizeInvalid = false;
			}
		}

		/// <summary>
		///       选择单元格
		///       </summary>
		
		public override bool Select()
		{
			XTextTableElement ownerTable = OwnerTable;
			if (ownerTable == null)
			{
				return false;
			}
			XTextTableCellElement xTextTableCellElement = this;
			if (xTextTableCellElement.IsOverrided)
			{
				xTextTableCellElement = xTextTableCellElement.OverrideCell;
			}
			OwnerDocument.method_124(this);
			int viewIndex = xTextTableCellElement.FirstContentElement.ViewIndex;
			int viewIndex2 = xTextTableCellElement.LastContentElement.ViewIndex;
			xTextTableCellElement.DocumentContentElement.Focus();
			return xTextTableCellElement.DocumentContentElement.SetSelectionRange(viewIndex, viewIndex2);
		}

		public override void vmethod_34(ContentChangedEventArgs contentChangedEventArgs_0)
		{
			if (OwnerColumn != null && !contentChangedEventArgs_0.LoadingDocument && OwnerDocument.EnableContentChangedEvent)
			{
				OwnerColumn.Modified = true;
			}
			base.vmethod_34(contentChangedEventArgs_0);
		}

		/// <summary>
		///       处理文档事件
		///       </summary>
		/// <param name="args">参数</param>
		public override void HandleDocumentEvent(DocumentEventArgs args)
		{
			if (args.Style == DocumentEventStyles.MouseMove || args.Style == DocumentEventStyles.MouseDown)
			{
				if (!args.StrictMatch)
				{
					if (args.ClientX == 0 && ColIndex == 0)
					{
						args.Cursor = GClass291.smethod_7();
						if (args.Style == DocumentEventStyles.MouseDown)
						{
							OwnerRow.Select();
						}
						args.Handled = true;
					}
					return;
				}
				float num = OwnerDocument.PixelToDocumentUnit(OwnerDocument.Options.BehaviorOptions.TableCellOperationDetectDistance);
				float num2 = Math.Max(num * 2f, RuntimeStyle.PaddingLeft);
				DomAccessFlags domAccessFlags = DomAccessFlags.Normal;
				if ((OwnerDocument.EditorControl.FormView == FormViewMode.Normal || OwnerDocument.EditorControl.FormView == FormViewMode.Strict) && OwnerTable.AllowUserToResizeEvenInFormViewMode)
				{
					domAccessFlags &= ~DomAccessFlags.CheckFormView;
				}
				if ((float)Math.Abs(args.X) <= num2 && (float)Math.Abs(args.X) > num)
				{
					if (OwnerDocument.DocumentControler.CanModify(this, domAccessFlags))
					{
						args.Cursor = GClass291.smethod_0();
						if (args.Style == DocumentEventStyles.MouseDown && args.StrictMatch)
						{
							Select();
							args.Handled = true;
						}
					}
				}
				else if ((float)Math.Abs(args.X) <= num)
				{
					XTextTableColumnElement ownerColumn = OwnerColumn;
					ownerColumn = (XTextTableColumnElement)OwnerTable.Columns.GetPreElement(ownerColumn);
					if (ownerColumn != null && OwnerDocument.DocumentControler.CanModify(this, domAccessFlags) && OwnerTable.RuntimeAllowUserToResizeColumns)
					{
						args.Cursor = Cursors.VSplit;
						if (args.Style == DocumentEventStyles.MouseDown && args.StrictMatch && ownerColumn != null)
						{
							method_66(ownerColumn, args);
						}
					}
				}
				else if ((float)Math.Abs(args.Y) <= num)
				{
					XTextTableRowElement lastOwnerRow = LastOwnerRow;
					lastOwnerRow = (XTextTableRowElement)lastOwnerRow.PreviousElement;
					if (lastOwnerRow != null && OwnerDocument.DocumentControler.CanModify(this, domAccessFlags) && lastOwnerRow.RuntimeAllowUserToResizeHeight)
					{
						args.Cursor = Cursors.HSplit;
						if (args.Style == DocumentEventStyles.MouseDown && args.StrictMatch)
						{
							method_64(lastOwnerRow, args);
						}
					}
				}
				else if (Math.Abs((float)args.Y - Height) <= num)
				{
					if (OwnerDocument.DocumentControler.CanModify(this, domAccessFlags) && LastOwnerRow.RuntimeAllowUserToResizeHeight)
					{
						args.Cursor = Cursors.HSplit;
						if (args.Style == DocumentEventStyles.MouseDown && args.StrictMatch)
						{
							method_64(LastOwnerRow, args);
						}
					}
				}
				else if (Math.Abs((float)args.X - Width) <= num && OwnerDocument.DocumentControler.CanModify(this, domAccessFlags) && OwnerTable.RuntimeAllowUserToResizeColumns)
				{
					args.Cursor = Cursors.VSplit;
					if (args.Style == DocumentEventStyles.MouseDown && args.StrictMatch)
					{
						method_66(LastOwnerColumn, args);
					}
				}
			}
			else
			{
				base.HandleDocumentEvent(args);
			}
		}

		private void method_64(XTextTableRowElement xtextTableRowElement_0, DocumentEventArgs documentEventArgs_0)
		{
			if (!OwnerDocument.EditorControl.UIStartEditContentSpecifyElement(this) || !xtextTableRowElement_0.RuntimeAllowUserToResizeHeight)
			{
				return;
			}
			WriterControl editorControl = OwnerDocument.EditorControl;
			editorControl.InnerViewControl.gclass435_1 = editorControl.method_23(this);
			Point[] array = editorControl.InnerViewControl.vmethod_20(method_67, Rectangle.Empty, null);
			editorControl.InnerViewControl.gclass435_1 = null;
			if (array != null)
			{
				documentEventArgs_0.Handled = true;
				if (editorControl.UIStartEditContentSpecifyElement(this))
				{
					float newHeight = xtextTableRowElement_0.Height + (float)array[1].Y - (float)array[0].Y;
					xtextTableRowElement_0.EditorSetRowSpecifyHeight(newHeight, logUndo: true);
				}
			}
		}

		private bool method_65(DocumentEventArgs documentEventArgs_0, bool bool_26)
		{
			WriterControl editorControl = OwnerDocument.EditorControl;
			editorControl.InnerViewControl.PagesTransform.method_33(bool_1: true);
			Point[] array = editorControl.InnerViewControl.vmethod_20(method_68, Rectangle.Empty, null);
			if (array != null)
			{
				documentEventArgs_0.Handled = true;
				float num = array[1].X - array[0].X;
				if (num <= 0f)
				{
					return false;
				}
				if (!editorControl.UIStartEditContent())
				{
					return false;
				}
				XTextDocument ownerDocument = OwnerDocument;
				XTextTableElement ownerTable = OwnerTable;
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)ownerTable.Columns[0];
				num = Math.Min(num, xTextTableColumnElement.Width - ownerDocument.Options.ViewOptions.MinTableColumnWidth);
				XTextUndoTableInfo xTextUndoTableInfo = null;
				if (bool_26)
				{
					xTextUndoTableInfo = new XTextUndoTableInfo();
					xTextUndoTableInfo.OldTableInfo = new Class116(ownerTable, bool_0: false);
				}
				float height = ownerTable.Height;
				ownerTable.LeftIndent += num;
				xTextTableColumnElement.Width -= num;
				UpdateContentVersion();
				ownerTable.InvalidateView();
				foreach (XTextTableRowElement row in ownerTable.Rows)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)row.Cells.FirstElement;
					xTextTableCellElement.Width = 0f;
					xTextTableCellElement.SizeInvalid = true;
				}
				ownerTable.ExecuteLayout();
				ownerTable.InvalidateView();
				if (height != ownerTable.Height)
				{
					ownerTable.method_41(bool_26: false);
				}
				editorControl?.UpdateTextCaretWithoutScroll();
				if (xTextUndoTableInfo != null)
				{
					xTextUndoTableInfo.NewTableInfo = new Class116(ownerTable, bool_0: false);
				}
				if (ownerDocument.BeginLogUndo())
				{
					ownerDocument.UndoList.method_14(xTextUndoTableInfo);
					ownerDocument.EndLogUndo();
				}
				ownerDocument.OnSelectionChanged();
				ownerDocument.OnDocumentContentChanged();
				return true;
			}
			return false;
		}

		private void method_66(XTextTableColumnElement xtextTableColumnElement_1, DocumentEventArgs documentEventArgs_0)
		{
			if (!OwnerDocument.EditorControl.UIStartEditContentSpecifyElement(this) || !OwnerTable.RuntimeAllowUserToResizeColumns)
			{
				return;
			}
			OwnerDocument.EditorControl.InnerViewControl.PagesTransform.method_33(bool_1: true);
			Point[] array = OwnerDocument.EditorControl.InnerViewControl.vmethod_20(method_68, Rectangle.Empty, null);
			if (array == null)
			{
				return;
			}
			documentEventArgs_0.Handled = true;
			if (!OwnerDocument.EditorControl.UIStartEditContentSpecifyElement(this))
			{
				return;
			}
			float float_ = xtextTableColumnElement_1.Width + (float)array[1].X - (float)array[0].X;
			float num = array[1].X - array[0].X;
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
			{
				xtextTableColumnElement_1.method_13(float_, bool_7: true, bool_8: false);
			}
			else
			{
				XTextSelection selection = OwnerDocument.Selection;
				XTextTableCellElement xTextTableCellElement = null;
				XTextTableCellElement xTextTableCellElement2 = null;
				if (selection.Mode == ContentRangeMode.Cell)
				{
					XTextElementList cellsWithoutOverried = selection.CellsWithoutOverried;
					if (cellsWithoutOverried != null && cellsWithoutOverried.Count == 1)
					{
						xTextTableCellElement2 = (XTextTableCellElement)cellsWithoutOverried[0];
						XTextTableRowElement ownerRow = xTextTableCellElement2.OwnerRow;
						xTextTableCellElement = (XTextTableCellElement)ownerRow.Cells[xtextTableColumnElement_1.Index];
						if (xTextTableCellElement.OverrideCell != null)
						{
							xTextTableCellElement = xTextTableCellElement.OverrideCell;
						}
						if (xTextTableCellElement != null)
						{
							if (xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan == OwnerTable.Columns.Count)
							{
								xTextTableCellElement = null;
							}
							else if (RowIndex < xTextTableCellElement.RowIndex || RowIndex >= xTextTableCellElement.RowIndex + xTextTableCellElement.RowSpan)
							{
								xTextTableCellElement = null;
							}
							else if (xtextTableColumnElement_1 != xTextTableCellElement.OwnerColumn && xtextTableColumnElement_1 != xTextTableCellElement.LastOwnerColumn)
							{
								xTextTableCellElement = null;
							}
						}
					}
				}
				if (xTextTableCellElement != null)
				{
					if (!xTextTableCellElement.EditorSetCellWidthSingle(xTextTableCellElement.Width + num, logUndo: true))
					{
						xtextTableColumnElement_1.method_13(float_, bool_7: true, bool_8: true);
					}
				}
				else
				{
					xtextTableColumnElement_1.method_13(float_, bool_7: true, bool_8: true);
				}
				xTextTableCellElement2?.Select();
			}
			documentEventArgs_0.Handled = true;
		}

		private void method_67(object sender, CaptureMouseMoveEventArgs e)
		{
			RectangleF absBounds = OwnerTable.AbsBounds;
			OwnerDocument.EditorControl.InnerViewControl.method_20((int)absBounds.Left, e.method_5().Y, (int)absBounds.Right, e.method_5().Y);
		}

		private void method_68(object sender, CaptureMouseMoveEventArgs e)
		{
			RectangleF absBounds = OwnerTable.AbsBounds;
			OwnerDocument.EditorControl.InnerViewControl.method_20(e.method_5().X, (int)absBounds.Top, e.method_5().X, (int)absBounds.Bottom);
		}

		private void method_69(XTextTableCellElement xtextTableCellElement_1, int int_19, int int_20)
		{
			XTextTableElement ownerTable = OwnerTable;
			_ = xtextTableCellElement_1.OwnerRow;
			for (int i = xtextTableCellElement_1.RowIndex + 1; i < ownerTable.Rows.Count && i <= int_20; i++)
			{
				XTextTableCellElement cell = ownerTable.GetCell(i, xtextTableCellElement_1.ColIndex, throwException: false);
				if (cell == null || cell.ColSpan != xtextTableCellElement_1.ColSpan || cell.IsOverrided)
				{
					break;
				}
				cell.method_60(int_19);
			}
			xtextTableCellElement_1.method_60(int_19);
		}

		/// <summary>
		///       设置单元格的边框线颜色
		///       </summary>
		/// <param name="direction">边框方向</param>
		/// <param name="borderVisible">边框是否可见</param>
		/// <param name="color">颜色</param>
		/// <returns>操作是否成功</returns>
		
		public bool EditorSetBorderColor(DCDirection direction, bool borderVisible, Color color)
		{
			XTextTableCellElement xTextTableCellElement = this;
			if (xTextTableCellElement.OverrideCell != null)
			{
				xTextTableCellElement = xTextTableCellElement.OverrideCell;
			}
			if (xTextTableCellElement.OwnerTable == null || xTextTableCellElement.OwnerDocument == null)
			{
				return false;
			}
			switch (direction)
			{
			case DCDirection.Left:
			{
				xTextTableCellElement.Style.BorderLeft = borderVisible;
				xTextTableCellElement.Style.BorderLeftColor = color;
				XTextTableCellElement xTextTableCellElement2 = OwnerTable.GetCell(xTextTableCellElement.RowIndex, xTextTableCellElement.ColIndex - 1, throwException: false);
				if (xTextTableCellElement2 != null)
				{
					if (xTextTableCellElement2.OverrideCell != null)
					{
						xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
					}
					xTextTableCellElement2.Style.BorderRight = borderVisible;
					xTextTableCellElement2.Style.BorderRightColor = color;
				}
				break;
			}
			case DCDirection.Top:
			{
				xTextTableCellElement.Style.BorderTop = borderVisible;
				xTextTableCellElement.Style.BorderTopColor = color;
				XTextTableCellElement xTextTableCellElement2 = OwnerTable.GetCell(xTextTableCellElement.RowIndex - 1, xTextTableCellElement.ColIndex, throwException: false);
				if (xTextTableCellElement2 != null)
				{
					if (xTextTableCellElement2.OverrideCell != null)
					{
						xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
					}
					xTextTableCellElement2.Style.BorderBottom = borderVisible;
					xTextTableCellElement2.Style.BorderBottomColor = color;
				}
				break;
			}
			case DCDirection.Right:
			{
				xTextTableCellElement.Style.BorderRight = borderVisible;
				xTextTableCellElement.Style.BorderRightColor = color;
				XTextTableCellElement xTextTableCellElement2 = OwnerTable.GetCell(xTextTableCellElement.RowIndex, xTextTableCellElement.ColIndex + 1, throwException: false);
				if (xTextTableCellElement2 != null)
				{
					if (xTextTableCellElement2.OverrideCell != null)
					{
						xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
					}
					xTextTableCellElement2.Style.BorderLeft = borderVisible;
					xTextTableCellElement2.Style.BorderLeftColor = color;
				}
				break;
			}
			case DCDirection.Bottom:
			{
				xTextTableCellElement.Style.BorderBottom = borderVisible;
				xTextTableCellElement.Style.BorderBottomColor = color;
				XTextTableCellElement xTextTableCellElement2 = OwnerTable.GetCell(xTextTableCellElement.RowIndex + 1, xTextTableCellElement.ColIndex, throwException: false);
				if (xTextTableCellElement2 != null)
				{
					if (xTextTableCellElement2.OverrideCell != null)
					{
						xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
					}
					xTextTableCellElement2.Style.BorderTop = borderVisible;
					xTextTableCellElement2.Style.BorderTopColor = color;
				}
				break;
			}
			}
			xTextTableCellElement.InvalidateView();
			return true;
		}

		/// <summary>
		///       单独的设置单元格的宽度
		///       </summary>
		/// <param name="newWidth">新宽度</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		[ComVisible(true)]
		
		public bool EditorSetCellWidthSingle(float newWidth, bool logUndo)
		{
			float minTableColumnWidth = OwnerDocument.Options.ViewOptions.MinTableColumnWidth;
			if (Math.Abs(newWidth - Width) < minTableColumnWidth / 5f)
			{
				return false;
			}
			XTextTableElement ownerTable = OwnerTable;
			_ = ColIndex;
			if (ColIndex + ColSpan >= ownerTable.Columns.Count)
			{
				return false;
			}
			XTextTableRowElement ownerRow = OwnerRow;
			if (newWidth > Width)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)ownerRow.Cells[ColIndex + ColSpan];
				if (xTextTableCellElement.OverrideCell != null)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				newWidth = Math.Min(newWidth, xTextTableCellElement.Width + Width - minTableColumnWidth);
			}
			if (newWidth < minTableColumnWidth)
			{
				newWidth = minTableColumnWidth;
			}
			new XTextElementList();
			int num = -1;
			int num2 = 0;
			while (true)
			{
				if (num2 < RowSpan)
				{
					XTextTableCellElement xTextTableCellElement = ownerTable.GetCell(num2 + RowIndex, ColIndex + ColSpan, throwException: true);
					if (xTextTableCellElement.IsOverrided)
					{
						xTextTableCellElement = xTextTableCellElement.OverrideCell;
					}
					if (xTextTableCellElement.RowIndex >= RowIndex)
					{
						if (xTextTableCellElement.RowIndex + xTextTableCellElement.RowSpan > RowIndex + RowSpan)
						{
							break;
						}
						num = ((!(newWidth < Width)) ? ((num != -1) ? Math.Min(num, xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan) : (xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan)) : ((num != -1) ? Math.Min(num, xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan) : (xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan)));
						num2++;
						continue;
					}
					return false;
				}
				if (num >= ownerTable.Columns.Count)
				{
					num = ownerTable.Columns.Count - 1;
				}
				XTextUndoTableInfo xTextUndoTableInfo = null;
				if (logUndo)
				{
					xTextUndoTableInfo = new XTextUndoTableInfo();
					xTextUndoTableInfo.OldTableInfo = new Class116(ownerTable, bool_0: false);
				}
				float num3 = 0f;
				bool flag = false;
				for (int i = ColIndex; i <= num; i++)
				{
					num3 += ownerTable.Columns[i].Width;
					if (!(Math.Abs(num3 - newWidth) < minTableColumnWidth * 0.4f))
					{
						if (!(num3 > newWidth))
						{
							continue;
						}
						XTextTableColumnElement xTextTableColumnElement = ownerTable.CreateColumnInstance();
						xTextTableColumnElement.Width = num3 - newWidth;
						((XTextTableColumnElement)ownerTable.Columns[i]).Width -= xTextTableColumnElement.Width;
						using (DCGraphics dcgraphics_ = ownerTable.OwnerDocument.CreateDCGraphics())
						{
							for (num2 = 0; num2 < ownerTable.Rows.Count; num2++)
							{
								XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)ownerTable.Rows[num2];
								XTextTableCellElement xTextTableCellElement2 = ownerTable.CreateCellInstance();
								xTextTableCellElement2.OwnerDocument = OwnerDocument;
								xTextTableCellElement2.StyleIndex = StyleIndex;
								xTextTableCellElement2.FixElements();
								DocumentPaintEventArgs documentPaintEventArgs = ownerTable.OwnerDocument.method_55(dcgraphics_);
								documentPaintEventArgs.Element = xTextTableCellElement2;
								xTextTableCellElement2.RefreshSize(documentPaintEventArgs);
								xTextTableCellElement2.Width = 0f;
								xTextTableCellElement2.Height = 0f;
								xTextTableCellElement2.Parent = xTextTableRowElement;
								xTextTableCellElement2.OwnerDocument = OwnerDocument;
								xTextTableRowElement.Cells.method_13(i + 1, xTextTableCellElement2);
								xTextTableRowElement.FixDomState();
							}
						}
						ownerTable.Columns.method_13(i + 1, xTextTableColumnElement);
						for (num2 = 0; num2 < ownerTable.Rows.Count; num2++)
						{
							XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)ownerTable.Rows[num2];
							if (num2 < RowIndex || num2 >= RowIndex + RowSpan)
							{
								XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextTableRowElement.Cells[i];
								if (xTextTableCellElement3.IsOverrided)
								{
									xTextTableCellElement3 = ((xTextTableCellElement3.RowIndex != xTextTableCellElement3.OverrideCell.RowIndex) ? null : xTextTableCellElement3.OverrideCell);
								}
								xTextTableCellElement3?.method_60(xTextTableCellElement3.ColSpan + 1);
							}
							else if (newWidth > Width)
							{
								XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[ColIndex + ColSpan];
								int num4 = xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan;
								xTextTableRowElement.Cells.MoveElement(xTextTableRowElement.Cells.IndexOf(xTextTableCellElement), i + 1);
								xTextTableCellElement.method_60(num4 - xTextTableRowElement.Cells.IndexOf(xTextTableCellElement) + 1);
							}
							else
							{
								XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[ColIndex + ColSpan + 1];
								int num5 = xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan;
								xTextTableRowElement.Cells.MoveElement(xTextTableRowElement.Cells.IndexOf(xTextTableCellElement), i + 1);
								xTextTableCellElement.method_60(num5 - i - 1);
							}
						}
						if (newWidth > Width)
						{
							method_60(i - ColIndex + 1);
						}
						else
						{
							method_60(i - ColIndex + 1);
						}
						flag = true;
						break;
					}
					if (i + 1 < ownerTable.Columns.Count)
					{
						for (num2 = 0; num2 < RowSpan; num2++)
						{
							XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)ownerTable.Rows[num2 + RowIndex];
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[ColIndex + ColSpan];
							int num5 = xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan;
							xTextTableRowElement.Cells.MoveElement(xTextTableRowElement.Cells.IndexOf(xTextTableCellElement), i + 1);
							xTextTableCellElement.method_60(num5 - i - 1);
						}
						method_60(i - ColIndex + 1);
						flag = true;
					}
					break;
				}
				if (flag)
				{
					ownerTable.FixDomState();
					UpdateContentVersion();
					ownerTable.method_35();
					if (ownerTable.method_44())
					{
						ownerTable.method_35();
					}
					vmethod_36(bool_22: true);
					_ = base.DocumentContentElement.Content;
					ownerTable.InvalidateView();
					using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
					{
						ownerTable.method_32(dcgraphics_);
					}
					ownerTable.ExecuteLayout();
					ownerTable.InvalidateView();
					ownerTable.method_41(bool_26: false);
					base.DocumentContentElement.SetSelection(FirstContentElement.ViewIndex, LastContentElement.ViewIndex - FirstContentElement.ViewIndex + 1);
					if (xTextUndoTableInfo != null)
					{
						xTextUndoTableInfo.NewTableInfo = new Class116(ownerTable, bool_0: false);
						xTextUndoTableInfo.method_0();
						if (OwnerDocument.BeginLogUndo())
						{
							OwnerDocument.UndoList.method_14(xTextUndoTableInfo);
							OwnerDocument.EndLogUndo();
						}
					}
					OwnerDocument.OnSelectionChanged();
					OwnerDocument.OnDocumentContentChanged();
				}
				return flag;
			}
			return false;
		}

		/// <summary>
		///       编辑器中拆分单元格
		///       </summary>
		/// <param name="newRowsNum">新的横向合并行数,该行数必须是单元格跨行数的约数</param>
		/// <param name="newColsNum">新的纵向合并列数</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否成功</returns>
		
		public bool EditorSplitCellExt(int newRowsNum, int newColsNum, bool logUndo)
		{
			if (newRowsNum < 1 || newColsNum < 1)
			{
				return false;
			}
			if (newRowsNum == 1 && newColsNum == 1)
			{
				return false;
			}
			bool flag = false;
			if (RowSpan > 1)
			{
				int[] array = MathCommon.smethod_3(RowSpan);
				for (int i = 0; i < array.Length; i++)
				{
					if (newRowsNum == array[i])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			XTextTableElement ownerTable = OwnerTable;
			ownerTable.FixDomState();
			XTextUndoTableInfo xTextUndoTableInfo = null;
			if (logUndo)
			{
				xTextUndoTableInfo = new XTextUndoTableInfo();
				xTextUndoTableInfo.OldTableInfo = new Class116(ownerTable, bool_0: true);
			}
			bool flag2 = false;
			int rowIndex = RowIndex;
			int colIndex = ColIndex;
			int colSpan = ColSpan;
			int num = RowSpan / newRowsNum;
			int num2 = RowSpan;
			if (num2 == 1)
			{
				num = 1;
			}
			float width = Width;
			if (newRowsNum == RowSpan && newColsNum == ColSpan)
			{
				XTextElementList range = ownerTable.GetRange(RowIndex, ColIndex, RowSpan, ColSpan, includeOverriedCell: true);
				foreach (XTextTableCellElement item in range)
				{
					item.method_60(1);
					item.method_61(1);
					item.method_57(null);
					item.Width = 0f;
					item.Height = 0f;
					item.SizeInvalid = true;
				}
				flag2 = true;
			}
			else
			{
				if (newRowsNum > 1)
				{
					if (num2 == 1)
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)ownerTable.Rows[rowIndex];
						float num3 = xTextTableRowElement.RuntimeSpecifyHeight;
						if (num3 > 0f)
						{
							num3 = (xTextTableRowElement.SpecifyHeight = num3 / (float)newRowsNum);
						}
						for (int j = 1; j < newRowsNum; j++)
						{
							XTextTableRowElement xTextTableRowElement2 = ownerTable.CreateRowInstance();
							xTextTableRowElement2.SpecifyHeight = num3;
							xTextTableRowElement2.StyleIndex = xTextTableRowElement.StyleIndex;
							xTextTableRowElement2.Parent = ownerTable;
							xTextTableRowElement2.OwnerDocument = OwnerDocument;
							foreach (XTextTableCellElement cell in xTextTableRowElement.Cells)
							{
								XTextTableCellElement xTextTableCellElement2 = ownerTable.CreateCellInstance(cell);
								xTextTableCellElement2.Parent = xTextTableRowElement2;
								xTextTableCellElement2.OwnerDocument = OwnerDocument;
								xTextTableCellElement2.Width = 0f;
								xTextTableCellElement2.Height = 0f;
								xTextTableCellElement2.SizeInvalid = true;
								xTextTableCellElement2.method_61(1);
								xTextTableCellElement2.method_60(1);
								xTextTableCellElement2.FixElements();
								xTextTableRowElement2.Cells.Add(xTextTableCellElement2);
							}
							ownerTable.Rows.method_13(rowIndex + 1, xTextTableRowElement2);
						}
						List<XTextTableCellElement> list = new List<XTextTableCellElement>();
						for (int k = 0; k < ownerTable.Columns.Count; k++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[k];
							if (xTextTableCellElement.OverrideCell != null)
							{
								xTextTableCellElement = xTextTableCellElement.OverrideCell;
							}
							if (!list.Contains(xTextTableCellElement))
							{
								list.Add(xTextTableCellElement);
								if (k < colIndex || k >= colIndex + colSpan)
								{
									xTextTableCellElement.method_61(xTextTableCellElement.RowSpan + newRowsNum - 1);
									xTextTableCellElement.Width = 0f;
								}
							}
						}
						num2 = num;
					}
					else
					{
						for (int j = 0; j < num2; j++)
						{
							XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)ownerTable.Rows[rowIndex + j];
							for (int k = 0; k < ColSpan; k++)
							{
								XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement3.Cells[colIndex + k];
								if (j % newRowsNum == 0)
								{
									xTextTableCellElement.method_61(num);
								}
								else
								{
									xTextTableCellElement.method_61(1);
								}
								xTextTableCellElement.Width = 0f;
								xTextTableCellElement.Height = 0f;
							}
						}
					}
					flag2 = true;
				}
				if (newColsNum == ColSpan)
				{
					if (ColSpan > 1)
					{
						XTextElementList range = ownerTable.GetRange(RowIndex, ColIndex, num2, ColSpan, includeOverriedCell: true);
						foreach (XTextTableCellElement item2 in range)
						{
							item2.method_60(1);
							item2.Width = 0f;
							item2.Height = 0f;
							if (item2.RowIndex == RowIndex)
							{
								item2.method_61(num);
							}
							item2.SizeInvalid = true;
						}
						flag2 = true;
					}
				}
				else
				{
					flag2 = true;
					List<Class12> list2 = new List<Class12>();
					float num5 = 0f;
					for (int k = 0; k < ColSpan; k++)
					{
						XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)ownerTable.Columns[k + colIndex];
						Class12 @class = new Class12();
						@class.float_0 = num5;
						@class.float_1 = xTextTableColumnElement.Width;
						@class.xtextTableColumnElement_0 = xTextTableColumnElement;
						list2.Add(@class);
						num5 += xTextTableColumnElement.Width;
					}
					float num6 = width / (float)newColsNum;
					for (int k = 0; k < newColsNum; k++)
					{
						float num7 = num6 * (float)k;
						bool flag3 = false;
						for (int i = 0; i < list2.Count; i++)
						{
							if ((double)Math.Abs(num7 - list2[i].float_0) < (double)num6 * 0.2)
							{
								list2[i].bool_0 = true;
								num7 = list2[i].float_0;
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							Class12 @class = new Class12();
							@class.float_0 = num7;
							@class.bool_0 = true;
							list2.Add(@class);
						}
					}
					list2.Sort();
					for (int i = 0; i < list2.Count; i++)
					{
						list2[i].int_0 = i;
						if (i > 0)
						{
							list2[i - 1].float_1 = list2[i].float_0 - list2[i - 1].float_0;
						}
					}
					list2[list2.Count - 1].float_1 = width - list2[list2.Count - 1].float_0;
					Class12 class2 = null;
					for (int i = 0; i < list2.Count; i++)
					{
						Class12 @class = list2[i];
						XTextTableColumnElement xTextTableColumnElement2 = ownerTable.CreateColumnInstance();
						xTextTableColumnElement2.OwnerDocument = OwnerDocument;
						xTextTableColumnElement2.Parent = ownerTable;
						xTextTableColumnElement2.Width = @class.float_1;
						xTextTableColumnElement2.xtextElementList_0 = new XTextElementList();
						@class.xtextTableColumnElement_1 = xTextTableColumnElement2;
						if (@class.xtextTableColumnElement_0 != null)
						{
							XTextElementList cells = @class.xtextTableColumnElement_0.Cells;
							foreach (XTextTableCellElement item3 in cells)
							{
								xTextTableColumnElement2.xtextElementList_0.Add(item3);
							}
							class2 = @class;
						}
						else
						{
							XTextElementList cells = class2.xtextTableColumnElement_0.Cells;
							foreach (XTextTableCellElement item4 in cells)
							{
								XTextTableCellElement xTextTableCellElement2 = ownerTable.CreateCellInstance(item4);
								xTextTableCellElement2.OwnerDocument = OwnerDocument;
								xTextTableCellElement2.Parent = item4.Parent;
								xTextTableColumnElement2.xtextElementList_0.Add(xTextTableCellElement2);
								int j = cells.IndexOf(item4);
								if (j < rowIndex || j >= rowIndex + newRowsNum)
								{
									if (item4.OverrideCell != null)
									{
										XTextTableCellElement overrideCell = item4.OverrideCell;
										if (overrideCell.OwnerRow == item4.OwnerRow)
										{
											overrideCell.method_60(overrideCell.ColSpan + 1);
										}
									}
									else
									{
										item4.method_60(item4.ColSpan + 1);
									}
								}
							}
						}
						if (!@class.bool_0)
						{
							continue;
						}
						if (i == list2.Count - 1)
						{
							for (int j = rowIndex; j < rowIndex + newRowsNum; j++)
							{
								XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)@class.xtextTableColumnElement_1.xtextElementList_0[j];
								xTextTableCellElement.method_60(1);
								xTextTableCellElement.Width = 0f;
							}
						}
						else
						{
							for (int l = i + 1; l < list2.Count; l++)
							{
								int num8 = -1;
								if (l == list2.Count - 1)
								{
									num8 = l - i;
									if (newColsNum < colSpan && !list2[l].bool_0)
									{
										num8++;
									}
								}
								else if (list2[l].bool_0)
								{
									num8 = l - i;
								}
								if (num8 > 0)
								{
									for (int j = rowIndex; j < rowIndex + newRowsNum; j++)
									{
										XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)@class.xtextTableColumnElement_1.xtextElementList_0[j];
										xTextTableCellElement.method_60(num8);
										xTextTableCellElement.Width = 0f;
									}
								}
								if (num8 > 0)
								{
									break;
								}
							}
						}
						for (int j = rowIndex; j < rowIndex + num2; j += num)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)@class.xtextTableColumnElement_1.xtextElementList_0[j];
							xTextTableCellElement.method_61(num);
							xTextTableCellElement.Width = 0f;
						}
					}
					using (DCGraphics dcgraphics_ = ownerTable.OwnerDocument.CreateDCGraphics())
					{
						DocumentPaintEventArgs documentPaintEventArgs = ownerTable.OwnerDocument.method_55(dcgraphics_);
						for (int i = 0; i < list2.Count; i++)
						{
							Class12 @class = list2[i];
							if (@class.bool_0)
							{
								foreach (XTextTableCellElement item5 in @class.xtextTableColumnElement_1.xtextElementList_0)
								{
									if (item5.IsOverrided)
									{
										documentPaintEventArgs.Element = item5;
										item5.FixElements();
										item5.RefreshSize(documentPaintEventArgs);
									}
								}
							}
						}
					}
					for (int i = colIndex + colSpan - 1; i >= colIndex; i--)
					{
						ownerTable.Columns.method_15(i);
						foreach (XTextTableRowElement row in ownerTable.Rows)
						{
							row.Cells.method_15(i);
						}
					}
					for (int i = 0; i < list2.Count; i++)
					{
						XTextTableColumnElement xTextTableColumnElement = list2[i].xtextTableColumnElement_1;
						ownerTable.Columns.method_13(colIndex + i, xTextTableColumnElement);
						for (int j = 0; j < ownerTable.Rows.Count; j++)
						{
							XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)ownerTable.Rows[j];
							XTextTableCellElement xtextElement_ = (XTextTableCellElement)xTextTableColumnElement.xtextElementList_0[j];
							xTextTableRowElement3.Cells.method_13(colIndex + i, xtextElement_);
						}
						xTextTableColumnElement.xtextElementList_0 = null;
					}
				}
			}
			if (flag2)
			{
				ownerTable.FixDomState();
				UpdateContentVersion();
				ownerTable.method_35();
				if (ownerTable.method_44())
				{
					ownerTable.method_35();
				}
				foreach (XTextTableCellElement cell2 in ownerTable.Cells)
				{
					cell2.FixElements();
				}
				if (!BelongToDocumentDom(OwnerDocument, checkLogicDelete: false))
				{
					return flag2;
				}
				if (base.DocumentContentElement != null)
				{
					base.DocumentContentElement.method_70();
				}
				vmethod_36(bool_22: true);
				ownerTable.InvalidateView();
				using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
				{
					ownerTable.method_32(dcgraphics_);
				}
				ownerTable.method_33(bool_26: false);
				ownerTable.InvalidateView();
				ownerTable.method_41(bool_26: false);
				if (base.DocumentContentElement != null)
				{
					base.DocumentContentElement.SetSelection(FirstContentElement.ViewIndex, LastContentElement.ViewIndex - FirstContentElement.ViewIndex);
				}
				if (xTextUndoTableInfo != null)
				{
					xTextUndoTableInfo.NewTableInfo = new Class116(ownerTable, bool_0: true);
					xTextUndoTableInfo.method_0();
					if (OwnerDocument.BeginLogUndo())
					{
						OwnerDocument.UndoList.method_14(xTextUndoTableInfo);
						OwnerDocument.EndLogUndo();
						OwnerDocument.OnSelectionChanged();
						OwnerDocument.OnDocumentContentChanged();
					}
				}
			}
			return flag2;
		}

		
		public bool method_70(int int_19, int int_20, bool bool_26, Dictionary<XTextTableCellElement, XTextElementList> dictionary_1)
		{
			int_19 = method_58(int_19);
			int_20 = method_59(int_20);
			if (int_19 == RowSpan && int_20 == ColSpan)
			{
				return false;
			}
			XTextUndoTableInfo xTextUndoTableInfo = null;
			if (bool_26)
			{
				xTextUndoTableInfo = new XTextUndoTableInfo();
				xTextUndoTableInfo.OldTableInfo = new Class116(OwnerTable, bool_0: true);
			}
			XTextTableElement ownerTable = OwnerTable;
			DocumentContentStyle documentContentStyle = RuntimeStyle.CloneParent();
			documentContentStyle.DisableDefaultValue = true;
			bool flag = false;
			if (ColSpan < int_20)
			{
				XTextTableCellElement cell = ownerTable.GetCell(RowIndex, ColIndex + int_20 - 1, throwException: false);
				if (!(cell?.IsOverrided ?? true))
				{
					documentContentStyle.BorderRight = cell.RuntimeStyle.BorderRight;
					documentContentStyle.BorderRightColor = cell.RuntimeStyle.BorderRightColor;
					flag = true;
				}
			}
			if (RowSpan < int_19)
			{
				XTextTableCellElement cell2 = ownerTable.GetCell(RowIndex + int_19 - 1, ColIndex, throwException: false);
				if (!(cell2?.IsOverrided ?? true))
				{
					documentContentStyle.BorderBottom = cell2.RuntimeStyle.BorderBottom;
					documentContentStyle.BorderBottomColor = cell2.RuntimeStyle.BorderBottomColor;
					flag = true;
				}
			}
			int styleIndex = StyleIndex;
			int num = styleIndex;
			if (flag)
			{
				num = OwnerDocument.ContentStyles.GetStyleIndex(documentContentStyle);
			}
			if (dictionary_1 != null)
			{
				foreach (XTextTableCellElement key in dictionary_1.Keys)
				{
					XTextElementList collection = dictionary_1[key];
					key.Elements.Clear();
					key.Elements.AddRange(collection);
					foreach (XTextElement element in key.Elements)
					{
						element.Parent = key;
						element.OwnerDocument = OwnerDocument;
					}
					key.vmethod_36(bool_22: false);
					key.Width = 0f;
				}
			}
			else
			{
				XTextElementList range = ownerTable.GetRange(RowIndex, ColIndex, int_13, int_14, includeOverriedCell: true);
				XTextElementList range2 = ownerTable.GetRange(RowIndex, ColIndex, int_19, int_20, includeOverriedCell: true);
				foreach (XTextTableCellElement item in range)
				{
					if (!range2.Contains(item))
					{
						item.vmethod_36(bool_22: false);
						item.Width = 0f;
					}
				}
				XTextElementList xTextElementList = new XTextElementList();
				foreach (XTextTableCellElement item2 in range2)
				{
					if (item2 != this && item2.OverrideCell == null && item2.Elements.Count > 1)
					{
						xTextElementList.AddRange(item2.Elements);
						item2.Elements.Clear();
						item2.Width = 0f;
						item2.vmethod_36(bool_22: false);
					}
				}
				for (int num2 = xTextElementList.Count - 2; num2 >= 0; num2--)
				{
					if (xTextElementList[num2] is XTextParagraphFlagElement)
					{
						XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElementList[num2];
						if (xTextParagraphFlagElement.AutoCreate)
						{
							xTextElementList.method_15(num2);
						}
					}
				}
				Elements.AddRange(xTextElementList);
				foreach (XTextElement item3 in xTextElementList)
				{
					item3.Parent = this;
				}
			}
			int_13 = int_19;
			int_14 = int_20;
			StyleIndex = num;
			Width = 0f;
			UpdateContentVersion();
			ownerTable.method_35();
			if (ownerTable.method_44())
			{
				ownerTable.method_35();
			}
			vmethod_36(bool_22: true);
			_ = base.DocumentContentElement.Content;
			base.DocumentContentElement.SetSelection(FirstContentElement.ViewIndex, LastContentElement.ViewIndex - FirstContentElement.ViewIndex);
			ownerTable.InvalidateView();
			ownerTable.ExecuteLayout();
			ownerTable.method_41(bool_26: true);
			ownerTable.InvalidateView();
			ownerTable.method_41(bool_26: false);
			if (xTextUndoTableInfo != null)
			{
				xTextUndoTableInfo.NewTableInfo = new Class116(ownerTable, bool_0: true);
				xTextUndoTableInfo.method_0();
				if (OwnerDocument.BeginLogUndo())
				{
					if (styleIndex != num)
					{
						OwnerDocument.UndoList.AddStyleIndex(this, styleIndex, num);
					}
					OwnerDocument.UndoList.method_14(xTextUndoTableInfo);
					OwnerDocument.EndLogUndo();
					OwnerDocument.OnSelectionChanged();
					OwnerDocument.OnDocumentContentChanged();
				}
			}
			return true;
		}

		/// <summary>
		///       计算元素大小
		///       </summary>
		/// <param name="args">参数</param>
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			base.LayoutInvalidate = true;
			base.RefreshSize(args);
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			gclass103_0.bool_4 = true;
			base.vmethod_19(gclass103_0);
		}

		private void method_71(bool bool_26)
		{
			throw new NotSupportedException("EditorDelete");
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否深度复制</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)base.Clone(Deeply);
			xTextTableCellElement.xtextTableColumnElement_0 = null;
			xTextTableCellElement.xtextTableCellElement_0 = null;
			return xTextTableCellElement;
		}

		public override string ToDebugString()
		{
			int num = 3;
			if (OwnerTable == null && string.IsNullOrEmpty(OwnerTable.ID))
			{
				return "Cell:" + CellID;
			}
			return "Cell:" + OwnerTable.ID + "!" + CellID;
		}

		/// <summary>
		///       为编辑器的上层操作而复制表格行对象
		///       </summary>
		/// <returns>复制品</returns>
		
		public XTextTableCellElement EditorClone()
		{
			TableRowCloneType cloneType = CloneType;
			if (cloneType == TableRowCloneType.Default && OwnerRow != null)
			{
				cloneType = OwnerRow.CloneType;
			}
			return EditorCloneSpecifyCloneType(cloneType);
		}

		/// <summary>
		///       指定复制模式的为编辑器复制表格行对象
		///       </summary>
		/// <param name="cloneType">复制模式</param>
		/// <returns>复制品</returns>
		
		public XTextTableCellElement EditorCloneSpecifyCloneType(TableRowCloneType cloneType)
		{
			switch (cloneType)
			{
			case TableRowCloneType.Complete:
				if (!XTextDocument.smethod_13(GEnum6.const_103))
				{
					cloneType = TableRowCloneType.Default;
				}
				break;
			case TableRowCloneType.ContentWithClearField:
				if (!XTextDocument.smethod_13(GEnum6.const_102))
				{
					cloneType = TableRowCloneType.Default;
				}
				break;
			}
			XTextTableCellElement xTextTableCellElement = null;
			switch (cloneType)
			{
			case TableRowCloneType.Default:
				xTextTableCellElement = (XTextTableCellElement)Clone(Deeply: false);
				break;
			case TableRowCloneType.ContentWithClearField:
				xTextTableCellElement = (XTextTableCellElement)Clone(Deeply: true);
				foreach (XTextElement element in xTextTableCellElement.Elements)
				{
					if (element is XTextFieldElementBase)
					{
						XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)element;
						xTextFieldElementBase.Elements.Clear();
						if (element is XTextInputFieldElementBase)
						{
							((XTextInputFieldElementBase)element).InnerValue = null;
						}
					}
				}
				break;
			case TableRowCloneType.Complete:
				xTextTableCellElement = (XTextTableCellElement)Clone(Deeply: true);
				break;
			}
			if (OwnerDocument.Options.EditOptions.CloneWithoutLogicDeletedContent)
			{
				WriterUtils.RemoveLogicDeletedElements(xTextTableCellElement.Elements);
			}
			xTextTableCellElement.RowSpan = 1;
			xTextTableCellElement.Parent = OwnerRow;
			xTextTableCellElement.method_57(null);
			xTextTableCellElement.dictionary_0 = null;
			xTextTableCellElement.FreeLayoutElements = null;
			xTextTableCellElement.FixElements();
			if (Elements.Count > 0)
			{
				xTextTableCellElement.Elements.LastElement.StyleIndex = Elements.LastElement.StyleIndex;
			}
			return xTextTableCellElement;
		}

		public override void Dispose()
		{
			base.Dispose();
			xtextTableCellElement_0 = null;
			xtextTableColumnElement_0 = null;
		}
	}
}
