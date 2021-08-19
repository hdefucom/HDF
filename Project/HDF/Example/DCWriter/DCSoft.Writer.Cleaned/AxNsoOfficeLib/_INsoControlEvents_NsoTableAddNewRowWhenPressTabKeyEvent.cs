using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoTableAddNewRowWhenPressTabKeyEvent
	{
		public string sTableName;

		public _INsoControlEvents_NsoTableAddNewRowWhenPressTabKeyEvent(string sTableName)
		{
			this.sTableName = sTableName;
		}
	}
}
