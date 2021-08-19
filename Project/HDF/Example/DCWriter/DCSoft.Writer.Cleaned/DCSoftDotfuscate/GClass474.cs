using DCSoft.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class PageFrameDrawer
	{
		private bool bool_0 = false;

		private float float_0 = 1f;

		private DocumentTerminalTextInfo documentTerminalTextInfo_0 = null;

		private WatermarkInfo watermarkInfo_0 = null;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private Rectangle rectangle_1 = Rectangle.Empty;

		private int int_0 = 20;

		private int int_1 = 30;

		private int int_2 = 20;

		private int int_3 = 40;

		private int int_4 = 60;

		private bool DrawMargin = true;

		private Color color_0 = Color.FromArgb(170, 170, 170);

		private bool bool_2 = true;

		private Color color_1 = Color.White;

		private Color color_2 = Color.Black;

		private int int_5 = 1;

		private PageBorderBackgroundStyle pageBorderBackgroundStyle_0 = null;

		private Image image_0 = null;

		private GClass543 gclass543_0 = null;

		public static void DrawPageFrame(Rectangle rectangle_2, Margins margins_0, Graphics graphics_0, Rectangle rectangle_3, bool bool_3, Color color_3)
		{
			PageFrameDrawer gClass = new PageFrameDrawer();
			gClass.method_9(rectangle_2);
			gClass.method_21(margins_0);
			if (bool_3)
			{
				gClass.method_33(Color.Blue);
			}
			else
			{
				gClass.method_33(Color.Black);
			}
			gClass.method_35(5);
			gClass.method_31(color_3);
			gClass.DrawPageFrame(graphics_0, rectangle_3);
		}

		public PageFrameDrawer()
		{
		}

		public PageFrameDrawer(Rectangle rectangle_2, Margins margins_0)
		{
			rectangle_0 = rectangle_2;
			method_21(margins_0);
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public float method_2()
		{
			return float_0;
		}

		public void method_3(float float_1)
		{
			float_0 = float_1;
		}

		public DocumentTerminalTextInfo method_4()
		{
			return documentTerminalTextInfo_0;
		}

		public void method_5(DocumentTerminalTextInfo documentTerminalTextInfo_1)
		{
			documentTerminalTextInfo_0 = documentTerminalTextInfo_1;
		}

		public WatermarkInfo method_6()
		{
			return watermarkInfo_0;
		}

		public void method_7(WatermarkInfo watermarkInfo_1)
		{
			watermarkInfo_0 = watermarkInfo_1;
		}

		public Rectangle method_8()
		{
			return rectangle_0;
		}

		public void method_9(Rectangle rectangle_2)
		{
			rectangle_0 = rectangle_2;
		}

		public Rectangle method_10()
		{
			return rectangle_1;
		}

		public void method_11(Rectangle rectangle_2)
		{
			rectangle_1 = rectangle_2;
		}

		public int method_12()
		{
			return int_0;
		}

		public void method_13(int int_6)
		{
			int_0 = int_6;
		}

		public int method_14()
		{
			return int_1;
		}

		public void method_15(int int_6)
		{
			int_1 = int_6;
		}

		public int method_16()
		{
			return int_2;
		}

		public void method_17(int int_6)
		{
			int_2 = int_6;
		}

		public int method_18()
		{
			return int_3;
		}

		public void method_19(int int_6)
		{
			int_3 = int_6;
		}

		public Margins method_20()
		{
			return new Margins(int_0, int_2, int_1, int_3);
		}

		public void method_21(Margins margins_0)
		{
			int_0 = margins_0.Left;
			int_1 = margins_0.Top;
			int_2 = margins_0.Right;
			int_3 = margins_0.Bottom;
		}

		public int method_22()
		{
			return int_4;
		}

		public void method_23(int int_6)
		{
			int_4 = int_6;
		}

		public bool method_24()
		{
			return DrawMargin;
		}

		public void method_25(bool bool_3)
		{
			DrawMargin = bool_3;
		}

		public Color method_26()
		{
			return color_0;
		}

		public void method_27(Color color_3)
		{
			color_0 = color_3;
		}

		public bool method_28()
		{
			return bool_2;
		}

		public void method_29(bool bool_3)
		{
			bool_2 = bool_3;
		}

		public Color method_30()
		{
			return color_1;
		}

		public void method_31(Color color_3)
		{
			color_1 = color_3;
		}

		public Color method_32()
		{
			return color_2;
		}

		public void method_33(Color color_3)
		{
			color_2 = color_3;
		}

		public int method_34()
		{
			return int_5;
		}

		public void method_35(int int_6)
		{
			int_5 = int_6;
		}

		public PageBorderBackgroundStyle method_36()
		{
			return pageBorderBackgroundStyle_0;
		}

		public void method_37(PageBorderBackgroundStyle pageBorderBackgroundStyle_1)
		{
			pageBorderBackgroundStyle_0 = pageBorderBackgroundStyle_1;
		}

		public Image method_38()
		{
			return image_0;
		}

		public void method_39(Image image_1)
		{
			image_0 = image_1;
		}

		public GClass543 method_40()
		{
			return gclass543_0;
		}

		public void method_41(GClass543 gclass543_1)
		{
			gclass543_0 = gclass543_1;
		}

		private GraphicsPath method_42()
		{
			return ShapeDrawer.CreateRoundRectanglePath(new RectangleF(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height), 30f);
		}

		public void DrawPageFrame(Graphics graphics_0, Rectangle rectangle_2)
		{
			using (RectangleDrawer gClass = new RectangleDrawer())
			{
				gClass.method_1(rectangle_0);
				gClass.method_3(9);
				if (method_32().A != 0 && method_34() > 0)
				{
					gClass.method_5(new Pen(method_32(), method_34()));
				}
				if (method_28())
				{
					if (method_36() != null && method_36().BackgroundColor.A != 0)
					{
						gClass.method_9(new SolidBrush(method_36().BackgroundColor));
					}
					else if (method_30().A != 0)
					{
						gClass.method_9(new SolidBrush(method_30()));
					}
				}
				if (gClass.method_13(graphics_0, rectangle_2))
				{
					if (method_0())
					{
						using (Pen pen = DrawerUtil.CreateSelectionPen(6f, IsCurrent: true))
						{
							graphics_0.DrawRectangle(pen, gClass.method_0());
						}
					}
					bool flag = false;
					if (method_38() != null)
					{
						Rectangle rectangle = new Rectangle(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height);
						if (!rectangle_2.IsEmpty)
						{
							rectangle = Rectangle.Intersect(rectangle, rectangle_2);
						}
						if (!rectangle.IsEmpty)
						{
							using (TextureBrush textureBrush = new TextureBrush(method_38()))
							{
								textureBrush.WrapMode = WrapMode.Tile;
								float num = (float)GraphicsUnitConvert.GetRate(graphics_0.PageUnit, GraphicsUnit.Pixel) * method_2();
								textureBrush.TranslateTransform(rectangle_0.Left, rectangle_0.Top);
								textureBrush.ScaleTransform(num, num);
								graphics_0.FillRectangle(textureBrush, rectangle);
							}
							flag = true;
						}
					}
					if (method_6() != null && method_6().ShowWatermark)
					{
						RectangleF rectangleF_ = new RectangleF(rectangle_0.Left + method_12(), rectangle_0.Top + method_14(), rectangle_0.Width - method_12() - method_16(), rectangle_0.Height - method_14() - method_18());
						Rectangle rectangle = new Rectangle(rectangle_0.Left, rectangle_0.Top, rectangle_0.Width, rectangle_0.Height);
						if (!rectangle_2.IsEmpty)
						{
							rectangle = Rectangle.Intersect(rectangle, rectangle_2);
						}
						method_6().method_4(rectangleF_, new DCGraphics(graphics_0), rectangle);
						flag = true;
					}
					if (flag)
					{
						gClass.method_14(graphics_0, rectangle_2);
					}
					if (method_24() && method_26().A != 0 && method_22() > 0)
					{
						Rectangle rectangle2 = new Rectangle(rectangle_0.Left + method_12() - 1, rectangle_0.Top + method_14(), rectangle_0.Width - method_12() - method_16() + 2, rectangle_0.Height - method_14() - method_18());
						Point[] array = new Point[16]
						{
							rectangle2.Location,
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
						array[1].X = rectangle2.Left - method_22();
						array[1].Y = rectangle2.Top;
						array[2] = array[0];
						array[3].X = rectangle2.Left;
						array[3].Y = rectangle2.Top - method_22();
						array[4].X = rectangle2.Right;
						array[4].Y = rectangle2.Top;
						array[5].X = rectangle2.Right + method_22();
						array[5].Y = rectangle2.Top;
						array[6] = array[4];
						array[7].X = rectangle2.Right;
						array[7].Y = rectangle2.Top - method_22();
						array[8].X = rectangle2.Right;
						array[8].Y = rectangle2.Bottom;
						array[9].X = rectangle2.Right + method_22();
						array[9].Y = rectangle2.Bottom;
						array[10] = array[8];
						array[11].X = rectangle2.Right;
						array[11].Y = rectangle2.Bottom + method_22();
						array[12].X = rectangle2.Left;
						array[12].Y = rectangle2.Bottom;
						array[13].X = rectangle2.Left;
						array[13].Y = rectangle2.Bottom + method_22();
						array[14] = array[12];
						array[15].X = rectangle2.Left - method_22();
						array[15].Y = rectangle2.Bottom;
						MathCommon.RectangleClipLines(rectangle_0, array);
						using (Pen pen = new Pen(method_26(), 1f))
						{
							for (int i = 0; i < array.Length; i += 2)
							{
								graphics_0.DrawLine(pen, array[i], array[i + 1]);
							}
						}
					}
				}
				if ((method_40() == null || !method_40().method_0()) && method_36() != null && method_36().BorderRange != 0)
				{
					Rectangle rectangle2 = method_8();
					if (method_36().BorderRange == PageBorderRangeTypes.Page)
					{
						float num2 = method_36().PaddingLeft;
						if (num2 <= 0f)
						{
							num2 = method_12() / 2;
						}
						float num3 = method_36().PaddingTop;
						if (num3 <= 0f)
						{
							num3 = method_14() / 2;
						}
						float num4 = method_36().PaddingRight;
						if (num4 <= 0f)
						{
							num4 = method_16() / 2;
						}
						float num5 = method_36().PaddingBottom;
						if (num5 <= 0f)
						{
							num5 = method_18() / 2;
						}
						rectangle2.Width = (int)((float)rectangle2.Width - num2 - num4);
						rectangle2.Height = (int)((float)rectangle2.Height - num3 - num5);
						rectangle2.Offset((int)num2, (int)num3);
					}
					else if (method_36().BorderRange == PageBorderRangeTypes.Body)
					{
						rectangle2.Offset(method_12(), method_14());
						rectangle2.Width = rectangle2.Width - method_12() - method_16();
						rectangle2.Height = rectangle2.Height - method_14() - method_18();
						if (!method_10().IsEmpty)
						{
							_ = method_10().Top - method_8().Top;
							if (rectangle2.Bottom >= method_10().Bottom - 3)
							{
							}
							rectangle2.Y = method_10().Y;
							rectangle2.Height = method_10().Height;
						}
					}
					if (method_36().HasVisibleBorder)
					{
						method_36().method_19(graphics_0, rectangle2);
					}
				}
				if (method_40() != null && method_40().method_0())
				{
					Rectangle a = new Rectangle((int)((float)(rectangle_0.Right - method_16()) + method_40().method_10()), rectangle_0.Top, (int)((float)method_16() - method_40().method_10()), rectangle_0.Height);
					if (!rectangle_2.IsEmpty)
					{
						a = Rectangle.Intersect(a, rectangle_2);
						if (!a.IsEmpty)
						{
							using (SolidBrush brush = new SolidBrush(SystemColors.ControlLight))
							{
								graphics_0.FillRectangle(brush, a);
							}
							gClass.method_14(graphics_0, rectangle_2);
						}
					}
				}
			}
		}
	}
}
