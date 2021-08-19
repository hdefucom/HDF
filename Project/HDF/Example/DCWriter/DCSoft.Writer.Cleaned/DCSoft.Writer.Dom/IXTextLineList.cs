using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextLineList 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("6C5B2797-EE70-4854-851A-9802A4D73530")]
	[ComVisible(true)]
	public interface IXTextLineList
	{
		/// <summary>属性Count</summary>
		[DispId(5)]
		int Count
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(6)]
		XTextLine this[int index]
		{
			get;
			set;
		}
	}
}
