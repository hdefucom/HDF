using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       默认事件表达式对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgDefaultEventExpression : Form
	{
		private WriterControl writerControl_0 = null;

		private string string_0 = null;

		private XTextInputFieldElement xtextInputFieldElement_0 = null;

		private IContainer icontainer_0 = null;

		private Label lblTitle;

		private Label label1;

		private TextBox txtDefaultEventExpression;

		private Label label2;

		private CheckedListBox lstItems;

		private Button btnOK;

		private Button btnCancel;

		/// <summary>
		///       编辑器控件
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				return writerControl_0;
			}
			set
			{
				writerControl_0 = value;
			}
		}

		/// <summary>
		///       默认事件表达式文本
		///       </summary>
		public string DefaultEventExpression
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
		///       输入域对象
		///       </summary>
		public XTextInputFieldElement FieldElement
		{
			get
			{
				return xtextInputFieldElement_0;
			}
			set
			{
				xtextInputFieldElement_0 = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgDefaultEventExpression()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgDefaultEventExpression_Load(object sender, EventArgs e)
		{
			int num = 5;
			txtDefaultEventExpression.Text = DefaultEventExpression;
			if (xtextInputFieldElement_0 != null)
			{
				lblTitle.Text = "ID:" + xtextInputFieldElement_0.ID + "  Name:" + xtextInputFieldElement_0.Name;
				ListItemCollection runtimeListItems = xtextInputFieldElement_0.GetRuntimeListItems();
				if (runtimeListItems != null)
				{
					foreach (ListItem item in runtimeListItems)
					{
						lstItems.Items.Add(item.Text);
					}
				}
			}
		}

		private void lstItems_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			int num = 6;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < lstItems.Items.Count; i++)
			{
				bool flag = lstItems.GetItemChecked(i);
				if (i == e.Index)
				{
					flag = (e.NewValue != CheckState.Unchecked);
				}
				if (flag)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(" Or ");
					}
					stringBuilder.Append(string.Concat("value='", lstItems.Items[i], "'"));
				}
			}
			txtDefaultEventExpression.Text = stringBuilder.ToString();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DefaultEventExpression = txtDefaultEventExpression.Text;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgDefaultEventExpression));
			lblTitle = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			txtDefaultEventExpression = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			lstItems = new System.Windows.Forms.CheckedListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lblTitle, "lblTitle");
			lblTitle.Name = "lblTitle";
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(txtDefaultEventExpression, "txtDefaultEventExpression");
			txtDefaultEventExpression.Name = "txtDefaultEventExpression";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			lstItems.CheckOnClick = true;
			lstItems.FormattingEnabled = true;
			resources.ApplyResources(lstItems, "lstItems");
			lstItems.Name = "lstItems";
			lstItems.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(lstItems_ItemCheck);
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
			base.Controls.Add(lstItems);
			base.Controls.Add(label2);
			base.Controls.Add(txtDefaultEventExpression);
			base.Controls.Add(label1);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDefaultEventExpression";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgDefaultEventExpression_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
