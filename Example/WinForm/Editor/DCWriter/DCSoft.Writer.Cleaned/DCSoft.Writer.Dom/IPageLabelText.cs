using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>PageLabelText 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("2B691831-D0C3-42C3-9FE3-43B7BD23AAFB")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public interface IPageLabelText
	{
		/// <summary>属性PageIndex</summary>
		[DispId(3)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(4)]
		string Text
		{
			get;
			set;
		}

		/// <summary>方法Clone</summary>
		[DispId(2)]
		PageLabelText Clone();
	}
}
