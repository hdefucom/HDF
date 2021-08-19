using DCSoft.Writer.Data;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Extension.Data
{
	/// <summary>
	///       知识库节点存储事件参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class KBStoreEventArgs : EventArgs
	{
		private KBEntry _Entry = null;

		private KBEntry _Parent = null;

		private KBLibrary _Library = null;

		private IServiceProvider _Services = null;

		/// <summary>
		///       操作的知识库节点对象
		///       </summary>
		public KBEntry Entry
		{
			get
			{
				return _Entry;
			}
			set
			{
				_Entry = value;
			}
		}

		/// <summary>
		///       父节点对象
		///       </summary>
		public KBEntry Parent
		{
			get
			{
				return _Parent;
			}
			set
			{
				_Parent = value;
			}
		}

		/// <summary>
		///       知识库节点对象
		///       </summary>
		public KBLibrary Library
		{
			get
			{
				return _Library;
			}
			set
			{
				_Library = value;
			}
		}

		/// <summary>
		///       服务对象列表
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
	}
}
