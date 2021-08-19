using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlDropDownEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlDropDownEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
