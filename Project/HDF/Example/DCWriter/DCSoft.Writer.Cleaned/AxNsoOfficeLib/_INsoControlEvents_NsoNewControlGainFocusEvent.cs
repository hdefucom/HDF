using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlGainFocusEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlGainFocusEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
