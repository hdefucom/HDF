using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DCSoftDotfuscate
{
	internal class Class134
	{
		private WriterControl writerControl_0;

		private Dictionary<string, ElementLoadEventHandler> dictionary_0;

		private Dictionary<string, ElementMouseEventHandler> dictionary_1;

		private Dictionary<string, ElementMouseEventHandler> dictionary_2;

		private Dictionary<string, ElementMouseEventHandler> dictionary_3;

		private Dictionary<string, ElementMouseEventHandler> dictionary_4;

		private Dictionary<string, ElementMouseEventHandler> dictionary_5;

		private Dictionary<string, ElementKeyEventHandler> dictionary_6;

		private Dictionary<string, ElementKeyEventHandler> dictionary_7;

		private Dictionary<string, ElementKeyEventHandler> dictionary_8;

		private Dictionary<string, ContentChangedEventHandler> dictionary_9;

		private Dictionary<string, ContentChangingEventHandler> dictionary_10;

		private Dictionary<string, ElementEventHandler> dictionary_11;

		private Dictionary<string, ElementEventHandler> dictionary_12;

		private Dictionary<string, ElementValidatingEventHandler> dictionary_13;

		private Dictionary<string, ElementEventHandler> dictionary_14;

		private Dictionary<string, ElementCancelEventHandler> dictionary_15;

		private Dictionary<string, ElementEventHandler> dictionary_16;

		private Dictionary<string, ElementEventHandler> dictionary_17;

		private Dictionary<string, ElementExpressionEventHandler> dictionary_18;

		private Dictionary<string, ElementQueryStateEventHandler> dictionary_19;

		public Class134(WriterControl writerControl_1)
		{
			int num = 7;
			writerControl_0 = null;
			dictionary_0 = new Dictionary<string, ElementLoadEventHandler>();
			dictionary_1 = new Dictionary<string, ElementMouseEventHandler>();
			dictionary_2 = new Dictionary<string, ElementMouseEventHandler>();
			dictionary_3 = new Dictionary<string, ElementMouseEventHandler>();
			dictionary_4 = new Dictionary<string, ElementMouseEventHandler>();
			dictionary_5 = new Dictionary<string, ElementMouseEventHandler>();
			dictionary_6 = new Dictionary<string, ElementKeyEventHandler>();
			dictionary_7 = new Dictionary<string, ElementKeyEventHandler>();
			dictionary_8 = new Dictionary<string, ElementKeyEventHandler>();
			dictionary_9 = new Dictionary<string, ContentChangedEventHandler>();
			dictionary_10 = new Dictionary<string, ContentChangingEventHandler>();
			dictionary_11 = new Dictionary<string, ElementEventHandler>();
			dictionary_12 = new Dictionary<string, ElementEventHandler>();
			dictionary_13 = new Dictionary<string, ElementValidatingEventHandler>();
			dictionary_14 = new Dictionary<string, ElementEventHandler>();
			dictionary_15 = new Dictionary<string, ElementCancelEventHandler>();
			dictionary_16 = new Dictionary<string, ElementEventHandler>();
			dictionary_17 = new Dictionary<string, ElementEventHandler>();
			dictionary_18 = new Dictionary<string, ElementExpressionEventHandler>();
			dictionary_19 = new Dictionary<string, ElementQueryStateEventHandler>();
			
			if (writerControl_1 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			writerControl_0 = writerControl_1;
		}

		public void method_0(string string_0, ElementLoadEventHandler elementLoadEventHandler_0)
		{
			method_41(dictionary_0, string_0, elementLoadEventHandler_0);
		}

		public void method_1(XTextElement xtextElement_0, ElementLoadEventArgs elementLoadEventArgs_0)
		{
			int num = 10;
			ElementLoadEventHandler elementLoadEventHandler = (ElementLoadEventHandler)method_40(dictionary_0, xtextElement_0);
			if (elementLoadEventHandler != null)
			{
				if (writerControl_0.IsTryCathForRaiseEvent)
				{
					try
					{
						elementLoadEventHandler(writerControl_0, elementLoadEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementLoadEventArgs_0.Element, exception_, "Element.Load");
					}
				}
				else
				{
					elementLoadEventHandler(writerControl_0, elementLoadEventArgs_0);
				}
			}
		}

		public void method_2(string string_0, ElementMouseEventHandler elementMouseEventHandler_0)
		{
			method_41(dictionary_1, string_0, elementMouseEventHandler_0);
		}

		public void method_3(XTextElement xtextElement_0, ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 15;
			ElementMouseEventHandler elementMouseEventHandler = (ElementMouseEventHandler)method_40(dictionary_1, xtextElement_0);
			if (elementMouseEventHandler != null)
			{
				if (writerControl_0.IsTryCathForRaiseEvent)
				{
					try
					{
						elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementMouseEventArgs_0.Element, exception_, "Element.MouseClick");
					}
				}
				else
				{
					elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
				}
			}
		}

		public void method_4(string string_0, ElementMouseEventHandler elementMouseEventHandler_0)
		{
			method_41(dictionary_2, string_0, elementMouseEventHandler_0);
		}

		public void method_5(XTextElement xtextElement_0, ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 12;
			ElementMouseEventHandler elementMouseEventHandler = (ElementMouseEventHandler)method_40(dictionary_2, xtextElement_0);
			if (elementMouseEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementMouseEventArgs_0.Element, exception_, "Element.MouseDblClick");
					}
				}
				else
				{
					elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
				}
			}
		}

		public void method_6(string string_0, ElementMouseEventHandler elementMouseEventHandler_0)
		{
			method_41(dictionary_3, string_0, elementMouseEventHandler_0);
		}

		public void method_7(XTextElement xtextElement_0, ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 13;
			ElementMouseEventHandler elementMouseEventHandler = (ElementMouseEventHandler)method_40(dictionary_3, xtextElement_0);
			if (elementMouseEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementMouseEventArgs_0.Element, exception_, "Element.MouseDown");
					}
				}
				else
				{
					elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
				}
			}
		}

		public void method_8(string string_0, ElementMouseEventHandler elementMouseEventHandler_0)
		{
			method_41(dictionary_4, string_0, elementMouseEventHandler_0);
		}

		public void method_9(XTextElement xtextElement_0, ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 19;
			ElementMouseEventHandler elementMouseEventHandler = (ElementMouseEventHandler)method_40(dictionary_4, xtextElement_0);
			if (elementMouseEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementMouseEventArgs_0.Element, exception_, "Element.MouseMove");
					}
				}
				else
				{
					elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
				}
			}
		}

		public void method_10(string string_0, ElementMouseEventHandler elementMouseEventHandler_0)
		{
			method_41(dictionary_5, string_0, elementMouseEventHandler_0);
		}

		public void method_11(XTextElement xtextElement_0, ElementMouseEventArgs elementMouseEventArgs_0)
		{
			int num = 6;
			ElementMouseEventHandler elementMouseEventHandler = (ElementMouseEventHandler)method_40(dictionary_5, xtextElement_0);
			if (elementMouseEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementMouseEventArgs_0.Element, exception_, "Element.MouseUp");
					}
				}
				else
				{
					elementMouseEventHandler(writerControl_0, elementMouseEventArgs_0);
				}
			}
		}

		public void method_12(string string_0, ElementKeyEventHandler elementKeyEventHandler_0)
		{
			method_41(dictionary_6, string_0, elementKeyEventHandler_0);
		}

		public void method_13(XTextElement xtextElement_0, ElementKeyEventArgs elementKeyEventArgs_0)
		{
			int num = 4;
			ElementKeyEventHandler elementKeyEventHandler = (ElementKeyEventHandler)method_40(dictionary_6, xtextElement_0);
			if (elementKeyEventHandler != null)
			{
				if (writerControl_0.IsTryCathForRaiseEvent)
				{
					try
					{
						elementKeyEventHandler(writerControl_0, elementKeyEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementKeyEventArgs_0.Element, exception_, "Element.KeyDown");
					}
				}
				else
				{
					elementKeyEventHandler(writerControl_0, elementKeyEventArgs_0);
				}
			}
		}

		public void method_14(string string_0, ElementKeyEventHandler elementKeyEventHandler_0)
		{
			method_41(dictionary_7, string_0, elementKeyEventHandler_0);
		}

		public void method_15(XTextElement xtextElement_0, ElementKeyEventArgs elementKeyEventArgs_0)
		{
			int num = 5;
			ElementKeyEventHandler elementKeyEventHandler = (ElementKeyEventHandler)method_40(dictionary_7, xtextElement_0);
			if (elementKeyEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementKeyEventHandler(writerControl_0, elementKeyEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementKeyEventArgs_0.Element, exception_, "Element.KeyPress");
					}
				}
				else
				{
					elementKeyEventHandler(writerControl_0, elementKeyEventArgs_0);
				}
			}
		}

		public void method_16(string string_0, ElementKeyEventHandler elementKeyEventHandler_0)
		{
			method_41(dictionary_8, string_0, elementKeyEventHandler_0);
		}

		public void method_17(XTextElement xtextElement_0, ElementKeyEventArgs elementKeyEventArgs_0)
		{
			int num = 8;
			ElementKeyEventHandler elementKeyEventHandler = (ElementKeyEventHandler)method_40(dictionary_8, xtextElement_0);
			if (elementKeyEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementKeyEventHandler(writerControl_0, elementKeyEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementKeyEventArgs_0.Element, exception_, "Element.KeyUp");
					}
				}
				else
				{
					elementKeyEventHandler(writerControl_0, elementKeyEventArgs_0);
				}
			}
		}

		public void method_18(string string_0, ContentChangedEventHandler contentChangedEventHandler_0)
		{
			method_41(dictionary_9, string_0, contentChangedEventHandler_0);
		}

		public void method_19(XTextElement xtextElement_0, ContentChangedEventArgs contentChangedEventArgs_0)
		{
			int num = 10;
			ContentChangedEventHandler contentChangedEventHandler = (ContentChangedEventHandler)method_40(dictionary_9, xtextElement_0);
			if (contentChangedEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						contentChangedEventHandler(writerControl_0, contentChangedEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(contentChangedEventArgs_0.Element, exception_, "Element.ContentChanged");
					}
				}
				else
				{
					contentChangedEventHandler(writerControl_0, contentChangedEventArgs_0);
				}
			}
		}

		public void method_20(string string_0, ContentChangingEventHandler contentChangingEventHandler_0)
		{
			method_41(dictionary_10, string_0, contentChangingEventHandler_0);
		}

		public void method_21(XTextElement xtextElement_0, ContentChangingEventArgs contentChangingEventArgs_0)
		{
			int num = 13;
			ContentChangingEventHandler contentChangingEventHandler = (ContentChangingEventHandler)method_40(dictionary_9, xtextElement_0);
			if (contentChangingEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						contentChangingEventHandler(writerControl_0, contentChangingEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(contentChangingEventArgs_0.Element, exception_, "Element.ContentChanging");
					}
				}
				else
				{
					contentChangingEventHandler(writerControl_0, contentChangingEventArgs_0);
				}
			}
		}

		public void method_22(string string_0, ElementEventHandler elementEventHandler_0)
		{
			method_41(dictionary_11, string_0, elementEventHandler_0);
		}

		public void method_23(XTextElement xtextElement_0, ElementEventArgs elementEventArgs_0)
		{
			int num = 2;
			ElementEventHandler elementEventHandler = (ElementEventHandler)method_40(dictionary_11, xtextElement_0);
			if (elementEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementEventHandler(writerControl_0, elementEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementEventArgs_0.Element, exception_, "Element.GotFocus");
					}
				}
				else
				{
					elementEventHandler(writerControl_0, elementEventArgs_0);
				}
			}
		}

		public void method_24(string string_0, ElementEventHandler elementEventHandler_0)
		{
			method_41(dictionary_12, string_0, elementEventHandler_0);
		}

		public void method_25(XTextElement xtextElement_0, ElementEventArgs elementEventArgs_0)
		{
			int num = 1;
			ElementEventHandler elementEventHandler = (ElementEventHandler)method_40(dictionary_12, xtextElement_0);
			if (elementEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementEventHandler(writerControl_0, elementEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementEventArgs_0.Element, exception_, "Element.LostFocus");
					}
				}
				else
				{
					elementEventHandler(writerControl_0, elementEventArgs_0);
				}
			}
		}

		public void method_26(string string_0, ElementValidatingEventHandler elementValidatingEventHandler_0)
		{
			method_41(dictionary_13, string_0, elementValidatingEventHandler_0);
		}

		public void method_27(XTextElement xtextElement_0, ElementValidatingEventArgs elementValidatingEventArgs_0)
		{
			int num = 0;
			ElementValidatingEventHandler elementValidatingEventHandler = (ElementValidatingEventHandler)method_40(dictionary_13, xtextElement_0);
			if (elementValidatingEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementValidatingEventHandler(writerControl_0, elementValidatingEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementValidatingEventArgs_0.Element, exception_, "Element.Validating");
					}
				}
				else
				{
					elementValidatingEventHandler(writerControl_0, elementValidatingEventArgs_0);
				}
			}
		}

		public void method_28(string string_0, ElementEventHandler elementEventHandler_0)
		{
			method_41(dictionary_14, string_0, elementEventHandler_0);
		}

		public void method_29(XTextElement xtextElement_0, ElementEventArgs elementEventArgs_0)
		{
			int num = 19;
			ElementEventHandler elementEventHandler = (ElementEventHandler)method_40(dictionary_14, xtextElement_0);
			if (elementEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementEventHandler(writerControl_0, elementEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementEventArgs_0.Element, exception_, "Element.Validate");
					}
				}
				else
				{
					elementEventHandler(writerControl_0, elementEventArgs_0);
				}
			}
		}

		public void method_30(string string_0, ElementCancelEventHandler elementCancelEventHandler_0)
		{
			method_41(dictionary_15, string_0, elementCancelEventHandler_0);
		}

		public void method_31(XTextElement xtextElement_0, ElementCancelEventArgs elementCancelEventArgs_0)
		{
			int num = 18;
			ElementCancelEventHandler elementCancelEventHandler = (ElementCancelEventHandler)method_40(dictionary_15, xtextElement_0);
			if (elementCancelEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementCancelEventHandler(writerControl_0, elementCancelEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementCancelEventArgs_0.Element, exception_, "Element.BeforeDropDown");
					}
				}
				else
				{
					elementCancelEventHandler(writerControl_0, elementCancelEventArgs_0);
				}
			}
		}

		public void method_32(string string_0, ElementEventHandler elementEventHandler_0)
		{
			method_41(dictionary_16, string_0, elementEventHandler_0);
		}

		public void method_33(XTextElement xtextElement_0, ElementEventArgs elementEventArgs_0)
		{
			int num = 11;
			ElementEventHandler elementEventHandler = (ElementEventHandler)method_40(dictionary_16, xtextElement_0);
			if (elementEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementEventHandler(writerControl_0, elementEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementEventArgs_0.Element, exception_, "Element.MouseEnter");
					}
				}
				else
				{
					elementEventHandler(writerControl_0, elementEventArgs_0);
				}
			}
		}

		public void method_34(string string_0, ElementEventHandler elementEventHandler_0)
		{
			method_41(dictionary_17, string_0, elementEventHandler_0);
		}

		public void method_35(XTextElement xtextElement_0, ElementEventArgs elementEventArgs_0)
		{
			int num = 9;
			ElementEventHandler elementEventHandler = (ElementEventHandler)method_40(dictionary_17, xtextElement_0);
			if (elementEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementEventHandler(writerControl_0, elementEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementEventArgs_0.Element, exception_, "Element.MouseLeave");
					}
				}
				else
				{
					elementEventHandler(writerControl_0, elementEventArgs_0);
				}
			}
		}

		public void method_36(string string_0, ElementExpressionEventHandler elementExpressionEventHandler_0)
		{
			method_41(dictionary_18, string_0, elementExpressionEventHandler_0);
		}

		public void method_37(XTextElement xtextElement_0, ElementExpressionEventArgs elementExpressionEventArgs_0)
		{
			int num = 1;
			ElementExpressionEventHandler elementExpressionEventHandler = (ElementExpressionEventHandler)method_40(dictionary_18, xtextElement_0);
			if (elementExpressionEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementExpressionEventHandler(writerControl_0, elementExpressionEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementExpressionEventArgs_0.Element, exception_, "Element.Expression");
					}
				}
				else
				{
					elementExpressionEventHandler(writerControl_0, elementExpressionEventArgs_0);
				}
			}
		}

		public void method_38(string string_0, ElementQueryStateEventHandler elementQueryStateEventHandler_0)
		{
			method_41(dictionary_19, string_0, elementQueryStateEventHandler_0);
		}

		public void method_39(XTextElement xtextElement_0, ElementQueryStateEventArgs elementQueryStateEventArgs_0)
		{
			int num = 8;
			ElementQueryStateEventHandler elementQueryStateEventHandler = (ElementQueryStateEventHandler)method_40(dictionary_19, xtextElement_0);
			if (elementQueryStateEventHandler != null)
			{
				if (writerControl_0.Document.IsTryCathForRaiseEvent)
				{
					try
					{
						elementQueryStateEventHandler(writerControl_0, elementQueryStateEventArgs_0);
					}
					catch (Exception exception_)
					{
						writerControl_0.Document.method_39(elementQueryStateEventArgs_0.Element, exception_, "Element.QueryState");
					}
				}
				else
				{
					elementQueryStateEventHandler(writerControl_0, elementQueryStateEventArgs_0);
				}
			}
		}

		private Delegate method_40(IDictionary idictionary_0, XTextElement xtextElement_0)
		{
			if (xtextElement_0 == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(xtextElement_0.ID))
			{
				return null;
			}
			if (idictionary_0.Contains(xtextElement_0.ID))
			{
				return (Delegate)idictionary_0[xtextElement_0.ID];
			}
			return null;
		}

		private bool method_41(IDictionary idictionary_0, string string_0, Delegate delegate_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return false;
			}
			if ((object)delegate_0 == null)
			{
				return false;
			}
			string[] array = string_0.Split(',');
			bool result = false;
			string[] array2 = array;
			foreach (string text in array2)
			{
				string text2 = text.Trim();
				if (text2.Length > 0)
				{
					idictionary_0[text2] = delegate_0;
					result = true;
				}
			}
			return result;
		}
	}
}
