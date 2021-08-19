using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       服务对象缓存区
	                                                                    ///       </summary>
	                                                                    /// <typeparam name="TService">
	                                                                    /// </typeparam>
	[ComVisible(false)]
	public abstract class DCServiceSpooler<TService>
	{
		private class StateItem
		{
			public TService Service = default(TService);

			public bool InUse = false;

			public int ReferenceCount = 0;

			public DateTime LastAccessTime = DateTime.MinValue;
		}

		private volatile List<StateItem> _Items = new List<StateItem>();

		private int _ContentVersion = 0;

		public int Count => _Items.Count;

		                                                                    /// <summary>
		                                                                    ///       内容版本号
		                                                                    ///       </summary>
		public int ContentVersion
		{
			get
			{
				return _ContentVersion;
			}
			set
			{
				_ContentVersion = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       清空缓存区
		                                                                    ///       </summary>
		public void Clear()
		{
			lock (this)
			{
				List<StateItem> items = _Items;
				_Items = new List<StateItem>();
				foreach (StateItem item in items)
				{
					FinalizeInstance(item.Service);
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       创建一个对象实例
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		protected abstract TService CreateInstance();

		protected virtual void FinalizeInstance(TService instance)
		{
		}

		                                                                    /// <summary>
		                                                                    ///       获得一个服务对象实例
		                                                                    ///       </summary>
		                                                                    /// <returns>获得的对象实例</returns>
		public TService GetService()
		{
			int num = 6;
			lock (this)
			{
				foreach (StateItem item in _Items)
				{
					if (!item.InUse)
					{
						item.InUse = true;
						item.LastAccessTime = DateTime.Now;
						item.ReferenceCount++;
						return item.Service;
					}
				}
				StateItem stateItem = new StateItem();
				stateItem.Service = CreateInstance();
				if (stateItem.Service == null)
				{
					throw new Exception("未能创建类型" + typeof(TService).FullName);
				}
				stateItem.LastAccessTime = DateTime.Now;
				stateItem.ReferenceCount = 1;
				_Items.Add(stateItem);
				return stateItem.Service;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       释放服务对象实例
		                                                                    ///       </summary>
		                                                                    /// <param name="instance">对象实例</param>
		                                                                    /// <returns>操作是否成功</returns>
		public bool ReleaseService(TService instance)
		{
			int num = 0;
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			lock (this)
			{
				foreach (StateItem item in _Items)
				{
					if (item.Service.Equals(instance))
					{
						item.InUse = false;
						return true;
					}
				}
			}
			return false;
		}
	}
}
