using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNetDogStatusEvent
	{
		public int nStatus;

		public _INsoControlEvents_NsoNetDogStatusEvent(int nStatus)
		{
			this.nStatus = nStatus;
		}
	}
}
