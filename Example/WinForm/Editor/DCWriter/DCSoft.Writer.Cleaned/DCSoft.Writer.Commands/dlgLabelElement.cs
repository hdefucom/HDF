using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文本标签元素对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgLabelElement : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtName;

		private CheckBox chkAutoSize;

		private Label label3;

		private TextBox txtText;

		private Button btnOK;

		private Button btnCancel;

		private CheckBox chkMultiline;

		private Label label4;

		private ComboBox cboAlign;

		private Label label5;

		private ComboBox cboEventTemplate;

		private CheckBox chkDeleteable;

		private GroupBox groupBox1;

		private TextBox txtLinkTextForContactAction;

		private Label label7;

		private TextBox txtAttributeNameForContactAction;

		private Label label6;

		private ComboBox cboContactMode;

		private Label label8;

		private CheckBox chkStrictMatchPageIndex;

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
		public dlgLabelElement()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgLabelElement_Load(object sender, EventArgs e)
		{
			WinFormUtils.FillEnumValuesToComboBox(typeof(LabelTextContactActionMode), cboContactMode);
			WinFormUtils.FillEnumValuesToComboBox(typeof(DCContentAlignment), cboAlign);
			if (elementPropertiesEditEventArgs_0 != null && elementPropertiesEditEventArgs_0.Document != null && elementPropertiesEditEventArgs_0.Document.EditorControl != null)
			{
				WriterControl editorControl = elementPropertiesEditEventArgs_0.Document.EditorControl;
				foreach (ElementEventTemplate eventTemplate in editorControl.EventTemplates)
				{
					cboEventTemplate.Items.Add(eventTemplate.Name);
				}
			}
			if (elementPropertiesEditEventArgs_0 != null && elementPropertiesEditEventArgs_0.Element is XTextLabelElement)
			{
				XTextLabelElement xTextLabelElement = (XTextLabelElement)elementPropertiesEditEventArgs_0.Element;
				txtID.Text = xTextLabelElement.ID;
				txtName.Text = xTextLabelElement.Name;
				chkAutoSize.Checked = xTextLabelElement.AutoSize;
				txtText.Text = xTextLabelElement.Text;
				cboAlign.SelectedItem = xTextLabelElement.Alignment;
				chkMultiline.Checked = xTextLabelElement.Multiline;
				cboEventTemplate.Text = xTextLabelElement.EventTemplateName;
				chkDeleteable.Checked = xTextLabelElement.Deleteable;
				txtAttributeNameForContactAction.Text = xTextLabelElement.AttributeNameForContactAction;
				txtLinkTextForContactAction.Text = xTextLabelElement.LinkTextForContactAction;
				cboContactMode.SelectedItem = xTextLabelElement.ContactAction;
				chkStrictMatchPageIndex.Checked = xTextLabelElement.StrictMatchPageIndex;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 13;
			if (elementPropertiesEditEventArgs_0 == null || !(elementPropertiesEditEventArgs_0.Element is XTextLabelElement))
			{
				return;
			}
			XTextLabelElement xTextLabelElement = (XTextLabelElement)elementPropertiesEditEventArgs_0.Element;
			XTextDocument document = SourceEventArgs.Document;
			bool flag = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
			bool flag2 = false;
			string text = txtID.Text.Trim();
			if (!WriterUtils.smethod_43(text, xTextLabelElement.ID))
			{
				if (flag)
				{
					document.UndoList.AddProperty("ID", xTextLabelElement.ID, text, xTextLabelElement);
				}
				xTextLabelElement.ID = text;
				flag2 = true;
			}
			text = txtName.Text;
			if (!WriterUtils.smethod_43(text, xTextLabelElement.Name))
			{
				if (flag)
				{
					document.UndoList.AddProperty("Name", xTextLabelElement.Name, text, xTextLabelElement);
				}
				xTextLabelElement.Name = text;
				flag2 = true;
			}
			text = txtAttributeNameForContactAction.Text;
			if (!WriterUtils.smethod_43(text, xTextLabelElement.AttributeNameForContactAction))
			{
				if (flag)
				{
					document.UndoList.AddProperty("AttributeNameForContactAction", xTextLabelElement.AttributeNameForContactAction, text, xTextLabelElement);
				}
				xTextLabelElement.AttributeNameForContactAction = text;
				flag2 = true;
			}
			text = txtLinkTextForContactAction.Text;
			if (!WriterUtils.smethod_43(text, xTextLabelElement.LinkTextForContactAction))
			{
				if (flag)
				{
					document.UndoList.AddProperty("LinkTextForContactAction", xTextLabelElement.LinkTextForContactAction, text, xTextLabelElement);
				}
				xTextLabelElement.LinkTextForContactAction = text;
				flag2 = true;
			}
			if (chkAutoSize.Checked != xTextLabelElement.AutoSize)
			{
				if (flag)
				{
					document.UndoList.AddProperty("AutoSize", xTextLabelElement.AutoSize, chkAutoSize.Checked, xTextLabelElement);
				}
				xTextLabelElement.AutoSize = chkAutoSize.Checked;
				flag2 = true;
			}
			if (chkStrictMatchPageIndex.Checked != xTextLabelElement.StrictMatchPageIndex)
			{
				if (flag)
				{
					document.UndoList.AddProperty("StrictMatchPageIndex", xTextLabelElement.StrictMatchPageIndex, chkStrictMatchPageIndex.Checked, xTextLabelElement);
				}
				xTextLabelElement.StrictMatchPageIndex = chkStrictMatchPageIndex.Checked;
				flag2 = true;
			}
			if (chkMultiline.Checked != xTextLabelElement.Multiline)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Multiline", xTextLabelElement.Multiline, chkMultiline.Checked, xTextLabelElement);
				}
				xTextLabelElement.Multiline = chkMultiline.Checked;
				flag2 = true;
			}
			if (chkDeleteable.Checked != xTextLabelElement.Deleteable)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Deleteable", xTextLabelElement.Deleteable, chkDeleteable.Checked, xTextLabelElement);
				}
				xTextLabelElement.Deleteable = chkDeleteable.Checked;
				flag2 = true;
			}
			LabelTextContactActionMode labelTextContactActionMode = (LabelTextContactActionMode)cboContactMode.SelectedItem;
			if (labelTextContactActionMode != xTextLabelElement.ContactAction)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ContactAction", xTextLabelElement.ContactAction, labelTextContactActionMode, xTextLabelElement);
				}
				xTextLabelElement.ContactAction = labelTextContactActionMode;
				flag2 = true;
			}
			DCContentAlignment dCContentAlignment = (DCContentAlignment)cboAlign.SelectedItem;
			if (dCContentAlignment != xTextLabelElement.Alignment)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Alignment", xTextLabelElement.Alignment, dCContentAlignment, xTextLabelElement);
				}
				xTextLabelElement.Alignment = dCContentAlignment;
				flag2 = true;
			}
			text = txtText.Text;
			if (!WriterUtils.smethod_43(text, xTextLabelElement.Text))
			{
				if (flag)
				{
					document.UndoList.AddProperty("Text", xTextLabelElement.Text, text, xTextLabelElement);
				}
				xTextLabelElement.Text = text;
				flag2 = true;
			}
			text = cboEventTemplate.Text;
			if (!WriterUtils.smethod_43(text, xTextLabelElement.EventTemplateName))
			{
				if (flag)
				{
					document.UndoList.AddProperty("EventTemplateName", xTextLabelElement.EventTemplateName, text, xTextLabelElement);
				}
				xTextLabelElement.EventTemplateName = text;
				flag2 = true;
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag2)
				{
					base.DialogResult = DialogResult.OK;
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = xTextLabelElement.OwnerDocument;
					contentChangedEventArgs.Element = xTextLabelElement;
					contentChangedEventArgs.LoadingDocument = false;
					xTextLabelElement.UpdateContactAction();
					xTextLabelElement.EditorRefreshView();
					xTextLabelElement.Parent.method_23(contentChangedEventArgs);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgLabelElement));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			chkAutoSize = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			chkMultiline = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			cboAlign = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			cboEventTemplate = new System.Windows.Forms.ComboBox();
			chkDeleteable = new System.Windows.Forms.CheckBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			chkStrictMatchPageIndex = new System.Windows.Forms.CheckBox();
			cboContactMode = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			txtLinkTextForContactAction = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			txtAttributeNameForContactAction = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			groupBox1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(chkAutoSize, "chkAutoSize");
			chkAutoSize.Name = "chkAutoSize";
			chkAutoSize.UseVisualStyleBackColor = true;
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
			resources.ApplyResources(chkMultiline, "chkMultiline");
			chkMultiline.Name = "chkMultiline";
			chkMultiline.UseVisualStyleBackColor = true;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			cboAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboAlign.FormattingEnabled = true;
			resources.ApplyResources(cboAlign, "cboAlign");
			cboAlign.Name = "cboAlign";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			cboEventTemplate.FormattingEnabled = true;
			resources.ApplyResources(cboEventTemplate, "cboEventTemplate");
			cboEventTemplate.Name = "cboEventTemplate";
			resources.ApplyResources(chkDeleteable, "chkDeleteable");
			chkDeleteable.Name = "chkDeleteable";
			chkDeleteable.UseVisualStyleBackColor = true;
			groupBox1.Controls.Add(chkStrictMatchPageIndex);
			groupBox1.Controls.Add(cboContactMode);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(txtLinkTextForContactAction);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(txtAttributeNameForContactAction);
			groupBox1.Controls.Add(label6);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(chkStrictMatchPageIndex, "chkStrictMatchPageIndex");
			chkStrictMatchPageIndex.Name = "chkStrictMatchPageIndex";
			chkStrictMatchPageIndex.UseVisualStyleBackColor = true;
			cboContactMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboContactMode.FormattingEnabled = true;
			resources.ApplyResources(cboContactMode, "cboContactMode");
			cboContactMode.Name = "cboContactMode";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(txtLinkTextForContactAction, "txtLinkTextForContactAction");
			txtLinkTextForContactAction.Name = "txtLinkTextForContactAction";
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(txtAttributeNameForContactAction, "txtAttributeNameForContactAction");
			txtAttributeNameForContactAction.Name = "txtAttributeNameForContactAction";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(groupBox1);
			base.Controls.Add(cboEventTemplate);
			base.Controls.Add(label5);
			base.Controls.Add(cboAlign);
			base.Controls.Add(label4);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkDeleteable);
			base.Controls.Add(chkMultiline);
			base.Controls.Add(chkAutoSize);
			base.Controls.Add(txtText);
			base.Controls.Add(label3);
			base.Controls.Add(txtName);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgLabelElement";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgLabelElement_Load);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
