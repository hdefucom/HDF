using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms.Controls
{
	/// <summary>DCCardListViewMouseEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("E0A60DF4-79A4-43D9-A941-521D78F7DF7F")]
	[ComVisible(true)]
	public interface IDCCardListViewMouseEventArgs
	{
		/// <summary>属性Button</summary>
		[DispId(2)]
		MouseButtons Button
		{
			get;
		}

		/// <summary>属性Click</summary>
		[DispId(3)]
		int Click
		{
			get;
		}

		/// <summary>属性Item</summary>
		[DispId(4)]
		DCCardListViewItem Item
		{
			get;
		}

		/// <summary>属性LeftButton</summary>
		[DispId(7)]
		bool LeftButton
		{
			get;
		}

		/// <summary>属性RightButton</summary>
		[DispId(8)]
		bool RightButton
		{
			get;
		}

		/// <summary>属性X</summary>
		[DispId(5)]
		int X
		{
			get;
		}

		/// <summary>属性Y</summary>
		[DispId(6)]
		int Y
		{
			get;
		}
	}
}
