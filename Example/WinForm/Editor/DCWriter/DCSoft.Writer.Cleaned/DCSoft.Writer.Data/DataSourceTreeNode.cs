using DCSoft.Common;
using DCSoft.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	[Serializable]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	
	[ComVisible(false)]
	public class DataSourceTreeNode
	{
		/// <summary>
		///       空白的无效的节点
		///       </summary>
		public static readonly DataSourceTreeNode EmptyNode = new DataSourceTreeNode();

		[NonSerialized]
		private object _BindingTarget = null;

		private static int _InstanceIndexCount = 0;

		private int _InstanceIndex = _InstanceIndexCount++;

		private string _ID = null;

		private string _Name = null;

		private bool _Enabled = true;

		private DataSourceTreeNode _Parent = null;

		private DataSourceTreeDocument _OwnerDocument = null;

		[NonSerialized]
		private object _Value = null;

		private string _KeyFieldValue = null;

		private string _TextValue = null;

		[NonSerialized]
		private PropertyInfo _Property = null;

		[NonSerialized]
		private object _DefineSource = null;

		[NonSerialized]
		private object _DataBoundItem = null;

		private string _FieldName = null;

		private DataSourceTreeNodeType _NodeType = DataSourceTreeNodeType.Auto;

		private bool _Readonly = false;

		private DataSourceTreeNodeList _Nodes = null;

		private bool _CanCreateSubNode = true;

		/// <summary>
		///       是否为空白节点
		///       </summary>
		[DefaultValue(false)]
		public bool IsEmpty => this == EmptyNode;

		/// <summary>
		///       绑定的目标
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public virtual object BindingTarget
		{
			get
			{
				return _BindingTarget;
			}
			set
			{
				_BindingTarget = value;
			}
		}

		public virtual string FullPath
		{
			get
			{
				int num = 0;
				StringBuilder stringBuilder = new StringBuilder();
				DataSourceTreeNode dataSourceTreeNode = this;
				while (dataSourceTreeNode != null && !(dataSourceTreeNode is DataSourceTreeDocument))
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Insert(0, "/");
					}
					stringBuilder.Insert(0, dataSourceTreeNode.Name);
					dataSourceTreeNode = dataSourceTreeNode.Parent;
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>
		///       节点实例唯一编号
		///       </summary>
		[ReadOnly(true)]
		[XmlAttribute]
		[DefaultValue(0)]
		public int InstanceIndex
		{
			get
			{
				return _InstanceIndex;
			}
			set
			{
				_InstanceIndex = value;
			}
		}

		/// <summary>
		///       节点编号
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}

		/// <summary>
		///       节点名称
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       节点是否有效
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				_Enabled = value;
			}
		}

		/// <summary>
		///       父对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public virtual DataSourceTreeNode Parent
		{
			get
			{
				if (IsEmpty)
				{
					return null;
				}
				return _Parent;
			}
			internal set
			{
				_Parent = value;
			}
		}

		/// <summary>
		///       对象所属文档对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public virtual DataSourceTreeDocument OwnerDocument
		{
			get
			{
				if (IsEmpty)
				{
					return null;
				}
				return _OwnerDocument;
			}
			internal set
			{
				_OwnerDocument = value;
			}
		}

		/// <summary>
		///       节点值
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public object Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		/// <summary>
		///       对应的关键字段值
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public string KeyFieldValue
		{
			get
			{
				return _KeyFieldValue;
			}
			set
			{
				_KeyFieldValue = value;
			}
		}

		/// <summary>
		///       文本节点值
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		public string TextValue
		{
			get
			{
				return _TextValue;
			}
			set
			{
				_TextValue = value;
			}
		}

		internal bool RuntimeIsDictionary
		{
			get
			{
				if (NodeType == DataSourceTreeNodeType.Entry)
				{
					return false;
				}
				if (DataBoundItem is IDictionary)
				{
					if (OwnerDocument != null)
					{
						return OwnerDocument.IsDictionaryType(DataBoundItem.GetType());
					}
					return true;
				}
				return false;
			}
		}

		internal bool RuntimeIsList
		{
			get
			{
				if (NodeType == DataSourceTreeNodeType.Entry)
				{
					return false;
				}
				if (DataBoundItem is string)
				{
					return false;
				}
				if (DataBoundItem is IList)
				{
					if (OwnerDocument != null)
					{
						return OwnerDocument.IsCollectionType(DataBoundItem.GetType());
					}
					return DesignUtils.GetCollectionItemType(DataBoundItem.GetType(), checkAddMethod: false) != null;
				}
				if (DataBoundItem is DataTable)
				{
					if (OwnerDocument != null)
					{
						return OwnerDocument.IsCollectionType(DataBoundItem.GetType());
					}
					return true;
				}
				return false;
			}
		}

		internal bool HasProperty => _Property != null;

		public object RuntimeDisplayValue
		{
			get
			{
				object runtimeValue = RuntimeValue;
				if (runtimeValue != null && runtimeValue is XmlNode)
				{
					if (runtimeValue is XmlElement)
					{
						return ((XmlElement)runtimeValue).InnerText;
					}
					return ((XmlNode)runtimeValue).Value;
				}
				return runtimeValue;
			}
		}

		public virtual object RuntimeValue
		{
			get
			{
				if (IsEmpty)
				{
					return null;
				}
				if (NodeType == DataSourceTreeNodeType.Text)
				{
					return Value;
				}
				if (DataBoundItem is XmlNode)
				{
					XmlNode xmlNode = (XmlNode)DataBoundItem;
					if (string.IsNullOrEmpty(FieldName))
					{
						return xmlNode;
					}
					if (xmlNode.ChildNodes != null)
					{
						foreach (XmlNode childNode in xmlNode.ChildNodes)
						{
							if (childNode.Name == FieldName)
							{
								return childNode;
							}
						}
					}
					return null;
				}
				if (DataBoundItem is DataTable)
				{
					DataTable dataTable = (DataTable)DataBoundItem;
					if (string.IsNullOrEmpty(FieldName))
					{
						return dataTable;
					}
					DataColumn column = GetColumn(dataTable, FieldName);
					if (column != null && dataTable.Rows.Count > 0)
					{
						return dataTable.Rows[0][column];
					}
					return null;
				}
				if (DataBoundItem is DataRow)
				{
					DataRow dataRow = (DataRow)DataBoundItem;
					if (string.IsNullOrEmpty(FieldName))
					{
						return dataRow;
					}
					DataColumn column = GetColumn(dataRow.Table, FieldName);
					if (column != null)
					{
						return dataRow[column];
					}
					return null;
				}
				if (DataBoundItem is IDictionary && NodeType != DataSourceTreeNodeType.Entry)
				{
					IDictionary dictionary = (IDictionary)DataBoundItem;
					if (!string.IsNullOrEmpty(FieldName))
					{
						if (dictionary.Contains(FieldName))
						{
							return dictionary[FieldName];
						}
						return null;
					}
					return DataBoundItem;
				}
				if (DataBoundItem != null)
				{
					if (!string.IsNullOrEmpty(FieldName))
					{
						if (_Property == null || string.Compare(_Property.Name, FieldName, ignoreCase: true) == 0 || !_Property.DeclaringType.IsInstanceOfType(DataBoundItem))
						{
							_Property = DataBoundItem.GetType().GetProperty(FieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
						}
						if (_Property == null)
						{
							return null;
						}
						return _Property.GetValue(DataBoundItem, null);
					}
					return DataBoundItem;
				}
				if (Value == null)
				{
					return TextValue;
				}
				return Value;
			}
		}

		/// <summary>
		///       定义信息来源
		///       </summary>
		[XmlIgnore]
		public object DefineSource
		{
			get
			{
				return _DefineSource;
			}
			set
			{
				_DefineSource = value;
			}
		}

		/// <summary>
		///       绑定的实体对象
		///       </summary>
		[DefaultValue(null)]
		[XmlIgnore]
		public virtual object DataBoundItem
		{
			get
			{
				return _DataBoundItem;
			}
			set
			{
				if (_DataBoundItem != value)
				{
					_DataBoundItem = value;
					_Property = null;
				}
			}
		}

		/// <summary>
		///       字段名
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public virtual string FieldName
		{
			get
			{
				return _FieldName;
			}
			set
			{
				if (_FieldName != value)
				{
					_FieldName = value;
					_Property = null;
				}
			}
		}

		/// <summary>
		///       节点类型
		///       </summary>
		[DefaultValue(DataSourceTreeNodeType.Text)]
		[XmlAttribute]
		public virtual DataSourceTreeNodeType NodeType
		{
			get
			{
				return _NodeType;
			}
			set
			{
				if (_NodeType != value)
				{
					_NodeType = value;
					_Property = null;
				}
			}
		}

		/// <summary>
		///       节点只读
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
			}
		}

		/// <summary>
		///       子节点列表
		///       </summary>
		[DefaultValue(null)]
		[XmlArrayItem("Node", typeof(DataSourceTreeNode))]
		public DataSourceTreeNodeList Nodes
		{
			get
			{
				if (IsEmpty)
				{
					return null;
				}
				return _Nodes;
			}
			set
			{
				_Nodes = value;
			}
		}

		/// <summary>
		///       是否有子节点
		///       </summary>
		[DefaultValue(false)]
		public bool HasChildNode => _Nodes != null && _Nodes.Count > 0;

		public virtual void ClearBindingTarget()
		{
			_BindingTarget = null;
			if (Nodes != null && Nodes.Count > 0)
			{
				foreach (DataSourceTreeNode node in Nodes)
				{
					node.ClearBindingTarget();
				}
			}
		}

		private string GetTextValue(object object_0)
		{
			if (object_0 == null || DBNull.Value.Equals(object_0))
			{
				return null;
			}
			if (object_0 is byte[])
			{
				return Convert.ToBase64String((byte[])object_0);
			}
			TypeConverter converter = TypeDescriptor.GetConverter(object_0);
			if (converter != null && converter.CanConvertTo(typeof(string)))
			{
				return converter.ConvertToString(object_0);
			}
			return Convert.ToString(object_0);
		}

		public bool SetValue(object newValue)
		{
			if (NodeType == DataSourceTreeNodeType.Text)
			{
				TextValue = GetTextValue(newValue);
				return true;
			}
			if (DataBoundItem is XmlNode)
			{
				if (DataBoundItem is XmlElement)
				{
					XmlElement xmlElement = (XmlElement)DataBoundItem;
					while (xmlElement.FirstChild != null)
					{
						xmlElement.RemoveChild(xmlElement.FirstChild);
					}
					string textValue = GetTextValue(newValue);
					if (!string.IsNullOrEmpty(textValue))
					{
						xmlElement.AppendChild(xmlElement.OwnerDocument.CreateTextNode(textValue));
					}
					return true;
				}
				if (DataBoundItem is XmlAttribute)
				{
					XmlAttribute xmlAttribute = (XmlAttribute)DataBoundItem;
					xmlAttribute.Value = GetTextValue(newValue);
					return true;
				}
			}
			else
			{
				if (DataBoundItem is DataTable)
				{
					DataTable dataTable = (DataTable)DataBoundItem;
					if (!string.IsNullOrEmpty(FieldName))
					{
						DataColumn column = GetColumn(dataTable, FieldName);
						if (column != null && dataTable.Rows.Count > 0)
						{
							if (newValue == null)
							{
								newValue = DBNull.Value;
							}
							else if (column.DataType != null)
							{
								newValue = Convert.ChangeType(newValue, column.DataType);
							}
							dataTable.Rows[0][column] = newValue;
							return true;
						}
					}
					return false;
				}
				if (DataBoundItem is DataRow)
				{
					DataRow dataRow = (DataRow)DataBoundItem;
					if (!string.IsNullOrEmpty(FieldName))
					{
						DataColumn column = GetColumn(dataRow.Table, FieldName);
						if (column != null)
						{
							if (newValue == null)
							{
								newValue = DBNull.Value;
							}
							else if (column.DataType != null)
							{
								newValue = Convert.ChangeType(newValue, column.DataType);
							}
							dataRow[column] = newValue;
							return true;
						}
					}
					return false;
				}
				if (RuntimeIsDictionary)
				{
					IDictionary dictionary = (IDictionary)DataBoundItem;
					dictionary[Name] = newValue;
					return true;
				}
				if (_Property != null)
				{
					if (_Property.CanWrite)
					{
						object value = ValueTypeHelper.ConvertTo(newValue, _Property.PropertyType);
						_Property.SetValue(DataBoundItem, value, null);
						return true;
					}
					return false;
				}
			}
			return false;
		}

		private DataColumn GetColumn(DataTable table, string name)
		{
			foreach (DataColumn column in table.Columns)
			{
				if (string.Compare(column.ColumnName, name, ignoreCase: true) == 0)
				{
					return column;
				}
			}
			return null;
		}

		public void CheckNodesInstance()
		{
			if (!IsEmpty && _Nodes == null)
			{
				_Nodes = new DataSourceTreeNodeList();
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <param name="deeply">是否深度复制</param>
		/// <returns>复制结果</returns>
		public virtual DataSourceTreeNode Clone(bool deeply)
		{
			if (IsEmpty)
			{
				return null;
			}
			DataSourceTreeNode dataSourceTreeNode = (DataSourceTreeNode)MemberwiseClone();
			dataSourceTreeNode._Nodes = null;
			if (deeply && _Nodes != null && _Nodes.Count > 0)
			{
				dataSourceTreeNode._Nodes = new DataSourceTreeNodeList();
				foreach (DataSourceTreeNode node in _Nodes)
				{
					dataSourceTreeNode._Nodes.Add(node.Clone(deeply: true));
				}
			}
			return dataSourceTreeNode;
		}

		public virtual DataSourceTreeNodeList SelectNodes(string path, bool autoCreateNode)
		{
			int num = 19;
			if (IsEmpty)
			{
				return null;
			}
			if (path == ".")
			{
				DataSourceTreeNodeList dataSourceTreeNodeList = new DataSourceTreeNodeList();
				dataSourceTreeNodeList.Add(this);
				return dataSourceTreeNodeList;
			}
			DataSourceTreeNodeList dataSourceTreeNodeList2 = new DataSourceTreeNodeList();
			InnerSelectNodes(path, dataSourceTreeNodeList2, singlMode: false, autoCreateNode);
			return dataSourceTreeNodeList2;
		}

		public virtual DataSourceTreeNode SelectSingleNode(string path, bool autoCreateNode)
		{
			int num = 3;
			if (IsEmpty)
			{
				return null;
			}
			if (path == ".")
			{
				return this;
			}
			DataSourceTreeNodeList dataSourceTreeNodeList = new DataSourceTreeNodeList();
			InnerSelectNodes(path, dataSourceTreeNodeList, singlMode: true, autoCreateNode);
			if (dataSourceTreeNodeList.Count > 0)
			{
				return dataSourceTreeNodeList[0];
			}
			return null;
		}

		private void SplitPathItem(string path, ref string name, ref string subPath)
		{
			int num = path.IndexOf(OwnerDocument.PathSpliter);
			if (num > 0)
			{
				name = path.Substring(0, num);
				subPath = path.Substring(num + 1);
			}
			else
			{
				name = path;
				subPath = null;
			}
		}

		private void InnerSelectNodes(string path, DataSourceTreeNodeList list, bool singlMode, bool autoCreateNode)
		{
			if (string.IsNullOrEmpty(path))
			{
				list.Add(this);
				return;
			}
			string name = null;
			string subPath = null;
			SplitPathItem(path, ref name, ref subPath);
			IList nodes = Nodes;
			bool flag = false;
			if (nodes != null && nodes.Count > 0)
			{
				foreach (DataSourceTreeNode item in nodes)
				{
					if (item.Name == name)
					{
						flag = true;
						if (string.IsNullOrEmpty(subPath))
						{
							list.Add(item);
						}
						else
						{
							item.InnerSelectNodes(subPath, list, singlMode, autoCreateNode);
						}
						if (singlMode && list.Count > 0)
						{
							return;
						}
					}
				}
			}
			if (flag || !autoCreateNode || (singlMode && list.Count > 0))
			{
				return;
			}
			DataSourceTreeNode dataSourceTreeNode = CreateSubNode(name);
			if (dataSourceTreeNode != null)
			{
				if (string.IsNullOrEmpty(subPath))
				{
					list.Add(dataSourceTreeNode);
				}
				else
				{
					dataSourceTreeNode.InnerSelectNodes(subPath, list, singlMode, autoCreateNode);
				}
			}
		}

		public virtual DataSourceTreeNode CreateSubNode(string name)
		{
			int num = 19;
			if (IsEmpty)
			{
				return null;
			}
			if (!_CanCreateSubNode)
			{
				return null;
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			if (NodeType == DataSourceTreeNodeType.Text)
			{
				return null;
			}
			if (Nodes == null)
			{
				Nodes = new DataSourceTreeNodeList();
			}
			object runtimeValue = RuntimeValue;
			if (runtimeValue is XmlNode)
			{
				if (runtimeValue is XmlElement)
				{
					XmlElement xmlElement = (XmlElement)runtimeValue;
					XmlDocument ownerDocument = xmlElement.OwnerDocument;
					DataSourceTreeNode dataSourceTreeNode;
					if (name[0] == '@')
					{
						string name2 = name.Substring(1);
						XmlAttribute xmlAttribute = xmlElement.Attributes[name2];
						if (xmlAttribute == null)
						{
							xmlAttribute = ownerDocument.CreateAttribute(name2);
							xmlElement.Attributes.Append(xmlAttribute);
						}
						dataSourceTreeNode = new DataSourceTreeNode();
						dataSourceTreeNode.OwnerDocument = OwnerDocument;
						dataSourceTreeNode.Parent = this;
						dataSourceTreeNode.Name = name;
						dataSourceTreeNode.DataBoundItem = xmlAttribute;
						dataSourceTreeNode.Value = xmlAttribute.Value;
						dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Xml;
						Nodes.Add(dataSourceTreeNode);
						return dataSourceTreeNode;
					}
					XmlElement xmlElement2 = null;
					foreach (XmlNode childNode in xmlElement.ChildNodes)
					{
						if (childNode.Name == name)
						{
							xmlElement2 = (XmlElement)childNode;
							break;
						}
					}
					if (xmlElement2 == null)
					{
						xmlElement2 = ownerDocument.CreateElement(name);
						xmlElement.AppendChild(xmlElement2);
					}
					dataSourceTreeNode = new DataSourceTreeNode();
					dataSourceTreeNode.OwnerDocument = OwnerDocument;
					dataSourceTreeNode.Parent = this;
					dataSourceTreeNode.Name = name;
					dataSourceTreeNode.DataBoundItem = xmlElement2;
					dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Xml;
					dataSourceTreeNode.Value = xmlElement2.Value;
					Nodes.Add(dataSourceTreeNode);
					return dataSourceTreeNode;
				}
			}
			else if (NodeType == DataSourceTreeNodeType.List)
			{
				if (Nodes == null || Nodes.Count == 0)
				{
					ExpandListItemNodes();
					if (Nodes != null && Nodes.Count > 0)
					{
						DataSourceTreeNode dataSourceTreeNode2 = Nodes[0];
						return dataSourceTreeNode2.GetSubNode(name, autoCreate: false);
					}
				}
			}
			else
			{
				if (runtimeValue is DataTable)
				{
					DataTable dataTable = (DataTable)runtimeValue;
					DataColumn column = GetColumn(dataTable, name);
					if (column != null && dataTable.Rows.Count > 0)
					{
						DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
						dataSourceTreeNode.OwnerDocument = OwnerDocument;
						dataSourceTreeNode.Parent = this;
						dataSourceTreeNode.Name = name;
						dataSourceTreeNode.DataBoundItem = dataTable.Rows[0];
						dataSourceTreeNode.FieldName = name;
						Nodes.Add(dataSourceTreeNode);
						return dataSourceTreeNode;
					}
					return null;
				}
				if (runtimeValue is DataRow)
				{
					DataRow dataRow = (DataRow)runtimeValue;
					DataTable dataTable = dataRow.Table;
					DataColumn column = GetColumn(dataTable, name);
					if (column != null && dataTable.Rows.Count > 0)
					{
						DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
						dataSourceTreeNode.OwnerDocument = OwnerDocument;
						dataSourceTreeNode.Parent = this;
						dataSourceTreeNode.Name = name;
						dataSourceTreeNode.DataBoundItem = dataRow;
						dataSourceTreeNode.FieldName = name;
						Nodes.Add(dataSourceTreeNode);
						return dataSourceTreeNode;
					}
				}
				else
				{
					if (runtimeValue is IDictionary && NodeType != DataSourceTreeNodeType.Entry)
					{
						IDictionary dictionary = (IDictionary)runtimeValue;
						DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
						dataSourceTreeNode.OwnerDocument = OwnerDocument;
						dataSourceTreeNode.Parent = this;
						dataSourceTreeNode.Name = name;
						dataSourceTreeNode.DataBoundItem = dictionary;
						dataSourceTreeNode.FieldName = name;
						dataSourceTreeNode.Readonly = dictionary.IsReadOnly;
						dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Auto;
						Nodes.Add(dataSourceTreeNode);
						return dataSourceTreeNode;
					}
					if (runtimeValue != null)
					{
						PropertyInfo dataProperty = DesignUtils.GetDataProperty(runtimeValue.GetType(), name);
						if (dataProperty == null)
						{
							return null;
						}
						DataSourceTreeNode dataSourceTreeNode = CreateSubNodeByProperty(dataProperty, runtimeValue);
						Nodes.Add(dataSourceTreeNode);
						return dataSourceTreeNode;
					}
				}
			}
			return null;
		}

		private DataSourceTreeNode CreateSubNodeByProperty(PropertyInfo propertyInfo_0, object dataBoundItem)
		{
			DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
			dataSourceTreeNode.OwnerDocument = OwnerDocument;
			dataSourceTreeNode.Parent = this;
			dataSourceTreeNode.Name = propertyInfo_0.Name;
			dataSourceTreeNode.FieldName = propertyInfo_0.Name;
			dataSourceTreeNode.Readonly = !propertyInfo_0.CanWrite;
			dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Entry;
			dataSourceTreeNode.DataBoundItem = DataBoundItem;
			if (OwnerDocument != null)
			{
				if (OwnerDocument.IsCollectionType(propertyInfo_0.PropertyType))
				{
					dataSourceTreeNode.NodeType = DataSourceTreeNodeType.List;
				}
				else if (OwnerDocument.IsDictionaryType(propertyInfo_0.PropertyType))
				{
					dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Dictionary;
				}
			}
			else if (Attribute.GetCustomAttribute(propertyInfo_0, typeof(XmlArrayItemAttribute), inherit: true) != null)
			{
				dataSourceTreeNode.NodeType = DataSourceTreeNodeType.List;
			}
			else if (DesignUtils.GetCollectionItemType(propertyInfo_0.PropertyType, checkAddMethod: false) != null)
			{
				dataSourceTreeNode.NodeType = DataSourceTreeNodeType.List;
			}
			else if (typeof(IDictionary).IsAssignableFrom(propertyInfo_0.PropertyType))
			{
				dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Dictionary;
			}
			dataSourceTreeNode._Property = propertyInfo_0;
			return dataSourceTreeNode;
		}

		public virtual DataSourceTreeNode GetSubNode(string name, bool autoCreate)
		{
			int num = 9;
			if (IsEmpty)
			{
				return null;
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}
			if (Nodes != null && Nodes.Count > 0)
			{
				foreach (DataSourceTreeNode node in Nodes)
				{
					if (node.Name == name)
					{
						return node;
					}
				}
			}
			if (autoCreate)
			{
				return CreateSubNode(name);
			}
			return null;
		}

		public void ExpandSubNodes()
		{
			object runtimeValue = RuntimeValue;
			if (runtimeValue == null)
			{
				Nodes = null;
				return;
			}
			if (runtimeValue is XmlNode)
			{
				XmlNode xmlNode = (XmlNode)runtimeValue;
				Nodes = new DataSourceTreeNodeList();
				if (xmlNode.Attributes != null && xmlNode.Attributes.Count > 0)
				{
					foreach (XmlAttribute attribute in xmlNode.Attributes)
					{
						DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
						dataSourceTreeNode.OwnerDocument = OwnerDocument;
						dataSourceTreeNode.Parent = this;
						dataSourceTreeNode.Name = attribute.Name;
						dataSourceTreeNode.DataBoundItem = attribute;
						dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Xml;
						Nodes.Add(dataSourceTreeNode);
					}
				}
				if (xmlNode.ChildNodes != null && xmlNode.ChildNodes.Count > 0)
				{
					foreach (XmlNode childNode in xmlNode.ChildNodes)
					{
						if (childNode is XmlElement)
						{
							DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
							dataSourceTreeNode.OwnerDocument = OwnerDocument;
							dataSourceTreeNode.Parent = this;
							dataSourceTreeNode.Name = childNode.Name;
							dataSourceTreeNode.DataBoundItem = childNode;
							dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Xml;
							Nodes.Add(dataSourceTreeNode);
						}
					}
				}
				return;
			}
			if (runtimeValue is DataRow)
			{
				DataRow dataRow = (DataRow)runtimeValue;
				DataTable table = dataRow.Table;
				Nodes = new DataSourceTreeNodeList();
				foreach (DataColumn column in table.Columns)
				{
					DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
					dataSourceTreeNode.OwnerDocument = OwnerDocument;
					dataSourceTreeNode.Parent = this;
					dataSourceTreeNode.Name = column.ColumnName;
					dataSourceTreeNode.DataBoundItem = dataRow;
					dataSourceTreeNode.FieldName = column.ColumnName;
					dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Auto;
					Nodes.Add(dataSourceTreeNode);
				}
				_CanCreateSubNode = false;
				return;
			}
			if (runtimeValue is IDictionary && NodeType != DataSourceTreeNodeType.Entry)
			{
				Nodes = new DataSourceTreeNodeList();
				IDictionary dictionary = (IDictionary)DataBoundItem;
				foreach (object key in dictionary.Keys)
				{
					DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
					dataSourceTreeNode.OwnerDocument = OwnerDocument;
					dataSourceTreeNode.Parent = this;
					dataSourceTreeNode.Name = Convert.ToString(key);
					dataSourceTreeNode.DataBoundItem = runtimeValue;
					dataSourceTreeNode.FieldName = dataSourceTreeNode.Name;
					dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Auto;
					Nodes.Add(dataSourceTreeNode);
				}
				return;
			}
			Nodes = new DataSourceTreeNodeList();
			PropertyInfo[] dataProperties = DesignUtils.GetDataProperties(runtimeValue.GetType());
			foreach (PropertyInfo propertyInfo_ in dataProperties)
			{
				DataSourceTreeNode dataSourceTreeNode = CreateSubNodeByProperty(propertyInfo_, runtimeValue);
				Nodes.Add(dataSourceTreeNode);
			}
			_CanCreateSubNode = false;
		}

		public void ExpandListItemNodes()
		{
			int num = 9;
			float tickCountFloat = CountDown.GetTickCountFloat();
			object runtimeValue = RuntimeValue;
			if (runtimeValue is DataTable)
			{
				DataTable dataTable = (DataTable)runtimeValue;
				Nodes = new DataSourceTreeNodeList();
				foreach (DataRow row in dataTable.Rows)
				{
					DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
					dataSourceTreeNode.OwnerDocument = OwnerDocument;
					dataSourceTreeNode.Parent = this;
					dataSourceTreeNode.Name = "Item";
					dataSourceTreeNode.DataBoundItem = row;
					dataSourceTreeNode.NodeType = DataSourceTreeNodeType.DataTable;
					Nodes.Add(dataSourceTreeNode);
					dataSourceTreeNode.ExpandSubNodes();
				}
			}
			else if (runtimeValue is IList)
			{
				IList list = (IList)runtimeValue;
				Nodes = new DataSourceTreeNodeList();
				foreach (object item in list)
				{
					DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
					dataSourceTreeNode.OwnerDocument = OwnerDocument;
					dataSourceTreeNode.Parent = this;
					dataSourceTreeNode.Name = "Item";
					dataSourceTreeNode.DataBoundItem = item;
					dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Entry;
					dataSourceTreeNode.Readonly = list.IsReadOnly;
					Nodes.Add(dataSourceTreeNode);
				}
			}
			tickCountFloat = CountDown.GetTickCountFloat() - tickCountFloat;
		}

		public virtual void FixDomState()
		{
			if (Nodes != null && Nodes.Count > 0)
			{
				foreach (DataSourceTreeNode node in Nodes)
				{
					node.Parent = this;
					node.OwnerDocument = OwnerDocument;
					node.FixDomState();
				}
			}
		}

		public override string ToString()
		{
			int num = 17;
			if (IsEmpty)
			{
				return "Empty node";
			}
			return Name + "=" + RuntimeValue;
		}
	}
}
