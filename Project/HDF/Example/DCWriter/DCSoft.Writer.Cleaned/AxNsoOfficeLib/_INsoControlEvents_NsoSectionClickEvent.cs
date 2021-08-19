using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoSectionClickEvent
	{
		public string sName;

		public _INsoControlEvents_NsoSectionClickEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
