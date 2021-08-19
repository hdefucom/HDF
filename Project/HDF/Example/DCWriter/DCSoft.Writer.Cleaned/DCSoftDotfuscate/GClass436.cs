using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass436
	{
		private Rectangle rectangle_0 = Rectangle.Empty;

		public void method_0()
		{
			rectangle_0 = Rectangle.Empty;
		}

		public void method_1(Rectangle rectangle_1)
		{
			if (rectangle_0.IsEmpty)
			{
				rectangle_0 = rectangle_1;
			}
			else
			{
				rectangle_0 = Rectangle.Union(rectangle_0, rectangle_1);
			}
		}

		public void method_2(int int_0, int int_1, int int_2, int int_3)
		{
			method_1(new Rectangle(int_0, int_1, int_2, int_3));
		}

		public bool method_3()
		{
			return rectangle_0.IsEmpty;
		}

		public Rectangle method_4()
		{
			return rectangle_0;
		}
	}
}
