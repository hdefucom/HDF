using DCSoft.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       字符间距对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgLetterSpacing : Form
	{
		private IContainer icontainer_0 = null;

		private NumericUpDown txtNumber;

		private Label label1;

		private Button btnOK;

		private Button btnCancel;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		private float float_0 = 0f;

		/// <summary>
		///       度量单位
		///       </summary>
		public GraphicsUnit InputUnit
		{
			get
			{
				return graphicsUnit_0;
			}
			set
			{
				graphicsUnit_0 = value;
			}
		}

		/// <summary>
		///       间距值
		///       </summary>
		public float InputValue
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgLetterSpacing));
			txtNumber = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)txtNumber).BeginInit();
			SuspendLayout();
			txtNumber.DecimalPlaces = 2;
			txtNumber.Increment = new decimal(new int[4]
			{
				1,
				0,
				0,
				65536
			});
			resources.ApplyResources(txtNumber, "txtNumber");
			txtNumber.Name = "txtNumber";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(label1);
			base.Controls.Add(txtNumber);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgLetterSpacing";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgLetterSpacing_Load);
			((System.ComponentModel.ISupportInitialize)txtNumber).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgLetterSpacing()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgLetterSpacing_Load(object sender, EventArgs e)
		{
			txtNumber.Value = Convert.ToDecimal(GraphicsUnitConvert.ConvertToCM(InputValue, InputUnit));
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			InputValue = GraphicsUnitConvert.ConvertFromCM((float)txtNumber.Value, InputUnit);
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
