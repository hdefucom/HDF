using System;
using System.Runtime.InteropServices;

namespace Evaluant.Calculator
{
	[ComVisible(false)]
	public class FunctionNotSupportedException : Exception
	{
		private string _FunctionName = null;

		public string FunctionName => _FunctionName;

		public override string Message => "不支持的表达式函数 " + _FunctionName;

		public FunctionNotSupportedException(string functionName)
		{
			_FunctionName = functionName;
		}

		public override string ToString()
		{
			return "不支持的表达式函数 " + _FunctionName + Environment.NewLine + base.ToString();
		}
	}
}
