using System;
using System.Collections;
using System.Data;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       DataTableHelper 的摘要说明。
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public sealed class DataTableHelper
	{
		public static DataTable CreateDataTable(IDataReader myReader, int MaxRowCount)
		{
			int num = 19;
			if (myReader == null)
			{
				throw new ArgumentNullException("myReader");
			}
			DataTable dataTable = null;
			if (myReader is XDataArrayReader)
			{
				dataTable = ((XDataArrayReader)myReader).CreateDataTable();
			}
			else
			{
				dataTable = new DataTable("reader");
				for (int i = 0; i < myReader.FieldCount; i++)
				{
					dataTable.Columns.Add(myReader.GetName(i), myReader.GetFieldType(i));
				}
				int num2 = 0;
				while (myReader.Read())
				{
					DataRow dataRow = dataTable.NewRow();
					for (int i = 0; i < myReader.FieldCount; i++)
					{
						if (myReader.IsDBNull(i))
						{
							dataRow[i] = DBNull.Value;
						}
						else
						{
							dataRow[i] = myReader.GetValue(i);
						}
					}
					dataTable.Rows.Add(dataRow);
					num2++;
					if (MaxRowCount > 0 && num2 >= MaxRowCount)
					{
						break;
					}
				}
			}
			return dataTable;
		}

		private static bool EqualsValue(object object_0, object object_1)
		{
			if (object_0 == object_1)
			{
				return true;
			}
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return object_1 == null || DBNull.Value.Equals(object_1);
			}
			return object_0?.Equals(object_1) ?? object_1?.Equals(object_0) ?? false;
		}

		public static object TotalFunction(DataRow[] rows, string FieldName, TotalFunctionStyle style)
		{
			return null;
		}

		public static object TotalFunction(ArrayList values, TotalFunctionStyle style)
		{
			switch (style)
			{
			default:
				return 0;
			case TotalFunctionStyle.Sum:
			{
				double num3 = 0.0;
				foreach (object value in values)
				{
					if (value != null && !DBNull.Value.Equals(value))
					{
						try
						{
							double num2 = Convert.ToDouble(value);
							num3 += num2;
						}
						catch
						{
						}
					}
				}
				return num3;
			}
			case TotalFunctionStyle.Count:
				return values.Count;
			case TotalFunctionStyle.Max:
			{
				double num4 = double.NaN;
				foreach (object value2 in values)
				{
					if (value2 != null && !DBNull.Value.Equals(value2))
					{
						try
						{
							double num2 = Convert.ToDouble(value2);
							if (!double.IsNaN(num2) && (double.IsNaN(num4) || num4 < num2))
							{
								num4 = num2;
							}
						}
						catch
						{
						}
					}
				}
				return num4;
			}
			case TotalFunctionStyle.Min:
			{
				double num = double.NaN;
				foreach (object value3 in values)
				{
					if (value3 != null && !DBNull.Value.Equals(value3))
					{
						try
						{
							double num2 = Convert.ToDouble(value3);
							if (!double.IsNaN(num2) && (double.IsNaN(num) || num > num2))
							{
								num = num2;
							}
						}
						catch
						{
						}
					}
				}
				return num;
			}
			case TotalFunctionStyle.Avg:
			{
				double num3 = 0.0;
				foreach (object value4 in values)
				{
					if (value4 != null && !DBNull.Value.Equals(value4))
					{
						try
						{
							double num2 = Convert.ToDouble(value4);
							num3 += num2;
						}
						catch
						{
						}
					}
				}
				if (values.Count > 0)
				{
					return num3 / (double)values.Count;
				}
				return 0;
			}
			case TotalFunctionStyle.First:
				if (values.Count > 0)
				{
					return values[0];
				}
				return 0;
			case TotalFunctionStyle.Last:
				if (values.Count > 0)
				{
					return values[values.Count - 1];
				}
				return 0;
			}
		}

		private DataTableHelper()
		{
		}
	}
}
