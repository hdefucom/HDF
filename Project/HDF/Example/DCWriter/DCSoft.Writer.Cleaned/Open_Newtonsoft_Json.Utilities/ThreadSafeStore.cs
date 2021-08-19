using Open_Newtonsoft_Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Open_Newtonsoft_Json.Utilities
{
	[ComVisible(false)]
	internal class ThreadSafeStore<TKey, TValue>
	{
		private readonly object _lock;

		private Dictionary<TKey, TValue> _store;

		private readonly Func<TKey, TValue> _creator;

		public ThreadSafeStore(Func<TKey, TValue> creator)
		{
			int num = 17;
			_lock = new object();
			
			if (creator == null)
			{
				throw new ArgumentNullException("creator");
			}
			_creator = creator;
			_store = new Dictionary<TKey, TValue>();
		}

		public TValue Get(TKey gparam_0)
		{
			if (!_store.TryGetValue(gparam_0, out TValue value))
			{
				return AddValue(gparam_0);
			}
			return value;
		}

		private TValue AddValue(TKey gparam_0)
		{
			TValue val = _creator(gparam_0);
			lock (_lock)
			{
				if (_store == null)
				{
					_store = new Dictionary<TKey, TValue>();
					_store[gparam_0] = val;
				}
				else
				{
					if (_store.TryGetValue(gparam_0, out TValue value))
					{
						return value;
					}
					Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(_store);
					dictionary[gparam_0] = val;
					Thread.MemoryBarrier();
					_store = dictionary;
				}
				return val;
			}
		}
	}
}
