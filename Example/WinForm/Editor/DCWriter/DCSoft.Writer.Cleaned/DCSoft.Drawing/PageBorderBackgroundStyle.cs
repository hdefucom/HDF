using DCSoft.Common;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       页面边框和背景样式
	///       </summary>
	[Serializable]
	[Guid("B4103AA3-524C-4E7A-98D2-4E34CFDE7AD0")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(IPageBorderBackgroundStyle))]
	
	[ComVisible(true)]
	public class PageBorderBackgroundStyle : ContentStyle, IPageBorderBackgroundStyle
	{
		private PageBorderRangeTypes _BorderRange = PageBorderRangeTypes.Body;

		/// <summary>
		///       页面边框范围
		///       </summary>
		[DefaultValue(PageBorderRangeTypes.None)]
		public PageBorderRangeTypes BorderRange
		{
			get
			{
				return _BorderRange;
			}
			set
			{
				_BorderRange = value;
			}
		}
	}
}
