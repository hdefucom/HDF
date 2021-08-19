using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoRegionLostFocusEvent
	{
		public string sName;

		public _INsoControlEvents_NsoRegionLostFocusEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
