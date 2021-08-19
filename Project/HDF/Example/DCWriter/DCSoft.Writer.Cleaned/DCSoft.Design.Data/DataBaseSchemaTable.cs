using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Design.Data
{
	/// <summary>
	///       数据表信息对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class DataBaseSchemaTable : IComparable
	{
		private DataBaseSchemaSourceStyle intSourceStyle = DataBaseSchemaSourceStyle.Unknow;

		internal DataBaseSchema myOwnerDataBase = null;

		private string strName = null;

		private string strRemark = null;

		private string strDescription = null;

		[NonSerialized]
		private object objTag = null;

		private DataBaseSchemaFieldCollection myFields = new DataBaseSchemaFieldCollection();

		private DataBaseSchemaTableStyle intStyle = DataBaseSchemaTableStyle.UserTable;

		/// <summary>
		///       对象信息来源类型
		///       </summary>
		[XmlAttribute]
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
		///       对象所属的数据库结构
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public DataBaseSchema OwnerDataBase => myOwnerDataBase;

		/// <summary>
		///       对象名称
		///       </summary>
		[XmlAttribute]
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
		///       对象说明,一般可以为对象中文名
		///       </summary>
		[XmlAttribute]
		public string Remark
		{
			get
			{
				return strRemark;
			}
			set
			{
				strRemark = value;
			}
		}

		/// <summary>
		///       对象说明
		///       </summary>
		[XmlAttribute]
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
		///       对象附加数据
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public object Tag
		{
			get
			{
				return objTag;
			}
			set
			{
				objTag = value;
			}
		}

		/// <summary>
		///       字段对象列表
		///       </summary>
		[Browsable(false)]
		[XmlArrayItem("Field", typeof(DataBaseSchemaField))]
		public DataBaseSchemaFieldCollection Fields
		{
			get
			{
				return myFields;
			}
			set
			{
				myFields = value;
				if (myFields != null)
				{
					myFields.myOwnerTable = this;
				}
			}
		}

		/// <summary>
		///       表类型
		///       </summary>
		[DefaultValue(DataBaseSchemaTableStyle.UserTable)]
		[XmlAttribute]
		public DataBaseSchemaTableStyle Style
		{
			get
			{
				return intStyle;
			}
			set
			{
				intStyle = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public DataBaseSchemaTable()
		{
			myFields.myOwnerTable = this;
		}

		/// <summary>
		///       从一个架构描述表中加载对象数据
		///       </summary>
		/// <param name="table">数据表，该数据表一般是IDataReader.GetSchemaTable()方法获得的。</param>
		/// <returns>加载的字段信息个数</returns>
		public int LoadSchemaDataTable(DataTable table)
		{
			int num = 0;
			foreach (DataRow row in table.Rows)
			{
				DataBaseSchemaField dataBaseSchemaField = new DataBaseSchemaField();
				if (table.Columns.Contains(SchemaTableColumn.ColumnName))
				{
					dataBaseSchemaField.Name = Convert.ToString(row[SchemaTableColumn.ColumnName]);
				}
				if (table.Columns.Contains(SchemaTableColumn.AllowDBNull))
				{
					dataBaseSchemaField.Nullable = Convert.ToBoolean(row[SchemaTableColumn.AllowDBNull]);
				}
				if (table.Columns.Contains(SchemaTableColumn.IsUnique))
				{
					dataBaseSchemaField.Indexed = Convert.ToBoolean(row[SchemaTableColumn.IsUnique]);
				}
				if (table.Columns.Contains(SchemaTableColumn.DataType))
				{
					dataBaseSchemaField.FieldType = Convert.ToString(row[SchemaTableColumn.DataType]);
				}
				if (table.Columns.Contains(SchemaTableColumn.IsKey))
				{
					dataBaseSchemaField.PrimaryKey = Convert.ToBoolean(row[SchemaTableColumn.IsKey]);
				}
				Fields.Add(dataBaseSchemaField);
				num++;
			}
			return num;
		}

		public int CompareTo(object target)
		{
			if (target is DataBaseSchemaTable)
			{
				return string.Compare(Name, ((DataBaseSchemaTable)target).Name, ignoreCase: true);
			}
			return string.Compare(Name, Convert.ToString(target), ignoreCase: true);
		}

		public override string ToString()
		{
			return strName;
		}
	}
}
