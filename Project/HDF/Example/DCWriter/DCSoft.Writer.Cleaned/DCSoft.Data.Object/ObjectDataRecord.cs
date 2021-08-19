using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Data.Object
{
	                                                                    /// <summary>
	                                                                    ///       基于对象数据的记录类型
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class ObjectDataRecord : IDataRecord
	{
		private class ValueItem
		{
			public object Key = null;

			public object Value = null;
		}

		private class ColumnInfo
		{
			public string Name = null;

			public string DisplayName = null;

			public ObjectValueAccesser Accesser = null;

			public Type DataType = typeof(string);

			internal bool NullFlag = false;

			internal PropertyInfo Property = null;

			public object GetValue(object instance)
			{
				if (Property != null)
				{
					return Property.GetValue(instance, null);
				}
				if (Accesser != null)
				{
					return Accesser.Read(instance);
				}
				return null;
			}
		}

		private object _Instance = null;

		private List<ValueItem> _Values = null;

		private ObjectDataRecordMode _Mode = ObjectDataRecordMode.Auto;

		private ObjectDataRecordMode _RuntimeMode = ObjectDataRecordMode.Auto;

		private List<ColumnInfo> myColumns = new List<ColumnInfo>();

		protected Type LastType = null;

		public object Instance
		{
			get
			{
				return _Instance;
			}
			set
			{
				_Instance = value;
				_RuntimeMode = ObjectDataRecordMode.Auto;
				_Values = null;
			}
		}

		public ObjectDataRecordMode Mode
		{
			get
			{
				return _Mode;
			}
			set
			{
				_Mode = value;
				_RuntimeMode = ObjectDataRecordMode.Auto;
				_Values = null;
			}
		}

		public ObjectDataRecordMode RuntimeMode
		{
			get
			{
				if (_RuntimeMode == ObjectDataRecordMode.Auto)
				{
					_RuntimeMode = ObjectDataRecordMode.BothProperty;
					if (Mode == ObjectDataRecordMode.Auto)
					{
						if (Instance is IList)
						{
							_RuntimeMode = ObjectDataRecordMode.Array;
						}
						else if (Instance is ICollection)
						{
							_RuntimeMode = ObjectDataRecordMode.Diction;
						}
					}
					else
					{
						_RuntimeMode = _Mode;
					}
				}
				return _RuntimeMode;
			}
		}

		public int FieldCount
		{
			get
			{
				CheckState();
				switch (RuntimeMode)
				{
				default:
					return myColumns.Count;
				case ObjectDataRecordMode.Array:
					return ((IList)Instance).Count;
				case ObjectDataRecordMode.Diction:
					return ((ICollection)Instance).Count;
				case ObjectDataRecordMode.SpecifyProperty:
					return myColumns.Count;
				}
			}
		}

		public object this[string name]
		{
			get
			{
				int num = 15;
				int ordinal = GetOrdinal(name);
				if (ordinal > 0)
				{
					throw new IndexOutOfRangeException("name=" + name);
				}
				return GetValue(ordinal);
			}
		}

		public object this[int ordinal] => GetValue(ordinal);

		public ObjectDataRecord()
		{
		}

		public ObjectDataRecord(object instance)
		{
			Instance = instance;
		}

		public void AddColumn(string displayName, string fieldName)
		{
			if (RuntimeMode == ObjectDataRecordMode.SpecifyProperty)
			{
				ColumnInfo columnInfo = new ColumnInfo();
				columnInfo.Name = fieldName;
				if (fieldName == null || fieldName.Trim().Length == 0)
				{
					columnInfo.Name = displayName;
				}
				columnInfo.DisplayName = displayName;
				columnInfo.Name = fieldName;
				myColumns.Add(columnInfo);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       设置内部状态,准备读取当前记录数据
		                                                                    ///       </summary>
		protected virtual void CheckState()
		{
			switch (RuntimeMode)
			{
			case ObjectDataRecordMode.Diction:
				if (_Values == null && Instance is ICollection)
				{
					_Values = new List<ValueItem>();
					IDictionary dictionary = (IDictionary)Instance;
					foreach (object key in dictionary.Keys)
					{
						ValueItem valueItem = new ValueItem();
						valueItem.Key = key;
						valueItem.Value = dictionary[key];
						_Values.Add(valueItem);
					}
				}
				break;
			case ObjectDataRecordMode.SpecifyProperty:
			{
				object instance = Instance;
				if (instance != null && (LastType == null || !instance.GetType().Equals(LastType)))
				{
					LastType = instance.GetType();
					RefreshColumns(instance.GetType());
				}
				break;
			}
			case ObjectDataRecordMode.BothProperty:
			{
				if (Instance == null || LastType == null || Instance.GetType().Equals(LastType))
				{
					break;
				}
				myColumns.Clear();
				LastType = Instance.GetType();
				PropertyInfo[] properties = LastType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (propertyInfo.CanRead)
					{
						ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
						if (indexParameters == null || indexParameters.Length == 0)
						{
							ColumnInfo columnInfo = new ColumnInfo();
							columnInfo.Name = propertyInfo.Name;
							columnInfo.Property = propertyInfo;
							myColumns.Add(columnInfo);
						}
					}
				}
				break;
			}
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

		public bool GetBoolean(int ordinal)
		{
			object value = GetValue(ordinal);
			return Convert.ToBoolean(value);
		}

		public byte GetByte(int ordinal)
		{
			return (byte)GetValue(ordinal);
		}

		public long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			throw new NotImplementedException();
		}

		public char GetChar(int ordinal)
		{
			return (char)GetValue(ordinal);
		}

		public long GetChars(int ordinal, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			throw new NotImplementedException();
		}

		public IDataReader GetData(int int_0)
		{
			throw new NotImplementedException();
		}

		public string GetDataTypeName(int ordinal)
		{
			throw new NotImplementedException();
		}

		public DateTime GetDateTime(int ordinal)
		{
			return Convert.ToDateTime(GetValue(ordinal));
		}

		public decimal GetDecimal(int ordinal)
		{
			return Convert.ToDecimal(GetValue(ordinal));
		}

		public double GetDouble(int ordinal)
		{
			return Convert.ToDouble(GetValue(ordinal));
		}

		public Type GetFieldType(int ordinal)
		{
			CheckState();
			switch (RuntimeMode)
			{
			default:
				return typeof(string);
			case ObjectDataRecordMode.Array:
			{
				IList list = (IList)Instance;
				object obj = list[ordinal];
				if (obj == null)
				{
					return typeof(DBNull);
				}
				return obj.GetType();
			}
			case ObjectDataRecordMode.Diction:
			{
				object obj = _Values[ordinal];
				if (obj == null)
				{
					return typeof(DBNull);
				}
				return obj.GetType();
			}
			case ObjectDataRecordMode.SpecifyProperty:
				return myColumns[ordinal].DataType;
			case ObjectDataRecordMode.BothProperty:
				return myColumns[ordinal].DataType;
			}
		}

		public float GetFloat(int ordinal)
		{
			return Convert.ToSingle(GetValue(ordinal));
		}

		public Guid GetGuid(int ordinal)
		{
			object value = GetValue(ordinal);
			if (value is string)
			{
				return new Guid((string)value);
			}
			return (Guid)value;
		}

		public short GetInt16(int ordinal)
		{
			return Convert.ToInt16(GetValue(ordinal));
		}

		public int GetInt32(int ordinal)
		{
			return Convert.ToInt32(GetValue(ordinal));
		}

		public long GetInt64(int ordinal)
		{
			return Convert.ToInt64(GetValue(ordinal));
		}

		public string GetName(int ordinal)
		{
			int num = 9;
			CheckState();
			switch (RuntimeMode)
			{
			default:
				throw new IndexOutOfRangeException("i");
			case ObjectDataRecordMode.Array:
				return "Field" + ordinal;
			case ObjectDataRecordMode.Diction:
				return Convert.ToString(_Values[ordinal].Key);
			case ObjectDataRecordMode.SpecifyProperty:
				return myColumns[ordinal].Name;
			case ObjectDataRecordMode.BothProperty:
				return myColumns[ordinal].Name;
			}
		}

		public int GetOrdinal(string name)
		{
			int num = 6;
			int result = 0;
			if (int.TryParse(name, out result))
			{
				if (result >= 0 && result < FieldCount)
				{
					return result;
				}
				throw new IndexOutOfRangeException("name=" + name);
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < FieldCount)
				{
					if (string.Compare(GetName(num2), name, ignoreCase: true) == 0)
					{
						break;
					}
					num2++;
					continue;
				}
				throw new IndexOutOfRangeException("name=" + name);
			}
			return num2;
		}

		public string GetString(int ordinal)
		{
			return Convert.ToString(GetValue(ordinal));
		}

		public object GetValue(int ordinal)
		{
			CheckState();
			switch (RuntimeMode)
			{
			default:
				return DBNull.Value;
			case ObjectDataRecordMode.Array:
			{
				IList list = (IList)Instance;
				return list[ordinal];
			}
			case ObjectDataRecordMode.Diction:
				return _Values[ordinal].Value;
			case ObjectDataRecordMode.SpecifyProperty:
				return myColumns[ordinal].GetValue(Instance);
			case ObjectDataRecordMode.BothProperty:
				return myColumns[ordinal].GetValue(Instance);
			}
		}

		public int GetValues(object[] values)
		{
			int num = Math.Min(values.Length, FieldCount);
			for (int i = 0; i < num; i++)
			{
				values[i] = GetValue(i);
			}
			return num;
		}

		public bool IsDBNull(int ordinal)
		{
			if (RuntimeMode == ObjectDataRecordMode.SpecifyProperty || RuntimeMode == ObjectDataRecordMode.BothProperty)
			{
				ColumnInfo columnInfo = myColumns[ordinal];
				if (columnInfo.NullFlag)
				{
					return true;
				}
			}
			object value = GetValue(ordinal);
			if (value == null || DBNull.Value.Equals(value))
			{
				return true;
			}
			return false;
		}
	}
}
