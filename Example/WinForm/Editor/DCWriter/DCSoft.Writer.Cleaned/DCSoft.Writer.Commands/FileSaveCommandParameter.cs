using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       FileSave编辑器命令使用的参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComDefaultInterface(typeof(IFileSaveCommandParameter))]
	[ComClass("3F6AB3E3-E126-468F-A4B5-238EE4131403", "346F30F2-6835-48BA-AADF-CEE0330D3739")]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("3F6AB3E3-E126-468F-A4B5-238EE4131403")]
	public class FileSaveCommandParameter : IFileSaveCommandParameter
	{
		internal const string CLASSID = "3F6AB3E3-E126-468F-A4B5-238EE4131403";

		internal const string CLASSID_Interface = "346F30F2-6835-48BA-AADF-CEE0330D3739";

		private bool _BackgroundMode = false;

		private string _FileSystemName = null;

		private string _FileName = null;

		private Encoding _ContentEncoding = null;

		private bool _AutoSetFormat = false;

		private string _Format = null;

		private TextWriter _OutputWriter = null;

		private Stream _OutputStream = null;

		private string _Message = null;

		/// <summary>
		///       后台模式。启用后台模式时，保存的文档状态不变，包括当前文件名，文件修改状态等等。
		///       </summary>
		public bool BackgroundMode
		{
			get
			{
				return _BackgroundMode;
			}
			set
			{
				_BackgroundMode = value;
			}
		}

		/// <summary>
		///       指定的文件系统名称
		///       </summary>
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
		///       指定的文件名
		///       </summary>
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
		///       指定的文档编码格式
		///       </summary>
		public Encoding ContentEncoding
		{
			get
			{
				return _ContentEncoding;
			}
			set
			{
				_ContentEncoding = value;
			}
		}

		/// <summary>
		///       自动设置文件格式
		///       </summary>
		public bool AutoSetFormat
		{
			get
			{
				return _AutoSetFormat;
			}
			set
			{
				_AutoSetFormat = value;
			}
		}

		/// <summary>
		///       指定的文件格式
		///       </summary>
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
		///       保存文件时使用的文本书写器
		///       </summary>
		public TextWriter OutputWriter
		{
			get
			{
				return _OutputWriter;
			}
			set
			{
				_OutputWriter = value;
			}
		}

		/// <summary>
		///       保存文件时使用的文件流对象
		///       </summary>
		public Stream OutputStream
		{
			get
			{
				return _OutputStream;
			}
			set
			{
				_OutputStream = value;
			}
		}

		/// <summary>
		///       相关的提示信息
		///       </summary>
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}
	}
}
