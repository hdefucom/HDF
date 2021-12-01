using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档元素表达式对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgElementExpression : Form
	{
		private IContainer icontainer_0 = null;

		private Label lblName;

		private Label label1;

		private TextBox txtValueExpression;

		private Label label2;

		private TextBox txtVisibleExpression;

		private Button btnOK;

		private Button btnCancel;

		private XTextElement xtextElement_0 = null;

		/// <summary>
		///       目标元素
		///       </summary>
		public XTextElement SourceElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
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
			lblName = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			txtValueExpression = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtVisibleExpression = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			lblName.AutoSize = true;
			lblName.Location = new System.Drawing.Point(14, 21);
			lblName.Name = "lblName";
			lblName.Size = new System.Drawing.Size(65, 12);
			lblName.TabIndex = 0;
			lblName.Text = "文档元素：";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(14, 56);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 12);
			label1.TabIndex = 1;
			label1.Text = "内容表达式：";
			txtValueExpression.Location = new System.Drawing.Point(109, 53);
			txtValueExpression.Name = "txtValueExpression";
			txtValueExpression.Size = new System.Drawing.Size(342, 21);
			txtValueExpression.TabIndex = 2;
			txtValueExpression.TextChanged += new System.EventHandler(txtValueExpression_TextChanged);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(14, 97);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(89, 12);
			label2.TabIndex = 1;
			label2.Text = "可见性表达式：";
			txtVisibleExpression.Location = new System.Drawing.Point(109, 94);
			txtVisibleExpression.Name = "txtVisibleExpression";
			txtVisibleExpression.Size = new System.Drawing.Size(342, 21);
			txtVisibleExpression.TabIndex = 2;
			txtVisibleExpression.TextChanged += new System.EventHandler(txtVisibleExpression_TextChanged);
			btnOK.Enabled = false;
			btnOK.Location = new System.Drawing.Point(181, 161);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(114, 23);
			btnOK.TabIndex = 3;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(308, 161);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(114, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(481, 196);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtVisibleExpression);
			base.Controls.Add(label2);
			base.Controls.Add(txtValueExpression);
			base.Controls.Add(label1);
			base.Controls.Add(lblName);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgElementExpression";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "表达式";
			base.Load += new System.EventHandler(dlgElementExpression_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgElementExpression()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgElementExpression_Load(object sender, EventArgs e)
		{
			if (SourceElement != null)
			{
				_ = SourceElement.DomDisplayName;
				if (SourceElement is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)SourceElement;
					txtValueExpression.Text = xTextContainerElement.ValueExpression;
					txtVisibleExpression.Text = xTextContainerElement.VisibleExpression;
				}
			}
			btnOK.Enabled = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (SourceElement is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)SourceElement;
				xTextContainerElement.ValueExpression = txtValueExpression.Text.Trim();
				xTextContainerElement.VisibleExpression = txtVisibleExpression.Text.Trim();
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void txtValueExpression_TextChanged(object sender, EventArgs e)
		{
			btnOK.Enabled = true;
		}

		private void txtVisibleExpression_TextChanged(object sender, EventArgs e)
		{
			btnOK.Enabled = true;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
