using DCSoft.Printing;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass158
	{
		private struct Struct55
		{
			private int int_0;

			private int int_1;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct Struct56
		{
			public short short_0;

			public short short_1;

			public short short_2;

			public short short_3;

			public short short_4;

			public short short_5;

			public short short_6;

			public short short_7;
		}

		private struct Struct57
		{
			public int int_0;

			public string string_0;

			public string string_1;

			public string string_2;

			public string string_3;

			public string string_4;

			public string string_5;

			public int int_1;

			public int int_2;

			public int int_3;

			public int int_4;

			public int int_5;

			public Struct56 struct56_0;
		}

		internal struct Struct58
		{
			public string string_0;

			public string string_1;

			public string string_2;

			public string string_3;

			public string string_4;

			public string string_5;

			public string string_6;

			public IntPtr intptr_0;

			public string string_7;

			public string string_8;

			public string string_9;

			public string string_10;

			public IntPtr intptr_1;

			public uint uint_0;

			public uint uint_1;

			public uint uint_2;

			public uint uint_3;

			public uint uint_4;

			public uint uint_5;

			public uint uint_6;

			public uint uint_7;
		}

		[StructLayout(LayoutKind.Sequential)]
		[ComVisible(false)]
		public class GClass159
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string string_0;

			public short short_0;

			public short short_1;

			public short short_2;

			public short short_3;

			public int int_0;

			public short short_4;

			public short short_5;

			public short short_6;

			public short short_7;

			public short short_8;

			public short short_9;

			public short short_10;

			public short short_11;

			public short short_12;

			public short short_13;

			public short short_14;

			public short short_15;

			public short short_16;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string string_1;

			public short short_17;

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

			public int int_11;

			public int int_12;

			public int int_13;

			public override string ToString()
			{
				return "[DEVMODE: dmDeviceName=" + string_0 + ", dmSpecVersion=" + short_0 + ", dmDriverVersion=" + short_1 + ", dmSize=" + short_2 + ", dmDriverExtra=" + short_3 + ", dmFields=" + int_0 + ", dmOrientation=" + short_4 + ", dmPaperSize=" + short_5 + ", dmPaperLength=" + short_6 + ", dmPaperWidth=" + short_7 + ", dmScale=" + short_8 + ", dmCopies=" + short_9 + ", dmDefaultSource=" + short_10 + ", dmPrintQuality=" + short_11 + ", dmColor=" + short_12 + ", dmDuplex=" + short_13 + ", dmYResolution=" + short_14 + ", dmTTOption=" + short_15 + ", dmCollate=" + short_16 + ", dmFormName=" + string_1 + ", dmLogPixels=" + short_17 + ", dmBitsPerPel=" + int_1 + ", dmPelsWidth=" + int_2 + ", dmPelsHeight=" + int_3 + ", dmDisplayFlags=" + int_4 + ", dmDisplayFrequency=" + int_5 + ", dmICMMethod=" + int_6 + ", dmICMIntent=" + int_7 + ", dmMediaType=" + int_8 + ", dmDitherType=" + int_9 + ", dmICCManufacturer=" + int_10 + ", dmICCModel=" + int_11 + ", dmPanningWidth=" + int_12 + ", dmPanningHeight=" + int_13 + "]";
			}
		}

		private string string_0 = null;

		private Struct58 struct58_0 = default(Struct58);

		private GClass160 gclass160_0 = new GClass160();

		public GClass158()
		{
		}

		public GClass158(string string_1)
		{
			string_0 = string_1;
			method_6();
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1)
		{
			string_0 = string_1;
		}

		public PrinterStatus method_2()
		{
			return (PrinterStatus)struct58_0.uint_5;
		}

		public string method_3()
		{
			return struct58_0.string_0;
		}

		public string method_4()
		{
			return struct58_0.string_2;
		}

		public GClass160 method_5()
		{
			return gclass160_0;
		}

		public void method_6()
		{
			gclass160_0 = new GClass160();
			int int_ = 0;
			Win32Exception ex = null;
			if (OpenPrinter(string_0, ref int_, 0) != 0)
			{
				int int_2 = 0;
				int int_3 = 0;
				GetPrinter(int_, 2, IntPtr.Zero, 0, ref int_2);
				if (int_2 > 0)
				{
					IntPtr intPtr = Marshal.AllocHGlobal(int_2);
					if (GetPrinter(int_, 2, intPtr, int_2, ref int_2) != 0)
					{
						struct58_0 = (Struct58)Marshal.PtrToStructure(intPtr, typeof(Struct58));
					}
					Marshal.FreeHGlobal(intPtr);
				}
				int num = Marshal.SizeOf(typeof(Struct57));
				EnumJobs(int_, 0, 10000, 1, IntPtr.Zero, 0, ref int_2, ref int_3);
				if (int_2 > 0)
				{
					IntPtr intPtr2 = Marshal.AllocHGlobal(int_2);
					if (EnumJobs(int_, 0, 1000, 1, intPtr2, int_2, ref int_2, ref int_3) == 0)
					{
						Marshal.FreeHGlobal(intPtr2);
						ClosePrinter(int_);
						ex = new Win32Exception(Marshal.GetLastWin32Error());
						throw ex;
					}
					for (int i = 0; i < int_3; i++)
					{
						IntPtr intptr_ = new IntPtr((long)intPtr2 + i * num);
						PrintJob printJob = new PrintJob();
						smethod_3(printJob, intptr_);
						printJob.PrinterName = string_0;
						method_5().method_1(printJob);
					}
					Marshal.FreeHGlobal(intPtr2);
				}
				ClosePrinter(int_);
				return;
			}
			ex = new Win32Exception(Marshal.GetLastWin32Error());
			throw ex;
		}

		internal static bool smethod_0(PrintJob printJob_0, GEnum27 genum27_0, bool bool_0)
		{
			int num = 9;
			if (printJob_0 == null)
			{
				throw new ArgumentNullException("job");
			}
			int int_ = 0;
			Win32Exception ex = null;
			if (OpenPrinter(printJob_0.PrinterName, ref int_, 0) != 0)
			{
				bool result = SetJob(int_, printJob_0.JobId, 0, IntPtr.Zero, (int)genum27_0);
				if (!smethod_2(int_, printJob_0, bool_0))
				{
					result = false;
				}
				ClosePrinter(int_);
				return result;
			}
			ex = new Win32Exception(Marshal.GetLastWin32Error());
			if (bool_0)
			{
				throw ex;
			}
			return false;
		}

		internal static bool smethod_1(PrintJob printJob_0, bool bool_0)
		{
			int int_ = 0;
			Win32Exception ex = null;
			if (OpenPrinter(printJob_0.PrinterName, ref int_, 0) != 0)
			{
				return smethod_2(int_, printJob_0, bool_0);
			}
			if (bool_0)
			{
				ex = new Win32Exception(Marshal.GetLastWin32Error());
				throw ex;
			}
			return false;
		}

		private static bool smethod_2(int int_0, PrintJob printJob_0, bool bool_0)
		{
			Win32Exception ex = null;
			int int_ = 0;
			GetJob(int_0, printJob_0.JobId, 1, IntPtr.Zero, 0, ref int_);
			bool result = false;
			if (int_ > 0)
			{
				IntPtr intPtr = Marshal.AllocHGlobal(int_);
				if (GetJob(int_0, printJob_0.JobId, 1, intPtr, int_, ref int_) != 0)
				{
					smethod_3(printJob_0, intPtr);
					Marshal.FreeHGlobal(intPtr);
					result = true;
				}
				else
				{
					Marshal.FreeHGlobal(intPtr);
					ex = new Win32Exception(Marshal.GetLastWin32Error());
				}
			}
			else
			{
				ex = new Win32Exception(Marshal.GetLastWin32Error());
				if (ex.NativeErrorCode == 87)
				{
					ex = null;
				}
			}
			ClosePrinter(int_0);
			if (ex != null)
			{
				if (bool_0)
				{
					throw ex;
				}
				return false;
			}
			return result;
		}

		private static void smethod_3(PrintJob printJob_0, IntPtr intptr_0)
		{
			Struct57 @struct = (Struct57)Marshal.PtrToStructure(intptr_0, typeof(Struct57));
			printJob_0.Datatype = @struct.string_4;
			printJob_0.Document = @struct.string_3;
			printJob_0.JobId = @struct.int_0;
			printJob_0.MachineName = @struct.string_1;
			printJob_0.PagesPrinted = @struct.int_5;
			printJob_0.Position = @struct.int_3;
			printJob_0.NativePrinterName = @struct.string_0;
			printJob_0.Priority = @struct.int_2;
			printJob_0.Status = (GEnum26)@struct.int_1;
			printJob_0.StatusText = @struct.string_5;
			Struct55 struct55_ = default(Struct55);
			SystemTimeToFileTime(ref @struct.struct56_0, ref struct55_);
			Struct55 struct55_2 = default(Struct55);
			FileTimeToLocalFileTime(ref struct55_, ref struct55_2);
			Struct56 struct56_ = default(Struct56);
			FileTimeToSystemTime(ref struct55_2, ref struct56_);
			printJob_0.Submitted = new DateTime(struct56_.short_0, struct56_.short_1, struct56_.short_3, struct56_.short_4, struct56_.short_5, struct56_.short_6);
			printJob_0.TotalPages = @struct.int_4;
			printJob_0.UserName = @struct.string_2;
		}

		public override string ToString()
		{
			int num = 19;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string_0 + " " + method_5().Count);
			foreach (PrintJob item in method_5())
			{
				stringBuilder.Append(" " + item.Document);
			}
			return stringBuilder.ToString();
		}

		[DllImport("winspool.drv", SetLastError = true)]
		private static extern int OpenPrinter(string string_1, ref int int_0, int int_1);

		[DllImport("winspool.drv", SetLastError = true)]
		private static extern int GetPrinter(int int_0, int int_1, IntPtr intptr_0, int int_2, ref int int_3);

		[DllImport("winspool.drv", SetLastError = true)]
		private static extern int ClosePrinter(int int_0);

		[DllImport("winspool.drv", SetLastError = true)]
		private static extern int EnumJobs(int int_0, int int_1, int int_2, int int_3, IntPtr intptr_0, int int_4, ref int int_5, ref int int_6);

		[DllImport("winspool.drv", SetLastError = true)]
		private static extern int GetJob(int int_0, int int_1, int int_2, IntPtr intptr_0, int int_3, ref int int_4);

		[DllImport("winspool.drv", SetLastError = true)]
		private static extern bool SetJob(int int_0, int int_1, int int_2, IntPtr intptr_0, int int_3);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool FileTimeToSystemTime(ref Struct55 struct55_0, ref Struct56 struct56_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool SystemTimeToFileTime(ref Struct56 struct56_0, ref Struct55 struct55_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool FileTimeToLocalFileTime(ref Struct55 struct55_0, ref Struct55 struct55_1);
	}
}
