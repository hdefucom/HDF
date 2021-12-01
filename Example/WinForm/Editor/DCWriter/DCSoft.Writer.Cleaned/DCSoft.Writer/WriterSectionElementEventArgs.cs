using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档节元素事件参数
	///       </summary>
	[DocumentComment]
	[ClassInterface(ClassInterfaceType.None)]
	[DCPublishAPI]
	[ComVisible(true)]
	[Guid("D81D643D-DB47-43B0-B1E6-09A5165075F7")]
	[ComDefaultInterface(typeof(IWriterSectionElementEventArgs))]
	[ComClass("D81D643D-DB47-43B0-B1E6-09A5165075F7", "C1C74C2E-2455-4273-89F5-C66326B7BEC0")]
	public class WriterSectionElementEventArgs : EventArgs, IWriterSectionElementEventArgs
	{
		internal const string CLASSID = "D81D643D-DB47-43B0-B1E6-09A5165075F7";

		internal const string CLASSID_Interface = "C1C74C2E-2455-4273-89F5-C66326B7BEC0";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XTextSectionElement _SectionElement = null;

		/// <summary>
		///       编辑器控件
		///       </summary>
		[DCPublishAPI]
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		[DCPublishAPI]
		public XTextDocument Document => _Document;

		/// <summary>
		///       文档节对象
		///       </summary>
		[DCPublishAPI]
		public XTextSectionElement SectionElement => _SectionElement;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="doc">文档对象</param>
		/// <param name="sec">文档节元素</param>
		[DCInternal]
		public WriterSectionElementEventArgs(WriterControl writerControl_0, XTextDocument xtextDocument_0, XTextSectionElement xtextSectionElement_0)
		{
			_WriterControl = writerControl_0;
			_Document = xtextDocument_0;
			_SectionElement = xtextSectionElement_0;
		}
	}
}
