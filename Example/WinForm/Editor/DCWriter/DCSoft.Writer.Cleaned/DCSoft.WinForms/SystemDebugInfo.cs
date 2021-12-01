using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	/// <summary>
	///       系统调试输出信息
	///       </summary>
	[Serializable]
	[XmlType("系统调试输出信息")]
	public class SystemDebugInfo
	{
		private static SystemDebugInfo myInstance = new SystemDebugInfo();

		/// <summary>
		///       发送错误报告的页面URL
		///       </summary>
		[XmlIgnore]
		public string ReportURL = null;

		private Image myApplicationImage = null;

		private DateTime dtmReportTime = DateTime.Now;

		private string strVersion = null;

		private string strErrorMessage = null;

		private string strApplicationName = null;

		private string strUserMessage = null;

		private string strReportSource = null;

		protected object myExceptionSource = null;

		protected string strExceptionMemberName = null;

		private Exception mySourceException = null;

		private string strExceptionMessage = null;

		private string strExceptionString = null;

		private string strDebugText = null;

		private SystemDebugKeyValueList myVariables = null;

		private SystemSoftwareInfo mySoftware = null;

		private SystemHardwareInfo myHardware = null;

		private SystemExecuteFileInfo myMainExecuteFile = null;

		private SystemProcessInfo myMainProcess = null;

		private ArrayList myModules = null;

		/// <summary>
		///       对象唯一静态实例
		///       </summary>
		public static SystemDebugInfo Instance => myInstance;

		public bool IsReportURLOK
		{
			get
			{
				if (ReportURL != null && ReportURL.Length > 0)
				{
					Uri uri = new Uri(ReportURL);
					return uri.Scheme == Uri.UriSchemeHttp;
				}
				return false;
			}
		}

		/// <summary>
		///       应用程序图标
		///       </summary>
		[XmlIgnore]
		public Image ApplicationImage
		{
			get
			{
				return myApplicationImage;
			}
			set
			{
				myApplicationImage = value;
			}
		}

		/// <summary>
		///       报告时间
		///       </summary>
		[XmlElement("报告时间")]
		public DateTime ReportTime
		{
			get
			{
				return dtmReportTime;
			}
			set
			{
				dtmReportTime = value;
			}
		}

		/// <summary>
		///       报告器版本
		///       </summary>
		[XmlElement("报告器版本")]
		public string Version
		{
			get
			{
				return strVersion;
			}
			set
			{
				strVersion = value;
			}
		}

		/// <summary>
		///       报告本身的错误信息
		///       </summary>
		[XmlElement("报表本身的错误信息")]
		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
			set
			{
				strErrorMessage = value;
			}
		}

		/// <summary>
		///       应用名称
		///       </summary>
		[XmlElement("应用名称")]
		public string ApplicationName
		{
			get
			{
				return strApplicationName;
			}
			set
			{
				strApplicationName = value;
			}
		}

		/// <summary>
		///       用户信息
		///       </summary>
		[XmlElement("用户信息")]
		public string UserMessage
		{
			get
			{
				return strUserMessage;
			}
			set
			{
				strUserMessage = value;
			}
		}

		/// <summary>
		///       报告来源
		///       </summary>
		[XmlElement("报告来源")]
		public string ReportSource
		{
			get
			{
				return strReportSource;
			}
			set
			{
				strReportSource = value;
			}
		}

		/// <summary>
		///       引发错误的对象
		///       </summary>
		[XmlIgnore]
		public object ExceptionSource
		{
			get
			{
				return myExceptionSource;
			}
			set
			{
				myExceptionSource = value;
			}
		}

		/// <summary>
		///       发生错误的对象成员名称
		///       </summary>
		public string ExceptionMemberName
		{
			get
			{
				return strExceptionMemberName;
			}
			set
			{
				strExceptionMemberName = value;
			}
		}

		/// <summary>
		///       错误信息对象
		///       </summary>
		[XmlIgnore]
		public Exception SourceException
		{
			get
			{
				return mySourceException;
			}
			set
			{
				mySourceException = value;
				if (mySourceException != null)
				{
					strExceptionMessage = mySourceException.Message;
					strExceptionString = mySourceException.ToString();
				}
			}
		}

		/// <summary>
		///       错误信息
		///       </summary>
		[XmlElement("错误信息")]
		public string ExceptionMessage
		{
			get
			{
				return strExceptionMessage;
			}
			set
			{
				strExceptionMessage = value;
			}
		}

		/// <summary>
		///       错误详细信息
		///       </summary>
		[XmlElement("错误详细信息")]
		public string ExceptionString
		{
			get
			{
				return strExceptionString;
			}
			set
			{
				strExceptionString = value;
			}
		}

		/// <summary>
		///       调试输出文本
		///       </summary>
		[XmlElement("调试输出文本")]
		public string DebugText
		{
			get
			{
				return strDebugText;
			}
			set
			{
				strDebugText = value;
			}
		}

		/// <summary>
		///       环境变量
		///       </summary>
		[XmlArrayItem("Item")]
		[XmlArray("系统环境变量")]
		public SystemDebugKeyValueList Variables
		{
			get
			{
				return myVariables;
			}
			set
			{
				myVariables = value;
			}
		}

		/// <summary>
		///       软件环境
		///       </summary>
		[XmlElement("软件环境")]
		public SystemSoftwareInfo Software
		{
			get
			{
				if (mySoftware == null)
				{
					mySoftware = new SystemSoftwareInfo();
				}
				return mySoftware;
			}
			set
			{
				mySoftware = value;
			}
		}

		/// <summary>
		///       硬件环境
		///       </summary>
		[XmlElement("硬件环境")]
		public SystemHardwareInfo Hardware
		{
			get
			{
				if (myHardware == null)
				{
					myHardware = new SystemHardwareInfo();
				}
				return myHardware;
			}
			set
			{
				myHardware = value;
			}
		}

		/// <summary>
		///       主可执行文件信息
		///       </summary>
		[XmlElement("主可执行文件信息")]
		public SystemExecuteFileInfo MainExecuteFile
		{
			get
			{
				return myMainExecuteFile;
			}
			set
			{
				myMainExecuteFile = value;
			}
		}

		/// <summary>
		///       主进程信息
		///       </summary>
		[XmlElement("主进程信息")]
		public SystemProcessInfo MainProcess
		{
			get
			{
				return myMainProcess;
			}
			set
			{
				myMainProcess = value;
			}
		}

		/// <summary>
		///       已加载的模板信息
		///       </summary>
		[XmlArrayItem("模块", typeof(SystemProcessModuleInfo))]
		[XmlArray("已加载的模块")]
		public ArrayList Modules
		{
			get
			{
				if (myModules == null)
				{
					myModules = new ArrayList();
					Process currentProcess = Process.GetCurrentProcess();
					if (currentProcess != null)
					{
						ProcessModuleCollection modules = currentProcess.Modules;
						if (modules != null)
						{
							foreach (ProcessModule item in modules)
							{
								myModules.Add(new SystemProcessModuleInfo(item));
							}
						}
					}
				}
				return myModules;
			}
			set
			{
				myModules = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public SystemDebugInfo()
		{
			Reset();
		}

		/// <summary>
		///       重新设置对象数据
		///       </summary>
		public void Reset()
		{
			try
			{
				myMainExecuteFile = new SystemExecuteFileInfo();
				myMainProcess = new SystemProcessInfo();
				myVariables = new SystemDebugKeyValueList();
				myModules = new ArrayList();
				strVersion = GetType().AssemblyQualifiedName;
				dtmReportTime = DateTime.Now;
				mySoftware = new SystemSoftwareInfo();
				myVariables = new SystemDebugKeyValueList();
				IDictionary environmentVariables = Environment.GetEnvironmentVariables();
				IDictionaryEnumerator enumerator = environmentVariables.GetEnumerator();
				while (enumerator.MoveNext())
				{
					myVariables.AddItem(Convert.ToString(enumerator.Key), Convert.ToString(enumerator.Value));
				}
				myMainExecuteFile = new SystemExecuteFileInfo(Application.ExecutablePath);
				Process currentProcess = Process.GetCurrentProcess();
				if (currentProcess != null)
				{
					myMainProcess = new SystemProcessInfo(currentProcess);
				}
			}
			catch (Exception ex)
			{
				strErrorMessage = ex.Message;
			}
		}

		/// <summary>
		///       显示错误信息对话框
		///       </summary>
		public void ShowErrorDialog()
		{
			using (dlgError dlgError = new dlgError())
			{
				dlgError.DebugInfo = this;
				dlgError.ShowDialog();
			}
		}

		/// <summary>
		///       根据对象内容创建一个XML字符串
		///       </summary>
		/// <returns>XML字符串</returns>
		public string CreateXMLString()
		{
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.IndentChar = ' ';
			xmlTextWriter.Indentation = 3;
			xmlTextWriter.Formatting = Formatting.Indented;
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(xmlTextWriter, this);
			xmlTextWriter.Close();
			string text = stringWriter.ToString();
			int num = text.IndexOf("?>");
			if (num > 0 && num < 50)
			{
				text = text.Substring(num + 2);
			}
			return text;
		}

		/// <summary>
		///       保存对象内容到一个XML文件中
		///       </summary>
		/// <param name="strFileName">XML文件名</param>
		public void Save(string strFileName)
		{
			XmlTextWriter xmlTextWriter = new XmlTextWriter(strFileName, Encoding.UTF8);
			xmlTextWriter.Indentation = 3;
			xmlTextWriter.IndentChar = ' ';
			xmlTextWriter.Formatting = Formatting.Indented;
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(xmlTextWriter, this);
			xmlTextWriter.Close();
		}

		/// <summary>
		///       向错误报告发送页面发送错误报告XML文档,本函数会进行错误处理，不会显示提示信息,若发送成功会清空内部的错误信息
		///       </summary>
		/// <returns>发送是否成功</returns>
		public bool SendReport()
		{
			int num = 18;
			if (IsReportURLOK)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(CreateXMLString());
				WebClient webClient = new WebClient();
				webClient.UploadData(ReportURL, "POST", bytes);
				webClient.Dispose();
				return true;
			}
			return false;
		}
	}
}
