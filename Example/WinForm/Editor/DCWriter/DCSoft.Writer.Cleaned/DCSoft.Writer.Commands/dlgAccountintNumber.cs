using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       会计数字窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgAccountintNumber : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtName;

		private CheckBox chkShowGrid;

		private CheckBox chkPrintGrid;

		private Label label3;

		private ComboBox cboUnitMode;

		private Label label4;

		private NumericUpDown nudDigitals;

		private Button btnOK;

		private Button btnCancel;

		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		/// <summary>
		///       事件参数
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgAccountintNumber));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			chkShowGrid = new System.Windows.Forms.CheckBox();
			chkPrintGrid = new System.Windows.Forms.CheckBox();
			label3 = new System.Windows.Forms.Label();
			cboUnitMode = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			nudDigitals = new System.Windows.Forms.NumericUpDown();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)nudDigitals).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(chkShowGrid, "chkShowGrid");
			chkShowGrid.Name = "chkShowGrid";
			chkShowGrid.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkPrintGrid, "chkPrintGrid");
			chkPrintGrid.Name = "chkPrintGrid";
			chkPrintGrid.UseVisualStyleBackColor = true;
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboUnitMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboUnitMode.FormattingEnabled = true;
			cboUnitMode.Items.AddRange(new object[2]
			{
				resources.GetString("cboUnitMode.Items"),
				resources.GetString("cboUnitMode.Items1")
			});
			resources.ApplyResources(cboUnitMode, "cboUnitMode");
			cboUnitMode.Name = "cboUnitMode";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(nudDigitals, "nudDigitals");
			nudDigitals.Name = "nudDigitals";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(nudDigitals);
			base.Controls.Add(label4);
			base.Controls.Add(cboUnitMode);
			base.Controls.Add(label3);
			base.Controls.Add(chkPrintGrid);
			base.Controls.Add(chkShowGrid);
			base.Controls.Add(txtName);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgAccountintNumber";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgAccountintNumber_Load);
			((System.ComponentModel.ISupportInitialize)nudDigitals).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgAccountintNumber()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgAccountintNumber_Load(object sender, EventArgs e)
		{
			if (SourceEventArgs != null && SourceEventArgs.Element is XTextAccountingNumberElement)
			{
				XTextAccountingNumberElement xTextAccountingNumberElement = (XTextAccountingNumberElement)SourceEventArgs.Element;
				txtID.Text = xTextAccountingNumberElement.ID;
				txtName.Text = xTextAccountingNumberElement.Name;
				chkPrintGrid.Checked = xTextAccountingNumberElement.PrintGrid;
				chkShowGrid.Checked = xTextAccountingNumberElement.ShowGrid;
				nudDigitals.Value = xTextAccountingNumberElement.Digitals;
				cboUnitMode.SelectedIndex = (int)xTextAccountingNumberElement.UnitMode;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (SourceEventArgs == null || !(SourceEventArgs.Element is XTextAccountingNumberElement))
			{
				return;
			}
			XTextAccountingNumberElement xTextAccountingNumberElement = (XTextAccountingNumberElement)SourceEventArgs.Element;
			_ = SourceEventArgs.Document;
			bool bool_ = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
			bool flag = false;
			if (WriterUtils.smethod_27(xTextAccountingNumberElement, "ID", txtID.Text.Trim(), bool_))
			{
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (WriterUtils.smethod_27(xTextAccountingNumberElement, "Name", txtName.Text.Trim(), bool_))
			{
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (WriterUtils.smethod_27(xTextAccountingNumberElement, "ShowGrid", chkShowGrid.Checked, bool_))
			{
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			if (WriterUtils.smethod_27(xTextAccountingNumberElement, "PrintGrid", chkPrintGrid.Checked, bool_))
			{
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (WriterUtils.smethod_27(xTextAccountingNumberElement, "Digitals", Convert.ToInt32(nudDigitals.Value), bool_))
			{
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			if (WriterUtils.smethod_27(xTextAccountingNumberElement, "UnitMode", (AccountingNumberUnitMode)cboUnitMode.SelectedIndex, bool_))
			{
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag)
				{
					xTextAccountingNumberElement.InvalidateView();
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = SourceEventArgs.Document;
					contentChangedEventArgs.Element = xTextAccountingNumberElement;
					contentChangedEventArgs.LoadingDocument = false;
					xTextAccountingNumberElement.method_23(contentChangedEventArgs);
					base.DialogResult = DialogResult.OK;
				}
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
