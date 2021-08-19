using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoDragAndDropCompletedEvent
	{
		public string sContent;

		public _INsoControlEvents_NsoDragAndDropCompletedEvent(string sContent)
		{
			this.sContent = sContent;
		}
	}
}
