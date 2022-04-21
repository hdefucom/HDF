using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       表格行高度正在改变事件
	///       </summary>
	[ComClass("29EED07E-FF09-48A2-AF4B-87260903429A", "7AD13E83-92A5-4E61-8439-E4B373690D1F")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("29EED07E-FF09-48A2-AF4B-87260903429A")]
	
	
	[ComDefaultInterface(typeof(IWriterTableRowHeightChangingEventArgs))]
	public class WriterTableRowHeightChangingEventArgs : WriterEventArgs, IWriterTableRowHeightChangingEventArgs
	{
		internal new const string CLASSID = "29EED07E-FF09-48A2-AF4B-87260903429A";

		internal new const string CLASSID_Interface = "7AD13E83-92A5-4E61-8439-E4B373690D1F";

		private float _NewHeight = 0f;

		private bool _Cancel = false;

		/// <summary>
		///       表格行元素对象
		///       </summary>
		
		public XTextTableRowElement RowElement => (XTextTableRowElement)base.Element;

		/// <summary>
		///       旧的高度
		///       </summary>
		
		public float OldHeight => base.Element.Height;

		/// <summary>
		///       新的高度
		///       </summary>
		
		public float NewHeight
		{
			get
			{
				return _NewHeight;
			}
			set
			{
				_NewHeight = value;
			}
		}

		/// <summary>
		///       是否取消操作
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
		/// <param name="row">表格行元素对象</param>
		/// <param name="newHeight">新的高度</param>
		
		public WriterTableRowHeightChangingEventArgs(WriterControl writerControl_0, XTextDocument document, XTextTableRowElement xtextTableRowElement_0, float newHeight)
			: base(writerControl_0, document, xtextTableRowElement_0)
		{
			_NewHeight = newHeight;
		}
	}
}
