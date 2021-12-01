using DCSoft.WinForms.Controls;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxDCCardListViewControl 事件的COM接口</summary>
	[ComVisible(true)]
	[Guid("39655E71-F969-4804-B3B9-A43B0CD30AA2")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IAxDCCardListViewControlComEvents
	{
		/// <summary> COMEventItemMouseClick 事件</summary>
		[DispId(34)]
		void COMEventItemMouseClick(DCCardListViewMouseEventArgs args);

		/// <summary> EventItemMouseClick 事件</summary>
		[DispId(2)]
		void EventItemMouseClick([MarshalAs(UnmanagedType.AsAny)] object sender, DCCardListViewMouseEventArgs e);
	}
}
