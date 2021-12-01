using DCSoft.Drawing;
using DCSoft.Drawing.Design;
using DCSoft.Writer.Dom;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       页码信息对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgPageInfoType : Form
	{
		private PageInfoValueType pageInfoValueType_0 = PageInfoValueType.PageIndex;

		private ParagraphListStyle paragraphListStyle_0 = ParagraphListStyle.ListNumberStyle;

		private string string_0 = null;

		private IContainer icontainer_0 = null;

		private Label label1;

		private ListBox lstPageInfoType;

		private Button btnOK;

		private Button btnCancel;

		private Label label2;

		private Button btnDisplayFormat;

		private Label label3;

		private ComboBox cboFormatString;

		private CheckBox chkAutoHeight;

		private Label label4;

		private TextBox txtSpecifyPageIndexText;

		/// <summary>
		///       页码信息
		///       </summary>
		public PageInfoValueType ContentType
		{
			get
			{
				return pageInfoValueType_0;
			}
			set
			{
				pageInfoValueType_0 = value;
			}
		}

		/// <summary>
		///       数字显示格式
		///       </summary>
		public ParagraphListStyle DisplayFormat
		{
			get
			{
				return paragraphListStyle_0;
			}
			set
			{
				paragraphListStyle_0 = value;
			}
		}

		/// <summary>
		///       格式化字符串
		///       </summary>
		public string InputFormatString
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
		///       自动高度
		///       </summary>
		public bool SetAutoHeight
		{
			get
			{
				return chkAutoHeight.Checked;
			}
			set
			{
				chkAutoHeight.Checked = value;
			}
		}

		/// <summary>
		///       指定的页码编号文本
		///       </summary>
		public string SpecifyPageIndexTexts
		{
			get
			{
				return txtSpecifyPageIndexText.Text;
			}
			set
			{
				txtSpecifyPageIndexText.Text = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgPageInfoType()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void dlgPageInfoType_Load(object sender, EventArgs e)
		{
			lstPageInfoType.SelectedIndex = (int)pageInfoValueType_0;
			btnDisplayFormat.Text = DisplayFormat.ToString();
			cboFormatString.Text = InputFormatString;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			pageInfoValueType_0 = (PageInfoValueType)lstPageInfoType.SelectedIndex;
			InputFormatString = cboFormatString.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnDisplayFormat_Click(object sender, EventArgs e)
		{
			using (dlgParagraphListStyle dlgParagraphListStyle = new dlgParagraphListStyle())
			{
				dlgParagraphListStyle.IncludeBulletedList = false;
				dlgParagraphListStyle.SelectedListStyle = DisplayFormat;
				if (dlgParagraphListStyle.ShowDialog(this) == DialogResult.OK)
				{
					DisplayFormat = dlgParagraphListStyle.SelectedListStyle;
					btnDisplayFormat.Text = dlgParagraphListStyle.SelectedListStyle.ToString();
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgPageInfoType));
			label1 = new System.Windows.Forms.Label();
			lstPageInfoType = new System.Windows.Forms.ListBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			btnDisplayFormat = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			cboFormatString = new System.Windows.Forms.ComboBox();
			chkAutoHeight = new System.Windows.Forms.CheckBox();
			label4 = new System.Windows.Forms.Label();
			txtSpecifyPageIndexText = new System.Windows.Forms.TextBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			resources.ApplyResources(lstPageInfoType, "lstPageInfoType");
			lstPageInfoType.FormattingEnabled = true;
			lstPageInfoType.Items.AddRange(new object[4]
			{
				resources.GetString("lstPageInfoType.Items"),
				resources.GetString("lstPageInfoType.Items1"),
				resources.GetString("lstPageInfoType.Items2"),
				resources.GetString("lstPageInfoType.Items3")
			});
			lstPageInfoType.Name = "lstPageInfoType";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(btnDisplayFormat, "btnDisplayFormat");
			btnDisplayFormat.Name = "btnDisplayFormat";
			btnDisplayFormat.UseVisualStyleBackColor = true;
			btnDisplayFormat.Click += new System.EventHandler(btnDisplayFormat_Click);
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			cboFormatString.FormattingEnabled = true;
			cboFormatString.Items.AddRange(new object[3]
			{
				DCSoft.Writer.WriterStrings.Command_AlignBottomCenter,
				resources.GetString("cboFormatString.Items"),
				resources.GetString("cboFormatString.Items1")
			});
			resources.ApplyResources(cboFormatString, "cboFormatString");
			cboFormatString.Name = "cboFormatString";
			resources.ApplyResources(chkAutoHeight, "chkAutoHeight");
			chkAutoHeight.Name = "chkAutoHeight";
			chkAutoHeight.UseVisualStyleBackColor = true;
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			resources.ApplyResources(txtSpecifyPageIndexText, "txtSpecifyPageIndexText");
			txtSpecifyPageIndexText.Name = "txtSpecifyPageIndexText";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtSpecifyPageIndexText);
			base.Controls.Add(label4);
			base.Controls.Add(chkAutoHeight);
			base.Controls.Add(cboFormatString);
			base.Controls.Add(label3);
			base.Controls.Add(btnDisplayFormat);
			base.Controls.Add(label2);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(lstPageInfoType);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgPageInfoType";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgPageInfoType_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
