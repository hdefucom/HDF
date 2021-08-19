using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoRegionChangedEvent
	{
		public string sName;

		public _INsoControlEvents_NsoRegionChangedEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
