using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       浏览显示对象类型的树状列表控件
	///       </summary>
	[ToolboxItem(false)]
	public class BrowseTypeTreeView : TreeView
	{
		private class TypeNameComparer : IComparer
		{
			public int Compare(object object_0, object object_1)
			{
				Type type = (Type)object_0;
				Type type2 = (Type)object_1;
				return type.FullName.CompareTo(type2.FullName);
			}
		}

		private ImageList myImageList;

		private IContainer components;

		private Type[] myTypes = null;

		/// <summary>
		///       要显示的类型列表
		///       </summary>
		public Type[] Types
		{
			get
			{
				return myTypes;
			}
			set
			{
				myTypes = value;
			}
		}

		/// <summary>
		///       选中的类型
		///       </summary>
		public Type SelectedType
		{
			get
			{
				if (base.SelectedNode != null)
				{
					return base.SelectedNode.Tag as Type;
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					TreeNode nodeByType = GetNodeByType(value);
					if (nodeByType != null)
					{
						base.SelectedNode = nodeByType;
					}
				}
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public BrowseTypeTreeView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(DCSoft.WinForms.BrowseTypeTreeView));
			myImageList = new System.Windows.Forms.ImageList(components);
			myImageList.ImageSize = new System.Drawing.Size(16, 16);
			myImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resourceManager.GetObject("myImageList.ImageStream");
			myImageList.TransparentColor = System.Drawing.Color.Transparent;
			base.ImageList = myImageList;
		}

		public TreeNode GetNodeByType(Type type_0)
		{
			int num = 14;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			return GetNodeByType(type_0, base.Nodes);
		}

		private TreeNode GetNodeByType(Type type_0, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (type_0.Equals(node.Tag))
				{
					return node;
				}
				TreeNode nodeByType = GetNodeByType(type_0, node.Nodes);
				if (nodeByType != null)
				{
					return nodeByType;
				}
			}
			return null;
		}

		/// <summary>
		///       刷新显示
		///       </summary>
		public void RefreshView()
		{
			BeginUpdate();
			base.Nodes.Clear();
			Array.Sort(myTypes, new TypeNameComparer());
			if (myTypes != null && myTypes.Length > 0)
			{
				Type[] array = myTypes;
				foreach (Type type in array)
				{
					string text = type.Namespace;
					if (text == null)
					{
						text = "";
					}
					TreeNode treeNode = null;
					foreach (TreeNode node in base.Nodes)
					{
						if (node.Text == text)
						{
							treeNode = node;
							break;
						}
					}
					if (treeNode == null)
					{
						treeNode = new TreeNode(text);
						treeNode.SelectedImageIndex = 0;
						treeNode.ImageIndex = 0;
						base.Nodes.Add(treeNode);
					}
					TreeNode treeNode3 = new TreeNode(type.Name);
					treeNode3.Tag = type;
					treeNode3.ImageIndex = GetImageIndex(type);
					treeNode3.SelectedImageIndex = GetImageIndex(type);
					treeNode.Nodes.Add(treeNode3);
				}
			}
			EndUpdate();
		}

		private int GetImageIndex(Type type_0)
		{
			if (type_0.IsClass)
			{
				return 2;
			}
			if (type_0.IsEnum)
			{
				return 3;
			}
			if (type_0.IsInterface)
			{
				return 5;
			}
			if (type_0.IsSubclassOf(typeof(Delegate)))
			{
				return 4;
			}
			return 2;
		}
	}
}
