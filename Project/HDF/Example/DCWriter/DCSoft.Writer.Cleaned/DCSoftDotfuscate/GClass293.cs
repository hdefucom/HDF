using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass293
	{
		private struct Struct74
		{
			public int int_0;

			public int int_1;
		}

		public const int int_0 = 533;

		public const int int_1 = 512;

		public const int int_2 = 160;

		public const int int_3 = 513;

		public const int int_4 = 514;

		public const int int_5 = 515;

		public const int int_6 = 516;

		public const int int_7 = 517;

		public const int int_8 = 518;

		public const int int_9 = 519;

		public const int int_10 = 520;

		public const int int_11 = 521;

		public const int int_12 = 523;

		public const int int_13 = 524;

		public const int int_14 = 525;

		public const int int_15 = 673;

		public const int int_16 = 675;

		public const int int_17 = 522;

		public const int int_18 = 161;

		public const int int_19 = 162;

		public const int int_20 = 163;

		public const int int_21 = 164;

		public const int int_22 = 165;

		public const int int_23 = 166;

		public const int int_24 = 167;

		public const int int_25 = 168;

		public const int int_26 = 169;

		public const int int_27 = 171;

		public const int int_28 = 172;

		public static bool smethod_0(int int_29)
		{
			switch (int_29)
			{
			case 512:
				return true;
			case 160:
				return true;
			default:
				return false;
			}
		}

		public static bool smethod_1(int int_29)
		{
			switch (int_29)
			{
			case 514:
				return true;
			case 517:
				return true;
			case 520:
				return true;
			case 524:
				return true;
			case 162:
				return true;
			case 165:
				return true;
			case 168:
				return true;
			case 172:
				return true;
			default:
				return false;
			}
		}

		public static bool smethod_2(int int_29)
		{
			switch (int_29)
			{
			case 513:
				return true;
			case 516:
				return true;
			case 519:
				return true;
			case 523:
				return true;
			case 161:
				return true;
			case 164:
				return true;
			case 167:
				return true;
			case 171:
				return true;
			default:
				return false;
			}
		}

		public static bool smethod_3(int int_29)
		{
			switch (int_29)
			{
			case 522:
				return true;
			case 533:
				return true;
			case 512:
				return true;
			case 160:
				return true;
			case 513:
				return true;
			case 514:
				return true;
			case 515:
				return true;
			case 516:
				return true;
			case 517:
				return true;
			case 518:
				return true;
			case 519:
				return true;
			case 520:
				return true;
			case 521:
				return true;
			case 523:
				return true;
			case 524:
				return true;
			case 525:
				return true;
			case 673:
				return true;
			case 675:
				return true;
			default:
				switch (int_29)
				{
				case 522:
					return true;
				case 161:
					return true;
				case 162:
					return true;
				case 163:
					return true;
				case 164:
					return true;
				case 165:
					return true;
				case 166:
					return true;
				case 167:
					return true;
				case 168:
					return true;
				case 169:
					return true;
				case 171:
					return true;
				case 172:
					return true;
				default:
					return false;
				}
			}
		}

		public static MouseButtons smethod_4(int int_29)
		{
			MouseButtons mouseButtons = MouseButtons.None;
			if (smethod_11(int_29, 1))
			{
				mouseButtons |= MouseButtons.Left;
			}
			if (smethod_11(int_29, 2))
			{
				mouseButtons |= MouseButtons.Right;
			}
			if (smethod_11(int_29, 16))
			{
				mouseButtons |= MouseButtons.Middle;
			}
			if (smethod_11(int_29, 32))
			{
				mouseButtons |= MouseButtons.XButton1;
			}
			if (smethod_11(int_29, 64))
			{
				mouseButtons |= MouseButtons.XButton2;
			}
			return mouseButtons;
		}

		public static int smethod_5(int int_29)
		{
			return int_29 & 0xFF;
		}

		public static int smethod_6(int int_29)
		{
			return int_29 >> 16;
		}

		public static Point smethod_7(int int_29)
		{
			int x = int_29 & 0xFF;
			int y = int_29 >> 16;
			return new Point(x, y);
		}

		public static uint smethod_8(Point point_0)
		{
			return (uint)((point_0.Y << 16) + point_0.X);
		}

		public static int smethod_9()
		{
			return GetDoubleClickTime();
		}

		public static void smethod_10(int int_29)
		{
			SetDoubleClickTime(int_29);
		}

		private static bool smethod_11(int int_29, int int_30)
		{
			return (int_29 & int_30) == int_30;
		}

		public static Point smethod_12(Message message_0)
		{
			if (message_0.Msg == 512 || message_0.Msg == 515 || message_0.Msg == 513 || message_0.Msg == 514 || message_0.Msg == 518 || message_0.Msg == 516 || message_0.Msg == 517)
			{
				Struct74 struct74_ = default(Struct74);
				struct74_.int_0 = smethod_5(message_0.LParam.ToInt32());
				struct74_.int_1 = smethod_6(message_0.LParam.ToInt32());
				ClientToScreen(message_0.HWnd, ref struct74_);
				return new Point(struct74_.int_0, struct74_.int_1);
			}
			return smethod_7(message_0.LParam.ToInt32());
		}

		public static Point smethod_13(IntPtr intptr_0, Point point_0)
		{
			Struct74 struct74_ = default(Struct74);
			struct74_.int_0 = point_0.X;
			struct74_.int_1 = point_0.Y;
			if (ClientToScreen(intptr_0, ref struct74_))
			{
				return new Point(struct74_.int_0, struct74_.int_1);
			}
			return Point.Empty;
		}

		public static Point smethod_14(IntPtr intptr_0, Point point_0)
		{
			Struct74 struct74_ = default(Struct74);
			struct74_.int_0 = point_0.X;
			struct74_.int_1 = point_0.Y;
			if (ScreenToClient(intptr_0, ref struct74_))
			{
				return new Point(struct74_.int_0, struct74_.int_1);
			}
			return Point.Empty;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool ClientToScreen(IntPtr intptr_0, ref Struct74 struct74_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool ScreenToClient(IntPtr intptr_0, ref Struct74 struct74_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool DragDetect(IntPtr intptr_0, Struct74 struct74_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetCapture();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetDoubleClickTime();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SetDoubleClickTime(int int_29);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool SwapMouseButton(bool bool_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern void mouse_event(int int_29, int int_30, int int_31, int int_32, int int_33);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool ReleaseCapture();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SetCapture(IntPtr intptr_0);
	}
}
