using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlBeforeDropDownEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlBeforeDropDownEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
