using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       InputBox 的摘要说明。
	///       </summary>
	[ComVisible(false)]
	public class dlgInputBox : Form
	{
		public CheckStringHandler CheckValueHandler = null;

		internal Label lblTitle;

		internal TextBox txtInput;

		internal Button cmdOK;

		internal Button cmdCancel;

		public string string_0 = "输入的数据错误，请重新输入!";

		private string string_1 = "";

		private Container container_0 = null;

		public string InputTitle
		{
			get
			{
				return lblTitle.Text;
			}
			set
			{
				lblTitle.Text = value;
			}
		}

		/// <summary>
		///       字符串值
		///       </summary>
		public string TextValue
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
		///       显示一个单行文本输入对话框,若用户取消输入则返回空引用
		///       </summary>
		/// <param name="ParentWindow">父窗体对象</param>
		/// <param name="strTitle">对话框说明</param>
		/// <param name="strCaption">对话框标题</param>
		/// <param name="strDefaultValue">默认值</param>
		/// <returns>用户输入的文本数据,若取消输入则返回空引用</returns>
		public static string InputBox(IWin32Window ParentWindow, string strTitle, string strCaption, string strDefaultValue)
		{
			using (dlgInputBox dlgInputBox = new dlgInputBox())
			{
				dlgInputBox.lblTitle.Text = strTitle;
				dlgInputBox.Text = strCaption;
				dlgInputBox.TextValue = strDefaultValue;
				if (dlgInputBox.ShowDialog(ParentWindow) == DialogResult.OK)
				{
					return dlgInputBox.txtInput.Text;
				}
			}
			return null;
		}

		public static string smethod_0(string string_2, string string_3, string string_4)
		{
			return InputBox(null, string_2, string_3, string_4);
		}

		public static string smethod_1(string string_2, string string_3, string string_4, CheckStringHandler checkStringHandler_0)
		{
			using (dlgInputBox dlgInputBox = new dlgInputBox())
			{
				dlgInputBox.lblTitle.Text = string_2;
				dlgInputBox.Text = string_3;
				dlgInputBox.TextValue = string_4;
				if (checkStringHandler_0 != null)
				{
					dlgInputBox.CheckValueHandler = checkStringHandler_0;
				}
				if (dlgInputBox.ShowDialog() == DialogResult.OK)
				{
					return dlgInputBox.txtInput.Text;
				}
			}
			return null;
		}

		public static string smethod_2(string string_2, string string_3, CheckStringHandler checkStringHandler_0)
		{
			int num = 8;
			using (dlgInputBox dlgInputBox = new dlgInputBox())
			{
				dlgInputBox.lblTitle.Text = string_2;
				dlgInputBox.Text = string_3;
				dlgInputBox.txtInput.PasswordChar = '*';
				dlgInputBox.CheckValueHandler = checkStringHandler_0;
				dlgInputBox.string_0 = "密码输入错误，请重新输入!";
				if (dlgInputBox.ShowDialog() == DialogResult.OK)
				{
					return dlgInputBox.TextValue;
				}
			}
			return null;
		}

		public dlgInputBox()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		///       清理所有正在使用的资源。
		///       </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && container_0 != null)
			{
				container_0.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       设计器支持所需的方法 - 不要使用代码编辑器修改
		///       此方法的内容。
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.WinForms.dlgInputBox));
			lblTitle = new System.Windows.Forms.Label();
			txtInput = new System.Windows.Forms.TextBox();
			cmdOK = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(lblTitle, "lblTitle");
			lblTitle.Name = "lblTitle";
			resources.ApplyResources(txtInput, "txtInput");
			txtInput.Name = "txtInput";
			txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(txtInput_KeyDown);
			resources.ApplyResources(cmdOK, "cmdOK");
			cmdOK.Name = "cmdOK";
			cmdOK.Click += new System.EventHandler(cmdOK_Click);
			cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(cmdCancel, "cmdCancel");
			cmdCancel.Name = "cmdCancel";
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			resources.ApplyResources(this, "$this");
			base.CancelButton = cmdCancel;
			base.Controls.Add(cmdCancel);
			base.Controls.Add(cmdOK);
			base.Controls.Add(txtInput);
			base.Controls.Add(lblTitle);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgInputBox";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgInputBox_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		private void cmdOK_Click(object sender, EventArgs e)
		{
			if (CheckValueHandler != null && !CheckValueHandler(txtInput.Text))
			{
				txtInput.Focus();
				txtInput.SelectAll();
			}
			else
			{
				string_1 = txtInput.Text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				cmdOK_Click(null, null);
			}
		}

		private void dlgInputBox_Load(object sender, EventArgs e)
		{
			txtInput.Text = string_1;
		}
	}
}
