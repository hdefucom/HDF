using DCSoft.Common;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Design.Data
{
	/// <summary>
	///       字段对象列表类型
	///       </summary>
	[Serializable]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(false)]
	[DebuggerDisplay("Count={ Count }")]
	public class DataBaseSchemaFieldCollection : CollectionBase
	{
		internal DataBaseSchemaTable myOwnerTable = null;

		/// <summary>
		///       返回指定序号的字段信息
		///       </summary>
		public DataBaseSchemaField this[int index] => (DataBaseSchemaField)base.InnerList[index];

		/// <summary>
		///       返回指定名称的字段信息
		///       </summary>
		public DataBaseSchemaField this[string strFieldName]
		{
			get
			{
				foreach (DataBaseSchemaField inner in base.InnerList)
				{
					if (string.Compare(inner.Name, strFieldName, ignoreCase: true) == 0)
					{
						return inner;
					}
				}
				return null;
			}
		}

		/// <summary>
		///       最后一个字段对象
		///       </summary>
		public DataBaseSchemaField LastField
		{
			get
			{
				if (base.Count > 0)
				{
					return this[base.Count - 1];
				}
				return null;
			}
		}

		/// <summary>
		///       添加字段信息对象
		///       </summary>
		/// <param name="info">字段信息对象</param>
		/// <returns>字段对象在列表中的序号</returns>
		public int Add(DataBaseSchemaField info)
		{
			info.myOwnerTable = myOwnerTable;
			return base.List.Add(info);
		}

		public void Remove(DataBaseSchemaField info)
		{
			base.List.Remove(info);
		}

		public void SortByName()
		{
			base.InnerList.Sort();
		}
	}
}
