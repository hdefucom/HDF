using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       绘制元素图形事件参数
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("12CF1384-1786-471F-BF9A-7E370B9A484B")]
	[ComDefaultInterface(typeof(IElementPaintEventArgs))]
	[DocumentComment]
	[ComClass("12CF1384-1786-471F-BF9A-7E370B9A484B", "BFB16C0A-B8AE-4ECA-AACE-BE43493221F5")]
	[ComVisible(true)]
	[DCPublishAPI]
	public class ElementPaintEventArgs : ElementEventArgs, IElementPaintEventArgs
	{
		internal new const string CLASSID = "12CF1384-1786-471F-BF9A-7E370B9A484B";

		internal new const string CLASSID_Interface = "BFB16C0A-B8AE-4ECA-AACE-BE43493221F5";

		private DCGraphics _Graphics = null;

		private RectangleF _ClipRectangle = RectangleF.Empty;

		private RectangleF _ViewBounds = RectangleF.Empty;

		private RectangleF _ClientViewBounds = RectangleF.Empty;

		private RuntimeDocumentContentStyle _Style = null;

		private bool _Cancel = false;

		private DocumentRenderMode intRenderMode = DocumentRenderMode.Paint;

		private bool bolForCreateImage = false;

		/// <summary>
		///       从1开始计算的当前页码号
		///       </summary>
		[DCPublishAPI]
		public int PageIndex
		{
			get
			{
				if (base.Document == null)
				{
					return 0;
				}
				return base.Document.PageIndex;
			}
		}

		/// <summary>
		///       画布对象
		///       </summary>
		[DCPublishAPI]
		public DCGraphics Graphics => _Graphics;

		/// <summary>
		///       剪切矩形
		///       </summary>
		[DCPublishAPI]
		public RectangleF ClipRectangle => _ClipRectangle;

		/// <summary>
		///       文档元素视图区域
		///       </summary>
		[DCPublishAPI]
		public RectangleF ViewBounds => _ViewBounds;

		/// <summary>
		///       文档元素客户区视图区域
		///       </summary>
		public RectangleF ClientViewBounds => _ClientViewBounds;

		/// <summary>
		///       绘制文档内容使用的样式
		///       </summary>
		[DCPublishAPI]
		public RuntimeDocumentContentStyle Style
		{
			get
			{
				return _Style;
			}
			set
			{
				_Style = value;
			}
		}

		/// <summary>
		///       用户取消操作
		///       </summary>
		[DCPublishAPI]
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
		///       正在呈现的文档样式
		///       </summary>
		[DCPublishAPI]
		public DocumentRenderMode RenderMode
		{
			get
			{
				return intRenderMode;
			}
			set
			{
				intRenderMode = value;
			}
		}

		/// <summary>
		///       正在为创建图片而绘制图形
		///       </summary>
		[DCPublishAPI]
		public bool ForCreateImage
		{
			get
			{
				return bolForCreateImage;
			}
			set
			{
				bolForCreateImage = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		[DCInternal]
		public ElementPaintEventArgs(XTextDocument document, XTextElement element, DocumentPaintEventArgs args)
		{
			base.Document = document;
			base.Element = element;
			_Graphics = args.Graphics;
			_ClipRectangle = args.ClipRectangle;
			_ViewBounds = args.ViewBounds;
			_ClientViewBounds = args.ClientViewBounds;
			base.WriterControl = document.EditorControl;
			intRenderMode = args.RenderMode;
			Cancel = args.Cancel;
			ForCreateImage = args.ForCreateImage;
			Style = args.Style;
		}
	}
}
