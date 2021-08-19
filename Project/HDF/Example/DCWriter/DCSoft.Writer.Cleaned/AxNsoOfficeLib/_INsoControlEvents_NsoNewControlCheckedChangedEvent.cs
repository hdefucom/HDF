using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlCheckedChangedEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlCheckedChangedEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
