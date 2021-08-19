using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoSectionGainFocusEvent
	{
		public string sName;

		public _INsoControlEvents_NsoSectionGainFocusEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
