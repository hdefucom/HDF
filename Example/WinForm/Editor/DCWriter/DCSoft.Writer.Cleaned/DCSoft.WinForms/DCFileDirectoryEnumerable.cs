using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms
{
	/// <summary>
	///        文件或目录遍历器,本类型为 FileDirectoryEnumerator 的一个包装
	///        </summary>
	/// <remarks>
	///
	///        编写 袁永福 （ http://www.xdesigner.cn ）2006-12-8
	///
	///        以下代码演示使用这个文件目录遍历器
	///
	///        FileDirectoryEnumerable e = new FileDirectoryEnumerable();
	///        e.SearchPath = @"c:\";
	///        e.ReturnStringType = true ;
	///        e.SearchPattern = "*.exe";
	///        e.SearchDirectory = false ;
	///        e.SearchFile = true;
	///        foreach (object name in e)
	///        {
	///            System.Console.WriteLine(name);
	///        }
	///        System.Console.ReadLine();
	///
	///       </remarks>
	[ComVisible(false)]
	public class DCFileDirectoryEnumerable : IEnumerable, IDisposable
	{
		private bool bool_0 = true;

		private string string_0 = "*";

		private string string_1 = null;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private ArrayList arrayList_0 = new ArrayList();

		/// <summary>
		///       是否以字符串方式返回查询结果,若返回true则当前对象返回为字符串,
		///       否则返回 System.IO.FileInfo或System.IO.DirectoryInfo类型
		///       </summary>
		public bool ReturnStringType
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		/// <summary>
		///       文件或目录名的通配符
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
		///       搜索路径,必须为绝对路径
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
				return bool_1;
			}
			set
			{
				bool_1 = value;
			}
		}

		/// <summary>
		///       是否查找子目录
		///       </summary>
		public bool SearchForDirectory
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
		///       发生IO错误时是否抛出异常
		///       </summary>
		public bool ThrowIOException
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

		public DCFileDirectoryEnumerable()
		{
		}

		public DCFileDirectoryEnumerable(string string_2, string string_3)
		{
			SearchPath = string_2;
			SearchPattern = string_3;
		}

		/// <summary>
		///       返回内置的文件和目录遍历器
		///       </summary>
		/// <returns>遍历器对象</returns>
		public IEnumerator GetEnumerator()
		{
			DCFileDirectoryEnumerator dCFileDirectoryEnumerator = new DCFileDirectoryEnumerator();
			dCFileDirectoryEnumerator.ReturnStringType = bool_0;
			dCFileDirectoryEnumerator.SearchForDirectory = bool_2;
			dCFileDirectoryEnumerator.SearchForFile = bool_1;
			dCFileDirectoryEnumerator.SearchPath = string_1;
			dCFileDirectoryEnumerator.SearchPattern = string_0;
			dCFileDirectoryEnumerator.ThrowIOException = bool_3;
			arrayList_0.Add(dCFileDirectoryEnumerator);
			return dCFileDirectoryEnumerator;
		}

		/// <summary>
		///       销毁对象
		///       </summary>
		public void Dispose()
		{
			foreach (DCFileDirectoryEnumerator item in arrayList_0)
			{
				item.Dispose();
			}
			arrayList_0.Clear();
		}
	}
}
