using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoRButtonUpEvent
	{
		public int xPos;

		public int yPos;

		public _INsoControlEvents_NsoRButtonUpEvent(int xPos, int yPos)
		{
			this.xPos = xPos;
			this.yPos = yPos;
		}
	}
}
