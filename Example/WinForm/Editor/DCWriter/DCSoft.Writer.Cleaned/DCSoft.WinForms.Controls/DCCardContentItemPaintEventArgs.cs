using DCSoft.Common;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       绘制卡片列表项目事件参数
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class DCCardContentItemPaintEventArgs
	{
		private DCCardListViewControl _ListView = null;

		private Graphics _Graphics = null;

		private Rectangle _ClipRectangle = Rectangle.Empty;

		private DCCardListViewItem _ListViewItem = null;

		private DCCardContentItem _ContentItem = null;

		private Rectangle _ViewBounds = Rectangle.Empty;

		private bool _Highlight = false;

		private object _Value = null;

		/// <summary>
		///       列表控件
		///       </summary>
		public DCCardListViewControl ListView => _ListView;

		public Graphics Graphics => _Graphics;

		public Rectangle ClipRectangle => _ClipRectangle;

		public DCCardListViewItem ListViewItem => _ListViewItem;

		public DCCardContentItem ContentItem => _ContentItem;

		/// <summary>
		///       视图边界
		///       </summary>
		public Rectangle ViewBounds
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
		///       高亮度模式
		///       </summary>
		public bool Highlight
		{
			get
			{
				return _Highlight;
			}
			set
			{
				_Highlight = value;
			}
		}

		/// <summary>
		///       要显示的数据
		///       </summary>
		public object Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}

		public DCCardContentItemPaintEventArgs(DCCardListViewControl dccardListViewControl_0, Graphics graphics_0, Rectangle rectangle_0, DCCardListViewItem item, DCCardContentItem contentItem)
		{
			_ListView = dccardListViewControl_0;
			_Graphics = graphics_0;
			_ClipRectangle = rectangle_0;
			_ListViewItem = item;
			_ContentItem = contentItem;
		}
	}
}
