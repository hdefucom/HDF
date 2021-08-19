using DCSoft.Writer.Dom;
using DCSoft.Writer.Dom.Design;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       表格属性
	///       </summary>
	[ComVisible(false)]
	public class dlgTableProperties : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtAttributes;

		private Button btnBrowseAttribute;

		private Button btnOK;

		private Button btnCancel;

		private ComboBox cboEventTemplateName;

		private Label label8;

		private CheckBox chkAllowUserToResizeRows;

		private CheckBox chkAllowUserToResizeColumns;

		private CheckBox chkDeleteable;

		private ComboBox cboContentReadonly;

		private Label label5;

		private Label label6;

		private ComboBox cboEnablePermission;

		private CheckBox chkPrintBothBorderWhenJumpPrint;

		private CheckBox chkHoldWholeLine;

		private CheckBox chkCompressOwnerLineSpacing;

		private CheckBox chkAllowUserInsertRow;

		private CheckBox chkAllowUserDeleteRow;

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
		///       初始化对象
		///       </summary>
		public dlgTableProperties()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgTableProperties_Load(object sender, EventArgs e)
		{
			if (SourceEventArgs != null)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)SourceEventArgs.Element;
				txtID.Text = xTextTableElement.ID;
				if (xTextTableElement.Attributes != null)
				{
					txtAttributes.Text = xTextTableElement.Attributes.ToString();
					txtAttributes.Tag = xTextTableElement.Attributes.Clone();
				}
				cboEventTemplateName.Text = xTextTableElement.EventTemplateName;
				chkAllowUserToResizeColumns.Checked = xTextTableElement.AllowUserToResizeColumns;
				chkAllowUserToResizeRows.Checked = xTextTableElement.AllowUserToResizeRows;
				chkDeleteable.Checked = xTextTableElement.Deleteable;
				cboContentReadonly.SelectedIndex = (int)xTextTableElement.ContentReadonly;
				cboEnablePermission.SelectedIndex = (int)xTextTableElement.EnablePermission;
				chkPrintBothBorderWhenJumpPrint.Checked = xTextTableElement.PrintBothBorderWhenJumpPrint;
				chkHoldWholeLine.Checked = xTextTableElement.HoldWholeLine;
				chkCompressOwnerLineSpacing.Checked = xTextTableElement.CompressOwnerLineSpacing;
				chkAllowUserDeleteRow.Checked = xTextTableElement.AllowUserDeleteRow;
				chkAllowUserInsertRow.Checked = xTextTableElement.AllowUserInsertRow;
			}
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

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 6;
			if (SourceEventArgs == null)
			{
				return;
			}
			SourceEventArgs.ContentEffect = ContentEffects.None;
			XTextTableElement xTextTableElement = (XTextTableElement)SourceEventArgs.Element;
			XTextDocument document = SourceEventArgs.Document;
			bool flag = SourceEventArgs.LogUndo && document.CanLogUndo;
			string text = txtID.Text.Trim();
			bool flag2 = false;
			if (xTextTableElement.ID != text)
			{
				if (flag)
				{
					document.UndoList.AddProperty("ID", xTextTableElement.ID, text, xTextTableElement);
				}
				xTextTableElement.ID = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = cboEventTemplateName.Text.Trim();
			if (!WriterUtils.smethod_43(xTextTableElement.EventTemplateName, text))
			{
				if (flag)
				{
					document.UndoList.AddProperty("EventTemplateName", xTextTableElement.EventTemplateName, text, xTextTableElement);
				}
				xTextTableElement.EventTemplateName = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			XAttributeList xAttributeList = (XAttributeList)txtAttributes.Tag;
			if (xAttributeList != xTextTableElement.Attributes)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Attributes", xTextTableElement.Attributes, xAttributeList, xTextTableElement);
				}
				xTextTableElement.Attributes = xAttributeList;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkPrintBothBorderWhenJumpPrint.Checked != xTextTableElement.PrintBothBorderWhenJumpPrint)
			{
				if (flag)
				{
					document.UndoList.AddProperty("PrintBothBorderWhenJumpPrint", xTextTableElement.PrintBothBorderWhenJumpPrint, chkPrintBothBorderWhenJumpPrint.Checked, xTextTableElement);
				}
				xTextTableElement.PrintBothBorderWhenJumpPrint = chkPrintBothBorderWhenJumpPrint.Checked;
				xTextTableElement.ResetPrintBorderStateForJumPrint();
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkCompressOwnerLineSpacing.Checked != xTextTableElement.CompressOwnerLineSpacing)
			{
				if (flag)
				{
					document.UndoList.AddProperty("CompressOwnerLineSpacing", xTextTableElement.CompressOwnerLineSpacing, chkCompressOwnerLineSpacing.Checked, xTextTableElement);
				}
				xTextTableElement.CompressOwnerLineSpacing = chkCompressOwnerLineSpacing.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			if (chkAllowUserInsertRow.Checked != xTextTableElement.AllowUserInsertRow)
			{
				if (flag)
				{
					document.UndoList.AddProperty("AllowUserInsertRow", xTextTableElement.AllowUserInsertRow, chkAllowUserInsertRow.Checked, xTextTableElement);
				}
				xTextTableElement.AllowUserInsertRow = chkAllowUserInsertRow.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkAllowUserDeleteRow.Checked != xTextTableElement.AllowUserDeleteRow)
			{
				if (flag)
				{
					document.UndoList.AddProperty("AllowUserDeleteRow", xTextTableElement.AllowUserDeleteRow, chkAllowUserDeleteRow.Checked, xTextTableElement);
				}
				xTextTableElement.AllowUserDeleteRow = chkAllowUserDeleteRow.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkAllowUserToResizeRows.Checked != xTextTableElement.AllowUserToResizeRows)
			{
				if (flag)
				{
					document.UndoList.AddProperty("AllowUserToResizeRows", xTextTableElement.AllowUserToResizeRows, chkAllowUserToResizeRows.Checked, xTextTableElement);
				}
				xTextTableElement.AllowUserToResizeRows = chkAllowUserToResizeRows.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkAllowUserToResizeColumns.Checked != xTextTableElement.AllowUserToResizeColumns)
			{
				if (flag)
				{
					document.UndoList.AddProperty("AllowUserToResizeColumns", xTextTableElement.AllowUserToResizeColumns, chkAllowUserToResizeColumns.Checked, xTextTableElement);
				}
				xTextTableElement.AllowUserToResizeColumns = chkAllowUserToResizeColumns.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (chkHoldWholeLine.Checked != xTextTableElement.HoldWholeLine)
			{
				if (flag)
				{
					document.UndoList.AddProperty("HoldWholeLine", xTextTableElement.HoldWholeLine, chkHoldWholeLine.Checked, xTextTableElement);
				}
				xTextTableElement.HoldWholeLine = chkHoldWholeLine.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			if (chkDeleteable.Checked != xTextTableElement.Deleteable)
			{
				if (flag)
				{
					document.UndoList.AddProperty("Deleteable", xTextTableElement.Deleteable, chkDeleteable.Checked, xTextTableElement);
				}
				xTextTableElement.Deleteable = chkDeleteable.Checked;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			ContentReadonlyState selectedIndex = (ContentReadonlyState)cboContentReadonly.SelectedIndex;
			if (selectedIndex != xTextTableElement.ContentReadonly && flag)
			{
				document.UndoList.AddProperty("ContentReadonly", xTextTableElement.ContentReadonly, selectedIndex, xTextTableElement);
				xTextTableElement.ContentReadonly = selectedIndex;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			DCBooleanValue selectedIndex2 = (DCBooleanValue)cboEnablePermission.SelectedIndex;
			if (selectedIndex2 != xTextTableElement.EnablePermission)
			{
				if (flag)
				{
					document.UndoList.AddProperty("EnablePermission", xTextTableElement.EnablePermission, selectedIndex2, xTextTableElement);
				}
				xTextTableElement.EnablePermission = selectedIndex2;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (flag2)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgTableProperties));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtAttributes = new System.Windows.Forms.TextBox();
			btnBrowseAttribute = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			cboEventTemplateName = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			chkAllowUserToResizeRows = new System.Windows.Forms.CheckBox();
			chkAllowUserToResizeColumns = new System.Windows.Forms.CheckBox();
			chkDeleteable = new System.Windows.Forms.CheckBox();
			cboContentReadonly = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			cboEnablePermission = new System.Windows.Forms.ComboBox();
			chkPrintBothBorderWhenJumpPrint = new System.Windows.Forms.CheckBox();
			chkHoldWholeLine = new System.Windows.Forms.CheckBox();
			chkCompressOwnerLineSpacing = new System.Windows.Forms.CheckBox();
			chkAllowUserInsertRow = new System.Windows.Forms.CheckBox();
			chkAllowUserDeleteRow = new System.Windows.Forms.CheckBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtAttributes, "txtAttributes");
			txtAttributes.Name = "txtAttributes";
			txtAttributes.ReadOnly = true;
			resources.ApplyResources(btnBrowseAttribute, "btnBrowseAttribute");
			btnBrowseAttribute.Name = "btnBrowseAttribute";
			btnBrowseAttribute.UseVisualStyleBackColor = true;
			btnBrowseAttribute.Click += new System.EventHandler(btnBrowseAttribute_Click);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			cboEventTemplateName.FormattingEnabled = true;
			resources.ApplyResources(cboEventTemplateName, "cboEventTemplateName");
			cboEventTemplateName.Name = "cboEventTemplateName";
			resources.ApplyResources(label8, "label8");
			label8.Name = "label8";
			resources.ApplyResources(chkAllowUserToResizeRows, "chkAllowUserToResizeRows");
			chkAllowUserToResizeRows.Name = "chkAllowUserToResizeRows";
			chkAllowUserToResizeRows.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkAllowUserToResizeColumns, "chkAllowUserToResizeColumns");
			chkAllowUserToResizeColumns.Name = "chkAllowUserToResizeColumns";
			chkAllowUserToResizeColumns.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkDeleteable, "chkDeleteable");
			chkDeleteable.Name = "chkDeleteable";
			chkDeleteable.UseVisualStyleBackColor = true;
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
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
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
			resources.ApplyResources(chkPrintBothBorderWhenJumpPrint, "chkPrintBothBorderWhenJumpPrint");
			chkPrintBothBorderWhenJumpPrint.Name = "chkPrintBothBorderWhenJumpPrint";
			chkPrintBothBorderWhenJumpPrint.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkHoldWholeLine, "chkHoldWholeLine");
			chkHoldWholeLine.Name = "chkHoldWholeLine";
			chkHoldWholeLine.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkCompressOwnerLineSpacing, "chkCompressOwnerLineSpacing");
			chkCompressOwnerLineSpacing.Name = "chkCompressOwnerLineSpacing";
			chkCompressOwnerLineSpacing.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkAllowUserInsertRow, "chkAllowUserInsertRow");
			chkAllowUserInsertRow.Name = "chkAllowUserInsertRow";
			chkAllowUserInsertRow.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkAllowUserDeleteRow, "chkAllowUserDeleteRow");
			chkAllowUserDeleteRow.Name = "chkAllowUserDeleteRow";
			chkAllowUserDeleteRow.UseVisualStyleBackColor = true;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(chkCompressOwnerLineSpacing);
			base.Controls.Add(chkHoldWholeLine);
			base.Controls.Add(chkPrintBothBorderWhenJumpPrint);
			base.Controls.Add(cboEnablePermission);
			base.Controls.Add(label6);
			base.Controls.Add(cboContentReadonly);
			base.Controls.Add(label5);
			base.Controls.Add(chkDeleteable);
			base.Controls.Add(chkAllowUserDeleteRow);
			base.Controls.Add(chkAllowUserInsertRow);
			base.Controls.Add(chkAllowUserToResizeColumns);
			base.Controls.Add(chkAllowUserToResizeRows);
			base.Controls.Add(cboEventTemplateName);
			base.Controls.Add(label8);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(btnBrowseAttribute);
			base.Controls.Add(txtAttributes);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTableProperties";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgTableProperties_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
