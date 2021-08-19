using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[Guid("56A868C0-0AD4-11CE-B03A-0020AF0BA770")]
	[TypeLibType(4096)]
	public interface GInterface36 : GInterface35
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_6([ComAliasName("QuartzTypeLib.LONG_PTR")] out int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_7(out int int_0, [ComAliasName("QuartzTypeLib.LONG_PTR")] out int int_1, [ComAliasName("QuartzTypeLib.LONG_PTR")] out int int_2, [In] int int_3);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_8([In] int int_0, out int int_1);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_9([In] int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_10([In] int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_11([In] int int_0, [In] [ComAliasName("QuartzTypeLib.LONG_PTR")] int int_1, [In] [ComAliasName("QuartzTypeLib.LONG_PTR")] int int_2);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_12([In] [ComAliasName("QuartzTypeLib.LONG_PTR")] int int_0, [In] int int_1, [In] [ComAliasName("QuartzTypeLib.LONG_PTR")] int int_2);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_13([In] int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void imethod_14(out int int_0);
	}
}
