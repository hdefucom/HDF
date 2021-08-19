using System.Collections;
using System.Drawing;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class TableTagProvider : SmartTagProvider
	{
		private EMRCell MyCell = null;

		public override int ImageIndex => 15;

		public override Point GetPos()
		{
			EMRTable currentTable = GetCurrentTable();
			if (currentTable != null)
			{
				return new Point(currentTable.Bounds.Right + 2, currentTable.Bounds.Top + 2);
			}
			return Point.Empty;
		}

		private EMRTable GetCurrentTable()
		{
			EMRTable eMRTable = Element as EMRTable;
			if (eMRTable == null)
			{
				MyCell = (Element as EMRCell);
				if (MyCell == null)
				{
					return null;
				}
				eMRTable = (MyCell.Parent.Parent as EMRTable);
			}
			if (!(eMRTable?.Deleteted ?? true))
			{
				return eMRTable;
			}
			return null;
		}

		public override bool isEnable()
		{
			return GetCurrentTable() != null;
		}

		public override void GetCommands(ArrayList myList)
		{
			EMRTable currentTable = GetCurrentTable();
			if (currentTable != null)
			{
				myList.Add(new SmartTagItem(this, 0, "&R  撤销"));
				myList.Add(new SmartTagItem(this, 1, "&A  重复"));
				myList.Add(new SmartTagItem("-"));
				myList.Add(new SmartTagItem(this, 2, "&T  剪贴"));
				myList.Add(new SmartTagItem(this, 3, "&C  复制"));
				myList.Add(new SmartTagItem(this, 4, "&P  粘贴"));
				myList.Add(new SmartTagItem(this, 5, "&D  删除"));
				myList.Add(new SmartTagItem("-"));
				myList.Add(new SmartTagItem(this, 7, "&R  插入列"));
				myList.Add(new SmartTagItem(this, 8, "&A  插入行"));
				myList.Add(new SmartTagItem(this, 10, "&R  平均分配宽度"));
				myList.Add(new SmartTagItem(this, 11, "&R  平均分配高度"));
				myList.Add(new SmartTagItem(this, 9, "&A  删除表格"));
				myList.Add(new SmartTagItem(this, 12, "&H 边框是否打印"));
			}
		}

		public override bool HandleCommand(SmartTagItem item)
		{
			EMRTable currentTable = GetCurrentTable();
			if (currentTable == null)
			{
				return false;
			}
			switch (item.ID)
			{
			case 0:
				OwnerDocument._Undo();
				return true;
			case 1:
				OwnerDocument._Redo();
				return true;
			case 2:
				OwnerDocument._Cut();
				return true;
			case 3:
				OwnerDocument._Copy();
				return true;
			case 4:
				OwnerDocument._Paste();
				return true;
			case 5:
				OwnerDocument._Delete();
				return true;
			case 7:
				currentTable.InsertCol();
				return true;
			case 8:
				currentTable.InsertRow();
				return true;
			case 9:
				currentTable.Parent.RemoveChild(currentTable);
				OwnerDocument.Modified = true;
				OwnerDocument.RefreshElements();
				OwnerDocument.RefreshLine();
				OwnerDocument.UpdateView();
				return true;
			case 10:
			{
				int width = currentTable.Width / currentTable.Cols.Count;
				foreach (EMRCol col in currentTable.Cols)
				{
					col.Width = width;
				}
				OwnerDocument.Modified = true;
				OwnerDocument.Refresh();
				return true;
			}
			case 11:
			{
				int height = currentTable.Height / currentTable.Rows.Count;
				foreach (EMRRow row in currentTable.Rows)
				{
					row.Height = height;
				}
				OwnerDocument.Modified = true;
				OwnerDocument.Refresh();
				return true;
			}
			case 12:
			{
				bool flag = false;
				foreach (EMRCell cell in currentTable.Cells)
				{
					if (cell.topborder == 0)
					{
						flag = true;
					}
					if (flag)
					{
						cell.topborder = 1;
						cell.bottomborder = 1;
						cell.leftborder = 1;
						cell.rightborder = 1;
					}
					else
					{
						cell.topborder = 0;
						cell.bottomborder = 0;
						cell.leftborder = 0;
						cell.rightborder = 0;
					}
				}
				OwnerDocument.Modified = true;
				OwnerDocument.Refresh();
				return true;
			}
			case 13:
			{
				string text = dlgInputBox.InputBox("请输入单元格的标识", "修改标识", MyCell.ContentMark);
				if (text != null)
				{
					MyCell.ContentMark = text;
				}
				return true;
			}
			default:
				return false;
			}
		}
	}
}
