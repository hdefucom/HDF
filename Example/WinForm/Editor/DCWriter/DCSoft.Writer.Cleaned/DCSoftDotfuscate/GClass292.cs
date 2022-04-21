#define DEBUG
using DCSoft.Common;
using DCSoft.WinForms;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public class GClass292
	{
		private static GClass292 gclass292_0 = null;

		private bool bool_0 = false;

		private bool bool_1 = false;

		private string string_0 = null;

		private Control control_0 = null;

		private Assembly assembly_0 = null;

		private bool bool_2 = false;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private int int_0 = 10000;

		private Timer timer_0 = null;

		public static GClass292 smethod_0()
		{
			if (gclass292_0 == null)
			{
				gclass292_0 = new GClass292();
			}
			return gclass292_0;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_5)
		{
			bool_0 = bool_5;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			if (string_0 != string_1)
			{
				string_0 = string_1;
				bool_1 = false;
			}
		}

		public Control method_4()
		{
			return control_0;
		}

		public void method_5(Control control_1)
		{
			control_0 = control_1;
		}

		public Assembly method_6()
		{
			return assembly_0;
		}

		public void method_7(Assembly assembly_1)
		{
			assembly_0 = assembly_1;
		}

		public bool method_8()
		{
			return bool_2;
		}

		public void method_9(bool bool_5)
		{
			bool_2 = bool_5;
		}

		public bool method_10()
		{
			return bool_3;
		}

		public void method_11(bool bool_5)
		{
			bool_3 = bool_5;
		}

		public bool method_12()
		{
			return bool_4;
		}

		public void method_13(bool bool_5)
		{
			bool_4 = bool_5;
		}

		public int method_14()
		{
			return int_0;
		}

		public void method_15(int int_1)
		{
			int_0 = int_1;
		}

		public void method_16()
		{
			int num = 5;
			if (method_0())
			{
				MessageBox.Show("Start:" + method_2());
			}
			if (method_14() <= 0)
			{
				method_18();
				return;
			}
			if (timer_0 == null)
			{
				timer_0 = new Timer();
				timer_0.Tick += timer_0_Tick;
				timer_0.Interval = method_14();
			}
			timer_0.Start();
		}

		public void method_17()
		{
			if (timer_0 != null)
			{
				timer_0.Stop();
				timer_0.Dispose();
				timer_0 = null;
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (timer_0 != null)
			{
				timer_0.Stop();
				timer_0.Dispose();
				timer_0 = null;
			}
			method_18();
		}

		public bool method_18()
		{
			int num = 6;
			if (bool_1)
			{
				return false;
			}
			bool_1 = true;
			if (string.IsNullOrEmpty(method_2()))
			{
				return false;
			}
			Control control = method_4();
			while (control != null && !control.IsHandleCreated)
			{
				control = control.Parent;
			}
			if (control == null)
			{
				control = method_4();
			}
			if (control != null && control.IsDisposed)
			{
				return false;
			}
			if (method_0())
			{
				MessageBox.Show("下载地址:" + method_2());
			}
			string text = method_2();
			int num2 = text.IndexOf("#");
			if (num2 < 0)
			{
				return false;
			}
			string text2 = text.Substring(0, num2);
			string text3 = text.Substring(num2 + 1);
			num2 = text3.IndexOf("=");
			if (num2 >= 0)
			{
				text3 = text3.Substring(num2 + 1);
			}
			text3 = text3.Replace(",", ".").Trim();
			Version version = new Version(text3);
			Assembly assembly = method_6();
			if (assembly == null)
			{
				if (method_4() != null)
				{
					assembly = method_4().GetType().Assembly;
				}
				if (assembly == null)
				{
					assembly = Assembly.GetExecutingAssembly();
				}
			}
			Version version2 = assembly.GetName().Version;
			if (version2 == version)
			{
				if (method_0())
				{
					MessageBox.Show("版本号都是 " + version.ToString() + " ，不更新");
				}
				return false;
			}
			if (method_12() && method_10())
			{
				string text4 = string.Format(WinFormsResources.AlertUpdate_OldVersion_NewVersion, version2, version);
				if (MessageBox.Show(control, text4, WinFormsResources.SystemAlert, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					return false;
				}
			}
			num2 = text2.LastIndexOf("/");
			string path = assembly.GetName().Name + version.ToString();
			path = Path.Combine(Path.GetTempPath(), path);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			using (WebClient webClient = new WebClient())
			{
				try
				{
					webClient.DownloadFile(text2, path);
					string text4 = "远程地址:" + text2 + "\r\n本地文件名:" + path;
					Debug.WriteLine(text4);
					if (method_0())
					{
						MessageBox.Show(control, text4);
					}
				}
				catch (Exception ex)
				{
					if (method_0())
					{
						MessageBox.Show(ex.ToString());
					}
					Debug.WriteLine(ex.Message);
					return false;
				}
			}
			byte[] byte_ = FileHelper.ReadFileHeader(path, 10);
			if (GClass339.smethod_2(byte_))
			{
				if (method_0())
				{
					MessageBox.Show("检测到CAB文件");
				}
				string text5 = path + ".expand";
				try
				{
					if (Directory.Exists(text5))
					{
						Directory.Delete(text5, recursive: true);
					}
					Directory.CreateDirectory(text5);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					text5 = path + ".expend" + Environment.TickCount;
					if (Directory.Exists(text5))
					{
						Directory.Delete(text5, recursive: true);
					}
					Directory.CreateDirectory(text5);
				}
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.UseShellExecute = true;
				processStartInfo.FileName = "expand.exe";
				processStartInfo.Arguments = "-F:* \"" + path + "\" \"" + text5 + "\"";
				Process process = Process.Start(processStartInfo);
				process.WaitForExit();
				process.Dispose();
				path = null;
				string[] files = Directory.GetFiles(text5);
				foreach (string text6 in files)
				{
					ProcessStartInfo processStartInfo2 = null;
					if (!text6.EndsWith(".inf", StringComparison.CurrentCultureIgnoreCase))
					{
						continue;
					}
					using (StreamReader streamReader = new StreamReader(text6, Encoding.Default, detectEncodingFromByteOrderMarks: true))
					{
						for (string text7 = streamReader.ReadLine(); text7 != null; text7 = streamReader.ReadLine())
						{
							if (text7.StartsWith("run=", StringComparison.CurrentCultureIgnoreCase))
							{
								string text8 = text7.Substring(4).Trim();
								int num3 = text8.IndexOf(" ");
								processStartInfo2 = new ProcessStartInfo();
								if (num3 > 0)
								{
									processStartInfo2.FileName = text8.Substring(0, num3);
									processStartInfo2.Arguments = text8.Substring(num3 + 1).Trim();
								}
								else
								{
									processStartInfo2.FileName = text8;
								}
								processStartInfo2.FileName = processStartInfo2.FileName.Replace("%EXTRACT_DIR%", text5);
								if (processStartInfo2.FileName.StartsWith("\"") && processStartInfo2.FileName.EndsWith("\""))
								{
									processStartInfo2.FileName = processStartInfo2.FileName.Substring(1, processStartInfo2.FileName.Length - 2);
								}
								processStartInfo2.UseShellExecute = true;
								break;
							}
						}
					}
					if (processStartInfo2 != null)
					{
						if (method_0())
						{
							MessageBox.Show(control, "执行命令 " + processStartInfo2.FileName + " " + processStartInfo2.Arguments);
						}
						Process process2 = Process.Start(processStartInfo2);
						if (method_8())
						{
							process2.WaitForExit();
						}
						if (method_12())
						{
							MessageBox.Show(control, WinFormsResources.PromptUpdateAssembly, WinFormsResources.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						return true;
					}
				}
				files = Directory.GetFiles(text5);
				foreach (string text6 in files)
				{
					if (text6.EndsWith(".exe", StringComparison.CurrentCultureIgnoreCase))
					{
						path = text6;
						break;
					}
				}
				if (path == null)
				{
					return false;
				}
			}
			ProcessStartInfo processStartInfo3 = new ProcessStartInfo();
			processStartInfo3.FileName = path;
			processStartInfo3.UseShellExecute = false;
			if (method_0())
			{
				MessageBox.Show(control, "执行命令 " + processStartInfo3.FileName + " " + processStartInfo3.Arguments);
			}
			Process process3 = Process.Start(processStartInfo3);
			if (method_8())
			{
				process3.WaitForExit();
			}
			if (method_12())
			{
				MessageBox.Show(control, WinFormsResources.PromptUpdateAssembly, WinFormsResources.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return true;
		}
	}
}
