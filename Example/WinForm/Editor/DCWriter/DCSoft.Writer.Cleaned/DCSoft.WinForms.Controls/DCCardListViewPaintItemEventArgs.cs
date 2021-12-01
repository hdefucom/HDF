using DCSoft.Common;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///       卡片项目绘制事件参数
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class DCCardListViewPaintItemEventArgs
	{
		private Graphics _Graphics = null;

		private Rectangle _ClipRectangle = Rectangle.Empty;

		private DCCardListViewItem _Item = null;

		private bool _Highlight = false;

		private Rectangle _ItemBounds = Rectangle.Empty;

		/// <summary>
		///       图形绘制对象
		///       </summary>
		public Graphics Graphics => _Graphics;

		/// <summary>
		///       剪切矩形
		///       </summary>
		public Rectangle ClipRectangle => _ClipRectangle;

		/// <summary>
		///       列表项目
		///       </summary>
		public DCCardListViewItem Item => _Item;

		/// <summary>
		///       高亮度显示模式
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
		///       列表项目绑定的数据源项目
		///       </summary>
		private object DataBoundItem
		{
			get
			{
				if (_Item == null)
				{
					return null;
				}
				return _Item.DataBoundItem;
			}
		}

		/// <summary>
		///       列表项目边界
		///       </summary>
		public Rectangle ItemBounds => _ItemBounds;

		public DCCardListViewPaintItemEventArgs(Graphics graphics_0, Rectangle clip, DCCardListViewItem item, Rectangle itemBounds)
		{
			_Graphics = graphics_0;
			_ClipRectangle = clip;
			_Item = item;
			_ItemBounds = itemBounds;
		}
	}
}
