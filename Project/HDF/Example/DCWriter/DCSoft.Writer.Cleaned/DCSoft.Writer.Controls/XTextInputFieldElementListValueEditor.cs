using DCSoft.Common;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       列表方式的文本输入域编辑器对象
	///       </summary>
	[ComVisible(false)]
	internal class XTextInputFieldElementListValueEditor : ElementValueEditor
	{
		/// <summary>
		///       获得编辑样式
		///       </summary>
		/// <param name="host">
		/// </param>
		/// <param name="context">
		/// </param>
		/// <returns>
		/// </returns>
		public override ElementValueEditorEditStyle GetEditStyle(TextWindowsFormsEditorHost host, ElementValueEditContext context)
		{
			return ElementValueEditorEditStyle.DropDown;
		}

		/// <summary>
		///       编辑数值
		///       </summary>
		/// <param name="host">宿主对象</param>
		/// <param name="context">上下文对象</param>
		/// <returns>操作是否成功</returns>
		public override ElementValueEditResult EditValue(TextWindowsFormsEditorHost host, ElementValueEditContext context)
		{
			if (host.EditControl.Modified)
			{
			}
			if (context.WriterControl == null)
			{
			}
			GClass124 gClass = new GClass124();
			gClass.method_3(host.EditControl);
			gClass.method_5(host.Document);
			gClass.method_7(context.Element);
			gClass.method_17(host);
			gClass.method_19(context);
			gClass.method_9(_Work_DoWork);
			gClass.method_11(_Work_Complete);
			gClass.method_23(GEnum17.const_3);
			gClass.method_12();
			if (context.WriterControl != null && context.WriterControl.InnerViewControl != null)
			{
				context.WriterControl.InnerViewControl.method_162(context.Element);
			}
			return ElementValueEditResult.OpeingUI;
		}

		private void _Work_DoWork(object sender, GClass125 args)
		{
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)args.method_0().method_6();
			ElementEventTemplateList events = xTextInputFieldElement.Events;
			if (events != null && events.HasBeforeDropDown)
			{
				ElementCancelEventArgs elementCancelEventArgs = new ElementCancelEventArgs(xTextInputFieldElement);
				events.OnBeforeDropDown(this, elementCancelEventArgs);
				if (elementCancelEventArgs.Cancel)
				{
					return;
				}
			}
			InputFieldSettings fieldSettings = xTextInputFieldElement.FieldSettings;
			ListSourceInfo listSource = xTextInputFieldElement.FieldSettings.ListSource;
			if (fieldSettings.DynamicListItems || (listSource != null && (!listSource.IsEmpty || (listSource.RuntimeItems != null && listSource.RuntimeItems.Count != 0))))
			{
				ListItemCollection object_ = xTextInputFieldElement.method_36(xTextInputFieldElement.SelectedSpellCode, bool_26: true, null);
				args.method_2(object_);
			}
		}

		private void _Work_Complete(object sender, GClass125 args)
		{
			int num = 13;
			TextWindowsFormsEditorHost host = (TextWindowsFormsEditorHost)args.method_0().method_16();
			ElementValueEditContext tag = (ElementValueEditContext)args.method_0().method_18();
			XTextInputFieldElement field = (XTextInputFieldElement)args.method_0().method_6();
			InputFieldSettings fieldSettings = field.FieldSettings;
			host.EditControl.Focus();
			host.EditControl.InnerViewControl.method_162(null);
			if ((!field.Focused || !field.WriterControl.ContainsFocus) && field.OwnerDocument.CurrentElement != field.StartElement)
			{
				return;
			}
			ListItemCollection listItemCollection = (ListItemCollection)args.method_1();
			if (listItemCollection == null)
			{
				listItemCollection = new ListItemCollection();
			}
			AddLastSelectedListItems(listItemCollection, field);
			if (listItemCollection != null && listItemCollection.Count != 0)
			{
				string value = field.InnerValue;
				if (string.IsNullOrEmpty(value))
				{
					value = field.Text;
				}
				try
				{
					XTreeListBoxEditControl2 xtreeListBoxEditControl2_0 = new XTreeListBoxEditControl2();
					try
					{
						xtreeListBoxEditControl2_0.EditorHost = host;
						xtreeListBoxEditControl2_0.ListBox.method_68(-1);
						if (listItemCollection != null)
						{
							string text = null;
							foreach (ListItem item in listItemCollection)
							{
								if (fieldSettings.RepulsionForGroup && !string.IsNullOrEmpty(text) && item.Group != text)
								{
									GClass290 gClass = new GClass290();
									gClass.method_1(GEnum69.const_1);
									xtreeListBoxEditControl2_0.ListBox.method_8().Add(gClass);
								}
								text = item.Group;
								GClass290 gClass2 = new GClass290();
								if (!string.IsNullOrEmpty(item.TextInList))
								{
									gClass2.method_3(item.TextInList);
								}
								else
								{
									gClass2.method_3(item.Text);
								}
								gClass2.method_6(item.RuntimeValue);
								gClass2.method_28(item);
								gClass2.method_8(item.Group);
								gClass2.method_14(item.LonelyChecked);
								string runtimeSpellCode = item.RuntimeSpellCode;
								if (!string.IsNullOrEmpty(runtimeSpellCode))
								{
									gClass2.method_32(runtimeSpellCode.ToUpper());
								}
								gClass2.method_42(bool_5: false);
								xtreeListBoxEditControl2_0.ListBox.method_8().Add(gClass2);
							}
						}
						if (!string.IsNullOrEmpty(field.FieldSettings.ListValueSeparatorChar))
						{
							xtreeListBoxEditControl2_0.ListBox.method_36(field.FieldSettings.RuntimeListValueSeparator);
						}
						xtreeListBoxEditControl2_0.ListBox.method_28(bool_14: false);
						xtreeListBoxEditControl2_0.ListBox.method_15(bool_14: false);
						xtreeListBoxEditControl2_0.ListBox.method_44(bool_14: false);
						xtreeListBoxEditControl2_0.ListBox.method_11(fieldSettings.MultiSelect);
						xtreeListBoxEditControl2_0.ListBox.method_3(fieldSettings.MultiColumn);
						xtreeListBoxEditControl2_0.ListBox.method_1(fieldSettings.RepulsionForGroup);
						xtreeListBoxEditControl2_0.ButtonVisible = fieldSettings.MultiSelect;
						host.EditControl.InnerViewControl.method_226(xtreeListBoxEditControl2_0.ListBox, bool_47: true);
						if (field.FieldSettings != null && field.FieldSettings.DynamicListItems)
						{
							xtreeListBoxEditControl2_0.ListBox.method_125(bool_14: true);
						}
						if (field.FieldSettings.DynamicListItems)
						{
							xtreeListBoxEditControl2_0.ListBox.Tag = tag;
							xtreeListBoxEditControl2_0.ListBox.method_122(ListBox_SpellTextChanged);
						}
						ParseSelectedValue(host.EditControl, field, xtreeListBoxEditControl2_0.ListBox, field.FieldSettings.ListValueFormatString, value);
						xtreeListBoxEditControl2_0.ListBox.method_13(bool_14: false);
						xtreeListBoxEditControl2_0.ListBox.method_110(bool_14: false);
						string text2 = field.Text;
						string innerValue = field.InnerValue;
						if (field.AutoSetSpellCodeInDropdownList && !string.IsNullOrEmpty(text2))
						{
							StringBuilder stringBuilder = new StringBuilder();
							string text3 = text2;
							foreach (char c in text3)
							{
								if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
								{
									stringBuilder.Append(char.ToUpper(c));
								}
							}
							GClass290 gClass3 = xtreeListBoxEditControl2_0.ListBox.method_57(stringBuilder.ToString());
							if (gClass3 != null)
							{
								xtreeListBoxEditControl2_0.ListBox.method_79(gClass3);
							}
						}
						if (!xtreeListBoxEditControl2_0.ListBox.method_53() && !string.IsNullOrEmpty(field.DefaultSelectedIndexs))
						{
							int[] int_ = StringConvertHelper.ToInt32Values(field.DefaultSelectedIndexs);
							xtreeListBoxEditControl2_0.ListBox.method_73(int_);
						}
						xtreeListBoxEditControl2_0.Modified = false;
						xtreeListBoxEditControl2_0.ListBox.method_121(field.SelectedSpellCode);
						if (xtreeListBoxEditControl2_0.method_0())
						{
							string lastSpellCode = xtreeListBoxEditControl2_0.ListBox.method_120();
							field.SelectedSpellCode = null;
							string text4 = null;
							string newValue = null;
							text4 = FormatSelectedValue(host.EditControl, field, xtreeListBoxEditControl2_0.ListBox, field.FieldSettings.ListValueFormatString, getText: true);
							newValue = FormatSelectedValue(host.EditControl, field, xtreeListBoxEditControl2_0.ListBox, field.FieldSettings.ListValueFormatString, getText: false);
							if (field.Text != text4)
							{
								int num2 = -1;
								StringBuilder stringBuilder2 = new StringBuilder();
								ListItemCollection listItemCollection2 = new ListItemCollection();
								foreach (GClass290 item2 in xtreeListBoxEditControl2_0.ListBox.method_8())
								{
									num2++;
									if (xtreeListBoxEditControl2_0.ListBox.method_10())
									{
										if (!item2.method_15())
										{
											continue;
										}
									}
									else if (!item2.method_17())
									{
										continue;
									}
									if (item2.method_27() is ListItem)
									{
										listItemCollection2.Add((ListItem)item2.method_27());
										if (stringBuilder2.Length > 0)
										{
											stringBuilder2.Append(",");
										}
										stringBuilder2.Append(num2.ToString());
									}
								}
								WriterBeforeFieldContentEditEventArgs writerBeforeFieldContentEditEventArgs = new WriterBeforeFieldContentEditEventArgs(field, stringBuilder2.ToString(), listItemCollection2, "XTextInputFieldElementListValueEditor");
								writerBeforeFieldContentEditEventArgs.NewText = text4;
								writerBeforeFieldContentEditEventArgs.NewValue = newValue;
								host.EditControl.method_55(writerBeforeFieldContentEditEventArgs);
								if (!writerBeforeFieldContentEditEventArgs.Cancel)
								{
									text4 = writerBeforeFieldContentEditEventArgs.NewText;
									newValue = writerBeforeFieldContentEditEventArgs.NewValue;
									if (field.OwnerDocument.UIStartEditContent())
									{
										host.Document.BeginLogUndo();
										field.eventHandler_0 = delegate
										{
											int num3 = 6;
											if (field.InnerValue != newValue)
											{
												if (host.Document.CanLogUndo)
												{
													host.Document.UndoList.AddProperty("InnerValue", field.InnerValue, newValue, field);
												}
												field.InnerValue = newValue;
											}
											if (!WriterUtils.smethod_43(field.SelectedSpellCode, lastSpellCode))
											{
												if (host.Document.CanLogUndo)
												{
													host.Document.UndoList.AddProperty("SelectedSpellCode", field.SelectedSpellCode, lastSpellCode, field);
												}
												field.SelectedSpellCode = lastSpellCode;
											}
											int num4 = xtreeListBoxEditControl2_0.ListBox.method_67();
											if (field.SelectedIndex != num4)
											{
												if (host.Document.CanLogUndo)
												{
													host.Document.UndoList.AddProperty("SelectedIndex", field.SelectedIndex, num4, field);
												}
												field.SelectedIndex = num4;
											}
											field.OwnerDocument.CopySourceExecuter.imethod_2(field);
										};
										SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
										setContainerTextArgs.NewText = text4;
										setContainerTextArgs.AccessFlags = (DomAccessFlags)MathCommon.smethod_25(255, 2, bool_0: false);
										setContainerTextArgs.ShowUI = true;
										setContainerTextArgs.LogUndo = true;
										setContainerTextArgs.DisablePermission = false;
										setContainerTextArgs.UpdateContent = true;
										setContainerTextArgs.RaiseDocumentContentChangedEvent = true;
										setContainerTextArgs.FocusContainer = true;
										setContainerTextArgs.EventSource = ContentChangedEventSource.ValueEditor;
										if (field.SetEditorText(setContainerTextArgs))
										{
											if (field.EnableLastSelectedListItems)
											{
												field.LastSelectedListItems = listItemCollection2;
											}
											host.Document.EndLogUndo();
											host.RaiseDocumentContentChangedOnceAfterEditValue = true;
											WriterAfterFieldContentEditEventArgs writerAfterFieldContentEditEventArgs_ = new WriterAfterFieldContentEditEventArgs(field, stringBuilder2.ToString(), listItemCollection2, "XTextInputFieldElementListValueEditor", text2, innerValue);
											writerBeforeFieldContentEditEventArgs.NewText = text4;
											writerBeforeFieldContentEditEventArgs.NewValue = newValue;
											host.EditControl.method_56(writerAfterFieldContentEditEventArgs_);
											host.EditControl.Focus();
											host.EditControl.method_14(field);
										}
										else
										{
											host.Document.CancelLogUndo();
										}
									}
								}
							}
						}
					}
					finally
					{
						if (xtreeListBoxEditControl2_0 != null)
						{
							((IDisposable)xtreeListBoxEditControl2_0).Dispose();
						}
					}
				}
				finally
				{
				}
			}
		}

		private void ListBox_SpellTextChanged(object sender, CancelEventArgs e)
		{
			GControl5 gControl = (GControl5)sender;
			ElementValueEditContext elementValueEditContext = (ElementValueEditContext)gControl.Tag;
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)elementValueEditContext.Element;
			WriterControl editorControl = xTextInputFieldElement.OwnerDocument.EditorControl;
			ListItemCollection listItemCollection = new ListItemCollection();
			List<GClass290> list = new List<GClass290>();
			if (gControl.method_10())
			{
				foreach (GClass290 item in gControl.method_8())
				{
					if (item.method_15())
					{
						list.Add(item);
					}
				}
			}
			ListItemCollection listItemCollection2 = xTextInputFieldElement.method_36(gControl.method_120(), bool_26: true, null);
			if (listItemCollection2 == null)
			{
				listItemCollection2 = new ListItemCollection();
			}
			gControl.method_8().Clear();
			gControl.method_8().AddRange(list);
			if (listItemCollection2 != null && listItemCollection2.Count > 0)
			{
				foreach (ListItem item2 in listItemCollection2)
				{
					GClass290 gClass = new GClass290();
					gClass.method_3(string.IsNullOrEmpty(item2.TextInList) ? item2.Text : item2.TextInList);
					gClass.method_6(item2.RuntimeValue);
					gClass.method_28(item2);
					gClass.method_8(item2.Group);
					gClass.method_14(item2.LonelyChecked);
					string runtimeSpellCode = item2.RuntimeSpellCode;
					if (!string.IsNullOrEmpty(runtimeSpellCode))
					{
						gClass.method_32(runtimeSpellCode.ToUpper());
					}
					if (xTextInputFieldElement.EnableLastSelectedListItems && xTextInputFieldElement.LastSelectedListItems != null && xTextInputFieldElement.LastSelectedListItems.Count > 0)
					{
						foreach (ListItem item3 in listItemCollection)
						{
							if (item3.Text == item2.Text && item3.Value == item2.Value && item3.Text2 == item2.Text2 && item3.TextInList == item2.TextInList)
							{
								gClass.method_18(bool_5: true);
								gClass.method_16(bool_5: true);
							}
						}
					}
					gClass.method_42(bool_5: false);
					gControl.method_8().Add(gClass);
				}
				string innerValue = xTextInputFieldElement.InnerValue;
				if (string.IsNullOrEmpty(innerValue))
				{
					innerValue = xTextInputFieldElement.Text;
				}
			}
			foreach (GClass290 item4 in list)
			{
				item4.method_16(bool_5: true);
				item4.method_18(bool_5: true);
			}
			TextWindowsFormsEditorHost editorHost = editorControl.EditorHost;
			editorHost.method_2();
			gControl.method_68(-1);
			gControl.method_68(0);
		}

		private void AddLastSelectedListItems(ListItemCollection list, XTextInputFieldElement field)
		{
			if (field.EnableLastSelectedListItems && field.LastSelectedListItems != null && field.LastSelectedListItems.Count > 0)
			{
				if (list == null)
				{
					list = new ListItemCollection();
				}
				ListItemCollection listItemCollection = new ListItemCollection();
				foreach (ListItem lastSelectedListItem in field.LastSelectedListItems)
				{
					bool flag = false;
					if (string.IsNullOrEmpty(lastSelectedListItem.Value))
					{
						foreach (ListItem item in list)
						{
							if (item.Text == lastSelectedListItem.Text)
							{
								flag = true;
								break;
							}
						}
					}
					else
					{
						foreach (ListItem item2 in list)
						{
							if (item2.Value == lastSelectedListItem.Value)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						listItemCollection.Add(lastSelectedListItem);
					}
				}
				list.InsertRange(0, listItemCollection);
			}
		}

		internal static void ParseSelectedValue(WriterControl writerControl_0, XTextElement element, GControl5 gcontrol5_0, string formatString, string Value)
		{
			List<string> list = new List<string>();
			foreach (GClass290 item in gcontrol5_0.method_8())
			{
				list.Add(Convert.ToString(item.method_5()));
			}
			string[] string_ = ParseSelectedValue(writerControl_0, element, list, gcontrol5_0.method_35(), formatString, Value);
			if (gcontrol5_0.method_10())
			{
				gcontrol5_0.method_83(string_);
			}
			else
			{
				gcontrol5_0.method_89(string_);
			}
		}

		internal static string[] ParseSelectedValue(WriterControl writerControl_0, XTextElement element, List<string> allValues, string itemSpliter, string formatString, string Value)
		{
			int num = 5;
			ParseSelectedItemsEventArgs parseSelectedItemsEventArgs = new ParseSelectedItemsEventArgs(writerControl_0, formatString, writerControl_0?.Document, element, Value, allValues.ToArray(), itemSpliter);
			if (!string.IsNullOrEmpty(Value))
			{
				if (string.IsNullOrEmpty(formatString))
				{
					parseSelectedItemsEventArgs.Result = StringConvertHelper.Split(Value, itemSpliter);
				}
				else
				{
					string[] array = VariableString.AnalyseVariableString(formatString, "[", "]");
					for (int i = 0; i < array.Length; i++)
					{
						string strA = array[i];
						if (i % 2 != 1 || string.Compare(strA, "IncludeList", ignoreCase: true) != 0)
						{
							continue;
						}
						string text = array[i - 1];
						if (!string.IsNullOrEmpty(text))
						{
							int num2 = Value.IndexOf(text);
							if (num2 >= 0)
							{
								Value = Value.Substring(num2 + text.Length);
							}
						}
						if (i < array.Length - 1)
						{
							string value = array[i + 1];
							int num2 = Value.IndexOf(value);
							if (num2 >= 0)
							{
								Value = Value.Substring(0, num2);
							}
						}
						parseSelectedItemsEventArgs.Result = StringConvertHelper.Split(Value, itemSpliter);
						break;
					}
				}
			}
			writerControl_0?.method_63(parseSelectedItemsEventArgs);
			return parseSelectedItemsEventArgs.Result;
		}

		internal static string FormatSelectedValue(WriterControl writerControl_0, XTextElement element, GControl5 gcontrol5_0, string formatString, bool getText)
		{
			int num = 10;
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			GClass289 gClass = gcontrol5_0.method_8();
			if (element is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
				if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.GetValueOrderByTime)
				{
					gClass = gcontrol5_0.method_8().method_2();
					gClass.method_1();
				}
			}
			foreach (GClass290 item in gClass)
			{
				if (item.method_0() == GEnum69.const_0)
				{
					ListItem listItem = (ListItem)item.method_27();
					string text = null;
					bool flag = false;
					if (getText)
					{
						string value = (listItem == null) ? item.method_2() : listItem.Text;
						if (!string.IsNullOrEmpty(value))
						{
							text = ((listItem != null) ? listItem.Text : item.method_2());
							if (gcontrol5_0.method_10())
							{
								if (item.method_15())
								{
									flag = true;
								}
							}
							else if (item.method_17())
							{
								flag = true;
							}
						}
					}
					else if (item.method_5() != null)
					{
						text = Convert.ToString(item.method_5());
						if (gcontrol5_0.method_10())
						{
							if (item.method_15())
							{
								flag = true;
							}
						}
						else if (item.method_17())
						{
							flag = true;
						}
					}
					if (text != null)
					{
						if (flag)
						{
							list.Add(text);
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(gcontrol5_0.method_35());
							}
							stringBuilder.Append(text);
						}
						else
						{
							list2.Add(text);
						}
					}
				}
			}
			FormatListItemsEventArgs formatListItemsEventArgs = new FormatListItemsEventArgs(writerControl_0, formatString, writerControl_0.Document, element, list.ToArray(), list2.ToArray(), gcontrol5_0.method_35());
			formatListItemsEventArgs.Result = stringBuilder.ToString();
			if (!string.IsNullOrEmpty(formatString))
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				string[] array = VariableString.AnalyseVariableString(formatString, "[", "]");
				for (int i = 0; i < array.Length; i++)
				{
					if (i % 2 == 0)
					{
						stringBuilder2.Append(array[i]);
						continue;
					}
					int num2 = 0;
					if (string.Compare(array[i], "IncludeList", ignoreCase: true) == 0)
					{
						num2 = 1;
					}
					else if (string.Compare(array[i], "ExcludeList", ignoreCase: true) == 0)
					{
						num2 = -1;
					}
					if (num2 == 0)
					{
						stringBuilder2.Append("[" + array[i] + "]");
						continue;
					}
					new StringBuilder();
					bool flag2 = true;
					foreach (GClass290 item2 in gcontrol5_0.method_8())
					{
						ListItem listItem = (ListItem)item2.method_27();
						switch (num2)
						{
						case 1:
							if (gcontrol5_0.method_10())
							{
								if (!item2.method_15())
								{
									continue;
								}
							}
							else if (!item2.method_17())
							{
								continue;
							}
							break;
						case -1:
							if (gcontrol5_0.method_10())
							{
								if (item2.method_15())
								{
									continue;
								}
							}
							else if (item2.method_17())
							{
								continue;
							}
							break;
						}
						if (!flag2)
						{
							stringBuilder2.Append(gcontrol5_0.method_35().ToString());
						}
						flag2 = false;
						if (getText)
						{
							if (listItem == null)
							{
								stringBuilder2.Append(item2.method_2());
							}
							else
							{
								stringBuilder2.Append(listItem.Text);
							}
						}
						else
						{
							string text = Convert.ToString(item2.method_5());
							if (string.IsNullOrEmpty(text))
							{
								if (listItem == null)
								{
									stringBuilder2.Append(item2.method_2());
								}
								else
								{
									stringBuilder2.Append(listItem.Text);
								}
							}
							else
							{
								stringBuilder2.Append(text);
							}
						}
					}
				}
				formatListItemsEventArgs.Result = stringBuilder2.ToString();
			}
			writerControl_0.method_64(formatListItemsEventArgs);
			return formatListItemsEventArgs.Result;
		}

		internal static string FormatSelectedValueByIndexs(WriterControl writerControl_0, XTextInputFieldElement element, int[] indexs, bool getText)
		{
			int num = 7;
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			ListItemCollection listItemCollection = element.method_36(null, bool_26: true, null);
			if (listItemCollection == null || listItemCollection.Count == 0)
			{
				return null;
			}
			for (int i = 0; i < listItemCollection.Count; i++)
			{
				ListItem listItem = listItemCollection[i];
				bool flag = Array.IndexOf(indexs, i) >= 0;
				string text = getText ? listItem.Text : listItem.Value;
				if (string.IsNullOrEmpty(text))
				{
					text = listItem.Text;
				}
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				if (flag)
				{
					list.Add(text);
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(element.FieldSettings.ListValueSeparatorChar);
					}
					stringBuilder.Append(text);
				}
				else
				{
					list2.Add(text);
				}
			}
			string runtimeListValueSeparator = element.FieldSettings.RuntimeListValueSeparator;
			FormatListItemsEventArgs formatListItemsEventArgs = new FormatListItemsEventArgs(writerControl_0, element.FieldSettings.ListValueFormatString, writerControl_0.Document, element, list.ToArray(), list2.ToArray(), runtimeListValueSeparator);
			formatListItemsEventArgs.Result = stringBuilder.ToString();
			if (!string.IsNullOrEmpty(element.FieldSettings.ListValueFormatString))
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				string[] array = VariableString.AnalyseVariableString(element.FieldSettings.ListValueFormatString, "[", "]");
				for (int i = 0; i < array.Length; i++)
				{
					if (i % 2 == 0)
					{
						stringBuilder2.Append(array[i]);
						continue;
					}
					int num2 = 0;
					if (string.Compare(array[i], "IncludeList", ignoreCase: true) == 0)
					{
						num2 = 1;
					}
					else if (string.Compare(array[i], "ExcludeList", ignoreCase: true) == 0)
					{
						num2 = -1;
					}
					if (num2 == 0)
					{
						stringBuilder2.Append("[" + array[i] + "]");
						continue;
					}
					new StringBuilder();
					bool flag2 = true;
					for (int j = 0; j < listItemCollection.Count; j++)
					{
						ListItem listItem = listItemCollection[j];
						bool flag = indexs != null && Array.IndexOf(indexs, j) >= 0;
						switch (num2)
						{
						case 1:
							if (!flag)
							{
								continue;
							}
							break;
						case -1:
							if (flag)
							{
								continue;
							}
							break;
						}
						if (!flag2 && !string.IsNullOrEmpty(runtimeListValueSeparator))
						{
							stringBuilder2.Append(runtimeListValueSeparator);
						}
						flag2 = false;
						if (getText)
						{
							stringBuilder2.Append(listItemCollection[j].Text);
							continue;
						}
						string text = listItemCollection[j].Value;
						if (string.IsNullOrEmpty(text))
						{
							text = listItemCollection[j].Text;
						}
						stringBuilder2.Append(text);
					}
				}
				formatListItemsEventArgs.Result = stringBuilder2.ToString();
			}
			writerControl_0.method_64(formatListItemsEventArgs);
			return formatListItemsEventArgs.Result;
		}
	}
}
