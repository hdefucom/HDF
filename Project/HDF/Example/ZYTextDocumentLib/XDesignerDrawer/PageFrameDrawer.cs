using System.Drawing;
using System.Drawing.Printing;
using XDesignerCommon;

namespace XDesignerDrawer
{
	public class PageFrameDrawer
	{
		private Rectangle myBounds = Rectangle.Empty;

		private int intLeftMargin = 20;

		private int intTopMargin = 30;

		private int intRightMargin = 20;

		private int intBottomMargin = 40;

		private int intMarginLineLength = 60;

		private bool bolDrawMargin = true;

		private Color intMarginLineColor = SystemColors.Control;

		private Color intBackColor = Color.White;

		private Color intBorderColor = Color.Black;

		private int intBorderWidth = 1;

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

		public int LeftMargin
		{
			get
			{
				return intLeftMargin;
			}
			set
			{
				intLeftMargin = value;
			}
		}

		public int TopMargin
		{
			get
			{
				return intTopMargin;
			}
			set
			{
				intTopMargin = value;
			}
		}

		public int RightMargin
		{
			get
			{
				return intRightMargin;
			}
			set
			{
				intRightMargin = value;
			}
		}

		public int BottomMargin
		{
			get
			{
				return intBottomMargin;
			}
			set
			{
				intBottomMargin = value;
			}
		}

		public Margins Margins
		{
			get
			{
				return new Margins(intLeftMargin, intRightMargin, intTopMargin, intBottomMargin);
			}
			set
			{
				intLeftMargin = value.Left;
				intTopMargin = value.Top;
				intRightMargin = value.Right;
				intBottomMargin = value.Bottom;
			}
		}

		public int MarginLineLength
		{
			get
			{
				return intMarginLineLength;
			}
			set
			{
				intMarginLineLength = value;
			}
		}

		public bool DrawMargin
		{
			get
			{
				return bolDrawMargin;
			}
			set
			{
				bolDrawMargin = value;
			}
		}

		public Color MarginLineColor
		{
			get
			{
				return intMarginLineColor;
			}
			set
			{
				intMarginLineColor = value;
			}
		}

		public Color BackColor
		{
			get
			{
				return intBackColor;
			}
			set
			{
				intBackColor = value;
			}
		}

		public Color BorderColor
		{
			get
			{
				return intBorderColor;
			}
			set
			{
				intBorderColor = value;
			}
		}

		public int BorderWidth
		{
			get
			{
				return intBorderWidth;
			}
			set
			{
				intBorderWidth = value;
			}
		}

		public static void DrawPageFrame(Rectangle bounds, Margins m, Graphics g, Rectangle ClipRectangle, bool HightlightingBorder, bool FillBackground)
		{
			PageFrameDrawer pageFrameDrawer = new PageFrameDrawer();
			pageFrameDrawer.Bounds = bounds;
			pageFrameDrawer.Margins = m;
			if (HightlightingBorder)
			{
				pageFrameDrawer.BorderColor = Color.Blue;
			}
			else
			{
				pageFrameDrawer.BorderColor = Color.Black;
			}
			pageFrameDrawer.BorderWidth = 3;
			if (FillBackground)
			{
				pageFrameDrawer.BackColor = SystemColors.Window;
			}
			else
			{
				pageFrameDrawer.BackColor = Color.Transparent;
			}
			pageFrameDrawer.DrawPageFrame(g, ClipRectangle);
		}

		public PageFrameDrawer()
		{
		}

		public PageFrameDrawer(Rectangle bounds, Margins m)
		{
			myBounds = bounds;
			Margins = m;
		}

		public void DrawPageFrame(Graphics g, Rectangle ClipRectangle)
		{
			using (RectangleDrawer rectangleDrawer = new RectangleDrawer())
			{
				rectangleDrawer.Bounds = myBounds;
				if (intBorderColor.A != 0 && intBorderWidth > 0)
				{
					rectangleDrawer.BorderPen = new Pen(intBorderColor, intBorderWidth);
				}
				if (intBackColor.A != 0)
				{
					rectangleDrawer.FillBrush = new SolidBrush(intBackColor);
				}
				if (rectangleDrawer.Draw(g, ClipRectangle) && bolDrawMargin && intMarginLineColor.A != 0 && intMarginLineLength > 0)
				{
					Rectangle rectangle = new Rectangle(myBounds.Left + intLeftMargin, myBounds.Top + intTopMargin, myBounds.Width - intLeftMargin - intRightMargin, myBounds.Height - intTopMargin - intBottomMargin);
					Point[] array = new Point[16]
					{
						rectangle.Location,
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point),
						default(Point)
					};
					array[1].X = rectangle.Left - intMarginLineLength;
					array[1].Y = rectangle.Top;
					array[2] = array[0];
					array[3].X = rectangle.Left;
					array[3].Y = rectangle.Top - intMarginLineLength;
					array[4].X = rectangle.Right;
					array[4].Y = rectangle.Top;
					array[5].X = rectangle.Right + intMarginLineLength;
					array[5].Y = rectangle.Top;
					array[6] = array[4];
					array[7].X = rectangle.Right;
					array[7].Y = rectangle.Top - intMarginLineLength;
					array[8].X = rectangle.Right;
					array[8].Y = rectangle.Bottom;
					array[9].X = rectangle.Right + intMarginLineLength;
					array[9].Y = rectangle.Bottom;
					array[10] = array[8];
					array[11].X = rectangle.Right;
					array[11].Y = rectangle.Bottom + intMarginLineLength;
					array[12].X = rectangle.Left;
					array[12].Y = rectangle.Bottom;
					array[13].X = rectangle.Left;
					array[13].Y = rectangle.Bottom + intMarginLineLength;
					array[14] = array[12];
					array[15].X = rectangle.Left - intMarginLineLength;
					array[15].Y = rectangle.Bottom;
					MathCommon.RectangleClipLines(myBounds, array);
					using (Pen pen = new Pen(intMarginLineColor, 1f))
					{
						for (int i = 0; i < array.Length; i += 2)
						{
							g.DrawLine(pen, array[i], array[i + 1]);
						}
					}
				}
			}
		}
	}
}
