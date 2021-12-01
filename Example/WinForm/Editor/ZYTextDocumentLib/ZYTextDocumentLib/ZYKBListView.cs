using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYKBListView : ListView
	{
		private KB_List myOwnerKBList = null;

		private bool bolShowChildKBList = false;

		private string strDefaultStatus = null;

		private ZYKBBuffer myKBBuffer = null;

		public ZYKBBuffer KBBuffer
		{
			get
			{
				return myKBBuffer;
			}
			set
			{
				myKBBuffer = value;
			}
		}

		public bool ShowChildKBList
		{
			get
			{
				return bolShowChildKBList;
			}
			set
			{
				bolShowChildKBList = value;
			}
		}

		public KB_List OwnerKBList
		{
			get
			{
				return myOwnerKBList;
			}
			set
			{
				myOwnerKBList = value;
				RefreshContent();
			}
		}

		public event StatusTextChangeHandler StatusTextChange;

		public ZYKBListView()
		{
			ColumnHeader value = new ColumnHeader
			{
				Text = "项目文本",
				Width = 150
			};
			base.Columns.Add(value);
			value = new ColumnHeader
			{
				Text = "项目值",
				Width = 150
			};
			base.Columns.Add(value);
			value = new ColumnHeader
			{
				Text = "类型",
				Width = 90
			};
			base.Columns.Add(value);
			value = new ColumnHeader
			{
				Text = "编号",
				Width = 80
			};
			base.Columns.Add(value);
			base.FullRowSelect = true;
			base.GridLines = true;
			base.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			base.HideSelection = false;
			base.LabelEdit = true;
			base.View = View.Details;
		}

		public bool EditFocusedItem()
		{
			if (base.FocusedItem != null && base.FocusedItem.Tag is KB_Item)
			{
				using (dlgKB_Item dlgKB_Item = new dlgKB_Item())
				{
					dlgKB_Item.OwnerItem = (base.FocusedItem.Tag as KB_Item);
					if (dlgKB_Item.ShowDialog(FindForm()) == DialogResult.OK)
					{
						RefreshListItem(base.FocusedItem);
						return true;
					}
				}
			}
			return false;
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			if (base.LabelEdit && base.FocusedItem != null && base.FocusedItem.Tag is KB_Item)
			{
				using (dlgKB_Item dlgKB_Item = new dlgKB_Item())
				{
					dlgKB_Item.OwnerItem = (base.FocusedItem.Tag as KB_Item);
					if (dlgKB_Item.ShowDialog(FindForm()) == DialogResult.OK)
					{
						RefreshListItem(base.FocusedItem);
					}
				}
			}
			else
			{
				base.OnDoubleClick(e);
			}
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			if (this.StatusTextChange != null)
			{
				if (base.SelectedItems.Count == 1)
				{
					this.StatusTextChange(this, myOwnerKBList.GetRealFullPath() + "." + base.SelectedItems[0].Text);
				}
				else if (base.SelectedItems.Count > 1)
				{
					this.StatusTextChange(this, "共选择 " + base.SelectedItems.Count + " 个对象");
				}
				else
				{
					this.StatusTextChange(this, strDefaultStatus);
				}
			}
		}

		protected override void OnBeforeLabelEdit(LabelEditEventArgs e)
		{
			if (!(base.Items[e.Item].Tag is KB_Item))
			{
				return;
			}
			KB_Item kB_Item = base.Items[e.Item].Tag as KB_Item;
			if (kB_Item.ItemStyle == 1 || kB_Item.isDeleted())
			{
				e.CancelEdit = true;
				return;
			}
			ZYDBRecordBase zYDBRecordBase = base.Items[e.Item].Tag as ZYDBRecordBase;
			if (zYDBRecordBase.isDeleted())
			{
				e.CancelEdit = true;
			}
			else
			{
				base.OnBeforeLabelEdit(e);
			}
		}

		protected override void OnAfterLabelEdit(LabelEditEventArgs e)
		{
			if (e.Label == null)
			{
				return;
			}
			if (base.Items[e.Item].Tag is KB_Item)
			{
				KB_Item kB_Item = base.Items[e.Item].Tag as KB_Item;
				if (kB_Item.ItemValue == null || kB_Item.ItemText.Equals(kB_Item.ItemValue))
				{
					if (!KB_Item.CheckItemText(e.Label))
					{
						Alert("列表项目文本不合法，不得为空且长度不得超过100个字符");
					}
					kB_Item.ItemText = e.Label;
					if (kB_Item.ItemValue != null)
					{
						kB_Item.ItemValue = kB_Item.ItemText;
					}
				}
				else
				{
					kB_Item.ItemText = e.Label;
				}
				RefreshListItem(base.Items[e.Item]);
			}
			else
			{
				KB_List kB_List = base.Items[e.Item].Tag as KB_List;
				if (!KB_List.CheckName(e.Label))
				{
					Alert("知识点名称不合法,不得为空且长度不得超过50个字符");
				}
				kB_List.Name = e.Label;
				RefreshListItem(base.Items[e.Item]);
			}
			base.OnAfterLabelEdit(e);
		}

		private void Alert(string strAlert)
		{
			MessageBox.Show(this, strAlert, "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		protected override void OnItemDrag(ItemDragEventArgs e)
		{
			if (base.SelectedItems.Count > 0)
			{
				ArrayList arrayList = new ArrayList();
				foreach (ListViewItem selectedItem in base.SelectedItems)
				{
					arrayList.Add(selectedItem.Tag);
				}
				DataObject data = new DataObject(arrayList);
				DoDragDrop(data, DragDropEffects.All);
			}
		}

		public void RefreshContent()
		{
			BeginUpdate();
			base.Items.Clear();
			int num = 0;
			if (bolShowChildKBList && myOwnerKBList != null && myOwnerKBList.HasChildren())
			{
				foreach (KB_List childNode in myOwnerKBList.ChildNodes)
				{
					ListViewItem listViewItem = CreateListViewItem();
					listViewItem.Tag = childNode;
					RefreshListItem(listViewItem);
					if (childNode.Items != null)
					{
						num += childNode.Items.Count;
					}
				}
			}
			if (myOwnerKBList != null && myOwnerKBList.HasItems())
			{
				foreach (KB_Item item in myOwnerKBList.Items)
				{
					ListViewItem listViewItem = CreateListViewItem();
					listViewItem.Tag = item;
					RefreshListItem(listViewItem);
				}
			}
			EndUpdate();
			if (this.StatusTextChange == null || myOwnerKBList == null)
			{
				return;
			}
			if (myOwnerKBList == null)
			{
				this.StatusTextChange(this, null);
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[" + myOwnerKBList.GetRealFullPath() + "]");
			stringBuilder.Append(" 共 " + base.Items.Count + " 个对象");
			if (myOwnerKBList.HasChildren())
			{
				stringBuilder.Append(" 有 " + myOwnerKBList.ChildNodes.Count + " 个知识点 ");
			}
			if (num > 0)
			{
				stringBuilder.Append("拥有 " + num + " 个列表项目");
			}
			strDefaultStatus = stringBuilder.ToString();
			this.StatusTextChange(this, strDefaultStatus);
		}

		private ListViewItem CreateListViewItem()
		{
			ListViewItem listViewItem = new ListViewItem();
			listViewItem.SubItems.Add("");
			listViewItem.SubItems.Add("");
			listViewItem.SubItems.Add("");
			base.Items.Add(listViewItem);
			return listViewItem;
		}

		public void RefreshListItem(ListViewItem myItem)
		{
			if (myItem.Tag is KB_Item)
			{
				KB_Item kB_Item = myItem.Tag as KB_Item;
				if (base.SmallImageList != null)
				{
					myItem.ImageIndex = ZYKBTreeView.GetICONIndex(kB_Item, bolExpanded: false);
				}
				myItem.Text = kB_Item.ItemText;
				myItem.SubItems[1].Text = kB_Item.ItemValue;
				myItem.SubItems[2].Text = KB_Item.KBItemStyleToDesc(kB_Item.ItemStyle);
				myItem.SubItems[3].Text = kB_Item.ItemSEQ.ToString();
			}
			else
			{
				KB_List kB_List = myItem.Tag as KB_List;
				if (base.SmallImageList != null)
				{
					myItem.ImageIndex = ZYKBTreeView.GetICONIndex(kB_List, bolExpanded: false);
				}
				myItem.Text = kB_List.Name;
				string text = null;
				if (kB_List.ChildNodes != null)
				{
					text = kB_List.ChildNodes.Count + "个子节点";
				}
				if (kB_List.Items != null)
				{
					text = kB_List.Items.Count + "个项目";
				}
				myItem.SubItems[1].Text = text;
				if (StringCommon.isBlankString(kB_List.ListSQL))
				{
					myItem.SubItems[2].Text = "知识点";
				}
				else
				{
					myItem.SubItems[2].Text = "SQL知识点";
				}
				myItem.SubItems[3].Text = kB_List.SEQ;
			}
			myItem.BackColor = ZYKBTreeView.GetItemBackColor(myItem.Tag as ZYDBRecordBase);
			if (myKBBuffer != null)
			{
				myItem.ForeColor = myKBBuffer.GetItemForeColor(myItem.Tag as KB_List);
			}
		}

		public bool NewKBList()
		{
			if (myOwnerKBList != null && !myOwnerKBList.HasItems())
			{
				string text = dlgInputBox.InputBox("输入新的列表的名称", "新增列表", "");
				if (!StringCommon.isBlankString(text))
				{
					KB_List tag = myOwnerKBList.NewChildList(text);
					ListViewItem listViewItem = CreateListViewItem();
					listViewItem.Tag = tag;
					RefreshListItem(listViewItem);
					return true;
				}
			}
			return false;
		}

		public bool NewKBItem()
		{
			if (myOwnerKBList != null && !myOwnerKBList.HasChildren())
			{
				string text = dlgInputBox.InputBox("输入新增的项目文本", "新增项目", "");
				if (!StringCommon.isBlankString(text))
				{
					KB_Item tag = myOwnerKBList.NewItem(text);
					ListViewItem listViewItem = CreateListViewItem();
					listViewItem.Tag = tag;
					RefreshListItem(listViewItem);
					return true;
				}
			}
			return false;
		}

		public void DeleteSelectedItems()
		{
			foreach (ListViewItem selectedItem in base.SelectedItems)
			{
				if (selectedItem.Tag is KB_Item)
				{
					KB_Item kB_Item = selectedItem.Tag as KB_Item;
					if (!kB_Item.isCreated())
					{
						kB_Item.DataState = DataRowState.Deleted;
						selectedItem.ImageIndex = ZYKBTreeView.GetICONIndex(kB_Item, bolExpanded: false);
					}
				}
				else
				{
					KB_List kB_List = selectedItem.Tag as KB_List;
					kB_List.DataState = DataRowState.Deleted;
					selectedItem.ImageIndex = ZYKBTreeView.GetICONIndex(kB_List, bolExpanded: false);
				}
				selectedItem.BackColor = ZYKBTreeView.GetItemBackColor(selectedItem.Tag as ZYDBRecordBase);
			}
		}

		public bool ItemMoveUp()
		{
			return MoveKBListItem(-1);
		}

		public bool ItemMoveDown()
		{
			return MoveKBListItem(1);
		}

		private void InitializeComponent()
		{
			Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		}

		private bool MoveKBListItem(int intStep)
		{
			if (base.SelectedItems.Count > 0)
			{
				int index = base.SelectedItems[0].Index;
				ArrayList arrayList = null;
				arrayList = ((!ShowChildKBList) ? myOwnerKBList.Items : myOwnerKBList.ChildNodes);
				if (index + intStep >= 0 && index + intStep < arrayList.Count)
				{
					int num = 0;
					IListIndex listIndex = arrayList[index] as IListIndex;
					IListIndex listIndex2 = arrayList[index + intStep] as IListIndex;
					if (listIndex is KB_Item && ((listIndex as KB_Item).isCreated() || (listIndex2 as KB_Item).isCreated()))
					{
						return false;
					}
					arrayList.Remove(listIndex2);
					arrayList.Insert(index, listIndex2);
					num = listIndex.ListIndex;
					listIndex.ListIndex = listIndex2.ListIndex;
					listIndex2.ListIndex = num;
					RefreshContent();
					base.Items[index + intStep].Selected = true;
					base.Items[index + intStep].Focused = true;
					base.Items[index + intStep].EnsureVisible();
					return true;
				}
			}
			return false;
		}
	}
}
