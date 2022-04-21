#define DEBUG
using DCSoft.Common;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       应用程序错误报告者
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[ComVisible(false)]
	public class ErrorReporter
	{
		private static string _ReportServiceUrl = null;

		/// <summary>
		///       错误报告页面地址
		///       </summary>
		public static string ReportServiceUrl
		{
			get
			{
				return _ReportServiceUrl;
			}
			set
			{
				_ReportServiceUrl = value;
			}
		}

		/// <summary>
		///       报告错误
		///       </summary>
		/// <param name="parentForm">窗体</param>
		/// <param name="sourceType">错误来源类型</param>
		/// <param name="userMessage">用户信息</param>
		/// <param name="ext">异常信息</param>
		private static void ReportError(IWin32Window parentForm, Type sourceType, string userMessage, Exception exception_0)
		{
			int num = 8;
			ErrorReportInfo reportInfo = CreateInfo(sourceType, userMessage, exception_0);
			string text = WriterStringsCore.Error + ":" + userMessage;
			if (exception_0 != null)
			{
				text = text + " " + exception_0.Message;
			}
			Debug.WriteLine(text);
			if (Environment.UserInteractive)
			{
				using (dlgError dlgError = new dlgError())
				{
					dlgError.ReportInfo = reportInfo;
					dlgError.ShowDialog(parentForm);
				}
			}
		}

		/// <summary>
		///       报告错误
		///       </summary>
		/// <param name="parentWindow">父窗体对象</param>
		/// <param name="message">错误信息</param>
		/// <param name="details">错误详细信息</param>
		public static void ReportError(IWin32Window parentWindow, string message, string details)
		{
			int num = 4;
			ErrorReportInfo errorReportInfo = CreateInfo(null, message, null);
			errorReportInfo.UserMessage = message;
			errorReportInfo.SystemMessage = details;
			string text = WriterStringsCore.Error + ":" + message;
			if (details != null)
			{
				text = text + " " + details;
			}
			Debug.WriteLine(text);
			if (parentWindow is WriterControl)
			{
				WriterControl writerControl = (WriterControl)parentWindow;
				WriterReportErrorEventArgs writerReportErrorEventArgs = new WriterReportErrorEventArgs(writerControl, writerControl.Document, null, message, details);
				writerControl.vmethod_20(writerReportErrorEventArgs);
				if (writerReportErrorEventArgs.Handled)
				{
					return;
				}
			}
			if (Environment.UserInteractive)
			{
				using (dlgError dlgError = new dlgError())
				{
					dlgError.ReportInfo = errorReportInfo;
					if (parentWindow is WriterControl)
					{
						WriterControl.UIShowDialog((WriterControl)parentWindow, dlgError, null);
					}
					else
					{
						dlgError.ShowDialog(parentWindow);
					}
				}
			}
		}

		/// <summary>
		///       创建报告
		///       </summary>
		/// <param name="sourceType">来源类型</param>
		/// <param name="userMessage">用户信息</param>
		/// <param name="ext">错误信息</param>
		/// <returns>创建的对象</returns>
		public static ErrorReportInfo CreateInfo(Type sourceType, string userMessage, Exception exception_0)
		{
			ErrorReportInfo errorReportInfo = new ErrorReportInfo();
			errorReportInfo.UserMessage = userMessage;
			try
			{
				errorReportInfo.ApplicationName = Application.ProductName;
			}
			catch (Exception ex)
			{
				errorReportInfo.ApplicationName = ex.Message;
			}
			try
			{
				errorReportInfo.AppVersion = Application.ProductVersion;
			}
			catch (Exception ex2)
			{
				errorReportInfo.AppVersion = ex2.Message;
			}
			try
			{
				errorReportInfo.CommandLine = Environment.CommandLine;
			}
			catch (Exception ex2)
			{
				errorReportInfo.CommandLine = ex2.Message;
			}
			try
			{
				errorReportInfo.AppPath = Application.ExecutablePath;
			}
			catch (Exception ex3)
			{
				errorReportInfo.AppPath = ex3.Message;
			}
			try
			{
				errorReportInfo.OSVersion = Environment.OSVersion.ToString();
			}
			catch (Exception ex3)
			{
				errorReportInfo.OSVersion = ex3.Message;
			}
			try
			{
				errorReportInfo.RuntimeVersion = Environment.Version.ToString();
			}
			catch (Exception ex3)
			{
				errorReportInfo.RuntimeVersion = ex3.Message;
			}
			if (exception_0 != null)
			{
				errorReportInfo.ExceptionString = exception_0.ToString();
				errorReportInfo.SystemMessage = exception_0.Message;
			}
			if (sourceType != null)
			{
				errorReportInfo.SourceType = sourceType.FullName;
				AssemblyName assemblyName = new AssemblyName(sourceType.Assembly.FullName);
				errorReportInfo.SourceModuleName = assemblyName.Name;
				errorReportInfo.SourceModuleVersion = assemblyName.Version.ToString();
				errorReportInfo.SourceModuleCodeBase = sourceType.Assembly.CodeBase;
			}
			return errorReportInfo;
		}
	}
}
