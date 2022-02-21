using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	
	[ComVisible(false)]
	public class dlgPrepareScreenSnapshot : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private Button btnStart;

		public EventHandler AfterGetSnashotImage = null;

		private Bitmap bitmap_0 = null;

		/// <summary>
		///       获得的图片对象
		///       </summary>
		public Bitmap BmpContent
		{
			get
			{
				return bitmap_0;
			}
			set
			{
				bitmap_0 = value;
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
			label1 = new System.Windows.Forms.Label();
			btnStart = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(240, 40);
			label1.TabIndex = 0;
			label1.Text = "请先调整您的窗口，将需要截取的内容显示在屏幕的可见区域。";
			btnStart.Location = new System.Drawing.Point(69, 77);
			btnStart.Name = "btnStart";
			btnStart.Size = new System.Drawing.Size(109, 40);
			btnStart.TabIndex = 1;
			btnStart.Text = "开始截屏";
			btnStart.UseVisualStyleBackColor = true;
			btnStart.Click += new System.EventHandler(btnStart_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(258, 129);
			base.Controls.Add(btnStart);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPrepareScreenSnapshot";
			base.Opacity = 0.7;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "准备截屏";
			base.TopMost = true;
			ResumeLayout(false);
		}

		public static void smethod_0(Form form_0, EventHandler eventHandler_0)
		{
			dlgPrepareScreenSnapshot dlgPrepareScreenSnapshot = new dlgPrepareScreenSnapshot();
			dlgPrepareScreenSnapshot.AfterGetSnashotImage = eventHandler_0;
			dlgPrepareScreenSnapshot.Show(form_0);
		}

		public dlgPrepareScreenSnapshot()
		{
			base.DialogResult = DialogResult.Cancel;
			InitializeComponent();
		}

		protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs previewKeyDownEventArgs_0)
		{
			base.OnPreviewKeyDown(previewKeyDownEventArgs_0);
			if (previewKeyDownEventArgs_0.KeyCode == Keys.Escape)
			{
				Close();
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			Form owner = base.Owner;
			Close();
			using (frmScreenSnapshot2 frmScreenSnapshot = new frmScreenSnapshot2())
			{
				frmScreenSnapshot.Owner = owner;
				if (frmScreenSnapshot.ShowDialog(owner) == DialogResult.OK)
				{
					base.DialogResult = DialogResult.OK;
					BmpContent = frmScreenSnapshot.BmpConent;
					if (AfterGetSnashotImage != null)
					{
						AfterGetSnashotImage(this, null);
					}
				}
			}
		}
	}
}
