using DCSoft.TemperatureChart;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxTemperatureControl 事件的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[Browsable(false)]
	[Guid("9BBA47B8-3E76-4D24-BD80-54E148043797")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	public interface IAxTemperatureControlComEvents
	{
		/// <summary> EventAfterRefreshView 事件</summary>
		[DispId(45)]
		void EventAfterRefreshView([MarshalAs(UnmanagedType.AsAny)] object sender, EventArgs e);

		/// <summary> EventDocumentDblClick 事件</summary>
		[DispId(38)]
		void EventDocumentDblClick([MarshalAs(UnmanagedType.AsAny)] object sender, DocumentDblClickEventArgs e);

		/// <summary> EventEditValuePoint 事件</summary>
		[DispId(46)]
		void EventEditValuePoint([MarshalAs(UnmanagedType.AsAny)] object sender, EditValuePointEventArgs e);

		/// <summary> EventLinkClick 事件</summary>
		[DispId(51)]
		void EventLinkClick([MarshalAs(UnmanagedType.AsAny)] object sender, DocumentLinkClickEventArgs e);

		/// <summary> EventValuePointClick 事件</summary>
		[DispId(25)]
		void EventValuePointClick([MarshalAs(UnmanagedType.AsAny)] object sender, ValuePointClickEventArgs e);
	}
}
