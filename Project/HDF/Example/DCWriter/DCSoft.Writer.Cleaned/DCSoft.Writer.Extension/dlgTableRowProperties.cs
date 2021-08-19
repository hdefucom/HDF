using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Design;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       表格行属性
	///       </summary>
	[ComVisible(false)]
	public class dlgTableRowProperties : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private bool bool_0 = false;

		private IContainer icontainer_0 = null;

		private Button btnCancel;

		private Button btnOK;

		private Button btnBrowseAttribute;

		private TextBox txtAttributes;

		private Label label2;

		private TextBox txtID;

		private Label label1;

		private CheckBox chkSpecifyRowHeight;

		private NumericUpDown nudSpecifyRowHeight;

		private CheckBox chkHeaderRow;

		private CheckBox chkHeightExt;

		private Label label4;

		private ComboBox cboCloneType;

		private Label label5;

		private ComboBox cboEventTemplateName;

		private CheckBox chkCanSplitByPageLine;

		private Label lblCurrentHeight;

		private ComboBox cboContentReadonly;

		private Label label3;

		private ComboBox cboEnablePermission;

		private Label label6;

		private Label label7;

		private TextBox txtValueBingding;

		private Button btnValueBinding;

		private CheckBox chkPrintCellBorder;

		private CheckBox chkPrintCellBackground;

		private CheckBox chkNewPage;

		private Button btnBrowseMemberExpressions;

		private Label label32;

		private TextBox txtMemberExpressions;

		private ComboBox cboAllowInsertRowDownUseHotKey;

		private Label label8;

		/// <summary>
		///       编辑元素事件参数
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
		///       标题样式
		///       </summary>
		public bool HeaderStyleModified
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

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgTableRowProperties()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgTableRowProperties_Load(object sender, EventArgs e)
		{
			int num = 11;
			if (SourceEventArgs != null)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)SourceEventArgs.Element;
				txtID.Text = xTextTableRowElement.ID;
				txtID.Enabled = (SourceEventArgs.Elements != null && SourceEventArgs.Elements.Count == 1);
				if (xTextTableRowElement.Attributes != null)
				{
					txtAttributes.Text = xTextTableRowElement.Attributes.ToString();
					txtAttributes.Tag = xTextTableRowElement.Attributes;
				}
				chkCanSplitByPageLine.Checked = xTextTableRowElement.CanSplitByPageLine;
				chkSpecifyRowHeight.Checked = (xTextTableRowElement.SpecifyHeight != 0f);
				nudSpecifyRowHeight.Value = WriterUtils.smethod_36(SourceEventArgs.Document, Math.Abs(xTextTableRowElement.SpecifyHeight));
				lblCurrentHeight.Text = string.Format(WriterStrings.CurrentHeight_CM, WriterUtils.smethod_36(SourceEventArgs.Document, Math.Abs(xTextTableRowElement.Height)).ToString("0.00"));
				chkHeightExt.Checked = (xTextTableRowElement.SpecifyHeight > 0f);
				chkHeaderRow.Checked = xTextTableRowElement.HeaderStyle;
				cboCloneType.SelectedIndex = (int)xTextTableRowElement.CloneType;
				cboEventTemplateName.Text = xTextTableRowElement.EventTemplateName;
				cboContentReadonly.SelectedIndex = (int)xTextTableRowElement.ContentReadonly;
				cboEnablePermission.SelectedIndex = (int)xTextTableRowElement.EnablePermission;
				chkPrintCellBackground.Checked = xTextTableRowElement.PrintCellBackground;
				chkPrintCellBorder.Checked = xTextTableRowElement.PrintCellBorder;
				txtValueBingding.Tag = xTextTableRowElement.ValueBinding;
				chkNewPage.Checked = xTextTableRowElement.NewPage;
				cboAllowInsertRowDownUseHotKey.SelectedIndex = (int)xTextTableRowElement.AllowInsertRowDownUseHotKey;
				if (xTextTableRowElement.ValueBinding != null)
				{
					txtValueBingding.Text = xTextTableRowElement.ValueBinding.ToString();
				}
				txtMemberExpressions.Tag = xTextTableRowElement.PropertyExpressions;
				if (xTextTableRowElement.PropertyExpressions != null)
				{
					txtMemberExpressions.Text = xTextTableRowElement.PropertyExpressions.ToString();
				}
				chkSpecifyRowHeight_CheckedChanged(null, null);
			}
		}

		private void chkSpecifyRowHeight_CheckedChanged(object sender, EventArgs e)
		{
			nudSpecifyRowHeight.Enabled = chkSpecifyRowHeight.Checked;
			chkHeightExt.Enabled = chkSpecifyRowHeight.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 6;
			if (SourceEventArgs == null)
			{
				return;
			}
			SourceEventArgs.ContentEffect = ContentEffects.None;
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)SourceEventArgs.Element;
			XTextDocument document = SourceEventArgs.Document;
			bool flag = SourceEventArgs.LogUndo && document.CanLogUndo;
			string text = txtID.Text.Trim();
			bool flag2 = false;
			if (txtID.Enabled && xTextTableRowElement.ID != text)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ID", xTextTableRowElement.ID, text, xTextTableRowElement);
				}
				xTextTableRowElement.ID = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			foreach (XTextTableRowElement element in SourceEventArgs.Elements)
			{
				text = cboEventTemplateName.Text.Trim();
				if (element.EventTemplateName != text)
				{
					if (flag)
					{
						document.UndoList.AddProperty("EventTemplateName", element.EventTemplateName, text, element);
					}
					element.EventTemplateName = text;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				XAttributeList xAttributeList = (XAttributeList)txtAttributes.Tag;
				if (xAttributeList != element.Attributes)
				{
					if (xAttributeList != null)
					{
						xAttributeList = xAttributeList.Clone();
					}
					if (flag)
					{
						document.UndoList.AddProperty("Attributes", element.Attributes, xAttributeList, element);
					}
					element.Attributes = xAttributeList;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				XDataBinding xDataBinding = (XDataBinding)txtValueBingding.Tag;
				if (xDataBinding != element.ValueBinding)
				{
					if (xDataBinding != null)
					{
						xDataBinding = xDataBinding.Clone();
					}
					if (flag)
					{
						document.UndoList.AddProperty("ValueBinding", element.ValueBinding, xDataBinding, element);
					}
					element.ValueBinding = xDataBinding;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				float num2 = 0f;
				if (chkSpecifyRowHeight.Checked)
				{
					num2 = WriterUtils.smethod_37(document, nudSpecifyRowHeight.Value);
					if (!chkHeightExt.Checked)
					{
						num2 = 0f - num2;
					}
				}
				if (num2 != element.SpecifyHeight)
				{
					if (flag)
					{
						document.UndoList.AddProperty("SpecifyHeight", element.SpecifyHeight, num2, element);
					}
					element.SpecifyHeight = num2;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					flag2 = true;
				}
				if (chkPrintCellBorder.Checked != element.PrintCellBorder)
				{
					if (flag)
					{
						document.UndoList.AddProperty("PrintCellBorder", element.PrintCellBorder, chkPrintCellBorder.Checked, element);
					}
					element.PrintCellBorder = chkPrintCellBorder.Checked;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
					flag2 = true;
				}
				if (chkNewPage.Checked != element.NewPage)
				{
					if (flag)
					{
						document.UndoList.AddProperty("NewPage", element.NewPage, chkNewPage.Checked, element);
					}
					element.NewPage = chkNewPage.Checked;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					flag2 = true;
				}
				if (chkPrintCellBackground.Checked != element.PrintCellBackground)
				{
					if (flag)
					{
						document.UndoList.AddProperty("PrintCellBackground", element.PrintCellBackground, chkPrintCellBackground.Checked, element);
					}
					element.PrintCellBackground = chkPrintCellBackground.Checked;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
					flag2 = true;
				}
				if (chkCanSplitByPageLine.Checked != element.CanSplitByPageLine)
				{
					if (flag)
					{
						document.UndoList.AddProperty("CanSplitByPageLine", element.CanSplitByPageLine, chkSpecifyRowHeight.Checked, element);
					}
					element.CanSplitByPageLine = chkCanSplitByPageLine.Checked;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					flag2 = true;
				}
				DCInsertRowDownUseHotKeys selectedIndex = (DCInsertRowDownUseHotKeys)cboAllowInsertRowDownUseHotKey.SelectedIndex;
				if (selectedIndex != element.AllowInsertRowDownUseHotKey)
				{
					if (flag)
					{
						document.UndoList.AddProperty("AllowInsertRowDownUseHotKey", element.AllowInsertRowDownUseHotKey, selectedIndex, element);
					}
					element.AllowInsertRowDownUseHotKey = selectedIndex;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
					flag2 = true;
				}
				TableRowCloneType selectedIndex2 = (TableRowCloneType)cboCloneType.SelectedIndex;
				if (selectedIndex2 != element.CloneType)
				{
					if (flag)
					{
						document.UndoList.AddProperty("CloneType", element.CloneType, selectedIndex2, element);
					}
					element.CloneType = selectedIndex2;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
					flag2 = true;
				}
				if (chkHeaderRow.Checked != element.HeaderStyle)
				{
					if (flag)
					{
						document.UndoList.AddProperty("HeaderStyle", element.HeaderStyle, chkHeaderRow.Checked, element);
					}
					element.HeaderStyle = chkHeaderRow.Checked;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					flag2 = true;
					bool_0 = true;
				}
				ContentReadonlyState selectedIndex3 = (ContentReadonlyState)cboContentReadonly.SelectedIndex;
				if (selectedIndex3 != element.ContentReadonly && flag)
				{
					document.UndoList.AddProperty("ContentReadonly", element.ContentReadonly, selectedIndex3, element);
					element.ContentReadonly = selectedIndex3;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				PropertyExpressionInfoList propertyExpressionInfoList = (PropertyExpressionInfoList)txtMemberExpressions.Tag;
				if (propertyExpressionInfoList != element.PropertyExpressions)
				{
					if (flag)
					{
						document.UndoList.AddProperty("PropertyExpressions", element.PropertyExpressions, propertyExpressionInfoList, element);
					}
					element.PropertyExpressions = propertyExpressionInfoList;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
				DCBooleanValue selectedIndex4 = (DCBooleanValue)cboEnablePermission.SelectedIndex;
				if (selectedIndex4 != element.EnablePermission)
				{
					if (flag)
					{
						document.UndoList.AddProperty("EnablePermission", element.EnablePermission, selectedIndex4, element);
					}
					element.EnablePermission = selectedIndex4;
					flag2 = true;
					SourceEventArgs.SetContentEffect(ContentEffects.Content);
				}
			}
			if (flag2)
			{
				base.DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void btnBrowseAttribute_Click(object sender, EventArgs e)
		{
			using (dlgAttributes dlgAttributes = new dlgAttributes())
			{
				dlgAttributes.InputAttributes = (XAttributeList)txtAttributes.Tag;
				if (dlgAttributes.ShowDialog(this) == DialogResult.OK)
				{
					txtAttributes.Tag = dlgAttributes.InputAttributes;
					txtAttributes.Text = dlgAttributes.InputAttributes.ToString();
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnValueBinding_Click(object sender, EventArgs e)
		{
			using (dlgXDataBinding dlgXDataBinding = new dlgXDataBinding())
			{
				dlgXDataBinding.XDataBinding = (XDataBinding)txtValueBingding.Tag;
				if (SourceEventArgs != null)
				{
					dlgXDataBinding.Document = SourceEventArgs.Document;
				}
				if (dlgXDataBinding.XDataBinding == null)
				{
					dlgXDataBinding.XDataBinding = new XDataBinding();
				}
				if (dlgXDataBinding.ShowDialog(this) == DialogResult.OK)
				{
					txtValueBingding.Tag = dlgXDataBinding.XDataBinding;
					txtValueBingding.Text = dlgXDataBinding.XDataBinding.ToString();
				}
			}
		}

		private void chkPrintCellBackground_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void btnBrowseMemberExpressions_Click(object sender, EventArgs e)
		{
			using (dlgPropertyExpressionInfoList dlgPropertyExpressionInfoList = new dlgPropertyExpressionInfoList())
			{
				dlgPropertyExpressionInfoList.InputInfos = (PropertyExpressionInfoList)txtMemberExpressions.Tag;
				dlgPropertyExpressionInfoList.InputOwner = SourceEventArgs.Element;
				if (dlgPropertyExpressionInfoList.InputInfos == null)
				{
					dlgPropertyExpressionInfoList.InputInfos = new PropertyExpressionInfoList();
				}
				else
				{
					dlgPropertyExpressionInfoList.InputInfos = dlgPropertyExpressionInfoList.InputInfos.Clone();
				}
				if (dlgPropertyExpressionInfoList.ShowDialog(this) == DialogResult.OK)
				{
					txtMemberExpressions.Tag = dlgPropertyExpressionInfoList.InputInfos;
					txtMemberExpressions.Text = dlgPropertyExpressionInfoList.InputInfos.ToString();
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgTableRowProperties));
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			btnBrowseAttribute = new System.Windows.Forms.Button();
			txtAttributes = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			chkSpecifyRowHeight = new System.Windows.Forms.CheckBox();
			nudSpecifyRowHeight = new System.Windows.Forms.NumericUpDown();
			chkHeaderRow = new System.Windows.Forms.CheckBox();
			chkHeightExt = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			cboCloneType = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			cboEventTemplateName = new System.Windows.Forms.ComboBox();
			chkCanSplitByPageLine = new System.Windows.Forms.CheckBox();
			lblCurrentHeight = new System.Windows.Forms.Label();
			cboContentReadonly = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			cboEnablePermission = new System.Windows.Forms.ComboBox();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			txtValueBingding = new System.Windows.Forms.TextBox();
			btnValueBinding = new System.Windows.Forms.Button();
			chkPrintCellBorder = new System.Windows.Forms.CheckBox();
			chkPrintCellBackground = new System.Windows.Forms.CheckBox();
			chkNewPage = new System.Windows.Forms.CheckBox();
			btnBrowseMemberExpressions = new System.Windows.Forms.Button();
			label32 = new System.Windows.Forms.Label();
			txtMemberExpressions = new System.Windows.Forms.TextBox();
			cboAllowInsertRowDownUseHotKey = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)nudSpecifyRowHeight).BeginInit();
			SuspendLayout();
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnBrowseAttribute, "btnBrowseAttribute");
			btnBrowseAttribute.Name = "btnBrowseAttribute";
			btnBrowseAttribute.UseVisualStyleBackColor = true;
			btnBrowseAttribute.Click += new System.EventHandler(btnBrowseAttribute_Click);
			resources.ApplyResources(txtAttributes, "txtAttributes");
			txtAttributes.Name = "txtAttributes";
			txtAttributes.ReadOnly = true;
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(chkSpecifyRowHeight, "chkSpecifyRowHeight");
			chkSpecifyRowHeight.Name = "chkSpecifyRowHeight";
			chkSpecifyRowHeight.UseVisualStyleBackColor = true;
			chkSpecifyRowHeight.CheckedChanged += new System.EventHandler(chkSpecifyRowHeight_CheckedChanged);
			nudSpecifyRowHeight.DecimalPlaces = 2;
			resources.ApplyResources(nudSpecifyRowHeight, "nudSpecifyRowHeight");
			nudSpecifyRowHeight.Maximum = new decimal(new int[4]
			{
				50,
				0,
				0,
				0
			});
			nudSpecifyRowHeight.Minimum = new decimal(new int[4]
			{
				50,
				0,
				0,
				-2147483648
			});
			nudSpecifyRowHeight.Name = "nudSpecifyRowHeight";
			resources.ApplyResources(chkHeaderRow, "chkHeaderRow");
			chkHeaderRow.Name = "chkHeaderRow";
			chkHeaderRow.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkHeightExt, "chkHeightExt");
			chkHeightExt.Name = "chkHeightExt";
			chkHeightExt.UseVisualStyleBackColor = true;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			cboCloneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboCloneType.FormattingEnabled = true;
			cboCloneType.Items.AddRange(new object[3]
			{
				resources.GetString("cboCloneType.Items"),
				resources.GetString("cboCloneType.Items1"),
				resources.GetString("cboCloneType.Items2")
			});
			resources.ApplyResources(cboCloneType, "cboCloneType");
			cboCloneType.Name = "cboCloneType";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			cboEventTemplateName.FormattingEnabled = true;
			resources.ApplyResources(cboEventTemplateName, "cboEventTemplateName");
			cboEventTemplateName.Name = "cboEventTemplateName";
			resources.ApplyResources(chkCanSplitByPageLine, "chkCanSplitByPageLine");
			chkCanSplitByPageLine.Name = "chkCanSplitByPageLine";
			chkCanSplitByPageLine.UseVisualStyleBackColor = true;
			resources.ApplyResources(lblCurrentHeight, "lblCurrentHeight");
			lblCurrentHeight.Name = "lblCurrentHeight";
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
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboEnablePermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboEnablePermission.FormattingEnabled = true;
			cboEnablePermission.Items.AddRange(new object[3]
			{
				resources.GetString("cboEnablePermission.Items"),
				resources.GetString("cboEnablePermission.Items1"),
				resources.GetString("cboEnablePermission.Items2")
			});
			resources.ApplyResources(cboEnablePermission, "cboEnablePermission");
			cboEnablePermission.Name = "cboEnablePermission";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(txtValueBingding, "txtValueBingding");
			txtValueBingding.Name = "txtValueBingding";
			txtValueBingding.ReadOnly = true;
			resources.ApplyResources(btnValueBinding, "btnValueBinding");
			btnValueBinding.Name = "btnValueBinding";
			btnValueBinding.UseVisualStyleBackColor = true;
			btnValueBinding.Click += new System.EventHandler(btnValueBinding_Click);
			resources.ApplyResources(chkPrintCellBorder, "chkPrintCellBorder");
			chkPrintCellBorder.Name = "chkPrintCellBorder";
			chkPrintCellBorder.UseVisualStyleBackColor = true;
			chkPrintCellBorder.CheckedChanged += new System.EventHandler(chkPrintCellBackground_CheckedChanged);
			resources.ApplyResources(chkPrintCellBackground, "chkPrintCellBackground");
			chkPrintCellBackground.Name = "chkPrintCellBackground";
			chkPrintCellBackground.UseVisualStyleBackColor = true;
			chkPrintCellBackground.CheckedChanged += new System.EventHandler(chkPrintCellBackground_CheckedChanged);
			resources.ApplyResources(chkNewPage, "chkNewPage");
			chkNewPage.Name = "chkNewPage";
			chkNewPage.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnBrowseMemberExpressions, "btnBrowseMemberExpressions");
			btnBrowseMemberExpressions.Name = "btnBrowseMemberExpressions";
			btnBrowseMemberExpressions.UseVisualStyleBackColor = true;
			btnBrowseMemberExpressions.Click += new System.EventHandler(btnBrowseMemberExpressions_Click);
			resources.ApplyResources(label32, "label32");
			label32.Name = "label32";
			resources.ApplyResources(txtMemberExpressions, "txtMemberExpressions");
			txtMemberExpressions.Name = "txtMemberExpressions";
			txtMemberExpressions.ReadOnly = true;
			cboAllowInsertRowDownUseHotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboAllowInsertRowDownUseHotKey.FormattingEnabled = true;
			cboAllowInsertRowDownUseHotKey.Items.AddRange(new object[3]
			{
				resources.GetString("cboAllowInsertRowDownUseHotKey.Items"),
				resources.GetString("cboAllowInsertRowDownUseHotKey.Items1"),
				resources.GetString("cboAllowInsertRowDownUseHotKey.Items2")
			});
			resources.ApplyResources(cboAllowInsertRowDownUseHotKey, "cboAllowInsertRowDownUseHotKey");
			cboAllowInsertRowDownUseHotKey.Name = "cboAllowInsertRowDownUseHotKey";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(cboAllowInsertRowDownUseHotKey);
			base.Controls.Add(label8);
			base.Controls.Add(btnBrowseMemberExpressions);
			base.Controls.Add(label32);
			base.Controls.Add(txtMemberExpressions);
			base.Controls.Add(chkPrintCellBackground);
			base.Controls.Add(chkPrintCellBorder);
			base.Controls.Add(cboEnablePermission);
			base.Controls.Add(label6);
			base.Controls.Add(cboContentReadonly);
			base.Controls.Add(label3);
			base.Controls.Add(lblCurrentHeight);
			base.Controls.Add(cboEventTemplateName);
			base.Controls.Add(label5);
			base.Controls.Add(cboCloneType);
			base.Controls.Add(label4);
			base.Controls.Add(chkHeightExt);
			base.Controls.Add(chkNewPage);
			base.Controls.Add(chkCanSplitByPageLine);
			base.Controls.Add(chkHeaderRow);
			base.Controls.Add(nudSpecifyRowHeight);
			base.Controls.Add(chkSpecifyRowHeight);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(btnValueBinding);
			base.Controls.Add(btnBrowseAttribute);
			base.Controls.Add(txtValueBingding);
			base.Controls.Add(label7);
			base.Controls.Add(txtAttributes);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTableRowProperties";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgTableRowProperties_Load);
			((System.ComponentModel.ISupportInitialize)nudSpecifyRowHeight).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
