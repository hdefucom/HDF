using DCSoft.Common;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       文件系统事件参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	
	public class VFileSystemEventArgs : EventArgs
	{
		private KBEntry _KBEntry = null;

		private IWin32Window _ParentWindow = null;

		private WriterAppHost _AppHost = null;

		private IServiceProvider _Services = null;

		private string _FileName = null;

		private string _FileSystemName = null;

		private string _FileFormat = null;

		/// <summary>
		///       相关的知识节点对象
		///       </summary>
		public KBEntry KBEntry
		{
			get
			{
				return _KBEntry;
			}
			set
			{
				_KBEntry = value;
			}
		}

		/// <summary>
		///       父窗体对象
		///       </summary>
		public IWin32Window ParentWindow
		{
			get
			{
				return _ParentWindow;
			}
			set
			{
				_ParentWindow = value;
			}
		}

		/// <summary>
		///       宿主
		///       </summary>
		public WriterAppHost AppHost
		{
			get
			{
				return _AppHost;
			}
			set
			{
				_AppHost = value;
			}
		}

		/// <summary>
		///       服务器对象提供者
		///       </summary>
		public IServiceProvider Services
		{
			get
			{
				return _Services;
			}
			set
			{
				_Services = value;
			}
		}

		/// <summary>
		///       文件名
		///       </summary>
		public string FileName
		{
			get
			{
				return _FileName;
			}
			set
			{
				_FileName = value;
			}
		}

		/// <summary>
		///       文件系统名称
		///       </summary>
		public string FileSystemName
		{
			get
			{
				return _FileSystemName;
			}
			set
			{
				_FileSystemName = value;
			}
		}

		/// <summary>
		///       文件格式
		///       </summary>
		public string FileFormat
		{
			get
			{
				return _FileFormat;
			}
			set
			{
				_FileFormat = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="host">编辑器宿主对象</param>
		/// <param name="parentWindow">父窗体对象</param>
		/// <param name="services">服务对象提供者</param>
		/// <param name="fileName">文件名</param>
		public VFileSystemEventArgs(WriterAppHost host, IWin32Window parentWindow, IServiceProvider services, string fileName)
		{
			_AppHost = host;
			_ParentWindow = parentWindow;
			_Services = services;
			_FileName = fileName;
		}
	}
}
