using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       SQL文本编辑对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgSQLText : Form
	{
		[ComVisible(false)]
		public class GClass18 : UITypeEditor
		{
			public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
			{
				return UITypeEditorEditStyle.Modal;
			}

			public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
			{
				using (dlgSQLText dlgSQLText = new dlgSQLText())
				{
					dlgSQLText.InputText = Convert.ToString(value);
					if (dlgSQLText.ShowDialog() == DialogResult.OK)
					{
						return dlgSQLText.InputText;
					}
				}
				return value;
			}
		}

		private IContainer icontainer_0 = null;

		private TextBox txtSQL;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       输入的文本
		///       </summary>
		public string InputText
		{
			get
			{
				return txtSQL.Text;
			}
			set
			{
				txtSQL.Text = value;
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
			txtSQL = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			txtSQL.Dock = System.Windows.Forms.DockStyle.Top;
			txtSQL.Location = new System.Drawing.Point(0, 0);
			txtSQL.Multiline = true;
			txtSQL.Name = "txtSQL";
			txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtSQL.Size = new System.Drawing.Size(494, 290);
			txtSQL.TabIndex = 0;
			txtSQL.WordWrap = false;
			btnOK.Location = new System.Drawing.Point(220, 300);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(358, 300);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(494, 331);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtSQL);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSQLText";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "SQL查询语句";
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgSQLText()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
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
	}
}
