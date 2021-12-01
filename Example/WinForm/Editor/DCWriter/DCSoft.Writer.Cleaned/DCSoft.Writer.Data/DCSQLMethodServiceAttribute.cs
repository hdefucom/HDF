using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       表示包含SQL方法的对象类型
	///       </summary>
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class DCSQLMethodServiceAttribute : Attribute
	{
		private string _Name = null;

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
		///       初始化
		///       </summary>
		public DCSQLMethodServiceAttribute()
		{
		}

		/// <summary>
		///       初始化
		///       </summary>
		/// <param name="name">
		/// </param>
		public DCSQLMethodServiceAttribute(string name)
		{
			_Name = name;
		}
	}
}
