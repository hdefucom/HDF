using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[InterfaceType(1)]
	[Guid("56A868B7-0AD4-11CE-B03A-0020AF0BA770")]
	public interface GInterface43
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_0([MarshalAs(UnmanagedType.Interface)] out GInterface42 ginterface42_0, [In] double double_0, [In] ref Guid guid_0, [In] int int_0, [In] short short_0, [In] int int_1, [In] [MarshalAs(UnmanagedType.Struct)] ref object object_0, [In] [Out] [MarshalAs(UnmanagedType.Struct)] ref object object_1, out short short_1);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_1([MarshalAs(UnmanagedType.Interface)] out GInterface42 ginterface42_0, [In] double double_0, [In] ref Guid guid_0, [In] int int_0, [In] short short_0, [In] int int_1, [In] [MarshalAs(UnmanagedType.Struct)] ref object object_0, [In] [Out] [MarshalAs(UnmanagedType.Struct)] ref object object_1, out short short_1);
	}
}
