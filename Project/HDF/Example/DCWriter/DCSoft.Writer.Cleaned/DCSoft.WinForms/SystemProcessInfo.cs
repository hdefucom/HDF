using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	/// <summary>
	///       进程信息对象
	///       </summary>
	[Serializable]
	public class SystemProcessInfo
	{
		/// <summary>
		///       错误信息
		///       </summary>
		[XmlElement("A错误信息")]
		public string Error;

		/// <summary>
		///       基本优先级
		///       </summary>
		[XmlElement("基本优先级")]
		public int BasePriority;

		/// <summary>
		///       进程名
		///       </summary>
		[XmlElement("进程名")]
		public string ProcessName;

		/// <summary>
		///       主模块信息
		///       </summary>
		[XmlElement("主模块信息")]
		public string MainModule;

		/// <summary>
		///       虚拟内存
		///       </summary>
		[XmlElement("虚拟内存")]
		public int VirtualMemorySize;

		/// <summary>
		///       物理内存
		///       </summary>
		[XmlElement("物理内存")]
		public int WorkingSet;

		/// <summary>
		///       启动时间
		///       </summary>
		[XmlElement("启动时间")]
		public string StartTime;

		/// <summary>
		///       已运行时间
		///       </summary>
		[XmlElement("已运行时间")]
		public string SpendTime;

		/// <summary>
		///       主窗体文本
		///       </summary>
		[XmlElement("主窗体文本")]
		public string MainWindowTitle;

		/// <summary>
		///       总处理器时间
		///       </summary>
		[XmlElement("总处理器时间")]
		public string TotalProcessorTime;

		/// <summary>
		///       用户处理器时间
		///       </summary>
		[XmlElement("用户处理器时间")]
		public string UserProcessorTime;

		/// <summary>
		///       初始化对象
		///       </summary>
		public SystemProcessInfo()
		{
			Error = null;
			BasePriority = 0;
			ProcessName = null;
			MainModule = null;
			VirtualMemorySize = 0;
			WorkingSet = 0;
			StartTime = null;
			SpendTime = null;
			MainWindowTitle = null;
			TotalProcessorTime = null;
			UserProcessorTime = null;
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="process">进程对象</param>
		public SystemProcessInfo(Process process)
		{
			int num = 18;
			Error = null;
			BasePriority = 0;
			ProcessName = null;
			MainModule = null;
			VirtualMemorySize = 0;
			WorkingSet = 0;
			StartTime = null;
			SpendTime = null;
			MainWindowTitle = null;
			TotalProcessorTime = null;
			UserProcessorTime = null;
			
			try
			{
				BasePriority = process.BasePriority;
				ProcessName = process.ProcessName;
				MainModule = process.MainModule.ToString();
				VirtualMemorySize = (int)process.VirtualMemorySize64;
				WorkingSet = (int)process.WorkingSet64;
				StartTime = process.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
				SpendTime = Convert.ToString(DateTime.Now - process.StartTime);
				MainWindowTitle = process.MainWindowTitle;
				TotalProcessorTime = process.TotalProcessorTime.ToString();
				UserProcessorTime = process.UserProcessorTime.ToString();
			}
			catch (Exception ex)
			{
				Error = ex.Message;
			}
		}
	}
}
