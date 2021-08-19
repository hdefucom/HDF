using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DCSoft.Design.Data
{
	/// <summary>
	///       显示数据库结构的树状列表
	///       </summary>
	/// <remarks>
	///       本树状列表在类型 DataBaseInfo 的支持下,用于显示数据结构信息.
	///       并能分析 MS ACCESS 2000 , ORACLE , MS SQL SERVER的数据库结构,还能加载
	///       并显示PDM文件中的数据库结构信息.
	///       编制 袁永福
	///       </remarks>
	[ToolboxItem(false)]
	[ComVisible(false)]
	[ToolboxBitmap(typeof(DataBaseSchemaTreeView))]
	public class DataBaseSchemaTreeView : TreeView
	{
		private DataBaseSchema myDataBaseSchema = DataBaseSchema.Instance;

		private IWindowsFormsEditorService myEditorService = null;

		private bool bolDirectDragObject = false;

		private bool bolUserSelected = false;

		/// <summary>
		///       数据库信息对象
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DataBaseSchema DataBaseSchema
		{
			get
			{
				return myDataBaseSchema;
			}
			set
			{
				myDataBaseSchema = value;
			}
		}

		/// <summary>
		///       设计器窗体服务对象
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IWindowsFormsEditorService EditorService
		{
			get
			{
				return myEditorService;
			}
			set
			{
				myEditorService = value;
			}
		}

		/// <summary>
		///       拖拽时直接拖拽对象数据
		///       </summary>
		[DefaultValue(false)]
		public bool DirectDragObject
		{
			get
			{
				return bolDirectDragObject;
			}
			set
			{
				bolDirectDragObject = value;
			}
		}

		/// <summary>
		///       用户执行了选择操作
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool UserSelected
		{
			get
			{
				return bolUserSelected;
			}
			set
			{
				bolUserSelected = value;
			}
		}

		/// <summary>
		///       当前路径
		///       </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SelectedPath
		{
			get
			{
				int num = 14;
				if (base.SelectedNode != null)
				{
					if (base.SelectedNode.Tag is DataBaseSchemaTable)
					{
						return ((DataBaseSchemaTable)base.SelectedNode.Tag).Name;
					}
					if (base.SelectedNode.Tag is DataBaseSchemaField)
					{
						DataBaseSchemaField dataBaseSchemaField = (DataBaseSchemaField)base.SelectedNode.Tag;
						DataBaseSchemaTable dataBaseSchemaTable = (DataBaseSchemaTable)base.SelectedNode.Parent.Tag;
						return dataBaseSchemaTable.Name + "." + dataBaseSchemaField.Name;
					}
				}
				return "";
			}
			set
			{
				TreeNode node = GetNode(value);
				if (node == null)
				{
					if (base.Nodes.Count > 0)
					{
						base.SelectedNode = base.Nodes[0];
					}
				}
				else
				{
					base.SelectedNode = node;
				}
			}
		}

		/// <summary>
		///       当前选择的数据表名称
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string CurrentTableName
		{
			get
			{
				TreeNode selectedNode = base.SelectedNode;
				if (selectedNode == null)
				{
					return null;
				}
				if (selectedNode.Tag is DataBaseSchemaTable)
				{
					return ((DataBaseSchemaTable)selectedNode.Tag).Name;
				}
				if (selectedNode.Tag is DataBaseSchemaField)
				{
					selectedNode = selectedNode.Parent;
					return ((DataBaseSchemaTable)selectedNode.Tag).Name;
				}
				return null;
			}
			set
			{
				TreeNode node = GetNode(value, null);
				if (node != null)
				{
					base.SelectedNode = node;
				}
			}
		}

		/// <summary>
		///       当前选择的数据字段名称
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string CurrentFieldName
		{
			get
			{
				if (base.SelectedNode != null)
				{
					DataBaseSchemaField dataBaseSchemaField = base.SelectedNode.Tag as DataBaseSchemaField;
					if (dataBaseSchemaField != null)
					{
						return dataBaseSchemaField.Name;
					}
				}
				return null;
			}
			set
			{
				TreeNode node = GetNode(value);
				if (node != null)
				{
					base.SelectedNode = node;
				}
			}
		}

		/// <summary>
		///       当前选择的数据字段对象
		///       </summary>
		[Browsable(false)]
		public DataBaseSchemaField CurrentField
		{
			get
			{
				if (base.SelectedNode != null)
				{
					return base.SelectedNode.Tag as DataBaseSchemaField;
				}
				return null;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DataBaseSchemaTreeView()
		{
			base.HideSelection = false;
			base.ImageList = GClass136.smethod_0();
		}

		/// <summary>
		///       鼠标双击事件处理
		///       </summary>
		/// <param name="e">参数</param>
		protected override void OnDoubleClick(EventArgs eventArgs_0)
		{
			base.OnDoubleClick(eventArgs_0);
			if (EditorService != null)
			{
				if (base.SelectedNode != null)
				{
					bolUserSelected = true;
				}
				EditorService.CloseDropDown();
			}
		}

		/// <summary>
		///       获得指定名称的节点对象
		///       </summary>
		/// <param name="FullName">全路径名称,可以是表名或 表名.字段名</param>
		/// <returns>找到的节点对象</returns>
		public TreeNode GetNode(string FullName)
		{
			int num = 15;
			if (FullName == null)
			{
				return null;
			}
			int num2 = FullName.IndexOf(".");
			if (num2 > 0)
			{
				string tableName = FullName.Substring(0, num2).Trim();
				string fieldName = FullName.Substring(num2 + 1).Trim();
				return GetNode(tableName, fieldName);
			}
			return GetNode(FullName, null);
		}

		/// <summary>
		///       获得指定表名和字段名的节点对象
		///       </summary>
		/// <param name="TableName">表名</param>
		/// <param name="FieldName">字段名</param>
		/// <returns>获得的节点对象</returns>
		public TreeNode GetNode(string TableName, string FieldName)
		{
			if (TableName == null)
			{
				return null;
			}
			if (base.Nodes.Count == 0)
			{
				return null;
			}
			foreach (TreeNode node in base.Nodes[0].Nodes)
			{
				DataBaseSchemaTable dataBaseSchemaTable = (DataBaseSchemaTable)node.Tag;
				if (string.Compare(dataBaseSchemaTable.Name, TableName, ignoreCase: true) == 0)
				{
					if (FieldName == null || FieldName.Length == 0)
					{
						return node;
					}
					foreach (TreeNode node2 in node.Nodes)
					{
						DataBaseSchemaField dataBaseSchemaField = (DataBaseSchemaField)node2.Tag;
						if (string.Compare(dataBaseSchemaField.Name, FieldName, ignoreCase: true) == 0)
						{
							return node2;
						}
					}
					return node;
				}
			}
			return null;
		}

		/// <summary>
		///       设置当前选中的元素
		///       </summary>
		/// <param name="FieldName">字段全名,格式为 表名.字段名 </param>
		/// <returns>是否选择了节点</returns>
		public bool SetSelection(string FieldName)
		{
			int num = 3;
			if (FieldName == null)
			{
				return false;
			}
			int num2 = FieldName.IndexOf(".");
			if (num2 > 0)
			{
				return SetSelection(FieldName.Substring(0, num2), FieldName.Substring(num2 + 1));
			}
			return false;
		}

		/// <summary>
		///       设置当前选中的元素
		///       </summary>
		/// <param name="TableName">数据表名</param>
		/// <param name="FieldName">数据字段名</param>
		/// <returns>是否选择的节点</returns>
		public bool SetSelection(string TableName, string FieldName)
		{
			TreeNode node = GetNode(TableName, FieldName);
			if (node != null)
			{
				base.SelectedNode = node;
				node.EnsureVisible();
				return true;
			}
			return false;
		}

		/// <summary>
		///       处理节点向外拖拽事件
		///       </summary>
		/// <param name="e">事件参数</param>
		protected override void OnItemDrag(ItemDragEventArgs itemDragEventArgs_0)
		{
			base.OnItemDrag(itemDragEventArgs_0);
			TreeNode treeNode = itemDragEventArgs_0.Item as TreeNode;
			if (treeNode != null && treeNode.TreeView == this)
			{
				base.SelectedNode = treeNode;
				object dragData = GetDragData(treeNode);
				if (dragData != null)
				{
					DataObject data = new DataObject(dragData);
					DoDragDrop(data, DragDropEffects.All);
				}
			}
		}

		/// <summary>
		///       获得要拖拽的数据
		///       </summary>
		/// <param name="node">要拖拽的节点</param>
		/// <returns>要拖拽的数据</returns>
		protected virtual object GetDragData(TreeNode node)
		{
			return node.Tag;
		}

		/// <summary>
		///       根据数据库结构刷新控件内容
		///       </summary>
		public void RefreshView()
		{
			int num = 9;
			BeginUpdate();
			base.Nodes.Clear();
			base.Nodes.Add(DesignStrings.Loading);
			EndUpdate();
			Refresh();
			Update();
			BeginUpdate();
			base.Nodes.Clear();
			if (myDataBaseSchema == null)
			{
				EndUpdate();
				return;
			}
			string text = myDataBaseSchema.Name;
			if (!HasContent(text))
			{
				text = DesignStrings.DataBaseSchema;
			}
			text += string.Format(DesignStrings.Total_Tables_Fields, myDataBaseSchema.Tables.Count, myDataBaseSchema.FieldCount);
			TreeNode treeNode = new TreeNode(text);
			treeNode.ImageIndex = GClass136.smethod_1(myDataBaseSchema);
			treeNode.SelectedImageIndex = treeNode.ImageIndex;
			treeNode.Tag = myDataBaseSchema;
			base.Nodes.Add(treeNode);
			foreach (DataBaseSchemaTable table in myDataBaseSchema.Tables)
			{
				text = ((!HasContent(table.Remark)) ? table.Name : (table.Name + "(" + table.Remark + ")"));
				TreeNode treeNode2 = new TreeNode(text);
				treeNode2.ImageIndex = GClass136.smethod_1(table);
				treeNode2.SelectedImageIndex = treeNode2.ImageIndex;
				treeNode2.Tag = table;
				treeNode.Nodes.Add(treeNode2);
				foreach (DataBaseSchemaField field in table.Fields)
				{
					text = ((!HasContent(field.Remark)) ? field.Name : (field.Name + "(" + field.Remark + ")"));
					TreeNode treeNode3 = new TreeNode(text);
					treeNode3.ImageIndex = GClass136.smethod_1(field);
					treeNode3.SelectedImageIndex = treeNode3.ImageIndex;
					treeNode3.Tag = field;
					treeNode2.Nodes.Add(treeNode3);
				}
			}
			treeNode.Expand();
			base.SelectedNode = treeNode;
			EndUpdate();
		}

		/// <summary>
		///       从一个PDM文件加载数据库结构并显示出来
		///       </summary>
		/// <param name="strFileName">PDM文件名</param>
		/// <remarks>此处的PDM文件是 PowerDesigner 生成的PDM文件</remarks>
		public void LoadPDMFile(string strFileName)
		{
			if (File.Exists(strFileName))
			{
				myDataBaseSchema.LoadFromPDMXMLFile(strFileName);
				RefreshView();
			}
		}

		public void LoadAssemblyFile(string strFileName)
		{
			if (File.Exists(strFileName))
			{
				myDataBaseSchema.LoadFromAssembly(strFileName);
				RefreshView();
			}
		}

		/// <summary>
		///       分析一个数据库结构,并显示其结构
		///       </summary>
		/// <param name="conn">数据库连接对象</param>
		/// <returns>操作是否成功</returns>
		public bool LoadConnection(IDbConnection conn)
		{
			bool result = false;
			if (GClass317.smethod_6(conn))
			{
				myDataBaseSchema.LoadFromOracle(conn);
				result = true;
			}
			else if (conn is SqlConnection)
			{
				myDataBaseSchema.LoadFromDB(conn as SqlConnection);
			}
			else if (conn is OleDbConnection)
			{
				myDataBaseSchema.LoadFromDB(conn as OleDbConnection);
			}
			else
			{
				if (!(conn is OdbcConnection))
				{
					return false;
				}
				myDataBaseSchema.LoadFromDB(conn as OdbcConnection);
			}
			RefreshView();
			return result;
		}

		private bool HasContent(string string_0)
		{
			return string_0 != null && string_0.Trim().Length > 0;
		}
	}
}
