using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>DCTestControl 事件的COM接口</summary>
	[Guid("0E0098EB-FE7B-4849-9FC8-C7CC69F8F18B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IDCTestControlComEvents
	{
		/// <summary> MyLinkEvent 事件</summary>
		[DispId(9)]
		void MyLinkEvent([MarshalAs(UnmanagedType.AsAny)] object sender, WriterLinkEventArgs e);

		/// <summary> MyVoidEvent 事件</summary>
		[DispId(10)]
		void MyVoidEvent();
	}
}
