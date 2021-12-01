using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>DCCardListViewEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("9A314854-FC21-4459-A99D-120AE0A54ED8")]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDCCardListViewEventArgs
	{
		/// <summary>属性Item</summary>
		[DispId(2)]
		DCCardListViewItem Item
		{
			get;
		}
	}
}
