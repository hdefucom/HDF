using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       基于二维数组的数据读取器
	                                                                    ///       </summary>
	[ComVisible(false)]
	public class XDataArrayReader : IDataReader
	{
		private class MyArrayComparer : IComparer
		{
			public int[] FieldIndexs = null;

			public MyArrayComparer(int[] fields)
			{
				FieldIndexs = fields;
			}

			public int Compare(object object_0, object object_1)
			{
				object[] array = (object[])object_0;
				object[] array2 = (object[])object_1;
				int num = FieldIndexs.Length;
				int num2 = 0;
				int num4;
				while (true)
				{
					if (num2 < num)
					{
						int num3 = FieldIndexs[num2];
						object obj = array[num3];
						object obj2 = array2[num3];
						bool flag = obj == null || DBNull.Value.Equals(obj);
						bool flag2 = obj2 == null || DBNull.Value.Equals(obj2);
						if (flag == flag2)
						{
							if (flag != flag2 && !object.Equals(obj, obj2) && obj is IComparable)
							{
								num4 = ((IComparable)obj).CompareTo(obj2);
								if (num4 != 0)
								{
									break;
								}
							}
							num2++;
							continue;
						}
						if (flag)
						{
							return -1;
						}
						return 1;
					}
					return 0;
				}
				return num4;
			}
		}

		private class ColumnInfo
		{
			public string Name = null;

			public Type ValueType = typeof(string);

			public object[] GroupValues = null;

			public object DefaultValue = null;
		}

		private static Hashtable myDefaultValue = null;

		private Hashtable myChildRows;

		private ArrayList myGroupCounter;

		                                                                    /// <summary>
		                                                                    ///       字段列表
		                                                                    ///       </summary>
		private ColumnInfo[] myColumns;

		                                                                    /// <summary>
		                                                                    ///       所有的数值
		                                                                    ///       </summary>
		private ArrayList myRows;

		                                                                    /// <summary>
		                                                                    ///       总列数
		                                                                    ///       </summary>
		private int intFieldCount;

		                                                                    /// <summary>
		                                                                    ///       当前数据行号
		                                                                    ///       </summary>
		private int intRowIndex;

		private bool bolClosedFlag;

		private DataTable _SchemaTable;

		                                                                    /// <summary>
		                                                                    ///       记录个数
		                                                                    ///       </summary>
		public int RecordCount
		{
			get
			{
				if (myRows == null)
				{
					return -1;
				}
				return myRows.Count;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       成员不支持
		                                                                    ///       </summary>
		public int RecordsAffected
		{
			get
			{
				throw new NotSupportedException("RecordsAffected");
			}
		}

		                                                                    /// <summary>
		                                                                    ///       对象是否关闭
		                                                                    ///       </summary>
		public bool IsClosed => bolClosedFlag;

		                                                                    /// <summary>
		                                                                    ///       成员不支持
		                                                                    ///       </summary>
		public int Depth
		{
			get
			{
				throw new NotSupportedException("Depth");
			}
		}

		public object this[string name] => GetValue(GetOrdinal(name));

		object IDataRecord.this[int int_0] => GetValue(int_0);

		public int FieldCount => intFieldCount;

		                                                                    /// <summary>
		                                                                    ///       无作为的初始化对象
		                                                                    ///       </summary>
		private XDataArrayReader()
		{
			myChildRows = null;
			myGroupCounter = null;
			myColumns = null;
			myRows = null;
			intFieldCount = 0;
			intRowIndex = -1;
			bolClosedFlag = false;
			_SchemaTable = null;
			
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="table">填充数据使用的数据表对象</param>
		public XDataArrayReader(DataTable table)
		{
			int num = 7;
			myChildRows = null;
			myGroupCounter = null;
			myColumns = null;
			myRows = null;
			intFieldCount = 0;
			intRowIndex = -1;
			bolClosedFlag = false;
			_SchemaTable = null;
			
			if (table == null)
			{
				throw new ArgumentNullException("table");
			}
			intFieldCount = table.Columns.Count;
			ArrayList arrayList = new ArrayList();
			foreach (DataColumn column in table.Columns)
			{
				arrayList.Add(new ColumnInfo
				{
					Name = column.ColumnName,
					ValueType = column.DataType,
					DefaultValue = column.DefaultValue
				});
			}
			myColumns = (ColumnInfo[])arrayList.ToArray(typeof(ColumnInfo));
			myRows = new ArrayList();
			foreach (DataRow row in table.Rows)
			{
				object[] itemArray = row.ItemArray;
				for (int i = 0; i < itemArray.Length; i++)
				{
					if (itemArray[i] == null)
					{
						itemArray[i] = DBNull.Value;
					}
				}
				myRows.Add(itemArray);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="table">填充数据使用的数据表对象</param>
		public XDataArrayReader(DataTable table, string filterExpression, string sortExpression)
		{
			int num = 18;
			myChildRows = null;
			myGroupCounter = null;
			myColumns = null;
			myRows = null;
			intFieldCount = 0;
			intRowIndex = -1;
			bolClosedFlag = false;
			_SchemaTable = null;
			
			if (table == null)
			{
				throw new ArgumentNullException("table");
			}
			intFieldCount = table.Columns.Count;
			ArrayList arrayList = new ArrayList();
			foreach (DataColumn column in table.Columns)
			{
				arrayList.Add(new ColumnInfo
				{
					Name = column.ColumnName,
					ValueType = column.DataType,
					DefaultValue = column.DefaultValue
				});
			}
			myColumns = (ColumnInfo[])arrayList.ToArray(typeof(ColumnInfo));
			myRows = new ArrayList();
			foreach (DataRowView item in new DataView(table)
			{
				Sort = sortExpression,
				RowFilter = filterExpression
			})
			{
				object[] itemArray = item.Row.ItemArray;
				for (int i = 0; i < itemArray.Length; i++)
				{
					if (itemArray[i] == null)
					{
						itemArray[i] = DBNull.Value;
					}
				}
				myRows.Add(itemArray);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="reader">填充数据的数据读取器</param>
		public XDataArrayReader(IDataReader reader)
		{
			int num = 15;
			myChildRows = null;
			myGroupCounter = null;
			myColumns = null;
			myRows = null;
			intFieldCount = 0;
			intRowIndex = -1;
			bolClosedFlag = false;
			_SchemaTable = null;
			
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (reader is XDataArrayReader)
			{
				XDataArrayReader xDataArrayReader = (XDataArrayReader)reader;
				intFieldCount = xDataArrayReader.intFieldCount;
				myColumns = new ColumnInfo[xDataArrayReader.myColumns.Length];
				for (int i = 0; i < myColumns.Length; i++)
				{
					myColumns[i] = new ColumnInfo();
					myColumns[i].Name = xDataArrayReader.myColumns[i].Name;
					myColumns[i].ValueType = xDataArrayReader.myColumns[i].ValueType;
					myColumns[i].DefaultValue = xDataArrayReader.myColumns[i].DefaultValue;
				}
				myRows = (ArrayList)xDataArrayReader.myRows.Clone();
				if (xDataArrayReader._SchemaTable != null)
				{
					_SchemaTable = xDataArrayReader._SchemaTable.Clone();
				}
				return;
			}
			try
			{
				_SchemaTable = reader.GetSchemaTable();
			}
			catch (Exception)
			{
			}
			ArrayList arrayList = new ArrayList();
			myRows = new ArrayList();
			if (arrayList.Count == 0)
			{
				intFieldCount = reader.FieldCount;
				for (int i = 0; i < intFieldCount; i++)
				{
					ColumnInfo columnInfo = new ColumnInfo();
					columnInfo.Name = reader.GetName(i);
					columnInfo.ValueType = reader.GetFieldType(i);
					columnInfo.DefaultValue = GetDefaultValue(columnInfo.ValueType);
					arrayList.Add(columnInfo);
				}
				if (arrayList.Count == 0)
				{
					throw new Exception("No column");
				}
				myColumns = (ColumnInfo[])arrayList.ToArray(typeof(ColumnInfo));
			}
			while (reader.Read())
			{
				object[] array = new object[intFieldCount];
				reader.GetValues(array);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == null)
					{
						array[i] = DBNull.Value;
					}
				}
				myRows.Add(array);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得指定类型的默认值
		                                                                    ///       </summary>
		                                                                    /// <param name="ValueType">数据类型</param>
		                                                                    /// <returns>默认值</returns>
		public static object GetDefaultValue(Type ValueType)
		{
			int num = 4;
			if (myDefaultValue == null)
			{
				myDefaultValue = new Hashtable();
				myDefaultValue[typeof(object)] = null;
				myDefaultValue[typeof(byte)] = (byte)0;
				myDefaultValue[typeof(sbyte)] = (sbyte)0;
				myDefaultValue[typeof(short)] = (short)0;
				myDefaultValue[typeof(ushort)] = (ushort)0;
				myDefaultValue[typeof(int)] = 0;
				myDefaultValue[typeof(uint)] = 0u;
				myDefaultValue[typeof(long)] = 0L;
				myDefaultValue[typeof(ulong)] = 0uL;
				myDefaultValue[typeof(char)] = '\0';
				myDefaultValue[typeof(float)] = 0f;
				myDefaultValue[typeof(double)] = 0.0;
				myDefaultValue[typeof(decimal)] = 0m;
				myDefaultValue[typeof(bool)] = false;
				myDefaultValue[typeof(string)] = null;
				myDefaultValue[typeof(DateTime)] = DateTime.MinValue;
				myDefaultValue[typeof(Point)] = Point.Empty;
				myDefaultValue[typeof(PointF)] = PointF.Empty;
				myDefaultValue[typeof(Size)] = Size.Empty;
				myDefaultValue[typeof(SizeF)] = SizeF.Empty;
				myDefaultValue[typeof(Rectangle)] = Rectangle.Empty;
				myDefaultValue[typeof(RectangleF)] = RectangleF.Empty;
				myDefaultValue[typeof(Color)] = Color.Transparent;
			}
			if (ValueType == null)
			{
				throw new ArgumentNullException("ValueType");
			}
			if (myDefaultValue.ContainsKey(ValueType))
			{
				return myDefaultValue[ValueType];
			}
			if (ValueType.IsValueType)
			{
				return Activator.CreateInstance(ValueType);
			}
			return null;
		}

		public string ToValueString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			ColumnInfo[] array = myColumns;
			foreach (ColumnInfo columnInfo in array)
			{
				stringBuilder.Append(columnInfo.Name);
				stringBuilder.Append('\t');
			}
			foreach (object[] myRow in myRows)
			{
				stringBuilder.Append(Environment.NewLine);
				for (int j = 0; j < intFieldCount; j++)
				{
					stringBuilder.Append(myRow[j]);
					stringBuilder.Append('\t');
				}
			}
			return stringBuilder.ToString();
		}

		public void Cross(string GroupFieldNameList, string CrossFieldNameList)
		{
			int num = 16;
			if (GroupFieldNameList == null)
			{
				throw new ArgumentNullException("GroupFieldNameList");
			}
			if (CrossFieldNameList == null)
			{
				throw new ArgumentNullException("CrossFieldNameList");
			}
			string[] groupFieldNames = GroupFieldNameList.Split(',');
			string[] crossFieldNames = CrossFieldNameList.Split(',');
			Cross(groupFieldNames, crossFieldNames);
		}

		public void Cross(string[] GroupFieldNames, string[] CrossFieldNames)
		{
			int num = 7;
			if (GroupFieldNames == null)
			{
				throw new ArgumentNullException("GroupFieldNames");
			}
			if (CrossFieldNames == null)
			{
				throw new ArgumentNullException("CrossFieldNames");
			}
			int[] fieldIndexs = GetFieldIndexs(GroupFieldNames);
			int[] fieldIndexs2 = GetFieldIndexs(CrossFieldNames);
			Cross(fieldIndexs, fieldIndexs2);
		}

		public void Cross(int[] GroupFieldIndexs, int[] CrossFieldIndexs)
		{
			int num = 19;
			if (GroupFieldIndexs == null)
			{
				throw new ArgumentNullException("GroupFieldIndexs");
			}
			if (CrossFieldIndexs == null)
			{
				throw new ArgumentNullException("CrossFieldIndexs");
			}
			int[] array = new int[GroupFieldIndexs.Length + CrossFieldIndexs.Length];
			Array.Copy(GroupFieldIndexs, 0, array, 0, GroupFieldIndexs.Length);
			Array.Copy(CrossFieldIndexs, 0, array, GroupFieldIndexs.Length, CrossFieldIndexs.Length);
			ArrayList arrayList = new ArrayList();
			myGroupCounter = new ArrayList();
			int num2 = GroupFieldIndexs.Length;
			foreach (object[] myRow in myRows)
			{
				bool flag = false;
				foreach (object[] item in myGroupCounter)
				{
					flag = true;
					for (int i = 0; i < num2; i++)
					{
						int num3 = GroupFieldIndexs[i];
						if (!EqualsValue(myRow[num3], item[num3]))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					myGroupCounter.Add(myRow);
				}
			}
			CrossFields(GroupFieldIndexs, CrossFieldIndexs, 0, new ArrayList(), myRows, arrayList);
			myRows.Clear();
			myRows.AddRange(arrayList);
			Sort(array);
		}

		public void Group(string strFieldName)
		{
			int num = 2;
			int fieldIndex = GetFieldIndex(strFieldName);
			if (fieldIndex < 0)
			{
				throw new ArgumentException("Bad field name '" + strFieldName + "'");
			}
			Group2(fieldIndex);
		}

		public void Group2(int FieldIndex)
		{
			myChildRows = new Hashtable();
			for (int i = 0; i < myRows.Count; i++)
			{
				object[] array = (object[])myRows[i];
				ArrayList arrayList = new ArrayList();
				myChildRows[array] = arrayList;
				arrayList.Add(array);
				for (int j = i + 1; j < myRows.Count; j++)
				{
					object[] array2 = (object[])myRows[j];
					if (EqualsValue(array[FieldIndex], array2[FieldIndex]))
					{
						arrayList.Add(array2);
						myRows.RemoveAt(j);
						j--;
					}
				}
			}
		}

		public XDataArrayReader GetChildReader()
		{
			int num = 16;
			CheckClosed();
			if (myChildRows == null)
			{
				return null;
			}
			if (intRowIndex < 0 || intRowIndex > myRows.Count)
			{
				throw new InvalidOperationException("Bad row index");
			}
			object[] key = (object[])myRows[intRowIndex];
			ArrayList arrayList = (ArrayList)myChildRows[key];
			if (arrayList != null)
			{
				XDataArrayReader xDataArrayReader = new XDataArrayReader(this);
				xDataArrayReader.myRows.Clear();
				xDataArrayReader.myRows.AddRange(arrayList);
				return xDataArrayReader;
			}
			return null;
		}

		private bool EqualsValue(object object_0, object object_1)
		{
			bool flag = object_0 == null || DBNull.Value.Equals(object_0);
			bool flag2 = object_1 == null || DBNull.Value.Equals(object_1);
			if (flag != flag2)
			{
				return false;
			}
			if (flag)
			{
				return true;
			}
			return object.Equals(object_0, object_1);
		}

		private void CrossFields(int[] GroupFieldIndexs, int[] CrossFieldIndexs, int layer, ArrayList CrossValues, ArrayList rows, ArrayList result)
		{
			if (layer == CrossFieldIndexs.Length)
			{
				foreach (object[] item in myGroupCounter)
				{
					bool flag = false;
					for (int num = rows.Count - 1; num >= 0; num--)
					{
						object[] array2 = (object[])rows[num];
						bool flag2 = true;
						for (int num2 = GroupFieldIndexs.Length - 1; num2 >= 0; num2--)
						{
							int num3 = GroupFieldIndexs[num2];
							if (!EqualsValue(array2[num3], item[num3]))
							{
								flag2 = false;
								break;
							}
						}
						if (flag2)
						{
							flag2 = true;
							for (int num2 = CrossFieldIndexs.Length - 1; num2 >= 0; num2--)
							{
								int num3 = CrossFieldIndexs[num2];
								if (!EqualsValue(array2[num3], CrossValues[num2]))
								{
									flag2 = false;
								}
							}
							if (flag2)
							{
								result.Add(array2);
								rows.RemoveAt(num);
								flag = true;
							}
						}
					}
					if (!flag)
					{
						object[] array3 = new object[intFieldCount];
						for (int num = 0; num < intFieldCount; num++)
						{
							array3[num] = myColumns[num].DefaultValue;
						}
						foreach (int num3 in GroupFieldIndexs)
						{
							array3[num3] = item[num3];
						}
						for (int num = 0; num < CrossFieldIndexs.Length; num++)
						{
							int num3 = CrossFieldIndexs[num];
							array3[num3] = CrossValues[num];
						}
						result.Add(array3);
					}
				}
				return;
			}
			XHashtable xHashtable = GroupValues(CrossFieldIndexs[layer], rows);
			foreach (object key in xHashtable.Keys)
			{
				ArrayList rows2 = (ArrayList)xHashtable[key];
				CrossValues.Add(key);
				CrossFields(GroupFieldIndexs, CrossFieldIndexs, layer + 1, CrossValues, rows2, result);
				CrossValues.RemoveAt(CrossValues.Count - 1);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       获得字段在读取器中的字段序号
		                                                                    ///       </summary>
		                                                                    /// <param name="FieldName">
		                                                                    /// </param>
		                                                                    /// <returns>
		                                                                    /// </returns>
		private int GetFieldIndex(string FieldName)
		{
			ArrayList arrayList = new ArrayList();
			ColumnInfo[] array = myColumns;
			foreach (ColumnInfo columnInfo in array)
			{
				arrayList.Add(columnInfo.Name);
			}
			return SQLHelper.FieldIndexOf(arrayList, FieldName);
		}

		private int[] GetFieldIndexs(string[] FieldNames)
		{
			ArrayList arrayList = new ArrayList();
			ColumnInfo[] array = myColumns;
			foreach (ColumnInfo columnInfo in array)
			{
				arrayList.Add(columnInfo.Name);
			}
			ArrayList arrayList2 = new ArrayList();
			foreach (string fieldName in FieldNames)
			{
				int num = SQLHelper.FieldIndexOf(arrayList, fieldName);
				if (num >= 0)
				{
					arrayList2.Add(num);
				}
			}
			return (int[])arrayList2.ToArray(typeof(int));
		}

		private XHashtable GroupValues(int FieldIndex, ArrayList rows)
		{
			XHashtable xHashtable = new XHashtable();
			foreach (object[] row in rows)
			{
				object object_ = row[FieldIndex];
				ArrayList arrayList = xHashtable[object_] as ArrayList;
				if (arrayList == null)
				{
					arrayList = (ArrayList)(xHashtable[object_] = new ArrayList());
				}
				arrayList.Add(row);
			}
			return xHashtable;
		}

		private object[] GetGroupValues(int FieldIndex)
		{
			int num = 6;
			if (FieldIndex < 0 || FieldIndex > intFieldCount)
			{
				throw new IndexOutOfRangeException("FieldIndex");
			}
			ColumnInfo columnInfo = myColumns[FieldIndex];
			if (columnInfo.GroupValues != null)
			{
				return columnInfo.GroupValues;
			}
			Hashtable hashtable = new Hashtable();
			for (int i = 0; i < myRows.Count; i++)
			{
				object[] array = (object[])myRows[i];
				hashtable[array[FieldIndex]] = 1;
			}
			ArrayList arrayList = new ArrayList(hashtable.Keys);
			columnInfo.GroupValues = arrayList.ToArray();
			return columnInfo.GroupValues;
		}

		                                                                    /// <summary>
		                                                                    ///       根据指定的多个字段进行排序
		                                                                    ///       </summary>
		                                                                    /// <param name="FieldNames">要排序的字段名称</param>
		public void Sort(string[] FieldNames)
		{
			int num = 6;
			if (FieldNames == null || FieldNames.Length == 0)
			{
				throw new ArgumentNullException("FieldNames");
			}
			ArrayList arrayList = new ArrayList();
			foreach (string name in FieldNames)
			{
				int ordinal = GetOrdinal(name);
				if (ordinal >= 0)
				{
					arrayList.Add(ordinal);
				}
			}
			if (arrayList.Count > 0)
			{
				Sort((int[])arrayList.ToArray(typeof(int)));
			}
		}

		                                                                    /// <summary>
		                                                                    ///       根据指定的多个字段进行排序
		                                                                    ///       </summary>
		                                                                    /// <param name="FieldIndexs">要排序的字段序号</param>
		public void Sort(int[] FieldIndexs)
		{
			int num = 0;
			if (FieldIndexs == null || FieldIndexs.Length == 0)
			{
				throw new ArgumentNullException("FieldIndexs");
			}
			MyArrayComparer comparer = new MyArrayComparer(FieldIndexs);
			myRows.Sort(comparer);
		}

		                                                                    /// <summary>
		                                                                    ///       根据对象数据创建一个数据表对象
		                                                                    ///       </summary>
		                                                                    /// <returns>创建的数据表对象</returns>
		public DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			ColumnInfo[] array = myColumns;
			foreach (ColumnInfo columnInfo in array)
			{
				DataColumn column = new DataColumn(columnInfo.Name, columnInfo.ValueType);
				dataTable.Columns.Add(column);
			}
			foreach (object[] myRow in myRows)
			{
				dataTable.Rows.Add(myRow);
			}
			return dataTable;
		}

		private void CheckClosed()
		{
			int num = 10;
			if (bolClosedFlag)
			{
				throw new InvalidOperationException("Already closed");
			}
		}

		                                                                    /// <summary>
		                                                                    ///       成员不支持
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public bool NextResult()
		{
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       关闭对象
		                                                                    ///       </summary>
		public void Close()
		{
			bolClosedFlag = true;
			myColumns = null;
			myRows = null;
			intRowIndex = -1;
			intFieldCount = 0;
			if (_SchemaTable != null)
			{
				_SchemaTable.Dispose();
				_SchemaTable = null;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       移动到下一行数据
		                                                                    ///       </summary>
		                                                                    /// <returns>操作是否成功</returns>
		public bool Read()
		{
			intRowIndex++;
			if (intRowIndex < myRows.Count)
			{
				return true;
			}
			return false;
		}

		                                                                    /// <summary>
		                                                                    ///       成员不支持
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public DataTable GetSchemaTable()
		{
			int num = 8;
			if (_SchemaTable == null)
			{
				throw new NotSupportedException("GetSchemaTable");
			}
			return _SchemaTable;
		}

		public void Dispose()
		{
			if (!bolClosedFlag)
			{
				Close();
			}
		}

		public int GetInt32(int ordinal)
		{
			return Convert.ToInt32(GetValue(ordinal));
		}

		public object GetValue(int ordinal)
		{
			int num = 16;
			CheckClosed();
			if (intRowIndex < 0 || intRowIndex >= myRows.Count || ordinal < 0 || ordinal >= intFieldCount)
			{
				throw new IndexOutOfRangeException("Miss data");
			}
			object[] array = (object[])myRows[intRowIndex];
			return array[ordinal];
		}

		public bool IsDBNull(int ordinal)
		{
			object value = GetValue(ordinal);
			return value == null || DBNull.Value.Equals(value);
		}

		public long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			byte[] array = (byte[])GetValue(ordinal);
			long num = Math.Min(array.Length - fieldOffset, length);
			byte[] destinationArray = new byte[num];
			Array.Copy(array, fieldOffset, destinationArray, bufferoffset, num);
			return num;
		}

		public byte GetByte(int ordinal)
		{
			return Convert.ToByte(GetValue(ordinal));
		}

		public Type GetFieldType(int ordinal)
		{
			int num = 11;
			CheckClosed();
			if (ordinal < 0 || ordinal >= intFieldCount)
			{
				throw new IndexOutOfRangeException("index");
			}
			return myColumns[ordinal].ValueType;
		}

		public decimal GetDecimal(int ordinal)
		{
			return Convert.ToDecimal(GetValue(ordinal));
		}

		public int GetValues(object[] values)
		{
			int num = 17;
			CheckClosed();
			if (intRowIndex < 0 || intRowIndex >= myRows.Count)
			{
				throw new IndexOutOfRangeException("RowIndex");
			}
			object[] array = (object[])myRows[intRowIndex];
			int num2 = Math.Min(values.Length, array.Length);
			Array.Copy(array, 0, values, 0, num2);
			return num2;
		}

		public string GetName(int ordinal)
		{
			int num = 5;
			CheckClosed();
			if (ordinal < 0 || ordinal >= intFieldCount)
			{
				throw new IndexOutOfRangeException("i");
			}
			return myColumns[ordinal].Name;
		}

		public long GetInt64(int ordinal)
		{
			return Convert.ToInt64(GetValue(ordinal));
		}

		public double GetDouble(int ordinal)
		{
			return Convert.ToDouble(GetValue(ordinal));
		}

		public bool GetBoolean(int ordinal)
		{
			return Convert.ToBoolean(GetValue(ordinal));
		}

		public Guid GetGuid(int ordinal)
		{
			throw new NotSupportedException("GetGuid");
		}

		public DateTime GetDateTime(int ordinal)
		{
			return Convert.ToDateTime(GetValue(ordinal));
		}

		public int GetOrdinal(string name)
		{
			int num = 2;
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = name.Trim();
			CheckClosed();
			int num2 = 0;
			while (true)
			{
				if (num2 < intFieldCount)
				{
					if (string.Compare(myColumns[num2].Name, name, ignoreCase: true) == 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num2;
		}

		public string GetDataTypeName(int ordinal)
		{
			int num = 9;
			CheckClosed();
			if (ordinal < 0 || ordinal >= intFieldCount)
			{
				throw new IndexOutOfRangeException("i");
			}
			return myColumns[ordinal].ValueType.Name;
		}

		public float GetFloat(int ordinal)
		{
			return Convert.ToSingle(GetValue(ordinal));
		}

		public IDataReader GetData(int int_0)
		{
			throw new NotSupportedException("GetData");
		}

		public long GetChars(int ordinal, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			throw new NotSupportedException("GetChars");
		}

		public string GetString(int ordinal)
		{
			return Convert.ToString(GetValue(ordinal));
		}

		public char GetChar(int ordinal)
		{
			return Convert.ToChar(GetValue(ordinal));
		}

		public short GetInt16(int ordinal)
		{
			return Convert.ToInt16(GetValue(ordinal));
		}
	}
}
