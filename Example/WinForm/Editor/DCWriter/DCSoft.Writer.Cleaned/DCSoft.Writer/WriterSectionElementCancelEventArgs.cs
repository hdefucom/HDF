using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       可取消的文档节元素事件参数
	///       </summary>
	[DocumentComment]
	[Guid("69939F69-03B7-4747-BD2C-0E186C1D0AB1")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IWriterSectionElementCancelEventArgs))]
	[ComVisible(true)]
	[ComClass("69939F69-03B7-4747-BD2C-0E186C1D0AB1", "298B6B79-9E81-4B20-9D0C-ADB858DB425C")]
	
	public class WriterSectionElementCancelEventArgs : CancelEventArgs, IWriterSectionElementCancelEventArgs
	{
		internal const string CLASSID = "69939F69-03B7-4747-BD2C-0E186C1D0AB1";

		internal const string CLASSID_Interface = "298B6B79-9E81-4B20-9D0C-ADB858DB425C";

		private WriterControl _WriterControl = null;

		private XTextDocument _Document = null;

		private XTextSectionElement _SectionElement = null;

		/// <summary>
		///       编辑器控件
		///       </summary>
		
		public WriterControl WriterControl => _WriterControl;

		/// <summary>
		///       文档对象
		///       </summary>
		
		public XTextDocument Document => _Document;

		/// <summary>
		///       文档节对象
		///       </summary>
		
		public XTextSectionElement SectionElement => _SectionElement;

		bool IWriterSectionElementCancelEventArgs.Cancel
		{
			get
			{
				return base.Cancel;
			}
			set
			{
				base.Cancel = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件</param>
		/// <param name="doc">文档对象</param>
		/// <param name="sec">文档节元素</param>
		
		public WriterSectionElementCancelEventArgs(WriterControl writerControl_0, XTextDocument xtextDocument_0, XTextSectionElement xtextSectionElement_0)
		{
			_WriterControl = writerControl_0;
			_Document = xtextDocument_0;
			_SectionElement = xtextSectionElement_0;
			base.Cancel = false;
		}
	}
}
