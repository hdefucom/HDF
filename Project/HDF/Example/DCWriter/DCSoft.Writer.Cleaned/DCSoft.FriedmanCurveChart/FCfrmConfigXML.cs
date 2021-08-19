using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       产程图配置XML文本对话框
	///       </summary>
	[ComVisible(false)]
	public class FCfrmConfigXML : Form
	{
		/// <summary>
		///       Required designer variable.
		///       </summary>
		private IContainer components = null;

		private TextBox textBox1;

		private Button btnOK;

		private Button btnCancel;

		private Button btnReplaceChars;

		private Button btnCopy;

		private Button btnPaste;

		/// <summary>
		///       XML文本
		///       </summary>
		public string XMLText
		{
			get
			{
				return textBox1.Text;
			}
			set
			{
				textBox1.Text = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public FCfrmConfigXML()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		private void frmConfigXML_Load(object sender, EventArgs e)
		{
			textBox1.Modified = false;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (textBox1.Modified)
			{
				base.DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnReplaceChars_Click(object sender, EventArgs e)
		{
			bool modified = textBox1.Modified;
			string text = textBox1.Text.Replace('"', '\'');
			textBox1.Text = text;
			textBox1.Modified = modified;
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetText(textBox1.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
			try
			{
				string text = Clipboard.GetText();
				if (!string.IsNullOrEmpty(text))
				{
					textBox1.Text = text;
				}
			}
			catch
			{
			}
		}

		/// <summary>
		///       Clean up any resources being used.
		///       </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///       Required method for Designer support - do not modify
		///       the contents of this method with the code editor.
		///       </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.FriedmanCurveChart.FCfrmConfigXML));
			textBox1 = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			btnReplaceChars = new System.Windows.Forms.Button();
			btnCopy = new System.Windows.Forms.Button();
			btnPaste = new System.Windows.Forms.Button();
			SuspendLayout();
			resources.ApplyResources(textBox1, "textBox1");
			textBox1.Name = "textBox1";
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnCancel, "btnCancel");
			btnCancel.Name = "btnCancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			resources.ApplyResources(btnReplaceChars, "btnReplaceChars");
			btnReplaceChars.Name = "btnReplaceChars";
			btnReplaceChars.UseVisualStyleBackColor = true;
			btnReplaceChars.Click += new System.EventHandler(btnReplaceChars_Click);
			resources.ApplyResources(btnCopy, "btnCopy");
			btnCopy.Name = "btnCopy";
			btnCopy.UseVisualStyleBackColor = true;
			btnCopy.Click += new System.EventHandler(btnCopy_Click);
			resources.ApplyResources(btnPaste, "btnPaste");
			btnPaste.Name = "btnPaste";
			btnPaste.UseVisualStyleBackColor = true;
			btnPaste.Click += new System.EventHandler(btnPaste_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(btnPaste);
			base.Controls.Add(btnCopy);
			base.Controls.Add(btnReplaceChars);
			base.Controls.Add(btnCancel);
			base.Controls.Add(btnOK);
			base.Controls.Add(textBox1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmConfigXML";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(frmConfigXML_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
