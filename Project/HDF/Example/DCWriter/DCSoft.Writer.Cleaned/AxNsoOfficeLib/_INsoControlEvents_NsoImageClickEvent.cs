using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoImageClickEvent
	{
		public string sName;

		public _INsoControlEvents_NsoImageClickEvent(string sName)
		{
			this.sName = sName;
		}
	}
}
