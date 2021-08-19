using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       插入当前日期对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgCurrentDateTime : Form
	{
		private IContainer icontainer_0 = null;

		private ListBox lstDateTime;

		private Button btnOK;

		private Button btnCancel;

		private string string_0 = null;

		private DateTime dateTime_0 = DateTime.Now;

		/// <summary>
		///       日期时间文本
		///       </summary>
		public string DateTimeString
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
		///       当前日期
		///       </summary>
		public DateTime CurrentDateTime
		{
			get
			{
				return dateTime_0;
			}
			set
			{
				dateTime_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgCurrentDateTime));
			lstDateTime = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lstDateTime, "lstDateTime");
			lstDateTime.FormattingEnabled = true;
			lstDateTime.Name = "lstDateTime";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.ImageKey = DCSoft.Writer.WriterStrings.Command_AlignBottomCenter;
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.ImageKey = DCSoft.Writer.WriterStrings.Command_AlignBottomCenter;
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstDateTime);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgCurrentDateTime";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgCurrentDateTime_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgCurrentDateTime()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgCurrentDateTime_Load(object sender, EventArgs e)
		{
			DateTime currentDateTime = CurrentDateTime;
			lstDateTime.Items.Add(currentDateTime.ToShortTimeString());
			lstDateTime.Items.Add(currentDateTime.ToString("d"));
			lstDateTime.Items.Add(currentDateTime.ToString("D"));
			lstDateTime.Items.Add(currentDateTime.ToString("f"));
			lstDateTime.Items.Add(currentDateTime.ToString("F"));
			lstDateTime.Items.Add(currentDateTime.ToString());
			lstDateTime.Items.Add(currentDateTime.ToString("yyyy年MM月dd日 HH:mm:ss"));
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DateTimeString = lstDateTime.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}
}
