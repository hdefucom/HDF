using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>
	///       打印的各页的信息
	///       </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ComDefaultInterface(typeof(IPrintPageResult))]
	[Guid("2CB5443F-42FF-4F6B-82B4-E3FA045C8B66")]
	
	public class PrintPageResult : IPrintPageResult
	{
		private int _TickSpan = 0;

		private PrintPage _Page = null;

		private int _PageIndex = 0;

		private float _ContentHeight = 0f;

		private float _StartPositionInPage = 0f;

		private float _EndPositionInPage = 0f;

		private float _ContentHeightPrinted = 0f;

		/// <summary>
		///       消耗的毫秒数
		///       </summary>
		public int TickSpan
		{
			get
			{
				return _TickSpan;
			}
			set
			{
				_TickSpan = value;
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
		///       页码
		///       </summary>
		public int PageIndex
		{
			get
			{
				if (_Page == null)
				{
					return _PageIndex;
				}
				return _Page.GlobalIndex;
			}
			set
			{
				_PageIndex = value;
			}
		}

		/// <summary>
		///       页面内容高度
		///       </summary>
		public float ContentHeight
		{
			get
			{
				return _ContentHeight;
			}
			set
			{
				_ContentHeight = value;
			}
		}

		/// <summary>
		///       打印开始位置在页面中的位置，打印内容的上边缘到纸张上边缘的距离。采用文档单位（document.DcoumentGraphicsUnit相同单位）。
		///       </summary>
		public float StartPositionInPage
		{
			get
			{
				return _StartPositionInPage;
			}
			set
			{
				_StartPositionInPage = value;
			}
		}

		/// <summary>
		///       打印结束位置，从纸张上边缘到打印的内容的最下边缘的距离。采用文档单位（document.DcoumentGraphicsUnit相同单位）。
		///       </summary>
		public float EndPositionInPage
		{
			get
			{
				return _EndPositionInPage;
			}
			set
			{
				_EndPositionInPage = value;
			}
		}

		/// <summary>
		///       实际打印的内容高度。采用文档单位（document.DcoumentGraphicsUnit相同单位）。
		///       </summary>
		public float ContentHeightPrinted
		{
			get
			{
				return _ContentHeightPrinted;
			}
			set
			{
				_ContentHeightPrinted = value;
			}
		}
	}
}
