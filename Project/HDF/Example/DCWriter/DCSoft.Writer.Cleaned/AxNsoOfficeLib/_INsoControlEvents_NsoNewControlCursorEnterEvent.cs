using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlCursorEnterEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlCursorEnterEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
