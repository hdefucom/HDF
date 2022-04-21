using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       绘制图形事件参数
	///       </summary>
	[Guid("00576813-1CAF-48CF-BE6E-FC54C6F2469B")]
	
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IWriterDrawShapeContentEventArgs))]
	[ComClass("00576813-1CAF-48CF-BE6E-FC54C6F2469B", "B6973757-A464-4AED-8C69-D1859AA4EDDC")]
	[ClassInterface(ClassInterfaceType.None)]
	
	public class WriterDrawShapeContentEventArgs : WriterEventArgs, IWriterDrawShapeContentEventArgs
	{
		internal new const string CLASSID = "00576813-1CAF-48CF-BE6E-FC54C6F2469B";

		internal new const string CLASSID_Interface = "B6973757-A464-4AED-8C69-D1859AA4EDDC";

		private XTextCustomShapeElement _ShapeElement = null;

		private DocumentPaintEventArgs _PaintEventArgs = null;

		/// <summary>
		///       自定义图形对象
		///       </summary>
		
		public XTextCustomShapeElement ShapeElement => _ShapeElement;

		
		public DocumentPaintEventArgs PaintEventArgs => _PaintEventArgs;

		/// <summary>
		///       元素视图区域
		///       </summary>
		
		public RectangleF ViewBounds => _PaintEventArgs.ViewBounds;

		/// <summary>
		///       剪切矩形
		///       </summary>
		
		public RectangleF ClipRectangle => _PaintEventArgs.ClipRectangle;

		/// <summary>
		///       文档样式对象
		///       </summary>
		
		public RuntimeDocumentContentStyle Sytle => _PaintEventArgs.Style;

		/// <summary>
		///       画布对象
		///       </summary>
		
		public DCGraphics Graphics => _PaintEventArgs.Graphics;

		/// <summary>
		///       当前页码
		///       </summary>
		
		public int PageIndex => _PaintEventArgs.PageIndex;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="ctl">编辑器控件对象</param>
		/// <param name="document">文档对象</param>
		/// <param name="shapeElement">图形文档元素对象</param>
		/// <param name="args">绘制图形事件参数</param>
		
		public WriterDrawShapeContentEventArgs(WriterControl writerControl_0, XTextDocument document, XTextCustomShapeElement shapeElement, DocumentPaintEventArgs args)
			: base(writerControl_0, document, shapeElement)
		{
			_ShapeElement = ShapeElement;
			_PaintEventArgs = args;
		}
	}
}
