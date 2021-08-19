using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoRegionDBClickEvent
	{
		public string sName;

		public _INsoControlEvents_NsoRegionDBClickEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
