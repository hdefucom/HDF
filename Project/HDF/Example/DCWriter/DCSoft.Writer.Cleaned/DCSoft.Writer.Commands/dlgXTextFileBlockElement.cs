using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文件块属性对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgXTextFileBlockElement : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtText;

		private Label label3;

		private TextBox txtContentSource;

		private Button btnBrowse;

		private Button btnOK;

		private Button btnCancel;

		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgXTextFileBlockElement));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtContentSource = new System.Windows.Forms.TextBox();
			btnBrowse = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtText, "txtText");
			txtText.Name = "txtText";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtContentSource, "txtContentSource");
			txtContentSource.Name = "txtContentSource";
			txtContentSource.ReadOnly = true;
			btnBrowse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnBrowse, "btnBrowse");
			btnBrowse.Name = "btnBrowse";
			btnBrowse.UseVisualStyleBackColor = true;
			btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(btnBrowse);
			base.Controls.Add(txtContentSource);
			base.Controls.Add(label3);
			base.Controls.Add(txtText);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgXTextFileBlockElement";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgXTextFileBlockElement_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgXTextFileBlockElement()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgXTextFileBlockElement_Load(object sender, EventArgs e)
		{
			if (SourceEventArgs != null)
			{
				XTextFileBlockElement xTextFileBlockElement = (XTextFileBlockElement)SourceEventArgs.Element;
				txtID.Text = xTextFileBlockElement.ID;
				txtText.Text = xTextFileBlockElement.Text;
				FileContentSource contentSource = xTextFileBlockElement.ContentSource;
				if (contentSource != null)
				{
					txtContentSource.Text = contentSource.ToString();
					txtContentSource.Tag = contentSource;
				}
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			using (dlgFileContentSource dlgFileContentSource = new dlgFileContentSource())
			{
				dlgFileContentSource.ContentSource = (FileContentSource)txtContentSource.Tag;
				if (SourceEventArgs != null)
				{
					dlgFileContentSource.AppHost = SourceEventArgs.Host;
				}
				if (dlgFileContentSource.ShowDialog(this) == DialogResult.OK)
				{
					txtContentSource.Text = dlgFileContentSource.ContentSource.ToString();
					txtContentSource.Tag = dlgFileContentSource.ContentSource.Clone();
					if (!string.IsNullOrEmpty(dlgFileContentSource.ContentSource.FileName))
					{
						txtText.Text = Path.GetFileNameWithoutExtension(dlgFileContentSource.ContentSource.FileName);
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 13;
			if (SourceEventArgs == null)
			{
				return;
			}
			XTextDocument document = SourceEventArgs.Document;
			XTextFileBlockElement xTextFileBlockElement = (XTextFileBlockElement)SourceEventArgs.Element;
			xTextFileBlockElement.OwnerDocument = document;
			bool flag = SourceEventArgs.LogUndo && document.CanLogUndo;
			bool flag2 = false;
			string text = txtID.Text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
			if (text != xTextFileBlockElement.ID)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ID", xTextFileBlockElement.ID, text, xTextFileBlockElement);
				}
				xTextFileBlockElement.ID = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtText.Text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
			if (text != xTextFileBlockElement.Text)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Text", xTextFileBlockElement.Text, text, xTextFileBlockElement);
				}
				xTextFileBlockElement.Text = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			FileContentSource fileContentSource = (FileContentSource)txtContentSource.Tag;
			if (fileContentSource != xTextFileBlockElement.ContentSource)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ContentSource", xTextFileBlockElement.ContentSource, fileContentSource, xTextFileBlockElement);
				}
				xTextFileBlockElement.ContentSource = fileContentSource;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag2)
				{
					base.DialogResult = DialogResult.OK;
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
	}
}
