using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>PageImageInfo 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("48D5E1AE-B081-4987-A1C8-E15D6127B93C")]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IPageImageInfo
	{
		/// <summary>属性Image</summary>
		[DispId(3)]
		XImageValue Image
		{
			get;
			set;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(4)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>方法Clone</summary>
		[DispId(2)]
		PageImageInfo Clone();
	}
}
