using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms.Native;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom.Undo;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       表格元素
	///       </summary>
	/// <remarks>
	///       本表格支持多行多列，支持横向和纵向合并单元格
	///       编写  袁永福 2012-7-12</remarks>
	[Serializable]
	[Guid("00012345-6789-ABCD-EF01-234567890013")]
	[DebuggerDisplay("表格，{RowsCount}行,{ColumnsCount}列")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IXTextTableElement))]
	[DocumentComment]
	
	[ComClass("00012345-6789-ABCD-EF01-234567890013", "56FB6F65-8B16-36B3-854B-A69FF648795D")]
	[XmlType("XTextTable")]
	public sealed class XTextTableElement : XTextContainerElement, IXTextTableElement
	{
		private class Class21 : IComparer<XTextElement>
		{
			public IDCTableRowComparer idctableRowComparer_0 = null;

			public Class21(IDCTableRowComparer idctableRowComparer_1)
			{
				idctableRowComparer_0 = idctableRowComparer_1;
			}

			public int Compare(XTextElement xtextElement_0, XTextElement xtextElement_1)
			{
				return idctableRowComparer_0.CompareTableRow((XTextTableRowElement)xtextElement_0, (XTextTableRowElement)xtextElement_1);
			}
		}

		private class Class22 : IComparable<Class22>
		{
			public XTextTableCellElement xtextTableCellElement_0 = null;

			public float float_0 = 0f;

			public float float_1 = 0f;

			public int int_0 = 0;

			public float float_2 = 0f;

			public int CompareTo(Class22 other)
			{
				if (float_0 > other.float_0)
				{
					return 1;
				}
				if (float_0 < other.float_0)
				{
					return -1;
				}
				return 0;
			}
		}

		private class Class23 : IComparer<XTextElement>
		{
			public int Compare(XTextElement xtextElement_0, XTextElement xtextElement_1)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xtextElement_0;
				float num = xTextTableCellElement.Height - xTextTableCellElement.ContentHeight;
				XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xtextElement_1;
				float value = xTextTableCellElement2.Height - xTextTableCellElement2.ContentHeight;
				return num.CompareTo(value);
			}
		}

		private class Class14 : GClass3
		{
			private static Image image_1 = WriterResourcesCore.DragHandle;

			public Class14(XTextTableElement xtextTableElement_0)
			{
				method_21(Cursors.Arrow);
				method_7(xtextTableElement_0);
				method_9(xtextTableElement_0.OwnerDocument.DomImageList.GetBitmap(DCStdImageKey.DragHandle));
				if (method_8() == null)
				{
					method_9(image_1);
				}
				method_21(Cursors.Arrow);
				RectangleF absBounds = xtextTableElement_0.AbsBounds;
				method_15(GraphicsUnitConvert.Convert(method_8().Width, GraphicsUnit.Pixel, xtextTableElement_0.OwnerDocument.DocumentGraphicsUnit));
				method_17(method_14());
				method_11(absBounds.Left - method_14() - 5f);
				method_13(absBounds.Top);
			}

			public override void vmethod_0(DocumentPaintEventArgs documentPaintEventArgs_0)
			{
				if (documentPaintEventArgs_0.ActiveMode && documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint)
				{
					base.vmethod_0(documentPaintEventArgs_0);
				}
			}

			public override void vmethod_1(WriterMouseEventArgs writerMouseEventArgs_0)
			{
				if (method_18().Contains(writerMouseEventArgs_0.X, writerMouseEventArgs_0.Y) && writerMouseEventArgs_0.Button == MouseButtons.Left)
				{
					writerMouseEventArgs_0.Handled = true;
					method_6().Select();
					method_6().OwnerDocument.method_69(method_6());
					WriterViewControl innerViewControl = method_6().WriterControl.InnerViewControl;
					innerViewControl.Update();
					if (MouseCapturer.DragDetect(innerViewControl.Handle))
					{
						innerViewControl.method_161();
					}
				}
			}
		}

		internal const string string_14 = "00012345-6789-ABCD-EF01-234567890013";

		internal const string string_15 = "56FB6F65-8B16-36B3-854B-A69FF648795D";

		private bool bool_17 = false;

		private bool bool_18 = true;

		private bool bool_19 = false;

		private bool bool_20 = true;

		private bool bool_21 = true;

		private bool bool_22 = false;

		private bool bool_23 = true;

		private bool bool_24 = true;

		private RenderVisibility renderVisibility_0 = RenderVisibility.All;

		private RenderVisibility renderVisibility_1 = RenderVisibility.All;

		private DCBooleanValue dcbooleanValue_1 = DCBooleanValue.Inherit;

		private float float_5 = 0f;

		[NonSerialized]
		private XTextElementList xtextElementList_2 = null;

		private XTextElementList xtextElementList_3 = new XTextElementList();

		private bool bool_25 = true;

		private TableSubfieldMode tableSubfieldMode_0 = TableSubfieldMode.None;

		private int int_10 = 1;

		public override string DomDisplayName => "Table:" + base.ID;

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
		///       是否包含未处理的分页标记
		///       </summary>
		internal override bool ContainsUnHandledPageBreak
		{
			get
			{
				foreach (XTextTableRowElement runtimeRow in RuntimeRows)
				{
					if (runtimeRow.ContainsUnHandledPageBreak)
					{
						return true;
					}
				}
				return base.ContainsUnHandledPageBreak;
			}
			set
			{
				base.ContainsUnHandledPageBreak = value;
			}
		}

		/// <summary>
		///       压缩所在文档行的行间距
		///       </summary>
		[HtmlAttribute]
		[Category("Layout")]
		[DefaultValue(false)]
		
		public bool CompressOwnerLineSpacing
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

		/// <summary>
		///       在排版时占据整个一行
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable(MemberEffectLevel.ContentElementLayout)]
		[DefaultValue(true)]
		public bool HoldWholeLine
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

		/// <summary>
		///       在续打的时候打印所有单元格边框
		///       </summary>
		[DefaultValue(false)]
		public bool PrintBothBorderWhenJumpPrint
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
		///       文档元素编号前缀
		///       </summary>
		public override string ElementIDPrefix => "table";

		/// <summary>
		///       允许用户删除表格行
		///       </summary>
		
		[DefaultValue(true)]
		[ComVisible(true)]
		[MemberExpressionable]
		[Category("Behavior")]
		[HtmlAttribute]
		public bool AllowUserDeleteRow
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

		
		[Browsable(false)]
		[ComVisible(false)]
		public bool RuntimeAllowUserDeleteRow
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_93))
				{
					return AllowUserDeleteRow;
				}
				return true;
			}
		}

		/// <summary>
		///       允许用户新增表格行
		///       </summary>
		[MemberExpressionable]
		[ComVisible(true)]
		[DefaultValue(true)]
		[Category("Behavior")]
		
		[HtmlAttribute]
		public bool AllowUserInsertRow
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

		[ComVisible(false)]
		
		[Browsable(false)]
		public bool RuntimeAllowUserInsertRow
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_93))
				{
					return AllowUserInsertRow;
				}
				return true;
			}
		}

		/// <summary>
		///       即使在表单模式下用户仍然可以拖拽修改表格大小
		///       </summary>
		[Category("Behavior")]
		
		[MemberExpressionable]
		[ComVisible(true)]
		[DefaultValue(false)]
		[HtmlAttribute]
		public bool AllowUserToResizeEvenInFormViewMode
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
		///       是否允许用户鼠标拖拽操作改变表格列宽度
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(true)]
		
		[HtmlAttribute]
		[MemberExpressionable]
		public bool AllowUserToResizeColumns
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

		internal bool RuntimeAllowUserToResizeColumns
		{
			get
			{
				if (XTextDocument.smethod_13(GEnum6.const_92))
				{
					return AllowUserToResizeColumns;
				}
				return true;
			}
		}

		/// <summary>
		///       是否允许用户鼠标拖拽操作改变表格行高度
		///       </summary>
		[HtmlAttribute]
		
		[ComVisible(true)]
		[DefaultValue(true)]
		[MemberExpressionable]
		public bool AllowUserToResizeRows
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
		///       单元格边框线可见性设置
		///       </summary>
		[XmlIgnore]
		[DefaultValue(RenderVisibility.All)]
		[Obsolete("！！！本属性废除了，请使用(表格行)XTextTablRowElement.PrintCellBorder属性。")]
		public RenderVisibility CellBorderVisibility
		{
			get
			{
				return renderVisibility_0;
			}
			set
			{
				renderVisibility_0 = (RenderVisibility)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       单元格背景色可见性设置
		///       </summary>
		[DefaultValue(RenderVisibility.All)]
		[XmlIgnore]
		[Obsolete("！！！本属性废除了，请使用(表格行)XTextTablRowElement.PrintCellBackground属性。")]
		public RenderVisibility CellBackgroundVisibility
		{
			get
			{
				return renderVisibility_1;
			}
			set
			{
				renderVisibility_1 = (RenderVisibility)WriterUtils.FixEnumValue(value);
			}
		}

		/// <summary>
		///       是否显示无边框的单元格的边框。当本属性设置为Inherit值时系统采用Options.ViewOptions.ShowCellNoneBorder的值。
		///       </summary>
		
		[DefaultValue(DCBooleanValue.Inherit)]
		[ComVisible(true)]
		public DCBooleanValue ShowCellNoneBorder
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
		///       运行时的是否显示无边框的单元格边框。
		///       </summary>
		private bool RuntimeShowCellNoneBorder
		{
			get
			{
				if (ShowCellNoneBorder == DCBooleanValue.Inherit)
				{
					return OwnerDocument.Options.ViewOptions.ShowCellNoneBorder;
				}
				if (ShowCellNoneBorder == DCBooleanValue.True)
				{
					return true;
				}
				if (ShowCellNoneBorder == DCBooleanValue.False)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		///       左边缩进量
		///       </summary>
		[DefaultValue(0f)]
		public float LeftIndent
		{
			get
			{
				return float_5;
			}
			set
			{
				float_5 = value;
			}
		}

		/// <summary>
		///       表格行数
		///       </summary>
		[Browsable(false)]
		[XmlAttribute]
		public int NumOfRows
		{
			get
			{
				if (Elements == null)
				{
					return 0;
				}
				return Elements.Count;
			}
			set
			{
			}
		}

		/// <summary>
		///       表格的列数
		///       </summary>
		[XmlAttribute]
		[Browsable(false)]
		public int NumOfColumns
		{
			get
			{
				return Columns.Count;
			}
			set
			{
			}
		}

		private static bool IsSupportHeaderRowStyle => XTextDocument.smethod_13(GEnum6.const_98);

		/// <summary>
		///       标题行集合
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public XTextElementList HeaderRows
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				if (IsSupportHeaderRowStyle)
				{
					foreach (XTextTableRowElement runtimeRow in RuntimeRows)
					{
						if (runtimeRow.HeaderStyle)
						{
							for (int i = Rows.IndexOf(runtimeRow); i < Rows.Count; i++)
							{
								XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)Rows[i];
								if (!xTextTableRowElement2.HeaderStyle)
								{
									break;
								}
								xTextElementList.Add(xTextTableRowElement2);
							}
							break;
						}
					}
				}
				return xTextElementList;
			}
		}

		/// <summary>
		///       判断是否存在标题行
		///       </summary>
		/// <returns>是否存在标题行</returns>
		[Browsable(false)]
		public bool HasHeaderRow
		{
			get
			{
				if (!IsSupportHeaderRowStyle)
				{
					return false;
				}
				foreach (XTextTableRowElement runtimeRow in RuntimeRows)
				{
					if (runtimeRow.HeaderStyle)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       运行时的表格行对象列表
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public XTextElementList RuntimeRows
		{
			get
			{
				if (xtextElementList_2 == null)
				{
					xtextElementList_2 = new XTextElementList();
					foreach (XTextTableRowElement row in Rows)
					{
						if (row.RuntimeLayoutable)
						{
							xtextElementList_2.Add(row);
						}
					}
					if (xtextElementList_2.Count == Rows.Count)
					{
						xtextElementList_2 = Rows;
					}
				}
				return xtextElementList_2;
			}
		}

		/// <summary>
		///       对象所属文档对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
		public override XTextDocument OwnerDocument
		{
			get
			{
				return base.ElementOwnerDocument;
			}
			set
			{
				base.OwnerDocument = value;
				foreach (XTextTableColumnElement column in Columns)
				{
					column.OwnerDocument = OwnerDocument;
				}
			}
		}

		/// <summary>
		///       表格列对象
		///       </summary>
		
		public XTextElementList Columns
		{
			get
			{
				return xtextElementList_3;
			}
			set
			{
				xtextElementList_3 = value;
			}
		}

		/// <summary>
		///       表格行对象
		///       </summary>
		
		[Browsable(false)]
		[XmlIgnore]
		public XTextElementList Rows
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
		///       表格行数
		///       </summary>
		
		public int RowsCount => Elements.Count;

		/// <summary>
		///       表格列数
		///       </summary>
		
		public int ColumnsCount => Columns.Count;

		/// <summary>
		///       获得所有的单元格对象
		///       </summary>
		[XmlIgnore]
		
		[Browsable(false)]
		public XTextElementList Cells
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				foreach (XTextTableRowElement runtimeRow in RuntimeRows)
				{
					xTextElementList.AddRange(runtimeRow.Cells);
				}
				return xTextElementList;
			}
		}

		/// <summary>
		///       获得所有可见的单元格对象
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public XTextElementList VisibleCells
		{
			get
			{
				XTextElementList xTextElementList = new XTextElementList();
				foreach (XTextTableRowElement runtimeRow in RuntimeRows)
				{
					if (runtimeRow.RuntimeVisible)
					{
						foreach (XTextTableCellElement cell in runtimeRow.Cells)
						{
							if (cell.RuntimeVisible)
							{
								xTextElementList.AddRaw(cell);
							}
						}
					}
				}
				return xTextElementList;
			}
		}

		/// <summary>
		///       表格中第一个单元格
		///       </summary>
		[Browsable(false)]
		
		[XmlIgnore]
		[ComVisible(true)]
		public XTextTableCellElement FirstCell
		{
			get
			{
				if (Rows.Count > 0)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[0];
					if (xTextTableRowElement.Cells.Count > 0)
					{
						return (XTextTableCellElement)xTextTableRowElement.Cells[0];
					}
				}
				return null;
			}
		}

		/// <summary>
		///       表格中第一个单元格
		///       </summary>
		[ComVisible(true)]
		[XmlIgnore]
		[Browsable(false)]
		public XTextTableCellElement FirstVisibleCell
		{
			get
			{
				if (Rows.Count > 0)
				{
					foreach (XTextTableRowElement row in Rows)
					{
						if (row.RuntimeVisible)
						{
							foreach (XTextTableCellElement cell in row.Cells)
							{
								if (cell.RuntimeVisible)
								{
									return cell;
								}
							}
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       表格中最后一个单元格
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public XTextTableCellElement LastCell
		{
			get
			{
				if (Rows.Count > 0)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows.LastElement;
					if (xTextTableRowElement.Cells.Count > 0)
					{
						return (XTextTableCellElement)xTextTableRowElement.Cells.LastElement;
					}
				}
				return null;
			}
		}

		/// <summary>
		///       获得最后一个可见的单元格对象
		///       </summary>
		[XmlIgnore]
		[ComVisible(true)]
		[Browsable(false)]
		public XTextTableCellElement LastVisibleCell
		{
			get
			{
				for (int num = Rows.Count - 1; num >= 0; num--)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[num];
					if (xTextTableRowElement.RuntimeVisible)
					{
						int num2 = xTextTableRowElement.Cells.Count - 1;
						while (num2 >= 0)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[num2];
							if (!xTextTableCellElement.RuntimeVisible)
							{
								num2--;
								continue;
							}
							return xTextTableCellElement;
						}
					}
				}
				return null;
			}
		}

		/// <summary>
		///       第一个在正文中的内容元素
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override XTextElement FirstContentElementInPublicContent => FirstCell?.FirstContentElementInPublicContent;

		/// <summary>
		///       最后一个在文档正文中的内容元素
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public override XTextElement LastContentElementInPublicContent => LastVisibleCell?.LastContentElementInPublicContent;

		/// <summary>
		///       第一个内容元素
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public override XTextElement FirstContentElement => this;

		/// <summary>
		///       最后一个内容元素
		///       </summary>
		[Browsable(false)]
		public override XTextElement LastContentElement => this;

		/// <summary>
		///       表格中是否有内容被选择
		///       </summary>
		[Browsable(false)]
		public override bool HasSelection
		{
			get
			{
				XTextSelection selection = base.DocumentContentElement.Selection;
				if (selection.Cells != null && selection.Cells.Count > 0)
				{
					foreach (XTextTableCellElement cell in selection.Cells)
					{
						if (cell.OwnerTable == this)
						{
							return true;
						}
					}
				}
				XTextTableCellElement firstVisibleCell = FirstVisibleCell;
				XTextTableCellElement lastVisibleCell = LastVisibleCell;
				XTextElement xTextElement = firstVisibleCell?.FirstContentElement;
				XTextElement xTextElement2 = lastVisibleCell?.LastContentElement;
				if (xTextElement == null || xTextElement2 == null)
				{
					return false;
				}
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (documentContentElement != null && documentContentElement.Selection != null)
				{
					int absStartIndex = documentContentElement.Selection.AbsStartIndex;
					int absEndIndex = documentContentElement.Selection.AbsEndIndex;
					if (xTextElement.ViewIndex <= absEndIndex && xTextElement2.ViewIndex >= absStartIndex)
					{
						return true;
					}
				}
				return false;
			}
		}

		/// <summary>
		///       表格套嵌层次，文档中第一层表格的层次为1，子表格为2,再内部的子表格为3，以此类推.
		///       </summary>
		
		public int NeastLevel
		{
			get
			{
				int num = 0;
				for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.Parent)
				{
					if (xTextElement is XTextTableElement)
					{
						num++;
					}
				}
				return num;
			}
		}

		/// <summary>
		///       表格内容排版无效标志
		///       </summary>
		internal bool LayoutInvalidate
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

		/// <summary>
		///       表格的宽度
		///       </summary>
		[Browsable(false)]
		public float TableWidth
		{
			get
			{
				float num = 0f;
				foreach (XTextTableColumnElement column in Columns)
				{
					if (column.RuntimeVisible)
					{
						num += column.Width;
					}
				}
				return num;
			}
		}

		/// <summary>
		///       返回表示对象的文本
		///       </summary>
		[ReadOnly(true)]
		
		[Browsable(true)]
		[XmlIgnore]
		public override string Text
		{
			get
			{
				int num = 8;
				StringBuilder stringBuilder = new StringBuilder();
				foreach (XTextTableRowElement runtimeRow in RuntimeRows)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.AppendLine();
					}
					foreach (XTextTableCellElement cell in runtimeRow.Cells)
					{
						if (!cell.IsOverrided)
						{
							string text = cell.Text;
							if (string.IsNullOrEmpty(text))
							{
								stringBuilder.Append(" ");
							}
							else
							{
								stringBuilder.Append(text);
							}
							stringBuilder.Append(" ");
						}
					}
				}
				return stringBuilder.ToString();
			}
			set
			{
			}
		}

		/// <summary>
		///       分栏模式
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(TableSubfieldMode.None)]
		[HtmlAttribute]
		
		public TableSubfieldMode SubfieldMode
		{
			get
			{
				return tableSubfieldMode_0;
			}
			set
			{
				tableSubfieldMode_0 = value;
			}
		}

		/// <summary>
		///       分栏数量
		///       </summary>
		
		[DefaultValue(1)]
		[ComVisible(true)]
		[HtmlAttribute]
		public int SubfieldNumber
		{
			get
			{
				return int_10;
			}
			set
			{
				int_10 = value;
			}
		}

		[Browsable(false)]
		
		public override bool SupportElementViewHandle => true;

		/// <summary>
		///       初始化对象
		///       </summary>
		
		public XTextTableElement()
		{
		}

		/// <summary>
		///       创建表格对象
		///       </summary>
		/// <param name="rowsCount">总行数</param>
		/// <param name="columnsCount">总列数</param>
		
		public XTextTableElement(int int_11, int int_12)
		{
			Reset(int_11, int_12);
		}

		
		[ComVisible(true)]
		public void ResetWithCellStyle(int rowsCount, int columnsCount, DocumentContentStyle cellStyle)
		{
			Reset(rowsCount, columnsCount);
			foreach (XTextTableCellElement cell in Cells)
			{
				cell.Style = cellStyle;
			}
		}

		
		[ComVisible(true)]
		public void Reset(int rowsCount, int columnsCount)
		{
			int num = 19;
			if (rowsCount <= 0)
			{
				throw new ArgumentOutOfRangeException("rowsCount=" + rowsCount);
			}
			if (columnsCount <= 0)
			{
				throw new ArgumentOutOfRangeException("columnsCount=" + columnsCount);
			}
			Rows.Clear();
			Columns.Clear();
			for (int i = 0; i < columnsCount; i++)
			{
				XTextTableColumnElement xTextTableColumnElement = CreateColumnInstance();
				xTextTableColumnElement.Parent = this;
				Columns.Add(xTextTableColumnElement);
			}
			for (int j = 0; j < rowsCount; j++)
			{
				XTextTableRowElement xTextTableRowElement = CreateRowInstance();
				xTextTableRowElement.Parent = this;
				Rows.Add(xTextTableRowElement);
				for (int i = 0; i < columnsCount; i++)
				{
					XTextTableCellElement xTextTableCellElement = CreateCellInstance();
					xTextTableCellElement.Parent = xTextTableRowElement;
					xTextTableRowElement.Cells.Add(xTextTableCellElement);
				}
			}
		}

		/// <summary>
		///       重置续打单元格边框的状态
		///       </summary>
		
		public void ResetPrintBorderStateForJumPrint()
		{
			foreach (XTextTableCellElement cell in Cells)
			{
				cell.BorderPrintedWhenJumpPrint = false;
			}
		}

		/// <summary>
		///       创建表格结构
		///       </summary>
		/// <param name="rowCount">总行数</param>
		/// <param name="colCount">总列数</param>
		/// <param name="colWidth">表格列宽度</param>
		
		public void Build(int rowCount, int colCount, float colWidth)
		{
			int num = 7;
			if (rowCount <= 0)
			{
				throw new ArgumentOutOfRangeException("RowCount=" + rowCount);
			}
			if (colCount <= 0)
			{
				throw new ArgumentOutOfRangeException("ColCount=" + colCount);
			}
			Rows.Clear();
			Columns.Clear();
			for (int i = 0; i < colCount; i++)
			{
				XTextTableColumnElement xTextTableColumnElement = CreateColumnInstance();
				xTextTableColumnElement.Width = colWidth;
				Columns.Add(xTextTableColumnElement);
			}
			for (int j = 0; j < rowCount; j++)
			{
				XTextTableRowElement xTextTableRowElement = CreateRowInstance();
				Rows.Add(xTextTableRowElement);
				for (int i = 0; i < colCount; i++)
				{
					XTextTableCellElement element = CreateCellInstance();
					xTextTableRowElement.Cells.Add(element);
				}
			}
			FixDomState();
		}

		/// <summary>
		///       根据单元格文档行的行数拆分表格行，使得每个单元格只有一行文本。
		///       </summary>
		/// <param name="startRowIndexBase0">从0开始的行号</param>
		/// <param name="rowsCount">要处理的表格行数</param>
		/// <param name="updateView">是否更新文档视图</param>
		/// <returns>操作是否修改了文档内容</returns>
		
		[ComVisible(true)]
		public bool SplitRowsByContentLines(int startRowIndexBase0, int rowsCount, bool updateView)
		{
			int num = 2;
			if (startRowIndexBase0 < 0 || startRowIndexBase0 >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("startRowIndexBase0=" + startRowIndexBase0);
			}
			if (rowsCount <= 0)
			{
				return false;
			}
			List<XTextElement> list = new List<XTextElement>();
			for (int i = 0; i < rowsCount; i++)
			{
				List<XTextTableRowElement> list2 = new List<XTextTableRowElement>();
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[i + startRowIndexBase0];
				int num2 = 0;
				Dictionary<XTextTableCellElement, int> dictionary = new Dictionary<XTextTableCellElement, int>();
				foreach (XTextTableCellElement cell in xTextTableRowElement.Cells)
				{
					dictionary[cell] = cell.PrivateLines.Count;
					num2 = Math.Max(cell.PrivateLines.Count, num2);
				}
				if (num2 <= 1)
				{
					list.Add(xTextTableRowElement);
					continue;
				}
				float specifyHeight = xTextTableRowElement.RuntimeSpecifyHeight / (float)num2;
				for (int j = 0; j < num2; j++)
				{
					XTextTableRowElement xTextTableRowElement2 = xTextTableRowElement.EditorCloneSpecifyCloneType(TableRowCloneType.Default);
					foreach (XTextTableCellElement cell2 in xTextTableRowElement.Cells)
					{
						if (j < cell2.PrivateLines.Count)
						{
							XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement2.Cells[xTextTableRowElement.Cells.IndexOf(cell2)];
							xTextTableCellElement2.OwnerDocument = OwnerDocument;
							xTextTableCellElement2.GridLine = null;
							xTextTableCellElement2.Style.GridLineType = ContentGridLineType.None;
							xTextTableCellElement2.SpecifyFixedLineHeight = 0f;
							xTextTableCellElement2.Elements.Clear();
							if (cell2.PrivateLines.Count <= 0)
							{
								xTextTableCellElement2.Elements.AddRange(cell2.Elements);
							}
							else
							{
								foreach (XTextElement item in cell2.PrivateLines[j])
								{
									if (!(item is XTextFieldBorderElement))
									{
										xTextTableCellElement2.Elements.Add(item.Clone(Deeply: true));
									}
								}
							}
						}
					}
					xTextTableRowElement2.SpecifyHeight = specifyHeight;
					list2.Add(xTextTableRowElement2);
					list.Add(xTextTableRowElement2);
				}
				for (int k = 0; k < xTextTableRowElement.Cells.Count; k++)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[k];
					if (xTextTableCellElement.RuntimeStyle.VerticalAlign != VerticalAlignStyle.Bottom)
					{
						continue;
					}
					int num3 = list2.Count - dictionary[xTextTableCellElement];
					if (num3 > 0)
					{
						for (int j = list2.Count - 1; j >= num3; j--)
						{
							XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)list2[j].Cells[i];
							XTextTableCellElement xTextTableCellElement4 = (XTextTableCellElement)list2[j - num3].Cells[i];
							xTextTableCellElement3.Elements.Clear();
							xTextTableCellElement3.Elements.AddRange(xTextTableCellElement4.Elements);
							xTextTableCellElement4.Elements.Clear();
							xTextTableCellElement4.FixElements();
						}
					}
				}
			}
			if (list.Count == rowsCount)
			{
				return false;
			}
			Rows.RemoveRange(startRowIndexBase0, rowsCount);
			Rows.method_12(startRowIndexBase0, list);
			if (OwnerDocument.UndoList != null)
			{
				OwnerDocument.UndoList.Clear();
			}
			if (updateView)
			{
				EditorRefreshView();
			}
			return true;
		}

		/// <summary>
		///       表格行排序
		///       </summary>
		/// <param name="startRowIndexBase0">排序区域的从0开始计算的开始行号</param>
		/// <param name="rowsCount">排序区域的行数</param>
		/// <param name="comparer">表格行比较器</param>
		/// <param name="updateView">是否更新文档视图</param>
		/// <returns>操作是否改变了文档内容</returns>
		[ComVisible(false)]
		public bool SortRows(int startRowIndexBase0, int rowsCount, IDCTableRowComparer comparer, bool updateView)
		{
			int num = 1;
			if (startRowIndexBase0 < 0 || startRowIndexBase0 >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("startRowIndexBase0=" + startRowIndexBase0);
			}
			if (rowsCount <= 1)
			{
				return false;
			}
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			XTextElementList xTextElementList = new XTextElementList();
			xTextElementList.AddRange(Rows);
			Rows.Sort(startRowIndexBase0, rowsCount, new Class21(comparer));
			bool flag = false;
			for (int i = 0; i < xTextElementList.Count; i++)
			{
				if (xTextElementList[i] != Rows[i])
				{
					flag = true;
					break;
				}
			}
			if (updateView && flag)
			{
				EditorRefreshView();
			}
			return flag;
		}

		/// <summary>
		///       获得所有的文档元素对象，包括自己
		///       </summary>
		/// <returns>获得的元素列表</returns>
		[ComVisible(true)]
		public override XTextElementList GetAllElements()
		{
			XTextElementList allElements = base.GetAllElements();
			allElements.AddRange(Columns);
			return allElements;
		}

		/// <summary>
		///       获得输入焦点
		///       </summary>
		
		public override void Focus()
		{
			XTextTableCellElement firstCell = FirstCell;
			if (firstCell == null)
			{
				return;
			}
			XTextElement firstElement = firstCell.PrivateContent.FirstElement;
			if (firstElement != null)
			{
				OwnerDocument.method_124(firstElement);
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				if (OwnerDocument.CurrentContentElement != documentContentElement)
				{
					documentContentElement.Focus();
				}
				documentContentElement.SetSelection(firstElement.ContentIndex, 0);
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.ScrollToCaret();
				}
			}
		}

		/// <summary>
		///       设置文档元素为选中
		///       </summary>
		
		public override bool Select()
		{
			XTextTableCellElement firstCell = FirstCell;
			XTextTableCellElement xTextTableCellElement = LastCell;
			if (xTextTableCellElement != null && xTextTableCellElement.OverrideCell != null)
			{
				xTextTableCellElement = xTextTableCellElement.OverrideCell;
			}
			if (firstCell != null && xTextTableCellElement != null)
			{
				XTextElement firstContentElement = firstCell.FirstContentElement;
				XTextElement lastContentElement = xTextTableCellElement.LastContentElement;
				OwnerDocument.method_124(firstContentElement);
				return base.DocumentContentElement.SetSelectionRange(firstContentElement.ViewIndex, lastContentElement.ViewIndex);
			}
			return false;
		}

		/// <summary>
		///       创建新的文档对象，使其包含本文档元素的复制品
		///       </summary>
		/// <param name="includeThis">是否包含本文档原始对象,对表格对象该参数无意义</param>
		/// <returns>创建的文档对象</returns>
		public override XTextDocument CreateContentDocument(bool includeThis)
		{
			return base.CreateContentDocument(includeThis: true);
		}

		internal void method_26(GClass128 gclass128_0)
		{
			method_27(gclass128_0);
		}

		internal void method_27(GClass128 gclass128_0)
		{
			int num = 10;
			float absTop = AbsTop;
			XTextTableRowElement xTextTableRowElement = null;
			foreach (XTextTableRowElement runtimeRow in RuntimeRows)
			{
				if (runtimeRow.RuntimeVisible)
				{
					if (!(gclass128_0.method_23() >= absTop + runtimeRow.Top))
					{
						break;
					}
					if (runtimeRow.RuntimeNewPage && !runtimeRow.HandledNewPage && !runtimeRow.RuntimeHeaderStyle)
					{
						runtimeRow.HandledNewPage = true;
						gclass128_0.method_5(runtimeRow);
						gclass128_0.method_24(runtimeRow.AbsTop);
						gclass128_0.method_3(bool_5: true);
						method_28(gclass128_0);
						return;
					}
					if (runtimeRow.ContainsUnHandledPageBreak)
					{
						foreach (XTextTableCellElement cell in runtimeRow.Cells)
						{
							if (cell.RuntimeVisible && cell.ContainsUnHandledPageBreak)
							{
								cell.method_42(gclass128_0);
								method_28(gclass128_0);
								return;
							}
						}
					}
					xTextTableRowElement = runtimeRow;
				}
			}
			if (xTextTableRowElement == null)
			{
				return;
			}
			if (!xTextTableRowElement.RuntimeCanSplitByPageLine)
			{
				gclass128_0.method_24(absTop + xTextTableRowElement.Top);
				gclass128_0.method_6().Add(xTextTableRowElement);
				gclass128_0.method_5(xTextTableRowElement);
				method_28(gclass128_0);
				return;
			}
			float num2 = gclass128_0.method_23() - (absTop + xTextTableRowElement.Top);
			StringBuilder stringBuilder = null;
			float num3 = OwnerDocument.PixelToDocumentUnit(10f);
			if (HasHeaderRow)
			{
				num3 *= 2f;
			}
			if (num2 > num3)
			{
				new List<XTextTableCellElement>();
				XTextElementList xTextElementList = new XTextElementList();
				foreach (XTextTableCellElement cell2 in xTextTableRowElement.Cells)
				{
					if (cell2.RuntimeVisible)
					{
						if (cell2.PrivateLines != null && cell2.PrivateLines.Count != 0)
						{
							xTextElementList.Add(cell2);
						}
					}
					else if (cell2.IsOverrided && !xTextElementList.Contains(cell2.OverrideCell))
					{
						xTextElementList.Add(cell2.OverrideCell);
					}
				}
				if (xTextElementList.Count == 0)
				{
					return;
				}
				XTextTableCellElement xTextTableCellElement2 = null;
				float num4 = float.NaN;
				foreach (XTextTableCellElement item in xTextElementList)
				{
					if (item.PrivateLines != null && item.PrivateLines.Count != 0)
					{
						XTextLine lastLine = item.PrivateLines.LastLine;
						float num5 = Math.Max(0f, item.ClientHeight - lastLine.Bottom);
						if (xTextTableCellElement2 == null || num5 < num4)
						{
							xTextTableCellElement2 = item;
							num4 = num5;
						}
					}
				}
				if (stringBuilder != null)
				{
					stringBuilder.AppendLine("minBlankCell:" + xTextTableCellElement2.CellID + " minBlankHeight:" + num4);
					stringBuilder.AppendLine("info.SourceElements.Count=" + gclass128_0.method_6().Count);
				}
				gclass128_0.method_23();
				gclass128_0.bool_3 = false;
				xTextTableCellElement2.method_42(gclass128_0);
				if (stringBuilder != null && gclass128_0.method_4() != null)
				{
					stringBuilder.AppendLine("info.SourceElement:" + gclass128_0.method_4().ElementInstanceIndex + ":" + gclass128_0.method_4().Text);
				}
				if (gclass128_0.bool_3)
				{
					if (!gclass128_0.method_16())
					{
						float num6 = absTop + xTextTableRowElement.Top;
						foreach (XTextTableCellElement item2 in xTextElementList)
						{
							if (item2 != xTextTableCellElement2 && item2.PrivateLines != null && item2.PrivateLines.Count != 0)
							{
								float num7 = num6 + item2.PrivateLines.FirstLine.Top;
								float num8 = num6 + item2.PrivateLines.LastLine.Bottom;
								if (num7 <= gclass128_0.method_23() && gclass128_0.method_23() <= num8)
								{
									item2.method_42(gclass128_0);
									break;
								}
							}
						}
					}
					if (stringBuilder != null)
					{
						stringBuilder.AppendLine("UpContentTop");
						MessageBox.Show(stringBuilder.ToString());
					}
				}
				else
				{
					foreach (XTextTableCellElement item3 in xTextElementList)
					{
						if (item3 != xTextTableCellElement2 && item3.PrivateLines != null && item3.PrivateLines.Count > 0)
						{
							float absTop2 = item3.AbsTop;
							float num7 = absTop2 + item3.PrivateLines.FirstLine.Top;
							float num8 = absTop2 + item3.PrivateLines.LastLine.Bottom;
							if (num7 + 2f < gclass128_0.method_23() && gclass128_0.method_23() < num8 - 2f)
							{
								gclass128_0.method_6().method_13(0, item3);
								stringBuilder?.AppendLine("Insert Cell:" + item3.CellID);
							}
						}
					}
					if (gclass128_0.method_4() == null)
					{
						gclass128_0.method_5(xTextTableRowElement);
					}
					method_28(gclass128_0);
					if (stringBuilder != null && stringBuilder.Length > 0)
					{
						MessageBox.Show(stringBuilder.ToString());
					}
				}
				return;
			}
			for (int i = 0; i < xTextTableRowElement.Cells.Count; i++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[i];
				if (xTextTableCellElement.IsOverrided)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				if (xTextTableCellElement.OwnerRow != xTextTableRowElement && !gclass128_0.method_6().Contains(xTextTableCellElement))
				{
					gclass128_0.method_6().Add(xTextTableCellElement);
				}
			}
			if (gclass128_0.method_23() > absTop + xTextTableRowElement.Top + xTextTableRowElement.Height)
			{
				gclass128_0.method_24(absTop + xTextTableRowElement.Top + xTextTableRowElement.Height);
				gclass128_0.method_5(RuntimeRows.GetNextElement(xTextTableRowElement));
			}
			else
			{
				gclass128_0.method_24(absTop + xTextTableRowElement.Top);
				gclass128_0.method_5(xTextTableRowElement);
			}
			if (gclass128_0.method_4() == null)
			{
				gclass128_0.method_5(xTextTableRowElement);
			}
			method_28(gclass128_0);
		}

		private void method_28(GClass128 gclass128_0)
		{
			if (!HasHeaderRow || gclass128_0.method_16() || gclass128_0.method_14() != PageViewMode.Page)
			{
				return;
			}
			XTextElement xTextElement = gclass128_0.method_4();
			while (xTextElement != null && xTextElement.Parent != this)
			{
				xTextElement = xTextElement.Parent;
			}
			if (RuntimeRows.Contains(xTextElement))
			{
				XTextTableRowElement item = (XTextTableRowElement)xTextElement;
				if (RuntimeRows.IndexOf(item) > RuntimeRows.IndexOf(HeaderRows.LastElement))
				{
					gclass128_0.method_25().AddRange(HeaderRows);
				}
			}
		}

		
		public void method_29(DocumentPaintEventArgs documentPaintEventArgs_0)
		{
			method_30(documentPaintEventArgs_0, bool_26: true, bool_27: true, bool_28: false);
		}

		/// <summary>
		///       绘制对象内容
		///       </summary>
		/// <param name="args">参数</param>
		public override void Draw(DocumentPaintEventArgs args)
		{
			method_30(args, bool_26: true, bool_27: true, bool_28: true);
		}

		private void method_30(DocumentPaintEventArgs documentPaintEventArgs_0, bool bool_26, bool bool_27, bool bool_28)
		{
			int num = 1;
			if (!documentPaintEventArgs_0.JumpPrintMode || !PrintBothBorderWhenJumpPrint)
			{
			}
			OwnerDocument.method_85(this);
			float x = AbsLeft + RuntimeStyle.PaddingLeft;
			float y = AbsTop + RuntimeStyle.PaddingTop;
			RectangleF clipRectangle = documentPaintEventArgs_0.ClipRectangle;
			GClass526 gClass = new GClass526();
			RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
			bool flag = false;
			if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && OwnerDocument.Options.ViewOptions.HiddenTableBorderJumpPrintPage && documentPaintEventArgs_0.Options != null && documentPaintEventArgs_0.Options.JumpPrint != null && documentPaintEventArgs_0.Options.JumpPrint.Enabled && documentPaintEventArgs_0.Options.JumpPrint.Mode == JumpPrintMode.Normal && documentPaintEventArgs_0.PageIndex == documentPaintEventArgs_0.Options.JumpPrint.PageIndex)
			{
				float position = documentPaintEventArgs_0.Options.JumpPrint.Position;
				RectangleF absBounds = AbsBounds;
				if (absBounds.Top < position && position < absBounds.Bottom && XTextDocument.smethod_13(GEnum6.const_94))
				{
					flag = true;
				}
			}
			if (runtimeStyle.HasVisibleBorder && !flag)
			{
				RectangleF absBounds = AbsBounds;
				if (!documentPaintEventArgs_0.PageClipRectangle.IsEmpty)
				{
					absBounds = RectangleF.Intersect(absBounds, documentPaintEventArgs_0.PageClipRectangle);
				}
				if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && documentPaintEventArgs_0.PrintSelectionMode && !base.DocumentContentElement.Selection.Contains(this))
				{
					absBounds = RectangleF.Empty;
				}
				if (!absBounds.IsEmpty)
				{
					gClass.method_0("table:" + base.ID, absBounds, runtimeStyle.BorderLeft, runtimeStyle.BorderTop, runtimeStyle.BorderRight, runtimeStyle.BorderBottom, runtimeStyle.BorderColor, runtimeStyle.BorderWidth, runtimeStyle.BorderStyle, 1, bool_4: false);
				}
			}
			List<XTextTableCellElement> list = new List<XTextTableCellElement>();
			foreach (XTextTableRowElement runtimeRow in RuntimeRows)
			{
				if (runtimeRow.RuntimeVisible && !(runtimeRow.Height <= 0f) && (documentPaintEventArgs_0.RenderMode != DocumentRenderMode.Print || runtimeRow.PrintVisibility == ElementVisibility.Visible) && documentPaintEventArgs_0.IsVisible(runtimeRow.RuntimeStyle.Visibility))
				{
					RectangleF bounds = runtimeRow.Bounds;
					bounds.Offset(x, y);
					if (!clipRectangle.IsEmpty)
					{
						if (bounds.Top > clipRectangle.Bottom)
						{
							break;
						}
						float num2 = bounds.Top + runtimeRow.MaxCellHeight - clipRectangle.Top;
						if (((double)num2 < 1.5 && documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print) || num2 < -2f)
						{
							continue;
						}
					}
					if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print)
					{
						if (clipRectangle.Bottom - bounds.Top < 2f)
						{
							continue;
						}
						base.InnerPrintedFlag = true;
						runtimeRow.InnerPrintedFlag = true;
					}
					documentPaintEventArgs_0.Cancel = false;
					documentPaintEventArgs_0.ViewBounds = runtimeRow.AbsBounds;
					documentPaintEventArgs_0.ClientViewBounds = runtimeRow.AbsClientBounds;
					WriterUtils.smethod_29(this, runtimeRow, documentPaintEventArgs_0);
					if (documentPaintEventArgs_0.Cancel)
					{
						documentPaintEventArgs_0.Cancel = false;
					}
					else
					{
						foreach (XTextTableCellElement cell in runtimeRow.Cells)
						{
							if (cell.Width != 0f && cell.RuntimeVisible && documentPaintEventArgs_0.IsVisible(cell.RuntimeStyle.Visibility) && (documentPaintEventArgs_0.RenderMode != DocumentRenderMode.Print || (cell.PrintVisibility == ElementVisibility.Visible && (!documentPaintEventArgs_0.PrintSelectionMode || base.DocumentContentElement.Selection.method_1(cell)))))
							{
								documentPaintEventArgs_0.Element = cell;
								documentPaintEventArgs_0.Style = cell.RuntimeStyle;
								RectangleF absBounds2 = cell.AbsBounds;
								RectangleF rectangleF_ = absBounds2;
								RectangleF rectangleF = absBounds2;
								if (!clipRectangle.IsEmpty)
								{
									rectangleF = RectangleF.Intersect(absBounds2, clipRectangle);
								}
								if (!(rectangleF.Width <= 0f) && !(rectangleF.Height <= 0f))
								{
									if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && !documentPaintEventArgs_0.HasBoundSelection)
									{
										if (!documentPaintEventArgs_0.ClipRectangle.IsEmpty)
										{
											RectangleF clipRectangle2 = documentPaintEventArgs_0.ClipRectangle;
											if (absBounds2.Bottom < clipRectangle2.Top + 1f || absBounds2.Top > clipRectangle2.Bottom - 1f)
											{
												continue;
											}
											if (absBounds2.Y < clipRectangle2.Y + 1f)
											{
												absBounds2.Height = absBounds2.Bottom - clipRectangle2.Y - 1f;
												absBounds2.Y = clipRectangle2.Y + 1f;
											}
											if (absBounds2.Bottom > clipRectangle2.Bottom - 1f)
											{
												absBounds2.Height = clipRectangle2.Bottom - 1f - absBounds2.Y;
											}
											rectangleF_ = absBounds2;
										}
									}
									else if (!documentPaintEventArgs_0.PageClipRectangle.IsEmpty)
									{
										RectangleF clipRectangle2 = documentPaintEventArgs_0.PageClipRectangle;
										if (absBounds2.Bottom < clipRectangle2.Top + 1f || absBounds2.Top > clipRectangle2.Bottom - 1f)
										{
											continue;
										}
										if (absBounds2.Y < clipRectangle2.Y + 1f)
										{
											absBounds2.Height = absBounds2.Bottom - clipRectangle2.Y - 1f;
											absBounds2.Y = clipRectangle2.Y + 1f;
										}
										if (absBounds2.Bottom > clipRectangle2.Bottom - 1f)
										{
											absBounds2.Height = clipRectangle2.Bottom - 1f - absBounds2.Y;
										}
										rectangleF_ = absBounds2;
									}
									PointF[] pointF_ = new PointF[2]
									{
										absBounds2.Location,
										new PointF(absBounds2.Right, absBounds2.Bottom)
									};
									if (documentPaintEventArgs_0.Graphics != null)
									{
										documentPaintEventArgs_0.Graphics.TransformPoints(pointF_);
									}
									if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print)
									{
										cell.InnerPrintedFlag = true;
									}
									documentPaintEventArgs_0.Cancel = false;
									documentPaintEventArgs_0.ViewBounds = cell.AbsBounds;
									documentPaintEventArgs_0.ClientViewBounds = cell.AbsClientBounds;
									WriterUtils.smethod_29(this, cell, documentPaintEventArgs_0);
									if (documentPaintEventArgs_0.Cancel)
									{
										documentPaintEventArgs_0.Cancel = false;
									}
									else
									{
										OwnerDocument.method_88(absBounds2);
										bool flag2 = true;
										if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print || documentPaintEventArgs_0.RenderMode == DocumentRenderMode.ReadPaint)
										{
											flag2 = runtimeRow.PrintCellBackground;
										}
										if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && documentPaintEventArgs_0.PrintSelectionMode && !base.DocumentContentElement.Selection.method_0(cell))
										{
											flag2 = false;
										}
										if (flag2 && !flag)
										{
											OwnerDocument.Render.vmethod_1(cell, documentPaintEventArgs_0, absBounds2);
										}
										Region region = documentPaintEventArgs_0.Graphics.Clip;
										if (region != null)
										{
											region = region.Clone();
										}
										documentPaintEventArgs_0.SetClip(new RectangleF(absBounds2.Left - 4f, absBounds2.Top - 4f, absBounds2.Width + 8f, absBounds2.Height + 8f), CombineMode.Intersect);
										bool enabledDrawGridLine = documentPaintEventArgs_0.EnabledDrawGridLine;
										documentPaintEventArgs_0.EnabledDrawGridLine = !flag;
										try
										{
											if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint)
											{
												if (absBounds2.Height > 3f)
												{
													cell.DrawContent(documentPaintEventArgs_0);
												}
											}
											else
											{
												cell.DrawContent(documentPaintEventArgs_0);
											}
										}
										finally
										{
											documentPaintEventArgs_0.EnabledDrawGridLine = enabledDrawGridLine;
										}
										documentPaintEventArgs_0.Style = cell.RuntimeStyle;
										if (!flag)
										{
											if (documentPaintEventArgs_0.Style.GridLineType == ContentGridLineType.Display)
											{
												documentPaintEventArgs_0.ViewBounds = cell.AbsBounds;
												documentPaintEventArgs_0.ClientViewBounds = documentPaintEventArgs_0.Style.GetClientRectangleF(documentPaintEventArgs_0.ViewBounds);
												cell.method_48(documentPaintEventArgs_0, method_4(documentPaintEventArgs_0.Style.GridLineColor), bool_22: false, bool_23: false, bool_24: false, 0f, cell.RuntimeSpecifyFixedLineHeight, documentPaintEventArgs_0.Style.GridLineOffsetY, documentPaintEventArgs_0.Style.GridLineStyle, bool_25: false);
											}
											else if (documentPaintEventArgs_0.Style.GridLineType == ContentGridLineType.ExtentToBottom)
											{
												documentPaintEventArgs_0.ViewBounds = cell.AbsBounds;
												documentPaintEventArgs_0.ClientViewBounds = documentPaintEventArgs_0.Style.GetClientRectangleF(documentPaintEventArgs_0.ViewBounds);
												cell.method_48(documentPaintEventArgs_0, method_4(documentPaintEventArgs_0.Style.GridLineColor), bool_22: true, bool_23: true, bool_24: false, 0f, cell.RuntimeSpecifyFixedLineHeight, documentPaintEventArgs_0.Style.GridLineOffsetY, documentPaintEventArgs_0.Style.GridLineStyle, bool_25: false);
											}
										}
										documentPaintEventArgs_0.Graphics.Clip = region;
										if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint && RuntimeShowCellNoneBorder && !flag)
										{
											RuntimeDocumentContentStyle runtimeStyle2 = cell.RuntimeStyle;
											if (!runtimeStyle2.BorderLeft || !runtimeStyle2.BorderTop || !runtimeStyle2.BorderRight || !runtimeStyle2.BorderBottom || runtimeStyle2.BorderWidth == 0f)
											{
												Pen pen = GClass438.smethod_1(OwnerDocument.Options.ViewOptions.NoneBorderColor);
												bool bool_29 = true;
												bool bool_30 = true;
												bool bool_31 = true;
												bool bool_32 = true;
												XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)runtimeRow.Cells.GetPreElement(cell);
												if (xTextTableCellElement2 != null && xTextTableCellElement2.OverrideCell != null)
												{
													xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
												}
												if (xTextTableCellElement2 != null && list.Contains(xTextTableCellElement2))
												{
													RuntimeDocumentContentStyle runtimeStyle3 = xTextTableCellElement2.RuntimeStyle;
													if (runtimeStyle3.BorderRight && runtimeStyle3.BorderWidth > 0f && runtimeStyle3.BorderLeftColor.A != 0)
													{
														bool_29 = false;
													}
												}
												XTextTableCellElement xTextTableCellElement3 = GetCell(cell.RowIndex - 1, cell.ColIndex, throwException: false);
												if (xTextTableCellElement3 != null && xTextTableCellElement3.OverrideCell != null)
												{
													xTextTableCellElement3 = xTextTableCellElement3.OverrideCell;
												}
												if (xTextTableCellElement3 != null && list.Contains(xTextTableCellElement3))
												{
													RuntimeDocumentContentStyle runtimeStyle4 = xTextTableCellElement3.RuntimeStyle;
													if (runtimeStyle4.BorderBottom && runtimeStyle4.BorderWidth > 0f && runtimeStyle4.BorderTopColor.A != 0)
													{
														bool_30 = false;
													}
												}
												gClass.method_0(cell.ElementInstanceIndex.ToString(), rectangleF_, bool_29, bool_30, bool_31, bool_32, pen.Color, pen.Width, pen.DashStyle, 0, bool_4: true);
											}
										}
										bool flag3 = true;
										if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print || documentPaintEventArgs_0.RenderMode == DocumentRenderMode.ReadPaint)
										{
											flag3 = runtimeRow.PrintCellBorder;
										}
										if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print && documentPaintEventArgs_0.PrintSelectionMode && !base.DocumentContentElement.Selection.method_0(cell))
										{
											flag3 = false;
										}
										if (flag3 && !flag)
										{
											float borderWidth = documentPaintEventArgs_0.Style.BorderWidth;
											if (documentPaintEventArgs_0.Style.BorderLeft && borderWidth > 0f)
											{
												gClass.method_1(cell.ElementInstanceIndex + "-L", absBounds2.Left, absBounds2.Top, absBounds2.Left, absBounds2.Bottom, method_4(documentPaintEventArgs_0.Style.BorderLeftColor), documentPaintEventArgs_0.Style.BorderWidth, documentPaintEventArgs_0.Style.BorderStyle, cell.StressBorder ? 1 : 0, bool_0: false);
											}
											if (documentPaintEventArgs_0.Style.BorderTop && borderWidth > 0f)
											{
												gClass.method_1(cell.ElementInstanceIndex + "-T", absBounds2.Left, absBounds2.Top, absBounds2.Right, absBounds2.Top, method_4(documentPaintEventArgs_0.Style.BorderTopColor), documentPaintEventArgs_0.Style.BorderWidth, documentPaintEventArgs_0.Style.BorderStyle, cell.StressBorder ? 1 : 0, bool_0: false);
											}
											if (documentPaintEventArgs_0.Style.BorderRight && borderWidth > 0f)
											{
												gClass.method_1(cell.ElementInstanceIndex + "-R", absBounds2.Right, absBounds2.Top, absBounds2.Right, absBounds2.Bottom, method_4(documentPaintEventArgs_0.Style.BorderRightColor), documentPaintEventArgs_0.Style.BorderWidth, documentPaintEventArgs_0.Style.BorderStyle, cell.StressBorder ? 1 : 0, bool_0: false);
											}
											if (documentPaintEventArgs_0.Style.BorderBottom && borderWidth > 0f)
											{
												gClass.method_1(cell.ElementInstanceIndex + "-B", absBounds2.Left, absBounds2.Bottom, absBounds2.Right, absBounds2.Bottom, method_4(documentPaintEventArgs_0.Style.BorderBottomColor), documentPaintEventArgs_0.Style.BorderWidth, documentPaintEventArgs_0.Style.BorderStyle, cell.StressBorder ? 1 : 0, bool_0: false);
											}
										}
										documentPaintEventArgs_0.ViewBounds = cell.AbsBounds;
										documentPaintEventArgs_0.ClientViewBounds = cell.AbsClientBounds;
										WriterUtils.smethod_28(this, cell, documentPaintEventArgs_0);
										if (documentPaintEventArgs_0.ActiveMode && cell.IsSelected && OwnerDocument.EditorControl != null)
										{
											OwnerDocument.EditorControl.AddSelectionAreaRectangle(Rectangle.Ceiling(cell.AbsBounds));
										}
										list.Add(cell);
									}
								}
							}
						}
						documentPaintEventArgs_0.ViewBounds = runtimeRow.AbsBounds;
						documentPaintEventArgs_0.ClientViewBounds = runtimeRow.AbsClientBounds;
						WriterUtils.smethod_28(this, runtimeRow, documentPaintEventArgs_0);
					}
				}
			}
			list.Clear();
			list = null;
			gClass.method_2();
			if (gClass.method_6().Count > 0 && !flag)
			{
				bool flag4 = true;
				if (!documentPaintEventArgs_0.IsVisible(OwnerDocument.Options.ViewOptions.TableCellBorderVisibility))
				{
					flag4 = false;
				}
				if (flag4)
				{
					documentPaintEventArgs_0.Graphics.ResetClip();
					RectangleF clipRectangle3 = documentPaintEventArgs_0.ClipRectangle;
					if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Print)
					{
						clipRectangle3.Height += 4f;
					}
					else
					{
						clipRectangle3.Height += 1f;
					}
					documentPaintEventArgs_0.SetClip(clipRectangle3, CombineMode.Replace);
					foreach (GClass526.GClass527 item in gClass.method_6())
					{
						if (!item.bool_0)
						{
						}
						if (documentPaintEventArgs_0.Graphics != null)
						{
							if (documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint)
							{
								XPenStyle xPenStyle = new XPenStyle(item.color_0, item.float_4, item.dashStyle_0);
								float float_ = (float)GraphicsUnitConvert.GetRate(documentPaintEventArgs_0.Graphics.PageUnit, GraphicsUnit.Pixel);
								xPenStyle.Width = MathCommon.smethod_2(item.float_4, float_);
								PointF[] pointF_ = new PointF[2]
								{
									new PointF(item.float_0, item.float_1),
									new PointF(item.float_2, item.float_3)
								};
								documentPaintEventArgs_0.Graphics.TransformPoints(pointF_);
								pointF_[0].X = MathCommon.smethod_2(pointF_[0].X, float_);
								pointF_[0].Y = MathCommon.smethod_2(pointF_[0].Y, float_);
								pointF_[1].X = MathCommon.smethod_2(pointF_[1].X, float_);
								pointF_[1].Y = MathCommon.smethod_2(pointF_[1].Y, float_);
								MathCommon.smethod_0(documentPaintEventArgs_0.Graphics.Transform, pointF_);
								documentPaintEventArgs_0.Graphics.DrawLine(xPenStyle, pointF_[0], pointF_[1]);
							}
							else
							{
								documentPaintEventArgs_0.Graphics.DrawLine(new XPenStyle(item.color_0, item.float_4, item.dashStyle_0), item.float_0, item.float_1, item.float_2, item.float_3);
							}
						}
					}
				}
			}
			if (OwnerDocument.Options.BehaviorOptions.DesignMode && documentPaintEventArgs_0.RenderMode == DocumentRenderMode.Paint)
			{
				using (Pen pen2 = new Pen(Color.FromArgb(150, Color.Red)))
				{
					pen2.CustomStartCap = new AdjustableArrowCap(4f, 4f);
					pen2.CustomEndCap = pen2.CustomStartCap;
					XTextElementList runtimeRows = RuntimeRows;
					RectangleF absBounds3 = AbsBounds;
					for (int i = 0; i < runtimeRows.Count; i++)
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)runtimeRows[i];
						if (xTextTableRowElement.ValueBinding != null && !xTextTableRowElement.ValueBinding.IsEmptyBinding && xTextTableRowElement.ValueBinding.Enabled && xTextTableRowElement.ExpendForDataBinding && xTextTableRowElement.DataSourceRowSpan > 0)
						{
							int num3 = runtimeRows.IndexOf(xTextTableRowElement);
							int index = Math.Min(num3 + xTextTableRowElement.DataSourceRowSpan - 1, runtimeRows.Count - 1);
							XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)runtimeRows[index];
							RectangleF rectangleF2 = new RectangleF(absBounds3.Right - 30f, xTextTableRowElement.AbsTop, 20f, xTextTableRowElement2.AbsTop + xTextTableRowElement2.Height - xTextTableRowElement.AbsTop);
							if (rectangleF2.IntersectsWith(documentPaintEventArgs_0.ClipRectangle))
							{
								documentPaintEventArgs_0.Graphics.DrawLine(pen2, rectangleF2.Left + rectangleF2.Width / 2f, rectangleF2.Top, rectangleF2.Left + rectangleF2.Width / 2f, rectangleF2.Bottom);
							}
							i += xTextTableRowElement.DataSourceRowSpan - 1;
						}
					}
				}
			}
		}

		/// <summary>
		///       获得指定区域内的单元格对象
		///       </summary>
		/// <param name="rowIndex">开始行号</param>
		/// <param name="colIndex">开始列号</param>
		/// <param name="rowSpan">行数</param>
		/// <param name="colSpan">列数</param>
		/// <param name="includeOverriedCell">是否包含被合并的单元格</param>
		/// <returns>单元格对象集合</returns>
		public XTextElementList GetRange(int rowIndex, int colIndex, int rowSpan, int colSpan, bool includeOverriedCell)
		{
			if (rowSpan < 0 || colSpan < 0)
			{
				return null;
			}
			int num = rowIndex + rowSpan - 1;
			int num2 = colIndex + colSpan - 1;
			if (rowIndex < 0)
			{
				rowIndex = 0;
			}
			if (colIndex < 0)
			{
				colIndex = 0;
			}
			XTextElementList rows = Rows;
			if (rowIndex >= rows.Count || colIndex >= Columns.Count)
			{
				return null;
			}
			if (num >= rows.Count)
			{
				num = rows.Count - 1;
			}
			if (num2 >= Columns.Count)
			{
				num2 = Columns.Count - 1;
			}
			XTextElementList xTextElementList = new XTextElementList();
			for (int i = rowIndex; i <= num; i++)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)rows[i];
				for (int j = colIndex; j <= num2 && j < xTextTableRowElement.Cells.Count; j++)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.Cells[j];
					if (includeOverriedCell || !xTextTableCellElement.IsOverrided)
					{
						xTextElementList.Add(xTextTableCellElement);
					}
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       插入子元素
		///       </summary>
		/// <param name="index">指定的序号</param>
		/// <param name="element">新添加的元素</param>
		/// <returns>操作是否成功</returns>
		public override bool InsertChildElement(int index, XTextElement element)
		{
			if (element is XTextTableColumnElement)
			{
				Columns.method_13(index, element);
				element.Parent = this;
				element.OwnerDocument = OwnerDocument;
				return true;
			}
			return base.InsertChildElement(index, element);
		}

		public override int vmethod_32(XTextElementList xtextElementList_4, bool bool_26)
		{
			int num = 0;
			foreach (XTextTableRowElement row in Rows)
			{
				if (row.RuntimeVisible)
				{
					foreach (XTextTableCellElement cell in row.Cells)
					{
						if (cell.RuntimeVisible)
						{
							num += cell.vmethod_32(xtextElementList_4, bool_26);
						}
					}
				}
			}
			return num;
		}

		/// <summary>
		///       添加子元素
		///       </summary>
		/// <param name="element">子元素</param>
		/// <returns>操作是否成功</returns>
		public override bool AppendChildElement(XTextElement element)
		{
			if (element is XTextTableColumnElement)
			{
				Columns.Add(element);
				element.Parent = this;
				element.OwnerDocument = OwnerDocument;
				return true;
			}
			return base.AppendChildElement(element);
		}

		/// <summary>
		///       刷新视图
		///       </summary>
		
		public override void EditorRefreshView()
		{
			if (UIIsUpdating)
			{
				return;
			}
			method_8(bool_5: false);
			method_40();
			FixDomState();
			foreach (XTextTableCellElement cell in Cells)
			{
				cell.FixElements();
				cell.method_8(bool_5: false);
			}
			vmethod_31(bool_26: true);
			base.EditorRefreshView();
			XTextDocument ownerDocument = OwnerDocument;
			if (ownerDocument != null)
			{
				ownerDocument.RefreshPages();
				if (ownerDocument.EditorControl != null && !ownerDocument.EditorControl.IsUpdating)
				{
					ownerDocument.EditorControl.UpdatePages();
					ownerDocument.EditorControl.UpdateTextCaret();
					ownerDocument.EditorControl.InnerViewControl.Invalidate();
				}
			}
		}

		/// <summary>
		///       修复DOM状态
		///       </summary>
		public override void FixDomState()
		{
			method_31(bool_26: true);
		}

		internal void method_31(bool bool_26)
		{
			method_18(bool_17: false);
			XTextDocument ownerDocument = OwnerDocument;
			if (xtextElementList_3 != null)
			{
				int count = Rows.Count;
				foreach (XTextTableColumnElement item in xtextElementList_3)
				{
					item.ElementIndex = count++;
					item.SetParentRaw(this);
					item.method_5(ownerDocument);
					item.xtextElementList_0 = null;
				}
			}
			int num = 0;
			foreach (XTextTableRowElement row in Rows)
			{
				row.ElementIndex = num++;
				row.method_18(bool_17: false);
				row.SetParentRaw(this);
				row.method_5(ownerDocument);
				row.MaxCellHeight = -1f;
				int count = 0;
				int num2 = 0;
				foreach (XTextTableCellElement cell in row.Cells)
				{
					if (bool_26)
					{
						cell.method_57(null);
					}
					cell.ElementIndex = num2++;
					cell.SetParentRaw(row);
					cell.method_5(ownerDocument);
					cell.FixDomState();
					if (xtextElementList_3 != null && count < xtextElementList_3.Count)
					{
						cell.OwnerColumn = (XTextTableColumnElement)xtextElementList_3[count];
					}
					count++;
				}
			}
			method_34();
			if (bool_26)
			{
				method_35();
			}
		}

		/// <summary>
		///       从文件中加载对象后的操作
		///       </summary>
		/// <param name="args">参数</param>
		public override void AfterLoad(ElementLoadEventArgs args)
		{
			foreach (XTextTableColumnElement column in Columns)
			{
				column.SetParentRaw(this);
				column.method_5(OwnerDocument);
			}
			if (method_40() > 0)
			{
				method_35();
			}
			foreach (XTextTableRowElement row in Rows)
			{
				foreach (XTextTableCellElement cell in row.Cells)
				{
					cell.AfterLoad(args);
				}
			}
		}

		public override void vmethod_31(bool bool_26)
		{
			_ = OwnerDocument;
			RuntimeVisible = vmethod_30();
			if (RuntimeVisible)
			{
				foreach (XTextTableColumnElement column in Columns)
				{
					column.RuntimeVisible = column.Visible;
				}
				foreach (XTextTableRowElement row in Rows)
				{
					row.RuntimeVisible = row.vmethod_30();
					if (row.RuntimeVisible)
					{
						XTextElementList cells = row.Cells;
						for (int i = 0; i < cells.Count; i++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)cells[i];
							xTextTableCellElement.RuntimeVisible = true;
							if (xTextTableCellElement.IsOverrided)
							{
								xTextTableCellElement.RuntimeVisible = false;
							}
							else if (i < Columns.Count && !Columns[i].RuntimeVisible)
							{
								xTextTableCellElement.RuntimeVisible = false;
							}
							if (bool_26)
							{
								xTextTableCellElement.vmethod_31(bool_17: true);
							}
						}
					}
					else
					{
						row.vmethod_31(bool_26);
					}
				}
			}
			else
			{
				foreach (XTextTableColumnElement column2 in Columns)
				{
					column2.RuntimeVisible = false;
				}
				base.vmethod_31(bool_26);
			}
		}

		internal void method_32(DCGraphics dcgraphics_0)
		{
			DocumentPaintEventArgs documentPaintEventArgs = OwnerDocument.method_55(dcgraphics_0);
			foreach (XTextTableCellElement cell in Cells)
			{
				if (!cell.IsOverrided && cell.SizeInvalid)
				{
					documentPaintEventArgs.Element = cell;
					cell.FixElements();
					cell.RefreshSize(documentPaintEventArgs);
				}
			}
		}

		/// <summary>
		///       重新计算对象大小
		///       </summary>
		/// <param name="args">参数</param>
		public override void RefreshSize(DocumentPaintEventArgs args)
		{
			bool_25 = true;
			base.RefreshSize(args);
		}

		/// <summary>
		///       执行表格排版
		///       </summary>
		public override void ExecuteLayout()
		{
			method_33(bool_26: true);
		}

		internal void method_33(bool bool_26)
		{
			if (!UIIsUpdating)
			{
				xtextElementList_2 = null;
				LayoutInvalidate = false;
				method_40();
				method_35();
				method_38(bool_26: true);
				if (base.OwnerLine != null && bool_26)
				{
					base.OwnerLine.method_22();
				}
			}
		}

		private void method_34()
		{
			XTextElementList rows = Rows;
			int count = rows.Count;
			for (int i = 0; i < count; i++)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)rows[i];
				xTextTableRowElement.int_10 = i;
				XTextElementList cells = xTextTableRowElement.Cells;
				int count2 = cells.Count;
				for (int j = 0; j < count2; j++)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)cells[j];
					xTextTableCellElement.int_15 = i;
					xTextTableCellElement.int_16 = j;
				}
			}
		}

		internal void method_35()
		{
			xtextElementList_2 = null;
			XTextElementList cells = Cells;
			XTextElementList xTextElementList = new XTextElementList();
			foreach (XTextTableCellElement item in cells)
			{
				if (item.OverrideCell != null)
				{
					xTextElementList.Add(item);
					item.method_57(null);
				}
			}
			foreach (XTextTableCellElement item2 in cells)
			{
				if (item2.OverrideCell == null)
				{
					int rowIndex = item2.RowIndex;
					int colIndex = item2.ColIndex;
					if (item2.RowSpan > 1 && rowIndex + item2.RowSpan > RuntimeRows.Count)
					{
						item2.method_61(Rows.Count - rowIndex);
					}
					if (item2.ColSpan > 1 && colIndex + item2.ColSpan > Columns.Count)
					{
						item2.method_60(Columns.Count - colIndex);
					}
					while (true)
					{
						IL_01cc:
						int runtimeRowSpan = item2.RuntimeRowSpan;
						if (runtimeRowSpan > 1 || item2.ColSpan > 1)
						{
							XTextElementList range = GetRange(rowIndex, colIndex, runtimeRowSpan, item2.ColSpan, includeOverriedCell: true);
							if (range != null)
							{
								foreach (XTextTableCellElement item3 in range)
								{
									_ = item2.OwnerRow;
									if (item3.OverrideCell == null || item3.OverrideCell == item2)
									{
										item3.method_57(item2);
										continue;
									}
									item2.method_60(item3.ColIndex - colIndex);
									goto IL_01cc;
								}
							}
							item2.method_57(null);
						}
						break;
					}
				}
			}
			foreach (XTextTableCellElement item4 in xTextElementList)
			{
				if (item4.OverrideCell == null)
				{
					item4.FixElements();
					item4.SizeInvalid = true;
				}
			}
		}

		private void method_36(XTextTableCellElement xtextTableCellElement_0, bool bool_26)
		{
			int colIndex = xtextTableCellElement_0.ColIndex;
			xtextTableCellElement_0.FixElements();
			XTextElementList columns = Columns;
			if (xtextTableCellElement_0.RuntimeVisible)
			{
				float num = 0f;
				if (xtextTableCellElement_0.ColSpan == 1)
				{
					num = columns[colIndex].Width;
				}
				else
				{
					for (int i = 0; i < xtextTableCellElement_0.ColSpan; i++)
					{
						num += columns[colIndex + i].Width;
					}
				}
				if (xtextTableCellElement_0.Width != num || xtextTableCellElement_0.SizeInvalid || xtextTableCellElement_0.LayoutInvalidate)
				{
					xtextTableCellElement_0.Width = num;
					if (bool_26)
					{
						xtextTableCellElement_0.method_63(bool_26: true);
					}
				}
				float num2 = 0f;
				int runtimeRowSpan = xtextTableCellElement_0.RuntimeRowSpan;
				if (runtimeRowSpan == 1)
				{
					num2 = xtextTableCellElement_0.OwnerRow.Height;
				}
				else
				{
					for (int i = 0; i < runtimeRowSpan; i++)
					{
						num2 += Rows[xtextTableCellElement_0.RowIndex + i].Height;
					}
				}
				RectangleF rectangleF = new RectangleF(columns[colIndex].Left, 0f, num, num2);
				if (bool_26 && (xtextTableCellElement_0.Height == 0f || xtextTableCellElement_0.Height != num2 || xtextTableCellElement_0.SizeInvalid))
				{
					VerticalAlignStyle contentVertialAlign = xtextTableCellElement_0.ContentVertialAlign;
					if (contentVertialAlign != 0)
					{
						xtextTableCellElement_0.vmethod_41(contentVertialAlign, bool_22: false, bool_23: false);
					}
				}
			}
			else
			{
				xtextTableCellElement_0.Left = xtextTableCellElement_0.OwnerColumn.Left;
				xtextTableCellElement_0.Top = 0f;
				xtextTableCellElement_0.Width = xtextTableCellElement_0.OwnerColumn.Width;
				xtextTableCellElement_0.Height = xtextTableCellElement_0.OwnerRow.Height;
			}
		}

		private void method_37(object object_1)
		{
			IEnumerator enumerator = (IEnumerator)object_1;
			while (true)
			{
				XTextTableCellElement xtextTableCellElement_ = null;
				lock (enumerator)
				{
					if (!enumerator.MoveNext())
					{
						return;
					}
					xtextTableCellElement_ = (XTextTableCellElement)enumerator.Current;
				}
				method_36(xtextTableCellElement_, bool_26: true);
			}
		}

		internal void method_38(bool bool_26)
		{
			float num = RuntimeStyle.PaddingLeft;
			foreach (XTextTableColumnElement column in Columns)
			{
				column.Left = num;
				if (column.RuntimeVisible)
				{
					num += column.Width;
				}
			}
			foreach (XTextTableRowElement row in Rows)
			{
				row.MaxCellHeight = -1f;
			}
			XTextElementList cells = Cells;
			bool flag = false;
			if (cells.Count > 5000 && bool_26 && OwnerDocument.Options.BehaviorOptions.SpeedupByMultiThread)
			{
				flag = true;
				foreach (XTextTableCellElement item in cells)
				{
					if (item.RuntimeVisible && item.AutoFixFontSizeMode != 0)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				int tickCount = Environment.TickCount;
				IEnumerator enumerator2 = cells.GetEnumerator();
				ParameterizedThreadStart start = method_37;
				Thread thread = new Thread(start);
				thread.Start(enumerator2);
				method_37(enumerator2);
				while (thread.IsAlive)
				{
					Thread.Sleep(5);
				}
				tickCount = Environment.TickCount - tickCount;
			}
			else
			{
				int tickCount = Environment.TickCount;
				foreach (XTextTableCellElement item2 in cells)
				{
					method_36(item2, bool_26);
				}
				tickCount = Environment.TickCount - tickCount;
			}
			foreach (XTextTableRowElement row2 in Rows)
			{
				row2.CalcuteRowHeight();
			}
			foreach (XTextTableCellElement item3 in cells)
			{
				if (!item3.IsOverrided && item3.RowSpan > 1)
				{
					float num2 = 0f;
					for (int i = 0; i < item3.RowSpan; i++)
					{
						num2 += ((XTextTableRowElement)Rows[i + item3.RowIndex]).Height;
					}
					RuntimeDocumentContentStyle runtimeStyle = item3.OwnerRow.RuntimeStyle;
					float num3 = item3.ContentHeight + runtimeStyle.PaddingTop + runtimeStyle.PaddingBottom;
					if (num3 > num2)
					{
						for (int i = item3.RowSpan - 1; i >= 0; i--)
						{
							XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[i + item3.RowIndex];
							if (xTextTableRowElement.RuntimeSpecifyHeight >= 0f)
							{
								xTextTableRowElement.Height = xTextTableRowElement.Height + num3 - num2;
								break;
							}
						}
					}
					else
					{
						item3.Height = num2;
					}
				}
			}
			RuntimeDocumentContentStyle runtimeStyle2 = RuntimeStyle;
			float num4 = runtimeStyle2.PaddingTop;
			foreach (XTextTableRowElement runtimeRow in RuntimeRows)
			{
				runtimeRow.Top = num4;
				num4 += runtimeRow.Height;
				runtimeRow.Left = runtimeStyle2.PaddingLeft;
				foreach (XTextTableCellElement cell in runtimeRow.Cells)
				{
					cell.Left = cell.OwnerColumn.Left;
					cell.Top = 0f;
					if (cell.RowSpan == 1 || cell.IsOverrided)
					{
						cell.Height = runtimeRow.Height;
					}
					else
					{
						float num5 = 0f;
						int i = Rows.IndexOf(runtimeRow);
						for (int j = 0; j < cell.RowSpan; j++)
						{
							num5 += Rows[i + j].Height;
						}
						cell.Height = num5;
					}
					if (cell.AutoFixFontSizeMode == ContentAutoFixFontSizeMode.MultiLine || cell.AutoFixFontSizeMode == ContentAutoFixFontSizeMode.SingleLine)
					{
						cell.method_55();
					}
					VerticalAlignStyle verticalAlign = cell.RuntimeStyle.VerticalAlign;
					if (verticalAlign != 0 && cell.Height > 0f)
					{
						cell.vmethod_41(verticalAlign, bool_22: false, bool_23: false);
					}
				}
			}
			Height = num4 + runtimeStyle2.PaddingTop + runtimeStyle2.PaddingBottom;
			float num6 = 0f;
			foreach (XTextTableColumnElement column2 in Columns)
			{
				if (column2.RuntimeVisible)
				{
					num6 += column2.Width;
				}
			}
			Width = num6 + runtimeStyle2.PaddingLeft + runtimeStyle2.PaddingRight;
			foreach (XTextTableRowElement row3 in Rows)
			{
				row3.Width = num6;
			}
		}

		internal void method_39()
		{
			RuntimeDocumentContentStyle runtimeStyle = RuntimeStyle;
			float num = runtimeStyle.PaddingTop;
			foreach (XTextTableRowElement runtimeRow in RuntimeRows)
			{
				runtimeRow.Top = num;
				num += runtimeRow.Height;
				runtimeRow.Left = runtimeStyle.PaddingLeft;
			}
			Height = num + runtimeStyle.PaddingBottom;
			if (base.OwnerLine != null)
			{
				base.OwnerLine.method_22();
			}
		}

		internal int method_40()
		{
			int num = 0;
			int num2 = 0;
			CountDown.GetTickCountFloat();
			bool flag = false;
			foreach (XTextTableRowElement row in Rows)
			{
				if (num2 < row.Cells.Count)
				{
					num2 = row.Cells.Count;
				}
				if (row.Cells.Count > Columns.Count)
				{
					for (int i = Columns.Count; i < row.Cells.Count; i++)
					{
						XTextTableColumnElement xTextTableColumnElement = CreateColumnInstance();
						xTextTableColumnElement.Width = row.Cells[i].Width;
						if (xTextTableColumnElement.Width == 0f)
						{
							if (Columns.Count == 0)
							{
								xTextTableColumnElement.Width = 100f;
							}
							else
							{
								xTextTableColumnElement.Width = Columns.LastElement.Width;
							}
						}
						xTextTableColumnElement.OwnerDocument = OwnerDocument;
						xTextTableColumnElement.Parent = this;
						Columns.Add(xTextTableColumnElement);
						flag = true;
					}
				}
			}
			if (Columns.Count > num2)
			{
				Columns.vmethod_0(num2);
			}
			GClass344 gClass = new GClass344();
			foreach (XTextTableRowElement element in Elements)
			{
				if (element.Cells.Count != Columns.Count)
				{
					element.Cells.vmethod_0(Columns.Count);
					if (element.Cells.Count < Columns.Count)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)element.Cells.LastElement;
						for (int i = element.Cells.Count; i < Columns.Count; i++)
						{
							XTextTableCellElement xTextTableCellElement2 = null;
							xTextTableCellElement2 = ((xTextTableCellElement != null) ? ((XTextTableCellElement)xTextTableCellElement.Clone(Deeply: false)) : CreateCellInstance());
							num++;
							element.Cells.Add(xTextTableCellElement2);
							xTextTableCellElement2.SetParentRaw(element);
							xTextTableCellElement2.method_5(OwnerDocument);
							xTextTableCellElement2.OwnerColumn = (XTextTableColumnElement)Columns[element.Cells.Count - 1];
							gClass.method_3(element.ElementIndex + 1);
							gClass.method_7(i + 1);
							xTextTableCellElement2.FixDomState();
							flag = true;
						}
					}
				}
			}
			if (!flag)
			{
			}
			method_34();
			return num;
		}

		internal void method_41(bool bool_26)
		{
			if (UIIsUpdating)
			{
				return;
			}
			XTextLine ownerLine = base.OwnerLine;
			if (ownerLine == null)
			{
				return;
			}
			float height = ownerLine.Height;
			ownerLine.method_22();
			if (ownerLine.Height != height || bool_26)
			{
				for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.Parent)
				{
					if (xTextElement is XTextTableCellElement)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElement;
						XTextTableElement ownerTable = xTextTableCellElement.OwnerTable;
						float height2 = xTextTableCellElement.Height;
						xTextTableCellElement.Height = 0f;
						ownerTable.ExecuteLayout();
						if (xTextTableCellElement.Height != height2)
						{
							ownerTable.OwnerLine.method_22();
							ownerTable.OwnerLine.InvalidateState = true;
						}
					}
					else if (xTextElement is XTextSectionElement)
					{
						XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextElement;
						float height2 = xTextSectionElement.Height;
						xTextSectionElement.vmethod_41(VerticalAlignStyle.Top, bool_22: true, bool_23: false);
						xTextSectionElement.vmethod_40();
						if (xTextSectionElement.Height != height2)
						{
							xTextSectionElement.OwnerLine.method_22();
							xTextSectionElement.OwnerLine.InvalidateState = true;
						}
					}
				}
				XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
				documentContentElement.vmethod_41(documentContentElement.ContentVertialAlign, bool_22: false, bool_23: true);
				documentContentElement.vmethod_40();
				OwnerDocument.RefreshPages();
				if (OwnerDocument.EditorControl != null)
				{
					OwnerDocument.EditorControl.UpdatePages();
					OwnerDocument.EditorControl.InnerViewControl.Invalidate();
				}
			}
			if (OwnerDocument.EditorControl != null)
			{
				OwnerDocument.EditorControl.UpdateTextCaretWithoutScroll();
			}
		}

		/// <summary>
		///       获得指定序号的单元格对象
		///       </summary>
		/// <param name="strCellIndex">单元格序号字符串</param>
		/// <param name="throwException">若未找到单元格是否抛出异常</param>
		/// <returns>找的单元格对象，若未找到而且不抛出异常则返回空引用</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("请使用GetCellByCellIndex（）")]
		public XTextTableCellElement GetCell(string strCellIndex, bool throwException)
		{
			return GetCellByCellIndex(strCellIndex, throwException);
		}

		/// <summary>
		///       获得指定序号的单元格对象
		///       </summary>
		/// <param name="strCellIndex">单元格序号字符串</param>
		/// <param name="throwException">若未找到单元格是否抛出异常</param>
		/// <returns>找的单元格对象，若未找到而且不抛出异常则返回空引用</returns>
		
		[ComVisible(true)]
		public XTextTableCellElement GetCellByCellIndex(string strCellIndex, bool throwException)
		{
			GClass344 gClass = new GClass344(strCellIndex);
			return GetCell(gClass.method_2() - 1, gClass.method_6() - 1, throwException);
		}

		/// <summary>
		///       获得指定序号的单元格文本内容
		///       </summary>
		/// <param name="strCellIndex">单元格序号字符串</param>
		/// <param name="throwException">若未找到单元格是否抛出异常</param>
		/// <returns>单元格文本内容</returns>
		[ComVisible(true)]
		
		public string GetCellTextByCellIndex(string strCellIndex, bool throwException)
		{
			XTextTableCellElement cellByCellIndex = GetCellByCellIndex(strCellIndex, throwException);
			if (cellByCellIndex == null)
			{
				return string.Empty;
			}
			return cellByCellIndex.Text;
		}

		/// <summary>
		///       获得指定序号的单元格文本内容
		///       </summary>
		/// <param name="rowIndex">从0开始的行号</param>
		/// <param name="colIndex">从0开始的列号</param>
		/// <param name="throwException">若未找到单元格是否抛出异常</param>
		/// <returns>获得的单元格文本内容</returns>
		
		[ComVisible(true)]
		public string GetCellText(int rowIndex, int colIndex, bool throwException)
		{
			XTextTableCellElement cell = GetCell(rowIndex, colIndex, throwException);
			if (cell == null)
			{
				return string.Empty;
			}
			return cell.Text;
		}

		/// <summary>
		///       获得指定序号的单元格对象
		///       </summary>
		/// <param name="rowIndex">从0开始的行号</param>
		/// <param name="colIndex">从0开始的列号</param>
		/// <param name="throwException">若未找到单元格是否抛出异常</param>
		/// <returns>找的单元格对象，若未找到而且不抛出异常则返回空引用</returns>
		[ComVisible(true)]
		public XTextTableCellElement GetCell(int rowIndex, int colIndex, bool throwException)
		{
			int num = 3;
			if (rowIndex >= 0 && rowIndex < RuntimeRows.Count)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)RuntimeRows[rowIndex];
				if (colIndex >= 0 && colIndex < xTextTableRowElement.Cells.Count)
				{
					return (XTextTableCellElement)xTextTableRowElement.Cells[colIndex];
				}
			}
			if (throwException)
			{
				throw new Exception("Bad RowIndex=" + rowIndex + ", ColIndex=" + colIndex);
			}
			return null;
		}

		/// <summary>
		///       根据两个单元格位置获得区域中被选择的单元格列表，包括被合并而隐藏的单元格
		///       </summary>
		/// <param name="rowIndex1">第一个单元格的行号</param>
		/// <param name="colIndex1">第一个单元格的列号</param>
		/// <param name="rowIndex2">第二个单元格的行号</param>
		/// <param name="colIndex2">第二个单元格的列号</param>
		/// <returns>单元格对象列表</returns>
		public XTextElementList GetSelectionCells(int rowIndex1, int colIndex1, int rowIndex2, int colIndex2)
		{
			int num = 11;
			if (rowIndex1 < 0 || rowIndex1 >= RuntimeRows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex1=" + rowIndex1);
			}
			if (rowIndex2 < 0 || rowIndex2 >= RuntimeRows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex2=" + rowIndex2);
			}
			if (colIndex1 < 0 || colIndex1 >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("colIndex1=" + colIndex1);
			}
			if (colIndex2 < 0 || colIndex2 >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("colIndex2=" + colIndex2);
			}
			XTextElementList range = GetRange(Math.Min(rowIndex1, rowIndex2), Math.Min(colIndex1, colIndex2), Math.Abs(rowIndex1 - rowIndex2) + 1, Math.Abs(colIndex1 - colIndex2) + 1, includeOverriedCell: true);
			for (int i = 0; i < range.Count; i++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)range[i];
				if (xTextTableCellElement.IsOverrided)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				rowIndex1 = Math.Min(rowIndex1, xTextTableCellElement.RowIndex);
				rowIndex2 = Math.Max(rowIndex2, xTextTableCellElement.RowIndex + xTextTableCellElement.RowSpan - 1);
				colIndex1 = Math.Min(colIndex1, xTextTableCellElement.ColIndex);
				colIndex2 = Math.Max(colIndex2, xTextTableCellElement.ColIndex + xTextTableCellElement.ColSpan - 1);
			}
			return GetRange(rowIndex1, colIndex1, rowIndex2 - rowIndex1 + 1, colIndex2 - colIndex1 + 1, includeOverriedCell: true);
		}

		
		public XTextTableCellElement method_42(float float_6, float float_7)
		{
			if (base.IsInCollapsedSection)
			{
				return null;
			}
			RectangleF absBounds = AbsBounds;
			if (absBounds.Contains(float_6, float_7))
			{
				XTextElementList runtimeRows = RuntimeRows;
				for (int num = runtimeRows.Count - 1; num >= 0; num--)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)runtimeRows[num];
					if (xTextTableRowElement.RuntimeVisible)
					{
						float num2 = absBounds.Top + xTextTableRowElement.Top;
						if (float_7 >= num2 && float_7 < num2 + xTextTableRowElement.MaxCellHeight)
						{
							foreach (XTextTableCellElement cell in xTextTableRowElement.Cells)
							{
								if (cell.RuntimeVisible && new RectangleF(absBounds.Left + cell.Left, num2, cell.Width, cell.Height).Contains(float_6, float_7))
								{
									return cell;
								}
							}
						}
					}
				}
			}
			return null;
		}

		public bool method_43(float float_6)
		{
			int num = 14;
			if (float_6 <= 0f)
			{
				throw new ArgumentOutOfRangeException("NewWidth=" + float_6);
			}
			float num2 = 0f;
			int num3 = 0;
			List<XTextTableColumnElement> list = new List<XTextTableColumnElement>();
			foreach (XTextTableColumnElement column in Columns)
			{
				if (column.RuntimeVisible)
				{
					num2 += column.Width;
					num3++;
					if (column.ZeroWidth)
					{
						list.Add(column);
					}
				}
			}
			bool result = false;
			if (list.Count == Columns.Count)
			{
				foreach (XTextTableColumnElement item in list)
				{
					item.Width = float_6 / (float)list.Count;
				}
				result = true;
				list.Clear();
			}
			else if (num2 != float_6 && num2 > 0f)
			{
				if (list.Count > 0 && float_6 > num2)
				{
					float width = (float_6 - num2) / (float)list.Count;
					foreach (XTextTableColumnElement item2 in list)
					{
						item2.Width = width;
						result = true;
					}
					list.Clear();
				}
				else
				{
					float num4 = float_6 / num2;
					foreach (XTextTableColumnElement column2 in Columns)
					{
						if (column2.RuntimeVisible)
						{
							column2.Width *= num4;
							result = true;
						}
					}
				}
			}
			if (list.Count > 0)
			{
				using (List<XTextTableColumnElement>.Enumerator enumerator2 = list.GetEnumerator())
				{
					if (enumerator2.MoveNext())
					{
						XTextTableColumnElement xTextTableColumnElement = enumerator2.Current;
						if (OwnerDocument == null)
						{
							xTextTableColumnElement.Width = 50f;
						}
						else
						{
							xTextTableColumnElement.Width = OwnerDocument.Options.ViewOptions.MinTableColumnWidth;
						}
						return true;
					}
				}
			}
			return result;
		}

		internal bool method_44()
		{
			bool result = false;
			for (int num = Columns.Count - 1; num > 0; num--)
			{
				bool flag = true;
				foreach (XTextTableRowElement row in Rows)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)row.Cells[num];
					if (!xTextTableCellElement.IsOverrided)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					result = true;
					XTextElementList xTextElementList = new XTextElementList();
					foreach (XTextTableRowElement row2 in Rows)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)row2.Cells[num];
						XTextTableCellElement overrideCell = xTextTableCellElement.OverrideCell;
						if (!xTextElementList.Contains(overrideCell))
						{
							xTextElementList.Add(overrideCell);
							overrideCell.method_60(overrideCell.ColSpan - 1);
						}
						row2.Cells.method_15(num);
					}
					XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)Columns[num];
					((XTextTableColumnElement)Columns[num - 1]).Width += xTextTableColumnElement.Width;
					Columns.method_15(num);
				}
			}
			for (int num2 = Rows.Count - 1; num2 > 0; num2--)
			{
				bool flag = true;
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[num2];
				foreach (XTextTableCellElement cell in xTextTableRowElement.Cells)
				{
					if (!cell.IsOverrided)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					result = true;
					XTextElementList xTextElementList = new XTextElementList();
					foreach (XTextTableCellElement cell2 in xTextTableRowElement.Cells)
					{
						XTextTableCellElement overrideCell = cell2.OverrideCell;
						if (!xTextElementList.Contains(overrideCell))
						{
							xTextElementList.Add(overrideCell);
							overrideCell.method_61(overrideCell.RowSpan - 1);
						}
					}
					Rows.method_15(num2);
				}
			}
			return result;
		}

		/// <summary>
		///       将插入点跳到指定单元格中
		///       </summary>
		/// <param name="rowIndex">从0开始计算的行号</param>
		/// <param name="colIndex">从0开始计算的列号</param>
		/// <returns>操作是否成功</returns>
		
		public bool EditorGotoCell(int rowIndex, int colIndex)
		{
			XTextTableCellElement xTextTableCellElement = GetCell(rowIndex, colIndex, throwException: false);
			if (xTextTableCellElement != null)
			{
				if (xTextTableCellElement.OverrideCell != null)
				{
					xTextTableCellElement = xTextTableCellElement.OverrideCell;
				}
				xTextTableCellElement.Focus();
				return true;
			}
			return false;
		}

		[Browsable(false)]
		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void method_45(int int_11, XTextElementList xtextElementList_4, bool bool_26, Dictionary<XTextTableCellElement, int> dictionary_0, bool bool_27)
		{
			int num = 7;
			if (xtextElementList_4 == null || xtextElementList_4.Count == 0)
			{
				throw new ArgumentNullException("newRows");
			}
			if (int_11 < 0 || int_11 > Rows.Count)
			{
				throw new ArgumentOutOfRangeException(string.Format(WriterStringsCore.ArgumentOutOfRange_Name_Value_Max_Min, "index", int_11, Rows.Count - 1, 0));
			}
			foreach (XTextTableRowElement item2 in xtextElementList_4)
			{
				if (Rows.Contains(item2))
				{
					throw new ArgumentException(WriterStringsCore.RowExistInTable);
				}
			}
			XTextUndoTableInfo xTextUndoTableInfo = null;
			if (bool_26)
			{
				xTextUndoTableInfo = new XTextUndoTableInfo();
			}
			if (xTextUndoTableInfo != null)
			{
				xTextUndoTableInfo.OldTableInfo = new Class116(this);
			}
			bool uIIsUpdating = UIIsUpdating;
			for (int i = 0; i < xtextElementList_4.Count; i++)
			{
				XTextTableRowElement item = (XTextTableRowElement)xtextElementList_4[i];
				item.Parent = this;
				item.OwnerDocument = OwnerDocument;
				Rows.method_13(int_11 + i, item);
				if (uIIsUpdating)
				{
					foreach (XTextTableCellElement cell in item.Cells)
					{
						cell.FixElements();
					}
				}
				else
				{
					foreach (XTextTableCellElement cell2 in item.Cells)
					{
						cell2.vmethod_36(bool_22: false);
						cell2.ExecuteLayout();
					}
				}
			}
			OwnerDocument.method_62(xtextElementList_4);
			if (OwnerDocument.ExpressionExecuter != null)
			{
				OwnerDocument.ExpressionExecuter.imethod_10(OwnerDocument, this, int_11, xtextElementList_4.Count);
			}
			UpdateContentVersion();
			if (dictionary_0 != null && dictionary_0.Count > 0)
			{
				foreach (XTextTableCellElement key in dictionary_0.Keys)
				{
					int num2 = dictionary_0[key];
					if (key.RowSpan != num2)
					{
						key.method_61(num2);
						key.UpdateContentVersion();
					}
				}
			}
			else if (bool_27)
			{
				for (int i = 0; i < int_11; i++)
				{
					XTextTableRowElement item = (XTextTableRowElement)Rows[i];
					foreach (XTextTableCellElement cell3 in item.Cells)
					{
						if (!cell3.IsOverrided && cell3.RowSpan > 1 && cell3.RowIndex + cell3.RowSpan + 1 > int_11)
						{
							int num2 = cell3.RowSpan + xtextElementList_4.Count;
							if (cell3.RowSpan != num2)
							{
								cell3.method_61(num2);
								cell3.UpdateContentVersion();
							}
						}
					}
				}
			}
			xtextElementList_2 = null;
			method_34();
			ExecuteLayout();
			ContentElement.vmethod_36(bool_22: true);
			base.DocumentContentElement.method_70();
			InvalidateHighlightInfo();
			InvalidateView();
			OwnerDocument.Modified = true;
			method_41(bool_26: true);
			_ = ContentElement;
			XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xtextElementList_4[0].Elements[0];
			if (xTextTableCellElement2.IsOverrided)
			{
				xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
			}
			base.DocumentContentElement.SetSelection(xTextTableCellElement2.PrivateContent[0].ViewIndex, 0);
			if (xTextUndoTableInfo != null)
			{
				xTextUndoTableInfo.NewTableInfo = new Class116(this);
			}
			if (bool_26 && OwnerDocument.BeginLogUndo())
			{
				OwnerDocument.UndoList.method_14(xTextUndoTableInfo);
				OwnerDocument.EndLogUndo();
				OwnerDocument.OnSelectionChanged();
				OwnerDocument.OnDocumentContentChanged();
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		
		public bool method_46(int int_11, int int_12, bool bool_26, Dictionary<XTextTableCellElement, int> dictionary_0)
		{
			int num = 17;
			if (int_11 < 0 || int_11 > Rows.Count)
			{
				throw new ArgumentOutOfRangeException("startRowIndex=" + int_11);
			}
			if (int_12 < 0)
			{
				throw new ArgumentOutOfRangeException(string.Format(WriterStringsCore.ArgumentOutOfRange_Name_Value_Max_Min, "rowsCount", int_12, Rows.Count - 1, 0));
			}
			if (int_11 + int_12 > Rows.Count)
			{
				throw new ArgumentOutOfRangeException(string.Format(WriterStringsCore.ArgumentOutOfRange_Name_Value_Max_Min, "startRowIndex + rowsCount", int_11 + int_12, Rows.Count - 1, 0));
			}
			XTextUndoTableInfo xTextUndoTableInfo = null;
			if (bool_26)
			{
				xTextUndoTableInfo = new XTextUndoTableInfo();
				xTextUndoTableInfo.OldTableInfo = new Class116(this);
			}
			InvalidateView();
			if (OwnerDocument.HighlightManager != null)
			{
				for (int i = 0; i < int_12; i++)
				{
					OwnerDocument.HighlightManager.imethod_8(Rows[int_11 + i]);
				}
			}
			Rows.RemoveRange(int_11, int_12);
			if (OwnerDocument.ExpressionExecuter != null)
			{
				OwnerDocument.ExpressionExecuter.imethod_10(OwnerDocument, this, int_11, -int_12);
			}
			UpdateContentVersion();
			if (dictionary_0 != null && dictionary_0.Count > 0)
			{
				foreach (XTextTableCellElement key in dictionary_0.Keys)
				{
					key.method_61(dictionary_0[key]);
				}
			}
			else
			{
				for (int i = 0; i < int_11; i++)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[i];
					foreach (XTextTableCellElement cell in xTextTableRowElement.Cells)
					{
						if (!cell.IsOverrided && cell.RowSpan > 1 && cell.RowIndex + cell.RowSpan + 1 > int_11)
						{
							int num2 = cell.RowSpan - int_12;
							if (num2 < int_11 - i)
							{
								num2 = int_11 - i;
							}
							cell.method_61(num2);
						}
					}
				}
			}
			xtextElementList_2 = null;
			ExecuteLayout();
			InvalidateView();
			OwnerDocument.Modified = true;
			ContentElement.vmethod_36(bool_22: true);
			base.DocumentContentElement.method_70();
			method_41(bool_26: true);
			if (int_11 > Rows.Count)
			{
				int_11 = Rows.Count - 1;
			}
			XTextTableCellElement xTextTableCellElement = GetCell(Math.Max(0, int_11 - 1), 0, throwException: false);
			if (xTextTableCellElement.IsOverrided)
			{
				xTextTableCellElement = xTextTableCellElement.OverrideCell;
			}
			base.DocumentContentElement.Content.LineEndFlag = false;
			base.DocumentContentElement.SetSelection(xTextTableCellElement.PrivateContent[0].ViewIndex, 0);
			if (xTextUndoTableInfo != null)
			{
				xTextUndoTableInfo.NewTableInfo = new Class116(this);
			}
			if (bool_26 && OwnerDocument.BeginLogUndo())
			{
				OwnerDocument.UndoList.method_14(xTextUndoTableInfo);
				OwnerDocument.EndLogUndo();
				OwnerDocument.OnSelectionChanged();
				OwnerDocument.OnDocumentContentChanged();
			}
			return true;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		
		[Browsable(false)]
		public void method_47(int int_11, XTextElementList xtextElementList_4, XTextElementList xtextElementList_5, bool bool_26, Dictionary<XTextTableCellElement, int> dictionary_0, bool bool_27, Dictionary<XTextTableColumnElement, float> dictionary_1)
		{
			int num = 6;
			if (int_11 < 0 || int_11 > Columns.Count)
			{
				throw new ArgumentOutOfRangeException(string.Format(WriterStringsCore.ArgumentOutOfRange_Name_Value_Max_Min, "index", int_11, Columns.Count - 1, 0));
			}
			if (xtextElementList_4 == null || xtextElementList_4.Count == 0)
			{
				throw new ArgumentNullException("newColumns");
			}
			float num2 = 0f;
			foreach (XTextTableColumnElement column in Columns)
			{
				num2 += column.Width;
			}
			foreach (XTextTableColumnElement item in xtextElementList_4)
			{
				if (Columns.Contains(item))
				{
					throw new ArgumentException("col existed in table");
				}
				if (item.Width < OwnerDocument.Options.ViewOptions.MinTableColumnWidth)
				{
					item.Width = OwnerDocument.Options.ViewOptions.MinTableColumnWidth;
				}
				item.Parent = this;
			}
			XTextUndoTableInfo xTextUndoTableInfo = null;
			if (bool_26)
			{
				xTextUndoTableInfo = new XTextUndoTableInfo();
				xTextUndoTableInfo.OldTableInfo = new Class116(this);
			}
			XTextElementList xTextElementList = new XTextElementList();
			method_40();
			Columns.method_12(int_11, xtextElementList_4);
			if (OwnerDocument.ExpressionExecuter != null)
			{
				OwnerDocument.ExpressionExecuter.imethod_11(OwnerDocument, this, int_11, xtextElementList_4.Count);
			}
			UpdateContentVersion();
			if (xtextElementList_5 != null && xtextElementList_5.Count == Rows.Count * xtextElementList_4.Count)
			{
				for (int i = 0; i < Rows.Count; i++)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[i];
					for (int j = 0; j < xtextElementList_4.Count; j++)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xtextElementList_5[i * xtextElementList_4.Count + j];
						xTextTableCellElement.Parent = xTextTableRowElement;
						xTextTableCellElement.FixElements();
						xTextTableRowElement.Cells.method_13(int_11 + j, xTextTableCellElement);
						xTextElementList.Add(xTextTableCellElement);
					}
				}
			}
			else
			{
				using (DCGraphics dcgraphics_ = OwnerDocument.CreateDCGraphics())
				{
					foreach (XTextTableRowElement row in Rows)
					{
						XTextTableCellElement xTextTableCellElement2 = null;
						xTextTableCellElement2 = ((int_11 != 0) ? ((XTextTableCellElement)row.Cells[int_11 - 1]) : ((XTextTableCellElement)row.Cells[int_11]));
						if (xTextTableCellElement2.IsOverrided)
						{
							xTextTableCellElement2 = xTextTableCellElement2.OverrideCell;
						}
						foreach (XTextTableColumnElement item2 in xtextElementList_4)
						{
							XTextTableCellElement xTextTableCellElement = null;
							if (xTextTableCellElement2 != null)
							{
								xTextTableCellElement = xTextTableCellElement2.EditorClone();
							}
							else
							{
								xTextTableCellElement = CreateCellInstance();
								XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
								xTextParagraphFlagElement.AutoCreate = true;
								if (xTextTableCellElement2 != null)
								{
									foreach (XTextElement element in xTextTableCellElement2.Elements)
									{
										if (element is XTextParagraphFlagElement)
										{
											xTextParagraphFlagElement.StyleIndex = element.StyleIndex;
											break;
										}
									}
								}
								xTextTableCellElement.Elements.Clear();
								xTextTableCellElement.Elements.Add(xTextParagraphFlagElement);
								xTextTableCellElement.FixElements();
							}
							xTextTableCellElement.Parent = row;
							xTextTableCellElement.StyleIndex = xTextTableCellElement2.StyleIndex;
							row.Cells.method_13(int_11, xTextTableCellElement);
							xTextElementList.Add(xTextTableCellElement);
							DocumentPaintEventArgs documentPaintEventArgs = OwnerDocument.method_55(dcgraphics_);
							documentPaintEventArgs.Element = xTextTableCellElement;
							xTextTableCellElement.RefreshSize(documentPaintEventArgs);
						}
					}
				}
			}
			if (dictionary_0 != null && dictionary_0.Count > 0)
			{
				foreach (XTextTableCellElement key in dictionary_0.Keys)
				{
					key.method_60(dictionary_0[key]);
				}
			}
			else
			{
				foreach (XTextTableCellElement visibleCell in VisibleCells)
				{
					if (visibleCell.ColSpan > 1 && visibleCell.ColIndex + visibleCell.ColSpan - 1 >= int_11 && visibleCell.ColIndex <= int_11)
					{
						int int_12 = visibleCell.ColSpan + xtextElementList_4.Count;
						visibleCell.method_60(int_12);
					}
				}
			}
			if (dictionary_1 != null && dictionary_1.Count > 0)
			{
				foreach (XTextTableColumnElement column2 in Columns)
				{
					if (dictionary_1.ContainsKey(column2))
					{
						column2.Width = dictionary_1[column2];
					}
				}
			}
			else if (bool_27)
			{
				float num3 = 0f;
				foreach (XTextTableColumnElement column3 in Columns)
				{
					num3 += column3.Width;
				}
				float num4 = num2 / num3;
				foreach (XTextTableColumnElement column4 in Columns)
				{
					column4.Width *= num4;
				}
			}
			if (xTextElementList.Count > 0)
			{
				OwnerDocument.method_62(xTextElementList);
			}
			float height = Height;
			ExecuteLayout();
			ContentElement.vmethod_36(bool_22: true);
			base.DocumentContentElement.method_70();
			InvalidateHighlightInfo();
			InvalidateView();
			OwnerDocument.Modified = true;
			method_41(height != Height);
			XTextTableCellElement xTextTableCellElement3 = GetCell(0, int_11, throwException: false);
			if (xTextTableCellElement3.IsOverrided)
			{
				xTextTableCellElement3 = xTextTableCellElement3.OverrideCell;
			}
			base.DocumentContentElement.SetSelection(xTextTableCellElement3.PrivateContent[0].ViewIndex, 0);
			if (bool_26 && OwnerDocument.BeginLogUndo())
			{
				xTextUndoTableInfo.NewTableInfo = new Class116(this);
				OwnerDocument.UndoList.method_14(xTextUndoTableInfo);
				OwnerDocument.EndLogUndo();
				OwnerDocument.OnSelectionChanged();
				OwnerDocument.OnDocumentContentChanged();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		
		[Browsable(false)]
		public bool method_48(int int_11, int int_12, bool bool_26, Dictionary<XTextTableCellElement, int> dictionary_0, bool bool_27, Dictionary<XTextTableColumnElement, float> dictionary_1)
		{
			int num = 19;
			if (int_11 < 0 || int_11 >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException(string.Format(WriterStringsCore.ArgumentOutOfRange_Name_Value_Max_Min, "startColumnIndex", int_11, Columns.Count - 1, 0));
			}
			if (int_12 <= 0)
			{
				throw new ArgumentOutOfRangeException("colCount=" + int_12);
			}
			if (int_11 + int_12 > Columns.Count)
			{
				throw new ArgumentOutOfRangeException(string.Format(WriterStringsCore.ArgumentOutOfRange_Name_Value_Max_Min, "startIndex+Count", int_11 + int_12, Columns.Count - 1, 0));
			}
			float num2 = 0f;
			foreach (XTextTableColumnElement column in Columns)
			{
				num2 += column.Width;
			}
			XTextUndoTableInfo xTextUndoTableInfo = null;
			if (bool_26)
			{
				xTextUndoTableInfo = new XTextUndoTableInfo();
				xTextUndoTableInfo.OldTableInfo = new Class116(this);
			}
			Columns.RemoveRange(int_11, int_12);
			if (OwnerDocument.ExpressionExecuter != null)
			{
				OwnerDocument.ExpressionExecuter.imethod_11(OwnerDocument, this, int_11, -int_12);
			}
			UpdateContentVersion();
			foreach (XTextTableRowElement row in Rows)
			{
				if (row.Cells.Count > int_11)
				{
					if (OwnerDocument.HighlightManager != null)
					{
						for (int i = 0; i < int_12; i++)
						{
							XTextElement xtextElement_ = row.Cells[int_11 + i];
							OwnerDocument.HighlightManager.imethod_8(xtextElement_);
						}
					}
					row.Cells.RemoveRange(int_11, int_12);
					if (dictionary_0 != null && dictionary_0.Count > 0)
					{
						foreach (XTextTableCellElement key in dictionary_0.Keys)
						{
							key.method_60(dictionary_0[key]);
						}
					}
					else
					{
						for (int i = 0; i < int_11; i++)
						{
							XTextTableCellElement current = (XTextTableCellElement)row.Cells[i];
							if (!current.IsOverrided && current.ColSpan > 1 && current.ColIndex + current.ColSpan - 1 >= int_11)
							{
								int num3 = current.ColSpan - int_12;
								if (num3 < int_11 - i)
								{
									num3 = int_11 - i;
								}
								current.method_60(num3);
								break;
							}
						}
					}
				}
			}
			if (dictionary_1 != null && dictionary_1.Count > 0)
			{
				foreach (XTextTableColumnElement column2 in Columns)
				{
					if (dictionary_1.ContainsKey(column2))
					{
						column2.Width = dictionary_1[column2];
					}
				}
			}
			else if (bool_27)
			{
				float num4 = 0f;
				foreach (XTextTableColumnElement column3 in Columns)
				{
					num4 += column3.Width;
				}
				float num5 = num2 / num4;
				foreach (XTextTableColumnElement column4 in Columns)
				{
					column4.Width *= num5;
				}
			}
			float height = Height;
			InvalidateView();
			ExecuteLayout();
			InvalidateView();
			ContentElement.vmethod_36(bool_22: true);
			base.DocumentContentElement.method_70();
			method_41(height != Height);
			OwnerDocument.Modified = true;
			XTextTableCellElement xTextTableCellElement = GetCell(0, (int_11 >= Columns.Count) ? (int_11 - 1) : int_11, throwException: false);
			if (xTextTableCellElement.IsOverrided)
			{
				xTextTableCellElement = xTextTableCellElement.OverrideCell;
			}
			base.DocumentContentElement.SetSelection(xTextTableCellElement.PrivateContent[0].ViewIndex, 0);
			if (bool_26 && OwnerDocument.BeginLogUndo())
			{
				xTextUndoTableInfo.NewTableInfo = new Class116(this);
				OwnerDocument.UndoList.method_14(xTextUndoTableInfo);
				OwnerDocument.EndLogUndo();
				OwnerDocument.OnSelectionChanged();
				OwnerDocument.OnDocumentContentChanged();
			}
			return true;
		}

		internal bool method_49(Class116 class116_0)
		{
			int num = 10;
			if (class116_0 == null)
			{
				throw new ArgumentNullException("tableInfo");
			}
			if (class116_0.method_2() != this)
			{
				throw new ArgumentException("info 不属于该表格");
			}
			InvalidateView();
			class116_0.method_15(this, bool_0: true);
			InvalidateView();
			InvalidateView();
			ContentElement.vmethod_36(bool_22: true);
			base.DocumentContentElement.method_70();
			method_41(bool_26: false);
			base.DocumentContentElement.method_69();
			OwnerDocument.Modified = true;
			if (class116_0.method_0() >= 0)
			{
				base.DocumentContentElement.SetSelection(class116_0.method_0(), 0);
			}
			OwnerDocument.OnSelectionChanged();
			OwnerDocument.OnDocumentContentChanged();
			return true;
		}

		/// <summary>
		///       设置表格标题行样式
		///       </summary>
		/// <param name="headerStyles">新的标题行样式</param>
		/// <param name="logUndo">是否记录撤销操作信息</param>
		/// <returns>操作是否修改了文档内容</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public bool EditorSetHeaderRow(Dictionary<XTextTableRowElement, bool> headerStyles, bool logUndo)
		{
			if (headerStyles == null || headerStyles.Count == 0)
			{
				return false;
			}
			bool flag = false;
			XTextUndoHeaderRow xTextUndoHeaderRow = new XTextUndoHeaderRow();
			xTextUndoHeaderRow.Table = this;
			foreach (XTextTableRowElement key in headerStyles.Keys)
			{
				if (key.RuntimeHeaderStyle != headerStyles[key])
				{
					flag = true;
					xTextUndoHeaderRow.OldHeaderStyles[key] = key.HeaderStyle;
					xTextUndoHeaderRow.NewHeaderStyles[key] = headerStyles[key];
					key.HeaderStyle = headerStyles[key];
				}
			}
			if (flag)
			{
				UpdateContentVersion();
				OwnerDocument.Modified = true;
				if (logUndo && OwnerDocument.CanLogUndo)
				{
					OwnerDocument.UndoList.method_14(xTextUndoHeaderRow);
				}
				if (OwnerDocument.EditorControl != null && (OwnerDocument.EditorControl.ViewMode == PageViewMode.Normal || OwnerDocument.EditorControl.ViewMode == PageViewMode.NormalCenter))
				{
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Element = this;
					method_23(contentChangedEventArgs);
					return flag;
				}
				xtextElementList_2 = null;
				method_39();
				method_41(bool_26: true);
				ContentChangedEventArgs contentChangedEventArgs2 = new ContentChangedEventArgs();
				contentChangedEventArgs2.Element = this;
				method_23(contentChangedEventArgs2);
			}
			return flag;
		}

		protected override bool vmethod_26(string string_16, bool bool_26)
		{
			return false;
		}

		/// <summary>
		///       使用指定的数据源对象更新数据源绑定
		///       </summary>
		/// <param name="dataSource">数据源对象</param>
		/// <param name="fastMode">是否为快速模式</param>
		/// <returns>操作是否修改了文档内容</returns>
		public override int UpdateDataBindingExt(UpdateDataBindingArgs args)
		{
			int num = 7;
			XTextDocument ownerDocument = OwnerDocument;
			if (!ownerDocument.Options.BehaviorOptions.EnableDataBinding)
			{
				return 0;
			}
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			XDataBinding xDataBinding = RuntimeSupportValueBinding ? base.ValueBinding : null;
			if (!args.CheckForSpecifyParameterName(xDataBinding))
			{
				return 0;
			}
			int num2 = 0;
			xtextElementList_2 = null;
			DataSourceTreeNode dataBoundNode = method_2(xDataBinding, args);
			if (ownerDocument.method_104(xDataBinding))
			{
				dataBoundNode = method_2(xDataBinding, args);
			}
			base.DataBoundNode = dataBoundNode;
			FixDomState();
			List<XTextTableRowElement> list = new List<XTextTableRowElement>();
			foreach (XTextTableRowElement row in Rows)
			{
				if (!row.RuntimeSupportValueBinding || !ownerDocument.method_104(row.ValueBinding) || !OwnerDocument.Options.BehaviorOptions.CheckedValueBindingHandledForTableRow || !row.GenerateByValueBingding)
				{
					list.Add(row);
				}
			}
			xtextElementList_2 = null;
			XTextElementList xTextElementList = new XTextElementList();
			for (int i = 0; i < list.Count; i++)
			{
				XTextTableRowElement xTextTableRowElement = list[i];
				if (xTextTableRowElement.RuntimeSupportValueBinding && OwnerDocument.method_104(xTextTableRowElement.ValueBinding))
				{
					List<XTextTableRowElement> list2 = new List<XTextTableRowElement>();
					for (int j = 0; j < xTextTableRowElement.DataSourceRowSpan; j++)
					{
						int num3 = i + j;
						if (num3 >= list.Count)
						{
							break;
						}
						list2.Add(xTextTableRowElement);
					}
					i += xTextTableRowElement.DataSourceRowSpan - 1;
					DataSourceTreeNode dataSourceTreeNode = xTextTableRowElement.method_2(xTextTableRowElement.ValueBinding, args);
					if (dataSourceTreeNode?.IsEmpty ?? true)
					{
						continue;
					}
					DataSourceTreeNodeList dataSourceTreeNodeList = new DataSourceTreeNodeList();
					if (dataSourceTreeNode.OwnerDocument.LongPathMode)
					{
						if (dataSourceTreeNode.Nodes != null && dataSourceTreeNode.Nodes.Count > 0)
						{
							dataSourceTreeNodeList.AddRange(dataSourceTreeNode.Nodes);
						}
					}
					else if (dataSourceTreeNode.RuntimeIsList)
					{
						if (dataSourceTreeNode.Nodes == null || dataSourceTreeNode.Nodes.Count == 0)
						{
							dataSourceTreeNode.ExpandListItemNodes();
						}
						if (dataSourceTreeNode.Nodes != null)
						{
							dataSourceTreeNodeList.AddRange(dataSourceTreeNode.Nodes);
						}
					}
					else if (dataSourceTreeNode.DataBoundItem is XmlNode)
					{
						if (dataSourceTreeNode.Nodes == null || dataSourceTreeNode.Nodes.Count == 0)
						{
							dataSourceTreeNode.ExpandSubNodes();
						}
						if (dataSourceTreeNode.Nodes != null)
						{
							dataSourceTreeNodeList.AddRange(dataSourceTreeNode.Nodes);
						}
					}
					else
					{
						dataSourceTreeNodeList.Add(dataSourceTreeNode);
					}
					if (xTextTableRowElement.ExpendForDataBinding)
					{
						bool flag = true;
						int num4 = 0;
						foreach (DataSourceTreeNode item in dataSourceTreeNodeList)
						{
							foreach (XTextTableRowElement item2 in list2)
							{
								XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)item2.Clone(Deeply: true);
								if (flag)
								{
									item2.GenerateByValueBingding = false;
								}
								else
								{
									item2.GenerateByValueBingding = true;
								}
								xTextTableRowElement2.ValueBinding = null;
								xTextTableRowElement2.Parent = this;
								xTextTableRowElement2.OwnerDocument = ownerDocument;
								xTextTableRowElement2.FixDomState();
								xTextTableRowElement2.DataBoundNode = item;
								UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
								updateDataBindingArgs.DataNode = item;
								updateDataBindingArgs.FastMode = args.FastMode;
								xTextTableRowElement2.method_26(updateDataBindingArgs);
								xTextElementList.Add(xTextTableRowElement2);
								xTextTableRowElement2.FixDomState();
								num2++;
								num4++;
							}
							flag = false;
						}
						if (xTextTableRowElement.CloneMultipleBaseForBindingDataSource <= 1)
						{
							continue;
						}
						int num5 = num4 % xTextTableRowElement.CloneMultipleBaseForBindingDataSource;
						if (num5 > 0)
						{
							num5 = xTextTableRowElement.CloneMultipleBaseForBindingDataSource - num5;
							for (int j = 0; j < num5; j++)
							{
								foreach (XTextTableRowElement item3 in list2)
								{
									XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)item3.Clone(Deeply: true);
									item3.GenerateByValueBingding = true;
									xTextTableRowElement2.Parent = this;
									xTextTableRowElement2.OwnerDocument = ownerDocument;
									xTextTableRowElement2.FixDomState();
									xTextElementList.Add(xTextTableRowElement2);
								}
							}
						}
					}
					else
					{
						UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
						updateDataBindingArgs.DataNode = dataSourceTreeNodeList[0];
						updateDataBindingArgs.FastMode = args.FastMode;
						foreach (XTextTableRowElement item4 in list2)
						{
							item4.GenerateByValueBingding = false;
							int num6 = item4.UpdateDataBindingExt(updateDataBindingArgs);
							if (num6 > 0)
							{
								item4.FixDomState();
							}
							num2 += num6;
							xTextElementList.Add(item4);
						}
					}
				}
				else
				{
					UpdateDataBindingArgs updateDataBindingArgs = new UpdateDataBindingArgs();
					updateDataBindingArgs.FastMode = args.FastMode;
					updateDataBindingArgs.SpecifyParameterNames = args.SpecifyParameterNames;
					int num6 = xTextTableRowElement.UpdateDataBindingExt(updateDataBindingArgs);
					if (num6 > 0)
					{
						xTextTableRowElement.FixDomState();
					}
					num2 += num6;
					xTextElementList.Add(xTextTableRowElement);
				}
			}
			Rows.Clear();
			Rows.AddRange(xTextElementList);
			Subfield(updateView: false);
			xtextElementList_2 = null;
			if (!args.FastMode)
			{
				EditorRefreshView();
			}
			if (num2 > 0)
			{
				int_7++;
			}
			return num2;
		}

		/// <summary>
		///       创建一个新的单元格对象
		///       </summary>
		/// <remarks>
		///       从XDesignerLib上派生的设计器中可以实现扩展表格模型,实现自己的
		///       表格单元格元素类型,此时需要重载该函数来返回扩展的表格单元格
		///       对象实例.
		///       </remarks>
		/// <returns>新的单元格对象</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public XTextTableCellElement CreateCellInstance()
		{
			XTextTableCellElement xTextTableCellElement = new XTextTableCellElement();
			xTextTableCellElement.OwnerDocument = OwnerDocument;
			return xTextTableCellElement;
		}

		/// <summary>
		///       创建一个新的单元格对象
		///       </summary>
		/// <param name="templateCell">用作模板的单元格对象</param>
		/// <remarks>
		///       从XDesignerLib上派生的设计器中可以实现扩展表格模型,实现自己的
		///       表格单元格元素类型,此时需要重载该函数来返回扩展的表格单元格
		///       对象实例.
		///       </remarks>
		/// <returns>新的单元格对象</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public XTextTableCellElement CreateCellInstance(XTextTableCellElement templateCell)
		{
			XTextTableCellElement xTextTableCellElement = CreateCellInstance();
			if (templateCell != null)
			{
				xTextTableCellElement.StyleIndex = templateCell.StyleIndex;
				xTextTableCellElement.Elements.Clear();
				if (templateCell.Elements.LastElement is XTextParagraphFlagElement)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
					xTextParagraphFlagElement.StyleIndex = templateCell.Elements.LastElement.StyleIndex;
					if (xTextParagraphFlagElement.StyleIndex < 0)
					{
						xTextParagraphFlagElement.AutoCreate = true;
					}
					xTextTableCellElement.Elements.Add(xTextParagraphFlagElement);
				}
			}
			return xTextTableCellElement;
		}

		/// <summary>
		///       创建一个新的表格列对象
		///       </summary>
		/// <remarks>
		///       从XDesignerLib上派生的设计器中可以实现扩展表格模型,实现自己的
		///       表格单元格元素类型,此时需要重载该函数来返回扩展的表格列
		///       对象实例.
		///       </remarks>
		/// <returns>新的表格列对象</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public XTextTableColumnElement CreateColumnInstance()
		{
			XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
			xTextTableColumnElement.OwnerDocument = OwnerDocument;
			xTextTableColumnElement.Parent = this;
			return xTextTableColumnElement;
		}

		/// <summary>
		///       创建一个新的表格行对象
		///       </summary>
		/// <remarks>
		///       从XDesignerLib上派生的设计器中可以实现扩展表格模型,实现自己的
		///       表格单元格元素类型,此时需要重载该函数来返回扩展的表格行
		///       对象实例.
		///       </remarks>
		/// <returns>新的表格行对象</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public XTextTableRowElement CreateRowInstance()
		{
			XTextTableRowElement xTextTableRowElement = new XTextTableRowElement();
			xTextTableRowElement.OwnerDocument = OwnerDocument;
			xTextTableRowElement.Parent = this;
			return xTextTableRowElement;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="Deeply">是否复制子孙节点</param>
		/// <returns>复制品</returns>
		public override XTextElement Clone(bool Deeply)
		{
			XTextTableElement xTextTableElement = (XTextTableElement)base.Clone(Deeply);
			xTextTableElement.xtextElementList_2 = null;
			if (Deeply)
			{
				xTextTableElement.xtextElementList_3 = new XTextElementList();
				foreach (XTextTableColumnElement column in Columns)
				{
					XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)column.Clone(Deeply: true);
					xTextTableColumnElement2.Parent = this;
					xTextTableElement.xtextElementList_3.Add(xTextTableColumnElement2);
				}
			}
			else
			{
				xTextTableElement.xtextElementList_3 = new XTextElementList();
			}
			foreach (XTextTableCellElement cell in xTextTableElement.Cells)
			{
				cell.Width = 0f;
				cell.Height = 0f;
			}
			return xTextTableElement;
		}

		
		public bool Subfield(bool updateView)
		{
			if ((SubfieldMode == TableSubfieldMode.LeftRightAndUpDown || SubfieldMode == TableSubfieldMode.UpDownAndLeftRight) && SubfieldNumber > 1)
			{
				bool result = SubfieldSpecify(SubfieldMode, SubfieldNumber, updateView);
				SubfieldMode = TableSubfieldMode.None;
				SubfieldNumber = 1;
				return result;
			}
			return false;
		}

		
		public bool SubfieldSpecify(TableSubfieldMode mode, int number, bool updateView)
		{
			if (!XTextDocument.smethod_13(GEnum6.const_95))
			{
				return false;
			}
			if (number <= 1 || mode == TableSubfieldMode.None || Rows.Count == 0 || Columns.Count == 0)
			{
				return false;
			}
			FixDomState();
			method_40();
			List<XTextTableRowElement> list = new List<XTextTableRowElement>();
			List<XTextTableRowElement> list2 = new List<XTextTableRowElement>();
			foreach (XTextTableRowElement row in Rows)
			{
				if (row.RuntimeHeaderStyle)
				{
					list.Add(row);
				}
				else
				{
					list2.Add(row);
				}
			}
			int num = (int)Math.Ceiling((double)list2.Count / (double)number);
			XTextElementList xTextElementList = new XTextElementList();
			for (int i = 0; i < number; i++)
			{
				foreach (XTextTableColumnElement column in Columns)
				{
					xTextElementList.Add((XTextTableColumnElement)column.Clone(Deeply: false));
				}
			}
			List<XTextTableRowElement> list3 = new List<XTextTableRowElement>();
			if (list.Count > 0)
			{
				foreach (XTextTableRowElement item in list)
				{
					XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)item.Clone(Deeply: false);
					list3.Add(xTextTableRowElement2);
					for (int i = 0; i < number; i++)
					{
						foreach (XTextTableCellElement cell in item.Cells)
						{
							XTextTableCellElement element = (XTextTableCellElement)cell.Clone(Deeply: true);
							xTextTableRowElement2.Cells.Add(element);
						}
					}
				}
			}
			List<XTextTableRowElement> list4 = new List<XTextTableRowElement>();
			if (list2.Count > 0)
			{
				switch (mode)
				{
				case TableSubfieldMode.LeftRightAndUpDown:
				{
					XTextTableRowElement xTextTableRowElement4 = null;
					int num2 = Columns.Count * number;
					foreach (XTextTableRowElement item2 in list2)
					{
						foreach (XTextTableCellElement cell2 in item2.Cells)
						{
							if (xTextTableRowElement4 == null || xTextTableRowElement4.Cells.Count == num2)
							{
								xTextTableRowElement4 = (XTextTableRowElement)item2.Clone(Deeply: false);
								list4.Add(xTextTableRowElement4);
							}
							xTextTableRowElement4.Cells.Add(cell2);
						}
					}
					break;
				}
				case TableSubfieldMode.UpDownAndLeftRight:
				{
					for (int j = 0; j < num; j++)
					{
						XTextTableRowElement xTextTableRowElement = list2[j];
						list4.Add(xTextTableRowElement);
						for (int k = j + num; k < list2.Count; k += num)
						{
							XTextTableRowElement xTextTableRowElement3 = list2[k];
							xTextTableRowElement.Cells.AddRange(xTextTableRowElement3.Cells);
							xTextTableRowElement3.Cells.Clear();
						}
					}
					for (int i = list2.Count - 1; i >= 0; i--)
					{
						if (list2[i].Cells.Count == 0)
						{
							list2.RemoveAt(i);
						}
					}
					break;
				}
				}
				Rows.Clear();
				foreach (XTextTableRowElement item3 in list3)
				{
					item3.DataBoundNode = null;
					item3.DataBoundNodeValueUsed = false;
					item3.ValueBinding = null;
					Rows.Add(item3);
				}
				foreach (XTextTableRowElement item4 in list4)
				{
					item4.DataBoundNode = null;
					item4.DataBoundNodeValueUsed = false;
					item4.ValueBinding = null;
					Rows.Add(item4);
				}
			}
			Columns.Clear();
			Columns.AddRange(xTextElementList);
			xtextElementList_2 = null;
			FixDomState();
			method_40();
			if (updateView)
			{
				EditorRefreshView();
			}
			return true;
		}

		internal bool method_50(XTextTableRowElement xtextTableRowElement_0, RectangleF rectangleF_0)
		{
			if (rectangleF_0.IsEmpty)
			{
				return true;
			}
			RectangleF absBounds = xtextTableRowElement_0.AbsBounds;
			RectangleF rectangleF = RectangleF.Intersect(rectangleF_0, absBounds);
			if (!rectangleF.IsEmpty && rectangleF.Height > 4f)
			{
				return true;
			}
			return false;
		}

		[Browsable(false)]
		
		[ComVisible(false)]
		public void method_51(out XTextElementList xtextElementList_4, out XTextElementList xtextElementList_5)
		{
			xtextElementList_4 = new XTextElementList();
			xtextElementList_5 = new XTextElementList();
			XTextDocumentContentElement documentContentElement = base.DocumentContentElement;
			if (documentContentElement.Selection.Cells != null)
			{
				foreach (XTextTableCellElement cell in documentContentElement.Selection.Cells)
				{
					if (cell.OwnerTable == this)
					{
						if (!xtextElementList_4.Contains(cell.OwnerRow))
						{
							xtextElementList_4.Add(cell.OwnerRow);
						}
						xtextElementList_5.Add(cell);
						if (cell.RowSpan > 1 || cell.ColSpan > 1)
						{
						}
					}
				}
			}
		}

		public override void vmethod_19(GClass103 gclass103_0)
		{
			int num = 9;
			int num2 = 1;
			for (XTextElement parent = Parent; parent != null; parent = parent.Parent)
			{
				if (parent is XTextTableCellElement)
				{
					num2++;
				}
			}
			int num3 = 0;
			if (gclass103_0.method_18() != null && !(gclass103_0.method_18() is XTextTableElement))
			{
				gclass103_0.method_10().method_14("par");
			}
			gclass103_0.method_10().method_12();
			XTextElementList xtextElementList_ = null;
			XTextElementList xtextElementList_2 = null;
			_ = base.DocumentContentElement;
			if (gclass103_0.vmethod_0())
			{
				method_51(out xtextElementList_, out xtextElementList_2);
			}
			else
			{
				xtextElementList_ = Rows;
			}
			foreach (XTextTableRowElement item in xtextElementList_)
			{
				if (method_50(item, gclass103_0.method_5()))
				{
					bool bool_ = xtextElementList_.LastElement == item;
					XTextElementList xTextElementList = item.Cells;
					if (gclass103_0.vmethod_0())
					{
						xTextElementList = new XTextElementList();
						foreach (XTextTableCellElement item2 in xtextElementList_2)
						{
							if (item2.OwnerRow == item)
							{
								xTextElementList.Add(item2);
							}
						}
					}
					gclass103_0.method_10().method_16(Environment.NewLine);
					num3++;
					if (num2 > 1)
					{
						for (int i = 0; i < xTextElementList.Count; i++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList[i];
							if (!(xTextTableCellElement.ID == "aaaaaaaaaaaa"))
							{
							}
							if (xTextTableCellElement.RuntimeVisible)
							{
								gclass103_0.method_28("intbl");
								gclass103_0.method_28("itap" + num2);
								xTextTableCellElement.vmethod_19(gclass103_0);
								gclass103_0.method_28("nestcell");
							}
							else if (xTextTableCellElement.OverrideCell.OwnerRow != xTextTableCellElement.OwnerRow)
							{
								gclass103_0.method_28("nestcell");
								i = i + xTextTableCellElement.OverrideCell.ColSpan - 1;
							}
						}
						gclass103_0.method_10().method_12();
						gclass103_0.method_28("nesttableprops");
						gclass103_0.method_28("trowd");
						method_52(item, gclass103_0, xTextElementList, bool_);
						gclass103_0.method_28("nestrow");
						gclass103_0.method_10().method_13();
					}
					else
					{
						gclass103_0.method_28("trowd");
						method_52(item, gclass103_0, xTextElementList, bool_);
						for (int i = 0; i < xTextElementList.Count; i++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList[i];
							if (xTextTableCellElement.RuntimeVisible)
							{
								gclass103_0.method_28("intbl");
								xTextTableCellElement.vmethod_19(gclass103_0);
								gclass103_0.method_28("cell");
							}
							else if (xTextTableCellElement.OverrideCell.OwnerRow != xTextTableCellElement.OwnerRow)
							{
								gclass103_0.method_28("cell");
								i = i + xTextTableCellElement.OverrideCell.ColSpan - 1;
							}
						}
						gclass103_0.method_28("row");
					}
				}
			}
			gclass103_0.method_10().method_13();
			gclass103_0.method_28("pard");
			gclass103_0.method_19(this);
		}

		private void method_52(XTextTableRowElement xtextTableRowElement_0, GClass103 gclass103_0, XTextElementList xtextElementList_4, bool bool_26)
		{
			int num = 15;
			gclass103_0.method_10().method_14("trgaph108");
			if (xtextTableRowElement_0.RuntimeSpecifyHeight != 0f)
			{
				gclass103_0.method_10().method_14("trrh" + gclass103_0.method_20((int)((double)xtextTableRowElement_0.RuntimeSpecifyHeight - 12.5)));
			}
			float num2 = 0f;
			foreach (XTextTableCellElement item in xtextElementList_4)
			{
				num2 += item.Width;
			}
			float num3 = 0f;
			XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xtextElementList_4[0];
			for (int i = 0; i < xTextTableCellElement2.ColIndex; i++)
			{
				num3 += Columns[i].Width;
			}
			gclass103_0.method_10().method_14("trwWidth" + gclass103_0.method_20(num2));
			if (xtextTableRowElement_0.RuntimeHeaderStyle)
			{
				gclass103_0.method_28("trhdr");
			}
			if (bool_26)
			{
				gclass103_0.method_28("lastrow");
			}
			float num4 = 0f;
			for (int i = 0; i < xtextElementList_4.Count; i++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xtextElementList_4[i];
				gclass103_0.method_10().method_0().method_12(Environment.NewLine);
				if (xTextTableCellElement.RuntimeVisible)
				{
					if (xTextTableCellElement.RowSpan > 1)
					{
						gclass103_0.method_28("clvmgf");
					}
					method_53(xTextTableCellElement, gclass103_0);
					if (xTextTableCellElement.RuntimeVisible)
					{
						RuntimeDocumentContentStyle runtimeStyle = xTextTableCellElement.RuntimeStyle;
						if (runtimeStyle.VerticalAlign == VerticalAlignStyle.Top)
						{
							gclass103_0.method_10().method_14("clvertalt");
						}
						else if (runtimeStyle.VerticalAlign == VerticalAlignStyle.Middle)
						{
							gclass103_0.method_10().method_14("clvertalc");
						}
						else if (runtimeStyle.VerticalAlign == VerticalAlignStyle.Bottom)
						{
							gclass103_0.method_10().method_14("clvertalb");
						}
						int num5 = gclass103_0.method_10().method_8().method_6(runtimeStyle.BackgroundColor);
						if (num5 >= 0)
						{
							gclass103_0.method_28("clcbpat" + Convert.ToString(num5 + 1));
						}
						gclass103_0.method_28("clpadt" + gclass103_0.method_20(runtimeStyle.PaddingLeft));
						gclass103_0.method_28("clpadft3");
						gclass103_0.method_28("clpadl" + gclass103_0.method_20(runtimeStyle.PaddingTop));
						gclass103_0.method_28("clpadfl3");
						gclass103_0.method_28("clpadr" + gclass103_0.method_20(runtimeStyle.PaddingRight));
						gclass103_0.method_28("clpadfr3");
						gclass103_0.method_28("clpadb" + gclass103_0.method_20(runtimeStyle.PaddingBottom));
						gclass103_0.method_28("clpadfb3");
					}
					num4 += xTextTableCellElement.Width;
					gclass103_0.method_10().method_14("cellx" + gclass103_0.method_20(xTextTableCellElement.Left - num3 + xTextTableCellElement.Width));
					gclass103_0.method_28("clwWidth" + gclass103_0.method_20(xTextTableCellElement.Width));
				}
				else if (xTextTableCellElement.OverrideCell.OwnerRow != xTextTableCellElement.OwnerRow)
				{
					gclass103_0.method_28("clvmrg");
					method_53(xTextTableCellElement, gclass103_0);
					gclass103_0.method_28("cellx" + gclass103_0.method_20(xTextTableCellElement.Left - num3 + xTextTableCellElement.OverrideCell.Width));
					i = i + xTextTableCellElement.OverrideCell.ColSpan - 1;
				}
			}
		}

		private void method_53(XTextTableCellElement xtextTableCellElement_0, GClass103 gclass103_0)
		{
			int num = 6;
			RuntimeDocumentContentStyle runtimeStyle = xtextTableCellElement_0.RuntimeStyle;
			if (!(runtimeStyle.BorderWidth > 0f))
			{
				return;
			}
			int num2 = gclass103_0.method_20(runtimeStyle.BorderWidth);
			if (num2 < 1)
			{
				num2 = 1;
			}
			if (num2 > 75)
			{
				num2 = 75;
			}
			if (runtimeStyle.BorderLeft && runtimeStyle.BorderTopColor.A != 0)
			{
				gclass103_0.method_28("clbrdrl");
				if (num2 != 1)
				{
					gclass103_0.method_28("brdrw" + num2);
				}
				gclass103_0.method_28("brdrcf" + gclass103_0.method_10().method_8().method_7(runtimeStyle.BorderLeftColor));
				gclass103_0.method_10().method_17(runtimeStyle.BorderStyle);
			}
			if (runtimeStyle.BorderTop && runtimeStyle.BorderTopColor.A != 0)
			{
				gclass103_0.method_28("clbrdrt");
				if (num2 != 1)
				{
					gclass103_0.method_28("brdrw" + num2);
				}
				gclass103_0.method_28("brdrcf" + gclass103_0.method_10().method_8().method_7(runtimeStyle.BorderTopColor));
				gclass103_0.method_10().method_17(runtimeStyle.BorderStyle);
			}
			if (runtimeStyle.BorderRight && runtimeStyle.BorderRightColor.A != 0)
			{
				gclass103_0.method_28("clbrdrr");
				if (num2 != 1)
				{
					gclass103_0.method_28("brdrw" + num2);
				}
				gclass103_0.method_28("brdrcf" + gclass103_0.method_10().method_8().method_7(runtimeStyle.BorderRightColor));
				gclass103_0.method_10().method_17(runtimeStyle.BorderStyle);
			}
			if (runtimeStyle.BorderBottom && runtimeStyle.BorderBottomColor.A != 0)
			{
				gclass103_0.method_28("clbrdrb");
				if (num2 != 1)
				{
					gclass103_0.method_28("brdrw" + num2);
				}
				gclass103_0.method_28("brdrcf" + gclass103_0.method_10().method_8().method_7(runtimeStyle.BorderBottomColor));
				gclass103_0.method_10().method_17(runtimeStyle.BorderStyle);
			}
		}

		public override void vmethod_17(ReadHTMLEventArgs readHTMLEventArgs_0)
		{
			int num = 7;
			new List<float>();
			GClass222 currentStyle = readHTMLEventArgs_0.CurrentStyle;
			DocumentContentStyle documentContentStyle = readHTMLEventArgs_0.CreateContentStyle(currentStyle, this, readHTMLEventArgs_0.HtmlElement);
			documentContentStyle.BorderColor = Color.Black;
			documentContentStyle.BorderLeft = true;
			documentContentStyle.BorderTop = true;
			documentContentStyle.BorderRight = true;
			documentContentStyle.BorderBottom = true;
			if (readHTMLEventArgs_0.HtmlElement.method_13("border"))
			{
				documentContentStyle.BorderWidth = readHTMLEventArgs_0.ToInt32(readHTMLEventArgs_0.HtmlElement.method_9("border"));
			}
			else
			{
				documentContentStyle.BorderWidth = 0f;
			}
			if (readHTMLEventArgs_0.HtmlElement.method_13("bgcolor"))
			{
				documentContentStyle.BackgroundColor = readHTMLEventArgs_0.ToColor(readHTMLEventArgs_0.HtmlElement.method_9("bgcolor"), Color.Transparent);
			}
			if (readHTMLEventArgs_0.HtmlElement.method_13("bordercolor"))
			{
				documentContentStyle.BorderColor = readHTMLEventArgs_0.ToColor(readHTMLEventArgs_0.HtmlElement.method_9("bordercolor"), Color.Black);
			}
			CompressOwnerLineSpacing = true;
			base.ID = readHTMLEventArgs_0.HtmlElement.method_37();
			readHTMLEventArgs_0.ReadDCCustomAttributes(readHTMLEventArgs_0.HtmlElement, this);
			GClass185 gClass = (GClass185)readHTMLEventArgs_0.HtmlElement;
			if (gClass.method_73() != null && gClass.method_73().Count > 0)
			{
				foreach (GClass163 item in gClass.method_73())
				{
					XTextTableColumnElement xTextTableColumnElement = CreateColumnInstance();
					DocumentContentStyle documentContentStyle2 = readHTMLEventArgs_0.CreateContentStyle(item.method_0(), xTextTableColumnElement, item);
					if (documentContentStyle2.float_1 > 0f)
					{
						xTextTableColumnElement.Width = documentContentStyle2.float_1;
					}
					else if (!item.method_0().method_4("width"))
					{
						if (item.method_13("width"))
						{
							xTextTableColumnElement.Width = readHTMLEventArgs_0.ToLength(item.method_9("width"));
						}
						else
						{
							xTextTableColumnElement.Width = 50f;
						}
					}
					Columns.Add(xTextTableColumnElement);
					readHTMLEventArgs_0.ReadDCCustomAttributes(item, xTextTableColumnElement);
				}
			}
			GClass163 gClass3 = readHTMLEventArgs_0.HtmlElement;
			foreach (GClass163 item2 in readHTMLEventArgs_0.HtmlElement.vmethod_2())
			{
				if (item2.method_43() == "tbody")
				{
					gClass3 = item2;
					break;
				}
			}
			foreach (GClass163 item3 in gClass3.vmethod_2())
			{
				if (item3.method_43() == "tr")
				{
					XTextTableRowElement xTextTableRowElement = CreateRowInstance();
					xTextTableRowElement.OwnerDocument = OwnerDocument;
					xTextTableRowElement.Parent = this;
					Rows.Add(xTextTableRowElement);
					readHTMLEventArgs_0.ReadDCCustomAttributes(item3, xTextTableRowElement);
					GClass222 gClass6 = item3.method_0();
					gClass6.method_8(readHTMLEventArgs_0.CurrentStyle, bool_0: false, GClass222.string_0);
					DocumentContentStyle documentContentStyle3 = readHTMLEventArgs_0.CreateContentStyle(gClass6, xTextTableRowElement, item3);
					if (item3.method_13("bgcolor"))
					{
						documentContentStyle3.BackgroundColor = readHTMLEventArgs_0.ToColor(item3.method_9("bgcolor"), Color.Transparent);
					}
					foreach (GClass163 item4 in item3.vmethod_2())
					{
						if (item4.TagName.ToLower() == "td")
						{
							GClass222 gClass8 = item4.method_0();
							gClass8.method_8(gClass6, bool_0: false, GClass222.string_0);
							XTextTableCellElement xTextTableCellElement = CreateCellInstance();
							DocumentContentStyle documentContentStyle4 = readHTMLEventArgs_0.CreateContentStyle(gClass8, xTextTableCellElement, item4);
							xTextTableCellElement.OwnerDocument = OwnerDocument;
							xTextTableCellElement.Parent = xTextTableRowElement;
							readHTMLEventArgs_0.ReadDCCustomAttributes(item4, xTextTableCellElement);
							if (documentContentStyle4.float_1 >= 0f)
							{
								xTextTableCellElement.Width = documentContentStyle4.float_1;
							}
							if (documentContentStyle4.float_2 >= 0f)
							{
								xTextTableCellElement.Height = documentContentStyle4.float_2;
							}
							xTextTableCellElement.StyleIndex = OwnerDocument.ContentStyles.GetStyleIndex(documentContentStyle4);
							if (item4.method_13("rowspan"))
							{
								xTextTableCellElement.method_61(readHTMLEventArgs_0.ToInt32(item4.method_9("rowspan")));
							}
							if (item4.method_13("colspan"))
							{
								xTextTableCellElement.method_60(readHTMLEventArgs_0.ToInt32(item4.method_9("colspan")));
							}
							if (item4.method_13("valign"))
							{
								string text = item4.method_9("valign");
								if (text != null)
								{
									switch (text.Trim().ToLower())
									{
									case "middle":
										documentContentStyle4.VerticalAlign = VerticalAlignStyle.Middle;
										break;
									case "top":
										documentContentStyle4.VerticalAlign = VerticalAlignStyle.Top;
										break;
									case "bottom":
										documentContentStyle4.VerticalAlign = VerticalAlignStyle.Bottom;
										break;
									}
								}
							}
							xTextTableRowElement.Cells.Add(xTextTableCellElement);
							DocumentContentStyle xdependencyObject_ = (DocumentContentStyle)documentContentStyle4.Clone();
							XDependencyObject.smethod_8(xdependencyObject_, "BorderLeft");
							XDependencyObject.smethod_8(xdependencyObject_, "BorderTop");
							XDependencyObject.smethod_8(xdependencyObject_, "BorderRight");
							XDependencyObject.smethod_8(xdependencyObject_, "BorderBottom");
							XDependencyObject.smethod_8(xdependencyObject_, "BorderColor");
							XDependencyObject.smethod_8(xdependencyObject_, "BorderStyle");
							XDependencyObject.smethod_8(xdependencyObject_, "BorderWidth");
							GClass222 gClass9 = new GClass222();
							gClass9.method_8(gClass8, bool_0: false, GClass222.string_0);
							xTextTableCellElement.vmethod_17(new ReadHTMLEventArgs(readHTMLEventArgs_0, item4, OwnerDocument, gClass9));
						}
					}
				}
			}
			int num2 = 0;
			foreach (XTextTableRowElement row in Rows)
			{
				int num3 = 0;
				foreach (XTextTableCellElement cell in row.Cells)
				{
					num3 += cell.ColSpan;
				}
				num2 = Math.Max(num2, num3);
			}
			XTextTableCellElement xTextTableCellElement2 = new XTextTableCellElement();
			XTextTableCellElement[,] array = new XTextTableCellElement[Rows.Count, num2];
			for (int i = 0; i < Rows.Count; i++)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[i];
				foreach (XTextTableCellElement cell2 in xTextTableRowElement.Cells)
				{
					int num4 = 0;
					for (int j = 0; j < num2; j++)
					{
						if (array[i, j] == null)
						{
							num4 = j;
							break;
						}
					}
					if (cell2.RowSpan == 1 && cell2.ColSpan == 1)
					{
						array[i, num4] = cell2;
					}
					else
					{
						for (int k = 0; k < cell2.ColSpan; k++)
						{
							for (int l = 0; l < cell2.RowSpan; l++)
							{
								if (k == 0 && l == 0)
								{
									array[i + l, num4 + k] = cell2;
								}
								else
								{
									if (i + l >= Rows.Count)
									{
										break;
									}
									if (array[i + l, num4 + k] == null)
									{
										array[i + l, num4 + k] = xTextTableCellElement2;
									}
								}
							}
						}
					}
				}
			}
			for (int i = 0; i < Rows.Count; i++)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)Rows[i];
				xTextTableRowElement.Cells.Clear();
				int styleIndex = -1;
				for (int num4 = 0; num4 < num2; num4++)
				{
					if (array[i, num4] == null || array[i, num4] == xTextTableCellElement2)
					{
						XTextTableCellElement xTextTableCellElement3 = CreateCellInstance();
						xTextTableCellElement3.StyleIndex = styleIndex;
						xTextTableRowElement.Cells.Add(xTextTableCellElement3);
					}
					else
					{
						styleIndex = array[i, num4].StyleIndex;
						xTextTableRowElement.Cells.Add(array[i, num4]);
					}
				}
			}
			float width = 50f;
			if (Columns.Count == 0)
			{
				width = (OwnerDocument.Body.ClientWidth - 10f) / (float)num2;
			}
			for (int j = Columns.Count; j < num2; j++)
			{
				XTextTableColumnElement xTextTableColumnElement = CreateColumnInstance();
				xTextTableColumnElement.Width = width;
				Columns.Add(xTextTableColumnElement);
			}
			for (int j = 0; j < Columns.Count; j++)
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)Columns[j];
				if (xTextTableColumnElement.Width <= 5f)
				{
					foreach (XTextTableRowElement row2 in Rows)
					{
						if (row2.Cells.Count > j)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)row2.Cells[j];
							if (xTextTableCellElement.ColSpan == 1 && xTextTableColumnElement.Width < xTextTableCellElement.Width)
							{
								xTextTableColumnElement.Width = xTextTableCellElement.Width;
							}
						}
					}
				}
				xTextTableColumnElement.Width = Math.Max(xTextTableColumnElement.Width, 5f);
			}
			foreach (XTextTableCellElement cell3 in Cells)
			{
				cell3.Width = 0f;
				cell3.Height = 0f;
			}
		}

		public override void OnViewGotFocus(ElementEventArgs elementEventArgs_0)
		{
			InvalidateView();
			base.OnViewGotFocus(elementEventArgs_0);
		}

		public override void OnViewLostFocus(ElementEventArgs elementEventArgs_0)
		{
			InvalidateView();
			base.OnViewLostFocus(elementEventArgs_0);
		}

		public override GClass3 vmethod_2()
		{
			XTextElement xTextElement = OwnerDocument.CurrentElement;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElement is XTextTableElement)
					{
						if (xTextElement != this)
						{
							break;
						}
						if (OwnerDocument.DocumentControler.CanModify(this))
						{
							return new Class14(this);
						}
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				XTextSelection selection = OwnerDocument.Selection;
				if (selection.Mode == ContentRangeMode.Cell)
				{
					bool flag = true;
					foreach (XTextTableCellElement cell in selection.Cells)
					{
						if (cell.OwnerTable != this)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return new Class14(this);
					}
				}
				return null;
			}
			return null;
		}

		public override void Dispose()
		{
			base.Dispose();
			if (xtextElementList_3 != null)
			{
				foreach (XTextTableColumnElement item in xtextElementList_3)
				{
					item.Dispose();
				}
				xtextElementList_3.Clear();
				xtextElementList_3 = null;
			}
			if (xtextElementList_2 != null)
			{
				xtextElementList_2.Clear();
				xtextElementList_2 = null;
			}
		}
	}
}
