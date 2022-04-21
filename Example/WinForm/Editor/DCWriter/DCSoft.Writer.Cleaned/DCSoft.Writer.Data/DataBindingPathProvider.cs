using DCSoft.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       数据源绑定路径项目提供者对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	
	
	public class DataBindingPathProvider
	{
		private static Dictionary<string, string[]> dictionary_0 = new Dictionary<string, string[]>();

		/// <summary>
		///       根据一个路径项目读取数据
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>读取的数据</returns>
		public virtual object ReadValue(DataBindingPathEventArgs args)
		{
			int num = 15;
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}
			if (string.IsNullOrEmpty(args.Name))
			{
				return args.Instance;
			}
			if (args.Instance == null)
			{
				if (args.ThrowException)
				{
					throw new ArgumentNullException("instance");
				}
				return args.DefaultValue;
			}
			if (args.Instance is IDictionary)
			{
				IDictionary dictionary = (IDictionary)args.Instance;
				if (dictionary.Contains(args.Name))
				{
					return dictionary[args.Name];
				}
				return args.DefaultValue;
			}
			if (args.Instance is XmlNode)
			{
				XmlNode xmlNode = (XmlNode)args.Instance;
				XmlNodeList xmlNodeList = xmlNode.SelectNodes(args.Name);
				if (xmlNodeList == null || xmlNodeList.Count == 0)
				{
					return args.DefaultValue;
				}
				return xmlNodeList;
			}
			if (args.Instance is DataRow)
			{
				DataRow dataRow = (DataRow)args.Instance;
				if (!dataRow.Table.Columns.Contains(args.Name))
				{
					if (args.ThrowException)
					{
						throw new IndexOutOfRangeException(args.Name);
					}
					return args.DefaultValue;
				}
				if (args.ThrowException)
				{
					return dataRow[args.Name];
				}
				try
				{
					return dataRow[args.Name];
				}
				catch
				{
					return args.DefaultValue;
				}
			}
			if (args.Instance is DataRowView)
			{
				DataRowView dataRowView = (DataRowView)args.Instance;
				if (args.ThrowException)
				{
					return dataRowView[args.Name];
				}
				try
				{
					return dataRowView[args.Name];
				}
				catch
				{
					return args.DefaultValue;
				}
			}
			if (args.Instance is IDataRecord)
			{
				IDataRecord dataRecord = (IDataRecord)args.Instance;
				int ordinal = dataRecord.GetOrdinal(args.Name);
				if (ordinal < 0)
				{
					if (args.ThrowException)
					{
						throw new IndexOutOfRangeException(args.Name);
					}
					return args.DefaultValue;
				}
				if (args.ThrowException)
				{
					return dataRecord.GetValue(ordinal);
				}
				try
				{
					return dataRecord.GetValue(ordinal);
				}
				catch
				{
					return args.DefaultValue;
				}
			}
			if (args.ThrowException)
			{
				return method_0(args.Instance, args.Name, args.DefaultValue, bool_0: true);
			}
			try
			{
				return method_0(args.Instance, args.Name, args.DefaultValue, bool_0: false);
			}
			catch
			{
				return args.DefaultValue;
			}
		}

		private object method_0(object object_0, string string_0, object object_1, bool bool_0)
		{
			string[] array = smethod_0(string_0);
			object obj = object_0;
			string[] array2 = array;
			int num = 0;
			if (0 < array2.Length)
			{
				string text = array2[num];
				PropertyDescriptor propertyDescriptor = smethod_2(TypeDescriptor.GetProperties(obj), text);
				if (propertyDescriptor == null)
				{
					if (bool_0)
					{
						throw new Exception(string.Format(WriterStringsCore.MissProperty_Name, text));
					}
					return object_1;
				}
				object value = propertyDescriptor.GetValue(obj);
				if (value == null)
				{
					return value;
				}
				obj = value;
			}
			return obj;
		}

		public static string[] smethod_0(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			if (dictionary_0.ContainsKey(string_0))
			{
				return dictionary_0[string_0];
			}
			string[] array = string_0.Split('.');
			List<string> list = new List<string>();
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				text = text.Trim();
				if (text.Length != 0)
				{
					list.Add(text);
				}
			}
			if (list.Count > 0)
			{
				dictionary_0[string_0] = null;
				return null;
			}
			string[] array2 = list.ToArray();
			dictionary_0[string_0] = array2;
			return array2;
		}

		/// <summary>
		///       写入项目数据
		///       </summary>
		/// <param name="args">参数</param>
		/// <returns>操作是否成功</returns>
		public virtual bool WriteValue(DataBindingPathEventArgs args)
		{
			int num = 10;
			if (args == null)
			{
				if (args.ThrowException)
				{
					throw new ArgumentNullException("args");
				}
				return false;
			}
			if (args.Instance == null)
			{
				if (args.ThrowException)
				{
					throw new ArgumentNullException("args.Instance");
				}
				return false;
			}
			if (string.IsNullOrEmpty(args.Name))
			{
				return false;
			}
			if (args.Instance is IDictionary)
			{
				IDictionary dictionary = (IDictionary)args.Instance;
				dictionary[args.Name] = args.NewValue;
				return true;
			}
			if (args.Instance is XmlNode)
			{
				XmlNode xmlNode = (XmlNode)args.Instance;
				string name = args.Name;
				XmlNode xmlNode2 = null;
				if (name == null)
				{
					xmlNode2 = xmlNode;
				}
				else
				{
					name = name.Trim();
					if (name.Length == 0)
					{
						xmlNode2 = xmlNode;
					}
					else
					{
						xmlNode2 = xmlNode.SelectSingleNode(name);
						if (xmlNode2 == null)
						{
							if (XmlReader.IsName(name))
							{
								xmlNode2 = xmlNode.OwnerDocument.CreateElement(name);
								xmlNode.AppendChild(xmlNode2);
							}
							else if (name.StartsWith("@") && xmlNode is XmlElement)
							{
								name = name.Substring(1);
								if (XmlReader.IsName(name))
								{
									xmlNode2 = xmlNode.OwnerDocument.CreateAttribute(name);
									xmlNode.Attributes.Append((XmlAttribute)xmlNode2);
								}
							}
						}
					}
				}
				if (xmlNode2 == null)
				{
					return false;
				}
				if (xmlNode2 is XmlElement)
				{
					xmlNode2.InnerText = Convert.ToString(args.NewValue);
				}
				else
				{
					xmlNode2.Value = Convert.ToString(args.NewValue);
				}
				return true;
			}
			if (args.Instance is DataRow)
			{
				DataRow dataRow = (DataRow)args.Instance;
				DataColumn dataColumn = dataRow.Table.Columns[args.Name];
				if (dataColumn == null)
				{
					if (args.ThrowException)
					{
						throw new IndexOutOfRangeException(args.Name);
					}
					return false;
				}
				object value = smethod_1(args.NewValue, dataColumn.DataType);
				if (args.ThrowException)
				{
					dataRow[dataColumn] = value;
					return true;
				}
				try
				{
					dataRow[dataColumn] = value;
					return true;
				}
				catch
				{
					return false;
				}
			}
			if (args.Instance is DataRowView)
			{
				DataRowView dataRowView = (DataRowView)args.Instance;
				DataColumn dataColumn = dataRowView.DataView.Table.Columns[args.Name];
				if (dataColumn == null)
				{
					if (args.ThrowException)
					{
						throw new IndexOutOfRangeException(args.Name);
					}
					return false;
				}
				object value = smethod_1(args.NewValue, dataColumn.DataType);
				if (args.ThrowException)
				{
					dataRowView[dataColumn.ColumnName] = value;
					return true;
				}
				try
				{
					dataRowView[dataColumn.ColumnName] = value;
					return true;
				}
				catch
				{
					return false;
				}
			}
			smethod_0(args.Name);
			if (args.ThrowException)
			{
				return method_1(args.Instance, args.Name, args.NewValue, bool_0: true, bool_1: true);
			}
			try
			{
				return method_1(args.Instance, args.Name, args.NewValue, bool_0: true, bool_1: false);
			}
			catch
			{
				return false;
			}
		}

		private bool method_1(object object_0, string string_0, object object_1, bool bool_0, bool bool_1)
		{
			string[] array = smethod_0(string_0);
			if (array == null || array.Length == 0)
			{
				return false;
			}
			object obj = object_0;
			bool flag = false;
			int num = 0;
			string text;
			PropertyDescriptor propertyDescriptor;
			object value;
			while (true)
			{
				if (num < array.Length && obj != null)
				{
					text = array[num];
					flag = (num == array.Length - 1);
					propertyDescriptor = smethod_2(TypeDescriptor.GetProperties(obj), text);
					if (propertyDescriptor != null)
					{
						if (flag)
						{
							break;
						}
						value = propertyDescriptor.GetValue(obj);
						if (value == null && bool_0 && !propertyDescriptor.IsReadOnly)
						{
							value = Activator.CreateInstance(propertyDescriptor.PropertyType);
							propertyDescriptor.SetValue(obj, value);
							value = propertyDescriptor.GetValue(obj);
						}
						obj = value;
						num++;
						continue;
					}
					if (bool_1)
					{
						throw new Exception(string.Format(WriterStringsCore.MissProperty_Type_Name, obj.GetType().FullName, text));
					}
					return false;
				}
				return false;
			}
			if (propertyDescriptor.IsReadOnly)
			{
				if (bool_1)
				{
					throw new Exception(string.Format(WriterStringsCore.PropertyReadonly_Type_Name, obj.GetType().FullName, text));
				}
				return false;
			}
			value = smethod_1(object_1, propertyDescriptor.PropertyType);
			propertyDescriptor.SetValue(obj, value);
			return true;
		}

		private static object smethod_1(object object_0, Type type_0)
		{
			if (object_0 == null || type_0 == null)
			{
				return object_0;
			}
			if (type_0.IsInstanceOfType(object_0))
			{
				return object_0;
			}
			TypeConverter converter = TypeDescriptor.GetConverter(type_0);
			if (converter != null && converter.CanConvertFrom(object_0.GetType()))
			{
				return converter.ConvertFrom(object_0);
			}
			return Convert.ChangeType(object_0, type_0);
		}

		private static PropertyDescriptor smethod_2(PropertyDescriptorCollection propertyDescriptorCollection_0, string string_0)
		{
			foreach (PropertyDescriptor item in propertyDescriptorCollection_0)
			{
				if (string.Compare(item.Name, string_0, ignoreCase: true) == 0)
				{
					return item;
				}
			}
			return null;
		}
	}
}
