using DCSoft.Writer.Serialization;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       URL地址输入对话框
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class dlgInputUrl : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private ComboBox cboURL;

		private Button btnOK;

		private Button btnCancel;

		private Label label2;

		private ComboBox cboFormat;

		private string string_0 = null;

		private string string_1 = null;

		private WriterAppHost writerAppHost_0 = WriterAppHost.Default;

		/// <summary>
		///       输入的URL地址
		///       </summary>
		public string InputURL
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
		///       文件格式
		///       </summary>
		public string FileFormat
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       编辑器宿主环境
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgInputUrl));
			label1 = new System.Windows.Forms.Label();
			cboURL = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			cboFormat = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			cboURL.FormattingEnabled = true;
			resources.ApplyResources(cboURL, "cboURL");
			cboURL.Name = "cboURL";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboFormat.FormattingEnabled = true;
			resources.ApplyResources(cboFormat, "cboFormat");
			cboFormat.Name = "cboFormat";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(cboFormat);
			base.Controls.Add(label2);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboURL);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputUrl";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInputUrl_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInputUrl()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInputUrl_Load(object sender, EventArgs e)
		{
			foreach (ContentSerializer contentSerializer in AppHost.ContentSerializers)
			{
				if ((contentSerializer.Flags & GEnum14.flag_1) == GEnum14.flag_1 || (contentSerializer.Flags & GEnum14.flag_3) == GEnum14.flag_3)
				{
					int selectedIndex = cboFormat.Items.Add(contentSerializer.Name);
					if (string.Compare(contentSerializer.Name, FileFormat, ignoreCase: true) == 0)
					{
						cboFormat.SelectedIndex = selectedIndex;
					}
				}
			}
			string[] array = GClass286.smethod_12();
			if (array != null)
			{
				cboURL.Items.AddRange(array);
			}
			cboURL.Text = string_0;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			string text = cboURL.Text;
			if (text.Trim().Length != 0)
			{
				string_0 = text;
				string_1 = cboFormat.Text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
