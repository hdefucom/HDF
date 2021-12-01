using DCSoftDotfuscate;
using System;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	/// <summary>
	///       系统软件信息
	///       </summary>
	[Serializable]
	public class SystemSoftwareInfo
	{
		/// <summary>
		///       时间戳
		///       </summary>
		[XmlElement("时间戳")]
		public int TickCount = Environment.TickCount;

		/// <summary>
		///       命令行
		///       </summary>
		[XmlElement("命令行")]
		public string CommandLine = Environment.CommandLine;

		/// <summary>
		///       当前目录
		///       </summary>
		[XmlElement("当前目录")]
		public string CurrentDirectory = Environment.CurrentDirectory;

		/// <summary>
		///       计算机名
		///       </summary>
		[XmlElement("计算机名")]
		public string MachineName = Environment.MachineName;

		/// <summary>
		///       用户名
		///       </summary>
		[XmlElement("用户名")]
		public string UserName = Environment.UserName;

		/// <summary>
		///       操作系统
		///       </summary>
		[XmlElement("操作系统")]
		public string OSVersion = Environment.OSVersion.ToString();

		/// <summary>
		///       系统目录
		///       </summary>
		[XmlElement("系统目录")]
		public string SystemDirectory = Environment.SystemDirectory;

		/// <summary>
		///       网络名称
		///       </summary>
		[XmlElement("网络名称")]
		public string UserDoaminName = Environment.UserDomainName;

		/// <summary>
		///       用户互换模式
		///       </summary>
		[XmlElement("用户互换模式")]
		public bool UserInteractive = Environment.UserInteractive;

		/// <summary>
		///       运行库版本
		///       </summary>
		[XmlElement("运行库版本")]
		public string RuntimeVersion = Environment.Version.ToString();

		/// <summary>
		///       所用物理内存
		///       </summary>
		[XmlElement("所用物理内存")]
		public long WorkingSet = Environment.WorkingSet;

		/// <summary>
		///       IE版本
		///       </summary>
		[XmlElement("IE版本")]
		public string IEVersion = GClass286.smethod_6();

		public SystemSoftwareInfo()
		{
			string str = Convert.ToString(GClass274.smethod_0("Win32_OperatingSystem", "Caption"));
			str = (OSVersion = str + " " + Convert.ToString(GClass274.smethod_0("Win32_OperatingSystem", "CSDVersion")));
		}
	}
}
