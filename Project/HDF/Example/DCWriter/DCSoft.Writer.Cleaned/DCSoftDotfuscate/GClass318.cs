using DCSoft.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass318
	{
		private object object_0 = null;

		public static GClass318 smethod_0(object object_1)
		{
			if (object_1 == null)
			{
				return null;
			}
			if (object_1 is GClass318)
			{
				return (GClass318)object_1;
			}
			return new GClass318(object_1);
		}

		public GClass318()
		{
		}

		public GClass318(object object_1)
		{
			object_0 = object_1;
		}

		public object method_0()
		{
			return object_0;
		}

		public void method_1(object object_1)
		{
			object_0 = object_1;
		}

		public object method_2(string string_0)
		{
			return smethod_2(object_0, string_0);
		}

		public bool method_3(string string_0, object object_1)
		{
			return smethod_1(object_0, string_0, object_1);
		}

		public string[] method_4()
		{
			return smethod_3(object_0);
		}

		public static bool smethod_1(object object_1, string string_0, object object_2)
		{
			if (object_1 == null)
			{
				return false;
			}
			if (object_1 is IDataRecord)
			{
				return false;
			}
			if (object_1 is DataRow)
			{
				DataRow dataRow = (DataRow)object_1;
				dataRow[string_0] = object_2;
				return true;
			}
			if (object_1 is DataRowView)
			{
				DataRowView dataRowView = (DataRowView)object_1;
				dataRowView[string_0] = object_2;
			}
			if (object_1 is DataTable)
			{
				DataTable dataTable = (DataTable)object_1;
				if (dataTable.Rows.Count > 0)
				{
					dataTable.Rows[0][string_0] = object_2;
					return true;
				}
				return false;
			}
			if (object_1 is DataView)
			{
				DataView dataView = (DataView)object_1;
				if (dataView.Count > 0)
				{
					DataRowView dataRowView = dataView[0];
					dataRowView[string_0] = object_2;
					return true;
				}
				return false;
			}
			if (object_1 is IDictionary)
			{
				IDictionary dictionary = (IDictionary)object_1;
				dictionary[string_0] = object_2;
				return true;
			}
			if (object_1 is XmlNode)
			{
				XmlNode rootNode = (XmlNode)object_1;
				XmlNode xmlNode = XMLHelper.CreateXMLNodeByPath(rootNode, string_0, 1, null);
				if (xmlNode != null)
				{
					if (object_2 == null || DBNull.Value.Equals(object_2))
					{
						xmlNode.Value = "";
					}
					else
					{
						xmlNode.Value = Convert.ToString(object_2);
					}
					return true;
				}
				return false;
			}
			if (object_1 is XmlNodeList)
			{
				XmlNodeList xmlNodeList = (XmlNodeList)object_1;
				if (xmlNodeList.Count > 0)
				{
					XmlNode rootNode = xmlNodeList[0];
					XmlNode xmlNode = XMLHelper.CreateXMLNodeByPath(rootNode, string_0, 1, null);
					if (xmlNode == null)
					{
						return false;
					}
					if (object_2 == null || DBNull.Value.Equals(object_2))
					{
						xmlNode.Value = "";
					}
					else
					{
						xmlNode.Value = Convert.ToString(object_2);
					}
					return true;
				}
			}
			if (object_1.GetType().IsArray)
			{
				Array array = (Array)object_1;
				if (array.GetLength(0) == 0)
				{
					return false;
				}
				object value = array.GetValue(0);
				return smethod_1(value, string_0, object_2);
			}
			return ValueTypeHelper.SetPropertyValueMultiLayer(object_1, string_0, object_2, throwExecption: false);
		}

		public static object smethod_2(object object_1, string string_0)
		{
			if (object_1 == null)
			{
				return null;
			}
			if (object_1 is IDataRecord)
			{
				IDataRecord dataRecord = (IDataRecord)object_1;
				return dataRecord[string_0];
			}
			if (object_1 is DataRow)
			{
				DataRow dataRow = (DataRow)object_1;
				return dataRow[string_0];
			}
			if (object_1 is DataRowView)
			{
				DataRowView dataRowView = (DataRowView)object_1;
				return dataRowView[string_0];
			}
			if (object_1 is DataTable)
			{
				DataTable dataTable = (DataTable)object_1;
				if (dataTable.Rows.Count > 0)
				{
					return dataTable.Rows[0][string_0];
				}
				return null;
			}
			if (object_1 is DataView)
			{
				DataView dataView = (DataView)object_1;
				if (dataView.Count > 0)
				{
					DataRowView dataRowView = dataView[0];
					return dataRowView[string_0];
				}
				return null;
			}
			if (object_1 is IDictionary)
			{
				IDictionary dictionary = (IDictionary)object_1;
				if (dictionary.Contains(string_0))
				{
					return dictionary[string_0];
				}
				return null;
			}
			if (object_1 is XmlNode)
			{
				XmlNode xmlNode = (XmlNode)object_1;
				return xmlNode.SelectSingleNode(string_0)?.Value;
			}
			if (object_1 is XmlNodeList)
			{
				XmlNodeList xmlNodeList = (XmlNodeList)object_1;
				if (xmlNodeList.Count > 0)
				{
					XmlNode xmlNode = xmlNodeList[0];
					return xmlNode.SelectSingleNode(string_0)?.Value;
				}
			}
			if (object_1.GetType().IsArray)
			{
				Array array = (Array)object_1;
				if (array.GetLength(0) == 0)
				{
					return null;
				}
				object value = array.GetValue(0);
				return smethod_2(value, string_0);
			}
			return ValueTypeHelper.GetPropertyValue(object_1, string_0, throwException: false);
		}

		public static string[] smethod_3(object object_1)
		{
			if (object_1 == null)
			{
				return null;
			}
			List<string> list = new List<string>();
			if (object_1 is IDataRecord)
			{
				IDataRecord dataRecord = (IDataRecord)object_1;
				for (int i = 0; i < dataRecord.FieldCount; i++)
				{
					list.Add(dataRecord.GetName(i));
				}
			}
			else if (object_1 is DataRow)
			{
				DataRow dataRow = (DataRow)object_1;
				DataTable table = dataRow.Table;
				foreach (DataColumn column in table.Columns)
				{
					list.Add(column.ColumnName);
				}
			}
			else if (object_1 is DataRowView)
			{
				DataRowView dataRowView = (DataRowView)object_1;
				foreach (DataColumn column2 in dataRowView.DataView.Table.Columns)
				{
					list.Add(column2.ColumnName);
				}
			}
			else if (object_1 is DataTable)
			{
				DataTable table = (DataTable)object_1;
				foreach (DataColumn column3 in table.Columns)
				{
					list.Add(column3.ColumnName);
				}
			}
			else if (object_1 is DataView)
			{
				DataView dataView = (DataView)object_1;
				foreach (DataColumn column4 in dataView.Table.Columns)
				{
					list.Add(column4.ColumnName);
				}
			}
			else if (object_1 is IDictionary)
			{
				IDictionary dictionary = (IDictionary)object_1;
				foreach (object key in dictionary.Keys)
				{
					list.Add(Convert.ToString(key));
				}
			}
			else if (object_1 is XmlNode)
			{
				XmlNode xmlNode = (XmlNode)object_1;
				foreach (XmlNode childNode in xmlNode.ChildNodes)
				{
					if (childNode is XmlElement)
					{
						list.Add(childNode.Name);
					}
				}
			}
			else if (object_1 is XmlNodeList)
			{
				XmlNodeList xmlNodeList = (XmlNodeList)object_1;
				if (xmlNodeList.Count > 0)
				{
					XmlNode xmlNode = xmlNodeList[0];
					foreach (XmlNode childNode2 in xmlNode.ChildNodes)
					{
						if (childNode2 is XmlElement)
						{
							list.Add(childNode2.Name);
						}
					}
				}
			}
			else if (object_1.GetType().IsArray)
			{
				Type elementType = object_1.GetType().GetElementType();
				PropertyInfo[] properties = elementType.GetProperties();
				if (properties != null)
				{
					PropertyInfo[] array = properties;
					foreach (PropertyInfo propertyInfo in array)
					{
						list.Add(propertyInfo.Name);
					}
				}
			}
			else
			{
				PropertyInfo[] properties = object_1.GetType().GetProperties();
				if (properties != null)
				{
					PropertyInfo[] array = properties;
					foreach (PropertyInfo propertyInfo in array)
					{
						list.Add(propertyInfo.Name);
					}
				}
			}
			return list.ToArray();
		}
	}
}
