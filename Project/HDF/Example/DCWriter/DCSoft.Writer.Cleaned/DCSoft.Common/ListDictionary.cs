using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       基于列表方式的字典类型
	                                                                    ///       </summary>
	                                                                    /// <remarks>本字典内部采用列表方式来实现，速度慢，但能保持关键字的添加顺序。
	                                                                    ///       编制 袁永福</remarks>
	[Serializable]
	[ComVisible(false)]
	public class ListDictionary<TKey, TValue>
	{
		private class ListItem<TKey2, TValue2>
		{
			public TKey2 _Key = default(TKey2);

			public TValue2 _Value = default(TValue2);
		}

		private List<ListItem<TKey, TValue>> _Items = new List<ListItem<TKey, TValue>>();

		                                                                    /// <summary>
		                                                                    ///       字典中项目的个数
		                                                                    ///       </summary>
		public int Count => _Items.Count;

		                                                                    /// <summary>
		                                                                    ///       获得所有的键值
		                                                                    ///       </summary>
		public List<TKey> Keys
		{
			get
			{
				List<TKey> list = new List<TKey>();
				foreach (ListItem<TKey, TValue> item in _Items)
				{
					list.Add(item._Key);
				}
				return list;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得所有的数值
		                                                                    ///       </summary>
		public List<TValue> Values
		{
			get
			{
				List<TValue> list = new List<TValue>();
				foreach (ListItem<TKey, TValue> item in _Items)
				{
					list.Add(item._Value);
				}
				return list;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       设置/获得指定的键值对应的数值
		                                                                    ///       </summary>
		                                                                    /// <param name="keyValue">键值</param>
		                                                                    /// <returns>数值</returns>
		public TValue this[TKey keyValue]
		{
			get
			{
				int num = 19;
				if (keyValue == null)
				{
					throw new ArgumentNullException("keyValue");
				}
				ListItem<TKey, TValue> item = GetItem(keyValue);
				if (item == null)
				{
					return default(TValue);
				}
				return item._Value;
			}
			set
			{
				ListItem<TKey, TValue> item = GetItem(keyValue);
				if (item == null)
				{
					item = new ListItem<TKey, TValue>();
					item._Key = keyValue;
					item._Value = value;
					_Items.Add(item);
				}
				else
				{
					item._Value = value;
				}
			}
		}

		                                                                    /// <summary>
		                                                                    ///       清空字典
		                                                                    ///       </summary>
		public void Clear()
		{
			_Items.Clear();
		}

		private ListItem<TKey, TValue> GetItem(TKey keyValue)
		{
			foreach (ListItem<TKey, TValue> item in _Items)
			{
				if (item._Key.Equals(keyValue))
				{
					return item;
				}
			}
			return null;
		}

		                                                                    /// <summary>
		                                                                    ///       删除指定的键值
		                                                                    ///       </summary>
		                                                                    /// <param name="keyValue">
		                                                                    /// </param>
		public void Remove(TKey keyValue)
		{
			ListItem<TKey, TValue> item = GetItem(keyValue);
			if (item != null)
			{
				_Items.Remove(item);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       判断是否存在指定的键值
		                                                                    ///       </summary>
		                                                                    /// <param name="keyValue">键值</param>
		                                                                    /// <returns>是否存在指定的键值</returns>
		public bool ContainsKey(TKey keyValue)
		{
			return GetItem(keyValue) != null;
		}
	}
}
