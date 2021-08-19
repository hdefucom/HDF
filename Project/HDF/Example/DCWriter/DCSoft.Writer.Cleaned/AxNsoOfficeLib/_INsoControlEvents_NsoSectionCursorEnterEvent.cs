using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoSectionCursorEnterEvent
	{
		public string sName;

		public _INsoControlEvents_NsoSectionCursorEnterEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
