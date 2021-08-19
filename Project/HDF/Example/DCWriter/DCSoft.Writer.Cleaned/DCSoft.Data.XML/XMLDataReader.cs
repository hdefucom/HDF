using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Xml;

namespace DCSoft.Data.XML
{
	                                                                    /// <summary>
	                                                                    ///       从XML文档对象读取数据的数据读取器对象
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class XMLDataReader : BaseDataReader, IRecordCount
	{
		private class ColumnInfo
		{
			public string Name = null;

			public string XPath = null;

			public Type DataType = typeof(string);

			public int Style = 0;
		}

		private static Type StringType = typeof(string);

		private string _RecordXPath = null;

		private List<XmlNode> _RecordNodes = null;

		private int intPosition = 0;

		                                                                    /// <summary>
		                                                                    ///       空值标记
		                                                                    ///       </summary>
		private bool bolDBNullFlag = false;

		                                                                    /// <summary>
		                                                                    ///       获得记录的XPath路径
		                                                                    ///       </summary>
		public string RecordXPath
		{
			get
			{
				return _RecordXPath;
			}
			set
			{
				_RecordXPath = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       记录的条数
		                                                                    ///       </summary>
		public int RecordCount
		{
			get
			{
				if (_RecordNodes == null)
				{
					return -1;
				}
				return _RecordNodes.Count;
			}
		}

		public override bool IsClosed => _RecordNodes == null;

		public XMLDataReader()
		{
			bolDirectConvert = false;
		}

		                                                                    /// <summary>
		                                                                    ///       清空设置
		                                                                    ///       </summary>
		public void Clear()
		{
			myColumns.Clear();
			_RecordXPath = null;
			_RecordNodes = null;
			intPosition = -1;
		}

		                                                                    /// <summary>
		                                                                    ///       添加记录集栏目
		                                                                    ///       </summary>
		                                                                    /// <param name="ColumnName">栏目名称</param>
		                                                                    /// <param name="XPath">获取数据的XPath</param>
		                                                                    /// <param name="DataType">数据类型</param>
		public void AddColumn(string ColumnName, string XPath, Type DataType)
		{
			int num = 15;
			if (XPath == null)
			{
				XPath = ".";
			}
			if (XPath != null)
			{
				XPath = XPath.Trim();
			}
			ColumnInfo columnInfo = new ColumnInfo();
			columnInfo.Name = ColumnName;
			columnInfo.XPath = XPath;
			if (XmlReader.IsName(XPath))
			{
				columnInfo.Style = 0;
			}
			else if (XPath.StartsWith("@") && XmlReader.IsName(XPath.Substring(1)))
			{
				columnInfo.XPath = XPath.Substring(1);
				columnInfo.Style = 1;
			}
			else
			{
				columnInfo.Style = 2;
			}
			if (DataType == null)
			{
				columnInfo.DataType = StringType;
			}
			else
			{
				columnInfo.DataType = DataType;
			}
			myColumns.Add(columnInfo);
		}

		                                                                    /// <summary>
		                                                                    ///       添加记录集栏目
		                                                                    ///       </summary>
		                                                                    /// <param name="ColumnName">栏目名称</param>
		                                                                    /// <param name="XPath">获取数据的XPath</param>
		public void AddColumn(string ColumnName, string XPath)
		{
			AddColumn(ColumnName, XPath, null);
		}

		                                                                    /// <summary>
		                                                                    ///       绑定数据源
		                                                                    ///       </summary>
		                                                                    /// <param name="DataSourceNode">数据源XML节点</param>
		                                                                    /// <returns>操作是否成功</returns>
		public bool BindDataSource(XmlNode DataSourceNode)
		{
			intPosition = -1;
			if (DataSourceNode == null)
			{
				_RecordNodes = null;
				return false;
			}
			_RecordNodes = new List<XmlNode>();
			if (_RecordXPath != null && _RecordXPath.Trim().Length > 0)
			{
				foreach (XmlNode item2 in DataSourceNode.SelectNodes(RecordXPath))
				{
					_RecordNodes.Add(item2);
				}
			}
			else
			{
				foreach (XmlNode childNode in DataSourceNode.ChildNodes)
				{
					if (childNode is XmlElement)
					{
						_RecordNodes.Add(childNode);
					}
				}
			}
			return _RecordNodes.Count > 0;
		}

		                                                                    /// <summary>
		                                                                    ///       加载指定的XML文档并绑定到该XML文档
		                                                                    ///       </summary>
		                                                                    /// <param name="strURL">XML文档路径</param>
		                                                                    /// <returns>操作是否成功</returns>
		public bool Load(string strURL)
		{
			int num = 18;
			if (strURL == null || strURL.Length == 0)
			{
				throw new ArgumentNullException("strURL");
			}
			string text = null;
			int num2 = strURL.IndexOf("#");
			if (num2 > 0)
			{
				strURL = strURL.Substring(0, num2);
				text = strURL.Substring(num2 + 1);
			}
			XmlDocument xmlDocument = new XmlDocument();
			XmlTextReader xmlTextReader = new XmlTextReader(strURL);
			try
			{
				xmlTextReader.XmlResolver = null;
				xmlDocument.Load(xmlTextReader);
			}
			finally
			{
				xmlTextReader.Close();
			}
			if (text != null && text.Trim().Length > 0)
			{
				_RecordXPath = text.Trim();
			}
			return BindDataSource(xmlDocument);
		}

		public XmlNode GetXMLNode(int int_0)
		{
			ColumnInfo columnInfo = (ColumnInfo)myColumns[int_0];
			XmlNode result = null;
			string xPath = columnInfo.XPath;
			if (xPath != null && xPath.Trim().Length > 0)
			{
				if (columnInfo.Style != 0)
				{
					result = ((columnInfo.Style != 1) ? _RecordNodes[intPosition].SelectSingleNode(columnInfo.XPath) : _RecordNodes[intPosition].Attributes[columnInfo.XPath]);
				}
				else
				{
					foreach (XmlNode childNode in _RecordNodes[intPosition].ChildNodes)
					{
						if (childNode.Name == columnInfo.XPath)
						{
							result = childNode;
							break;
						}
					}
				}
			}
			else
			{
				result = _RecordNodes[intPosition];
			}
			return result;
		}

		protected string InnerGetString(int index)
		{
			bolDBNullFlag = true;
			XmlNode xMLNode = GetXMLNode(index);
			if (xMLNode == null)
			{
				return null;
			}
			bolDBNullFlag = false;
			if (xMLNode is XmlElement)
			{
				return ((XmlElement)xMLNode).InnerText;
			}
			return xMLNode.Value;
		}

		public override DataTable GetSchemaTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(SchemaTableColumn.ColumnName, typeof(string));
			dataTable.Columns.Add(SchemaTableColumn.ColumnOrdinal, typeof(int));
			dataTable.Columns.Add(SchemaTableColumn.ColumnSize, typeof(int));
			dataTable.Columns.Add(SchemaTableColumn.DataType, typeof(Type));
			dataTable.Columns.Add(SchemaTableColumn.AllowDBNull, typeof(bool));
			for (int i = 0; i < FieldCount; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = GetName(i);
				dataRow[1] = i;
				dataRow[2] = -1;
				dataRow[3] = typeof(string);
				dataRow[4] = true;
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}

		protected override object InnerGetValue(int index)
		{
			string text = InnerGetString(index);
			if (text == null)
			{
				return DBNull.Value;
			}
			Type dataType = ((ColumnInfo)myColumns[index]).DataType;
			if (dataType.Equals(StringType))
			{
				return text;
			}
			return Convert.ChangeType(text, ((ColumnInfo)myColumns[index]).DataType);
		}

		public override void Close()
		{
			_RecordNodes = null;
			intPosition = -1;
		}

		public override bool Read()
		{
			intPosition++;
			return _RecordNodes != null && intPosition >= 0 && intPosition < _RecordNodes.Count;
		}

		protected override bool InnerIsDBNull(int index)
		{
			InnerGetString(index);
			return bolDBNullFlag;
		}

		public override long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			string @string = GetString(ordinal);
			if (@string == null)
			{
				return 0L;
			}
			byte[] array = Convert.FromBase64String(GetString(ordinal));
			int num = (int)(fieldOffset + length);
			if (num >= array.Length)
			{
				num = array.Length - 1;
			}
			long num2 = 0L;
			for (int i = (int)fieldOffset; i <= num; i++)
			{
				buffer[i + bufferoffset] = array[i];
				num2++;
			}
			return num2;
		}

		public override Type GetFieldType(int ordinal)
		{
			return ((ColumnInfo)myColumns[ordinal]).DataType;
		}

		public override string GetName(int ordinal)
		{
			return ((ColumnInfo)myColumns[ordinal]).Name;
		}

		public override Guid GetGuid(int ordinal)
		{
			return new Guid(GetString(ordinal));
		}

		public override long GetChars(int ordinal, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			string @string = GetString(ordinal);
			if (@string == null)
			{
				return 0L;
			}
			int num = (int)(fieldoffset + length);
			if (num >= @string.Length)
			{
				num = @string.Length - 1;
			}
			long num2 = 0L;
			for (int i = (int)fieldoffset; i <= num; i++)
			{
				buffer[bufferoffset + i] = @string[i];
				num2++;
			}
			return num2;
		}
	}
}
