using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass437
	{
		private RectangleF rectangleF_0 = RectangleF.Empty;

		public void method_0()
		{
			rectangleF_0 = RectangleF.Empty;
		}

		public void method_1(RectangleF rectangleF_1)
		{
			if (rectangleF_0.IsEmpty)
			{
				rectangleF_0 = rectangleF_1;
			}
			else
			{
				rectangleF_0 = RectangleF.Union(rectangleF_0, rectangleF_1);
			}
		}

		public void method_2(float float_0, float float_1, float float_2, float float_3)
		{
			method_1(new RectangleF(float_0, float_1, float_2, float_3));
		}

		public bool method_3()
		{
			return rectangleF_0.IsEmpty;
		}

		public RectangleF method_4()
		{
			return rectangleF_0;
		}
	}
}
