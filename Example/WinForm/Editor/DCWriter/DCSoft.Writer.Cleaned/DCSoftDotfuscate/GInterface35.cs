using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[TypeLibType(4160)]
	[Guid("56A868B6-0AD4-11CE-B03A-0020AF0BA770")]
	public interface GInterface35
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743808)]
		void imethod_0([ComAliasName("QuartzTypeLib.LONG_PTR")] out int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743809)]
		void imethod_1(out int int_0, [ComAliasName("QuartzTypeLib.LONG_PTR")] out int int_1, [ComAliasName("QuartzTypeLib.LONG_PTR")] out int int_2, [In] int int_3);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743810)]
		void imethod_2([In] int int_0, out int int_1);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743811)]
		void imethod_3([In] int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743812)]
		void imethod_4([In] int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743813)]
		void imethod_5([In] int int_0, [In] [ComAliasName("QuartzTypeLib.LONG_PTR")] int int_1, [In] [ComAliasName("QuartzTypeLib.LONG_PTR")] int int_2);
	}
}
