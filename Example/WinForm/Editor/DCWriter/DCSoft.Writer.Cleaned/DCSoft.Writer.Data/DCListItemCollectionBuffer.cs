using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       列表对象缓存对象
	///       </summary>
	[ComVisible(false)]
	
	public class DCListItemCollectionBuffer
	{
		private Dictionary<string, ListItemCollection> _Items = new Dictionary<string, ListItemCollection>();

		private static Dictionary<string, ListItemCollection> _GlobalItems = new Dictionary<string, ListItemCollection>();

		private void CheckInstance()
		{
			if (_Items == null)
			{
				_Items = new Dictionary<string, ListItemCollection>();
			}
			if (_GlobalItems == null)
			{
				_GlobalItems = new Dictionary<string, ListItemCollection>();
			}
		}

		/// <summary>
		///       添加列表对象
		///       </summary>
		/// <param name="name">保存的名称</param>
		/// <param name="items">列表对象</param>
		/// <param name="globalItems">是否为全局缓存</param>
		public void AddItems(string name, ListItemCollection items, bool globalItems)
		{
			CheckInstance();
			if (string.IsNullOrEmpty(name))
			{
				name = "";
			}
			if (globalItems)
			{
				_GlobalItems[name] = items;
			}
			else
			{
				_Items[name] = items;
			}
		}

		/// <summary>
		///       获得指定名称的列表对象
		///       </summary>
		/// <param name="name">名称</param>
		/// <returns>获得的列表对象</returns>
		public ListItemCollection GetItems(string name)
		{
			try
			{
				if (name == null || string.IsNullOrEmpty(name))
				{
					return null;
				}
				CheckInstance();
				if (_GlobalItems.ContainsKey(name))
				{
					return _GlobalItems[name];
				}
				if (_Items.ContainsKey(name))
				{
					return _Items[name];
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		/// <summary>
		///       获得所有缓存的列表对象的名称
		///       </summary>
		/// <returns>名称组成的数组</returns>
		public string[] GetItemsName()
		{
			CheckInstance();
			List<string> list = new List<string>();
			list.AddRange(_GlobalItems.Keys);
			list.AddRange(_Items.Keys);
			return list.ToArray();
		}
	}
}
