using System.Drawing;

namespace ZYCommon
{
	public delegate bool CaptureDragRectangleHandler(Rectangle SourceRect, ref Rectangle CurrentRect, int DragStyle);
}
