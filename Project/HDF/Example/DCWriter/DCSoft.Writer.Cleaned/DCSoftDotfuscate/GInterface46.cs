using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComImport]
	[Guid("56A868BB-0AD4-11CE-B03A-0020AF0BA770")]
	[TypeLibType(4160)]
	public interface GInterface46
	{
		[DispId(1610743808)]
		string Name
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[DispId(1610743808)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[DispId(1610743809)]
		void imethod_0([MarshalAs(UnmanagedType.IDispatch)] out object object_0);
	}
}
