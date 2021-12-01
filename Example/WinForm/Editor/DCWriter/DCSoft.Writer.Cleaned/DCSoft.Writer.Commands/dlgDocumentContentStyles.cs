using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       文档样式列表对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgDocumentContentStyles : Form
	{
		private IContainer icontainer_0 = null;

		private ListBox lstStyles;

		private PropertyGrid myPropertyGrid;

		private Button btnCompress;

		private Button btnClose;

		private XTextDocument xtextDocument_0 = null;

		/// <summary>
		///       编辑器文档对象
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
			lstStyles = new System.Windows.Forms.ListBox();
			myPropertyGrid = new System.Windows.Forms.PropertyGrid();
			btnCompress = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			SuspendLayout();
			lstStyles.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			lstStyles.FormattingEnabled = true;
			lstStyles.ItemHeight = 12;
			lstStyles.Location = new System.Drawing.Point(2, 2);
			lstStyles.Name = "lstStyles";
			lstStyles.Size = new System.Drawing.Size(213, 328);
			lstStyles.TabIndex = 0;
			lstStyles.SelectedIndexChanged += new System.EventHandler(lstStyles_SelectedIndexChanged);
			myPropertyGrid.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			myPropertyGrid.Location = new System.Drawing.Point(221, 2);
			myPropertyGrid.Name = "myPropertyGrid";
			myPropertyGrid.Size = new System.Drawing.Size(314, 328);
			myPropertyGrid.TabIndex = 1;
			btnCompress.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			btnCompress.Location = new System.Drawing.Point(12, 344);
			btnCompress.Name = "btnCompress";
			btnCompress.Size = new System.Drawing.Size(120, 23);
			btnCompress.TabIndex = 2;
			btnCompress.Text = "压缩数据";
			btnCompress.UseVisualStyleBackColor = true;
			btnCompress.Click += new System.EventHandler(btnCompress_Click);
			btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			btnClose.Location = new System.Drawing.Point(339, 344);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(126, 23);
			btnClose.TabIndex = 2;
			btnClose.Text = "关闭";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(541, 379);
			base.Controls.Add(btnClose);
			base.Controls.Add(btnCompress);
			base.Controls.Add(myPropertyGrid);
			base.Controls.Add(lstStyles);
			base.MinimizeBox = false;
			base.Name = "dlgDocumentContentStyles";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "文档样式列表";
			base.Load += new System.EventHandler(dlgDocumentContentStyles_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgDocumentContentStyles()
		{
			InitializeComponent();
		}

		private void dlgDocumentContentStyles_Load(object sender, EventArgs e)
		{
			method_0();
		}

		private void method_0()
		{
			int num = 15;
			if (xtextDocument_0 != null)
			{
				lstStyles.Items.Clear();
				lstStyles.Items.Add("Default");
				int num2 = 0;
				foreach (DocumentContentStyle style in Document.ContentStyles.Styles)
				{
					_ = style;
					lstStyles.Items.Add("Style" + num2);
					num2++;
				}
			}
		}

		private void lstStyles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstStyles.SelectedIndex == 0)
			{
				myPropertyGrid.SelectedObject = Document.ContentStyles.Default;
				return;
			}
			int num = lstStyles.SelectedIndex - 1;
			if (num >= 0)
			{
				myPropertyGrid.SelectedObject = Document.ContentStyles.Styles[num];
			}
		}

		private void btnCompress_Click(object sender, EventArgs e)
		{
			if (Document != null)
			{
				Document.method_111();
				method_0();
				Document.EditorControl.InnerViewControl.Invalidate();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
