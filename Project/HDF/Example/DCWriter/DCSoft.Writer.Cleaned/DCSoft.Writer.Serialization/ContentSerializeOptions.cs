using DCSoft.Common;
using DCSoft.Writer.Controls;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoft.Writer.Serialization
{
	/// <summary>
	///       内容序列化选项
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[DocumentComment]
	[ComVisible(false)]
	public class ContentSerializeOptions
	{
		private Encoding _ContentEncoding = null;

		private WriterControl _WriterControl = null;

		private object _Tag = null;

		private bool _FastMode = false;

		private string _FileName = null;

		private string _BasePath = null;

		private bool _IncludeSelectionOnly = false;

		private bool _SerializeAttachFiles = false;

		private bool _Formated = true;

		private bool bolEnableDocumentSetting = true;

		private bool _ImportTemplateGenerateParagraph = true;

		private Dictionary<string, string> _Parameters = new Dictionary<string, string>();

		private bool _ForPrint = false;

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
		///       相关的编辑器控件
		///       </summary>
		public WriterControl WriterControl
		{
			get
			{
				return _WriterControl;
			}
			set
			{
				_WriterControl = value;
			}
		}

		/// <summary>
		///       附加数据
		///       </summary>
		public object Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}

		/// <summary>
		///       快速加载模式
		///       </summary>
		public bool FastMode
		{
			get
			{
				return _FastMode;
			}
			set
			{
				_FastMode = value;
			}
		}

		/// <summary>
		///       输出的文件名
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
		///       基础路径
		///       </summary>
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
		///       只输出被选择的文档内容
		///       </summary>
		public bool IncludeSelectionOnly
		{
			get
			{
				return _IncludeSelectionOnly;
			}
			set
			{
				_IncludeSelectionOnly = value;
			}
		}

		/// <summary>
		///       是否序列化输出附加文件
		///       </summary>
		public bool SerializeAttachFiles
		{
			get
			{
				return _SerializeAttachFiles;
			}
			set
			{
				_SerializeAttachFiles = value;
			}
		}

		/// <summary>
		///       是否进行格式化输出
		///       </summary>
		public bool Formated
		{
			get
			{
				return _Formated;
			}
			set
			{
				_Formated = value;
			}
		}

		/// <summary>
		///       允许读取文档设置
		///       </summary>
		public bool EnableDocumentSetting
		{
			get
			{
				return bolEnableDocumentSetting;
			}
			set
			{
				bolEnableDocumentSetting = value;
			}
		}

		/// <summary>
		///       是否导入临时生成的段落符号
		///       </summary>
		public bool ImportTemplateGenerateParagraph
		{
			get
			{
				return _ImportTemplateGenerateParagraph;
			}
			set
			{
				_ImportTemplateGenerateParagraph = value;
			}
		}

		/// <summary>
		///       用户参数
		///       </summary>
		public Dictionary<string, string> Parameters => _Parameters;

		/// <summary>
		///       处于打印模式
		///       </summary>
		public bool ForPrint
		{
			get
			{
				return _ForPrint;
			}
			set
			{
				_ForPrint = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public ContentSerializeOptions Clone()
		{
			ContentSerializeOptions contentSerializeOptions = (ContentSerializeOptions)MemberwiseClone();
			contentSerializeOptions._Parameters = new Dictionary<string, string>(_Parameters);
			return contentSerializeOptions;
		}
	}
}
