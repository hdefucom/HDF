using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlLostFocusEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlLostFocusEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
