using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass251
	{
		private int int_0 = 0;

		private IntPtr intptr_0 = IntPtr.Zero;

		private IWin32Window iwin32Window_0 = null;

		public GClass251(IntPtr intptr_1)
		{
			intptr_0 = intptr_1;
		}

		public GClass251(IWin32Window iwin32Window_1)
		{
			iwin32Window_0 = iwin32Window_1;
		}

		public IntPtr method_0()
		{
			if (iwin32Window_0 == null)
			{
				return intptr_0;
			}
			return iwin32Window_0.Handle;
		}

		public int method_1()
		{
			return int_0;
		}

		public uint method_2(Message message_0)
		{
			return method_4(message_0.Msg, (uint)message_0.WParam.ToInt32(), (uint)message_0.LParam.ToInt32());
		}

		public bool method_3(Message message_0)
		{
			return method_5(message_0.Msg, (uint)(int)message_0.WParam, (uint)(int)message_0.LParam);
		}

		public uint method_4(int int_1, uint uint_0, uint uint_1)
		{
			int_0 = 0;
			if (method_34())
			{
				uint result = SendMessage(method_0(), int_1, uint_0, uint_1);
				int_0 = GetLastError();
				return result;
			}
			return 0u;
		}

		public bool method_5(int int_1, uint uint_0, uint uint_1)
		{
			int_0 = 0;
			if (method_34())
			{
				bool result = PostMessage(method_0(), int_1, uint_0, uint_1);
				int_0 = GetLastError();
				return result;
			}
			return false;
		}

		public bool method_6(int int_1, int int_2)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 3, 0u, method_35(int_2, int_1)) == 0;
			}
			return false;
		}

		public bool method_7(int int_1, int int_2)
		{
			return method_5(3, 0u, method_35(int_2, int_1));
		}

		public bool method_8()
		{
			if (method_34())
			{
				return SendMessage(method_0(), 16, 0u, 0u) == 0;
			}
			return false;
		}

		public bool method_9()
		{
			if (method_34())
			{
				return PostMessage(method_0(), 16, 0u, 0u);
			}
			return false;
		}

		public bool method_10(bool bool_0)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 24, bool_0 ? 1u : 0u, 0u) == 0;
			}
			return false;
		}

		public bool method_11(bool bool_0)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 24, bool_0 ? 1u : 0u, 0u);
			}
			return false;
		}

		public bool method_12(char char_0)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 258, char_0, 0u) == 0;
			}
			return false;
		}

		public bool method_13(char char_0)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 258, char_0, 0u);
			}
			return false;
		}

		public bool method_14(int int_1, int int_2)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 512, 0u, method_35(int_2, int_1)) == 0;
			}
			return false;
		}

		public bool method_15(int int_1, int int_2)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 512, 0u, method_35(int_2, int_1));
			}
			return false;
		}

		public bool method_16(int int_1, int int_2)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 513, 0u, method_35(int_2, int_1)) == 0;
			}
			return false;
		}

		public bool method_17(int int_1, int int_2)
		{
			return method_5(513, 0u, method_35(int_2, int_1));
		}

		public bool method_18(int int_1, int int_2)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 514, 0u, method_35(int_2, int_1)) == 0;
			}
			return false;
		}

		public bool method_19(int int_1, int int_2)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 514, 0u, method_35(int_2, int_1));
			}
			return false;
		}

		public bool method_20(int int_1, int int_2)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 516, 0u, method_35(int_2, int_1)) == 0;
			}
			return false;
		}

		public bool method_21(int int_1, int int_2)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 516, 0u, method_35(int_2, int_1));
			}
			return false;
		}

		public bool method_22(int int_1, int int_2)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 517, 0u, method_35(int_2, int_1)) == 0;
			}
			return false;
		}

		public bool method_23(int int_1, int int_2)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 517, 0u, method_35(int_2, int_1));
			}
			return false;
		}

		public bool method_24(int int_1, int int_2, int int_3)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 522, (uint)(int_3 << 16), method_35(int_2, int_1)) == 0;
			}
			return false;
		}

		public bool method_25(int int_1, int int_2, int int_3)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 522, (uint)(int_3 << 16), method_35(int_2, int_1));
			}
			return false;
		}

		public bool method_26(int int_1, int int_2)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 673, 0u, method_35(int_2, int_1)) == 0;
			}
			return false;
		}

		public bool method_27(int int_1, int int_2)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 673, 0u, method_35(int_2, int_1));
			}
			return false;
		}

		public bool method_28()
		{
			if (method_34())
			{
				return SendMessage(method_0(), 675, 0u, 0u) == 0;
			}
			return false;
		}

		public bool method_29()
		{
			if (method_34())
			{
				return PostMessage(method_0(), 675, 0u, 0u);
			}
			return false;
		}

		public bool method_30(Keys keys_0)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 256, (uint)keys_0, 0u) == 0;
			}
			return false;
		}

		public bool method_31(Keys keys_0)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 256, (uint)keys_0, 0u);
			}
			return false;
		}

		public bool method_32(Keys keys_0)
		{
			if (method_34())
			{
				return SendMessage(method_0(), 257, (uint)keys_0, 0u) == 0;
			}
			return false;
		}

		public bool method_33(Keys keys_0)
		{
			if (method_34())
			{
				return PostMessage(method_0(), 257, (uint)keys_0, 0u);
			}
			return false;
		}

		private bool method_34()
		{
			IntPtr intPtr = method_0();
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			return IsWindow(intPtr);
		}

		private uint method_35(int int_1, int int_2)
		{
			long num = int_1;
			num <<= 16;
			num += int_2;
			return (uint)num;
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern int GetLastError();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern uint SendMessage(IntPtr intptr_1, int int_1, uint uint_0, uint uint_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool PostMessage(IntPtr intptr_1, int int_1, uint uint_0, uint uint_1);

		[DllImport("user32.dll")]
		private static extern bool IsWindow(IntPtr intptr_1);
	}
}
