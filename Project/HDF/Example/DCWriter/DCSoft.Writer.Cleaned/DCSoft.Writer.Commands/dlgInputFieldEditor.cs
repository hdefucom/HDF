using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Data.WinForms;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Design;
using DCSoft.Writer.Expression;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文本输入域属性对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgInputFieldEditor : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtName;

		private Label label2;

		private TextBox txtValidate;

		private Button btnBrowseValidate;

		private Button btnOK;

		private Button btnCancel;

		private Label label3;

		private TextBox txtSettings;

		private Button btnBrowseSettings;

		private Label label4;

		private TextBox txtBinding;

		private Button btnBrowseBinding;

		private Label label5;

		private TextBox txtAttributes;

		private Button btnBrowseAttributes;

		private Label label6;

		private TextBox txtID;

		private Label label7;

		private TextBox txtDisplayFormat;

		private Button btnBrowseDisplayFormat;

		private CheckBox chkUserEditable;

		private Label label8;

		private TextBox txtToolTip;

		private Label label9;

		private TextBox txtBackgroundText;

		private Label label10;

		private TextBox txtAcceptElementType;

		private Button btnBrowseAcceptElementType;

		private Label label11;

		private TextBox txtDefaultEventExpression;

		private Label label12;

		private ComboBox cboEnableHighlight;

		private Label label13;

		private TextBox txtEventExpressions;

		private Button btnBrowseEventExpressions;

		private Label label14;

		private NumericUpDown txtSpecifyWidth;

		private CheckBox chkDeleteable;

		private Label label15;

		private ComboBox cboEncryptLevel;

		private Label label16;

		private TextBox txtUnitText;

		private Label label17;

		private Button btnEditorActiveMode;

		private Label label18;

		private ComboBox cboMoveFocusHotKey;

		private Label label19;

		private TextBox txtLabel;

		private Label label20;

		private TextBox txtCopySource;

		private Button btnBrowseCopySource;

		private CheckBox chkEnableFieldTextColor;

		private CheckBox chkTabStop;

		private Label label21;

		private ComboBox cboContentReadonly;

		private Label label22;

		private TextBox txtUserFlags;

		private TextBox txtValueExpression;

		private Label label23;

		private Label label24;

		private ComboBox cboAutoHideMode;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TextBox txtEditorControlTypeName;

		private Label label25;

		private TextBox txtVisibleExpression;

		private Label label26;

		private TextBox txtEndBorderText;

		private Label label27;

		private TextBox txtStartBorderText;

		private Label label28;

		private ComboBox cboBorderVisible;

		private Label label29;

		private ComboBox cboAlignment;

		private Label label30;

		private ComboBox cboDefaultValueType;

		private Label label31;

		private Button btnBrowseMemberExpressions;

		private Label label32;

		private TextBox txtMemberExpressions;

		private TextBox txtDefaultSelectedIndexs;

		private Label label33;

		private ToolTip toolTip_0;

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
			icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgInputFieldEditor));
			label1 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtValidate = new System.Windows.Forms.TextBox();
			btnBrowseValidate = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			txtSettings = new System.Windows.Forms.TextBox();
			btnBrowseSettings = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			txtBinding = new System.Windows.Forms.TextBox();
			btnBrowseBinding = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			txtAttributes = new System.Windows.Forms.TextBox();
			btnBrowseAttributes = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			txtDisplayFormat = new System.Windows.Forms.TextBox();
			btnBrowseDisplayFormat = new System.Windows.Forms.Button();
			chkUserEditable = new System.Windows.Forms.CheckBox();
			label8 = new System.Windows.Forms.Label();
			txtToolTip = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			txtBackgroundText = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			txtAcceptElementType = new System.Windows.Forms.TextBox();
			btnBrowseAcceptElementType = new System.Windows.Forms.Button();
			label11 = new System.Windows.Forms.Label();
			txtDefaultEventExpression = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			cboEnableHighlight = new System.Windows.Forms.ComboBox();
			label13 = new System.Windows.Forms.Label();
			txtEventExpressions = new System.Windows.Forms.TextBox();
			btnBrowseEventExpressions = new System.Windows.Forms.Button();
			label14 = new System.Windows.Forms.Label();
			txtSpecifyWidth = new System.Windows.Forms.NumericUpDown();
			chkDeleteable = new System.Windows.Forms.CheckBox();
			label15 = new System.Windows.Forms.Label();
			cboEncryptLevel = new System.Windows.Forms.ComboBox();
			label16 = new System.Windows.Forms.Label();
			txtUnitText = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			btnEditorActiveMode = new System.Windows.Forms.Button();
			label18 = new System.Windows.Forms.Label();
			cboMoveFocusHotKey = new System.Windows.Forms.ComboBox();
			label19 = new System.Windows.Forms.Label();
			txtLabel = new System.Windows.Forms.TextBox();
			label20 = new System.Windows.Forms.Label();
			txtCopySource = new System.Windows.Forms.TextBox();
			btnBrowseCopySource = new System.Windows.Forms.Button();
			chkEnableFieldTextColor = new System.Windows.Forms.CheckBox();
			chkTabStop = new System.Windows.Forms.CheckBox();
			label21 = new System.Windows.Forms.Label();
			cboContentReadonly = new System.Windows.Forms.ComboBox();
			label22 = new System.Windows.Forms.Label();
			txtUserFlags = new System.Windows.Forms.TextBox();
			txtValueExpression = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			cboAutoHideMode = new System.Windows.Forms.ComboBox();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			cboDefaultValueType = new System.Windows.Forms.ComboBox();
			label31 = new System.Windows.Forms.Label();
			cboAlignment = new System.Windows.Forms.ComboBox();
			label30 = new System.Windows.Forms.Label();
			txtEndBorderText = new System.Windows.Forms.TextBox();
			label27 = new System.Windows.Forms.Label();
			txtStartBorderText = new System.Windows.Forms.TextBox();
			label28 = new System.Windows.Forms.Label();
			txtEditorControlTypeName = new System.Windows.Forms.TextBox();
			txtVisibleExpression = new System.Windows.Forms.TextBox();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			cboBorderVisible = new System.Windows.Forms.ComboBox();
			label29 = new System.Windows.Forms.Label();
			tabPage2 = new System.Windows.Forms.TabPage();
			btnBrowseMemberExpressions = new System.Windows.Forms.Button();
			label32 = new System.Windows.Forms.Label();
			txtMemberExpressions = new System.Windows.Forms.TextBox();
			label33 = new System.Windows.Forms.Label();
			txtDefaultSelectedIndexs = new System.Windows.Forms.TextBox();
			toolTip_0 = new System.Windows.Forms.ToolTip(icontainer_0);
			((System.ComponentModel.ISupportInitialize)txtSpecifyWidth).BeginInit();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			txtName.TextChanged += new System.EventHandler(txtLabel_TextChanged);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtValidate, "txtValidate");
			txtValidate.Name = "txtValidate";
			txtValidate.ReadOnly = true;
			resources.ApplyResources(btnBrowseValidate, "btnBrowseValidate");
			btnBrowseValidate.Name = "btnBrowseValidate";
			btnBrowseValidate.UseVisualStyleBackColor = true;
			btnBrowseValidate.Click += new System.EventHandler(btnBrowseValidate_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtSettings, "txtSettings");
			txtSettings.Name = "txtSettings";
			txtSettings.ReadOnly = true;
			resources.ApplyResources(btnBrowseSettings, "btnBrowseSettings");
			btnBrowseSettings.Name = "btnBrowseSettings";
			btnBrowseSettings.UseVisualStyleBackColor = true;
			btnBrowseSettings.Click += new System.EventHandler(btnBrowseSettings_Click);
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(txtBinding, "txtBinding");
			txtBinding.Name = "txtBinding";
			txtBinding.ReadOnly = true;
			resources.ApplyResources(btnBrowseBinding, "btnBrowseBinding");
			btnBrowseBinding.Name = "btnBrowseBinding";
			btnBrowseBinding.UseVisualStyleBackColor = true;
			btnBrowseBinding.Click += new System.EventHandler(btnBrowseBinding_Click);
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(txtAttributes, "txtAttributes");
			txtAttributes.Name = "txtAttributes";
			txtAttributes.ReadOnly = true;
			resources.ApplyResources(btnBrowseAttributes, "btnBrowseAttributes");
			btnBrowseAttributes.Name = "btnBrowseAttributes";
			btnBrowseAttributes.UseVisualStyleBackColor = true;
			btnBrowseAttributes.Click += new System.EventHandler(btnBrowseAttributes_Click);
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			txtID.TextChanged += new System.EventHandler(txtLabel_TextChanged);
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(txtDisplayFormat, "txtDisplayFormat");
			txtDisplayFormat.Name = "txtDisplayFormat";
			txtDisplayFormat.ReadOnly = true;
			resources.ApplyResources(btnBrowseDisplayFormat, "btnBrowseDisplayFormat");
			btnBrowseDisplayFormat.Name = "btnBrowseDisplayFormat";
			btnBrowseDisplayFormat.UseVisualStyleBackColor = true;
			btnBrowseDisplayFormat.Click += new System.EventHandler(btnBrowseDisplayFormat_Click);
			resources.ApplyResources(chkUserEditable, "chkUserEditable");
			chkUserEditable.Name = "chkUserEditable";
			chkUserEditable.UseVisualStyleBackColor = true;
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(txtToolTip, "txtToolTip");
			txtToolTip.Name = "txtToolTip";
			txtToolTip.TextChanged += new System.EventHandler(txtLabel_TextChanged);
			resources.ApplyResources(label9, "label9");
			label9.Name = "label9";
			resources.ApplyResources(txtBackgroundText, "txtBackgroundText");
			txtBackgroundText.Name = "txtBackgroundText";
			txtBackgroundText.TextChanged += new System.EventHandler(txtLabel_TextChanged);
			resources.ApplyResources(label10, "label10");
			label10.Name = "label10";
			resources.ApplyResources(txtAcceptElementType, "txtAcceptElementType");
			txtAcceptElementType.Name = "txtAcceptElementType";
			txtAcceptElementType.ReadOnly = true;
			resources.ApplyResources(btnBrowseAcceptElementType, "btnBrowseAcceptElementType");
			btnBrowseAcceptElementType.Name = "btnBrowseAcceptElementType";
			btnBrowseAcceptElementType.UseVisualStyleBackColor = true;
			btnBrowseAcceptElementType.Click += new System.EventHandler(btnBrowseAcceptElementType_Click);
			resources.ApplyResources(label11, "label11");
			label11.Name = "label11";
			label11.Click += new System.EventHandler(label11_Click);
			resources.ApplyResources(txtDefaultEventExpression, "txtDefaultEventExpression");
			txtDefaultEventExpression.Name = "txtDefaultEventExpression";
			txtDefaultEventExpression.TextChanged += new System.EventHandler(txtLabel_TextChanged);
			resources.ApplyResources(label12, "label12");
			label12.Name = "label12";
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
			resources.ApplyResources(label13, "label13");
			label13.Name = "label13";
			resources.ApplyResources(txtEventExpressions, "txtEventExpressions");
			txtEventExpressions.Name = "txtEventExpressions";
			txtEventExpressions.ReadOnly = true;
			resources.ApplyResources(btnBrowseEventExpressions, "btnBrowseEventExpressions");
			btnBrowseEventExpressions.Name = "btnBrowseEventExpressions";
			btnBrowseEventExpressions.UseVisualStyleBackColor = true;
			btnBrowseEventExpressions.Click += new System.EventHandler(btnBrowseEventExpressions_Click);
			resources.ApplyResources(label14, "label14");
			label14.Name = "label14";
			txtSpecifyWidth.DecimalPlaces = 2;
			resources.ApplyResources(txtSpecifyWidth, "txtSpecifyWidth");
			txtSpecifyWidth.Minimum = new decimal(new int[4]
			{
				100,
				0,
				0,
				-2147483648
			});
			txtSpecifyWidth.Name = "txtSpecifyWidth";
			resources.ApplyResources(chkDeleteable, "chkDeleteable");
			chkDeleteable.Name = "chkDeleteable";
			chkDeleteable.UseVisualStyleBackColor = true;
			resources.ApplyResources(label15, "label15");
			label15.Name = "label15";
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
			resources.ApplyResources(label16, "label16");
			label16.Name = "label16";
			resources.ApplyResources(txtUnitText, "txtUnitText");
			txtUnitText.Name = "txtUnitText";
			txtUnitText.TextChanged += new System.EventHandler(txtLabel_TextChanged);
			resources.ApplyResources(label17, "label17");
			label17.Name = "label17";
			resources.ApplyResources(btnEditorActiveMode, "btnEditorActiveMode");
			btnEditorActiveMode.Name = "btnEditorActiveMode";
			btnEditorActiveMode.UseVisualStyleBackColor = true;
			btnEditorActiveMode.Click += new System.EventHandler(btnEditorActiveMode_Click);
			resources.ApplyResources(label18, "label18");
			label18.Name = "label18";
			cboMoveFocusHotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboMoveFocusHotKey.FormattingEnabled = true;
			resources.ApplyResources(cboMoveFocusHotKey, "cboMoveFocusHotKey");
			cboMoveFocusHotKey.Name = "cboMoveFocusHotKey";
			resources.ApplyResources(label19, "label19");
			label19.Name = "label19";
			resources.ApplyResources(txtLabel, "txtLabel");
			txtLabel.Name = "txtLabel";
			txtLabel.TextChanged += new System.EventHandler(txtLabel_TextChanged);
			resources.ApplyResources(label20, "label20");
			label20.Name = "label20";
			resources.ApplyResources(txtCopySource, "txtCopySource");
			txtCopySource.Name = "txtCopySource";
			txtCopySource.ReadOnly = true;
			resources.ApplyResources(btnBrowseCopySource, "btnBrowseCopySource");
			btnBrowseCopySource.Name = "btnBrowseCopySource";
			btnBrowseCopySource.UseVisualStyleBackColor = true;
			btnBrowseCopySource.Click += new System.EventHandler(btnBrowseCopySource_Click);
			resources.ApplyResources(chkEnableFieldTextColor, "chkEnableFieldTextColor");
			chkEnableFieldTextColor.Name = "chkEnableFieldTextColor";
			chkEnableFieldTextColor.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkTabStop, "chkTabStop");
			chkTabStop.Name = "chkTabStop";
			chkTabStop.UseVisualStyleBackColor = true;
			resources.ApplyResources(label21, "label21");
			label21.Name = "label21";
			cboContentReadonly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboContentReadonly.FormattingEnabled = true;
			cboContentReadonly.Items.AddRange(new object[3]
			{
				resources.GetString("cboContentReadonly.Items"),
				resources.GetString("cboContentReadonly.Items1"),
				resources.GetString("cboContentReadonly.Items2")
			});
			resources.ApplyResources(cboContentReadonly, "cboContentReadonly");
			cboContentReadonly.Name = "cboContentReadonly";
			resources.ApplyResources(label22, "label22");
			label22.Name = "label22";
			resources.ApplyResources(txtUserFlags, "txtUserFlags");
			txtUserFlags.Name = "txtUserFlags";
			resources.ApplyResources(txtValueExpression, "txtValueExpression");
			txtValueExpression.Name = "txtValueExpression";
			resources.ApplyResources(label23, "label23");
			label23.Name = "label23";
			resources.ApplyResources(label24, "label24");
			label24.Name = "label24";
			cboAutoHideMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboAutoHideMode.FormattingEnabled = true;
			cboAutoHideMode.Items.AddRange(new object[3]
			{
				resources.GetString("cboAutoHideMode.Items"),
				resources.GetString("cboAutoHideMode.Items1"),
				resources.GetString("cboAutoHideMode.Items2")
			});
			resources.ApplyResources(cboAutoHideMode, "cboAutoHideMode");
			cboAutoHideMode.Name = "cboAutoHideMode";
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			resources.ApplyResources(tabControl1, "tabControl1");
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabPage1.Controls.Add(cboDefaultValueType);
			tabPage1.Controls.Add(label31);
			tabPage1.Controls.Add(cboAlignment);
			tabPage1.Controls.Add(label30);
			tabPage1.Controls.Add(txtEndBorderText);
			tabPage1.Controls.Add(label27);
			tabPage1.Controls.Add(txtStartBorderText);
			tabPage1.Controls.Add(label28);
			tabPage1.Controls.Add(label6);
			tabPage1.Controls.Add(cboAutoHideMode);
			tabPage1.Controls.Add(label1);
			tabPage1.Controls.Add(label24);
			tabPage1.Controls.Add(label16);
			tabPage1.Controls.Add(txtDefaultSelectedIndexs);
			tabPage1.Controls.Add(txtEditorControlTypeName);
			tabPage1.Controls.Add(txtVisibleExpression);
			tabPage1.Controls.Add(label33);
			tabPage1.Controls.Add(txtValueExpression);
			tabPage1.Controls.Add(label25);
			tabPage1.Controls.Add(label26);
			tabPage1.Controls.Add(txtName);
			tabPage1.Controls.Add(label23);
			tabPage1.Controls.Add(txtUnitText);
			tabPage1.Controls.Add(txtUserFlags);
			tabPage1.Controls.Add(label8);
			tabPage1.Controls.Add(label22);
			tabPage1.Controls.Add(txtToolTip);
			tabPage1.Controls.Add(txtSpecifyWidth);
			tabPage1.Controls.Add(cboContentReadonly);
			tabPage1.Controls.Add(cboBorderVisible);
			tabPage1.Controls.Add(cboMoveFocusHotKey);
			tabPage1.Controls.Add(label19);
			tabPage1.Controls.Add(cboEncryptLevel);
			tabPage1.Controls.Add(txtLabel);
			tabPage1.Controls.Add(cboEnableHighlight);
			tabPage1.Controls.Add(label9);
			tabPage1.Controls.Add(txtBackgroundText);
			tabPage1.Controls.Add(label11);
			tabPage1.Controls.Add(label21);
			tabPage1.Controls.Add(btnEditorActiveMode);
			tabPage1.Controls.Add(txtDefaultEventExpression);
			tabPage1.Controls.Add(txtID);
			tabPage1.Controls.Add(chkDeleteable);
			tabPage1.Controls.Add(chkEnableFieldTextColor);
			tabPage1.Controls.Add(chkTabStop);
			tabPage1.Controls.Add(chkUserEditable);
			tabPage1.Controls.Add(label17);
			tabPage1.Controls.Add(label12);
			tabPage1.Controls.Add(label29);
			tabPage1.Controls.Add(label15);
			tabPage1.Controls.Add(label18);
			tabPage1.Controls.Add(label14);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			cboDefaultValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboDefaultValueType.FormattingEnabled = true;
			resources.ApplyResources(cboDefaultValueType, "cboDefaultValueType");
			cboDefaultValueType.Name = "cboDefaultValueType";
			resources.ApplyResources(label31, "label31");
			label31.Name = "label31";
			cboAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboAlignment.FormattingEnabled = true;
			cboAlignment.Items.AddRange(new object[3]
			{
				resources.GetString("cboAlignment.Items"),
				resources.GetString("cboAlignment.Items1"),
				resources.GetString("cboAlignment.Items2")
			});
			resources.ApplyResources(cboAlignment, "cboAlignment");
			cboAlignment.Name = "cboAlignment";
			resources.ApplyResources(label30, "label30");
			label30.Name = "label30";
			resources.ApplyResources(txtEndBorderText, "txtEndBorderText");
			txtEndBorderText.Name = "txtEndBorderText";
			resources.ApplyResources(label27, "label27");
			label27.Name = "label27";
			resources.ApplyResources(txtStartBorderText, "txtStartBorderText");
			txtStartBorderText.Name = "txtStartBorderText";
			resources.ApplyResources(label28, "label28");
			label28.Name = "label28";
			resources.ApplyResources(txtEditorControlTypeName, "txtEditorControlTypeName");
			txtEditorControlTypeName.Name = "txtEditorControlTypeName";
			resources.ApplyResources(txtVisibleExpression, "txtVisibleExpression");
			txtVisibleExpression.Name = "txtVisibleExpression";
			resources.ApplyResources(label25, "label25");
			label25.Name = "label25";
			resources.ApplyResources(label26, "label26");
			label26.Name = "label26";
			cboBorderVisible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboBorderVisible.FormattingEnabled = true;
			resources.ApplyResources(cboBorderVisible, "cboBorderVisible");
			cboBorderVisible.Name = "cboBorderVisible";
			resources.ApplyResources(label29, "label29");
			label29.Name = "label29";
			tabPage2.Controls.Add(label3);
			tabPage2.Controls.Add(label2);
			tabPage2.Controls.Add(txtValidate);
			tabPage2.Controls.Add(btnBrowseSettings);
			tabPage2.Controls.Add(label4);
			tabPage2.Controls.Add(btnBrowseMemberExpressions);
			tabPage2.Controls.Add(btnBrowseCopySource);
			tabPage2.Controls.Add(txtBinding);
			tabPage2.Controls.Add(btnBrowseEventExpressions);
			tabPage2.Controls.Add(label5);
			tabPage2.Controls.Add(btnBrowseAcceptElementType);
			tabPage2.Controls.Add(label7);
			tabPage2.Controls.Add(btnBrowseDisplayFormat);
			tabPage2.Controls.Add(txtAttributes);
			tabPage2.Controls.Add(btnBrowseAttributes);
			tabPage2.Controls.Add(label10);
			tabPage2.Controls.Add(btnBrowseBinding);
			tabPage2.Controls.Add(label13);
			tabPage2.Controls.Add(btnBrowseValidate);
			tabPage2.Controls.Add(label32);
			tabPage2.Controls.Add(label20);
			tabPage2.Controls.Add(txtSettings);
			tabPage2.Controls.Add(txtDisplayFormat);
			tabPage2.Controls.Add(txtMemberExpressions);
			tabPage2.Controls.Add(txtCopySource);
			tabPage2.Controls.Add(txtAcceptElementType);
			tabPage2.Controls.Add(txtEventExpressions);
			resources.ApplyResources(tabPage2, "tabPage2");
			tabPage2.Name = "tabPage2";
			tabPage2.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnBrowseMemberExpressions, "btnBrowseMemberExpressions");
			btnBrowseMemberExpressions.Name = "btnBrowseMemberExpressions";
			btnBrowseMemberExpressions.UseVisualStyleBackColor = true;
			btnBrowseMemberExpressions.Click += new System.EventHandler(btnBrowseMemberExpressions_Click);
			resources.ApplyResources(label32, "label32");
			label32.Name = "label32";
			resources.ApplyResources(txtMemberExpressions, "txtMemberExpressions");
			txtMemberExpressions.Name = "txtMemberExpressions";
			txtMemberExpressions.ReadOnly = true;
			resources.ApplyResources(label33, "label33");
			label33.Name = "label33";
			resources.ApplyResources(txtDefaultSelectedIndexs, "txtDefaultSelectedIndexs");
			txtDefaultSelectedIndexs.Name = "txtDefaultSelectedIndexs";
			toolTip_0.SetToolTip(txtDefaultSelectedIndexs, resources.GetString("txtDefaultSelectedIndexs.ToolTip"));
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(tabControl1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputFieldEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInputFieldEditor_Load);
			((System.ComponentModel.ISupportInitialize)txtSpecifyWidth).EndInit();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInputFieldEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInputFieldEditor_Load(object sender, EventArgs e)
		{
			if (SourceEventArgs != null && SourceEventArgs.WriterControl != null)
			{
				Text = SourceEventArgs.WriterControl.DialogTitlePrefix + Text;
			}
			foreach (object value in Enum.GetValues(typeof(MoveFocusHotKeys)))
			{
				cboMoveFocusHotKey.Items.Add(value);
			}
			foreach (object value2 in Enum.GetValues(typeof(DCVisibleState)))
			{
				cboBorderVisible.Items.Add(value2);
			}
			foreach (object value3 in Enum.GetValues(typeof(DCDefaultValueType)))
			{
				cboDefaultValueType.Items.Add(value3);
			}
			if (SourceEventArgs != null)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)SourceEventArgs.Element;
				cboDefaultValueType.SelectedIndex = (int)xTextInputFieldElement.DefaultValueType;
				cboBorderVisible.SelectedIndex = (int)xTextInputFieldElement.BorderVisible;
				txtName.Text = xTextInputFieldElement.Name;
				txtID.Text = xTextInputFieldElement.ID;
				txtBackgroundText.Text = xTextInputFieldElement.BackgroundText;
				cboContentReadonly.SelectedIndex = (int)xTextInputFieldElement.ContentReadonly;
				chkUserEditable.Checked = xTextInputFieldElement.UserEditable;
				txtToolTip.Text = xTextInputFieldElement.ToolTip;
				txtLabel.Text = xTextInputFieldElement.LabelText;
				chkDeleteable.Checked = xTextInputFieldElement.Deleteable;
				cboEncryptLevel.SelectedIndex = (int)xTextInputFieldElement.ViewEncryptType;
				txtUnitText.Text = xTextInputFieldElement.UnitText;
				chkTabStop.Checked = xTextInputFieldElement.TabStop;
				txtValueExpression.Text = xTextInputFieldElement.ValueExpression;
				cboAutoHideMode.SelectedIndex = (int)xTextInputFieldElement.AutoHideMode;
				txtVisibleExpression.Text = xTextInputFieldElement.VisibleExpression;
				cboAlignment.SelectedIndex = (int)xTextInputFieldElement.Alignment;
				txtDefaultSelectedIndexs.Text = xTextInputFieldElement.DefaultSelectedIndexs;
				if (xTextInputFieldElement.CopySource != null)
				{
					txtCopySource.Text = xTextInputFieldElement.CopySource.ToString();
					txtCopySource.Tag = xTextInputFieldElement.CopySource.Clone();
				}
				if (xTextInputFieldElement.ValidateStyle != null)
				{
					txtValidate.Text = xTextInputFieldElement.ValidateStyle.method_2();
					txtValidate.Tag = xTextInputFieldElement.ValidateStyle;
				}
				if (xTextInputFieldElement.FieldSettings != null)
				{
					txtSettings.Text = xTextInputFieldElement.FieldSettings.ToString();
					txtSettings.Tag = xTextInputFieldElement.FieldSettings;
				}
				if (xTextInputFieldElement.Attributes != null)
				{
					txtAttributes.Text = xTextInputFieldElement.Attributes.ToString();
					txtAttributes.Tag = xTextInputFieldElement.Attributes;
				}
				if (xTextInputFieldElement.DisplayFormat != null)
				{
					txtDisplayFormat.Text = xTextInputFieldElement.DisplayFormat.ToString();
					txtDisplayFormat.Tag = xTextInputFieldElement.DisplayFormat;
				}
				txtDefaultEventExpression.Text = xTextInputFieldElement.DefaultEventExpression;
				if (xTextInputFieldElement.EventExpressions != null)
				{
					txtEventExpressions.Text = xTextInputFieldElement.EventExpressions.ToString();
					txtEventExpressions.Tag = xTextInputFieldElement.EventExpressions;
				}
				if (xTextInputFieldElement.ValueBinding != null)
				{
					txtBinding.Text = xTextInputFieldElement.ValueBinding.ToString();
					txtBinding.Tag = xTextInputFieldElement.ValueBinding;
				}
				if (xTextInputFieldElement.PropertyExpressions != null)
				{
					txtMemberExpressions.Text = xTextInputFieldElement.PropertyExpressions.ToString();
					txtMemberExpressions.Tag = xTextInputFieldElement.PropertyExpressions;
				}
				txtUserFlags.Text = xTextInputFieldElement.UserFlags.ToString();
				txtAcceptElementType.Text = xTextInputFieldElement.AcceptChildElementTypes2.ToString();
				txtAcceptElementType.Tag = xTextInputFieldElement.AcceptChildElementTypes2;
				cboEnableHighlight.SelectedIndex = (int)xTextInputFieldElement.EnableHighlight;
				txtSpecifyWidth.Value = WriterUtils.smethod_36(SourceEventArgs.Document, xTextInputFieldElement.SpecifyWidth);
				btnEditorActiveMode.Tag = xTextInputFieldElement.EditorActiveMode;
				btnEditorActiveMode.Text = xTextInputFieldElement.EditorActiveMode.ToString();
				cboMoveFocusHotKey.SelectedItem = xTextInputFieldElement.MoveFocusHotKey;
				chkEnableFieldTextColor.Checked = xTextInputFieldElement.EnableFieldTextColor;
				txtEditorControlTypeName.Text = xTextInputFieldElement.EditorControlTypeName;
				txtStartBorderText.Text = xTextInputFieldElement.StartBorderText;
				txtEndBorderText.Text = xTextInputFieldElement.EndBorderText;
			}
		}

		private void btnBrowseValidate_Click(object sender, EventArgs e)
		{
			using (dlgValueValidateStyleEditor dlgValueValidateStyleEditor = new dlgValueValidateStyleEditor())
			{
				dlgValueValidateStyleEditor.ValidateStyle = (ValueValidateStyle)txtValidate.Tag;
				if (dlgValueValidateStyleEditor.ShowDialog(this) == DialogResult.OK)
				{
					txtValidate.Tag = dlgValueValidateStyleEditor.ValidateStyle.method_4();
					txtValidate.Text = dlgValueValidateStyleEditor.ValidateStyle.method_2();
				}
			}
		}

		private void btnBrowseBinding_Click(object sender, EventArgs e)
		{
			if (SourceEventArgs != null)
			{
				dlgXDataBinding.smethod_0(txtBinding, SourceEventArgs.Document, SourceEventArgs.Element);
			}
		}

		private void btnBrowseSettings_Click(object sender, EventArgs e)
		{
			using (dlgInputFieldSettings dlgInputFieldSettings = new dlgInputFieldSettings())
			{
				dlgInputFieldSettings.InputFieldSettings = (InputFieldSettings)txtSettings.Tag;
				dlgInputFieldSettings.SourceElement = elementPropertiesEditEventArgs_0.Element;
				if (dlgInputFieldSettings.ShowDialog(this) == DialogResult.OK)
				{
					txtSettings.Tag = dlgInputFieldSettings.InputFieldSettings.Clone();
					txtSettings.Text = dlgInputFieldSettings.InputFieldSettings.ToString();
				}
			}
		}

		private void btnBrowseAttributes_Click(object sender, EventArgs e)
		{
			using (dlgAttributes dlgAttributes = new dlgAttributes())
			{
				dlgAttributes.InputAttributes = (XAttributeList)txtAttributes.Tag;
				if (dlgAttributes.ShowDialog(this) == DialogResult.OK)
				{
					txtAttributes.Tag = dlgAttributes.InputAttributes.Clone();
					txtAttributes.Text = dlgAttributes.InputAttributes.ToString();
				}
			}
		}

		private void btnBrowseDisplayFormat_Click(object sender, EventArgs e)
		{
			using (dlgFormatDesigner dlgFormatDesigner = new dlgFormatDesigner())
			{
				dlgFormatDesigner.InputFormater = (ValueFormater)txtDisplayFormat.Tag;
				if (dlgFormatDesigner.ShowDialog(this) == DialogResult.OK)
				{
					txtDisplayFormat.Tag = dlgFormatDesigner.InputFormater.Clone();
					txtDisplayFormat.Text = dlgFormatDesigner.InputFormater.ToString();
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 17;
			if (SourceEventArgs == null || !(SourceEventArgs.Element is XTextInputFieldElement))
			{
				return;
			}
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)SourceEventArgs.Element;
			if (xTextInputFieldElement != null)
			{
				XTextDocument document = SourceEventArgs.Document;
				bool flag = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
				bool flag2 = false;
				ContentReadonlyState selectedIndex = (ContentReadonlyState)cboContentReadonly.SelectedIndex;
				if (WriterUtils.smethod_27(xTextInputFieldElement, "ContentReadonly", selectedIndex, bool_2: true))
				{
					flag2 = true;
				}
				string text = txtID.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextInputFieldElement.ID != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("ID", xTextInputFieldElement.ID, text, xTextInputFieldElement);
					}
					xTextInputFieldElement.ID = text;
					flag2 = true;
				}
				if (!WriterUtils.smethod_43(txtStartBorderText.Text, xTextInputFieldElement.StartBorderText))
				{
					if (flag)
					{
						document.UndoList.AddProperty("StartBorderText", xTextInputFieldElement.StartBorderText, txtStartBorderText.Text, xTextInputFieldElement);
					}
					xTextInputFieldElement.StartBorderText = txtStartBorderText.Text;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
				}
				if (!WriterUtils.smethod_43(txtEndBorderText.Text, xTextInputFieldElement.EndBorderText))
				{
					if (flag)
					{
						document.UndoList.AddProperty("EndBorderText", xTextInputFieldElement.EndBorderText, txtEndBorderText.Text, xTextInputFieldElement);
					}
					xTextInputFieldElement.EndBorderText = txtEndBorderText.Text;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
				}
				if (!WriterUtils.smethod_43(txtDefaultSelectedIndexs.Text, xTextInputFieldElement.DefaultSelectedIndexs))
				{
					if (flag)
					{
						document.UndoList.AddProperty("DefaultSelectedIndexs", xTextInputFieldElement.DefaultSelectedIndexs, txtDefaultSelectedIndexs.Text, xTextInputFieldElement);
					}
					xTextInputFieldElement.DefaultSelectedIndexs = txtDefaultSelectedIndexs.Text;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				text = txtName.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextInputFieldElement.Name != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("Name", xTextInputFieldElement.Name, text, xTextInputFieldElement);
					}
					xTextInputFieldElement.Name = text;
					flag2 = true;
				}
				text = txtUnitText.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextInputFieldElement.UnitText != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("UnitText", xTextInputFieldElement.UnitText, text, xTextInputFieldElement);
					}
					xTextInputFieldElement.UnitText = text;
					flag2 = true;
				}
				text = txtEditorControlTypeName.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextInputFieldElement.EditorControlTypeName != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("EditorControlTypeName", xTextInputFieldElement.EditorControlTypeName, text, xTextInputFieldElement);
					}
					xTextInputFieldElement.EditorControlTypeName = text;
					flag2 = true;
				}
				text = txtToolTip.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				ContentViewEncryptType selectedIndex2 = (ContentViewEncryptType)cboEncryptLevel.SelectedIndex;
				if (xTextInputFieldElement.ViewEncryptType != selectedIndex2)
				{
					if (flag)
					{
						document.UndoList.AddProperty("ViewEncryptType", xTextInputFieldElement.ViewEncryptType, selectedIndex2, xTextInputFieldElement);
					}
					xTextInputFieldElement.ViewEncryptType = selectedIndex2;
					flag2 = true;
				}
				PropertyExpressionInfoList propertyExpressionInfoList = (PropertyExpressionInfoList)txtMemberExpressions.Tag;
				if (xTextInputFieldElement.PropertyExpressions != propertyExpressionInfoList)
				{
					if (flag)
					{
						document.UndoList.AddProperty("PropertyExpressions", xTextInputFieldElement.PropertyExpressions, propertyExpressionInfoList, xTextInputFieldElement);
					}
					xTextInputFieldElement.PropertyExpressions = propertyExpressionInfoList;
					if (SourceEventArgs.Document.ExpressionExecuter != null)
					{
						SourceEventArgs.Document.ExpressionExecuter.imethod_4(SourceEventArgs.Element);
					}
					flag2 = true;
				}
				DCVisibleState selectedIndex3 = (DCVisibleState)cboBorderVisible.SelectedIndex;
				if (xTextInputFieldElement.BorderVisible != selectedIndex3)
				{
					if (flag)
					{
						document.UndoList.AddProperty("BorderVisible", xTextInputFieldElement.BorderVisible, selectedIndex3, xTextInputFieldElement);
					}
					xTextInputFieldElement.BorderVisible = selectedIndex3;
					flag2 = true;
				}
				DCDefaultValueType selectedIndex4 = (DCDefaultValueType)cboDefaultValueType.SelectedIndex;
				if (xTextInputFieldElement.DefaultValueType != selectedIndex4)
				{
					if (flag)
					{
						document.UndoList.AddProperty("DefaultValueType", xTextInputFieldElement.DefaultValueType, selectedIndex4, xTextInputFieldElement);
					}
					xTextInputFieldElement.DefaultValueType = selectedIndex4;
					flag2 = true;
				}
				if (xTextInputFieldElement.ToolTip != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("ToolTip", xTextInputFieldElement.ToolTip, text, xTextInputFieldElement);
					}
					xTextInputFieldElement.ToolTip = text;
					flag2 = true;
				}
				text = txtBackgroundText.Text;
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextInputFieldElement.BackgroundText != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("BackgroundText", xTextInputFieldElement.BackgroundText, text, xTextInputFieldElement);
					}
					xTextInputFieldElement.BackgroundText = text;
					flag2 = true;
				}
				text = txtLabel.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextInputFieldElement.LabelText != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("LabelText", xTextInputFieldElement.LabelText, text, xTextInputFieldElement);
					}
					xTextInputFieldElement.LabelText = text;
					flag2 = true;
				}
				text = txtDefaultEventExpression.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (xTextInputFieldElement.DefaultEventExpression != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("DefaultEventExpression", xTextInputFieldElement.DefaultEventExpression, text, xTextInputFieldElement);
					}
					xTextInputFieldElement.DefaultEventExpression = text;
					flag2 = true;
				}
				WriterUtils.smethod_27(xTextInputFieldElement, "TabStop", chkTabStop.Checked, xTextInputFieldElement.TabStop);
				if (xTextInputFieldElement.Deleteable != chkDeleteable.Checked)
				{
					if (flag)
					{
						document.UndoList.AddProperty("Deleteable", xTextInputFieldElement.Deleteable, chkDeleteable.Checked, xTextInputFieldElement);
					}
					xTextInputFieldElement.Deleteable = chkDeleteable.Checked;
					flag2 = true;
				}
				if (xTextInputFieldElement.UserEditable != chkUserEditable.Checked)
				{
					if (flag)
					{
						document.UndoList.AddProperty("UserEditable", xTextInputFieldElement.UserEditable, chkUserEditable.Checked, xTextInputFieldElement);
					}
					xTextInputFieldElement.UserEditable = chkUserEditable.Checked;
					flag2 = true;
				}
				CopySourceInfo copySourceInfo = (CopySourceInfo)txtCopySource.Tag;
				if (xTextInputFieldElement.CopySource != copySourceInfo)
				{
					if (flag)
					{
						document.UndoList.AddProperty("CopySource", xTextInputFieldElement.CopySource, copySourceInfo, xTextInputFieldElement);
					}
					xTextInputFieldElement.CopySource = copySourceInfo;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				if (xTextInputFieldElement.Attributes != txtAttributes.Tag)
				{
					if (flag)
					{
						document.UndoList.AddProperty("Attributes", xTextInputFieldElement.Attributes, txtAttributes.Tag, xTextInputFieldElement);
					}
					xTextInputFieldElement.Attributes = (XAttributeList)txtAttributes.Tag;
					flag2 = true;
				}
				if (xTextInputFieldElement.ValidateStyle != txtValidate.Tag)
				{
					if (flag)
					{
						document.UndoList.AddProperty("ValidateStyle", xTextInputFieldElement.ValidateStyle, txtValidate.Tag, xTextInputFieldElement);
					}
					xTextInputFieldElement.ValidateStyle = (ValueValidateStyle)txtValidate.Tag;
					flag2 = true;
				}
				if (xTextInputFieldElement.FieldSettings != txtSettings.Tag)
				{
					if (flag)
					{
						document.UndoList.AddProperty("FieldSettings", xTextInputFieldElement.FieldSettings, txtSettings.Tag, xTextInputFieldElement);
					}
					xTextInputFieldElement.FieldSettings = (InputFieldSettings)txtSettings.Tag;
					flag2 = true;
				}
				if (xTextInputFieldElement.DisplayFormat != txtDisplayFormat.Tag)
				{
					if (flag)
					{
						document.UndoList.AddProperty("DisplayFormat", xTextInputFieldElement.DisplayFormat, (ValueFormater)txtDisplayFormat.Tag, xTextInputFieldElement);
					}
					xTextInputFieldElement.DisplayFormat = (ValueFormater)txtDisplayFormat.Tag;
					flag2 = true;
				}
				if (xTextInputFieldElement.AcceptChildElementTypes2 != (ElementType)txtAcceptElementType.Tag)
				{
					if (flag)
					{
						document.UndoList.AddProperty("AcceptChildElementTypes2", xTextInputFieldElement.AcceptChildElementTypes2, txtAcceptElementType.Tag, xTextInputFieldElement);
					}
					xTextInputFieldElement.AcceptChildElementTypes2 = (ElementType)txtAcceptElementType.Tag;
					flag2 = true;
				}
				if (xTextInputFieldElement.EnableHighlight != (EnableState)cboEnableHighlight.SelectedIndex)
				{
					if (flag)
					{
						document.UndoList.AddProperty("EnableHighlight", xTextInputFieldElement.EnableHighlight, (EnableState)cboEnableHighlight.SelectedIndex, xTextInputFieldElement);
					}
					xTextInputFieldElement.EnableHighlight = (EnableState)cboEnableHighlight.SelectedIndex;
					flag2 = true;
				}
				float num2 = WriterUtils.smethod_37(document, txtSpecifyWidth.Value);
				if (xTextInputFieldElement.SpecifyWidth != num2)
				{
					if (flag)
					{
						document.UndoList.AddProperty("SpecifyWidth", xTextInputFieldElement.SpecifyWidth, num2, xTextInputFieldElement);
					}
					xTextInputFieldElement.SpecifyWidth = num2;
					flag2 = true;
				}
				if (xTextInputFieldElement.EditorActiveMode != (ValueEditorActiveMode)btnEditorActiveMode.Tag)
				{
					if (flag)
					{
						document.UndoList.AddProperty("EditorActiveMode", xTextInputFieldElement.EditorActiveMode, btnEditorActiveMode.Tag, xTextInputFieldElement);
					}
					xTextInputFieldElement.EditorActiveMode = (ValueEditorActiveMode)btnEditorActiveMode.Tag;
					flag2 = true;
				}
				EventExpressionInfoList eventExpressionInfoList = (EventExpressionInfoList)txtEventExpressions.Tag;
				if (xTextInputFieldElement.EventExpressions != eventExpressionInfoList)
				{
					if (flag)
					{
						document.UndoList.AddProperty("EventExpressions", xTextInputFieldElement.EventExpressions, eventExpressionInfoList, xTextInputFieldElement);
					}
					xTextInputFieldElement.EventExpressions = eventExpressionInfoList;
					flag2 = true;
				}
				MoveFocusHotKeys moveFocusHotKeys = (MoveFocusHotKeys)cboMoveFocusHotKey.SelectedItem;
				if (xTextInputFieldElement.MoveFocusHotKey != moveFocusHotKeys)
				{
					if (flag)
					{
						document.UndoList.AddProperty("MoveFocusHotKey", xTextInputFieldElement.MoveFocusHotKey, moveFocusHotKeys, xTextInputFieldElement);
					}
					xTextInputFieldElement.MoveFocusHotKey = moveFocusHotKeys;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				if (cboAutoHideMode.SelectedIndex != (int)xTextInputFieldElement.AutoHideMode)
				{
					if (flag)
					{
						document.UndoList.AddProperty("AutoHideMode", xTextInputFieldElement.AutoHideMode, (ContainerAutoHideMode)cboAutoHideMode.SelectedIndex, xTextInputFieldElement);
					}
					xTextInputFieldElement.AutoHideMode = (ContainerAutoHideMode)cboAutoHideMode.SelectedIndex;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				if (xTextInputFieldElement.EnableFieldTextColor != chkEnableFieldTextColor.Checked)
				{
					if (flag)
					{
						document.UndoList.AddProperty("EnableFieldTextColor", xTextInputFieldElement.EnableFieldTextColor, chkEnableFieldTextColor.Checked, xTextInputFieldElement);
					}
					xTextInputFieldElement.EnableFieldTextColor = chkEnableFieldTextColor.Checked;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				bool flag3 = false;
				if (xTextInputFieldElement.ValueBinding != txtBinding.Tag)
				{
					if (flag)
					{
						document.UndoList.AddProperty("ValueBinding", xTextInputFieldElement.ValueBinding, txtBinding.Tag, xTextInputFieldElement);
					}
					xTextInputFieldElement.ValueBinding = (XDataBinding)txtBinding.Tag;
					flag3 = true;
					flag2 = true;
				}
				int result = 0;
				if (!string.IsNullOrEmpty(txtUserFlags.Text) && int.TryParse(txtUserFlags.Text, out result) && xTextInputFieldElement.UserFlags != result)
				{
					if (flag)
					{
						document.UndoList.AddProperty("UserFlags", xTextInputFieldElement.UserFlags, result, xTextInputFieldElement);
					}
					xTextInputFieldElement.UserFlags = result;
					flag2 = true;
				}
				StringAlignment selectedIndex5 = (StringAlignment)cboAlignment.SelectedIndex;
				if (selectedIndex5 != xTextInputFieldElement.Alignment)
				{
					if (flag)
					{
						document.UndoList.AddProperty("Alignment", xTextInputFieldElement.Alignment, selectedIndex5, xTextInputFieldElement);
					}
					xTextInputFieldElement.Alignment = selectedIndex5;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					flag2 = true;
				}
				if (txtValueExpression.Text != xTextInputFieldElement.ValueExpression)
				{
					if (flag)
					{
						document.UndoList.AddProperty("ValueExpression", xTextInputFieldElement.ValueExpression, txtValueExpression.Text, xTextInputFieldElement);
					}
					xTextInputFieldElement.ValueExpression = txtValueExpression.Text;
					flag2 = true;
				}
				if (txtVisibleExpression.Text != xTextInputFieldElement.VisibleExpression)
				{
					if (flag)
					{
						document.UndoList.AddProperty("VisibleExpression", xTextInputFieldElement.VisibleExpression, txtVisibleExpression.Text, xTextInputFieldElement);
					}
					xTextInputFieldElement.VisibleExpression = txtVisibleExpression.Text;
					flag2 = true;
				}
				if (txtUserFlags.Text != null && txtUserFlags.Text != string.Empty)
				{
					xTextInputFieldElement.UserFlags = Convert.ToInt32(txtUserFlags.Text);
				}
				else
				{
					xTextInputFieldElement.UserFlags = 0;
				}
				if (flag3 && xTextInputFieldElement.ValueBinding != null)
				{
					int processState = (int)xTextInputFieldElement.ValueBinding.ProcessState;
					xTextInputFieldElement.UpdateDataBindingExt(new UpdateDataBindingArgs(null, fastMode: false));
					xTextInputFieldElement.ValueBinding.ProcessState = (DCProcessStates)processState;
				}
				if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
				{
					if (flag2)
					{
						XTextContentElement contentElement = xTextInputFieldElement.ContentElement;
						contentElement.method_29(xTextInputFieldElement.StartElement.OwnerLine, xTextInputFieldElement.EndElement.OwnerLine);
						xTextInputFieldElement.StartElement.SizeInvalid = true;
						xTextInputFieldElement.EndElement.SizeInvalid = true;
						xTextInputFieldElement.EditorRefreshView();
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.Document = xTextInputFieldElement.OwnerDocument;
						contentChangedEventArgs.Element = xTextInputFieldElement;
						contentChangedEventArgs.LoadingDocument = false;
						xTextInputFieldElement.method_23(contentChangedEventArgs);
					}
				}
				else
				{
					base.DialogResult = DialogResult.OK;
				}
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtLabel_TextChanged(object sender, EventArgs e)
		{
		}

		private void btnBrowseAcceptElementType_Click(object sender, EventArgs e)
		{
			using (dlgElementTypeEditor dlgElementTypeEditor = new dlgElementTypeEditor())
			{
				dlgElementTypeEditor.InputElementType = (ElementType)txtAcceptElementType.Tag;
				if (dlgElementTypeEditor.ShowDialog(this) == DialogResult.OK)
				{
					txtAcceptElementType.Tag = dlgElementTypeEditor.InputElementType;
					txtAcceptElementType.Text = dlgElementTypeEditor.InputElementType.ToString();
				}
			}
		}

		private void btnBrowseEventExpressions_Click(object sender, EventArgs e)
		{
			int num = 3;
			using (dlgEventExpressionInfos dlgEventExpressionInfos = new dlgEventExpressionInfos())
			{
				EventExpressionInfoList eventExpressionInfoList = (EventExpressionInfoList)txtEventExpressions.Tag;
				eventExpressionInfoList = (dlgEventExpressionInfos.InputExpressions = ((eventExpressionInfoList == null) ? new EventExpressionInfoList() : eventExpressionInfoList.Clone()));
				if (dlgEventExpressionInfos.ShowDialog(this) == DialogResult.OK)
				{
					EventExpressionInfoList inputExpressions = dlgEventExpressionInfos.InputExpressions;
					txtEventExpressions.Tag = inputExpressions;
					txtEventExpressions.Text = inputExpressions.ToString();
					if (inputExpressions != null)
					{
						txtDefaultEventExpression.Text = "";
						foreach (EventExpressionInfo item in inputExpressions)
						{
							if (item.EventName == "ContentChanged" && item.Target == EventExpressionTarget.NextElement)
							{
								txtDefaultEventExpression.Text = item.Expression;
								break;
							}
						}
					}
				}
			}
		}

		private void btnEditorActiveMode_Click(object sender, EventArgs e)
		{
			using (dlgValueEditorActiveMode dlgValueEditorActiveMode = new dlgValueEditorActiveMode())
			{
				dlgValueEditorActiveMode.EditorActiveMode = (ValueEditorActiveMode)btnEditorActiveMode.Tag;
				if (dlgValueEditorActiveMode.ShowDialog(this) == DialogResult.OK)
				{
					btnEditorActiveMode.Tag = dlgValueEditorActiveMode.EditorActiveMode;
					btnEditorActiveMode.Text = dlgValueEditorActiveMode.EditorActiveMode.ToString();
				}
			}
		}

		private void btnBrowseCopySource_Click(object sender, EventArgs e)
		{
			using (dlgCopySourceInfo dlgCopySourceInfo = new dlgCopySourceInfo())
			{
				dlgCopySourceInfo.DescElement = SourceEventArgs.Element;
				dlgCopySourceInfo.InputInfo = (CopySourceInfo)txtCopySource.Tag;
				if (dlgCopySourceInfo.ShowDialog(this) == DialogResult.OK)
				{
					txtCopySource.Tag = dlgCopySourceInfo.InputInfo;
					txtCopySource.Text = dlgCopySourceInfo.InputInfo.ToString();
				}
			}
		}

		private void label11_Click(object sender, EventArgs e)
		{
		}

		private void btnBrowseMemberExpressions_Click(object sender, EventArgs e)
		{
			int num = 13;
			using (dlgPropertyExpressionInfoList dlgPropertyExpressionInfoList = new dlgPropertyExpressionInfoList())
			{
				dlgPropertyExpressionInfoList.InputOwner = SourceEventArgs.Element;
				dlgPropertyExpressionInfoList.InputInfos = (PropertyExpressionInfoList)txtMemberExpressions.Tag;
				if (dlgPropertyExpressionInfoList.InputInfos != null)
				{
					dlgPropertyExpressionInfoList.InputInfos = dlgPropertyExpressionInfoList.InputInfos.Clone();
				}
				if (dlgPropertyExpressionInfoList.ShowDialog(this) == DialogResult.OK)
				{
					txtMemberExpressions.Tag = dlgPropertyExpressionInfoList.InputInfos;
					txtMemberExpressions.Text = dlgPropertyExpressionInfoList.InputInfos.ToString();
					if (SourceEventArgs.Element != null && SourceEventArgs.Document.ExpressionExecuter != null)
					{
						SourceEventArgs.Document.ExpressionExecuter.imethod_4(SourceEventArgs.Element);
						txtVisibleExpression.Text = dlgPropertyExpressionInfoList.InputInfos.GetValue("Visible");
					}
				}
			}
		}
	}
}
