using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Design
{
	[ComVisible(false)]
	public class frmBrowseType : Form
	{
		private IContainer icontainer_0 = null;

		private TreeView tvwTypes;

		private Button btnOK;

		private Button btnCancel;

		private DCTypeLibrary dctypeLibrary_0 = DCTypeLibrary.Instance;

		private DCAssemblyInfo dcassemblyInfo_0 = null;

		private string string_0 = null;

		private DCTypeInfo dctypeInfo_0 = null;

		private TypeVisiblityFlags typeVisiblityFlags_0 = TypeVisiblityFlags.AllType;

		private GClass135 gclass135_0 = null;

		private List<DCTypeInfo> list_0 = null;

		/// <summary>
		///       类型库信息对象
		///       </summary>
		public DCTypeLibrary TypeLibrary
		{
			get
			{
				return dctypeLibrary_0;
			}
			set
			{
				dctypeLibrary_0 = value;
			}
		}

		/// <summary>
		///       程序集信息对象
		///       </summary>
		public DCAssemblyInfo AssemblyInfo
		{
			get
			{
				return dcassemblyInfo_0;
			}
			set
			{
				dcassemblyInfo_0 = value;
			}
		}

		/// <summary>
		///       被选择的类型名称
		///       </summary>
		public string SelectedTypeName
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
		///       被选择的类型信息对象
		///       </summary>
		public DCTypeInfo SelectedTypeInfo
		{
			get
			{
				return dctypeInfo_0;
			}
			set
			{
				dctypeInfo_0 = value;
			}
		}

		public bool ShowCheckbox
		{
			get
			{
				return tvwTypes.CheckBoxes;
			}
			set
			{
				tvwTypes.CheckBoxes = value;
			}
		}

		/// <summary>
		///       类型显示标记
		///       </summary>
		public TypeVisiblityFlags TypeVisibilityFlag
		{
			get
			{
				return typeVisiblityFlags_0;
			}
			set
			{
				typeVisiblityFlags_0 = value;
			}
		}

		public List<DCTypeInfo> CheckedTypes
		{
			get
			{
				return list_0;
			}
			set
			{
				list_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Design.frmBrowseType));
			tvwTypes = new System.Windows.Forms.TreeView();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(tvwTypes, "tvwTypes");
			tvwTypes.HideSelection = false;
			tvwTypes.Name = "tvwTypes";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(tvwTypes);
			base.MinimizeBox = false;
			base.Name = "frmBrowseType";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(frmBrowseType_Load);
			ResumeLayout(false);
		}

		public frmBrowseType()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void frmBrowseType_Load(object sender, EventArgs e)
		{
			int num = 14;
			gclass135_0 = new GClass135(tvwTypes);
			gclass135_0.method_18(bool_5: false);
			gclass135_0.method_16(GEnum19.const_0);
			gclass135_0.method_10(GEnum19.const_0);
			gclass135_0.method_12(GEnum19.const_0);
			gclass135_0.method_14(GEnum19.const_0);
			gclass135_0.method_29(bool_5: true);
			gclass135_0.method_8(bool_5: true);
			gclass135_0.method_2(bool_5: false);
			gclass135_0.method_20(TypeVisibilityFlag);
			if (!string.IsNullOrEmpty(SelectedTypeName) || SelectedTypeInfo != null)
			{
				gclass135_0.method_29(bool_5: false);
			}
			if (AssemblyInfo != null)
			{
				gclass135_0.method_31(AssemblyInfo);
			}
			else if (TypeLibrary != null)
			{
				gclass135_0.method_30(TypeLibrary.DomInfo);
			}
			if (tvwTypes.Nodes.Count > 0)
			{
				tvwTypes.Nodes[0].Expand();
			}
			if (!string.IsNullOrEmpty(SelectedTypeName))
			{
				string selectedTypeName = SelectedTypeName;
				int num2 = selectedTypeName.IndexOf(",");
				if (num2 > 0)
				{
					string strB = selectedTypeName.Substring(num2 + 1).Trim();
					selectedTypeName = selectedTypeName.Substring(0, num2).Trim();
					foreach (TreeNode node in tvwTypes.Nodes)
					{
						if (string.Compare(node.Text, strB, ignoreCase: true) == 0)
						{
							method_0(node.Nodes, selectedTypeName, null);
							break;
						}
					}
				}
				else
				{
					method_0(tvwTypes.Nodes, selectedTypeName, null);
				}
			}
			else if (SelectedTypeInfo != null)
			{
				method_0(tvwTypes.Nodes, null, SelectedTypeInfo);
			}
			tvwTypes.Focus();
		}

		private bool method_0(TreeNodeCollection treeNodeCollection_0, string string_1, DCTypeInfo dctypeInfo_1)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (item.Tag is DCTypeInfo)
				{
					DCTypeInfo dCTypeInfo = (DCTypeInfo)item.Tag;
					if (!string.IsNullOrEmpty(string_1) && dCTypeInfo.FullName == string_1)
					{
						tvwTypes.SelectedNode = item;
						item.EnsureVisible();
						return true;
					}
					if (dctypeInfo_1 != null && dCTypeInfo == dctypeInfo_1)
					{
						tvwTypes.SelectedNode = item;
						item.EnsureVisible();
						return true;
					}
				}
				else if (method_0(item.Nodes, string_1, dctypeInfo_1))
				{
					return true;
				}
			}
			return false;
		}

		private void method_1(object sender, EventArgs e)
		{
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (tvwTypes.CheckBoxes)
			{
				list_0 = new List<DCTypeInfo>();
				method_2(tvwTypes.Nodes);
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else if (tvwTypes.SelectedNode != null && tvwTypes.SelectedNode.Tag is DCTypeInfo)
			{
				dctypeInfo_0 = (DCTypeInfo)tvwTypes.SelectedNode.Tag;
				string_0 = dctypeInfo_0.FullName;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void method_2(TreeNodeCollection treeNodeCollection_0)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (item.Tag is DCTypeInfo)
				{
					if (item.Checked)
					{
						list_0.Add((DCTypeInfo)item.Tag);
					}
				}
				else if (item.Nodes.Count > 0)
				{
					method_2(item.Nodes);
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
