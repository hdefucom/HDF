using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoFileSavedCompletedEvent
	{
		public string sName;

		public _INsoControlEvents_NsoFileSavedCompletedEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
