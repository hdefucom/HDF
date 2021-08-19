using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.Extension
{
	/// <summary>
	///       DCWRITER运行环境配置对话框
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class dlgDCEnvirmentConfig : Form
	{
		private class Class27 : IComparer<Type>
		{
			public int Compare(Type type_0, Type type_1)
			{
				return string.Compare(type_0.FullName, type_1.FullName);
			}
		}

		private IContainer icontainer_0 = null;

		private Button btnRegAsm;

		private Label label1;

		private Button btnUnRegAsm;

		private Button btnSetSite;

		private TextBox txtASMUrl;

		private Label label2;

		private GroupBox groupBox2;

		private TextBox txtLog;

		private TabControl myTabControl;

		private TabPage pageStart;

		private Button btnToCOM;

		private Button btnToWeb;

		private TabPage pageWebSite;

		private Label label3;

		private TabPage pageCOM;

		private Label label4;

		private TabPage tabPage1;

		private ComboBox cboDelphiVersion;

		private Label label5;

		private Button btnGenereatePascalTlb;

		private Button btnClearDelphi;

		private Button btnRegASMandExit;

		private Button btnIEDebugFile;

		private TabPage tabPage2;

		private Button btnCheckComVisible;

		private Button btnAbout;

		private TextBox txtCurrentCOMPath;

		private Label lblCurrentCOMPath;

		private GroupBox groupBox1;

		private Button btnBrowseOutputDir;

		private TextBox txtOuptputDir;

		private Label label7;

		private Label lblCurrentAssemblyFile;

		private Button btnClearReg;

		private Button btnDelphiWinzard;

		private Button btnGenerateCAB;

		private Button btnCheckSerailize;

		private Button btnRegAsmFast;

		private bool bool_0 = false;

		private GClass358 gclass358_0 = null;

		private bool bool_1 = false;

		private bool bool_2 = false;

		/// <summary>
		///       安静模式
		///       </summary>
		public bool SilentMode
		{
			get
			{
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		public bool RegAsmFast
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Writer.Extension.dlgDCEnvirmentConfig));
			btnRegAsm = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			btnUnRegAsm = new System.Windows.Forms.Button();
			btnSetSite = new System.Windows.Forms.Button();
			txtASMUrl = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			txtLog = new System.Windows.Forms.TextBox();
			myTabControl = new System.Windows.Forms.TabControl();
			pageStart = new System.Windows.Forms.TabPage();
			btnDelphiWinzard = new System.Windows.Forms.Button();
			btnAbout = new System.Windows.Forms.Button();
			btnToCOM = new System.Windows.Forms.Button();
			btnToWeb = new System.Windows.Forms.Button();
			pageCOM = new System.Windows.Forms.TabPage();
			btnRegAsmFast = new System.Windows.Forms.Button();
			btnClearReg = new System.Windows.Forms.Button();
			lblCurrentAssemblyFile = new System.Windows.Forms.Label();
			txtCurrentCOMPath = new System.Windows.Forms.TextBox();
			lblCurrentCOMPath = new System.Windows.Forms.Label();
			btnRegASMandExit = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			pageWebSite = new System.Windows.Forms.TabPage();
			btnGenerateCAB = new System.Windows.Forms.Button();
			btnIEDebugFile = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			tabPage1 = new System.Windows.Forms.TabPage();
			groupBox1 = new System.Windows.Forms.GroupBox();
			btnGenereatePascalTlb = new System.Windows.Forms.Button();
			btnBrowseOutputDir = new System.Windows.Forms.Button();
			txtOuptputDir = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			cboDelphiVersion = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			btnClearDelphi = new System.Windows.Forms.Button();
			tabPage2 = new System.Windows.Forms.TabPage();
			btnCheckSerailize = new System.Windows.Forms.Button();
			btnCheckComVisible = new System.Windows.Forms.Button();
			groupBox2.SuspendLayout();
			myTabControl.SuspendLayout();
			pageStart.SuspendLayout();
			pageCOM.SuspendLayout();
			pageWebSite.SuspendLayout();
			tabPage1.SuspendLayout();
			groupBox1.SuspendLayout();
			tabPage2.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(btnRegAsm, "btnRegAsm");
			btnRegAsm.Name = "btnRegAsm";
			btnRegAsm.UseVisualStyleBackColor = true;
			btnRegAsm.Click += new System.EventHandler(btnRegAsm_Click);
			label1.BackColor = System.Drawing.SystemColors.Window;
			resources.ApplyResources(label1, "label1");
			label1.Name = "label1";
			btnUnRegAsm.ForeColor = System.Drawing.Color.Red;
			resources.ApplyResources(btnUnRegAsm, "btnUnRegAsm");
			btnUnRegAsm.Name = "btnUnRegAsm";
			btnUnRegAsm.UseVisualStyleBackColor = true;
			btnUnRegAsm.Click += new System.EventHandler(btnUnRegAsm_Click);
			resources.ApplyResources(btnSetSite, "btnSetSite");
			btnSetSite.Name = "btnSetSite";
			btnSetSite.UseVisualStyleBackColor = true;
			btnSetSite.Click += new System.EventHandler(btnSetSite_Click);
			resources.ApplyResources(txtASMUrl, "txtASMUrl");
			txtASMUrl.Name = "txtASMUrl";
			resources.ApplyResources(label2, "label2");
			label2.Name = "label2";
			groupBox2.Controls.Add(txtLog);
			resources.ApplyResources(groupBox2, "groupBox2");
			groupBox2.Name = "groupBox2";
			groupBox2.TabStop = false;
			resources.ApplyResources(txtLog, "txtLog");
			txtLog.Name = "txtLog";
			myTabControl.Controls.Add(pageStart);
			myTabControl.Controls.Add(pageCOM);
			myTabControl.Controls.Add(pageWebSite);
			myTabControl.Controls.Add(tabPage1);
			myTabControl.Controls.Add(tabPage2);
			resources.ApplyResources(myTabControl, "myTabControl");
			myTabControl.Name = "myTabControl";
			myTabControl.SelectedIndex = 0;
			pageStart.Controls.Add(btnDelphiWinzard);
			pageStart.Controls.Add(btnAbout);
			pageStart.Controls.Add(btnToCOM);
			pageStart.Controls.Add(btnToWeb);
			pageStart.Controls.Add(label1);
			resources.ApplyResources(pageStart, "pageStart");
			pageStart.Name = "pageStart";
			pageStart.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnDelphiWinzard, "btnDelphiWinzard");
			btnDelphiWinzard.Name = "btnDelphiWinzard";
			btnDelphiWinzard.UseVisualStyleBackColor = true;
			btnDelphiWinzard.Click += new System.EventHandler(btnDelphiWinzard_Click);
			resources.ApplyResources(btnAbout, "btnAbout");
			btnAbout.Name = "btnAbout";
			btnAbout.UseVisualStyleBackColor = true;
			btnAbout.Click += new System.EventHandler(btnAbout_Click);
			resources.ApplyResources(btnToCOM, "btnToCOM");
			btnToCOM.Name = "btnToCOM";
			btnToCOM.UseVisualStyleBackColor = true;
			btnToCOM.Click += new System.EventHandler(btnToCOM_Click);
			resources.ApplyResources(btnToWeb, "btnToWeb");
			btnToWeb.Name = "btnToWeb";
			btnToWeb.UseVisualStyleBackColor = true;
			btnToWeb.Click += new System.EventHandler(btnToWeb_Click);
			pageCOM.Controls.Add(btnRegAsmFast);
			pageCOM.Controls.Add(btnClearReg);
			pageCOM.Controls.Add(lblCurrentAssemblyFile);
			pageCOM.Controls.Add(txtCurrentCOMPath);
			pageCOM.Controls.Add(lblCurrentCOMPath);
			pageCOM.Controls.Add(btnRegASMandExit);
			pageCOM.Controls.Add(btnUnRegAsm);
			pageCOM.Controls.Add(label4);
			pageCOM.Controls.Add(btnRegAsm);
			resources.ApplyResources(pageCOM, "pageCOM");
			pageCOM.Name = "pageCOM";
			pageCOM.UseVisualStyleBackColor = true;
			btnRegAsmFast.ForeColor = System.Drawing.Color.Black;
			resources.ApplyResources(btnRegAsmFast, "btnRegAsmFast");
			btnRegAsmFast.Name = "btnRegAsmFast";
			btnRegAsmFast.UseVisualStyleBackColor = true;
			btnRegAsmFast.Click += new System.EventHandler(btnRegAsmFast_Click);
			btnClearReg.ForeColor = System.Drawing.Color.Red;
			resources.ApplyResources(btnClearReg, "btnClearReg");
			btnClearReg.Name = "btnClearReg";
			btnClearReg.UseVisualStyleBackColor = true;
			btnClearReg.Click += new System.EventHandler(btnClearReg_Click);
			resources.ApplyResources(lblCurrentAssemblyFile, "lblCurrentAssemblyFile");
			lblCurrentAssemblyFile.Name = "lblCurrentAssemblyFile";
			resources.ApplyResources(txtCurrentCOMPath, "txtCurrentCOMPath");
			txtCurrentCOMPath.Name = "txtCurrentCOMPath";
			txtCurrentCOMPath.ReadOnly = true;
			resources.ApplyResources(lblCurrentCOMPath, "lblCurrentCOMPath");
			lblCurrentCOMPath.Name = "lblCurrentCOMPath";
			resources.ApplyResources(btnRegASMandExit, "btnRegASMandExit");
			btnRegASMandExit.Name = "btnRegASMandExit";
			btnRegASMandExit.UseVisualStyleBackColor = true;
			btnRegASMandExit.Click += new System.EventHandler(btnRegASMandExit_Click);
			resources.ApplyResources(label4, "label4");
			label4.Name = "label4";
			pageWebSite.Controls.Add(btnGenerateCAB);
			pageWebSite.Controls.Add(btnIEDebugFile);
			pageWebSite.Controls.Add(btnSetSite);
			pageWebSite.Controls.Add(txtASMUrl);
			pageWebSite.Controls.Add(label3);
			pageWebSite.Controls.Add(label2);
			resources.ApplyResources(pageWebSite, "pageWebSite");
			pageWebSite.Name = "pageWebSite";
			pageWebSite.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnGenerateCAB, "btnGenerateCAB");
			btnGenerateCAB.Name = "btnGenerateCAB";
			btnGenerateCAB.UseVisualStyleBackColor = true;
			btnGenerateCAB.Click += new System.EventHandler(btnGenerateCAB_Click);
			resources.ApplyResources(btnIEDebugFile, "btnIEDebugFile");
			btnIEDebugFile.Name = "btnIEDebugFile";
			btnIEDebugFile.UseVisualStyleBackColor = true;
			btnIEDebugFile.Click += new System.EventHandler(btnIEDebugFile_Click);
			resources.ApplyResources(label3, "label3");
			label3.Name = "label3";
			tabPage1.Controls.Add(groupBox1);
			tabPage1.Controls.Add(cboDelphiVersion);
			tabPage1.Controls.Add(label5);
			tabPage1.Controls.Add(btnClearDelphi);
			resources.ApplyResources(tabPage1, "tabPage1");
			tabPage1.Name = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			groupBox1.Controls.Add(btnGenereatePascalTlb);
			groupBox1.Controls.Add(btnBrowseOutputDir);
			groupBox1.Controls.Add(txtOuptputDir);
			groupBox1.Controls.Add(label7);
			resources.ApplyResources(groupBox1, "groupBox1");
			groupBox1.Name = "groupBox1";
			groupBox1.TabStop = false;
			resources.ApplyResources(btnGenereatePascalTlb, "btnGenereatePascalTlb");
			btnGenereatePascalTlb.Name = "btnGenereatePascalTlb";
			btnGenereatePascalTlb.UseVisualStyleBackColor = true;
			btnGenereatePascalTlb.Click += new System.EventHandler(btnGenereatePascalTlb_Click);
			resources.ApplyResources(btnBrowseOutputDir, "btnBrowseOutputDir");
			btnBrowseOutputDir.Name = "btnBrowseOutputDir";
			btnBrowseOutputDir.UseVisualStyleBackColor = true;
			btnBrowseOutputDir.Click += new System.EventHandler(btnBrowseOutputDir_Click);
			resources.ApplyResources(txtOuptputDir, "txtOuptputDir");
			txtOuptputDir.Name = "txtOuptputDir";
			resources.ApplyResources(label7, "label7");
			label7.Name = "label7";
			cboDelphiVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboDelphiVersion.FormattingEnabled = true;
			resources.ApplyResources(cboDelphiVersion, "cboDelphiVersion");
			cboDelphiVersion.Name = "cboDelphiVersion";
			resources.ApplyResources(label5, "label5");
			label5.Name = "label5";
			resources.ApplyResources(btnClearDelphi, "btnClearDelphi");
			btnClearDelphi.Name = "btnClearDelphi";
			btnClearDelphi.UseVisualStyleBackColor = true;
			btnClearDelphi.Click += new System.EventHandler(btnClearDelphi_Click);
			tabPage2.Controls.Add(btnCheckSerailize);
			tabPage2.Controls.Add(btnCheckComVisible);
			resources.ApplyResources(tabPage2, "tabPage2");
			tabPage2.Name = "tabPage2";
			tabPage2.UseVisualStyleBackColor = true;
			resources.ApplyResources(btnCheckSerailize, "btnCheckSerailize");
			btnCheckSerailize.Name = "btnCheckSerailize";
			btnCheckSerailize.UseVisualStyleBackColor = true;
			btnCheckSerailize.Click += new System.EventHandler(btnCheckSerailize_Click);
			resources.ApplyResources(btnCheckComVisible, "btnCheckComVisible");
			btnCheckComVisible.Name = "btnCheckComVisible";
			btnCheckComVisible.UseVisualStyleBackColor = true;
			btnCheckComVisible.Click += new System.EventHandler(btnCheckComVisible_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(groupBox2);
			base.Controls.Add(myTabControl);
			base.MinimizeBox = false;
			base.Name = "dlgDCEnvirmentConfig";
			base.Load += new System.EventHandler(dlgDCEnvirmentConfig_Load);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			myTabControl.ResumeLayout(false);
			pageStart.ResumeLayout(false);
			pageCOM.ResumeLayout(false);
			pageCOM.PerformLayout();
			pageWebSite.ResumeLayout(false);
			pageWebSite.PerformLayout();
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			tabPage2.ResumeLayout(false);
			ResumeLayout(false);
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public dlgDCEnvirmentConfig()
		{
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
		}

		private void dlgDCEnvirmentConfig_Load(object sender, EventArgs e)
		{
			int num = 18;
			lblCurrentAssemblyFile.Text += GetType().Assembly.Location;
			method_0();
			string text = GClass37.smethod_0();
			if (text != null)
			{
				MessageBox.Show(null, text, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			string[] array = Class66.smethod_5();
			if (array != null && array.Length > 0)
			{
				cboDelphiVersion.Items.AddRange(array);
				cboDelphiVersion.SelectedIndex = 0;
			}
			Text = Text + " V:" + base.ProductVersion;
			gclass358_0 = new GClass358(txtLog);
			gclass358_0.method_5(bool_3: true);
			gclass358_0.method_1(bool_3: true);
			if (!Class50.smethod_0())
			{
				Text += " !!!";
			}
			txtOuptputDir.Text = DCSoftAppSettings.smethod_1("DelphiOutputDir");
		}

		protected override void OnClosing(CancelEventArgs cancelEventArgs_0)
		{
			DCSoftAppSettings.smethod_2("DelphiOutputDir", txtOuptputDir.Text);
			DCSoftAppSettings.smethod_3();
			base.OnClosing(cancelEventArgs_0);
		}

		private void method_0()
		{
			int num = 3;
			txtCurrentCOMPath.Text = GClass37.smethod_9(GetType().Assembly);
			if (!string.IsNullOrEmpty(txtCurrentCOMPath.Text))
			{
				string strA = Path.ChangeExtension(txtCurrentCOMPath.Text, "dll");
				if (string.Compare(strA, GetType().Assembly.Location, ignoreCase: true) != 0)
				{
					lblCurrentCOMPath.Invoke((EventHandler)delegate
					{
						lblCurrentCOMPath.Text += "应该不是当前程序集！！！";
					});
				}
			}
		}

		/// <summary>
		///       执行命令行
		///       </summary>
		public void ExecuteCommandLines()
		{
			int num = 18;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			string[] array = commandLineArgs;
			int num2 = 0;
			while (true)
			{
				if (num2 < array.Length)
				{
					string text = array[num2];
					if (string.Compare(text, "/i", ignoreCase: true) != 0)
					{
						if (string.Compare(text, "/fi", ignoreCase: true) != 0)
						{
							if (string.Compare(text, "/u", ignoreCase: true) != 0)
							{
								if (!text.StartsWith("/website:", StringComparison.CurrentCultureIgnoreCase))
								{
									if (string.Compare(text, "/wi", ignoreCase: true) == 0)
									{
										break;
									}
									num2++;
									continue;
								}
								SilentMode = true;
								string text2 = text.Substring(9);
								txtASMUrl.Text = text2;
								btnSetSite_Click(null, null);
								return;
							}
							SilentMode = true;
							btnUnRegAsm_Click(null, null);
							return;
						}
						SilentMode = true;
						btnRegAsmFast_Click(null, null);
						return;
					}
					SilentMode = true;
					btnRegAsm_Click(null, null);
					return;
				}
				Application.Run(this);
				return;
			}
			string text3 = Path.Combine(Path.GetTempPath(), "DCWriterLib_" + base.ProductVersion + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
			if (!Directory.Exists(text3))
			{
				Directory.CreateDirectory(text3);
			}
			FileHelper.CopyFolder(Application.StartupPath, text3, resetFileAttributes: true);
			string fileName = Path.Combine(text3, Path.GetFileName(Application.ExecutablePath));
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = fileName;
			processStartInfo.Arguments = "/i";
			processStartInfo.UseShellExecute = false;
			Process process = Process.Start(processStartInfo);
			process.WaitForExit();
		}

		/// <summary>
		///       注册COM接口
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		public void btnRegAsm_Click(object sender, EventArgs e)
		{
			RegAsmFast = false;
			method_1();
		}

		/// <summary>
		///       快速注册COM接口
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		private void btnRegAsmFast_Click(object sender, EventArgs e)
		{
			RegAsmFast = true;
			method_1();
		}

		public void method_1()
		{
			using (dlgSingleProgress dlgSingleProgress = new dlgSingleProgress())
			{
				dlgSingleProgress.EventDoWork = method_2;
				dlgSingleProgress.DoWorkEventSender = dlgSingleProgress;
				dlgSingleProgress.ShowDialog(this);
			}
		}

		private void method_2(object sender, EventArgs e)
		{
			GClass37 gClass = new GClass37();
			gClass.method_1(SilentMode);
			_ = GetType().Assembly;
			Control control = sender as Control;
			if (control == null)
			{
				control = this;
			}
			if (!RegAsmFast)
			{
				if (gClass.method_6(control, bool_1: true) && !SilentMode)
				{
					method_0();
				}
			}
			else if (gClass.method_6(control, bool_1: false) && !SilentMode)
			{
				method_0();
			}
		}

		public void method_3(object sender, EventArgs e)
		{
			GClass37 gClass = new GClass37();
			gClass.method_1(SilentMode);
			gClass.method_4(this, bool_1: false);
		}

		/// <summary>
		///       注销COM接口
		///       </summary>
		/// <param name="sender">
		/// </param>
		/// <param name="e">
		/// </param>
		public void btnUnRegAsm_Click(object sender, EventArgs e)
		{
			int num = 19;
			using (dlgSingleProgress dlgSingleProgress = new dlgSingleProgress())
			{
				dlgSingleProgress.EventDoWork = method_3;
				dlgSingleProgress.DoWorkEventSender = dlgSingleProgress;
				dlgSingleProgress.UserMessage = "注销COM接口，请稍候……";
				dlgSingleProgress.ShowDialog(this);
			}
		}

		private void btnSetSite_Click(object sender, EventArgs e)
		{
			method_5(0);
		}

		private void method_4(object sender, EventArgs e)
		{
			method_5(1);
		}

		public void method_5(int int_0)
		{
			int num = 17;
			string text = txtASMUrl.Text.Trim();
			if (text.Length == 0)
			{
				if (!SilentMode)
				{
					MessageBox.Show(this, WriterStrings.PromptInputURL);
				}
			}
			else
			{
				GClass37 gClass = new GClass37();
				gClass.method_1(SilentMode);
				Assembly assembly = GetType().Assembly;
				try
				{
					if (!SilentMode)
					{
						Cursor = Cursors.WaitCursor;
					}
					if (gClass.method_10(this, "iexplore"))
					{
						if (int_0 == 0 && !gClass.method_18(assembly.Location, text) && !SilentMode)
						{
							MessageBox.Show(this, string.Format(WriterStrings.FailValidateContent_URL, text), WriterStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						if (!gClass.method_11() && !SilentMode)
						{
							MessageBox.Show(this, WriterStrings.FailSetFullTrust, WriterStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						if (!gClass.method_12(text) && !SilentMode)
						{
							MessageBox.Show(this, string.Format(WriterStrings.FailSetTrustSite_Url, text), WriterStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						gClass.method_9();
						if (!SilentMode)
						{
							MessageBox.Show(this, string.Format(WriterStrings.SucccessSetSite_Site, text), WriterStrings.SystemAlert);
						}
					}
				}
				catch (Exception ex)
				{
					if (!SilentMode)
					{
						MessageBox.Show(this, string.Format(WriterStrings.PromptErrAndWin7_MSG, ex.Message), WriterStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				finally
				{
					if (!SilentMode)
					{
						Cursor = Cursors.Default;
					}
				}
			}
		}

		private void btnToWeb_Click(object sender, EventArgs e)
		{
			myTabControl.SelectedTab = pageWebSite;
		}

		private void btnToCOM_Click(object sender, EventArgs e)
		{
			myTabControl.SelectedTab = pageCOM;
		}

		private void btnClearDelphi_Click(object sender, EventArgs e)
		{
			int num = 19;
			if (!string.IsNullOrEmpty(cboDelphiVersion.Text))
			{
				GClass37 gClass = new GClass37();
				gClass.method_1(SilentMode);
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

		private void btnGenereatePascalTlb_Click(object sender, EventArgs e)
		{
			int num = 6;
			using (dlgSingleProgress dlgSingleProgress = new dlgSingleProgress())
			{
				dlgSingleProgress.EventDoWork = method_6;
				dlgSingleProgress.DoWorkEventSender = dlgSingleProgress;
				dlgSingleProgress.UserMessage = "正在处理DELPHI输出文件，请稍候……";
				dlgSingleProgress.ShowDialog(this);
			}
		}

		private void method_6(object sender, EventArgs e)
		{
			int num = 3;
			string text = Path.ChangeExtension(GetType().Assembly.Location, "tlb");
			if (!File.Exists(text))
			{
				MessageBox.Show(string.Format(WriterStrings.PromptGenerateDCWriterTlb_FileName, text));
			}
			else if (!string.IsNullOrEmpty(cboDelphiVersion.Text))
			{
				string text2 = txtOuptputDir.Text.Trim();
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				Cursor = Cursors.WaitCursor;
				GClass37 gClass = new GClass37();
				gClass.method_10(this, "tlibimp.exe");
				Class66.smethod_6(cboDelphiVersion.Text, text, text2, bool_0: false);
				Cursor = Cursors.Default;
			}
		}

		private void btnRegASMandExit_Click(object sender, EventArgs e)
		{
			method_1();
			Close();
		}

		private void btnIEDebugFile_Click(object sender, EventArgs e)
		{
			int num = 3;
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "*.txt|*.txt";
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.OverwritePrompt = true;
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					string fileName = saveFileDialog.FileName;
					bool bool_ = true;
					if (IntPtr.Size == 4)
					{
						bool_ = true;
					}
					else if (IntPtr.Size == 8)
					{
						bool_ = false;
					}
					method_7(bool_, fileName);
				}
			}
		}

		private void method_7(bool bool_3, string string_0)
		{
			int num = 12;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Windows Registry Editor Version 5.00").Append("\r\n");
			if (bool_3)
			{
				stringBuilder.Append("[HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\.NETFramework]").Append("\r\n");
			}
			else
			{
				stringBuilder.Append("[HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\.NETFramework]").Append("\r\n");
			}
			stringBuilder.Append("\"DebugIEHost\"=dword:1").Append("\r\n");
			stringBuilder.Append("\"EnableIEHosting\"=dword:1").Append("\r\n");
			stringBuilder.Append("\"IEHostLogFile\"=\"" + string_0 + "\"");
			string text = stringBuilder.ToString();
			using (FileStream fileStream = new FileStream(Application.StartupPath + "\\reg.reg", FileMode.Create, FileAccess.ReadWrite))
			{
				byte[] bytes = Encoding.ASCII.GetBytes(text);
				fileStream.Write(bytes, 0, text.Length);
			}
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "cmd.exe";
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardInput = true;
			processStartInfo.RedirectStandardOutput = true;
			process.StartInfo = processStartInfo;
			process.Start();
			string value = "\"" + Path.Combine(Application.StartupPath, "reg.reg") + "\"";
			process.StandardInput.WriteLine(value);
			process.StandardInput.WriteLine("exit");
		}

		private void btnCheckComVisible_Click(object sender, EventArgs e)
		{
			int num = 12;
			List<Type> list = new List<Type>(typeof(AxWriterControl).Assembly.GetTypes());
			list.Sort(new Class27());
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			StringBuilder stringBuilder3 = new StringBuilder();
			StringBuilder stringBuilder4 = new StringBuilder();
			List<string> list2 = new List<string>();
			foreach (Type item in list)
			{
				if (item != typeof(AxWriterControlForPB))
				{
				}
				if (!(item.Namespace == "DCSoft.WMPLib"))
				{
					if (!item.Equals(typeof(GClass109.GClass110)))
					{
					}
					if (item.IsPublic || item.IsNestedPublic)
					{
						ComVisibleAttribute comVisibleAttribute = (ComVisibleAttribute)Attribute.GetCustomAttribute(item, typeof(ComVisibleAttribute), inherit: false);
						if (comVisibleAttribute == null)
						{
							stringBuilder3.AppendLine(item.FullName);
						}
						if (comVisibleAttribute == null || comVisibleAttribute.Value)
						{
							if (item.Namespace == "DCSoftDotfuscate")
							{
								stringBuilder4.AppendLine("!!!" + item.FullName);
							}
							ObfuscationAttribute obfuscationAttribute = (ObfuscationAttribute)Attribute.GetCustomAttribute(item, typeof(ObfuscationAttribute), inherit: false);
							if (obfuscationAttribute == null)
							{
								if (!XTextDocument.IsAssemblyObfuscation)
								{
									stringBuilder4.AppendLine(item.FullName);
								}
							}
							else if (!obfuscationAttribute.Exclude)
							{
								stringBuilder4.AppendLine("False:" + item.FullName);
							}
						}
					}
					GuidAttribute guidAttribute = (GuidAttribute)Attribute.GetCustomAttribute(item, typeof(GuidAttribute), inherit: true);
					if (guidAttribute != null)
					{
						string value = guidAttribute.Value;
						if (string.IsNullOrEmpty(value))
						{
							stringBuilder.AppendLine("-----" + item.FullName);
						}
						else
						{
							if (list2.Contains(value))
							{
								stringBuilder.AppendLine("重复的GUID：" + item.FullName);
							}
							else
							{
								list2.Add(value);
							}
							try
							{
								Guid guid = new Guid(value);
							}
							catch (Exception ex)
							{
								stringBuilder2.AppendLine(item.FullName + " " + ex.Message);
							}
						}
					}
					bool flag = Attribute.GetCustomAttribute(item, typeof(DCPublishAPIAttribute), inherit: true) != null;
					ComVisibleAttribute comVisibleAttribute2 = (ComVisibleAttribute)Attribute.GetCustomAttribute(item, typeof(ComVisibleAttribute), inherit: true);
					if (comVisibleAttribute2 != null && comVisibleAttribute2.Value && !flag && !item.IsInterface)
					{
						stringBuilder.AppendLine(item.FullName + "内部类型，无需ComVisibleAttribute");
					}
					if (comVisibleAttribute2 != null && comVisibleAttribute2.Value && guidAttribute == null)
					{
						stringBuilder2.AppendLine(item.FullName);
					}
					if (comVisibleAttribute2 != null && comVisibleAttribute2.Value && !(((ObfuscationAttribute)Attribute.GetCustomAttribute(item, typeof(ObfuscationAttribute), inherit: false))?.Exclude ?? false))
					{
						stringBuilder.AppendLine(item.FullName + " 需要 ObfuscationAttributeAttribute");
					}
					if (flag && !item.IsInterface)
					{
						ObfuscationAttribute obfuscationAttribute2 = (ObfuscationAttribute)Attribute.GetCustomAttribute(item, typeof(ObfuscationAttribute), inherit: false);
						if (obfuscationAttribute2 == null || !obfuscationAttribute2.Exclude || !obfuscationAttribute2.ApplyToMembers)
						{
							bool flag2 = false;
							MemberInfo[] members = item.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
							foreach (MemberInfo memberInfo in members)
							{
								comVisibleAttribute2 = (ComVisibleAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(ComVisibleAttribute), inherit: true);
								if (comVisibleAttribute2 != null && comVisibleAttribute2.Value && !(((ObfuscationAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(ObfuscationAttribute), inherit: false))?.Exclude ?? false))
								{
									if (!flag2)
									{
										flag2 = true;
										stringBuilder.AppendLine("对于类型 " + item.FullName + "以下成员需要 ObfuscationAttributeAttribute");
									}
									stringBuilder.AppendLine("    " + memberInfo.Name);
								}
							}
						}
					}
				}
			}
			if (stringBuilder3.Length > 0)
			{
				stringBuilder.AppendLine("以下类型可能需要 ComVisibleAttribute");
				stringBuilder.AppendLine(stringBuilder3.ToString());
			}
			if (stringBuilder4.Length > 0)
			{
				stringBuilder.AppendLine("以下类型可能需要 ObfuscationAttribute");
				stringBuilder.AppendLine(stringBuilder4.ToString());
			}
			if (stringBuilder2.Length > 0)
			{
				stringBuilder.AppendLine("以下类型可能需要 GuidAttribute");
				stringBuilder.AppendLine(stringBuilder2.ToString());
			}
			stringBuilder.AppendLine(method_9(list));
			string text = stringBuilder.ToString();
			if (string.IsNullOrEmpty(text))
			{
				Clipboard.Clear();
				MessageBox.Show("无任何信息.");
			}
			else
			{
				Clipboard.SetText(text);
				MessageBox.Show((text.Length > 1000) ? text.Substring(0, 1000) : text);
			}
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			using (dlgAbout dlgAbout = new dlgAbout())
			{
				dlgAbout.ShowDialog(this);
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

		private void btnClearReg_Click(object sender, EventArgs e)
		{
			int num = 14;
			using (dlgSingleProgress dlgSingleProgress = new dlgSingleProgress())
			{
				dlgSingleProgress.EventDoWork = method_8;
				dlgSingleProgress.DoWorkEventSender = dlgSingleProgress;
				dlgSingleProgress.UserMessage = "清理注册表，请稍候……";
				dlgSingleProgress.ShowDialog(this);
			}
		}

		private void method_8(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			int num = GClass37.smethod_1();
			Cursor = Cursors.Default;
			MessageBox.Show("共清理了 " + num + " 处数据");
		}

		private void btnDelphiWinzard_Click(object sender, EventArgs e)
		{
			Hide();
			using (dlgDelphiUpdate dlgDelphiUpdate = new dlgDelphiUpdate())
			{
				dlgDelphiUpdate.ShowInTaskbar = true;
				if (base.Owner != null)
				{
					dlgDelphiUpdate.ShowDialog(base.Owner);
				}
				else
				{
					dlgDelphiUpdate.ShowDialog();
				}
			}
			Show();
		}

		private void btnGenerateCAB_Click(object sender, EventArgs e)
		{
			int num = 7;
			byte[] array = WebWriterControl.smethod_0();
			if (array != null && array.Length > 0)
			{
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "*.cab|*.cab";
					saveFileDialog.CheckPathExists = true;
					saveFileDialog.OverwritePrompt = true;
					if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
					{
						File.WriteAllBytes(saveFileDialog.FileName, array);
					}
				}
			}
		}

		private string method_9(List<Type> list_0)
		{
			int num = 9;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Type item in list_0)
			{
				ObfuscationAttribute obfuscationAttribute = (ObfuscationAttribute)Attribute.GetCustomAttribute(item, typeof(ObfuscationAttribute), inherit: true);
				if (obfuscationAttribute?.Exclude ?? false)
				{
					if (obfuscationAttribute.ApplyToMembers)
					{
						if (!item.IsSubclassOf(typeof(Delegate)) && !item.IsSubclassOf(typeof(UITypeEditor)) && !item.IsSubclassOf(typeof(Attribute)) && !item.IsEnum && !item.IsInterface)
						{
							stringBuilder.AppendLine("全部开放:" + item.FullName);
						}
					}
					else
					{
						bool flag = false;
						MemberInfo[] members = item.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
						foreach (MemberInfo memberInfo in members)
						{
							if (!(memberInfo is MethodInfo) || (!memberInfo.Name.StartsWith("get_") && !memberInfo.Name.StartsWith("set_") && !memberInfo.Name.StartsWith("add_") && !memberInfo.Name.StartsWith("remove_")))
							{
								try
								{
									obfuscationAttribute = (ObfuscationAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(ObfuscationAttribute), inherit: true);
								}
								catch (Exception ex)
								{
									MessageBox.Show(item.FullName + "." + memberInfo.Name + "\r\n" + ex.Message);
								}
								if (obfuscationAttribute != null && obfuscationAttribute.Exclude && !obfuscationAttribute.ApplyToMembers)
								{
									if (!flag)
									{
										flag = true;
										stringBuilder.AppendLine(item.FullName + " 需要检查类型成员");
									}
									stringBuilder.AppendLine("   " + memberInfo.Name);
								}
							}
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		private void btnCheckSerailize_Click(object sender, EventArgs e)
		{
			string text = GClass369.smethod_0(GetType().Assembly);
			Clipboard.SetText(text);
			MessageBox.Show(text);
		}

		[CompilerGenerated]
		private void method_10(object sender, EventArgs e)
		{
			lblCurrentCOMPath.Text += "应该不是当前程序集！！！";
		}
	}
}
