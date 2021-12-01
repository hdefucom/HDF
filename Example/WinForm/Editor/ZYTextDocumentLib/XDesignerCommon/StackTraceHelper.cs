using System;
using System.Diagnostics;
using System.Reflection;

namespace XDesignerCommon
{
	public sealed class StackTraceHelper
	{
		public static bool CheckRecursion()
		{
			StackTrace stackTrace = new StackTrace();
			if (stackTrace.FrameCount < 3)
			{
				return false;
			}
			IntPtr value = stackTrace.GetFrame(1).GetMethod().MethodHandle.Value;
			for (int i = 2; i < stackTrace.FrameCount; i++)
			{
				MethodBase method = stackTrace.GetFrame(i).GetMethod();
				if (method.MethodHandle.Value == value)
				{
					return true;
				}
			}
			return false;
		}

		public static void OutputStackTrace()
		{
			StackTrace stackTrace = new StackTrace();
			Console.WriteLine(stackTrace.ToString());
		}

		private StackTraceHelper()
		{
		}
	}
}
