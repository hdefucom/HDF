using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoSectionInsertOrDelEventEvent
	{
		public int nEventType;

		public string sName;

		public _INsoControlEvents_NsoSectionInsertOrDelEventEvent(string sName, int nEventType)
		{
			this.sName = sName;
			this.nEventType = nEventType;
		}
	}
}
