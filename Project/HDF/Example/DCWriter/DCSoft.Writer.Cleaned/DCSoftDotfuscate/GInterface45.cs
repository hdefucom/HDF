using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[Guid("56A868BA-0AD4-11CE-B03A-0020AF0BA770")]
	[TypeLibType(4160)]
	public interface GInterface45
	{
		[DispId(1610743809)]
		string Name
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1610743809)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743808)]
		void imethod_0([In] [MarshalAs(UnmanagedType.BStr)] string string_0, [MarshalAs(UnmanagedType.IDispatch)] out object object_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743810)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string imethod_1();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743811)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object imethod_2();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743812)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object imethod_3();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743813)]
		int imethod_4();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743814)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string imethod_5();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743814)]
		void imethod_6([In] [MarshalAs(UnmanagedType.BStr)] string string_0);
	}
}
