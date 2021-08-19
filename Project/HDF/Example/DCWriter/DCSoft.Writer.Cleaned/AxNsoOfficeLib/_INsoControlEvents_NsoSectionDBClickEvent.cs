using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoSectionDBClickEvent
	{
		public string sName;

		public _INsoControlEvents_NsoSectionDBClickEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
