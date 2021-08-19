using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoRadioButtonCheckChangedEvent
	{
		public int newCheckIndex;

		public int oldCheckIndex;

		public string sName;

		public _INsoControlEvents_NsoRadioButtonCheckChangedEvent(string sName, int oldCheckIndex, int newCheckIndex)
		{
			this.sName = sName;
			this.oldCheckIndex = oldCheckIndex;
			this.newCheckIndex = newCheckIndex;
		}
	}
}
