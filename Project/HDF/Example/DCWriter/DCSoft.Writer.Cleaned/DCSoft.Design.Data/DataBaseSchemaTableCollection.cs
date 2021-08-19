using DCSoft.Common;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoft.Design.Data
{
	/// <summary>
	///       数据表信息列表类型
	///       </summary>
	[Serializable]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[ComVisible(false)]
	[DebuggerDisplay("Count={ Count }")]
	public class DataBaseSchemaTableCollection : CollectionBase
	{
		private class MyTableComparer : IComparer
		{
			public int Compare(object object_0, object object_1)
			{
				DataBaseSchemaTable dataBaseSchemaTable = (DataBaseSchemaTable)object_0;
				DataBaseSchemaTable dataBaseSchemaTable2 = (DataBaseSchemaTable)object_1;
				return string.Compare(dataBaseSchemaTable.Name, dataBaseSchemaTable2.Name);
			}
		}

		internal DataBaseSchema myOwnerDataBase = null;

		/// <summary>
		///       返回指定序号的表信息对象
		///       </summary>
		public DataBaseSchemaTable this[int index] => (DataBaseSchemaTable)base.List[index];

		/// <summary>
		///       返回指定名称的表信息对象
		///       </summary>
		public DataBaseSchemaTable this[string strTableName]
		{
			get
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DataBaseSchemaTable dataBaseSchemaTable = (DataBaseSchemaTable)enumerator.Current;
						if (string.Compare(dataBaseSchemaTable.Name, strTableName, ignoreCase: true) == 0)
						{
							return dataBaseSchemaTable;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return null;
			}
		}

		/// <summary>
		///       向列表添加表对象
		///       </summary>
		/// <param name="table">表对象</param>
		/// <returns>新增对象在列表中的序号</returns>
		public int Add(DataBaseSchemaTable table)
		{
			table.myOwnerDataBase = myOwnerDataBase;
			return base.List.Add(table);
		}

		public void Remove(DataBaseSchemaTable table)
		{
			base.List.Remove(table);
		}

		public void SortByName()
		{
			base.InnerList.Sort(new MyTableComparer());
		}
	}
}
