using DCSoft.WinForms.Native;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass262
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int MsgWaitForMultipleObjectsEx(int int_0, IntPtr intptr_0, int int_1, int int_2, int int_3);

		public static Point smethod_0(IntPtr intptr_0, uint uint_0)
		{
			GStruct15 gstruct15_ = default(GStruct15);
			gstruct15_.int_0 = (short)(uint_0 & 0xFFFF);
			gstruct15_.int_1 = (short)((uint)((int)uint_0 & -65536) >> 16);
			ClientToScreen(intptr_0, ref gstruct15_);
			return new Point(gstruct15_.int_0, gstruct15_.int_1);
		}

		public static Point smethod_1(GStruct7 gstruct7_0)
		{
			GStruct15 gstruct15_ = default(GStruct15);
			gstruct15_.int_0 = (short)(gstruct7_0.int_3 & 0xFFFF);
			gstruct15_.int_1 = (short)((uint)(gstruct7_0.int_3 & -65536) >> 16);
			ClientToScreen(new IntPtr(gstruct7_0.int_0), ref gstruct15_);
			return new Point(gstruct15_.int_0, gstruct15_.int_1);
		}

		public static Point smethod_2(int int_0, IntPtr intptr_0, uint uint_0)
		{
			bool flag = true;
			if (int_0 == 161 || int_0 == 167 || int_0 == 164 || int_0 == 171 || int_0 == 162 || int_0 == 168 || int_0 == 165 || int_0 == 172 || int_0 == 160)
			{
				flag = false;
			}
			GStruct15 gstruct15_ = default(GStruct15);
			gstruct15_.int_0 = (short)(uint_0 & 0xFFFF);
			gstruct15_.int_1 = (short)((uint)((int)uint_0 & -65536) >> 16);
			if (flag)
			{
				ClientToScreen(intptr_0, ref gstruct15_);
			}
			return new Point(gstruct15_.int_0, gstruct15_.int_1);
		}

		public static bool smethod_3(int int_0)
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

		public static bool smethod_4(int int_0)
		{
			if (int_0 == 512 || int_0 == 160)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_5(int int_0)
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

		public static bool smethod_6(int int_0)
		{
			if (int_0 == 256 || int_0 == 257 || int_0 == 258)
			{
				return true;
			}
			return false;
		}

		public static int smethod_7(uint uint_0)
		{
			return (int)((uint)((int)uint_0 & -65536) >> 16);
		}

		public static int smethod_8(uint uint_0)
		{
			return (int)(uint_0 & 0xFFFF);
		}

		public static int smethod_9(int int_0, Rectangle rectangle_0)
		{
			int int_ = GClass259.CreateRectRgn(rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Bottom);
			return SetWindowRgn(int_0, int_, bool_0: true);
		}

		public static int smethod_10(int int_0, int int_1, int int_2, int int_3, int int_4)
		{
			int int_5 = GClass259.CreateRectRgn(int_1, int_2, int_1 + int_3, int_2 + int_4);
			return SetWindowRgn(int_0, int_5, bool_0: true);
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SetWindowRgn(int int_0, int int_1, bool bool_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int ScrollWindow(int int_0, int int_1, int int_2, int int_3, int int_4);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowLong(int int_0, int int_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SetWindowLong(int int_0, int int_1, int int_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool SystemParametersInfo(uint uint_0, uint uint_1, ref int int_0, uint uint_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool AnimateWindow(int int_0, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool InvalidateRect(int int_0, ref GStruct14 gstruct14_0, bool bool_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int LoadCursor(int int_0, uint uint_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SetCursor(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetFocus();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SetFocus(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool WaitMessage();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool TranslateMessage(ref GStruct7 gstruct7_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool DispatchMessage(ref GStruct7 gstruct7_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool PostMessage(IntPtr intptr_0, int int_0, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern uint SendMessage(IntPtr intptr_0, int int_0, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool GetMessage(ref GStruct7 gstruct7_0, IntPtr intptr_0, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool PeekMessage(ref GStruct7 gstruct7_0, IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int BeginPaint(IntPtr intptr_0, ref GStruct13 gstruct13_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool EndPaint(IntPtr intptr_0, ref GStruct13 gstruct13_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetDC(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int ShowWindow(IntPtr intptr_0, short short_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool MoveWindow(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, bool bool_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SetWindowPos(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, int int_4, uint uint_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool UpdateLayeredWindow(IntPtr intptr_0, int int_0, ref GStruct15 gstruct15_0, ref GStruct16 gstruct16_0, int int_1, ref GStruct15 gstruct15_1, int int_2, ref GStruct17 gstruct17_0, int int_3);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool GetWindowRect(IntPtr intptr_0, ref GStruct14 gstruct14_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool ClientToScreen(IntPtr intptr_0, ref GStruct15 gstruct15_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool ScreenToClient(IntPtr intptr_0, ref GStruct15 gstruct15_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool TrackMouseEvent(ref GStruct18 gstruct18_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool SetWindowRgn(IntPtr intptr_0, int int_0, bool bool_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern ushort GetKeyState(int int_0);

		[DllImport("user32")]
		public static extern int RegisterClassA(ref GStruct9 gstruct9_0);

		[DllImport("user32")]
		public static extern int DefWindowProcA(IntPtr intptr_0, int int_0, int int_1, int int_2);

		[DllImport("user32")]
		public static extern void PostQuitMessage(int int_0);

		[DllImport("user32")]
		public static extern int GetMessageA(out GStruct7 gstruct7_0, int int_0, int int_1, int int_2);

		[DllImport("user32")]
		public static extern bool PeekMessageA(out GStruct7 gstruct7_0, int int_0, uint uint_0, uint uint_1, GEnum43 genum43_0);

		[DllImport("user32", CharSet = CharSet.Ansi)]
		public static extern int DispatchMessageA(ref GStruct7 gstruct7_0);

		[DllImport("user32")]
		public static extern bool GetClientRect(IntPtr intptr_0, out GStruct14 gstruct14_0);

		[DllImport("user32")]
		public static extern int CreateWindowExA(GEnum48 genum48_0, string string_0, string string_1, GEnum47 genum47_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7);

		[DllImport("user32")]
		public static extern bool SetWindowPos(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, int int_4, GEnum44 genum44_0);

		[DllImport("user32")]
		public static extern bool SetWindowPos(IntPtr intptr_0, GEnum35 genum35_0, int int_0, int int_1, int int_2, int int_3, GEnum44 genum44_0);

		[DllImport("user32")]
		public static extern bool ShowWindow(IntPtr intptr_0, GEnum45 genum45_0);

		[DllImport("user32")]
		public static extern bool UpdateWindow(IntPtr intptr_0);

		[DllImport("user32")]
		public static extern bool PostMessageA(IntPtr intptr_0, Msgs msgs_0, int int_0, int int_1);

		[DllImport("user32")]
		public static extern int GetSystemMetrics(GEnum62 genum62_0);

		[DllImport("user32")]
		public static extern bool SystemParametersInfoA(GEnum40 genum40_0, uint uint_0, out GStruct14 gstruct14_0, uint uint_1);

		[DllImport("user32")]
		public static extern bool SystemParametersInfoA(GEnum40 genum40_0, uint uint_0, out int int_0, uint uint_1);

		[DllImport("user32")]
		public static extern bool SystemParametersInfoA(GEnum40 genum40_0, uint uint_0, out bool bool_0, uint uint_1);

		[DllImport("user32")]
		public static extern bool SystemParametersInfoA(uint uint_0, uint uint_1, ref GStruct11 gstruct11_0, uint uint_2);

		[DllImport("user32")]
		public static extern int FillRect(IntPtr intptr_0, ref GStruct14 gstruct14_0, int int_0);

		[DllImport("user32")]
		public static extern bool SetWindowTextA(IntPtr intptr_0, string string_0);

		[DllImport("user32")]
		public static extern bool InvalidateRect(IntPtr intptr_0, int int_0, bool bool_0);

		[DllImport("user32")]
		public static extern bool TrackMouseEvent(ref GStruct8 gstruct8_0);

		[DllImport("user32")]
		public static extern int LoadCursorA(int int_0, GEnum32 genum32_0);

		[DllImport("user32")]
		public static extern bool DestroyWindow(IntPtr intptr_0);

		[DllImport("user32")]
		public static extern int GetForegroundWindow();

		[DllImport("user32")]
		public static extern bool CloseWindow(IntPtr intptr_0);

		[DllImport("user32")]
		public static extern bool IsWindowVisible(IntPtr intptr_0);

		[DllImport("user32")]
		public static extern int SetWindowLongA(IntPtr intptr_0, GEnum36 genum36_0, GEnum47 genum47_0);

		[DllImport("user32")]
		public static extern int SetWindowLongA(IntPtr intptr_0, GEnum36 genum36_0, GEnum48 genum48_0);

		[DllImport("user32")]
		public static extern int GetWindowLongA(IntPtr intptr_0, GEnum36 genum36_0);

		[DllImport("user32")]
		public static extern bool RedrawWindow(IntPtr intptr_0, int int_0, int int_1, GEnum37 genum37_0);

		[DllImport("user32")]
		public static extern bool AdjustWindowRectEx(ref GStruct14 gstruct14_0, GEnum47 genum47_0, bool bool_0, GEnum48 genum48_0);

		[DllImport("user32")]
		public static extern short GetKeyState(GEnum70 genum70_0);

		[DllImport("user32")]
		public static extern uint SetTimer(IntPtr intptr_0, uint uint_0, uint uint_1, GDelegate12 gdelegate12_0);

		[DllImport("user32")]
		public static extern uint SetTimer(IntPtr intptr_0, uint uint_0, uint uint_1, int int_0);

		[DllImport("user32")]
		public static extern bool KillTimer(IntPtr intptr_0, uint uint_0);

		[DllImport("user32")]
		public static extern int SetParent(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32")]
		public static extern int SetCapture(IntPtr intptr_0);

		[DllImport("user32")]
		public static extern int GetCapture();

		[DllImport("user32")]
		public static extern int WindowFromPoint(GStruct15 gstruct15_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetDesktopWindow();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool GetInputState();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetParent(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool DrawFocusRect(IntPtr intptr_0, ref GStruct14 gstruct14_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool HideCaret(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool ShowCaret(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int InvertRect(IntPtr intptr_0, ref GStruct14 gstruct14_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetClipboardOwner();

		public static int smethod_11(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3)
		{
			GStruct14 gstruct14_ = default(GStruct14);
			gstruct14_.int_0 = int_0;
			gstruct14_.int_1 = int_1;
			gstruct14_.int_2 = int_0 + int_2;
			gstruct14_.int_3 = int_1 + int_3;
			return InvertRect(intptr_0, ref gstruct14_);
		}

		public static int smethod_12(IntPtr intptr_0, Rectangle rectangle_0)
		{
			GStruct14 gstruct14_ = default(GStruct14);
			gstruct14_.int_0 = rectangle_0.Left;
			gstruct14_.int_1 = rectangle_0.Top;
			gstruct14_.int_2 = rectangle_0.Right;
			gstruct14_.int_3 = rectangle_0.Bottom;
			return InvertRect(intptr_0, ref gstruct14_);
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SetActiveWindow(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetSystemMetrics(int int_0);
	}
}
