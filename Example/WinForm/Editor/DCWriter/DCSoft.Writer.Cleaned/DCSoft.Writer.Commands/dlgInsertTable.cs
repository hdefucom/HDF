using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       插入表格对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgInsertTable : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private NumericUpDown txtRows;

		private NumericUpDown txtColumns;

		private Label label2;

		private Button cmdOK;

		private Button cmdCancel;

		private GroupBox groupBox1;

		private Panel pnlPreview;

		private Label label3;

		private TextBox txtID;

		private ElementPropertiesEditEventArgs elementPropertiesEditEventArgs_0 = null;

		private XTextTableElementProperties xtextTableElementProperties_0 = new XTextTableElementProperties();

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
		///       用户使用的创建表格信息对象
		///       </summary>
		internal XTextTableElementProperties TableCreationInfo
		{
			get
			{
				return xtextTableElementProperties_0;
			}
			set
			{
				xtextTableElementProperties_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgInsertTable));
			label1 = new System.Windows.Forms.Label();
			txtRows = new System.Windows.Forms.NumericUpDown();
			txtColumns = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			pnlPreview = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			txtID = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)txtRows).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtColumns).BeginInit();
			groupBox1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtRows, "txtRows");
			txtRows.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtRows.Name = "txtRows";
			txtRows.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtRows.ValueChanged += new System.EventHandler(txtRows_ValueChanged);
			resources.ApplyResources(txtColumns, "txtColumns");
			txtColumns.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtColumns.Name = "txtColumns";
			txtColumns.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			txtColumns.ValueChanged += new System.EventHandler(txtColumns_ValueChanged);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.UseVisualStyleBackColor = true;
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.UseVisualStyleBackColor = true;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			groupBox1.Controls.Add(pnlPreview);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(pnlPreview, "pnlPreview");
			pnlPreview.Name = "pnlPreview";
			pnlPreview.Paint += new System.Windows.Forms.PaintEventHandler(pnlPreview_Paint);
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(txtID, "txtID");
			txtID.Name = "txtID";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtID);
			base.Controls.Add(label3);
			base.Controls.Add(groupBox1);
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(txtColumns);
			base.Controls.Add(label2);
			base.Controls.Add(txtRows);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInsertTable";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInsertTable_Load);
			((System.ComponentModel.ISupportInitialize)txtRows).EndInit();
			((System.ComponentModel.ISupportInitialize)txtColumns).EndInit();
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInsertTable()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInsertTable_Load(object sender, EventArgs e)
		{
			if (xtextTableElementProperties_0 != null)
			{
				txtRows.Value = xtextTableElementProperties_0.RowsCount;
				txtColumns.Value = xtextTableElementProperties_0.ColumnsCount;
				txtID.Text = xtextTableElementProperties_0.ID;
			}
		}

		private void method_0(XTextTableElementProperties xtextTableElementProperties_1)
		{
			xtextTableElementProperties_1.ID = txtID.Text;
			xtextTableElementProperties_1.RowsCount = (int)txtRows.Value;
			xtextTableElementProperties_1.ColumnsCount = (int)txtColumns.Value;
		}

		private void pnlPreview_Paint(object sender, PaintEventArgs e)
		{
			XTextTableElementProperties xTextTableElementProperties = new XTextTableElementProperties();
			method_0(xTextTableElementProperties);
			xTextTableElementProperties.DrawPreview(e.Graphics, new Rectangle(10, 10, pnlPreview.ClientSize.Width - 20, pnlPreview.ClientSize.Height - 20));
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (xtextTableElementProperties_0 == null)
			{
				xtextTableElementProperties_0 = new XTextTableElementProperties();
			}
			method_0(xtextTableElementProperties_0);
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtRows_ValueChanged(object sender, EventArgs e)
		{
			pnlPreview.Invalidate();
		}

		private void txtColumns_ValueChanged(object sender, EventArgs e)
		{
			pnlPreview.Invalidate();
		}
	}
}
