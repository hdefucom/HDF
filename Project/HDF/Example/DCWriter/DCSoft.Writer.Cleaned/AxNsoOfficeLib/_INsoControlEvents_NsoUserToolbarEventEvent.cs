using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoUserToolbarEventEvent
	{
		public int nID;

		public string sRev1;

		public string sRev2;

		public _INsoControlEvents_NsoUserToolbarEventEvent(int nID, string sRev1, string sRev2)
		{
			this.nID = nID;
			this.sRev1 = sRev1;
			this.sRev2 = sRev2;
		}
	}
}
