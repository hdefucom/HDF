using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ZYCommon
{
	public class ZYErrorReport
	{
		private static ZYErrorReport myInstance = new ZYErrorReport();

		private bool bolGetDebugPrint = false;

		private NameValueList myAttributes = new NameValueList();

		public DateTime LogTime = ZYTime.GetServerTime();

		public string SystemName = "";

		public string OperatorName = "";

		public Image AppImage = null;

		public Type SourceType = null;

		public object SourceObject = null;

		public string MemberName = null;

		public Exception SourceException = null;

		public string LogFile = null;

		public string ReportURL = null;

		public string UserMessage = null;

		private ConsoleBuffer myDebugPrintBuffer = new ConsoleBuffer();

		public static ZYErrorReport Instance => myInstance;

		public bool GetDebugPrint
		{
			get
			{
				return bolGetDebugPrint;
			}
			set
			{
				bolGetDebugPrint = value;
			}
		}

		public ConsoleBuffer DebugPrintBuffer => myDebugPrintBuffer;

		public void SetAttribute(string strName, string strValue)
		{
			myAttributes.SetValue(strName, strValue);
		}

		public void Clear()
		{
			SourceType = null;
			MemberName = null;
			SourceException = null;
			myAttributes.Clear();
			LogTime = ZYTime.GetServerTime();
		}

		public void ClearDebugPrint()
		{
			myDebugPrintBuffer.Clear();
		}

		public void DebugPrint(string strText)
		{
			Console.WriteLine(strText);
			if (bolGetDebugPrint)
			{
				myDebugPrintBuffer.WriteLine(strText);
			}
		}

		public string GetEnvironmentDesc()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string executablePath = Application.ExecutablePath;
			stringBuilder.Append("\r\n 主程序:" + executablePath);
			try
			{
				FileInfo fileInfo = new FileInfo(executablePath);
				stringBuilder.Append("\r\n 主程序信息 创建时间:" + fileInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"));
				stringBuilder.Append(" 修改时间:" + fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
				stringBuilder.Append(" 最后读取时间:" + fileInfo.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss"));
				stringBuilder.Append(" 文件属性:" + fileInfo.Attributes);
				stringBuilder.Append(" 长度:" + fileInfo.Length);
			}
			catch (Exception ex)
			{
				stringBuilder.Append("获取文件 " + executablePath + " 信息时错误" + ex.ToString());
			}
			try
			{
				stringBuilder.Append("\r\n 主程序名称:" + Application.ProductName);
				stringBuilder.Append("\r\n 主程序版本:" + Application.ProductVersion);
				stringBuilder.Append("\r\n 时间擢    :" + Environment.TickCount);
				stringBuilder.Append("\r\n 命令行    :" + Environment.CommandLine);
				stringBuilder.Append("\r\n 当前目录  :" + Environment.CurrentDirectory);
				stringBuilder.Append("\r\n 计算机名  :" + Environment.MachineName);
				stringBuilder.Append("\r\n 操作系统  :" + Environment.OSVersion.ToString());
				stringBuilder.Append("\r\n 系统目录  :" + Environment.SystemDirectory);
				stringBuilder.Append("\r\n 网络域名  :" + Environment.UserDomainName);
				stringBuilder.Append("\r\n 互换模式  :" + Environment.UserInteractive);
				stringBuilder.Append("\r\n 用户名    :" + Environment.UserName);
				stringBuilder.Append("\r\n 运行库    :" + Environment.Version);
				stringBuilder.Append("\r\n 所用物理内存:" + Environment.WorkingSet);
				stringBuilder.Append("\r\n 环境变量 -----------------------------------");
				IDictionary environmentVariables = Environment.GetEnvironmentVariables();
				IDictionaryEnumerator enumerator = environmentVariables.GetEnumerator();
				while (enumerator.MoveNext())
				{
					stringBuilder.Append(string.Concat("\r\n     ", enumerator.Key, "=", enumerator.Value));
				}
				stringBuilder.Append("\r\n 当前进程信息 -------------------------------");
				Process currentProcess = Process.GetCurrentProcess();
				currentProcess.Refresh();
				stringBuilder.Append("\r\n     优先级   :" + currentProcess.BasePriority);
				stringBuilder.Append("\r\n     句柄     :" + currentProcess.Handle);
				stringBuilder.Append("\r\n     句柄计数 :" + currentProcess.HandleCount);
				stringBuilder.Append("\r\n     进程编号 :" + currentProcess.Id);
				stringBuilder.Append("\r\n     进程名   :" + currentProcess.ProcessName);
				stringBuilder.Append("\r\n     主模块   :" + currentProcess.MainModule);
				stringBuilder.Append("\r\n     虚拟内存 :" + currentProcess.VirtualMemorySize);
				stringBuilder.Append("\r\n     物理内存 :" + currentProcess.WorkingSet);
				stringBuilder.Append("\r\n     启动时间 :" + currentProcess.StartTime);
				stringBuilder.Append("\r\n     已运行时间    :" + (DateTime.Now - currentProcess.StartTime));
				stringBuilder.Append("\r\n     主窗体句柄    :" + currentProcess.MainWindowHandle);
				stringBuilder.Append("\r\n     主窗体标题    :" + currentProcess.MainWindowTitle);
				stringBuilder.Append("\r\n     工作集峰值    :" + currentProcess.PeakWorkingSet);
				stringBuilder.Append("\r\n     允许最大工作集:" + currentProcess.MaxWorkingSet);
				stringBuilder.Append("\r\n     允许最小工作集:" + currentProcess.MinWorkingSet);
				stringBuilder.Append("\r\n     虚拟内存峰值  :" + currentProcess.PeakVirtualMemorySize);
				stringBuilder.Append("\r\n     专用内存大小  :" + currentProcess.PrivateMemorySize);
				stringBuilder.Append("\r\n     总处理器时间  :" + currentProcess.TotalProcessorTime);
				stringBuilder.Append("\r\n     用户处理器时间:" + currentProcess.UserProcessorTime);
			}
			catch (Exception ex)
			{
				stringBuilder.Append("\r\n 读取系统信息错误" + ex.ToString());
			}
			return stringBuilder.ToString();
		}

		public string CreateReportXML(bool bolIndent)
		{
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			if (bolIndent)
			{
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.IndentChar = ' ';
				xmlTextWriter.Indentation = 4;
			}
			CreateReportXML(xmlTextWriter);
			xmlTextWriter.Flush();
			string text = stringWriter.ToString();
			xmlTextWriter.Close();
			int num = text.IndexOf("?>");
			if (num > 0)
			{
				text = text.Substring(num + 2);
			}
			return text;
		}

		public void CreateReportXML(XmlTextWriter myXMLWriter)
		{
			myXMLWriter.WriteStartDocument();
			myXMLWriter.WriteStartElement("errorreport");
			myXMLWriter.WriteAttributeString("version", "1.0");
			myXMLWriter.WriteElementString("报告器版本", GetType().AssemblyQualifiedName);
			myXMLWriter.WriteElementString("报告器位置", GetType().Assembly.Location);
			myXMLWriter.WriteElementString("来源", GetType().Assembly.CodeBase);
			myXMLWriter.WriteElementString("报告时间", LogTime.ToString("yyyy-MM-dd HH:mm:ss"));
			myXMLWriter.WriteElementString("系统名称", SystemName);
			myXMLWriter.WriteElementString("当前用户", OperatorName);
			myXMLWriter.WriteElementString("用户信息", UserMessage);
			if (MemberName != null)
			{
				myXMLWriter.WriteElementString("发生错误的对象成员名称", MemberName);
			}
			if (SourceException != null)
			{
				myXMLWriter.WriteStartElement("用户错误");
				myXMLWriter.WriteCData(SourceException.ToString());
				myXMLWriter.WriteEndElement();
			}
			if (myAttributes.Count > 0)
			{
				myXMLWriter.WriteStartElement("报告属性");
				for (int i = 0; i < myAttributes.Count; i++)
				{
					myXMLWriter.WriteStartElement("value");
					myXMLWriter.WriteAttributeString("name", myAttributes.GetName(i));
					myXMLWriter.WriteAttributeString("value", myAttributes.GetValue(i));
					myXMLWriter.WriteEndElement();
				}
				myXMLWriter.WriteEndElement();
			}
			myXMLWriter.WriteStartElement("系统调试输出信息");
			myXMLWriter.WriteCData(myDebugPrintBuffer.ToString());
			myXMLWriter.WriteEndElement();
			myXMLWriter.WriteStartElement("系统环境");
			myXMLWriter.WriteCData(GetEnvironmentDesc());
			myXMLWriter.WriteEndElement();
			if (SourceObject != null)
			{
				SourceType = SourceObject.GetType();
			}
			if (SourceType != null)
			{
				myXMLWriter.WriteStartElement("发生错误的类型");
				myXMLWriter.WriteAttributeString("名称", SourceType.Name);
				myXMLWriter.WriteAttributeString("程序集", SourceType.Assembly.FullName);
				myXMLWriter.WriteStartElement("成员列表");
				MemberInfo[] members = SourceType.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance);
				MemberInfo[] array = members;
				foreach (MemberInfo memberInfo in array)
				{
					bool flag = false;
					try
					{
						ParameterInfo[] array2 = null;
						if (memberInfo is FieldInfo)
						{
							flag = true;
							FieldInfo fieldInfo = memberInfo as FieldInfo;
							myXMLWriter.WriteStartElement("字段");
							myXMLWriter.WriteAttributeString("name", memberInfo.Name);
							if (SourceObject != null)
							{
								myXMLWriter.WriteAttributeString("数值", (fieldInfo.GetValue(SourceObject) == null) ? "[null]" : fieldInfo.GetValue(SourceObject).ToString());
							}
							myXMLWriter.WriteAttributeString("类型", fieldInfo.FieldType.ToString());
							myXMLWriter.WriteStartAttribute("属性", null);
							if (fieldInfo.IsInitOnly)
							{
								myXMLWriter.WriteString(" initonly ");
							}
							if (fieldInfo.IsPrivate)
							{
								myXMLWriter.WriteString(" private ");
							}
							if (fieldInfo.IsPublic)
							{
								myXMLWriter.WriteString(" public ");
							}
							if (fieldInfo.IsSpecialName)
							{
								myXMLWriter.WriteString(" specialname ");
							}
							if (fieldInfo.IsStatic)
							{
								myXMLWriter.WriteString(" static ");
							}
							myXMLWriter.WriteEndAttribute();
						}
						if (memberInfo is PropertyInfo)
						{
							flag = true;
							PropertyInfo propertyInfo = memberInfo as PropertyInfo;
							myXMLWriter.WriteStartElement("属性");
							myXMLWriter.WriteAttributeString("name", memberInfo.Name);
							if (SourceObject != null && propertyInfo.CanRead)
							{
								myXMLWriter.WriteAttributeString("数值", (propertyInfo.GetValue(SourceObject, null) == null) ? "[null]" : propertyInfo.GetValue(SourceObject, null).ToString());
							}
							myXMLWriter.WriteAttributeString("类型", propertyInfo.PropertyType.ToString());
							myXMLWriter.WriteStartAttribute("属性", null);
							if (propertyInfo.CanRead)
							{
								myXMLWriter.WriteString(" read ");
							}
							if (propertyInfo.CanWrite)
							{
								myXMLWriter.WriteString(" write ");
							}
							if (propertyInfo.IsSpecialName)
							{
								myXMLWriter.WriteString(" specialname ");
							}
							myXMLWriter.WriteEndAttribute();
						}
						if (array2 != null)
						{
							ParameterInfo[] array3 = array2;
							foreach (ParameterInfo parameterInfo in array3)
							{
								myXMLWriter.WriteStartElement("参数");
								myXMLWriter.WriteAttributeString("名称", parameterInfo.Name);
								myXMLWriter.WriteAttributeString("类型", parameterInfo.ParameterType.ToString());
								myXMLWriter.WriteStartAttribute("属性", null);
								if (parameterInfo.IsOptional)
								{
									myXMLWriter.WriteString(" optional ");
								}
								if (parameterInfo.IsOut)
								{
									myXMLWriter.WriteString(" out ");
								}
								if (parameterInfo.IsIn)
								{
									myXMLWriter.WriteString(" in ");
								}
								if (parameterInfo.IsRetval)
								{
									myXMLWriter.WriteString(" retval ");
								}
								myXMLWriter.WriteEndAttribute();
								myXMLWriter.WriteEndElement();
							}
						}
					}
					catch (Exception ex)
					{
						myXMLWriter.WriteString("获取成员信息错误:" + ex.Message);
					}
					if (flag)
					{
						myXMLWriter.WriteEndElement();
					}
				}
			}
			myXMLWriter.WriteEndElement();
			myXMLWriter.WriteEndDocument();
		}

		public bool SendReportError()
		{
			if (StringCommon.isBlankString(ReportURL))
			{
				return false;
			}
			try
			{
				ArrayList httpPostEncoding = XMLHttpConnection.GetHttpPostEncoding(PostReportData);
				if (httpPostEncoding != null)
				{
					string s = CreateReportXML(bolIndent: false);
					Encoding encoding = httpPostEncoding[0] as Encoding;
					byte[] bytes = encoding.GetBytes(s);
					PostReportData(bytes);
					Clear();
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private byte[] PostReportData(byte[] bytSend)
		{
			return CommonFunction.HttpPostData(ReportURL, bytSend, null, null);
		}

		public void ReportError()
		{
			ShowErrorDialog();
			Clear();
		}

		public void ShowErrorDialog()
		{
			using (dlgError dlgError = new dlgError())
			{
				dlgError.ErrorReport = this;
				dlgError.ShowDialog();
			}
		}
	}
}
