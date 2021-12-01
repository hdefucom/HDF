using DCSoft.FriedmanCurveChart;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxFriedmanCurveControl 事件的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("3BA92EF4-5C99-456C-B6C1-03DFAB8B5AD4")]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[Browsable(false)]
	public interface IAxFriedmanCurveControlComEvents
	{
		/// <summary> EventAfterRefreshView 事件</summary>
		[DispId(2)]
		void EventAfterRefreshView([MarshalAs(UnmanagedType.AsAny)] object sender, EventArgs e);

		/// <summary> EventDocumentDblClick 事件</summary>
		[DispId(3)]
		void EventDocumentDblClick([MarshalAs(UnmanagedType.AsAny)] object sender, FCDocumentDblClickEventArgs e);

		/// <summary> EventEditValuePoint 事件</summary>
		[DispId(4)]
		void EventEditValuePoint([MarshalAs(UnmanagedType.AsAny)] object sender, FCEditValuePointEventArgs e);

		/// <summary> EventLinkClick 事件</summary>
		[DispId(5)]
		void EventLinkClick([MarshalAs(UnmanagedType.AsAny)] object sender, FCDocumentLinkClickEventArgs e);

		/// <summary> EventValuePointClick 事件</summary>
		[DispId(6)]
		void EventValuePointClick([MarshalAs(UnmanagedType.AsAny)] object sender, FCValuePointClickEventArgs e);
	}
}
