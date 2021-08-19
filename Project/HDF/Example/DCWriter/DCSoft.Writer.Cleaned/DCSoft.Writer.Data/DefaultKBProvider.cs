using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       默认的知识库提供者对象
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DefaultKBProvider : IKBProvider
	{
		/// <summary>
		///       获得子知识节点列表
		///       </summary>
		/// <param name="host">宿主对象</param>
		/// <param name="root">根知识点节点</param>
		/// <returns>获得的子知识点列表</returns>
		public virtual KBEntryList GetSubEntries(WriterAppHost host, KBEntry root)
		{
			if (root == null)
			{
				return ((KBLibrary)host.Services.GetService(typeof(KBLibrary)))?.KBEntries;
			}
			return root.SubEntries;
		}

		/// <summary>
		///       根据知识节点信息创建文档元素对象
		///       </summary>
		/// <param name="args">参数</param>
		public virtual void CreateElements(CreateElementsByKBEntryEventArgs args)
		{
			int num = 7;
			KBLibrary kBLibrary = (KBLibrary)args.Host.Services.GetService(typeof(KBLibrary));
			XTextElementList xTextElementList = new XTextElementList();
			if (args.KBEntry.SubEntries == null || args.KBEntry.SubEntries.Count == 0)
			{
				if (args.KBEntry.Style == KBEntryStyle.List || args.KBEntry.Style == KBEntryStyle.ListSQL)
				{
					XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.BackgroundText = args.KBEntry.Text;
					xTextInputFieldElement.ID = args.KBEntry.ID;
					xTextInputFieldElement.ToolTip = args.KBEntry.Text;
					if (string.IsNullOrEmpty(args.KBEntry.Name))
					{
						if (string.IsNullOrEmpty(xTextInputFieldElement.ID))
						{
							xTextInputFieldElement.Name = args.KBEntry.Text;
						}
						else
						{
							xTextInputFieldElement.Name = xTextInputFieldElement.ID;
						}
					}
					else
					{
						xTextInputFieldElement.Name = args.KBEntry.Name;
					}
					xTextInputFieldElement.FieldSettings = new InputFieldSettings();
					xTextInputFieldElement.FieldSettings.ListSource = new ListSourceInfo();
					xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DropdownList;
					if (args.KBEntry.Style == KBEntryStyle.MultiList)
					{
						xTextInputFieldElement.FieldSettings.MultiSelect = true;
					}
					string text = args.KBEntry.ID;
					if (string.IsNullOrEmpty(text))
					{
						text = args.KBEntry.Value;
					}
					xTextInputFieldElement.FieldSettings.ListSource.SourceName = text;
					if (args.KBEntry.ListItems != null && args.KBEntry.ListItems.Count > 0)
					{
						if (args.KBEntry.CopyListItems)
						{
							xTextInputFieldElement.FieldSettings.ListSource.Items = args.KBEntry.ListItems.Clone();
						}
						else
						{
							xTextInputFieldElement.FieldSettings.ListSource.RuntimeItems = args.KBEntry.ListItems;
						}
					}
					xTextInputFieldElement.UserEditable = false;
					DocumentContentStyle contentStyleForNewString = args.Document.CurrentStyleInfo.ContentStyleForNewString;
					xTextInputFieldElement.StyleIndex = args.Document.ContentStyles.GetStyleIndex(contentStyleForNewString);
					if (!string.IsNullOrEmpty(args.KBEntry.Text))
					{
						bool flag = true;
						if (args.KBEntry.ListItems != null)
						{
							foreach (ListItem listItem in args.KBEntry.ListItems)
							{
								if (listItem.Text != null && listItem.Text.IndexOf(args.KBEntry.Text) >= 0)
								{
									flag = false;
									break;
								}
							}
						}
						if (flag)
						{
							xTextElementList.AddRange(args.Document.CreateTextElements(args.KBEntry.Text, null, contentStyleForNewString));
						}
					}
					xTextElementList.Add(xTextInputFieldElement);
				}
				else if (args.KBEntry.Style == KBEntryStyle.CheckBoxList || args.KBEntry.Style == KBEntryStyle.RadioList)
				{
					if (args.KBEntry.ListItems != null && args.KBEntry.ListItems.Count > 0)
					{
						DocumentContentStyle contentStyleForNewString = args.Document.CurrentStyleInfo.ContentStyleForNewString;
						int styleIndex = args.Document.ContentStyles.GetStyleIndex(contentStyleForNewString);
						int num2 = -1;
						string text2 = args.KBEntry.Name;
						if (string.IsNullOrEmpty(text2))
						{
							text2 = args.KBEntry.ID;
						}
						foreach (ListItem listItem2 in args.KBEntry.ListItems)
						{
							num2++;
							string text3 = listItem2.TextInList;
							if (string.IsNullOrEmpty(text3))
							{
								text3 = listItem2.Text;
							}
							string text4 = listItem2.Value;
							if (string.IsNullOrEmpty(text4))
							{
								text4 = text3;
							}
							if (args.KBEntry.Style == KBEntryStyle.CheckBoxList)
							{
								XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)args.Document.CreateElementByType(typeof(XTextCheckBoxElement));
								xTextCheckBoxElement.Name = text2;
								xTextCheckBoxElement.Caption = text3;
								xTextCheckBoxElement.CheckedValue = text4;
								xTextCheckBoxElement.StyleIndex = styleIndex;
								xTextCheckBoxElement.ID = xTextCheckBoxElement.Name + "_" + num2;
								xTextElementList.Add(xTextCheckBoxElement);
							}
							else
							{
								XTextRadioBoxElement xTextRadioBoxElement = (XTextRadioBoxElement)args.Document.CreateElementByType(typeof(XTextRadioBoxElement));
								xTextRadioBoxElement.Name = text2;
								xTextRadioBoxElement.Caption = text3;
								xTextRadioBoxElement.CheckedValue = text4;
								xTextRadioBoxElement.StyleIndex = styleIndex;
								xTextRadioBoxElement.ID = xTextRadioBoxElement.Name + "_" + num2;
								xTextElementList.Add(xTextRadioBoxElement);
							}
						}
					}
				}
				else if (args.KBEntry.Style == KBEntryStyle.InputField || args.KBEntry.Style == KBEntryStyle.DateTimeField || args.KBEntry.Style == KBEntryStyle.NumberField)
				{
					XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.BackgroundText = args.KBEntry.Text;
					xTextInputFieldElement.ID = args.KBEntry.ID;
					if (string.IsNullOrEmpty(args.KBEntry.Name))
					{
						if (string.IsNullOrEmpty(xTextInputFieldElement.ID))
						{
							xTextInputFieldElement.Name = args.KBEntry.Text;
						}
						else
						{
							xTextInputFieldElement.Name = xTextInputFieldElement.ID;
						}
					}
					else
					{
						xTextInputFieldElement.Name = args.KBEntry.Name;
					}
					xTextInputFieldElement.FieldSettings = new InputFieldSettings();
					if (args.KBEntry.Style == KBEntryStyle.DateTimeField)
					{
						xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.DateTime;
					}
					else if (args.KBEntry.Style == KBEntryStyle.NumberField)
					{
						xTextInputFieldElement.FieldSettings.EditStyle = InputFieldEditStyle.Numeric;
					}
					DocumentContentStyle contentStyleForNewString = args.Document.CurrentStyleInfo.ContentStyleForNewString;
					xTextInputFieldElement.StyleIndex = args.Document.ContentStyles.GetStyleIndex(contentStyleForNewString);
					if (!string.IsNullOrEmpty(args.KBEntry.Value))
					{
						xTextInputFieldElement.SetInnerTextFast(args.KBEntry.Value);
						xTextInputFieldElement.InnerValue = args.KBEntry.Value;
					}
					if (!string.IsNullOrEmpty(args.KBEntry.Text))
					{
						xTextElementList.AddRange(args.Document.CreateTextElements(args.KBEntry.Text, null, contentStyleForNewString));
					}
					xTextElementList.Add(xTextInputFieldElement);
				}
				else if (args.KBEntry.Style == KBEntryStyle.Template)
				{
					try
					{
						string text5 = args.KBEntry.Value;
						if (string.IsNullOrEmpty(text5))
						{
							text5 = args.KBEntry.ID;
						}
						string string_ = kBLibrary.TemplateFileFormat;
						byte[] array = vmethod_0(args, args.Host, text5, ref string_, kBLibrary.TemplateFileSystemName, kBLibrary.TemplateFileSystem, args.KBEntry);
						if (array != null && array.Length > 0)
						{
							if (string_ == null)
							{
								string_ = args.Host.ContentSerializers.DefaultSerializer.Name;
							}
							XTextDocument xTextDocument = (XTextDocument)args.Document.Clone(Deeply: false);
							MemoryStream memoryStream = new MemoryStream(array);
							xTextDocument.Load(memoryStream, string_, fastMode: false);
							if (args.Host.Debuger != null)
							{
								args.Host.Debuger.DebugLoadFileComplete((int)memoryStream.Length);
							}
							memoryStream.Close();
							XDependencyObject.CopyValueFast(args.Document.ContentStyles.Default, xTextDocument.ContentStyles.Default, overWrite: true);
							xTextDocument.ContentStyles.HandleAfterLoad();
							xTextDocument.CommitUserTrace();
							if (xTextDocument.Body.Elements.Count > 1)
							{
								XTextElementList xTextElementList2 = new XTextElementList();
								xTextElementList2.AddRange(xTextDocument.Body.Elements);
								WriterUtils.RemoveAutoCreateParagraphFlag(xTextElementList2);
								if (xTextElementList2.LastElement is XTextParagraphFlagElement)
								{
									xTextElementList2.RemoveAt(xTextElementList2.Count - 1);
								}
								if (xTextElementList2.Count > 0)
								{
									args.Document.ImportElements(xTextElementList2);
									xTextElementList.AddRange(xTextElementList2);
								}
							}
						}
					}
					catch (Exception ex)
					{
						if (args.Host.Debuger != null)
						{
							args.Host.Debuger.WriteLine(ex.Message);
						}
					}
				}
			}
			args.Result = xTextElementList;
			args.Handled = true;
		}

		public virtual byte[] vmethod_0(CreateElementsByKBEntryEventArgs createElementsByKBEntryEventArgs_0, WriterAppHost writerAppHost_0, string string_0, ref string string_1, string string_2, IFileSystem ifileSystem_0, KBEntry kbentry_0)
		{
			KBLibrary kBLibrary = (KBLibrary)writerAppHost_0.Services.GetService(typeof(KBLibrary));
			if (kBLibrary != null && kBLibrary.LoadEntryTemplateContentHandler != null)
			{
				KBEntryLoadTemplateContentEventArgs kBEntryLoadTemplateContentEventArgs = new KBEntryLoadTemplateContentEventArgs(kBLibrary, kbentry_0);
				kBEntryLoadTemplateContentEventArgs.Format = string_1;
				kBLibrary.LoadEntryTemplateContentHandler(this, kBEntryLoadTemplateContentEventArgs);
				if (kBEntryLoadTemplateContentEventArgs.Result)
				{
					string_1 = kBEntryLoadTemplateContentEventArgs.Format;
					return kBEntryLoadTemplateContentEventArgs.Content;
				}
				return null;
			}
			string fileName = string_0;
			if (!string.IsNullOrEmpty(kBLibrary.TemplateSourceFormatString))
			{
				fileName = string.Format(kBLibrary.TemplateSourceFormatString, string_0);
				fileName = kBLibrary.CombinRumtimeBaseURL(fileName);
			}
			WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(createElementsByKBEntryEventArgs_0.WriterControl, createElementsByKBEntryEventArgs_0.Document, createElementsByKBEntryEventArgs_0.Element, fileName, string_2);
			writerReadFileContentEventArgs.FileSystem = kBLibrary.TemplateFileSystem;
			writerReadFileContentEventArgs.FileFormat = kBLibrary.TemplateFileFormat;
			byte[] result = WriterControl.ReadFileContent(createElementsByKBEntryEventArgs_0.WriterControl, writerReadFileContentEventArgs);
			string_1 = writerReadFileContentEventArgs.FileFormat;
			return result;
		}
	}
}
