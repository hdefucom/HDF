using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>ElementEventTemplate 事件的COM接口</summary>
	[Guid("2C834075-AF5D-46C2-9415-83E93EC39519")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[ComVisible(true)]
	public interface IElementEventTemplateComEvents
	{
		/// <summary> AfterPaint 事件</summary>
		[DispId(12340)]
		void AfterPaint([MarshalAs(UnmanagedType.AsAny)] object sender, ElementPaintEventArgs e);

		/// <summary> BeforeDropDown 事件</summary>
		[DispId(12363)]
		void BeforeDropDown([MarshalAs(UnmanagedType.AsAny)] object sender, ElementCancelEventArgs e);

		/// <summary> BeforePaint 事件</summary>
		[DispId(12341)]
		void BeforePaint([MarshalAs(UnmanagedType.AsAny)] object sender, ElementPaintEventArgs e);

		/// <summary> ContentChanged 事件</summary>
		[DispId(12342)]
		void ContentChanged([MarshalAs(UnmanagedType.AsAny)] object sender, ContentChangedEventArgs e);

		/// <summary> ContentChanging 事件</summary>
		[DispId(12343)]
		void ContentChanging([MarshalAs(UnmanagedType.AsAny)] object sender, ContentChangingEventArgs e);

		/// <summary> Expression 事件</summary>
		[DispId(12344)]
		void Expression([MarshalAs(UnmanagedType.AsAny)] object sender, ElementExpressionEventArgs e);

		/// <summary> GotFocus 事件</summary>
		[DispId(12345)]
		void GotFocus([MarshalAs(UnmanagedType.AsAny)] object sender, ElementEventArgs e);

		/// <summary> KeyDown 事件</summary>
		[DispId(12346)]
		void KeyDown([MarshalAs(UnmanagedType.AsAny)] object sender, ElementKeyEventArgs e);

		/// <summary> KeyPress 事件</summary>
		[DispId(12347)]
		void KeyPress([MarshalAs(UnmanagedType.AsAny)] object sender, ElementKeyEventArgs e);

		/// <summary> KeyUp 事件</summary>
		[DispId(12348)]
		void KeyUp([MarshalAs(UnmanagedType.AsAny)] object sender, ElementKeyEventArgs e);

		/// <summary> Load 事件</summary>
		[DispId(12349)]
		void Load([MarshalAs(UnmanagedType.AsAny)] object sender, ElementLoadEventArgs e);

		/// <summary> LostFocus 事件</summary>
		[DispId(12350)]
		void LostFocus([MarshalAs(UnmanagedType.AsAny)] object sender, ElementEventArgs e);

		/// <summary> MouseClick 事件</summary>
		[DispId(12351)]
		void MouseClick([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> MouseDblClick 事件</summary>
		[DispId(12352)]
		void MouseDblClick([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> MouseDown 事件</summary>
		[DispId(12353)]
		void MouseDown([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> MouseEnter 事件</summary>
		[DispId(12354)]
		void MouseEnter([MarshalAs(UnmanagedType.AsAny)] object sender, ElementEventArgs e);

		/// <summary> MouseLeave 事件</summary>
		[DispId(12355)]
		void MouseLeave([MarshalAs(UnmanagedType.AsAny)] object sender, ElementEventArgs e);

		/// <summary> MouseMove 事件</summary>
		[DispId(12356)]
		void MouseMove([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> MouseUp 事件</summary>
		[DispId(12357)]
		void MouseUp([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> QueryState 事件</summary>
		[DispId(12358)]
		void QueryState([MarshalAs(UnmanagedType.AsAny)] object sender, ElementQueryStateEventArgs e);

		/// <summary> Validated 事件</summary>
		[DispId(12359)]
		void Validated([MarshalAs(UnmanagedType.AsAny)] object sender, ElementEventArgs e);

		/// <summary> Validating 事件</summary>
		[DispId(12360)]
		void Validating([MarshalAs(UnmanagedType.AsAny)] object sender, ElementValidatingEventArgs e);
	}
}
