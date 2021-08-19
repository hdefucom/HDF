using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass558 : ICloneable
	{
		private string string_0;

		private GClass560 gclass560_0;

		public string Name
		{
			get
			{
				return gclass560_0.Name;
			}
			set
			{
				gclass560_0.Name = value;
			}
		}

		private GClass558()
		{
			gclass560_0 = new GClass560();
		}

		public GClass558(byte[] byte_0)
		{
			gclass560_0 = new GClass560();
			gclass560_0.method_29(byte_0);
		}

		public GClass558(GClass560 gclass560_1)
		{
			int num = 19;
			
			if (gclass560_1 == null)
			{
				throw new ArgumentNullException("header");
			}
			gclass560_0 = (GClass560)gclass560_1.Clone();
		}

		public object Clone()
		{
			GClass558 gClass = new GClass558();
			gClass.string_0 = string_0;
			gClass.gclass560_0 = (GClass560)gclass560_0.Clone();
			gClass.Name = Name;
			return gClass;
		}

		public static GClass558 smethod_0(string string_1)
		{
			GClass558 gClass = new GClass558();
			smethod_3(gClass.gclass560_0, string_1);
			return gClass;
		}

		public static GClass558 smethod_1(string string_1)
		{
			GClass558 gClass = new GClass558();
			gClass.method_18(gClass.gclass560_0, string_1);
			return gClass;
		}

		public override bool Equals(object other)
		{
			GClass558 gClass = other as GClass558;
			if (gClass != null)
			{
				return Name.Equals(gClass.Name);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public bool method_0(GClass558 gclass558_0)
		{
			int num = 6;
			if (gclass558_0 == null)
			{
				throw new ArgumentNullException("toTest");
			}
			return gclass558_0.Name.StartsWith(Name);
		}

		public GClass560 method_1()
		{
			return gclass560_0;
		}

		public int method_2()
		{
			return gclass560_0.method_3();
		}

		public void method_3(int int_0)
		{
			gclass560_0.method_4(int_0);
		}

		public int method_4()
		{
			return gclass560_0.method_5();
		}

		public void method_5(int int_0)
		{
			gclass560_0.method_6(int_0);
		}

		public string method_6()
		{
			return gclass560_0.method_21();
		}

		public void method_7(string string_1)
		{
			gclass560_0.method_22(string_1);
		}

		public string method_8()
		{
			return gclass560_0.method_23();
		}

		public void method_9(string string_1)
		{
			gclass560_0.method_24(string_1);
		}

		public void method_10(int int_0, int int_1)
		{
			method_3(int_0);
			method_5(int_1);
		}

		public void method_11(string string_1, string string_2)
		{
			method_7(string_1);
			method_9(string_2);
		}

		public DateTime method_12()
		{
			return gclass560_0.method_9();
		}

		public void method_13(DateTime dateTime_0)
		{
			gclass560_0.method_10(dateTime_0);
		}

		public string method_14()
		{
			return string_0;
		}

		public long method_15()
		{
			return gclass560_0.method_7();
		}

		public void method_16(long long_0)
		{
			gclass560_0.method_8(long_0);
		}

		public bool method_17()
		{
			int num = 10;
			if (string_0 != null)
			{
				return Directory.Exists(string_0);
			}
			if (gclass560_0 != null && (gclass560_0.method_13() == 53 || Name.EndsWith("/")))
			{
				return true;
			}
			return false;
		}

		public void method_18(GClass560 gclass560_1, string string_1)
		{
			int num = 18;
			if (gclass560_1 == null)
			{
				throw new ArgumentNullException("header");
			}
			if (string_1 == null)
			{
				throw new ArgumentNullException("file");
			}
			string_0 = string_1;
			string text = string_1;
			if (text.IndexOf(Environment.CurrentDirectory) == 0)
			{
				text = text.Substring(Environment.CurrentDirectory.Length);
			}
			text = text.Replace(Path.DirectorySeparatorChar, '/');
			while (text.StartsWith("/"))
			{
				text = text.Substring(1);
			}
			gclass560_1.method_16(string.Empty);
			gclass560_1.Name = text;
			if (Directory.Exists(string_1))
			{
				gclass560_1.method_2(1003);
				gclass560_1.method_14(53);
				if (gclass560_1.Name.Length == 0 || gclass560_1.Name[gclass560_1.Name.Length - 1] != '/')
				{
					gclass560_1.Name += "/";
				}
				gclass560_1.method_8(0L);
			}
			else
			{
				gclass560_1.method_2(33216);
				gclass560_1.method_14(48);
				gclass560_1.method_8(new FileInfo(string_1.Replace('/', Path.DirectorySeparatorChar)).Length);
			}
			gclass560_1.method_10(File.GetLastWriteTime(string_1.Replace('/', Path.DirectorySeparatorChar)).ToUniversalTime());
			gclass560_1.method_26(0);
			gclass560_1.method_28(0);
		}

		public GClass558[] method_19()
		{
			if (string_0 == null || !Directory.Exists(string_0))
			{
				return new GClass558[0];
			}
			string[] fileSystemEntries = Directory.GetFileSystemEntries(string_0);
			GClass558[] array = new GClass558[fileSystemEntries.Length];
			for (int i = 0; i < fileSystemEntries.Length; i++)
			{
				array[i] = smethod_1(fileSystemEntries[i]);
			}
			return array;
		}

		public void method_20(byte[] byte_0)
		{
			gclass560_0.method_30(byte_0);
		}

		public static void smethod_2(byte[] byte_0, string string_1)
		{
			GClass560.smethod_7(string_1, byte_0, 0, 100);
		}

		public static void smethod_3(GClass560 gclass560_1, string string_1)
		{
			int num = 8;
			if (gclass560_1 == null)
			{
				throw new ArgumentNullException("header");
			}
			if (string_1 == null)
			{
				throw new ArgumentNullException("name");
			}
			bool flag = string_1.EndsWith("/");
			gclass560_1.Name = string_1;
			gclass560_1.method_2(flag ? 1003 : 33216);
			gclass560_1.method_4(0);
			gclass560_1.method_6(0);
			gclass560_1.method_8(0L);
			gclass560_1.method_10(DateTime.UtcNow);
			gclass560_1.method_14((byte)(flag ? 53 : 48));
			gclass560_1.method_16(string.Empty);
			gclass560_1.method_22(string.Empty);
			gclass560_1.method_24(string.Empty);
			gclass560_1.method_26(0);
			gclass560_1.method_28(0);
		}
	}
}
