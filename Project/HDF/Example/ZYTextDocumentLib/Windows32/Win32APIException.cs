using System;

namespace Windows32
{
	public class Win32APIException : Exception
	{
		private int intLastDllError = 0;

		private int intReturnValue = 0;

		private string strAPIName = "";

		private string strErrorMsg = "";

		public string ErrorMsg
		{
			get
			{
				return strErrorMsg;
			}
			set
			{
				strErrorMsg = value;
			}
		}

		public int ReturnValue => intReturnValue;

		public int LastDllError => intLastDllError;

		public string APIName => strAPIName;

		public override string ToString()
		{
			return "Win32APIException:调用Win32API函数" + strAPIName + " 错误，返回:" + intReturnValue + " 系统错误号" + intLastDllError + Kernel32.FormatErrorMessage(intLastDllError) + " 错误信息: " + strErrorMsg + "\r\n" + StackTrace;
		}

		public Win32APIException(string vAPIName, int vReturnValue, int vDllError, string msg)
		{
			strAPIName = vAPIName;
			intLastDllError = vDllError;
			intReturnValue = vReturnValue;
			strErrorMsg = msg;
		}

		public Win32APIException(string vAPIName, int vReturnValue, int vDllError)
		{
			strAPIName = vAPIName;
			intLastDllError = vDllError;
			intReturnValue = vReturnValue;
		}

		public Win32APIException(string vAPIName, int vReturnValue)
		{
			strAPIName = vAPIName;
			intLastDllError = (int)Kernel32.GetLastError();
			intReturnValue = vReturnValue;
		}

		public Win32APIException()
		{
		}
	}
}
