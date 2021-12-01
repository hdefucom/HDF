using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       执行数据源绑定路径项目事件参数
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class DataBindingPathEventArgs : EventArgs
	{
		private string _Name = null;

		private object _NewValue = null;

		private object _Instance = null;

		private object _DefaultValue = null;

		private bool _ThrowException = false;

		/// <summary>
		///       路径名称
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
		///       新数值
		///       </summary>
		public object NewValue
		{
			get
			{
				return _NewValue;
			}
			set
			{
				_NewValue = value;
			}
		}

		/// <summary>
		///       对象实例
		///       </summary>
		public object Instance => _Instance;

		/// <summary>
		///       默认值
		///       </summary>
		public object DefaultValue => _DefaultValue;

		/// <summary>
		///       是否抛出异常
		///       </summary>
		public bool ThrowException => _ThrowException;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="name">名称</param>
		/// <param name="instance">对象实例</param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="throwException">是否抛出异常</param>
		public DataBindingPathEventArgs(string name, object instance, object defaultValue, bool throwException)
		{
			_Name = name;
			_Instance = instance;
			_DefaultValue = defaultValue;
			_ThrowException = throwException;
		}
	}
}
