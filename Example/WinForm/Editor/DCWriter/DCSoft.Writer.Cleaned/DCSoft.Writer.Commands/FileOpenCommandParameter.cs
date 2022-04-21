using DCSoft.Common;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       FileOpen编辑器命令使用的参数
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComClass("B74C8612-CD72-4BEF-9FE7-476AA93A7155", "5B1E164D-B3DE-4645-96DA-420C994AFAE0")]
	[Guid("B74C8612-CD72-4BEF-9FE7-476AA93A7155")]
	
	[ComDefaultInterface(typeof(IFileOpenCommandParameter))]
	[ComVisible(true)]
	
	[ClassInterface(ClassInterfaceType.None)]
	public class FileOpenCommandParameter : IFileOpenCommandParameter
	{
		internal const string CLASSID = "B74C8612-CD72-4BEF-9FE7-476AA93A7155";

		internal const string CLASSID_Interface = "5B1E164D-B3DE-4645-96DA-420C994AFAE0";

		private string _FileSystemName = null;

		private string _FileName = null;

		private Encoding _ContentEncoding = null;

		private string _Format = null;

		private TextReader _InputReader = null;

		private Stream _InputStream = null;

		private string _Message = null;

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
		///       读取文件时使用的文本读取器
		///       </summary>
		public TextReader InputReader
		{
			get
			{
				return _InputReader;
			}
			set
			{
				_InputReader = value;
			}
		}

		/// <summary>
		///       读取文件时使用的文件流对象
		///       </summary>
		public Stream InputStream
		{
			get
			{
				return _InputStream;
			}
			set
			{
				_InputStream = value;
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
