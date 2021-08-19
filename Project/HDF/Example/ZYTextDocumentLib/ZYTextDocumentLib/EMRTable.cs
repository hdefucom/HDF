using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace ZYTextDocumentLib
{
	public class EMRTable : ZYTextContainer
	{
		public ArrayList Cols = new ArrayList();

		public ArrayList Vborder = new ArrayList();

		public ArrayList Hborder = new ArrayList();

		public ArrayList Rows => base.ChildElements;

		public override int Height
		{
			get
			{
				int num = 0;
				foreach (EMRRow row in Rows)
				{
					num += row.Height;
				}
				return num;
			}
		}

		public override int Width
		{
			get
			{
				int num = 0;
				foreach (EMRCol col in Cols)
				{
					num += col.Width;
				}
				return num;
			}
		}

		public ArrayList Cells
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				foreach (EMRRow row in Rows)
				{
					arrayList.AddRange(row.Cells);
				}
				return arrayList;
			}
		}

		public override bool isNewLine()
		{
			return false;
		}

		public override bool CanBeLineEnd()
		{
			return false;
		}

		public override string GetXMLName()
		{
			return "table";
		}

		public override bool RefreshSize()
		{
			int num = 0;
			foreach (EMRRow row in Rows)
			{
				num += row.Height;
			}
			Height = num;
			num = 0;
			foreach (EMRCol col in Cols)
			{
				num += col.Width;
			}
			Width = num;
			return true;
		}

		public override void RefreshLine()
		{
			foreach (EMRRow row in Rows)
			{
				row.RefreshLine();
			}
		}

		public override bool RefreshView()
		{
			FixCells();
			UpdateLayout();
			SetCellSize();
			foreach (EMRCell cell in Cells)
			{
				cell.OwnerDocument = OwnerDocument;
				cell.RefreshView();
			}
			return true;
		}

		public override bool FromXML(XmlElement myElement)
		{
			XmlNodeList elementsByTagName = myElement.GetElementsByTagName("col");
			foreach (XmlElement item in elementsByTagName)
			{
				EMRCol eMRCol = new EMRCol();
				eMRCol.Width = ((item.GetAttribute("width") == "") ? 100 : int.Parse(item.GetAttribute("width")));
				eMRCol.OwnerTable = this;
				Cols.Add(eMRCol);
			}
			myChildElements.Clear();
			ArrayList myList = new ArrayList();
			myOwnerDocument.LoadElementsToList(myElement, myList);
			InsertRangeBefore(myList, null);
			FixCells();
			SetCellSize();
			UpdateLayout();
			return true;
		}

		public override bool ToXML(XmlElement myElement)
		{
			for (int i = 0; i < Cols.Count; i++)
			{
				XmlElement xmlElement = myElement.OwnerDocument.CreateElement("col");
				xmlElement.SetAttribute("width", (Cols[i] as EMRCol).Width.ToString());
				myElement.AppendChild(xmlElement);
			}
			for (int i = 0; i < Rows.Count; i++)
			{
				XmlElement xmlElement = myElement.OwnerDocument.CreateElement("row");
				xmlElement.SetAttribute("height", (Rows[i] as EMRRow).Height.ToString());
				foreach (EMRCell cell in (Rows[i] as EMRRow).Cells)
				{
					XmlElement xmlElement2 = myElement.OwnerDocument.CreateElement("cell");
					cell.ToXML(xmlElement2);
					xmlElement.AppendChild(xmlElement2);
				}
				myElement.AppendChild(xmlElement);
			}
			return true;
		}

		protected virtual EMRCell NewCell()
		{
			return new EMRCell();
		}

		protected virtual EMRCol NewColumn()
		{
			return new EMRCol();
		}

		protected virtual EMRRow NewRow()
		{
			return new EMRRow();
		}

		protected void FixCells()
		{
			foreach (EMRRow childElement in base.ChildElements)
			{
				if (childElement.Cells.Count > Cols.Count)
				{
					for (int i = Cols.Count; i < childElement.Cells.Count; i++)
					{
						EMRCol eMRCol = NewColumn();
						eMRCol.Width = ((EMRCol)childElement.Cells[i]).Width;
						eMRCol.OwnerTable = this;
						Cols.Add(eMRCol);
					}
				}
			}
			foreach (EMRRow childElement2 in base.ChildElements)
			{
				if (childElement2.Cells.Count != Cols.Count)
				{
					childElement2.Cells.Clear();
					if (childElement2.Cells.Count < Cols.Count)
					{
						for (int j = childElement2.Cells.Count; j < Cols.Count; j++)
						{
							EMRCell eMRCell = NewCell();
							childElement2.Cells.Add(eMRCell);
							eMRCell.OwnerTable = this;
							eMRCell.OwnerRow = childElement2;
							eMRCell.OwnerColumn = (EMRCol)Cols[j];
						}
					}
				}
			}
			Hborder.Clear();
			Vborder.Clear();
			foreach (EMRCell cell in Cells)
			{
				cell.OwnerRow = (EMRRow)cell.Parent;
				cell.OwnerTable = this;
				cell.OwnerColumn = (EMRCol)Cols[cell.Parent.ChildElements.IndexOf(cell)];
				if (cell.GetHBorder() != Rectangle.Empty)
				{
					Hborder.Add(cell.GetHBorder());
				}
				if (cell.GetVBorder() != Rectangle.Empty)
				{
					Vborder.Add(cell.GetVBorder());
				}
			}
		}

		private void SetCellSize()
		{
			ArrayList cells = Cells;
			foreach (EMRCell item in cells)
			{
				item.myOverrideCell = null;
			}
			foreach (EMRCell item2 in cells)
			{
				if (item2.myOverrideCell == null)
				{
					if (item2.RowSpan > 1 && item2.RowIndex + item2.RowSpan > Rows.Count)
					{
						item2.RowSpan = Rows.Count - item2.RowIndex;
					}
					if (item2.ColSpan > 1 && item2.ColIndex + item2.ColSpan > Cols.Count)
					{
						item2.ColSpan = Cols.Count - item2.ColIndex;
					}
					if (item2.RowSpan > 1 || item2.ColSpan > 1)
					{
						foreach (EMRCell item3 in GetRange(item2.RowIndex, item2.ColIndex, item2.RowSpan, item2.ColSpan))
						{
							item3.myOverrideCell = item2;
						}
						item2.myOverrideCell = null;
					}
					int num = 0;
					if (item2.ColSpan == 1)
					{
						num = ((EMRCol)Cols[item2.ColIndex]).Width;
					}
					else
					{
						for (int i = 0; i < item2.ColSpan; i++)
						{
							num += ((EMRCol)Cols[item2.ColIndex + i]).Width;
						}
					}
					int num2 = 0;
					if (item2.RowSpan == 1)
					{
						num2 = item2.OwnerRow.Height;
					}
					else
					{
						for (int j = 0; j < item2.RowSpan; j++)
						{
							num2 += ((EMRRow)Rows[item2.RowIndex + j]).Height;
						}
					}
					item2.Width = num;
					item2.Height = num2;
					item2.Left = ((EMRCol)Cols[item2.ColIndex]).Left;
					item2.Top = item2.OwnerRow.Top;
				}
			}
		}

		protected ArrayList GetRange(int RowIndex, int ColIndex, int RowSpan, int ColSpan)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < RowSpan; i++)
			{
				EMRRow eMRRow = (EMRRow)Rows[RowIndex + i];
				for (int j = 0; j < ColSpan; j++)
				{
					if (ColIndex + j >= 0 && ColIndex + j < eMRRow.Cells.Count)
					{
						arrayList.Add(eMRRow.Cells[ColIndex + j]);
					}
				}
			}
			return arrayList;
		}

		public int GetRowTop(EMRRow vRow)
		{
			int num = 0;
			foreach (EMRRow row in Rows)
			{
				if (row == vRow)
				{
					break;
				}
				num += row.Height;
			}
			return num;
		}

		public int GetColLeft(EMRCol vCol)
		{
			int num = 0;
			foreach (EMRCol col in Cols)
			{
				if (col == vCol)
				{
					break;
				}
				num += col.Width;
			}
			return num;
		}

		public virtual void UpdateLayout()
		{
			if (Rows.Count != 0 && Cols.Count != 0)
			{
				FixCells();
				SetCellSize();
				int num = 0;
				int num2 = 0;
				foreach (EMRCol col in Cols)
				{
					col.Left = num2 + RealLeft;
					num2 += col.Width;
				}
				intWidth = num2;
				foreach (EMRRow row in Rows)
				{
					row.Top = num + RealTop;
					num += row.Height;
				}
				intHeight = num;
				SetCellSize();
				intWidth = Width;
				intHeight = Height;
			}
		}

		protected override void AddLastElement()
		{
		}

		public ZYTextElement GetElementAt(int x, int y)
		{
			if (Bounds.Contains(x, y))
			{
				foreach (EMRCell cell in Cells)
				{
					if (cell.Contains(x, y))
					{
						return cell.GetElementAt(x, y);
					}
				}
			}
			return null;
		}

		public override bool HandleClick(int x, int y, MouseButtons Button)
		{
			if (Bounds.Contains(x, y))
			{
				foreach (EMRCell cell in Cells)
				{
					if (cell.Contains(x, y))
					{
						cell.HandleClick(x, y, Button);
						return true;
					}
				}
			}
			return false;
		}

		public void InsertCol()
		{
			EMRCol eMRCol = new EMRCol();
			eMRCol.OwnerTable = this;
			if (Width + eMRCol.Width <= OwnerDocument.Pages.StandardWidth)
			{
				Cols.Add(eMRCol);
				for (int i = 0; i < Rows.Count; i++)
				{
					EMRCell newElement = new EMRCell();
					(Rows[i] as EMRRow).InsertBefore(newElement, null);
				}
				FixCells();
				SetCellSize();
				UpdateLayout();
				OwnerDocument.ContentChanged();
				OwnerDocument.Refresh();
			}
		}

		public void InsertRow()
		{
			EMRRow eMRRow = new EMRRow();
			eMRRow.OwnerTable = this;
			eMRRow.OwnerDocument = OwnerDocument;
			for (int i = 0; i < Cols.Count; i++)
			{
				EMRCell newElement = new EMRCell();
				eMRRow.InsertBefore(newElement, null);
			}
			InsertBefore(eMRRow, null);
			FixCells();
			SetCellSize();
			UpdateLayout();
			OwnerDocument.ContentChanged();
			OwnerDocument.UpdateView();
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
				foreach (EMRRow item in arrayList)
				{
					item.Parent = this;
					item.OwnerDocument = myOwnerDocument;
					item.OwnerTable = this;
					item.RefreshSize();
				}
				OnChildElementsChange();
			}
			return true;
		}

		public override bool HandleMouseMove(int x, int y, MouseButtons Button)
		{
			foreach (Rectangle item in Vborder)
			{
				if (item.Contains(x, y))
				{
					myOwnerDocument.SetCursor(Cursors.SizeWE);
					return true;
				}
			}
			foreach (Rectangle item2 in Hborder)
			{
				if (item2.Contains(x, y))
				{
					myOwnerDocument.SetCursor(Cursors.SizeNS);
					return true;
				}
			}
			return false;
		}

		public override bool HandleMouseDown(int x, int y, MouseButtons Button)
		{
			if (Bounds.Contains(x, y) || OwnerDocument.OwnerControl.Cursor == Cursors.SizeWE)
			{
				foreach (EMRCell cell in Cells)
				{
					if (cell.Contains(x, y))
					{
						cell.HandleMouseDown(x, y, Button);
						break;
					}
					if (cell.GetVBorder().Contains(x, y) || cell.GetHBorder().Contains(x, y))
					{
						cell.HandleMouseDown(x, y, Button);
						break;
					}
				}
				return false;
			}
			return false;
		}
	}
}
