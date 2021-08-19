using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法的参数
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public class DCSQLMethodParameterInfo
	{
		private string _Name = null;

		private Type _ParameterType = null;

		private string _DisplayFormat = null;

		private bool _MacroMode = false;

		private DCSQLMethodParameterType _ValueType = DCSQLMethodParameterType.Default;

		private List<DCSQLMethodParameterInfo> _SubInfos = null;

		private string _PropertyName = null;

		/// <summary>
		///       名称
		///       </summary>
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
		///       参数类型
		///       </summary>
		public Type ParameterType
		{
			get
			{
				return _ParameterType;
			}
			set
			{
				_ParameterType = value;
			}
		}

		/// <summary>
		///       显示格式
		///       </summary>
		public string DisplayFormat
		{
			get
			{
				return _DisplayFormat;
			}
			set
			{
				_DisplayFormat = value;
			}
		}

		/// <summary>
		///       使用宏替换的模式插入SQL参数
		///       </summary>
		public bool MacroMode
		{
			get
			{
				return _MacroMode;
			}
			set
			{
				_MacroMode = value;
			}
		}

		/// <summary>
		///       目标数据类型
		///       </summary>
		public DCSQLMethodParameterType ValueType
		{
			get
			{
				return _ValueType;
			}
			set
			{
				_ValueType = value;
			}
		}

		internal List<DCSQLMethodParameterInfo> SubInfos
		{
			get
			{
				return _SubInfos;
			}
			set
			{
				_SubInfos = value;
			}
		}

		/// <summary>
		///       属性名
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
		///       数据类型
		///       </summary>
		public Type NativeValueType
		{
			get
			{
				switch (ValueType)
				{
				default:
					return typeof(string);
				case DCSQLMethodParameterType.Default:
					return typeof(string);
				case DCSQLMethodParameterType.Boolean:
					return typeof(bool);
				case DCSQLMethodParameterType.Date:
					return typeof(DateTime);
				case DCSQLMethodParameterType.Integer:
					return typeof(int);
				case DCSQLMethodParameterType.Single:
					return typeof(float);
				case DCSQLMethodParameterType.Double:
					return typeof(double);
				case DCSQLMethodParameterType.LongInteger:
					return typeof(long);
				case DCSQLMethodParameterType.String:
					return typeof(string);
				case DCSQLMethodParameterType.LongString:
					return typeof(string);
				}
			}
		}
	}
}
