using DCSoft.Design;
using DCSoft.Writer.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       插入图形
	///       </summary>
	[ComVisible(false)]
	public class dlgInsertShape : Form
	{
		private string string_0 = null;

		private IContainer icontainer_0 = null;

		private ListView lvwShape;

		private Button btnOK;

		private Button btnCancel;

		private CheckBox chkIsDbClick;

		/// <summary>
		///       用户选择的图形对象类型全名
		///       </summary>
		public string SelectedShapeTypeFullName
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInsertShape()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInsertShape_Load(object sender, EventArgs e)
		{
			int num = 5;
			List<ComponentTypeInfo> list = new List<ComponentTypeInfo>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly assembly_ in assemblies)
			{
				HostComponentTypeInfoLoader hostComponentTypeInfoLoader = new HostComponentTypeInfoLoader();
				hostComponentTypeInfoLoader.SupportDocumentImage = true;
				hostComponentTypeInfoLoader.SupportWinFormControl = false;
				hostComponentTypeInfoLoader.SupportWPF = false;
				try
				{
					ComponentTypeInfo[] array = hostComponentTypeInfoLoader.Load(assembly_);
					if (array != null && array.Length > 0)
					{
						list.AddRange(array);
					}
				}
				catch (Exception)
				{
				}
			}
			if (list.Count > 0)
			{
				ImageList imageList = new ImageList();
				foreach (ComponentTypeInfo item in list)
				{
					if (item.ToolboxImage != null)
					{
						imageList.Images.Add(item.FullName, item.ToolboxImage);
					}
				}
				lvwShape.SmallImageList = imageList;
				lvwShape.Items.Clear();
				foreach (ComponentTypeInfo item2 in list)
				{
					string name = item2.Name;
					if (!name.EndsWith("DocumentImage"))
					{
					}
					name = " ";
					ListViewItem listViewItem = new ListViewItem(name);
					listViewItem.Tag = item2;
					listViewItem.ImageKey = item2.FullName;
					lvwShape.Items.Add(listViewItem);
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lvwShape.SelectedItems.Count == 1)
			{
				ComponentTypeInfo componentTypeInfo = (ComponentTypeInfo)lvwShape.SelectedItems[0].Tag;
				SelectedShapeTypeFullName = componentTypeInfo.FullName;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void lvwShape_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (chkIsDbClick.Checked && lvwShape.SelectedItems.Count == 1)
			{
				ComponentTypeInfo componentTypeInfo = (ComponentTypeInfo)lvwShape.SelectedItems[0].Tag;
				SelectedShapeTypeFullName = componentTypeInfo.FullName;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgInsertShape));
			lvwShape = new System.Windows.Forms.ListView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkIsDbClick = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			resources.ApplyResources(lvwShape, "lvwShape");
			lvwShape.HideSelection = false;
			lvwShape.MultiSelect = false;
			lvwShape.Name = "lvwShape";
			lvwShape.UseCompatibleStateImageBehavior = false;
			lvwShape.View = System.Windows.Forms.View.List;
			lvwShape.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(lvwShape_MouseDoubleClick);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(chkIsDbClick, "chkIsDbClick");
			chkIsDbClick.Name = "chkIsDbClick";
			chkIsDbClick.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(chkIsDbClick);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lvwShape);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInsertShape";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInsertShape_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
