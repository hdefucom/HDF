using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlChangedEvent
	{
		public string sName;

		public _INsoControlEvents_NsoNewControlChangedEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
