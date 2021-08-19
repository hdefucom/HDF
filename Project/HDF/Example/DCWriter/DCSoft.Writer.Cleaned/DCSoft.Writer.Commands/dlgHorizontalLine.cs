using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	[ComVisible(false)]
	public class dlgHorizontalLine : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtID;

		private Label label2;

		private Button btnColor;

		private Label label3;

		private NumericUpDown nudLineSize;

		private Button btnOK;

		private Button btnCancel;

		private Label label4;

		private NumericUpDown txtLengthCM;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgHorizontalLine));
			label1 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			btnColor = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			nudLineSize = new System.Windows.Forms.NumericUpDown();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			txtLengthCM = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)nudLineSize).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtLengthCM).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(btnColor, "btnColor");
			btnColor.Name = "btnColor";
			btnColor.UseVisualStyleBackColor = true;
			btnColor.Click += new System.EventHandler(btnColor_Click);
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(nudLineSize, "nudLineSize");
			nudLineSize.Name = "nudLineSize";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			txtLengthCM.DecimalPlaces = 2;
			txtLengthCM.Increment = new decimal(new int[4]
			{
				1,
				0,
				0,
				65536
			});
			resources.ApplyResources(txtLengthCM, "txtLengthCM");
			txtLengthCM.Name = "txtLengthCM";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtLengthCM);
			base.Controls.Add(label4);
			base.Controls.Add(nudLineSize);
			base.Controls.Add(label3);
			base.Controls.Add(btnColor);
			base.Controls.Add(label2);
			base.Controls.Add(txtID);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgHorizontalLine";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgHorizontalLine_Load);
			((System.ComponentModel.ISupportInitialize)nudLineSize).EndInit();
			((System.ComponentModel.ISupportInitialize)txtLengthCM).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgHorizontalLine()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgHorizontalLine_Load(object sender, EventArgs e)
		{
			if (SourceEventArgs != null && SourceEventArgs.Element is XTextHorizontalLineElement)
			{
				XTextHorizontalLineElement xTextHorizontalLineElement = (XTextHorizontalLineElement)SourceEventArgs.Element;
				xTextHorizontalLineElement.OwnerDocument = SourceEventArgs.Document;
				txtID.Text = xTextHorizontalLineElement.ID;
				btnColor.BackColor = xTextHorizontalLineElement.RuntimeStyle.Color;
				nudLineSize.Value = Convert.ToDecimal(xTextHorizontalLineElement.LineSize);
				txtLengthCM.Value = (decimal)xTextHorizontalLineElement.LineLengthInCM;
			}
		}

		private void btnColor_Click(object sender, EventArgs e)
		{
			if (SourceEventArgs != null && SourceEventArgs.Document != null)
			{
				Color colorValue = btnColor.BackColor;
				if (SourceEventArgs.Document.AppHost.UITools.PickColor(this, ref colorValue))
				{
					btnColor.BackColor = colorValue;
				}
			}
			else
			{
				using (ColorDialog colorDialog = new ColorDialog())
				{
					colorDialog.Color = btnColor.BackColor;
					if (colorDialog.ShowDialog(this) == DialogResult.OK)
					{
						btnColor.BackColor = colorDialog.Color;
					}
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 15;
			if (SourceEventArgs == null)
			{
				return;
			}
			bool flag = false;
			XTextDocument document = SourceEventArgs.Document;
			bool flag2 = SourceEventArgs.LogUndo && document.CanLogUndo;
			XTextHorizontalLineElement xTextHorizontalLineElement = (XTextHorizontalLineElement)SourceEventArgs.Element;
			xTextHorizontalLineElement.OwnerDocument = document;
			string text = txtID.Text.Trim();
			DocumentContentStyle documentContentStyle = xTextHorizontalLineElement.RuntimeStyle.CloneParent();
			if (WriterUtils.smethod_43(text, xTextHorizontalLineElement.ID))
			{
				if (flag2)
				{
					document.UndoList.AddProperty("ID", xTextHorizontalLineElement.ID, text, xTextHorizontalLineElement);
				}
				xTextHorizontalLineElement.ID = text;
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Content);
			}
			bool flag3 = false;
			if (documentContentStyle.Color != btnColor.BackColor)
			{
				documentContentStyle.Color = btnColor.BackColor;
				flag3 = true;
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			float num2 = Convert.ToSingle(nudLineSize.Value);
			if (num2 != xTextHorizontalLineElement.LineSize)
			{
				if (flag2)
				{
					document.UndoList.AddProperty("LineSize", xTextHorizontalLineElement.LineSize, num2, xTextHorizontalLineElement);
				}
				xTextHorizontalLineElement.LineSize = num2;
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			float num3 = (float)txtLengthCM.Value;
			if (num3 != xTextHorizontalLineElement.LineLengthInCM)
			{
				if (flag2)
				{
					document.UndoList.AddProperty("LineLengthInCM", xTextHorizontalLineElement.LineLengthInCM, num3, xTextHorizontalLineElement);
				}
				xTextHorizontalLineElement.LineLengthInCM = num3;
				flag = true;
				SourceEventArgs.SetContentEffect(ContentEffects.Display);
			}
			if (flag3)
			{
				int styleIndex = document.ContentStyles.GetStyleIndex(documentContentStyle);
				if (styleIndex != xTextHorizontalLineElement.StyleIndex)
				{
					document.UndoList.AddProperty("StyleIndex", xTextHorizontalLineElement.StyleIndex, styleIndex, xTextHorizontalLineElement);
				}
				xTextHorizontalLineElement.StyleIndex = styleIndex;
				flag = true;
			}
			if (SourceEventArgs.Method == ElementPropertiesEditMethod.Edit)
			{
				if (flag)
				{
					base.DialogResult = DialogResult.OK;
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
	}
}
