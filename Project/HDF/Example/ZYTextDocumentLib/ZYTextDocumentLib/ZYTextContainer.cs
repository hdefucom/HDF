using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYTextContainer : ZYTextElement, ICloneable
	{
		protected ArrayList myLines = new ArrayList();

		protected int intMaxWidth = 0;

		protected int intLineSpan = 1;

		protected int intLeftMargin = 0;

		protected int intTopMargin = 0;

		protected int intRightMargin = 0;

		protected int intBottomMargin = 0;

		protected ArrayList myChildElements = new ArrayList();

		protected ZYTextElement myLastElement = null;

		protected bool bolDrawBackGround = true;

		protected Color intForeColor = SystemColors.WindowText;

		protected bool bolEnableForeColor = false;

		protected bool bolContainTextOnly = false;

		protected bool bolChildElementsLocked = false;

		protected bool bolLocked = false;

		private string strID;

		private string strName;

		protected int intClientWidth = 0;

		private SizeF titleSize = new SizeF(0f, 0f);

		public ArrayList myContentList = new ArrayList();

		public virtual bool WholeElement => false;

		public virtual bool EnableTypeSet => false;

		internal ZYTextElement vLastElement => myLastElement;

		public virtual bool Locked
		{
			get
			{
				if (myOwnerDocument.Loading)
				{
					return false;
				}
				if (myOwnerDocument.Locked)
				{
					return true;
				}
				return bolLocked;
			}
			set
			{
				bolLocked = value;
			}
		}

		public virtual bool Block => false;

		public bool TitleLine
		{
			get
			{
				return myAttributes.GetBool("titleline");
			}
			set
			{
				myAttributes.SetValue("titleline", value);
			}
		}

		public string Title
		{
			get
			{
				return myAttributes.GetString("title");
			}
			set
			{
				myAttributes.SetValue("title", value);
			}
		}

		public bool HideTitle
		{
			get
			{
				return myAttributes.GetBool("hidetitle");
			}
			set
			{
				myAttributes.SetValue("hidetitle", value);
			}
		}

		public string TitleAlign
		{
			get
			{
				return myAttributes.GetString("titlealign");
			}
			set
			{
				myAttributes.SetValue("titlealign", value);
			}
		}

		public string FontName
		{
			get
			{
				return myAttributes.GetString("fontname");
			}
			set
			{
				myAttributes.SetValue("fontname", value);
			}
		}

		public float FontSize
		{
			get
			{
				return myAttributes.GetFloat("fontsize");
			}
			set
			{
				myAttributes.SetValue("fontsize", value);
			}
		}

		public float indentWidth
		{
			get
			{
				Font font = new Font(FontName, FontSize + 2f, FontStyle.Bold);
				SizeF sizeF = myOwnerDocument.View.MeasureString("____", font);
				font.Dispose();
				return sizeF.Width;
			}
		}

		public string ValueSource
		{
			get
			{
				return myAttributes.GetString("valuesource");
			}
			set
			{
				myAttributes.SetValue("valuesource", value);
			}
		}

		public string ID
		{
			get
			{
				return strID;
			}
			set
			{
				myAttributes.SetValue("id", value);
				strID = value;
			}
		}

		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				myAttributes.SetValue("name", value);
				strName = value;
			}
		}

		public ArrayList Lines => myLines;

		public ZYTextElement LastElement
		{
			get
			{
				if (myChildElements != null && myChildElements.Count > 0)
				{
					return (ZYTextElement)myChildElements[myChildElements.Count - 1];
				}
				return null;
			}
		}

		public override ZYTextDocument OwnerDocument
		{
			get
			{
				return myOwnerDocument;
			}
			set
			{
				myOwnerDocument = value;
				if (myLastElement != null)
				{
					myLastElement.OwnerDocument = value;
				}
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					myChildElement.OwnerDocument = value;
				}
			}
		}

		public int LineSpan
		{
			get
			{
				return intLineSpan;
			}
			set
			{
				intLineSpan = value;
			}
		}

		public int MaxWidth
		{
			get
			{
				return intMaxWidth;
			}
			set
			{
				intMaxWidth = value;
			}
		}

		public override bool Deleteted
		{
			get
			{
				return base.Deleteted;
			}
			set
			{
				base.Deleteted = value;
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					myChildElement.Deleteted = value;
				}
			}
		}

		public override int Height
		{
			get
			{
				if (myLines.Count > 0)
				{
					ZYTextLine zYTextLine = (ZYTextLine)myLines[myLines.Count - 1];
					return zYTextLine.Top + zYTextLine.Height + intTopMargin + intBottomMargin;
				}
				return myOwnerDocument.DefaultRowHeight + intTopMargin + intBottomMargin;
			}
			set
			{
			}
		}

		public SizeF TitleSize
		{
			get
			{
				string title = Title;
				if (HideTitle || StringCommon.isBlankString(title))
				{
					return new SizeF(0f, 0f);
				}
				using (Font myFont = new Font(FontName, FontSize + 2f, FontStyle.Bold))
				{
					SizeF result = myOwnerDocument.View.MeasureString(title, myFont);
					result.Width += 2f;
					if (TitleLine)
					{
						result.Width = 0f;
					}
					return result;
				}
			}
			set
			{
				titleSize = value;
			}
		}

		public ArrayList ChildElements => myChildElements;

		public int ChildCount => myChildElements.Count;

		public virtual void UpdateUserLogin()
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement is ZYTextContainer)
				{
					(myChildElement as ZYTextContainer).UpdateUserLogin();
				}
			}
		}

		public virtual bool Contains(int x, int y)
		{
			return myChildElements.Contains(myOwnerDocument.Content.GetElementAt(x, y));
		}

		public override bool RefreshSize()
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				myChildElement.RefreshSize();
			}
			return true;
		}

		protected virtual void RefreshClientWidth()
		{
			if (myParent == null)
			{
				if (myOwnerDocument != null && myOwnerDocument.Info.WordWrap)
				{
					intClientWidth = myOwnerDocument.Pages.StandardWidth - RealLeft - intLeftMargin - intRightMargin;
				}
				else
				{
					intClientWidth = 0;
				}
			}
			else
			{
				intClientWidth = Width - intLeftMargin - intRightMargin;
			}
		}

		internal int GetClientWidth()
		{
			return intClientWidth;
		}

		protected virtual SizeF GetTitleSize()
		{
			string title = Title;
			if (HideTitle || StringCommon.isBlankString(title))
			{
				return new SizeF(0f, 0f);
			}
			using (Font myFont = new Font(FontName, FontSize + 2f, FontStyle.Bold))
			{
				SizeF result = myOwnerDocument.View.MeasureString(title, myFont);
				result.Width += 8f;
				if (TitleLine)
				{
					result.Width = 0f;
					return result;
				}
				return result;
			}
		}

		public virtual void RefreshLine()
		{
			if (myParent == null)
			{
				intWidth = 0;
			}
			RefreshLineFast(0);
		}

		public virtual void RefreshLineFast(int StartIndex)
		{
			List<ZYTextElement> list = new List<ZYTextElement>();
			int height = Height;
			RefreshClientWidth();
			int num = (int)TitleSize.Width;
			if (!TitleLine && TitleAlign == "tab")
			{
				num = (int)TitleSize.Width + (int)indentWidth;
			}
			int num2 = 0;
			if (StartIndex < 0 || StartIndex > myChildElements.Count - 1)
			{
				StartIndex = 0;
			}
			if (StartIndex == 0)
			{
				myLines.Clear();
			}
			else
			{
				ZYTextElement zYTextElement = myChildElements[StartIndex] as ZYTextElement;
				num2 = zYTextElement.LineIndex;
				myLines.RemoveRange(num2, myLines.Count - num2);
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					if (myChildElement == zYTextElement)
					{
						break;
					}
					if (myChildElement.LineIndex == num2)
					{
						list.Add(myChildElement);
						num += myChildElement.Width;
					}
				}
			}
			bool flag = false;
			ZYTextElement zYTextElement3 = null;
			myContentList.Clear();
			myContentList.AddRange(myChildElements);
			for (int i = StartIndex; i < myContentList.Count; i++)
			{
				ZYTextElement zYTextElement2 = (ZYTextElement)myContentList[i];
				if (zYTextElement2.Visible)
				{
					if (zYTextElement2 is ZYTextCharTab)
					{
						(zYTextElement2 as ZYTextCharTab).RefreshTabWidth();
					}
					if (zYTextElement2 is ZYTextHRule)
					{
						zYTextElement2.RefreshSize();
					}
					flag = true;
					if (zYTextElement2 is ZYTextContainer)
					{
						ZYTextContainer zYTextContainer = (ZYTextContainer)zYTextElement2;
						if (zYTextContainer.Block)
						{
							myContentList.InsertRange(myContentList.IndexOf(zYTextContainer) + 1, zYTextContainer.ChildElements);
						}
						else
						{
							zYTextContainer.RefreshLine();
						}
					}
					if (zYTextElement2.OwnerWholeLine() || (zYTextElement3 != null && zYTextElement3.OwnerWholeLine()))
					{
						flag = false;
					}
					else if (!zYTextElement2.isNewLine() && intClientWidth > 0)
					{
						if (num + zYTextElement2.Width > intClientWidth)
						{
							flag = false;
						}
						else if (i < myContentList.Count - 2)
						{
							ZYTextElement zYTextElement4 = (ZYTextElement)myContentList[i + 1];
							if ((!zYTextElement4.CanBeLineHead() || !zYTextElement2.CanBeLineEnd()) && num + zYTextElement2.Width + zYTextElement4.Width > intClientWidth)
							{
								flag = false;
							}
						}
					}
					if (flag)
					{
						list.Add(zYTextElement2);
						num += zYTextElement2.Width;
					}
					else
					{
						ResetLine(list);
						list.Clear();
						num = intLeftMargin;
						list.Add(zYTextElement2);
						num += zYTextElement2.Width;
					}
					if (zYTextElement2.isNewLine())
					{
						ResetLine(list);
						list.Clear();
						num = intLeftMargin;
					}
				}
				else
				{
					zYTextElement2.OwnerLine = null;
				}
				zYTextElement3 = zYTextElement2;
			}
			if (list.Count > 0)
			{
				ResetLine(list);
			}
			if (myParent == null && myOwnerDocument != null && !myOwnerDocument.Info.WordWrap)
			{
				foreach (ZYTextLine myLine in myLines)
				{
					if (intWidth < intLeftMargin + intRightMargin + myLine.ContentWidth)
					{
						intWidth = intLeftMargin + intRightMargin + myLine.ContentWidth;
					}
				}
			}
			UpdateBounds();
			if (Height != height && !myOwnerDocument.Loading)
			{
				myOwnerDocument.RefreshAllFlag = true;
			}
		}

		public virtual void UpdateBounds()
		{
			int num = 0;
			if (TitleLine)
			{
				num = (int)TitleSize.Height;
			}
			Rectangle empty = Rectangle.Empty;
			foreach (ZYTextLine myLine in myLines)
			{
				myLine.Top = num;
				myLine.RealTop = RealTop + num;
				myLine.RealLeft = RealLeft;
				if (myLine.LastElement != null && myLine.LastElement.isNewParagraph())
				{
					myLine.LineSpacing = myOwnerDocument.Info.ParagraphSpacing;
				}
				else
				{
					myLine.LineSpacing = myOwnerDocument.Info.LineSpacing;
				}
				num += myLine.FullHeight;
				foreach (ZYTextElement element in myLine.Elements)
				{
					empty = new Rectangle(element.RealLeft, element.RealTop, element.Width + element.WidthFix, element.Height);
					if (!empty.Equals(element.Bounds))
					{
						if (myOwnerDocument.OwnerControl != null && !(element is ZYTextContainer))
						{
							if (!element.Bounds.IsEmpty)
							{
								myOwnerDocument.OwnerControl.AddInvalidateRect(element.Bounds);
							}
							myOwnerDocument.OwnerControl.AddInvalidateRect(empty);
						}
						element.myBounds = empty;
					}
					if (element is ZYTextContainer)
					{
						ZYTextContainer zYTextContainer = (ZYTextContainer)element;
						zYTextContainer.UpdateBounds();
					}
				}
			}
		}

		private int ResetLine(List<ZYTextElement> LineElements)
		{
			if (LineElements == null || LineElements.Count == 0)
			{
				return 0;
			}
			ZYTextLine zYTextLine = new ZYTextLine();
			zYTextLine.Index = myLines.Count;
			zYTextLine.Container = this;
			zYTextLine.RealLeft = RealLeft;
			zYTextLine.Elements.AddRange(LineElements);
			foreach (ZYTextElement LineElement in LineElements)
			{
				if (zYTextLine.Height < LineElement.Height)
				{
					zYTextLine.Height = LineElement.Height;
				}
				zYTextLine.ContentWidth += LineElement.Width;
			}
			myLines.Add(zYTextLine);
			myOwnerDocument.AddLine(zYTextLine);
			if (myLines.Count == 1 && !TitleLine && zYTextLine.Height < (int)TitleSize.Height)
			{
				zYTextLine.Height = (int)TitleSize.Height;
			}
			int num = intClientWidth;
			if (myLines.Count == 1)
			{
				if (TitleAlign == "tab" && !TitleLine)
				{
					Font font = new Font(FontName, FontSize + 2f, FontStyle.Bold);
					num -= (int)(TitleSize.Width + indentWidth);
					font.Dispose();
				}
				else
				{
					num -= (int)TitleSize.Width;
				}
			}
			ParagraphAlignConst paragraphAlignConst = ParagraphAlignConst.Left;
			if (zYTextLine.HasLineEnd)
			{
				for (int i = myContentList.IndexOf(LineElements[LineElements.Count - 1]); i < myContentList.Count; i++)
				{
					if (myContentList[i] is ZYTextParagraph)
					{
						paragraphAlignConst = (myContentList[i] as ZYTextParagraph).Align;
						break;
					}
				}
			}
			int num2 = 0;
			switch (paragraphAlignConst)
			{
			case ParagraphAlignConst.Left:
				num2 = intLeftMargin;
				break;
			case ParagraphAlignConst.Center:
				num2 = intLeftMargin + (num - zYTextLine.ContentWidth) / 2;
				break;
			case ParagraphAlignConst.Right:
				num2 = intLeftMargin + num - zYTextLine.ContentWidth;
				break;
			case ParagraphAlignConst.Justify:
				num2 = intLeftMargin;
				break;
			}
			if (myLines.Count == 1)
			{
				if (TitleAlign == "tab" && !TitleLine)
				{
					Font font = new Font(FontName, FontSize + 2f, FontStyle.Bold);
					num2 += (int)(TitleSize.Width + indentWidth);
					font.Dispose();
				}
				else
				{
					num2 += (int)TitleSize.Width;
				}
			}
			int num3 = 0;
			int num4 = 0;
			if (LineElements.Count > 0 && (!zYTextLine.HasLineEnd || paragraphAlignConst == ParagraphAlignConst.Justify))
			{
				num4 = num - zYTextLine.ContentWidth;
				num3 = (int)Math.Ceiling((double)num4 / (double)(LineElements.Count - 1));
				if (num4 > 0 && num3 < 1)
				{
					num3 = 1;
				}
			}
			foreach (ZYTextElement LineElement2 in LineElements)
			{
				LineElement2.OwnerLine = zYTextLine;
				LineElement2.Left = num2;
				LineElement2.Top = zYTextLine.Height - LineElement2.Height;
				LineElement2.WidthFix = 0;
				num2 += LineElement2.Width;
				if (num3 > 0 && LineElement2 is ZYTextChar)
				{
					num2 += num3;
					LineElement2.WidthFix = num3;
					num4 -= num3;
					if (num4 <= 0)
					{
						num3 = 0;
					}
				}
			}
			if (myParent == null && !myOwnerDocument.Info.WordWrap && intWidth < num2)
			{
				intWidth = num2;
			}
			zYTextLine.RealIndex = zYTextLine.CalcuteRealIndex();
			return zYTextLine.Height;
		}

		public virtual int AppendKeyValueList(ArrayList myKeyValues)
		{
			return 0;
		}

		public virtual void RaiseOnChangeEvent()
		{
			if (myOwnerDocument.OwnerControl != null && !myOwnerDocument.Loading)
			{
				myOwnerDocument.InitEventObject(ZYVBEventType.OnChange);
				myOwnerDocument.RunEventScript(this, "onchange");
			}
		}

		public bool ContainsElements(List<ZYTextElement> myList)
		{
			if (myList != null && myList.Count > 0)
			{
				foreach (ZYTextElement my in myList)
				{
					if (!myChildElements.Contains(my) && my != this)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public virtual bool AppendChild(ZYTextElement newElement)
		{
			if (bolChildElementsLocked)
			{
				return false;
			}
			if (newElement != null && !myChildElements.Contains(newElement))
			{
				if (newElement.Parent != null)
				{
					newElement.Parent.RemoveChild(newElement);
				}
				myChildElements.Add(newElement);
				newElement.Parent = this;
				newElement.OwnerDocument = myOwnerDocument;
				OnChildElementsChange();
				return true;
			}
			return false;
		}

		public virtual bool RemoveChild(ZYTextElement refElement)
		{
			if (bolChildElementsLocked)
			{
				return false;
			}
			if (!Locked && refElement != null && myChildElements.Contains(refElement) && refElement != myLastElement)
			{
				if (myOwnerDocument.CanContentChangeLog)
				{
					myOwnerDocument.ContentChangeLog.Container = this;
					myOwnerDocument.ContentChangeLog.LogRemove(myChildElements.IndexOf(refElement), refElement);
				}
				myChildElements.Remove(refElement);
				OnChildElementsChange();
				return true;
			}
			return false;
		}

		public virtual int RemoveBlankLine()
		{
			int num = 0;
			for (int i = 0; i < myChildElements.Count - 1; i++)
			{
				ZYTextElement zYTextElement = (ZYTextElement)myChildElements[i];
				if (zYTextElement is ZYTextParagraph && zYTextElement.OwnerLine.Elements.Count == 1)
				{
					myOwnerDocument.BeginContentChangeLog();
					myOwnerDocument.ContentChangeLog.Container = this;
					myOwnerDocument.ContentChangeLog.LogRemove(i, zYTextElement);
					myOwnerDocument.EndContentChangeLog();
					num++;
					i--;
				}
				else if (zYTextElement is ZYTextContainer)
				{
					num += (zYTextElement as ZYTextContainer).RemoveBlankLine();
				}
			}
			return num;
		}

		public virtual int RemoveBlankKeyField2(bool ContentLog)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			int num = 0;
			bool flag = true;
			int num2 = 0;
			for (int i = 0; i < myChildElements.Count; i++)
			{
				bool flag2 = false;
				ZYTextElement zYTextElement = (ZYTextElement)myChildElements[i];
				if (IsLastElement(zYTextElement))
				{
					flag2 = true;
				}
				else if (zYTextElement is ZYTextChar)
				{
					ZYTextChar zYTextChar = (ZYTextChar)zYTextElement;
					if (zYTextChar.IsSymbol() && arrayList2.Count > 0)
					{
						flag2 = true;
					}
					arrayList2.Add(zYTextElement);
				}
				else if (zYTextElement is ZYTextBlock)
				{
					ZYTextBlock zYTextBlock = (ZYTextBlock)zYTextElement;
					if (!zYTextBlock.KeyField || StringCommon.HasContent(zYTextBlock.ToEMRString()))
					{
						flag = false;
					}
					num2++;
					arrayList2.Add(zYTextElement);
				}
				else
				{
					if (zYTextElement is ZYTextContainer)
					{
						num += ((ZYTextContainer)zYTextElement).RemoveBlankKeyField2(ContentLog);
						continue;
					}
					flag2 = true;
				}
				if (!flag2)
				{
					continue;
				}
				if (arrayList2.Count > 0 && flag && num2 > 0)
				{
					ZYTextChar zYTextChar2 = arrayList2[0] as ZYTextChar;
					ZYTextChar zYTextChar3 = arrayList2[arrayList2.Count - 1] as ZYTextChar;
					if (arrayList2.Count > 1 && zYTextChar2 != null && zYTextChar3 != null)
					{
						int symbolSplitLevel = StringCommon.GetSymbolSplitLevel(zYTextChar2.Char);
						int symbolSplitLevel2 = StringCommon.GetSymbolSplitLevel(zYTextChar3.Char);
						if (symbolSplitLevel != 0 && symbolSplitLevel2 != 0)
						{
							arrayList2.RemoveAt((symbolSplitLevel < symbolSplitLevel2) ? (arrayList2.Count - 1) : 0);
						}
					}
					if (arrayList2.Count > 0)
					{
						int num3 = myChildElements.IndexOf(arrayList2[0]);
						if (ContentLog)
						{
							myOwnerDocument.BeginContentChangeLog();
							myOwnerDocument.ContentChangeLog.Container = this;
							myOwnerDocument.ContentChangeLog.LogRemoveRange(num3, arrayList2);
							myOwnerDocument.EndContentChangeLog();
						}
						myChildElements.RemoveRange(num3, arrayList2.Count);
						num += arrayList2.Count;
						i = num3 - 1;
					}
				}
				num2 = 0;
				arrayList2.Clear();
				flag = true;
			}
			return num;
		}

		public virtual int RemoveBlankKeyField(bool ContentLog)
		{
			ArrayList arrayList = new ArrayList();
			int num = 0;
			for (int i = 0; i < myChildElements.Count; i++)
			{
				ZYTextElement zYTextElement = (ZYTextElement)myChildElements[i];
				if (!zYTextElement.Deleteted && zYTextElement is ZYTextBlock)
				{
					ZYTextBlock zYTextBlock = (ZYTextBlock)zYTextElement;
					if (!zYTextBlock.KeyField || !StringCommon.isBlankString(zYTextBlock.ToEMRString()))
					{
						continue;
					}
					int num2 = 0;
					int num3 = myChildElements.Count - 2;
					ZYTextChar zYTextChar = null;
					ZYTextChar zYTextChar2 = null;
					for (int j = myChildElements.IndexOf(zYTextBlock); j < myChildElements.Count; j++)
					{
						if (myChildElements[j] is ZYTextChar && ((ZYTextChar)myChildElements[j]).IsSymbol())
						{
							num3 = j;
							zYTextChar2 = (ZYTextChar)myChildElements[j];
							break;
						}
					}
					for (int j = myChildElements.IndexOf(zYTextBlock); j >= 0; j--)
					{
						if (myChildElements[j] is ZYTextChar && ((ZYTextChar)myChildElements[j]).IsSymbol())
						{
							num2 = j;
							zYTextChar = (ZYTextChar)myChildElements[j];
							break;
						}
					}
					bool flag = true;
					if (zYTextChar != null && zYTextChar2 != null && StringCommon.GetSymbolSplitLevel(zYTextChar.Char) < StringCommon.GetSymbolSplitLevel(zYTextChar2.Char))
					{
						flag = false;
					}
					if (flag)
					{
						num2++;
					}
					else
					{
						num3--;
					}
					if (num3 < num2)
					{
						continue;
					}
					if (ContentLog)
					{
						myOwnerDocument.BeginContentChangeLog();
					}
					if (myOwnerDocument.CanContentChangeLog)
					{
						myOwnerDocument.ContentChangeLog.Container = this;
					}
					for (int j = num2; j <= num3; j++)
					{
						if (myOwnerDocument.CanContentChangeLog)
						{
							myOwnerDocument.ContentChangeLog.LogRemove(num2, (ZYTextElement)myChildElements[num2]);
						}
						myChildElements.RemoveAt(num2);
						num++;
					}
					if (ContentLog)
					{
						myOwnerDocument.EndContentChangeLog();
					}
					i = num2 - 1;
				}
				else if (zYTextElement is ZYTextContainer)
				{
					num += ((ZYTextContainer)zYTextElement).RemoveBlankKeyField(ContentLog);
				}
			}
			return num;
		}

		public virtual int RemoveChildRange(ArrayList myList)
		{
			if (bolChildElementsLocked)
			{
				return 0;
			}
			int num = 0;
			if (!Locked && myList != null && myList.Count > 0)
			{
				foreach (ZYTextElement my in myList)
				{
					if (myChildElements.Contains(my) && my != myLastElement)
					{
						if (myOwnerDocument.CanContentChangeLog)
						{
							myOwnerDocument.ContentChangeLog.Container = this;
							myOwnerDocument.ContentChangeLog.LogRemove(myChildElements.IndexOf(my), my);
						}
						myChildElements.Remove(my);
						num++;
					}
				}
				if (num > 0)
				{
					OnChildElementsChange();
				}
			}
			return num;
		}

		protected virtual bool BeforeInsert(ZYTextElement NewElement)
		{
			if (bolChildElementsLocked)
			{
				return false;
			}
			if (bolContainTextOnly && !(NewElement is ZYTextChar))
			{
				return false;
			}
			return myOwnerDocument.BeforeInsertElemnt(this, NewElement);
		}

		public virtual bool InsertBefore(ZYTextElement NewElement, ZYTextElement refElement)
		{
			if (bolChildElementsLocked)
			{
				return false;
			}
			if (NewElement == null || Locked)
			{
				return false;
			}
			if (BeforeInsert(NewElement))
			{
				if (myChildElements.Contains(NewElement))
				{
					myChildElements.Remove(NewElement);
				}
				if (refElement != null && myChildElements.Contains(refElement))
				{
					int index = myChildElements.IndexOf(refElement);
					if (myOwnerDocument.ContentChangeLog != null)
					{
						myOwnerDocument.ContentChangeLog.Container = this;
						myOwnerDocument.ContentChangeLog.LogInsert(index, NewElement);
					}
					myChildElements.Insert(index, NewElement);
				}
				else
				{
					if (myOwnerDocument.ContentChangeLog != null)
					{
						myOwnerDocument.ContentChangeLog.Container = this;
						myOwnerDocument.ContentChangeLog.LogAdd(NewElement);
					}
					myChildElements.Add(NewElement);
				}
				NewElement.Parent = this;
				NewElement.OwnerDocument = myOwnerDocument;
				NewElement.RefreshSize();
				NewElement.Visible = true;
				OnChildElementsChange();
				return true;
			}
			return false;
		}

		public virtual bool InsertRangeBefore(ArrayList myList, ZYTextElement refElement)
		{
			if (bolChildElementsLocked)
			{
				return false;
			}
			if (myList == null || Locked)
			{
				return false;
			}
			ArrayList arrayList = new ArrayList();
			foreach (ZYTextElement my in myList)
			{
				if (BeforeInsert(my))
				{
					arrayList.Add(my);
					my.Visible = true;
				}
			}
			if (arrayList.Count > 0)
			{
				if (refElement == null)
				{
					refElement = myLastElement;
				}
				if (refElement != null && myChildElements.Contains(refElement))
				{
					if (myOwnerDocument.ContentChangeLog != null)
					{
						myOwnerDocument.ContentChangeLog.Container = this;
						myOwnerDocument.ContentChangeLog.LogInsertRange(myChildElements.IndexOf(refElement), arrayList);
					}
					myChildElements.InsertRange(myChildElements.IndexOf(refElement), arrayList);
				}
				else
				{
					if (myOwnerDocument.ContentChangeLog != null)
					{
						myOwnerDocument.ContentChangeLog.Container = this;
						myOwnerDocument.ContentChangeLog.LogAddRang(arrayList);
					}
					myChildElements.AddRange(arrayList);
				}
				foreach (ZYTextElement item in arrayList)
				{
					item.Parent = this;
					item.OwnerDocument = myOwnerDocument;
					item.RefreshSize();
				}
				OnChildElementsChange();
			}
			return true;
		}

		public virtual bool InsertRangeBefore(List<ZYTextElement> myList, ZYTextElement refElement)
		{
			if (bolChildElementsLocked)
			{
				return false;
			}
			if (myList == null || Locked)
			{
				return false;
			}
			ArrayList arrayList = new ArrayList();
			foreach (ZYTextElement my in myList)
			{
				if (BeforeInsert(my))
				{
					arrayList.Add(my);
					my.Visible = true;
				}
			}
			if (arrayList.Count > 0)
			{
				if (refElement == null)
				{
					refElement = myLastElement;
				}
				if (refElement != null && myChildElements.Contains(refElement))
				{
					if (myOwnerDocument.ContentChangeLog != null)
					{
						myOwnerDocument.ContentChangeLog.Container = this;
						myOwnerDocument.ContentChangeLog.LogInsertRange(myChildElements.IndexOf(refElement), arrayList);
					}
					myChildElements.InsertRange(myChildElements.IndexOf(refElement), arrayList);
				}
				else
				{
					if (myOwnerDocument.ContentChangeLog != null)
					{
						myOwnerDocument.ContentChangeLog.Container = this;
						myOwnerDocument.ContentChangeLog.LogAddRang(arrayList);
					}
					myChildElements.AddRange(arrayList);
				}
				foreach (ZYTextElement item in arrayList)
				{
					item.Parent = this;
					item.OwnerDocument = myOwnerDocument;
					item.RefreshSize();
				}
				OnChildElementsChange();
			}
			return true;
		}

		public void ClearChild()
		{
			myChildElements.Clear();
			AddLastElement();
		}

		public void ClearSaveLog()
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				myChildElement.Visible = true;
				if (myChildElement is ZYTextContainer)
				{
					(myChildElement as ZYTextContainer).ClearSaveLog();
				}
				else
				{
					myChildElement.DeleterIndex = -1;
					myChildElement.CreatorIndex = myOwnerDocument.SaveLogs.CurrentIndex;
				}
			}
		}

		protected virtual void OnChildElementsChange()
		{
			RaiseOnChangeEvent();
		}

		public int IndexOf(ZYTextElement myElement)
		{
			return myChildElements.IndexOf(myElement);
		}

		public bool EnumChildElements(EnumElementHandler vHandler, bool bolPreEnum)
		{
			if (vHandler != null)
			{
				if (bolPreEnum && !vHandler(myParent, this))
				{
					return false;
				}
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					if (myChildElement is ZYTextContainer)
					{
						if (!(myChildElement as ZYTextContainer).EnumChildElements(vHandler, bolPreEnum))
						{
							return false;
						}
					}
					else if (!vHandler(this, myChildElement))
					{
						return false;
					}
				}
				if (!bolPreEnum && !vHandler(myParent, this))
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public virtual void AddElementToListAbs(ArrayList myList)
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				myList.Add(myChildElement);
				if (myChildElement is ZYTextContainer)
				{
					(myChildElement as ZYTextContainer).AddElementToListAbs(myList);
				}
			}
		}

		public virtual void AddElementToList(List<ZYTextElement> myList, bool ResetFlag)
		{
			if (myList != null)
			{
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					if (ResetFlag)
					{
						myChildElement.Visible = false;
						myChildElement.Index = -1;
					}
					if (myOwnerDocument.isVisible(myChildElement))
					{
						if (!(myChildElement is ZYTextContainer))
						{
							myList.Add(myChildElement);
						}
						else
						{
							myChildElement.Visible = true;
							(myChildElement as ZYTextContainer).AddElementToList(myList, ResetFlag);
						}
					}
				}
			}
		}

		public virtual void AddFinalElementToList(List<ZYTextElement> myList)
		{
			if (myList != null)
			{
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					if (!myChildElement.Deleteted)
					{
						if (myChildElement is ZYTextContainer)
						{
							(myChildElement as ZYTextContainer).AddFinalElementToList(myList);
						}
						else
						{
							myList.Add(myChildElement);
						}
					}
				}
			}
		}

		public override bool isTextElement()
		{
			return false;
		}

		public override bool isField()
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement is ZYTextContainer)
				{
					return myChildElement.isField();
				}
				if (myChildElement.isField())
				{
					return true;
				}
			}
			return false;
		}

		public bool HasVisibleElement()
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement.Visible)
				{
					return true;
				}
			}
			return false;
		}

		public bool Contains(ZYTextElement vElement, bool Deep)
		{
			if (vElement == null)
			{
				return false;
			}
			if (myChildElements.Contains(vElement))
			{
				return true;
			}
			if (Deep)
			{
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					if (myChildElement is ZYTextContainer && (myChildElement as ZYTextContainer).Contains(vElement, Deep))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual ZYTextElement GetFirstElement()
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (!(myChildElement is ZYTextContainer))
				{
					return myChildElement;
				}
				ZYTextElement firstElement = (myChildElement as ZYTextContainer).GetFirstElement();
				if (firstElement != null)
				{
					return firstElement;
				}
			}
			return null;
		}

		public virtual ZYTextElement GetLastElement()
		{
			return myLastElement;
		}

		public virtual ArrayList GetVisibleElements()
		{
			ArrayList arrayList = new ArrayList();
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement.Visible)
				{
					arrayList.Add(myChildElement);
				}
			}
			return arrayList;
		}

		public override bool isNewLine()
		{
			return true;
		}

		public int FixForKeyField(ArrayList myElements)
		{
			int num = 0;
			for (int i = 0; i < myElements.Count; i++)
			{
				if (!(myElements[i] is ZYTextBlock))
				{
					continue;
				}
				ZYTextBlock zYTextBlock = (ZYTextBlock)myElements[i];
				if (!zYTextBlock.KeyField || !StringCommon.isBlankString(zYTextBlock.ToEMRString()))
				{
					continue;
				}
				int j;
				for (j = i + 1; j < myElements.Count && myElements[j] is ZYTextChar; j++)
				{
					if (((ZYTextChar)myElements[j]).IsSymbol())
					{
						myElements.RemoveRange(i + 1, j - i);
						num += j - i - 1;
						break;
					}
				}
				j = i - 1;
				while (j >= 0 && myElements[j] is ZYTextChar)
				{
					if (((ZYTextChar)myElements[j]).IsSymbol())
					{
						myElements.RemoveRange(j + 1, i - j - 1);
						num += i - j + 1;
						break;
					}
					j--;
				}
			}
			return num;
		}

		public override string ToEMRString()
		{
			if (myChildElements.Count == 0)
			{
				return null;
			}
			ArrayList visibleElements = GetVisibleElements();
			FixForKeyField(visibleElements);
			StringBuilder stringBuilder = new StringBuilder(myChildElements.Count);
			foreach (ZYTextElement item in visibleElements)
			{
				stringBuilder.Append(item.ToEMRString());
			}
			return stringBuilder.ToString();
		}

		public virtual void GetFinalText(StringBuilder myStr)
		{
			ArrayList arrayList = new ArrayList();
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (!myChildElement.Deleteted)
				{
					arrayList.Add(myChildElement);
				}
			}
			FixForKeyField(arrayList);
			foreach (ZYTextElement item in arrayList)
			{
				if (item.isTextElement())
				{
					myStr.Append(item.ToEMRString());
				}
				else if (item is ZYTextContainer)
				{
					(item as ZYTextContainer).GetFinalText(myStr);
				}
			}
		}

		protected virtual void AddLastElement()
		{
			if (myChildElements.Count > 0)
			{
				myLastElement = (myChildElements[myChildElements.Count - 1] as ZYTextParagraph);
				if (myLastElement == null)
				{
					myLastElement = new ZYTextParagraph();
					myChildElements.Add(myLastElement);
				}
			}
			else
			{
				myChildElements.Add(myLastElement);
			}
			if (myLastElement != null && myOwnerDocument != null)
			{
				myLastElement.CreatorIndex = -1;
				myLastElement.DeleterIndex = -1;
			}
		}

		protected virtual bool IsLastElement(ZYTextElement vElement)
		{
			return vElement == myChildElements[myChildElements.Count - 1];
		}

		public virtual void ResetViewState()
		{
		}

		public virtual void DrawBackGround(ZYTextElement myElement)
		{
		}

		public virtual Rectangle GetContentBounds()
		{
			return new Rectangle(RealLeft, RealTop, intClientWidth, Height);
		}

		public override bool RefreshView()
		{
			Rectangle contentBounds = GetContentBounds();
			if (myOwnerDocument.isNeedDraw(contentBounds) && HasVisibleElement())
			{
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					if (myChildElement is ZYTextContainer)
					{
						((ZYTextContainer)myChildElement).ResetViewState();
					}
				}
				ArrayList arrayList = new ArrayList();
				RefreshClientWidth();
				int realTop = RealTop;
				int realLeft = RealLeft;
				foreach (ZYTextLine myLine in myLines)
				{
					int num = realTop + myLine.Top;
					int height = myLine.Height;
					int realLeft2 = myLine.RealLeft;
					Rectangle rect = new Rectangle(0, num, 0, height);
					if (myOwnerDocument.View.isNeedDrawY(num, height))
					{
						bool flag = false;
						foreach (ZYTextElement element in myLine.Elements)
						{
							int num2 = realLeft2 + element.Left;
							int num3 = num + element.Top;
							int num4 = element.Width + element.WidthFix;
							int height2 = element.Height;
							if (myOwnerDocument.View.isNeedDrawX(num2, num4))
							{
								flag = true;
							}
							else if (element is ZYTextContainer)
							{
								Rectangle contentBounds2 = (element as ZYTextContainer).GetContentBounds();
								if (!contentBounds2.IsEmpty && myOwnerDocument.View.isNeedDrawX(contentBounds2.Left, contentBounds2.Width))
								{
									flag = true;
								}
							}
							if (flag)
							{
								if (myOwnerDocument.isSelected(element))
								{
									if (rect.Width == 0)
									{
										rect.X = num2;
										rect.Width = element.Width + element.WidthFix;
									}
									else
									{
										if (rect.Left > num2)
										{
											rect.X = num2;
										}
										if (rect.Right < num2 + element.Width + element.WidthFix)
										{
											rect.Width = num2 + element.Width + element.WidthFix - rect.Left;
										}
									}
								}
								else if (bolDrawBackGround && myOwnerDocument.Info.ShowMark)
								{
									int markLevel = myOwnerDocument.GetMarkLevel(element.CreatorIndex);
									if (markLevel > 0)
									{
										myOwnerDocument.DrawNewBackGround(markLevel, num2, num3, num4, height2);
									}
									else if (element.isField() && element is ZYTextChar)
									{
										myOwnerDocument.View.DrawFieldBackGround(num2, num3, num4, height2);
									}
								}
								element.Parent.DrawBackGround(element);
								element.RefreshView();
								if (element.Deleteted)
								{
									myOwnerDocument.DrawDeleteLine(myOwnerDocument.GetMarkLevel(element.DeleterIndex), element.RealLeft, element.RealTop, element.Width, element.Height);
								}
							}
						}
						if (rect.Width > 0 && myOwnerDocument.OwnerControl != null)
						{
							myOwnerDocument.OwnerControl.ReversibleViewFillRect(rect, myOwnerDocument.View.Graph);
						}
					}
				}
				myBorder.Draw(myOwnerDocument.View, contentBounds);
				return true;
			}
			return false;
		}

		public override bool ToXML(XmlElement myElement)
		{
			XmlElement xmlElement = null;
			if (StringCommon.isBlankString(myAttributes.GetString("id")))
			{
				myAttributes.SetValue("id", StringCommon.AllocObjectName());
			}
			switch (myOwnerDocument.Info.SaveMode)
			{
			case 0:
			{
				ZYTextElement zYTextElement2 = null;
				ZYTextChar zYTextChar = null;
				ZYTextChar zYTextChar2 = null;
				myAttributes.ToXML(myElement);
				if (myOwnerDocument.Info.SavePreViewText)
				{
					List<ZYTextElement> myList2 = new List<ZYTextElement>();
					AddFinalElementToList(myList2);
					string elementsText2 = ZYTextElement.GetElementsText(myList2);
					xmlElement = myElement.OwnerDocument.CreateElement("text");
					myElement.AppendChild(xmlElement);
					xmlElement.InnerText = elementsText2;
				}
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					bool flag = false;
					zYTextChar2 = (myChildElement as ZYTextChar);
					if (zYTextChar2 == null)
					{
						zYTextChar = null;
					}
					else
					{
						if (zYTextChar != null && zYTextChar.Attributes.EqualsValue(zYTextChar2.Attributes))
						{
							zYTextChar2.AppendToXML(xmlElement);
							flag = true;
						}
						zYTextChar = zYTextChar2;
					}
					if (!flag)
					{
						string xMLName = myChildElement.GetXMLName();
						if (xMLName != null)
						{
							xmlElement = myElement.OwnerDocument.CreateElement(myChildElement.GetXMLName());
							myElement.AppendChild(xmlElement);
							myChildElement.ToXML(xmlElement);
							zYTextElement2 = myChildElement;
						}
					}
				}
				break;
			}
			case 1:
				myElement.SetAttribute("name", myAttributes.GetString("name"));
				foreach (ZYTextElement myChildElement2 in myChildElements)
				{
					if (myChildElement2.DeleterIndex < 0)
					{
						if (myChildElement2 is ZYTextChar || myChildElement2 is ZYTextParagraph || myChildElement2 is ZYTextLineEnd)
						{
							myElement.AppendChild(myElement.OwnerDocument.CreateTextNode(myChildElement2.ToEMRString()));
						}
						else if (myChildElement2.isField() && myChildElement2.GetXMLName() != null)
						{
							xmlElement = myElement.OwnerDocument.CreateElement(myChildElement2.GetXMLName());
							myElement.AppendChild(xmlElement);
							myChildElement2.ToXML(xmlElement);
						}
					}
				}
				break;
			case 2:
				myElement.SetAttribute("name", myAttributes.GetString("name"));
				foreach (ZYTextElement myChildElement3 in myChildElements)
				{
					if (myChildElement3.DeleterIndex < 0 && myChildElement3.isField() && myChildElement3.GetXMLName() != null)
					{
						xmlElement = myElement.OwnerDocument.CreateElement(myChildElement3.GetXMLName());
						myElement.AppendChild(xmlElement);
						myChildElement3.ToXML(xmlElement);
					}
				}
				break;
			case 3:
			{
				List<ZYTextElement> myList = new List<ZYTextElement>();
				AddFinalElementToList(myList);
				string elementsText = ZYTextElement.GetElementsText(myList);
				xmlElement = myElement.OwnerDocument.CreateElement("text");
				myElement.AppendChild(xmlElement);
				xmlElement.InnerText = elementsText;
				foreach (ZYTextElement myChildElement4 in myChildElements)
				{
					if (myChildElement4.DeleterIndex < 0 && myChildElement4.isField())
					{
						if (StringCommon.isBlankString(myChildElement4.Attributes.GetString("id")))
						{
							myChildElement4.Attributes.SetValue("id", StringCommon.AllocObjectName());
						}
						xmlElement = myElement.OwnerDocument.CreateElement(myChildElement4.Attributes.GetString("id"));
						myElement.AppendChild(xmlElement);
						myChildElement4.ToXML(xmlElement);
					}
				}
				break;
			}
			default:
				return false;
			}
			return true;
		}

		public override bool FromXML(XmlElement myElement)
		{
			if (base.FromXML(myElement))
			{
				myChildElements.Clear();
				List<ZYTextElement> myList = new List<ZYTextElement>();
				myOwnerDocument.LoadElementsToList(myElement, myList);
				InsertRangeBefore(myList, null);
				AddLastElement();
				foreach (ZYTextElement myChildElement in myChildElements)
				{
					myChildElement.Parent = this;
				}
				strID = myAttributes.GetString("id");
				strName = myAttributes.GetString("name");
				return true;
			}
			return false;
		}

		public override void UpdateAttrubute()
		{
			strID = myAttributes.GetString("id");
			strName = myAttributes.GetString("name");
		}

		public override bool HandleClick(int x, int y, MouseButtons Button)
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement.Visible && !myChildElement.Deleteted && myChildElement.HandleClick(x, y, Button))
				{
					return true;
				}
			}
			return false;
		}

		public override bool HandleDblClick(int x, int y, MouseButtons Button)
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement.Visible && !myChildElement.Deleteted && myChildElement.HandleDblClick(x, y, Button))
				{
					return true;
				}
			}
			return false;
		}

		public override bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement.Visible && !myChildElement.Deleteted && myChildElement.HandleMouseDown(x, y, Button))
				{
					return true;
				}
			}
			return false;
		}

		public override bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement.Visible && !myChildElement.Deleteted && myChildElement.HandleMouseMove(x, y, Button))
				{
					return true;
				}
			}
			return false;
		}

		public override bool HandleMouseUp(int x, int y, MouseButtons Button)
		{
			foreach (ZYTextElement myChildElement in myChildElements)
			{
				if (myChildElement.Visible && !myChildElement.Deleteted && myChildElement.HandleMouseUp(x, y, Button))
				{
					return true;
				}
			}
			return false;
		}

		public ZYTextContainer()
		{
			myBorder = new ZYTextBorder();
			myLastElement = new ZYTextParagraph();
			myLastElement.Parent = this;
			AddLastElement();
			base.Visible = true;
			Index = 0;
		}

		public object Clone()
		{
			ZYTextContainer zYTextContainer = new ZYTextContainer();
			zYTextContainer.bolAbsolutePos = bolAbsolutePos;
			zYTextContainer.bolChildElementsLocked = bolChildElementsLocked;
			zYTextContainer.bolContainTextOnly = bolContainTextOnly;
			zYTextContainer.bolDrawBackGround = bolDrawBackGround;
			zYTextContainer.bolEnableForeColor = bolEnableForeColor;
			zYTextContainer.bolLocked = bolLocked;
			zYTextContainer.Index = Index;
			zYTextContainer.intBottomMargin = intBottomMargin;
			zYTextContainer.intClientWidth = intClientWidth;
			zYTextContainer.intForeColor = intForeColor;
			zYTextContainer.intHeight = intHeight;
			zYTextContainer.intLeft = intLeft;
			zYTextContainer.intLeftMargin = intLeftMargin;
			zYTextContainer.intLineSpan = intLineSpan;
			zYTextContainer.intMaxWidth = intMaxWidth;
			zYTextContainer.intRightMargin = intRightMargin;
			zYTextContainer.intTop = intTop;
			zYTextContainer.intTopMargin = intTopMargin;
			zYTextContainer.intWidth = intWidth;
			zYTextContainer.myAttributes = myAttributes;
			zYTextContainer.myBorder = myBorder;
			zYTextContainer.myBounds = myBounds;
			zYTextContainer.myChildElements = myChildElements;
			zYTextContainer.myContentList = myContentList;
			zYTextContainer.myLastElement = myLastElement;
			zYTextContainer.myLines.Clear();
			zYTextContainer.myLines.AddRange(myLines);
			zYTextContainer.myOwnerLine = myOwnerLine;
			zYTextContainer.myParent = myParent;
			zYTextContainer.strID = strID;
			zYTextContainer.strName = strName;
			zYTextContainer.titleSize = titleSize;
			zYTextContainer.WidthFix = WidthFix;
			return zYTextContainer;
		}
	}
}
