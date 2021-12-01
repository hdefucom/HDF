using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom.Design
{
	/// <summary>
	///       激活模式对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgValueEditorActiveMode : Form
	{
		private ValueEditorActiveMode valueEditorActiveMode_0 = ValueEditorActiveMode.None;

		private IContainer icontainer_0 = null;

		private CheckBox chkProgram;

		private CheckBox chkF2;

		private CheckBox chkGotFocus;

		private CheckBox chkMouseDblClick;

		private Button btnOK;

		private Button btnCancel;

		private CheckBox chkDefault;

		private CheckBox chkMouseClick;

		private CheckBox chkMouseRightClick;

		private CheckBox chkEnter;

		/// <summary>
		///       输入的激活模式
		///       </summary>
		public ValueEditorActiveMode EditorActiveMode
		{
			get
			{
				return valueEditorActiveMode_0;
			}
			set
			{
				valueEditorActiveMode_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgValueEditorActiveMode()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgValueEditorActiveMode_Load(object sender, EventArgs e)
		{
			chkDefault.Checked = WriterUtils.smethod_35((int)EditorActiveMode, 1);
			chkProgram.Checked = WriterUtils.smethod_35((int)EditorActiveMode, 2);
			chkF2.Checked = WriterUtils.smethod_35((int)EditorActiveMode, 4);
			chkGotFocus.Checked = WriterUtils.smethod_35((int)EditorActiveMode, 8);
			chkMouseDblClick.Checked = WriterUtils.smethod_35((int)EditorActiveMode, 16);
			chkMouseClick.Checked = WriterUtils.smethod_35((int)EditorActiveMode, 32);
			chkMouseRightClick.Checked = WriterUtils.smethod_35((int)EditorActiveMode, 64);
			chkEnter.Checked = WriterUtils.smethod_35((int)EditorActiveMode, 128);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			valueEditorActiveMode_0 = ValueEditorActiveMode.None;
			if (chkProgram.Checked)
			{
				valueEditorActiveMode_0 |= ValueEditorActiveMode.Program;
			}
			if (chkF2.Checked)
			{
				valueEditorActiveMode_0 |= ValueEditorActiveMode.F2;
			}
			if (chkGotFocus.Checked)
			{
				valueEditorActiveMode_0 |= ValueEditorActiveMode.GotFocus;
			}
			if (chkMouseDblClick.Checked)
			{
				valueEditorActiveMode_0 |= ValueEditorActiveMode.MouseDblClick;
			}
			if (chkDefault.Checked)
			{
				valueEditorActiveMode_0 |= ValueEditorActiveMode.Default;
			}
			if (chkMouseClick.Checked)
			{
				valueEditorActiveMode_0 |= ValueEditorActiveMode.MouseClick;
			}
			if (chkMouseRightClick.Checked)
			{
				valueEditorActiveMode_0 |= ValueEditorActiveMode.MouseRightClick;
			}
			if (chkEnter.Checked)
			{
				valueEditorActiveMode_0 |= ValueEditorActiveMode.Enter;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkDefault_CheckedChanged(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Dom.Design.dlgValueEditorActiveMode));
			chkProgram = new System.Windows.Forms.CheckBox();
			chkF2 = new System.Windows.Forms.CheckBox();
			chkGotFocus = new System.Windows.Forms.CheckBox();
			chkMouseDblClick = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkDefault = new System.Windows.Forms.CheckBox();
			chkMouseClick = new System.Windows.Forms.CheckBox();
			chkMouseRightClick = new System.Windows.Forms.CheckBox();
			chkEnter = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			resources.ApplyResources(chkProgram, "chkProgram");
			chkProgram.Name = "chkProgram";
			chkProgram.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkF2, "chkF2");
			chkF2.Name = "chkF2";
			chkF2.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkGotFocus, "chkGotFocus");
			chkGotFocus.Name = "chkGotFocus";
			chkGotFocus.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkMouseDblClick, "chkMouseDblClick");
			chkMouseDblClick.Name = "chkMouseDblClick";
			chkMouseDblClick.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(chkDefault, "chkDefault");
			chkDefault.Name = "chkDefault";
			chkDefault.UseVisualStyleBackColor = true;
			chkDefault.CheckedChanged += new System.EventHandler(chkDefault_CheckedChanged);
			resources.ApplyResources(chkMouseClick, "chkMouseClick");
			chkMouseClick.Name = "chkMouseClick";
			chkMouseClick.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkMouseRightClick, "chkMouseRightClick");
			chkMouseRightClick.Name = "chkMouseRightClick";
			chkMouseRightClick.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkEnter, "chkEnter");
			chkEnter.Name = "chkEnter";
			chkEnter.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkEnter);
			base.Controls.Add(chkMouseRightClick);
			base.Controls.Add(chkMouseClick);
			base.Controls.Add(chkMouseDblClick);
			base.Controls.Add(chkGotFocus);
			base.Controls.Add(chkF2);
			base.Controls.Add(chkDefault);
			base.Controls.Add(chkProgram);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgValueEditorActiveMode";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgValueEditorActiveMode_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
