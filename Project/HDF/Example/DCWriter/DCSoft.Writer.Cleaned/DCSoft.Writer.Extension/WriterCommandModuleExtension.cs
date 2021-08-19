using DCSoft.Common;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Data;
using DCSoft.Writer.Extension.Medical;
using DCSoftDotfuscate;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       扩展的编辑器命令模块对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[WriterCommandDescription("Extension")]
	[DCInternal]
	[ComVisible(false)]
	public class WriterCommandModuleExtension : WriterCommandModule
	{
		[WriterCommandDescription("InsertDateTimeField", ImageResource = "DCSoft.Writer.Extension.Images.DateTime.bmp")]
		protected void method_1(object sender, WriterCommandEventArgs e)
		{
			int num = 6;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.CommandControler != null && e.CommandControler.IsCommandEnabled("InsertInputField"));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XTextInputFieldElement xTextInputFieldElement = null;
				if (e.Parameter is XTextInputFieldElement)
				{
					xTextInputFieldElement = (e.Parameter as XTextInputFieldElement);
				}
				else
				{
					xTextInputFieldElement = new XTextInputFieldElement();
					InputFieldSettings inputFieldSettings = new InputFieldSettings();
					inputFieldSettings.EditStyle = InputFieldEditStyle.DateTime;
					xTextInputFieldElement.FieldSettings = inputFieldSettings;
				}
				e.Document.AllocElementID("datetime", xTextInputFieldElement);
				if (e.ShowUI)
				{
					using (dlgDateTimeFieldElement dlgDateTimeFieldElement = new dlgDateTimeFieldElement())
					{
						dlgDateTimeFieldElement.InputFieldElement = xTextInputFieldElement;
						if (dlgDateTimeFieldElement.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
					}
				}
				if (xTextInputFieldElement != null)
				{
					e.EditorControl.ExecuteCommand("InsertInputField", showUI: false, xTextInputFieldElement);
				}
			}
		}

		[WriterCommandDescription("InsertListField")]
		protected void method_2(object sender, WriterCommandEventArgs e)
		{
			int num = 4;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.CommandControler != null && e.CommandControler.IsCommandEnabled("InsertInputField"));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XTextInputFieldElement xTextInputFieldElement = null;
				if (e.Parameter is XTextInputFieldElement)
				{
					xTextInputFieldElement = (e.Parameter as XTextInputFieldElement);
				}
				else
				{
					xTextInputFieldElement = new XTextInputFieldElement();
					InputFieldSettings inputFieldSettings = new InputFieldSettings();
					inputFieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
					xTextInputFieldElement.FieldSettings = inputFieldSettings;
				}
				e.Document.AllocElementID("lst", xTextInputFieldElement);
				if (e.ShowUI)
				{
					using (dlgListFieldElement dlgListFieldElement = new dlgListFieldElement())
					{
						dlgListFieldElement.InputFieldElement = xTextInputFieldElement;
						if (dlgListFieldElement.ShowDialog(e.EditorControl) != DialogResult.OK)
						{
							return;
						}
					}
				}
				if (xTextInputFieldElement != null)
				{
					e.EditorControl.ExecuteCommand("InsertInputField", showUI: false, xTextInputFieldElement);
				}
			}
		}

		[WriterCommandDescription("GetSurplusLinesOfSpeifyPage", ReturnValueType = typeof(int))]
		protected void method_3(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = 0;
				if (e.EditorControl != null)
				{
					int pageIndex = WriterUtils.smethod_40(e.Parameter, e.Document.Pages.Count);
					e.Result = e.EditorControl.GetSurplusLinesOfSpeifyPage(pageIndex, 0f);
				}
			}
		}

		[WriterCommandDescription("InsertInputFieldWithDataSourceDescriptor")]
		protected void method_4(object sender, WriterCommandEventArgs e)
		{
			int num = 11;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.DocumentControler != null)
				{
					e.Enabled = e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextInputFieldElement));
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				DataSourceDescriptor dataSourceDescriptor = (DataSourceDescriptor)e.Parameter;
				if (dataSourceDescriptor != null)
				{
					XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.OwnerDocument = e.Document;
					dataSourceDescriptor.SetInputField(xTextInputFieldElement);
					e.Result = e.EditorControl.ExecuteCommand("InsertInputField", e.ShowUI, xTextInputFieldElement);
				}
			}
		}

		[WriterCommandDescription("EnvironmentConfig")]
		protected void method_5(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgDCEnvirmentConfig dlgDCEnvirmentConfig = new dlgDCEnvirmentConfig())
				{
					dlgDCEnvirmentConfig.ShowInTaskbar = false;
					WriterControl.UIShowDialog(e.EditorControl, dlgDCEnvirmentConfig, null);
				}
			}
		}

		[WriterCommandDescription("CommandNameSourceCode")]
		protected void method_6(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgGenerateCommandNameSourceCode dlgGenerateCommandNameSourceCode = new dlgGenerateCommandNameSourceCode())
				{
					dlgGenerateCommandNameSourceCode.AppHost = e.Host;
					WriterControl.UIShowDialog(e.EditorControl, dlgGenerateCommandNameSourceCode, null);
				}
			}
		}

		[WriterCommandDescription("ExecuteCommand", ShortcutKey = (Keys)65659)]
		protected void method_7(object sender, WriterCommandEventArgs e)
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
				string text = null;
				string parameter = null;
				bool showUI = e.ShowUI;
				if (e.Parameter != null)
				{
					text = Convert.ToString(text);
				}
				bool flag = false;
				if (e.ShowUI)
				{
					if (!method_8(e))
					{
						return;
					}
					using (dlgExecuteCommand dlgExecuteCommand = new dlgExecuteCommand())
					{
						dlgExecuteCommand.CommandName = text;
						dlgExecuteCommand.CmdControler = e.CommandControler;
						dlgExecuteCommand.AppHost = e.Host;
						dlgExecuteCommand.ShowResult = flag;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgExecuteCommand, null) != DialogResult.OK)
						{
							return;
						}
						text = dlgExecuteCommand.CommandName;
						parameter = dlgExecuteCommand.CommandParameter;
						showUI = dlgExecuteCommand.ShowUI;
						flag = dlgExecuteCommand.ShowResult;
					}
				}
				if (e.EditorControl != null)
				{
					e.Result = e.EditorControl.ExecuteCommand(text, showUI, parameter);
				}
				else
				{
					e.Result = e.CommandControler.InnerExecuteCommand(text, showUI, parameter);
				}
				if (flag && e.ShowUI)
				{
					if (e.Result == null)
					{
						e.Host.UITools.ShowMessageBox(e.EditorControl, WriterStrings.ReturnNull);
						return;
					}
					string string_ = Convert.ToString(e.Result);
					e.Host.UITools.ShowTextDialog(e.EditorControl, string_, null);
				}
			}
		}

		protected bool method_8(WriterCommandEventArgs writerCommandEventArgs_0)
		{
			bool result = true;
			string customAttribute = writerCommandEventArgs_0.EditorControl.GetCustomAttribute("PasswordForExecuteCommand");
			if (!string.IsNullOrEmpty(customAttribute))
			{
				using (dlgPasswordForExecuteCommand dlgPasswordForExecuteCommand = new dlgPasswordForExecuteCommand())
				{
					dlgPasswordForExecuteCommand.PasswordForExecuteCommand = customAttribute;
					if (WriterControl.UIShowDialog(writerCommandEventArgs_0.EditorControl, dlgPasswordForExecuteCommand, null) == DialogResult.OK)
					{
						return true;
					}
					return false;
				}
			}
			return result;
		}

		[WriterCommandDescription("InsertOldXML", ReturnValueType = typeof(XTextElementList))]
		protected void method_9(object sender, WriterCommandEventArgs e)
		{
			int num = 14;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.DocumentControler != null && e.Document != null && e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextElement)));
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
					XTextDocument xTextDocument = null;
					if (e.Parameter is string)
					{
						StringReader stringReader = new StringReader((string)e.Parameter);
						xTextDocument = (XTextDocument)e.Document.CreateElementByType(e.Document.GetType());
						xTextDocument.Load(stringReader, "OldXML", fastMode: true);
						stringReader.Close();
					}
					else if (e.Parameter is Stream)
					{
						xTextDocument = (XTextDocument)e.Document.CreateElementByType(e.Document.GetType());
						xTextDocument.Load((Stream)e.Parameter, "OldXML", fastMode: true);
					}
					else if (e.Parameter is TextReader)
					{
						xTextDocument = (XTextDocument)e.Document.CreateElementByType(e.Document.GetType());
						xTextDocument.Load((TextReader)e.Parameter, "OldXML", fastMode: true);
					}
					if (xTextDocument != null && xTextDocument.Body != null && xTextDocument.Body.Elements.Count > 0 && e.DocumentControler.vmethod_1(xTextDocument, e.ShowUI))
					{
						XTextElementList xTextElementList = xTextDocument.Body.Elements.Clone();
						e.Document.ImportElements(xTextElementList);
						e.DocumentControler.InsertElements(xTextElementList);
						e.Result = xTextElementList;
					}
				}
			}
		}

		[WriterCommandDescription("InsertShape", ImageResource = "DCSoft.Writer.Extension.Images.CommandInsertShape.bmp", ReturnValueType = typeof(XTextControlHostElement))]
		public void method_10(object sender, WriterCommandEventArgs e)
		{
			int num = 18;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.IsCommandEnabled("InsertControlHost"));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke && e.ShowUI)
			{
				using (dlgInsertShape dlgInsertShape = new dlgInsertShape())
				{
					if (WriterControl.UIShowDialog(e.EditorControl, dlgInsertShape, null) == DialogResult.OK)
					{
						e.Result = e.EditorControl.ExecuteCommand("InsertControlHost", showUI: false, dlgInsertShape.SelectedShapeTypeFullName);
					}
				}
			}
		}

		[WriterCommandDescription("SetDefaultEventExpression", ImageResource = "DCSoft.Writer.Extension.Images.CommandSetDefaultEventExpression.bmp", ReturnValueType = typeof(bool), DefaultResultValue = false)]
		public void method_11(object sender, WriterCommandEventArgs e)
		{
			int num = 1;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.EditorControl.GetCurrentElement(typeof(XTextInputFieldElement));
					if (xTextInputFieldElement != null && e.DocumentControler.CanModify(xTextInputFieldElement, DomAccessFlags.CheckControlReadonly | DomAccessFlags.CheckReadonly | DomAccessFlags.CheckPermission | DomAccessFlags.CheckFormView | DomAccessFlags.CheckLock | DomAccessFlags.CheckContentProtect | DomAccessFlags.CheckContainerReadonly))
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
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.EditorControl.GetCurrentElement(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement == null || !e.DocumentControler.CanModify(xTextInputFieldElement, DomAccessFlags.CheckControlReadonly | DomAccessFlags.CheckReadonly | DomAccessFlags.CheckPermission | DomAccessFlags.CheckFormView | DomAccessFlags.CheckLock | DomAccessFlags.CheckContentProtect | DomAccessFlags.CheckContainerReadonly))
				{
					return;
				}
				string text = null;
				if (e.Parameter != null)
				{
					text = Convert.ToString(e.Parameter);
				}
				if (string.IsNullOrEmpty(text))
				{
					text = xTextInputFieldElement.DefaultEventExpression;
				}
				if (e.ShowUI)
				{
					using (dlgDefaultEventExpression dlgDefaultEventExpression = new dlgDefaultEventExpression())
					{
						dlgDefaultEventExpression.WriterControl = e.EditorControl;
						dlgDefaultEventExpression.FieldElement = xTextInputFieldElement;
						dlgDefaultEventExpression.DefaultEventExpression = text;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgDefaultEventExpression, xTextInputFieldElement) != DialogResult.OK)
						{
							e.Result = false;
							return;
						}
						text = dlgDefaultEventExpression.DefaultEventExpression;
					}
				}
				if (text != xTextInputFieldElement.DefaultEventExpression && e.UIStartEditContent())
				{
					if (e.Document.BeginLogUndo())
					{
						e.Document.UndoList.AddProperty("DefaultEventExpression", xTextInputFieldElement.DefaultEventExpression, text, xTextInputFieldElement);
						e.Document.EndLogUndo();
					}
					xTextInputFieldElement.DefaultEventExpression = text;
					e.Result = true;
					e.RefreshLevel = UIStateRefreshLevel.None;
					xTextInputFieldElement.vmethod_43(bool_20: false);
					e.Document.Modified = true;
					e.Document.OnSelectionChanged();
					e.Document.OnDocumentContentChanged();
				}
			}
		}

		[WriterCommandDescription("SetListInputField")]
		public void method_12(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.Document.GetCurrentElement(typeof(XTextInputFieldElement));
					if (xTextInputFieldElement != null && e.DocumentControler.CanModify(xTextInputFieldElement))
					{
						e.Enabled = true;
					}
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.Document.GetCurrentElement(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement != null && e.DocumentControler.CanModify(xTextInputFieldElement) && e.ShowUI)
				{
					using (dlgInsertListInputField dlgInsertListInputField = new dlgInsertListInputField())
					{
						dlgInsertListInputField.Document = e.Document;
						dlgInsertListInputField.FieldElement = xTextInputFieldElement;
						dlgInsertListInputField.LogUndo = true;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgInsertListInputField, xTextInputFieldElement) == DialogResult.OK)
						{
							e.Document.Modified = true;
							e.Document.OnDocumentContentChanged();
							xTextInputFieldElement.EditorRefreshView();
							e.Result = xTextInputFieldElement;
						}
					}
				}
			}
		}

		[WriterCommandDescription("InsertListInputField")]
		public void method_13(object sender, WriterCommandEventArgs e)
		{
			int num = 13;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.IsCommandEnabled("InsertInputField"));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XTextInputFieldElement xTextInputFieldElement = e.Parameter as XTextInputFieldElement;
				if (xTextInputFieldElement == null)
				{
					xTextInputFieldElement = new XTextInputFieldElement();
				}
				xTextInputFieldElement.OwnerDocument = e.Document;
				e.Document.AllocElementID("lst", xTextInputFieldElement);
				if (e.ShowUI)
				{
					using (dlgInsertListInputField dlgInsertListInputField = new dlgInsertListInputField())
					{
						dlgInsertListInputField.Document = e.Document;
						dlgInsertListInputField.FieldElement = xTextInputFieldElement;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgInsertListInputField, xTextInputFieldElement) == DialogResult.OK)
						{
							xTextInputFieldElement = dlgInsertListInputField.FieldElement;
							if (xTextInputFieldElement != null)
							{
								e.Result = e.EditorControl.ExecuteCommand("InsertInputField", showUI: false, xTextInputFieldElement);
							}
						}
					}
				}
			}
		}

		[WriterCommandDescription("InsertSpecifyCharacter", ReturnValueType = typeof(bool), DefaultResultValue = false)]
		public void method_14(object sender, WriterCommandEventArgs e)
		{
			int num = 6;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.EditorControl != null && e.EditorControl.IsCommandEnabled("InsertString"));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				if (e.ShowUI)
				{
					using (dlgSpecifyCharacter dlgSpecifyCharacter = new dlgSpecifyCharacter())
					{
						if (WriterControl.UIShowDialog(e.EditorControl, dlgSpecifyCharacter, null) == DialogResult.OK)
						{
							XTextElementList xTextElementList = (XTextElementList)e.EditorControl.ExecuteCommand("InsertString", showUI: false, dlgSpecifyCharacter.SpecifyCharacter);
							e.Result = (xTextElementList != null && xTextElementList.Count > 0);
						}
					}
				}
			}
		}

		[WriterCommandDescription("ConvertFileFormatBatch")]
		public void method_15(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = true;
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.RefreshLevel = UIStateRefreshLevel.None;
				using (dlgFileFormatConvert dlgFileFormatConvert = new dlgFileFormatConvert())
				{
					dlgFileFormatConvert.ShowInTaskbar = false;
					WriterControl.UIShowDialog(e.EditorControl, dlgFileFormatConvert, null);
				}
			}
		}

		[WriterCommandDescription("SetDateTimeField")]
		public void method_16(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.Document.GetCurrentElement(typeof(XTextInputFieldElement));
					if (xTextInputFieldElement != null && e.DocumentControler.CanModify(xTextInputFieldElement))
					{
						e.Enabled = true;
					}
				}
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.Document.GetCurrentElement(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement != null && e.DocumentControler.CanModify(xTextInputFieldElement) && e.ShowUI)
				{
					using (dlgDateTimeFieldElement dlgDateTimeFieldElement = new dlgDateTimeFieldElement())
					{
						dlgDateTimeFieldElement.InputFieldElement = xTextInputFieldElement;
						dlgDateTimeFieldElement.LogUndo = true;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgDateTimeFieldElement, xTextInputFieldElement) == DialogResult.OK)
						{
							xTextInputFieldElement.EditorRefreshView();
							e.Document.Modified = true;
							e.Document.OnDocumentContentChanged();
							e.Result = xTextInputFieldElement;
						}
					}
				}
			}
		}

		[WriterCommandDescription("InsertDateTimeString", ImageResource = "DCSoft.Writer.Extension.Images.DateTime.bmp")]
		public void method_17(object sender, WriterCommandEventArgs e)
		{
			int num = 18;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.CommandControler != null && e.CommandControler.IsCommandEnabled("InsertString"));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				string text = e.Document.GetNowDateTime().ToString();
				if (e.ShowUI)
				{
					using (dlgCurrentDateTime dlgCurrentDateTime = new dlgCurrentDateTime())
					{
						dlgCurrentDateTime.CurrentDateTime = e.Document.GetNowDateTime();
						if (WriterControl.UIShowDialog(e.EditorControl, dlgCurrentDateTime, null) != DialogResult.OK)
						{
							return;
						}
						text = dlgCurrentDateTime.DateTimeString;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					e.EditorControl.ExecuteCommand("InsertString", showUI: false, text);
				}
			}
		}

		[WriterCommandDescription("TableCellProperties", ImageResource = "DCSoft.Writer.Extension.Images.CommandTableCellProperties.bmp", ReturnValueType = typeof(bool), DefaultResultValue = false)]
		public void method_18(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.Document == null)
				{
					e.Enabled = false;
					return;
				}
				XTextElementList handledCells = WriterCommandModuleTable.GetHandledCells(e.Document, firstOnly: true);
				e.Enabled = (handledCells != null && handledCells.Count > 0);
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				XTextElementList handledCells = WriterCommandModuleTable.GetHandledCells(e.Document, firstOnly: false);
				if (handledCells != null && handledCells.Count != 0 && e.UIStartEditContent())
				{
					ElementPropertiesEditEventArgs elementPropertiesEditEventArgs = new ElementPropertiesEditEventArgs();
					elementPropertiesEditEventArgs.Document = e.Document;
					elementPropertiesEditEventArgs.ContentEffect = ContentEffects.None;
					elementPropertiesEditEventArgs.Elements = handledCells;
					elementPropertiesEditEventArgs.Host = e.Host;
					elementPropertiesEditEventArgs.LogUndo = true;
					elementPropertiesEditEventArgs.Method = ElementPropertiesEditMethod.Edit;
					elementPropertiesEditEventArgs.ParentWindow = e.EditorControl;
					e.Document.BeginLogUndo();
					using (dlgTableCellProperties dlgTableCellProperties = new dlgTableCellProperties())
					{
						dlgTableCellProperties.SourceEventArgs = elementPropertiesEditEventArgs;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgTableCellProperties, handledCells[0]) == DialogResult.OK)
						{
							WriterCommandModule.ApplyElementPropertiesResult(elementPropertiesEditEventArgs, e);
							e.Result = true;
							e.RefreshLevel = UIStateRefreshLevel.All;
						}
					}
					e.Document.EndLogUndo();
				}
			}
		}

		[WriterCommandDescription("TableRowProperties", ImageResource = "DCSoft.Writer.Extension.Images.CommandTableRowProperties.bmp", DefaultResultValue = false)]
		public void method_19(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.Document == null)
				{
					e.Enabled = false;
					return;
				}
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)e.Document.GetCurrentElement(typeof(XTextTableRowElement));
				e.Enabled = (xTextTableRowElement != null && e.DocumentControler.CanModify(xTextTableRowElement));
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.ShowUI)
				{
					return;
				}
				e.Result = false;
				XTextElementList handledRows = WriterCommandModuleTable.GetHandledRows(e.Document, firstRowOnly: false);
				if (handledRows == null || handledRows.Count == 0)
				{
					return;
				}
				foreach (XTextTableRowElement item2 in handledRows)
				{
					if (!e.DocumentControler.CanModify(item2))
					{
						ContentProtectedInfo item = new ContentProtectedInfo(item2, string.Format(WriterStrings.CannotModifyElement_Name, WriterCommandModuleTable.GetRowDisplayID(item2)), ContentProtectedReason.None);
						GClass108 gClass = new GClass108();
						gClass.Add(item);
						e.Document.method_91(gClass);
						return;
					}
				}
				e.Result = false;
				if (e.UIStartEditContent())
				{
					ElementPropertiesEditEventArgs elementPropertiesEditEventArgs = null;
					if (e.Parameter is ElementPropertiesEditEventArgs)
					{
						elementPropertiesEditEventArgs = (ElementPropertiesEditEventArgs)e.Parameter;
					}
					else
					{
						elementPropertiesEditEventArgs = new ElementPropertiesEditEventArgs();
						elementPropertiesEditEventArgs.Elements = handledRows;
						elementPropertiesEditEventArgs.Document = e.Document;
						elementPropertiesEditEventArgs.Host = e.Host;
						elementPropertiesEditEventArgs.LogUndo = true;
						elementPropertiesEditEventArgs.Method = ElementPropertiesEditMethod.Edit;
						elementPropertiesEditEventArgs.ParentWindow = e.EditorControl;
					}
					e.Document.BeginLogUndo();
					using (dlgTableRowProperties dlgTableRowProperties = new dlgTableRowProperties())
					{
						dlgTableRowProperties.SourceEventArgs = elementPropertiesEditEventArgs;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgTableRowProperties, handledRows[0]) == DialogResult.OK)
						{
							WriterCommandModule.ApplyElementPropertiesResult(elementPropertiesEditEventArgs, e);
							if (dlgTableRowProperties.HeaderStyleModified)
							{
								e.EditorControl.RefreshDocumentExt(refreshSize: false, executeLayout: false);
							}
							e.Result = true;
							e.RefreshLevel = UIStateRefreshLevel.All;
						}
					}
					e.Document.EndLogUndo();
				}
			}
		}

		[WriterCommandDescription("TableProperties", ImageResource = "DCSoft.Writer.Extension.Images.CommandTableProperties.bmp", DefaultResultValue = false)]
		public void method_20(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				if (e.Document == null)
				{
					e.Enabled = false;
					return;
				}
				XTextTableElement xTextTableElement = (XTextTableElement)e.Document.GetCurrentElement(typeof(XTextTableElement));
				e.Enabled = (xTextTableElement != null && e.DocumentControler.CanModify(xTextTableElement));
			}
			else if (e.Mode == WriterCommandEventMode.Invoke)
			{
				e.Result = false;
				XTextTableElement xTextTableElement = (XTextTableElement)e.Document.GetCurrentElement(typeof(XTextTableElement));
				if (xTextTableElement != null && e.DocumentControler.CanModify(xTextTableElement) && e.UIStartEditContent())
				{
					ElementPropertiesEditEventArgs elementPropertiesEditEventArgs = new ElementPropertiesEditEventArgs();
					elementPropertiesEditEventArgs.Document = e.Document;
					elementPropertiesEditEventArgs.Element = xTextTableElement;
					elementPropertiesEditEventArgs.Host = e.Host;
					elementPropertiesEditEventArgs.LogUndo = true;
					elementPropertiesEditEventArgs.Method = ElementPropertiesEditMethod.Edit;
					elementPropertiesEditEventArgs.ParentWindow = e.EditorControl;
					e.Document.BeginLogUndo();
					using (dlgTableProperties dlgTableProperties = new dlgTableProperties())
					{
						dlgTableProperties.SourceEventArgs = elementPropertiesEditEventArgs;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgTableProperties, xTextTableElement) == DialogResult.OK)
						{
							WriterCommandModule.ApplyElementPropertiesResult(elementPropertiesEditEventArgs, e);
							e.Result = true;
							e.RefreshLevel = UIStateRefreshLevel.All;
						}
					}
					e.Document.EndLogUndo();
				}
			}
		}

		[WriterCommandDescription("ConvertContentToKBEntry", ImageResource = "DCSoft.Writer.Extension.Images.CommandInsertKBEntryBySelection.bmp")]
		public void method_21(object sender, WriterCommandEventArgs e)
		{
			int num = 7;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = (e.Document != null && e.Document.Selection.Length != 0);
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				string text = e.Document.Selection.Text;
				if (text == null || text.Trim().Length == 0 || !e.UIStartEditContent())
				{
					return;
				}
				text = text.Trim();
				KBEntry kBEntry = new KBEntry();
				kBEntry.ListItems = method_22(text);
				kBEntry.ID = "KB" + e.Document.GetNowDateTime().ToString("yyyyMMddHHmmss");
				kBEntry.Text = kBEntry.ID;
				kBEntry.Style = KBEntryStyle.List;
				if (e.ShowUI)
				{
					using (dlgInsertKBEntryByContent dlgInsertKBEntryByContent = new dlgInsertKBEntryByContent())
					{
						dlgInsertKBEntryByContent.AppHost = e.Host;
						dlgInsertKBEntryByContent.NewKBEntry = kBEntry;
						if (WriterControl.UIShowDialog(e.EditorControl, dlgInsertKBEntryByContent, null) != DialogResult.OK)
						{
							return;
						}
					}
				}
				else
				{
					e.Host.KBLibrary?.KBEntries.Add(kBEntry);
				}
				if (kBEntry.OwnerLevel == EntryOwnerLevel.Department)
				{
					CurrentDepartmentInfo currentDepartmentInfo = (CurrentDepartmentInfo)e.Host.Services.GetService(typeof(CurrentDepartmentInfo));
					if (currentDepartmentInfo != null)
					{
						kBEntry.OwnerID = currentDepartmentInfo.ID;
					}
				}
				else if (kBEntry.OwnerLevel == EntryOwnerLevel.User)
				{
					CurrentUserInfo currentUserInfo = (CurrentUserInfo)e.Host.Services.GetService(typeof(CurrentUserInfo));
					if (currentUserInfo != null)
					{
						kBEntry.OwnerID = currentUserInfo.ID;
					}
				}
				IKBStoreProvider iKBStoreProvider = (IKBStoreProvider)e.Host.Services.GetService(typeof(IKBStoreProvider));
				if (iKBStoreProvider != null)
				{
					KBStoreEventArgs kBStoreEventArgs = new KBStoreEventArgs();
					kBStoreEventArgs.Entry = kBEntry;
					kBStoreEventArgs.Parent = kBEntry.Parent;
					kBStoreEventArgs.Library = e.Host.KBLibrary;
					kBStoreEventArgs.Services = e.Host.Services;
					if (!iKBStoreProvider.Insert(kBStoreEventArgs))
					{
						if (kBEntry.Parent != null)
						{
							kBEntry.Parent.SubEntries.Remove(kBEntry);
						}
						return;
					}
				}
				e.EditorControl.ExecuteCommand("Delete", showUI: false, null);
				e.EditorControl.ExecuteCommand("InsertKBEntry", showUI: false, kBEntry);
				e.Result = kBEntry;
			}
		}

		private ListItemCollection method_22(string string_1)
		{
			int num = 7;
			ListItemCollection listItemCollection = new ListItemCollection();
			if (!string.IsNullOrEmpty(string_1))
			{
				string[] array = string_1.Split(',', ';', '、');
				string[] array2 = array;
				foreach (string text in array2)
				{
					string text2 = text.Trim();
					string value = text.Trim();
					int num2 = string_1.IndexOf("=");
					if (num2 > 0)
					{
						text2 = text.Substring(0, num2).Trim();
						value = text.Substring(num2 + 1).Trim();
					}
					ListItem listItem = new ListItem();
					listItem.Text = text2;
					listItem.Value = value;
					listItemCollection.Add(listItem);
				}
			}
			return listItemCollection;
		}

		[WriterCommandDescription("InsertMedicalExpression")]
		[Obsolete("请使用InsertNewMedicalExpression命令")]
		public void method_23(object sender, WriterCommandEventArgs e)
		{
			int num = 4;
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.DocumentControler != null)
				{
					e.Enabled = e.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextMedicalExpressionFieldElement));
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke || !e.UIStartEditContent())
				{
					return;
				}
				XTextMedicalExpressionFieldElement xTextMedicalExpressionFieldElement = null;
				if (e.Parameter is XTextMedicalExpressionFieldElement)
				{
					xTextMedicalExpressionFieldElement = (XTextMedicalExpressionFieldElement)e.Parameter;
				}
				if (xTextMedicalExpressionFieldElement == null)
				{
					xTextMedicalExpressionFieldElement = new XTextMedicalExpressionFieldElement();
					xTextMedicalExpressionFieldElement.OwnerDocument = e.Document;
					xTextMedicalExpressionFieldElement.EnableHighlight = EnableState.Disabled;
					xTextMedicalExpressionFieldElement.SetInnerTextFast("Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9");
				}
				e.Document.AllocElementID("exp", xTextMedicalExpressionFieldElement);
				if (e.ShowUI)
				{
					xTextMedicalExpressionFieldElement.OwnerDocument = e.Document;
					if (!WriterAppHost.smethod_4(e, xTextMedicalExpressionFieldElement, ElementPropertiesEditMethod.Insert))
					{
						xTextMedicalExpressionFieldElement.Dispose();
						xTextMedicalExpressionFieldElement = null;
					}
				}
				if (xTextMedicalExpressionFieldElement == null)
				{
					return;
				}
				XTextElement currentElement = e.Document.CurrentElement;
				xTextMedicalExpressionFieldElement.EditMode = false;
				xTextMedicalExpressionFieldElement.StyleIndex = currentElement.StyleIndex;
				xTextMedicalExpressionFieldElement.StartElement.StyleIndex = currentElement.StyleIndex;
				xTextMedicalExpressionFieldElement.EndElement.StyleIndex = currentElement.StyleIndex;
				if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.FourValues)
				{
					if (!string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
					{
						xTextMedicalExpressionFieldElement.SetInnerTextFast("2016/4/14,3,30,2016/4/14");
					}
				}
				else if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.FourValues1)
				{
					if (!string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
					{
						xTextMedicalExpressionFieldElement.SetInnerTextFast("Value1,Value2,Value3,Value4");
					}
				}
				else if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.FourValues2)
				{
					if (!string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
					{
						xTextMedicalExpressionFieldElement.SetInnerTextFast("Value1,Value2,Value3,Value4");
					}
				}
				else if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.ThreeValues)
				{
					if (!string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
					{
						xTextMedicalExpressionFieldElement.SetInnerTextFast("Value1,Value2,Value3");
					}
				}
				else if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.Pupil)
				{
					if (!string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
					{
						xTextMedicalExpressionFieldElement.SetInnerTextFast("Value1,Value2,Value3,Value4,Value5,Value6,Value7");
					}
				}
				else if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.LightPositioning)
				{
					if (!string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
					{
						xTextMedicalExpressionFieldElement.SetInnerTextFast("Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9");
					}
				}
				else if (xTextMedicalExpressionFieldElement.ExpressionStyle == MedicalExpressionStyle.FetalHeart && !string.IsNullOrEmpty(xTextMedicalExpressionFieldElement.Text))
				{
					xTextMedicalExpressionFieldElement.SetInnerTextFast("Value1,Value2,Value3,Value4,Value5,Value6");
				}
				foreach (XTextElement element in xTextMedicalExpressionFieldElement.Elements)
				{
					element.StyleIndex = currentElement.StyleIndex;
				}
				if (xTextMedicalExpressionFieldElement.ValueBinding != null && xTextMedicalExpressionFieldElement.ValueBinding.AutoUpdate)
				{
					xTextMedicalExpressionFieldElement.UpdateDataBindingExt(new UpdateDataBindingArgs(null, fastMode: true));
				}
				e.DocumentControler.InsertElement(xTextMedicalExpressionFieldElement);
				e.RefreshLevel = UIStateRefreshLevel.All;
				e.Result = xTextMedicalExpressionFieldElement;
			}
		}

		[WriterCommandDescription("EditKBEntry", ImageResource = "DCSoft.Writer.Extension.Images.CommandEditKBEntry.bmp", DefaultResultValue = false)]
		public void method_24(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.Document != null)
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.Document.GetCurrentElement(typeof(XTextInputFieldElement));
					if (xTextInputFieldElement != null && xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.ListSource != null && !string.IsNullOrEmpty(xTextInputFieldElement.FieldSettings.ListSource.SourceName) && e.Host.KBLibrary != null)
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
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)e.Document.GetCurrentElement(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement == null || xTextInputFieldElement.FieldSettings == null || xTextInputFieldElement.FieldSettings.ListSource == null)
				{
					return;
				}
				string sourceName = xTextInputFieldElement.FieldSettings.ListSource.SourceName;
				KBLibrary kBLibrary = e.Host.KBLibrary;
				if (kBLibrary != null)
				{
					KBEntry kBEntry = kBLibrary.SearchKBEntry(sourceName);
					if (kBEntry != null && kBEntry.Style == KBEntryStyle.List && e.UIStartEditContent() && e.ShowUI)
					{
						using (dlgEditKBEntry dlgEditKBEntry = new dlgEditKBEntry())
						{
							dlgEditKBEntry.KBEntry = kBEntry;
							dlgEditKBEntry.KBEntryIDReadonly = true;
							if (WriterControl.UIShowDialog(e.EditorControl, dlgEditKBEntry, null) == DialogResult.OK)
							{
								if (kBEntry.OwnerLevel == EntryOwnerLevel.Department)
								{
									CurrentDepartmentInfo currentDepartmentInfo = (CurrentDepartmentInfo)e.Host.Services.GetService(typeof(CurrentDepartmentInfo));
									if (currentDepartmentInfo != null)
									{
										kBEntry.OwnerID = currentDepartmentInfo.ID;
									}
								}
								else if (kBEntry.OwnerLevel == EntryOwnerLevel.User)
								{
									CurrentUserInfo currentUserInfo = (CurrentUserInfo)e.Host.Services.GetService(typeof(CurrentUserInfo));
									if (currentUserInfo != null)
									{
										kBEntry.OwnerID = currentUserInfo.ID;
									}
								}
								foreach (XTextInputFieldElement item in e.Document.GetElementsByType(typeof(XTextInputFieldElement)))
								{
									if (item.FieldSettings != null && item.FieldSettings.ListSource != null && item.FieldSettings.ListSource.SourceName == kBEntry.ID)
									{
										item.FieldSettings.ListSource.RuntimeItems = null;
									}
								}
								IKBStoreProvider iKBStoreProvider = (IKBStoreProvider)e.Host.Services.GetService(typeof(IKBStoreProvider));
								if (iKBStoreProvider != null)
								{
									KBStoreEventArgs kBStoreEventArgs = new KBStoreEventArgs();
									kBStoreEventArgs.Entry = kBEntry;
									kBStoreEventArgs.Library = kBLibrary;
									kBStoreEventArgs.Parent = kBEntry.Parent;
									kBStoreEventArgs.Services = e.Host.Services;
									if (iKBStoreProvider.Update(kBStoreEventArgs))
									{
										e.Result = true;
									}
								}
								else
								{
									e.Result = true;
								}
							}
						}
					}
				}
			}
		}

		[WriterCommandDescription("InsertObject", DefaultResultValue = false)]
		public void method_25(object sender, WriterCommandEventArgs e)
		{
			if (e.Mode == WriterCommandEventMode.QueryState)
			{
				e.Enabled = false;
				if (e.EditorControl != null && e.Parameter != null)
				{
					IDataObject dataObject = e.Parameter as IDataObject;
					if (dataObject == null)
					{
						dataObject = new DataObject();
						dataObject.SetData(e.Parameter);
					}
					CanInsertObjectEventArgs canInsertObjectEventArgs = new CanInsertObjectEventArgs(e.Document);
					canInsertObjectEventArgs.DataObject = dataObject;
					e.EditorControl.OnEventCanInsertObject(canInsertObjectEventArgs);
					e.Enabled = canInsertObjectEventArgs.Result;
				}
			}
			else
			{
				if (e.Mode != WriterCommandEventMode.Invoke)
				{
					return;
				}
				e.Result = false;
				if (e.EditorControl != null && e.Parameter != null && e.UIStartEditContent())
				{
					IDataObject dataObject = e.Parameter as IDataObject;
					if (dataObject == null)
					{
						dataObject = new DataObject();
						dataObject.SetData(e.Parameter);
					}
					InsertObjectEventArgs insertObjectEventArgs = new InsertObjectEventArgs(e.Document);
					if (e.EditorControl != null)
					{
						insertObjectEventArgs.AllowDataFormats = e.EditorControl.AcceptDataFormats;
					}
					insertObjectEventArgs.DataObject = dataObject;
					insertObjectEventArgs.ShowUI = e.ShowUI;
					e.EditorControl.OnEventInsertObject(insertObjectEventArgs);
					e.Result = insertObjectEventArgs.Result;
				}
			}
		}
	}
}
