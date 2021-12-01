using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ZYCommon;
using ZYTextDocumentLib.icon;

namespace ZYTextDocumentLib
{
	public class ZYKBTreeView : TreeView
	{
		public static bool RunInDesigner = false;

		private bool bolDesignKBMode = false;

		private Control myBindControl;

		private ZYKBBuffer myKBBuffer = null;

		public bool EnableClickEvent = false;

		public EventHandler OnHandleCommand = null;

		private static ArrayList myAllKBTreeView = new ArrayList();

		private bool bolDoubleClickMode = false;

		private bool bolShowKBItem = false;

		private bool bolShowNormalKBItem = false;

		private bool bolShowSystemKBItem = false;

		private bool bolShowTemplateKBItem = false;

		private KB_List myRootKBList = null;

		private TreeNode myStartNode = null;

		private string strSearchText = null;

		private bool bolStartMatch = false;

		private bool bolMatchAll = false;

		private TreeNode myLastDragNode = null;

		private Point myLastMousePos = Point.Empty;

		private TreeNode myDragNode = null;

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

		public bool DesignKBMode
		{
			get
			{
				return bolDesignKBMode;
			}
			set
			{
				bolDesignKBMode = value;
				RunInDesigner = value;
			}
		}

		public Control BindControl
		{
			get
			{
				return myBindControl;
			}
			set
			{
				myBindControl = value;
			}
		}

		public bool DoubleClickMode
		{
			get
			{
				return bolDoubleClickMode;
			}
			set
			{
				bolDoubleClickMode = value;
			}
		}

		public bool ShowKBItem
		{
			get
			{
				return bolShowKBItem;
			}
			set
			{
				bolShowKBItem = value;
			}
		}

		public bool ShowNormalKBItem
		{
			get
			{
				return bolShowKBItem && bolShowNormalKBItem;
			}
			set
			{
				bolShowNormalKBItem = value;
			}
		}

		public bool ShowSystemKBItem
		{
			get
			{
				return bolShowKBItem && bolShowSystemKBItem;
			}
			set
			{
				bolShowSystemKBItem = value;
			}
		}

		public bool ShowTemplateKBItem
		{
			get
			{
				return bolShowKBItem && bolShowTemplateKBItem;
			}
			set
			{
				bolShowTemplateKBItem = value;
			}
		}

		public KB_List RootKBList
		{
			get
			{
				return myRootKBList;
			}
			set
			{
				myRootKBList = value;
			}
		}

		public KB_List SelectedKBList
		{
			get
			{
				if (base.SelectedNode != null)
				{
					return base.SelectedNode.Tag as KB_List;
				}
				return null;
			}
			set
			{
				if (value != null && value.SEQ != null)
				{
					TreeNode nodeByKBList = GetNodeByKBList(value, null);
					if (nodeByKBList != null)
					{
						base.SelectedNode = nodeByKBList;
					}
				}
			}
		}

		public event KBListClickHandler KBListClick;

		public event KBItemClickHandler KBItemClick;

		protected override void WndProc(ref Message m)
		{
			if (20 != m.Msg)
			{
				base.WndProc(ref m);
			}
		}

		public static ImageList GetKBImageList()
		{
			string[] array = new string[20]
			{
				"chm.bmp",
				"open.bmp",
				"close.bmp",
				"item.bmp",
				"frm.bmp",
				"new.bmp",
				"check.bmp",
				"delete.bmp",
				"event.bmp",
				"system.bmp",
				"close_2.bmp",
				"open_2.bmp",
				"text.bmp",
				"createsql.bmp",
				"link.bmp",
				"img.bmp",
				"div.bmp",
				"paragraph.bmp",
				"unit.bmp",
				"hrule.bmp"
			};
			ImageList imageList = new ImageList();
			imageList.ImageSize = new Size(16, 16);
			string[] array2 = array;
			foreach (string strName in array2)
			{
				Image resourceImage = IconHelper.GetResourceImage(strName, Color.White);
				if (resourceImage != null)
				{
					imageList.Images.Add(resourceImage);
				}
			}
			return imageList;
		}

