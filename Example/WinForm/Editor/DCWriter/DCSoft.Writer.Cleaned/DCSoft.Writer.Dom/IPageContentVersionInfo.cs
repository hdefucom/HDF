using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>PageContentVersionInfo 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("262854DB-5809-4058-A8D3-6473B5B4390B")]
	public interface IPageContentVersionInfo
	{
		/// <summary>属性PageIndex</summary>
		[DispId(2)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性Version</summary>
		[DispId(3)]
		string Version
		{
			get;
			set;
		}
	}
}
