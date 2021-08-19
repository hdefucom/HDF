using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows32
{
	public class User32
	{
		public static Point MousePositionFromMSG(int hwnd, uint lParam)
		{
			POINT pt = default(POINT);
			pt.x = (short)(lParam & 0xFFFF);
			pt.y = (short)((uint)((int)lParam & -65536) >> 16);
			ClientToScreen(hwnd, ref pt);
			return new Point(pt.x, pt.y);
		}

		public static Point MousePositionFromMSG(MSG msg)
		{
			POINT pt = default(POINT);
			pt.x = (short)(msg.lParam & 0xFFFF);
			pt.y = (short)((uint)(msg.lParam & -65536) >> 16);
			ClientToScreen(msg.hwnd, ref pt);
			return new Point(pt.x, pt.y);
		}

		public static Point MousePosFromMessage(int intMessage, int Hwnd, uint lParam)
		{
			bool flag = true;
			if (intMessage == 161 || intMessage == 167 || intMessage == 164 || intMessage == 171 || intMessage == 162 || intMessage == 168 || intMessage == 165 || intMessage == 172 || intMessage == 160)
			{
				flag = false;
			}
			POINT pt = default(POINT);
			pt.x = (short)(lParam & 0xFFFF);
			pt.y = (short)((uint)((int)lParam & -65536) >> 16);
			if (flag)
			{
				ClientToScreen(Hwnd, ref pt);
			}
			return new Point(pt.x, pt.y);
		}

		public static bool isMouseDownMessage(int intMessage)
		{
			if (intMessage == 513 || intMessage == 519 || intMessage == 516 || intMessage == 523)
			{
				return true;
			}
			if (intMessage == 161 || intMessage == 167 || intMessage == 164 || intMessage == 171)
			{
				return true;
			}
			return false;
		}

		public static bool isMouseMoveMessage(int intMessage)
		{
			if (intMessage == 512 || intMessage == 160)
			{
				return true;
			}
			return false;
		}

		public static bool isMouseUpMessage(int intMessage)
		{
			if (intMessage == 514 || intMessage == 520 || intMessage == 517 || intMessage == 524)
			{
				return true;
			}
			if (intMessage == 162 || intMessage == 168 || intMessage == 165 || intMessage == 172)
			{
				return true;
			}
			return false;
		}

		public static bool isKeyMessage(int intMessage)
		{
			if (intMessage == 256 || intMessage == 257 || intMessage == 258)
			{
				return true;
			}
			return false;
		}

		public static int GetHeightOrder(uint intValue)
		{
			return (int)((uint)((int)intValue & -65536) >> 16);
		}

		public static int GetLowOrder(uint intValue)
		{
			return (int)(intValue & 0xFFFF);
		}

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowLong(int hWnd, int nIndex);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int SetWindowLong(int hWnd, int nIndex, int newLong);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int bRetValue, uint fWinINI);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool AnimateWindow(int hWnd, uint dwTime, uint dwFlags);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool InvalidateRect(int hWnd, ref RECT rect, bool erase);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int LoadCursor(int hInstance, uint cursor);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int SetCursor(int hCursor);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetFocus();

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int SetFocus(int hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool ReleaseCapture();

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool WaitMessage();

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool TranslateMessage(ref MSG msg);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool DispatchMessage(ref MSG msg);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool PostMessage(int hWnd, int Msg, uint wParam, uint lParam);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern uint SendMessage(int hWnd, int Msg, uint wParam, uint lParam);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool GetMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool PeekMessage(ref MSG msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int BeginPaint(int hWnd, ref PAINTSTRUCT ps);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool EndPaint(int hWnd, ref PAINTSTRUCT ps);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetDC(int hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int ReleaseDC(int hWnd, int hDC);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int ShowWindow(int hWnd, short cmdShow);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool MoveWindow(int hWnd, int x, int y, int width, int height, bool repaint);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int SetWindowPos(int hWnd, int hWndAfter, int X, int Y, int Width, int Height, uint flags);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool UpdateLayeredWindow(int hwnd, int hdcDst, ref POINT pptDst, ref SIZE psize, int hdcSrc, ref POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool GetWindowRect(int hWnd, ref RECT rect);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool ClientToScreen(int hWnd, ref POINT pt);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool ScreenToClient(int hWnd, ref POINT pt);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool SetWindowRgn(int hWnd, int hRgn, bool redraw);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern ushort GetKeyState(int virtKey);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool GetInputState();

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetParent(int hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool DrawFocusRect(int hWnd, ref RECT rect);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool HideCaret(int hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern bool ShowCaret(int hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int InvertRect(int hdc, ref RECT vRect);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int SetActiveWindow(int hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetSystemMetrics(int nIndex);

		public static int InvertRect(int hdc, int x, int y, int width, int height)
		{
			RECT vRect = default(RECT);
			vRect.left = x;
			vRect.top = y;
			vRect.right = x + width;
			vRect.bottom = y + height;
			return InvertRect(hdc, ref vRect);
		}
	}
}
