using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gocent.Library.Editor.Common
{
    /// <summary>
    /// 应用程序调用堆栈信息帮助类
    /// </summary>
    public sealed class StackTraceHelper
    {
        /// <summary>
        /// 检查调用本方法的方法是否发生了递归
        /// </summary>
        /// <remarks>本函数是利用应用程序调用堆栈来判断是否存在递归</remarks>
        /// <returns>若发生了递归则返回true,否则返回false</returns>
        public static bool CheckRecursion()
        {
            StackTrace myTrace = new StackTrace();
            // 若堆栈小于三层则不可能出现递归
            if (myTrace.FrameCount < 3)
                return false;
            IntPtr mh = myTrace.GetFrame(1).GetMethod().MethodHandle.Value;
            for (int iCount = 2; iCount < myTrace.FrameCount; iCount++)
            {
                MethodBase m = myTrace.GetFrame(iCount).GetMethod();
                if (m.MethodHandle.Value == mh)
                {
                    return true;
                }
            }
            return false;
        }
        public static void OutputStackTrace()
        {
            StackTrace myTrace = new StackTrace();
            Console.WriteLine(myTrace.ToString());
        }

        /// <summary>
        /// 本对象不能实例化
        /// </summary>
        private StackTraceHelper()
        {
        }
    }

}