		public static Color GetItemBackColor(ZYDBRecordBase myRecord)
		{
			if (!RunInDesigner)
			{
				return Color.White;
			}
			if (myRecord != null)
			{
				if (myRecord.isNewRecord())
				{
					return Color.Gold;
				}
				if (myRecord.isDeleted())
				{
					return Color.Salmon;
				}
				if (myRecord.isModified())
				{
					return Color.LightGreen;
				}
			}
			return Color.White;
		}

		public static int GetICONIndex(ZYDBRecordBase myRecord, bool bolExpanded)
		{
			int result = 0;
			if (myRecord != null)
			{
				KB_List kB_List = myRecord as KB_List;
				if (kB_List != null)
				{
					result = (kB_List.InputBoxAttribute ? 12 : ((RunInDesigner && !StringCommon.isBlankString(kB_List.ListSQL)) ? 13 : (kB_List.HasChildren() ? ((!bolExpanded) ? 10 : 11) : (bolExpanded ? 1 : 2))));
				}
				KB_Item kB_Item = myRecord as KB_Item;
				if (kB_Item != null)
				{
					if (kB_Item.isCreated())
					{
						result = 8;
					}
					else if (kB_Item.isNormalItem())
					{
						result = 3;
					}
					else if (kB_Item.isSystemItem())
					{
						result = 9;
					}
					else if (kB_Item.isTemplate())
					{
						result = 4;
					}
					else if (kB_Item.isLink())
					{
						result = 14;
					}
				}
			}
			return result;
		}

		public static void GlobalRefreshChileNode(ZYKBTreeView Sender, KB_List myList)
		{
			foreach (ZYKBTreeView item in myAllKBTreeView)
			{
				if (item != Sender || !item.IsDisposed)
				{
					TreeNode nodeByKBList = item.GetNodeByKBList(myList, null);
					if (nodeByKBList != null)
					{
						item.RefreshChildNode(nodeByKBList, bolMoveNode: true);
					}
				}
			}
		}

		protected virtual void OnKBItemClick(TreeNode TreeNode, KB_Item SelectedItem)
		{
			if (!EnableClickEvent)
			{
				return;
			}
			base.SelectedNode = TreeNode;
			if (myBindControl != null)
			{
				ZYEditorControl zYEditorControl = myBindControl as ZYEditorControl;
				if (zYEditorControl != null && SelectedItem.isTemplate())
				{
					ZYEditorAction actionByName = zYEditorControl.GetActionByName("insertdocument");
					if (actionByName != null)
					{
						actionByName.Param1 = SelectedItem.ItemValue;
						actionByName.Execute();
					}
				}
			}
			if (this.KBItemClick != null)
			{
				this.KBItemClick(TreeNode, SelectedItem);
			}
		}

		protected virtual void OnKBListClick(TreeNode TreeNode, KB_List SelectedList)
		{
			if (!EnableClickEvent)
			{
				return;
			}
			if (myBindControl != null)
			{
				ZYKBListView zYKBListView = myBindControl as ZYKBListView;
				if (zYKBListView != null)
				{
					zYKBListView.ShowChildKBList = SelectedList.HasChildren();
					zYKBListView.OwnerKBList = SelectedList;
				}
				(myBindControl as ZYEditorControl)?.EMRDoc._InsertKB(SelectedList);
			}
			if (this.KBListClick != null)
			{
				this.KBListClick(TreeNode, SelectedList);
			}
		}

		public ZYKBTreeView()
		{
			base.Indent = 14;
			base.ItemHeight = 18;
			base.HideSelection = false;
			base.FullRowSelect = false;
			base.ImageList = GetKBImageList();
			myAllKBTreeView.Add(this);
		}

