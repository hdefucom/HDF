using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoFileModifyChangedEvent
	{
		public bool bModify;

		public _INsoControlEvents_NsoFileModifyChangedEvent(bool bModify)
		{
			this.bModify = bModify;
		}
	}
}
