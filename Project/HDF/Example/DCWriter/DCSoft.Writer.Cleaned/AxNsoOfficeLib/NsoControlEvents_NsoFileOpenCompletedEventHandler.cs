using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[Guid("FCDC456D-B7F2-4F62-A9C8-03E88C9FCD47")]
	[ComVisible(true)]
	public delegate void NsoControlEvents_NsoFileOpenCompletedEventHandler(string sPath, string sReserve);
}
