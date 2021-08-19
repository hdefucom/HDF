using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       运行环境信息对话框
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class dlgEnvironmentInfo : Form
	{
		private IContainer icontainer_0 = null;

		private TextBox txtInfo;

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		public dlgEnvironmentInfo()
		{
			InitializeComponent();
		}

		private void dlgEnvironmentInfo_Load(object sender, EventArgs e)
		{
			int num = 15;
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				stringBuilder.AppendLine("运行时版本：" + Environment.Version.ToString());
				stringBuilder.AppendLine("命令行    ：" + Environment.CommandLine);
				stringBuilder.AppendLine("当前目录  ：" + Environment.CurrentDirectory);
				stringBuilder.AppendLine("操作系统  ：" + Environment.OSVersion.ToString());
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (executingAssembly != null)
				{
					stringBuilder.AppendLine("当前程序集：" + executingAssembly.Location);
				}
				Process currentProcess = Process.GetCurrentProcess();
				if (currentProcess != null)
				{
					stringBuilder.AppendLine("占用物理内存：" + FileHelper.FormatByteSize((int)currentProcess.WorkingSet64));
					stringBuilder.AppendLine("占用虚拟内存：" + FileHelper.FormatByteSize((int)currentProcess.VirtualMemorySize64));
				}
				stringBuilder.AppendLine("--------- 加载的程序集 ---------------");
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					stringBuilder.AppendLine(assembly.FullName);
					stringBuilder.AppendLine("    CodeBase    ：" + assembly.CodeBase);
					stringBuilder.AppendLine("    Location    ：" + assembly.Location);
					stringBuilder.AppendLine("    全局缓存    ：" + assembly.GlobalAssemblyCache);
					stringBuilder.AppendLine("    ImageRuntime：" + assembly.ImageRuntimeVersion);
					stringBuilder.AppendLine();
				}
			}
			catch (Exception ex)
			{
				stringBuilder.AppendLine(ex.Message);
			}
			txtInfo.Text = stringBuilder.ToString();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCSoft.Common.dlgEnvironmentInfo));
			txtInfo = new System.Windows.Forms.TextBox();
			SuspendLayout();
			resources.ApplyResources(txtInfo, "txtInfo");
			txtInfo.Name = "txtInfo";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(txtInfo);
			base.MinimizeBox = false;
			base.Name = "dlgEnvironmentInfo";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Load += new System.EventHandler(dlgEnvironmentInfo_Load);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
