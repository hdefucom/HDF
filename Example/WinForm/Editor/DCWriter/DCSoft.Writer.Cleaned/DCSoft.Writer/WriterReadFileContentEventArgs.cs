using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       读取文件内容事件参数
	///       </summary>
	[DocumentComment]
	[ComClass("F833B59C-C3B4-4E36-97C5-0F1AA9433419", "6ACA5A24-7F1F-430A-B028-6DF89C54A4A7")]
	
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IWriterReadFileContentEventArgs))]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("F833B59C-C3B4-4E36-97C5-0F1AA9433419")]
	public class WriterReadFileContentEventArgs : WriterEventArgs, IWriterReadFileContentEventArgs
	{
		internal new const string CLASSID = "F833B59C-C3B4-4E36-97C5-0F1AA9433419";

		internal new const string CLASSID_Interface = "6ACA5A24-7F1F-430A-B028-6DF89C54A4A7";

		private string _SpecifyTitle = null;

		private bool _Cancel = false;

		[NonSerialized]
		private WriterAppHost _AppHost = WriterAppHost.Default;

		private string _FileName = null;

		private string _FileFormat = null;

		private string _FileSystemName = null;

		[NonSerialized]
		private IFileSystem _FileSystem = null;

		private bool _FileExisted = true;

		private string _ResultBase64String = null;

		private Encoding _ResultEncoding = null;

		private byte[] _ResultBinary = null;

		private bool _Handled = false;

		/// <summary>
		///       用户强制制定的文档标题
		///       </summary>
		
		public string SpecifyTitle
		{
			get
			{
				return _SpecifyTitle;
			}
			set
			{
				_SpecifyTitle = value;
			}
		}

		/// <summary>
		///       用户取消操作
		///       </summary>
		
		public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
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
		[XmlElement]
		
		[DefaultValue(null)]
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
		///       文件是否存在
		///       </summary>
		[XmlElement]
		
		[DefaultValue(false)]
		public bool FileExisted
		{
			get
			{
				return _FileExisted;
			}
			set
			{
				_FileExisted = value;
			}
		}

		/// <summary>
		///       已BASE64表示的读取到的文件内容
		///       </summary>
		[XmlIgnore]
		
		public string ResultBase64String
		{
			get
			{
				return _ResultBase64String;
			}
			set
			{
				_ResultBase64String = value;
			}
		}

		/// <summary>
		///       文本编码格式
		///       </summary>
		
		[XmlIgnore]
		public Encoding ResultEncoding
		{
			get
			{
				return _ResultEncoding;
			}
			set
			{
				_ResultEncoding = value;
			}
		}

		/// <summary>
		///       结果文本编码名称
		///       </summary>
		
		public string ResultEncodingName
		{
			get
			{
				if (_ResultEncoding == null)
				{
					return null;
				}
				return _ResultEncoding.WebName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_ResultEncoding = null;
				}
				else
				{
					_ResultEncoding = Encoding.GetEncoding(value);
				}
			}
		}

		/// <summary>
		///       读取到的二进制内容
		///       </summary>
		
		[XmlIgnore]
		public byte[] ResultBinary
		{
			get
			{
				return _ResultBinary;
			}
			set
			{
				_ResultBinary = value;
			}
		}

		/// <summary>
		///       事件已经被处理了，无需后续处理
		///       </summary>
		
		[XmlElement]
		[DefaultValue(false)]
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
		
		public WriterReadFileContentEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, string fileName, string fileSystemName)
			: base(writerControl_0, document, element)
		{
			_FileName = fileName;
			_FileSystemName = fileSystemName;
			if (writerControl_0 != null)
			{
				_AppHost = writerControl_0.AppHost;
			}
			else if (document != null)
			{
				_AppHost = document.AppHost;
			}
		}

		internal override void InnerDispose()
		{
			base.InnerDispose();
			_AppHost = null;
			_ResultBinary = null;
			_ResultBase64String = null;
		}

		/// <summary>
		///       获得所得的二进制数据
		///       </summary>
		/// <returns>
		/// </returns>
		
		public byte[] GetResultBinary()
		{
			if (!string.IsNullOrEmpty(_ResultBase64String))
			{
				return Convert.FromBase64String(_ResultBase64String);
			}
			return _ResultBinary;
		}
	}
}
