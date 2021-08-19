using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlDBClickEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlDBClickEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
