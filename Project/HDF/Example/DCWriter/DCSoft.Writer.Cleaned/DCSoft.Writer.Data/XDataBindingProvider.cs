#define DEBUG
using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///        数据源绑定功能提供者
	///        </summary>
	/// <remarks>编写 袁永福</remarks>
	[ComVisible(false)]
	[DocumentComment]
	public class XDataBindingProvider
	{
		/// <summary>
		///       读取数据
		///       </summary>
		/// <param name="specifyDataBoundItem">指定的数据源对象</param>
		/// <param name="host">应用程序宿主对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">元素对象</param>
		/// <param name="binding">数据源绑定信息对象</param>
		/// <param name="throwException">是否抛出异常</param>
		/// <returns>获得的数据</returns>
		public virtual object DomReadValue(object specifyDataBoundItem, WriterAppHost host, XTextDocument document, XTextElement element, XDataBinding binding, bool throwException)
		{
			if (binding == null)
			{
				return null;
			}
			object obj = null;
			obj = ((specifyDataBoundItem != null) ? specifyDataBoundItem : document.GetParameterValue(binding.DataSource));
			if (obj != null)
			{
				return ReadValue(binding, obj, null, throwException);
			}
			return null;
		}

		/// <summary>
		///       设置数据
		///       </summary>
		/// <param name="specifyDataBoundItem">指定的数据源对象</param>
		/// <param name="host">宿主对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">元素对象</param>
		/// <param name="binding">数据源绑定信息</param>
		/// <param name="newValue">新数值</param>
		/// <param name="throwException">是否抛出异常</param>
		/// <returns>操作是否成功</returns>
		public virtual bool DomWriteValue(object specifyDataBoundItem, WriterAppHost host, XTextDocument document, XTextElement element, XDataBinding binding, object newValue, bool throwException)
		{
			bool result = false;
			if (!binding.Readonly)
			{
				if (string.IsNullOrEmpty(binding.BindingPath))
				{
					return document.SetDocumentParameterValue(binding.DataSource, newValue);
				}
				object obj = null;
				obj = ((specifyDataBoundItem != null) ? specifyDataBoundItem : document.GetParameterValue(binding.DataSource));
				if (obj != null)
				{
					result = WriteValue(binding, obj, newValue, throwException);
				}
			}
			return result;
		}

		public virtual object ReadItemValue(GClass115 item, object instance, object defaultValue, bool throwException)
		{
			return StdReadItemValue(item, instance, defaultValue, throwException);
		}

		/// <summary>
		///       获得数据源所能使用的字段名
		///       </summary>
		/// <param name="instance">数据源对象</param>
		/// <returns>能使用的字段名列表</returns>
		public virtual string[] GetFieldNames(object instance)
		{
			return StdGetFieldNames(instance);
		}

		/// <summary>
		///       获得字段名称列表
		///       </summary>
		/// <param name="instance">
		/// </param>
		/// <returns>
		/// </returns>
		public static string[] StdGetFieldNames(object instance)
		{
			int num = 19;
			if (instance == null)
			{
				return null;
			}
			try
			{
				if (instance is IDictionary)
				{
					IDictionary dictionary = (IDictionary)instance;
					List<string> list = new List<string>();
					foreach (object key in dictionary.Keys)
					{
						if (key != null && !DBNull.Value.Equals(key))
						{
							list.Add(Convert.ToString(key));
						}
					}
					return list.ToArray();
				}
				if (instance is XmlNode)
				{
					XmlNode xmlNode = (XmlNode)instance;
					List<string> list = new List<string>();
					if (xmlNode.Attributes != null)
					{
						foreach (XmlAttribute attribute in xmlNode.Attributes)
						{
							list.Add("@" + attribute.Name);
						}
					}
					if (xmlNode.ChildNodes.Count > 0)
					{
						foreach (XmlNode childNode in xmlNode.ChildNodes)
						{
							if (childNode is XmlElement)
							{
								list.Add(childNode.Name);
							}
						}
					}
					return list.ToArray();
				}
				if (instance is DataRow || instance is DataTable)
				{
					DataTable dataTable = null;
					dataTable = ((!(instance is DataTable)) ? ((DataRow)instance).Table : ((DataTable)instance));
					if (dataTable != null)
					{
						List<string> list = new List<string>();
						foreach (DataColumn column in dataTable.Columns)
						{
							list.Add(column.ColumnName);
						}
						return list.ToArray();
					}
				}
				else
				{
					if (!(instance is DataRowView))
					{
						List<string> list;
						if (instance is IDataRecord)
						{
							IDataRecord dataRecord = (IDataRecord)instance;
							list = new List<string>();
							for (int i = 0; i < dataRecord.FieldCount; i++)
							{
								list.Add(dataRecord.GetName(i));
							}
							return list.ToArray();
						}
						Type type = instance.GetType();
						list = new List<string>();
						PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
						foreach (PropertyInfo propertyInfo in properties)
						{
							if (propertyInfo.CanRead)
							{
								ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
								if ((indexParameters == null || indexParameters.Length > 0) && !list.Contains(propertyInfo.Name))
								{
									list.Add(propertyInfo.Name);
								}
							}
						}
						return list.ToArray();
					}
					DataRowView dataRowView = (DataRowView)instance;
					if (dataRowView.DataView != null)
					{
						List<string> list = new List<string>();
						foreach (DataColumn column2 in dataRowView.DataView.Table.Columns)
						{
							list.Add(column2.ColumnName);
						}
						list.ToArray();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return null;
		}

		public static object StdReadItemValue(GClass115 item, object instance, object defaultValue, bool throwException)
		{
			int num = 0;
			if (item == null)
			{
				if (throwException)
				{
					throw new ArgumentNullException("item");
				}
				return defaultValue;
			}
			if (instance == null)
			{
				if (throwException)
				{
					throw new ArgumentNullException("instance");
				}
				return defaultValue;
			}
			if (!item.method_0().IsInstanceOfType(instance))
			{
				if (throwException)
				{
					throw new InvalidCastException(instance.GetType().FullName + "->" + item.method_0().FullName);
				}
				return defaultValue;
			}
			if (string.IsNullOrEmpty(item.Name))
			{
				return instance;
			}
			if (instance is IDictionary)
			{
				IDictionary dictionary = (IDictionary)instance;
				if (dictionary.Contains(item.Name))
				{
					return dictionary[item.Name];
				}
				return defaultValue;
			}
			if (instance is XmlNode)
			{
				XmlNode xmlNode = (XmlNode)instance;
				XmlNode xmlNode2 = xmlNode.SelectSingleNode(item.Name);
				if (xmlNode2 == null)
				{
					return defaultValue;
				}
				if (xmlNode2 is XmlElement)
				{
					return xmlNode2.InnerText;
				}
				return xmlNode2.Value;
			}
			if (instance is DataRow || instance is DataTable)
			{
				DataRow dataRow = null;
				if (instance is DataRow)
				{
					dataRow = (DataRow)instance;
				}
				else
				{
					DataTable dataTable = (DataTable)instance;
					if (dataTable.Rows.Count > 0)
					{
						dataRow = dataTable.Rows[0];
					}
				}
				if (dataRow == null)
				{
					return defaultValue;
				}
				if (!dataRow.Table.Columns.Contains(item.Name))
				{
					if (throwException)
					{
						throw new IndexOutOfRangeException(item.Name);
					}
					return defaultValue;
				}
				if (throwException)
				{
					return dataRow[item.Name];
				}
				try
				{
					return dataRow[item.Name];
				}
				catch
				{
					return defaultValue;
				}
			}
			if (instance is DataRowView)
			{
				DataRowView dataRowView = (DataRowView)instance;
				if (throwException)
				{
					return dataRowView[item.Name];
				}
				try
				{
					return dataRowView[item.Name];
				}
				catch
				{
					return defaultValue;
				}
			}
			if (instance is IDataRecord)
			{
				IDataRecord dataRecord = (IDataRecord)instance;
				int ordinal = dataRecord.GetOrdinal(item.Name);
				if (ordinal < 0)
				{
					if (throwException)
					{
						throw new IndexOutOfRangeException(item.Name);
					}
					return defaultValue;
				}
				if (throwException)
				{
					return dataRecord.GetValue(ordinal);
				}
				try
				{
					return dataRecord.GetValue(ordinal);
				}
				catch
				{
					return defaultValue;
				}
			}
			if (throwException)
			{
				return item.method_2().GetValue(instance);
			}
			try
			{
				return item.method_2().GetValue(instance);
			}
			catch
			{
				return defaultValue;
			}
		}

		public virtual bool WriteItemValue(GClass115 item, object instance, object newValue, bool throwException)
		{
			int num = 12;
			if (item == null)
			{
				if (throwException)
				{
					throw new ArgumentNullException("item");
				}
				return false;
			}
			if (instance == null)
			{
				if (throwException)
				{
					throw new ArgumentNullException("instance");
				}
				return false;
			}
			if (!item.method_0().IsInstanceOfType(instance))
			{
				if (throwException)
				{
					throw new InvalidCastException(instance.GetType().FullName + ">" + item.method_0().FullName);
				}
				return false;
			}
			if (string.IsNullOrEmpty(item.Name))
			{
				return false;
			}
			if (instance is IDictionary)
			{
				IDictionary dictionary = (IDictionary)instance;
				dictionary[item.Name] = newValue;
				return true;
			}
			if (instance is XmlNode)
			{
				XmlNode xmlNode = (XmlNode)instance;
				string name = item.Name;
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
					xmlNode2.InnerText = Convert.ToString(newValue);
				}
				else
				{
					xmlNode2.Value = Convert.ToString(newValue);
				}
				return true;
			}
			if (instance is DataRow || instance is DataTable)
			{
				DataRow dataRow = null;
				if (instance is DataRow)
				{
					dataRow = (DataRow)instance;
				}
				else
				{
					DataTable dataTable = (DataTable)instance;
					if (dataTable.Rows.Count > 0)
					{
						dataRow = dataTable.Rows[0];
					}
				}
				if (dataRow == null)
				{
					return false;
				}
				if (!dataRow.Table.Columns.Contains(item.Name))
				{
					if (throwException)
					{
						throw new IndexOutOfRangeException(item.Name);
					}
					return false;
				}
				if (throwException)
				{
					dataRow[item.Name] = newValue;
					return true;
				}
				try
				{
					dataRow[item.Name] = newValue;
					return true;
				}
				catch
				{
					return false;
				}
			}
			if (instance is DataRowView)
			{
				DataRowView dataRowView = (DataRowView)instance;
				if (throwException)
				{
					dataRowView[item.Name] = newValue;
					return true;
				}
				try
				{
					dataRowView[item.Name] = newValue;
					return true;
				}
				catch
				{
					return false;
				}
			}
			if (throwException)
			{
				item.method_2().SetValue(instance, newValue);
				return true;
			}
			try
			{
				item.method_2().SetValue(instance, newValue);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		///       写数据
		///       </summary>
		/// <param name="binding">数据源绑定信息对象</param>
		/// <param name="dataSourceInstance">数据源对象</param>
		/// <param name="newValue">新数据值</param>
		/// <param name="throwException">若发生错误是否抛出异常</param>
		/// <returns>操作是否成功</returns>
		public virtual bool WriteValue(XDataBinding binding, object dataSourceInstance, object newValue, bool throwException)
		{
			int num = 17;
			if (dataSourceInstance == null)
			{
				if (throwException)
				{
					throw new ArgumentNullException("dataSourceInstance");
				}
				return false;
			}
			GClass114 gClass = GClass114.smethod_1(dataSourceInstance.GetType(), binding.BindingPath, throwException);
			if (gClass != null)
			{
				if (gClass.method_2())
				{
					if (throwException)
					{
						throw new NotSupportedException("Write " + gClass.method_0().FullName + "." + gClass.method_1());
					}
					return false;
				}
				object obj = dataSourceInstance;
				for (int i = 0; i < gClass.method_3().Count - 1; i++)
				{
					object obj2 = ReadItemValue(gClass.method_3()[i], obj, null, throwException);
					if (obj2 != null)
					{
					}
					obj = obj2;
				}
				if (obj == null)
				{
					return false;
				}
				GClass115 gClass2 = gClass.method_3()[gClass.method_3().Count - 1];
				if (gClass2.method_2() != null && gClass2.method_2().PropertyType != null)
				{
					newValue = ConvertType(binding, newValue, gClass2.method_2().PropertyType);
				}
				return WriteItemValue(gClass2, obj, newValue, throwException);
			}
			return false;
		}

		/// <summary>
		///       写数据
		///       </summary>
		/// <param name="binding">数据源绑定信息对象</param>
		/// <param name="dataSourceInstance">数据源对象</param>
		/// <param name="newValue">新数据值</param>
		/// <param name="throwException">若发生错误是否抛出异常</param>
		/// <returns>操作是否成功</returns>
		public static bool StdWriteValue(XDataBinding binding, object dataSourceInstance, object newValue, bool throwException)
		{
			XDataBindingProvider xDataBindingProvider = new XDataBindingProvider();
			return xDataBindingProvider.WriteValue(binding, dataSourceInstance, newValue, throwException);
		}

		/// <summary>
		///       数据类型转换
		///       </summary>
		/// <param name="binding">数据源绑定信息对象</param>
		/// <param name="oldValue">旧数据</param>
		/// <param name="descType">要转换的类型</param>
		/// <returns>转换后的数据</returns>
		protected static object ConvertType(XDataBinding binding, object oldValue, Type descType)
		{
			if (!string.IsNullOrEmpty(binding.FormatString) && descType.Equals(typeof(DateTime)))
			{
				DateTime result = DateTime.Now;
				DateTime.TryParseExact(Convert.ToString(oldValue), binding.FormatString, null, DateTimeStyles.AllowWhiteSpaces, out result);
				return result;
			}
			TypeConverter converter = TypeDescriptor.GetConverter(descType);
			if (converter != null)
			{
				return converter.ConvertFrom(oldValue);
			}
			return oldValue;
		}

		/// <summary>
		///       读取数据
		///       </summary>
		/// <param name="binding">数据源绑定信息对象</param>
		/// <param name="dataSourceInstance">数据来源对象</param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="throwException">发生错误时是否抛出异常</param>
		/// <returns>读取的数据</returns>
		public virtual object ReadValue(XDataBinding binding, object dataSourceInstance, object defaultValue, bool throwException)
		{
			return StdReadValue(binding, dataSourceInstance, defaultValue, throwException, this);
		}

		/// <summary>
		///       读取数据
		///       </summary>
		/// <param name="binding">数据源绑定信息对象</param>
		/// <param name="dataSourceInstance">数据来源对象</param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="throwException">发生错误时是否抛出异常</param>
		/// <param name="provider">数据绑定提供者对象</param>
		/// <returns>读取的数据</returns>
		public static object StdReadValue(XDataBinding binding, object dataSourceInstance, object defaultValue, bool throwException, XDataBindingProvider provider)
		{
			int num = 18;
			if (dataSourceInstance == null)
			{
				if (throwException)
				{
					throw new ArgumentNullException("dataSourceInstance");
				}
				return false;
			}
			GClass114 gClass = GClass114.smethod_1(dataSourceInstance.GetType(), binding.BindingPath, throwException);
			if (gClass != null)
			{
				object obj = dataSourceInstance;
				for (int i = 0; i < gClass.method_3().Count; i++)
				{
					object obj2 = null;
					obj2 = ((provider != null) ? provider.ReadItemValue(gClass.method_3()[i], obj, null, throwException) : StdReadItemValue(gClass.method_3()[i], obj, null, throwException));
					if (obj2 != null)
					{
					}
					obj = obj2;
				}
				if (!string.IsNullOrEmpty(binding.FormatString) && obj is IFormattable)
				{
					obj = ((IFormattable)obj).ToString(binding.FormatString, null);
				}
				return obj;
			}
			return defaultValue;
		}

		public static object StdReadValue(GClass114 path, object instance, object defaultValue, bool throwException, XDataBindingProvider provider)
		{
			object obj = instance;
			int num = 0;
			while (true)
			{
				if (num < path.method_3().Count)
				{
					object obj2 = null;
					obj2 = ((provider != null) ? provider.ReadItemValue(path.method_3()[num], obj, null, throwException) : StdReadItemValue(path.method_3()[num], obj, null, throwException));
					if (obj2 == null)
					{
						break;
					}
					obj = obj2;
					num++;
					continue;
				}
				return obj;
			}
			return defaultValue;
		}
	}
}
