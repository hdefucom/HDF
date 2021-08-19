using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoAuthorityStatusEvent
	{
		public int nStatus;

		public _INsoControlEvents_NsoAuthorityStatusEvent(int nStatus)
		{
			this.nStatus = nStatus;
		}
	}
}
