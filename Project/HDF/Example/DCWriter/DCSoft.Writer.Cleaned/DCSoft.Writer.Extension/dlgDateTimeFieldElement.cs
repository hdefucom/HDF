using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       时间输入域属性对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgDateTimeFieldElement : Form
	{
		private XTextInputFieldElement xtextInputFieldElement_0 = null;

		private bool bool_0 = false;

		private IContainer icontainer_0 = null;

		private ComboBox cboEncryptLevel;

		private ComboBox cboInputStyle;

		private ComboBox cboEnableHighlight;

		private Button btnCancel;

		private Button btnOK;

		private CheckBox chkUserEditable;

		private CheckBox chkMustInput;

		private CheckBox chkDeleteable;

		private CheckBox chkReadonly;

		private Label label3;

		private Label label15;

		private Label label12;

		private TextBox txtID;

		private Label label6;

		private TextBox txtBackgroundText;

		private Label label9;

		private TextBox txtToolTip;

		private Label label8;

		private TextBox txtName;

		private Label label16;

		private Panel panel1;

		/// <summary>
		///       输入域对象
		///       </summary>
		public XTextInputFieldElement InputFieldElement
		{
			get
			{
				return xtextInputFieldElement_0;
			}
			set
			{
				xtextInputFieldElement_0 = value;
			}
		}

		/// <summary>
		///       是否记录撤销信息
		///       </summary>
		public bool LogUndo
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public static bool smethod_0(XTextInputFieldElement xtextInputFieldElement_1)
		{
			if (xtextInputFieldElement_1 == null || xtextInputFieldElement_1.FieldSettings == null)
			{
				return false;
			}
			return xtextInputFieldElement_1.FieldSettings.EditStyle == InputFieldEditStyle.Date || xtextInputFieldElement_1.FieldSettings.EditStyle == InputFieldEditStyle.DateTime || xtextInputFieldElement_1.FieldSettings.EditStyle == InputFieldEditStyle.DateTimeWithoutSecond;
		}

		/// <summary>
		///       初始化对象
		///        </summary>
		public dlgDateTimeFieldElement()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 17;
			XTextDocument xTextDocument = (xtextInputFieldElement_0 == null) ? null : xtextInputFieldElement_0.OwnerDocument;
			bool flag = LogUndo && xtextInputFieldElement_0 != null && xtextInputFieldElement_0.OwnerDocument != null && xtextInputFieldElement_0.OwnerDocument.CanLogUndo;
			if (!string.IsNullOrEmpty(txtID.Text))
			{
				if (flag)
				{
					xTextDocument.UndoList.AddProperty("ID", xtextInputFieldElement_0.ID, txtID.Text, xtextInputFieldElement_0);
				}
				xtextInputFieldElement_0.ID = txtID.Text;
			}
			if (!string.IsNullOrEmpty(txtName.Text))
			{
				if (flag)
				{
					xTextDocument.UndoList.AddProperty("Name", xtextInputFieldElement_0.Name, txtName.Text, xtextInputFieldElement_0);
				}
				xtextInputFieldElement_0.Name = txtName.Text;
			}
			if (!string.IsNullOrEmpty(txtToolTip.Text))
			{
				if (flag)
				{
					xTextDocument.UndoList.AddProperty("ToolTip", xtextInputFieldElement_0.ToolTip, txtToolTip.Text, xtextInputFieldElement_0);
				}
				xtextInputFieldElement_0.ToolTip = txtToolTip.Text;
			}
			if (!string.IsNullOrEmpty(txtBackgroundText.Text))
			{
				if (flag)
				{
					xTextDocument.UndoList.AddProperty("BackgroundText", xtextInputFieldElement_0.BackgroundText, txtBackgroundText.Text, xtextInputFieldElement_0);
				}
				xtextInputFieldElement_0.BackgroundText = txtBackgroundText.Text;
			}
			ContentReadonlyState contentReadonlyState = (!chkReadonly.Checked) ? ContentReadonlyState.Inherit : ContentReadonlyState.True;
			if (xtextInputFieldElement_0.ContentReadonly != contentReadonlyState)
			{
				if (flag)
				{
					xTextDocument.UndoList.AddProperty("ContentReadonly", xtextInputFieldElement_0.ContentReadonly, contentReadonlyState, xtextInputFieldElement_0);
				}
				xtextInputFieldElement_0.ContentReadonly = contentReadonlyState;
			}
			if (xtextInputFieldElement_0.UserEditable != chkUserEditable.Checked)
			{
				if (flag)
				{
					xTextDocument.UndoList.AddProperty("UserEditable", xtextInputFieldElement_0.UserEditable, chkUserEditable.Checked, xtextInputFieldElement_0);
				}
				xtextInputFieldElement_0.UserEditable = chkUserEditable.Checked;
			}
			if (xtextInputFieldElement_0.Deleteable != chkDeleteable.Checked)
			{
				if (flag)
				{
					xTextDocument.UndoList.AddProperty("Deleteable", xtextInputFieldElement_0.Deleteable, chkDeleteable.Checked, xtextInputFieldElement_0);
				}
				xtextInputFieldElement_0.Deleteable = chkDeleteable.Checked;
			}
			ValueValidateStyle valueValidateStyle = new ValueValidateStyle();
			valueValidateStyle.Required = chkMustInput.Checked;
			if (flag)
			{
				xTextDocument.UndoList.AddProperty("ValidateStyle", xtextInputFieldElement_0.ValidateStyle, valueValidateStyle, xtextInputFieldElement_0);
			}
			xtextInputFieldElement_0.ValidateStyle = valueValidateStyle;
			string text = cboInputStyle.Text;
			ValueFormater valueFormater = new ValueFormater();
			if (!string.IsNullOrEmpty(text))
			{
				valueFormater = new ValueFormater(ValueFormatStyle.DateTime, text);
			}
			if (flag)
			{
				xTextDocument.UndoList.AddProperty("DisplayFormat", xtextInputFieldElement_0.DisplayFormat, valueFormater, xtextInputFieldElement_0);
			}
			xtextInputFieldElement_0.DisplayFormat = valueFormater;
			if (xtextInputFieldElement_0.BackgroundText != cboInputStyle.Text)
			{
				if (flag)
				{
					xTextDocument.UndoList.AddProperty("BackgroundText", xtextInputFieldElement_0.BackgroundText, cboInputStyle.Text, xtextInputFieldElement_0);
				}
				xtextInputFieldElement_0.BackgroundText = cboInputStyle.Text;
			}
			string selectedText = cboEnableHighlight.SelectedText;
			if (!string.IsNullOrEmpty(selectedText))
			{
				method_1(selectedText);
			}
			string selectedText2 = cboEncryptLevel.SelectedText;
			if (!string.IsNullOrEmpty(selectedText2))
			{
				method_0(selectedText2);
			}
			InputFieldSettings inputFieldSettings = new InputFieldSettings();
			inputFieldSettings.EditStyle = WriterTools.GetEditStyleByDateTimeFormatString(cboInputStyle.Text);
			if (flag)
			{
				xTextDocument.UndoList.AddProperty("FieldSettings", xtextInputFieldElement_0.FieldSettings, inputFieldSettings, xtextInputFieldElement_0);
			}
			xtextInputFieldElement_0.FieldSettings = inputFieldSettings;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void method_0(string string_0)
		{
			int num = 6;
			switch (string_0)
			{
			case "不加密":
				xtextInputFieldElement_0.ViewEncryptType = ContentViewEncryptType.None;
				break;
			case "部分加密":
				xtextInputFieldElement_0.ViewEncryptType = ContentViewEncryptType.Partial;
				break;
			case "全部加密":
				xtextInputFieldElement_0.ViewEncryptType = ContentViewEncryptType.Both;
				break;
			}
		}

		private void method_1(string string_0)
		{
			int num = 7;
			switch (string_0)
			{
			case "默认":
				xtextInputFieldElement_0.EnableHighlight = EnableState.Default;
				break;
			case "允许":
				xtextInputFieldElement_0.EnableHighlight = EnableState.Enabled;
				break;
			case "禁止":
				xtextInputFieldElement_0.EnableHighlight = EnableState.Disabled;
				break;
			}
		}

		private void dlgDateTimeFieldElement_Load(object sender, EventArgs e)
		{
			cboInputStyle.SelectedIndex = 0;
			cboEnableHighlight.SelectedIndex = 0;
			cboEncryptLevel.SelectedIndex = 0;
			if (xtextInputFieldElement_0 == null)
			{
				return;
			}
			txtID.Text = xtextInputFieldElement_0.ID;
			txtName.Text = xtextInputFieldElement_0.Name;
			txtBackgroundText.Text = xtextInputFieldElement_0.BackgroundText;
			txtToolTip.Text = xtextInputFieldElement_0.ToolTip;
			chkReadonly.Checked = (xtextInputFieldElement_0.ContentReadonly == ContentReadonlyState.True);
			chkDeleteable.Checked = xtextInputFieldElement_0.Deleteable;
			chkUserEditable.Checked = xtextInputFieldElement_0.UserEditable;
			if (xtextInputFieldElement_0.ValidateStyle != null)
			{
				if (xtextInputFieldElement_0.ValidateStyle.Required)
				{
					chkMustInput.Checked = true;
				}
				else
				{
					chkMustInput.Checked = false;
				}
			}
			if (xtextInputFieldElement_0.DisplayFormat != null)
			{
				cboInputStyle.Text = xtextInputFieldElement_0.DisplayFormat.Format;
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgDateTimeFieldElement));
			cboEncryptLevel = new System.Windows.Forms.ComboBox();
			cboInputStyle = new System.Windows.Forms.ComboBox();
			cboEnableHighlight = new System.Windows.Forms.ComboBox();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			chkUserEditable = new System.Windows.Forms.CheckBox();
			chkMustInput = new System.Windows.Forms.CheckBox();
			chkDeleteable = new System.Windows.Forms.CheckBox();
			chkReadonly = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			txtBackgroundText = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			txtToolTip = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label16 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			cboEncryptLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboEncryptLevel.FormattingEnabled = true;
			cboEncryptLevel.Items.AddRange(new object[3]
			{
				resources.GetString("cboEncryptLevel.Items"),
				resources.GetString("cboEncryptLevel.Items1"),
				resources.GetString("cboEncryptLevel.Items2")
			});
			resources.ApplyResources(cboEncryptLevel, "cboEncryptLevel");
			cboEncryptLevel.Name = "cboEncryptLevel";
			resources.ApplyResources(cboInputStyle, "cboInputStyle");
			cboInputStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			cboInputStyle.FormattingEnabled = true;
			cboInputStyle.Items.AddRange(new object[13]
			{
				resources.GetString("cboInputStyle.Items"),
				resources.GetString("cboInputStyle.Items1"),
				resources.GetString("cboInputStyle.Items2"),
				resources.GetString("cboInputStyle.Items3"),
				resources.GetString("cboInputStyle.Items4"),
				resources.GetString("cboInputStyle.Items5"),
				resources.GetString("cboInputStyle.Items6"),
				resources.GetString("cboInputStyle.Items7"),
				resources.GetString("cboInputStyle.Items8"),
				resources.GetString("cboInputStyle.Items9"),
				resources.GetString("cboInputStyle.Items10"),
				resources.GetString("cboInputStyle.Items11"),
				resources.GetString("cboInputStyle.Items12")
			});
			cboInputStyle.Name = "cboInputStyle";
			cboEnableHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboEnableHighlight.FormattingEnabled = true;
			cboEnableHighlight.Items.AddRange(new object[3]
			{
				resources.GetString("cboEnableHighlight.Items"),
				resources.GetString("cboEnableHighlight.Items1"),
				resources.GetString("cboEnableHighlight.Items2")
			});
			resources.ApplyResources(cboEnableHighlight, "cboEnableHighlight");
			cboEnableHighlight.Name = "cboEnableHighlight";
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(chkUserEditable, "chkUserEditable");
			chkUserEditable.Name = "chkUserEditable";
			chkUserEditable.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkMustInput, "chkMustInput");
			chkMustInput.Name = "chkMustInput";
			chkMustInput.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkDeleteable, "chkDeleteable");
			chkDeleteable.Name = "chkDeleteable";
			chkDeleteable.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkReadonly, "chkReadonly");
			chkReadonly.Name = "chkReadonly";
			chkReadonly.UseVisualStyleBackColor = true;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(label15, "label15");
			label15.Name = "label15";
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(txtBackgroundText, "txtBackgroundText");
			txtBackgroundText.Name = "txtBackgroundText";
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			resources.ApplyResources(txtToolTip, "txtToolTip");
			txtToolTip.Name = "txtToolTip";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(label16, "label16");
			label16.Name = "label16";
			panel1.Controls.Add(cboInputStyle);
			resources.ApplyResources(panel1, "panel1");
			panel1.Name = "panel1";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(panel1);
			base.Controls.Add(cboEncryptLevel);
			base.Controls.Add(cboEnableHighlight);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkUserEditable);
			base.Controls.Add(chkMustInput);
			base.Controls.Add(chkDeleteable);
			base.Controls.Add(chkReadonly);
			base.Controls.Add(label3);
			base.Controls.Add(label15);
			base.Controls.Add(label12);
			base.Controls.Add(txtID);
			base.Controls.Add(label6);
			base.Controls.Add(txtBackgroundText);
			base.Controls.Add(label9);
			base.Controls.Add(txtToolTip);
			base.Controls.Add(label8);
			base.Controls.Add(txtName);
			base.Controls.Add(label16);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "dlgDateTimeFieldElement";
			base.Load += new System.EventHandler(dlgDateTimeFieldElement_Load);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
