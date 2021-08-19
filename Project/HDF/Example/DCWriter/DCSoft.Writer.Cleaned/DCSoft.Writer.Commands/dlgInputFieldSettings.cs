using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       编辑文本输入域设置对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgInputFieldSettings : Form
	{
		private IContainer icontainer_0 = null;

		private RadioButton rdoText;

		private RadioButton rdoDropdownList;

		private GroupBox grbDropdownList;

		private CheckBox chkMultiSelect;

		private RadioButton rdoDate;

		private Button btnOK;

		private Button btnCancel;

		private RadioButton rdoDateTime;

		private Button btnBrowseListSource;

		private TextBox txtListSource;

		private Label label1;

		private ComboBox cboListValueSeparatorChar;

		private Label label2;

		private ComboBox txtListValueFormatString;

		private Label label19;

		private RadioButton rdoTime;

		private RadioButton rdoNumeric;

		private CheckBox chkDynamicListItems;

		private RadioButton rdoDateTimeWithoutSecond;

		private CheckBox chkGetValuesByTime;

		private CheckBox chkMultiColumn;

		private CheckBox chkRepulsionForGroup;

		private InputFieldSettings inputFieldSettings_0 = null;

		private XTextElement xtextElement_0 = null;

		/// <summary>
		///       当前编辑的设置信息对象
		///       </summary>
		public InputFieldSettings InputFieldSettings
		{
			get
			{
				return inputFieldSettings_0;
			}
			set
			{
				inputFieldSettings_0 = value;
			}
		}

		/// <summary>
		///       数据源元素
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgInputFieldSettings));
			rdoText = new System.Windows.Forms.RadioButton();
			rdoDropdownList = new System.Windows.Forms.RadioButton();
			grbDropdownList = new System.Windows.Forms.GroupBox();
			chkMultiColumn = new System.Windows.Forms.CheckBox();
			chkGetValuesByTime = new System.Windows.Forms.CheckBox();
			chkDynamicListItems = new System.Windows.Forms.CheckBox();
			cboListValueSeparatorChar = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			txtListValueFormatString = new System.Windows.Forms.ComboBox();
			label19 = new System.Windows.Forms.Label();
			btnBrowseListSource = new System.Windows.Forms.Button();
			txtListSource = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			chkMultiSelect = new System.Windows.Forms.CheckBox();
			rdoDate = new System.Windows.Forms.RadioButton();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			rdoDateTime = new System.Windows.Forms.RadioButton();
			rdoTime = new System.Windows.Forms.RadioButton();
			rdoNumeric = new System.Windows.Forms.RadioButton();
			rdoDateTimeWithoutSecond = new System.Windows.Forms.RadioButton();
			chkRepulsionForGroup = new System.Windows.Forms.CheckBox();
			grbDropdownList.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(rdoText, "rdoText");
			rdoText.Name = "rdoText";
			rdoText.TabStop = true;
			rdoText.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoDropdownList, "rdoDropdownList");
			rdoDropdownList.Name = "rdoDropdownList";
			rdoDropdownList.TabStop = true;
			rdoDropdownList.UseVisualStyleBackColor = true;
			rdoDropdownList.CheckedChanged += new System.EventHandler(rdoDropdownList_CheckedChanged);
			grbDropdownList.Controls.Add(chkRepulsionForGroup);
			grbDropdownList.Controls.Add(chkMultiColumn);
			grbDropdownList.Controls.Add(chkGetValuesByTime);
			grbDropdownList.Controls.Add(chkDynamicListItems);
			grbDropdownList.Controls.Add(cboListValueSeparatorChar);
			grbDropdownList.Controls.Add(label2);
			grbDropdownList.Controls.Add(txtListValueFormatString);
			grbDropdownList.Controls.Add(label19);
			grbDropdownList.Controls.Add(btnBrowseListSource);
			grbDropdownList.Controls.Add(txtListSource);
			grbDropdownList.Controls.Add(label1);
			grbDropdownList.Controls.Add(chkMultiSelect);
			resources.ApplyResources(grbDropdownList, "grbDropdownList");
			grbDropdownList.Name = "grbDropdownList";
			grbDropdownList.TabStop = false;
			resources.ApplyResources(chkMultiColumn, "chkMultiColumn");
			chkMultiColumn.Name = "chkMultiColumn";
			chkMultiColumn.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkGetValuesByTime, "chkGetValuesByTime");
			chkGetValuesByTime.Name = "chkGetValuesByTime";
			chkGetValuesByTime.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkDynamicListItems, "chkDynamicListItems");
			chkDynamicListItems.Name = "chkDynamicListItems";
			chkDynamicListItems.UseVisualStyleBackColor = true;
			cboListValueSeparatorChar.FormattingEnabled = true;
			cboListValueSeparatorChar.Items.AddRange(new object[5]
			{
				resources.GetString("cboListValueSeparatorChar.Items"),
				resources.GetString("cboListValueSeparatorChar.Items1"),
				resources.GetString("cboListValueSeparatorChar.Items2"),
				resources.GetString("cboListValueSeparatorChar.Items3"),
				resources.GetString("cboListValueSeparatorChar.Items4")
			});
			resources.ApplyResources(cboListValueSeparatorChar, "cboListValueSeparatorChar");
			cboListValueSeparatorChar.Name = "cboListValueSeparatorChar";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtListValueFormatString, "txtListValueFormatString");
			txtListValueFormatString.Name = "txtListValueFormatString";
			resources.ApplyResources(label19, "label19");
			label19.Name = "label19";
			resources.ApplyResources(btnBrowseListSource, "btnBrowseListSource");
			btnBrowseListSource.Name = "btnBrowseListSource";
			btnBrowseListSource.UseVisualStyleBackColor = true;
			btnBrowseListSource.Click += new System.EventHandler(btnBrowseListSource_Click);
			resources.ApplyResources(txtListSource, "txtListSource");
			txtListSource.Name = "txtListSource";
			txtListSource.ReadOnly = true;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(chkMultiSelect, "chkMultiSelect");
			chkMultiSelect.Name = "chkMultiSelect";
			chkMultiSelect.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoDate, "rdoDate");
			rdoDate.Name = "rdoDate";
			rdoDate.TabStop = true;
			rdoDate.UseVisualStyleBackColor = true;
			rdoDate.CheckedChanged += new System.EventHandler(rdoDate_CheckedChanged);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(rdoDateTime, "rdoDateTime");
			rdoDateTime.Name = "rdoDateTime";
			rdoDateTime.TabStop = true;
			rdoDateTime.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoTime, "rdoTime");
			rdoTime.Name = "rdoTime";
			rdoTime.TabStop = true;
			rdoTime.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoNumeric, "rdoNumeric");
			rdoNumeric.Name = "rdoNumeric";
			rdoNumeric.TabStop = true;
			rdoNumeric.UseVisualStyleBackColor = true;
			resources.ApplyResources(rdoDateTimeWithoutSecond, "rdoDateTimeWithoutSecond");
			rdoDateTimeWithoutSecond.Name = "rdoDateTimeWithoutSecond";
			rdoDateTimeWithoutSecond.TabStop = true;
			rdoDateTimeWithoutSecond.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkRepulsionForGroup, "chkRepulsionForGroup");
			chkRepulsionForGroup.Name = "chkRepulsionForGroup";
			chkRepulsionForGroup.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(rdoNumeric);
			base.Controls.Add(rdoTime);
			base.Controls.Add(rdoDateTimeWithoutSecond);
			base.Controls.Add(rdoDateTime);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(rdoDate);
			base.Controls.Add(rdoDropdownList);
			base.Controls.Add(rdoText);
			base.Controls.Add(grbDropdownList);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputFieldSettings";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInputFieldSettings_Load);
			grbDropdownList.ResumeLayout(false);
			grbDropdownList.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInputFieldSettings()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInputFieldSettings_Load(object sender, EventArgs e)
		{
			if (inputFieldSettings_0 == null)
			{
				inputFieldSettings_0 = new InputFieldSettings();
			}
			chkDynamicListItems.Checked = inputFieldSettings_0.DynamicListItems;
			rdoText.Checked = (inputFieldSettings_0.EditStyle == InputFieldEditStyle.Text);
			rdoDropdownList.Checked = (inputFieldSettings_0.EditStyle == InputFieldEditStyle.DropdownList);
			if (rdoDropdownList.Checked)
			{
				chkMultiSelect.Checked = inputFieldSettings_0.MultiSelect;
				txtListValueFormatString.Text = inputFieldSettings_0.ListValueFormatString;
				cboListValueSeparatorChar.Text = inputFieldSettings_0.ListValueSeparatorChar;
				if (inputFieldSettings_0.ListSource != null)
				{
					txtListSource.Text = inputFieldSettings_0.ListSource.ToString();
					txtListSource.Tag = inputFieldSettings_0.ListSource.Clone();
				}
			}
			rdoDate.Checked = (inputFieldSettings_0.EditStyle == InputFieldEditStyle.Date);
			rdoDateTime.Checked = (inputFieldSettings_0.EditStyle == InputFieldEditStyle.DateTime);
			rdoTime.Checked = (inputFieldSettings_0.EditStyle == InputFieldEditStyle.Time);
			rdoNumeric.Checked = (inputFieldSettings_0.EditStyle == InputFieldEditStyle.Numeric);
			rdoDateTimeWithoutSecond.Checked = (inputFieldSettings_0.EditStyle == InputFieldEditStyle.DateTimeWithoutSecond);
			chkGetValuesByTime.Checked = inputFieldSettings_0.GetValueOrderByTime;
			chkMultiColumn.Checked = inputFieldSettings_0.MultiColumn;
			chkRepulsionForGroup.Checked = inputFieldSettings_0.RepulsionForGroup;
			rdoDropdownList_CheckedChanged(null, null);
		}

		private void method_0(Control control_0, bool bool_0)
		{
			control_0.Enabled = bool_0;
			foreach (Control control in control_0.Controls)
			{
				control.Enabled = bool_0;
			}
		}

		private void rdoDropdownList_CheckedChanged(object sender, EventArgs e)
		{
			method_0(grbDropdownList, rdoDropdownList.Checked);
		}

		private void rdoDate_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			inputFieldSettings_0.EditStyle = InputFieldEditStyle.Text;
			inputFieldSettings_0.DynamicListItems = chkDynamicListItems.Checked;
			inputFieldSettings_0.GetValueOrderByTime = chkGetValuesByTime.Checked;
			inputFieldSettings_0.RepulsionForGroup = chkRepulsionForGroup.Checked;
			inputFieldSettings_0.MultiColumn = chkMultiColumn.Checked;
			if (rdoText.Checked)
			{
				inputFieldSettings_0.EditStyle = InputFieldEditStyle.Text;
			}
			else if (rdoDropdownList.Checked)
			{
				inputFieldSettings_0.EditStyle = InputFieldEditStyle.DropdownList;
				inputFieldSettings_0.MultiSelect = chkMultiSelect.Checked;
				inputFieldSettings_0.ListSource = (ListSourceInfo)txtListSource.Tag;
				inputFieldSettings_0.ListValueFormatString = txtListValueFormatString.Text.Trim();
				string text = cboListValueSeparatorChar.Text;
				if (text.Length > 0)
				{
					inputFieldSettings_0.ListValueSeparatorChar = text;
				}
			}
			else if (rdoDate.Checked)
			{
				inputFieldSettings_0.EditStyle = InputFieldEditStyle.Date;
			}
			else if (rdoDateTime.Checked)
			{
				inputFieldSettings_0.EditStyle = InputFieldEditStyle.DateTime;
			}
			else if (rdoDateTimeWithoutSecond.Checked)
			{
				inputFieldSettings_0.EditStyle = InputFieldEditStyle.DateTimeWithoutSecond;
			}
			else if (rdoTime.Checked)
			{
				inputFieldSettings_0.EditStyle = InputFieldEditStyle.Time;
			}
			else if (rdoNumeric.Checked)
			{
				inputFieldSettings_0.EditStyle = InputFieldEditStyle.Numeric;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnBrowseListSource_Click(object sender, EventArgs e)
		{
			using (dlgListSourceInfo dlgListSourceInfo = new dlgListSourceInfo())
			{
				dlgListSourceInfo.ListSource = (ListSourceInfo)txtListSource.Tag;
				dlgListSourceInfo.SourceElement = SourceElement;
				if (dlgListSourceInfo.ShowDialog(this) == DialogResult.OK)
				{
					txtListSource.Text = dlgListSourceInfo.ListSource.ToString();
					txtListSource.Tag = dlgListSourceInfo.ListSource;
				}
			}
		}
	}
}
