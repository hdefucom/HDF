using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass246
	{
		private struct Struct67
		{
			public int int_0;

			public int int_1;

			public IntPtr intptr_0;
		}

		public const int int_0 = 74;

		private IntPtr intptr_0 = IntPtr.Zero;

		private int int_1 = 0;

		private byte[] byte_0 = null;

		public IntPtr method_0()
		{
			return intptr_0;
		}

		public void method_1(IntPtr intptr_1)
		{
			intptr_0 = intptr_1;
		}

		public int method_2()
		{
			return int_1;
		}

		public void method_3(int int_2)
		{
			int_1 = int_2;
		}

		public byte[] method_4()
		{
			return byte_0;
		}

		public void method_5(byte[] byte_1)
		{
			byte_0 = byte_1;
		}

		public bool method_6()
		{
			return smethod_1(intptr_0, int_1, byte_0);
		}

		public static bool smethod_0(IntPtr intptr_1, int int_2, string string_0)
		{
			byte[] byte_ = null;
			if (string_0 != null && string_0.Length > 0)
			{
				byte_ = Encoding.UTF8.GetBytes(string_0);
			}
			return smethod_1(intptr_1, int_2, byte_);
		}

		public static bool smethod_1(IntPtr intptr_1, int int_2, byte[] byte_1)
		{
			int num = 4;
			if (!IsWindow(intptr_1))
			{
				throw new Exception(intptr_1 + " not a window");
			}
			Struct67 @struct = default(Struct67);
			@struct.int_0 = int_2;
			if (byte_1 != null && byte_1.Length > 0)
			{
				@struct.int_1 = byte_1.Length;
				@struct.intptr_0 = Marshal.AllocCoTaskMem(byte_1.Length);
				Marshal.Copy(byte_1, 0, @struct.intptr_0, byte_1.Length);
			}
			IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(@struct));
			Marshal.StructureToPtr(@struct, intPtr, fDeleteOld: true);
			bool result = SendMessage(intptr_1, 74, 0, (int)intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			if (byte_1 != null && byte_1.Length > 0)
			{
				Marshal.FreeCoTaskMem(@struct.intptr_0);
			}
			return result;
		}

		public static bool smethod_2(Message message_0)
		{
			return message_0.Msg == 74;
		}

		public bool method_7(Message message_0)
		{
			if (message_0.Msg == 74)
			{
				intptr_0 = message_0.HWnd;
				Struct67 @struct = (Struct67)Marshal.PtrToStructure(message_0.LParam, typeof(Struct67));
				byte_0 = null;
				int_1 = @struct.int_0;
				if (@struct.int_1 != 0)
				{
					byte_0 = new byte[@struct.int_1];
					Marshal.Copy(@struct.intptr_0, byte_0, 0, byte_0.Length);
					return true;
				}
			}
			return false;
		}

		public string method_8(Message message_0)
		{
			if (method_7(message_0) && byte_0 != null)
			{
				return Encoding.UTF8.GetString(byte_0);
			}
			return null;
		}

		[DllImport("user32.dll")]
		private static extern bool SendMessage(IntPtr intptr_1, int int_2, int int_3, int int_4);

		[DllImport("user32.dll")]
		private static extern bool IsWindow(IntPtr intptr_1);
	}
}
