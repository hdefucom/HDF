#define DEBUG
using DCSoft.Common;
using DCSoft.Design;
using DCSoft.Drawing;
using DCSoft.Drawing.Design;
using DCSoft.WinForms;
using DCSoft.WinForms.Controls;
using DCSoft.WinForms.Design;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Undo;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档内容格式命令模块
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[WriterCommandDescription("Format")]
	[ComVisible(false)]
	public class WriterCommandModuleFormat : WriterCommandModule
	{
		private DCMenuHelper _ColorMenu = null;

		/// <summary>
		///       设置文档节的边框和背景
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SectionBorderBackgroundFormat", ReturnValueType = typeof(bool), DefaultResultValue = false, ImageResource = "DCSoft.Writer.Commands.Images.CommandBorderBackgroundFormat.bmp")]
		protected void SectionBorderBackgroundFormat(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextSectionElement xTextSectionElement = (XTextSectionElement)e.Document.GetCurrentElement(typeof(XTextSectionElement));
					if (xTextSectionElement != null && e.DocumentControler.CanModify(xTextSectionElement))
					{
						e.Enabled = true;
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
				XTextSectionElement xTextSectionElement = (XTextSectionElement)e.Document.GetCurrentElement(typeof(XTextSectionElement));
				if (xTextSectionElement == null || !e.DocumentControler.CanModify(xTextSectionElement))
				{
					return;
				}
				DocumentContentStyle documentContentStyle = e.Parameter as DocumentContentStyle;
				if (documentContentStyle != null || e.ShowUI)
				{
					if (documentContentStyle == null)
					{
						documentContentStyle = xTextSectionElement.RuntimeStyle.CloneParent();
					}
					if (e.ShowUI)
					{
						using (dlgBorderBackground dlgBorderBackground = new dlgBorderBackground())
						{
							if (e.EditorControl != null)
							{
								dlgBorderBackground.Text = e.EditorControl.DialogTitlePrefix + dlgBorderBackground.Text;
							}
							dlgBorderBackground.ContentStyle = documentContentStyle;
							if (WriterControl.UIShowDialog(e.EditorControl, dlgBorderBackground, xTextSectionElement) != DialogResult.OK)
							{
								return;
							}
						}
					}
					e.Result = false;
					DocumentContentStyle documentContentStyle2 = xTextSectionElement.RuntimeStyle.CloneParent();
					XDependencyObject.smethod_7(documentContentStyle, documentContentStyle2, bool_3: true);
					int styleIndex = e.Document.ContentStyles.GetStyleIndex(documentContentStyle2);
					if (e.Document.BeginLogUndo())
					{
						e.Document.UndoList.AddStyleIndex(xTextSectionElement, xTextSectionElement.StyleIndex, styleIndex);
						e.Document.EndLogUndo();
					}
					xTextSectionElement.StyleIndex = styleIndex;
					e.Document.Modified = true;
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
					e.RefreshLevel = UIStateRefreshLevel.None;
					xTextSectionElement.InvalidateView();
					e.Result = true;
				}
			}
		}

		private static XTextElementList GetFormatHandleElements(XTextDocument document, bool includeContent, bool includeParagraphs, bool includeCells, DocumentControler documentControler_0)
		{
			if (documentControler_0 == null)
			{
				documentControler_0 = document.DocumentControler;
			}
			XTextElementList xTextElementList = new XTextElementList();
			if (includeContent && document != null && document.Selection.Length != 0)
			{
				foreach (XTextElement contentElement in document.Selection.ContentElements)
				{
					if (documentControler_0.CanModify(contentElement))
					{
						xTextElementList.Add(contentElement);
					}
				}
			}
			if (includeParagraphs)
			{
				if (document.Selection.Length == 0)
				{
					XTextParagraphFlagElement currentParagraphEOF = document.CurrentParagraphEOF;
					if (documentControler_0.CanModify(currentParagraphEOF))
					{
						xTextElementList.Add(currentParagraphEOF);
					}
				}
				else
				{
					foreach (XTextElement selectionParagraphFlag in document.Selection.SelectionParagraphFlags)
					{
						if (documentControler_0.CanModify(selectionParagraphFlag))
						{
							xTextElementList.Add(selectionParagraphFlag);
						}
					}
				}
			}
			if (includeCells)
			{
				if (document.Selection.Cells != null && document.Selection.Cells.Count > 0)
				{
					foreach (XTextTableCellElement cell in document.Selection.Cells)
					{
						if (!cell.IsOverrided && documentControler_0.CanModify(cell))
						{
							xTextElementList.Add(cell);
						}
					}
				}
				else
				{
					XTextElement currentElement = document.CurrentElement;
					if (currentElement != null)
					{
						XTextTableCellElement xTextTableCellElement = currentElement.OwnerCell;
						if (xTextTableCellElement != null && !xTextTableCellElement.IsOverrided && documentControler_0.CanModify(xTextTableCellElement))
						{
							xTextElementList.Add(xTextTableCellElement);
						}
					}
				}
			}
			if (xTextElementList.Count > 0)
			{
				return xTextElementList;
			}
			return null;
		}

		/// <summary>
		///       用设置下边框的方式来设置下划线，此命令会强制更改操作元素的边框
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InputFieldUnderLine", ReturnValueType = typeof(bool), DefaultResultValue = false, ImageResource = "DCSoft.Writer.Commands.Images.CommandUnderline.bmp")]
		protected void InputFieldUnderLine(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && !e.EditorControl.RuntimeReadonly && e.EditorControl.CurrentInputField != null && e.DocumentControler.CanModify(e.EditorControl.CurrentInputField))
				{
					e.Enabled = true;
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
				if (e.ShowUI)
				{
					InputFieldUnderLineCommandParameter inputFieldUnderLineCommandParameter = new InputFieldUnderLineCommandParameter();
					inputFieldUnderLineCommandParameter.IsAddLine = !e.EditorControl.CurrentInputField.Style.BorderBottom;
					using (dlgInputFieldUnderLineInfo dlgInputFieldUnderLineInfo = new dlgInputFieldUnderLineInfo(inputFieldUnderLineCommandParameter))
					{
						if (dlgInputFieldUnderLineInfo.ShowDialog() == DialogResult.OK)
						{
							if (dlgInputFieldUnderLineInfo.bool_0)
							{
								e.Parameter = dlgInputFieldUnderLineInfo.inputFieldUnderLineCommandParameter_0;
							}
							else
							{
								e.Parameter = false;
							}
						}
					}
				}
				bool flag = false;
				InputFieldUnderLineCommandParameter inputFieldUnderLineCommandParameter2 = new InputFieldUnderLineCommandParameter();
				XTextInputFieldElement currentInputField = e.EditorControl.CurrentInputField;
				DocumentContentStyle documentContentStyle = null;
				if (currentInputField == null)
				{
					return;
				}
				documentContentStyle = currentInputField.Style;
				if (e.Parameter is bool)
				{
					flag = (bool)e.Parameter;
				}
				else if (e.Parameter is InputFieldUnderLineCommandParameter)
				{
					flag = true;
					inputFieldUnderLineCommandParameter2 = (InputFieldUnderLineCommandParameter)e.Parameter;
				}
				if (flag)
				{
					documentContentStyle.BorderTop = false;
					documentContentStyle.BorderLeft = false;
					documentContentStyle.BorderRight = false;
					documentContentStyle.BorderBottom = true;
					documentContentStyle.BorderBottomColor = inputFieldUnderLineCommandParameter2.InputFieldUnderLineColor;
					documentContentStyle.BorderStyle = inputFieldUnderLineCommandParameter2.InputFieldUnderLineStyle;
					documentContentStyle.BorderWidth = inputFieldUnderLineCommandParameter2.InputFieldUnderLineWidth;
				}
				else
				{
					documentContentStyle.BorderTop = false;
					documentContentStyle.BorderLeft = false;
					documentContentStyle.BorderRight = false;
					documentContentStyle.BorderBottom = false;
				}
				e.Document.BeginLogUndo();
				if (currentInputField != null)
				{
					if (inputFieldUnderLineCommandParameter2.bUseMyOwnLength)
					{
						currentInputField.SpecifyWidth = WriterUtils.smethod_37(e.Document, (decimal)inputFieldUnderLineCommandParameter2.InputFieldUnderLineLength);
					}
					currentInputField.Style = documentContentStyle;
					currentInputField.EditorRefreshView();
				}
				e.Document.EndLogUndo();
				e.Document.OnDocumentContentChanged();
				e.Result = true;
			}
		}

		/// <summary>
		///       格式刷
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FormatBrush", ReturnValueType = typeof(bool), DefaultResultValue = false, ImageResource = "DCSoft.Writer.Commands.Images.CommandFormatBrush.bmp", FunctionID = GEnum6.const_57)]
		protected void FormatBrush(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && !e.EditorControl.RuntimeReadonly)
				{
					e.Enabled = true;
					e.Checked = (e.EditorControl.StyleInfoForFormatBrush != null);
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && XTextDocument.smethod_13(GEnum6.const_57))
			{
				e.Result = false;
				if (e.UIStartEditContent())
				{
					e.RefreshLevel = UIStateRefreshLevel.Current;
					e.EditorControl.CancelEditElementValue();
					e.EditorControl.StyleInfoForFormatBrush = e.Document.CurrentStyleInfo.method_2();
					e.Result = true;
				}
			}
		}

		/// <summary>
		///       执行格式刷完成功能
		///       </summary>
		/// <param name="ctl">
		/// </param>
		internal static void ApplyFormatBrush(WriterControl writerControl_0)
		{
			CurrentContentStyleInfo styleInfoForFormatBrush = writerControl_0.StyleInfoForFormatBrush;
			writerControl_0.StyleInfoForFormatBrush = null;
			XTextElementList formatHandleElements = GetFormatHandleElements(writerControl_0.Document, includeContent: true, includeParagraphs: true, includeCells: true, writerControl_0.Document.DocumentControler);
			writerControl_0.Document.BeginLogUndo();
			bool flag = XTextSelection.smethod_0(styleInfoForFormatBrush.Content, styleInfoForFormatBrush.Paragraph, styleInfoForFormatBrush.Cell, writerControl_0.Document, formatHandleElements, bool_1: true, "FormatBrush", bool_2: true);
			writerControl_0.Document.EndLogUndo();
			if (flag)
			{
				writerControl_0.Document.OnSelectionChanged();
				writerControl_0.Document.OnDocumentContentChanged();
				writerControl_0.CommandControler.InvalidateCommandState();
			}
		}

		/// <summary>
		///       清空文档样式格式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ClearFormat", ReturnValueType = typeof(bool), DefaultResultValue = false, ImageResource = "DCSoft.Writer.Commands.Images.CommandClearFormat.bmp", FunctionID = GEnum6.const_58)]
		protected void ClearFormat(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextElementList formatHandleElements = GetFormatHandleElements(e.Document, includeContent: true, includeParagraphs: true, includeCells: true, e.DocumentControler);
					if (formatHandleElements != null && formatHandleElements.Count > 0)
					{
						e.Enabled = true;
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
				XTextElementList formatHandleElements = GetFormatHandleElements(e.Document, includeContent: true, includeParagraphs: true, includeCells: true, e.DocumentControler);
				if (formatHandleElements == null || formatHandleElements.Count <= 0)
				{
					return;
				}
				e.EditorControl.CancelFormatBrush();
				e.Document.BeginLogUndo();
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)e.Document.ContentStyles.Default.Clone();
				documentContentStyle.DisableDefaultValue = true;
				if (e.Document.Options.SecurityOptions.EnablePermission)
				{
					documentContentStyle.CreatorIndex = e.Document.UserHistories.CurrentIndex;
				}
				e.Result = XTextSelection.smethod_0(documentContentStyle, documentContentStyle, documentContentStyle, e.Document, formatHandleElements, bool_1: true, e.Name, bool_2: true);
				e.Document.EndLogUndo();
				if ((bool)e.Result)
				{
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
					if (e.EditorControl != null)
					{
						e.EditorControl.vmethod_12();
					}
				}
			}
		}

		/// <summary>
		///       设置段落格式
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("ParagraphFormat", ReturnValueType = typeof(bool))]
		protected void ParagraphFormat(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.Snapshot.CanModifySelection);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				ParagraphFormatCommandParameter paragraphFormatCommandParameter = e.Parameter as ParagraphFormatCommandParameter;
				if (paragraphFormatCommandParameter == null)
				{
					paragraphFormatCommandParameter = new ParagraphFormatCommandParameter();
					paragraphFormatCommandParameter.Read(e.Document.CurrentStyleInfo.Paragraph);
				}
				if (e.ShowUI)
				{
					using (dlgParagraphFormatcs dlgParagraphFormatcs = new dlgParagraphFormatcs())
					{
						if (e.EditorControl != null)
						{
							dlgParagraphFormatcs.Text = e.EditorControl.DialogTitlePrefix + dlgParagraphFormatcs.Text;
						}
						DocumentContentStyle documentContentStyle = new DocumentContentStyle();
						paragraphFormatCommandParameter.Save(documentContentStyle);
						dlgParagraphFormatcs.ContentStyle = documentContentStyle;
						dlgParagraphFormatcs.DocumentGraphicsUnit = e.Document.DocumentGraphicsUnit;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgParagraphFormatcs, null) != DialogResult.OK)
						{
							return;
						}
						paragraphFormatCommandParameter.Read(documentContentStyle);
					}
				}
				DocumentContentStyle documentContentStyle2 = new DocumentContentStyle();
				documentContentStyle2.DisableDefaultValue = true;
				paragraphFormatCommandParameter.Save(documentContentStyle2);
				e.Document.BeginLogUndo();
				XTextElementList xTextElementList = e.Document.Selection.SetParagraphStyle(documentContentStyle2);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					e.Result = true;
				}
				e.Document.EndLogUndo();
				e.Document.OnSelectionChanged();
				e.Document.OnDocumentContentChanged();
				e.EditorControl.method_16();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       边框和背景样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BorderBackgroundFormat", ReturnValueType = typeof(bool), ImageResource = "DCSoft.Writer.Commands.Images.CommandBorderBackgroundFormat.bmp")]
		protected void BorderBackgroundFormat(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				StyleApplyRanges allowApplyRange = GetAllowApplyRange(e);
				e.Enabled = (allowApplyRange != StyleApplyRanges.None);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				StyleApplyRanges allowApplyRange2 = GetAllowApplyRange(e);
				e.Result = false;
				XTextElement xTextElement = null;
				if (Math.Abs(e.Document.Selection.Length) == 1)
				{
					xTextElement = e.Document.Selection.ContentElements[0];
					if (!(xTextElement is XTextObjectElement) && !(xTextElement is XTextShapeInputFieldElement))
					{
						xTextElement = null;
					}
				}
				if (xTextElement != null && !e.DocumentControler.CanModify(xTextElement))
				{
					return;
				}
				BorderBackgroundCommandParameter borderBackgroundCommandParameter = e.Parameter as BorderBackgroundCommandParameter;
				if (borderBackgroundCommandParameter == null && !e.ShowUI)
				{
					return;
				}
				if (borderBackgroundCommandParameter == null)
				{
					borderBackgroundCommandParameter = new BorderBackgroundCommandParameter();
					if (e.Document.Selection.Length != 0)
					{
						if (e.Document.Selection.Mode == ContentRangeMode.Cell)
						{
							ReadCellBorderBackgroundFormatSettings(borderBackgroundCommandParameter, e);
							borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Cell;
						}
						else
						{
							ReadElementBorderBackgroundFormatSettings(borderBackgroundCommandParameter, e, e.Document.Selection.ContentElements[0]);
							if ((allowApplyRange2 & StyleApplyRanges.Text) == StyleApplyRanges.Text)
							{
								borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Text;
							}
							else if ((allowApplyRange2 & StyleApplyRanges.Field) == StyleApplyRanges.Field)
							{
								borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Field;
							}
							else if ((allowApplyRange2 & StyleApplyRanges.Paragraph) == StyleApplyRanges.Paragraph)
							{
								borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Paragraph;
							}
							else if ((allowApplyRange2 & StyleApplyRanges.Cell) == StyleApplyRanges.Cell)
							{
								borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Cell;
							}
						}
					}
					else if ((allowApplyRange2 & StyleApplyRanges.Field) == StyleApplyRanges.Field)
					{
						borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Field;
						ReadElementBorderBackgroundFormatSettings(borderBackgroundCommandParameter, e, e.Document.GetCurrentElement(typeof(XTextInputFieldElement)));
						borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Field;
					}
					else if ((allowApplyRange2 & StyleApplyRanges.Cell) == StyleApplyRanges.Cell)
					{
						borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Cell;
						ReadCellBorderBackgroundFormatSettings(borderBackgroundCommandParameter, e);
					}
					else if ((allowApplyRange2 & StyleApplyRanges.Paragraph) == StyleApplyRanges.Paragraph)
					{
						borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Paragraph;
						ReadElementBorderBackgroundFormatSettings(borderBackgroundCommandParameter, e, e.Document.CurrentElement.OwnerParagraphEOF);
					}
					else if ((allowApplyRange2 & StyleApplyRanges.Section) == StyleApplyRanges.Section)
					{
						borderBackgroundCommandParameter.ApplyRange = StyleApplyRanges.Section;
						ReadElementBorderBackgroundFormatSettings(borderBackgroundCommandParameter, e, e.Document.GetCurrentElement(typeof(XTextSectionElement)));
					}
				}
				if (e.ShowUI)
				{
					using (dlgDocumentBorderBackground dlgDocumentBorderBackground = new dlgDocumentBorderBackground())
					{
						if (e.EditorControl != null)
						{
							dlgDocumentBorderBackground.Text = e.EditorControl.DialogTitlePrefix + dlgDocumentBorderBackground.Text;
						}
						dlgDocumentBorderBackground.AllowApplyRanges = allowApplyRange2;
						dlgDocumentBorderBackground.CommandParameter = borderBackgroundCommandParameter;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgDocumentBorderBackground, null) != DialogResult.OK)
						{
							return;
						}
					}
				}
				e.Result = false;
				if (borderBackgroundCommandParameter.ApplyRange == StyleApplyRanges.Text)
				{
					SetElementsBorderBackgroundFormat(borderBackgroundCommandParameter, e, e.Document.Selection.ContentElements);
					return;
				}
				if (borderBackgroundCommandParameter.ApplyRange == StyleApplyRanges.Cell)
				{
					SetCellBorderBackgroundFormat(borderBackgroundCommandParameter, e, setBorderVisibleOnly: false);
					return;
				}
				if (borderBackgroundCommandParameter.ApplyRange == StyleApplyRanges.Paragraph)
				{
					SetElementsBorderBackgroundFormat(borderBackgroundCommandParameter, e, e.Document.Selection.ParagraphsEOFs);
					return;
				}
				XTextElement xTextElement2 = e.Document.CurrentElement;
				XTextElementList xTextElementList = new XTextElementList();
				while (xTextElement2 != null)
				{
					if (e.DocumentControler.CanModify(xTextElement2))
					{
						if (borderBackgroundCommandParameter.ApplyRange == StyleApplyRanges.Field && xTextElement2 is XTextInputFieldElement)
						{
							xTextElementList.Add(xTextElement2);
							break;
						}
						if (borderBackgroundCommandParameter.ApplyRange == StyleApplyRanges.Row && xTextElement2 is XTextTableRowElement)
						{
							xTextElementList.Add(xTextElement2);
							break;
						}
						if (borderBackgroundCommandParameter.ApplyRange == StyleApplyRanges.Table && xTextElement2 is XTextTableElement)
						{
							xTextElementList.Add(xTextElement2);
							break;
						}
						if (borderBackgroundCommandParameter.ApplyRange == StyleApplyRanges.Section && xTextElement2 is XTextSectionElement)
						{
							xTextElementList.Add(xTextElement2);
							break;
						}
					}
					xTextElement2 = xTextElement2.Parent;
				}
				if (xTextElementList.Count > 0)
				{
					SetElementsBorderBackgroundFormat(borderBackgroundCommandParameter, e, xTextElementList);
				}
			}
		}

		private StyleApplyRanges GetAllowApplyRange(WriterCommandEventArgs args)
		{
			StyleApplyRanges styleApplyRanges = StyleApplyRanges.None;
			if (args.EditorControl == null)
			{
				return styleApplyRanges;
			}
			if (args.EditorControl != null && args.EditorControl.RuntimeReadonly)
			{
				return styleApplyRanges;
			}
			if (args.Document.Selection.Mode == ContentRangeMode.Content && args.Document.Selection.Length != 0 && args.DocumentControler.Snapshot.CanModifySelection)
			{
				return styleApplyRanges | StyleApplyRanges.Text | StyleApplyRanges.Paragraph;
			}
			if (args.DocumentControler.Snapshot.CanModifyParagraphs)
			{
				styleApplyRanges |= StyleApplyRanges.Paragraph;
			}
			if (args.Document.Selection.Mode == ContentRangeMode.Cell)
			{
				styleApplyRanges |= StyleApplyRanges.Cell;
			}
			for (XTextElement xTextElement = args.Document.CurrentElement; xTextElement != null; xTextElement = xTextElement.Parent)
			{
				if (args.DocumentControler.CanModify(xTextElement))
				{
					if (xTextElement is XTextObjectElement)
					{
						styleApplyRanges |= StyleApplyRanges.Text;
					}
					else if (xTextElement is XTextInputFieldElement)
					{
						styleApplyRanges |= StyleApplyRanges.Field;
					}
					else if (xTextElement is XTextTableCellElement)
					{
						styleApplyRanges = (styleApplyRanges | StyleApplyRanges.Cell | StyleApplyRanges.Row | StyleApplyRanges.Table);
					}
					else if (xTextElement is XTextSectionElement)
					{
						styleApplyRanges |= StyleApplyRanges.Section;
					}
				}
			}
			return styleApplyRanges;
		}

		/// <summary>
		///       获得最大和最小单元格行号和列号
		///       </summary>
		/// <param name="cells">
		/// </param>
		/// <param name="minRowIndex">
		/// </param>
		/// <param name="minColIndex">
		/// </param>
		/// <param name="maxRowIndex">
		/// </param>
		/// <param name="maxColIndex">
		/// </param>
		public static void GetCellIndexRange(XTextElementList cells, ref int minRowIndex, ref int minColIndex, ref int maxRowIndex, ref int maxColIndex)
		{
			minRowIndex = 10000;
			minColIndex = 10000;
			maxRowIndex = 0;
			maxColIndex = 0;
			foreach (XTextTableCellElement cell in cells)
			{
				if (cell.RowIndex < minRowIndex)
				{
					minRowIndex = cell.RowIndex;
				}
				if (cell.ColIndex < minColIndex)
				{
					minColIndex = cell.ColIndex;
				}
				if (cell.RowIndex + cell.RowSpan > maxRowIndex)
				{
					maxRowIndex = cell.RowIndex + cell.RowSpan;
				}
				if (cell.ColIndex + cell.ColSpan > maxColIndex)
				{
					maxColIndex = cell.ColIndex + cell.ColSpan;
				}
			}
		}

		/// <summary>
		///       读取单元格的边框背景设置
		///       </summary>
		/// <param name="parameter">参数</param>
		/// <param name="args">参数</param>
		/// <param name="element">元素对象</param>
		/// <returns>操作是否成功</returns>
		private bool ReadElementBorderBackgroundFormatSettings(BorderBackgroundCommandParameter parameter, WriterCommandEventArgs args, XTextElement element)
		{
			RuntimeDocumentContentStyle runtimeStyle = element.RuntimeStyle;
			parameter.BorderLeftColor = runtimeStyle.BorderLeftColor;
			parameter.BorderTopColor = runtimeStyle.BorderTopColor;
			parameter.BorderRightColor = runtimeStyle.BorderRightColor;
			parameter.BorderBottomColor = runtimeStyle.BorderBottomColor;
			parameter.BorderWidth = runtimeStyle.BorderWidth;
			parameter.BorderStyle = runtimeStyle.BorderStyle;
			parameter.LeftBorder = runtimeStyle.BorderLeft;
			parameter.TopBorder = runtimeStyle.BorderTop;
			parameter.RightBorder = runtimeStyle.BorderRight;
			parameter.BottomBorder = runtimeStyle.BorderBottom;
			parameter.BackgroundColor = runtimeStyle.BackgroundColor;
			parameter.MiddleHorizontalBorder = false;
			parameter.CenterVerticalBorder = false;
			parameter.ApplyRange = StyleApplyRanges.Text;
			parameter.SetBorderSettingsStyle();
			return true;
		}

		/// <summary>
		///       设置多个文档元素的边框和背景样式
		///       </summary>
		/// <param name="parameter">参数</param>
		/// <param name="args">参数</param>
		/// <param name="elements">文档元素对象列表</param>
		private void SetElementsBorderBackgroundFormat(BorderBackgroundCommandParameter parameter, WriterCommandEventArgs args, XTextElementList elements)
		{
			args.Document.BeginLogUndo();
			bool flag = false;
			foreach (XTextElement element in elements)
			{
				if (args.DocumentControler.CanModify(element))
				{
					DocumentContentStyle documentContentStyle = element.RuntimeStyle.CloneParent();
					if (parameter.SetContentStyle(documentContentStyle))
					{
						flag = true;
						int styleIndex = args.Document.ContentStyles.GetStyleIndex(documentContentStyle);
						if (styleIndex != element.StyleIndex)
						{
							if (args.Document.CanLogUndo)
							{
								args.Document.UndoList.AddStyleIndex(element, element.StyleIndex, styleIndex);
							}
							element.StyleIndex = styleIndex;
							if (element.ShadowElement != null)
							{
								if (args.Document.CanLogUndo)
								{
									args.Document.UndoList.AddStyleIndex(element.ShadowElement, element.ShadowElement.StyleIndex, styleIndex);
								}
								element.ShadowElement.StyleIndex = styleIndex;
								element.ShadowElement.InvalidateView();
							}
							element.ContentElement.vmethod_44(bool_22: true);
							element.InvalidateView();
							element.UpdateContentVersion();
						}
					}
				}
			}
			args.Document.EndLogUndo();
			if (flag)
			{
				args.Result = true;
				args.Document.Modified = true;
				args.Document.OnDocumentContentChanged();
			}
		}

		/// <summary>
		///       读取单元格的边框背景设置
		///       </summary>
		/// <param name="parameter">参数</param>
		/// <param name="args">参数</param>
		/// <returns>操作是否成功</returns>
		private bool ReadCellBorderBackgroundFormatSettings(BorderBackgroundCommandParameter parameter, WriterCommandEventArgs args)
		{
			XTextSelection selection = args.Document.Selection;
			XTextElementList xTextElementList = new XTextElementList();
			if (selection.Mode == ContentRangeMode.Cell)
			{
				xTextElementList = selection.Cells;
			}
			else
			{
				XTextTableCellElement ownerCell = args.Document.CurrentElement.OwnerCell;
				if (ownerCell != null)
				{
					xTextElementList.Add(ownerCell);
				}
			}
			if (xTextElementList.Count > 0)
			{
				int minRowIndex = 0;
				int minColIndex = 0;
				int maxRowIndex = 0;
				int maxColIndex = 0;
				GetCellIndexRange(xTextElementList, ref minRowIndex, ref minColIndex, ref maxRowIndex, ref maxColIndex);
				parameter.LeftBorder = true;
				parameter.TopBorder = true;
				parameter.RightBorder = true;
				parameter.BottomBorder = true;
				parameter.CenterVerticalBorder = (maxRowIndex - minRowIndex > 1);
				parameter.MiddleHorizontalBorder = (maxColIndex - minColIndex > 1);
				foreach (XTextTableCellElement item in xTextElementList)
				{
					RuntimeDocumentContentStyle runtimeStyle = item.RuntimeStyle;
					if (item.RowIndex == minRowIndex)
					{
						if (!runtimeStyle.BorderTop)
						{
							parameter.TopBorder = false;
						}
					}
					else if (item.RowIndex < maxRowIndex && !runtimeStyle.BorderTop)
					{
						parameter.MiddleHorizontalBorder = false;
					}
					if (item.RowIndex + item.RowSpan == maxRowIndex && !runtimeStyle.BorderBottom)
					{
						parameter.BottomBorder = false;
					}
					if (item.ColIndex == minColIndex)
					{
						if (!runtimeStyle.BorderLeft)
						{
							parameter.LeftBorder = false;
						}
					}
					else if (item.ColIndex < maxColIndex && !runtimeStyle.BorderLeft)
					{
						parameter.CenterVerticalBorder = false;
					}
					if (item.ColIndex + item.ColSpan == maxColIndex && !runtimeStyle.BorderRight)
					{
						parameter.RightBorder = false;
					}
				}
				parameter.SetBorderSettingsStyle();
				RuntimeDocumentContentStyle runtimeStyle2 = xTextElementList[0].RuntimeStyle;
				parameter.BorderLeftColor = runtimeStyle2.BorderLeftColor;
				parameter.BorderTopColor = runtimeStyle2.BorderTopColor;
				parameter.BorderRightColor = runtimeStyle2.BorderRightColor;
				parameter.BorderBottomColor = runtimeStyle2.BorderBottomColor;
				parameter.BorderStyle = runtimeStyle2.BorderStyle;
				parameter.BorderWidth = runtimeStyle2.BorderWidth;
				parameter.BackgroundColor = runtimeStyle2.BackgroundColor;
				return true;
			}
			return false;
		}

		/// <summary>
		///       设置表格单元格的边框和背景样式
		///       </summary>
		/// <param name="parameter">参数</param>
		/// <param name="args">参数</param>
		/// <param name="setBorderVisibleOnly">只设置边框线可见性</param>
		public static void SetCellBorderBackgroundFormat(BorderBackgroundCommandParameter parameter, WriterCommandEventArgs args, bool setBorderVisibleOnly)
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (parameter.Elements != null)
			{
				foreach (XTextElement element in parameter.Elements)
				{
					if (element is XTextTableCellElement)
					{
						xTextElementList.Add(element);
					}
				}
			}
			if (xTextElementList.Count == 0)
			{
				if (args.Parameter is XTextTableCellElement)
				{
					xTextElementList.Add((XTextTableCellElement)args.Parameter);
				}
				else if (args.Parameter is XTextElementList)
				{
					xTextElementList = (XTextElementList)args.Parameter;
				}
				else
				{
					XTextSelection selection = args.Document.Selection;
					if (selection.Mode == ContentRangeMode.Cell)
					{
						xTextElementList = selection.Cells;
					}
					else if (args.Document.CurrentElement != null && args.Document.CurrentElement.OwnerCell != null)
					{
						xTextElementList.Add(args.Document.CurrentElement.OwnerCell);
					}
				}
			}
			if (xTextElementList.Count != 0)
			{
				int minRowIndex = 0;
				int minColIndex = 0;
				int maxRowIndex = 0;
				int maxColIndex = 0;
				if (parameter.ApplyRange == StyleApplyRanges.Cell)
				{
					GetCellIndexRange(xTextElementList, ref minRowIndex, ref minColIndex, ref maxRowIndex, ref maxColIndex);
				}
				else
				{
					XTextTableElement ownerTable = ((XTextTableCellElement)xTextElementList[0]).OwnerTable;
					xTextElementList = ownerTable.Cells;
					minRowIndex = 0;
					minColIndex = 0;
					maxRowIndex = ownerTable.Rows.Count;
					maxColIndex = ownerTable.Columns.Count;
				}
				args.Document.BeginLogUndo();
				bool flag = false;
				DocumentControler documentControler = args.DocumentControler;
				foreach (XTextTableCellElement item in xTextElementList)
				{
					if (!item.IsOverrided && documentControler.CanModify(item))
					{
						DocumentContentStyle documentContentStyle = item.RuntimeStyle.CloneParent();
						bool flag2 = false;
						bool borderTop = documentContentStyle.BorderTop;
						borderTop = ((item.RowIndex != minRowIndex) ? parameter.MiddleHorizontalBorder : parameter.TopBorder);
						if (borderTop != documentContentStyle.BorderTop)
						{
							documentContentStyle.BorderTop = borderTop;
							flag2 = true;
						}
						borderTop = documentContentStyle.BorderLeft;
						borderTop = ((item.ColIndex != minColIndex) ? parameter.CenterVerticalBorder : parameter.LeftBorder);
						if (borderTop != documentContentStyle.BorderLeft)
						{
							documentContentStyle.BorderLeft = borderTop;
							flag2 = true;
						}
						borderTop = documentContentStyle.BorderRight;
						borderTop = ((item.ColIndex + item.ColSpan != maxColIndex) ? parameter.CenterVerticalBorder : parameter.RightBorder);
						if (borderTop != documentContentStyle.BorderRight)
						{
							documentContentStyle.BorderRight = borderTop;
							flag2 = true;
						}
						borderTop = documentContentStyle.BorderBottom;
						borderTop = ((item.RowIndex + item.RowSpan != maxRowIndex) ? parameter.MiddleHorizontalBorder : parameter.BottomBorder);
						if (borderTop != documentContentStyle.BorderBottom)
						{
							documentContentStyle.BorderBottom = borderTop;
							flag2 = true;
						}
						if (!setBorderVisibleOnly)
						{
							if (documentContentStyle.BorderLeftColor.ToArgb() != parameter.BorderLeftColor.ToArgb())
							{
								documentContentStyle.BorderLeftColor = parameter.BorderLeftColor;
								flag2 = true;
							}
							if (documentContentStyle.BorderTopColor.ToArgb() != parameter.BorderTopColor.ToArgb())
							{
								documentContentStyle.BorderTopColor = parameter.BorderTopColor;
								flag2 = true;
							}
							if (documentContentStyle.BorderRightColor.ToArgb() != parameter.BorderRightColor.ToArgb())
							{
								documentContentStyle.BorderRightColor = parameter.BorderRightColor;
								flag2 = true;
							}
							if (documentContentStyle.BorderBottomColor.ToArgb() != parameter.BorderBottomColor.ToArgb())
							{
								documentContentStyle.BorderBottomColor = parameter.BorderBottomColor;
								flag2 = true;
							}
							if (documentContentStyle.BorderStyle != parameter.BorderStyle)
							{
								documentContentStyle.BorderStyle = parameter.BorderStyle;
								flag2 = true;
							}
							if (documentContentStyle.BorderWidth != parameter.BorderWidth)
							{
								documentContentStyle.BorderWidth = parameter.BorderWidth;
								flag2 = true;
							}
							if (!documentContentStyle.BackgroundColor.IsEmpty && documentContentStyle.BackgroundColor.ToArgb() != parameter.BackgroundColor.ToArgb())
							{
								documentContentStyle.BackgroundColor = parameter.BackgroundColor;
								flag2 = true;
							}
						}
						if (flag2)
						{
							flag = true;
							if (item.Parent.RuntimeEnablePermission)
							{
								documentContentStyle.CreatorIndex = args.Document.UserHistories.CurrentIndex;
								documentContentStyle.DeleterIndex = -1;
							}
							int styleIndex = args.Document.ContentStyles.GetStyleIndex(documentContentStyle);
							if (styleIndex != item.StyleIndex)
							{
								if (args.Document.CanLogUndo)
								{
									args.Document.UndoList.AddStyleIndex(item, item.StyleIndex, styleIndex);
								}
								item.StyleIndex = styleIndex;
								item.InvalidateView();
								item.UpdateContentVersion();
								ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
								contentChangedEventArgs.Document = args.Document;
								contentChangedEventArgs.Element = item;
								item.method_23(contentChangedEventArgs);
							}
						}
					}
				}
				args.Document.EndLogUndo();
				if (flag)
				{
					args.Document.Modified = true;
					args.Document.OnDocumentContentChanged();
					args.Result = true;
				}
			}
		}

		/// <summary>
		///       设置背景颜色
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BackColor", ImageResource = "DCSoft.Writer.Commands.Images.CommandBackColor.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_63)]
		protected void BackColor(object sender, WriterCommandEventArgs e)
		{
			CommonColorFunction(sender, e, "BackColor");
		}

		/// <summary>
		///       设置打印用文本颜色
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("PrintColor", ImageResource = "DCSoft.Writer.Commands.Images.CommandColor.bmp", ReturnValueType = typeof(bool))]
		protected void PrintColorFunction(object sender, WriterCommandEventArgs e)
		{
			CommonColorFunction(sender, e, "PrintColor");
		}

		/// <summary>
		///       设置打印用背景文本颜色
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("PrintBackColor", ImageResource = "DCSoft.Writer.Commands.Images.CommandBackColor.bmp", ReturnValueType = typeof(bool))]
		protected void PrintBackColorFunction(object sender, WriterCommandEventArgs e)
		{
			CommonColorFunction(sender, e, "PrintBackColor");
		}

		/// <summary>
		///       设置文本颜色
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Color", ImageResource = "DCSoft.Writer.Commands.Images.CommandColor.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_62)]
		protected void ColorFunction(object sender, WriterCommandEventArgs e)
		{
			CommonColorFunction(sender, e, "Color");
		}

		private void CommonColorFunction(object sender, WriterCommandEventArgs args, string commandName)
		{
			int num = 10;
			if (args.Mode == WriterCommandEventMode.QueryState)
			{
				args.Enabled = (args.DocumentControler != null && args.DocumentControler.Snapshot.CanModifySelection);
				if (commandName == "PrintColor" && args.Enabled)
				{
					args.Enabled = (args.Document.Selection.Length != 0);
				}
			}
			else
			{
				if (args.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				args.Result = false;
				DocumentContentStyle currentStyle = GetCurrentStyle(args.Document);
				Color colorValue = currentStyle.Color;
				switch (commandName)
				{
				case "PrintColor":
					colorValue = currentStyle.PrintColor;
					if (args.Parameter != null)
					{
						colorValue = ConvertToColor(args.Parameter, Color.Black);
					}
					break;
				case "PrintBackColor":
					colorValue = currentStyle.PrintBackColor;
					if (args.Parameter != null)
					{
						colorValue = ConvertToColor(args.Parameter, Color.Empty);
					}
					break;
				case "BackColor":
					colorValue = currentStyle.BackgroundColor;
					if (args.Parameter != null)
					{
						colorValue = ConvertToColor(args.Parameter, Color.Transparent);
					}
					break;
				default:
					if (args.Parameter != null)
					{
						colorValue = ConvertToColor(args.Parameter, Color.Black);
					}
					break;
				}
				if (args.ShowUI)
				{
					Rectangle rectangle_ = WinFormUtils.smethod_5(args.UIElement, args.UIEventArgs);
					if (!rectangle_.IsEmpty)
					{
						if (_ColorMenu == null || _ColorMenu.IsDisposed)
						{
							_ColorMenu = new DCMenuHelper();
							_ColorMenu.ColorPlate.method_12(ColorPlate_SelectedColorChanged);
						}
						args.Name = commandName;
						if (commandName == "Color")
						{
							_ColorMenu.ColorPlate.method_5(bool_3: true);
							_ColorMenu.ColorPlate.method_7(Color.Black);
						}
						else if (commandName == "BackColor")
						{
							_ColorMenu.ColorPlate.method_5(bool_3: true);
							_ColorMenu.ColorPlate.method_7(Color.Transparent);
						}
						else
						{
							_ColorMenu.ColorPlate.method_5(bool_3: false);
						}
						_ColorMenu.ColorPlate.Tag = args;
						_ColorMenu.ColorPlate.method_11(colorValue);
						rectangle_.Location = args.EditorControl.InnerViewControl.PointToClient(rectangle_.Location);
						_ColorMenu.method_2(args.EditorControl.InnerViewControl, rectangle_);
						return;
					}
					if (!args.Host.UITools.PickColor(args.EditorControl, ref colorValue))
					{
						return;
					}
				}
				args.Parameter = colorValue;
				SetStyleProperty(sender, args, commandName);
			}
		}

		private void ColorPlate_SelectedColorChanged(object sender, EventArgs e)
		{
			GControl4 gControl = (GControl4)sender;
			WriterCommandEventArgs writerCommandEventArgs = (WriterCommandEventArgs)gControl.Tag;
			writerCommandEventArgs.Parameter = gControl.method_10();
			SetStyleProperty(sender, writerCommandEventArgs, writerCommandEventArgs.Name);
		}

		private Color ConvertToColor(object parameter, Color defaultValue)
		{
			Color result = defaultValue;
			if (parameter is Color)
			{
				result = (Color)parameter;
			}
			else if (parameter is int)
			{
				int argb = (int)parameter;
				result = Color.FromArgb(argb);
			}
			else if (parameter is string)
			{
				try
				{
					string text = (string)parameter;
					result = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(text);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			}
			return result;
		}

		private IList GetListItemsPropertyValue(object object_0)
		{
			int num = 15;
			if (object_0 == null)
			{
				return null;
			}
			Type type = object_0.GetType();
			string[] array = new string[2]
			{
				"Items",
				"ListItems"
			};
			string[] array2 = array;
			int num2 = 0;
			PropertyInfo property;
			while (true)
			{
				if (num2 < array2.Length)
				{
					string name = array2[num2];
					property = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (property != null && property.CanRead)
					{
						Type collectionItemType = DesignUtils.GetCollectionItemType(property.PropertyType, checkAddMethod: true);
						if (collectionItemType == null)
						{
							return null;
						}
						if (collectionItemType.Equals(typeof(string)) || collectionItemType.Equals(typeof(object)))
						{
							break;
						}
					}
					num2++;
					continue;
				}
				return null;
			}
			return (IList)property.GetValue(object_0, Type.EmptyTypes);
		}

		/// <summary>
		///       设置字体名称
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FontName", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_59)]
		protected void FontName(object sender, WriterCommandEventArgs e)
		{
			int num = 8;
			e.EnableSetUITextAsParamter = true;
			if (e.Mode == WriterCommandEventMode.InitalizeUIElement)
			{
				IList list = WinFormUtils.smethod_8(e.UIElement);
				if (list == null || list.Count != 0)
				{
					return;
				}
				if (e.EditorControl != null && e.EditorControl.DocumentOptions.BehaviorOptions.WeakMode)
				{
					FontFamily[] families = FontFamily.Families;
					foreach (FontFamily fontFamily in families)
					{
						WinFormUtils.smethod_9(list, fontFamily.Name);
					}
				}
				else
				{
					try
					{
						FontFamily[] families = FontFamily.Families;
						foreach (FontFamily fontFamily in families)
						{
							WinFormUtils.smethod_9(list, fontFamily.Name);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			else if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.Document == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.Snapshot.CanModifySelection);
				if (e.Parameter == null)
				{
					e.Parameter = e.Document.CurrentStyleInfo.Content.FontName;
				}
				e.SetParameterToUIText = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				SetStyleProperty(sender, e, "FontName");
				e.RefreshLevel = UIStateRefreshLevel.Current;
				if (e.EditorControl != null)
				{
					e.EditorControl.Focus();
				}
			}
		}

		/// <summary>
		///       设置字体大小
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FontSize", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_60)]
		protected void FontSize(object sender, WriterCommandEventArgs e)
		{
			int num = 2;
			e.EnableSetUITextAsParamter = true;
			if (e.Mode == WriterCommandEventMode.InitalizeUIElement)
			{
				GClass288[] array = null;
				array = ((e.EditorControl != null && !e.EditorControl.DocumentOptions.BehaviorOptions.EnableChineseFontSizeName) ? GClass288.smethod_3() : GClass288.smethod_2());
				IList list = WinFormUtils.smethod_8(e.UIElement);
				if (list == null || list.Count != 0)
				{
					return;
				}
				if (e.EditorControl != null && e.EditorControl.DocumentOptions.BehaviorOptions.WeakMode)
				{
					GClass288[] array2 = array;
					foreach (GClass288 gClass in array2)
					{
						WinFormUtils.smethod_9(list, gClass.Name);
					}
				}
				else
				{
					try
					{
						GClass288[] array2 = array;
						foreach (GClass288 gClass in array2)
						{
							WinFormUtils.smethod_9(list, gClass.Name);
						}
					}
					catch (Exception)
					{
					}
				}
			}
			else if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.Document == null)
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.Snapshot.CanModifySelection);
				if (e.Parameter == null)
				{
					e.Parameter = GClass288.smethod_0(GetCurrentStyle(e.Document).FontSize, e.EditorControl.DocumentOptions.BehaviorOptions.EnableChineseFontSizeName);
				}
				e.SetParameterToUIText = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				SetStyleProperty(sender, e, "FontSize");
				if (e.EditorControl != null)
				{
					e.EditorControl.Focus();
				}
			}
		}

		/// <summary>
		///       设置字体样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Font", ImageResource = "DCSoft.Writer.Commands.Images.CommandFont.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_59)]
		protected void Font(object sender, WriterCommandEventArgs e)
		{
			int num = 7;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.Snapshot.CanModifySelection);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				DocumentContentStyle currentStyle = GetCurrentStyle(e.Document);
				XFontValue xFontValue = new XFontValue();
				if (e.Parameter == null)
				{
					xFontValue = currentStyle.Font;
				}
				else if (!(e.Parameter is string))
				{
					xFontValue = ((e.Parameter is XFontValue) ? ((XFontValue)e.Parameter).Clone() : ((!(e.Parameter is Font)) ? currentStyle.Font : new XFontValue((Font)e.Parameter)));
				}
				else
				{
					xFontValue = currentStyle.Font.Clone();
					xFontValue.method_6((string)e.Parameter);
				}
				if (e.ShowUI)
				{
					using (FontDialog fontDialog = new FontDialog())
					{
						fontDialog.Font = xFontValue.Value;
						if (fontDialog.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
						xFontValue = new XFontValue(fontDialog.Font);
					}
				}
				e.Parameter = xFontValue;
				SetStyleProperty(sender, e, "Font");
			}
		}

		/// <summary>
		///       设置下划线样式
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("Underline", ShortcutKey = (Keys)131157, ImageResource = "DCSoft.Writer.Commands.Images.CommandUnderline.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_61)]
		protected void Underline(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "Underline");
		}

		/// <summary>
		///       设置下划线样式
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("UnderlineStyle", ImageResource = "DCSoft.Writer.Commands.Images.CommandUnderline.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_61)]
		protected void UnderlineStyle(object sender, WriterCommandEventArgs e)
		{
			int num = 13;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				SetStyleProperty(sender, e, "UnderlineStyle");
				return;
			}
			DocumentContentStyle currentStyle = GetCurrentStyle(e.Document);
			TextUnderlineStyle textUnderlineStyle = TextUnderlineStyle.Single;
			Color color = currentStyle.Color;
			if (e.Parameter is TextUnderlineStyle)
			{
				textUnderlineStyle = (TextUnderlineStyle)e.Parameter;
			}
			else if (e.Parameter is string)
			{
				string text = (string)e.Parameter;
				int num2 = text.IndexOf(";");
				if (num2 > 0)
				{
					string object_ = text.Substring(0, num2).Trim();
					textUnderlineStyle = (TextUnderlineStyle)WriterUtils.smethod_39(object_, textUnderlineStyle);
					color = ConvertToColor(text.Substring(num2 + 1), color);
				}
				else
				{
					textUnderlineStyle = (TextUnderlineStyle)WriterUtils.smethod_39(text, textUnderlineStyle);
				}
				if (e.ShowUI)
				{
					using (dlgTextUnderlineStyle dlgTextUnderlineStyle = new dlgTextUnderlineStyle())
					{
						dlgTextUnderlineStyle.SelectedColor = color;
						dlgTextUnderlineStyle.SelectedStyle = textUnderlineStyle;
						dlgTextUnderlineStyle.DefaultColor = currentStyle.Color;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgTextUnderlineStyle, null) != DialogResult.OK)
						{
							return;
						}
						color = dlgTextUnderlineStyle.SelectedColor;
						textUnderlineStyle = dlgTextUnderlineStyle.SelectedStyle;
					}
				}
				if (color == currentStyle.Color)
				{
					e.Parameter = new object[2]
					{
						textUnderlineStyle,
						null
					};
				}
				else
				{
					e.Parameter = new object[2]
					{
						textUnderlineStyle,
						XMLSerializeHelper.ColorToString(color)
					};
				}
				SetStyleProperty(sender, e, "UnderlineStyle");
			}
		}

		/// <summary>
		///       设置斜体模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Italic", ShortcutKey = (Keys)131145, ImageResource = "DCSoft.Writer.Commands.Images.CommandItalic.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_61)]
		protected void Italic(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "Italic");
		}

		/// <summary>
		///       设置或取消粗体样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Bold", ShortcutKey = (Keys)131138, ImageResource = "DCSoft.Writer.Commands.Images.CommandBold.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_61)]
		protected void Bold(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "Bold");
		}

		/// <summary>
		///       设置或取消着重号样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("EmphasisMark", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_65)]
		protected void EmphasisMark(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "EmphasisMark");
		}

		/// <summary>
		///       设置或取消粗体样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FixedSpacing", ReturnValueType = typeof(bool))]
		protected void FixedSpacing(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "FixedSpacing");
		}

		/// <summary>
		///       段落左对齐
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AlignLeft", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignLeft.bmp", ReturnValueType = typeof(bool))]
		protected void AlignLeft(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "AlignLeft");
		}

		/// <summary>
		///       段落左对齐
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AlignCenter", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignCenter.bmp", ReturnValueType = typeof(bool))]
		protected void AlignCenter(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "AlignCenter");
		}

		/// <summary>
		///       段落左对齐
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AlignDistribute", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignDistribute.bmp", ReturnValueType = typeof(bool))]
		protected void AlignDistribute(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "AlignDistribute");
		}

		/// <summary>
		///       段落左对齐
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AlignRight", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignRight.bmp", ReturnValueType = typeof(bool))]
		protected void AlignRight(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "AlignRight");
		}

		/// <summary>
		///       段落左对齐
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("AlignJustify", ImageResource = "DCSoft.Writer.Commands.Images.CommandAlignJustify.bmp", ReturnValueType = typeof(bool))]
		protected void AlignJustify(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "AlignJustify");
		}

		/// <summary>
		///       设置段落的左边框
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BorderLeft", ImageResource = "DCSoft.Writer.Commands.Images.CommandBorderLeft.bmp", ReturnValueType = typeof(bool))]
		protected void BorderLeft(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "BorderLeft");
		}

		/// <summary>
		///       段落左对齐
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BorderTop", ImageResource = "DCSoft.Writer.Commands.Images.CommandBorderTop.bmp", ReturnValueType = typeof(bool))]
		protected void BorderTop(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "BorderTop");
		}

		/// <summary>
		///       段落左对齐
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BorderRight", ImageResource = "DCSoft.Writer.Commands.Images.CommandBorderRight.bmp", ReturnValueType = typeof(bool))]
		protected void BorderRight(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "BorderRight");
		}

		/// <summary>
		///       段落左对齐
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BorderBottom", ImageResource = "DCSoft.Writer.Commands.Images.CommandBorderBottom.bmp", ReturnValueType = typeof(bool))]
		protected void BorderBottom(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "BorderBottom");
		}

		/// <summary>
		///       设置/取消删除线样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Strikeout", ReturnValueType = typeof(bool))]
		protected void Strikeout(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "Strikeout");
		}

		/// <summary>
		///       获得EventListenerNameSmart命令操作的文档元素列表
		///       </summary>
		/// <param name="document">
		/// </param>
		/// <param name="controler">
		/// </param>
		/// <returns>
		/// </returns>
		private XTextElementList GetElementsForSmartEventListenerName(XTextDocument document, DocumentControler controler)
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (document.Content.Selection.Length != 0)
			{
				foreach (XTextElement contentElement in document.Content.Selection.ContentElements)
				{
					if (contentElement is XTextObjectElement)
					{
						xTextElementList.Add(contentElement);
					}
					else if (contentElement is XTextContainerElement)
					{
						xTextElementList.Add(contentElement);
					}
					else if (contentElement is XTextFieldBorderElement)
					{
						XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)contentElement.Parent;
						if (!xTextElementList.Contains(xTextFieldElementBase))
						{
							xTextElementList.Add(xTextFieldElementBase);
						}
					}
				}
				if (document.Content.Selection.Cells != null && document.Content.Selection.Cells.Count > 0)
				{
					foreach (XTextTableCellElement cell in document.Content.Selection.Cells)
					{
						if (!cell.IsOverrided && !xTextElementList.Contains(cell))
						{
							xTextElementList.Add(cell);
						}
					}
				}
			}
			if (xTextElementList.Count == 0)
			{
				XTextContainerElement container = null;
				int elementIndex = 0;
				document.Content.GetCurrentPositionInfo(out container, out elementIndex);
				if (container != null)
				{
					xTextElementList.Add(container);
				}
			}
			for (int num = xTextElementList.Count - 1; num >= 0; num--)
			{
				if (!controler.CanModify(xTextElementList[num]))
				{
					xTextElementList.RemoveAt(num);
				}
			}
			return xTextElementList;
		}

		/// <summary>
		///       智能的设置元素的事件监听器的名称
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SmartSetEventTemplateName", ImageResource = "DCSoft.Writer.Commands.Images.CommandEventListenerName.bmp", ReturnValueType = typeof(bool))]
		protected void SmartSetEventTemplateName(object sender, WriterCommandEventArgs e)
		{
			int num = 11;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.DocumentControler != null && e.Document != null)
				{
					XTextElementList elementsForSmartEventListenerName = GetElementsForSmartEventListenerName(e.Document, e.DocumentControler);
					if (elementsForSmartEventListenerName.Count > 0)
					{
						e.Enabled = true;
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
				XTextElementList elementsForSmartEventListenerName = GetElementsForSmartEventListenerName(e.Document, e.DocumentControler);
				if (elementsForSmartEventListenerName.Count == 0)
				{
					return;
				}
				string text = null;
				if (e.Parameter is string && !string.IsNullOrEmpty((string)e.Parameter))
				{
					text = (string)e.Parameter;
				}
				else
				{
					foreach (XTextElement item in elementsForSmartEventListenerName)
					{
						if (item is XTextObjectElement)
						{
							text = ((XTextObjectElement)item).EventTemplateName;
						}
						else if (item is XTextContainerElement)
						{
							text = ((XTextContainerElement)item).EventTemplateName;
						}
						if (!string.IsNullOrEmpty(text))
						{
							break;
						}
					}
				}
				if (e.ShowUI)
				{
					using (dlgStringList dlgStringList = new dlgStringList())
					{
						dlgStringList.Text = WriterStrings.SelectEventListener;
						if (e.EditorControl != null)
						{
							dlgStringList.Text = e.EditorControl.DialogTitlePrefix + dlgStringList.Text;
						}
						foreach (ElementEventTemplate eventTemplate in e.EditorControl.EventTemplates)
						{
							dlgStringList.ListItems.Add(eventTemplate.Name);
						}
						dlgStringList.SelectedText = text;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgStringList, null) != DialogResult.OK)
						{
							return;
						}
						text = dlgStringList.SelectedText;
					}
				}
				e.Document.BeginLogUndo();
				bool flag = false;
				foreach (XTextElement item2 in elementsForSmartEventListenerName)
				{
					if (item2 is XTextObjectElement)
					{
						XTextObjectElement xTextObjectElement = (XTextObjectElement)item2;
						if (xTextObjectElement.EventTemplateName != text)
						{
							e.Document.UndoList.AddProperty("EventTemplateName", xTextObjectElement.EventTemplateName, text, xTextObjectElement);
						}
						xTextObjectElement.EventTemplateName = text;
						flag = true;
					}
					else if (item2 is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement = (XTextContainerElement)item2;
						if (xTextContainerElement.EventTemplateName != text)
						{
							e.Document.UndoList.AddProperty("EventTemplateName", xTextContainerElement.EventTemplateName, text, xTextContainerElement);
						}
						xTextContainerElement.EventTemplateName = text;
						flag = true;
					}
				}
				e.Document.EndLogUndo();
				e.Result = flag;
				if (flag)
				{
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
					e.RefreshLevel = UIStateRefreshLevel.Current;
					if (e.EditorControl != null)
					{
						e.EditorControl.Focus();
					}
				}
			}
		}

		/// <summary>
		///       设置内边距
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Padding", ImageResource = "DCSoft.Writer.Commands.Images.CommandPadding.bmp", ReturnValueType = typeof(bool))]
		protected void Padding(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				XTextElementList paddingableElement = GetPaddingableElement(e.Document);
				e.Enabled = (paddingableElement != null && paddingableElement.Count > 0);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				XTextElementList paddingableElement2 = GetPaddingableElement(e.Document);
				if (paddingableElement2 == null || paddingableElement2.Count == 0)
				{
					return;
				}
				bool flag = false;
				XPaddingF xPaddingF = null;
				if (e.Parameter is XPaddingF)
				{
					xPaddingF = (XPaddingF)e.Parameter;
					flag = true;
				}
				else if (e.Parameter is string)
				{
					xPaddingF = new XPaddingF();
					if (XPaddingF.Parse((string)e.Parameter, xPaddingF))
					{
						flag = true;
					}
				}
				if (!flag)
				{
					DocumentContentStyle parent = paddingableElement2[0].RuntimeStyle.Parent;
					xPaddingF = new XPaddingF(parent.PaddingLeft, parent.PaddingTop, parent.PaddingRight, parent.PaddingBottom);
				}
				if (e.ShowUI)
				{
					using (dlgPadding dlgPadding = new dlgPadding())
					{
						dlgPadding.XPaddingValue = xPaddingF;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgPadding, paddingableElement2[0]) == DialogResult.OK)
						{
							flag = true;
						}
					}
				}
				if (flag && xPaddingF != null)
				{
					DocumentContentStyle documentContentStyle = new DocumentContentStyle();
					documentContentStyle.DisableDefaultValue = true;
					documentContentStyle.PaddingLeft = xPaddingF.Left;
					documentContentStyle.PaddingTop = xPaddingF.Top;
					documentContentStyle.PaddingRight = xPaddingF.Right;
					documentContentStyle.PaddingBottom = xPaddingF.Bottom;
					e.Document.BeginLogUndo();
					e.Result = XTextSelection.smethod_0(documentContentStyle, documentContentStyle, documentContentStyle, e.Document, paddingableElement2, bool_1: true, e.Name, bool_2: true);
					e.Document.EndLogUndo();
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
				}
			}
		}

		/// <summary>
		///       获得文档中可以设置内边距的元素对象
		///       </summary>
		/// <param name="document">文档对象</param>
		/// <returns>元素对象列表</returns>
		private XTextElementList GetPaddingableElement(XTextDocument document)
		{
			if (document == null)
			{
				return null;
			}
			XTextElementList xTextElementList;
			if (document.Selection != null && document.Selection.Length != 0)
			{
				xTextElementList = new XTextElementList();
				foreach (XTextElement contentElement in document.Selection.ContentElements)
				{
					if ((contentElement is XTextObjectElement || contentElement is XTextShapeInputFieldElement) && document.DocumentControler.CanModify(contentElement))
					{
						xTextElementList.Add(contentElement);
					}
				}
				if (document.Selection.Cells != null)
				{
					foreach (XTextTableCellElement cell in document.Selection.Cells)
					{
						if (!cell.IsOverrided && document.DocumentControler.CanModify(cell))
						{
							xTextElementList.Add(cell);
						}
					}
				}
				return xTextElementList;
			}
			XTextContainerElement container = null;
			int elementIndex = 0;
			document.Content.GetCurrentPositionInfo(out container, out elementIndex);
			while (true)
			{
				if (container != null)
				{
					if (container is XTextShapeInputFieldElement || container is XTextTableCellElement)
					{
						break;
					}
					container = container.Parent;
					continue;
				}
				return null;
			}
			xTextElementList = new XTextElementList();
			xTextElementList.Add(container);
			return xTextElementList;
		}

		/// <summary>
		///       设置段落的数字列表样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("NumberedList", ImageResource = "DCSoft.Writer.Commands.Images.CommandNumberedList.bmp", ReturnValueType = typeof(bool))]
		protected void NumberedList(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "NumberedList");
		}

		/// <summary>
		///       设置段落的原点列表样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("BulletedList", ImageResource = "DCSoft.Writer.Commands.Images.CommandBulletedList.bmp", ReturnValueType = typeof(bool))]
		protected void BulletedList(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "BulletedList");
		}

		/// <summary>
		///       设置段落的数字列表样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ParagraphListStyle", ReturnValueType = typeof(bool))]
		protected void ParagraphListStyle(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "ParagraphListStyle");
		}

		/// <summary>
		///       特殊的段落首行缩进
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("IncreaseFirstLineIndent", ImageResource = "DCSoft.Writer.Commands.Images.CommandFirstLineIndent.bmp", ReturnValueType = typeof(bool))]
		protected void IncreaseFirstLineIndent(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "IncreaseFirstLineIndent");
		}

		/// <summary>
		///       段落首行缩进
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FirstLineIndent", ImageResource = "DCSoft.Writer.Commands.Images.CommandFirstLineIndent.bmp", ReturnValueType = typeof(bool))]
		protected void FirstLineIndent(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "FirstLineIndent");
		}

		/// <summary>
		///       下标样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Subscript", ImageResource = "DCSoft.Writer.Commands.Images.CommandSubscript.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_64)]
		protected void Subscript(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "Subscript");
		}

		/// <summary>
		///       上标样式
		///        </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Superscript", ImageResource = "DCSoft.Writer.Commands.Images.CommandSuperscript.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_64)]
		protected void Superscript(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "Superscript");
		}

		/// <summary>
		///       文字四周布局
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("TextSurroundings", ImageResource = "DCSoft.Writer.Commands.Images.CommandTextSurroundings.bmp", ReturnValueType = typeof(bool))]
		protected void TextSurroundings(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "TextSurroundings");
		}

		/// <summary>
		///       嵌入在文字中
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("EmbedInText", ImageResource = "DCSoft.Writer.Commands.Images.CommandEmbedInText.bmp", ReturnValueType = typeof(bool))]
		protected void EmbedInText(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "EmbedInText");
		}

		/// <summary>
		///       文字套圈
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("CharacterCircle", ImageResource = "DCSoft.Writer.Commands.Images.CommandCharacterCircle.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_66)]
		protected void CharacterCircle(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "CharacterCircle");
		}

		/// <summary>
		///       设置标题层次
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("TitleLevel", ImageResource = "DCSoft.Writer.Commands.Images.CommandTitleLevel.bmp", ReturnValueType = typeof(bool))]
		protected void TitleLevel(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "TitleLevel");
		}

		/// <summary>
		///       设置标题层次
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Visibility", ReturnValueType = typeof(bool))]
		protected void Visibility(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "Visibility");
		}

		/// <summary>
		///       设置字符间距
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("LetterSpacing", ReturnValueType = typeof(bool))]
		protected void LetterSpacing(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "LetterSpacing");
		}

		/// <summary>
		///       设置内容保护
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ContentProtect", ImageResource = "DCSoft.Writer.Commands.Images.CommandContentProtect.bmp", ReturnValueType = typeof(bool))]
		protected void ContentProtect(object sender, WriterCommandEventArgs e)
		{
			SetStyleProperty(sender, e, "ContentProtect");
		}

		/// <summary>
		///       插入文档注释
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertComment", ReturnValueType = typeof(bool), ImageResource = "DCSoft.Writer.Commands.Images.CommandInsertComment.bmp")]
		protected void InsertComment(object sender, WriterCommandEventArgs e)
		{
			int num = 0;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl == null || (e.EditorControl.RuntimeReadonly && !e.EditorControl.CommentEditableWhenReadonly))
				{
					return;
				}
				if (!e.EditorControl.DocumentOptions.BehaviorOptions.InsertCommentBindingUserTrack)
				{
					if (e.Document.Selection.Length != 0)
					{
						e.Enabled = true;
					}
					else if (e.Document.Content.Count > 1)
					{
						e.Enabled = true;
					}
				}
				else
				{
					GetCurrentStyle(e.Document);
					e.Enabled = (e.EditorControl != null && e.DocumentControler != null && e.DocumentControler.Snapshot.CanModifySelection);
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextSelection xTextSelection = e.Document.Selection;
				if (xTextSelection.Length == 0)
				{
					xTextSelection = ((xTextSelection.StartIndex != e.Document.Content.Count - 1) ? e.Document.CurrentContentElement.method_65(xTextSelection.StartIndex, 1) : e.Document.CurrentContentElement.method_65(xTextSelection.StartIndex - 1, 1));
				}
				e.Result = false;
				GetCurrentStyle(e.Document);
				DocumentContentStyle documentContentStyle = e.Document.CreateDocumentContentStyle();
				documentContentStyle.DisableDefaultValue = true;
				DocumentComment documentComment = null;
				if (e.Parameter is DocumentComment)
				{
					documentComment = (DocumentComment)e.Parameter;
				}
				else
				{
					documentComment = new DocumentComment();
					documentComment.Text = Convert.ToString(e.Parameter);
				}
				if (e.ShowUI)
				{
					using (dlgDocumentComment dlgDocumentComment = new dlgDocumentComment())
					{
						dlgDocumentComment.CommentText = documentComment.Text;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgDocumentComment, null) != DialogResult.OK)
						{
							return;
						}
						documentComment.Text = dlgDocumentComment.CommentText;
					}
				}
				if (!(e.Parameter is DocumentComment))
				{
					CurrentUserInfo currentUserInfo = (CurrentUserInfo)e.Host.Services.GetService(typeof(CurrentUserInfo));
					if (currentUserInfo == null)
					{
						documentComment.Author = Environment.UserName;
					}
					else
					{
						documentComment.Author = currentUserInfo.Name;
						documentComment.AuthorID = currentUserInfo.ID;
					}
					documentComment.CreationTime = e.Document.GetNowDateTime();
					documentComment.Index = e.Document.AllocObjectID();
					documentComment.BindingUserTrack = e.Document.Options.BehaviorOptions.InsertCommentBindingUserTrack;
					if (e.Document.Options.SecurityOptions.EnablePermission && e.Document.UserHistories.CurrentInfo != null)
					{
						documentComment.CreatorIndex = e.Document.UserHistories.CurrentIndex;
						documentComment.Author = e.Document.UserHistories.CurrentInfo.Name;
						documentComment.method_1(e.Document);
					}
				}
				if (e.EditorControl != null)
				{
					try
					{
						DocumentComment documentComment2 = (DocumentComment)e.EditorControl.vmethod_43(typeof(DocumentComment), documentComment, e.Name);
						if (documentComment2 == null)
						{
							return;
						}
						documentComment = documentComment2;
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.Message);
						if (documentComment == null)
						{
							documentComment = new DocumentComment();
						}
					}
				}
				documentComment.Index = e.Document.AllocObjectID();
				DocumentCommentList documentCommentList = e.Document.Comments.Clone(deeply: false);
				documentCommentList.Add(documentComment);
				e.Document.BeginLogUndo();
				if (e.Document.CanLogUndo)
				{
					e.Document.UndoList.AddProperty("Comments", e.Document.Comments, documentCommentList, e.Document);
				}
				e.Document.Comments = documentCommentList;
				documentContentStyle.CommentIndex = documentComment.Index;
				bool flag = false;
				flag = ((e.EditorControl.CommentVisibility != FunctionControlVisibility.Hide) ? true : false);
				if (e.UIStartEditContent())
				{
					XDependencyObject.smethod_7(documentContentStyle, e.Document.CurrentStyleInfo.Content, bool_3: true);
					XDependencyObject.smethod_7(documentContentStyle, e.Document.CurrentStyleInfo.ContentStyleForNewString, bool_3: true);
					e.Result = xTextSelection.SetElementStyle(documentContentStyle, flag, includeCells: false, e.Name);
					if (flag)
					{
						e.EditorControl.RefreshDocument();
						e.Document.UndoList.AddMethod(UndoMethodTypes.RefreshPages);
					}
					e.Document.EndLogUndo();
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
				}
			}
		}

		internal static DocumentContentStyle GetCurrentStyle(XTextDocument document)
		{
			return document?.CurrentStyleInfo.Content;
		}

		private void SetStyleProperty(object sender, WriterCommandEventArgs args, string commandName)
		{
			int num = 14;
			if (args.Mode == WriterCommandEventMode.QueryState)
			{
				args.Enabled = false;
				if (args.EditorControl == null)
				{
					return;
				}
				if (commandName == "InsertComment")
				{
					if (args.EditorControl.RuntimeReadonly && !args.EditorControl.CommentEditableWhenReadonly)
					{
						return;
					}
					if (!args.EditorControl.DocumentOptions.BehaviorOptions.InsertCommentBindingUserTrack)
					{
						if (args.Document.Selection.Length != 0)
						{
							args.Enabled = true;
						}
						else if (args.Document.Selection.StartIndex < args.Document.Content.Count - 1)
						{
							args.Enabled = true;
						}
						return;
					}
				}
				DocumentContentStyle currentStyle = GetCurrentStyle(args.Document);
				args.Enabled = (args.EditorControl != null && args.DocumentControler != null && args.DocumentControler.Snapshot.CanModifySelection);
				if (!args.Enabled)
				{
					return;
				}
				switch (commandName)
				{
				case "InsertComment":
				case "LetterSpacing":
				case "UnderlineStyle":
					break;
				case "Visibility":
					args.Enabled = (args.DocumentControler != null && args.Document.Selection.Length != 0 && args.DocumentControler.Snapshot.CanModifySelection);
					break;
				case "ContentProtect":
					args.Enabled = (args.DocumentControler != null && args.DocumentControler.CanModifySelection(checkContentProtect: false));
					if (args.Enabled && args.Document.Selection.Length == 0)
					{
						args.Enabled = false;
					}
					if (args.Enabled)
					{
						args.Checked = (args.Document.InternalCurrentStyle.ProtectType != ContentProtectType.None);
					}
					break;
				case "TitleLevel":
					if (args.Enabled && args.Document.Selection.Length == 0)
					{
						args.Enabled = false;
					}
					break;
				case "TextSurroundings":
				{
					XTextElement singleSelectedElement = args.Document.SingleSelectedElement;
					args.Enabled = false;
					if (singleSelectedElement != null && args.DocumentControler.CanModify(singleSelectedElement) && (singleSelectedElement is XTextObjectElement || singleSelectedElement is XTextShapeInputFieldElement))
					{
						args.Enabled = true;
						args.Checked = (singleSelectedElement.RuntimeStyle.LayoutAlign == ContentLayoutAlign.Surroundings);
					}
					break;
				}
				case "EmbedInText":
				{
					XTextElement singleSelectedElement = args.Document.SingleSelectedElement;
					args.Enabled = false;
					if (singleSelectedElement != null && args.DocumentControler.CanModify(singleSelectedElement) && (singleSelectedElement is XTextObjectElement || singleSelectedElement is XTextShapeInputFieldElement))
					{
						args.Enabled = true;
						args.Checked = (singleSelectedElement.RuntimeStyle.LayoutAlign == ContentLayoutAlign.EmbedInText);
					}
					break;
				}
				case "CharacterCircle":
					args.Checked = (currentStyle.CharacterCircle != CharacterCircleStyles.None);
					break;
				case "Bold":
					args.Checked = currentStyle.Bold;
					break;
				case "EmphasisMark":
					args.Checked = currentStyle.EmphasisMark;
					break;
				case "FixedSpacing":
					args.Checked = currentStyle.FixedSpacing;
					break;
				case "BorderBottom":
					args.Checked = currentStyle.BorderBottom;
					break;
				case "BorderLeft":
					args.Checked = currentStyle.BorderLeft;
					break;
				case "BorderRight":
					args.Checked = currentStyle.BorderRight;
					break;
				case "BorderTop":
					args.Checked = currentStyle.BorderTop;
					break;
				case "Italic":
					args.Checked = currentStyle.Italic;
					break;
				case "Strikeout":
					args.Checked = currentStyle.Strikeout;
					break;
				case "Subscript":
					args.Checked = currentStyle.Subscript;
					break;
				case "Superscript":
					args.Checked = currentStyle.Superscript;
					break;
				case "Underline":
					args.Checked = currentStyle.Underline;
					break;
				default:
					args.Enabled = false;
					break;
				}
			}
			else
			{
				if (args.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				XTextSelection xTextSelection = args.Document.Selection;
				args.Result = false;
				DocumentContentStyle currentStyle2 = GetCurrentStyle(args.Document);
				DocumentContentStyle documentContentStyle = args.Document.CreateDocumentContentStyle();
				documentContentStyle.DisableDefaultValue = true;
				bool flag = true;
				bool includeCells = false;
				switch (commandName)
				{
				case "InsertComment":
				{
					if (xTextSelection.Length == 0)
					{
						xTextSelection = args.Document.CurrentContentElement.method_65(xTextSelection.StartIndex, 1);
					}
					DocumentComment documentComment = null;
					if (args.Parameter is DocumentComment)
					{
						documentComment = (DocumentComment)args.Parameter;
					}
					else
					{
						documentComment = new DocumentComment();
						documentComment.Text = Convert.ToString(args.Parameter);
					}
					if (args.ShowUI)
					{
						using (dlgDocumentComment dlgDocumentComment = new dlgDocumentComment())
						{
							dlgDocumentComment.CommentText = documentComment.Text;
							if (WriterControl.UIShowDialog(args.EditorControl, dlgDocumentComment, null) != DialogResult.OK)
							{
								return;
							}
							documentComment.Text = dlgDocumentComment.CommentText;
						}
					}
					if (!(args.Parameter is DocumentComment))
					{
						CurrentUserInfo currentUserInfo = (CurrentUserInfo)args.Host.Services.GetService(typeof(CurrentUserInfo));
						if (currentUserInfo == null)
						{
							documentComment.Author = Environment.UserName;
						}
						else
						{
							documentComment.Author = currentUserInfo.Name;
							documentComment.AuthorID = currentUserInfo.ID;
						}
						documentComment.CreationTime = args.Document.GetNowDateTime();
						documentComment.Index = args.Document.AllocObjectID();
						documentComment.BindingUserTrack = args.Document.Options.BehaviorOptions.InsertCommentBindingUserTrack;
						if (args.Document.Options.SecurityOptions.EnablePermission && args.Document.UserHistories.CurrentInfo != null)
						{
							documentComment.CreatorIndex = args.Document.UserHistories.CurrentIndex;
							documentComment.Author = args.Document.UserHistories.CurrentInfo.Name;
							documentComment.method_1(args.Document);
						}
					}
					if (args.EditorControl != null)
					{
						documentComment = (DocumentComment)args.EditorControl.vmethod_43(typeof(DocumentComment), documentComment, args.Name);
						if (documentComment == null)
						{
							break;
						}
					}
					documentComment.Index = args.Document.AllocObjectID();
					DocumentCommentList documentCommentList = args.Document.Comments.Clone(deeply: false);
					documentCommentList.Add(documentComment);
					if (args.Document.CanLogUndo)
					{
						args.Document.UndoList.AddProperty("Comments", args.Document.Comments, documentCommentList, args.Document);
					}
					args.Document.Comments = documentCommentList;
					documentContentStyle.CommentIndex = documentComment.Index;
					flag = ((args.EditorControl.CommentVisibility != FunctionControlVisibility.Hide) ? true : false);
					goto IL_12b2;
				}
				case "ContentProtect":
				{
					ContentProtectType contentProtectType = args.Document.InternalCurrentStyle.ProtectType;
					if (args.Parameter is ContentProtectType)
					{
						contentProtectType = (ContentProtectType)args.Parameter;
					}
					else if (args.Parameter is string)
					{
						contentProtectType = (ContentProtectType)WriterUtils.smethod_39(args.Parameter, contentProtectType);
					}
					else if (args.Parameter is bool)
					{
						contentProtectType = (((bool)args.Parameter) ? ContentProtectType.Range : ContentProtectType.None);
					}
					if (args.ShowUI)
					{
						using (dlgContentProtectedMode dlgContentProtectedMode = new dlgContentProtectedMode())
						{
							dlgContentProtectedMode.ContentProtectType = contentProtectType;
							if (WriterControl.UIShowDialog(args.EditorControl, dlgContentProtectedMode, null) != DialogResult.OK)
							{
								return;
							}
							contentProtectType = dlgContentProtectedMode.ContentProtectType;
						}
					}
					documentContentStyle.ProtectType = contentProtectType;
					flag = false;
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_12b2;
				}
				case "Visibility":
				{
					includeCells = true;
					RenderVisibility renderVisibility = currentStyle2.Visibility;
					if (args.Parameter is string)
					{
						try
						{
							renderVisibility = (RenderVisibility)Enum.Parse(typeof(RenderVisibility), (string)args.Parameter);
						}
						catch (Exception ex)
						{
							Debug.WriteLine(ex.Message);
						}
					}
					else if (args.Parameter is RenderVisibility)
					{
						renderVisibility = (RenderVisibility)args.Parameter;
					}
					if (args.ShowUI)
					{
						using (dlgRenderVisibility dlgRenderVisibility = new dlgRenderVisibility())
						{
							dlgRenderVisibility.VisiblityValue = renderVisibility;
							if (WriterControl.UIShowDialog(args.EditorControl, dlgRenderVisibility, null) == DialogResult.Cancel)
							{
								return;
							}
							renderVisibility = dlgRenderVisibility.VisiblityValue;
						}
					}
					documentContentStyle.Visibility = renderVisibility;
					flag = false;
					goto IL_12b2;
				}
				case "TitleLevel":
				{
					int titleLevel = currentStyle2.TitleLevel;
					if (args.Parameter is int || args.Parameter is short || args.Parameter is long)
					{
						titleLevel = (int)args.Parameter;
					}
					if (args.ShowUI)
					{
						using (dlgTitleLevel dlgTitleLevel = new dlgTitleLevel())
						{
							dlgTitleLevel.TitleLevel = titleLevel;
							if (WriterControl.UIShowDialog(args.EditorControl, dlgTitleLevel, null) != DialogResult.OK)
							{
								return;
							}
							titleLevel = dlgTitleLevel.TitleLevel;
						}
					}
					documentContentStyle.TitleLevel = titleLevel;
					flag = false;
					goto IL_12b2;
				}
				case "TextSurroundings":
				{
					XTextElement singleSelectedElement = args.Document.SingleSelectedElement;
					ContentLayoutAlign contentLayoutAlign = ContentLayoutAlign.EmbedInText;
					contentLayoutAlign = (WriterUtils.smethod_41(args.Parameter, bool_2: true) ? ContentLayoutAlign.Surroundings : ContentLayoutAlign.EmbedInText);
					if (singleSelectedElement.RuntimeStyle.LayoutAlign != contentLayoutAlign)
					{
						documentContentStyle.LayoutAlign = contentLayoutAlign;
						flag = true;
						goto IL_12b2;
					}
					break;
				}
				case "EmbedInText":
				{
					XTextElement singleSelectedElement = args.Document.SingleSelectedElement;
					ContentLayoutAlign contentLayoutAlign = ContentLayoutAlign.EmbedInText;
					contentLayoutAlign = ((!WriterUtils.smethod_41(args.Parameter, bool_2: true)) ? ContentLayoutAlign.Surroundings : ContentLayoutAlign.EmbedInText);
					if (singleSelectedElement.RuntimeStyle.LayoutAlign != contentLayoutAlign)
					{
						documentContentStyle.LayoutAlign = contentLayoutAlign;
						flag = true;
						goto IL_12b2;
					}
					break;
				}
				case "CharacterCircle":
					documentContentStyle.CharacterCircle = (CharacterCircleStyles)WriterUtils.smethod_39(args.Parameter, (currentStyle2.CharacterCircle == CharacterCircleStyles.None) ? CharacterCircleStyles.Circle : CharacterCircleStyles.None);
					if (args.ShowUI)
					{
						using (dlgCharacterCircle dlgCharacterCircle = new dlgCharacterCircle())
						{
							dlgCharacterCircle.CircleStyle = currentStyle2.CharacterCircle;
							if (WriterControl.UIShowDialog(args.EditorControl, dlgCharacterCircle, null) != DialogResult.OK)
							{
								return;
							}
							documentContentStyle.CharacterCircle = dlgCharacterCircle.CircleStyle;
						}
					}
					flag = true;
					goto IL_12b2;
				case "Bold":
					documentContentStyle.Bold = WriterUtils.smethod_41(args.Parameter, !currentStyle2.Bold);
					flag = true;
					goto IL_12b2;
				case "EmphasisMark":
					documentContentStyle.EmphasisMark = WriterUtils.smethod_41(args.Parameter, !currentStyle2.EmphasisMark);
					flag = true;
					goto IL_12b2;
				case "FixedSpacing":
					documentContentStyle.FixedSpacing = WriterUtils.smethod_41(args.Parameter, !currentStyle2.FixedSpacing);
					flag = true;
					goto IL_12b2;
				case "BorderBottom":
					documentContentStyle.BorderBottom = WriterUtils.smethod_41(args.Parameter, !currentStyle2.BorderBottom);
					flag = false;
					goto IL_12b2;
				case "BorderLeft":
					documentContentStyle.BorderLeft = WriterUtils.smethod_41(args.Parameter, !currentStyle2.BorderLeft);
					flag = false;
					goto IL_12b2;
				case "BorderRight":
					documentContentStyle.BorderRight = WriterUtils.smethod_41(args.Parameter, !currentStyle2.BorderRight);
					goto IL_12b2;
				case "BorderTop":
					documentContentStyle.BorderTop = WriterUtils.smethod_41(args.Parameter, !currentStyle2.BorderTop);
					flag = false;
					goto IL_12b2;
				case "Italic":
					documentContentStyle.Italic = WriterUtils.smethod_41(args.Parameter, !currentStyle2.Italic);
					flag = true;
					goto IL_12b2;
				case "Strikeout":
					documentContentStyle.Strikeout = WriterUtils.smethod_41(args.Parameter, !currentStyle2.Strikeout);
					flag = false;
					goto IL_12b2;
				case "Subscript":
					documentContentStyle.Subscript = WriterUtils.smethod_41(args.Parameter, !currentStyle2.Subscript);
					documentContentStyle.Superscript = false;
					flag = true;
					goto IL_12b2;
				case "Superscript":
					documentContentStyle.Subscript = false;
					documentContentStyle.Superscript = WriterUtils.smethod_41(args.Parameter, !currentStyle2.Superscript);
					flag = true;
					goto IL_12b2;
				case "Underline":
					documentContentStyle.Underline = WriterUtils.smethod_41(args.Parameter, !currentStyle2.Underline);
					flag = false;
					goto IL_12b2;
				case "UnderlineStyle":
					if (args.Parameter is object[])
					{
						object[] array = (object[])args.Parameter;
						if (array.Length == 2)
						{
							if (array[0] is TextUnderlineStyle)
							{
								documentContentStyle.UnderlineStyle = (TextUnderlineStyle)array[0];
							}
							if (array[1] is string)
							{
								documentContentStyle.UnderlineColor = (string)array[1];
							}
						}
						if (documentContentStyle.UnderlineStyle == TextUnderlineStyle.None)
						{
							documentContentStyle.Underline = false;
						}
						else
						{
							documentContentStyle.Underline = true;
						}
					}
					flag = false;
					goto IL_12b2;
				case "Color":
					documentContentStyle.Color = ConvertToColor(args.Parameter, currentStyle2.Color);
					flag = false;
					goto IL_12b2;
				case "PrintColor":
					documentContentStyle.PrintColor = ConvertToColor(args.Parameter, currentStyle2.Color);
					flag = false;
					goto IL_12b2;
				case "BackColor":
					documentContentStyle.BackgroundColor = ConvertToColor(args.Parameter, currentStyle2.BackgroundColor);
					flag = false;
					goto IL_12b2;
				case "Font":
					if (args.Parameter is Font)
					{
						documentContentStyle.Font = new XFontValue((Font)args.Parameter);
					}
					else if (args.Parameter is XFontValue)
					{
						documentContentStyle.Font = ((XFontValue)args.Parameter).Clone();
					}
					flag = true;
					goto IL_12b2;
				case "FontName":
					if (args.Parameter is string)
					{
						documentContentStyle.FontName = (string)args.Parameter;
						args.Document.CurrentStyleInfo.Content.FontName = documentContentStyle.FontName;
					}
					flag = true;
					goto IL_12b2;
				case "FontSize":
					if (args.Parameter is string)
					{
						documentContentStyle.FontSize = GClass288.smethod_1((string)args.Parameter, args.Document.DefaultStyle.FontSize);
					}
					else if (args.Parameter is float || args.Parameter is double || args.Parameter is int)
					{
						documentContentStyle.FontSize = Convert.ToSingle(args.Parameter);
					}
					args.Document.CurrentStyleInfo.Content.FontSize = documentContentStyle.FontSize;
					flag = true;
					goto IL_12b2;
				case "LetterSpacing":
				{
					float num2 = WriterUtils.smethod_40(args.Parameter, (int)currentStyle2.LetterSpacing);
					if (args.ShowUI)
					{
						using (dlgLetterSpacing dlgLetterSpacing = new dlgLetterSpacing())
						{
							dlgLetterSpacing.InputUnit = args.Document.DocumentGraphicsUnit;
							dlgLetterSpacing.InputValue = num2;
							if (WriterControl.UIShowDialog(args.EditorControl, dlgLetterSpacing, null) != DialogResult.OK)
							{
								return;
							}
							num2 = dlgLetterSpacing.InputValue;
						}
					}
					if (num2 != documentContentStyle.LetterSpacing)
					{
						documentContentStyle.LetterSpacing = num2;
						args.Document.CurrentStyleInfo.Content.LetterSpacing = documentContentStyle.LetterSpacing;
						flag = true;
					}
					goto IL_12b2;
				}
				default:
					{
						throw new NotSupportedException(commandName);
					}
					IL_12b2:
					if (!args.UIStartEditContent())
					{
						break;
					}
					XDependencyObject.smethod_7(documentContentStyle, args.Document.CurrentStyleInfo.Content, bool_3: true);
					XDependencyObject.smethod_7(documentContentStyle, args.Document.CurrentStyleInfo.ContentStyleForNewString, bool_3: true);
					if (xTextSelection.Length == 0)
					{
						XTextContainerElement container = null;
						int elementIndex = 0;
						args.Document.Content.GetCurrentPositionInfo(out container, out elementIndex);
						if (container is XTextInputFieldElement && container.Elements.Count == 0 && elementIndex == 0)
						{
							xTextSelection = new XTextSelection(xTextSelection.DocumentContent);
							xTextSelection.ContentElements.Add(((XTextInputFieldElement)container).StartElement);
						}
					}
					args.Document.BeginLogUndo();
					args.Result = xTextSelection.SetElementStyle(documentContentStyle, flag, includeCells, args.Name);
					if (flag && commandName == "InsertComment")
					{
						args.EditorControl.RefreshDocument();
						args.Document.UndoList.AddMethod(UndoMethodTypes.RefreshPages);
					}
					args.Document.EndLogUndo();
					args.Document.OnSelectionChanged();
					args.Document.OnDocumentContentChanged();
					break;
				}
			}
		}

		/// <summary>
		///       删除所有的文档批注
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DeleteAllComment")]
		protected void DeleteAllComment(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && (!e.EditorControl.RuntimeReadonly || e.EditorControl.CommentEditableWhenReadonly))
				{
					e.Enabled = (e.Document.Comments.Count > 0);
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Parameter = e.Document.Comments;
				e.Result = Func_DeleteComments(e, validatePermission: false);
			}
		}

		private bool ValidateCommentUserID(DocumentComment documentComment_0, WriterCommandEventArgs args)
		{
			if (documentComment_0 == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(documentComment_0.AuthorID))
			{
				return true;
			}
			if (args.EditorControl.DocumentOptions.BehaviorOptions.ValidateUserIDWhenEditDeleteComment)
			{
				CurrentUserInfo currentUserInfo = (CurrentUserInfo)args.Host.Services.GetService(typeof(CurrentUserInfo));
				if (currentUserInfo == null || currentUserInfo.ID != documentComment_0.AuthorID)
				{
					if (args.ShowUI)
					{
						args.Host.UITools.ShowWarringMessageBox(args.EditorControl, string.Format(WriterStrings.PromptCannotEditComment_AuthorID, documentComment_0.AuthorID));
					}
					return false;
				}
			}
			return true;
		}

		/// <summary>
		///       不校验权限的删除文档批注
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DeleteCommentWithoutValidatePermission", ReturnValueType = typeof(bool), ImageResource = "DCSoft.Writer.Commands.Images.CommandDeleteComment.bmp")]
		protected void DeleteCommentWithoutValidatePermission(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && (!e.EditorControl.RuntimeReadonly || e.EditorControl.CommentEditableWhenReadonly))
				{
					e.Enabled = true;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = Func_DeleteComments(e, validatePermission: true);
			}
		}

		/// <summary>
		///       删除文档批注
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DeleteComment", ReturnValueType = typeof(bool), ImageResource = "DCSoft.Writer.Commands.Images.CommandDeleteComment.bmp")]
		protected void DeleteComment(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && (!e.EditorControl.RuntimeReadonly || e.EditorControl.CommentEditableWhenReadonly))
				{
					e.Enabled = true;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = Func_DeleteComments(e, validatePermission: true);
			}
		}

		/// <summary>
		///       删除若干个文档批注对象
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <param name="validatePermission">
		/// </param>
		/// <returns>
		/// </returns>
		private bool Func_DeleteComments(WriterCommandEventArgs args, bool validatePermission)
		{
			int num = 11;
			DocumentCommentList documentCommentList = null;
			if (args.Parameter is DocumentComment)
			{
				documentCommentList = new DocumentCommentList();
				documentCommentList.Add((DocumentComment)args.Parameter);
			}
			else if (args.Parameter is DocumentCommentList)
			{
				documentCommentList = (DocumentCommentList)args.Parameter;
				documentCommentList = documentCommentList.Clone(deeply: false);
			}
			if (documentCommentList == null && args.EditorControl.CommentManager.imethod_9() != null)
			{
				documentCommentList = new DocumentCommentList();
				documentCommentList.Add(args.EditorControl.CommentManager.imethod_9());
			}
			if (documentCommentList == null || documentCommentList.Count == 0)
			{
				return false;
			}
			if (validatePermission)
			{
				for (int num2 = documentCommentList.Count - 1; num2 >= 0; num2--)
				{
					DocumentComment documentComment = documentCommentList[num2];
					if (documentComment.BindingUserTrack && !args.EditorControl.IsAdministrator && args.Host.PermissionControler != null && !args.Host.PermissionControler.CanDelete(args.Document, documentComment.CreatorIndex, -1))
					{
						if (args.ShowUI)
						{
							args.Host.UITools.ShowWarringMessageBox(args.EditorControl, string.Format(WriterStrings.PromptCannotEditComment_AuthorID, documentComment.AuthorID));
						}
						documentCommentList.RemoveAt(num2);
					}
					else if (!ValidateCommentUserID(documentComment, args))
					{
						documentCommentList.RemoveAt(num2);
					}
				}
			}
			if (documentCommentList.Count == 0)
			{
				return false;
			}
			if (!args.UIStartEditContent())
			{
				return false;
			}
			DocumentCommentList comments = args.Document.Comments;
			DocumentCommentList documentCommentList2 = args.Document.Comments.Clone(deeply: false);
			foreach (DocumentComment item in documentCommentList)
			{
				documentCommentList2.Remove(item);
			}
			if (args.Document.BeginLogUndo())
			{
				args.Document.UndoList.AddProperty("Comments", args.Document.Comments, documentCommentList2, args.Document);
				if (documentCommentList2.Count == 0)
				{
					args.Document.UndoList.AddMethod(UndoMethodTypes.RefreshDocument);
				}
				else
				{
					args.Document.UndoList.AddMethod(UndoMethodTypes.RefreshComment);
				}
				args.Document.EndLogUndo();
			}
			args.Document.Comments = documentCommentList2;
			args.EditorControl.CommentManager.imethod_10(null);
			args.EditorControl.CommentManager.imethod_5(comments, documentCommentList2);
			if (documentCommentList2.Count == 0)
			{
				args.EditorControl.RefreshDocument();
			}
			else
			{
				args.EditorControl.CommentManager.imethod_2();
			}
			args.Document.Modified = true;
			args.Document.OnDocumentContentChanged();
			return true;
		}

		/// <summary>
		///       编辑文档批注
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("EditComment")]
		protected void EditComment(object sender, WriterCommandEventArgs e)
		{
			int num = 8;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && e.EditorControl != null && (!e.EditorControl.RuntimeReadonly || e.EditorControl.CommentEditableWhenReadonly))
				{
					e.Enabled = true;
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.EditorControl.RuntimeReadonly && !e.EditorControl.CommentEditableWhenReadonly)
				{
					return;
				}
				DocumentComment documentComment = e.EditorControl.CommentManager.imethod_9();
				if (documentComment == null)
				{
					return;
				}
				if (documentComment.BindingUserTrack && !e.EditorControl.IsAdministrator && e.Host.PermissionControler != null && !e.Host.PermissionControler.CanModify(e.Document, documentComment.CreatorIndex, -1))
				{
					if (e.ShowUI)
					{
						e.Host.UITools.ShowWarringMessageBox(e.EditorControl, string.Format(WriterStrings.PromptCannotEditComment_AuthorID, documentComment.AuthorID));
					}
				}
				else
				{
					if (!ValidateCommentUserID(documentComment, e) || !e.UIStartEditContent())
					{
						return;
					}
					string text = null;
					if (e.Parameter is string)
					{
						text = (string)e.Parameter;
					}
					if (e.ShowUI)
					{
						using (dlgDocumentComment dlgDocumentComment = new dlgDocumentComment())
						{
							if (string.IsNullOrEmpty(text))
							{
								dlgDocumentComment.CommentText = documentComment.Text;
							}
							else
							{
								dlgDocumentComment.CommentText = text;
							}
							dlgDocumentComment.CommentAuthor = documentComment.Author;
							if (WriterControl.UIShowDialog(e.EditorControl, dlgDocumentComment, null) != DialogResult.OK)
							{
								return;
							}
							text = dlgDocumentComment.CommentText;
						}
					}
					if (text != documentComment.Text)
					{
						if (e.Document.BeginLogUndo())
						{
							e.Document.UndoList.AddProperty("Text", documentComment.Text, text, documentComment);
							e.Document.UndoList.AddMethod(UndoMethodTypes.RefreshComment);
							e.Document.EndLogUndo();
						}
						documentComment.Text = text;
						e.EditorControl.CommentManager.imethod_4(documentComment.Index);
						e.EditorControl.CommentManager.imethod_2();
						e.Document.Modified = true;
						e.Document.OnDocumentContentChanged();
					}
				}
			}
		}

		/// <summary>
		///       内容排版方向
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("LayoutDirection")]
		protected void LayoutDirection(object sender, WriterCommandEventArgs e)
		{
			SetParagraphStyleProperty(sender, e, "LayoutDirection");
		}

		/// <summary>
		///       根据段落列表样式设置段落的缩进量
		///       </summary>
		/// <param name="ns">
		/// </param>
		/// <param name="document">
		/// </param>
		private static void SetParagraphIndentByListStyle(DocumentContentStyle documentContentStyle_0, XTextDocument document)
		{
			if (documentContentStyle_0.ParagraphListStyle == DCSoft.Drawing.ParagraphListStyle.None)
			{
				documentContentStyle_0.FirstLineIndent = 0f;
				documentContentStyle_0.LeftIndent = 0f;
				return;
			}
			DocumentContentStyle paragraph = document.CurrentStyleInfo.Paragraph;
			int num = 1;
			foreach (XTextParagraphFlagElement paragraphsEOF in document.Selection.ParagraphsEOFs)
			{
				num = Math.Max(num, paragraphsEOF.MaxListIndex);
			}
			using (DCGraphics dcgraphics_ = document.CreateDCGraphics())
			{
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)paragraph.Clone();
				documentContentStyle.ParagraphListStyle = documentContentStyle_0.ParagraphListStyle;
				SizeF sizeF = XTextParagraphListItemElement.smethod_0(documentContentStyle, dcgraphics_, num);
				if (sizeF.Width > 0f)
				{
					if (paragraph.FirstLineIndent < 0f)
					{
						documentContentStyle_0.LeftIndent = paragraph.LeftIndent + paragraph.FirstLineIndent;
					}
					else
					{
						documentContentStyle_0.LeftIndent = paragraph.LeftIndent;
					}
					documentContentStyle_0.LeftIndent += sizeF.Width;
					documentContentStyle_0.FirstLineIndent = 0f - sizeF.Width;
				}
			}
		}

		/// <summary>
		///       更新目录域
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("UpdateDirectoryField")]
		protected void UpdateDirectoryField(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextDirectoryFieldElement xTextDirectoryFieldElement = (XTextDirectoryFieldElement)e.Document.GetCurrentElement(typeof(XTextDirectoryFieldElement));
					if (xTextDirectoryFieldElement != null)
					{
						e.Enabled = true;
					}
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				((XTextDirectoryFieldElement)e.Document.GetCurrentElement(typeof(XTextDirectoryFieldElement)))?.method_35(bool_21: true);
			}
		}

		/// <summary>
		///       带参数的执行标题样式命令
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("HeaderFormat")]
		protected void HeaderFormat(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
				return;
			}
			HeaderFormatCommandParameter headerFormatCommandParameter = e.Parameter as HeaderFormatCommandParameter;
			if (headerFormatCommandParameter != null)
			{
				SetHeaderParagraphFormat(e, headerFormatCommandParameter);
			}
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header1")]
		protected void Header1(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader1();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header2")]
		protected void Header2(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader2();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header3")]
		protected void Header3(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader3();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header4")]
		protected void Header4(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader4();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header5")]
		protected void Header5(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader5();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header6")]
		protected void Header6(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader6();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header1WithMultiNumberlist")]
		protected void Header1WithMultiNumberlist(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader1WithMultiNumberlist();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header2WithMultiNumberlist")]
		protected void Header2WithMultiNumberlist(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader2WithMultiNumberlist();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header3WithMultiNumberlist")]
		protected void Header3WithMultiNumberlist(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader3WithMultiNumberlist();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header4WithMultiNumberlist")]
		protected void Header4WithMultiNumberlist(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader4WithMultiNumberlist();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header5WithMultiNumberlist")]
		protected void Header5WithMultiNumberlist(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader5WithMultiNumberlist();
			SetHeaderParagraphFormat(e, parameter);
		}

		/// <summary>
		///       设置标准的标题1样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Header6WithMultiNumberlist")]
		protected void Header6WithMultiNumberlist(object sender, WriterCommandEventArgs e)
		{
			HeaderFormatCommandParameter parameter = HeaderFormatCommandParameter.CreateHeader6WithMultiNumberlist();
			SetHeaderParagraphFormat(e, parameter);
		}

		private void SetHeaderParagraphFormat(WriterCommandEventArgs args, HeaderFormatCommandParameter parameter)
		{
			if (args.Mode == WriterCommandEventMode.QueryState)
			{
				args.Enabled = false;
				if (args.Document == null)
				{
					return;
				}
				DocumentContentStyle paragraph = args.Document.CurrentStyleInfo.Paragraph;
				args.Enabled = (args.DocumentControler != null && args.DocumentControler.Snapshot.CanModifyParagraphs);
				if (args.Enabled)
				{
					if (parameter.ParagraphMultiLevel)
					{
						args.Checked = (paragraph.ParagraphOutlineLevel == parameter.ParagraphOutlineLevel && paragraph.ParagraphMultiLevel);
					}
					else
					{
						args.Checked = (paragraph.ParagraphOutlineLevel == parameter.ParagraphOutlineLevel);
					}
				}
			}
			else if (args.Mode == WriterCommandEventMode.Invoke && args.UIStartEditContent())
			{
				DocumentContentStyle documentContentStyle = new DocumentContentStyle();
				documentContentStyle.DisableDefaultValue = true;
				documentContentStyle.ParagraphOutlineLevel = parameter.ParagraphOutlineLevel;
				documentContentStyle.ParagraphMultiLevel = parameter.ParagraphMultiLevel;
				documentContentStyle.LeftIndent = parameter.LeftIndent;
				documentContentStyle.FirstLineIndent = parameter.FirstLineIndent;
				documentContentStyle.ParagraphListStyle = parameter.ParagraphListStyle;
				documentContentStyle.LineSpacingStyle = parameter.LineSpacingStyle;
				documentContentStyle.LineSpacing = parameter.LineSpacing;
				documentContentStyle.FontSize = parameter.FontSize;
				documentContentStyle.VisibleInDirectory = parameter.VisibleInDirectory;
				if (!string.IsNullOrEmpty(parameter.FontName))
				{
					documentContentStyle.FontName = parameter.FontName;
				}
				documentContentStyle.FontStyle = parameter.FontStyle;
				DocumentContentStyle documentContentStyle2 = new DocumentContentStyle();
				documentContentStyle2.FontSize = parameter.FontSize;
				documentContentStyle2.FontStyle = parameter.FontStyle;
				if (!string.IsNullOrEmpty(parameter.FontName))
				{
					documentContentStyle2.FontName = parameter.FontName;
				}
				XTextContent content = args.Document.Content;
				XTextElementList xTextElementList = new XTextElementList();
				if (args.Document.Selection.Length == 0)
				{
					xTextElementList.Add(args.Document.CurrentParagraphEOF);
				}
				else
				{
					foreach (XTextElement contentElement in args.Document.Selection.ContentElements)
					{
						XTextParagraphFlagElement xTextParagraphFlagElement = content.method_41(contentElement);
						if (!xTextElementList.Contains(xTextParagraphFlagElement))
						{
							xTextElementList.Add(xTextParagraphFlagElement);
						}
					}
				}
				XTextElementList xTextElementList2 = new XTextElementList();
				foreach (XTextParagraphFlagElement item in xTextElementList)
				{
					XTextElement firstContentElement = item.FirstContentElement;
					int num = args.Document.Content.IndexOf(firstContentElement);
					int num2 = args.Document.Content.IndexOf(item);
					for (int i = num; i <= num2; i++)
					{
						xTextElementList2.AddRaw(content[i]);
					}
				}
				args.Document.BeginLogUndo();
				bool flag = XTextSelection.smethod_0(documentContentStyle2, documentContentStyle, null, args.Document, xTextElementList2, bool_1: true, args.Name, bool_2: true);
				if (args.Document.CanLogUndo)
				{
					args.Document.UndoList.AddMethod(UndoMethodTypes.RefreshParagraphTree);
				}
				args.Document.EndLogUndo();
				args.Document.Modified = true;
				args.Document.OnSelectionChanged();
				args.Document.OnDocumentContentChanged();
				args.RefreshLevel = UIStateRefreshLevel.All;
				args.Result = flag;
				args.EditorControl.vmethod_12();
			}
		}

		/// <summary>
		///       设置段落样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		/// <param name="commandName">
		/// </param>
		private void SetParagraphStyleProperty(object sender, WriterCommandEventArgs args, string commandName)
		{
			int num = 14;
			if (args.Mode == WriterCommandEventMode.QueryState)
			{
				if (args.EditorControl == null)
				{
					args.Enabled = false;
					return;
				}
				DocumentContentStyle paragraph = args.Document.CurrentStyleInfo.Paragraph;
				args.Enabled = (args.DocumentControler != null && args.DocumentControler.Snapshot.CanModifyParagraphs);
				switch (commandName)
				{
				case "LayoutDirection":
					break;
				case "AlignLeft":
					args.Checked = (paragraph.Align == DocumentContentAlignment.Left);
					break;
				case "AlignCenter":
					args.Checked = (paragraph.Align == DocumentContentAlignment.Center);
					break;
				case "AlignRight":
					args.Checked = (paragraph.Align == DocumentContentAlignment.Right);
					break;
				case "AlignJustify":
					args.Checked = (paragraph.Align == DocumentContentAlignment.Justify);
					break;
				case "AlignDistribute":
					args.Checked = (paragraph.Align == DocumentContentAlignment.Distribute);
					break;
				case "BorderBottom":
					args.Checked = paragraph.BorderBottom;
					break;
				case "BorderLeft":
					args.Checked = paragraph.BorderLeft;
					break;
				case "BorderRight":
					args.Checked = paragraph.BorderRight;
					break;
				case "BorderTop":
					args.Checked = paragraph.BorderTop;
					break;
				case "BulletedList":
					args.Checked = paragraph.IsBulletedList;
					break;
				case "NumberedList":
					args.Checked = paragraph.IsListNumberStyle;
					break;
				case "FirstLineIndent":
					args.Checked = (paragraph.FirstLineIndent > 1f);
					break;
				case "ParagraphListStyle":
					args.Enabled = true;
					break;
				case "IncreaseFirstLineIndent":
					args.Enabled = true;
					break;
				default:
					args.Enabled = false;
					break;
				}
			}
			else
			{
				if (args.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				args.Result = false;
				DocumentContentStyle paragraph2 = args.Document.CurrentStyleInfo.Paragraph;
				DocumentContentStyle documentContentStyle = args.Document.CreateDocumentContentStyle();
				documentContentStyle.DisableDefaultValue = true;
				switch (commandName)
				{
				case "AlignCenter":
					documentContentStyle.Align = DocumentContentAlignment.Center;
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				case "AlignJustify":
					documentContentStyle.Align = DocumentContentAlignment.Justify;
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				case "AlignLeft":
					documentContentStyle.Align = DocumentContentAlignment.Left;
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				case "AlignRight":
					documentContentStyle.Align = DocumentContentAlignment.Right;
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				case "AlignDistribute":
					documentContentStyle.Align = DocumentContentAlignment.Distribute;
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				case "BorderBottom":
					documentContentStyle.BorderBottom = WriterUtils.smethod_41(args.Parameter, !paragraph2.BorderBottom);
					goto IL_0875;
				case "BorderLeft":
					documentContentStyle.BorderLeft = WriterUtils.smethod_41(args.Parameter, !paragraph2.BorderLeft);
					goto IL_0875;
				case "BorderRight":
					documentContentStyle.BorderRight = WriterUtils.smethod_41(args.Parameter, !paragraph2.BorderRight);
					goto IL_0875;
				case "BorderTop":
					documentContentStyle.BorderTop = WriterUtils.smethod_41(args.Parameter, !paragraph2.BorderTop);
					goto IL_0875;
				case "LayoutDirection":
				{
					bool flag3 = false;
					ContentLayoutDirectionStyle contentLayoutDirectionStyle = (ContentLayoutDirectionStyle)WriterUtils.smethod_39(args.Parameter, paragraph2.LayoutDirection);
					if (args.ShowUI)
					{
						using (dlgLayoutDirection dlgLayoutDirection = new dlgLayoutDirection())
						{
							dlgLayoutDirection.LayoutDirection = contentLayoutDirectionStyle;
							if (WriterControl.UIShowDialog(args.EditorControl, dlgLayoutDirection, null) != DialogResult.OK)
							{
								return;
							}
							contentLayoutDirectionStyle = dlgLayoutDirection.LayoutDirection;
							flag3 = true;
						}
					}
					if (flag3)
					{
						documentContentStyle.LayoutDirection = contentLayoutDirectionStyle;
						switch (contentLayoutDirectionStyle)
						{
						case ContentLayoutDirectionStyle.LeftToRight:
							documentContentStyle.Align = DocumentContentAlignment.Left;
							break;
						case ContentLayoutDirectionStyle.RightToLeft:
							documentContentStyle.Align = DocumentContentAlignment.Right;
							break;
						}
						args.RefreshLevel = UIStateRefreshLevel.All;
						goto IL_0875;
					}
					break;
				}
				case "ParagraphListStyle":
				{
					bool flag3 = false;
					ParagraphListStyle paragraphListStyle = args.Document.CurrentStyleInfo.Paragraph.ParagraphListStyle;
					if (args.Parameter is ParagraphListStyle)
					{
						paragraphListStyle = (ParagraphListStyle)args.Parameter;
						flag3 = true;
					}
					else if (args.Parameter is string)
					{
						try
						{
							paragraphListStyle = (ParagraphListStyle)Enum.Parse(typeof(ParagraphListStyle), (string)args.Parameter);
							flag3 = true;
						}
						catch
						{
						}
					}
					if (args.ShowUI)
					{
						using (dlgParagraphListStyle dlgParagraphListStyle = new dlgParagraphListStyle())
						{
							dlgParagraphListStyle.SelectedListStyle = paragraphListStyle;
							if (WriterControl.UIShowDialog(args.EditorControl, dlgParagraphListStyle, null) != DialogResult.OK)
							{
								return;
							}
							paragraphListStyle = dlgParagraphListStyle.SelectedListStyle;
							flag3 = true;
						}
					}
					if (flag3)
					{
						documentContentStyle.ParagraphListStyle = paragraphListStyle;
						SetParagraphIndentByListStyle(documentContentStyle, args.Document);
						args.RefreshLevel = UIStateRefreshLevel.All;
						goto IL_0875;
					}
					break;
				}
				case "BulletedList":
				{
					bool flag2;
					if ((flag2 = WriterUtils.smethod_41(args.Parameter, !paragraph2.IsBulletedList)) != paragraph2.IsBulletedList)
					{
						if (flag2)
						{
							documentContentStyle.ParagraphListStyle = DCSoft.Drawing.ParagraphListStyle.BulletedList;
						}
						else
						{
							documentContentStyle.ParagraphListStyle = DCSoft.Drawing.ParagraphListStyle.None;
						}
					}
					SetParagraphIndentByListStyle(documentContentStyle, args.Document);
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				}
				case "NumberedList":
				{
					bool flag2;
					if ((flag2 = WriterUtils.smethod_41(args.Parameter, !paragraph2.IsListNumberStyle)) != paragraph2.IsListNumberStyle)
					{
						if (flag2)
						{
							documentContentStyle.ParagraphListStyle = DCSoft.Drawing.ParagraphListStyle.ListNumberStyle;
						}
						else
						{
							documentContentStyle.ParagraphListStyle = DCSoft.Drawing.ParagraphListStyle.None;
						}
					}
					SetParagraphIndentByListStyle(documentContentStyle, args.Document);
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				}
				case "FirstLineIndent":
				{
					bool flag = false;
					if (!WriterUtils.smethod_38(args.Parameter, ref flag))
					{
						flag = ((!(paragraph2.FirstLineIndent > 1f)) ? true : false);
					}
					if (flag)
					{
						documentContentStyle.FirstLineIndent = 100f;
						documentContentStyle.LeftIndent = 0f;
					}
					else
					{
						documentContentStyle.FirstLineIndent = 0f;
						documentContentStyle.LeftIndent = 0f;
					}
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				}
				case "IncreaseFirstLineIndent":
				{
					bool flag;
					if (flag = WriterUtils.smethod_41(args.Parameter, bool_2: true))
					{
						documentContentStyle.FirstLineIndent += 100f;
						if (documentContentStyle.FirstLineIndent > 180f)
						{
							documentContentStyle.LeftIndent += 100f;
						}
					}
					else
					{
						documentContentStyle.FirstLineIndent -= 100f;
						if (documentContentStyle.FirstLineIndent < 0f)
						{
							documentContentStyle.FirstLineIndent = 0f;
						}
						if (documentContentStyle.FirstLineIndent < 80f)
						{
							documentContentStyle.LeftIndent = 0f;
						}
					}
					args.RefreshLevel = UIStateRefreshLevel.All;
					goto IL_0875;
				}
				default:
					{
						throw new NotSupportedException(commandName);
					}
					IL_0875:
					if (args.UIStartEditContent())
					{
						args.Document.BeginLogUndo();
						XTextElementList xTextElementList = args.Document.Selection.SetParagraphStyle(documentContentStyle);
						args.Document.EndLogUndo();
						args.Document.OnSelectionChanged();
						args.Document.OnDocumentContentChanged();
						if (xTextElementList != null && xTextElementList.Count > 0)
						{
							args.Result = true;
						}
					}
					break;
				}
			}
		}
	}
}
