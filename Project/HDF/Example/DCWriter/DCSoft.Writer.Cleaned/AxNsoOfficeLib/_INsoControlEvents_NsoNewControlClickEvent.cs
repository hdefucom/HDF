using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlClickEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlClickEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
