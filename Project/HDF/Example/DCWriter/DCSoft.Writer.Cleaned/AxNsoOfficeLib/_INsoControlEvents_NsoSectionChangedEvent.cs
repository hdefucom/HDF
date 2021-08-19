using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoSectionChangedEvent
	{
		public string sName;

		public _INsoControlEvents_NsoSectionChangedEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
