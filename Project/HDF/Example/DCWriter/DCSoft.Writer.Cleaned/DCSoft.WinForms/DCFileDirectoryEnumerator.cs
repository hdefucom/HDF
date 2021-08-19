using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms
{
	/// <summary>
	///       文件和目录的遍历器
	///       </summary>
	/// <remarks>本对象为Win32API函数 FindFirstFile , FindNextFile 
	///       和 FindClose 的一个包装
	///
	///       以下代码演示使用了 FileDirectoryEnumerator 
	///
	///       FileDirectoryEnumerator e = new FileDirectoryEnumerator();
	///       e.SearchPath = @"c:\";
	///       e.Reset();
	///       e.ReturnStringType = true ;
	///       while (e.MoveNext())
	///       {
	///           System.Console.WriteLine
	///               ( e.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss")
	///               + "   " + e.FileLength + "  \t" + e.Name );
	///       }
	///       e.Close();
	///       System.Console.ReadLine();
	///
	///       编写 袁永福 （ http://www.xdesigner.cn ）2006-12-8</remarks>
	[ComVisible(false)]
	public class DCFileDirectoryEnumerator : IDisposable, IEnumerator
	{
		[Serializable]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[ComVisible(false)]
		[BestFitMapping(false)]
		private struct WIN32_FIND_DATA
		{
			public int dwFileAttributes;

			public int ftCreationTime_dwLowDateTime;

			public int ftCreationTime_dwHighDateTime;

			public int ftLastAccessTime_dwLowDateTime;

			public int ftLastAccessTime_dwHighDateTime;

			public int ftLastWriteTime_dwLowDateTime;

			public int ftLastWriteTime_dwHighDateTime;

			public int nFileSizeHigh;

			public int nFileSizeLow;

			public int dwReserved0;

			public int dwReserved1;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string cFileName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string cAlternateFileName;
		}

		private object object_0 = null;

		private bool bool_0 = false;

		private int int_0 = 0;

		private bool bool_1 = true;

		private int int_1 = 0;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private string string_0 = "*";

		private string string_1 = null;

		private bool bool_4 = true;

		private bool bool_5 = true;

		private static readonly IntPtr intptr_0 = new IntPtr(-1);

		private IntPtr intptr_1 = intptr_0;

		private WIN32_FIND_DATA win32_FIND_DATA_0 = default(WIN32_FIND_DATA);

		private bool bool_6 = false;

		/// <summary>
		///       该目录为空
		///       </summary>
		public bool IsEmpty => bool_0;

		/// <summary>
		///       已找到的对象的个数
		///       </summary>
		public int SearchedCount => int_0;

		/// <summary>
		///       当前对象是否为文件,若为true则当前对象为文件,否则为目录
		///       </summary>
		public bool IsFile => bool_1;

		/// <summary>
		///       最后一次操作的Win32错误代码
		///       </summary>
		public int LastErrorCode => int_1;

		/// <summary>
		///       当前对象的名称
		///       </summary>
		public string Name
		{
			get
			{
				if (object_0 != null)
				{
					if (object_0 is string)
					{
						return (string)object_0;
					}
					return ((FileSystemInfo)object_0).Name;
				}
				return null;
			}
		}

		/// <summary>
		///       当前对象属性
		///       </summary>
		public FileAttributes Attributes => (FileAttributes)win32_FIND_DATA_0.dwFileAttributes;

		/// <summary>
		///       当前对象创建时间
		///       </summary>
		public DateTime CreationTime
		{
			get
			{
				long fileTime = smethod_0(win32_FIND_DATA_0.ftCreationTime_dwHighDateTime, win32_FIND_DATA_0.ftCreationTime_dwLowDateTime);
				return DateTime.FromFileTimeUtc(fileTime).ToLocalTime();
			}
		}

		/// <summary>
		///       当前对象最后访问时间
		///       </summary>
		public DateTime LastAccessTime
		{
			get
			{
				long fileTime = smethod_0(win32_FIND_DATA_0.ftLastAccessTime_dwHighDateTime, win32_FIND_DATA_0.ftLastAccessTime_dwLowDateTime);
				return DateTime.FromFileTimeUtc(fileTime).ToLocalTime();
			}
		}

		/// <summary>
		///       当前对象最后保存时间
		///       </summary>
		public DateTime LastWriteTime
		{
			get
			{
				long fileTime = smethod_0(win32_FIND_DATA_0.ftLastWriteTime_dwHighDateTime, win32_FIND_DATA_0.ftLastWriteTime_dwLowDateTime);
				return DateTime.FromFileTimeUtc(fileTime).ToLocalTime();
			}
		}

		/// <summary>
		///       当前文件长度,若为当前对象为文件则返回文件长度,若当前对象为目录则返回0
		///       </summary>
		public long FileLength
		{
			get
			{
				if (bool_1)
				{
					return smethod_0(win32_FIND_DATA_0.nFileSizeHigh, win32_FIND_DATA_0.nFileSizeLow);
				}
				return 0L;
			}
		}

		/// <summary>
		///       发生IO错误时是否抛出异常
		///       </summary>
		public bool ThrowIOException
		{
			get
			{
				return bool_2;
			}
			set
			{
				bool_2 = value;
			}
		}

		/// <summary>
		///       是否以字符串方式返回查询结果,若返回true则当前对象返回为字符串,
		///       否则返回 System.IO.FileInfo或System.IO.DirectoryInfo类型
		///       </summary>
		public bool ReturnStringType
		{
			get
			{
				return bool_3;
			}
			set
			{
				bool_3 = value;
			}
		}

		/// <summary>
		///       要匹配的文件或目录名,支持通配符
		///       </summary>
		public string SearchPattern
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		/// <summary>
		///       搜索的父目录,必须为绝对路径,不得有通配符,该目录必须存在
		///       </summary>
		public string SearchPath
		{
			get
			{
				return string_1;
			}
			set
			{
				string_1 = value;
			}
		}

		/// <summary>
		///       是否查找文件
		///       </summary>
		public bool SearchForFile
		{
			get
			{
				return bool_4;
			}
			set
			{
				bool_4 = value;
			}
		}

		/// <summary>
		///       是否查找子目录
		///       </summary>
		public bool SearchForDirectory
		{
			get
			{
				return bool_5;
			}
			set
			{
				bool_5 = value;
			}
		}

		/// <summary>
		///       返回当前对象
		///       </summary>
		public object Current => object_0;

		/// <summary>
		///       找到下一个文件或目录
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool MoveNext()
		{
			bool flag = false;
			while (bool_6 ? method_2() : method_1())
			{
				if (method_3())
				{
					return true;
				}
			}
			object_0 = null;
			return false;
		}

		/// <summary>
		///       重新设置对象
		///       </summary>
		public void Reset()
		{
			int num = 17;
			if (string.IsNullOrEmpty(string_1))
			{
				throw new ArgumentNullException("SearchPath can not null");
			}
			if (string_0 == null || string_0.Length == 0)
			{
				string_0 = "*";
			}
			int_0 = 0;
			object_0 = null;
			method_0();
			bool_6 = false;
			bool_0 = false;
			int_1 = 0;
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr FindFirstFile(string pFileName, ref WIN32_FIND_DATA pFindFileData);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool FindNextFile(IntPtr hndFindFile, ref WIN32_FIND_DATA lpFindFileData);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool FindClose(IntPtr hndFindFile);

		private static long smethod_0(int int_2, int int_3)
		{
			long num = (uint)int_2;
			num <<= 32;
			return num | (uint)int_3;
		}

		private static void smethod_1(int int_2, string string_2)
		{
			int num = 13;
			switch (int_2)
			{
			case 32:
				throw new IOException("IO_SharingViolation:" + string_2);
			case 2:
				throw new FileNotFoundException("FileNotFound:" + string_2);
			case 3:
				throw new DirectoryNotFoundException("PathNotFound:" + string_2);
			case 5:
				throw new UnauthorizedAccessException("UnauthorizedAccess:" + string_2);
			default:
				throw new IOException("IOError:" + smethod_2(int_2));
			case 206:
				throw new PathTooLongException("PathTooLong:" + string_2);
			case 87:
				throw new IOException("IOError:" + smethod_2(int_2));
			case 80:
				throw new IOException("IO_FileExists :" + string_2);
			}
		}

		private static int smethod_2(int int_2)
		{
			return -2147024896 | int_2;
		}

		private void method_0()
		{
			if (intptr_1 != intptr_0)
			{
				FindClose(intptr_1);
				intptr_1 = intptr_0;
			}
		}

		private bool method_1()
		{
			bool_6 = true;
			bool_0 = false;
			object_0 = null;
			int_1 = 0;
			string pFileName = Path.Combine(string_1, string_0);
			method_0();
			intptr_1 = FindFirstFile(pFileName, ref win32_FIND_DATA_0);
			if (intptr_1 == intptr_0)
			{
				int_1 = Marshal.GetLastWin32Error();
				if (int_1 == 2)
				{
					bool_0 = true;
					return false;
				}
				if (!bool_2)
				{
					return false;
				}
				smethod_1(int_1, string_1);
			}
			return true;
		}

		private bool method_2()
		{
			if (!bool_6)
			{
				return false;
			}
			if (bool_0)
			{
				return false;
			}
			if (intptr_1 == intptr_0)
			{
				return false;
			}
			int_1 = 0;
			if (!FindNextFile(intptr_1, ref win32_FIND_DATA_0))
			{
				int_1 = Marshal.GetLastWin32Error();
				method_0();
				if (int_1 != 0 && int_1 != 18)
				{
					if (!bool_2)
					{
						return false;
					}
					smethod_1(int_1, string_1);
				}
				return false;
			}
			return true;
		}

		private bool method_3()
		{
			int num = 3;
			if (intptr_1 == intptr_0)
			{
				return false;
			}
			bool flag = false;
			object_0 = null;
			if ((win32_FIND_DATA_0.dwFileAttributes & 0x10) == 0)
			{
				bool_1 = true;
				if (bool_4)
				{
					flag = true;
				}
			}
			else
			{
				bool_1 = false;
				if (bool_5)
				{
					flag = ((!(win32_FIND_DATA_0.cFileName == ".") && !(win32_FIND_DATA_0.cFileName == "..")) ? true : false);
				}
			}
			if (flag)
			{
				if (bool_3)
				{
					object_0 = win32_FIND_DATA_0.cFileName;
				}
				else
				{
					string text = Path.Combine(string_1, win32_FIND_DATA_0.cFileName);
					if (bool_1)
					{
						object_0 = new FileInfo(text);
					}
					else
					{
						object_0 = new DirectoryInfo(text);
					}
				}
				int_0++;
			}
			return flag;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			method_0();
		}
	}
}
