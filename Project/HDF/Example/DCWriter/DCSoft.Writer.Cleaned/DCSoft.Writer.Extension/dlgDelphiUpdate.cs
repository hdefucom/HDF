using DCSoftDotfuscate;
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
	[ComVisible(false)]
	public class dlgDelphiUpdate : Form
	{
		private IContainer icontainer_0 = null;

		private Panel panel1;

		private Label label1;

		private TabControl myTtabControl;

		private TabPage tabPage1;

		private Label label2;

		private TabPage tabPage2;

		private Label label3;

		private Button btnClearReg;

		private Button btnUnRegAsm;

		private Button btnPre;

		private Button btnNext;

		private Button btnClose;

		private TabPage tabPage3;

		private TabPage tabPage4;

		private Button btnRegAsm;

		private ComboBox cboDelphiVersion;

		private Label label5;

		private Button btnClearDelphi;

		private Label label4;

		private Button btnGenereatePascalTlb;

		private Button btnBrowseOutputDir;

		private TextBox txtOuptputDir;

		private Label label7;

		private TabPage tabPage5;

		private Label label8;

		private TextBox txtOutputPath;

		private Label label6;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgDelphiUpdate));
			panel1 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			myTtabControl = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			label3 = new System.Windows.Forms.Label();
			btnClearReg = new System.Windows.Forms.Button();
			btnUnRegAsm = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			tabPage2 = new System.Windows.Forms.TabPage();
			btnRegAsm = new System.Windows.Forms.Button();
			tabPage3 = new System.Windows.Forms.TabPage();
			cboDelphiVersion = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			btnClearDelphi = new System.Windows.Forms.Button();
			tabPage4 = new System.Windows.Forms.TabPage();
			label4 = new System.Windows.Forms.Label();
			btnGenereatePascalTlb = new System.Windows.Forms.Button();
			btnBrowseOutputDir = new System.Windows.Forms.Button();
			txtOuptputDir = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			tabPage5 = new System.Windows.Forms.TabPage();
			label8 = new System.Windows.Forms.Label();
			txtOutputPath = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			btnPre = new System.Windows.Forms.Button();
			btnNext = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			myTtabControl.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage3.SuspendLayout();
			tabPage4.SuspendLayout();
			tabPage5.SuspendLayout();
			SuspendLayout();
			panel1.BackColor = System.Drawing.Color.White;
			panel1.Controls.Add(label1);
			panel1.Dock = System.Windows.Forms.DockStyle.Top;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(495, 41);
			panel1.TabIndex = 0;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(3, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(351, 16);
			label1.TabIndex = 0;
			label1.Text = "南京都昌公司针对DELPHI的软件产品升级向导";
			myTtabControl.Controls.Add(tabPage1);
			myTtabControl.Controls.Add(tabPage2);
			myTtabControl.Controls.Add(tabPage3);
			myTtabControl.Controls.Add(tabPage4);
			myTtabControl.Controls.Add(tabPage5);
			myTtabControl.Dock = System.Windows.Forms.DockStyle.Top;
			myTtabControl.Location = new System.Drawing.Point(0, 41);
			myTtabControl.Name = "myTtabControl";
			myTtabControl.SelectedIndex = 0;
			myTtabControl.Size = new System.Drawing.Size(495, 259);
			myTtabControl.TabIndex = 1;
			myTtabControl.SelectedIndexChanged += new System.EventHandler(myTtabControl_SelectedIndexChanged);
			tabPage1.Controls.Add(label3);
			tabPage1.Controls.Add(btnClearReg);
			tabPage1.Controls.Add(btnUnRegAsm);
			tabPage1.Controls.Add(label2);
			tabPage1.Location = new System.Drawing.Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(487, 233);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "第一步:卸载";
			tabPage1.UseVisualStyleBackColor = true;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(8, 118);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(449, 12);
			label3.TabIndex = 8;
			label3.Text = "如果升级效果不好，请尝试点击下面的按钮进行强力卸载然后重新执行一遍本向导。";
			btnClearReg.ForeColor = System.Drawing.Color.Red;
			btnClearReg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnClearReg.Location = new System.Drawing.Point(50, 143);
			btnClearReg.Name = "btnClearReg";
			btnClearReg.Size = new System.Drawing.Size(243, 46);
			btnClearReg.TabIndex = 7;
			btnClearReg.Text = "强力卸载旧软件(慎用)";
			btnClearReg.UseVisualStyleBackColor = true;
			btnClearReg.Click += new System.EventHandler(btnClearReg_Click);
			btnUnRegAsm.ForeColor = System.Drawing.SystemColors.ControlText;
			btnUnRegAsm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnUnRegAsm.Location = new System.Drawing.Point(50, 60);
			btnUnRegAsm.Name = "btnUnRegAsm";
			btnUnRegAsm.Size = new System.Drawing.Size(243, 46);
			btnUnRegAsm.TabIndex = 6;
			btnUnRegAsm.Text = "卸载旧软件";
			btnUnRegAsm.UseVisualStyleBackColor = true;
			btnUnRegAsm.Click += new System.EventHandler(btnUnRegAsm_Click);
			label2.Location = new System.Drawing.Point(8, 13);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(471, 44);
			label2.TabIndex = 0;
			label2.Text = "欢迎使用都昌软件针对DELPHI的升级向导。请按照本向导提供的步骤一步步的完成操作。\r\n请点击下面的“卸载旧控件”进行软件控件的卸载操作。";
			tabPage2.Controls.Add(btnRegAsm);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(487, 233);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "第二步:安装";
			tabPage2.UseVisualStyleBackColor = true;
			btnRegAsm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnRegAsm.Location = new System.Drawing.Point(53, 46);
			btnRegAsm.Name = "btnRegAsm";
			btnRegAsm.Size = new System.Drawing.Size(347, 127);
			btnRegAsm.TabIndex = 1;
			btnRegAsm.Text = "向操作系统安装控件";
			btnRegAsm.UseVisualStyleBackColor = true;
			btnRegAsm.Click += new System.EventHandler(btnRegAsm_Click);
			tabPage3.Controls.Add(cboDelphiVersion);
			tabPage3.Controls.Add(label5);
			tabPage3.Controls.Add(btnClearDelphi);
			tabPage3.Location = new System.Drawing.Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(487, 233);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "第三步:清理环境";
			tabPage3.UseVisualStyleBackColor = true;
			cboDelphiVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboDelphiVersion.FormattingEnabled = true;
			cboDelphiVersion.Location = new System.Drawing.Point(26, 58);
			cboDelphiVersion.Name = "cboDelphiVersion";
			cboDelphiVersion.Size = new System.Drawing.Size(271, 20);
			cboDelphiVersion.TabIndex = 10;
			label5.AutoSize = true;
			label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			label5.Location = new System.Drawing.Point(24, 43);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(173, 12);
			label5.TabIndex = 9;
			label5.Text = "请选择您要处理的DELPHI版本：";
			btnClearDelphi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnClearDelphi.Location = new System.Drawing.Point(72, 117);
			btnClearDelphi.Name = "btnClearDelphi";
			btnClearDelphi.Size = new System.Drawing.Size(225, 47);
			btnClearDelphi.TabIndex = 8;
			btnClearDelphi.Text = "清理IDE环境";
			btnClearDelphi.UseVisualStyleBackColor = true;
			btnClearDelphi.Click += new System.EventHandler(btnClearDelphi_Click);
			tabPage4.Controls.Add(label4);
			tabPage4.Controls.Add(btnGenereatePascalTlb);
			tabPage4.Controls.Add(btnBrowseOutputDir);
			tabPage4.Controls.Add(txtOuptputDir);
			tabPage4.Controls.Add(label7);
			tabPage4.Location = new System.Drawing.Point(4, 22);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new System.Drawing.Size(487, 233);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "第四步:生成接口代码";
			tabPage4.UseVisualStyleBackColor = true;
			label4.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label4.ForeColor = System.Drawing.Color.Red;
			label4.Location = new System.Drawing.Point(12, 71);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(457, 62);
			label4.TabIndex = 15;
			label4.Text = "请注意：在同一个电脑中这个目录一旦完成操作就尽量不要更改，保持固定不变，不同的电脑这个目录可以不一样。\r\n而且本操作会删除该目录下的所有的文件。";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnGenereatePascalTlb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnGenereatePascalTlb.Location = new System.Drawing.Point(119, 172);
			btnGenereatePascalTlb.Name = "btnGenereatePascalTlb";
			btnGenereatePascalTlb.Size = new System.Drawing.Size(207, 45);
			btnGenereatePascalTlb.TabIndex = 11;
			btnGenereatePascalTlb.Text = "生成接口代码";
			btnGenereatePascalTlb.UseVisualStyleBackColor = true;
			btnGenereatePascalTlb.Click += new System.EventHandler(btnGenereatePascalTlb_Click);
			btnBrowseOutputDir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			btnBrowseOutputDir.Location = new System.Drawing.Point(394, 134);
			btnBrowseOutputDir.Name = "btnBrowseOutputDir";
			btnBrowseOutputDir.Size = new System.Drawing.Size(75, 23);
			btnBrowseOutputDir.TabIndex = 14;
			btnBrowseOutputDir.Text = "浏览";
			btnBrowseOutputDir.UseVisualStyleBackColor = true;
			btnBrowseOutputDir.Click += new System.EventHandler(btnBrowseOutputDir_Click);
			txtOuptputDir.Location = new System.Drawing.Point(8, 136);
			txtOuptputDir.Name = "txtOuptputDir";
			txtOuptputDir.Size = new System.Drawing.Size(380, 21);
			txtOuptputDir.TabIndex = 13;
			txtOuptputDir.TextChanged += new System.EventHandler(txtOuptputDir_TextChanged);
			label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			label7.Location = new System.Drawing.Point(8, 9);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(461, 62);
			label7.TabIndex = 12;
			label7.Text = "本步骤用于输出DELPHI中使用的控件接口代码文件（包括PAS代码和DPK文件），请在下面输入接口代码文件输出目录，对于Windows7等安全限制比较多的操作系统，该目录不要放置在比较敏感的目录下，比如C:\\或C:\\Program Files或C:\\Windows等等。";
			label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			tabPage5.Controls.Add(label8);
			tabPage5.Controls.Add(txtOutputPath);
			tabPage5.Controls.Add(label6);
			tabPage5.Location = new System.Drawing.Point(4, 22);
			tabPage5.Name = "tabPage5";
			tabPage5.Size = new System.Drawing.Size(487, 233);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "第五步:使用";
			tabPage5.UseVisualStyleBackColor = true;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(8, 22);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(89, 12);
			label8.TabIndex = 2;
			label8.Text = "当前导入目录：";
			txtOutputPath.Location = new System.Drawing.Point(103, 19);
			txtOutputPath.Name = "txtOutputPath";
			txtOutputPath.ReadOnly = true;
			txtOutputPath.Size = new System.Drawing.Size(364, 21);
			txtOutputPath.TabIndex = 1;
			label6.Location = new System.Drawing.Point(3, 58);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(476, 162);
			label6.TabIndex = 0;
			label6.Text = resources.GetString("label6.Text");
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnPre.Location = new System.Drawing.Point(185, 306);
			btnPre.Name = "btnPre";
			btnPre.Size = new System.Drawing.Size(75, 23);
			btnPre.TabIndex = 2;
			btnPre.Text = "上一步";
			btnPre.UseVisualStyleBackColor = true;
			btnPre.Click += new System.EventHandler(btnPre_Click);
			btnNext.Location = new System.Drawing.Point(282, 306);
			btnNext.Name = "btnNext";
			btnNext.Size = new System.Drawing.Size(75, 23);
			btnNext.TabIndex = 2;
			btnNext.Text = "下一步";
			btnNext.UseVisualStyleBackColor = true;
			btnNext.Click += new System.EventHandler(btnNext_Click);
			btnClose.Location = new System.Drawing.Point(382, 306);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(75, 23);
			btnClose.TabIndex = 2;
			btnClose.Text = "关闭";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(495, 335);
			base.Controls.Add(btnClose);
			base.Controls.Add(btnNext);
			base.Controls.Add(btnPre);
			base.Controls.Add(myTtabControl);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dlgDelphiUpdate";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "南京都昌科技软件产品DELPHI升级向导";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(dlgDelphiUpdate_FormClosing);
			base.Load += new System.EventHandler(dlgDelphiUpdate_Load);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			myTtabControl.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			tabPage4.ResumeLayout(false);
			tabPage4.PerformLayout();
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
			ResumeLayout(false);
		}

		public dlgDelphiUpdate()
		{
			InitializeComponent();
		}

		private void dlgDelphiUpdate_Load(object sender, EventArgs e)
		{
			string[] array = Class66.smethod_5();
			if (array != null && array.Length > 0)
			{
				cboDelphiVersion.Items.AddRange(array);
				cboDelphiVersion.SelectedIndex = 0;
			}
			txtOuptputDir.Text = Class66.smethod_0();
			myTtabControl_SelectedIndexChanged(null, null);
		}

		private void btnUnRegAsm_Click(object sender, EventArgs e)
		{
			GClass37 gClass = new GClass37();
			gClass.method_1(bool_1: false);
			gClass.method_4(this, bool_1: false);
		}

		private void btnClearReg_Click(object sender, EventArgs e)
		{
			GClass37 gClass = new GClass37();
			gClass.method_1(bool_1: false);
			gClass.method_4(this, bool_1: true);
		}

		private void btnRegAsm_Click(object sender, EventArgs e)
		{
			GClass37 gClass = new GClass37();
			gClass.method_1(bool_1: false);
			_ = GetType().Assembly;
			if (gClass.method_6(this, bool_1: true))
			{
			}
		}

		private void btnClearDelphi_Click(object sender, EventArgs e)
		{
			int num = 8;
			if (!string.IsNullOrEmpty(cboDelphiVersion.Text))
			{
				GClass37 gClass = new GClass37();
				if (gClass.method_19(cboDelphiVersion.Text, new string[4]
				{
					"dcwriter",
					"dcsoft.writer",
					"dcsoft_writer",
					"dcsoftwriter"
				}))
				{
					MessageBox.Show(WriterStrings.PromptClearDelphi);
				}
			}
		}

		private void btnBrowseOutputDir_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.SelectedPath = txtOuptputDir.Text;
				folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
				if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
				{
					txtOuptputDir.Text = folderBrowserDialog.SelectedPath;
				}
			}
		}

		private void btnGenereatePascalTlb_Click(object sender, EventArgs e)
		{
			int num = 13;
			string text = Path.ChangeExtension(GetType().Assembly.Location, "tlb");
			if (!File.Exists(text))
			{
				MessageBox.Show(string.Format(WriterStrings.PromptGenerateDCWriterTlb_FileName, text));
			}
			else
			{
				if (string.IsNullOrEmpty(cboDelphiVersion.Text))
				{
					return;
				}
				string text2 = txtOuptputDir.Text.Trim();
				if (Directory.Exists(text2))
				{
					string[] files = Directory.GetFiles(text2);
					foreach (string text3 in files)
					{
						try
						{
							File.SetAttributes(text3, FileAttributes.Normal);
							File.Delete(text3);
						}
						catch (Exception ex)
						{
							MessageBox.Show(this, "删除文件“" + text3 + "”时错误:" + ex.Message, "系统提示");
						}
					}
				}
				else
				{
					Directory.CreateDirectory(text2);
				}
				Cursor = Cursors.WaitCursor;
				GClass37 gClass = new GClass37();
				gClass.method_10(this, "tlibimp.exe");
				List<string> list = Class66.smethod_6(cboDelphiVersion.Text, text, text2, bool_0: false);
				if (list == null)
				{
					Cursor = Cursors.Default;
					return;
				}
				Cursor = Cursors.Default;
				if (list != null && list.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (string item in list)
					{
						stringBuilder.AppendLine(item);
					}
					MessageBox.Show(this, "生成以下文件:" + Environment.NewLine + stringBuilder.ToString(), WriterStrings.SystemAlert);
				}
			}
		}

		private void txtOuptputDir_TextChanged(object sender, EventArgs e)
		{
			txtOutputPath.Text = txtOuptputDir.Text;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnPre_Click(object sender, EventArgs e)
		{
			if (myTtabControl.SelectedIndex > 0)
			{
				myTtabControl.SelectedIndex--;
			}
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (myTtabControl.SelectedIndex < myTtabControl.TabPages.Count - 1)
			{
				myTtabControl.SelectedIndex++;
			}
		}

		private void myTtabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnPre.Enabled = (myTtabControl.SelectedIndex > 0);
			btnNext.Enabled = (myTtabControl.SelectedIndex < myTtabControl.TabPages.Count - 1);
		}

		private void dlgDelphiUpdate_FormClosing(object sender, FormClosingEventArgs e)
		{
			Class66.smethod_1(txtOuptputDir.Text);
		}
	}
}
