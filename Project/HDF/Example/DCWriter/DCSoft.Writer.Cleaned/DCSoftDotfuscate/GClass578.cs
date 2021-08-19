using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass578 : GInterface27
	{
		[ComVisible(false)]
		public enum GEnum102
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6
		}

		private GInterface26 ginterface26_0;

		private DateTime dateTime_0 = DateTime.Now;

		private GEnum102 genum102_0;

		private bool bool_0;

		private int int_0 = -1;

		private int int_1;

		public GClass578()
		{
			ginterface26_0 = new GClass580();
		}

		public GClass578(GEnum102 genum102_1)
		{
			genum102_0 = genum102_1;
			ginterface26_0 = new GClass580();
		}

		public GClass578(DateTime dateTime_1)
		{
			genum102_0 = GEnum102.const_6;
			method_3(dateTime_1);
			ginterface26_0 = new GClass580();
		}

		public GInterface26 imethod_4()
		{
			return ginterface26_0;
		}

		public void imethod_5(GInterface26 ginterface26_1)
		{
			if (ginterface26_1 == null)
			{
				ginterface26_0 = new GClass580();
			}
			else
			{
				ginterface26_0 = ginterface26_1;
			}
		}

		public GEnum102 method_0()
		{
			return genum102_0;
		}

		public void method_1(GEnum102 genum102_1)
		{
			genum102_0 = genum102_1;
		}

		public DateTime method_2()
		{
			return dateTime_0;
		}

		public void method_3(DateTime dateTime_1)
		{
			int num = 7;
			if (dateTime_1.Year < 1970)
			{
				throw new ArgumentException("Value is too old to be valid", "value");
			}
			dateTime_0 = dateTime_1;
		}

		public int method_4()
		{
			return int_0;
		}

		public void method_5(int int_2)
		{
			int_0 = int_2;
		}

		public int method_6()
		{
			return int_1;
		}

		public void method_7(int int_2)
		{
			int_1 = int_2;
		}

		public bool method_8()
		{
			return bool_0;
		}

		public void method_9(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public GClass577 imethod_0(string string_0)
		{
			return imethod_1(string_0, bool_1: true);
		}

		public GClass577 imethod_1(string string_0, bool bool_1)
		{
			int num = 19;
			GClass577 gClass = new GClass577(ginterface26_0.imethod_0(string_0));
			gClass.method_4(bool_0);
			int num2 = 0;
			bool flag = int_1 != 0;
			FileInfo fileInfo = null;
			if (bool_1)
			{
				fileInfo = new FileInfo(string_0);
			}
			if (fileInfo != null && fileInfo.Exists)
			{
				switch (genum102_0)
				{
				default:
					throw new GException24("Unhandled time setting in MakeFileEntry");
				case GEnum102.const_0:
					gClass.method_29(fileInfo.LastWriteTime);
					break;
				case GEnum102.const_1:
					gClass.method_29(fileInfo.LastWriteTimeUtc);
					break;
				case GEnum102.const_2:
					gClass.method_29(fileInfo.CreationTime);
					break;
				case GEnum102.const_3:
					gClass.method_29(fileInfo.CreationTimeUtc);
					break;
				case GEnum102.const_4:
					gClass.method_29(fileInfo.LastAccessTime);
					break;
				case GEnum102.const_5:
					gClass.method_29(fileInfo.LastAccessTimeUtc);
					break;
				case GEnum102.const_6:
					gClass.method_29(dateTime_0);
					break;
				}
				gClass.method_31(fileInfo.Length);
				flag = true;
				num2 = ((int)fileInfo.Attributes & int_0);
			}
			else if (genum102_0 == GEnum102.const_6)
			{
				gClass.method_29(dateTime_0);
			}
			if (flag)
			{
				num2 |= int_1;
				gClass.method_14(num2);
			}
			return gClass;
		}

		public GClass577 imethod_2(string string_0)
		{
			return imethod_3(string_0, bool_1: true);
		}

		public GClass577 imethod_3(string string_0, bool bool_1)
		{
			int num = 4;
			GClass577 gClass = new GClass577(ginterface26_0.imethod_1(string_0));
			gClass.method_4(bool_0);
			gClass.method_31(0L);
			int num2 = 0;
			DirectoryInfo directoryInfo = null;
			if (bool_1)
			{
				directoryInfo = new DirectoryInfo(string_0);
			}
			if (directoryInfo != null && directoryInfo.Exists)
			{
				switch (genum102_0)
				{
				default:
					throw new GException24("Unhandled time setting in MakeDirectoryEntry");
				case GEnum102.const_0:
					gClass.method_29(directoryInfo.LastWriteTime);
					break;
				case GEnum102.const_1:
					gClass.method_29(directoryInfo.LastWriteTimeUtc);
					break;
				case GEnum102.const_2:
					gClass.method_29(directoryInfo.CreationTime);
					break;
				case GEnum102.const_3:
					gClass.method_29(directoryInfo.CreationTimeUtc);
					break;
				case GEnum102.const_4:
					gClass.method_29(directoryInfo.LastAccessTime);
					break;
				case GEnum102.const_5:
					gClass.method_29(directoryInfo.LastAccessTimeUtc);
					break;
				case GEnum102.const_6:
					gClass.method_29(dateTime_0);
					break;
				}
				num2 = ((int)directoryInfo.Attributes & int_0);
			}
			else if (genum102_0 == GEnum102.const_6)
			{
				gClass.method_29(dateTime_0);
			}
			num2 |= (int_1 | 0x10);
			gClass.method_14(num2);
			return gClass;
		}
	}
}
