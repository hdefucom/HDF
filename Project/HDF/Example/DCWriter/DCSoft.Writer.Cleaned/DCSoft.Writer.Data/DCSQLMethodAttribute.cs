using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法标记特性
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class DCSQLMethodAttribute : Attribute
	{
		private string _SQLText = null;

		private DCSQLMethodType _MethodType = DCSQLMethodType.AutoDetect;

		private bool _Fixed = false;

		/// <summary>
		///       使用的SQL语句
		///       </summary>
		public string SQLText
		{
			get
			{
				return _SQLText;
			}
			set
			{
				_SQLText = value;
			}
		}

		/// <summary>
		///       方法类型
		///       </summary>
		public DCSQLMethodType MethodType
		{
			get
			{
				return _MethodType;
			}
			set
			{
				_MethodType = value;
			}
		}

		/// <summary>
		///       状态是固定的
		///       </summary>
		public bool Fixed
		{
			get
			{
				return _Fixed;
			}
			set
			{
				_Fixed = value;
			}
		}

		/// <summary>
		///       初始化
		///       </summary>
		/// <param name="sqlText">
		/// </param>
		public DCSQLMethodAttribute(string sqlText)
		{
			_SQLText = sqlText;
		}

		/// <summary>
		///       初始化
		///       </summary>
		/// <param name="sqlText">
		/// </param>
		/// <param name="methodType">
		/// </param>
		public DCSQLMethodAttribute(string sqlText, DCSQLMethodType methodType)
		{
			_SQLText = sqlText;
			_MethodType = methodType;
		}
	}
}
