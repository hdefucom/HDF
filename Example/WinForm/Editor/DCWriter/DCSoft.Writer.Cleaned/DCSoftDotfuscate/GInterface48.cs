using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[TypeLibType(4160)]
	[Guid("56A868BD-0AD4-11CE-B03A-0020AF0BA770")]
	public interface GInterface48
	{
		[DispId(1610743812)]
		string Name
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1610743812)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743808)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object imethod_0();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743809)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object imethod_1();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743810)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object imethod_2();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743811)]
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
		[DispId(1610743815)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		object imethod_6();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743816)]
		void imethod_7([In] [MarshalAs(UnmanagedType.IUnknown)] object object_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743817)]
		void imethod_8([In] [MarshalAs(UnmanagedType.IUnknown)] object object_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743818)]
		void imethod_9([In] [MarshalAs(UnmanagedType.IUnknown)] object object_0, [In] [MarshalAs(UnmanagedType.IDispatch)] object object_1);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743819)]
		void imethod_10();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743820)]
		void imethod_11();
	}
}
