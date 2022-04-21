using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoftDotfuscate;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       绘制文档内容事件参数
	///       </summary>
	
	[ComVisible(false)]
	
	public class DocumentPaintEventArgs : EventArgs, ICloneable
	{
		private bool _EnabledDrawGridLine = true;

		private bool _CheckSizeInvalidateWhenRefreshSize = false;

		private bool _JumpPrintMode = false;

		private PageViewMode _ViewMode = PageViewMode.Page;

		private XTextDocument myDocument = null;

		private XTextDocumentContentElement _DocumentContentElement = null;

		private bool _ActiveMode = true;

		private XTextElement myElement = null;

		private PageContentPartyStyle intType = PageContentPartyStyle.Body;

		private RuntimeDocumentContentStyle _Style = null;

		private bool _Cancel = false;

		private GClass95 _Render = null;

		private DocumentRenderMode _RenderMode = DocumentRenderMode.Paint;

		private bool bolForCreateImage = false;

		/// <summary>
		///       绘图对象
		///       </summary>
		private DCGraphics _Graphics = null;

		private int[] _PageLinePositions = null;

		private RectangleF _PageClipRectangle = RectangleF.Empty;

		private PrintPage _Page = null;

		private int _PageIndex = 0;

		/// <summary>
		///       剪切矩形
		///       </summary>
		protected RectangleF myClipRectangle = RectangleF.Empty;

		private DCPrintDocumentOptions _Options = null;

		private RectangleF _Bounds = RectangleF.Empty;

		/// <summary>
		///       绘图区域的矩形数组
		///       </summary>
		protected RectangleF[] _DrawRectangles = null;

		private float _ScaleRate = 1f;

		/// <summary>
		///       对象的区域
		///       </summary>
		protected RectangleF _ViewBounds = RectangleF.Empty;

		private RectangleF _ClientViewBounds = RectangleF.Empty;

		/// <summary>
		///       允许绘制网格线
		///       </summary>
		
		public bool EnabledDrawGridLine
		{
			get
			{
				return _EnabledDrawGridLine;
			}
			set
			{
				_EnabledDrawGridLine = value;
			}
		}

		/// <summary>
		///       在计算元素大小时是否检查元素的SizeInvalidte属性值。
		///       </summary>
		
		public bool CheckSizeInvalidateWhenRefreshSize
		{
			get
			{
				return _CheckSizeInvalidateWhenRefreshSize;
			}
			set
			{
				_CheckSizeInvalidateWhenRefreshSize = value;
			}
		}

		/// <summary>
		///       处于续打模式
		///       </summary>
		
		public bool JumpPrintMode
		{
			get
			{
				return _JumpPrintMode;
			}
			set
			{
				_JumpPrintMode = value;
			}
		}

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
		///       相关的文档对象
		///       </summary>
		
		public XTextDocument Document
		{
			get
			{
				return myDocument;
			}
			set
			{
				myDocument = value;
			}
		}

		/// <summary>
		///       内容元素对象
		///       </summary>
		
		public XTextDocumentContentElement DocumentContentElement
		{
			get
			{
				return _DocumentContentElement;
			}
			set
			{
				_DocumentContentElement = value;
			}
		}

		/// <summary>
		///       要绘制的内容处于激活模式
		///       </summary>
		
		public bool ActiveMode
		{
			get
			{
				return _ActiveMode;
			}
			set
			{
				_ActiveMode = value;
			}
		}

		/// <summary>
		///       相关的文档元素对象
		///       </summary>
		
		public XTextElement Element
		{
			get
			{
				return myElement;
			}
			set
			{
				myElement = value;
			}
		}

		/// <summary>
		///       文档内容类型
		///       </summary>
		
		public PageContentPartyStyle Type
		{
			get
			{
				return intType;
			}
			set
			{
				intType = value;
			}
		}

		/// <summary>
		///       绘制文档内容使用的样式
		///       </summary>
		
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
		///       图形内容呈现器
		///       </summary>
		
		public GClass95 Render
		{
			get
			{
				return _Render;
			}
			set
			{
				_Render = value;
			}
		}

		/// <summary>
		///       正在呈现的文档样式
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
		///       正在打印文档中被选中的区域的模式
		///       </summary>
		
		public bool PrintSelectionMode => Options != null && Options.PrintRange == PrintRange.Selection;

		/// <summary>
		///       正在为创建图片而绘制图形
		///       </summary>
		
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
		///       绘图对象
		///       </summary>
		
		public DCGraphics Graphics
		{
			get
			{
				return _Graphics;
			}
			set
			{
				_Graphics = value;
			}
		}

		/// <summary>
		///       分页线位置
		///       </summary>
		
		public int[] PageLinePositions
		{
			get
			{
				return _PageLinePositions;
			}
			set
			{
				_PageLinePositions = value;
			}
		}

		/// <summary>
		///       页面剪切矩形
		///       </summary>
		
		public RectangleF PageClipRectangle
		{
			get
			{
				return _PageClipRectangle;
			}
			set
			{
				_PageClipRectangle = value;
			}
		}

		/// <summary>
		///       页面对象
		///       </summary>
		
		public PrintPage Page
		{
			get
			{
				return _Page;
			}
			set
			{
				_Page = value;
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
		///       剪切矩形
		///       </summary>
		
		public RectangleF ClipRectangle
		{
			get
			{
				return myClipRectangle;
			}
			set
			{
				myClipRectangle = value;
			}
		}

		/// <summary>
		///       打印文档选项
		///       </summary>
		[Browsable(false)]
		
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
		///       是否处于区域选择显示模式
		///       </summary>
		
		public bool HasBoundSelection => Options != null && Options.HasBoundSelection;

		/// <summary>
		///       边界
		///       </summary>
		
		public RectangleF Bounds
		{
			get
			{
				return _Bounds;
			}
			set
			{
				_Bounds = value;
			}
		}

		/// <summary>
		///       绘图区域的矩形数组
		///       </summary>
		
		public RectangleF[] DrawRectangles
		{
			get
			{
				return _DrawRectangles;
			}
			set
			{
				_DrawRectangles = value;
			}
		}

		/// <summary>
		///       缩放比率
		///       </summary>
		
		public float ScaleRate
		{
			get
			{
				return _ScaleRate;
			}
			set
			{
				_ScaleRate = value;
			}
		}

		/// <summary>
		///       对象的区域
		///       </summary>
		
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
		///       对象客户区的边界
		///       </summary>
		
		public RectangleF ClientViewBounds
		{
			get
			{
				return _ClientViewBounds;
			}
			set
			{
				_ClientViewBounds = value;
			}
		}

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="g">绘图对象</param>
		/// <param name="clipRectangle">剪切矩形</param>
		
		public DocumentPaintEventArgs(DCGraphics dcgraphics_0, RectangleF clipRectangle)
		{
			_Graphics = dcgraphics_0;
			myClipRectangle = clipRectangle;
			_ViewBounds = clipRectangle;
			_DrawRectangles = new RectangleF[1]
			{
				clipRectangle
			};
		}

		/// <summary>
		///       是否可见
		///       </summary>
		/// <param name="visi">
		/// </param>
		/// <returns>
		/// </returns>
		
		public bool IsVisible(RenderVisibility visi)
		{
			if (RenderMode == DocumentRenderMode.Print)
			{
				if ((visi & RenderVisibility.Print) != RenderVisibility.Print)
				{
					return false;
				}
			}
			else if (RenderMode == DocumentRenderMode.PDF && (visi & RenderVisibility.PDF) != RenderVisibility.PDF)
			{
				return false;
			}
			return true;
		}

		public void SetClip(RectangleF rect, CombineMode mode)
		{
			if (RenderMode == DocumentRenderMode.Print && Options != null && Options.HasBoundSelection)
			{
				Region region = null;
				foreach (BoundsSelectionPrintInfoItem item in Options.BoundsSelection)
				{
					if (region == null)
					{
						region = new Region(item.ViewBounds);
					}
					else
					{
						region.Union(item.ViewBounds);
					}
				}
				if (!ClipRectangle.IsEmpty)
				{
					region.Intersect(ClipRectangle);
				}
				Graphics.NativeGraphics.SetClip(region, CombineMode.Replace);
			}
			else
			{
				Graphics.SetClip(rect, mode);
			}
		}

		private bool MatchPageLine(float float_0)
		{
			if (_PageLinePositions != null)
			{
				int num = _PageLinePositions.Length - 1;
				while (num >= 0)
				{
					if (!((double)Math.Abs((float)_PageLinePositions[num] - float_0) < 0.01))
					{
						num--;
						continue;
					}
					return true;
				}
			}
			return false;
		}

		/// <summary>
		///       判断指定矩形是否和绘图区域相交
		///       </summary>
		/// <param name="rect">表示指定区域的矩形</param>
		/// <returns>指定区域是否和绘图区域相交</returns>
		public bool IntersectsWithDrawRects(RectangleF rect)
		{
			if (_DrawRectangles != null)
			{
				for (int i = 0; i < _DrawRectangles.Length; i++)
				{
					if (_DrawRectangles[i].IntersectsWith(rect))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		///       判断指定点是否在绘制区域中
		///       </summary>
		/// <param name="y1">Y1坐标值</param>
		/// <param name="y2">Y2坐标值</param>
		/// <returns>
		/// </returns>
		public bool IntersectsWithDrawRects(int int_0, int int_1)
		{
			RectangleF rect = new RectangleF(_ViewBounds.Left, int_0, _ViewBounds.Width, int_1 - int_0);
			return IntersectsWithDrawRects(rect);
		}

		/// <summary>
		///       判断指定大小的区域是否表示有效的大小
		///       </summary>
		/// <param name="width">区域宽度</param>
		/// <param name="height">区域高度</param>
		/// <returns>是否表示有效大小</returns>
		private bool InvalidSize(float width, float height)
		{
			if (width > 0f && height >= 0f)
			{
				return true;
			}
			if (height > 0f && width >= 0f)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///       绘制边框
		///       </summary>
		/// <param name="p">绘制边框使用的画笔对象</param>
		public void DrawDrawRects(Pen pen_0)
		{
			DrawDrawRects(pen_0, _ViewBounds, LeftBorder: true, TopBorder: true, RightBorder: true, BottomBorder: true);
		}

		/// <summary>
		///       绘制边框
		///       </summary>
		/// <param name="p">绘制边框使用的画笔对象</param>
		/// <param name="rect">边框的矩形对象</param>
		/// <param name="LeftBorder">是否绘制左边框</param>
		/// <param name="TopBorder">是否绘制顶边框</param>
		/// <param name="RightBorder">是否绘制右边框</param>
		/// <param name="BottomBorder">是否绘制底边框</param>
		public void DrawDrawRects(Pen pen_0, RectangleF rect, bool LeftBorder, bool TopBorder, bool RightBorder, bool BottomBorder)
		{
			if (_DrawRectangles == null || _Graphics == null || pen_0 == null)
			{
				return;
			}
			for (int i = 0; i < _DrawRectangles.Length; i++)
			{
				RectangleF rectangleF = RectangleF.Intersect(_DrawRectangles[i], rect);
				if (!InvalidSize(rectangleF.Width, rectangleF.Height))
				{
					continue;
				}
				if (LeftBorder && rectangleF.Left == rect.Left)
				{
					_Graphics.DrawLine(pen_0, rectangleF.Left, rectangleF.Top, rectangleF.Left, rectangleF.Bottom);
				}
				if (TopBorder)
				{
					float top = rectangleF.Top;
					if (top == rect.Top || MatchPageLine(top))
					{
						_Graphics.DrawLine(pen_0, rectangleF.Left, top, rectangleF.Right, top);
					}
				}
				if (RightBorder && rectangleF.Right == rect.Right)
				{
					_Graphics.DrawLine(pen_0, rectangleF.Right, rectangleF.Top, rectangleF.Right, rectangleF.Bottom);
				}
				if (BottomBorder)
				{
					float bottom = rectangleF.Bottom;
					if (bottom == rect.Bottom || MatchPageLine(bottom))
					{
						_Graphics.DrawLine(pen_0, rectangleF.Left, bottom, rectangleF.Right, bottom);
					}
				}
			}
		}

		object ICloneable.Clone()
		{
			DocumentPaintEventArgs documentPaintEventArgs = (DocumentPaintEventArgs)MemberwiseClone();
			if (_DrawRectangles != null)
			{
				documentPaintEventArgs._DrawRectangles = (RectangleF[])_DrawRectangles.Clone();
			}
			return documentPaintEventArgs;
		}

		/// <summary>
		///       复制对象的一个复本
		///       </summary>
		/// <returns>复制的对象</returns>
		public DocumentPaintEventArgs Clone()
		{
			return (DocumentPaintEventArgs)((ICloneable)this).Clone();
		}
	}
}
