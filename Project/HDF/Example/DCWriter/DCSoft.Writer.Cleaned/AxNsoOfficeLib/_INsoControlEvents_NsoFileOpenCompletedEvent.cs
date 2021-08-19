using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoFileOpenCompletedEvent
	{
		public string sPath;

		public string sReserve;

		public _INsoControlEvents_NsoFileOpenCompletedEvent(string sPath, string sReserve)
		{
			this.sPath = sPath;
			this.sReserve = sReserve;
		}
	}
}
