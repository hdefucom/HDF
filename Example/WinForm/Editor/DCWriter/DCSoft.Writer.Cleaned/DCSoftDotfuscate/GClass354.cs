#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Services;
using System.Web.UI;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass354
	{
		private static Dictionary<Type, bool> dictionary_0 = new Dictionary<Type, bool>();

		public static bool smethod_0(Type type_0)
		{
			int num = 3;
			if (type_0 == null)
			{
				throw new ArgumentNullException("t");
			}
			if (!dictionary_0.ContainsKey(type_0))
			{
				try
				{
					StackTrace stackTrace = new StackTrace();
					if (stackTrace.FrameCount >= 3)
					{
						StackFrame frame = stackTrace.GetFrame(2);
						dictionary_0[type_0] = (frame.GetMethod().Name == "OnPaint");
					}
					else
					{
						dictionary_0[type_0] = true;
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					dictionary_0[type_0] = true;
				}
			}
			return dictionary_0[type_0];
		}

		public static MethodBase smethod_1()
		{
			StackTrace stackTrace = new StackTrace();
			if (stackTrace.FrameCount < 2)
			{
				return null;
			}
			return stackTrace.GetFrame(1).GetMethod();
		}

		public static bool smethod_2()
		{
			StackTrace stackTrace = new StackTrace();
			int num = 2;
			while (true)
			{
				if (num < stackTrace.FrameCount)
				{
					StackFrame frame = stackTrace.GetFrame(num);
					Type declaringType = frame.GetMethod().DeclaringType;
					if (!declaringType.IsSubclassOf(typeof(System.Web.UI.Control)))
					{
						if (!declaringType.IsSubclassOf(typeof(WebService)))
						{
							if (declaringType.IsSubclassOf(typeof(System.Windows.Forms.Control)))
							{
								break;
							}
							num++;
							continue;
						}
						return true;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool smethod_3()
		{
			try
			{
				StackTrace stackTrace = new StackTrace();
				if (stackTrace.FrameCount < 3)
				{
					return false;
				}
				MethodBase method = stackTrace.GetFrame(1).GetMethod();
				for (int i = 2; i < stackTrace.FrameCount; i++)
				{
					MethodBase method2 = stackTrace.GetFrame(i).GetMethod();
					if (method == method2)
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return false;
		}

		public static void smethod_4()
		{
			StackTrace stackTrace = new StackTrace(fNeedFileInfo: true);
			Console.WriteLine(stackTrace.ToString());
		}

		public static string smethod_5()
		{
			StackTrace stackTrace = new StackTrace(fNeedFileInfo: true);
			return stackTrace.ToString();
		}

		public static void smethod_6()
		{
			int num = 1;
			StackTrace stackTrace = new StackTrace(fNeedFileInfo: true);
			Console.WriteLine("");
			for (int i = 0; i < stackTrace.FrameCount; i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				Console.Write(i + " ");
				Console.Write(frame.GetMethod().ToString());
				if (frame.GetFileName() != null)
				{
					Console.Write(frame.GetFileName());
				}
				if (frame.GetFileLineNumber() >= 0)
				{
					Console.Write(" " + frame.GetFileLineNumber());
				}
				Console.WriteLine("");
			}
		}

		public static string smethod_7()
		{
			int num = 10;
			StackTrace stackTrace = new StackTrace(fNeedFileInfo: true);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < stackTrace.FrameCount; i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				stringBuilder.Append(Environment.NewLine + i + "|");
				MethodBase method = frame.GetMethod();
				if (method != null)
				{
					stringBuilder.Append(method.DeclaringType.FullName + "#" + method.ToString());
				}
				if (frame.GetFileName() != null)
				{
					stringBuilder.Append(frame.GetFileName());
					if (frame.GetFileLineNumber() >= 0)
					{
						stringBuilder.Append(" " + frame.GetFileLineNumber());
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static string smethod_8(int int_0)
		{
			int num = 11;
			StackTrace stackTrace = new StackTrace(fNeedFileInfo: true);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = int_0; i < stackTrace.FrameCount; i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				stringBuilder.Append(Environment.NewLine + Convert.ToString(i - int_0) + "|");
				MethodBase method = frame.GetMethod();
				if (method != null)
				{
					stringBuilder.Append(method.DeclaringType.FullName + "#" + method.ToString());
				}
				if (frame.GetFileName() != null)
				{
					stringBuilder.Append(frame.GetFileName());
					if (frame.GetFileLineNumber() >= 0)
					{
						stringBuilder.Append(" " + frame.GetFileLineNumber());
					}
				}
			}
			return stringBuilder.ToString().Trim();
		}

		private GClass354()
		{
		}
	}
}
