using DCSoft.Data;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Design.Data
{
	/// <summary>
	///       字段信息对象
	///       </summary>
	[Serializable]
	[ComVisible(false)]
	public class DataBaseSchemaField : IComparable
	{
		private string strName = null;

		private string strRemark = null;

		private string strDescription = null;

		private string strCategoryID = null;

		private string strFieldType = null;

		private object objDefaultValue = null;

		private string strFieldWidth = "";

		private bool bolNullable = true;

		private bool bolPrimaryKey = false;

		private bool bolIndexed = false;

		private bool bolIsReadonly = false;

		internal DataBaseSchemaTable myOwnerTable = null;

		/// <summary>
		///       字段名称
		///       </summary>
		[XmlAttribute]
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
		///       字段说明,一般可以为字段中文名
		///       </summary>
		[DefaultValue(null)]
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
		///       字段说明
		///       </summary>
		[DefaultValue(null)]
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
		///       组织类型编号
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string CategoryID
		{
			get
			{
				return strCategoryID;
			}
			set
			{
				strCategoryID = value;
			}
		}

		/// <summary>
		///       字段类型
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string FieldType
		{
			get
			{
				return strFieldType;
			}
			set
			{
				strFieldType = value;
			}
		}

		/// <summary>
		///       字段默认值
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public object DefaultValue
		{
			get
			{
				return objDefaultValue;
			}
			set
			{
				objDefaultValue = value;
			}
		}

		[Browsable(false)]
		[XmlElement("DefaultValue")]
		public XValue InnerDefaultValue
		{
			get
			{
				return new XValue(objDefaultValue);
			}
			set
			{
				objDefaultValue = value.RawValue;
			}
		}

		/// <summary>
		///       判断字段是否是字符串字段
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool IsString
		{
			get
			{
				return TypeContainStrings(new string[3]
				{
					"char",
					"text",
					"string"
				});
			}
			set
			{
			}
		}

		/// <summary>
		///       判断字段是否是整数字段
		///       </summary>
		[DefaultValue(false)]
		[XmlAttribute]
		public bool IsInteger
		{
			get
			{
				return TypeContainStrings(new string[3]
				{
					"int",
					"bit",
					"int32"
				});
			}
			set
			{
			}
		}

		/// <summary>
		///       判断字段是否是布尔类型
		///       </summary>
		[DefaultValue(false)]
		[XmlAttribute]
		public bool IsBoolean
		{
			get
			{
				return TypeContainStrings(new string[1]
				{
					"bit"
				});
			}
			set
			{
			}
		}

		/// <summary>
		///       字段是否是数值的字段
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool IsNumberic
		{
			get
			{
				return TypeContainStrings(new string[6]
				{
					"number",
					"decimal",
					"numberic",
					"float",
					"real",
					"double"
				});
			}
			set
			{
			}
		}

		/// <summary>
		///       是否是日期类型的字段
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool IsDateTime
		{
			get
			{
				return TypeContainStrings(new string[2]
				{
					"date",
					"datetime"
				});
			}
			set
			{
			}
		}

		/// <summary>
		///       是否是二进制类型的字段
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool IsBinary
		{
			get
			{
				return TypeContainStrings(new string[4]
				{
					"binary",
					"long",
					"image",
					"byte[]"
				});
			}
			set
			{
			}
		}

		/// <summary>
		///       字段对应的数据类型
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public Type ValueType
		{
			get
			{
				if (IsBoolean)
				{
					return typeof(bool);
				}
				if (IsInteger)
				{
					return typeof(int);
				}
				if (IsBinary)
				{
					return typeof(byte[]);
				}
				if (IsDateTime)
				{
					return typeof(DateTime);
				}
				if (IsNumberic)
				{
					return typeof(double);
				}
				return typeof(string);
			}
		}

		/// <summary>
		///       字段对应的数据类型名称
		///       </summary>
		public string ValueTypeName
		{
			get
			{
				return ValueType.FullName;
			}
			set
			{
			}
		}

		/// <summary>
		///       字段宽度
		///       </summary>
		[XmlAttribute]
		public string FieldWidth
		{
			get
			{
				return strFieldWidth;
			}
			set
			{
				strFieldWidth = value;
			}
		}

		/// <summary>
		///       字段可否为空
		///       </summary>
		[XmlAttribute]
		[DefaultValue(true)]
		public bool Nullable
		{
			get
			{
				return bolNullable;
			}
			set
			{
				bolNullable = value;
			}
		}

		/// <summary>
		///       是否主键
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool PrimaryKey
		{
			get
			{
				return bolPrimaryKey;
			}
			set
			{
				bolPrimaryKey = value;
			}
		}

		/// <summary>
		///       是否索引
		///       </summary>
		[DefaultValue(false)]
		[XmlAttribute]
		public bool Indexed
		{
			get
			{
				return bolIndexed;
			}
			set
			{
				bolIndexed = value;
			}
		}

		/// <summary>
		///       是否只读
		///       </summary>
		[XmlAttribute]
		[DefaultValue(false)]
		public bool IsReadonly
		{
			get
			{
				return bolIsReadonly;
			}
			set
			{
				bolIsReadonly = value;
			}
		}

		/// <summary>
		///       字段全名
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public string FullName
		{
			get
			{
				int num = 18;
				if (myOwnerTable == null)
				{
					return strName;
				}
				return myOwnerTable.Name + "." + strName;
			}
		}

		/// <summary>
		///       字段所在的数据表对象
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public DataBaseSchemaTable OwnerTable => myOwnerTable;

		private bool TypeContainStrings(string[] items)
		{
			string text = strFieldType;
			if (text != null)
			{
				text = text.ToLower();
				foreach (string value in items)
				{
					if (text.IndexOf(value) >= 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		///       返回表示对象的字符串
		///       </summary>
		/// <returns>字符串</returns>
		public override string ToString()
		{
			return FullName;
		}

		public int CompareTo(object target)
		{
			if (target is DataBaseSchemaField)
			{
				return string.Compare(Name, ((DataBaseSchemaField)target).Name, ignoreCase: true);
			}
			return string.Compare(Name, Convert.ToString(target), ignoreCase: true);
		}
	}
}
