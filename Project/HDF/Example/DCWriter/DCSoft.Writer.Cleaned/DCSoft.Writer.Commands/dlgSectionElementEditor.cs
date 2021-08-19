using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档节元素对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgSectionElementEditor : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private IContainer icontainer_0 = null;

		private Button btnCancel;

		private Button btnOK;

		private TextBox txtName;

		private Label label2;

		private TextBox txtID;

		private Label label1;

		/// <summary>
		///       参数
		///       </summary>
		public ElementPropertiesEditEventArgs SourceEventArgs
		{
			get
			{
				return elementPropertiesEditEventArgs_0;
			}
			set
			{
				elementPropertiesEditEventArgs_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgSectionElementEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgSectionElementEditor_Load(object sender, EventArgs e)
		{
			if (elementPropertiesEditEventArgs_0 != null && elementPropertiesEditEventArgs_0.Element is XTextSectionElement)
			{
				XTextSectionElement xTextSectionElement = (XTextSectionElement)elementPropertiesEditEventArgs_0.Element;
				txtID.Text = xTextSectionElement.ID;
				txtName.Text = xTextSectionElement.Name;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 17;
			if (elementPropertiesEditEventArgs_0 == null || !(elementPropertiesEditEventArgs_0.Element is XTextSectionElement))
			{
				return;
			}
			XTextSectionElement xTextSectionElement = (XTextSectionElement)elementPropertiesEditEventArgs_0.Element;
			XTextDocument document = SourceEventArgs.Document;
			bool flag = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
			bool flag2 = false;
			string text = txtID.Text.Trim();
			if (!WriterUtils.smethod_43(text, xTextSectionElement.ID))
			{
				if (flag)
				{
					document.UndoList.AddProperty("ID", xTextSectionElement.ID, text, xTextSectionElement);
				}
				xTextSectionElement.ID = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			text = txtName.Text;
			if (!WriterUtils.smethod_43(text, xTextSectionElement.Name))
			{
				if (flag)
				{
					document.UndoList.AddProperty("Name", xTextSectionElement.Name, text, xTextSectionElement);
				}
				xTextSectionElement.Name = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag2)
				{
					base.DialogResult = DialogResult.OK;
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = xTextSectionElement.OwnerDocument;
					contentChangedEventArgs.Element = xTextSectionElement;
					contentChangedEventArgs.LoadingDocument = false;
					xTextSectionElement.EditorRefreshView();
					xTextSectionElement.Parent.method_23(contentChangedEventArgs);
				}
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
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
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			txtName = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnCancel.Location = new System.Drawing.Point(154, 102);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(106, 23);
			btnCancel.TabIndex = 92;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnOK.Location = new System.Drawing.Point(19, 102);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(106, 23);
			btnOK.TabIndex = 91;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			txtName.Location = new System.Drawing.Point(84, 60);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(176, 21);
			txtName.TabIndex = 96;
			label2.AutoSize = true;
			label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			label2.Location = new System.Drawing.Point(17, 64);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(41, 12);
			label2.TabIndex = 95;
			label2.Text = "名称：";
			txtID.Location = new System.Drawing.Point(84, 24);
			txtID.Name = "txtID";
			txtID.Size = new System.Drawing.Size(176, 21);
			txtID.TabIndex = 94;
			label1.AutoSize = true;
			label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			label1.Location = new System.Drawing.Point(17, 28);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(41, 12);
			label1.TabIndex = 93;
			label1.Text = "编号：";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(284, 149);
			base.Controls.Add(txtName);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSectionElementEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "文档节元素";
			base.Load += new System.EventHandler(dlgSectionElementEditor_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
