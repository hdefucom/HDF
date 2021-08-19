using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	[ComVisible(false)]
	public class dlgCollectionEditor : Form
	{
		/// <summary>
		///       必需的设计器变量。
		///       </summary>
		private IContainer components = null;

		private ListBox lstCollection;

		private PropertyGrid myPropertyGrid;

		private Button cmdOK;

		private Button cmdCancel;

		private Button cmdNew;

		private Button cmdDelete;

		private Button cmdUp;

		private Button cmdDown;

		public CreateCollectionItemInstanceHandler CreateItemInstance = null;

		private string strTitle = null;

		private bool bolModified = false;

		private IList myCollectionInstance = null;

		private object objSelectedItem = null;

		private Type myItemMemberType = typeof(string);

		private string strItemNameMember = null;

		private bool bolCanMoveItem = true;

		private bool bolEnableSelectedIndexChanged = true;

		/// <summary>
		///       数据是否改变标记
		///       </summary>
		public bool Modified
		{
			get
			{
				return bolModified;
			}
			set
			{
				bolModified = value;
			}
		}

		/// <summary>
		///       列表对象实例
		///       </summary>
		public IList CollectionInstance
		{
			get
			{
				return myCollectionInstance;
			}
			set
			{
				myCollectionInstance = value;
			}
		}

		/// <summary>
		///       用户选中的列表项目
		///       </summary>
		public object SelectedItem
		{
			get
			{
				return objSelectedItem;
			}
			set
			{
				objSelectedItem = value;
			}
		}

		/// <summary>
		///       列表元素对象类型
		///       </summary>
		public Type ItemMemberType
		{
			get
			{
				return myItemMemberType;
			}
			set
			{
				myItemMemberType = value;
			}
		}

		/// <summary>
		///       作为对象名称的成员属性名称
		///       </summary>
		public string ItemNameMember
		{
			get
			{
				return strItemNameMember;
			}
			set
			{
				strItemNameMember = value;
			}
		}

		/// <summary>
		///       能否移动元素
		///       </summary>
		public bool CanMoveItem
		{
			get
			{
				return bolCanMoveItem;
			}
			set
			{
				bolCanMoveItem = value;
			}
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要
		///       使用代码编辑器修改此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.Design.dlgCollectionEditor));
			lstCollection = new System.Windows.Forms.ListBox();
			myPropertyGrid = new System.Windows.Forms.PropertyGrid();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			cmdNew = new System.Windows.Forms.Button();
			cmdDelete = new System.Windows.Forms.Button();
			cmdUp = new System.Windows.Forms.Button();
			cmdDown = new System.Windows.Forms.Button();
			SuspendLayout();
			lstCollection.AccessibleDescription = null;
			lstCollection.AccessibleName = null;
			resources.ApplyResources(lstCollection, "lstCollection");
			lstCollection.BackgroundImage = null;
			lstCollection.DisplayMember = "Name";
			lstCollection.Font = null;
			lstCollection.FormattingEnabled = true;
			lstCollection.Name = "lstCollection";
			lstCollection.SelectedIndexChanged += new System.EventHandler(lstCollection_SelectedIndexChanged);
			myPropertyGrid.AccessibleDescription = null;
			myPropertyGrid.AccessibleName = null;
			resources.ApplyResources(myPropertyGrid, "myPropertyGrid");
			myPropertyGrid.BackgroundImage = null;
			myPropertyGrid.Font = null;
			myPropertyGrid.Name = "myPropertyGrid";
			myPropertyGrid.ToolbarVisible = false;
			myPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(myPropertyGrid_PropertyValueChanged);
			cmdOK.AccessibleDescription = null;
			cmdOK.AccessibleName = null;
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.BackgroundImage = null;
			cmdOK.Font = null;
			cmdOK.Name = "cmdOK";
			cmdOK.UseVisualStyleBackColor = false;
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.AccessibleDescription = null;
			cmdCancel.AccessibleName = null;
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.BackgroundImage = null;
			cmdCancel.Font = null;
			cmdCancel.Name = "cmdCancel";
			cmdCancel.UseVisualStyleBackColor = false;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			cmdNew.AccessibleDescription = null;
			cmdNew.AccessibleName = null;
			resources.ApplyResources(cmdNew, "cmdNew");
			cmdNew.BackgroundImage = null;
			cmdNew.Font = null;
			cmdNew.Name = "cmdNew";
			cmdNew.UseVisualStyleBackColor = false;
			cmdNew.Click += new System.EventHandler(cmdNew_Click);
			cmdDelete.AccessibleDescription = null;
			cmdDelete.AccessibleName = null;
			resources.ApplyResources(cmdDelete, "cmdDelete");
			cmdDelete.BackgroundImage = null;
			cmdDelete.Font = null;
			cmdDelete.Name = "cmdDelete";
			cmdDelete.UseVisualStyleBackColor = false;
			cmdDelete.Click += new System.EventHandler(cmdDelete_Click);
			cmdUp.AccessibleDescription = null;
			cmdUp.AccessibleName = null;
			resources.ApplyResources(cmdUp, "cmdUp");
			cmdUp.BackgroundImage = null;
			cmdUp.Font = null;
			cmdUp.Name = "cmdUp";
			cmdUp.UseVisualStyleBackColor = false;
			cmdUp.Click += new System.EventHandler(cmdUp_Click);
			cmdDown.AccessibleDescription = null;
			cmdDown.AccessibleName = null;
			resources.ApplyResources(cmdDown, "cmdDown");
			cmdDown.BackgroundImage = null;
			cmdDown.Font = null;
			cmdDown.Name = "cmdDown";
			cmdDown.UseVisualStyleBackColor = false;
			cmdDown.Click += new System.EventHandler(cmdDown_Click);
			base.AccessibleDescription = null;
			base.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackgroundImage = null;
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdDown);
			base.Controls.Add(cmdDelete);
			base.Controls.Add(cmdUp);
			base.Controls.Add(cmdNew);
			base.Controls.Add(cmdOK);
			base.Controls.Add(myPropertyGrid);
			base.Controls.Add(lstCollection);
			Font = null;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = null;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgCollectionEditor";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgCollectionEditor_Load);
			ResumeLayout(false);
		}

		public dlgCollectionEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgCollectionEditor_Load(object sender, EventArgs e)
		{
			strTitle = Text;
			if (myCollectionInstance != null)
			{
				lstCollection.DisplayMember = strItemNameMember;
				foreach (object item in myCollectionInstance)
				{
					lstCollection.Items.Add(item);
				}
				if (lstCollection.Items.Count > 0)
				{
					if (objSelectedItem == null)
					{
						lstCollection.SelectedIndex = 0;
					}
					else
					{
						lstCollection.SelectedItem = objSelectedItem;
					}
				}
			}
			bolModified = false;
			cmdUp.Visible = bolCanMoveItem;
			cmdDown.Visible = bolCanMoveItem;
		}

		private void lstCollection_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bolEnableSelectedIndexChanged)
			{
				myPropertyGrid.SelectedObject = lstCollection.SelectedItem;
				cmdUp.Enabled = (lstCollection.SelectedIndex > 0);
				cmdDown.Enabled = (lstCollection.SelectedIndex < lstCollection.Items.Count - 1);
			}
		}

		private void myPropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
		{
			Text = strTitle + "*";
			bolModified = true;
			bolEnableSelectedIndexChanged = false;
			object selectedItem = lstCollection.SelectedItem;
			int selectedIndex = lstCollection.SelectedIndex;
			lstCollection.Items.RemoveAt(selectedIndex);
			lstCollection.Items.Insert(selectedIndex, selectedItem);
			lstCollection.SelectedIndex = selectedIndex;
			bolEnableSelectedIndexChanged = true;
		}

		private void cmdNew_Click(object sender, EventArgs e)
		{
			int num = 0;
			object obj = null;
			if (CreateItemInstance != null)
			{
				obj = CreateItemInstance(this, null);
				if (obj == null)
				{
					return;
				}
			}
			if (obj == null)
			{
				obj = Activator.CreateInstance(myItemMemberType);
			}
			lstCollection.GetItemText(obj);
			lstCollection.SelectedIndex = lstCollection.Items.Add(obj);
			bolModified = true;
			Text = strTitle + "*";
		}

		private void cmdDelete_Click(object sender, EventArgs e)
		{
			int num = 16;
			if (lstCollection.SelectedIndex >= 0)
			{
				lstCollection.Items.RemoveAt(lstCollection.SelectedIndex);
				bolModified = true;
				Text = strTitle + "*";
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (bolModified)
			{
				myCollectionInstance.Clear();
				foreach (object item in lstCollection.Items)
				{
					myCollectionInstance.Add(item);
				}
			}
			base.DialogResult = DialogResult.OK;
			objSelectedItem = lstCollection.SelectedItem;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cmdUp_Click(object sender, EventArgs e)
		{
			int selectedIndex = lstCollection.SelectedIndex;
			if (selectedIndex > 0)
			{
				object obj = lstCollection.Items[selectedIndex];
				lstCollection.Items.Remove(obj);
				lstCollection.Items.Insert(selectedIndex - 1, obj);
				lstCollection.SelectedIndex = selectedIndex - 1;
				bolModified = true;
			}
		}

		private void cmdDown_Click(object sender, EventArgs e)
		{
			int selectedIndex = lstCollection.SelectedIndex;
			if (selectedIndex >= 0 && selectedIndex < lstCollection.Items.Count - 1)
			{
				object obj = lstCollection.Items[selectedIndex];
				lstCollection.Items.Remove(obj);
				lstCollection.Items.Insert(selectedIndex + 1, obj);
				lstCollection.SelectedIndex = selectedIndex + 1;
				bolModified = true;
			}
		}
	}
}
