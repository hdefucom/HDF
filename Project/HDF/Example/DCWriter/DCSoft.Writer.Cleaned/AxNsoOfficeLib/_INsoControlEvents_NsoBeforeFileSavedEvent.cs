using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoBeforeFileSavedEvent
	{
		public bool bCancel;

		public string sName;

		public _INsoControlEvents_NsoBeforeFileSavedEvent(string sName, bool bCancel)
		{
			this.sName = sName;
			this.bCancel = bCancel;
		}
	}
}
