using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       保存文件内容事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IWriterSaveFileContentEventArgs))]
	[ComClass("63EAC939-B4AF-47C3-AB44-5634B299121A", "45B150B5-AE4F-4809-9AC4-32766FDEC5B3")]
	[Guid("63EAC939-B4AF-47C3-AB44-5634B299121A")]
	
	
	[ComVisible(true)]
	public class WriterSaveFileContentEventArgs : WriterEventArgs, IWriterSaveFileContentEventArgs
	{
		internal new const string CLASSID = "63EAC939-B4AF-47C3-AB44-5634B299121A";

		internal new const string CLASSID_Interface = "45B150B5-AE4F-4809-9AC4-32766FDEC5B3";

		private string _UserParameter = null;

		[NonSerialized]
		private WriterAppHost _AppHost = WriterAppHost.Default;

		private string _FileName = null;

		private string _FileSystemName = null;

		[NonSerialized]
		private IFileSystem _FileSystem = null;

		private byte[] _BinaryContentToSave = null;

		private string _FileFormat = null;

		private bool _Result = false;

		private bool _Handled = false;

		/// <summary>
		///       用户参数
		///       </summary>
		
		public string UserParameter
		{
			get
			{
				return _UserParameter;
			}
			set
			{
				_UserParameter = value;
			}
		}

		/// <summary>
		///       编辑器宿主对象
		///       </summary>
		
		[XmlIgnore]
		public WriterAppHost AppHost
		{
			get
			{
				return _AppHost;
			}
			internal set
			{
				_AppHost = value;
			}
		}

		/// <summary>
		///       文件名
		///       </summary>
		
		[DefaultValue(null)]
		[XmlElement]
		public string FileName
		{
			get
			{
				return _FileName;
			}
			set
			{
				_FileName = value;
			}
		}

		/// <summary>
		///       文件系统名称
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		public string FileSystemName
		{
			get
			{
				return _FileSystemName;
			}
			set
			{
				_FileSystemName = value;
			}
		}

		/// <summary>
		///       指定的虚拟文件系统对象
		///       </summary>
		[XmlIgnore]
		public IFileSystem FileSystem
		{
			get
			{
				return _FileSystem;
			}
			set
			{
				_FileSystem = value;
			}
		}

		/// <summary>
		///       要保存的二进制数据
		///       </summary>
		[XmlIgnore]
		[ComVisible(false)]
		
		public byte[] BinaryContentToSave
		{
			get
			{
				return _BinaryContentToSave;
			}
			set
			{
				_BinaryContentToSave = value;
			}
		}

		/// <summary>
		///       要保存的BASE64格式的二进制数据
		///       </summary>
		[XmlElement]
		
		public string Base64ContentToSave
		{
			get
			{
				if (_BinaryContentToSave == null || _BinaryContentToSave.Length == 0)
				{
					return null;
				}
				return Convert.ToBase64String(_BinaryContentToSave);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_BinaryContentToSave = null;
				}
				else
				{
					_BinaryContentToSave = Convert.FromBase64String(value);
				}
			}
		}

		/// <summary>
		///       文件格式
		///       </summary>
		[DefaultValue(null)]
		[XmlElement]
		
		public string FileFormat
		{
			get
			{
				return _FileFormat;
			}
			set
			{
				_FileFormat = value;
			}
		}

		/// <summary>
		///       操作是否成功
		///        </summary>
		
		[DefaultValue(false)]
		[XmlElement]
		public bool Result
		{
			get
			{
				return _Result;
			}
			set
			{
				_Result = value;
			}
		}

		/// <summary>
		///       事件已经处理， 无需后续处理
		///       </summary>
		
		[DefaultValue(false)]
		[XmlElement]
		public bool Handled
		{
			get
			{
				return _Handled;
			}
			set
			{
				_Handled = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">相关的文档元素对象</param>
		/// <param name="fileName">文件名</param>
		/// <param name="fileSystemName">文件系统名称</param>
		
		public WriterSaveFileContentEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, string fileName, string fileSystemName, byte[] content)
			: base(writerControl_0, document, element)
		{
			_FileName = fileName;
			_FileSystemName = fileSystemName;
			_BinaryContentToSave = content;
			if (writerControl_0 != null)
			{
				_AppHost = writerControl_0.AppHost;
			}
			else if (document != null)
			{
				_AppHost = document.AppHost;
			}
		}
	}
}
