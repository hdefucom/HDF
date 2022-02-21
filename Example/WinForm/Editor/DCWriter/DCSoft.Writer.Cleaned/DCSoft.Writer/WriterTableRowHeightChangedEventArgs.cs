using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       表格行高度改变事件
	///       </summary>
	[ComClass("E575EB08-55B4-435F-B17F-D2D538F70E5A", "FC83CB1D-B2DF-47FB-9404-0473E15477EB")]
	[DocumentComment]
	
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("E575EB08-55B4-435F-B17F-D2D538F70E5A")]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IWriterTableRowHeightChangedEventArgs))]
	public class WriterTableRowHeightChangedEventArgs : WriterEventArgs, IWriterTableRowHeightChangedEventArgs
	{
		internal new const string CLASSID = "E575EB08-55B4-435F-B17F-D2D538F70E5A";

		internal new const string CLASSID_Interface = "FC83CB1D-B2DF-47FB-9404-0473E15477EB";

		private float _OldHeight = 0f;

		private float _NewHeight = 0f;

		/// <summary>
		///       表格行元素对象
		///       </summary>
		
		public XTextTableRowElement RowElement => (XTextTableRowElement)base.Element;

		/// <summary>
		///       旧的高度
		///       </summary>
		
		public float OldHeight => _OldHeight;

		/// <summary>
		///       新的高度
		///       </summary>
		
		public float NewHeight => _NewHeight;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="row">表格行元素对象</param>
		/// <param name="newHeight">新的高度</param>
		
		public WriterTableRowHeightChangedEventArgs(WriterControl writerControl_0, XTextDocument document, XTextTableRowElement xtextTableRowElement_0, float oldHeight, float newHeight)
			: base(writerControl_0, document, xtextTableRowElement_0)
		{
			_OldHeight = oldHeight;
			_NewHeight = newHeight;
		}
	}
}
