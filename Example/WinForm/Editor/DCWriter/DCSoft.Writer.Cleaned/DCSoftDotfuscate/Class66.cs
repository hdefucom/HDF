#define DEBUG
using DCSoft.Common;
using DCSoft.Writer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace DCSoftDotfuscate
{
	internal class Class66
	{
		private class Class67
		{
			public bool bool_0 = true;

			public string string_0 = null;

			public string string_1 = null;

			public string string_2 = null;

			public string string_3 = null;

			public string string_4 = null;

			public List<string> list_0 = new List<string>();
		}

		private static List<Class67> list_0 = null;

		public static string smethod_0()
		{
			int num = 9;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\DCSoft\\DCWriter", writable: false);
			if (registryKey != null)
			{
				string result = Convert.ToString(registryKey.GetValue("DelphiOutuptPath"));
				registryKey.Close();
				return result;
			}
			return null;
		}

		public static void smethod_1(string string_0)
		{
			int num = 4;
			try
			{
				if (string_0 == null)
				{
					string_0 = "";
				}
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\DCSoft\\DCWriter", RegistryKeyPermissionCheck.Default)?.SetValue("DelphiOutuptPath", string_0);
			}
			catch (Exception)
			{
			}
		}

		private static void smethod_2()
		{
			int num = 6;
			if (list_0 == null)
			{
				list_0 = new List<Class67>();
				smethod_4("SOFTWARE\\Borland\\C++Builder", "C++Builder", bool_0: false);
				smethod_4("SOFTWARE\\Borland\\Delphi", "Delphi", bool_0: true);
				smethod_4("SOFTWARE\\Embarcadero\\BDS", "Delphi", bool_0: true);
				smethod_4("SOFTWARE\\CodeGear\\BDS", "Delphi", bool_0: true);
			}
		}

		private static Class67 smethod_3(string string_0)
		{
			smethod_2();
			foreach (Class67 item in list_0)
			{
				if (item.string_1 == string_0)
				{
					return item;
				}
			}
			return null;
		}

		private static void smethod_4(string string_0, string string_1, bool bool_0)
		{
			int num = 10;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(string_0, writable: false);
			if (registryKey == null)
			{
				return;
			}
			string[] subKeyNames = registryKey.GetSubKeyNames();
			string[] array = subKeyNames;
			foreach (string text in array)
			{
				RegistryKey registryKey2 = registryKey.OpenSubKey(text);
				Class67 @class = new Class67();
				@class.bool_0 = bool_0;
				@class.string_0 = string_1;
				@class.string_2 = Convert.ToString(registryKey2.GetValue("App"));
				@class.string_1 = Path.GetFileNameWithoutExtension(@class.string_2) + "(" + text + ")";
				if (File.Exists(@class.string_2))
				{
					@class.string_3 = Path.GetDirectoryName(@class.string_2);
				}
				@class.string_4 = Convert.ToString(registryKey2.GetValue("RootDir"));
				RegistryKey registryKey3 = registryKey2.OpenSubKey("Library");
				if (registryKey3 != null)
				{
					string text2 = Convert.ToString(registryKey3.GetValue("Search Path"));
					string text3 = (IntPtr.Size == 8) ? "Win64" : "Win32";
					RegistryKey registryKey4 = registryKey3.OpenSubKey(text3);
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (registryKey4 != null)
					{
						string text4 = Convert.ToString(registryKey4.GetValue("Search Path"));
						registryKey4.Close();
						if (!string.IsNullOrEmpty(text4))
						{
							text4 = text4.Replace("$(Platform)", text3);
							text2 = text2 + ";" + text4;
						}
						string text5 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Embarcadero\\BDS\\" + text + "\\environment.proj");
						if (File.Exists(text5))
						{
							XmlDocument xmlDocument = new XmlDocument();
							xmlDocument.Load(text5);
							XmlNode childNode = XMLHelper.GetChildNode(xmlDocument.DocumentElement, "PropertyGroup");
							if (childNode != null)
							{
								foreach (XmlNode childNode2 in childNode.ChildNodes)
								{
									if (childNode2 is XmlElement)
									{
										dictionary[childNode2.Name] = childNode2.InnerText;
									}
								}
							}
						}
					}
					registryKey3.Close();
					registryKey3 = Registry.CurrentUser.OpenSubKey(string_0 + "\\" + text + "\\Library", writable: false);
					if (registryKey3 != null)
					{
						string text6 = Convert.ToString(registryKey3.GetValue("Search Path"));
						registryKey3.Close();
						if (!string.IsNullOrEmpty(text6))
						{
							text2 = text2 + ";" + text6;
						}
					}
					string text7 = @class.string_4;
					if (text7.EndsWith("\\"))
					{
						text7 = text7.Substring(0, text7.Length - 1);
					}
					dictionary["DELPHI"] = text7;
					dictionary["BCB"] = text7;
					string[] array2 = text2.Split(';');
					for (int j = 0; j < array2.Length; j++)
					{
						string text8 = array2[j];
						if (!string.IsNullOrEmpty(text8))
						{
							foreach (string key in dictionary.Keys)
							{
								text8 = text8.Replace("$(" + key + ")", dictionary[key]);
							}
							if (!@class.list_0.Contains(text8) && Directory.Exists(text8))
							{
								@class.list_0.Add(text8);
							}
						}
					}
					if (dictionary.ContainsKey("BDSCOMMONDIR"))
					{
						string text9 = dictionary["BDSCOMMONDIR"];
						@class.list_0.Add(text9);
						string text10 = Path.Combine(text9, "Bpl");
						if (Directory.Exists(text10))
						{
							@class.list_0.Add(text10);
						}
					}
				}
				registryKey2.Close();
				list_0.Add(@class);
			}
			registryKey.Close();
		}

		public static string[] smethod_5()
		{
			smethod_2();
			List<string> list = new List<string>();
			foreach (Class67 item in list_0)
			{
				list.Add(item.string_1);
			}
			return list.ToArray();
		}

		public static List<string> smethod_6(string string_0, string string_1, string string_2, bool bool_0)
		{
			int num = 19;
			List<string> list = new List<string>();
			Class67 @class = smethod_3(string_0);
			if (@class == null)
			{
				return null;
			}
			string string_3 = @class.string_2;
			if (File.Exists(string_3))
			{
				string_3 = Path.Combine(Path.GetDirectoryName(string_3), "tlibimp.exe");
				if (File.Exists(string_3))
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = string_3;
					if (@class.bool_0)
					{
						processStartInfo.Arguments = "-P+ -Ha+ \"-D" + string_2 + "\" \"" + string_1 + "\"";
					}
					else
					{
						processStartInfo.Arguments = "-C+ -Ha+ \"-D" + string_2 + "\" \"" + string_1 + "\"";
					}
					processStartInfo.UseShellExecute = false;
					processStartInfo.RedirectStandardInput = true;
					processStartInfo.RedirectStandardOutput = true;
					processStartInfo.RedirectStandardError = true;
					processStartInfo.CreateNoWindow = true;
					Process process = Process.Start(processStartInfo);
					process.Start();
					string processName = process.ProcessName;
					process.WaitForExit(60000);
					if (!process.HasExited && MessageBox.Show("后台操作进程还没退出，是否强制退出?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						process.Kill();
					}
					Thread.Sleep(1000);
					Process[] processesByName = Process.GetProcessesByName(processName);
					if (processesByName != null && processesByName.Length > 0)
					{
						Process[] array = processesByName;
						foreach (Process process2 in array)
						{
							process2.WaitForExit(60000);
						}
					}
					string text = process.StandardOutput.ReadToEnd();
					string message = process.StandardError.ReadToEnd();
					Debug.WriteLine(text);
					Debug.WriteLine(message);
					if (!string.IsNullOrEmpty(text))
					{
						StringReader stringReader = new StringReader(text);
						for (string text2 = stringReader.ReadLine(); text2 != null; text2 = stringReader.ReadLine())
						{
							if (text2.StartsWith("Cannot create file"))
							{
								MessageBox.Show("操作发生错误,不过可以忽略掉，或者请过几分钟再重试一下。" + Environment.NewLine + text2);
							}
							if (text2.StartsWith("Created"))
							{
								text2 = text2.Substring(7).Trim();
								if (text2.StartsWith("!"))
								{
									text2 = text2.Substring(1);
								}
								if (File.Exists(text2))
								{
									list.Add(text2);
									if (text2.EndsWith("DCSoft_Writer_TLB.pas", StringComparison.CurrentCultureIgnoreCase))
									{
										string text3 = null;
										using (StreamReader streamReader = new StreamReader(text2, Encoding.Default))
										{
											text3 = streamReader.ReadToEnd();
										}
										int num2 = text3.IndexOf("TAxWriterControl = class(TOleControl)");
										bool flag = false;
										if (num2 > 0)
										{
											num2 = text3.IndexOf("published", num2 + 1);
											if (num2 > 2 && num2 < text3.Length - 20 && char.IsWhiteSpace(text3[num2 - 1]) && char.IsWhiteSpace(text3[num2 + 9]))
											{
												text3 = text3.Insert(num2 + 9, Environment.NewLine + "    property  OnDragDrop;\r\n    property  OnDragOver;\r\n    property  OnEndDrag;\r\n");
												flag = true;
											}
										}
										num2 = 0;
										string text4 = "TControlData2(CControlData).FirstEventOfs";
										while (num2 >= 0)
										{
											num2 = text3.IndexOf(text4, num2);
											if (num2 <= 0)
											{
												break;
											}
											text3 = text3.Insert(num2, "//");
											flag = true;
											num2 += text4.Length;
										}
										if (flag)
										{
											using (StreamWriter streamWriter = new StreamWriter(text2, append: false, Encoding.Default))
											{
												streamWriter.Write(text3);
											}
										}
									}
								}
							}
						}
						stringReader.Close();
						if (list.Count > 0)
						{
							list = new List<string>(Directory.GetFiles(string_2));
						}
						if (list.Count > 0 && bool_0)
						{
							string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(string_1);
							fileNameWithoutExtension = fileNameWithoutExtension.Replace('.', '_');
							string path = Path.Combine(string_2, fileNameWithoutExtension + ".dpk");
							using (StreamWriter streamWriter2 = new StreamWriter(path, append: false, Encoding.Default))
							{
								streamWriter2.WriteLine("package " + fileNameWithoutExtension);
								streamWriter2.WriteLine("");
								streamWriter2.WriteLine("{$R *.res}");
								foreach (string item in list)
								{
									if (item.EndsWith(".dcr", StringComparison.CurrentCultureIgnoreCase))
									{
										streamWriter2.WriteLine("{$R '" + Path.GetFileName(item) + "'}");
									}
								}
								streamWriter2.WriteLine("\r\n{$ASSERTIONS ON}\r\n{$BOOLEVAL OFF}\r\n{$DEBUGINFO ON}\r\n{$EXTENDEDSYNTAX ON}\r\n{$IMPORTEDDATA ON}\r\n{$IOCHECKS ON}\r\n{$LOCALSYMBOLS ON}\r\n{$LONGSTRINGS ON}\r\n{$OPENSTRINGS ON}\r\n{$OPTIMIZATION ON}\r\n{$OVERFLOWCHECKS OFF}\r\n{$RANGECHECKS OFF}\r\n{$REFERENCEINFO ON}\r\n{$SAFEDIVIDE OFF}\r\n{$STACKFRAMES OFF}\r\n{$TYPEDADDRESS OFF}\r\n{$VARSTRINGCHECKS ON}\r\n{$WRITEABLECONST OFF}\r\n{$MINENUMSIZE 1}\r\n{$IMAGEBASE $400000}\r\n{$IMPLICITBUILD OFF}\r\n\r\nrequires\r\n  rtl,\r\n  vcl;\r\n\r\ncontains");
								foreach (string item2 in list)
								{
									if (item2.EndsWith(".pas", StringComparison.CurrentCultureIgnoreCase))
									{
										streamWriter2.WriteLine("   " + Path.GetFileNameWithoutExtension(item2) + " in '" + Path.GetFileName(item2) + "',");
									}
								}
								streamWriter2.WriteLine();
								streamWriter2.WriteLine("end.");
							}
						}
					}
				}
			}
			if (list != null && list.Count > 0)
			{
				if (@class.bool_0)
				{
					string[] files = Directory.GetFiles(string_2, "*.pas");
					foreach (string current in files)
					{
						string text4 = File.ReadAllText(current, Encoding.Default);
						text4 = text4.Replace("{$VARPROPSETTER ON}", "//{$VARPROPSETTER ON}");
						File.WriteAllText(current, text4, Encoding.Default);
					}
					WriterUtils.smethod_13(typeof(Class66), "DCSoft.Writer.Extension.DelphiProject.dcsoft_writer.res", Path.Combine(string_2, "dcsoft_writer.res"));
					list.Add(Path.Combine(string_2, "dcsoft_writer.res"));
					WriterUtils.smethod_13(typeof(Class66), "DCSoft.Writer.Extension.DelphiProject.dcsoft_writer.dpk", Path.Combine(string_2, "dcsoft_writer.dpk"));
					list.Add(Path.Combine(string_2, "dcsoft_writer.dpk"));
					WriterUtils.smethod_13(typeof(Class66), "DCSoft.Writer.Extension.DelphiProject.dcsoft_writer.dof", Path.Combine(string_2, "dcsoft_writer.dof"));
					list.Add(Path.Combine(string_2, "dcsoft_writer.dof"));
					string text5 = Path.Combine(string_2, "dcsoft_writer.cfg");
					WriterUtils.smethod_13(typeof(Class66), "DCSoft.Writer.Extension.DelphiProject.dcsoft_writer.cfg", text5);
					string text6 = File.ReadAllText(text5, Encoding.Default);
					text6 = text6.Replace("#OutputPath", string_2);
					File.WriteAllText(text5, text6, Encoding.Default);
					list.Add(text5);
				}
				else
				{
					WriterUtils.smethod_13(typeof(Class66), "DCSoft.Writer.Extension.BCBProject.dcsoft_writer.res", Path.Combine(string_2, "dcsoft_writer.res"));
					list.Add(Path.Combine(string_2, "dcsoft_writer.res"));
					WriterUtils.smethod_13(typeof(Class66), "DCSoft.Writer.Extension.BCBProject.dcsoft_writer.bpk", Path.Combine(string_2, "dcsoft_writer.bpk"));
					list.Add(Path.Combine(string_2, "dcsoft_writer.bpk"));
					WriterUtils.smethod_13(typeof(Class66), "DCSoft.Writer.Extension.BCBProject.dcsoft_writer.cpp", Path.Combine(string_2, "dcsoft_writer.cpp"));
					list.Add(Path.Combine(string_2, "dcsoft_writer.cpp"));
				}
			}
			return list;
		}

		public static string smethod_7(string string_0)
		{
			smethod_2();
			foreach (Class67 item in list_0)
			{
				if (item.string_1 == string_0)
				{
					return item.string_2;
				}
			}
			return null;
		}

		public static bool smethod_8(string string_0, string[] string_1)
		{
			int num = 6;
			if (string.IsNullOrEmpty(string_0))
			{
				throw new ArgumentNullException("version");
			}
			if (string_1 == null || string_1.Length == 0)
			{
				throw new ArgumentNullException("matchFileNames");
			}
			Class67 @class = smethod_3(string_0);
			if (@class == null)
			{
				return false;
			}
			string string_2 = @class.string_4;
			if (Directory.Exists(string_2))
			{
				string string_3 = Path.Combine(string_2, "Projects\\Bpl");
				smethod_9(string_3, string_1);
				smethod_9(Path.Combine(string_2, "Bpl"), string_1);
				smethod_9(Path.Combine(string_2, "Imports"), string_1);
			}
			foreach (string item in @class.list_0)
			{
				smethod_9(item, string_1);
			}
			return true;
		}

		private static void smethod_9(string string_0, string[] string_1)
		{
			int num = 17;
			if (!Directory.Exists(string_0))
			{
				return;
			}
			string[] files = Directory.GetFiles(string_0);
			string[] array = files;
			foreach (string text in array)
			{
				string fileName = Path.GetFileName(text);
				bool flag = false;
				foreach (string value in string_1)
				{
					if (fileName.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) >= 0)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					try
					{
						File.SetAttributes(text, FileAttributes.Normal);
						File.Delete(text);
						Debug.WriteLine("删除文件:" + text);
					}
					catch (Exception ex)
					{
						Debug.WriteLine("删除文件:" + text + "!" + ex.Message);
					}
				}
			}
		}
	}
}
