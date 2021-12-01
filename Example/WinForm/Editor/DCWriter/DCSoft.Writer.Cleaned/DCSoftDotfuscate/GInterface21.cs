using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[Guid("7BF80981-BF32-101A-8BBB-00AA00300CAB")]
	[InterfaceType(2)]
	[ComConversionLoss]
	[DefaultMember("Handle")]
	public interface GInterface21
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(0)]
		int imethod_0();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(2)]
		int imethod_1();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(2)]
		void imethod_2(int int_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(3)]
		short imethod_3();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(4)]
		int imethod_4();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(5)]
		int imethod_5();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[DispId(6)]
		void imethod_6(int int_0, int int_1, int int_2, int int_3, int int_4, [ComAliasName("stdole.OLE_XPOS_HIMETRIC")] int int_5, [ComAliasName("stdole.OLE_YPOS_HIMETRIC")] int int_6, [ComAliasName("stdole.OLE_XSIZE_HIMETRIC")] int int_7, [ComAliasName("stdole.OLE_YSIZE_HIMETRIC")] int int_8, IntPtr intptr_0);
	}
}
