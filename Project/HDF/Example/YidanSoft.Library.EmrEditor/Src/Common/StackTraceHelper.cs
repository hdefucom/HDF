using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Common
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
            System.Diagnostics.StackTrace myTrace = new System.Diagnostics.StackTrace();
            // 若堆栈小于三层则不可能出现递归
            if (myTrace.FrameCount < 3)
                return false;
            System.IntPtr mh = myTrace.GetFrame(1).GetMethod().MethodHandle.Value;
            for (int iCount = 2; iCount < myTrace.FrameCount; iCount++)
            {
                System.Reflection.MethodBase m = myTrace.GetFrame(iCount).GetMethod();
                if (m.MethodHandle.Value == mh)
                {
                    return true;
                }
            }
            return false;
        }
        public static void OutputStackTrace()
        {
            System.Diagnostics.StackTrace myTrace = new System.Diagnostics.StackTrace();
            System.Console.WriteLine(myTrace.ToString());
        }

        //		/// <summary>
        //		/// 检查调用本方法的方法是否发生了递归
        //		/// </summary>
        //		/// <remarks>本函数是利用应用程序调用堆栈来判断是否存在递归</remarks>
        //		/// <param name="MaxCount">最多可以递归的次数</param>
        //		/// <returns>若发生了递归则返回true,否则返回false</returns>
        //		public static bool CheckRecursion( int MaxCount )
        //		{
        //			System.Diagnostics.StackTrace myTrace = new System.Diagnostics.StackTrace();
        //			// 若堆栈小于三层则不可能出现递归
        //			if( myTrace.FrameCount < 3 )
        //				return false;
        //			System.IntPtr mh = myTrace.GetFrame( myTrace.FrameCount - 2 ).GetMethod().MethodHandle.Value ;
        //			for( int iCount = myTrace.FrameCount - 3 ; iCount >= 0 ; iCount -- )
        //			{
        //				System.Reflection.MethodBase m = myTrace.GetFrame( iCount ).GetMethod();
        //				if( m.MethodHandle.Value == mh )
        //				{
        //					MaxCount -- ;
        //					if( MaxCount <= 0 )
        //						return true;
        //				}
        //			}
        //			return false;
        //		}

        /// <summary>
        /// 本对象不能实例化
        /// </summary>
        private StackTraceHelper()
        {
        }
    }//public sealed class CheckRecursion
}
