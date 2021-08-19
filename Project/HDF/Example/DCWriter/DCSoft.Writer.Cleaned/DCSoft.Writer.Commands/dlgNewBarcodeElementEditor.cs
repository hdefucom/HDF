using DCSoft.Barcode;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       条码元素编辑对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgNewBarcodeElementEditor : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private TextBox txtName;

		private Label label3;

		private ComboBox cboBarcodeStyle;

		private Label label4;

		private ComboBox cboTextAlignment;

		private CheckBox chkShowText;

		private GroupBox groupBox1;

		private Button btnOK;

		private Button btnCancel;

		private PictureBox picPreview;

		private Label label6;

		private TextBox txtText;

		private Button btnValueBingding;

		private Label label7;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgNewBarcodeElementEditor));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			cboBarcodeStyle = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			cboTextAlignment = new System.Windows.Forms.ComboBox();
			chkShowText = new System.Windows.Forms.CheckBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			picPreview = new System.Windows.Forms.PictureBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			txtText = new System.Windows.Forms.TextBox();
			btnValueBingding = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
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
			cboBarcodeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboBarcodeStyle.FormattingEnabled = true;
			resources.ApplyResources(cboBarcodeStyle, "cboBarcodeStyle");
			cboBarcodeStyle.Name = "cboBarcodeStyle";
			cboBarcodeStyle.SelectedIndexChanged += new System.EventHandler(cboBarcodeStyle_SelectedIndexChanged);
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			cboTextAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboTextAlignment.FormattingEnabled = true;
			cboTextAlignment.Items.AddRange(new object[3]
			{
				resources.GetString("cboTextAlignment.Items"),
				resources.GetString("cboTextAlignment.Items1"),
				resources.GetString("cboTextAlignment.Items2")
			});
			resources.ApplyResources(cboTextAlignment, "cboTextAlignment");
			cboTextAlignment.Name = "cboTextAlignment";
			cboTextAlignment.SelectedIndexChanged += new System.EventHandler(cboTextAlignment_SelectedIndexChanged);
			resources.ApplyResources(chkShowText, "chkShowText");
			chkShowText.Name = "chkShowText";
			chkShowText.UseVisualStyleBackColor = true;
			chkShowText.CheckedChanged += new System.EventHandler(chkShowText_CheckedChanged);
			groupBox1.Controls.Add(picPreview);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			picPreview.BackColor = System.Drawing.Color.White;
			picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(picPreview, "picPreview");
			picPreview.Name = "picPreview";
			picPreview.TabStop = false;
			picPreview.Paint += new System.Windows.Forms.PaintEventHandler(picPreview_Paint);
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(txtText, "txtText");
			txtText.Name = "txtText";
			txtText.TextChanged += new System.EventHandler(txtText_TextChanged);
			resources.ApplyResources(btnValueBingding, "btnValueBingding");
			btnValueBingding.Name = "btnValueBingding";
			btnValueBingding.UseVisualStyleBackColor = true;
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnValueBingding);
			base.Controls.Add(label7);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(groupBox1);
			base.Controls.Add(chkShowText);
			base.Controls.Add(cboTextAlignment);
			base.Controls.Add(cboBarcodeStyle);
			base.Controls.Add(label4);
			base.Controls.Add(txtText);
			base.Controls.Add(txtName);
			base.Controls.Add(label6);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgNewBarcodeElementEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgNewBarcodeElementEditor_Load);
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgNewBarcodeElementEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			btnValueBingding.Click += btnValueBingding_Click;
		}

		private void dlgNewBarcodeElementEditor_Load(object sender, EventArgs e)
		{
			foreach (object value in Enum.GetValues(typeof(DCBarcodeStyle)))
			{
				cboBarcodeStyle.Items.Add(value);
			}
			if (SourceEventArgs != null)
			{
				if (SourceEventArgs.WriterControl != null)
				{
					Text = SourceEventArgs.WriterControl.DialogTitlePrefix + Text;
				}
				XTextNewBarcodeElement xTextNewBarcodeElement = (XTextNewBarcodeElement)SourceEventArgs.Element;
				txtID.Text = xTextNewBarcodeElement.ID;
				txtName.Text = xTextNewBarcodeElement.Name;
				cboBarcodeStyle.Text = xTextNewBarcodeElement.BarcodeStyle2.ToString();
				cboTextAlignment.SelectedIndex = (int)xTextNewBarcodeElement.TextAlignment;
				chkShowText.Checked = xTextNewBarcodeElement.ShowText;
				txtText.Text = xTextNewBarcodeElement.Text;
				btnValueBingding.Tag = xTextNewBarcodeElement.ValueBinding;
				if (xTextNewBarcodeElement.ValueBinding != null)
				{
					btnValueBingding.Text = xTextNewBarcodeElement.ValueBinding.ToString();
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 17;
			if (SourceEventArgs != null && SourceEventArgs.Element is XTextNewBarcodeElement)
			{
				bool flag = false;
				XTextNewBarcodeElement xTextNewBarcodeElement = (XTextNewBarcodeElement)SourceEventArgs.Element;
				bool flag2 = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
				XTextDocument document = SourceEventArgs.Document;
				string text = txtID.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (text != xTextNewBarcodeElement.ID)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("ID", xTextNewBarcodeElement.ID, text, xTextNewBarcodeElement);
					}
					xTextNewBarcodeElement.ID = text;
					flag = true;
				}
				text = txtName.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (text != xTextNewBarcodeElement.Name)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Name", xTextNewBarcodeElement.Name, text, xTextNewBarcodeElement);
					}
					xTextNewBarcodeElement.Name = text;
					flag = true;
				}
				DCBarcodeStyle dCBarcodeStyle = (DCBarcodeStyle)Enum.Parse(typeof(DCBarcodeStyle), cboBarcodeStyle.Text);
				if (dCBarcodeStyle != xTextNewBarcodeElement.BarcodeStyle2)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("BarcodeStyle2", xTextNewBarcodeElement.BarcodeStyle2, dCBarcodeStyle, xTextNewBarcodeElement);
					}
					xTextNewBarcodeElement.BarcodeStyle2 = dCBarcodeStyle;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					flag = true;
				}
				StringAlignment selectedIndex = (StringAlignment)cboTextAlignment.SelectedIndex;
				if (selectedIndex != xTextNewBarcodeElement.TextAlignment)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("TextAlignment", xTextNewBarcodeElement.TextAlignment, selectedIndex, xTextNewBarcodeElement);
					}
					xTextNewBarcodeElement.TextAlignment = selectedIndex;
					flag = true;
				}
				if (chkShowText.Checked != xTextNewBarcodeElement.ShowText)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("ShowText", xTextNewBarcodeElement.ShowText, chkShowText.Checked, xTextNewBarcodeElement);
					}
					xTextNewBarcodeElement.ShowText = chkShowText.Checked;
					flag = true;
				}
				if (xTextNewBarcodeElement.ValueBinding != btnValueBingding.Tag)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("ValueBinding", xTextNewBarcodeElement.ValueBinding, btnValueBingding.Tag, xTextNewBarcodeElement);
					}
					xTextNewBarcodeElement.ValueBinding = (XDataBinding)btnValueBingding.Tag;
					if (xTextNewBarcodeElement.ValueBinding != null)
					{
						int processState = (int)xTextNewBarcodeElement.ValueBinding.ProcessState;
						xTextNewBarcodeElement.UpdateDataBindingExt(new UpdateDataBindingArgs(null, fastMode: false));
						xTextNewBarcodeElement.ValueBinding.ProcessState = (DCProcessStates)processState;
					}
				}
				if (txtText.Text != xTextNewBarcodeElement.Text)
				{
					xTextNewBarcodeElement.Text = txtText.Text;
					flag = true;
				}
				if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
				{
					if (flag)
					{
						document.Modified = true;
						base.DialogResult = DialogResult.OK;
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.Document = xTextNewBarcodeElement.OwnerDocument;
						contentChangedEventArgs.Element = xTextNewBarcodeElement;
						contentChangedEventArgs.LoadingDocument = false;
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

		private void cboBarcodeStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			picPreview.Refresh();
		}

		private void cboTextAlignment_SelectedIndexChanged(object sender, EventArgs e)
		{
			picPreview.Refresh();
		}

		private void chkShowText_CheckedChanged(object sender, EventArgs e)
		{
			picPreview.Refresh();
		}

		private void method_0(object sender, EventArgs e)
		{
			picPreview.Refresh();
		}

		private void txtText_TextChanged(object sender, EventArgs e)
		{
			picPreview.Refresh();
		}

		private void picPreview_Paint(object sender, PaintEventArgs e)
		{
			GClass94 gClass = new GClass94();
			gClass.method_16((Font)Font.Clone());
			gClass.method_14(chkShowText.Checked);
			gClass.method_7((BarcodeStyle)Enum.Parse(typeof(BarcodeStyle), cboBarcodeStyle.Text));
			if (string.IsNullOrEmpty(txtText.Text))
			{
				gClass.method_3(GClass94.smethod_1(gClass.method_8()));
			}
			else
			{
				gClass.method_3(txtText.Text);
			}
			gClass.method_18((StringAlignment)cboTextAlignment.SelectedIndex);
			gClass.method_22(bool_3: true);
			gClass.method_20();
			Rectangle r = new Rectangle((int)((float)picPreview.ClientSize.Width - gClass.method_19()) / 2, 10, (int)gClass.method_19(), picPreview.ClientSize.Height - 20);
			gClass.method_24(e.Graphics, r);
		}

		private void btnValueBingding_Click(object sender, EventArgs e)
		{
			dlgXDataBinding.smethod_0(btnValueBingding, SourceEventArgs.Document, SourceEventArgs.Element);
		}
	}
}
