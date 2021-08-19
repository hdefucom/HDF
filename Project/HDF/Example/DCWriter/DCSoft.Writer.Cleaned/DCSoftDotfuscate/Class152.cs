using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class152
	{
		private const ushort ushort_0 = 13961;

		private const ushort ushort_1 = 34658;

		private const ushort ushort_2 = 8224;

		private const ushort ushort_3 = 13961;

		private const ushort ushort_4 = 8224;

		private const ushort ushort_5 = 8224;

		private const short short_0 = 2;

		private const short short_1 = 16;

		private const short short_2 = -1;

		private const short short_3 = 259;

		private const uint uint_0 = 2147483648u;

		private const int int_0 = 1073741824;

		private const uint uint_1 = 1u;

		private const uint uint_2 = 2u;

		private const uint uint_3 = 3u;

		private const uint uint_4 = 128u;

		private const uint uint_5 = 65535u;

		private const short short_4 = 495;

		public const int int_1 = -21;

		public const int int_2 = -22;

		public const int int_3 = -23;

		public const int int_4 = -24;

		public const int int_5 = -50;

		public const int int_6 = 97;

		public const int int_7 = 128;

		public const int int_8 = 225;

		public const int int_9 = 80;

		public const int int_10 = 32;

		public const int int_11 = 16;

		private const byte byte_0 = 1;

		private const byte byte_1 = 2;

		private const byte byte_2 = 5;

		private const byte byte_3 = 8;

		private const byte byte_4 = 9;

		private const byte byte_5 = 16;

		private const byte byte_6 = 17;

		private const byte byte_7 = 18;

		private const byte byte_8 = 19;

		private const byte byte_9 = 32;

		private const byte byte_10 = 36;

		private const byte byte_11 = 48;

		private const byte byte_12 = 49;

		private const byte byte_13 = 50;

		private const byte byte_14 = 51;

		private const byte byte_15 = 52;

		private const byte byte_16 = 53;

		private const byte byte_17 = 54;

		private const byte byte_18 = 55;

		private const byte byte_19 = 81;

		private const byte byte_20 = 82;

		private const byte byte_21 = 83;

		private const byte byte_22 = 83;

		private bool bool_0;

		[DllImport("kernel32.dll")]
		public static extern int lstrlenA(string string_0);

		[DllImport("kernel32.dll")]
		public static extern void RtlMoveMemory(byte[] byte_23, string string_0, int int_12);

		[DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory")]
		public static extern void RtlMoveMemory_1(StringBuilder stringBuilder_0, byte[] byte_23, int int_12);

		[DllImport("HID.dll")]
		private static extern bool HidD_GetAttributes(int int_12, ref GStruct5 gstruct5_0);

		[DllImport("HID.dll")]
		private static extern int HidD_GetHidGuid(ref GStruct0 gstruct0_0);

		[DllImport("HID.dll")]
		private static extern bool HidD_GetPreparsedData(int int_12, ref IntPtr intptr_0);

		[DllImport("HID.dll")]
		private static extern int HidP_GetCaps(IntPtr intptr_0, ref GStruct6 gstruct6_0);

		[DllImport("HID.dll")]
		private static extern bool HidD_FreePreparsedData(IntPtr intptr_0);

		[DllImport("HID.dll")]
		private static extern bool HidD_SetFeature(int int_12, byte[] byte_23, int int_13);

		[DllImport("HID.dll")]
		private static extern bool HidD_GetFeature(int int_12, byte[] byte_23, int int_13);

		[DllImport("SetupApi.dll")]
		private static extern IntPtr SetupDiGetClassDevsA(ref GStruct0 gstruct0_0, int int_12, int int_13, int int_14);

		[DllImport("SetupApi.dll")]
		private static extern bool SetupDiDestroyDeviceInfoList(IntPtr intptr_0);

		[DllImport("SetupApi.dll")]
		private static extern bool SetupDiGetDeviceInterfaceDetailA(IntPtr intptr_0, ref GStruct1 gstruct1_0, ref GStruct4 gstruct4_0, int int_12, ref int int_13, int int_14);

		[DllImport("SetupApi.dll", EntryPoint = "SetupDiGetDeviceInterfaceDetailA")]
		private static extern bool SetupDiGetDeviceInterfaceDetailA_1(IntPtr intptr_0, ref GStruct2 gstruct2_0, ref GStruct4 gstruct4_0, int int_12, ref int int_13, int int_14);

		[DllImport("SetupApi.dll")]
		private static extern bool SetupDiEnumDeviceInterfaces(IntPtr intptr_0, int int_12, ref GStruct0 gstruct0_0, int int_13, ref GStruct1 gstruct1_0);

		[DllImport("SetupApi.dll", EntryPoint = "SetupDiEnumDeviceInterfaces")]
		private static extern bool SetupDiEnumDeviceInterfaces_1(IntPtr intptr_0, ulong ulong_0, ref GStruct0 gstruct0_0, int int_12, ref GStruct2 gstruct2_0);

		[DllImport("kernel32.dll")]
		private static extern int CreateFileA(string string_0, uint uint_6, uint uint_7, uint uint_8, uint uint_9, uint uint_10, uint uint_11);

		[DllImport("kernel32.dll")]
		private static extern int CloseHandle(int int_12);

		[DllImport("kernel32.dll")]
		private static extern int GetLastError();

		[DllImport("kernel32.dll")]
		private static extern int CreateSemaphoreA(int int_12, int int_13, int int_14, string string_0);

		[DllImport("kernel32.dll")]
		private static extern int WaitForSingleObject(int int_12, uint uint_6);

		[DllImport("kernel32.dll")]
		private static extern int ReleaseSemaphore(int int_12, int int_13, int int_14);

		public Class152()
		{
			bool_0 = (IntPtr.Size == 4);
		}

		private static string smethod_0(byte[] byte_23)
		{
			char[] array = new char[2];
			char[] trimChars = array;
			Encoding @default = Encoding.Default;
			return @default.GetString(byte_23).TrimEnd(trimChars);
		}

		private uint method_0(string string_0)
		{
			string[] array = new string[16]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"A",
				"B",
				"C",
				"D",
				"E",
				"F"
			};
			string_0 = string_0.ToUpper();
			int num = 1;
			int num2 = 0;
			for (int num3 = string_0.Length; num3 > 0; num3--)
			{
				string a = string_0.Substring(num3 - 1, 1);
				int num4 = 0;
				for (int i = 0; i < 16; i++)
				{
					if (a == array[i])
					{
						num4 = i;
					}
				}
				num2 += num4 * num;
				num *= 16;
			}
			return (uint)num2;
		}

		private int method_1(string string_0, ref byte[] byte_23)
		{
			int length = string_0.Length;
			int num;
			if (length < 16)
			{
				num = 16;
			}
			num = length / 2;
			byte_23 = new byte[num];
			int num2 = 0;
			for (int i = 0; i < length; i += 2)
			{
				string string_ = string_0.Substring(i, 2);
				byte_23[num2] = (byte)method_0(string_);
				num2++;
			}
			return num;
		}

		public void method_2(byte[] byte_23, byte[] byte_24, string string_0)
		{
			uint[] array = new uint[16];
			uint num = 2654435769u;
			uint num2 = 0u;
			int length = string_0.Length;
			int num3 = 0;
			for (int i = 1; i <= length; i += 2)
			{
				string string_ = string_0.Substring(i - 1, 2);
				array[num3] = method_0(string_);
				num3++;
			}
			uint num4 = 0u;
			uint num5 = 0u;
			uint num6 = 0u;
			uint num7 = 0u;
			for (int i = 0; i <= 3; i++)
			{
				num4 = ((array[i] << i * 8) | num4);
				num5 = ((array[i + 4] << i * 8) | num5);
				num6 = ((array[i + 4 + 4] << i * 8) | num6);
				num7 = ((array[i + 4 + 4 + 4] << i * 8) | num7);
			}
			uint num8 = 0u;
			uint num9 = 0u;
			for (int i = 0; i <= 3; i++)
			{
				uint num10 = byte_23[i];
				num8 = ((num10 << i * 8) | num8);
				num10 = byte_23[i + 4];
				num9 = ((num10 << i * 8) | num9);
			}
			for (int i = 32; i > 0; i--)
			{
				num2 = num + num2;
				num8 += (((num9 << 4) + num4) ^ (num9 + num2) ^ ((num9 >> 5) + num5));
				num9 += (((num8 << 4) + num6) ^ (num8 + num2) ^ ((num8 >> 5) + num7));
			}
			for (int i = 0; i <= 3; i++)
			{
				byte_24[i] = Convert.ToByte((num8 >> i * 8) & 0xFF);
				byte_24[i + 4] = Convert.ToByte((num9 >> i * 8) & 0xFF);
			}
		}

		public void method_3(byte[] byte_23, byte[] byte_24, string string_0)
		{
			uint[] array = new uint[16];
			uint num = 2654435769u;
			uint num2 = 3337565984u;
			int length = string_0.Length;
			int num3 = 0;
			int i;
			for (i = 1; i <= length; i += 2)
			{
				string string_ = string_0.Substring(i - 1, 2);
				array[num3] = method_0(string_);
				num3++;
			}
			uint num4 = 0u;
			uint num5 = 0u;
			uint num6 = 0u;
			uint num7 = 0u;
			for (i = 0; i <= 3; i++)
			{
				num4 = ((array[i] << i * 8) | num4);
				num5 = ((array[i + 4] << i * 8) | num5);
				num6 = ((array[i + 4 + 4] << i * 8) | num6);
				num7 = ((array[i + 4 + 4 + 4] << i * 8) | num7);
			}
			uint num8 = 0u;
			uint num9 = 0u;
			for (i = 0; i <= 3; i++)
			{
				uint num10 = byte_23[i];
				num8 = ((num10 << i * 8) | num8);
				num10 = byte_23[i + 4];
				num9 = ((num10 << i * 8) | num9);
			}
			i = 32;
			while (i-- > 0)
			{
				num9 -= (((num8 << 4) + num6) ^ (num8 + num2) ^ ((num8 >> 5) + num7));
				num8 -= (((num9 << 4) + num4) ^ (num9 + num2) ^ ((num9 >> 5) + num5));
				num2 -= num;
			}
			for (i = 0; i <= 3; i++)
			{
				byte_24[i] = Convert.ToByte((num8 >> i * 8) & 0xFF);
				byte_24[i + 4] = Convert.ToByte((num9 >> i * 8) & 0xFF);
			}
		}

		public string method_4(string string_0, string string_1)
		{
			int num = 2;
			byte[] array = new byte[8];
			byte[] array2 = new byte[8];
			int num2 = lstrlenA(string_0) + 1;
			int num3 = (num2 >= 8) ? num2 : 8;
			byte[] array3 = new byte[num3];
			byte[] array4 = new byte[num3];
			RtlMoveMemory(array3, string_0, num2);
			array3.CopyTo(array4, 0);
			for (int i = 0; i <= num3 - 8; i += 8)
			{
				for (int j = 0; j < 8; j++)
				{
					array[j] = array3[j + i];
				}
				method_2(array, array2, string_1);
				for (int j = 0; j < 8; j++)
				{
					array4[j + i] = array2[j];
				}
			}
			string text = "";
			for (int i = 0; i <= num3 - 1; i++)
			{
				text += array4[i].ToString("X2");
			}
			return text;
		}

		public string method_5(string string_0, string string_1)
		{
			byte[] array = new byte[8];
			byte[] array2 = new byte[8];
			int length = string_0.Length;
			int num;
			if (length < 16)
			{
				num = 16;
			}
			num = length / 2;
			byte[] array3 = new byte[num];
			byte[] array4 = new byte[num];
			int num2 = 0;
			for (int i = 1; i <= length; i += 2)
			{
				string string_2 = string_0.Substring(i - 1, 2);
				array3[num2] = Convert.ToByte(method_0(string_2));
				num2++;
			}
			array3.CopyTo(array4, 0);
			for (int i = 0; i <= num - 8; i += 8)
			{
				for (num2 = 0; num2 < 8; num2++)
				{
					array[num2] = array3[num2 + i];
				}
				method_3(array, array2, string_1);
				for (num2 = 0; num2 < 8; num2++)
				{
					array4[num2 + i] = array2[num2];
				}
			}
			StringBuilder stringBuilder = new StringBuilder("", num);
			RtlMoveMemory_1(stringBuilder, array4, num);
			return stringBuilder.ToString();
		}

		private bool method_6(int int_12, ref int int_13, ref string string_0)
		{
			if (bool_0)
			{
				return method_8(int_12, ref int_13, ref string_0);
			}
			return method_7(int_12, ref int_13, ref string_0);
		}

		private bool method_7(int int_12, ref int int_13, ref string string_0)
		{
			GStruct2 gstruct2_ = default(GStruct2);
			GStruct0 gstruct0_ = default(GStruct0);
			GStruct4 gstruct4_ = default(GStruct4);
			GStruct5 gstruct5_ = default(GStruct5);
			int num = 0;
			int_13 = 0;
			HidD_GetHidGuid(ref gstruct0_);
			IntPtr intPtr = SetupDiGetClassDevsA(ref gstruct0_, 0, 0, 18);
			if (intPtr == (IntPtr)(-1))
			{
				return false;
			}
			gstruct2_.long_0 = Marshal.SizeOf(gstruct2_);
			int num2;
			while (true)
			{
				if (SetupDiEnumDeviceInterfaces_1(intPtr, 0uL, ref gstruct0_, num, ref gstruct2_) && GetLastError() != 259)
				{
					gstruct4_.int_0 = 8;
					int int_14 = 0;
					if (SetupDiGetDeviceInterfaceDetailA_1(intPtr, ref gstruct2_, ref gstruct4_, 300, ref int_14, 0))
					{
						string_0 = smethod_0(gstruct4_.byte_0);
						num2 = CreateFileA(string_0, 3221225472u, 3u, 0u, 3u, 0u, 0u);
						if (-1 != num2)
						{
							if (HidD_GetAttributes(num2, ref gstruct5_) && ((gstruct5_.ushort_1 == 34658 && gstruct5_.ushort_0 == 13961) || (gstruct5_.ushort_1 == 8224 && gstruct5_.ushort_0 == 13961) || (gstruct5_.ushort_1 == 8224 && gstruct5_.ushort_0 == 8224)))
							{
								if (int_12 == int_13)
								{
									break;
								}
								int_13++;
							}
							CloseHandle(num2);
						}
						num++;
						continue;
					}
					SetupDiDestroyDeviceInfoList(intPtr);
					return false;
				}
				SetupDiDestroyDeviceInfoList(intPtr);
				return false;
			}
			SetupDiDestroyDeviceInfoList(intPtr);
			CloseHandle(num2);
			return true;
		}

		private bool method_8(int int_12, ref int int_13, ref string string_0)
		{
			GStruct1 gstruct1_ = default(GStruct1);
			GStruct0 gstruct0_ = default(GStruct0);
			GStruct4 gstruct4_ = default(GStruct4);
			GStruct5 gstruct5_ = default(GStruct5);
			int num = 0;
			int_13 = 0;
			HidD_GetHidGuid(ref gstruct0_);
			IntPtr intPtr = SetupDiGetClassDevsA(ref gstruct0_, 0, 0, 18);
			if (intPtr == (IntPtr)(-1))
			{
				return false;
			}
			gstruct1_.int_0 = Marshal.SizeOf(gstruct1_);
			int num2;
			while (true)
			{
				if (SetupDiEnumDeviceInterfaces(intPtr, 0, ref gstruct0_, num, ref gstruct1_) && GetLastError() != 259)
				{
					gstruct4_.int_0 = Marshal.SizeOf(gstruct4_) - 255;
					int int_14 = 0;
					if (SetupDiGetDeviceInterfaceDetailA(intPtr, ref gstruct1_, ref gstruct4_, 300, ref int_14, 0))
					{
						string_0 = smethod_0(gstruct4_.byte_0);
						num2 = CreateFileA(string_0, 3221225472u, 3u, 0u, 3u, 0u, 0u);
						if (-1 != num2)
						{
							if (HidD_GetAttributes(num2, ref gstruct5_) && ((gstruct5_.ushort_1 == 34658 && gstruct5_.ushort_0 == 13961) || (gstruct5_.ushort_1 == 8224 && gstruct5_.ushort_0 == 13961) || (gstruct5_.ushort_1 == 8224 && gstruct5_.ushort_0 == 8224)))
							{
								if (int_12 == int_13)
								{
									break;
								}
								int_13++;
							}
							CloseHandle(num2);
						}
						num++;
						continue;
					}
					SetupDiDestroyDeviceInfoList(intPtr);
					return false;
				}
				SetupDiDestroyDeviceInfoList(intPtr);
				return false;
			}
			SetupDiDestroyDeviceInfoList(intPtr);
			CloseHandle(num2);
			return true;
		}

		private bool method_9(int int_12, byte[] byte_23, int int_13)
		{
			byte[] array = new byte[512];
			IntPtr intptr_ = IntPtr.Zero;
			GStruct6 gstruct6_ = default(GStruct6);
			if (!HidD_GetPreparsedData(int_12, ref intptr_))
			{
				return false;
			}
			if (HidP_GetCaps(intptr_, ref gstruct6_) <= 0)
			{
				HidD_FreePreparsedData(intptr_);
				return false;
			}
			bool flag = true;
			array[0] = 1;
			bool flag2;
			if (flag2 = HidD_GetFeature(int_12, array, gstruct6_.short_4))
			{
				for (int i = 0; i < int_13; i++)
				{
					byte_23[i] = array[i];
				}
			}
			flag = (flag && flag2);
			HidD_FreePreparsedData(intptr_);
			return flag;
		}

		private bool method_10(int int_12, byte[] byte_23, int int_13)
		{
			byte[] array = new byte[512];
			IntPtr intptr_ = IntPtr.Zero;
			GStruct6 gstruct6_ = default(GStruct6);
			if (!HidD_GetPreparsedData(int_12, ref intptr_))
			{
				return false;
			}
			if (HidP_GetCaps(intptr_, ref gstruct6_) <= 0)
			{
				HidD_FreePreparsedData(intptr_);
				return false;
			}
			bool flag = true;
			array[0] = 2;
			for (int i = 0; i < int_13; i++)
			{
				array[i + 1] = byte_23[i + 1];
			}
			bool flag2 = HidD_SetFeature(int_12, array, gstruct6_.short_4);
			flag = (flag && flag2);
			HidD_FreePreparsedData(intptr_);
			return flag;
		}

		private int method_11(int int_12, ref string string_0)
		{
			int int_13 = 0;
			if (!method_6(int_12, ref int_13, ref string_0))
			{
				return -92;
			}
			return 0;
		}

		private int method_12(int int_12, int int_13, int int_14, ref string string_0)
		{
			int int_15 = 0;
			int int_16 = 0;
			int num = int_12;
			while (true)
			{
				if (num < 256)
				{
					if (method_6(num, ref int_15, ref string_0))
					{
						if (method_24(int_13, string_0) == 0 && method_23(ref int_16, string_0) == 0 && int_16 == int_14)
						{
							break;
						}
						num++;
						continue;
					}
					return -92;
				}
				return -92;
			}
			return 0;
		}

		private int method_13(ref int int_12, string string_0)
		{
			int int_13 = 0;
			if (string_0.Length < 1)
			{
				string string_ = "";
				if (!method_6(0, ref int_13, ref string_))
				{
					return -92;
				}
				int_12 = CreateFileA(string_, 3221225472u, 3u, 0u, 3u, 128u, 0u);
				if (int_12 == -1)
				{
					return -92;
				}
			}
			else
			{
				int_12 = CreateFileA(string_0, 3221225472u, 3u, 0u, 3u, 128u, 0u);
				if (int_12 == -1)
				{
					return -92;
				}
			}
			return 0;
		}

		private int method_14(ref byte byte_23, ref byte byte_24, ref byte byte_25, ref byte byte_26, string string_0)
		{
			byte[] array = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			if (!method_9(int_, array, 5))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			byte_23 = array[0];
			byte_24 = array[1];
			byte_25 = array[2];
			byte_26 = array[3];
			return 0;
		}

		private int method_15(byte byte_23, byte byte_24, byte byte_25, byte byte_26, string string_0)
		{
			byte[] array = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 3;
			array[2] = byte_23;
			array[3] = byte_24;
			array[4] = byte_25;
			array[5] = byte_26;
			if (!method_10(int_, array, 5))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			return 0;
		}

		private int method_16(byte byte_23, byte byte_24, byte byte_25, byte byte_26, string string_0)
		{
			byte[] array = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 4;
			array[2] = byte_23;
			array[3] = byte_24;
			array[4] = byte_25;
			array[5] = byte_26;
			if (!method_10(int_, array, 5))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			return 0;
		}

		private int method_17(ref short short_5, string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 1;
			if (!method_10(int_, array, 1))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 1))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			short_5 = array2[0];
			return 0;
		}

		private int method_18(ref int int_12, ref int int_13, string string_0)
		{
			int[] array = new int[8];
			byte[] array2 = new byte[25];
			byte[] array3 = new byte[25];
			int int_14 = 0;
			if (method_13(ref int_14, string_0) != 0)
			{
				return -92;
			}
			array2[1] = 2;
			if (!method_10(int_14, array2, 1))
			{
				CloseHandle(int_14);
				return -93;
			}
			if (!method_9(int_14, array3, 8))
			{
				CloseHandle(int_14);
				return -93;
			}
			CloseHandle(int_14);
			array[0] = array3[0];
			array[1] = array3[1];
			array[2] = array3[2];
			array[3] = array3[3];
			array[4] = array3[4];
			array[5] = array3[5];
			array[6] = array3[6];
			array[7] = array3[7];
			int_12 = (array[3] | (array[2] << 8) | (array[1] << 16) | (array[0] << 24));
			int_13 = (array[7] | (array[6] << 8) | (array[5] << 16) | (array[4] << 24));
			return 0;
		}

		private int method_19(byte[] byte_23, int int_12, int int_13, byte[] byte_24, string string_0, int int_14)
		{
			byte[] array = new byte[512];
			byte[] array2 = new byte[512];
			if (int_12 > 495 || int_12 < 0)
			{
				return -81;
			}
			if (int_13 > 255)
			{
				return -87;
			}
			if (int_13 + int_12 > 495)
			{
				return -88;
			}
			int num = (int_12 >> 8) * 2;
			int num2 = int_12 & 0xFF;
			int int_15 = 0;
			if (method_13(ref int_15, string_0) != 0)
			{
				return -92;
			}
			array[1] = 18;
			array[2] = (byte)num;
			array[3] = (byte)num2;
			array[4] = (byte)int_13;
			for (int i = 0; i <= 7; i++)
			{
				array[5 + i] = byte_24[i];
			}
			if (!method_10(int_15, array, 13))
			{
				CloseHandle(int_15);
				return -93;
			}
			if (!method_9(int_15, array2, int_13 + 1))
			{
				CloseHandle(int_15);
				return -94;
			}
			CloseHandle(int_15);
			if (array2[0] != 0)
			{
				return -83;
			}
			for (int i = 0; i < int_13; i++)
			{
				byte_23[i + int_14] = array2[i + 1];
			}
			return 0;
		}

		private int method_20(byte[] byte_23, int int_12, int int_13, byte[] byte_24, string string_0, int int_14)
		{
			byte[] array = new byte[512];
			byte[] array2 = new byte[512];
			if (int_13 > 255)
			{
				return -87;
			}
			if (int_12 + int_13 - 1 > 512 || int_12 < 0)
			{
				return -81;
			}
			int num = (int_12 >> 8) * 2;
			int num2 = int_12 & 0xFF;
			int int_15 = 0;
			if (method_13(ref int_15, string_0) != 0)
			{
				return -92;
			}
			array[1] = 19;
			array[2] = (byte)num;
			array[3] = (byte)num2;
			array[4] = (byte)int_13;
			for (int i = 0; i <= 7; i++)
			{
				array[5 + i] = byte_24[i];
			}
			for (int i = 0; i < int_13; i++)
			{
				array[13 + i] = byte_23[i + int_14];
			}
			if (!method_10(int_15, array, 13 + int_13))
			{
				CloseHandle(int_15);
				return -93;
			}
			if (!method_9(int_15, array2, 2))
			{
				CloseHandle(int_15);
				return -94;
			}
			CloseHandle(int_15);
			if (array2[0] != 0)
			{
				return -82;
			}
			return 0;
		}

		private int method_21(byte[] byte_23, byte[] byte_24, string string_0, int int_12)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_13 = 0;
			if (method_13(ref int_13, string_0) != 0)
			{
				return -92;
			}
			array[1] = 8;
			for (int i = 2; i <= 9; i++)
			{
				array[i] = byte_23[i - 2 + int_12];
			}
			if (!method_10(int_13, array, 9))
			{
				CloseHandle(int_13);
				return -93;
			}
			if (!method_9(int_13, array2, 9))
			{
				CloseHandle(int_13);
				return -93;
			}
			CloseHandle(int_13);
			for (int i = 0; i < 8; i++)
			{
				byte_24[i + int_12] = array2[i];
			}
			if (array2[8] != 85)
			{
				return -20;
			}
			return 0;
		}

		private int method_22(byte[] byte_23, byte byte_24, string string_0, short short_5)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 9;
			array[2] = byte_24;
			for (int i = 0; i < 8; i++)
			{
				array[3 + i] = byte_23[i + short_5];
			}
			if (!method_10(int_, array, 11))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 2))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[0] != 0)
			{
				return -82;
			}
			return 0;
		}

		private int method_23(ref int int_12, string string_0)
		{
			byte byte_ = 0;
			byte byte_2 = 0;
			byte byte_3 = 0;
			byte byte_4 = 0;
			int result = method_14(ref byte_, ref byte_2, ref byte_3, ref byte_4, string_0);
			int num = byte_;
			int num2 = byte_2;
			int num3 = byte_3;
			int num4 = byte_4;
			int_12 = (num | (num2 << 8) | (num3 << 16) | (num4 << 24));
			return result;
		}

		private int method_24(int int_12, string string_0)
		{
			byte byte_ = (byte)(int_12 & 0xFF);
			byte byte_2 = (byte)((int_12 >> 8) & 0xFF);
			byte byte_3 = (byte)((int_12 >> 16) & 0xFF);
			byte byte_4 = (byte)((int_12 >> 24) & 0xFF);
			return method_15(byte_, byte_2, byte_3, byte_4, string_0);
		}

		private int method_25(int int_12, string string_0)
		{
			byte byte_ = (byte)(int_12 & 0xFF);
			byte byte_2 = (byte)((int_12 >> 8) & 0xFF);
			byte byte_3 = (byte)((int_12 >> 16) & 0xFF);
			byte byte_4 = (byte)((int_12 >> 24) & 0xFF);
			return method_16(byte_, byte_2, byte_3, byte_4, string_0);
		}

		public int method_26(ref short short_5, string string_0)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_17(ref short_5, string_0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		public int method_27(ref int int_12, ref int int_13, string string_0)
		{
			int int_14 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_14, 65535u);
			int result = method_18(ref int_12, ref int_13, string_0);
			ReleaseSemaphore(int_14, 1, 0);
			CloseHandle(int_14);
			return result;
		}

		public int method_28(ref int int_12, string string_0)
		{
			int int_13 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_13, 65535u);
			int result = method_23(ref int_12, string_0);
			ReleaseSemaphore(int_13, 1, 0);
			CloseHandle(int_13);
			return result;
		}

		public int method_29(int int_12, string string_0)
		{
			int int_13 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_13, 65535u);
			int result = method_24(int_12, string_0);
			ReleaseSemaphore(int_13, 1, 0);
			CloseHandle(int_13);
			return result;
		}

		public int method_30(byte[] byte_23, int int_12, int int_13, string string_0, string string_1, string string_2)
		{
			int num = 0;
			int num2 = 0;
			byte[] array = new byte[8];
			int int_14 = 0;
			if (int_12 + int_13 - 1 > 495 || int_12 < 0)
			{
				return -81;
			}
			num2 = method_68(string_2, ref int_14);
			if (int_14 < 100)
			{
				int_14 = 16;
			}
			int_14 -= 8;
			if (num2 != 0)
			{
				return num2;
			}
			method_36(string_0, string_1, array);
			int int_15 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_15, 65535u);
			int num3 = int_12 % int_14;
			int num4 = int_14 - num3;
			if (num4 > int_13)
			{
				num4 = int_13;
			}
			if (num4 > 0)
			{
				int i;
				for (i = 0; i < num4 / int_14; i++)
				{
					num2 = method_20(byte_23, int_12 + i * int_14, int_14, array, string_2, int_14 * i);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_15, 1, 0);
						CloseHandle(int_15);
						return method_62(byte_23, int_12, int_13, string_0, string_1, string_2);
					}
				}
				if (num4 - int_14 * i > 0)
				{
					num2 = method_20(byte_23, int_12 + i * int_14, num4 - i * int_14, array, string_2, int_14 * i);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_15, 1, 0);
						CloseHandle(int_15);
						return method_62(byte_23, int_12, int_13, string_0, string_1, string_2);
					}
				}
			}
			int_13 -= num4;
			int_12 += num4;
			if (int_13 > 0)
			{
				int i;
				for (i = 0; i < int_13 / int_14; i++)
				{
					num2 = method_20(byte_23, int_12 + i * int_14, int_14, array, string_2, num4 + int_14 * i);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_15, 1, 0);
						CloseHandle(int_15);
						return method_62(byte_23, int_12, int_13, string_0, string_1, string_2);
					}
				}
				if (int_13 - int_14 * i > 0)
				{
					num2 = method_20(byte_23, int_12 + i * int_14, int_13 - i * int_14, array, string_2, num4 + int_14 * i);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_15, 1, 0);
						CloseHandle(int_15);
						return method_62(byte_23, int_12, int_13, string_0, string_1, string_2);
					}
				}
			}
			ReleaseSemaphore(int_15, 1, 0);
			CloseHandle(int_15);
			return num2;
		}

		public int method_31(byte[] byte_23, short short_5, short short_6, string string_0, string string_1, string string_2)
		{
			int num = 10;
			int num2 = 0;
			byte[] array = new byte[8];
			int int_ = 0;
			if (short_5 + short_6 - 1 > 495 || short_5 < 0)
			{
				return -81;
			}
			num2 = method_68(string_2, ref int_);
			if (int_ < 100)
			{
				int_ = 16;
			}
			if (num2 != 0)
			{
				return num2;
			}
			method_36(string_0, string_1, array);
			int int_2 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_2, 65535u);
			int num3 = 0;
			while (true)
			{
				if (num3 < short_6 / int_)
				{
					num2 = method_19(byte_23, short_5 + num3 * int_, int_, array, string_2, num3 * int_);
					if (num2 != 0)
					{
						break;
					}
					num3++;
					continue;
				}
				if (short_6 - int_ * num3 > 0)
				{
					num2 = method_19(byte_23, short_5 + num3 * int_, short_6 - int_ * num3, array, string_2, int_ * num3);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_2, 1, 0);
						CloseHandle(int_2);
						return method_61(byte_23, short_5, short_6, string_0, string_1, string_2);
					}
				}
				ReleaseSemaphore(int_2, 1, 0);
				CloseHandle(int_2);
				return num2;
			}
			ReleaseSemaphore(int_2, 1, 0);
			CloseHandle(int_2);
			return method_61(byte_23, short_5, short_6, string_0, string_1, string_2);
		}

		public int method_32(int int_12, int int_13, int int_14, ref string string_0)
		{
			int int_15 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_15, 65535u);
			int result = method_12(int_12, int_13, int_14, ref string_0);
			ReleaseSemaphore(int_15, 1, 0);
			CloseHandle(int_15);
			return result;
		}

		public int method_33(int int_12, ref string string_0)
		{
			int int_13 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_13, 65535u);
			int result = method_11(int_12, ref string_0);
			ReleaseSemaphore(int_13, 1, 0);
			CloseHandle(int_13);
			return result;
		}

		public int method_34(int int_12, string string_0)
		{
			int int_13 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_13, 65535u);
			int result = method_25(int_12, string_0);
			ReleaseSemaphore(int_13, 1, 0);
			CloseHandle(int_13);
			return result;
		}

		private string method_35(string string_0)
		{
			int num = 1;
			int length = string_0.Length;
			for (int i = length; i <= 7; i++)
			{
				string_0 = "0" + string_0;
			}
			return string_0;
		}

		private void method_36(string string_0, string string_1, byte[] byte_23)
		{
			string_0 = method_35(string_0);
			string_1 = method_35(string_1);
			for (int i = 0; i <= 3; i++)
			{
				byte_23[i] = (byte)method_0(string_0.Substring(i * 2, 2));
			}
			for (int i = 0; i <= 3; i++)
			{
				byte_23[i + 4] = (byte)method_0(string_1.Substring(i * 2, 2));
			}
		}

		public int method_37(ref byte byte_23, int int_12, string string_0, string string_1, string string_2)
		{
			int num = 4;
			byte[] array = new byte[8];
			if (int_12 > 495 || int_12 < 0)
			{
				return -81;
			}
			method_36(string_0, string_1, array);
			int int_13 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_13, 65535u);
			int result = method_38(ref byte_23, int_12, array, string_2);
			ReleaseSemaphore(int_13, 1, 0);
			CloseHandle(int_13);
			return result;
		}

		private int method_38(ref byte byte_23, int int_12, byte[] byte_24, string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_13 = 0;
			if (int_12 > 495 || int_12 < 0)
			{
				return -81;
			}
			byte b = 128;
			if (int_12 > 255)
			{
				b = 160;
				int_12 -= 256;
			}
			if (method_13(ref int_13, string_0) != 0)
			{
				return -92;
			}
			array[1] = 16;
			array[2] = b;
			array[3] = (byte)int_12;
			array[4] = (byte)int_12;
			for (int i = 0; i < 8; i++)
			{
				array[5 + i] = byte_24[i];
			}
			if (!method_10(int_13, array, 13))
			{
				CloseHandle(int_13);
				return -93;
			}
			if (!method_9(int_13, array2, 2))
			{
				CloseHandle(int_13);
				return -94;
			}
			CloseHandle(int_13);
			if (array2[0] != 83)
			{
				return -83;
			}
			byte_23 = array2[1];
			return 0;
		}

		public int method_39(byte byte_23, int int_12, string string_0, string string_1, string string_2)
		{
			int num = 17;
			byte[] array = new byte[8];
			if (int_12 > 495 || int_12 < 0)
			{
				return -81;
			}
			method_36(string_0, string_1, array);
			int int_13 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_13, 65535u);
			int result = method_40(byte_23, int_12, array, string_2);
			ReleaseSemaphore(int_13, 1, 0);
			CloseHandle(int_13);
			return result;
		}

		private int method_40(byte byte_23, int int_12, byte[] byte_24, string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_13 = 0;
			if (int_12 > 511 || int_12 < 0)
			{
				return -81;
			}
			byte b = 64;
			if (int_12 > 255)
			{
				b = 96;
				int_12 -= 256;
			}
			if (method_13(ref int_13, string_0) != 0)
			{
				return -92;
			}
			array[1] = 17;
			array[2] = b;
			array[3] = (byte)int_12;
			array[4] = byte_23;
			for (int i = 0; i < 8; i++)
			{
				array[5 + i] = byte_24[i];
			}
			if (!method_10(int_13, array, 13))
			{
				CloseHandle(int_13);
				return -93;
			}
			if (!method_9(int_13, array2, 2))
			{
				CloseHandle(int_13);
				return -94;
			}
			CloseHandle(int_13);
			if (array2[1] != 1)
			{
				return -82;
			}
			return 0;
		}

		public int method_41(string string_0, string string_1, string string_2, string string_3, string string_4)
		{
			byte[] array = new byte[8];
			byte[] byte_ = new byte[8];
			method_36(string_0, string_1, array);
			method_36(string_2, string_3, byte_);
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_20(byte_, 496, 8, array, string_4, 0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		public int method_42(string string_0, string string_1, string string_2, string string_3, string string_4)
		{
			byte[] array = new byte[8];
			byte[] byte_ = new byte[8];
			method_36(string_0, string_1, array);
			method_36(string_2, string_3, byte_);
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_20(byte_, 504, 8, array, string_4, 0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		public int method_43(string string_0, int int_12, string string_1, string string_2, string string_3)
		{
			int num = 0;
			int num2 = 0;
			byte[] array = new byte[8];
			int int_13 = 0;
			if (int_12 < 0)
			{
				return -81;
			}
			num2 = method_68(string_3, ref int_13);
			if (int_13 < 100)
			{
				int_13 = 16;
			}
			int_13 -= 8;
			if (num2 != 0)
			{
				return num2;
			}
			method_36(string_1, string_2, array);
			int num3 = lstrlenA(string_0);
			byte[] byte_ = new byte[num3];
			RtlMoveMemory(byte_, string_0, num3);
			int num4 = int_12 + num3;
			if (num4 > 495)
			{
				return -47;
			}
			int int_14 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_14, 65535u);
			int num5 = int_12 % int_13;
			int num6 = int_13 - num5;
			if (num6 > num3)
			{
				num6 = num3;
			}
			if (num6 > 0)
			{
				int i;
				for (i = 0; i < num6 / int_13; i++)
				{
					num2 = method_20(byte_, int_12 + i * int_13, int_13, array, string_3, i * int_13);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_14, 1, 0);
						CloseHandle(int_14);
						return method_60(string_0, int_12, string_1, string_2, string_3);
					}
				}
				if (num6 - int_13 * i > 0)
				{
					num2 = method_20(byte_, int_12 + i * int_13, num6 - i * int_13, array, string_3, int_13 * i);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_14, 1, 0);
						CloseHandle(int_14);
						return method_60(string_0, int_12, string_1, string_2, string_3);
					}
				}
			}
			num3 -= num6;
			int_12 += num6;
			if (num3 > 0)
			{
				int i;
				for (i = 0; i < num3 / int_13; i++)
				{
					num2 = method_20(byte_, int_12 + i * int_13, int_13, array, string_3, num6 + i * int_13);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_14, 1, 0);
						CloseHandle(int_14);
						return num2;
					}
				}
				if (num3 - int_13 * i > 0)
				{
					num2 = method_20(byte_, int_12 + i * int_13, num3 - i * int_13, array, string_3, num6 + int_13 * i);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_14, 1, 0);
						CloseHandle(int_14);
						return num2;
					}
				}
			}
			ReleaseSemaphore(int_14, 1, 0);
			CloseHandle(int_14);
			return num2;
		}

		public int method_44(ref string string_0, int int_12, int int_13, string string_1, string string_2, string string_3)
		{
			int num = 15;
			int num2 = 0;
			byte[] array = new byte[8];
			int int_14 = 0;
			byte[] byte_ = new byte[int_13];
			method_36(string_1, string_2, array);
			if (int_12 < 0)
			{
				return -81;
			}
			num2 = method_68(string_3, ref int_14);
			if (int_14 < 100)
			{
				int_14 = 16;
			}
			if (num2 != 0)
			{
				return num2;
			}
			int num3 = int_12 + int_13;
			if (num3 > 495)
			{
				return -47;
			}
			int int_15 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_15, 65535u);
			int num4 = 0;
			while (true)
			{
				if (num4 < int_13 / int_14)
				{
					num2 = method_19(byte_, int_12 + num4 * int_14, int_14, array, string_3, num4 * int_14);
					if (num2 != 0)
					{
						break;
					}
					num4++;
					continue;
				}
				if (int_13 - int_14 * num4 > 0)
				{
					num2 = method_19(byte_, int_12 + num4 * int_14, int_13 - int_14 * num4, array, string_3, int_14 * num4);
					if (num2 != 0)
					{
						ReleaseSemaphore(int_15, 1, 0);
						CloseHandle(int_15);
						return method_59(ref string_0, int_12, int_13, string_1, string_2, string_3);
					}
				}
				ReleaseSemaphore(int_15, 1, 0);
				CloseHandle(int_15);
				StringBuilder stringBuilder = new StringBuilder("", int_13);
				for (num4 = 0; num4 < int_13; num4++)
				{
					stringBuilder.Append(0);
				}
				RtlMoveMemory_1(stringBuilder, byte_, int_13);
				string_0 = stringBuilder.ToString();
				return num2;
			}
			ReleaseSemaphore(int_15, 1, 0);
			CloseHandle(int_15);
			return method_59(ref string_0, int_12, int_13, string_1, string_2, string_3);
		}

		public int method_45(string string_0, string string_1)
		{
			byte[] byte_ = new byte[16];
			method_1(string_0, ref byte_);
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int num = method_22(byte_, 0, string_1, 8);
			if (num == 0)
			{
				num = method_22(byte_, 1, string_1, 0);
			}
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return num;
		}

		public int method_46(byte[] byte_23, byte[] byte_24, string string_0)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_21(byte_23, byte_24, string_0, 0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		public int method_47(string string_0, ref string string_1, string string_2)
		{
			int num = 8;
			int num2 = 0;
			int num3 = lstrlenA(string_0) + 1;
			int int_ = num3;
			if (num3 < 8)
			{
				num3 = 8;
			}
			byte[] array = new byte[num3];
			byte[] array2 = new byte[num3];
			RtlMoveMemory(array, string_0, int_);
			array.CopyTo(array2, 0);
			int int_2 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_2, 65535u);
			for (int i = 0; i <= num3 - 8; i += 8)
			{
				num2 = method_21(array, array2, string_2, i);
				if (num2 != 0)
				{
					break;
				}
			}
			ReleaseSemaphore(int_2, 1, 0);
			CloseHandle(int_2);
			string_1 = "";
			for (int i = 0; i < num3; i++)
			{
				string_1 += array2[i].ToString("X2");
			}
			return num2;
		}

		public int method_48(int int_12, ref int int_13, string string_0)
		{
			int int_14 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_14, 65535u);
			int num = method_24(int_12, string_0);
			if (num == 0)
			{
				num = method_23(ref int_13, string_0);
			}
			ReleaseSemaphore(int_14, 1, 0);
			CloseHandle(int_14);
			return num;
		}

		public int method_49(int int_12, ref int int_13, string string_0)
		{
			int int_14 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_14, 65535u);
			int num = method_25(int_12, string_0);
			if (num == 0)
			{
				num = method_23(ref int_13, string_0);
			}
			ReleaseSemaphore(int_14, 1, 0);
			CloseHandle(int_14);
			return num;
		}

		public int method_50(string string_0)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_51(string_0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		private int method_51(string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 32;
			if (!method_10(int_, array, 2))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 2))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			if (array2[0] != 0)
			{
				return -82;
			}
			return 0;
		}

		public int method_52(string string_0, string string_1)
		{
			byte[] byte_ = new byte[16];
			method_1(string_0, ref byte_);
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int num = method_57(byte_, 0, string_1, 8);
			if (num == 0)
			{
				num = method_57(byte_, 1, string_1, 0);
			}
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return num;
		}

		public int method_53(byte[] byte_23, byte[] byte_24, string string_0)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_56(byte_23, byte_24, string_0, 0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		public int method_54(string string_0, ref string string_1, string string_2)
		{
			int num = 19;
			int num2 = 0;
			int num3 = lstrlenA(string_0) + 1;
			int int_ = num3;
			if (num3 < 8)
			{
				num3 = 8;
			}
			byte[] array = new byte[num3];
			byte[] array2 = new byte[num3];
			RtlMoveMemory(array, string_0, int_);
			array.CopyTo(array2, 0);
			int int_2 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_2, 65535u);
			for (int i = 0; i <= num3 - 8; i += 8)
			{
				num2 = method_56(array, array2, string_2, i);
				if (num2 != 0)
				{
					break;
				}
			}
			ReleaseSemaphore(int_2, 1, 0);
			CloseHandle(int_2);
			string_1 = "";
			for (int i = 0; i < num3; i++)
			{
				string_1 += array2[i].ToString("X2");
			}
			return num2;
		}

		public int method_55(ref short short_5, string string_0)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_58(ref short_5, string_0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		private int method_56(byte[] byte_23, byte[] byte_24, string string_0, int int_12)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_13 = 0;
			if (method_13(ref int_13, string_0) != 0)
			{
				return -92;
			}
			array[1] = 12;
			for (int i = 2; i <= 9; i++)
			{
				array[i] = byte_23[i - 2 + int_12];
			}
			if (!method_10(int_13, array, 9))
			{
				CloseHandle(int_13);
				return -93;
			}
			if (!method_9(int_13, array2, 9))
			{
				CloseHandle(int_13);
				return -93;
			}
			CloseHandle(int_13);
			for (int i = 0; i < 8; i++)
			{
				byte_24[i + int_12] = array2[i];
			}
			if (array2[8] != 85)
			{
				return -20;
			}
			return 0;
		}

		private int method_57(byte[] byte_23, byte byte_24, string string_0, short short_5)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 13;
			array[2] = byte_24;
			for (int i = 0; i < 8; i++)
			{
				array[3 + i] = byte_23[i + short_5];
			}
			if (!method_10(int_, array, 11))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 2))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[0] != 0)
			{
				return -82;
			}
			return 0;
		}

		private int method_58(ref short short_5, string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 5;
			if (!method_10(int_, array, 1))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 1))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			short_5 = array2[0];
			return 0;
		}

		private int method_59(ref string string_0, int int_12, int int_13, string string_1, string string_2, string string_3)
		{
			int num = 0;
			byte[] array = new byte[int_13];
			int num2 = 0;
			while (true)
			{
				if (num2 < int_13)
				{
					num = method_37(ref array[num2], int_12 + num2, string_1, string_2, string_3);
					if (num != 0)
					{
						break;
					}
					num2++;
					continue;
				}
				StringBuilder stringBuilder = new StringBuilder("", int_13);
				for (num2 = 0; num2 < int_13; num2++)
				{
					stringBuilder.Append(0);
				}
				RtlMoveMemory_1(stringBuilder, array, int_13);
				string_0 = stringBuilder.ToString();
				return num;
			}
			return num;
		}

		private int method_60(string string_0, int int_12, string string_1, string string_2, string string_3)
		{
			int num = 0;
			int num2 = lstrlenA(string_0);
			byte[] array = new byte[num2];
			RtlMoveMemory(array, string_0, num2);
			int num3 = 0;
			while (true)
			{
				if (num3 < num2)
				{
					num = method_39(array[num3], int_12 + num3, string_1, string_2, string_3);
					if (num != 0)
					{
						break;
					}
					num3++;
					continue;
				}
				return num;
			}
			return num;
		}

		private int method_61(byte[] byte_23, int int_12, int int_13, string string_0, string string_1, string string_2)
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < int_13)
				{
					num = method_37(ref byte_23[num2], int_12 + num2, string_0, string_1, string_2);
					if (num != 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return num;
			}
			return num;
		}

		private int method_62(byte[] byte_23, int int_12, int int_13, string string_0, string string_1, string string_2)
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < int_13)
				{
					num = method_39(byte_23[num2], int_12 + num2, string_0, string_1, string_2);
					if (num != 0)
					{
						break;
					}
					num2++;
					continue;
				}
				return num;
			}
			return num;
		}

		public int method_63(bool bool_1, string string_0)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_64(bool_1, string_0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		private int method_64(bool bool_1, string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 85;
			if (bool_1)
			{
				array[2] = 0;
			}
			else
			{
				array[2] = byte.MaxValue;
			}
			if (!method_10(int_, array, 3))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 1))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			if (array2[0] != 0)
			{
				return -82;
			}
			return 0;
		}

		public int method_65(string string_0)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_66(string_0);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		private int method_66(string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 86;
			if (!method_10(int_, array, 3))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 1))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			if (array2[0] != 0)
			{
				return -82;
			}
			return 0;
		}

		private int method_67(int int_12, ref int int_13)
		{
			IntPtr intptr_ = IntPtr.Zero;
			GStruct6 gstruct6_ = default(GStruct6);
			if (!HidD_GetPreparsedData(int_12, ref intptr_))
			{
				return -93;
			}
			if (HidP_GetCaps(intptr_, ref gstruct6_) <= 0)
			{
				HidD_FreePreparsedData(intptr_);
				return -93;
			}
			HidD_FreePreparsedData(intptr_);
			int_13 = gstruct6_.short_4 - 5;
			return 0;
		}

		private int method_68(string string_0, ref int int_12)
		{
			int int_13 = 0;
			if (method_13(ref int_13, string_0) != 0)
			{
				return -92;
			}
			int result = method_67(int_13, ref int_12);
			CloseHandle(int_13);
			return result;
		}

		private int method_69(byte[] byte_23, byte[] byte_24, byte[] byte_25, byte[] byte_26, string string_0)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[25];
			int num = 0;
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 50;
			for (num = 0; num < 32; num++)
			{
				array[2 + num] = byte_23[num];
				array[2 + num + 32] = byte_24[num];
				array[2 + num + 64] = byte_25[num];
			}
			for (num = 0; num < 80; num++)
			{
				array[2 + num + 96] = byte_26[num];
			}
			if (!method_10(int_, array, 178))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 2))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[0] != 32)
			{
				return -50;
			}
			return 0;
		}

		private int method_70(byte[] byte_23, byte[] byte_24, string string_0)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[256];
			int num = 0;
			int int_ = 0;
			array2[0] = 251;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 55;
			if (!method_10(int_, array, 2))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 98))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[0] != 32)
			{
				return -21;
			}
			for (num = 0; num < 32; num++)
			{
				byte_23[num] = array2[1 + num];
			}
			for (num = 0; num < 65; num++)
			{
				byte_24[num] = array2[33 + num];
			}
			return 0;
		}

		private int method_71(byte[] byte_23, string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 83;
			if (!method_10(int_, array, 1))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 17))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			if (array2[0] != 32)
			{
				return -50;
			}
			for (int i = 0; i < 16; i++)
			{
				byte_23[i] = array2[1 + i];
			}
			return 0;
		}

		private int method_72(byte[] byte_23, byte[] byte_24, byte[] byte_25, string string_0)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[256];
			int num = 0;
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 51;
			if (!method_10(int_, array, 2))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 146))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[0] != 32)
			{
				return -50;
			}
			for (num = 0; num < 32; num++)
			{
				byte_23[num] = array2[1 + num];
				byte_24[num] = array2[33 + num];
			}
			for (num = 0; num < 80; num++)
			{
				byte_25[num] = array2[65 + num];
			}
			return 0;
		}

		private int method_73(string string_0, string string_1, string string_2)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[256];
			int num = 0;
			int int_ = 0;
			if (method_13(ref int_, string_2) != 0)
			{
				return -92;
			}
			array[1] = 54;
			byte[] array3 = new byte[16];
			RtlMoveMemory(array3, string_0, 16);
			byte[] array4 = new byte[16];
			RtlMoveMemory(array4, string_1, 16);
			for (num = 0; num < 16; num++)
			{
				array[2 + num] = array3[num];
				array[18 + num] = array4[num];
			}
			if (!method_10(int_, array, 34))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 2))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[0] != 32)
			{
				return -50;
			}
			if (array2[1] != 32)
			{
				return -24;
			}
			return 0;
		}

		private int method_74(byte[] byte_23, byte[] byte_24, byte byte_25, string string_0)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[256];
			int num = 0;
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 52;
			array[2] = byte_25;
			for (num = 0; num < byte_25; num++)
			{
				array[3 + num] = byte_23[num];
			}
			if (!method_10(int_, array, byte_25 + 1 + 2))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, byte_25 + 97 + 3))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[0] != 32)
			{
				return -50;
			}
			if (array2[1] == 0)
			{
				return -22;
			}
			for (num = 0; num < byte_25 + 97; num++)
			{
				byte_24[num] = array2[2 + num];
			}
			return 0;
		}

		private int method_75(byte[] byte_23, byte[] byte_24, byte byte_25, string string_0, string string_1)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[256];
			int num = 0;
			int int_ = 0;
			if (method_13(ref int_, string_1) != 0)
			{
				return -92;
			}
			array[1] = 53;
			byte[] array3 = new byte[16];
			RtlMoveMemory(array3, string_0, 16);
			for (num = 0; num < 16; num++)
			{
				array[2 + num] = array3[num];
			}
			array[18] = byte_25;
			for (num = 0; num < byte_25; num++)
			{
				array[19 + num] = byte_23[num];
			}
			if (!method_10(int_, array, byte_25 + 1 + 2 + 16))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, byte_25 - 97 + 4))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[2] != 32)
			{
				return -24;
			}
			if (array2[1] == 0)
			{
				return -22;
			}
			if (array2[0] != 32)
			{
				return -50;
			}
			for (num = 0; num < byte_25 - 97; num++)
			{
				byte_24[num] = array2[3 + num];
			}
			return 0;
		}

		private int method_76(byte[] byte_23, byte[] byte_24, string string_0, string string_1)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[256];
			int num = 0;
			int int_ = 0;
			if (method_13(ref int_, string_1) != 0)
			{
				return -92;
			}
			array[1] = 81;
			byte[] array3 = new byte[16];
			RtlMoveMemory(array3, string_0, 16);
			for (num = 0; num < 16; num++)
			{
				array[2 + num] = array3[num];
			}
			for (num = 0; num < 32; num++)
			{
				array[18 + num] = byte_23[num];
			}
			if (!method_10(int_, array, 50))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 67))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[1] != 32)
			{
				return -24;
			}
			if (array2[0] != 32)
			{
				return -50;
			}
			for (num = 0; num < 64; num++)
			{
				byte_24[num] = array2[2 + num];
			}
			return 0;
		}

		private int method_77(byte[] byte_23, byte[] byte_24, string string_0, string string_1)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[256];
			int num = 0;
			int int_ = 0;
			if (method_13(ref int_, string_1) != 0)
			{
				return -92;
			}
			array[1] = 83;
			byte[] array3 = new byte[16];
			RtlMoveMemory(array3, string_0, 16);
			for (num = 0; num < 16; num++)
			{
				array[2 + num] = array3[num];
			}
			for (num = 0; num < 32; num++)
			{
				array[18 + num] = byte_23[num];
			}
			if (!method_10(int_, array, 50))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 67))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			if (array2[1] != 32)
			{
				return -24;
			}
			if (array2[0] != 32)
			{
				return -50;
			}
			for (num = 0; num < 64; num++)
			{
				byte_24[num] = array2[2 + num];
			}
			return 0;
		}

		private int method_78(byte[] byte_23, byte[] byte_24, ref bool bool_1, string string_0)
		{
			byte[] array = new byte[256];
			byte[] array2 = new byte[256];
			int num = 0;
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 82;
			for (num = 0; num < 32; num++)
			{
				array[2 + num] = byte_23[num];
			}
			for (num = 0; num < 64; num++)
			{
				array[34 + num] = byte_24[num];
			}
			if (!method_10(int_, array, 98))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 3))
			{
				CloseHandle(int_);
				return -94;
			}
			CloseHandle(int_);
			bool_1 = (array2[1] != 0);
			if (array2[0] != 32)
			{
				return -50;
			}
			return 0;
		}

		private string method_79(byte[] byte_23, int int_12)
		{
			int num = 8;
			string text = "";
			for (int i = 0; i < int_12; i++)
			{
				text += byte_23[i].ToString("X2");
			}
			return text;
		}

		public int method_80(ref string string_0, ref string string_1, ref string string_2, string string_3)
		{
			int num = 12;
			byte[] byte_ = new byte[32];
			byte[] array = new byte[65];
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_70(byte_, array, string_3);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			string_0 = method_79(byte_, 32);
			string_1 = "";
			string_2 = "";
			for (int i = 0; i < 32; i++)
			{
				string_1 += array[i + 1].ToString("X2");
				string_2 += array[i + 1 + 32].ToString("X2");
			}
			return result;
		}

		public int method_81(string string_0, string string_1, string string_2, string string_3, string string_4)
		{
			byte[] byte_ = new byte[32];
			byte[] byte_2 = new byte[32];
			byte[] byte_3 = new byte[32];
			byte[] array = new byte[80];
			method_1(string_0, ref byte_);
			method_1(string_1, ref byte_2);
			method_1(string_2, ref byte_3);
			RtlMoveMemory(array, string_3, 80);
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_69(byte_, byte_2, byte_3, array, string_4);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		public int method_82(ref string string_0, ref string string_1, ref string string_2, string string_3)
		{
			byte[] byte_ = new byte[32];
			byte[] array = new byte[32];
			byte[] array2 = new byte[80];
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_72(byte_, array, array2, string_3);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			string_0 = method_79(byte_, 32);
			string_1 = method_79(array, 32);
			StringBuilder stringBuilder = new StringBuilder("", 80);
			RtlMoveMemory_1(stringBuilder, array2, 80);
			string_2 = stringBuilder.ToString();
			return result;
		}

		public int method_83(ref string string_0, string string_1)
		{
			byte[] byte_ = new byte[16];
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_71(byte_, string_1);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			string_0 = method_79(byte_, 16);
			return result;
		}

		public int method_84(byte[] byte_23, byte[] byte_24, int int_12, string string_0)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			byte[] array = new byte[225];
			byte[] array2 = new byte[225];
			int int_13 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_13, 65535u);
			while (int_12 > 0)
			{
				int num4 = (int_12 <= 128) ? int_12 : 128;
				for (int i = 0; i < num4; i++)
				{
					array[i] = byte_23[num2 + i];
				}
				num = method_74(array, array2, (byte)num4, string_0);
				for (int i = 0; i < num4 + 97; i++)
				{
					byte_24[num3 + i] = array2[i];
				}
				if (num != 0)
				{
					break;
				}
				int_12 -= 128;
				num2 += 128;
				num3 += 225;
			}
			ReleaseSemaphore(int_13, 1, 0);
			CloseHandle(int_13);
			return num;
		}

		public int method_85(byte[] byte_23, byte[] byte_24, int int_12, string string_0, string string_1)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			byte[] array = new byte[225];
			byte[] array2 = new byte[225];
			int int_13 = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_13, 65535u);
			while (int_12 > 0)
			{
				int num4 = (int_12 <= 225) ? int_12 : 225;
				for (int i = 0; i < num4; i++)
				{
					array[i] = byte_23[num2 + i];
				}
				num = method_75(byte_23, byte_24, (byte)num4, string_0, string_1);
				for (int i = 0; i < num4 - 97; i++)
				{
					byte_24[num3 + i] = array2[i];
				}
				if (num != 0)
				{
					break;
				}
				int_12 -= 225;
				num2 += 225;
				num3 += 128;
			}
			ReleaseSemaphore(int_13, 1, 0);
			CloseHandle(int_13);
			return num;
		}

		public int method_86(string string_0, ref string string_1, string string_2)
		{
			int num = 0;
			int num2 = 0;
			byte[] array = new byte[225];
			byte[] array2 = new byte[225];
			int num3 = lstrlenA(string_0) + 1;
			int num4 = (num3 / 128 + 1) * 97 + num3;
			byte[] array3 = new byte[num4];
			byte[] array4 = new byte[num3];
			RtlMoveMemory(array4, string_0, num3);
			int num5 = 0;
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			while (num3 > 0)
			{
				int num6 = (num3 <= 128) ? num3 : 128;
				for (int i = 0; i < num6; i++)
				{
					array[i] = array4[num + i];
				}
				num5 = method_74(array, array2, (byte)num6, string_2);
				for (int i = 0; i < num6 + 97; i++)
				{
					array3[num2 + i] = array2[i];
				}
				if (num5 != 0)
				{
					break;
				}
				num3 -= 128;
				num += 128;
				num2 += 225;
			}
			string_1 = method_79(array3, num4);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return num5;
		}

		public int method_87(string string_0, ref string string_1, string string_2, string string_3)
		{
			int num = 0;
			int num2 = 0;
			byte[] array = new byte[225];
			byte[] array2 = new byte[225];
			int num3 = lstrlenA(string_0) / 2;
			int num4 = num3 - (num3 / 225 + 1) * 97;
			byte[] byte_ = new byte[num3];
			byte[] array3 = new byte[num4];
			int num5 = 0;
			method_1(string_0, ref byte_);
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			while (num3 > 0)
			{
				int num6 = (num3 <= 225) ? num3 : 225;
				for (int i = 0; i < num6; i++)
				{
					array[i] = byte_[num + i];
				}
				num5 = method_75(array, array2, (byte)num6, string_2, string_3);
				for (int i = 0; i < num6 - 97; i++)
				{
					array3[num2 + i] = array2[i];
				}
				if (num5 != 0)
				{
					break;
				}
				num3 -= 225;
				num += 225;
				num2 += 128;
			}
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			StringBuilder stringBuilder = new StringBuilder("", num4);
			RtlMoveMemory_1(stringBuilder, array3, num4);
			string_1 = stringBuilder.ToString();
			return num5;
		}

		public int method_88(string string_0, string string_1, string string_2)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_73(string_0, string_1, string_2);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		private int method_89(byte[] byte_23, string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_0) != 0)
			{
				return -92;
			}
			array[1] = 7;
			for (int i = 2; i <= 9; i++)
			{
				array[i] = byte_23[i - 2];
			}
			if (!method_10(int_, array, 9))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 9))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			if (array2[0] != 0)
			{
				return -82;
			}
			return 0;
		}

		public int method_90(string string_0, string string_1)
		{
			int num = 15;
			byte[] byte_ = new byte[8];
			for (int i = 0; i < 8; i++)
			{
				byte_[i] = 0;
			}
			method_1(string_0, ref byte_);
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_89(byte_, string_1);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		private int method_91(ref string string_0, string string_1)
		{
			int num = 6;
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_ = 0;
			if (method_13(ref int_, string_1) != 0)
			{
				return -92;
			}
			array[1] = 15;
			if (!method_10(int_, array, 1))
			{
				CloseHandle(int_);
				return -93;
			}
			if (!method_9(int_, array2, 8))
			{
				CloseHandle(int_);
				return -93;
			}
			CloseHandle(int_);
			string_0 = "";
			for (int i = 0; i < 8; i++)
			{
				string_0 += array2[i].ToString("X2");
			}
			return 0;
		}

		public int method_92(ref string string_0, string string_1)
		{
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_91(ref string_0, string_1);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}

		public string method_93(string string_0)
		{
			string str = 2000 + method_0(string_0.Substring(0, 2)) + "年";
			str = str + method_0(string_0.Substring(2, 2)) + "月";
			str = str + method_0(string_0.Substring(4, 2)) + "日";
			str = str + method_0(string_0.Substring(6, 2)) + "时";
			str = str + method_0(string_0.Substring(8, 2)) + "分";
			str = str + method_0(string_0.Substring(10, 2)) + "秒--";
			return str + "序号：" + method_0(string_0.Substring(12, 4));
		}

		private int method_94(byte[] byte_23, int int_12, int int_13, byte[] byte_24, string string_0)
		{
			byte[] array = new byte[25];
			byte[] array2 = new byte[25];
			int int_14 = 0;
			if (int_13 > 8)
			{
				return -87;
			}
			if (method_13(ref int_14, string_0) != 0)
			{
				return -92;
			}
			array[1] = 6;
			array[2] = 0;
			array[3] = 0;
			array[4] = (byte)int_13;
			for (int i = 0; i <= 7; i++)
			{
				array[5 + i] = byte_24[i];
			}
			for (int i = 0; i < int_13; i++)
			{
				array[13 + i] = byte_23[i];
			}
			if (!method_10(int_14, array, 13 + int_13))
			{
				CloseHandle(int_14);
				return -93;
			}
			if (!method_9(int_14, array2, 2))
			{
				CloseHandle(int_14);
				return -93;
			}
			CloseHandle(int_14);
			if (array2[0] != 0)
			{
				return -82;
			}
			return 0;
		}

		public int method_95(string string_0, string string_1, string string_2, string string_3, string string_4)
		{
			byte[] array = new byte[8];
			byte[] byte_ = new byte[8];
			method_36(string_0, string_1, array);
			method_36(string_2, string_3, byte_);
			int int_ = CreateSemaphoreA(0, 1, 1, "ex_sim");
			WaitForSingleObject(int_, 65535u);
			int result = method_94(byte_, 0, 8, array, string_4);
			ReleaseSemaphore(int_, 1, 0);
			CloseHandle(int_);
			return result;
		}
	}
}
