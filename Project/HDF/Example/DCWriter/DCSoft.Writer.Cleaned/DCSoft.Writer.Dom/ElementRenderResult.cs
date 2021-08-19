using DCSoft.Common;
using System.Drawing;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档元素打印结果
	///       </summary>
	[DCPublishAPI]
	public class ElementRenderResult
	{
		private RectangleF _ViewBounds = RectangleF.Empty;

		private DocumentRenderMode _RenderMode = DocumentRenderMode.Paint;

		private RectangleF _ClipRectangle = RectangleF.Empty;

		private bool _Printing = false;

		private bool _PrintPreviewing = false;

		public RectangleF ViewBounds
		{
			get
			{
				return _ViewBounds;
			}
			set
			{
				_ViewBounds = value;
			}
		}

		/// <summary>
		///       呈现模式
		///       </summary>
		public DocumentRenderMode RenderMode
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
		///       剪切矩形
		///       </summary>
		public RectangleF ClipRectangle
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
		///       文档正在打印中
		///       </summary>
		[DCPublishAPI]
		public bool Printing
		{
			get
			{
				return _Printing;
			}
			set
			{
				_Printing = value;
			}
		}

		/// <summary>
		///       文档正在生成打印预览内容
		///       </summary>
		[DCPublishAPI]
		public bool PrintPreviewing
		{
			get
			{
				return _PrintPreviewing;
			}
			set
			{
				_PrintPreviewing = value;
			}
		}

		public ElementRenderResult()
		{
		}

		public ElementRenderResult(DocumentPaintEventArgs args, XTextDocument document)
		{
			_RenderMode = args.RenderMode;
			_ClipRectangle = args.ClipRectangle;
			_Printing = document.States.Printing;
			_PrintPreviewing = document.States.PrintPreviewing;
			_ViewBounds = args.ViewBounds;
		}
	}
}
