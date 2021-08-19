using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       倒计数对象
	                                                                    ///       </summary>
	                                                                    /// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public class CountDown
	{
		private class APIClass
		{
			public static bool PubQueryPerformanceCounter(ref long lpPerformanceCount)
			{
				return QueryPerformanceCounter(ref lpPerformanceCount);
			}

			public static bool PubQueryPerformanceFrequency(ref long lpFrequency)
			{
				return QueryPerformanceFrequency(ref lpFrequency);
			}

			[DllImport("kernel32.dll")]
			private static extern bool QueryPerformanceCounter(ref long lpPerformanceCount);

			[DllImport("kernel32.dll")]
			private static extern bool QueryPerformanceFrequency(ref long lpFrequency);
		}

		private static CountDown myInstance = new CountDown();

		private static long _f = 0L;

		private static int _UseAPI = 0;

		                                                                    /// <summary>
		                                                                    ///       毫秒为单位的总的倒计数值
		                                                                    ///       </summary>
		protected int intCount = 0;

		                                                                    /// <summary>
		                                                                    ///       重置对象,开始计数
		                                                                    ///       </summary>
		protected int intStartTick = 0;

		private long intStartTickExt = GetTickCountExt();

		private StringBuilder myLogString = new StringBuilder();

		                                                                    /// <summary>
		                                                                    ///       对象唯一静态实例
		                                                                    ///       </summary>
		public static CountDown Instance => myInstance;

		                                                                    /// <summary>
		                                                                    ///       毫秒为单位的总的倒计数值
		                                                                    ///       </summary>
		public int Count
		{
			get
			{
				return intCount;
			}
			set
			{
				intCount = value;
			}
		}

		                                                                    /// <summary>
		                                                                    ///       已经消耗的毫秒数
		                                                                    ///       </summary>
		public int Spend => Environment.TickCount - intStartTick;

		                                                                    /// <summary>
		                                                                    ///       高精度的已消耗的时间数,以十万分之一秒为单位
		                                                                    ///       </summary>
		public long SpendExt => GetTickCountExt() - intStartTickExt;

		                                                                    /// <summary>
		                                                                    ///       剩余的毫秒数
		                                                                    ///       </summary>
		public int Remain
		{
			get
			{
				int tickCount = Environment.TickCount;
				return intCount - (tickCount - intStartTick);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       当前输出的日志文本
		                                                                    ///       </summary>
		public string LogText => myLogString.ToString();

		                                                                    /// <summary>
		                                                                    ///       将TickCountExt值转换为TickCount值
		                                                                    ///       </summary>
		                                                                    /// <param name="tickExt">TickCountExt值</param>
		                                                                    /// <returns>转换后的值</returns>
		public static double TickCountExtToTick(long tickExt)
		{
			return (double)tickExt / 100.0;
		}

		                                                                    /// <summary>
		                                                                    ///       获得当前系统时间戳，单位为毫秒。
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static float GetTickCountFloat()
		{
			long tickCountExt = GetTickCountExt();
			return (float)tickCountExt / 10000f;
		}

		                                                                    /// <summary>
		                                                                    ///       获得当前系统时间戳，单位为 0.1微毫秒(十万分之一秒)
		                                                                    ///       </summary>
		                                                                    /// <returns>
		                                                                    /// </returns>
		public static long GetTickCountExt()
		{
			long lpFrequency = _f;
			if (lpFrequency == 0L)
			{
				if (APIClass.PubQueryPerformanceFrequency(ref lpFrequency))
				{
					_f = lpFrequency;
				}
				else
				{
					_f = -1L;
				}
			}
			if (lpFrequency == -1L)
			{
				return Environment.TickCount * 10000;
			}
			long lpPerformanceCount = 0L;
			APIClass.PubQueryPerformanceCounter(ref lpPerformanceCount);
			return (long)((double)lpPerformanceCount * 1000.0 * 10000.0 / (double)lpFrequency);
		}

		                                                                    /// <summary>
		                                                                    ///       无作为的初始化对象
		                                                                    ///       </summary>
		public CountDown()
		{
			Reset();
		}

		                                                                    /// <summary>
		                                                                    ///       初始化对象
		                                                                    ///       </summary>
		                                                                    /// <param name="vCount">毫秒为单位的总时间</param>
		public CountDown(int vCount)
		{
			intCount = vCount;
			Reset();
		}

		                                                                    /// <summary>
		                                                                    ///       重置对象,开始计数
		                                                                    ///       </summary>
		public void Reset()
		{
			intStartTick = Environment.TickCount;
			intStartTickExt = GetTickCountExt();
		}

		                                                                    /// <summary>
		                                                                    ///       重置对象,设置新的计数总数,并开始计数
		                                                                    ///       </summary>
		                                                                    /// <param name="vCount">新的计数总数</param>
		public void Reset(int vCount)
		{
			intCount = vCount;
			intStartTick = Environment.TickCount;
		}

		                                                                    /// <summary>
		                                                                    ///       休息当前线程来消耗掉所有剩余时间
		                                                                    ///       </summary>
		public void SleepToEnd()
		{
			int remain = Remain;
			if (remain > 0)
			{
				Thread.Sleep(remain);
			}
		}

		                                                                    /// <summary>
		                                                                    ///       输出记录信息
		                                                                    ///       </summary>
		                                                                    /// <param name="text">文本</param>
		public void Log(string text)
		{
			myLogString.Append(Environment.NewLine + Spend + " : " + text);
		}

		                                                                    /// <summary>
		                                                                    ///       进行记录
		                                                                    ///       </summary>
		                                                                    /// <param name="text">
		                                                                    /// </param>
		public void LogExt(string text)
		{
			long spendExt = SpendExt;
			long num = spendExt % 10000L;
			spendExt = (spendExt - num) / 10000L;
			myLogString.Append(Environment.NewLine + spendExt + "." + num + " : " + text);
		}

		                                                                    /// <summary>
		                                                                    ///       清空日志信息
		                                                                    ///       </summary>
		public void ClearLog()
		{
			myLogString = new StringBuilder();
		}
	}
}
