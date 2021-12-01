#define DEBUG
using DCSoft.Common;
using DCSoft.WinForms;
using DCSoft.Writer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass37
	{
		private static string string_0;

		private bool bool_0 = false;

		private static string[] string_1;

		static GClass37()
		{
			string_0 = null;
			string_1 = null;
			GuidAttribute guidAttribute = (GuidAttribute)Attribute.GetCustomAttribute(typeof(GClass37).Assembly, typeof(GuidAttribute));
			if (guidAttribute != null)
			{
				string_0 = guidAttribute.Value;
			}
		}

		public static string smethod_0()
		{
			return WriterUtils.CheckNET20SP2(throwException: false);
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public bool method_2()
		{
			return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 1;
		}

		public bool method_3()
		{
			return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1;
		}

		public static int smethod_1()
		{
			int num = 8;
			int num2 = 0;
			num2 = 0 + smethod_6(Registry.ClassesRoot);
			num2 += smethod_2(Registry.ClassesRoot.OpenSubKey("CLSID", writable: true), bool_1: true);
			num2 += smethod_2(Registry.ClassesRoot.OpenSubKey("Interface", writable: true), bool_1: true);
			num2 += smethod_2(Registry.ClassesRoot.OpenSubKey("Record", writable: true), bool_1: true);
			num2 += smethod_2(Registry.ClassesRoot.OpenSubKey("TypeLib", writable: true), bool_1: true);
			num2 += smethod_2(Registry.ClassesRoot.OpenSubKey("Wow6432Node\\Interface", writable: true), bool_1: true);
			num2 += smethod_2(Registry.ClassesRoot.OpenSubKey("Wow6432Node\\TypeLib", writable: true), bool_1: true);
			num2 += smethod_2(Registry.ClassesRoot.OpenSubKey("Wow6432Node\\CLSID", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\CLSID", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Interface", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Record", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\TypeLib", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Wow6432Node\\CLSID", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Wow6432Node\\Interface", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Wow6432Node\\TypeLib", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Classes\\CLSID", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Classes\\Interface", writable: true), bool_1: true);
			num2 += smethod_2(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Classes\\TypeLib", writable: true), bool_1: true);
			num2 += smethod_2(Registry.CurrentUser.OpenSubKey("Software\\Borland\\Delphi", writable: true), bool_1: true);
			num2 += smethod_2(Registry.CurrentUser.OpenSubKey("Software\\Embarcadero\\BDS", writable: true), bool_1: true);
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Volatile\\00\\MACHINE\\SOFTWARE\\Classes\\Wow6432Node\\CLSID\\{6BF52A52-394A-11D3-B153-00C04F79FAA6}\\InprocServer32", writable: true);
			if (registryKey != null)
			{
				string[] subKeyNames = registryKey.GetSubKeyNames();
				if (subKeyNames != null && subKeyNames.Length > 0)
				{
					string[] array = subKeyNames;
					foreach (string text in array)
					{
						RegistryKey registryKey2 = registryKey.OpenSubKey(text, writable: false);
						string text2 = Convert.ToString(registryKey2.GetValue("Assembly"));
						registryKey2.Close();
						if (text2 != null && text2.IndexOf("DCSoft.", StringComparison.CurrentCultureIgnoreCase) >= 0)
						{
							try
							{
								registryKey.DeleteSubKeyTree(text);
								num2++;
							}
							catch
							{
							}
						}
					}
				}
			}
			return num2;
		}

		private static int smethod_2(RegistryKey registryKey_0, bool bool_1)
		{
			int num = 0;
			if (registryKey_0 == null)
			{
				return 0;
			}
			int result = 0;
			if (registryKey_0.Name.EndsWith("\\TypeLib"))
			{
				result = smethod_3(registryKey_0);
			}
			else if (registryKey_0.Name.EndsWith("\\Interface"))
			{
				result = smethod_8(registryKey_0);
			}
			else if (registryKey_0.Name.EndsWith("\\Classes") || registryKey_0.Name.EndsWith("\\CLSID"))
			{
				result = smethod_6(registryKey_0);
			}
			else if (registryKey_0.Name.EndsWith("\\Delphi") || registryKey_0.Name.EndsWith("\\BDS"))
			{
				result = smethod_5(registryKey_0);
			}
			else if (registryKey_0.Name.EndsWith("\\Record"))
			{
				result = smethod_4(registryKey_0);
			}
			if (bool_1)
			{
				registryKey_0.Close();
			}
			return result;
		}

		private static int smethod_3(RegistryKey registryKey_0)
		{
			int num = 1;
			int num2 = 0;
			string[] subKeyNames = registryKey_0.GetSubKeyNames();
			if (subKeyNames != null && subKeyNames.Length > 0)
			{
				string[] array = subKeyNames;
				foreach (string text in array)
				{
					try
					{
						RegistryKey registryKey = registryKey_0.OpenSubKey(text, writable: false);
						bool flag = false;
						string[] subKeyNames2 = registryKey.GetSubKeyNames();
						if (subKeyNames != null && subKeyNames.Length > 0)
						{
							string[] array2 = subKeyNames2;
							foreach (string name in array2)
							{
								RegistryKey registryKey2 = registryKey.OpenSubKey(name, writable: true);
								if (registryKey2 != null)
								{
									string text2 = Convert.ToString(registryKey2.GetValue(null));
									registryKey2.Close();
									if (text2 != null && text2.IndexOf("DCSoft.") >= 0)
									{
										flag = true;
										break;
									}
								}
							}
						}
						registryKey.Close();
						if (flag)
						{
							registryKey_0.DeleteSubKeyTree(text);
							num2++;
						}
					}
					catch
					{
					}
				}
			}
			return num2;
		}

		private static int smethod_4(RegistryKey registryKey_0)
		{
			int num = 18;
			int num2 = 0;
			string[] subKeyNames = registryKey_0.GetSubKeyNames();
			if (subKeyNames != null && subKeyNames.Length > 0)
			{
				string[] array = subKeyNames;
				foreach (string text in array)
				{
					try
					{
						RegistryKey registryKey = registryKey_0.OpenSubKey(text, writable: false);
						string[] subKeyNames2 = registryKey.GetSubKeyNames();
						bool flag = false;
						if (subKeyNames2 != null && subKeyNames2.Length > 0)
						{
							string[] array2 = subKeyNames2;
							foreach (string name in array2)
							{
								RegistryKey registryKey2 = registryKey.OpenSubKey(name, writable: false);
								string text2 = Convert.ToString(registryKey2.GetValue("Assembly"));
								if (text2 != null && text2.IndexOf("DCSoft.") >= 0)
								{
									flag = true;
									registryKey2.Close();
									break;
								}
								text2 = Convert.ToString(registryKey2.GetValue("Class"));
								if (text2 != null && text2.IndexOf("DCSoft.") >= 0)
								{
									flag = true;
									registryKey2.Close();
									break;
								}
							}
						}
						registryKey.Close();
						if (flag)
						{
							registryKey_0.DeleteSubKeyTree(text);
							num2++;
						}
					}
					catch
					{
					}
				}
			}
			return num2;
		}

		private static int smethod_5(RegistryKey registryKey_0)
		{
			int num = 14;
			int num2 = 0;
			string[] subKeyNames = registryKey_0.GetSubKeyNames();
			if (subKeyNames != null && subKeyNames.Length > 0)
			{
				string[] array = subKeyNames;
				foreach (string str in array)
				{
					RegistryKey registryKey = registryKey_0.OpenSubKey(str + "\\Known Packages", writable: true);
					if (registryKey != null)
					{
						string[] valueNames = registryKey.GetValueNames();
						if (valueNames != null && valueNames.Length > 0)
						{
							string[] array2 = valueNames;
							foreach (string text in array2)
							{
								if (text.IndexOf("dcsoft_", StringComparison.CurrentCultureIgnoreCase) >= 0)
								{
									registryKey.DeleteValue(text);
									num2++;
								}
							}
						}
						registryKey.Close();
					}
					RegistryKey registryKey2 = registryKey_0.OpenSubKey(str + "\\Package Cache", writable: true);
					string[] subKeyNames2;
					if (registryKey2 != null)
					{
						subKeyNames2 = registryKey2.GetSubKeyNames();
						if (subKeyNames2 != null && subKeyNames2.Length > 0)
						{
							string[] array2 = subKeyNames2;
							foreach (string text2 in array2)
							{
								if (text2.IndexOf("dcsoft_", StringComparison.CurrentCultureIgnoreCase) >= 0)
								{
									registryKey2.DeleteSubKeyTree(text2);
									num2++;
								}
							}
						}
						registryKey2.Close();
					}
					RegistryKey registryKey3 = registryKey_0.OpenSubKey(str + "\\Palette\\Cache", writable: true);
					if (registryKey3 == null)
					{
						continue;
					}
					subKeyNames2 = registryKey3.GetSubKeyNames();
					if (subKeyNames2 != null && subKeyNames2.Length > 0)
					{
						string[] array2 = subKeyNames2;
						foreach (string text2 in array2)
						{
							if (text2.IndexOf("dcsoft_", StringComparison.CurrentCultureIgnoreCase) >= 0)
							{
								registryKey3.DeleteSubKeyTree(text2);
								num2++;
							}
						}
					}
					registryKey3.Close();
				}
			}
			return num2;
		}

		private static int smethod_6(RegistryKey registryKey_0)
		{
			int num = 11;
			int num2 = 0;
			string[] subKeyNames = registryKey_0.GetSubKeyNames();
			if (subKeyNames != null && subKeyNames.Length > 0)
			{
				string[] array = subKeyNames;
				foreach (string text in array)
				{
					if (text.StartsWith("DCSoft.") || text.StartsWith("DCSoftDotfuscate."))
					{
						registryKey_0.DeleteSubKeyTree(text);
						num2++;
					}
					else
					{
						if (string.IsNullOrEmpty(string_0))
						{
							continue;
						}
						RegistryKey registryKey = registryKey_0.OpenSubKey(text + "\\TypeLib", writable: false);
						if (registryKey != null)
						{
							string text2 = Convert.ToString(registryKey.GetValue(null));
							registryKey.Close();
							if (text2 != null && text2.IndexOf(string_0, StringComparison.CurrentCultureIgnoreCase) >= 0)
							{
								registryKey_0.DeleteSubKeyTree(text);
								num2++;
							}
						}
					}
				}
			}
			return num2;
		}

		private static string[] smethod_7()
		{
			if (string_1 == null)
			{
				Type[] types = typeof(GClass37).Assembly.GetTypes();
				List<string> list = new List<string>();
				Type[] array = types;
				foreach (Type type in array)
				{
					list.Add(type.Name);
				}
				string_1 = list.ToArray();
			}
			return string_1;
		}

		private static int smethod_8(RegistryKey registryKey_0)
		{
			int num = 16;
			typeof(GClass37).Assembly.GetTypes();
			int num2 = 0;
			string[] subKeyNames = registryKey_0.GetSubKeyNames();
			if (subKeyNames != null && subKeyNames.Length > 0)
			{
				string[] array = subKeyNames;
				foreach (string text in array)
				{
					RegistryKey registryKey = registryKey_0.OpenSubKey(text, writable: false);
					string text2 = Convert.ToString(registryKey.GetValue(null));
					if (text2 == null)
					{
						registryKey.Close();
						continue;
					}
					bool flag = false;
					if (text2.StartsWith("_DCSoft_"))
					{
						flag = true;
					}
					else if (!string.IsNullOrEmpty(string_0))
					{
						RegistryKey registryKey2 = registryKey.OpenSubKey("TypeLib", writable: false);
						if (registryKey2 != null)
						{
							string text3 = Convert.ToString(registryKey2.GetValue(null));
							registryKey2.Close();
							if (text3 != null && text3.IndexOf(string_0, StringComparison.CurrentCultureIgnoreCase) >= 0)
							{
								flag = true;
							}
						}
					}
					registryKey.Close();
					if (flag)
					{
						try
						{
							registryKey_0.DeleteSubKeyTree(text);
							num2++;
						}
						catch
						{
						}
					}
				}
			}
			return num2;
		}

		public void method_4(Form form_0, bool bool_1)
		{
			int num = 2;
			try
			{
				if (!method_0() && form_0 != null)
				{
					form_0.Cursor = Cursors.WaitCursor;
				}
				GClass37 gClass = new GClass37();
				gClass.method_1(method_0());
				Assembly assembly = GetType().Assembly;
				if (!gClass.method_10(form_0, "iexplore"))
				{
					return;
				}
				if (gClass.method_5(assembly))
				{
					if (bool_1)
					{
						int num2 = smethod_1();
						if (!method_0())
						{
							MessageBox.Show(form_0, "清理了 " + num2 + " 处数据", WriterStrings.SystemAlert);
						}
					}
					if (!method_0())
					{
						MessageBox.Show(form_0, string.Format(WriterStrings.SuccessUnRegAsm_FileName, assembly.Location), WriterStrings.SystemAlert);
					}
				}
				else if (!method_0())
				{
					MessageBox.Show(form_0, string.Format(WriterStrings.FailUnRegAsm_FileName, assembly.Location), WriterStrings.SystemAlert);
				}
			}
			catch (Exception ex)
			{
				if (!method_0())
				{
					MessageBox.Show(form_0, string.Format(WriterStrings.PromptErrAndWin7_MSG, ex.Message), WriterStrings.SystemAlert, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			if (!method_0() && form_0 != null)
			{
				form_0.Cursor = Cursors.Default;
			}
		}

		public bool method_5(Assembly assembly_0)
		{
			int num = 14;
			GuidAttribute guidAttribute = (GuidAttribute)Attribute.GetCustomAttribute(assembly_0, typeof(GuidAttribute), inherit: true);
			List<string> list = new List<string>();
			string name = assembly_0.GetName().Name;
			Type[] types = assembly_0.GetTypes();
			foreach (Type element in types)
			{
				try
				{
					if (((ComVisibleAttribute)Attribute.GetCustomAttribute(element, typeof(ComVisibleAttribute), inherit: true))?.Value ?? false)
					{
						GuidAttribute guidAttribute2 = (GuidAttribute)Attribute.GetCustomAttribute(element, typeof(GuidAttribute), inherit: true);
						if (guidAttribute2 != null && !string.IsNullOrEmpty(guidAttribute2.Value))
						{
							list.Add("{" + guidAttribute2.Value + "}");
						}
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
				}
			}
			if (list.Count > 0)
			{
				RegistryKey classesRoot = Registry.ClassesRoot;
				string name2 = "CLSID";
				RegistryKey registryKey = classesRoot.OpenSubKey(name2, writable: true);
				string[] subKeyNames = registryKey.GetSubKeyNames();
				string[] array = subKeyNames;
				foreach (string text in array)
				{
					if (list.Count == 0)
					{
						break;
					}
					bool flag = false;
					foreach (string item in list)
					{
						if (string.Compare(item, text, ignoreCase: true) == 0)
						{
							registryKey.DeleteSubKeyTree(text);
							list.Remove(item);
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
					try
					{
						Guid a = new Guid(text);
						if (a == Guid.Empty)
						{
							continue;
						}
					}
					catch
					{
						continue;
					}
					try
					{
						RegistryKey registryKey2 = registryKey.OpenSubKey(text, writable: false);
						if (registryKey2 != null)
						{
							RegistryKey registryKey3 = registryKey2.OpenSubKey("InprocServer32", writable: false);
							if (registryKey3 != null)
							{
								string text2 = Convert.ToString(registryKey3.GetValue("Assembly"));
								if (!string.IsNullOrEmpty(text2))
								{
									int num2 = text2.IndexOf(',');
									if (num2 > 0)
									{
										text2 = text2.Substring(0, num2).Trim();
										if (text2 == name)
										{
											flag = true;
										}
									}
								}
								registryKey3.Close();
							}
							registryKey2.Close();
						}
					}
					catch
					{
					}
					if (flag)
					{
						RegistryKey registryKey3 = registryKey.OpenSubKey(text);
						if (registryKey3 != null)
						{
							registryKey3.Close();
							try
							{
								registryKey.DeleteSubKeyTree(text);
							}
							catch (Exception ex)
							{
								Debug.WriteLine(text + " " + ex.Message);
							}
						}
					}
				}
				classesRoot.Close();
			}
			if (guidAttribute != null && !string.IsNullOrEmpty(guidAttribute.Value))
			{
				string text = "{" + guidAttribute.Value.ToUpper() + "}";
				RegistryKey registryKey4 = Registry.ClassesRoot.OpenSubKey("TypeLib", writable: true);
				if (registryKey4 != null)
				{
					RegistryKey registryKey2 = registryKey4.OpenSubKey(text);
					if (registryKey2 != null)
					{
						registryKey2.Close();
						try
						{
							registryKey4.DeleteSubKeyTree(text);
						}
						catch (Exception ex)
						{
							Debug.WriteLine(text + " " + ex.Message);
						}
					}
					registryKey4.Close();
				}
			}
			string directoryName = Path.GetDirectoryName(typeof(string).Assembly.Location);
			string text3 = Path.Combine(directoryName, "Regasm.exe");
			if (!File.Exists(text3))
			{
				MessageBox.Show("未找到文件 " + text3 + " ,无法执行操作!");
				return false;
			}
			string arguments = "\"" + assembly_0.Location + "\"  /u";
			Process process = new Process();
			process.StartInfo.FileName = text3;
			process.StartInfo.Arguments = arguments;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.WaitForExit(5000);
			string message = process.StandardOutput.ReadToEnd();
			string message2 = process.StandardError.ReadToEnd();
			Debug.WriteLine(message);
			Debug.WriteLine(message2);
			return true;
		}

		public static string smethod_9(Assembly assembly_0)
		{
			int num = 17;
			if (assembly_0 == null)
			{
				throw new ArgumentNullException("asm");
			}
			string result = null;
			Guid typeLibGuidForAssembly = Marshal.GetTypeLibGuidForAssembly(assembly_0);
			if (typeLibGuidForAssembly != Guid.Empty)
			{
				string str = "{" + typeLibGuidForAssembly.ToString().ToUpper() + "}";
				RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("TypeLib\\" + str, writable: true);
				if (registryKey != null)
				{
					string[] subKeyNames = registryKey.GetSubKeyNames();
					if (subKeyNames != null && subKeyNames.Length > 0)
					{
						RegistryKey registryKey2 = null;
						registryKey2 = ((IntPtr.Size != 4) ? registryKey.OpenSubKey(subKeyNames[0] + "\\0\\win64") : registryKey.OpenSubKey(subKeyNames[0] + "\\0\\win32"));
						if (registryKey2 != null)
						{
							result = Convert.ToString(registryKey2.GetValue(null));
							registryKey2.Close();
						}
					}
					registryKey.Close();
				}
			}
			return result;
		}

		public bool method_6(Control control_0, bool bool_1)
		{
			int num = 6;
			MessageBoxShower messageBoxShower = new MessageBoxShower();
			messageBoxShower.Owner = control_0;
			messageBoxShower.Caption = WriterStrings.SystemAlert;
			messageBoxShower.Icon = MessageBoxIcon.Asterisk;
			try
			{
				Assembly assembly = GetType().Assembly;
				if (!method_0() && control_0 != null)
				{
					control_0.Cursor = Cursors.WaitCursor;
				}
				if (!method_10(control_0, "iexplore"))
				{
					return false;
				}
				if (bool_1 && !method_5(assembly))
				{
					return false;
				}
				if (method_8(assembly))
				{
					if (!method_0() && control_0 != null)
					{
						control_0.Cursor = Cursors.Default;
					}
					if (!method_0())
					{
						method_7(control_0);
						messageBoxShower.Text = string.Format(WriterStrings.SuccessRegAsm_FileName, assembly.Location);
						messageBoxShower.ShowWithCheckInvoke();
					}
					return true;
				}
				if (!method_0())
				{
					method_7(control_0);
					messageBoxShower.Text = string.Format(WriterStrings.FailRegAsm_FileName, assembly.Location);
					messageBoxShower.Icon = MessageBoxIcon.Hand;
					messageBoxShower.ShowWithCheckInvoke();
				}
			}
			catch (Exception ex)
			{
				if (!method_0())
				{
					method_7(control_0);
					messageBoxShower.Icon = MessageBoxIcon.Hand;
					messageBoxShower.Text = string.Format(WriterStrings.PromptErrAndWin7_MSG, ex.Message);
					messageBoxShower.ShowWithCheckInvoke();
				}
			}
			finally
			{
				if (!method_0() && control_0 != null)
				{
					control_0.Cursor = Cursors.Default;
				}
			}
			return false;
		}

		private void method_7(Control control_0)
		{
			if (control_0 is dlgSingleProgress)
			{
				dlgSingleProgress dlgSingleProgress = control_0 as dlgSingleProgress;
				dlgSingleProgress.CompleteWork();
			}
		}

		public bool method_8(Assembly assembly_0)
		{
			string directoryName = Path.GetDirectoryName(typeof(string).Assembly.Location);
			string fileName = Path.Combine(directoryName, "Regasm.exe");
			string arguments = "\"" + assembly_0.Location + "\"  /tlb  /codebase";
			Process process = new Process();
			process.StartInfo.FileName = fileName;
			process.StartInfo.Arguments = arguments;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.WaitForExit(60000);
			string message = process.StandardOutput.ReadToEnd();
			string message2 = process.StandardError.ReadToEnd();
			Debug.WriteLine(message);
			Debug.WriteLine(message2);
			return true;
		}

		public bool method_9()
		{
			int num = 15;
			bool result = false;
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			folderPath = Path.Combine(folderPath, "assembly");
			string text = Path.Combine(folderPath, "dl2");
			if (Directory.Exists(text))
			{
				Directory.Delete(text, recursive: true);
				Debug.WriteLine(string.Format(WriterStrings.DeleteDirectory_Name, text));
				result = true;
			}
			text = Path.Combine(folderPath, "dl3");
			if (Directory.Exists(text))
			{
				Directory.Delete(text, recursive: true);
				Debug.WriteLine(string.Format(WriterStrings.DeleteDirectory_Name, text));
				result = true;
			}
			return result;
		}

		public bool method_10(Control control_0, string string_2)
		{
			int num = 19;
			if (method_0())
			{
				return true;
			}
			if (string_2 == null)
			{
				string_2 = "iexplore";
			}
			bool flag = false;
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			foreach (Process process in array)
			{
				if (string.Compare(process.ProcessName, string_2, ignoreCase: true) == 0 && !flag)
				{
					flag = true;
					MessageBoxShower messageBoxShower = new MessageBoxShower();
					messageBoxShower.Owner = control_0;
					messageBoxShower.Caption = WriterStrings.SystemAlert;
					messageBoxShower.Text = string.Format(WriterStrings.PromptKillProcess_Name, string_2);
					messageBoxShower.Icon = MessageBoxIcon.Question;
					messageBoxShower.Buttons = MessageBoxButtons.OKCancel;
					if (messageBoxShower.ShowWithCheckInvoke() != DialogResult.Cancel)
					{
						break;
					}
					return false;
				}
			}
			return true;
		}

		public bool method_11()
		{
			int num = 14;
			bool flag = true;
			bool flag2 = false;
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "Software\\Microsoft\\NET Framework Setup\\NDP\\v2.0.50727";
			RegistryKey registryKey = localMachine.OpenSubKey(name);
			if (registryKey != null)
			{
				flag2 = true;
			}
			bool flag3 = false;
			string name2 = "Software\\Microsoft\\NET Framework Setup\\NDP\\v4.0";
			RegistryKey registryKey2 = localMachine.OpenSubKey(name2);
			if (registryKey2 != null)
			{
				string[] valueNames = registryKey2.GetValueNames();
				if (valueNames.Length > 0)
				{
					string[] array = valueNames;
					foreach (string a in array)
					{
						if (a == "Version")
						{
							flag3 = true;
						}
					}
				}
			}
			if (flag2)
			{
				if (flag3)
				{
					RegistryKey localMachine2 = Registry.LocalMachine;
					RegistryKey registryKey3 = localMachine2.OpenSubKey(name, writable: true);
					RegistryKey registryKey4 = registryKey3.CreateSubKey("EnableIEHosting");
					registryKey4.SetValue("EnableIEHosting", 1, RegistryValueKind.DWord);
				}
				string value = string.Empty;
				if (method_2())
				{
					value = "C:\\Windows\\Microsoft.NET\\Framework\\v2.0.50727\\Caspol.exe -force   -pp  off -machine -chggroup 1.5 FullTrust";
				}
				else if (method_3())
				{
					value = "C:\\Windows\\Microsoft.NET\\Framework\\v2.0.50727\\Caspol.exe -force   -pp  off -machine -chggroup 1.5 FullTrust";
				}
				Process process = new Process();
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				process.StandardInput.WriteLine(value);
				process.StandardInput.WriteLine("exit");
				string text = process.StandardOutput.ReadToEnd();
				Debug.WriteLine(text);
				if (text.Contains("成功") || text.Contains("Success"))
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public bool method_12(string string_2)
		{
			int num = 11;
			bool result = true;
			if (string_2 != null || string_2 != string.Empty)
			{
				bool flag = Regex.IsMatch(string_2, "\\b(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\b");
				string a = "";
				if (!flag)
				{
					string pattern = "(?<=http://)[\\w\\.]+[^/]";
					MatchCollection matchCollection = Regex.Matches(string_2, pattern);
					foreach (Match item in matchCollection)
					{
						a = item.ToString();
					}
				}
				if (a != "")
				{
					method_13(string_2);
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		private void method_13(string string_2)
		{
			int num = 13;
			RegistryKey currentUser = Registry.CurrentUser;
			string[] array = string_2.Split('/');
			string[] array2 = array[2].Split(new char[1]
			{
				'.'
			}, 2);
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].Contains(":"))
				{
					string[] array3 = array2[i].Split(':');
					array2[i] = array3[0];
					array[2] = array2[i];
				}
			}
			string name = array[0].Substring(0, array[0].Length - 1);
			string name2;
			if (method_14(array[2]))
			{
				name2 = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\ZoneMap\\Ranges";
				RegistryKey registryKey = currentUser.OpenSubKey(name2, writable: true);
				bool flag = false;
				List<string> list = new List<string>();
				string[] subKeyNames = registryKey.GetSubKeyNames();
				foreach (string text in subKeyNames)
				{
					list.Add(text.Substring("Range".Length));
					RegistryKey registryKey2 = registryKey.OpenSubKey(text, writable: true);
					if (registryKey2.GetValue(":Range").Equals(array[2]))
					{
						flag = true;
						if (registryKey2.GetValue(name) != null)
						{
							break;
						}
						registryKey2.SetValue(name, 2, RegistryValueKind.DWord);
					}
				}
				if (!flag)
				{
					RegistryKey registryKey2 = registryKey.CreateSubKey("Range" + method_16(list));
					registryKey2.SetValue(":Range", array[2], RegistryValueKind.String);
					registryKey2.SetValue(name, 2, RegistryValueKind.DWord);
				}
				return;
			}
			name2 = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\ZoneMap\\Domains";
			RegistryKey registryKey3 = currentUser.OpenSubKey(name2, writable: true);
			string[] array4 = array[2].Split(new char[1]
			{
				'.'
			}, 2);
			for (int i = 0; i < array4.Length; i++)
			{
				if (array4[i].Contains(":"))
				{
					string[] array3 = array4[i].Split(':');
					array4[i] = array3[0] + "//";
				}
			}
			string text2 = string.Empty;
			string empty = string.Empty;
			bool flag2 = true;
			if (array4.Length > 1)
			{
				text2 = array4[0];
				empty = array4[1];
			}
			else
			{
				empty = array4[0];
				flag2 = false;
			}
			RegistryKey registryKey4 = registryKey3.OpenSubKey(empty, writable: true);
			if (registryKey4 == null)
			{
				registryKey4 = registryKey3.CreateSubKey(empty);
				RegistryKey registryKey5 = registryKey4.CreateSubKey(text2);
				registryKey5.SetValue(name, 2, RegistryValueKind.DWord);
			}
			else if (flag2)
			{
				RegistryKey registryKey5 = registryKey4.OpenSubKey(text2, writable: true);
				if (registryKey5 == null)
				{
					registryKey5 = registryKey4.CreateSubKey(text2);
					registryKey5.SetValue(name, 2, RegistryValueKind.DWord);
				}
			}
			else
			{
				RegistryKey registryKey5 = registryKey4.OpenSubKey(text2, writable: true);
				registryKey5.SetValue(name, 2, RegistryValueKind.DWord);
			}
		}

		private bool method_14(string string_2)
		{
			string[] array = string_2.Split('.');
			string[] array2 = array;
			int num = 0;
			while (true)
			{
				if (num < array2.Length)
				{
					string string_3 = array2[num];
					if (!method_15(string_3))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_15(string string_2)
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < string_2.Length)
				{
					char c = string_2[num2];
					num = c;
					if (num < 48 || num > 57)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		private string method_16(List<string> list_0)
		{
			int num = 1;
			while (true)
			{
				if (num <= list_0.Count)
				{
					if (list_0.IndexOf(num.ToString()) == -1)
					{
						break;
					}
					num++;
					continue;
				}
				return (list_0.Count + 1).ToString();
			}
			return num.ToString();
		}

		public bool method_17(Assembly assembly_0, string string_2)
		{
			return method_18(assembly_0.Location, string_2);
		}

		public bool method_18(string string_2, string string_3)
		{
			int num = 16;
			if (string.IsNullOrEmpty(string_2))
			{
				throw new ArgumentNullException("localFileName");
			}
			if (string.IsNullOrEmpty(string_3))
			{
				throw new ArgumentNullException("url");
			}
			if (!File.Exists(string_2))
			{
				throw new FileNotFoundException(string_2);
			}
			using (WebClient webClient = new WebClient())
			{
				byte[] array = webClient.DownloadData(string_3);
				if (array != null && array.Length > 0)
				{
					using (FileStream fileStream = new FileStream(string_2, FileMode.Open, FileAccess.Read))
					{
						byte[] array2 = new byte[fileStream.Length];
						fileStream.Read(array2, 0, array2.Length);
						if (array.Length == array2.Length)
						{
							int num2 = 0;
							while (true)
							{
								if (num2 >= array.Length)
								{
									return true;
								}
								if (array[num2] != array2[num2])
								{
									break;
								}
								num2++;
							}
							return false;
						}
					}
				}
			}
			return false;
		}

		public bool method_19(string string_2, string[] string_3)
		{
			if (string.IsNullOrEmpty(string_2))
			{
				return false;
			}
			string path = Class66.smethod_7(string_2);
			if (File.Exists(path))
			{
				path = Path.GetFileNameWithoutExtension(path);
				if (!method_10(null, path))
				{
					return false;
				}
			}
			return Class66.smethod_8(string_2, string_3);
		}
	}
}
