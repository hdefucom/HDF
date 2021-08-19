using DCSoft.Common;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       区域选择信息对象
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public class BoundsSelectionPrintInfoItem
	{
		private RectangleF _ViewBounds = RectangleF.Empty;

		private int _PageIndex = 0;

		/// <summary>
		///       视图边界
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
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public BoundsSelectionPrintInfoItem Clone()
		{
			return (BoundsSelectionPrintInfoItem)MemberwiseClone();
		}
	}
}
