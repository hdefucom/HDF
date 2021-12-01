using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       元素选择窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgBrowseElements : Form
	{
		private IContainer icontainer_0 = null;

		private ListBox lstElements;

		private Button btnOK;

		private Button btnCancel;

		private XTextElementList xtextElementList_0 = null;

		private XTextElement xtextElement_0 = null;

		/// <summary>
		///       元素列表
		///       </summary>
		public XTextElementList InputElements
		{
			get
			{
				return xtextElementList_0;
			}
			set
			{
				xtextElementList_0 = value;
			}
		}

		/// <summary>
		///       选择的元素
		///       </summary>
		public XTextElement SelectedElement
		{
			get
			{
				return xtextElement_0;
			}
			set
			{
				xtextElement_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgBrowseElements));
			lstElements = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lstElements, "lstElements");
			lstElements.FormattingEnabled = true;
			lstElements.Name = "lstElements";
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
			base.Controls.Add(lstElements);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgBrowseElements";
			base.Load += new System.EventHandler(dlgBrowseElements_Load);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgBrowseElements()
		{
			InitializeComponent();
		}

		private void dlgBrowseElements_Load(object sender, EventArgs e)
		{
			if (xtextElementList_0 != null)
			{
				int num = xtextElementList_0.IndexOf(xtextElement_0);
				foreach (XTextElement item in xtextElementList_0)
				{
					lstElements.Items.Add(item.ToDebugString());
				}
				if (num >= 0)
				{
					lstElements.SelectedIndex = num;
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (lstElements.SelectedIndex >= 0)
			{
				xtextElement_0 = xtextElementList_0[lstElements.SelectedIndex];
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
