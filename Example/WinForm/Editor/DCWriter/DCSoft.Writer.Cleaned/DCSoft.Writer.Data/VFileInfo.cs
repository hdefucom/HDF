using DCSoft.Common;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       文件信息
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	
	[ComVisible(false)]
	[DocumentComment]
	public class VFileInfo : ICloneable
	{
		private string _Name;

		private string _Format;

		private string _FullPath;

		private string _BasePath;

		private long _Length;

		private string _Title;

		private bool _Exists;

		private DateTime _CreationTime;

		private DateTime _AccessTime;

		private bool _Readonly;

		/// <summary>
		///       文件名
		///       </summary>
		[DefaultValue(null)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;
			}
		}

		/// <summary>
		///       文件格式,可以为XML,RTF,HTML,OldXML
		///       </summary>
		[DefaultValue(null)]
		public string Format
		{
			get
			{
				return _Format;
			}
			set
			{
				_Format = value;
			}
		}

		/// <summary>
		///       全路径名
		///       </summary>
		[DefaultValue(null)]
		public string FullPath
		{
			get
			{
				return _FullPath;
			}
			set
			{
				_FullPath = value;
			}
		}

		/// <summary>
		///       基础路径
		///       </summary>
		[DefaultValue(null)]
		public string BasePath
		{
			get
			{
				return _BasePath;
			}
			set
			{
				_BasePath = value;
			}
		}

		/// <summary>
		///       文件长度
		///       </summary>
		[DefaultValue(0L)]
		public long Length
		{
			get
			{
				return _Length;
			}
			set
			{
				_Length = value;
			}
		}

		/// <summary>
		///       标题
		///       </summary>
		[DefaultValue(null)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				_Title = value;
			}
		}

		/// <summary>
		///       文件是否存在
		///       </summary>
		[DefaultValue(true)]
		public bool Exists
		{
			get
			{
				return _Exists;
			}
			set
			{
				_Exists = value;
			}
		}

		/// <summary>
		///       文件创建时间
		///       </summary>
		public DateTime CreationTime
		{
			get
			{
				return _CreationTime;
			}
			set
			{
				_CreationTime = value;
			}
		}

		/// <summary>
		///       文件访问时间
		///       </summary>
		public DateTime AccessTime
		{
			get
			{
				return _AccessTime;
			}
			set
			{
				_AccessTime = value;
			}
		}

		/// <summary>
		///       文件是只读的
		///       </summary>
		[DefaultValue(false)]
		public bool Readonly
		{
			get
			{
				return _Readonly;
			}
			set
			{
				_Readonly = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		public VFileInfo()
		{
			_Name = null;
			_Format = null;
			_FullPath = null;
			_BasePath = null;
			_Length = 0L;
			_Title = null;
			_Exists = true;
			_CreationTime = GClass117.dateTime_0;
			_AccessTime = GClass117.dateTime_0;
			_Readonly = false;
			
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="info">本地文件系统信息对象</param>
		public VFileInfo(FileInfo info)
		{
			int num = 13;
			_Name = null;
			_Format = null;
			_FullPath = null;
			_BasePath = null;
			_Length = 0L;
			_Title = null;
			_Exists = true;
			_CreationTime = GClass117.dateTime_0;
			_AccessTime = GClass117.dateTime_0;
			_Readonly = false;
			
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			Name = info.Name;
			FullPath = info.FullName;
			Exists = info.Exists;
			BasePath = Path.GetDirectoryName(info.FullName);
			if (info.Exists)
			{
				Length = info.Length;
				CreationTime = info.CreationTime;
				AccessTime = info.LastAccessTime;
				Readonly = info.IsReadOnly;
				Title = Path.GetFileName(info.Name);
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public VFileInfo Clone()
		{
			return (VFileInfo)((ICloneable)this).Clone();
		}

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}
	}
}
