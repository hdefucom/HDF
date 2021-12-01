using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass244 : IWin32Window
	{
		private class Class175 : IWin32Window
		{
			public IntPtr intptr_0 = IntPtr.Zero;

			public IntPtr Handle => intptr_0;

			public Class175()
			{
			}

			public Class175(IntPtr intptr_1)
			{
				intptr_0 = intptr_1;
			}
		}

		private delegate bool Delegate4(IntPtr intptr_0, IntPtr intptr_1);

		[ComVisible(false)]
		private struct Struct64
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;

			public int int_4;

			public int int_5;

			public int int_6;

			public int int_7;

			public int int_8;

			public int int_9;

			public int int_10;
		}

		private delegate bool Delegate5(IntPtr intptr_0, IntPtr intptr_1);

		private struct Struct65
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;
		}

		private struct Struct66
		{
			public int int_0;

			public int int_1;
		}

		private const int int_0 = -14;

		private const int int_1 = 0;

		private const int int_2 = 1;

		private const int int_3 = 2;

		private const int int_4 = 127;

		private const int int_5 = 128;

		private const int int_6 = 0;

		private const int int_7 = 1;

		private const int int_8 = 1;

		private const int int_9 = 2;

		private const int int_10 = 3;

		private const int int_11 = 3;

		private const int int_12 = 4;

		private const int int_13 = 5;

		private const int int_14 = 6;

		private const int int_15 = 7;

		private const int int_16 = 8;

		private const int int_17 = 9;

		private const int int_18 = 10;

		private const int int_19 = 11;

		private const int int_20 = 11;

		private const int int_21 = -4;

		private const int int_22 = -6;

		private const int int_23 = -8;

		private const int int_24 = -16;

		private const int int_25 = -20;

		private const int int_26 = -21;

		private const int int_27 = -12;

		private const int int_28 = -8;

		private const int int_29 = -10;

		private const int int_30 = -12;

		private const int int_31 = -14;

		private const int int_32 = -16;

		private const int int_33 = -18;

		private const int int_34 = -20;

		private const int int_35 = -24;

		private const int int_36 = -26;

		private const int int_37 = -32;

		private bool bool_0 = false;

		private Icon icon_0 = null;

		[NonSerialized]
		private IWin32Window iwin32Window_0 = null;

		private static ArrayList arrayList_0 = null;

		private static List<IntPtr> list_0 = null;

		private static bool bool_1 = false;

		public IntPtr Handle
		{
			get
			{
				if (method_37())
				{
					return iwin32Window_0.Handle;
				}
				return IntPtr.Zero;
			}
		}

		public static GClass244 smethod_0()
		{
			IntPtr desktopWindow = GetDesktopWindow();
			return new GClass244(desktopWindow);
		}

		public static GClass244 smethod_1()
		{
			IntPtr activeWindow = GetActiveWindow();
			if (activeWindow == IntPtr.Zero)
			{
				return null;
			}
			return new GClass244(activeWindow);
		}

		public static GClass244 smethod_2()
		{
			IntPtr focus = GetFocus();
			if (focus != IntPtr.Zero)
			{
				return new GClass244(focus);
			}
			return null;
		}

		public static GClass244 smethod_3(IntPtr intptr_0)
		{
			if (smethod_4(intptr_0))
			{
				return new GClass244(intptr_0);
			}
			return null;
		}

		public GClass244(IntPtr intptr_0)
		{
			iwin32Window_0 = new Class175(intptr_0);
		}

		public GClass244(IWin32Window iwin32Window_1)
		{
			iwin32Window_0 = iwin32Window_1;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public string method_2()
		{
			if (method_37())
			{
				int num = 1000;
				byte[] array = new byte[1000];
				num = GetClassName(iwin32Window_0.Handle, array, array.Length);
				if (num != 0)
				{
					return Encoding.Unicode.GetString(array, 0, num * 2);
				}
				method_40();
			}
			return null;
		}

		public string method_3()
		{
			if (method_37())
			{
				int windowTextLength = GetWindowTextLength(iwin32Window_0.Handle);
				if (windowTextLength > 0)
				{
					StringBuilder stringBuilder = new StringBuilder(windowTextLength + 1);
					if (GetWindowText(iwin32Window_0.Handle, stringBuilder, stringBuilder.Capacity) == 0)
					{
						method_40();
					}
					return stringBuilder.ToString();
				}
				if (windowTextLength == 0)
				{
					method_40();
				}
			}
			return "";
		}

		public void method_4(string string_0)
		{
			if (method_37())
			{
				if (string_0 == null)
				{
					string_0 = "";
				}
				if (!SetWindowText(iwin32Window_0.Handle, string_0))
				{
					method_40();
				}
			}
		}

		public Rectangle method_5()
		{
			if (method_37())
			{
				Struct65 struct65_ = default(Struct65);
				if (!GetClientRect(iwin32Window_0.Handle, ref struct65_))
				{
					method_40();
				}
				return new Rectangle(struct65_.int_0, struct65_.int_1, struct65_.int_2 - struct65_.int_0, struct65_.int_3 - struct65_.int_1);
			}
			return Rectangle.Empty;
		}

		public Point method_6(int int_38, int int_39)
		{
			if (method_37())
			{
				Struct66 struct66_ = default(Struct66);
				struct66_.int_0 = int_38;
				struct66_.int_1 = int_39;
				if (!ClientToScreen(iwin32Window_0.Handle, ref struct66_))
				{
					method_40();
				}
				return new Point(struct66_.int_0, struct66_.int_1);
			}
			return Point.Empty;
		}

		public Point method_7(int int_38, int int_39)
		{
			if (method_37())
			{
				Struct66 struct66_ = default(Struct66);
				struct66_.int_0 = int_38;
				struct66_.int_1 = int_39;
				if (!ScreenToClient(iwin32Window_0.Handle, ref struct66_))
				{
					method_40();
				}
				return new Point(struct66_.int_0, struct66_.int_1);
			}
			return Point.Empty;
		}

		public Rectangle method_8()
		{
			if (method_37())
			{
				Struct65 struct65_ = default(Struct65);
				if (!GetWindowRect(iwin32Window_0.Handle, ref struct65_))
				{
					method_40();
				}
				return new Rectangle(struct65_.int_0, struct65_.int_1, struct65_.int_2 - struct65_.int_0, struct65_.int_3 - struct65_.int_1);
			}
			return Rectangle.Empty;
		}

		public void method_9(Rectangle rectangle_0)
		{
			if (method_37() && !SetWindowPos(iwin32Window_0.Handle, IntPtr.Zero, rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height, 20))
			{
				method_40();
			}
		}

		public bool method_10()
		{
			if (method_37())
			{
				return IsWindowEnabled(iwin32Window_0.Handle);
			}
			return false;
		}

		public void method_11(bool bool_2)
		{
			if (method_37())
			{
				EnableWindow(iwin32Window_0.Handle, bool_2);
			}
		}

		public bool method_12()
		{
			if (method_37())
			{
				return IsWindowVisible(iwin32Window_0.Handle);
			}
			return false;
		}

		public void method_13(bool bool_2)
		{
			if (method_37())
			{
				SetWindowPos(iwin32Window_0.Handle, IntPtr.Zero, 0, 0, 0, 0, 0x17 | (bool_2 ? 64 : 128));
			}
		}

		public bool method_14()
		{
			if (method_37())
			{
				bool result;
				if (result = DestroyWindow(Handle))
				{
					iwin32Window_0 = new Class175(IntPtr.Zero);
				}
				return result;
			}
			return false;
		}

		public int method_15()
		{
			if (method_37())
			{
				int num = (int)GetWindowLong(iwin32Window_0.Handle, -16);
				if (num == 0)
				{
					method_40();
				}
				return num;
			}
			return 0;
		}

		public void method_16(int int_38)
		{
			if (method_37() && SetWindowLong(iwin32Window_0.Handle, -16, new IntPtr(int_38)) == IntPtr.Zero)
			{
				method_40();
			}
		}

		public int method_17()
		{
			if (method_37())
			{
				int num = (int)GetWindowLong(iwin32Window_0.Handle, -20);
				if (num == 0)
				{
					method_40();
				}
				return num;
			}
			return 0;
		}

		public void method_18(int int_38)
		{
			if (method_37() && SetWindowLong(Handle, -20, new IntPtr(int_38)) == IntPtr.Zero)
			{
				method_40();
			}
		}

		public IntPtr method_19()
		{
			if (method_37())
			{
				IntPtr parent = GetParent(Handle);
				if (parent == IntPtr.Zero)
				{
					method_40();
				}
				return parent;
			}
			return IntPtr.Zero;
		}

		public void method_20(IntPtr intptr_0)
		{
			if (method_37() && IsWindow(intptr_0) && GetParent(Handle) != intptr_0)
			{
				SetParent(Handle, intptr_0);
			}
		}

		public FormWindowState method_21()
		{
			if (method_37())
			{
				Struct64 struct64_ = default(Struct64);
				if (GetWindowPlacement(Handle, ref struct64_) == 0)
				{
					method_40();
				}
				int num = struct64_.int_2;
				if (num == 1 || num == 4 || num == 5 || num == 9)
				{
					return FormWindowState.Normal;
				}
				if (num == 2 || num == 6 || num == 7)
				{
					return FormWindowState.Minimized;
				}
				if (num == 3)
				{
					return FormWindowState.Maximized;
				}
				if (IsIconic(Handle))
				{
					return FormWindowState.Minimized;
				}
			}
			return FormWindowState.Minimized;
		}

		public void method_22(FormWindowState formWindowState_0)
		{
			if (method_37())
			{
				switch (formWindowState_0)
				{
				case FormWindowState.Normal:
					ShowWindow(Handle, 1);
					break;
				case FormWindowState.Minimized:
					ShowWindow(Handle, 6);
					break;
				case FormWindowState.Maximized:
					ShowWindow(Handle, 3);
					break;
				}
			}
		}

		public GClass244 method_23()
		{
			if (method_37())
			{
				IntPtr parent = GetParent(Handle);
				if (parent == IntPtr.Zero)
				{
					method_40();
					return null;
				}
				return new GClass244(parent);
			}
			return null;
		}

		public Icon method_24()
		{
			int num = 18;
			if (method_37())
			{
				if (icon_0 == null)
				{
					IntPtr intPtr = IntPtr.Zero;
					if (Environment.OSVersion.Version >= new Version("6.1"))
					{
						intPtr = SendMessage(Handle, 127, 2, 0);
					}
					if (intPtr == IntPtr.Zero)
					{
						intPtr = SendMessage(Handle, 127, 0, 0);
					}
					if (intPtr == IntPtr.Zero)
					{
						intPtr = SendMessage(Handle, 127, 1, 0);
					}
					if (intPtr == IntPtr.Zero)
					{
						intPtr = GetClassLong(Handle, -14);
					}
					if (intPtr != IntPtr.Zero)
					{
						Icon icon = Icon.FromHandle(intPtr);
						if (icon.Width == 0 || icon.Height == 0)
						{
							icon.Dispose();
							return null;
						}
						icon_0 = icon;
					}
				}
				return icon_0;
			}
			return null;
		}

		public void method_25(Icon icon_1)
		{
			if (method_37())
			{
				SendMessage(Handle, 128, 0, icon_1?.Handle.ToInt32() ?? 0);
				icon_0 = icon_1;
			}
		}

		public void method_26()
		{
			if (method_37())
			{
				IntPtr value = SetFocus(Handle);
				if (value == IntPtr.Zero)
				{
					Marshal.GetLastWin32Error();
				}
			}
		}

		public bool method_27()
		{
			IntPtr focus = GetFocus();
			return focus == Handle;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SetFocus(IntPtr intptr_0);

		public bool method_28(IntPtr intptr_0)
		{
			if (intptr_0 == IntPtr.Zero || !IsWindow(intptr_0))
			{
				return false;
			}
			if (method_37())
			{
				IntPtr intPtr = Handle;
				while (intPtr != IntPtr.Zero)
				{
					intPtr = GetParent(intPtr);
					if (!(intPtr == intptr_0))
					{
						if (intPtr == IntPtr.Zero)
						{
							break;
						}
						continue;
					}
					return true;
				}
			}
			return false;
		}

		public bool method_29(IntPtr intptr_0)
		{
			if (intptr_0 == IntPtr.Zero || !IsWindow(intptr_0))
			{
				return false;
			}
			if (method_37())
			{
				IntPtr value = SetParent(Handle, intptr_0);
				if (value == IntPtr.Zero)
				{
					method_40();
					return false;
				}
				return true;
			}
			return false;
		}

		public Process method_30()
		{
			if (method_37())
			{
				int int_ = 0;
				GetWindowThreadProcessId(Handle, ref int_);
				if (int_ != 0)
				{
					return Process.GetProcessById(int_);
				}
			}
			return null;
		}

		public GClass244 method_31()
		{
			GClass244[] array = smethod_6();
			for (GClass244 gClass = this; gClass != null; gClass = gClass.method_23())
			{
				GClass244[] array2 = array;
				foreach (GClass244 gClass2 in array2)
				{
					if (gClass2.Handle == gClass.Handle)
					{
						return gClass2;
					}
				}
			}
			return null;
		}

		public void method_32()
		{
			if (method_37())
			{
				SendMessage(Handle, 16, 0, 0);
			}
		}

		public void method_33()
		{
			if (method_37())
			{
				PostMessage(Handle, 16, 0, 0);
			}
		}

		public void method_34()
		{
			if (method_37() && !BringWindowToTop(Handle))
			{
				method_40();
			}
		}

		public void method_35()
		{
			if (method_37())
			{
				SetForegroundWindow(Handle);
			}
		}

		public void method_36()
		{
			if (method_37())
			{
				FlashWindow(Handle, bool_2: true);
			}
		}

		public bool method_37()
		{
			if (iwin32Window_0.Handle == IntPtr.Zero)
			{
				return false;
			}
			if (!IsWindow(iwin32Window_0.Handle))
			{
				return false;
			}
			return true;
		}

		public GClass244[] method_38()
		{
			IntPtr[] array = smethod_9(Handle);
			if (array != null && array.Length > 0)
			{
				GClass244[] array2 = new GClass244[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = new GClass244(array[i]);
				}
				return array2;
			}
			return null;
		}

		public bool method_39()
		{
			return smethod_11(Handle);
		}

		public static bool smethod_4(IntPtr intptr_0)
		{
			if (intptr_0 == IntPtr.Zero)
			{
				return false;
			}
			if (!IsWindow(intptr_0))
			{
				return false;
			}
			return true;
		}

		public static bool smethod_5()
		{
			int num = 14;
			GClass244[] array = smethod_8(IntPtr.Zero);
			if (array != null)
			{
				GClass244[] array2 = array;
				foreach (GClass244 gClass in array2)
				{
					if (string.Compare(gClass.method_2(), "Shell_TrayWnd", ignoreCase: true) == 0)
					{
						gClass.method_35();
						return true;
					}
				}
			}
			return false;
		}

		public static GClass244[] smethod_6()
		{
			IntPtr threadDesktop = GetThreadDesktop(GetCurrentThreadId());
			if (threadDesktop != IntPtr.Zero)
			{
				lock (typeof(GClass244))
				{
					arrayList_0 = new ArrayList();
					EnumDesktopWindows(threadDesktop, smethod_7, threadDesktop);
					CloseDesktop(threadDesktop);
					GClass244[] result = (GClass244[])arrayList_0.ToArray(typeof(GClass244));
					arrayList_0 = null;
					return result;
				}
			}
			throw new Win32Exception();
		}

		private static bool smethod_7(IntPtr intptr_0, IntPtr intptr_1)
		{
			IntPtr windowThreadProcessId = GetWindowThreadProcessId(intptr_0, 0);
			IntPtr threadDesktop = GetThreadDesktop(windowThreadProcessId);
			CloseDesktop(threadDesktop);
			if (threadDesktop == intptr_1)
			{
				GClass244 gClass = new GClass244(intptr_0);
				if (!gClass.method_12())
				{
					return true;
				}
				string text = gClass.method_3();
				if (text == null || text.Length == 0)
				{
					return true;
				}
				arrayList_0.Add(gClass);
			}
			return true;
		}

		private void method_40()
		{
			int lastWin32Error = Marshal.GetLastWin32Error();
			if (lastWin32Error != 0)
			{
				Win32Exception ex = new Win32Exception(lastWin32Error);
				if (method_0())
				{
					throw ex;
				}
			}
		}

		public static GClass244[] smethod_8(IntPtr intptr_0)
		{
			IntPtr[] array = smethod_9(intptr_0);
			if (array != null && array.Length > 0)
			{
				GClass244[] array2 = new GClass244[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = new GClass244(array[i]);
				}
				return array2;
			}
			return null;
		}

		public static IntPtr[] smethod_9(IntPtr intptr_0)
		{
			lock (typeof(GClass244))
			{
				list_0 = new List<IntPtr>();
				EnumChildWindows(intptr_0, smethod_10, IntPtr.Zero);
				IntPtr[] result = list_0.ToArray();
				list_0 = null;
				return result;
			}
		}

		private static bool smethod_10(IntPtr intptr_0, IntPtr intptr_1)
		{
			if (list_0 != null)
			{
				list_0.Add(intptr_0);
				return true;
			}
			return false;
		}

		public static bool smethod_11(IntPtr intptr_0)
		{
			lock (typeof(GClass244))
			{
				bool_1 = false;
				EnumChildWindows(intptr_0, smethod_12, IntPtr.Zero);
				return bool_1;
			}
		}

		private static bool smethod_12(IntPtr intptr_0, IntPtr intptr_1)
		{
			bool_1 = true;
			return false;
		}

		[DllImport("user32.dll")]
		private static extern bool DestroyWindow(IntPtr hWnd);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool EnumChildWindows(IntPtr intptr_0, Delegate4 delegate4_0, IntPtr intptr_1);

		[DllImport("user32.dll")]
		private static extern IntPtr GetFocus();

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern int GetWindowPlacement(IntPtr intptr_0, ref Struct64 struct64_0);

		[DllImport("user32.dll")]
		private static extern int GetWindowThreadProcessId(IntPtr intptr_0, ref int int_38);

		[DllImport("user32.dll")]
		private static extern bool IsIconic(IntPtr intptr_0);

		[DllImport("user32.dll")]
		private static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowThreadProcessId(IntPtr intptr_0, int int_38);

		[DllImport("user32.dll")]
		private static extern IntPtr GetThreadDesktop(IntPtr intptr_0);

		[DllImport("user32.dll")]
		private static extern bool CloseDesktop(IntPtr intptr_0);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetCurrentThreadId();

		[DllImport("user32.dll")]
		private static extern bool EnumDesktopWindows(IntPtr intptr_0, Delegate5 delegate5_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool BringWindowToTop(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern IntPtr GetParent(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern IntPtr SetParent(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool FlashWindow(IntPtr intptr_0, bool bool_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool SetForegroundWindow(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr intptr_0, int int_38, int int_39, int int_40);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr PostMessage(IntPtr intptr_0, int int_38, int int_39, int int_40);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool ShowWindow(IntPtr intptr_0, int int_38);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool EnableWindow(IntPtr intptr_0, bool bool_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool IsWindowEnabled(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool IsWindowVisible(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool SetWindowPos(IntPtr intptr_0, IntPtr intptr_1, int int_38, int int_39, int int_40, int int_41, int int_42);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SetWindowLong(IntPtr intptr_0, int int_38, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern IntPtr GetActiveWindow();

		[DllImport("user32.dll")]
		private static extern IntPtr GetClassLong(IntPtr intptr_0, int int_38);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr GetWindowLong(IntPtr intptr_0, int int_38);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool ClientToScreen(IntPtr intptr_0, ref Struct66 struct66_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool ScreenToClient(IntPtr intptr_0, ref Struct66 struct66_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool GetWindowRect(IntPtr intptr_0, ref Struct65 struct65_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern bool GetClientRect(IntPtr intptr_0, ref Struct65 struct65_0);

		[DllImport("user32.dll")]
		private static extern bool IsWindow(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowTextLength(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowText(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_38);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetClassName(IntPtr intptr_0, byte[] byte_0, int int_38);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool SetWindowText(IntPtr intptr_0, string string_0);
	}
}
