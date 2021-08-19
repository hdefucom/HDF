using DCSoft.Writer.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       生成命令名称源代码
	///       </summary>
	[ComVisible(false)]
	public class dlgGenerateCommandNameSourceCode : Form
	{
		private IContainer icontainer_0 = null;

		private Label label1;

		private ComboBox ComboxType;

		private Label label2;

		private Label label3;

		private Button btnRefresh;

		private TextBox txtCode;

		private Button btnOK;

		private Button btnClose;

		private SaveFileDialog saveFileDialog_0;

		private TextBox txtVar;

		private WriterAppHost writerAppHost_0 = WriterAppHost.Default;

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		public WriterAppHost AppHost
		{
			get
			{
				return writerAppHost_0;
			}
			set
			{
				writerAppHost_0 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgGenerateCommandNameSourceCode));
			label1 = new System.Windows.Forms.Label();
			ComboxType = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			btnRefresh = new System.Windows.Forms.Button();
			txtCode = new System.Windows.Forms.TextBox();
			btnOK = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			saveFileDialog_0 = new System.Windows.Forms.SaveFileDialog();
			txtVar = new System.Windows.Forms.TextBox();
			SuspendLayout();
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			ComboxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(ComboxType, "ComboxType");
			ComboxType.FormattingEnabled = true;
			ComboxType.Items.AddRange(new object[5]
			{
				resources.GetString("ComboxType.Items"),
				resources.GetString("ComboxType.Items1"),
				resources.GetString("ComboxType.Items2"),
				resources.GetString("ComboxType.Items3"),
				resources.GetString("ComboxType.Items4")
			});
			ComboxType.Name = "ComboxType";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			resources.ApplyResources(btnRefresh, "btnRefresh");
			btnRefresh.Name = "btnRefresh";
			btnRefresh.UseVisualStyleBackColor = true;
			btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
			resources.ApplyResources(txtCode, "txtCode");
			txtCode.Name = "txtCode";
			txtCode.ReadOnly = true;
			resources.ApplyResources(btnOK, "btnOK");
			btnOK.Name = "btnOK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(btnClose, "btnClose");
			btnClose.Name = "btnClose";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			txtVar.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(txtVar, "txtVar");
			txtVar.Name = "txtVar";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtVar);
			base.Controls.Add(btnClose);
			base.Controls.Add(btnOK);
			base.Controls.Add(txtCode);
			base.Controls.Add(btnRefresh);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(ComboxType);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgGenerateCommandNameSourceCode";
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgGenerateCommandNameSourceCode_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgGenerateCommandNameSourceCode()
		{
			InitializeComponent();
			base.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		///       刷新
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			int num = 11;
			txtCode.Text = "";
			List<WriterCommand> allCommands = AppHost.CommandContainer.AllCommands;
			StringBuilder stringBuilder = new StringBuilder();
			string text = ComboxType.Text;
			foreach (WriterCommand item in allCommands)
			{
				switch (text)
				{
				case "C#":
					stringBuilder.AppendLine("public const string " + txtVar.Text + item.Name + "=\"" + item.Name + "\";\r\n");
					break;
				case "C++":
					stringBuilder.AppendLine("public const string " + txtVar.Text + item.Name + "=\"" + item.Name + "\";\r\n");
					break;
				case "VB":
					stringBuilder.AppendLine("Public Const " + txtVar.Text + item.Name + " As String=\"" + item.Name + "\"\r\n");
					break;
				case "DELPHI":
					stringBuilder.AppendLine("public const string " + txtVar.Text + item.Name + ":='" + item.Name + "';\r\n");
					break;
				}
			}
			txtCode.Text = stringBuilder.ToString();
		}

		/// <summary>
		///       保存文本
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnOK_Click(object sender, EventArgs e)
		{
			int num = 13;
			saveFileDialog_0.Title = "保存文本";
			saveFileDialog_0.RestoreDirectory = true;
			switch (ComboxType.Text)
			{
			case "C#":
				saveFileDialog_0.Filter = "C#代码(*.cs)|*.cs";
				break;
			case "C++":
				saveFileDialog_0.Filter = "C++代码(*.cpp)|*.cpp";
				break;
			case "VB":
				saveFileDialog_0.Filter = "VB代码(*.bas)|*.bas";
				break;
			case "DELPHI":
				saveFileDialog_0.Filter = "Delphi代码(*.pas)|*.pas";
				break;
			case "PB":
				saveFileDialog_0.Filter = "PB代码(*.txt)|*.txt";
				break;
			}
			if (saveFileDialog_0.ShowDialog() == DialogResult.OK && saveFileDialog_0.FileName != "")
			{
				File.WriteAllText(saveFileDialog_0.FileName, txtCode.Text, Encoding.Default);
			}
		}

		/// <summary>
		///       关闭
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		///       首次加载
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void dlgGenerateCommandNameSourceCode_Load(object sender, EventArgs e)
		{
			txtVar.Text = "Command_";
			ComboxType.SelectedIndex = 0;
		}
	}
}
