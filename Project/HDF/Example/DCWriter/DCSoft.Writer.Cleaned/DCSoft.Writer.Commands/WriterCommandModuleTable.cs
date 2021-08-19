#define DEBUG
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       操作表格的命令功能模块对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[WriterCommandDescription("Table")]
	internal class WriterCommandModuleTable : WriterCommandModule
	{
		/// <summary>
		///       将文档表格元素转换为数据表对象
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_ConvertTableElementToDataTable")]
		public void Table_ConvertTableElementToDataTable(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XTextTableElement xTextTableElement = e.Parameter as XTextTableElement;
				if (xTextTableElement == null)
				{
					xTextTableElement = GetCurrentTable(e.Document);
				}
				if (xTextTableElement != null && e.ShowUI)
				{
					using (dlgConvertTableElementToDataTable dlgConvertTableElementToDataTable = new dlgConvertTableElementToDataTable())
					{
						dlgConvertTableElementToDataTable.InputTableElement = xTextTableElement;
						WriterControl.UIShowDialog(e.EditorControl, dlgConvertTableElementToDataTable, null);
					}
				}
			}
		}

		/// <summary>
		///       重置表格样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_ResetTableStyle")]
		public void Table_ResetTableStyle(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextTableElement handledTable = GetHandledTable(e, useLastTable: false);
				if (handledTable != null)
				{
					DocumentContentStyle documentContentStyle = new DocumentContentStyle();
					documentContentStyle.BorderColor = Color.Black;
					documentContentStyle.BorderStyle = DashStyle.Solid;
					documentContentStyle.BorderWidth = 1f;
					documentContentStyle.BorderLeft = true;
					documentContentStyle.BorderTop = true;
					documentContentStyle.BorderRight = true;
					documentContentStyle.BorderBottom = true;
					int styleIndex = e.Document.ContentStyles.GetStyleIndex(documentContentStyle);
					handledTable.StyleIndex = -1;
					foreach (XTextTableCellElement cell in handledTable.Cells)
					{
						cell.EditorSetStyleDeeply(e.Document.DefaultStyle);
						cell.StyleIndex = styleIndex;
					}
					if (handledTable.Columns.Count > 0)
					{
						XTextContentElement contentElement = handledTable.ContentElement;
						float val = (contentElement.ClientWidth - 3f) / (float)handledTable.Columns.Count;
						val = Math.Max(50f, val);
						foreach (XTextTableColumnElement column in handledTable.Columns)
						{
							column.Width = val;
						}
					}
					foreach (XTextTableRowElement row in handledTable.Rows)
					{
						row.SpecifyHeight = 0f;
					}
					e.Document.UndoList.Clear();
					handledTable.EditorRefreshView();
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Document.Modified = true;
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
				}
			}
		}

		/// <summary>
		///       删除最后一页中的空白表格行
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_RemoveEmptyRowsInLastPage")]
		protected void Table_RemoveEmptyRowsInLastPage(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.Document != null)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)e.Document.Body.GetLastElementByType(typeof(XTextTableElement));
				if (xTextTableElement != null)
				{
					float num = e.Document.Pages.LastPage.Top - xTextTableElement.AbsTop;
					foreach (XTextTableRowElement row in xTextTableElement.Rows)
					{
						if (row.Top > num - 1f)
						{
							int num2 = xTextTableElement.Rows.IndexOf(row);
							xTextTableElement.Rows.RemoveRange(num2, xTextTableElement.Rows.Count - num2);
							e.Document.Modified = true;
							xTextTableElement.EditorRefreshView();
							e.Document.UndoList.Clear();
							e.RefreshLevel = UIStateRefreshLevel.All;
							e.Result = xTextTableElement;
							break;
						}
					}
				}
			}
		}

		/// <summary>
		///       插入表格
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("Table_InsertTable", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertTable.bmp", FunctionID = GEnum6.const_88)]
		protected void Table_InsertTable(object sender, WriterCommandEventArgs e)
		{
			int num = 18;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.DocumentControler != null)
				{
					e.Enabled = e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextTableElement));
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextTableElement xTextTableElement = null;
				if (e.Parameter is XTextTableElement)
				{
					xTextTableElement = (XTextTableElement)e.Parameter;
				}
				else
				{
					XTextTableElementProperties xTextTableElementProperties = e.Parameter as XTextTableElementProperties;
					if (xTextTableElementProperties == null)
					{
						xTextTableElementProperties = new XTextTableElementProperties();
					}
					if ((e.ShowUI && !xTextTableElementProperties.PromptNewElement(e)) || xTextTableElementProperties.ColumnsCount <= 0 || xTextTableElementProperties.RowsCount <= 0)
					{
						return;
					}
					if (xTextTableElementProperties.ColumnWidth == 0f && e.Document.CurrentElement != null)
					{
						XTextContentElement contentElement = e.Document.CurrentElement.ContentElement;
						xTextTableElementProperties.ColumnWidth = (contentElement.ClientWidth - e.Document.PixelToDocumentUnit(2f)) / (float)xTextTableElementProperties.ColumnsCount;
					}
					xTextTableElement = (XTextTableElement)xTextTableElementProperties.CreateElement(e.Document);
				}
				if (xTextTableElement != null)
				{
					xTextTableElement.vmethod_0(bool_17: true);
					e.Document.AllocElementID("table", xTextTableElement);
					foreach (XTextTableRowElement row in xTextTableElement.Rows)
					{
						foreach (XTextTableCellElement cell in row.Cells)
						{
							cell.FixElements();
						}
					}
					xTextTableElement.OwnerDocument = e.Document;
					xTextTableElement.FixDomState();
					xTextTableElement.SizeInvalid = true;
					e.DocumentControler.vmethod_6(new XTextElementList(xTextTableElement));
					e.Document.ValidateElementIDRepeat(xTextTableElement);
					e.Document.BeginLogUndo();
					e.Document.InsertElement(xTextTableElement);
					e.Document.EndLogUndo();
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = xTextTableElement;
				}
			}
		}

		/// <summary>
		///       删除整个表格
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("Table_DeleteTable", FunctionID = GEnum6.const_90)]
		protected void Table_DeleteTable(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Parameter is XTextTableElement)
				{
					e.Enabled = e.DocumentControler.method_18((XTextTableElement)e.Parameter);
					return;
				}
				XTextTableCellElement currentCell = GetCurrentCell(e.Document);
				if (currentCell != null)
				{
					e.Enabled = e.DocumentControler.method_18(currentCell);
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = null;
				if (!e.UIStartEditContent())
				{
					return;
				}
				XTextTableElement xTextTableElement = null;
				if (e.Parameter is XTextTableElement)
				{
					xTextTableElement = (XTextTableElement)e.Parameter;
				}
				else
				{
					XTextTableCellElement currentCell = GetCurrentCell(e.Document);
					xTextTableElement = currentCell.OwnerTable;
				}
				GClass108 gClass = new GClass108();
				xTextTableElement.vmethod_27(gClass, 100);
				if (gClass != null && gClass.Count > 0)
				{
					if (e.ShowUI)
					{
						e.Document.method_91(gClass);
					}
				}
				else if (xTextTableElement.EditorDelete(logUndo: true))
				{
					e.Result = xTextTableElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       合并单元格
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("Table_MergeCell", ImageResource = "DCSoft.Writer.Commands.Images.CommandMergeCell.bmp", ReturnValueType = typeof(XTextTableCellElement), FunctionID = GEnum6.const_89)]
		protected void Table_MegeCell(object sender, WriterCommandEventArgs e)
		{
			MegeCellCommandParameter megeCellCommandParameter = null;
			if (e.Mode != WriterCommandEventMode.QueryState && e.Mode != WriterCommandEventMode.Invoke)
			{
				return;
			}
			if (e.EditorControl == null)
			{
				e.Enabled = false;
				return;
			}
			megeCellCommandParameter = (e.Parameter as MegeCellCommandParameter);
			if (megeCellCommandParameter == null)
			{
				XTextDocumentContentElement currentContentElement = e.Document.CurrentContentElement;
				if (currentContentElement.Selection.Mode == ContentRangeMode.Cell)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)currentContentElement.Selection.Cells.FirstElement;
					XTextTableElement ownerTable = xTextTableCellElement.OwnerTable;
					if (xTextTableCellElement.RowIndex < ownerTable.Rows.Count - 1 || xTextTableCellElement.ColIndex < ownerTable.Columns.Count - 1)
					{
						e.Enabled = e.DocumentControler.CanModify(xTextTableCellElement);
						if (e.Enabled && e.Mode == WriterCommandEventMode.Invoke)
						{
							XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)currentContentElement.Selection.Cells.FirstElement;
							XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)currentContentElement.Selection.Cells.LastElement;
							megeCellCommandParameter = new MegeCellCommandParameter();
							megeCellCommandParameter.Cell = xTextTableCellElement2;
							megeCellCommandParameter.NewRowSpan = xTextTableCellElement3.RowIndex + xTextTableCellElement3.RowSpan - xTextTableCellElement2.RowIndex;
							megeCellCommandParameter.NewColSpan = xTextTableCellElement3.ColIndex + xTextTableCellElement3.ColSpan - xTextTableCellElement2.ColIndex;
						}
					}
				}
				else
				{
					e.Enabled = false;
				}
			}
			else
			{
				if (megeCellCommandParameter.Cell == null && !string.IsNullOrEmpty(megeCellCommandParameter.CellID))
				{
					megeCellCommandParameter.Cell = (e.Document.GetElementById(megeCellCommandParameter.CellID) as XTextTableCellElement);
				}
				if (megeCellCommandParameter.Cell != null && !megeCellCommandParameter.Cell.IsOverrided && e.DocumentControler.CanModify(megeCellCommandParameter.Cell) && megeCellCommandParameter.NewRowSpan >= megeCellCommandParameter.Cell.RowSpan && megeCellCommandParameter.NewColSpan >= megeCellCommandParameter.Cell.ColSpan)
				{
					e.Enabled = true;
				}
			}
			if (e.Mode == WriterCommandEventMode.Invoke && e.Enabled && e.UIStartEditContent())
			{
				megeCellCommandParameter.Cell.method_70(megeCellCommandParameter.NewRowSpan, megeCellCommandParameter.NewColSpan, bool_26: true, null);
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Result = megeCellCommandParameter.Cell;
			}
		}

		/// <summary>
		///       增强型的拆分单元格
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("Table_SplitCellExt", ImageResource = "DCSoft.Writer.Commands.Images.CommandSplitCell.bmp", ReturnValueType = typeof(XTextTableCellElement))]
		protected void Table_SplitCellExt(object sender, WriterCommandEventArgs e)
		{
			int num = 7;
			SplitCellExtCommandParameter splitCellExtCommandParameter = null;
			if (e.Mode == WriterCommandEventMode.QueryState || e.Mode == WriterCommandEventMode.Invoke)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				if (e.Parameter is SplitCellExtCommandParameter)
				{
					splitCellExtCommandParameter = (SplitCellExtCommandParameter)e.Parameter;
					if (splitCellExtCommandParameter.CellElement == null)
					{
						splitCellExtCommandParameter.CellElement = (e.Document.GetElementById(splitCellExtCommandParameter.CellID) as XTextTableCellElement);
					}
				}
				else
				{
					splitCellExtCommandParameter = new SplitCellExtCommandParameter();
					if (e.Document.Selection.Cells != null && e.Document.Selection.Cells.Count > 1)
					{
						splitCellExtCommandParameter.CellElement = null;
					}
					else
					{
						splitCellExtCommandParameter.CellElement = GetCurrentCell(e.Document);
					}
				}
				if (splitCellExtCommandParameter.CellElement != null && !e.DocumentControler.CanModify(splitCellExtCommandParameter.CellElement))
				{
					splitCellExtCommandParameter.CellElement = null;
				}
			}
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (splitCellExtCommandParameter != null && splitCellExtCommandParameter.CellElement != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = null;
				if (splitCellExtCommandParameter == null || splitCellExtCommandParameter.CellElement == null)
				{
					return;
				}
				if (e.Parameter is string)
				{
					string text = (string)e.Parameter;
					int num2 = text.IndexOf(",");
					if (num2 >= 0)
					{
						try
						{
							splitCellExtCommandParameter.NewRowSpan = int.Parse(text.Substring(0, num2));
							splitCellExtCommandParameter.NewColSpan = int.Parse(text.Substring(num2 + 1));
						}
						catch (Exception ex)
						{
							Debug.WriteLine("Table_SplitCellExt:" + ex.Message);
							splitCellExtCommandParameter.NewRowSpan = splitCellExtCommandParameter.CellElement.RowSpan;
							splitCellExtCommandParameter.NewColSpan = splitCellExtCommandParameter.CellElement.ColSpan;
						}
					}
				}
				if (splitCellExtCommandParameter.NewRowSpan < 1)
				{
					splitCellExtCommandParameter.NewRowSpan = splitCellExtCommandParameter.CellElement.RowSpan;
				}
				if (splitCellExtCommandParameter.NewColSpan < 1)
				{
					splitCellExtCommandParameter.NewColSpan = splitCellExtCommandParameter.CellElement.ColSpan;
				}
				if (e.ShowUI)
				{
					using (dlgSplitCell dlgSplitCell = new dlgSplitCell())
					{
						dlgSplitCell.InputRowsNum = splitCellExtCommandParameter.NewRowSpan;
						dlgSplitCell.InputColsNum = splitCellExtCommandParameter.NewColSpan;
						dlgSplitCell.OldRowSpan = splitCellExtCommandParameter.CellElement.RowSpan;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgSplitCell, splitCellExtCommandParameter.CellElement) != DialogResult.OK)
						{
							return;
						}
						splitCellExtCommandParameter.NewRowSpan = dlgSplitCell.InputRowsNum;
						splitCellExtCommandParameter.NewColSpan = dlgSplitCell.InputColsNum;
					}
				}
				if (e.UIStartEditContent() && splitCellExtCommandParameter.CellElement.EditorSplitCellExt(splitCellExtCommandParameter.NewRowSpan, splitCellExtCommandParameter.NewColSpan, logUndo: true))
				{
					e.Result = splitCellExtCommandParameter.CellElement;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       拆分单元格
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("Table_SplitCell", ImageResource = "DCSoft.Writer.Commands.Images.CommandSplitCell.bmp", ReturnValueType = typeof(XTextTableCellElement))]
		protected void Table_SplitCell(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = false;
				if (e.Document == null)
				{
					return;
				}
				if (e.Document.Selection.Cells != null && e.Document.Selection.Cells.Count > 1)
				{
					e.Enabled = false;
					return;
				}
				XTextTableCellElement currentCell = GetCurrentCell(e.Document);
				if (currentCell != null && (currentCell.RowSpan > 1 || currentCell.ColSpan > 1))
				{
					e.Enabled = e.DocumentControler.CanModify(currentCell);
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = null;
				e.RefreshLevel = UIStateRefreshLevel.None;
				XTextTableCellElement currentCell = GetCurrentCell(e.Document);
				if (currentCell != null && (currentCell.RowSpan > 1 || currentCell.ColSpan > 1) && e.UIStartEditContent() && currentCell.method_70(1, 1, bool_26: true, null))
				{
					e.Result = currentCell;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       在当前行上面插入表格行
		///       </summary>
		/// <param name="sender">事件参数</param>
		/// <param name="args">事件参数</param>
		[WriterCommandDescription("Table_InsertRowUp", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertRowUp.bmp", ReturnValueType = typeof(XTextTableRowElement), FunctionID = GEnum6.const_91)]
		protected void Table_InsertRowUp(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = InsertRows(e, insertUp: true, detect: true);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InsertRows(e, insertUp: true, detect: false);
			}
		}

		/// <summary>
		///       根据内容行数来拆分表格行（实现护理记录单效果），本命令不受内容授权控制影响。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_SplitRowsByContentLines", FunctionID = GEnum6.const_91)]
		protected void Table_SplitRowsByContentLines(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				XTextTableElement xTextTableElement = null;
				List<XTextTableRowElement> list = new List<XTextTableRowElement>();
				if (e.Parameter is List<XTextTableRowElement>)
				{
					list = (List<XTextTableRowElement>)e.Parameter;
				}
				else if (e.Parameter is XTextTableRowElement)
				{
					list.Add((XTextTableRowElement)e.Parameter);
				}
				else if (e.Parameter is XTextTableElement)
				{
					xTextTableElement = (XTextTableElement)e.Parameter;
					foreach (XTextTableRowElement row in xTextTableElement.Rows)
					{
						if (!row.HeaderStyle)
						{
							list.Add(row);
						}
					}
				}
				else if (e.Parameter is string && !string.IsNullOrEmpty((string)e.Parameter))
				{
					xTextTableElement = (e.Document.GetElementById((string)e.Parameter) as XTextTableElement);
					if (xTextTableElement != null)
					{
						foreach (XTextTableRowElement row2 in xTextTableElement.Rows)
						{
							if (!row2.HeaderStyle)
							{
								list.Add(row2);
							}
						}
					}
				}
				else
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)e.Document.GetCurrentElement(typeof(XTextTableRowElement));
					if (xTextTableRowElement != null)
					{
						list.Add(xTextTableRowElement);
					}
				}
				if (list == null || list.Count == 0)
				{
					return;
				}
				for (int num = list.Count - 1; num >= 0; num--)
				{
					XTextTableRowElement xTextTableRowElement = list[num];
					int num2 = 0;
					foreach (XTextTableCellElement cell in xTextTableRowElement.Cells)
					{
						if (num2 == 0)
						{
							num2 = cell.RowSpan;
						}
						else if (num2 != cell.RowSpan)
						{
							list.RemoveAt(num);
							break;
						}
					}
				}
				if (list.Count != 0)
				{
					XTextTableElement xTextTableElement2 = null;
					int startRowIndexBase = -1;
					int num3 = 0;
					foreach (XTextTableRowElement item in list)
					{
						if (xTextTableElement2 == null)
						{
							xTextTableElement2 = item.OwnerTable;
							startRowIndexBase = xTextTableElement2.Rows.IndexOf(item);
							num3 = 1;
						}
						else
						{
							if (item.OwnerTable != xTextTableElement2)
							{
								break;
							}
							num3++;
						}
					}
					if (xTextTableElement2 != null && num3 >= 1)
					{
						bool flag = xTextTableElement2.SplitRowsByContentLines(startRowIndexBase, num3, updateView: true);
						e.Result = flag;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       修改表格行的高度，使其扩展到页面低端。本操作不受权限控制。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_IncreaseRowHeightToPageBottom")]
		protected void Table_IncreaseRowHeightToPageBottom(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextTableElement handledTable = GetHandledTable(e, useLastTable: true);
				if (handledTable == null || handledTable.OwnerPagePartyStyle != PageContentPartyStyle.Body)
				{
					e.Enabled = false;
					return;
				}
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)handledTable.Rows.LastElement;
				_ = xTextTableRowElement.Height;
				if (xTextTableRowElement.RuntimeSpecifyHeight != 0f)
				{
					Math.Abs(xTextTableRowElement.RuntimeSpecifyHeight);
				}
				int num = e.Document.Pages.Count - 1;
				PrintPage printPage;
				while (true)
				{
					if (num >= 0)
					{
						printPage = e.Document.Pages[num];
						float top = printPage.Top;
						if (xTextTableRowElement.AbsTop + xTextTableRowElement.Height >= top + 2f)
						{
							break;
						}
						num--;
						continue;
					}
					return;
				}
				float num2 = printPage.StandartPapeBodyHeight;
				if (printPage.HeaderRowsBounds.Height > 0f)
				{
					num2 = num2 - printPage.HeaderRowsBounds.Height - 3f;
				}
				float num3 = printPage.Top + num2 - xTextTableRowElement.AbsTop;
				foreach (XTextTableCellElement cell in xTextTableRowElement.Cells)
				{
					if (!cell.IsOverrided)
					{
						if (cell.GridLine != null && cell.GridLine.Visible && cell.GridLine.RuntimeGridSpan > 0f)
						{
							int num4 = (int)Math.Floor((num3 - cell.RuntimeStyle.PaddingTop) / cell.GridLine.RuntimeGridSpan);
							num3 = (float)num4 * cell.GridLine.RuntimeGridSpan;
							break;
						}
						float num5 = cell.method_45(printPage);
						if (cell.RuntimeStyle.GridLineColor.A != 0 && cell.RuntimeStyle.GridLineType == ContentGridLineType.ExtentToBottom && num5 > 0f)
						{
							int num4 = (int)Math.Floor((num3 - cell.RuntimeStyle.PaddingTop) / num5);
							num3 = (float)num4 * num5;
							break;
						}
					}
				}
				xTextTableRowElement.EditorSetRowSpecifyHeight(num3, logUndo: true);
				e.Document.Modified = true;
				e.Result = xTextTableRowElement;
			}
		}

		/// <summary>
		///       在一个表格后面插入新表格行，使得表格延伸到当前页面的最下面。本操作不受权限控制。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_InsertRowsToPageBottom", FunctionID = GEnum6.const_91)]
		protected void Table_InsertRowsToPageBottom(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || e.Document.CurrentContentPartyStyle != PageContentPartyStyle.Body)
				{
					return;
				}
				XTextTableElement handledTable = GetHandledTable(e, useLastTable: true);
				if (handledTable == null || handledTable.OwnerPagePartyStyle != PageContentPartyStyle.Body)
				{
					e.Enabled = false;
					return;
				}
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)handledTable.Rows.LastElement;
				_ = xTextTableRowElement.Height;
				if (xTextTableRowElement.RuntimeSpecifyHeight != 0f)
				{
					Math.Abs(xTextTableRowElement.RuntimeSpecifyHeight);
				}
				float num = 0f;
				int num2 = e.Document.Pages.Count - 1;
				PrintPage printPage;
				float top;
				while (true)
				{
					if (num2 >= 0)
					{
						printPage = e.Document.Pages[num2];
						top = printPage.Top;
						if (xTextTableRowElement.AbsTop + xTextTableRowElement.Height >= top + 2f)
						{
							break;
						}
						num2--;
						continue;
					}
					return;
				}
				float num3 = printPage.StandartPapeBodyHeight;
				if (printPage.HeaderRowsBounds.Height > 0f)
				{
					num3 -= printPage.HeaderRowsBounds.Height;
				}
				float num4 = num3 + top - (xTextTableRowElement.AbsTop + xTextTableRowElement.Height);
				XTextElementList xTextElementList = new XTextElementList();
				while ((double)num4 > (double)num * 1.1)
				{
					XTextTableRowElement xTextTableRowElement2 = xTextTableRowElement.EditorClone();
					xTextTableRowElement2.NewPage = false;
					xTextTableRowElement2.Parent = handledTable;
					xTextTableRowElement2.OwnerDocument = e.Document;
					xTextTableRowElement2.Parent = handledTable;
					WriterUtils.smethod_20(e.Document, xTextTableRowElement2.Cells, bool_2: false);
					foreach (XTextTableCellElement cell in xTextTableRowElement2.Cells)
					{
						cell.ExecuteLayout();
					}
					xTextTableRowElement2.CalcuteRowHeight();
					num = xTextTableRowElement2.Height;
					if (num4 < num - 1f)
					{
						break;
					}
					xTextElementList.Add(xTextTableRowElement2);
					num4 -= num;
				}
				if (xTextElementList.Count > 0)
				{
					handledTable.method_45(handledTable.Rows.Count, xTextElementList, bool_26: true, null, bool_27: false);
					e.Document.Modified = true;
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = xTextElementList;
				}
			}
		}

		/// <summary>
		///       获得命令操作要处理的表格对象
		///       </summary>
		/// <param name="args">命令参数</param>
		/// <param name="useLastTable">是否允许使用文档中最后一个表格</param>
		/// <returns>操作是否成功</returns>
		private XTextTableElement GetHandledTable(WriterCommandEventArgs args, bool useLastTable)
		{
			if (args.Parameter is XTextTableElement)
			{
				return (XTextTableElement)args.Parameter;
			}
			if (args.Parameter is string)
			{
				string text = (string)args.Parameter;
				if (!string.IsNullOrEmpty(text))
				{
					return args.Document.GetElementById(text) as XTextTableElement;
				}
			}
			if (args.Parameter is TableCommandArgs)
			{
				TableCommandArgs tableCommandArgs = (TableCommandArgs)args.Parameter;
				if (tableCommandArgs.TableElement != null)
				{
					return tableCommandArgs.TableElement;
				}
				if (!string.IsNullOrEmpty(tableCommandArgs.TableID))
				{
					XTextTableElement xTextTableElement = args.Document.GetElementById(tableCommandArgs.TableID) as XTextTableElement;
					if (xTextTableElement != null)
					{
						return xTextTableElement;
					}
				}
			}
			XTextTableElement xTextTableElement2 = (XTextTableElement)args.Document.GetCurrentElement(typeof(XTextTableElement));
			if (xTextTableElement2 != null)
			{
				return xTextTableElement2;
			}
			if (useLastTable)
			{
				return (XTextTableElement)args.Document.Body.GetLastElementByType(typeof(XTextTableElement));
			}
			return null;
		}

		/// <summary>
		///       在当前行上面插入表格行
		///       </summary>
		/// <param name="sender">事件参数</param>
		/// <param name="args">事件参数</param>
		[WriterCommandDescription("Table_InsertRowDown", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertRowDown.bmp", ReturnValueType = typeof(XTextTableRowElement), FunctionID = GEnum6.const_91)]
		protected void Table_InsertRowDown(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = InsertRows(e, insertUp: false, detect: true);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InsertRows(e, insertUp: false, detect: false);
			}
		}

		/// <summary>
		///       删除当前表格行
		///       </summary>
		/// <param name="sender">事件参数</param>
		/// <param name="args">事件参数</param>
		[WriterCommandDescription("Table_DeleteRow", ImageResource = "DCSoft.Writer.Commands.Images.CommandDeleteRow.bmp", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = GEnum6.const_90)]
		protected void Table_DeleteRow(object sender, WriterCommandEventArgs e)
		{
			int num = 8;
			if (e.Mode != WriterCommandEventMode.Invoke && e.Mode != WriterCommandEventMode.QueryState)
			{
				return;
			}
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
			}
			if (e.EditorControl == null)
			{
				return;
			}
			e.Result = false;
			XTextElementList xTextElementList = new XTextElementList();
			XTextTableRowElement xTextTableRowElement;
			XTextTableElement xTextTableElement2;
			if (e.Parameter is XTextTableRowElement)
			{
				xTextElementList.Add((XTextTableRowElement)e.Parameter);
			}
			else if (e.Parameter is XTextElementList)
			{
				XTextTableElement xTextTableElement = null;
				XTextElementList xTextElementList2 = (XTextElementList)e.Parameter;
				foreach (XTextElement item in xTextElementList2)
				{
					if (item is XTextTableRowElement)
					{
						xTextTableRowElement = (XTextTableRowElement)item;
						if (xTextTableElement == null)
						{
							xTextTableElement = xTextTableRowElement.OwnerTable;
						}
						else if (xTextTableRowElement.OwnerTable != xTextTableElement)
						{
							throw new ArgumentOutOfRangeException("不是同一个表格的表格行");
						}
						xTextElementList.Add(xTextTableRowElement);
					}
				}
			}
			else if (e.Parameter is TableCommandArgs)
			{
				TableCommandArgs tableCommandArgs = (TableCommandArgs)e.Parameter;
				xTextTableElement2 = tableCommandArgs.TableElement;
				if (xTextTableElement2 == null)
				{
					xTextTableElement2 = (e.Document.GetElementById(tableCommandArgs.TableID) as XTextTableElement);
				}
				if (xTextTableElement2 != null && xTextTableElement2.Rows.Count > 0)
				{
					int num2 = tableCommandArgs.RowIndex;
					if (num2 < 0)
					{
						num2 = 0;
					}
					if (num2 > xTextTableElement2.Rows.Count)
					{
						num2 = xTextTableElement2.Rows.Count - 1;
					}
					for (int i = 0; i < tableCommandArgs.RowsCount; i++)
					{
						int num3 = num2 + i;
						if (num3 >= 0 && num3 < xTextTableElement2.Rows.Count)
						{
							xTextElementList.Add(xTextTableElement2.Rows[num3]);
						}
					}
				}
				if (xTextElementList.Count == 0)
				{
					return;
				}
				foreach (XTextTableRowElement item2 in xTextElementList)
				{
					if (!e.DocumentControler.method_18(item2))
					{
						return;
					}
				}
			}
			else
			{
				xTextElementList = GetRowsOrColumns(e.Document, getTableRow: true);
			}
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			xTextTableRowElement = (XTextTableRowElement)xTextElementList[0];
			if (!e.DocumentControler.method_18(xTextTableRowElement))
			{
				if (e.Mode == WriterCommandEventMode.QueryState)
				{
					e.Enabled = false;
				}
				return;
			}
			xTextTableElement2 = xTextTableRowElement.OwnerTable;
			if (!xTextTableElement2.RuntimeAllowUserDeleteRow)
			{
				e.Enabled = false;
				return;
			}
			if (xTextElementList.Count == xTextTableElement2.Rows.Count)
			{
				Table_DeleteTable(sender, e);
				if (e.Result != null)
				{
					e.Result = true;
				}
			}
			else
			{
				GClass108 gClass = new GClass108();
				foreach (XTextTableRowElement item3 in xTextElementList)
				{
					if (item3.vmethod_27(gClass, 100))
					{
						break;
					}
				}
				if (gClass.Count > 0)
				{
					if (e.Mode == WriterCommandEventMode.QueryState)
					{
						e.Enabled = false;
					}
					else if (e.ShowUI)
					{
						e.Document.method_91(gClass);
					}
					e.Result = false;
				}
				else
				{
					if (e.Mode == WriterCommandEventMode.QueryState)
					{
						e.Enabled = true;
						return;
					}
					if (!e.UIStartEditContent())
					{
						return;
					}
					e.Result = xTextTableElement2.method_46(xTextTableRowElement.Index, xTextElementList.Count, bool_26: true, null);
				}
			}
			if (e.Parameter is TableCommandArgs)
			{
				TableCommandArgs tableCommandArgs = (TableCommandArgs)e.Parameter;
				tableCommandArgs.Result = (bool)e.Result;
			}
			if (e.Result == null)
			{
				e.Result = false;
			}
			if ((bool)e.Result)
			{
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       在左边插入表格列
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_InsertColumnLeft", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertColumnLeft.bmp", ReturnValueType = typeof(XTextTableColumnElement), FunctionID = GEnum6.const_91)]
		protected void Table_InsertColumnLeft(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				InsertCols(e, e.Document, insertLeft: true);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = InsertCols(e, e.Document, insertLeft: true);
				if (e.Result == null)
				{
					e.RefreshLevel = UIStateRefreshLevel.None;
				}
				else
				{
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       在右边插入表格列
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_InsertColumnRight", ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertColumnRight.bmp", ReturnValueType = typeof(XTextTableColumnElement), FunctionID = GEnum6.const_91)]
		protected void Table_InsertColumnRight(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				InsertCols(e, e.Document, insertLeft: false);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = InsertCols(e, e.Document, insertLeft: false);
				if (e.Result == null)
				{
					e.RefreshLevel = UIStateRefreshLevel.None;
				}
				else
				{
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       删除当前表格行
		///       </summary>
		/// <param name="sender">事件参数</param>
		/// <param name="args">事件参数</param>
		[WriterCommandDescription("Table_DeleteColumn", ImageResource = "DCSoft.Writer.Commands.Images.CommandDeleteColumn.bmp", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = GEnum6.const_90)]
		protected void Table_DeleteColumn(object sender, WriterCommandEventArgs e)
		{
			int num = 9;
			if (e.Mode != WriterCommandEventMode.Invoke && e.Mode != WriterCommandEventMode.QueryState)
			{
				return;
			}
			if (e.Mode != WriterCommandEventMode.QueryState)
			{
			}
			if (e.EditorControl == null)
			{
				return;
			}
			e.Result = false;
			XTextElementList xTextElementList = new XTextElementList();
			XTextTableColumnElement xTextTableColumnElement;
			XTextTableElement xTextTableElement2;
			if (e.Parameter is XTextTableColumnElement)
			{
				xTextElementList.Add((XTextTableColumnElement)e.Parameter);
			}
			else if (e.Parameter is XTextElementList)
			{
				XTextElementList xTextElementList2 = (XTextElementList)e.Parameter;
				XTextTableElement xTextTableElement = null;
				foreach (XTextElement item in xTextElementList2)
				{
					if (item is XTextTableColumnElement)
					{
						xTextTableColumnElement = (XTextTableColumnElement)item;
						if (xTextTableElement == null)
						{
							xTextTableElement = xTextTableColumnElement.OwnerTable;
						}
						else if (xTextTableElement != xTextTableColumnElement.OwnerTable)
						{
							throw new ArgumentOutOfRangeException("不是同表格的表格列");
						}
						xTextElementList.Add(xTextTableColumnElement);
					}
				}
			}
			else if (e.Parameter is TableCommandArgs)
			{
				TableCommandArgs tableCommandArgs = (TableCommandArgs)e.Parameter;
				xTextTableElement2 = tableCommandArgs.TableElement;
				if (xTextTableElement2 == null)
				{
					xTextTableElement2 = (e.Document.GetElementById(tableCommandArgs.TableID) as XTextTableElement);
				}
				if (xTextTableElement2 != null && xTextTableElement2.Columns.Count > 0)
				{
					int num2 = tableCommandArgs.ColIndex;
					if (num2 < 0)
					{
						num2 = 0;
					}
					if (num2 > xTextTableElement2.Columns.Count)
					{
						num2 = xTextTableElement2.Columns.Count - 1;
					}
					for (int i = 0; i < tableCommandArgs.ColsCount; i++)
					{
						int num3 = i + num2;
						if (num3 >= 0 && num3 < xTextTableElement2.Columns.Count)
						{
							xTextElementList.Add(xTextTableElement2.Columns[num3]);
						}
					}
				}
				if (xTextElementList.Count == 0)
				{
					return;
				}
				foreach (XTextTableColumnElement item2 in xTextElementList)
				{
					if (!e.DocumentControler.method_18(item2))
					{
						return;
					}
				}
			}
			else
			{
				xTextElementList = GetRowsOrColumns(e.Document, getTableRow: false);
			}
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			foreach (XTextTableColumnElement item3 in xTextElementList)
			{
				if (!e.DocumentControler.method_18(item3))
				{
					if (e.Mode == WriterCommandEventMode.QueryState)
					{
						e.Enabled = false;
					}
					return;
				}
				GClass108 gClass = new GClass108();
				bool flag = true;
				if (e.Mode == WriterCommandEventMode.QueryState && item3.OwnerTable.Rows.Count > 100)
				{
					flag = false;
				}
				if (flag)
				{
					XTextElementList cells = item3.Cells;
					foreach (XTextTableCellElement item4 in cells)
					{
						if (e.Mode == WriterCommandEventMode.QueryState)
						{
							if (item4.vmethod_27(gClass, 1))
							{
								break;
							}
						}
						else if (item4.vmethod_27(gClass, 100))
						{
							break;
						}
					}
					if (gClass.Count > 0)
					{
						if (e.Mode != WriterCommandEventMode.QueryState && e.ShowUI)
						{
							e.Document.method_91(gClass);
						}
						return;
					}
				}
			}
			xTextTableColumnElement = (XTextTableColumnElement)xTextElementList[0];
			xTextTableElement2 = xTextTableColumnElement.OwnerTable;
			if (xTextElementList.Count == xTextTableElement2.Columns.Count)
			{
				if (e.Mode == WriterCommandEventMode.QueryState)
				{
					e.Enabled = true;
					return;
				}
				e.Parameter = xTextTableElement2;
				Table_DeleteTable(sender, e);
			}
			else
			{
				GClass108 gClass = new GClass108();
				if (e.EditorControl != null && e.RaiseFromUI)
				{
					CollectProtectedElementsEventArgs collectProtectedElementsEventArgs_ = new CollectProtectedElementsEventArgs(e.EditorControl, e.Document, xTextElementList, gClass);
					e.EditorControl.vmethod_35(collectProtectedElementsEventArgs_);
				}
				if (gClass.Count > 0)
				{
					foreach (XTextTableRowElement row in xTextTableElement2.Rows)
					{
						for (int j = 0; j < xTextElementList.Count; j++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)row.Cells[xTextTableColumnElement.Index + j];
							if (xTextTableCellElement.vmethod_27(gClass, 100))
							{
								break;
							}
						}
					}
				}
				if (gClass != null && gClass.Count > 0)
				{
					if (e.Mode == WriterCommandEventMode.QueryState)
					{
						e.Enabled = false;
						return;
					}
					if (e.ShowUI)
					{
						e.Document.method_91(gClass);
					}
					e.Result = false;
				}
				else
				{
					if (e.Mode == WriterCommandEventMode.QueryState)
					{
						e.Enabled = true;
						return;
					}
					if (!e.UIStartEditContent())
					{
						return;
					}
					e.Result = xTextTableElement2.method_48(xTextTableColumnElement.Index, xTextElementList.Count, bool_26: true, null, e.Document.Options.EditOptions.KeepTableWidthWhenInsertDeleteColumn, null);
				}
			}
			if (e.Parameter is TableCommandArgs)
			{
				((TableCommandArgs)e.Parameter).Result = (bool)e.Result;
			}
			if (e.Parameter is XTextTableElement)
			{
				if (e.Result != null)
				{
					e.Result = true;
				}
				else
				{
					e.Result = false;
				}
			}
			if ((bool)e.Result)
			{
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		public static XTextElementList InnerInsertRow(XTextTableElement table, XTextTableRowElement currentRow, bool insertUp, bool autoSetRowSpan, int newRowsNum)
		{
			int num = 14;
			if (table == null)
			{
				throw new ArgumentNullException("table");
			}
			if (currentRow == null)
			{
				throw new ArgumentNullException("currentRow");
			}
			if (currentRow.OwnerTable != table)
			{
				throw new ArgumentOutOfRangeException("currentRow");
			}
			XTextElementList xTextElementList = new XTextElementList();
			XTextDocument ownerDocument = table.OwnerDocument;
			bool uIIsUpdating = ownerDocument.UIIsUpdating;
			for (int i = 0; i < newRowsNum; i++)
			{
				XTextTableRowElement xTextTableRowElement = null;
				xTextTableRowElement = currentRow;
				xTextTableRowElement = xTextTableRowElement.EditorClone();
				xTextTableRowElement.FixDomState();
				if (!uIIsUpdating)
				{
					using (DCGraphics dcgraphics_ = ownerDocument.CreateDCGraphics())
					{
						DocumentPaintEventArgs documentPaintEventArgs = ownerDocument.method_55(dcgraphics_);
						documentPaintEventArgs.Element = xTextTableRowElement;
						xTextTableRowElement.RefreshSize(documentPaintEventArgs);
					}
				}
				xTextElementList.Add(xTextTableRowElement);
			}
			if (insertUp)
			{
				table.method_45(table.Rows.IndexOf(currentRow), xTextElementList, bool_26: true, null, autoSetRowSpan);
			}
			else
			{
				table.method_45(table.Rows.IndexOf(currentRow) + 1, xTextElementList, bool_26: true, null, autoSetRowSpan);
			}
			return xTextElementList;
		}

		/// <summary>
		///       在当前单元格下面插入表格行
		///       </summary>
		/// <param name="args">参数</param>
		/// <param name="detect">是否仅仅是检测操作能否成功，而不真正的执行操作</param>
		/// <param name="insertUp">是否是在上面插入表格行</param>
		/// <returns>操作是否成功</returns>
		private bool InsertRows(WriterCommandEventArgs args, bool insertUp, bool detect)
		{
			if (args.EditorControl == null)
			{
				return false;
			}
			if (!detect && !args.UIStartEditContent())
			{
				return false;
			}
			XTextTableRowElement xTextTableRowElement = null;
			int newRowsNum = 1;
			if (args.Parameter is XTextTableRowElement)
			{
				xTextTableRowElement = (XTextTableRowElement)args.Parameter;
			}
			else if (args.Parameter is TableCommandArgs)
			{
				TableCommandArgs tableCommandArgs = (TableCommandArgs)args.Parameter;
				newRowsNum = tableCommandArgs.RowsCount;
				XTextTableElement xTextTableElement = tableCommandArgs.TableElement;
				if (xTextTableElement == null)
				{
					xTextTableElement = (args.Document.GetElementById(tableCommandArgs.TableID) as XTextTableElement);
				}
				if (xTextTableElement != null && xTextTableElement.Rows.Count > 0)
				{
					int rowIndex = tableCommandArgs.RowIndex;
					xTextTableRowElement = ((rowIndex < 0) ? ((XTextTableRowElement)xTextTableElement.Rows[0]) : ((rowIndex < xTextTableElement.Rows.Count) ? ((XTextTableRowElement)xTextTableElement.Rows[rowIndex]) : ((XTextTableRowElement)xTextTableElement.Rows.LastElement)));
				}
			}
			if (xTextTableRowElement == null)
			{
				XTextElementList rowsOrColumns = GetRowsOrColumns(args.Document, getTableRow: true);
				if (rowsOrColumns == null || rowsOrColumns.Count == 0)
				{
					return false;
				}
				xTextTableRowElement = ((!insertUp) ? ((XTextTableRowElement)rowsOrColumns.LastElement) : ((XTextTableRowElement)rowsOrColumns.FirstElement));
			}
			if (xTextTableRowElement != null)
			{
				if (!args.DocumentControler.CanInsert(xTextTableRowElement.OwnerTable, 0, typeof(XTextTableRowElement)))
				{
					return false;
				}
				if (xTextTableRowElement.HeaderStyle && insertUp)
				{
					return false;
				}
			}
			if (detect)
			{
				if (xTextTableRowElement != null)
				{
					XTextTableElement xTextTableElement = xTextTableRowElement.OwnerTable;
					return xTextTableElement.RuntimeAllowUserInsertRow;
				}
				return false;
			}
			XTextTableElement ownerTable = xTextTableRowElement.OwnerTable;
			if (!ownerTable.RuntimeAllowUserInsertRow)
			{
				return false;
			}
			args.Result = InnerInsertRow(ownerTable, xTextTableRowElement, insertUp, autoSetRowSpan: false, newRowsNum);
			if (args.Result == null)
			{
				args.RefreshLevel = UIStateRefreshLevel.None;
				return false;
			}
			if (args.Parameter is TableCommandArgs)
			{
				((TableCommandArgs)args.Parameter).Result = true;
			}
			args.RefreshLevel = UIStateRefreshLevel.All;
			return true;
		}

		/// <summary>
		///       将一行表格行的单元格的样式复制到另外一个表格行的单元格
		///       </summary>
		/// <param name="SourceRow">原始表格行</param>
		/// <param name="DescRow">目标表格行</param>
		public static void CloneCellsStyle(XTextTableRowElement SourceRow, XTextTableRowElement DescRow)
		{
			int num = 9;
			if (SourceRow == DescRow)
			{
				return;
			}
			if (SourceRow == null)
			{
				throw new ArgumentNullException("SourceRow");
			}
			if (DescRow == null)
			{
				throw new ArgumentNullException("DescRow");
			}
			if (SourceRow.OwnerTable == DescRow.OwnerTable)
			{
			}
			DescRow.StyleIndex = SourceRow.StyleIndex;
			for (int i = 0; i < SourceRow.Cells.Count; i++)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)SourceRow.Cells[i];
				if (xTextTableCellElement.IsOverrided)
				{
					XTextTableCellElement overrideCell = xTextTableCellElement.OverrideCell;
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)DescRow.Cells[i];
					CloneCellStyle(overrideCell, xTextTableCellElement2);
					if (overrideCell.ColIndex != xTextTableCellElement.ColIndex)
					{
						xTextTableCellElement2.ColSpan = 1;
					}
				}
				else
				{
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)DescRow.Cells[i];
					CloneCellStyle(xTextTableCellElement, xTextTableCellElement2);
				}
			}
		}

		/// <summary>
		///       将同一个表格中的一列单元格的样式复制到另外一列的所有的单元格。
		///       </summary>
		/// <param name="SourceCol">原始表格列</param>
		/// <param name="DescCol">目标表格列</param>
		public static void CloneCellsStyle(XTextTableColumnElement SourceCol, XTextTableColumnElement DescCol)
		{
			int num = 9;
			if (SourceCol != DescCol)
			{
				if (SourceCol == null)
				{
					throw new ArgumentNullException("SourceCol");
				}
				if (DescCol == null)
				{
					throw new ArgumentNullException("DescCol");
				}
				if (SourceCol.Parent != DescCol.Parent)
				{
					throw new ArgumentException("不属于同一个表格");
				}
				_ = DescCol.Index;
				foreach (XTextTableRowElement element in SourceCol.Parent.Elements)
				{
					XTextTableCellElement sourceCell = (XTextTableCellElement)element.Elements[SourceCol.Index];
					XTextTableCellElement descCell = (XTextTableCellElement)element.Elements[DescCol.Index];
					CloneCellStyle(sourceCell, descCell);
				}
			}
		}

		/// <summary>
		///       将一个表格单元格的样式复制到另外一个单元中
		///       </summary>
		/// <param name="SourceCell">原始单元格</param>
		/// <param name="DescCell">目标单元格</param>
		public static void CloneCellStyle(XTextTableCellElement SourceCell, XTextTableCellElement DescCell)
		{
			int num = 12;
			if (SourceCell == DescCell)
			{
				return;
			}
			if (SourceCell == null)
			{
				throw new ArgumentNullException("SourceCell");
			}
			if (DescCell == null)
			{
				throw new ArgumentNullException("DescCell");
			}
			DescCell.StyleIndex = SourceCell.StyleIndex;
			DescCell.ColSpan = SourceCell.ColSpan;
			if (SourceCell.FirstContentElement == null)
			{
				return;
			}
			XTextParagraphFlagElement ownerParagraphEOF = SourceCell.FirstContentElement.OwnerParagraphEOF;
			if (ownerParagraphEOF != null && DescCell.FirstContentElement != null)
			{
				XTextParagraphFlagElement ownerParagraphEOF2 = DescCell.FirstContentElement.OwnerParagraphEOF;
				if (ownerParagraphEOF2 != null)
				{
					ownerParagraphEOF2.StyleIndex = ownerParagraphEOF.StyleIndex;
				}
			}
		}

		/// <summary>
		///       判断能否进行删除表格行操作
		///       </summary>
		/// <param name="doc">设计文档对象</param>
		/// <returns>能否进行操作</returns>
		public static bool CanDeleteRow(XTextDocument xtextDocument_0)
		{
			XTextTableRowElement currentRow = GetCurrentRow(xtextDocument_0);
			if (currentRow == null)
			{
				return false;
			}
			if (currentRow.OwnerTable.Rows.Count == 1)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       判断能否进行插入表格列操作
		///       </summary>
		/// <param name="doc">设计文档对象</param>
		/// <returns>能否执行操作</returns>
		public static bool CanInsertCol(XTextDocument xtextDocument_0)
		{
			return GetCurrentCell(xtextDocument_0) != null;
		}

		/// <summary>
		///       在当前单元格旁边插入表格列
		///       </summary>
		private XTextElementList InsertCols(WriterCommandEventArgs args, XTextDocument xtextDocument_0, bool insertLeft)
		{
			if (args.EditorControl == null)
			{
				return null;
			}
			if (args.Mode == WriterCommandEventMode.Invoke && !args.UIStartEditContent())
			{
				return null;
			}
			XTextTableColumnElement xTextTableColumnElement = null;
			int num = 1;
			if (args.Parameter is XTextTableColumnElement)
			{
				xTextTableColumnElement = (XTextTableColumnElement)args.Parameter;
			}
			else if (args.Parameter is TableCommandArgs)
			{
				TableCommandArgs tableCommandArgs = (TableCommandArgs)args.Parameter;
				num = tableCommandArgs.ColsCount;
				XTextTableElement xTextTableElement = tableCommandArgs.TableElement;
				if (xTextTableElement == null)
				{
					xTextTableElement = (args.Document.GetElementById(tableCommandArgs.TableID) as XTextTableElement);
				}
				if (xTextTableElement != null && xTextTableElement.Columns.Count > 0)
				{
					int colIndex = tableCommandArgs.ColIndex;
					xTextTableColumnElement = ((colIndex < 0) ? ((XTextTableColumnElement)xTextTableElement.Columns[0]) : ((colIndex < xTextTableElement.Columns.Count) ? ((XTextTableColumnElement)xTextTableElement.Columns[colIndex]) : ((XTextTableColumnElement)xTextTableElement.Columns.LastElement)));
				}
			}
			if (xTextTableColumnElement == null)
			{
				XTextElementList rowsOrColumns = GetRowsOrColumns(xtextDocument_0, getTableRow: false);
				if (rowsOrColumns == null || rowsOrColumns.Count == 0)
				{
					if (args.Mode == WriterCommandEventMode.QueryState)
					{
						args.Enabled = false;
					}
					return null;
				}
				xTextTableColumnElement = ((!insertLeft) ? ((XTextTableColumnElement)rowsOrColumns.LastElement) : ((XTextTableColumnElement)rowsOrColumns.FirstElement));
			}
			XTextTableElement ownerTable = xTextTableColumnElement.OwnerTable;
			if (!args.DocumentControler.CanInsert(ownerTable, 0, typeof(XTextTableColumnElement)))
			{
				if (args.Mode == WriterCommandEventMode.QueryState)
				{
					args.Enabled = false;
				}
				return null;
			}
			if (args.Mode == WriterCommandEventMode.QueryState)
			{
				args.Enabled = true;
				return null;
			}
			XTextElementList xTextElementList = new XTextElementList();
			for (int i = 0; i < num; i++)
			{
				XTextTableColumnElement xTextTableColumnElement2 = ownerTable.CreateColumnInstance();
				xTextTableColumnElement2.Width = xTextTableColumnElement.Width;
				xTextElementList.Add(xTextTableColumnElement2);
			}
			if (insertLeft)
			{
				ownerTable.method_47(xTextTableColumnElement.Index, xTextElementList, null, bool_26: true, null, xtextDocument_0.Options.EditOptions.KeepTableWidthWhenInsertDeleteColumn, null);
			}
			else
			{
				ownerTable.method_47(xTextTableColumnElement.Index + 1, xTextElementList, null, bool_26: true, null, xtextDocument_0.Options.EditOptions.KeepTableWidthWhenInsertDeleteColumn, null);
			}
			if (xTextElementList != null && xTextElementList.Count > 0 && args.Parameter is TableCommandArgs)
			{
				((TableCommandArgs)args.Parameter).Result = true;
			}
			return xTextElementList;
		}

		/// <summary>
		///       判断能否进行删除表格列操作
		///       </summary>
		/// <param name="doc">设计文档对象</param>
		/// <returns>能否进行操作</returns>
		public static bool CanDeleteCol(XTextDocument xtextDocument_0)
		{
			XTextTableCellElement currentCell = GetCurrentCell(xtextDocument_0);
			if (currentCell == null)
			{
				return false;
			}
			if (currentCell.OwnerTable.Columns.Count == 1)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       判断能否进行合并单元格操作
		///       </summary>
		/// <param name="doc">文档对象</param>
		/// <returns>能否进行操作</returns>
		public static bool CanMergeCell(XTextDocument xtextDocument_0)
		{
			XTextTableCellElement currentCell = GetCurrentCell(xtextDocument_0);
			if (currentCell == null)
			{
				return false;
			}
			if (currentCell.OwnerTable.Rows.Count == 1 && currentCell.OwnerTable.Columns.Count == 1)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		///       判断能否进行插入表格行操作
		///       </summary>
		/// <param name="doc">设计文档对象</param>
		/// <returns>能否进行插入表格行操作</returns>
		public static bool CanInsertRow(XTextDocument xtextDocument_0)
		{
			return GetCurrentRow(xtextDocument_0) != null;
		}

		public static XTextElementList GetHandledRows(XTextDocument document, bool firstRowOnly)
		{
			XTextElementList handledCells = GetHandledCells(document, firstRowOnly);
			XTextElementList xTextElementList = new XTextElementList();
			if (handledCells != null && handledCells.Count > 0)
			{
				foreach (XTextTableCellElement item in handledCells)
				{
					if (!xTextElementList.Contains(item.OwnerRow))
					{
						xTextElementList.Add(item.OwnerRow);
					}
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       单元格内容底端居中对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignBottomCenter", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignBottomCenter.bmp")]
		protected void AlignBottomCenter(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.BottomCenter, e);
		}

		/// <summary>
		///       单元格内容底端左对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignBottomLeft", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignBottomLeft.bmp")]
		protected void AlignBottomLeft(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.BottomLeft, e);
		}

		/// <summary>
		///       单元格内容底端居中对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignBottomRight", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignBottomRight.bmp")]
		protected void AlignBottomRight(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.BottomRight, e);
		}

		/// <summary>
		///       单元格内容垂直居中水平居中对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignMiddleCenter", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignMiddleCenter.bmp")]
		protected void AlignMiddleCenter(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.MiddleCenter, e);
		}

		/// <summary>
		///       单元格内容垂直居中水平左对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignMiddleLeft", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignMiddleLeft.bmp")]
		protected void AlignMiddleLeft(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.MiddleLeft, e);
		}

		/// <summary>
		///       单元格内容垂直居中右对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignMiddleRight", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignMiddleRight.bmp")]
		protected void AlignMiddleRight(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.MiddleRight, e);
		}

		/// <summary>
		///       单元格内容靠上居中对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignTopCenter", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignTopCenter.bmp")]
		protected void AlignTopCenter(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.TopCenter, e);
		}

		/// <summary>
		///       单元格内容靠上居中对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignTopLeft", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignTopLeft.bmp")]
		protected void AlignTopLeft(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.TopLeft, e);
		}

		/// <summary>
		///       单元格内容靠上居中对齐
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("AlignTopRight", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignTopRight.bmp")]
		protected void AlignTopRight(object sender, WriterCommandEventArgs e)
		{
			SetCellContentAlign(ContentAlignment.TopRight, e);
		}

		/// <summary>
		///       设置单元格的内容对齐方式
		///       </summary>
		/// <param name="align">新对齐方式</param>
		/// <param name="args">参数</param>
		private static void SetCellContentAlign(ContentAlignment align, WriterCommandEventArgs args)
		{
			if (args.Mode == WriterCommandEventMode.QueryState)
			{
				args.Enabled = false;
				args.Checked = false;
				if (args.EditorControl != null)
				{
					XTextElementList handledCells = GetHandledCells(args.Document, firstOnly: true);
					if (handledCells != null && handledCells.Count > 0)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)handledCells[0];
						foreach (XTextParagraphFlagElement paragraphsFlag in xTextTableCellElement.ParagraphsFlags)
						{
							if (args.DocumentControler.CanModify(paragraphsFlag))
							{
								args.Enabled = true;
								switch (xTextTableCellElement.ContentVertialAlign)
								{
								case VerticalAlignStyle.Top:
									switch (paragraphsFlag.RuntimeStyle.Align)
									{
									case DocumentContentAlignment.Left:
										args.Checked = (align == ContentAlignment.TopLeft);
										break;
									case DocumentContentAlignment.Center:
										args.Checked = (align == ContentAlignment.TopCenter);
										break;
									case DocumentContentAlignment.Right:
										args.Checked = (align == ContentAlignment.TopRight);
										break;
									case DocumentContentAlignment.Justify:
										args.Checked = (align == ContentAlignment.TopCenter);
										break;
									}
									break;
								case VerticalAlignStyle.Middle:
									switch (paragraphsFlag.RuntimeStyle.Align)
									{
									case DocumentContentAlignment.Left:
										args.Checked = (align == ContentAlignment.MiddleLeft);
										break;
									case DocumentContentAlignment.Center:
										args.Checked = (align == ContentAlignment.MiddleCenter);
										break;
									case DocumentContentAlignment.Right:
										args.Checked = (align == ContentAlignment.MiddleRight);
										break;
									case DocumentContentAlignment.Justify:
										args.Checked = (align == ContentAlignment.MiddleCenter);
										break;
									}
									break;
								case VerticalAlignStyle.Bottom:
									switch (paragraphsFlag.RuntimeStyle.Align)
									{
									case DocumentContentAlignment.Left:
										args.Checked = (align == ContentAlignment.BottomLeft);
										break;
									case DocumentContentAlignment.Center:
										args.Checked = (align == ContentAlignment.BottomCenter);
										break;
									case DocumentContentAlignment.Right:
										args.Checked = (align == ContentAlignment.BottomRight);
										break;
									case DocumentContentAlignment.Justify:
										args.Checked = (align == ContentAlignment.BottomCenter);
										break;
									}
									break;
								}
								break;
							}
						}
					}
				}
			}
			else
			{
				if (args.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				args.Result = false;
				if (!args.UIStartEditContent())
				{
					return;
				}
				args.RefreshLevel = UIStateRefreshLevel.All;
				XTextElementList handledCells = GetHandledCells(args.Document, firstOnly: false);
				if (handledCells != null && handledCells.Count > 0)
				{
					Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
					VerticalAlignStyle verticalAlignStyle = VerticalAlignStyle.Middle;
					DocumentContentAlignment documentContentAlignment = DocumentContentAlignment.Left;
					switch (align)
					{
					case ContentAlignment.MiddleCenter:
						verticalAlignStyle = VerticalAlignStyle.Middle;
						documentContentAlignment = DocumentContentAlignment.Center;
						break;
					case ContentAlignment.MiddleLeft:
						verticalAlignStyle = VerticalAlignStyle.Middle;
						documentContentAlignment = DocumentContentAlignment.Left;
						break;
					case ContentAlignment.TopLeft:
						verticalAlignStyle = VerticalAlignStyle.Top;
						documentContentAlignment = DocumentContentAlignment.Left;
						break;
					case ContentAlignment.TopCenter:
						verticalAlignStyle = VerticalAlignStyle.Top;
						documentContentAlignment = DocumentContentAlignment.Center;
						break;
					case ContentAlignment.TopRight:
						verticalAlignStyle = VerticalAlignStyle.Top;
						documentContentAlignment = DocumentContentAlignment.Right;
						break;
					case ContentAlignment.BottomLeft:
						verticalAlignStyle = VerticalAlignStyle.Bottom;
						documentContentAlignment = DocumentContentAlignment.Left;
						break;
					case ContentAlignment.MiddleRight:
						verticalAlignStyle = VerticalAlignStyle.Middle;
						documentContentAlignment = DocumentContentAlignment.Right;
						break;
					case ContentAlignment.BottomRight:
						verticalAlignStyle = VerticalAlignStyle.Bottom;
						documentContentAlignment = DocumentContentAlignment.Right;
						break;
					case ContentAlignment.BottomCenter:
						verticalAlignStyle = VerticalAlignStyle.Bottom;
						documentContentAlignment = DocumentContentAlignment.Center;
						break;
					}
					foreach (XTextTableCellElement item in handledCells)
					{
						if (!item.IsOverrided && args.DocumentControler.CanModify(item))
						{
							if (item.ContentVertialAlign != verticalAlignStyle)
							{
								DocumentContentStyle documentContentStyle = item.RuntimeStyle.CloneParent();
								documentContentStyle.DisableDefaultValue = true;
								documentContentStyle.VerticalAlign = verticalAlignStyle;
								dictionary[item] = args.Document.ContentStyles.GetStyleIndex(documentContentStyle);
							}
							foreach (XTextParagraphFlagElement paragraphsFlag2 in item.ParagraphsFlags)
							{
								if (paragraphsFlag2.OwnerLine != null)
								{
								}
								if (args.DocumentControler.CanModify(paragraphsFlag2) && paragraphsFlag2.RuntimeStyle.Align != documentContentAlignment)
								{
									DocumentContentStyle documentContentStyle = paragraphsFlag2.RuntimeStyle.CloneParent();
									documentContentStyle.DisableDefaultValue = true;
									documentContentStyle.Align = documentContentAlignment;
									dictionary[paragraphsFlag2] = args.Document.ContentStyles.GetStyleIndex(documentContentStyle);
								}
							}
						}
					}
					if (dictionary.Count > 0)
					{
						args.Result = true;
						args.Document.EditorSetElementStyle(dictionary, logUndo: true, causeUpdateLayout: true, args.Name);
					}
				}
			}
		}

		/// <summary>
		///       设置单元格网格线
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_SetCellGridLine")]
		protected void Table_SetCellGridLine(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				XTextElementList handledRows = GetHandledRows(e.Document, firstRowOnly: true);
				e.Enabled = (handledRows != null && handledRows.Count > 0);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextElementList handledRows2 = GetHandledRows(e.Document, firstRowOnly: true);
				if (handledRows2 != null && handledRows2.Count > 0)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)handledRows2[0];
					e.Document.BeginLogUndo();
					bool flag = xTextTableRowElement.EditorSetSpecifyFixedLineHeight(float.NaN, showGridLine: true, logUndo: true);
					e.Document.EndLogUndo();
					if (flag)
					{
						e.Document.Modified = true;
						e.Document.OnDocumentContentChanged();
						e.RefreshLevel = UIStateRefreshLevel.All;
						e.Result = xTextTableRowElement;
					}
				}
			}
		}

		/// <summary>
		///       标题行
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("Table_HeaderRow")]
		protected void Table_HeaderRow(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.EditorControl == null)
				{
					e.Enabled = false;
					return;
				}
				e.Checked = false;
				XTextElementList handledRows = GetHandledRows(e.Document, firstRowOnly: true);
				if (handledRows != null && handledRows.Count > 0)
				{
					e.Enabled = true;
					foreach (XTextTableRowElement item in handledRows)
					{
						if (item.HeaderStyle)
						{
							e.Checked = true;
							break;
						}
					}
				}
				else
				{
					e.Enabled = false;
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextElementList handledRows = GetHandledRows(e.Document, firstRowOnly: false);
				if (handledRows != null && handledRows.Count > 0 && e.UIStartEditContent())
				{
					XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)handledRows.LastElement;
					XTextTableElement ownerTable = xTextTableRowElement2.OwnerTable;
					handledRows = new XTextElementList();
					for (int i = 0; i <= ownerTable.Rows.IndexOf(xTextTableRowElement2); i++)
					{
						handledRows.Add(ownerTable.Rows[i]);
					}
					bool flag = false;
					if (e.Parameter is bool)
					{
						flag = (bool)e.Parameter;
					}
					else
					{
						flag = true;
						foreach (XTextTableRowElement item2 in handledRows)
						{
							if (item2.HeaderStyle)
							{
								flag = false;
								break;
							}
						}
					}
					Dictionary<XTextTableRowElement, bool> dictionary = new Dictionary<XTextTableRowElement, bool>();
					foreach (XTextTableRowElement item3 in handledRows)
					{
						if (item3.HeaderStyle != flag)
						{
							dictionary[item3] = flag;
						}
					}
					e.Document.BeginLogUndo();
					if (dictionary.Count > 0)
					{
						XTextTableElement ownerTable2 = ((XTextTableRowElement)handledRows[0]).OwnerTable;
						ownerTable2.EditorSetHeaderRow(dictionary, logUndo: true);
					}
					e.Document.EndLogUndo();
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       设置表格单元格的网格线
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Table_CellGridLine", ImageResource = "DCSoft.Writer.Commands.Images.CommandCellGridLine.bmp")]
		protected void Table_CellGridLine(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				e.Checked = false;
				if (e.Document != null)
				{
					XTextElementList handledCells = GetHandledCells(e.Document, firstOnly: true);
					if (handledCells != null && handledCells.Count > 0)
					{
						foreach (XTextTableCellElement item in handledCells)
						{
							if (e.DocumentControler.CanModify(item))
							{
								e.Enabled = true;
								e.Checked = (item.RuntimeStyle.GridLineType != ContentGridLineType.None);
								break;
							}
						}
					}
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (!e.UIStartEditContent())
				{
					return;
				}
				e.RefreshLevel = UIStateRefreshLevel.All;
				XTextElementList handledCells = GetHandledCells(e.Document, firstOnly: false);
				if (handledCells == null || handledCells.Count <= 0)
				{
					return;
				}
				ContentGridLineType contentGridLineType = ContentGridLineType.None;
				if (e.Parameter is ContentGridLineType)
				{
					contentGridLineType = (ContentGridLineType)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					try
					{
						ContentGridLineType contentGridLineType2 = (ContentGridLineType)Enum.Parse(typeof(ContentGridLineType), (string)e.Parameter, ignoreCase: true);
						contentGridLineType = contentGridLineType2;
					}
					catch
					{
					}
				}
				else
				{
					contentGridLineType = handledCells[0].RuntimeStyle.GridLineType;
					if (!e.ShowUI)
					{
						contentGridLineType = ((contentGridLineType == ContentGridLineType.None) ? ContentGridLineType.ExtentToBottom : ContentGridLineType.None);
					}
				}
				if (e.ShowUI)
				{
					using (dlgContentGridLineType dlgContentGridLineType = new dlgContentGridLineType())
					{
						dlgContentGridLineType.GridLineType = contentGridLineType;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgContentGridLineType, null) != DialogResult.OK)
						{
							return;
						}
						contentGridLineType = dlgContentGridLineType.GridLineType;
					}
				}
				Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
				foreach (XTextTableCellElement item2 in handledCells)
				{
					if (e.DocumentControler.CanModify(item2) && item2.RuntimeStyle.GridLineType != contentGridLineType)
					{
						DocumentContentStyle documentContentStyle = item2.RuntimeStyle.CloneParent();
						documentContentStyle.DisableDefaultValue = true;
						documentContentStyle.GridLineType = contentGridLineType;
						dictionary[item2] = e.Document.ContentStyles.GetStyleIndex(documentContentStyle);
					}
				}
				if (dictionary.Count > 0)
				{
					e.Result = true;
					e.Document.EditorSetElementStyle(dictionary, logUndo: true, causeUpdateLayout: false, e.Name);
				}
			}
		}

		/// <summary>
		///       获得当前位置所在的表格行或者所有在同一个表格中的表格行或者表格列的列表
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="getTableRow">true:获得表格行;false:获得表格列</param>
		/// <returns>获得的要操作的对象列表</returns>
		public static XTextElementList GetRowsOrColumns(XTextDocument document, bool getTableRow)
		{
			XTextElementList xTextElementList = new XTextElementList();
			XTextSelection selection = document.Selection;
			if (selection.Cells != null && selection.Cells.Count > 0)
			{
				XTextTableElement ownerTable = ((XTextTableCellElement)selection.Cells[0]).OwnerTable;
				foreach (XTextTableCellElement cell in selection.Cells)
				{
					if (getTableRow)
					{
						XTextTableRowElement ownerRow = cell.OwnerRow;
						if (!xTextElementList.Contains(ownerRow) && ownerRow.OwnerTable == ownerTable)
						{
							xTextElementList.Add(ownerRow);
						}
					}
					else
					{
						XTextTableColumnElement ownerColumn = cell.OwnerColumn;
						if (!xTextElementList.Contains(ownerColumn) && ownerColumn.OwnerTable == ownerTable)
						{
							xTextElementList.Add(ownerColumn);
						}
					}
				}
			}
			else
			{
				XTextTableCellElement xTextTableCellElement = GetCurrentCell(document);
				if (xTextTableCellElement != null && xTextTableCellElement.RowIndex >= 0)
				{
					XTextTableElement ownerTable = xTextTableCellElement.OwnerTable;
					if (getTableRow)
					{
						for (int i = 0; i < xTextTableCellElement.RowSpan; i++)
						{
							xTextElementList.Add(ownerTable.RuntimeRows[xTextTableCellElement.RowIndex + i]);
						}
					}
					else
					{
						for (int i = 0; i < xTextTableCellElement.ColSpan; i++)
						{
							xTextElementList.Add(ownerTable.Columns[xTextTableCellElement.ColIndex + i]);
						}
					}
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       获得文档中需要处理的单元格对象列表
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <param name="firstOnly">只返回第一个要处理的单元格对象</param>
		/// <returns>获得的单元格对象列表</returns>
		public static XTextElementList GetHandledCells(XTextDocument document, bool firstOnly)
		{
			int num = 14;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			XTextElementList xTextElementList = new XTextElementList();
			if (document.Selection.Length == 0)
			{
				if (document.CurrentElement != null)
				{
					XTextTableCellElement ownerCell = document.CurrentElement.OwnerCell;
					if (ownerCell != null)
					{
						xTextElementList.Add(ownerCell);
					}
				}
			}
			else if (document.Selection.Mode == ContentRangeMode.Cell || document.Selection.Mode == ContentRangeMode.Mixed)
			{
				xTextElementList = document.Selection.Cells.Clone();
			}
			else
			{
				XTextTableCellElement ownerCell = document.Selection.ContentElements[0].OwnerCell;
				if (ownerCell != null)
				{
					xTextElementList.Add(ownerCell);
				}
			}
			if (firstOnly)
			{
				foreach (XTextTableCellElement item in xTextElementList)
				{
					if (!item.IsOverrided && document.DocumentControler.CanModify(item))
					{
						return new XTextElementList(item);
					}
				}
				return new XTextElementList();
			}
			for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
			{
				XTextTableCellElement ownerCell = (XTextTableCellElement)xTextElementList[num2];
				if (ownerCell.IsOverrided || !document.DocumentControler.CanModify(ownerCell))
				{
					xTextElementList.RemoveAt(num2);
				}
			}
			return xTextElementList;
		}

		public static string GetRowDisplayID(XTextTableRowElement xtextTableRowElement_0)
		{
			int num = 17;
			if (xtextTableRowElement_0 == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(xtextTableRowElement_0.ID))
			{
				XTextTableElement ownerTable = xtextTableRowElement_0.OwnerTable;
				if (ownerTable != null && !string.IsNullOrEmpty(ownerTable.ID))
				{
					return ownerTable.ID + "#Row" + ownerTable.Rows.IndexOf(xtextTableRowElement_0);
				}
				return "Row";
			}
			return xtextTableRowElement_0.ID;
		}

		/// <summary>
		///       获得当前表格行对象
		///       </summary>
		/// <param name="doc">设计文档对象</param>
		/// <returns>当前单元格对象,若没有则返回空引用</returns>
		public static XTextTableRowElement GetCurrentRow(XTextDocument xtextDocument_0)
		{
			if (xtextDocument_0 == null)
			{
				return null;
			}
			XTextElement xTextElement = xtextDocument_0.CurrentElement;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElement is XTextTableRowElement)
					{
						break;
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				return null;
			}
			return (XTextTableRowElement)xTextElement;
		}

		/// <summary>
		///       获得当前表格对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>当前表格对象</returns>
		public static XTextTableElement GetCurrentTable(XTextDocument document)
		{
			if (document == null)
			{
				return null;
			}
			XTextElement xTextElement = document.CurrentElement;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElement is XTextTableElement)
					{
						break;
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				return null;
			}
			return (XTextTableElement)xTextElement;
		}

		/// <summary>
		///       获得当前单元格对象
		///       </summary>
		/// <param name="doc">设计文档对象</param>
		/// <returns>当前单元格对象,若没有则返回空引用</returns>
		public static XTextTableCellElement GetCurrentCell(XTextDocument xtextDocument_0)
		{
			if (xtextDocument_0 == null)
			{
				return null;
			}
			XTextContent content = xtextDocument_0.Content;
			if (content.Selection.Cells != null && content.Selection.Cells.Count > 0)
			{
				return (XTextTableCellElement)content.Selection.Cells[0];
			}
			XTextElement xTextElement = xtextDocument_0.CurrentElement;
			while (true)
			{
				if (xTextElement != null)
				{
					if (xTextElement is XTextTableCellElement)
					{
						break;
					}
					xTextElement = xTextElement.Parent;
					continue;
				}
				return null;
			}
			return (XTextTableCellElement)xTextElement;
		}
	}
}
