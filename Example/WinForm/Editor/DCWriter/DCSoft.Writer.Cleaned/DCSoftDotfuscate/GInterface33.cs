using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[TypeLibType(4160)]
	[Guid("56A868B9-0AD4-11CE-B03A-0020AF0BA770")]
	public interface GInterface33
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743808)]
		int imethod_0();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743809)]
		void imethod_1([In] int int_0, [MarshalAs(UnmanagedType.IUnknown)] out object object_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743810)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object imethod_2();
	}
}
