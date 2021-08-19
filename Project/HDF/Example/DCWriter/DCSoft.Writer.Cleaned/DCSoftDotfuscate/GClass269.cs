using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass269
	{
		private PaperSize paperSize_0 = null;

		private Margins margins_0 = new Margins(100, 100, 100, 100);

		private bool bool_0 = false;

		private Rectangle rectangle_0 = Rectangle.Empty;

		public PaperSize method_0()
		{
			return paperSize_0;
		}

		public void method_1(PaperSize paperSize_1)
		{
			paperSize_0 = paperSize_1;
		}

		public Margins method_2()
		{
			return margins_0;
		}

		public void method_3(Margins margins_1)
		{
			margins_0 = margins_1;
		}

		public bool method_4()
		{
			return bool_0;
		}

		public void method_5(bool bool_1)
		{
			bool_0 = bool_1;
		}

		public void method_6(PageSettings pageSettings_0)
		{
			paperSize_0 = pageSettings_0.PaperSize;
			margins_0 = pageSettings_0.Margins;
			bool_0 = pageSettings_0.Landscape;
		}

		public Rectangle method_7()
		{
			return rectangle_0;
		}

		public void method_8(Rectangle rectangle_1)
		{
			rectangle_0 = rectangle_1;
		}

		public void method_9(object sender, PaintEventArgs e)
		{
			int num = (!bool_0) ? paperSize_0.Width : paperSize_0.Height;
			int num2 = (!bool_0) ? paperSize_0.Height : paperSize_0.Width;
			double num3 = 1.0;
			num3 = ((!((double)num / (double)rectangle_0.Width > (double)num2 / (double)rectangle_0.Height)) ? (1.1 * (double)num2 / (double)rectangle_0.Height) : (1.1 * (double)num / (double)rectangle_0.Width));
			Rectangle rect = new Rectangle(0, 0, (int)((double)num / num3), (int)((double)num2 / num3));
			rect.X = rectangle_0.Left + (rectangle_0.Width - rect.Width) / 2;
			rect.Y = rectangle_0.Top + (rectangle_0.Height - rect.Height) / 2;
			if (rect.IntersectsWith(e.ClipRectangle))
			{
				e.Graphics.FillRectangle(Brushes.White, rect);
				e.Graphics.DrawRectangle(Pens.Black, rect);
				Rectangle rect2 = new Rectangle((int)((double)rect.Left + (double)margins_0.Left / num3), (int)((double)rect.Top + (double)margins_0.Top / num3), (int)((double)rect.Width - (double)(margins_0.Left + margins_0.Right) / num3), (int)((double)rect.Height - (double)(margins_0.Top + margins_0.Bottom) / num3));
				e.Graphics.DrawRectangle(Pens.Red, rect2);
			}
		}
	}
}
