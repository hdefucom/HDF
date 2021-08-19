using DCSoft.Common;
using DCSoft.Drawing;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       页码图片信息对象
	///       </summary>
	[Serializable]
	[ComDefaultInterface(typeof(IPageImageInfo))]
	[ComClass("34F37673-BF4C-4F24-B9AC-23443C17C058", "48D5E1AE-B081-4987-A1C8-E15D6127B93C")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("34F37673-BF4C-4F24-B9AC-23443C17C058")]
	[DocumentComment]
	public class PageImageInfo : IPageImageInfo
	{
		internal const string string_0 = "34F37673-BF4C-4F24-B9AC-23443C17C058";

		internal const string string_1 = "48D5E1AE-B081-4987-A1C8-E15D6127B93C";

		private int int_0 = 0;

		private XImageValue ximageValue_0 = null;

		/// <summary>
		///       从0开始计算的页码
		///       </summary>
		[DefaultValue(0)]
		[ComVisible(true)]
		public int PageIndex
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		/// <summary>
		///       图片值
		///       </summary>
		[DefaultValue(null)]
		public XImageValue Image
		{
			get
			{
				return ximageValue_0;
			}
			set
			{
				ximageValue_0 = value;
			}
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public PageImageInfo Clone()
		{
			PageImageInfo pageImageInfo = new PageImageInfo();
			pageImageInfo.int_0 = int_0;
			if (ximageValue_0 != null)
			{
				pageImageInfo.ximageValue_0 = ximageValue_0.Clone();
			}
			return pageImageInfo;
		}
	}
}
