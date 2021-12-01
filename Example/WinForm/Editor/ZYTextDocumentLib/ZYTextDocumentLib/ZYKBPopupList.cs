using System.Collections;
using System.Drawing;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ZYKBPopupList : ZYPopupList
	{
		public ZYEditorControl OwnerEditor = null;

		public ZYTextDocument OwnerDocument = null;

		public string FirstKBSEQ = "";

		public KB_List CurrentKBList = null;

		public bool EnableSearchKBDynamic = true;

		public KB_Item SelectedKBItem
		{
			get
			{
				if (base.SelectedItem != null && base.SelectedItem.obj is KB_Item)
				{
					return base.SelectedItem.obj as KB_Item;
				}
				return null;
			}
		}

		public object WaitForUserSelectKBItem(bool bolMultiSelect)
		{
			if (myItems.Count > 0)
			{
				if (((ListItem)myItems[0]).obj is KB_List)
				{
					MultiSelect = false;
				}
				else
				{
					MultiSelect = bolMultiSelect;
				}
			}
			while (WaitUserSelected())
			{
				if (MultiSelect)
				{
					return base.SelectedObjects;
				}
				ListItem selectedItem = base.SelectedItem;
				if (selectedItem != null)
				{
					KB_List kB_List = selectedItem.obj as KB_List;
					if (kB_List == null || kB_List.InputBoxAttribute || kB_List.YesNoAttribute)
					{
						CloseList();
						return selectedItem.obj;
					}
					MultiSelect = bolMultiSelect;
					SetKBList((selectedItem.obj as KB_List).SEQ);
				}
			}
			CloseList();
			return null;
		}

		protected override void UpdateChineseSpell(string strSpell)
		{
			if (EnableSearchKBDynamic && (CurrentKBList == null || !CurrentKBList.HasItems()))
			{
				ArrayList arrayList = new ArrayList();
				ZYKBBufferYS.Instance.GetKBListsByName(strSpell, arrayList, bolCompareName: false);
				SetKBList(null, arrayList);
			}
			base.UpdateChineseSpell(strSpell);
		}

		protected override bool OnBackSpace()
		{
			if (CurrentKBList != null && CurrentKBList.SEQ != FirstKBSEQ && CurrentKBList.SEQ != null)
			{
				KB_List currentKBList = CurrentKBList;
				SetKBList(CurrentKBList.ParentSEQ);
				if (currentKBList != null)
				{
					base.SelectedText = currentKBList.Name;
				}
				return true;
			}
			return false;
		}

		protected override void OnLoadChildItems(ListItem myItem, ArrayList myChildItems)
		{
			if (myItem.obj is KB_List)
			{
				KB_List kB_List = myItem.obj as KB_List;
				ArrayList arrayList = new ArrayList();
				string text = lblSpell.Text;
				lblSpell.Text = "正在加载列表 " + kB_List.Name + "...";
				lblSpell.Refresh();
				kB_List.LoadAllChildObjects(arrayList, OwnerDocument.DataSource.DBConn);
				lblSpell.Text = text;
				CreateKBListItems(arrayList, myChildItems, ShowPath: false);
			}
		}

		private void CreateKBListItems(ArrayList myObjects, ArrayList myListItems, bool ShowPath)
		{
			if (myObjects != null && myListItems != null && myObjects.Count > 0)
			{
				ListItem listItem = null;
				Image icon = myImageList.Images[2];
				Image icon2 = myImageList.Images[10];
				Image icon3 = myImageList.Images[4];
				Image icon4 = myImageList.Images[3];
				Image icon5 = myImageList.Images[12];
				foreach (object myObject in myObjects)
				{
					if (myObject == null)
					{
						listItem = CreateListItem(null);
						listItem.Style = 1;
						myListItems.Add(listItem);
					}
					else if (myObject is KB_List)
					{
						KB_List kB_List = (KB_List)myObject;
						if (kB_List.Visible)
						{
							string text = null;
							if (ShowPath)
							{
								if (kB_List.Parent != null && kB_List.Parent.SEQ != null)
								{
									text = kB_List.Parent.GetRealFullPath();
								}
								text = ((!StringCommon.isBlankString(text)) ? (kB_List.Name + " [" + text + "]") : kB_List.Name);
							}
							else
							{
								text = kB_List.Name;
							}
							listItem = CreateListItem(text);
							listItem.obj = kB_List;
							listItem.HasItems = kB_List.HasChildObjects();
							if (kB_List.HasChildren())
							{
								listItem.Icon = icon2;
							}
							else if (kB_List.InputBoxAttribute)
							{
								listItem.Icon = icon5;
							}
							else
							{
								listItem.Icon = icon;
							}
							if (bolMultiSelect)
							{
								bolMultiSelect = false;
							}
							myListItems.Add(listItem);
						}
					}
					else if (myObject is KB_Item)
					{
						KB_Item kB_Item = (KB_Item)myObject;
						listItem = CreateListItem(kB_Item.ItemText);
						listItem.obj = kB_Item;
						if (kB_Item.isTemplate())
						{
							listItem.Icon = icon3;
						}
						else
						{
							listItem.Icon = icon4;
						}
						listItem.HasItems = false;
						myListItems.Add(listItem);
					}
				}
			}
		}

		public void SetKBList(string intKBSEQ)
		{
			SetKBList(ZYKBBufferYS.Instance.GetKBList(intKBSEQ));
		}

		public void SetKBList(string strTitle, ArrayList myList)
		{
			BeginUpdate();
			Clear();
			base.Title = strTitle;
			CurrentKBList = null;
			if (myList != null && myList.Count > 0)
			{
				CreateKBListItems(myList, myItems, ShowPath: true);
			}
			RefreshChineseSpell(ResetAll: true);
			SetDefaultSize();
			EndUpdate();
			UpdateComposition();
		}

		public void SetKBList(KB_List myList)
		{
			CurrentKBList = myList;
			Clear();
			if (CurrentKBList != null)
			{
				BeginUpdate();
				base.Title = "[" + CurrentKBList.Name + "]";
				ArrayList arrayList = new ArrayList();
				string text = lblSpell.Text;
				lblSpell.Text = "正在加载列表 " + CurrentKBList.Name + "...";
				lblSpell.Refresh();
				CurrentKBList.LoadAllChildObjects(arrayList, OwnerDocument.DataSource.DBConn);
				lblSpell.Text = text;
				if (arrayList.Count > 0)
				{
					CreateKBListItems(arrayList, myItems, ShowPath: false);
					RefreshChineseSpell(ResetAll: true);
					SetDefaultSize();
				}
				EndUpdate();
				UpdateComposition();
			}
		}
	}
}
