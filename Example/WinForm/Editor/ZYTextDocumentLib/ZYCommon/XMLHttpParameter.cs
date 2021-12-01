using System.Data;

namespace ZYCommon
{
	public class XMLHttpParameter : IDbDataParameter, IDataParameter
	{
		private ParameterDirection intDirection = ParameterDirection.Input;

		private DataRowVersion intSourceVersion = DataRowVersion.Default;

		private DbType intDbType = DbType.String;

		private object objValue = null;

		private string strParameterName = null;

		private string strSourceColumn = null;

		public ParameterDirection Direction
		{
			get
			{
				return intDirection;
			}
			set
			{
				intDirection = value;
			}
		}

		public DbType DbType
		{
			get
			{
				return intDbType;
			}
			set
			{
				intDbType = value;
			}
		}

		public object Value
		{
			get
			{
				return objValue;
			}
			set
			{
				objValue = value;
			}
		}

		public bool IsNullable => false;

		public DataRowVersion SourceVersion
		{
			get
			{
				return intSourceVersion;
			}
			set
			{
				intSourceVersion = value;
			}
		}

		public string ParameterName
		{
			get
			{
				return strParameterName;
			}
			set
			{
				strParameterName = value;
			}
		}

		public string SourceColumn
		{
			get
			{
				return strSourceColumn;
			}
			set
			{
				strSourceColumn = value;
			}
		}

		public byte Precision
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte Scale
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Size
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public XMLHttpParameter(string strValue)
		{
			objValue = strValue;
		}

		public XMLHttpParameter()
		{
		}
	}
}
