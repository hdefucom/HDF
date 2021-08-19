using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoNewControlInsertOrDelEventEvent
	{
		public int nEventType;

		public string sName;

		public string sParentSection;

		public _INsoControlEvents_NsoNewControlInsertOrDelEventEvent(string sName, string sParentSection, int nEventType)
		{
			this.sName = sName;
			this.sParentSection = sParentSection;
			this.nEventType = nEventType;
		}
	}
}
