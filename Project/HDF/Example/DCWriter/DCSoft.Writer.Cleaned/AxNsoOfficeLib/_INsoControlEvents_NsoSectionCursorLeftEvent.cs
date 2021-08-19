using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoSectionCursorLeftEvent
	{
		public string sName;

		public _INsoControlEvents_NsoSectionCursorLeftEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
