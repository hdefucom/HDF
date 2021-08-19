using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoBeforeFilePrintedExEvent
	{
		public bool bCancel;

		public _INsoControlEvents_NsoBeforeFilePrintedExEvent(bool bCancel)
		{
			this.bCancel = bCancel;
		}
	}
}
