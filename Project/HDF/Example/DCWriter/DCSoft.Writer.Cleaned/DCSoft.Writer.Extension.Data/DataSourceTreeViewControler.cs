using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>
	///       数据源树状列表控制器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DCPublishAPI]
	public class DataSourceTreeViewControler
	{
		private struct POINT
		{
			public int int_0;

			public int int_1;
		}

		private TreeView _TreeView = null;

		private TreeNode _RootNode = null;

		/// <summary>
		///       数据源根节点对象
		///       </summary>
		public TreeNode RootNode
		{
			get
			{
				return _RootNode;
			}
			set
			{
				_RootNode = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DataSourceTreeViewControler(TreeView treeView_0)
		{
			_TreeView = treeView_0;
		}

		/// <summary>
		///       从文件加载对象数据
		///       </summary>
		/// <param name="fileName">
		/// </param>
		/// <returns>
		/// </returns>
		public bool LoadFile(string fileName)
		{
			int num = 1;
			if (File.Exists(fileName))
			{
				DataSourceDescriptor dataSourceDescriptor = new DataSourceDescriptor();
				dataSourceDescriptor.Load(fileName);
				_TreeView.Nodes.Clear();
				_TreeView.Nodes.Add(new TreeNode("数据源"));
				RootNode = _TreeView.Nodes[0];
				Fill(RootNode, dataSourceDescriptor);
				RootNode.ExpandAll();
				return true;
			}
			return false;
		}

		/// <summary>
		///       从数据流加载对象数据
		///       </summary>
		/// <param name="stream">
		/// </param>
		/// <returns>
		/// </returns>
		public bool LoadFile(Stream stream)
		{
			int num = 1;
			if (stream != null)
			{
				DataSourceDescriptor dataSourceDescriptor = new DataSourceDescriptor();
				dataSourceDescriptor.Load(stream);
				_TreeView.Nodes.Clear();
				_TreeView.Nodes.Add(new TreeNode("数据源"));
				RootNode = _TreeView.Nodes[0];
				Fill(RootNode, dataSourceDescriptor);
				RootNode.ExpandAll();
				return true;
			}
			return false;
		}

		/// <summary>
		///       填充树状列表的节点
		///       </summary>
		/// <param name="rootNode">根节点</param>
		/// <param name="dsd">数据源对象</param>
		private void Fill(TreeNode rootNode, DataSourceDescriptor dataSourceDescriptor_0)
		{
			int num = 6;
			if (rootNode == null)
			{
				throw new ArgumentNullException("rootNode");
			}
			if (string.IsNullOrEmpty(dataSourceDescriptor_0.Description))
			{
				rootNode.Text = dataSourceDescriptor_0.Name;
			}
			else
			{
				rootNode.Text = dataSourceDescriptor_0.Name + "[" + dataSourceDescriptor_0.Description + "]";
			}
			rootNode.Tag = dataSourceDescriptor_0;
			foreach (DataSourceDescriptor childDescriptor in dataSourceDescriptor_0.ChildDescriptors)
			{
				TreeNode treeNode = new TreeNode();
				Fill(treeNode, childDescriptor);
				rootNode.Nodes.Add(treeNode);
			}
		}

		/// <summary>
		///       处理数据源树状列表鼠标按键按下事件
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		public void HandleTreeViewMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			TreeViewHitTestInfo treeViewHitTestInfo = _TreeView.HitTest(e.X, e.Y);
			if (treeViewHitTestInfo != null && treeViewHitTestInfo.Node != null && (treeViewHitTestInfo.Location == TreeViewHitTestLocations.Image || treeViewHitTestInfo.Location == TreeViewHitTestLocations.Label))
			{
				_TreeView.SelectedNode = treeViewHitTestInfo.Node;
				if (DragDetect(_TreeView.Handle))
				{
					DataObject data = new DataObject(treeViewHitTestInfo.Node.Tag);
					_TreeView.DoDragDrop(data, DragDropEffects.Copy);
				}
			}
		}

		/// <summary>
		///       处理编辑器控件的能否插入对象事件
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="args">
		/// </param>
		public void HandleCanInsertObjectEvent(WriterControl writerControl_0, CanInsertObjectEventArgs args)
		{
			int num = 11;
			if (args.Handled)
			{
				return;
			}
			string[] formats = args.DataObject.GetFormats();
			int num2 = 0;
			while (true)
			{
				if (num2 < formats.Length)
				{
					string text = formats[num2];
					if (text.IndexOf("DataSourceDescriptor") >= 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			args.Result = args.DocumentControler.CanInsertElementAtCurrentPosition(typeof(XTextInputFieldElement));
			args.Handled = true;
		}

		/// <summary>
		///       处理编辑器控件插入对象事件
		///       </summary>
		/// <param name="ctl">
		/// </param>
		/// <param name="args">
		/// </param>
		public void HandleInsertObjectEvent(WriterControl writerControl_0, InsertObjectEventArgs args)
		{
			int num = 12;
			if (args.Handled)
			{
				return;
			}
			string[] formats = args.DataObject.GetFormats();
			int num2 = 0;
			DataSourceDescriptor dataSourceDescriptor;
			while (true)
			{
				if (num2 >= formats.Length)
				{
					return;
				}
				string text = formats[num2];
				if (text.IndexOf("DataSourceDescriptor") >= 0)
				{
					dataSourceDescriptor = (args.DataObject.GetData(text) as DataSourceDescriptor);
					if (dataSourceDescriptor != null)
					{
						break;
					}
				}
				num2++;
			}
			if (dataSourceDescriptor.ElementType == DocumentElementType.InputField)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)args.Document.CreateElementByType(typeof(XTextInputFieldElement));
				xTextInputFieldElement.BackgroundText = dataSourceDescriptor.BackgroundText;
				xTextInputFieldElement.Name = dataSourceDescriptor.Name;
				xTextInputFieldElement.AcceptChildElementTypes2 = ElementType.Text;
				xTextInputFieldElement.ToolTip = dataSourceDescriptor.Description;
				xTextInputFieldElement.ContentReadonly = ((!dataSourceDescriptor.Readonly) ? ContentReadonlyState.Inherit : ContentReadonlyState.True);
				xTextInputFieldElement.ValueBinding = dataSourceDescriptor.ValueBinding.Clone();
				xTextInputFieldElement.DisplayFormat = dataSourceDescriptor.DisplayFormat;
				xTextInputFieldElement.FieldSettings = new InputFieldSettings();
				xTextInputFieldElement.FieldSettings.EditStyle = dataSourceDescriptor.EditStyle;
				xTextInputFieldElement.FieldSettings.ListSource = dataSourceDescriptor.ListSource;
				xTextInputFieldElement.ValidateStyle = dataSourceDescriptor.ValidateStyle;
				xTextInputFieldElement.UserEditable = dataSourceDescriptor.UserEditable;
				writerControl_0.ExecuteCommand("InsertInputField", showUI: false, xTextInputFieldElement);
				args.Handled = true;
				args.Result = true;
			}
			else
			{
				if (dataSourceDescriptor.ElementType != DocumentElementType.CheckBox && dataSourceDescriptor.ElementType != DocumentElementType.RadioBox)
				{
					return;
				}
				XTextElementList xTextElementList = new XTextElementList();
				XTextCheckBoxElementBase xTextCheckBoxElementBase = null;
				xTextCheckBoxElementBase = ((dataSourceDescriptor.ElementType != DocumentElementType.CheckBox) ? ((XTextCheckBoxElementBase)(XTextRadioBoxElement)args.Document.CreateElementByType(typeof(XTextRadioBoxElement))) : ((XTextCheckBoxElementBase)(XTextCheckBoxElement)args.Document.CreateElementByType(typeof(XTextCheckBoxElement))));
				xTextCheckBoxElementBase.Name = dataSourceDescriptor.Name;
				xTextCheckBoxElementBase.ToolTip = dataSourceDescriptor.Description;
				xTextCheckBoxElementBase.Readonly = dataSourceDescriptor.Readonly;
				xTextCheckBoxElementBase.ValueBinding = dataSourceDescriptor.ValueBinding.Clone();
				xTextElementList.Add(xTextCheckBoxElementBase);
				string text2 = dataSourceDescriptor.Description;
				if (!string.IsNullOrEmpty(text2))
				{
					text2 = dataSourceDescriptor.Name;
				}
				if (!string.IsNullOrEmpty(text2))
				{
					XTextElementList xTextElementList2 = args.Document.CreateTextElements(text2, null, args.Document.CurrentStyleInfo.ContentStyleForNewString);
					if (xTextElementList2 != null)
					{
						xTextElementList.AddRange(xTextElementList2);
					}
				}
				int num3 = (int)writerControl_0.ExecuteCommand("InsertElements", showUI: false, xTextElementList);
				if (num3 > 0)
				{
					args.Result = true;
				}
				args.Handled = true;
			}
		}

		/// <summary>
		///       根据编辑控件的当前位置设置数据源树状列表的当前节点
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		public void UpdateCurrentDataSourceNode(WriterControl writerControl_0)
		{
			if (writerControl_0 == null || writerControl_0.DragState != 0)
			{
				return;
			}
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)writerControl_0.GetCurrentElement(typeof(XTextInputFieldElement));
			if (xTextInputFieldElement != null && xTextInputFieldElement.ValueBinding != null && !string.IsNullOrEmpty(xTextInputFieldElement.ValueBinding.DataSource) && !string.IsNullOrEmpty(xTextInputFieldElement.ValueBinding.BindingPath))
			{
				TreeNode treeNode = DeeplySearch(RootNode, xTextInputFieldElement.ValueBinding.DataSource, xTextInputFieldElement.ValueBinding.BindingPath);
				if (treeNode != null)
				{
					_TreeView.SelectedNode = treeNode;
				}
			}
		}

		private TreeNode DeeplySearch(TreeNode rootNode, string dsName, string dsPath)
		{
			if (rootNode != null)
			{
				foreach (TreeNode node in rootNode.Nodes)
				{
					if (node.Tag is DataSourceDescriptor)
					{
						DataSourceDescriptor dataSourceDescriptor = (DataSourceDescriptor)node.Tag;
						if (dataSourceDescriptor.ValueBinding != null && dataSourceDescriptor.ValueBinding.DataSource == dsName && dataSourceDescriptor.ValueBinding.BindingPath == dsPath)
						{
							return node;
						}
					}
					if (node.Nodes.Count > 0)
					{
						TreeNode treeNode2 = DeeplySearch(node, dsName, dsPath);
						if (treeNode2 != null)
						{
							return treeNode2;
						}
					}
				}
				return null;
			}
			return null;
		}

		/// <summary>
		///       检测鼠标是否开始执行了拖拽操作
		///       </summary>
		/// <param name="hwnd">
		/// </param>
		/// <returns>是否开始进行了鼠标拖拽操作</returns>
		private static bool DragDetect(IntPtr hwnd)
		{
			POINT point_ = default(POINT);
			point_.int_0 = Control.MousePosition.X;
			point_.int_1 = Control.MousePosition.Y;
			return DragDetect(hwnd, point_);
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool DragDetect(IntPtr hWnd, POINT point_0);
	}
}
