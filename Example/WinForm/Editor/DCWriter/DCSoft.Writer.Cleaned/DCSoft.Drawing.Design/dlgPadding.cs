using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Drawing.Design
{
	/// <summary>
	///       内边距对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgPadding : Form
	{
		private RectangleF rectangleF_0 = RectangleF.Empty;

		private XPaddingF xpaddingF_0 = new XPaddingF();

		private IContainer icontainer_0 = null;

		private Label label1;

		private NumericUpDown nudLeftPadding;

		private GroupBox groupBox1;

		private NumericUpDown nudBottomPadding;

		private Label label4;

		private NumericUpDown nudRightPadding;

		private Label label3;

		private NumericUpDown nudTopPadding;

		private Label label2;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       元素边界
		///       </summary>
		public RectangleF ElementBounds
		{
			get
			{
				return rectangleF_0;
			}
			set
			{
				rectangleF_0 = value;
			}
		}

		/// <summary>
		///       内边距值
		///       </summary>
		public XPaddingF XPaddingValue
		{
			get
			{
				return xpaddingF_0;
			}
			set
			{
				xpaddingF_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgPadding()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgPadding_Load(object sender, EventArgs e)
		{
			if (xpaddingF_0 == null)
			{
				xpaddingF_0 = new XPaddingF();
			}
			nudBottomPadding.Value = Convert.ToDecimal(xpaddingF_0.Bottom);
			nudLeftPadding.Value = Convert.ToDecimal(xpaddingF_0.Left);
			nudRightPadding.Value = Convert.ToDecimal(xpaddingF_0.Right);
			nudTopPadding.Value = Convert.ToDecimal(xpaddingF_0.Top);
			if (rectangleF_0.Width > 0f)
			{
				nudLeftPadding.Maximum = Convert.ToDecimal(rectangleF_0.Width);
				nudRightPadding.Maximum = Convert.ToDecimal(rectangleF_0.Width);
			}
			if (rectangleF_0.Height > 0f)
			{
				nudTopPadding.Maximum = Convert.ToDecimal(rectangleF_0.Height);
				nudBottomPadding.Maximum = Convert.ToDecimal(rectangleF_0.Height);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (xpaddingF_0 == null)
			{
				xpaddingF_0 = new XPaddingF();
			}
			xpaddingF_0.Left = Convert.ToSingle(nudLeftPadding.Value);
			xpaddingF_0.Top = Convert.ToSingle(nudTopPadding.Value);
			xpaddingF_0.Right = Convert.ToSingle(nudRightPadding.Value);
			xpaddingF_0.Bottom = Convert.ToSingle(nudBottomPadding.Value);
			base.DialogResult = DialogResult.OK;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Drawing.Design.dlgPadding));
			label1 = new System.Windows.Forms.Label();
			nudLeftPadding = new System.Windows.Forms.NumericUpDown();
			groupBox1 = new System.Windows.Forms.GroupBox();
			nudBottomPadding = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			nudRightPadding = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			nudTopPadding = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)nudLeftPadding).BeginInit();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudBottomPadding).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudRightPadding).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTopPadding).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(nudLeftPadding, "nudLeftPadding");
			nudLeftPadding.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			nudLeftPadding.Name = "nudLeftPadding";
			groupBox1.Controls.Add(nudBottomPadding);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(nudRightPadding);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(nudTopPadding);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(nudLeftPadding);
			groupBox1.Controls.Add(label1);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(nudBottomPadding, "nudBottomPadding");
			nudBottomPadding.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			nudBottomPadding.Name = "nudBottomPadding";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(nudRightPadding, "nudRightPadding");
			nudRightPadding.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			nudRightPadding.Name = "nudRightPadding";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(nudTopPadding, "nudTopPadding");
			nudTopPadding.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			nudTopPadding.Name = "nudTopPadding";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPadding";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPadding_Load);
			((System.ComponentModel.ISupportInitialize)nudLeftPadding).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudBottomPadding).EndInit();
			((System.ComponentModel.ISupportInitialize)nudRightPadding).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTopPadding).EndInit();
			ResumeLayout(false);
		}
	}
}
