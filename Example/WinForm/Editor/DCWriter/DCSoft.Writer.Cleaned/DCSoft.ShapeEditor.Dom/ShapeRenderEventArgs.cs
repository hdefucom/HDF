using DCSoft.Drawing;
using DCSoftDotfuscate;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       文档内容呈现事件参数
	///       </summary>
	[ComVisible(false)]
	public class ShapeRenderEventArgs
	{
		private ShapeDocument _Document = null;

		private ShapeElement _Element = null;

		private bool _DesignMode = true;

		private GClass331 _Render = null;

		private float _ZoomRate = 1f;

		private ShapeDocumentViewOptions _ViewOptions = null;

		private DCGraphics _Graphics = null;

		private RectangleF _ClipRectangle = RectangleF.Empty;

		private ShapeRenderStyle _Style = ShapeRenderStyle.Paint;

		/// <summary>
		///       操作涉及的文档对象
		///       </summary>
		public ShapeDocument Document
		{
			get
			{
				return _Document;
			}
			set
			{
				_Document = value;
			}
		}

		/// <summary>
		///       要绘制的文档元素对象
		///       </summary>
		public ShapeElement Element
		{
			get
			{
				return _Element;
			}
			set
			{
				_Element = value;
			}
		}

		/// <summary>
		///       是否处于设计模式
		///       </summary>
		public bool DesignMode
		{
			get
			{
				return _DesignMode;
			}
			set
			{
				_DesignMode = value;
			}
		}

		/// <summary>
		///       图形呈现器
		///       </summary>
		public GClass331 Render
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
		///       视图缩放比例
		///       </summary>
		public float ZoomRate
		{
			get
			{
				return _ZoomRate;
			}
			set
			{
				_ZoomRate = value;
			}
		}

		/// <summary>
		///       文档视图选项
		///       </summary>
		public ShapeDocumentViewOptions ViewOptions
		{
			get
			{
				return _ViewOptions;
			}
			set
			{
				_ViewOptions = value;
			}
		}

		/// <summary>
		///       画布对象
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
		///       图形呈现模式
		///       </summary>
		public ShapeRenderStyle Style
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
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public ShapeRenderEventArgs Clone()
		{
			return (ShapeRenderEventArgs)MemberwiseClone();
		}
	}
}
