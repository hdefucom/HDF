using DCSoftDotfuscate;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Services;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Design.Data
{
	/// <summary>
	///       分析数据库表结构的对象
	///       </summary>
	/// <remarks>
	///       本对象能分析Access2000,Oracle,SQLServer 的数据库,并加载其表结构定义.
	///       也可从PDM文件中加载表结构定义
	///       编制 袁永福 </remarks>
	[Serializable]
	[ComVisible(false)]
	public class DataBaseSchema : ICloneable
	{
		private static DataBaseSchema myInstance = new DataBaseSchema();

		private string strName = null;

		private string strDescription = null;

		private DataBaseSchemaTableCollection myTables = new DataBaseSchemaTableCollection();

		/// <summary>
		///       对象填充样式
		///       </summary>
		protected DataBaseSchemaSourceStyle intSourceStyle = DataBaseSchemaSourceStyle.Unknow;

		/// <summary>
		///       对象唯一静态实例
		///       </summary>
		public static DataBaseSchema Instance
		{
			get
			{
				return myInstance;
			}
			set
			{
				myInstance = value;
			}
		}

		/// <summary>
		///       对象名称
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
			}
		}

		/// <summary>
		///       对象说明
		///       </summary>
		[DefaultValue(null)]
		public string Description
		{
			get
			{
				return strDescription;
			}
			set
			{
				strDescription = value;
			}
		}

		/// <summary>
		///       总共包含的字段个数
		///       </summary>
		[Browsable(false)]
		public int FieldCount
		{
			get
			{
				int num = 0;
				foreach (DataBaseSchemaTable myTable in myTables)
				{
					num += myTable.Fields.Count;
				}
				return num;
			}
		}

		/// <summary>
		///       数据库表信息列表
		///       </summary>
		[Browsable(false)]
		[XmlArrayItem("Table", typeof(DataBaseSchemaTable))]
		public DataBaseSchemaTableCollection Tables
		{
			get
			{
				return myTables;
			}
			set
			{
				myTables = value;
				if (myTables != null)
				{
					myTables.myOwnerDataBase = this;
				}
			}
		}

		/// <summary>
		///       对象填充样式
		///       </summary>
		[DefaultValue(DataBaseSchemaSourceStyle.Unknow)]
		public DataBaseSchemaSourceStyle SourceStyle
		{
			get
			{
				return intSourceStyle;
			}
			set
			{
				intSourceStyle = value;
			}
		}

		/// <summary>
		///       无作为的初始化对象
		///       </summary>
		public DataBaseSchema()
		{
			myTables.myOwnerDataBase = this;
		}

		/// <summary>
		///       获得指定表名和字段名的字段对象
		///       </summary>
		/// <param name="TableName">表名</param>
		/// <param name="FieldName">字段名</param>
		/// <returns>获得的字段对象,若未找到则返回空引用</returns>
		public DataBaseSchemaField GetField(string TableName, string FieldName)
		{
			return myTables[TableName]?.Fields[FieldName];
		}

		/// <summary>
		///       获得指定全名称的字段对象
		///       </summary>
		/// <param name="FullName">字段名称,格式为 表名.字段名</param>
		/// <returns>获得的字段对象,若为找到怎返回空引用</returns>
		public DataBaseSchemaField GetField(string FullName)
		{
			int num = 14;
			if (FullName == null)
			{
				return null;
			}
			int num2 = FullName.IndexOf(".");
			if (num2 <= 0)
			{
				return null;
			}
			return GetField(FullName.Substring(0, num2).Trim(), FullName.Substring(num2 + 1).Trim());
		}

		/// <summary>
		///       从一个PDM数据结构定义文件中加载数据结构信息
		///       </summary>
		/// <param name="strFileName">PDM文件名</param>
		/// <returns>加载的字段信息个数</returns>
		public int LoadFromPDMXMLFile(string strFileName)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(strFileName);
			return LoadFromPDMXMLDocument(xmlDocument);
		}

		/// <summary>
		///       从PDM数据结构定义XML文件中加载数据结构信息
		///       </summary>
		/// <param name="doc">XML文档对象</param>
		/// <returns>加载的字段信息个数</returns>
		public int LoadFromPDMXMLDocument(XmlDocument xmlDocument_0)
		{
			int num = 2;
			SourceStyle = DataBaseSchemaSourceStyle.PDM;
			int num2 = 0;
			myTables.Clear();
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument_0.NameTable);
			xmlNamespaceManager.AddNamespace("a", "attribute");
			xmlNamespaceManager.AddNamespace("c", "collection");
			xmlNamespaceManager.AddNamespace("o", "object");
			XmlNode xmlNode = xmlDocument_0.SelectSingleNode("/Model/o:RootObject/c:Children/o:Model", xmlNamespaceManager);
			if (xmlNode == null)
			{
				return 0;
			}
			strName = ReadXMLValue(xmlNode, "a:Name", xmlNamespaceManager);
			strDescription = strName;
			foreach (XmlNode item in xmlNode.SelectNodes("//c:Tables/o:Table", xmlNamespaceManager))
			{
				DataBaseSchemaTable dataBaseSchemaTable = new DataBaseSchemaTable();
				dataBaseSchemaTable.myOwnerDataBase = this;
				dataBaseSchemaTable.SourceStyle = SourceStyle;
				myTables.Add(dataBaseSchemaTable);
				dataBaseSchemaTable.Name = ReadXMLValue(item, "a:Code", xmlNamespaceManager);
				dataBaseSchemaTable.Remark = ReadXMLValue(item, "a:Name", xmlNamespaceManager);
				string text = ReadXMLValue(item, "c:PrimaryKey/o:Key/@Ref", xmlNamespaceManager);
				StringCollection stringCollection = new StringCollection();
				if (text != null)
				{
					foreach (XmlNode item2 in item.SelectNodes("c:Keys/o:Key[@Id = '" + text + "']/c:Key.Columns/o:Column/@Ref", xmlNamespaceManager))
					{
						stringCollection.Add(item2.Value);
					}
				}
				foreach (XmlNode item3 in item.SelectNodes("c:Columns/o:Column", xmlNamespaceManager))
				{
					num2++;
					string attribute = ((XmlElement)item3).GetAttribute("Id");
					DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
					dataBaseSchemaField.myOwnerTable = dataBaseSchemaTable;
					dataBaseSchemaTable.Fields.Add(dataBaseSchemaField);
					dataBaseSchemaField.Name = ReadXMLValue(item3, "a:Code", xmlNamespaceManager);
					dataBaseSchemaField.Remark = ReadXMLValue(item3, "a:Name", xmlNamespaceManager);
					dataBaseSchemaField.Description = ReadXMLValue(item3, "a:Comment", xmlNamespaceManager);
					string text2 = ReadXMLValue(item3, "a:DataType", xmlNamespaceManager);
					if (text2 != null)
					{
						int num3 = text2.IndexOf("(");
						if (num3 > 0)
						{
							text2 = text2.Substring(0, num3);
						}
					}
					dataBaseSchemaField.FieldType = text2;
					dataBaseSchemaField.FieldWidth = ReadXMLValue(item3, "a:Length", xmlNamespaceManager);
					if (stringCollection.Contains(attribute))
					{
						dataBaseSchemaField.PrimaryKey = true;
					}
					string text3 = ReadXMLValue(item3, "a:Description", xmlNamespaceManager);
					if (!string.IsNullOrEmpty(text3))
					{
						text3 = text3.Trim();
						if (text3.StartsWith("{\\rtf"))
						{
							dataBaseSchemaField.Description = FastGetRTFContentText(text3);
						}
						else
						{
							dataBaseSchemaField.Description = text3;
						}
					}
				}
			}
			SortByName();
			return num2;
		}

		private string FastGetRTFContentText(string string_0)
		{
			int num = 7;
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			string text = "0123456789abcdef";
			string[] array = string_0.Split('\\');
			Encoding @default = Encoding.Default;
			GClass367 gClass = new GClass367();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			char[] anyOf = new char[4]
			{
				' ',
				'\r',
				'\n',
				'\t'
			};
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				string text3 = text2.Trim();
				if (text3.Length == 0)
				{
					continue;
				}
				if (text3[text3.Length - 1] == '{')
				{
					text3 = text3.Substring(0, text3.Length - 1);
				}
				if (text3.EndsWith("}"))
				{
					text3 = text3.Substring(0, text3.Length - 1);
				}
				if (text3.Length == 0)
				{
					continue;
				}
				string text4 = null;
				if (text3[0] == '\'')
				{
					if (text3.Length >= 3 && flag)
					{
						int num2 = text.IndexOf(text3[1]);
						int num3 = text.IndexOf(text3[2]);
						if (num2 >= 0 && num3 >= 0)
						{
							byte byte_ = (byte)(num2 * 16 + num3);
							gClass.method_3(byte_);
						}
					}
					if (text3.Length > 3)
					{
						text4 = text3.Substring(3);
					}
				}
				else
				{
					int num4 = text3.IndexOfAny(anyOf);
					if (num4 >= 0)
					{
						text4 = text3.Substring(num4 + 1).Trim();
						text3 = text3.Substring(0, num4);
					}
					int result = int.MinValue;
					for (int j = 0; j < text3.Length; j++)
					{
						if ("0123456789-".IndexOf(text3[j]) >= 0)
						{
							text3 = text2.Substring(0, j);
							int.TryParse(text2.Substring(j), out result);
							break;
						}
					}
					if (text2 == "pard")
					{
						flag = true;
					}
				}
				if (text4 != null && text4.Length > 0 && flag)
				{
					if (gClass.method_0() > 0)
					{
						stringBuilder.Append(@default.GetString(gClass.method_6()));
						gClass.method_1();
					}
					stringBuilder.Append(text4);
				}
			}
			if (gClass.method_0() > 0)
			{
				stringBuilder.Append(@default.GetString(gClass.method_6()));
			}
			return stringBuilder.ToString();
		}

		private string ReadXMLValue(XmlNode node, string path, XmlNamespaceManager xmlNamespaceManager_0)
		{
			XmlNode xmlNode = node.SelectSingleNode(path, xmlNamespaceManager_0);
			if (xmlNode == null)
			{
				return null;
			}
			if (xmlNode is XmlElement)
			{
				return ((XmlElement)xmlNode).InnerText;
			}
			return xmlNode.Value;
		}

		public void SortByName()
		{
			Tables.SortByName();
			foreach (DataBaseSchemaTable table in Tables)
			{
				table.Fields.SortByName();
			}
		}

		/// <summary>
		///       根据数据库连接设置相应的FillStyle值
		///       </summary>
		/// <param name="conn">
		/// </param>
		private void setFillStyleValue(IDbConnection conn)
		{
			if (GClass317.smethod_7(conn))
			{
				intSourceStyle = DataBaseSchemaSourceStyle.Access2000;
			}
			else if (GClass317.smethod_6(conn))
			{
				intSourceStyle = DataBaseSchemaSourceStyle.Oracle;
			}
			else if (GClass317.smethod_5(conn))
			{
				intSourceStyle = DataBaseSchemaSourceStyle.SQLServer;
			}
			else
			{
				intSourceStyle = DataBaseSchemaSourceStyle.Unknow;
			}
		}

		public int Load(IDbConnection conn)
		{
			if (conn is SqlConnection)
			{
				return LoadFromSQLServer((SqlConnection)conn);
			}
			if (conn is OleDbConnection)
			{
				return LoadFromDB((OleDbConnection)conn);
			}
			if (conn is OracleConnection)
			{
				return LoadFromDB((OracleConnection)conn);
			}
			if (conn is OdbcConnection)
			{
				return LoadFromDB((OdbcConnection)conn);
			}
			return 0;
		}

		/// <summary>
		///       LoadFromDB SqlConnection DataSource
		///       </summary>
		/// <param name="myConn">
		/// </param>
		/// <returns>
		/// </returns>
		public int LoadFromDB(SqlConnection myConn)
		{
			return LoadFromSQLServer(myConn);
		}

		/// <summary>
		///       从一个SQL SERVER加载信息
		///       </summary>
		/// <param name="myConn">
		/// </param>
		/// <returns>
		/// </returns>
		public int LoadFromSQLServer(DbConnection myConn)
		{
			int num = 18;
			SourceStyle = DataBaseSchemaSourceStyle.SQLServer;
			int num2 = 0;
			myTables.Clear();
			if (string.IsNullOrEmpty(myConn.Database))
			{
				string dataSource = myConn.DataSource;
				if (dataSource != null)
				{
					strName = Path.GetFileName(dataSource);
				}
			}
			else
			{
				strName = myConn.Database;
			}
			string text = myConn.Database;
			string text2 = null;
			using (DataTable dataTable = myConn.GetSchema(SqlClientMetaDataCollectionNames.Tables, new string[4]
			{
				text,
				text2,
				null,
				"BASE TABLE"
			}))
			{
				int ordinal = dataTable.Columns["TABLE_CATALOG"].Ordinal;
				int ordinal2 = dataTable.Columns["TABLE_SCHEMA"].Ordinal;
				int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
				if (dataTable.Rows.Count > 0)
				{
					if (dataTable.Rows[0][ordinal] != null && dataTable.Rows[0][ordinal].ToString().Trim() != string.Empty)
					{
						text = dataTable.Rows[0][ordinal].ToString();
					}
					if (dataTable.Rows[0][ordinal2] != null && dataTable.Rows[0][ordinal2].ToString().Trim() != string.Empty)
					{
						text2 = dataTable.Rows[0][ordinal2].ToString();
					}
				}
				foreach (DataRow row in dataTable.Rows)
				{
					DataBaseSchemaTable dataBaseSchemaTable = new DataBaseSchemaTable();
					dataBaseSchemaTable.myOwnerDataBase = this;
					dataBaseSchemaTable.SourceStyle = SourceStyle;
					dataBaseSchemaTable.Name = row[ordinal3].ToString();
					dataBaseSchemaTable.Remark = string.Empty;
					dataBaseSchemaTable.Remark = dataBaseSchemaTable.Remark;
					myTables.Add(dataBaseSchemaTable);
				}
			}
			using (DataTable dataTable = myConn.GetSchema(SqlClientMetaDataCollectionNames.Views))
			{
				int ordinal = dataTable.Columns["TABLE_CATALOG"].Ordinal;
				int ordinal2 = dataTable.Columns["TABLE_SCHEMA"].Ordinal;
				int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
				if (dataTable.Rows.Count > 0)
				{
					if (dataTable.Rows[0][ordinal] != null && dataTable.Rows[0][ordinal].ToString().Trim() != string.Empty)
					{
						text = dataTable.Rows[0][ordinal].ToString();
					}
					if (dataTable.Rows[0][ordinal2] != null && dataTable.Rows[0][ordinal2].ToString().Trim() != string.Empty)
					{
						text2 = dataTable.Rows[0][ordinal2].ToString();
					}
				}
				foreach (DataRow row2 in dataTable.Rows)
				{
					DataBaseSchemaTable dataBaseSchemaTable = new DataBaseSchemaTable();
					dataBaseSchemaTable.myOwnerDataBase = this;
					dataBaseSchemaTable.SourceStyle = SourceStyle;
					dataBaseSchemaTable.Name = row2[ordinal3].ToString();
					dataBaseSchemaTable.Remark = string.Empty;
					dataBaseSchemaTable.Remark = dataBaseSchemaTable.Remark;
					dataBaseSchemaTable.Style = DataBaseSchemaTableStyle.View;
					myTables.Add(dataBaseSchemaTable);
				}
			}
			using (DataTable dataTable = myConn.GetSchema(SqlClientMetaDataCollectionNames.Columns, new string[4]
			{
				text,
				text2,
				null,
				null
			}))
			{
				int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
				int ordinal4 = dataTable.Columns["COLUMN_NAME"].Ordinal;
				int ordinal5 = dataTable.Columns["IS_NULLABLE"].Ordinal;
				int ordinal6 = dataTable.Columns["COLUMN_DEFAULT"].Ordinal;
				int ordinal7 = dataTable.Columns["DATA_TYPE"].Ordinal;
				int ordinal8 = dataTable.Columns["CHARACTER_MAXIMUM_LENGTH"].Ordinal;
				foreach (DataRow row3 in dataTable.Rows)
				{
					DataBaseSchemaTable dataBaseSchemaTable = myTables[row3[ordinal3].ToString()];
					if (dataBaseSchemaTable != null)
					{
						DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
						dataBaseSchemaField.myOwnerTable = dataBaseSchemaTable;
						dataBaseSchemaTable.Fields.Add(dataBaseSchemaField);
						dataBaseSchemaField.Name = row3[ordinal4].ToString();
						dataBaseSchemaField.Nullable = row3[ordinal5].ToString().StartsWith("Yes", StringComparison.CurrentCultureIgnoreCase);
						dataBaseSchemaField.DefaultValue = row3[ordinal6];
						dataBaseSchemaField.Remark = string.Empty;
						dataBaseSchemaField.FieldType = row3[ordinal7].ToString();
						dataBaseSchemaField.FieldWidth = row3[ordinal8].ToString();
						num2++;
					}
				}
			}
			using (DataTable dataTable = myConn.GetSchema(SqlClientMetaDataCollectionNames.IndexColumns, new string[3]
			{
				text,
				text2,
				null
			}))
			{
				int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
				int ordinal4 = dataTable.Columns["COLUMN_NAME"].Ordinal;
				int ordinal9 = dataTable.Columns["CONSTRAINT_NAME"].Ordinal;
				foreach (DataRow row4 in dataTable.Rows)
				{
					DataBaseSchemaTable dataBaseSchemaTable = myTables[row4[ordinal3].ToString()];
					if (dataBaseSchemaTable != null)
					{
						DataBaseSchemaField dataBaseSchemaField = dataBaseSchemaTable.Fields[row4[ordinal4].ToString()];
						if (dataBaseSchemaField != null)
						{
							dataBaseSchemaField.Indexed = true;
							dataBaseSchemaField.PrimaryKey = row4[ordinal9].ToString().StartsWith("PK_");
						}
					}
				}
			}
			SortByName();
			return num2;
		}

		/// <summary>
		///       LoadFromDB OracleConnection DataSource(未完)
		///       </summary>
		/// <param name="myConn">
		/// </param>
		/// <returns>
		/// </returns>
		public int LoadFromDB(OracleConnection myConn)
		{
			int num = 3;
			SourceStyle = DataBaseSchemaSourceStyle.Oracle;
			int num2 = 0;
			myTables.Clear();
			strName = myConn.DataSource;
			string text = null;
			using (DataTable dataTable = myConn.GetSchema("TABLES", new string[2]
			{
				text,
				null
			}))
			{
				int ordinal = dataTable.Columns["OWNER"].Ordinal;
				int ordinal2 = dataTable.Columns["TABLE_NAME"].Ordinal;
				DataRow[] array = dataTable.Select("TYPE ='User'", "TYPE");
				if (array.Length > 0 && array[0][ordinal] != null && array[0][ordinal].ToString().Trim() != string.Empty)
				{
					text = array[0][ordinal].ToString();
				}
				DataRow[] array2 = array;
				foreach (DataRow dataRow in array2)
				{
					DataBaseSchemaTable dataBaseSchemaTable = new DataBaseSchemaTable();
					dataBaseSchemaTable.myOwnerDataBase = this;
					dataBaseSchemaTable.SourceStyle = SourceStyle;
					dataBaseSchemaTable.Name = Convert.ToString(dataRow[ordinal2]).Trim();
					dataBaseSchemaTable.Description = string.Empty;
					dataBaseSchemaTable.Remark = string.Empty;
					myTables.Add(dataBaseSchemaTable);
				}
			}
			foreach (DataBaseSchemaTable myTable in myTables)
			{
				using (DataTable dataTable = myConn.GetSchema("Columns", new string[2]
				{
					null,
					myTable.Name
				}))
				{
					int ordinal2 = dataTable.Columns["TABLE_NAME"].Ordinal;
					int ordinal3 = dataTable.Columns["COLUMN_NAME"].Ordinal;
					int ordinal4 = dataTable.Columns["NULLABLE"].Ordinal;
					int ordinal5 = dataTable.Columns["LENGTH"].Ordinal;
					int ordinal6 = dataTable.Columns["DATATYPE"].Ordinal;
					foreach (DataRow row in dataTable.Rows)
					{
						DataBaseSchemaTable dataBaseSchemaTable = myTables[row[ordinal2].ToString()];
						if (dataBaseSchemaTable != null)
						{
							DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
							dataBaseSchemaField.myOwnerTable = dataBaseSchemaTable;
							dataBaseSchemaTable.Fields.Add(dataBaseSchemaField);
							dataBaseSchemaField.Name = row[ordinal3].ToString();
							dataBaseSchemaField.Nullable = row[ordinal4].ToString().Equals("Y");
							dataBaseSchemaField.DefaultValue = string.Empty;
							dataBaseSchemaField.Remark = string.Empty;
							dataBaseSchemaField.FieldType = row[ordinal6].ToString().ToLower();
							dataBaseSchemaField.FieldWidth = row[ordinal5].ToString();
							num2++;
						}
					}
				}
			}
			foreach (DataBaseSchemaTable myTable2 in myTables)
			{
				using (DataTable dataTable = myConn.GetSchema("Indexes", new string[4]
				{
					null,
					null,
					null,
					myTable2.Name
				}))
				{
					foreach (DataRow row2 in dataTable.Rows)
					{
						DataBaseSchemaTable dataBaseSchemaTable = myTables[row2["TABLE_NAME"].ToString()];
						if (dataBaseSchemaTable != null)
						{
							DataBaseSchemaField dataBaseSchemaField = dataBaseSchemaTable.Fields[Convert.ToString(row2["INCLUDE_COLUMN"])];
							if (dataBaseSchemaField != null)
							{
								dataBaseSchemaField.Indexed = true;
								dataBaseSchemaField.PrimaryKey = row2["UNIQUENESS"].ToString().Equals("UNIQUE");
							}
						}
					}
				}
			}
			SortByName();
			using (IDbCommand dbCommand = myConn.CreateCommand())
			{
				dbCommand.CommandText = "Select table_name , comments from user_tab_comments";
				IDataReader dataReader = dbCommand.ExecuteReader();
				while (dataReader.Read())
				{
					if (!dataReader.IsDBNull(1))
					{
						string strTableName = Convert.ToString(dataReader.GetValue(0));
						string description = Convert.ToString(dataReader.GetValue(1));
						DataBaseSchemaTable dataBaseSchemaTable3 = Tables[strTableName];
						if (dataBaseSchemaTable3 != null)
						{
							dataBaseSchemaTable3.Description = description;
						}
					}
				}
				dataReader.Close();
				dbCommand.CommandText = "Select table_name, column_name,comments from user_col_comments";
				dataReader = dbCommand.ExecuteReader();
				while (dataReader.Read())
				{
					if (!dataReader.IsDBNull(2))
					{
						string strTableName = Convert.ToString(dataReader.GetValue(0));
						string strFieldName = Convert.ToString(dataReader.GetValue(1));
						string description = Convert.ToString(dataReader.GetValue(2));
						DataBaseSchemaTable dataBaseSchemaTable3 = Tables[strTableName];
						if (dataBaseSchemaTable3 != null)
						{
							DataBaseSchemaField dataBaseSchemaField2 = dataBaseSchemaTable3.Fields[strFieldName];
							if (dataBaseSchemaField2 != null)
							{
								dataBaseSchemaField2.Description = description;
							}
						}
					}
				}
				dataReader.Close();
			}
			return num2;
		}

		/// <summary>
		///       LoadFromDB OleDbConnection DataSource
		///       </summary>
		/// <param name="myConn">
		/// </param>
		/// <returns>
		/// </returns>
		public int LoadFromDB(OleDbConnection myConn)
		{
			int num = 12;
			setFillStyleValue(myConn);
			int num2 = 0;
			myTables.Clear();
			if (string.IsNullOrEmpty(myConn.Database))
			{
				string dataSource = myConn.DataSource;
				if (dataSource != null)
				{
					strName = Path.GetFileName(dataSource);
				}
			}
			else
			{
				strName = myConn.Database;
			}
			string text = null;
			string text2 = null;
			using (DataTable dataTable = myConn.GetSchema(OleDbMetaDataCollectionNames.Tables, new string[4]
			{
				null,
				null,
				null,
				"TABLE"
			}))
			{
				int ordinal = dataTable.Columns["TABLE_CATALOG"].Ordinal;
				int ordinal2 = dataTable.Columns["TABLE_SCHEMA"].Ordinal;
				int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
				int ordinal4 = dataTable.Columns["DESCRIPTION"].Ordinal;
				if (dataTable.Rows.Count > 0)
				{
					if (HasValue(dataTable.Rows[0][ordinal]))
					{
						text = Convert.ToString(dataTable.Rows[0][ordinal]);
					}
					if (HasValue(dataTable.Rows[0][ordinal2]))
					{
						text2 = Convert.ToString(dataTable.Rows[0][ordinal2]);
					}
				}
				foreach (DataRow row in dataTable.Rows)
				{
					DataBaseSchemaTable dataBaseSchemaTable = new DataBaseSchemaTable();
					dataBaseSchemaTable.myOwnerDataBase = this;
					dataBaseSchemaTable.SourceStyle = SourceStyle;
					dataBaseSchemaTable.Name = row[ordinal3].ToString();
					if (HasValue(row[ordinal4]))
					{
						dataBaseSchemaTable.Remark = Convert.ToString(row[ordinal4]);
					}
					dataBaseSchemaTable.Remark = dataBaseSchemaTable.Remark;
					myTables.Add(dataBaseSchemaTable);
				}
			}
			using (DataTable dataTable = myConn.GetSchema(OleDbMetaDataCollectionNames.Columns, new string[3]
			{
				text,
				text2,
				null
			}))
			{
				int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
				int ordinal5 = dataTable.Columns["COLUMN_NAME"].Ordinal;
				int ordinal6 = dataTable.Columns["IS_NULLABLE"].Ordinal;
				int ordinal7 = dataTable.Columns["COLUMN_DEFAULT"].Ordinal;
				int ordinal8 = dataTable.Columns["DATA_TYPE"].Ordinal;
				int ordinal4 = dataTable.Columns["DESCRIPTION"].Ordinal;
				int ordinal9 = dataTable.Columns["CHARACTER_MAXIMUM_LENGTH"].Ordinal;
				foreach (DataRow row2 in dataTable.Rows)
				{
					DataBaseSchemaTable dataBaseSchemaTable = myTables[Convert.ToString(row2[ordinal3])];
					if (dataBaseSchemaTable != null)
					{
						DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
						dataBaseSchemaField.myOwnerTable = dataBaseSchemaTable;
						dataBaseSchemaTable.Fields.Add(dataBaseSchemaField);
						dataBaseSchemaField.Name = Convert.ToString(row2[ordinal5]);
						dataBaseSchemaField.Nullable = Convert.ToBoolean(row2[ordinal6]);
						dataBaseSchemaField.DefaultValue = row2[ordinal7];
						if (HasValue(row2[ordinal4]))
						{
							dataBaseSchemaField.Remark = Convert.ToString(row2[ordinal4]);
						}
						OleDbType oleDbType = (OleDbType)Convert.ToInt32(row2[ordinal8]);
						if (oleDbType == OleDbType.WChar)
						{
							dataBaseSchemaField.FieldType = "Char";
						}
						else
						{
							dataBaseSchemaField.FieldType = oleDbType.ToString();
						}
						dataBaseSchemaField.FieldWidth = Convert.ToString(row2[ordinal9]);
						num2++;
					}
				}
			}
			using (DataTable dataTable = myConn.GetSchema(OleDbMetaDataCollectionNames.Indexes, new string[3]
			{
				text,
				text2,
				null
			}))
			{
				int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
				int ordinal5 = dataTable.Columns["COLUMN_NAME"].Ordinal;
				int ordinal10 = dataTable.Columns["PRIMARY_KEY"].Ordinal;
				foreach (DataRow row3 in dataTable.Rows)
				{
					DataBaseSchemaTable dataBaseSchemaTable = myTables[Convert.ToString(row3[ordinal3])];
					if (dataBaseSchemaTable != null)
					{
						DataBaseSchemaField dataBaseSchemaField = dataBaseSchemaTable.Fields[Convert.ToString(row3[ordinal5])];
						if (dataBaseSchemaField != null)
						{
							dataBaseSchemaField.Indexed = true;
							if (!dataBaseSchemaField.PrimaryKey)
							{
								dataBaseSchemaField.PrimaryKey = Convert.ToBoolean(row3[ordinal10]);
							}
						}
					}
				}
			}
			SortByName();
			return num2;
		}

		private bool HasValue(object object_0)
		{
			return object_0 != null && !DBNull.Value.Equals(object_0);
		}

		/// <summary>
		/// </summary>
		/// <param name="myConn">
		/// </param>
		/// <returns>
		/// </returns>
		public int LoadFromDB(OdbcConnection myConn)
		{
			int num = 5;
			setFillStyleValue(myConn);
			int num2 = 0;
			myTables.Clear();
			if (string.IsNullOrEmpty(myConn.Database))
			{
				string dataSource = myConn.DataSource;
				if (dataSource != null)
				{
					strName = Path.GetFileName(dataSource);
				}
			}
			else
			{
				strName = myConn.Database;
			}
			string text = null;
			string text2 = null;
			using (DataTable dataTable = myConn.GetSchema(OdbcMetaDataCollectionNames.Tables, new string[3]
			{
				text,
				text2,
				null
			}))
			{
				int ordinal = dataTable.Columns["TABLE_CAT"].Ordinal;
				int ordinal2 = dataTable.Columns["TABLE_SCHEM"].Ordinal;
				int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
				int ordinal4 = dataTable.Columns["REMARKS"].Ordinal;
				DataRow[] array = dataTable.Select("TABLE_TYPE <>'SYSTEM TABLE'", "TABLE_TYPE");
				if (array.Length > 0)
				{
					if (array[0][ordinal] != null && array[0][ordinal].ToString().Trim() != string.Empty)
					{
						text = array[0][ordinal].ToString();
					}
					if (array[0][ordinal2] != null && array[0][ordinal2].ToString().Trim() != string.Empty)
					{
						text2 = array[0][ordinal2].ToString();
					}
				}
				DataRow[] array2 = array;
				foreach (DataRow dataRow in array2)
				{
					DataBaseSchemaTable dataBaseSchemaTable = new DataBaseSchemaTable();
					dataBaseSchemaTable.myOwnerDataBase = this;
					dataBaseSchemaTable.SourceStyle = SourceStyle;
					dataBaseSchemaTable.Name = Convert.ToString(dataRow[ordinal3]).Trim();
					dataBaseSchemaTable.Description = Convert.ToString(dataRow[ordinal4]);
					dataBaseSchemaTable.Remark = Convert.ToString(dataRow[ordinal4]);
					myTables.Add(dataBaseSchemaTable);
				}
			}
			foreach (DataBaseSchemaTable myTable in myTables)
			{
				using (DataTable dataTable = myConn.GetSchema(OdbcMetaDataCollectionNames.Columns, new string[3]
				{
					text,
					text2,
					myTable.Name
				}))
				{
					int ordinal3 = dataTable.Columns["TABLE_NAME"].Ordinal;
					int ordinal5 = dataTable.Columns["COLUMN_NAME"].Ordinal;
					int ordinal6 = dataTable.Columns["IS_NULLABLE"].Ordinal;
					int ordinal7 = dataTable.Columns["COLUMN_DEF"].Ordinal;
					int ordinal4 = dataTable.Columns["REMARKS"].Ordinal;
					int ordinal8 = dataTable.Columns["COLUMN_SIZE"].Ordinal;
					int ordinal9 = dataTable.Columns["SQL_DATA_TYPE"].Ordinal;
					foreach (DataRow row in dataTable.Rows)
					{
						DataBaseSchemaTable dataBaseSchemaTable = myTables[row[ordinal3].ToString()];
						if (dataBaseSchemaTable != null)
						{
							DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
							dataBaseSchemaField.myOwnerTable = dataBaseSchemaTable;
							dataBaseSchemaTable.Fields.Add(dataBaseSchemaField);
							dataBaseSchemaField.Name = row[ordinal5].ToString();
							dataBaseSchemaField.Nullable = row[ordinal6].ToString().Equals("YES");
							dataBaseSchemaField.DefaultValue = row[ordinal7];
							dataBaseSchemaField.Remark = row[ordinal4].ToString();
							OdbcType odbcType = (OdbcType)Convert.ToInt32(row[ordinal9]);
							dataBaseSchemaField.FieldType = odbcType.ToString();
							dataBaseSchemaField.FieldWidth = row[ordinal8].ToString();
							num2++;
						}
					}
				}
			}
			foreach (DataBaseSchemaTable myTable2 in myTables)
			{
				using (DataTable dataTable = myConn.GetSchema(OdbcMetaDataCollectionNames.Indexes, new string[3]
				{
					text,
					text2,
					myTable2.Name
				}))
				{
					foreach (DataRow row2 in dataTable.Rows)
					{
						DataBaseSchemaTable dataBaseSchemaTable = myTables[row2["TABLE_NAME"].ToString()];
						if (dataBaseSchemaTable != null)
						{
							DataBaseSchemaField dataBaseSchemaField = dataBaseSchemaTable.Fields[Convert.ToString(row2["COLUMN_NAME"])];
							if (dataBaseSchemaField != null)
							{
								dataBaseSchemaField.Indexed = true;
								if (!dataBaseSchemaField.PrimaryKey)
								{
									dataBaseSchemaField.PrimaryKey = row2["NON_UNIQUE"].ToString().Equals("0");
								}
							}
						}
					}
				}
			}
			SortByName();
			return num2;
		}

		/// <summary>
		///       将数据转换为布尔数值
		///       </summary>
		/// <param name="obj">数据</param>
		/// <returns>转换的布尔数值</returns>
		private bool boolParse(object object_0)
		{
			int num = 18;
			if (object_0 == null)
			{
				return false;
			}
			if (DBNull.Value.Equals(object_0))
			{
				return false;
			}
			string text = object_0.ToString().ToLower();
			if (text.StartsWith("yes"))
			{
				return true;
			}
			if (text.StartsWith("no"))
			{
				return false;
			}
			if (text.Equals("0"))
			{
				return false;
			}
			if (text.Equals("1"))
			{
				return true;
			}
			bool result = false;
			if (!bool.TryParse(object_0.ToString(), out result))
			{
				result = false;
			}
			return true;
		}

		/// <summary> 从 MySQL 中加载数据库结构信息
		///       从 MySQL 中加载数据库结构信息
		///       </summary>
		/// <param name="myConn">数据库连接对象</param>
		/// <returns>加载的字段信息个数</returns>
		public int LoadFromMySQL(IDbConnection myConn)
		{
			int num = 15;
			intSourceStyle = DataBaseSchemaSourceStyle.MySQL;
			int num2 = 0;
			string text = null;
			text = "show tables from " + myConn.Database;
			myTables.Clear();
			using (IDbCommand dbCommand = myConn.CreateCommand())
			{
				dbCommand.CommandText = text;
				using (IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult))
				{
					while (dataReader.Read())
					{
						DataBaseSchemaTable dataBaseSchemaTable = new DataBaseSchemaTable();
						dataBaseSchemaTable.Name = dataReader.GetString(0).Trim();
						Tables.Add(dataBaseSchemaTable);
					}
				}
				foreach (DataBaseSchemaTable table in Tables)
				{
					string text2 = null;
					text2 = (dbCommand.CommandText = "show columns from " + table.Name);
					IDataReader dataReader2 = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
					while (dataReader2.Read())
					{
						DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
						table.Fields.Add(dataBaseSchemaField);
						dataBaseSchemaField.Name = dataReader2.GetString(0);
						string @string = dataReader2.GetString(1);
						if (@string.ToLower() == "datetime" || @string.ToLower() == "date")
						{
							dataBaseSchemaField.FieldType = @string;
						}
						else if (@string.ToLower() == "longblob" || @string.ToLower() == "longtext")
						{
							dataBaseSchemaField.FieldType = @string;
							dataBaseSchemaField.FieldWidth = "4294967295";
						}
						else if (@string.ToLower() == "mediumtext")
						{
							dataBaseSchemaField.FieldType = @string;
							dataBaseSchemaField.FieldWidth = "16777215";
						}
						else if (@string.ToLower() == "text")
						{
							dataBaseSchemaField.FieldType = @string;
							dataBaseSchemaField.FieldWidth = "65535";
						}
						else if (@string.ToLower() == "tinytext")
						{
							dataBaseSchemaField.FieldType = @string;
							dataBaseSchemaField.FieldWidth = "255";
						}
						else if (@string.IndexOf("(") == -1)
						{
							dataBaseSchemaField.FieldType = @string;
							dataBaseSchemaField.FieldWidth = "0";
						}
						else
						{
							try
							{
								dataBaseSchemaField.FieldType = @string.Substring(0, @string.IndexOf("("));
								dataBaseSchemaField.FieldWidth = @string.Substring(@string.IndexOf("(") + 1, @string.IndexOf(")") - @string.IndexOf("(") - 1);
							}
							catch (Exception ex)
							{
								Console.WriteLine(ex.Message);
							}
						}
						if (!dataReader2.IsDBNull(2))
						{
							dataBaseSchemaField.Nullable = (dataReader2.GetString(2).ToUpper() == "YES");
						}
						num2++;
					}
					dataReader2.Close();
					for (int num3 = myTables.Count - 1; num3 >= 0; num3--)
					{
						DataBaseSchemaTable dataBaseSchemaTable2 = myTables[num3];
						try
						{
							string text5 = dbCommand.CommandText = "show index from " + dataBaseSchemaTable2.Name;
							dataReader2 = dbCommand.ExecuteReader();
							while (dataReader2.Read())
							{
								string string2 = dataReader2.GetString(2);
								string string3 = dataReader2.GetString(4);
								bool primaryKey = string2.ToLower() == "primary";
								DataBaseSchemaField dataBaseSchemaField2 = table.Fields[string3.Trim()];
								if (dataBaseSchemaField2 != null)
								{
									dataBaseSchemaField2.Indexed = true;
									dataBaseSchemaField2.PrimaryKey = primaryKey;
								}
							}
							dataReader2.Close();
						}
						catch (Exception ex2)
						{
							table.Name = table.Name + " " + ex2.Message;
						}
					}
				}
			}
			SortByName();
			return num2;
		}

		/// <summary>
		///       从 Oracle 加载数据库结构信息
		///       </summary>
		/// <param name="myConn">数据库连接对象</param>
		/// <returns>加载的字段信息个数</returns>
		public int LoadFromOracle(IDbConnection myConn)
		{
			int num = 10;
			SourceStyle = DataBaseSchemaSourceStyle.Oracle;
			int num2 = 0;
			string text = null;
			text = "Select TName,CName,coltype,width  From Col Order by TName,CName";
			myTables.Clear();
			if (myConn is OleDbConnection)
			{
				strName = ((OleDbConnection)myConn).DataSource + " - " + myConn.Database;
			}
			else
			{
				strName = myConn.Database;
			}
			using (IDbCommand dbCommand = myConn.CreateCommand())
			{
				dbCommand.CommandText = text;
				IDataReader dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
				DataBaseSchemaTable dataBaseSchemaTable = null;
				while (dataReader.Read())
				{
					string text2 = dataReader.GetString(0).Trim();
					if (dataBaseSchemaTable == null || dataBaseSchemaTable.Name != text2)
					{
						dataBaseSchemaTable = new DataBaseSchemaTable();
						dataBaseSchemaTable.SourceStyle = SourceStyle;
						myTables.Add(dataBaseSchemaTable);
						dataBaseSchemaTable.Name = text2;
					}
					DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
					dataBaseSchemaTable.Fields.Add(dataBaseSchemaField);
					dataBaseSchemaField.Name = dataReader.GetString(1);
					dataBaseSchemaField.FieldType = dataReader.GetString(2);
					dataBaseSchemaField.FieldWidth = dataReader[3].ToString();
					num2++;
				}
				dataReader.Close();
				dbCommand.CommandText = "\r\nselect table_name , \r\n\tcolumn_name , \r\n\tindex_name \r\nfrom user_ind_columns \r\norder by table_name , column_name ";
				dataReader = dbCommand.ExecuteReader(CommandBehavior.SingleResult);
				DataBaseSchemaTable dataBaseSchemaTable2 = null;
				while (dataReader.Read())
				{
					dataBaseSchemaTable2 = myTables[dataReader.GetString(0)];
					if (dataBaseSchemaTable2 != null)
					{
						string @string = dataReader.GetString(2);
						string string2 = dataReader.GetString(1);
						DataBaseSchemaField dataBaseSchemaField2 = dataBaseSchemaTable2.Fields[string2];
						if (dataBaseSchemaField2 != null)
						{
							dataBaseSchemaField2.Indexed = true;
							if (@string.StartsWith("PK"))
							{
								dataBaseSchemaField2.PrimaryKey = true;
							}
						}
					}
				}
				dataReader.Close();
			}
			SortByName();
			return num2;
		}

		public int LoadFromAssembly(string strFileName)
		{
			int num = 7;
			if (!File.Exists(strFileName))
			{
				throw new FileNotFoundException("未找到文件:" + strFileName);
			}
			byte[] array = null;
			using (FileStream fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
			{
				array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
			}
			if (array.Length == 0)
			{
				return 0;
			}
			string currentDirectory = Environment.CurrentDirectory;
			Environment.CurrentDirectory = Path.GetDirectoryName(strFileName);
			AppDomainSetup appDomainSetup = new AppDomainSetup();
			appDomainSetup.ApplicationBase = "file:///" + Path.GetDirectoryName(strFileName);
			appDomainSetup.DisallowBindingRedirects = false;
			appDomainSetup.DisallowCodeDownload = false;
			appDomainSetup.ApplicationName = "DataBaseInfoTempApp";
			AppDomain appDomain = AppDomain.CreateDomain("TempD46FC6A5-6D21-42c4-9768-CBB02954F478", null, appDomainSetup);
			try
			{
				Console.WriteLine(appDomain.BaseDirectory);
				Console.WriteLine(appDomain.RelativeSearchPath);
				AssemblyName assemblyName = new AssemblyName();
				assemblyName.CodeBase = "file:///" + Path.GetDirectoryName(strFileName);
				assemblyName.Name = Path.GetFileNameWithoutExtension(strFileName);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(strFileName);
				Assembly assembly_ = appDomain.Load(fileNameWithoutExtension);
				Environment.CurrentDirectory = currentDirectory;
				int result = LoadFromAssembly(assembly_);
				strName = Path.GetFileName(strFileName);
				return result;
			}
			finally
			{
				AppDomain.Unload(appDomain);
			}
		}

		private static Assembly domain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			Console.WriteLine(args.Name);
			return null;
		}

		public int LoadFromAssembly(Assembly assembly_0)
		{
			intSourceStyle = DataBaseSchemaSourceStyle.Assembly;
			strName = assembly_0.FullName;
			AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly_0, typeof(AssemblyTitleAttribute));
			if (assemblyTitleAttribute != null)
			{
				Description = assemblyTitleAttribute.Title;
			}
			int num = 0;
			myTables.Clear();
			Type[] types = assembly_0.GetTypes();
			foreach (Type type in types)
			{
				if (type.Namespace == null || type.IsSubclassOf(typeof(System.Windows.Forms.Control)) || type.IsSubclassOf(typeof(System.Web.UI.Control)) || type.IsSubclassOf(typeof(Attribute)) || type.IsSubclassOf(typeof(WebService)) || !type.IsPublic || !type.IsClass)
				{
					continue;
				}
				DataBaseSchemaTable dataBaseSchemaTable = new DataBaseSchemaTable();
				dataBaseSchemaTable.Name = type.Name;
				dataBaseSchemaTable.myOwnerDataBase = this;
				DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(type, typeof(DescriptionAttribute));
				if (descriptionAttribute != null)
				{
					dataBaseSchemaTable.Remark = descriptionAttribute.Description;
				}
				dataBaseSchemaTable.Tag = type;
				myTables.Add(dataBaseSchemaTable);
				MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public);
				if (members != null && members.Length > 0)
				{
					MemberInfo[] array = members;
					foreach (MemberInfo memberInfo in array)
					{
						if (memberInfo.Name == null || memberInfo is MethodInfo)
						{
							continue;
						}
						if (memberInfo is PropertyInfo)
						{
							PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
							if (!propertyInfo.CanRead)
							{
								continue;
							}
							ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
							if (indexParameters == null || indexParameters.Length <= 0)
							{
								Type propertyType = propertyInfo.PropertyType;
								DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
								dataBaseSchemaField.myOwnerTable = dataBaseSchemaTable;
								dataBaseSchemaField.Name = propertyInfo.Name;
								descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(DescriptionAttribute));
								if (descriptionAttribute != null)
								{
									dataBaseSchemaField.Description = descriptionAttribute.Description;
								}
								dataBaseSchemaField.FieldType = propertyType.Name;
								dataBaseSchemaTable.Fields.Add(dataBaseSchemaField);
								num++;
							}
						}
						else if (memberInfo is FieldInfo)
						{
							FieldInfo fieldInfo = (FieldInfo)memberInfo;
							Type propertyType = fieldInfo.FieldType;
							DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
							dataBaseSchemaField.myOwnerTable = dataBaseSchemaTable;
							dataBaseSchemaField.Name = fieldInfo.Name;
							descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
							if (descriptionAttribute != null)
							{
								dataBaseSchemaField.Description = descriptionAttribute.Description;
							}
							dataBaseSchemaField.FieldType = propertyType.Name;
							dataBaseSchemaTable.Fields.Add(dataBaseSchemaField);
							num++;
						}
					}
				}
				if (dataBaseSchemaTable.Fields.Count == 0)
				{
					myTables.Remove(dataBaseSchemaTable);
				}
			}
			SortByName();
			return num;
		}

		object ICloneable.Clone()
		{
			DataBaseSchema dataBaseSchema = new DataBaseSchema();
			dataBaseSchema.intSourceStyle = intSourceStyle;
			dataBaseSchema.strDescription = strDescription;
			dataBaseSchema.Name = strName;
			foreach (DataBaseSchemaTable myTable in myTables)
			{
				DataBaseSchemaTable dataBaseSchemaTable2 = new DataBaseSchemaTable();
				dataBaseSchemaTable2.Name = myTable.Name;
				dataBaseSchemaTable2.Remark = myTable.Remark;
				dataBaseSchemaTable2.Description = myTable.Description;
				dataBaseSchemaTable2.Tag = myTable.Tag;
				dataBaseSchemaTable2.myOwnerDataBase = dataBaseSchema;
				dataBaseSchema.myTables.Add(dataBaseSchemaTable2);
				foreach (DataBaseSchemaField field in myTable.Fields)
				{
					DataBaseSchemaField dataBaseSchemaField2 = new DataBaseSchemaField();
					dataBaseSchemaField2.Name = field.Name;
					dataBaseSchemaField2.Remark = field.Remark;
					dataBaseSchemaField2.Description = field.Description;
					dataBaseSchemaField2.FieldType = field.FieldType;
					dataBaseSchemaField2.FieldWidth = field.FieldWidth;
					dataBaseSchemaField2.Indexed = field.Indexed;
					dataBaseSchemaField2.Nullable = field.Nullable;
					dataBaseSchemaField2.PrimaryKey = field.PrimaryKey;
					dataBaseSchemaField2.DefaultValue = field.DefaultValue;
					dataBaseSchemaField2.myOwnerTable = dataBaseSchemaTable2;
					dataBaseSchemaTable2.Fields.Add(dataBaseSchemaField2);
				}
			}
			return dataBaseSchema;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DataBaseSchema Clone()
		{
			return (DataBaseSchema)((ICloneable)this).Clone();
		}
	}
}
