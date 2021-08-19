using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Undo;
using System.Collections.Generic;

namespace DCSoftDotfuscate
{
	internal class Class130 : GClass113
	{
		protected XTextDocument xtextDocument_0 = null;

		private int int_0 = 0;

		private int int_1 = 0;

		private int int_2 = 0;

		private int int_3 = 0;

		public Class130(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public XTextDocument method_0()
		{
			return xtextDocument_0;
		}

		public void method_1(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
		}

		public override void Undo(GEventArgs3 args)
		{
			method_2(args, bool_1: true);
		}

		public override void Redo(GEventArgs3 args)
		{
			method_2(args, bool_1: false);
		}

		private void method_2(GEventArgs3 geventArgs3_0, bool bool_1)
		{
			xtextDocument_0.UndoList.RefreshElements.Clear();
			xtextDocument_0.UndoList.dictionary_0.Clear();
			xtextDocument_0.UndoList.ContentChangedContainer.Clear();
			xtextDocument_0.UndoList.NeedInvokeMethods = UndoMethodTypes.None;
			if (bool_1)
			{
				base.Undo(geventArgs3_0);
			}
			else
			{
				base.Redo(geventArgs3_0);
			}
			if ((xtextDocument_0.UndoList.NeedInvokeMethods & UndoMethodTypes.RefreshDocument) == UndoMethodTypes.RefreshDocument)
			{
				if (method_0().EditorControl != null)
				{
					method_0().EditorControl.RefreshDocument();
					return;
				}
			}
			else
			{
				if ((xtextDocument_0.UndoList.NeedInvokeMethods & UndoMethodTypes.RefreshPages) == UndoMethodTypes.RefreshPages && method_0().EditorControl != null)
				{
					method_0().EditorControl.RefreshDocumentExt(refreshSize: false, executeLayout: false);
				}
				if ((xtextDocument_0.UndoList.NeedInvokeMethods & UndoMethodTypes.RefreshLayout) == UndoMethodTypes.RefreshLayout)
				{
					if (method_0().EditorControl != null)
					{
						method_0().EditorControl.RefreshDocumentExt(refreshSize: false, executeLayout: true);
					}
				}
				else if ((xtextDocument_0.UndoList.NeedInvokeMethods & UndoMethodTypes.RefreshComment) == UndoMethodTypes.RefreshComment)
				{
					method_0().EditorControl.CommentManager.imethod_2();
				}
				if ((xtextDocument_0.UndoList.NeedInvokeMethods & UndoMethodTypes.Invalidate) == UndoMethodTypes.Invalidate && method_0().EditorControl != null)
				{
					method_0().EditorControl.InnerViewControl.Invalidate();
				}
				if ((xtextDocument_0.UndoList.NeedInvokeMethods & UndoMethodTypes.UpdateExpressionExecuter) == UndoMethodTypes.UpdateExpressionExecuter && method_0().ExpressionExecuter != null)
				{
					method_0().ExpressionExecuter.imethod_3();
				}
				if ((xtextDocument_0.UndoList.NeedInvokeMethods & UndoMethodTypes.RefreshParagraphTree) == UndoMethodTypes.RefreshParagraphTree)
				{
					XTextDocumentContentElement xTextDocumentContentElement = method_0().Body;
					if (method_0().UndoList.RefreshElements != null && method_0().UndoList.RefreshElements.Count > 0)
					{
						xTextDocumentContentElement = method_0().UndoList.RefreshElements[0].DocumentContentElement;
					}
					if (xTextDocumentContentElement == null && method_0().UndoList.dictionary_0 != null)
					{
						foreach (XTextContentElement key in method_0().UndoList.dictionary_0.Keys)
						{
							xTextDocumentContentElement = key.DocumentContentElement;
							if (xTextDocumentContentElement != null)
							{
								break;
							}
						}
					}
					if (xTextDocumentContentElement == null)
					{
						xTextDocumentContentElement = method_0().Body;
					}
					xTextDocumentContentElement.method_57(bool_23: false, bool_24: true);
					if (method_0().EditorControl != null)
					{
						method_0().EditorControl.vmethod_12();
					}
				}
			}
			XTextElementList xTextElementList = new XTextElementList();
			Dictionary<XTextContentElement, int> dictionary = new Dictionary<XTextContentElement, int>();
			if (method_0().UndoList.dictionary_0.Count > 0)
			{
				XTextDocumentContentElement xTextDocumentContentElement = null;
				foreach (XTextContentElement key2 in method_0().UndoList.dictionary_0.Keys)
				{
					xTextDocumentContentElement = key2.DocumentContentElement;
					key2.vmethod_36(bool_22: false);
					dictionary[key2] = method_0().UndoList.dictionary_0[key2];
				}
				xTextDocumentContentElement.vmethod_36(bool_22: false);
			}
			if (method_0().UndoList.RefreshElements.Count > 0)
			{
				foreach (XTextElement refreshElement in method_0().UndoList.RefreshElements)
				{
					XTextContentElement current2 = refreshElement.ContentElement;
					if (current2 != null)
					{
						if (refreshElement is XTextSectionElement)
						{
							current2 = refreshElement.Parent.ContentElement;
						}
						if (dictionary.ContainsKey(current2))
						{
							int num = current2.PrivateContent.IndexOf(refreshElement);
							if (num >= 0 && num < dictionary[current2])
							{
								for (int num2 = dictionary[current2]; num2 >= num; num2--)
								{
									XTextElement xTextElement = current2.PrivateContent[num2];
									if (xTextElement.OwnerLine != null)
									{
										xTextElement.OwnerLine.InvalidateState = true;
									}
								}
								dictionary[current2] = num;
							}
						}
						else
						{
							current2.vmethod_36(bool_22: true);
							refreshElement.FirstContentElement.method_11(bool_5: true, bool_6: true);
							int num = current2.PrivateContent.IndexOf(refreshElement.FirstContentElementInPublicContent);
							if (num < 0)
							{
								num = current2.PrivateContent.IndexOf(refreshElement);
							}
							if (refreshElement is XTextParagraphFlagElement && num >= 0)
							{
								int num3 = current2.PrivateContent.IndexOf(refreshElement);
								bool flag = false;
								if (num3 < 0)
								{
									flag = true;
									num3 = current2.PrivateContent.Count - 1;
								}
								for (int num2 = num; num2 <= num3; num2++)
								{
									XTextElement xTextElement = current2.PrivateContent[num2];
									if (flag && xTextElement.Parent == refreshElement.Parent && xTextElement.ElementIndex > refreshElement.ElementIndex)
									{
										break;
									}
									if (xTextElement.OwnerLine != null)
									{
										xTextElement.OwnerLine.InvalidateState = true;
									}
								}
							}
							if (num >= 0)
							{
								dictionary[current2] = num;
							}
						}
					}
				}
				if (dictionary.Count == 0)
				{
					XTextDocumentContentElement xTextDocumentContentElement = null;
					foreach (XTextElement refreshElement2 in method_0().UndoList.RefreshElements)
					{
						XTextContentElement current2 = refreshElement2.ContentElement;
						if (current2 != null)
						{
							if (refreshElement2 is XTextSectionElement)
							{
								current2 = refreshElement2.Parent.ContentElement;
							}
							if (!dictionary.ContainsKey(current2))
							{
								xTextDocumentContentElement = current2.DocumentContentElement;
								current2.vmethod_36(bool_22: false);
								dictionary[current2] = 0;
								foreach (XTextLine privateLine in current2.PrivateLines)
								{
									privateLine.InvalidateState = true;
								}
							}
						}
					}
					xTextDocumentContentElement?.vmethod_36(bool_22: false);
				}
				using (DCGraphics dcgraphics_ = method_0().CreateDCGraphics())
				{
					DocumentPaintEventArgs args = method_0().method_55(dcgraphics_);
					foreach (XTextElement refreshElement3 in method_0().UndoList.RefreshElements)
					{
						XTextContentElement current2 = refreshElement3.ContentElement;
						if (current2 != null)
						{
							if (refreshElement3 is XTextSectionElement)
							{
								current2 = refreshElement3.Parent.ContentElement;
							}
							int num3 = current2.PrivateContent.IndexOf(refreshElement3.FirstContentElementInPublicContent);
							if (num3 >= 0)
							{
								if (refreshElement3.SizeInvalid || refreshElement3.ViewInvalid)
								{
									xTextElementList.Add(refreshElement3);
								}
								if (refreshElement3.SizeInvalid)
								{
									refreshElement3.RefreshSize(args);
								}
							}
						}
					}
				}
			}
			XTextDocumentContentElement xTextDocumentContentElement2 = method_0().Body;
			foreach (XTextContentElement key3 in dictionary.Keys)
			{
				xTextDocumentContentElement2 = key3.DocumentContentElement;
				int num = dictionary[key3];
				if (num <= 0)
				{
				}
				key3.vmethod_38(num, -1, bool_22: true);
			}
			xTextDocumentContentElement2?.method_57(bool_23: false, bool_24: true);
			if (!method_0().PageRefreshed)
			{
				method_0().RefreshPages();
				if (method_0().EditorControl != null)
				{
					method_0().EditorControl.UpdatePages();
					method_0().EditorControl.InnerViewControl.Invalidate();
				}
			}
			xTextDocumentContentElement2.Content.AutoClearSelection = true;
			xTextDocumentContentElement2.Content.LineEndFlag = false;
			if (bool_1)
			{
				xTextDocumentContentElement2.SetSelection(int_0, 0);
			}
			else
			{
				xTextDocumentContentElement2.SetSelection(int_2, 0);
			}
			foreach (XTextElement item in xTextElementList)
			{
				item.ViewInvalid = true;
				item.InvalidateView();
			}
			if (method_0().UndoList.ContentChangedContainer.Count > 0)
			{
				foreach (XTextContainerElement item2 in method_0().UndoList.ContentChangedContainer)
				{
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.EventSource = ContentChangedEventSource.UndoRedo;
					contentChangedEventArgs.Document = method_0();
					contentChangedEventArgs.Element = item2;
					item2.method_23(contentChangedEventArgs);
				}
				if (method_0().HighlightManager != null)
				{
					method_0().HighlightManager.imethod_7();
				}
				method_0().OnDocumentContentChanged();
			}
			if (method_0().EditorControl != null && method_0().EditorControl.ControlHostManger != null)
			{
				method_0().EditorControl.method_16();
				method_0().EditorControl.UpdateTextCaret();
				method_0().EditorControl.ControlHostManger.ReloadControls();
				method_0().EditorControl.Update();
			}
		}

		public int method_3()
		{
			return int_0;
		}

		public void method_4(int int_4)
		{
			int_0 = int_4;
		}

		public int method_5()
		{
			return int_1;
		}

		public void method_6(int int_4)
		{
			int_1 = int_4;
		}

		public int method_7()
		{
			return int_2;
		}

		public void method_8(int int_4)
		{
			int_2 = int_4;
		}

		public int method_9()
		{
			return int_3;
		}

		public void method_10(int int_4)
		{
			int_3 = int_4;
		}
	}
}