		public void SetDeleteFlag(TreeNode RootNode)
		{
			if (RootNode.Tag is KB_Item)
			{
				(RootNode.Tag as KB_Item).DataState = DataRowState.Deleted;
			}
			else if (RootNode.Tag is KB_List)
			{
				(RootNode.Tag as KB_List).DataState = DataRowState.Deleted;
			}
			RefreshNode(RootNode);
			foreach (TreeNode node in RootNode.Nodes)
			{
				SetDeleteFlag(node);
			}
		}

		public void SetSectionFlag(TreeNode RootNode, string strSection)
		{
			if (RootNode.Tag is KB_List)
			{
				(RootNode.Tag as KB_List).OwnerSection = strSection;
			}
			RefreshNode(RootNode);
			foreach (TreeNode node in RootNode.Nodes)
			{
				SetSectionFlag(node, strSection);
			}
		}

		public KB_List InsertKBList()
		{
			KB_List selectedKBList = SelectedKBList;
			if (selectedKBList != null && selectedKBList.Parent != null)
			{
				string text = dlgInputBox.InputBox("输入新的知识点的名称", "插入知识点", "");
				if (!StringCommon.isBlankString(text))
				{
					KB_List parent = selectedKBList.Parent;
					KB_List kB_List = parent.NewChildList(text);
					if (kB_List != null)
					{
						TreeNode treeNode = new TreeNode();
						treeNode.Tag = kB_List;
						RefreshNode(treeNode);
						TreeNode parent2 = base.SelectedNode.Parent;
						parent2.Nodes.Add(treeNode);
						treeNode.EnsureVisible();
						base.SelectedNode = treeNode;
						return kB_List;
					}
				}
			}
			return null;
		}

		public KB_List NewKBList(int intKBStyle)
		{
			KB_List selectedKBList = SelectedKBList;
			if (!(selectedKBList?.HasItems() ?? true))
			{
				string text = dlgInputBox.InputBox("输入新的知识点的名称", "新增知识点", "");
				if (!StringCommon.isBlankString(text))
				{
					KB_List kB_List = selectedKBList.NewChildList(text);
					if (kB_List != null)
					{
						kB_List.KBStyle = intKBStyle;
						TreeNode treeNode = new TreeNode();
						treeNode.Tag = kB_List;
						RefreshNode(treeNode);
						base.SelectedNode.Nodes.Add(treeNode);
						RefreshNode(base.SelectedNode);
						treeNode.EnsureVisible();
						base.SelectedNode = treeNode;
						return kB_List;
					}
				}
			}
			return null;
		}

		public bool NewKBItem()
		{
			return NewKBItemWithStyle(0) != null;
		}

		public bool NewFormItem()
		{
			return NewKBItemWithStyle(100) != null;
		}

		private KB_Item NewKBItemWithStyle(int Style)
		{
			KB_List selectedKBList = SelectedKBList;
			if (!(selectedKBList?.HasChildren() ?? true))
			{
				string text = dlgInputBox.InputBox("输入新增的项目文本", "新增项目", "");
				if (!StringCommon.isBlankString(text))
				{
					KB_Item kB_Item = selectedKBList.NewItem(text);
					if (kB_Item != null)
					{
						kB_Item.ItemStyle = Style;
						TreeNode treeNode = new TreeNode();
						treeNode.Tag = kB_Item;
						RefreshNode(treeNode);
						base.SelectedNode.Nodes.Add(treeNode);
						RefreshNode(base.SelectedNode);
						treeNode.EnsureVisible();
						base.SelectedNode = treeNode;
						return kB_Item;
					}
				}
			}
			return null;
		}

		protected override void Dispose(bool disposing)
		{
			myAllKBTreeView.Remove(this);
			if (disposing && base.ImageList != null)
			{
				base.ImageList.Dispose();
			}
		}

		public void MoveNodeUp()
		{
			MoveTreeNode(bolUp: true);
		}

		public void MoveNodeDown()
		{
			MoveTreeNode(bolUp: false);
		}

