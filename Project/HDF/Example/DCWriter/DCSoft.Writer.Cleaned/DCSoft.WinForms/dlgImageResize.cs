using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	public class dlgImageResize : Form
	{
		private Size myOldSize = Size.Empty;

		private Size myNewSize = Size.Empty;

		/// <summary>
		///       必需的设计器变量。
		///       </summary>
		private IContainer components = null;

		private Label label1;

		private NumericUpDown txtWidth;

		private Label label2;

		private NumericUpDown txtHeight;

		private Button btnOK;

		private Button btnCancel;

		private CheckBox chkKeepScale;

		public Size OldSize
		{
			get
			{
				return myOldSize;
			}
			set
			{
				myOldSize = value;
			}
		}

		public Size NewSize => myNewSize;

		public dlgImageResize()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.OK;
		}

		private void chkKeepScale_CheckedChanged(object sender, EventArgs e)
		{
			txtHeight.Enabled = !chkKeepScale.Checked;
			if (myOldSize.Width > 0)
			{
				txtHeight.Value = Convert.ToDecimal(txtWidth.Value * (decimal)myOldSize.Height / (decimal)myOldSize.Width);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			myNewSize = new Size((int)txtWidth.Value, (int)txtHeight.Value);
			Close();
		}

		private void txtWidth_ValueChanged(object sender, EventArgs e)
		{
			if (chkKeepScale.Checked && myOldSize.Width > 0)
			{
				txtHeight.Value = Convert.ToDecimal(txtWidth.Value * (decimal)myOldSize.Height / (decimal)myOldSize.Width);
			}
		}

		private void dlgImageResize_Load(object sender, EventArgs e)
		{
			txtWidth.Value = myOldSize.Width;
			txtHeight.Value = myOldSize.Height;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.dlgImageResize));
			label1 = new System.Windows.Forms.Label();
			txtWidth = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			txtHeight = new System.Windows.Forms.NumericUpDown();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkKeepScale = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)txtWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtHeight).BeginInit();
			SuspendLayout();
			label1.AccessibleDescription = null;
			label1.AccessibleName = null;
			resources.ApplyResources(label1, "label1");
			label1.Font = null;
			label1.Name = "label1";
			txtWidth.AccessibleDescription = null;
			txtWidth.AccessibleName = null;
			resources.ApplyResources(txtWidth, "txtWidth");
			txtWidth.Font = null;
			txtWidth.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			txtWidth.Name = "txtWidth";
			txtWidth.ValueChanged += new System.EventHandler(txtWidth_ValueChanged);
			label2.AccessibleDescription = null;
			label2.AccessibleName = null;
			resources.ApplyResources(label2, "label2");
			label2.Font = null;
			label2.Name = "label2";
			txtHeight.AccessibleDescription = null;
			txtHeight.AccessibleName = null;
			resources.ApplyResources(txtHeight, "txtHeight");
			txtHeight.Font = null;
			txtHeight.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			txtHeight.Name = "txtHeight";
			btnOK.AccessibleDescription = null;
			btnOK.AccessibleName = null;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.BackgroundImage = null;
			btnOK.Font = null;
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.AccessibleDescription = null;
			btnCancel.AccessibleName = null;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.BackgroundImage = null;
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Font = null;
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			chkKeepScale.AccessibleDescription = null;
			chkKeepScale.AccessibleName = null;
			resources.ApplyResources(chkKeepScale, "chkKeepScale");
			chkKeepScale.BackgroundImage = null;
			chkKeepScale.Font = null;
			chkKeepScale.Name = "chkKeepScale";
			chkKeepScale.UseVisualStyleBackColor = true;
			chkKeepScale.CheckedChanged += new System.EventHandler(chkKeepScale_CheckedChanged);
			base.AcceptButton = btnOK;
			base.AccessibleDescription = null;
			base.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackgroundImage = null;
			base.CancelButton = btnCancel;
			base.Controls.Add(chkKeepScale);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtHeight);
			base.Controls.Add(txtWidth);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = null;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = null;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgImageResize";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgImageResize_Load);
			((System.ComponentModel.ISupportInitialize)txtWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)txtHeight).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
