using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[DCPublishAPI]
	[DocumentComment]
	[ComVisible(false)]
	internal class Class53 : GInterface3
	{
		private bool bool_0 = true;

		private Form form_0 = null;

		private XTextDocument xtextDocument_0 = null;

		private XTextContent xtextContent_0 = null;

		private bool bool_1 = false;

		public bool imethod_0()
		{
			return bool_0;
		}

		public void imethod_1(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public Form imethod_2()
		{
			if (form_0 != null && form_0.IsDisposed)
			{
				form_0 = null;
			}
			return form_0;
		}

		public void imethod_3(Form form_1)
		{
			form_0 = form_1;
		}

		public XTextDocument imethod_4()
		{
			return xtextDocument_0;
		}

		public void imethod_5(XTextDocument xtextDocument_1)
		{
			xtextDocument_0 = xtextDocument_1;
			if (xtextDocument_0 != null)
			{
				xtextContent_0 = xtextDocument_0.Content;
			}
		}

		public XTextContent imethod_6()
		{
			return xtextContent_0;
		}

		public void imethod_7(XTextContent xtextContent_1)
		{
			xtextContent_0 = xtextContent_1;
		}

		public int imethod_8(SearchReplaceCommandArgs searchReplaceCommandArgs_0)
		{
			int num = 0;
			if (searchReplaceCommandArgs_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			if (searchReplaceCommandArgs_0.SearchID)
			{
				return 0;
			}
			if (!imethod_4().UIStartEditContent())
			{
				return 0;
			}
			int num2 = 0;
			new List<int>();
			SearchReplaceCommandArgs searchReplaceCommandArgs = searchReplaceCommandArgs_0.Clone();
			searchReplaceCommandArgs.LogUndo = false;
			searchReplaceCommandArgs.ExcludeBackgroundText = true;
			imethod_4().BeginLogUndo();
			_ = imethod_4().CurrentContentElement;
			while (true)
			{
				int num3 = imethod_9(searchReplaceCommandArgs);
				if (num3 < 0)
				{
					break;
				}
				num2++;
			}
			imethod_4().EndLogUndo();
			return num2;
		}

		public int imethod_9(SearchReplaceCommandArgs searchReplaceCommandArgs_0)
		{
			int num = 17;
			if (searchReplaceCommandArgs_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			if (searchReplaceCommandArgs_0.SearchID)
			{
				return 0;
			}
			if (!imethod_4().UIStartEditContent())
			{
				return 0;
			}
			bool insertMode = false;
			bool flag = true;
			int int_ = -1;
			int lastSearchStartPosition;
			while (true)
			{
				int_ = imethod_11(searchReplaceCommandArgs_0, bool_2: true, int_);
				lastSearchStartPosition = imethod_4().LastSearchStartPosition;
				if (int_ >= 0)
				{
					if (flag)
					{
						flag = false;
						if (searchReplaceCommandArgs_0.LogUndo)
						{
							imethod_4().BeginLogUndo();
						}
						if (imethod_4().EditorControl != null)
						{
							insertMode = imethod_4().EditorControl.InsertMode;
							imethod_4().EditorControl.InsertMode = false;
						}
					}
					int absStartIndex = imethod_6().Selection.AbsStartIndex;
					if (string.IsNullOrEmpty(searchReplaceCommandArgs_0.ReplaceString))
					{
						if (!imethod_4().DocumentControler.Delete(showUI: true))
						{
							int_ = ((!searchReplaceCommandArgs_0.Backward) ? (int_ - searchReplaceCommandArgs_0.SearchString.Length - 1) : (int_ + searchReplaceCommandArgs_0.SearchString.Length + 1));
							continue;
						}
					}
					else
					{
						XTextElementList xTextElementList = imethod_4().DocumentControler.InsertString(searchReplaceCommandArgs_0.ReplaceString, searchReplaceCommandArgs_0.LogUndo, InputValueSource.Unknow, null, null);
						if (xTextElementList == null || xTextElementList.Count == 0)
						{
							int_ = ((!searchReplaceCommandArgs_0.Backward) ? (int_ - searchReplaceCommandArgs_0.SearchString.Length - 1) : (int_ + searchReplaceCommandArgs_0.SearchString.Length + 1));
							continue;
						}
					}
					if (int_ >= 0)
					{
						searchReplaceCommandArgs_0.MatchedIndexs.Add(absStartIndex);
						imethod_6().method_47(absStartIndex, searchReplaceCommandArgs_0.ReplaceString.Length);
					}
					if (imethod_4().EditorControl != null)
					{
						imethod_4().EditorControl.InsertMode = insertMode;
					}
					if (searchReplaceCommandArgs_0.LogUndo)
					{
						imethod_4().EndLogUndo();
					}
				}
				else
				{
					int_ = -1;
				}
				break;
			}
			imethod_4().LastSearchStartPosition = lastSearchStartPosition;
			return int_;
		}

		public int imethod_10(SearchReplaceCommandArgs searchReplaceCommandArgs_0)
		{
			int num = 0;
			if (searchReplaceCommandArgs_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			if (string.IsNullOrEmpty(searchReplaceCommandArgs_0.SearchString))
			{
				return -1;
			}
			searchReplaceCommandArgs_0.MatchedIndexs.Clear();
			XTextContent xTextContent = imethod_6();
			int length = searchReplaceCommandArgs_0.SearchString.Length;
			int count = xTextContent.Count;
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = xTextContent[i];
				if (!(xTextElement is XTextCharElement))
				{
					continue;
				}
				if (searchReplaceCommandArgs_0.ExcludeBackgroundText && xTextElement.Parent is XTextFieldElementBase)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement.Parent;
					if (xTextFieldElementBase.IsBackgroundTextElement(xTextElement))
					{
						i = xTextContent.IndexOf(xTextFieldElementBase.EndElement);
						continue;
					}
				}
				char charValue = ((XTextCharElement)xTextElement).CharValue;
				if (!method_1(charValue, searchReplaceCommandArgs_0.SearchString[0], searchReplaceCommandArgs_0.IgnoreCase))
				{
					continue;
				}
				if (length == 1)
				{
					searchReplaceCommandArgs_0.MatchedIndexs.Add(i);
				}
				else
				{
					if (count - i < length)
					{
						continue;
					}
					for (int j = 1; j < length; j++)
					{
						XTextElement xTextElement2 = xTextContent[i + j];
						if (!(xTextElement2 is XTextCharElement) || !method_1(((XTextCharElement)xTextElement2).CharValue, searchReplaceCommandArgs_0.SearchString[j], searchReplaceCommandArgs_0.IgnoreCase))
						{
							break;
						}
						if (j == length - 1)
						{
							searchReplaceCommandArgs_0.MatchedIndexs.Add(i);
							break;
						}
					}
				}
			}
			return searchReplaceCommandArgs_0.MatchedCount;
		}

		public int imethod_11(SearchReplaceCommandArgs searchReplaceCommandArgs_0, bool bool_2, int int_0)
		{
			int num = 8;
			if (searchReplaceCommandArgs_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			if (searchReplaceCommandArgs_0.SearchID)
			{
				XTextElement elementById = imethod_4().GetElementById(searchReplaceCommandArgs_0.SearchString);
				if (elementById != null)
				{
					int viewIndex = elementById.FirstContentElementInPublicContent.ViewIndex;
					if (bool_2 && bool_2)
					{
						elementById.Focus();
					}
					return viewIndex;
				}
				return -1;
			}
			if (string.IsNullOrEmpty(searchReplaceCommandArgs_0.SearchString))
			{
				return -1;
			}
			XTextContent xTextContent = imethod_6();
			int length = searchReplaceCommandArgs_0.SearchString.Length;
			int num2 = -1;
			if (searchReplaceCommandArgs_0.Backward)
			{
				while (true)
				{
					if (int_0 < 0)
					{
						int_0 = xTextContent.Selection.AbsEndIndex;
					}
					if (imethod_4().LastSearchStartPosition < 0)
					{
						imethod_4().LastSearchStartPosition = int_0;
						bool_1 = false;
					}
					int count = xTextContent.Count;
					int i;
					for (i = int_0; i < count; i++)
					{
						XTextElement elementById = xTextContent[i];
						if (!(elementById is XTextCharElement))
						{
							continue;
						}
						if (searchReplaceCommandArgs_0.ExcludeBackgroundText && elementById.Parent is XTextFieldElementBase)
						{
							XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)elementById.Parent;
							if (xTextFieldElementBase.IsBackgroundTextElement(elementById))
							{
								i = xTextContent.IndexOf(xTextFieldElementBase.EndElement);
								continue;
							}
						}
						char charValue = ((XTextCharElement)elementById).CharValue;
						if (!method_1(charValue, searchReplaceCommandArgs_0.SearchString[0], searchReplaceCommandArgs_0.IgnoreCase))
						{
							continue;
						}
						if (length != 1)
						{
							if (count - i < length)
							{
								continue;
							}
							int num3 = 1;
							while (num3 < length)
							{
								XTextElement xTextElement = xTextContent[i + num3];
								if (!(xTextElement is XTextCharElement) || !method_1(((XTextCharElement)xTextElement).CharValue, searchReplaceCommandArgs_0.SearchString[num3], searchReplaceCommandArgs_0.IgnoreCase))
								{
									break;
								}
								if (num3 != length - 1)
								{
									num3++;
									continue;
								}
								goto IL_02b6;
							}
							continue;
						}
						num2 = i;
						break;
					}
					if (num2 >= 0)
					{
						break;
					}
					if (!bool_1)
					{
						bool flag = true;
						if (imethod_0() && imethod_4().Options.BehaviorOptions.PromptJumpBackForSearch)
						{
							flag = imethod_4().AppHost.UITools.Confirm(imethod_4().EditorControl, WriterStrings.PromptJumpStartForSearch);
						}
						if (flag)
						{
							bool_1 = true;
							int_0 = 0;
							continue;
						}
					}
					return num2;
					IL_02b6:
					num2 = i;
					break;
				}
			}
			else
			{
				while (true)
				{
					if (int_0 < 0)
					{
						int_0 = xTextContent.Selection.AbsStartIndex - searchReplaceCommandArgs_0.SearchString.Length;
					}
					if (imethod_4().LastSearchStartPosition < 0)
					{
						imethod_4().LastSearchStartPosition = int_0;
						bool_1 = false;
					}
					char char_ = searchReplaceCommandArgs_0.SearchString[searchReplaceCommandArgs_0.SearchString.Length - 1];
					int i;
					for (i = int_0; i >= 0; i--)
					{
						XTextElement elementById = xTextContent[i];
						if (!(elementById is XTextCharElement))
						{
							continue;
						}
						if (searchReplaceCommandArgs_0.ExcludeBackgroundText && elementById.Parent is XTextFieldElementBase)
						{
							XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)elementById.Parent;
							if (xTextFieldElementBase.IsBackgroundTextElement(elementById))
							{
								i = xTextContent.IndexOf(xTextFieldElementBase.StartElement);
								continue;
							}
						}
						char charValue = ((XTextCharElement)elementById).CharValue;
						if (!method_1(charValue, char_, searchReplaceCommandArgs_0.IgnoreCase))
						{
							continue;
						}
						if (length != 1)
						{
							if (i < length - 1)
							{
								continue;
							}
							int num3 = length - 2;
							while (num3 >= 0)
							{
								XTextElement xTextElement = xTextContent[i - length + num3 + 1];
								if (!(xTextElement is XTextCharElement) || !method_1(((XTextCharElement)xTextElement).CharValue, searchReplaceCommandArgs_0.SearchString[num3], searchReplaceCommandArgs_0.IgnoreCase))
								{
									break;
								}
								if (num3 != 0)
								{
									num3--;
									continue;
								}
								goto IL_04de;
							}
							continue;
						}
						num2 = i;
						break;
					}
					if (num2 >= 0 || bool_1)
					{
						break;
					}
					bool flag = true;
					if (imethod_0() && imethod_4().Options.BehaviorOptions.PromptJumpBackForSearch)
					{
						flag = imethod_4().AppHost.UITools.Confirm(imethod_4().EditorControl, WriterStrings.PromptJumEndForSearch);
					}
					if (!flag)
					{
						break;
					}
					bool_1 = true;
					int_0 = xTextContent.Count - 1;
					continue;
					IL_04de:
					num2 = i - length + 1;
					break;
				}
			}
			if (bool_2 && num2 >= 0)
			{
				int lastSearchStartPosition = imethod_4().LastSearchStartPosition;
				if (xTextContent.method_47(num2, searchReplaceCommandArgs_0.SearchString.Length))
				{
					imethod_4().LastSearchStartPosition = lastSearchStartPosition;
					if (imethod_4().EditorControl != null)
					{
						imethod_4().EditorControl.UpdateTextCaret();
						method_0();
					}
				}
			}
			return num2;
		}

		private void method_0()
		{
			WriterControl editorControl = imethod_4().EditorControl;
			if (editorControl == null || imethod_2() == null || imethod_6().Selection.Length == 0)
			{
				return;
			}
			Rectangle bounds = imethod_2().Bounds;
			_ = bounds.Top + bounds.Height / 2;
			Rectangle elementClientBounds = editorControl.GetElementClientBounds(imethod_6().Selection.FirstElement);
			Rectangle elementClientBounds2 = editorControl.GetElementClientBounds(imethod_6().Selection.LastElement);
			Rectangle rectangle = Rectangle.Union(elementClientBounds, elementClientBounds2);
			rectangle.Location = editorControl.InnerViewControl.PointToScreen(rectangle.Location);
			if (rectangle.IntersectsWith(bounds))
			{
				if (Screen.FromControl(editorControl).WorkingArea.Bottom - rectangle.Bottom > bounds.Height)
				{
					bounds.Y = rectangle.Bottom + 10;
				}
				else if (rectangle.Top > bounds.Height)
				{
					bounds.Y = rectangle.Top - bounds.Height - 10;
				}
				imethod_2().Top = bounds.Top;
			}
		}

		public int imethod_12(SearchReplaceCommandArgs searchReplaceCommandArgs_0, XTextElementList xtextElementList_0, bool bool_2, int int_0)
		{
			int num = 12;
			if (searchReplaceCommandArgs_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			if (xtextElementList_0 == null)
			{
				throw new ArgumentNullException("elements");
			}
			if (xtextElementList_0.Count == 0)
			{
				return -1;
			}
			if (string.IsNullOrEmpty(searchReplaceCommandArgs_0.SearchString))
			{
				return -1;
			}
			if (xtextElementList_0 == null)
			{
				xtextElementList_0 = imethod_6();
			}
			int length = searchReplaceCommandArgs_0.SearchString.Length;
			int num2 = -1;
			if (searchReplaceCommandArgs_0.Backward)
			{
				if (int_0 < 0)
				{
					int_0 = 0;
				}
				int count = xtextElementList_0.Count;
				for (int i = int_0; i < count; i++)
				{
					XTextElement xTextElement = xtextElementList_0[i];
					if (!(xTextElement is XTextCharElement))
					{
						continue;
					}
					char charValue = ((XTextCharElement)xTextElement).CharValue;
					if (!method_1(charValue, searchReplaceCommandArgs_0.SearchString[0], searchReplaceCommandArgs_0.IgnoreCase))
					{
						continue;
					}
					if (length != 1)
					{
						if (count - i < length)
						{
							continue;
						}
						int num3 = 1;
						while (num3 < length)
						{
							XTextElement xTextElement2 = xtextElementList_0[i + num3];
							if (!(xTextElement2 is XTextCharElement) || !method_1(((XTextCharElement)xTextElement2).CharValue, searchReplaceCommandArgs_0.SearchString[num3], searchReplaceCommandArgs_0.IgnoreCase))
							{
								break;
							}
							if (num3 != length - 1)
							{
								num3++;
								continue;
							}
							goto IL_017d;
						}
						continue;
					}
					num2 = i;
					break;
					IL_017d:
					num2 = i;
					break;
				}
			}
			else
			{
				if (int_0 < 0)
				{
					int_0 = xtextElementList_0.Count - 1;
				}
				char char_ = searchReplaceCommandArgs_0.SearchString[searchReplaceCommandArgs_0.SearchString.Length - 1];
				int i = int_0;
				while (i >= 0)
				{
					XTextElement xTextElement = xtextElementList_0[i];
					if (xTextElement is XTextCharElement)
					{
						char charValue = ((XTextCharElement)xTextElement).CharValue;
						if (method_1(charValue, char_, searchReplaceCommandArgs_0.IgnoreCase))
						{
							if (length == 1)
							{
								num2 = i;
								break;
							}
							if (i >= length - 1)
							{
								int num3 = length - 2;
								while (num3 >= 0)
								{
									XTextElement xTextElement2 = xtextElementList_0[i - length + num3 + 1];
									if (!(xTextElement2 is XTextCharElement) || !method_1(((XTextCharElement)xTextElement2).CharValue, searchReplaceCommandArgs_0.SearchString[num3], searchReplaceCommandArgs_0.IgnoreCase))
									{
										break;
									}
									if (num3 != 0)
									{
										num3--;
										continue;
									}
									goto IL_028c;
								}
							}
						}
					}
					i--;
					continue;
					IL_028c:
					num2 = i - length + 1;
					break;
				}
			}
			if (bool_2 && num2 >= 0)
			{
				XTextElement xTextElement = xtextElementList_0[num2];
				int num4 = imethod_6().IndexOf(xTextElement);
				if (num4 >= 0 && imethod_6().method_47(num4, searchReplaceCommandArgs_0.SearchString.Length) && imethod_4().EditorControl != null)
				{
					WriterControl editorControl = imethod_4().EditorControl;
					editorControl.UpdateTextCaret();
					method_0();
				}
			}
			return num2;
		}

		private bool method_1(char char_0, char char_1, bool bool_2)
		{
			if (char_0 == char_1)
			{
				return true;
			}
			if (bool_2)
			{
				if (char.IsLower(char_0))
				{
					return char_0 == char.ToLower(char_1);
				}
				if (char.IsUpper(char_0))
				{
					return char_0 == char.ToUpper(char_1);
				}
			}
			return false;
		}
	}
}
