using System.Diagnostics;
using System.Xml.Serialization;

namespace DCSoft.WinForms
{
	/// <summary>
	///       进程模块信息对象
	///       </summary>
	public class SystemProcessModuleInfo
	{
		/// <summary>
		///       名称
		///       </summary>
		[XmlElement("名称")]
		public string Name;

		/// <summary>
		///       文件名
		///       </summary>
		[XmlElement("文件名")]
		public string FileName;

		/// <summary>
		///       版本
		///       </summary>
		[XmlElement("版本")]
		public string Version;

		/// <summary>
		///       初始化对象
		///       </summary>
		public SystemProcessModuleInfo()
		{
			Name = null;
			FileName = null;
			Version = null;
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="mod">模板对象</param>
		public SystemProcessModuleInfo(ProcessModule processModule_0)
		{
			int num = 10;
			Name = null;
			FileName = null;
			Version = null;
			
			Name = processModule_0.ModuleName;
			FileName = processModule_0.FileName;
			if (processModule_0.FileVersionInfo != null)
			{
				Version = processModule_0.FileVersionInfo.FileVersion + " " + processModule_0.FileVersionInfo.ProductName;
			}
		}
	}
}
