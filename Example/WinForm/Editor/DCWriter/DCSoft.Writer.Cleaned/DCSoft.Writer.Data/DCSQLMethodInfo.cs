using DCSoft.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法
	///       </summary>
	
	[ComVisible(false)]
	public class DCSQLMethodInfo
	{
		private string _ModuleName = null;

		private bool _Invalidate = false;

		private Type _Type = null;

		private MethodInfo _NativeMethod = null;

		private string _Name = null;

		private string _SQLText = null;

		private Dictionary<int, string> _CommandTexts = new Dictionary<int, string>();

		private string _Description = null;

		private DCSQLMethodParameterInfo[] _Parameters = null;

		private DCSQLMethodReturnPropertyInfo[] _ReturnProperties = null;

		private string _RuntimeSQLText = null;

		private DCSQLMethodType _MethodType = DCSQLMethodType.AutoDetect;

		private DCSQLMethodType _RuntimeMethodType = DCSQLMethodType.ExecuteScalar;

		private bool _Fixed = false;

		/// <summary>
		///       所属模块名称
		///       </summary>
		public string ModuleName
		{
			get
			{
				return _ModuleName;
			}
			set
			{
				_ModuleName = value;
			}
		}

		/// <summary>
		///       状态无效
		///       </summary>
		public bool Invalidate
		{
			get
			{
				return _Invalidate;
			}
			set
			{
				_Invalidate = value;
			}
		}

		/// <summary>
		///       类型
		///       </summary>
		public Type Type
		{
			get
			{
				return _Type;
			}
			set
			{
				_Type = value;
			}
		}

		/// <summary>
		///       返回类型
		///       </summary>
		public Type ReturnType
		{
			get
			{
				if (_NativeMethod == null)
				{
					return null;
				}
				return _NativeMethod.ReturnType;
			}
		}

		/// <summary>
		///       方法
		///       </summary>
		public MethodInfo NativeMethod
		{
			get
			{
				return _NativeMethod;
			}
			set
			{
				_NativeMethod = value;
			}
		}

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
		///       SQL文字
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
		///       命令文字
		///       </summary>
		public Dictionary<int, string> CommandTexts
		{
			get
			{
				return _CommandTexts;
			}
			set
			{
				_CommandTexts = value;
			}
		}

		/// <summary>
		///       说明文字
		///       </summary>
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				_Description = value;
			}
		}

		/// <summary>
		///       参数
		///       </summary>
		public DCSQLMethodParameterInfo[] Parameters
		{
			get
			{
				return _Parameters;
			}
			set
			{
				_Parameters = value;
			}
		}

		/// <summary>
		///       返回参数
		///       </summary>
		public DCSQLMethodReturnPropertyInfo[] ReturnProperties
		{
			get
			{
				return _ReturnProperties;
			}
			set
			{
				_ReturnProperties = value;
			}
		}

		/// <summary>
		///       返回SQL文字
		///       </summary>
		public string RuntimeSQLText
		{
			get
			{
				return _RuntimeSQLText;
			}
			set
			{
				_RuntimeSQLText = value;
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
		///       运行时采用的方法类型
		///       </summary>
		public DCSQLMethodType RuntimeMethodType
		{
			get
			{
				return _RuntimeMethodType;
			}
			set
			{
				_RuntimeMethodType = value;
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
		///       验证
		///       </summary>
		/// <param name="runTimeSQL">
		/// </param>
		/// <returns>
		/// </returns>
		public string Validate(string runTimeSQL)
		{
			int num = 11;
			if (string.IsNullOrEmpty(runTimeSQL))
			{
				runTimeSQL = SQLText;
			}
			if (string.IsNullOrEmpty(runTimeSQL))
			{
				return "没有配置SQL语句";
			}
			string[] array = VariableString.AnalyseVariableString(runTimeSQL, "[%", "%]");
			int num2 = 0;
			string text;
			while (true)
			{
				if (num2 < array.Length)
				{
					if (num2 % 2 == 1)
					{
						text = array[num2];
						bool flag = false;
						if (Parameters != null)
						{
							DCSQLMethodParameterInfo[] parameters = Parameters;
							foreach (DCSQLMethodParameterInfo dCSQLMethodParameterInfo in parameters)
							{
								if (string.Compare(dCSQLMethodParameterInfo.Name, text, ignoreCase: true) == 0)
								{
									flag = true;
									break;
								}
							}
						}
						if (!flag)
						{
							break;
						}
					}
					num2++;
					continue;
				}
				return null;
			}
			return "SQL语句中没找到参数" + text;
		}

		internal int GetParameterIndexByFieldName(string fieldName)
		{
			if (_Parameters == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				if (num < _Parameters.Length)
				{
					if (string.Compare(_Parameters[num].Name, fieldName, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		internal DCSQLMethodParameterInfo GetParameterByFieldName(string fieldName)
		{
			if (_Parameters == null)
			{
				return null;
			}
			DCSQLMethodParameterInfo[] parameters = _Parameters;
			int num = 0;
			DCSQLMethodParameterInfo dCSQLMethodParameterInfo;
			while (true)
			{
				if (num < parameters.Length)
				{
					dCSQLMethodParameterInfo = parameters[num];
					if (string.Compare(dCSQLMethodParameterInfo.Name, fieldName, ignoreCase: true) == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return dCSQLMethodParameterInfo;
		}
	}
}
