using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       Import the IObjectSaftety COM Interface. 
	///       See http://www.cnblogs.com/shuang121/archive/2012/06/04/2534296.html 
	///       </summary>
	[ComImport]
	[Guid("CB5BDC81-93C1-11CF-8F20-00805F2CD064")]
	[ComVisible(true)]
	[DCInternal]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IObjectSafety
	{
		[PreserveSig]
		int GetInterfaceSafetyOptions(ref Guid riid, [MarshalAs(UnmanagedType.U4)] ref int pdwSupportedOptions, [MarshalAs(UnmanagedType.U4)] ref int pdwEnabledOptions);

		[PreserveSig]
		int SetInterfaceSafetyOptions(ref Guid riid, [MarshalAs(UnmanagedType.U4)] int dwOptionSetMask, [MarshalAs(UnmanagedType.U4)] int dwEnabledOptions);
	}
}
