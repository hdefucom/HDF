using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档选项对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgInstanceProperties : Form
	{
		private Type type_0 = null;

		private object object_0 = null;

		private IContainer icontainer_0 = null;

		private Button btnOK;

		private Button btnCancel;

		private PropertyGrid pgGridLine;

		private Button btnLoad;

		private Button btnSave;

		/// <summary>
		///       元素类型
		///       </summary>
		public Type InstanceType
		{
			get
			{
				return type_0;
			}
			set
			{
				type_0 = value;
			}
		}

		/// <summary>
		///       是否显示打开保存按钮
		///       </summary>
		public bool ShowOpenSaveButton
		{
			get
			{
				return btnLoad.Visible;
			}
			set
			{
				btnLoad.Visible = value;
				btnSave.Visible = value;
			}
		}

		/// <summary>
		///       对象属性
		///       </summary>
		public object ObjectInstance
		{
			get
			{
				return object_0;
			}
			set
			{
				object_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInstanceProperties()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInstanceProperties_Load(object sender, EventArgs e)
		{
			pgGridLine.SelectedObject = object_0;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			int num = 12;
			if (object_0 != null)
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.CheckFileExists = true;
					openFileDialog.Filter = "*.xml|*.xml";
					if (openFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						pgGridLine.Refresh();
					}
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			int num = 17;
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.OverwritePrompt = true;
				saveFileDialog.Filter = "*.xml|*.xml";
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgInstanceProperties));
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			pgGridLine = new System.Windows.Forms.PropertyGrid();
			btnLoad = new System.Windows.Forms.Button();
			btnSave = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(pgGridLine, "pgGridLine");
			pgGridLine.Name = "pgGridLine";
			resources.ApplyResources(btnLoad, "btnLoad");
			btnLoad.Name = "btnLoad";
			btnLoad.UseVisualStyleBackColor = true;
			btnLoad.Click += new System.EventHandler(btnLoad_Click);
			resources.ApplyResources(btnSave, "btnSave");
			btnSave.Name = "btnSave";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnSave);
			base.Controls.Add(btnLoad);
			base.Controls.Add(pgGridLine);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInstanceProperties";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInstanceProperties_Load);
			ResumeLayout(false);
		}
	}
}
