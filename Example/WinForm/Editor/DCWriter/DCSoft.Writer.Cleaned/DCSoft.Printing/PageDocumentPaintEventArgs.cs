using DCSoft.Drawing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       分页文档绘制内容事件参数
	///       </summary>
	[ComVisible(false)]
	public class PageDocumentPaintEventArgs : EventArgs
	{
		private SimpleRectangleTransform _TransformItem = null;

		private DCPrintDocumentOptions _Options = null;

		private int _PageIndex = 0;

		private int _NumberOfPages = 0;

		private Graphics _Graphics = null;

		private Rectangle _ClipRectangle = Rectangle.Empty;

		private Rectangle _ContentBounds = Rectangle.Empty;

		private RectangleF myPageClipRectangle = RectangleF.Empty;

		private IPageDocument _Document = null;

		private PrintPage _Page = null;

		private PageContentPartyStyle _ContentStyle = PageContentPartyStyle.Body;

		private PageViewMode _ViewMode = PageViewMode.Page;

		private ContentRenderMode _RenderMode = ContentRenderMode.UIPaint;

		private bool _Cancel = false;

		public SimpleRectangleTransform TransformItem => _TransformItem;

		/// <summary>
		///       文档选项
		///       </summary>
		public DCPrintDocumentOptions Options
		{
			get
			{
				return _Options;
			}
			set
			{
				_Options = value;
			}
		}

		/// <summary>
		///       从0开始计算的页码号
		///       </summary>
		public int PageIndex
		{
			get
			{
				return _PageIndex;
			}
			set
			{
				_PageIndex = value;
			}
		}

		/// <summary>
		///       总页数
		///       </summary>
		[DefaultValue(0)]
		public int NumberOfPages
		{
			get
			{
				return _NumberOfPages;
			}
			set
			{
				_NumberOfPages = value;
			}
		}

		/// <summary>
		///       图形绘制对象
		///       </summary>
		public Graphics Graphics => _Graphics;

		/// <summary>
		///       剪切矩形
		///       </summary>
		public Rectangle ClipRectangle
		{
			get
			{
				return _ClipRectangle;
			}
			set
			{
				_ClipRectangle = value;
			}
		}

		/// <summary>
		///       当绘制页眉页脚时，页眉页脚内容边界
		///       </summary>
		public Rectangle ContentBounds
		{
			get
			{
				return _ContentBounds;
			}
			set
			{
				_ContentBounds = value;
			}
		}

		/// <summary>
		///       页面剪切矩形
		///       </summary>
		public RectangleF PageClipRectangle
		{
			get
			{
				return myPageClipRectangle;
			}
			set
			{
				myPageClipRectangle = value;
			}
		}

		/// <summary>
		///       文档对象
		///       </summary>
		public IPageDocument Document => _Document;

		/// <summary>
		///       页面对象
		///       </summary>
		public PrintPage Page => _Page;

		/// <summary>
		///       内容样式
		///       </summary>
		public PageContentPartyStyle ContentStyle => _ContentStyle;

		/// <summary>
		///       视图模式
		///       </summary>
		public PageViewMode ViewMode
		{
			get
			{
				return _ViewMode;
			}
			set
			{
				_ViewMode = value;
			}
		}

		/// <summary>
		///       内容呈现模式
		///       </summary>
		public ContentRenderMode RenderMode
		{
			get
			{
				return _RenderMode;
			}
			set
			{
				_RenderMode = value;
			}
		}

		/// <summary>
		///       取消操作
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

		public PageDocumentPaintEventArgs(Graphics graphics, Rectangle clipRectangle, IPageDocument document, PrintPage page, PageContentPartyStyle contentStyle, SimpleRectangleTransform transformItem)
		{
			_Graphics = graphics;
			_ClipRectangle = clipRectangle;
			_Document = document;
			_Page = page;
			_ContentStyle = contentStyle;
			if (page != null)
			{
				_PageIndex = page.GlobalIndex;
			}
			_TransformItem = transformItem;
		}
	}
}
