using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Dom.Design
{
	/// <summary>
	///       元素类型对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgElementTypeEditor : Form
	{
		private IContainer icontainer_0 = null;

		private CheckBox chkText;

		private CheckBox chkField;

		private CheckBox chkInputField;

		private CheckBox chkTable;

		private CheckBox chkObject;

		private CheckBox chkLineBreak;

		private CheckBox chkPageBreak;

		private CheckBox chkParagraphFlag;

		private CheckBox chkCheckBox;

		private CheckBox chkImage;

		private Button btnOK;

		private Button btnCancel;

		private GroupBox grbTypes;

		private RadioButton rdoAllType;

		private RadioButton rdoSpecifyType;

		private CheckBox chkButton;

		private ElementType elementType_0 = ElementType.All;

		/// <summary>
		///       输入输出的元素类型
		///       </summary>
		public ElementType InputElementType
		{
			get
			{
				return elementType_0;
			}
			set
			{
				elementType_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Dom.Design.dlgElementTypeEditor));
			chkText = new System.Windows.Forms.CheckBox();
			chkField = new System.Windows.Forms.CheckBox();
			chkInputField = new System.Windows.Forms.CheckBox();
			chkTable = new System.Windows.Forms.CheckBox();
			chkObject = new System.Windows.Forms.CheckBox();
			chkLineBreak = new System.Windows.Forms.CheckBox();
			chkPageBreak = new System.Windows.Forms.CheckBox();
			chkParagraphFlag = new System.Windows.Forms.CheckBox();
			chkCheckBox = new System.Windows.Forms.CheckBox();
			chkImage = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			grbTypes = new System.Windows.Forms.GroupBox();
			rdoAllType = new System.Windows.Forms.RadioButton();
			rdoSpecifyType = new System.Windows.Forms.RadioButton();
			chkButton = new System.Windows.Forms.CheckBox();
			grbTypes.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(chkText, "chkText");
			chkText.Name = "chkText";
			chkText.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkField, "chkField");
			chkField.Name = "chkField";
			chkField.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkInputField, "chkInputField");
			chkInputField.Name = "chkInputField";
			chkInputField.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkTable, "chkTable");
			chkTable.Name = "chkTable";
			chkTable.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkObject, "chkObject");
			chkObject.Name = "chkObject";
			chkObject.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkLineBreak, "chkLineBreak");
			chkLineBreak.Name = "chkLineBreak";
			chkLineBreak.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkPageBreak, "chkPageBreak");
			chkPageBreak.Name = "chkPageBreak";
			chkPageBreak.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkParagraphFlag, "chkParagraphFlag");
			chkParagraphFlag.Name = "chkParagraphFlag";
			chkParagraphFlag.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkCheckBox, "chkCheckBox");
			chkCheckBox.Name = "chkCheckBox";
			chkCheckBox.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkImage, "chkImage");
			chkImage.Name = "chkImage";
			chkImage.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			grbTypes.Controls.Add(chkPageBreak);
			grbTypes.Controls.Add(chkField);
			grbTypes.Controls.Add(chkText);
			grbTypes.Controls.Add(chkLineBreak);
			grbTypes.Controls.Add(chkButton);
			grbTypes.Controls.Add(chkObject);
			grbTypes.Controls.Add(chkImage);
			grbTypes.Controls.Add(chkParagraphFlag);
			grbTypes.Controls.Add(chkInputField);
			grbTypes.Controls.Add(chkTable);
			grbTypes.Controls.Add(chkCheckBox);
			resources.ApplyResources(grbTypes, "grbTypes");
			grbTypes.Name = "grbTypes";
			grbTypes.TabStop = false;
			resources.ApplyResources(rdoAllType, "rdoAllType");
			rdoAllType.Name = "rdoAllType";
			rdoAllType.TabStop = true;
			rdoAllType.UseVisualStyleBackColor = true;
			rdoAllType.CheckedChanged += new System.EventHandler(rdoAllType_CheckedChanged);
			resources.ApplyResources(rdoSpecifyType, "rdoSpecifyType");
			rdoSpecifyType.Name = "rdoSpecifyType";
			rdoSpecifyType.TabStop = true;
			rdoSpecifyType.UseVisualStyleBackColor = true;
			rdoSpecifyType.CheckedChanged += new System.EventHandler(rdoSpecifyType_CheckedChanged);
			resources.ApplyResources(chkButton, "chkButton");
			chkButton.Name = "chkButton";
			chkButton.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(rdoSpecifyType);
			base.Controls.Add(rdoAllType);
			base.Controls.Add(grbTypes);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgElementTypeEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgElementTypeEditor_Load);
			grbTypes.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgElementTypeEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgElementTypeEditor_Load(object sender, EventArgs e)
		{
			if (elementType_0 == ElementType.All)
			{
				rdoAllType.Checked = true;
				rdoSpecifyType.Checked = false;
				return;
			}
			rdoAllType.Checked = false;
			rdoSpecifyType.Checked = true;
			chkCheckBox.Checked = ((elementType_0 & ElementType.CheckRadioBox) == ElementType.CheckRadioBox);
			chkField.Checked = ((elementType_0 & ElementType.Field) == ElementType.Field);
			chkImage.Checked = ((elementType_0 & ElementType.Image) == ElementType.Image);
			chkInputField.Checked = ((elementType_0 & ElementType.InputField) == ElementType.InputField);
			chkLineBreak.Checked = ((elementType_0 & ElementType.LineBreak) == ElementType.LineBreak);
			chkObject.Checked = ((elementType_0 & ElementType.Object) == ElementType.Object);
			chkPageBreak.Checked = ((elementType_0 & ElementType.PageBreak) == ElementType.PageBreak);
			chkParagraphFlag.Checked = ((elementType_0 & ElementType.ParagraphFlag) == ElementType.ParagraphFlag);
			chkTable.Checked = ((elementType_0 & ElementType.Table) == ElementType.Table);
			chkText.Checked = ((elementType_0 & ElementType.Text) == ElementType.Text);
			chkButton.Checked = ((elementType_0 & ElementType.Button) == ElementType.Button);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (rdoAllType.Checked)
			{
				elementType_0 = ElementType.All;
			}
			else
			{
				elementType_0 = ElementType.None;
				if (chkCheckBox.Checked)
				{
					elementType_0 |= ElementType.CheckRadioBox;
				}
				if (chkField.Checked)
				{
					elementType_0 |= ElementType.Field;
				}
				if (chkImage.Checked)
				{
					elementType_0 |= ElementType.Image;
				}
				if (chkInputField.Checked)
				{
					elementType_0 |= ElementType.InputField;
				}
				if (chkLineBreak.Checked)
				{
					elementType_0 |= ElementType.LineBreak;
				}
				if (chkObject.Checked)
				{
					elementType_0 |= ElementType.Object;
				}
				if (chkPageBreak.Checked)
				{
					elementType_0 |= ElementType.PageBreak;
				}
				if (chkParagraphFlag.Checked)
				{
					elementType_0 |= ElementType.ParagraphFlag;
				}
				if (chkTable.Checked)
				{
					elementType_0 |= ElementType.Table;
				}
				if (chkText.Checked)
				{
					elementType_0 |= ElementType.Text;
				}
				if (chkButton.Checked)
				{
					elementType_0 |= ElementType.Button;
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void rdoAllType_CheckedChanged(object sender, EventArgs e)
		{
			grbTypes.Enabled = rdoSpecifyType.Checked;
		}

		private void rdoSpecifyType_CheckedChanged(object sender, EventArgs e)
		{
			grbTypes.Enabled = rdoSpecifyType.Checked;
		}
	}
}
