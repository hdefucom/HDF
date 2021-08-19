using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass257
	{
		public const int int_0 = 8;

		public static void smethod_0(Graphics graphics_0, Rectangle rectangle_0, bool bool_0)
		{
			if (graphics_0 != null)
			{
				graphics_0.FillRectangle(SystemBrushes.Window, rectangle_0);
				graphics_0.DrawRectangle(SystemPens.WindowText, rectangle_0);
				graphics_0.DrawLine(SystemPens.WindowText, rectangle_0.X + 2, (int)((double)rectangle_0.Y + (double)rectangle_0.Height / 2.0), rectangle_0.X + rectangle_0.Width - 2, (int)((double)rectangle_0.Y + (double)rectangle_0.Height / 2.0));
				if (!bool_0)
				{
					graphics_0.DrawLine(SystemPens.WindowText, (int)((double)rectangle_0.X + (double)rectangle_0.Width / 2.0), rectangle_0.Y + 2, (int)((double)rectangle_0.X + (double)rectangle_0.Width / 2.0), rectangle_0.Y + rectangle_0.Height - 2);
				}
			}
		}

		public static Rectangle smethod_1(int int_1, int int_2, int int_3)
		{
			if (int_3 <= 8)
			{
				int_3 = 8;
			}
			return new Rectangle(int_1 - 8 - 2, int_2 - (int)((double)(int_3 - 8) / 2.0), 8, 8);
		}

		public static Rectangle smethod_2(int int_1, int int_2, int int_3)
		{
			return new Rectangle(int_1, int_2 + (int)((double)(int_3 - 8) / 2.0), 8, 8);
		}

		private GClass257()
		{
		}
	}
}
