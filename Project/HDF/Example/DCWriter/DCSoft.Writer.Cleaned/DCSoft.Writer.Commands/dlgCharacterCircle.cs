using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       带圈字符设置对话框对象
	///       </summary>
	[ComVisible(false)]
	public class dlgCharacterCircle : Form
	{
		private IContainer icontainer_0 = null;

		private RadioButton rdoNone;

		private RadioButton rdoCircle;

		private RadioButton rdoRectangle;

		private Button btnOK;

		private Button btnCancel;

		private CharacterCircleStyles characterCircleStyles_0 = CharacterCircleStyles.None;

		/// <summary>
		///       字符套圈样式
		///       </summary>
		public CharacterCircleStyles CircleStyle
		{
			get
			{
				return characterCircleStyles_0;
			}
			set
			{
				characterCircleStyles_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgCharacterCircle));
			rdoNone = new System.Windows.Forms.RadioButton();
			rdoCircle = new System.Windows.Forms.RadioButton();
			rdoRectangle = new System.Windows.Forms.RadioButton();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(rdoNone, "rdoNone");
			rdoNone.Name = "rdoNone";
			rdoNone.TabStop = true;
			rdoNone.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoCircle, "rdoCircle");
			rdoCircle.Name = "rdoCircle";
			rdoCircle.TabStop = true;
			rdoCircle.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoRectangle, "rdoRectangle");
			rdoRectangle.Name = "rdoRectangle";
			rdoRectangle.TabStop = true;
			rdoRectangle.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(rdoRectangle);
			base.Controls.Add(rdoCircle);
			base.Controls.Add(rdoNone);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgCharacterCircle";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgCharacterCircle_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgCharacterCircle()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgCharacterCircle_Load(object sender, EventArgs e)
		{
			switch (CircleStyle)
			{
			case CharacterCircleStyles.None:
				rdoNone.Checked = true;
				break;
			case CharacterCircleStyles.Circle:
				rdoCircle.Checked = true;
				break;
			case CharacterCircleStyles.Rectangle:
				rdoRectangle.Checked = true;
				break;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (rdoNone.Checked)
			{
				CircleStyle = CharacterCircleStyles.None;
			}
			if (rdoCircle.Checked)
			{
				CircleStyle = CharacterCircleStyles.Circle;
			}
			if (rdoRectangle.Checked)
			{
				CircleStyle = CharacterCircleStyles.Rectangle;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
