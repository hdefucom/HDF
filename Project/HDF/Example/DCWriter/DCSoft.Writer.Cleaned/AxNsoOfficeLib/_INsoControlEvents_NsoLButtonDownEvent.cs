using System.Runtime.InteropServices;

namespace AxNsoOfficeLib
{
	[ComVisible(false)]
	public class _INsoControlEvents_NsoLButtonDownEvent
	{
		public int xPos;

		public int yPos;

		public _INsoControlEvents_NsoLButtonDownEvent(int xPos, int yPos)
		{
			this.xPos = xPos;
			this.yPos = yPos;
		}
	}
}
