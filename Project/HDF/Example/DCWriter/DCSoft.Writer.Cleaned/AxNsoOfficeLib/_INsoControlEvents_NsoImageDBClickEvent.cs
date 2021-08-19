using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoImageDBClickEvent
	{
		public string sName;

		public _INsoControlEvents_NsoImageDBClickEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
