using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       内容复制来源窗体对象
	///       </summary>
	[ComVisible(false)]
	public class dlgCopySourceInfo : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private Label label2;

		private ComboBox cboSourcePropertyName;

		private Label label3;

		private ComboBox cboDescPropertyName;

		private CheckBox chkIgnoreChildElements;

		private Button btnOK;

		private Button btnCancel;

		private ComboBox cboSourceID;

		private XTextElement xtextElement_0 = null;

		private CopySourceInfo copySourceInfo_0 = null;

		/// <summary>
		///       当前元素
		///       </summary>
		public XTextElement DescElement
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
		///       复制数据源信息
		///       </summary>
		public CopySourceInfo InputInfo
		{
			get
			{
				return copySourceInfo_0;
			}
			set
			{
				copySourceInfo_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgCopySourceInfo));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			cboSourcePropertyName = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			cboDescPropertyName = new System.Windows.Forms.ComboBox();
			chkIgnoreChildElements = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			cboSourceID = new System.Windows.Forms.ComboBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			cboSourcePropertyName.FormattingEnabled = true;
			resources.ApplyResources(cboSourcePropertyName, "cboSourcePropertyName");
			cboSourcePropertyName.Name = "cboSourcePropertyName";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboDescPropertyName.FormattingEnabled = true;
			resources.ApplyResources(cboDescPropertyName, "cboDescPropertyName");
			cboDescPropertyName.Name = "cboDescPropertyName";
			resources.ApplyResources(chkIgnoreChildElements, "chkIgnoreChildElements");
			chkIgnoreChildElements.Name = "chkIgnoreChildElements";
			chkIgnoreChildElements.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			cboSourceID.FormattingEnabled = true;
			resources.ApplyResources(cboSourceID, "cboSourceID");
			cboSourceID.Name = "cboSourceID";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkIgnoreChildElements);
			base.Controls.Add(cboDescPropertyName);
			base.Controls.Add(label3);
			base.Controls.Add(cboSourceID);
			base.Controls.Add(cboSourcePropertyName);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgCopySourceInfo";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgCopySourceInfo_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgCopySourceInfo()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgCopySourceInfo_Load(object sender, EventArgs e)
		{
			if (xtextElement_0 != null && xtextElement_0.OwnerDocument != null)
			{
				foreach (XTextInputFieldElement item in xtextElement_0.OwnerDocument.GetElementsByType(typeof(XTextInputFieldElement)))
				{
					if (!string.IsNullOrEmpty(item.ID))
					{
						cboSourceID.Items.Add(item.ID);
					}
				}
			}
			if (xtextElement_0 != null)
			{
				Type type = xtextElement_0.GetType();
				PropertyInfo[] properties = type.GetProperties();
				foreach (PropertyInfo propertyInfo in properties)
				{
					cboDescPropertyName.Items.Add(propertyInfo.Name);
				}
			}
			if (InputInfo != null)
			{
				cboSourceID.Text = InputInfo.SourceID;
				cboSourcePropertyName.Text = InputInfo.SourcePropertyName;
				cboDescPropertyName.Text = InputInfo.DescPropertyName;
				chkIgnoreChildElements.Checked = InputInfo.IgnoreChildElements;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (InputInfo == null)
			{
				InputInfo = new CopySourceInfo();
			}
			InputInfo.SourceID = cboSourceID.Text;
			InputInfo.SourcePropertyName = cboSourcePropertyName.Text;
			InputInfo.DescPropertyName = cboDescPropertyName.Text;
			InputInfo.IgnoreChildElements = chkIgnoreChildElements.Checked;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
