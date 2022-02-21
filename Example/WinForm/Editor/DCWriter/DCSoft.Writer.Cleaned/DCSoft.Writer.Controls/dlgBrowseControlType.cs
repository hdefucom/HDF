using DCSoft.Common;
using DCSoft.Design;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       浏览选择控件的对话框
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[ComVisible(false)]
	public class dlgBrowseControlType : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TreeView tvwControl;

		private Button cmdOK;

		private Button cmdCancel;

		private Button cmdLoadAssembly;

		private Label lblDesc;

		private string string_0 = null;

		/// <summary>
		///       用户设置的类型名称
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.dlgBrowseControlType));
			label1 = new System.Windows.Forms.Label();
			tvwControl = new System.Windows.Forms.TreeView();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			cmdLoadAssembly = new System.Windows.Forms.Button();
			lblDesc = new System.Windows.Forms.Label();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			tvwControl.HideSelection = false;
			resources.ApplyResources(tvwControl, "tvwControl");
			tvwControl.Name = "tvwControl";
			tvwControl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(tvwControl_AfterSelect);
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.UseVisualStyleBackColor = true;
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.UseVisualStyleBackColor = true;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			resources.ApplyResources(cmdLoadAssembly, "cmdLoadAssembly");
			cmdLoadAssembly.Name = "cmdLoadAssembly";
			cmdLoadAssembly.UseVisualStyleBackColor = true;
			cmdLoadAssembly.Click += new System.EventHandler(cmdLoadAssembly_Click);
			lblDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(lblDesc, "lblDesc");
			lblDesc.Name = "lblDesc";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = cmdCancel;
			base.Controls.Add(lblDesc);
			base.Controls.Add(cmdLoadAssembly);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(tvwControl);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseControlType";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgBrowseControlType_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgBrowseControlType()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgBrowseControlType_Load(object sender, EventArgs e)
		{
			ComponentTypeControler componentTypeControler = new ComponentTypeControler();
			componentTypeControler.BrowseType = ComponentTypeBrowseTypes.ForControlHost;
			componentTypeControler.FillTreeView(tvwControl, SelectedTypeName);
		}

		private void cmdLoadAssembly_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = WriterStringsCore.AssemblyFileFilter;
				openFileDialog.CheckFileExists = true;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					try
					{
						ComponentTypeControler componentTypeControler = new ComponentTypeControler();
						string text = componentTypeControler.LoadRemoteAssembly(openFileDialog.FileName);
						if (text != null)
						{
							TreeNode treeNode = componentTypeControler.AddAssemblyNode(tvwControl, text, null);
							if (treeNode != null)
							{
								tvwControl.SelectedNode = treeNode;
								treeNode.Expand();
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (tvwControl.SelectedNode != null && tvwControl.SelectedNode.Tag is ComponentTypeInfo)
			{
				ComponentTypeInfo componentTypeInfo = (ComponentTypeInfo)tvwControl.SelectedNode.Tag;
				SelectedTypeName = componentTypeInfo.FullName;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		public static void smethod_0()
		{
			using (dlgBrowseControlType dlgBrowseControlType = new dlgBrowseControlType())
			{
				if (dlgBrowseControlType.ShowDialog() == DialogResult.OK)
				{
					MessageBox.Show(dlgBrowseControlType.SelectedTypeName);
				}
			}
		}

		private void tvwControl_AfterSelect(object sender, TreeViewEventArgs e)
		{
			ComponentTypeInfo componentTypeInfo = tvwControl.SelectedNode.Tag as ComponentTypeInfo;
			if (componentTypeInfo == null)
			{
				lblDesc.Text = "";
			}
			else
			{
				lblDesc.Text = componentTypeInfo.FullName;
			}
		}
	}
}
