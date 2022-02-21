using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档选项对话框
	///       </summary>
	[ComVisible(false)]
	
	public class dlgDocumentOptions : Form
	{
		private DocumentOptions documentOptions_0 = null;

		private IContainer icontainer_0 = null;

		private Button btnOK;

		private Button btnCancel;

		private PropertyGrid myPropertyGrid;

		private Button btnLoad;

		private Button btnSave;

		private Button btnCopyPropertyName;

		private Label label1;

		private TextBox txtOptionName;

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
		///       文档选项对象
		///       </summary>
		public DocumentOptions DocumentOptions
		{
			get
			{
				return documentOptions_0;
			}
			set
			{
				documentOptions_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgDocumentOptions()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgDocumentOptions_Load(object sender, EventArgs e)
		{
			if (documentOptions_0 == null)
			{
				documentOptions_0 = new DocumentOptions();
			}
			myPropertyGrid.SelectedObject = documentOptions_0;
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
			int num = 9;
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.CheckFileExists = true;
				openFileDialog.Filter = "*.options.xml|*.options.xml";
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					if (documentOptions_0 == null)
					{
						documentOptions_0 = new DocumentOptions();
					}
					documentOptions_0.LoadLocalFile(openFileDialog.FileName);
					myPropertyGrid.SelectedObject = documentOptions_0;
					myPropertyGrid.Refresh();
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
				saveFileDialog.Filter = "*.options.xml|*.options.xml";
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					if (documentOptions_0 == null)
					{
						documentOptions_0 = new DocumentOptions();
					}
					documentOptions_0.SaveLocalFile(saveFileDialog.FileName);
				}
			}
		}

		private string method_0()
		{
			int num = 11;
			if (myPropertyGrid.SelectedGridItem != null)
			{
				GridItem gridItem = myPropertyGrid.SelectedGridItem;
				StringBuilder stringBuilder = new StringBuilder();
				while (gridItem != null && gridItem.PropertyDescriptor != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Insert(0, ".");
					}
					stringBuilder.Insert(0, gridItem.PropertyDescriptor.Name);
					gridItem = gridItem.Parent;
				}
				return stringBuilder.ToString();
			}
			return "";
		}

		private void btnCopyPropertyName_Click(object sender, EventArgs e)
		{
			string text = method_0();
			if (text.Length > 0)
			{
				Clipboard.SetText(text);
				MessageBox.Show(this, WriterStrings.AlreadCopyToClipboard + Environment.NewLine + text, WriterStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void myPropertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
		{
			txtOptionName.Text = method_0();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgDocumentOptions));
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			myPropertyGrid = new System.Windows.Forms.PropertyGrid();
			btnLoad = new System.Windows.Forms.Button();
			btnSave = new System.Windows.Forms.Button();
			btnCopyPropertyName = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			txtOptionName = new System.Windows.Forms.TextBox();
			SuspendLayout();
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(myPropertyGrid, "myPropertyGrid");
			myPropertyGrid.Name = "myPropertyGrid";
			myPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			myPropertyGrid.ToolbarVisible = false;
			myPropertyGrid.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(myPropertyGrid_SelectedGridItemChanged);
			resources.ApplyResources(btnLoad, "btnLoad");
			btnLoad.Name = "btnLoad";
			btnLoad.UseVisualStyleBackColor = true;
			btnLoad.Click += new System.EventHandler(btnLoad_Click);
			resources.ApplyResources(btnSave, "btnSave");
			btnSave.Name = "btnSave";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			resources.ApplyResources(btnCopyPropertyName, "btnCopyPropertyName");
			btnCopyPropertyName.Name = "btnCopyPropertyName";
			btnCopyPropertyName.UseVisualStyleBackColor = true;
			btnCopyPropertyName.Click += new System.EventHandler(btnCopyPropertyName_Click);
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtOptionName, "txtOptionName");
			txtOptionName.Name = "txtOptionName";
			txtOptionName.ReadOnly = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtOptionName);
			base.Controls.Add(label1);
			base.Controls.Add(btnCopyPropertyName);
			base.Controls.Add(btnSave);
			base.Controls.Add(btnLoad);
			base.Controls.Add(myPropertyGrid);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDocumentOptions";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgDocumentOptions_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
