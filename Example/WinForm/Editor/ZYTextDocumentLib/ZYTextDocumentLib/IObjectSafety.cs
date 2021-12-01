using System.Runtime.InteropServices;

namespace ZYTextDocumentLib
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("CB5BDC81-93C1-11CF-8F20-00805F2CD064")]
	public interface IObjectSafety
	{
		void GetInterfacceSafyOptions(int riid, out int pdwSupportedOptions, out int pdwEnabledOptions);

		void SetInterfaceSafetyOptions(int riid, int dwOptionsSetMask, int dwEnabledOptions);
	}
}
