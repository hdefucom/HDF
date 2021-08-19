using DCSoft.Writer.Extension.Data;
using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       文件格式转换
	///       </summary>
	[ComVisible(false)]
	public class dlgFileFormatConvert : Form
	{
		private IContainer icontainer_0 = null;

		private GroupBox gbSource;

		private ComboBox cboSourceFormat;

		private Label label2;

		private CheckBox chkRecursion;

		private Button btnSourceDirectory;

		private TextBox txtSourceDirectory;

		private Label label1;

		private GroupBox gbDest;

		private ComboBox cboDestFormat;

		private Label label3;

		private Button btnBrowseDestDirectory;

		private TextBox txtDestDirectory;

		private Label label4;

		private Button btnRun;

		private Label lblProgress;

		private Button btnCancelTask;

		private GroupBox gbProgress;

		private ProgressBar myProgressbar;

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgFileFormatConvert()
		{
			InitializeComponent();
		}

		private void dlgFileFormatConvert_Load(object sender, EventArgs e)
		{
			foreach (ContentSerializer contentSerializer in WriterAppHost.Default.ContentSerializers)
			{
				cboDestFormat.Items.Add(contentSerializer.Name);
				cboSourceFormat.Items.Add(contentSerializer.Name);
			}
		}

		private void btnSourceDirectory_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.SelectedPath = txtSourceDirectory.Text;
				folderBrowserDialog.ShowNewFolderButton = false;
				folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
				if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
				{
					txtSourceDirectory.Text = folderBrowserDialog.SelectedPath;
				}
			}
		}

		private void btnBrowseDestDirectory_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.SelectedPath = txtDestDirectory.Text;
				folderBrowserDialog.ShowNewFolderButton = true;
				folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
				if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
				{
					txtDestDirectory.Text = folderBrowserDialog.SelectedPath;
				}
			}
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			int num = 11;
			ContentSerializer serializer = WriterAppHost.Default.ContentSerializers.GetSerializer(cboSourceFormat.Text);
			ContentSerializer serializer2 = WriterAppHost.Default.ContentSerializers.GetSerializer(cboDestFormat.Text);
			DocumentFormatConverter documentFormatConverter = new DocumentFormatConverter();
			DocumentFormatConverter.CreateTasks(txtSourceDirectory.Text, "*" + serializer.FileExtension, serializer.Name, txtDestDirectory.Text, serializer2.Name, chkRecursion.Checked, documentFormatConverter.Tasks);
			if (documentFormatConverter.Tasks.Count > 0)
			{
				gbSource.Enabled = false;
				gbDest.Enabled = false;
				btnRun.Visible = false;
				gbProgress.Visible = true;
				myProgressbar.Maximum = documentFormatConverter.Tasks.Count;
				Update();
				try
				{
					documentFormatConverter.ProgressChanged += method_0;
					int num2 = documentFormatConverter.Run();
					MessageBox.Show("共转换了" + num2 + "个文件!");
				}
				finally
				{
					gbSource.Enabled = true;
					gbDest.Enabled = true;
					btnRun.Visible = true;
					gbProgress.Visible = false;
				}
			}
		}

		private void method_0(object sender, ProgressChangedEventArgs e)
		{
			GClass25 gClass = (GClass25)e.UserState;
			lblProgress.Text = Path.GetFileName(gClass.method_0());
			myProgressbar.Value = e.ProgressPercentage;
			lblProgress.Update();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgFileFormatConvert));
			gbSource = new System.Windows.Forms.GroupBox();
			cboSourceFormat = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			chkRecursion = new System.Windows.Forms.CheckBox();
			btnSourceDirectory = new System.Windows.Forms.Button();
			txtSourceDirectory = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			gbDest = new System.Windows.Forms.GroupBox();
			cboDestFormat = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			btnBrowseDestDirectory = new System.Windows.Forms.Button();
			txtDestDirectory = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			btnRun = new System.Windows.Forms.Button();
			lblProgress = new System.Windows.Forms.Label();
			btnCancelTask = new System.Windows.Forms.Button();
			gbProgress = new System.Windows.Forms.GroupBox();
			myProgressbar = new System.Windows.Forms.ProgressBar();
			gbSource.SuspendLayout();
			gbDest.SuspendLayout();
			gbProgress.SuspendLayout();
			SuspendLayout();
			gbSource.Controls.Add(cboSourceFormat);
			gbSource.Controls.Add(label2);
			gbSource.Controls.Add(chkRecursion);
			gbSource.Controls.Add(btnSourceDirectory);
			gbSource.Controls.Add(txtSourceDirectory);
			gbSource.Controls.Add(label1);
			resources.ApplyResources(gbSource, "gbSource");
			gbSource.Name = "gbSource";
			gbSource.TabStop = false;
			cboSourceFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboSourceFormat.FormattingEnabled = true;
			resources.ApplyResources(cboSourceFormat, "cboSourceFormat");
			cboSourceFormat.Name = "cboSourceFormat";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(chkRecursion, "chkRecursion");
			chkRecursion.Name = "chkRecursion";
			chkRecursion.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnSourceDirectory, "btnSourceDirectory");
			btnSourceDirectory.Name = "btnSourceDirectory";
			btnSourceDirectory.UseVisualStyleBackColor = true;
			btnSourceDirectory.Click += new System.EventHandler(btnSourceDirectory_Click);
			resources.ApplyResources(txtSourceDirectory, "txtSourceDirectory");
			txtSourceDirectory.Name = "txtSourceDirectory";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			gbDest.Controls.Add(cboDestFormat);
			gbDest.Controls.Add(label3);
			gbDest.Controls.Add(btnBrowseDestDirectory);
			gbDest.Controls.Add(txtDestDirectory);
			gbDest.Controls.Add(label4);
			resources.ApplyResources(gbDest, "gbDest");
			gbDest.Name = "gbDest";
			gbDest.TabStop = false;
			cboDestFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboDestFormat.FormattingEnabled = true;
			resources.ApplyResources(cboDestFormat, "cboDestFormat");
			cboDestFormat.Name = "cboDestFormat";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(btnBrowseDestDirectory, "btnBrowseDestDirectory");
			btnBrowseDestDirectory.Name = "btnBrowseDestDirectory";
			btnBrowseDestDirectory.UseVisualStyleBackColor = true;
			btnBrowseDestDirectory.Click += new System.EventHandler(btnBrowseDestDirectory_Click);
			resources.ApplyResources(txtDestDirectory, "txtDestDirectory");
			txtDestDirectory.Name = "txtDestDirectory";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(btnRun, "btnRun");
			btnRun.Name = "btnRun";
			btnRun.UseVisualStyleBackColor = true;
			btnRun.Click += new System.EventHandler(btnRun_Click);
			lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(lblProgress, "lblProgress");
			lblProgress.Name = "lblProgress";
			resources.ApplyResources(btnCancelTask, "btnCancelTask");
			btnCancelTask.Name = "btnCancelTask";
			btnCancelTask.UseVisualStyleBackColor = true;
			gbProgress.Controls.Add(myProgressbar);
			gbProgress.Controls.Add(btnCancelTask);
			gbProgress.Controls.Add(lblProgress);
			resources.ApplyResources(gbProgress, "gbProgress");
			gbProgress.Name = "gbProgress";
			gbProgress.TabStop = false;
			resources.ApplyResources(myProgressbar, "myProgressbar");
			myProgressbar.Name = "myProgressbar";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnRun);
			base.Controls.Add(gbDest);
			base.Controls.Add(gbSource);
			base.Controls.Add(gbProgress);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFileFormatConvert";
			base.Load += new System.EventHandler(dlgFileFormatConvert_Load);
			gbSource.ResumeLayout(false);
			gbSource.PerformLayout();
			gbDest.ResumeLayout(false);
			gbDest.PerformLayout();
			gbProgress.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
