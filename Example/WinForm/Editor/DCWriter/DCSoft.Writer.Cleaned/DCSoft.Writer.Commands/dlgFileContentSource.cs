using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Serialization;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文件来源对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgFileContentSource : Form
	{
		private WriterAppHost writerAppHost_0 = null;

		private FileContentSource fileContentSource_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private ComboBox cboFileSystem;

		private Label label2;

		private TextBox txtFileName;

		private Button btnBrowse;

		private Label label3;

		private ComboBox cboFormat;

		private Button btnOK;

		private Button btnCancel;

		private Label label4;

		private ComboBox cboTargetRange;

		/// <summary>
		///       编辑器宿主
		///       </summary>
		public WriterAppHost AppHost
		{
			get
			{
				return writerAppHost_0;
			}
			set
			{
				writerAppHost_0 = value;
			}
		}

		/// <summary>
		///       文件来源信息
		///       </summary>
		public FileContentSource ContentSource
		{
			get
			{
				return fileContentSource_0;
			}
			set
			{
				fileContentSource_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgFileContentSource()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgFileContentSource_Load(object sender, EventArgs e)
		{
			if (AppHost != null)
			{
				foreach (string key in AppHost.FileSystems.Keys)
				{
					cboFileSystem.Items.Add(key);
				}
				foreach (ContentSerializer contentSerializer in AppHost.ContentSerializers)
				{
					cboFormat.Items.Add(contentSerializer.Name);
				}
			}
			if (ContentSource != null)
			{
				cboFileSystem.Text = ContentSource.FileSystemName;
				txtFileName.Text = ContentSource.FileName;
				cboFormat.Text = ContentSource.Format;
				cboTargetRange.Text = ContentSource.Range;
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (AppHost != null)
			{
				string string_ = null;
				string text = WriterControl.smethod_0(this, AppHost, txtFileName.Text, ref string_, cboFileSystem.Text);
				if (text != null)
				{
					txtFileName.Text = text;
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			fileContentSource_0 = new FileContentSource();
			fileContentSource_0.FileSystemName = cboFileSystem.Text;
			fileContentSource_0.FileName = txtFileName.Text;
			fileContentSource_0.Format = cboFormat.Text;
			fileContentSource_0.Range = cboTargetRange.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgFileContentSource));
			label1 = new System.Windows.Forms.Label();
			cboFileSystem = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			txtFileName = new System.Windows.Forms.TextBox();
			btnBrowse = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			cboFormat = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			cboTargetRange = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			cboFileSystem.FormattingEnabled = true;
			resources.ApplyResources(cboFileSystem, "cboFileSystem");
			cboFileSystem.Name = "cboFileSystem";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtFileName, "txtFileName");
			txtFileName.Name = "txtFileName";
			resources.ApplyResources(btnBrowse, "btnBrowse");
			btnBrowse.Name = "btnBrowse";
			btnBrowse.UseVisualStyleBackColor = true;
			btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboFormat.FormattingEnabled = true;
			resources.ApplyResources(cboFormat, "cboFormat");
			cboFormat.Name = "cboFormat";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			cboTargetRange.FormattingEnabled = true;
			cboTargetRange.Items.AddRange(new object[3]
			{
				resources.GetString("cboTargetRange.Items"),
				resources.GetString("cboTargetRange.Items1"),
				resources.GetString("cboTargetRange.Items2")
			});
			resources.ApplyResources(cboTargetRange, "cboTargetRange");
			cboTargetRange.Name = "cboTargetRange";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboTargetRange);
			base.Controls.Add(label4);
			base.Controls.Add(cboFormat);
			base.Controls.Add(label3);
			base.Controls.Add(btnBrowse);
			base.Controls.Add(txtFileName);
			base.Controls.Add(label2);
			base.Controls.Add(cboFileSystem);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFileContentSource";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgFileContentSource_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
