using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlCursorLeftEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlCursorLeftEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
