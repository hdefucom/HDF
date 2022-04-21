using DCSoft.Common;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       区域选择打印信息对象集合
	///       </summary>
	
	[ComVisible(false)]
	
	public class BoundsSelectionPrintInfo : List<BoundsSelectionPrintInfoItem>
	{
		private bool _Enable = false;

		/// <summary>
		///       是否存在有效的信息
		///       </summary>
		public bool HasValidateInfo
		{
			get
			{
				if (!Enable)
				{
					return false;
				}
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						BoundsSelectionPrintInfoItem current = enumerator.Current;
						if (current.PageIndex >= 0 && !current.ViewBounds.IsEmpty)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		/// <summary>
		///       对象是否可用
		///       </summary>
		public bool Enable
		{
			get
			{
				return _Enable;
			}
			set
			{
				_Enable = value;
			}
		}

		/// <summary>
		///       包含所有区域的最小矩形
		///       </summary>
		public RectangleF ViewBounds
		{
			get
			{
				RectangleF rectangleF = RectangleF.Empty;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						BoundsSelectionPrintInfoItem current = enumerator.Current;
						rectangleF = ((!rectangleF.IsEmpty) ? RectangleF.Union(rectangleF, current.ViewBounds) : current.ViewBounds);
					}
				}
				return rectangleF;
			}
		}

		/// <summary>
		///       添加项目
		///       </summary>
		/// <param name="pageIndex">从0开始计算的页码号</param>
		/// <param name="bounds">视图区域</param>
		/// <returns>新添加的项目</returns>
		public BoundsSelectionPrintInfoItem AddItem(int pageIndex, RectangleF bounds)
		{
			BoundsSelectionPrintInfoItem boundsSelectionPrintInfoItem = new BoundsSelectionPrintInfoItem();
			boundsSelectionPrintInfoItem.PageIndex = pageIndex;
			boundsSelectionPrintInfoItem.ViewBounds = bounds;
			Add(boundsSelectionPrintInfoItem);
			return boundsSelectionPrintInfoItem;
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public BoundsSelectionPrintInfo Clone()
		{
			BoundsSelectionPrintInfo boundsSelectionPrintInfo = new BoundsSelectionPrintInfo();
			boundsSelectionPrintInfo._Enable = _Enable;
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BoundsSelectionPrintInfoItem current = enumerator.Current;
					boundsSelectionPrintInfo.Add(current.Clone());
				}
			}
			return boundsSelectionPrintInfo;
		}
	}
}
