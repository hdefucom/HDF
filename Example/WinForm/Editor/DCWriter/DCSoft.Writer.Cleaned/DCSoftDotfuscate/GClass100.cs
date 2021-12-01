using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[DCInternal]
	[ComVisible(false)]
	public class DocumentPageDrawer
	{
		private ContentRenderMode contentRenderMode_0 = ContentRenderMode.Print;

		private string string_0 = null;

		private PageSettings pageSettings_0 = null;

		private Image image_0 = null;

		private IPageDocument ipageDocument_0 = null;

		private float float_0 = 1f;

		private float float_1 = 1f;

		private string string_1 = null;

		private PrintPageCollection printPageCollection_0 = null;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private Color color_0 = Color.White;

		private Color color_1 = Color.Transparent;

		private PageBorderBackgroundStyle pageBorderBackgroundStyle_0 = null;

		private PointF pointF_0 = PointF.Empty;

		private GClass472 gclass472_0 = null;

		private int int_0 = 60;

		private DCPrintDocumentOptions dcprintDocumentOptions_0 = null;

		protected SimpleRectangleTransform gclass435_0 = null;

		public static Bitmap smethod_0(IPageDocument ipageDocument_1, PrintPageCollection printPageCollection_1, int int_1, bool bool_2, DocumentPageDrawer gclass100_0)
		{
			gclass100_0.method_9(ipageDocument_1);
			gclass100_0.method_17(printPageCollection_1);
			gclass100_0.method_23(Color.White);
			if (bool_2)
			{
				gclass100_0.method_25(Color.Black);
			}
			else
			{
				gclass100_0.method_25(Color.Transparent);
			}
			return gclass100_0.method_36(printPageCollection_1[int_1], bool_2: true);
		}

		public static byte[] smethod_1(IPageDocument ipageDocument_1, PrintPageCollection printPageCollection_1, int int_1, bool bool_2, DocumentPageDrawer gclass100_0)
		{
			gclass100_0.method_9(ipageDocument_1);
			gclass100_0.method_17(printPageCollection_1);
			gclass100_0.method_23(Color.White);
			if (bool_2)
			{
				gclass100_0.method_25(Color.Black);
			}
			else
			{
				gclass100_0.method_25(Color.Transparent);
			}
			return gclass100_0.method_34(printPageCollection_1[int_1], bool_2: true);
		}

		public DocumentPageDrawer()
		{
		}

		public DocumentPageDrawer(IPageDocument ipageDocument_1, PrintPageCollection printPageCollection_1)
		{
			ipageDocument_0 = ipageDocument_1;
			printPageCollection_0 = printPageCollection_1;
		}

		public ContentRenderMode method_0()
		{
			return contentRenderMode_0;
		}

		public void method_1(ContentRenderMode contentRenderMode_1)
		{
			contentRenderMode_0 = contentRenderMode_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_2)
		{
			string_0 = string_2;
		}

		public PageSettings method_4()
		{
			return pageSettings_0;
		}

		public void method_5(PageSettings pageSettings_1)
		{
			pageSettings_0 = pageSettings_1;
		}

		public Image method_6()
		{
			return image_0;
		}

		public void method_7(Image image_1)
		{
			image_0 = image_1;
		}

		public IPageDocument method_8()
		{
			return ipageDocument_0;
		}

		public void method_9(IPageDocument ipageDocument_1)
		{
			ipageDocument_0 = ipageDocument_1;
			if (ipageDocument_1 != null)
			{
				printPageCollection_0 = ipageDocument_1.Pages;
			}
		}

		public float method_10()
		{
			return float_0;
		}

		public void method_11(float float_2)
		{
			float_0 = float_2;
		}

		public float method_12()
		{
			return float_1;
		}

		public void method_13(float float_2)
		{
			float_1 = float_2;
		}

		public string method_14()
		{
			return string_1;
		}

		public void method_15(string string_2)
		{
			string_1 = string_2;
		}

		public PrintPageCollection method_16()
		{
			return printPageCollection_0;
		}

		public void method_17(PrintPageCollection printPageCollection_1)
		{
			printPageCollection_0 = printPageCollection_1;
		}

		public bool method_18()
		{
			return bool_0;
		}

		public void method_19(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public bool method_20()
		{
			return bool_1;
		}

		public void method_21(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public Color method_22()
		{
			return color_0;
		}

		public void method_23(Color color_2)
		{
			color_0 = color_2;
		}

		public Color method_24()
		{
			return color_1;
		}

		public void method_25(Color color_2)
		{
			color_1 = color_2;
		}

		public PageBorderBackgroundStyle method_26()
		{
			return pageBorderBackgroundStyle_0;
		}

		public void method_27(PageBorderBackgroundStyle pageBorderBackgroundStyle_1)
		{
			pageBorderBackgroundStyle_0 = pageBorderBackgroundStyle_1;
		}

		public PointF method_28()
		{
			return pointF_0;
		}

		public void method_29(PointF pointF_1)
		{
			pointF_0 = pointF_1;
		}

		public GClass472 method_30()
		{
			return gclass472_0;
		}

		public void method_31(GClass472 gclass472_1)
		{
			gclass472_0 = gclass472_1;
		}

		public int method_32()
		{
			return int_0;
		}

		public void method_33(int int_1)
		{
			int_0 = int_1;
		}

		public byte[] method_34(PrintPage printPage_0, bool bool_2)
		{
			XPageSettings pageSettings = printPage_0.PageSettings;
			Metafile metafile = null;
			using (GClass250 gClass = GClass250.smethod_1(IntPtr.Zero))
			{
				MemoryStream memoryStream = new MemoryStream();
				metafile = new Metafile(memoryStream, gClass.method_5(), new Rectangle(0, 0, (int)printPage_0.PageSettings.ViewPaperWidth, (int)printPage_0.PageSettings.ViewPaperHeight), GClass154.smethod_8(ipageDocument_0.DocumentGraphicsUnit));
				using (Graphics graphics = Graphics.FromImage(metafile))
				{
					if (color_0.A != 0)
					{
						graphics.Clear(color_0);
					}
					graphics.PageUnit = ipageDocument_0.DocumentGraphicsUnit;
					PageFrameDrawer gClass2 = new PageFrameDrawer();
					gClass2.method_23(method_32());
					gClass2.method_25(bool_2);
					gClass2.method_31(Color.Transparent);
					gClass2.method_33(color_1);
					gClass2.method_35(1);
					gClass2.method_13((int)printPage_0.ViewLeftMargin);
					gClass2.method_15((int)printPage_0.ViewTopMargin);
					gClass2.method_17((int)printPage_0.ViewRightMargin);
					gClass2.method_19((int)printPage_0.ViewBottomMargin);
					gClass2.method_37(method_26());
					gClass2.method_9(new Rectangle(0, 0, (int)pageSettings.ViewPaperWidth, (int)pageSettings.ViewPaperHeight));
					gClass2.method_39(method_6());
					graphics.ScaleTransform(method_10(), method_12());
					gClass2.DrawPageFrame(graphics, Rectangle.Empty);
					vmethod_1(printPage_0, graphics, Rectangle.Ceiling(printPage_0.Bounds), bool_2: true);
					if (method_30() != null)
					{
						graphics.ResetClip();
						graphics.ResetTransform();
						method_30().method_28(graphics, new RectangleF(0f, 0f, pageSettings.ViewPaperWidth, pageSettings.ViewPaperHeight), bool_7: true);
					}
				}
				metafile.Dispose();
				gClass.Dispose();
				return memoryStream.ToArray();
			}
		}

		public Bitmap method_35(int int_1, bool bool_2)
		{
			return method_36(printPageCollection_0[int_1], bool_2);
		}

		public Bitmap method_36(PrintPage printPage_0, bool bool_2)
		{
			XPageSettings pageSettings = printPage_0.PageSettings;
			double rate = GraphicsUnitConvert.GetRate(ipageDocument_0.DocumentGraphicsUnit, GraphicsUnit.Pixel);
			int num = (int)(Math.Ceiling((double)pageSettings.ViewPaperWidth / rate) * (double)method_10());
			int num2 = (int)(Math.Ceiling((double)pageSettings.ViewPaperHeight / rate) * (double)method_12());
			if (num <= 0 || num2 <= 0)
			{
				return null;
			}
			Bitmap bitmap = new Bitmap(num, num2);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				if (color_0.A != 0)
				{
					graphics.Clear(color_0);
				}
				graphics.PageUnit = ipageDocument_0.DocumentGraphicsUnit;
				PageFrameDrawer gClass = new PageFrameDrawer();
				gClass.method_25(bool_2);
				gClass.method_23(method_32());
				gClass.method_31(Color.Transparent);
				gClass.method_33(color_1);
				gClass.method_35(1);
				gClass.method_13((int)(printPage_0.ViewLeftMargin * method_10()));
				gClass.method_15((int)(printPage_0.ViewTopMargin * method_12()));
				gClass.method_17((int)(printPage_0.ViewRightMargin * method_10()));
				gClass.method_19((int)(printPage_0.ViewBottomMargin * method_12()));
				gClass.method_37(method_26());
				gClass.method_9(new Rectangle(0, 0, (int)(printPage_0.ViewPaperWidth * method_10()), (int)(printPage_0.ViewPaperHeight * method_12())));
				gClass.method_39(method_6());
				if (gClass.method_38() == null && pageSettings.RuntimeEditTimeBackgroundImage != null)
				{
					gClass.method_39(pageSettings.RuntimeEditTimeBackgroundImage.Value);
				}
				gClass.method_7(pageSettings.RuntimeWatermark);
				gClass.DrawPageFrame(graphics, Rectangle.Empty);
				vmethod_1(printPage_0, graphics, Rectangle.Ceiling(printPage_0.Bounds), bool_2: true);
				if (method_30() != null)
				{
					graphics.ResetTransform();
					graphics.ResetClip();
					method_30().method_28(graphics, new RectangleF(0f, 0f, printPage_0.ViewPaperWidth, printPage_0.ViewPaperHeight), bool_7: true);
				}
			}
			return bitmap;
		}

		protected virtual void vmethod_0(PrintPage printPage_0, Graphics graphics_0)
		{
		}

		public DCPrintDocumentOptions method_37()
		{
			return dcprintDocumentOptions_0;
		}

		public void method_38(DCPrintDocumentOptions dcprintDocumentOptions_1)
		{
			dcprintDocumentOptions_0 = dcprintDocumentOptions_1;
		}

		public SimpleRectangleTransform method_39()
		{
			return gclass435_0;
		}

		public virtual PrintPageResult vmethod_1(PrintPage printPage_0, Graphics graphics_0, Rectangle rectangle_0, bool bool_2)
		{
			PrintPageResult printPageResult = new PrintPageResult();
			printPageResult.Page = printPage_0;
			printPageResult.ContentHeight = printPage_0.Height;
			printPageResult.StartPositionInPage = printPage_0.Height;
			int num = 0;
			int num2 = 0;
			if (bool_2)
			{
				num = (int)printPage_0.ViewLeftMargin;
				num2 = (int)printPage_0.ViewTopMargin;
				_ = (int)printPage_0.ViewRightMargin;
				_ = (int)printPage_0.ViewBottomMargin;
			}
			vmethod_0(printPage_0, graphics_0);
			IntPtr hdc = graphics_0.GetHdc();
			new GClass294(hdc);
			graphics_0.ReleaseHdc();
			graphics_0.PageUnit = ipageDocument_0.DocumentGraphicsUnit;
			Rectangle rectangle = Rectangle.Empty;
			if (string_1 != null)
			{
				graphics_0.DrawString(string_1, Control.DefaultFont, Brushes.Red, 20f, 20f, StringFormat.GenericDefault);
			}
			float num3 = (float)GraphicsUnitConvert.Convert((double)pointF_0.X / 100.0, GraphicsUnit.Inch, ipageDocument_0.DocumentGraphicsUnit);
			float num4 = (float)GraphicsUnitConvert.Convert((double)pointF_0.Y / 100.0, GraphicsUnit.Inch, ipageDocument_0.DocumentGraphicsUnit);
			if (method_26() != null)
			{
				using (Pen pen = method_26().method_15())
				{
					graphics_0.ResetTransform();
					graphics_0.ResetClip();
					graphics_0.ScaleTransform(method_10(), method_12());
					graphics_0.TranslateTransform((float)num - num3, (float)num2 - num4);
					Rectangle rect = new Rectangle((int)(0f + method_26().PaddingLeft), (int)(0f + method_26().PaddingTop), (int)(printPage_0.ViewPaperWidth - method_26().PaddingLeft - method_26().PaddingRight), (int)(printPage_0.ViewPaperHeight - method_26().PaddingTop - method_26().PaddingBottom));
					graphics_0.DrawRectangle(pen, rect);
				}
			}
			if (method_18())
			{
				if (printPage_0.HeaderContentHeight > 0f)
				{
					graphics_0.ResetTransform();
					graphics_0.ResetClip();
					rectangle = new Rectangle(0, 0, (int)Math.Ceiling(printPage_0.Width), (int)Math.Ceiling(printPage_0.HeaderContentHeight));
					printPageResult.StartPositionInPage = Math.Min(printPageResult.StartPositionInPage, (float)num2 - num4);
					graphics_0.ScaleTransform(method_10(), method_12());
					graphics_0.TranslateTransform((float)num - num3, (float)num2 - num4);
					graphics_0.SetClip(new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width + 1, rectangle.Height + 1));
					PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(graphics_0, rectangle, ipageDocument_0, printPage_0, printPage_0.FirstPageFlag ? PageContentPartyStyle.HeaderForFirstPage : PageContentPartyStyle.Header, null);
					pageDocumentPaintEventArgs.Options = method_37();
					pageDocumentPaintEventArgs.ContentBounds = rectangle;
					pageDocumentPaintEventArgs.PageClipRectangle = rectangle;
					pageDocumentPaintEventArgs.PageIndex = printPage_0.GlobalIndex;
					pageDocumentPaintEventArgs.NumberOfPages = method_16().Count;
					pageDocumentPaintEventArgs.ContentBounds = rectangle;
					if (printPage_0.PageSettings.method_3(printPage_0.PageIndex))
					{
						ipageDocument_0.DrawContent(pageDocumentPaintEventArgs);
					}
				}
				graphics_0.ResetClip();
				graphics_0.ResetTransform();
				if (!printPage_0.HeaderRowsBounds.IsEmpty)
				{
					graphics_0.ResetTransform();
					graphics_0.ResetClip();
					printPageResult.StartPositionInPage = Math.Min(printPage_0.HeaderRowsBounds.Top, printPageResult.StartPositionInPage);
					rectangle = new Rectangle((int)printPage_0.HeaderRowsBounds.Left - 1, (int)printPage_0.HeaderRowsBounds.Top - 1, (int)printPage_0.HeaderRowsBounds.Width + 1, (int)printPage_0.HeaderRowsBounds.Height + 1);
					graphics_0.ScaleTransform(method_10(), method_12());
					graphics_0.TranslateTransform((float)num - num3, (float)num2 - num4 - printPage_0.HeaderRowsBounds.Top);
					graphics_0.SetClip(new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width + 1, rectangle.Height + 1));
					PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(graphics_0, rectangle, ipageDocument_0, printPage_0, PageContentPartyStyle.Header, null);
					pageDocumentPaintEventArgs.ContentBounds = rectangle;
					pageDocumentPaintEventArgs.PageClipRectangle = rectangle;
					pageDocumentPaintEventArgs.PageIndex = printPage_0.GlobalIndex;
					pageDocumentPaintEventArgs.NumberOfPages = method_16().Count;
					pageDocumentPaintEventArgs.ContentBounds = rectangle;
					ipageDocument_0.DrawContent(pageDocumentPaintEventArgs);
				}
			}
			rectangle = new Rectangle(0, (int)Math.Floor(printPage_0.Top), (int)Math.Ceiling(printPage_0.Width), (int)Math.Ceiling(printPage_0.Height));
			if (!rectangle_0.IsEmpty)
			{
				rectangle = Rectangle.Intersect(rectangle, rectangle_0);
			}
			if (!rectangle.IsEmpty)
			{
				graphics_0.ScaleTransform(method_10(), method_12());
				graphics_0.TranslateTransform((float)num - num3, (float)num2 - printPage_0.Top + printPage_0.HeaderContentHeight + printPage_0.HeaderRowsBounds.Height - num4);
				PointF[] array = new PointF[2]
				{
					new PointF(printPage_0.Left, printPage_0.Top),
					new PointF(printPage_0.Left + printPage_0.Width, printPage_0.Top + printPage_0.Height)
				};
				graphics_0.Transform.TransformPoints(array);
				gclass435_0 = new SimpleRectangleTransform();
				gclass435_0.setSourceRectF(new RectangleF(array[0].X, array[0].Y, array[1].X - array[0].X, array[1].Y - array[0].Y));
				gclass435_0.set_DescRectF(new RectangleF(printPage_0.Left, printPage_0.Top, printPage_0.Width, printPage_0.Height));
				printPageResult.StartPositionInPage = Math.Min(printPageResult.StartPositionInPage, array[0].Y);
				RectangleF clip = DrawerUtil.FixClipBounds(graphics_0, rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
				clip.Offset(-4f, -4f);
				clip.Width += 8f;
				clip.Height += 8f;
				graphics_0.SetClip(clip);
				PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(graphics_0, rectangle, ipageDocument_0, printPage_0, PageContentPartyStyle.Body, null);
				pageDocumentPaintEventArgs.PageIndex = printPage_0.GlobalIndex;
				pageDocumentPaintEventArgs.NumberOfPages = method_16().Count;
				pageDocumentPaintEventArgs.ContentBounds = rectangle;
				pageDocumentPaintEventArgs.PageClipRectangle = new RectangleF(0f, printPage_0.Top, printPage_0.Width, printPage_0.Height);
				pageDocumentPaintEventArgs.PageClipRectangle = rectangle;
				ipageDocument_0.DrawContent(pageDocumentPaintEventArgs);
			}
			if (method_20() && printPage_0.FooterContentHeight > 0f)
			{
				graphics_0.ResetClip();
				graphics_0.ResetTransform();
				float documentHeight = printPage_0.DocumentHeight;
				rectangle = new Rectangle(0, (int)Math.Floor(documentHeight - printPage_0.FooterContentHeight), (int)Math.Ceiling(printPage_0.Width), (int)Math.Ceiling(printPage_0.FooterContentHeight));
				int num5 = 0;
				num5 = ((!bool_2) ? ((int)(printPage_0.ViewPaperHeight - printPage_0.ViewBottomMargin - printPage_0.ViewTopMargin)) : ((int)(printPage_0.ViewPaperHeight - printPage_0.ViewBottomMargin)));
				graphics_0.ScaleTransform(method_10(), method_12());
				graphics_0.TranslateTransform((float)num - num3, (float)num5 - num4);
				graphics_0.SetClip(new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width + 1, rectangle.Height + 1));
				PageDocumentPaintEventArgs pageDocumentPaintEventArgs = new PageDocumentPaintEventArgs(graphics_0, rectangle, ipageDocument_0, printPage_0, (!printPage_0.FirstPageFlag) ? PageContentPartyStyle.Footer : PageContentPartyStyle.FooterForFirstPage, null);
				pageDocumentPaintEventArgs.ContentBounds = rectangle;
				pageDocumentPaintEventArgs.PageClipRectangle = rectangle;
				pageDocumentPaintEventArgs.PageIndex = printPage_0.GlobalIndex;
				pageDocumentPaintEventArgs.NumberOfPages = method_16().Count;
				if (printPage_0.PageSettings.method_3(printPage_0.PageIndex))
				{
					ipageDocument_0.DrawContent(pageDocumentPaintEventArgs);
				}
			}
			return printPageResult;
		}
	}
}
