using DCSoft.Common;
using Microsoft.VisualBasic;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       插入文档内容使用的参数
	///       </summary>
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComClass("F46D03D5-533E-4CC5-A312-D2FC7395B38B", "841C8CC1-8171-4F31-AF4F-708FBE765BD7")]
	[DCPublishAPI]
	[ComDefaultInterface(typeof(IInsertDocumentCommandParameter))]
	[Guid("F46D03D5-533E-4CC5-A312-D2FC7395B38B")]
	public class InsertDocumentCommandParameter : IInsertDocumentCommandParameter
	{
		internal const string CLASSID = "F46D03D5-533E-4CC5-A312-D2FC7395B38B";

		internal const string CLASSID_Interface = "841C8CC1-8171-4F31-AF4F-708FBE765BD7";

		private string _StringSource = null;

		private TextReader _SourceTextReader = null;

		private Stream _SourceStream = null;

		private string _FileFormat = null;

		private int _StyleIndex = int.MinValue;

		private int _ParagraphStyleIndex = int.MinValue;

		/// <summary>
		///       插入文档内容来源
		///       </summary>
		public string StringSource
		{
			get
			{
				return _StringSource;
			}
			set
			{
				_StringSource = value;
			}
		}

		/// <summary>
		///       插入文档内容来源读取器
		///       </summary>
		[ComVisible(false)]
		public TextReader SourceTextReader
		{
			get
			{
				return _SourceTextReader;
			}
			set
			{
				_SourceTextReader = value;
			}
		}

		/// <summary>
		///       插入文档内容来源文件流
		///       </summary>
		[ComVisible(false)]
		public Stream SourceStream
		{
			get
			{
				return _SourceStream;
			}
			set
			{
				_SourceStream = value;
			}
		}

		/// <summary>
		///       插入文档内容的文件格式
		///       </summary>
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
		///       插入文档内容对应的样式索引
		///       </summary>
		public int StyleIndex
		{
			get
			{
				return _StyleIndex;
			}
			set
			{
				_StyleIndex = value;
			}
		}

		/// <summary>
		///       插入文档内容段落样式对应的索引
		///       </summary>
		public int ParagraphStyleIndex
		{
			get
			{
				return _ParagraphStyleIndex;
			}
			set
			{
				_ParagraphStyleIndex = value;
			}
		}
	}
}
