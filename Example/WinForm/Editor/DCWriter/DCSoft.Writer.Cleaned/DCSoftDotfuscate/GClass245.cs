using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass245
	{
		private IntPtr intptr_0 = IntPtr.Zero;

		private int int_0 = 0;

		private IntPtr intptr_1 = IntPtr.Zero;

		private IntPtr intptr_2 = IntPtr.Zero;

		private IntPtr intptr_3 = IntPtr.Zero;

		public static int smethod_0(IntPtr intptr_4)
		{
			int num = 0;
			while (true)
			{
				GStruct7 gstruct7_ = default(GStruct7);
				if (!PeekMessage(ref gstruct7_, intptr_4, 0u, 0u, 16777215u) || gstruct7_.int_1 == 0)
				{
					break;
				}
				num++;
			}
			return num;
		}

		public static int smethod_1()
		{
			return smethod_0(IntPtr.Zero);
		}

		public static bool smethod_2()
		{
			return WaitMessage();
		}

		public static GClass245 smethod_3()
		{
			GStruct7 gstruct7_ = default(GStruct7);
			if (GetMessage(ref gstruct7_, IntPtr.Zero, 0u, 0u))
			{
				return new GClass245(gstruct7_);
			}
			return null;
		}

		public static GClass245 smethod_4()
		{
			GStruct7 gstruct7_ = default(GStruct7);
			if (PeekMessage(ref gstruct7_, IntPtr.Zero, 0u, 0u, 0u))
			{
				return new GClass245(gstruct7_);
			}
			return null;
		}

		private GClass245(GStruct7 gstruct7_0)
		{
			intptr_0 = new IntPtr(gstruct7_0.int_0);
			intptr_1 = new IntPtr(gstruct7_0.int_3);
			int_0 = gstruct7_0.int_1;
			intptr_2 = new IntPtr(gstruct7_0.int_2);
		}

		public GClass245(Message message_0)
		{
			intptr_0 = message_0.HWnd;
			intptr_1 = message_0.LParam;
			int_0 = message_0.Msg;
			intptr_3 = message_0.Result;
			intptr_2 = message_0.WParam;
		}

		public IntPtr method_0()
		{
			return intptr_0;
		}

		public void method_1(IntPtr intptr_4)
		{
			intptr_0 = intptr_4;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_1)
		{
			int_0 = int_1;
		}

		public IntPtr method_4()
		{
			return intptr_1;
		}

		public void method_5(IntPtr intptr_4)
		{
			intptr_1 = intptr_4;
		}

		public IntPtr method_6()
		{
			return intptr_2;
		}

		public void method_7(IntPtr intptr_4)
		{
			intptr_2 = intptr_4;
		}

		public IntPtr method_8()
		{
			return intptr_3;
		}

		public void method_9(IntPtr intptr_4)
		{
			intptr_3 = intptr_4;
		}

		public uint method_10(IntPtr intptr_4)
		{
			return SendMessage(intptr_4, method_2(), (uint)(int)method_6(), (uint)(int)method_4());
		}

		public uint method_11()
		{
			return SendMessage(method_0(), method_2(), (uint)(int)method_6(), (uint)(int)method_4());
		}

		public bool method_12(IntPtr intptr_4)
		{
			return PostMessage(intptr_4, method_2(), (uint)(int)method_6(), (uint)(int)method_4());
		}

		public bool method_13()
		{
			return PostMessage(method_0(), method_2(), (uint)(int)method_6(), (uint)(int)method_4());
		}

		public bool method_14()
		{
			if (int_0 == 513 || int_0 == 519 || int_0 == 516 || int_0 == 523)
			{
				return true;
			}
			if (int_0 == 161 || int_0 == 167 || int_0 == 164 || int_0 == 171)
			{
				return true;
			}
			return false;
		}

		public bool method_15()
		{
			if (int_0 == 512 || int_0 == 160)
			{
				return true;
			}
			return false;
		}

		public bool method_16()
		{
			if (int_0 == 514 || int_0 == 520 || int_0 == 517 || int_0 == 524)
			{
				return true;
			}
			if (int_0 == 162 || int_0 == 168 || int_0 == 165 || int_0 == 172)
			{
				return true;
			}
			return false;
		}

		public bool method_17()
		{
			if (int_0 == 256 || int_0 == 257 || int_0 == 258)
			{
				return true;
			}
			return false;
		}

		public Point method_18()
		{
			GStruct15 gstruct15_ = default(GStruct15);
			gstruct15_.int_0 = (short)(method_4().ToInt32() & 0xFFFF);
			gstruct15_.int_1 = (short)((method_4().ToInt32() & 0xFFFF0000) >> 16);
			if (method_0() != IntPtr.Zero)
			{
				ClientToScreen(method_0(), ref gstruct15_);
			}
			return new Point(gstruct15_.int_0, gstruct15_.int_1);
		}

		public Point method_19()
		{
			GStruct15 gStruct = default(GStruct15);
			gStruct.int_0 = (short)(method_4().ToInt32() & 0xFFFF);
			gStruct.int_1 = (short)((method_4().ToInt32() & 0xFFFF0000) >> 16);
			return new Point(gStruct.int_0, gStruct.int_1);
		}

		[DllImport("user32")]
		public static extern void PostQuitMessage(int int_1);

		[DllImport("user32")]
		public static extern int GetMessageA(out GStruct7 gstruct7_0, int int_1, int int_2, int int_3);

		[DllImport("user32")]
		public static extern bool PeekMessageA(out GStruct7 gstruct7_0, int int_1, uint uint_0, uint uint_1, GEnum43 genum43_0);

		[DllImport("user32", CharSet = CharSet.Ansi)]
		public static extern int DispatchMessageA(ref GStruct7 gstruct7_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool WaitMessage();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool TranslateMessage(ref GStruct7 gstruct7_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool DispatchMessage(ref GStruct7 gstruct7_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool PostMessage(IntPtr intptr_4, int int_1, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern uint SendMessage(IntPtr intptr_4, int int_1, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool GetMessage(ref GStruct7 gstruct7_0, IntPtr intptr_4, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool PeekMessage(ref GStruct7 gstruct7_0, IntPtr intptr_4, uint uint_0, uint uint_1, uint uint_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool ClientToScreen(IntPtr intptr_4, ref GStruct15 gstruct15_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool ScreenToClient(IntPtr intptr_4, ref GStruct15 gstruct15_0);
	}
}
