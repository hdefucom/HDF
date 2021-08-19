using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[InterfaceType(1)]
	[Guid("56A868B8-0AD4-11CE-B03A-0020AF0BA770")]
	public interface GInterface42
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_0();

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_1(out int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_2([In] double double_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_3([MarshalAs(UnmanagedType.Error)] out int int_0);
	}
}
