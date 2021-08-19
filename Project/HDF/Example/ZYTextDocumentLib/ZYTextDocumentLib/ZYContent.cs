using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ZYTextDocumentLib
{
	public class ZYContent : ICloneable
	{
		private ZYTextDocument myDocument = null;

		private List<ZYTextElement> myElements = null;

		private int intSelectStart = 0;

		private int intSelectLength = 0;

		private string strFixLenText = null;

		private bool bolModified = false;

		private bool bolAutoClearSelection = true;

		private int intLastXPos = -1;

		private bool bolLineEndFlag = false;

		protected int intUserLevel = 0;

		public bool LineEndFlag => bolLineEndFlag;

		public ZYTextDocument Document
		{
			get
			{
				return myDocument;
			}
			set
			{
				myDocument = value;
			}
		}

		public bool AutoClearSelection
		{
			get
			{
				return bolAutoClearSelection;
			}
			set
			{
				bolAutoClearSelection = value;
			}
		}

		public List<ZYTextElement> Elements
		{
			get
			{
				return myElements;
			}
			set
			{
				myElements = value;
				bolModified = false;
				strFixLenText = null;
				SetSelection(0, 0);
			}
		}

		public bool Modified
		{
			get
			{
				return bolModified;
			}
			set
			{
				bolModified = value;
			}
		}

		public int SelectStart
		{
			get
			{
				return intSelectStart;
			}
			set
			{
				if (bolAutoClearSelection)
				{
					SetSelection(value, 0);
				}
				else
				{
					SetSelection(value, intSelectStart - value);
				}
			}
		}

		public ZYTextLine PreLine
		{
			get
			{
				try
				{
					ZYTextLine currentLine = CurrentLine;
					if (myDocument.Lines.IndexOf(currentLine) > 0)
					{
						for (int num = intSelectStart - 1; num >= 0; num--)
						{
							ZYTextElement zYTextElement = myElements[num];
							if (zYTextElement.OwnerLine != currentLine)
							{
								return zYTextElement.OwnerLine;
							}
						}
						return null;
					}
					return currentLine;
				}
				catch
				{
				}
				return null;
			}
		}

		public ZYTextLine NextLine
		{
			get
			{
				try
				{
					ZYTextLine currentLine = CurrentLine;
					if (myDocument.Lines.IndexOf(currentLine) < myDocument.Lines.Count - 1)
					{
						for (int i = intSelectStart + 1; i < myElements.Count; i++)
						{
							ZYTextElement zYTextElement = myElements[i];
							if (zYTextElement.OwnerLine != currentLine)
							{
								return zYTextElement.OwnerLine;
							}
						}
						return null;
					}
					return currentLine;
				}
				catch
				{
				}
				return null;
			}
		}

		public ZYTextLine CurrentLine
		{
			get
			{
				if (myElements.Count == 0)
				{
					return null;
				}
				if (myElements != null && intSelectStart >= 0 && intSelectStart < myElements.Count)
				{
					ZYTextLine ownerLine = myElements[intSelectStart].OwnerLine;
					if (bolLineEndFlag && myDocument.Lines.IndexOf(ownerLine) > 0)
					{
						return (ZYTextLine)myDocument.Lines[myDocument.Lines.IndexOf(ownerLine) - 1];
					}
					return ownerLine;
				}
				return myElements[myElements.Count - 1].OwnerLine;
			}
		}

		public ZYTextElement CurrentElement
		{
			get
			{
				ZYTextElement zYTextElement = null;
				if (myElements.Count == 0)
				{
					return null;
				}
				zYTextElement = ((myElements == null || intSelectStart < 0 || intSelectStart >= myElements.Count) ? myElements[myElements.Count - 1] : myElements[intSelectStart]);
				if (zYTextElement.Parent.WholeElement)
				{
					zYTextElement = zYTextElement.Parent;
				}
				return zYTextElement;
			}
			set
			{
				if (myElements.Contains(value))
				{
					MoveSelectStart(myElements.IndexOf(value));
				}
				intSelectStart = FixIndex(intSelectStart);
			}
		}

		public ZYTextElement CurrentSelectElement
		{
			get
			{
				if (myElements.Count == 0 || (intSelectLength != 1 && intSelectLength != -1))
				{
					return null;
				}
				return myElements[AbsSelectStart];
			}
			set
			{
				if (myElements.Contains(value))
				{
					SetSelection(myElements.IndexOf(value) + 1, -1);
				}
			}
		}

		public ZYTextElement PreElement
		{
			get
			{
				if (myElements != null && myElements.Count > 0 && intSelectStart > 0 && intSelectStart < myElements.Count)
				{
					return myElements[intSelectStart - 1];
				}
				return null;
			}
		}

		public int UserLevel
		{
			get
			{
				return intUserLevel;
			}
			set
			{
				intUserLevel = value;
			}
		}

		public int SelectLength => intSelectLength;

		public int AbsSelectStart => (intSelectLength > 0) ? intSelectStart : (intSelectStart + intSelectLength);

		public int AbsSelectEnd
		{
			get
			{
				int num = (intSelectLength < 0) ? (intSelectStart - 1) : (intSelectStart + intSelectLength - 1);
				if (num >= myElements.Count - 1)
				{
					num = myElements.Count - 1;
				}
				return num;
			}
		}

		public int IndexOf(ZYTextElement e)
		{
			return myElements.IndexOf(e);
		}

		public ZYTextElement GetPreElement(ZYTextElement refElement)
		{
			int num = myElements.IndexOf(refElement);
			if (num >= 1)
			{
				return myElements[num - 1];
			}
			return null;
		}

		public ZYTextElement GetNextElement(ZYTextElement refElement)
		{
			int num = myElements.IndexOf(refElement);
			if (num >= 0 && num < myElements.Count - 1)
			{
				return myElements[num + 1];
			}
			return null;
		}

		public int GetMaxLockLevel()
		{
			int num = -1;
			for (int i = 0; i < myElements.Count; i++)
			{
				if (myElements[i] is ZYTextLock)
				{
					ZYTextLock zYTextLock = (ZYTextLock)myElements[i];
					if (num < zYTextLock.Level)
					{
						num = zYTextLock.Level;
					}
				}
			}
			return num;
		}

		public bool IsLock(int index)
		{
			if (index >= 0)
			{
				for (int i = index; i < myElements.Count; i++)
				{
					if (myElements[i] is ZYTextLock)
					{
						ZYTextLock zYTextLock = (ZYTextLock)myElements[i];
						if (zYTextLock.Level >= intUserLevel)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public bool IsLock(ZYTextElement element)
		{
			if (element is ZYTextFlag)
			{
				return !myDocument.Info.DesignMode;
			}
			if (element is ZYTextLock)
			{
				return !myDocument.Info.DesignMode;
			}
			int num = myElements.IndexOf(element);
			if (num >= 0)
			{
				return IsLock(num);
			}
			return false;
		}

		public bool isCurrentElement(ZYTextElement myElement)
		{
			return CurrentElement == myElement && intSelectLength == 0;
		}

		public ArrayList GetCurrentLineElements()
		{
			intSelectStart = FixIndex(intSelectStart);
			ZYTextElement zYTextElement = myElements[intSelectStart];
			int lineIndex = zYTextElement.LineIndex;
			int num = 0;
			for (int num2 = intSelectStart - 1; num2 >= 0; num2--)
			{
				zYTextElement = myElements[num2];
				if (zYTextElement.LineIndex != lineIndex)
				{
					num = num2 + 1;
					break;
				}
			}
			ArrayList arrayList = new ArrayList();
			for (int num2 = num; num2 < myElements.Count; num2++)
			{
				zYTextElement = myElements[num2];
				if (zYTextElement.LineIndex == lineIndex)
				{
					arrayList.Add(zYTextElement);
					continue;
				}
				break;
			}
			return arrayList;
		}

		public string GetCurrentLineHeadBlank()
		{
			intSelectStart = FixIndex(intSelectStart);
			ArrayList currentLineElements = GetCurrentLineElements();
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < currentLineElements.Count; i++)
			{
				ZYTextChar zYTextChar = currentLineElements[i] as ZYTextChar;
				if (zYTextChar != null && char.IsWhiteSpace(zYTextChar.Char))
				{
					stringBuilder.Append(zYTextChar.Char);
					continue;
				}
				break;
			}
			return stringBuilder.ToString();
		}

		public bool isSelected(ZYTextElement myElement)
		{
			if (intSelectLength == 0 || myElement == null)
			{
				return false;
			}
			int index = myElement.Index;
			if (intSelectLength > 0 && index >= intSelectStart && index < intSelectStart + intSelectLength)
			{
				return true;
			}
			if (intSelectLength < 0 && index >= intSelectStart + intSelectLength && index < intSelectStart)
			{
				return true;
			}
			return false;
		}

		public bool HasSelected()
		{
			return intSelectLength != 0;
		}

		public bool HasSelectedText()
		{
			List<ZYTextElement> selectElements = GetSelectElements();
			if (selectElements != null && selectElements.Count > 0)
			{
				foreach (ZYTextElement item in selectElements)
				{
					if (item.isTextElement())
					{
						return true;
					}
				}
			}
			return false;
		}

		public string GetSelectedText()
		{
			List<ZYTextElement> selectElements = GetSelectElements();
			if (selectElements != null && selectElements.Count > 0)
			{
				return ZYTextElement.GetElementsText(selectElements);
			}
			return null;
		}

		public bool HasSelectedChar()
		{
			List<ZYTextElement> selectElements = GetSelectElements();
			if (selectElements != null && selectElements.Count > 0)
			{
				foreach (ZYTextElement item in selectElements)
				{
					if (item is ZYTextChar)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool SetSelection(int NewSelectStart, int NewSelectLength)
		{
			bolLineEndFlag = false;
			if (myElements == null || myElements.Count == 0)
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			NewSelectStart = FixIndex(NewSelectStart);
			int num6 = (NewSelectStart > intSelectStart) ? 1 : (-1);
			bool flag = NewSelectLength == 0;
			for (int i = NewSelectStart; i >= 0 && i < myElements.Count; i += num6)
			{
				ZYTextElement zYTextElement = myElements[i];
				if (zYTextElement.Parent != null)
				{
					if (zYTextElement is ZYTextContainer || !zYTextElement.Parent.WholeElement)
					{
						NewSelectStart = i;
						break;
					}
					if (!flag)
					{
						NewSelectLength -= num6;
					}
				}
			}
			if (intSelectStart == NewSelectStart && intSelectLength == NewSelectLength)
			{
				return true;
			}
			int num7 = intSelectStart;
			if (NewSelectLength == 0 && intSelectLength == 0)
			{
				intSelectStart = NewSelectStart;
				if (intSelectStart < 0)
				{
					intSelectStart = 0;
				}
				if (intSelectStart >= myElements.Count)
				{
					intSelectStart = myElements.Count - 1;
				}
				ZYTextElement zYTextElement2 = myElements[intSelectStart];
				if (myDocument != null)
				{
					myDocument.SelectionChanged(num7, 0, intSelectStart, 0);
				}
				if (num7 >= 0 && num7 < myElements.Count)
				{
					myElements[num7].HandleLeave();
				}
				myElements[intSelectStart].HandleEnter();
				return true;
			}
			if (intSelectLength > 0)
			{
				num = intSelectStart;
				num2 = intSelectStart + intSelectLength;
			}
			else
			{
				num = intSelectStart + intSelectLength;
				num2 = intSelectStart;
			}
			if (NewSelectLength > 0)
			{
				num3 = NewSelectStart;
				num4 = NewSelectStart + NewSelectLength;
			}
			else
			{
				num3 = NewSelectStart + NewSelectLength;
				num4 = NewSelectStart;
			}
			if (num > num3)
			{
				num5 = num;
				num = num3;
				num3 = num5;
			}
			if (num2 > num4)
			{
				num5 = num2;
				num2 = num4;
				num4 = num5;
			}
			if (num3 > num2)
			{
				num5 = num3;
				num3 = num2;
				num2 = num5;
			}
			intSelectStart = NewSelectStart;
			intSelectLength = NewSelectLength;
			FixSelection();
			num = FixIndex(num);
			num2 = FixIndex(num2);
			num3 = FixIndex(num3);
			num4 = FixIndex(num4);
			if (num != num3)
			{
				for (int i = num; i <= num3; i++)
				{
					if (myElements[i].HandleSelectedChange())
					{
						return false;
					}
				}
			}
			if (num2 != num4)
			{
				for (int i = num2; i <= num4; i++)
				{
					if (myElements[i].HandleSelectedChange())
					{
						return false;
					}
				}
			}
			if (myDocument != null)
			{
				myDocument.SelectionChanged(num, num2, num3, num4);
			}
			if (num7 >= 0 && num7 < myElements.Count)
			{
				myElements[num7].HandleLeave();
			}
			myElements[intSelectStart].HandleEnter();
			return true;
		}

		private int FixIndex(int index)
		{
			if (index <= 0)
			{
				return 0;
			}
			if (index >= myElements.Count)
			{
				return myElements.Count - 1;
			}
			return index;
		}

		public void SelectAll()
		{
			SetSelection(0, myElements.Count);
		}

		public bool MoveSelectStart(int index)
		{
			index = FixIndex(index);
			return SetSelection(index, (!bolAutoClearSelection) ? (intSelectLength + intSelectStart - index) : 0);
		}

		public bool MoveSelectStart(ZYTextElement refElement)
		{
			if (myElements.IndexOf(refElement) >= 0)
			{
				return MoveSelectStart(myElements.IndexOf(refElement));
			}
			return false;
		}

		public List<ZYTextElement> GetSelectElements()
		{
			if (myElements == null)
			{
				return null;
			}
			List<ZYTextElement> list = new List<ZYTextElement>();
			int absSelectEnd = AbsSelectEnd;
			for (int i = AbsSelectStart; i <= absSelectEnd; i++)
			{
				list.Add(myElements[i]);
			}
			return list;
		}

		public ArrayList GetSelectParagraph()
		{
			if (myElements == null)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			int absSelectEnd = AbsSelectEnd;
			for (int i = AbsSelectStart; i < myElements.Count; i++)
			{
				if (myElements[i] is ZYTextParagraph)
				{
					arrayList.Add(myElements[i]);
					if (i > absSelectEnd)
					{
						break;
					}
				}
			}
			return arrayList;
		}

		public ArrayList GetElementsRange(int Index1, int Index2)
		{
			if (myElements == null)
			{
				return null;
			}
			ArrayList arrayList = new ArrayList();
			int num = 0;
			if (Index1 > Index2)
			{
				num = Index1;
				Index1 = Index2;
				Index2 = num;
			}
			Index1 = FixIndex(Index1);
			Index2 = FixIndex(Index2);
			for (int i = Index1; i < Index2; i++)
			{
				arrayList.Add(myElements[i]);
			}
			return arrayList;
		}

		public ZYTextElement GetSelectElement()
		{
			if (intSelectLength == 1)
			{
				return myElements[intSelectStart];
			}
			if (intSelectLength == -1)
			{
				return myElements[intSelectStart - 1];
			}
			return null;
		}

		public string GetSelectText()
		{
			return ZYTextElement.GetElementsText(GetSelectElements());
		}

		public bool ReplaceSelection(string strText)
		{
			if (strText == null || strText.Length == 0)
			{
				return false;
			}
			DeleteSeleciton();
			InsertString(strText);
			bolModified = true;
			return true;
		}

		public void InsertRangeElements(ArrayList myList)
		{
			if (myElements != null && myElements.Count != 0 && myList != null && myList.Count != 0 && !IsLock(intSelectStart))
			{
				ZYTextElement zYTextElement = myElements[intSelectStart];
				ZYTextContainer parent = zYTextElement.Parent;
				parent.InsertRangeBefore(myList, zYTextElement);
				parent.RefreshLine();
				bolModified = true;
				if (myDocument != null)
				{
					myDocument.ContentChanged();
				}
				AutoClearSelection = true;
				MoveSelectStart(intSelectStart + myList.Count);
			}
		}

		public void InsertString(string strText)
		{
			if (myElements == null || myElements.Count == 0 || IsLock(intSelectStart))
			{
				return;
			}
			ZYTextChar zYTextChar = null;
			ZYTextChar zYTextChar2 = null;
			ZYTextFlag zYTextFlag = null;
			for (int num = intSelectStart - 1; num >= 0; num--)
			{
				if (myElements[num] is ZYTextChar)
				{
					zYTextChar2 = (ZYTextChar)myElements[num];
					break;
				}
				if (myElements[num] is ZYTextFlag)
				{
					zYTextFlag = (ZYTextFlag)myElements[num];
				}
			}
			ZYTextElement zYTextElement = myElements[intSelectStart];
			ZYTextContainer parent = zYTextElement.Parent;
			ArrayList arrayList = new ArrayList();
			zYTextElement.OwnerDocument.ContentChangeLog.CanLog = false;
			for (int num = 0; num < strText.Length; num++)
			{
				if (strText[num] == '\n')
				{
					arrayList.Add(new ZYTextParagraph());
				}
				else if (strText[num] != '\r')
				{
					zYTextChar = zYTextElement.OwnerDocument.CreateChar(strText[num]);
					if (zYTextChar2 != null)
					{
						zYTextChar2.Attributes.CopyTo(zYTextChar.Attributes);
					}
					else if (zYTextFlag != null)
					{
						zYTextChar.Attributes.SetValue("fontsize", zYTextFlag.Attributes.GetFloat("fontsize"));
					}
					arrayList.Add(zYTextChar);
				}
			}
			zYTextElement.OwnerDocument.ContentChangeLog.CanLog = true;
			parent.InsertRangeBefore(arrayList, zYTextElement);
			parent.RefreshLine();
			bolModified = true;
			if (myDocument != null)
			{
				myDocument.ContentChanged();
			}
			AutoClearSelection = true;
			MoveSelectStart(intSelectStart + strText.Length);
		}

		public ZYTextChar GetPreChar()
		{
			for (int num = (intSelectStart == 0 && myElements.Count > 1) ? 1 : (intSelectStart - 1); num >= 0; num--)
			{
				if (myElements[num] is ZYTextChar)
				{
					return (ZYTextChar)myElements[num];
				}
			}
			return null;
		}

		public ZYTextChar InsertChar(char vChar)
		{
			if (myElements == null || myElements.Count == 0)
			{
				return null;
			}
			if (IsLock(intSelectStart))
			{
				return null;
			}
			if (intSelectStart < 0)
			{
				intSelectStart = 0;
			}
			if (intSelectStart >= myElements.Count)
			{
				intSelectStart = myElements.Count - 1;
			}
			ZYTextChar zYTextChar = null;
			ZYTextChar preChar = GetPreChar();
			ZYTextElement currentElement = CurrentElement;
			ZYTextContainer parent = currentElement.Parent;
			if (currentElement.OwnerDocument.ContentChangeLog != null)
			{
				currentElement.OwnerDocument.ContentChangeLog.CanLog = false;
			}
			zYTextChar = currentElement.OwnerDocument.CreateChar(vChar);
			if (preChar != null)
			{
				preChar.Attributes.CopyTo(zYTextChar.Attributes);
				zYTextChar.UpdateAttrubute();
			}
			if (currentElement.OwnerDocument.ContentChangeLog != null)
			{
				currentElement.OwnerDocument.ContentChangeLog.CanLog = true;
			}
			if (parent.InsertBefore(zYTextChar, currentElement))
			{
				bolModified = true;
				if (myDocument != null)
				{
					myDocument.ContentChanged();
				}
				AutoClearSelection = true;
				MoveSelectStart(intSelectStart + 1);
				return zYTextChar;
			}
			return null;
		}

		public void InsertElement(ZYTextElement NewElement)
		{
			if (myElements == null || myElements.Count == 0 || IsLock(intSelectStart))
			{
				return;
			}
			ZYTextElement zYTextElement = myElements[intSelectStart];
			ZYTextContainer parent = zYTextElement.Parent;
			if (parent.InsertBefore(NewElement, zYTextElement))
			{
				bolModified = true;
				if (myDocument != null)
				{
					myDocument.ContentChanged();
				}
				AutoClearSelection = true;
				MoveSelectStart(intSelectStart + 1);
			}
		}

		public void InsertLock(ZYTextElement NewElement)
		{
			if (myElements == null || myElements.Count == 0 || IsLock(intSelectStart))
			{
				return;
			}
			ZYTextElement zYTextElement = myElements[intSelectStart];
			ZYTextContainer parent = zYTextElement.Parent;
			if (CurrentLine.Elements.Count > 1)
			{
				ZYTextParagraph zYTextParagraph = new ZYTextParagraph();
				zYTextParagraph.OwnerDocument = myDocument;
				InsertElement(zYTextParagraph);
			}
			if (parent.InsertBefore(NewElement, zYTextElement))
			{
				bolModified = true;
				if (myDocument != null)
				{
					myDocument.ContentChanged();
				}
				AutoClearSelection = true;
				MoveSelectStart(intSelectStart + 1);
			}
		}

		public void DeleteSeleciton()
		{
			if (myElements == null || myElements.Count == 0 || IsLock(intSelectStart))
			{
				return;
			}
			int absSelectStart = AbsSelectStart;
			int absSelectEnd = AbsSelectEnd;
			int num = (intSelectLength > 0) ? intSelectLength : (-intSelectLength);
			bool flag = false;
			List<ZYTextElement> selectElements = GetSelectElements();
			ArrayList arrayList = new ArrayList();
			ZYTextContainer zYTextContainer = null;
			foreach (ZYTextElement item in selectElements)
			{
				if (zYTextContainer != null && zYTextContainer != item.Parent && zYTextContainer != null)
				{
					zYTextContainer.RemoveChildRange(arrayList);
					arrayList.Clear();
					zYTextContainer.RefreshLine();
				}
				zYTextContainer = item.Parent;
				flag = true;
				if (myDocument.isDeleteElement(item) == 0)
				{
					arrayList.Add(item);
				}
			}
			if (arrayList.Count > 0)
			{
				zYTextContainer.RemoveChildRange(arrayList);
				zYTextContainer.RefreshLine();
				flag = true;
			}
			if (flag)
			{
				bolModified = true;
				FixSelection();
				if (myDocument != null)
				{
					myDocument.ContentChanged();
				}
				SetSelection(absSelectStart, 0);
				FixSelection();
			}
		}

		private void FixSelection()
		{
			if (intSelectStart >= myElements.Count)
			{
				intSelectStart = myElements.Count - 1;
			}
			if (intSelectStart < 0)
			{
				intSelectStart = 0;
			}
			if (intSelectLength > 0 && intSelectStart + intSelectLength > myElements.Count)
			{
				intSelectLength = 0;
			}
			if (intSelectLength < 0 && intSelectStart + intSelectLength < 0)
			{
				intSelectLength = 0;
			}
		}

		public int DeleteCurrentElement()
		{
			if (myElements == null || myElements.Count == 0)
			{
				return 1;
			}
			if (IsLock(intSelectStart))
			{
				return 1;
			}
			if (CheckSelectStart())
			{
				ZYTextElement currentElement = CurrentElement;
				if (currentElement != myElements[myElements.Count - 1])
				{
					int num = myDocument.isDeleteElement(currentElement);
					if (num == 0)
					{
						if (currentElement.Parent.RemoveChild(currentElement))
						{
							bolModified = true;
							myDocument.ContentChanged();
							FixSelection();
						}
					}
					else if (num == 2 && !myDocument.Info.ShowAll)
					{
						bolModified = true;
						myDocument.ContentChanged();
						FixSelection();
					}
					return num;
				}
			}
			return 1;
		}

		public int DeletePreElement()
		{
			if (myElements == null || myElements.Count == 0)
			{
				return 1;
			}
			if (IsLock(intSelectStart - 1))
			{
				return 1;
			}
			if (intSelectStart > 0 && intSelectStart < myElements.Count)
			{
				ZYTextElement zYTextElement = myElements[intSelectStart - 1];
				if (!(zYTextElement is ZYTextContainer))
				{
					bool flag = false;
					if (zYTextElement.Parent != null)
					{
						if (zYTextElement.Parent.WholeElement)
						{
							flag = true;
						}
						if (zYTextElement.Parent is ZYTextBlock && zYTextElement == zYTextElement.Parent.GetLastElement())
						{
							flag = true;
						}
						if (flag)
						{
							zYTextElement = zYTextElement.Parent;
						}
					}
				}
				int newSelectStart = myElements.IndexOf(zYTextElement);
				int num = myDocument.isDeleteElement(zYTextElement);
				if (num == 0)
				{
					if (zYTextElement.Parent.RemoveChild(zYTextElement))
					{
						bolModified = true;
						myDocument.ContentChanged();
						SetSelection(newSelectStart, 0);
					}
				}
				else if (num == 2 && !myDocument.Info.ShowAll)
				{
					bolModified = true;
					myDocument.ContentChanged();
					SetSelection(newSelectStart, 0);
				}
				return num;
			}
			return 1;
		}

		public string GetText()
		{
			return ZYTextElement.GetElementsText(myElements);
		}

		public int GetPreWordIndex()
		{
			int result = -1;
			ZYTextLine currentLine = CurrentLine;
			int num = intSelectStart - 1;
			while (num >= 0 && myElements[num] is ZYTextChar)
			{
				ZYTextChar zYTextChar = (ZYTextChar)myElements[num];
				if (char.IsLetter(zYTextChar.Char) && zYTextChar.OwnerLine == currentLine)
				{
					result = num;
					num--;
					continue;
				}
				break;
			}
			return result;
		}

		public int GetPreWordIndex(ZYTextElement myElement)
		{
			int result = -1;
			if (myElement == null || !myElements.Contains(myElement))
			{
				return -1;
			}
			int num = myElements.IndexOf(myElement) - 1;
			while (num >= 0 && myElements[num] is ZYTextChar && char.IsLetter((myElements[num] as ZYTextChar).Char))
			{
				result = num;
				num--;
			}
			return result;
		}

		public string GetPreWord()
		{
			int preWordIndex = GetPreWordIndex();
			StringBuilder stringBuilder = new StringBuilder();
			ZYTextChar zYTextChar = null;
			if (preWordIndex >= 0)
			{
				for (int i = preWordIndex; i < intSelectStart; i++)
				{
					zYTextChar = (myElements[i] as ZYTextChar);
					if (zYTextChar != null && char.IsLetter(zYTextChar.Char))
					{
						stringBuilder.Append(zYTextChar.Char);
						continue;
					}
					break;
				}
			}
			if (stringBuilder.Length == 0)
			{
				return null;
			}
			return stringBuilder.ToString();
		}

		public string GetPreWord(ZYTextElement myElement)
		{
			int preWordIndex = GetPreWordIndex(myElement);
			StringBuilder stringBuilder = new StringBuilder();
			ZYTextChar zYTextChar = null;
			if (preWordIndex >= 0)
			{
				for (int i = preWordIndex; i < myElements.Count; i++)
				{
					zYTextChar = (myElements[i] as ZYTextChar);
					if (zYTextChar != null && char.IsLetter(zYTextChar.Char))
					{
						stringBuilder.Append(zYTextChar.Char);
						continue;
					}
					break;
				}
			}
			if (stringBuilder.Length == 0)
			{
				return null;
			}
			return stringBuilder.ToString();
		}

		public string GetRangeText(int intStartIndex, int intEndIndex)
		{
			intStartIndex = FixIndex(intStartIndex);
			intEndIndex = FixIndex(intEndIndex);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = intStartIndex; i <= intEndIndex; i++)
			{
				stringBuilder.Append(myElements[i].ToEMRString());
			}
			return stringBuilder.ToString();
		}

		internal string GetFixLenText()
		{
			if (myElements == null)
			{
				return null;
			}
			if (!bolModified && strFixLenText != null)
			{
				return strFixLenText;
			}
			char[] array = new char[myElements.Count];
			ZYTextChar zYTextChar = null;
			for (int i = 0; i < myElements.Count; i++)
			{
				zYTextChar = (myElements[i] as ZYTextChar);
				if (zYTextChar == null)
				{
					array[i] = '\u0001';
				}
				else
				{
					array[i] = zYTextChar.Char;
				}
			}
			strFixLenText = new string(array);
			return strFixLenText;
		}

		public bool FindText(string strText)
		{
			if (strText != null && strText.Length != 0)
			{
				GetFixLenText();
				if (strFixLenText != null)
				{
					int num = strFixLenText.IndexOf(strText, SelectStart);
					if (num >= 0)
					{
						SetSelection(num + strText.Length, -strText.Length);
					}
					return num >= 0;
				}
			}
			return false;
		}

		public bool ReplaceText(string strFind, string strReplace)
		{
			if (GetSelectText() == strFind)
			{
				ReplaceSelection(strReplace);
			}
			FindText(strFind);
			return true;
		}

		public int ReplaceTextAll(string strFind, string strReplace)
		{
			int num = 0;
			SetSelection(0, 0);
			while (FindText(strFind))
			{
				ReplaceSelection(strReplace);
				num++;
			}
			return num;
		}

		public void MoveUpOneLine2()
		{
			ZYTextElement zYTextElement = myElements[intSelectStart];
			int num = zYTextElement.RealLineIndex - 1;
			int realLeft = zYTextElement.RealLeft;
			ZYTextElement zYTextElement2 = null;
			int num2 = intSelectStart - 1;
			while (true)
			{
				if (num2 >= 0)
				{
					zYTextElement2 = myElements[num2];
					if (zYTextElement2.RealLineIndex == num && zYTextElement2.RealLeft <= realLeft)
					{
						MoveSelectStart(num2);
						return;
					}
					if (zYTextElement2.RealLineIndex < num)
					{
						break;
					}
					num2--;
					continue;
				}
				return;
			}
			MoveSelectStart(num2 + 1);
		}

		public void MoveUpOneLine()
		{
			ZYTextLine preLine = PreLine;
			if (preLine != null)
			{
				if (intLastXPos <= 0)
				{
					ZYTextElement zYTextElement = myElements[intSelectStart];
					intLastXPos = zYTextElement.RealLeft;
				}
				foreach (ZYTextElement element in preLine.Elements)
				{
					if (element.RealLeft >= intLastXPos)
					{
						MoveSelectStart(element);
						return;
					}
				}
				MoveSelectStart(preLine.LastElement);
			}
		}

		public void MoveDownOneLine()
		{
			ZYTextLine nextLine = NextLine;
			if (nextLine != null)
			{
				if (intLastXPos <= 0)
				{
					ZYTextElement zYTextElement = myElements[intSelectStart];
					intLastXPos = zYTextElement.RealLeft;
				}
				foreach (ZYTextElement element in nextLine.Elements)
				{
					if (element.RealLeft >= intLastXPos)
					{
						MoveSelectStart(element);
						return;
					}
				}
				MoveSelectStart(nextLine.LastElement);
			}
		}

		public void MoveLeft()
		{
			intLastXPos = -1;
			if (intSelectStart > 0)
			{
				MoveSelectStart(intSelectStart - 1);
			}
		}

		public void MoveRight()
		{
			intLastXPos = -1;
			if (intSelectStart < myElements.Count - 1)
			{
				MoveSelectStart(intSelectStart + 1);
			}
		}

		public void MoveEnd()
		{
			try
			{
				ZYTextLine currentLine = CurrentLine;
				if (currentLine != null && !bolLineEndFlag)
				{
					intLastXPos = -1;
					CurrentElement = currentLine.LastElement;
					if (currentLine.LastElement.isNewLine())
					{
						MoveSelectStart(currentLine.LastElement);
					}
					else
					{
						MoveSelectStart(myElements.IndexOf(currentLine.LastElement) + 1);
						bolLineEndFlag = true;
						myDocument.UpdateTextCaret();
					}
				}
			}
			catch
			{
			}
		}

		public void MoveHome()
		{
			ZYTextLine zYTextLine = null;
			zYTextLine = CurrentLine;
			if (zYTextLine != null)
			{
				intLastXPos = -1;
				int num = myElements.IndexOf(zYTextLine.FirstElement);
				int num2 = 0;
				foreach (ZYTextElement element in zYTextLine.Elements)
				{
					ZYTextChar zYTextChar = element as ZYTextChar;
					if (zYTextChar == null || !char.IsWhiteSpace(zYTextChar.Char))
					{
						num2 = zYTextLine.Elements.IndexOf(element);
						break;
					}
				}
				if (num2 == 0 || intSelectStart == num + num2)
				{
					MoveSelectStart(num);
				}
				else
				{
					MoveSelectStart(num + num2);
				}
			}
		}

		public ZYTextElement GetElementAt(int x, int y)
		{
			if (myDocument != null && myDocument.Lines != null && myDocument.Lines.Count > 0)
			{
				int num = -1;
				foreach (ZYTextLine line in myDocument.Lines)
				{
					if (line.RealLeft + line.ContentWidth >= x || !(line.Container is EMRCell))
					{
						if (num == -1)
						{
							num = line.RealTop;
						}
						if (y >= num && y < line.RealTop + line.Height)
						{
							x -= line.RealLeft;
							foreach (ZYTextElement element in line.Elements)
							{
								if (x > element.Left && x <= element.Left + element.Width + element.WidthFix)
								{
									if (!(element is EMRTable))
									{
										return element;
									}
									return (element as EMRTable).GetElementAt(x, y);
								}
							}
							return null;
						}
						num = line.RealTop + line.Height;
					}
				}
			}
			return null;
		}

		public void MoveTo(int x, int y)
		{
			intLastXPos = -1;
			if (myDocument == null)
			{
				return;
			}
			ZYTextLine zYTextLine = null;
			foreach (ZYTextLine line in myDocument.Lines)
			{
				if (line.RealTop + line.Height > y)
				{
					if (!(line.Container is EMRCell))
					{
						zYTextLine = line;
						break;
					}
					if (line.Container.Contains(x, y))
					{
						zYTextLine = line;
						break;
					}
				}
			}
			if (zYTextLine == null && myDocument.Lines.Count > 0)
			{
				zYTextLine = (ZYTextLine)myDocument.Lines[myDocument.Lines.Count - 1];
			}
			if (zYTextLine == null)
			{
				return;
			}
			bool flag = false;
			int num = 0;
			x -= zYTextLine.RealLeft;
			ZYTextElement zYTextElement = null;
			foreach (ZYTextElement element in zYTextLine.Elements)
			{
				if (x < element.Left + element.Width && (x <= element.Left + element.Width / 2 || element is EMRTable))
				{
					if (!element.Parent.WholeElement)
					{
						zYTextElement = element;
						if (zYTextElement is EMRTable)
						{
							zYTextElement = (zYTextElement as EMRTable).GetElementAt(x, y);
						}
						break;
					}
					return;
				}
			}
			if (zYTextElement == null)
			{
				if (zYTextLine.HasLineEnd)
				{
					num = myElements.IndexOf(zYTextLine.LastElement);
				}
				else
				{
					num = myElements.IndexOf(zYTextLine.LastElement) + 1;
					flag = true;
				}
			}
			else
			{
				num = myElements.IndexOf(zYTextElement);
				flag = false;
			}
			if (num > myElements.Count)
			{
				num = myElements.Count - 1;
				flag = false;
			}
			if (num < 0)
			{
				num = 0;
				flag = false;
			}
			MoveSelectStart(num);
			if (bolLineEndFlag != flag)
			{
				bolLineEndFlag = flag;
				myDocument.UpdateTextCaret();
			}
		}

		private bool CheckSelectStart()
		{
			if (myElements == null)
			{
				return false;
			}
			return intSelectStart >= 0 && intSelectStart <= myElements.Count - 1;
		}

		public void MoveStep(int iStep)
		{
			ZYTextElement zYTextElement = myElements[intSelectStart];
			MoveTo(zYTextElement.RealLeft, zYTextElement.RealTop + iStep);
		}

		public object Clone()
		{
			ZYContent zYContent = new ZYContent();
			zYContent.bolAutoClearSelection = bolAutoClearSelection;
			zYContent.bolLineEndFlag = bolLineEndFlag;
			zYContent.bolModified = bolModified;
			zYContent.intLastXPos = intLastXPos;
			zYContent.intSelectLength = intSelectLength;
			zYContent.intSelectStart = intSelectStart;
			zYContent.intUserLevel = intUserLevel;
			zYContent.myElements = new List<ZYTextElement>();
			zYContent.myElements.Clear();
			zYContent.myElements.AddRange(myElements);
			zYContent.strFixLenText = strFixLenText;
			return zYContent;
		}
	}
}
