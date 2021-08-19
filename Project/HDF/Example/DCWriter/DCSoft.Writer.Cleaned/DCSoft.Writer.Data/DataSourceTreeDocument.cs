using DCSoft.Common;
using DCSoft.Design;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	[Serializable]
	[DCInternal]
	[ComVisible(false)]
	public class DataSourceTreeDocument : DataSourceTreeNode
	{
		private bool _LongPathMode = false;

		private string _RecordItemsNodeName = "Item";

		private char _PathSpliter = '/';

		[NonSerialized]
		[XmlIgnore]
		public QueryRootDataSourceEventHandler EventQueryRootDataSource = null;

		/// <summary>
		///       长路径模式
		///       </summary>
		[DefaultValue(false)]
		[XmlAttribute]
		public bool LongPathMode
		{
			get
			{
				return _LongPathMode;
			}
			set
			{
				_LongPathMode = value;
			}
		}

		/// <summary>
		///       记录节点名称
		///       </summary>
		[XmlAttribute]
		[DefaultValue("Item")]
		public string RecordItemsNodeName
		{
			get
			{
				return _RecordItemsNodeName;
			}
			set
			{
				_RecordItemsNodeName = value;
			}
		}

		/// <summary>
		///       路径分隔字符
		///       </summary>
		[XmlAttribute]
		[DefaultValue('/')]
		public char PathSpliter
		{
			get
			{
				return _PathSpliter;
			}
			set
			{
				_PathSpliter = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public override DataSourceTreeNode Parent => null;

		[XmlIgnore]
		[Browsable(false)]
		public override DataSourceTreeDocument OwnerDocument => this;

		[Browsable(false)]
		public override string FullPath => null;

		[Browsable(false)]
		public override object DataBoundItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public override DataSourceTreeNodeType NodeType
		{
			get
			{
				return DataSourceTreeNodeType.Auto;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public override object RuntimeValue => null;

		[XmlIgnore]
		[Browsable(false)]
		public override string FieldName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataSourceTreeDocument()
		{
			base.Nodes = new DataSourceTreeNodeList();
		}

		public virtual string[] SplitPath(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return null;
			}
			string[] array = path.Split(PathSpliter);
			List<string> list = new List<string>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				string text2 = text.Trim();
				if (text2.Length > 0)
				{
					list.Add(text2);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		///       转换为运行时使用的数据源路径
		///       </summary>
		/// <param name="path">
		/// </param>
		/// <returns>
		/// </returns>
		public virtual string TranslateRuntimePath(string path)
		{
			string[] array = SplitPath(path);
			if (array != null && array.Length > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				string[] array2 = array;
				foreach (string value in array2)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(PathSpliter);
						if (LongPathMode)
						{
							stringBuilder.Append(RecordItemsNodeName);
							stringBuilder.Append(PathSpliter);
						}
					}
					if (LongPathMode)
					{
						stringBuilder.Append(value);
					}
					else
					{
						stringBuilder.Append(value);
					}
				}
				return stringBuilder.ToString();
			}
			return null;
		}

		public override DataSourceTreeNode CreateSubNode(string name)
		{
			if (EventQueryRootDataSource != null)
			{
				QueryRootDataSourceEventArgs queryRootDataSourceEventArgs = new QueryRootDataSourceEventArgs(this, name);
				EventQueryRootDataSource(this, queryRootDataSourceEventArgs);
				if (queryRootDataSourceEventArgs.Result != null)
				{
					DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
					dataSourceTreeNode.Name = name;
					dataSourceTreeNode.DataBoundItem = queryRootDataSourceEventArgs.Result;
					dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Auto;
					base.Nodes.Add(dataSourceTreeNode);
					return dataSourceTreeNode;
				}
			}
			return null;
		}

		public void AddRootNode(string name, object dataBoundItem)
		{
			DataSourceTreeNode dataSourceTreeNode = new DataSourceTreeNode();
			dataSourceTreeNode.Name = name;
			dataSourceTreeNode.DataBoundItem = dataBoundItem;
			dataSourceTreeNode.NodeType = DataSourceTreeNodeType.Auto;
			dataSourceTreeNode.Parent = this;
			dataSourceTreeNode.OwnerDocument = this;
			base.Nodes.Add(dataSourceTreeNode);
		}

		public virtual bool IsCollectionType(Type type_0)
		{
			int num = 12;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (typeof(DataTable).IsAssignableFrom(type_0))
			{
				return true;
			}
			return DesignUtils.GetCollectionItemType(type_0, checkAddMethod: false) != null;
		}

		public virtual bool IsDictionaryType(Type type_0)
		{
			int num = 3;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			return typeof(IDictionary).IsAssignableFrom(type_0);
		}

		public virtual bool IsPrimitiveType(Type type_0)
		{
			int num = 5;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (type_0.IsPrimitive || type_0.Equals(typeof(string)))
			{
				return true;
			}
			return false;
		}

		public void Save(Stream stream)
		{
			int num = 13;
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(stream, this);
		}

		public void Save(string fileName)
		{
			int num = 2;
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				xmlSerializer.Serialize(stream, this);
			}
		}

		public void Save(TextWriter writer)
		{
			int num = 5;
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(writer, this);
		}

		public void Save(XmlWriter writer)
		{
			int num = 10;
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(writer, this);
		}
	}
}