		private void MoveTreeNode(bool bolUp)
		{
			if (base.SelectedNode != null && base.SelectedNode.Tag is KB_List && ((base.SelectedNode.PrevNode != null && bolUp) || (base.SelectedNode.NextNode != null && !bolUp)))
			{
				TreeNode parent = base.SelectedNode.Parent;
				TreeNode selectedNode = base.SelectedNode;
				TreeNode treeNode = bolUp ? selectedNode.PrevNode : selectedNode.NextNode;
				KB_List kB_List = selectedNode.Tag as KB_List;
				KB_List kB_List2 = treeNode.Tag as KB_List;
				int listIndex = kB_List.ListIndex;
				kB_List.ListIndex = kB_List2.ListIndex;
				kB_List2.ListIndex = listIndex;
				selectedNode.Remove();
				parent.Nodes.Insert(bolUp ? treeNode.Index : (treeNode.Index + 1), selectedNode);
				selectedNode.EnsureVisible();
				base.SelectedNode = selectedNode;
				RefreshNode(selectedNode);
				RefreshNode(treeNode);
			}
		}

		private void RefreshNodeIcon(TreeNode myNode)
		{
			myNode.ImageIndex = GetICONIndex(myNode.Tag as KB_List, myNode.IsExpanded);
			myNode.SelectedImageIndex = myNode.ImageIndex;
		}

