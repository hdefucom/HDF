using System.Drawing;

namespace XDesignerGUI
{
	public class RectangleCounter
	{
		private Rectangle myRect = Rectangle.Empty;

		public bool IsEmpty => myRect.IsEmpty;

		public Rectangle Value => myRect;

		public void Clear()
		{
			myRect = Rectangle.Empty;
		}

		public void Add(Rectangle rect)
		{
			if (myRect.IsEmpty)
			{
				myRect = rect;
			}
			else
			{
				myRect = Rectangle.Union(myRect, rect);
			}
		}

		public void Add(int left, int top, int width, int height)
		{
			Add(new Rectangle(left, top, width, height));
		}
	}
}
