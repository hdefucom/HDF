using DCSoft.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       文件系统列表对象
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	[DCInternal]
	public class FileSystemDictionary : Dictionary<string, IFileSystem>
	{
		/// <summary>
		///       打开和保存文档使用的文件系统
		///       </summary>
		public IFileSystem Docuemnt
		{
			get
			{
				return GetFileSystem("document", strictMatchName: false);
			}
			set
			{
				base["document"] = value;
			}
		}

		/// <summary>
		///       打开和保存模板使用的文件系统
		///       </summary>
		public IFileSystem Template
		{
			get
			{
				return GetFileSystem("template", strictMatchName: false);
			}
			set
			{
				base["template"] = value;
			}
		}

		/// <summary>
		///       打开和保存知识库使用的文件系统
		///       </summary>
		public IFileSystem KBLibray
		{
			get
			{
				return GetFileSystem("kblibrary", strictMatchName: false);
			}
			set
			{
				base["kblibrary"] = value;
			}
		}

		/// <summary>
		///       加载知识节点列表项目使用的文件系统
		///       </summary>
		public IFileSystem KBListItem
		{
			get
			{
				return GetFileSystem("kblistitem", strictMatchName: false);
			}
			set
			{
				base["kblistitem"] = value;
			}
		}

		/// <summary>
		///       默认文件系统，如其他专用的文件系统为空则转而使用默认文件系统。
		///       </summary>
		public IFileSystem Default
		{
			get
			{
				return GetFileSystem("default", strictMatchName: false);
			}
			set
			{
				base["default"] = value;
			}
		}

		/// <summary>
		///       获得指定名称的文件系统,本函数能确保不返回空引用
		///       </summary>
		/// <remarks>
		///       本方法首先区分大小写的查找名称，若没找到则使用不区分大小写的查找，
		///       若还没找到则返回默认名称default的项目，若还没找到则返回默认的标准文件系统对象。
		///       </remarks>
		/// <param name="name">指定的名称</param>
		/// <returns>获得的文件系统</returns>
		public IFileSystem GetFileSystem(string name)
		{
			return GetFileSystem(name, strictMatchName: false);
		}

		/// <summary>
		///       获得指定名称的文件系统,本函数能确保不返回空引用
		///       </summary>
		/// <remarks>
		///       本方法首先区分大小写的查找名称，若没找到则使用不区分大小写的查找，
		///       若还没找到则返回默认名称default的项目，若还没找到则返回默认的标准文件系统对象。
		///       </remarks>
		/// <param name="name">指定的名称</param>
		/// <param name="strictMatchName">严格的命中名称</param>
		/// <returns>获得的文件系统</returns>
		public IFileSystem GetFileSystem(string name, bool strictMatchName)
		{
			int num = 5;
			IFileSystem fileSystem = null;
			if (!string.IsNullOrEmpty(name))
			{
				if (ContainsKey(name))
				{
					fileSystem = base[name];
				}
				if (fileSystem == null && !strictMatchName)
				{
					foreach (string key in base.Keys)
					{
						if (string.Compare(key, name, ignoreCase: true) == 0)
						{
							fileSystem = base[key];
							break;
						}
					}
				}
			}
			if (fileSystem == null)
			{
				foreach (string key2 in base.Keys)
				{
					if (string.Compare(key2, "default", ignoreCase: true) == 0)
					{
						fileSystem = base[key2];
						break;
					}
				}
			}
			return fileSystem;
		}
	}
}
