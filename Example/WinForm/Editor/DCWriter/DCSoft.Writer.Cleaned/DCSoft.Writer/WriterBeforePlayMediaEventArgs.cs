using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       准备播放多媒体事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[DocumentComment]
	[ComVisible(true)]
	
	[ComDefaultInterface(typeof(IWriterBeforePlayMediaEventArgs))]
	[Guid("ACDACF1B-140E-4BE2-81DC-0D7D60B30A65")]
	[ComClass("ACDACF1B-140E-4BE2-81DC-0D7D60B30A65", "B5BFF735-5AA3-465A-887F-93ADE8A633AD")]
	public class WriterBeforePlayMediaEventArgs : EventArgs, IWriterBeforePlayMediaEventArgs
	{
		internal const string CLASSID = "ACDACF1B-140E-4BE2-81DC-0D7D60B30A65";

		internal const string CLASSID_Interface = "B5BFF735-5AA3-465A-887F-93ADE8A633AD";

		private string _FileSystemName;

		private string _FileName;

		private string _TargetFileName;

		private WriterControl _WriterControl;

		private XTextDocument _Document;

		private XTextElement _MediaElement;

		private bool _Cancel;

		/// <summary>
		///       文件系统名称
		///       </summary>
		
		public string FileSystemName => _FileSystemName;

		/// <summary>
		///       媒体文件名
		///       </summary>
		
		public string FileName => _FileName;

		/// <summary>
		///       目标文件名
		///       </summary>
		
		public string TargetFileName
		{
			get
			{
				return _TargetFileName;
			}
			set
			{
				_TargetFileName = value;
			}
		}

		/// <summary>
		///       编辑器控件
		///       </summary>
		
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Document => _Document;

		/// <summary>
		///       媒体文档元素对象
		///       </summary>
		
		public XTextElement MediaElement => _MediaElement;

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
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="element">媒体元素对象</param>
		
		public WriterBeforePlayMediaEventArgs(WriterControl writerControl_0, XTextDocument document, XTextElement element, string fileName, string fileSystemName)
		{
			int num = 16;
			_FileSystemName = null;
			_FileName = null;
			_TargetFileName = null;
			_WriterControl = null;
			_Document = null;
			_MediaElement = null;
			_Cancel = false;
			
			if (writerControl_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			_WriterControl = writerControl_0;
			_Document = document;
			_MediaElement = element;
			_FileName = fileName;
			_TargetFileName = FileName;
			_FileSystemName = fileSystemName;
		}
	}
}
