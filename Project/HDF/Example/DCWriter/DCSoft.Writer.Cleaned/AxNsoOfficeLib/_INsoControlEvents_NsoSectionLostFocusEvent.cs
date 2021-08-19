using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoSectionLostFocusEvent
	{
		public string sName;

		public _INsoControlEvents_NsoSectionLostFocusEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
