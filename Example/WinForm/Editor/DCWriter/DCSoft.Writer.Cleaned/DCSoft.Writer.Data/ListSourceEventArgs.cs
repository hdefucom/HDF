using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       列表项目事件参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IListSourceEventArgs))]
	[ComClass("A86C02C1-8CD2-4BF8-AF73-CEA4D4FD65C2", "D277A42C-60D7-4E35-B466-2AEE388EA5FF")]
	[ComVisible(true)]
	[Guid("A86C02C1-8CD2-4BF8-AF73-CEA4D4FD65C2")]
	public class ListSourceEventArgs : EventArgs, IListSourceEventArgs
	{
		internal const string CLASSID = "A86C02C1-8CD2-4BF8-AF73-CEA4D4FD65C2";

		internal const string CLASSID_Interface = "D277A42C-60D7-4E35-B466-2AEE388EA5FF";

		private WriterAppHost _Host = null;

		private IServiceProvider _Services = null;

		private ListSourceInfo _Info = null;

		private object _Value = null;

		/// <summary>
		///       编辑器程序宿主对象
		///       </summary>
		public WriterAppHost Host
		{
			get
			{
				return _Host;
			}
			set
			{
				_Host = value;
			}
		}

		/// <summary>
		///       服务器容器对象
		///       </summary>
		[ComVisible(false)]
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
		///       列表项目来源信息对象
		///       </summary>
		public ListSourceInfo Info
		{
			get
			{
				return _Info;
			}
			set
			{
				_Info = value;
			}
		}

		/// <summary>
		///       当前列表值
		///       </summary>
		public object Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="host">宿主对象</param>
		/// <param name="services">服务对象列表</param>
		/// <param name="info">信息对象</param>
		public ListSourceEventArgs(WriterAppHost host, IServiceProvider services, ListSourceInfo info)
		{
			_Host = host;
			_Services = services;
			_Info = info;
		}
	}
}
