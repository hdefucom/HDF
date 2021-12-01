using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       错误报告信息
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComVisible(false)]
	public class ErrorReportInfo
	{
		private string _ApplicationName = null;

		private string _AppPath = null;

		private string _DateTime = null;

		private string _OSVersion = null;

		private string _CommandLine = null;

		private string _AppVersion = null;

		private string _SourceType = null;

		private string _SourceModuleName = null;

		private string _SourceModuleVersion = null;

		private string _SourceModuleCodeBase = null;

		private string _RuntimeVersion = null;

		private string _UserMessage = null;

		private string _SystemMessage = null;

		private string _ExceptionString = null;

		/// <summary>
		///       应用程序名称
		///       </summary>
		[DefaultValue(null)]
		public string ApplicationName
		{
			get
			{
				return _ApplicationName;
			}
			set
			{
				_ApplicationName = value;
			}
		}

		/// <summary>
		///       应用程序路径
		///       </summary>
		[DefaultValue(null)]
		public string AppPath
		{
			get
			{
				return _AppPath;
			}
			set
			{
				_AppPath = value;
			}
		}

		/// <summary>
		///       提交报告时的时间
		///       </summary>
		[DefaultValue(null)]
		public string DateTime
		{
			get
			{
				return _DateTime;
			}
			set
			{
				_DateTime = value;
			}
		}

		/// <summary>
		///       操作系统版本号
		///       </summary>
		[DefaultValue(null)]
		public string OSVersion
		{
			get
			{
				return _OSVersion;
			}
			set
			{
				_OSVersion = value;
			}
		}

		/// <summary>
		///       命令行文本
		///       </summary>
		[DefaultValue(null)]
		public string CommandLine
		{
			get
			{
				return _CommandLine;
			}
			set
			{
				_CommandLine = value;
			}
		}

		/// <summary>
		///       应用程序版本号
		///       </summary>
		[DefaultValue(null)]
		public string AppVersion
		{
			get
			{
				return _AppVersion;
			}
			set
			{
				_AppVersion = value;
			}
		}

		/// <summary>
		///       发生错误的相关类型
		///       </summary>
		[DefaultValue(null)]
		public string SourceType
		{
			get
			{
				return _SourceType;
			}
			set
			{
				_SourceType = value;
			}
		}

		/// <summary>
		///       出错的程序模块名称
		///       </summary>
		[DefaultValue(null)]
		public string SourceModuleName
		{
			get
			{
				return _SourceModuleName;
			}
			set
			{
				_SourceModuleName = value;
			}
		}

		/// <summary>
		///       出错的程序模块版本号
		///       </summary>
		[DefaultValue(null)]
		public string SourceModuleVersion
		{
			get
			{
				return _SourceModuleVersion;
			}
			set
			{
				_SourceModuleVersion = value;
			}
		}

		/// <summary>
		///       出错的程序模块基础代码
		///       </summary>
		[DefaultValue(null)]
		public string SourceModuleCodeBase
		{
			get
			{
				return _SourceModuleCodeBase;
			}
			set
			{
				_SourceModuleCodeBase = value;
			}
		}

		/// <summary>
		///       .NET运行时版本号
		///       </summary>
		[DefaultValue(null)]
		public string RuntimeVersion
		{
			get
			{
				return _RuntimeVersion;
			}
			set
			{
				_RuntimeVersion = value;
			}
		}

		/// <summary>
		///       用户信息
		///       </summary>
		[DefaultValue(null)]
		public string UserMessage
		{
			get
			{
				return _UserMessage;
			}
			set
			{
				_UserMessage = value;
			}
		}

		/// <summary>
		///       系统消息
		///       </summary>
		[DefaultValue(null)]
		public string SystemMessage
		{
			get
			{
				return _SystemMessage;
			}
			set
			{
				_SystemMessage = value;
			}
		}

		/// <summary>
		///       完整的异常信息
		///       </summary>
		[DefaultValue(null)]
		public string ExceptionString
		{
			get
			{
				return _ExceptionString;
			}
			set
			{
				_ExceptionString = value;
			}
		}

		/// <summary>
		///       获得保存对象数据的XML字符串
		///       </summary>
		/// <returns>XML字符串</returns>
		public string ToXMLString()
		{
			StringWriter stringWriter = new StringWriter();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Indentation = 1;
			xmlTextWriter.IndentChar = '\t';
			xmlTextWriter.Formatting = Formatting.Indented;
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());
			xmlSerializer.Serialize(xmlTextWriter, this);
			xmlTextWriter.Close();
			return stringWriter.ToString();
		}
	}
}
