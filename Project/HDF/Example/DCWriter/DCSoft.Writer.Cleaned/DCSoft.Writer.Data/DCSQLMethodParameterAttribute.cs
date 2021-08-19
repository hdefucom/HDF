using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法的参数特性
	///       </summary>
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
	public class DCSQLMethodParameterAttribute : Attribute
	{
		private string _DispalyFormat = null;

		private bool _MacroMode = false;

		private DCSQLMethodParameterType _ValueType = DCSQLMethodParameterType.Default;

		private string _PropertyName = null;

		/// <summary>
		///       显示格式
		///       </summary>
		public string DispalyFormat
		{
			get
			{
				return _DispalyFormat;
			}
			set
			{
				_DispalyFormat = value;
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

		/// <summary>
		///       相关的属性名
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
		///       初始化
		///       </summary>
		public DCSQLMethodParameterAttribute()
		{
		}

		/// <summary>
		///       初始化
		///       </summary>
		/// <param name="displayFormat">
		/// </param>
		public DCSQLMethodParameterAttribute(string displayFormat)
		{
			_DispalyFormat = displayFormat;
		}
	}
}
