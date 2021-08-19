using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.Data.Object
{
	                                                                    /// <summary>
	                                                                    ///       对于对象的数据读取器
	                                                                    ///       </summary>
	                                                                    /// <remarks>本对象使用反射来获得对象数据,并使用委托来加速。
	                                                                    ///       编制 袁永福</remarks>
	[ComVisible(false)]
	public class ObjectDataReader : BaseDataReader, IRecordCount
	{
		private class ColumnInfo
		{
			public string Name = null;

			public string DisplayName = null;

			public ObjectValueAccesser Accesser = null;

			public Type DataType = typeof(string);

			internal bool NullFlag = false;
		}

		protected IEnumerator myObjects = null;

		protected int intPosition = -1;

		protected object myCurrentObject = null;

		protected Type LastType = null;

		public override bool IsClosed => myObjects == null;

		                                                                    /// <summary>
		                                                                    ///       记录总个数
		                                                                    ///       </summary>
		public int RecordCount
		{
			get
			{
				if (myObjects != null && myObjects is ICollection)
				{
					return ((ICollection)myObjects).Count;
				}
				return -1;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       无作为的初始化对象
		                                                                    ///       </summary>
		public ObjectDataReader()
		{
			bolDirectConvert = true;
		}

		                                                                    /// <summary>
		                                                                    ///       设置对象列表的初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="objs">对象列表</param>
		public ObjectDataReader(IEnumerator objs)
		{
			bolDirectConvert = true;
			Connect(objs);
		}

		                                                                    /// <summary>
		                                                                    ///       设置对象列表的初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="objs">对象列表</param>
		public ObjectDataReader(IEnumerable objs)
		{
			bolDirectConvert = true;
			Connect(objs);
		}

		                                                                    /// <summary>
		                                                                    ///       设置栏目名称的数据对象类型的初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="ColumnNames">栏目名称</param>
		                                                                    /// <param name="vType">数据对象类型</param>
		public ObjectDataReader(ICollection ColumnNames, Type vType)
		{
			AddColumns(ColumnNames);
			LastType = vType;
			RefreshColumns(vType);
		}

		public virtual object GetCurrentObject()
		{
			return myCurrentObject;
		}

		                                                                    /// <summary>
		                                                                    ///       设置内部状态,准备读取当前记录数据
		                                                                    ///       </summary>
		protected virtual void PrepareReadValue()
		{
			object currentObject = GetCurrentObject();
			if (currentObject != null && LastType == null && !currentObject.GetType().Equals(LastType))
			{
				LastType = currentObject.GetType();
				RefreshColumns(currentObject.GetType());
			}
		}

		private void RefreshColumns(Type type_0)
		{
			foreach (ColumnInfo myColumn in myColumns)
			{
				myColumn.Accesser = ObjectValueAccesser.GetInstance(type_0, myColumn.Name);
				if (myColumn.Accesser == null)
				{
					myColumn.NullFlag = true;
				}
				else
				{
					myColumn.NullFlag = false;
				}
			}
		}

		public void Connect(IEnumerable objs)
		{
			if (objs != null)
			{
				myObjects = objs.GetEnumerator();
			}
			intPosition = -1;
		}

		                                                                    /// <summary>
		                                                                    ///       连接对象集合
		                                                                    ///       </summary>
		                                                                    /// <param name="objs">对象集合</param>
		public void Connect(IEnumerator objs)
		{
			myObjects = objs;
			intPosition = -1;
		}

		                                                                    /// <summary>
		                                                                    ///       添加一个数据栏目
		                                                                    ///       </summary>
		                                                                    /// <param name="vName">栏目名称</param>
		                                                                    /// <returns>栏目序号</returns>
		public int AddColumn(string vName)
		{
			return AddColumn(vName, vName);
		}

		                                                                    /// <summary>
		                                                                    ///       添加若干个栏目
		                                                                    ///       </summary>
		                                                                    /// <param name="names">栏目名称列表</param>
		public void AddColumns(IEnumerable names)
		{
			foreach (string name in names)
			{
				AddColumn(name, name);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       添加栏目
		                                                                    ///       </summary>
		                                                                    /// <param name="vName">栏目名称</param>
		                                                                    /// <param name="vDisplayName">栏目编号</param>
		                                                                    /// <returns>栏目序号</returns>
		public int AddColumn(string vName, string vDisplayName)
		{
			ColumnInfo columnInfo = new ColumnInfo();
			columnInfo.Name = vName;
			columnInfo.DisplayName = vDisplayName;
			return myColumns.Add(columnInfo);
		}

		public void ClearColumn()
		{
			myColumns.Clear();
		}

		protected override object InnerGetValue(int index)
		{
			ColumnInfo columnInfo = (ColumnInfo)myColumns[index];
			object currentObject = GetCurrentObject();
			if (currentObject == null)
			{
				return DBNull.Value;
			}
			if (columnInfo.Accesser == null)
			{
				return DBNull.Value;
			}
			return columnInfo.Accesser.Read(currentObject);
		}

		public override void Close()
		{
			myObjects = null;
			intPosition = -1;
			LastType = null;
			myColumns.Clear();
		}

		public override bool Read()
		{
			if (myObjects == null)
			{
				return false;
			}
			if (!myObjects.MoveNext())
			{
				return false;
			}
			intPosition++;
			myCurrentObject = myObjects.Current;
			PrepareReadValue();
			return true;
		}

		public override string GetName(int ordinal)
		{
			return ((ColumnInfo)myColumns[ordinal]).DisplayName;
		}

		protected override bool InnerIsDBNull(int index)
		{
			return ((ColumnInfo)myColumns[index]).NullFlag;
		}
	}
}
