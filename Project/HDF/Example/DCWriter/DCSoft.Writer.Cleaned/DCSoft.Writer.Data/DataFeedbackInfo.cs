using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       数据回填信息对象
	///       </summary>
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[Editor("DCSoft.Writer.Commands.DataFeedbackInfoUITypeEditor", typeof(UITypeEditor))]
	[DCPublishAPI]
	public class DataFeedbackInfo
	{
		private string _TableName = null;

		private string _FieldName = null;

		private string _FieldValue = null;

		private string _KeyFieldName = null;

		private string _KeyFieldValue = null;

		private string _KeyFieldDataSourcePath = null;

		[NonSerialized]
		private object _Owner = null;

		[NonSerialized]
		private int _ContentVersion = -1;

		private bool _Handled = false;

		/// <summary>
		///       操作的数据表名称
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string TableName
		{
			get
			{
				return _TableName;
			}
			set
			{
				_TableName = value;
			}
		}

		/// <summary>
		///       字段名
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string FieldName
		{
			get
			{
				return _FieldName;
			}
			set
			{
				_FieldName = value;
			}
		}

		/// <summary>
		///       字段数值
		///       </summary>
		[DefaultValue(null)]
		[XmlText]
		public string FieldValue
		{
			get
			{
				return _FieldValue;
			}
			set
			{
				_FieldValue = value;
			}
		}

		/// <summary>
		///       关键字段名
		///       </summary>
		[DefaultValue(null)]
		[XmlAttribute]
		public string KeyFieldName
		{
			get
			{
				return _KeyFieldName;
			}
			set
			{
				_KeyFieldName = value;
			}
		}

		/// <summary>
		///       关键字段值
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
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
		///       关键字段数据源路径
		///       </summary>
		[XmlAttribute]
		[DefaultValue(null)]
		public string KeyFeildDataSourcePath
		{
			get
			{
				return _KeyFieldDataSourcePath;
			}
			set
			{
				_KeyFieldDataSourcePath = value;
			}
		}

		/// <summary>
		///       对象设置是否为空
		///       </summary>
		[Browsable(false)]
		public bool IsEmpty => string.IsNullOrEmpty(TableName) || string.IsNullOrEmpty(FieldName) || string.IsNullOrEmpty(KeyFieldName);

		/// <summary>
		///       对象所属父对象
		///       </summary>
		[Browsable(false)]
		[ComVisible(false)]
		[XmlIgnore]
		public object Owner
		{
			get
			{
				return _Owner;
			}
			set
			{
				_Owner = value;
			}
		}

		/// <summary>
		///       数据对应的容器元素内容版本号
		///       </summary>
		[Browsable(false)]
		[XmlIgnore]
		public int ContentVersion
		{
			get
			{
				return _ContentVersion;
			}
			set
			{
				_ContentVersion = value;
			}
		}

		/// <summary>
		///       对象已经被处理过了。
		///       </summary>
		[XmlIgnore]
		[Browsable(false)]
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DataFeedbackInfo Clone()
		{
			return (DataFeedbackInfo)MemberwiseClone();
		}
	}
}
