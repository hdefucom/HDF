using DCSoft.Common;
using DCSoft.Writer.Dom;
using DCSoftDotfuscate;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Serialization
{
	/// <summary>
	///       文档内容编码解码器
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	[ComVisible(false)]
	[DCInternal]
	public abstract class ContentSerializer
	{
		private int _Priority = 0;

		private bool _IsDefault = false;

		private Encoding _ContentEncoding = null;

		/// <summary>
		///       文件格式名城
		///       </summary>
		public virtual string Name => null;

		/// <summary>
		///       级别
		///       </summary>
		public virtual int Priority
		{
			get
			{
				return _Priority;
			}
			set
			{
				_Priority = value;
			}
		}

		/// <summary>
		///       是否是默认文件编码器
		///       </summary>
		public bool IsDefault
		{
			get
			{
				return _IsDefault;
			}
			set
			{
				_IsDefault = value;
			}
		}

		/// <summary>
		///       文件扩展名
		///       </summary>
		public virtual string FileExtension => null;

		/// <summary>
		///       文件名过滤器
		///       </summary>
		public virtual string FileFilter => WriterStringsCore.AllFileFilter;

		/// <summary>
		///       对象标记
		///       </summary>
		public virtual GEnum14 Flags => GEnum14.flag_0;

		/// <summary>
		///       文本编码格式
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
		///       是否需要刷新文档页面
		///       </summary>
		public virtual bool NeedRefreshPages(XTextDocument document)
		{
			return false;
		}

		/// <summary>
		///       反序列化文档内容
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="options">选项</param>
		/// <returns>操作是否成功</returns>
		public virtual bool Deserialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			return false;
		}

		/// <summary>
		///       反序列化文档内容
		///       </summary>
		/// <param name="reader">文本读取器</param>
		/// <param name="document">文档对象</param>
		/// <param name="options">选项</param>
		/// <returns>操作是否成功</returns>
		public virtual bool Deserialize(TextReader reader, XTextDocument document, ContentSerializeOptions options)
		{
			return false;
		}

		/// <summary>
		///       序列化文档内容
		///       </summary>
		/// <param name="stream">文件流对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="options">选项</param>
		/// <returns>操作是否成功</returns>
		public virtual bool Serialize(Stream stream, XTextDocument document, ContentSerializeOptions options)
		{
			return false;
		}

		/// <summary>
		///       序列化文档内容
		///       </summary>
		/// <param name="writer">文本书写器</param>
		/// <param name="document">文档对象</param>
		/// <param name="options">选项</param>
		/// <returns>操作是否成功</returns>
		public virtual bool Serialize(TextWriter writer, XTextDocument document, ContentSerializeOptions options)
		{
			return false;
		}
	}
}
