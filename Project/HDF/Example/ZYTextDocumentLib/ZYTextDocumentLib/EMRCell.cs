using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class EMRCell : ZYTextContainer
	{
		public bool selected = false;

		protected int intColSpan = 1;

		protected int intRowSpan = 1;

		internal EMRCell myOverrideCell = null;

		protected EMRCol myOwnerColumn = null;

		protected EMRRow myOwnerRow = null;

		protected EMRTable myOwnerTable = null;

		public string text = "";

		public bool Visable = true;

		public int Bottom => Top + intHeight;

		public int leftborder
		{
			get
			{
				return myAttributes.GetInt32("leftborder");
			}
			set
			{
				myAttributes.SetValue("leftborder", value);
			}
		}

		public int bottomborder
		{
			get
			{
				return myAttributes.GetInt32("bottomborder");
			}
			set
			{
				myAttributes.SetValue("bottomborder", value);
			}
		}

		public int rightborder
		{
			get
			{
				return myAttributes.GetInt32("rightborder");
			}
			set
			{
				myAttributes.SetValue("rightborder", value);
			}
		}

		public int topborder
		{
			get
			{
				return myAttributes.GetInt32("topborder");
			}
			set
			{
				myAttributes.SetValue("topborder", value);
			}
		}

		public int minHeight
		{
			get
			{
				int num = 0;
				foreach (ZYTextLine line in base.Lines)
				{
					num += line.Height;
				}
				if (num > 0)
				{
					return num;
				}
				return OwnerDocument.DefaultRowHeight;
			}
		}

		public int CellHeight
		{
			get
			{
				if (intRowSpan == 1)
				{
					return OwnerRow.Height;
				}
				int num = 0;
				int num2 = RowIndex + intRowSpan;
				for (int i = RowIndex; i < OwnerTable.Rows.Count && i < num2; i++)
				{
					num += ((EMRRow)OwnerTable.Rows[i]).Height;
				}
				return num;
			}
			set
			{
				int cellHeight = CellHeight;
				if (cellHeight != value)
				{
					int num = LastOwnerRow.Height - cellHeight + value;
					if (num > 0)
					{
						LastOwnerRow.Height = num;
						myOwnerTable.UpdateLayout();
					}
				}
			}
		}

		public int CellWidth
		{
			get
			{
				if (intColSpan == 1)
				{
					return OwnerColumn.Width;
				}
				int num = 0;
				int num2 = ColIndex + intColSpan;
				for (int i = ColIndex; i < OwnerTable.Cols.Count && i < num2; i++)
				{
					num += ((EMRCol)OwnerTable.Cols[i]).Width;
				}
				return num;
			}
			set
			{
				int cellWidth = CellWidth;
				if (cellWidth != value)
				{
					int num = LastOwnerColumn.Width - cellWidth + value;
					if (num > 0)
					{
						LastOwnerColumn.Width = num;
						myOwnerTable.UpdateLayout();
					}
				}
			}
		}

		public int ColIndex => myOwnerTable.Cols.IndexOf(myOwnerColumn);

		public int ColSpan
		{
			get
			{
				return intColSpan;
			}
			set
			{
				int num = value;
				if (ColIndex + num - 1 >= OwnerTable.Cols.Count)
				{
					num = OwnerTable.Cols.Count - ColIndex;
				}
				if (num < 1)
				{
					num = 1;
				}
				if (intColSpan != num)
				{
					intColSpan = num;
					OwnerTable.UpdateLayout();
				}
			}
		}

		public override int Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				intHeight = value;
			}
		}

		public EMRCol LastOwnerColumn => (EMRCol)myOwnerTable.Cols[myOwnerColumn.Index + intColSpan - 1];

		public EMRRow LastOwnerRow => (EMRRow)myOwnerTable.Rows[myOwnerRow.Index + intRowSpan - 1];

		public override int Left
		{
			get
			{
				return OwnerColumn.Left;
			}
			set
			{
				intLeft = value;
			}
		}

		public EMRCell OverrideCell => myOverrideCell;

		public EMRCol OwnerColumn
		{
			get
			{
				return myOwnerColumn;
			}
			set
			{
				myOwnerColumn = value;
			}
		}

		public EMRRow OwnerRow
		{
			get
			{
				return myOwnerRow;
			}
			set
			{
				myOwnerRow = value;
			}
		}

		public EMRTable OwnerTable
		{
			get
			{
				return myOwnerTable;
			}
			set
			{
				myOwnerTable = value;
			}
		}

		public int Right => intLeft + intWidth;

		public int RowIndex => myOwnerTable.Rows.IndexOf(myOwnerRow);

		public int RowSpan
		{
			get
			{
				return intRowSpan;
			}
			set
			{
				int num = value;
				if (RowIndex + num - 1 >= OwnerTable.Rows.Count)
				{
					num = OwnerTable.Rows.Count - RowIndex;
				}
				if (num < 1)
				{
					num = 1;
				}
				if (intRowSpan != num)
				{
					intRowSpan = num;
					OwnerTable.UpdateLayout();
				}
			}
		}

		public override int Top
		{
			get
			{
				return OwnerRow.Top;
			}
			set
			{
				intTop = value;
			}
		}

		public override int Width
		{
			get
			{
				return intWidth;
			}
			set
			{
				intWidth = value;
			}
		}

		public string ContentMark
		{
			get
			{
				return myAttributes.GetString(ZYTextConst.c_ContentMark);
			}
			set
			{
				myAttributes.SetValue(ZYTextConst.c_ContentMark, value);
			}
		}

		public override string GetXMLName()
		{
			return "cell";
		}

		public override bool Contains(int x, int y)
		{
			return x >= intLeft && x <= intLeft + intWidth && y >= intTop && y <= intTop + intHeight;
		}

		public override Rectangle GetContentBounds()
		{
			return new Rectangle(RealLeft + 6, RealTop + 6, CellWidth - 4, CellHeight - 4);
		}

		public override bool ToXML(XmlElement myElement)
		{
			XmlElement xmlElement = null;
			if (ColSpan > 1)
			{
				myAttributes.SetValue("colspan", intColSpan);
			}
			if (RowSpan > 1)
			{
				myAttributes.SetValue("rowspan", intRowSpan);
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
			myChildElements.Clear();
			ArrayList myList = new ArrayList();
			myOwnerDocument.LoadElementsToList(myElement, myList);
			InsertRangeBefore(myList, null);
			AddLastElement();
			intColSpan = ((myElement.GetAttribute("colspan") == "") ? 1 : int.Parse(myElement.GetAttribute("colspan")));
			intRowSpan = ((myElement.GetAttribute("rowspan") == "") ? 1 : int.Parse(myElement.GetAttribute("rowspan")));
			leftborder = ((!(myElement.GetAttribute("leftborder") == "0")) ? 1 : 0);
			topborder = ((!(myElement.GetAttribute("topborder") == "0")) ? 1 : 0);
			rightborder = ((!(myElement.GetAttribute("rightborder") == "0")) ? 1 : 0);
			bottomborder = ((!(myElement.GetAttribute("bottomborder") == "0")) ? 1 : 0);
			if (myElement.HasAttribute(ZYTextConst.c_ContentMark))
			{
				ContentMark = myElement.GetAttribute(ZYTextConst.c_ContentMark);
			}
			return true;
		}

		protected override void RefreshClientWidth()
		{
			intClientWidth = Width - 20;
		}

		public override void RefreshLine()
		{
			RefreshLineFast(0);
		}

		public override void UpdateBounds()
		{
			int num = 5;
			Rectangle empty = Rectangle.Empty;
			foreach (ZYTextLine myLine in myLines)
			{
				myLine.Top = num;
				myLine.RealTop = RealTop + num;
				myLine.RealLeft = RealLeft + 10;
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

		public ZYTextElement GetElementAt(int x, int y)
		{
			if (OwnerDocument != null && base.Lines != null && base.Lines.Count > 0)
			{
				int num = -1;
				foreach (ZYTextLine line in base.Lines)
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
								return element;
							}
						}
						return base.LastElement;
					}
					num = line.RealTop + line.Height;
				}
			}
			return base.LastElement;
		}

		public override void RefreshLineFast(int StartIndex)
		{
			List<ZYTextElement> list = new List<ZYTextElement>();
			int height = Height;
			RefreshClientWidth();
			int num = 0;
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
			if (zYTextLine.Height < myOwnerDocument.DefaultRowHeight)
			{
				zYTextLine.Height = myOwnerDocument.DefaultRowHeight;
			}
			myLines.Add(zYTextLine);
			myOwnerDocument.AddLine(zYTextLine);
			int intClientWidth = base.intClientWidth;
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
			int num = 0;
			switch (paragraphAlignConst)
			{
			case ParagraphAlignConst.Left:
				num = intLeftMargin;
				break;
			case ParagraphAlignConst.Center:
				num = intLeftMargin + (intClientWidth - zYTextLine.ContentWidth) / 2;
				break;
			case ParagraphAlignConst.Right:
				num = intLeftMargin + intClientWidth - zYTextLine.ContentWidth;
				break;
			case ParagraphAlignConst.Justify:
				num = intLeftMargin;
				break;
			default:
				num = intLeftMargin;
				break;
			}
			int num2 = 0;
			int num3 = 0;
			if (LineElements.Count > 0 && (!zYTextLine.HasLineEnd || paragraphAlignConst == ParagraphAlignConst.Justify))
			{
				num3 = intClientWidth - zYTextLine.ContentWidth;
				num2 = (int)Math.Ceiling((double)num3 / (double)(LineElements.Count - 1));
				if (num3 > 0 && num2 < 1)
				{
					num2 = 1;
				}
			}
			foreach (ZYTextElement LineElement2 in LineElements)
			{
				LineElement2.OwnerLine = zYTextLine;
				LineElement2.Left = num;
				LineElement2.Top = zYTextLine.Height - LineElement2.Height;
				LineElement2.WidthFix = 0;
				num += LineElement2.Width;
				if (num2 > 0 && LineElement2 is ZYTextChar)
				{
					num += num2;
					LineElement2.WidthFix = num2;
					num3 -= num2;
					if (num3 <= 0)
					{
						num2 = 0;
					}
				}
			}
			if (myParent == null && !myOwnerDocument.Info.WordWrap && intWidth < num)
			{
				intWidth = num;
			}
			zYTextLine.RealIndex = zYTextLine.CalcuteRealIndex();
			return zYTextLine.Height;
		}

		public override bool RefreshView()
		{
			if (OverrideCell != null)
			{
				return true;
			}
			if (bottomborder == 1 && topborder == 1 && leftborder == 1 && rightborder == 1)
			{
				Rectangle vRect = new Rectangle(Left, Top, CellWidth, CellHeight);
				OwnerDocument.View.DrawRectangle(Color.Black, vRect);
			}
			else
			{
				Pen pen = new Pen(Color.Black);
				if (bottomborder == 1)
				{
					pen.Color = Color.Black;
					pen.DashStyle = DashStyle.Solid;
					OwnerDocument.View.DrawLine(pen, Left, Top + CellHeight, Left + CellWidth, Top + CellHeight);
				}
				else if (!OwnerDocument.Info.Printing)
				{
					pen.DashStyle = DashStyle.Dot;
					pen.Color = SystemColors.ControlDark;
					OwnerDocument.View.DrawLine(pen, Left, Top + CellHeight, Left + CellWidth, Top + CellHeight);
				}
				if (leftborder == 1)
				{
					pen.Color = Color.Black;
					pen.DashStyle = DashStyle.Solid;
					OwnerDocument.View.DrawLine(pen, Left, Top, Left, Top + CellHeight);
				}
				else if (!OwnerDocument.Info.Printing)
				{
					pen.DashStyle = DashStyle.Dot;
					pen.Color = SystemColors.ControlDark;
					OwnerDocument.View.DrawLine(pen, Left, Top, Left, Top + CellHeight);
				}
				if (rightborder == 1)
				{
					pen.Color = Color.Black;
					pen.DashStyle = DashStyle.Solid;
					OwnerDocument.View.DrawLine(pen, Left + CellWidth, Top, Left + CellWidth, Top + CellHeight);
				}
				else if (!OwnerDocument.Info.Printing)
				{
					pen.DashStyle = DashStyle.Dot;
					pen.Color = SystemColors.ControlDark;
					OwnerDocument.View.DrawLine(pen, Left + CellWidth, Top, Left + CellWidth, Top + CellHeight);
				}
				if (topborder == 1)
				{
					pen.Color = Color.Black;
					pen.DashStyle = DashStyle.Solid;
					OwnerDocument.View.DrawLine(pen, Left, Top, Left + CellWidth, Top);
				}
				else if (!OwnerDocument.Info.Printing)
				{
					pen.DashStyle = DashStyle.Dot;
					pen.Color = SystemColors.ControlDark;
					OwnerDocument.View.DrawLine(pen, Left, Top, Left + CellWidth, Top);
				}
			}
			Rectangle contentBounds = GetContentBounds();
			RefreshLine();
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

		protected override void OnChildElementsChange()
		{
			if (OwnerTable != null)
			{
				RefreshLine();
				OwnerDocument.RefreshElement(OwnerTable);
			}
		}

		public Rectangle GetVBorder()
		{
			if (OverrideCell != null)
			{
				return Rectangle.Empty;
			}
			return new Rectangle(RealLeft - 4 + CellWidth, RealTop - 2, 8, CellHeight - 2);
		}

		public Rectangle GetHBorder()
		{
			if (OverrideCell != null)
			{
				return Rectangle.Empty;
			}
			return new Rectangle(RealLeft, RealTop + CellHeight - 5, CellWidth - 2, 10);
		}

		public override bool InsertRangeBefore(ArrayList myList, ZYTextElement refElement)
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

		public override bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			base.HandleMouseDown(x, y, Button);
			if (GetVBorder().Contains(x, y) && myOwnerDocument.OwnerControl != null)
			{
				Rectangle sourceRect = new Rectangle(Left, OwnerTable.RealTop, CellWidth, OwnerTable.Height);
				Rectangle rectangle = myOwnerDocument.OwnerControl.CaptureDragRect(sourceRect, 3, DrawFocusRect: false, 0.0, ShowSizeInfo: false, null);
				if (rectangle.Width > 10 && rectangle.Height > 10)
				{
					int num = rectangle.Width - OwnerColumn.Width;
					int width = OwnerTable.Parent.Width;
					if (OwnerTable.Width + num > width)
					{
						OwnerColumn.Width += width - OwnerTable.Width;
					}
					else
					{
						OwnerColumn.Width = rectangle.Width;
					}
					OwnerDocument.ContentChanged();
					OwnerDocument.Refresh();
					return true;
				}
			}
			if (GetHBorder().Contains(x, y) && myOwnerDocument.OwnerControl != null)
			{
				Rectangle sourceRect = new Rectangle(OwnerTable.Left, RealTop, OwnerTable.Width, CellHeight);
				Rectangle rectangle = myOwnerDocument.OwnerControl.CaptureDragRect(sourceRect, 5, DrawFocusRect: false, 0.0, ShowSizeInfo: false, null);
				if (rectangle.Width > 10 && rectangle.Height > minHeight)
				{
					OwnerRow.Height = rectangle.Height;
					OwnerDocument.ContentChanged();
					OwnerDocument.RefreshLine();
					OwnerDocument.Refresh();
					return true;
				}
			}
			return false;
		}
	}
}
