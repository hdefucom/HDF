using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       执行表达式函数事件参数
	///       </summary>
	[Guid("C4B8B1C8-94D0-4F97-8EF0-578CBBD3DB47")]
	[ComVisible(true)]
	[ComClass("C4B8B1C8-94D0-4F97-8EF0-578CBBD3DB47", "92FB3A91-1D68-4200-8AA8-B399F5070341")]
	
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComDefaultInterface(typeof(IWriterExpressionFunctionEventArgs))]
	public class WriterExpressionFunctionEventArgs : WriterEventArgs, IWriterExpressionFunctionEventArgs
	{
		internal new const string CLASSID = "C4B8B1C8-94D0-4F97-8EF0-578CBBD3DB47";

		internal new const string CLASSID_Interface = "92FB3A91-1D68-4200-8AA8-B399F5070341";

		private object[] _Parameters = null;

		private string _FunctionName = null;

		private object _Result = null;

		private bool _Handled = false;

		/// <summary>
		///       函数名称
		///       </summary>
		
		public string FunctionName => _FunctionName;

		/// <summary>
		///       参数的个数
		///       </summary>
		
		public int ParametersCount
		{
			get
			{
				if (_Parameters == null)
				{
					return 0;
				}
				return _Parameters.Length;
			}
		}

		/// <summary>
		///       第一个参数的字符串形式
		///       </summary>
		
		public string ParameterString1 => GetParameterStringValue(0);

		/// <summary>
		///       第二个参数的字符串形式
		///       </summary>
		
		public string ParameterString2 => GetParameterStringValue(1);

		/// <summary>
		///       第三个参数的字符串形式
		///       </summary>
		
		public string ParameterString3 => GetParameterStringValue(2);

		/// <summary>
		///       第四个参数的字符串形式
		///       </summary>
		
		public string ParameterString4 => GetParameterStringValue(3);

		/// <summary>
		///       运算结果
		///       </summary>
		
		public object Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       运算结果
		///       </summary>
		
		public object ResultString
		{
			get
			{
				if (_Result == null || DBNull.Value.Equals(_Result))
				{
					return null;
				}
				return Convert.ToString(_Result);
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       事件已经处理了无需后续处理
		///       </summary>
		
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
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">元素对象</param>
		/// <param name="functionName">函数名</param>
		/// <param name="parameters">参数列表</param>
		
		public WriterExpressionFunctionEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, string functionName, object[] parameters)
			: base(writerControl_0, document, element)
		{
			_FunctionName = functionName;
			_Parameters = parameters;
		}

		/// <summary>
		///       获得指定序号的参数值
		///       </summary>
		/// <param name="index">序号</param>
		/// <returns>参数值</returns>
		
		public object GetParameterValue(int index)
		{
			if (_Parameters != null && index >= 0 && index < _Parameters.Length)
			{
				return _Parameters[index];
			}
			return null;
		}

		/// <summary>
		///       获得指定序号的参数值的字符串数值
		///       </summary>
		/// <param name="index">序号</param>
		/// <returns>参数值</returns>
		
		public string GetParameterStringValue(int index)
		{
			object parameterValue = GetParameterValue(index);
			if (parameterValue == null || DBNull.Value.Equals(parameterValue))
			{
				return null;
			}
			return Convert.ToString(parameterValue);
		}
	}
}
