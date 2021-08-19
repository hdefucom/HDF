using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextDocument 事件的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("6A816920-3A16-40C6-93CF-6C24F1EBCBBE")]
	[ComVisible(true)]
	public interface IXTextDocumentComEvents
	{
		/// <summary> DocumentContentChanged 事件</summary>
		[DispId(193)]
		void DocumentContentChanged([MarshalAs(UnmanagedType.AsAny)] object sender, EventArgs e);

		/// <summary> DocumentLoad 事件</summary>
		[DispId(194)]
		void DocumentLoad([MarshalAs(UnmanagedType.AsAny)] object sender, EventArgs e);

		/// <summary> EventAfterPaintElement 事件</summary>
		[DispId(195)]
		void EventAfterPaintElement([MarshalAs(UnmanagedType.AsAny)] object sender, ElementPaintEventArgs e);

		/// <summary> EventBeforePaintElement 事件</summary>
		[DispId(196)]
		void EventBeforePaintElement([MarshalAs(UnmanagedType.AsAny)] object sender, ElementPaintEventArgs e);

		/// <summary> EventBeginPrint 事件</summary>
		[DispId(197)]
		void EventBeginPrint([MarshalAs(UnmanagedType.AsAny)] object sender, WriterPrintEventEventArgs e);

		/// <summary> EventElementValidating 事件</summary>
		[DispId(198)]
		void EventElementValidating([MarshalAs(UnmanagedType.AsAny)] object sender, ElementValidatingEventArgs e);

		/// <summary> EventEndPrint 事件</summary>
		[DispId(199)]
		void EventEndPrint([MarshalAs(UnmanagedType.AsAny)] object sender, WriterPrintEventEventArgs e);

		/// <summary> EventExpressionFunction 事件</summary>
		[DispId(200)]
		void EventExpressionFunction([MarshalAs(UnmanagedType.AsAny)] object sender, WriterExpressionFunctionEventArgs e);

		/// <summary> EventPrintPage 事件</summary>
		[DispId(201)]
		void EventPrintPage([MarshalAs(UnmanagedType.AsAny)] object sender, WriterPrintPageEventEventArgs e);

		/// <summary> EventPrintQueryPageSettings 事件</summary>
		[DispId(202)]
		void EventPrintQueryPageSettings([MarshalAs(UnmanagedType.AsAny)] object sender, WriterPrintQueryPageSettingsEventArgs e);

		/// <summary> SelectionChanged 事件</summary>
		[DispId(203)]
		void SelectionChanged([MarshalAs(UnmanagedType.AsAny)] object sender, EventArgs e);

		/// <summary> SelectionChanging 事件</summary>
		[DispId(204)]
		void SelectionChanging([MarshalAs(UnmanagedType.AsAny)] object sender, SelectionChangingEventArgs e);
	}
}
