using DCSoft.Common;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       插入参数对话框
	///       </summary>
	
	[ComVisible(false)]
	public class dlgInsertParameter : Form
	{
		private string string_0 = null;

		private string string_1 = null;

		private XTextDocument xtextDocument_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private TextBox txtName;

		private Label label2;

		private ListBox lstName;

		private GroupBox groupBox1;

		private Label lblPreview;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       输入域名称
		///       </summary>
		public string InputName
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       参数名
		///       </summary>
		public string InputParameterName
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		public XTextDocument Document
		{
			get
			{
				return xtextDocument_0;
			}
			set
			{
				xtextDocument_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgInsertParameter()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgInsertParameter_Load(object sender, EventArgs e)
		{
			if (Document != null)
			{
				lstName.Items.AddRange(Document.InnerParameters.Names);
				if (Document.Parameters != null)
				{
					lstName.Items.AddRange(Document.Parameters.Names);
				}
			}
			txtName.Text = InputName;
			lstName.Text = InputParameterName;
		}

		private void lstName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Document != null)
			{
				lblPreview.Text = Convert.ToString(Document.GetParameterValue(lstName.Text));
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			InputName = txtName.Text;
			InputParameterName = lstName.Text;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Controls.dlgInsertParameter));
			label1 = new System.Windows.Forms.Label();
			txtName = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			lstName = new System.Windows.Forms.ListBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			lblPreview = new System.Windows.Forms.Label();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtName, "txtName");
			txtName.Name = "txtName";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			lstName.FormattingEnabled = true;
			resources.ApplyResources(lstName, "lstName");
			lstName.Name = "lstName";
			lstName.SelectedIndexChanged += new System.EventHandler(lstName_SelectedIndexChanged);
			groupBox1.Controls.Add(lblPreview);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			lblPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			resources.ApplyResources(lblPreview, "lblPreview");
			lblPreview.Name = "lblPreview";
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
			base.Controls.Add(groupBox1);
			base.Controls.Add(lstName);
			base.Controls.Add(label2);
			base.Controls.Add(txtName);
			base.Controls.Add(label1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInsertParameter";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInsertParameter_Load);
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
