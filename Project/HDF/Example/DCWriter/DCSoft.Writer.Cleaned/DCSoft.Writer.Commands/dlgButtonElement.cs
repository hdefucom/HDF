using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgButtonElement : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtName;

		private Label label3;

		private TextBox txtText;

		private Button btnOK;

		private Button btnCancel;

		private Label label5;

		private ComboBox cboEventTemplate;

		private CheckBox chkDeleteable;

		private Label label4;

		private TextBox txtClickScriptText;

		private Label label6;

		private TextBox txtCommandName;

		private CheckBox chkEnable;

		private Label label7;

		private ComboBox cboPrintVisibility;

		private Label label8;

		private Button btnImage;

		private Label label9;

		private Button btnImageForMouseOver;

		private Label label10;

		private Button btnImageForDown;

		private CheckBox chkAutoSize;

		private CheckBox chkPrintAsText;

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
		public dlgButtonElement()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgButtonElement_Load(object sender, EventArgs e)
		{
			if (elementPropertiesEditEventArgs_0 != null && elementPropertiesEditEventArgs_0.Document != null && elementPropertiesEditEventArgs_0.Document.EditorControl != null)
			{
				WriterControl editorControl = elementPropertiesEditEventArgs_0.Document.EditorControl;
				foreach (ElementEventTemplate eventTemplate in editorControl.EventTemplates)
				{
					cboEventTemplate.Items.Add(eventTemplate.Name);
				}
			}
			if (elementPropertiesEditEventArgs_0 != null && elementPropertiesEditEventArgs_0.Element is XTextButtonElement)
			{
				XTextButtonElement xTextButtonElement = (XTextButtonElement)elementPropertiesEditEventArgs_0.Element;
				txtID.Text = xTextButtonElement.ID;
				txtName.Text = xTextButtonElement.Name;
				txtText.Text = xTextButtonElement.Text;
				cboEventTemplate.Text = xTextButtonElement.EventTemplateName;
				chkDeleteable.Checked = xTextButtonElement.Deleteable;
				txtClickScriptText.Text = xTextButtonElement.ScriptTextForClick;
				cboPrintVisibility.SelectedIndex = (int)xTextButtonElement.PrintVisibility;
				txtCommandName.Text = xTextButtonElement.CommandName;
				chkEnable.Checked = xTextButtonElement.Enabled;
				chkAutoSize.Checked = xTextButtonElement.AutoSize;
				btnImage.Tag = xTextButtonElement.Image;
				if (xTextButtonElement.Image != null)
				{
					btnImage.Image = xTextButtonElement.Image.Value;
				}
				btnImageForDown.Tag = xTextButtonElement.ImageForDown;
				if (xTextButtonElement.ImageForDown != null)
				{
					btnImageForDown.Image = xTextButtonElement.ImageForDown.Value;
				}
				btnImageForMouseOver.Tag = xTextButtonElement.ImageForMouseOver;
				if (xTextButtonElement.ImageForMouseOver != null)
				{
					btnImageForMouseOver.Image = xTextButtonElement.ImageForMouseOver.Value;
				}
				chkPrintAsText.Checked = xTextButtonElement.PrintAsText;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 9;
			if (elementPropertiesEditEventArgs_0 == null || !(elementPropertiesEditEventArgs_0.Element is XTextButtonElement))
			{
				return;
			}
			XTextButtonElement xTextButtonElement = (XTextButtonElement)elementPropertiesEditEventArgs_0.Element;
			XTextDocument document = SourceEventArgs.Document;
			bool flag = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
			bool flag2 = false;
			string text = txtID.Text.Trim();
			if (!WriterUtils.smethod_43(text, xTextButtonElement.ID))
			{
				if (flag)
				{
					document.UndoList.AddProperty("ID", xTextButtonElement.ID, text, xTextButtonElement);
				}
				xTextButtonElement.ID = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			text = txtName.Text;
			if (!WriterUtils.smethod_43(text, xTextButtonElement.Name))
			{
				if (flag)
				{
					document.UndoList.AddProperty("Name", xTextButtonElement.Name, text, xTextButtonElement);
				}
				xTextButtonElement.Name = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (!WriterUtils.smethod_43(txtCommandName.Text, xTextButtonElement.CommandName))
			{
				if (flag)
				{
					document.UndoList.AddProperty("CommandName", xTextButtonElement.CommandName, txtCommandName.Text, xTextButtonElement);
				}
				xTextButtonElement.CommandName = txtCommandName.Text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkDeleteable.Checked != xTextButtonElement.Deleteable)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Deleteable", xTextButtonElement.Deleteable, chkDeleteable.Checked, xTextButtonElement);
				}
				xTextButtonElement.Deleteable = chkDeleteable.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkPrintAsText.Checked != xTextButtonElement.PrintAsText)
			{
				if (flag)
				{
					document.UndoList.AddProperty("PrintAsText", xTextButtonElement.PrintAsText, chkPrintAsText.Checked, xTextButtonElement);
				}
				xTextButtonElement.PrintAsText = chkPrintAsText.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkAutoSize.Checked != xTextButtonElement.AutoSize)
			{
				if (flag)
				{
					document.UndoList.AddProperty("AutoSize", xTextButtonElement.AutoSize, chkAutoSize.Checked, xTextButtonElement);
				}
				xTextButtonElement.AutoSize = chkAutoSize.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			if (chkEnable.Checked != xTextButtonElement.Enabled)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Enabled", xTextButtonElement.Enabled, chkEnable.Checked, xTextButtonElement);
				}
				xTextButtonElement.Enabled = chkEnable.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			ElementVisibility selectedIndex = (ElementVisibility)cboPrintVisibility.SelectedIndex;
			if (selectedIndex != xTextButtonElement.PrintVisibility)
			{
				if (flag)
				{
					document.UndoList.AddProperty("PrintVisibility", xTextButtonElement.PrintVisibility, selectedIndex, xTextButtonElement);
				}
				xTextButtonElement.PrintVisibility = selectedIndex;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			XImageValue xImageValue = (XImageValue)btnImage.Tag;
			if (xImageValue != xTextButtonElement.Image)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Image", xTextButtonElement.Image, xImageValue, xTextButtonElement);
				}
				xTextButtonElement.Image = xImageValue;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			xImageValue = (XImageValue)btnImageForDown.Tag;
			if (xImageValue != xTextButtonElement.ImageForDown)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ImageForDown", xTextButtonElement.ImageForDown, xImageValue, xTextButtonElement);
				}
				xTextButtonElement.ImageForDown = xImageValue;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			xImageValue = (XImageValue)btnImageForMouseOver.Tag;
			if (xImageValue != xTextButtonElement.ImageForMouseOver)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ImageForMouseOver", xTextButtonElement.ImageForMouseOver, xImageValue, xTextButtonElement);
				}
				xTextButtonElement.ImageForMouseOver = xImageValue;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			text = txtText.Text;
			if (!WriterUtils.smethod_43(text, xTextButtonElement.Text))
			{
				if (flag)
				{
					document.UndoList.AddProperty("Text", xTextButtonElement.Text, text, xTextButtonElement);
				}
				xTextButtonElement.Text = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtClickScriptText.Text;
			if (!WriterUtils.smethod_43(text, xTextButtonElement.Text))
			{
				if (flag)
				{
					document.UndoList.AddProperty("ScriptTextForClick", xTextButtonElement.ScriptTextForClick, text, xTextButtonElement);
				}
				xTextButtonElement.ScriptTextForClick = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = cboEventTemplate.Text;
			if (!WriterUtils.smethod_43(text, xTextButtonElement.EventTemplateName))
			{
				if (flag)
				{
					document.UndoList.AddProperty("EventTemplateName", xTextButtonElement.EventTemplateName, text, xTextButtonElement);
				}
				xTextButtonElement.EventTemplateName = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag2)
				{
					base.DialogResult = DialogResult.OK;
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = xTextButtonElement.OwnerDocument;
					contentChangedEventArgs.Element = xTextButtonElement;
					contentChangedEventArgs.LoadingDocument = false;
					xTextButtonElement.EditorRefreshView();
					xTextButtonElement.Parent.method_23(contentChangedEventArgs);
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

		private void method_0(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = WriterStrings.ImageFileFilter;
				openFileDialog.CheckFileExists = true;
				if (openFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					XImageValue xImageValue = new XImageValue();
					xImageValue.Load(openFileDialog.FileName);
					Button button = (Button)sender;
					button.Image = xImageValue.Value;
					button.Tag = xImageValue;
				}
			}
		}

		private void btnImageForDown_MouseUp(object sender, MouseEventArgs e)
		{
			Button button = (Button)sender;
			if (e.Button == MouseButtons.Left)
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.Filter = WriterStrings.ImageFileFilter;
					openFileDialog.CheckFileExists = true;
					if (openFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						XImageValue xImageValue = new XImageValue();
						xImageValue.Load(openFileDialog.FileName);
						button.Image = xImageValue.Value;
						button.Tag = xImageValue;
					}
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				button.Image = null;
				button.Tag = null;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgButtonElement));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			cboEventTemplate = new System.Windows.Forms.ComboBox();
			chkDeleteable = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			txtClickScriptText = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			txtCommandName = new System.Windows.Forms.TextBox();
			chkEnable = new System.Windows.Forms.CheckBox();
			label7 = new System.Windows.Forms.Label();
			cboPrintVisibility = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			btnImage = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			btnImageForMouseOver = new System.Windows.Forms.Button();
			label10 = new System.Windows.Forms.Label();
			btnImageForDown = new System.Windows.Forms.Button();
			chkAutoSize = new System.Windows.Forms.CheckBox();
			chkPrintAsText = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtText, "txtText");
			txtText.Name = "txtText";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			cboEventTemplate.FormattingEnabled = true;
			resources.ApplyResources(cboEventTemplate, "cboEventTemplate");
			cboEventTemplate.Name = "cboEventTemplate";
			resources.ApplyResources(chkDeleteable, "chkDeleteable");
			chkDeleteable.Name = "chkDeleteable";
			chkDeleteable.UseVisualStyleBackColor = true;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(txtClickScriptText, "txtClickScriptText");
			txtClickScriptText.Name = "txtClickScriptText";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(txtCommandName, "txtCommandName");
			txtCommandName.Name = "txtCommandName";
			resources.ApplyResources(chkEnable, "chkEnable");
			chkEnable.Name = "chkEnable";
			chkEnable.UseVisualStyleBackColor = true;
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			cboPrintVisibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboPrintVisibility.FormattingEnabled = true;
			cboPrintVisibility.Items.AddRange(new object[3]
			{
				resources.GetString("cboPrintVisibility.Items"),
				resources.GetString("cboPrintVisibility.Items1"),
				resources.GetString("cboPrintVisibility.Items2")
			});
			resources.ApplyResources(cboPrintVisibility, "cboPrintVisibility");
			cboPrintVisibility.Name = "cboPrintVisibility";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(btnImage, "btnImage");
			btnImage.Name = "btnImage";
			btnImage.UseVisualStyleBackColor = true;
			btnImage.MouseUp += new System.Windows.Forms.MouseEventHandler(btnImageForDown_MouseUp);
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			resources.ApplyResources(btnImageForMouseOver, "btnImageForMouseOver");
			btnImageForMouseOver.Name = "btnImageForMouseOver";
			btnImageForMouseOver.UseVisualStyleBackColor = true;
			btnImageForMouseOver.MouseUp += new System.Windows.Forms.MouseEventHandler(btnImageForDown_MouseUp);
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			resources.ApplyResources(btnImageForDown, "btnImageForDown");
			btnImageForDown.Name = "btnImageForDown";
			btnImageForDown.UseVisualStyleBackColor = true;
			btnImageForDown.MouseUp += new System.Windows.Forms.MouseEventHandler(btnImageForDown_MouseUp);
			resources.ApplyResources(chkAutoSize, "chkAutoSize");
			chkAutoSize.Name = "chkAutoSize";
			chkAutoSize.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkPrintAsText, "chkPrintAsText");
			chkPrintAsText.Name = "chkPrintAsText";
			chkPrintAsText.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnImageForDown);
			base.Controls.Add(label10);
			base.Controls.Add(btnImageForMouseOver);
			base.Controls.Add(label9);
			base.Controls.Add(btnImage);
			base.Controls.Add(label8);
			base.Controls.Add(cboPrintVisibility);
			base.Controls.Add(label7);
			base.Controls.Add(cboEventTemplate);
			base.Controls.Add(label5);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkPrintAsText);
			base.Controls.Add(chkAutoSize);
			base.Controls.Add(chkEnable);
			base.Controls.Add(chkDeleteable);
			base.Controls.Add(txtClickScriptText);
			base.Controls.Add(label4);
			base.Controls.Add(txtCommandName);
			base.Controls.Add(label6);
			base.Controls.Add(txtText);
			base.Controls.Add(label3);
			base.Controls.Add(txtName);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgButtonElement";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgButtonElement_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
