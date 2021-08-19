using DCSoft.Drawing;
using DCSoft.ShapeEditor;
using DCSoft.ShapeEditor.Dom;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Undo;
using DCSoft.Writer.Script;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑文档内容的功能模块
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[WriterCommandDescription("Edit")]
	internal class WriterCommandModuleEdit : WriterCommandModule
	{
		/// <summary>
		///       元素属性表达式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ElementPropertyExpressions", ReturnValueType = typeof(bool), DefaultResultValue = true)]
		protected void ElementPropertyExpressions(object sender, WriterCommandEventArgs e)
		{
			int num = 9;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				XTextElement xTextElement = null;
				if (e.Parameter is XTextElement)
				{
					xTextElement = (XTextElement)e.Parameter;
				}
				else if (e.Parameter is string)
				{
					xTextElement = e.Document.GetElementById((string)e.Parameter);
				}
				if (xTextElement == null)
				{
					xTextElement = e.Document.CurrentElement;
				}
				XTextElement xTextElement2 = null;
				if (xTextElement != null)
				{
					xTextElement2 = ((!(xTextElement is XTextObjectElement)) ? xTextElement.Parent : xTextElement);
				}
				if (xTextElement2 != null && e.UIStartEditContent())
				{
					using (dlgPropertyExpressionInfoList dlgPropertyExpressionInfoList = new dlgPropertyExpressionInfoList())
					{
						if (xTextElement2 is XTextObjectElement)
						{
							dlgPropertyExpressionInfoList.InputInfos = ((XTextObjectElement)xTextElement2).PropertyExpressions;
						}
						else if (xTextElement2 is XTextContainerElement)
						{
							dlgPropertyExpressionInfoList.InputInfos = ((XTextContainerElement)xTextElement2).PropertyExpressions;
						}
						dlgPropertyExpressionInfoList.InputOwner = xTextElement2;
						if (dlgPropertyExpressionInfoList.InputInfos == null)
						{
							dlgPropertyExpressionInfoList.InputInfos = new PropertyExpressionInfoList();
						}
						else
						{
							dlgPropertyExpressionInfoList.InputInfos = dlgPropertyExpressionInfoList.InputInfos.Clone();
						}
						dlgPropertyExpressionInfoList.Text = dlgPropertyExpressionInfoList.Text + "-" + xTextElement2.GetType().FullName;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgPropertyExpressionInfoList, xTextElement2) == DialogResult.OK && e.Document.BeginLogUndo())
						{
							if (xTextElement2 is XTextObjectElement)
							{
								XTextObjectElement xTextObjectElement = (XTextObjectElement)xTextElement2;
								e.Document.UndoList.AddProperty("PropertyExpressions", xTextObjectElement.PropertyExpressions, dlgPropertyExpressionInfoList.InputInfos, xTextObjectElement);
								e.Document.UndoList.AddMethod(UndoMethodTypes.UpdateExpressionExecuter);
								xTextObjectElement.PropertyExpressions = dlgPropertyExpressionInfoList.InputInfos;
							}
							else if (xTextElement2 is XTextContainerElement)
							{
								XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement2;
								e.Document.UndoList.AddProperty("PropertyExpressions", xTextContainerElement.PropertyExpressions, dlgPropertyExpressionInfoList.InputInfos, xTextContainerElement);
								e.Document.UndoList.AddMethod(UndoMethodTypes.UpdateExpressionExecuter);
								xTextContainerElement.PropertyExpressions = dlgPropertyExpressionInfoList.InputInfos;
							}
							e.Document.EndLogUndo();
							e.Document.Modified = true;
							e.Document.OnDocumentContentChanged();
							e.Result = true;
						}
					}
				}
			}
		}

		/// <summary>
		///       设置是否显示页眉下边缘的横线
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SpecifyPageIndex", ReturnValueType = typeof(bool), DefaultResultValue = true)]
		protected void SpecifyPageIndex(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				XTextPageInfoElement xTextPageInfoElement = (XTextPageInfoElement)GetSingleHandledElement(e, typeof(XTextPageInfoElement));
				e.Enabled = (xTextPageInfoElement != null && e.DocumentControler.CanModify(xTextPageInfoElement));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				XTextPageInfoElement xTextPageInfoElement = (XTextPageInfoElement)GetSingleHandledElement(e, typeof(XTextPageInfoElement));
				if (xTextPageInfoElement != null && e.DocumentControler.CanModify(xTextPageInfoElement) && (xTextPageInfoElement.ValueType == PageInfoValueType.PageIndex || xTextPageInfoElement.ValueType == PageInfoValueType.LocalPageIndex))
				{
					int num = e.Document.PageIndex + 1;
					if (e.ShowUI)
					{
						using (dlgSpecifyPageIndex dlgSpecifyPageIndex = new dlgSpecifyPageIndex())
						{
							dlgSpecifyPageIndex.InputValue = num;
							if (WriterControl.UIShowDialog(e.EditorControl, dlgSpecifyPageIndex, xTextPageInfoElement) == DialogResult.OK)
							{
								int inputValue = dlgSpecifyPageIndex.InputValue;
								if (inputValue != num)
								{
									if (xTextPageInfoElement.SpecifyPageIndexs == null)
									{
										xTextPageInfoElement.SpecifyPageIndexs = new SpecifyPageIndexInfoList();
									}
									xTextPageInfoElement.SpecifyPageIndexs.SetValue(num, inputValue);
									e.Result = true;
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		///       设置是否显示页眉下边缘的横线
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("HeaderBottomLineVisible", ReturnValueType = typeof(bool), DefaultResultValue = true)]
		protected void HeaderBottomLineVisible(object sender, WriterCommandEventArgs e)
		{
			int num = 5;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
				if (e.Document != null)
				{
					e.Checked = (e.Document.Info.ShowHeaderBottomLine != DCBooleanValue.False);
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				DCBooleanValue dCBooleanValue = DCBooleanValue.True;
				dCBooleanValue = ((e.Document.Info.ShowHeaderBottomLine == DCBooleanValue.True) ? DCBooleanValue.False : DCBooleanValue.True);
				if (e.Parameter is bool)
				{
					dCBooleanValue = ((!(bool)e.Parameter) ? DCBooleanValue.False : DCBooleanValue.True);
				}
				else if (e.Parameter is DCBooleanValue)
				{
					dCBooleanValue = (DCBooleanValue)e.Parameter;
				}
				if (e.Document.Info.ShowHeaderBottomLine != dCBooleanValue)
				{
					if (e.Document.BeginLogUndo())
					{
						e.Document.UndoList.AddProperty("ShowHeaderBottomLine", e.Document.Info.ShowHeaderBottomLine, dCBooleanValue, e.Document.Info);
						e.Document.EndLogUndo();
					}
					e.Document.Info.ShowHeaderBottomLine = dCBooleanValue;
					e.Document.Modified = true;
					e.Document.UpdateContentVersion();
					e.Document.OnDocumentContentChanged();
					e.RefreshLevel = UIStateRefreshLevel.Current;
					if (e.EditorControl != null)
					{
						e.EditorControl.InnerViewControl.Invalidate();
					}
				}
			}
		}

		/// <summary>
		///       显示被标记为自动隐藏的元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ShowElementMarkAutoHide")]
		protected void ShowElementMarkAutoHide(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.Document != null)
			{
				e.Document.BeginLogUndo();
				e.Result = e.Document.SetVisibleForElementMarkAutoHide(visible: true, logUndo: true);
				e.Document.EndLogUndo();
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Document.OnDocumentContentChanged();
				e.Document.OnSelectionChanged();
			}
		}

		/// <summary>
		///       隐藏被标记为自动隐藏的元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("HideElementMarkAutoHide")]
		protected void HideElementMarkAutoHide(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.Document != null)
			{
				e.Document.BeginLogUndo();
				e.Result = e.Document.SetVisibleForElementMarkAutoHide(visible: false, logUndo: true);
				e.Document.EndLogUndo();
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Document.OnDocumentContentChanged();
				e.Document.OnSelectionChanged();
			}
		}

		/// <summary>
		///       清空文档正文内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ClearBodyContent")]
		protected void ClearBodyContent(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && !e.EditorControl.RuntimeReadonly);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.EditorControl != null && !e.EditorControl.RuntimeReadonly)
				{
					e.Document.Comments.Clear();
					e.Document.UndoList.Clear();
					e.Document.Body.Elements.Clear();
					e.EditorControl.RefreshDocument();
					e.Document.Modified = true;
					e.Document.OnDocumentContentChanged();
					e.Document.OnSelectionChanged();
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = true;
				}
			}
		}

		/// <summary>
		///       显示文档选项
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DocumentInfo", ReturnValueType = typeof(bool))]
		protected void DocumentInfo(object sender, WriterCommandEventArgs e)
		{
			int num = 3;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.ShowUI)
				{
					using (dlgObjectProperty dlgObjectProperty = new dlgObjectProperty())
					{
						DocumentInfo documentInfo = e.Document.Info.Clone();
						documentInfo.RefreshLayoutFlag = false;
						documentInfo.RefreshViewFlag = false;
						dlgObjectProperty.InputObject = documentInfo;
						if (dlgObjectProperty.ShowDialog(e.EditorControl) == DialogResult.OK)
						{
							if (e.Document.BeginLogUndo())
							{
								e.Document.UndoList.AddProperty("Info", e.Document.Info, dlgObjectProperty.InputObject, e.Document);
							}
							e.Document.Info = documentInfo;
							e.Document.Modified = true;
							e.Document.OnDocumentContentChanged();
							e.RefreshLevel = UIStateRefreshLevel.All;
							e.Result = true;
							if (documentInfo.RefreshLayoutFlag)
							{
								e.EditorControl.RefreshDocumentExt(refreshSize: true, executeLayout: true);
							}
							else if (documentInfo.RefreshViewFlag)
							{
								e.EditorControl.InnerViewControl.Invalidate();
							}
						}
					}
				}
			}
		}

		/// <summary>
		///       设置输入语言
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SetInputLanguage")]
		protected void SetInputLanguage(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && !e.EditorControl.RuntimeReadonly);
				if (e.UIElement is ToolStripItem)
				{
					((ToolStripItem)e.UIElement).Text = WriterStrings.CaptionInputLanguage + GetShortLanguageName(InputLanguage.CurrentInputLanguage);
				}
			}
			else if (e.Mode == WriterCommandEventMode.UpdateUIElement)
			{
				if (e.UIElement is ToolStripDropDownButton)
				{
					ToolStripDropDownButton toolStripDropDownButton = (ToolStripDropDownButton)e.UIElement;
					if (toolStripDropDownButton.DropDownItems.Count == 0)
					{
						toolStripDropDownButton.DropDownItems.AddRange(CreateLanugageMenuItems());
					}
				}
				else if (e.UIElement is ToolStripMenuItem)
				{
					ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.UIElement;
					if (toolStripMenuItem.DropDownItems.Count == 0)
					{
						toolStripMenuItem.DropDownItems.AddRange(CreateLanugageMenuItems());
					}
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI && !(e.UIElement is ToolStripDropDownButton) && !(e.UIElement is ToolStripDropDownItem))
			{
				using (dlgBrowseInputLanguage dlgBrowseInputLanguage = new dlgBrowseInputLanguage())
				{
					dlgBrowseInputLanguage.SelectedInputLanugae = InputLanguage.CurrentInputLanguage;
					if (dlgBrowseInputLanguage.ShowDialog(e.EditorControl) == DialogResult.OK)
					{
						InputLanguage.CurrentInputLanguage = dlgBrowseInputLanguage.SelectedInputLanugae;
					}
				}
			}
		}

		private string GetShortLanguageName(InputLanguage inputLanguage_0)
		{
			return inputLanguage_0.Culture.TwoLetterISOLanguageName.ToUpper();
		}

		private ToolStripMenuItem[] CreateLanugageMenuItems()
		{
			List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
			foreach (InputLanguage installedInputLanguage in InputLanguage.InstalledInputLanguages)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = installedInputLanguage.LayoutName;
				toolStripMenuItem.Tag = installedInputLanguage;
				toolStripMenuItem.Click += InputLanguageItem_Click;
				list.Add(toolStripMenuItem);
			}
			return list.ToArray();
		}

		private void InputLanguageItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			InputLanguage inputLanguage_ = InputLanguage.CurrentInputLanguage = (InputLanguage)toolStripMenuItem.Tag;
			if (toolStripMenuItem.OwnerItem != null)
			{
				toolStripMenuItem.OwnerItem.Text = WriterStrings.CaptionInputLanguage + GetShortLanguageName(inputLanguage_);
			}
		}

		/// <summary>
		///       获得支持设置事件VB脚本的文档元素对象
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <returns>
		/// </returns>
		private XTextElement GetElementSupportEventVBScript(WriterCommandEventArgs args, bool showUI)
		{
			XTextElement result = null;
			XTextElement xTextElement = args.Document.CurrentElement;
			if (xTextElement == null)
			{
				return null;
			}
			if (showUI)
			{
				XTextElementList xTextElementList = new XTextElementList();
				while (xTextElement != null)
				{
					if (xTextElement is XTextContainerElement)
					{
						xTextElementList.Add(xTextElement);
					}
					xTextElement = xTextElement.Parent;
				}
				if (xTextElementList.Count > 1)
				{
					using (dlgBrowseElements dlgBrowseElements = new dlgBrowseElements())
					{
						dlgBrowseElements.InputElements = xTextElementList;
						if (WriterControl.UIShowDialog(args.EditorControl, dlgBrowseElements, null) == DialogResult.OK)
						{
							result = dlgBrowseElements.SelectedElement;
						}
					}
				}
			}
			else
			{
				result = DocumentScriptEngine.GetElementSupportEventVBScript(xTextElement);
			}
			return result;
		}

		/// <summary>
		///       编辑文档元素的VB脚本代码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("EditElementEventVBScript", ImageResource = "DCSoft.Writer.Controls.VB.bmp")]
		protected void EditElementEventVBScript(object sender, WriterCommandEventArgs e)
		{
			int num = 3;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && e.Document.Selection.Length == 0)
				{
					XTextElement elementSupportEventVBScript = GetElementSupportEventVBScript(e, showUI: false);
					if (elementSupportEventVBScript == null)
					{
						e.Enabled = false;
					}
					else if (e.DocumentControler.CanModify(elementSupportEventVBScript))
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
				if (!e.UIStartEditContent())
				{
					return;
				}
				e.RefreshLevel = UIStateRefreshLevel.None;
				XTextElement elementSupportEventVBScript = GetElementSupportEventVBScript(e, e.ShowUI);
				if (elementSupportEventVBScript == null || !e.DocumentControler.CanModify(elementSupportEventVBScript))
				{
					return;
				}
				VBScriptItemList vBScriptItemList = null;
				if (e.Parameter is VBScriptItemList)
				{
					vBScriptItemList = (VBScriptItemList)e.Parameter;
				}
				else
				{
					vBScriptItemList = DocumentScriptEngine.GetVBScriptItems(elementSupportEventVBScript);
					vBScriptItemList = ((vBScriptItemList != null) ? vBScriptItemList.Clone() : new VBScriptItemList());
				}
				if (e.ShowUI)
				{
					using (dlgVBScriptEditor dlgVBScriptEditor = new dlgVBScriptEditor())
					{
						dlgVBScriptEditor.Text = elementSupportEventVBScript.GetType().Name + ":" + elementSupportEventVBScript.ID;
						dlgVBScriptEditor.ScriptItems = vBScriptItemList;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgVBScriptEditor, elementSupportEventVBScript) != DialogResult.OK)
						{
							return;
						}
						vBScriptItemList = dlgVBScriptEditor.ScriptItems;
					}
				}
				e.Document.BeginLogUndo();
				bool flag = DocumentScriptEngine.SetVBScriptItems(elementSupportEventVBScript, vBScriptItemList, logUndo: true);
				e.Document.EndLogUndo();
				if (flag)
				{
					e.Result = true;
					e.Document.Modified = true;
					if (e.Document.ScriptEngine != null)
					{
						e.Document.ScriptEngine.UpdateScriptText();
					}
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
				}
			}
		}

		/// <summary>
		///       执行退格删除操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Backspace", ShortcutKey = Keys.Back, ReturnValueType = typeof(bool))]
		protected void Backspace(object sender, WriterCommandEventArgs e)
		{
			int num = 10;
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
				if (!e.UIStartEditContent())
				{
					return;
				}
				if (e.Document.Selection.Mode == ContentRangeMode.Cell)
				{
					List<XTextTableRowElement> list = new List<XTextTableRowElement>();
					List<XTextTableColumnElement> list2 = new List<XTextTableColumnElement>();
					XTextElementList cells = e.Document.Selection.Cells;
					bool flag = true;
					bool flag2 = true;
					XTextTableElement ownerTable = ((XTextTableCellElement)cells[0]).OwnerTable;
					for (int i = 0; i < cells.Count; i++)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)cells[i];
						if (xTextTableCellElement.OwnerTable == ownerTable)
						{
							if (xTextTableCellElement.OwnerColumn != null && !list2.Contains(xTextTableCellElement.OwnerColumn))
							{
								list2.Add(xTextTableCellElement.OwnerColumn);
								XTextTableColumnElement ownerColumn = xTextTableCellElement.OwnerColumn;
								int num2 = 0;
								for (int j = i; j < cells.Count; j++)
								{
									XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)cells[j];
									if (xTextTableCellElement2.OwnerColumn == ownerColumn)
									{
										num2++;
										if (num2 == ownerTable.Rows.Count)
										{
											break;
										}
									}
								}
								if (num2 != ownerTable.Rows.Count)
								{
									flag2 = false;
								}
							}
							if (xTextTableCellElement.OwnerRow != null && !list.Contains(xTextTableCellElement.OwnerRow))
							{
								list.Add(xTextTableCellElement.OwnerRow);
								XTextTableRowElement ownerRow = xTextTableCellElement.OwnerRow;
								int num2 = 0;
								for (int j = i; j < cells.Count; j++)
								{
									if (cells[j].Parent == ownerRow)
									{
										num2++;
										if (num2 == ownerRow.Cells.Count)
										{
											break;
										}
									}
								}
								if (num2 != ownerRow.Cells.Count)
								{
									flag = false;
								}
							}
							if (!flag && !flag2)
							{
								break;
							}
							continue;
						}
						flag = false;
						flag2 = false;
						break;
					}
					if (flag)
					{
						e.Result = e.EditorControl.ExecuteCommandSpecifyArgs("Table_DeleteRow", e);
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
					else if (flag2)
					{
						e.Result = e.EditorControl.ExecuteCommandSpecifyArgs("Table_DeleteColumn", e);
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
					else if (e.ShowUI)
					{
						using (dlgPromptDeleteCell dlgPromptDeleteCell = new dlgPromptDeleteCell())
						{
							if (WriterControl.UIShowDialog(e.EditorControl, dlgPromptDeleteCell, null) == DialogResult.OK)
							{
								if (dlgPromptDeleteCell.DeleteRow)
								{
									e.Result = e.EditorControl.ExecuteCommandSpecifyArgs("Table_DeleteRow", e);
									e.RefreshLevel = UIStateRefreshLevel.All;
								}
								else
								{
									e.Result = e.EditorControl.ExecuteCommandSpecifyArgs("Table_DeleteColumn", e);
									e.RefreshLevel = UIStateRefreshLevel.All;
								}
							}
						}
					}
					else
					{
						e.Result = e.EditorControl.ExecuteCommandSpecifyArgs("Table_DeleteRow", e);
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
				else
				{
					e.Result = e.EditorControl.DocumentControler.vmethod_7(e.ShowUI);
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       以文本方式复制内容，忽略其他所有设置
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("CopyWithClearFieldValue", ImageResource = "DCSoft.Writer.Commands.Images.CommandCopy.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_51)]
		protected void CopyWithClearFieldValue(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanCopy);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = e.DocumentControler.method_11();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       以文本方式复制内容，忽略其他所有设置
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("CopyAsText", ImageResource = "DCSoft.Writer.Commands.Images.CommandCopy.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_51)]
		protected void CopyAsText(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanCopy);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = e.DocumentControler.method_10();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       复制内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Copy", ShortcutKey = (Keys)131139, ImageResource = "DCSoft.Writer.Commands.Images.CommandCopy.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_51)]
		protected void Copy(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanCopy);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = e.DocumentControler.method_9();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       粘贴操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Cut", ShortcutKey = (Keys)131160, ImageResource = "DCSoft.Writer.Commands.Images.CommandCut.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_52)]
		protected void Cut(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.method_8());
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.UIStartEditContent())
				{
					e.Result = e.DocumentControler.method_7(e.ShowUI);
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       执行删除整个文本行的操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DeleteLine", ImageResource = "DCSoft.Writer.Commands.Images.CommandDelete.bmp", ReturnValueType = typeof(bool))]
		protected void DeleteLine(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && !e.EditorControl.RuntimeReadonly);
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
				XTextLine xTextLine = null;
				XTextContent content = e.Document.Content;
				if (e.Parameter is XTextElement)
				{
					XTextElement xTextElement = (XTextElement)e.Parameter;
					xTextLine = xTextElement.OwnerLine;
					if (xTextElement.FirstContentElement != null)
					{
						xTextLine = xTextElement.FirstContentElement.OwnerLine;
					}
				}
				else
				{
					xTextLine = content.CurrentLine;
				}
				if (xTextLine == null)
				{
					return;
				}
				XTextContentElement contentElement = xTextLine[0].ContentElement;
				XTextSelection xTextSelection = new XTextSelection(xTextLine[0].DocumentContentElement);
				int num = content.IndexOf(xTextLine[0]);
				XTextElement lastElement = xTextLine.LastElement;
				int num2 = content.IndexOf(lastElement);
				if (lastElement is XTextParagraphFlagElement && contentElement.Elements.LastElement == lastElement)
				{
					num2--;
				}
				if (num2 < num)
				{
					return;
				}
				num = content.FixIndexForStrictFormViewMode(num, FixIndexDirection.Back, enableSetAutoClearSelectionFlag: false);
				for (num2 = content.FixIndexForStrictFormViewMode(num2, FixIndexDirection.Forward, enableSetAutoClearSelectionFlag: false); num <= num2 && !e.DocumentControler.CanDeleteExt(content[num], DomAccessFlags.Normal); num++)
				{
				}
				while (num2 >= num && !e.DocumentControler.CanDeleteExt(content[num2], DomAccessFlags.Normal))
				{
					num2--;
				}
				if (num2 >= num)
				{
					xTextSelection.Refresh(num, num2 - num + 1);
					e.Document.BeginLogUndo();
					int num3 = content.DeleteSelection(raiseEvent: true, detect: false, fastMode: false, xTextSelection);
					e.Document.EndLogUndo();
					if (num3 > 0)
					{
						content.MoveToPosition(num);
					}
					e.Result = (num3 > 0);
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       执行删除操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DeleteAbsolute", ImageResource = "DCSoft.Writer.Commands.Images.CommandDelete.bmp", ReturnValueType = typeof(bool))]
		protected void DeleteAbsolute(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.UIStartEditContent())
				{
					bool flag = false;
					bool backgroundMode = e.EditorControl.BackgroundMode;
					bool enableLogicDelete = e.Document.Options.SecurityOptions.EnableLogicDelete;
					try
					{
						e.EditorControl.BackgroundMode = true;
						e.Document.Options.SecurityOptions.EnableLogicDelete = false;
						flag = e.DocumentControler.Delete(e.ShowUI);
					}
					finally
					{
						e.EditorControl.BackgroundMode = backgroundMode;
						e.Document.Options.SecurityOptions.EnableLogicDelete = enableLogicDelete;
					}
					e.Result = flag;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       执行删除操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Delete", ShortcutKey = Keys.Delete, ImageResource = "DCSoft.Writer.Commands.Images.CommandDelete.bmp", ReturnValueType = typeof(bool))]
		protected void Delete(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.Snapshot.CanDeleteSelection);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.UIStartEditContent())
				{
					bool flag = false;
					flag = e.DocumentControler.Delete(e.ShowUI);
					e.Result = flag;
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       删除文档最后面的空白段落
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("DeleteRedundant", ReturnValueType = typeof(int))]
		protected void DeleteRedundant(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.CurrentContentElement != null && !e.DocumentControler.EditorControlReadonly);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = 0;
				if (e.UIStartEditContent())
				{
					XTextContentElement xTextContentElement = e.Document.CurrentContentElement;
					if (e.Parameter is XTextContentElement)
					{
						xTextContentElement = (XTextContentElement)e.Parameter;
					}
					int num = xTextContentElement.DeleteRedundant(whiteSpace: true, tabSpace: true, paragraphFlag: true, chineseWhitespace: true, pageBreak: true, lineBreak: true);
					if (num > 0)
					{
						e.Result = num;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       插入签名锁元素
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SignDocument", ImageResource = "DCSoft.Writer.Commands.Images.CommandSignDocument.bmp", ReturnValueType = typeof(XTextSignElement))]
		protected void SignDocument(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.DocumentControler != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextSignElement)) && e.Document.CurrentContentPartyStyle == PageContentPartyStyle.Body && e.Document.Options.SecurityOptions.EnablePermission)
				{
					e.Enabled = true;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				e.Result = e.DocumentControler.SignDocument();
				e.RefreshLevel = UIStateRefreshLevel.All;
			}
		}

		/// <summary>
		///       设置修改、插入模式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("InsertMode", ShortcutKey = Keys.Insert, ReturnValueType = typeof(bool))]
		protected void InsertMode(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
				e.Checked = (e.EditorControl != null && e.EditorControl.InsertMode);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				bool insertMode;
				if ((insertMode = WriterUtils.smethod_41(e.Parameter, !e.EditorControl.InsertMode)) != e.EditorControl.InsertMode)
				{
					e.EditorControl.InsertMode = insertMode;
					e.EditorControl.UpdateTextCaret();
					e.EditorControl.OnSelectionChanged(EventArgs.Empty);
				}
				e.Result = e.EditorControl.InsertMode;
			}
		}

		/// <summary>
		///       已纯文本格式粘贴操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("PasteAsText", ImageResource = "DCSoft.Writer.Commands.Images.CommandPaste.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_53)]
		protected void PasteAsText(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && e.DocumentControler.CanInsertAtCurrentPosition)
				{
					e.Enabled = true;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.UIStartEditContent())
				{
					e.Result = e.EditorControl.method_0(DataFormats.Text, e.ShowUI);
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       粘贴操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Paste", ShortcutKey = (Keys)131158, ImageResource = "DCSoft.Writer.Commands.Images.CommandPaste.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_53)]
		protected void Paste(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && e.DocumentControler.CanInsertAtCurrentPosition)
				{
					e.Enabled = true;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.UIStartEditContent())
				{
					e.Result = e.EditorControl.method_0(null, e.ShowUI);
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       选择性粘贴操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SpecifyPaste", ImageResource = "DCSoft.Writer.Commands.Images.CommandPaste.bmp", ReturnValueType = typeof(bool), FunctionID = GEnum6.const_54)]
		protected void SpecifyPaste(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && e.DocumentControler.CanInsertAtCurrentPosition)
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
				if (e.UIStartEditContent())
				{
					string text = e.Parameter as string;
					if (e.ShowUI)
					{
						using (dlgSpecifyPaste dlgSpecifyPaste = new dlgSpecifyPaste())
						{
							dlgSpecifyPaste.WriterControl = e.EditorControl;
							dlgSpecifyPaste.Document = e.Document;
							dlgSpecifyPaste.DataObject = Clipboard.GetDataObject();
							dlgSpecifyPaste.ResultFormat = text;
							if (WriterControl.UIShowDialog(e.EditorControl, dlgSpecifyPaste, null) != DialogResult.OK)
							{
								return;
							}
							text = dlgSpecifyPaste.ResultFormat;
						}
					}
					if (!string.IsNullOrEmpty(text))
					{
						e.Result = e.EditorControl.method_0(text, e.ShowUI);
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       重复执行操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Redo", ShortcutKey = (Keys)131161, ImageResource = "DCSoft.Writer.Commands.Images.CommandRedo.bmp", ReturnValueType = typeof(bool))]
		protected void Redo(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					e.Enabled = (!e.DocumentControler.EditorControlReadonly && e.Document.UndoList != null && e.Document.UndoList.method_10() && e.Document.Options.BehaviorOptions.EnableLogUndo);
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.UIStartEditContent())
				{
					GEventArgs3 geventArgs3_ = new GEventArgs3();
					e.EditorControl.CancelEditElementValue();
					e.EditorControl.CancelFormatBrush();
					e.Document.States.ExecutingRedo = true;
					try
					{
						e.Result = e.Document.UndoList.method_8(geventArgs3_);
					}
					finally
					{
						e.Document.States.ExecutingRedo = false;
					}
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       重复执行操作
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Undo", ShortcutKey = (Keys)131162, ImageResource = "DCSoft.Writer.Commands.Images.CommandUndo.bmp", ReturnValueType = typeof(bool))]
		protected void Undo(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					e.Enabled = (!e.DocumentControler.EditorControlReadonly && e.Document.UndoList != null && e.Document.UndoList.method_9() && e.Document.Options.BehaviorOptions.EnableLogUndo);
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.UIStartEditContent())
				{
					GEventArgs3 geventArgs3_ = new GEventArgs3();
					e.EditorControl.CancelEditElementValue();
					e.EditorControl.CancelFormatBrush();
					e.Document.States.ExecutingUndo = true;
					try
					{
						e.Result = e.Document.UndoList.method_7(geventArgs3_);
					}
					finally
					{
						e.Document.States.ExecutingUndo = false;
					}
					e.RefreshLevel = UIStateRefreshLevel.All;
				}
			}
		}

		/// <summary>
		///       清空撤销操作信息列表
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ClearUndo")]
		protected void ClearUndo(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.Document != null && e.Document.UndoList != null)
				{
					e.Document.CancelLogUndo();
					e.Document.UndoList.Clear();
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = true;
				}
			}
		}

		/// <summary>
		///       清空正文中所有输入域的内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ClearAllFieldValue", ReturnValueType = typeof(bool))]
		protected void ClearAllFieldValue(object sender, WriterCommandEventArgs e)
		{
			int num = 5;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && !e.EditorControl.RuntimeReadonly);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					bool flag = false;
					XTextElementList elementsByType = e.Document.Body.GetElementsByType(typeof(XTextInputFieldElement));
					if (elementsByType != null && elementsByType.Count > 0)
					{
						e.Document.BeginLogUndo();
						foreach (XTextInputFieldElement item in elementsByType)
						{
							if (e.DocumentControler.CanModify(item, DomAccessFlags.Normal))
							{
								bool flag2 = false;
								if (item.SetEditorTextExt(null, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true))
								{
									flag2 = true;
								}
								string innerValue = item.InnerValue;
								if (!string.IsNullOrEmpty(innerValue))
								{
									if (e.Document.CanLogUndo)
									{
										e.Document.UndoList.AddProperty("InnerValue", innerValue, null, item);
									}
									item.InnerValue = null;
									flag2 = true;
								}
								if (flag2)
								{
									flag = true;
								}
							}
						}
						e.Document.EndLogUndo();
						e.Document.Modified = true;
						e.Result = flag;
					}
				}
			}
		}

		/// <summary>
		///       清空输入域的内容
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ClearCurrentFieldValue", ReturnValueType = typeof(bool))]
		protected void ClearCurrentFieldValue(object sender, WriterCommandEventArgs e)
		{
			int num = 14;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.Document.GetCurrentElement(typeof(XTextInputFieldElement));
					if (xTextInputFieldElement != null)
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
				if (!e.UIStartEditContent())
				{
					return;
				}
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.Document.GetCurrentElement(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement == null || !e.DocumentControler.CanModify(xTextInputFieldElement, DomAccessFlags.Normal))
				{
					return;
				}
				e.Document.BeginLogUndo();
				bool flag = false;
				e.Document.Content.MoveToPosition(xTextInputFieldElement.FirstContentElementInPublicContent.ViewIndex + 1);
				if (xTextInputFieldElement.SetEditorTextExt(null, DomAccessFlags.Normal, disablePermissioin: false, updateContent: true))
				{
					flag = true;
				}
				string innerValue = xTextInputFieldElement.InnerValue;
				if (!string.IsNullOrEmpty(innerValue))
				{
					if (e.Document.CanLogUndo)
					{
						e.Document.UndoList.AddProperty("InnerValue", innerValue, null, xTextInputFieldElement);
					}
					xTextInputFieldElement.InnerValue = null;
					flag = true;
				}
				e.Document.EndLogUndo();
				e.Result = flag;
			}
		}

		/// <summary>
		///       删除字段域元素
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("DeleteField", ReturnValueType = typeof(bool))]
		protected void DeleteField(object sender, WriterCommandEventArgs e)
		{
			if (e.Document == null)
			{
				e.Enabled = false;
				return;
			}
			XTextElement xTextElement = e.Document.CurrentElement;
			if (e.Parameter is XTextElement)
			{
				xTextElement = (XTextElement)e.Parameter;
			}
			while (xTextElement != null && !(xTextElement is XTextFieldElementBase))
			{
				xTextElement = xTextElement.Parent;
			}
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (xTextElement == null)
				{
					e.Enabled = false;
				}
				else
				{
					e.Enabled = (e.DocumentControler != null && e.DocumentControler.method_18(xTextElement));
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement;
					int viewIndex = xTextFieldElementBase.StartElement.ViewIndex;
					if (xTextFieldElementBase.EditorDelete(logUndo: true))
					{
						e.Document.Content.method_47(viewIndex, 0);
						e.RefreshLevel = UIStateRefreshLevel.All;
						e.Result = true;
					}
				}
			}
		}

		/// <summary>
		///       获得要处理的单个文档元素对象
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <param name="elementType">
		/// </param>
		/// <returns>
		/// </returns>
		private XTextElement GetSingleHandledElement(WriterCommandEventArgs args, Type elementType)
		{
			int num = 1;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (elementType == null)
			{
				throw new ArgumentNullException("elementType");
			}
			if (!elementType.IsSubclassOf(typeof(XTextElement)))
			{
				throw new ArgumentException(elementType.FullName);
			}
			if (args.Parameter != null && elementType.IsInstanceOfType(args.Parameter))
			{
				return (XTextElement)args.Parameter;
			}
			if (args.Parameter is string)
			{
				XTextElement elementById = args.Document.GetElementById((string)args.Parameter);
				if (elementType.IsInstanceOfType(elementById))
				{
					return elementById;
				}
			}
			if (args.Document.Selection.Length == 0)
			{
				if (elementType.IsInstanceOfType(args.Document.CurrentElement))
				{
					return args.Document.CurrentElement;
				}
			}
			else if (args.Document.Selection.Length == 1)
			{
				XTextElement xTextElement = args.Document.Selection.ContentElements[0];
				if (elementType.IsInstanceOfType(xTextElement))
				{
					return xTextElement;
				}
			}
			return null;
		}

		/// <summary>
		///       编辑图片上附加的图形
		///       </summary>
		/// <param name="sender">参数</param>
		/// <param name="args">参数</param>
		[WriterCommandDescription("EditImageAdditionShape", ImageResource = "DCSoft.Writer.Commands.Images.CommandEditImageAdditionShape.bmp", ReturnValueType = typeof(bool))]
		protected void EditImageAdditionShape(object sender, WriterCommandEventArgs e)
		{
			int num = 18;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextImageElement xTextImageElement = (XTextImageElement)GetSingleHandledElement(e, typeof(XTextImageElement));
					e.Enabled = (xTextImageElement != null && e.Document.DocumentControler.CanModify(xTextImageElement));
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					XTextImageElement xTextImageElement = (XTextImageElement)GetSingleHandledElement(e, typeof(XTextImageElement));
					if (xTextImageElement != null && xTextImageElement.EnableEditImageAdditionShape && e.ShowUI)
					{
						using (frmImageShapeEditor frmImageShapeEditor = new frmImageShapeEditor())
						{
							frmImageShapeEditor.StandardLabels = e.Document.Options.BehaviorOptions.StdLablesForImageEditor;
							frmImageShapeEditor.ContentImage = xTextImageElement.RuntimeImage.Value;
							frmImageShapeEditor.ZoomButtonVisible = false;
							frmImageShapeEditor.CurrentLineColor = e.Document.Options.ViewOptions.DefaultLineColorForImageEditor;
							frmImageShapeEditor.BackgroundMenuItemSettingString = e.Document.Options.BehaviorOptions.ImageShapeEditorBackgroundMenuItemConfig;
							ShapeDocument shapeDocument = null;
							if (xTextImageElement.AdditionShape != null)
							{
								shapeDocument = (ShapeDocument)xTextImageElement.AdditionShape.vmethod_17(bool_8: true);
							}
							else
							{
								shapeDocument = new ShapeDocument();
								shapeDocument.TextBackColor = Color.White;
							}
							if (shapeDocument.FirstPage == null)
							{
								ShapeDocumentImagePage shapeDocumentImagePage = new ShapeDocumentImagePage();
								shapeDocumentImagePage.OwnerDocument = shapeDocument;
								shapeDocumentImagePage.Width = xTextImageElement.Width;
								shapeDocumentImagePage.Height = xTextImageElement.Height;
								ContentStyle contentStyle = new ContentStyle();
								contentStyle.BorderLeft = true;
								contentStyle.BorderTop = true;
								contentStyle.BorderRight = true;
								contentStyle.BorderBottom = true;
								contentStyle.BorderWidth = 1f;
								contentStyle.BorderColor = Color.Black;
								shapeDocumentImagePage.StyleIndex = shapeDocument.ContentStyles.GetStyleIndex(contentStyle);
								shapeDocument.Pages.Add(shapeDocumentImagePage);
							}
							shapeDocument.DocumentGraphicsUnit = e.Document.DocumentGraphicsUnit;
							shapeDocument.FirstPage.Width = xTextImageElement.Width;
							shapeDocument.FirstPage.Height = xTextImageElement.Height;
							ShapeDocumentImagePage shapeDocumentImagePage2 = (ShapeDocumentImagePage)shapeDocument.FirstPage;
							shapeDocumentImagePage2.AutoSize = false;
							frmImageShapeEditor.SpecifyImageSize = new SizeF(xTextImageElement.Width, xTextImageElement.Height);
							frmImageShapeEditor.ShapeDocument = shapeDocument;
							if (WriterControl.UIShowDialog(e.EditorControl, frmImageShapeEditor, xTextImageElement) == DialogResult.OK)
							{
								e.Document.Options.ViewOptions.DefaultLineColorForImageEditor = frmImageShapeEditor.CurrentLineColor;
								if (e.Document.BeginLogUndo())
								{
									e.Document.UndoList.AddProperty("AdditionShape", xTextImageElement.AdditionShape, frmImageShapeEditor.ShapeDocument, xTextImageElement);
									e.Document.EndLogUndo();
								}
								xTextImageElement.AdditionShape = frmImageShapeEditor.ShapeDocument;
								if (xTextImageElement.AdditionShape.Pages.Count > 0 && xTextImageElement.AdditionShape.Pages[0] is ShapeDocumentImagePage)
								{
									ShapeDocumentImagePage shapeDocumentImagePage3 = (ShapeDocumentImagePage)xTextImageElement.AdditionShape.Pages[0];
									shapeDocumentImagePage3.Image = null;
								}
								xTextImageElement.UpdateContentVersion();
								e.Document.Modified = true;
								e.Document.OnSelectionChanged();
								e.Document.OnDocumentContentChanged();
								xTextImageElement.InvalidateView();
								e.Result = true;
							}
						}
					}
				}
			}
		}

		/// <summary>
		///       编辑元素值，标准快捷键是 F2 。
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ExecuteElementDefaultMethod", ShortcutKey = Keys.F2)]
		protected void ExecuteElementDefaultMethod(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && !e.EditorControl.RuntimeReadonly)
				{
					e.Enabled = true;
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.UIStartEditContent())
			{
				e.EditorControl.ExecuteElementDefaultMethod(e.EditorControl.CurrentElement);
			}
		}

		/// <summary>
		///       文档元素表达式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ElementExpression")]
		protected void ElementExpression(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && !e.EditorControl.RuntimeReadonly);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI && e.UIStartEditContent())
			{
				XTextElement xTextElement = e.Document.CurrentElement;
				while (xTextElement != null && !(xTextElement is XTextContainerElement))
				{
					xTextElement = xTextElement.Parent;
				}
				if (xTextElement != null)
				{
					using (dlgElementExpression dlgElementExpression = new dlgElementExpression())
					{
						dlgElementExpression.SourceElement = xTextElement;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgElementExpression, xTextElement) == DialogResult.OK)
						{
							if (e.Document.ExpressionExecuter != null)
							{
								e.Document.ExpressionExecuter.imethod_4(xTextElement);
							}
							e.Result = xTextElement;
						}
					}
				}
			}
		}

		/// <summary>
		///       简单的编辑元素属性
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ElementPropertiesSimpleMode", ImageResource = "DCSoft.Writer.Commands.Images.CommandElementProperties.bmp", ReturnValueType = typeof(XTextElement))]
		protected void ElementPropertiesSimpleMode(object sender, WriterCommandEventArgs e)
		{
			if (e.EditorControl == null)
			{
				e.Enabled = false;
				return;
			}
			bool simpleElementProperties = e.EditorControl.DocumentOptions.BehaviorOptions.SimpleElementProperties;
			try
			{
				e.EditorControl.DocumentOptions.BehaviorOptions.SimpleElementProperties = true;
				ElementProperties(sender, e);
			}
			finally
			{
				e.EditorControl.DocumentOptions.BehaviorOptions.SimpleElementProperties = simpleElementProperties;
			}
		}

		/// <summary>
		///       编辑元素属性
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("ElementProperties", ImageResource = "DCSoft.Writer.Commands.Images.CommandElementProperties.bmp", ReturnValueType = typeof(XTextElement))]
		protected void ElementProperties(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.DocumentControler.CanSetStyle);
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
				bool flag = false;
				ElementPropertiesCommandParameter elementPropertiesCommandParameter = e.Parameter as ElementPropertiesCommandParameter;
				if (elementPropertiesCommandParameter == null)
				{
					elementPropertiesCommandParameter = new ElementPropertiesCommandParameter();
					elementPropertiesCommandParameter.SimpleElementProperties = e.Document.Options.BehaviorOptions.SimpleElementProperties;
					if (e.Parameter is XTextElement)
					{
						elementPropertiesCommandParameter.Element = (XTextElement)e.Parameter;
					}
					else
					{
						elementPropertiesCommandParameter.Element = e.Document.CurrentElement;
						if (e.Document.Selection.ContentElements.Count == 1)
						{
							elementPropertiesCommandParameter.Element = e.Document.Selection.ContentElements[0];
						}
					}
				}
				else if (elementPropertiesCommandParameter.Element != null)
				{
					flag = true;
				}
				XTextElement xTextElement = elementPropertiesCommandParameter.Element;
				while (true)
				{
					if (xTextElement != null)
					{
						int num = 255;
						num = MathCommon.smethod_25(255, 2, bool_0: false);
						num = MathCommon.smethod_25(num, 4, bool_0: false);
						if (xTextElement.Parent == null)
						{
						}
						ElementStateDetectEventArgs elementStateDetectEventArgs = new ElementStateDetectEventArgs(xTextElement, (DomAccessFlags)num);
						elementStateDetectEventArgs.ForContent = true;
						e.DocumentControler.CanModify(elementStateDetectEventArgs);
						if (!elementStateDetectEventArgs.Result)
						{
							xTextElement = xTextElement.Parent;
							continue;
						}
						if (elementPropertiesCommandParameter.Editor == null)
						{
							elementPropertiesCommandParameter.Editor = e.Host.ElementPropertiesEditors.GetEditor(xTextElement.GetType());
						}
						if (elementPropertiesCommandParameter.Editor != null)
						{
							break;
						}
						if (!flag)
						{
							xTextElement = xTextElement.Parent;
							continue;
						}
						return;
					}
					xTextElement = elementPropertiesCommandParameter.Element;
					GClass8 gClass = null;
					while (xTextElement != null)
					{
						gClass = e.Host.CreateProperties(xTextElement.GetType());
						if (gClass != null)
						{
							break;
						}
						xTextElement = xTextElement.Parent;
					}
					if (gClass == null)
					{
						return;
					}
					gClass.method_1(e.Document);
					if (!gClass.ReadProperties(xTextElement))
					{
						return;
					}
					e.SourceElement = xTextElement;
					if (!gClass.PromptEditProperties(e))
					{
						return;
					}
					e.Document.BeginLogUndo();
					bool flag2 = false;
					if (gClass.ApplyToElement(e.Document, xTextElement, logUndo: true))
					{
						if (xTextElement is XTextContainerElement)
						{
							XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
							xTextContainerElement.method_25();
						}
						xTextElement.UpdateContentVersion();
						xTextElement.InvalidateView();
						flag2 = true;
					}
					e.Document.EndLogUndo();
					if (flag2)
					{
						e.Result = xTextElement;
						e.Document.Modified = true;
						e.Document.OnDocumentContentChanged();
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
					return;
				}
				if (elementPropertiesCommandParameter.Editor.IsSupportMethod(ElementPropertiesEditMethod.Edit))
				{
					ElementPropertiesEditEventArgs elementPropertiesEditEventArgs = new ElementPropertiesEditEventArgs();
					elementPropertiesEditEventArgs.Document = e.Document;
					elementPropertiesEditEventArgs.Element = xTextElement;
					elementPropertiesEditEventArgs.Host = e.Host;
					elementPropertiesEditEventArgs.LogUndo = true;
					elementPropertiesEditEventArgs.Method = ElementPropertiesEditMethod.Edit;
					elementPropertiesEditEventArgs.WriterControl = e.EditorControl;
					elementPropertiesEditEventArgs.SimpleElementProperties = elementPropertiesCommandParameter.SimpleElementProperties;
					bool flag2 = false;
					e.Document.BeginLogUndo();
					if (elementPropertiesCommandParameter.Editor.Edit(elementPropertiesEditEventArgs))
					{
						WriterCommandModule.ApplyElementPropertiesResult(elementPropertiesEditEventArgs, e);
						flag2 = true;
					}
					e.Document.EndLogUndo();
					if (flag2)
					{
						e.Result = xTextElement;
						e.RefreshLevel = UIStateRefreshLevel.All;
					}
				}
			}
		}

		/// <summary>
		///       查找
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("Search", ImageResource = "DCSoft.Writer.Commands.Images.CommandSearch.bmp")]
		protected void Search(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerSearchReplace(e, enableReplace: false);
			}
		}

		/// <summary>
		///       查找和替换
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SearchReplace", ImageResource = "DCSoft.Writer.Commands.Images.CommandSearch.bmp", ShortcutKey = (Keys)131142)]
		protected void SearchReplace(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.Document != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				InnerSearchReplace(e, enableReplace: true);
			}
		}

		/// <summary>
		///       执行查找替换功能
		///       </summary>
		/// <param name="args">
		/// </param>
		/// <param name="enableReplace">
		/// </param>
		private void InnerSearchReplace(WriterCommandEventArgs args, bool enableReplace)
		{
			args.Result = -1;
			SearchReplaceCommandArgs searchReplaceCommandArgs = args.Parameter as SearchReplaceCommandArgs;
			dlgSearch form_ = null;
			if (args.ShowUI)
			{
				form_ = (dlgSearch)args.EditorControl.ToolWindows.method_0(typeof(dlgSearch));
				if (form_ == null)
				{
					form_ = new dlgSearch();
					form_.EnableReplace = enableReplace;
					args.EditorControl.ToolWindows.Add(form_);
					form_.WriterControl = args.EditorControl;
				}
				if (form_ == null)
				{
					return;
				}
				if (!form_.Visible)
				{
					if (searchReplaceCommandArgs == null)
					{
						searchReplaceCommandArgs = new SearchReplaceCommandArgs();
					}
					if (args.Document.Selection.Length != 0)
					{
						searchReplaceCommandArgs.SearchString = args.Document.Selection.Text;
					}
					form_.CommandArgs = searchReplaceCommandArgs;
					WriterControl.UIShowForm(args.EditorControl, form_);
					form_.method_0();
				}
				else
				{
					if (searchReplaceCommandArgs != null)
					{
						form_.CommandArgs = searchReplaceCommandArgs;
						form_.method_0();
					}
					else if (args.Document.Selection.Length != 0)
					{
						form_.CommandArgs.SearchString = args.Document.Selection.Text;
						form_.method_0();
					}
					form_.Focus();
				}
				return;
			}
			args.Result = -1;
			if (searchReplaceCommandArgs != null)
			{
				GInterface3 gInterface = args.Document.AppHost.Tools.CreateContentSearchReplacer();
				gInterface.imethod_3(form_);
				gInterface.imethod_5(args.Document);
				if (searchReplaceCommandArgs.EnableReplaceString)
				{
					int num = gInterface.imethod_9(searchReplaceCommandArgs);
					args.Result = num;
					args.RefreshLevel = UIStateRefreshLevel.None;
				}
				else
				{
					int num = gInterface.imethod_11(searchReplaceCommandArgs, bool_0: true, -1);
					args.Result = num;
					args.RefreshLevel = UIStateRefreshLevel.None;
				}
			}
		}

		/// <summary>
		///       设置输入域固定宽度
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("FieldSpecifyWidth", ReturnValueType = typeof(bool))]
		protected void FieldSpecifyWidth(object sender, WriterCommandEventArgs e)
		{
			int num = 15;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.Document == null)
				{
					e.Enabled = false;
					e.Checked = false;
					return;
				}
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)e.Document.GetCurrentElement(typeof(XTextInputFieldElementBase));
				if (xTextInputFieldElementBase == null || !e.DocumentControler.CanModify(xTextInputFieldElementBase))
				{
					e.Enabled = false;
					return;
				}
				e.Enabled = true;
				e.Checked = (xTextInputFieldElementBase.SpecifyWidth > 0f);
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
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)e.Document.GetCurrentElement(typeof(XTextInputFieldElementBase));
				if (xTextInputFieldElementBase == null || !e.DocumentControler.CanModify(xTextInputFieldElementBase))
				{
					return;
				}
				float num2 = 0f;
				XTextElementList xTextElementList = new XTextElementList();
				xTextInputFieldElementBase.vmethod_32(xTextElementList, bool_20: true);
				float num3 = 0f;
				if (num3 < e.Document.PixelToDocumentUnit(XTextFieldBorderElement.float_5) * 4f)
				{
					foreach (XTextElement item in xTextElementList)
					{
						num3 = ((!(item is XTextFieldBorderElement)) ? (num3 + item.Width) : (num3 + e.Document.PixelToDocumentUnit(XTextFieldBorderElement.float_5)));
					}
				}
				if (!(e.Parameter is bool))
				{
					num2 = ((xTextInputFieldElementBase.SpecifyWidth != 0f) ? 0f : num3);
				}
				else if ((bool)e.Parameter)
				{
					num2 = num3;
				}
				if (xTextInputFieldElementBase.SpecifyWidth != num2)
				{
					if (e.Document.BeginLogUndo())
					{
						e.Document.UndoList.AddProperty("SpecifyWidth", xTextInputFieldElementBase.SpecifyWidth, num2, xTextInputFieldElementBase);
						e.Document.EndLogUndo();
					}
					xTextInputFieldElementBase.SpecifyWidth = num2;
					e.Document.Modified = true;
					e.Document.OnDocumentContentChanged();
					e.Result = true;
				}
			}
		}

		/// <summary>
		///       设置文档默认样式
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="args">
		/// </param>
		[WriterCommandDescription("SetDefaultStyle", ReturnValueType = typeof(bool))]
		protected void SetDefaultStyle(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null && !e.EditorControl.RuntimeReadonly)
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
				DocumentContentStyle documentContentStyle = null;
				if (e.Parameter is string)
				{
					documentContentStyle = new DocumentContentStyle();
					documentContentStyle.DisableDefaultValue = true;
					string string_ = (string)e.Parameter;
					GClass340 gClass = new GClass340(string_);
					bool flag = false;
					foreach (GClass341 item in gClass)
					{
						GClass371 gClass2 = GClass371.smethod_2(typeof(DocumentContentStyle), item.Name);
						if (gClass2 != null)
						{
							Type type = gClass2.method_1();
							try
							{
								if (type.Equals(typeof(string)))
								{
									documentContentStyle.vmethod_1(gClass2, item.method_0());
								}
								else
								{
									TypeConverter converter = TypeDescriptor.GetConverter(type);
									if (converter != null && converter.CanConvertFrom(typeof(string)))
									{
										object object_ = converter.ConvertFrom(item.method_0());
										documentContentStyle.vmethod_1(gClass2, object_);
									}
									else
									{
										object object_ = Convert.ChangeType(item.method_0(), type);
										documentContentStyle.vmethod_1(gClass2, object_);
									}
								}
								flag = true;
							}
							catch
							{
							}
						}
					}
					if (!flag)
					{
						documentContentStyle = null;
					}
				}
				else if (e.Parameter is DocumentContentStyle)
				{
					documentContentStyle = (DocumentContentStyle)e.Parameter;
				}
				if (documentContentStyle != null)
				{
					e.Document.EditorSetDefaultStyle(documentContentStyle, logUndo: true);
					e.RefreshLevel = UIStateRefreshLevel.All;
					e.Result = true;
				}
			}
		}
	}
}
