using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass381
	{
		private class Class200
		{
			public string string_0 = null;

			public Assembly assembly_0 = null;

			public byte[] byte_0 = null;

			public DateTime dateTime_0 = DateTime.Now;

			public DateTime dateTime_1 = DateTime.Now;

			public int int_0 = 0;

			public int int_1 = 0;

			public bool bool_0 = false;
		}

		private AppDomain appDomain_0 = AppDomain.CurrentDomain;

		private string string_0 = null;

		private int int_0 = 5120000;

		private MD5CryptoServiceProvider md5CryptoServiceProvider_0 = new MD5CryptoServiceProvider();

		private ArrayList arrayList_0 = new ArrayList();

		public static GClass381 smethod_0()
		{
			try
			{
				return new GClass381();
			}
			catch
			{
				return null;
			}
		}

		private GClass381()
		{
			string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DCSoftScriptAssemblyBuffer");
		}

		public AppDomain method_0()
		{
			return appDomain_0;
		}

		public void method_1(AppDomain appDomain_1)
		{
			appDomain_0 = appDomain_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_1)
		{
			string_0 = string_1;
		}

		public int method_4()
		{
			return int_0;
		}

		public void method_5(int int_1)
		{
			int_0 = int_1;
		}

		private string method_6(string string_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(string_1);
			bytes = md5CryptoServiceProvider_0.ComputeHash(bytes);
			return Convert.ToBase64String(bytes);
		}

		public void method_7(string string_1, Assembly assembly_0, byte[] byte_0)
		{
			Class200 @class = new Class200();
			@class.string_0 = method_6(string_1);
			@class.assembly_0 = assembly_0;
			@class.byte_0 = byte_0;
			@class.int_1 = 1;
			arrayList_0.Add(@class);
			method_11();
		}

		public void method_8()
		{
			arrayList_0.Clear();
		}

		public void method_9()
		{
			foreach (Class200 item in arrayList_0)
			{
				if (!item.bool_0 && item.byte_0 != null && item.byte_0.Length > 0)
				{
					vmethod_1(item.string_0, item.byte_0);
				}
			}
		}

		public Assembly method_10(string string_1)
		{
			string text = method_6(string_1);
			foreach (Class200 item in arrayList_0)
			{
				if (item.string_0 == text)
				{
					item.int_1++;
					item.dateTime_1 = DateTime.Now;
					return item.assembly_0;
				}
			}
			byte[] array = vmethod_0(text);
			if (array != null)
			{
				Class200 class2 = new Class200();
				class2.string_0 = text;
				class2.byte_0 = array;
				class2.assembly_0 = appDomain_0.Load(array);
				class2.bool_0 = true;
				class2.int_0 = array.Length;
				arrayList_0.Add(class2);
				method_11();
				return class2.assembly_0;
			}
			return null;
		}

		private void method_11()
		{
			if (int_0 <= 0)
			{
				return;
			}
			while (arrayList_0.Count > 1)
			{
				int num = 0;
				foreach (Class200 item in arrayList_0)
				{
					num += item.int_0;
				}
				if (num > int_0)
				{
					Class200 class2 = null;
					foreach (Class200 item2 in arrayList_0)
					{
						if (class2 == null)
						{
							class2 = item2;
						}
						else if (class2.dateTime_1 > item2.dateTime_1)
						{
							class2 = item2;
						}
					}
					arrayList_0.Remove(class2);
					if (string_0 != null && Path.IsPathRooted(string_0) && !class2.bool_0 && class2.byte_0 != null && class2.byte_0.Length > 0)
					{
						vmethod_1(class2.string_0, class2.byte_0);
					}
					continue;
				}
				break;
			}
		}

		public virtual byte[] vmethod_0(string string_1)
		{
			if (string_0 != null && Path.IsPathRooted(string_0))
			{
				string path = Path.Combine(string_0, string_1);
				if (File.Exists(path))
				{
					byte[] array = null;
					using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
					{
						array = new byte[fileStream.Length];
						fileStream.Read(array, 0, array.Length);
					}
					return array;
				}
			}
			return null;
		}

		public virtual void vmethod_1(string string_1, byte[] byte_0)
		{
			if (string_0 != null && Path.IsPathRooted(string_0))
			{
				if (!Directory.Exists(string_0))
				{
					Directory.CreateDirectory(string_0);
				}
				using (FileStream fileStream = new FileStream(Path.Combine(string_0, string_1), FileMode.Create, FileAccess.Write))
				{
					fileStream.Write(byte_0, 0, byte_0.Length);
				}
			}
		}
	}
}
