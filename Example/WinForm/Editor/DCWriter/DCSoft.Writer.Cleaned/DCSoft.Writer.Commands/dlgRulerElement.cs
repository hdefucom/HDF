using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	
	public class dlgRulerElement : Form
	{
		private ElementPropertiesEditEventArgs _SourceEventArgs = null;

		private ScalePropertyList _Scales = null;

		/// <summary>
		///       Required designer variable.
		///       </summary>
		private IContainer components = null;

		private ColorDialog colorDialog1;

		private Button btnOK;

		private Button btnCancel;

		private TextBox txtMaxScale;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private TextBox txtMinScale;

		private TextBox txtHeight;

		private TextBox txtWidth;

		private TextBox txtSettings;

		private TextBox txtValue;

		private Label label7;

		private Label label8;

		private ComboBox cboPrecision;

		private Label label9;

		private TextBox txtID;

		private Label label10;

		private TextBox txtName;

		private Label label1;

		private GClass304 btnRulerColor;

		private Button btnBrowseSettings;

		/// <summary>
		///       参数
		///       </summary>
		public ElementPropertiesEditEventArgs SourceEventArgs
		{
			get
			{
				return _SourceEventArgs;
			}
			set
			{
				_SourceEventArgs = value;
			}
		}

		/// <summary>
		///       自定义的刻度信息列表
		///       </summary>
		[Browsable(true)]
		[XmlArrayItem("Scale", typeof(ScaleProperty))]
		[DefaultValue(null)]
		public ScalePropertyList Scales
		{
			get
			{
				if (_Scales == null)
				{
					_Scales = new ScalePropertyList();
				}
				return _Scales;
			}
			set
			{
				_Scales = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgRulerElement()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 0;
			if (_SourceEventArgs == null || !(_SourceEventArgs.Element is XTextRulerElement))
			{
				return;
			}
			XTextRulerElement xTextRulerElement = (XTextRulerElement)_SourceEventArgs.Element;
			XTextDocument document = SourceEventArgs.Document;
			bool flag = SourceEventArgs.LogUndo && SourceEventArgs.Document.CanLogUndo;
			bool flag2 = false;
			string text = txtID.Text.Trim();
			if (!WriterUtils.smethod_43(text, xTextRulerElement.ID))
			{
				if (flag)
				{
					document.UndoList.AddProperty("ID", xTextRulerElement.ID, text, xTextRulerElement);
				}
				xTextRulerElement.ID = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Layout);
			}
			text = txtName.Text;
			if (!WriterUtils.smethod_43(text, xTextRulerElement.Name))
			{
				if (flag)
				{
					document.UndoList.AddProperty("Name", xTextRulerElement.Name, text, xTextRulerElement);
				}
				xTextRulerElement.Name = text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtHeight.Text;
			float result;
			if (!WriterUtils.smethod_43(text, xTextRulerElement.Height.ToString()))
			{
				if (float.TryParse(text, out result))
				{
					xTextRulerElement.Height = result;
				}
				if (flag)
				{
					document.UndoList.AddProperty("Height", xTextRulerElement.Height, result, xTextRulerElement);
				}
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtWidth.Text;
			if (!WriterUtils.smethod_43(text, xTextRulerElement.Height.ToString()))
			{
				if (float.TryParse(text, out result))
				{
					xTextRulerElement.Width = result;
				}
				if (flag)
				{
					document.UndoList.AddProperty("Width", xTextRulerElement.Width, result, xTextRulerElement);
				}
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtValue.Text;
			if (!WriterUtils.smethod_43(text, xTextRulerElement.RulerValue.ToString()))
			{
				if (float.TryParse(text, out result))
				{
					xTextRulerElement.RulerValue = result;
				}
				if (flag)
				{
					document.UndoList.AddProperty("RulerValue", xTextRulerElement.RulerValue, result, xTextRulerElement);
				}
				xTextRulerElement.RulerValue = float.Parse(text);
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtMaxScale.Text;
			int result2;
			if (!WriterUtils.smethod_43(text, xTextRulerElement.MaxScale.ToString()))
			{
				if (int.TryParse(text, out result2))
				{
					xTextRulerElement.MaxScale = result2;
				}
				if (flag)
				{
					document.UndoList.AddProperty("MaxScale", xTextRulerElement.MaxScale, result2, xTextRulerElement);
				}
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = txtMinScale.Text;
			if (!WriterUtils.smethod_43(text, xTextRulerElement.MinScale.ToString()))
			{
				if (int.TryParse(text, out result2))
				{
					xTextRulerElement.MinScale = result2;
				}
				if (flag)
				{
					document.UndoList.AddProperty("MinScale", xTextRulerElement.MinScale, result2, xTextRulerElement);
				}
				xTextRulerElement.MinScale = int.Parse(text);
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = btnRulerColor.method_0().ToString();
			if (!WriterUtils.smethod_43(text, xTextRulerElement.LineColor.ToString()))
			{
				if (flag)
				{
					document.UndoList.AddProperty("LineColor", xTextRulerElement.LineColor, btnRulerColor.method_0(), xTextRulerElement);
				}
				xTextRulerElement.LineColor = btnRulerColor.method_0();
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			text = cboPrecision.Text;
			if (!WriterUtils.smethod_43(text, xTextRulerElement.Precision))
			{
				if (flag)
				{
					document.UndoList.AddProperty("Precision", xTextRulerElement.Precision, cboPrecision.Text, xTextRulerElement);
				}
				xTextRulerElement.Precision = cboPrecision.Text;
				flag2 = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			if (flag)
			{
				document.UndoList.AddProperty("Scales", xTextRulerElement.Scales, _Scales, xTextRulerElement);
			}
			xTextRulerElement.Scales = _Scales;
			flag2 = true;
			SourceEventArgs.SetContentEffect(ContentEffects.Content);
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag2)
				{
					base.DialogResult = DialogResult.OK;
					ContentChangedEventArgs contentChangedEventArgs = new ContentChangedEventArgs();
					contentChangedEventArgs.Document = xTextRulerElement.OwnerDocument;
					contentChangedEventArgs.Element = xTextRulerElement;
					contentChangedEventArgs.LoadingDocument = false;
					xTextRulerElement.EditorRefreshView();
					xTextRulerElement.Parent.method_23(contentChangedEventArgs);
				}
			}
			else
			{
				base.DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dlgRulerElement_Load(object sender, EventArgs e)
		{
			int num = 3;
			if (_SourceEventArgs != null && _SourceEventArgs.Document != null && _SourceEventArgs.Document.EditorControl != null)
			{
				_ = _SourceEventArgs.Document.EditorControl;
			}
			if (_SourceEventArgs != null && _SourceEventArgs.Element is XTextRulerElement)
			{
				XTextRulerElement xTextRulerElement = (XTextRulerElement)_SourceEventArgs.Element;
				txtID.Text = xTextRulerElement.ID;
				txtName.Text = xTextRulerElement.Name;
				txtMaxScale.Text = xTextRulerElement.MaxScale.ToString();
				txtMinScale.Text = xTextRulerElement.MinScale.ToString();
				txtHeight.Text = xTextRulerElement.Height.ToString();
				txtWidth.Text = xTextRulerElement.Width.ToString();
				txtValue.Text = xTextRulerElement.RulerValue.ToString();
				btnRulerColor.method_1(xTextRulerElement.LineColor);
				cboPrecision.Text = xTextRulerElement.Precision;
				_Scales = xTextRulerElement.Scales;
				txtSettings.Text = xTextRulerElement.Scales.Count + " Items";
			}
		}

		private void btnBrowseSettings_Click(object sender, EventArgs e)
		{
			int num = 5;
			using (dlgRulerSettings dlgRulerSettings = new dlgRulerSettings())
			{
				dlgRulerSettings.Scales = _Scales;
				if (dlgRulerSettings.ShowDialog(this) == DialogResult.OK)
				{
					txtSettings.Text = dlgRulerSettings.Scales.Count + " Items";
					_Scales = dlgRulerSettings.Scales;
				}
			}
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			colorDialog1 = new System.Windows.Forms.ColorDialog();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			txtMaxScale = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			txtMinScale = new System.Windows.Forms.TextBox();
			txtHeight = new System.Windows.Forms.TextBox();
			txtWidth = new System.Windows.Forms.TextBox();
			txtSettings = new System.Windows.Forms.TextBox();
			txtValue = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			cboPrecision = new System.Windows.Forms.ComboBox();
			label9 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label10 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			btnRulerColor = new DCSoftDotfuscate.GClass304();
			btnBrowseSettings = new System.Windows.Forms.Button();
			SuspendLayout();
			btnOK.Location = new System.Drawing.Point(46, 219);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 19;
			btnOK.Text = "确定";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.Location = new System.Drawing.Point(210, 219);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 20;
			btnCancel.Text = "取消";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			txtMaxScale.Location = new System.Drawing.Point(92, 45);
			txtMaxScale.Name = "txtMaxScale";
			txtMaxScale.Size = new System.Drawing.Size(83, 21);
			txtMaxScale.TabIndex = 21;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(13, 84);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(77, 12);
			label2.TabIndex = 23;
			label2.Text = "刻度最小值：";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(188, 50);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(41, 12);
			label3.TabIndex = 24;
			label3.Text = "高度：";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(188, 82);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(41, 12);
			label4.TabIndex = 25;
			label4.Text = "宽度：";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(13, 151);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(65, 12);
			label5.TabIndex = 26;
			label5.Text = "刻度集合：";
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(13, 183);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(77, 12);
			label6.TabIndex = 27;
			label6.Text = "刻度线颜色：";
			txtMinScale.Location = new System.Drawing.Point(92, 78);
			txtMinScale.Name = "txtMinScale";
			txtMinScale.Size = new System.Drawing.Size(83, 21);
			txtMinScale.TabIndex = 28;
			txtHeight.Location = new System.Drawing.Point(235, 46);
			txtHeight.Name = "txtHeight";
			txtHeight.Size = new System.Drawing.Size(83, 21);
			txtHeight.TabIndex = 29;
			txtWidth.Location = new System.Drawing.Point(235, 80);
			txtWidth.Name = "txtWidth";
			txtWidth.Size = new System.Drawing.Size(83, 21);
			txtWidth.TabIndex = 30;
			txtSettings.Location = new System.Drawing.Point(92, 147);
			txtSettings.Name = "txtSettings";
			txtSettings.ReadOnly = true;
			txtSettings.Size = new System.Drawing.Size(156, 21);
			txtSettings.TabIndex = 31;
			txtValue.Location = new System.Drawing.Point(92, 113);
			txtValue.Name = "txtValue";
			txtValue.Size = new System.Drawing.Size(83, 21);
			txtValue.TabIndex = 33;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(13, 118);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(53, 12);
			label7.TabIndex = 34;
			label7.Text = "刻度值：";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(188, 117);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(41, 12);
			label8.TabIndex = 35;
			label8.Text = "精度：";
			cboPrecision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboPrecision.FormattingEnabled = true;
			cboPrecision.Items.AddRange(new object[4]
			{
				"#0",
				"#0.0",
				"#0.00",
				"#0.000"
			});
			cboPrecision.Location = new System.Drawing.Point(235, 114);
			cboPrecision.Name = "cboPrecision";
			cboPrecision.Size = new System.Drawing.Size(83, 20);
			cboPrecision.TabIndex = 36;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(13, 17);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(65, 12);
			label9.TabIndex = 37;
			label9.Text = "编号(ID)：";
			txtID.Location = new System.Drawing.Point(92, 12);
			txtID.Name = "txtID";
			txtID.Size = new System.Drawing.Size(83, 21);
			txtID.TabIndex = 38;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(188, 16);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(41, 12);
			label10.TabIndex = 39;
			label10.Text = "名称：";
			txtName.Location = new System.Drawing.Point(235, 13);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(83, 21);
			txtName.TabIndex = 40;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 50);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(77, 12);
			label1.TabIndex = 41;
			label1.Text = "刻度最大值：";
			btnRulerColor.Location = new System.Drawing.Point(92, 176);
			btnRulerColor.Name = "btnRulerColor";
			btnRulerColor.method_5(true);
			btnRulerColor.Size = new System.Drawing.Size(83, 23);
			btnRulerColor.TabIndex = 1;
			btnRulerColor.UseVisualStyleBackColor = true;
			btnBrowseSettings.Location = new System.Drawing.Point(260, 146);
			btnBrowseSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			btnBrowseSettings.Name = "btnBrowseSettings";
			btnBrowseSettings.Size = new System.Drawing.Size(58, 23);
			btnBrowseSettings.TabIndex = 42;
			btnBrowseSettings.Text = "浏览";
			btnBrowseSettings.UseVisualStyleBackColor = true;
			btnBrowseSettings.Click += new System.EventHandler(btnBrowseSettings_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(332, 265);
			base.Controls.Add(btnBrowseSettings);
			base.Controls.Add(label1);
			base.Controls.Add(txtName);
			base.Controls.Add(btnRulerColor);
			base.Controls.Add(label10);
			base.Controls.Add(txtID);
			base.Controls.Add(label9);
			base.Controls.Add(cboPrecision);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(txtValue);
			base.Controls.Add(txtSettings);
			base.Controls.Add(txtWidth);
			base.Controls.Add(txtHeight);
			base.Controls.Add(txtMinScale);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(txtMaxScale);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgRulerElement";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "标尺";
			base.Load += new System.EventHandler(dlgRulerElement_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
