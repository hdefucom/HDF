using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Design
{
	[ComVisible(false)]
	public class dlgFillStyleConfigItem : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtText;

		private Label label2;

		private ListBox lstItems;

		private Button btnOK;

		private Button btnCancel;

		private string string_0 = null;

		private XBrushStyleConst xbrushStyleConst_0 = XBrushStyleConst.Solid;

		public string InputText
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

		public XBrushStyleConst InputStyle
		{
			get
			{
				return xbrushStyleConst_0;
			}
			set
			{
				xbrushStyleConst_0 = value;
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
			txtText = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			lstItems = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 0;
			label1.Text = "文本：";
			txtText.Location = new System.Drawing.Point(72, 9);
			txtText.Name = "txtText";
			txtText.Size = new System.Drawing.Size(255, 21);
			txtText.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(65, 12);
			label2.TabIndex = 2;
			label2.Text = "填充样式：";
			lstItems.FormattingEnabled = true;
			lstItems.ItemHeight = 12;
			lstItems.Location = new System.Drawing.Point(72, 48);
			lstItems.Name = "lstItems";
			lstItems.Size = new System.Drawing.Size(255, 172);
			lstItems.TabIndex = 3;
			btnOK.Location = new System.Drawing.Point(107, 227);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 4;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(198, 227);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(349, 262);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstItems);
			base.Controls.Add(label2);
			base.Controls.Add(txtText);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgFillStyleConfigItem";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "填充样式";
			base.Load += new System.EventHandler(dlgFillStyleConfigItem_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public dlgFillStyleConfigItem()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgFillStyleConfigItem_Load(object sender, EventArgs e)
		{
			GClass441 gClass = new GClass441();
			gClass.method_15();
			gClass.method_3(lstItems);
			GClass441.smethod_0(lstItems, InputStyle);
			txtText.Text = InputText;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			InputText = txtText.Text;
			InputStyle = GClass441.smethod_1(lstItems);
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}
}
