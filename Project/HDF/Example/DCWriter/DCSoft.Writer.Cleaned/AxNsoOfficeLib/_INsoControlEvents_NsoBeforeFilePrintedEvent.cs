using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoBeforeFilePrintedEvent
	{
		public string sName;

		public _INsoControlEvents_NsoBeforeFilePrintedEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