		private void Alert(string strAlert)
		{
			MessageBox.Show(this, strAlert, "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		protected override void OnGotFocus(EventArgs e)
		{
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (myDragNode != null)
			{
				RefreshNode(myDragNode);
			}
			if (!bolDesignKBMode)
			{
				if (e.Button != MouseButtons.Right)
				{
					return;
				}
				TreeNode nodeAt = GetNodeAt(e.X, e.Y);
				if (nodeAt != null && nodeAt.Bounds.Contains(e.X, e.Y) && nodeAt.Tag is KB_List)
				{
					KB_List kB_List = (KB_List)nodeAt.Tag;
					if (kB_List.HasItems())
					{
						base.SelectedNode = nodeAt;
						ArrayList arrayList = new ArrayList();
						arrayList.Add(new MenuItem("知识点[ " + kB_List.Name + " ]共 " + kB_List.Items.Count + " 个项目"));
						arrayList.Add(new MenuItem("-"));
						int num = 0;
						foreach (KB_Item item in kB_List.Items)
						{
							arrayList.Add(new MenuItem(item.ItemText));
							if (num++ > 30)
							{
								break;
							}
						}
						using (ContextMenu contextMenu = new ContextMenu((MenuItem[])arrayList.ToArray(typeof(MenuItem))))
						{
							contextMenu.Show(this, new Point(nodeAt.Bounds.Left, nodeAt.Bounds.Bottom));
						}
					}
				}
			}
			else if (base.LabelEdit && e.Button == MouseButtons.Right)
			{
				TreeNode nodeAt = GetNodeAt(e.X, e.Y);
				if (nodeAt != null)
				{
					base.SelectedNode = nodeAt;
				}
			}
		}

		protected override void OnAfterSelect(TreeViewEventArgs e)
		{
			if (bolDoubleClickMode)
			{
				base.OnAfterSelect(e);
				return;
			}
			TreeNode node = e.Node;
			if (node != null)
			{
				base.SelectedNode = node;
				KB_List kB_List = node.Tag as KB_List;
				if (kB_List != null && EnableClickEvent)
				{
					OnKBListClick(node, kB_List);
				}
				KB_Item kB_Item = node.Tag as KB_Item;
				if (kB_Item != null && EnableClickEvent)
				{
					OnKBItemClick(node, kB_Item);
				}
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			if (bolDoubleClickMode && base.SelectedNode != null)
			{
				Point pt = PointToClient(Control.MousePosition);
				TreeNode selectedNode = base.SelectedNode;
				if (selectedNode.Bounds.Contains(pt))
				{
					KB_List kB_List = selectedNode.Tag as KB_List;
					if (kB_List != null && EnableClickEvent)
					{
						OnKBListClick(selectedNode, kB_List);
					}
					KB_Item kB_Item = selectedNode.Tag as KB_Item;
					if (kB_Item != null && EnableClickEvent)
					{
						OnKBItemClick(selectedNode, kB_Item);
					}
				}
			}
			else
			{
				base.OnDoubleClick(e);
			}
		}

		protected override void OnBeforeLabelEdit(NodeLabelEditEventArgs e)
		{
			ZYDBRecordBase zYDBRecordBase = e.Node.Tag as ZYDBRecordBase;
			if ((zYDBRecordBase != null && zYDBRecordBase.isDeleted()) || e.Node == base.Nodes[0])
			{
				e.CancelEdit = true;
			}
		}

		protected override void OnAfterExpand(TreeViewEventArgs e)
		{
			SetTreeNodeICON(e.Node);
		}

		protected override void OnAfterCollapse(TreeViewEventArgs e)
		{
			SetTreeNodeICON(e.Node);
		}

		protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
		{
			if (e.Label == null)
			{
				return;
			}
			KB_List kB_List = e.Node.Tag as KB_List;
			if (kB_List != null)
			{
				if (!KB_List.CheckName(e.Label))
				{
					Alert("知识点名称不合法,不得为空且长度不得超过50个字符");
				}
				kB_List.Name = e.Label.Trim();
				SetTreeNodeICON(e.Node);
			}
			KB_Item kB_Item = e.Node.Tag as KB_Item;
			if (kB_Item != null)
			{
				if (!KB_Item.CheckItemText(e.Label))
				{
					Alert("列表项目文本不合法，不得为空且长度不得超过100个字符");
				}
				kB_Item.ItemText = e.Label;
				SetTreeNodeICON(e.Node);
			}
		}

		public void RefreshChildNode(bool bolMoveNode)
		{
			RefreshChildNode(base.SelectedNode, bolMoveNode);
			RefreshNode(base.SelectedNode);
		}

		public void RefreshChildNode(TreeNode myRootNode, bool bolMoveNode)
		{
			if (myRootNode == null)
			{
				return;
			}
			if (bolMoveNode)
			{
				TreeNodeCollection nodes = myRootNode.Nodes;
				BeginUpdate();
				if (nodes.Count > 0)
				{
					RefreshNode(nodes[0]);
				}
				for (int i = 1; i < nodes.Count - 1; i++)
				{
					TreeNode treeNode = nodes[i];
					RefreshNode(treeNode);
					IListIndex listIndex = nodes[i - 1].Tag as IListIndex;
					IListIndex listIndex2 = treeNode.Tag as IListIndex;
					if (listIndex2.ListIndex < listIndex.ListIndex)
					{
						myRootNode.Nodes.Remove(treeNode);
						foreach (TreeNode item in nodes)
						{
							if ((item.Tag as IListIndex).ListIndex > listIndex2.ListIndex)
							{
								nodes.Insert(nodes.IndexOf(item), treeNode);
								break;
							}
						}
					}
				}
				KB_List kB_List = myRootNode.Tag as KB_List;
				if (kB_List != null && kB_List.HasChildren())
				{
					foreach (KB_List childNode in kB_List.ChildNodes)
					{
						bool flag = false;
						foreach (TreeNode item2 in nodes)
						{
							if (item2.Tag == childNode)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							TreeNode treeNode3 = new TreeNode();
							nodes.Add(treeNode3);
							treeNode3.Tag = childNode;
							RefreshNode(treeNode3);
						}
					}
				}
				EndUpdate();
			}
			else
			{
				foreach (TreeNode node in myRootNode.Nodes)
				{
					RefreshNode(node);
				}
			}
		}

		public TreeNode GetNodeByKBList(KB_List myList, TreeNodeCollection myNodes)
		{
			if (myList == null)
			{
				return null;
			}
			if (myNodes == null)
			{
				myNodes = base.Nodes;
			}
			foreach (TreeNode myNode in myNodes)
			{
				if (myNode.Tag == myList)
				{
					return myNode;
				}
				TreeNode nodeByKBList = GetNodeByKBList(myList, myNode.Nodes);
				if (nodeByKBList != null)
				{
					return nodeByKBList;
				}
			}
			return null;
		}

		public void RefreshAllNode()
		{
			BeginUpdate();
			RefreshNodes(base.Nodes[0].Nodes);
			EndUpdate();
		}

		private bool RefreshNodes(TreeNodeCollection nodes)
		{
			bool result = false;
			for (int num = nodes.Count - 1; num >= 0; num--)
			{
				ZYDBRecordBase zYDBRecordBase = nodes[num].Tag as ZYDBRecordBase;
				if (zYDBRecordBase != null)
				{
					if (zYDBRecordBase.isDeleted())
					{
						nodes.RemoveAt(num);
						result = true;
					}
					else
					{
						RefreshNodes(nodes[num].Nodes);
						RefreshNode(nodes[num]);
					}
				}
			}
			return result;
		}

		public void RefreshNode(TreeNode myNode)
		{
			if (myNode == null)
			{
				return;
			}
			if (myNode.Tag is KB_List)
			{
				KB_List kB_List = myNode.Tag as KB_List;
				if (myNode.Text != kB_List.Name)
				{
					myNode.Text = kB_List.Name;
				}
				myNode.ImageIndex = GetICONIndex(kB_List, myNode.Nodes.Count > 0 && myNode.IsExpanded);
			}
			if (myNode.Tag is KB_Item)
			{
				KB_Item kB_Item = myNode.Tag as KB_Item;
				if (myNode.Text != kB_Item.ItemText)
				{
					myNode.Text = kB_Item.ItemText;
				}
				myNode.ImageIndex = GetICONIndex(kB_Item, bolExpanded: false);
			}
			myNode.SelectedImageIndex = myNode.ImageIndex;
			myNode.BackColor = GetItemBackColor(myNode.Tag as ZYDBRecordBase);
			if (myKBBuffer != null)
			{
				myNode.ForeColor = myKBBuffer.GetItemForeColor(myNode.Tag as KB_List);
			}
			if (myNode.Tag is KB_Item && myNode.Parent != null)
			{
				myNode.ForeColor = myNode.Parent.ForeColor;
			}
		}

		public void RefreshNodeColor(TreeNode myRootNode)
		{
			if (myRootNode == null)
			{
				return;
			}
			myRootNode.BackColor = GetItemBackColor(myRootNode.Tag as ZYDBRecordBase);
			if (myKBBuffer != null)
			{
				if (myRootNode.Tag is KB_List)
				{
					myRootNode.ForeColor = myKBBuffer.GetItemForeColor(myRootNode.Tag as KB_List);
				}
				if (myRootNode.Tag is KB_Item)
				{
					myRootNode.ForeColor = myRootNode.Parent.ForeColor;
				}
			}
			foreach (TreeNode node in myRootNode.Nodes)
			{
				RefreshNodeColor(node);
			}
		}

		public void ResetContent()
		{
			BeginUpdate();
			base.Nodes.Clear();
			TreeNode treeNode = new TreeNode(myRootKBList.Name);
			base.Nodes.Add(treeNode);
			treeNode.Tag = myRootKBList;
			ResetNode(treeNode);
			treeNode.ImageIndex = 0;
			treeNode.Expand();
			EndUpdate();
			Refresh();
		}

		public void RefreshCurrentNode()
		{
			RefreshNode(base.SelectedNode);
		}

		public void ResetNode(TreeNode RootNode)
		{
			KB_List kB_List = RootNode.Tag as KB_List;
			if (kB_List != null)
			{
				TreeNode treeNode = null;
				if (kB_List.ChildNodes != null)
				{
					foreach (KB_List childNode in kB_List.ChildNodes)
					{
						if (bolDesignKBMode || childNode.Visible)
						{
							treeNode = new TreeNode(childNode.Name);
							RootNode.Nodes.Add(treeNode);
							treeNode.Tag = childNode;
							RefreshNode(treeNode);
							ResetNode(treeNode);
						}
					}
				}
				if (ShowKBItem && kB_List.Items != null)
				{
					foreach (KB_Item item in kB_List.Items)
					{
						if ((ShowNormalKBItem && item.isNormalItem()) || (ShowSystemKBItem && item.isSystemItem()) || (ShowTemplateKBItem && item.isTemplate()))
						{
							treeNode = new TreeNode(item.ItemText);
							treeNode.Tag = item;
							RefreshNode(treeNode);
							RootNode.Nodes.Add(treeNode);
						}
					}
				}
			}
		}

		public void SetTreeNodeICON(TreeNode myNode)
		{
			if (myNode != null && myNode != base.Nodes[0])
			{
				int num2 = myNode.SelectedImageIndex = (myNode.ImageIndex = GetICONIndex(myNode.Tag as ZYDBRecordBase, myNode.IsExpanded));
				myNode.BackColor = GetItemBackColor(myNode.Tag as ZYDBRecordBase);
				KB_List kB_List = myNode.Tag as KB_List;
				if (myKBBuffer != null)
				{
					myNode.ForeColor = myKBBuffer.GetItemForeColor(myNode.Tag as KB_List);
				}
			}
		}

		public TreeNode SearchNode(TreeNode StartNode, string strFind, bool MatchAll)
		{
			if (StartNode == null)
			{
				StartNode = base.SelectedNode;
			}
			if (StartNode == null)
			{
				StartNode = base.Nodes[0];
			}
			if (StringCommon.isBlankString(strFind))
			{
				return null;
			}
			myStartNode = StartNode;
			strSearchText = strFind;
			bolMatchAll = MatchAll;
			bolStartMatch = false;
			return InnerSearchNode(base.Nodes);
		}

		private TreeNode InnerSearchNode(TreeNodeCollection myNodes)
		{
			foreach (TreeNode myNode in myNodes)
			{
				if (bolStartMatch)
				{
					if (myNode.Text == strSearchText || (!bolMatchAll && myNode.Text.IndexOf(strSearchText) >= 0))
					{
						return myNode;
					}
				}
				else if (myNode == myStartNode)
				{
					bolStartMatch = true;
				}
				TreeNode treeNode2 = InnerSearchNode(myNode.Nodes);
				if (treeNode2 != null)
				{
					return treeNode2;
				}
			}
			return null;
		}

		private bool CanDrag(DragEventArgs drgevent)
		{
			bool flag = false;
			if (!DesignKBMode)
			{
				return false;
			}
			ArrayList arrayList = drgevent.Data.GetData(typeof(ArrayList)) as ArrayList;
			if (arrayList != null && arrayList.Count > 0)
			{
				Point p = new Point(drgevent.X, drgevent.Y);
				p = PointToClient(p);
				TreeNode nodeAt = GetNodeAt(p);
				if (nodeAt != null)
				{
					if (nodeAt == myLastDragNode)
					{
						flag = true;
					}
					else
					{
						KB_List kB_List = nodeAt.Tag as KB_List;
						if (kB_List != null)
						{
							if (arrayList[0] is KB_Item && kB_List.EnableAddItem() && (arrayList[0] as KB_Item).KBSEQ != kB_List.SEQ)
							{
								flag = true;
							}
							if (arrayList[0] is KB_List && kB_List.EnableAddChild() && (arrayList[0] as KB_List).ParentSEQ != kB_List.SEQ)
							{
								flag = true;
							}
						}
						if (flag)
						{
							if (myLastDragNode != null)
							{
								RefreshNode(myLastDragNode);
							}
							myLastDragNode = nodeAt;
							nodeAt.BackColor = SystemColors.Highlight;
							nodeAt.ForeColor = SystemColors.HighlightText;
						}
					}
				}
			}
			return flag;
		}

		protected override void OnDragOver(DragEventArgs drgevent)
		{
			if (CanDrag(drgevent))
			{
				drgevent.Effect = DragDropEffects.Move;
			}
			else
			{
				drgevent.Effect = DragDropEffects.None;
			}
		}

		protected override void OnDragLeave(EventArgs e)
		{
			if (myLastDragNode != null)
			{
				RefreshNode(myLastDragNode);
				myLastDragNode = null;
			}
		}

		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (CanDrag(drgevent))
			{
				Point p = new Point(drgevent.X, drgevent.Y);
				p = PointToClient(p);
				TreeNode nodeAt = GetNodeAt(p);
				ArrayList arrayList = drgevent.Data.GetData(typeof(ArrayList)) as ArrayList;
				if (arrayList != null && arrayList.Count > 0 && nodeAt != null && nodeAt.Tag is KB_List)
				{
					try
					{
						KB_List kB_List = nodeAt.Tag as KB_List;
						foreach (object item in arrayList)
						{
							if (item is KB_Item)
							{
								kB_List.AppendItem(item as KB_Item);
							}
							if (item is KB_List && kB_List.AppendChild(item as KB_List))
							{
								TreeNode nodeByKBList = GetNodeByKBList(item as KB_List, null);
								if (nodeByKBList != null && nodeByKBList.Parent != null)
								{
									nodeByKBList.Remove();
									nodeAt.Nodes.Add(nodeByKBList);
									RefreshNode(nodeByKBList);
								}
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}
					RefreshNode(nodeAt);
					RefreshChildNode(nodeAt, bolMoveNode: true);
					nodeAt.Expand();
					drgevent.Effect = DragDropEffects.Move;
					base.OnDragDrop(drgevent);
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && base.Nodes.Count > 0)
			{
				myLastMousePos = new Point(e.X, e.Y);
				myDragNode = GetNodeAt(e.X, e.Y);
				if (myDragNode == base.Nodes[0])
				{
					myDragNode = null;
				}
				if (myDragNode != null)
				{
					if (!myDragNode.Bounds.Contains(e.X, e.Y))
					{
						myDragNode = null;
					}
					else if (DesignKBMode)
					{
						myDragNode.BackColor = SystemColors.Highlight;
						myDragNode.ForeColor = SystemColors.HighlightText;
					}
					else
					{
						bool enableClickEvent = EnableClickEvent;
						EnableClickEvent = false;
						base.SelectedNode = myDragNode;
						EnableClickEvent = enableClickEvent;
					}
				}
			}
			if (e.Button == MouseButtons.Right && base.Nodes.Count > 0)
			{
				TreeNode nodeAt = GetNodeAt(e.X, e.Y);
				if (nodeAt != null && nodeAt.Bounds.Contains(e.X, e.Y))
				{
					base.SelectedNode = nodeAt;
				}
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && myDragNode != null)
			{
				RectangleObject rectangleObject = new RectangleObject();
				rectangleObject.SetRect(myLastMousePos.X, myLastMousePos.Y, e.X, e.Y);
				if (rectangleObject.Width > SystemInformation.DragSize.Width || rectangleObject.Height > SystemInformation.DragSize.Height)
				{
					RefreshNode(myDragNode);
					ArrayList arrayList = new ArrayList();
					arrayList.Add(myDragNode.Tag);
					DataObject data = new DataObject(arrayList);
					DoDragDrop(data, DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.Link | DragDropEffects.Scroll);
					return;
				}
			}
			base.OnMouseMove(e);
		}

		protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
		{
			gfbevent.UseDefaultCursors = true;
		}
	}
}
