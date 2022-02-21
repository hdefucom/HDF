using DCSoft.Common;
using DCSoft.Writer.Controls;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档母版信息对象
	///       </summary>
	[Serializable]
	[ComVisible(true)]
	[Guid("66872296-99A7-486C-A93E-58EAEE5013C6")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IMotherTemplateInfo))]
	[DocumentComment]
	
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[ComClass("66872296-99A7-486C-A93E-58EAEE5013C6", "E9616384-7887-4071-B773-157F5E594590")]
	public class MotherTemplateInfo : IMotherTemplateInfo
	{
		internal const string CLASSID = "66872296-99A7-486C-A93E-58EAEE5013C6";

		internal const string CLASSID_Interface = "E9616384-7887-4071-B773-157F5E594590";

		private string _FileName = null;

		private string _FileSystemName = null;

		private string _Format = null;

		private bool _ImportPageSettings = true;

		private bool _ImportHeader = true;

		private bool _ImportFooter = true;

		/// <summary>
		///       文件名
		///       </summary>
		
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
		///       文件系统名称
		///       </summary>
		[DefaultValue(null)]
		
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
		///       文件格式
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
		///       导入页面设置
		///       </summary>
		
		[DefaultValue(true)]
		public bool ImportPageSettings
		{
			get
			{
				return _ImportPageSettings;
			}
			set
			{
				_ImportPageSettings = value;
			}
		}

		/// <summary>
		///       导入页眉
		///       </summary>
		[DefaultValue(true)]
		
		public bool ImportHeader
		{
			get
			{
				return _ImportHeader;
			}
			set
			{
				_ImportHeader = value;
			}
		}

		/// <summary>
		///       导入页脚
		///       </summary>
		
		[DefaultValue(true)]
		public bool ImportFooter
		{
			get
			{
				return _ImportFooter;
			}
			set
			{
				_ImportFooter = value;
			}
		}

		/// <summary>
		///       对文档应用文档母版信息
		///       </summary>
		/// <param name="ctl">相关的编辑器控件</param>
		/// <param name="document">文档对象</param>
		/// <returns>操作是否改变了文档内容</returns>
		internal bool Apply(WriterControl writerControl_0, XTextDocument document)
		{
			int num = 9;
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (string.IsNullOrEmpty(FileName))
			{
				return false;
			}
			WriterReadFileContentEventArgs writerReadFileContentEventArgs = new WriterReadFileContentEventArgs(writerControl_0, document, null, FileName, FileSystemName);
			writerReadFileContentEventArgs.FileFormat = Format;
			byte[] array = WriterControl.ReadFileContent(writerControl_0, writerReadFileContentEventArgs);
			if (array == null || array.Length == 0)
			{
				return false;
			}
			XTextDocument xTextDocument = new XTextDocument();
			MemoryStream stream = new MemoryStream(array);
			xTextDocument.Load(stream, writerReadFileContentEventArgs.FileFormat);
			if (ImportPageSettings)
			{
				document.PageSettings = xTextDocument.PageSettings;
			}
			if (ImportHeader)
			{
				XTextElementList elements = xTextDocument.Header.Elements;
				document.ImportElements(elements);
				document.Header.Elements.Clear();
				document.Header.Elements.AddRange(elements);
			}
			if (ImportFooter)
			{
				XTextElementList elements = xTextDocument.Footer.Elements;
				document.ImportElements(elements);
				document.Footer.Elements.Clear();
				document.Footer.Elements.AddRange(elements);
			}
			return true;
		}
	}
}
