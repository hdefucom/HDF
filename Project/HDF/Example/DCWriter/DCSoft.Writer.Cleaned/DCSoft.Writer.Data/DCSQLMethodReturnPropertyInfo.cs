using DCSoft.Common;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法的返回属性
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCSQLMethodReturnPropertyInfo
	{
		private Type _ReturnType = null;

		private PropertyInfo _Property = null;

		private string _FieldName = null;

		private int _FieldIndex = -1;

		private string _ParseFormat = null;

		/// <summary>
		///       返回类型
		///       </summary>
		public Type ReturnType
		{
			get
			{
				return _ReturnType;
			}
			set
			{
				_ReturnType = value;
			}
		}

		/// <summary>
		///       属性
		///       </summary>
		public PropertyInfo Property
		{
			get
			{
				return _Property;
			}
			set
			{
				_Property = value;
			}
		}

		/// <summary>
		///       名称
		///       </summary>
		public string Name => _Property.Name;

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
	}
}
