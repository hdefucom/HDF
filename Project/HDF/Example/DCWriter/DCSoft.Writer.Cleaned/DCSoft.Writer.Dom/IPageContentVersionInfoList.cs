using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>PageContentVersionInfoList 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("370C8B59-4ECB-4573-B420-30491BDBDE51")]
	public interface IPageContentVersionInfoList
	{
		/// <summary>属性Count</summary>
		[DispId(2)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(3)]
		PageContentVersionInfo this[int index]
		{
			get;
			set;
		}
	}
}
