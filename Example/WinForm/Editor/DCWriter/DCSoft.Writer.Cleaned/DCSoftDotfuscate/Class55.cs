#define DEBUG
using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class55 : GInterface4
	{
		public const string string_0 = "VISIBLE";

		public const string string_1 = "TEXT";

		public const string string_2 = "Value";

		public const string string_3 = "ContentReadonly";

		private bool bool_0 = false;

		private XTextDocument xtextDocument_0 = null;

		private Class73 class73_0 = null;

		private bool bool_1 = false;

		private Stack<GClass39> stack_0 = new Stack<GClass39>();

		public Class55(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		private void method_0()
		{
			if (!bool_0)
			{
				bool_0 = true;
				imethod_3();
				imethod_6(bool_2: true);
				imethod_8();
				imethod_6(bool_2: false);
			}
		}

		private XTextDocument method_1()
		{
			return xtextDocument_0;
		}

		public int imethod_0(XTextElementList xtextElementList_0, Dictionary<string, string> dictionary_0)
		{
			int num = 12;
			if (xtextElementList_0 == null || xtextElementList_0.Count == 0)
			{
				return 0;
			}
			if (dictionary_0 == null || dictionary_0.Count == 0)
			{
				return 0;
			}
			int num2 = 0;
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(xtextElementList_0);
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is IMemberPropertyExpressions)
				{
					PropertyExpressionInfoList propertyExpressions = ((IMemberPropertyExpressions)item).PropertyExpressions;
					if (propertyExpressions != null && propertyExpressions.Count > 0)
					{
						foreach (PropertyExpressionInfo item2 in propertyExpressions)
						{
							string[] array = VariableString.AnalyseVariableString(item2.Expression, "[", "]");
							StringBuilder stringBuilder = new StringBuilder();
							bool flag = false;
							for (int i = 0; i < array.Length; i++)
							{
								string text = array[i];
								if (i % 2 == 0)
								{
									stringBuilder.Append(text);
								}
								else
								{
									bool flag2 = false;
									foreach (string key in dictionary_0.Keys)
									{
										string b = dictionary_0[key];
										if (text == b)
										{
											stringBuilder.Append("[" + key + "]");
											flag2 = true;
											flag = true;
											break;
										}
									}
									if (!flag2)
									{
										stringBuilder.Append("[" + text + "]");
									}
								}
							}
							if (flag)
							{
								item2.Expression = stringBuilder.ToString();
								num2++;
								imethod_4(item);
							}
						}
					}
				}
			}
			return num2;
		}

		public string imethod_2(XTextElement xtextElement_0)
		{
			foreach (GClass39 item in method_7())
			{
				if (item.method_2() == xtextElement_0 && !string.IsNullOrEmpty(item.method_16()))
				{
					return item.method_16();
				}
			}
			return null;
		}

		private bool method_2(XTextElement xtextElement_0, string string_4)
		{
			if (!method_1().Options.BehaviorOptions.EnableExpression)
			{
				return false;
			}
			GClass53 gClass = new GClass53(string_4);
			List<GClass55> list = gClass.method_1();
			foreach (GClass55 item in list)
			{
				if (item is GClass58)
				{
					GClass58 gClass2 = (GClass58)item;
					string name = gClass2.Name;
					if (!string.IsNullOrEmpty(xtextElement_0.ID))
					{
						if (string.Compare(xtextElement_0.ID, name, ignoreCase: true) == 0)
						{
							return true;
						}
					}
					else if (xtextElement_0 is XTextInputFieldElementBase)
					{
						XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xtextElement_0;
						if (!string.IsNullOrEmpty(xTextInputFieldElementBase.Name) && string.Compare(xTextInputFieldElementBase.Name, name, ignoreCase: true) == 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		private bool method_3(XTextElement xtextElement_0, PropertyExpressionInfo propertyExpressionInfo_0, bool bool_2)
		{
			if (!method_1().Options.BehaviorOptions.EnableExpression)
			{
				return false;
			}
			if (!string.IsNullOrEmpty(propertyExpressionInfo_0.Expression))
			{
				method_5(xtextElement_0, propertyExpressionInfo_0.Expression);
			}
			return false;
		}

		public bool imethod_1(XTextElement xtextElement_0, EventExpressionInfoList eventExpressionInfoList_0, string string_4, bool bool_2)
		{
			int num = 6;
			if (xtextElement_0 == null)
			{
				throw new ArgumentNullException("sourceElement");
			}
			if (eventExpressionInfoList_0 == null || eventExpressionInfoList_0.Count == 0)
			{
				return false;
			}
			if (string_4 == null)
			{
				throw new ArgumentNullException("eventName");
			}
			if (!method_1().Options.BehaviorOptions.EnableExpression)
			{
				return false;
			}
			if (!XTextDocument.smethod_13(GEnum6.const_125))
			{
				return false;
			}
			bool result = false;
			bool flag = false;
			XTextDocumentContentElement documentContentElement = xtextElement_0.DocumentContentElement;
			XTextElement xTextElement = null;
			int num2 = -1;
			if (documentContentElement != null)
			{
				xTextElement = documentContentElement.CurrentElement;
				if (xTextElement != null)
				{
					num2 = documentContentElement.Content.IndexOf(xTextElement);
				}
			}
			if (bool_2 || method_1().EditorControl == null)
			{
			}
			foreach (EventExpressionInfo item in eventExpressionInfoList_0)
			{
				if (string.Compare(item.EventName, string_4, ignoreCase: true) == 0 && !string.IsNullOrEmpty(item.Expression))
				{
					XTextElement xTextElement2 = method_4(xtextElement_0, item);
					if (xTextElement2 == null)
					{
						if (method_1().Options.BehaviorOptions.DebugMode)
						{
							string message = string.Format(WriterStrings.ExpressionMissTarget_Source_Target, xtextElement_0.ToDebugString(), (item.Target == EventExpressionTarget.Custom) ? item.CustomTargetName : "Next");
							Debug.WriteLine(message);
						}
					}
					else if (xTextElement2.IsParentOrSupParent(xtextElement_0))
					{
						if (method_1().Options.BehaviorOptions.DebugMode)
						{
							string message = string.Format(WriterStrings.ExpressionTargetInvalidteForChild_Source_Target, xtextElement_0.ToDebugString(), (item.Target == EventExpressionTarget.Custom) ? item.CustomTargetName : "Next");
							Debug.WriteLine(message);
						}
					}
					else
					{
						string text = item.TargetPropertyName;
						if (string.IsNullOrEmpty(text))
						{
							text = "Visible";
						}
						text = text.Trim().ToUpper();
						object obj = null;
						try
						{
							obj = method_5(xtextElement_0, item.Expression);
						}
						catch (Exception ex)
						{
							if (method_1().Options.BehaviorOptions.DebugMode)
							{
								string message = string.Format(WriterStrings.ExecuteExpression_Sender_Expression_Result, (xtextElement_0 == null) ? "NULL" : xtextElement_0.ToDebugString(), item.Expression, ex.Message);
								Debug.WriteLine(message);
							}
							if (!(text == "VISIBLE"))
							{
								continue;
							}
							obj = true;
						}
						switch (text)
						{
						case "TEXT":
							if (xTextElement2 is XTextContainerElement)
							{
								string text2 = Convert.ToString(obj);
								XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement2;
								if (bool_2)
								{
									xTextContainerElement.SetInnerTextFast(text2);
									xTextContainerElement.FixDomState();
								}
								else
								{
									xTextContainerElement.SetEditorTextExt(text2, DomAccessFlags.None, disablePermissioin: false, updateContent: true);
									xTextContainerElement.FixDomState();
									if (xtextDocument_0.WriterControl != null)
									{
										WriterAfterExecuteEventExpressionEventArgs writerAfterExecuteEventExpressionEventArgs_ = new WriterAfterExecuteEventExpressionEventArgs(xtextDocument_0.WriterControl, xtextDocument_0, xtextElement_0, xTextElement2, text);
										xtextDocument_0.WriterControl.vmethod_4(writerAfterExecuteEventExpressionEventArgs_);
									}
								}
							}
							break;
						case "VISIBLE":
						{
							bool visible = (bool)ValueTypeHelper.ConvertTo(obj, typeof(bool), xTextElement2.Visible);
							if (bool_2)
							{
								xTextElement2.Visible = visible;
							}
							else
							{
								xTextElement2.EditorSetVisibleExt(visible, logUndo: false, fastMode: false);
								if (xtextDocument_0.WriterControl != null)
								{
									WriterAfterExecuteEventExpressionEventArgs writerAfterExecuteEventExpressionEventArgs_ = new WriterAfterExecuteEventExpressionEventArgs(xtextDocument_0.WriterControl, xtextDocument_0, xtextElement_0, xTextElement2, text);
									xtextDocument_0.WriterControl.vmethod_4(writerAfterExecuteEventExpressionEventArgs_);
								}
								if (xTextElement2.ContentElement.bool_19)
								{
									flag = true;
								}
							}
							break;
						}
						}
					}
				}
			}
			if (!bool_2)
			{
				if (xTextElement != null)
				{
					int num3 = documentContentElement.Content.IndexOf(xTextElement);
					if (num3 != num2 && num3 >= 0)
					{
						documentContentElement.Content.method_47(num3, 0);
					}
				}
				if (method_1().EditorControl == null)
				{
				}
				if (flag)
				{
					method_1().RefreshPages();
					if (method_1().EditorControl != null)
					{
						method_1().EditorControl.UpdatePages();
						method_1().EditorControl.UpdateTextCaret();
						method_1().EditorControl.InnerViewControl.Invalidate();
					}
				}
				else if (method_1().EditorControl != null)
				{
					method_1().EditorControl.UpdateTextCaret();
				}
			}
			return result;
		}

		private XTextElement method_4(XTextElement xtextElement_0, EventExpressionInfo eventExpressionInfo_0)
		{
			int num = 3;
			if (eventExpressionInfo_0 == null)
			{
				throw new ArgumentNullException("info");
			}
			XTextDocument ownerDocument = xtextElement_0.OwnerDocument;
			XTextElement result = null;
			if (eventExpressionInfo_0.Target == EventExpressionTarget.NextElement)
			{
				result = ownerDocument.GetNextElement(xtextElement_0, typeof(XTextFieldElementBase), includeHiddenElement: true);
			}
			else if (eventExpressionInfo_0.Target == EventExpressionTarget.Custom)
			{
				result = ownerDocument.GetElementById(eventExpressionInfo_0.CustomTargetName);
			}
			return result;
		}

		private object method_5(XTextElement xtextElement_0, string string_4)
		{
			int num = 13;
			if (string.IsNullOrEmpty(string_4))
			{
				return null;
			}
			if (!method_1().Options.BehaviorOptions.EnableExpression)
			{
				return false;
			}
			if (!method_1().method_78(xtextElement_0))
			{
				return false;
			}
			object obj = null;
			ElementEventTemplateList events = xtextElement_0.Events;
			string text = null;
			if (method_1().Options.BehaviorOptions.EnableElementEvents && events != null && events.HasExpression)
			{
				if (method_1().Options.BehaviorOptions.EnableElementEvents)
				{
					ElementExpressionEventArgs elementExpressionEventArgs = new ElementExpressionEventArgs(xtextElement_0, string_4);
					events.OnExpression(this, elementExpressionEventArgs);
					obj = elementExpressionEventArgs.Result;
					if (obj == null && !elementExpressionEventArgs.Handled)
					{
						GClass54 gClass = new GClass54(string_4, xtextElement_0, null);
						obj = gClass.vmethod_1();
						text = gClass.method_16();
					}
				}
			}
			else
			{
				string text2 = string_4.Replace("[value]", "value");
				text2 = text2.Replace("[VALUE]", "value");
				GClass54 gClass = new GClass54(text2, xtextElement_0, null);
				obj = gClass.vmethod_1();
				text = gClass.method_16();
			}
			if (method_1().Options.BehaviorOptions.DebugMode)
			{
				string message = string.Format(WriterStrings.ExecuteExpression_Sender_Expression_Result, (xtextElement_0 == null) ? "NULL" : xtextElement_0.ToDebugString(), string_4, obj);
				Debug.WriteLine(message);
				if (!string.IsNullOrEmpty(text))
				{
					Debug.WriteLine(text);
				}
			}
			return obj;
		}

		private bool method_6(XTextElement xtextElement_0, string string_4, bool bool_2)
		{
			int num = 3;
			if (!method_1().Options.BehaviorOptions.EnableExpression)
			{
				return bool_2;
			}
			if (string.IsNullOrEmpty(string_4))
			{
				return bool_2;
			}
			try
			{
				object obj = method_5(xtextElement_0, string_4);
				if (obj is bool)
				{
					return (bool)obj;
				}
				return Convert.ToBoolean(obj);
			}
			catch (Exception ex)
			{
				if (method_1().Options.BehaviorOptions.DebugMode)
				{
					string message = string.Format(WriterStrings.ExecuteExpression_Sender_Expression_Result, (xtextElement_0 == null) ? "NULL" : xtextElement_0.ToDebugString(), string_4, ex.Message);
					Debug.WriteLine(message);
				}
				return bool_2;
			}
		}

		internal Class73 method_7()
		{
			if (class73_0 == null)
			{
				class73_0 = new Class73();
			}
			return class73_0;
		}

		internal void method_8(Class73 class73_1)
		{
			class73_0 = class73_1;
		}

		public void imethod_3()
		{
			class73_0 = new Class73();
			DomTreeNodeEnumerable domTreeNodeEnumerable = new DomTreeNodeEnumerable(method_1());
			domTreeNodeEnumerable.ExcludeCharElement = true;
			domTreeNodeEnumerable.ExcludeParagraphFlag = true;
			foreach (XTextElement item in domTreeNodeEnumerable)
			{
				if (item is XTextContainerElement || item is XTextObjectElement)
				{
					method_9(item);
				}
			}
		}

		public void imethod_4(XTextElement xtextElement_0)
		{
			foreach (GClass39 item in method_7())
			{
				if (item.method_2() == xtextElement_0)
				{
					method_7().Remove(item);
					break;
				}
			}
			method_9(xtextElement_0);
		}

		private void method_9(XTextElement xtextElement_0)
		{
			int num = 11;
			PropertyExpressionInfoList runtimePropertyExpressions = xtextElement_0.GetRuntimePropertyExpressions();
			if (runtimePropertyExpressions != null && runtimePropertyExpressions.Count > 0)
			{
				bool flag = XTextDocument.smethod_13(GEnum6.const_126);
				bool flag2 = XTextDocument.smethod_13(GEnum6.const_125);
				foreach (PropertyExpressionInfo item in runtimePropertyExpressions)
				{
					if ((flag || string.Compare(item.Name, "FormulaValue", ignoreCase: true) == 0 || string.Compare(item.Name, "Visible", ignoreCase: true) == 0) && (flag2 || string.Compare(item.Name, "FormulaValue", ignoreCase: true) != 0))
					{
						GClass39 gClass = new GClass39();
						gClass.method_3(xtextElement_0);
						gClass.method_7(item.Name);
						gClass.method_9(item.Expression);
						gClass.method_11(item.AllowChainReaction);
						method_7().Add(gClass);
					}
				}
			}
		}

		private GClass39 method_10(XTextElement xtextElement_0, string string_4)
		{
			int num = 15;
			string text = null;
			switch (string_4)
			{
			case "Value":
				if (xtextElement_0 is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)xtextElement_0;
					text = xTextContainerElement.ValueExpression;
				}
				else if (xtextElement_0 is XTextObjectElement)
				{
					XTextObjectElement xTextObjectElement = (XTextObjectElement)xtextElement_0;
					text = xTextObjectElement.ValueExpression;
				}
				break;
			case "VISIBLE":
				if (xtextElement_0 is XTextContainerElement)
				{
					text = ((XTextContainerElement)xtextElement_0).VisibleExpression;
				}
				break;
			case "ContentReadonly":
				if (xtextElement_0 is XTextContainerElement)
				{
					text = ((XTextContainerElement)xtextElement_0).ContentReadonlyExpression;
				}
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				GClass39 gClass = new GClass39();
				gClass.method_3(xtextElement_0);
				gClass.method_9(text);
				gClass.method_7(string_4);
				string text2 = xtextElement_0.ID;
				if (string.IsNullOrEmpty(text2) && xtextElement_0 is XTextTableCellElement)
				{
					text2 = ((XTextTableCellElement)xtextElement_0).CellID;
				}
				if (method_1().Options.BehaviorOptions.DebugMode)
				{
					string message = string.Format(WriterStrings.DetectValueExpression_ID_Expression, text2, text);
					Debug.WriteLine(message);
				}
				return gClass;
			}
			return null;
		}

		public bool imethod_5()
		{
			return bool_1;
		}

		public void imethod_6(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public bool imethod_7(XTextElement xtextElement_0)
		{
			GClass39 gClass = method_7().method_0(xtextElement_0);
			if (gClass == null)
			{
				return false;
			}
			return method_11(gClass, null, 0);
		}

		private bool method_11(GClass39 gclass39_0, XTextElement xtextElement_0, int int_0)
		{
			int num = 12;
			if (gclass39_0.method_0())
			{
				return false;
			}
			if (string.IsNullOrEmpty(gclass39_0.method_6()))
			{
				return false;
			}
			method_0();
			XTextElement xTextElement = gclass39_0.method_2();
			if (xTextElement == null)
			{
				return false;
			}
			PropertyInfo property = xTextElement.GetType().GetProperty(gclass39_0.method_6(), BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				return false;
			}
			object obj = null;
			try
			{
				obj = gclass39_0.method_23(xtextElement_0, int_0);
			}
			catch (Exception)
			{
				return false;
			}
			if (!xTextElement.BelongToDocumentDom(method_1(), checkLogicDelete: false))
			{
				return false;
			}
			MemberEffectLevel memberEffectLevel = MemberEffectLevel.DOM;
			MemberExpressionableAttribute memberExpressionableAttribute = (MemberExpressionableAttribute)Attribute.GetCustomAttribute(property, typeof(MemberExpressionableAttribute), inherit: false);
			if (memberExpressionableAttribute != null)
			{
				memberEffectLevel = memberExpressionableAttribute.EffectLevel;
			}
			object obj2 = null;
			if (property.PropertyType.Equals(typeof(DCBooleanValue)) && obj is bool)
			{
				obj2 = ((!(bool)obj) ? ((object)DCBooleanValue.False) : ((object)DCBooleanValue.True));
			}
			else
			{
				try
				{
					obj2 = ValueTypeHelper.ConvertTo(obj, property.PropertyType);
				}
				catch
				{
					return false;
				}
			}
			object value = property.GetValue(xTextElement, null);
			if (object.Equals(value, obj2))
			{
				return false;
			}
			property.SetValue(xTextElement, obj2, null);
			if (property.Name == "Visible" && xTextElement is XTextContainerElement)
			{
				xTextElement.RuntimeVisible = ((XTextContainerElement)xTextElement).vmethod_30();
			}
			if (xtextDocument_0.WriterControl != null)
			{
				WriterAfterExecuteEventExpressionEventArgs writerAfterExecuteEventExpressionEventArgs_ = new WriterAfterExecuteEventExpressionEventArgs(xtextDocument_0.WriterControl, xtextDocument_0, xtextElement_0, xTextElement, property.Name);
				xtextDocument_0.WriterControl.vmethod_4(writerAfterExecuteEventExpressionEventArgs_);
			}
			switch (memberEffectLevel)
			{
			case MemberEffectLevel.DOM:
				if (xTextElement.WriterControl != null)
				{
					xTextElement.WriterControl.CommandControler.InvalidateCommandState();
				}
				break;
			case MemberEffectLevel.ElementView:
				xTextElement.InvalidateView();
				xTextElement.InvalidateHighlightInfo();
				break;
			case MemberEffectLevel.ElementLayout:
				xTextElement.EditorRefreshView();
				break;
			case MemberEffectLevel.ParentElementLayout:
				if (xTextElement.Parent != null)
				{
					xTextElement.Parent.EditorRefreshView();
				}
				break;
			case MemberEffectLevel.ContentElementLayout:
				xTextElement.ContentElement?.EditorRefreshView();
				break;
			case MemberEffectLevel.DocumentLayout:
				if (xTextElement.WriterControl == null)
				{
					XTextDocument ownerDocument = xTextElement.OwnerDocument;
					ownerDocument.RefreshSizeWithoutParamter();
					ownerDocument.ExecuteLayout();
					ownerDocument.RefreshPages();
				}
				else
				{
					xTextElement.WriterControl.RefreshDocument();
				}
				break;
			}
			return true;
		}

		private XTextElement method_12(XTextElement xtextElement_0)
		{
			if (xtextElement_0 is XTextTableCellElement)
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xtextElement_0;
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextTableCellElement.Elements.method_5(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement != null)
				{
					return xTextInputFieldElement;
				}
			}
			return xtextElement_0;
		}

		public int imethod_8()
		{
			int num = 0;
			if (method_7().Count > 0)
			{
				List<GClass39> list = new List<GClass39>();
				foreach (GClass39 item in method_7())
				{
					list.Add(item);
				}
				foreach (GClass39 item2 in list)
				{
					if (method_11(item2, null, 0))
					{
						num++;
					}
				}
			}
			return num;
		}

		public int imethod_9(XTextElement xtextElement_0)
		{
			int num = 7;
			if (!method_1().Options.BehaviorOptions.EnableExpression)
			{
				return 0;
			}
			if (xtextElement_0 == null)
			{
				return 0;
			}
			if (!XTextDocument.smethod_13(GEnum6.const_125))
			{
				return 0;
			}
			method_0();
			if (stack_0 == null)
			{
				stack_0 = new Stack<GClass39>();
			}
			if (stack_0.Count > 5)
			{
				return 0;
			}
			if (stack_0.Count == 0)
			{
				foreach (GClass39 item in method_7())
				{
					item.method_1(bool_3: false);
				}
			}
			if (stack_0.Count > 0 && !stack_0.Peek().method_10())
			{
				return 0;
			}
			int result = 0;
			Class73 @class = method_7().method_3();
			for (int i = 0; i < @class.Count; i++)
			{
				GClass39 current = @class[i];
				if (current.method_2() == null || !current.method_2().BelongToDocumentDom(method_1(), checkLogicDelete: false))
				{
					if (i < @class.Count)
					{
						@class.RemoveAt(i);
					}
					i--;
				}
				else if (current.method_12(xtextElement_0) && (!stack_0.Contains(current) || current.method_6() != "FormulaValue"))
				{
					stack_0.Push(current);
					try
					{
						method_11(current, xtextElement_0, stack_0.Count - 1);
					}
					finally
					{
						current.method_1(bool_3: true);
						stack_0.Pop();
					}
				}
			}
			return result;
		}

		public int imethod_10(XTextDocument xtextDocument_1, XTextTableElement xtextTableElement_0, int int_0, int int_1)
		{
			return method_13(xtextDocument_1, xtextTableElement_0, int_0, int_1, bool_2: true, bool_3: true);
		}

		public int imethod_11(XTextDocument xtextDocument_1, XTextTableElement xtextTableElement_0, int int_0, int int_1)
		{
			return method_13(xtextDocument_1, xtextTableElement_0, int_0, int_1, bool_2: false, bool_3: true);
		}

		private int method_13(XTextDocument xtextDocument_1, XTextTableElement xtextTableElement_0, int int_0, int int_1, bool bool_2, bool bool_3)
		{
			int num = 8;
			method_0();
			int num2 = 0;
			XTextElementList elementsByType = xtextDocument_1.GetElementsByType(typeof(XTextTableElement));
			foreach (XTextTableElement item in elementsByType)
			{
				string text = null;
				if (item != xtextTableElement_0)
				{
					text = item.ID;
					if (string.IsNullOrEmpty(text))
					{
						text = "Table" + Convert.ToString(elementsByType.IndexOf(item) + 1);
					}
				}
				foreach (XTextTableCellElement visibleCell in item.VisibleCells)
				{
					if (!string.IsNullOrEmpty(visibleCell.ValueExpression))
					{
						string text2 = null;
						text2 = ((!bool_2) ? method_15(visibleCell.ValueExpression, int_0, int_1, text) : method_14(visibleCell.ValueExpression, int_0, int_1, text));
						if (text2 != visibleCell.ValueExpression)
						{
							if (item != xtextTableElement_0 && bool_3 && xtextDocument_1.CanLogUndo)
							{
								xtextDocument_1.UndoList.AddProperty("ValueExpression", visibleCell.ValueExpression, text2, visibleCell);
							}
							visibleCell.ValueExpression = text2;
							num2++;
						}
					}
				}
			}
			return num2;
		}

		internal string method_14(string string_4, int int_0, int int_1, string string_5)
		{
			int num = 15;
			if (string.IsNullOrEmpty(string_4))
			{
				return string_4;
			}
			method_0();
			bool flag = false;
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = VariableString.AnalyseVariableString(string_4, "[", "]");
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				string str = array[i];
				if (GClass344.smethod_0(str))
				{
					GClass344 gClass = new GClass344(str);
					if (!string.IsNullOrEmpty(string_5) && string.Compare(gClass.method_0(), string_5, ignoreCase: true) != 0)
					{
						stringBuilder.Append("[" + str + "]");
						continue;
					}
					if (gClass.method_2() + gClass.method_12() - 1 >= int_0)
					{
						if (int_1 > 0)
						{
							if (gClass.method_2() - 1 >= int_0)
							{
								gClass.method_3(gClass.method_2() + int_1);
								flag = true;
							}
							else
							{
								gClass.method_13(gClass.method_12() + int_1);
								flag = true;
							}
						}
						else if (gClass.method_2() - 1 > int_0)
						{
							gClass.method_3(gClass.method_2() + int_1);
							flag = true;
						}
						else if (gClass.method_12() > 0)
						{
							gClass.method_13(gClass.method_12() + int_1);
							flag = true;
						}
					}
					stringBuilder.Append("[" + gClass.method_14() + "]");
				}
				else
				{
					stringBuilder.Append("[" + str + "]");
				}
			}
			if (flag)
			{
				return stringBuilder.ToString();
			}
			return string_4;
		}

		internal string method_15(string string_4, int int_0, int int_1, string string_5)
		{
			int num = 8;
			if (string.IsNullOrEmpty(string_4))
			{
				return string_4;
			}
			bool flag = false;
			StringBuilder stringBuilder = new StringBuilder();
			string[] array = VariableString.AnalyseVariableString(string_4, "[", "]");
			for (int i = 0; i < array.Length; i++)
			{
				if (i % 2 == 0)
				{
					stringBuilder.Append(array[i]);
					continue;
				}
				string str = array[i];
				if (GClass344.smethod_0(str))
				{
					GClass344 gClass = new GClass344(str);
					if (!string.IsNullOrEmpty(string_5) && string.Compare(gClass.method_0(), string_5, ignoreCase: true) != 0)
					{
						stringBuilder.Append("[" + str + "]");
						continue;
					}
					if (gClass.method_6() + gClass.method_12() - 1 >= int_0)
					{
						if (int_1 > 0)
						{
							if (gClass.method_6() - 1 >= int_0)
							{
								gClass.method_7(gClass.method_6() + int_1);
								flag = true;
							}
							else
							{
								gClass.method_11(gClass.method_10() + int_1);
								flag = true;
							}
						}
						else if (gClass.method_6() - 1 > int_0)
						{
							gClass.method_7(gClass.method_6() + int_1);
							flag = true;
						}
						else if (gClass.method_10() > 0)
						{
							gClass.method_11(gClass.method_10() + int_1);
							flag = true;
						}
					}
					stringBuilder.Append("[" + gClass.method_14() + "]");
				}
				else
				{
					stringBuilder.Append("[" + str + "]");
				}
			}
			if (flag)
			{
				return stringBuilder.ToString();
			}
			return string_4;
		}
	}
}
