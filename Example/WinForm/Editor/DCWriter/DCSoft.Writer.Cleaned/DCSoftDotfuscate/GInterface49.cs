using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[Guid("BC9BCF80-DCD2-11D2-ABF6-00A0C905F375")]
	[TypeLibType(4160)]
	public interface GInterface49
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743808)]
		void imethod_0();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743809)]
		int imethod_1();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743810)]
		void imethod_2([In] int int_0, [MarshalAs(UnmanagedType.BStr)] out string string_0, out int int_1, out double double_0, out double double_1, out double double_2, out double double_3, out double double_4);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743811)]
		void imethod_3([In] [MarshalAs(UnmanagedType.BStr)] string string_0, out int int_0, out int int_1, out double double_0, out double double_1, out double double_2, out double double_3, out double double_4);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743812)]
		void imethod_4([In] [MarshalAs(UnmanagedType.BStr)] string string_0, [In] int int_0, out int int_1);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743813)]
		void imethod_5([In] int int_0, [In] double double_0);
	}
}
