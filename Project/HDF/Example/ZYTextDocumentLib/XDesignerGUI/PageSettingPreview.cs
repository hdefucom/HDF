using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace XDesignerGUI
{
	public class PageSettingPreview
	{
		private PaperSize myPaperSize = null;

		private Margins myMargins = new Margins(100, 100, 100, 100);

		private bool bolLandscape = false;

		private Rectangle myBounds = Rectangle.Empty;

		public PaperSize PaperSize
		{
			get
			{
				return myPaperSize;
			}
			set
			{
				myPaperSize = value;
			}
		}

		public Margins Margins
		{
			get
			{
				return myMargins;
			}
			set
			{
				myMargins = value;
			}
		}

		public bool Landscape
		{
			get
			{
				return bolLandscape;
			}
			set
			{
				bolLandscape = value;
			}
		}

		public Rectangle Bounds
		{
			get
			{
				return myBounds;
			}
			set
			{
				myBounds = value;
			}
		}

		public void SetPagetSettings(PageSettings ps)
		{
			myPaperSize = ps.PaperSize;
			myMargins = ps.Margins;
			bolLandscape = ps.Landscape;
		}

		public void OnPaint(object sender, PaintEventArgs e)
		{
			int num = (!bolLandscape) ? myPaperSize.Width : myPaperSize.Height;
			int num2 = (!bolLandscape) ? myPaperSize.Height : myPaperSize.Width;
			double num3 = 1.0;
			num3 = ((!((double)num / (double)myBounds.Width > (double)num2 / (double)myBounds.Height)) ? (1.1 * (double)num2 / (double)myBounds.Height) : (1.1 * (double)num / (double)myBounds.Width));
			Rectangle rect = new Rectangle(0, 0, (int)((double)num / num3), (int)((double)num2 / num3));
			rect.X = myBounds.Left + (myBounds.Width - rect.Width) / 2;
			rect.Y = myBounds.Top + (myBounds.Height - rect.Height) / 2;
			if (rect.IntersectsWith(e.ClipRectangle))
			{
				e.Graphics.FillRectangle(Brushes.White, rect);
				e.Graphics.DrawRectangle(Pens.Black, rect);
				Rectangle rect2 = new Rectangle((int)((double)rect.Left + (double)myMargins.Left / num3), (int)((double)rect.Top + (double)myMargins.Top / num3), (int)((double)rect.Width - (double)(myMargins.Left + myMargins.Right) / num3), (int)((double)rect.Height - (double)(myMargins.Top + myMargins.Bottom) / num3));
				e.Graphics.DrawRectangle(Pens.Red, rect2);
			}
		}
	}
}
