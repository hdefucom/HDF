using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       数据源绑定对话框
	///       </summary>
	[ComVisible(false)]
	public class dlgXDataBinding : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private ComboBox cboDataSource;

		private Label label2;

		private ComboBox cboFormat;

		private Label label3;

		private CheckBox chkReadonly;

		private CheckBox chkAutoUpdate;

		private Button btnOK;

		private Button btnCancel;

		private ComboBox txtPath;

		private Label label4;

		private ComboBox cboProcessState;

		private CheckBox chkEnabled;

		private ComboBox cboPathForText;

		private Label label6;

		private XTextDocument xtextDocument_0 = null;

		private XTextElement xtextElement_0 = null;

		private XDataBinding xdataBinding_0 = null;

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
		///       操作的文档元素对象
		///       </summary>
		public XTextElement InputElement
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
		///       数据源绑定信息对象
		///       </summary>
		public XDataBinding XDataBinding
		{
			get
			{
				return xdataBinding_0;
			}
			set
			{
				xdataBinding_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Commands.dlgXDataBinding));
			label1 = new System.Windows.Forms.Label();
			cboDataSource = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			cboFormat = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			chkReadonly = new System.Windows.Forms.CheckBox();
			chkAutoUpdate = new System.Windows.Forms.CheckBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			txtPath = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			cboProcessState = new System.Windows.Forms.ComboBox();
			chkEnabled = new System.Windows.Forms.CheckBox();
			cboPathForText = new System.Windows.Forms.ComboBox();
			label6 = new System.Windows.Forms.Label();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			cboDataSource.FormattingEnabled = true;
			resources.ApplyResources(cboDataSource, "cboDataSource");
			cboDataSource.Name = "cboDataSource";
			cboDataSource.SelectedIndexChanged += new System.EventHandler(cboDataSource_SelectedIndexChanged);
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			cboFormat.FormattingEnabled = true;
			resources.ApplyResources(cboFormat, "cboFormat");
			cboFormat.Name = "cboFormat";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(chkReadonly, "chkReadonly");
			chkReadonly.Name = "chkReadonly";
			chkReadonly.UseVisualStyleBackColor = true;
			resources.ApplyResources(chkAutoUpdate, "chkAutoUpdate");
			chkAutoUpdate.Name = "chkAutoUpdate";
			chkAutoUpdate.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			txtPath.FormattingEnabled = true;
			resources.ApplyResources(txtPath, "txtPath");
			txtPath.Name = "txtPath";
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			cboProcessState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboProcessState.FormattingEnabled = true;
			cboProcessState.Items.AddRange(new object[3]
			{
				resources.GetString("cboProcessState.Items"),
				resources.GetString("cboProcessState.Items1"),
				resources.GetString("cboProcessState.Items2")
			});
			resources.ApplyResources(cboProcessState, "cboProcessState");
			cboProcessState.Name = "cboProcessState";
			resources.ApplyResources(chkEnabled, "chkEnabled");
			chkEnabled.Name = "chkEnabled";
			chkEnabled.UseVisualStyleBackColor = true;
			chkEnabled.CheckedChanged += new System.EventHandler(chkEnabled_CheckedChanged);
			cboPathForText.FormattingEnabled = true;
			resources.ApplyResources(cboPathForText, "cboPathForText");
			cboPathForText.Name = "cboPathForText";
			resources.ApplyResources(label6, "label6");
			label6.Name = "label6";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(chkEnabled);
			base.Controls.Add(label4);
			base.Controls.Add(cboProcessState);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(chkAutoUpdate);
			base.Controls.Add(chkReadonly);
			base.Controls.Add(cboFormat);
			base.Controls.Add(label6);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(cboPathForText);
			base.Controls.Add(txtPath);
			base.Controls.Add(cboDataSource);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgXDataBinding";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgXDataBinding_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgXDataBinding()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.OK;
		}

		private void dlgXDataBinding_Load(object sender, EventArgs e)
		{
			if (xdataBinding_0 == null)
			{
				xdataBinding_0 = new XDataBinding();
			}
			if (xtextDocument_0 != null)
			{
				cboDataSource.Items.AddRange(xtextDocument_0.InnerParameters.Names);
				if (xtextDocument_0.Parameters != null)
				{
					cboDataSource.Items.AddRange(xtextDocument_0.Parameters.Names);
				}
			}
			cboDataSource.Text = xdataBinding_0.DataSource;
			cboFormat.Text = xdataBinding_0.FormatString;
			txtPath.Text = xdataBinding_0.BindingPath;
			chkReadonly.Checked = xdataBinding_0.Readonly;
			chkAutoUpdate.Checked = xdataBinding_0.AutoUpdate;
			cboProcessState.SelectedIndex = (int)xdataBinding_0.ProcessState;
			chkEnabled.Checked = xdataBinding_0.Enabled;
			if (InputElement == null || InputElement is XTextInputFieldElement)
			{
				cboPathForText.Text = xdataBinding_0.BindingPathForText;
			}
			else
			{
				cboPathForText.Enabled = false;
			}
			chkEnabled_CheckedChanged(null, null);
		}

		private void cboDataSource_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtPath.Items.Clear();
			cboPathForText.Items.Clear();
			if (xtextDocument_0 == null)
			{
				return;
			}
			DocumentParameter documentParameter = xtextDocument_0.Parameters[cboDataSource.Text];
			if (documentParameter == null)
			{
				return;
			}
			string[] array = GClass318.smethod_3(documentParameter.Value);
			if (array != null)
			{
				string[] array2 = array;
				foreach (string item in array2)
				{
					txtPath.Items.Add(item);
					cboPathForText.Items.Add(item);
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			xdataBinding_0.Enabled = chkEnabled.Checked;
			xdataBinding_0.DataSource = method_0(cboDataSource.Text);
			xdataBinding_0.FormatString = method_0(cboFormat.Text);
			xdataBinding_0.Readonly = chkReadonly.Checked;
			xdataBinding_0.AutoUpdate = chkAutoUpdate.Checked;
			xdataBinding_0.BindingPath = method_0(txtPath.Text.Trim());
			xdataBinding_0.ProcessState = (DCProcessStates)cboProcessState.SelectedIndex;
			xdataBinding_0.BindingPathForText = cboPathForText.Text;
			base.DialogResult = DialogResult.OK;
			Close();
		}

		private string method_0(string string_0)
		{
			string_0 = string_0.Trim();
			if (string_0.Length == 0)
			{
				return null;
			}
			return string_0;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		public static bool smethod_0(Control control_0, XTextDocument xtextDocument_1, XTextElement xtextElement_1)
		{
			using (dlgXDataBinding dlgXDataBinding = new dlgXDataBinding())
			{
				dlgXDataBinding.XDataBinding = (XDataBinding)control_0.Tag;
				dlgXDataBinding.Document = xtextDocument_1;
				dlgXDataBinding.InputElement = xtextElement_1;
				if (dlgXDataBinding.ShowDialog(control_0) == DialogResult.OK)
				{
					control_0.Tag = dlgXDataBinding.XDataBinding.Clone();
					control_0.Text = dlgXDataBinding.XDataBinding.ToString();
					return true;
				}
			}
			return false;
		}

		private void chkEnabled_CheckedChanged(object sender, EventArgs e)
		{
			foreach (Control control in base.Controls)
			{
				if (control != chkEnabled && !(control is Button))
				{
					control.Enabled = chkEnabled.Checked;
				}
			}
			if (cboPathForText.Enabled)
			{
				cboPathForText.Enabled = (InputElement is XTextInputFieldElement);
			}
		}
	}
}
