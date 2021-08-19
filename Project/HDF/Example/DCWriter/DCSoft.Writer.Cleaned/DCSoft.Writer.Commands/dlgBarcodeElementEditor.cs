using DCSoft.Barcode;
using DCSoft.Drawing;
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
	public class dlgBarcodeElementEditor : Form
	{
		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

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

		private Label label5;

		private NumericUpDown txtMinWidth;

		private Label label6;

		private TextBox txtInitalizeText;

		private Button btnValueBingding;

		private Label label7;

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
		public dlgBarcodeElementEditor()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
			btnValueBingding.Click += btnValueBingding_Click;
		}

		private void dlgBarcodeElementEditor_Load(object sender, EventArgs e)
		{
			foreach (object value in Enum.GetValues(typeof(BarcodeStyle)))
			{
				cboBarcodeStyle.Items.Add(value);
			}
			if (SourceEventArgs != null)
			{
				if (SourceEventArgs.WriterControl != null)
				{
					Text = SourceEventArgs.WriterControl.DialogTitlePrefix + Text;
				}
				XTextBarcodeFieldElement xTextBarcodeFieldElement = (XTextBarcodeFieldElement)SourceEventArgs.Element;
				txtID.Text = xTextBarcodeFieldElement.ID;
				txtName.Text = xTextBarcodeFieldElement.Name;
				cboBarcodeStyle.Text = xTextBarcodeFieldElement.BarcodeStyle.ToString();
				cboTextAlignment.SelectedIndex = (int)xTextBarcodeFieldElement.TextAlignment;
				chkShowText.Checked = xTextBarcodeFieldElement.ShowText;
				txtMinWidth.Value = (decimal)xTextBarcodeFieldElement.MinBarWidth;
				if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
				{
					txtInitalizeText.Text = xTextBarcodeFieldElement.Text;
				}
				else
				{
					txtInitalizeText.Text = xTextBarcodeFieldElement.InitalizeText;
				}
				btnValueBingding.Tag = xTextBarcodeFieldElement.ValueBinding;
				if (xTextBarcodeFieldElement.ValueBinding != null)
				{
					btnValueBingding.Text = xTextBarcodeFieldElement.ValueBinding.ToString();
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (SourceEventArgs != null && SourceEventArgs.Element is XTextBarcodeFieldElement)
			{
				bool flag = false;
				XTextBarcodeFieldElement xTextBarcodeFieldElement = (XTextBarcodeFieldElement)SourceEventArgs.Element;
				bool flag2 = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
				XTextDocument document = SourceEventArgs.Document;
				string text = txtID.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (text != xTextBarcodeFieldElement.ID)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("ID", xTextBarcodeFieldElement.ID, text, xTextBarcodeFieldElement);
					}
					xTextBarcodeFieldElement.ID = text;
					flag = true;
				}
				text = txtName.Text.Trim();
				if (text.Length == 0)
				{
					text = null;
				}
				if (text != xTextBarcodeFieldElement.Name)
				{
					if (flag2)
					{
						document.UndoList.AddProperty("Name", xTextBarcodeFieldElement.Name, text, xTextBarcodeFieldElement);
					}
					xTextBarcodeFieldElement.Name = text;
					flag = true;
				}
				BarcodeStyle barcodeStyle = (BarcodeStyle)Enum.Parse(typeof(BarcodeStyle), cboBarcodeStyle.Text);
				if (barcodeStyle != xTextBarcodeFieldElement.BarcodeStyle)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("BarcodeStyle", xTextBarcodeFieldElement.BarcodeStyle, barcodeStyle, xTextBarcodeFieldElement);
					}
					xTextBarcodeFieldElement.BarcodeStyle = barcodeStyle;
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					flag = true;
				}
				StringAlignment selectedIndex = (StringAlignment)cboTextAlignment.SelectedIndex;
				if (selectedIndex != xTextBarcodeFieldElement.TextAlignment)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("TextAlignment", xTextBarcodeFieldElement.TextAlignment, selectedIndex, xTextBarcodeFieldElement);
					}
					xTextBarcodeFieldElement.TextAlignment = selectedIndex;
					flag = true;
				}
				if (chkShowText.Checked != xTextBarcodeFieldElement.ShowText)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("ShowText", xTextBarcodeFieldElement.ShowText, chkShowText.Checked, xTextBarcodeFieldElement);
					}
					xTextBarcodeFieldElement.ShowText = chkShowText.Checked;
					flag = true;
				}
				float num2 = (float)txtMinWidth.Value;
				if (num2 != xTextBarcodeFieldElement.MinBarWidth)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("MinBarWidth", xTextBarcodeFieldElement.MinBarWidth, num2, xTextBarcodeFieldElement);
					}
					SourceEventArgs.SetContentEffect(ContentEffects.Layout);
					xTextBarcodeFieldElement.MinBarWidth = num2;
					flag = true;
				}
				if (xTextBarcodeFieldElement.ValueBinding != btnValueBingding.Tag)
				{
					if (flag2 && document.CanLogUndo)
					{
						document.UndoList.AddProperty("ValueBinding", xTextBarcodeFieldElement.ValueBinding, btnValueBingding.Tag, xTextBarcodeFieldElement);
					}
					xTextBarcodeFieldElement.ValueBinding = (XDataBinding)btnValueBingding.Tag;
					if (xTextBarcodeFieldElement.ValueBinding != null)
					{
						int processState = (int)xTextBarcodeFieldElement.ValueBinding.ProcessState;
						xTextBarcodeFieldElement.UpdateDataBindingExt(new UpdateDataBindingArgs(null, fastMode: false));
						xTextBarcodeFieldElement.ValueBinding.ProcessState = (DCProcessStates)processState;
					}
				}
				if (txtInitalizeText.Text != xTextBarcodeFieldElement.Text)
				{
					xTextBarcodeFieldElement.OwnerDocument = SourceEventArgs.Document;
					if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
					{
						SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
						setContainerTextArgs.NewText = txtInitalizeText.Text;
						setContainerTextArgs.AccessFlags = DomAccessFlags.Normal;
						setContainerTextArgs.UpdateContent = true;
						setContainerTextArgs.LogUndo = false;
						setContainerTextArgs.DisablePermission = false;
						xTextBarcodeFieldElement.SetEditorText(setContainerTextArgs);
						flag = true;
					}
					else if (!string.IsNullOrEmpty(txtInitalizeText.Text))
					{
						xTextBarcodeFieldElement.SetInnerTextFast(txtInitalizeText.Text);
						flag = true;
					}
				}
				if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
				{
					if (flag)
					{
						xTextBarcodeFieldElement.CheckShapeState(updateSize: true);
						document.Modified = true;
						base.DialogResult = DialogResult.OK;
						ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
						contentChangedEventArgs.Document = xTextBarcodeFieldElement.OwnerDocument;
						contentChangedEventArgs.Element = xTextBarcodeFieldElement;
						contentChangedEventArgs.LoadingDocument = false;
						xTextBarcodeFieldElement.method_23(contentChangedEventArgs);
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

		private void txtMinWidth_ValueChanged(object sender, EventArgs e)
		{
			picPreview.Refresh();
		}

		private void txtInitalizeText_TextChanged(object sender, EventArgs e)
		{
			picPreview.Refresh();
		}

		private void picPreview_Paint(object sender, PaintEventArgs e)
		{
			GClass94 gClass = new GClass94();
			gClass.method_16((Font)Font.Clone());
			gClass.method_14(chkShowText.Checked);
			gClass.method_7((BarcodeStyle)Enum.Parse(typeof(BarcodeStyle), cboBarcodeStyle.Text));
			if (string.IsNullOrEmpty(txtInitalizeText.Text))
			{
				gClass.method_3(GClass94.smethod_1(gClass.method_8()));
			}
			else
			{
				gClass.method_3(txtInitalizeText.Text);
			}
			gClass.method_18((StringAlignment)cboTextAlignment.SelectedIndex);
			gClass.method_12(GraphicsUnitConvert.Convert((float)txtMinWidth.Value, GraphicsUnit.Document, GraphicsUnit.Pixel));
			gClass.method_20();
			Rectangle r = new Rectangle((int)((float)picPreview.ClientSize.Width - gClass.method_19()) / 2, 10, (int)gClass.method_19(), picPreview.ClientSize.Height - 20);
			gClass.method_24(e.Graphics, r);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgBarcodeElementEditor));
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
			label5 = new System.Windows.Forms.Label();
			txtMinWidth = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			txtInitalizeText = new System.Windows.Forms.TextBox();
			btnValueBingding = new System.Windows.Forms.Button();
			label7 = new System.Windows.Forms.Label();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtMinWidth).BeginInit();
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
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(txtMinWidth, "txtMinWidth");
			txtMinWidth.Name = "txtMinWidth";
			txtMinWidth.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtMinWidth.ValueChanged += new System.EventHandler(txtMinWidth_ValueChanged);
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(txtInitalizeText, "txtInitalizeText");
			txtInitalizeText.Name = "txtInitalizeText";
			txtInitalizeText.TextChanged += new System.EventHandler(txtInitalizeText_TextChanged);
			resources.ApplyResources(btnValueBingding, "btnValueBingding");
			btnValueBingding.Name = "btnValueBingding";
			btnValueBingding.UseVisualStyleBackColor = true;
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnValueBingding);
			base.Controls.Add(label7);
			base.Controls.Add(txtMinWidth);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(groupBox1);
			base.Controls.Add(chkShowText);
			base.Controls.Add(cboTextAlignment);
			base.Controls.Add(cboBarcodeStyle);
			base.Controls.Add(label4);
			base.Controls.Add(txtInitalizeText);
			base.Controls.Add(txtName);
			base.Controls.Add(label5);
			base.Controls.Add(label6);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBarcodeElementEditor";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgBarcodeElementEditor_Load);
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
			((System.ComponentModel.ISupportInitialize)txtMinWidth).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
