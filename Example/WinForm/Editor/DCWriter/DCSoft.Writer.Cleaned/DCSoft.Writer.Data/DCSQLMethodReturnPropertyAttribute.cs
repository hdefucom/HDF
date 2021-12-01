using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法返回的属性特性
	///       </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	[ComVisible(false)]
	public class DCSQLMethodReturnPropertyAttribute : Attribute
	{
		private string _PropertyName;

		private string _FieldName;

		private int _FieldIndex;

		private string _ParseFormat;

		/// <summary>
		///       属性名称
		///       </summary>
		public string PropertyName
		{
			get
			{
				return _PropertyName;
			}
			set
			{
				_PropertyName = value;
			}
		}

		/// <summary>
		///       字段名称
		///       </summary>
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
		///       字段序号
		///       </summary>
		public int FieldIndex
		{
			get
			{
				return _FieldIndex;
			}
			set
			{
				_FieldIndex = value;
			}
		}

		/// <summary>
		///       解析时使用的格式化字符串
		///       </summary>
		public string ParseFormat
		{
			get
			{
				return _ParseFormat;
			}
			set
			{
				_ParseFormat = value;
			}
		}

		private DCSQLMethodReturnPropertyAttribute(string propertyName)
		{
			int num = 18;
			_PropertyName = null;
			_FieldName = null;
			_FieldIndex = -1;
			_ParseFormat = null;
			
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException("propertyName");
			}
			_PropertyName = propertyName;
		}

		private DCSQLMethodReturnPropertyAttribute(string propertyName, string fieldName)
		{
			int num = 2;
			_PropertyName = null;
			_FieldName = null;
			_FieldIndex = -1;
			_ParseFormat = null;
			
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException("propertyName");
			}
			_PropertyName = propertyName;
			_FieldName = fieldName;
		}

		private DCSQLMethodReturnPropertyAttribute(int fieldIndex, string propertyName)
		{
			int num = 10;
			_PropertyName = null;
			_FieldName = null;
			_FieldIndex = -1;
			_ParseFormat = null;
			
			if (string.IsNullOrEmpty(propertyName))
			{
				throw new ArgumentNullException("propertyName");
			}
			_PropertyName = propertyName;
			_FieldIndex = fieldIndex;
		}
	}
}
