using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[TypeLibType(4160)]
	[Guid("56A868B1-0AD4-11CE-B03A-0020AF0BA770")]
	public interface GInterface34
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743808)]
		void imethod_0();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743809)]
		void imethod_1();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743810)]
		void imethod_2();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743811)]
		void imethod_3([In] int int_0, out int int_1);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743812)]
		void imethod_4([In] [MarshalAs(UnmanagedType.BStr)] string string_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743813)]
		void imethod_5([In] [MarshalAs(UnmanagedType.BStr)] string string_0, [MarshalAs(UnmanagedType.IDispatch)] out object object_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object imethod_6();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743815)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object imethod_7();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743816)]
		void imethod_8();
	}
}
