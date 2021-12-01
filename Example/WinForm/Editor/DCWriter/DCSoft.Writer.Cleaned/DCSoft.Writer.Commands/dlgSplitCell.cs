using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       表格单元格拆分窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgSplitCell : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private NumericUpDown nudColSpan;

		private Label label2;

		private NumericUpDown nudRowSpan;

		private Button btnOK;

		private Button btnCancel;

		private Label lblAllowRows;

		private int int_0 = 1;

		/// <summary>
		///       行数可选值范围
		///       </summary>
		public int OldRowSpan
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       拆分行数
		///       </summary>
		public int InputRowsNum
		{
			get
			{
				return Convert.ToInt32(nudRowSpan.Value);
			}
			set
			{
				nudRowSpan.Value = value;
			}
		}

		/// <summary>
		///       拆分列数
		///       </summary>
		public int InputColsNum
		{
			get
			{
				return Convert.ToInt32(nudColSpan.Value);
			}
			set
			{
				nudColSpan.Value = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgSplitCell));
			label1 = new System.Windows.Forms.Label();
			nudColSpan = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			nudRowSpan = new System.Windows.Forms.NumericUpDown();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			lblAllowRows = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)nudColSpan).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudRowSpan).BeginInit();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(nudColSpan, "nudColSpan");
			nudColSpan.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			nudColSpan.Name = "nudColSpan";
			nudColSpan.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(nudRowSpan, "nudRowSpan");
			nudRowSpan.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			nudRowSpan.Name = "nudRowSpan";
			nudRowSpan.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(lblAllowRows, "lblAllowRows");
			lblAllowRows.Name = "lblAllowRows";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.Controls.Add(lblAllowRows);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(nudRowSpan);
			base.Controls.Add(label2);
			base.Controls.Add(nudColSpan);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgSplitCell";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgSplitCell_Load);
			((System.ComponentModel.ISupportInitialize)nudColSpan).EndInit();
			((System.ComponentModel.ISupportInitialize)nudRowSpan).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgSplitCell()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgSplitCell_Load(object sender, EventArgs e)
		{
			int num = 12;
			if (OldRowSpan > 1)
			{
				nudRowSpan.Maximum = OldRowSpan;
				StringBuilder stringBuilder = new StringBuilder();
				int[] array = MathCommon.smethod_3(OldRowSpan);
				for (int i = 0; i < array.Length; i++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(array[i].ToString());
				}
				lblAllowRows.Text = string.Format(lblAllowRows.Text, stringBuilder.ToString());
			}
			else
			{
				nudRowSpan.Maximum = 10m;
				StringBuilder stringBuilder = new StringBuilder();
				lblAllowRows.Visible = false;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (OldRowSpan != 1)
			{
				int[] array = MathCommon.smethod_3(OldRowSpan);
				int inputRowsNum = InputRowsNum;
				bool flag = false;
				for (int i = 0; i < array.Length; i++)
				{
					if (inputRowsNum == array[i])
					{
						flag = true;
					}
				}
				if (!flag)
				{
					MessageBox.Show(this, WriterStrings.PormptInvalidateRowsNum, Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
