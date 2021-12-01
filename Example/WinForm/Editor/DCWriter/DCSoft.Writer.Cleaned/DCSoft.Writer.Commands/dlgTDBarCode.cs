using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       二维条码属性对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgTDBarCode : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private Button btnCreateImage;

		private TextBox txtText;

		private PictureBox picPreview;

		private Label label3;

		private ComboBox cboCodeMode;

		private ComboBox cboCodeErrorCorrection;

		private Label label8;

		private Button btnOK;

		private Button btnCancel;

		private GroupBox groupBox1;

		private Label label2;

		private TextBox txtID;

		private Label label4;

		private Button btnValueBingding;

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
		///       默认构造函数
		///       </summary>
		public dlgTDBarCode()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			base.Load += dlgTDBarCode_Load;
			btnOK.Click += btnOK_Click;
			btnCancel.Click += btnCancel_Click;
			btnCreateImage.Click += btnCreateImage_Click;
		}

		private void dlgTDBarCode_Load(object sender, EventArgs e)
		{
			foreach (object value in Enum.GetValues(typeof(DCTDBarcodeType)))
			{
				cboCodeMode.Items.Add(value);
			}
			if (SourceEventArgs != null && SourceEventArgs.Element is XTextTDBarcodeElement)
			{
				XTextTDBarcodeElement xTextTDBarcodeElement = (XTextTDBarcodeElement)SourceEventArgs.Element;
				txtID.Text = xTextTDBarcodeElement.ID;
				txtText.Text = xTextTDBarcodeElement.Text;
				cboCodeMode.SelectedIndex = (int)xTextTDBarcodeElement.BarcodeType;
				cboCodeErrorCorrection.SelectedIndex = (int)xTextTDBarcodeElement.ErroeCorrectionLevel;
				btnValueBingding.Tag = xTextTDBarcodeElement.ValueBinding;
				if (xTextTDBarcodeElement.ValueBinding != null)
				{
					btnValueBingding.Text = xTextTDBarcodeElement.ValueBinding.ToString();
				}
			}
			btnCreateImage_Click(null, null);
		}

		private bool method_0(XTextTDBarcodeElement xtextTDBarcodeElement_0, bool bool_0)
		{
			int num = 1;
			bool result = false;
			XTextDocument document = SourceEventArgs.Document;
			if (!WriterUtils.smethod_43(txtID.Text, xtextTDBarcodeElement_0.ID))
			{
				if (bool_0)
				{
					document.UndoList.AddProperty("ID", xtextTDBarcodeElement_0.ID, txtID.Text, xtextTDBarcodeElement_0);
				}
				xtextTDBarcodeElement_0.ID = txtID.Text;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
				result = true;
			}
			DCTDBarcodeType selectedIndex = (DCTDBarcodeType)cboCodeMode.SelectedIndex;
			if (selectedIndex != xtextTDBarcodeElement_0.BarcodeType)
			{
				if (bool_0)
				{
					document.UndoList.AddProperty("BarcodeType", xtextTDBarcodeElement_0.BarcodeType, selectedIndex, xtextTDBarcodeElement_0);
				}
				xtextTDBarcodeElement_0.BarcodeType = selectedIndex;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
				result = true;
			}
			DCTBErroeCorrectionLevelType selectedIndex2 = (DCTBErroeCorrectionLevelType)cboCodeErrorCorrection.SelectedIndex;
			if (selectedIndex2 != xtextTDBarcodeElement_0.ErroeCorrectionLevel)
			{
				if (bool_0)
				{
					document.UndoList.AddProperty("ErroeCorrectionLevel", xtextTDBarcodeElement_0.ErroeCorrectionLevel, selectedIndex2, xtextTDBarcodeElement_0);
				}
				xtextTDBarcodeElement_0.ErroeCorrectionLevel = selectedIndex2;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
				result = true;
			}
			if (!WriterUtils.smethod_43(txtText.Text, xtextTDBarcodeElement_0.Text))
			{
				if (bool_0)
				{
					document.UndoList.AddProperty("Text", xtextTDBarcodeElement_0.Text, txtText.Text, xtextTDBarcodeElement_0);
				}
				xtextTDBarcodeElement_0.Text = txtText.Text;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
				result = true;
			}
			XDataBinding xDataBinding = (XDataBinding)btnValueBingding.Tag;
			if (xDataBinding != xtextTDBarcodeElement_0.ValueBinding)
			{
				if (bool_0)
				{
					document.UndoList.AddProperty("ValueBinding", xtextTDBarcodeElement_0.ValueBinding, xDataBinding, xtextTDBarcodeElement_0);
				}
				xtextTDBarcodeElement_0.ValueBinding = xDataBinding;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
				result = true;
			}
			return result;
		}

		/// <summary>
		///       生成二维码
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnCreateImage_Click(object sender, EventArgs e)
		{
			try
			{
				XTextTDBarcodeElement xTextTDBarcodeElement = new XTextTDBarcodeElement();
				method_0(xTextTDBarcodeElement, bool_0: false);
				int int_ = picPreview.ClientSize.Width - 5;
				int int_2 = picPreview.ClientSize.Height - 5;
				picPreview.Image = (Image)XTextTDBarcodeElement.smethod_2(xTextTDBarcodeElement.BarcodeType, xTextTDBarcodeElement.ErroeCorrectionLevel, xTextTDBarcodeElement.Text, ref int_, ref int_2, 1);
				txtText.Focus();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			bool bool_ = SourceEventArgs.Document != null && SourceEventArgs.Document.CanLogUndo && SourceEventArgs.LogUndo;
			method_0(SourceEventArgs.Element as XTextTDBarcodeElement, bool_);
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnValueBingding_Click(object sender, EventArgs e)
		{
			dlgXDataBinding.smethod_0(btnValueBingding, SourceEventArgs.Document, SourceEventArgs.Element);
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
			cboCodeErrorCorrection = new System.Windows.Forms.ComboBox();
			label8 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnCreateImage = new System.Windows.Forms.Button();
			txtText = new System.Windows.Forms.TextBox();
			picPreview = new System.Windows.Forms.PictureBox();
			label3 = new System.Windows.Forms.Label();
			cboCodeMode = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label2 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			btnValueBingding = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			cboCodeErrorCorrection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboCodeErrorCorrection.FormattingEnabled = true;
			cboCodeErrorCorrection.Items.AddRange(new object[4]
			{
				"L:7%的字码可被修正",
				"M:15%的字码可被修正",
				"Q:25%的字码可被修正",
				"H:30%的字码可被修正"
			});
			cboCodeErrorCorrection.Location = new System.Drawing.Point(78, 145);
			cboCodeErrorCorrection.MaxDropDownItems = 20;
			cboCodeErrorCorrection.Name = "cboCodeErrorCorrection";
			cboCodeErrorCorrection.Size = new System.Drawing.Size(182, 20);
			cboCodeErrorCorrection.TabIndex = 17;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(12, 148);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(59, 12);
			label8.TabIndex = 18;
			label8.Text = "纠错能力:";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(11, 54);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(35, 12);
			label1.TabIndex = 0;
			label1.Text = "文本:";
			btnCreateImage.Location = new System.Drawing.Point(41, 15);
			btnCreateImage.Name = "btnCreateImage";
			btnCreateImage.Size = new System.Drawing.Size(75, 23);
			btnCreateImage.TabIndex = 11;
			btnCreateImage.Text = "刷新";
			btnCreateImage.UseVisualStyleBackColor = true;
			btnCreateImage.Click += new System.EventHandler(btnCreateImage_Click);
			txtText.Location = new System.Drawing.Point(78, 33);
			txtText.Multiline = true;
			txtText.Name = "txtText";
			txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtText.Size = new System.Drawing.Size(182, 72);
			txtText.TabIndex = 0;
			picPreview.BackColor = System.Drawing.SystemColors.Control;
			picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			picPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
			picPreview.Location = new System.Drawing.Point(3, 44);
			picPreview.Name = "picPreview";
			picPreview.Size = new System.Drawing.Size(265, 241);
			picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			picPreview.TabIndex = 0;
			picPreview.TabStop = false;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(12, 122);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(35, 12);
			label3.TabIndex = 4;
			label3.Text = "类型:";
			cboCodeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboCodeMode.FormattingEnabled = true;
			cboCodeMode.Location = new System.Drawing.Point(78, 119);
			cboCodeMode.MaxDropDownItems = 20;
			cboCodeMode.Name = "cboCodeMode";
			cboCodeMode.Size = new System.Drawing.Size(182, 20);
			cboCodeMode.TabIndex = 2;
			btnOK.Location = new System.Drawing.Point(147, 313);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(116, 23);
			btnOK.TabIndex = 19;
			btnOK.Text = "确定(&O)";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(283, 313);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(116, 23);
			btnCancel.TabIndex = 19;
			btnCancel.Text = "取消(&C)";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			groupBox1.Controls.Add(picPreview);
			groupBox1.Controls.Add(btnCreateImage);
			groupBox1.Location = new System.Drawing.Point(280, 6);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(271, 288);
			groupBox1.TabIndex = 20;
			groupBox1.TabStop = false;
			groupBox1.Text = "预览";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(35, 12);
			label2.TabIndex = 21;
			label2.Text = "编号:";
			txtID.Location = new System.Drawing.Point(78, 6);
			txtID.Name = "txtID";
			txtID.Size = new System.Drawing.Size(182, 21);
			txtID.TabIndex = 0;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(12, 190);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(47, 12);
			label4.TabIndex = 22;
			label4.Text = "数据源:";
			btnValueBingding.Location = new System.Drawing.Point(78, 185);
			btnValueBingding.Name = "btnValueBingding";
			btnValueBingding.Size = new System.Drawing.Size(182, 23);
			btnValueBingding.TabIndex = 23;
			btnValueBingding.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnValueBingding.UseVisualStyleBackColor = true;
			btnValueBingding.Click += new System.EventHandler(btnValueBingding_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(561, 344);
			base.Controls.Add(btnValueBingding);
			base.Controls.Add(label4);
			base.Controls.Add(txtID);
			base.Controls.Add(label2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(cboCodeErrorCorrection);
			base.Controls.Add(label8);
			base.Controls.Add(label1);
			base.Controls.Add(cboCodeMode);
			base.Controls.Add(label3);
			base.Controls.Add(txtText);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgTDBarCode";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "二维码";
			base.Load += new System.EventHandler(dlgTDBarCode_Load);
			((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
